using System;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Windows;
using Avalon.Common;
using Avalon.Common.ViewModel;

namespace Avalon
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// The startup of the application.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.StartupEventArgs"/> instance containing the event data.</param>
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = new MainWindow();

            var catalog = new AggregateCatalog(new DirectoryCatalog("."), new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            var container = new CompositionContainer(catalog);
            var modules = container.GetExportedValues<IModule>();

            var viewModel = new MainWindowViewModel(modules);

            //close stuff
            EventHandler handler = null;
            handler = delegate
                          {
                              viewModel.RequestClose -= handler;
                              mainWindow.Close();

                          };
            viewModel.RequestClose += handler;

            mainWindow.DataContext = viewModel;
            mainWindow.Show();
        }
    }
}
