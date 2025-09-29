using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Windows.Forms;

namespace WinSFNETMENU_DAT
{
    public partial class Form1 :Form
    {
        public Form1()
        {
            InitializeComponent();
            this.propertyGrid1.SelectedObject = _sfNetMenuAddOnInfoEx;
        }
        SfNetMenuAddOnInfoEx _sfNetMenuAddOnInfoEx = new SfNetMenuAddOnInfoEx();

        private void button1_Click(object sender, EventArgs e)
        {
            SfNetMenuAddOnInfo sfNetMenuAddOnInfo = Broadleaf.Application.Common.UserSettingController.DecryptionDeserializeUserSetting<Broadleaf.Windows.Forms.SfNetMenuAddOnInfo>(Application.StartupPath + "\\MenuSettings\\AppSettingData\\SFNETMENU_Config.dat", new string[] { "SFNETMENU", "Addon", "Key" });

            this.propertyGrid1.SelectedObject = SfNetMenuAddOnInfoCopyTo(sfNetMenuAddOnInfo);
        }

        private SfNetMenuAddOnInfoEx SfNetMenuAddOnInfoCopyTo(SfNetMenuAddOnInfo sfNetMenuAddOnInfo)
        {
            SfNetMenuAddOnInfoEx sfNetMenuAddOnInfoEx = new SfNetMenuAddOnInfoEx();
            try
            {
                sfNetMenuAddOnInfoEx.EmployeeLogin = sfNetMenuAddOnInfo.EmployeeLogin.ToArray();
            }
            catch( Exception )
            {
            }

            try
            {
                sfNetMenuAddOnInfoEx.EmployeeLoginError = sfNetMenuAddOnInfo.EmployeeLoginError.ToArray();
            }
            catch( Exception )
            {
            }

            try
            {

                sfNetMenuAddOnInfoEx.EmployeeLogOut = sfNetMenuAddOnInfo.EmployeeLogOut.ToArray();
            }
            catch( Exception )
            {
            }
            try
            {
                sfNetMenuAddOnInfoEx.HelpOpening = sfNetMenuAddOnInfo.HelpOpening.ToArray();
            }
            catch( Exception )
            {
            }
            try
            {
                sfNetMenuAddOnInfoEx.InformationOpening = sfNetMenuAddOnInfo.InformationOpening.ToArray();
            }
            catch( Exception )
            {
            }
            try
            {
                sfNetMenuAddOnInfoEx.MenuEnding = sfNetMenuAddOnInfo.MenuEnding.ToArray();
            }
            catch( Exception )
            {
            }
            try
            {
                sfNetMenuAddOnInfoEx.MenuOpening = sfNetMenuAddOnInfo.MenuOpening.ToArray();
            }
            catch( Exception )
            {
            }
            try
            {
                sfNetMenuAddOnInfoEx.Sfnetmenu2Opening = sfNetMenuAddOnInfo.Sfnetmenu2Opening.ToArray();
            }
            catch( Exception )
            {
            }
            try
            {
                sfNetMenuAddOnInfoEx.SettingOpening = sfNetMenuAddOnInfo.SettingOpening.ToArray();
            }
            catch( Exception )
            {
            }
            try
            {
                sfNetMenuAddOnInfoEx.RemoteMaintenanceOpening = sfNetMenuAddOnInfo.RemoteMaintenanceOpening.ToArray();
            }
            catch( Exception )
            {
            }
            return sfNetMenuAddOnInfoEx;
        }

        private SfNetMenuAddOnInfo SfNetMenuAddOnInfoExCopyTo(SfNetMenuAddOnInfoEx sfNetMenuAddOnInfoEx)
        {
            SfNetMenuAddOnInfo sfNetMenuAddOnInfo = new SfNetMenuAddOnInfo();
            try
            {
                sfNetMenuAddOnInfo.EmployeeLogin.AddRange(sfNetMenuAddOnInfoEx.EmployeeLogin);
            }
            catch( Exception )
            {
            }
            try
            {
                sfNetMenuAddOnInfo.EmployeeLoginError.AddRange(sfNetMenuAddOnInfoEx.EmployeeLoginError);
            }
            catch( Exception )
            {
            }
            try
            {
                sfNetMenuAddOnInfo.EmployeeLogOut.AddRange(sfNetMenuAddOnInfoEx.EmployeeLogOut);
            }
            catch( Exception )
            {
            }
            try
            {
                sfNetMenuAddOnInfo.HelpOpening.AddRange(sfNetMenuAddOnInfoEx.HelpOpening);
            }
            catch( Exception )
            {
            }
            try
            {
                sfNetMenuAddOnInfo.InformationOpening.AddRange(sfNetMenuAddOnInfoEx.InformationOpening);
            }
            catch( Exception )
            {
            }
            try
            {
                sfNetMenuAddOnInfo.MenuEnding.AddRange(sfNetMenuAddOnInfoEx.MenuEnding);
            }
            catch( Exception )
            {
            }
            try
            {
                sfNetMenuAddOnInfo.MenuOpening.AddRange(sfNetMenuAddOnInfoEx.MenuOpening);
            }
            catch( Exception )
            {
            }
            try
            {
                sfNetMenuAddOnInfo.Sfnetmenu2Opening.AddRange(sfNetMenuAddOnInfoEx.Sfnetmenu2Opening);
            }
            catch( Exception )
            {
            }


            try
            {
                sfNetMenuAddOnInfo.SettingOpening.AddRange(sfNetMenuAddOnInfoEx.SettingOpening);
            }
            catch( Exception )
            {
            }
            try
            {
                sfNetMenuAddOnInfo.RemoteMaintenanceOpening.AddRange(sfNetMenuAddOnInfoEx.RemoteMaintenanceOpening);
            }
            catch( Exception )
            {
            }

            return sfNetMenuAddOnInfo;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SfNetMenuAddOnInfo sfNetMenuAddOnInfo = SfNetMenuAddOnInfoExCopyTo((SfNetMenuAddOnInfoEx)this.propertyGrid1.SelectedObject);
            Broadleaf.Application.Common.UserSettingController.EncryptionSerializeUserSetting(sfNetMenuAddOnInfo, Application.StartupPath + "\\MenuSettings\\AppSettingData\\SFNETMENU_Config.dat", new string[] { "SFNETMENU", "Addon", "Key" });
        }

        private void propertyGrid1_SelectedObjectsChanged(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}