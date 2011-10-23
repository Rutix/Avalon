using System;
using System.Windows.Input;

namespace Avalon.Common.ViewModel
{
    public class ModuleViewModel : ViewModelBase
    {
        #region Fields

        private Command _closeCommand;

        #endregion

        #region Constructor

        protected ModuleViewModel()
        {
        }

        #endregion

        #region CloseCommand

        /// <summary>
        /// Returns the command that, when invoked, attempts
        /// to remove this workspace from the user interface.
        /// </summary>
        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new Command(OnRequestClose);
                }
                return _closeCommand;
            }
        }

        #endregion

        #region RequestClose [event]

        /// <summary>
        /// Raised when this workspace should be removed from the UI.
        /// </summary>
        public event EventHandler RequestClose;

        private void OnRequestClose()
        {
            EventHandler handler = this.RequestClose;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}
