using System;
using System.Runtime.InteropServices;

namespace Mir.DiscordExtension
{
    internal static class DiscordSocialBridge
    {
        private const string LibraryName = "DiscordSocialBridge.dll";

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool DiscordBridge_Initialize(ulong applicationId);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DiscordBridge_Shutdown();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DiscordBridge_RunCallbacks();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool DiscordBridge_UpdatePresence(
            string details,
            string state,
            string largeImageKey,
            string largeImageText,
            string smallImageKey,
            string smallImageText,
            string buttonLabel,
            string buttonUrl,
            string secondButtonLabel,
            string secondButtonUrl);
    }
}
