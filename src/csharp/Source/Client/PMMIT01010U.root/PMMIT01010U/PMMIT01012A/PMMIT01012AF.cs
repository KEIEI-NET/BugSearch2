using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using System.Collections; // ADD 2013/03/13 宋剛 Redmine#35020 No.1834

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 検索見積 UOE発注選択アクセスクラス
    /// </summary>
    /// <br>Note       : 検索見積のUOE発注用のアクセスクラスです。</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2008.10.17</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.10.17 men 新規作成</br>
    /// <br>Update     : 2011/02/14 dingjx</br>
    /// <br>Note       : 発注選択時の数量チェック処理追加</br>
    /// <br>Update Note: 2013/02/27 譚洪</br>
    /// <br>管理番号   : 10801804-00、2013/03/13配信分</br>
    /// <br>             Redmine#34434 No.1180 現在庫数が０のとき在庫数が空白で表示されるの対応</br>
    /// <br>Update Note: 2013/03/07 gaofeng</br>
    /// <br>管理番号   : 10801804-00、2013/03/13配信分</br>
    /// <br>             Redmine#34994 優良発注先の場合にＢＯ区分を入力すると、発注数がデフォルト表示しなく、０で表示されるの対応</br>
    /// <br>Update Note: 2013/03/08 譚洪</br>
    /// <br>管理番号   : 10801804-00、2013/03/13配信分</br>
    /// <br>             Redmine#34994 優良発注先の場合にＢＯ区分を入力すると、発注数がデフォルト表示しなく、０で表示されるの対応</br>
    /// <br>Update Note: 2013/03/10 譚洪</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>           : redmine#34994、検索見積発行　現在庫数が０のとき在庫数が０で表示の対応</br>
    /// <br>Update Note: 2013/03/13 宋剛</br>
    /// <br>管理番号   : 10900691-00、2013/05/15配信分</br>
    /// <br>             Redmine#35020 管理№1834 「検索見積」の「発注検索画面」のレスポンス低下のトリガーの排除</br>
    /// <br>Update Note: 2013/04/15 donggy</br>
    /// <br>管理番号   : 10900691-00 2013/05/15配信分</br>
    /// <br>               Redmine#35020　検索見積」の「発注検索画面」のレスポンス低下のトリガーの排除</br>
    /// <remarks></remarks>
    public class EstimateInputOrderSelectAcs
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region ■Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EstimateInputOrderSelectAcs()
        {
            //this._primeInfoDataTable = primeInfoDataTable;
            //this._estimateDetailDataTable = estimateDetailDataTable;
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._estimateInputInitDataAcs = EstimateInputInitDataAcs.GetInstance();
            this._uOESupplierAcs = new UOESupplierAcs();
        }
        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ■ Private Members

        // ADD 2013/03/13 宋剛 Redmine#35020 No.1834 ---->>>>>>>>
        // 全てUOE発注先情報Dictionary
        private Dictionary<int, UOESupplier> _allSupplierDic;
        // ADD 2013/03/13 宋剛 Redmine#35020 No.1834 ----<<<<<<<<

        private string _enterpriseCode;
        private DataTable _headerTable;
        private DataTable _detailTable;
        private DataView _headerView;
        private DataView _detailView;

        private EstimateInputInitDataAcs _estimateInputInitDataAcs;

        private UOESupplierAcs _uOESupplierAcs;

        #endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        #region ■Properties

        /// <summary>ヘッダ情報データビュー</summary>
        public DataView HeaderView
        {
            get { return _headerView; }
            set { _headerView = value; }
        }

        /// <summary>明細情報データビュー</summary>
        public DataView DetailView
        {
            get { return _detailView; }
            set { _detailView = value; }
        }

        /// <summary>明細情報データビュー</summary>
        public DataTable DetailTable
        {
            get { return _detailTable; }
            set { _detailTable = value; }
        }

        #endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        #region ■Public Methods

        /// <summary>
        /// 発注選択したデータを取得します。
        /// </summary>
        /// <param name="uoeOrderDataTable">ＵＯＥ発注データテーブル</param>
        /// <param name="uoeOrderDetailDataTable">ＵＯＥ発注明細データテーブル</param>
        public void GetOrderSelectData(out EstimateInputDataSet.UOEOrderDataTable uoeOrderDataTable, out EstimateInputDataSet.UOEOrderDetailDataTable uoeOrderDetailDataTable)
        {
            uoeOrderDataTable = new EstimateInputDataSet.UOEOrderDataTable();
            uoeOrderDetailDataTable = new EstimateInputDataSet.UOEOrderDetailDataTable();

            // 発注選択されている情報を抽出する
            DataRow[] hdRows = this._headerTable.Select(string.Format("{0}='{1}'", EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_ExistOrder, true),EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd);

            foreach (DataRow hdRow in hdRows)
            {
                Guid orderGuid = Guid.NewGuid();

                // 対象発注先で発注数が入力されているデータを抽出する
                DataRow[] dtlRows = this._detailTable.Select(string.Format("{0}<>{1} AND {2}={3}", EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt, 0, EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_SupplierCd, (int)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd]));
                if (( dtlRows != null ) && ( dtlRows.Length > 0 ))
                {
                    // データが存在する場合はヘッダ行を生成
                    EstimateInputDataSet.UOEOrderRow uoeOrderRow = uoeOrderDataTable.NewUOEOrderRow();
                    uoeOrderRow.OrderGuid = orderGuid;
                    uoeOrderRow.UOESupplierCd = (int)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOESupplierCd];
                    uoeOrderRow.UOESupplierName = (string)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOESupplierName];
                    uoeOrderRow.UOEDeliGoodsDiv = (string)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOEDeliGoodsDiv];
                    uoeOrderRow.DeliveredGoodsDivNm = (string)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_DeliveredGoodsDivNm];
                    uoeOrderRow.FollowDeliGoodsDiv = (string)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_FollowDeliGoodsDiv];
                    uoeOrderRow.FollowDeliGoodsDivNm = (string)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_FollowDeliGoodsDivNm];
                    uoeOrderRow.UOEResvdSection = (string)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOEResvdSection];
                    uoeOrderRow.UOEResvdSectionNm = (string)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOEResvdSectionNm];
                    uoeOrderRow.UoeRemark1 = (string)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UoeRemark1];
                    uoeOrderRow.UoeRemark2 = (string)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UoeRemark2];
                    uoeOrderRow.CommAssemblyId = ( (UOESupplier)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOESupplier] ).CommAssemblyId;
                    uoeOrderRow.SupplierCd = ( (UOESupplier)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOESupplier] ).SupplierCd;
                    uoeOrderDataTable.AddUOEOrderRow(uoeOrderRow);

                    foreach (DataRow dtlRow in dtlRows)
                    {
                        EstimateInputDataSet.UOEOrderDetailRow uoeOrderDetailRow = uoeOrderDetailDataTable.NewUOEOrderDetailRow();
                        uoeOrderDetailRow.DtlRelationGuid = (Guid)dtlRow[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_DtlRelationGuid];
                        uoeOrderDetailRow.BoCode = (string)dtlRow[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode];
                        uoeOrderDetailRow.OrderCnt = (int)dtlRow[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt];
                        uoeOrderDetailRow.OrderGuid = orderGuid;

                        uoeOrderDetailDataTable.AddUOEOrderDetailRow(uoeOrderDetailRow);

                    }
                }
            }
        }

        /// <summary>
        /// 発注選択用のデータテーブルを生成します。
        /// </summary>
        /// <param name="estimateDetailDataTable"></param>
        /// <param name="primeInfoDataTable"></param>
        /// <param name="uoeOrderDataTable"></param>
        /// <param name="uoeOrderDetailDataTable"></param>
        /// <br>Update Note: 2013/03/08 譚洪</br>
        /// <br>管理番号   : 10801804-00、2013/03/13配信分</br>
        /// <br>             Redmine#34994 優良発注先の場合にＢＯ区分を入力すると、発注数がデフォルト表示しなく、０で表示されるの対応</br>
        /// <br>Update Note: 2013/04/15 donggy</br>
        /// <br>管理番号   : 10900691-00 2013/05/15配信分</br>
        /// <br>             Redmine#35020　検索見積」の「発注検索画面」のレスポンス低下のトリガーの排除</br>
        /// <remarks></remarks>
        public void CreateOrderSelectDataTable(EstimateInputDataSet.EstimateDetailDataTable estimateDetailDataTable, EstimateInputDataSet.PrimeInfoDataTable primeInfoDataTable, EstimateInputDataSet.UOEOrderDataTable uoeOrderDataTable, EstimateInputDataSet.UOEOrderDetailDataTable uoeOrderDetailDataTable)
        {
            List<int> supplierList = new List<int>();

            OrderSelectHdTable.CreateTable(ref this._headerTable);
            OrderSelectDtlTable.CreateTable(ref this._detailTable);

            DataView estmView = new DataView(estimateDetailDataTable);
            DataView primeView = new DataView(primeInfoDataTable);

            #region 純正部品の発注テーブル生成（見積明細テーブルより）

            estmView.RowFilter = string.Format("{0}<>{1} AND {2}<>'{3}' AND {4}<>{5}",
                estimateDetailDataTable.SupplierCdColumn.ColumnName, 0,
                estimateDetailDataTable.GoodsNoColumn.ColumnName, string.Empty,
                estimateDetailDataTable.GoodsMakerCdColumn.ColumnName, 0);

            foreach (DataRowView drv in estmView)
            {
                if (!supplierList.Contains((int)drv[estimateDetailDataTable.SupplierCdColumn.ColumnName]))
                {
                    DataRow hdRow = _headerTable.NewRow();
                    hdRow[OrderSelectHdTable.ctColName_SupplierCd] = (int)drv[estimateDetailDataTable.SupplierCdColumn.ColumnName];
                    hdRow[OrderSelectHdTable.ctColName_SupplierSnm] = (string)drv[estimateDetailDataTable.SupplierSnmColumn.ColumnName];

                    _headerTable.Rows.Add(hdRow);
                    supplierList.Add((int)drv[estimateDetailDataTable.SupplierCdColumn.ColumnName]);
                }

                DataRow dtlRow = _detailTable.NewRow();
                dtlRow[OrderSelectDtlTable.ctColName_DtlRelationGuid] = (Guid)drv[estimateDetailDataTable.DtlRelationGuidColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_SupplierCd] = (int)drv[estimateDetailDataTable.SupplierCdColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_GoodsName] = (string)drv[estimateDetailDataTable.GoodsNameColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_GoodsNo] = (string)drv[estimateDetailDataTable.GoodsNoColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_GoodsMakerCd] = (int)drv[estimateDetailDataTable.GoodsMakerCdColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_WarehouseCode] = (string)drv[estimateDetailDataTable.WarehouseCodeColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_ShipmentCnt] = (double)drv[estimateDetailDataTable.ShipmentCntColumn.ColumnName];
                //dtlRow[OrderSelectDtlTable.ctColName_ShipmentPosCnt] = (double)drv[estimateDetailDataTable.ShipmentPosCntColumn.ColumnName]; // DEL 2013/03/08 tanh Redmine#34994

                // ADD 2013/03/08 tanh Redmine#34994 ---- >>>>>
                if (string.IsNullOrEmpty(dtlRow[OrderSelectDtlTable.ctColName_WarehouseCode].ToString()))
                {
                    dtlRow[OrderSelectDtlTable.ctColName_ShipmentPosCnt] = string.Empty;
                }
                else
                {
                    //dtlRow[OrderSelectDtlTable.ctColName_ShipmentPosCnt] = ((double)drv[estimateDetailDataTable.ShipmentPosCntColumn.ColumnName]).ToString("N");// DEL 譚洪 Redmine#34994 2013/03/10
                    dtlRow[OrderSelectDtlTable.ctColName_ShipmentPosCnt] = double.Parse(drv[estimateDetailDataTable.ShipmentPosCntColumn.ColumnName].ToString()).ToString("N");// ADD 譚洪 Redmine#34994 2013/03/10
                }
                // ADD 2013/03/08 tanh Redmine#34994 ---- <<<<<

                if ((Guid)drv[estimateDetailDataTable.UOEOrderGuidColumn.ColumnName] == Guid.Empty)
                {
                    dtlRow[OrderSelectDtlTable.ctColName_BOCode] = "*";
                }
                else
                {

                }
                _detailTable.Rows.Add(dtlRow);
            }
            #endregion

            #region 優良部品の発注テーブル生成（見積明細テーブルより）

            // 優良連結GUIDが入っているデータは除外（優良データテーブルより抽出する為）して抽出
            estmView.RowFilter = string.Format("{0}<>{1} AND {2}<>'{3}' AND {4}<>{5} AND {6}='{7}'",
                estimateDetailDataTable.SupplierCd_PrimeColumn.ColumnName, 0,
                estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName, string.Empty,
                estimateDetailDataTable.GoodsMakerCd_PrimeColumn.ColumnName, 0,
                estimateDetailDataTable.PrimeInfoRelationGuidColumn.ColumnName, Guid.Empty);

            foreach (DataRowView drv in estmView)
            {
                if (!supplierList.Contains((int)drv[estimateDetailDataTable.SupplierCd_PrimeColumn.ColumnName]))
                {
                    DataRow hdRow = _headerTable.NewRow();
                    hdRow[OrderSelectHdTable.ctColName_SupplierCd] = (int)drv[estimateDetailDataTable.SupplierCd_PrimeColumn.ColumnName];
                    hdRow[OrderSelectHdTable.ctColName_SupplierSnm] = (string)drv[estimateDetailDataTable.SupplierSnm_PrimeColumn.ColumnName];

                    _headerTable.Rows.Add(hdRow);
                    supplierList.Add((int)drv[estimateDetailDataTable.SupplierCd_PrimeColumn.ColumnName]);
                }

                DataRow dtlRow = _detailTable.NewRow();
                dtlRow[OrderSelectDtlTable.ctColName_DtlRelationGuid] = (Guid)drv[estimateDetailDataTable.DtlRelationGuid_PrimeColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_SupplierCd] = (int)drv[estimateDetailDataTable.SupplierCd_PrimeColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_GoodsName] = (string)drv[estimateDetailDataTable.GoodsName_PrimeColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_GoodsNo] = (string)drv[estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_GoodsMakerCd] = (int)drv[estimateDetailDataTable.GoodsMakerCd_PrimeColumn.ColumnName];
                //dtlRow[OrderSelectDtlTable.ctColName_WarehouseCode] = (string)drv[estimateDetailDataTable.WarehouseName_PrimeColumn.ColumnName];// DEL 2013/03/10 譚洪 Redmine#34994
                dtlRow[OrderSelectDtlTable.ctColName_WarehouseCode] = (string)drv[estimateDetailDataTable.WarehouseCode_PrimeColumn.ColumnName];// ADD 2013/03/10 譚洪 Redmine#34994
                dtlRow[OrderSelectDtlTable.ctColName_ShipmentCnt] = (double)drv[estimateDetailDataTable.ShipmentCnt_PrimeColumn.ColumnName];
                //dtlRow[OrderSelectDtlTable.ctColName_ShipmentPosCnt] = (double)drv[estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName]; // DEL 2013/03/08 tanh Redmine#34994
                // ADD 2013/03/08 tanh Redmine#34994 ---- >>>>>
                if (string.IsNullOrEmpty(dtlRow[OrderSelectDtlTable.ctColName_WarehouseCode].ToString()))
                {
                    dtlRow[OrderSelectDtlTable.ctColName_ShipmentPosCnt] = string.Empty;
                }
                else
                {
                    //dtlRow[OrderSelectDtlTable.ctColName_ShipmentPosCnt] = ((double)drv[estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName]).ToString("N");// DEL 譚洪 Redmine#34994 2013/03/10
                    dtlRow[OrderSelectDtlTable.ctColName_ShipmentPosCnt] = double.Parse(drv[estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName].ToString()).ToString("N");// ADD 譚洪 Redmine#34994 2013/03/10
                }
                // ADD 2013/03/08 tanh Redmine#34994 ---- <<<<<
                if ((Guid)drv[estimateDetailDataTable.UOEOrderGuid_PrimeColumn.ColumnName] == Guid.Empty)
                {
                    dtlRow[OrderSelectDtlTable.ctColName_BOCode] = "*";
                }
                else
                {

                }

                _detailTable.Rows.Add(dtlRow);
            }

            #endregion

            #region 優良部品の発注テーブル生成（優良部品テーブルより）

            primeView.RowFilter = string.Format("{0}<>{1} AND {2}<>'{3}' AND {4}<>{5}",
                primeInfoDataTable.SupplierCdColumn.ColumnName, 0,
                primeInfoDataTable.GoodsNoColumn.ColumnName, string.Empty,
                primeInfoDataTable.GoodsMakerCdColumn.ColumnName, 0);

            foreach (DataRowView drv in primeView)
            {
                if (!supplierList.Contains((int)drv[primeInfoDataTable.SupplierCdColumn.ColumnName]))
                {
                    DataRow hdRow = _headerTable.NewRow();
                    hdRow[OrderSelectHdTable.ctColName_SupplierCd] = (int)drv[primeInfoDataTable.SupplierCdColumn.ColumnName];
                    hdRow[OrderSelectHdTable.ctColName_SupplierSnm] = (string)drv[primeInfoDataTable.SupplierSnmColumn.ColumnName];

                    _headerTable.Rows.Add(hdRow);
                    supplierList.Add((int)drv[primeInfoDataTable.SupplierCdColumn.ColumnName]);
                }

                DataRow dtlRow = _detailTable.NewRow();
                dtlRow[OrderSelectDtlTable.ctColName_DtlRelationGuid] = (Guid)drv[primeInfoDataTable.DtlRelationGuidColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_SupplierCd] = (int)drv[primeInfoDataTable.SupplierCdColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_GoodsName] = (string)drv[primeInfoDataTable.GoodsNameColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_GoodsNo] = (string)drv[primeInfoDataTable.GoodsNoColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_GoodsMakerCd] = (int)drv[primeInfoDataTable.GoodsMakerCdColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_WarehouseCode] = (string)drv[primeInfoDataTable.WarehouseCodeColumn.ColumnName];
                dtlRow[OrderSelectDtlTable.ctColName_ShipmentCnt] = (double)drv[primeInfoDataTable.ShipmentCntColumn.ColumnName];
                //dtlRow[OrderSelectDtlTable.ctColName_ShipmentPosCnt] = (double)drv[primeInfoDataTable.ShipmentPosCntColumn.ColumnName]; // DEL 2013/02/27 tanh Redmine#34434 No.1180

                // DEL 2013/03/08 tanh Redmine#34994 ---- >>>>>
                // ADD 2013/02/27 tanh Redmine#34434 No.1180 ---- >>>>>>>>>>>>
                //if (string.IsNullOrEmpty(drv[primeInfoDataTable.ShipmentPosCntColumn.ColumnName].ToString()))
                //{
                //    //dtlRow[OrderSelectDtlTable.ctColName_ShipmentCnt] = 0; // DEL 2013/03/07 gaofeng Redmine#34994
                //    dtlRow[OrderSelectDtlTable.ctColName_ShipmentPosCnt] = 0;　// ADD 2013/03/07 gaofeng Redmine#34994
                //}
                //else
                //{
                //    dtlRow[OrderSelectDtlTable.ctColName_ShipmentPosCnt] = double.Parse(drv[primeInfoDataTable.ShipmentPosCntColumn.ColumnName].ToString());

                //}
                // ADD 2013/02/27 tanh Redmine#34434 No.1180 ---- <<<<<<<<<<<<
                // DEL 2013/03/08 tanh Redmine#34994 ---- <<<<<

                // ADD 2013/03/08 tanh Redmine#34994 ---- >>>>>
                if (string.IsNullOrEmpty(drv[primeInfoDataTable.ShipmentPosCntColumn.ColumnName].ToString()))
                {
                    dtlRow[OrderSelectDtlTable.ctColName_ShipmentPosCnt] = string.Empty;
                }
                else
                {
                    dtlRow[OrderSelectDtlTable.ctColName_ShipmentPosCnt] = (double.Parse(drv[primeInfoDataTable.ShipmentPosCntColumn.ColumnName].ToString())).ToString("N"); 
                }
                // ADD 2013/03/08 tanh Redmine#34994 ---- <<<<<

                if ((Guid)drv[primeInfoDataTable.UOEOrderGuidColumn.ColumnName] == Guid.Empty)
                {
                    dtlRow[OrderSelectDtlTable.ctColName_BOCode] = "*";
                }
                else
                {
                }
                _detailTable.Rows.Add(dtlRow);
            }

            #endregion

            #region 発注選択済み情報の反映

            List<Guid> orderGuidList = new List<Guid>();
            foreach (EstimateInputDataSet.UOEOrderDetailRow uoeOrderDetailRow in uoeOrderDetailDataTable.Rows)
            {
                DataRow row = _detailTable.Rows.Find(uoeOrderDetailRow.DtlRelationGuid);

                if (row != null)
                {
                    if (!orderGuidList.Contains(uoeOrderDetailRow.OrderGuid))
                    {
                        DataRow hdRow = _headerTable.Rows.Find((int)row[OrderSelectDtlTable.ctColName_SupplierCd]);
                        EstimateInputDataSet.UOEOrderRow uoeOrderRow = uoeOrderDataTable.FindByOrderGuid(uoeOrderDetailRow.OrderGuid);

                        if (( hdRow != null ) && ( uoeOrderRow != null ))
                        {
                            hdRow[OrderSelectHdTable.ctColName_ExistOrder] = true;
                            hdRow[OrderSelectHdTable.ctColName_OrderGuid] = uoeOrderRow.OrderGuid;
                            hdRow[OrderSelectHdTable.ctColName_UOESupplierCd] = uoeOrderRow.UOESupplierCd;
                            hdRow[OrderSelectHdTable.ctColName_UOESupplierName] = uoeOrderRow.UOESupplierName;
                            hdRow[OrderSelectHdTable.ctColName_UoeRemark1] = uoeOrderRow.UoeRemark1;
                            hdRow[OrderSelectHdTable.ctColName_UoeRemark2] = uoeOrderRow.UoeRemark2;
                            hdRow[OrderSelectHdTable.ctColName_UOEDeliGoodsDiv] = uoeOrderRow.UOEDeliGoodsDiv;
                            hdRow[OrderSelectHdTable.ctColName_DeliveredGoodsDivNm] = uoeOrderRow.DeliveredGoodsDivNm;
                            hdRow[OrderSelectHdTable.ctColName_FollowDeliGoodsDiv] = uoeOrderRow.FollowDeliGoodsDiv;
                            hdRow[OrderSelectHdTable.ctColName_FollowDeliGoodsDivNm] = uoeOrderRow.FollowDeliGoodsDivNm;
                            hdRow[OrderSelectHdTable.ctColName_UOEResvdSection] = uoeOrderRow.UOEResvdSection;
                            hdRow[OrderSelectHdTable.ctColName_UOEResvdSectionNm] = uoeOrderRow.UOEResvdSectionNm;
                        }
                        orderGuidList.Add(uoeOrderDetailRow.OrderGuid);
                    }
                    row[OrderSelectDtlTable.ctColName_BOCode] = uoeOrderDetailRow.BoCode;
                    row[OrderSelectDtlTable.ctColName_OrderCnt] = uoeOrderDetailRow.OrderCnt;
                }
            }
            
            #endregion

            #region 発注先情報の設定
            // --- DEL donggy 2013/04/15 for Redmine#35020 --->>>>>>>
            //// ADD 2013/03/13 宋剛 Redmine#35020 No.1834 ---->>>>>>>>
            //// 全てUOE発注先情報検索処理
            //FindAllSupplierInfo();
            //// ADD 2013/03/13 宋剛 Redmine#35020 No.1834 ----<<<<<<<<

            //foreach (DataRow row in _headerTable.Rows)
            //{
            //    bool defaultSetting = ( (Guid)row[OrderSelectHdTable.ctColName_OrderGuid] == Guid.Empty );

            //    int targetCode = ( defaultSetting ) ? (int)row[OrderSelectHdTable.ctColName_SupplierCd] : (int)row[OrderSelectHdTable.ctColName_UOESupplierCd];

            //this.UOESupplierInfoReadAndSetting(row, targetCode, defaultSetting);
            //}
            // --- DEL donggy 2013/04/15 for Redmine#35020 ---<<<<<<<

            // --- ADD donggy 2013/04/15 for Redmine#35020 --->>>>>>>
            List<UOESupplier> uoeSupplierList = new List<UOESupplier>();
            // 指定発注先コード取得
            foreach (DataRow row in _headerTable.Rows)
            {
                bool defaultSetting = ( (Guid)row[OrderSelectHdTable.ctColName_OrderGuid] == Guid.Empty );

                int targetCode = ( defaultSetting ) ? (int)row[OrderSelectHdTable.ctColName_SupplierCd] : (int)row[OrderSelectHdTable.ctColName_UOESupplierCd];

                UOESupplier paraUoeSupplier = new UOESupplier();
                paraUoeSupplier.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                paraUoeSupplier.EnterpriseCode = this._enterpriseCode;
                paraUoeSupplier.UOESupplierCd = targetCode;

                uoeSupplierList.Add(paraUoeSupplier);

            }
            // UOE 発注先マスタ情報のリストを取得します。
            ArrayList retSupplierList = new ArrayList();
            this._uOESupplierAcs.SearchBySupplierCds(out retSupplierList, uoeSupplierList);
            // UOE発注先情報Dictionary作成
            // Dictionaryの説明
            //           KEY : UOESupplierCd
            //           VALUE : UOESupplier
            _allSupplierDic = new Dictionary<int, UOESupplier>();
            foreach (UOESupplier tempUOESupplier in retSupplierList)
            {
                if (!_allSupplierDic.ContainsKey(tempUOESupplier.UOESupplierCd))
                {
                    _allSupplierDic.Add(tempUOESupplier.UOESupplierCd, tempUOESupplier);
                }
            }
            // 発注先情報の設定
            foreach (DataRow row in _headerTable.Rows)
            {
                bool defaultSetting = ((Guid)row[OrderSelectHdTable.ctColName_OrderGuid] == Guid.Empty);

                int targetCode = (defaultSetting) ? (int)row[OrderSelectHdTable.ctColName_SupplierCd] : (int)row[OrderSelectHdTable.ctColName_UOESupplierCd];
                if (!_allSupplierDic.ContainsKey(targetCode))
                {
                    UOESupplier newUoeSupplier = new UOESupplier();
                    _allSupplierDic.Add(targetCode, newUoeSupplier);
                }
                // 発注先情報の初期値設定
                this.UOESupplierInfoSetting(row, _allSupplierDic[targetCode], true);
            }
            #endregion

            this._headerView = new DataView(this._headerTable);
            this._detailView = new DataView(this._detailTable);
        }

        /// <summary>
        /// 発注選択用のデータが存在するかチェックします。
        /// </summary>
        /// <returns></returns>
        public bool ExistData()
        {
            return ( this._headerTable.Rows.Count > 0 );
        }

        /// <summary>
        /// 仕入先変更時処理
        /// </summary>
        public void ChangeSupplier(int supplierCd)
        {
            this._detailView.RowFilter = string.Format("{0}={1}", EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_SupplierCd, supplierCd);

            int index = 1;
            foreach(DataRowView drv in this._detailView)
            {
                drv[OrderSelectDtlTable.ctColName_No] = index;
                index++;
            }
        }

        /// <summary>
        /// 明細情報変更時イベント
        /// </summary>
        /// <param name="supplierCd">仕入先</param>
        public void DetailDataChenged(int supplierCd)
        {
            DataRow[] dtlRows = this._detailTable.Select(string.Format("{0}={1} AND {2}<>{3}", OrderSelectDtlTable.ctColName_SupplierCd, supplierCd, OrderSelectDtlTable.ctColName_OrderCnt, 0));

            DataRow row = this._headerTable.Rows.Find(supplierCd);
            if (row != null)
            {
                row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_ExistOrder] = ( ( dtlRows != null ) && ( dtlRows.Length > 0 ) );
            }
            this._headerTable.AcceptChanges();
        }

        /// <summary>
        /// ヘッダ行取得処理
        /// </summary>
        /// <param name="supplierCd"></param>
        public DataRow GetOrderSelectHeaderRow(int supplierCd)
        {
            return this._headerTable.Rows.Find(supplierCd);
        }

        /// <summary>
        /// 発注先情報の初期値設定処理
        /// </summary>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="uoeSupplier">ＵＯＥ発注先マスタ</param>
        public void UOESupplierInfoDefaultSetting(int supplierCd, UOESupplier uoeSupplier)
        {
            DataRow row = this._headerTable.Rows.Find(supplierCd);

            this.UOESupplierInfoSetting(row, uoeSupplier, true);
        }

        /// <summary>
        /// 発注取消処理
        /// </summary>
        /// <param name="supplierCd">仕入先コード</param>
        public void OrderCancel(int supplierCd)
        {
            DataRow row = this._headerTable.Rows.Find(supplierCd);

            if (row != null)
            {
                this.DetailOrderCancel((int)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd]);
                //this._detailInput.AllOrderCancel((int)row[OrderSelectHdTable.ctColName_SupplierCd]);
            }

            row[OrderSelectHdTable.ctColName_ExistOrder] = false;
            this.UOESupplierInfoReadAndSetting(row, supplierCd, true);
        }

        /// <summary>
        /// 発注取消処理
        /// </summary>
        /// <param name="dtlRelationGuid"></param>
        public void OrderCancel(Guid dtlRelationGuid)
        {
            DataRow row = this._detailTable.Rows.Find(dtlRelationGuid);

            if (row != null)
            {
                this.DetailOrderCancel(row);
            }
        }

        /// <summary>
        /// 明細の発注数設定
        /// </summary>
        /// <param name="dtlRelationGuid"></param>
        /// <param name="orderCnt"></param>
        public void DetailSettingOrderCnt(Guid dtlRelationGuid, int orderCnt)
        {
            DataRow row = this._detailTable.Rows.Find(dtlRelationGuid);

            if (row != null)
            {
                row[OrderSelectDtlTable.ctColName_OrderCnt] = orderCnt;
            }
            this._detailTable.AcceptChanges();
        }

        /// <summary>
        /// 明細の発注数初期値設定
        /// </summary>
        /// <param name="dtlRelationGuid"></param>
        public void DetailSettingDefaultOrderCnt(Guid dtlRelationGuid)
        {
            DataRow row = this._detailTable.Rows.Find(dtlRelationGuid);

            if (row != null)
            {
                row[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt] = (int)(double)row[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_ShipmentCnt];
            }
            this._detailTable.AcceptChanges();
        }

        /// <summary>
        /// 明細発注キャンセル処理
        /// </summary>
        /// <param name="supplierCd"></param>
        public void DetailOrderCancel(int supplierCd)
        {
            DataRow[] rows = this._detailTable.Select(string.Format("{0}={1}", EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_SupplierCd, supplierCd));

            if (( rows != null ) && ( rows.Length > 0 ))
            {
                foreach (DataRow row in rows)
                {
                    this.DetailOrderCancel(row);
                }
            }
        }

        /// <summary>
        /// 明細発注キャンセル処理
        /// </summary>
        /// <param name="dtlRelationGuid"></param>
        public  void DetailOrderCancel(Guid dtlRelationGuid)
        {
            DataRow row = this._detailTable.Rows.Find(dtlRelationGuid);

            if (row != null)
            {
                this.DetailOrderCancel(row);
            }
            this._detailTable.AcceptChanges();
        }

        /// <summary>
        /// 明細発注キャンセル処理
        /// </summary>
        /// <param name="row"></param>
        public void DetailOrderCancel(DataRow row)
        {
            if (row != null)
            {
                row[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt] = 0;
                row[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode] = "*";
            }
        }

        /// <summary>
        /// 発注数設定
        /// </summary>
        /// <param name="dtlRelationGuid"></param>
        /// <param name="orderCnt"></param>
        public void DetailOrderCntSetting(Guid dtlRelationGuid, int orderCnt)
        {
            DataRow row = this._detailTable.Rows.Find(dtlRelationGuid);

            if (row != null)
            {
                row[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt] = orderCnt;
            }
        }

        /// <summary>
        /// 発注可否チェック
        /// </summary>
        /// <param name="dtlRelationGuid"></param>
        public bool ChackCanOrder(Guid dtlRelationGuid)
        {
            bool ret = false;

            DataRow row = this._detailTable.Rows.Find(dtlRelationGuid);

            if (row != null)
            {
                DataRow hdRow = this._headerTable.Rows.Find((int)row[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_SupplierCd]);
                if (hdRow != null)
                {
                    UOESupplier uoeSupplier = (UOESupplier)hdRow[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOESupplier];

                    UOESupplierAcs.PureCodeDiv pureCodeDiv = UOESupplierAcs.PureCodeUOESupplier(uoeSupplier.CommAssemblyId);
                    if (pureCodeDiv == UOESupplierAcs.PureCodeDiv.Prime)
                    {
                        ret = true;
                    }
                    else
                    {
                        int goodsMakerCd = (int)row[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_GoodsMakerCd];
                        ret = ( ( goodsMakerCd == uoeSupplier.EnableOdrMakerCd1 ) || ( goodsMakerCd == uoeSupplier.EnableOdrMakerCd2 ) || ( goodsMakerCd == uoeSupplier.EnableOdrMakerCd3 ) || ( goodsMakerCd == uoeSupplier.EnableOdrMakerCd4 ) || ( goodsMakerCd == uoeSupplier.EnableOdrMakerCd5 ) );
                    }
                }
            }

            return ret;
        }

        //  ADD 2011/02/14  >>>
        /// <summary>
        /// 発注選択時の数量チェック
        /// </summary>
        /// <param name="supplierCd">仕入先コード</param>
        /// <returns></returns>
        public string CheckDetail(int supplierCd)
        {
            string message = null;

            this._detailView.RowFilter = string.Format("{0}={1}", EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_SupplierCd, supplierCd);

            int index = 1;
            foreach (DataRowView drv in this._detailView)
            {
                if ((int)(drv.Row[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt]) > 999)
                    message += "      行№ " + index.ToString() + "\r\n";
                index++;
            }

            return message;
        } 
        //  ADD 2011/02/14  <<<

        #endregion

        // ===================================================================================== //
        // プライベート メソッド
        // ===================================================================================== //
        #region ■Private Methods

        // --- DEL 2013/04/15 donggy for Redmine#35020 ---->>>>>>>>>
        #region DEL
        //// ADD 2013/03/13 宋剛 Redmine#35020 No.1834 ---->>>>>>>>
        ///// <summary>
        ///// 全てUOE発注先情報検索処理
        ///// </summary>
        //private void FindAllSupplierInfo()
        //{
        //    // 全てUOE発注先情報Dictionary初期化処理
        //    _allSupplierDic = new Dictionary<int, UOESupplier>();
        //    ArrayList supplierList = new ArrayList();

        //    // UOE 発注先マスタ情報のリストを取得します。
        //    _uOESupplierAcs.Search(out supplierList, this._enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);

        //    // UOE発注先情報Dictionary作成
        //    // Dictionaryの説明
        //    //           KEY : UOESupplierCd
        //    //           VALUE : UOESupplier
        //    foreach (UOESupplier tempUOESupplier in supplierList)
        //    {
        //        if (!_allSupplierDic.ContainsKey(tempUOESupplier.UOESupplierCd))
        //        {
        //            _allSupplierDic.Add(tempUOESupplier.UOESupplierCd, tempUOESupplier);
        //        }
        //    }
        //}
        //// ADD 2013/03/13 宋剛 Redmine#35020 No.1834 ----<<<<<<<<
        #endregion DEL
        // --- DEL 2013/04/15 donggy for Redmine#35020 ----<<<<<<<<
        /// <summary>
        /// 発注先情報の読み込みと初期設定処理
        /// </summary>
        /// <param name="row"></param>
        /// <param name="supplierCd"></param>
        /// <param name="defaultSetting"></param>
        /// <br>Update Note  : 2013/04/15 donggy</br>
        /// <br>管理番号     : 10900691-00 2013/05/15配信分</br>
        /// <br>               Redmine#35020　検索見積」の「発注検索画面」のレスポンス低下のトリガーの排除</br>
        private void UOESupplierInfoReadAndSetting(DataRow row, int supplierCd, bool defaultSetting)
        {
            if (row != null)
            {
                UOESupplier uoeSupplier;
                // --- DEL 2013/04/15 donggy for  Redmine#35020 ---->>>>>>>>
                //// ADD 2013/03/13 宋剛 Redmine#35020 No.1834 ---->>>>>>>>
                //if (null == _allSupplierDic)
                //{
                //    _allSupplierDic = new Dictionary<int, UOESupplier>();
                //}

                //// UOE発注先Dictionaryから、UOE発注先情報取得
                //if (_allSupplierDic.ContainsKey(supplierCd))
                //{
                //    uoeSupplier = _allSupplierDic[supplierCd];
                //}
                //else
                //{
                //    // UOE発注先Dictionaryがなければ、再検索処理を行います
                //    int status = this._uOESupplierAcs.Read(out uoeSupplier, this._enterpriseCode, supplierCd, LoginInfoAcquisition.Employee.BelongSectionCode);

                //    // 発注先が存在しない場合、初期化UOESupplierオブジェクト
                //    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //    {
                //        uoeSupplier = new UOESupplier();
                //    }

                //    // 発注先が存在する場合、UOE発注先Dictionaryに追加します
                //    if (!_allSupplierDic.ContainsKey(supplierCd))
                //    {
                //        _allSupplierDic.Add(supplierCd, uoeSupplier);
                //    }
                //}

                //this.UOESupplierInfoSetting(row, _allSupplierDic[supplierCd], true);
                //// ADD 2013/03/13 宋剛 Redmine#35020 No.1834 ----<<<<<<<<
                // --- DEL 2013/04/15 donggy for  Redmine#35020 ----<<<<<<<<<


                /* DEL 2013/03/13 宋剛 Redmine#35020 No.1834 ---->>>>>>>>
                int status = this._uOESupplierAcs.Read(out uoeSupplier, this._enterpriseCode, supplierCd, LoginInfoAcquisition.Employee.BelongSectionCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.UOESupplierInfoSetting(row, uoeSupplier, true);
                }
                else
                {
                        uoeSupplier = new UOESupplier();
                    }
                this.UOESupplierInfoSetting(row, uoeSupplier, true);
                // DEL 2013/03/13 宋剛 Redmine#35020 No.1834 ----<<<<<<<<*/
                // --- ADD 2013/04/15 donggy for  Redmine#35020 ---->>>>>>>>
                int status = this._uOESupplierAcs.Read(out uoeSupplier, this._enterpriseCode, supplierCd, LoginInfoAcquisition.Employee.BelongSectionCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.UOESupplierInfoSetting(row, uoeSupplier, true);
                }
                else
                {
                    uoeSupplier = new UOESupplier();
                }
                this.UOESupplierInfoSetting(row, uoeSupplier, true);
                // --- ADD 2013/04/15 donggy for  Redmine#35020 ----<<<<<<<<<
            }
        }

        ///// <summary>
        ///// 発注先情報の設定
        ///// </summary>
        ///// <param name="row"></param>
        ///// <param name="uoeSupplier"></param>
        //private void UOESupplierInfoSetting(DataRow row, UOESupplier uoeSupplier)
        //{
        //    if (row != null)
        //    {
        //        row[OrderSelectHdTable.ctColName_UOESupplier] = uoeSupplier;
        //    }
        //}
      
        /// <summary>
        /// 発注先情報の初期値設定処理
        /// </summary>
        /// <param name="row">データ行</param>
        /// <param name="uoeSupplier">ＵＯＥ発注先マスタ</param>
        /// <param name="defaultSetting">True:初期値設定</param>
        private void UOESupplierInfoSetting(DataRow row, UOESupplier uoeSupplier, bool defaultSetting)
        {
            if (row != null)
            {
                row[OrderSelectHdTable.ctColName_UOESupplier] = uoeSupplier;
                if (defaultSetting)
                {
                    row[OrderSelectHdTable.ctColName_UOESupplierCd] = uoeSupplier.UOESupplierCd;
                    row[OrderSelectHdTable.ctColName_UOESupplierName] = uoeSupplier.UOESupplierName;

                    if ((Guid)row[OrderSelectHdTable.ctColName_OrderGuid] == Guid.Empty)
                    {
                        row[OrderSelectHdTable.ctColName_UoeRemark1] = this._estimateInputInitDataAcs.GetUOESetting().InpSearchRemark;
                        row[OrderSelectHdTable.ctColName_UoeRemark2] = string.Empty;

                        // 納品区分の初期値設定
                        if (UOESupplierAcs.EnabledDeliveredGoodsDiv(uoeSupplier.CommAssemblyId))
                        {
                            string uoeGuideCode, uoeGuideName;
                            this._estimateInputInitDataAcs.GetMinElementFromUOEGuideName(EstimateInputInitDataAcs.ctUOEGuideDivCd_DeliveredGoodsDiv, uoeSupplier.UOESupplierCd, out uoeGuideCode, out uoeGuideName);
                            row[OrderSelectHdTable.ctColName_UOEDeliGoodsDiv] = uoeGuideCode;
                            row[OrderSelectHdTable.ctColName_DeliveredGoodsDivNm] = uoeGuideName;
                        }
                        else
                        {
                            row[OrderSelectHdTable.ctColName_UOEDeliGoodsDiv] = string.Empty;
                            row[OrderSelectHdTable.ctColName_DeliveredGoodsDivNm] = string.Empty;
                        }

                        // H納品区分の初期値設定
                        if (UOESupplierAcs.EnabledFollowDeliGoodsDiv(uoeSupplier.CommAssemblyId))
                        {
                            string uoeGuideCode, uoeGuideName;
                            this._estimateInputInitDataAcs.GetMinElementFromUOEGuideName(EstimateInputInitDataAcs.ctUOEGuideDivCd_DeliveredGoodsDiv, uoeSupplier.UOESupplierCd, out uoeGuideCode, out uoeGuideName);
                            row[OrderSelectHdTable.ctColName_FollowDeliGoodsDiv] = uoeGuideCode;
                            row[OrderSelectHdTable.ctColName_FollowDeliGoodsDivNm] = uoeGuideName;
                        }
                        else
                        {
                            row[OrderSelectHdTable.ctColName_FollowDeliGoodsDiv] = string.Empty;
                            row[OrderSelectHdTable.ctColName_FollowDeliGoodsDivNm] = string.Empty;
                        }

                        // 担当拠点の初期値設定
                        if (UOESupplierAcs.EnabledUOEResvdSection(uoeSupplier.CommAssemblyId))
                        {
                            string uoeGuideCode, uoeGuideName;
                            this._estimateInputInitDataAcs.GetMinElementFromUOEGuideName(EstimateInputInitDataAcs.ctUOEGuideDivCd_UOEResvdSection, uoeSupplier.UOESupplierCd, out uoeGuideCode, out uoeGuideName);
                            row[OrderSelectHdTable.ctColName_UOEResvdSection] = uoeGuideCode;
                            row[OrderSelectHdTable.ctColName_UOEResvdSectionNm] = uoeGuideName;
                        }
                        else
                        {
                            row[OrderSelectHdTable.ctColName_UOEResvdSection] = string.Empty;
                            row[OrderSelectHdTable.ctColName_UOEResvdSectionNm] = string.Empty;
                        }
                    }
                }
            }
        }

        #endregion

        // ===================================================================================== //
        // 発注選択用のヘッダ、明細のテーブルスキーマ定義
        // ===================================================================================== //
        #region 表示用のテーブルスキーマ定義クラス

        /// <summary>
        /// 発注選択のヘッダ用のテーブルスキーマ定義クラス
        /// </summary>
        public class OrderSelectHdTable
        {
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public OrderSelectHdTable()
            {
            }

            /// <summary>テーブル名称</summary>
            public const string ctTableName = "OrderSelectHdTable";
            /// <summary>カラム名（発注有無）</summary>
            public const string ctColName_ExistOrder = "ExistOrder";
            /// <summary>カラム名（表示用発注有無）</summary>
            public const string ctColName_ExistOrderDisplay = "ExistOrderDisplay";
            /// <summary>カラム名（仕入先コード）</summary>
            public const string ctColName_SupplierCd = "SupplierCd";
            /// <summary>カラム名（仕入先略称）</summary>
            public const string ctColName_SupplierSnm = "SupplierSnm";
            /// <summary>カラム名（ＵＯＥ発注先）</summary>
            public const string ctColName_UOESupplierCd = "UOESupplierCd";
            /// <summary>カラム名（ＵＯＥ発注先名称）</summary>
            public const string ctColName_UOESupplierName = "UOESupplierName";
            /// <summary>カラム名（ＵＯＥ仕入先）</summary>
            public const string ctColName_UOESupplier = "UOESupplier";
            /// <summary>カラム名（ＵＯＥリマーク１）</summary>
            public const string ctColName_UoeRemark1 = "UoeRemark1";
            /// <summary>カラム名（ＵＯＥリマーク２）</summary>
            public const string ctColName_UoeRemark2 = "UoeRemark2";
            /// <summary>カラム名（ＵＯＥ納品区分）</summary>
            public const string ctColName_UOEDeliGoodsDiv = "UOEDeliGoodsDiv";
            /// <summary>カラム名（ＵＯＥ納品区分名称）</summary>
            public const string ctColName_DeliveredGoodsDivNm = "DeliveredGoodsDivNm";
            /// <summary>カラム名（フォロー納品区分）</summary>
            public const string ctColName_FollowDeliGoodsDiv = "FollowDeliGoodsDiv";
            /// <summary>カラム名（フォロー納品区分名称）</summary>
            public const string ctColName_FollowDeliGoodsDivNm = "FollowDeliGoodsDivNm";
            /// <summary>カラム名（指定拠点）</summary>
            public const string ctColName_UOEResvdSection = "UOEResvdSection";
            /// <summary>カラム名（指定拠点名称）</summary>
            public const string ctColName_UOEResvdSectionNm = "UOEResvdSectionNm";

            /// <summary>カラム名（発注ＧＵＩＤ）</summary>
            public const string ctColName_OrderGuid = "OrderGuid";

            /// <summary>
            /// テーブルを生成します。
            /// </summary>
            /// <param name="dt"></param>
            static public void CreateTable(ref DataTable dt)
            {
                if (dt == null)
                {
                    dt = new DataTable(ctTableName);
                }
                dt.Rows.Clear();

                // カラム生成
                // 発注有無
                dt.Columns.Add(ctColName_ExistOrder, typeof(bool));
                dt.Columns[ctColName_ExistOrder].DefaultValue = false;

                // 発注有無(表示)
                dt.Columns.Add(ctColName_ExistOrderDisplay, typeof(string));
                dt.Columns[ctColName_ExistOrderDisplay].DefaultValue = string.Empty;

                // 仕入先
                dt.Columns.Add(ctColName_SupplierCd, typeof(int));
                dt.Columns[ctColName_SupplierCd].DefaultValue = 0;

                // 仕入先略称
                dt.Columns.Add(ctColName_SupplierSnm, typeof(string));
                dt.Columns[ctColName_SupplierSnm].DefaultValue = string.Empty;

                // 発注先コード
                dt.Columns.Add(ctColName_UOESupplierCd, typeof(int));
                dt.Columns[ctColName_UOESupplierCd].DefaultValue = 0;

                // 発注先名称
                dt.Columns.Add(ctColName_UOESupplierName, typeof(string));
                dt.Columns[ctColName_UOESupplierName].DefaultValue = string.Empty;

                // 発注先マスタオブジェクト
                dt.Columns.Add(ctColName_UOESupplier, typeof(UOESupplier));
                dt.Columns[ctColName_UOESupplier].DefaultValue = new UOESupplier();

                // ＵＯＥリマーク１
                dt.Columns.Add(ctColName_UoeRemark1, typeof(string));
                dt.Columns[ctColName_UoeRemark1].DefaultValue = string.Empty;

                // ＵＯＥリマーク２
                dt.Columns.Add(ctColName_UoeRemark2, typeof(string));
                dt.Columns[ctColName_UoeRemark2].DefaultValue = string.Empty;

                // 納品区分
                dt.Columns.Add(ctColName_UOEDeliGoodsDiv, typeof(string));
                dt.Columns[ctColName_UOEDeliGoodsDiv].DefaultValue = string.Empty;

                // 納品区分名称
                dt.Columns.Add(ctColName_DeliveredGoodsDivNm, typeof(string));
                dt.Columns[ctColName_DeliveredGoodsDivNm].DefaultValue = string.Empty;

                // フォロー納品区分
                dt.Columns.Add(ctColName_FollowDeliGoodsDiv, typeof(string));
                dt.Columns[ctColName_FollowDeliGoodsDiv].DefaultValue = string.Empty;

                // フォロー納品区分名称
                dt.Columns.Add(ctColName_FollowDeliGoodsDivNm, typeof(string));
                dt.Columns[ctColName_FollowDeliGoodsDivNm].DefaultValue = string.Empty;

                // UOE指定拠点
                dt.Columns.Add(ctColName_UOEResvdSection, typeof(string));
                dt.Columns[ctColName_UOEResvdSection].DefaultValue = string.Empty;

                // UOE指定拠点名称
                dt.Columns.Add(ctColName_UOEResvdSectionNm, typeof(string));
                dt.Columns[ctColName_UOEResvdSectionNm].DefaultValue = string.Empty;


                dt.Columns.Add(ctColName_OrderGuid, typeof(Guid));
                dt.Columns[ctColName_OrderGuid].DefaultValue = Guid.Empty;

                dt.PrimaryKey = new DataColumn[] { dt.Columns[ctColName_SupplierCd] };
            }
        }

        /// <summary>
        /// 発注選択の明細用のテーブルスキーマ定義クラス
        /// </summary>
        /// <br>Update Note: 2013/03/08 譚洪</br>
        /// <br>管理番号   : 10801804-00、2013/03/13配信分</br>
        /// <br>             Redmine#34994 優良発注先の場合にＢＯ区分を入力すると、発注数がデフォルト表示しなく、０で表示されるの対応</br>
        /// <remarks></remarks>
        public class OrderSelectDtlTable
        {
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public OrderSelectDtlTable()
            {
            }

            /// <summary>発注選択明細用テーブル名称</summary>
            public const string ctTableName = "OrderSelectDtlTable";

            /// <summary>カラム名（No.）</summary>
            public const string ctColName_No = "No";

            /// <summary>カラム名（明細連結ＧＵＩＤ）</summary>
            public const string ctColName_DtlRelationGuid = "DtlRelationGuid";
            /// <summary>カラム名（仕入先コード）</summary>
            public const string ctColName_SupplierCd = "SupplierCd";
            /// <summary>カラム名（ＢＯコード）</summary>
            public const string ctColName_BOCode = "BOCode";
            /// <summary>カラム名（発注数）</summary>
            public const string ctColName_OrderCnt = "OrderCnt";
            /// <summary>カラム名（出荷数）</summary>
            public const string ctColName_ShipmentCnt = "ShipmentCnt";
            /// <summary>カラム名（品名）</summary>
            public const string ctColName_GoodsName = "GoodsNo";
            /// <summary>カラム名（品番）</summary>
            public const string ctColName_GoodsNo = "GoodsName";
            /// <summary>カラム名（メーカーコード）</summary>
            public const string ctColName_GoodsMakerCd = "GoodsMakerCd";
            /// <summary>カラム名（倉庫コード）</summary>
            public const string ctColName_WarehouseCode = "WarehouseCode";
            /// <summary>カラム名（現在庫数）</summary>
            public const string ctColName_ShipmentPosCnt = "ShipmentPosCnt";

            /// <summary>
            /// テーブルを生成します。
            /// </summary>
            /// <param name="dt"></param>
            static public void CreateTable(ref DataTable dt)
            {
                if (dt == null)
                {
                    dt = new DataTable(ctTableName);
                }

                dt.Rows.Clear();

                // カラム生成
                // 明細連結Guid
                dt.Columns.Add(ctColName_DtlRelationGuid, typeof(Guid));
                dt.Columns[ctColName_DtlRelationGuid].DefaultValue = Guid.Empty;

                // №
                dt.Columns.Add(ctColName_No, typeof(int));
                dt.Columns[ctColName_No].DefaultValue = 0;

                // 仕入先
                dt.Columns.Add(ctColName_SupplierCd, typeof(int));
                dt.Columns[ctColName_SupplierCd].DefaultValue = 0;

                // BO
                dt.Columns.Add(ctColName_BOCode, typeof(string));
                dt.Columns[ctColName_BOCode].DefaultValue = string.Empty;

                // 発注数
                dt.Columns.Add(ctColName_OrderCnt, typeof(int));
                dt.Columns[ctColName_OrderCnt].DefaultValue = 0;

                // QTY
                dt.Columns.Add(ctColName_ShipmentCnt, typeof(double));
                dt.Columns[ctColName_ShipmentCnt].DefaultValue = 0;

                // 品名
                dt.Columns.Add(ctColName_GoodsName, typeof(string));
                dt.Columns[ctColName_GoodsName].DefaultValue = string.Empty;

                // 品番
                dt.Columns.Add(ctColName_GoodsNo, typeof(string));
                dt.Columns[ctColName_GoodsNo].DefaultValue = string.Empty;

                // メーカーコード
                dt.Columns.Add(ctColName_GoodsMakerCd, typeof(int));
                dt.Columns[ctColName_GoodsMakerCd].DefaultValue = 0;

                // 倉庫
                dt.Columns.Add(ctColName_WarehouseCode, typeof(string));
                dt.Columns[ctColName_WarehouseCode].DefaultValue = string.Empty;

                // 現在庫数
                // DEL 2013/03/08 tanh Redmine#34994 ---- >>>>>
                //dt.Columns.Add(ctColName_ShipmentPosCnt, typeof(double));
                //dt.Columns[ctColName_ShipmentPosCnt].DefaultValue = 0;
                // DEL 2013/03/08 tanh Redmine#34994 ---- <<<<<

                // ADD 2013/03/08 tanh Redmine#34994 ---- >>>>>
                dt.Columns.Add(ctColName_ShipmentPosCnt, typeof(string));
                dt.Columns[ctColName_ShipmentPosCnt].DefaultValue = string.Empty;
                // ADD 2013/03/08 tanh Redmine#34994 ---- <<<<<

                dt.PrimaryKey = new DataColumn[] { dt.Columns[ctColName_DtlRelationGuid] };
            }
        }

        #endregion

    }
}
