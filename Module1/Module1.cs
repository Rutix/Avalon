using System.ComponentModel.Composition;
using System.Windows.Controls;
using Avalon;
using ModuleTracking;

namespace Module1
{
    [Export(typeof(IModule))]
    public class Module1 : IModule
    {
        public string Name
        {
            get { return "module 1"; }
        }

        public UserControl UserInterface
        {
            get { return new Module1View(); }
        }
    }
}
