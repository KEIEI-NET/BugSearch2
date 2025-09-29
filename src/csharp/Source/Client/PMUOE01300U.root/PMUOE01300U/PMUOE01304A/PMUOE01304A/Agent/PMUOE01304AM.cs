//****************************************************************************//
// システム         : 卸商仕入受信処理
// プログラム名称   : 卸商仕入受信処理Controller
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/11/17  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Agent
{
    using LoginWorkerAcs = SingletonPolicy<LoginWorker>;
    using MakerDB = SingletonPolicy<MakerMasterDBAgent>;

    /// <summary>
    /// 商品DBアクセスの代理人クラス
    /// </summary>
    public sealed class GoodsDBAgent
    {
        #region <本物のアクセサ/>

        /// <summary>本物のアクセサ</summary>
        private readonly GoodsAcs _realAccesser = new GoodsAcs();
        /// <summary>
        /// 本物のアクセサを取得します。
        /// </summary>
        /// <value>本物のアクセサ</value>
        private GoodsAcs RealAccesser { get { return _realAccesser; } }

        #endregion  // <本物のアクセサ/>

        #region <商品連結データのnullリスト/>

        /// <summary>商品連結データのnullリスト</summary>
        private readonly List<GoodsUnitData> _nullGoodsUnitDataList;
        /// <summary>
        /// 商品連結データのnullリストを取得します。
        /// </summary>
        /// <value>商品連結データのnullリスト</value>
        private List<GoodsUnitData> NullGoodsUnitDataList { get { return _nullGoodsUnitDataList; } }

        #endregion  // <商品連結データのnullリスト/>

        #region <品番検索/>

        /// <summary>2番目の品番検索者</summary>
        private IGoodsFaindable _secondGoodsFinder;
        /// <summary>
        /// 2番目の品番検索者を取得します。
        /// </summary>
        private IGoodsFaindable SecondGoodsFinder
        {
            get
            {
                if (_secondGoodsFinder == null)
                {
                    // 結合検索無し完全一致で品番検索
                    _secondGoodsFinder = new GoodsFinderThatSearchPartsFromGoodsNoNonVariousSearchWholeWord(
                        RealAccesser
                    );
                }
                return _secondGoodsFinder;
            }
        }

        #endregion  // <品番検索/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public GoodsDBAgent()
        {
            _nullGoodsUnitDataList = new List<GoodsUnitData>();
            _nullGoodsUnitDataList.Add(null);
        }

        #endregion  // <Constructor/>

        #region <倉庫/>

        /// <summary>
        /// ログイン拠点の倉庫コード(×3)より、該当する最初の在庫を検索します。
        /// </summary>
        /// <remarks>
        /// 倉庫コード1、2、3 の順に検索します。
        /// </remarks>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <returns>該当する在庫（該当する在庫がない場合、<c>null</c>を返します。）</returns>
        public Stock FindFirstStockByLoginWorkers3WarehouseCodes(
            int makerCode,
            string goodsNo
        )
        {
            // メーカーコードと品番で絞り込み
            GoodsUnitData goodsUnitData = new GoodsUnitData();
            int status = RealAccesser.Read(
                LoginWorkerAcs.Instance.Policy.SectionProfile.Code.Trim(),
                makerCode,
                goodsNo,
                out goodsUnitData
            );
            if (!status.Equals((int)Result.RemoteStatus.Normal) || goodsUnitData == null)
            {
                goodsUnitData = SecondGoodsFinder.Find(makerCode, goodsNo);
                if (goodsUnitData == null) return null;
            }

            // 倉庫コードで検索
            string[] gettingWarehouseCodes = new string[3] {
                LoginWorkerAcs.Instance.Policy.SectionInfo.SectWarehouseCd1,
                LoginWorkerAcs.Instance.Policy.SectionInfo.SectWarehouseCd2,
                LoginWorkerAcs.Instance.Policy.SectionInfo.SectWarehouseCd3
            };
            foreach (string gettingWarehouseCode in gettingWarehouseCodes)
            {
                Stock stock = RealAccesser.GetStockFromStockList(
                    gettingWarehouseCode,
                    makerCode,
                    goodsNo,
                    goodsUnitData.StockList
                );
                if (stock != null) return stock;
            }

            return null;
        }

        #endregion  // <倉庫/>

        #region <商品検索/>

        /// <summary>商品連結データのリストのマップ</summary>
        private readonly IDictionary<string, List<GoodsUnitData>> _goodsUnitDataListMap = new Dictionary<string, List<GoodsUnitData>>();
        /// <summary>
        /// 商品連結データのリストのマップを取得します。
        /// </summary>
        /// <value>商品連結データのリストのマップ</value>
        public IDictionary<string, List<GoodsUnitData>> GoodsUnitDataListMap
        { 
            get { return _goodsUnitDataListMap; }
        }

        /// <summary>
        /// キーを取得します。
        /// </summary>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="uoeSupplier">UOE発注先</param>
        /// <returns>商品番号 + "-" + メーカーコード("000000")×5</returns>
        private static string GetKey(
            string goodsNo,
            UOESupplierHelper uoeSupplier
        )
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(goodsNo).Append("-");

                List<int> makerCodeList = uoeSupplier.CreateSearchingMakerCodeListForGoodsAcs();
                foreach (int makerCode in makerCodeList)
                {
                    key.Append(makerCode.ToString("000000"));
                }
            }
            return key.ToString();
        }

        /// <summary>
        /// 品番検索を行います。
        /// </summary>
        /// <param name="receivedTelegram">受信電文</param>
        /// <param name="uoeSupplier">UOE発注先</param>
        /// <returns>商品連結データ</returns>
        public GoodsUnitData FindFirstGoodsUnitData(
            ReceivedText receivedTelegram,
            UOESupplierHelper uoeSupplier
        )
        {
            string goodsNo = receivedTelegram.ToGoodsNo();

            string key = GetKey(goodsNo, uoeSupplier);
            if (GoodsUnitDataListMap.ContainsKey(key))
            {
                return GoodsUnitDataListMap[key][0];
            }

            // 新たに検索
            GoodsCndtn searchingCondition = new GoodsCndtn();
            {
                searchingCondition.EnterpriseCode   = LoginWorkerAcs.Instance.Policy.EnterpriseProfile.Code;
                searchingCondition.SectionCode      = LoginWorkerAcs.Instance.Policy.SectionProfile.Code;
                searchingCondition.GoodsNo          = goodsNo;
            }

            List<GoodsUnitData> goodsUnitDataList = null;
            string message = string.Empty;
            int status = RealAccesser.SearchPartsFromGoodsNoNonVariousSearch(
                searchingCondition,
                false,
                uoeSupplier.CreateSearchingMakerCodeListForGoodsAcs(),
                out goodsUnitDataList,
                out message
            );
            if (goodsUnitDataList == null || goodsUnitDataList.Count.Equals(0))
            {
                GoodsUnitDataListMap.Add(key, NullGoodsUnitDataList);
                return null;
            }

            // 検索結果を保持
            GoodsUnitDataListMap.Add(key, goodsUnitDataList);

            return goodsUnitDataList[0];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receivedTelegram">受信電文</param>
        /// <param name="uoeSupplier">UOE発注先</param>
        /// <returns></returns>
        public GoodsPrice FindFirstGoodsPrice(
            ReceivedText receivedTelegram,
            UOESupplierHelper uoeSupplier
        )
        {
            GoodsUnitData goodsUnitData = FindFirstGoodsUnitData(receivedTelegram, uoeSupplier);
            if (goodsUnitData == null) return null;

            return goodsUnitData.GoodsPriceList[0];
        }

        #endregion  // <商品検索/>

        #region <品番検索/>

        /// <summary>
        /// 品番検索インターフェース
        /// </summary>
        private interface IGoodsFaindable
        {
            /// <summary>
            /// 品番検索します。
            /// </summary>
            /// <param name="makerCode">メーカーコード</param>
            /// <param name="goodsNo">品番</param>
            /// <returns>商品情報（件数0の場合、<c>null</c>を返します）</returns>
            GoodsUnitData Find(
                int makerCode,
                string goodsNo
            );
        }

        /// <summary>
        /// 結合検索無し完全一致で品番検索するクラス
        /// </summary>
        private sealed class GoodsFinderThatSearchPartsFromGoodsNoNonVariousSearchWholeWord : IGoodsFaindable
        {
            #region <IGoodsFaindable メンバ/>

            /// <summary>
            /// 結合検索無し完全一致で品番検索します。
            /// </summary>
            /// <param name="makerCode">メーカーコード</param>
            /// <param name="goodsNo">品番</param>
            /// <returns>商品情報（件数0の場合、<c>null</c>を返します）</returns>
            public GoodsUnitData Find(
                int makerCode,
                string goodsNo
            )
            {
                string key = GetKey(makerCode, goodsNo);
                if (GoodsUnitDataMap.ContainsKey(key)) return GoodsUnitDataMap[key];

                if (SearchPartsFromGoodsNoNonVariousSearchWholeWord(
                    CreateGoodsCndtnList(makerCode, goodsNo)
                ).Equals((int)Result.RemoteStatus.Normal))
                {
                    if (GoodsUnitDataMap.ContainsKey(key)) return GoodsUnitDataMap[key];
                }

                return null;
            }

            #endregion  // <IGoodsFaindable メンバ/>

            #region <本物のアクセサ/>

            /// <summary>本物のアクセサ</summary>
            private readonly GoodsAcs _realAccesser;
            /// <summary>
            /// 本物のアクセサを取得します。
            /// </summary>
            /// <value>本物のアクセサ</value>
            private GoodsAcs RealAccesser { get { return _realAccesser; } }

            #endregion  // <本物のアクセサ/>

            #region <商品連結データのローカルキャッシュ/>

            /// <summary>商品連結データマップ</summary>
            private readonly IDictionary<string, GoodsUnitData> _goodsUnitDataMap = new Dictionary<string, GoodsUnitData>();
            /// <summary>
            /// 商品連結データマップを取得します。
            /// </summary>
            private IDictionary<string, GoodsUnitData> GoodsUnitDataMap { get { return _goodsUnitDataMap; } }

            #endregion  // <商品連結データのローカルキャッシュ/>

            #region <Constructor/>

            /// <summary>
            /// カスタムコンストラクタ
            /// </summary>
            /// <param name="realAccesser">本物のアクセサ</param>
            public GoodsFinderThatSearchPartsFromGoodsNoNonVariousSearchWholeWord(GoodsAcs realAccesser)
            {
                _realAccesser = realAccesser;
            }

            #endregion  // <Constructor/>

            #region <品番検索（結合検索無し完全一致）/>

            /// <summary>
            /// 商品アクセスクラスの抽出条件リストを生成します。
            /// </summary>
            /// <param name="makerCode">メーカーコード</param>
            /// <param name="goodsNo">品番</param>
            /// <returns>商品アクセスクラスの抽出条件リスト</returns>
            private static List<GoodsCndtn> CreateGoodsCndtnList(
                int makerCode,
                string goodsNo
            )
            {
                List<GoodsCndtn> goodsCndtnList = new List<GoodsCndtn>();
                {
                    GoodsCndtn goodsCndtn = new GoodsCndtn();
                    {
                        goodsCndtn.EnterpriseCode   = LoginWorkerAcs.Instance.Policy.EnterpriseProfile.Code.Trim();
                        goodsCndtn.SectionCode      = LoginWorkerAcs.Instance.Policy.SectionProfile.Code.Trim();

                        MakerSet foundMaker = MakerDB.Instance.Policy.Find(makerCode);
                        if (foundMaker != null)
                        {
                            goodsCndtn.MakerName = foundMaker.MakerName;
                        }
                        goodsCndtn.GoodsNoSrchTyp   = 0;
                        goodsCndtn.GoodsMakerCd     = makerCode;
                        goodsCndtn.GoodsNo          = goodsNo;
                        goodsCndtn.JoinSearchDiv    = (int)GoodsCndtn.JoinSearchDivType.NoSearch;
                    }
                    goodsCndtnList.Add(goodsCndtn);
                }
                return goodsCndtnList;
            }

            /// <summary>
            /// 結合検索無し完全一致で品番検索します。
            /// </summary>
            /// <remarks>
            /// 移植元：DCHAT02105AA.cs::OrderListAcs.GoodsRead()
            /// </remarks>
            /// <param name="goodsCndtnList">商品抽出条件クラスリスト</param>
            /// <returns>結果コード</returns>
            private int SearchPartsFromGoodsNoNonVariousSearchWholeWord(List<GoodsCndtn> goodsCndtnList)
            {
                // 結合検索無し完全一致で商品情報を取得
                List<List<GoodsUnitData>> goodsUnitDataListList = null; // 2パラ目
                string message = string.Empty;                          // 3パラ目
                int status = RealAccesser.SearchPartsFromGoodsNoNonVariousSearchWholeWord(
                    goodsCndtnList,
                    out goodsUnitDataListList,
                    out message
                );
                if ((goodsUnitDataListList != null) && (goodsUnitDataListList.Count > 0))
                {
                    for (int i = 0; i < goodsUnitDataListList.Count; i++)
                    {
                        List<GoodsUnitData> goodsUnitDataList = goodsUnitDataListList[i];
                        
                        for (int j = 0; j < goodsUnitDataList.Count; j++)
                        {
                            GoodsUnitData goodsUnitData = goodsUnitDataList[j];
                            string key = CreateKeyForGoodsUnitDataMap(goodsUnitData);
                            if (GoodsUnitDataMap.ContainsKey(key))
                            {
                                // 同一商品が存在している場合は削除
                                GoodsUnitDataMap.Remove(key);
                            }
                            GoodsUnitDataMap.Add(key, goodsUnitData);
                        }
                    }
                }

                return status;
            }

            /// <summary>
            /// 商品連結データのローカルキャッシュ用キーを作成します。
            /// </summary>
            /// <remarks>
            /// 移植元：DCHAT02105AA.cs::OrderListAcs.CreateKey_GoodsUnitData()
            /// </remarks>
            /// <param name="goodsUnitData">商品連結データ</param>
            /// <returns>メーカーコード(0000) + "-" + 品番</returns>
            private static string CreateKeyForGoodsUnitDataMap(GoodsUnitData goodsUnitData)
            {
                return GetKey(goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo);
            }

            /// <summary>
            /// 商品連結データのローカルキャッシュ用キーを作成します。
            /// </summary>
            /// <param name="goodsMakerCode">メーカーコード</param>
            /// <param name="goodsNo">品番</param>
            /// <returns>メーカーコード(0000) + "-" + 品番</returns>
            private static string GetKey(
                int goodsMakerCode,
                string goodsNo
            )
            {
                // メーカーコード + 品番
                return goodsMakerCode.ToString("d04") + "-" + goodsNo;
            }

            #endregion  // <品番検索（結合検索無し完全一致）/>
        }

        #endregion  // <品番検索/>
    }
}
