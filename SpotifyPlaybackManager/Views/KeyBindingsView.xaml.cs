using System.ComponentModel.Composition;
using System.Windows.Input;
using SpotifyPlaybackManager.ViewModels;

namespace SpotifyPlaybackManager.Views
{
    [Export]
    public partial class KeyBindingsView
    {
        [Import]
        private KeyBindingsViewModel ViewModel
        {
            set { DataContext = value; }
        }

        public KeyBindingsView()
        {
            InitializeComponent();
        }
    }
}