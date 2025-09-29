//****************************************************************************//
// システム         : 回答送信処理
// プログラム名称   : 回答送信処理アクセス
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
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = CustomerInfoAcs;
    using RecordType        = CustomerInfo;

    /// <summary>
    /// 得意先マスタのアクセスクラスの代理人クラス
    /// </summary>
    public sealed class CustomerAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        /// <summary>ログ用の名称</summary>
        private const string MY_NAME = "CustomerAgent";

        /// <summary>
        /// オンライン種別区分列挙型
        /// </summary>
        public enum OnlineKindDiv : int
        {
            /// <summary>0:なし</summary>
            None = 0,
            /// <summary>10:SCM</summary>
            SCM = 10,
            /// <summary>20:TSP.NS</summary>
            TSPNS = 20,
            /// <summary>30:TSP.NSインライン</summary>
            TSPNSinline = 30,
            /// <summary>40:TSPメール</summary>
            TSPmail = 40
        }

        #region <得意先情報>

        /// <summary>得意先情報マップ</summary>
        private readonly IDictionary<int, CustomerInfo> _customerInfoMap = new Dictionary<int, CustomerInfo>();
        /// <summary>得意先情報マップを取得します。</summary>
        public IDictionary<int, CustomerInfo> CustomerInfoMap { get { return _customerInfoMap; } }

        /// <summary>得意先掛率グループマップ</summary>
        private readonly IDictionary<int, List<CustRateGroup>> _customerRateGroupMap = new Dictionary<int, List<CustRateGroup>>();
        /// <summary>得意先掛率グループマップを取得します。</summary>
        public IDictionary<int, List<CustRateGroup>> CustomerRateGroupMap { get { return _customerRateGroupMap; } }

        #endregion // </得意先情報>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public CustomerAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// 得意先情報を取得します。
        /// </summary>
        /// <param name="headerRecord">SCM受注データのレコード</param>
        public void TakeCustomerInfo(ISCMOrderHeaderRecord headerRecord)
        {
            TakeCustomerInfo(headerRecord.EnterpriseCode, headerRecord.CustomerCode);
        }

        /// <summary>
        /// 得意先情報を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        public void TakeCustomerInfo(
            string enterpriseCode,
            int customerCode
        )
        {
            #region <Guard Phrase>

            if (CustomerInfoMap.ContainsKey(customerCode))
            {
                return;
            }

            #endregion // </Guard Phrase>

            // 得意先情報
            CustomerInfoMap.Add(
                customerCode,
                FindCustomerInfo(enterpriseCode, customerCode)
            );

            // 得意先掛率グループ
            CustomerRateGroupMap.Add(
                customerCode,
                FindCustomerRateGroup(enterpriseCode, customerCode)
            );
        }

        #region <検索>

        /// <summary>
        /// 得意先情報を検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先情報</returns>
        private CustomerInfo FindCustomerInfo(
            string enterpriseCode,
            int customerCode
        )
        {
            const string METHOD = "FindCustomerInfo";
            const string INDENT = "\t    ";

            CustomerInfo customerInfo = null;
            {
                Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "CustomerInfoAcs.ReadDBData()を呼出中…");
                int status = RealAccesser.ReadDBData(
                    enterpriseCode,
                    customerCode,
                    out customerInfo
                );
                Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "CustomerInfoAcs.ReadDBData()を呼出完了");
            }
            return customerInfo ?? new CustomerInfo();
        }

        /// <summary>
        /// 得意先掛率グループ情報を検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先掛率グループ情報</returns>
        private List<CustRateGroup> FindCustomerRateGroup(
            string enterpriseCode,
            int customerCode
        )
        {
            List<CustRateGroup> foundCustomerRateGroupList = new List<CustRateGroup>();
            {
                if (!customerCode.Equals(0))
                {
                    CustRateGroupAcs customerRateGroupAcs = new CustRateGroupAcs();

                    ArrayList custRateGroupList = null;
                    customerRateGroupAcs.Search(
                        out custRateGroupList,
                        enterpriseCode,
                        customerCode,
                        ConstantManagement.LogicalMode.GetData0
                    );
                    if ((custRateGroupList != null) && (custRateGroupList.Count > 0))
                    {
                        foundCustomerRateGroupList = new List<CustRateGroup>((CustRateGroup[])custRateGroupList.ToArray(typeof(CustRateGroup)));
                    }
                }
            }
            return foundCustomerRateGroupList;
        }

        #endregion // </検索>

        /// <summary>
        /// 売上消費税端数処理コードを取得します。
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>売上消費税端数処理コード</returns>
        public int GetSalesFractionProcCdOfTax(
            int customerCode,
            GoodsUnitData goodsUnitData
        )
        {
            return RealAccesser.GetSalesFractionProcCd(
                goodsUnitData.EnterpriseCode,
                customerCode,
                CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd
            );
        }

        /// <summary>
        /// 売上単価端数処理コードを取得します。
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>売上単価端数処理コード</returns>
        public int GetSalesFractionProcCdOfUnit(
            int customerCode,
            GoodsUnitData goodsUnitData
        )
        {
            return RealAccesser.GetSalesFractionProcCd(
                goodsUnitData.EnterpriseCode,
                customerCode,
                CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd
            );
        }
    }
}
