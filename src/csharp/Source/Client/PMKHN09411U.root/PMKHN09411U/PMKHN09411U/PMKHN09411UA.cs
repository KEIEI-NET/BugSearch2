//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率マスタ引用登録
// プログラム概要   : 掛率マスタ引用登録
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/08  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鈴木創
// 作 成 日  2021/09/06  修正内容 : 保存処理時、アクセスクラスに引用元得意先掛率グループコードが0000かどうかの情報を渡すよう修正。
//                                  BLINCIDENT-2384 PM(NS) 掛率マスタ引用登録の条件を確認したい。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;

using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// 掛率マスタ引用登録フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率マスタ引用登録を行います。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2008.03.27</br>
    /// </remarks>
    public partial class PMKHN09411UA : Form
    {
        // ===================================================================================== //
        // Private Members
        // ===================================================================================== //
        #region
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;					// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _updateButton;					// 更新ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;					// 選択解除ボタン					
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;				// ログイン担当者名称
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;

        private string _enterpriseCode;
        private RateQuoteInputAcs _rateQuoteInputAcs = null;
        private SecInfoAcs _secInfoAcs;                     // 拠点情報アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs = null;        // 拠点アクセスクラス
        private UserGuideAcs _userGuideAcs = null;			// ユーザーガイドアクセスクラス
        private CustomerSearchAcs _customerSearchAcs = null;  
        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, string> _custRateGrpDic;
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;
        private Control _prevControl = null;									// 現在のコントロール
        private bool _setDisplayFlg = false;
        private bool BfFocusFlg = false;
        private bool AfFocusFlg = false;
        #endregion

        // ===================================================================================== //
        // Constructor
        // ===================================================================================== //
        #region
        /// <summary>
        /// 掛率マスタ引用登録フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 掛率マスタ引用登録フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 劉洋</br>
        /// <br>Date		: 2008.03.27</br>
        /// </remarks>
        public PMKHN09411UA()
        {
            InitializeComponent();

            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;

            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._updateButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Update"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Clear"];

            //　企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._rateQuoteInputAcs = RateQuoteInputAcs.GetInstance();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._customerSearchAcs = new CustomerSearchAcs();

            // マスタ読込
            ReadSecInfoSet();

            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
        }
        #endregion

        // ===================================================================================== //
        //  Private Methods
        // ===================================================================================== //
        #region
        /// <summary>
        /// ボタン設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._updateButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            this.BfSectionGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.BfCustRateGrpGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.BfCustomerCodeGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.AfSectionGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.AfCustRateGrpGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.AfCustomerCodeGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
        }

        /// <summary>
        /// コンボクス
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void ComboBoxSetting()
        {
            // 対象区分
            this.SetItemObjectDistinction();
            // 更新区分
            this.SetItemUpdateDistinction();
        }

        /// <summary>
        /// 対象区分
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void SetItemObjectDistinction()
        {
            this.ObjectDistinction_tComEditor.Items.Clear();

            Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
            item0.Tag = 1;
            item0.DataValue = 0;
            item0.DisplayText = "売上・価格";
            this.ObjectDistinction_tComEditor.Items.Add(item0);

            Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
            item1.Tag = 2;
            item1.DataValue = 1;
            item1.DisplayText = "売上のみ";
            this.ObjectDistinction_tComEditor.Items.Add(item1);

            Infragistics.Win.ValueListItem item2 = new Infragistics.Win.ValueListItem();
            item2.Tag = 3;
            item2.DataValue = 2;
            item2.DisplayText = "価格のみ";
            this.ObjectDistinction_tComEditor.Items.Add(item2);

            this.ObjectDistinction_tComEditor.Value = 0;
        }

        
        /// <summary>
        /// 対象区分
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void SetItemUpdateDistinction()
        {
            this.UpdateDistinction_tComEditor.Items.Clear();

            Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
            item0.Tag = 1;
            item0.DataValue = 0;
            item0.DisplayText = "追加・更新";
            this.UpdateDistinction_tComEditor.Items.Add(item0);

            Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
            item1.Tag = 2;
            item1.DataValue = 1;
            item1.DisplayText = "追加のみ";
            this.UpdateDistinction_tComEditor.Items.Add(item1);

            this.UpdateDistinction_tComEditor.Value = 0;
        }

        /// <summary>
        /// 画面表示
        /// </summary>
        /// <param name="stockQuoteData">画面データ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void SetDisplay(StockQuoteData stockQuoteData)
        {
            if (stockQuoteData == null) return;

            this._setDisplayFlg = true;

            // start
            this.tEdit_BfSectionCode.BeginUpdate();
            this.tEdit_AfSectionName.BeginUpdate();
            this.tEdit_BfCustRateGrpCode.BeginUpdate();
            this.tNedit_BfCustomerCode.BeginUpdate();
            this.tEdit_BfCustomerName.BeginUpdate();
            this.tEdit_AfSectionCode.BeginUpdate();
            this.tEdit_AfSectionName.BeginUpdate();
            this.tEdit_BfCustRateGrpCode.BeginUpdate();
            this.tNedit_BfCustomerCode.BeginUpdate();
            this.tEdit_AfCustomerName.BeginUpdate();
            this.ObjectDistinction_tComEditor.BeginUpdate();
            this.UpdateDistinction_tComEditor.BeginUpdate();

            // 画面情報を表示する
            this.tEdit_BfSectionCode.Text = stockQuoteData.BfSectionCode;
            this.tEdit_BfSectionName.Text = stockQuoteData.BfSectionName;
            if (!string.IsNullOrEmpty(stockQuoteData.BfCustRateGrpName))
            {
                this.tEdit_BfCustRateGrpCode.DataText = stockQuoteData.BfCustRateGrpCode.ToString("0000");
            }
            else
            {
                this.tEdit_BfCustRateGrpCode.DataText = "";
            }
            this.tNedit_BfCustomerCode.SetInt(stockQuoteData.BfCustomerCode);
            this.tEdit_BfCustomerName.Text = stockQuoteData.BfCustomerName;
            this.tEdit_AfSectionCode.Text = stockQuoteData.AfSectionCode;
            this.tEdit_AfSectionName.Text = stockQuoteData.AfSectionName;
            if (!string.IsNullOrEmpty(stockQuoteData.AfCustRateGrpName))
            {
                this.tEdit_AfCustRateGrpCode.DataText = stockQuoteData.AfCustRateGrpCode.ToString("0000");
            }
            else
            {
                this.tEdit_AfCustRateGrpCode.DataText = "";
            }
            this.tNedit_AfCustomerCode.SetInt(stockQuoteData.AfCustomerCode);
            this.tEdit_AfCustomerName.Text = stockQuoteData.AfCustomerName;
            this.ObjectDistinction_tComEditor.Value = stockQuoteData.ObjectDistinctionCode;
            this.UpdateDistinction_tComEditor.Value = stockQuoteData.UpdateDistinctionCode;
            this.ReadCount_uLabel.Text = stockQuoteData.ReadCount.ToString("N0") + " " + "件";
            this.ProcessCount_uLabel.Text = stockQuoteData.ProcessCount.ToString("N0") + " " + "件";

            // 画面ENABLE
            this.tEdit_BfSectionCode.Enabled = true;
            this.BfSectionGuide_Button.Enabled = true;
            this.tEdit_BfCustRateGrpCode.Enabled = true;
            this.BfCustRateGrpGuide_Button.Enabled = true;
            this.tNedit_BfCustomerCode.Enabled = true;
            this.BfCustomerCodeGuide_Button.Enabled = true;
            this.tEdit_AfSectionCode.Enabled = true;
            this.AfSectionGuide_Button.Enabled = true;
            this.tEdit_AfCustRateGrpCode.Enabled = true;
            this.AfCustRateGrpGuide_Button.Enabled = true;
            this.tNedit_AfCustomerCode.Enabled = true;
            this.AfCustomerCodeGuide_Button.Enabled = true;

            // 引用元得意先掛率グループが入力の場合
            if (!string.IsNullOrEmpty(stockQuoteData.BfCustRateGrpName))
            {
                this.tNedit_BfCustomerCode.Enabled = false;
                this.BfCustomerCodeGuide_Button.Enabled = false;
            }
            // 引用元得意先コードが入力の場合
            if (stockQuoteData.BfCustomerCode != 0)
            {
                this.tEdit_BfCustRateGrpCode.Enabled = false;
                this.BfCustRateGrpGuide_Button.Enabled = false;
            }
            // 引用先得意先掛率グループが入力の場合
            if (!string.IsNullOrEmpty(stockQuoteData.AfCustRateGrpName))
            {
                this.tNedit_AfCustomerCode.Enabled = false;
                this.AfCustomerCodeGuide_Button.Enabled = false;
            }
            // 引用先得意先コードが入力の場合
            if (stockQuoteData.AfCustomerCode != 0)
            {
                this.tEdit_AfCustRateGrpCode.Enabled = false;
                this.AfCustRateGrpGuide_Button.Enabled = false;
            }

            // end
            this.tEdit_BfSectionCode.EndUpdate();
            this.tEdit_AfSectionName.EndUpdate();
            this.tEdit_BfCustRateGrpCode.EndUpdate();
            this.tNedit_BfCustomerCode.EndUpdate();
            this.tEdit_BfCustomerName.EndUpdate();
            this.tEdit_AfSectionCode.EndUpdate();
            this.tEdit_AfSectionName.EndUpdate();
            this.tEdit_AfCustRateGrpCode.EndUpdate();
            this.tNedit_AfCustomerCode.EndUpdate();
            this.tEdit_AfCustomerName.EndUpdate();
            this.ObjectDistinction_tComEditor.EndUpdate();
            this.UpdateDistinction_tComEditor.EndUpdate();

            this._setDisplayFlg = false;
        }

        /// <summary>
        /// 画面初期化
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void Clear()
        {
            // 画面初期化データ
            this._rateQuoteInputAcs.CreateStockQuoteInitialData();
            // 画面初期化表示
            this.SetDisplay(this._rateQuoteInputAcs.StockQuoteData);
            // 得意先掛率グループ設定
            this.tEdit_BfCustRateGrpCode.Clear();
            this.tEdit_AfCustRateGrpCode.Clear();

            this.timer_SetFocus.Enabled = true;
        }

        /// <summary>
        /// 画面更新
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void Save()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            if (this._prevControl != null)
            {
                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tRetKeyControl1_ChangeFocus(this, e);
            }

            // チェック
            bool isSave = BeforeSaveCheck();

            if (!isSave)
            {
                return;
            }

            string msg = string.Empty;

            // ADD BLINCIDENT-2384 2021/09/06 --------------------------------------------------->>>>>

            // 引用元の得意先掛率グループコードが「0000」のときFlagはTrue
            //   本画面では得意先掛率グループコードが「0000」と「指定なし」どちらの場合でも、
            //   BfCustRateGrpCode=0 となっており区別がつかないため、別途情報を付与する。
            bool bfCustRateGrpCodeIsZero = this.tEdit_BfCustRateGrpCode.Text.Trim() == "0000" ? true : false ;

            // ADD BLINCIDENT-2384 2021/09/06 ---------------------------------------------------<<<<<

            // UPD BLINCIDENT-2384 2021/09/06 --------------------------------------------------->>>>>
            
            // 保存処理
            //status = this._rateQuoteInputAcs.SaveData(ref msg);
            status = this._rateQuoteInputAcs.SaveData(ref msg, bfCustRateGrpCodeIsZero);

            // UPD BLINCIDENT-2384 2021/09/06 ---------------------------------------------------<<<<<

            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                // 該当なし
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                this.Name,											// アセンブリID
                                msg,                       // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);
                // 件数更新
                StockQuoteData stockQuoteData = this._rateQuoteInputAcs.StockQuoteData;

                this.ReadCount_uLabel.Text = stockQuoteData.ReadCount.ToString("N0") + " " + "件";
                this.ProcessCount_uLabel.Text = stockQuoteData.ProcessCount.ToString("N0") + " " + "件";
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                SaveCompletionDialog dialog = new SaveCompletionDialog();
                dialog.ShowDialog(2);
                // 件数更新
                this.ReadCount_uLabel.Text = this._rateQuoteInputAcs.StockQuoteData.ReadCount.ToString("N0") + " " + "件";
                this.ProcessCount_uLabel.Text = this._rateQuoteInputAcs.StockQuoteData.ProcessCount.ToString("N0") + " " + "件";
                // フォーカス設定
                this.tEdit_BfSectionCode.Focus();
            }
            else
            {
                // メッセージを呼び出す
                TMsgDisp.Show(
                   this,
                   emErrorLevel.ERR_LEVEL_STOPDISP,
                   this.Name,
                   "保存処理が失敗します。",
                   -1,
                   MessageBoxButtons.OK);
                // 件数更新
                this.ReadCount_uLabel.Text = this._rateQuoteInputAcs.StockQuoteData.ReadCount.ToString("N0") + " " + "件";
                this.ProcessCount_uLabel.Text = this._rateQuoteInputAcs.StockQuoteData.ProcessCount.ToString("N0") + " " + "件";
            }
        }

        /// <summary>
        /// 画面更新前チェック
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private bool BeforeSaveCheck()
        {

            StockQuoteData stockQuoteData = this._rateQuoteInputAcs.StockQuoteData;

            // 引用元拠点入力チェック
            if (string.IsNullOrEmpty(stockQuoteData.BfSectionCode))
            {
                // 該当なし
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                this.Name,											// アセンブリID
                                "引用元拠点が設定されていません。",                 // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);

                // フォーカス設定
                this.tEdit_BfSectionCode.Focus();
                return false;
            }

            // 引用先拠点入力チェック
            if (string.IsNullOrEmpty(stockQuoteData.AfSectionCode))
            {
                // 該当なし
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                this.Name,											// アセンブリID
                                "引用先拠点が設定されていません。",                 // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);

                // フォーカス設定
                this.tEdit_AfSectionCode.Focus();
                return false;
            }

            // 引用先情報が設定されていません
            if (string.IsNullOrEmpty(stockQuoteData.BfCustRateGrpName) && stockQuoteData.BfCustomerCode == 0)
            {
                // 該当なし
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                this.Name,											// アセンブリID
                                "引用元情報が設定されていません。",                 // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);

                // フォーカス設定
                this.tEdit_BfCustRateGrpCode.Focus();
                return false;
            }

            // 引用先情報が設定されていません
            if (string.IsNullOrEmpty(stockQuoteData.AfCustRateGrpName) && stockQuoteData.AfCustomerCode == 0)
            {
                // 該当なし
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                this.Name,											// アセンブリID
                                "引用先情報が設定されていません。",                 // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);

                // フォーカス設定
                this.tEdit_AfCustRateGrpCode.Focus();
                return false;
            }

            // 引用元と引用先拠点コードが同じで
            if (stockQuoteData.AfSectionCode.Equals(stockQuoteData.BfSectionCode))
            {
                if (!string.IsNullOrEmpty(stockQuoteData.BfCustRateGrpName) && !string.IsNullOrEmpty(stockQuoteData.AfCustRateGrpName)
                    && stockQuoteData.BfCustRateGrpCode == stockQuoteData.AfCustRateGrpCode)
                {
                    // 該当なし
                    TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                    this.Name,											// アセンブリID
                                    "引用元、引用先の得意先掛率グループ設定が不正です。", // 表示するメッセージ
                                    -1,													// ステータス値
                                    MessageBoxButtons.OK);

                    // フォーカス設定
                    this.tEdit_BfCustRateGrpCode.Focus();
                    return false;
                }

                if (stockQuoteData.BfCustomerCode != 0 && stockQuoteData.BfCustomerCode == stockQuoteData.AfCustomerCode)
                {
                    // 該当なし
                    TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                    this.Name,											// アセンブリID
                                    "引用元、引用先の得意先設定が不正です。",           // 表示するメッセージ
                                    -1,													// ステータス値
                                    MessageBoxButtons.OK);

                    // フォーカス設定
                    this.tNedit_BfCustomerCode.Focus();
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 拠点略称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名</returns>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            sectionCode = sectionCode.Trim().PadLeft(2, '0');

            if (sectionCode == "00")
            {
                return "全社";
            }

            if (this._secInfoSetDic.ContainsKey(sectionCode))
            {
                return this._secInfoSetDic[sectionCode].SectionGuideSnm.Trim();
            }

            return "";
        }

        /// <summary>
        /// 拠点情報マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
        }

        /// <summary>
        /// 得意先掛率グループ名称取得処理
        /// </summary>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <returns>得意先掛率グループ名称</returns>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private string GetCustRateGrpName(int custRateGrpCode)
        {
            string custRateGrpName = "";

            if (this._custRateGrpDic.ContainsKey(custRateGrpCode))
            {
                custRateGrpName = (string)this._custRateGrpDic[custRateGrpCode];
            }

            return custRateGrpName;
        }

        /// <summary>
        /// 得意先掛率グループ情報取得処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private int GetCustRateGrp()
        {
            this._custRateGrpDic = new Dictionary<int, string>();

            int status;
            ArrayList retList = new ArrayList();

            // ユーザーガイドデータ取得(得意先掛率グループ)
            status = GetUserGuideBd(out retList, 43);
            if (status == 0)
            {
                foreach (UserGdBd userGdBd in retList)
                {
                    this._custRateGrpDic.Add(userGdBd.GuideCode, userGdBd.GuideName.Trim());
                }
            }

            return status;
        }

        /// <summary>
        /// ユーザーガイドデータ取得処理
        /// </summary>
        /// <param name="retList">ユーザーガイドボディデータリスト</param>
        /// <param name="userGuideDivCd">ガイド区分</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private int GetUserGuideBd(out ArrayList retList, int userGuideDivCd)
        {
            int status;
            retList = new ArrayList();

            status = this._userGuideAcs.SearchAllDivCodeBody(out retList, this._enterpriseCode,
                                                             userGuideDivCd, UserGuideAcsData.UserBodyData);

            return status;
        }

        /// <summary>
        /// 得意先名称取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先名称</returns>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            string customerName = "";

            try
            {
                if (this._customerSearchRetDic.ContainsKey(customerCode))
                {
                    customerName = this._customerSearchRetDic[customerCode].Snm.Trim();
                }
            }
            catch
            {
                customerName = "";
            }

            return customerName;
        }
        
        /// <summary>
        /// 得意先検索マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void LoadCustomerSearchRet()
        {
            this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();

            try
            {
                CustomerSearchPara para = new CustomerSearchPara();
                para.EnterpriseCode = this._enterpriseCode;

                CustomerSearchRet[] retList;

                int status = this._customerSearchAcs.Serch(out retList, para);
                if (status == 0)
                {
                    foreach (CustomerSearchRet ret in retList)
                    {
                        if (ret.LogicalDeleteCode == 0)
                        {
                            this._customerSearchRetDic.Add(ret.CustomerCode, ret);
                        }
                    }
                }
            }
            catch
            {
                this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
            }
        }
        #endregion


        // ===================================================================================== //
        // 各コントロールイベント処理
        // ===================================================================================== //
        # region ■Control Event Methods
        /// <summary>
        ///	Form.Load イベント(PMKHN09411U)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer	: 劉洋</br>
        /// <br>Date		: 2008.03.27</br>
        /// </remarks>
        private void PMKHN09411U_Load(object sender, EventArgs e)
        {
            // ボタン設定
            this.ButtonInitialSetting();

            // コンボクス設定
            this.ComboBoxSetting();

            // 画面初期化
            this.Clear();
        }

        /// <summary>
        /// イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 終了処理
                        Close();
                        break;
                    }
                case "ButtonTool_Update":
                    {
                        this.Save();
                        break;
                    }
                case "ButtonTool_Clear":
                    {
                        // クリア処理
                        this.Clear();
                        break;
                    }
            }
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            this._prevControl = e.NextCtrl;

            bool reReadFlg = false;

            StockQuoteData stockQuoteDataCurrent = this._rateQuoteInputAcs.StockQuoteData.Clone();
            if (stockQuoteDataCurrent == null) return;

            StockQuoteData stockQuoteData = stockQuoteDataCurrent.Clone();

            switch (e.PrevCtrl.Name)
            {
                // 引用元拠点コード
                case "tEdit_BfSectionCode":
                    {
                        string code = this.tEdit_BfSectionCode.Text.Trim().PadLeft(2, '0');

                        if (string.IsNullOrEmpty(code) || "00".Equals(code))
                        {
                            code = "00";
                            stockQuoteData.BfSectionCode = code;
                            stockQuoteData.BfSectionName = GetSectionName(code);
                        }

                        if (e.ShiftKey == false)
                        {
                            // 入力変更なし
                            if (code.Equals(stockQuoteData.BfSectionCode))
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    if (string.IsNullOrEmpty(code))
                                    {
                                        e.NextCtrl = this.BfSectionGuide_Button;
                                    }
                                    else
                                    {
                                        if (this.tEdit_BfCustRateGrpCode.Enabled)
                                        {
                                            e.NextCtrl = this.tEdit_BfCustRateGrpCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_BfCustomerCode;
                                        }
                                    }
                                }

                                break;
                            }
                            else
                            {
                                // 入力無し
                                if (string.IsNullOrEmpty(this.tEdit_BfSectionCode.Text.Trim()))
                                {
                                    // 設定値保存、名称のクリア
                                    stockQuoteData.BfSectionCode = string.Empty;
                                    stockQuoteData.BfSectionName = string.Empty;

                                    // フォーカス設定
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.BfSectionGuide_Button;
                                    }

                                    break;
                                }

                                if (!string.IsNullOrEmpty(GetSectionName(code)))
                                {
                                    // 結果を画面に設定
                                    stockQuoteData.BfSectionCode = code;
                                    stockQuoteData.BfSectionName = GetSectionName(code);
                                }
                                else
                                {
                                    // 該当なし
                                    TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                                    emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                                    this.Name,											// アセンブリID
                                                    "マスタに存在しません。", // 表示するメッセージ
                                                    -1,													// ステータス値
                                                    MessageBoxButtons.OK);           					// 表示するボタン
                                    // 画面表示
                                    this.SetDisplay(stockQuoteData);
                                    // ↓ 2009.07.07 劉洋 modify PVCS NO.307
                                    // フォーカス設定
                                    // e.NextCtrl = this.BfSectionGuide_Button;
                                    e.NextCtrl = e.PrevCtrl;
                                    // ↑ 2009.07.07 劉洋
                                    return;
                                }

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    if (this.tEdit_BfCustRateGrpCode.Enabled)
                                    {
                                        e.NextCtrl = this.tEdit_BfCustRateGrpCode;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tNedit_BfCustomerCode;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // 入力変更なし
                            if (code.Equals(stockQuoteData.BfSectionCode))
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.UpdateDistinction_tComEditor;
                                }

                                break;
                            }
                            else
                            {
                                // 入力無し
                                if (string.IsNullOrEmpty(this.tEdit_BfSectionCode.Text.Trim()))
                                {
                                    // 設定値保存、名称のクリア
                                    stockQuoteData.BfSectionCode = string.Empty;
                                    stockQuoteData.BfSectionName = string.Empty;

                                    // フォーカス設定
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.UpdateDistinction_tComEditor;
                                    }

                                    break;
                                }

                                if (!string.IsNullOrEmpty(GetSectionName(code)))
                                {
                                    // 結果を画面に設定
                                    stockQuoteData.BfSectionCode = code;
                                    stockQuoteData.BfSectionName = GetSectionName(code);
                                }
                                else
                                {
                                    // 該当なし
                                    TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                                    emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                                    this.Name,											// アセンブリID
                                                    "マスタに存在しません。", // 表示するメッセージ
                                                    -1,													// ステータス値
                                                    MessageBoxButtons.OK);           					// 表示するボタン
                                    // 画面表示
                                    this.SetDisplay(stockQuoteData);
                                    // ↓ 2009.07.07 劉洋 modify PVCS NO.307
                                    // フォーカス設定
                                    // e.NextCtrl = this.BfSectionGuide_Button;
                                    e.NextCtrl = e.PrevCtrl;
                                    // ↑ 2009.07.07 劉洋
                                    return;
                                }

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.UpdateDistinction_tComEditor;
                                }
                            }
                        }

                        break;
                    }
                // 引用元拠点ボタン
                case "BfSectionGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                if (this.tEdit_BfCustRateGrpCode.Enabled)
                                {
                                    e.NextCtrl = this.tEdit_BfCustRateGrpCode;
                                }
                                else
                                {
                                    e.NextCtrl = this.tNedit_BfCustomerCode;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.tEdit_BfSectionCode;
                            }
                        }
                        break;
                    }
                // 引用元得意先掛率グループ
                case "tEdit_BfCustRateGrpCode":
                    {
                        if (_custRateGrpDic == null)
                        {
                            GetCustRateGrp();
                        }

                        string value = this.tEdit_BfCustRateGrpCode.Text.Trim();
                        // 入力正確性判断
                        bool inputFlg = true;
                        for (int i = 0; i < value.Length; i++)
                        {
                            if (!char.IsNumber(value, i))
                            {
                                inputFlg = false;
                                break;
                            }
                        }

                        if (e.ShiftKey == false)
                        {
                            // 引用元得意先掛率グループ
                            if (this.tEdit_BfCustRateGrpCode.DataText.Trim() == "" || !inputFlg)
                            {
                                // クリア
                                stockQuoteData.BfCustRateGrpCode = 0;
                                stockQuoteData.BfCustRateGrpName = string.Empty;

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // フォーカス
                                    e.NextCtrl = this.BfCustRateGrpGuide_Button;
                                }

                                this.SetDisplay(stockQuoteData);

                                this._rateQuoteInputAcs.CacheStockQuoteData(stockQuoteData);

                                this.tEdit_BfCustRateGrpCode.Clear();

                                this.tEdit_BfCustRateGrpCode.DataText = "";

                                return;
                            }

                            reReadFlg = true;

                            // 入力コード
                            int code = Convert.ToInt32(this.tEdit_BfCustRateGrpCode.Text.ToString());

                            // 入力変更なし
                            if (code == stockQuoteData.BfCustRateGrpCode && !string.IsNullOrEmpty(stockQuoteData.BfCustRateGrpName))
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    if (code == 0 && string.IsNullOrEmpty(stockQuoteData.BfCustRateGrpName))
                                    {
                                        e.NextCtrl = this.BfCustRateGrpGuide_Button;
                                    }
                                    else
                                    {
                                        if (this.tNedit_BfCustomerCode.Enabled)
                                        {
                                            e.NextCtrl = this.tNedit_BfCustomerCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_AfSectionCode;
                                        }
                                    }
                                }

                                break;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(GetCustRateGrpName(code)))
                                {
                                    // 結果を画面に設定
                                    stockQuoteData.BfCustRateGrpCode = code;
                                    stockQuoteData.BfCustRateGrpName = GetCustRateGrpName(code);
                                }
                                else
                                {
                                    // 該当なし
                                    TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                                    emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                                    this.Name,											// アセンブリID
                                                    "マスタに存在しません。", // 表示するメッセージ
                                                    -1,													// ステータス値
                                                    MessageBoxButtons.OK);           					// 表示するボタン
                                    // 画面表示
                                    this.SetDisplay(stockQuoteData);
                                    // ↓ 2009.07.07 劉洋 modify PVCS NO.307
                                    // フォーカス設定
                                    // e.NextCtrl = this.BfCustRateGrpGuide_Button;
                                    e.NextCtrl = e.PrevCtrl;
                                    // ↑ 2009.07.07 劉洋
                                    return;
                                }

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tEdit_AfSectionCode;
                                }
                            }
                        }
                        else
                        {
                            // 引用元得意先掛率グループ
                            if (this.tEdit_BfCustRateGrpCode.DataText.Trim() == "" || !inputFlg)
                            {
                                // クリア
                                stockQuoteData.BfCustRateGrpCode = 0;
                                stockQuoteData.BfCustRateGrpName = string.Empty;

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // フォーカス
                                    e.NextCtrl = this.tEdit_BfSectionCode;
                                }

                                this.SetDisplay(stockQuoteData);

                                this._rateQuoteInputAcs.CacheStockQuoteData(stockQuoteData);

                                this.tEdit_BfCustRateGrpCode.Clear();

                                this.tEdit_BfCustRateGrpCode.DataText = "";

                                return;
                            }

                            reReadFlg = true;

                            // 入力コード
                            int code = Convert.ToInt32(this.tEdit_BfCustRateGrpCode.Text.ToString());

                            // 入力変更なし
                            if (code == stockQuoteData.BfCustRateGrpCode && !string.IsNullOrEmpty(stockQuoteData.BfCustRateGrpName))
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tEdit_BfSectionCode;
                                }

                                break;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(GetCustRateGrpName(code)))
                                {
                                    // 結果を画面に設定
                                    stockQuoteData.BfCustRateGrpCode = code;
                                    stockQuoteData.BfCustRateGrpName = GetCustRateGrpName(code);
                                }
                                else
                                {
                                    // 該当なし
                                    TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                                    emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                                    this.Name,											// アセンブリID
                                                    "マスタに存在しません。", // 表示するメッセージ
                                                    -1,													// ステータス値
                                                    MessageBoxButtons.OK);           					// 表示するボタン
                                    // 画面表示
                                    this.SetDisplay(stockQuoteData);
                                    // ↓ 2009.07.07 劉洋 modify PVCS NO.307
                                    // フォーカス設定
                                    // e.NextCtrl = this.BfCustRateGrpGuide_Button;
                                    e.NextCtrl = e.PrevCtrl;
                                    // ↑ 2009.07.07 劉洋
                                    return;
                                }

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tEdit_BfSectionCode;
                                }
                            }
                        }


                        break;
                    }
                // 引用元得意先掛率グループ
                case "BfCustRateGrpGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                if (this.tNedit_BfCustomerCode.Enabled)
                                {
                                    e.NextCtrl = this.tNedit_BfCustomerCode;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_AfSectionCode;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.tEdit_BfCustRateGrpCode;
                            }
                        }
                        break;
                    }
                // 引用元得意先コード
                case "tNedit_BfCustomerCode":
                    {
                        // 得意先検索
                        if (_customerSearchRetDic == null)
                        {
                            LoadCustomerSearchRet();
                        }

                        // 入力コード
                        int code = this.tNedit_BfCustomerCode.GetInt();

                        if (e.ShiftKey == false)
                        {
                        // 入力変更なし
                            if (code == stockQuoteData.BfCustomerCode)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    if (code == 0)
                                    {
                                        e.NextCtrl = this.BfCustomerCodeGuide_Button;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_AfSectionCode;
                                    }
                                }

                                break;
                            }
                            else
                            {
                                // 入力無し
                                if (code == 0)
                                {
                                    // 設定値保存、名称のクリア
                                    stockQuoteData.BfCustomerCode = 0;
                                    stockQuoteData.BfCustomerName = string.Empty;

                                    // フォーカス設定
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.BfCustomerCodeGuide_Button;
                                    }

                                    break;
                                }

                                if (!string.IsNullOrEmpty(GetCustomerName(code)))
                                {
                                    // 結果を画面に設定
                                    stockQuoteData.BfCustomerCode = code;
                                    stockQuoteData.BfCustomerName = GetCustomerName(code);
                                }
                                else
                                {
                                    // 該当なし
                                    TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                                    emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                                    this.Name,											// アセンブリID
                                                    "マスタに存在しません。", // 表示するメッセージ
                                                    -1,													// ステータス値
                                                    MessageBoxButtons.OK);           					// 表示するボタン
                                    // 画面表示
                                    this.SetDisplay(stockQuoteData);
                                    // ↓ 2009.07.07 劉洋 modify PVCS NO.307
                                    // フォーカス設定
                                    // e.NextCtrl = this.BfCustomerCodeGuide_Button;
                                    e.NextCtrl = e.PrevCtrl;
                                    // ↑ 2009.07.07 劉洋 modify
                                    return;
                                }

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tEdit_AfSectionCode;
                                }
                            }
                        }
                        else
                        {
                            if (code == stockQuoteData.BfCustomerCode)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    if (!this.tEdit_BfCustRateGrpCode.Enabled)
                                    {
                                        e.NextCtrl = this.tEdit_BfSectionCode;
                                    }
                                    else
                                    {
                                        if (!string.IsNullOrEmpty(this.tEdit_BfCustRateGrpCode.DataText))
                                        {
                                            e.NextCtrl = this.tEdit_BfCustRateGrpCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.BfCustRateGrpGuide_Button;
                                        }
                                    }
                                }

                                break;
                            }
                            else
                            {
                                // 入力無し
                                if (code == 0)
                                {
                                    // 設定値保存、名称のクリア
                                    stockQuoteData.BfCustomerCode = 0;
                                    stockQuoteData.BfCustomerName = string.Empty;

                                    // フォーカス設定
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        if (!this.tEdit_BfCustRateGrpCode.Enabled)
                                        {
                                            e.NextCtrl = this.tEdit_BfSectionCode;
                                        }
                                        else
                                        {
                                            if (!string.IsNullOrEmpty(this.tEdit_BfCustRateGrpCode.DataText))
                                            {
                                                e.NextCtrl = this.tEdit_BfCustRateGrpCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.BfCustRateGrpGuide_Button;
                                            }
                                        }
                                    }

                                    break;
                                }

                                if (!string.IsNullOrEmpty(GetCustomerName(code)))
                                {
                                    // 結果を画面に設定
                                    stockQuoteData.BfCustomerCode = code;
                                    stockQuoteData.BfCustomerName = GetCustomerName(code);
                                }
                                else
                                {
                                    // 該当なし
                                    TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                                    emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                                    this.Name,											// アセンブリID
                                                    "マスタに存在しません。", // 表示するメッセージ
                                                    -1,													// ステータス値
                                                    MessageBoxButtons.OK);           					// 表示するボタン
                                    // 画面表示
                                    this.SetDisplay(stockQuoteData);
                                    // ↓ 2009.07.07 劉洋 modify PVCS NO.307
                                    // フォーカス設定
                                    // e.NextCtrl = this.BfCustomerCodeGuide_Button;
                                    e.NextCtrl = e.PrevCtrl;
                                    // ↓ 2009.07.07 劉洋 modify
                                    return;
                                }

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    if (!this.tEdit_BfCustRateGrpCode.Enabled)
                                    {
                                        e.NextCtrl = this.tEdit_BfSectionCode;
                                    }
                                    else
                                    {
                                        if (!string.IsNullOrEmpty(this.tEdit_BfCustRateGrpCode.DataText))
                                        {
                                            e.NextCtrl = this.tEdit_BfCustRateGrpCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.BfCustRateGrpGuide_Button;
                                        }
                                    }
                                }
                            }
                        }

                        break;
                    }
                // 引用元得意先ボタン
                case "BfCustomerCodeGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.tEdit_AfSectionCode;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.tNedit_BfCustomerCode;
                            }
                        }
                        break;
                    }
                // 引用先拠点コード
                case "tEdit_AfSectionCode":
                    {
                        string code = this.tEdit_AfSectionCode.DataText.Trim().PadLeft(2, '0');

                        if (e.ShiftKey == false)
                        {
                            if (string.IsNullOrEmpty(code) || "00".Equals(code))
                            {
                                code = "00";
                                stockQuoteData.AfSectionCode = code;
                                stockQuoteData.AfSectionName = GetSectionName(code);
                            }

                            // 入力変更なし
                            if (code.Equals(stockQuoteData.AfSectionCode))
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    if (string.IsNullOrEmpty(code))
                                    {
                                        e.NextCtrl = this.AfSectionGuide_Button;
                                    }
                                    else
                                    {
                                        if (this.tEdit_AfCustRateGrpCode.Enabled)
                                        {
                                            e.NextCtrl = this.tEdit_AfCustRateGrpCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_AfCustomerCode;
                                        }
                                    }
                                }

                                break;
                            }
                            else
                            {
                                // 入力無し
                                if (string.IsNullOrEmpty(this.tEdit_AfSectionCode.Text.Trim()))
                                {
                                    // 設定値保存、名称のクリア
                                    stockQuoteData.AfSectionCode = string.Empty;
                                    stockQuoteData.AfSectionName = string.Empty;

                                    // フォーカス設定
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.AfSectionGuide_Button;
                                    }

                                    break;
                                }

                                if (!string.IsNullOrEmpty(GetSectionName(code)))
                                {
                                    // 結果を画面に設定
                                    stockQuoteData.AfSectionCode = code;
                                    stockQuoteData.AfSectionName = GetSectionName(code);
                                }
                                else
                                {
                                    // 該当なし
                                    TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                                    emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                                    this.Name,											// アセンブリID
                                                    "マスタに存在しません。", // 表示するメッセージ
                                                    -1,													// ステータス値
                                                    MessageBoxButtons.OK);           					// 表示するボタン
                                    // 画面表示
                                    this.SetDisplay(stockQuoteData);
                                    // ↓ 2009.07.07 劉洋 modify PVCS NO.307
                                    // フォーカス設定
                                    // e.NextCtrl = this.AfSectionGuide_Button;
                                    e.NextCtrl = e.PrevCtrl;
                                    // ↑ 2009.07.07 劉洋 modify
                                    return;
                                }

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    if (this.tEdit_AfCustRateGrpCode.Enabled)
                                    {
                                        e.NextCtrl = this.tEdit_AfCustRateGrpCode;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tNedit_AfCustomerCode;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(code))
                            {
                                code = "00";
                                stockQuoteData.AfSectionCode = code;
                                stockQuoteData.AfSectionName = GetSectionName(code);
                            }

                            // 入力変更なし
                            if (code.Equals(stockQuoteData.AfSectionCode))
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    if (!this.tNedit_BfCustomerCode.Enabled)
                                    {
                                        if (!string.IsNullOrEmpty(this.tEdit_BfCustRateGrpCode.DataText))
                                        {
                                            e.NextCtrl = this.tEdit_BfCustRateGrpCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.BfCustRateGrpGuide_Button;
                                        }
                                    }
                                    else
                                    {
                                        if (this.tNedit_BfCustomerCode.GetInt() != 0)
                                        {
                                            e.NextCtrl = this.tNedit_BfCustomerCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.BfCustomerCodeGuide_Button;
                                        }
                                    }
                                }

                                break;
                            }
                            else
                            {
                                // 入力無し
                                if (string.IsNullOrEmpty(this.tEdit_AfSectionCode.Text.Trim()))
                                {
                                    // 設定値保存、名称のクリア
                                    stockQuoteData.AfSectionCode = string.Empty;
                                    stockQuoteData.AfSectionName = string.Empty;

                                    // フォーカス設定
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        if (!this.tNedit_BfCustomerCode.Enabled)
                                        {
                                            if (!string.IsNullOrEmpty(this.tEdit_BfCustRateGrpCode.DataText))
                                            {
                                                e.NextCtrl = this.tEdit_BfCustRateGrpCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.BfCustRateGrpGuide_Button;
                                            }
                                        }
                                        else
                                        {
                                            if (this.tNedit_BfCustomerCode.GetInt() != 0)
                                            {
                                                e.NextCtrl = this.tNedit_BfCustomerCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.BfCustomerCodeGuide_Button;
                                            }
                                        }
                                    }

                                    break;
                                }

                                if (!string.IsNullOrEmpty(GetSectionName(code)))
                                {
                                    // 結果を画面に設定
                                    stockQuoteData.AfSectionCode = code;
                                    stockQuoteData.AfSectionName = GetSectionName(code);
                                }
                                else
                                {
                                    // 該当なし
                                    TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                                    emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                                    this.Name,											// アセンブリID
                                                    "マスタに存在しません。", // 表示するメッセージ
                                                    -1,													// ステータス値
                                                    MessageBoxButtons.OK);           					// 表示するボタン
                                    // 画面表示
                                    this.SetDisplay(stockQuoteData);
                                    // ↓ 2009.07.07 劉洋 modify PVCS NO.307
                                    // フォーカス設定
                                    // e.NextCtrl = this.AfSectionGuide_Button;
                                    e.NextCtrl = e.PrevCtrl;
                                    // ↑ 2009.07.07 劉洋 modify
                                    return;
                                }

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    if (!this.tNedit_BfCustomerCode.Enabled)
                                    {
                                        if (!string.IsNullOrEmpty(this.tEdit_BfCustRateGrpCode.DataText))
                                        {
                                            e.NextCtrl = this.tEdit_BfCustRateGrpCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.BfCustRateGrpGuide_Button;
                                        }
                                    }
                                    else
                                    {
                                        if (this.tNedit_BfCustomerCode.GetInt() != 0)
                                        {
                                            e.NextCtrl = this.tNedit_BfCustomerCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.BfCustomerCodeGuide_Button;
                                        }
                                    }
                                }
                            }
                        }

                        break;
                    }
                // 引用先拠点ボタン
                case "AfSectionGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                if (this.tEdit_AfCustRateGrpCode.Enabled)
                                {
                                    e.NextCtrl = this.tEdit_AfCustRateGrpCode;
                                }
                                else
                                {
                                    e.NextCtrl = this.tNedit_AfCustomerCode;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.tEdit_AfSectionCode;
                            }
                        }
                        break;
                    }
                // 引用先得意先掛率グループ
                case "tEdit_AfCustRateGrpCode":
                    {
                        if (_custRateGrpDic == null)
                        {
                            GetCustRateGrp();
                        }

                        string value = this.tEdit_AfCustRateGrpCode.Text.Trim();
                        // 入力正確性判断
                        bool inputFlg = true;
                        for (int i = 0; i < value.Length; i++)
                        {
                            if (!char.IsNumber(value, i))
                            {
                                inputFlg = false;
                                break;
                            }
                        }

                        if (e.ShiftKey == false)
                        {
                            // 引用元得意先掛率グループ
                            if (this.tEdit_AfCustRateGrpCode.DataText.Trim() == "" || !inputFlg)
                            {
                                this.tEdit_AfCustRateGrpCode.Clear();
                                // クリア
                                stockQuoteData.AfCustRateGrpCode = 0;
                                stockQuoteData.AfCustRateGrpName = string.Empty;

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // フォーカス
                                    e.NextCtrl = this.AfCustRateGrpGuide_Button;
                                }

                                this.SetDisplay(stockQuoteData);

                                this._rateQuoteInputAcs.CacheStockQuoteData(stockQuoteData);

                                return;
                            }

                            reReadFlg = true;

                            // 入力コード
                            int code = Convert.ToInt32(this.tEdit_AfCustRateGrpCode.Text.ToString());

                            // 入力変更なし
                            if (code == stockQuoteData.AfCustRateGrpCode && !string.IsNullOrEmpty(stockQuoteData.AfCustRateGrpName))
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                        if (code == 0 && string.IsNullOrEmpty(stockQuoteData.AfCustRateGrpName))
                                        {
                                            e.NextCtrl = this.AfCustRateGrpGuide_Button;
                                        }
                                        else
                                        {
                                            if (this.tNedit_AfCustomerCode.Enabled)
                                            {
                                                e.NextCtrl = this.tNedit_AfCustomerCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.ObjectDistinction_tComEditor;
                                            }
                                        }
                                    }
                                }

                                break;
                            }
                            else
                            {

                                if (!string.IsNullOrEmpty(GetCustRateGrpName(code)))
                                {
                                    // 結果を画面に設定
                                    stockQuoteData.AfCustRateGrpCode = code;
                                    stockQuoteData.AfCustRateGrpName = GetCustRateGrpName(code);
                                }
                                else
                                {
                                    // 該当なし
                                    TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                                    emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                                    this.Name,											// アセンブリID
                                                    "マスタに存在しません。", // 表示するメッセージ
                                                    -1,													// ステータス値
                                                    MessageBoxButtons.OK);           					// 表示するボタン
                                    // 画面表示
                                    this.SetDisplay(stockQuoteData);
                                    // ↓ 2009.07.07 劉洋 modify PVCS NO.307
                                    // フォーカス設定
                                    // e.NextCtrl = this.AfCustRateGrpGuide_Button;
                                    e.NextCtrl = e.PrevCtrl;
                                    // ↑ 2009.07.07 劉洋
                                    return;
                                }

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.ObjectDistinction_tComEditor;
                                }
                            }
                        }
                        else
                        {
                            // 引用元得意先掛率グループ
                            if (this.tEdit_AfCustRateGrpCode.DataText.Trim() == "" || !inputFlg)
                            {
                                this.tEdit_AfCustRateGrpCode.Clear();
                                // クリア
                                stockQuoteData.AfCustRateGrpCode = 0;
                                stockQuoteData.AfCustRateGrpName = string.Empty;

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // フォーカス
                                    e.NextCtrl = this.tEdit_AfSectionCode;
                                }

                                this.SetDisplay(stockQuoteData);

                                this._rateQuoteInputAcs.CacheStockQuoteData(stockQuoteData);

                                return;
                            }

                            reReadFlg = true;

                            // 入力コード
                            int code = Convert.ToInt32(this.tEdit_AfCustRateGrpCode.Text.ToString());

                            // 入力変更なし
                            if (code == stockQuoteData.AfCustRateGrpCode && !string.IsNullOrEmpty(stockQuoteData.AfCustRateGrpName))
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.tEdit_AfSectionCode;
                                    }
                                }

                                break;
                            }
                            else
                            {

                                if (!string.IsNullOrEmpty(GetCustRateGrpName(code)))
                                {
                                    // 結果を画面に設定
                                    stockQuoteData.AfCustRateGrpCode = code;
                                    stockQuoteData.AfCustRateGrpName = GetCustRateGrpName(code);
                                }
                                else
                                {
                                    // 該当なし
                                    TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                                    emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                                    this.Name,											// アセンブリID
                                                    "マスタに存在しません。", // 表示するメッセージ
                                                    -1,													// ステータス値
                                                    MessageBoxButtons.OK);           					// 表示するボタン
                                    // 画面表示
                                    this.SetDisplay(stockQuoteData);
                                    // ↓ 2009.07.07 劉洋 modify PVCS NO.307
                                    // フォーカス設定
                                    // e.NextCtrl = this.AfCustRateGrpGuide_Button;
                                    e.NextCtrl = e.PrevCtrl;
                                    // ↑ 2009.07.07 劉洋
                                    return;
                                }

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tEdit_AfSectionCode;
                                }
                            }
                        }

                        break;
                    }
                // 引用元得意先掛率グループ
                case "AfCustRateGrpGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                if (this.tNedit_AfCustomerCode.Enabled)
                                {
                                    e.NextCtrl = this.tNedit_AfCustomerCode;
                                }
                                else
                                {
                                    e.NextCtrl = this.ObjectDistinction_tComEditor;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.tEdit_AfCustRateGrpCode;
                            }
                        }
                        break;
                    }
                // 引用先得意先コード
                case "tNedit_AfCustomerCode":
                    {
                        // 得意先検索
                        if (_customerSearchRetDic == null)
                        {
                            LoadCustomerSearchRet();
                        }

                        // 入力コード
                        int code = this.tNedit_AfCustomerCode.GetInt();

                        if (e.ShiftKey == false)
                        {
                            // 入力変更なし
                            if (code == stockQuoteData.AfCustomerCode)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    if (code == 0)
                                    {
                                        e.NextCtrl = this.AfCustomerCodeGuide_Button;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.ObjectDistinction_tComEditor;
                                    }
                                }

                                break;
                            }
                            else
                            {
                                // 入力無し
                                if (code == 0)
                                {
                                    // 設定値保存、名称のクリア
                                    stockQuoteData.AfCustomerCode = 0;
                                    stockQuoteData.AfCustomerName = string.Empty;

                                    // フォーカス設定
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.AfCustomerCodeGuide_Button;
                                    }

                                    break;
                                }

                                if (!string.IsNullOrEmpty(GetCustomerName(code)))
                                {
                                    // 結果を画面に設定
                                    stockQuoteData.AfCustomerCode = code;
                                    stockQuoteData.AfCustomerName = GetCustomerName(code);
                                }
                                else
                                {
                                    // 該当なし
                                    TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                                    emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                                    this.Name,											// アセンブリID
                                                    "マスタに存在しません。", // 表示するメッセージ
                                                    -1,													// ステータス値
                                                    MessageBoxButtons.OK);           					// 表示するボタン
                                    // 画面表示
                                    this.SetDisplay(stockQuoteData);
                                    // ↓ 2009.07.07 劉洋 modify PVCS NO.307
                                    // フォーカス設定
                                    // e.NextCtrl = this.AfCustomerCodeGuide_Button;
                                    e.NextCtrl = e.PrevCtrl;
                                    // ↑ 2009.07.07 劉洋 modify
                                    return;
                                }

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.ObjectDistinction_tComEditor;
                                }
                            }
                        }
                        else
                        {
                            if (code == stockQuoteData.AfCustomerCode)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    if (!this.tEdit_AfCustRateGrpCode.Enabled)
                                    {
                                        e.NextCtrl = this.tEdit_AfSectionCode;
                                    }
                                    else
                                    {
                                        if (string.IsNullOrEmpty(this.tEdit_AfCustRateGrpCode.DataText))
                                        {
                                            e.NextCtrl = this.AfCustRateGrpGuide_Button;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_AfCustRateGrpCode;
                                        }
                                    }
                                }

                                break;
                            }
                            else
                            {
                                // 入力無し
                                if (code == 0)
                                {
                                    // 設定値保存、名称のクリア
                                    stockQuoteData.AfCustomerCode = 0;
                                    stockQuoteData.AfCustomerName = string.Empty;

                                    // フォーカス設定
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        if (this.tEdit_AfCustRateGrpCode.Enabled)
                                        {
                                            if (string.IsNullOrEmpty(this.tEdit_AfCustRateGrpCode.DataText))
                                            {
                                                e.NextCtrl = this.AfCustRateGrpGuide_Button;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_AfCustRateGrpCode;
                                            }
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_AfSectionCode;
                                        }
                                    }

                                    break;
                                }

                                if (!string.IsNullOrEmpty(GetCustomerName(code)))
                                {
                                    // 結果を画面に設定
                                    stockQuoteData.AfCustomerCode = code;
                                    stockQuoteData.AfCustomerName = GetCustomerName(code);
                                }
                                else
                                {
                                    // 該当なし
                                    TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                                    emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                                    this.Name,											// アセンブリID
                                                    "マスタに存在しません。", // 表示するメッセージ
                                                    -1,													// ステータス値
                                                    MessageBoxButtons.OK);           					// 表示するボタン
                                    // 画面表示
                                    // ↓ 2009.07.07 劉洋 modify PVCS NO.307
                                    this.SetDisplay(stockQuoteData);
                                    // フォーカス設定
                                    // e.NextCtrl = this.AfCustomerCodeGuide_Button;
                                    e.NextCtrl = e.PrevCtrl;
                                    // ↑ 2009.07.07 劉洋 modify
                                    return;
                                }

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    if (this.tEdit_AfCustRateGrpCode.Enabled)
                                    {
                                        if (string.IsNullOrEmpty(this.tEdit_AfCustRateGrpCode.DataText))
                                        {
                                            e.NextCtrl = this.AfCustRateGrpGuide_Button;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_AfCustRateGrpCode;
                                        }
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_AfSectionCode;
                                    }
                                }
                            }
                        }

                        break;
                    }
                // 引用先得意先ボタン
                case "AfCustomerCodeGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.ObjectDistinction_tComEditor;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.tNedit_AfCustomerCode;
                            }
                        }
                        break;
                    }
                // 対象区分
                case "ObjectDistinction_tComEditor":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.UpdateDistinction_tComEditor;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                if (this.tNedit_AfCustomerCode.Enabled)
                                {
                                    if (this.tNedit_AfCustomerCode.GetInt() != 0)
                                    {
                                        e.NextCtrl = this.tNedit_AfCustomerCode;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.AfCustomerCodeGuide_Button;
                                    }
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(this.tEdit_AfCustRateGrpCode.DataText))
                                    {
                                        e.NextCtrl = this.tEdit_AfCustRateGrpCode;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.AfCustRateGrpGuide_Button;
                                    }
                                }
                            }
                        }
                        break;
                    }
                // 更新区分
                case "UpdateDistinction_tComEditor":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.tEdit_BfSectionCode;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.ObjectDistinction_tComEditor;
                            }
                        }
                        break;
                    }
            }

            // メモリ上の内容と比較する
            ArrayList arRetList = stockQuoteData.Compare(stockQuoteDataCurrent);

            if (arRetList.Count > 0 || reReadFlg)
            {
                this._rateQuoteInputAcs.CacheStockQuoteData(stockQuoteData);

                // 画面表示
                this.SetDisplay(stockQuoteData);
            }
        }

        /// <summary>
        /// Control.Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void BfCustRateGrpGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_custRateGrpDic == null)
                {
                    GetCustRateGrp();
                }

                // キャッシュ処理
                StockQuoteData stockQuoteData = this._rateQuoteInputAcs.StockQuoteData;

                int status;

                UserGdHd userGdHd;
                UserGdBd userGdBd;

                status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 43);
                if (status == 0)
                {
                    stockQuoteData.BfCustRateGrpCode = userGdBd.GuideCode;
                    stockQuoteData.BfCustRateGrpName = this.GetCustRateGrpName(userGdBd.GuideCode);

                    // フォーカス設定
                    this.tEdit_AfSectionCode.Focus();

                    // 画面再表示
                    this.SetDisplay(stockQuoteData);

                    // キャッシュ処理
                    this._rateQuoteInputAcs.CacheStockQuoteData(stockQuoteData);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void BfSectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // キャッシュ処理
                StockQuoteData stockQuoteData = this._rateQuoteInputAcs.StockQuoteData;

                int status;
                SecInfoSet secInfoSet = new SecInfoSet();

                // 拠点ガイド表示
                status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == 0)
                {
                    if (secInfoSet.SectionCode.Trim() != stockQuoteData.BfSectionCode)
                    {
                        // 拠点コード
                        stockQuoteData.BfSectionCode = secInfoSet.SectionCode.Trim();

                        // 拠点名称
                        stockQuoteData.BfSectionName = secInfoSet.SectionGuideNm.Trim();

                        // 画面再表示
                        this.SetDisplay(stockQuoteData);

                        // キャッシュ処理
                        this._rateQuoteInputAcs.CacheStockQuoteData(stockQuoteData);
                    }

                    // フォーカス設定
                    if (this.tEdit_BfCustRateGrpCode.Enabled)
                    {
                        this.tEdit_BfCustRateGrpCode.Focus();
                    }
                    else
                    {
                        this.tNedit_BfCustomerCode.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        /// <summary>
        /// Control.Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void BfCustomerNameGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 得意先検索
                if (_customerSearchRetDic == null)
                {
                    LoadCustomerSearchRet();
                }

                BfFocusFlg = false;

                // 得意先ガイド
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.BfCustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                if (BfFocusFlg)
                {
                    // フォーカス設定
                    this.tEdit_AfSectionCode.Focus();
                }

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void BfCustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            BfFocusFlg = true;

            // キャッシュ処理
            StockQuoteData stockQuoteData = this._rateQuoteInputAcs.StockQuoteData;

            if (customerSearchRet.CustomerCode != stockQuoteData.BfCustomerCode)
            {
                // 得意先コード
                stockQuoteData.BfCustomerCode = customerSearchRet.CustomerCode;

                // 得意先名称
                stockQuoteData.BfCustomerName = customerSearchRet.Snm.Trim();

                // 画面再表示
                this.SetDisplay(stockQuoteData);

                // キャッシュ処理
                this._rateQuoteInputAcs.CacheStockQuoteData(stockQuoteData);
            }
        }


        /// <summary>
        /// Control.Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void AfSectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // キャッシュ処理
                StockQuoteData stockQuoteData = this._rateQuoteInputAcs.StockQuoteData;

                int status;
                SecInfoSet secInfoSet = new SecInfoSet();

                // 拠点ガイド表示
                status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == 0)
                {
                    if (secInfoSet.SectionCode.Trim() != stockQuoteData.AfSectionCode)
                    {
                        // 拠点コード
                        stockQuoteData.AfSectionCode = secInfoSet.SectionCode.Trim();

                        // 拠点名称
                        stockQuoteData.AfSectionName = secInfoSet.SectionGuideNm.Trim();

                        // 画面再表示
                        this.SetDisplay(stockQuoteData);

                        // キャッシュ処理
                        this._rateQuoteInputAcs.CacheStockQuoteData(stockQuoteData);
                    }

                    // フォーカス設定
                    if (this.tEdit_AfCustRateGrpCode.Enabled)
                    {
                        this.tEdit_AfCustRateGrpCode.Focus();
                    }
                    else
                    {
                        this.tNedit_AfCustomerCode.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        /// <summary>
        /// Control.Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void AfCustRateGrpGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_custRateGrpDic == null)
                {
                    GetCustRateGrp();
                }

                // キャッシュ処理
                StockQuoteData stockQuoteData = this._rateQuoteInputAcs.StockQuoteData;

                int status;

                UserGdHd userGdHd;
                UserGdBd userGdBd;

                status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 43);
                if (status == 0)
                {
                    stockQuoteData.AfCustRateGrpCode = userGdBd.GuideCode;
                    stockQuoteData.AfCustRateGrpName = this.GetCustRateGrpName(userGdBd.GuideCode);

                    // フォーカス設定
                    this.ObjectDistinction_tComEditor.Focus();

                    // 画面再表示
                    this.SetDisplay(stockQuoteData);

                    // キャッシュ処理
                    this._rateQuoteInputAcs.CacheStockQuoteData(stockQuoteData);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void AfCustomerNameGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 得意先検索
                if (_customerSearchRetDic == null)
                {
                    LoadCustomerSearchRet();
                }

                AfFocusFlg = false;

                // 得意先ガイド
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.AfCustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                if (AfFocusFlg)
                {
                    // フォーカス設定
                    this.ObjectDistinction_tComEditor.Focus();
                }

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void AfCustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            AfFocusFlg = true;

            // キャッシュ処理
            StockQuoteData stockQuoteData = this._rateQuoteInputAcs.StockQuoteData;

            if (customerSearchRet.CustomerCode != stockQuoteData.AfCustomerCode)
            {
                // 得意先コード
                stockQuoteData.AfCustomerCode = customerSearchRet.CustomerCode;

                // 得意先名称
                stockQuoteData.AfCustomerName = customerSearchRet.Snm.Trim();

                // 画面再表示
                this.SetDisplay(stockQuoteData);

                // キャッシュ処理
                this._rateQuoteInputAcs.CacheStockQuoteData(stockQuoteData);
            }
        }

        /// <summary>
        /// フォーカス設定
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">クラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void timer_SetFocus_Tick(object sender, EventArgs e)
        {
            // フォーカス設定
            this.tEdit_BfSectionCode.Focus();

            this.timer_SetFocus.Enabled = false;
        }

        /// <summary>
        /// 対象区分設定
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">クラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void ObjectDistinction_tComEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this.ObjectDistinction_tComEditor.Value != null)
            {
                // キャッシュ処理
                StockQuoteData stockQuoteData = this._rateQuoteInputAcs.StockQuoteData;

                // 画面値
                stockQuoteData.ObjectDistinctionCode = (int)this.ObjectDistinction_tComEditor.Value;

                this._rateQuoteInputAcs.CacheStockQuoteData(stockQuoteData);
            }
        }

        /// <summary>
        /// 更新区分設定
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">クラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void UpdateDistinction_tComEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this.UpdateDistinction_tComEditor.Value != null)
            {
                // キャッシュ処理
                StockQuoteData stockQuoteData = this._rateQuoteInputAcs.StockQuoteData;

                // 画面値
                stockQuoteData.UpdateDistinctionCode = (int)this.UpdateDistinction_tComEditor.Value;

                this._rateQuoteInputAcs.CacheStockQuoteData(stockQuoteData);
            }
        }

        /// <summary>
        /// 得意先掛率グループ設定
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">クラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void tEdit_AfCustRateGrpCode_Enter(object sender, EventArgs e)
        {
            if (!_setDisplayFlg)
            {
                if (this.tEdit_AfCustRateGrpCode.DataText == "")
                {
                    return;
                }

                int code = Convert.ToInt32(this.tEdit_AfCustRateGrpCode.DataText.ToString());

                this.tEdit_AfCustRateGrpCode.DataText = code.ToString();
            }
        }

        /// <summary>
        /// 得意先掛率グループ設定
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">クラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void tEdit_BfCustRateGrpCode_Enter(object sender, EventArgs e)
        {
            if (!_setDisplayFlg)
            {
                if (this.tEdit_BfCustRateGrpCode.DataText == "")
                {
                    return;
                }

                int code = Convert.ToInt32(this.tEdit_BfCustRateGrpCode.DataText.ToString());

                this.tEdit_BfCustRateGrpCode.DataText = code.ToString();
            }
        }
        #endregion

        private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "BfSettingGroup") ||
                (e.Group.Key == "AfSettingGroup") ||
                (e.Group.Key == "DetailSettingGroup") ||
                (e.Group.Key == "ResultSettingGroup"))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }

        private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "BfSettingGroup") ||
                (e.Group.Key == "AfSettingGroup") ||
                (e.Group.Key == "DetailSettingGroup") ||
                (e.Group.Key == "ResultSettingGroup"))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }
    }
}