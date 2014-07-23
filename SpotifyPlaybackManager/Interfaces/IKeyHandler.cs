using System.Windows.Input;
using SpotifyPlaybackManager.Models;

namespace SpotifyPlaybackManager.Interfaces
{
    public interface IKeyHandler
    {
        IPlaybackHandler ItsPlaybackHandler { set; }
        PlaybackHotKeyBindings ItsPlaybackHotKeyBindings { set; get; }

        void HandleKeyUp(Key key);
        void HandleKeyDown(Key key);
    }
}