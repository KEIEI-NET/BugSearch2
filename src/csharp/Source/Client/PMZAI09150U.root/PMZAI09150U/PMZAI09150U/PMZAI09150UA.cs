//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫履歴現在庫数設定
// プログラム概要   : 在庫マスタの現在庫数を元に、在庫履歴データの正しい現在庫数を再計算し更新する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/12/24  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 :
// 修 正 日  2010/01/13  修正内容 : redmine#2333 対象年月の初期表示を修正
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using System.Globalization;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 在庫履歴現在庫数設定
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫マスタの現在庫数を元に、在庫履歴データの正しい現在庫数を再計算し更新する。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009/12/24</br>
    /// <br>UpdateNote : 2010/01/13 李占川 ＰＭ．ＮＳ保守依頼④</br>
    /// <br>             redmine#2333 対象年月の初期表示を修正</br>
    /// </remarks>
    public partial class PMZAI09150UA : Form
    {
        #region ■ Const Memebers ■
        private const string ct_ClassID = "PMZAI09150UA";
        #endregion ■ Const Memebers ■

        #region ■ private field ■

        // 企業コード
        private string _enterpriseCode;

        private ImageList _imageList16 = null;
        // クローズボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        // 実行ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _runButton;
        // ログイン担当者
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin;
        // 在庫履歴現在庫数設定インターフェース対象
        private StockHistoryUpdateAcs _stockHistoryUpdateAcs;
        // ログイン担当者名称
        private string _loginName = LoginInfoAcquisition.Employee.Name;
        // デフォルト行の外観設定
        Infragistics.Win.Appearance _defRowAppearance = new Infragistics.Win.Appearance();

        private DateGetAcs _dateGetAcs;

        private ObjAutoSetAcs _objAutoSetAcs;
        #endregion ■ private field ■

        #region ■ Constructor ■
        /// <summary>
        /// 在庫履歴現在庫数設定UIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫履歴現在庫数設定UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/12/24</br>
        /// <br></br>
        /// </remarks>
        public PMZAI09150UA()
        {
            InitializeComponent();
            // 変数初期化
            // 企業コード
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._runButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Run"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            this._stockHistoryUpdateAcs = new StockHistoryUpdateAcs();
            this._dateGetAcs = DateGetAcs.GetInstance();
            this._objAutoSetAcs = ObjAutoSetAcs.GetInstance();
        }
        #endregion ■ Constructor ■

        #region  ■ Control Event ■
        #region ■ フォームロード ■
        /// <summary>
        /// 画面の処理化処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>   
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: 画面の処理化を行う。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2009/12/24</br>
        /// <br>UpdateNote  : 2010/01/13 李占川 ＰＭ．ＮＳ保守依頼④</br>
        /// <br>              redmine#2333 対象年月の初期表示を修正</br>
        /// </remarks>
        private void PMZAI09150UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            // ボタン初期化
            this.ButtonInitialSetting();

            // ログイン担当者の設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;

            // 初期表示は本年度の期首月とする。
            List<DateTime> yearMonth;
            this._objAutoSetAcs.GetCompanyInf(out yearMonth);
            //this.tDateEdit_AddUpYearMonthSt.SetDateTime(DateTime.ParseExact(DateTime.Now.ToString("yyyy") + yearMonth[0].ToString("MMdd"), "yyyyMMdd", CultureInfo.InvariantCulture)); // DEL 2010/01/13
            this.tDateEdit_AddUpYearMonthSt.SetDateTime(yearMonth[0]); // ADD 2010/01/13
        }
        #endregion ■ フォームロード ■

        #region ■ ツールバーボタンクリックイベント処理 ■
        /// <summary>
        /// ツールバーボタンクリックイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>   
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: なし。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 終了処理
                        this.Close();
                        break;
                    }
                case "ButtonTool_Run":
                    {
                        // チェック処理
                        if (this.UpdateBeforeCheck())
                        {
                            // 実行確認メッセージ表示
                            DialogResult dialogResult = TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_QUESTION,
                                this.Name,
                                "処理を実行しますか？",
                                0,
                                MessageBoxButtons.YesNo);

                            if (dialogResult == DialogResult.Yes)
                            {
                                // 実行処理
                                this.UpdateProcess();
                            }
                        }
                        break;
                    }
            }
        }
        #endregion ■ ツールバーボタンクリックイベント処理 ■
        #endregion

        #region  ■ Private Method ■
        #region  ■ 在庫履歴データ更新処理 ■
        /// <summary>
        /// 在庫履歴データ更新処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 在庫履歴データ更新処理を行う。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        private void UpdateProcess()
        {
            // 抽出中画面部品のインスタンスを作成
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            SFCMN00299CA form = new SFCMN00299CA();
            // 表示文字を設定
            form.Title = "在庫履歴現在庫数設定";
            form.Message = "現在、処理中です。";
            // ダイアログ表示
            form.Show();
            string errMsg = string.Empty;

            // 検索条件格納処理
            StockHistoryExtractInfo extrInfo;
            this.SetExtrInfo(out extrInfo);

            // 在庫履歴更新処理
            status = this._stockHistoryUpdateAcs.Update(extrInfo, out errMsg);

            // ダイアログを閉じる
            form.Close();
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "処理が完了しました。",
                    -1,
                    MessageBoxButtons.OK);
            }
            else if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                TMsgDisp.Show(
                   this,
                   emErrorLevel.ERR_LEVEL_INFO,
                   this.Name,
                   "該当データありません。",
                   -1,
                   MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    errMsg,
                    status,
                    MessageBoxButtons.OK);
            }
        }
        #endregion ■ 在庫履歴データ更新処理 ■

        #region  ■ ボタン初期設定処理 ■
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面初期化時に発生します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            // 終了ボタン
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // 実行ボタン
            this._runButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            // ログイン担当者レーベル
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

        }
        #endregion ■ ボタン初期設定処理 ■

        /// <summary>
        /// 検索条件格納処理
        /// </summary>
        /// <param name="extrInfo">検索条件(明示的にoutパラメータで渡します)</param>
        /// <remarks>
        /// <br>Note        : 検索条件を格納します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/12/24</br>
        /// </remarks>
        private void SetExtrInfo(out StockHistoryExtractInfo extrInfo)
        {
            extrInfo = new StockHistoryExtractInfo();

            // 企業コード
            extrInfo.EnterpriseCode = this._enterpriseCode;

            // 対象年月
            DateTime dateAddUpYearMonthSt = this.tDateEdit_AddUpYearMonthSt.GetDateTime();
            extrInfo.AddUpYearMonthSt = Convert.ToInt32(dateAddUpYearMonthSt.ToString("yyyyMM"));
        }

        /// <summary>
        /// クリア前のチェック処理
        /// </summary>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note        : クリア前のチェック処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/12/24</br>
        /// </remarks>
        private bool UpdateBeforeCheck()
        {
            string errMsg = string.Empty;

            // 日付の未入力チェック
            if (this.CheckDateNoInput(this.tDateEdit_AddUpYearMonthSt))
            {
                errMsg = "対象年月を入力して下さい。";
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    errMsg,
                    -1,
                    MessageBoxButtons.OK);
                this.tDateEdit_AddUpYearMonthSt.Select();
                return false;
            }

            // 日付の不正入力チェック
            if (this.CheckDateInvalid(this.tDateEdit_AddUpYearMonthSt))
            {
                errMsg = "対象年月が不正です。";
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    errMsg,
                    -1,
                    MessageBoxButtons.OK);
                this.tDateEdit_AddUpYearMonthSt.Select();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 日付の未入力チェック
        /// </summary>
        /// <param name="targetDateEdit">日付</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note        : 日付の未入力チェックを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/12/24</br>
        /// </remarks>
        private bool CheckDateNoInput(TDateEdit targetDateEdit)
        {
            DateGetAcs.CheckDateResult result = this._dateGetAcs.CheckDate(ref targetDateEdit);
            return (result == DateGetAcs.CheckDateResult.ErrorOfNoInput);
        }

        /// <summary>
        /// 日付の不正入力チェック
        /// </summary>
        /// <param name="targetDateEdit">日付</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note        : 日付の不正入力チェックを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/12/24</br>
        /// </remarks>
        private bool CheckDateInvalid(TDateEdit targetDateEdit)
        {
            DateGetAcs.CheckDateResult result = this._dateGetAcs.CheckDate(ref targetDateEdit);
            return (result == DateGetAcs.CheckDateResult.ErrorOfInvalid);
        }
        #endregion  ■ Private Method ■
    }
}