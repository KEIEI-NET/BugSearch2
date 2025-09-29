//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 仕入伝票照会
// プログラム概要   : 仕入伝票照会を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍 幸史
// 作 成 日  2009/02/09  修正内容 : 障害ID:9049対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/09  修正内容 : 障害対応13014
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/12  修正内容 : 障害対応13234
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
    /// <br></br>
    /// <br>Update Note: 2008.04.24 20056 對馬 大輔</br>
    ///	<br>		   : PM.NS 共通修正 得意先・仕入先分離対応</br>
    /// <br>Update Note: 2009.02.09 30414 忍 幸史</br>
    ///	<br>		   : 障害ID:9049対応</br>
    /// </remarks>
    public class SearchSlipAcs
    {
        # region ■Private Member
        /// <summary>リモートオブジェクト格納バッファ</summary>
        private ISearchStockSlipDB _iSearchStockSlipDB = null;
        /// <summary>拠点オプションフラグ</summary>
        private bool _optSection;
		// 拠点アクセスクラス
        private static SecInfoAcs _secInfoAcs;													
        private StockDataSet _dataSet;
        private static StockDataSet.StockSlipDataTable _stockSlipCache;
        private static SearchParaStockSlip _paraStockSlipCache;
        private static SortedList _nameList;
        private static SearchSlipAcs _searchSlipAcs;
        private List<StockDetail> _stockDetailDBDataList;

        private StockSlipInputAcs _stockSlipInputAcs;

        private string _enterpriseCode;             // 企業コード

        private const string MESSAGE_NoResult = "検索条件に一致する伝票は存在しません。";
        private const string MESSAGE_ErrResult = "伝票情報の取得に失敗しました。";
        private const string MESSAGE_NONOWNSECTION = "自拠点情報が取得できませんでした。拠点設定を行ってから起動してください。";
		private const string ct_DateFormat = "yyyy/MM/dd";

        private Dictionary<string, SecInfoSet> _secInfoSetDic;

        private SubSectionAcs _subSectionAcs;
        private Dictionary<int, SubSection> _subSectionDic;

        # endregion

        // デリゲート処理
        public event GetNameListEventHandler GetNameList;
        public delegate SortedList GetNameListEventHandler();

        public event SettingStatusBarMessageEventHandler StatusBarMessageSetting;
        public delegate void SettingStatusBarMessageEventHandler(object sender, string message);

        # region ■Constracter
        /// <summary>
        /// 伝票検索 テーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品大分類マスタ テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 980023 飯谷  耕平</br>
        /// <br>Date       : 2006.12.04</br>
        /// </remarks>
        public SearchSlipAcs()
        {
            //　企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            
            // 拠点OPの判定
            this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);
            this._dataSet = new StockDataSet();
            this._stockDetailDBDataList = new List<StockDetail>();
            this._stockSlipInputAcs = StockSlipInputAcs.GetInstance();

            // --- ADD 2009/02/09 障害ID:9049対応------------------------------------------------------>>>>>
            ReadSecInfoSet();
            // --- ADD 2009/02/09 障害ID:9049対応------------------------------------------------------<<<<<

            this._subSectionAcs = new SubSectionAcs();
            ReadSubSection();

            // ログイン部品で通信状態を確認
            if (LoginInfoAcquisition.OnlineFlag)
            {
                try
                {
                    // リモートオブジェクト取得
                    this._iSearchStockSlipDB = (ISearchStockSlipDB)MediationSearchStockSlipDB.GetSearchStockSlipDB();
                }
                catch (Exception)
                {
                    //オフライン時はnullをセット
                    this._iSearchStockSlipDB = null;
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

        // --- ADD 2009/02/09 障害ID:9049対応------------------------------------------------------>>>>>
        public void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            SecInfoAcs secInfoAcs = new SecInfoAcs();

            foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
        }

        private string GetSectionName(string sectionCode)
        {
            if (this._secInfoSetDic.ContainsKey(sectionCode))
            {
                return this._secInfoSetDic[sectionCode].SectionGuideNm.Trim();
            }

            return "";
        }
        // --- ADD 2009/02/09 障害ID:9049対応------------------------------------------------------<<<<<

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

        /// <summary>
        /// 伝票検索アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>伝票検索アクセスクラス インスタンス</returns>
        public static SearchSlipAcs GetInstance()
        {
            if (_searchSlipAcs == null)
            {
                _searchSlipAcs = new SearchSlipAcs();
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
            if (this._iSearchStockSlipDB == null)
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
        private void CacheParaStockSlip(SearchParaStockSlip searchParaStockSlip)
        {
            // 検索条件値
            if (_paraStockSlipCache == null)
            {
                _paraStockSlipCache = new SearchParaStockSlip();
            }
            _paraStockSlipCache = searchParaStockSlip;

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
        /// </remarks>
        public int SetSearchData(SearchParaStockSlip searchParaStockSlip)
        {
			string supplierSlipCdString = "";
            List<SearchRetStockSlip> retData;
			long stockPriceConsTax = 0;
			long stockTotalPrice = 0;
            
            int status = this.Search(out retData, searchParaStockSlip);

            // 仕入形式
            List<string> SupplierFormalList = new List<string>();
            SupplierFormalList.Add("仕入");
			SupplierFormalList.Add("入荷");
			SupplierFormalList.Add("発注");

            // --- DEL 2009/01/23 -------------------------------->>>>>
            //// 伝票区分
            //SortedList SupplierSlipCdList = new SortedList();
            //SupplierSlipCdList.Add(10,"仕入");
            //SupplierSlipCdList.Add(20,"返品");
            //SupplierSlipCdList.Add(30, "現金仕入");
            //SupplierSlipCdList.Add(40, "現金返品");
            // --- DEL 2009/01/23 --------------------------------<<<<<

            // 赤伝区分
            List<string> DebitNoteDivList = new List<string>();
            DebitNoteDivList.Add("黒伝");
            DebitNoteDivList.Add("赤伝");
            DebitNoteDivList.Add("元黒");

            // 商品区分    
            List<string> StockGoodsCdList = new List<string>();
            StockGoodsCdList.Add("商品");
            StockGoodsCdList.Add("商品外");
            StockGoodsCdList.Add("消費税調整");
            StockGoodsCdList.Add("残高調整");
			StockGoodsCdList.Add("消費税調整（買掛用）");
			StockGoodsCdList.Add("残高調整（買掛用）");
			StockGoodsCdList.Add("合計入力");

            // 買掛区分    
            List<string> AccPayDivCdList = new List<string>();
            AccPayDivCdList.Add("買掛管理しない");
            AccPayDivCdList.Add("買掛管理する");

            this.ClearStockSlipDataTable();

            //SecInfoSet secInfoSet;
            //SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            //int rstatus;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 伝票番号(仕入SEQ/支払No)保存用変数
                //int exSupplierSlipNo = 0;

                for (int i = 0; i < retData.Count; i++)
                {
                    SearchRetStockSlip searchRetStockSlip = retData[i];

					//消費税調整・残高調整
					if ((searchRetStockSlip.StockGoodsCd == 2) || (searchRetStockSlip.StockGoodsCd == 4))
					{
						stockTotalPrice = 0;
						stockPriceConsTax = searchRetStockSlip.StockPriceConsTax;
					}
					else if ((searchRetStockSlip.StockGoodsCd == 3) || (searchRetStockSlip.StockGoodsCd == 5))
					{
						stockTotalPrice = searchRetStockSlip.StockTotalPrice;
						stockPriceConsTax = 0;
					}
					else
					{
						stockTotalPrice = searchRetStockSlip.StockSubttlPrice;
						stockPriceConsTax = searchRetStockSlip.StockPriceConsTax;
					}

                    //// 消費税転嫁方式
                    //if (searchRetStockSlip.SuppCTaxLayCd == 0)
                    //{
                    //    // 伝票方式
                    //    if (searchRetStockSlip.SupplierSlipNo != exSupplierSlipNo)
                    //    {
                    //        // 伝票番号が変わったら表示

                    //    }
                    //}

                    //// 伝票番号を保存
                    //exSupplierSlipNo = searchRetStockSlip.SupplierSlipNo;

                    //string sectionCode = searchRetStockSlip.SectionCode;      // DEL 2009/05/12
                    string sectionCode = searchRetStockSlip.StockSectionCd;     // ADD 2009/05/12 仕入拠点コード
                    //string sectionName = stockSlipWork.SectionCode;
                    string sectionName = "";
                    if (sectionCode == "00")
                    {
                        sectionName = "全社";
                    }
                    else
                    {
                        // --- CHG 2009/02/09 障害ID:9049対応------------------------------------------------------>>>>>
                        //rstatus = secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, sectionCode);
                        //if (rstatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //{
                        //    sectionName = secInfoSet.SectionGuideNm;
                        //}
                        sectionName = GetSectionName(sectionCode.Trim());
                        // --- CHG 2009/02/09 障害ID:9049対応------------------------------------------------------<<<<<
                    }

					supplierSlipCdString = "";
					switch(searchRetStockSlip.SupplierSlipCd)
					{
						case 10:
                            // --- DEL 2009/01/23 -------------------------------->>>>>
                            //if (searchRetStockSlip.AccPayDivCd == 0) supplierSlipCdString = "現金仕入";
                            //else                                     supplierSlipCdString = "掛仕入";
                            // --- DEL 2009/01/23 --------------------------------<<<<<
                            supplierSlipCdString = "仕入"; // ADD 2009/01/23
							break;
						case 20:
                            // --- DEL 2009/01/23 -------------------------------->>>>>
                            //if (searchRetStockSlip.AccPayDivCd == 0) supplierSlipCdString = "現金返品";
                            //else supplierSlipCdString = "掛返品";
                            // --- DEL 2009/01/23 --------------------------------<<<<<
                            supplierSlipCdString = "返品"; // ADD 2009/01/23
							break;
					}


                    _dataSet.StockSlip.AddStockSlipRow(i + 1, searchRetStockSlip.EnterpriseCode,
                                                       sectionCode, sectionName, searchRetStockSlip.SupplierSlipNo,
                                                       searchRetStockSlip.StockAddUpADate, GetDateTimeString(searchRetStockSlip.StockAddUpADate, ct_DateFormat),
													   searchRetStockSlip.ArrivalGoodsDay, GetDateTimeString(searchRetStockSlip.ArrivalGoodsDay, ct_DateFormat),
                                                       searchRetStockSlip.StockAgentCode, searchRetStockSlip.StockAgentName,
                                                       // UPD 2008.04.24 >>>>>>
                                                       //searchRetStockSlip.CustomerCode, searchRetStockSlip.CustomerName,
                                                       searchRetStockSlip.SupplierCd, searchRetStockSlip.SupplierSnm,//Nm1
                                                       // UPD 2008.04.24 <<<<<<
													   searchRetStockSlip.SupplierFormal,
                                                       SupplierFormalList[searchRetStockSlip.SupplierFormal],
                                                       searchRetStockSlip.SupplierSlipCd,
                                                       supplierSlipCdString, //SupplierSlipCdList[searchRetStockSlip.SupplierSlipCd].ToString(),
                                                       searchRetStockSlip.DebitNoteDiv,
                                                       DebitNoteDivList[searchRetStockSlip.DebitNoteDiv],
                                                       searchRetStockSlip.StockGoodsCd,
                                                       StockGoodsCdList[searchRetStockSlip.StockGoodsCd],
                                                       searchRetStockSlip.AccPayDivCd,
                                                       AccPayDivCdList[searchRetStockSlip.AccPayDivCd],
													   searchRetStockSlip.InputDay, GetDateTimeString(searchRetStockSlip.InputDay, ct_DateFormat),
													   searchRetStockSlip.StockDate, GetDateTimeString(searchRetStockSlip.StockDate, ct_DateFormat),
                                                       stockTotalPrice,
													   searchRetStockSlip.StockSubttlPrice,
													   stockPriceConsTax,
                                                       searchRetStockSlip.PartySaleSlipNum,
                                                       searchRetStockSlip.SupplierSlipNote1, 
                                                       searchRetStockSlip.SupplierSlipNote2,
                                                       //searchRetStockSlip.SupplierCd,
                                                       //searchRetStockSlip.SupplierNm1,
                                                       searchRetStockSlip.SupplierSlipNo,
                                                       searchRetStockSlip.SupplierSlipNo,
                                                       searchRetStockSlip.UoeRemark1,
                                                       searchRetStockSlip.PayeeCode,
                                                       searchRetStockSlip.PayeeSnm,
                                                       searchRetStockSlip.SuppCTaxLayCd,
                                                       GetSubSectionName(searchRetStockSlip.SubSectionCode)
													   );
                }

                // 検索データのキャッシュ
                this.CacheStockSlipTable();

                // 検索条件のキャッシュ
                this.CacheParaStockSlip(searchParaStockSlip);
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
        /// <param name="searchParaStockSlip">仕入伝票検索パラメータクラス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 伝票情報を読み込みます。</br>
        /// <br>Programmer : 980023 飯谷  飯谷</br>
        /// <br>Date       : 2007.01.29</br>
        /// </remarks>
        public int Search(out List<SearchRetStockSlip> searchRetStockSlips, SearchParaStockSlip searchParaStockSlip)
        {
            try
            {
                int status;
                searchRetStockSlips = new List<SearchRetStockSlip>();

                // オンラインの場合リモート取得
                if (LoginInfoAcquisition.OnlineFlag)
                {
                    CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                    paraList.Add(searchParaStockSlip);

                    CustomSerializeArrayList retList = new CustomSerializeArrayList();

                    object paraObj = (object)paraList;
                    object retObj = (object)retList;

                    //伝票情報取得
                    status = this._iSearchStockSlipDB.Search(ref paraObj, out retObj);
                    
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        int setCount = 0;
                        retList = (CustomSerializeArrayList)retObj;
                        for (int i = 0; i < retList.Count; i++)
                        {
                            searchRetStockSlips.Add((SearchRetStockSlip)retList[i]);
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
            catch (Exception)
            {
                searchRetStockSlips = null;
                //オフライン時はnullをセット
                this._iSearchStockSlipDB= null;
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
        public SearchParaStockSlip GetParaStockSlipCache()
        {
            return _paraStockSlipCache;
        }

        /// <summary>
        /// 伝票情報件数取得処理（論理削除除く）
        /// </summary>
        /// <param name="retTotalCnt">データ件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>取得結果</returns>
        /// <remarks>
        /// <br>Note       : 仕入データ検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 980023 飯谷  耕平</br>
        /// <br>Date       : 2007.01.29</br>
        /// </remarks>
        public int GetCnt(out int retTotalCnt, string enterpriseCode)
        {
            return GetCntProc(out retTotalCnt, enterpriseCode, 0);
        }

        /// <summary>
        /// 伝票情報件数取得処理（論理削除含む）
        /// </summary>
        /// <param name="retTotalCnt">データ件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>取得結果</returns>
        /// <remarks>
        /// <br>Note       : 仕入データ検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 980023 飯谷  耕平</br>
        /// <br>Date       : 2006.12.04</br>
        /// </remarks>
        public int GetAllCnt(out int retTotalCnt, string enterpriseCode)
        {
            return GetCntProc(out retTotalCnt, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>
        /// 伝票検索数取得処理
        /// </summary>
        /// <param name="retTotalCnt">データ件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:全ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入データ数の検索を行います。</br>
        /// <br>Programmer : 980023 飯谷  耕平</br>
        /// <br>Date       : 2007.01.29</br>
        /// </remarks>
        public int GetCntProc(out int retTotalCnt, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            StockSlipWork stockSlipWork = new StockSlipWork();
            stockSlipWork.EnterpriseCode = enterpriseCode;

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(stockSlipWork);

            //object objectStockSlipWork;
            //this._iIOWriteMASIRDB.Search(out objectLGoodsGanreWork, lgoodsganreWork, 0, ConstantManagement.LogicalMode.GetData01);
            //ArrayList al = (ArrayList)objectStockSlipWork;
            //retTotalCnt = al.Count;
            retTotalCnt = 0;
            return 0;
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
        public SearchRetStockSlip GetSelectedRowData(int getRowNo)
        {
            SearchRetStockSlip searchRetStockSlip = new SearchRetStockSlip();

            searchRetStockSlip.EnterpriseCode   = this._dataSet.StockSlip[getRowNo].EnterpriseCode;         // 企業コード
            searchRetStockSlip.SupplierFormal   = this._dataSet.StockSlip[getRowNo].SupplierFomal;          // 仕入形式
            searchRetStockSlip.SupplierSlipNo   = this._dataSet.StockSlip[getRowNo].SupplierSlipNo;         // 仕入伝票番号
            searchRetStockSlip.SupplierSlipCd   = this._dataSet.StockSlip[getRowNo].SupplierSlipCd;         // 伝票区分
            searchRetStockSlip.StockGoodsCd     = this._dataSet.StockSlip[getRowNo].StockGoodsCd;           // 商品区分
            searchRetStockSlip.AccPayDivCd      = this._dataSet.StockSlip[getRowNo].AccPayDivCd;            // 買掛区分

            searchRetStockSlip.StockAgentCode   = this._dataSet.StockSlip[getRowNo].StockAgentCode;         // 担当者コード
            searchRetStockSlip.StockAgentName   = this._dataSet.StockSlip[getRowNo].StockAgentName;         // 担当者名

            // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //searchRetStockSlip.CustomerCode = this._dataSet.StockSlip[getRowNo].CustomerCode;           // 仕入先コード
            //searchRetStockSlip.CustomerName = this._dataSet.StockSlip[getRowNo].CustomerName;           // 仕入先名
            searchRetStockSlip.SupplierCd = this._dataSet.StockSlip[getRowNo].CustomerCode;           // 仕入先コード
            searchRetStockSlip.SupplierSnm = this._dataSet.StockSlip[getRowNo].CustomerName;           // 仕入先名
            // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			searchRetStockSlip.ArrivalGoodsDay  = this._dataSet.StockSlip[getRowNo].ArrivalGoodsDay;        // 入荷日
            searchRetStockSlip.StockAddUpADate  = this._dataSet.StockSlip[getRowNo].StockAddUpADate;        // 計上日
			searchRetStockSlip.InputDay			= this._dataSet.StockSlip[getRowNo].InputDay;				// 入力日
			searchRetStockSlip.StockDate		= this._dataSet.StockSlip[getRowNo].StockDate;				// 仕入日

			searchRetStockSlip.PartySaleSlipNum = this._dataSet.StockSlip[getRowNo].PartySaleSlipNum;       // 相手先伝番
			searchRetStockSlip.SupplierSlipNo = this._dataSet.StockSlip[getRowNo].SupplierSlipNo;			// 伝票番号

            searchRetStockSlip.UoeRemark1 = this._dataSet.StockSlip[getRowNo].UoeRemark1;
            searchRetStockSlip.PayeeCode = this._dataSet.StockSlip[getRowNo].PayeeCode;
            searchRetStockSlip.PayeeSnm = this._dataSet.StockSlip[getRowNo].PayeeSnm;

            searchRetStockSlip.SectionCode = this._dataSet.StockSlip[getRowNo].SectionCode;
            

            return searchRetStockSlip;
        }

        /// <summary>
        /// 対象伝票明細情報取得処理
        /// </summary>
        /// <param name="supplierFormal">仕入形式</param>
        /// <param name="supplierSlipNo">伝票番号</param>
        public void SetDetailData(int supplierFormal, int supplierSlipNo)
		{
			long stockPriceTaxExc = 0;
			long stockPriceConsTax = 0;

			//PaymentSlp paymentSlp;
			//Broadleaf.Application.UIData.PaymentSlp paymentSlp;
			//List<SalesTemp> salesTempList;

			StockSlip stockSlip = new StockSlip();
            List<StockDetail> stockDetailList = new List<StockDetail>();
			StockInputDataSet.StockDetailDataTable stockDetailTable = new StockInputDataSet.StockDetailDataTable();

            // 2008.10.06 **undefined source objection
			this._stockSlipInputAcs.ReadDBData(
				this._enterpriseCode,
				supplierFormal,
				supplierSlipNo,
				out stockSlip,
				out stockDetailList,
				out stockDetailTable);

			if (stockDetailTable == null)
            {
                return;
            }

            Supplier supplier;
            SupplierAcs supplierAcs = new SupplierAcs();
            int rstatus = 0;

			for (int i = 0; i < stockDetailTable.Count; i++)
            {
                int stockRowNo = stockDetailTable[i].StockRowNo;

				//stockDetailTable[i].StockGoodsCd
				//stockDetailTable[i].StockPriceConsTax


                string goodsName = stockDetailTable[i].GoodsName;
                string warehouseCode = stockDetailTable[i].WarehouseCode;
                string warehouseName = stockDetailTable[i].WarehouseName;
                string warehouseShelfNo = stockDetailTable[i].WarehouseShelfNo; // ADD 2009/03/16
				string goodsCode = stockDetailTable[i].GoodsNo;

				double stockUnitPriceDisplay = stockDetailTable[i].StockUnitPriceDisplay;
				//double stockUnitPrice = stockDetailTable[i].StockUnitPrice;

				double stockUnitPrice = stockDetailTable[i].StockUnitPriceFl;


				double stockCount = stockDetailTable[i].StockCount;
                long stockPriceDisplay = stockDetailTable[i].StockPriceDisplay;
                long stockPrice = stockDetailTable[i].StockPriceTaxInc;
                int taxationCode = stockDetailTable[i].TaxationCode;
                string stockDtiSlipNote1 = stockDetailTable[i].StockDtiSlipNote1;
				int goodsMakerCd = stockDetailTable[i].GoodsMakerCd;
				string makerName = stockDetailTable[i].MakerName;
                // 2009.01.05 Add [9486]
                string blGoodsCodeString = string.Empty;
                if (stockDetailTable[i].BLGoodsCode > 0)
                {
                    blGoodsCodeString = stockDetailTable[i].BLGoodsCode.ToString();
                }
                // 2009.01.05 Add [9486]

				//税名称
				string taxationCodeString = "";
				switch(taxationCode)
				{
					case 0:
						taxationCodeString = "外税";
						break;
					case 1:
						taxationCodeString = "非課税";
						break;
					case 2:
						taxationCodeString = "内税";
						break;
					default:
						taxationCodeString = "";
						break;
				}



				//消費税調整・残高調整
				if ((stockDetailTable[i].StockGoodsCd == 2) || (stockDetailTable[i].StockGoodsCd == 4))
				{
					stockPriceTaxExc = 0;
					stockPriceConsTax = stockDetailTable[i].StockPriceConsTax;
				}
				else if ((stockDetailTable[i].StockGoodsCd == 3) || (stockDetailTable[i].StockGoodsCd == 5))
				{
					stockPriceTaxExc = stockDetailTable[i].StockPriceTaxInc;
					stockPriceConsTax = 0;
				}
				else
				{
					stockPriceTaxExc = stockDetailTable[i].StockPriceTaxExc;
					stockPriceConsTax = stockDetailTable[i].StockPriceConsTax;
				}

                // 消費税転嫁方式により表示を変更

                if (String.IsNullOrEmpty(stockDetailTable[i].SupplierSnm) && stockDetailTable[i].SupplierCd > 0)
                {
                    rstatus = supplierAcs.Read(out supplier, this._enterpriseCode, stockDetailTable[i].SupplierCd);

                    if (rstatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        stockDetailTable[i].SupplierSnm = supplier.SupplierSnm;
                    }
                }


				this._dataSet.StockDetail.AddStockDetailRow(
															i+1,
															supplierFormal,
															supplierSlipNo,
                                                            stockRowNo,
															goodsCode,
															goodsName,
															warehouseCode,
															warehouseName,
                                                            stockUnitPriceDisplay,
															stockUnitPrice,
                                                            stockCount,
															stockPriceTaxExc, //stockPriceDisplay,
															stockPrice,
															stockPriceConsTax,
															taxationCodeString,
                                                            stockDtiSlipNote1,
															goodsMakerCd,
															makerName,
															stockDetailTable[i].OrderCnt + stockDetailTable[i].OrderAdjustCnt,
															stockDetailTable[i].OrderCnt + stockDetailTable[i].OrderAdjustCnt,
															stockDetailTable[i].OrderRemainCnt,
                                                            stockDetailTable[i].SupplierCd,
                                                            stockDetailTable[i].SupplierSnm,
                                                            stockDetailTable[i].BLGoodsCode,
                                                            stockDetailTable[i].ListPriceTaxExcFl,
                                                            0,
                                                            blGoodsCodeString,   // 2009.01.05 Add [9486]
                                                            warehouseShelfNo // ADD 2009/03/16
															);
			}
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
        public bool CheckGoodsExist(string goodsCode)
        {
            List<GoodsUnitData> goodsUnitDataList;
            GoodsAcs goodsAcs = new GoodsAcs();

            // 商品コードのみの指定で
            int status = goodsAcs.Read(this._enterpriseCode, goodsCode,out goodsUnitDataList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
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
		public bool CheckGoodsExist(string goodsCode, out string goodsName)
		{
			List<GoodsUnitData> goodsUnitDataList;
			GoodsAcs goodsAcs = new GoodsAcs();
			goodsName = "";

			// 商品コードのみの指定で
			int status = goodsAcs.Read(this._enterpriseCode, goodsCode, out goodsUnitDataList);

			if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList.Count != 0))
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
		/// 商品名称取得処理
		/// </summary>
		/// <param name="goodsCode">商品コード</param>
		/// <returns>true:存在あり、false:存在しない</returns>
		public bool CheckGoodsExist(string goodsCode, out string goodsName, out int goodsMakerCd, out string makerName)
		{
			List<GoodsUnitData> goodsUnitDataList;
			GoodsAcs goodsAcs = new GoodsAcs();
			goodsName = "";
			goodsMakerCd = 0;
			makerName = "";

			// 商品コードのみの指定で
			int status = goodsAcs.Read(this._enterpriseCode, goodsCode, out goodsUnitDataList);

			if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList.Count != 0))
			{
				goodsName = goodsUnitDataList[0].GoodsName;

				makerName = goodsUnitDataList[0].MakerName;
				goodsMakerCd = goodsUnitDataList[0].GoodsMakerCd;
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

        // 2008.12.25 [9571]
        ///// <summary>
        ///// 本社機能／拠点機能チェック処理
        ///// </summary>
        ///// <returns>true:本社機能 false:拠点機能</returns>
        //public bool IsMainOfficeFunc()
        //{
        //    bool isMainOfficeFunc = false;

        //    // 拠点制御アクセスクラスインスタンス化処理
        //    this.CreateSecInfoAcs();

        //    // ログイン担当拠点情報の取得
        //    SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

        //    if (secInfoSet != null)
        //    {
        //        // 本社機能か？
        //        if (secInfoSet.MainOfficeFuncFlag == 1)
        //        {
        //            isMainOfficeFunc = true;
        //        }
        //    }
        //    else
        //    {
        //        throw new ApplicationException(MESSAGE_NONOWNSECTION);
        //    }

        //    return isMainOfficeFunc;
        //}
        // 2008.12.25 [9571]

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
