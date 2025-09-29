//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 仕入履歴照会
// プログラム概要   : 仕入履歴照会を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/09  修正内容 : 障害対応13014
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/15  修正内容 : 障害対応13180
//----------------------------------------------------------------------------//

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
    /// </remarks>
    public class DCKOU04102AA
    {
        # region ■Private Member
        /// <summary>リモートオブジェクト格納バッファ</summary>
        private IStcHisRefDataDB _iStcHisRefDataDB = null;
        /// <summary>拠点オプションフラグ</summary>
        private bool _optSection;
		// 拠点アクセスクラス
        //private static SecInfoAcs _secInfoAcs;													
        private StockDataSet _dataSet;
        private static StockDataSet.StockSlipDataTable _stockSlipCache;
        private static StcHisRefExtraParamWork _paraStockSlipCache;
        private static SortedList _nameList;
        private static DCKOU04102AA _searchSlipAcs;

        private string _enterpriseCode;             // 企業コード
        private const string MESSAGE_NoResult = "検索条件に一致する伝票は存在しません。";
        private const string MESSAGE_ErrResult = "伝票情報の取得に失敗しました。";
        private const string MESSAGE_NONOWNSECTION = "自拠点情報が取得できませんでした。拠点設定を行ってから起動してください。";
		private const string ct_DateFormat = "yyyy/MM/dd";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
        private int _maxSelectCount;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD

        // ADD 2009/04/09 ------>>>
        private SubSectionAcs _subSectionAcs;
        private Dictionary<int, SubSection> _subSectionDic;
        // ADD 2009/04/09 ------<<<
        
        # endregion

		// デリゲート処理
        public event GetNameListEventHandler GetNameList;
        public delegate SortedList GetNameListEventHandler();

        public event SettingStatusBarMessageEventHandler StatusBarMessageSetting;
        public delegate void SettingStatusBarMessageEventHandler(object sender, string message);

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
        // 行選択状態変更イベント
        /// <summary>行選択状態変更イベント</summary>
        public event SelectedDataChangeEventHandler SelectedDataChange;
        public delegate void SelectedDataChangeEventHandler( object sender, bool status, int count );
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD

        # region ■Constracter
        /// <summary>
        /// 伝票検索 テーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品大分類マスタ テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 980023 飯谷  耕平</br>
        /// <br>Date       : 2006.12.04</br>
        /// </remarks>
        public DCKOU04102AA()
        {
            //　企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            
            // 拠点OPの判定
            this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);
            this._dataSet = new StockDataSet();
            //this._stockDetailDBDataList = new List<StockDetail>();
            //this._stockSlipInputAcs = StockSlipInputAcs.GetInstance();

            // ADD 2009/04/09 ------>>>
            this._subSectionAcs = new SubSectionAcs();
            ReadSubSection();
            // ADD 2009/04/09 ------<<<
            
            // ログイン部品で通信状態を確認
            if (LoginInfoAcquisition.OnlineFlag)
            {
                try
                {
                    // リモートオブジェクト取得
					this._iStcHisRefDataDB = (IStcHisRefDataDB)MediationStcHisRefDataDB.GetStcHisRefDataDB();
                }
                catch (Exception)
                {
                    //オフライン時はnullをセット
                    this._iStcHisRefDataDB = null;
                }
            }
            else
            {
                // オフライン時のデータ読み込み
                //this.SearchOfflineData();
                MessageBox.Show("オフライン状態のため検索が実行できません。");
            }
        }
        # endregion

        /// <summary>
        /// 伝票検索アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>伝票検索アクセスクラス インスタンス</returns>
        public static DCKOU04102AA GetInstance()
        {
            if (_searchSlipAcs == null)
            {
                _searchSlipAcs = new DCKOU04102AA();
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

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
        /// <summary>
        /// 選択可能明細数 プロパティ
        /// </summary>
        public int MaxSelectCount
        {
            get { return _maxSelectCount; }
            set { _maxSelectCount = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD

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
            if (this._iStcHisRefDataDB == null)
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
                _stockSlipCache = new StockDataSet.StockSlipDataTable();
            }

            this._dataSet.StockSlip.AcceptChanges();
            _stockSlipCache = (StockDataSet.StockSlipDataTable)this._dataSet.StockSlip.Copy();
        }

        /// <summary>
        /// 検索条件クラス(再表示用) キャッシュ処理
        /// </summary>
        private void CacheParaStockSlip(StcHisRefExtraParamWork stcHisRefExtraParamWork)
        {
            // 検索条件値
            if (_paraStockSlipCache == null)
            {
                _paraStockSlipCache = new StcHisRefExtraParamWork();
            }
            _paraStockSlipCache = stcHisRefExtraParamWork;

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

        // ADD 2009/04/09 ------>>>
        private void ReadSubSection()
        {
            this._subSectionDic = new Dictionary<int, SubSection>();

            ArrayList retList;

            int status = this._subSectionAcs.SearchAll(out retList, this._enterpriseCode);
            if (status == 0)
            {
                foreach (SubSection subSection in retList)
                {
                    if (subSection.LogicalDeleteCode == 0)
                    {
                        this._subSectionDic.Add(subSection.SubSectionCode, subSection);
                    }
                }
            }
        }
        // ADD 2009/04/09 ------<<<
        
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
        /// </remarks>
        public int SetSearchData(StcHisRefExtraParamWork stcHisRefExtraParamWork)
        {
            List<StcHisRefDataWork> retData;
			string supplierFormalName = "";
			string supplierSlipCdName = "";
			string accPayDivCdName = "";
			string arrivalGoodsDayString = "";
			string stockDateString = "";
			string memoExistName = "";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.29 TOKUNAGA ADD START
            string debitNoteName = "";                  // 赤伝区分名
            string stockGoodsCdName = "";               // 商品区分名
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.29 TOKUNAGA ADD END

			long stockPriceTaxExc = 0;
			long stockPriceConsTax = 0;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/05 ADD
            long stockPriceTaxInc = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/05 ADD
            
            int status = this.Search(out retData, stcHisRefExtraParamWork);

            // 仕入形式
            List<string> SupplierFormalList = new List<string>();
            SupplierFormalList.Add("仕入");
            SupplierFormalList.Add("入荷");

            // 買掛区分    
            List<string> AccPayDivCdList = new List<string>();
            AccPayDivCdList.Add("買掛管理しない");
            AccPayDivCdList.Add("買掛管理する");

            this.ClearStockSlipDataTable();

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                for (int i = 0; i < retData.Count; i++)
                {
                    StcHisRefDataWork stcHisRefDataWork = retData[i];

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/05 DEL
                    ////消費税調整・残高調整
                    //if ((stcHisRefDataWork.StockGoodsCd == 2) || (stcHisRefDataWork.StockGoodsCd == 4))
                    //{
                    //    stockPriceTaxExc = 0;
                    //    stockPriceConsTax = stcHisRefDataWork.StockPriceConsTax;
                    //}

                    //else if ((stcHisRefDataWork.StockGoodsCd == 3) || (stcHisRefDataWork.StockGoodsCd == 5))
                    //{
                    //    stockPriceTaxExc = stcHisRefDataWork.StockPriceTaxInc;
                    //    stockPriceConsTax = 0;
                    //}
                    //else
                    //{
                    //    stockPriceTaxExc = stcHisRefDataWork.StockPriceTaxExc;
                    //    stockPriceConsTax = stcHisRefDataWork.StockPriceConsTax;
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/05 DEL

					//仕入形式
					if (stcHisRefDataWork.SupplierFormal == 0)
					{
						supplierFormalName = "仕入";
					}
					else
					{
						supplierFormalName = "入荷";
					}

					//仕入伝票区分
					if (stcHisRefDataWork.SupplierSlipCd == 10)
					{
                        // --- DEL 2009/01/23 -------------------------------->>>>>
                        //if (stcHisRefDataWork.AccPayDivCd == 0)
                        //{
                        //    supplierSlipCdName = "現金仕入";
                        //}
                        //else
                        //{
                        //    supplierSlipCdName = "掛仕入";
                        //}
                        // --- DEL 2009/01/23 --------------------------------<<<<<
                        supplierSlipCdName = "仕入";
					}
					else
					{
                        // --- DEL 2009/01/23 -------------------------------->>>>>
                        //if (stcHisRefDataWork.AccPayDivCd == 0)
                        //{
                        //    supplierSlipCdName = "現金返品";
                        //}
                        //else
                        //{
                        //    supplierSlipCdName = "掛返品";
                        //}
                        // --- DEL 2009/01/23 --------------------------------<<<<<
                        supplierSlipCdName = "返品"; 
					}

					//買掛区分
					if (stcHisRefDataWork.AccPayDivCd == 0)
					{
						accPayDivCdName = "買掛なし";
					}
					else
					{
						accPayDivCdName = "買掛あり";
					}

					//入荷日
					arrivalGoodsDayString = GetDateTimeString(stcHisRefDataWork.ArrivalGoodsDay, ct_DateFormat);

					//仕入日
					stockDateString = GetDateTimeString(stcHisRefDataWork.StockDate, ct_DateFormat);

                    // 赤黒
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.29 TOKUNAGA ADD START
                    switch (stcHisRefDataWork.DebitNoteDiv)
                    {
                        case 0: debitNoteName = "黒伝"; break;
                        case 1: debitNoteName = "赤伝"; break;
                        case 2: debitNoteName = "元黒"; break;
                    }

                    switch (stcHisRefDataWork.StockGoodsCd)
                    {
                        case 0: stockGoodsCdName = "商品"; break;
                        case 1: stockGoodsCdName = "商品外"; break;
                        case 2: stockGoodsCdName = "消費税調整"; break;
                        case 3: stockGoodsCdName = "残高調整"; break;
                        case 4: stockGoodsCdName = "買掛用消費税調整"; break;
                        case 5: stockGoodsCdName = "買掛用残高調整"; break;
                        case 6: stockGoodsCdName = "合計入力"; break;
                        case 10: stockGoodsCdName = "買用消費税調整(自動)"; break;
                        case 11: stockGoodsCdName = "相殺"; break;
                        case 12: stockGoodsCdName = "相殺(自動)"; break;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.29 TOKUNAGA ADD END

					//メモ存在
					if(stcHisRefDataWork.MemoExist != 0)
					{
						memoExistName = "○";
					}
					else
					{
						memoExistName = "";
					}

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/05 DEL
                    # region // DEL
                    //_dataSet.StockSlip.AddStockSlipRow(i + 1, 
                    //                                    false,//stcHisRefDataWork.PrintFlag, 
                    //                                    stcHisRefDataWork.EnterpriseCode,
                    //                                    stcHisRefDataWork.SupplierFormal, 
                    //                                    supplierFormalName,//stcHisRefDataWork.SupplierFomalName, 
                    //                                    stcHisRefDataWork.SupplierSlipNo, 
                    //                                    stcHisRefDataWork.SectionCode, 
                    //                                    stcHisRefDataWork.SectionGuideNm, 
                    //                                    stcHisRefDataWork.SupplierSlipCd,
                    //                                    supplierSlipCdName,//stcHisRefDataWork.SupplierSlipCdName, 
                    //                                    stcHisRefDataWork.AccPayDivCd,
                    //                                    accPayDivCdName,//stcHisRefDataWork.AccPayDivCdName, 
                    //                                    stcHisRefDataWork.ArrivalGoodsDay,
                    //                                    arrivalGoodsDayString,//stcHisRefDataWork.ArrivalGoodsDayString, 
                    //                                    stcHisRefDataWork.StockDate,
                    //                                    stockDateString,//stcHisRefDataWork.StockDateString, 
                    //                                    stcHisRefDataWork.StockInputCode, 
                    //                                    stcHisRefDataWork.StockInputName, 
                    //                                    stcHisRefDataWork.StockAgentCode, 
                    //                                    stcHisRefDataWork.StockAgentName, 
                    //                                    //stcHisRefDataWork.CustomerCode, 
                    //                                    //stcHisRefDataWork.CustomerName, 
                    //                                    //stcHisRefDataWork.CustomerName2, 
                    //                                    //stcHisRefDataWork.CustomerSnm, 
                    //                                    stcHisRefDataWork.PartySaleSlipNum, 
                    //                                    stcHisRefDataWork.StockRowNo, 
                    //                                    stcHisRefDataWork.CommonSeqNo, 
                    //                                    stcHisRefDataWork.StockSlipDtlNum, 
                    //                                    stcHisRefDataWork.GoodsMakerCd, 
                    //                                    stcHisRefDataWork.MakerName, 
                    //                                    stcHisRefDataWork.GoodsNo, 
                    //                                    stcHisRefDataWork.GoodsName, 
                    //                                    //stcHisRefDataWork.ListPriceFl, 
                    //                                    stcHisRefDataWork.StockUnitPriceFl, 
                    //                                    stcHisRefDataWork.StockCount, 
                    //                                    stockPriceTaxExc,
                    //                                    stockPriceConsTax,
                    //                                    //stcHisRefDataWork.UnitCode, 
                    //                                    //stcHisRefDataWork.UnitName, 
                    //                                    stcHisRefDataWork.WarehouseCode, 
                    //                                    stcHisRefDataWork.WarehouseName, 
                    //                                    stcHisRefDataWork.WarehouseShelfNo, 
                    //                                    stcHisRefDataWork.SupplierCd, 
                    //                                    stcHisRefDataWork.SupplierSnm, 
                    //                                    stcHisRefDataWork.OrderNumber, 
                    //                                    //stcHisRefDataWork.OrderCnt,
                    //                                    //stcHisRefDataWork.OrderCnt + stcHisRefDataWork.OrderAdjustCnt,
                    //                                    //stcHisRefDataWork.OrderAdjustCnt, 
                    //                                    //stcHisRefDataWork.OrderRemainCnt, 
                    //                                    stcHisRefDataWork.StockDtiSlipNote1,
                    //                                    stcHisRefDataWork.SalesCustomerCode,
                    //                                    //.CustomerCode,	//販売先コード
                    //                                    stcHisRefDataWork.SalesCustomerSnm,
                    //                                    //.CustomerSnm,	//販売先略称
                    //                                    stcHisRefDataWork.MemoExist,
                    //                                    memoExistName,//stcHisRefDataWork.MemoExistName, 
                    //                                    stcHisRefDataWork.SlipMemo1, 
                    //                                    stcHisRefDataWork.SlipMemo2, 
                    //                                    stcHisRefDataWork.SlipMemo3, 
                    //                                    //stcHisRefDataWork.SlipMemo4, 
                    //                                    //stcHisRefDataWork.SlipMemo5, 
                    //                                    //stcHisRefDataWork.SlipMemo6, 
                    //                                    stcHisRefDataWork.InsideMemo1, 
                    //                                    stcHisRefDataWork.InsideMemo2, 
                    //                                    stcHisRefDataWork.InsideMemo3,
                    //                                    stcHisRefDataWork.BLGoodsCode,
                    //                                    stcHisRefDataWork.ListPriceTaxExcFl,
                    //                                    stcHisRefDataWork.DebitNoteDiv,
                    //                                    debitNoteName,  // 赤黒
                    //                                    stcHisRefDataWork.InputDay,
                    //                                    stcHisRefDataWork.StockAddUpADate,
                    //                                    stcHisRefDataWork.PayeeCode,
                    //                                    stcHisRefDataWork.PayeeSnm,
                    //                                    stockGoodsCdName
                    //                                    //stcHisRefDataWork.InsideMemo4, 
                    //                                    //stcHisRefDataWork.InsideMemo5, 
                    //                                    //stcHisRefDataWork.InsideMemo6
                    //                                   );
                    # endregion
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/05 DEL

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/05 ADD
                    // 消費税表示対応

                    stockPriceTaxExc = stcHisRefDataWork.StockPriceTaxExc;
                    stockPriceConsTax = stcHisRefDataWork.StockPriceTaxInc - stcHisRefDataWork.StockPriceTaxExc;
                    stockPriceTaxInc = stcHisRefDataWork.StockPriceTaxInc;

                    // 設定適用
                    ReflectMoneyForTaxPrint( ref stockPriceTaxExc, ref stockPriceConsTax, ref stockPriceTaxInc, stcHisRefDataWork.SuppTtlAmntDspWayCd, stcHisRefDataWork.SuppCTaxLayCd, stcHisRefDataWork.TaxationCode );

                    # region [商品区分]
                    switch ( stcHisRefDataWork.StockGoodsCd )
                    {
                        case 2:
                        case 4:
                            // 2:消費税調整,4:売掛用消費税調整
                            stockPriceTaxExc = 0;
                            break;
                        case 3:
                        case 5:
                            // 3:残高調整,5:売掛用残高調整
                            stockPriceTaxExc = stockPriceTaxInc;
                            stockPriceConsTax = 0;
                            break;
                        default:
                            break;
                    }
                    # endregion
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/05 ADD
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/05 ADD
                    StockDataSet.StockSlipRow row = _dataSet.StockSlip.NewStockSlipRow();

                    # region [row]
                    row.EnterpriseCode = stcHisRefDataWork.EnterpriseCode;
                    row.SupplierFormal = stcHisRefDataWork.SupplierFormal;
                    row.SupplierSlipNo = stcHisRefDataWork.SupplierSlipNo;
                    row.SectionCode = stcHisRefDataWork.SectionCode;
                    row.SectionGuideNm = stcHisRefDataWork.SectionGuideNm;
                    row.SupplierSlipCd = stcHisRefDataWork.SupplierSlipCd;
                    row.AccPayDivCd = stcHisRefDataWork.AccPayDivCd;
                    row.ArrivalGoodsDay = stcHisRefDataWork.ArrivalGoodsDay;
                    row.StockDate = stcHisRefDataWork.StockDate;
                    row.StockInputCode = stcHisRefDataWork.StockInputCode;
                    row.StockInputName = stcHisRefDataWork.StockInputName;
                    row.StockAgentCode = stcHisRefDataWork.StockAgentCode;
                    row.StockAgentName = stcHisRefDataWork.StockAgentName;
                    row.PartySaleSlipNum = stcHisRefDataWork.PartySaleSlipNum;
                    row.StockRowNo = stcHisRefDataWork.StockRowNo;
                    row.CommonSeqNo = stcHisRefDataWork.CommonSeqNo;
                    row.StockSlipDtlNum = stcHisRefDataWork.StockSlipDtlNum;
                    row.GoodsMakerCd = stcHisRefDataWork.GoodsMakerCd;
                    row.MakerName = stcHisRefDataWork.MakerName;
                    row.GoodsNo = stcHisRefDataWork.GoodsNo;
                    row.GoodsName = stcHisRefDataWork.GoodsName;
                    row.StockUnitPriceFl = stcHisRefDataWork.StockUnitPriceFl;
                    row.StockCount = stcHisRefDataWork.StockCount;
                    row.WarehouseCode = stcHisRefDataWork.WarehouseCode;
                    row.WarehouseName = stcHisRefDataWork.WarehouseName;
                    row.WarehouseShelfNo = stcHisRefDataWork.WarehouseShelfNo;
                    row.SupplierCd = stcHisRefDataWork.SupplierCd;
                    row.SupplierSnm = stcHisRefDataWork.SupplierSnm;
                    row.OrderNumber = stcHisRefDataWork.OrderNumber;
                    row.StockDtiSlipNote1 = stcHisRefDataWork.StockDtiSlipNote1;
                    row.SalesCustomerCode = stcHisRefDataWork.SalesCustomerCode;
                    row.SalesCustomerSnm = stcHisRefDataWork.SalesCustomerSnm;
                    row.MemoExist = stcHisRefDataWork.MemoExist;
                    row.SlipMemo1 = stcHisRefDataWork.SlipMemo1;
                    row.SlipMemo2 = stcHisRefDataWork.SlipMemo2;
                    row.SlipMemo3 = stcHisRefDataWork.SlipMemo3;
                    row.InsideMemo1 = stcHisRefDataWork.InsideMemo1;
                    row.InsideMemo2 = stcHisRefDataWork.InsideMemo2;
                    row.InsideMemo3 = stcHisRefDataWork.InsideMemo3;
                    row.BLGoodsCode = stcHisRefDataWork.BLGoodsCode;
                    row.ListPriceTaxExcFl = stcHisRefDataWork.ListPriceTaxExcFl;
                    row.DebitNoteDiv = stcHisRefDataWork.DebitNoteDiv;
                    row.InputDay = stcHisRefDataWork.InputDay;
                    // --- CHG 2009/02/24 障害ID:11873対応------------------------------------------------------>>>>>
                    //row.StockAddUpADate = stcHisRefDataWork.StockAddUpADate;
                    if (stcHisRefDataWork.StockAddUpADate != DateTime.MinValue)
                    {
                        row.StockAddUpADate = stcHisRefDataWork.StockAddUpADate;
                    }
                    // --- CHG 2009/02/24 障害ID:11873対応------------------------------------------------------<<<<<
                    row.PayeeCode = stcHisRefDataWork.PayeeCode;
                    row.PayeeSnm = stcHisRefDataWork.PayeeSnm;
                    row.SubSectionName = GetSubSectionName(stcHisRefDataWork.SubSectionCode);  // ADD 2009/04/09
                    # endregion

                    # region [row(手動)]
                    row.No = i + 1;
                    row.PrintFlag = false;
                    row.SupplierFormalName = supplierFormalName;
                    row.SupplierSlipCdName = supplierSlipCdName;
                    row.AccPayDivCdName = accPayDivCdName;
                    row.ArrivalGoodsDayString = arrivalGoodsDayString;
                    row.StockDateString = stockDateString;
                    row.StockPriceTaxExc = stockPriceTaxExc;
                    row.StockPriceConsTax = stockPriceConsTax;
                    row.DebitNoteDivName = debitNoteName;
                    row.StockGoodsCdName = stockGoodsCdName;
                    row.MemoExistName = memoExistName;
                    # endregion

                    _dataSet.StockSlip.AddStockSlipRow( row );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/05 ADD
				}

                // 検索データのキャッシュ
                this.CacheStockSlipTable();

                // 検索条件のキャッシュ
                this.CacheParaStockSlip(stcHisRefExtraParamWork);
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
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/05 ADD
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
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/05 ADD

        /// <summary>
        /// データセットクリア処理
        /// </summary>
        public void ClearStockSlipDataTable()
        {
            this._dataSet.StockSlip.Rows.Clear();

            // キャッシュデータの取り直し(クリア状態にする)
            this.CacheStockSlipTable();
            this.CacheParaStockSlip(null);
        }
        
        /// <summary>
        /// 伝票情報 読み込み処理
        /// </summary>
        /// <param name="stockSlipWorks">仕入データ オブジェクト配列</param>
        /// <param name="stcHisRefExtraParamWork">仕入伝票検索パラメータクラス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 伝票情報を読み込みます。</br>
        /// <br>Programmer : 980023 飯谷  飯谷</br>
        /// <br>Date       : 2007.01.29</br>
        /// </remarks>
        public int Search(out List<StcHisRefDataWork> stcHisRefDataWorkList, StcHisRefExtraParamWork stcHisRefExtraParamWork)
        {
            try
            {
                int status;
                stcHisRefDataWorkList = new List<StcHisRefDataWork>();

                // オンラインの場合リモート取得
                if (LoginInfoAcquisition.OnlineFlag)
                {
                    CustomSerializeArrayList paraList = new CustomSerializeArrayList();
					paraList.Add(stcHisRefExtraParamWork);

                    //CustomSerializeArrayList retList = new CustomSerializeArrayList();
					ArrayList retList = new ArrayList();

                    object paraObj = (object)paraList;
                    object retObj = (object)retList;

                    //伝票情報取得
                    status = this._iStcHisRefDataDB.Search( out retObj, paraObj );
                    
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        int setCount = 0;
                        //retList = (CustomSerializeArrayList)retObj;
						retList = (ArrayList)retObj;
						for (int i = 0; i < retList.Count; i++)
                        {
                            stcHisRefDataWorkList.Add((StcHisRefDataWork)retList[i]);
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
                }
                else	// オフラインの場合
                {
                    //status = ReadStaticMemory(out lgoodsganre, enterpriseCode, largeGoodsGanreCode);
                    status = -1;
                }

                return status;
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );

                stcHisRefDataWorkList = null;
                //オフライン時はnullをセット
                this._iStcHisRefDataDB= null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 伝票データテーブルキャッシュ取得処理
        /// </summary>
        /// <returns>伝票データテーブルキャッシュ</returns>
        public StockDataSet.StockSlipDataTable GetStockSlipTableCache()
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
        public StcHisRefExtraParamWork GetParaStockSlipCache()
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
			DataRow _row = this._dataSet.StockSlip.Rows.Find(_uniqueID);

			// 一致する行が存在する！
			if (_row != null)
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 DEL
                //bool printFlag = (bool)_row[this._dataSet.StockSlip.PrintFlagColumn.ColumnName];

                //_row.BeginEdit();
                //_row[this._dataSet.StockSlip.PrintFlagColumn.ColumnName] = !printFlag;
                //_row.EndEdit();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
                bool printFlag = (bool)_row[this._dataSet.StockSlip.PrintFlagColumn.ColumnName];
                SelectedPrintRow( ref _row, !printFlag );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD
			}
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
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
                bool prevPrintFlag = (bool)row[this._dataSet.StockSlip.PrintFlagColumn.ColumnName];

                // 変更可
                checkResult = true;
                // 変更
                row.BeginEdit();
                row[this._dataSet.StockSlip.PrintFlagColumn.ColumnName] = selected;
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
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD

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
        public bool SelectedPrintRow(int _uniqueID, bool selected)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 DEL
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
            bool result = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD

			// ------------------------------------------------------------//
			// Find メソッドを使う但し、Viewのソート順を変更したくない為、 //
			// DataTableに更新をかける。                                   //
			// ------------------------------------------------------------//
			DataRow _row = this._dataSet.StockSlip.Rows.Find(_uniqueID);

			// 一致する行が存在する！
			if (_row != null)
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
			DataView StockSlipView = new DataView(this._dataSet.StockSlip);
			StockSlipView.RowFilter = String.Format("{0} = {1}", this._dataSet.StockSlip.PrintFlagColumn.ColumnName, true);
			return (StockSlipView.Count);
		}

		/// <summary>
        /// 選択行テーブルデータ取得処理＜複数行選択＞
        /// </summary>
        /// <param name="getRowNo">グリッド選択RowNo</param>
        /// <returns>仕入データクラス</returns>
        /// <remarks>
        /// <br>Note       : データテーブルから、指定行の仕入データクラスを返します。</br>
        /// <br>Programmer : 980023 飯谷  耕平</br>
        /// <br>Date       : 2007.01.29</br>
        /// </remarks>
        public List<StcHisRefDataWork> GetSelectedRowData()
        {
			// 戻値
			List<StcHisRefDataWork> stcHisRefDataWorkList = new List<StcHisRefDataWork>();

			// 部品情報テーブル
			DataView StockSlipView = new DataView(this._dataSet.StockSlip);
			StockSlipView.RowFilter = String.Format("{0} = {1}", this._dataSet.StockSlip.PrintFlagColumn.ColumnName,true);

			for (int ix = 0; ix < StockSlipView.Count; ix++)
			{
				StcHisRefDataWork stcHisRefDataWork = new StcHisRefDataWork();

				stcHisRefDataWork.EnterpriseCode = (string)StockSlipView[ix][this._dataSet.StockSlip.EnterpriseCodeColumn.ColumnName];

				stcHisRefDataWork.EnterpriseCode = (string)StockSlipView[ix][this._dataSet.StockSlip.EnterpriseCodeColumn.ColumnName];
				stcHisRefDataWork.SupplierFormal = (int)StockSlipView[ix][this._dataSet.StockSlip.SupplierFormalColumn.ColumnName];
				stcHisRefDataWork.SupplierSlipNo = (int)StockSlipView[ix][this._dataSet.StockSlip.SupplierSlipNoColumn.ColumnName];
				stcHisRefDataWork.SectionCode = (string)StockSlipView[ix][this._dataSet.StockSlip.SectionCodeColumn.ColumnName];
				stcHisRefDataWork.SectionGuideNm = (string)StockSlipView[ix][this._dataSet.StockSlip.SectionGuideNmColumn.ColumnName];
				stcHisRefDataWork.SupplierSlipCd = (int)StockSlipView[ix][this._dataSet.StockSlip.SupplierSlipCdColumn.ColumnName];
				stcHisRefDataWork.AccPayDivCd = (int)StockSlipView[ix][this._dataSet.StockSlip.AccPayDivCdColumn.ColumnName];
				stcHisRefDataWork.ArrivalGoodsDay = (System.DateTime)StockSlipView[ix][this._dataSet.StockSlip.ArrivalGoodsDayColumn.ColumnName];
				stcHisRefDataWork.StockDate = (System.DateTime)StockSlipView[ix][this._dataSet.StockSlip.StockDateColumn.ColumnName];
				stcHisRefDataWork.StockInputCode = (string)StockSlipView[ix][this._dataSet.StockSlip.StockInputCodeColumn.ColumnName];
				stcHisRefDataWork.StockInputName = (string)StockSlipView[ix][this._dataSet.StockSlip.StockInputNameColumn.ColumnName];
				stcHisRefDataWork.StockAgentCode = (string)StockSlipView[ix][this._dataSet.StockSlip.StockAgentCodeColumn.ColumnName];
				stcHisRefDataWork.StockAgentName = (string)StockSlipView[ix][this._dataSet.StockSlip.StockAgentNameColumn.ColumnName];
				//stcHisRefDataWork.CustomerCode = (int)StockSlipView[ix][this._dataSet.StockSlip.CustomerCodeColumn.ColumnName];
				//stcHisRefDataWork.CustomerName = (string)StockSlipView[ix][this._dataSet.StockSlip.CustomerNameColumn.ColumnName];
				//stcHisRefDataWork.CustomerName2 = (string)StockSlipView[ix][this._dataSet.StockSlip.CustomerName2Column.ColumnName];
				//stcHisRefDataWork.CustomerSnm = (string)StockSlipView[ix][this._dataSet.StockSlip.CustomerSnmColumn.ColumnName];
				stcHisRefDataWork.PartySaleSlipNum = (string)StockSlipView[ix][this._dataSet.StockSlip.PartySaleSlipNumColumn.ColumnName];
				stcHisRefDataWork.StockRowNo = (int)StockSlipView[ix][this._dataSet.StockSlip.StockRowNoColumn.ColumnName];
				stcHisRefDataWork.CommonSeqNo = (long)StockSlipView[ix][this._dataSet.StockSlip.CommonSeqNoColumn.ColumnName];
				stcHisRefDataWork.StockSlipDtlNum = (long)StockSlipView[ix][this._dataSet.StockSlip.StockSlipDtlNumColumn.ColumnName];
				stcHisRefDataWork.GoodsMakerCd = (int)StockSlipView[ix][this._dataSet.StockSlip.GoodsMakerCdColumn.ColumnName];
				stcHisRefDataWork.MakerName = (string)StockSlipView[ix][this._dataSet.StockSlip.MakerNameColumn.ColumnName];
				stcHisRefDataWork.GoodsNo = (string)StockSlipView[ix][this._dataSet.StockSlip.GoodsNoColumn.ColumnName];
				stcHisRefDataWork.GoodsName = (string)StockSlipView[ix][this._dataSet.StockSlip.GoodsNameColumn.ColumnName];
				//stcHisRefDataWork.ListPriceFl = (double)StockSlipView[ix][this._dataSet.StockSlip.ListPriceFlColumn.ColumnName];
				stcHisRefDataWork.StockUnitPriceFl = (double)StockSlipView[ix][this._dataSet.StockSlip.StockUnitPriceFlColumn.ColumnName];
				stcHisRefDataWork.StockCount = (double)StockSlipView[ix][this._dataSet.StockSlip.StockCountColumn.ColumnName];
				stcHisRefDataWork.StockPriceTaxExc = (long)StockSlipView[ix][this._dataSet.StockSlip.StockPriceTaxExcColumn.ColumnName];
				//stcHisRefDataWork.UnitCode = (int)StockSlipView[ix][this._dataSet.StockSlip.UnitCodeColumn.ColumnName];
				//stcHisRefDataWork.UnitName = (string)StockSlipView[ix][this._dataSet.StockSlip.UnitNameColumn.ColumnName];
				stcHisRefDataWork.WarehouseCode = (string)StockSlipView[ix][this._dataSet.StockSlip.WarehouseCodeColumn.ColumnName];
				stcHisRefDataWork.WarehouseName = (string)StockSlipView[ix][this._dataSet.StockSlip.WarehouseNameColumn.ColumnName];
				stcHisRefDataWork.WarehouseShelfNo = (string)StockSlipView[ix][this._dataSet.StockSlip.WarehouseShelfNoColumn.ColumnName];
				stcHisRefDataWork.SupplierCd = (int)StockSlipView[ix][this._dataSet.StockSlip.SupplierCdColumn.ColumnName];
				stcHisRefDataWork.SupplierSnm = (string)StockSlipView[ix][this._dataSet.StockSlip.SupplierSnmColumn.ColumnName];
				stcHisRefDataWork.OrderNumber = (string)StockSlipView[ix][this._dataSet.StockSlip.OrderNumberColumn.ColumnName];
				//stcHisRefDataWork.OrderCnt = (double)StockSlipView[ix][this._dataSet.StockSlip.OrderCntColumn.ColumnName];
				//stcHisRefDataWork.OrderAdjustCnt = (double)StockSlipView[ix][this._dataSet.StockSlip.OrderAdjustCntColumn.ColumnName];
				//stcHisRefDataWork.OrderRemainCnt = (double)StockSlipView[ix][this._dataSet.StockSlip.OrderRemainCntColumn.ColumnName];
				//stcHisRefDataWork.StockDtiSlipNote1 = (string)StockSlipView[ix][this._dataSet.StockSlip.StockDtiSlipNote1Column.ColumnName];
//
				//stcHisRefDataWork.SalesCustomerCode = (int)StockSlipView[ix][this._dataSet.StockSlip.SalesCustomerCodeColumn.ColumnName];
				//stcHisRefDataWork.SalesCustomerSnm = (string)StockSlipView[ix][this._dataSet.StockSlip.SalesCustomerSnmColumn.ColumnName];
				
				stcHisRefDataWork.MemoExist = (int)StockSlipView[ix][this._dataSet.StockSlip.MemoExistColumn.ColumnName];
				stcHisRefDataWork.SlipMemo1 = (string)StockSlipView[ix][this._dataSet.StockSlip.SlipMemo1Column.ColumnName];
				stcHisRefDataWork.SlipMemo2 = (string)StockSlipView[ix][this._dataSet.StockSlip.SlipMemo2Column.ColumnName];
				stcHisRefDataWork.SlipMemo3 = (string)StockSlipView[ix][this._dataSet.StockSlip.SlipMemo3Column.ColumnName];
				//stcHisRefDataWork.SlipMemo4 = (string)StockSlipView[ix][this._dataSet.StockSlip.SlipMemo4Column.ColumnName];
				//stcHisRefDataWork.SlipMemo5 = (string)StockSlipView[ix][this._dataSet.StockSlip.SlipMemo5Column.ColumnName];
				//stcHisRefDataWork.SlipMemo6 = (string)StockSlipView[ix][this._dataSet.StockSlip.SlipMemo6Column.ColumnName];
				stcHisRefDataWork.InsideMemo1 = (string)StockSlipView[ix][this._dataSet.StockSlip.InsideMemo1Column.ColumnName];
				stcHisRefDataWork.InsideMemo2 = (string)StockSlipView[ix][this._dataSet.StockSlip.InsideMemo2Column.ColumnName];
				stcHisRefDataWork.InsideMemo3 = (string)StockSlipView[ix][this._dataSet.StockSlip.InsideMemo3Column.ColumnName];
				//stcHisRefDataWork.InsideMemo4 = (string)StockSlipView[ix][this._dataSet.StockSlip.InsideMemo4Column.ColumnName];
				//stcHisRefDataWork.InsideMemo5 = (string)StockSlipView[ix][this._dataSet.StockSlip.InsideMemo5Column.ColumnName];
				//stcHisRefDataWork.InsideMemo6 = (string)StockSlipView[ix][this._dataSet.StockSlip.InsideMemo6Column.ColumnName];
                stcHisRefDataWork.BLGoodsCode = (int)StockSlipView[ix][this._dataSet.StockSlip.BLGoodsCodeColumn.ColumnName];
                stcHisRefDataWork.ListPriceTaxExcFl = (double)StockSlipView[ix][this._dataSet.StockSlip.ListPriceTaxExcFlColumn.ColumnName];
                stcHisRefDataWork.DebitNoteDiv = (int)StockSlipView[ix][this._dataSet.StockSlip.DebitNoteDivColumn.ColumnName];
                stcHisRefDataWork.InputDay = (System.DateTime)StockSlipView[ix][this._dataSet.StockSlip.InputDayColumn.ColumnName];
                //stcHisRefDataWork.StockAddUpADate = (System.DateTime)StockSlipView[ix][this._dataSet.StockSlip.StockAddUpADateColumn.ColumnName];     // DEL 2009/04/15
                // ADD 2009/04/15 ------>>>
                // 入荷の場合、計上日が未設定
                if (StockSlipView[ix][this._dataSet.StockSlip.StockAddUpADateColumn.ColumnName] != DBNull.Value)
                {
                    stcHisRefDataWork.StockAddUpADate = (System.DateTime)StockSlipView[ix][this._dataSet.StockSlip.StockAddUpADateColumn.ColumnName];
                }
                else
                {
                    stcHisRefDataWork.StockAddUpADate = DateTime.MinValue;
                }
                // ADD 2009/04/15 ------<<<
                stcHisRefDataWork.PayeeCode = (int)StockSlipView[ix][this._dataSet.StockSlip.PayeeCodeColumn.ColumnName];
                stcHisRefDataWork.PayeeSnm = (string)StockSlipView[ix][this._dataSet.StockSlip.PayeeSnmColumn.ColumnName];

				stcHisRefDataWorkList.Add(stcHisRefDataWork);
			}

			return stcHisRefDataWorkList;
        }

		/// <summary>
		/// 選択行テーブルデータ取得処理＜1行選択＞
		/// </summary>
		/// <param name="getRowNo">グリッド選択RowNo</param>
		/// <returns>仕入データクラス</returns>
		/// <remarks>
		/// <br>Note       : データテーブルから、指定行の仕入データクラスを返します。</br>
		/// <br>Programmer : 980023 飯谷  耕平</br>
		/// <br>Date       : 2007.01.29</br>
		/// </remarks>
		public List<StcHisRefDataWork> GetSelectedRowData(int ix)
		{
			// 戻値
			List<StcHisRefDataWork> stcHisRefDataWorkList = new List<StcHisRefDataWork>();

			StcHisRefDataWork stcHisRefDataWork = new StcHisRefDataWork();

			stcHisRefDataWork.EnterpriseCode = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.EnterpriseCodeColumn.ColumnName];

			stcHisRefDataWork.EnterpriseCode = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.EnterpriseCodeColumn.ColumnName];
			stcHisRefDataWork.SupplierFormal = (int)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.SupplierFormalColumn.ColumnName];
			stcHisRefDataWork.SupplierSlipNo = (int)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.SupplierSlipNoColumn.ColumnName];
			stcHisRefDataWork.SectionCode = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.SectionCodeColumn.ColumnName];
			stcHisRefDataWork.SectionGuideNm = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.SectionGuideNmColumn.ColumnName];
			stcHisRefDataWork.SupplierSlipCd = (int)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.SupplierSlipCdColumn.ColumnName];
			stcHisRefDataWork.AccPayDivCd = (int)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.AccPayDivCdColumn.ColumnName];
			stcHisRefDataWork.ArrivalGoodsDay = (System.DateTime)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.ArrivalGoodsDayColumn.ColumnName];
			stcHisRefDataWork.StockDate = (System.DateTime)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockDateColumn.ColumnName];
			stcHisRefDataWork.StockInputCode = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockInputCodeColumn.ColumnName];
			stcHisRefDataWork.StockInputName = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockInputNameColumn.ColumnName];
			stcHisRefDataWork.StockAgentCode = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockAgentCodeColumn.ColumnName];
			stcHisRefDataWork.StockAgentName = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockAgentNameColumn.ColumnName];
			//stcHisRefDataWork.CustomerCode = (int)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.CustomerCodeColumn.ColumnName];
			//stcHisRefDataWork.CustomerName = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.CustomerNameColumn.ColumnName];
			//stcHisRefDataWork.CustomerName2 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.CustomerName2Column.ColumnName];
			//stcHisRefDataWork.CustomerSnm = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.CustomerSnmColumn.ColumnName];
			stcHisRefDataWork.PartySaleSlipNum = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.PartySaleSlipNumColumn.ColumnName];
			stcHisRefDataWork.StockRowNo = (int)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockRowNoColumn.ColumnName];
			stcHisRefDataWork.CommonSeqNo = (long)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.CommonSeqNoColumn.ColumnName];
			stcHisRefDataWork.StockSlipDtlNum = (long)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockSlipDtlNumColumn.ColumnName];
			stcHisRefDataWork.GoodsMakerCd = (int)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.GoodsMakerCdColumn.ColumnName];
			stcHisRefDataWork.MakerName = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.MakerNameColumn.ColumnName];
			stcHisRefDataWork.GoodsNo = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.GoodsNoColumn.ColumnName];
			stcHisRefDataWork.GoodsName = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.GoodsNameColumn.ColumnName];
			//stcHisRefDataWork.ListPriceFl = (double)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.ListPriceFlColumn.ColumnName];
			stcHisRefDataWork.StockUnitPriceFl = (double)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockUnitPriceFlColumn.ColumnName];
			stcHisRefDataWork.StockCount = (double)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockCountColumn.ColumnName];
			stcHisRefDataWork.StockPriceTaxExc = (long)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockPriceTaxExcColumn.ColumnName];
			//stcHisRefDataWork.UnitCode = (int)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.UnitCodeColumn.ColumnName];
			//stcHisRefDataWork.UnitName = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.UnitNameColumn.ColumnName];
			stcHisRefDataWork.WarehouseCode = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.WarehouseCodeColumn.ColumnName];
			stcHisRefDataWork.WarehouseName = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.WarehouseNameColumn.ColumnName];
			stcHisRefDataWork.WarehouseShelfNo = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.WarehouseShelfNoColumn.ColumnName];
			stcHisRefDataWork.SupplierCd = (int)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.SupplierCdColumn.ColumnName];
			stcHisRefDataWork.SupplierSnm = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.SupplierSnmColumn.ColumnName];
			stcHisRefDataWork.OrderNumber = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.OrderNumberColumn.ColumnName];
			//stcHisRefDataWork.OrderCnt = (double)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.OrderCntColumn.ColumnName];
			//stcHisRefDataWork.OrderAdjustCnt = (double)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.OrderAdjustCntColumn.ColumnName];
			//stcHisRefDataWork.OrderRemainCnt = (double)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.OrderRemainCntColumn.ColumnName];
			stcHisRefDataWork.StockDtiSlipNote1 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockDtiSlipNote1Column.ColumnName];
			stcHisRefDataWork.MemoExist = (int)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.MemoExistColumn.ColumnName];
			stcHisRefDataWork.SlipMemo1 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.SlipMemo1Column.ColumnName];
			stcHisRefDataWork.SlipMemo2 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.SlipMemo2Column.ColumnName];
			stcHisRefDataWork.SlipMemo3 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.SlipMemo3Column.ColumnName];
			//stcHisRefDataWork.SlipMemo4 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.SlipMemo4Column.ColumnName];
			//stcHisRefDataWork.SlipMemo5 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.SlipMemo5Column.ColumnName];
			//stcHisRefDataWork.SlipMemo6 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.SlipMemo6Column.ColumnName];
			stcHisRefDataWork.InsideMemo1 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.InsideMemo1Column.ColumnName];
			stcHisRefDataWork.InsideMemo2 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.InsideMemo2Column.ColumnName];
			stcHisRefDataWork.InsideMemo3 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.InsideMemo3Column.ColumnName];
			//stcHisRefDataWork.InsideMemo4 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.InsideMemo4Column.ColumnName];
			//stcHisRefDataWork.InsideMemo5 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.InsideMemo5Column.ColumnName];
			//stcHisRefDataWork.InsideMemo6 = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.InsideMemo6Column.ColumnName];
            stcHisRefDataWork.BLGoodsCode = (int)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.BLGoodsCodeColumn.ColumnName];
            stcHisRefDataWork.ListPriceTaxExcFl = (double)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.ListPriceTaxExcFlColumn.ColumnName];
            stcHisRefDataWork.DebitNoteDiv = (int)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.DebitNoteDivColumn.ColumnName];
            stcHisRefDataWork.InputDay = (System.DateTime)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.InputDayColumn.ColumnName];
            //stcHisRefDataWork.StockAddUpADate = (System.DateTime)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockAddUpADateColumn.ColumnName];   // DEL 2009/04/15
            // ADD 2009/04/15 ------>>>
            // 入荷の場合、計上日が未設定
            if (this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockAddUpADateColumn.ColumnName] != DBNull.Value)
            {
                stcHisRefDataWork.StockAddUpADate = (System.DateTime)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockAddUpADateColumn.ColumnName];
            }
            else
            {
                stcHisRefDataWork.StockAddUpADate = DateTime.MinValue;
            }
            // ADD 2009/04/15 ------<<<
            stcHisRefDataWork.StockAddUpADate = (System.DateTime)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.StockAddUpADateColumn.ColumnName];
            stcHisRefDataWork.PayeeCode = (int)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.PayeeCodeColumn.ColumnName];
            stcHisRefDataWork.PayeeSnm = (string)this._dataSet.StockSlip[ix][this._dataSet.StockSlip.PayeeSnmColumn.ColumnName];

			stcHisRefDataWorkList.Add(stcHisRefDataWork);

			return stcHisRefDataWorkList;
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

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
        ///// <summary>
        ///// 商品名称取得処理
        ///// </summary>
        ///// <param name="goodsCode">商品コード</param>
        ///// <returns>true:存在あり、false:存在しない</returns>
        //public bool CheckGoodsExist(string goodsCode, out string goodsName)
        //{
        //    List<GoodsUnitData> goodsUnitDataList;
        //    GoodsAcs goodsAcs = new GoodsAcs();
        //    goodsName = "";

        //    // 商品コードのみの指定で
        //    int status = goodsAcs.Read(this._enterpriseCode, goodsCode,out goodsUnitDataList);

        //    if( (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList.Count != 0) )
        //    {
        //        goodsName = goodsUnitDataList[0].GoodsName;
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// 商品名称取得処理
        ///// </summary>
        ///// <param name="goodsCode">商品コード</param>
        ///// <returns>true:存在あり、false:存在しない</returns>
        //public int CheckGoodsExist(IWin32Window owner, ref string goodsCode, ref string goodsName, ref int goodsMakerCd, ref string makerName)
        //{
        //    int status;
        //    string message;
        //    string searchCode;
        //    int searchType;

        //    GoodsCndtn goodsCndtn = new GoodsCndtn();
        //    List<GoodsUnitData> goodsUnitDataList;
        //    GoodsAcs goodsAcs = new GoodsAcs();

        //    searchType = GetSearchType(goodsCode, out searchCode);

        //    MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

        //    goodsCndtn.GoodsMakerCd = goodsMakerCd;
        //    goodsCndtn.GoodsNoSrchTyp = searchType;
        //    //goodsCndtn.GoodsNo = goodsCode;
        //    goodsCndtn.GoodsNo = searchCode;
        //    goodsCndtn.EnterpriseCode = this._enterpriseCode;

        //    //status = goodsSelectGuide.ReadGoods(owner, false, goodsCndtn, this._enterpriseCode, searchType, searchCode, out goodsUnitDataList, out message);
        //    status = goodsSelectGuide.ReadGoods(owner, false, goodsCndtn, out goodsUnitDataList, out message);


        //    if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
        //    {
        //        goodsCode = goodsUnitDataList[0].GoodsNo;
        //        goodsName = goodsUnitDataList[0].GoodsName;

        //        makerName = goodsUnitDataList[0].MakerName;
        //        goodsMakerCd = goodsUnitDataList[0].GoodsMakerCd;
        //    }
        //    return (status);
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL

		// ===================================================================================== //
		// 商品関連処理
		// ===================================================================================== //
		# region Goods Control Methods

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
        ///// <summary>
        ///// 検索タイプ取得処理
        ///// </summary>
        ///// <param name="inputCode">入力されたコード</param>
        ///// <param name="searchCode">検索用コード（*を除く）</param>
        ///// <returns>0:完全一致検索 1:前方一致検索 2:後方一致検索 3:曖昧検索</returns>
        //public static int GetSearchType(string inputCode, out string searchCode)
        //{
        //    searchCode = inputCode;
        //    if (String.IsNullOrEmpty(inputCode)) return 0;

        //    if (inputCode.Contains("*"))
        //    {
        //        searchCode = inputCode.Replace("*", "");
        //        string firstString = inputCode.Substring(0, 1);
        //        string lastString = inputCode.Substring(inputCode.Length - 1, 1);

        //        if ((firstString == "*") && (lastString == "*"))
        //        {
        //            return 3;
        //        }
        //        else if (firstString == "*")
        //        {
        //            return 2;
        //        }
        //        else if (lastString == "*")
        //        {
        //            return 1;
        //        }
        //        else
        //        {
        //            return 3;
        //        }
        //    }
        //    else
        //    {
        //        // *が存在しないため完全一致検索
        //        return 0;
        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL

		# endregion

		/// <summary>
        /// 拠点制御アクセスクラスインスタンス化処理
        /// </summary>
        internal void CreateSecInfoAcs()
        {
            //if (_secInfoAcs == null)
            //{
            //    _secInfoAcs = new SecInfoAcs();
            //}

            //// ログイン担当拠点情報の取得
            //if (_secInfoAcs.SecInfoSet == null)
            //{
            //    throw new ApplicationException(MESSAGE_NONOWNSECTION);
            //}
        }

        /// <summary>
        /// 本社機能／拠点機能チェック処理
        /// </summary>
        /// <returns>true:本社機能 false:拠点機能</returns>
        public bool IsMainOfficeFunc()
        {
            bool isMainOfficeFunc = true;// 常に本社機能として使用
            //bool isMainOfficeFunc = false;

            //// 拠点制御アクセスクラスインスタンス化処理
            //this.CreateSecInfoAcs();

            //// ログイン担当拠点情報の取得
            //SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

            //if (secInfoSet != null)
            //{
            //    // 本社機能か？
            //    if (secInfoSet.MainOfficeFuncFlag == 1)
            //    {
            //        isMainOfficeFunc = true;
            //    }
            //}
            //else
            //{
            //    throw new ApplicationException(MESSAGE_NONOWNSECTION);
            //}

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

        // ADD 2009/04/09 ------>>>
        public string GetSubSectionName(int subSectionCode)
        {
            if (this._subSectionDic.ContainsKey(subSectionCode))
            {
                return this._subSectionDic[subSectionCode].SubSectionName.Trim();
            }
            else
            {
                return "";
            }
        }

        public int ExecuteSubSectionGuide(out SubSection subSection)
        {
            int status = this._subSectionAcs.ExecuteGuid(out subSection, this._enterpriseCode);

            return status;
        }
        // ADD 2009/04/09 ------<<<
        # endregion

    }
}
