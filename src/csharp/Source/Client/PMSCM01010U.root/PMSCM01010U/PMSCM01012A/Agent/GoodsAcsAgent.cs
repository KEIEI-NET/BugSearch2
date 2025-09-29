//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/07/09  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018　鈴木 正臣
// 作 成 日  2012/04/19  修正内容 : RC-SCM速度改良の修正
//                               ：（※検索結果が不正にならないようキャッシュクリアする）
//                               ：（※キャッシュクリアしてもstaticで保持している情報を再取得しないよう変更）
//----------------------------------------------------------------------------//
// 管理番号  11070076-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2014/05/08  修正内容 : PM-SCM速度改良 フェーズ２対応
//                                : 01.商品検索アクセスクラス補正処理プロパティ対応
//                                : 02.得意先掛率グループマスタ取得改良対応（回答判定時）
//                                : 03.変更前単価計算呼出回数改良対応
//                                : 04.キャンペーン売価設定マスタ取得改良対応
//                                : 05.得意先マスタ（伝票管理）取得改良対応
//                                : 06.得意先マスタ取得改良対応（金額計算クラス）
//                                : 07.得意先マスタ取得改良対応（金額計算クラス・キャンペーン対応）
//                                : 08.売上データ生成時のシステム日付取得対応
//                                : 09.得意先掛率グループマスタ取得改良対応（売上データ生成時）
//                                : 10.単価計算呼出回数改良
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Agent
{
    /// <summary>
    /// 商品検索クラスの代理人クラス
    /// </summary>
    public sealed class GoodsAcsAgent
    {
        #region <商品検索クラス>

        /// <summary>商品検索クラスのマップ</summary>
        private IDictionary<string, GoodsAcs> _goodsAcsMap;
        /// <summary>商品検索クラスのマップを取得します。</summary>
        /// <remarks>キー：企業コード + 拠点コード</remarks>
        private IDictionary<string, GoodsAcs> GoodsAcsMap
        {
            get
            {
                if (_goodsAcsMap == null)
                {
                    _goodsAcsMap = new Dictionary<string, GoodsAcs>();
                }
                return _goodsAcsMap;
            }
        }

        // --- ADD m.suzuki 2012/04/19 ---------->>>>>
        /// <summary>商品検索クラス初期化済みフラグのマップ</summary>
        private static IDictionary<string, bool> _goodsAcsInitFlagMap;
        /// <summary>商品検索クラス初期化済みフラグのマップを取得します。</summary>
        /// <remarks>キー：企業コード + 拠点コード</remarks>
        private static IDictionary<string, bool> GoodsAcsInitFlagMap
        {
            get
            {
                if ( _goodsAcsInitFlagMap == null )
                {
                    _goodsAcsInitFlagMap = new Dictionary<string, bool>();
                }
                return _goodsAcsInitFlagMap;
            }
        }
        // --- ADD m.suzuki 2012/04/19 ----------<<<<<

        #endregion // </商品検索クラス>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public GoodsAcsAgent() { }

        #endregion // </Constructor>

        /// <summary>
        /// 商品検索クラスを取得します。
        /// </summary>
        /// <param name="scmDetailRecord">SCM受注明細データ(問合せ・発注)</param>
        /// <returns>該当する商品検索クラス</returns>
        public GoodsAcs GetGoodsAccesser(
            ISCMOrderDetailRecord scmDetailRecord
        )
        {
            return GetGoodsAccesser(scmDetailRecord.InqOtherEpCd, scmDetailRecord.InqOtherSecCd);
        }

        /// <summary>
        /// 商品検索クラスを取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>該当する商品検索クラス</returns>
        private GoodsAcs GetGoodsAccesser(
            string enterpriseCode,
            string sectionCode
        )
        {
            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode) + SCMEntityUtil.FormatSectionCode(sectionCode);
            if (GoodsAcsMap.ContainsKey(key))
            {
                return GoodsAcsMap[key];
            }
            GoodsAcs goodsAccesser = new GoodsAcs(sectionCode);
            {
                string msg = string.Empty;
                // ADD 2014/05/08 PM-SCM速度改良 フェーズ２№01.商品検索アクセスクラス補正処理プロパティ対応 --------------------------------->>>>>
                goodsAccesser.IsGetSupplier = true;
                // ADD 2014/05/08 PM-SCM速度改良 フェーズ２№01.商品検索アクセスクラス補正処理プロパティ対応 ---------------------------------<<<<<
                // --- UPD m.suzuki 2012/04/19 ---------->>>>>
                //goodsAccesser.SearchInitial(enterpriseCode, sectionCode, out msg);
                if ( !GoodsAcsInitFlagMap.ContainsKey( key ) )
                {
                    // 商品アクセスクラスのSearchInitial実行
                    goodsAccesser.SearchInitial( enterpriseCode, sectionCode, out msg );
                    
                    // SearchInitial実行済みディクショナリに追加
                    GoodsAcsInitFlagMap.Add( key, true );
                }
                // --- UPD m.suzuki 2012/04/19 ----------<<<<<

                GoodsAcsMap.Add(key, goodsAccesser);
            }
            return goodsAccesser;
        }
        // --- ADD m.suzuki 2012/04/19 ---------->>>>>
        /// <summary>
        /// GoodsAcsMapをクリアします。
        /// </summary>
        public void ClearGoodsAcsMap()
        {
            if ( GoodsAcsMap != null )
            {
                GoodsAcsMap.Clear();
            }
        }
        // --- ADD m.suzuki 2012/04/19 ----------<<<<<
    }
}
