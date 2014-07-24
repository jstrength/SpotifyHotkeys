using System.Windows.Input;
using SpotifyPlaybackManager.Properties;

namespace SpotifyPlaybackManager.Models
{
    public class PlaybackHotKeyBindings
    {
        public bool Shift
        {
            get { return Settings.Default.Shift; }
            set
            {
                Settings.Default.Shift = value;
                Settings.Default.Save();
            }
        }
        public bool Ctrl
        {
            get { return Settings.Default.Ctrl; }
            set
            {
                Settings.Default.Ctrl = value;
                Settings.Default.Save();
            }
        }
        public bool Alt
        {
            get { return Settings.Default.Alt; }
            set
            {
                Settings.Default.Alt = value;
                Settings.Default.Save();
            }
        }
        public Key PlayPause
        {
            get { return (Key) KeyConverter.ConvertFromString(Settings.Default.PlayPauseKey); }
            set
            {
                Settings.Default.PlayPauseKey = KeyConverter.ConvertToString(value);
                Settings.Default.Save();
            }
        }

        public Key NextTrack
        {
            get { return (Key) KeyConverter.ConvertFromString(Settings.Default.NextTrack); }
            set
            {
                Settings.Default.NextTrack = KeyConverter.ConvertToString(value);
                Settings.Default.Save();
            }
        }

        public Key PrevTrack
        {
            get { return (Key) KeyConverter.ConvertFromString(Settings.Default.PrevTrack); }
            set
            {
                Settings.Default.PrevTrack = KeyConverter.ConvertToString(value);
                Settings.Default.Save();
            }
        }

        public Key Shuffle
        {
            get { return (Key) KeyConverter.ConvertFromString(Settings.Default.Shuffle); }
            set
            {
                Settings.Default.Shuffle = KeyConverter.ConvertToString(value);
                Settings.Default.Save();
            }
        }

        public Key Replay
        {
            get { return (Key) KeyConverter.ConvertFromString(Settings.Default.Replay); }
            set
            {
                Settings.Default.Replay = KeyConverter.ConvertToString(value);
                Settings.Default.Save();
            }
        }

        public Key VolumeUp
        {
            get { return (Key) KeyConverter.ConvertFromString(Settings.Default.VolumeUp); }
            set
            {
                Settings.Default.VolumeUp = KeyConverter.ConvertToString(value);
                Settings.Default.Save();
            }
        }

        public Key VolumeDown
        {
            get { return (Key) KeyConverter.ConvertFromString(Settings.Default.VolumeDown); }
            set
            {
                Settings.Default.VolumeDown = KeyConverter.ConvertToString(value);
                Settings.Default.Save();
            }
        }

        public Key Mute
        {
            get { return (Key) KeyConverter.ConvertFromString(Settings.Default.Mute); }
            set
            {
                Settings.Default.Mute = KeyConverter.ConvertToString(value);
                Settings.Default.Save();
            }
        }


        private readonly KeyConverter KeyConverter = new KeyConverter();
    }
}