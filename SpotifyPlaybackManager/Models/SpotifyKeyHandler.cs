using System.Windows.Forms;
using SpotifyPlaybackManager.Interfaces;

namespace SpotifyPlaybackManager.Models
{
    public class SpotifyKeyHandler : IKeyHandler
    {
        public IPlaybackHandler PlaybackHandler { set; private get; }
        private bool _ctrlDown = false;

        public void HandleKeyUp(Keys key)
        {
            switch (key)
            {
                case Keys.ControlKey:
                case Keys.LControlKey:
                case Keys.RControlKey:
                    _ctrlDown = false;
                    break;
            }
        }

        public void HandleKeyDown(Keys key)
        {
            switch (key)
            {
                case Keys.ControlKey:
                case Keys.LControlKey:
                case Keys.RControlKey:
                    _ctrlDown = true;
                    break;
                case Keys.NumPad4:
                    if(_ctrlDown) PlaybackHandler.PrevTrack();
                    break;
                case Keys.NumPad5:
                    if(_ctrlDown) PlaybackHandler.PlayPauseToggle();
                    break;
                case Keys.NumPad6:
                    if(_ctrlDown) PlaybackHandler.NextTrack();
                    break;
                case Keys.NumPad8:
                    if(_ctrlDown) PlaybackHandler.VolumeUp();
                    break;
                case Keys.NumPad2:
                    if(_ctrlDown) PlaybackHandler.VolumeDown();
                    break;
                case Keys.NumPad0:
                    if(_ctrlDown) PlaybackHandler.Mute();
                    break;
                case Keys.NumPad7:
                    if(_ctrlDown) PlaybackHandler.Shuffle();
                    break;
                case Keys.NumPad9:
                    if(_ctrlDown) PlaybackHandler.Replay();
                    break;
            }
        }
    }
}
