using System;
using System.Collections.Generic;
using System.Windows.Input;
using SpotifyPlaybackManager.Interfaces;

namespace SpotifyPlaybackManager.Models
{
    public class SpotifyKeyHandler : IKeyHandler
    {
        public IPlaybackHandler ItsPlaybackHandler { set; get; }
        public PlaybackHotKeyBindings ItsPlaybackHotKeyBindings { set; get; }

        private readonly HashSet<Key> _keyMonitor;

        public SpotifyKeyHandler()
        {
            ItsPlaybackHandler = new SpotifyPlaybackHandler();
            _keyMonitor = new HashSet<Key>();
        }

        public void HandleKeyUp(Key key)
        {
            _keyMonitor.Remove(key);
        }

        public void HandleKeyDown(Key key)
        {
            //key already in
            if (!_keyMonitor.Add(key))
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
            else if (_keyMonitor.Contains(ItsPlaybackHotKeyBindings.PlayPause))
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