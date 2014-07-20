using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.ViewModel;

namespace SpotifyPlaybackManager.ViewModels
{
    [Export]
    public class KeyBindingsViewModel : NotificationObject
    {
        public IList<char> ItsAlphaHotkeys
        {
            get { return _alphaHotkeys; }
            set 
            { 
                _alphaHotkeys = value;
                RaisePropertyChanged(() => ItsAlphaHotkeys);
            }
        }

        public char ItsPlayPauseHotkey { get; set; }

        private IList<char> _alphaHotkeys;

        public KeyBindingsViewModel()
	{
	    Initialize();
	}

	private void Initialize()
        {
	    _alphaHotkeys = new List<char>();

            for (var i = 97; i < 123; i++)
            {
		_alphaHotkeys.Add((char)i);
            }
        }
    }
}
