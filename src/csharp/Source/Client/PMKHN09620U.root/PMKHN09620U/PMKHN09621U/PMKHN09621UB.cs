//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン対象商品設定マスタ
// プログラム概要   : キャンペーン対象商品設定マスタを行う
//----------------------------------------------------------------------------//
//                (c)Copyright 2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10701342-00 作成担当 : 曹文傑
// 作 成 日  2011/04/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 譚洪
// 修 正 日  2011/07/06  修正内容 : Redmine#22776 キャンペーン対象商品設定マスタ／追加行の対応
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 譚洪
// 修 正 日  2011/07/07  修正内容 : Redmine#22810 ①明細項目の幅・文字サイズは変更時に保存の対応
//                                                ②明細”メーカー名称”から”カナ名称”に変更の対応
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 譚洪
// 修 正 日  2011/07/06  修正内容 : Redmine#22776 行追加の得意先のチェックに関しての修正
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 曹文傑
// 修 正 日  2011/07/12  修正内容 : Redmine#22919 ①初回起動時の文字サイズと項目幅の変更
//                                                ②明細のキャンペーンコードに初期表示するように変更
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 曹文傑
// 修 正 日  2011/07/14  修正内容 : Redmine#22962 拠点違いで登録可能にするように変更対応
//                                  Redmine#22957 対象得意先に設定している場合、全得意先が入力できる
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 曹文傑
// 修 正 日  2011/07/14  修正内容 : Redmine#22984 最終行の情報がデータ登録されない
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 曹文傑
// 修 正 日  2011/07/15  修正内容 : Redmine#22984 売価区分を異なる設定にすると、同一商品設定を重複チェック
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 曹文傑
// 修 正 日  2011/07/21  修正内容 : Redmine#23119 最終明細行でのフォーカス遷移不正の修正
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 譚洪
// 修 正 日  2011/07/22  修正内容 : Redmine#23119 提供優良品番の品名が空白のものがありますの対応
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 鄧潘ハン
// 修 正 日  2011/09/05  修正内容 : Redmine#23965 キャンペーン管理　売上伝票入力（Delphi）の変更時の調査の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 陳健
// 修 正 日  2014/03/20  修正内容 : Redmine#42174 更新日Column追加の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;   // ADD 2011/07/07 
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;  // ADD 2011/07/07 
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// キャンペーン対象商品設定マスタ 明細コントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン対象商品設定マスタ 明細コントロールクラス</br>
    /// <br>Programmer : 曹文傑</br>
    /// <br>Date       : 2011/04/26</br>
    /// <br>UpdateNote : 2011/07/06 譚洪 Redmine#22776 キャンペーン対象商品設定マスタ／追加行の対応</br>
    /// <br>UpdateNote : 2011/07/07 譚洪 Redmine#22810 ①明細項目の幅・文字サイズは変更時に保存の対応</br>
    /// <br>                                           ②明細”メーカー名称”から”カナ名称”に変更の対応</br>
    /// <br>UpdateNote : 2011/07/11 譚洪 Redmine#22776 行追加の得意先のチェックに関しての修正</br>
    /// <br>UpdateNote : 2011/07/12 曹文傑 Redmine#22919 ①初回起動時の文字サイズと項目幅の変更</br>
    /// <br>　　　　　　　　　　　　　　　　　　　　　 ②明細のキャンペーンコードに初期表示するように変更</br>
    /// <br>UpdateNote : 2011/07/14 曹文傑 Redmine#22962 拠点違いで登録可能にするように変更対応</br>
    /// <br>UpdateNote : 2011/07/14 曹文傑 Redmine#22984 最終行の情報がデータ登録されない</br>
    /// <br>UpdateNote : 2011/07/15 曹文傑 Redmine#22984 売価区分を異なる設定にすると、同一商品設定を重複チェック</br>
    /// <br>UpdateNote : 2011/07/21 譚洪 Redmine#23119 最終明細行でのフォーカス遷移不正の修正</br>
    /// <br>UpdateNote : 2011/07/22 譚洪 Redmine#23119 提供優良品番の品名が空白のものがありますの対応</br>
    /// <br>UpdateNote : 2011/09/05 鄧潘ハン Redmine#23965 キャンペーン管理　売上伝票入力（Delphi）の変更時の調査の対応</br>
    /// </remarks>
    public partial class PMKHN09621UB : UserControl
    {
        # region Private Members
        private CampaignMngDataSet.CampaignMngDataTable _campaignMngDataTable;
        private CampaignObjGoodsStAcs _campaignObjGoodsStAcs = null;
        private Dictionary<Guid, CampaignObjGoodsSt> _prevCampaignMngDic = new Dictionary<Guid, CampaignObjGoodsSt>();

        private static readonly Color ct_DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color ct_DISABLE_FONT_COLOR = Color.Black;
        private static readonly Color ct_READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));

        private const string TOOLBAR_ROWDELETEBUTTON_KEY = "ButtonTool_RowDelete";						// 行削除
        private const string TOOLBAR_ALLDELETEBUTTON_KEY = "ButtonTool_AllRowDelete";					// 全削除
        private const string TOOLBAR_REVIVALBUTTON_KEY = "ButtonTool_Revival";						    // 復活
        private const string TOOLBAR_GETPRICEBUTTON_KEY = "ButtonTool_GetPriceDate";					// 価格日取得

        /// <summary>設定XMLファイル名</summary>
        private const string XML_FILE_NAME = "PMKHN09620U_Construction.XML";   // ADD 2011/07/07 

        /// <summary>企業コード</summary>
        private string _enterpriseCode = string.Empty;
        private string _loginSectionCode = string.Empty;
        /// <summary>BLコード</summary>
        private int _swBLGoodsCode = 0;
        /// <summary>品番</summary>
        private string _swGoodsNo = string.Empty;
        /// <summary>メーカーコード</summary>
        private int _swGoodsMakerCd = 0;

        private string _swSectionCode = "00";
        private int _swBLGroupU = 0;
        private string _swUserGdBd = string.Empty;
        private string _swCustomerInfo = string.Empty;
        private int _swCampaignCd = 0;

        private CustomerSearchRet _customerSearchRet = null;

        /// <summary>DCKHN09092A)BLコード</summary>
        private BLGoodsCdAcs _blGoodsCdAcs;

        private bool focusFlg = true;
        private bool leftFocusFlg = false;    // ADD 2011/07/07 

        // ユーザー設定
        private CampaignMngUserSet _userSetting; // ADD 2011/07/07 

        private CampaignLinkAcs _campaignLinkAcs;
        private SecInfoSetAcs _secInfoSetAcs;
        private MakerAcs _makerAcs;
        private BLGroupUAcs _blGroupUAcs;
        private UserGuideAcs _userGuideAcs;

        internal event SetGuidButtonEventHandler SetGuidButton;
        internal delegate void SetGuidButtonEventHandler(Boolean enable);

        // ---ADD 2011/07/12--------------->>>>>
        internal event GetCampaignInfoEventHandler GetCampaignInfo;
        internal delegate void GetCampaignInfoEventHandler(out string campaignCode, out string campaignName, out string sectionCode);
        // ---ADD 2011/07/12---------------<<<<<

        /// <summary>フォーカスの変化</summary>
        internal event EventHandler GridKeyUpTopRow;
        #endregion

        #region プロパティ
        /// <summary>
        /// キャンペーン対象商品設定マスタ アクセスクラスプロパティ
        /// </summary>
        public CampaignObjGoodsStAcs CampaignObjGoodsStAcs
        {
            get { return this._campaignObjGoodsStAcs; }
        }
        /// <summary>
        /// 明細部にフォーカスありプロパティ
        /// </summary>
        public Boolean FocusFlg
        {
            get { return this.focusFlg; }
        }

        // ----- ADD 2011/07/07 ------- <<<<<<<<<
        /// <summary>
        /// 明細部にフォーカスありプロパティ
        /// </summary>
        public Boolean LeftFocusFlg
        {
            set { this.leftFocusFlg = value; }
        }

        /// <summary>
        /// ユーザのプロパティ
        /// </summary>
        public CampaignMngUserSet UserSetting
        {
            get { return this._userSetting; }
        }
        // ----- ADD 2011/07/07 ------- <<<<<<<<<
        #endregion

        # region Constroctors
        /// <summary>
        /// 入力明細入力コントロールクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入力明細入力コントロールクラス デフォルトを行うコントロールクラスです。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/07 譚洪 Redmine#22810 明細項目の幅・文字サイズは変更時に保存の対応</br>
        /// </remarks>
        public PMKHN09621UB()
        {
            InitializeComponent();
            this._campaignObjGoodsStAcs = new CampaignObjGoodsStAcs();
            this._campaignMngDataTable = this._campaignObjGoodsStAcs.CampaignMngDataTable;

            // 企業コード
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._campaignLinkAcs = new CampaignLinkAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._makerAcs = new MakerAcs();
            this._blGroupUAcs = new BLGroupUAcs();
            this._userGuideAcs = new UserGuideAcs();

            this._userSetting = new CampaignMngUserSet();  // ADD 2011/07/07 
        }
        #endregion

        #region イベント
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note	   : フォームが読み込まれた時に発生します。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void PMKHN09621UB_Load(object sender, EventArgs e)
        {
            // データソースとしてデータビューを指定
            this.uGrid_Details.DataSource = this._campaignObjGoodsStAcs.CampaignMngDataTable;

            // グリッドクリア
            this.Clear(false);
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note	   : フォームが読み込まれた時に発生します。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 行削除
                case TOOLBAR_ROWDELETEBUTTON_KEY:
                    {
                        this.uButton_RowDelete_Click(sender, new EventArgs());
                        break;
                    }
                // 全削除
                case TOOLBAR_ALLDELETEBUTTON_KEY:
                    {
                        this.uButton_AllRowDelete_Click(sender, new EventArgs());
                        break;
                    }
                // 復活
                case TOOLBAR_REVIVALBUTTON_KEY:
                    {
                        this.uButton_Revival_Click(sender, new EventArgs());
                        break;
                    }
                // 価格日取得
                case TOOLBAR_GETPRICEBUTTON_KEY:
                    {
                        this.uButton_GetPriceDate_Click(sender, new EventArgs());
                        break;
                    }
            }
        }

        /// <summary>
        /// 明細初期化イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note	   : 明細初期化イベントします。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.uGrid_Details.BeginUpdate();

            // グリッド列初期設定処理
            this.InitialSettingGridCol();

            this.uGrid_Details.EndUpdate();
        }

        /// <summary>
        /// 行削除処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 行削除処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void uButton_RowDelete_Click(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null)
            {
                return;
            }

            try
            {
                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                this.Cursor = Cursors.WaitCursor;

                this.uGrid_Details.BeginUpdate();

                foreach (UltraGridRow row in this.uGrid_Details.Rows)
                {
                    if (row.Selected || row.IsActiveRow)
                    {
                        if ((int)row.Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value != 1)
                        {
                            //削除指定区分:0
                            if (this._campaignObjGoodsStAcs.DeleteSearchMode == false)
                            {
                                if (this.uGrid_Details.ActiveCell != null)
                                {
                                    this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
                                    this.SetGuidButton(false);
                                }

                                // 行削除時BackColorの設定(ピンク色)、入力許可設定
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    cell.Appearance.BackColor = Color.Pink;
                                    cell.Appearance.BackColor2 = Color.Pink;
                                    cell.Appearance.BackColorDisabled = Color.Pink;
                                    cell.Appearance.BackColorDisabled2 = Color.Pink;
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;

                                    cell.Activation = Activation.NoEdit;
                                }
                                row.Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value = 1;
                            }
                            //削除指定区分:1
                            else
                            {
                                // 行削除時BackColorの設定(ピンク色)、入力許可設定
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    cell.Appearance.BackColor = Color.Pink;
                                    cell.Appearance.BackColor2 = Color.Pink;
                                    cell.Appearance.BackColorDisabled = Color.Pink;
                                    cell.Appearance.BackColorDisabled2 = Color.Pink;
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                }
                                row.Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value = 1;
                            }
                        }
                        else
                        {
                            //削除指定区分:0
                            if (this._campaignObjGoodsStAcs.DeleteSearchMode == false)
                            {
                                #region 行削除解除
                                // 新規行の判断
                                bool isNewRow = false;

                                if ((Guid)row.Cells[this._campaignMngDataTable.FilterGuidColumn.ColumnName].Value == Guid.Empty)
                                {
                                    isNewRow = true;
                                }

                                #region 入力許可設定
                                row.Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                row.Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Activation = Activation.AllowEdit;
                                if (isNewRow == true)
                                {
                                    row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                    row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Activation = Activation.AllowEdit;
                                }
                                switch ((int)row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Value)
                                {
                                    case 1:
                                        {
                                            row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                            row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.AllowEdit;
                                            break;
                                        }
                                    case 2:
                                        {
                                            row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                            row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                            break;
                                        }
                                    case 3:
                                        {
                                            row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                            row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                            break;
                                        }
                                    case 4:
                                        {
                                            row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                            break;
                                        }
                                    case 5:
                                        {
                                            row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                            break;
                                        }
                                    case 6:
                                        {
                                            row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                            break;
                                        }
                                }
                                if ((int)row.Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Value == 1)
                                {
                                    row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                    row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Activation = Activation.AllowEdit;
                                    if ((int)row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Value == 1)
                                    {
                                        row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Activation = Activation.AllowEdit;
                                    }
                                    row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Activation = Activation.AllowEdit;
                                    row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Activation = Activation.AllowEdit;
                                    row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Activation = Activation.AllowEdit;
                                }
                                #endregion

                                // 行削除解除時BackColorの設定(通常色)
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    if (cell.Activation == Activation.NoEdit
                                        && cell.Column.Key != this._campaignMngDataTable.RowNoColumn.ColumnName)
                                    {
                                        cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                                        cell.Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                                        cell.Appearance.BackColorDisabled = ct_READONLY_CELL_COLOR;
                                        cell.Appearance.BackColorDisabled2 = ct_READONLY_CELL_COLOR;
                                    }
                                    else
                                    {
                                        cell.Appearance.BackColor = Color.Empty;
                                        cell.Appearance.BackColor2 = Color.Empty;
                                        cell.Appearance.BackColorDisabled = Color.Empty;
                                        cell.Appearance.BackColorDisabled2 = Color.Empty;
                                    }
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                }

                                if (this.uGrid_Details.ActiveCell != null)
                                {
                                    this.uGrid_Details.ActiveCell.Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    if (this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.CampaignCodeColumn.ColumnName
                                        || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.SectionCodeColumn.ColumnName
                                        || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName
                                        || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName
                                        || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.BLGroupCodeColumn.ColumnName
                                        || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.SalesCodeColumn.ColumnName
                                        || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.CustomerCodeColumn.ColumnName)
                                    {
                                        if (this.uGrid_Details.ActiveCell.Activation == Activation.AllowEdit)
                                        {
                                            this.SetGuidButton(true);
                                        }
                                        else
                                        {
                                            this.SetGuidButton(false);
                                        }
                                    }
                                    else
                                    {
                                        this.SetGuidButton(false);
                                    }
                                }
                                row.Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
                                #endregion
                            }
                            //削除指定区分:1
                            else
                            {
                                #region 行削除解除
                                // 行削除解除時BackColorの設定(DiabledColor)
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    cell.Appearance.BackColor = Color.Gainsboro;
                                    cell.Appearance.BackColor2 = Color.Gainsboro;
                                    cell.Appearance.BackColorDisabled = Color.Gainsboro;
                                    cell.Appearance.BackColorDisabled2 = Color.Gainsboro;
                                    if (cell.Column.Key == this._campaignMngDataTable.RowNoColumn.ColumnName)
                                    {
                                        cell.Appearance.BackColor = Color.Empty;
                                        cell.Appearance.BackColor2 = Color.Empty;
                                        cell.Appearance.BackColorDisabled = Color.Empty;
                                        cell.Appearance.BackColorDisabled2 = Color.Empty;
                                    }
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                }
                                row.Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
                                #endregion
                            }
                        }
                    }
                }

                this.uGrid_Details.EndUpdate();
            }
            finally
            {
                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 全削除処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 全削除処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void uButton_AllRowDelete_Click(object sender, EventArgs e)
        {
            bool isAllDelete = true;
            try
            {
                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                this.Cursor = Cursors.WaitCursor;

                this.uGrid_Details.BeginUpdate();

                //削除指定区分:0
                if (this._campaignObjGoodsStAcs.DeleteSearchMode == false)
                {
                    for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
                    {
                        if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value == 0)
                        {
                            isAllDelete = false;
                            break;
                        }
                    }

                    if (isAllDelete == true)
                    {
                        #region 入力許可設定
                        bool isNewRow = false;
                        foreach (UltraGridRow row in this.uGrid_Details.Rows)
                        {
                            if ((Guid)row.Cells[this._campaignMngDataTable.FilterGuidColumn.ColumnName].Value == Guid.Empty)
                            {
                                isNewRow = true;
                            }

                            row.Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                            row.Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Activation = Activation.AllowEdit;
                            if (isNewRow == true)
                            {
                                row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Activation = Activation.AllowEdit;
                            }
                            switch ((int)row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Value)
                            {
                                case 1:
                                    {
                                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.AllowEdit;
                                        break;
                                    }
                                case 2:
                                    {
                                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                        break;
                                    }
                                case 3:
                                    {
                                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                        break;
                                    }
                                case 4:
                                    {
                                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                        break;
                                    }
                                case 5:
                                    {
                                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                        break;
                                    }
                                case 6:
                                    {
                                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                        break;
                                    }
                            }
                            if ((int)row.Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Value == 1)
                            {
                                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Activation = Activation.AllowEdit;
                                if ((int)row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Value == 1)
                                {
                                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Activation = Activation.AllowEdit;
                                }
                                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Activation = Activation.AllowEdit;
                                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Activation = Activation.AllowEdit;
                                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Activation = Activation.AllowEdit;
                            }
                        }
                        #endregion

                        // 行削除解除時BackColorの設定(通常色)
                        foreach (UltraGridRow row in this.uGrid_Details.Rows)
                        {
                            if ((int)row.Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value == 1)
                            {
                                // 行削除解除時BackColorの設定(通常色)
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    if (cell.Activation != Activation.NoEdit
                                        || cell.Column.Key == this._campaignMngDataTable.RowNoColumn.ColumnName)
                                    {
                                        cell.Appearance.BackColor = Color.Empty;
                                        cell.Appearance.BackColor2 = Color.Empty;
                                        cell.Appearance.BackColorDisabled = Color.Empty;
                                        cell.Appearance.BackColorDisabled2 = Color.Empty;
                                    }
                                    else
                                    {
                                        cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                                        cell.Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                                        cell.Appearance.BackColorDisabled = ct_READONLY_CELL_COLOR;
                                        cell.Appearance.BackColorDisabled2 = ct_READONLY_CELL_COLOR;
                                    }
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                }
                            }

                            row.Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
                        }
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        if (this.uGrid_Details.ActiveCell != null)
                        {
                            if (this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.CampaignCodeColumn.ColumnName
                                            || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.SectionCodeColumn.ColumnName
                                            || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName
                                            || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName
                                            || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.BLGroupCodeColumn.ColumnName
                                            || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.SalesCodeColumn.ColumnName
                                            || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.CustomerCodeColumn.ColumnName)
                            {
                                if (this.uGrid_Details.ActiveCell.Activation == Activation.AllowEdit)
                                {
                                    this.SetGuidButton(true);
                                }
                                else
                                {
                                    this.SetGuidButton(false);
                                }
                            }
                            else
                            {
                                this.SetGuidButton(false);
                            }
                        }
                    }
                    else
                    {
                        this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
                        this.SetGuidButton(false);
                        
                        for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
                        {
                            if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value != 1)
                            {
                                // 行削除時BackColorの設定(ピンク色)、入力許可設定
                                foreach (UltraGridCell cell in this.uGrid_Details.Rows[rowIndex].Cells)
                                {
                                    cell.Appearance.BackColor = Color.Pink;
                                    cell.Appearance.BackColor2 = Color.Pink;
                                    cell.Appearance.BackColorDisabled = Color.Pink;
                                    cell.Appearance.BackColorDisabled2 = Color.Pink;
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;

                                    cell.Activation = Activation.NoEdit;
                                }
                            }

                            this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value = 1;
                        }
                    }

                }
                //削除指定区分:1
                else
                {
                    for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
                    {
                        if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value != 1)
                        {
                            isAllDelete = false;
                            break;
                        }
                    }

                    if (isAllDelete == true)
                    {
                        // 行削除解除時BackColorの設定(通常色)
                        foreach (UltraGridRow row in this.uGrid_Details.Rows)
                        {
                            if ((int)row.Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value == 1)
                            {
                                // 行削除解除時BackColorの設定(通常色)
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    if (cell.Column.Key == this._campaignMngDataTable.RowNoColumn.ColumnName)
                                    {
                                        cell.Appearance.BackColor = Color.Empty;
                                        cell.Appearance.BackColor2 = Color.Empty;
                                        cell.Appearance.BackColorDisabled = Color.Empty;
                                        cell.Appearance.BackColorDisabled2 = Color.Empty;
                                    }
                                    else
                                    {
                                        cell.Appearance.BackColor = ct_DISABLE_COLOR;
                                        cell.Appearance.BackColor2 = ct_DISABLE_COLOR;
                                        cell.Appearance.BackColorDisabled = ct_DISABLE_COLOR;
                                        cell.Appearance.BackColorDisabled2 = ct_DISABLE_COLOR;
                                    }
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;

                                    cell.Activation = Activation.NoEdit;
                                }
                            }

                            row.Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
                        }
                    }
                    else
                    {
                        for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
                        {
                            if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value != 1)
                            {
                                // 行削除時BackColorの設定(ピンク色)、入力許可設定
                                foreach (UltraGridCell cell in this.uGrid_Details.Rows[rowIndex].Cells)
                                {
                                    cell.Appearance.BackColor = Color.Pink;
                                    cell.Appearance.BackColor2 = Color.Pink;
                                    cell.Appearance.BackColorDisabled = Color.Pink;
                                    cell.Appearance.BackColorDisabled2 = Color.Pink;
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;

                                    cell.Activation = Activation.NoEdit;
                                }
                            }

                            this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value = 1;
                        }
                    }
                }

                this.uGrid_Details.EndUpdate();
            }
            finally
            {
                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 復活処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 復活処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void uButton_Revival_Click(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null)
            {
                return;
            }

            try
            {
                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                this.uGrid_Details.BeginUpdate();

                foreach (UltraGridRow row in this.uGrid_Details.Rows)
                {
                    if (row.Selected || row.IsActiveRow)
                    {
                        if ((int)this.uGrid_Details.Rows[row.Index].Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value != 2)
                        {
                            //復活処理
                            foreach (UltraGridCell cell in this.uGrid_Details.Rows[row.Index].Cells)
                            {
                                if (cell.Column.Key == this._campaignMngDataTable.RowNoColumn.ColumnName)
                                {
                                    cell.Appearance.BackColor = Color.Empty;
                                    cell.Appearance.BackColor2 = Color.Empty;
                                    cell.Appearance.BackColorDisabled = Color.Empty;
                                    cell.Appearance.BackColorDisabled2 = Color.Empty;
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                }
                                else
                                {
                                    cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                                    cell.Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                                    cell.Appearance.BackColorDisabled = ct_READONLY_CELL_COLOR;
                                    cell.Appearance.BackColorDisabled2 = ct_READONLY_CELL_COLOR;
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                }
                            }

                            this.uGrid_Details.Rows[row.Index].Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value = 2;
                        }
                        else
                        {
                            //復活解除処理
                            foreach (UltraGridCell cell in this.uGrid_Details.Rows[row.Index].Cells)
                            {
                                if (cell.Column.Key != this._campaignMngDataTable.RowNoColumn.ColumnName)
                                {
                                    cell.Appearance.BackColor = ct_DISABLE_COLOR;
                                    cell.Appearance.BackColor2 = ct_DISABLE_COLOR;
                                    cell.Appearance.BackColorDisabled = ct_DISABLE_COLOR;
                                    cell.Appearance.BackColorDisabled2 = ct_DISABLE_COLOR;
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                }
                            }

                            this.uGrid_Details.Rows[row.Index].Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
                        }
                    }
                }

                this.uGrid_Details.EndUpdate();
            }
            finally
            {
                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 価格日取得処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 価格日取得処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void uButton_GetPriceDate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "画面に表示されている全明細に対して、価格日を再設定します。" + "\r\n" + "\r\n" +
                        "よろしいですか？",
                        0,
                        MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
            {
                return;
            }

            this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
            this.SetGuidButton(false);

            foreach (CampaignMngDataSet.CampaignMngRow row in this._campaignMngDataTable.Rows)
            {
                if (row.SalesPriceSetDiv == 1)
                {
                    CampaignSt campaignSt;
                    if (this._campaignObjGoodsStAcs.CampaignStDic.ContainsKey(row.CampaignCode))
                    {
                        campaignSt = this._campaignObjGoodsStAcs.CampaignStDic[row.CampaignCode];

                        string strDate = string.Empty; 
                        int intDate = 0;
                        strDate = campaignSt.ApplyStaDate.Date.ToString("yyyyMMdd");
                        if (int.TryParse(strDate, out intDate))
                        {
                            row.PriceStartDate = intDate;
                        }

                        strDate = campaignSt.ApplyEndDate.Date.ToString("yyyyMMdd");
                        if (int.TryParse(strDate, out intDate))
                        {
                            row.PriceEndDate = intDate;
                        }
                    }
                }
            }
            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
            if (this.uGrid_Details.ActiveCell != null)
            {
                if (this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.CampaignCodeColumn.ColumnName
                                            || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.SectionCodeColumn.ColumnName
                                            || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName
                                            || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName
                                            || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.BLGroupCodeColumn.ColumnName
                                            || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.SalesCodeColumn.ColumnName
                                            || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.CustomerCodeColumn.ColumnName)
                {
                    if (this.uGrid_Details.ActiveCell.Activation == Activation.AllowEdit)
                    {
                        this.SetGuidButton(true);
                    }
                    else
                    {
                        this.SetGuidButton(false);
                    }
                }
                else
                {
                    this.SetGuidButton(false);
                }
            }
        }

        /// <summary>
        /// セルのデータチェック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <returns/>
        /// <remarks>
        /// <br>Note       : セルのデータチェック処理。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void uGrid_Details_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                // 数値項目の場合
                if ((this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int32)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int64)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(double)))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Details.ActiveCell.EditorResolved;

                    // 未入力は0にする				
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        if (this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName)
                        {
                            editorBase.Value = this.uGrid_Details.ActiveCell.Value;				// 前回値をセット
                        }
                        else if (this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName)
                        {
                            editorBase.Value = this.uGrid_Details.ActiveCell.Value;				// 前回値をセット
                        }
                        else
                        {
                            editorBase.Value = 0;				// 0をセット
                            this.uGrid_Details.ActiveCell.Value = 0;
                        }
                    }
                    // 数値項目に「-」or「.」だけしか入ってなかったら駄目です				
                    else if ((editorBase.CurrentEditText.Trim() == "-") ||
                        (editorBase.CurrentEditText.Trim() == ".") ||
                        (editorBase.CurrentEditText.Trim() == "-."))
                    {
                        if (this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName)
                        {
                            editorBase.Value = this.uGrid_Details.ActiveCell.Value;				// 前回値をセット
                        }
                        else if (this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName)
                        {
                            editorBase.Value = this.uGrid_Details.ActiveCell.Value;				// 前回値をセット
                        }
                        else
                        {
                            editorBase.Value = 0;				// 0をセット
                            this.uGrid_Details.ActiveCell.Value = 0;
                        }
                    }
                    // 通常入力				
                    else
                    {
                        try
                        {
                            editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.uGrid_Details.ActiveCell.Column.DataType);
                            this.uGrid_Details.ActiveCell.Value = editorBase.Value;
                        }
                        catch
                        {
                            if (this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName)
                            {
                                editorBase.Value = this.uGrid_Details.ActiveCell.Value;				// 前回値をセット
                            }
                            else if (this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName)
                            {
                                editorBase.Value = this.uGrid_Details.ActiveCell.Value;				// 前回値をセット
                            }
                            else
                            {
                                editorBase.Value = 0;				// 0をセット
                                this.uGrid_Details.ActiveCell.Value = 0;
                            }
                        }
                    }
                    e.RaiseErrorEvent = false;			// エラーイベントは発生させない
                    e.RestoreOriginalValue = false;		// セルの値を元に戻さない	
                    e.StayInEditMode = false;			// 編集モードは抜ける
                }
            }
        }

        /// <summary>
        /// グリッドセルアクティブ後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : グリッドセルアクティブ後発生イベント</br>
        /// <br>Programmer  : 曹文傑</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            this.SetGridGuid();
        }

        /// <summary>
        /// グリッドセル編集モードに入った後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : グリッドセル編集モードに入った後発生イベント</br>
        /// <br>Programmer  : 曹文傑</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void uGrid_Details_AfterEnterEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                if (this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.SectionCodeColumn.ColumnName)
                {
                    if (this.uGrid_Details.ActiveCell.Activation == Activation.AllowEdit)
                    {
                        int inputValue = 0;
                        if (int.TryParse(this.uGrid_Details.ActiveCell.Text, out inputValue))
                        {
                            this.uGrid_Details.ActiveCell.Value = inputValue.ToString();
                        }
                        else
                        {
                            this.uGrid_Details.ActiveCell.Value = "0";
                        }
                    }
                    this.uGrid_Details.ActiveCell.SelectAll();
                }
            }
        }

        /// <summary>
        /// グリッドセル出る後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : グリッドセル出る後発生イベント</br>
        /// <br>Programmer  : 曹文傑</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void uGrid_Details_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                if (this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.SectionCodeColumn.ColumnName)
                {
                    this.uGrid_Details.ActiveCell.Value = this.uGrid_Details.ActiveCell.Text.PadLeft(2, '0');
                }
            }
        }

        /// <summary>
        /// グリッドセルアクティブ前発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : グリッドセルアクティブ前発生イベント</br>
        /// <br>Programmer  : 曹文傑</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void uGrid_Details_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (e.Cell == null) return;
            UltraGridCell cell = e.Cell;

            if (cell.Column.Key == this._campaignMngDataTable.SectionCodeColumn.ColumnName)
            {
                this._swSectionCode = e.Cell.Value.ToString().Trim().PadLeft(2, '0');
            }
            else if (cell.Column.Key == this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName)
            {
                this._swGoodsMakerCd = (Int32)e.Cell.Value;
            }
            else if (cell.Column.Key == this._campaignMngDataTable.GoodsNoColumn.ColumnName)
            {
                this._swGoodsNo = e.Cell.Value.ToString().Trim();
            }
            else if (cell.Column.Key == this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName)
            {
                this._swBLGoodsCode = (Int32)e.Cell.Value;
            }
            else if (cell.Column.Key == this._campaignMngDataTable.BLGroupCodeColumn.ColumnName)
            {
                this._swBLGroupU = (Int32)e.Cell.Value;
            }
            else if (cell.Column.Key == this._campaignMngDataTable.SalesCodeColumn.ColumnName)
            {
                this._swUserGdBd = e.Cell.Value.ToString().Trim();
            }
            else if (cell.Column.Key == this._campaignMngDataTable.CustomerCodeColumn.ColumnName)
            {
                this._swCustomerInfo = e.Cell.Value.ToString().Trim();
            }
            else if (cell.Column.Key == this._campaignMngDataTable.CampaignCodeColumn.ColumnName)
            {
                this._swCampaignCd = (Int32)e.Cell.Value;
            }
        }

        /// <summary>
        /// CellChange イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にvalueを変化時に発生します。</br>
        /// <br>Programmer  : 曹文傑</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void uGrid_Details_CellChange(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;
            UltraGridCell cell = e.Cell;
            UltraGridRow row = e.Cell.Row;

            // 設定種別
            if (cell.Column.Key == this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName)
            {
                this.CampaignSettingKindChanged(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Text, row);
            }
            // 売価区分
            else if (cell.Column.Key == this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName)
            {
                int cellValue = 0;
                int.TryParse(cell.Text, out cellValue);

                this.SalesPriceSetDivChanged(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Text, row);

                if ((int)this.uGrid_Details.Rows[row.Index].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Value != 0 && ("1:有り".Equals(cell.Text) || cellValue == 1))
                {
                    CampaignSt campaignSt = null;
                    if (this._campaignObjGoodsStAcs.CampaignStDic.ContainsKey((int)this.uGrid_Details.Rows[row.Index].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Value))
                    {
                        campaignSt = this._campaignObjGoodsStAcs.CampaignStDic[(int)this.uGrid_Details.Rows[row.Index].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Value];
                    }

                    if (campaignSt != null)
                    {
                        this.uGrid_Details.Rows[row.Index].Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Value = Convert.ToInt32(campaignSt.ApplyStaDate.Date.ToString("yyyyMMdd"));
                        this.uGrid_Details.Rows[row.Index].Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Value = Convert.ToInt32(campaignSt.ApplyEndDate.Date.ToString("yyyyMMdd"));
                    }
                }
            }
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 曹文傑</br>
        /// <br>Date        : 2011/04/26</br>
        /// <br>UpdateNote :  2011/07/06 譚洪 Redmine#22776 キャンペーン対象商品設定マスタ／追加行の対応</br>
        /// <br>UpdateNote :  2011/07/07 譚洪 Redmine#22810 左右端の項目で止まるように修正。</br>
        /// <br>UpdateNote : 2011/07/12 曹文傑 Redmine#22919 ①初回起動時の文字サイズと項目幅の変更</br>
        /// <br>UpdateNote : 2011/07/14 曹文傑 Redmine#22984 最終行の情報がデータ登録されない</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Details.ActiveRow != null)
            {
                if (this.uGrid_Details.ActiveRow.Selected && this.uGrid_Details.ActiveRow.Index == 0)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        if (this.GridKeyUpTopRow != null)
                        {
                            this.GridKeyUpTopRow(this, new EventArgs());
                            this.uGrid_Details.ActiveRow.Selected = false;
                            this.uGrid_Details.ActiveRow = null;
                            e.Handled = true;
                        }
                    }
                }
            }
            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            int rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            string columnKey = this.uGrid_Details.ActiveCell.Column.Key;

            if (this.uGrid_Details.ActiveCell.IsInEditMode)
            {
                if (e.KeyCode == Keys.Left && this.uGrid_Details.ActiveCell.SelStart != 0)
                {
                    return;
                }
                if (e.KeyCode == Keys.Right && this.uGrid_Details.ActiveCell.SelStart < this.uGrid_Details.ActiveCell.Text.Length)
                {
                    return;
                }
            }

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        this.focusFlg = true;
                        this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

                        if (rowIndex == 0)
                        {
                            if (focusFlg)
                            {
                                if (this.GridKeyUpTopRow != null)
                                {
                                    this.GridKeyUpTopRow(this, new EventArgs());
                                    this.uGrid_Details.ActiveCell.Selected = false;
                                    this.uGrid_Details.ActiveCell = null;
                                    e.Handled = true;
                                }
                            }
                            else
                            {
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            e.Handled = true;
                            if (focusFlg)
                            {
                                this.uGrid_Details.Rows[rowIndex - 1].Cells[columnKey].Activate();
                            }
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        this.focusFlg = true;
                        this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

                        if (rowIndex == this.uGrid_Details.Rows.Count - 1)
                        {
                            e.Handled = true;
                            if (focusFlg)
                            {
                                if (this._campaignObjGoodsStAcs.DeleteSearchMode == false)
                                {
                                    // ----- UPD 2011/07/06 ------- >>>>>>>>>
                                    if (CheckDateForDown())
                                    {
                                        #region 最終行の場合、新規行を追加する
                                        CampaignMngDataSet.CampaignMngRow newRow = this._campaignMngDataTable.NewCampaignMngRow();
                                        newRow.RowNo = this.uGrid_Details.Rows.Count + 1;
                                        newRow.FilterGuid = Guid.Empty;
                                        newRow.SectionCode = "00";
                                        newRow.GoodsName = "";
                                        newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");

                                        this._campaignMngDataTable.AddCampaignMngRow(newRow);

                                        this.DetailGridInitSetting();
                                        #endregion
                                        // ---UPD 2011/07/12---------------->>>>>
                                        //if (rowIndex < this.uGrid_Details.Rows.Count - 1)
                                        //{
                                        //    this.uGrid_Details.Rows[rowIndex + 1].Cells[columnKey].Activate();
                                        //}

                                        string campaignCode = string.Empty;
                                        string campaignName = string.Empty;
                                        string sectionCode = string.Empty;
                                        this.GetCampaignInfo(out campaignCode, out campaignName, out sectionCode);
                                        if (campaignCode == string.Empty &&
                                            campaignName == string.Empty &&
                                            sectionCode == string.Empty)
                                        {
                                            if (rowIndex < this.uGrid_Details.Rows.Count - 1)
                                            {
                                                this.uGrid_Details.Rows[rowIndex + 1].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                                            }
                                        }
                                        else
                                        {
                                            this.uGrid_Details.Rows[rowIndex + 1].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();

                                            this.uGrid_Details.Rows[rowIndex + 1].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Value = campaignCode;
                                            this.uGrid_Details.Rows[rowIndex + 1].Cells[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Value = campaignName;
                                            this.uGrid_Details.Rows[rowIndex + 1].Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Value = sectionCode;

                                            this.uGrid_Details.Rows[rowIndex + 1].Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Activate();
                                        }

                                        // ---ADD 2011/07/14------------->>>>>
                                        CampaignObjGoodsSt campaignObjGoodsSt = null;
                                        this._campaignObjGoodsStAcs.CopyToCampaignMngFromDetailRow((CampaignMngDataSet.CampaignMngRow)this._campaignMngDataTable.Rows[this._campaignMngDataTable.Count - 1], ref campaignObjGoodsSt);
                                        this._campaignObjGoodsStAcs.NewCampaignObj = campaignObjGoodsSt.Clone();
                                        // ---ADD 2011/07/14-------------<<<<<
                                        // ---UPD 2011/07/12----------------<<<<<
                                    }
                                    // ----- UPD 2011/07/06 ------- <<<<<<<<<
                                }
                            }
                        }
                        else
                        {
                            e.Handled = true;
                            if (focusFlg)
                            {
                                this.uGrid_Details.Rows[rowIndex + 1].Cells[columnKey].Activate();
                            }
                        }
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                case Keys.Left:
                    {
                        this.focusFlg = true;
                        this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

                        // ----- UPD 2011/07/07 ------- >>>>>>>>>
                        //if ((rowIndex == 0) &&
                        //       (columnKey == this._campaignMngDataTable.CampaignCodeColumn.ColumnName))
                        if (columnKey == this._campaignMngDataTable.CampaignCodeColumn.ColumnName
                            || columnKey == this._campaignMngDataTable.UpdateTimeColumn.ColumnName)
                        {
                            // 左端のVisiblePositionを取得
                            //int firstPosition = this.GetGridFirstPosition(this.uGrid_Details);

                            // 左端から次行左端に移動させない
                            if (this.uGrid_Details.ActiveCell.Column.Header.VisiblePosition == 1)
                            {
                                e.Handled = true;
                            }
                            else
                            {
                                if (!this.leftFocusFlg)
                                {
                                    e.Handled = true;
                                }
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                break;
                            }
                        }
                        // ----- UPD 2011/07/07 ------- <<<<<<<<<
                        else
                        {
                            // 次セル取得
                            string columnName = columnKey;
                            // 次セル取得
                            int targetColumnIndex = GetNextColumnIndexByTab(1, rowIndex, columnName);

                            if (targetColumnIndex != -1)
                            {
                                if (focusFlg)
                                {
                                    this.uGrid_Details.Rows[rowIndex].Cells[targetColumnIndex].Activate();
                                }
                            }
                            else
                            {
                                if (focusFlg)
                                {
                                    // 改行
                                    columnName = this._campaignMngDataTable.PriceEndDateColumn.ColumnName;
                                    this.uGrid_Details.Rows[rowIndex - 1].Cells[columnName].Activate();
                                }
                            }
                        }

                        e.Handled = true;
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                case Keys.Right:
                    {
                        this.focusFlg = true;

                        // ----- UPD 2011/07/07 ------- >>>>>>>>>
                        if (columnKey == this._campaignMngDataTable.UpdateTimeColumn.ColumnName)
                        {
                            // なし。
                        }
                        // UPD 陳健 2014/03/20 -------------------------------------------------------------->>>>>
                        //else if (columnKey == this._campaignMngDataTable.PriceEndDateColumn.ColumnName)
                        else if (columnKey == this._campaignMngDataTable.UpdateTime2Column.ColumnName)
                        // UPD 陳健 2014/03/20 --------------------------------------------------------------<<<<<
                        {
                            // 右端のVisiblePositionを取得
                            int lastPosition = this.GetGridLastPosition(this.uGrid_Details);

                            // 右端から次行左端に移動させない
                            if (this.uGrid_Details.ActiveCell.Column.Header.VisiblePosition == lastPosition)
                            {
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

                            // 次セル取得
                            string columnName = columnKey;
                            // 次セル取得
                            int targetColumnIndex = GetNextColumnIndexByTab(0, rowIndex, columnName);

                            if (targetColumnIndex != -1)
                            {
                                if (focusFlg)
                                {
                                    this.uGrid_Details.Rows[rowIndex].Cells[targetColumnIndex].Activate();
                                }
                            }
                            else
                            {
                                if (focusFlg)
                                {
                                    if (rowIndex < this.uGrid_Details.Rows.Count - 1)
                                    {
                                        // 改行
                                        columnName = this._campaignMngDataTable.CampaignCodeColumn.ColumnName;
                                        this.uGrid_Details.Rows[rowIndex + 1].Cells[columnName].Activate();
                                    }
                                    else
                                    {
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        return;
                                    }
                                }
                            }

                            e.Handled = true;
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        // ----- UPD 2011/07/07 ------- <<<<<<<<<
                        break;
                    }
            }
            this.focusFlg = true;
        }

        // ----- ADD 2011/07/07 ------- >>>>>>>>>
        /// <summary>
        /// グリッド内の最後のVisiblePosition取得
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private int GetGridLastPosition(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            if (grid.ActiveRow == null) return 0;

            int colCount = 0;
            for (int index = 0; index < grid.ActiveRow.Cells.Count; index++)
            {
                if (grid.ActiveRow.Cells[index].Column.Hidden == false)
                {
                    if (colCount < grid.ActiveRow.Cells[index].Column.Header.VisiblePosition)
                    {
                        colCount = grid.ActiveRow.Cells[index].Column.Header.VisiblePosition;
                    }
                }
            }
            return colCount;
        }

        /// <summary>
        /// グリッド内の最前のVisiblePosition取得
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private int GetGridFirstPosition(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            if (grid.ActiveRow == null) return 0;

            int colCount = 5;
            for (int index = 0; index < grid.ActiveRow.Cells.Count; index++)
            {
                if (grid.ActiveRow.Cells[index].Column.Hidden == false)
                {
                    if (colCount > grid.ActiveRow.Cells[index].Column.Header.VisiblePosition)
                    {
                        colCount = grid.ActiveRow.Cells[index].Column.Header.VisiblePosition;
                    }
                }
            }
            return colCount;
        }
        // ----- ADD 2011/07/07 ------- <<<<<<<<<

        /// <summary>
        /// グリッドセルアプデト後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : グリッドセルアプデト後発生イベント</br>
        /// <br>Programmer  : 曹文傑</br>
        /// <br>Date        : 2011/04/26</br>
        /// <br>UpdateNote  : 2011/07/07 譚洪 Redmine#22810 明細”メーカー名称”から”カナ名称”に変更の対応</br>
        /// <br>UpdateNote  : 2011/07/22 譚洪 Redmine#23119 提供優良品番の品名が空白のものがありますの対応</br>
        /// </remarks>
        private void uGrid_Details_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;
            UltraGridCell cell = e.Cell;
            UltraGridRow row = e.Cell.Row;

            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
            // 設定種別
            if (cell.Column.Key == this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName)
            {
                //なし。
            }
            // 売価区分
            else if (cell.Column.Key == this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName)
            {
                //なし。
            }
            // ｺｰﾄﾞ
            else if (cell.Column.Key == this._campaignMngDataTable.CampaignCodeColumn.ColumnName)
            {
                int inputValue = 0;
                // 入力値を取得
                Int32.TryParse(cell.Value.ToString(), out inputValue);

                if (inputValue != 0)
                {
                    CampaignSt campaignSt = null;
                    if (this._campaignObjGoodsStAcs.CampaignStDic.ContainsKey(inputValue))
                    {
                        campaignSt = this._campaignObjGoodsStAcs.CampaignStDic[inputValue];
                    }

                    if (campaignSt != null && campaignSt.LogicalDeleteCode == 0)
                    {
                        // キャンペーンコードの値設定
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Value = inputValue;
                        this._swCampaignCd = inputValue;

                        // キャンペーン名の値設定
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Value = campaignSt.CampaignName;

                        // 拠点の値設定
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Value = campaignSt.SectionCode.Trim().PadLeft(2, '0');
                        this._swSectionCode = campaignSt.SectionCode.Trim().PadLeft(2, '0');

                        // 適用日の値設定
                        if ((int)this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Value == 1)
                        {
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Value = Convert.ToInt32(campaignSt.ApplyStaDate.Date.ToString("yyyyMMdd"));
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Value = Convert.ToInt32(campaignSt.ApplyEndDate.Date.ToString("yyyyMMdd"));
                        }
                    }
                    else
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "キャンペーンコードが存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Value = this._swCampaignCd;
                        this.focusFlg = false;
                    }
                }
                else
                {
                    // キャンペーンコードの値設定
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Value = 0;
                    this._swCampaignCd = 0;

                    // キャンペーン名の値設定
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Value = string.Empty;
                }
            }
            // 拠点
            else if (cell.Column.Key == this._campaignMngDataTable.SectionCodeColumn.ColumnName)
            {
                string inputValue = e.Cell.Value.ToString().Trim().PadLeft(2, '0');

                if (!"00".Equals(inputValue))
                {
                    SecInfoSet secInfoSet = null;
                    if (this._campaignObjGoodsStAcs.SecInfoSetDic.ContainsKey(inputValue))
                    {
                        secInfoSet = this._campaignObjGoodsStAcs.SecInfoSetDic[inputValue];
                    }

                    if (secInfoSet != null)
                    {
                        this._swSectionCode = secInfoSet.SectionCode.Trim();
                    }
                    else
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "拠点が存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Value = this._swSectionCode;
                        this.focusFlg = false;
                    }
                }
                else
                {
                    this._swSectionCode = "00";
                }
            }
            // ﾒｰｶｰ
            else if (cell.Column.Key == this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName)
            {
                int inputValue = 0;
                // 入力値を取得
                Int32.TryParse(cell.Value.ToString(), out inputValue);


                if (inputValue != 0)
                {
                    MakerUMnt makerUMnt = null;
                    if (this._campaignObjGoodsStAcs.MakerUMntDic.ContainsKey(inputValue))
                    {
                        makerUMnt = this._campaignObjGoodsStAcs.MakerUMntDic[inputValue];
                    }

                    if (makerUMnt != null)
                    {
                        if (!string.IsNullOrEmpty(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Text.Trim()))
                        {
                            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                            GoodsUnitData goodsUnitData = new GoodsUnitData();
                            string msg = string.Empty;
                            GoodsCndtn cndtn = new GoodsCndtn();
                            cndtn.EnterpriseCode = this._enterpriseCode;
                            cndtn.GoodsMakerCd = inputValue;
                            cndtn.GoodsNo = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Text.Trim();
                            cndtn.GoodsKindCode = 9;
                            int status = this._campaignObjGoodsStAcs.GoodsAcsClass.SearchPartsFromGoodsNoNonVariousSearch(cndtn, out goodsUnitDataList, out msg);

                            if (goodsUnitDataList.Count > 0)
                            {
                                goodsUnitData = goodsUnitDataList[0];

                                if (goodsUnitData.LogicalDeleteCode == 0)
                                {
                                    this._swGoodsMakerCd = inputValue;
                                    //this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Value = makerUMnt.MakerName;   // DEL 2011/07/07 
                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Value = makerUMnt.MakerKanaName; // ADD 2011/07/07 
                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Value = goodsUnitData.GoodsNo;
                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = goodsUnitData.GoodsNameKana;
                                }
                            }
                            else
                            {
                                TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "商品が存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Value = this._swGoodsMakerCd;
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                this.focusFlg = false;
                            }
                        }
                        else
                        {
                            this._swGoodsMakerCd = inputValue;
                            //this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Value = makerUMnt.MakerName; // DEL 2011/07/07 
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Value = makerUMnt.MakerKanaName;   // ADD 2011/07/07 
                        }
                    }
                    else
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "メーカーコードが存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Value = this._swGoodsMakerCd;
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        this.focusFlg = false;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Text.Trim()))
                    {
                        List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                        GoodsUnitData goodsUnitData = new GoodsUnitData();
                        string msg = string.Empty;
                        GoodsCndtn cndtn = new GoodsCndtn();
                        cndtn.EnterpriseCode = this._enterpriseCode;

                        if (inputValue != 0)
                        {
                            cndtn.GoodsMakerCd = inputValue;
                        }
                        cndtn.GoodsNo = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Text.Trim();
                        cndtn.GoodsKindCode = 9;
                        int status = this._campaignObjGoodsStAcs.GoodsAcsClass.SearchPartsFromGoodsNoNonVariousSearch(cndtn, out goodsUnitDataList, out msg);

                        if (goodsUnitDataList.Count > 0)
                        {
                            goodsUnitData = goodsUnitDataList[0];

                            if (goodsUnitData.LogicalDeleteCode == 0)
                            {
                                this._swGoodsMakerCd = goodsUnitData.GoodsMakerCd;
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Value = goodsUnitData.GoodsMakerCd;
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = goodsUnitData.GoodsNameKana;
                            }
                        }
                        else
                        {
                            TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "商品が存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Value = this._swGoodsMakerCd;
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            this.focusFlg = false;
                        }
                    }
                    else
                    {
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Value = 0;
                        this._swGoodsMakerCd = 0;
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Value = string.Empty;
                    }
                }
            }
            // 品番
            else if (cell.Column.Key == this._campaignMngDataTable.GoodsNoColumn.ColumnName)
            {
                string goodsNo = cell.Value.ToString();
                int goodsMakerCd = (int)this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Value;

                if (!String.IsNullOrEmpty(goodsNo))
                {
                    if (!this._swGoodsNo.Equals(goodsNo))
                    {
                        List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                        GoodsUnitData goodsUnitData = new GoodsUnitData();
                        string msg = string.Empty;
                        GoodsCndtn cndtn = new GoodsCndtn();
                        cndtn.EnterpriseCode = this._enterpriseCode;
                        cndtn.SectionCode = this._loginSectionCode;  // ADD 2011/07/22
                        if (goodsMakerCd != 0)
                        {
                            cndtn.GoodsMakerCd = goodsMakerCd;
                        }
                        cndtn.GoodsNo = cell.Value.ToString().Trim();
                        cndtn.GoodsKindCode = 9;

                        int status = this._campaignObjGoodsStAcs.GoodsAcsClass.SearchPartsFromGoodsNoNonVariousSearch(cndtn, out goodsUnitDataList, out msg);

                        // ADD 2011/07/22 --- >>>
                        if (goodsUnitDataList.Count == 0)
                        {
                            cndtn.SectionCode = "00";
                            status = this._campaignObjGoodsStAcs.GoodsAcsClass.SearchPartsFromGoodsNoNonVariousSearch(cndtn, out goodsUnitDataList, out msg);
                        }
                        // ADD 2011/07/22 --- <<<
                        if (goodsUnitDataList.Count > 0)
                        {
                            goodsUnitData = goodsUnitDataList[0];

                            if (goodsUnitData.LogicalDeleteCode == 0)
                            {
                                this._swGoodsNo = goodsUnitData.GoodsNo;
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Value = goodsUnitData.GoodsMakerCd;
                                MakerUMnt makerUMnt = null;
                                try
                                {
                                    makerUMnt = this._campaignObjGoodsStAcs.MakerUMntDic[goodsUnitData.GoodsMakerCd];
                                }
                                catch
                                {
                                }
                                finally
                                {
                                    if (makerUMnt != null)
                                    {
                                        //this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Value = makerUMnt.MakerName;   // DEL 2011/07/07 
                                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Value = makerUMnt.MakerKanaName; // ADD 2011/07/07 
                                    }
                                }
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Value = goodsUnitData.GoodsNo;
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = goodsUnitData.GoodsNameKana;
                            }
                        }
                        else if (status == -1)
                        {
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Value = string.Empty;
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = string.Empty;
                            this._swGoodsNo = string.Empty;
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            this.focusFlg = false;
                        }
                        else
                        {
                            TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "商品が存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Value = this._swGoodsNo;
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            this.focusFlg = false;
                        }
                    }
                }
                else
                {
                    this._swGoodsNo = string.Empty;
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Value = 0;
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Value = string.Empty;
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = string.Empty;
                }
            }
            // BLｺｰﾄﾞ
            else if (cell.Column.Key == this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName)
            {
                int inputValue = 0;
                // 入力値を取得
                Int32.TryParse(cell.Value.ToString(), out inputValue);
                if (inputValue != 0)
                {
                    BLGoodsCdUMnt blGoodsCdUMnt = null;
                    if (this._campaignObjGoodsStAcs.BLGoodsCdDic.ContainsKey(inputValue))
                    {
                        blGoodsCdUMnt = this._campaignObjGoodsStAcs.BLGoodsCdDic[inputValue];
                    }

                    if (blGoodsCdUMnt != null)
                    {
                        this._swBLGoodsCode = blGoodsCdUMnt.BLGoodsCode;
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Value = blGoodsCdUMnt.BLGoodsCode;
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = blGoodsCdUMnt.BLGoodsHalfName;
                    }
                    else
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "ＢＬコードが存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Value = this._swBLGoodsCode;
                        this.focusFlg = false;
                    }
                }
                else
                {
                    this._swBLGoodsCode = 0;
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Value = 0;
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = string.Empty;
                }
            }
            // ｸﾞﾙｰﾌ
            else if (cell.Column.Key == this._campaignMngDataTable.BLGroupCodeColumn.ColumnName)
            {
                int inputValue = 0;
                // 入力値を取得
                Int32.TryParse(cell.Value.ToString(), out inputValue);

                if (inputValue != 0)
                {
                    BLGroupU blGroupU = null;
                    if (this._campaignObjGoodsStAcs.BLGroupDic.ContainsKey(inputValue))
                    {
                        blGroupU = this._campaignObjGoodsStAcs.BLGroupDic[inputValue];
                    }

                    if (blGroupU != null)
                    {
                        this._swBLGroupU = blGroupU.BLGroupCode;
                    }
                    else
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "グループコードが存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Value = this._swBLGroupU;
                        this.focusFlg = false;
                    }
                }
                else
                {
                    this._swBLGroupU = 0;
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Value = 0;
                }
            }
            // 販売区分
            else if (cell.Column.Key == this._campaignMngDataTable.SalesCodeColumn.ColumnName)
            {
                int inputValue = 0;
                // 入力値を取得
                Int32.TryParse(cell.Value.ToString(), out inputValue);
                if (cell.Value.ToString().Trim() != string.Empty)
                {
                    UserGdBd userGdBd = null;
                    if (this._campaignObjGoodsStAcs.UserGdBdDic.ContainsKey(inputValue))
                    {
                        userGdBd = this._campaignObjGoodsStAcs.UserGdBdDic[inputValue];
                    }

                    if (userGdBd != null)
                    {
                        this._swUserGdBd = userGdBd.GuideCode.ToString().PadLeft(4, '0');
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Value = userGdBd.GuideCode.ToString().PadLeft(4, '0');
                    }
                    else
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "販売区分が存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Value = this._swUserGdBd;
                        this.focusFlg = false;
                    }
                }
                else
                {
                    this._swUserGdBd = string.Empty;
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Value = string.Empty;
                }
            }
            // 得意先
            else if (cell.Column.Key == this._campaignMngDataTable.CustomerCodeColumn.ColumnName)
            {
                int inputValue = 0;
                // 入力値を取得
                Int32.TryParse(cell.Value.ToString(), out inputValue);

                if (cell.Value.ToString().Trim() != string.Empty)
                {
                    CustomerInfo customerInfo = null;
                    if (this._campaignObjGoodsStAcs.CustomerDic.ContainsKey(inputValue))
                    {
                        customerInfo = this._campaignObjGoodsStAcs.CustomerDic[inputValue];
                    }

                    if (customerInfo != null || inputValue == 0)
                    {
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Value = inputValue.ToString().PadLeft(8, '0');
                        this._swCustomerInfo = inputValue.ToString().PadLeft(8, '0');
                    }
                    else
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "得意先が存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Value = this._swCustomerInfo.ToString().PadLeft(8, '0');
                        this.focusFlg = false;
                    }
                }
                else
                {
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Value = string.Empty;
                    this._swCustomerInfo = string.Empty;
                }
            }
            // 価格開始日
            else if (cell.Column.Key == this._campaignMngDataTable.PriceStartDateColumn.ColumnName)
            {
                //なし。
            }
            // 価格終了日
            else if (cell.Column.Key == this._campaignMngDataTable.PriceEndDateColumn.ColumnName)
            {
                //なし。
            }
            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
        }

        /// <summary>
        /// グリッドセルKeyPress発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : グリッドセルKeyPress発生イベント</br>
        /// <br>Programmer  : 曹文傑</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            UltraGridCell cell = this.uGrid_Details.ActiveCell;

            if (!cell.IsInEditMode) return;

            //----------------------------------------------
            // ActiveCellがキャンペーンコードの場合
            //----------------------------------------------
            if (cell.Column.Key == this._campaignMngDataTable.CampaignCodeColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(6, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCellが拠点の場合
            //----------------------------------------------
            else if (cell.Column.Key == this._campaignMngDataTable.SectionCodeColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCellが設定種別、売価区分の場合
            //----------------------------------------------
            else if (cell.Column.Key == this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName
                    || cell.Column.Key == this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(1, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCellがメーカー、販売区分の場合
            //----------------------------------------------
            else if (cell.Column.Key == this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName
                  || cell.Column.Key == this._campaignMngDataTable.SalesCodeColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCellがBLｺｰﾄﾞ、ｸﾞﾙｰﾌﾟｺｰﾄﾞの場合
            //----------------------------------------------
            else if (cell.Column.Key == this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName
                  || cell.Column.Key == this._campaignMngDataTable.BLGroupCodeColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(5, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCellが得意先、価格開始日、価格終了日の場合
            //----------------------------------------------
            else if (cell.Column.Key == this._campaignMngDataTable.CustomerCodeColumn.ColumnName
                   || cell.Column.Key == this._campaignMngDataTable.PriceStartDateColumn.ColumnName
                   || cell.Column.Key == this._campaignMngDataTable.PriceEndDateColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(8, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCellが値引率の場合
            //----------------------------------------------
            else if (cell.Column.Key == this._campaignMngDataTable.DiscountRateColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(5, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCellが売価率の場合
            //----------------------------------------------
            else if (cell.Column.Key == this._campaignMngDataTable.RateValColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(6, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCellが売価額の場合
            //----------------------------------------------
            else if (cell.Column.Key == this._campaignMngDataTable.PriceFlColumn.ColumnName)
            {
                if (e.KeyChar == '-')
                {
                    if ((cell.Text.Trim().Contains("-") && cell.SelLength == 14)
                        || (!cell.Text.Trim().Contains("-") && cell.SelLength == 13))
                    {
                        return;
                    }

                    if (cell.Text.Trim().Contains("-") || cell.SelStart != 0)
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else
                {
                    if (e.KeyChar != '.')
                    {
                        if (cell.Text.Trim().Contains("-"))
                        {
                            if (cell.SelStart == 11)
                            {
                                e.Handled = true;
                                return;
                            }
                        }
                    }

                    if (cell.Text.Trim().Contains("-"))
                    {
                        if (!this.KeyPressNumCheck(14, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, true))
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                    else
                    {
                        if (!this.KeyPressNumCheck(13, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                }
            }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 明細部初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 明細部初期化処理します。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/12 曹文傑 Redmine#22919 ①初回起動時の文字サイズと項目幅の変更</br>
        /// </remarks>
        private void InitialSettingGridCol()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // 全ての列をいったん非表示にする。
                col.Hidden = true;
                col.Header.Fixed = false;

                // 「No列」以外の全てのセルのDiabledColorを設定する。
                if (col.Key != this._campaignMngDataTable.RowNoColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = ct_DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = ct_DISABLE_FONT_COLOR;
                }
            }

            #region ●表示幅設定
            // ---UPD 2011/07/12---------------->>>>>
            //editBand.Columns[this._campaignMngDataTable.RowNoColumn.ColumnName].Width = 55;		            // №
            //editBand.Columns[this._campaignMngDataTable.UpdateTimeColumn.ColumnName].Width = 80;		        // 削除日
            //editBand.Columns[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Width = 70;			    // ｺｰﾄﾞ
            //editBand.Columns[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Width = 120;			// 名称
            //editBand.Columns[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Width = 40;		    	// 拠点
            //editBand.Columns[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Width = 140;		// 設定種別
            //editBand.Columns[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Width = 50;		    // ﾒｰｶｰ
            //editBand.Columns[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Width = 180;			// ﾒｰｶｰ名
            //editBand.Columns[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Width = 150;	                // 品番
            //editBand.Columns[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Width = 60;		        // BLｺｰﾄﾞ
            //editBand.Columns[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Width = 150;				// 品名
            //editBand.Columns[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Width = 60;			    // ｸﾞﾙｰﾌﾟ
            //editBand.Columns[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Width = 80;			    // 販売区分
            //editBand.Columns[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Width = 75;		    // 売価区分
            //editBand.Columns[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Width = 80;		        // 得意先
            //editBand.Columns[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Width = 60;		        // 値引率
            //editBand.Columns[this._campaignMngDataTable.RateValColumn.ColumnName].Width = 60;				    // 売価率
            //editBand.Columns[this._campaignMngDataTable.PriceFlColumn.ColumnName].Width = 150;			        // 売価額
            //editBand.Columns[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Width = 90;			// 価格開始日
            //editBand.Columns[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Width = 90;			// 価格終了日

            editBand.Columns[this._campaignMngDataTable.RowNoColumn.ColumnName].Width = 40;		            // №
            editBand.Columns[this._campaignMngDataTable.UpdateTimeColumn.ColumnName].Width = 80;		        // 削除日
            editBand.Columns[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Width = 55;			    // ｺｰﾄﾞ
            editBand.Columns[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Width = 120;			// 名称
            editBand.Columns[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Width = 35;		    	// 拠点
            editBand.Columns[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Width = 125;		// 設定種別
            editBand.Columns[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Width = 40;		    // ﾒｰｶｰ
            editBand.Columns[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Width = 85;			// ﾒｰｶｰ名
            editBand.Columns[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Width = 115;	                // 品番
            editBand.Columns[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Width = 50;		        // BLｺｰﾄﾞ
            editBand.Columns[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Width = 150;				// 品名
            editBand.Columns[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Width = 50;			    // ｸﾞﾙｰﾌﾟ
            editBand.Columns[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Width = 60;			    // 販売区分
            editBand.Columns[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Width = 70;		    // 売価区分
            editBand.Columns[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Width = 65;		        // 得意先
            editBand.Columns[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Width = 50;		        // 値引率
            editBand.Columns[this._campaignMngDataTable.RateValColumn.ColumnName].Width = 55;				    // 売価率
            editBand.Columns[this._campaignMngDataTable.PriceFlColumn.ColumnName].Width = 130;			        // 売価額
            editBand.Columns[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Width = 75;			// 価格開始日
            editBand.Columns[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Width = 75;			// 価格終了日
            // ADD 陳健 2014/03/20 --------------------------------------------------------------->>>>>
            editBand.Columns[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Width = 75;			// 更新日
            // ADD 陳健 2014/03/20 ---------------------------------------------------------------<<<<<
            // ---UPD 2011/07/12----------------<<<<<
            #endregion

            #region ●固定列設定
            editBand.Columns[this._campaignMngDataTable.RowNoColumn.ColumnName].Header.Fixed = true;		            // №
            editBand.Columns[this._campaignMngDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;		            // №
            #endregion
            
            #region ●CellAppearance設定
            editBand.Columns[this._campaignMngDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;                 // №
            editBand.Columns[this._campaignMngDataTable.UpdateTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;			    // 削除日
            editBand.Columns[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right; 			// ｺｰﾄﾞ
            editBand.Columns[this._campaignMngDataTable.CampaignNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;			// 名称
            editBand.Columns[this._campaignMngDataTable.SectionCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		    // 拠点
            editBand.Columns[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	// 設定種別
            editBand.Columns[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		    // ﾒｰｶｰ
            editBand.Columns[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;			// ﾒｰｶｰ名
            editBand.Columns[this._campaignMngDataTable.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	            // 品番
            editBand.Columns[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		    // BLｺｰﾄﾞ
            editBand.Columns[this._campaignMngDataTable.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;				// 品名
            editBand.Columns[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;			// ｸﾞﾙｰﾌﾟ
            editBand.Columns[this._campaignMngDataTable.SalesCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;			    // 販売区分
            editBand.Columns[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;		// 売価区分
            editBand.Columns[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		    // 得意先
            editBand.Columns[this._campaignMngDataTable.DiscountRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		    // 値引率
            editBand.Columns[this._campaignMngDataTable.RateValColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;				// 売価率
            editBand.Columns[this._campaignMngDataTable.PriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;			    // 売価額
            editBand.Columns[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;			// 価格開始日
            editBand.Columns[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;			// 価格終了日
            // ADD 陳健 2014/03/20 --------------------------------------------------------------->>>>>
            editBand.Columns[this._campaignMngDataTable.UpdateTime2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;             // 更新日
            // ADD 陳健 2014/03/20 --------------------------------------------------------------->>>>>


            editBand.Columns[this._campaignMngDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            editBand.Columns[this._campaignMngDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            editBand.Columns[this._campaignMngDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            editBand.Columns[this._campaignMngDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            editBand.Columns[this._campaignMngDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            editBand.Columns[this._campaignMngDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            #endregion

            #region ●入力許可設定
            editBand.Columns[this._campaignMngDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;		        // №
            editBand.Columns[this._campaignMngDataTable.UpdateTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;			    // 削除日
            editBand.Columns[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;		// ｺｰﾄﾞ
            editBand.Columns[this._campaignMngDataTable.CampaignNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;			// 名称
            editBand.Columns[this._campaignMngDataTable.SectionCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;		    // 拠点
            editBand.Columns[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;	// 設定種別
            editBand.Columns[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;		// ﾒｰｶｰ
            editBand.Columns[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;			// ﾒｰｶｰ名
            editBand.Columns[this._campaignMngDataTable.GoodsNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 	        // 品番
            editBand.Columns[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 		// BLｺｰﾄﾞ
            editBand.Columns[this._campaignMngDataTable.GoodsNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; 				// 品名
            editBand.Columns[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 	    // ｸﾞﾙｰﾌﾟ
            editBand.Columns[this._campaignMngDataTable.SalesCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 			// 販売区分
            editBand.Columns[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 	// 売価区分
            editBand.Columns[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 		// 得意先
            editBand.Columns[this._campaignMngDataTable.DiscountRateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;		// 値引率
            editBand.Columns[this._campaignMngDataTable.RateValColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 			// 売価率
            editBand.Columns[this._campaignMngDataTable.PriceFlColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 			// 売価額
            editBand.Columns[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 		// 価格開始日
            editBand.Columns[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 		// 価格終了日
            // ADD 陳健 2014/03/20 --------------------------------------------------------------->>>>>
            editBand.Columns[this._campaignMngDataTable.UpdateTime2Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;         //更新日
            // ADD 陳健 2014/03/20 ---------------------------------------------------------------<<<<<
            #endregion

            #region ●Style設定
            editBand.Columns[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			            // ｺｰﾄﾞ
            editBand.Columns[this._campaignMngDataTable.UpdateTimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			            // 削除日
            editBand.Columns[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			            // 名称
            editBand.Columns[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;		    	        // 拠点
            editBand.Columns[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;	// 設定種別
            editBand.Columns[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;		            // ﾒｰｶｰ
            editBand.Columns[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			        // ﾒｰｶｰ名
            editBand.Columns[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;	                        // 品番
            editBand.Columns[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;		                // BLｺｰﾄﾞ
            editBand.Columns[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			         	// 品名
            editBand.Columns[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			            // ｸﾞﾙｰﾌﾟ
            editBand.Columns[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			            // 販売区分
            editBand.Columns[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;		// 売価区分
            editBand.Columns[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;		                // 得意先
            editBand.Columns[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;		                // 値引率
            editBand.Columns[this._campaignMngDataTable.RateValColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;				            // 売価率
            editBand.Columns[this._campaignMngDataTable.PriceFlColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			                // 売価額
            editBand.Columns[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			        // 価格開始日
            editBand.Columns[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			            // 価格終了日
            // ADD 陳健 2014/03/20 --------------------------------------------------------------->>>>>
            editBand.Columns[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                       // 更新日
            // ADD 陳健 2014/03/20 ---------------------------------------------------------------<<<<<          
            #endregion

            #region ●フォーマット設定
            string decimalFormat = "#,##0.00;-#,##0.00;''";
            string codeFormat1 = "#000000;-#0000000;''";
            string codeFormat2 = "#00;-#00;''";
            string codeFormat3 = "#0000;-#0000;''";
            string codeFormat4 = "#00000;-#00000;''";
            string codeFormat5 = "#00000000;-#00000000;''";

            editBand.Columns[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Format = codeFormat1;			// ｺｰﾄﾞ
            editBand.Columns[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Format = codeFormat2;		    // 拠点
            editBand.Columns[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Format = codeFormat3;		    // ﾒｰｶｰ
            editBand.Columns[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Format = codeFormat4;		    // BLｺｰﾄﾞ
            editBand.Columns[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Format = codeFormat4;			// ｸﾞﾙｰﾌﾟ
            editBand.Columns[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Format = codeFormat3;			    // 販売区分
            editBand.Columns[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Format = codeFormat5;		    // 得意先
            editBand.Columns[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Format = decimalFormat;		    // 値引率
            editBand.Columns[this._campaignMngDataTable.RateValColumn.ColumnName].Format = decimalFormat;				// 売価率
            editBand.Columns[this._campaignMngDataTable.PriceFlColumn.ColumnName].Format = decimalFormat;			    // 売価額
            editBand.Columns[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Format = codeFormat5;		    // 価格開始日
            editBand.Columns[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Format = codeFormat5;		    // 価格終了日
            // ADD 陳健 2014/03/20 --------------------------------------------------------------->>>>>
            editBand.Columns[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Format = codeFormat5;             // 更新日
            // ADD 陳健 2014/03/20 ---------------------------------------------------------------<<<<<
            #endregion

            #region ●MaxLength設定
            editBand.Columns[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].MaxLength = 6;			    // ｺｰﾄﾞ
            editBand.Columns[this._campaignMngDataTable.SectionCodeColumn.ColumnName].MaxLength = 2;		    	// 拠点
            editBand.Columns[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].MaxLength = 4;		    // ﾒｰｶｰ
            editBand.Columns[this._campaignMngDataTable.GoodsNoColumn.ColumnName].MaxLength = 24;	                // 品番
            editBand.Columns[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].MaxLength = 5;		        // BLｺｰﾄﾞ
            editBand.Columns[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].MaxLength = 5;			    // ｸﾞﾙｰﾌﾟ
            editBand.Columns[this._campaignMngDataTable.SalesCodeColumn.ColumnName].MaxLength = 4;			        // 販売区分
            editBand.Columns[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].MaxLength = 8;		        // 得意先
            editBand.Columns[this._campaignMngDataTable.DiscountRateColumn.ColumnName].MaxLength = 5;		        // 値引率
            editBand.Columns[this._campaignMngDataTable.RateValColumn.ColumnName].MaxLength = 6;				    // 売価率
            editBand.Columns[this._campaignMngDataTable.PriceFlColumn.ColumnName].MaxLength = 17;			        // 売価額
            #endregion

            #region ●DropDownList設定
            // 設定種別設定
            Infragistics.Win.ValueList list = new Infragistics.Win.ValueList();
            list.DisplayStyle = Infragistics.Win.ValueListDisplayStyle.DisplayText;
            list.DropDownListMinWidth = 0;
            list.MaxDropDownItems = 10;

            Infragistics.Win.ValueListItem listItem0 = new Infragistics.Win.ValueListItem();
            listItem0.DataValue = 1;
            listItem0.DisplayText = "1：ﾒｰｶｰ+品番";

            Infragistics.Win.ValueListItem listItem1 = new Infragistics.Win.ValueListItem();
            listItem1.DataValue = 2;
            listItem1.DisplayText = "2：ﾒｰｶｰ+BLｺｰﾄﾞ";

            Infragistics.Win.ValueListItem listItem2 = new Infragistics.Win.ValueListItem();
            listItem2.DataValue = 3;
            listItem2.DisplayText = "3：ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ";

            Infragistics.Win.ValueListItem listItem3 = new Infragistics.Win.ValueListItem();
            listItem3.DataValue = 4;
            listItem3.DisplayText = "4：ﾒｰｶｰ";

            Infragistics.Win.ValueListItem listItem4 = new Infragistics.Win.ValueListItem();
            listItem4.DataValue = 5;
            listItem4.DisplayText = "5：BLｺｰﾄﾞ";

            Infragistics.Win.ValueListItem listItem5 = new Infragistics.Win.ValueListItem();
            listItem5.DataValue = 6;
            listItem5.DisplayText = "6：販売区分";

            list.ValueListItems.Add(listItem0);
            list.ValueListItems.Add(listItem1);
            list.ValueListItems.Add(listItem2);
            list.ValueListItems.Add(listItem3);
            list.ValueListItems.Add(listItem4);
            list.ValueListItems.Add(listItem5);

            this.uGrid_Details.DisplayLayout.ValueLists.Add(list);
            editBand.Columns[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].ValueList = list;

            // 売価区分設定
            Infragistics.Win.ValueList list2 = new Infragistics.Win.ValueList();
            list2.DisplayStyle = Infragistics.Win.ValueListDisplayStyle.DisplayText;
            list2.DropDownListMinWidth = 0;
            list2.MaxDropDownItems = 10;

            Infragistics.Win.ValueListItem list2Item0 = new Infragistics.Win.ValueListItem();
            list2Item0.DataValue = 0;
            list2Item0.DisplayText = "0:無し";

            Infragistics.Win.ValueListItem list2Item1 = new Infragistics.Win.ValueListItem();
            list2Item1.DataValue = 1;
            list2Item1.DisplayText = "1:有り";

            list2.ValueListItems.Add(list2Item0);
            list2.ValueListItems.Add(list2Item1);

            this.uGrid_Details.DisplayLayout.ValueLists.Add(list2);
            editBand.Columns[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].ValueList = list2;
            #endregion

            #region ●グリッド列表示非表示設定処理
            editBand.Columns[this._campaignMngDataTable.RowNoColumn.ColumnName].Hidden = false;		            // №
            editBand.Columns[this._campaignMngDataTable.UpdateTimeColumn.ColumnName].Hidden = true;		        // 削除日
            editBand.Columns[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Hidden = false;		     	// ｺｰﾄﾞ
            editBand.Columns[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Hidden = false;			    // 名称
            editBand.Columns[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Hidden = false;		    	// 拠点
            editBand.Columns[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Hidden = false;		// 設定種別
            editBand.Columns[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Hidden = false;		    // ﾒｰｶｰ
            editBand.Columns[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Hidden = false;			// ﾒｰｶｰ名
            editBand.Columns[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Hidden = false;	                // 品番
            editBand.Columns[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Hidden = false;		        // BLｺｰﾄﾞ
            editBand.Columns[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Hidden = false;				// 品名
            editBand.Columns[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Hidden = false;			    // ｸﾞﾙｰﾌﾟ
            editBand.Columns[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Hidden = false;			    // 販売区分
            editBand.Columns[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Hidden = false;		    // 売価区分
            editBand.Columns[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Hidden = false;		        // 得意先
            editBand.Columns[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Hidden = false;		        // 値引率
            editBand.Columns[this._campaignMngDataTable.RateValColumn.ColumnName].Hidden = false;				    // 売価率
            editBand.Columns[this._campaignMngDataTable.PriceFlColumn.ColumnName].Hidden = false;			        // 売価額
            editBand.Columns[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Hidden = false;			// 価格開始日
            editBand.Columns[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Hidden = false;			    // 価格終了日
            // ADD 陳健 2014/03/20 --------------------------------------------------------------->>>>>
            editBand.Columns[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Hidden = false;               // 更新日
            // ADD 陳健 2014/03/20 ---------------------------------------------------------------<<<<<
            #endregion
        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 画面初期化処理します。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        internal void Clear(bool settingGrid)
        {
            this._campaignObjGoodsStAcs.PrevCampaignMngDic.Clear();

            this.SetButtonEnabled(1);
            // 明細DataTable行クリア処理
            this._campaignObjGoodsStAcs.CampaignMngDataTable.Rows.Clear();

            // ソート設定の解除
            this.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.Clear();

            // グリッド行初期設定処理
            this._campaignObjGoodsStAcs.DetailRowInitialSetting(1);
            this.DetailGridInitSetting();

            if (settingGrid)
            {
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._campaignMngDataTable.UpdateTimeColumn.ColumnName].Hidden = true;
            }
        }

        /// <summary>
        /// グリッド列不可入力色設定
        /// </summary>
        /// <remarks>
        /// <br>Note	   : グリッド列不可入力色設定します。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        internal void DetailGridInitSetting()
        {
            if (this.uGrid_Details == null || this.uGrid_Details.Rows.Count < 1)
            {
                return;
            }

            UltraGridRow row = this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count-1];
            
            foreach (UltraGridCell cell in row.Cells)
            {
                if (cell.Column.Key == this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName
                    || cell.Column.Key == this._campaignMngDataTable.BLGroupCodeColumn.ColumnName
                    || cell.Column.Key == this._campaignMngDataTable.SalesCodeColumn.ColumnName
                    || cell.Column.Key == this._campaignMngDataTable.CustomerCodeColumn.ColumnName
                    || cell.Column.Key == this._campaignMngDataTable.DiscountRateColumn.ColumnName
                    || cell.Column.Key == this._campaignMngDataTable.RateValColumn.ColumnName
                    || cell.Column.Key == this._campaignMngDataTable.PriceFlColumn.ColumnName
                    || cell.Column.Key == this._campaignMngDataTable.PriceStartDateColumn.ColumnName
                    || cell.Column.Key == this._campaignMngDataTable.PriceEndDateColumn.ColumnName
                    || cell.Column.Key == this._campaignMngDataTable.CampaignNameColumn.ColumnName
                    || cell.Column.Key == this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName
                    // UPD 陳健 2014/03/20 --------------------------------------------------------------->>>>>
                    || cell.Column.Key == this._campaignMngDataTable.GoodsNameColumn.ColumnName
                    || cell.Column.Key == this._campaignMngDataTable.UpdateTime2Column.ColumnName)
                    // UPD 陳健 2014/03/20 ---------------------------------------------------------------<<<<<
                {
                    cell.Activation = Activation.NoEdit;
                    cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                }
            }
        }

        /// <summary>
        /// キャンペーンコードガイド起動
        /// </summary>
        /// <param name="rowIndex">行番号</param>
        /// <remarks>
        /// <br>Note	   : キャンペーンコードガイド起動。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        internal void CampaignCodeGuide(int rowIndex)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CampaignSt campaignSt;

                // ガイド起動
                int status = this._campaignLinkAcs.CampaignStAcs.ExecuteGuid(this._enterpriseCode, out campaignSt);
                if (status == 0)
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Value = campaignSt.CampaignCode;
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Value = campaignSt.CampaignName;

                    CampaignSt campaignStObj;
                    int sts = this._campaignLinkAcs.CampaignStAcs.Read(out campaignStObj, this._enterpriseCode, campaignSt.CampaignCode);
                    {
                        // 結果セット
                        this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Value = campaignStObj.SectionCode.Trim().PadLeft(2, '0');
                    }

                    MoveNextAllowEditCell(false);
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 拠点コードガイド起動
        /// </summary>
        /// <param name="rowIndex">行番号</param>
        /// <remarks>
        /// <br>Note	   : 拠点コードガイド起動。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        internal void SectionCodeGuide(int rowIndex)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 拠点ガイド呼び出し
                SecInfoSet secInfoSet;
                int status = this._secInfoSetAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out secInfoSet);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 結果セット
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Value = secInfoSet.SectionCode.Trim().PadLeft(2, '0');

                    MoveNextAllowEditCell(false);
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// メーカーコードガイド起動
        /// </summary>
        /// <param name="rowIndex">行番号</param>
        /// <remarks>
        /// <br>Note	   : メーカーコードガイド起動。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/12 曹文傑 Redmine#22810 明細”メーカー名称”から”カナ名称”に変更の対応</br>
        /// </remarks>
        internal void GoodsMakerCodeGuide(int rowIndex)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // コードから名称へ変換
                MakerUMnt makerInfo;
                int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerInfo);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 結果セット
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Value = makerInfo.GoodsMakerCd;
                    //this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Value = makerInfo.MakerName; // DEL 2011/07/12
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Value = makerInfo.MakerKanaName; // ADD 2011/07/12

                    MoveNextAllowEditCell(false);
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ＢＬコードガイド起動
        /// </summary>
        /// <param name="rowIndex">行番号</param>
        /// <remarks>
        /// <br>Note	   : ＢＬコードガイド起動。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        internal void BLGoodsCodeGuide(int rowIndex)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // コードから名称へ変換
                BLGoodsCdUMnt blGoodsUnit;
                int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsUnit);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 結果セット
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Value = blGoodsUnit.BLGoodsCode;
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = blGoodsUnit.BLGoodsHalfName;

                    MoveNextAllowEditCell(false);
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ＢＬグループコードガイド起動
        /// </summary>
        /// <param name="rowIndex">行番号</param>
        /// <remarks>
        /// <br>Note	   : ＢＬグループコードガイド起動。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        internal void BLGroupCodeGuide(int rowIndex)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // ガイド表示
                BLGroupU blGroupUInfo;
                int status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupUInfo);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 結果セット
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Value = blGroupUInfo.BLGroupCode;

                    MoveNextAllowEditCell(false);
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 販売区分ガイド起動
        /// </summary>
        /// <param name="rowIndex">行番号</param>
        /// <remarks>
        /// <br>Note	   : 販売区分ガイド起動。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        internal void SalesCodeGuide(int rowIndex)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int userGuideDivCd_SalesCode = 71;  // 販売区分：71

                // コードから名称へ変換
                UserGdHd userGuideHdInfo;
                UserGdBd userGuideBdInfo;
                int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGuideHdInfo, out userGuideBdInfo, userGuideDivCd_SalesCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 結果セット
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Value = userGuideBdInfo.GuideCode.ToString().PadLeft(4, '0');

                    MoveNextAllowEditCell(false);
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 得意先コードガイド起動
        /// </summary>
        /// <param name="rowIndex">行番号</param>
        /// <remarks>
        /// <br>Note	   : 得意先コードガイド起動。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        internal void CustomerCodeGuide(int rowIndex)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 得意先ガイド
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                if (this._customerSearchRet != null)
                {
                    // 得意先コード
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Value = this._customerSearchRet.CustomerCode.ToString().PadLeft(8, '0');

                    MoveNextAllowEditCell(false);
                    this._customerSearchRet = null;
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 復活ボタン無効/有効設定
        /// </summary>
        /// <param name="mode">mode1,2,3</param>
        /// <remarks>
        /// <br>Note	   : 復活ボタン無効/有効設定。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        internal void SetButtonEnabled(int mode)
        {
            switch (mode)
            {
                case 1:
                    {
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Revival"].SharedProps.Enabled = false;
                        this.uButton_Revival.Enabled = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = true;
                        this.uButton_RowDelete.Enabled = true;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllRowDelete"].SharedProps.Enabled = true;
                        this.uButton_AllRowDelete.Enabled = true;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_GetPriceDate"].SharedProps.Enabled = true;
                        this.uButton_GetPriceDate.Enabled = true;
                        break;
                    }
                case 2:
                    {
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Revival"].SharedProps.Enabled = true;
                        this.uButton_Revival.Enabled = true;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = true;
                        this.uButton_RowDelete.Enabled = true;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllRowDelete"].SharedProps.Enabled = true;
                        this.uButton_AllRowDelete.Enabled = true;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_GetPriceDate"].SharedProps.Enabled = true;
                        this.uButton_GetPriceDate.Enabled = true;
                        break;
                    }
                case 3:
                    {
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Revival"].SharedProps.Enabled = false;
                        this.uButton_Revival.Enabled = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = false;
                        this.uButton_RowDelete.Enabled = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllRowDelete"].SharedProps.Enabled = false;
                        this.uButton_AllRowDelete.Enabled = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_GetPriceDate"].SharedProps.Enabled = false;
                        this.uButton_GetPriceDate.Enabled = false;
                        break;
                    }
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note        : 得意先選択時に発生します。</br>
        /// <br>Programmer	: 曹文傑</br>
        /// <br>Date		: 2011/04/26</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._customerSearchRet = null;
                return;
            }
            this._customerSearchRet = customerSearchRet;
        }

        /// <summary>
        /// グリッドNextフォーカス取得処理
        /// </summary>
        /// <param name="mode">モード(0:Tab;1;Shift + Tab)</param>
        /// <param name="rowIndex">rowIndex</param>
        /// <param name="columnKey">columnKey</param>
        /// <returns>columnIndex</returns>
        /// <remarks>
        /// <br>Note        : グリッドNextフォーカス取得を行います。</br>
        /// <br>Programmer  : 曹文傑</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private int GetNextColumnIndexByTab(int mode, int rowIndex, string columnKey)
        {
            int columnIndex = -1;
            switch (mode)
            {
                case 0:
                    #region Tab
                    if (columnKey == this._campaignMngDataTable.CampaignCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.CampaignNameColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.SectionCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.GoodsNoColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.GoodsNameColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.BLGroupCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.SalesCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.CustomerCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.DiscountRateColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.RateValColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.PriceFlColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.PriceStartDateColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.PriceEndDateColumn.ColumnName)
                    {
                        // UPD 陳健 2014/03/20 -------------------------->>>>>
                        //columnIndex = -1;
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Column.Index;
                        // UPD 陳健 2014/03/20 --------------------------<<<<<
                    }
                    // ADD 陳健 2014/03/20 --------------------------------------------------------->>>>>
                    else if (columnKey == this._campaignMngDataTable.UpdateTime2Column.ColumnName)
                    {
                        columnIndex = -1;
                    }
                    // ADD 陳健 2014/03/20 ---------------------------------------------------------<<<<<
                    break;
                    #endregion Tab
                case 1:
                    #region Shift + Tab
                    if (columnKey == this._campaignMngDataTable.CampaignCodeColumn.ColumnName)
                    {
                        columnIndex = -1;
                    }
                    else if (columnKey == this._campaignMngDataTable.CampaignNameColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.SectionCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.GoodsNoColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.GoodsNameColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.BLGroupCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.SalesCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.CustomerCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.DiscountRateColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.RateValColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.PriceFlColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.PriceStartDateColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.PriceEndDateColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Column.Index;
                    }
                    // ADD 陳健 2014/03/20 --------------------------------------------------------->>>>>
                    else if (columnKey == this._campaignMngDataTable.UpdateTime2Column.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Column.Index;
                    }
                    // ADD 陳健 2014/03/20 ---------------------------------------------------------<<<<<
                    break;
                    #endregion Shift + Tab
            }

            return columnIndex;
        }

        /// <summary>
        /// 設定種別変化時、セル変化
        /// </summary>
        /// <param name="campaignSettingKind">設定種別</param>
        /// <param name="row">桁</param>
        /// <remarks>
        /// <br>Note        : 設定種別変化時、セル変化</br>
        /// <br>Programmer  : 曹文傑</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void CampaignSettingKindChanged(string campaignSettingKind, UltraGridRow row)
        {
            switch (campaignSettingKind)
            {
                case "1：ﾒｰｶｰ+品番":
                    {
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                        this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                        if (row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Value.ToString().Trim() == string.Empty)
                        {
                            row.Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = string.Empty;
                        }
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Value = 0;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Value = 0;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Value = string.Empty;
                        this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        break;
                    }
                case "2：ﾒｰｶｰ+BLｺｰﾄﾞ":
                    {
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                        this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Value = string.Empty;
                        if ((int)row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Value == 0)
                        {
                            row.Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = string.Empty;
                        }
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Value = 0;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Value = string.Empty;
                        this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        break;
                    }
                case "3：ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ":
                    {
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                        this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Value = string.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = string.Empty;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Value = 0;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Value = string.Empty;
                        this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        break;
                    }
                case "4：ﾒｰｶｰ":
                    {
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                        this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Value = string.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = string.Empty;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Value = 0;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Value = 0;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Value = string.Empty;
                        this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        break;
                    }
                case "5：BLｺｰﾄﾞ":
                    {
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                        this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Value = 0;
                        row.Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Value = string.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Value = string.Empty;
                        if ((int)row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Value == 0)
                        {
                            row.Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = string.Empty;
                        }
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Value = 0;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Value = string.Empty;
                        this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        break;
                    }
                case "6：販売区分":
                    {
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                        this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Value = 0;
                        row.Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Value = string.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Value = string.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = string.Empty;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Value = 0;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Value = 0;
                        this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        break;
                    }
            }

            if ((int)row.Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Value == 1)
            {
                if (campaignSettingKind != "1：ﾒｰｶｰ+品番")
                {
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Value = 0;
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                }
                else
                {
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Activation = Activation.AllowEdit;
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor = Color.Empty;
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                }
            }
        }

        /// <summary>
        /// 検索処理後、設定種別より、セル変化
        /// </summary>
        /// <param name="campaignSettingKind">設定種別</param>
        /// <param name="row">桁</param>
        /// <remarks>
        /// <br>Note        : 検索処理後、設定種別より、セル変化</br>
        /// <br>Programmer  : 曹文傑</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void SetCampaignSettingKind(string campaignSettingKind, UltraGridRow row)
        {
            switch (campaignSettingKind)
            {
                case "1：ﾒｰｶｰ+品番":
                    {
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                        break;
                    }
                case "2：ﾒｰｶｰ+BLｺｰﾄﾞ":
                    {
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                        break;
                    }
                case "3：ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ":
                    {
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                        break;
                    }
                case "4：ﾒｰｶｰ":
                    {
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                        break;
                    }
                case "5：BLｺｰﾄﾞ":
                    {
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                        break;
                    }
                case "6：販売区分":
                    {
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                        break;
                    }
            }
        }

        /// <summary>
        /// 売価区分変化時、セル変化
        /// </summary>
        /// <param name="salesPriceSetDiv">売価区分</param>
        /// <param name="row">桁</param>
        /// <remarks>
        /// <br>Note        : 売価区分変化時、セル変化</br>
        /// <br>Programmer  : 曹文傑</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void SalesPriceSetDivChanged(string salesPriceSetDiv, UltraGridRow row)
        {
            int cellValue = 0;
            int.TryParse(salesPriceSetDiv, out cellValue);

            if ("1:有り".Equals(salesPriceSetDiv) || cellValue == 1)
            {
                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                // ADD 陳健 2014/03/20 --------------------------------------------------------------------->>>>>
                row.Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                // ADD 陳健 2014/03/20 ---------------------------------------------------------------------<<<<<

                if ((int)row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Value != 1)
                {
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Value = 0;
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                }
            }
            else if ("0:無し".Equals(salesPriceSetDiv) || cellValue == 0)
            {
                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                // ADD 陳健 2014/03/20 --------------------------------------------------------------------->>>>>
                row.Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                // ADD 陳健 2014/03/20 ---------------------------------------------------------------------<<<<<

                // 「0:無し」へ変更時、売価項目（得意先、値引率、売価率、売価額、価格開始日、価格終了日）を空白表示へ変更する
                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Value = "";
                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Value = 0;
                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Value = 0;
                row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Value = 0;
                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Value = 0;
                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Value = 0;
                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
            }
            else
            {
                //なし。
            }
        }

        /// <summary>
        /// 検索処理後、売価区分より、セル変化
        /// </summary>
        /// <param name="salesPriceSetDiv">売価区分</param>
        /// <param name="row">桁</param>
        /// <remarks>
        /// <br>Note        : 検索処理後、売価区分より、セル変化</br>
        /// <br>Programmer  : 曹文傑</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void SetSalesPriceSetDiv(string salesPriceSetDiv, UltraGridRow row)
        {
            if ("1:有り".Equals(salesPriceSetDiv))
            {
                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                // ADD 陳健 2014/03/20 --------------------------------------------------------------------->>>>>
                row.Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                // ADD 陳健 2014/03/20 ---------------------------------------------------------------------<<<<<

                if ((int)row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Value != 1)
                {
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                }
            }
            else if ("0:無し".Equals(salesPriceSetDiv))
            {
                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                // ADD 陳健 2014/03/20 --------------------------------------------------------------------->>>>>
                row.Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                // ADD 陳健 2014/03/20 ---------------------------------------------------------------------<<<<<
            }
            else
            {
                //なし。
            }
        }
        #endregion

        #region Public Method
        /// <summary>
        /// 変化データ取得処理
        /// </summary>
        /// <param name="delList">削除リスト</param>
        /// <param name="updList">登録リスト</param>
        /// <remarks>
        /// <br>Note        : 変化データ取得処理</br>
        /// <br>Programmer  : 曹文傑</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        public void GetSaveDate(out List<CampaignObjGoodsSt> delList, out List<CampaignObjGoodsSt> updList)
        {
            this._prevCampaignMngDic = this._campaignObjGoodsStAcs.PrevCampaignMngDic;
            List<CampaignObjGoodsSt> dList = new List<CampaignObjGoodsSt>();
            List<CampaignObjGoodsSt> uList = new List<CampaignObjGoodsSt>();

            CampaignObjGoodsSt campaignMng = new CampaignObjGoodsSt();
            CampaignObjGoodsSt campaignMngUPD = new CampaignObjGoodsSt();
            if (this._campaignMngDataTable.Rows.Count > 0)
            {
                foreach (CampaignMngDataSet.CampaignMngRow row in this._campaignMngDataTable.Rows)
                {
                    campaignMng = new CampaignObjGoodsSt();
                    this._campaignObjGoodsStAcs.CopyToCampaignMngFromDetailRow(row, ref campaignMng);
                    // 改修行の場合
                    if (_prevCampaignMngDic.ContainsKey(row.FilterGuid))
                    {
                        bool keyChanged = this._campaignObjGoodsStAcs.CompareKey(campaignMng, _prevCampaignMngDic[row.FilterGuid]);

                        // 行削除の場合
                        if (row.RowDeleteFlg == 0)
                        {
                            if (this._campaignObjGoodsStAcs.Compare(campaignMng, _prevCampaignMngDic[row.FilterGuid]))
                            {
                                dList.Add(_prevCampaignMngDic[row.FilterGuid]);
                                campaignMngUPD = campaignMng.Clone();
                                campaignMngUPD.LogicalDeleteCode = 0;
                                campaignMngUPD.GoodsMGroup = _prevCampaignMngDic[row.FilterGuid].GoodsMGroup;
                                campaignMngUPD.SalesTargetCount = _prevCampaignMngDic[row.FilterGuid].SalesTargetCount;
                                campaignMngUPD.SalesTargetMoney = _prevCampaignMngDic[row.FilterGuid].SalesTargetMoney;
                                campaignMngUPD.SalesTargetProfit = _prevCampaignMngDic[row.FilterGuid].SalesTargetProfit;
                                if (!keyChanged)
                                {
                                    campaignMngUPD.IsUpdRow = true;
                                }
                                uList.Add(campaignMngUPD);
                            }
                        }
                        else
                        {
                            campaignMng = _prevCampaignMngDic[row.FilterGuid];
                            campaignMngUPD = campaignMng.Clone();
                            campaignMngUPD.LogicalDeleteCode = 1;
                            if (!keyChanged)
                            {
                                campaignMngUPD.IsUpdRow = true;
                            }
                            uList.Add(campaignMngUPD);
                        }
                    }
                    // 新規行の場合
                    else
                    {
                        if (this._campaignObjGoodsStAcs.IsRowUpdate(row) && row.RowDeleteFlg == 0)
                        {
                            campaignMngUPD = campaignMng.Clone();
                            campaignMngUPD.EnterpriseCode = this._enterpriseCode;
                            campaignMngUPD.LogicalDeleteCode = 0;
                            campaignMngUPD.IsUpdRow = false;
                            uList.Add(campaignMngUPD);
                        }
                    }
                }
            }

            delList = dList;
            updList = uList;
        }

        /// <summary>
        /// 保存前チェック処理
        /// </summary>
        /// <param name="deleteList">削除リスト</param>
        /// <param name="updateList">更新リスト</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : 保存前チェック処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/14 曹文傑 Redmine#22962 拠点違いで登録可能にするように変更対応</br>
        /// <br>                               Redmine#22957 対象得意先に設定している場合、全得意先が入力できる</br>
        /// <br>UpdateNote : 2011/07/15 曹文傑 Redmine#22984 売価区分を異なる設定にすると、同一商品設定を重複チェック</br>
        /// <br>UpdateNote : 2011/09/05 鄧潘ハン Redmine#23965 キャンペーン管理　売上伝票入力（Delphi）の変更時の調査の対応</br>
        /// </remarks>
        public bool CheckSaveDate(out List<CampaignObjGoodsSt> deleteList, out List<CampaignObjGoodsSt> updateList)
        {
            List<CampaignObjGoodsSt> delList = new List<CampaignObjGoodsSt>();
            List<CampaignObjGoodsSt> updList = new List<CampaignObjGoodsSt>();

            this.GetSaveDate(out delList, out updList);
            deleteList = delList;
            updateList = updList;

            if (updateList.Count == 0)
            {
                return false;
            }

            #region
            if (updateList.Count != 0)
            {
                CampaignSt campaignSt = null;
                CampaignLink campaignLink = null;
                int rowIndex = -1;
                foreach (CampaignObjGoodsSt campaign in updateList)
                {
                    campaignSt = null;
                    campaignLink = null;
                    // 行削除のデータがチェックない
                    if (campaign.LogicalDeleteCode == 1)
                    {
                        continue;
                    }

                    // キャンペーン設定マスタ取得
                    if (this._campaignObjGoodsStAcs.CampaignStDic.ContainsKey(campaign.CampaignCode))
                    {
                        campaignSt = this._campaignObjGoodsStAcs.CampaignStDic[campaign.CampaignCode];
                    }

                    //行番号を取得
                    foreach (UltraGridRow row in this.uGrid_Details.Rows)
                    {
                        if (campaign.RowIndex == (int)row.Cells[this._campaignMngDataTable.RowNoColumn.ColumnName].Value)
                        {
                            rowIndex = row.Index;
                            break;
                        }
                    }

                    // キャンペーン関連マスタ取得
                    foreach (CampaignLink work in this._campaignObjGoodsStAcs.CampaignLinkList)
                    {
                        if (work.CampaignCode == campaign.CampaignCode && work.CustomerCode == campaign.CustomerCode)
                        {
                            campaignLink = work;
                            break;
                        }
                    }

                    // キャンペーンコードを入力チェック
                    if (campaign.CampaignCode == 0)
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "キャンペーンコードを入力して下さい。",
                             0,
                             MessageBoxButtons.OK);
                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;

                    }
                    // メーカーコードを入力チェック
                    if (campaign.GoodsMakerCd == 0
                        && (campaign.CampaignSettingKind == 1
                            || campaign.CampaignSettingKind == 2
                            || campaign.CampaignSettingKind == 3
                            || campaign.CampaignSettingKind == 4))
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "メーカーコードを入力して下さい。",
                             0,
                             MessageBoxButtons.OK);
                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }
                    // 品番を入力チェック
                    if (string.IsNullOrEmpty(campaign.GoodsNo.Trim()) && campaign.CampaignSettingKind == 1)
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "品番を入力して下さい。",
                             0,
                             MessageBoxButtons.OK);
                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }
                    // ＢＬコードを入力チェック
                    if (campaign.BLGoodsCode == 0
                        && (campaign.CampaignSettingKind == 2
                            || campaign.CampaignSettingKind == 5))
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "ＢＬコードを入力して下さい。",
                             0,
                             MessageBoxButtons.OK);
                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }
                    // グループコードを入力チェック
                    if (campaign.BLGroupCode == 0
                        && campaign.CampaignSettingKind == 3)
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "グループコードを入力して下さい。",
                             0,
                             MessageBoxButtons.OK);
                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }
                    // 販売区分を入力チェック
                    if (this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Value.ToString().Trim() == string.Empty
                        && campaign.CampaignSettingKind == 6)
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "販売区分を入力して下さい。",
                             0,
                             MessageBoxButtons.OK);
                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }

                    // 売価区分＝１の場合
                    // ---UPD 2011/07/14---------------->>>>>
                    // ---UPD 2011/09/05---------------->>>>>
                    if (campaign.SalesPriceSetDiv == 1)
                    //if (campaign.SalesPriceSetDiv == 1 && campaign.CustomerCode != 0)
                    // ---UPD 2011/09/05----------------<<<<<
                    // ---UPD 2011/07/14----------------<<<<<
                    {
                        if (campaignSt != null)
                        {
                            // ｷｬﾝﾍﾟｰﾝ設定ﾏｽﾀ.ｷｬﾝﾍﾟｰﾝ対象区分=1:対象得意先
                            if (campaignSt.CampaignObjDiv == 1)
                            {
                                // ｷｬﾝﾍﾟｰﾝ関連ﾏｽﾀ.得意先≠得意先の場合、エラー
                                // ---UPD 2011/09/05---------------->>>>>
                                if (campaignLink == null && campaign.CustomerCode != 0)
                                //if (campaignLink == null)
                                // ---UPD 2011/09/05----------------<<<<<
                                {
                                    TMsgDisp.Show(
                                         this,
                                         emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                         this.Name,
                                         "対象外の得意先です。",
                                         0,
                                         MessageBoxButtons.OK);
                                    if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                                    {
                                        this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Activate();
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    return false;
                                }
                            }
                        }

                        // 値引率、売価率を入力チェック
                        // ---UPD 2011/07/15------------->>>>>
                        //if (campaign.CampaignSettingKind == 3
                        //    || campaign.CampaignSettingKind == 4
                        //    || campaign.CampaignSettingKind == 5
                        //    || campaign.CampaignSettingKind == 6)
                        if (campaign.CampaignSettingKind == 2
                            || campaign.CampaignSettingKind == 3
                            || campaign.CampaignSettingKind == 4
                            || campaign.CampaignSettingKind == 5
                            || campaign.CampaignSettingKind == 6)
                        // ---UPD 2011/07/15-------------<<<<<
                        {
                            if (campaign.RateVal == 0 && campaign.DiscountRate == 0)
                            {
                                TMsgDisp.Show(
                                     this,
                                     emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                     this.Name,
                                     "値引率または売価率を入力して下さい。",
                                     0,
                                     MessageBoxButtons.OK);
                                if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                                {
                                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                return false;
                            }
                        }

                        // 設定種別＝1：ﾒｰｶｰ+品番の場合のみチェック
                        if (campaign.CampaignSettingKind == 1)
                        {
                            if (campaign.RateVal == 0 && campaign.PriceFl == 0 && campaign.DiscountRate == 0)
                            {
                                TMsgDisp.Show(
                                     this,
                                     emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                     this.Name,
                                     "値引率、売価率、売価額のいずれかを入力して下さい。",
                                     0,
                                     MessageBoxButtons.OK);
                                if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                                {
                                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                return false;
                            }
                            if (campaign.DiscountRate != 0 && campaign.PriceFl != 0)
                            {
                                TMsgDisp.Show(
                                     this,
                                     emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                     this.Name,
                                     "値引率と売価額は両方設定できません。",
                                     0,
                                     MessageBoxButtons.OK);
                                if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                                {
                                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                return false;
                            }
                            if (campaign.RateVal != 0 && campaign.PriceFl != 0)
                            {
                                TMsgDisp.Show(
                                     this,
                                     emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                     this.Name,
                                     "売価率と売価額は両方設定できません。",
                                     0,
                                     MessageBoxButtons.OK);
                                if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                                {
                                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                return false;
                            }
                        }

                        if (campaign.DiscountRate != 0 && campaign.RateVal != 0)
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "値引率と売価率は両方設定できません。",
                                 0,
                                 MessageBoxButtons.OK);
                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }

                        // 価格開始日を入力チェック
                        if (campaign.PriceStartDate == 0)
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "価格開始日を入力して下さい。",
                                 0,
                                 MessageBoxButtons.OK);
                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }

                        // 価格日の範囲チェック
                        if (campaign.PriceStartDate > campaign.PriceEndDate && campaign.PriceEndDate != 0)
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "価格日の範囲指定に誤りがあります。",
                                 0,
                                 MessageBoxButtons.OK);
                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }

                        // キャンペーンの適用日範囲外チェック
                        if (campaignSt != null)
                        {
                            if (Convert.ToInt32(campaignSt.ApplyStaDate.Date.ToString("yyyyMMdd")) > campaign.PriceStartDate)
                            {
                                TMsgDisp.Show(
                                     this,
                                     emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                     this.Name,
                                     "キャンペーンの適用日範囲外です。",
                                     0,
                                     MessageBoxButtons.OK);
                                if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                                {
                                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                return false;
                            }
                        }

                        // 価格終了日を入力チェック
                        if (campaign.PriceEndDate == 0)
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "価格終了日を入力して下さい。",
                                 0,
                                 MessageBoxButtons.OK);
                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }

                        // キャンペーンの適用日範囲外チェック
                        if (campaignSt != null)
                        {
                            if (Convert.ToInt32(campaignSt.ApplyEndDate.Date.ToString("yyyyMMdd")) < campaign.PriceEndDate)
                            {
                                TMsgDisp.Show(
                                     this,
                                     emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                     this.Name,
                                     "キャンペーンの適用日範囲外です。",
                                     0,
                                     MessageBoxButtons.OK);
                                if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                                {
                                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                return false;
                            }
                        }
                    }
                }
            }

            if (updateList.Count != 0)
            {
                CampaignSt campaignSt = null;
                CampaignLink campaignLink = null;
                int rowIndex = -1;
                foreach (CampaignObjGoodsSt campaign in updateList)
                {
                    // 行削除のデータがチェックない
                    if (campaign.LogicalDeleteCode == 1)
                    {
                        continue;
                    }

                    // キャンペーン設定マスタ取得
                    if (this._campaignObjGoodsStAcs.CampaignStDic.ContainsKey(campaign.CampaignCode))
                    {
                        campaignSt = this._campaignObjGoodsStAcs.CampaignStDic[campaign.CampaignCode];
                    }

                    //行番号を取得
                    foreach (UltraGridRow row in this.uGrid_Details.Rows)
                    {
                        if (campaign.RowIndex == (int)row.Cells[this._campaignMngDataTable.RowNoColumn.ColumnName].Value)
                        {
                            rowIndex = row.Index;
                            break;
                        }
                    }

                    // キャンペーン関連マスタ取得
                    foreach (CampaignLink work in this._campaignObjGoodsStAcs.CampaignLinkList)
                    {
                        if (work.CampaignCode == campaign.CampaignCode && work.CustomerCode == campaign.CustomerCode)
                        {
                            campaignLink = work;
                            break;
                        }
                    }

                    int flag = 0;
                    string errorMsg = string.Empty;

                    #region 売価区分「0:無し」の場合、重複レコードの存在チェック
                    if (campaign.SalesPriceSetDiv == 0)
                    {
                        foreach (CampaignMngDataSet.CampaignMngRow row in this._campaignMngDataTable.Rows)
                        {
                            if (row.FilterGuid == Guid.Empty && row.RowDeleteFlg == 1)
                            {
                                continue;
                            }
                            // ---UPD 2011/07/15---------------->>>>>
                            //if (row.SalesPriceSetDiv == 0)
                            //{
                                // ---UPD 2011/07/14------------------>>>>>
                                //if (row.CampaignCode == campaign.CampaignCode && row.CampaignSettingKind == campaign.CampaignSettingKind)
                                if (row.CampaignCode == campaign.CampaignCode
                                    && row.CampaignSettingKind == campaign.CampaignSettingKind
                                    && row.SectionCode == campaign.SectionCode)
                                // ---UPD 2011/07/14------------------<<<<<
                                {
                                    switch (campaign.CampaignSettingKind)
                                    {
                                        case 1:
                                            {
                                                if ((campaign.GoodsMakerCd == row.GoodsMakerCode) && (campaign.GoodsNo.Trim() == row.GoodsNo.Trim()))
                                                {
                                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "、設定種別 1：ﾒｰｶｰ+品番、ﾒｰｶｰ：" + campaign.GoodsMakerCd.ToString().PadLeft(4, '0') + "、品番：" + campaign.GoodsNo.Trim();
                                                    flag++;
                                                }
                                                break;
                                            }
                                        case 2:
                                            {
                                                if ((campaign.GoodsMakerCd == row.GoodsMakerCode) && (campaign.BLGoodsCode == row.BLGoodsCode))
                                                {
                                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "、設定種別 2：ﾒｰｶｰ+BLｺｰﾄﾞ、ﾒｰｶｰ：" + campaign.GoodsMakerCd.ToString().PadLeft(4, '0') + "、BLｺｰﾄﾞ：" + campaign.BLGoodsCode.ToString().PadLeft(5, '0');
                                                    flag++;
                                                }
                                                break;
                                            }
                                        case 3:
                                            {
                                                if ((campaign.GoodsMakerCd == row.GoodsMakerCode) && (campaign.BLGroupCode == row.BLGroupCode))
                                                {
                                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "、設定種別 3：ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ、ﾒｰｶｰ：" + campaign.GoodsMakerCd.ToString().PadLeft(4, '0') + "、ｸﾞﾙｰﾌﾟ：" + campaign.BLGroupCode.ToString().PadLeft(5, '0');
                                                    flag++;
                                                }
                                                break;
                                            }
                                        case 4:
                                            {
                                                if (campaign.GoodsMakerCd == row.GoodsMakerCode)
                                                {
                                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "、設定種別 4：ﾒｰｶｰ、ﾒｰｶｰ：" + campaign.GoodsMakerCd.ToString().PadLeft(4, '0');
                                                    flag++;
                                                }
                                                break;
                                            }
                                        case 5:
                                            {
                                                if (campaign.BLGoodsCode == row.BLGoodsCode)
                                                {
                                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "、設定種別 5：BLｺｰﾄﾞ、BLｺｰﾄﾞ：" + campaign.BLGoodsCode.ToString().PadLeft(5, '0');
                                                    flag++;
                                                }
                                                break;
                                            }
                                        case 6:
                                            {
                                                int inputValue = 0;
                                                int.TryParse(row.SalesCode, out inputValue);
                                                if (campaign.SalesCode == inputValue)
                                                {
                                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "、設定種別 6：販売区分、販売区分：" + campaign.SalesCode.ToString().PadLeft(4, '0');
                                                    flag++;
                                                }
                                                break;
                                            }
                                    }
                                    if (flag > 1)
                                    {
                                        TMsgDisp.Show(
                                             this,
                                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                             this.Name,
                                             "同一の商品設定が既に登録されています。" + "\r\n" +
                                             errorMsg,
                                             0,
                                             MessageBoxButtons.OK);
                                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                                        {
                                            this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                        return false;
                                    }
                                }
                            //}
                            // ---UPD 2011/07/15----------------<<<<<
                        }
                    }
                    #endregion 売価区分「0:無し」の場合、重複レコードの存在チェック

                    #region 売価区分「1:有り」の場合、重複レコードの存在チェック
                    if (campaign.SalesPriceSetDiv == 1)
                    {
                        flag = 0;
                        int flag2 = 0;
                        foreach (CampaignMngDataSet.CampaignMngRow row in this._campaignMngDataTable.Rows)
                        {
                            if (row.FilterGuid == Guid.Empty && row.RowDeleteFlg == 1)
                            {
                                continue;
                            }

                            if (row.SalesPriceSetDiv == 1)
                            {
                                if (row.SectionCode.Trim().PadLeft(2, '0') == campaign.SectionCode.Trim().PadLeft(2, '0')
                                    && row.CampaignSettingKind == campaign.CampaignSettingKind
                                    && row.CustomerCode.Trim().PadLeft(8, '0') == campaign.CustomerCode.ToString().PadLeft(8, '0'))
                                {
                                    switch (campaign.CampaignSettingKind)
                                    {
                                        case 1:
                                            {
                                                if ((campaign.GoodsMakerCd == row.GoodsMakerCode) && (campaign.GoodsNo.Trim() == row.GoodsNo.Trim()))
                                                {
                                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "、設定種別 1：ﾒｰｶｰ+品番、ﾒｰｶｰ：" + campaign.GoodsMakerCd.ToString().PadLeft(4, '0') + "、品番：" + campaign.GoodsNo.Trim() + "、得意先：" + campaign.CustomerCode.ToString().PadLeft(8, '0') + "、価格日：" + campaign.PriceStartDate.ToString().PadLeft(6, '0') + "～" + campaign.PriceEndDate.ToString().PadLeft(6, '0');
                                                    if ((row.PriceStartDate <= campaign.PriceStartDate
                                                        && campaign.PriceStartDate <= row.PriceEndDate)
                                                        || (row.PriceStartDate <= campaign.PriceEndDate
                                                        && campaign.PriceEndDate <= row.PriceEndDate))
                                                    {
                                                        flag++;
                                                    }
                                                }
                                                break;
                                            }
                                        case 2:
                                            {
                                                if ((campaign.GoodsMakerCd == row.GoodsMakerCode) && (campaign.BLGoodsCode == row.BLGoodsCode))
                                                {
                                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "、設定種別 2：ﾒｰｶｰ+BLｺｰﾄﾞ、ﾒｰｶｰ：" + campaign.GoodsMakerCd.ToString().PadLeft(4, '0') + "、BLｺｰﾄﾞ：" + campaign.BLGoodsCode.ToString().PadLeft(5, '0') + "、得意先：" + campaign.CustomerCode.ToString().PadLeft(8, '0') + "、価格日：" + campaign.PriceStartDate.ToString().PadLeft(6, '0') + "～" + campaign.PriceEndDate.ToString().PadLeft(6, '0');
                                                    if ((row.PriceStartDate <= campaign.PriceStartDate
                                                        && campaign.PriceStartDate <= row.PriceEndDate)
                                                        || (row.PriceStartDate <= campaign.PriceEndDate
                                                        && campaign.PriceEndDate <= row.PriceEndDate))
                                                    {
                                                        flag++;
                                                    }
                                                }
                                                break;
                                            }
                                        case 3:
                                            {
                                                if ((campaign.GoodsMakerCd == row.GoodsMakerCode) && (campaign.BLGroupCode == row.BLGroupCode))
                                                {
                                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "、設定種別 3：ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ、ﾒｰｶｰ：" + campaign.GoodsMakerCd.ToString().PadLeft(4, '0') + "、ｸﾞﾙｰﾌﾟ：" + campaign.BLGroupCode.ToString().PadLeft(5, '0') + "、得意先：" + campaign.CustomerCode.ToString().PadLeft(8, '0') + "、価格日：" + campaign.PriceStartDate.ToString().PadLeft(6, '0') + "～" + campaign.PriceEndDate.ToString().PadLeft(6, '0');
                                                    if ((row.PriceStartDate <= campaign.PriceStartDate
                                                        && campaign.PriceStartDate <= row.PriceEndDate)
                                                        || (row.PriceStartDate <= campaign.PriceEndDate
                                                        && campaign.PriceEndDate <= row.PriceEndDate))
                                                    {
                                                        flag++;
                                                    }
                                                }
                                                break;
                                            }
                                        case 4:
                                            {
                                                if (campaign.GoodsMakerCd == row.GoodsMakerCode)
                                                {
                                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "、設定種別 4：ﾒｰｶｰ、ﾒｰｶｰ：" + campaign.GoodsMakerCd.ToString().PadLeft(4, '0') + "、得意先：" + campaign.CustomerCode.ToString().PadLeft(8, '0') + "、価格日：" + campaign.PriceStartDate.ToString().PadLeft(6, '0') + "～" + campaign.PriceEndDate.ToString().PadLeft(6, '0');
                                                    if ((row.PriceStartDate <= campaign.PriceStartDate
                                                        && campaign.PriceStartDate <= row.PriceEndDate)
                                                        || (row.PriceStartDate <= campaign.PriceEndDate
                                                        && campaign.PriceEndDate <= row.PriceEndDate))
                                                    {
                                                        flag++;
                                                    }
                                                }
                                                break;
                                            }
                                        case 5:
                                            {
                                                if (campaign.BLGoodsCode == row.BLGoodsCode)
                                                {
                                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "、設定種別 5：BLｺｰﾄﾞ、BLｺｰﾄﾞ：" + campaign.BLGoodsCode.ToString().PadLeft(5, '0') + "、得意先：" + campaign.CustomerCode.ToString().PadLeft(8, '0') + "、価格日：" + campaign.PriceStartDate.ToString().PadLeft(6, '0') + "～" + campaign.PriceEndDate.ToString().PadLeft(6, '0');
                                                    if ((row.PriceStartDate <= campaign.PriceStartDate
                                                        && campaign.PriceStartDate <= row.PriceEndDate)
                                                        || (row.PriceStartDate <= campaign.PriceEndDate
                                                        && campaign.PriceEndDate <= row.PriceEndDate))
                                                    {
                                                        flag++;
                                                    }
                                                }
                                                break;
                                            }
                                        case 6:
                                            {
                                                if (campaign.SalesCode == Convert.ToInt32(row.SalesCode))
                                                {
                                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "、設定種別 6：販売区分、販売区分：" + campaign.SalesCode.ToString().PadLeft(4, '0') + "、得意先：" + campaign.CustomerCode.ToString().PadLeft(8, '0') + "、価格日：" + campaign.PriceStartDate.ToString().PadLeft(6, '0') + "～" + campaign.PriceEndDate.ToString().PadLeft(6, '0');
                                                    if ((row.PriceStartDate <= campaign.PriceStartDate
                                                        && campaign.PriceStartDate <= row.PriceEndDate)
                                                        || (row.PriceStartDate <= campaign.PriceEndDate
                                                        && campaign.PriceEndDate <= row.PriceEndDate))
                                                    {
                                                        flag++;
                                                    }
                                                }
                                                break;
                                            }
                                    }
                                    if (flag > 1)
                                    {
                                        TMsgDisp.Show(
                                             this,
                                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                             this.Name,
                                             "同一の商品設定が既に登録されています。" + "\r\n" +
                                             errorMsg,
                                             0,
                                             MessageBoxButtons.OK);
                                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                                        {
                                            this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                if (row.CampaignCode == campaign.CampaignCode
                                       && row.CampaignSettingKind == campaign.CampaignSettingKind
                                       && row.SectionCode == campaign.SectionCode)
                                {
                                    switch (campaign.CampaignSettingKind)
                                    {
                                        case 1:
                                            {
                                                if ((campaign.GoodsMakerCd == row.GoodsMakerCode) && (campaign.GoodsNo.Trim() == row.GoodsNo.Trim()))
                                                {
                                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "、設定種別 1：ﾒｰｶｰ+品番、ﾒｰｶｰ：" + campaign.GoodsMakerCd.ToString().PadLeft(4, '0') + "、品番：" + campaign.GoodsNo.Trim();
                                                    flag2++;
                                                }
                                                break;
                                            }
                                        case 2:
                                            {
                                                if ((campaign.GoodsMakerCd == row.GoodsMakerCode) && (campaign.BLGoodsCode == row.BLGoodsCode))
                                                {
                                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "、設定種別 2：ﾒｰｶｰ+BLｺｰﾄﾞ、ﾒｰｶｰ：" + campaign.GoodsMakerCd.ToString().PadLeft(4, '0') + "、BLｺｰﾄﾞ：" + campaign.BLGoodsCode.ToString().PadLeft(5, '0');
                                                    flag2++;
                                                }
                                                break;
                                            }
                                        case 3:
                                            {
                                                if ((campaign.GoodsMakerCd == row.GoodsMakerCode) && (campaign.BLGroupCode == row.BLGroupCode))
                                                {
                                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "、設定種別 3：ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ、ﾒｰｶｰ：" + campaign.GoodsMakerCd.ToString().PadLeft(4, '0') + "、ｸﾞﾙｰﾌﾟ：" + campaign.BLGroupCode.ToString().PadLeft(5, '0');
                                                    flag2++;
                                                }
                                                break;
                                            }
                                        case 4:
                                            {
                                                if (campaign.GoodsMakerCd == row.GoodsMakerCode)
                                                {
                                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "、設定種別 4：ﾒｰｶｰ、ﾒｰｶｰ：" + campaign.GoodsMakerCd.ToString().PadLeft(4, '0');
                                                    flag2++;
                                                }
                                                break;
                                            }
                                        case 5:
                                            {
                                                if (campaign.BLGoodsCode == row.BLGoodsCode)
                                                {
                                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "、設定種別 5：BLｺｰﾄﾞ、BLｺｰﾄﾞ：" + campaign.BLGoodsCode.ToString().PadLeft(5, '0');
                                                    flag2++;
                                                }
                                                break;
                                            }
                                        case 6:
                                            {
                                                int inputValue = 0;
                                                int.TryParse(row.SalesCode, out inputValue);
                                                if (campaign.SalesCode == inputValue)
                                                {
                                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "、設定種別 6：販売区分、販売区分：" + campaign.SalesCode.ToString().PadLeft(4, '0');
                                                    flag2++;
                                                }
                                                break;
                                            }
                                    }
                                    if (flag2 > 0)
                                    {
                                        TMsgDisp.Show(
                                             this,
                                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                             this.Name,
                                             "同一の商品設定が既に登録されています。" + "\r\n" +
                                             errorMsg,
                                             0,
                                             MessageBoxButtons.OK);
                                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                                        {
                                            this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                        return false;
                                    }
                                } 
                            }
                        }
                    }
                    #endregion 売価区分「1:有り」の場合、重複レコードの存在チェック
                }
            }
            #endregion

            return true;
        }


        // ----- ADD 2011/07/06 ------- >>>>>>>>>
        /// <summary>
        /// DOWN前チェック処理
        /// </summary>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : 保存前チェック処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2011/07/06</br>
        /// <br>UpdateNote : 2011/07/11 譚洪 Redmine#22776 行追加の得意先のチェックに関しての修正</br>
        /// <br>UpdateNote : 2011/07/14 曹文傑 Redmine#22957 対象得意先に設定している場合、全得意先が入力できる</br>
        /// </remarks>
        public bool CheckDateForDown()
        {
            CampaignMngDataSet.CampaignMngRow row = (CampaignMngDataSet.CampaignMngRow)this._campaignMngDataTable.Rows[this._campaignMngDataTable.Count - 1];
            // 行削除のデータがチェックない
            if (row.RowDeleteFlg == 1)
            {
                return true;
            }

            CampaignObjGoodsSt campaign = new CampaignObjGoodsSt();
            this._campaignObjGoodsStAcs.CopyToCampaignMngFromDetailRow((CampaignMngDataSet.CampaignMngRow)this._campaignMngDataTable.Rows[this._campaignMngDataTable.Count - 1], ref campaign);

            // 行削除のデータがチェックない
            if (campaign.LogicalDeleteCode == 1)
            {
                return true;
            }

            CampaignSt campaignSt = null;
            //CampaignLink campaignLink = null;  // DEL 2011/07/11

            // キャンペーン設定マスタ取得
            if (this._campaignObjGoodsStAcs.CampaignStDic.ContainsKey(campaign.CampaignCode))
            {
                campaignSt = this._campaignObjGoodsStAcs.CampaignStDic[campaign.CampaignCode];
            }

            // ----- DEL 2011/07/11 ------- >>>>>>>>>
            // キャンペーン関連マスタ取得
            //foreach (CampaignLink work in this._campaignObjGoodsStAcs.CampaignLinkList)
            //{
            //    if (work.CampaignCode == campaign.CampaignCode && work.CustomerCode == campaign.CustomerCode)
            //    {
            //        campaignLink = work;
            //        break;
            //    }
            //}
            // ----- DEL 2011/07/11 ------- <<<<<<<<<

            // キャンペーンコードを入力チェック
            if (campaign.CampaignCode == 0)
            {
                return false;
            }

            // メーカーコードを入力チェック
            if (campaign.GoodsMakerCd == 0
                && (campaign.CampaignSettingKind == 1
                    || campaign.CampaignSettingKind == 2
                    || campaign.CampaignSettingKind == 3
                    || campaign.CampaignSettingKind == 4))
            {
                return false;
            }

            // 品番を入力チェック
            if (string.IsNullOrEmpty(campaign.GoodsNo.Trim()) && campaign.CampaignSettingKind == 1)
            {
                return false;
            }

            // ＢＬコードを入力チェック
            if (campaign.BLGoodsCode == 0
                && (campaign.CampaignSettingKind == 2
                    || campaign.CampaignSettingKind == 5))
            {
                return false;
            }

            // グループコードを入力チェック
            if (campaign.BLGroupCode == 0
                && campaign.CampaignSettingKind == 3)
            {
                return false;
            }

            // 販売区分を入力チェック
            if (campaign.SalesCode == 0
                && campaign.CampaignSettingKind == 6)
            {
                return false;
            }

            // 売価区分＝１の場合
            if (campaign.SalesPriceSetDiv == 1)
            {
                if (campaignSt != null)
                {
                    // ｷｬﾝﾍﾟｰﾝ設定ﾏｽﾀ.ｷｬﾝﾍﾟｰﾝ対象区分=1:対象得意先
                    if (campaignSt.CampaignObjDiv == 1)
                    {
                        // ----- UPD 2011/07/11 ------- >>>>>>>>>
                        // ｷｬﾝﾍﾟｰﾝ関連ﾏｽﾀ.得意先≠得意先の場合、エラー
                        //if (campaignLink == null)
                        //{
                        //    return false;
                        //}
                        // ---UPD 2011/07/14------------->>>>>
                        //if (campaign.CustomerCode == 0)
                        //{
                        //    return false;
                        //}

                        if (string.IsNullOrEmpty(this._campaignMngDataTable[this._campaignMngDataTable.Count - 1].CustomerCode.Trim()))
                        {
                            return false;
                        }
                        // ---UPD 2011/07/14-------------<<<<<
                        // ----- UPD 2011/07/11 ------- <<<<<<<<<
                    }
                }

                // 値引率、売価率を入力チェック
                if (campaign.CampaignSettingKind == 3
                    || campaign.CampaignSettingKind == 4
                    || campaign.CampaignSettingKind == 5
                    || campaign.CampaignSettingKind == 6)
                {
                    if (campaign.RateVal == 0 && campaign.DiscountRate == 0)
                    {
                        return false;
                    }
                }

                // 設定種別＝1：ﾒｰｶｰ+品番の場合のみチェック
                if (campaign.CampaignSettingKind == 1)
                {
                    if (campaign.RateVal == 0 && campaign.PriceFl == 0 && campaign.DiscountRate == 0)
                    {
                        return false;
                    }

                    if (campaign.DiscountRate != 0 && campaign.PriceFl != 0)
                    {
                        return false;
                    }

                    if (campaign.RateVal != 0 && campaign.PriceFl != 0)
                    {
                        return false;
                    }
                }

                if (campaign.DiscountRate != 0 && campaign.RateVal != 0)
                {
                    return false;
                }

                // 価格開始日を入力チェック
                if (campaign.PriceStartDate == 0)
                {
                    return false;
                }

                // 価格日の範囲チェック
                if (campaign.PriceStartDate > campaign.PriceEndDate && campaign.PriceEndDate != 0)
                {
                    return false;
                }

                // キャンペーンの適用日範囲外チェック
                if (campaignSt != null)
                {
                    if (Convert.ToInt32(campaignSt.ApplyStaDate.Date.ToString("yyyyMMdd")) > campaign.PriceStartDate)
                    {
                        return false;
                    }
                }

                // 価格終了日を入力チェック
                if (campaign.PriceEndDate == 0)
                {
                    return false;
                }

                // キャンペーンの適用日範囲外チェック
                if (campaignSt != null)
                {
                    if (Convert.ToInt32(campaignSt.ApplyEndDate.Date.ToString("yyyyMMdd")) < campaign.PriceEndDate)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        // ----- ADD 2011/07/06 ------- <<<<<<<<<

        /// <summary>
        /// 保存前チェック処理（削除指定区分＝１）
        /// </summary>
        /// <param name="deleteList">削除リスト</param>
        /// <param name="updateList">更新リスト</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : 保存前チェック処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public void ReturnSaveDate(out List<CampaignObjGoodsSt> deleteList, out List<CampaignObjGoodsSt> updateList)
        {
            this._prevCampaignMngDic = this._campaignObjGoodsStAcs.PrevCampaignMngDic;
            List<CampaignObjGoodsSt> delList = new List<CampaignObjGoodsSt>();
            List<CampaignObjGoodsSt> updList = new List<CampaignObjGoodsSt>();

            CampaignObjGoodsSt campaignMng = new CampaignObjGoodsSt();
            CampaignObjGoodsSt campaignMngUPD = new CampaignObjGoodsSt();
            if (this._campaignMngDataTable.Rows.Count > 0)
            {
                foreach (CampaignMngDataSet.CampaignMngRow row in this._campaignMngDataTable.Rows)
                {
                    this._campaignObjGoodsStAcs.CopyToCampaignMngFromDetailRow(row, ref campaignMng);
                    if (row.RowDeleteFlg == 1)
                    {
                        delList.Add(this._prevCampaignMngDic[row.FilterGuid]);
                    }
                    else if (row.RowDeleteFlg == 2)
                    {
                        campaignMng = this._prevCampaignMngDic[row.FilterGuid];
                        campaignMngUPD = campaignMng.Clone();
                        campaignMngUPD.LogicalDeleteCode = 0;
                        updList.Add(campaignMngUPD);
                    }
                }
            }

            deleteList = delList;
            updateList = updList;
        }

        /// <summary>
        /// 検索後、明細部設定処理
        /// </summary>
        /// <param name="deleteFlg">削除指定区分</param>
        /// <remarks>
        /// <br>Note       : 検索後、明細部設定処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/12 曹文傑 Redmine#22919 ①初回起動時の文字サイズと項目幅の変更</br>
        /// <br>　　　　　　　　　　　　　　　　　　　　　 ②明細のキャンペーンコードに初期表示するように変更</br>
        /// </remarks>
        public void GridSettingAfterSearch(bool deleteFlg)
        {
            //削除指定区分:0
            if (deleteFlg == false)
            {
                this.SetButtonEnabled(1);
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._campaignMngDataTable.UpdateTimeColumn.ColumnName].Hidden = true;
                foreach (UltraGridRow row in this.uGrid_Details.Rows)
                {
                    row.Cells[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                    row.Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                    if (!Guid.Empty.Equals((Guid)row.Cells[this._campaignMngDataTable.FilterGuidColumn.ColumnName].Value))
                    {
                        row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                    }
                    else
                    {
                        row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Activation = Activation.AllowEdit;
                    }
                    // ADD 陳健 214/03/20---------------------------------------------------------------------------------->>>>>
                    row.Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Activation = Activation.NoEdit;
                    // ADD 陳健 214/03/20----------------------------------------------------------------------------------<<<<<
                    row.Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                    row.Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                    this.SetCampaignSettingKind(this.uGrid_Details.Rows[row.Index].Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Text, row);
                    row.Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Activation = Activation.AllowEdit;
                    this.SetSalesPriceSetDiv(this.uGrid_Details.Rows[row.Index].Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Text, row);
                }
            }
            //削除指定区分:1
            else
            {
                this.SetButtonEnabled(2);
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._campaignMngDataTable.UpdateTimeColumn.ColumnName].Hidden = false;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._campaignMngDataTable.UpdateTimeColumn.ColumnName].CellAppearance.ForeColor = Color.Red;
                foreach (UltraGridRow row in this.uGrid_Details.Rows)
                {
                    foreach (UltraGridCell cell in row.Cells)
                    {
                        if (cell.Column.Key != this._campaignMngDataTable.RowNoColumn.ColumnName)
                        {
                            cell.Appearance.BackColor = ct_DISABLE_COLOR;
                            cell.Appearance.BackColor2 = ct_DISABLE_COLOR;
                            cell.Activation = Activation.NoEdit;
                        }
                    }
                }
            }

            //this.SetFocusAfterSearch();  // DEL 2011/07/12
        }

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : 次入力可能セル移動処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/06 譚洪 Redmine#22776 キャンペーン対象商品設定マスタ／追加行の対応</br>
        /// <br>UpdateNote : 2011/07/12 曹文傑 Redmine#22919 ①初回起動時の文字サイズと項目幅の変更</br>
        /// <br>UpdateNote : 2011/07/14 曹文傑 Redmine#22984 最終行の情報がデータ登録されない</br>
        /// <br>UpdateNote : 2011/07/21 譚洪 Redmine#23119 最終明細行でのフォーカス遷移不正の修正</br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            try
            {
                // 更新開始（描画ストップ）
                this.uGrid_Details.BeginUpdate();

                if ((activeCellCheck) && (this.uGrid_Details.ActiveCell != null))
                {
                    if ((!this.uGrid_Details.ActiveCell.Column.Hidden) &&
                        (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                }

                while (!moved)
                {
                    if (this.uGrid_Details.ActiveRow.Index == this._campaignMngDataTable.Count - 1)
                    {
                        if ((Int32)this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Value == 0)
                        {
                            if (this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName.Equals(this.uGrid_Details.ActiveCell.Column.Key)
                                || this._campaignMngDataTable.PriceEndDateColumn.ColumnName.Equals(this.uGrid_Details.ActiveCell.Column.Key))
                            {
                                if (this._campaignObjGoodsStAcs.DeleteSearchMode == false)
                                {
                                    // ----- UPD 2011/07/06 ------- >>>>>>>>>
                                    if (CheckDateForDown())
                                    {
                                        #region 最終行の場合、新規行を追加する
                                        CampaignMngDataSet.CampaignMngRow newRow = this._campaignMngDataTable.NewCampaignMngRow();
                                        newRow.RowNo = this.uGrid_Details.Rows.Count + 1;
                                        newRow.FilterGuid = Guid.Empty;
                                        newRow.SectionCode = "00";
                                        newRow.GoodsName = "";
                                        newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");

                                        this._campaignMngDataTable.AddCampaignMngRow(newRow);

                                        this.DetailGridInitSetting();
                                        // ---ADD 2011/07/12------------------>>>>>
                                        string campaignCode = string.Empty;
                                        string campaignName = string.Empty;
                                        string sectionCode = string.Empty;
                                        this.GetCampaignInfo(out campaignCode, out campaignName, out sectionCode);
                                        if (campaignCode == string.Empty &&
                                            campaignName == string.Empty &&
                                            sectionCode == string.Empty)
                                        {
                                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();

                                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                            // ---ADD 2011/07/14------------->>>>>
                                            CampaignObjGoodsSt campaignObjGoodsSt = null;
                                            this._campaignObjGoodsStAcs.CopyToCampaignMngFromDetailRow((CampaignMngDataSet.CampaignMngRow)this._campaignMngDataTable.Rows[this._campaignMngDataTable.Count - 1], ref campaignObjGoodsSt);
                                            this._campaignObjGoodsStAcs.NewCampaignObj = campaignObjGoodsSt.Clone();
                                            // ---ADD 2011/07/14-------------<<<<<
                                            return true;
                                        }
                                        else
                                        {
                                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();

                                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Value = campaignCode;
                                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Value = campaignName;
                                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Value = sectionCode;

                                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Activate();
                                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                            // ---ADD 2011/07/14------------->>>>>
                                            CampaignObjGoodsSt campaignObjGoodsSt = null;
                                            this._campaignObjGoodsStAcs.CopyToCampaignMngFromDetailRow((CampaignMngDataSet.CampaignMngRow)this._campaignMngDataTable.Rows[this._campaignMngDataTable.Count - 1], ref campaignObjGoodsSt);
                                            this._campaignObjGoodsStAcs.NewCampaignObj = campaignObjGoodsSt.Clone();
                                            // ---ADD 2011/07/14-------------<<<<<
                                            return true;
                                        }
                                        // ---ADD 2011/07/12------------------<<<<<
                                        #endregion
                                    }
                                    // ----- UPD 2011/07/06 ------- <<<<<<<<<
                                    // ----- ADD 2011/07/21 ------- >>>>>>>>>
                                    else
                                    {
                                        moved = false;
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        break;
                                    }
                                    // ----- ADD 2011/07/21 ------- <<<<<<<<<
                                }
                            }
                        }
                        else
                        {
                            if (this._campaignMngDataTable.PriceEndDateColumn.ColumnName.Equals(this.uGrid_Details.ActiveCell.Column.Key))
                            {
                                if (this._campaignObjGoodsStAcs.DeleteSearchMode == false)
                                {
                                    // ----- UPD 2011/07/06 ------- >>>>>>>>>
                                    if (CheckDateForDown())
                                    {
                                        #region 最終行の場合、新規行を追加する
                                        CampaignMngDataSet.CampaignMngRow newRow = this._campaignMngDataTable.NewCampaignMngRow();
                                        newRow.RowNo = this.uGrid_Details.Rows.Count + 1;
                                        newRow.FilterGuid = Guid.Empty;
                                        newRow.SectionCode = "00";
                                        newRow.GoodsName = "";
                                        newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");

                                        this._campaignMngDataTable.AddCampaignMngRow(newRow);

                                        this.DetailGridInitSetting();
                                        // ---ADD 2011/07/12------------------>>>>>
                                        string campaignCode = string.Empty;
                                        string campaignName = string.Empty;
                                        string sectionCode = string.Empty;
                                        this.GetCampaignInfo(out campaignCode, out campaignName, out sectionCode);
                                        if (campaignCode == string.Empty &&
                                            campaignName == string.Empty &&
                                            sectionCode == string.Empty)
                                        {
                                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();

                                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                            // ---ADD 2011/07/14------------->>>>>
                                            CampaignObjGoodsSt campaignObjGoodsSt = null;
                                            this._campaignObjGoodsStAcs.CopyToCampaignMngFromDetailRow((CampaignMngDataSet.CampaignMngRow)this._campaignMngDataTable.Rows[this._campaignMngDataTable.Count - 1], ref campaignObjGoodsSt);
                                            this._campaignObjGoodsStAcs.NewCampaignObj = campaignObjGoodsSt.Clone();
                                            // ---ADD 2011/07/14-------------<<<<<
                                            return true;
                                        }
                                        else
                                        {
                                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();

                                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Value = campaignCode;
                                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Value = campaignName;
                                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Value = sectionCode;

                                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Activate();
                                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                            // ---ADD 2011/07/14------------->>>>>
                                            CampaignObjGoodsSt campaignObjGoodsSt = null;
                                            this._campaignObjGoodsStAcs.CopyToCampaignMngFromDetailRow((CampaignMngDataSet.CampaignMngRow)this._campaignMngDataTable.Rows[this._campaignMngDataTable.Count - 1], ref campaignObjGoodsSt);
                                            this._campaignObjGoodsStAcs.NewCampaignObj = campaignObjGoodsSt.Clone();
                                            // ---ADD 2011/07/14-------------<<<<<
                                            return true;
                                        }
                                        // ---ADD 2011/07/12------------------<<<<<
                                        #endregion
                                    }
                                    // ----- UPD 2011/07/06 ------- <<<<<<<<<
                                    // ----- ADD 2011/07/21 ------- >>>>>>>>>
                                    else
                                    {
                                        moved = false;
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        break;
                                    }
                                    // ----- ADD 2011/07/21 ------- <<<<<<<<<
                                }
                            }
                        }
                    }

                    performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

                    if (performActionResult)
                    {
                        if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            moved = true;
                        }
                        else
                        {
                            moved = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (moved)
                {
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                // 更新終了（描画再開）
                this.uGrid_Details.EndUpdate();
            }

            return performActionResult;
        }

        /// <summary>
        /// 前入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : 前入力可能セル移動処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private bool MovePreAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            try
            {
                // 更新開始（描画ストップ）
                this.uGrid_Details.BeginUpdate();

                if ((activeCellCheck) && (this.uGrid_Details.ActiveCell != null))
                {
                    if ((!this.uGrid_Details.ActiveCell.Column.Hidden) &&
                        (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                }

                while (!moved)
                {
                    if (this.uGrid_Details.ActiveRow.Index == 0)
                    {
                        if (this.uGrid_Details.Rows[0].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activation != Activation.AllowEdit)
                        {
                            if ("SectionCode".Equals(this.uGrid_Details.ActiveCell.Column.Key))
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                break;
                            }
                        }
                        else
                        {
                            if ("CampaignCode".Equals(this.uGrid_Details.ActiveCell.Column.Key))
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                break;
                            }
                        }
                    }

                    performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);

                    if (performActionResult)
                    {
                        if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            moved = true;
                        }
                        else
                        {
                            moved = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (moved)
                {
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                // 更新終了（描画再開）
                this.uGrid_Details.EndUpdate();
            }

            return performActionResult;
        }

        #region ReturnKeyDown
        /// <summary>
        /// ReturnKey押下処理(グリッド内)
        /// </summary>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : ReturnKey押下処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public void ReturnKeyDown(ref ChangeFocusEventArgs e)
        {
            if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.ActiveRow == null))
            {
                this.uGrid_Details.Rows[0].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
            }

            string columnKey;
            int rowIndex;

            if (this.uGrid_Details.ActiveCell != null)
            {
                columnKey = this.uGrid_Details.ActiveCell.Column.Key;
                rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            }
            else
            {
                columnKey = this._campaignMngDataTable.CampaignCodeColumn.ColumnName;
                rowIndex = this.uGrid_Details.ActiveRow.Index;
            }

            e.NextCtrl = null;

            if (this.uGrid_Details.ActiveRow != null)
            {
                if (this.uGrid_Details.ActiveRow.Selected)
                {
                    if (this._campaignObjGoodsStAcs.DeleteSearchMode == false)
                    {
                        if (this.uGrid_Details.ActiveRow.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activation == Activation.AllowEdit)
                        {
                            this.uGrid_Details.ActiveRow.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        else
                        {
                            this.uGrid_Details.ActiveRow.Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                    }
                    else
                    {
                        if (this.uGrid_Details.ActiveRow.Index < this.uGrid_Details.Rows.Count - 1)
                        {
                            this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Selected = false;
                            this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index + 1].Activate();
                            this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Selected = true;
                        }
                    }
                    return;
                }
            }

            this.focusFlg = true;
            this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

            if (this.focusFlg)
            {
                MoveNextAllowEditCell(false);
            }
            else
            {
                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
            }
        }
        #endregion ReturnKeyDown

        #region ShiftKeyDown
        /// <summary>
        /// ShiftKey押下処理(グリッド内)
        /// </summary>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : ShiftKey押下処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public void ShiftKeyDown(ref ChangeFocusEventArgs e)
        {
            if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.ActiveRow == null))
            {
                this.uGrid_Details.Rows[0].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
            }

            string columnKey;
            int rowIndex;

            if (this.uGrid_Details.ActiveCell != null)
            {
                columnKey = this.uGrid_Details.ActiveCell.Column.Key;
                rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            }
            else
            {
                columnKey = this._campaignMngDataTable.CampaignCodeColumn.ColumnName;
                rowIndex = this.uGrid_Details.ActiveRow.Index;
            }

            e.NextCtrl = null;

            if (this.uGrid_Details.ActiveRow != null)
            {
                if (this.uGrid_Details.ActiveRow.Selected)
                {
                    if (this._campaignObjGoodsStAcs.DeleteSearchMode == false)
                    {
                        if (this.uGrid_Details.ActiveRow.Index > 0)
                        {
                            if (this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index - 1].Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Activation == Activation.AllowEdit)
                            {
                                this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index - 1].Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index - 1].Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                    }
                    else
                    {
                        if (this.uGrid_Details.ActiveRow.Index > 0)
                        {
                            this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Selected = false;
                            this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index - 1].Activate();
                            this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Selected = true;
                        }
                    }
                    return;
                }
            }

            this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

            if (this.focusFlg)
            {
                MovePreAllowEditCell(false);
            }
            else
            {
                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
            }
        }
        #endregion ReturnKeyDown

        /// <summary>
        /// 明細部アクッチブキーを取得
        /// </summary>
        /// <param name="rowIndex">行番号</param>
        /// <remarks>
        /// <br>Note       : 明細部アクッチブキーを取得を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public string GetFocusColumnKey(out int rowIndex)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                rowIndex = -1;
                return string.Empty;
            }

            rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            return this.uGrid_Details.ActiveCell.Column.Key;
        }

        /// <summary>
        /// ガイドボタン設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ガイドボタン設定処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public void SetGridGuid()
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                switch (this.uGrid_Details.ActiveCell.Column.Key)
                {
                    case "CampaignCode":
                    case "SectionCode":
                    case "GoodsMakerCode":
                    case "BLGoodsCode":
                    case "BLGroupCode":
                    case "SalesCode":
                    case "CustomerCode":
                        {
                            if (this.uGrid_Details.ActiveCell.Activation == Activation.AllowEdit)
                            {
                                this.SetGuidButton(true);
                            }
                            else
                            {
                                this.SetGuidButton(false);
                            }
                            break;
                        }
                    default:
                        {
                            this.SetGuidButton(false);
                            break;
                        }
                }
            }
            else
            {
                this.SetGuidButton(false);
            }
        }
               

        /// <summary>
        /// 数値入力チェック処理
        /// </summary>
        /// <param name="keta">桁数(マイナス符号を含まず)</param>
        /// <param name="priod">小数点以下桁数</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <param name="minusFlg">マイナス入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        /// <remarks>
        /// <br>Note        : 数値入力チェック処理</br>
        /// <br>Programmer  : 曹文傑</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        public bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }
            // 数値以外は、ＮＧ
            if (!Char.IsDigit(key))
            {
                // 小数点または、マイナス以外
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = string.Empty;
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // マイナスのチェック
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // 小数点以下のチェック
            if (priod > 0)
            {
                // 小数点の位置決定
                int _pointPos = _strResult.IndexOf('.');

                // 整数部に入力可能な桁数を決定！
                //int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
                int _Rketa = CampaignObjGoodsStAcs.diverge<int>(_strResult[0] == '-', keta - priod, keta - priod - 1);
                // 整数部の桁数をチェック
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (_strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // 小数部の桁数をチェック
                if (_pointPos != -1)
                {
                    // 小数部の桁数を計算
                    int _priketa = _strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// ヘッダ部から、ENTER、TAB、↓押下時、最終明細行＋１行目のコードへフォーカスを遷移する。
        /// </summary>
        /// <remarks>
        /// <br>Note       : ヘッダ部から、ENTER、TAB、↓押下時、最終明細行＋１行目のコードへフォーカスを遷移する。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/14 曹文傑 Redmine#22984 最終行の情報がデータ登録されない</br>
        /// </remarks>
        public void SetFocusAfterSearch()
        {
            if (this.uGrid_Details.Rows.Count > 0)
            {
                if (this._campaignObjGoodsStAcs.DeleteSearchMode == false)
                {
                    bool flag = false;
                    foreach (UltraGridRow row in this.uGrid_Details.Rows)
                    {
                        // ---UPD 2011/07/12------------------->>>>>
                        //if (row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Text.Trim() == string.Empty
                        //    && row.Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Text.Trim() == "00"
                        //    && (int)row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Value == 1
                        //    && row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Text.Trim() == string.Empty
                        //    && row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Text.Trim() == string.Empty
                        //    && row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Text.Trim() == string.Empty
                        //    && row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Text.Trim() == string.Empty
                        //    && row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Text.Trim() == string.Empty
                        //    && (int)row.Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Value == 0)
                        //{
                        //    if (row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activation == Activation.AllowEdit)
                        //    {
                        //        row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                        //        flag = true;
                        //        break;
                        //    }
                        //}

                        if (row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activation == Activation.AllowEdit)
                        {
                            flag = true;
                            if (row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Text.Trim() == string.Empty)
                            {
                                string campaignCode = string.Empty;
                                string campaignName = string.Empty;
                                string sectionCode = string.Empty;
                                this.GetCampaignInfo(out campaignCode, out campaignName, out sectionCode);
                                if (campaignCode == string.Empty)
                                {
                                    row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                                }
                                else
                                {
                                    row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();

                                    row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Value = campaignCode;
                                    row.Cells[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Value = campaignName;
                                    row.Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Value = sectionCode;

                                    row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Activate();
                                }
                            }
                            else
                            {
                                row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();

                                row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Activate();
                            }
                            break;
                        }
                        // ---UPD 2011/07/12-------------------<<<<<
                    }

                    // ---UPD 2011/07/12----------------->>>>>
                    if (flag == false)
                    {
                        #region 最終行の場合、新規行を追加する
                        CampaignMngDataSet.CampaignMngRow newRow = this._campaignMngDataTable.NewCampaignMngRow();
                        newRow.RowNo = this.uGrid_Details.Rows.Count + 1;
                        newRow.FilterGuid = Guid.Empty;
                        newRow.SectionCode = "00";
                        newRow.GoodsName = "";
                        newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");

                        this._campaignMngDataTable.AddCampaignMngRow(newRow);

                        this.DetailGridInitSetting();
                        #endregion
                        //this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                        
                        string campaignCode = string.Empty;
                        string campaignName = string.Empty;
                        string sectionCode = string.Empty;
                        this.GetCampaignInfo(out campaignCode, out campaignName, out sectionCode);
                        if (campaignCode == string.Empty)
                        {
                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                        }
                        else
                        {
                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();

                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Value = campaignCode;
                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Value = campaignName;
                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Value = sectionCode;

                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Activate();
                        }
                        // ---ADD 2011/07/14------------->>>>>
                        CampaignObjGoodsSt campaignObjGoodsSt = null;
                        this._campaignObjGoodsStAcs.CopyToCampaignMngFromDetailRow((CampaignMngDataSet.CampaignMngRow)this._campaignMngDataTable.Rows[this._campaignMngDataTable.Count - 1], ref campaignObjGoodsSt);
                        this._campaignObjGoodsStAcs.NewCampaignObj = campaignObjGoodsSt.Clone();
                        // ---ADD 2011/07/14-------------<<<<<
                    }
                    // ---UPD 2011/07/12-----------------<<<<<
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    this.uGrid_Details.Focus();
                    this.uGrid_Details.Rows[0].Activate();
                    this.uGrid_Details.Rows[0].Selected = true;
                }
            }
        }
        #endregion


        // ----- ADD 2011/07/07 ------- >>>>>>>>>
        /// <summary>
        /// グリッドカラム情報の保存
        /// </summary>
        /// <param name="fontSize">fontSize</param>
        /// <param name="autoFillToGrid">autoFillToGrid</param>
        public void SaveSettings(int fontSize, bool autoFillToGrid)
        {
            // 明細グリッド
            List<ColumnInfo> detailColumnsList;
            this.SaveGridColumnsSetting(uGrid_Details, out detailColumnsList);
            this._userSetting.DetailColumnsList = detailColumnsList;
            this._userSetting.OutputStyle = fontSize;
            this._userSetting.AutoAdjustDetail = autoFillToGrid;
        }

        /// <summary>
        /// グリッドカラム情報の読み込み
        /// </summary>
        public void LoadSettings()
        {
            this.LoadGridColumnsSetting(ref uGrid_Details, this._userSetting.DetailColumnsList);
        }


        /// <summary>
        /// グリッドカラム情報の保存
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <param name="settingList"></param>
        private void SaveGridColumnsSetting(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, out List<ColumnInfo> settingList)
        {
            settingList = new List<ColumnInfo>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in targetGrid.DisplayLayout.Bands[0].Columns)
            {
                settingList.Add(new ColumnInfo(ultraGridColumn.Key, ultraGridColumn.Width));
            }
        }

        /// <summary>
        /// グリッドカラム情報の読み込み
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <param name="settingList"></param>
        private void LoadGridColumnsSetting(ref Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, List<ColumnInfo> settingList)
        {
            if (settingList == null || settingList.Count == 0) return;

            targetGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
            foreach (ColumnInfo columnInfo in settingList)
            {
                try
                {
                    Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn = targetGrid.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                    ultraGridColumn.Width = columnInfo.Width;
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// 得意先電子元帳用ユーザー設定シリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先電子元帳用ユーザー設定のシリアライズを行います。</br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// </remarks>
        public void Serialize()
        {
            try
            {
                UserSettingController.SerializeUserSetting(_userSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }

        }

        /// <summary>
        /// 得意先電子元帳用ユーザー設定デシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先電子元帳用ユーザー設定クラスをデシリアライズします。</br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            {
                try
                {
                    this._userSetting = UserSettingController.DeserializeUserSetting<CampaignMngUserSet>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                }
                catch
                {
                    this._userSetting = new CampaignMngUserSet();
                }
            }
        }
    }



    /// <summary>
    /// キャンペーン対象商品設定マスタ用グリッド設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン対象商品設定マスタ用グリッド設定クラス</br>
    /// <br>Programmer : </br>
    /// <br>Date       : </br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class CampaignMngUserSet
    {
        // 出力形式
        private int _outputStyle;

        // 明細グリッドカラムリスト
        private List<ColumnInfo> _detailColumnsList;

        // 明細グリッド自動サイズ調整
        private bool _autoAdjustDetail;

        # region コンストラクタ
        /// <summary>
        /// キャンペーン対象商品設定マスタ用グリッド設定クラス
        /// </summary>
        public CampaignMngUserSet()
        {

        }
        # endregion

        /// <summary>出力型式</summary>
        public int OutputStyle
        {
            get { return this._outputStyle; }
            set { this._outputStyle = value; }
        }

        /// <summary>明細グリッドカラムリスト</summary>
        public List<ColumnInfo> DetailColumnsList
        {
            get { return this._detailColumnsList; }
            set { this._detailColumnsList = value; }
        }

        /// <summary>明細グリッド自動サイズ調整</summary>
        public bool AutoAdjustDetail
        {
            get { return _autoAdjustDetail; }
            set { _autoAdjustDetail = value; }
        }
    }

    # region [ColumnInfo]
    /// <summary>
    /// ColumnInfo
    /// </summary>
    [Serializable]
    public struct ColumnInfo
    {
        /// <summary>列名</summary>
        private string _columnName;

        /// <summary>幅</summary>
        private int _width;

        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }

        /// <summary>
        /// 幅
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <param name="width">幅</param>
        public ColumnInfo(string columnName, int width)
        {
            _columnName = columnName;
            _width = width;
        }
    }
    # endregion
    // ----- ADD 2011/07/07 ------- <<<<<<<<<
}
