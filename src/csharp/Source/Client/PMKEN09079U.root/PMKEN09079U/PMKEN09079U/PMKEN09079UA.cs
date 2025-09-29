//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 結合マスタ
// プログラム概要   : 結合マスタに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2010/06/08  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉超
// 修 正 日  2013/12/04  修正内容 : Redmine#41447の対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO; // ADD 譚洪　2013/12/04
using Broadleaf.Application.Common; // ADD 譚洪　2013/12/04
using Broadleaf.Application.Resources; // ADD 譚洪　2013/12/04

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 結合マスタ
    /// </summary>
    /// <remarks>
    /// Note       : 結合マスタ設定処理です。<br />
    /// Programmer : 譚洪<br />
    /// Date       : 2010/06/08<br />
    /// </remarks>
    public partial class PMKEN09079UA : Form
    {
        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMKEN09079UA()
        {
            InitializeComponent();

            this._userSetting = new FormMemPos(); // ADD 譚洪　2013/12/04
        }
        # endregion ■ コンストラクタ ■

        # region ■ private field ■

        private PMKEN09074UA _pmKEN09074UA;

        // ADD 譚洪　2013/12/04 FOR Redmine#41447 ------>>>>>>
        /// <summary>設定XMLファイル名</summary>
        private const string XML_FILE_NAME = "PMKEN09079U.XML";

        // ユーザー設定
        private FormMemPos _userSetting;

        public FormMemPos UserSetting
        {
            get { return this._userSetting; }
        }
        // ADD 譚洪　2013/12/04 FOR Redmine#41447 ------<<<<<<

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
        /// </remarks>
        private void PMKEN09079UA_Load(object sender, EventArgs e)
        {
            this._pmKEN09074UA = new PMKEN09074UA();
            this._pmKEN09074UA.TopLevel = false;
            this._pmKEN09074UA.FormBorderStyle = FormBorderStyle.None;

            // ADD 譚洪　2013/12/04 FOR Redmine#41447 ------>>>>>>
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
            // ADD 譚洪　2013/12/04 FOR Redmine#41447 ------<<<<<<

            this._pmKEN09074UA.Show();
            this._pmKEN09074UA.Dock = DockStyle.Fill;
            this.Text = this._pmKEN09074UA.Text;
            this.Controls.Add(this._pmKEN09074UA);
            this._pmKEN09074UA.FormClosed += new FormClosedEventHandler(this.PMKEN09079UA_FormClosed);
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
        /// </remarks>
        private void PMKEN09079UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        // ADD START 劉超　2013/12/04 FOR Redmine#41447 ------>>>>>>
        private void PMKEN09079UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._pmKEN09074UA.BeforeFormClose();

            _userSetting.Top = this.Top;
            _userSetting.Left = this.Left;
            _userSetting.Height = this.Height;
            _userSetting.Width = this.Width;
            _userSetting.WindowState = this.WindowState.ToString();
            this.Serialize();


        }
        // ADD END 劉超　2013/12/04 FOR Redmine#41447 ------<<<<<<

        // ADD START 譚洪　2013/12/04 FOR Redmine#41447 ------>>>>>>
        /// <summary>
        /// 結合マスタ用ユーザー設定シリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 結合マスタ用ユーザー設定のシリアライズを行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2013/12/04</br>
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
        /// 結合マスタ用ユーザー設定デシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 結合マスタ用ユーザー設定クラスをデシリアライズします。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2013/12/04</br>
        /// </remarks>
        private bool Deserialize()
        {
            bool fileExist = false;

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings_FormPos, XML_FILE_NAME))))
            {
                try
                {
                    this._userSetting = UserSettingController.DeserializeUserSetting<FormMemPos>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings_FormPos, XML_FILE_NAME)));
                    fileExist = true;
                }
                catch
                {
                    this._userSetting = new FormMemPos();
                }
            }

            return fileExist;
        }
        // ADD END 譚洪　2013/12/04 FOR Redmine#41447 ------<<<<<<

        #endregion ■ Private Method ■
    }

    #region FormMemPos
    /// <summary>
    /// 結合マスタ用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 結合マスタのユーザー設定情報を管理するクラス</br>
    /// <br>Programmer : </br>
    /// <br>Date       : </br>
    /// <br></br>
    /// </remarks>
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
        /// 結合マスタユーザー設定情報クラス
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
}