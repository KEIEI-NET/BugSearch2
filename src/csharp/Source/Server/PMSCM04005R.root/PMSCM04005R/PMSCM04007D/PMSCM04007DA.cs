using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SCMInquiryOrderWork
    /// <summary>
    ///                      SCM問い合わせ一覧抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM問い合わせ一覧抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    2009/4/13</br>
    /// <br>Genarated Date   :   2009/05/18  (CSharp File Generated Date)</br>
    /// <br></br>
    /// <br>Update Note: 抽出条件項目追加(開始更新年月日(St_UpdateDate),終了更新年月日(Ed_UpdateDate))</br>
    /// <br>Programmer : 22018　鈴木 正臣</br>
    /// <br>Date       : 2011/06/13</br>
    /// <br>Update Note: Readmine 26534 受発注種別を追加し、PCCforNSとBLパーツオーダーシステムの判断を可能とする</br>
    /// <br>Programmer : 葛中華</br>    
    /// <br>Date       : 2011/11/12</br>    
    /// <br>Update Note: SCM障害№10384対応 抽出条件項目追加（開始入庫予定日, 終了入庫予定日）(</br>
    /// <br>Programmer : 30744 湯上 千加子</br>    
    /// <br>Date       : 2013/05/09</br>    
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SCMInquiryOrderWork
    {
        /// <summary>問合せ元企業コード</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>問合せ元拠点コード</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>問合せ先企業コード</summary>
        private string _inqOtherEpCd = "";

        /// <summary>問合せ先拠点コード</summary>
        private string _inqOtherSecCd = "";

        /// <summary>開始問合せ番号</summary>
        private Int64 _st_InquiryNumber;

        /// <summary>終了問合せ番号</summary>
        private Int64 _ed_InquiryNumber;

        /// <summary>更新年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _updateDate;

        /// <summary>更新時間</summary>
        /// <remarks>HHMMSSXXX</remarks>
        private Int32 _updateTime;

        /// <summary>問合せ・発注種別</summary>
        /// <remarks>1:問合せ 2:発注</remarks>
        private Int32[] _inqOrdDivCd;

        /// <summary>回答区分</summary>
        /// <remarks>0:アクションなし 1:回答中 10:一部回答 20:回答完了 30:承認 99:キャンセル</remarks>
        private Int32[] _answerDivCd;

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

        /// <summary>開始問合せ日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _st_InquiryDate;

        /// <summary>終了問合せ日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _ed_InquiryDate;

        /// <summary>開始得意先コード</summary>
        private Int32 _st_CustomerCode;

        /// <summary>終了得意先コード</summary>
        private Int32 _ed_CustomerCode;

        /// <summary>開始売上伝票番号</summary>
        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
        private string _st_SalesSlipNum = "";

        /// <summary>終了売上伝票番号</summary>
        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
        private string _ed_SalesSlipNum = "";

        /// <summary>受注ステータス</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
        private Int32[] _acptAnOdrStatus;

        /// <summary>回答方法</summary>
        private Int32[] _awnserMethod;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>売上伝票合計（税込み）</summary>
        /// <remarks>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</remarks>
        private Int64 _salesTotalTaxInc;

        // --- ADD m.suzuki 2011/06/13 ---------->>>>>
        /// <summary>開始更新年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _st_UpdateDate;

        /// <summary>終了更新年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _ed_UpdateDate;
        // --- ADD m.suzuki 2011/06/13 ----------<<<<<

        // --- ADD gezh 2011/11/12 ---------->>>>>  
        /// <summary>連携対象区分</summary>        
        private Int16[] _cooperationOptionDiv;  
        // --- ADD gezh 2011/11/12 ----------<<<<<

        // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
        /// <summary>開始入庫予定日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _st_ExpectedCeDate;

        /// <summary>終了入庫予定日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _ed_ExpectedCeDate;
        // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<

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

        /// public propaty name  :  St_InquiryNumber
        /// <summary>開始問合せ番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始問合せ番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 St_InquiryNumber
        {
            get { return _st_InquiryNumber; }
            set { _st_InquiryNumber = value; }
        }

        /// public propaty name  :  Ed_InquiryNumber
        /// <summary>終了問合せ番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了問合せ番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Ed_InquiryNumber
        {
            get { return _ed_InquiryNumber; }
            set { _ed_InquiryNumber = value; }
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
        public Int32[] InqOrdDivCd
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
        public Int32[] AnswerDivCd
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

        /// public propaty name  :  St_InquiryDate
        /// <summary>開始問合せ日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始問合せ日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_InquiryDate
        {
            get { return _st_InquiryDate; }
            set { _st_InquiryDate = value; }
        }

        /// public propaty name  :  Ed_InquiryDate
        /// <summary>終了問合せ日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了問合せ日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_InquiryDate
        {
            get { return _ed_InquiryDate; }
            set { _ed_InquiryDate = value; }
        }

        /// public propaty name  :  St_CustomerCode
        /// <summary>開始得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_CustomerCode
        {
            get { return _st_CustomerCode; }
            set { _st_CustomerCode = value; }
        }

        /// public propaty name  :  Ed_CustomerCode
        /// <summary>終了得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_CustomerCode
        {
            get { return _ed_CustomerCode; }
            set { _ed_CustomerCode = value; }
        }

        /// public propaty name  :  St_SalesSlipNum
        /// <summary>開始売上伝票番号プロパティ</summary>
        /// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_SalesSlipNum
        {
            get { return _st_SalesSlipNum; }
            set { _st_SalesSlipNum = value; }
        }

        /// public propaty name  :  Ed_SalesSlipNum
        /// <summary>終了売上伝票番号プロパティ</summary>
        /// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_SalesSlipNum
        {
            get { return _ed_SalesSlipNum; }
            set { _ed_SalesSlipNum = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>10:見積,20:受注,30:売上,40:出荷</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32[] AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  AwnserMethod
        /// <summary>回答方法プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答方法プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32[] AwnserMethod
        {
            get { return _awnserMethod; }
            set { _awnserMethod = value; }
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

        // --- ADD m.suzuki 2011/06/13 ---------->>>>>
        /// public propaty name  :  St_UpdateDate
        /// <summary>開始更新年月日</summary>
        /// <value>YYYYMMDD</value>
        public Int32 St_UpdateDate
        {
            get { return _st_UpdateDate; }
            set { _st_UpdateDate = value; }
        }
        /// public propaty name  :  Ed_UpdateDate
        /// <summary>終了更新年月日</summary>
        /// <value>YYYYMMDD</value>
        public Int32 Ed_UpdateDate
        {
            get { return _ed_UpdateDate; }
            set { _ed_UpdateDate = value; }
        }
        // --- ADD m.suzuki 2011/06/13 ----------<<<<<

        // --- ADD gezh 2011/11/12 ---------->>>>> 
        /// public propaty name  :  CooperationOptionDiv        
        /// <summary>連携対象区分プロパティ</summary>        
        public Int16[] CooperationOptionDiv
        {
            get { return _cooperationOptionDiv; }
            set { _cooperationOptionDiv = value; }
        }        
        // --- ADD gezh 2011/11/12 ----------<<<<<

        // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
        /// public propaty name  :  St_ExpectedCeDate
        /// <summary>開始入庫予定日</summary>
        /// <value>YYYYMMDD</value>
        public Int32 St_ExpectedCeDate
        {
            get { return _st_ExpectedCeDate; }
            set { _st_ExpectedCeDate = value; }
        }
        /// public propaty name  :  Ed_ExpectedCeDate
        /// <summary>終了入庫予定日</summary>
        /// <value>YYYYMMDD</value>
        public Int32 Ed_ExpectedCeDate
        {
            get { return _ed_ExpectedCeDate; }
            set { _ed_ExpectedCeDate = value; }
        }
        // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<
        
        /// <summary>
        /// SCM問い合わせ一覧抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>SCMInquiryOrderWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMInquiryOrderWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SCMInquiryOrderWork()
        {
        }

    }
}




