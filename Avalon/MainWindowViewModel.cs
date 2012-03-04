using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Avalon.Common;
using Avalon.Common.ViewModel;
using Avalon.Properties;

namespace Avalon
{
    /// <summary>
    /// The application's main window ViewModel.
    /// </summary>
    public class MainWindowViewModel : ModuleViewModel
    {
        #region Fields

        private IModule _selectedModule;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        /// <param name="modules">The modules.</param>
        public MainWindowViewModel(IEnumerable<IModule> modules)
        {
            base.DisplayName = Resources.MainWindowViewModel_DisplayName;

            Modules = modules.OrderBy(m => m.Name).ToList();
            if (Modules.Count > 0)
            {
                SelectedModule = Modules[0];
            }

        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets the modules.
        /// </summary>
        public List<IModule> Modules { get; private set; }

        /// <summary>
        /// Gets or sets the selected module.
        /// </summary>
        /// <value>
        /// The selected module.
        /// </value>
        public IModule SelectedModule
        {
            get { return _selectedModule; }
            set
            {
                if (value != _selectedModule)
                {
                    _selectedModule = value;
                    OnPropertyChanged(PropertyOf<MainWindowViewModel>.Resolve(x => x.SelectedModule));
                    OnPropertyChanged(PropertyOf<MainWindowViewModel>.Resolve(x => x.UserInterface));
                }
                _selectedModule = value;
            }
        }

        /// <summary>
        /// Gets the user interface.
        /// </summary>
        public UserControl UserInterface
        {
            get { return SelectedModule == null ? null : SelectedModule.UserInterface; }
        }
        
        #endregion
    }
}
