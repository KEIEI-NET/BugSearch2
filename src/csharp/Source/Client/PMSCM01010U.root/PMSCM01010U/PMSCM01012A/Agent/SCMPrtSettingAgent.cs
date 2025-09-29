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
// 作 成 日  2009/05/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = SCMPrtSettingAcs;
    using RecordType        = IList<SCMPrtSetting>;

    /// <summary>
    /// SCM品目設定アクセスの代理人クラス
    /// </summary>
    public sealed class SCMPrtSettingAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "SCMPrtSettingAgent";    // ログ用

        /// <summary>
        /// 自動回答区分列挙型
        /// </summary>
        public enum AutoAnswerDiv : int
        {
            /// <summary>0:しない</summary>
            None = 0,
            /// <summary>1:納期</summary>
            DeliveryDate = 1,
            /// <summary>2:価格</summary>
            Price = 2
        }

        /// <summary>
        /// 自動回答区分の名称を取得します。
        /// </summary>
        /// <param name="scmPrtSetting">SCM品目設定</param>
        /// <returns></returns>
        public static string GetAutoAnswerDivName(SCMPrtSetting scmPrtSetting)
        {
            if (scmPrtSetting == null) return string.Empty;

            switch (scmPrtSetting.AutoAnswerDiv)
            {
                case (int)AutoAnswerDiv.None:
                    return "しない";
                case (int)AutoAnswerDiv.DeliveryDate:
                    return "納期";
                case (int)AutoAnswerDiv.Price:
                    return "価格";
                default:
                    return string.Empty;
            }
        }

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SCMPrtSettingAgent() { }

        #endregion // </Constructor>

        /// <summary>
        /// 検索します。
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>検索結果(SCM品目設定マスタのレコードリスト)</returns>
        public IList<SCMPrtSetting> Find(
            GoodsUnitData goodsUnitData,
            int customerCode
        )
        {
            // 1パラ目
            SCMPrtSettingOrder searchingCondition = new SCMPrtSettingOrder();
            {
                // 企業コード
                searchingCondition.EnterpriseCode = goodsUnitData.EnterpriseCode;

                // 拠点コード
                if (customerCode <= 0)
                {
                    searchingCondition.SectionCode = goodsUnitData.SectionCode;
                }

                // 得意先コード
                searchingCondition.St_CustomerCode = customerCode;
                searchingCondition.Ed_CustomerCode = customerCode;

                // 商品中分類コード
                searchingCondition.St_GoodsMGroup = goodsUnitData.GoodsMGroup;
                searchingCondition.Ed_GoodsMGroup = goodsUnitData.GoodsMGroup;

                // BL商品コード
                searchingCondition.St_BLGoodsCode = goodsUnitData.BLGoodsCode;
                searchingCondition.Ed_BLGoodsCode = goodsUnitData.BLGoodsCode;

                // 商品メーカーコード
                searchingCondition.St_GoodsMakerCd = goodsUnitData.GoodsMakerCd;
                searchingCondition.Ed_GoodsMakerCd = goodsUnitData.GoodsMakerCd;

                // 商品番号
                searchingCondition.GoodsNo = goodsUnitData.GoodsNo;

                // BLグループコード
                searchingCondition.St_BLGroupCode = goodsUnitData.BLGroupCode;
                searchingCondition.Ed_BLGroupCode = goodsUnitData.BLGroupCode;
            }

            // 2パラ目
            List<SCMPrtSetting> searchedList = null;

            // 3パラ目
            string msg = string.Empty;

            // 検索
            RealAccesser.EnterpriseCode = goodsUnitData.EnterpriseCode;
            RealAccesser.SectionCode    = goodsUnitData.SectionCode;
            int status = RealAccesser.Search(searchingCondition, out searchedList, out msg);
            if (searchedList == null && customerCode > 0)
            {
                // 得意先コードで検索していた場合、拠点コードで再検索
                searchingCondition.St_CustomerCode = 0;
                searchingCondition.Ed_CustomerCode = 0;
                searchingCondition.SectionCode = goodsUnitData.SectionCode;
                status = RealAccesser.Search(searchingCondition, out searchedList, out msg);
            }

            // TODO:全検索結果をダンプ

            return searchedList ?? new List<SCMPrtSetting>();
        }
    }
}
