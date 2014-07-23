using System.ComponentModel.Composition;
using System.Windows.Input;
using SpotifyPlaybackManager.Interfaces;

namespace SpotifyPlaybackManager.Models
{
    public class SpotifyKeyHandler : IKeyHandler
    {
        public IPlaybackHandler ItsPlaybackHandler { set; get; }
        public PlaybackHotKeyBindings ItsPlaybackHotKeyBindings { set; get; }

        private bool _ctrlDown;

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
            }
            if (_ctrlDown == false) return;

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