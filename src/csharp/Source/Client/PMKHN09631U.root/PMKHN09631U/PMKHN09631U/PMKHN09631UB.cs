//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 対象得意先設定画面
// プログラム概要   : 対象得意先設定画面
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 作 成 日  2011/05/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using System.Collections;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 対象得意先設定画面フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 対象得意先設定画面を行います。</br>
    /// <br>Programmer : 鄧潘ハン</br>
    /// <br>Date       : 2011/05/20</br>
    /// </remarks>
    public partial class PMKHN09631UB : Form
    {

        # region Private Constant

        // ツールバーツールキー設定
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";
        private const string TOOLBAR_UPDATEBUTTON_KEY = "ButtonTool_Update";
       
        // UIのGrid表示用
        private const string MY_SCREEN_CUSTOMER_CODE = "CustomerCode";
        private const string MY_SCREEN_CUSTOMER_NAME = "CustomerName";
        private const string MY_SCREEN_ODER = "NO";
        private const string MY_SCREEN_GUID = "CustomerGuid";
        private const string MY_SCREEN_TABLE = "MY_SCREEN_TABLE";
        private const string I_CAMPAIGN_TABLE = "CAMPAIGN_TABLE";
        
        // アセンブリ情報
        private const string PG_ID = "PMKHN09531U";
        private const string PG_NAME = "対象得意先設定";
      
        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";

        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;					// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _updateButton;					// 更新ボタン
        private string _enterpriseCode;
        private bool _gridUpdFlg = true;　　　　　　　　　　// Grid変更フラグ
        private CustomerInfoAcs _customerInfoAcs = null;    // 得意先情報アクセスクラス
        private CampaignLinkDataSet.CampaignLinkDataTable _campaignLinkDataTable;
        private PMKHN09631UA _PMKHN09631UA = null;
        private Image _guideButtonImage;
        private int _customerCode;　　　　　　　　　　　　   // 得意先情報ダイアログ
        private ArrayList _customerList;　　　　　　　　　　// 得意先情報キャッシュ
        private string _customerName;
        private int campaignLinkFlag = -1;
        private CampaignLinkWork _campaignLinkWork = null;
        private int _closeFlag = -1;

        #endregion
        
        // ===================================================================================== //
        // Constructor
        // ===================================================================================== //
        #region　Constructor
        /// <summary>
        /// 対象得意先設定画面フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 対象得意先設定画面フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 鄧潘ハン</br>
        /// <br>Date		: 2011/05/20</br>
        /// </remarks>
        public PMKHN09631UB()
        {
            InitializeComponent();
            
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY];
            this._updateButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_UPDATEBUTTON_KEY];
         
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode; ;
            this._customerInfoAcs = new CustomerInfoAcs();
            this._PMKHN09631UA = new PMKHN09631UA();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._guideButtonImage = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            //キャッシュ情報取得
            this.GetCacheData();

            this._campaignLinkDataTable = new CampaignLinkDataSet.CampaignLinkDataTable();
            this.uGrid_Customer.DataSource = this._campaignLinkDataTable;
            ScreenInitialSetting();
       
            CampaignLinkToCampaignLinklist();
            this.campaignLinkFlag = this._campaignLinkDataTable.Rows.Count;
        }

        /// <summary>
        /// キャンペーンリンクTOキャンペーンリンクリスト
        /// </summary>
        public void CampaignLinkToCampaignLinklist()
        {
            if (this._PMKHN09631UA._campaignGoodsStAcs._precampaignLinkList == null)
            {
                ScreenReconstruction();
                return;
            }

            foreach (CampaignLinkWork work in this._PMKHN09631UA._campaignGoodsStAcs._precampaignLinkList)
            {

                CampaignLinkDataSet.CampaignLinkRow row = this._campaignLinkDataTable.NewCampaignLinkRow();
                row.CustomerCode = work.CustomerCode.ToString("00000000");
                this._campaignLinkDataTable.AddCampaignLinkRow(row);
            }

            // 更新モード
            this.Mode_Label.Text = UPDATE_MODE;

            // 画面展開処理
            CampaignLinkToScreen();
            DataUpdate();
        }

        #endregion

        // ===================================================================================== //
        //  Private Methods
        // ===================================================================================== //
        #region　Private Methods

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面の初期設定を行います。</br>
        /// <br>Programmer	: 鄧潘ハン</br>
        /// <br>Date		: 2011/05/20</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            ToolBarInitilSetting();

            GridInitialSetting();　　　　// GRIDの初期設定
        }

        /// <summary>
        /// ツールバー初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面初期化時、ツールバー初期設定処理を行います。</br>
        /// <br>Programmer  : 鄧潘ハン</br>
        /// <br>Date        : 2011/05/20</br>
        /// </remarks> 
        private void ToolBarInitilSetting()
        {
            this._imageList16 = IconResourceManagement.ImageList16;
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._updateButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
        }

        /// <summary>
        /// グリト設定
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面のグリト設定を行います。</br>
        /// <br>Programmer	: 鄧潘ハン</br>
        /// <br>Date		: 2011/05/20</br>
        /// </remarks>
        private void GridInitialSetting()
        {
            // グリッドの背景色
            this.uGrid_Customer.DisplayLayout.Appearance.BackColor = Color.White;
            this.uGrid_Customer.DisplayLayout.Appearance.BackColor2 = Color.FromArgb(198, 219, 255);
            this.uGrid_Customer.DisplayLayout.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // 行の追加不可
            this.uGrid_Customer.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            // 行のサイズ変更不可
            this.uGrid_Customer.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            // 行の削除不可
            this.uGrid_Customer.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            // 列の移動不可
            this.uGrid_Customer.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            // 列のサイズ変更不可
            this.uGrid_Customer.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            // 列の交換不可
            this.uGrid_Customer.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            // フィルタの使用不可
            this.uGrid_Customer.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // タイトルの外観設定
            this.uGrid_Customer.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid_Customer.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid_Customer.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Customer.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            this.uGrid_Customer.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

            // グリッドの選択方法を設定（セル単体の選択のみ許可）
            this.uGrid_Customer.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.uGrid_Customer.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            // 互い違いの行の色を変更
            this.uGrid_Customer.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Lavender;
            // 行セレクタ表示無し
            this.uGrid_Customer.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;

            this.uGrid_Customer.DisplayLayout.Override.EditCellAppearance.BackColor = Color.FromArgb(247, 227, 156);
            this.uGrid_Customer.DisplayLayout.Override.ActiveCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.uGrid_Customer.DisplayLayout.Override.EditCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.uGrid_Customer.DisplayLayout.Override.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            // 「ID」は編集不可（固定項目として設定）
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].TabStop = false;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.ForeColor = Color.White;

            // 得意先コード列の設定
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_CODE].CellActivation = Activation.AllowEdit;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_CODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_CODE].TabStop = true;

            // ガイドボタンの設定
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].CellActivation = Activation.NoEdit;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].TabStop = true;

            // BL品名列の設定
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_NAME].CellActivation = Activation.NoEdit;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_NAME].TabStop = false;

            // セルの幅の設定
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].Width = 50;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_CODE].Width = 100;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].Width = 20;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_NAME].Width = 380;

            // 選択行の外観設定
            this.uGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            this.uGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            this.uGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.ForeColor = System.Drawing.Color.Black;
            this.uGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            this.uGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);
            // アクティブ行の外観設定
            this.uGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            this.uGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            this.uGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.ForeColor = System.Drawing.Color.Black;
            this.uGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            this.uGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);

            // 行セレクタの外観設定
            this.uGrid_Customer.DisplayLayout.Override.RowSelectorAppearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(89)), ((System.Byte)(135)), ((System.Byte)(214)));
            this.uGrid_Customer.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(7)), ((System.Byte)(59)), ((System.Byte)(150)));
            this.uGrid_Customer.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // 罫線の色を変更
            this.uGrid_Customer.DisplayLayout.Appearance.BorderColor = Color.FromArgb(1, 68, 208);
        }

        /// <summary>
        /// 対象得意先設定 クラス画面展開処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 対象得意先設定 オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer	: 鄧潘ハン</br>
        /// <br>Date		: 2011/05/20</br>
        /// </remarks>
        private void CampaignLinkToScreen()
        {
            int i = 0;
            string NameValue = string.Empty;
            int maxRow = this._campaignLinkDataTable.Rows.Count;
            if (maxRow > 0)
            {
                NameValue = this._campaignLinkDataTable.Rows[maxRow - 1]["CustomerCode"].ToString();
                if (NameValue == string.Empty)
                {
                    maxRow = maxRow - 1;
                }
            }
            // 得意先情報
            for (i = 0; i < maxRow; i++)
            {

                this._campaignLinkDataTable.Rows[i]["NO"] = i + 1;// 表示順位

                this._campaignLinkDataTable.Rows[i]["CustomerName"] = GetCustomerName(Convert.ToInt32(this._campaignLinkDataTable.Rows[i]["CustomerCode"]));   // 得意先名
            }
            if (maxRow > 0)
            {
                this.uGrid_Customer.Rows[0].Selected = false;
                this.uGrid_Customer.ActiveCell = null;
                this.uGrid_Customer.ActiveRow = null;
            }

        }

        /// <summary>
        /// 得意先名称取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先名称</returns>
        /// <remarks>
        /// <br>Note		: 得意先名称を取得します。</br>
        /// <br>Programmer	: 鄧潘ハン</br>
        /// <br>Date		: 2011/05/20</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            return GetCustomerName(customerCode, false);
        }

        /// <summary>
        /// 得意先名称を取得します。
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="throwsExceptionWhenCodeIsNotFound">該当する得意先コードがない場合、例外を投入するフラグ</param>
        /// <returns>得意先名称</returns>
        /// <exception cref="ArgumentException">
        /// <c>throwsExceptionWhenCodeIsNotFound</c>が<c>true</c>のとき、
        /// 得意先マスタに該当する得意先コードが存在しない場合、投入されます。
        /// </exception>
        /// <remarks>
        /// <br>Note		: 得意先名称を取得します。</br>
        /// <br>Programmer	: 鄧潘ハン</br>
        /// <br>Date		: 2011/05/20</br>
        /// </remarks>
        private string GetCustomerName(
            int customerCode,
            bool throwsExceptionWhenCodeIsNotFound
        )
        {
            string customerName = string.Empty;
            CustomerInfo customerInfo = new CustomerInfo();

            bool codeIsFound = false;
            try
            {
                foreach (CustomerSearchRet customerSearchRet in this._customerList)
                {
                    if (customerSearchRet.CustomerCode == customerCode && customerSearchRet.LogicalDeleteCode == 0)
                    {
                        codeIsFound = true;
                        customerName = customerSearchRet.Snm.Trim();
                        break;
                    }
                }

                if (customerName == "")
                {
                    int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                    if (status == 0)
                    {
                        codeIsFound = true;
                        customerName = customerInfo.CustomerSnm.Trim();
                    }
                }
            }
            catch
            {
                customerName = string.Empty;
            }

            if (!codeIsFound && throwsExceptionWhenCodeIsNotFound)
            {
                throw new ArgumentException("customerCode(=" + customerCode.ToString() + ") is not found.");
            }

            return customerName;
        }


        /// <summary>
        /// キャッシュ情報取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先の名称をキャッシュ化。</br>
        /// </remarks>
        private void GetCacheData()
        {
            // 得意先名称リスト取得
            this.GetCustomerNameList();

        }

        /// <summary>
        /// 得意先名称リスト取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先名称のリストを取得します。</br>
        /// </remarks>
        private void GetCustomerNameList()
        {
            int status;
            CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
            CustomerSearchRet[] customerSearchRetArray;
            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            customerSearchPara.EnterpriseCode = this._enterpriseCode;
            this._customerList = new ArrayList();

            status = customerSearchAcs.Serch(out customerSearchRetArray, customerSearchPara);
            if (status == 0)
            {
                foreach (CustomerSearchRet customerSearchRet in customerSearchRetArray)
                {
                    // 論理削除データは読み込まない
                    if (customerSearchRet.LogicalDeleteCode != 1)
                    {
                        this._customerList.Add(customerSearchRet);
                    }
                }
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note　　　 : 得意先ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            _customerCode = 0;
            _customerName = "";

            if (customerSearchRet == null)
            {
                return;
            }

            // 得意先コード
            _customerCode = customerSearchRet.CustomerCode;

            // 得意先名称
            _customerName = customerSearchRet.Snm.Trim();
        }


        private void SetGridColVisible()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Customer.DisplayLayout.Bands[0];
            if (editBand == null) return;


            CampaignLinkDataSet.CampaignLinkDataTable table = this._campaignLinkDataTable;
            ColumnsCollection columns = editBand.Columns;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in columns)
            {
                // 全ての列をいったん非表示にする。
                col.Hidden = true;
            }

            columns[table.NOColumn.ColumnName].Hidden = false;
            columns[table.CustomerCodeColumn.ColumnName].Hidden = false;
            columns[table.CustomerGuidColumn.ColumnName].Hidden = false;
            columns[table.CustomerNameColumn.ColumnName].Hidden = false;

        }

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// Note			:	次の入力可能なセルにフォーカスを移動する処理を行います。<br />
        /// <br></br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_Customer.ActiveCell != null))
            {
                if ((this.uGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }
            else
            {
                while (!moved)
                {
                    performActionResult = this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

                    if (performActionResult)
                    {
                        if ((this.uGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.uGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            moved = true;
                        }
                        else if (this.uGrid_Customer.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                        {
                            // アクティブセルがボタン
                            moved = false;
                            int rowIdx = this.uGrid_Customer.ActiveCell.Row.Index;
                            if ((this._campaignLinkDataTable.Rows[rowIdx][MY_SCREEN_CUSTOMER_CODE].ToString() == "") &&
                                (this._gridUpdFlg))
                            {
                                // 得意先コードが未入力の場合(得意先コード取得失敗等は除く)
                                break;
                            }
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
            }

            if (moved)
            {
                this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }

        /// <summary>
        ///	Grid 新規行の追加
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDに新規行を追加します。</br>
        /// <br></br>
        /// </remarks>
        private void tbsPartsList_AddRow()
        {
            if (this._campaignLinkDataTable.Rows.Count == 99)
            {
                // MAX99行とする
                return;
            }

            // ガイドで選択した得意先コードを追加
            CampaignLinkDataSet.CampaignLinkRow row = this._campaignLinkDataTable.NewCampaignLinkRow();

            row["NO"] = this._campaignLinkDataTable.Rows.Count + 1;
            row["CustomerCode"] = "";
            row["CustomerName"] = "";

            this._campaignLinkDataTable.AddCampaignLinkRow(row);
        }


        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面の再構築を行います。</br>
        /// <br></br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            int recordCount = this._campaignLinkDataTable.Rows.Count;
            string NameValue = string.Empty;
            if (recordCount > 0)
            {
                NameValue = this._campaignLinkDataTable.Rows[recordCount - 1]["CustomerCode"].ToString();
            }

            if (this._campaignLinkDataTable.Rows.Count < 1)
            {
                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                if (recordCount == 0)
                {
                    // グリッド行を追加
                    this.tbsPartsList_AddRow();
                }
            }
            else
            {
                // 更新モード
                this.Mode_Label.Text = UPDATE_MODE;

                if (NameValue != string.Empty)
                {
                    this.tbsPartsList_AddRow();
                }
            }
        }

        /// <summary>
        /// 上のセルへ移動処理
        /// </summary>
        /// <returns>次のコントロール</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアクティブセルを上のセルに移動します。</br>
        /// <br></br>
        /// </remarks>
        private Control MoveAboveCell()
        {
            bool performActionResult;

            // アクティブセルがnull
            if (this.uGrid_Customer.ActiveCell == null)
            {
                return null;
            }

            // グリッド状態取得
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.uGrid_Customer.CurrentState;


            // 上のセルに移動
            performActionResult = this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);
            if (performActionResult)
            {
                if ((this.uGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            return null;
        }
        /// <summary>
        /// 下のセルへ移動処理
        /// </summary>
        /// <returns>次のコントロール</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアクティブセルを下のセルに移動します。</br>
        /// <br></br>
        /// </remarks>
        private Control MoveBelowCell()
        {
            bool performActionResult;

            // アクティブセルがnull
            if (this.uGrid_Customer.ActiveCell == null)
            {
                return null;
            }

            // グリッド状態取得
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.uGrid_Customer.CurrentState;


            // セル移動前アクティブセルのインデックス
            int prevCol = this.uGrid_Customer.ActiveCell.Column.Index;
            int prevRow = this.uGrid_Customer.ActiveCell.Row.Index;

            // 下のセルに移動
            performActionResult = this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
            if (performActionResult)
            {
                if ((this.uGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            return null;
        }


        /// <summary>
        /// 画面更新
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private void DataUpdate()
        {
            
            int maxRow = this._campaignLinkDataTable.Rows.Count;
            string NameValue = string.Empty;
            string campaignCodeValue=string.Empty;
            int AddRow = maxRow;
            _closeFlag = -1;
            ArrayList addCampaignList = new ArrayList();

            // 得意先情報
            for (int i = 0; i < maxRow; i++)
            {
                campaignCodeValue = this._campaignLinkDataTable.Rows[i]["CustomerCode"].ToString();
                if (campaignCodeValue != string.Empty)
                {
                   _campaignLinkWork = new CampaignLinkWork();
                   _campaignLinkWork.CustomerCode = Convert.ToInt32(this._campaignLinkDataTable.Rows[i]["CustomerCode"]);
                   addCampaignList.Add(_campaignLinkWork);
                }
                
            }

            if (addCampaignList.Count == 0)
            {
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "得意先コードが登録されていません。",
                            -1,
                            MessageBoxButtons.OK);
                _closeFlag = 1;

            }
            else
            {
                this._PMKHN09631UA._campaignGoodsStAcs._precampaignLinkList = addCampaignList;
            }

        }

        private bool MovePrevAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_Customer.ActiveCell != null))
            {
                if ((this.uGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }
            else
            {
                while (!moved)
                {
                    performActionResult = this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);

                    if (performActionResult)
                    {
                        if ((this.uGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.uGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            moved = true;
                        }
                        else if (this.uGrid_Customer.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                        {
                            // アクティブセルがボタン
                            moved = false;
                            int rowIdx = this.uGrid_Customer.ActiveCell.Row.Index;
                            if (this._campaignLinkDataTable.Rows[rowIdx][MY_SCREEN_CUSTOMER_CODE].ToString() == "")
                            {
                                // 得意先コードが未入力の場合
                                break;
                            }
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
            }

            if (moved)
            {
                this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }
        #endregion
        // ===================================================================================== //
        // 各コントロールイベント処理
        // ===================================================================================== //
        # region Control Event Methods

        /// <summary>
        /// 画面ロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09631UB_Load(object sender, EventArgs e)
        {
            this.uGrid_Customer.DataSource = this._campaignLinkDataTable;
        }

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : ツールバークリック時に発生します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 終了
                case TOOLBAR_CLOSEBUTTON_KEY:
                    {
                        // 終了処理
                        Close();

                        break;
                    }
                // 更新
                case TOOLBAR_UPDATEBUTTON_KEY:
                    {
                        this.uGrid_Customer_AfterExitEditMode(sender, e);
                        this.DataUpdate();
                        if (_closeFlag != 1)
                        {
                            Close();
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// Control.Click イベント(DeleteRow_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void DeleteRow_Button_Click(object sender, EventArgs e)
        {
            string message = "";

            if (this._campaignLinkDataTable.Rows.Count < 1)
            {
                 //デバッグ用
                 this.tbsPartsList_AddRow();
            }

            if (this.uGrid_Customer.ActiveRow == null)
            {
                // 削除する行が未選択
                message = "削除する得意先コードを選択して下さい。";

                TMsgDisp.Show(
                    this,								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                    PG_ID,      						// アセンブリＩＤまたはクラスＩＤ
                    message,							// 表示するメッセージ 
                    0,									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                this.uGrid_Customer.Focus();
            }
            else if (this.uGrid_Customer.Rows.Count == 1)
            {
                // Gridの行数が1行の場合は削除不可
                message = "全ての得意先を削除はできません";

                TMsgDisp.Show(
                    this,								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                    PG_ID,      						// アセンブリＩＤまたはクラスＩＤ
                    message,							// 表示するメッセージ 
                    0,									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                this.uGrid_Customer.Focus();
            }
            else
            {
                // UI画面のGridから選択行を削除
                // 選択行のindexを取得
                int delIndex = (int)this.uGrid_Customer.ActiveRow.Cells[MY_SCREEN_ODER].Value - 1;

                // 選択行の削除
                this.uGrid_Customer.ActiveRow.Delete();

                // 削除後のGrid行数を取得
                int maxRow = this._campaignLinkDataTable.Rows.Count;

                for (int index = delIndex; index < maxRow; index++)
                {
                    // 削除した行以降の表示順位を更新する
                    this._campaignLinkDataTable.Rows[index][MY_SCREEN_ODER] = index + 1;
                }
            }
        }

        /// <summary>
        /// Control.Click イベント(Guid_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void Guid_Button_Click(object sender, EventArgs e)
        {
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            DialogResult res = customerSearchForm.ShowDialog(this);

            if (res.Equals(System.Windows.Forms.DialogResult.Cancel))
            {
                _customerCode = 0;
            }

            if (_customerCode != 0)
            {
                bool AddFlg = true;     // 追加フラグ
                int maxRow = this._campaignLinkDataTable.Rows.Count;

                // 得意先コードの重複チェック
                for (int i = 0; i < maxRow; i++)
                {
                    string code = this._campaignLinkDataTable.Rows[i][MY_SCREEN_CUSTOMER_CODE].ToString();
                    if ((code != "") && (int.Parse(code) == _customerCode))
                    {
                        // 重複コード有
                        AddFlg = false;
                        break;
                    }
                }

                if (AddFlg)
                {
                    int lastRow = this._campaignLinkDataTable.Rows.Count - 1;

                    if (this._campaignLinkDataTable.Rows[lastRow][MY_SCREEN_CUSTOMER_CODE].ToString() == "")
                    {
                        // 最終行が空き
                        this._campaignLinkDataTable.Rows[lastRow][MY_SCREEN_CUSTOMER_CODE] = _customerCode.ToString("d08");
                        this._campaignLinkDataTable.Rows[lastRow][MY_SCREEN_CUSTOMER_NAME] = _customerName;
                    }
                    else
                    {
                        // ガイドで選択した得意先コードを追加
                        CampaignLinkDataSet.CampaignLinkRow row = this._campaignLinkDataTable.NewCampaignLinkRow();

                        row["NO"] = this._campaignLinkDataTable.Rows.Count + 1;
                        row["CustomerCode"] = _customerCode.ToString("d08"); ;
                        row["CustomerName"] = _customerName;

                        this._campaignLinkDataTable.AddCampaignLinkRow(row);
                    }

                    // 新規行を追加
                    this.tbsPartsList_AddRow();

                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
                else 
                {

                    // 重複エラーを表示
                    string message = "選択した得意先コードは選択済です。";

                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                        PG_ID,      						// アセンブリＩＤまたはクラスＩＤ
                        message,							// 表示するメッセージ 
                        0,									// ステータス値
                        MessageBoxButtons.OK);				// 表示するボタン

                    ((Control)sender).Focus();

                }
            }
            else
            {
                ((Control)sender).Focus();
            }
        }
        /// <summary>
        /// Control.VisibleChange イベント(UI_UltraGrid)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールの表示状態が変わったときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void uGrid_Customer_VisibleChanged(object sender, System.EventArgs e)
        {
            // アクティブセル・アクティブ行を無効
            this.uGrid_Customer.ActiveCell = null;
        }

        /// <summary>
        /// Timer.Tick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 指定された間隔の時間が経過したときに発生します。
        ///					  この処理は、システムが提供するスレッド プール
        ///					  スレッドで実行されます。</br>
        /// <br></br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;

            ScreenReconstruction();　　　// 画面再構築処理
        }

        private void uGrid_Customer_ClickCellButton(object sender, CellEventArgs e)
        {
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            DialogResult res = customerSearchForm.ShowDialog(this);

            if (res.Equals(System.Windows.Forms.DialogResult.Cancel))
            {
                _customerCode = 0;
            }
         
            if (_customerCode != 0)
            {
                bool AddFlg = true;     // 追加フラグ

                int maxRow = this._campaignLinkDataTable.Rows.Count;

                // 得意先コードの重複チェック
                for (int i = 0; i < maxRow; i++)
                {
                    string code = (string)this._campaignLinkDataTable.Rows[i][MY_SCREEN_CUSTOMER_CODE];
                    if (code == "")
                    {
                        continue;
                    }

                    int customerCode = Int32.Parse(code);
                    if (customerCode == _customerCode)
                    {
                        // 重複コード有
                        AddFlg = false;
                        break;
                    }
                }

                if (AddFlg)
                {
                    // 選択した情報をCellに設定
                    e.Cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = _customerCode.ToString("d08");    // 得意先コード
                    e.Cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = _customerName;                    // 得意先名

                    if ((int)e.Cell.Row.Cells[MY_SCREEN_ODER].Value == this._campaignLinkDataTable.Rows.Count)
                    {
                        // 最終行の場合、行を追加
                        this.tbsPartsList_AddRow();
                    }

                    // 次のコントロールへフォーカスを移動
                    this.MoveNextAllowEditCell(false);
                }
                else
                {
                    // 重複エラーを表示
                    TMsgDisp.Show(
                        this,								    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // エラーレベル
                        PG_ID,      						    // アセンブリＩＤまたはクラスＩＤ
                        "選択した得意先コードが重複しています。",	// 表示するメッセージ 
                        0,									    // ステータス値
                        MessageBoxButtons.OK);				    // 表示するボタン

                    ((Control)sender).Focus();
                }
            }
            else
            {
                ((Control)sender).Focus();
            }
        }


        /// <summary>
        ///	ultraGrid.AfterExitEditMode イベント(Cell)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDのセル編集終了イベント処理。</br>
        /// <br></br>
        /// </remarks>
        private void uGrid_Customer_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Customer.ActiveCell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Customer.ActiveCell;

            // 得意先コード
            if (cell.Column.Key == MY_SCREEN_CUSTOMER_CODE)
            {
                string code = cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Text;
                this._gridUpdFlg = true;

                int customerCode = 0;
                string customerName = "";
                try
                {
                    // 入力有
                    customerCode = int.Parse(code);
                    customerName = GetCustomerName(customerCode);

                }
                catch
                {
                    customerCode = 0;
                    customerName = "";
                }
                if (customerCode == 0)
                {
                    cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = "";                    // 得意先コード
                    cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = "";                   // 得意先品名
                }
                else if (customerName != "")
                {
                    bool AddFlg = true;     // 追加フラグ
                    int maxRow = this._campaignLinkDataTable.Rows.Count;

                    // 得意先コードの重複チェック
                    for (int i = 0; i < maxRow; i++)
                    {
                        if (cell.Row.Index == i)
                        {
                            // 同じ行数はSKIP
                            continue;
                        }

                        string wkTbsPartsCode = this._campaignLinkDataTable.Rows[i][MY_SCREEN_CUSTOMER_CODE].ToString();
                        if ((wkTbsPartsCode != "") && (int.Parse(wkTbsPartsCode) == customerCode))
                        {
                            // 重複コード有
                            AddFlg = false;
                            break;
                        }
                    }

                    if (AddFlg)
                    {
                        // 得意先コードの追加
                        // 選択した情報をCellに設定
                        cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = customerCode.ToString("d08");   // 得意先コード
                        cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = customerName;                   // 得意先品名

                        if ((int)cell.Row.Cells[MY_SCREEN_ODER].Value == this._campaignLinkDataTable.Rows.Count)
                        {
                            // 最終行の場合、行を追加
                            this.tbsPartsList_AddRow();
                        }
                    }
                    else
                    {
                        // 重複エラーを表示
                        TMsgDisp.Show(
                            this,								    // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // エラーレベル
                            PG_ID,      						    // アセンブリＩＤまたはクラスＩＤ
                            "選択した得意先コードが重複しています。",	    // 表示するメッセージ 
                            0,									    // ステータス値
                            MessageBoxButtons.OK);				    // 表示するボタン

                        // 得意先コード、得意先名をクリア
                        cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = "";     // 得意先コード
                        cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = "";     // 得意先名

                        // Grid変更なし
                        this._gridUpdFlg = false;
                    }
                }
                else
                {
                    // 論理削除データは設定不可
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "得意先コード [" + customerCode.ToString("d08") + "] に該当するデータが存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                    // 得意先コード、得意先名をクリア
                    cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = "";     // 得意先コード
                    cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = "";     // 得意先名

                    // Grid変更なし
                    this._gridUpdFlg = false;
                }              
            }
        }

        /// <summary>
        /// Control.KeyDown イベント (UI_UltraGrid)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : キーが押されたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void uGrid_Customer_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            // アクティブセルがnullの時は処理を行わず終了
            if (this.uGrid_Customer.ActiveCell == null)
            {
                return;
            }

            // グリッド状態取得()
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.uGrid_Customer.CurrentState;

            //ドロップダウン状態の時は処理しない(UltraGridのデフォルトの動きにする)
            Control nextControl = null;
            if ((e.Control == false) && (e.Shift == false) && (e.Alt == false) &&
                ((status & Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown) != Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown))
            {

                switch (e.KeyCode)
                {
                    // ↑キー
                    case Keys.Up:
                        {
                            // 上のセルへ移動
                            nextControl = MoveAboveCell();
                            e.Handled = true;
                            break;
                        }
                    // ↓キー
                    case Keys.Down:
                        {
                            // 下のセルへ移動
                            nextControl = MoveBelowCell();
                            e.Handled = true;
                            break;
                        }
                    // ←キー
                    case Keys.Left:
                        {
                            // 上のセルへ移動
                            nextControl = MoveAboveCell();
                            e.Handled = true;

                            break;
                        }
                    // →キー
                    case Keys.Right:
                        {
                            // 下のセルへ移動
                            nextControl = MoveBelowCell();
                            e.Handled = true;

                            break;
                        }
                    case Keys.Space:
                        {
                            if (this.uGrid_Customer.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                            {
                                UltraGridCell ultraGridCell = this.uGrid_Customer.ActiveCell;
                                CellEventArgs cellEventArgs = new CellEventArgs(ultraGridCell);
                                uGrid_Customer_ClickCellButton(sender, cellEventArgs);
                            }
                            break;
                        }
                    case Keys.F3:
                        {
                            //削除ボタンをクリック
                            this.DeleteRow_Button_Click(sender,e);
                            break;
                        }
                    case Keys.F5:
                        {
                            //ガイドボタンをクリック
                            this.Guid_Button_Click(sender, e);
                            break;
                        }
                }

                if (nextControl != null)
                {
                    nextControl.Focus();
                }
            }
        }

        /// <summary>
        ///	ultraGrid.KeyPress イベント(Cell)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDのキー押下イベント処理。</br>
        /// <br></br>
        /// </remarks>
        private void uGrid_Customer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Customer.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Customer.ActiveCell;

            // 得意先コードの入力桁数チェック
            if (cell.Column.Key == MY_SCREEN_CUSTOMER_CODE)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(8, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
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
        /// <param name="NumberFlg">数値入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        /// <remarks>
        /// Note			:	押されたキーが数値のみ有効にする処理を行います。<br />
        /// <br></br>
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg, Boolean NumberFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }

            // 押されたキーが数値以外、かつ数値以外入力不可
            if (!Char.IsDigit(key) && !NumberFlg)
            {
                return false;
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = "";
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
                // マイナス(小数点)が入力可能か？
                if (minusFlg == false)
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                // 小数点以下桁数が0か？
                if (priod == 0)
                {
                    return false;
                }
                else
                {
                    // 小数点が既に存在するか？
                    if (_strResult.Contains("."))
                    {
                        return false;
                    }
                }
            }
            else
            {
                // 小数点が既に存在するか？
                if (_strResult.Contains("."))
                {
                    int index = _strResult.IndexOf('.');
                    string strDecimal = _strResult.Substring(index + 1);

                    if ((strDecimal.Length >= priod) && (selstart > index))
                    {
                        // 小数桁が入力可能桁数以上で、カーソル位置が小数点以降
                        return false;
                    }
                    else if (((keta - priod) < index))
                    {
                        // 整数部の桁数が入力可能桁数を超えた
                        return false;
                    }
                }
                else
                {
                    // 小数点桁数を前提に整数部の桁数を決定
                    if (((keta - priod) <= _strResult.Length))
                    {
                        return false;
                    }
                }
            }

            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring(0, selstart) + key
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
                else if (_strResult.Contains("."))
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else if ((_strResult[0] == '-') && (_strResult.Contains(".")))
                {
                    if (_strResult.Length > (keta + 2))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// リターンキー移動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : リターンキー押下時の制御を行います。</br>
        /// <br></br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "DeleteRow_Button":            // GRID削除ボタン
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // GRIDの得意先コードへフォーカス制御
                                        this.uGrid_Customer.Rows[0].Cells[MY_SCREEN_CUSTOMER_CODE].Activate();
                                        this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "uGrid_Customer":      // グリッド
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // ガイドボタンにフォーカスがある
                                        if (this.uGrid_Customer.ActiveCell != null)
                                        {
                                            Infragistics.Win.UltraWinGrid.UltraGridState status = this.uGrid_Customer.CurrentState;

                                            if ((this.uGrid_Customer.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button) &&
                                                (status & Infragistics.Win.UltraWinGrid.UltraGridState.RowLast) == Infragistics.Win.UltraWinGrid.UltraGridState.RowLast)
                                            {
                                                // セルのスタイルがボタンで、セルの最終行の場合
                                                if ((int)this.uGrid_Customer.ActiveCell.Row.Cells[MY_SCREEN_ODER].Value == this._campaignLinkDataTable.Rows.Count)
                                                {
                                                    // 最終行の場合、行を追加
                                                    this.tbsPartsList_AddRow();
                                                }
                                            }
                                        }

                                        // 次のセルへ移動
                                        bool moveFlg = this.MoveNextAllowEditCell(false);
                                        if (moveFlg)
                                        {
                                            e.NextCtrl = null;
                                        }
                                        else if (!this._gridUpdFlg)
                                        {
                                            this.MovePrevAllowEditCell(false);
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        if (this.MovePrevAllowEditCell(false))
                                        {
                                            // グリッド内のフォーカス制御
                                            e.NextCtrl = null;
                                        }

                                        break;
                                    }
                            }
                        }
                        break;
                    }
            }
          
        }

        # endregion

    }
}