using System.ComponentModel.Composition.Hosting;
using System.Windows;

namespace SpotifyPlaybackManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var catalogs = new AggregateCatalog();

	    catalogs.Catalogs.Add(new AssemblyCatalog(typeof(SpotifyPlaybackManageModuleDefinitionBase).Assembly));

	    new ApplicationBootstrapper(catalogs).Run();
        }


    }
}
