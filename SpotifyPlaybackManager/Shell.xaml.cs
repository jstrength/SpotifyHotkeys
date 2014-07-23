using System.ComponentModel.Composition;
using System.Windows;

namespace SpotifyPlaybackManager
{
    [Export]
    public partial class Shell : Window
    {
        public Shell()
        {
            InitializeComponent();
        }
    }
}