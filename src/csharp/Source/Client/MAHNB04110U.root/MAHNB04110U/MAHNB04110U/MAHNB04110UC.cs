using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Resources;//add 2011/07/18

namespace Broadleaf.Windows.Forms
{
    public partial class MAHNB04110UC : Form
    {
        #region Constructor

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="salesSlipSearchAcs"></param>
        /// <param name="salesSlipSearchResult"></param>
        public MAHNB04110UC(SalesSlipSearchAcs salesSlipSearchAcs, SalesSlipSearchResult salesSlipSearchResult)
        {
            _salesSlipSearchAcs = salesSlipSearchAcs;

            InitializeComponent();

            if (salesSlipSearchResult != null)
            {
                this._salesSlipSearchResult = salesSlipSearchResult;
            }
            this._dataSet = this._salesSlipSearchAcs.DataSet;
            this.uGrid_ViewDetails.DataSource = this._dataSet.SalesDetail;

            this._imageList16 = IconResourceManagement.ImageList16;
            this._returnButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_ViewDetail.Tools["ButtonTool_Return"];
            this._decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_ViewDetail.Tools["ButtonTool_Decision"];

            this.SetInitialDataValue();
            // ---------------------- ADD START 2011/07/18 朱宝軍 ----------------->>>>>
            #region ●PCCオプション
            //Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_PCC);// DEL 2011/08/08
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM);// ADD 2011/08/08
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Pcc = (int)Option.ON;
            }
            else
            {
                this._opt_Pcc = (int)Option.OFF;
            }
            #endregion
            // ---------------------- ADD END   2011/07/18 朱宝軍 -----------------<<<<<
        }

        #endregion  // Constructor

        private SalesSlipSearchAcs _salesSlipSearchAcs;

        private SalesSlipDataSet _dataSet;
        private ImageList _imageList16 = null;									// イメージリスト
        private SalesSlipSearchResult _salesSlipSearchResult;
        SortedList _supplierFormalStr = new SortedList();                       // 売上形式
        SortedList _supplierFormalTitleStr = new SortedList();                  // 日付タイトル
        SortedList _supplierSlipCdStr = new SortedList();                       // 伝票形式

        private Infragistics.Win.UltraWinToolbars.ButtonTool _returnButton;		// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _decisionButton;	// 確定ボタン
        // ---------------------- ADD START 2011/07/18 朱宝軍 ----------------->>>>>
        /// <summary>PCCオプション情報</summary>
        private int _opt_Pcc;
        public int Opt_Pcc
        {
            get { return _opt_Pcc; }
        }
        #region ■列挙体
        /// <summary>
        /// オプション有効有無
        /// </summary>
        public enum Option : int
        {
            /// <summary>無効</summary>
            OFF = 0,
            /// <summary>有効</summary>
            ON = 1,
        }
        #endregion
        // ---------------------- ADD END   2011/07/18 朱宝軍 -----------------<<<<<
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA ADD START
        // 自社設定アクセスクラス
        private CompanyInfAcs _companyAcs;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA ADD END

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        private void MAHNB04110UC_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // グリッド列初期設定処理
            this.GridColInitialSetting(this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns);

            // ボタン初期設定処理
            this.ButtonInitialSetting();

            // グリッド行初期設定処理
            this.GridRowInitialSetting();

            // ヘッダ部情報設定処理
            this.SetHeaderInfo();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA ADD START
            this._companyAcs = new CompanyInfAcs();
            CompanyInf companyInf;
            
            // 自社設定を取得
            this._companyAcs.Read(out companyInf, _salesSlipSearchResult.EnterpriseCode);
            if (companyInf != null)
            {
                // 部門管理区分が拠点であれば部門名を非表示
                // 0:拠点　1:拠点＋部　2:拠点＋部＋課（ソースより）
                if (companyInf.SecMngDiv == 0)
                {
                    this.uLabel_SubSectionCode.Visible = false;
                    this.uLabel_SubSectionName.Visible = false;
                    this.ultraLabel2.Visible = false;
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA ADD END

            // 対象伝票の明細情報を取得
            SalesSlipDetailSearch salesSlipDetailSearch = new SalesSlipDetailSearch();
            salesSlipDetailSearch.EnterpriseCode = _salesSlipSearchResult.EnterpriseCode;
            salesSlipDetailSearch.AcptAnOdrStatus = _salesSlipSearchResult.AcptAnOdrStatus;
            //salesSlipDetailSearch.SalesSlipNum = _salesSlipSearchResult.SearchSlipNum;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            salesSlipDetailSearch.SalesSlipNum = _salesSlipSearchResult.SalesSlipNum;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
            //this._salesSlipSearchAcs.SearchDetail(salesSlipDetailSearch);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
            this._salesSlipSearchAcs.SearchDetail( salesSlipDetailSearch, _salesSlipSearchResult );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD

            // 2008.12.11 add start []
            DataView dv = new DataView(this._dataSet.SalesDetail);
            dv.Sort = "SalesRowNo Asc";
            this.uGrid_ViewDetails.DataSource = dv;
            // 2008.12.11 add end []

        }

        /// <summary>
        /// 固定値変数初期化処理
        /// </summary>
        private void SetInitialDataValue()
        {
            // 売上形式 (10:見積,20:受注,30:売上,40:出荷)
            _supplierFormalStr.Add(10, "見積");
            _supplierFormalStr.Add(20, "受注");
            _supplierFormalStr.Add(30, "売上");
            _supplierFormalStr.Add(40, "貸出");

            // 日付表示タイトル (10:見積,20:受注,30:売上,40:出荷)
            _supplierFormalTitleStr.Add(10, "見積日");
            _supplierFormalTitleStr.Add(20, "受注日");
            _supplierFormalTitleStr.Add(30, "売上日");
            _supplierFormalTitleStr.Add(40, "貸出日");

            // 伝票区分 (0:売上,1:返品)
            _supplierSlipCdStr.Add(0, "売上");
            _supplierSlipCdStr.Add(1, "返品");
        }

        /// <summary>
        /// 売上形式名称取得
        /// </summary>
        /// <param name="salesFormal"></param>
        /// <returns></returns>
        private string SalesFormalName(int salesSlipCd, int accRecDivCd)
        {
            string retString = "";

            //0:売掛なし
            if (accRecDivCd == 0)
            {
                switch (salesSlipCd)
                {
                    case 0:
                        retString = "現金売上";
                        break;
                    case 1:
                        retString = "現金返品";
                        break;
                }
            }
            //1:売掛あり
            else
            {
                switch (salesSlipCd)
                {
                    case 0:
                        retString = "掛売上";
                        break;
                    case 1:
                        retString = "掛返品";
                        break;
                }
            }
            return (retString);
        }

        /// <summary>
        /// ヘッダ部情報設定処理
        /// </summary>
        private void SetHeaderInfo()
        {
            DateTime dt;

            //日付タイトル
            this.uLabel_DateTile.Text = _supplierFormalTitleStr[_salesSlipSearchResult.AcptAnOdrStatus].ToString();


            //this.uLabel_SupplierSlipNo.Text = _salesSlipSearchResult.SearchSlipNum.ToString();             // 伝票番号
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            this.uLabel_SupplierSlipNo.Text = _salesSlipSearchResult.SalesSlipNum.Trim();             // 伝票番号
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD

            // 売上形式
            if ((_salesSlipSearchResult.EstimateDivide == 2) && (_salesSlipSearchResult.AcptAnOdrStatus == 10))
            {
                this.uLabel_SupplierFormal.Text = "単価見積";
            }
            else
            {
                this.uLabel_SupplierFormal.Text = _supplierFormalStr[_salesSlipSearchResult.AcptAnOdrStatus].ToString();
            }

            // 2008.12.09 add start [8872]
            // 検索見積時は伝票区分は空白
            if (_salesSlipSearchResult.EstimateDivide != 3)
            {
                this.uLabel_SupplierSlipCd.Text = SalesFormalName(_salesSlipSearchResult.SalesSlipCd, _salesSlipSearchResult.AccRecDivCd);
            }
            else
            {
                this.uLabel_SupplierSlipCd.Text = string.Empty;
            }
            // 2008.12.09 add end [8872]

            this.uLabel_StockAgentCode.Text = _salesSlipSearchResult.SalesEmployeeCd;
            this.uLabel_StockAgentName.Text = _salesSlipSearchResult.SalesEmployeeNm;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //this.uLabel_CustomerCode.Text = _salesSlipSearchResult.CustomerCode.ToString();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            this.uLabel_CustomerCode.Text = _salesSlipSearchResult.CustomerCode.ToString( GetCustomerCodeFormat() );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            this.uLabel_CustomerName.Text = _salesSlipSearchResult.CustomerName;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA ADD START
            // 拠点コード
            this.uLabel_SectionCode.Text = _salesSlipSearchResult.SectionCode;
            // 拠点名
            this.uLabel_SectionName.Text = _salesSlipSearchResult.SectionGuideNm;
            // 部門コード
            this.uLabel_SubSectionCode.Text = _salesSlipSearchResult.SubSectionCode.ToString("00");
            // ADD 2008/11/05 不具合対応[7076] 部門コードが0の場合、空 ---------->>>>>
            // 部門コードが0の場合、空
            if (this.uLabel_SubSectionCode.Text.Equals("00")) this.uLabel_SubSectionCode.Text = string.Empty;
            // ADD 2008/11/05 不具合対応[7076] 部門コードが0の場合、空 ----------<<<<<
            // 部門名
            this.uLabel_SubSectionName.Text = _salesSlipSearchResult.SubSectionName;
            // 発行者コード
            this.uLabel_SalesInputCode.Text = _salesSlipSearchResult.SalesInputCode;
            // 発行者名
            this.uLabel_SalesInputName.Text = _salesSlipSearchResult.SalesInputName;
            // 受注者コード
            this.uLabel_FrontEmployeeCd.Text = _salesSlipSearchResult.FrontEmployeeCd;
            // 受注者名
            this.uLabel_FrontEmployeeName.Text = _salesSlipSearchResult.FrontEmployeeNm;
            // 絞込型式
            this.uLabel_FullModel.Text = _salesSlipSearchResult.FullModel;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA ADD END

            //出荷日
            if (_salesSlipSearchResult.AcptAnOdrStatus == 40)
            {
                dt = _salesSlipSearchResult.ShipmentDay;
            }
            //売上日
            else
            {
                dt = _salesSlipSearchResult.SalesDate;
            }

            if (dt == DateTime.MinValue)
            {
                this.uLabel_ArrivalGoodsDay.Text = "";
            }
            else
            {
                this.uLabel_ArrivalGoodsDay.Text = dt.ToString("yyyy年MM月dd日");
            }

            //入力日
            if (_salesSlipSearchResult.SearchSlipDate == DateTime.MinValue)
            {
                this.uLabel_StockAddUpADate.Text = "";
            }
            else
            {
                this.uLabel_StockAddUpADate.Text = _salesSlipSearchResult.SearchSlipDate.Date.ToString("yyyy年MM月dd日");
            }

        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
        /// <summary>
        /// ＵＩ設定ＸＭＬからのコードフォーマット取得(00,000,0000… etc.)
        /// </summary>
        /// <param name="editName"></param>
        /// <returns></returns>
        private string GetCodeFormat( string editName )
        {
            UiSet uiset;
            int status = uiSetControl1.ReadUISet( out uiset, editName );
            if ( status == 0 )
            {
                return string.Format( "{0};-{0};''", new string( '0', uiset.Column ) );
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 得意先コードフォーマット取得
        /// </summary>
        /// <returns></returns>
        private string GetCustomerCodeFormat()
        {
            return GetCodeFormat( "tNedit_CustomerCode" );
        }
        /// <summary>
        /// ＢＬコードフォーマット取得
        /// </summary>
        /// <returns></returns>
        private string GetBLGoodsCodeFormat()
        {
            return GetCodeFormat( "tNedit_BLGoodsCode" );
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD

        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        private void GridColInitialSetting(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns)
        {
            string acptAnOdrStatusTiTle = "";
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
            //string _moneyFormat = "#,##0;-#,##0;";
            //string _doubleFormat = "#,##0.00;-#,##0.00;";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
            string _moneyFormat = "#,##0;-#,##0;''";
            string _doubleFormat = "#,##0.00;-#,##0.00;''";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD
            //string _chargeFormat = "###9";
            //string _dateFormat = "yyyy/MM/dd";


            switch (_salesSlipSearchResult.AcptAnOdrStatus)
            {
                case 10: acptAnOdrStatusTiTle = "見積"; break;
                case 20: acptAnOdrStatusTiTle = "受注"; break;
                case 30: acptAnOdrStatusTiTle = "売上"; break;
                case 40: acptAnOdrStatusTiTle = "貸出"; break;
            }

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
                //入力許可設定
                //column.AutoEdit = false;
            }

            //--------------------------------------------------------------------------------
            //  表示するカラム情報
            //--------------------------------------------------------------------------------
#if False
			// 印刷フラグ
			Columns[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName].Header.Fixed = true;			// 固定項目
			Columns[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName].Hidden = false;
			Columns[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName].Header.Caption = "";
			Columns[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName].Width = 10;
			Columns[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
			Columns[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName].AutoEdit = true;
			Columns[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName].Header.VisiblePosition = 1;

			//No.
			Columns[this._dataSet.SalesDetail.NoColumn.ColumnName].Header.Fixed = true;			// 固定項目
			Columns[this._dataSet.SalesDetail.NoColumn.ColumnName].Hidden = false;
			Columns[this._dataSet.SalesDetail.NoColumn.ColumnName].Header.Caption = "No.";
			Columns[this._dataSet.SalesDetail.NoColumn.ColumnName].Width = 35;
			Columns[this._dataSet.SalesDetail.NoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			Columns[this._dataSet.SalesDetail.NoColumn.ColumnName].Header.VisiblePosition = 2;

			//メモ
			Columns[this._dataSet.SalesDetail.MemoExistNameColumn.ColumnName].Hidden = false;
			Columns[this._dataSet.SalesDetail.MemoExistNameColumn.ColumnName].Header.Caption = "メモ";
			Columns[this._dataSet.SalesDetail.MemoExistNameColumn.ColumnName].Width = 40;
			Columns[this._dataSet.SalesDetail.MemoExistNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			Columns[this._dataSet.SalesDetail.MemoExistNameColumn.ColumnName].Header.VisiblePosition = 3;
#endif
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA ADD START
            // 並びを変更した際にもvisiblePositionをいちいち変更しなくてすむように
            int visiblePositionNo = 1;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA ADD END

            //売上行番号
            Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Header.Fixed = true;			// 固定項目
            Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Header.Caption = "行番号";
            Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA DEL START
            //Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Header.VisiblePosition = 20; // 不要
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA MODIFY START
            // 先頭から1ずつ増やすように
            Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;
            //Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Header.VisiblePosition = 2;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA MODIFY END


            //売上日
            //Columns[this._dataSet.SalesDetail.SalesDateStringColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesDetail.SalesDateStringColumn.ColumnName].Header.Caption = "売上日";
            //Columns[this._dataSet.SalesDetail.SalesDateStringColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesDetail.SalesDateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //Columns[this._dataSet.SalesDetail.SalesDateStringColumn.ColumnName].Header.VisiblePosition = 4;
            //Columns[this._dataSet.SalesDetail.SalesDateStringColumn.ColumnName].Format = _dateFormat;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA MODIFY START
            //品番(商品番号から変更)
            Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Header.Caption = "品番";
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Width = 100;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Width = 200;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;
            //Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Header.VisiblePosition = 5;

            //品名(商品名から変更)
            Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Header.Caption = "品名";
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Width = 100;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Width = 200;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;
            //Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Header.VisiblePosition = 6;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA MODIFY END

            //メーカー名
            Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Header.Caption = "メーカー名";
            Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA MODIFY START
            Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;
            //Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Header.VisiblePosition = 7;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA MODIFY END

            // BLコード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA ADD START
            Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Header.Caption = "BLコード";
            Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Format = GetBLGoodsCodeFormat();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD

            // UNDONE:標準価格
/*
            Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Header.Caption = "標準価格";
            Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //Columns[this._dataSet.SalesDetail.AcceptAnOrderCntColumn.ColumnName].Format = _moneyFormat;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Format = _moneyFormat;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA ADD END
*/
            Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Header.Caption = "標準価格";
            Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;
            Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Format = _moneyFormat;

            //受注数
            // 2008.11.21 modify start [7076]
            // 受注数には受注数量ではなく出荷数を表示(佐藤M指示)
            // 2008.11.27 modify start [8333]
            // 受注ステータスが「受注」の時には受注残数を使用
            if (_salesSlipSearchResult.AcptAnOdrStatus == 20)
            {
                Columns[this._dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName].Hidden = false;
                Columns[this._dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName].Header.Caption = acptAnOdrStatusTiTle + "数";
                Columns[this._dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName].Width = 100;
                Columns[this._dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[this._dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName].Format = _doubleFormat;
                Columns[this._dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;
            }
            else
            {
                Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Hidden = false;
                Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Header.Caption = acptAnOdrStatusTiTle + "数";
                Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Width = 100;
                Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Format = _doubleFormat;
                Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;
            }
            // 2008.11.27 modify end [8333]
            //Columns[this._dataSet.SalesDetail.AcceptAnOrderCntColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesDetail.AcceptAnOrderCntColumn.ColumnName].Header.Caption = acptAnOdrStatusTiTle + "数";
            //Columns[this._dataSet.SalesDetail.AcceptAnOrderCntColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesDetail.AcceptAnOrderCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //Columns[this._dataSet.SalesDetail.AcceptAnOrderCntColumn.ColumnName].Format = _doubleFormat;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA MODIFY START
            //Columns[this._dataSet.SalesDetail.AcceptAnOrderCntColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;
            ////Columns[this._dataSet.SalesDetail.AcceptAnOrderCntColumn.ColumnName].Header.VisiblePosition = 8;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA MODIFY END
            // 2008.11.21 modify end [7076]

            ////受注残数
            ////受注時
            //if (_salesSlipSearchResult.AcptAnOdrStatus == 20)
            //{
            //    Columns[this._dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName].Hidden = false;
            //    Columns[this._dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName].Header.Caption = "受注残数";
            //    Columns[this._dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName].Width = 100;
            //    Columns[this._dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //    Columns[this._dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName].Header.VisiblePosition = 9;
            //    Columns[this._dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName].Format = _doubleFormat;
            //}
            ////出荷時
            //else if (_salesSlipSearchResult.AcptAnOdrStatus == 40)
            //{
            //    Columns[this._dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName].Hidden = false;
            //    Columns[this._dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName].Header.Caption = "出荷残数";
            //    Columns[this._dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName].Width = 100;
            //    Columns[this._dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //    Columns[this._dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName].Header.VisiblePosition = 9;
            //    Columns[this._dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName].Format = _doubleFormat;
            //}

            // UNDONE:売上単価
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.11.07 TOKUNAGA MODIFY START[7076]
            // 単価を消費税込み(SalesUnPrcTaxIncFlColumn)から消費税抜きに変更
            Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Header.Caption = acptAnOdrStatusTiTle + "単価";
            Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Format = _doubleFormat;  // MOD 2008/11/05 不具合対応[7076] 売上単価は小数点付 _moneyFormat→_doubleFormat
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA MODIFY START
            Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;
            //Columns[this._dataSet.SalesDetail.SalesUnPrcTaxIncFlColumn.ColumnName].Header.VisiblePosition = 10;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA MODIFY END
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.11.07 TOKUNAGA MODIFY END[7076]

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.14 TOKUNAGA DEL START
            //単位
            //Columns[this._dataSet.SalesDetail.UnitNameColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesDetail.UnitNameColumn.ColumnName].Header.Caption = "単位";
            //Columns[this._dataSet.SalesDetail.UnitNameColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesDetail.UnitNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.SalesDetail.UnitNameColumn.ColumnName].Header.VisiblePosition = 11;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.14 TOKUNAGA DEL END

            //売上金額（税込）
            //Columns[this._dataSet.SalesDetail.SalesMoneyTaxIncColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesDetail.SalesMoneyTaxIncColumn.ColumnName].Header.Caption = acptAnOdrStatusTiTle+ "金額";
            //Columns[this._dataSet.SalesDetail.SalesMoneyTaxIncColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesDetail.SalesMoneyTaxIncColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //Columns[this._dataSet.SalesDetail.SalesMoneyTaxIncColumn.ColumnName].Header.VisiblePosition = 12;
            //Columns[this._dataSet.SalesDetail.SalesMoneyTaxIncColumn.ColumnName].Format = _moneyFormat;

            //売上金額（税抜）
            Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Header.Caption = acptAnOdrStatusTiTle + "金額";
            Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA MODIFY START
            Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;
            //Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Header.VisiblePosition = 12;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA MODIFY END
            Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Format = _moneyFormat;

            //消費税
            Columns[this._dataSet.SalesDetail.SalsePriceConsTaxColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SalsePriceConsTaxColumn.ColumnName].Header.Caption = "消費税";
            Columns[this._dataSet.SalesDetail.SalsePriceConsTaxColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.SalsePriceConsTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA MODIFY START
            Columns[this._dataSet.SalesDetail.SalsePriceConsTaxColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;
            //Columns[this._dataSet.SalesDetail.SalsePriceConsTaxColumn.ColumnName].Header.VisiblePosition = 12;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA MODIFY END
            Columns[this._dataSet.SalesDetail.SalsePriceConsTaxColumn.ColumnName].Format = _moneyFormat;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.14 TOKUNAGA DEL START
            //特値区分(特売区分名称)
            //Columns[this._dataSet.SalesDetail.BargainNmColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesDetail.BargainNmColumn.ColumnName].Header.Caption = "特値区分";
            //Columns[this._dataSet.SalesDetail.BargainNmColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesDetail.BargainNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.SalesDetail.BargainNmColumn.ColumnName].Header.VisiblePosition = 13;

            ////得意先注番
            //Columns[this._dataSet.SalesDetail.PartySlipNumDtlColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesDetail.PartySlipNumDtlColumn.ColumnName].Header.Caption = "得意先注番";
            //Columns[this._dataSet.SalesDetail.PartySlipNumDtlColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesDetail.PartySlipNumDtlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.SalesDetail.PartySlipNumDtlColumn.ColumnName].Header.VisiblePosition = 14;

            ////基準単価
            //Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Header.Caption = "基準単価";
            //Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Header.VisiblePosition = 15;
            //Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Format = _doubleFormat;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.14 TOKUNAGA DEL END

            //原価単価
            Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Header.Caption = "原価単価";
            Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA MODIFY START
            Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;
            //Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Header.VisiblePosition = 16;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA MODIFY END
            Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Format = _doubleFormat;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA ADD START
            //原価金額
            Columns[this._dataSet.SalesDetail.SalesUnitTotalColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SalesUnitTotalColumn.ColumnName].Header.Caption = "原価金額";
            Columns[this._dataSet.SalesDetail.SalesUnitTotalColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.SalesUnitTotalColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesDetail.SalesUnitTotalColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;
            Columns[this._dataSet.SalesDetail.SalesUnitTotalColumn.ColumnName].Format = _doubleFormat;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA ADD END

            // --- ADD 2009/03/16 -------------------------------->>>>>
            // 倉庫名
            Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Header.Caption = "倉庫名";
            Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;

            // 棚番
            Columns[this._dataSet.SalesDetail.WarehouseShelfNoColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.WarehouseShelfNoColumn.ColumnName].Header.Caption = "棚番";
            Columns[this._dataSet.SalesDetail.WarehouseShelfNoColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.WarehouseShelfNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.WarehouseShelfNoColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;
            // --- ADD 2009/03/16 --------------------------------<<<<<

            ////仕入先
            //Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Header.Caption = "仕入先";
            //Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA MODIFY START
            //Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;
            ////Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Header.VisiblePosition = 17;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA MODIFY END
            
            //明細備考
            Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Header.Caption = "明細備考";
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Width = 100;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Width = 200;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA MODIFY START
            Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;
            //Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Header.VisiblePosition = 18;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA MODIFY END


            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.14 TOKUNAGA DEL START
            //売上伝票番号
            //Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Header.Caption = "伝票番号";
            //Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = 19;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.14 TOKUNAGA DEL END

            //客先納期
            if (_salesSlipSearchResult.AcptAnOdrStatus == 20)
            {
                Columns[this._dataSet.SalesDetail.DeliGdsCmpltDueDateStringColumn.ColumnName].Hidden = false;
                Columns[this._dataSet.SalesDetail.DeliGdsCmpltDueDateStringColumn.ColumnName].Header.Caption = "納品完了予定日";
                //Columns[this._dataSet.SalesDetail.DeliGdsCmpltDueDateStringColumn.ColumnName].Header.Caption = "客先納期";
                Columns[this._dataSet.SalesDetail.DeliGdsCmpltDueDateStringColumn.ColumnName].Width = 100;
                Columns[this._dataSet.SalesDetail.DeliGdsCmpltDueDateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                Columns[this._dataSet.SalesDetail.DeliGdsCmpltDueDateStringColumn.ColumnName].Header.VisiblePosition = 24;
            }
          
            //---ADD 2011/11/11 ------------------------------------------------------------->>>>>
            // 連携種別
            Columns[this._dataSet.SalesDetail.CooprtKindColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.CooprtKindColumn.ColumnName].Header.Caption = "連携種別";
            Columns[this._dataSet.SalesDetail.CooprtKindColumn.ColumnName].Width = 120;
            Columns[this._dataSet.SalesDetail.CooprtKindColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.CooprtKindColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;
            //---ADD 2011/11/11 -------------------------------------------------------------<<<<<
            
            // 固定列区切り線設定
            // ---------------------- ADD START 2011/07/18 朱宝軍 ----------------->>>>>
            // 自動回答
            if (this._opt_Pcc == (int)Option.ON)
            {
                Columns[this._dataSet.SalesDetail.AutoAnswerDivSCMColumn.ColumnName].Hidden = false;
                Columns[this._dataSet.SalesDetail.AutoAnswerDivSCMColumn.ColumnName].Header.Caption = "自動回答";
                Columns[this._dataSet.SalesDetail.AutoAnswerDivSCMColumn.ColumnName].Width = 100;
                Columns[this._dataSet.SalesDetail.AutoAnswerDivSCMColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                Columns[this._dataSet.SalesDetail.AutoAnswerDivSCMColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;
            }
            else
            {
                Columns[this._dataSet.SalesDetail.AutoAnswerDivSCMColumn.ColumnName].Hidden = true;
                Columns[this._dataSet.SalesDetail.AutoAnswerDivSCMColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;
            }
            // ---------------------- ADD END   2011/07/18 朱宝軍 -----------------<<<<<
            this.uGrid_ViewDetails.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_ViewDetails.DisplayLayout.Override.HeaderAppearance.BackColor2;
        }

        /// <summary>
        /// グリッド行初期設定処理
        /// </summary>
        private void GridRowInitialSetting()
        {
            this._dataSet.SalesDetail.Rows.Clear();
        }

        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager_ViewDetail.ImageListSmall = this._imageList16;
            this._returnButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            this._decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
        }


        # region コントロールイベントメソッド

        /// <summary>
        /// グリッドエンターイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_Enter(object sender, EventArgs e)
        {
            if (this.uGrid_ViewDetails.Rows.Count != 0)
            {
                //this.uButton_StockSearch.Enabled = true;
            }

            timer_InitialSetSelect.Enabled = true;
        }

        /// <summary>
        /// グリッドフォーカス離脱時イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// グリッドキーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_ViewDetails.ActiveRow == null) return;

            // Enterキー
            if (e.KeyCode == Keys.Enter)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;
            }

            // 最上行での↑キー
            if (this.uGrid_ViewDetails.ActiveRow.Index == 0)
            {
                if (e.KeyCode == Keys.Up)
                {
                    // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                    e.Handled = true;
                    //this.uButton_StockSearch.Focus();
                }
            }

            // →矢印キー
            if (e.KeyCode == Keys.Right)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;
                // グリッド表示を右にスクロール
                this.uGrid_ViewDetails.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_ViewDetails.DisplayLayout.ColScrollRegions[0].Position + 40;
            }

            // ←矢印キー
            if (e.KeyCode == Keys.Left)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;
                if (this.uGrid_ViewDetails.DisplayLayout.ColScrollRegions[0].Position == 0)
                {
                    //this.uButton_StockSearch.Focus();
                }
                else
                {
                    // グリッド表示を左にスクロール
                    this.uGrid_ViewDetails.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_ViewDetails.DisplayLayout.ColScrollRegions[0].Position - 40;
                }
            }

            // Homeキー
            if (e.KeyCode == Keys.Home)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;

                // 他キーとの組合せ無しの場合
                if (e.Modifiers == Keys.None)
                {
                    // グリッド表示を左先頭にスクロール
                    this.uGrid_ViewDetails.DisplayLayout.ColScrollRegions[0].Position = 0;
                }

                // Controlキーとの組合せの場合
                if (e.Modifiers == Keys.Control)
                {
                    // グリッド表示を左先頭にスクロール
                    //this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = 0;
                    // 先頭行に移動
                    this.uGrid_ViewDetails.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);
                }
            }

            // Endキー
            if (e.KeyCode == Keys.End)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;

                // 他キーとの組合せ無しの場合
                if (e.Modifiers == Keys.None)
                {
                    // グリッド表示を左先頭にスクロール
                    this.uGrid_ViewDetails.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_ViewDetails.DisplayLayout.ColScrollRegions[0].Range;
                }

                // Controlキーとの組合せの場合
                if (e.Modifiers == Keys.Control)
                {
                    // グリッド表示を右末尾にスクロール
                    //this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Range;
                    // 最終行に移動
                    this.uGrid_ViewDetails.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastRowInGrid);
                }
            }
        }

        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            //if (e.PrevCtrl == this.uButton_StockSearch)
            //{
            //    switch (e.Key)
            //    {
            //        case Keys.Up:
            //            {
            //                Control nextControl = this.InitFocusSetting(this);
            //                e.NextCtrl = nextControl;

            //                break;
            //            }
            //        case Keys.Left:
            //            {
            //                break;
            //            }
            //        case Keys.Right:
            //            {
            //                e.NextCtrl = this.uGrid_ViewDetails;
            //                break;
            //            }
            //    }
            //}
        }

        # endregion

        /// <summary>
        /// ツールバーボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tToolbarsManager_ViewDetail_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Return":
                    {
                        // 終了処理
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                        break;
                    }
                case "ButtonTool_Decision":
                    {
                        // 確定処理
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                        break;
                    }
            }
        }

        /// <summary>
        /// グリッド行選択設定タイマー起動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void timer_InitialSetSelect_Tick(object sender, EventArgs e)
        {
            if (this.uGrid_ViewDetails.ActiveRow != null)
            {
                this.uGrid_ViewDetails.ActiveRow.Selected = true;
            }
            timer_InitialSetSelect.Enabled = false;
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
        /// <summary>
        /// 確定ボタンEnabled設定
        /// </summary>
        /// <param name="enabled"></param>
        public void SetDecisionButtonEnabled( bool enabled )
        {
            _decisionButton.SharedProps.Enabled = enabled;
            _decisionButton.SharedProps.Visible = enabled;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD

        // ADD 2009/12/03 MANTIS対応[14742]：明細グリッド列の列設定の変更 ---------->>>>>
        /// <summary>
        /// 明細情報グリッドを取得します。
        /// </summary>
        public Infragistics.Win.UltraWinGrid.UltraGrid DetailGrid
        {
            get { return this.uGrid_ViewDetails; }
        }
        // ADD 2009/12/03 MANTIS対応[14742]：明細グリッド列の列設定の変更 ----------<<<<<
    }
}
