using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;

namespace Broadleaf.ServiceProcess
{
    /// <summary>
    /// 
    /// </summary>
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        /// <summary>
        /// 
        /// </summary>
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}