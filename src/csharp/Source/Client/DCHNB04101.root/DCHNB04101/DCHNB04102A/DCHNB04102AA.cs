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
    /// 伝票検索 テーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 伝票検索を行います。</br>
    /// <br>Programmer	: 980023 飯谷　耕平</br>
    /// <br>Date		: 2007.01.29</br>
    /// <br></br>
    /// <br>Update Note : 2010/05/25　22008 長内 数馬</br>
    /// <br>              オフライン対応</br>
    /// <br></br>
    /// <br>Update Note : 2011/11/11 鄧潘ハン Redmine 26539対応</br>
    /// <br>Update Note : 2011/11/16 鄧潘ハン Redmine 26539対応</br>
    /// </remarks>
	public partial class DCHNB04102AA
    {
        # region ■Private Member
        /// <summary>リモートオブジェクト格納バッファ</summary>
        private ISalHisRefDB _iSalHisRefDB = null;
        /// <summary>拠点オプションフラグ</summary>
        private bool _optSection;
		private StockDataSet _dataSet;
		private DataView _salesDetailView;
        private static StockDataSet.SalesDetailDataTable _stockSlipCache;
        private static SalHisRefExtraParamWork _paraStockSlipCache;
        private static SortedList _nameList;
        private static DCHNB04102AA _searchSlipAcs;

        private string _enterpriseCode;             // 企業コード

        private const string MESSAGE_NoResult = "検索条件に一致する伝票は存在しません。";
        private const string MESSAGE_ErrResult = "伝票情報の取得に失敗しました。";
		private const string ct_DateFormat = "yyyy/MM/dd";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
        private int _maxSelectCount; // 最大選択可能行数
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD

        # endregion

        // デリゲート処理
        public event GetNameListEventHandler GetNameList;
        public delegate SortedList GetNameListEventHandler();

        public event SettingStatusBarMessageEventHandler StatusBarMessageSetting;
        public delegate void SettingStatusBarMessageEventHandler(object sender, string message);

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
        // 行選択状態変更イベント
        /// <summary>行選択状態変更イベント</summary>
        public event SelectedDataChangeEventHandler SelectedDataChange;
        public delegate void SelectedDataChangeEventHandler( object sender, bool status, int count );
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD

        # region ■Constracter
        /// <summary>
        /// 伝票検索 テーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品大分類マスタ テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 980023 飯谷  耕平</br>
        /// <br>Date       : 2006.12.04</br>
        /// </remarks>
        public DCHNB04102AA()
        {
            //　企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            
            // 拠点OPの判定
            this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);
            this._dataSet = new StockDataSet();
			this._salesDetailView = new DataView(this._dataSet.SalesDetail);


            //this._stockDetailDBDataList = new List<StockDetail>();
            //this._stockSlipInputAcs = StockSlipInputAcs.GetInstance();

            // ログイン部品で通信状態を確認
            // -- UPD 2010/05/25 --------------------------------->>>
            //if (LoginInfoAcquisition.OnlineFlag)
            //{
            //    try
            //    {
            //        // リモートオブジェクト取得
            //        this._iSalHisRefDB = (ISalHisRefDB)MediationSalHisRefDB.GetSalHisRefDB();
            //    }
            //    catch (Exception)
            //    {
            //        //オフライン時はnullをセット
            //        this._iSalHisRefDB = null;
            //    }
            //}
            //else
            //{
            //    // オフライン時のデータ読み込み
            //    //this.SearchOfflineData();
            //    MessageBox.Show("オフライン状態のため検索が実行できません。");
            //}

            try
            {
                // リモートオブジェクト取得
                this._iSalHisRefDB = (ISalHisRefDB)MediationSalHisRefDB.GetSalHisRefDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iSalHisRefDB = null;
            }
            // -- UPD 2010/05/25 ---------------------------------<<<
        }
        # endregion

        /// <summary>
        /// 伝票検索アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>伝票検索アクセスクラス インスタンス</returns>
        public static DCHNB04102AA GetInstance()
        {
            if (_searchSlipAcs == null)
            {
                _searchSlipAcs = new DCHNB04102AA();
            }

            return _searchSlipAcs;
        }

        /// <summary>
        /// 伝票検索データセット取得処理
        /// </summary>
        /// <returns>伝票検索データセット</returns>
        public StockDataSet DataSet
        {
            get { return this._dataSet; }
        }

		/// <summary>
		/// 売上履歴DataView
		/// </summary>
		public DataView SalesDetailView
		{
			get { return this._salesDetailView; }
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
        /// <summary>
        /// 選択可能明細数 プロパティ
        /// </summary>
        public int MaxSelectCount
        {
            get { return _maxSelectCount; }
            set { _maxSelectCount = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD


        # region ◆public int GetOnlineMode()
        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 980023 飯谷  耕平</br>
        /// <br>Date       : 2006.12.04</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iSalHisRefDB == null)
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
        private void CacheStockSlipTable()
        {
            if (_stockSlipCache == null)
            {
                _stockSlipCache = new StockDataSet.SalesDetailDataTable();
            }

            this._dataSet.SalesDetail.AcceptChanges();
            _stockSlipCache = (StockDataSet.SalesDetailDataTable)this._dataSet.SalesDetail.Copy();
        }

        /// <summary>
        /// 検索条件クラス(再表示用) キャッシュ処理
        /// </summary>
        private void CacheParaStockSlip(SalHisRefExtraParamWork salHisRefExtraParamWork)
        {
            // 検索条件値
            if (_paraStockSlipCache == null)
            {
                _paraStockSlipCache = new SalHisRefExtraParamWork();
            }
            _paraStockSlipCache = salHisRefExtraParamWork;

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

        #endregion



        #region ■Public Method

        /// <summary>
        /// 伝票情報 読込・データセット格納実行処理
        /// </summary>
        /// <param name="ioWriteMASIRReadWork">仕入伝票検索パラメータクラス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 伝票情報を読み込みます。</br>
        /// <br>Programmer : 980023 飯谷  飯谷</br>
        /// <br>Date       : 2007.01.29</br>
        /// <br>Update Note: 2011/11/11 鄧潘ハン BLﾊﾟｰﾂｵｰﾀﾞｰ在庫確認時の見積伝票対応</br>
        /// <br>Update Note: 2011/11/16 鄧潘ハン BLﾊﾟｰﾂｵｰﾀﾞｰ在庫確認時の見積伝票対応</br>
        /// </remarks>
        public int SetSearchData(SalHisRefExtraParamWork salHisRefExtraParamWork)
        {
            List<SalHisRefResultParamWork> retData;
			string salesDateString = "";
			string memoExistName = "";

			string salesGoodsCdString = "";
			string salesSlipCdDtlString = "";
			string acptAnOdrStatusString = "";
            
			long salesMoneyTaxExc = 0;
            long salesPriceConsTax = 0;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
            long salesMoneyTaxInc = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD

            long shipmentLeftCnt = 0;   // 出荷残数
            long salesCost = 0;         // 原価金額
            string modelCategoryNo = "";// 類別形式
            string debitNoteDivStr = "";// 赤伝区分


            int status = this.Search(out retData, salHisRefExtraParamWork);

            this.ClearStockSlipDataTable();

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                for (int i = 0; i < retData.Count; i++)
                {
					SalHisRefResultParamWork salHisRefResultParamWork = retData[i];

					//売上日
					salesDateString = GetDateTimeString(salHisRefResultParamWork.SalesDate, ct_DateFormat);

					//メモ存在
					if((salHisRefResultParamWork.SlipMemo1.Trim() != "")
					|| (salHisRefResultParamWork.SlipMemo2.Trim() != "")
					|| (salHisRefResultParamWork.SlipMemo3.Trim() != "")
					//|| (salHisRefResultParamWork.SlipMemo4.Trim() != "")
					//|| (salHisRefResultParamWork.SlipMemo5.Trim() != "")
					//|| (salHisRefResultParamWork.SlipMemo6.Trim() != "")
					|| (salHisRefResultParamWork.InsideMemo1.Trim() != "")
					|| (salHisRefResultParamWork.InsideMemo2.Trim() != "")
					|| (salHisRefResultParamWork.InsideMemo3.Trim() != "")
					//|| (salHisRefResultParamWork.InsideMemo4.Trim() != "")
					//|| (salHisRefResultParamWork.InsideMemo5.Trim() != "")
					//|| (salHisRefResultParamWork.InsideMemo6.Trim() != "")
                        )
					{
						memoExistName = "○";
					}
					else
					{
						memoExistName = "";
					}

					// 商品区分
					// 0:商品, 1:商品外, 2:消費税調整, 3:残高調整, 4:売掛用消費税調整, 5:売掛用残高調整
					switch (salHisRefResultParamWork.SalesGoodsCd)
					{
						case 0: salesGoodsCdString = "商品"; break;
						case 1: salesGoodsCdString = "商品外"; break;
						case 2: salesGoodsCdString = "消費税調整"; break;
						case 3: salesGoodsCdString = "残高調整"; break;
						case 4: salesGoodsCdString = "売掛用消費税調整"; break;
						case 5: salesGoodsCdString = "売掛用残高調整"; break;
						default: salesGoodsCdString = ""; break;
					}

					// 伝票区分
                    // 0:売上, 1:返品, 2:値引, 3:注釈, 4:小計, 5:作業, 9:一式
					switch (salHisRefResultParamWork.SalesSlipCdDtl)
					{
						case 0: salesSlipCdDtlString = "売上"; break;
						case 1: salesSlipCdDtlString = "返品"; break;
						case 2: salesSlipCdDtlString = "値引"; break;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                        case 3: salesSlipCdDtlString = "注釈"; break;
                        case 4: salesSlipCdDtlString = "小計"; break;
                        case 5: salesSlipCdDtlString = "作業"; break;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
						case 9: salesSlipCdDtlString = "一式"; break;
						default: salesSlipCdDtlString = ""; break;
					}

					// 伝票区分
					// 10:見積, 20:受注, 30:売上, 40:出荷
					switch (salHisRefResultParamWork.AcptAnOdrStatus)
					{
                        case 10: acptAnOdrStatusString = "見積"; break;
						case 20: acptAnOdrStatusString = "受注"; break;
						case 30: acptAnOdrStatusString = "売上"; break;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
                        //case 40: acptAnOdrStatusString = "出荷"; break;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
                        case 40: acptAnOdrStatusString = "貸出"; break;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
						default: acptAnOdrStatusString = ""; break;
					}

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
                    ////消費税調整・残高調整
                    //if ((salHisRefResultParamWork.SalesGoodsCd == 2) || (salHisRefResultParamWork.SalesGoodsCd == 4))
                    //{
                    //    salesMoneyTaxExc = 0;
                    //    //salesPriceConsTax = salHisRefResultParamWork.SalesPriceConsTax;
                    //    salesPriceConsTax = salHisRefResultParamWork.SalesMoneyTaxInc - salHisRefResultParamWork.SalesMoneyTaxExc;
                    //}
                    //else if ((salHisRefResultParamWork.SalesGoodsCd == 3) || (salHisRefResultParamWork.SalesGoodsCd == 5))
                    //{
                    //    salesMoneyTaxExc = salHisRefResultParamWork.SalesMoneyTaxInc;
                    //    salesPriceConsTax = 0;
                    //}
                    //else
                    //{
                    //    salesMoneyTaxExc = salHisRefResultParamWork.SalesMoneyTaxExc;
                    //    //salsePriceConsTax = salHisRefResultParamWork.SalsePriceConsTax;
                    //    salesPriceConsTax = salHisRefResultParamWork.SalesMoneyTaxInc - salHisRefResultParamWork.SalesMoneyTaxExc;
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
                    //// 出荷残数
                    //shipmentLeftCnt = long.Parse( (salHisRefResultParamWork.ShipmentCnt - salHisRefResultParamWork.CmpltShipmentCnt).ToString() );

                    //// 原価金額 (原価単価 * 売上数)
                    //salesCost = long.Parse( (salHisRefResultParamWork.SalesUnitCost * salHisRefResultParamWork.ShipmentCnt).ToString() );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
                    // 出荷残数
                    shipmentLeftCnt = (long)(salHisRefResultParamWork.ShipmentCnt - salHisRefResultParamWork.CmpltShipmentCnt);

                    // 原価金額 (原価単価 * 売上数)
                    //salesCost = (long)(salHisRefResultParamWork.SalesUnitCost * salHisRefResultParamWork.ShipmentCnt);
                    salesCost = (long)Math.Floor(salHisRefResultParamWork.SalesUnitCost * salHisRefResultParamWork.ShipmentCnt + 0.5);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
                    //// 類別形式
                    //modelCategoryNo = salHisRefResultParamWork.ModelDesignationNo.ToString().PadLeft(5, '0') + "-" + salHisRefResultParamWork.CategoryNo.ToString().PadLeft(4, '0');
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
                    // 類別形式
                    if ( salHisRefResultParamWork.ModelDesignationNo == 0 && salHisRefResultParamWork.CategoryNo == 0 )
                    {
                        modelCategoryNo = string.Empty;
                    }
                    else
                    {
                        modelCategoryNo = salHisRefResultParamWork.ModelDesignationNo.ToString().PadLeft( 5, '0' ) + "-" + salHisRefResultParamWork.CategoryNo.ToString().PadLeft( 4, '0' );
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD

                    // 赤伝区分
                    // 0:黒伝, 1:赤伝, 2:元黒
            		switch (salHisRefResultParamWork.DebitNoteDiv)
                    {
                        case 0: debitNoteDivStr = "黒伝"; break;
                        case 1: debitNoteDivStr = "赤伝"; break;
                        case 2: debitNoteDivStr = "元黒"; break;
                        default: debitNoteDivStr = ""; break;
                    }
                    
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                    # region // DEL
                    //_dataSet.SalesDetail.AddSalesDetailRow(i + 1, 
                    //                                    false,
                    //                                    salHisRefResultParamWork.EnterpriseCode,
                    //                                    salHisRefResultParamWork.LogicalDeleteCode,
                    //                                    salHisRefResultParamWork.AcceptAnOrderNo,
                    //                                    salHisRefResultParamWork.AcptAnOdrStatus,
                    //                                    acptAnOdrStatusString,//salHisRefResultParamWork.AcptAnOdrStatusString
                    //                                    salHisRefResultParamWork.SalesSlipNum,
                    //                                    salHisRefResultParamWork.SalesRowNo,
                    //                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                    //                                    salHisRefResultParamWork.SalesRowDerivNo,
                    //                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                    //                                    salHisRefResultParamWork.SectionCode,
                    //                                    salHisRefResultParamWork.SectionGuideNm,
                    //                                    salHisRefResultParamWork.SubSectionCode,
                    //                                    salHisRefResultParamWork.SubSectionName,
                    //                                    //salHisRefResultParamWork.MinSectionCode,
                    //                                    salHisRefResultParamWork.SalesDate,
                    //                                    salesDateString,
                    //                                    salHisRefResultParamWork.CommonSeqNo,
                    //                                    salHisRefResultParamWork.SalesSlipDtlNum,
                    //                                    salHisRefResultParamWork.AcptAnOdrStatusSrc,
                    //                                    salHisRefResultParamWork.SalesSlipDtlNumSrc,
                    //                                    salHisRefResultParamWork.SupplierFormalSync,
                    //                                    salHisRefResultParamWork.StockSlipDtlNumSync,
                    //                                    salHisRefResultParamWork.SalesSlipCdDtl,
                    //                                    //salHisRefResultParamWork.ServiceSlipCd,
                    //                                    //salHisRefResultParamWork.SalesDepositsDiv,
                    //                                    //salHisRefResultParamWork.StockMngExistCd,
                    //                                    salHisRefResultParamWork.GoodsKindCode,
                    //                                    salHisRefResultParamWork.GoodsMakerCd,
                    //                                    salHisRefResultParamWork.MakerName,
                    //                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                    //                                    salHisRefResultParamWork.MakerKanaName,
                    //                                    salHisRefResultParamWork.CmpltMakerKanaName,
                    //                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                    //                                    salHisRefResultParamWork.GoodsNo,
                    //                                    salHisRefResultParamWork.GoodsName,
                    //                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                    //                                    salHisRefResultParamWork.GoodsNameKana,
                    //                                    salHisRefResultParamWork.GoodsLGroup,
                    //                                    salHisRefResultParamWork.GoodsLGroupName,
                    //                                    salHisRefResultParamWork.GoodsMGroup,
                    //                                    salHisRefResultParamWork.GoodsMGroupName,
                    //                                    salHisRefResultParamWork.BLGroupCode,
                    //                                    salHisRefResultParamWork.BLGroupName,
                    //                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                    //                                    //salHisRefResultParamWork.GoodsSetDivCd,
                    //                                    //salHisRefResultParamWork.LargeGoodsGanreCode,
                    //                                    //salHisRefResultParamWork.LargeGoodsGanreName,
                    //                                    //salHisRefResultParamWork.MediumGoodsGanreCode,
                    //                                    //salHisRefResultParamWork.MediumGoodsGanreName,
                    //                                    //salHisRefResultParamWork.DetailGoodsGanreCode,
                    //                                    //salHisRefResultParamWork.DetailGoodsGanreName,
                    //                                    salHisRefResultParamWork.BLGoodsCode,
                    //                                    salHisRefResultParamWork.BLGoodsFullName,
                    //                                    salHisRefResultParamWork.EnterpriseGanreCode,
                    //                                    salHisRefResultParamWork.EnterpriseGanreName,
                    //                                    salHisRefResultParamWork.WarehouseCode,
                    //                                    salHisRefResultParamWork.WarehouseName,
                    //                                    salHisRefResultParamWork.WarehouseShelfNo,
                    //                                    salHisRefResultParamWork.SalesOrderDivCd,
                    //                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                    //                                    salHisRefResultParamWork.OpenPriceDiv,
                    //                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                    //                                    //salHisRefResultParamWork.UnitCode,
                    //                                    //salHisRefResultParamWork.UnitName,
                    //                                    salHisRefResultParamWork.GoodsRateRank,
                    //                                    salHisRefResultParamWork.CustRateGrpCode,
                    //                                    //salHisRefResultParamWork.SuppRateGrpCode,
                    //                                    salHisRefResultParamWork.ListPriceRate,
                    //                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                    //                                    salHisRefResultParamWork.RateSectPriceUnPrc,
                    //                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                    //                                    salHisRefResultParamWork.RateDivLPrice,
                    //                                    salHisRefResultParamWork.UnPrcCalcCdLPrice,
                    //                                    salHisRefResultParamWork.PriceCdLPrice,
                    //                                    salHisRefResultParamWork.StdUnPrcLPrice,
                    //                                    salHisRefResultParamWork.FracProcUnitLPrice,
                    //                                    salHisRefResultParamWork.FracProcLPrice,
                    //                                    salHisRefResultParamWork.ListPriceTaxIncFl,
                    //                                    salHisRefResultParamWork.ListPriceTaxExcFl,
                    //                                    salHisRefResultParamWork.ListPriceChngCd,
                    //                                    salHisRefResultParamWork.SalesRate,
                    //                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                    //                                    salHisRefResultParamWork.RateSectSalUnPrc,
                    //                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                    //                                    salHisRefResultParamWork.RateDivSalUnPrc,
                    //                                    salHisRefResultParamWork.UnPrcCalcCdSalUnPrc,
                    //                                    salHisRefResultParamWork.PriceCdSalUnPrc,
                    //                                    salHisRefResultParamWork.StdUnPrcSalUnPrc,
                    //                                    salHisRefResultParamWork.FracProcUnitSalUnPrc,
                    //                                    salHisRefResultParamWork.FracProcSalUnPrc,
                    //                                    salHisRefResultParamWork.SalesUnPrcTaxIncFl,
                    //                                    salHisRefResultParamWork.SalesUnPrcTaxExcFl,
                    //                                    salHisRefResultParamWork.SalesUnPrcChngCd,
                    //                                    salHisRefResultParamWork.CostRate,
                    //                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                    //                                    salHisRefResultParamWork.RateSectCstUnPrc,
                    //                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                    //                                    salHisRefResultParamWork.RateDivUnCst,
                    //                                    salHisRefResultParamWork.UnPrcCalcCdUnCst,
                    //                                    salHisRefResultParamWork.PriceCdUnCst,
                    //                                    salHisRefResultParamWork.StdUnPrcUnCst,
                    //                                    salHisRefResultParamWork.FracProcUnitUnCst,
                    //                                    salHisRefResultParamWork.FracProcUnCst,
                    //                                    salHisRefResultParamWork.SalesUnitCost,
                    //                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                    //                                    salesCost,
                    //                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                    //                                    salHisRefResultParamWork.SalesUnitCostChngDiv,
                    //                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                    //                                    salHisRefResultParamWork.RateBLGoodsCode,
                    //                                    salHisRefResultParamWork.RateBLGoodsName,
                    //                                    salHisRefResultParamWork.PrtBLGoodsCode,
                    //                                    salHisRefResultParamWork.PrtBLGoodsName,
                    //                                    salHisRefResultParamWork.SalesCode,
                    //                                    salHisRefResultParamWork.SalesCdNm,
                    //                                    salHisRefResultParamWork.WorkManHour,
                    //                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                    //                                    //salHisRefResultParamWork.BargainCd,
                    //                                    //salHisRefResultParamWork.BargainNm,
                    //                                    salHisRefResultParamWork.ShipmentCnt,
                    //                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                    //                                    shipmentLeftCnt,
                    //                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                    //                                    salHisRefResultParamWork.SalesMoneyTaxInc,
                    //                                    salesMoneyTaxExc,
                    //                                    salHisRefResultParamWork.Cost,
                    //                                    salHisRefResultParamWork.GrsProfitChkDiv,
                    //                                    salHisRefResultParamWork.SalesGoodsCd,
                    //                                    salesPriceConsTax,
                    //                                    //salHisRefResultParamWork.TaxAdjust,
                    //                                    //salHisRefResultParamWork.BalanceAdjust,
                    //                                    salHisRefResultParamWork.TaxationDivCd,
                    //                                    salHisRefResultParamWork.PartySlipNumDtl,
                    //                                    salHisRefResultParamWork.DtlNote,
                    //                                    salHisRefResultParamWork.SupplierCd,
                    //                                    salHisRefResultParamWork.SupplierSnm,
                    //                                    //salHisRefResultParamWork.ResultsAddUpSecCd,
                    //                                    salHisRefResultParamWork.OrderNumber,
                    //                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                    //                                    salHisRefResultParamWork.WayToOrder,
                    //                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                    //                                    salHisRefResultParamWork.SlipMemo1,
                    //                                    salHisRefResultParamWork.SlipMemo2,
                    //                                    salHisRefResultParamWork.SlipMemo3,
                    //                                    //salHisRefResultParamWork.SlipMemo4,
                    //                                    //salHisRefResultParamWork.SlipMemo5,
                    //                                    //salHisRefResultParamWork.SlipMemo6,
                    //                                    salHisRefResultParamWork.InsideMemo1,
                    //                                    salHisRefResultParamWork.InsideMemo2,
                    //                                    salHisRefResultParamWork.InsideMemo3,
                    //                                    //salHisRefResultParamWork.InsideMemo4,
                    //                                    //salHisRefResultParamWork.InsideMemo5,
                    //                                    //salHisRefResultParamWork.InsideMemo6,
                    //                                    salHisRefResultParamWork.BfListPrice,
                    //                                    salHisRefResultParamWork.BfSalesUnitPrice,
                    //                                    salHisRefResultParamWork.BfUnitCost,
                    //                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                    //                                    salHisRefResultParamWork.CmpltSalesRowNo,
                    //                                    salHisRefResultParamWork.CmpltGoodsMakerCd,
                    //                                    salHisRefResultParamWork.CmpltMakerName,
                    //                                    salHisRefResultParamWork.CmpltGoodsName,
                    //                                    salHisRefResultParamWork.CmpltShipmentCnt,
                    //                                    salHisRefResultParamWork.CmpltSalesUnPrcFl,
                    //                                    salHisRefResultParamWork.CmpltSalesMoney,
                    //                                    salHisRefResultParamWork.CmpltSalesUnitCost,
                    //                                    salHisRefResultParamWork.CmpltCost,
                    //                                    salHisRefResultParamWork.CmpltPartySalSlNum,
                    //                                    salHisRefResultParamWork.CmpltNote,
                    //                                    salHisRefResultParamWork.CarMngCode,
                    //                                    salHisRefResultParamWork.ModelDesignationNo,
                    //                                    salHisRefResultParamWork.CategoryNo,
                    //                                    modelCategoryNo,
                    //                                    salHisRefResultParamWork.MakerFullName,
                    //                                    salHisRefResultParamWork.FullModel,
                    //                                    salHisRefResultParamWork.ModelFullName,
                    //                                    salHisRefResultParamWork.SearchSlipDate,
                    //                                    salHisRefResultParamWork.ShipmentDay,
                    //                                    salHisRefResultParamWork.AddUpADate,
                    //                                    salHisRefResultParamWork.InputAgenCd,
                    //                                    salHisRefResultParamWork.InputAgenNm,
                    //                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                    //                                    //salHisRefResultParamWork.PrtGoodsNo,
                    //                                    //salHisRefResultParamWork.PrtGoodsName,
                    //                                    //salHisRefResultParamWork.PrtGoodsMakerCd,
                    //                                    //salHisRefResultParamWork.PrtGoodsMakerNm,
                    //                                    salHisRefResultParamWork.SalesInputCode,
                    //                                    salHisRefResultParamWork.SalesInputName,
                    //                                    salHisRefResultParamWork.FrontEmployeeCd,
                    //                                    salHisRefResultParamWork.FrontEmployeeNm,
                    //                                    salHisRefResultParamWork.SalesEmployeeCd,
                    //                                    salHisRefResultParamWork.SalesEmployeeNm,
                    //                                    //salHisRefResultParamWork.MinSectionName,
                    //                                    //salHisRefResultParamWork.SalesSlipCd,
                    //                                    //salHisRefResultParamWork.AccRecDivCd,
                    //                                    salHisRefResultParamWork.ClaimCode,
                    //                                    salHisRefResultParamWork.ClaimSnm,
                    //                                    salesGoodsCdString,	//SalesGoodsCdString
                    //                                    salesSlipCdDtlString, //SalesGoodsCdString
                    //                                    salHisRefResultParamWork.CustomerCode,
                    //                                    //salHisRefResultParamWork.CustomerName,
                    //                                    //salHisRefResultParamWork.CustomerName2,
                    //                                    salHisRefResultParamWork.CustomerSnm,
                    //                                    salHisRefResultParamWork.AddresseeCode,
                    //                                    salHisRefResultParamWork.AddresseeName,
                    //                                    salHisRefResultParamWork.AddresseeName2,
                    //                                    memoExistName,
                    //                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.23 TOKUNAGA ADD START
                    //                                    salHisRefResultParamWork.DebitNoteDiv,
                    //                                    debitNoteDivStr,
                    //                                    salHisRefResultParamWork.AcptAnOdrRemainCnt,
                    //                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.23 TOKUNAGA ADD END
                    //                                    0
                    //                                   );
                    # endregion
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
                    // 消費税表示対応

                    salesMoneyTaxExc = salHisRefResultParamWork.SalesMoneyTaxExc;
                    salesPriceConsTax = salHisRefResultParamWork.SalesMoneyTaxInc - salHisRefResultParamWork.SalesMoneyTaxExc;
                    salesMoneyTaxInc = salHisRefResultParamWork.SalesMoneyTaxInc;

                    // 設定適用（消費税表示対応）
                    ReflectMoneyForTaxPrint( ref salesMoneyTaxExc, ref salesPriceConsTax, ref salesMoneyTaxInc, salHisRefResultParamWork.TotalAmountDispWayCd, salHisRefResultParamWork.ConsTaxLayMethod, salHisRefResultParamWork.TaxationDivCd );

                    # region [売上商品区分]
                    switch ( salHisRefResultParamWork.SalesGoodsCd )
                    {
                        case 2:
                        case 4:
                            // 2:消費税調整,4:売掛用消費税調整
                            salesMoneyTaxExc = 0;
                            break;
                        case 3:
                        case 5:
                            // 3:残高調整,5:売掛用残高調整
                            salesMoneyTaxExc = salesMoneyTaxInc;
                            salesPriceConsTax = 0;
                            break;
                        default:
                            break;
                    }
                    # endregion

                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                    StockDataSet.SalesDetailRow row = _dataSet.SalesDetail.NewSalesDetailRow();

                    # region [row]
                    row.EnterpriseCode = salHisRefResultParamWork.EnterpriseCode;
                    row.LogicalDeleteCode = salHisRefResultParamWork.LogicalDeleteCode;
                    row.AcceptAnOrderNo = salHisRefResultParamWork.AcceptAnOrderNo;
                    row.AcptAnOdrStatus = salHisRefResultParamWork.AcptAnOdrStatus;
                    row.SalesSlipNum = salHisRefResultParamWork.SalesSlipNum;
                    row.SalesRowNo = salHisRefResultParamWork.SalesRowNo;
                    row.SalesRowDerivNo = salHisRefResultParamWork.SalesRowDerivNo;
                    row.SectionCode = salHisRefResultParamWork.SectionCode;
                    row.SectionGuideNm = salHisRefResultParamWork.SectionGuideNm;
                    row.SubSectionCode = salHisRefResultParamWork.SubSectionCode;
                    row.SubSectionName = salHisRefResultParamWork.SubSectionName;
                    row.SalesDate = salHisRefResultParamWork.SalesDate;
                    row.CommonSeqNo = salHisRefResultParamWork.CommonSeqNo;
                    row.SalesSlipDtlNum = salHisRefResultParamWork.SalesSlipDtlNum;
                    row.AcptAnOdrStatusSrc = salHisRefResultParamWork.AcptAnOdrStatusSrc;
                    row.SalesSlipDtlNumSrc = salHisRefResultParamWork.SalesSlipDtlNumSrc;
                    row.SupplierFormalSync = salHisRefResultParamWork.SupplierFormalSync;
                    row.StockSlipDtlNumSync = salHisRefResultParamWork.StockSlipDtlNumSync;
                    row.SalesSlipCdDtl = salHisRefResultParamWork.SalesSlipCdDtl;
                    row.GoodsKindCode = salHisRefResultParamWork.GoodsKindCode;
                    row.GoodsMakerCd = salHisRefResultParamWork.GoodsMakerCd;
                    row.MakerName = salHisRefResultParamWork.MakerName;
                    row.MakerKanaName = salHisRefResultParamWork.MakerKanaName;
                    row.CmpltMakerKanaName = salHisRefResultParamWork.CmpltMakerKanaName;
                    row.GoodsNo = salHisRefResultParamWork.GoodsNo;
                    row.GoodsName = salHisRefResultParamWork.GoodsName;
                    row.GoodsNameKana = salHisRefResultParamWork.GoodsNameKana;
                    row.GoodsLGroup = salHisRefResultParamWork.GoodsLGroup;
                    row.GoodsLGroupName = salHisRefResultParamWork.GoodsLGroupName;
                    row.GoodsMGroup = salHisRefResultParamWork.GoodsMGroup;
                    row.GoodsMGroupName = salHisRefResultParamWork.GoodsMGroupName;
                    row.BLGroupCode = salHisRefResultParamWork.BLGroupCode;
                    row.BLGroupName = salHisRefResultParamWork.BLGroupName;
                    row.BLGoodsCode = salHisRefResultParamWork.BLGoodsCode;
                    row.BLGoodsFullName = salHisRefResultParamWork.BLGoodsFullName;
                    row.EnterpriseGanreCode = salHisRefResultParamWork.EnterpriseGanreCode;
                    row.EnterpriseGanreName = salHisRefResultParamWork.EnterpriseGanreName;
                    row.WarehouseCode = salHisRefResultParamWork.WarehouseCode;
                    row.WarehouseName = salHisRefResultParamWork.WarehouseName;
                    row.WarehouseShelfNo = salHisRefResultParamWork.WarehouseShelfNo;
                    row.SalesOrderDivCd = salHisRefResultParamWork.SalesOrderDivCd;
                    row.OpenPriceDiv = salHisRefResultParamWork.OpenPriceDiv;
                    row.GoodsRateRank = salHisRefResultParamWork.GoodsRateRank;
                    row.CustRateGrpCode = salHisRefResultParamWork.CustRateGrpCode;
                    row.ListPriceRate = salHisRefResultParamWork.ListPriceRate;
                    row.RateSectPriceUnPrc = salHisRefResultParamWork.RateSectPriceUnPrc;
                    row.RateDivLPrice = salHisRefResultParamWork.RateDivLPrice;
                    row.UnPrcCalcCdLPrice = salHisRefResultParamWork.UnPrcCalcCdLPrice;
                    row.PriceCdLPrice = salHisRefResultParamWork.PriceCdLPrice;
                    row.StdUnPrcLPrice = salHisRefResultParamWork.StdUnPrcLPrice;
                    row.FracProcUnitLPrice = salHisRefResultParamWork.FracProcUnitLPrice;
                    row.FracProcLPrice = salHisRefResultParamWork.FracProcLPrice;
                    row.ListPriceTaxIncFl = salHisRefResultParamWork.ListPriceTaxIncFl;
                    row.ListPriceTaxExcFl = salHisRefResultParamWork.ListPriceTaxExcFl;
                    row.ListPriceChngCd = salHisRefResultParamWork.ListPriceChngCd;
                    row.SalesRate = salHisRefResultParamWork.SalesRate;
                    row.RateSectSalUnPrc = salHisRefResultParamWork.RateSectSalUnPrc;
                    row.RateDivSalUnPrc = salHisRefResultParamWork.RateDivSalUnPrc;
                    row.UnPrcCalcCdSalUnPrc = salHisRefResultParamWork.UnPrcCalcCdSalUnPrc;
                    row.PriceCdSalUnPrc = salHisRefResultParamWork.PriceCdSalUnPrc;
                    row.StdUnPrcSalUnPrc = salHisRefResultParamWork.StdUnPrcSalUnPrc;
                    row.FracProcUnitSalUnPrc = salHisRefResultParamWork.FracProcUnitSalUnPrc;
                    row.FracProcSalUnPrc = salHisRefResultParamWork.FracProcSalUnPrc;
                    row.SalesUnPrcTaxIncFl = salHisRefResultParamWork.SalesUnPrcTaxIncFl;
                    row.SalesUnPrcTaxExcFl = salHisRefResultParamWork.SalesUnPrcTaxExcFl;
                    row.SalesUnPrcChngCd = salHisRefResultParamWork.SalesUnPrcChngCd;
                    row.CostRate = salHisRefResultParamWork.CostRate;
                    row.RateSectCstUnPrc = salHisRefResultParamWork.RateSectCstUnPrc;
                    row.RateDivUnCst = salHisRefResultParamWork.RateDivUnCst;
                    row.UnPrcCalcCdUnCst = salHisRefResultParamWork.UnPrcCalcCdUnCst;
                    row.PriceCdUnCst = salHisRefResultParamWork.PriceCdUnCst;
                    row.StdUnPrcUnCst = salHisRefResultParamWork.StdUnPrcUnCst;
                    row.FracProcUnitUnCst = salHisRefResultParamWork.FracProcUnitUnCst;
                    row.FracProcUnCst = salHisRefResultParamWork.FracProcUnCst;
                    row.SalesUnitCost = salHisRefResultParamWork.SalesUnitCost;
                    row.SalesUnitCostChngDiv = salHisRefResultParamWork.SalesUnitCostChngDiv;
                    row.RateBLGoodsCode = salHisRefResultParamWork.RateBLGoodsCode;
                    row.RateBLGoodsName = salHisRefResultParamWork.RateBLGoodsName;
                    row.PrtBLGoodsCode = salHisRefResultParamWork.PrtBLGoodsCode;
                    row.PrtBLGoodsName = salHisRefResultParamWork.PrtBLGoodsName;
                    row.SalesCode = salHisRefResultParamWork.SalesCode;
                    row.SalesCdNm = salHisRefResultParamWork.SalesCdNm;
                    row.WorkManHour = salHisRefResultParamWork.WorkManHour;
                    row.ShipmentCnt = salHisRefResultParamWork.ShipmentCnt;
                    row.Cost = salHisRefResultParamWork.Cost;
                    row.GrsProfitChkDiv = salHisRefResultParamWork.GrsProfitChkDiv;
                    row.SalesGoodsCd = salHisRefResultParamWork.SalesGoodsCd;
                    row.TaxationDivCd = salHisRefResultParamWork.TaxationDivCd;
                    row.PartySlipNumDtl = salHisRefResultParamWork.PartySlipNumDtl;
                    row.DtlNote = salHisRefResultParamWork.DtlNote;
                    row.SupplierCd = salHisRefResultParamWork.SupplierCd;
                    row.SupplierSnm = salHisRefResultParamWork.SupplierSnm;
                    row.OrderNumber = salHisRefResultParamWork.OrderNumber;
                    row.WayToOrder = salHisRefResultParamWork.WayToOrder;
                    row.SlipMemo1 = salHisRefResultParamWork.SlipMemo1;
                    row.SlipMemo2 = salHisRefResultParamWork.SlipMemo2;
                    row.SlipMemo3 = salHisRefResultParamWork.SlipMemo3;
                    row.InsideMemo1 = salHisRefResultParamWork.InsideMemo1;
                    row.InsideMemo2 = salHisRefResultParamWork.InsideMemo2;
                    row.InsideMemo3 = salHisRefResultParamWork.InsideMemo3;
                    row.BfListPrice = salHisRefResultParamWork.BfListPrice;
                    row.BfSalesUnitPrice = salHisRefResultParamWork.BfSalesUnitPrice;
                    row.BfUnitCost = salHisRefResultParamWork.BfUnitCost;
                    row.CmpltSalesRowNo = salHisRefResultParamWork.CmpltSalesRowNo;
                    row.CmpltGoodsMakerCd = salHisRefResultParamWork.CmpltGoodsMakerCd;
                    row.CmpltMakerName = salHisRefResultParamWork.CmpltMakerName;
                    row.CmpltGoodsName = salHisRefResultParamWork.CmpltGoodsName;
                    row.CmpltShipmentCnt = salHisRefResultParamWork.CmpltShipmentCnt;
                    row.CmpltSalesUnPrcFl = salHisRefResultParamWork.CmpltSalesUnPrcFl;
                    row.CmpltSalesMoney = salHisRefResultParamWork.CmpltSalesMoney;
                    row.CmpltSalesUnitCost = salHisRefResultParamWork.CmpltSalesUnitCost;
                    row.CmpltCost = salHisRefResultParamWork.CmpltCost;
                    row.CmpltPartySalSlNum = salHisRefResultParamWork.CmpltPartySalSlNum;
                    row.CmpltNote = salHisRefResultParamWork.CmpltNote;
                    row.CarMngCode = salHisRefResultParamWork.CarMngCode;
                    row.ModelDesignationNo = salHisRefResultParamWork.ModelDesignationNo;
                    row.CategoryNo = salHisRefResultParamWork.CategoryNo;
                    row.MakerFullName = salHisRefResultParamWork.MakerFullName;
                    row.FullModel = salHisRefResultParamWork.FullModel;
                    row.ModelFullName = salHisRefResultParamWork.ModelFullName;
                    row.SearchSlipDate = salHisRefResultParamWork.SearchSlipDate;
                    // 2008.11.10 add start [7541]
                    if (salHisRefResultParamWork.ShipmentDay != DateTime.MinValue)
                    {
                        row.ShipmentDay = salHisRefResultParamWork.ShipmentDay;
                    }
                    if (salHisRefResultParamWork.AddUpADate != DateTime.MinValue)
                    {
                        row.AddUpADate = salHisRefResultParamWork.AddUpADate;
                    }
                    // 2008.11.10 add end [7541]
                    row.InputAgenCd = salHisRefResultParamWork.InputAgenCd;
                    row.InputAgenNm = salHisRefResultParamWork.InputAgenNm;
                    row.SalesInputCode = salHisRefResultParamWork.SalesInputCode;
                    row.SalesInputName = salHisRefResultParamWork.SalesInputName;
                    row.FrontEmployeeCd = salHisRefResultParamWork.FrontEmployeeCd;
                    row.FrontEmployeeNm = salHisRefResultParamWork.FrontEmployeeNm;
                    row.SalesEmployeeCd = salHisRefResultParamWork.SalesEmployeeCd;
                    row.SalesEmployeeNm = salHisRefResultParamWork.SalesEmployeeNm;
                    row.ClaimCode = salHisRefResultParamWork.ClaimCode;
                    row.ClaimSnm = salHisRefResultParamWork.ClaimSnm;
                    row.CustomerCode = salHisRefResultParamWork.CustomerCode;
                    row.CustomerSnm = salHisRefResultParamWork.CustomerSnm;
                    row.AddresseeCode = salHisRefResultParamWork.AddresseeCode;
                    row.AddresseeName = salHisRefResultParamWork.AddresseeName;
                    row.AddresseeName2 = salHisRefResultParamWork.AddresseeName2;
                    row.DebitNoteDiv = salHisRefResultParamWork.DebitNoteDiv;
                    row.AcptAnOdrRemainCnt = salHisRefResultParamWork.AcptAnOdrRemainCnt;
                    //---ADD 2011/11/11 ------------------------------------------------------------->>>>>
                    //連携種別
                    if (salHisRefResultParamWork.AcceptOrOrderKind == 0)
                    {
                        row.CooprtKind = "PCCforNS";
                    }
                    else if (salHisRefResultParamWork.AcceptOrOrderKind == 1)
                    {
                        row.CooprtKind = "BLﾊﾟｰﾂｵｰﾀﾞｰ";
                    }
                    else
                    {
                        row.CooprtKind = "通常";
                    }

                    //自動回答
                    if (salHisRefResultParamWork.AutoAnswerDivSCM == 0)
                    {
                        row.AutoAnswer = "通常";
                        row.CooprtKind = "通常"; // ADD 2011/11/16
                    }
                    else if (salHisRefResultParamWork.AutoAnswerDivSCM == 1)
                    {
                        row.AutoAnswer = "手動回答";
                    }
                    else if (salHisRefResultParamWork.AutoAnswerDivSCM == 2)
                    {
                        row.AutoAnswer = "自動回答";
                    }
                    //---ADD 2011/11/11 -------------------------------------------------------------<<<<<
                  
                    # endregion

                    # region [row(手動)]
                    row.No = i + 1;
                    row.PrintFlag = false;
                    row.AcptAnOdrStatusString = acptAnOdrStatusString;
                    row.SalesDateString = salesDateString;
                    row.SalesCost = salesCost;
                    row.ShipmentLeftCnt = shipmentLeftCnt;
                    row.SalesMoneyTaxExc = salesMoneyTaxExc;
                    row.SalesPriceConsTax = salesPriceConsTax;
                    row.SalesMoneyTaxInc = salesMoneyTaxInc;
                    row.ModelCategoryNo = modelCategoryNo;
                    row.SalesGoodsCdString = salesGoodsCdString;
                    row.SalesSlipCdDtlString = salesSlipCdDtlString;
                    row.MemoExistName = memoExistName;
                    row.DebitNoteDivString = debitNoteDivStr;
                    row.NoForDisp = 0;
                    # endregion

                    _dataSet.SalesDetail.AddSalesDetailRow( row );

                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

				}

                // 検索データのキャッシュ
                this.CacheStockSlipTable();

                // 検索条件のキャッシュ
                this.CacheParaStockSlip(salHisRefExtraParamWork);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/24 ADD
                // 表示用№セット
                int noForDisp = 1;
                foreach (DataRowView rowView in this.SalesDetailView)
                {
                    rowView[_dataSet.SalesDetail.NoForDispColumn.ColumnName] = noForDisp++;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/24 ADD

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
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
        /// <summary>
        /// 金額取得処理（消費税印刷対応）
        /// </summary>
        /// <param name="moneyTaxExc"></param>
        /// <param name="priceConsTax"></param>
        /// <param name="moneyTaxInc"></param>
        /// <param name="totalAmountDispWayCd"></param>
        /// <param name="consTaxLayMethod"></param>
        /// <param name="taxationDivCd"></param>
        private static void ReflectMoneyForTaxPrint( ref long moneyTaxExc, ref long priceConsTax, ref long moneyTaxInc, int totalAmountDispWayCd, int consTaxLayMethod, int taxationDivCd )
        {
            bool printTax;

            # region [printTax]
            switch ( GetTaxPrintType( totalAmountDispWayCd, consTaxLayMethod ) )
            {
                case 0:
                default:
                    {
                        // 伝票単位（明細毎の消費税は表示しない）
                        printTax = false;
                    }
                    break;
                case 1:
                    {
                        // 明細単位/総額表示
                        printTax = true;
                    }
                    break;
                case 2:
                    {
                        // 請求親子・非課税（課税区分＝内税のみ表示）
                        // 課税区分（0:課税,1:非課税,2:課税（内税））
                        switch ( taxationDivCd )
                        {
                            case 0:
                            case 1:
                            default:
                                {
                                    printTax = false;
                                }
                                break;
                            case 2:
                                {
                                    printTax = true;
                                }
                                break;
                        }
                    }
                    break;
            }
            # endregion

            // 税印字しない場合
            if ( !printTax )
            {
                priceConsTax = 0;
                moneyTaxInc = moneyTaxExc;
            }
        }
        /// <summary>
        /// 消費税表示タイプ取得
        /// </summary>
        /// <param name="slipWork"></param>
        /// <returns>TaxPrintType（0:伝票単位, 1:明細単位/総額表示あり, 2:請求親/請求子/非課税）</returns>
        private static int GetTaxPrintType( int totalAmountDispWayCd, int consTaxLayMethod )
        {
            // 総額表示方法
            switch ( totalAmountDispWayCd )
            {
                case 1:
                    // 総額表示する
                    return 1;
                case 0:
                default:
                    {
                        // 総額表示しない

                        switch ( consTaxLayMethod )
                        {
                            // 0:伝票単位
                            case 0:
                                return 0;
                            // 1:明細単位
                            case 1:
                                return 1;
                            // 2:請求親
                            case 2:
                            // 3:請求子
                            case 3:
                            // 9:非課税
                            case 9:
                            default:
                                return 2;
                        }
                    }
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD

        /// <summary>
        /// データセットクリア処理
        /// </summary>
        public void ClearStockSlipDataTable()
        {
            this._dataSet.SalesDetail.Rows.Clear();

            // キャッシュデータの取り直し(クリア状態にする)
            this.CacheStockSlipTable();
            this.CacheParaStockSlip(null);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
            if ( this.SelectedDataChange != null )
            {
                this.SelectedDataChange( this, true, 0 );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
        }
        
        /// <summary>
        /// 伝票情報 読み込み処理
        /// </summary>
        /// <param name="stockSlipWorks">仕入データ オブジェクト配列</param>
        /// <param name="salHisRefExtraParamWork">仕入伝票検索パラメータクラス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 伝票情報を読み込みます。</br>
        /// <br>Programmer : 980023 飯谷  飯谷</br>
        /// <br>Date       : 2007.01.29</br>
        /// </remarks>
        public int Search(out List<SalHisRefResultParamWork> salHisRefResultParamWorkList, SalHisRefExtraParamWork salHisRefExtraParamWork)
        {
            try
            {
                int status;
                salHisRefResultParamWorkList = new List<SalHisRefResultParamWork>();

                // オンラインの場合リモート取得
                // -- DEL 2010/05/25 ------------------------>>>
                //if (LoginInfoAcquisition.OnlineFlag)
                //{
                // -- DEL 2010/05/25 ------------------------<<<
                //CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                //paraList.Add(salHisRefExtraParamWork);

                //CustomSerializeArrayList retList = new CustomSerializeArrayList();
                ArrayList retList = new ArrayList();

                //object paraObj = (object)paraList;
                object paraObj = (object)salHisRefExtraParamWork;
                object retObj = (object)retList;

                //伝票情報取得
                status = this._iSalHisRefDB.Search(out retObj, paraObj, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    int setCount = 0;
                    //retList = (CustomSerializeArrayList)retObj;
                    retList = (ArrayList)retObj;
                    for (int i = 0; i < retList.Count; i++)
                    {
                        salHisRefResultParamWorkList.Add((SalHisRefResultParamWork)retList[i]);
                        setCount++;
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
                // -- DEL 2010/05/25 --------------------------->>>
                //}
                //else	// オフラインの場合
                //{
                //    //status = ReadStaticMemory(out lgoodsganre, enterpriseCode, largeGoodsGanreCode);
                //    status = -1;
                //}
                // -- DEL 2010/05/25 ---------------------------<<<

                return status;
            }
            catch (Exception)
            {
                salHisRefResultParamWorkList = null;
                //オフライン時はnullをセット
                this._iSalHisRefDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 伝票データテーブルキャッシュ取得処理
        /// </summary>
        /// <returns>伝票データテーブルキャッシュ</returns>
        public StockDataSet.SalesDetailDataTable GetStockSlipTableCache()
        {
            return _stockSlipCache;
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
        public SalHisRefExtraParamWork GetParaStockSlipCache()
        {
            return _paraStockSlipCache;
		}


		/// <summary>
		/// 選択行印字選択・非選択状態処理
		/// </summary>
		/// <param name="_uniqueID">ユニークID</param>
		/// <remarks>
		/// <br>Note       : 抽出データを初期化します。</br>
		/// <br>Programer  : 980023  飯谷 耕平</br>
		/// <br>Date       : 2007.07.09</br>
		/// </remarks>
		public void SelectedPrintRow(int _uniqueID)
		{
			// ------------------------------------------------------------//
			// Find メソッドを使う但し、Viewのソート順を変更したくない為、 //
			// DataTableに更新をかける。                                   //
			// ------------------------------------------------------------//
			DataRow _row = this._dataSet.SalesDetail.Rows.Find(_uniqueID);

			// 一致する行が存在する！
			if (_row != null)
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
                //bool printFlag = (bool)_row[this._dataSet.StockSlip.PrintFlagColumn.ColumnName];

                //_row.BeginEdit();
                //_row[this._dataSet.StockSlip.PrintFlagColumn.ColumnName] = !printFlag;
                //_row.EndEdit();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
                bool printFlag = (bool)_row[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName];
                SelectedPrintRow( ref _row, !printFlag );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
			}
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
        /// <summary>
        /// 選択行状態設定
        /// </summary>
        /// <param name="row"></param>
        /// <param name="selected"></param>
        /// <returns></returns>
        public bool SelectedPrintRow( ref DataRow row, bool selected )
        {
            bool checkResult;
            int selectedCount = GetSelectedRowCount();

            if ( selected == true && selectedCount == MaxSelectCount )
            {
                // 変更不可
                checkResult = false;
            }
            else
            {
                // 変更前の値を退避
                bool prevPrintFlag = (bool)row[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName];

                // 変更可
                checkResult = true;
                // 変更
                row.BeginEdit();
                row[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName] = selected;
                row.EndEdit();

                if ( !prevPrintFlag && selected )
                {
                    selectedCount++;
                }
                else if ( prevPrintFlag && !selected )
                {
                    selectedCount--;
                }
            }

            // 選択状態変更イベント
            if ( this.SelectedDataChange != null )
            {
                this.SelectedDataChange( this, checkResult, selectedCount );
            }

            return checkResult;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD

		/// <summary>
		/// 選択行印字選択・非選択状態処理(指定型)
		/// </summary>
		/// <param name="_uniqueID">ユニークID</param>
		/// <param name="selected">true:選択,false:非選択</param>
		/// <remarks>
		/// <br>Note       : 抽出データを初期化します。</br>
		/// <br>Programer  : 980023  飯谷 耕平</br>
		/// <br>Date       : 2007.07.09</br>
		/// </remarks>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 DEL
        //public void SelectedPrintRow(int _uniqueID, bool selected)
        public bool SelectedPrintRow( int _uniqueID, bool selected )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 DEL
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
            bool result = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD

            // ------------------------------------------------------------//
            // Find メソッドを使う但し、Viewのソート順を変更したくない為、 //
            // DataTableに更新をかける。                                   //
            // ------------------------------------------------------------//
            DataRow _row = this._dataSet.SalesDetail.Rows.Find( _uniqueID );

            // 一致する行が存在する！
            if ( _row != null )
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 DEL
                //_row.BeginEdit();
                //_row[this._dataSet.StockSlip.PrintFlagColumn.ColumnName] = selected;
                //_row.EndEdit();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
                result = SelectedPrintRow( ref _row, selected );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
            return result;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD
        }

		/// <summary>
		/// 選択行テーブルデータ数取得処理
		/// </summary>
		/// <returns></returns>
		public int GetSelectedRowCount()
		{
			// 部品情報テーブル
			DataView StockSlipView = new DataView(this._dataSet.SalesDetail);
			StockSlipView.RowFilter = String.Format("{0} = {1}", this._dataSet.SalesDetail.PrintFlagColumn.ColumnName, true);
			return (StockSlipView.Count);
		}

		/// <summary>
        /// 選択行テーブルデータ取得処理
        /// </summary>
        /// <param name="getRowNo">グリッド選択RowNo</param>
        /// <returns>仕入データクラス</returns>
        /// <remarks>
        /// <br>Note       : データテーブルから、指定行の仕入データクラスを返します。</br>
        /// <br>Programmer : 980023 飯谷  耕平</br>
        /// <br>Date       : 2007.01.29</br>
        /// </remarks>
        public List<SalHisRefResultParamWork> GetSelectedRowData(int getRowNo)
        {
			// 戻値
			List<SalHisRefResultParamWork> salHisRefResultParamWorkList = new List<SalHisRefResultParamWork>();

			// 部品情報テーブル
			DataView StockSlipView = new DataView(this._dataSet.SalesDetail);
			StockSlipView.RowFilter = String.Format("{0} = {1}", this._dataSet.SalesDetail.PrintFlagColumn.ColumnName,true);

			for (int ix = 0; ix < StockSlipView.Count; ix++)
			{
				SalHisRefResultParamWork salHisRefResultParamWork = new SalHisRefResultParamWork();

				salHisRefResultParamWork.EnterpriseCode = (string)StockSlipView[ix][this._dataSet.SalesDetail.EnterpriseCodeColumn.ColumnName];
				salHisRefResultParamWork.LogicalDeleteCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.LogicalDeleteCodeColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/24 DEL
                //salHisRefResultParamWork.AcceptAnOrderNo = (int)StockSlipView[ix][this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/24 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/24 ADD
                salHisRefResultParamWork.AcceptAnOrderNo = (Int64)StockSlipView[ix][this._dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/24 ADD
				salHisRefResultParamWork.AcptAnOdrStatus = (int)StockSlipView[ix][this._dataSet.SalesDetail.AcptAnOdrStatusColumn.ColumnName];
				salHisRefResultParamWork.SalesSlipNum = (string)StockSlipView[ix][this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName];
				salHisRefResultParamWork.SalesRowNo = (int)StockSlipView[ix][this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                salHisRefResultParamWork.SalesRowDerivNo = (int)StockSlipView[ix][this._dataSet.SalesDetail.SalesRowDerivNoColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
				salHisRefResultParamWork.SectionCode = (string)StockSlipView[ix][this._dataSet.SalesDetail.SectionCodeColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                salHisRefResultParamWork.SectionGuideNm = (string)StockSlipView[ix][this._dataSet.SalesDetail.SectionGuideNmColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
				salHisRefResultParamWork.SubSectionCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.SubSectionCodeColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                salHisRefResultParamWork.SubSectionName = (string)StockSlipView[ix][this._dataSet.SalesDetail.SubSectionNameColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
				//salHisRefResultParamWork.MinSectionCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.MinSectionCodeColumn.ColumnName];
                if (!String.IsNullOrEmpty(StockSlipView[ix][this._dataSet.SalesDetail.SalesDateColumn.ColumnName].ToString().Trim()))
                {
                    salHisRefResultParamWork.SalesDate = (System.DateTime)StockSlipView[ix][this._dataSet.SalesDetail.SalesDateColumn.ColumnName];
                }
				salHisRefResultParamWork.CommonSeqNo = (long)StockSlipView[ix][this._dataSet.SalesDetail.CommonSeqNoColumn.ColumnName];
				salHisRefResultParamWork.SalesSlipDtlNum = (long)StockSlipView[ix][this._dataSet.SalesDetail.SalesSlipDtlNumColumn.ColumnName];
				salHisRefResultParamWork.AcptAnOdrStatusSrc = (int)StockSlipView[ix][this._dataSet.SalesDetail.AcptAnOdrStatusSrcColumn.ColumnName];
				salHisRefResultParamWork.SalesSlipDtlNumSrc = (long)StockSlipView[ix][this._dataSet.SalesDetail.SalesSlipDtlNumSrcColumn.ColumnName];
				salHisRefResultParamWork.SupplierFormalSync = (int)StockSlipView[ix][this._dataSet.SalesDetail.SupplierFormalSyncColumn.ColumnName];
				salHisRefResultParamWork.StockSlipDtlNumSync = (long)StockSlipView[ix][this._dataSet.SalesDetail.StockSlipDtlNumSyncColumn.ColumnName];
				salHisRefResultParamWork.SalesSlipCdDtl = (int)StockSlipView[ix][this._dataSet.SalesDetail.SalesSlipCdDtlColumn.ColumnName];
				//salHisRefResultParamWork.ServiceSlipCd = (int)StockSlipView[ix][this._dataSet.SalesDetail.ServiceSlipCdColumn.ColumnName];
				//salHisRefResultParamWork.SalesDepositsDiv = (int)StockSlipView[ix][this._dataSet.SalesDetail.SalesDepositsDivColumn.ColumnName];
				//salHisRefResultParamWork.StockMngExistCd = (int)StockSlipView[ix][this._dataSet.SalesDetail.StockMngExistCdColumn.ColumnName];
				salHisRefResultParamWork.GoodsKindCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.GoodsKindCodeColumn.ColumnName];
				salHisRefResultParamWork.GoodsMakerCd = (int)StockSlipView[ix][this._dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName];
				salHisRefResultParamWork.MakerName = (string)StockSlipView[ix][this._dataSet.SalesDetail.MakerNameColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                salHisRefResultParamWork.MakerKanaName = (string)StockSlipView[ix][this._dataSet.SalesDetail.MakerKanaNameColumn.ColumnName];
                salHisRefResultParamWork.CmpltMakerKanaName = (string)StockSlipView[ix][this._dataSet.SalesDetail.CmpltMakerKanaNameColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
				salHisRefResultParamWork.GoodsNo = (string)StockSlipView[ix][this._dataSet.SalesDetail.GoodsNoColumn.ColumnName];
				salHisRefResultParamWork.GoodsName = (string)StockSlipView[ix][this._dataSet.SalesDetail.GoodsNameColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                salHisRefResultParamWork.GoodsNameKana = (string)StockSlipView[ix][this._dataSet.SalesDetail.GoodsNameKanaColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                //salHisRefResultParamWork.GoodsSetDivCd = (int)StockSlipView[ix][this._dataSet.SalesDetail.GoodsSetDivCdColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA MODIFY START
                salHisRefResultParamWork.GoodsLGroupName = (string)StockSlipView[ix][this._dataSet.SalesDetail.GoodsLGroupNameColumn.ColumnName];
                salHisRefResultParamWork.GoodsLGroupName = (string)StockSlipView[ix][this._dataSet.SalesDetail.GoodsLGroupNameColumn.ColumnName];
                salHisRefResultParamWork.GoodsMGroup = (int)StockSlipView[ix][this._dataSet.SalesDetail.GoodsMGroupColumn.ColumnName];
                salHisRefResultParamWork.GoodsMGroupName = (string)StockSlipView[ix][this._dataSet.SalesDetail.GoodsMGroupNameColumn.ColumnName];
                salHisRefResultParamWork.BLGroupCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.BLGroupCodeColumn.ColumnName];
                salHisRefResultParamWork.BLGroupName = (string)StockSlipView[ix][this._dataSet.SalesDetail.BLGroupNameColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA MODIFY END
                salHisRefResultParamWork.BLGoodsCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName];
				salHisRefResultParamWork.BLGoodsFullName = (string)StockSlipView[ix][this._dataSet.SalesDetail.BLGoodsFullNameColumn.ColumnName];
				salHisRefResultParamWork.EnterpriseGanreCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.EnterpriseGanreCodeColumn.ColumnName];
				salHisRefResultParamWork.EnterpriseGanreName = (string)StockSlipView[ix][this._dataSet.SalesDetail.EnterpriseGanreNameColumn.ColumnName];
				salHisRefResultParamWork.WarehouseCode = (string)StockSlipView[ix][this._dataSet.SalesDetail.WarehouseCodeColumn.ColumnName];
				salHisRefResultParamWork.WarehouseName = (string)StockSlipView[ix][this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName];
				salHisRefResultParamWork.WarehouseShelfNo = (string)StockSlipView[ix][this._dataSet.SalesDetail.WarehouseShelfNoColumn.ColumnName];
				salHisRefResultParamWork.SalesOrderDivCd = (int)StockSlipView[ix][this._dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                salHisRefResultParamWork.OpenPriceDiv = (int)StockSlipView[ix][this._dataSet.SalesDetail.OpenPriceDivColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END                
				//salHisRefResultParamWork.UnitCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.UnitCodeColumn.ColumnName];
				//salHisRefResultParamWork.UnitName = (string)StockSlipView[ix][this._dataSet.SalesDetail.UnitNameColumn.ColumnName];
				salHisRefResultParamWork.GoodsRateRank = (string)StockSlipView[ix][this._dataSet.SalesDetail.GoodsRateRankColumn.ColumnName];
				salHisRefResultParamWork.CustRateGrpCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.CustRateGrpCodeColumn.ColumnName];
				//salHisRefResultParamWork.SuppRateGrpCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.SuppRateGrpCodeColumn.ColumnName];
				salHisRefResultParamWork.ListPriceRate = (double)StockSlipView[ix][this._dataSet.SalesDetail.ListPriceRateColumn.ColumnName];
				salHisRefResultParamWork.RateDivLPrice = (string)StockSlipView[ix][this._dataSet.SalesDetail.RateDivLPriceColumn.ColumnName];
				salHisRefResultParamWork.UnPrcCalcCdLPrice = (int)StockSlipView[ix][this._dataSet.SalesDetail.UnPrcCalcCdLPriceColumn.ColumnName];
				salHisRefResultParamWork.PriceCdLPrice = (int)StockSlipView[ix][this._dataSet.SalesDetail.PriceCdLPriceColumn.ColumnName];
				salHisRefResultParamWork.StdUnPrcLPrice = (double)StockSlipView[ix][this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName];
				salHisRefResultParamWork.FracProcUnitLPrice = (double)StockSlipView[ix][this._dataSet.SalesDetail.FracProcUnitLPriceColumn.ColumnName];
				salHisRefResultParamWork.FracProcLPrice = (int)StockSlipView[ix][this._dataSet.SalesDetail.FracProcLPriceColumn.ColumnName];
				salHisRefResultParamWork.ListPriceTaxIncFl = (double)StockSlipView[ix][this._dataSet.SalesDetail.ListPriceTaxIncFlColumn.ColumnName];
				salHisRefResultParamWork.ListPriceTaxExcFl = (double)StockSlipView[ix][this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName];
				salHisRefResultParamWork.ListPriceChngCd = (int)StockSlipView[ix][this._dataSet.SalesDetail.ListPriceChngCdColumn.ColumnName];
				salHisRefResultParamWork.SalesRate = (double)StockSlipView[ix][this._dataSet.SalesDetail.SalesRateColumn.ColumnName];
				salHisRefResultParamWork.RateDivSalUnPrc = (string)StockSlipView[ix][this._dataSet.SalesDetail.RateDivSalUnPrcColumn.ColumnName];
				salHisRefResultParamWork.UnPrcCalcCdSalUnPrc = (int)StockSlipView[ix][this._dataSet.SalesDetail.UnPrcCalcCdSalUnPrcColumn.ColumnName];
				salHisRefResultParamWork.PriceCdSalUnPrc = (int)StockSlipView[ix][this._dataSet.SalesDetail.PriceCdSalUnPrcColumn.ColumnName];
				salHisRefResultParamWork.StdUnPrcSalUnPrc = (double)StockSlipView[ix][this._dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName];
				salHisRefResultParamWork.FracProcUnitSalUnPrc = (double)StockSlipView[ix][this._dataSet.SalesDetail.FracProcUnitSalUnPrcColumn.ColumnName];
				salHisRefResultParamWork.FracProcSalUnPrc = (int)StockSlipView[ix][this._dataSet.SalesDetail.FracProcSalUnPrcColumn.ColumnName];
				salHisRefResultParamWork.SalesUnPrcTaxIncFl = (double)StockSlipView[ix][this._dataSet.SalesDetail.SalesUnPrcTaxIncFlColumn.ColumnName];
				salHisRefResultParamWork.SalesUnPrcTaxExcFl = (double)StockSlipView[ix][this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName];
				salHisRefResultParamWork.SalesUnPrcChngCd = (int)StockSlipView[ix][this._dataSet.SalesDetail.SalesUnPrcChngCdColumn.ColumnName];
				salHisRefResultParamWork.CostRate = (double)StockSlipView[ix][this._dataSet.SalesDetail.CostRateColumn.ColumnName];
				salHisRefResultParamWork.RateDivUnCst = (string)StockSlipView[ix][this._dataSet.SalesDetail.RateDivUnCstColumn.ColumnName];
				salHisRefResultParamWork.UnPrcCalcCdUnCst = (int)StockSlipView[ix][this._dataSet.SalesDetail.UnPrcCalcCdUnCstColumn.ColumnName];
				salHisRefResultParamWork.PriceCdUnCst = (int)StockSlipView[ix][this._dataSet.SalesDetail.PriceCdUnCstColumn.ColumnName];
				salHisRefResultParamWork.StdUnPrcUnCst = (double)StockSlipView[ix][this._dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName];
				salHisRefResultParamWork.FracProcUnitUnCst = (double)StockSlipView[ix][this._dataSet.SalesDetail.FracProcUnitUnCstColumn.ColumnName];
				salHisRefResultParamWork.FracProcUnCst = (int)StockSlipView[ix][this._dataSet.SalesDetail.FracProcUnCstColumn.ColumnName];
				salHisRefResultParamWork.SalesUnitCost = (double)StockSlipView[ix][this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName];
				salHisRefResultParamWork.SalesUnitCostChngDiv = (int)StockSlipView[ix][this._dataSet.SalesDetail.SalesUnitCostChngDivColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                salHisRefResultParamWork.RateBLGoodsCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.RateBLGoodsCodeColumn.ColumnName];
                salHisRefResultParamWork.RateBLGoodsName = (string)StockSlipView[ix][this._dataSet.SalesDetail.RateBLGoodsNameColumn.ColumnName];
                salHisRefResultParamWork.PrtBLGoodsCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.PrtBLGoodsCodeColumn.ColumnName];
                salHisRefResultParamWork.PrtBLGoodsName = (string)StockSlipView[ix][this._dataSet.SalesDetail.PrtBLGoodsNameColumn.ColumnName];
                salHisRefResultParamWork.SalesCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.SalesCodeColumn.ColumnName];
                salHisRefResultParamWork.SalesCdNm = (string)StockSlipView[ix][this._dataSet.SalesDetail.SalesCdNmColumn.ColumnName];
                salHisRefResultParamWork.WorkManHour = (double)StockSlipView[ix][this._dataSet.SalesDetail.WorkManHourColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
				//salHisRefResultParamWork.BargainCd = (int)StockSlipView[ix][this._dataSet.SalesDetail.BargainCdColumn.ColumnName];
				//salHisRefResultParamWork.BargainNm = (string)StockSlipView[ix][this._dataSet.SalesDetail.BargainNmColumn.ColumnName];
				salHisRefResultParamWork.ShipmentCnt = (double)StockSlipView[ix][this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName];
				salHisRefResultParamWork.SalesMoneyTaxInc = (long)StockSlipView[ix][this._dataSet.SalesDetail.SalesMoneyTaxIncColumn.ColumnName];
				salHisRefResultParamWork.SalesMoneyTaxExc = (long)StockSlipView[ix][this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName];
				salHisRefResultParamWork.Cost = (long)StockSlipView[ix][this._dataSet.SalesDetail.CostColumn.ColumnName];
				salHisRefResultParamWork.GrsProfitChkDiv = (int)StockSlipView[ix][this._dataSet.SalesDetail.GrsProfitChkDivColumn.ColumnName];
				salHisRefResultParamWork.SalesGoodsCd = (int)StockSlipView[ix][this._dataSet.SalesDetail.SalesGoodsCdColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                //salHisRefResultParamWork.SalesPriceConsTax = (int)StockSlipView[ix][this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName];
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
                salHisRefResultParamWork.SalesPriceConsTax = (Int64)StockSlipView[ix][this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
                //salHisRefResultParamWork.TaxAdjust = (long)StockSlipView[ix][this._dataSet.SalesDetail.TaxAdjustColumn.ColumnName];
				//salHisRefResultParamWork.BalanceAdjust = (long)StockSlipView[ix][this._dataSet.SalesDetail.BalanceAdjustColumn.ColumnName];
				salHisRefResultParamWork.TaxationDivCd = (int)StockSlipView[ix][this._dataSet.SalesDetail.TaxationDivCdColumn.ColumnName];
				salHisRefResultParamWork.PartySlipNumDtl = (string)StockSlipView[ix][this._dataSet.SalesDetail.PartySlipNumDtlColumn.ColumnName];
				salHisRefResultParamWork.DtlNote = (string)StockSlipView[ix][this._dataSet.SalesDetail.DtlNoteColumn.ColumnName];
				salHisRefResultParamWork.SupplierCd = (int)StockSlipView[ix][this._dataSet.SalesDetail.SupplierCdColumn.ColumnName];
				salHisRefResultParamWork.SupplierSnm = (string)StockSlipView[ix][this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName];
				//salHisRefResultParamWork.ResultsAddUpSecCd = (string)StockSlipView[ix][this._dataSet.SalesDetail.ResultsAddUpSecCdColumn.ColumnName];
				salHisRefResultParamWork.OrderNumber = (string)StockSlipView[ix][this._dataSet.SalesDetail.OrderNumberColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                salHisRefResultParamWork.WayToOrder = (int)StockSlipView[ix][this._dataSet.SalesDetail.WayToOrderColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END                
				salHisRefResultParamWork.SlipMemo1 = (string)StockSlipView[ix][this._dataSet.SalesDetail.SlipMemo1Column.ColumnName];
				salHisRefResultParamWork.SlipMemo2 = (string)StockSlipView[ix][this._dataSet.SalesDetail.SlipMemo2Column.ColumnName];
				salHisRefResultParamWork.SlipMemo3 = (string)StockSlipView[ix][this._dataSet.SalesDetail.SlipMemo3Column.ColumnName];
				//salHisRefResultParamWork.SlipMemo4 = (string)StockSlipView[ix][this._dataSet.SalesDetail.SlipMemo4Column.ColumnName];
				//salHisRefResultParamWork.SlipMemo5 = (string)StockSlipView[ix][this._dataSet.SalesDetail.SlipMemo5Column.ColumnName];
				//salHisRefResultParamWork.SlipMemo6 = (string)StockSlipView[ix][this._dataSet.SalesDetail.SlipMemo6Column.ColumnName];
				salHisRefResultParamWork.InsideMemo1 = (string)StockSlipView[ix][this._dataSet.SalesDetail.InsideMemo1Column.ColumnName];
				salHisRefResultParamWork.InsideMemo2 = (string)StockSlipView[ix][this._dataSet.SalesDetail.InsideMemo2Column.ColumnName];
				salHisRefResultParamWork.InsideMemo3 = (string)StockSlipView[ix][this._dataSet.SalesDetail.InsideMemo3Column.ColumnName];
				//salHisRefResultParamWork.InsideMemo4 = (string)StockSlipView[ix][this._dataSet.SalesDetail.InsideMemo4Column.ColumnName];
				//salHisRefResultParamWork.InsideMemo5 = (string)StockSlipView[ix][this._dataSet.SalesDetail.InsideMemo5Column.ColumnName];
				//salHisRefResultParamWork.InsideMemo6 = (string)StockSlipView[ix][this._dataSet.SalesDetail.InsideMemo6Column.ColumnName];
				salHisRefResultParamWork.BfListPrice = (double)StockSlipView[ix][this._dataSet.SalesDetail.BfListPriceColumn.ColumnName];
				salHisRefResultParamWork.BfSalesUnitPrice = (double)StockSlipView[ix][this._dataSet.SalesDetail.BfSalesUnitPriceColumn.ColumnName];
				salHisRefResultParamWork.BfUnitCost = (double)StockSlipView[ix][this._dataSet.SalesDetail.BfUnitCostColumn.ColumnName];
				//salHisRefResultParamWork.PrtGoodsNo = (string)StockSlipView[ix][this._dataSet.SalesDetail.PrtGoodsNoColumn.ColumnName];
				//salHisRefResultParamWork.PrtGoodsName = (string)StockSlipView[ix][this._dataSet.SalesDetail.PrtGoodsNameColumn.ColumnName];
				//salHisRefResultParamWork.PrtGoodsMakerCd = (int)StockSlipView[ix][this._dataSet.SalesDetail.PrtGoodsMakerCdColumn.ColumnName];
				//salHisRefResultParamWork.PrtGoodsMakerNm = (string)StockSlipView[ix][this._dataSet.SalesDetail.PrtGoodsMakerNmColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                salHisRefResultParamWork.CmpltSalesRowNo = (int)StockSlipView[ix][this._dataSet.SalesDetail.CmpltSalesRowNoColumn.ColumnName];
                salHisRefResultParamWork.CmpltGoodsMakerCd = (int)StockSlipView[ix][this._dataSet.SalesDetail.CmpltGoodsMakerCdColumn.ColumnName];
                salHisRefResultParamWork.CmpltMakerName = (string)StockSlipView[ix][this._dataSet.SalesDetail.CmpltMakerNameColumn.ColumnName];
                salHisRefResultParamWork.CmpltGoodsName = (string)StockSlipView[ix][this._dataSet.SalesDetail.CmpltGoodsNameColumn.ColumnName];
                salHisRefResultParamWork.CmpltShipmentCnt = (double)StockSlipView[ix][this._dataSet.SalesDetail.CmpltShipmentCntColumn.ColumnName];
                salHisRefResultParamWork.CmpltSalesUnPrcFl = (double)StockSlipView[ix][this._dataSet.SalesDetail.CmpltSalesUnPrcFlColumn.ColumnName];
                salHisRefResultParamWork.CmpltSalesMoney = (long)StockSlipView[ix][this._dataSet.SalesDetail.CmpltSalesMoneyColumn.ColumnName];
                salHisRefResultParamWork.CmpltSalesUnitCost = (double)StockSlipView[ix][this._dataSet.SalesDetail.CmpltSalesUnitCostColumn.ColumnName];
                salHisRefResultParamWork.CmpltCost = (long)StockSlipView[ix][this._dataSet.SalesDetail.CmpltCostColumn.ColumnName];
                salHisRefResultParamWork.CmpltPartySalSlNum = (string)StockSlipView[ix][this._dataSet.SalesDetail.CmpltPartySalSlNumColumn.ColumnName];
                salHisRefResultParamWork.CmpltNote = (string)StockSlipView[ix][this._dataSet.SalesDetail.CmpltNoteColumn.ColumnName];
                salHisRefResultParamWork.CarMngCode = (string)StockSlipView[ix][this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName];
                salHisRefResultParamWork.ModelDesignationNo = (int)StockSlipView[ix][this._dataSet.SalesDetail.ModelDesignationNoColumn.ColumnName];
                salHisRefResultParamWork.CategoryNo = (int)StockSlipView[ix][this._dataSet.SalesDetail.CategoryNoColumn.ColumnName];
                salHisRefResultParamWork.MakerFullName = (string)StockSlipView[ix][this._dataSet.SalesDetail.MakerFullNameColumn.ColumnName];
                salHisRefResultParamWork.FullModel = (string)StockSlipView[ix][this._dataSet.SalesDetail.FullModelColumn.ColumnName];
                salHisRefResultParamWork.ModelFullName = (string)StockSlipView[ix][this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName];
                // 2008.11.14 modify start
                if (!String.IsNullOrEmpty(StockSlipView[ix][this._dataSet.SalesDetail.SearchSlipDateColumn.ColumnName].ToString().Trim()))
                {
                    salHisRefResultParamWork.SearchSlipDate = (System.DateTime)StockSlipView[ix][this._dataSet.SalesDetail.SearchSlipDateColumn.ColumnName];
                }
                if (!String.IsNullOrEmpty(StockSlipView[ix][this._dataSet.SalesDetail.ShipmentDayColumn.ColumnName].ToString().Trim()))
                {
                salHisRefResultParamWork.ShipmentDay = (System.DateTime)StockSlipView[ix][this._dataSet.SalesDetail.ShipmentDayColumn.ColumnName];
                }
                if (!String.IsNullOrEmpty(StockSlipView[ix][this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].ToString().Trim()))
                {
                    salHisRefResultParamWork.AddUpADate = (System.DateTime)StockSlipView[ix][this._dataSet.SalesDetail.AddUpADateColumn.ColumnName];
                }
                // 2008.11.14 modify end
                salHisRefResultParamWork.InputAgenCd = (string)StockSlipView[ix][this._dataSet.SalesDetail.InputAgenCdColumn.ColumnName];
                salHisRefResultParamWork.InputAgenNm = (string)StockSlipView[ix][this._dataSet.SalesDetail.InputAgenNmColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                salHisRefResultParamWork.SalesInputCode = (string)StockSlipView[ix][this._dataSet.SalesDetail.SalesInputCodeColumn.ColumnName];
                salHisRefResultParamWork.SalesInputName = (string)StockSlipView[ix][this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName];
                salHisRefResultParamWork.FrontEmployeeCd = (string)StockSlipView[ix][this._dataSet.SalesDetail.FrontEmployeeCdColumn.ColumnName];
                salHisRefResultParamWork.FrontEmployeeNm = (string)StockSlipView[ix][this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName];
                salHisRefResultParamWork.SalesEmployeeCd = (string)StockSlipView[ix][this._dataSet.SalesDetail.SalesEmployeeCdColumn.ColumnName];
                salHisRefResultParamWork.SalesEmployeeNm = (string)StockSlipView[ix][this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                salHisRefResultParamWork.ClaimCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.ClaimCodeColumn.ColumnName];
                salHisRefResultParamWork.ClaimSnm = (string)StockSlipView[ix][this._dataSet.SalesDetail.ClaimSnmColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                salHisRefResultParamWork.CustomerCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName];
				//salHisRefResultParamWork.CustomerName = (string)StockSlipView[ix][this._dataSet.SalesDetail.CustomerNameColumn.ColumnName];
				//salHisRefResultParamWork.CustomerName2 = (string)StockSlipView[ix][this._dataSet.SalesDetail.CustomerName2Column.ColumnName];
				salHisRefResultParamWork.CustomerSnm = (string)StockSlipView[ix][this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName];
				salHisRefResultParamWork.AddresseeCode = (int)StockSlipView[ix][this._dataSet.SalesDetail.AddresseeCodeColumn.ColumnName];
				salHisRefResultParamWork.AddresseeName = (string)StockSlipView[ix][this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName];
				salHisRefResultParamWork.AddresseeName2 = (string)StockSlipView[ix][this._dataSet.SalesDetail.AddresseeName2Column.ColumnName];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.23 TOKUNAGA ADD START
                salHisRefResultParamWork.AcptAnOdrRemainCnt = (double)StockSlipView[ix][this._dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName];
                salHisRefResultParamWork.DebitNoteDiv = (int)StockSlipView[ix][this._dataSet.SalesDetail.DebitNoteDivColumn.ColumnName];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.23 TOKUNAGA ADD END

				salHisRefResultParamWorkList.Add(salHisRefResultParamWork);
			}

			return salHisRefResultParamWorkList;
        }

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
				//goodsName = goodsUnitDataList[0].GoodsShortName;
				return true;
            }
            else
            {
                return false;
            }
        }

		/// <summary>
		/// 商品名称取得処理
		/// </summary>
		/// <param name="goodsCode">商品コード</param>
		/// <returns>true:存在あり、false:存在しない</returns>
		public int CheckGoodsExist(IWin32Window owner, ref string goodsCode, ref string goodsName, ref int goodsMakerCd, ref string makerName)
		{
			int status;
			string message;
			string searchCode;
			int searchType;

			GoodsCndtn goodsCndtn = new GoodsCndtn();
			List<GoodsUnitData> goodsUnitDataList;
			GoodsAcs goodsAcs = new GoodsAcs();

			searchType = GetSearchType(goodsCode, out searchCode);

			MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

			goodsCndtn.GoodsMakerCd = goodsMakerCd;
			goodsCndtn.GoodsNoSrchTyp = searchType;
			//goodsCndtn.GoodsNo = goodsCode;
			goodsCndtn.GoodsNo = searchCode;
			goodsCndtn.EnterpriseCode = this._enterpriseCode;

			//status = goodsSelectGuide.ReadGoods(owner, false, goodsCndtn, this._enterpriseCode, searchType, searchCode, out goodsUnitDataList, out message);
			status = goodsSelectGuide.ReadGoods(owner, false, goodsCndtn, out goodsUnitDataList, out message);


			if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
			{
				goodsCode = goodsUnitDataList[0].GoodsNo;
				goodsName = goodsUnitDataList[0].GoodsName;
				//goodsName = goodsUnitDataList[0].GoodsShortName;

				makerName = goodsUnitDataList[0].MakerName;
				goodsMakerCd = goodsUnitDataList[0].GoodsMakerCd;
			}
			return (status);
		}

		// ===================================================================================== //
		// 商品関連処理
		// ===================================================================================== //
		# region Goods Control Methods

		/// <summary>
		/// 検索タイプ取得処理
		/// </summary>
		/// <param name="inputCode">入力されたコード</param>
		/// <param name="searchCode">検索用コード（*を除く）</param>
		/// <returns>0:完全一致検索 1:前方一致検索 2:後方一致検索 3:曖昧検索</returns>
		public static int GetSearchType(string inputCode, out string searchCode)
		{
			searchCode = inputCode;
			if (String.IsNullOrEmpty(inputCode)) return 0;

			if (inputCode.Contains("*"))
			{
				searchCode = inputCode.Replace("*", "");
				string firstString = inputCode.Substring(0, 1);
				string lastString = inputCode.Substring(inputCode.Length - 1, 1);

				if ((firstString == "*") && (lastString == "*"))
				{
					return 3;
				}
				else if (firstString == "*")
				{
					return 2;
				}
				else if (lastString == "*")
				{
					return 1;
				}
				else
				{
					return 3;
				}
			}
			else
			{
				// *が存在しないため完全一致検索
				return 0;
			}
		}

		# endregion

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
