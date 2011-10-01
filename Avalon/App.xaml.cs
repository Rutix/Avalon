using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

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

            var catalog = new AssemblyCatalog(this.GetType().Assembly);
            var container = new CompositionContainer(catalog);
            var modules = container.GetExportedValues<IModule>();

            mainWindow.Show();
        }
    }
}
