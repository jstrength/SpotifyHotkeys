using System.Windows.Forms;

namespace SpotifyPlaybackManager.Interfaces
{
    public interface IKeyHandler
    {
        IPlaybackHandler PlaybackHandler { set; }

        void HandleKeyUp(Keys key);
        void HandleKeyDown(Keys key);
    }
}
