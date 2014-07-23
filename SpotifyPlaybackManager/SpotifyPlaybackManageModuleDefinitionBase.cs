using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using SpotifyPlaybackManager.Views;

namespace SpotifyPlaybackManager
{
    [ModuleExport(typeof (SpotifyPlaybackManageModuleDefinitionBase))]
    public class SpotifyPlaybackManageModuleDefinitionBase : IModule
    {
        [Import] private KeyBindingsView _keyBindingsView;

        public void Initialize()
        {
            var regionManager = (IRegionManager) ServiceLocator.Current.GetInstance(typeof (IRegionManager));

            regionManager.Regions["Region1"].Add(_keyBindingsView);
        }
    }
}