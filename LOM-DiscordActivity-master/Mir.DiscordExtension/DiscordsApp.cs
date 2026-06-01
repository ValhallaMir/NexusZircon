using Mir.DiscordExtension.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Mir.DiscordExtension
{
    public class DiscordsApp
    {
        public bool Running { get; private set; }

        private bool _stop;

        public bool Stop
        {
            get => _stop;
            set
            {
                if (_stop == value)
                    return;
                _stop = value;
                if (_stop)
                    StopApp();
            }
        }

        private static readonly DiscordsApp Instance = new DiscordsApp();
        public static DiscordsApp GetApp() => Instance;

        private readonly DiscordSettings _settings;
        private const string SettingsFile = @".\DiscordSettings.json";
        private long _clientId;
        private GameStage _currentState = new GameStage();
        private string _largeImageKey = string.Empty;
        private string _largeImageText = string.Empty;
        private string _smallImageKey = string.Empty;
        private string _smallImageText = string.Empty;
        private DateTime _startTime = DateTime.UtcNow;
        private Timer _callbackTimer;

        public event EventHandler Started;
        public event EventHandler Stopped;
        public event EventHandler StartFailure;
        public event EventHandler HasException;
        public event EventHandler ActivityCallBack;

        public long ClientId
        {
            get => _clientId;
            set => _clientId = value;
        }

        private DiscordsApp()
        {
            if (!File.Exists(SettingsFile))
            {
                _settings = new DiscordSettings();
                File.WriteAllText(SettingsFile, JsonConvert.SerializeObject(_settings, Formatting.Indented));
            }
            else
            {
                _settings = JsonConvert.DeserializeObject<DiscordSettings>(File.ReadAllText(SettingsFile));
            }
        }

        public void StartApp()
        {
            try
            {
                if (Running)
                    return;

                if (!DiscordSocialBridge.DiscordBridge_Initialize((ulong)_clientId))
                {
                    StartFailure?.Invoke((byte)0, EventArgs.Empty);
                    return;
                }

                Running = true;
                _startTime = DateTime.UtcNow;
                _callbackTimer = new Timer(_ => RunCallbacks(), null, 0, 1000);
                Started?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception e)
            {
                HasException?.Invoke(e, EventArgs.Empty);
                StartFailure?.Invoke((byte)1, EventArgs.Empty);
            }
        }

        public void StopApp()
        {
            try
            {
                _callbackTimer?.Dispose();
                _callbackTimer = null;
                DiscordSocialBridge.DiscordBridge_Shutdown();
            }
            catch (Exception e)
            {
                HasException?.Invoke(e, EventArgs.Empty);
            }
            finally
            {
                Running = false;
                Stopped?.Invoke(this, EventArgs.Empty);
            }
        }

        public void StartLoop()
        {
            RunCallbacks();
        }

        private void RunCallbacks()
        {
            if (!Running)
                return;

            try
            {
                DiscordSocialBridge.DiscordBridge_RunCallbacks();
            }
            catch (Exception e)
            {
                HasException?.Invoke(e, EventArgs.Empty);
            }
        }

        public void UpdateStage(StatusType statusType, params object[] inputs)
        {
            switch (statusType)
            {
                case StatusType.PlayerCount:
                    _currentState.UpdatePlayerCount((int)inputs[0]);
                    break;
                case StatusType.ObserverCount:
                    _currentState.UpdateObserverCount((int)inputs[0]);
                    break;
                case StatusType.GameState:
                    var nextState = (GameState)inputs[0];
                    _currentState.UpdateState(nextState);
                    if (nextState != GameState.Playing && nextState != GameState.PlayingGroup)
                        ClearGameplayFields();
                    break;
                case StatusType.Party:
                    _currentState.UpdateParty((int)inputs[0], (int)inputs[1]);
                    break;
                case StatusType.PlayerName:
                    _currentState.UpdatePlayerName((string)inputs[0]);
                    break;
                case StatusType.PlayerLevel:
                    _currentState.UpdatePlayerLevel((string)inputs[0]);
                    break;
                case StatusType.PlayerRebirth:
                    _currentState.UpdatePlayerRebirth((string)inputs[0]);
                    break;
                case StatusType.PlayerClass:
                    _currentState.UpdatePlayersClass((string)inputs[0]);
                    break;
                case StatusType.SmallImage:
                    _currentState.UpdateSmallImage((string)inputs[0]);
                    _smallImageKey = _currentState.SmallImage;
                    break;
                case StatusType.SmallImageText:
                    _currentState.UpdateSmallImageText((string)inputs[0]);
                    _smallImageText = _currentState.SmallImageText;
                    break;
                case StatusType.LargeImage:
                    _currentState.UpdateLargeImage((string)inputs[0]);
                    _largeImageKey = _currentState.LargeImage;
                    break;
                case StatusType.LargeImageText:
                    _currentState.UpdateLargeImageText((string)inputs[0]);
                    _largeImageText = _currentState.LargeImageText;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(statusType), statusType, Resources.DiscordsApp_UpdateStage_Invalid_status_Type);
            }
        }

        public void UpdateActivity()
        {
            try
            {
                if (!Running)
                    return;

                var details = BuildDetails();
                var state = BuildState();
                var result = DiscordSocialBridge.DiscordBridge_UpdatePresence(
                    details,
                    state,
                    _largeImageKey,
                    _largeImageText,
                    _smallImageKey,
                    _smallImageText,
                    _settings.ButtonLabel,
                    _settings.ButtonUrl,
                    _settings.SecondButtonLabel,
                    _settings.SecondButtonUrl);

                ActivityCallBack?.Invoke(result, EventArgs.Empty);
            }
            catch (Exception e)
            {
                HasException?.Invoke(e, EventArgs.Empty);
            }
        }

        private string BuildState()
        {
            var activity = _settings.ShowGroup && _currentState.State == GameState.PlayingGroup
                ? _currentState.State.ToString()
                : !_settings.ShowGroup && _currentState.State == GameState.PlayingGroup
                    ? GameState.Playing + " Solo"
                    : _currentState.State == GameState.Playing
                        ? _currentState.State + " Solo"
                        : _currentState.State.ToString();

            var userCount = _currentState.PlayerCount > -1
                ? $"UC: {_currentState.PlayerCount} (Obs: {_currentState.ObserverCount})"
                : null;

            return string.IsNullOrWhiteSpace(userCount) ? activity : $"{activity} | {userCount}";
        }

        private void ClearGameplayFields()
        {
            _currentState.UpdatePlayerCount(-1);
            _currentState.UpdateObserverCount(-1);
            _currentState.UpdatePlayerName(string.Empty);
            _currentState.UpdatePlayerLevel("0");
            _currentState.UpdatePlayerRebirth("0");
        }

        private string BuildDetails()
        {
            var showCharacterData = _currentState.State == GameState.Playing ||
                                    _currentState.State == GameState.PlayingGroup;

            var fields = new List<string>();
            if (showCharacterData && !string.IsNullOrEmpty(_currentState.PlayersName) && _settings.DisplayCharacterName)
                fields.Add(_currentState.PlayersName);
            if (showCharacterData && _currentState.PlayerLevel != "0")
                fields.Add($"Lvl: {_currentState.PlayerLevel}");
            if (showCharacterData && _currentState.PlayerRebirth != "0")
                fields.Add($"RB: {_currentState.PlayerRebirth}");

            return string.Join("\n", fields);
        }
    }
}
