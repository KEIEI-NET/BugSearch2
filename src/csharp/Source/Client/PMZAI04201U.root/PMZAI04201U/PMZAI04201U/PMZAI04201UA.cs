using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 棚卸表示UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 棚卸表示UIフォームクラス</br>
    /// <br>Programmer  : 30350 櫻井 亮太</br>
    /// <br>Date        : 2008/11/10</br>
    /// <br>Update Note : 2009/03/12 30414 忍 幸史 障害ID:12303対応</br>
    /// <br>Update Note : 2014/03/05 田建委</br>
    /// <br>            : Redmine#42247 印刷機能の追加</br>
    /// <br>Update Note : 2014/03/13 田建委</br>
    /// <br>            : メーカーガイドのToolTipメッセージの対応</br>
    /// <br>Update Note : 2014/03/26 田建委</br>
    /// <br>            : Redmine#42247 障害対応</br>
    /// <br>            : ・「表示タイプ」が「最大」の場合に差額の表示がPM7SPと違っている対応 </br>
    /// <br>            : ・表示区分を「全社計」で抽出した時、対象が無かった場合障害の対応 </br>
    /// <br>            : ・結果対象が無い場合、エラーメッセージの変更</br>
    /// </remarks>
    public partial class PMZAI04201UA : Form
    {
        #region Constants

        // アセンブリID
        private const string ASSMBLY_ID = "PMZAI04201U";

        // グリッド列
        private const string COLUMN_WARECODE = "WareCode"; // ADD 2014/03/05 田建委 Redmine#42247
        private const string COLUMN_WARE = "Ware";
        private const string COLUMN_ITEM = "Item";
        private const string COLUMN_MONY = "Mony";

        private const string COLUMN_MAXMONY = "MaxItem";
        private const string COLUMN_BALANCE = "Balance";

        // 表示区分１
        private const string LISTDIV1_0 = "倉庫別";
        private const string LISTDIV1_1 = "全社計";
        private const int LISTDIV1_0_VALUE = 0;
        private const int LISTDIV1_1_VALUE = 1;

        // 表示区分２
        private const string LISTDIV2_0 = "全て";
        private const string LISTDIV2_1 = "自社在庫";
        private const string LISTDIV2_2 = "受託在庫";
        private const int LISTDIV2_0_VALUE = 0;
        private const int LISTDIV2_1_VALUE = 1;
        private const int LISTDIV2_2_VALUE = 2;

        // 表示タイプ
        private const string LISTTYPE_0 = "通常";
        private const string LISTTYPE_1 = "アイテム数＝0はカウントしない";
        private const string LISTTYPE_2 = "最大";
        private const int LISTTYPE_0_VALUE = 0;
        private const int LISTTYPE_1_VALUE = 1;
        private const int LISTTYPE_2_VALUE = 2;

        // 倉庫区分
        private const string WAREHOUSEDIV_0 = "範囲";
        private const string WAREHOUSEDIV_1 = "単独";
        private const int WAREHOUSEDIV_0_VALUE = 0;
        private const int WAREHOUSEDIV_1_VALUE = 1;


        #endregion Constants


        #region Private Members

        private ControlScreenSkin _controlScreenSkin;

        private string _enterpriseCode;

        //private DateGetAcs _dateGetAcs;
        private InventoryDataDspAcs _inventoryDataDspAcs;

        private MakerAcs _makerAcs;
        private MakerUMnt makerUmnt;

        private WarehouseAcs _warehouseAcs;
        private Warehouse warehouse;

        private Dictionary<string, Warehouse> _warehouseDic;

        // 検索条件格納
        private InventoryDataDspParam _extrInfoForPrint; // ADD 2014/03/05 田建委 Redmine#42247
        #endregion


        #region Constructor

        /// <summary>
        /// 棚卸表示UIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 出荷部品表示UIフォームクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/17</br>
        /// </remarks>
        public PMZAI04201UA()
		{

			InitializeComponent();

            this._controlScreenSkin = new ControlScreenSkin();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            
            //this._dateGetAcs = DateGetAcs.GetInstance();

            this._inventoryDataDspAcs = new InventoryDataDspAcs();
            this._makerAcs = new MakerAcs();
            this.makerUmnt = new MakerUMnt();

            this._warehouseAcs = new WarehouseAcs();
            this.warehouse = new Warehouse();

            ReadWarehouse();

            // 画面クリア
            ClearScreen();

            // 画面初期設定
            SetInitialSetting();

            
        }

        #endregion


        #region Private Methods

        /// <summary>
        /// 倉庫マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 倉庫マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/17</br>
        /// </remarks>
        private void ReadWarehouse()
        {
            ArrayList retList = new ArrayList();
            this._warehouseDic = new Dictionary<string, Warehouse>();

            int status = _warehouseAcs.SearchAll(out  retList, this._enterpriseCode);

            try
            {
                foreach(Warehouse warehouse in retList)
                {
                    if (warehouse.LogicalDeleteCode == 0)
                    {
                        this._warehouseDic.Add(warehouse.WarehouseCode.Trim(), warehouse);
                    }
                    else
                    {

                    }
                }
            }
            catch
            {
                this._warehouseDic = new Dictionary<string, Warehouse>();
            }

        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報の初期設定を行います。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/17</br>
        /// <br>Update Note : 2014/03/05 田建委</br>
        /// <br>            : Redmine#42247 印刷機能の追加</br>
        /// </remarks>
        private void SetInitialSetting()
        {
            //---------------------------------
            // 画面スキンファイルの読込(デフォルトスキン指定)
            //---------------------------------
            // スキン変更除外設定
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.Standard_UGroupBox.Name);
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);

            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // コントロールサイズ設定
            //this.tEdit_SectionCodeAllowZero.Size = new Size(28, 24);
            //this.tEdit_SectionName.Size = new Size(175, 24);

            //---------------------------------
            // アイコン設定
            //---------------------------------
            this.tToolbarsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;
            ButtonTool workButton;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Undo"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;

            //----- ADD 2014/03/05 田建委 Redmine#42247 ---------->>>>>
            // 印刷
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Print"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;
            // PDF表示
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_PDF"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PREVIEW;
            //----- ADD 2014/03/05 田建委 Redmine#42247 ----------<<<<<

            ImageList imageList16 = IconResourceManagement.ImageList16;
            //this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            //---------------------------------
            // グリッド設定
            //---------------------------------
            CreateGrid(new List<InventoryDataDspResult>());
            SetGridLayout();

            this.tNedit_GoodsMakerCd.Focus();
        }

        /// <summary>
        /// 画面情報クリア処理
        /// </summary>
        /// 
        /// <remarks>
        /// <br>Note        : 画面情報をクリアします。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/17</br>
        /// <br>Update Note : 2014/03/05 田建委</br>
        /// <br>            : Redmine#42247 印刷機能の追加</br>
        /// </remarks>
        private void ClearScreen()
        {
            this.tNedit_GoodsMakerCd.Clear();
            this.tEdit_GoodsMakerName.Clear();
            this.WarehouseDiv_tComboEditor.SelectedIndex = 0;
            this.tEdit_WarehouseCode_St.Clear();
            this.tEdit_StWarehouseName.Clear();
            this.tEdit_WarehouseCode_Ed.Clear();
            this.tEdit_EdWarehouseName.Clear();
            this.tEdit_warehouseCd01.Clear();
            this.tEdit_warehouseCd02.Clear();
            this.tEdit_warehouseCd03.Clear();
            this.tEdit_warehouseCd04.Clear();
            this.tEdit_warehouseCd05.Clear();
            this.tEdit_warehouseCd06.Clear();
            this.tEdit_warehouseCd07.Clear();
            this.tEdit_warehouseCd08.Clear();
            this.tEdit_warehouseCd09.Clear();
            this.tEdit_warehouseCd10.Clear();
            this.ListDiv1_tComboEditor.SelectedIndex = 0;
            this.ListDiv2_tComboEditor.SelectedIndex = 0;
            this.ListTypeDiv_tComboEditor.SelectedIndex = 0;
            
            // グリッド
            CreateGrid(new List<InventoryDataDspResult>());

            adjustButtonEnable(); // ADD 2014/03/05 田建委 Redmine#42247

            // フォーカス設定
            this.tNedit_GoodsMakerCd.Focus();
        }

        /// <summary>
        /// グリッド作成処理
        /// </summary>
        /// <param name="updHisDspWorkList">更新履歴リスト</param>
        /// <remarks>
        /// <br>Note        : グリッドを作成します。</br>
        /// <br>Programmer  : 3050 櫻井 亮太</br>
        /// <br>Date        : 2008/11/17</br>
        /// <br>Update Note : 2014/03/05 田建委</br>
        /// <br>            : Redmine#42247 印刷機能の追加</br>
        /// <br>Update Note : 2014/03/26 田建委</br>
        /// <br>            : Redmine#42247 表示区分を「全社計」で抽出した時、対象が無かった場合障害の対応</br>
        /// </remarks>
        private void CreateGrid(List<InventoryDataDspResult> inventoryDataDspResultList)
        {
            //--------------------------------------
            // グリッド列、データ設定
            //--------------------------------------
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add(COLUMN_WARECODE, typeof(string)); // ADD 2014/03/05 田建委 Redmine#42247
            dataTable.Columns.Add(COLUMN_WARE, typeof(string));
            dataTable.Columns.Add(COLUMN_ITEM, typeof(string));
            dataTable.Columns.Add(COLUMN_MONY, typeof(string));

            dataTable.Columns.Add(COLUMN_MAXMONY, typeof(string));
            dataTable.Columns.Add(COLUMN_BALANCE, typeof(string));
            if (ListDiv1_tComboEditor.SelectedIndex == 0)
            {
                if (inventoryDataDspResultList.Count != 0)
                {
                    for (int index = 0; index < inventoryDataDspResultList.Count + 1; index++)
                    {
                        DataRow dataRow = dataTable.NewRow();

                        dataRow[COLUMN_WARECODE] = ""; // ADD 2014/03/05 田建委 Redmine#42247
                        dataRow[COLUMN_WARE] = "";
                        dataRow[COLUMN_ITEM] = "";
                        dataRow[COLUMN_MONY] = "";

                        dataRow[COLUMN_MAXMONY] = "";
                        dataRow[COLUMN_BALANCE] = "";

                        dataTable.Rows.Add(dataRow);
                    }
                }
            }
            else if(ListDiv1_tComboEditor.SelectedIndex == 1)
            {
                if (inventoryDataDspResultList.Count != 0) // ADD 2014/03/26 田建委 Redmine#42247
                {
                    DataRow dataRow = dataTable.NewRow();

                    dataRow[COLUMN_WARECODE] = ""; // ADD 2014/03/05 田建委 Redmine#42247
                    dataRow[COLUMN_WARE] = "";
                    dataRow[COLUMN_ITEM] = "";
                    dataRow[COLUMN_MONY] = "";

                    dataRow[COLUMN_MAXMONY] = "";
                    dataRow[COLUMN_BALANCE] = "";

                    dataTable.Rows.Add(dataRow);
                }
            }
            this.uGrid_Details.DataSource = dataTable;

            this.uGrid_Details.ActiveRow = null;
        }

        /// <summary>
        /// グリッドレイアウト設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : グリッドレイアウトを設定します。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/17</br>
        /// <br>Update Note : 2014/03/05 田建委</br>
        /// <br>            : Redmine#42247 印刷機能の追加</br>
        /// </remarks>
        private void SetGridLayout()
        {
            //--------------------------------------
            // グリッド外観設定
            //--------------------------------------
            ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

            // キャプション
            columns[COLUMN_WARE].Header.Caption = "倉庫";
            columns[COLUMN_ITEM].Header.Caption = "棚卸アイテム数";
            columns[COLUMN_MONY].Header.Caption = "棚卸金額";
            columns[COLUMN_MAXMONY].Header.Caption = "最大棚卸金額";
            columns[COLUMN_BALANCE].Header.Caption = "差額";

            // 列幅
            columns[COLUMN_WARE].Width = 140;
            columns[COLUMN_ITEM].Width = 140;
            columns[COLUMN_MONY].Width = 140;
            columns[COLUMN_MAXMONY].Width = 140;
            columns[COLUMN_BALANCE].Width = 140;

            // 表示
            columns[COLUMN_WARECODE].Hidden = true; // ADD 2014/03/05 田建委 Redmine#42247
            if (this.ListTypeDiv_tComboEditor.SelectedIndex != 2)
            {
                columns[COLUMN_MONY].Hidden = false;
                columns[COLUMN_MAXMONY].Hidden = true;
                columns[COLUMN_BALANCE].Hidden = true;
            }
            else
            {
                columns[COLUMN_MONY].Hidden = true;
                columns[COLUMN_MAXMONY].Hidden = false;
                columns[COLUMN_BALANCE].Hidden = false;
            }

            // テキスト位置(HAlign)
            columns[COLUMN_WARE].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_ITEM].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_MONY].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_MAXMONY].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_BALANCE].CellAppearance.TextHAlign = HAlign.Right;

            // テキスト位置(VAlign)
            columns[COLUMN_WARE].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_ITEM].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_MONY].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_MAXMONY].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_BALANCE].CellAppearance.TextVAlign = VAlign.Middle;
        }

        /// <summary>
        /// 棚卸表示抽出結果画面表示処理
        /// </summary>
        /// <param name="shipmentPartsDspResultList">出荷部品照会抽出結果リスト</param>
        /// <remarks>
        /// <br>Note        : 出荷部品照会抽出結果リストを画面表示します。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/17</br>
        /// <br>Update Note : 2014/03/05 田建委</br>
        /// <br>            : Redmine#42247 印刷機能の追加</br>
        /// <br>Update Note : 2014/03/26 田建委</br>
        /// <br>            : Redmine#42247 「表示タイプ」が「最大」の場合に差額の表示がPM7SPと違っている対応</br>
        /// </remarks>
        private void InventoryDataDspResultToScreen(List<InventoryDataDspResult> inventoryDataDspResultList)
        {
            if (inventoryDataDspResultList == null)
            {
                return;
            }

            string warehouseName = "";
            int inventoryItemCnt = 0;
            double inventoryMony = 0;
            double maximumInventoryMony = 0;
            double balanceMony = 0;
            int i = 0;
            int suminventoryItemCnt =0;
            double suminventoryMony = 0;
            double summaximumInventoryMony = 0;
            double sumbalanceMony=0;
            foreach (InventoryDataDspResult inventoryDataDspResult in inventoryDataDspResultList)
            {
                //----- ADD 2014/03/05 田建委 Redmine#42247 ---------->>>>>
                //倉庫コード
                this.uGrid_Details.Rows[i].Cells[COLUMN_WARECODE].Value = inventoryDataDspResult.WarehouseCode;
                //----- ADD 2014/03/05 田建委 Redmine#42247 ----------<<<<<

                //倉庫名称
                warehouseName = inventoryDataDspResult.WarehouseName;
                this.uGrid_Details.Rows[i].Cells[COLUMN_WARE].Value = warehouseName;

                inventoryItemCnt = inventoryDataDspResult.InventoryItemCnt;
                this.uGrid_Details.Rows[i].Cells[COLUMN_ITEM].Value = inventoryItemCnt.ToString("###,##0");
                suminventoryItemCnt += inventoryItemCnt;
                
                if (ListTypeDiv_tComboEditor.Text != LISTTYPE_2)
                {
                    inventoryMony = inventoryDataDspResult.InventoryMony;
                    this.uGrid_Details.Rows[i].Cells[COLUMN_MONY].Value = inventoryMony.ToString("###,##0");
                    suminventoryMony += inventoryMony;
                }
                else
                {
                    maximumInventoryMony = inventoryDataDspResult.MaximuminventoryMony;
                    this.uGrid_Details.Rows[i].Cells[COLUMN_MAXMONY].Value = maximumInventoryMony.ToString("###,##0");
                    //balanceMony = inventoryDataDspResult.InventoryMony - inventoryDataDspResult.MaximuminventoryMony; // DEL 2014/03/26 田建委 Redmine#42247
                    balanceMony = inventoryDataDspResult.MaximuminventoryMony - inventoryDataDspResult.InventoryMony; // ADD 2014/03/26 田建委 Redmine#42247
                    this.uGrid_Details.Rows[i].Cells[COLUMN_BALANCE].Value = balanceMony.ToString("###,##0");
                    summaximumInventoryMony += maximumInventoryMony;
                    sumbalanceMony += balanceMony;
                }
                i++;
            }
            this.uGrid_Details.Rows[i].Cells[COLUMN_WARE].Value = "全社合計";
            this.uGrid_Details.Rows[i].Cells[COLUMN_ITEM].Value = suminventoryItemCnt.ToString("###,##0");
            if (ListTypeDiv_tComboEditor.Text != LISTTYPE_2)
            {
                this.uGrid_Details.Rows[i].Cells[COLUMN_MONY].Value = suminventoryMony.ToString("###,##0");
            }
            else
            {
                this.uGrid_Details.Rows[i].Cells[COLUMN_MAXMONY].Value = summaximumInventoryMony.ToString("###,##0");
                this.uGrid_Details.Rows[i].Cells[COLUMN_BALANCE].Value = sumbalanceMony.ToString("###,##0");
            }

        }

        /// <summary>
        /// 棚卸表示抽出結果画面表示処理
        /// </summary>
        /// <param name="shipmentPartsDspResultList">出荷部品照会抽出結果リスト</param>
        /// <remarks>
        /// <br>Note        : 出荷部品照会抽出結果リストを画面表示します。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/17</br>
        /// <br>Update Note : 2014/03/26 田建委</br>
        /// <br>            : Redmine#42247 「表示タイプ」が「最大」の場合に差額の表示がPM7SPと違っている対応</br>
        /// </remarks>
        private void InventoryDataDspResultToScreen2(List<InventoryDataDspResult> inventoryDataDspResultList)
        {
            if (inventoryDataDspResultList == null)
            {
                return;
            }

            int inventoryItemCnt = 0;
            double inventoryMony = 0;
            double maximumInventoryMony = 0;
            double balanceMony = 0;
            int suminventoryItemCnt = 0;
            double suminventoryMony = 0;
            double summaximumInventoryMony = 0;
            double sumbalanceMony = 0;
            foreach (InventoryDataDspResult inventoryDataDspResult in inventoryDataDspResultList)
            {
                inventoryItemCnt = inventoryDataDspResult.InventoryItemCnt;
                suminventoryItemCnt += inventoryItemCnt;

                if (ListTypeDiv_tComboEditor.Text != LISTTYPE_2)
                {
                    inventoryMony = inventoryDataDspResult.InventoryMony;
                    suminventoryMony += inventoryMony;
                }
                else
                {
                    maximumInventoryMony = inventoryDataDspResult.MaximuminventoryMony;
                    //balanceMony = inventoryDataDspResult.InventoryMony - inventoryDataDspResult.MaximuminventoryMony; // DEL 2014/03/26 田建委 Redmine#42247
                    balanceMony = inventoryDataDspResult.MaximuminventoryMony - inventoryDataDspResult.InventoryMony; // ADD 2014/03/26 田建委 Redmine#42247
                    summaximumInventoryMony += maximumInventoryMony;
                    sumbalanceMony += balanceMony;
                }
            }
            this.uGrid_Details.Rows[0].Cells[COLUMN_WARE].Value = "全社合計";
            this.uGrid_Details.Rows[0].Cells[COLUMN_ITEM].Value = suminventoryItemCnt.ToString("###,##0");
            if (ListTypeDiv_tComboEditor.Text != LISTTYPE_2)
            {
                this.uGrid_Details.Rows[0].Cells[COLUMN_MONY].Value = suminventoryMony.ToString("###,##0");
            }
            else
            {
                this.uGrid_Details.Rows[0].Cells[COLUMN_MAXMONY].Value = summaximumInventoryMony.ToString("###,##0");
                this.uGrid_Details.Rows[0].Cells[COLUMN_BALANCE].Value = sumbalanceMony.ToString("###,##0");
            }

        }


        /// <summary>
        /// 確定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 確定処理を行います。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/17</br>
        /// <br>Update Note : 2014/03/05 田建委</br>
        /// <br>            : Redmine#42247 印刷機能の追加</br>
        /// <br>Update Note : 2014/03/26 田建委</br>
        /// <br>            : Redmine#42247 結果対象が無い場合、エラーメッセージの変更</br>
        /// </remarks>
        private void Search()
        {
            // 画面情報チェック
            bool bStatus = CheckScreenInput();
            if (!bStatus)
            {
                return;
            }

            // 検索条件格納
            InventoryDataDspParam extrInfo;
            SetExtrInfo(out extrInfo);

            this._extrInfoForPrint = extrInfo; // ADD 2014/03/05 田建委 Redmine#42247

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "抽出中";
            msgForm.Message = "棚卸データの抽出中です。";

            int status;
            List<InventoryDataDspResult> inventoryDataDspResultList;

            try
            {
                msgForm.Show();

               // 検索処理
                status = this._inventoryDataDspAcs.Search(extrInfo, out inventoryDataDspResultList);
                if (status == 0)
                {

                    SetGridLayout();
                    CreateGrid(inventoryDataDspResultList);

                    // 画面表示
                    if (ListDiv1_tComboEditor.SelectedIndex == 0)
                    {
                        InventoryDataDspResultToScreen(inventoryDataDspResultList);
                    }
                    else if (ListDiv1_tComboEditor.SelectedIndex == 1)
                    {
                        InventoryDataDspResultToScreen2(inventoryDataDspResultList);
                    }

                    adjustButtonEnable(); // ADD 2014/03/05 田建委 Redmine#42247
                        return;
                }
            }
            finally
            {
                msgForm.Close();
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "Search",
                                       //"検索条件に該当する棚卸品番は存在しません。", // DEL 2014/03/26 田建委 Redmine#42247
                                       "該当するデータがありません。", // ADD 2014/03/26 田建委 Redmine#42247
                                       status,
                                       MessageBoxButtons.OK);

                        // グリッド情報クリア
                        CreateGrid(new List<InventoryDataDspResult>());

                        adjustButtonEnable(); // ADD 2014/03/05 田建委 Redmine#42247
                        return;
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "Search",
                                       "確定処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        // グリッド情報クリア
                        CreateGrid(new List<InventoryDataDspResult>());

                        adjustButtonEnable(); // ADD 2014/03/05 田建委 Redmine#42247
                        return;
                    }
            }
        }

        /// <summary>
        /// 画面情報チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 画面情報をチェックします。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/17</br>
        /// </remarks>
        private bool CheckScreenInput()
        {
            string errMsg = "";

            try
            {
                //メーカーコード
                //if (this.tNedit_GoodsMakerCd.Text == "")
                //{
                //    errMsg = this.GoodsMakerLabel.Text + "を入力してください";
                //    return (false);
                //}
                //if (WarehouseDiv_tComboEditor.Text == WAREHOUSEDIV_0 && (tEdit_WarehouseCode_St.DataText == "" && tEdit_WarehouseCode_Ed.DataText == ""))
                //{
                //    errMsg = this.WarehouseLabel.Text + "(範囲)を入力してください";
                //    return (false);
                //}
                if (WarehouseDiv_tComboEditor.Text == WAREHOUSEDIV_0 && (tEdit_WarehouseCode_St.DataText!="" && tEdit_WarehouseCode_Ed.DataText != "") && (Int32.Parse(tEdit_WarehouseCode_St.DataText) > Int32.Parse(tEdit_WarehouseCode_Ed.DataText)))
                {
                    errMsg = this.WarehouseLabel.Text + "の入力範囲が不正です";
                    return (false);
                }
                if (WarehouseDiv_tComboEditor.Text == WAREHOUSEDIV_1 && (tEdit_warehouseCd01.DataText == "" && tEdit_warehouseCd02.DataText == "" && tEdit_warehouseCd03.DataText == "" &&
                    tEdit_warehouseCd04.DataText == "" && tEdit_warehouseCd05.DataText == "" && tEdit_warehouseCd06.DataText == "" && tEdit_warehouseCd07.DataText == "" &&
                    tEdit_warehouseCd08.DataText == "" && tEdit_warehouseCd09.DataText == "" && tEdit_warehouseCd10.DataText == ""))
                {
                    errMsg = this.WarehouseLabel.Text + "(単独)を入力してください";
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// 検索条件格納処理
        /// </summary>
        /// <param name="extrInfo">検索条件(明示的にoutパラメータで渡します)</param>
        /// <remarks>
        /// <br>Note        : 検索条件を格納します。</br>
        /// <br>Programmer  : 30350 櫻井　亮太</br>
        /// <br>Date        : 2008/11/17</br>
        /// <br>Update Note : 2014/03/05 田建委</br>
        /// <br>            : Redmine#42247 印刷機能の追加</br>
        /// </remarks>
        private void SetExtrInfo(out InventoryDataDspParam extrInfo)
        {
            extrInfo = new InventoryDataDspParam();

            // 企業コード
            extrInfo.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // メーカーコード
            extrInfo.GoodsMakerCd = tNedit_GoodsMakerCd.GetInt();
            //----- ADD 2014/03/05 田建委 Redmine#42247 ---------->>>>>
            // メーカー名称
            extrInfo.GoodsMakerName = tEdit_GoodsMakerName.Text.Trim();
            //----- ADD 2014/03/05 田建委 Redmine#42247 ----------<<<<<
            // 倉庫指定区分
            extrInfo.WarehouseDiv = WarehouseDiv_tComboEditor.SelectedIndex;
            // 開始倉庫コード
            extrInfo.StWarehouseCode = tEdit_WarehouseCode_St.DataText.Trim().PadLeft(4, '0');
            if (this.tEdit_WarehouseCode_Ed.DataText != "")
            {
                // 終了倉庫コード
                extrInfo.EdWarehouseCode = tEdit_WarehouseCode_Ed.DataText.Trim().PadLeft(4, '0');
            }
            // 倉庫コード01
            extrInfo.WarehouseCd01 = tEdit_warehouseCd01.DataText.Trim().PadLeft(4, '0');
            // 倉庫コード02
            extrInfo.WarehouseCd02 = tEdit_warehouseCd02.DataText.Trim().PadLeft(4, '0');
            // 倉庫コード03
            extrInfo.WarehouseCd03 = tEdit_warehouseCd03.DataText.Trim().PadLeft(4, '0');
            // 倉庫コード04
            extrInfo.WarehouseCd04 = tEdit_warehouseCd04.DataText.Trim().PadLeft(4, '0');
            // 倉庫コード05
            extrInfo.WarehouseCd05 = tEdit_warehouseCd05.DataText.Trim().PadLeft(4, '0');
            // 倉庫コード06
            extrInfo.WarehouseCd06 = tEdit_warehouseCd06.DataText.Trim().PadLeft(4, '0');
            // 倉庫コード07
            extrInfo.WarehouseCd07 = tEdit_warehouseCd07.DataText.Trim().PadLeft(4, '0');
            // 倉庫コード08
            extrInfo.WarehouseCd08 = tEdit_warehouseCd08.DataText.Trim().PadLeft(4, '0');
            // 倉庫コード09
            extrInfo.WarehouseCd09 = tEdit_warehouseCd09.DataText.Trim().PadLeft(4, '0');
            // 倉庫コード010
            extrInfo.WarehouseCd10 = tEdit_warehouseCd10.DataText.Trim().PadLeft(4, '0');
            // 表示区分１
            extrInfo.ListDiv1 = ListDiv1_tComboEditor.SelectedIndex;
            // 表示区分２
            extrInfo.ListDiv2 = ListDiv2_tComboEditor.SelectedIndex;
            //表示タイプ
            extrInfo.ListTypeDiv = ListTypeDiv_tComboEditor.SelectedIndex;

        }

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <param name="defaultButton">初期表示ボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // 親ウィンドウフォーム
                                         errLevel,                          // エラーレベル
                                         ASSMBLY_ID,                        // アセンブリID
                                         message,                           // 表示するメッセージ
                                         status,                            // ステータス値
                                         msgButton,                         // 表示するボタン
                                         defaultButton);                    // 初期表示ボタン
            return dialogResult;
        }

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="methodName">処理名称</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // 親ウィンドウフォーム
                                         errLevel,			                // エラーレベル
                                         this.Name,						    // プログラム名称
                                         ASSMBLY_ID, 		  　　		    // アセンブリID
                                         methodName,						// 処理名称
                                         "",					            // オペレーション
                                         message,	                        // 表示するメッセージ
                                         status,							// ステータス値
                                         this._inventoryDataDspAcs,			// エラーが発生したオブジェクト
                                         msgButton,         			  	// 表示するボタン
                                         MessageBoxDefaultButton.Button1);	// 初期表示ボタン

            return dialogResult;
        }

        #endregion Private Methods


        #region Control Events

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : フォームがLoadされた時に発生します。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/17</br>
        /// </remarks>
        private void PMZAI04201UA_Load(object sender, EventArgs e)
        {
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.uGrid_Details.ActiveRow = null;

            this.Initial_Timer.Enabled = true;
            this.GuudsMakerGuide_Button.ImageList = imageList16;
            this.GuudsMakerGuide_Button.Appearance.Image = Size16_Index.STAR1;

            //倉庫区分
            this.WarehouseDiv_tComboEditor.Items.Clear();
            this.WarehouseDiv_tComboEditor.Items.Add(WAREHOUSEDIV_0_VALUE, WAREHOUSEDIV_0);
            this.WarehouseDiv_tComboEditor.Items.Add(WAREHOUSEDIV_1_VALUE, WAREHOUSEDIV_1);
            this.WarehouseDiv_tComboEditor.MaxDropDownItems = this.WarehouseDiv_tComboEditor.Items.Count;
            //表示区分１
            this.ListDiv1_tComboEditor.Items.Clear();
            this.ListDiv1_tComboEditor.Items.Add(LISTDIV1_0_VALUE, LISTDIV1_0);
            this.ListDiv1_tComboEditor.Items.Add(LISTDIV1_1_VALUE, LISTDIV1_1);
            this.ListDiv1_tComboEditor.MaxDropDownItems = this.ListDiv1_tComboEditor.Items.Count;
            //表示区分２
            this.ListDiv2_tComboEditor.Items.Clear();
            this.ListDiv2_tComboEditor.Items.Add(LISTDIV2_0_VALUE, LISTDIV2_0);
            this.ListDiv2_tComboEditor.Items.Add(LISTDIV2_1_VALUE, LISTDIV2_1);
            this.ListDiv2_tComboEditor.Items.Add(LISTDIV2_2_VALUE, LISTDIV2_2);
            this.ListDiv2_tComboEditor.MaxDropDownItems = this.ListDiv2_tComboEditor.Items.Count;
            //表示タイプ
            this.ListTypeDiv_tComboEditor.Items.Clear();
            this.ListTypeDiv_tComboEditor.Items.Add(LISTTYPE_0_VALUE, LISTTYPE_0);
            this.ListTypeDiv_tComboEditor.Items.Add(LISTTYPE_1_VALUE, LISTTYPE_1);
            this.ListTypeDiv_tComboEditor.Items.Add(LISTTYPE_2_VALUE, LISTTYPE_2);
            this.ListTypeDiv_tComboEditor.MaxDropDownItems = this.ListTypeDiv_tComboEditor.Items.Count;

            this.WarehouseDiv_tComboEditor.SelectedIndex = 0;
            this.ListDiv1_tComboEditor.SelectedIndex = 0;
            this.ListDiv2_tComboEditor.SelectedIndex = 0;
            this.ListTypeDiv_tComboEditor.SelectedIndex = 0;

        }


        private void WarehouseDiv_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this.WarehouseDiv_tComboEditor.Text == WAREHOUSEDIV_0)
            {
                tEdit_warehouseCd01.Enabled = false;
                tEdit_warehouseCd02.Enabled = false;
                tEdit_warehouseCd03.Enabled = false;
                tEdit_warehouseCd04.Enabled = false;
                tEdit_warehouseCd05.Enabled = false;
                tEdit_warehouseCd06.Enabled = false;
                tEdit_warehouseCd07.Enabled = false;
                tEdit_warehouseCd08.Enabled = false;
                tEdit_warehouseCd09.Enabled = false;
                tEdit_warehouseCd10.Enabled = false;
                tEdit_WarehouseCode_St.Enabled = true;
                tEdit_WarehouseCode_Ed.Enabled = true;
            }
            if (this.WarehouseDiv_tComboEditor.Text == WAREHOUSEDIV_1)
            {
                tEdit_WarehouseCode_St.Enabled = false;
                tEdit_WarehouseCode_Ed.Enabled = false;
                tEdit_warehouseCd01.Enabled = true;
                tEdit_warehouseCd02.Enabled = true;
                tEdit_warehouseCd03.Enabled = true;
                tEdit_warehouseCd04.Enabled = true;
                tEdit_warehouseCd05.Enabled = true;
                tEdit_warehouseCd06.Enabled = true;
                tEdit_warehouseCd07.Enabled = true;
                tEdit_warehouseCd08.Enabled = true;
                tEdit_warehouseCd09.Enabled = true;
                tEdit_warehouseCd10.Enabled = true;
            }
            tEdit_warehouseCd01.Clear();
            tEdit_warehouseCd02.Clear();
            tEdit_warehouseCd03.Clear();
            tEdit_warehouseCd04.Clear();
            tEdit_warehouseCd05.Clear();
            tEdit_warehouseCd06.Clear();
            tEdit_warehouseCd07.Clear();
            tEdit_warehouseCd08.Clear();
            tEdit_warehouseCd09.Clear();
            tEdit_warehouseCd10.Clear();
            tEdit_WarehouseCode_St.Clear();
            tEdit_WarehouseCode_Ed.Clear();
            tEdit_StWarehouseName.Clear();
            tEdit_EdWarehouseName.Clear();

        }

        /// <summary>
        /// ToolClick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : ツールバーがクリックされた時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// <br>Update Note : 2014/03/05 田建委</br>
        /// <br>            : Redmine#42247 印刷機能の追加</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 終了処理
                        Close();
                        break;
                    }
                case "ButtonTool_Decision":
                    {
                        // 確定処理
                        Search();
                        break;
                    }
                case "ButtonTool_Undo":
                    {
                        // クリア処理
                        ClearScreen();
                        break;
                    }
                //----- ADD 2014/03/05 田建委 Redmine#42247 ---------->>>>>
                case "ButtonTool_Print":
                    {
                        // 印刷
                        Print(false);
                        break;
                    }
                case "ButtonTool_PDF":
                    {
                        // PDF表示
                        Print(true);
                        break;
                    }
                //----- ADD 2014/03/05 田建委 Redmine#42247 ----------<<<<<
            }
        }

        //----- ADD 2014/03/05 田建委 Redmine#42247 ---------->>>>>
        /// <summary>
        /// 印刷(PDF表示)
        /// </summary>
        /// <param name="pdfOut">PDF表示するかどうか</param>
        /// <remarks>
        /// <br>Note        : 印刷(PDF表示)</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2014/03/05</br>
        /// </remarks>
        private void Print(bool pdfOut)
        {
            // 明細一覧が存在しない場合は実行不能
            if (this.uGrid_Details.Rows.Count == 0)
            {
                return;
            }

            // 印刷オブジェクト呼び出し
            SFCMN06001U printDialog = new SFCMN06001U();
            SFCMN06002C printInfo = new SFCMN06002C();

            printInfo.printmode = (pdfOut) ? 2 : 1;　// 2：PDF表示のみ、1：印刷のみ
            printInfo.pdfopen = false;
            printInfo.pdftemppath = "";

            // 直接印刷バージョン
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ASSMBLY_ID;　// 起動PGID
            // PDF出力履歴用
            printInfo.prpnm = "";

            // 検索条件格納
            if (_extrInfoForPrint != null)
            {
                printInfo.jyoken = _extrInfoForPrint;
            }

            // 印刷データ作成
            DataTable dt = null;
            GetPrintDataSetFromDataView(out dt);

            DataView dtView = new DataView(dt);
            printInfo.rdData = dtView;
            printInfo.key = dtView.Table.TableName;

            printDialog.PrintInfo = printInfo;

            DialogResult result = printDialog.ShowDialog(this);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            // PDF表示の場合
            if (printInfo.pdfopen)
            {
                PMZAI04201UB pdfForm = new PMZAI04201UB(this.Parent as Form);

                try
                {
                    pdfForm.PDFShow(printInfo.pdftemppath);
                }
                finally
                {
                    pdfForm.Close();
                    pdfForm.Dispose();
                }
            }
        }

        /// <summary>
        /// 印刷用データテーブル生成
        /// </summary>
        /// <param name="dt"></param>
        /// <remarks>
        /// <br>Note        : 印刷用データテーブル生成</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2014/03/05</br>
        /// </remarks>
        private void GetPrintDataSetFromDataView(out DataTable dt)
        {
            dt = new DataTable("InventoryDataDsp");

            dt.Columns.Add(COLUMN_WARECODE, typeof(string));
            dt.Columns.Add(COLUMN_WARE, typeof(string));
            dt.Columns.Add(COLUMN_ITEM, typeof(string));
            dt.Columns.Add(COLUMN_MONY, typeof(string));

            dt.Columns.Add(COLUMN_MAXMONY, typeof(string));
            dt.Columns.Add(COLUMN_BALANCE, typeof(string));

            DataRow row = null;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_Details.Rows)
            {
                row = dt.NewRow();

                row[COLUMN_WARECODE] = gridRow.Cells[COLUMN_WARECODE].Value;
                row[COLUMN_WARE] = gridRow.Cells[COLUMN_WARE].Value;
                row[COLUMN_ITEM] = gridRow.Cells[COLUMN_ITEM].Value;
                row[COLUMN_MONY] = gridRow.Cells[COLUMN_MONY].Value;
                row[COLUMN_MAXMONY] = gridRow.Cells[COLUMN_MAXMONY].Value;
                row[COLUMN_BALANCE] = gridRow.Cells[COLUMN_BALANCE].Value;

                dt.Rows.Add(row);
            }
        }

        /// <summary>
        /// ボタンの有効/無効切替
        /// </summary>
        /// <remarks>
        /// <br>Note        : ボタンの有効/無効切替</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2014/03/05</br>
        /// </remarks>
        private void adjustButtonEnable()
        {
            if (this.uGrid_Details.Rows.Count > 0)
            {
                // 印刷
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Print"].SharedProps.Enabled = true;
                // PDF出力
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_PDF"].SharedProps.Enabled = true;
            }
            else
            {
                // 印刷
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Print"].SharedProps.Enabled = false;
                // PDF出力
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_PDF"].SharedProps.Enabled = false;
            }
        }
        //----- ADD 2014/03/05 田建委 Redmine#42247 ----------<<<<<

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : メーカーガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/17</br>
        /// </remarks>
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                MakerUMnt makerUmnt;

                int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUmnt);
                if (status == 0)
                {
                    this.tNedit_GoodsMakerCd.DataText = makerUmnt.GoodsMakerCd.ToString();
                    this.tEdit_GoodsMakerName.DataText = makerUmnt.MakerName.Trim();

                    // フォーカス設定
                    this.ListDiv1_tComboEditor.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ExpandedStateChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 展開ステータスが変更された時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void Standard_UGroupBox_ExpandedStateChanged(object sender, EventArgs e)
        {
            Size topSize = new Size();

            topSize.Width = this.Form1_Top_Panel.Size.Width;
            topSize.Height = 20;

            if (this.Standard_UGroupBox.Expanded == true)
            {
                topSize.Height = 210;
            }
            else
            {
                topSize.Height = 20;
            }

            this.Form1_Top_Panel.Size = topSize;
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null)
            {
                return;
            }

            int rowIndex = this.uGrid_Details.ActiveRow.Index;

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;
                        break;
                    }
                case Keys.Up:
                    {
                        if (rowIndex == 0)
                        {
                            e.Handled = true;
                            //this.tDateEdit_CAddUpUpdExecDateSt.Focus();
                        }
                        else
                        {
                            e.Handled = true;
                            this.uGrid_Details.Rows[rowIndex - 1].Activate();
                            this.uGrid_Details.Rows[rowIndex - 1].Selected = true;
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if (rowIndex == this.uGrid_Details.Rows.Count - 1)
                        {
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = true;
                            this.uGrid_Details.Rows[rowIndex + 1].Activate();
                            this.uGrid_Details.Rows[rowIndex + 1].Selected = true;
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;
                        // グリッド表示を右にスクロール
                        this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position + 40;
                        break;
                    }
                case Keys.Left:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;
                        if (this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position != 0)
                        {
                            // グリッド表示を左にスクロール
                            this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position - 40;
                        }
                        break;
                    }
                case Keys.Home:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;

                        // 他キーとの組合せ無しの場合
                        if (e.Modifiers == Keys.None)
                        {
                            // グリッド表示を左先頭にスクロール
                            this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = 0;
                        }

                        // Controlキーとの組合せの場合
                        if (e.Modifiers == Keys.Control)
                        {
                            // 先頭行に移動
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);
                        }
                        break;
                    }
                case Keys.End:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;

                        // 他キーとの組合せ無しの場合
                        if (e.Modifiers == Keys.None)
                        {
                            // グリッド表示を左先頭にスクロール
                            this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Range;
                        }

                        // Controlキーとの組合せの場合
                        if (e.Modifiers == Keys.Control)
                        {
                            // 最終行に移動
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastRowInGrid);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドが非アクティブになった時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
            this.uGrid_Details.ActiveCell = null;
            this.uGrid_Details.ActiveRow = null;

            for (int index = 0; index < this.uGrid_Details.Rows.Count; index++)
            {
                this.uGrid_Details.Rows[index].Selected = false;
            }
        }

        /// <summary>
        /// Tick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 一定間隔が過ぎる度に時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // フォーカス設定
            this.tNedit_GoodsMakerCd.Focus();

            // グリッドのアクティブ行を削除
            this.uGrid_Details.ActiveRow = null;

            this.Initial_Timer.Enabled = false;
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : コントロールのフォーカスが変更された時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/10</br>
        /// <br>Update Note: 2014/03/05 田建委</br>
        /// <br>           : 既存障害：フォーカスについての対応</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // メーカーコード
            if (e.PrevCtrl == this.tNedit_GoodsMakerCd)
            {
                MakerUMnt makerUMnt = new MakerUMnt();
                MakerAcs makerAcs = new MakerAcs();

                makerAcs.Read(out makerUMnt, this._enterpriseCode, this.tNedit_GoodsMakerCd.GetInt());

                if (this.tNedit_GoodsMakerCd.GetInt() != 0)
                {
                    if (makerUMnt != null && makerUMnt.LogicalDeleteCode != 1)
                    {
                        this.tEdit_GoodsMakerName.DataText = makerUMnt.MakerName;
                        if (e.Key == Keys.Enter)
                        {
                            e.NextCtrl = ListDiv1_tComboEditor;
                        }
                    }
                    else
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "該当するメーカーが存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                        this.tNedit_GoodsMakerCd.Clear();
                        this.tEdit_GoodsMakerName.Clear();
                        e.NextCtrl = this.GuudsMakerGuide_Button;
                    }
                }
                else
                {
                    this.tEdit_GoodsMakerName.DataText = "全て";
                }
                if (e.ShiftKey == true)
                {
                    if (this.uGrid_Details.Rows.Count != 0)
                    {
                        e.NextCtrl = this.uGrid_Details;
                        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Activate();
                        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Selected = true;
                    }
                    else
                    {
                        //e.NextCtrl = this.tEdit_WarehouseCode_Ed; // DEL 2014/03/05 田建委 Redmine#42247
                        //----- ADD 2014/03/05 田建委 Redmine#42247 ----->>>>>
                        if (this.WarehouseDiv_tComboEditor.SelectedIndex == 0)
                        {
                        e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                    }
                        else
                        {
                            e.NextCtrl = this.tEdit_warehouseCd10;
                        }
                        //----- ADD 2014/03/05 田建委 Redmine#42247 -----<<<<<
                    }
                }

            }
            if (this.WarehouseDiv_tComboEditor.SelectedIndex == 0)
            {
                if (e.PrevCtrl == this.WarehouseDiv_tComboEditor)
                {
                    if (!e.ShiftKey) // ADD 2014/03/05 田建委 Redmine#42247
                    {
                    if (e.Key == Keys.Enter)
                    {
                        e.NextCtrl = this.tEdit_WarehouseCode_St;
                    }
                }
            }
            }
            else
            {
                if (e.PrevCtrl == this.WarehouseDiv_tComboEditor)
                {
                    if (!e.ShiftKey) // ADD 2014/03/05 田建委 Redmine#42247
                    {
                    if (e.Key == Keys.Enter)
                    {
                        e.NextCtrl = this.tEdit_warehouseCd01;
                    }
                }
            }
            }
            if (this.tEdit_WarehouseCode_Ed.Text == "")
            {
                if (e.PrevCtrl == this.tEdit_WarehouseCode_Ed)
                {
                    if (!e.ShiftKey) // ADD 2014/03/05 田建委 Redmine#42247
                    {
                    if (e.Key == Keys.Enter)
                    {
                        e.NextCtrl = this.tNedit_GoodsMakerCd;
                    }
                }
            }
            }

            if (e.PrevCtrl == this.tEdit_warehouseCd10)
            {
                //if (e.Key == Keys.Enter) // DEL 2014/03/05 田建委 Redmine#42247
                if (!e.ShiftKey) // ADD 2014/03/05 田建委 Redmine#42247
                {
                    if (e.Key == Keys.Enter || e.Key == Keys.Tab) // ADD 2014/03/05 田建委 Redmine#42247
                {
                    e.NextCtrl = this.tNedit_GoodsMakerCd;
                }
            }
            }
            if (e.PrevCtrl == this.tEdit_WarehouseCode_St)
            {
                if (e.Key == Keys.Down)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
            }
            if (e.PrevCtrl == this.tEdit_WarehouseCode_Ed)
            {
                if (e.Key == Keys.Down)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
            }
            if (this.WarehouseDiv_tComboEditor.SelectedIndex == 0)
            {
                if (e.PrevCtrl == this.WarehouseDiv_tComboEditor)
                {
                    if (e.Key == Keys.Down)
                    {
                        e.NextCtrl = e.PrevCtrl;
                    }
                }
            }
            if (e.PrevCtrl == this.tEdit_warehouseCd06)
            {
                if (e.Key == Keys.Down)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
            }
            if (e.PrevCtrl == this.tEdit_warehouseCd07)
            {
                if (e.Key == Keys.Down)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
            }
            if (e.PrevCtrl == this.tEdit_warehouseCd08)
            {
                if (e.Key == Keys.Down)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
            }
            if (e.PrevCtrl == this.tEdit_warehouseCd09)
            {
                if (e.Key == Keys.Down)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
            }
            if (e.PrevCtrl == this.tEdit_warehouseCd10)
            {
                if (e.Key == Keys.Down)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
            }

            // 倉庫コード(範囲)
            if (e.PrevCtrl == this.tEdit_WarehouseCode_St)
            {
                WarehouseAcs warehouseAcs = new WarehouseAcs();
                Warehouse warehouse = new Warehouse();
                if (this.tEdit_WarehouseCode_St.Text != "")
                {
                    if (this._warehouseDic.ContainsKey(tEdit_WarehouseCode_St.DataText.Trim().PadLeft(4, '0')))
                    {
                        tEdit_StWarehouseName.DataText = this._warehouseDic[tEdit_WarehouseCode_St.DataText.Trim().PadLeft(4, '0')].WarehouseName.Trim();
                        if (e.Key == Keys.Enter)
                        {
                            e.NextCtrl = tEdit_WarehouseCode_Ed;
                        }
                    }
                    //else
                    //{
                    //    TMsgDisp.Show(
                    //    this,
                    //    emErrorLevel.ERR_LEVEL_INFO,
                    //    this.Name,
                    //    "該当する倉庫が存在しません。",
                    //    -1,
                    //    MessageBoxButtons.OK);

                    //    this.tEdit_WarehouseCode_St.Clear();
                    //    this.tEdit_StWarehouseName.Clear();
                    //    e.NextCtrl = e.PrevCtrl;
                    //}
                }
                else
                {
                    this.tEdit_StWarehouseName.Clear();
                }
            }
            if (e.PrevCtrl == this.tEdit_WarehouseCode_Ed)
            {
                WarehouseAcs warehouseAcs = new WarehouseAcs();
                Warehouse warehouse = new Warehouse();
                if (this.tEdit_WarehouseCode_Ed.Text != "")
                {
                    if (this._warehouseDic.ContainsKey(tEdit_WarehouseCode_Ed.DataText.Trim().PadLeft(4, '0')))
                    {
                        tEdit_EdWarehouseName.DataText = this._warehouseDic[tEdit_WarehouseCode_Ed.DataText.Trim().PadLeft(4, '0')].WarehouseName.Trim();

                    }
                    //else
                    //{
                    //    TMsgDisp.Show(
                    //    this,
                    //    emErrorLevel.ERR_LEVEL_INFO,
                    //    this.Name,
                    //    "該当する倉庫が存在しません。",
                    //    -1,
                    //    MessageBoxButtons.OK);

                    //    this.tEdit_WarehouseCode_Ed.Clear();
                    //    this.tEdit_EdWarehouseName.Clear();
                    //    e.NextCtrl = e.PrevCtrl;
                    //}
                    if (e.Key == Keys.Enter)
                    {
                        e.NextCtrl = this.uGrid_Details;
                        //                        e.NextCtrl = tNedit_GoodsMakerCd;
                    }
                }
                else
                {
                    this.tEdit_EdWarehouseName.Clear();
                }
                if (e.ShiftKey == false)
                {
                    if (e.Key == Keys.Enter || e.Key == Keys.Tab) // ADD 2014/03/05 田建委 Redmine#42247
                    {
                    if (this.uGrid_Details.Rows.Count != 0)
                    {
                        e.NextCtrl = this.uGrid_Details;
                        this.uGrid_Details.Rows[0].Activate();
                        this.uGrid_Details.Rows[0].Selected = true;
                    }
                    else
                    {
                        e.NextCtrl = this.tNedit_GoodsMakerCd;
                    }
                }
                }

            }

            if (e.PrevCtrl == this.tEdit_warehouseCd01 && this.tEdit_warehouseCd01.DataText !="")
            {
                if (this._warehouseDic.ContainsKey(tEdit_warehouseCd01.DataText.Trim().PadLeft(4, '0')))
                {
                }
                else
                {
                    TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "該当する倉庫が存在しません。",
                    -1,
                    MessageBoxButtons.OK);
                    e.NextCtrl = e.PrevCtrl;
                    e.NextCtrl.Select();
                    tEdit_warehouseCd01.Clear();
                }
            } 
            if (e.PrevCtrl == this.tEdit_warehouseCd02 && this.tEdit_warehouseCd02.DataText !="")
            {
                if (this._warehouseDic.ContainsKey(tEdit_warehouseCd02.DataText.Trim().PadLeft(4, '0')))
                {
                }
                else
                {
                    TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "該当する倉庫が存在しません。",
                    -1,
                    MessageBoxButtons.OK);
                    e.NextCtrl = e.PrevCtrl;
                    e.NextCtrl.Select();
                    tEdit_warehouseCd02.Clear();
                }
            }
            if (e.PrevCtrl == this.tEdit_warehouseCd03 && this.tEdit_warehouseCd03.DataText != "")
            {
                if (this._warehouseDic.ContainsKey(tEdit_warehouseCd03.DataText.Trim().PadLeft(4, '0')))
                {
                }
                else
                {
                    TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "該当する倉庫が存在しません。",
                    -1,
                    MessageBoxButtons.OK);
                    e.NextCtrl = e.PrevCtrl;
                    e.NextCtrl.Select();
                    tEdit_warehouseCd03.Clear();
                }
            }
            if (e.PrevCtrl == this.tEdit_warehouseCd04 && this.tEdit_warehouseCd04.DataText != "")
            {
                if (this._warehouseDic.ContainsKey(tEdit_warehouseCd04.DataText.Trim().PadLeft(4, '0')))
                {
                }
                else
                {
                    TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "該当する倉庫が存在しません。",
                    -1,
                    MessageBoxButtons.OK);
                    e.NextCtrl = e.PrevCtrl;
                    e.NextCtrl.Select();
                    tEdit_warehouseCd04.Clear();
                }
            }
            if (e.PrevCtrl == this.tEdit_warehouseCd05 && this.tEdit_warehouseCd05.DataText != "")
            {
                if (this._warehouseDic.ContainsKey(tEdit_warehouseCd05.DataText.Trim().PadLeft(4, '0')))
                {
                }
                else
                {
                    TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "該当する倉庫が存在しません。",
                    -1,
                    MessageBoxButtons.OK);
                    e.NextCtrl = e.PrevCtrl;
                    e.NextCtrl.Select();
                    tEdit_warehouseCd05.Clear();
                }
            }
            if (e.PrevCtrl == this.tEdit_warehouseCd06 && this.tEdit_warehouseCd06.DataText != "")
            {
                if (this._warehouseDic.ContainsKey(tEdit_warehouseCd06.DataText.Trim().PadLeft(4, '0')))
                {
                }
                else
                {
                    TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "該当する倉庫が存在しません。",
                    -1,
                    MessageBoxButtons.OK);
                    e.NextCtrl = e.PrevCtrl;
                    e.NextCtrl.Select();
                    tEdit_warehouseCd06.Clear();
                }
            }
            if (e.PrevCtrl == this.tEdit_warehouseCd07 && this.tEdit_warehouseCd07.DataText != "")
            {
                if (this._warehouseDic.ContainsKey(tEdit_warehouseCd07.DataText.Trim().PadLeft(4, '0')))
                {
                }
                else
                {
                    TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "該当する倉庫が存在しません。",
                    -1,
                    MessageBoxButtons.OK);
                    e.NextCtrl = e.PrevCtrl;
                    e.NextCtrl.Select();
                    tEdit_warehouseCd07.Clear();
                }
            }
            if (e.PrevCtrl == this.tEdit_warehouseCd08 && this.tEdit_warehouseCd08.DataText != "")
            {
                if (this._warehouseDic.ContainsKey(tEdit_warehouseCd08.DataText.Trim().PadLeft(4, '0')))
                {
                }
                else
                {
                    TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "該当する倉庫が存在しません。",
                    -1,
                    MessageBoxButtons.OK);
                    e.NextCtrl = e.PrevCtrl;
                    e.NextCtrl.Select();
                    tEdit_warehouseCd08.Clear();
                }
            }
            if (e.PrevCtrl == this.tEdit_warehouseCd09 && this.tEdit_warehouseCd09.DataText != "")
            {
                if (this._warehouseDic.ContainsKey(tEdit_warehouseCd09.DataText.Trim().PadLeft(4, '0')))
                {
                }
                else
                {
                    TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "該当する倉庫が存在しません。",
                    -1,
                    MessageBoxButtons.OK);
                    e.NextCtrl = e.PrevCtrl;
                    e.NextCtrl.Select();
                    tEdit_warehouseCd09.Clear();
                }
            }
            if (e.PrevCtrl == this.tEdit_warehouseCd10 && this.tEdit_warehouseCd10.DataText != "")
            {
                if (this._warehouseDic.ContainsKey(tEdit_warehouseCd10.DataText.Trim().PadLeft(4, '0')))
                {
                }
                else
                {
                    TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "該当する倉庫が存在しません。",
                    -1,
                    MessageBoxButtons.OK);
                    e.NextCtrl = e.PrevCtrl;
                    e.NextCtrl.Select();
                    tEdit_warehouseCd10.Clear();
                }
            } 

            // グリッド
            if (e.PrevCtrl == this.uGrid_Details)
            {
                if (e.ShiftKey == false)
                {
                    if (this.uGrid_Details.Rows.Count != 0) // ADD 2014/03/05 田建委 Redmine#42247
                    {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        if (this.uGrid_Details.ActiveRow == null)
                        {
                            e.NextCtrl = null;
                            this.uGrid_Details.Rows[0].Activate();
                            this.uGrid_Details.Rows[0].Selected = true;
                        }
                        else
                        {
                            int rowIndex = this.uGrid_Details.ActiveRow.Index;
                            if (rowIndex != this.uGrid_Details.Rows.Count - 1)
                            {
                                e.NextCtrl = null;
                                this.uGrid_Details.Rows[rowIndex + 1].Activate();
                                this.uGrid_Details.Rows[rowIndex + 1].Selected = true;
                            }
                        }
                    }
                    return;
                }
                }
                else
                {
                    if (this.uGrid_Details.Rows.Count != 0)
                    {
                        //if (e.Key == Keys.Tab) // DEL 2014/03/05 田建委 Redmine#42247
                        if (e.Key == Keys.Tab || e.Key == Keys.Enter) // ADD 2014/03/05 田建委 Redmine#42247
                        {
                            if (this.uGrid_Details.ActiveRow == null)
                            {
                                e.NextCtrl = null;
                                this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Activate();
                                this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Selected = true;
                            }
                            else
                            {
                                int rowIndex = this.uGrid_Details.ActiveRow.Index;
                                if (rowIndex != 0)
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Rows[rowIndex - 1].Activate();
                                    this.uGrid_Details.Rows[rowIndex - 1].Selected = true;
                                }
                                else
                                {
                                    if (this.WarehouseDiv_tComboEditor.SelectedIndex == 0)
                                        e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                                    else
                                        e.NextCtrl = this.tEdit_warehouseCd10;
                                }
                            }
                        }
                        return;
                    }
                }
            }
        }

        #endregion Control Events

        private void uGrid_Details_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }

        private void ultraLabel1_Click(object sender, EventArgs e)
        {

        }

        private void ultraLabel4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Top_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ultraExpandableGroupBoxPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ultraCombo4_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }

        private void tEdit_SectionName_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ultraLabel5_Click(object sender, EventArgs e)
        {

        }

        private void tNedit_GoodsMakerCd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Top_Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Standard_UGroupBox_ExpandedStateChanging(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Top_Panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}