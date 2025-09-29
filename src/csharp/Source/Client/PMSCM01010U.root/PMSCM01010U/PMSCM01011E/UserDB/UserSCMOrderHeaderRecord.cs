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
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/06/24  修正内容 : 「回答作成区分」が「0:自動」の場合、「CMT連携区分」を設定する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018　鈴木 正臣
// 作 成 日  2011/05/23  修正内容 : テーブルレイアウト変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/08/10  修正内容 : PCCUOE自動回答対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/06/07  修正内容 : №10285 WebDBへの変換時、項目入力データの設定追加
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 脇田 靖之
// 作 成 日  2013/06/24  修正内容 : タブレット対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/05/24  修正内容 : SCM障害№10537対応 車両管理コード追加
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 脇田 靖之
// 作 成 日  2013/07/31  修正内容 : 2013/08/09配信 システムテスト障害一覧№15対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2014/12/19  修正内容 : SCM高速化 PMNS対応 自動回答方式の追加
//----------------------------------------------------------------------------//
using System;

using Broadleaf.Application.UIData.Util;
using Broadleaf.Application.UIData.WebDB;

namespace Broadleaf.Application.UIData
{
    using RecordType    = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork;
    using RecordTypeWeb = Broadleaf.Application.UIData.ScmOdrData;

    /// <summary>
    /// ユーザーDB SCM受注データのレコードクラス
    /// </summary>
    public class UserSCMOrderHeaderRecord : UserSCMOrderHeaderWrapper
    {
        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public UserSCMOrderHeaderRecord() : base() { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="realRecord">本物のレコード</param>
        public UserSCMOrderHeaderRecord(RecordType realRecord) : base(realRecord) { }

        #endregion // </Constructor>

        /// <summary>
        /// カスタムコンストラクタ(Web⇒User変換。得意先等は別途設定が必要)
        /// </summary>
        /// <param name="webRecord">SCM受発注データ</param>
        public UserSCMOrderHeaderRecord(WebSCMOrderHeaderRecord webRecord) : base(new RecordType())
        {
            RealRecord.CreateDateTime = webRecord.CreateDateTime; // 作成日時
            RealRecord.UpdateDateTime = webRecord.UpdateDateTime; // 更新日時
            RealRecord.EnterpriseCode = webRecord.EnterpriseCode; // 企業コード
            //RealRecord.FileHeaderGuid = webRecord.FileHeaderGuid; // GUID
            //RealRecord.UpdEmployeeCode = webRecord.UpdEmployeeCode; // 更新従業員コード
            //RealRecord.UpdAssemblyId1 = webRecord.UpdAssemblyId1; // 更新アセンブリID1
            //RealRecord.UpdAssemblyId2 = webRecord.UpdAssemblyId2; // 更新アセンブリID2
            RealRecord.LogicalDeleteCode = webRecord.LogicalDeleteCode; // 論理削除区分
            RealRecord.InqOriginalEpCd = webRecord.InqOriginalEpCd.Trim(); // 問合せ元企業コード//@@@@20230303
            //RealRecord.InqOriginalEpNm = webRecord.InqOriginalEpNm; // 問合せ元企業名称
            RealRecord.InqOriginalSecCd = webRecord.InqOriginalSecCd; // 問合せ元拠点コード
            //RealRecord.InqOriginalSecNm = webRecord.InqOriginalSecNm; // 問合せ元拠点名称
            RealRecord.InqOtherEpCd = webRecord.InqOtherEpCd; // 問合せ先企業コード
            RealRecord.InqOtherSecCd = webRecord.InqOtherSecCd; // 問合せ先拠点コード
            RealRecord.InquiryNumber = webRecord.InquiryNumber; // 問合せ番号
            RealRecord.CustomerCode = webRecord.CustomerCode; // 得意先コード
            RealRecord.UpdateDate = webRecord.UpdateDate; // 更新年月日
            RealRecord.UpdateTime = webRecord.UpdateTime; // 更新時分秒ミリ秒
            RealRecord.AnswerDivCd = webRecord.AnswerDivCd; // 回答区分

            RealRecord.JudgementDate = webRecord.JudgementDate; // 確定日

            RealRecord.InqOrdNote = webRecord.InqOrdNote; // 問合せ・発注備考
            //RealRecord.AppendingFile = webRecord.AppendingFile; // 添付ファイル
            //RealRecord.AppendingFileNm = webRecord.AppendingFileNm; // 添付ファイル名
            RealRecord.InqEmployeeCd = webRecord.InqEmployeeCd; // 問合せ従業員コード
            RealRecord.InqEmployeeNm = webRecord.InqEmployeeNm; // 問合せ従業員名称
            RealRecord.AnsEmployeeCd = webRecord.AnsEmployeeCd; // 回答従業員コード
            RealRecord.AnsEmployeeNm = webRecord.AnsEmployeeNm; // 回答従業員名称

            RealRecord.InquiryDate = webRecord.InquiryDate; // 問合せ日

            RealRecord.AcptAnOdrStatus = webRecord.AcptAnOdrStatus; // 受注ステータス
            RealRecord.SalesSlipNum = webRecord.SalesSlipNum; // 売上伝票番号
            //RealRecord.SalesTotalTaxInc = webRecord.SalesTotalTaxInc; // 売上伝票合計（税込み）
            //RealRecord.SalesSubtotalTax = webRecord.SalesSubtotalTax; // 売上小計（税）
            RealRecord.InqOrdDivCd = webRecord.InqOrdDivCd; // 問合せ・発注種別
            RealRecord.InqOrdAnsDivCd = webRecord.InqOrdAnsDivCd; // 問発・回答種別

            RealRecord.ReceiveDateTime = webRecord.ReceiveDateTime; // 受信日時

            //RealRecord.AnswerCreateDiv = webRecord.AnswerCreateDiv; // 回答作成区分

            // 2010/05/26 Add >>>
            RealRecord.CancelDiv = webRecord.CancelDiv; // キャンセル区分
            RealRecord.CMTCooprtDiv = webRecord.CMTCooprtDiv; // CMT連携区分
            // 2010/05/26 Add <<<
            // --- ADD m.suzuki 2011/05/23 ---------->>>>>
            RealRecord.SfPmCprtInstSlipNo = webRecord.SfPmCprtInstSlipNo; // SF-PM連携指示書番号
            // --- ADD m.suzuki 2011/05/23 ----------<<<<<
            RealRecord.AcceptOrOrderKind = webRecord.AcceptOrOrderKind; // 受発注種別 // ADD 2011/08/10
            // --- ADD 2013/06/24 Y.Wakita ---------->>>>>
            RealRecord.TabUseDiv = webRecord.TabUseDiv;  // タブレット使用区分
            // --- ADD 2013/06/24 Y.Wakita ----------<<<<<
            // ADD 2013/05/24 SCM障害№10537対応 ---------------------------------->>>>>
            RealRecord.CarMngCode = webRecord.CarMngCode; // 車両管理コード
            // ADD 2013/05/24 SCM障害№10537対応 ----------------------------------<<<<<
            // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
            RealRecord.AutoAnsMthd = webRecord.AutoAnsMthd; // 自動回答方式
            // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<
        }

        /// <summary>
        /// コピーコンストラクタ
        /// </summary>
        /// <param name="other">コピー元</param>
        public UserSCMOrderHeaderRecord(UserSCMOrderHeaderRecord other) : base()
        {
            if (other == null || other == this) return;

            RealRecord.EnterpriseCode = other.EnterpriseCode; // 企業コード
            RealRecord.FileHeaderGuid = other.FileHeaderGuid; // GUID
            RealRecord.UpdEmployeeCode = other.UpdEmployeeCode; // 更新従業員コード
            RealRecord.UpdAssemblyId1 = other.UpdAssemblyId1; // 更新アセンブリID1
            RealRecord.UpdAssemblyId2 = other.UpdAssemblyId2; // 更新アセンブリID2
            RealRecord.LogicalDeleteCode = other.LogicalDeleteCode; // 論理削除区分
            RealRecord.InqOriginalEpCd = other.InqOriginalEpCd.Trim(); // 問合せ元企業コード//@@@@20230303
            //RealRecord.InqOriginalEpNm = other.InqOriginalEpNm; // 問合せ元企業名称
            RealRecord.InqOriginalSecCd = other.InqOriginalSecCd; // 問合せ元拠点コード
            //RealRecord.InqOriginalSecNm = other.InqOriginalSecNm; // 問合せ元拠点名称
            RealRecord.InqOtherEpCd = other.InqOtherEpCd; // 問合せ先企業コード
            RealRecord.InqOtherSecCd = other.InqOtherSecCd; // 問合せ先拠点コード
            RealRecord.InquiryNumber = other.InquiryNumber; // 問合せ番号
            RealRecord.CustomerCode = other.CustomerCode; // 得意先コード
            RealRecord.UpdateDate = other.UpdateDate; // 更新年月日
            RealRecord.UpdateTime = other.UpdateTime; // 更新時分秒ミリ秒
            RealRecord.AnswerDivCd = other.AnswerDivCd; // 回答区分

            RealRecord.JudgementDate = other.JudgementDate; // 確定日

            RealRecord.InqOrdNote = other.InqOrdNote; // 問合せ・発注備考
            RealRecord.AppendingFile = other.AppendingFile; // 添付ファイル
            RealRecord.AppendingFileNm = other.AppendingFileNm; // 添付ファイル名
            RealRecord.InqEmployeeCd = other.InqEmployeeCd; // 問合せ従業員コード
            RealRecord.InqEmployeeNm = other.InqEmployeeNm; // 問合せ従業員名称
            RealRecord.AnsEmployeeCd = other.AnsEmployeeCd; // 回答従業員コード
            RealRecord.AnsEmployeeNm = other.AnsEmployeeNm; // 回答従業員名称

            RealRecord.InquiryDate = other.InquiryDate; // 問合せ日

            RealRecord.AcptAnOdrStatus = other.AcptAnOdrStatus; // 受注ステータス
            RealRecord.SalesSlipNum = other.SalesSlipNum; // 売上伝票番号
            RealRecord.SalesTotalTaxInc = other.SalesTotalTaxInc; // 売上伝票合計（税込み）
            RealRecord.SalesSubtotalTax = other.SalesSubtotalTax; // 売上小計（税）
            RealRecord.InqOrdDivCd = other.InqOrdDivCd; // 問合せ・発注種別
            RealRecord.InqOrdAnsDivCd = other.InqOrdAnsDivCd; // 問発・回答種別

            RealRecord.ReceiveDateTime = other.ReceiveDateTime; // 受信日時

            RealRecord.AnswerCreateDiv = other.AnswerCreateDiv; // 回答作成区分

            // 2010/05/26 Add >>>
            RealRecord.CancelDiv = other.CancelDiv; // キャンセル区分
            RealRecord.CMTCooprtDiv = other.CMTCooprtDiv; // CMT連携区分
            // 2010/05/26 Add <<<

            // --- ADD m.suzuki 2011/05/23 ---------->>>>>
            RealRecord.SfPmCprtInstSlipNo = other.SfPmCprtInstSlipNo; // SF-PM連携指示書番号
            // --- ADD m.suzuki 2011/05/23 ----------<<<<<
            RealRecord.AcceptOrOrderKind = other.AcceptOrOrderKind; // 受発注種別 // ADD 2011/08/10
            // --- ADD 2013/06/24 Y.Wakita ---------->>>>>
            RealRecord.TabUseDiv = other.TabUseDiv;  // タブレット使用区分
            // --- ADD 2013/06/24 Y.Wakita ----------<<<<<
            // ADD 2013/05/24 SCM障害№10537対応 ---------------------------------->>>>>
            RealRecord.CarMngCode = other.CarMngCode; // 車両管理コード
            // ADD 2013/05/24 SCM障害№10537対応 ----------------------------------<<<<<
            // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
            RealRecord.AutoAnsMthd = other.AutoAnsMthd; // 自動回答方式
            // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<
        }

        #region <User⇒WEB変換>
        /// <summary>
        /// UserDBからWebDBへの詰替え処理
        /// </summary>
        /// <returns>SCM受発注データ</returns>
        public WebSCMOrderHeaderRecord CopyToWebSCMOrderHeaderRecord()
        {
            RecordTypeWeb webRecord = new RecordTypeWeb();
            {
                //webRecord.EnterpriseCode = RealRecord.EnterpriseCode; // 企業コード
                //webRecord.FileHeaderGuid = RealRecord.FileHeaderGuid; // GUID
                //webRecord.UpdEmployeeCode = RealRecord.UpdEmployeeCode; // 更新従業員コード
                //webRecord.UpdAssemblyId1 = RealRecord.UpdAssemblyId1; // 更新アセンブリID1
                //webRecord.UpdAssemblyId2 = RealRecord.UpdAssemblyId2; // 更新アセンブリID2
                webRecord.LogicalDeleteCode = RealRecord.LogicalDeleteCode; // 論理削除区分
                webRecord.InqOriginalEpCd = RealRecord.InqOriginalEpCd.Trim(); // 問合せ元企業コード//@@@@20230303
                //webRecord.InqOriginalEpNm = RealRecord.InqOriginalEpNm; // 問合せ元企業名称
                webRecord.InqOriginalSecCd = RealRecord.InqOriginalSecCd; // 問合せ元拠点コード
                //webRecord.InqOriginalSecNm = RealRecord.InqOriginalSecNm; // 問合せ元拠点名称
                webRecord.InqOtherEpCd = RealRecord.InqOtherEpCd; // 問合せ先企業コード
                webRecord.InqOtherSecCd = RealRecord.InqOtherSecCd; // 問合せ先拠点コード
                webRecord.InquiryNumber = RealRecord.InquiryNumber; // 問合せ番号
                //webRecord.CustomerCode = RealRecord.CustomerCode; // 得意先コード
                webRecord.UpdateDate = RealRecord.UpdateDate; // 更新年月日
                webRecord.UpdateTime = RealRecord.UpdateTime; // 更新時分秒ミリ秒
                webRecord.AnswerDivCd = RealRecord.AnswerDivCd; // 回答区分

                webRecord.JudgementDate = RealRecord.JudgementDate; // 確定日

                webRecord.InqOrdNote = RealRecord.InqOrdNote; // 問合せ・発注備考
                //webRecord.AppendingFile = RealRecord.AppendingFile; // 添付ファイル
                //webRecord.AppendingFileNm = RealRecord.AppendingFileNm; // 添付ファイル名
                webRecord.InqEmployeeCd = RealRecord.InqEmployeeCd; // 問合せ従業員コード
                webRecord.InqEmployeeNm = RealRecord.InqEmployeeNm; // 問合せ従業員名称
                webRecord.AnsEmployeeCd = RealRecord.AnsEmployeeCd; // 回答従業員コード
                webRecord.AnsEmployeeNm = RealRecord.AnsEmployeeNm; // 回答従業員名称

                webRecord.InquiryDate = RealRecord.InquiryDate; // 問合せ日

                //webRecord.AcptAnOdrStatus = RealRecord.AcptAnOdrStatus; // 受注ステータス
                //webRecord.SalesSlipNum = RealRecord.SalesSlipNum; // 売上伝票番号
                //webRecord.SalesTotalTaxInc = RealRecord.SalesTotalTaxInc; // 売上伝票合計（税込み）
                //webRecord.SalesSubtotalTax = RealRecord.SalesSubtotalTax; // 売上小計（税）
                webRecord.InqOrdDivCd = RealRecord.InqOrdDivCd; // 問合せ・発注種別
                webRecord.InqOrdAnsDivCd = RealRecord.InqOrdAnsDivCd; // 問発・回答種別

                webRecord.ReceiveDateTime = RealRecord.ReceiveDateTime; // 受信日時

                //webRecord.AnswerCreateDiv = RealRecord.AnswerCreateDiv; // 回答作成区分

                // 2010/05/26 Add >>>
                webRecord.CancelDiv = RealRecord.CancelDiv; // キャンセル区分
                webRecord.CMTCooprtDiv = RealRecord.CMTCooprtDiv; // CMT連携区分
                // 2010/05/26 Add <<<

                // --- ADD m.suzuki 2011/05/23 ---------->>>>>
                webRecord.SfPmCprtInstSlipNo = RealRecord.SfPmCprtInstSlipNo; // SF-PM連携指示書番号
                // --- ADD m.suzuki 2011/05/23 ----------<<<<<
                webRecord.AcceptOrOrderKind = RealRecord.AcceptOrOrderKind; // 受発注種別 // ADD 2011/08/10
                // ADD 2012/06/07 --------------------------------------->>>>>
                webRecord.DataInputSystem = 10; // 項目データ入力システム 10:PM
                // ADD 2012/06/07 ---------------------------------------<<<<<
                // --- UPD 2013/07/31 Y.Wakita ---------->>>>>
                //// --- ADD 2013/06/24 Y.Wakita ---------->>>>>
                //webRecord.TabUseDiv = webRecord.TabUseDiv;  // タブレット使用区分
                //// --- ADD 2013/06/24 Y.Wakita ----------<<<<<
                webRecord.TabUseDiv = RealRecord.TabUseDiv; // タブレット使用区分
                // --- UPD 2013/07/31 Y.Wakita ----------<<<<<
                // ADD 2013/05/24 SCM障害№10537対応 ---------------------------------->>>>>
                webRecord.CarMngCode = RealRecord.CarMngCode; // 車両管理コード
                // ADD 2013/05/24 SCM障害№10537対応 ----------------------------------<<<<<
                // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
                webRecord.AutoAnsMthd = RealRecord.AutoAnsMthd; // 自動回答方式
                // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<
            }
            return new WebSCMOrderHeaderRecord(webRecord);
        }
        #endregion

        // ADD 2010/06/24 「回答作成区分」が「0:自動」の場合、「CMT連携区分」を設定する ---------->>>>>
        #region <34.回答作成区分>

        /// <summary>回答作成区分を取得または設定します。</summary>
        /// <remarks>0:自動, 1:手動（Web）, 2:手動（その他）</remarks>
        public override int AnswerCreateDiv
        {
            get { return RealRecord.AnswerCreateDiv; }
            set
            {
                RealRecord.AnswerCreateDiv = value;
                if (RealRecord.AnswerCreateDiv.Equals((int)AnswerCreateDivValue.Auto))
                {
                    BackupCMTCooprtDiv = CMTCooprtDiv;

                    // 「回答作成区分」が「0:自動」
                    // 「問合・発注種別」が「1:問合せ」の場合、「CMT連携区分」は「11:問合せ(自動)」
                    // 「問合・発注種別」が「2:発注」の場合、「CMT連携区分」は「12:発注(自動)」
                    RealRecord.CMTCooprtDiv = RealRecord.InqOrdDivCd.Equals((int)InqOrdDivCdValue.Ordering)
                        ?
                    (short)CMTCooprtDivValue.OrderedAutomatically : (short)CMTCooprtDivValue.MadeInquiriesAutomatically;
                }
                else
                {
                    // 「回答作成区分」が「0:自動」以外は元に戻す
                    if (BackupCMTCooprtDiv > 0)
                    {
                        RealRecord.CMTCooprtDiv = BackupCMTCooprtDiv;
                    }
                }
            }
        }

        /// <summary>CMT連携区分のバックアップ</summary>
        private short _backupCMTCooprtDiv = -1;
        /// <summary>CMT連携区分のバックアップを取得または設定します。</summary>
        private short BackupCMTCooprtDiv
        {
            get { return _backupCMTCooprtDiv; }
            set { _backupCMTCooprtDiv = value; }
        }

        #endregion </34.回答作成区分>
        // ADD 2010/06/24 「回答作成区分」が「0:自動」の場合、「CMT連携区分」を設定する ----------<<<<<
    }
}
