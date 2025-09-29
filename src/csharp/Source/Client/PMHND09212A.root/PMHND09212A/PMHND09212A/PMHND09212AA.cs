//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品バーコード関連付け　アクセスクラス
// プログラム概要   : 商品バーコード関連付けデータに対して各操作処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 3H 張小磊
// 作 成 日  2017/06/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11770175-00 作成担当 : 呉元嘯
// 修 正 日  2021/11/03  修正内容 : PJMIT-1499 OUT OF MEMORY対応(4GB対応)
//----------------------------------------------------------------------------//
// 管理番号  11770181-00 作成担当 : 呉元嘯
// 修 正 日  2021/11/18  修正内容 : PJMIT-1499 OUT OF MEMORY対応(4GB対応) 恒久対応
//----------------------------------------------------------------------------//
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 商品バーコード関連付けテーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品バーコード関連付けテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 3H 張小磊</br>
    /// <br>Date       : 2017/06/12</br>
    /// <br>Update Note: 2021/11/03 呉元嘯</br>
    /// <br>管理番号   : 11770175-00</br>
    /// <br>             PJMIT-1499　OUT OF MEMORY対応(4GB対応)</br>
    /// <br>Update Note: 2021/11/18 呉元嘯</br>
    /// <br>管理番号   : 11770181-00</br>
    /// <br>             PJMIT-1499　OUT OF MEMORY対応(4GB対応) 恒久対応</br>
    /// </remarks>
    public class GoodsBarCodeRevnAcs
    {
        /// <summary>リモートオブジェクト</summary>
        private IGoodsBarCodeRevnDB _iGoodsBarCodeRevnDB = null;
        // --- ADD 2021/11/03 呉元嘯 PJMIT-1499対応 ------>>>>> 
        // メモリアウト判断用文字列
        private string CT_MemoryOutStr = "OutOfMemoryException";
        // メモリアウトフラグ
        private bool _memoryOutFlag = false;
        /// <summary>
        /// メモリアウトフラグロパティ
        /// </summary>
        public bool MemoryOutFlag
        {
            get { return this._memoryOutFlag; }
            set { this._memoryOutFlag = value; }
        }
        // --- ADD 2021/11/03 呉元嘯 PJMIT-1499対応 ------<<<<<

        // 商品マスタアクセス
        private GoodsAcs _goodsAcs;    

        /// <summary>
        /// 商品バーコード関連付けテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public GoodsBarCodeRevnAcs()
        {
            // 商品マスタアクセス
            this._goodsAcs = new GoodsAcs();
            string msg;
            // 商品マスタアクセス検索初期化
            this._goodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode.TrimEnd(), LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd(), out msg);
            
            try
            {
                // リモートオブジェクト取得
                this._iGoodsBarCodeRevnDB = MediationGoodsBarCodeRevnDB.GetGoodsBarCodeRevnDB();
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iGoodsBarCodeRevnDB = null;
            }
        }

        #region ■ 検索処理
        /// <summary>
        /// 商品バーコード関連付け検索処理(メイン)
        /// </summary>
        /// <param name="retList">検索結果List</param>
        /// <param name="goodsBarCodeRevnSearchPara">検索条件</param>
        /// <returns>検索処理(メイン)結果</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けの検索処理を行います。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public int Search(out List<GoodsBarCodeRevn> retList, GoodsBarCodeRevnSearchPara goodsBarCodeRevnSearchPara)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retList = new List<GoodsBarCodeRevn>();
            try
            {
                // 商品連結データ
                List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                // 商品バーコードデータ
                List<GoodsBarCodeRevnWork> goodsBarCodeRevnWorkList = new List<GoodsBarCodeRevnWork>();
                // 商品連結データ検索処理
                status = SearchGoodsUnitData(out goodsUnitDataList, goodsBarCodeRevnSearchPara);
                // 検索処理エラー時
                if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR) return status;
                // 商品バーコードデータ検索処理
                status = SearchGoodsBarCodeRevnWorkData(out goodsBarCodeRevnWorkList, goodsBarCodeRevnSearchPara);
                // 検索処理エラー時
                if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR) return status;
                // 商品バーコードデータと商品連結データを結び付ける
                retList = UnitGoodsDataAndGoodsBarData(goodsUnitDataList, goodsBarCodeRevnWorkList, goodsBarCodeRevnSearchPara.HaveBarCodeDiv);

                if (retList != null && retList.Count > 0)
                {
                    // 検索結果あり時
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    // 検索結果なし時
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch
            {
                // 検索処理エラー時
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 商品連結データ検索処理
        /// </summary>
        /// <param name="goodsUnitDataList">検索結果List</param>
        /// <param name="goodsBarCodeRevnSearchPara">検索条件</param>
        /// <returns>検索処理結果</returns>
        /// <remarks>
        /// <br>Note       : 商品連結データの検索処理を行います。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// <br>Update Note: 2021/11/18 呉元嘯</br>
        /// <br>管理番号   : 11770181-00</br>
        /// <br>             PJMIT-1499　OUT OF MEMORY対応(4GB対応) 恒久対応</br>
        /// </remarks>
        private int SearchGoodsUnitData(out List<GoodsUnitData> goodsUnitDataList, GoodsBarCodeRevnSearchPara goodsBarCodeRevnSearchPara)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            goodsUnitDataList = new List<GoodsUnitData>();
            try
            {
                // StockDiv 0:在庫のみ
                if (goodsBarCodeRevnSearchPara.StockDiv == 0)
                {
                    List<GoodsUnitData> userGoodsUnitDataList = new List<GoodsUnitData>();
                    // 商品連結データ(ユーザー分)検索処理
                    // --- UPD 2021/11/18 呉元嘯 PJMIT-1499対応 恒久対応------>>>>> 
                    //status = SearchUserGoodsUnitData(out userGoodsUnitDataList, goodsBarCodeRevnSearchPara);
                    //// 検索処理エラー時
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR) return status;
                    //if (userGoodsUnitDataList != null && userGoodsUnitDataList.Count > 0)
                    //{
                    //    foreach (GoodsUnitData temp in userGoodsUnitDataList)
                    //    {
                    //        if (temp.StockList != null && temp.StockList.Count > 0)
                    //        {
                    //            for (int i = temp.StockList.Count - 1; i >= 0; i--)
                    //            {
                    //                // 検索条件：「倉庫コード」と「管理拠点コード」が有り時、
                    //                if (!string.IsNullOrEmpty(goodsBarCodeRevnSearchPara.WarehouseCode)
                    //                    && !string.IsNullOrEmpty(goodsBarCodeRevnSearchPara.SectionCode))
                    //                {
                    //                    // 商品情報に「倉庫コード」と「管理拠点コード」に合致しない倉庫情報を除く
                    //                    if (temp.StockList[i].WarehouseCode != goodsBarCodeRevnSearchPara.WarehouseCode
                    //                        || temp.StockList[i].SectionCode != goodsBarCodeRevnSearchPara.SectionCode)
                    //                    {
                    //                        temp.StockList.RemoveAt(i);
                    //                    }
                    //                }
                    //                // 検索条件：「倉庫コード」が有り時
                    //                else if (!string.IsNullOrEmpty(goodsBarCodeRevnSearchPara.WarehouseCode))
                    //                {
                    //                    // 商品情報に「倉庫コード」に合致しない倉庫情報を除く
                    //                    if (temp.StockList[i].WarehouseCode != goodsBarCodeRevnSearchPara.WarehouseCode)
                    //                    {
                    //                        temp.StockList.RemoveAt(i);
                    //                    }
                    //                }
                    //                // 検索条件：「管理拠点コード」が有り時
                    //                else if (!string.IsNullOrEmpty(goodsBarCodeRevnSearchPara.SectionCode))
                    //                {
                    //                    // 商品情報に「管理拠点コード」に合致しない倉庫情報を除く
                    //                    if (temp.StockList[i].SectionCode != goodsBarCodeRevnSearchPara.SectionCode)
                    //                    {
                    //                        temp.StockList.RemoveAt(i);
                    //                    }
                    //                }
                    //            }
                    //            // 倉庫情報があるの商品のみを取得
                    //            if (temp.StockList != null && temp.StockList.Count > 0)
                    //            {
                    //                goodsUnitDataList.Add(temp);
                    //            }
                    //        }
                    //    }
                    //}
                    status = SearchStockUserGoodsUnitData(out goodsUnitDataList, goodsBarCodeRevnSearchPara);
                    // --- UPD 2021/11/18 呉元嘯 PJMIT-1499対応 恒久対応------<<<<<
                }
                else
                {
                    List<GoodsUnitData> offerGoodsUnitDataList = new List<GoodsUnitData>();
                    List<GoodsUnitData> userGoodsUnitDataList = new List<GoodsUnitData>();
                    // 商品連結データ(提供分)検索処理
                    status = SearchOfferGoodsUnitData(out offerGoodsUnitDataList, goodsBarCodeRevnSearchPara);
                    // 検索処理エラー時
                    if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR) return status;
                    // 商品連結データ(ユーザー分)検索処理
                    status = SearchUserGoodsUnitData(out userGoodsUnitDataList, goodsBarCodeRevnSearchPara);
                    // 検索処理エラー時
                    if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR) return status;

                    // 商品連結データディクショナリ
                    Dictionary<string, GoodsUnitData> goodsUnitDataDic = new Dictionary<string, GoodsUnitData>();
                    // 商品連結データ(提供分)をディクショナリに実装
                    if (offerGoodsUnitDataList != null && offerGoodsUnitDataList.Count > 0)
                    {
                        for (int i = 0; i < offerGoodsUnitDataList.Count; i++)
                        {
                            // キー: 商品メーカーコード(4桁) + "_" + 商品番号
                            string dicKey = offerGoodsUnitDataList[i].GoodsMakerCd.ToString("0000") + "_" + offerGoodsUnitDataList[i].GoodsNo;
                            if (!goodsUnitDataDic.ContainsKey(dicKey))
                            {
                                goodsUnitDataDic.Add(dicKey, offerGoodsUnitDataList[i]);
                            }
                        }
                    }
                    // 商品連結データ(ユーザー分)をディクショナリに実装
                    if (userGoodsUnitDataList != null && userGoodsUnitDataList.Count > 0)
                    {
                        for (int i = 0; i < userGoodsUnitDataList.Count; i++)
                        {
                            // キー: 商品メーカーコード(4桁) + "_" + 商品番号
                            string dicKey = userGoodsUnitDataList[i].GoodsMakerCd.ToString("0000") + "_" + userGoodsUnitDataList[i].GoodsNo;
                            if (!goodsUnitDataDic.ContainsKey(dicKey))
                            {
                                goodsUnitDataDic.Add(dicKey, userGoodsUnitDataList[i]);
                            }
                        }
                    }
                    // ディクショナリの中の商品連結データを取得
                    foreach (GoodsUnitData temp in goodsUnitDataDic.Values)
                    {
                        goodsUnitDataList.Add(temp);
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 商品連結データ(提供分)検索処理
        /// </summary>
        /// <param name="goodsUnitDataList">検索結果List</param>
        /// <param name="goodsBarCodeRevnSearchPara">検索条件</param>
        /// <returns>検索処理結果</returns>
        /// <remarks>
        /// <br>Note       : 商品連結データ(提供分)の検索処理を行います。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private int SearchOfferGoodsUnitData(out List<GoodsUnitData> goodsUnitDataList, GoodsBarCodeRevnSearchPara goodsBarCodeRevnSearchPara)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            goodsUnitDataList = new List<GoodsUnitData>();
            try
            {
                string errMsg = string.Empty;
                PartsInfoDataSet partsInfoDataSet;

                // 抽出条件の作成
                GoodsCndtn goodsCndtn = new GoodsCndtn();

                // 企業コード
                goodsCndtn.EnterpriseCode = goodsBarCodeRevnSearchPara.EnterpriseCode;
                // 商品メーカーコード
                goodsCndtn.GoodsMakerCd = goodsBarCodeRevnSearchPara.GoodsMakerCd;
                // 商品番号
                goodsCndtn.GoodsNo = goodsBarCodeRevnSearchPara.GoodsNo;
                // 仕入先情報取得区分 1:設定なし
                goodsCndtn.IsSettingSupplier = 1;
                // 論理削除区分
                goodsCndtn.LogicalMode = (int)ConstantManagement.LogicalMode.GetData0;

                // 商品マスタ（提供データ）検索
                status = this._goodsAcs.SearchPartsOfNonGoodsNo(goodsCndtn, out partsInfoDataSet, out goodsUnitDataList, out errMsg);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 商品連結データ(ユーザー分)検索処理
        /// </summary>
        /// <param name="goodsUnitDataList">検索結果List</param>
        /// <param name="goodsBarCodeRevnSearchPara">検索条件</param>
        /// <returns>検索処理結果</returns>
        /// <remarks>
        /// <br>Note       : 商品連結データ(ユーザー分)の検索処理を行います。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// <br>Update Note: 2021/11/03 呉元嘯</br>
        /// <br>管理番号   : 11770175-00</br>
        /// <br>             PJMIT-1499　OUT OF MEMORY対応(4GB対応)</br>
        /// </remarks>
        private int SearchUserGoodsUnitData(out List<GoodsUnitData> goodsUnitDataList, GoodsBarCodeRevnSearchPara goodsBarCodeRevnSearchPara)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            goodsUnitDataList = new List<GoodsUnitData>();
            // --- ADD 2021/11/03 呉元嘯 PJMIT-1499対応 ------>>>>>
            // メモリアウトフラグ初期化設定
            this._memoryOutFlag = false;
            // --- ADD 2021/11/03 呉元嘯 PJMIT-1499対応 ------<<<<<

            try
            {
                string errMsg = string.Empty;

                // 抽出条件の作成
                GoodsCndtn goodsCndtn = new GoodsCndtn();
                // 企業コード
                goodsCndtn.EnterpriseCode = goodsBarCodeRevnSearchPara.EnterpriseCode;
                // 商品メーカーコード
                goodsCndtn.GoodsMakerCd = goodsBarCodeRevnSearchPara.GoodsMakerCd;
                // 商品番号
                goodsCndtn.GoodsNo = goodsBarCodeRevnSearchPara.GoodsNo;
                // 前方一致
                goodsCndtn.GoodsNoSrchTyp = 1;
                // 商品属性 (9:全て対象)
                goodsCndtn.GoodsKindCode = 9;
                // 仕入先情報取得区分 1:設定なし
                goodsCndtn.IsSettingSupplier = 1;

                // 検索 (論理削除データ取得しない)
                status = this._goodsAcs.Search(goodsCndtn, 0, goodsBarCodeRevnSearchPara.StockDiv, ConstantManagement.LogicalMode.GetData0, out goodsUnitDataList, out errMsg);
                // --- ADD 2021/11/03 呉元嘯 PJMIT-1499対応 ------>>>>>
                //メモリアウトが発生される時、メモリアウトフラグをtrueに設定
                if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR &&
                    errMsg.Contains(CT_MemoryOutStr))
                {
                    this._memoryOutFlag = true;
                }
                // --- ADD 2021/11/03 呉元嘯 PJMIT-1499対応 ------<<<<<
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        // --- ADD 2021/11/18 呉元嘯 PJMIT-1499対応 恒久対応------>>>>>
        /// <summary>
        /// 在庫分の商品連結データ(ユーザー分)検索処理
        /// </summary>
        /// <param name="goodsUnitDataList">検索結果List</param>
        /// <param name="goodsBarCodeRevnSearchPara">検索条件</param>
        /// <returns>検索処理結果</returns>
        /// <remarks>
        /// <br>Note       : 在庫分の商品連結データ(ユーザー分)の検索処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2021/11/18</br>
        /// </remarks>
        private int SearchStockUserGoodsUnitData(out List<GoodsUnitData> goodsUnitDataList, GoodsBarCodeRevnSearchPara goodsBarCodeRevnSearchPara)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            goodsUnitDataList = new List<GoodsUnitData>();
            ArrayList wkList = new ArrayList();
            try
            {
                GoodsBarCodeRevnSearchParaWork goodsBarCodeRevnSearchParaWork = new GoodsBarCodeRevnSearchParaWork();

                if (goodsBarCodeRevnSearchPara != null)
                {
                    // 商品バーコード関連付け検索条件クラス ⇒ ワーククラス
                    goodsBarCodeRevnSearchParaWork = CopyToGoodsBarCodeRevnSearchParaWorkFromSearchPara(goodsBarCodeRevnSearchPara);
                }
                // 商品バーコード関連付け検索条件ワーククラス ⇒ obj
                object paraobj = goodsBarCodeRevnSearchParaWork;
                object retobj = null;

                // 在庫分の商品連結データ(ユーザー分)検索
                status = this._iGoodsBarCodeRevnDB.SearchStockGoods(out retobj, paraobj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 在庫分の商品連結データ(ユーザー分)検索List
                    wkList = retobj as ArrayList;
                    if (wkList != null && wkList.Count > 0)
                    {
                        for (int i = 0; i < wkList.Count; i++)
                        {
                            GoodsUnitData wkGoodsUnitData = new GoodsUnitData();
                            GoodsBarCodeRevnWork wkGoodsBarCodeRevnWork = (GoodsBarCodeRevnWork)wkList[i];
                            wkGoodsUnitData.GoodsMakerCd = wkGoodsBarCodeRevnWork.GoodsMakerCd;
                            wkGoodsUnitData.GoodsNo = wkGoodsBarCodeRevnWork.GoodsNo;
                            wkGoodsUnitData.GoodsName = wkGoodsBarCodeRevnWork.GoodsName;
                            wkGoodsUnitData.MakerName = wkGoodsBarCodeRevnWork.MakerName;
                            wkGoodsUnitData.OfferDataDiv = wkGoodsBarCodeRevnWork.OfferDataDiv;
                            if (wkGoodsBarCodeRevnWork.OfferDate != 0)
                            {
                                wkGoodsUnitData.OfferDate = DateTime.ParseExact(wkGoodsBarCodeRevnWork.OfferDate.ToString(), "yyyyMMdd", null);
                            }
                            goodsUnitDataList.Add(wkGoodsUnitData);
                        }
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        // --- ADD 2021/11/18 呉元嘯 PJMIT-1499対応 恒久対応------<<<<<

        /// <summary>
        /// 商品バーコード関連付け検索処理
        /// </summary>
        /// <param name="goodsBarCodeRevnWorkList">検索結果List</param>
        /// <param name="goodsBarCodeRevnSearchPara">検索条件</param>
        /// <returns>検索処理結果</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けの検索処理を行います。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private int SearchGoodsBarCodeRevnWorkData(out List<GoodsBarCodeRevnWork> goodsBarCodeRevnWorkList, GoodsBarCodeRevnSearchPara goodsBarCodeRevnSearchPara)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            goodsBarCodeRevnWorkList = new List<GoodsBarCodeRevnWork>();
            try
            {
                ArrayList wkList = new ArrayList();

                GoodsBarCodeRevnSearchParaWork goodsBarCodeRevnSearchParaWork = new GoodsBarCodeRevnSearchParaWork();

                if (goodsBarCodeRevnSearchPara != null)
                {
                    // 商品バーコード関連付け検索条件クラス ⇒ ワーククラス
                    goodsBarCodeRevnSearchParaWork = CopyToGoodsBarCodeRevnSearchParaWorkFromSearchPara(goodsBarCodeRevnSearchPara);

                    goodsBarCodeRevnSearchParaWork.GoodsNo = string.Empty;
                }
                // 商品バーコード関連付け検索条件ワーククラス ⇒ obj
                object paraobj = goodsBarCodeRevnSearchParaWork;
                object retobj = null;

                // 商品バーコード関連付けデータ検索
                status = this._iGoodsBarCodeRevnDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData01);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 商品バーコード関連付けワークList
                    wkList = retobj as ArrayList;
                    if (wkList != null&&wkList.Count>0)
                    {
                        for (int i = 0; i < wkList.Count; i++)
                        {
                            goodsBarCodeRevnWorkList.Add((GoodsBarCodeRevnWork)wkList[i]);
                        }
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 商品バーコードデータと商品連結データを結び付ける
        /// </summary>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="goodsBarCodeRevnWorkList">商品バーコードデータ</param>
        /// <param name="haveCodeDiv">登録区分</param>
        /// <returns>結合処理したデータ</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコードデータと商品連結データの結合処理を行います。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private List<GoodsBarCodeRevn> UnitGoodsDataAndGoodsBarData(List<GoodsUnitData> goodsUnitDataList, List<GoodsBarCodeRevnWork> goodsBarCodeRevnWorkList, int haveCodeDiv)
        {
            List<GoodsBarCodeRevn> retList = new List<GoodsBarCodeRevn>();

            if (goodsUnitDataList != null && goodsUnitDataList.Count > 0)
            {

                // 商品バーコード関連付けディクショナリ
                Dictionary<string, GoodsBarCodeRevnWork> _goodsBarCodeRevnWorkDic = new Dictionary<string, GoodsBarCodeRevnWork>();
                // キーのList
                List<string> keyList = new List<string>();

                if (goodsBarCodeRevnWorkList != null && goodsBarCodeRevnWorkList.Count > 0)
                {
                    for (int i = 0; i < goodsBarCodeRevnWorkList.Count; i++)
                    {
                        // キー: 商品メーカーコード(4桁) + "_" + 商品番号
                        string dicKey = goodsBarCodeRevnWorkList[i].GoodsMakerCd.ToString("0000") + "_" + goodsBarCodeRevnWorkList[i].GoodsNo;
                        if (!_goodsBarCodeRevnWorkDic.ContainsKey(dicKey))
                        {
                            // 既存のデータをディクショナリにセット
                            _goodsBarCodeRevnWorkDic.Add(dicKey, goodsBarCodeRevnWorkList[i]);
                        }
                    }
                }

                for (int j = 0; j < goodsUnitDataList.Count; j++)
                {
                    GoodsBarCodeRevn temp = new GoodsBarCodeRevn();
                    // 企業コード
                    temp.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                    // 商品メーカーコード
                    temp.GoodsMakerCd = goodsUnitDataList[j].GoodsMakerCd;
                    // 商品番号
                    temp.GoodsNo = goodsUnitDataList[j].GoodsNo;
                    // メーカー名称
                    temp.MakerName = goodsUnitDataList[j].MakerName;
                    // 商品名称
                    temp.GoodsName = goodsUnitDataList[j].GoodsName;
                    // 商品バーコード種別：0:JAN
                    temp.GoodsBarCodeKind = 0;
                    // 提供データ区分
                    temp.OfferDataDiv = goodsUnitDataList[j].OfferDataDiv;
                    // 提供日付
                    if (goodsUnitDataList[j].OfferDate != null)
                    {
                        int intOfferDate = 0;
                        Int32.TryParse(goodsUnitDataList[j].OfferDate.ToString("yyyyMMdd"), out intOfferDate);
                        temp.OfferDate = intOfferDate;
                    }

                    // キー: 商品メーカーコード(4桁)  + "_" + 商品番号
                    string dicKey = goodsUnitDataList[j].GoodsMakerCd.ToString("0000") + "_" + goodsUnitDataList[j].GoodsNo;
                    // 登録済みデータ
                    if (_goodsBarCodeRevnWorkDic.ContainsKey(dicKey))
                    {
                        // 作成日時
                        temp.CreateDateTime = _goodsBarCodeRevnWorkDic[dicKey].CreateDateTime;
                        // 更新日時
                        temp.UpdateDateTime = _goodsBarCodeRevnWorkDic[dicKey].UpdateDateTime;
                        // GUID
                        temp.FileHeaderGuid = _goodsBarCodeRevnWorkDic[dicKey].FileHeaderGuid;
                        // 更新従業員コード
                        temp.UpdEmployeeCode = _goodsBarCodeRevnWorkDic[dicKey].UpdEmployeeCode;
                        // 更新アセンブリID1
                        temp.UpdAssemblyId1 = _goodsBarCodeRevnWorkDic[dicKey].UpdAssemblyId1;
                        // 更新アセンブリID2
                        temp.UpdAssemblyId2 = _goodsBarCodeRevnWorkDic[dicKey].UpdAssemblyId2;
                        // 論理削除区分
                        temp.LogicalDeleteCode = _goodsBarCodeRevnWorkDic[dicKey].LogicalDeleteCode;
                        // 商品バーコード
                        temp.GoodsBarCode = _goodsBarCodeRevnWorkDic[dicKey].GoodsBarCode;
                        // 商品バーコード種別
                        temp.GoodsBarCodeKind = _goodsBarCodeRevnWorkDic[dicKey].GoodsBarCodeKind;
                        // チェックデジット区分
                        temp.CheckdigitCode = _goodsBarCodeRevnWorkDic[dicKey].CheckdigitCode;
                        // 提供日付
                        temp.OfferDate = _goodsBarCodeRevnWorkDic[dicKey].OfferDate;
                        // 提供データ区分
                        temp.OfferDataDiv = _goodsBarCodeRevnWorkDic[dicKey].OfferDataDiv;
                    }
                    // 登録区分 0:全て 1:バーコード有り 2:バーコード無し
                    if (haveCodeDiv == 0)
                    {
                        retList.Add(temp);
                    }
                    else
                    {
                        if (haveCodeDiv == 1 && !string.IsNullOrEmpty(temp.GoodsBarCode))
                        {
                            retList.Add(temp);
                        }
                        else if (haveCodeDiv == 2 && string.IsNullOrEmpty(temp.GoodsBarCode))
                        {
                            retList.Add(temp);
                        }
                    }
                }
            }
            
            return retList;
        }
        #endregion

        #region ■ 保存処理
        /// <summary>
        /// 商品バーコード関連付けデータの保存処理
        /// </summary>
        /// <param name="saveList">保存用リスト</param>
        /// <param name="deleteList">削除用リスト</param>
        /// <returns>保存処理結果</returns>
        /// <remarks>
        /// <br>Note       : 保存処理を行います。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public int WriteBySave(List<GoodsBarCodeRevn> saveList, List<GoodsBarCodeRevn> deleteList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList saveWorkList = new ArrayList();
                ArrayList deleteWorkList = new ArrayList();
                if (saveList != null && saveList.Count > 0)
                {
                    for (int i = 0; i < saveList.Count; i++)
                    {
                        // 保存用商品バーコード関連付けワークList
                        saveWorkList.Add(CopyToGoodsBarCodeRevnWorkFromGoodsBarCodeRevn(saveList[i]));
                    }
                }
                if (deleteList != null && deleteList.Count > 0)
                {
                    for (int i = 0; i < deleteList.Count; i++)
                    {
                        // 削除用商品バーコード関連付けワークList
                        deleteWorkList.Add(CopyToGoodsBarCodeRevnWorkFromGoodsBarCodeRevn(deleteList[i]));
                    }
                }
                object objSaveWorkList = (object)saveWorkList;
                object objDeleteWorkList = (object)deleteWorkList;
                // 商品バーコード関連付け保存処理  
                status = this._iGoodsBarCodeRevnDB.WriteBySave(ref objSaveWorkList, ref objDeleteWorkList);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #region ■ クラス ⇔ クラスワーク処理

        /// <summary>
        /// クラスメンバコピー処理（商品バーコード関連付けクラス→商品バーコード関連付けクラスワーク）
        /// </summary>
        /// <param name="goodsBarCodeRevn">商品バーコード関連付けクラス</param>
        /// <returns>商品バーコード関連付けワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けクラスから商品バーコード関連付けワーククラスへメンバコピーを行います。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private GoodsBarCodeRevnWork CopyToGoodsBarCodeRevnWorkFromGoodsBarCodeRevn(GoodsBarCodeRevn goodsBarCodeRevn)
        {
            GoodsBarCodeRevnWork goodsBarCodeRevnWork = new GoodsBarCodeRevnWork();

            // 作成日時
            goodsBarCodeRevnWork.CreateDateTime = goodsBarCodeRevn.CreateDateTime;
            // 更新日時
            goodsBarCodeRevnWork.UpdateDateTime = goodsBarCodeRevn.UpdateDateTime;
            // 企業コード
            goodsBarCodeRevnWork.EnterpriseCode = goodsBarCodeRevn.EnterpriseCode;
            // GUID
            goodsBarCodeRevnWork.FileHeaderGuid = goodsBarCodeRevn.FileHeaderGuid;
            // 更新従業員コード
            goodsBarCodeRevnWork.UpdEmployeeCode = goodsBarCodeRevn.UpdEmployeeCode;
            // 更新アセンブリID1
            goodsBarCodeRevnWork.UpdAssemblyId1 = goodsBarCodeRevn.UpdAssemblyId1;
            // 更新アセンブリID2
            goodsBarCodeRevnWork.UpdAssemblyId2 = goodsBarCodeRevn.UpdAssemblyId2;
            // 論理削除区分
            goodsBarCodeRevnWork.LogicalDeleteCode = goodsBarCodeRevn.LogicalDeleteCode;

            // 商品メーカーコード
            goodsBarCodeRevnWork.GoodsMakerCd = goodsBarCodeRevn.GoodsMakerCd;
            // 商品番号
            goodsBarCodeRevnWork.GoodsNo = goodsBarCodeRevn.GoodsNo;
            // 商品バーコード
            goodsBarCodeRevnWork.GoodsBarCode = goodsBarCodeRevn.GoodsBarCode;
            // 商品バーコード種別
            goodsBarCodeRevnWork.GoodsBarCodeKind = goodsBarCodeRevn.GoodsBarCodeKind;
            // チェックデジット区分
            goodsBarCodeRevnWork.CheckdigitCode = goodsBarCodeRevn.CheckdigitCode;
            // 提供日付
            goodsBarCodeRevnWork.OfferDate = goodsBarCodeRevn.OfferDate;
            // 提供データ区分
            goodsBarCodeRevnWork.OfferDataDiv = goodsBarCodeRevn.OfferDataDiv;
            // メーカー名称
            goodsBarCodeRevnWork.MakerName = goodsBarCodeRevn.MakerName;
            // 商品名称
            goodsBarCodeRevnWork.GoodsName = goodsBarCodeRevn.GoodsName;

            return goodsBarCodeRevnWork;
        }

        /// <summary>
        /// クラスメンバコピー処理（商品バーコード関連付けワーククラス→商品バーコード関連付けクラス）
        /// </summary>
        /// <param name="goodsBarCodeRevnWork">検品全体設定ワーククラス</param>
        /// <returns>商品バーコード関連付けクラス</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けワーククラスから商品バーコード関連付けクラスへメンバコピーを行います。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private GoodsBarCodeRevn CopyToGoodsBarCodeRevnFromGoodsBarCodeRevnWork(GoodsBarCodeRevnWork goodsBarCodeRevnWork)
        {
            GoodsBarCodeRevn goodsBarCodeRevn = new GoodsBarCodeRevn();

            // 作成日時
            goodsBarCodeRevn.CreateDateTime = goodsBarCodeRevnWork.CreateDateTime;
            // 更新日時
            goodsBarCodeRevn.UpdateDateTime = goodsBarCodeRevnWork.UpdateDateTime;
            // 企業コード
            goodsBarCodeRevn.EnterpriseCode = goodsBarCodeRevnWork.EnterpriseCode;
            // GUID
            goodsBarCodeRevn.FileHeaderGuid = goodsBarCodeRevnWork.FileHeaderGuid;
            // 更新従業員コード
            goodsBarCodeRevn.UpdEmployeeCode = goodsBarCodeRevnWork.UpdEmployeeCode;
            // 更新アセンブリID1
            goodsBarCodeRevn.UpdAssemblyId1 = goodsBarCodeRevnWork.UpdAssemblyId1;
            // 更新アセンブリID2
            goodsBarCodeRevn.UpdAssemblyId2 = goodsBarCodeRevnWork.UpdAssemblyId2;
            // 論理削除区分
            goodsBarCodeRevn.LogicalDeleteCode = goodsBarCodeRevnWork.LogicalDeleteCode;

            // 商品メーカーコード
            goodsBarCodeRevn.GoodsMakerCd = goodsBarCodeRevnWork.GoodsMakerCd;
            // 商品番号
            goodsBarCodeRevn.GoodsNo = goodsBarCodeRevnWork.GoodsNo;
            // 商品バーコード
            goodsBarCodeRevn.GoodsBarCode = goodsBarCodeRevnWork.GoodsBarCode;
            // 商品バーコード種別
            goodsBarCodeRevn.GoodsBarCodeKind = goodsBarCodeRevnWork.GoodsBarCodeKind;
            // チェックデジット区分
            goodsBarCodeRevn.CheckdigitCode = goodsBarCodeRevnWork.CheckdigitCode;
            // 提供日付
            goodsBarCodeRevn.OfferDate = goodsBarCodeRevnWork.OfferDate;
            // 提供データ区分
            goodsBarCodeRevn.OfferDataDiv = goodsBarCodeRevnWork.OfferDataDiv;
            // メーカー名称
            goodsBarCodeRevn.MakerName = goodsBarCodeRevnWork.MakerName;
            // 商品名称
            goodsBarCodeRevn.GoodsName = goodsBarCodeRevnWork.GoodsName;

            return goodsBarCodeRevn;
        }

        /// <summary>
        /// クラスメンバコピー処理（商品バーコード関連付け検索条件クラス→クラスワーク）
        /// </summary>
        /// <param name="goodsBarCodeRevnSearchPara">商品バーコード関連付け検索条件クラス</param>
        /// <returns>商品バーコード関連付け検索条件ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付け検索条件クラスからワーククラスへメンバコピーを行います。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private GoodsBarCodeRevnSearchParaWork CopyToGoodsBarCodeRevnSearchParaWorkFromSearchPara(GoodsBarCodeRevnSearchPara goodsBarCodeRevnSearchPara)
        {
            GoodsBarCodeRevnSearchParaWork goodsBarCodeRevnSearchParaWork = new GoodsBarCodeRevnSearchParaWork();

            // 企業コード
            goodsBarCodeRevnSearchParaWork.EnterpriseCode = goodsBarCodeRevnSearchPara.EnterpriseCode;
            // 在庫区分
            goodsBarCodeRevnSearchParaWork.StockDiv = goodsBarCodeRevnSearchPara.StockDiv;
            // コード(有無)
            goodsBarCodeRevnSearchParaWork.HaveBarCodeDiv = goodsBarCodeRevnSearchPara.HaveBarCodeDiv;
            // 商品メーカーコード
            goodsBarCodeRevnSearchParaWork.GoodsMakerCd = goodsBarCodeRevnSearchPara.GoodsMakerCd;
            // 商品番号
            goodsBarCodeRevnSearchParaWork.GoodsNo = goodsBarCodeRevnSearchPara.GoodsNo;
            // 倉庫コード
            goodsBarCodeRevnSearchParaWork.WarehouseCode = goodsBarCodeRevnSearchPara.WarehouseCode;
            // 拠点コード
            goodsBarCodeRevnSearchParaWork.SectionCode = goodsBarCodeRevnSearchPara.SectionCode;

            return goodsBarCodeRevnSearchParaWork;
        }

        /// <summary>
        /// クラスメンバコピー処理（商品バーコード関連付け検索条件ワーククラス→クラス）
        /// </summary>
        /// <param name="goodsBarCodeRevnSearchParaWork">商品バーコード関連付け検索条件ワーククラス</param>
        /// <returns>商品バーコード関連付け検索条件クラス</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付け検索条件ワーククラスからクラスへメンバコピーを行います。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private GoodsBarCodeRevnSearchPara CopyToGoodsBarCodeRevnSearchParaFromSearchParaWork(GoodsBarCodeRevnSearchParaWork goodsBarCodeRevnSearchParaWork)
        {
            GoodsBarCodeRevnSearchPara goodsBarCodeRevnSearchPara = new GoodsBarCodeRevnSearchPara();

            // 企業コード
            goodsBarCodeRevnSearchPara.EnterpriseCode = goodsBarCodeRevnSearchParaWork.EnterpriseCode;
            // 在庫区分
            goodsBarCodeRevnSearchPara.StockDiv = goodsBarCodeRevnSearchParaWork.StockDiv;
            // コード(有無)
            goodsBarCodeRevnSearchPara.HaveBarCodeDiv = goodsBarCodeRevnSearchParaWork.HaveBarCodeDiv;
            // 商品メーカーコード
            goodsBarCodeRevnSearchPara.GoodsMakerCd = goodsBarCodeRevnSearchParaWork.GoodsMakerCd;
            // 商品番号
            goodsBarCodeRevnSearchPara.GoodsNo = goodsBarCodeRevnSearchParaWork.GoodsNo;
            // 倉庫コード
            goodsBarCodeRevnSearchPara.WarehouseCode = goodsBarCodeRevnSearchParaWork.WarehouseCode;
            // 拠点コード
            goodsBarCodeRevnSearchPara.SectionCode = goodsBarCodeRevnSearchParaWork.SectionCode;

            return goodsBarCodeRevnSearchPara;
        }

        #endregion
    }
}
