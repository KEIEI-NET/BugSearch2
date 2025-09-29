//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 簡単問合せCTI表示 明細表示フォームクラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 10601193-00  作成担当 : 21024　佐々木 健
// 作 成 日  2010/04/06  修正内容 : IAAE版から製品版へ変更(不要ロジック削除)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
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
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 簡単問合せCTI表示 明細表示フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 新規作成(IAAEから変更)</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/04/06</br>
    /// <br></br>
    /// </remarks>
    public partial class PMSCM00101UB : Form
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ■ Private Member

        private SimpleInqCTIAcs _salesSlipSearchAcs;

        private SimpleInqCTIDataSet _dataSet;
        private SalesSlipSearchResult _salesSlipSearchResult;
        SortedList _supplierFormalStr = new SortedList();                       // 売上形式
        SortedList _supplierFormalTitleStr = new SortedList();                  // 日付タイトル
        SortedList _supplierSlipCdStr = new SortedList();                       // 伝票形式

        // 自社設定アクセスクラス
        private CompanyInfAcs _companyAcs;

        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region ■ Constructor

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="salesSlipSearchAcs"></param>
        /// <param name="salesSlipSearchResult"></param>
        public PMSCM00101UB(SimpleInqCTIAcs salesSlipSearchAcs, SalesSlipSearchResult salesSlipSearchResult)
        {
            _salesSlipSearchAcs = salesSlipSearchAcs;

            InitializeComponent();

            if (salesSlipSearchResult != null)
            {
                this._salesSlipSearchResult = salesSlipSearchResult;
            }

            this._dataSet = this._salesSlipSearchAcs.DataSet;
            this.uGrid_ViewDetails.DataSource = this._dataSet.SalesDetail;

            this.SetInitialDataValue();
        }

        #endregion  // Constructor


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


            this.uLabel_SupplierSlipNo.Text = _salesSlipSearchResult.SalesSlipNum.Trim();             // 伝票番号

            // 売上形式
            if ((_salesSlipSearchResult.EstimateDivide == 2) && (_salesSlipSearchResult.AcptAnOdrStatus == 10))
            {
                this.uLabel_SupplierFormal.Text = "単価見積";
            }
            else
            {
                this.uLabel_SupplierFormal.Text = _supplierFormalStr[_salesSlipSearchResult.AcptAnOdrStatus].ToString();
            }

            // 検索見積時は伝票区分は空白
            if (_salesSlipSearchResult.EstimateDivide != 3)
            {
                this.uLabel_SupplierSlipCd.Text = SalesFormalName(_salesSlipSearchResult.SalesSlipCd, _salesSlipSearchResult.AccRecDivCd);
            }
            else
            {
                this.uLabel_SupplierSlipCd.Text = string.Empty;
            }

            this.uLabel_StockAgentCode.Text = _salesSlipSearchResult.SalesEmployeeCd;
            this.uLabel_StockAgentName.Text = _salesSlipSearchResult.SalesEmployeeNm;

            this.uLabel_CustomerCode.Text = _salesSlipSearchResult.CustomerCode.ToString( GetCustomerCodeFormat() );
            this.uLabel_CustomerName.Text = _salesSlipSearchResult.CustomerName;

            // 拠点コード
            this.uLabel_SectionCode.Text = _salesSlipSearchResult.SectionCode;
            // 拠点名
            this.uLabel_SectionName.Text = _salesSlipSearchResult.SectionGuideNm;
            // 部門コード
            this.uLabel_SubSectionCode.Text = _salesSlipSearchResult.SubSectionCode.ToString("00");
            // 部門コードが0の場合、空
            if (this.uLabel_SubSectionCode.Text.Equals("00")) this.uLabel_SubSectionCode.Text = string.Empty;
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

        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        private void GridColInitialSetting(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns)
        {
            string acptAnOdrStatusTiTle = "";
            string _moneyFormat = "#,##0;-#,##0;''";
            string _doubleFormat = "#,##0.00;-#,##0.00;''";

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
            #region 各項目の設定
            int visiblePositionNo = 1;

            //売上行番号
            Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Header.Fixed = true;			// 固定項目
            Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Header.Caption = "行番号";
            Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // 先頭から1ずつ増やすように
            Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;


            //品番(商品番号から変更)
            Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Header.Caption = "品番";
            Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Width = 200;
            Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;

            //品名(商品名から変更)
            Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Header.Caption = "品名";
            Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Width = 200;
            Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;

            //メーカー名
            Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Header.Caption = "メーカー名";
            Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;

            // BLコード
            Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Header.Caption = "BLコード";
            Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;
            Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Format = GetBLGoodsCodeFormat();

            // 標準価格
            Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Header.Caption = "標準価格";
            Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;
            Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Format = _moneyFormat;

            //受注数
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

            // UNDONE:売上単価
            // 単価を消費税込み(SalesUnPrcTaxIncFlColumn)から消費税抜きに変更
            Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Header.Caption = acptAnOdrStatusTiTle + "単価";
            Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Format = _doubleFormat;  // MOD 2008/11/05 不具合対応[7076] 売上単価は小数点付 _moneyFormat→_doubleFormat
            Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;

            //売上金額（税抜）
            Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Header.Caption = acptAnOdrStatusTiTle + "金額";
            Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;
            Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Format = _moneyFormat;

            //消費税
            Columns[this._dataSet.SalesDetail.SalsePriceConsTaxColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SalsePriceConsTaxColumn.ColumnName].Header.Caption = "消費税";
            Columns[this._dataSet.SalesDetail.SalsePriceConsTaxColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.SalsePriceConsTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesDetail.SalsePriceConsTaxColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;
            Columns[this._dataSet.SalesDetail.SalsePriceConsTaxColumn.ColumnName].Format = _moneyFormat;

            //原価単価
            Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Header.Caption = "原価単価";
            Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;
            Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Format = _doubleFormat;

            //原価金額
            Columns[this._dataSet.SalesDetail.SalesUnitTotalColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SalesUnitTotalColumn.ColumnName].Header.Caption = "原価金額";
            Columns[this._dataSet.SalesDetail.SalesUnitTotalColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.SalesUnitTotalColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesDetail.SalesUnitTotalColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;
            Columns[this._dataSet.SalesDetail.SalesUnitTotalColumn.ColumnName].Format = _doubleFormat;

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

            //明細備考
            Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Header.Caption = "明細備考";
            Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Width = 200;
            Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Header.VisiblePosition = visiblePositionNo++;

            //客先納期
            if (_salesSlipSearchResult.AcptAnOdrStatus == 20)
            {
                Columns[this._dataSet.SalesDetail.DeliGdsCmpltDueDateStringColumn.ColumnName].Hidden = false;
                Columns[this._dataSet.SalesDetail.DeliGdsCmpltDueDateStringColumn.ColumnName].Header.Caption = "納品完了予定日";
                Columns[this._dataSet.SalesDetail.DeliGdsCmpltDueDateStringColumn.ColumnName].Width = 100;
                Columns[this._dataSet.SalesDetail.DeliGdsCmpltDueDateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                Columns[this._dataSet.SalesDetail.DeliGdsCmpltDueDateStringColumn.ColumnName].Header.VisiblePosition = 24;
            }
            #endregion // 各項目の設定

            // 固定列区切り線設定

            this.uGrid_ViewDetails.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_ViewDetails.DisplayLayout.Override.HeaderAppearance.BackColor2;
        }

        /// <summary>
        /// グリッド行初期設定処理
        /// </summary>
        private void GridRowInitialSetting()
        {
            this._dataSet.SalesDetail.Rows.Clear();
        }

        // ===================================================================================== //
        // コントロールイベント
        // ===================================================================================== //
        # region ■ Control Event

        /// <summary>
        ///  画面ロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAHNB04110UC_Load(object sender, EventArgs e)
        {
            // グリッド列初期設定処理
            this.GridColInitialSetting(this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns);

            // グリッド行初期設定処理
            this.GridRowInitialSetting();

            // ヘッダ部情報設定処理
            this.SetHeaderInfo();

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

            // 対象伝票の明細情報を取得
            SalesSlipDetailSearch salesSlipDetailSearch = new SalesSlipDetailSearch();
            salesSlipDetailSearch.EnterpriseCode = _salesSlipSearchResult.EnterpriseCode;
            salesSlipDetailSearch.AcptAnOdrStatus = _salesSlipSearchResult.AcptAnOdrStatus;
            salesSlipDetailSearch.SalesSlipNum = _salesSlipSearchResult.SalesSlipNum;
            this._salesSlipSearchAcs.SearchDetail(salesSlipDetailSearch, _salesSlipSearchResult);

            DataView dv = new DataView(this._dataSet.SalesDetail);
            dv.Sort = "SalesRowNo Asc";
            this.uGrid_ViewDetails.DataSource = dv;
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
        /// 閉じるボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        # endregion

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

        /// <summary>
        /// 明細情報グリッドを取得します。
        /// </summary>
        public Infragistics.Win.UltraWinGrid.UltraGrid DetailGrid
        {
            get { return this.uGrid_ViewDetails; }
        }
    }
}
