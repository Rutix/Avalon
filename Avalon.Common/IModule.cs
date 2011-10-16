using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Avalon.Common
{
    /// <summary>
    /// The interface for modules.
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; }

        /// <summary>
        /// Gets the user interface.
        /// </summary>
        UserControl UserInterface { get; }
    }
}
