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
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2015/01/27  修正内容 : SCM高速化Redmine#39対応
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.UIData.WebDB
{
    using RecordType = Broadleaf.Application.UIData.ScmOdrData;

    /// <summary>
    /// Web-DB SCM受発注データのラッパークラス（お約束）
    /// </summary>
    public abstract partial class WebSCMOrderHeaderWrapper : ISCMOrderHeaderRecord
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
        protected WebSCMOrderHeaderWrapper() : this(new RecordType()) { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="realRecord">本物のレコード</param>
        protected WebSCMOrderHeaderWrapper(RecordType realRecord)
        {
            _realRecord = realRecord;
        }

        #endregion // </Constructor>

        /// <summary>
        /// ディープコピーを行います。
        /// </summary>
        /// <returns>コピーインスタンス</returns>
        public object Clone()
        {
            return RealRecord.Clone();
        }

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

        #region <03.論理削除区分>

        /// <summary>論理削除区分を取得または設定します。</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        public int LogicalDeleteCode
        {
            get { return RealRecord.LogicalDeleteCode; }
            set { RealRecord.LogicalDeleteCode = value; }
        }

        #endregion </03.論理削除区分>

        #region <04.問合せ元企業コード>

        /// <summary>問合せ元企業コードを取得または設定します。</summary>
        public string InqOriginalEpCd
        {
            get { return RealRecord.InqOriginalEpCd; }
            set { RealRecord.InqOriginalEpCd = value; }
        }

        #endregion </04.問合せ元企業コード>

        #region <05.問合せ元拠点コード>

        /// <summary>問合せ元拠点コードを取得または設定します。</summary>
        public string InqOriginalSecCd
        {
            get { return RealRecord.InqOriginalSecCd; }
            set { RealRecord.InqOriginalSecCd = value; }
        }

        #endregion </05.問合せ元拠点コード>

        #region <06.問合せ先企業コード>

        /// <summary>問合せ先企業コードを取得または設定します。</summary>
        public string InqOtherEpCd
        {
            get { return RealRecord.InqOtherEpCd; }
            set { RealRecord.InqOtherEpCd = value; }
        }

        #endregion </06.問合せ先企業コード>

        #region <07.問合せ先拠点コード>

        /// <summary>問合せ先拠点コードを取得または設定します。</summary>
        public string InqOtherSecCd
        {
            get { return RealRecord.InqOtherSecCd; }
            set { RealRecord.InqOtherSecCd = value; }
        }

        #endregion </07.問合せ先拠点コード>

        #region <08.問合せ番号>

        /// <summary>問合せ番号を取得または設定します。</summary>
        public long InquiryNumber
        {
            get { return RealRecord.InquiryNumber; }
            set { RealRecord.InquiryNumber = value; }
        }

        #endregion </08.問合せ番号>

        #region <09.更新年月日>

        /// <summary>更新年月日を取得または設定します。</summary>
        /// <remarks>YYYYMMDD</remarks>
        public DateTime UpdateDate
        {
            get { return RealRecord.UpdateDate; }
            set { RealRecord.UpdateDate = value; }
        }

        #endregion </09.更新年月日>

        #region <10.更新時分秒ミリ秒>

        /// <summary>更新時分秒ミリ秒を取得または設定します。</summary>
        /// <remarks>HHMMSSXXX</remarks>
        public int UpdateTime
        {
            get { return RealRecord.UpdateTime; }
            set { RealRecord.UpdateTime = value; }
        }

        #endregion </10.更新時分秒ミリ秒>

        #region <11.回答区分>

        /// <summary>回答区分を取得または設定します。</summary>
        /// <remarks>0:アクションなし 1:回答中 10:一部回答 20:回答完了 30:承認 99:キャンセル</remarks>
        public int AnswerDivCd
        {
            get { return RealRecord.AnswerDivCd; }
            set { RealRecord.AnswerDivCd = value; }
        }

        #endregion </11.回答区分>

        #region <12.確定日>

        /// <summary>確定日を取得または設定します。</summary>
        /// <remarks>YYYYMMDD     ＰＳＦにて使用する。取引が終息した日。伝票ロックにも使用する。</remarks>
        public DateTime JudgementDate
        {
            get { return RealRecord.JudgementDate; }
            set { RealRecord.JudgementDate = value; }
        }

        #endregion </12.確定日>

        #region <13.問合せ・発注備考>

        /// <summary>問合せ・発注備考を取得または設定します。</summary>
        public string InqOrdNote
        {
            get { return RealRecord.InqOrdNote; }
            set { RealRecord.InqOrdNote = value; }
        }

        #endregion </13.問合せ・発注備考>

        #region <14.問合せ従業員コード>

        /// <summary>問合せ従業員コードを取得または設定します。</summary>
        /// <remarks>問合せした従業員コード</remarks>
        public string InqEmployeeCd
        {
            get { return RealRecord.InqEmployeeCd; }
            set { RealRecord.InqEmployeeCd = value; }
        }

        #endregion </14.問合せ従業員コード>

        #region <15.問合せ従業員名称>

        /// <summary>問合せ従業員名称を取得または設定します。</summary>
        /// <remarks>問合せした従業員名称</remarks>
        public string InqEmployeeNm
        {
            get { return RealRecord.InqEmployeeNm; }
            set { RealRecord.InqEmployeeNm = value; }
        }

        #endregion </15.問合せ従業員名称>

        #region <16.回答従業員コード>

        /// <summary>回答従業員コードを取得または設定します。</summary>
        public string AnsEmployeeCd
        {
            get { return RealRecord.AnsEmployeeCd; }
            set { RealRecord.AnsEmployeeCd = value; }
        }

        #endregion </16.回答従業員コード>

        #region <17.回答従業員名称>

        /// <summary>回答従業員名称を取得または設定します。</summary>
        public string AnsEmployeeNm
        {
            get { return RealRecord.AnsEmployeeNm; }
            set { RealRecord.AnsEmployeeNm = value; }
        }

        #endregion </17.回答従業員名称>

        #region <18.問合せ日>

        /// <summary>問合せ日を取得または設定します。</summary>
        /// <remarks>YYYYMMDD</remarks>
        public DateTime InquiryDate
        {
            get { return RealRecord.InquiryDate; }
            set { RealRecord.InquiryDate = value; }
        }

        #endregion </18.問合せ日>

        #region <19.問合せ・発注種別>

        /// <summary>問合せ・発注種別を取得または設定します。</summary>
        /// <remarks>1:問合せ 2:発注</remarks>
        public int InqOrdDivCd
        {
            get { return RealRecord.InqOrdDivCd; }
            set { RealRecord.InqOrdDivCd = value; }
        }

        #endregion </19.問合せ・発注種別>

        #region <20.問発・回答種別>

        /// <summary>問発・回答種別を取得または設定します。</summary>
        /// <remarks>1:問合せ・発注 2:回答</remarks>
        public int InqOrdAnsDivCd
        {
            get { return RealRecord.InqOrdAnsDivCd; }
            set { RealRecord.InqOrdAnsDivCd = value; }
        }

        #endregion </20.問発・回答種別>

        #region <21.受信日時>

        /// <summary>受信日時を取得または設定します。</summary>
        /// <remarks>（DateTime:精度は100ナノ秒）</remarks>
        public DateTime ReceiveDateTime
        {
            get { return RealRecord.ReceiveDateTime; }
            set { RealRecord.ReceiveDateTime = value; }
        }

        #endregion </21.受信日時>

        #region <22.最新識別区分>

        /// <summary>最新識別区分を取得または設定します。</summary>
        /// <remarks>0:最新データ 1:旧データ</remarks>
        public short LatestDiscCode
        {
            get { return RealRecord.LatestDiscCode; }
            set { RealRecord.LatestDiscCode = value; }
        }

        #endregion </22.最新識別区分>

        // 2010/05/26 Add >>>
        #region <23.キャンセル区分>

        /// <summary>キャンセル区分を取得または設定します。</summary>
        /// <remarks>0:キャンセルなし 1:キャンセルあり</remarks>
        public short CancelDiv
        {
            get { return RealRecord.CancelDiv; }
            set { RealRecord.CancelDiv = value; }
        }

        #endregion </23.キャンセル区分>

        #region <24.CMT連携区分>

        /// <summary>CMT連携区分を取得または設定します。</summary>
        /// <remarks>0:連携なし 1:連携あり</remarks>
        public short CMTCooprtDiv
        {
            get { return RealRecord.CMTCooprtDiv; }
            set { RealRecord.CMTCooprtDiv = value; }
        }

        #endregion </24.CMT連携区分>
        // 2010/05/26 Add <<<

        // ADD 2010/06/30 「回答作成区分」を追加 ---------->>>>>
        private int _answerCreateDiv;
        /// <summary>
        /// 回答作成区分を取得または設定します。
        /// （本物のSCM受発注データには存在しません）
        /// </summary>
        public int AnswerCreateDiv
        {
            get { return _answerCreateDiv; }
            set { _answerCreateDiv = value; }
        }
        // ADD 2010/06/30 「回答作成区分」を追加 ----------<<<<<

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

        // ----- 2011/08/10 ----- >>>>>
        /// public propaty name  :  AcceptOrOrderKind
        /// <summary>受発注種別プロパティ</summary>
        /// <value>0:通常,1:PCC-UOE</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受発注種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 AcceptOrOrderKind
        {
            get { return RealRecord.AcceptOrOrderKind; }
            set { RealRecord.AcceptOrOrderKind = value; }
        }
        // ----- 2011/08/10 ----- <<<<<

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
        /// public propaty name  :  CarMngCode
        /// <summary>車両管理コード</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両管理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarMngCode
        {
            get { return RealRecord.CarMngCode; }
            set { RealRecord.CarMngCode = value; }
        }
        // ADD 2013/05/24 SCM障害№10537対応 ----------------------------------<<<<<

        // ADD 2015/01/27 SCM高速化Redmine#39対応 --------------------------------->>>>>
        /// <summary>
        /// 自動回答方式を取得または設定します。
        /// </summary>
        /// <see cref="ISCMOrderHeaderRecord"/>
        public Int16 AutoAnsMthd
        {
            get { return RealRecord.AutoAnsMthd; }
            set { RealRecord.AutoAnsMthd = value; }
        }
        // ADD 2015/01/27 SCM高速化Redmine#39対応 ---------------------------------<<<<<
	
        #endregion // </Automatic Code>
    }
}
