using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SCMInquiryResultWork
    /// <summary>
    ///                      SCM問い合わせ一覧抽出結果(伝票)クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM問い合わせ一覧抽出結果(伝票)クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    2009/4/13</br>
    /// <br>Genarated Date   :   2009/05/18  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   項目追加</br>
    /// <br>Programmer       :   長内</br>
    /// <br>Date             :   2010/06/17</br>
    /// <br>Update Note      :   項目追加</br>
    /// <br>Programmer       :   久保田</br>
    /// <br>Date             :   2011/05/26</br>
    /// <br>Update Note      :   項目追加</br>
    /// <br>Programmer       :   葛中華</br>
    /// <br>Date             :   2011/11/12</br>
    /// <br>Update Note      :   2012/11/14配信予定 SCM障害№176対応：項目追加</br>
    /// <br>Programmer       :   湯上 千加子</br>
    /// <br>Date             :   2012/10/10</br>
    /// <br>Update Note      :   SCM障害№10384対応：項目追加</br>
    /// <br>Programmer       :   湯上 千加子</br>
    /// <br>Date             :   2013/05/13</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SCMInquiryResultWork
    {
        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先名称</summary>
        private string _customerName = "";

        /// <summary>受注ステータス</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>売上伝票番号</summary>
        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
        private string _salesSlipNum = "";

        /// <summary>問合せ元企業コード</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>問合せ元拠点コード</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>問合せ先企業コード</summary>
        private string _inqOtherEpCd = "";

        /// <summary>問合せ先拠点コード</summary>
        private string _inqOtherSecCd = "";

        /// <summary>問合せ番号</summary>
        private Int64 _inquiryNumber;

        /// <summary>更新年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _updateDate;

        /// <summary>更新時間</summary>
        /// <remarks>HHMMSSXXX</remarks>
        private Int32 _updateTime;

        /// <summary>問合せ・発注種別</summary>
        /// <remarks>1:問合せ 2:発注</remarks>
        private Int32 _inqOrdDivCd;

        /// <summary>回答区分</summary>
        /// <remarks>0:アクションなし 1:回答中 10:一部回答 20:回答完了 30:承認 99:キャンセル</remarks>
        private Int32 _answerDivCd;

        /// <summary>確定日</summary>
        /// <remarks>YYYYMMDD     ＰＳＦにて使用する。取引が終息した日。伝票ロックにも使用する。</remarks>
        private Int32 _judgementDate;

        /// <summary>問合せ・発注備考</summary>
        private string _inqOrdNote = "";

        /// <summary>問合せ従業員コード</summary>
        /// <remarks>問合せした従業員コード</remarks>
        private string _inqEmployeeCd = "";

        /// <summary>問合せ従業員名称</summary>
        /// <remarks>問合せした従業員名称</remarks>
        private string _inqEmployeeNm = "";

        /// <summary>回答従業員コード</summary>
        private string _ansEmployeeCd = "";

        /// <summary>回答従業員名称</summary>
        private string _ansEmployeeNm = "";

        /// <summary>問合せ日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _inquiryDate;

        /// <summary>陸運事務所番号</summary>
        private Int32 _numberPlate1Code;

        /// <summary>陸運事務局名称</summary>
        private string _numberPlate1Name = "";

        /// <summary>車両登録番号（種別）</summary>
        private string _numberPlate2 = "";

        /// <summary>車両登録番号（カナ）</summary>
        private string _numberPlate3 = "";

        /// <summary>車両登録番号（プレート番号）</summary>
        private Int32 _numberPlate4;

        /// <summary>型式指定番号</summary>
        private Int32 _modelDesignationNo;

        /// <summary>類別番号</summary>
        private Int32 _categoryNo;

        /// <summary>メーカーコード</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _makerCode;

        /// <summary>車種コード</summary>
        /// <remarks>車名コード(翼) 1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _modelCode;

        /// <summary>車種サブコード</summary>
        /// <remarks>0～899:提供分,900～ﾕｰｻﾞｰ登録</remarks>
        private Int32 _modelSubCode;

        /// <summary>車種名</summary>
        private string _modelName = "";

        /// <summary>車検証型式</summary>
        private string _carInspectCertModel = "";

        /// <summary>型式（フル型）</summary>
        /// <remarks>フル型式(44桁用)</remarks>
        private string _fullModel = "";

        /// <summary>車台番号</summary>
        private string _frameNo = "";

        /// <summary>車台型式</summary>
        private string _frameModel = "";

        /// <summary>シャシーNo</summary>
        private string _chassisNo = "";

        /// <summary>車両固有番号</summary>
        /// <remarks>ユニークな固定番号</remarks>
        private Int32 _carProperNo;

        /// <summary>生産年式（NUMタイプ）</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _produceTypeOfYearNum;

        /// <summary>問合せ日(車両情報)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _inquiryDate_Car;

        /// <summary>問合せ従業員コード(車両情報)</summary>
        /// <remarks>問合せした従業員コード</remarks>
        private string _inqEmployeeCd_Car = "";

        /// <summary>問合せ従業員名称(車両情報)</summary>
        /// <remarks>問合せした従業員名称</remarks>
        private string _inqEmployeeNm_Car = "";

        /// <summary>発注日(車両情報)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _salesOrderDate_Car;

        /// <summary>発注者従業員コード</summary>
        /// <remarks>発注した従業員コード</remarks>
        private string _salesOrderEmployeeCd = "";

        /// <summary>発注者従業員名称</summary>
        /// <remarks>発注した従業員名称</remarks>
        private string _salesOrderEmployeeNm = "";

        /// <summary>コメント</summary>
        /// <remarks>カタログのコメントや単位・カラーが格納</remarks>
        private string _comment = "";

        /// <summary>リペアカラーコード</summary>
        /// <remarks>カタログの色コード（リペア用が新車時と異なる場合）</remarks>
        private string _rpColorCode = "";

        /// <summary>カラー名称1</summary>
        /// <remarks>画面表示用正式名称</remarks>
        private string _colorName1 = "";

        /// <summary>トリムコード</summary>
        private string _trimCode = "";

        /// <summary>トリム名称</summary>
        private string _trimName = "";

        /// <summary>車両走行距離</summary>
        private Int32 _mileage;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>回答方法</summary>
        private Int32 _awnserMethod;

        /// <summary>売上伝票合計（税込み）</summary>
        /// <remarks>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</remarks>
        private Int64 _salesTotalTaxInc;

        // -- ADD 2010/06/17 ----------->>>
        /// <summary>キャンセル区分</summary>
        /// <remarks>0:キャンセルなし 1:キャンセルあり</remarks>
        private Int16 _cancelDiv;

        /// <summary>CMT連携区分</summary>
        /// <remarks>0:連携なし 1:連携あり</remarks>
        private Int16 _cMTCooprtDiv;
        // -- ADD 2010/06/17 -----------<<<

        //--- ADD 2011/05/26 --->>>
        /// <summary>SF-PM連携指示書番号</summary>
        /// <remarks>得意先注番</remarks>
        private string _sfPmCprtInstSlipNo;
        //--- ADD 2011/05/26 ---<<<

        //--- ADD gezh 2011/11/12 --->>>>>
        /// <summary>連携対象区分</summary>
        private Int16 _cooperationOptionDiv;
        //--- ADD gezh 2011/11/12 ---<<<<<

        //--- ADD 2012/10/10 2012/11/14配信予定 SCM障害№176対応 ---------->>>>>
        /// <summary>回答方法件数（自動回答分）</summary>
        private Int32 _autoAnswerCount;

        /// <summary>回答方法件数（手動回答分）</summary>
        private Int32 _manualAnswerCount;
        //--- ADD 2012/10/10 2012/11/14配信予定 SCM障害№176対応 ----------<<<<<

        // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
        /// <summary>入庫予定日</summary>
        private Int32 _expectedCeDate;
        // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerName
        /// <summary>得意先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>10:見積,20:受注,30:売上,40:出荷</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>売上伝票番号プロパティ</summary>
        /// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>問合せ元企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
        }

        /// public propaty name  :  InqOriginalSecCd
        /// <summary>問合せ元拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOriginalSecCd
        {
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
        }

        /// public propaty name  :  InqOtherEpCd
        /// <summary>問合せ先企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ先企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOtherEpCd
        {
            get { return _inqOtherEpCd; }
            set { _inqOtherEpCd = value; }
        }

        /// public propaty name  :  InqOtherSecCd
        /// <summary>問合せ先拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ先拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOtherSecCd
        {
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
        }

        /// public propaty name  :  InquiryNumber
        /// <summary>問合せ番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 InquiryNumber
        {
            get { return _inquiryNumber; }
            set { _inquiryNumber = value; }
        }

        /// public propaty name  :  UpdateDate
        /// <summary>更新年月日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

        /// public propaty name  :  UpdateTime
        /// <summary>更新時間プロパティ</summary>
        /// <value>HHMMSSXXX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新時間プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateTime
        {
            get { return _updateTime; }
            set { _updateTime = value; }
        }

        /// public propaty name  :  InqOrdDivCd
        /// <summary>問合せ・発注種別プロパティ</summary>
        /// <value>1:問合せ 2:発注</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ・発注種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InqOrdDivCd
        {
            get { return _inqOrdDivCd; }
            set { _inqOrdDivCd = value; }
        }

        /// public propaty name  :  AnswerDivCd
        /// <summary>回答区分プロパティ</summary>
        /// <value>0:アクションなし 1:回答中 10:一部回答 20:回答完了 30:承認 99:キャンセル</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AnswerDivCd
        {
            get { return _answerDivCd; }
            set { _answerDivCd = value; }
        }

        /// public propaty name  :  JudgementDate
        /// <summary>確定日プロパティ</summary>
        /// <value>YYYYMMDD     ＰＳＦにて使用する。取引が終息した日。伝票ロックにも使用する。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   確定日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JudgementDate
        {
            get { return _judgementDate; }
            set { _judgementDate = value; }
        }

        /// public propaty name  :  InqOrdNote
        /// <summary>問合せ・発注備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ・発注備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOrdNote
        {
            get { return _inqOrdNote; }
            set { _inqOrdNote = value; }
        }

        /// public propaty name  :  InqEmployeeCd
        /// <summary>問合せ従業員コードプロパティ</summary>
        /// <value>問合せした従業員コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqEmployeeCd
        {
            get { return _inqEmployeeCd; }
            set { _inqEmployeeCd = value; }
        }

        /// public propaty name  :  InqEmployeeNm
        /// <summary>問合せ従業員名称プロパティ</summary>
        /// <value>問合せした従業員名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqEmployeeNm
        {
            get { return _inqEmployeeNm; }
            set { _inqEmployeeNm = value; }
        }

        /// public propaty name  :  AnsEmployeeCd
        /// <summary>回答従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnsEmployeeCd
        {
            get { return _ansEmployeeCd; }
            set { _ansEmployeeCd = value; }
        }

        /// public propaty name  :  AnsEmployeeNm
        /// <summary>回答従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnsEmployeeNm
        {
            get { return _ansEmployeeNm; }
            set { _ansEmployeeNm = value; }
        }

        /// public propaty name  :  InquiryDate
        /// <summary>問合せ日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InquiryDate
        {
            get { return _inquiryDate; }
            set { _inquiryDate = value; }
        }

        /// public propaty name  :  NumberPlate1Code
        /// <summary>陸運事務所番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   陸運事務所番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NumberPlate1Code
        {
            get { return _numberPlate1Code; }
            set { _numberPlate1Code = value; }
        }

        /// public propaty name  :  NumberPlate1Name
        /// <summary>陸運事務局名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   陸運事務局名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NumberPlate1Name
        {
            get { return _numberPlate1Name; }
            set { _numberPlate1Name = value; }
        }

        /// public propaty name  :  NumberPlate2
        /// <summary>車両登録番号（種別）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両登録番号（種別）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NumberPlate2
        {
            get { return _numberPlate2; }
            set { _numberPlate2 = value; }
        }

        /// public propaty name  :  NumberPlate3
        /// <summary>車両登録番号（カナ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両登録番号（カナ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NumberPlate3
        {
            get { return _numberPlate3; }
            set { _numberPlate3 = value; }
        }

        /// public propaty name  :  NumberPlate4
        /// <summary>車両登録番号（プレート番号）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両登録番号（プレート番号）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NumberPlate4
        {
            get { return _numberPlate4; }
            set { _numberPlate4 = value; }
        }

        /// public propaty name  :  ModelDesignationNo
        /// <summary>型式指定番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式指定番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelDesignationNo
        {
            get { return _modelDesignationNo; }
            set { _modelDesignationNo = value; }
        }

        /// public propaty name  :  CategoryNo
        /// <summary>類別番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   類別番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CategoryNo
        {
            get { return _categoryNo; }
            set { _categoryNo = value; }
        }

        /// public propaty name  :  MakerCode
        /// <summary>メーカーコードプロパティ</summary>
        /// <value>1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public propaty name  :  ModelCode
        /// <summary>車種コードプロパティ</summary>
        /// <value>車名コード(翼) 1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelCode
        {
            get { return _modelCode; }
            set { _modelCode = value; }
        }

        /// public propaty name  :  ModelSubCode
        /// <summary>車種サブコードプロパティ</summary>
        /// <value>0～899:提供分,900～ﾕｰｻﾞｰ登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種サブコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelSubCode
        {
            get { return _modelSubCode; }
            set { _modelSubCode = value; }
        }

        /// public propaty name  :  ModelName
        /// <summary>車種名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelName
        {
            get { return _modelName; }
            set { _modelName = value; }
        }

        /// public propaty name  :  CarInspectCertModel
        /// <summary>車検証型式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車検証型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarInspectCertModel
        {
            get { return _carInspectCertModel; }
            set { _carInspectCertModel = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>型式（フル型）プロパティ</summary>
        /// <value>フル型式(44桁用)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式（フル型）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }

        /// public propaty name  :  FrameNo
        /// <summary>車台番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車台番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrameNo
        {
            get { return _frameNo; }
            set { _frameNo = value; }
        }

        /// public propaty name  :  FrameModel
        /// <summary>車台型式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車台型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrameModel
        {
            get { return _frameModel; }
            set { _frameModel = value; }
        }

        /// public propaty name  :  ChassisNo
        /// <summary>シャシーNoプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シャシーNoプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ChassisNo
        {
            get { return _chassisNo; }
            set { _chassisNo = value; }
        }

        /// public propaty name  :  CarProperNo
        /// <summary>車両固有番号プロパティ</summary>
        /// <value>ユニークな固定番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両固有番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarProperNo
        {
            get { return _carProperNo; }
            set { _carProperNo = value; }
        }

        /// public propaty name  :  ProduceTypeOfYearNum
        /// <summary>生産年式（NUMタイプ）プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   生産年式（NUMタイプ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ProduceTypeOfYearNum
        {
            get { return _produceTypeOfYearNum; }
            set { _produceTypeOfYearNum = value; }
        }

        /// public propaty name  :  InquiryDate_Car
        /// <summary>問合せ日(車両情報)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ日(車両情報)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InquiryDate_Car
        {
            get { return _inquiryDate_Car; }
            set { _inquiryDate_Car = value; }
        }

        /// public propaty name  :  InqEmployeeCd_Car
        /// <summary>問合せ従業員コード(車両情報)プロパティ</summary>
        /// <value>問合せした従業員コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ従業員コード(車両情報)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqEmployeeCd_Car
        {
            get { return _inqEmployeeCd_Car; }
            set { _inqEmployeeCd_Car = value; }
        }

        /// public propaty name  :  InqEmployeeNm_Car
        /// <summary>問合せ従業員名称(車両情報)プロパティ</summary>
        /// <value>問合せした従業員名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ従業員名称(車両情報)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqEmployeeNm_Car
        {
            get { return _inqEmployeeNm_Car; }
            set { _inqEmployeeNm_Car = value; }
        }

        /// public propaty name  :  SalesOrderDate_Car
        /// <summary>発注日(車両情報)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注日(車両情報)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesOrderDate_Car
        {
            get { return _salesOrderDate_Car; }
            set { _salesOrderDate_Car = value; }
        }

        /// public propaty name  :  SalesOrderEmployeeCd
        /// <summary>発注者従業員コードプロパティ</summary>
        /// <value>発注した従業員コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注者従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesOrderEmployeeCd
        {
            get { return _salesOrderEmployeeCd; }
            set { _salesOrderEmployeeCd = value; }
        }

        /// public propaty name  :  SalesOrderEmployeeNm
        /// <summary>発注者従業員名称プロパティ</summary>
        /// <value>発注した従業員名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注者従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesOrderEmployeeNm
        {
            get { return _salesOrderEmployeeNm; }
            set { _salesOrderEmployeeNm = value; }
        }

        /// public propaty name  :  Comment
        /// <summary>コメントプロパティ</summary>
        /// <value>カタログのコメントや単位・カラーが格納</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   コメントプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        /// public propaty name  :  RpColorCode
        /// <summary>リペアカラーコードプロパティ</summary>
        /// <value>カタログの色コード（リペア用が新車時と異なる場合）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   リペアカラーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RpColorCode
        {
            get { return _rpColorCode; }
            set { _rpColorCode = value; }
        }

        /// public propaty name  :  ColorName1
        /// <summary>カラー名称1プロパティ</summary>
        /// <value>画面表示用正式名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カラー名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ColorName1
        {
            get { return _colorName1; }
            set { _colorName1 = value; }
        }

        /// public propaty name  :  TrimCode
        /// <summary>トリムコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   トリムコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TrimCode
        {
            get { return _trimCode; }
            set { _trimCode = value; }
        }

        /// public propaty name  :  TrimName
        /// <summary>トリム名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   トリム名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TrimName
        {
            get { return _trimName; }
            set { _trimName = value; }
        }

        /// public propaty name  :  Mileage
        /// <summary>車両走行距離プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両走行距離プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Mileage
        {
            get { return _mileage; }
            set { _mileage = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  AwnserMethod
        /// <summary>回答方法プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答方法プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AwnserMethod
        {
            get { return _awnserMethod; }
            set { _awnserMethod = value; }
        }

        /// public propaty name  :  SalesTotalTaxInc
        /// <summary>売上伝票合計（税込み）プロパティ</summary>
        /// <value>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票合計（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTotalTaxInc
        {
            get { return _salesTotalTaxInc; }
            set { _salesTotalTaxInc = value; }
        }

        // -- ADD 2010/06/17 ----------------------------->>>
        /// public propaty name  :  CancelDiv
        /// <summary>キャンセル区分プロパティ</summary>
        /// <value>0:キャンセルなし 1:キャンセルあり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンセル区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 CancelDiv
        {
            get { return _cancelDiv; }
            set { _cancelDiv = value; }
        }

        /// public propaty name  :  CMTCooprtDiv
        /// <summary>CMT連携区分プロパティ</summary>
        /// <value>0:連携なし 1:連携あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   CMT連携区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 CMTCooprtDiv
        {
            get { return _cMTCooprtDiv; }
            set { _cMTCooprtDiv = value; }
        }
        // -- ADD 2010/06/17 -----------------------------<<<

        //--- ADD 2011/05/26 ----------------------------->>>
        /// public propaty name  :  SfPmCprtInstSlipNo
        /// <summary>SF-PM連携指示書番号プロパティ</summary>
        /// <value>0:連携なし 1:連携あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SF-PM連携指示書番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SfPmCprtInstSlipNo
        {
            get { return _sfPmCprtInstSlipNo; }
            set { _sfPmCprtInstSlipNo = value; }
        }

        //--- ADD 2011/05/26 -----------------------------<<<

        //--- ADD gezh 2011/11/12 ----------------------------->>>>>
        /// public propaty name  :  CooperationOptionDiv
        /// <summary>回答方法プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答方法プロパティ</br>
        /// <br>Programer        :   葛中華</br>
        /// </remarks>
        public Int16 CooperationOptionDiv
        {
            get { return _cooperationOptionDiv; }
            set { _cooperationOptionDiv = value; }
        }
        //--- ADD gezh 2011/11/12 -----------------------------<<<<<

        //--- ADD 2012/10/10 2012/11/14配信予定  SCM障害№176対応 ---------->>>>>
        /// public propaty name  :  AutoAnswerCount
        /// <summary>回答方法件数（自動回答分）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答方法件数（自動回答分）プロパティ</br>
        /// </remarks>
        public Int32 AutoAnswerCount
        {
            get { return _autoAnswerCount; }
            set { _autoAnswerCount = value; }
        }

        /// public propaty name  :  ManualAnswerCount
        /// <summary>回答方法件数（手動回答分）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答方法件数（手動回答分）プロパティ</br>
        /// </remarks>
        public Int32 ManualAnswerCount
        {
            get { return _manualAnswerCount; }
            set { _manualAnswerCount = value; }
        }

        //--- ADD 2012/10/10 2012/11/14配信予定  SCM障害№176対応 ----------<<<<<

        // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
        /// public propaty name  :  ExpectedCeDate
        /// <summary>入庫予定日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入庫予定日プロパティ</br>
        /// </remarks>
        public Int32 ExpectedCeDate
        {
            get { return _expectedCeDate; }
            set { _expectedCeDate = value; }
        }
        // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<

        /// <summary>
        /// SCM問い合わせ一覧抽出結果(伝票)クラスワークコンストラクタ
        /// </summary>
        /// <returns>SCMInquiryResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMInquiryResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SCMInquiryResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SCMInquiryResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SCMInquiryResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SCMInquiryResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMInquiryResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SCMInquiryResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SCMInquiryResultWork || graph is ArrayList || graph is SCMInquiryResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SCMInquiryResultWork).FullName));

            if (graph != null && graph is SCMInquiryResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMInquiryResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SCMInquiryResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SCMInquiryResultWork[])graph).Length;
            }
            else if (graph is SCMInquiryResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先名称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //受注ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //売上伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //問合せ元企業コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalEpCd
            //問合せ元拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalSecCd
            //問合せ先企業コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
            //問合せ先拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
            //問合せ番号
            serInfo.MemberInfo.Add(typeof(Int64)); //InquiryNumber
            //更新年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDate
            //更新時間
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateTime
            //問合せ・発注種別
            serInfo.MemberInfo.Add(typeof(Int32)); //InqOrdDivCd
            //回答区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDivCd
            //確定日
            serInfo.MemberInfo.Add(typeof(Int32)); //JudgementDate
            //問合せ・発注備考
            serInfo.MemberInfo.Add(typeof(string)); //InqOrdNote
            //問合せ従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //InqEmployeeCd
            //問合せ従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //InqEmployeeNm
            //回答従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //AnsEmployeeCd
            //回答従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //AnsEmployeeNm
            //問合せ日
            serInfo.MemberInfo.Add(typeof(Int32)); //InquiryDate
            //陸運事務所番号
            serInfo.MemberInfo.Add(typeof(Int32)); //NumberPlate1Code
            //陸運事務局名称
            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate1Name
            //車両登録番号（種別）
            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate2
            //車両登録番号（カナ）
            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate3
            //車両登録番号（プレート番号）
            serInfo.MemberInfo.Add(typeof(Int32)); //NumberPlate4
            //型式指定番号
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelDesignationNo
            //類別番号
            serInfo.MemberInfo.Add(typeof(Int32)); //CategoryNo
            //メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
            //車種コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelCode
            //車種サブコード
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelSubCode
            //車種名
            serInfo.MemberInfo.Add(typeof(string)); //ModelName
            //車検証型式
            serInfo.MemberInfo.Add(typeof(string)); //CarInspectCertModel
            //型式（フル型）
            serInfo.MemberInfo.Add(typeof(string)); //FullModel
            //車台番号
            serInfo.MemberInfo.Add(typeof(string)); //FrameNo
            //車台型式
            serInfo.MemberInfo.Add(typeof(string)); //FrameModel
            //シャシーNo
            serInfo.MemberInfo.Add(typeof(string)); //ChassisNo
            //車両固有番号
            serInfo.MemberInfo.Add(typeof(Int32)); //CarProperNo
            //生産年式（NUMタイプ）
            serInfo.MemberInfo.Add(typeof(Int32)); //ProduceTypeOfYearNum
            //問合せ日(車両情報)
            serInfo.MemberInfo.Add(typeof(Int32)); //InquiryDate_Car
            //問合せ従業員コード(車両情報)
            serInfo.MemberInfo.Add(typeof(string)); //InqEmployeeCd_Car
            //問合せ従業員名称(車両情報)
            serInfo.MemberInfo.Add(typeof(string)); //InqEmployeeNm_Car
            //発注日(車両情報)
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesOrderDate_Car
            //発注者従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //SalesOrderEmployeeCd
            //発注者従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesOrderEmployeeNm
            //コメント
            serInfo.MemberInfo.Add(typeof(string)); //Comment
            //リペアカラーコード
            serInfo.MemberInfo.Add(typeof(string)); //RpColorCode
            //カラー名称1
            serInfo.MemberInfo.Add(typeof(string)); //ColorName1
            //トリムコード
            serInfo.MemberInfo.Add(typeof(string)); //TrimCode
            //トリム名称
            serInfo.MemberInfo.Add(typeof(string)); //TrimName
            //車両走行距離
            serInfo.MemberInfo.Add(typeof(Int32)); //Mileage
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //回答方法
            serInfo.MemberInfo.Add(typeof(Int32)); //AwnserMethod
            //売上伝票合計（税込み）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTotalTaxInc
            // -- ADD 2010/06/17 ---------->>>
            //キャンセル区分
            serInfo.MemberInfo.Add(typeof(Int16)); //CancelDiv
            //CMT連携区分
            serInfo.MemberInfo.Add(typeof(Int16)); //CMTCooprtDiv
            // -- ADD 2010/06/17 ----------<<<
            //SF-PM連携指示書番号
            serInfo.MemberInfo.Add(typeof(string)); //SfPmCprtInstSlipNo
            // -- ADD gezh 2011/11/12 ---------->>>>>
            // 連携対象区分
            serInfo.MemberInfo.Add(typeof(Int16)); // CooperationOptionDiv
            // -- ADD gezh 2011/11/12 ----------<<<<<

            //--- ADD 2012/10/10 2012/11/14配信予定  SCM障害№176対応 ---------->>>>>
            // 回答方法件数（自動回答分）
            serInfo.MemberInfo.Add(typeof(Int32)); // AutoAnswerCount
            // 回答方法件数（手動回答分）
            serInfo.MemberInfo.Add(typeof(Int32)); // ManualAnswerCount
            //--- ADD 2012/10/10 2012/11/14配信予定  SCM障害№176対応 ----------<<<<<

            // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
            serInfo.MemberInfo.Add(typeof(Int32)); // ExpectedCeDate
            // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is SCMInquiryResultWork)
            {
                SCMInquiryResultWork temp = (SCMInquiryResultWork)graph;

                SetSCMInquiryResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SCMInquiryResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SCMInquiryResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SCMInquiryResultWork temp in lst)
                {
                    SetSCMInquiryResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SCMInquiryResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        // -- UPD 2010/06/17 ------------------------>>>
        //private const int currentMemberCount = 53;
        //private const int currentMemberCount = 55;  //DEL 2011/05/26
        //private const int currentMemberCount = 56;    //ADD 2011/05/26 //DEL 2011/11/12
        //--- UPD 2012/10/10 2012/11/14配信予定  SCM障害№176対応 ---------->>>>>
        //private const int currentMemberCount = 57;    // ADD 2011/11/12
        // UPD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
        //private const int currentMemberCount = 59;
        private const int currentMemberCount = 60;
        // UPD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<
        //--- UPD 2012/10/10 2012/11/14配信予定  SCM障害№176対応 ----------<<<<<
        // -- UPD 2010/06/17 ------------------------<<<

        /// <summary>
        ///  SCMInquiryResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMInquiryResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSCMInquiryResultWork(System.IO.BinaryWriter writer, SCMInquiryResultWork temp)
        {
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先名称
            writer.Write(temp.CustomerName);
            //受注ステータス
            writer.Write(temp.AcptAnOdrStatus);
            //売上伝票番号
            writer.Write(temp.SalesSlipNum);
            //問合せ元企業コード
            writer.Write(temp.InqOriginalEpCd.Trim());	//@@@@20230303
            //問合せ元拠点コード
            writer.Write(temp.InqOriginalSecCd);
            //問合せ先企業コード
            writer.Write(temp.InqOtherEpCd);
            //問合せ先拠点コード
            writer.Write(temp.InqOtherSecCd);
            //問合せ番号
            writer.Write(temp.InquiryNumber);
            //更新年月日
            writer.Write((Int64)temp.UpdateDate.Ticks);
            //更新時間
            writer.Write(temp.UpdateTime);
            //問合せ・発注種別
            writer.Write(temp.InqOrdDivCd);
            //回答区分
            writer.Write(temp.AnswerDivCd);
            //確定日
            writer.Write(temp.JudgementDate);
            //問合せ・発注備考
            writer.Write(temp.InqOrdNote);
            //問合せ従業員コード
            writer.Write(temp.InqEmployeeCd);
            //問合せ従業員名称
            writer.Write(temp.InqEmployeeNm);
            //回答従業員コード
            writer.Write(temp.AnsEmployeeCd);
            //回答従業員名称
            writer.Write(temp.AnsEmployeeNm);
            //問合せ日
            writer.Write(temp.InquiryDate);
            //陸運事務所番号
            writer.Write(temp.NumberPlate1Code);
            //陸運事務局名称
            writer.Write(temp.NumberPlate1Name);
            //車両登録番号（種別）
            writer.Write(temp.NumberPlate2);
            //車両登録番号（カナ）
            writer.Write(temp.NumberPlate3);
            //車両登録番号（プレート番号）
            writer.Write(temp.NumberPlate4);
            //型式指定番号
            writer.Write(temp.ModelDesignationNo);
            //類別番号
            writer.Write(temp.CategoryNo);
            //メーカーコード
            writer.Write(temp.MakerCode);
            //車種コード
            writer.Write(temp.ModelCode);
            //車種サブコード
            writer.Write(temp.ModelSubCode);
            //車種名
            writer.Write(temp.ModelName);
            //車検証型式
            writer.Write(temp.CarInspectCertModel);
            //型式（フル型）
            writer.Write(temp.FullModel);
            //車台番号
            writer.Write(temp.FrameNo);
            //車台型式
            writer.Write(temp.FrameModel);
            //シャシーNo
            writer.Write(temp.ChassisNo);
            //車両固有番号
            writer.Write(temp.CarProperNo);
            //生産年式（NUMタイプ）
            writer.Write(temp.ProduceTypeOfYearNum);
            //問合せ日(車両情報)
            writer.Write(temp.InquiryDate_Car);
            //問合せ従業員コード(車両情報)
            writer.Write(temp.InqEmployeeCd_Car);
            //問合せ従業員名称(車両情報)
            writer.Write(temp.InqEmployeeNm_Car);
            //発注日(車両情報)
            writer.Write(temp.SalesOrderDate_Car);
            //発注者従業員コード
            writer.Write(temp.SalesOrderEmployeeCd);
            //発注者従業員名称
            writer.Write(temp.SalesOrderEmployeeNm);
            //コメント
            writer.Write(temp.Comment);
            //リペアカラーコード
            writer.Write(temp.RpColorCode);
            //カラー名称1
            writer.Write(temp.ColorName1);
            //トリムコード
            writer.Write(temp.TrimCode);
            //トリム名称
            writer.Write(temp.TrimName);
            //車両走行距離
            writer.Write(temp.Mileage);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //回答方法
            writer.Write(temp.AwnserMethod);
            //売上伝票合計（税込み）
            writer.Write(temp.SalesTotalTaxInc);
            // -- ADD 2010/06/17 -------------->>>
            //キャンセル区分
            writer.Write(temp.CancelDiv);
            //CMT連携区分
            writer.Write(temp.CMTCooprtDiv);
            // -- ADD 2010/06/17 --------------<<<
            //SF-PM連携指示書番号
            writer.Write(temp.SfPmCprtInstSlipNo);  //ADD 2011/05/26
            // ADD gezh 2011/11/12 -------------->>>>>
            // 連携対象区分
            writer.Write(temp.CooperationOptionDiv);
            // ADD gezh 2011/11/12 --------------<<<<<
            //--- ADD 2012/10/10 2012/11/14配信予定  SCM障害№176対応 ---------->>>>>
            // 回答方法件数（自動回答分）
            writer.Write(temp.AutoAnswerCount);
            // 回答方法件数（手動回答分）
            writer.Write(temp.ManualAnswerCount);
            //--- ADD 2012/10/10 2012/11/14配信予定  SCM障害№176対応 ----------<<<<<
            // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
            // 入庫予定日
            writer.Write(temp.ExpectedCeDate);
            // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<
        }

        /// <summary>
        ///  SCMInquiryResultWorkインスタンス取得
        /// </summary>
        /// <returns>SCMInquiryResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMInquiryResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SCMInquiryResultWork GetSCMInquiryResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SCMInquiryResultWork temp = new SCMInquiryResultWork();

            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先名称
            temp.CustomerName = reader.ReadString();
            //受注ステータス
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //売上伝票番号
            temp.SalesSlipNum = reader.ReadString();
            //問合せ元企業コード
            temp.InqOriginalEpCd = reader.ReadString().Trim();//@@@@20230303
            //問合せ元拠点コード
            temp.InqOriginalSecCd = reader.ReadString();
            //問合せ先企業コード
            temp.InqOtherEpCd = reader.ReadString();
            //問合せ先拠点コード
            temp.InqOtherSecCd = reader.ReadString();
            //問合せ番号
            temp.InquiryNumber = reader.ReadInt64();
            //更新年月日
            temp.UpdateDate = new DateTime(reader.ReadInt64());
            //更新時間
            temp.UpdateTime = reader.ReadInt32();
            //問合せ・発注種別
            temp.InqOrdDivCd = reader.ReadInt32();
            //回答区分
            temp.AnswerDivCd = reader.ReadInt32();
            //確定日
            temp.JudgementDate = reader.ReadInt32();
            //問合せ・発注備考
            temp.InqOrdNote = reader.ReadString();
            //問合せ従業員コード
            temp.InqEmployeeCd = reader.ReadString();
            //問合せ従業員名称
            temp.InqEmployeeNm = reader.ReadString();
            //回答従業員コード
            temp.AnsEmployeeCd = reader.ReadString();
            //回答従業員名称
            temp.AnsEmployeeNm = reader.ReadString();
            //問合せ日
            temp.InquiryDate = reader.ReadInt32();
            //陸運事務所番号
            temp.NumberPlate1Code = reader.ReadInt32();
            //陸運事務局名称
            temp.NumberPlate1Name = reader.ReadString();
            //車両登録番号（種別）
            temp.NumberPlate2 = reader.ReadString();
            //車両登録番号（カナ）
            temp.NumberPlate3 = reader.ReadString();
            //車両登録番号（プレート番号）
            temp.NumberPlate4 = reader.ReadInt32();
            //型式指定番号
            temp.ModelDesignationNo = reader.ReadInt32();
            //類別番号
            temp.CategoryNo = reader.ReadInt32();
            //メーカーコード
            temp.MakerCode = reader.ReadInt32();
            //車種コード
            temp.ModelCode = reader.ReadInt32();
            //車種サブコード
            temp.ModelSubCode = reader.ReadInt32();
            //車種名
            temp.ModelName = reader.ReadString();
            //車検証型式
            temp.CarInspectCertModel = reader.ReadString();
            //型式（フル型）
            temp.FullModel = reader.ReadString();
            //車台番号
            temp.FrameNo = reader.ReadString();
            //車台型式
            temp.FrameModel = reader.ReadString();
            //シャシーNo
            temp.ChassisNo = reader.ReadString();
            //車両固有番号
            temp.CarProperNo = reader.ReadInt32();
            //生産年式（NUMタイプ）
            temp.ProduceTypeOfYearNum = reader.ReadInt32();
            //問合せ日(車両情報)
            temp.InquiryDate_Car = reader.ReadInt32();
            //問合せ従業員コード(車両情報)
            temp.InqEmployeeCd_Car = reader.ReadString();
            //問合せ従業員名称(車両情報)
            temp.InqEmployeeNm_Car = reader.ReadString();
            //発注日(車両情報)
            temp.SalesOrderDate_Car = reader.ReadInt32();
            //発注者従業員コード
            temp.SalesOrderEmployeeCd = reader.ReadString();
            //発注者従業員名称
            temp.SalesOrderEmployeeNm = reader.ReadString();
            //コメント
            temp.Comment = reader.ReadString();
            //リペアカラーコード
            temp.RpColorCode = reader.ReadString();
            //カラー名称1
            temp.ColorName1 = reader.ReadString();
            //トリムコード
            temp.TrimCode = reader.ReadString();
            //トリム名称
            temp.TrimName = reader.ReadString();
            //車両走行距離
            temp.Mileage = reader.ReadInt32();
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //回答方法
            temp.AwnserMethod = reader.ReadInt32();
            //売上伝票合計（税込み）
            temp.SalesTotalTaxInc = reader.ReadInt64();
            // -- UPD 2010/06/17 ------------------------->>>
            //キャンセル区分
            temp.CancelDiv = reader.ReadInt16();
            //CMT連携区分
            temp.CMTCooprtDiv = reader.ReadInt16();
            // -- UPD 2010/06/17 -------------------------<<<
            //SF-PM連携指示書番号
            temp.SfPmCprtInstSlipNo = reader.ReadString();  //ADD 2011/05/26
            // ADD gezh 2011/11/12 ----------------------->>>>>
            // 連携対象区分
            temp.CooperationOptionDiv = reader.ReadInt16();
            // ADD gezh 2011/11/12 -----------------------<<<<<
            //--- ADD 2012/10/10 2012/11/14配信予定  SCM障害№176対応 ---------->>>>>
            // 回答方法件数（自動回答分）
            temp.AutoAnswerCount = reader.ReadInt32();
            // 回答方法件数（手動回答分）
            temp.ManualAnswerCount = reader.ReadInt32();
            //--- ADD 2012/10/10 2012/11/14配信予定  SCM障害№176対応 ----------<<<<<
            // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
            // 入庫予定日
            temp.ExpectedCeDate = reader.ReadInt32();
            // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<

            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>SCMInquiryResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMInquiryResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SCMInquiryResultWork temp = GetSCMInquiryResultWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (SCMInquiryResultWork[])lst.ToArray(typeof(SCMInquiryResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
