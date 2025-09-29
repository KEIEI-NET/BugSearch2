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
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/05/26  修正内容 : テーブルレイアウト変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/06/24  修正内容 : 「回答作成区分」が「0:自動」の場合、「CMT連携区分」を設定する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018　鈴木 正臣
// 作 成 日  2011/05/23  修正内容 : テーブルレイアウト変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNS wangqx
// 作 成 日  2011/08/08  修正内容 : PCCUOE自動回答対応
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
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2014/12/19  修正内容 : SCM高速化 PMNS対応 自動回答方式の追加
//----------------------------------------------------------------------------//
using System;

using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.UIData
{
    using RecordType    = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork;
    using RecordTypeWeb = Broadleaf.Application.UIData.ScmOdrData;

    /// <summary>
    /// ユーザーDB SCM受注データのラッパークラス（お約束）
    /// </summary>
    public abstract partial class UserSCMOrderHeaderWrapper : ISCMOrderHeaderRecord
    {
        #region <Override>

        /// <summary>
        /// 等しいか判断します。
        /// </summary>
        /// <param name="obj">オブジェクト</param>
        /// <returns><c>true</c> :等しいです。<br/><c>false</c>:等しくありません。</returns>
        public override bool Equals(object obj)
        {
            return RealRecord.Equals(obj);
        }

        /// <summary>
        /// ハッシュコードを取得します。
        /// </summary>
        /// <returns>ハッシュコード</returns>
        public override int GetHashCode()
        {
            return RealRecord.GetHashCode();
        }

        /// <summary>
        /// 文字列に変換します。
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            return RealRecord.ToString();
        }

        #endregion // </Override>

        #region <Adaptee>

        /// <summary>本物のレコード</summary>
        private readonly RecordType _realRecord;
        /// <summary>本物のレコードを取得します。</summary>
        public RecordType RealRecord { get { return _realRecord; } }

        #endregion // </Adaptee>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        protected UserSCMOrderHeaderWrapper() : this(new RecordType()) { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="realRecord">本物のレコード</param>
        protected UserSCMOrderHeaderWrapper(RecordType realRecord)
        {
            _realRecord = realRecord;
        }

        #endregion // </Constructor>

        #region <Automatic Code>

        #region <01.作成日時>

        /// <summary>作成日時を取得または設定します。</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        public DateTime CreateDateTime
        {
            get { return RealRecord.CreateDateTime; }
            set { RealRecord.CreateDateTime = value; }
        }

        #endregion </01.作成日時>

        #region <02.更新日時>

        /// <summary>更新日時を取得または設定します。</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        public DateTime UpdateDateTime
        {
            get { return RealRecord.UpdateDateTime; }
            set { RealRecord.UpdateDateTime = value; }
        }

        #endregion </02.更新日時>

        #region <03.企業コード>

        /// <summary>企業コードを取得または設定します。</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        public string EnterpriseCode
        {
            get { return RealRecord.EnterpriseCode; }
            set { RealRecord.EnterpriseCode = value; }
        }

        #endregion </03.企業コード>

        #region <04.GUID>

        /// <summary>GUIDを取得または設定します。</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        public Guid FileHeaderGuid
        {
            get { return RealRecord.FileHeaderGuid; }
            set { RealRecord.FileHeaderGuid = value; }
        }

        #endregion </04.GUID>

        #region <05.更新従業員コード>

        /// <summary>更新従業員コードを取得または設定します。</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        public string UpdEmployeeCode
        {
            get { return RealRecord.UpdEmployeeCode; }
            set { RealRecord.UpdEmployeeCode = value; }
        }

        #endregion </05.更新従業員コード>

        #region <06.更新アセンブリID1>

        /// <summary>更新アセンブリID1を取得または設定します。</summary>
        /// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
        public string UpdAssemblyId1
        {
            get { return RealRecord.UpdAssemblyId1; }
            set { RealRecord.UpdAssemblyId1 = value; }
        }

        #endregion </06.更新アセンブリID1>

        #region <07.更新アセンブリID2>

        /// <summary>更新アセンブリID2を取得または設定します。</summary>
        /// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
        public string UpdAssemblyId2
        {
            get { return RealRecord.UpdAssemblyId2; }
            set { RealRecord.UpdAssemblyId2 = value; }
        }

        #endregion </07.更新アセンブリID2>

        #region <08.論理削除区分>

        /// <summary>論理削除区分を取得または設定します。</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        public int LogicalDeleteCode
        {
            get { return RealRecord.LogicalDeleteCode; }
            set { RealRecord.LogicalDeleteCode = value; }
        }

        #endregion </08.論理削除区分>

        #region <09.問合せ元企業コード>

        /// <summary>問合せ元企業コードを取得または設定します。</summary>
        public string InqOriginalEpCd
        {
            get { return RealRecord.InqOriginalEpCd; }
            set { RealRecord.InqOriginalEpCd = value; }
        }

        #endregion </09.問合せ元企業コード>

        #region <10.問合せ元拠点コード>

        /// <summary>問合せ元拠点コードを取得または設定します。</summary>
        public string InqOriginalSecCd
        {
            get { return RealRecord.InqOriginalSecCd; }
            set { RealRecord.InqOriginalSecCd = value; }
        }

        #endregion </10.問合せ元拠点コード>

        #region <11.問合せ先企業コード>

        /// <summary>問合せ先企業コードを取得または設定します。</summary>
        public string InqOtherEpCd
        {
            get { return RealRecord.InqOtherEpCd; }
            set { RealRecord.InqOtherEpCd = value; }
        }

        #endregion </11.問合せ先企業コード>

        #region <12.問合せ先拠点コード>

        /// <summary>問合せ先拠点コードを取得または設定します。</summary>
        public string InqOtherSecCd
        {
            get { return RealRecord.InqOtherSecCd; }
            set { RealRecord.InqOtherSecCd = value; }
        }

        #endregion </12.問合せ先拠点コード>

        #region <13.問合せ番号>

        /// <summary>問合せ番号を取得または設定します。</summary>
        public long InquiryNumber
        {
            get { return RealRecord.InquiryNumber; }
            set { RealRecord.InquiryNumber = value; }
        }

        #endregion </13.問合せ番号>

        #region <14.得意先コード>

        /// <summary>得意先コードを取得または設定します。</summary>
        public int CustomerCode
        {
            get { return RealRecord.CustomerCode; }
            set { RealRecord.CustomerCode = value; }
        }

        #endregion </14.得意先コード>

        #region <15.更新年月日>

        /// <summary>更新年月日を取得または設定します。</summary>
        /// <remarks>YYYYMMDD</remarks>
        public DateTime UpdateDate
        {
            get { return RealRecord.UpdateDate; }
            set { RealRecord.UpdateDate = value; }
        }

        #endregion </15.更新年月日>

        #region <16.更新時分秒ミリ秒>

        /// <summary>更新時分秒ミリ秒を取得または設定します。</summary>
        /// <remarks>HHMMSSXXX</remarks>
        public int UpdateTime
        {
            get { return RealRecord.UpdateTime; }
            set { RealRecord.UpdateTime = value; }
        }

        #endregion </16.更新時分秒ミリ秒>

        #region <17.回答区分>

        /// <summary>回答区分を取得または設定します。</summary>
        /// <remarks>0:アクションなし 10:一部回答 20:回答完了 30:承認 99:キャンセル</remarks>
        public int AnswerDivCd
        {
            get { return RealRecord.AnswerDivCd; }
            set { RealRecord.AnswerDivCd = value; }
        }

        #endregion </17.回答区分>

        #region <18.確定日>

        ///// <summary>確定日を取得または設定します。</summary>
        ///// <remarks>YYYYMMDD     ＰＳＦにて使用する。取引が終息した日。伝票ロックにも使用する。</remarks>
        //public DateTime JudgementDate
        //{
        //    get { return RealRecord.JudgementDate; }
        //    set { RealRecord.JudgementDate = value; }
        //}

        #endregion </18.確定日>

        #region <19.問合せ・発注備考>

        /// <summary>問合せ・発注備考を取得または設定します。</summary>
        public string InqOrdNote
        {
            get { return RealRecord.InqOrdNote; }
            set { RealRecord.InqOrdNote = value; }
        }

        #endregion </19.問合せ・発注備考>

        #region <20.添付ファイル>

        /// <summary>添付ファイルを取得または設定します。</summary>
        public byte[] AppendingFile
        {
            get { return RealRecord.AppendingFile; }
            set { RealRecord.AppendingFile = value; }
        }

        #endregion </20.添付ファイル>

        #region <21.添付ファイル名>

        /// <summary>添付ファイル名を取得または設定します。</summary>
        public string AppendingFileNm
        {
            get { return RealRecord.AppendingFileNm; }
            set { RealRecord.AppendingFileNm = value; }
        }

        #endregion </21.添付ファイル名>

        #region <22.問合せ従業員コード>

        /// <summary>問合せ従業員コードを取得または設定します。</summary>
        /// <remarks>問合せした従業員コード</remarks>
        public string InqEmployeeCd
        {
            get { return RealRecord.InqEmployeeCd; }
            set { RealRecord.InqEmployeeCd = value; }
        }

        #endregion </22.問合せ従業員コード>

        #region <23.問合せ従業員名称>

        /// <summary>問合せ従業員名称を取得または設定します。</summary>
        /// <remarks>問合せした従業員名称</remarks>
        public string InqEmployeeNm
        {
            get { return RealRecord.InqEmployeeNm; }
            set { RealRecord.InqEmployeeNm = value; }
        }

        #endregion </23.問合せ従業員名称>

        #region <24.回答従業員コード>

        /// <summary>回答従業員コードを取得または設定します。</summary>
        public string AnsEmployeeCd
        {
            get { return RealRecord.AnsEmployeeCd; }
            set { RealRecord.AnsEmployeeCd = value; }
        }

        #endregion </24.回答従業員コード>

        #region <25.回答従業員名称>

        /// <summary>回答従業員名称を取得または設定します。</summary>
        public string AnsEmployeeNm
        {
            get { return RealRecord.AnsEmployeeNm; }
            set { RealRecord.AnsEmployeeNm = value; }
        }

        #endregion </25.回答従業員名称>

        #region <26.問合せ日>

        ///// <summary>問合せ日を取得または設定します。</summary>
        ///// <remarks>YYYYMMDD</remarks>
        //public DateTime InquiryDate
        //{
        //    get { return RealRecord.InquiryDate; }
        //    set { RealRecord.InquiryDate = value; }
        //}

        #endregion </26.問合せ日>

        #region <27.受注ステータス>

        /// <summary>受注ステータスを取得または設定します。</summary>
        /// <remarks>10:見積,20:受注,30:売上</remarks>
        public int AcptAnOdrStatus
        {
            get { return RealRecord.AcptAnOdrStatus; }
            set { RealRecord.AcptAnOdrStatus = value; }
        }

        #endregion </27.受注ステータス>

        #region <28.売上伝票番号>

        /// <summary>売上伝票番号を取得または設定します。</summary>
        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
        public string SalesSlipNum
        {
            get { return RealRecord.SalesSlipNum; }
            set { RealRecord.SalesSlipNum = value; }
        }

        #endregion </28.売上伝票番号>

        #region <29.売上伝票合計（税込み）>

        /// <summary>売上伝票合計（税込み）を取得または設定します。</summary>
        /// <remarks>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</remarks>
        public long SalesTotalTaxInc
        {
            get { return RealRecord.SalesTotalTaxInc; }
            set { RealRecord.SalesTotalTaxInc = value; }
        }

        #endregion </29.売上伝票合計（税込み）>

        #region <30.売上小計（税）>

        /// <summary>売上小計（税）を取得または設定します。</summary>
        /// <remarks>値引後の税額（外税分、内税分の合計）</remarks>
        public long SalesSubtotalTax
        {
            get { return RealRecord.SalesSubtotalTax; }
            set { RealRecord.SalesSubtotalTax = value; }
        }

        #endregion </30.売上小計（税）>

        #region <31.問合せ・発注種別>

        /// <summary>問合せ・発注種別を取得または設定します。</summary>
        /// <remarks>1:問合せ 2:発注</remarks>
        public int InqOrdDivCd
        {
            get { return RealRecord.InqOrdDivCd; }
            set { RealRecord.InqOrdDivCd = value; }
        }

        #endregion </31.問合せ・発注種別>

        #region <32.問発・回答種別>

        /// <summary>問発・回答種別を取得または設定します。</summary>
        /// <remarks>1:問合せ・発注 2:回答</remarks>
        public int InqOrdAnsDivCd
        {
            get { return RealRecord.InqOrdAnsDivCd; }
            set { RealRecord.InqOrdAnsDivCd = value; }
        }

        #endregion </32.問発・回答種別>

        #region <33.受信日時>

        ///// <summary>受信日時を取得または設定します。</summary>
        ///// <remarks>（DateTime:精度は100ナノ秒）</remarks>
        //public DateTime ReceiveDateTime
        //{
        //    get { return RealRecord.ReceiveDateTime; }
        //    set { RealRecord.ReceiveDateTime = value; }
        //}

        #endregion </33.受信日時>

        #region <34.回答作成区分>

        /// <summary>回答作成区分を取得または設定します。</summary>
        /// <remarks>0:自動, 1:手動（Web）, 2:手動（その他）</remarks>
        // DEL 2010/06/24 「回答作成区分」が「0:自動」の場合、「CMT連携区分」を設定する ---------->>>>>
        //public int AnswerCreateDiv
        //{
        //    get { return RealRecord.AnswerCreateDiv; }
        //    set { RealRecord.AnswerCreateDiv = value; }
        //}
        // DEL 2010/06/24 「回答作成区分」が「0:自動」の場合、「CMT連携区分」を設定する ----------<<<<<
        // ADD 2010/06/24 「回答作成区分」が「0:自動」の場合、「CMT連携区分」を設定する ---------->>>>>
        public virtual int AnswerCreateDiv
        {
            get { return RealRecord.AnswerCreateDiv; }
            set { RealRecord.AnswerCreateDiv = value; } // セッタで「36.CMT連携区分」も設定するので、UserSCMOrderHeaderRecordクラスでオーバーライド
        }
        // ADD 2010/06/24 「回答作成区分」が「0:自動」の場合、「CMT連携区分」を設定する ----------<<<<<

        #endregion </34.回答作成区分>

        // 2010/05/26 Add >>>
        #region <35.キャンセル区分>

        /// <summary>キャンセル区分を取得または設定します。</summary>
        /// <remarks>0:キャンセルなし 1:キャンセルあり</remarks>
        public short CancelDiv
        {
            get { return RealRecord.CancelDiv; }
            set { RealRecord.CancelDiv = value; }
        }

        #endregion </35.キャンセル区分>

        #region <36.CMT連携区分>

        /// <summary>CMT連携区分を取得または設定します。</summary>
        /// <remarks>0:連携なし 1:連携あり</remarks>
        public short CMTCooprtDiv
        {
            get { return RealRecord.CMTCooprtDiv; }
            set { RealRecord.CMTCooprtDiv = value; }
        }

        #endregion </36.CMT連携区分>
        // 2010/05/26 Add <<<

        // --- ADD m.suzuki 2011/05/23 ---------->>>>>
        /// <summary>
        /// SF-PM連携指示書番号を取得または設定します。
        /// </summary>
        public string SfPmCprtInstSlipNo
        {
            get { return RealRecord.SfPmCprtInstSlipNo; }
            set { RealRecord.SfPmCprtInstSlipNo = value; }
        }
        // --- ADD m.suzuki 2011/05/23 ----------<<<<<

        // --- ADD LDNS wangqx 2011/08/08 ---------->>>>>
        /// <summary>
        /// PM現在庫数
        /// </summary>
        public double PmPrsntCount
        {
            get { return RealRecord.PmPrsntCount; }
            set { RealRecord.PmPrsntCount = value; }
        }
        
        /// <summary>
        /// セット部品メーカーコード
        /// </summary>
        public int SetPartsMkrCd
        {
            get { return RealRecord.SetPartsMkrCd; }
            set { RealRecord.SetPartsMkrCd = value; }
        }

        /// <summary>
        /// セット部品番号
        /// </summary>
        public string SetPartsNumber
        {
            get { return RealRecord.SetPartsNumber; }
            set { RealRecord.SetPartsNumber = value; }
        }

        
        /// <summary>
        /// セット部品親子番号
        /// </summary>
        public int SetPartsMainSubNo
        {
            get { return RealRecord.SetPartsMainSubNo; }
            set { RealRecord.SetPartsMainSubNo = value; }
        }
        // --- ADD LDNS wangqx 2011/08/08 ----------<<<<<
        
        // ----- ADD 2011/08/10 ----- >>>>>
        /// <summary>
        /// 受発注種別を取得または設定します。
        /// </summary>
        public Int16 AcceptOrOrderKind
        {
            get { return RealRecord.AcceptOrOrderKind; }
            set { RealRecord.AcceptOrOrderKind = value; }
        }
        // ----- ADD 2011/08/10 ----- <<<<<

        // --- ADD 2013/06/24 Y.Wakita ---------->>>>>
        /// <summary>
        /// タブレット使用区分
        /// </summary>
        public int TabUseDiv
        {
            get { return RealRecord.TabUseDiv; }
            set { RealRecord.TabUseDiv = value; }
        }
        // --- ADD 2013/06/24 Y.Wakita ----------<<<<<

        // ADD 2013/05/24 SCM障害№10537対応 ---------------------------------->>>>>
        /// <summary>
        /// 車両管理コードを取得または設定します。
        /// </summary>
        public string CarMngCode
        {
            get { return RealRecord.CarMngCode; }
            set { RealRecord.CarMngCode = value; }
        }
        // ADD 2013/05/24 SCM障害№10537対応 ----------------------------------<<<<<

        // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
        /// <summary>
        /// 自動回答方式を取得または設定します
        /// </summary>
        public Int16 AutoAnsMthd
        {
            get { return RealRecord.AutoAnsMthd; }
            set { RealRecord.AutoAnsMthd = value; }
        }
        // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<

        #endregion // </Automatic Code>
    }
}
