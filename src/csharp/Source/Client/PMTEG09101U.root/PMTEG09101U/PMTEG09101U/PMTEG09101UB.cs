using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 手持手形検索フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 手持手形検索のフォームクラスです。</br>
    /// <br>Programmer : 20073 西 毅</br>
    /// <br>Date       : 2012/10/18</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2012/10/18 20073 西 毅 新規作成</br>
    /// <br>UpDate</br>
    /// <br>2012/10/26 99020 山路 芳郎 初期日付にシステム日付をセット</br>
    /// <br>　　　　　　　　　　　　　　PM7SPに合わせる</br>
    /// </remarks>
    public partial class PMTEG09101UB : Form
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private RcvDraftDataAcs _rcvDraftDataAcs;
        private RcvDraftDataSet.RcvDraftDataTable _rcvDraftDataTable;
        private DataView _rcvDraftView = null;
        private DialogResult _dialogRes = DialogResult.Cancel;

        public RcvDraftData _rcvDraftData = null;
        private ImageList _imageList16 = null;												// イメージリスト

        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region プロパティ
        /// <summary>伝票番号リスト</summary>
        public RcvDraftData RcvDraftDataOfGuide
        {
            get { return this._rcvDraftData; }
            set { this._rcvDraftData = value; }
        }
        # endregion

        // ===================================================================================== //
        // 外部に提供する定数群
        // ===================================================================================== //
        # region Public Readonly Members
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// PMTEG09101UB
        /// </summary>
        public PMTEG09101UB()
        {
            InitializeComponent();

            //this._rcvDraftDataAcs = RcvDraftDataAcs.GetInstance();

            // 各コントロール初期設定
            this.Main_StatusBar.Panels["StatusBarPanel_Progress"].Visible = false;

            this._rcvDraftData = new RcvDraftData(); ;
            this._rcvDraftDataTable = new RcvDraftDataSet.RcvDraftDataTable(); ;
        }
        # endregion

        // ===================================================================================== //
        // 各種コンポーネントイベント処理郡
        // ===================================================================================== //
        # region Event Methods
        /// <summary>
        /// PMTEG09101UB_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMTEG09101UB_Load(object sender, EventArgs e)
        {

            // 画面初期化処理
            this.InitialSetting();

            //---------------------------------------------------------
            // 初期設定タイマー起動
            //---------------------------------------------------------
            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// RcvSearchProc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private int RcvSearchProc()
        {
            //---------------------------------------------------------
            // データ参照
            //---------------------------------------------------------
            //受取手形アクセスクラス
            if (_rcvDraftDataAcs == null)
                _rcvDraftDataAcs = new RcvDraftDataAcs();
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            List<RcvDraftData> retList = null;

            RcvDraftData paraRcvDraftData = new RcvDraftData();
            paraRcvDraftData.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            paraRcvDraftData.ValidityTerm = this.tDateEdit_ValidityData.GetLongDate();
            paraRcvDraftData.DraftKindCd = 0 ;  //手持
            status = this._rcvDraftDataAcs.Search(out retList, 2, paraRcvDraftData);

            Rcv_Draft_DataSet(retList);

            return status;
        }

        /// <summary>
        /// Rcv_Draft_DataSet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rcv_Draft_DataSet(List<RcvDraftData>  retList)
        {

            //---------------------------------------------------------
            // 売上伝票番号データテーブル
            //---------------------------------------------------------
            this._rcvDraftDataTable.Clear();
            int i = 1;
            foreach (RcvDraftData rcvDraftDataWork in retList)
            {
                RcvDraftDataSet.RcvDraftRow row = (RcvDraftDataSet.RcvDraftRow)this._rcvDraftDataTable.NewRow();
                row.RowNo = i;
                row.CreateDateTime = rcvDraftDataWork.CreateDateTime;
                row.UpdateDateTime = rcvDraftDataWork.UpdateDateTime;
                row.EnterpriseCode = rcvDraftDataWork.EnterpriseCode;
                row.FileHeaderGuid = rcvDraftDataWork.FileHeaderGuid;
                row.UpdEmployeeCode = rcvDraftDataWork.UpdEmployeeCode;
                row.UpdAssemblyId1 = rcvDraftDataWork.UpdAssemblyId1;
                row.UpdAssemblyId2 = rcvDraftDataWork.UpdAssemblyId2;
                row.LogicalDeleteCode = rcvDraftDataWork.LogicalDeleteCode;
                row.RcvDraftNo = rcvDraftDataWork.RcvDraftNo;
                row.DraftKindCd = rcvDraftDataWork.DraftKindCd;
                row.DraftDivide = rcvDraftDataWork.DraftDivide;
                row.Deposit = rcvDraftDataWork.Deposit;
                row.BankAndBranchCd = rcvDraftDataWork.BankAndBranchCd;
                row.BankAndBranchNm = rcvDraftDataWork.BankAndBranchNm;
                row.SectionCode = rcvDraftDataWork.SectionCode;
                row.AddUpSecCode = rcvDraftDataWork.AddUpSecCode;
                row.CustomerCode = rcvDraftDataWork.CustomerCode;
                row.CustomerName = rcvDraftDataWork.CustomerName;
                row.CustomerName2 = rcvDraftDataWork.CustomerName2;
                row.CustomerSnm = rcvDraftDataWork.CustomerSnm;
                row.ProcDate = rcvDraftDataWork.ProcDate;
                row.DraftDrawingDate = rcvDraftDataWork.DraftDrawingDate;
                row.DraftDrawingDateAdFormal = rcvDraftDataWork.DraftDrawingDateAdFormal;
                row.ValidityTerm = rcvDraftDataWork.ValidityTerm;
                row.ValidityTermAdFormal = string.Format("{0:0000}",rcvDraftDataWork.ValidityTerm / 10000) + '/'
                                         + string.Format("{0:00}", (rcvDraftDataWork.ValidityTerm / 100) % 100) + '/'
                                         + string.Format("{0:00}",rcvDraftDataWork.ValidityTerm % 100);

                row.DraftStmntDate = rcvDraftDataWork.DraftStmntDate;
                row.Outline1 = rcvDraftDataWork.Outline1;
                row.Outline2 = rcvDraftDataWork.Outline2;
                row.AcptAnOdrStatus = rcvDraftDataWork.AcptAnOdrStatus;
                row.DepositSlipNo = rcvDraftDataWork.DepositSlipNo;
                row.DepositRowNo = rcvDraftDataWork.DepositRowNo;
                //row.DepositDate = rcvDraftDataWork.DepositDateAdFormal;
                this._rcvDraftDataTable.AddRcvDraftRow(row);
                i++;
            }
            //---------------------------------------------------------
            // グリッド情報設定
            //---------------------------------------------------------
            this._rcvDraftView = this._rcvDraftDataTable.DefaultView;
            this.uGrid_RcvDraft.DataSource = this._rcvDraftView;
        }
        /// <summary>
        /// Initial_Timer_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // 初期設定タイマー解除
            this.Initial_Timer.Enabled = false;

            // 初期フォーカス位置指定
            if (RcvSearchProc() != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tDateEdit_ValidityData.Focus();
            }
            else
            {
                if (this.uGrid_RcvDraft.Rows.Count != 0)
                {
                    this.uGrid_RcvDraft.Rows[0].Selected = true;
                    this.uGrid_RcvDraft.Focus();
                }
                else
                {
                    this.tDateEdit_ValidityData.Focus();
                }
            }
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// </remarks>
        private void InitialSetting()
        {
            // ツールバー初期設定処理
            this.SetToolbar();

            // 各コントロール初期設定
            this.Main_StatusBar.Panels["StatusBarPanel_Progress"].Visible = false;
            this.GridFontSize_TComboEditor.Value = 11;

            // 固定ヘッダー機能の有効にする
            this.uGrid_RcvDraft.DisplayLayout.UseFixedHeaders = true;

            // 行サイズを設定
            this.uGrid_RcvDraft.DisplayLayout.Override.DefaultRowHeight = 22;

            ToolBarButtonEnabledSetting("uGrid_RcvDraft");

            this.Main_StatusBar.Panels["StatusBarPanel_Text"].Text = "F3：条件設定　F6：絞込　ESC：終了";
            //2012/10/26 yamaji ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            this.tDateEdit_ValidityData.SetDateTime(DateTime.Today);
            //2012/10/26 yamaji ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        
        }


        /// <summary>
        /// ツールバー初期設定処理
        /// </summary>
        /// <param>none</param>
        /// <returns>none</returns>
        /// <remarks>
        /// <br>Note       : ツールバーの初期設定を行います</br>
        /// </remarks>
        private void SetToolbar()
        {
            this._imageList16 = IconResourceManagement.ImageList16;

            // イメージリストを設定する
            Main_ToolbarsManager.ImageListSmall = this._imageList16;
            

            // ログイン担当者のアイコン設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools["LoginTitle_LabelTool"];
            loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            // 閉じるのアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Close_ButtonTool"];
            closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

            // 戻るのアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool returnButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Return_ButtonTool"];
            returnButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;

            // 得意先新規のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool customerNewButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["CustomerNew_ButtonTool"];
            customerNewButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CUSTOMERNEW;

            // 得意先編集のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool customerEditButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["CustomerEdit_ButtonTool"];
            customerEditButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CUSTOMERINPUT1;

            // 得意先削除のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool customerDeleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["CustomerDelete_ButtonTool"];
            customerDeleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CUSTOMERDELETE;

            // 得意先復元のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool customerRevivalButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["CustomerRevival_ButtonTool"];
            customerRevivalButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;

            // 設定のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool setupButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["SetUp_ButtonTool"];
            setupButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;

            // 詳細表示のアイコン設定
            Infragistics.Win.UltraWinToolbars.PopupMenuTool detailViewPopUpMenu = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)Main_ToolbarsManager.Tools["DetailView_PopupMenuTool"];
            detailViewPopUpMenu.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DETAILS;

            // 選択のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Select_ButtonTool"];
            selectButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;

            // 取消のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool clearButtonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Clear_ButtonTool"];
            clearButtonTool.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;

            // 検索のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool searchButtonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Search_ButtonTool"];
            searchButtonTool.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;

        }

        /// <summary>
        /// uButton_Close_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>ESCで画面終了を行うときに使用</remarks>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            // ボタンは隠れてます
            this.SetDialogRes(DialogResult.Cancel);
            this.CloseForm();
        }

        /// <summary>
        /// ultraGrid1_InitializeLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_RcvDraft_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_RcvDraft.DisplayLayout.Bands[0].Columns;

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
            }

            int visiblePosition = 0;

            //--------------------------------------------------------------------------------
            //  表示するカラム情報
            //--------------------------------------------------------------------------------
            this.uGrid_RcvDraft.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;
            this.uGrid_RcvDraft.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            this.uGrid_RcvDraft.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_RcvDraft.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_RcvDraft.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.uGrid_RcvDraft.DisplayLayout.Bands[0].Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;// None;
            this.uGrid_RcvDraft.DisplayLayout.Bands[0].Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

          
            // 手形番号
            Columns[this._rcvDraftDataTable.RcvDraftNoColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._rcvDraftDataTable.RcvDraftNoColumn.ColumnName].Hidden = false;
            Columns[this._rcvDraftDataTable.RcvDraftNoColumn.ColumnName].Width = 120;
            Columns[this._rcvDraftDataTable.RcvDraftNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._rcvDraftDataTable.RcvDraftNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._rcvDraftDataTable.RcvDraftNoColumn.ColumnName].Header.Caption = "手形番号";

            // 期日（有効期限）
            Columns[this._rcvDraftDataTable.ValidityTermAdFormalColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._rcvDraftDataTable.ValidityTermAdFormalColumn.ColumnName].Hidden = false;
            Columns[this._rcvDraftDataTable.ValidityTermAdFormalColumn.ColumnName].Width = 88;
            Columns[this._rcvDraftDataTable.ValidityTermAdFormalColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._rcvDraftDataTable.ValidityTermAdFormalColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._rcvDraftDataTable.ValidityTermAdFormalColumn.ColumnName].Header.Caption = "期　日";

            // 手形振出日
            Columns[this._rcvDraftDataTable.DraftDrawingDateAdFormalColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._rcvDraftDataTable.DraftDrawingDateAdFormalColumn.ColumnName].Hidden = false;
            Columns[this._rcvDraftDataTable.DraftDrawingDateAdFormalColumn.ColumnName].Width = 88;
            Columns[this._rcvDraftDataTable.DraftDrawingDateAdFormalColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._rcvDraftDataTable.DraftDrawingDateAdFormalColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._rcvDraftDataTable.DraftDrawingDateAdFormalColumn.ColumnName].Header.Caption = "振出日";

            // 取引先略称
            Columns[this._rcvDraftDataTable.CustomerSnmColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._rcvDraftDataTable.CustomerSnmColumn.ColumnName].Hidden = false;
            Columns[this._rcvDraftDataTable.CustomerSnmColumn.ColumnName].Width = 168;
            Columns[this._rcvDraftDataTable.CustomerSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._rcvDraftDataTable.CustomerSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._rcvDraftDataTable.CustomerSnmColumn.ColumnName].Header.Caption = "取　引";

            
            // 固定列区切り線設定
            this.uGrid_RcvDraft.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_RcvDraft.DisplayLayout.Override.HeaderAppearance.BackColor2;

        }

        /// <summary>
        /// uGrid_SelectBLGoodsDr_DoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_RcvDraft_DoubleClick(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // マウスポインタがグリッドのどの位置にあるかを判定する
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);

            // UIElementを取得する。
            Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
            if (objUIElement == null)
                return;

            // マウスポインターが列のヘッダ上にあるかチェック。
            Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
              (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

            if (objHeader != null) return;

            // マウスポインターが行の上にあるかチェック。
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
              (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

            if (objRow == null) return;

            this.SetRcvDraftData(objRow);
            this.SetDialogRes(DialogResult.OK);
            this.CloseForm();

        }

        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        # region Private Methods
        /// <summary>
        /// 画面終了処理
        /// </summary>
        private void CloseForm()
        {
            //if (this._dialogRes == DialogResult.Cancel) this._salesSlipNum = string.Empty;
            this.DialogResult = this._dialogRes;
            this.Close();
        }

        /// <summary>
        /// ダイアログリザルト設定処理
        /// </summary>
        /// <param name="dialogRes">ダイアログリザルト</param>
        private void SetDialogRes(DialogResult dialogRes)
        {
            _dialogRes = dialogRes;
        }

        /// <summary>
        /// 伝票番号設定処理
        /// </summary>
        /// <param name="objRow"></param>
        private void SetRcvDraftData(Infragistics.Win.UltraWinGrid.UltraGridRow objRow)
        {
            //this._rcvDraftData.CreateDateTime = (DateTime)objRow.Cells[this._rcvDraftDataTable.CreateDateTimeColumn.ColumnName].Value;
            //this._rcvDraftData.UpdateDateTime = (DateTime)objRow.Cells[this._rcvDraftDataTable.UpdateDateTimeColumn.ColumnName].Value;
            this._rcvDraftData.EnterpriseCode = (string)objRow.Cells[this._rcvDraftDataTable.EnterpriseCodeColumn.ColumnName].Value;
            //this._rcvDraftData.FileHeaderGuid = (Guid)objRow.Cells[this._rcvDraftDataTable.FileHeaderGuidColumn.ColumnName].Value;
            this._rcvDraftData.UpdEmployeeCode = (string)objRow.Cells[this._rcvDraftDataTable.UpdEmployeeCodeColumn.ColumnName].Value;
            this._rcvDraftData.UpdAssemblyId1 = (string)objRow.Cells[this._rcvDraftDataTable.UpdAssemblyId1Column.ColumnName].Value;
            this._rcvDraftData.UpdAssemblyId2 = (string)objRow.Cells[this._rcvDraftDataTable.UpdAssemblyId2Column.ColumnName].Value;
            this._rcvDraftData.LogicalDeleteCode = (int)objRow.Cells[this._rcvDraftDataTable.LogicalDeleteCodeColumn.ColumnName].Value;
            this._rcvDraftData.RcvDraftNo = (string)objRow.Cells[this._rcvDraftDataTable.RcvDraftNoColumn.ColumnName].Value;
            this._rcvDraftData.DraftKindCd = (int)objRow.Cells[this._rcvDraftDataTable.DraftKindCdColumn.ColumnName].Value;
            this._rcvDraftData.DraftDivide = (int)objRow.Cells[this._rcvDraftDataTable.DraftDivideColumn.ColumnName].Value;
            this._rcvDraftData.Deposit = (long)objRow.Cells[this._rcvDraftDataTable.DepositColumn.ColumnName].Value;
            this._rcvDraftData.BankAndBranchCd = (int)objRow.Cells[this._rcvDraftDataTable.BankAndBranchCdColumn.ColumnName].Value;
            this._rcvDraftData.BankAndBranchNm = (string)objRow.Cells[this._rcvDraftDataTable.BankAndBranchNmColumn.ColumnName].Value;
            this._rcvDraftData.SectionCode = (string)objRow.Cells[this._rcvDraftDataTable.SectionCodeColumn.ColumnName].Value;
            this._rcvDraftData.AddUpSecCode = (string)objRow.Cells[this._rcvDraftDataTable.AddUpSecCodeColumn.ColumnName].Value;
            this._rcvDraftData.CustomerCode = (int)objRow.Cells[this._rcvDraftDataTable.CustomerCodeColumn.ColumnName].Value;
            this._rcvDraftData.CustomerName = (string)objRow.Cells[this._rcvDraftDataTable.CustomerNameColumn.ColumnName].Value;
            this._rcvDraftData.CustomerName2 = (string)objRow.Cells[this._rcvDraftDataTable.CustomerName2Column.ColumnName].Value;
            this._rcvDraftData.CustomerSnm = (string)objRow.Cells[this._rcvDraftDataTable.CustomerSnmColumn.ColumnName].Value;
            this._rcvDraftData.ProcDate = (int)objRow.Cells[this._rcvDraftDataTable.ProcDateColumn.ColumnName].Value;
            this._rcvDraftData.DraftDrawingDate = (DateTime)objRow.Cells[this._rcvDraftDataTable.DraftDrawingDateColumn.ColumnName].Value;
            this._rcvDraftData.DraftDrawingDateAdFormal = (string)objRow.Cells[this._rcvDraftDataTable.DraftDrawingDateAdFormalColumn.ColumnName].Value;
            this._rcvDraftData.ValidityTerm = (int)objRow.Cells[this._rcvDraftDataTable.ValidityTermColumn.ColumnName].Value;
            this._rcvDraftData.DraftStmntDate = (int)objRow.Cells[this._rcvDraftDataTable.DraftStmntDateColumn.ColumnName].Value;
            this._rcvDraftData.Outline1 = (string)objRow.Cells[this._rcvDraftDataTable.Outline1Column.ColumnName].Value;
            this._rcvDraftData.Outline2 = (string)objRow.Cells[this._rcvDraftDataTable.Outline2Column.ColumnName].Value;
            this._rcvDraftData.AcptAnOdrStatus = (int)objRow.Cells[this._rcvDraftDataTable.AcptAnOdrStatusColumn.ColumnName].Value;
            this._rcvDraftData.DepositSlipNo = (int)objRow.Cells[this._rcvDraftDataTable.DepositSlipNoColumn.ColumnName].Value;
            this._rcvDraftData.DepositRowNo = (int)objRow.Cells[this._rcvDraftDataTable.DepositRowNoColumn.ColumnName].Value;
            //this._rcvDraftData.DepositDateAdFormal = (int)objRow.Cells[this._rcvDraftDataTable.DepositDateColumn.ColumnName].Value;
        }
        # endregion

        /// <summary>
        /// グリッドフォントサイズコンボエディタ値変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void GridFontSize_TComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this.GridFontSize_TComboEditor.Value is int)
            {
                int fontSize = (int)this.GridFontSize_TComboEditor.Value;

                if (fontSize != 0)
                {
                    this.uGrid_RcvDraft.Font = new System.Drawing.Font("ＭＳ ゴシック", fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
                }
            }

        }

        /// <summary>
        /// 抽出結果グリッドキーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_RcvDraft_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.F3:
                        {
                            this.ActiveControl = this.tDateEdit_ValidityData;
                            this.tDateEdit_ValidityData.Focus();
                            ToolBarButtonEnabledSetting("tDateEdit_ValidityData");
                            break;
                        }
                    default:
                        break;
                }
            }
        }

         /// <summary>
        /// キー押下イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMTEG09101UB_KeyDown(object sender, KeyEventArgs e)
        {
            // ESCキー押下による画面閉じる処理
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            //F6キー押下
            if (e.KeyCode == Keys.F6)
            {

                if (RcvSearchProc() != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.tDateEdit_ValidityData.Focus();
                }
                else
                {
                    this.uGrid_RcvDraft.Focus();
                }

                ToolBarButtonEnabledSetting("uGrid_RcvDraft");
            }


        }

        /// <summary>
        /// 選択ボタンクリック処理
        /// </summary>
        private void SelectButtonClick()
        {
            this.SetRcvDraftData(this.uGrid_RcvDraft.ActiveRow);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// フォーカスコントロールイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            try
            {
                switch (e.PrevCtrl.Name)
                {

                    // 期日 ============================================ //
                    case "tDateEdit_ValidityData":
                        {
                            if (e.NextCtrl.Name == "uGrid_RcvDraft")
                            {
                                if (RcvSearchProc() != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    //this.tDateEdit_ValidityData.Focus();
                                    e.NextCtrl = tDateEdit_ValidityData;
                                }
                            }
                            break;

                        }
                    // 検索結果グリッド ======================================== //
                    case "uGrid_RcvDraft":
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                    {
                                        Infragistics.Win.UltraWinToolbars.ButtonTool selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Select_ButtonTool"];

                                        if (selectButton.SharedProps.Visible)
                                        {
                                            // 選択ボタンクリック処理
                                            this.SelectButtonClick();

                                        }
                                        break;  
                                    }
                            }
                            break;
                        }
                }

                ToolBarButtonEnabledSetting(e.NextCtrl.Name);

            }
            catch
            {
            }
            finally
            {
            }

        }

        /// <summary>
        /// ツールバーツールクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void Main_ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Return_ButtonTool":
                    {
                        this.Close();
                        break;
                    }
                case "Select_ButtonTool":
                    {
                        // 選択ボタンクリック処理
                        this.SelectButtonClick();

                        break;
                    }
            }

        }
        		/// <summary>
		/// ツールバーボタン有効無効設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : ツールバーボタン有効無効設定を行います</br>
		/// </remarks>
        private void ToolBarButtonEnabledSetting(string NextCtrlName)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Select_ButtonTool"];
            if (NextCtrlName == "uGrid_RcvDraft")
            {
                selectButton.SharedProps.Enabled = true;
            }
            else
            {
                selectButton.SharedProps.Enabled = false;
            }

        }

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        #region Public Methods
        #endregion

    }
}