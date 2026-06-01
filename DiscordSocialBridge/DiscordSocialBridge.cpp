#include <cstdint>

#include "cdiscord.h"

namespace
{
    Discord_Client g_client{};
    bool g_initialized = false;
    bool g_connected = false;
    uint64_t g_applicationId = 0;

    Discord_String MakeString(const char* value)
    {
        Discord_String s{};
        if (value != nullptr && *value != '\0')
        {
            s.ptr = reinterpret_cast<uint8_t*>(const_cast<char*>(value));
            s.size = 0;
            while (value[s.size] != '\0')
                ++s.size;
        }
        return s;
    }

    void SetString(Discord_String* target, const char* value)
    {
        if (value == nullptr || *value == '\0')
        {
            *target = Discord_String{};
            return;
        }

        *target = MakeString(value);
    }
}

extern "C" __declspec(dllexport) bool DiscordBridge_Initialize(uint64_t applicationId)
{
    if (!g_initialized)
    {
        Discord_Client_Init(&g_client);
        g_initialized = true;
    }

    g_applicationId = applicationId;
    Discord_Client_SetApplicationId(&g_client, applicationId);
    Discord_Client_Connect(&g_client);
    g_connected = true;
    return true;
}

extern "C" __declspec(dllexport) void DiscordBridge_Shutdown()
{
    if (!g_initialized)
        return;

    if (g_connected)
    {
        Discord_Client_Disconnect(&g_client);
        g_connected = false;
    }

    Discord_Client_Drop(&g_client);
    g_initialized = false;
}

extern "C" __declspec(dllexport) void DiscordBridge_RunCallbacks()
{
    if (g_initialized)
        Discord_RunCallbacks();
}

extern "C" __declspec(dllexport) bool DiscordBridge_UpdatePresence(
    const char* details,
    const char* state,
    const char* largeImageKey,
    const char* largeImageText,
    const char* smallImageKey,
    const char* smallImageText,
    const char* buttonLabel,
    const char* buttonUrl,
    const char* secondButtonLabel,
    const char* secondButtonUrl)
{
    if (!g_initialized)
        return false;

    Discord_Activity activity{};
    Discord_Activity_Init(&activity);
    Discord_Activity_SetType(&activity, Discord_ActivityTypes_Playing);
    Discord_Activity_SetApplicationId(&activity, &g_applicationId);

    Discord_String stringValue{};

    stringValue = MakeString(details);
    Discord_Activity_SetDetails(&activity, stringValue.ptr ? &stringValue : nullptr);

    stringValue = MakeString(state);
    Discord_Activity_SetState(&activity, stringValue.ptr ? &stringValue : nullptr);

    Discord_ActivityAssets assets{};
    Discord_ActivityAssets_Init(&assets);

    bool hasAssets = false;
    stringValue = MakeString(largeImageKey);
    if (stringValue.ptr)
    {
        Discord_ActivityAssets_SetLargeImage(&assets, &stringValue);
        hasAssets = true;
    }
    stringValue = MakeString(largeImageText);
    if (stringValue.ptr)
    {
        Discord_ActivityAssets_SetLargeText(&assets, &stringValue);
        hasAssets = true;
    }
    stringValue = MakeString(smallImageKey);
    if (stringValue.ptr)
    {
        Discord_ActivityAssets_SetSmallImage(&assets, &stringValue);
        hasAssets = true;
    }
    stringValue = MakeString(smallImageText);
    if (stringValue.ptr)
    {
        Discord_ActivityAssets_SetSmallText(&assets, &stringValue);
        hasAssets = true;
    }

    if (hasAssets)
        Discord_Activity_SetAssets(&activity, &assets);

    if (buttonLabel != nullptr && *buttonLabel != '\0' && buttonUrl != nullptr && *buttonUrl != '\0')
    {
        Discord_ActivityButton button{};
        Discord_ActivityButton_Init(&button);
        stringValue = MakeString(buttonLabel);
        Discord_ActivityButton_SetLabel(&button, stringValue);
        stringValue = MakeString(buttonUrl);
        Discord_ActivityButton_SetUrl(&button, stringValue);
        Discord_Activity_AddButton(&activity, &button);
        Discord_ActivityButton_Drop(&button);
    }

    if (secondButtonLabel != nullptr && *secondButtonLabel != '\0' && secondButtonUrl != nullptr && *secondButtonUrl != '\0')
    {
        Discord_ActivityButton button{};
        Discord_ActivityButton_Init(&button);
        stringValue = MakeString(secondButtonLabel);
        Discord_ActivityButton_SetLabel(&button, stringValue);
        stringValue = MakeString(secondButtonUrl);
        Discord_ActivityButton_SetUrl(&button, stringValue);
        Discord_Activity_AddButton(&activity, &button);
        Discord_ActivityButton_Drop(&button);
    }

    Discord_Client_UpdateRichPresence(
        &g_client,
        &activity,
        [](Discord_ClientResult* result, void*) { Discord_ClientResult_Drop(result); },
        nullptr,
        nullptr);

    Discord_Activity_Drop(&activity);
    if (hasAssets)
        Discord_ActivityAssets_Drop(&assets);

    return true;
}
