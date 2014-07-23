using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Input;
using SpotifyPlaybackManager.Interfaces;
using SpotifyPlaybackManager.Models;

namespace SpotifyPlaybackManager.ViewModels
{
    [Export]
    public class KeyBindingsViewModel
    {
        private IKeyHandler _keyHandler;
        private KeyCapture _keyCapture;
        public PlaybackHotKeyBindings ItsPlaybackHotKeyBindings { get; private set; }
        private const int ALPHA_BEGIN = 65;
        private const int ALPHA_END = 90;
        private readonly KeyConverter _keyConverter = new KeyConverter();

        public IList<Key> ItsHotkeySelectionList { get; set; }

        public KeyBindingsViewModel()
        {
            Initialize();
            GenerateHotkeySelectionList();
        }

        private void Initialize()
        {
            ItsPlaybackHotKeyBindings = new PlaybackHotKeyBindings();
            _keyHandler = new SpotifyKeyHandler {ItsPlaybackHotKeyBindings = ItsPlaybackHotKeyBindings};
            _keyCapture = new KeyCapture(_keyHandler);
            _keyCapture.HookKeys();
        }

        private void GenerateHotkeySelectionList()
        {
            ItsHotkeySelectionList = new List<Key>();
            for (var i = ALPHA_BEGIN; i <= ALPHA_END; i++)
            {
                var curKey = (Key) _keyConverter.ConvertFromString(((char) i).ToString());
                ItsHotkeySelectionList.Add(curKey);
            }
            for (var i = 0; i < 9; i++)
            {
                ItsHotkeySelectionList.Add((Key) _keyConverter.ConvertFromString(string.Format("NumPad{0}", i)));
            }
        }
    }
}