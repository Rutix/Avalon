using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using ModuleTracking;

namespace Avalon
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Variables

        private IModule _selectedModule; 
        
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
                    RaisePropertyChanged("SelectedModule");
                    RaisePropertyChanged("UserInterface");
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

        #region Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        /// <param name="modules">The modules.</param>
        public MainWindowViewModel(IEnumerable<IModule> modules)
        {
            Modules = modules.OrderBy(m => m.Name).ToList();
            if (Modules.Count > 0)
            {
                SelectedModule = Modules[0];
            }

        }

        /// <summary>
        /// Raises the changed property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        } 
        #endregion

        #region Events

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged; 
        
        #endregion
    }
}
