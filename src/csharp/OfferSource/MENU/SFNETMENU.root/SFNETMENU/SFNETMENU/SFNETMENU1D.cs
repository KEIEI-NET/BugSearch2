using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// TOP���j���[�A�h�I�����N���X
    /// </summary>
    public class SfNetMenuAddOnInfo
    {
        public SfNetMenuAddOnInfo()
        {
        }
        /// <summary>
        /// �A�h�I�����Ă΂��^�C�~���O
        /// </summary>
        public enum AddonRunType
        {
            MenuOpening = 0,
            MenuEnding = 1,
            EmployeeLogin = 2,
            EmployeeLogOut = 3,
            EmployeeLoginError = 4,
            InformationOpening = 5,
            HelpOpening = 6,
            Sfnetmenu2Opening = 7,
            SettingOpening = 8,
            RemoteMaintenanceOpening =9
        }

        #region �v���C�x�[�g�����o
        /// <summary>TOP���j���[�N����</summary>
        private List<string> _menuOpening = new List<string>();
        /// <summary>TOP���j���[�I����</summary>
        private List<string> _menuEnding = new List<string>();
        /// <summary>�]�ƈ����O�C��������</summary>
        private List<string> _employeeLogin = new List<string>();
        /// <summary>�]�ƈ����O�A�E�g������</summary>
        private List<string> _employeeLogOut = new List<string>();
        /// <summary>�]�ƈ����O�C�����s��</summary>
        private List<string> _employeeLoginError = new List<string>();
        /// <summary>�C���t�H���[�V�����N����</summary>
        private List<string> _informationOpening = new List<string>();
        /// <summary>�w���v�N����</summary>
        private List<string> _helpOpening = new List<string>();
        /// <summary>�Ɩ����j���[�N����</summary>
        private List<string> _sfnetmenu2Opening = new List<string>();
        /// <summary>�ݒ�N����</summary>
        private List<string> _settingOpening = new List<string>();
        /// <summary>�����[�g�����e�i���X�N����</summary>
        private List<string> _remoteMaintenanceOpening = new List<string>();
       

        
        #endregion

        #region �v���p�e�B
        /// <summary>TOP���j���[�N����</summary>
        public List<string> MenuOpening
        {
            get { return _menuOpening; }
            set { _menuOpening = value; }
        }
        /// <summary>TOP���j���[�I����</summary>
        public List<string> MenuEnding
        {
            get { return _menuEnding; }
            set { _menuEnding = value; }
        }
        /// <summary>�]�ƈ����O�C��������</summary>
        public List<string> EmployeeLogin
        {
            get { return _employeeLogin; }
            set { _employeeLogin = value; }
        }
        /// <summary>�]�ƈ����O�A�E�g������</summary>
        public List<string> EmployeeLogOut
        {
            get { return _employeeLogOut; }
            set { _employeeLogOut = value; }
        }
        /// <summary>�]�ƈ����O�C�����s��</summary>
        public List<string> EmployeeLoginError
        {
            get { return _employeeLoginError; }
            set { _employeeLoginError = value; }
        }
        /// <summary>�C���t�H���[�V�����N����</summary>
        public List<string> InformationOpening
        {
            get { return _informationOpening; }
            set { _informationOpening = value; }
        }
        /// <summary>�w���v�N����</summary>
        public List<string> HelpOpening
        {
            get { return _helpOpening; }
            set { _helpOpening = value; }
        }
        /// <summary>�Ɩ����j���[�N����</summary>
        public List<string> Sfnetmenu2Opening
        {
            get { return _sfnetmenu2Opening; }
            set { _sfnetmenu2Opening = value; }
        }
        /// <summary>�ݒ�N����</summary>
        public List<string> SettingOpening
        {
            get { return _settingOpening; }
            set { _settingOpening = value; }
        }
        /// <summary>�����[�g�����e�i���X�N����</summary>
        public List<string> RemoteMaintenanceOpening
        {
            get { return _remoteMaintenanceOpening; }
            set { _remoteMaintenanceOpening = value; }
        }
        #endregion

        /// <summary>
        /// �A�h�I�����O���[�v�ʂɎ擾
        /// </summary>
        /// <param rKeyName="addonRunType"></param>
        /// <returns></returns>
        public List<string> GetAddonList(AddonRunType addonRunType)
        {
            List<string> resultList = null;

            switch( addonRunType )
            {
                case AddonRunType.MenuOpening:
                    {
                        resultList = _menuOpening;
                        break;
                    }
                case AddonRunType.MenuEnding:
                    {
                        resultList = _menuEnding;
                        break;
                    }
                case AddonRunType.EmployeeLogin:
                    {
                        resultList = _employeeLogin;
                        break;
                    }
                case AddonRunType.EmployeeLogOut:
                    {
                        resultList = _employeeLogOut;
                        break;
                    }
                case AddonRunType.EmployeeLoginError:
                    {
                        resultList = _employeeLoginError;
                        break;
                    }
                case AddonRunType.InformationOpening:
                    {
                        resultList = _informationOpening;
                        break;
                    }
                case AddonRunType.HelpOpening:
                    {
                        resultList = _helpOpening;
                        break;
                    }
                case AddonRunType.Sfnetmenu2Opening:
                    {
                        resultList = _sfnetmenu2Opening;
                        break;
                    }
                case AddonRunType.SettingOpening:
                    {
                        resultList = _settingOpening;
                        break;
                    }
                case AddonRunType.RemoteMaintenanceOpening:
                    {
                        resultList = _remoteMaintenanceOpening;
                        break;
                    }
            }

            return resultList;
        }

    }
}
