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

namespace Broadleaf.Application.UIData
{
    using RecordType    = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork;
    using RecordTypeWeb = Broadleaf.Application.UIData.ScmOdrData;

    /// <summary>
    /// ユーザーDB SCM受注データのラッパークラス（実装）
    /// </summary>
    /// <remarks>
    /// お約束の過不足分(主にISCMOrderHeaderRecordの実装)を実装します。
    /// </remarks>
    public abstract partial class UserSCMOrderHeaderWrapper
    {
        /// <summary>確定日を取得または設定します。</summary>
        /// <remarks>YYYYMMDD     ＰＳＦにて使用する。取引が終息した日。伝票ロックにも使用する。</remarks>
        /// <see cref="ISCMOrderHeaderRecord"/>
        public DateTime JudgementDate
        {
            get { return RealRecord.JudgementDate; }
            set { RealRecord.JudgementDate = value; }
        }

        /// <summary>問合せ日を取得または設定します。</summary>
        /// <remarks>YYYYMMDD</remarks>
        /// <see cref="ISCMOrderHeaderRecord"/>
        public DateTime InquiryDate
        {
            get { return RealRecord.InquiryDate; }
            set { RealRecord.InquiryDate = value; }
        }

        /// <summary>受信日時を取得または設定します。</summary>
        /// <remarks>（DateTime:精度は100ナノ秒）</remarks>
        /// <see cref="ISCMOrderHeaderRecord"/>
        public DateTime ReceiveDateTime
        {
            get { return RealRecord.ReceiveDateTime; }
            set { RealRecord.ReceiveDateTime = value; }
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
                csv.Append(EnterpriseCode).Append(SCMEntityUtil.COMMA);
                csv.Append(FileHeaderGuid).Append(SCMEntityUtil.COMMA);
                csv.Append(UpdEmployeeCode).Append(SCMEntityUtil.COMMA);
                csv.Append(UpdAssemblyId1).Append(SCMEntityUtil.COMMA);
                csv.Append(UpdAssemblyId2).Append(SCMEntityUtil.COMMA);
                csv.Append(LogicalDeleteCode).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOriginalEpCd.Trim()).Append(SCMEntityUtil.COMMA);//@@@@20230303
                csv.Append(InqOriginalSecCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOtherEpCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOtherSecCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InquiryNumber).Append(SCMEntityUtil.COMMA);
                csv.Append(CustomerCode).Append(SCMEntityUtil.COMMA);
                csv.Append(UpdateDate).Append(SCMEntityUtil.COMMA);
                csv.Append(UpdateTime).Append(SCMEntityUtil.COMMA);
                csv.Append(AnswerDivCd).Append(SCMEntityUtil.COMMA);
                csv.Append(JudgementDate).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOrdNote).Append(SCMEntityUtil.COMMA);
                csv.Append(AppendingFile).Append(SCMEntityUtil.COMMA);
                csv.Append(AppendingFileNm).Append(SCMEntityUtil.COMMA);
                csv.Append(InqEmployeeCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InqEmployeeNm).Append(SCMEntityUtil.COMMA);
                csv.Append(AnsEmployeeCd).Append(SCMEntityUtil.COMMA);
                csv.Append(AnsEmployeeNm).Append(SCMEntityUtil.COMMA);
                csv.Append(InquiryDate).Append(SCMEntityUtil.COMMA);
                csv.Append(AcptAnOdrStatus).Append(SCMEntityUtil.COMMA);
                csv.Append(SalesSlipNum).Append(SCMEntityUtil.COMMA);
                csv.Append(SalesTotalTaxInc).Append(SCMEntityUtil.COMMA);
                csv.Append(SalesSubtotalTax).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOrdDivCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOrdAnsDivCd).Append(SCMEntityUtil.COMMA);
                csv.Append(ReceiveDateTime).Append(SCMEntityUtil.COMMA);
                // --- ADD 2013/06/24 Y.Wakita ---------->>>>>
                csv.Append(TabUseDiv).Append(SCMEntityUtil.COMMA);
                // --- ADD 2013/06/24 Y.Wakita ----------<<<<<
                // DEL 2010/06/17 テーブルのレイアウト変更 ---------->>>>>
                //csv.Append(AnswerCreateDiv);
                // DEL 2010/06/17 テーブルのレイアウト変更 ----------<<<<<
                // ADD 2010/06/17 テーブルのレイアウト変更 ---------->>>>>
                csv.Append(AnswerCreateDiv).Append(SCMEntityUtil.COMMA);
                csv.Append(CancelDiv).Append(SCMEntityUtil.COMMA);
                // --- UPD m.suzuki 2011/05/23 ---------->>>>>
                //csv.Append(CMTCooprtDiv);
                csv.Append( CMTCooprtDiv ).Append( SCMEntityUtil.COMMA );
                //csv.Append( SfPmCprtInstSlipNo ); // DEL 2011/08/10
                // --- UPD m.suzuki 2011/05/23 ----------<<<<<
                // ADD 2010/06/17 テーブルのレイアウト変更 ----------<<<<<
                // ADD 2013/05/24 SCM障害№10537対応 ---------------------------------->>>>>
                csv.Append(CarMngCode).Append(SCMEntityUtil.COMMA);
                // ADD 2013/05/24 SCM障害№10537対応 ----------------------------------<<<<<
                csv.Append( SfPmCprtInstSlipNo ).Append(SCMEntityUtil.COMMA); // ADD 2011/08/10
                csv.Append(AcceptOrOrderKind); // ADD 2011/08/10

            }
            return csv.ToString();
        }
    }
}
