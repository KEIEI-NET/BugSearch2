using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SalesDayMonthReportParamWork
	/// <summary>
	///                      売上日報月報出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   売上日報月報出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/08/13  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SalesDayMonthReportParamWork
	{
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        /// <remarks>(配列)　全社指定は{""}</remarks>
        private string[] _sectionCodes;

        /// <summary>集計単位</summary>
        /// <remarks>0:得意先別 1:担当者別 2:受注者別 3:発行者別 4:地区別 5:業種別 6:販売区分別</remarks>
        private Int32 _totalType;

        /// <summary>集計方法</summary>
        /// <remarks>0:全社 1:拠点毎</remarks>
        private Int32 _ttlType;

        /// <summary>出力順</summary>
        /// <remarks>※出力順について参照</remarks>
        private Int32 _outType;

        /// <summary>開始対象日付(期間)</summary>
        /// <remarks>計上年月(YYYYMMDD)</remarks>
        private DateTime _salesDateSt;

        /// <summary>終了対象日付(期間)</summary>
        /// <remarks>計上年月(YYYYMMDD)</remarks>
        private DateTime _salesDateEd;

        /// <summary>開始対象日付(当月)</summary>
        /// <remarks>前月締日の翌日(YYYYMMDD)</remarks>
        private DateTime _monthReportDateSt;

        /// <summary>終了対象日付(当月)</summary>
        /// <remarks>計上年月(YYYYMMDD)</remarks>
        private DateTime _monthReportDateEd;

        /// <summary>開始得意先コード</summary>
        private Int32 _customerCodeSt;

        /// <summary>終了得意先コード</summary>
        private Int32 _customerCodeEd;

        /// <summary>開始検索コード</summary>
        /// <remarks>XXXコードをセット　集計単位により変化(集計単位=0:なし 1:担当者 2:受注者 3:発行者 4:地区 5:業種 6:販売区分)</remarks>
        private string _srchCodeSt = "";

        /// <summary>終了検索コード</summary>
        /// <remarks>XXXコードをセット　集計単位により変化(集計単位=0:なし 1:担当者 2:受注者 3:発行者 4:地区 5:業種 6:販売区分)</remarks>
        private string _srchCodeEd = "";

        /// <summary>対象年月(目標)</summary>
        /// <remarks>計上年月(YYYYMM)</remarks>
        private DateTime _targetYearMonthSt;

        /// <summary>対象年月(目標)</summary>
        /// <remarks>計上年月(YYYYMM)</remarks>
        private DateTime _targetYearMonthEd;


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

        /// public propaty name  :  SectionCodes
        /// <summary>拠点コードプロパティ</summary>
        /// <value>(配列)　全社指定は{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        /// public propaty name  :  TotalType
        /// <summary>集計単位プロパティ</summary>
        /// <value>0:得意先別 1:担当者別 2:受注者別 3:発行者別 4:地区別 5:業種別 6:販売区分別</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集計単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalType
        {
            get { return _totalType; }
            set { _totalType = value; }
        }

        /// public propaty name  :  TtlType
        /// <summary>集計方法プロパティ</summary>
        /// <value>0:全社 1:拠点毎</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集計方法プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TtlType
        {
            get { return _ttlType; }
            set { _ttlType = value; }
        }

        /// public propaty name  :  OutType
        /// <summary>出力順プロパティ</summary>
        /// <value>※出力順について参照</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力順プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OutType
        {
            get { return _outType; }
            set { _outType = value; }
        }

        /// public propaty name  :  SalesDateSt
        /// <summary>開始対象日付(期間)プロパティ</summary>
        /// <value>計上年月(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始対象日付(期間)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDateSt
        {
            get { return _salesDateSt; }
            set { _salesDateSt = value; }
        }

        /// public propaty name  :  SalesDateEd
        /// <summary>終了対象日付(期間)プロパティ</summary>
        /// <value>計上年月(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了対象日付(期間)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDateEd
        {
            get { return _salesDateEd; }
            set { _salesDateEd = value; }
        }

        /// public propaty name  :  MonthReportDateSt
        /// <summary>開始対象日付(当月)プロパティ</summary>
        /// <value>前月締日の翌日(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始対象日付(当月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime MonthReportDateSt
        {
            get { return _monthReportDateSt; }
            set { _monthReportDateSt = value; }
        }

        /// public propaty name  :  MonthReportDateEd
        /// <summary>終了対象日付(当月)プロパティ</summary>
        /// <value>計上年月(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了対象日付(当月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime MonthReportDateEd
        {
            get { return _monthReportDateEd; }
            set { _monthReportDateEd = value; }
        }

        /// public propaty name  :  CustomerCodeSt
        /// <summary>開始得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>終了得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }

        /// public propaty name  :  SrchCodeSt
        /// <summary>開始検索コードプロパティ</summary>
        /// <value>XXXコードをセット　集計単位により変化(集計単位=0:なし 1:担当者 2:受注者 3:発行者 4:地区 5:業種 6:販売区分)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始検索コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SrchCodeSt
        {
            get { return _srchCodeSt; }
            set { _srchCodeSt = value; }
        }

        /// public propaty name  :  SrchCodeEd
        /// <summary>終了検索コードプロパティ</summary>
        /// <value>XXXコードをセット　集計単位により変化(集計単位=0:なし 1:担当者 2:受注者 3:発行者 4:地区 5:業種 6:販売区分)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了検索コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SrchCodeEd
        {
            get { return _srchCodeEd; }
            set { _srchCodeEd = value; }
        }

        /// public propaty name  :  TargetYearMonthSt
        /// <summary>対象年月(目標)プロパティ</summary>
        /// <value>計上年月(YYYYMM)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   対象年月(目標)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime TargetYearMonthSt
        {
            get { return _targetYearMonthSt; }
            set { _targetYearMonthSt = value; }
        }

        /// public propaty name  :  TargetYearMonthEd
        /// <summary>対象年月(目標)プロパティ</summary>
        /// <value>計上年月(YYYYMM)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   対象年月(目標)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime TargetYearMonthEd
        {
            get { return _targetYearMonthEd; }
            set { _targetYearMonthEd = value; }
        }


        /// <summary>
        /// 売上日報月報出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>SalesDayMonthReportParamWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesDayMonthReportParamWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesDayMonthReportParamWork()
        {
        }
    }
}
