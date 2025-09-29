using System;
using System.Collections.Generic;
using System.Text;

namespace WinSFNETMENU_DAT
{
    /// <summary>
    /// TOPメニューアドオン情報クラス
    /// </summary>
    public class SfNetMenuAddOnInfoEx
    {
        public SfNetMenuAddOnInfoEx()
        {
        }

        #region プライベートメンバ
        /// <summary>TOPメニュー起動時</summary>
        private string[] _menuOpening;
        /// <summary>TOPメニュー終了時</summary>
        private string[] _menuEnding;
        /// <summary>従業員ログイン完了時</summary>
        private string[] _employeeLogin;
        /// <summary>従業員ログアウト完了時</summary>
        private string[] _employeeLogOut;
        /// <summary>従業員ログイン失敗時</summary>
        private string[] _employeeLoginError;
        /// <summary>インフォメーション起動時</summary>
        private string[] _informationOpening;
        /// <summary>ヘルプ起動時</summary>
        private string[] _helpOpening;
        /// <summary>業務メニュー起動時</summary>
        private string[] _sfnetmenu2Opening;
        /// <summary>設定起動時</summary>
        private string[] _settingOpening;
        /// <summary>リモートメンテナンス起動時</summary>
        private string[] _remoteMaintenanceOpening;


        
        #endregion

        #region プロパティ
        /// <summary>TOPメニュー起動時</summary>
        public string[] MenuOpening
        {
            get { return _menuOpening; }
            set { _menuOpening = value; }
        }
        /// <summary>TOPメニュー終了時</summary>
        public string[] MenuEnding
        {
            get { return _menuEnding; }
            set { _menuEnding = value; }
        }
        /// <summary>従業員ログイン完了時</summary>
        public string[] EmployeeLogin
        {
            get { return _employeeLogin; }
            set { _employeeLogin = value; }
        }
        /// <summary>従業員ログアウト完了時</summary>
        public string[] EmployeeLogOut
        {
            get { return _employeeLogOut; }
            set { _employeeLogOut = value; }
        }
        /// <summary>従業員ログイン失敗時</summary>
        public string[] EmployeeLoginError
        {
            get { return _employeeLoginError; }
            set { _employeeLoginError = value; }
        }
        /// <summary>インフォメーション起動時</summary>
        public string[] InformationOpening
        {
            get { return _informationOpening; }
            set { _informationOpening = value; }
        }
        /// <summary>ヘルプク起動時</summary>
        public string[] HelpOpening
        {
            get { return _helpOpening; }
            set { _helpOpening = value; }
        }
        /// <summary>業務メニュー起動時</summary>
        public string[] Sfnetmenu2Opening
        {
            get { return _sfnetmenu2Opening; }
            set { _sfnetmenu2Opening = value; }
        }
        /// <summary>設定起動時</summary>
        public string[] SettingOpening
        {
            get { return _settingOpening; }
            set { _settingOpening = value; }
        }
        /// <summary>リモートメンテナンス起動時</summary>
        public string[] RemoteMaintenanceOpening
        {
            get { return _remoteMaintenanceOpening; }
            set { _remoteMaintenanceOpening = value; }
        }
        #endregion


    }
}
