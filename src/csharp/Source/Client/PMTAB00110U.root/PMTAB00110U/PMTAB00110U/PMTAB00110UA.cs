//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : タブレット設定マスタアップロード処理
// プログラム概要   : タブレット設定マスタアップロード処理
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10902622-01 作成担当 : 鄭慕鈞
// 作 成 日  2013/05/29  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10902622-01 作成担当 : 鄭慕鈞
// 作 成 日  2013/06/14  修正内容 : 得意先マスタアップロード処理の追加
//----------------------------------------------------------------------------//
// 管理番号  10902622-01 作成担当 : 鄭慕鈞
// 作 成 日  2013/06/19  修正内容 : status値が常駐処理と合わせることの変更
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// タブレット設定マスタアップロード処理フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : タブレット設定マスタアップロード処理のフォームクラスです。</br>
    /// <br>Programmer : 鄭慕鈞</br>
    /// <br>Date       : 2013/05/29</br>
    /// </remarks>
    public partial class PMTAB00110UA : Form
    {
        // ===================================================================================== //
        // 定数
        // ===================================================================================== //
        #region ■ Private Const
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";						// 終了
        private const string TOOLBAR_EXECUTEBUTTON_KEY = "ButtonTool_Execute";                  // 実行

        private const string CT_PGID = "PMTAB00110U";
        private const string CT_PGNM = "タブレット設定マスタアップロード処理";

        private TabSCMUpLoadAcs tabSCMUpLoadAcs = null;
        #endregion ■ Private Const

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructors
        /// <summary>
        /// タブレット設定マスタアップロード処理フォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : タブレット設定マスタアップロード処理のフォームクラスです。</br>
        /// <br>Programmer : 鄭慕鈞</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        public PMTAB00110UA()
        {
            InitializeComponent();
            // タブレットログ対応　--------------------------------->>>>>
            // コンストラクタでログ出力用ディレクトリを作成
            System.IO.Directory.CreateDirectory(EasyLogger.OutPutPath);
            // タブレットログ対応　---------------------------------<<<<<
        }
        #endregion

        //======================================================================================= //
        //  内部メンバー
        //======================================================================================= //
        #region ■Private Members
        /// <summary>企業コード</summary>
        private string _enterpriseCode = "";
        /// <summary>自拠点コード</summary>
        private string _loginSectionCode = "";

        // タブレットログ対応　--------------------------------->>>>>
        private const string CLASS_NAME = "PMTAB00110UA";
        // タブレットログ対応　---------------------------------<<<<<

        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ◆Private Methods
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 鄭慕鈞</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        private void PMTAB00110UA_Load(object sender, EventArgs e)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "PMTAB00110UA_Load";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            // 画面を構築
            this.ScreenInitialSetting();
            tabSCMUpLoadAcs = new TabSCMUpLoadAcs();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
        }

        /// <summary>
        ///	画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面初期設定を処理します。</br>
        /// <br>Programmer : 鄭慕鈞</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {

            // イメージリスト設定
            this.tToolsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;

            //----------------------------
            // ツールアイコン設定
            //----------------------------
            // 終了
            this.tToolsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // 実行
            this.tToolsManager_MainMenu.Tools[TOOLBAR_EXECUTEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;

        }

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <param name="iLevel">エラーレベル</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 鄭慕鈞</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        private DialogResult MsgDisp(string message, emErrorLevel iLevel)
        {
            // メッセージ表示
            return TMsgDisp.Show(
                this,                               // 親ウィンドウフォーム
                iLevel,                             // エラーレベル
                this.GetType().ToString(),          // アセンブリＩＤまたはクラスＩＤ
                message,                            // 表示するメッセージ
                0,                                  // ステータス値
                MessageBoxButtons.OK);             // 表示するボタン
        }

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : ツールバークリックイベント。</br>
        /// <br>Programmer : 鄭慕鈞</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "tToolsManager_MainMenu_ToolClick";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            switch (e.Tool.Key)
            {
                // -------------------------------------------------------------------------------
                // 終了
                // -------------------------------------------------------------------------------
                case TOOLBAR_CLOSEBUTTON_KEY:
                    {
                        // タブレットログ対応　--------------------------------->>>>>
                        EasyLogger.Write(CLASS_NAME, methodName, "終了ボタンクリック");
                        // タブレットログ対応　---------------------------------<<<<<
                        #region 終了
                        this.Close();
                        #endregion
                        break;
                    }
                // -------------------------------------------------------------------------------
                // 実行
                // -------------------------------------------------------------------------------
                case TOOLBAR_EXECUTEBUTTON_KEY:
                    {
                        // タブレットログ対応　--------------------------------->>>>>
                        EasyLogger.Write(CLASS_NAME, methodName, "実行ボタンクリック");
                        // タブレットログ対応　---------------------------------<<<<<
                        #region 実行
                        DialogResult ret = TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, Text,
                                "実行しますか？", 0, MessageBoxButtons.OKCancel);
                        if (ret == DialogResult.OK)
                        {
                            SFCMN00299CA _progressForm;
                            _progressForm = new SFCMN00299CA();

                            _progressForm.Title = "アップロード中";
                            _progressForm.Message = "現在、データをアップロード中です。";
                            _progressForm.Show();
                            string msg = "";
                            if (this.ExecuteProc())
                            {
                                _progressForm.Close();
                                msg = "設定マスタのアップロードが完了しました。";
                            }
                            else
                            {
                                _progressForm.Close();
                                msg = "設定マスタのアップロードが失敗しました。";
                            }
                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text,
                               msg, 0, MessageBoxButtons.OK);
                        }
                        #endregion
                        break;
                    }
            }
            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
        }

        /// <summary>
        /// 実行処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 実行処理します。</br>
        /// <br>Programmer : 鄭慕鈞</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        /// <returns></returns>
        private bool ExecuteProc()
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "ExecuteProc";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            bool saveFlg = false;

            if(tabSCMUpLoadAcs == null)
            {
                tabSCMUpLoadAcs = new TabSCMUpLoadAcs();
            }
            int status = tabSCMUpLoadAcs.UploadFromNStoSCM(this._enterpriseCode,this._loginSectionCode.Trim());
            //各テープルアップロード成功の場合status++ 
            //status = 10:アップロード成功　status<10:アップロード失敗
            //if (status == 9) // DEL 鄭慕鈞  2013/06/14 得意先マスタアップロード処理の追加 
            //if (status == 10)  // ADD 鄭慕鈞  2013/06/14 得意先マスタアップロード処理の追加    // DEL 鄭慕鈞  2013/06/19  status値が常駐処理と合わせることの変更　
            if (status == 0)  // ADD 鄭慕鈞  2013/06/19  status値が常駐処理と合わせることの変更
            {
                saveFlg = true;
            }

            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
            return saveFlg;
        }

        #endregion
    }
}