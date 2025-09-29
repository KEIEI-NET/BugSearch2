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
// 作 成 日  2009/05/29  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/06/17  修正内容 : テーブルのレイアウト変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018　鈴木 正臣
// 作 成 日  2011/05/23  修正内容 : テーブルレイアウト変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/08/10  修正内容 : PCCUOE自動回答対応
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 脇田 靖之
// 作 成 日  2013/06/24  修正内容 : タブレット対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/05/24  修正内容 : SCM障害№10537対応 車両管理コード追加
//----------------------------------------------------------------------------//
using System;
using System.Text;

using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.UIData.WebDB
{
    using RecordType = Broadleaf.Application.UIData.ScmOdrData;

    /// <summary>
    /// Web-DB SCM受発注データのラッパークラス（実装）
    /// </summary>
    /// <remarks>
    /// お約束の過不足分(主にISCMOrderHeaderRecordの実装)を実装します。
    /// </remarks>
    public abstract partial class WebSCMOrderHeaderWrapper
    {
        /// <summary>
        /// 企業コードを取得または設定します。(※Web-DBには存在しません)
        /// </summary>
        /// <remarks>
        /// 問合せ先企業コードを取得または設定します。
        /// </remarks>
        /// <see cref="ISCMOrderHeaderRecord"/>
        public string EnterpriseCode
        {
            get { return RealRecord.InqOtherEpCd; }
            set { RealRecord.InqOtherEpCd = value; }
        }

        /// <summary>得意先コード</summary>
        private int _customerCode = -1;
        /// <summary>
        /// 得意先コードを取得または設定します。(※Web-DBには存在しません)
        /// </summary>
        /// <see cref="ISCMOrderHeaderRecord"/>
        public int CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// <summary>受注ステータス</summary>
        private int _acptAnOdrStatus;
        /// <summary>
        /// 受注ステータスを取得または設定します。(※Web-DBには存在しません)
        /// </summary>
        /// <remarks>10:見積,20:受注,30:売上</remarks>
        /// <see cref="ISCMOrderHeaderRecord"/>
        public int AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// <summary>売上伝票番号</summary>
        private string _salesSlipNum;
        /// <summary>
        /// 売上伝票番号を取得または設定します。(※Web-DBには存在しません)
        /// </summary>
        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
        /// <see cref="ISCMOrderHeaderRecord"/>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// <summary>売上伝票合計(税込み)</summary>
        private long _salesTotalTaxInc;
        /// <summary>
        /// 売上伝票合計(税込み)を取得または設定します。(※Web-DBには存在しません)
        /// </summary>
        /// <remarks>売上正価金額+売上値引金額計(税抜き)+売上金額消費税額</remarks>
        /// <see cref="ISCMOrderHeaderRecord"/>
        public long SalesTotalTaxInc
        {
            get { return _salesTotalTaxInc; }
            set { _salesTotalTaxInc = value; }
        }

        /// <summary>
        /// キーに変換します。
        /// </summary>
        /// <returns>キー</returns>
        /// <see cref="ISCMOrderHeaderRecord"/>
        public string ToKey()
        {
            return SCMEntityUtil.GetHeaderRecordKey(this);
        }

        /// <summary>
        /// SCM受注データの関連キーに変換します。
        /// </summary>
        /// <returns>SCM受注データの関連キー</returns>
        /// <see cref="ISCMOrderHeaderRecord"/>
        public string ToRelationKey()
        {
            return SCMEntityUtil.GetRelationKey(this);
        }

        /// <summary>
        /// CSVに変換します。
        /// </summary>
        /// <returns>CSV</returns>
        /// <see cref="ISCMOrderHeaderRecord"/>
        public string ToCSV()
        {
            StringBuilder csv = new StringBuilder();
            {
                csv.Append(CreateDateTime).Append(SCMEntityUtil.COMMA);
                csv.Append(UpdateDateTime).Append(SCMEntityUtil.COMMA);
                csv.Append(LogicalDeleteCode).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOriginalEpCd.Trim()).Append(SCMEntityUtil.COMMA);//@@@@20230303
                csv.Append(InqOriginalSecCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOtherEpCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOtherSecCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InquiryNumber).Append(SCMEntityUtil.COMMA);
                csv.Append(UpdateDate).Append(SCMEntityUtil.COMMA);
                csv.Append(UpdateTime).Append(SCMEntityUtil.COMMA);
                csv.Append(AnswerDivCd).Append(SCMEntityUtil.COMMA);
                csv.Append(JudgementDate).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOrdNote).Append(SCMEntityUtil.COMMA);
                csv.Append(InqEmployeeCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InqEmployeeNm).Append(SCMEntityUtil.COMMA);
                csv.Append(AnsEmployeeCd).Append(SCMEntityUtil.COMMA);
                csv.Append(AnsEmployeeNm).Append(SCMEntityUtil.COMMA);
                csv.Append(InquiryDate).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOrdDivCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOrdAnsDivCd).Append(SCMEntityUtil.COMMA);
                csv.Append(ReceiveDateTime).Append(SCMEntityUtil.COMMA);
                // --- ADD 2013/06/24 Y.Wakita ---------->>>>>
                csv.Append(TabUseDiv).Append(SCMEntityUtil.COMMA);
                // --- ADD 2013/06/24 Y.Wakita ----------<<<<<
                // DEL 2010/06/17 テーブルのレイアウト変更 ---------->>>>>
                //csv.Append(LatestDiscCode);
                // DEL 2010/06/17 テーブルのレイアウト変更 ----------<<<<<
                // ADD 2010/06/17 テーブルのレイアウト変更 ---------->>>>>
                csv.Append(LatestDiscCode).Append(SCMEntityUtil.COMMA);
                csv.Append(CancelDiv).Append(SCMEntityUtil.COMMA);
                // --- UPD m.suzuki 2011/05/23 ---------->>>>>
                // ADD 2013/05/24 SCM障害№10537対応 ---------------------------------->>>>>
                csv.Append(CarMngCode).Append(SCMEntityUtil.COMMA);
                // ADD 2013/05/24 SCM障害№10537対応 ----------------------------------<<<<<
                //csv.Append(CMTCooprtDiv);
                csv.Append( CMTCooprtDiv ).Append( SCMEntityUtil.COMMA );
                csv.Append( SfPmCprtInstSlipNo );
                // --- UPD m.suzuki 2011/05/23 ----------<<<<<
                // ADD 2010/06/17 テーブルのレイアウト変更 ----------<<<<<
                csv.Append(AcceptOrOrderKind); // ADD 2011/08/10
            }
            return csv.ToString();
        }
    }
}
