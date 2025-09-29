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
// 作 成 日  2009/06/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/10/25  修正内容 : 201311XX配信予定システムテスト障害№13,14対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/01/30  修正内容 : Redmine#41771 障害№13対応
//----------------------------------------------------------------------------//
using System;

using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Agent
{
    /// <summary>
    /// 税率設定マスタのアクセスクラスの代理人クラス
    /// </summary>
    public sealed class TaxRateSetAgent
    {
        #region <税率設定情報/>

        /// <summary>税率設定情報</summary>
        private readonly TaxRateSet _taxRateSetInfo;
        /// <summary>
        /// 税率設定情報を取得します。
        /// </summary>
        /// <value>税率設定情報</value>
        private TaxRateSet TaxRateSetInfo { get { return _taxRateSetInfo; } }
        //2012/04/12 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private static TaxRateSet taxRateSet = null;
        //2012/04/12 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2014/01/30 Redmine#41771-障害№13対応 ---------------------------------->>>>>
        /// <summary>税率判定日付</summary>
        private DateTime _taxRateDate;
        /// <summary>
        /// 税率判定日付
        /// </summary>
        public DateTime TaxRateDate
        {
            get { return _taxRateDate; }
            set { _taxRateDate = value; }
        }

        /// <summary>キャンセル区分</summary>
        private short _cancelDiv;
        /// <summary>
        ///  キャンセル区分
        /// </summary>
        public short CancelDiv
        {
            get { return _cancelDiv; }
            set { _cancelDiv = value; }
        }
        // ADD 2014/01/30 Redmine#41771-障害№13対応 ----------------------------------<<<<<

        #endregion  // <税率設定情報/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        public TaxRateSetAgent(string enterpriseCode)
        {
            _taxRateSetInfo = GetTaxRateSet(enterpriseCode);
        }

        /// <summary>
        /// 税率設定情報を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>税率設定情報</returns>
        private static TaxRateSet GetTaxRateSet(string enterpriseCode)
        {
            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();
            {
                //2012/04/12 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //TaxRateSet taxRateSet = null;
                if (taxRateSet == null)
                {
                //2012/04/12 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    int status = taxRateSetAcs.Read(out taxRateSet, enterpriseCode, 0);
                //2012/04/12 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                }
                //2012/04/12 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                if (taxRateSet == null)
                {
                    taxRateSet = new TaxRateSet();
                }
                return taxRateSet;
            }
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// 今の税率を取得します。
        /// </summary>
        /// <value>今の税率</value>
        public double TaxRateOfNow
        {
            get
            {
                return GetTaxRate(TaxRateSetInfo, DateTime.Now);
            }
        }

        // ADD 2014/01/30 Redmine#41771-障害№13対応 ---------------------------------------->>>>>
        /// <summary>
        /// 伝票日付による税率を取得します。
        /// </summary>
        /// <value>今の税率</value>
        public double TaxRateOfSlesDate
        {
            get
            {
                // 伝票日付未設定時は税率ゼロを設定
                if (_taxRateDate == DateTime.MinValue) return 0;

                return GetTaxRate(TaxRateSetInfo, _taxRateDate);
            }
        }
        // ADD 2014/01/30 Redmine#41771-障害№13対応 ----------------------------------------<<<<<

        // ADD 2013/10/25 201311XX配信予定システムテスト障害№13,14対応 -------------------------------->>>>> 
        /// <summary>
        /// 消費税転嫁方式を取得します。
        /// </summary>
        /// <value>今の税率</value>
        public int ConsTaxLayMethod
        {
            get
            {
                return TaxRateSetInfo.ConsTaxLayMethod;
            }
        }
        // ADD 2013/10/25 201311XX配信予定システムテスト障害№13,14対応 --------------------------------<<<<< 

        /// <summary>
        /// 税率を取得します。
        /// </summary>
        /// <param name="taxRateSet">税率設定情報</param>
        /// <param name="targetDate">税率適用日</param>
        /// <returns>TtlAmntDspRateDivCd</returns>
        private static double GetTaxRate(
            TaxRateSet taxRateSet,
            DateTime targetDate
        )
        {
            return TaxRateSetAcs.GetTaxRate(taxRateSet, targetDate);
        }


    }
}
