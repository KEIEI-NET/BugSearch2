//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 単品売価設定一括登録・修正
// プログラム概要   : 掛率マスタの単品設定分を対象に、複数件一括で登録・修正、一括削除、引用登録を行う。
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2010/08/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 修 正 日  2010/08/27  修正内容 : 単品売価一括登録修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2010/09/16  修正内容 : Redmine#14182の速度ＵＰ対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2010/09/26  修正内容 : Redmine#14182の速度ＵＰ対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李永平
// 修 正 日  2010/12/03  修正内容 : 障害改良対応（１２月分）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 凌小青
// 修 正 日  2011/11/02  修正内容 : Redmine#26319の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 凌小青
// 修 正 日  2011/11/23  修正内容 : Redmine#7744の対応
//----------------------------------------------------------------------------//

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using System.Data;

using System.Threading;    // ADD 2010/09/26 

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 単品売価設定一括登録・修正アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率マスタ一括修正・登録のアクセス制御を行います。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2010/08/04</br>
    /// <br>Update Note: 2010/09/16 譚洪</br>
    /// <br>           : Redmine#14182の速度ＵＰ対応</br>
    /// </remarks>
    public class GoodsRateSetUpdateAcs
    {
        #region ■ Private Members
        // 掛率マスタリモート
        private ISingleGoodsRateDB _iRateDB = null;
        /// <summary>商品入力アクセスクラス</summary>
        GoodsAcs _goodsAcs;

        // 抽出中断フラグ
        private bool _extractCancelFlag;
        private string _enterpriseCode;
        /// <summary>自拠点コード</summary>
        private string _loginSectionCode = "";

        // ADD 2010/09/26 --- >>>>
        GoodsAcs _goodsAcs2;
        GoodsAcs _goodsAcs3;

        private Thread _readInitialThread;
        private Thread _readInitialThreadSecond;
        private Thread _readInitialThreadThird;

        private Thread _readInitialThreadForth;
        private Thread _readInitialThreadFivth;
        private Thread _readInitialThreadSixth;

        ArrayList thread1Arr = null;
        ArrayList thread2Arr = null;
        ArrayList thread3Arr = null;

        ArrayList thread1ArrResult = null;
        ArrayList thread2ArrResult = null;
        ArrayList thread3ArrResult = null;

        GoodsRateSetSearchParam rateSearchParam;

        private UnitPriceCalculation _unitPriceCalculation;
        private TaxRateSet _taxRateSet;
        private StockProcMoneyAcs _stockProcMoneyAcs;   // 単価算出クラスアクセスクラス
        private TaxRateSetAcs _taxRateSetAcs;           // 税率設定マスタアクセスクラス
        // ADD 2010/09/26 --- <<<<

        #endregion ■ Private Members


        #region ■ Construcstor
        /// <summary>
        /// 単品売価設定一括登録・修正アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 単品売価設定一括登録・修正アクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        /// </remarks>
        public GoodsRateSetUpdateAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iRateDB = (ISingleGoodsRateDB)MediationSingleGoodsRateDB.GetSingleGoodsRateDB();

                // UPD 2010/09/26 --- >>>>
                //this._goodsAcs = new GoodsAcs();
                //this._goodsAcs.IsLocalDBRead = false;

                rateSearchParam = new GoodsRateSetSearchParam();

                thread1Arr = new ArrayList();
                thread2Arr = new ArrayList();
                thread3Arr = new ArrayList();

                thread1ArrResult = new ArrayList();
                thread2ArrResult = new ArrayList();
                thread3ArrResult = new ArrayList();

                this._unitPriceCalculation = new UnitPriceCalculation();
                this._stockProcMoneyAcs = new StockProcMoneyAcs();
                this._taxRateSetAcs = new TaxRateSetAcs();

                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                if (LoginInfoAcquisition.Employee != null)
                {
                    this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                }

                //string msg;

                //// メニューモード時はサーバー読み込み固定
                //this._goodsAcs.IsLocalDBRead = false;

                //// 初期値データ取得
                //int status = this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out msg);
                
                //switch (status)
                //{
                //    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                //        {
                //            break;
                //        }
                //    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                //    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                //        {
                //            break;
                //        }
                //    default:
                //        {
                //            break;
                //        }
                //}

                //status = this._goodsAcs.SearchInitialForMst(this._enterpriseCode, this._loginSectionCode, out msg); // ADD 2010/08/27

                this._readInitialThread = new Thread(this.ReadInitialThread);
                this._readInitialThread.Start();
                this._readInitialThreadSecond = new Thread(this.ReadInitialThreadSecond);
                this._readInitialThreadSecond.Start();
                this._readInitialThreadThird = new Thread(this.ReadInitialThreadThird);
                this._readInitialThreadThird.Start();

                ReadInitData();
                ReadTaxRate();
                // UPD 2010/09/26 --- <<<<

            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iRateDB = null;
                this._goodsAcs = null;
            }
        }
        #endregion ■ Construcstor

        #region プロパティ
        /// <summary>
        /// 抽出中断フラグ
        /// </summary>
        public bool ExtractCancelFlag
        {
            get { return _extractCancelFlag; }
            set { _extractCancelFlag = value; }
        }
        #endregion // プロパティ


        #region ■ Public Methods
        /// <summary>
        /// 掛率マスタ更新処理
        /// </summary>
        /// <param name="saveList">保存リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 掛率マスタを更新します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        /// </remarks>
        public int Write(ArrayList saveList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraRateList = new ArrayList();

                for (int i = 0; i < saveList.Count; i++)
                {
                    // クラスメンバコピー処理
                    paraRateList.Add(CopyToRateWorkFromRate((Rate)saveList[i]));
                }

                object paraObj = (object)paraRateList;

                status = this._iRateDB.Write(ref paraObj);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// 掛率マスタ削除処理
        /// </summary>
        /// <param name="deleteList">削除リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 掛率マスタを削除します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        /// </remarks>
        public int Delete(ArrayList deleteList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                byte[] paraRateWork = null;
                ArrayList rateWorkList = new ArrayList();

                for (int i = 0; i < deleteList.Count; i++)
                {
                    // クラスメンバコピー処理
                    rateWorkList.Add(CopyToRateWorkFromRate((Rate)deleteList[i]));
                }

                // ArrayListから配列を生成
                SingleGoodsRateWork[] rateWorks = (SingleGoodsRateWork[])rateWorkList.ToArray(typeof(SingleGoodsRateWork));

                // シリアライズ
                paraRateWork = XmlByteSerializer.Serialize(rateWorks);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// 掛率マスタ検索処理
        /// </summary>
        /// <param name="rateSearchResultList">掛率マスタ検索結果リスト</param>
        /// <param name="rateSearchParam">掛率マスタ検索条件</param>
        /// <remarks>
        /// <br>Note       : 掛率マスタを検索します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        /// <br>Update Note: 2010/09/16 譚洪 Redmine#14182の速度ＵＰ対応</br>
        /// <br>Update Note: 2010/12/03 李永平　障害改良対応（１２月分）</br>
        /// </remarks>
        public int Search(out List<GoodsRateSetSearchResult> rateSearchResultList, GoodsRateSetSearchParam rateSearch)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // ADD 2010/12/03 --- >>>>
            if (this._readInitialThread != null)
            {
                while (this._readInitialThread.ThreadState == ThreadState.Running
                       || this._readInitialThread.ThreadState == ThreadState.WaitSleepJoin)
                {
                    Thread.Sleep(100);
                }
            }

            if (this._readInitialThreadSecond != null)
            {
                while (this._readInitialThreadSecond.ThreadState == ThreadState.Running
                       || this._readInitialThreadSecond.ThreadState == ThreadState.WaitSleepJoin)
                {
                    Thread.Sleep(100);
                }
            }

            if (this._readInitialThreadThird != null)
            {
                while (this._readInitialThreadThird.ThreadState == ThreadState.Running
                       || this._readInitialThreadThird.ThreadState == ThreadState.WaitSleepJoin)
                {
                    Thread.Sleep(100);
                }
            }
            // ADD 2010/12/03 --- <<<<

            // ADD 2010/09/26 --- >>>
            thread1Arr = new ArrayList();
            thread2Arr = new ArrayList();
            thread3Arr = new ArrayList();

            thread1ArrResult = new ArrayList();
            thread2ArrResult = new ArrayList();
            thread3ArrResult = new ArrayList();
            // ADD 2010/09/26 --- <<<

            rateSearchResultList = new List<GoodsRateSetSearchResult>();

            this.rateSearchParam = rateSearch;  // ADD 2010/09/26

            try
            {
                // クラスメンバコピー処理(E→D)
                SingleGoodsRateSearchParamWork paraWork = CopyToRateSearchParamWorkFromRateSearchParam(rateSearchParam);

                object paraObj = paraWork;
                object retObj;

                if (_extractCancelFlag == true) return 0;

                status = this._iRateDB.SearchRate(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData01);

                if (_extractCancelFlag == true) return 0;

                if (status == 0)
                {
                    //ArrayList retWorkList = retObj as ArrayList;   // DEL 2010/09/16
                    // ADD 2010/09/16  --- >>>>
                    ArrayList retWorkListTemp = retObj as ArrayList;
                    ArrayList retWorkList = new ArrayList();

                    // 重複しているデータがある場合は、最小ロット数のデータを取得
                    Dictionary<string, SingleGoodsRateSearchResultWork> parentDic = new Dictionary<string, SingleGoodsRateSearchResultWork>();
                    foreach (SingleGoodsRateSearchResultWork retWork in retWorkListTemp)
                    {
                        // ------------DEL  BY 凌小青 2011/11/02 -------------->>>>>>>>>>>>>>>>   
                        //string key = MakeParentKey(retWork);
                        //if (!parentDic.ContainsKey(key))
                        //{
                        //    parentDic.Add(key, retWork);
                        //} 
                        //else
                        //{
                        //    if (retWork.LotCount < parentDic[key].LotCount)
                        //    {
                        //        parentDic[key] = retWork;
                        //    }
                        //}
                        // ------------DEL  BY 凌小青 2011/11/02 --------------<<<<<<<<<<<<<<<

                        // ------------ADD  BY 凌小青 2011/11/02 -------------->>>>>>>>>>>>>>>>
                        if (retWork.CustomerCode != 0)
                        {
                            string key = MakeParentKey(retWork);
                            if (!parentDic.ContainsKey(key + retWork.CustomerCode))
                            {
                                parentDic.Add(key + retWork.CustomerCode, retWork);
                            }
                            else
                            {
                                if (retWork.LotCount < parentDic[key + retWork.CustomerCode].LotCount)
                                {
                                    parentDic[key + retWork.CustomerCode] = retWork;
                                }
                            }
                        }
                        else
                        {
                            string key = MakeParentKey(retWork);
                            if (!parentDic.ContainsKey(key + retWork.CustRateGrpCode))
                            {
                                parentDic.Add(key + retWork.CustRateGrpCode, retWork);
                            }
                            else
                            {
                                if (retWork.LotCount < parentDic[key + retWork.CustRateGrpCode].LotCount)
                                {
                                    parentDic[key + retWork.CustRateGrpCode] = retWork;
                                }
                            }
                        }
                        // ------------ADD  BY 凌小青 2011/11/02 --------------<<<<<<<<<<<<<<<<<<<
                    }

                    foreach (SingleGoodsRateSearchResultWork result in parentDic.Values)
                    {
                        retWorkList.Add(result);
                    }
                    // ADD 2010/09/16  --- <<<<

                    // ADD 2010/09/26 --- >>>
                    // --- ADD 2010/08/27 ---------->>>>>
                    // 初期値データ取得
                    //string msgInit;
                    //this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out msgInit); // DEL 2010/08/27

                    //GoodsInputDataSet.GoodsPriceDataTable dt = new GoodsInputDataSet.GoodsPriceDataTable();
                    //GoodsInputDataSet.GoodsPriceRow goodsPriceRow = dt.NewGoodsPriceRow();
                    // --- ADD 2010/08/27 ----------<<<<<

                    int threadCount = 0;

                    threadCount = retWorkList.Count / 3;

                    for (int i = 0; i < retWorkList.Count; i++)
                    {
                        SingleGoodsRateSearchResultWork retWork = (SingleGoodsRateSearchResultWork)retWorkList[i];
                        if (threadCount > i)
                        {
                            thread1Arr.Add(retWork);
                        }
                        else if ((i >= threadCount) && (i < (threadCount * 2)))
                        {
                            thread2Arr.Add(retWork);
                        }
                        else
                        {
                            thread3Arr.Add(retWork);
                        }
                    }

                    if (thread1Arr.Count > 0)
                    {
                        this._readInitialThreadForth = new Thread(this.ReadInitialForth);
                        this._readInitialThreadForth.Start();
                    }

                    if (thread2Arr.Count > 0)
                    {
                        this._readInitialThreadFivth = new Thread(this.ReadInitialThreadFivth);
                        this._readInitialThreadFivth.Start();
                    }

                    if (thread3Arr.Count > 0)
                    {
                        this._readInitialThreadSixth = new Thread(this.ReadInitialThreadSixth);
                        this._readInitialThreadSixth.Start();
                    }

                    if (this._readInitialThreadForth != null) // ADD 2010/12/03
                    {// ADD 2010/12/03
                        while (this._readInitialThreadForth.ThreadState == ThreadState.Running
                          || this._readInitialThreadForth.ThreadState == ThreadState.WaitSleepJoin)
                        {
                            Thread.Sleep(100);
                        }
                    }// ADD 2010/12/03

                    if (this._readInitialThreadFivth != null)// ADD 2010/12/03
                    {
                        while (this._readInitialThreadFivth.ThreadState == ThreadState.Running
                               || this._readInitialThreadFivth.ThreadState == ThreadState.WaitSleepJoin)
                        {
                            Thread.Sleep(100);
                        }
                    }// ADD 2010/12/03

                    if (this._readInitialThreadSixth != null)// ADD 2010/12/03
                    {
                        while (this._readInitialThreadSixth.ThreadState == ThreadState.Running
                              || this._readInitialThreadSixth.ThreadState == ThreadState.WaitSleepJoin)
                        {
                            Thread.Sleep(100);
                        }
                    }// ADD 2010/12/03
                    

                    foreach (GoodsRateSetSearchResult thread1Work in this.thread1ArrResult)
                    {
                        rateSearchResultList.Add(thread1Work);
                    }

                    foreach (GoodsRateSetSearchResult thread2Work in this.thread2ArrResult)
                    {
                        rateSearchResultList.Add(thread2Work);
                    }

                    foreach (GoodsRateSetSearchResult thread3Work in this.thread3ArrResult)
                    {
                        rateSearchResultList.Add(thread3Work);
                    }

                    //foreach (SingleGoodsRateSearchResultWork retWork in retWorkList)
                    //{
                    //    if (_extractCancelFlag == true)
                    //    {
                    //        break;
                    //    }
                    //    // クラスメンバコピー処理(D→E)
                    //    //商品管理情報マスタと価格マスタ情報の取得

                    //    List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                    //    GoodsUnitData goodsUnitData = new GoodsUnitData();
                    //    string msg = string.Empty;
                    //    GoodsCndtn cndtn = new GoodsCndtn();
                    //    // --- UPD 2010/09/07 ---------->>>>>
                    //    //cndtn.EnterpriseCode = this._enterpriseCode;
                    //    //cndtn.GoodsMakerCd = retWork.GoodsMakerCd;
                    //    //cndtn.GoodsNo = retWork.GoodsNo;
                    //    //if ("00".Equals(rateSearchParam.SectionCode[0]))
                    //    //    cndtn.SectionCode = this._goodsAcs.LoginSectionCode;
                    //    //else
                    //    //    cndtn.SectionCode = rateSearchParam.SectionCode[0];
                    //    //cndtn.PriceApplyDate = DateTime.Today;
                    //    //cndtn.LogicalMode = (int)ConstantManagement.LogicalMode.GetData01;
                    //    cndtn.EnterpriseCode = this._enterpriseCode;
                    //    if ("00".Equals(rateSearchParam.SectionCode[0]))
                    //        cndtn.SectionCode = this._goodsAcs.LoginSectionCode;
                    //    else
                    //        cndtn.SectionCode = rateSearchParam.SectionCode[0];
                    //    cndtn.GoodsMakerCd = retWork.GoodsMakerCd;
                    //    cndtn.BLGoodsCode = retWork.BLGoodsCode;
                    //    cndtn.GoodsNo = retWork.GoodsNo;
                    //    cndtn.GoodsKindCode = 9;
                    //    cndtn.IsSettingSupplier = 1;
                    //    // --- UPD 2010/09/07 ----------<<<<<
                    //    //status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(cndtn, out goodsUnitDataList, out msg); // DEL 2010/08/27
                    //    // --- UPD 2010/09/07 ---------->>>>>
                    //    //status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(cndtn, false, out goodsUnitDataList, out msg); // ADD 2010/08/27
                    //    status = this._goodsAcs.Search(cndtn, out goodsUnitDataList, out msg);
                    //    // --- UPD 2010/09/07 ----------<<<<<

                    //    if (goodsUnitDataList.Count > 0)
                    //    {
                    //        goodsUnitData = goodsUnitDataList[0];
                    //        // --- ADD 2010/09/07 ---------->>>>>
                    //        this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);
                    //        // --- ADD 2010/09/07 ----------<<<<<
                    //        switch (goodsUnitData.OfferKubun)
                    //        {
                    //            case 0: // ユーザー登録
                    //            case 1: // 提供純正編集
                    //            case 2: // 提供優良編集
                    //                if (goodsUnitData.LogicalDeleteCode == 0)
                    //                {
                    //                    // 仕入先
                    //                    retWork.GoodsSupplierCd = goodsUnitData.SupplierCd;

                    //                    if (goodsUnitData != null && goodsUnitData.GoodsPriceList != null)
                    //                    {
                    //                        if (goodsUnitData.GoodsPriceList.Count > 0)
                    //                        {
                    //                            // --- UPD 2010/08/27 ---------->>>>>
                    //                            //GoodsPrice goodsPrice = goodsUnitData.GoodsPriceList[0];
                    //                            //GoodsPrice goodsPrice = GetGoodsPriceByPriceStartDate(DateTime.Today, goodsUnitData.GoodsPriceList);

                    //                            //// UPD 2010/08/27 ---->>>>>
                    //                            //// 標準価格
                    //                            //if (goodsPrice != null)
                    //                            //{
                    //                            //    retWork.ListPrice = goodsPrice.ListPrice;
                    //                            //}
                    //                            //else
                    //                            //{
                    //                            //    return (status);
                    //                            //}
                    //                            //// UPD 2010/08/27 ----<<<<<
                    //                            ////// 原単価
                    //                            ////retWork.SalesUnitCost = goodsPrice.SalesUnitCost;

                    //                            //// 価格情報を再計算するので初期化
                    //                            //goodsPriceRow.CalcStockRate = 0.0;          // 計算原価率
                    //                            //goodsPriceRow.CalcSalesUnitCost = 0.0;      // 計算原価額
                    //                            //goodsPriceRow.CalcMaster = string.Empty;    // 算出マスタ
                    //                            //goodsPriceRow.PriorityOrder = 0;            // 優先順位
                    //                            //goodsPriceRow.EnterpriseCode = goodsPrice.EnterpriseCode;
                    //                            //goodsPriceRow.GoodsMakerCd = goodsPrice.GoodsMakerCd;
                    //                            //goodsPriceRow.GoodsNo = goodsPrice.GoodsNo;
                    //                            //goodsPriceRow.ListPrice = goodsPrice.ListPrice;

                    //                            //goodsPriceRow.SalesUnitCost = goodsPrice.SalesUnitCost;
                    //                            //goodsPriceRow.StockRate = goodsPrice.StockRate;
                    //                            //goodsPriceRow.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;
                    //                            //goodsPriceRow.PriceStartDate = goodsPrice.PriceStartDate;

                    //                            //// --- ADD 2010/09/07 ---------->>>>>
                    //                            //if (goodsPrice.ListPrice != 0)
                    //                            //{
                    //                            //// --- ADD 2010/09/07 ----------<<<<<
                    //                            //    this._goodsAcs.CalclateUnitPrice(goodsPriceRow, goodsUnitData);             // 単価算出
                    //                            //    this._goodsAcs.SettingCalcMaster(goodsPriceRow);                            // 算出マスタ
                    //                            //    this._goodsAcs.SettingCalcStockRate(goodsPriceRow);                         // 算出用原価率
                    //                            //    this._goodsAcs.SettingCalcSalesUnitCost(goodsPriceRow);                     // 算出用原価単価
                    //                            //    if (!goodsPriceRow.PriceStartDate.Equals(DateTime.MinValue))
                    //                            //    {
                    //                            //        retWork.SalesUnitCost = goodsPriceRow.CalcSalesUnitCost;    // 原単価
                    //                            //    }
                    //                            //////// --- ADD 2010/09/07 ---------->>>>>
                    //                            //}
                    //                            // --- ADD 2010/09/07 ----------<<<<<
                    //                            // --- UPD 2010/08/27 ----------<<<<<

                    //                            GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Now, goodsUnitData.GoodsPriceList);//ddd
                    //                            if (goodsPrice != null)
                    //                            {
                    //                                retWork.ListPrice = goodsPrice.ListPrice;
                    //                            }

                    //                            retWork.SalesUnitCost = GetStockUnitPrice(goodsUnitData);
                    //                        }
                    //                    }
                    //                }
                    //                break;
                    //            default:
                    //                break;
                    //        }
                    //    }
                    //    rateSearchResultList.Add(CopyToRateSearchResultFromRateSearchResultWork(retWork));
                    //}
                }
                // ADD 2010/09/26 --- <<<
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                rateSearchResultList = new List<GoodsRateSetSearchResult>();
            }

            return (status);
        }

        // ADD 2010/09/26 --- >>>
        /// <summary>
        /// 原単価取得処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>原単価</returns>
        private Double GetStockUnitPrice(GoodsUnitData goodsUnitData)
        {
            Double stockUnitPrice = 0;

            // 商品連結データから単価算出結果オブジェクトを取得
            UnitPriceCalcRet unitPriceCalcRet = GetUnitPriceCalcRet(goodsUnitData);

            // 単価算出結果オブジェクトより原単価取得
            stockUnitPrice = unitPriceCalcRet.UnitPriceTaxExcFl;

            return stockUnitPrice;
        }

        /// <summary>
        /// 単価算出結果オブジェクト取得処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>単価算出結果オブジェクト</returns>
        private UnitPriceCalcRet GetUnitPriceCalcRet(GoodsUnitData goodsUnitData)
        {
            // 単価算出パラメータ設定
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
            unitPriceCalcParam.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();    // 拠点コード
            unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                               // 商品メーカーコード
            unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                                         // 商品番号
            unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                             // 商品掛率ランク
            unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsMGroup;                            // 商品掛率グループコード
            unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                                 // BLグループコード
            unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                                 // BL商品コード
            unitPriceCalcParam.SupplierCd = goodsUnitData.SupplierCd;                                   // 仕入先コード
            unitPriceCalcParam.PriceApplyDate = DateTime.Today;                                              // 価格適用日
            unitPriceCalcParam.CountFl = 1;                                                             // 数量
            unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                             // 課税区分
            unitPriceCalcParam.TaxRate = TaxRateSetAcs.GetTaxRate(this._taxRateSet, DateTime.Today);         // 税率
            unitPriceCalcParam.StockCnsTaxFrcProcCd = goodsUnitData.StockCnsTaxFrcProcCd;               // 仕入消費税端数処理コード
            unitPriceCalcParam.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;                 // 仕入単価端数処理コード

            List<UnitPriceCalcRet> unitPriceCalcRetList;
            this._unitPriceCalculation.CalculateUnitCost(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);

            foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
            {
                if (unitPriceCalcRetWk.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                {
                    return unitPriceCalcRetWk;
                }
            }

            return new UnitPriceCalcRet();
        }
        // ADD 2010/09/26 --- <<<

        // ADD 2010/09/16 --- >>>>
        /// <summary>
        /// Key作成処理
        /// </summary>
        /// <param name="result">掛率マスタ検索結果</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note        : Keyを作成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private string MakeParentKey(SingleGoodsRateSearchResultWork result)
        {
            // 品番＋メーカーコード＋BLコード + グループコード + 仕入先コード
            string key = result.GoodsMakerCd.ToString("0000") + "\\" +
                         result.BLGoodsCode.ToString("00000") + "\\" +
                         result.BLGroupCode.ToString("00000") + "\\" +
                         result.GoodsSupplierCd.ToString("000000") + "\\" +
                         result.UnitRateSetDivCd + "\\" +  //ADD BY 凌小青 on 2011/11/23 for Redmine#7744 
                         result.GoodsNo;

            return key;
        }
        // ADD 2010/09/16 --- <<<<

        // --- ADD 2010/08/27 ---------->>>>>
        /// <summary>
        /// 指定された日時に合う価格情報レコードを取得します。
        /// </summary>
        /// <param name="dateTime">日時</param>
        /// <returns>
        /// 価格開始日≦指定日時のレコードのうち、最近のものを返します。
        /// （指定日時より未来のレコードは無視されます）
        /// </returns>
        private GoodsPrice GetGoodsPriceByPriceStartDate(DateTime dateTime, List<GoodsPrice> goodsPriceList)
        {
            // 価格情報グリッドの最大行数　※保存、起動のタイミングで開始日付の昇順にソートされる
            int rowCount = goodsPriceList.Count;

            // 価格開始日で価格情報レコードをソート（降順）
            SortedList<DateTime, GoodsPrice> sortedGoodsPriceRowList = new SortedList<DateTime, GoodsPrice>();
            for (int i = 0; i < rowCount; i++)
            {
                DateTime key = goodsPriceList[i].PriceStartDate;
                if (key.Equals(DateTime.MinValue))
                {
                    key = key.AddMilliseconds((double)(rowCount - i));
                }
                sortedGoodsPriceRowList.Add(key, goodsPriceList[i]);
            }
            // --- DEL 2010/09/07 ---------->>>>>
            //// 価格開始日≦指定日時のレコードのうち、最近のものを返す
            //for (int i = rowCount - 1; i >= 0; i--)
            //{
            //    DateTime key = sortedGoodsPriceRowList.Keys[i];
            //    if (sortedGoodsPriceRowList[key].PriceStartDate <= dateTime)
            //    {
            //        return sortedGoodsPriceRowList[key];
            //    }
            //}
            //return null;    // 価格開始日が未来のレコードしかない場合
            // --- DEL 2010/09/07 ----------<<<<<

            // --- ADD 2010/09/07 ---------->>>>>
            int count = 0;
            bool flag = false;
            for (int i = rowCount - 1; i >= 0; i--)
            {
                DateTime key = sortedGoodsPriceRowList.Keys[i];
                if (sortedGoodsPriceRowList[key].PriceStartDate <= dateTime)
                {
                    count = i;
                    flag = true;
                    break;
                }
            }

            // 価格開始日≦システム日付
            if (flag)
            {
                DateTime key = sortedGoodsPriceRowList.Keys[count];
                return sortedGoodsPriceRowList[key];
            }
            else
            {
                // 価格開始日 > システム日付
                if (rowCount != 0)
                {
                    DateTime key = sortedGoodsPriceRowList.Keys[0];
                    sortedGoodsPriceRowList[key].ListPrice = 0;
                    sortedGoodsPriceRowList[key].SalesUnitCost = 0;
                    sortedGoodsPriceRowList[key].StockRate = 0;
                    return sortedGoodsPriceRowList[key];
                }
                // 価格開始日はNULL
                else
                {
                    GoodsPrice gPrice = new GoodsPrice();
                    gPrice.ListPrice = 0;
                    gPrice.SalesUnitCost = 0;
                    gPrice.StockRate = 0;
                    return gPrice;
                }
            }
            // --- ADD 2010/09/07 ----------<<<<<
        }

        /// <summary>
        /// 初期値データ取得
        /// </summary>
        public void RenewalSearchInitial()
        {
            // 初期値データ取得
            string msgInit;
            this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out msgInit);
        }
        // --- ADD 2010/08/27 ----------<<<<<

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <param name="delRateList">削除データリスト</param>
        /// <param name="updRateList">更新データリスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 保存処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        /// </remarks>
        public int Save(ref ArrayList delRateList, ref ArrayList updRateList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                RateWork delRateWork = null;
                RateWork updRateWork = null;
                ArrayList delRateWorkList = new ArrayList();	// ワーククラス格納用ArrayList
                ArrayList updRateWorkList = new ArrayList();	// ワーククラス格納用ArrayList

                // ワーククラス格納用ArrayListへ詰め替え
                for (int i = 0; i < delRateList.Count; i++)
                {
                    // クラスデータをワーククラスデータに変換
                    delRateWork = CopyToRateWorkFromRate((Rate)delRateList[i]);
                    delRateWorkList.Add(delRateWork);
                }

                for (int i = 0; i < updRateList.Count; i++)
                {
                    // クラスデータをワーククラスデータに変換
                    updRateWork = CopyToRateWorkFromRate((Rate)updRateList[i]);
                    updRateWorkList.Add(updRateWork);
                }

                object delparaObj = (object)delRateWorkList;
                object updparaObj = (object)updRateWorkList;

                // 保存処理
                status = this._iRateDB.Save(delparaObj, updparaObj, ref message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 何かしらのエラー発生
                    message = "保存に失敗しました。";
                    return status;
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // オフライン時はnullをセット
                this._iRateDB = null;
                // 通信エラー
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        #endregion ■ Public Methods


        #region ■ Private Methods
        /// <summary>
        /// クラスメンバコピー処理(E→D)
        /// </summary>
        /// <param name="rateSearchParam">掛率マスタ検索条件</param>
        /// <returns>掛率マスタ検索条件ワーク</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        /// </remarks>
        private SingleGoodsRateSearchParamWork CopyToRateSearchParamWorkFromRateSearchParam(GoodsRateSetSearchParam rateSearchParam)
        {
            SingleGoodsRateSearchParamWork paraWork = new SingleGoodsRateSearchParamWork();

            paraWork.EnterpriseCode = rateSearchParam.EnterpriseCode;       // 企業コード
            paraWork.SectionCode = rateSearchParam.SectionCode;             // 拠点コード
            paraWork.SupplierCd = rateSearchParam.SupplierCd;               // 仕入先コード
            paraWork.GoodsRateGrpCode = rateSearchParam.GoodsRateGrpCode;   // 商品掛率グループコード
            paraWork.GoodsMakerCd = rateSearchParam.GoodsMakerCd;           // メーカーコード
            paraWork.CustomerCode = rateSearchParam.CustomerCode;           // 得意先コード
            paraWork.CustRateGrpCode = rateSearchParam.CustRateGrpCode;     // 得意先掛率グループコード
            paraWork.PrmSectionCode = rateSearchParam.PrmSectionCode;       // ログイン拠点コード
            paraWork.GoodsNo = rateSearchParam.GoodsNo;       // 品番
            paraWork.BlGoodsCode = rateSearchParam.BlGoodsCode;       // BLコード
            paraWork.BlGroupCode = rateSearchParam.BlGroupCode;       // BLグループコード
            paraWork.ObjectDiv = rateSearchParam.ObjectDiv;       // 対象区分
            paraWork.UnSettingFlg = rateSearchParam.UnSettingFlg;       // 未設定

            return paraWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(D→E)
        /// </summary>
        /// <param name="rateSearchResultWork">掛率マスタ検索結果ワーク</param>
        /// <returns>掛率マスタ検索結果</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        /// </remarks>
        private GoodsRateSetSearchResult CopyToRateSearchResultFromRateSearchResultWork(SingleGoodsRateSearchResultWork rateSearchResultWork)
        {
            GoodsRateSetSearchResult result = new GoodsRateSetSearchResult();

            // 掛率マスタより取得
            result.CreateDateTime = rateSearchResultWork.CreateDateTime;            // 作成日時
            result.UpdateDateTime = rateSearchResultWork.UpdateDateTime;            // 更新日時
            result.EnterpriseCode = rateSearchResultWork.EnterpriseCode;            // 企業コード
            result.FileHeaderGuid = rateSearchResultWork.FileHeaderGuid;            // GUID
            result.UpdEmployeeCode = rateSearchResultWork.UpdEmployeeCode;          // 更新従業員コード
            result.UpdAssemblyId1 = rateSearchResultWork.UpdAssemblyId1;            // 更新アセンブリID1
            result.UpdAssemblyId2 = rateSearchResultWork.UpdAssemblyId2;            // 更新アセンブリID2
            result.LogicalDeleteCode = rateSearchResultWork.LogicalDeleteCode;      // 論理削除区分
            result.SectionCode = rateSearchResultWork.SectionCode;                  // 拠点コード
            result.UnitRateSetDivCd = rateSearchResultWork.UnitRateSetDivCd;        // 単価掛率設定区分
            result.UnitPriceKind = rateSearchResultWork.UnitPriceKind;              // 単価種類
            result.RateSettingDivide = rateSearchResultWork.RateSettingDivide;      // 掛率設定区分
            result.RateMngGoodsCd = rateSearchResultWork.RateMngGoodsCd;            // 掛率設定区分（商品）
            result.RateMngGoodsNm = rateSearchResultWork.RateMngGoodsNm;            // 掛率設定名称（商品）
            result.RateMngCustCd = rateSearchResultWork.RateMngCustCd;              // 掛率設定区分（得意先）
            result.RateMngCustNm = rateSearchResultWork.RateMngCustNm;              // 掛率設定名称（得意先）
            result.GoodsMakerCd = rateSearchResultWork.GoodsMakerCd;                // 商品メーカーコード
            result.GoodsNo = rateSearchResultWork.GoodsNo;                          // 商品番号
            result.GoodsRateRank = rateSearchResultWork.GoodsRateRank;              // 商品掛率ランク
            result.GoodsRateGrpCode = rateSearchResultWork.GoodsRateGrpCode;        // 商品掛率グループコード
            result.BLGroupCode = rateSearchResultWork.BLGroupCode;                  // BLグループコード
            result.BLGoodsCode = rateSearchResultWork.BLGoodsCode;                  // BL商品コード
            result.CustomerCode = rateSearchResultWork.CustomerCode;                // 得意先コード
            result.CustRateGrpCode = rateSearchResultWork.CustRateGrpCode;          // 得意先掛率グループコード
            result.SupplierCd = rateSearchResultWork.SupplierCd;                    // 仕入先コード
            result.LotCount = rateSearchResultWork.LotCount;                        // ロット数
            result.PriceFl = rateSearchResultWork.PriceFl;                          // 価格（浮動）
            result.RateVal = rateSearchResultWork.RateVal;                          // 掛率
            result.UpRate = rateSearchResultWork.UpRate;                            // UP率
            result.GrsProfitSecureRate = rateSearchResultWork.GrsProfitSecureRate;  // 粗利確保率
            result.UnPrcFracProcUnit = rateSearchResultWork.UnPrcFracProcUnit;      // 単価端数処理単位
            result.UnPrcFracProcDiv = rateSearchResultWork.UnPrcFracProcDiv;        // 単価端数処理区分
            // 優良設定マスタ、商品管理情報マスタより取得
            result.PrmGoodsMGroup = rateSearchResultWork.PrmGoodsMGroup;            // 商品中分類コード
            result.PrmTbsPartsCode = rateSearchResultWork.PrmTbsPartsCode;          // BLコード
            result.BLGoodsHalfName = rateSearchResultWork.BLGoodsHalfName;          // BL商品コード名称（半角）
            result.PrmPartsMakerCd = rateSearchResultWork.PrmPartsMakerCd;          // 部品メーカーコード
            result.MakerName = rateSearchResultWork.MakerName;                      // メーカー名称
            result.GoodsSupplierCd = rateSearchResultWork.GoodsSupplierCd;          // 仕入先コード

            result.ListPrice = rateSearchResultWork.ListPrice;          // 標準価格
            result.SalesUnitCost = rateSearchResultWork.SalesUnitCost;          // 原単価
            result.RatebLGroupCode = rateSearchResultWork.RatebLGroupCode;          // BLグループコード(掛率マスタ)
            result.RatebLGoodsCode = rateSearchResultWork.RatebLGoodsCode;          // BL商品コード(掛率マスタ)
            result.GoodsLogicalDeleteCode = rateSearchResultWork.GoodsLogicalDeleteCode;          // 論理削除区分(商品マスタ)

            return result;
        }

        /// <summary>
        /// クラスメンバーコピー処理（掛率設定クラス⇒掛率設定ワーククラス）
        /// </summary>
        /// <param name="rate">掛率設定クラス</param>
        /// <returns>SingleGoodsRateWork</returns>
        /// <remarks>
        /// <br>Note       : 掛率設定クラスから掛率設定ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        /// </remarks>
        private RateWork CopyToRateWorkFromRate(Rate rate)
        {
            RateWork rateWork = new RateWork();

            rateWork.CreateDateTime = rate.CreateDateTime;              // 作成日時
            rateWork.UpdateDateTime = rate.UpdateDateTime;              // 更新日時
            rateWork.EnterpriseCode = rate.EnterpriseCode;              // 企業コード
            rateWork.FileHeaderGuid = rate.FileHeaderGuid;              // GUID
            rateWork.UpdEmployeeCode = rate.UpdEmployeeCode;            // 更新従業員コード
            rateWork.UpdAssemblyId1 = rate.UpdAssemblyId1;              // 更新アセンブリID1
            rateWork.UpdAssemblyId2 = rate.UpdAssemblyId2;              // 更新アセンブリID2
            rateWork.LogicalDeleteCode = rate.LogicalDeleteCode;        // 論理削除区分
            rateWork.SectionCode = rate.SectionCode;                    // 拠点コード
            rateWork.UnitRateSetDivCd = rate.UnitRateSetDivCd;          // 単価掛率設定区分
            rateWork.UnitPriceKind = rate.UnitPriceKind;                // 単価種類
            rateWork.RateSettingDivide = rate.RateSettingDivide;        // 掛率設定区分
            rateWork.RateMngGoodsCd = rate.RateMngGoodsCd;              // 掛率設定区分（商品）
            rateWork.RateMngGoodsNm = rate.RateMngGoodsNm;              // 掛率設定名称（商品）
            rateWork.RateMngCustCd = rate.RateMngCustCd;                // 掛率設定区分（得意先）
            rateWork.RateMngCustNm = rate.RateMngCustNm;                // 掛率設定名称（得意先）
            rateWork.GoodsMakerCd = rate.GoodsMakerCd;                  // 商品メーカーコード
            rateWork.GoodsNo = rate.GoodsNo;                            // 商品番号
            rateWork.GoodsRateRank = rate.GoodsRateRank;                // 商品掛率ランク
            rateWork.BLGoodsCode = rate.BLGoodsCode;                    // BL商品コード
            rateWork.CustomerCode = rate.CustomerCode;                  // 得意先コード
            rateWork.CustRateGrpCode = rate.CustRateGrpCode;            // 得意先掛率グループコード
            rateWork.SupplierCd = rate.SupplierCd;                      // 仕入先コード
            rateWork.LotCount = rate.LotCount;                          // ロット数 
            rateWork.PriceFl = rate.PriceFl;                            // 価格
            rateWork.RateVal = rate.RateVal;                            // 掛率
            rateWork.UnPrcFracProcUnit = rate.UnPrcFracProcUnit;        // 単価端数処理単位
            rateWork.UnPrcFracProcDiv = rate.UnPrcFracProcDiv;          // 単価端数処理区分
            rateWork.GoodsRateGrpCode = rate.GoodsRateGrpCode;          // 商品掛率グループコード
            rateWork.BLGroupCode = rate.BLGroupCode;                    // BLグループコード
            rateWork.UpRate = rate.UpRate;                              // UP率
            rateWork.GrsProfitSecureRate = rate.GrsProfitSecureRate;    // 粗利確保率

            return rateWork;
        }

        // ADD 2010/09/26 --- >>>
        /// <summary>
        /// 単価算出クラス初期データ読込処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 単価算出クラス初期データ読込処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        private void ReadInitData()
        {
            List<StockProcMoney> stockProcMoneyList = new List<StockProcMoney>();
            ArrayList retStockProcMoneyList;

            int status = this._stockProcMoneyAcs.Search(out retStockProcMoneyList, LoginInfoAcquisition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (StockProcMoney stockProcMoney in retStockProcMoneyList)
                {
                    stockProcMoneyList.Add(stockProcMoney.Clone());
                }
            }

            this._unitPriceCalculation.CacheStockProcMoneyList(stockProcMoneyList);
        }

        /// <summary>
        /// 税率設定マスタ取得処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 税率設定マスタ取得処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        private void ReadTaxRate()
        {
            int status;

            try
            {
                // 税率設定マスタ取得(税率コード=0固定)
                status = this._taxRateSetAcs.Read(out this._taxRateSet, LoginInfoAcquisition.EnterpriseCode, 0);
            }
            catch
            {
                this._taxRateSet = new TaxRateSet();
            }
        }

        /// <summary>
        /// 初期データ取得用のスレッド
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 税率設定マスタ取得処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        private void ReadInitialThread()
        {
            this.ReadInitData(this._enterpriseCode, this._loginSectionCode);
        }

        /// <summary>
        /// 初期データ取得用のスレッド
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 税率設定マスタ取得処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        private void ReadInitialThreadSecond()
        {
            this.ReadInitDataSecond(this._enterpriseCode, this._loginSectionCode);
        }

        /// <summary>
        /// 初期データ取得用のスレッド
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 税率設定マスタ取得処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        private void ReadInitialThreadThird()
        {
            this.ReadInitDataThird(this._enterpriseCode, this._loginSectionCode);
        }

        /// <summary>
        /// 初期データ取得用のスレッド
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 税率設定マスタ取得処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        public int ReadInitData(string enterpriseCode, string sectionCode)
        {
            this._goodsAcs = new GoodsAcs();
            string msg = string.Empty;

            // メニューモード時はサーバー読み込み固定
            this._goodsAcs.IsLocalDBRead = false;

            // 初期値データ取得
            int status = this._goodsAcs.SearchInitial(enterpriseCode, sectionCode, out msg);

            status = this._goodsAcs.SearchInitialForMst(enterpriseCode, sectionCode, out msg);

            return status;
        }

        /// <summary>
        /// 初期データ取得用のスレッド
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 税率設定マスタ取得処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        public int ReadInitDataSecond(string enterpriseCode, string sectionCode)
        {
            this._goodsAcs2 = new GoodsAcs();
            string msg = string.Empty;

            // メニューモード時はサーバー読み込み固定
            this._goodsAcs2.IsLocalDBRead = false;

            // 初期値データ取得
            int status = this._goodsAcs2.SearchInitial(enterpriseCode, sectionCode, out msg);

            status = this._goodsAcs2.SearchInitialForMst(enterpriseCode, sectionCode, out msg);

            return status;
        }

        /// <summary>
        /// 初期データ取得用のスレッド
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 税率設定マスタ取得処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        public int ReadInitDataThird(string enterpriseCode, string sectionCode)
        {
            this._goodsAcs3 = new GoodsAcs();
            string msg = string.Empty;

            // メニューモード時はサーバー読み込み固定
            this._goodsAcs3.IsLocalDBRead = false;

            // 初期値データ取得
            int status = this._goodsAcs3.SearchInitial(enterpriseCode, sectionCode, out msg);

            status = this._goodsAcs3.SearchInitialForMst(enterpriseCode, sectionCode, out msg);

            return status;
        }

        /// <summary>
        /// 商品情報データ取得用のスレッド
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 税率設定マスタ取得処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        private void ReadInitialForth()
        {
            this.ReadInitDataForth();
        }

        /// <summary>
        /// 商品情報データ取得用のスレッド
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 税率設定マスタ取得処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        private void ReadInitialThreadFivth()
        {
            this.ReadInitDataFivth();
        }

        /// <summary>
        /// 商品情報データ取得用のスレッド
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 税率設定マスタ取得処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        private void ReadInitialThreadSixth()
        {
            this.ReadInitDataSixth();
        }

        /// <summary>
        /// 商品情報データ取得用のスレッド
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 税率設定マスタ取得処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        public int ReadInitDataForth()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {
                foreach (SingleGoodsRateSearchResultWork retWork in this.thread1Arr)
                {
                    if (this._extractCancelFlag == true)
                    {
                        break;
                    }
                    // クラスメンバコピー処理(D→E)
                    //商品管理情報マスタと価格マスタ情報の取得

                    List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                    GoodsUnitData goodsUnitData = new GoodsUnitData();
                    string msg = string.Empty;
                    GoodsCndtn cndtn = new GoodsCndtn();
                    cndtn.EnterpriseCode = this._enterpriseCode;
                    if ("00".Equals(this.rateSearchParam.SectionCode[0]))
                        cndtn.SectionCode = this._goodsAcs.LoginSectionCode;
                    else
                        cndtn.SectionCode = this.rateSearchParam.SectionCode[0];
                    cndtn.GoodsMakerCd = retWork.GoodsMakerCd;
                    cndtn.BLGoodsCode = retWork.BLGoodsCode;
                    cndtn.GoodsNo = retWork.GoodsNo;
                    cndtn.GoodsKindCode = 9;
                    cndtn.IsSettingSupplier = 1;
                    status = this._goodsAcs.Search(cndtn, out goodsUnitDataList, out msg);

                    if (goodsUnitDataList.Count > 0)
                    {
                        goodsUnitData = goodsUnitDataList[0];

                        this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);

                        switch (goodsUnitData.OfferKubun)
                        {
                            case 0: // ユーザー登録
                            case 1: // 提供純正編集
                            case 2: // 提供優良編集
                                if (goodsUnitData.LogicalDeleteCode == 0)
                                {
                                    // 仕入先
                                    retWork.GoodsSupplierCd = goodsUnitData.SupplierCd;

                                    if (goodsUnitData != null && goodsUnitData.GoodsPriceList != null)
                                    {
                                        if (goodsUnitData.GoodsPriceList.Count > 0)
                                        {

                                            GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Now, goodsUnitData.GoodsPriceList);//ddd
                                            if (goodsPrice != null)
                                            {
                                                retWork.ListPrice = goodsPrice.ListPrice;
                                            }

                                            retWork.SalesUnitCost = GetStockUnitPrice(goodsUnitData);
                                        }
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    thread1ArrResult.Add(CopyToRateSearchResultFromRateSearchResultWork(retWork));
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 商品情報データ取得用のスレッド
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 税率設定マスタ取得処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        public int ReadInitDataFivth()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            try
            {
                foreach (SingleGoodsRateSearchResultWork retWork in this.thread2Arr)
                {
                    if (this._extractCancelFlag == true)
                    {
                        break;
                    }
                    // クラスメンバコピー処理(D→E)
                    //商品管理情報マスタと価格マスタ情報の取得

                    List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                    GoodsUnitData goodsUnitData = new GoodsUnitData();
                    string msg = string.Empty;
                    GoodsCndtn cndtn = new GoodsCndtn();
                    cndtn.EnterpriseCode = this._enterpriseCode;
                    if ("00".Equals(this.rateSearchParam.SectionCode[0]))
                        cndtn.SectionCode = this._goodsAcs.LoginSectionCode;
                    else
                        cndtn.SectionCode = this.rateSearchParam.SectionCode[0];
                    cndtn.GoodsMakerCd = retWork.GoodsMakerCd;
                    cndtn.BLGoodsCode = retWork.BLGoodsCode;
                    cndtn.GoodsNo = retWork.GoodsNo;
                    cndtn.GoodsKindCode = 9;
                    cndtn.IsSettingSupplier = 1;
                    status = this._goodsAcs.Search(cndtn, out goodsUnitDataList, out msg);

                    if (goodsUnitDataList.Count > 0)
                    {
                        goodsUnitData = goodsUnitDataList[0];

                        this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);

                        switch (goodsUnitData.OfferKubun)
                        {
                            case 0: // ユーザー登録
                            case 1: // 提供純正編集
                            case 2: // 提供優良編集
                                if (goodsUnitData.LogicalDeleteCode == 0)
                                {
                                    // 仕入先
                                    retWork.GoodsSupplierCd = goodsUnitData.SupplierCd;

                                    if (goodsUnitData != null && goodsUnitData.GoodsPriceList != null)
                                    {
                                        if (goodsUnitData.GoodsPriceList.Count > 0)
                                        {

                                            GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Now, goodsUnitData.GoodsPriceList);//ddd
                                            if (goodsPrice != null)
                                            {
                                                retWork.ListPrice = goodsPrice.ListPrice;
                                            }

                                            retWork.SalesUnitCost = GetStockUnitPrice(goodsUnitData);
                                        }
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    thread2ArrResult.Add(CopyToRateSearchResultFromRateSearchResultWork(retWork));
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 商品情報データ取得用のスレッド
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 税率設定マスタ取得処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        public int ReadInitDataSixth()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            try
            {
                foreach (SingleGoodsRateSearchResultWork retWork in this.thread3Arr)
                {
                    if (this._extractCancelFlag == true)
                    {
                        break;
                    }
                    // クラスメンバコピー処理(D→E)
                    //商品管理情報マスタと価格マスタ情報の取得

                    List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                    GoodsUnitData goodsUnitData = new GoodsUnitData();
                    string msg = string.Empty;
                    GoodsCndtn cndtn = new GoodsCndtn();
                    cndtn.EnterpriseCode = this._enterpriseCode;
                    if ("00".Equals(this.rateSearchParam.SectionCode[0]))
                        cndtn.SectionCode = this._goodsAcs.LoginSectionCode;
                    else
                        cndtn.SectionCode = this.rateSearchParam.SectionCode[0];
                    cndtn.GoodsMakerCd = retWork.GoodsMakerCd;
                    cndtn.BLGoodsCode = retWork.BLGoodsCode;
                    cndtn.GoodsNo = retWork.GoodsNo;
                    cndtn.GoodsKindCode = 9;
                    cndtn.IsSettingSupplier = 1;
                    status = this._goodsAcs.Search(cndtn, out goodsUnitDataList, out msg);

                    if (goodsUnitDataList.Count > 0)
                    {
                        goodsUnitData = goodsUnitDataList[0];

                        this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);

                        switch (goodsUnitData.OfferKubun)
                        {
                            case 0: // ユーザー登録
                            case 1: // 提供純正編集
                            case 2: // 提供優良編集
                                if (goodsUnitData.LogicalDeleteCode == 0)
                                {
                                    // 仕入先
                                    retWork.GoodsSupplierCd = goodsUnitData.SupplierCd;

                                    if (goodsUnitData != null && goodsUnitData.GoodsPriceList != null)
                                    {
                                        if (goodsUnitData.GoodsPriceList.Count > 0)
                                        {

                                            GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Now, goodsUnitData.GoodsPriceList);//ddd
                                            if (goodsPrice != null)
                                            {
                                                retWork.ListPrice = goodsPrice.ListPrice;
                                            }

                                            retWork.SalesUnitCost = GetStockUnitPrice(goodsUnitData);
                                        }
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    thread3ArrResult.Add(CopyToRateSearchResultFromRateSearchResultWork(retWork));
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        // ADD 2010/09/26 --- <<<
        #endregion ■ Private Methods
    }
}
