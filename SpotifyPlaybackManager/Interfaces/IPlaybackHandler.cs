namespace SpotifyPlaybackManager.Interfaces
{
    public interface IPlaybackHandler
    {
        void PlayPauseToggle();
        void NextTrack();
        void PrevTrack();
        void VolumeDown();
        void VolumeUp();
        void Shuffle();
        void Mute();
        void Replay();
    }
}
