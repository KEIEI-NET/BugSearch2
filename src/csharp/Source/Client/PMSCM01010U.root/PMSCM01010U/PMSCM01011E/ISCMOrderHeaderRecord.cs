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
// 作 成 日  2009/05/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/05/26  修正内容 : テーブルレイアウト変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434　工藤 恵優
// 作 成 日  2010/06/30  修正内容 : 「回答作成区分」を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018　鈴木 正臣
// 作 成 日  2011/05/23  修正内容 : テーブルレイアウト変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/08/10  修正内容 : PCCUOE自動回答
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 脇田 靖之
// 作 成 日  2013/06/24  修正内容 : タブレット対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/05/24  修正内容 : SCM障害№10537対応 車両管理コード追加
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2014/12/19  修正内容 : SCM高速化 PMNS対応 自動回答方式の追加
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// SCM受注データのレコードインターフェース
    /// </summary>
    public interface ISCMOrderHeaderRecord
    {
        /// <summary>
        /// 問合せ元企業コードを取得または設定します。
        /// </summary>
        string InqOriginalEpCd { get; set; }

        /// <summary>
        /// 問合せ元拠点コードを取得または設定します。
        /// </summary>
        string InqOriginalSecCd { get; set; }

        /// <summary>
        /// 問合せ先企業コードを取得または設定します。
        /// </summary>
        string InqOtherEpCd { get; set; }

        /// <summary>
        /// 問合せ先拠点コードを取得または設定します。
        /// </summary>
        string InqOtherSecCd { get; set; }

        /// <summary>
        /// 問合せ番号を取得または設定します。
        /// </summary>
        long InquiryNumber { get; set; }

        /// <summary>
        /// 更新年月日を取得または設定します。
        /// </summary>
        DateTime UpdateDate { get; set; }

        /// <summary>
        /// 更新時分秒ミリ秒を取得または設定します。
        /// </summary>
        int UpdateTime { get; set; }

        /// <summary>
        /// 回答区分を取得または設定します。
        /// </summary>
        int AnswerDivCd { get; set; }

        /// <summary>
        /// 問合せ・発注種別
        /// </summary>
        string InqOrdNote { get; set; }

        /// <summary>
        /// 回答従業員コードを取得または設定します。
        /// </summary>
        string AnsEmployeeCd { get; set; }

        /// <summary>
        /// 回答従業員名称を取得または設定します。
        /// </summary>
        string AnsEmployeeNm { get; set; }

        /// <summary>
        /// 問合せ日を取得または設定します。
        /// </summary>
        DateTime InquiryDate { get; set; }

        /// <summary>
        /// 問発・回答種別を取得または設定します。
        /// </summary>
        int InqOrdAnsDivCd { get; set; }

        /// <summary>
        /// 受信日時を取得または設定します。
        /// </summary>
        DateTime ReceiveDateTime { get; set; }

        /// <summary>
        /// 企業コードを取得または設定します。
        /// </summary>
        string EnterpriseCode { get; set; }

        /// <summary>
        /// 得意先コードを取得または設定します。
        /// </summary>
        int CustomerCode { get; set; }

        /// <summary>
        /// 問合せ・発注種別を取得または設定します。
        /// </summary>
        int InqOrdDivCd { get; set; }

        /// <summary>
        /// 受注ステータスを取得または設定します。
        /// </summary>
        int AcptAnOdrStatus { get; set; }

        /// <summary>
        /// 売上伝票番号を取得または設定します。
        /// </summary>
        string SalesSlipNum { get; set; }

        /// <summary>
        /// 売上伝票合計(税込み)を取得または設定します。
        /// </summary>
        long SalesTotalTaxInc { get; set; }

        // ADD 2010/06/30 「回答作成区分」を追加 ---------->>>>>
        /// <summary>
        /// 回答作成区分を取得または設定します。
        /// </summary>
        int AnswerCreateDiv { get; set; }
        // ADD 2010/06/30 「回答作成区分」を追加 ----------<<<<<

        // 2010/05/26 Add >>>
        /// <summary>
        /// キャンセル区分を取得または設定します。
        /// </summary>
        short CancelDiv { get;set;}

        /// <summary>
        /// CMT連携区分を取得または設定します。
        /// </summary>
        short CMTCooprtDiv { get;set;}
        // 2010/05/26 Add <<<

        // --- ADD m.suzuki 2011/05/23 ---------->>>>>
        /// <summary>
        /// 確定日を取得または設定します。
        /// </summary>
        DateTime JudgementDate { get;set;}
        /// <summary>
        /// SF-PM連携指示書番号を取得または設定します。
        /// </summary>
        string SfPmCprtInstSlipNo { get;set;}
        // --- ADD m.suzuki 2011/05/23 ----------<<<<<

        // ----- ADD 2011/08/10 ----- >>>>>
        /// <summary>
        /// 受発注種別を取得または設定します。
        /// </summary>
        Int16 AcceptOrOrderKind { get;set;}
        // ----- ADD 2011/08/10 ----- <<<<<

        // --- ADD 2013/06/24 Y.Wakita ---------->>>>>
        /// <summary>
        /// タブレット使用区分を取得または設定します。
        /// </summary>
        int TabUseDiv { get; set; }
        // --- ADD 2013/06/24 Y.Wakita ----------<<<<<
        	
        // ADD 2013/05/24 SCM障害№10537対応 ---------------------------------->>>>>
        /// <summary>
        /// 車両管理コードを取得または設定します。
        /// </summary>
        string CarMngCode { get;set;}
        // ADD 2013/05/24 SCM障害№10537対応 ----------------------------------<<<<<

        // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
        /// <summary>
        /// 自動回答方式を取得または設定します。
        /// </summary>
        Int16 AutoAnsMthd { get; set; }
        // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<

        /// <summary>
        /// キーに変換します。
        /// </summary>
        /// <returns>キー</returns>
        string ToKey();

        /// <summary>
        /// SCM受注データの関連キーに変換します。
        /// </summary>
        /// <returns>SCM受注データの関連キー</returns>
        string ToRelationKey();

        /// <summary>
        /// CSVに変換します。
        /// </summary>
        /// <returns>CSV</returns>
        string ToCSV();
    }
}
