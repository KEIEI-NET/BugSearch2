//****************************************************************************//
// システム         : PMTAB 自動回答処理(データ登録)
// プログラム名称   : PMTAB 自動回答処理(データ登録)アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10902622-01 作成担当 : qijh
// 作 成 日  2013/06/29  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Controller
{
    public partial class TabSCMSalesDataMaker
    {
        /// <summary>
        /// 伝票印刷情報データ構造体
        /// </summary>
        public struct SlipPrintInfoValue
        {
            int _acptAnOdrStatus;
            string _salesSlipNum;

            //普通帳票（リモート伝票以外）印刷用フラグ（0：印刷、1：印刷しない）
            int _nomalSalesSlipPrintFlag;

            /// <summary>
            /// 伝票印刷情報データ構造体コンストラクタ
            /// </summary>
            /// <param name="acptAnOdrStatus">受注ステータス</param>
            /// <param name="salesSlipNum">売上伝票番号</param>
            /// <param name="nomalPrintFlag">印刷フラグ</param>
            internal SlipPrintInfoValue(int acptAnOdrStatus, string salesSlipNum, int nomalPrintFlag)
            {
                this._acptAnOdrStatus = acptAnOdrStatus;
                this._salesSlipNum = salesSlipNum;
                this._nomalSalesSlipPrintFlag = nomalPrintFlag;
            }

            /// <summary>受注ステータスプロパティ</summary>
            internal int AcptAnOdrStatus
            {
                get { return this._acptAnOdrStatus; }
                set { this._acptAnOdrStatus = value; }
            }

            /// <summary>伝票番号プロパティ</summary>
            internal string SalesSlipNum
            {
                get { return this._salesSlipNum; }
                set { this._salesSlipNum = value; }
            }

            /// <summary>普通帳票（リモート伝票以外）印刷用フラグプロパティ</summary>
            internal int NomalSalesSlipPrintFlag
            {
                get { return this._nomalSalesSlipPrintFlag; }
                set { this._nomalSalesSlipPrintFlag = value; }
            }
        }

        // --------------- ADD END 2013/07/02 wangl2 FOR Redmine#37585-------->>>>
        /// <summary>
        /// 総額表示方法区分
        /// </summary>
        public enum TotalAmountDispWayCd : int
        {
            /// <summary>総額表示しない</summary>
            NoTotalAmount = 0,
            /// <summary>総額表示する</summary>
            TotalAmount = 1,
        }

        /// <summary>
        /// 受注ステータス
        /// </summary>
        public enum AcptAnOdrStatusState : int
        {
            /// <summary>見積</summary>
            Estimate = 10,
            /// <summary>単価見積</summary>
            UnitPriceEstimate = 15,
            /// <summary>検索見積</summary>
            SearchEstimate = 16,
            /// <summary>受注</summary>
            AcceptAnOrder = 20,
            /// <summary>売上</summary>
            Sales = 30,
            /// <summary>貸出</summary>
            Shipment = 40,
        }

        /// <summary>
        /// 売掛区分
        /// </summary>
        public enum AccRecDivCd : int
        {
            /// <summary>売掛なし</summary>
            NonAccRec = 0,
            /// <summary>売掛</summary>
            AccRec = 1,
        }

        /// <summary>
        /// 商品区分
        /// </summary>
        public enum SalesGoodsCd : int
        {
            /// <summary>商品</summary>
            Goods = 0,
            /// <summary>商品外</summary>
            NonGoods = 1,
            /// <summary>消費税調整</summary>
            ConsTaxAdjust = 2,
            /// <summary>残高調整</summary>
            BalanceAdjust = 3,
            /// <summary>売掛用消費税調整</summary>
            AccRecConsTaxAdjust = 4,
            /// <summary>売掛用残高調整</summary>
            AccRecBalanceAdjust = 5,
        }

        /// <summary>
        /// 自動入金区分
        /// </summary>
        public enum AutoDepositCd : int
        {
            /// <summary>登録しない</summary>
            None = 0,
            /// <summary>登録する</summary>
            Write = 1,
        }
        // --------------- ADD END 2013/07/02 wangl2 FOR Redmine#37585--------<<<<
    }
}
