using System.Windows.Input;
using SpotifyPlaybackManager.Interfaces;

namespace SpotifyPlaybackManager.Models
{
    public class SpotifyKeyHandler : IKeyHandler
    {
        public IPlaybackHandler ItsPlaybackHandler { set; get; }
        public PlaybackHotKeyBindings ItsPlaybackHotKeyBindings { set; get; }

        private bool _ctrlDown;
        private bool _altDown;
        private bool _shiftDown;

        public SpotifyKeyHandler()
        {
            ItsPlaybackHandler = new SpotifyPlaybackHandler();
        }

        public void HandleKeyUp(Key key)
        {
            switch (key)
            {
                case Key.LeftCtrl:
                case Key.RightCtrl:
                    _ctrlDown = false;
                    break;
                case Key.LeftAlt:
                case Key.RightAlt:
                    _altDown = false;
                    return;
                case Key.LeftShift:
                case Key.RightShift:
                    _shiftDown = false;
                    return;
            }
        }

        public void HandleKeyDown(Key key)
        {
            switch (key)
            {
                case Key.LeftCtrl:
                case Key.RightCtrl:
                    _ctrlDown = true;
                    return;
                case Key.LeftAlt:
                case Key.RightAlt:
                    _altDown = true;
                    return;
                case Key.LeftShift:
                case Key.RightShift:
                    _shiftDown = true;
                    return;
            }
            if (ItsPlaybackHotKeyBindings.Shift && !_shiftDown ||
                ItsPlaybackHotKeyBindings.Alt && !_altDown ||
                ItsPlaybackHotKeyBindings.Ctrl && !_ctrlDown)
            {
                return;
            }

            if (key.Equals(ItsPlaybackHotKeyBindings.PrevTrack))
            {
                ItsPlaybackHandler.PrevTrack();
            }
            else if (key.Equals(ItsPlaybackHotKeyBindings.NextTrack))
            {
                ItsPlaybackHandler.NextTrack();
            }
            else if (key.Equals(ItsPlaybackHotKeyBindings.PlayPause))
            {
                ItsPlaybackHandler.PlayPauseToggle();
            }
            else if (key.Equals(ItsPlaybackHotKeyBindings.Mute))
            {
                ItsPlaybackHandler.Mute();
            }
            else if (key.Equals(ItsPlaybackHotKeyBindings.Shuffle))
            {
                ItsPlaybackHandler.Shuffle();
            }
            else if (key.Equals(ItsPlaybackHotKeyBindings.Replay))
            {
                ItsPlaybackHandler.Replay();
            }
            else if (key.Equals(ItsPlaybackHotKeyBindings.VolumeDown))
            {
                ItsPlaybackHandler.VolumeDown();
            }
            else if (key.Equals(ItsPlaybackHotKeyBindings.VolumeUp))
            {
                ItsPlaybackHandler.VolumeUp();
            }
        }
    }
}