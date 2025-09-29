using System;
using System.Collections.Generic;
using System.Text;

namespace WinSFNETMENU_DAT
{
    /// <summary>
    /// TOP���j���[�A�h�I�����N���X
    /// </summary>
    public class SfNetMenuAddOnInfoEx
    {
        public SfNetMenuAddOnInfoEx()
        {
        }

        #region �v���C�x�[�g�����o
        /// <summary>TOP���j���[�N����</summary>
        private string[] _menuOpening;
        /// <summary>TOP���j���[�I����</summary>
        private string[] _menuEnding;
        /// <summary>�]�ƈ����O�C��������</summary>
        private string[] _employeeLogin;
        /// <summary>�]�ƈ����O�A�E�g������</summary>
        private string[] _employeeLogOut;
        /// <summary>�]�ƈ����O�C�����s��</summary>
        private string[] _employeeLoginError;
        /// <summary>�C���t�H���[�V�����N����</summary>
        private string[] _informationOpening;
        /// <summary>�w���v�N����</summary>
        private string[] _helpOpening;
        /// <summary>�Ɩ����j���[�N����</summary>
        private string[] _sfnetmenu2Opening;
        /// <summary>�ݒ�N����</summary>
        private string[] _settingOpening;
        /// <summary>�����[�g�����e�i���X�N����</summary>
        private string[] _remoteMaintenanceOpening;


        
        #endregion

        #region �v���p�e�B
        /// <summary>TOP���j���[�N����</summary>
        public string[] MenuOpening
        {
            get { return _menuOpening; }
            set { _menuOpening = value; }
        }
        /// <summary>TOP���j���[�I����</summary>
        public string[] MenuEnding
        {
            get { return _menuEnding; }
            set { _menuEnding = value; }
        }
        /// <summary>�]�ƈ����O�C��������</summary>
        public string[] EmployeeLogin
        {
            get { return _employeeLogin; }
            set { _employeeLogin = value; }
        }
        /// <summary>�]�ƈ����O�A�E�g������</summary>
        public string[] EmployeeLogOut
        {
            get { return _employeeLogOut; }
            set { _employeeLogOut = value; }
        }
        /// <summary>�]�ƈ����O�C�����s��</summary>
        public string[] EmployeeLoginError
        {
            get { return _employeeLoginError; }
            set { _employeeLoginError = value; }
        }
        /// <summary>�C���t�H���[�V�����N����</summary>
        public string[] InformationOpening
        {
            get { return _informationOpening; }
            set { _informationOpening = value; }
        }
        /// <summary>�w���v�N�N����</summary>
        public string[] HelpOpening
        {
            get { return _helpOpening; }
            set { _helpOpening = value; }
        }
        /// <summary>�Ɩ����j���[�N����</summary>
        public string[] Sfnetmenu2Opening
        {
            get { return _sfnetmenu2Opening; }
            set { _sfnetmenu2Opening = value; }
        }
        /// <summary>�ݒ�N����</summary>
        public string[] SettingOpening
        {
            get { return _settingOpening; }
            set { _settingOpening = value; }
        }
        /// <summary>�����[�g�����e�i���X�N����</summary>
        public string[] RemoteMaintenanceOpening
        {
            get { return _remoteMaintenanceOpening; }
            set { _remoteMaintenanceOpening = value; }
        }
        #endregion


    }
}
