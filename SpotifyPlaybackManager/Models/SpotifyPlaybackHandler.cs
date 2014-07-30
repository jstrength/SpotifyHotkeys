using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SpotifyPlaybackManager.Enums;
using SpotifyPlaybackManager.Interfaces;
using SpotifyPlaybackManager.Properties;

namespace SpotifyPlaybackManager.Models
{
    public class SpotifyPlaybackHandler : IPlaybackHandler
    {
        private const string SPOTIFY_CLASS_NAME = "SpotifyMainWindow";

        private static IntPtr _spotifyHwnd;

        private enum AppcommandVkCodes
        {
            NEXT_TRACK = 0xB0000,
            PREV_TRACK = 0xC0000,
            PLAY_PAUSE = 0xE0000,
            MUTE_VOLUME = 0x80000,
        }

        public SpotifyPlaybackHandler()
        {
            Initialize();
        }

        private void Initialize()
        {
            _spotifyHwnd = FindWindow(SPOTIFY_CLASS_NAME, null);
            if (_spotifyHwnd == IntPtr.Zero)
            {
                Console.WriteLine(Resources.FAILED_FIND_WINDOW);
            }
        }

        public void PlayPauseToggle()
        {
            SendMessage(_spotifyHwnd, (uint) WmCodes.WM_APPCOMMAND, IntPtr.Zero, (IntPtr) AppcommandVkCodes.PLAY_PAUSE);
        }

        public void NextTrack()
        {
            SendMessage(_spotifyHwnd, (uint) WmCodes.WM_APPCOMMAND, IntPtr.Zero, (IntPtr) AppcommandVkCodes.NEXT_TRACK);
        }

        public void PrevTrack()
        {
            SendMessage(_spotifyHwnd, (uint) WmCodes.WM_APPCOMMAND, IntPtr.Zero, (IntPtr) AppcommandVkCodes.PREV_TRACK);
        }

        public void Mute()
        {
            SendMessage(_spotifyHwnd, (uint) WmCodes.WM_APPCOMMAND, IntPtr.Zero, (IntPtr) AppcommandVkCodes.MUTE_VOLUME);
        }

        public void VolumeDown()
        {
            SendMessageHelper.SendControlKey(_spotifyHwnd, (IntPtr) Keys.Down);
        }

        public void VolumeUp()
        {
            SendMessageHelper.SendControlKey(_spotifyHwnd, (IntPtr) Keys.Up);
        }

        public void Shuffle()
        {
            SendMessageHelper.SendControlKey(_spotifyHwnd, (IntPtr) Keys.S);
        }

        public void Replay()
        {
            SendMessageHelper.SendControlKey(_spotifyHwnd, (IntPtr) Keys.R);
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
    }
}