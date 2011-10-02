using System.Windows.Controls;

namespace ModuleTracking
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
