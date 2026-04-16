using Library;
using MirDB;
using Server.DBModels;
using Server.Envir.Commands.Exceptions;
using Server.Models;
using System;
using System.Drawing;
using S = Library.Network.ServerPackets;

namespace Server.Envir.Commands.Command.Admin
{
    using System.Drawing;

    class ChangeNameColour : AbstractParameterizedCommand<IAdminCommand>
    {
        public override string VALUE => "NAMECOLOUR";
        public override int PARAMS_LENGTH => 2; // @NAMECOLOUR RED or @NAMECOLOUR RED PLAYERNAME

        public override void Action(PlayerObject player, string[] vals)
        {
            if (vals.Length < PARAMS_LENGTH)
                ThrowNewInvalidParametersException();

            PlayerObject playerOb;

            // If player name provided
            if (vals.Length >= 3)
            {
                playerOb = SEnvir.GetPlayerByCharacter(vals[2]);
                if (playerOb == null)
                    throw new UserCommandException($"Could not find player: {vals[2]}");
            }
            else
            {
                playerOb = player;
            }

            string input = vals[1].ToUpperInvariant();

            Color oldColour = playerOb.Character.CustomNameColour;

            // ✅ HANDLE CLEAR
            if (input == "CLEAR")
            {
                playerOb.Character.CustomNameColour = Color.Empty;
                return;
            }

            // Validate colour
            if (!IsValidColor(input))
                throw new UserCommandException($"Invalid colour: {vals[1]}");

            Color newColour = GetColor(input);

            if (oldColour != newColour)
            {
                playerOb.Character.CustomNameColour = newColour;
            }
        }

        private bool IsValidColor(string input)
        {
            try
            {
                ColorTranslator.FromHtml(input);
                return true;
            }
            catch
            {
                Color c = Color.FromName(input);
                return c.IsKnownColor || c.IsNamedColor;
            }
        }

        private Color GetColor(string input)
        {
            try
            {
                return ColorTranslator.FromHtml(input); // handles hex + names
            }
            catch
            {
                return Color.FromName(input);
            }
        }
    }
}
