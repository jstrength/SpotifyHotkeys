using System.ComponentModel.Composition.Hosting;
using System.Windows;
using Microsoft.Practices.Prism.MefExtensions;

namespace SpotifyPlaybackManager
{
    public class ApplicationBootstrapper : MefBootstrapper
    {
        private readonly AggregateCatalog _catalogs;

        public ApplicationBootstrapper(AggregateCatalog catalogs)
        {
            _catalogs = catalogs;
        }

        protected override DependencyObject CreateShell()
        {
            return Container.GetExportedValue<Shell>();
        }

        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();

            AggregateCatalog.Catalogs.Add(_catalogs);
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Shell) Shell;
            Application.Current.MainWindow.Show();
        }
    }
}