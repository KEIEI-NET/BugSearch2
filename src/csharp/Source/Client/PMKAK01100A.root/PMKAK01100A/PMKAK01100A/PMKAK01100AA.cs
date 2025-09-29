//***************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 仕入返品予定計上更新部品
// プログラム概要   : 仕入返品予定計上更新部品 アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : FSI斎藤 和宏
// 作 成 日  2013/01/22  修正内容 : 仕入返品予定機能追加対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Collections;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// 仕入返品予定計上更新部品　アクセスクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 仕入返品予定計上更新の制御全般を行います。</br>
	/// <br>Programmer : FSI斎藤 和宏</br>
	/// <br>Date       : 2013/01/22</br>
	/// <br></br>
    /// </remarks>
	public class StockSlipRetPlnAcs
	{ 
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region ■Constructor
		/// <summary>
		/// デフォルトコンストラクタ（Singletonクラス)
		/// </summary>
		private StockSlipRetPlnAcs()
		{
            // 変数初期化
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._goodsAcs = new GoodsAcs();

            this.GetTtlSt();
        }

        /// <summary>
        /// 仕入返品予定計上更新部品アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>仕入返品予定計上更新部品クラス インスタンス</returns>
        public static StockSlipRetPlnAcs GetInstance()
        {
            if (_stockSlipRetPlnAcs == null)
            {
                _stockSlipRetPlnAcs = new StockSlipRetPlnAcs();
            }
            return _stockSlipRetPlnAcs;
        }
		# endregion

		// ===================================================================================== //
		// プライベート変数
        // ===================================================================================== //
        # region ■Private Members
        private static StockSlipRetPlnAcs _stockSlipRetPlnAcs;  // 仕入返品予定計上更新部品アクセスクラス(Singletonクラス)
        private string _enterpriseCode = string.Empty;          // 企業コード
        private TotalDayCalculator _totalDayCalculator = null;  // 締日チェック部品
        private DateGetAcs _dateGetAcs = null;                  // 日付取得部品
        private SalesTtlSt _salesTtlSt = null;                  // 売上全体設定
        private StockTtlSt _stockTtlSt = null;                  // 仕入全体設定
        private GoodsAcs _goodsAcs = null;                      // 商品マスタアクセスクラス
        private IStockSlipRetPlnDB _iStockSlipRetPlnDB = null;  // 仕入返品用のリモートインターフェース

        private const string ctSectionCode_Common = "00";       // 拠点コード(全社共通)
        # endregion

		// ===================================================================================== //
		// プロパティ
        // ===================================================================================== //
        # region ■Properties

        /// <summary>
        /// 売上全体設定マスタ
        /// </summary>
        /// <returns>売上全体設定マスタオブジェクト</returns>
        public SalesTtlSt GetSalesTtlSt()
        {
            return this._salesTtlSt;
        }

        /// <summary>
        /// 仕入在庫全体設定マスタ
        /// </summary>
        /// <returns>仕入在庫全体設定マスタオブジェクト</returns>
        public StockTtlSt GetStockTtlSt()
        {
            return this._stockTtlSt;
        }

        # endregion

        // ===================================================================================== //
		// DBデータアクセス処理
		// ===================================================================================== //
		# region ■DataBase Access Methods
        /// <summary>
        /// 前回月次更新日取得
        /// </summary>
        /// <returns></returns>
        private DateTime GetHisTotalDayMonthly()
        {
            if (_totalDayCalculator == null) this._totalDayCalculator = TotalDayCalculator.GetInstance();

            int status;
            DateTime prevTotalDay;

            // 締日算出モジュールのキャッシュクリア
            this._totalDayCalculator.ClearCache();

            // 買掛オプション判定
            PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);
            if (ps == PurchaseStatus.Contract)
            {
                // 買掛オプションあり
                // 売上月次処理日、仕入月次処理日の古い年月取得
                this._totalDayCalculator.InitializeHisMonthly();
                status = this._totalDayCalculator.GetHisTotalDayMonthly(string.Empty, out prevTotalDay);
                if (prevTotalDay == DateTime.MinValue)
                {
                    // 売上月次処理日取得
                    status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec(string.Empty, out prevTotalDay);
                    if (prevTotalDay == DateTime.MinValue)
                    {
                        // 仕入月次処理日取得
                        status = this._totalDayCalculator.GetHisTotalDayMonthlyAccPay(string.Empty, out prevTotalDay);
                    }
                }
            }
            else
            {
                // 買掛オプションなし
                // 売上月次処理日取得
                this._totalDayCalculator.InitializeHisMonthlyAccRec();
                status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec(string.Empty, out prevTotalDay);
            }

            return prevTotalDay;
        }

		# endregion

		// ===================================================================================== //
		// パブリックメソッド
        // ===================================================================================== //
        # region ■Public Methods
        /// <summary>
        /// 仕入返品予定データの登録を行います
        /// </summary>
        /// <param name="retPlnDataObj">登録する仕入返品予定データ</param>
        /// <param name="salsSlipNoList">売上返品の伝票番号リスト</param>
        /// <param name="errMsg">返却するエラーメッセージ</param>
        /// <returns>0:正常終了 9:エラー</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22 FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// </remarks>
        public int WriteStockSlipRetPln(object retPlnDataObj, ArrayList salsSlipNoList, out string errMsg)
        {
            errMsg = string.Empty;

            return this.WriteStockSlipRetPlnProc(retPlnDataObj, salsSlipNoList, out errMsg);
        }

        /// <summary>
        /// 仕入返品予定データの削除を行います
        /// </summary>
        /// <param name="retPlnDelDataObj">削除対象の仕入返品予定データ</param>
        /// <param name="errMsg">返却するエラーメッセージ</param>
        /// <returns>0:正常終了 9:エラー</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22 FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// </remarks>
        public int DeleteStockSlipRetPln(ref object retPlnDelDataObj, out string errMsg)
        {
            errMsg = string.Empty;

            return this.DeleteStockSlipRetPlnProc(ref retPlnDelDataObj, out errMsg);
        }

        /// <summary>
        /// 仕入返品予定データの計上を行います
        /// </summary>
        /// <param name="addUpDataObj">計上対象の仕入返品予定データ</param>
        /// <param name="errMsg">返却するエラーメッセージ</param>
        /// <returns>0:正常終了 9:エラー</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22 FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// </remarks>
        public int AddUpStockSlipRetPln(object addUpDataObj, out string errMsg)
        {
            errMsg = string.Empty;

            return this.AddUpStockSlipRetPlnProc(addUpDataObj, out errMsg);
        }

        #endregion

        // ===================================================================================== //
		// プライベートメソッド
        // ===================================================================================== //
        #region ■Private Methods

        #region[書込処理]
        /// <summary>
        /// 仕入返品予定データの登録を行います
        /// </summary>
        /// <param name="retPlnDataObj">登録する仕入返品予定データ</param>
        /// <param name="salsSlipNoList">売上返品の伝票番号リスト</param>
        /// <param name="errMsg">返却するエラーメッセージ</param>
        /// <returns>0:正常終了 9:エラー</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22 FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// </remarks>
        private int WriteStockSlipRetPlnProc(object retPlnDataObj, ArrayList salsSlipNoList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            string retItemInfo = string.Empty;      // リモートを呼ぶのに必要(未使用)

            // パラメータチェック
            if(retPlnDataObj == null)
            {
                errMsg = ": パラメータが不正です。";
                return status;
            }
            else if(salsSlipNoList == null || salsSlipNoList.Count == 0)
            {
                errMsg = ": 売上伝票番号が指定されていません。";
                return status;
            }

            CustomSerializeArrayList dataList = new CustomSerializeArrayList();

            dataList = (CustomSerializeArrayList)retPlnDataObj;

            // 登録データの更新処理
            if ((int)ConstantManagement.MethodResult.ctFNC_NORMAL != this.AddPurchaseRetPlnWriteData(ref dataList, salsSlipNoList, out errMsg))
            {
                return status;
            }

            // IOWrite制御ワークオブジェクトの追加セット
            IOWriteCtrlOptWork iOWriteCtrlOptWork = this.GetIOWriteCtrlOptWork();
            dataList.Add(iOWriteCtrlOptWork);

            // dataListをobjectに変更
            object inputData = dataList;

            // リモートオブジェクトのインスタンス取得
            if (this._iStockSlipRetPlnDB == null) this._iStockSlipRetPlnDB = (IStockSlipRetPlnDB)MediationStockSlipRetPlnDB.GetStockSlipRetPlnDB();

            // リモートの登録処理
            status = this._iStockSlipRetPlnDB.Write(ref inputData, out errMsg, out retItemInfo);

            return status;
        }

        /// <summary>
        /// 登録する返品予定データの情報追加処理を行います。
        /// </summary>
        /// <param name="dataList">登録する仕入返品予定データ</param>
        /// <param name="salesSlipNumList">売上返品伝票番号リスト</param>
        /// <param name="errMsg">返却するエラーメッセージ</param>
        /// <returns>0:正常終了 9:エラー</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22 FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// </remarks>
        private int AddPurchaseRetPlnWriteData(ref CustomSerializeArrayList dataList, ArrayList salesSlipNumList, out string errMsg)
        {
            //この時点でdataListは以下の構成になっている
            //------------------------------------------------------------------------------------
            //  CustomSerializeArrayList            書き込みパラメータリスト
            //      --CustomSerializeArrayList      仕入リスト
            //          --StockSlipWork             仕入データオブジェクト
            //          --ArrayList                 仕入明細リスト
            //              --StockDetailWork       仕入明細データオブジェクト
            //          --ArrayList                 仕入明細追加情報リスト
            //              --SlipDetailAddInfoWork 仕入明細追加情報データオブジェクト
            //------------------------------------------------------------------------------------
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            errMsg = string.Empty;

            // 伝票データ
            StockSlipWork stockSlip = null;
            // 明細リスト
            List<StockDetailWork> stockDetailList = null;
            // 明細追加情報リスト
            List<SlipDetailAddInfoWork> slipDetailAddInfoWorkList = null;
            // 全明細リスト
            List<StockDetailWork> stockDetailAllList = new List<StockDetailWork>();
            // 仕入拠点コード格納
            string stockSectionCd = string.Empty;

            try
            {
                // データ取得(書き込みパラメータリストから)
                foreach (ArrayList PurchaseList in dataList)
                {
                    stockSlip = new StockSlipWork();

                    // データ取得(仕入リストから)
                    foreach (object data in PurchaseList)
                    {
                        if (data is StockSlipWork) // 仕入伝票の場合
                        {
                            stockSlip = (StockSlipWork)data;
                            stockSectionCd = stockSlip.StockSectionCd.Trim();
                            // 部品側で仕入形式「0」をセット
                            // 伝票番号採番はこの値を参照して行う為、
                            // ここで「3」をセットすると採番できない
                            stockSlip.SupplierFormal = 0;

                            // 自動支払区分は0固定とする(入荷伝票作成時同様)
                            stockSlip.AutoPayment = 0;
                            stockSlip.AutoPaySlipNum = 0;

                            // 伝票データに対するデータセットはここ //
                        }
                        else if (data is ArrayList && ((ArrayList)data)[0] != null && ((ArrayList)data)[0] is StockDetailWork)
                        {
                            stockDetailList = new List<StockDetailWork>();

                            // foreachでStockDetailWork取り出す
                            foreach (StockDetailWork stockDetail in (ArrayList)data)
                            {
                                // 部品側で仕入形式「0」をセット
                                // 伝票番号採番はこの値を参照して行う為、
                                // ここで「3」をセットすると採番できない
                                // 仕入形式（元）は得意先電子元帳側で-1にセットされている
                                stockDetail.SupplierFormal = 0;

                                // 共通通番は0(新規採番する)
                                stockDetail.CommonSeqNo = 0;

                                // 仕入在庫取寄せ区分
                                stockDetail.StockOrderDivCd = (string.IsNullOrEmpty(stockDetail.WarehouseCode.Trim())) ? 0 : 1;

                                // 明細データに対するデータセットはここ //

                                stockDetailList.Add(stockDetail);
                                stockDetailAllList.Add(stockDetail);
                            }

                        }
                        else if (data is ArrayList && ((ArrayList)data)[0] != null && ((ArrayList)data)[0] is SlipDetailAddInfoWork)
                        {
                            slipDetailAddInfoWorkList = new List<SlipDetailAddInfoWork>();

                            foreach (SlipDetailAddInfoWork slipDetailAddInfo in (ArrayList)data)
                            {
                                slipDetailAddInfoWorkList.Add(slipDetailAddInfo);
                            }

                        }
                        else
                        {
                            // データの形式が不正
                            errMsg = ": 仕入形式パラメータが不正です。";
                            return status;
                        }
                    }
                }

                // 全明細リストに対して、売上返品データの売上明細通番を取得・セット
                status = this.SetSalesSlipDtlNumFromSalesSlipNum(salesSlipNumList, stockSectionCd, ref stockDetailAllList, out errMsg);

            }
            catch
            {
                errMsg = ": 仕入形式パラメータが不正です。";
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 売上返品明細データの通番を仕入明細の売上明細通番(同時)にセットします
        /// </summary>
        /// <param name="salesSlipNumList">売上返品伝票番号リスト</param>
        /// <param name="stockSectionCd">仕入拠点コード</param>
        /// <param name="stockDetailAllList">仕入明細データ</param>
        /// <param name="errMsg">返却するエラーメッセージ</param>
        /// <returns>0:正常終了 9:エラー</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22 FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// </remarks>
        private int SetSalesSlipDtlNumFromSalesSlipNum(ArrayList salesSlipNumList, string stockSectionCd, ref List<StockDetailWork> stockDetailAllList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            errMsg = string.Empty;
            object objectSalesDetailWork = null;
            ArrayList retWorkList = null;

            object salesSlipNumparm = (object)salesSlipNumList;
            try
            {
                // リモートオブジェクトのインスタンス取得
                if (this._iStockSlipRetPlnDB == null) this._iStockSlipRetPlnDB = (IStockSlipRetPlnDB)MediationStockSlipRetPlnDB.GetStockSlipRetPlnDB();

                // 売上伝票番号をキーに売上返品データを全取得
                status = this._iStockSlipRetPlnDB.SearchSalesDetail(out objectSalesDetailWork, this._enterpriseCode, salesSlipNumparm, stockSectionCd);

                if (objectSalesDetailWork != null && (objectSalesDetailWork as CustomSerializeArrayList).Count > 0)
                {
                    retWorkList = objectSalesDetailWork as ArrayList;
                }
                else
                {
                    errMsg = ": 元の売上明細データがありません";
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }

                // stockDetailAllListに対して、売上明細通番を格納
                foreach (StockDetailWork stockDetail in stockDetailAllList)
                {
                    foreach (StockSlipRetPlnWork salesDetail in retWorkList)
                    {
                        // GUIDが一致している場合
                        if (stockDetail.FileHeaderGuid.Equals(salesDetail.FileHeaderGuid))
                        {
                            stockDetail.SalesSlipDtlNumSync = salesDetail.SalesSlipDtlNum;
                            stockDetail.FileHeaderGuid = Guid.Empty;
                            break;
                        }
                    }
                    if (stockDetail.SalesSlipDtlNumSync == 0)
                    {
                        errMsg = ": 元の売上明細データがありません";
                        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    }
                }
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch
            {
                errMsg = ": 仕入形式パラメータが不正です。";
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// GoodsUnitを元に明細情報・明細追加情報の更新処理を行います
        /// </summary>
        /// <param name="stockSlip">仕入伝票データ</param>
        /// <param name="stockDetailList">仕入明細リスト仕入返品予定データ</param>
        /// <param name="slipDetailAddInfoWorkList">仕入明細追加情報リスト</param>
        /// <param name="errMsg">返却するエラーメッセージ</param>
        /// <remarks>
        /// <br>Note        : 2013/01/22 FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// <br>              ※仕入伝票入力の処理流用</br>
        /// </remarks>
        private void SetStockDetailFromGoodsInfo(ref StockSlipWork stockSlip, ref List<StockDetailWork> stockDetailList, ref List<SlipDetailAddInfoWork> slipDetailAddInfoWorkList, out string errMsg)
        {
            // 商品情報
            List<GoodsCndtn> goodsCndtnList = new List<GoodsCndtn>(); //GoodsUnitData取得のため
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>(); //GoodsUnitData格納するList

            // 抽出条件項目に仕入明細データを格納
            foreach (StockDetailWork stockDetailWork in stockDetailList)
            {
                GoodsCndtn goodsCndtn = new GoodsCndtn();
                goodsCndtn.EnterpriseCode = this._enterpriseCode;
                goodsCndtn.GoodsNo = stockDetailWork.GoodsNo;
                goodsCndtn.GoodsMakerCd = stockDetailWork.GoodsMakerCd;
                goodsCndtn.SectionCode = stockSlip.StockSectionCd;
                goodsCndtn.IsSettingSupplier = 1;
                goodsCndtnList.Add(goodsCndtn);
            }

            //goodsCndtnListを元にgoodsUnitDataListを取得
            this.GetGoodsUnitDataList(goodsCndtnList, out goodsUnitDataList, out errMsg);

            // 仕入全体設定を取得
            StockTtlSt stockTtlSt = this.GetStockTtlSt();

            // 仕入明細データ・仕入明細追加情報の更新
            int index = 0;
            for (index = 0; (index < stockDetailList.Count || index < slipDetailAddInfoWorkList.Count); index++)
            {
                // 明細関連付けGUID
                slipDetailAddInfoWorkList[index].DtlRelationGuid = stockDetailList[index].DtlRelationGuid;

                // 品番・メーカーが入力されていて、仕入行の場合
                if ((!string.IsNullOrEmpty(stockDetailList[index].GoodsNo) && (stockDetailList[index].GoodsMakerCd != 0)) && (stockDetailList[index].StockSlipCdDtl == 0))
                {
                    //GoodsUnitDataListから取得したいデータを取得
                    GoodsUnitData goodsUnitData = this.GetGoodsUnitDataFromList(stockDetailList[index].GoodsNo, stockDetailList[index].GoodsMakerCd, goodsUnitDataList);

                    // 商品自動登録：する
                    if ((this.GetStockTtlSt().AutoEntryGoodsDivCd == 1) &&
                        ((goodsUnitData == null) || (goodsUnitData.OfferKubun >= 3)))
                    {
                        if (goodsUnitData == null) goodsUnitData = new GoodsUnitData();

                        slipDetailAddInfoWorkList[index].GoodsEntryDiv = 1;                            // 商品登録区分
                        slipDetailAddInfoWorkList[index].GoodsOfferDate = goodsUnitData.OfferDate;     // 商品提供日

                        GoodsPrice goodsPrice = this.GetGoodsPrice((stockDetailList[index].SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay, goodsUnitData);
                        if (goodsPrice != null)
                        {
                            slipDetailAddInfoWorkList[index].PriceOfferDate = goodsPrice.OfferDate;    // 価格提供日
                        }
                        slipDetailAddInfoWorkList[index].PriceStartDate = GetPriceStartDate(stockSlip); // 価格開始日
                        slipDetailAddInfoWorkList[index].PriceUpdateDiv = 1;
                    }
                    else
                    {
                        if ((goodsUnitData != null) && (goodsUnitData.OfferKubun < 3))
                        {
                            GoodsPrice goodsPrice = this.GetGoodsPrice((stockSlip.SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay, goodsUnitData);

                            slipDetailAddInfoWorkList[index].PriceUpdateDiv = (stockTtlSt.PriceCostUpdtDiv == 1) ? 1 : 0;   // 価格更新区分
                            if (goodsPrice != null)
                            {
                                slipDetailAddInfoWorkList[index].PriceStartDate = goodsPrice.PriceStartDate;       // 価格開始日
                                slipDetailAddInfoWorkList[index].PriceOfferDate = goodsPrice.OfferDate;			// 価格提供日
                            }
                            else
                            {
                                slipDetailAddInfoWorkList[index].PriceStartDate = GetPriceStartDate(stockSlip);
                            }
                        }
                    }
                }
            }

            return;
        }
        #endregion[書込処理]

        #region[削除処理]

        /// <summary>
        /// 仕入返品予定データの論理削除を行います
        /// </summary>
        /// <param name="retPlnDelObj">論理削除する仕入返品予定データ</param>
        /// <param name="errMsg">返却するエラーメッセージ</param>
        /// <returns>RETURN</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22 FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// </remarks>
        private int DeleteStockSlipRetPlnProc(ref object retPlnDelObj, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // リモートオブジェクトのインスタンス取得
            if (this._iStockSlipRetPlnDB == null) this._iStockSlipRetPlnDB = (IStockSlipRetPlnDB)MediationStockSlipRetPlnDB.GetStockSlipRetPlnDB();

            // リモートの論理削除処理
            status = this._iStockSlipRetPlnDB.LogicalDelete(ref retPlnDelObj, out errMsg);

            return status;
        }

        #endregion[削除処理]

        #region[計上処理]

        /// <summary>
        /// 仕入返品予定データの計上処理を行います
        /// </summary>
        /// <param name="addUpDataObj">計上する仕入返品予定データ</param>
        /// <param name="errMsg">返却するエラーメッセージ</param>
        /// <returns>0:正常終了 9:エラー</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22 FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// </remarks>
        private int AddUpStockSlipRetPlnProc(object addUpDataObj, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            string retItemInfo = string.Empty;      // リモートを呼ぶのに必要(未使用)
            errMsg = string.Empty;

            CustomSerializeArrayList dataList = new CustomSerializeArrayList();

            dataList = (CustomSerializeArrayList)addUpDataObj;

            // パラメータチェック
            if (addUpDataObj == null)
            {
                errMsg = ": パラメータが不正です。";
                return status;
            }
            else if ((int)ConstantManagement.MethodResult.ctFNC_NORMAL != CheckAddUpDataObj(ref dataList, out errMsg))
            {
                // データの中身チェック
                return status;
            }

            // 計上データの更新処理
            if ((int)ConstantManagement.MethodResult.ctFNC_NORMAL != this.AddPurchaseAddUpData(ref dataList, out errMsg))
            {
                return status;
            }

            // IOWrite制御ワークオブジェクトの追加セット
            IOWriteCtrlOptWork iOWriteCtrlOptWork = this.GetIOWriteCtrlOptWork();
            dataList.Add(iOWriteCtrlOptWork);

            // dataListをobjectに変更
            object inputData = dataList;

            // リモートオブジェクトのインスタンス取得
            if (this._iStockSlipRetPlnDB == null) this._iStockSlipRetPlnDB = (IStockSlipRetPlnDB)MediationStockSlipRetPlnDB.GetStockSlipRetPlnDB();

            // リモートの登録処理
            status = this._iStockSlipRetPlnDB.AddUp(ref inputData, out errMsg, out retItemInfo);

            return status;
        }

        /// <summary>
        /// 仕入返品予定データの計上前チェック処理を行います
        /// </summary>
        /// <param name="dataList">計上する仕入返品予定データ</param>
        /// <param name="errMsg">返却するエラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22 FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// </remarks>
        private int CheckAddUpDataObj(ref CustomSerializeArrayList dataList, out string errMsg)
        {
            // この時点でdataListは以下の構成になっている
            // 仕入リストに対して、「返品計上」「在庫登録」の2つ伝票となっているか
            // 同一伝票に「返品計上」「在庫登録」の明細が混在していないかをチェック
            //------------------------------------------------------------------------------------
            //  CustomSerializeArrayList            書き込みパラメータリスト
            //      --CustomSerializeArrayList      仕入リスト
            //          --StockSlipWork             仕入データオブジェクト
            //          --ArrayList                 仕入明細リスト
            //              --StockDetailWork       仕入明細データオブジェクト
            //          --ArrayList                 仕入明細追加情報リスト
            //              --SlipDetailAddInfoWork 仕入明細追加情報データオブジェクト
            //------------------------------------------------------------------------------------

            int ret = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            errMsg = string.Empty;

            try
            {
                bool isAddUpCheckingflg = false;

                #region チェック処理
                // データ取得(書き込みパラメータリストから)
                foreach (ArrayList PurchaseList in dataList)
                {
                    StockSlipWork stockSlip = new StockSlipWork();

                    // データ取得(仕入リストから)
                    foreach (object data in PurchaseList)
                    {
                        if (data is StockSlipWork) // 仕入伝票の場合
                        {
                            stockSlip = (StockSlipWork)data;

                            // 仕入返品予定データかチェック
                            if (stockSlip.SupplierFormal != 3)
                            {
                                errMsg = ": パラメータ不正（仕入伝票の仕入形式が不正）";
                                return ret;
                            }
                        }
                        else if (data is ArrayList && ((ArrayList)data)[0] != null && ((ArrayList)data)[0] is StockDetailWork)
                        {
                            // 1件目のデータを取得して仕入計上or在庫登録を判断
                            StockDetailWork firstStockDetailWork = new StockDetailWork();
                            firstStockDetailWork = ((ArrayList)data)[0] as StockDetailWork;

                            // 計上データチェック時:true 在庫データチェック時:false
                            isAddUpCheckingflg = string.IsNullOrEmpty(firstStockDetailWork.WarehouseCode.Trim());

                            // 倉庫コードが空の場合は配下の明細データが全て倉庫コードが空かチェック
                            foreach (StockDetailWork stockDetail in (ArrayList)data)
                            {
                                if (stockDetail.StockSlipCdDtl == 2)
                                {
                                    // 手数料明細は以降のチェックしない
                                    continue;
                                }

                                // 仕入形式・通番情報・倉庫コードをチェック
                                if (stockDetail.SupplierFormal != 3 || stockDetail.SupplierFormalSrc != -1)
                                {
                                    errMsg = ": パラメータ不正（仕入明細の仕入形式が不正）";
                                    return ret;
                                }
                                else if (stockDetail.SalesSlipDtlNumSync == 0)
                                {
                                    errMsg = ": パラメータ不正（売上明細通番（同時）情報が不正です）";
                                    return ret;
                                }
                                else if (stockDetail.StockSlipDtlNum == 0 || stockDetail.StockSlipDtlNumSrc == 0)
                                {
                                    errMsg = ": パラメータ不正（仕入明細通番情報が不正です）";
                                    return ret;
                                }
                                else if (isAddUpCheckingflg != string.IsNullOrEmpty(stockDetail.WarehouseCode.Trim()))
                                {
                                    errMsg = ": パラメータ不正（在庫登録データが混在しています）";
                                    return ret;
                                }
                            }
                        }
                        else if (data is ArrayList && ((ArrayList)data)[0] != null && ((ArrayList)data)[0] is SlipDetailAddInfoWork)
                        {
                            continue;
                        }
                        else
                        {
                            // データの形式が不正
                            errMsg = ": 仕入形式パラメータが不正です。";
                            return ret;
                        }
                    }
                }
                #endregion

                ret = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch
            {
                ret = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMsg = ": 仕入形式パラメータが不正です。";
            }

            return ret;
        }

        /// <summary>
        /// 計上対象の仕入返品予定データに必要なデータをセットします。
        /// </summary>
        /// <param name="dataList">計上する仕入返品予定データ</param>
        /// <param name="errMsg">返却するエラーメッセージ</param>
        /// <returns>0:正常終了 9:エラー</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22 FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// </remarks>
        private int AddPurchaseAddUpData(ref CustomSerializeArrayList dataList, out string errMsg)
        {
            // この時点でdataListは以下の構成になっている
            // 仕入リストに対して、伝票データ・明細データに値を格納する
            //------------------------------------------------------------------------------------
            //  CustomSerializeArrayList            書き込みパラメータリスト
            //      --CustomSerializeArrayList      仕入リスト
            //          --StockSlipWork             仕入データオブジェクト
            //          --ArrayList                 仕入明細リスト
            //              --StockDetailWork       仕入明細データオブジェクト
            //          --ArrayList                 仕入明細追加情報リスト
            //              --SlipDetailAddInfoWork 仕入明細追加情報データオブジェクト
            //------------------------------------------------------------------------------------

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            errMsg = string.Empty;

            // 伝票データ
            StockSlipWork stockSlip = null;
            // 明細追加情報リスト
            List<StockDetailWork> stockDetailList = null;
            List<SlipDetailAddInfoWork> slipDetailAddInfoWorkList = null;

            #region 値追加処理

            // データ取得(書き込みパラメータリストから)
            foreach (ArrayList PurchaseList in dataList)
            {
                // 伝票データ
                stockSlip = new StockSlipWork();

                // 明細情報リストをnew
                stockDetailList = new List<StockDetailWork>();
                slipDetailAddInfoWorkList = new List<SlipDetailAddInfoWork>();

                // データ取得(仕入リストから)
                foreach (object data in PurchaseList)
                {
                    if (data is StockSlipWork)
                    {
                        // 仕入伝票の場合
                        stockSlip = (StockSlipWork)data;

                        stockSlip.SupplierFormal = 0;           // 仕入形式:0
                        stockSlip.StockSlipUpdateCd = 0;        // 仕入伝票更新区分:0
                        stockSlip.InputDay = DateTime.Today;    // 入力日:システム時刻 

                        // 伝票発行区分
                        stockSlip.SlipPrintDivCd =
                            (stockSlip.SupplierSlipCd == 20 && this._stockTtlSt.RgdsSlipPrtDiv == 1) ? 1 : 0;

                        stockSlip.AutoPayment = 0;              // 自動支払区分:0
                    }
                    else if (data is ArrayList && ((ArrayList)data)[0] != null && ((ArrayList)data)[0] is StockDetailWork)
                    {
                        int index = 0;

                        // 明細データの場合
                        foreach (StockDetailWork stockDetail in (ArrayList)data)
                        {
                            // 仕入形式 (元も含む)をセット
                            stockDetail.SupplierFormalSrc = 0;
                            stockDetail.SupplierFormal = 0;     // 仕入形式:0

                            // 仕入在庫取寄せ区分(倉庫コード有:1(在庫) 無:0(取寄))
                            stockDetail.StockOrderDivCd = (string.IsNullOrEmpty(stockDetail.WarehouseCode.Trim())) ? 0 : 1;

                            // 明細関連付けGUID
                            stockDetail.DtlRelationGuid = Guid.NewGuid();

                            // 明細追加情報
                            SlipDetailAddInfoWork slipDetailAddInfoWork = new SlipDetailAddInfoWork();
                            slipDetailAddInfoWork.DtlRelationGuid = stockDetail.DtlRelationGuid;		// 明細関連付けGUID
                            slipDetailAddInfoWork.SlipDtlRegOrder = index + 1;
                            index++;

                            // 以下の条件を満たす場合は商品マスタ・価格マスタへ登録
                            // <条件>
                            // ・品番/メーカ/倉庫コードが格納されている
                            // ・売上全体設定マスタ.返品時在庫登録「0:する」
                            if (!string.IsNullOrEmpty(stockDetail.GoodsNo) &&
                                stockDetail.GoodsMakerCd != 0 &&
                                !string.IsNullOrEmpty(stockDetail.WarehouseCode) &&
                                (this._salesTtlSt != null && this._salesTtlSt.RetGoodsStockEtyDiv == 0))
                            {
                                slipDetailAddInfoWork.GoodsEntryDiv = 1; // 商品登録する
                                slipDetailAddInfoWork.PriceUpdateDiv = 1; // 価格更新する
                                slipDetailAddInfoWork.GoodsOfferDate = DateTime.MinValue;
                                slipDetailAddInfoWork.PriceStartDate = GetPriceStartDate(stockSlip);
                                slipDetailAddInfoWork.PriceOfferDate = DateTime.MinValue;
                            }
                            else
                            {
                                slipDetailAddInfoWork.GoodsEntryDiv = 0; // 商品登録しない
                                slipDetailAddInfoWork.PriceUpdateDiv = 0; // 価格更新しない
                                slipDetailAddInfoWork.GoodsOfferDate = DateTime.MinValue;
                                slipDetailAddInfoWork.PriceStartDate = DateTime.MinValue;
                                slipDetailAddInfoWork.PriceOfferDate = DateTime.MinValue;
                            }

                            slipDetailAddInfoWorkList.Add(slipDetailAddInfoWork);
                        }
                    }
                    else if (data is ArrayList && ((ArrayList)data)[0] != null && ((ArrayList)data)[0] is SlipDetailAddInfoWork)
                    {
                        int index = 0;

                        if (((ArrayList)data).Count == slipDetailAddInfoWorkList.Count)
                        {
                            for (index = 0; ((ArrayList)data).Count > index; index++)
                            {
                                // 元の仕入リストに格納しなおす
                                SlipDetailAddInfoWork slipDetailAddInfoWorkSrc = ((ArrayList)data)[index] as SlipDetailAddInfoWork;
                                slipDetailAddInfoWorkSrc.GoodsEntryDiv = slipDetailAddInfoWorkList[index].GoodsEntryDiv;
                                slipDetailAddInfoWorkSrc.PriceUpdateDiv = slipDetailAddInfoWorkList[index].PriceUpdateDiv;
                                slipDetailAddInfoWorkSrc.GoodsOfferDate = slipDetailAddInfoWorkList[index].GoodsOfferDate;
                                slipDetailAddInfoWorkSrc.PriceStartDate = slipDetailAddInfoWorkList[index].PriceStartDate;
                                slipDetailAddInfoWorkSrc.PriceOfferDate = slipDetailAddInfoWorkList[index].PriceOfferDate;
                                slipDetailAddInfoWorkSrc.DtlRelationGuid = slipDetailAddInfoWorkList[index].DtlRelationGuid;
                                slipDetailAddInfoWorkSrc.SlipDtlRegOrder = slipDetailAddInfoWorkList[index].SlipDtlRegOrder;
                            }
                        }
                    }
                    else
                    {
                        // データの形式が不正
                        errMsg = ": 仕入形式パラメータが不正です。";
                        return status;
                    }
                }
            }
            #endregion

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        #endregion[計上処理]

        #region[その他処理]

        /// <summary>
        /// 売上・仕入全体設定マスタを取得します。
        /// </summary>
        /// <remarks>
        /// <br>Note        : 2013/01/22 FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// </remarks>
        private void GetTtlSt()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
         
            // 売上全体設定マスタ
            ArrayList retSalesTtlSt;
            SalesTtlStAcs salesTtlStAcs = new SalesTtlStAcs();

            status = salesTtlStAcs.SearchAll(out retSalesTtlSt, this._enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._salesTtlSt = this.GetSalesTtlStFromList(LoginInfoAcquisition.Employee.BelongSectionCode, retSalesTtlSt);
            }
            else
            {
                this._salesTtlSt = null;
            }

            // 仕入全体マスタ取得
            ArrayList retStockTtlSt;
            StockTtlStAcs stockTtlStAcs = new StockTtlStAcs();

            status = stockTtlStAcs.Search(out retStockTtlSt, this._enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._stockTtlSt = this.GetStockTtlStFromList(LoginInfoAcquisition.Employee.BelongSectionCode, retStockTtlSt);
            }
            else
            {
                this._stockTtlSt = null;
            }

            return;
        }
        #endregion

        #region[流用メソッド]
        /// <summary>
        /// IOWriter制御オプションワーク取得処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22 FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// <br>              MAKON01112AA.cs より流用</br>
        /// </remarks>
        private IOWriteCtrlOptWork GetIOWriteCtrlOptWork()
        {
            IOWriteCtrlOptWork iOWriteCtrlOptWork = new IOWriteCtrlOptWork();

            iOWriteCtrlOptWork.EnterpriseCode = this._enterpriseCode;

            iOWriteCtrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Purchase;							// 制御起点：仕入
            if (this.GetSalesTtlSt() != null)
            {
                iOWriteCtrlOptWork.ShipmAddUpRemDiv = this.GetSalesTtlSt().ShipmAddUpRemDiv;			// 出荷データ計上残区分(売上全体設定マスタより)
            }

            if (this.GetSalesTtlSt() != null)
            {
                iOWriteCtrlOptWork.AcpOdrrAddUpRemDiv = this.GetSalesTtlSt().AcpOdrrAddUpRemDiv;		// 受注データ計上残区分(売上全体設定マスタより)
            }

            // 残数管理区分は「する」固定
            iOWriteCtrlOptWork.RemainCntMngDiv = 0;
            //if (this._stockSlipInputInitDataAcs.GetAllDefSet() != null)
            //{
            //    iOWriteCtrlOptWork.RemainCntMngDiv = this._stockSlipInputInitDataAcs.GetAllDefSet().RemainCntMngDiv;			// 残数管理区分(全体初期値設定より)
            //}

            return iOWriteCtrlOptWork;
        }

        /// <summary>
        /// 売上全体設定マスタのリスト中から、指定した拠点の設定を取得します。
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="salesTtlStStArrayList">売上全体設定マスタオブジェクトリスト</param>
        /// <returns>売上全体設定マスタオブジェクト</returns>
        private SalesTtlSt GetSalesTtlStFromList(string sectionCode, ArrayList salesTtlStStArrayList)
        {
            SalesTtlSt allSecSalesTtlSt = null;

            foreach (SalesTtlSt salesTtlSt in salesTtlStStArrayList)
            {
                if (salesTtlSt.SectionCode.Trim() == sectionCode.Trim())
                {
                    return salesTtlSt;
                }
                else if (salesTtlSt.SectionCode.Trim() == ctSectionCode_Common.Trim())
                {
                    allSecSalesTtlSt = salesTtlSt;
                }
            }

            return allSecSalesTtlSt;
        }

        /// <summary>
        /// 商品データリスト生成処理
        /// </summary>
        /// <param name="goodsCndtnList">商品検索条件リスト</param>
        /// <param name="goodsUnitDataList">商品リスト</param>
        /// <param name="message">拠点コード</param>
        /// <returns>検索ステータス(ConstantManagement.MethodResult)</returns>
        private int GetGoodsUnitDataList(List<GoodsCndtn> goodsCndtnList, out List<GoodsUnitData> goodsUnitDataList, out string message)
        {
            message = string.Empty;

            goodsUnitDataList = new List<GoodsUnitData>();

            List<List<GoodsUnitData>> goodsUnitDataListRet;

            int status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataListRet, out message);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {

                foreach (GoodsCndtn goodsCndtn in goodsCndtnList)
                {
                    foreach (List<GoodsUnitData> goodsUnitDataListWk in goodsUnitDataListRet)
                    {
                        bool findGoods = false;
                        foreach (GoodsUnitData goodsUnitData in goodsUnitDataListWk)
                        {
                            if ((goodsCndtn.GoodsNo == goodsUnitData.GoodsNo) &&
                                (goodsCndtn.GoodsMakerCd == goodsUnitData.GoodsMakerCd))
                            {
                                goodsUnitDataList.Add(goodsUnitData);
                                findGoods = true;
                                break;
                            }
                        }
                        if (findGoods) break;
                    }
                }
            }
            return status;
        }

        /// <summary>
        /// 価格開始日取得処理
        /// </summary>
        /// <param name="stockSlip"></param>
        /// <returns></returns>
        private DateTime GetPriceStartDate(StockSlipWork stockSlip)
        {
            try
            {
                //--------------------------------------------------
                // 通常は、前回月次更新日の翌日
                //--------------------------------------------------
                DateTime prevTotalDay = GetHisTotalDayMonthly();
                if (prevTotalDay != DateTime.MinValue)
                {
                    // 前回月次更新日の翌日
                    return prevTotalDay.AddDays(1);
                }

                //--------------------------------------------------
                // （※新規搬入して一度も月次更新をしていないような場合）自社.期首日
                //--------------------------------------------------
                if (_dateGetAcs == null)
                {
                    _dateGetAcs = DateGetAcs.GetInstance();
                }
                else
                {
                    _dateGetAcs.ReloadCompanyInf(); // 必ず再取得する
                }
                List<DateTime> startMonthDateList;
                List<DateTime> endMonthDateList;

                CompanyInf companyInf = _dateGetAcs.GetCompanyInf();
                if (companyInf != null && companyInf.CompanyBiginDate != 0)
                {
                    _dateGetAcs.GetFinancialYearTable(out startMonthDateList, out endMonthDateList);
                    if (startMonthDateList != null && startMonthDateList.Count > 0)
                    {
                        // 期首日←最初の月の開始日
                        return startMonthDateList[0];
                    }
                }
            }
            catch
            {
            }

            //--------------------------------------------------
            // ※通常は発生しないが前回月次更新日も期首日も取得できない場合は、
            // 　仕様変更前と同様に、仕入日or入荷日をセットする。
            //--------------------------------------------------
            return (stockSlip.SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay;
        }

        /// <summary>
        /// 商品連結データリストより、指定された商品の情報を取得します。
        /// </summary>
        /// <param name="goodsNo">商品コード</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="goodsUnitDataList">商品情報データリスト</param>
        /// <returns>商品情報データ</returns>
        private GoodsUnitData GetGoodsUnitDataFromList(string goodsNo, int goodsMakerCd, List<GoodsUnitData> goodsUnitDataList)
        {
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                if ((goodsUnitData.GoodsMakerCd == goodsMakerCd) && (goodsUnitData.GoodsNo == goodsNo))
                {
                    return goodsUnitData;
                }
            }
            return null;
        }

        /// <summary>
        /// 商品連結データの商品価格リストから、対象日の商品価格情報を取得します。
        /// </summary>
        /// <param name="targetDate">対象日付</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>商品価格データ</returns>
        private GoodsPrice GetGoodsPrice(DateTime targetDate, GoodsUnitData goodsUnitData)
        {
            return this._goodsAcs.GetGoodsPriceFromGoodsPriceList(targetDate, goodsUnitData.GoodsPriceList);
        }

        /// <summary>
        /// 仕入全体設定マスタのリスト中から、指定した拠点の設定を取得します。
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="stockTtlStArrayList">仕入全体設定マスタオブジェクトリスト</param>
        /// <returns>仕入全体設定マスタオブジェクト</returns>
        private StockTtlSt GetStockTtlStFromList(string sectionCode, ArrayList stockTtlStArrayList)
        {
            StockTtlSt allSecStockTtlSt = null;

            foreach (StockTtlSt stockTtlSt in stockTtlStArrayList)
            {
                if (stockTtlSt.SectionCode.Trim() == sectionCode.Trim())
                {
                    return stockTtlSt;
                }
                else if (stockTtlSt.SectionCode.Trim() == "00")
                {
                    allSecStockTtlSt = stockTtlSt;
                }
            }
            return allSecStockTtlSt;
        }

        #endregion

        #endregion

    }
}
