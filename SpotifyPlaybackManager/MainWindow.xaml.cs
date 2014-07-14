using System.Windows;
using SpotifyPlaybackManager.Models;

namespace SpotifyPlaybackManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var playBackHandler = new SpotifyPlaybackHandler();
            var keyHandler = new SpotifyKeyHandler {PlaybackHandler = playBackHandler};
            var interceptKeys = new KeyCapture(keyHandler);
        }
    }
}
