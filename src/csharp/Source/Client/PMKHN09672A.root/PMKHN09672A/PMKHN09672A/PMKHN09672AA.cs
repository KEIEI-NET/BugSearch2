//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   商品マスタ更新処理アクセスクラス
//                  :   PMKHN09672A.DLL
// Name Space       :   Broadleaf.Application.Controller
// Programmer       :   許雁波
// Date             :   2011/07/22
// Update Note      :   連番1029  新規
//----------------------------------------------------------------------
// Update Note      :   機能追加：ログ出力
// Programmer       :   周雨
// Date             :   2011/08/22
// Update Note      :   連番1029  新規
//----------------------------------------------------------------------
// Update Note      :   障害報告 #25232　⑤ 名称更新を修正
// Programmer       :   王飛3　
// Date             :   2011/09/16
//----------------------------------------------------------------------
// Update Note      :   価格更新区分追加の対応
// Programmer       :   yangmj
// Date             :   2012/06/12
//----------------------------------------------------------------------
// Update Note      :   商品マスタ更新処理でセレクトコードを無視して更新される不具合の対応
//                  :   商品マスタ更新処理以外のPGでも問題が発生しているが、取り急ぎ、商品マスタ更新処理のみから
//                  :   呼ばれるメソッドを新規作成して対応。別途恒久対応を行う。
// Programmer       :   22008 長内 数馬
// Date             :   2015/04/08
//----------------------------------------------------------------------
// Update Note      :   2015/04/08修正分の暫定対応メソッドの呼出部分を削除
//                  :   暫定対応前のメソッドに戻す
// Programmer       :   22008 長内 数馬
// Date             :   2015/04/10
//----------------------------------------------------------------------
// Update Note      :   商品マスタ更新(サポート)対応
// Programmer       :   譚洪
// Date             :   2021/08/06
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;// ADD yangmj 2012/06/12 価格更新区分追加

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 商品マスタ更新処理アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品マスタ更新を行うアクセスクラスです。</br>
    /// <br>Programmer : 許雁波</br>
    /// <br>Date       : 2011.07.22</br>
    /// <br>Update Note: 連番1029 機能追加：ログ出力</br>
    /// <br>Programmer : 周雨</br>
    /// <br>Date       : 2011/08/22</br>
    /// <br>Update Note: 価格更新区分追加の対応</br>
    /// <br>Programmer : yangmj</br>
    /// <br>Date       : 2012/06/12</br>
    /// <br>Update Note: 商品マスタ更新(サポート)対応</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2021/08/06</br>
    /// </remarks>
    public class GoodsUAcs
    {
        #region ■ Private Member
        /// <summary>商品マスタ（ユーザー登録分）DB RemoteObjectインターフェース</summary>
        private IGoodsUpdateDB _iGoodsUDB = null;

        /// <summary>商品マスタ（提供DB分）DB RemoteObjectインターフェース</summary>
        private IOfferPartsInfo _iOfferPartsInfo;
        // --------------- ADD 2011/08/22 機能追加：ログ出力 -------------- >>>>>
        /// <summary>ログの書込み者</summary>
        private OperationHistoryLog _operationHistoryLog;
        // --------------- ADD 2011/08/22 機能追加：ログ出力 -------------- <<<<<

        // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
        private ArrayList writePricesList = null; // 価格リスト(書込用)
        private ArrayList deletePriceList = null; // 価格リスト(削除用)
        private List<PrmSettingUWork> prmSettingUWorkList = null; // 価格リスト(削除用)
        // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- <<<<<
        // --- ADD 2021/08/06 譚洪 商品マスタ更新(サポート)対応 ----->>>>>
        private const string PGID_PMKHN09679U = "PMKHN09679U";
        private const string PGID_PMKHN09670U = "PMKHN09670U";
        private const string PROGRAM_SUPPORT = "商品マスタ更新(サポート)";
        // --- ADD 2021/08/06 譚洪 商品マスタ更新(サポート)対応 -----<<<<<
        #endregion ■ Private Member

        // --------------- ADD 2011/08/22 機能追加：ログ出力 -------------- >>>>>
        #region  ■ Constructor
        public GoodsUAcs()
        {
            if (_operationHistoryLog == null)
                _operationHistoryLog = new OperationHistoryLog();
        }
        #endregion
        // --------------- ADD 2011/08/22 機能追加：ログ出力 -------------- <<<<<

        #region ■ Public Method

        /// <summary>
        /// 商品マスタ（ユーザー登録分）更新を行う
        /// </summary>
        /// <param name="retCnt">該当データ件数</param>
        /// <param name="goodsUpdate">更新パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの商品マスタ（ユーザー登録分）更新を行う</br>
        /// <br>Programmer : 許雁波</br>
        /// <br>Date       : 2011/07/22</br>
        /// <br>Update Note: 価格更新区分追加の対応</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 商品マスタ更新(サポート)対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2021/08/06</br>
        public int Update(out int cnt, GoodsUpdate goodsUpdate)
        {
            cnt = 0;
            //検索用商品データリスト
            //object goodsUWorkList;// DEL yangmj 2012/06/12 価格更新区分追加
            object goodsUWorkList = new object();// ADD yangmj 2012/06/12 価格更新区分追加
            object objGoods;// ADD yangmj 2012/06/12 価格更新区分追加
            //更新用商品データリスト
            List<GoodsUResultWork> goodsUList;

            //検索条件
            GoodsUpdateWork goodsUpdateWork = copyToGoodsUpdateWorkFromGoodsUpdate(goodsUpdate);
            
            this._iGoodsUDB = MediationIGoodsUpdateDB.GetIGoodsUpdateDB();

            //ユーザDBから商品マスタデータを取得する
            //int status = this._iGoodsUDB.SearchAll(out goodsUWorkList, goodsUpdateWork, ConstantManagement.LogicalMode.GetData0); // DEL yangmj 2012/06/12 価格更新区分追加
            int status = this._iGoodsUDB.SearchAll(out objGoods, goodsUpdateWork, ConstantManagement.LogicalMode.GetData0); // ADD yangmj 2012/06/12 価格更新区分追加

            //提供DBから商品マスタデータを取得する
            //if ((status != 0) || (goodsUWorkList == null)) // DEL yangmj 2012/06/12 価格更新区分追加
            if ((status != 0) || (objGoods == null)) // ADD yangmj 2012/06/12 価格更新区分追加
            {
                return 4;
            }
            // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
            else
            {
                if (objGoods is CustomSerializeArrayList)
                {
                    CustomSerializeArrayList customList = (CustomSerializeArrayList)objGoods;

                    if (customList[0] is List<GoodsUResultWork> && customList[0] != null)
                    {
                        goodsUWorkList = (List<GoodsUResultWork>)customList[0];
                    }
                    else
            {
                return 4;
            }
                    if (customList.Count > 1)
                    {
                        prmSettingUWorkList = new List<PrmSettingUWork>((PrmSettingUWork[])((ArrayList)customList[1]).ToArray(typeof(PrmSettingUWork)));

                    }
                }
            }
            // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- <<<<<
            //SearchFromOfferDB(ref goodsUWorkList, out goodsUList); // DEL yangmj 2012/06/12 価格更新区分追加
            SearchFromOfferDB(goodsUpdate.PriceUpdateDivCd, ref goodsUWorkList, out goodsUList); // ADD yangmj 2012/06/12 価格更新区分追加
            if ((goodsUList != null) && (goodsUList.Count > 20000))
            {
                // --- UPD 譚洪 2021/08/06 商品マスタ更新(サポート)対応 ----->>>>>
                //return 1;
                if (checkPgId())
                {
                    return 1;
                }
                // --- UPD 譚洪 2021/08/06 商品マスタ更新(サポート)対応 -----<<<<<
            }
            else if ((goodsUList != null) && (goodsUList.Count == 0))
            {
                return 4;
            }

            //提供データをユーザDBに更新する
            //status = this._iGoodsUDB.Update(out cnt, (object)goodsUList, goodsUpdateWork);// EDL yangmj 2012/06/12 価格更新区分追加
            // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
            object obj;
            ArrayList updList = new ArrayList();
            updList.Add(goodsUList);
            updList.Add(writePricesList);
            updList.Add(deletePriceList);
            obj = (object)updList;
            status = this._iGoodsUDB.Update(out cnt, (object)obj, goodsUpdateWork);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                cnt = cnt + writePricesList.Count + deletePriceList.Count;
            }
            // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- <<<<<
            return 0;

        }

        // --- ADD 譚洪 2021/08/06 商品マスタ更新(サポート)対応 ----->>>>>
        /// <summary>
        /// PGID判断用
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品マスタ更新(サポート)対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2021/08/06</br>
        /// </remarks>
        private bool checkPgId()
        {
            bool checkFlg = true;
            try
            {
                string prePGID = new System.Diagnostics.StackTrace().GetFrame(2).GetMethod().ReflectedType.Assembly.GetName().Name;
                switch (prePGID)
                {
                    case PGID_PMKHN09670U:
                        checkFlg = true;
                        break;
                    case PGID_PMKHN09679U:
                        checkFlg = false;
                        break;
                    default:
                        checkFlg = true;
                        break;
                }
            }
            catch
            {
                checkFlg = true;
            }
            return checkFlg;
        }
        // --- ADD 譚洪 2021/08/06 商品マスタ更新(サポート)対応 -----<<<<<

        // --------------- ADD 2011/08/22 機能追加：ログ出力 -------------- >>>>>
        /// <summary>
        /// ログを書き込みます
        /// </summary>
        /// <param name="processName">各処理の名称</param>
        /// <param name="stepName">処理区分</param>
        /// <param name="data">更新内容</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ログを書き込みます</br>
        /// <br>Programmer : 周雨</br>
        /// <br>Date       : 2011/08/22</br>
        /// <br>UpdateNote : 商品マスタ更新(サポート)対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2021/08/06</br>
        public void Write(
            string processName,
            string stepName,
            string data
        )
        {
            const string PROGRAM_ID = "PMKHN09672A";
            const string PROGRAM_NAME = "商品マスタ更新処理";
            const int OPERATION_CODE = 0;
            const int STATUS = 0;

            // --- ADD 譚洪 2021/08/06 商品マスタ更新(サポート)対応 ----->>>>>
            string pgmNm = string.Empty;
            if (checkPgId())
            {
                pgmNm = PROGRAM_NAME;
            }
            else
            {
                pgmNm = PROGRAM_SUPPORT;
            }
            // --- ADD 譚洪 2021/08/06 商品マスタ更新(サポート)対応 -----<<<<<
            this._operationHistoryLog.WriteOperationLog(
                this,
                DateTime.Now,
                LogDataKind.SystemLog,
                PROGRAM_ID,
                // --- UPD 譚洪 2021/08/06 商品マスタ更新(サポート)対応 ----->>>>>
                //PROGRAM_NAME,
                pgmNm,
                // --- UPD 譚洪 2021/08/06 商品マスタ更新(サポート)対応 -----<<<<<
                processName,
                OPERATION_CODE,
                STATUS,
                stepName,
                data
            );
        }
        // --------------- ADD 2011/08/22 機能追加：ログ出力 -------------- <<<<<
        #endregion ■ Public Method

        #region ■ Private Method
        /// <summary>
        /// 検索条件の準備
        /// </summary>
        /// <param name="goodsUpdate">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 検索条件の準備を行う</br>
        /// <br>Programmer : 許雁波</br>
        /// <br>Date       : 2011/07/22</br>
        /// <br>Update Note: 価格更新区分追加の対応</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/06/12</br>
        private GoodsUpdateWork copyToGoodsUpdateWorkFromGoodsUpdate(GoodsUpdate goodsUpdate)
        {
            GoodsUpdateWork goodsUpdateWork = new GoodsUpdateWork();

            goodsUpdateWork.EnterpriseCode = goodsUpdate.EnterpriseCode;
            goodsUpdateWork.GoodsMakerCd = goodsUpdate.GoodsMakerCd;
            goodsUpdateWork.GoodsMGroup = goodsUpdate.GoodsMGroup;
            goodsUpdateWork.BLGoodsCode = goodsUpdate.BLGoodsCode;
            goodsUpdateWork.BLCodeUpdateDivCd = goodsUpdate.BLCodeUpdateDivCd;
            goodsUpdateWork.RateRankUpdateDivCd = goodsUpdate.RateRankUpdateDivCd;
            goodsUpdateWork.GoodsNameUpdateDivCd = goodsUpdate.GoodsNameUpdateDivCd;
            goodsUpdateWork.PriceUpdateDivCd = goodsUpdate.PriceUpdateDivCd;//ADD yangmj 2012/06/12 価格更新区分追加
            return goodsUpdateWork;
        }

        /// <summary>
        /// 提供DBから商品マスタデータを取得する
        /// </summary>
        /// <param name="objList">検索条件</param>
        /// <param name="goodsUList">取得データリスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 提供DBから商品マスタデータを取得するう</br>
        /// <br>Programmer : 許雁波</br>
        /// <br>Date       : 2011/07/22</br>
        /// <br>Update Note: 価格更新区分追加の対応</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/06/12</br>
        //private void SearchFromOfferDB(ref object objList, out List<GoodsUResultWork> goodsUList) // DEL yangmj 2012/06/12 価格更新区分追加
        private void SearchFromOfferDB(int priceUpdateDivCd, ref object objList, out List<GoodsUResultWork> goodsUList) // ADD yangmj 2012/06/12 価格更新区分追加
        {
            List<GoodsUResultWork> goodsUWorkList = (List<GoodsUResultWork>)objList;
            goodsUList = new List<GoodsUResultWork>();
            GoodsUResultWork goodsU;
 
            ArrayList lstSrchCond = new ArrayList();
            OfrPrtsSrchCndWork ofrPrtsSrchCndWork;
            foreach (GoodsUResultWork goodsUWork in goodsUWorkList)
            {
                ofrPrtsSrchCndWork = new OfrPrtsSrchCndWork();
                ofrPrtsSrchCndWork.MakerCode = goodsUWork.GoodsMakerCd; // メーカーコード
                ofrPrtsSrchCndWork.PrtsNo = goodsUWork.GoodsNo;         // 品番
                lstSrchCond.Add(ofrPrtsSrchCndWork);
            }

            if (lstSrchCond.Count > 0)
            {
                ArrayList lstRst;
                ArrayList lstRstPrm;
                ArrayList lstPrmPrice;

                try
                {
                    this._iOfferPartsInfo = (IOfferPartsInfo)MediationOfferPartsInfo.GetOfferPartsInfo();
                    // -- UPD 2015/04/10 osanai ----------------------------------------------->>> 
                    //// -- UPD 2015/04/08 osanai ----------------------------------------------->>> 
                    //// 提供のリモート処理を使用して商品マスタ情報を取得する
                    ////int satus = this._iOfferPartsInfo.GetOfrPartsInf(lstSrchCond, out lstRst, out lstRstPrm, out lstPrmPrice);

                    //// 暫定対応として、商品マスタ更新処理用に追加したメソッドを呼び出す。
                    //// （既存メソッドを修正した場合に、影響範囲が広いため、別途恒久対応後に既存メソッドに戻す）
                    //int satus = this._iOfferPartsInfo.GetOfrPartsInfGoodsUpdateOnly(lstSrchCond, out lstRst, out lstRstPrm, out lstPrmPrice);
                    //// -- UPD 2015/04/08 osanai -----------------------------------------------<<< 

                    // 提供R側で恒久対応を行うため、暫定対応前のメソッドに戻す
                    int satus = this._iOfferPartsInfo.GetOfrPartsInf(lstSrchCond, out lstRst, out lstRstPrm, out lstPrmPrice);
                    // -- UPD 2015/04/10 osanai -----------------------------------------------<<< 

                    // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
                    PriceChgSet priceChkSet = new PriceChgSet();
                    int priceMngCnt = -1;
                    if (priceUpdateDivCd == 1)
                    {
                    // 価格管理件数の取得
                    PriceChgSetAcs priceChgSetAcs = new PriceChgSetAcs();
                    priceChgSetAcs.Read(out priceChkSet, goodsUWorkList[0].EnterpriseCode, PriceChgSetAcs.SearchMode.Remote);
                        priceMngCnt = priceChkSet.PriceMngCnt;
                    }
                    // ここで価格改正処理
                    List<GoodsPriceUWork> addList;//価格新規追加データリスト
                    List<GoodsPriceUWork> deleteList;//価格削除データリスト

                    writePricesList = new ArrayList();
                    deletePriceList = new ArrayList();
                    // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- <<<<<
                   
                    int goodsMakeCd;
                    string goodsNo;
                    foreach (GoodsUResultWork goodsUWork in goodsUWorkList)
                    {
                        goodsMakeCd = goodsUWork.GoodsMakerCd;
                        goodsNo = goodsUWork.GoodsNo;

                        foreach (OfferJoinPartsRetWork offerJoinPartsRetWork in lstRstPrm)
                        {
                            if (offerJoinPartsRetWork.JoinDestMakerCd == goodsMakeCd
                                && offerJoinPartsRetWork.JoinDestPartsNo == goodsNo)
                            {
                                goodsU = goodsUWork;
                                goodsUList.Add(goodsUWork);
                                //goodsU.GoodsName = offerJoinPartsRetWork.PrimePartsName;//DEL 2011/09/16
                                goodsU.GoodsName = offerJoinPartsRetWork.PrimePartsKanaName;//ADD 2011/09/16
                                goodsU.BLGoodsCode = offerJoinPartsRetWork.TbsPartsCode;
                                goodsU.GoodsRateRank = offerJoinPartsRetWork.PartsLayerCd;
                                goodsU.GoodsNameKana = offerJoinPartsRetWork.PrimePartsKanaName;//ADD 2011/09/16
                                break;
                            }
                        }
                        // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
                        //価格更新区分：する場合、価格マスタに更新する
                        if (priceUpdateDivCd == 1)
                        {
                            // ユーザー価格リスト
                            ArrayList priceList = goodsUWork.PriceList;
                            // 価格更新リストを作成する
                            CreatePrimePartsPriceUpdateDataList(goodsUWork.EnterpriseCode, goodsUWork.GoodsNo, goodsUWork.GoodsMakerCd, priceChkSet, priceList, lstPrmPrice, lstRstPrm, out addList, out deleteList);
                            if (addList.Count > 0) writePricesList.AddRange(addList.ToArray());
                            if (deleteList.Count > 0) deletePriceList.AddRange(deleteList.ToArray());
                        }
                        // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- <<<<<
                    }
                }
                catch
                {
                    
                }
            }
        }
        // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
        #region 価格マスタの更新処理

        /// <summary>
        /// 価格改正リストの生成
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="makerCd">メーカーコード</param>
        /// <param name="priceMergeSt">提供データ更新設定マスタ</param>
        /// <param name="prcUpdtTrgtList">純正価格マスタリスト</param>
        /// <param name="lstPrimePrice">優良部品価格リスト</param>
        /// <param name="addList">追加更新対象リスト</param>
        /// <param name="deleteList">削除対象リスト</param>
        private void CreatePrimePartsPriceUpdateDataList(string enterpriseCode, string goodsNo, int makerCd, PriceChgSet priceChkSet, ArrayList priceList, ArrayList lstPrimePrice, ArrayList lstRstPrm, out List<GoodsPriceUWork> addList, out List<GoodsPriceUWork> deleteList)
        {
            addList = new List<GoodsPriceUWork>();
            deleteList = new List<GoodsPriceUWork>();

            if (lstPrimePrice == null || lstPrimePrice.Count == 0) return;

            // 提供・ユーザーをマージしたリスト
            SortedDictionary<DateTime, object> prcList = new SortedDictionary<DateTime, object>();
            // ユーザーに同一価格開始日がある分の提供リスト
            Dictionary<DateTime, OfferJoinPriceRetWork> duplicateList = new Dictionary<DateTime, OfferJoinPriceRetWork>();

            // ユーザー価格マスタからリスト追加
            foreach (GoodsPriceUWork data in priceList)
            {
                if (data.PriceStartDate == DateTime.MinValue) continue;

                if (!prcList.ContainsKey(data.PriceStartDate))
                {
                    prcList.Add(data.PriceStartDate, data);
                }
            }

            bool ofrDtExists = false;
            // 提供優良価格マスタからリスト追加
            foreach (OfferJoinPriceRetWork prmPrtPriceWork in lstPrimePrice)
            {
                if (makerCd == prmPrtPriceWork.PartsMakerCd
                    && goodsNo == prmPrtPriceWork.PrimePartsNoWithH)
                {
                    // セレクトコードがある場合は該当商品かチェックする
                    if (prmPrtPriceWork.PrmSetDtlNo1 != 0)
                    {
                        if (prmSettingUWorkList == null) continue;
                        int GoodsMGroup = 0;
                        int TbsPartsCode = 0;

                        foreach (OfferJoinPartsRetWork offerJoinPartsRetWork in lstRstPrm)
                        { 
                            if (offerJoinPartsRetWork.JoinDestMakerCd == makerCd
                                && offerJoinPartsRetWork.JoinDestPartsNo == goodsNo)
                            {
                                GoodsMGroup = offerJoinPartsRetWork.GoodsMGroup;
                                TbsPartsCode = offerJoinPartsRetWork.TbsPartsCode;
                                break;
                            }
                        }

                        PrmSettingUWork prmSettingWork = prmSettingUWorkList.Find(
                            delegate(PrmSettingUWork target)
                            {
                                if (target.PartsMakerCd == prmPrtPriceWork.PartsMakerCd &&
                                    target.GoodsMGroup == GoodsMGroup &&
                                    target.TbsPartsCode == TbsPartsCode &&
                                    target.PrmSetDtlNo1 == prmPrtPriceWork.PrmSetDtlNo1
                                   ) return true;

                                return false;
                            });

                        if (prmSettingWork == null) continue;
                    }
                    // 既にユーザーに同一価格開始日がある場合は重複リストに移行
                    if (prcList.ContainsKey(prmPrtPriceWork.PriceStartDate))
                    {
                        // 提供データ中に、提供日付が重複のデータがある時、マージ処理を行う
                        if (ofrDtExists && !duplicateList.ContainsKey(prmPrtPriceWork.PriceStartDate)
                            && prcList[prmPrtPriceWork.PriceStartDate] is OfferJoinPriceRetWork)
                        {
                            OfferJoinPriceRetWork ofrData = (OfferJoinPriceRetWork)prcList[prmPrtPriceWork.PriceStartDate];
                            ofrData.OfferDate = prmPrtPriceWork.OfferDate;// 提供日付
                            ofrData.OpenPriceDiv = prmPrtPriceWork.OpenPriceDiv;// オープン価格区分;
                            // 新しい定価がゼロの場合
                            if (prmPrtPriceWork.NewPrice == 0)
                            {
                                // 提供データ更新設定マスタのオープン価格区分を参照してセット
                                if (priceChkSet.OpenPriceDiv == 0)
                                {
                                    // 元のユーザー価格を引継ぐ
                                }
                                else
                                {
                                    ofrData.NewPrice = 0;         // 定価０
                                }
                            }
                            else
                            {
                                ofrData.NewPrice = prmPrtPriceWork.NewPrice;
                            }
                            prcList.Remove(prmPrtPriceWork.PriceStartDate);
                            prcList.Add(ofrData.PriceStartDate, ofrData);
                        }
                        else if (duplicateList.ContainsKey(prmPrtPriceWork.PriceStartDate))
                        {
                            duplicateList[prmPrtPriceWork.PriceStartDate].OfferDate = prmPrtPriceWork.OfferDate;// 提供日付
                            duplicateList[prmPrtPriceWork.PriceStartDate].OpenPriceDiv = prmPrtPriceWork.OpenPriceDiv;// オープン価格区分

                            // 新しい定価がゼロの場合
                            if (prmPrtPriceWork.NewPrice == 0)
                            {
                                // 提供データ更新設定マスタのオープン価格区分を参照してセット
                                if (priceChkSet.OpenPriceDiv == 0)
                                {
                                    // 元のユーザー価格を引継ぐ
                                }
                                else
                                {
                                    duplicateList[prmPrtPriceWork.PriceStartDate].NewPrice = 0;         // 定価０
                                }
                            }
                            else
                            {
                                duplicateList[prmPrtPriceWork.PriceStartDate].NewPrice = prmPrtPriceWork.NewPrice;
                            }
                        }
                        else
                        {
                        duplicateList.Add(prmPrtPriceWork.PriceStartDate, prmPrtPriceWork);
                    }
                    }
                    else
                    {
                        prcList.Add(prmPrtPriceWork.PriceStartDate, prmPrtPriceWork);
                    }
                    ofrDtExists = true;
                }
            }
            if (!ofrDtExists) return;

            // 古い方から見ていく
            List<GoodsPriceUWork> allList = new List<GoodsPriceUWork>();    　// ユーザーデータの最新情報（価格順で）
            GoodsPriceUWork usrGoods = new GoodsPriceUWork(); // ユーザー商品

            foreach (DateTime prcStDate in prcList.Keys)
            {
                // ユーザー商品
                if (prcList[prcStDate] is GoodsPriceUWork)
                {
                    usrGoods = (GoodsPriceUWork)prcList[prcStDate];
                    GoodsPriceUWork writeWork = usrGoods;

                    // 提供データがあった場合
                    if (duplicateList.ContainsKey(prcStDate))
                    {
                        OfferJoinPriceRetWork ofrData = duplicateList[prcStDate];

                        writeWork.UpdateDate = DateTime.Now;                                              // 更新日付
                        writeWork.OfferDate = ofrData.OfferDate; // 提供日付
                        writeWork.OpenPriceDiv = ofrData.OpenPriceDiv;                                    // オープン価格区分

                        // 新しい定価がゼロの場合
                        if (ofrData.NewPrice == 0)
                        {
                            // 提供データ更新設定マスタのオープン価格区分を参照してセット
                            if (priceChkSet.OpenPriceDiv == 0)
                            {
                                // 元のユーザー価格を引継ぐ
                            }
                            else
                            {
                                writeWork.ListPrice = 0;         // 定価０
                            }
                        }
                        else
                        {
                            writeWork.ListPrice = ofrData.NewPrice;
                        }

                        // 提供データがあった場合のみ価格改正リストへの追加
                        addList.Add(writeWork);
                    }
                    allList.Add(writeWork);
                }
                else if (prcList[prcStDate] is OfferJoinPriceRetWork)
                {
                    OfferJoinPriceRetWork ofrData = (OfferJoinPriceRetWork)prcList[prcStDate];

                    GoodsPriceUWork writeWork = new GoodsPriceUWork();
                    writeWork.EnterpriseCode = enterpriseCode;              // 企業コード
                    writeWork.PriceStartDate = ofrData.PriceStartDate;       // 価格開始日
                    writeWork.GoodsMakerCd = makerCd;                       // メーカー
                    writeWork.GoodsNo = goodsNo;                            // 品番
                    writeWork.UpdateDate = DateTime.Now;                    // 更新年月日

                    // ユーザー価格マスタの内容を引継ぐ(提供が一番古い場合は入らない)
                    writeWork.SalesUnitCost = usrGoods.SalesUnitCost;  // 原価単価
                    writeWork.StockRate = usrGoods.StockRate;          // 仕入率

                    writeWork.OfferDate = ofrData.OfferDate; // 提供日付
                    writeWork.OpenPriceDiv = ofrData.OpenPriceDiv;          // オープン価格区分
                    writeWork.ListPrice = ofrData.NewPrice;                // 定価

                    // 提供の標準価格がゼロの場合
                    if (ofrData.NewPrice == 0)
                    {
                        // 提供データ更新設定マスタのオープン価格区分を参照してセット
                        if (priceChkSet.OpenPriceDiv == 0)
                        {
                            if (allList.Count > 0)
                            {
                                writeWork.ListPrice = allList[allList.Count - 1].ListPrice;   // 1つ前の定価をセット
                            }
                    }
                }
                    // 価格改正リストに追加
                    allList.Add(writeWork);

                    // 全件リストに追加
                    addList.Add(writeWork);
                }
            }

            // 管理件数を超えている場合、古いデータから消す
            if (allList.Count > priceChkSet.PriceMngCnt)
            {
                // 削除する件数
                int delCnt = allList.Count - priceChkSet.PriceMngCnt;

                for (int cnt = 0; cnt < delCnt; cnt++)
                {
                    GoodsPriceUWork data = allList[0];
                    
                    // 作成日時が入っている場合は、ユーザー登録されていた分なので、削除リストに追加
                    if (data.CreateDateTime != DateTime.MinValue)
                    {
                        deleteList.Add(data);
                    }

                    // 追加・更新データに含まれる場合はリストから削除
                    if (addList.Contains(data)) addList.Remove(data);

                    // 先頭データを消す
                    allList.RemoveAt(0);
                }
            }
        }
        #endregion
        // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- <<<<<
        #endregion ■ Private Method

    }
}
