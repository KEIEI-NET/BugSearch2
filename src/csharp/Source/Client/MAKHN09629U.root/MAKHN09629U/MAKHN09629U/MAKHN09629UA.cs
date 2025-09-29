//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : セットマスタ
// プログラム概要   : セットマスタに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2010/06/08  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11175121-00 作成担当 : gaocheng
// 修 正 日  2015/07/02  修正内容 : Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//---- ADD gaocheng 2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応 ---->>>>>
using Broadleaf.Application.Common;
using System.IO;
using Broadleaf.Application.Resources;
//---- ADD gaocheng 2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応 ----<<<<<

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// セットマスタ
    /// </summary>
    /// <remarks>
    /// Note       : セットマスタ設定処理です。<br />
    /// Programmer : 譚洪<br />
    /// Date       : 2010/06/08<br />
    /// </remarks>
    public partial class MAKHN09629UA : Form
    {
        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MAKHN09629UA()
        {
            InitializeComponent();
            this._userSetting = new FormMemPos(); // ADD gaocheng 2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応
        }
        # endregion ■ コンストラクタ ■

        # region ■ private field ■

        private MAKHN09620UA _maKHN09620UA;

        //---- ADD gaocheng 2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応 ---->>>>>
        /// <summary>設定XMLファイル名</summary>
        private const string XML_FILE_NAME = "MAKHN09629U.XML";
        /// <summary>画面の前回top位置</summary>
        private int _top;
        /// <summary>画面の前回left位置</summary>
        private int _left;
        /// <summary>画面の前回width値</summary>
        private int _width;
        /// <summary>画面の前回height値</summary>
        private int _height;
        // ユーザー設定
        private FormMemPos _userSetting;

        public FormMemPos UserSetting
        {
            get { return this._userSetting; }
        }
        //---- ADD gaocheng 2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応 ----<<<<<

        # endregion ■ private field ■

        # region ■ フォームロード ■
        /// <summary>
        /// フォームロードイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// <br>Update Note: 2015/07/02 gaocheng</br>
        /// <br>管理番号   : 11175121-00</br>
        /// <br>           : Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応</br>  
        /// </remarks>
        private void MAKHN09629UA_Load(object sender, EventArgs e)
        {
            this._maKHN09620UA = new MAKHN09620UA();
            this._maKHN09620UA.TopLevel = false;
            this._maKHN09620UA.FormBorderStyle = FormBorderStyle.None;
            //---- ADD gaocheng 2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応 ---->>>>>
            // 設定読み込み
            bool existFlg = this.Deserialize();

            if (existFlg)
            {
                this.Location = new Point(_userSetting.Left, _userSetting.Top);
                this.Height = _userSetting.Height;
                this.Width = _userSetting.Width;

                if (_userSetting.WindowState.Equals("Maximized"))
                {
                    this.WindowState = FormWindowState.Maximized;
                }
                else if (_userSetting.WindowState.Equals("Minimized"))
                {
                    this.WindowState = FormWindowState.Minimized;
                }
                else
                {
                    this.WindowState = FormWindowState.Normal;
                }
            }
            //---- ADD gaocheng 2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応 ----<<<<<
            this._maKHN09620UA.Show();
            this._maKHN09620UA.Dock = DockStyle.Fill;
            this.Text = this._maKHN09620UA.Text;
            this.Controls.Add(this._maKHN09620UA);
            this._maKHN09620UA.FormClosed += new FormClosedEventHandler(this.MAKHN09629UA_FormClosed);
        }
        # endregion ■ フォームロード ■

        #region ■ Private Method ■
        /// <summary>
        /// 画面閉じる処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// <br>Update Note: 2015/07/02 gaocheng</br>
        /// <br>管理番号   : 11175121-00</br>
        /// <br>           : Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応</br>   
        /// </remarks>
        private void MAKHN09629UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        //---- ADD gaocheng 2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応 ---->>>>>
        /// <summary>
        /// フォームクロージングイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォームクロージングイベントを行う。</br>
        /// <br>Programmer : gaocheng</br>
        /// <br>Date       : 2015/07/02</br>
        /// <br>管理番号   : 11175121-00</br>
        /// <br>           : Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応</br>   
        /// </remarks> 
        private void MAKHN09629UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._maKHN09620UA.BeforeFormClose();
            if (this.WindowState == FormWindowState.Minimized)
            {
                _userSetting.Top = this._top;
                _userSetting.Left = this._left;
                _userSetting.Height = this._height;
                _userSetting.Width = this._width;
                _userSetting.WindowState = this.WindowState.ToString();
            }
            else
            {
                _userSetting.Top = this.Top;
                _userSetting.Left = this.Left;
                _userSetting.Height = this.Height;
                _userSetting.Width = this.Width;
                _userSetting.WindowState = this.WindowState.ToString();
            }
            this.Serialize();
        }

        /// <summary>
        /// セットマスタ用ユーザー設定シリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : セットマスタ用ユーザー設定のシリアライズを行います。</br>
        /// <br>Programmer : gaocheng</br>
        /// <br>Date       : 2015/07/02</br>
        /// <br>管理番号   : 11175121-00</br>
        /// <br>           : Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応</br>   
        /// </remarks>
        private void Serialize()
        {
            try
            {
                UserSettingController.SerializeUserSetting(_userSetting, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings_FormPos, XML_FILE_NAME)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// セットマスタ用ユーザー設定デシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : セットマスタ用ユーザー設定クラスをデシリアライズします。</br>
        /// <br>Programmer : gaocheng</br>
        /// <br>Date       : 2015/07/02</br>
        /// <br>管理番号   : 11175121-00</br>
        /// <br>           : Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応</br>    
        /// </remarks>
        private bool Deserialize()
        {
            bool fileExist = false;

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings_FormPos, XML_FILE_NAME))))
            {
                try
                {
                    this._userSetting = UserSettingController.DeserializeUserSetting<FormMemPos>(Path.Combine(ConstantManagement_ClientDirectory.UISettings_FormPos, XML_FILE_NAME));
                    fileExist = true;
                }
                catch
                {
                    this._userSetting = new FormMemPos();
                }
            }

            return fileExist;
        }

        #endregion ■ Private Method ■
        /// <summary>
        /// フォームサイズ変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォームサイズ変更イベントを行う。</br>
        /// <br>Programmer : gaocheng</br>
        /// <br>Date       : 2015/07/02</br>
        /// <br>管理番号   : 11175121-00</br>
        /// <br>           : Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応</br>    
        /// </remarks>
        private void MAKHN09629UA_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this._left = this.Left;
                this._top = this.Top;
                this._width = this.Width;
                this._height = this.Height;
            }
        }
    }

    #region FormMemPos
    /// <summary>
    /// セットマスタ用ユーザー設定クラス
    /// </summary>
    [Serializable]
    public class FormMemPos
    {
        #region プライベート変数
        // TOP
        private int _top;
        // LEFT
        private int _left;
        // HEIGHT
        private int _height;
        // WIDTH
        private int _width;
        // WINDOWSTATE
        private string _windowState = string.Empty;
        #endregion

        # region コンストラクタ
        /// <summary>
        /// セットマスタユーザー設定情報クラス
        /// </summary>
        public FormMemPos()
        {
        }
        # endregion // コンストラクタ

        #region プロパティ
        /// <summary>TOP</summary>
        public int Top
        {
            get { return this._top; }
            set { this._top = value; }
        }
        /// <summary>LEFT</summary>
        public int Left
        {
            get { return this._left; }
            set { this._left = value; }
        }
        /// <summary>HEIGHT</summary>
        public int Height
        {
            get { return this._height; }
            set { this._height = value; }
        }
        /// <summary>WIDTH</summary>
        public int Width
        {
            get { return this._width; }
            set { this._width = value; }
        }
        /// <summary>WINDOWSTATE</summary>
        public string WindowState
        {
            get { return this._windowState; }
            set { this._windowState = value; }
        }
        #endregion
    }
    #endregion
    //---- ADD gaocheng 2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応 ----<<<<<
}