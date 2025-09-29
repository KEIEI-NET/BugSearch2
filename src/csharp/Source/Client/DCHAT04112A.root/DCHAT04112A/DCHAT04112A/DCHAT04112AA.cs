# region ※using
using System;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
# endregion

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 発注残照会 テーブルアクセスクラス
    /// </summary>
    /// <remarks>
	/// <br>Note		: 発注データの検索を行います。</br>
	/// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2007.10.15</br>
    /// </remarks>
    public class DCHAT04112AA
    {
        # region ■Private Member
        /// <summary>リモートオブジェクト格納バッファ</summary>
        private IOrderListWorkDB _iOrderListWorkDB = null;
        /// <summary>拠点オプションフラグ</summary>
        private bool _optSection;
		// 拠点アクセスクラス
        private static SecInfoAcs _secInfoAcs;													
		private OrderRemainDataSet _dataSet;
		private static OrderRemainDataSet.OrderListResultDataTable _orderListResultDataTable;
        private static OrderListCndtnWork _orderListCndtnCache;
        private static SortedList _nameList;
        //private static DCHAT04112AA _searchSlipAcs;

        private string _enterpriseCode;             // 企業コード

        private const string MESSAGE_NoResult = "検索条件に一致する伝票は存在しません。";
        private const string MESSAGE_ErrResult = "伝票情報の取得に失敗しました。";
        private const string MESSAGE_NONOWNSECTION = "自拠点情報が取得できませんでした。拠点設定を行ってから起動してください。";
		private const string ct_DateFormat = "yyyy/MM/dd";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
        private int _maxSelectCount;
        private bool _rowChangeStatus;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

        # endregion

		#region ■event
		public event GetNameListEventHandler GetNameList;
        public delegate SortedList GetNameListEventHandler();

        public event SettingStatusBarMessageEventHandler StatusBarMessageSetting;
		public delegate void SettingStatusBarMessageEventHandler( object sender, string message );

		public event EventHandler SelectedRowChanged;
		#endregion

		# region ■Constracter
		/// <summary>
		/// 発注残照会 テーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
		/// <br>Note       : 発注残照会アクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        public DCHAT04112AA()
        {
            //　企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            
            // 拠点OPの判定
            this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);
            this._dataSet = new OrderRemainDataSet();

            // ログイン部品で通信状態を確認
            if (LoginInfoAcquisition.OnlineFlag)
            {
                try
                {
                    // リモートオブジェクト取得
					this._iOrderListWorkDB = (IOrderListWorkDB)MediationOrderListWorkDB.GetOrderListWorkDB();
                }
                catch (Exception)
                {
                    //オフライン時はnullをセット
                    this._iOrderListWorkDB = null;
                }
            }
            else
            {
                // オフライン時のデータ読み込み
                //this.SearchOfflineData();
                MessageBox.Show("オフライン状態のため検索が実行できません。");
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            this.RowChangeStatus = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
        }
        # endregion

        /// <summary>
		/// 発注残照会データセット取得処理
        /// </summary>
		/// <returns>発注残照会データセット</returns>
        public OrderRemainDataSet DataSet
        {
            get { return this._dataSet; }
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
        /// <summary>
        /// 選択可能最大明細行数
        /// </summary>
        public int MaxSelectCount
        {
            get { return _maxSelectCount; }
            set { _maxSelectCount = value; }
        }
        /// <summary>
        /// 行選択状態変更ステータス
        /// </summary>
        public bool RowChangeStatus
        {
            get { return _rowChangeStatus; }
            set { _rowChangeStatus = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

        # region ◆public int GetOnlineMode()
        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iOrderListWorkDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }
        # endregion

        #region ■Private Method

        /// <summary>
        /// 伝票データテーブル キャッシュ処理
        /// </summary>
        private void CacheOrderRemainTable()
        {
            if (_orderListResultDataTable == null)
            {
                _orderListResultDataTable = new OrderRemainDataSet.OrderListResultDataTable();
            }

            this._dataSet.OrderListResult.AcceptChanges();
            _orderListResultDataTable = (OrderRemainDataSet.OrderListResultDataTable)this._dataSet.OrderListResult.Copy();
        }

        /// <summary>
        /// 検索条件クラス(再表示用) キャッシュ処理
        /// </summary>
        private void CacheOrderListCndtn(OrderListCndtnWork orderListCndtnWork)
        {
            // 検索条件値
            if (_orderListCndtnCache == null)
            {
                _orderListCndtnCache = new OrderListCndtnWork();
            }
            _orderListCndtnCache = orderListCndtnWork;

            // 名称
            if (_nameList == null)
            {
                _nameList = new SortedList();
            }

            // デリゲートにて画面の名称項目値リストを取得・格納
            if (this.GetNameList != null)
            {
                _nameList = this.GetNameList();
            }
        }

		/// <summary>
		/// 発注一覧抽出結果ワークオブジェクトから発注一覧抽出結果データテーブル行オブジェクトを生成します。
		/// </summary>
		/// <param name="no">行番号</param>
		/// <param name="orderListResultWork"></param>
		/// <returns></returns>
		private OrderRemainDataSet.OrderListResultRow CreateOrderListResultRow( int no, OrderListResultWork orderListResultWork )
		{
			OrderRemainDataSet.OrderListResultRow row = _dataSet.OrderListResult.NewOrderListResultRow();

			#region 項目のコピー

			row.No = no;
			row.SelectFlag = false;
			row.DebitNoteDiv = orderListResultWork.DebitNoteDiv;
			row.SupplierSlipCd = orderListResultWork.SupplierSlipCd;
			row.PartySaleSlipNum = orderListResultWork.PartySaleSlipNum;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //row.OrderFormPrintDate = orderListResultWork.OrderFormPrintDate;
            //row.OrderFormPrintDateDisplay = GetDateTimeString(orderListResultWork.OrderFormPrintDate, ct_DateFormat);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
			row.AcceptAnOrderNo = orderListResultWork.AcceptAnOrderNo;
			row.SupplierFormal = orderListResultWork.SupplierFormal;
            // 2008.11.19 modify start [7968]
            if (orderListResultWork.SupplierSlipNo > 0)
            {
                row.SupplierSlipNo = orderListResultWork.SupplierSlipNo;
            }
            // 2008.11.19 modify end [7968]
			row.StockRowNo = orderListResultWork.StockRowNo;
			row.SectionCode = orderListResultWork.SectionCode;
			row.StockAgentCode = orderListResultWork.StockAgentCode;
			row.StockAgentName = orderListResultWork.StockAgentName;
			row.StockInputCode = orderListResultWork.StockInputCode;
			row.StockInputName = orderListResultWork.StockInputName;
			row.GoodsMakerCd = orderListResultWork.GoodsMakerCd;
			row.MakerName = orderListResultWork.MakerName;
			row.GoodsNo = orderListResultWork.GoodsNo;
			row.GoodsName = orderListResultWork.GoodsName;
			row.WarehouseCode = orderListResultWork.WarehouseCode;
			row.WarehouseName = orderListResultWork.WarehouseName;
			row.StockOrderDivCd = orderListResultWork.StockOrderDivCd;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //row.UnitCode = orderListResultWork.UnitCode;
            //row.UnitName = orderListResultWork.UnitName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
			row.StockUnitPriceFl = orderListResultWork.StockUnitPriceFl;
			row.StockUnitTaxPriceFl = orderListResultWork.StockUnitTaxPriceFl;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //row.BargainCd = orderListResultWork.BargainCd;
            //row.BargainNm = orderListResultWork.BargainNm;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
			row.StockCount = orderListResultWork.StockCount - orderListResultWork.OrderRemainCnt;
			row.StockPriceTaxExc = orderListResultWork.StockPriceTaxExc;
			row.StockPriceTaxInc = orderListResultWork.StockPriceTaxInc;
			row.StockDtiSlipNote1 = orderListResultWork.StockDtiSlipNote1;
			row.SalesCustomerCode = orderListResultWork.SalesCustomerCode;
			row.SalesCustomerSnm = orderListResultWork.SalesCustomerSnm;
            // 2008.11.19 modify start [7968]
            if (orderListResultWork.SupplierCd > 0)
            {
                row.SupplierCd = orderListResultWork.SupplierCd;
            }
            // 2008.11.19 modify end [7968]
			row.SupplierSnm = orderListResultWork.SupplierSnm;
			row.AddresseeCode = orderListResultWork.AddresseeCode;
			row.AddresseeName = orderListResultWork.AddresseeName;
			row.RemainCntUpdDate = orderListResultWork.RemainCntUpdDate;
			row.RemainCntUpdDateDisplay = GetDateTimeString(orderListResultWork.RemainCntUpdDate, ct_DateFormat);
			row.DirectSendingCd = orderListResultWork.DirectSendingCd;
			row.OrderNumber = orderListResultWork.OrderNumber;
			row.WayToOrder = orderListResultWork.WayToOrder;
			row.DeliGdsCmpltDueDate = orderListResultWork.DeliGdsCmpltDueDate;
			row.DeliGdsCmpltDueDateDisplay = GetDateTimeString(orderListResultWork.DeliGdsCmpltDueDate, ct_DateFormat);
			row.ExpectDeliveryDate = orderListResultWork.ExpectDeliveryDate;
			row.ExpectDeliveryDateDisplay = GetDateTimeString(orderListResultWork.ExpectDeliveryDate, ct_DateFormat);
			row.OrderCnt = orderListResultWork.StockCount;
			row.OrderAdjustCnt = orderListResultWork.StockCount;
			row.OrderRemainCnt = orderListResultWork.OrderRemainCnt;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //row.ReconcileFlag = orderListResultWork.ReconcileFlag;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
			row.OrderFormIssuedDiv = orderListResultWork.OrderFormIssuedDiv;
			row.OrderDataCreateDate = orderListResultWork.OrderDataCreateDate;
			row.OrderDataCreateDateDisplay = GetDateTimeString(orderListResultWork.OrderDataCreateDate, ct_DateFormat);
			row.SlipMemo1 = orderListResultWork.SlipMemo1;
			row.SlipMemo2 = orderListResultWork.SlipMemo2;
			row.SlipMemo3 = orderListResultWork.SlipMemo3;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //row.SlipMemo4 = orderListResultWork.SlipMemo4;
            //row.SlipMemo5 = orderListResultWork.SlipMemo5;
            //row.SlipMemo6 = orderListResultWork.SlipMemo6;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
			row.InsideMemo1 = orderListResultWork.InsideMemo1;
			row.InsideMemo2 = orderListResultWork.InsideMemo2;
			row.InsideMemo3 = orderListResultWork.InsideMemo3;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //row.InsideMemo4 = orderListResultWork.InsideMemo4;
            //row.InsideMemo5 = orderListResultWork.InsideMemo5;
            //row.InsideMemo6 = orderListResultWork.InsideMemo6;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
			row.StockSlipDtlNum = orderListResultWork.StockSlipDtlNum;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //if (( row.SlipMemo1 != string.Empty ) || ( row.SlipMemo2 != string.Empty ) || ( row.SlipMemo3 != string.Empty ) ||
            //    ( row.SlipMemo4 != string.Empty ) || ( row.SlipMemo5 != string.Empty ) || ( row.SlipMemo6 != string.Empty ) ||
            //    ( row.InsideMemo1 != string.Empty ) || ( row.InsideMemo2 != string.Empty ) || ( row.InsideMemo3 != string.Empty ) ||
            //    ( row.InsideMemo4 != string.Empty ) || ( row.InsideMemo5 != string.Empty ) || ( row.InsideMemo6 != string.Empty )
            //    )
            //{
            //    row.MemoExist = true;
            //    row.MemoExistName = "○";
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            if ( (row.SlipMemo1 != string.Empty) || (row.SlipMemo2 != string.Empty) || (row.SlipMemo3 != string.Empty) ||
                (row.InsideMemo1 != string.Empty) || (row.InsideMemo2 != string.Empty) || (row.InsideMemo3 != string.Empty)
                )
            {
                row.MemoExist = true;
                row.MemoExistName = "○";
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
            // 2008.11.19 add start [7968]
            if (orderListResultWork.InputDay != DateTime.MinValue)
            {
                row.InputDay = orderListResultWork.InputDay;
            }
            if (orderListResultWork.BLGoodsCode > 0)
            {
                row.BLGoodsCode = orderListResultWork.BLGoodsCode;
            }
            row.ListPriceTaxExcFl = orderListResultWork.ListPriceTaxExcFl;
            row.StockPriceConsTax = orderListResultWork.StockPriceConsTax;
            row.SectionGuideNm = orderListResultWork.SectionGuideNm;
            row.SectionGuideSnm = orderListResultWork.SectionGuideSnm;
            // 2008.11.19 add end [7968]

			#endregion

			return row;
		}

        #endregion

        #region ■Public Method

        /// <summary>
		/// 発注残照会 読込・データセット格納実行処理
        /// </summary>
		/// <param name="ioWriteMASIRReadWork">発注残検索パラメータクラス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 伝票情報を読み込みます。</br>
		/// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        public int SetSearchData(OrderListCndtnWork orderListCndtnWork)
        {
            List<OrderListResultWork> retData;
            
            int status = this.Search(out retData, orderListCndtnWork);

            this.ClearOrderListResultDataTable();

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                for (int i = 0; i < retData.Count; i++)
                {
                    OrderListResultWork orderListResultWork = retData[i];
					
					_dataSet.OrderListResult.AddOrderListResultRow(CreateOrderListResultRow(i + 1, orderListResultWork));
				}

                // 検索データのキャッシュ
                this.CacheOrderRemainTable();

                // 検索条件のキャッシュ
                this.CacheOrderListCndtn(orderListCndtnWork);
            }
            else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                     (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
            {
                if (this.StatusBarMessageSetting != null)
                {
                    this.StatusBarMessageSetting(this, MESSAGE_NoResult);
                }
            }
            return status;
        }

		/// <summary>
		/// 検索済みデータのデータセット格納処理
		/// </summary>
		/// <param name="orderListResultWorkList">発注残検索結果オブジェクトリスト</param>
		/// <returns></returns>
		public void SetSearchData( List<OrderListResultWork> orderListResultWorkList )
		{
			this.ClearOrderListResultDataTable();

			int cnt = 0;
			foreach (OrderListResultWork orderListResultWork in orderListResultWorkList)
			{
				this._dataSet.OrderListResult.AddOrderListResultRow(CreateOrderListResultRow(cnt++, orderListResultWork));

			}
			// 検索データのキャッシュ
			this.CacheOrderRemainTable();

			// 検索条件のキャッシュ
			this.CacheOrderListCndtn(new OrderListCndtnWork());
		}

        /// <summary>
        /// データセットクリア処理
        /// </summary>
        public void ClearOrderListResultDataTable()
        {
            this._dataSet.OrderListResult.Rows.Clear();

            // キャッシュデータの取り直し(クリア状態にする)
            this.CacheOrderRemainTable();
            this.CacheOrderListCndtn(null);

			if (this.SelectedRowChanged != null)
			{
				this.SelectedRowChanged(this, new EventArgs());
			}
		}
        
        /// <summary>
        /// 伝票情報 読み込み処理
        /// </summary>
        /// <param name="stockSlipWorks">仕入データ オブジェクト配列</param>
        /// <param name="orderListCndtnWork">仕入伝票検索パラメータクラス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 伝票情報を読み込みます。</br>
		/// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        public int Search(out List<OrderListResultWork> orderListResultWorkList, OrderListCndtnWork orderListCndtnWork)
        {
            try
            {
                int status;
                orderListResultWorkList = new List<OrderListResultWork>();

                // オンラインの場合リモート取得
                if (LoginInfoAcquisition.OnlineFlag)
                {
					ArrayList retList = new ArrayList();

					object paraObj = (object)orderListCndtnWork;
                    object retObj = (object)retList;

                    //伝票情報取得
					status = this._iOrderListWorkDB.Search(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData0);
                    
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
						foreach (OrderListResultWork orderListResultWork in (ArrayList)retObj)
						{
							orderListResultWorkList.Add(orderListResultWork);
						}
                    }
                    else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                             (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                    {
                        if (this.StatusBarMessageSetting != null)
                        {
                            this.StatusBarMessageSetting(this, MESSAGE_NoResult);
                        }
                    }
                    else
                    {
                        if (this.StatusBarMessageSetting != null)
                        {
                            this.StatusBarMessageSetting(this, MESSAGE_ErrResult);
                        }
                    }
                }
                else	// オフラインの場合
                {
                    //status = ReadStaticMemory(out lgoodsganre, enterpriseCode, largeGoodsGanreCode);
                    status = -1;
                }

                return status;
            }
            catch (Exception)
            {
                orderListResultWorkList = null;
                //オフライン時はnullをセット
                this._iOrderListWorkDB= null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 伝票データテーブルキャッシュ取得処理
        /// </summary>
        /// <returns>伝票データテーブルキャッシュ</returns>
        public OrderRemainDataSet.OrderListResultDataTable GetStockSlipTableCache()
        {
            return _orderListResultDataTable;
        }

        /// <summary>
        /// 画面名称項目値リスト キャッシュ取得処理
        /// </summary>
        /// <returns>画面名称項目値リスト キャッシュ</returns>
        public SortedList GetCacheNmaeList()
        {
            return _nameList;
        }


        /// <summary>
        /// 検索条件クラスキャッシュ取得処理
        /// </summary>
        /// <returns>検索条件クラスキャッシュ</returns>
        public OrderListCndtnWork GetOrderListCndtnCache()
        {
            return _orderListCndtnCache;
		}

		/// <summary>
		/// 検索条件クラスキャッシュクリア処理
		/// </summary>
		public void ClearOrderListCndtnCache()
		{
			_orderListCndtnCache = new OrderListCndtnWork();
		}

		/// <summary>
        /// 選択行テーブルデータ取得処理
        /// </summary>
        /// <returns>仕入データクラス</returns>
        /// <remarks>
        /// <br>Note       : データテーブルから、指定行の仕入データクラスを返します。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        public List<OrderListResultWork> GetSelectedRowData()
        {
			// 戻値
			List<OrderListResultWork> orderListResultWorkList = new List<OrderListResultWork>();

			DataView orderListResultView = new DataView(this._dataSet.OrderListResult);
			orderListResultView.RowFilter = String.Format("{0} = {1}", this._dataSet.OrderListResult.SelectFlagColumn.ColumnName, true);

			for (int ix = 0; ix < orderListResultView.Count; ix++)
			{
				#region 項目のコピー
				OrderListResultWork orderListResultWork = new OrderListResultWork();

				orderListResultWork.DebitNoteDiv = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.DebitNoteDivColumn.ColumnName];
				orderListResultWork.SupplierSlipCd = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.SupplierSlipCdColumn.ColumnName];
				orderListResultWork.PartySaleSlipNum = (string)orderListResultView[ix][this._dataSet.OrderListResult.PartySaleSlipNumColumn.ColumnName];
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                //orderListResultWork.OrderFormPrintDate = (DateTime)orderListResultView[ix][this._dataSet.OrderListResult.OrderFormPrintDateColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
				orderListResultWork.AcceptAnOrderNo = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.AcceptAnOrderNoColumn.ColumnName];
				orderListResultWork.SupplierFormal = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.SupplierFormalColumn.ColumnName];
				orderListResultWork.SupplierSlipNo = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.SupplierSlipNoColumn.ColumnName];
				orderListResultWork.StockRowNo = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.StockRowNoColumn.ColumnName];
				orderListResultWork.SectionCode = (string)orderListResultView[ix][this._dataSet.OrderListResult.SectionCodeColumn.ColumnName];
				orderListResultWork.StockAgentCode = (string)orderListResultView[ix][this._dataSet.OrderListResult.StockAgentCodeColumn.ColumnName];
				orderListResultWork.StockAgentName = (string)orderListResultView[ix][this._dataSet.OrderListResult.StockAgentNameColumn.ColumnName];
				orderListResultWork.StockInputCode = (string)orderListResultView[ix][this._dataSet.OrderListResult.StockInputCodeColumn.ColumnName];
				orderListResultWork.StockInputName = (string)orderListResultView[ix][this._dataSet.OrderListResult.StockInputNameColumn.ColumnName];
				orderListResultWork.GoodsMakerCd = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.GoodsMakerCdColumn.ColumnName];
				orderListResultWork.MakerName = (string)orderListResultView[ix][this._dataSet.OrderListResult.MakerNameColumn.ColumnName];
				orderListResultWork.GoodsNo = (string)orderListResultView[ix][this._dataSet.OrderListResult.GoodsNoColumn.ColumnName];
				orderListResultWork.GoodsName = (string)orderListResultView[ix][this._dataSet.OrderListResult.GoodsNameColumn.ColumnName];
				orderListResultWork.WarehouseCode = (string)orderListResultView[ix][this._dataSet.OrderListResult.WarehouseCodeColumn.ColumnName];
				orderListResultWork.WarehouseName = (string)orderListResultView[ix][this._dataSet.OrderListResult.WarehouseNameColumn.ColumnName];
				orderListResultWork.StockOrderDivCd = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.StockOrderDivCdColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                //orderListResultWork.UnitCode = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.UnitCodeColumn.ColumnName];
                //orderListResultWork.UnitName = (string)orderListResultView[ix][this._dataSet.OrderListResult.UnitNameColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
				orderListResultWork.StockUnitPriceFl = (Double)orderListResultView[ix][this._dataSet.OrderListResult.StockUnitPriceFlColumn.ColumnName];
				orderListResultWork.StockUnitTaxPriceFl = (Double)orderListResultView[ix][this._dataSet.OrderListResult.StockUnitTaxPriceFlColumn.ColumnName];
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                //orderListResultWork.BargainCd = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.BargainCdColumn.ColumnName];
                //orderListResultWork.BargainNm = (string)orderListResultView[ix][this._dataSet.OrderListResult.BargainNmColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
				orderListResultWork.StockCount = (Double)orderListResultView[ix][this._dataSet.OrderListResult.StockCountColumn.ColumnName];
				orderListResultWork.StockPriceTaxExc = (Int64)orderListResultView[ix][this._dataSet.OrderListResult.StockPriceTaxExcColumn.ColumnName];
				orderListResultWork.StockPriceTaxInc = (Int64)orderListResultView[ix][this._dataSet.OrderListResult.StockPriceTaxIncColumn.ColumnName];
				orderListResultWork.StockDtiSlipNote1 = (string)orderListResultView[ix][this._dataSet.OrderListResult.StockDtiSlipNote1Column.ColumnName];
				orderListResultWork.SalesCustomerCode = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.SalesCustomerCodeColumn.ColumnName];
				orderListResultWork.SalesCustomerSnm = (string)orderListResultView[ix][this._dataSet.OrderListResult.SalesCustomerSnmColumn.ColumnName];
				orderListResultWork.SupplierCd = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.SupplierCdColumn.ColumnName];
				orderListResultWork.SupplierSnm = (string)orderListResultView[ix][this._dataSet.OrderListResult.SupplierSnmColumn.ColumnName];
				orderListResultWork.AddresseeCode = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.AddresseeCodeColumn.ColumnName];
				orderListResultWork.AddresseeName = (string)orderListResultView[ix][this._dataSet.OrderListResult.AddresseeNameColumn.ColumnName];
				orderListResultWork.RemainCntUpdDate = (DateTime)orderListResultView[ix][this._dataSet.OrderListResult.RemainCntUpdDateColumn.ColumnName];
				orderListResultWork.DirectSendingCd = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.DirectSendingCdColumn.ColumnName];
				orderListResultWork.OrderNumber = (string)orderListResultView[ix][this._dataSet.OrderListResult.OrderNumberColumn.ColumnName];
				orderListResultWork.WayToOrder = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.WayToOrderColumn.ColumnName];
				orderListResultWork.DeliGdsCmpltDueDate = (DateTime)orderListResultView[ix][this._dataSet.OrderListResult.DeliGdsCmpltDueDateColumn.ColumnName];
				orderListResultWork.ExpectDeliveryDate = (DateTime)orderListResultView[ix][this._dataSet.OrderListResult.ExpectDeliveryDateColumn.ColumnName];
				orderListResultWork.OrderCnt = (Double)orderListResultView[ix][this._dataSet.OrderListResult.OrderCntColumn.ColumnName];
				orderListResultWork.OrderAdjustCnt = (Double)orderListResultView[ix][this._dataSet.OrderListResult.OrderAdjustCntColumn.ColumnName];
				orderListResultWork.OrderRemainCnt = (Double)orderListResultView[ix][this._dataSet.OrderListResult.OrderRemainCntColumn.ColumnName];
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                //orderListResultWork.ReconcileFlag = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.ReconcileFlagColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
				orderListResultWork.OrderFormIssuedDiv = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.OrderFormIssuedDivColumn.ColumnName];
				orderListResultWork.OrderDataCreateDate = (DateTime)orderListResultView[ix][this._dataSet.OrderListResult.OrderDataCreateDateColumn.ColumnName];
				orderListResultWork.SlipMemo1 = (string)orderListResultView[ix][this._dataSet.OrderListResult.SlipMemo1Column.ColumnName];
				orderListResultWork.SlipMemo2 = (string)orderListResultView[ix][this._dataSet.OrderListResult.SlipMemo2Column.ColumnName];
				orderListResultWork.SlipMemo3 = (string)orderListResultView[ix][this._dataSet.OrderListResult.SlipMemo3Column.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                //orderListResultWork.SlipMemo4 = (string)orderListResultView[ix][this._dataSet.OrderListResult.SlipMemo4Column.ColumnName];
                //orderListResultWork.SlipMemo5 = (string)orderListResultView[ix][this._dataSet.OrderListResult.SlipMemo5Column.ColumnName];
                //orderListResultWork.SlipMemo6 = (string)orderListResultView[ix][this._dataSet.OrderListResult.SlipMemo6Column.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
				orderListResultWork.InsideMemo1 = (string)orderListResultView[ix][this._dataSet.OrderListResult.InsideMemo1Column.ColumnName];
				orderListResultWork.InsideMemo2 = (string)orderListResultView[ix][this._dataSet.OrderListResult.InsideMemo2Column.ColumnName];
				orderListResultWork.InsideMemo3 = (string)orderListResultView[ix][this._dataSet.OrderListResult.InsideMemo3Column.ColumnName];
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                //orderListResultWork.InsideMemo4 = (string)orderListResultView[ix][this._dataSet.OrderListResult.InsideMemo4Column.ColumnName];
                //orderListResultWork.InsideMemo5 = (string)orderListResultView[ix][this._dataSet.OrderListResult.InsideMemo5Column.ColumnName];
                //orderListResultWork.InsideMemo6 = (string)orderListResultView[ix][this._dataSet.OrderListResult.InsideMemo6Column.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
				orderListResultWork.StockSlipDtlNum = (Int64)orderListResultView[ix][this._dataSet.OrderListResult.StockSlipDtlNumColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
                if ( orderListResultView[ix][this._dataSet.OrderListResult.InputDayColumn.ColumnName] != DBNull.Value )
                {
                    orderListResultWork.InputDay = (DateTime)orderListResultView[ix][this._dataSet.OrderListResult.InputDayColumn.ColumnName];
                }
                else
                {
                    orderListResultWork.InputDay = DateTime.MinValue;
                }
                if ( orderListResultView[ix][this._dataSet.OrderListResult.BLGoodsCodeColumn.ColumnName] != DBNull.Value )
                {
                    orderListResultWork.BLGoodsCode = (Int32)orderListResultView[ix][this._dataSet.OrderListResult.BLGoodsCodeColumn.ColumnName];
                }
                else
                {
                    orderListResultWork.BLGoodsCode = 0;
                }
                orderListResultWork.ListPriceTaxExcFl = (Double)orderListResultView[ix][this._dataSet.OrderListResult.ListPriceTaxExcFlColumn.ColumnName];
                orderListResultWork.StockPriceConsTax = (Int64)orderListResultView[ix][this._dataSet.OrderListResult.StockPriceConsTaxColumn.ColumnName];
                orderListResultWork.SectionGuideNm = (String)orderListResultView[ix][this._dataSet.OrderListResult.SectionGuideNmColumn.ColumnName];
                orderListResultWork.SectionGuideSnm = (String)orderListResultView[ix][this._dataSet.OrderListResult.SectionGuideSnmColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
				#endregion

				orderListResultWorkList.Add(orderListResultWork);
			}

			return orderListResultWorkList;
        }


		# region ■ 行選択チェック編集 ■

		/// <summary>
		/// 選択行取得処理
		/// </summary>
		public int GetSelectedRowCount()
		{
			// データビューを生成して、選択済みフラグでフィルタをかける
			DataView view = new DataView(this._dataSet.OrderListResult);
			view.RowFilter = string.Format("{0} = '{1}'",
												this._dataSet.OrderListResult.SelectFlagColumn.ColumnName, true);
			// 件数を返す
			return view.Count;
		}

		/// <summary>
		/// 行選択チェック処理（bool反転）
		/// </summary>
		/// <param name="rowNo"></param>
		public void SetRowSelected( int rowNo )
		{
			// 行№で検索
			DataRow row = this._dataSet.OrderListResult.Rows.Find(rowNo);
			if (row == null) return;

			// チェック値bool反転セット
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //row[this._dataSet.OrderListResult.SelectFlagColumn.ColumnName] = !(bool)row[this._dataSet.OrderListResult.SelectFlagColumn.ColumnName];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            int currentCount = GetSelectedRowCount();
            bool currentValue = (bool)row[this._dataSet.OrderListResult.SelectFlagColumn.ColumnName];

            if ( currentCount >= this.MaxSelectCount && currentValue == false )
            {
                this.RowChangeStatus = false;
            }
            else
            {
                row[this._dataSet.OrderListResult.SelectFlagColumn.ColumnName] = !currentValue;
                this.RowChangeStatus = true;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

			if (this.SelectedRowChanged != null)
			{
				this.SelectedRowChanged(this, new EventArgs());
			}
		}
		/// <summary>
		/// 行選択チェック処理
		/// </summary>
		/// <param name="rowNo"></param>
		/// <param name="rowSelected"></param>
		public void SetRowSelected( int rowNo, bool rowSelected )
		{
			// 行№で検索
			DataRow row = this._dataSet.OrderListResult.Rows.Find(rowNo);
			if (row == null) return;

			// チェック値セット
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //row[this._dataSet.OrderListResult.SelectFlagColumn.ColumnName] = rowSelected;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            int currentCount = GetSelectedRowCount();

            if ( currentCount >= this.MaxSelectCount && rowSelected == true )
            {
                this.RowChangeStatus = false;
            }
            else
            {
                row[this._dataSet.OrderListResult.SelectFlagColumn.ColumnName] = rowSelected;
                this.RowChangeStatus = true;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

			if (this.SelectedRowChanged != null)
			{
				this.SelectedRowChanged(this, new EventArgs());
			}
		}
		/// <summary>
		/// 全ての行の選択チェックをセット
		/// </summary>
		public void SetRowSelectedAll( bool rowSelected )
		{
			// 全ての行の選択チェックを設定
			foreach (DataRow row in this._dataSet.OrderListResult.Rows)
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                int currentCount = GetSelectedRowCount();

                if ( currentCount >= this.MaxSelectCount && rowSelected == true )
                {
                    this.RowChangeStatus = false;
                    break;
                }
                this.RowChangeStatus = true;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
				row[this._dataSet.OrderListResult.SelectFlagColumn.ColumnName] = rowSelected;
			}

			if (this.SelectedRowChanged != null)
			{
				this.SelectedRowChanged(this, new EventArgs());
			}
		}
		#endregion

		/// <summary>
        /// 従業員名称取得処理
        /// </summary>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns>従業員名称</returns>
        public string GetName_FromEmployee(string employeeCode)
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();
            Employee employee;

            int status = employeeAcs.Read(out employee, this._enterpriseCode, employeeCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return employee.Name.Trim();
            }
            else
            {
                return "";
            }
        }

		/// <summary>
		/// メーカー名称取得処理
		/// </summary>
		/// <param name="employeeCode">従業員コード</param>
		/// <returns>従業員名称</returns>
		public string GetName_FromGoodsMaker(int goodsMakerCd)
		{
			MakerAcs makerAcs = new MakerAcs();
			MakerUMnt makerUMnt;

			int status = makerAcs.Read(out makerUMnt, this._enterpriseCode, goodsMakerCd);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				return makerUMnt.MakerName.Trim();
			}
			else
			{
				return "";
			}
		}

		/// <summary>
        /// 商品名称取得処理
        /// </summary>
        /// <param name="goodsCode">商品コード</param>
        /// <returns>true:存在あり、false:存在しない</returns>
		public bool CheckGoodsExist(string goodsCode, out string goodsName)
        {
            List<GoodsUnitData> goodsUnitDataList;
            GoodsAcs goodsAcs = new GoodsAcs();
			goodsName = "";

            // 商品コードのみの指定で
            int status = goodsAcs.Read(this._enterpriseCode, goodsCode,out goodsUnitDataList);

            if( (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList.Count != 0) )
            {
				goodsName = goodsUnitDataList[0].GoodsName;
                return true;
            }
            else
            {
                return false;
            }
        }

		/// <summary>
        /// 拠点制御アクセスクラスインスタンス化処理
        /// </summary>
        internal void CreateSecInfoAcs()
        {
            if (_secInfoAcs == null)
            {
                _secInfoAcs = new SecInfoAcs();
            }

            // ログイン担当拠点情報の取得
            if (_secInfoAcs.SecInfoSet == null)
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }
        }

        /// <summary>
        /// 本社機能／拠点機能チェック処理
        /// </summary>
        /// <returns>true:本社機能 false:拠点機能</returns>
        public bool IsMainOfficeFunc()
        {
            bool isMainOfficeFunc = false;

            // 拠点制御アクセスクラスインスタンス化処理
            this.CreateSecInfoAcs();

            // ログイン担当拠点情報の取得
            SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

            if (secInfoSet != null)
            {
                // 本社機能か？
                if (secInfoSet.MainOfficeFuncFlag == 1)
                {
                    isMainOfficeFunc = true;
                }
            }
            else
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }

            return isMainOfficeFunc;
        }

		/// <summary>
		/// 日付文字列を取得します。
		/// </summary>
		/// <param name="date">日付</param>
		/// <param name="format">フォーマット文字列</param>
		/// <returns>日付文字列</returns>
		public static string GetDateTimeString(DateTime date, string format)
		{
			if (date == DateTime.MinValue)
			{
				return "";
			}
			else
			{
				return date.ToString(format);
			}
		}
		# endregion

	}
}
