using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Avalon.Common;

namespace AvalonPortScan
{
    [Export(typeof(IModule))]
    class PortScan : IModule
    {
        public string Name
        {
            get { return "Port Scanner"; }
        }

        public UserControl UserInterface
        {
            get { return new PortScanView(); }
        }
    }
}
