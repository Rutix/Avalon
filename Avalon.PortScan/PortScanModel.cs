using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using Avalon.Common;

namespace AvalonPortScan
{
    public class PortScanModel : INotifyPropertyChanged
    {

        #region Fields

        private string _hostAddress;
        private string _startPort;
        private string _endPort;

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PortScanModel"/> class.
        /// </summary>
        public PortScanModel()
        {
            HostAddress = "127.0.0.1";
            StartPort = "0";
            EndPort = "100";
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the host adres.
        /// </summary>
        /// <value>
        /// The host adres.
        /// </value>
        public string HostAddress
        {
            get { return _hostAddress; }
            set
            {
                if (_hostAddress == value) return;
                _hostAddress = value;
                OnPropertyChanged(PropertyOf<PortScanModel>.Resolve(x => x.HostAddress));
            }
        }

        /// <summary>
        /// Gets or sets the start port.
        /// </summary>
        /// <value>
        /// The start port.
        /// </value>
        public string StartPort
        {
            get { return _startPort; }
            set
            {
                if (_startPort == value) return;
                _startPort = value;
                OnPropertyChanged(PropertyOf<PortScanModel>.Resolve(x => x.StartPort));
            }
        }

        /// <summary>
        /// Gets or sets the end port.
        /// </summary>
        /// <value>
        /// The end port.
        /// </value>
        public string EndPort
        {
            get { return _endPort; }
            set
            {
                if (_endPort == value) return;
                _endPort = value;
                OnPropertyChanged(PropertyOf<PortScanModel>.Resolve(x => x.EndPort));
            }
        }

        #endregion

        #region private methods

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion


    }
}
