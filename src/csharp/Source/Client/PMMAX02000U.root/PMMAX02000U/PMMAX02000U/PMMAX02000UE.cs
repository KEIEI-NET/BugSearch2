//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 出品・入荷予約
// プログラム概要   : 出品・入荷予約 部品MAX認証入力画面
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 陳艶丹
// 作 成 日 : 2016/01/21   修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/02/22   修正内容 : Redmine#48629の障害一覧No.242　認証失敗時は前回入力値が表示される障害対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 部品MAX認証入力画面クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 部品MAX認証入力画面クラス。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2016/01/21</br>
    /// <br>UpdateNote : 宋剛 2016/02/22</br>
    /// <br>           : Redmine#48629の障害一覧No.242　認証失敗時は前回入力値が表示される障害対応</br>
    /// </remarks>
    public partial class PMMAX02000UE : Form
    {
        # region
        private PMMAX02000UC _pMMAX02000UC;
        // 企業コード
        private string _enterpriseCode;
        // ログイン拠点コード
        private string _loginSectionCode;
        // 部品MAXログインID
        private string _userID;
        // 部品MAXパスワード
        private string _userPassWord;
        // 表示文言
        private string _displayMessage;

        // ユーザーIDとパースワード保存用
        private DataSet menuDataSet = null;
        // クラス名
        private const string ct_PRINTNAME = "部品MAX認証入力画面";
        private const string CT_PGID = "PMMAX02000UE";

        /// <summary>
        /// 部品MAXログインID
        /// </summary>
        public string UserID
        {
            get { return _userID; }
        }

        /// <summary>
        /// 部品MAXパスワード
        /// </summary>
        public string UserPassWord
        {
            get { return _userPassWord; }
        }

        /// <summary>
        /// 表示文言
        /// </summary>
        public string DisplayMessage
        {
            get { return _displayMessage; }
            set { _displayMessage = value; }
        }

        /// <summary>
        /// 部品MAX認証入力画面コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 部品MAX認証入力画面クラスのインスタンスを生成します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public PMMAX02000UE()
        {
            InitializeComponent();

            _pMMAX02000UC = new PMMAX02000UC();
            // 企業コード
            this._enterpriseCode = _pMMAX02000UC.EnterpriseCode;
            // ログイン拠点コード
            this._loginSectionCode = _pMMAX02000UC.LoginSectionCode;
        }

        /// <summary>
        /// コンストラクタ　Nunit用
        /// </summary>
        /// <param name="param">パラメータ</param>
        /// <remarks>
        /// <br>Note       : 部品MAX認証入力画面クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public PMMAX02000UE(string param)
        {
            if (("NUnit").Equals(param))
            {
                // 初期化
                InitializeComponent();
            }
            else
            {
                throw new Exception();
            }
        }


        /// <summary>
        /// Form.Load イベント(PMMAX02000UE)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// <br>UpdateNote : 宋剛 2016/02/22</br>
        /// <br>           : Redmine#48629の障害一覧No.242　認証失敗時は前回入力値が表示される障害対応</br>
        /// </remarks>
        private void PMMAX02000UE_Load(object sender, EventArgs e)
        {
            this.ultraLabel_Message.Text = this._displayMessage;
            this.ultraLabel_Message.Appearance.TextVAlignAsString = "Middle";
            // ADD BY 宋剛 2016/02/22 FOR Redmine#48629の障害一覧No.242　認証失敗時は前回入力値が表示される障害対応 ---->>>>>
            this.tEdit_LoginId.Text = string.Empty;
            this.tEdit_Password.Text = string.Empty;
            // ADD BY 宋剛 2016/02/22 FOR Redmine#48629の障害一覧No.242　認証失敗時は前回入力値が表示される障害対応 ----<<<<<
            this.tEdit_LoginId.Focus();
        }

        /// <summary>
        /// 画面初期化
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面初期化を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public void InitialScreenData()
        {
            // ユーザー情報の表示
            this.UserInfoShow();
        }

        /// <summary>
        /// ユーザー情報の表示処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ユーザー情報の表示処理</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void UserInfoShow()
        {
            // ユーザー情報
            string userID;
            string userPassWord;
            bool userExistFlag = false;
            // DATファイルから、ユーザー情報を取得する
            _pMMAX02000UC.ReadDatFile(PMMAX02000UC.ct_Tbl_Users, this._enterpriseCode, this._loginSectionCode, out userID, out userPassWord, out userExistFlag);
            // 該当するユーザーを設定した場合
            if (userExistFlag)
            {
                // DATファイルにのIDとパースワードを使用し、表示する
                this.tEdit_LoginId.Text = userID.Trim();
                this.tEdit_Password.Text = userPassWord.Trim();
            }
            // 該当するユーザーを設定しない場合
            else
            {
                this.tEdit_LoginId.Text = string.Empty;
                this.tEdit_Password.Text = string.Empty;
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 保存ボタンClick イベント</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void uButton_Save_Click(object sender, EventArgs e)
        {
            // 保存前チェック
            string message = string.Empty;
            Control errControl = null;
            bool canExport = this.BeforeSaveCheck(out message, out errControl);

            if (!canExport)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, ct_PRINTNAME, "", "", message, -1, null, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                errControl.Focus();
            }
            else
            {
                // ユーザー情報
                string userID;
                string userPassWord;
                bool userExistFlag = false;
                // DATファイルから、ユーザー情報を取得する
                this.menuDataSet = _pMMAX02000UC.ReadDatFile(PMMAX02000UC.ct_Tbl_Users, this._enterpriseCode, this._loginSectionCode, out userID, out userPassWord, out userExistFlag);
                // ユーザー情報を新規登録する
                if (!userExistFlag)
                {
                    // ユーザー情報保存用DateTableの作成
                    _pMMAX02000UC.CreatUserDateTable(ref this.menuDataSet, this.tEdit_LoginId.Text.Trim(), this.tEdit_Password.Text.Trim());

                }
                // ユーザー情報更新
                else
                {
                    _pMMAX02000UC.ReSetDateTable(ref this.menuDataSet, this.tEdit_LoginId.Text.Trim(), this.tEdit_Password.Text.Trim());
                }
                // ユーザー情報をDATファイルにセットする
                _pMMAX02000UC.SetDateToDat(this.menuDataSet);

                // 部品MAXログインID
                this._userID = this.tEdit_LoginId.Text.Trim();
                // 部品MAXパスワード
                this._userPassWord = this.tEdit_Password.Text.Trim();
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }

        }

        /// <summary>
        /// 保存前にチェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errControl">エラーコントロール</param>
        /// <returns>エラー有無フラグ</returns>
        /// <remarks>
        /// <br>Note       : 保存前にチェック処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private bool BeforeSaveCheck(out string errMessage, out Control errControl)
        {
            bool result = true;
            errMessage = string.Empty;
            errControl = null;

            if (this.tEdit_LoginId.Text.Trim() == "")
            {
                // ログインＩＤ
                errMessage = MessageInfo.M_008;
                errControl = this.tEdit_LoginId;
                result = false;
                return result;
            }

            if (this.tEdit_Password.Text.Trim() == "")
            {
                // ログインパスワード
                errMessage = MessageInfo.M_009;
                errControl = this.tEdit_Password;
                result = false;
                return result;
            }
            return result;
        }

        /// <summary>
        /// Cancel_Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 中止ボタンClick イベント</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void uButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        /// <summary>
        /// フォーカス移動イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : フォーカス移動イベント処理</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                #region [パスワード]
                case "tEdit_Password":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Down:
                                    {
                                        // 保存ボタン
                                        e.NextCtrl = uButton_Save;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
        # endregion
                default:
                    break;
            }
        }
        # endregion
    }
}