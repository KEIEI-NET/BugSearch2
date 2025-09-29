using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SalesTargetPrintWork
	/// <summary>
	///                      売上目標設定マスタマスタ（印刷）条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   売上目標設定マスタマスタ（印刷）条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
    public class SalesTargetPrintWork 
    {
        # region ■ private field ■
        /// <summary>印刷パターン</summary>
        /// <remarks>0:拠点 1:拠点-部門 2:拠点-担当者 3:拠点-受注者 4:拠点-発行者 5:拠点-販売区分 6:拠点-商品区分 7:拠点-得意先 8:拠点-業種 9:拠点-地区</remarks>
        private Int32 _printType;

        /// <summary>印刷区分</summary>
        private Int32 _printDiv;

        /// <summary>開始年月</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _targetDivideCodeSt;

        /// <summary>終了年月</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _targetDivideCodeEd;

        /// <summary>開始拠点コード</summary>
        private string _sectionCodeSt = "";

        /// <summary>終了拠点コード</summary>
        private string _sectionCodeEd = "";

        /// <summary>開始部門コード</summary>
        private Int32 _subSectionCodeSt;

        /// <summary>終了部門コード</summary>
        private Int32 _subSectionCodeEd;

        /// <summary>開始従業員コード</summary>
        private string _employeeCodeSt = "";

        /// <summary>終了従業員コード</summary>
        private string _employeeCodeEd = "";

        /// <summary>開始販売区分コード</summary>
        private Int32 _salesCodeSt;

        /// <summary>終了販売区分コード</summary>
        private Int32 _salesCodeEd;

        /// <summary>開始商品区分コード</summary>
        /// <remarks>自社分類コード</remarks>
        private Int32 _enterpriseGanreCodeSt;

        /// <summary>終了商品区分コード</summary>
        /// <remarks>自社分類コード</remarks>
        private Int32 _enterpriseGanreCodeEd;

        /// <summary>開始得意先コード</summary>
        private Int32 _customerCodeSt;

        /// <summary>終了得意先コード</summary>
        private Int32 _customerCodeEd;

        /// <summary>開始業種コード</summary>
        private Int32 _businessTypeCodeSt;

        /// <summary>終了業種コード</summary>
        private Int32 _businessTypeCodeEd;

        /// <summary>開始販売エリアコード</summary>
        private Int32 _salesAreaCodeSt;

        /// <summary>終了販売エリアコード</summary>
        private Int32 _salesAreaCodeEd;

        /// <summary>削除指定区分</summary>
        /// <remarks>0:有効,1:論理削除</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>開始削除日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _deleteDateTimeSt;

        /// <summary>終了削除日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _deleteDateTimeEd;

        # endregion  ■ private field ■

        # region ■ public propaty ■
        /// public propaty name  :  PrintType
        /// <summary>印刷パターンプロパティ</summary>
        /// <value>0:拠点 1:拠点-部門 2:拠点-担当者 3:拠点-受注者 4:拠点-発行者 5:拠点-販売区分 6:拠点-商品区分 7:拠点-得意先 8:拠点-業種 9:拠点-地区</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷パターンプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintType
        {
            get { return _printType; }
            set { _printType = value; }
        }

        /// public propaty name  :  PrintDiv
        /// <summary>印刷区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintDiv
        {
            get { return _printDiv; }
            set { _printDiv = value; }
        }

        /// public propaty name  :  TargetDivideCodeSt
        /// <summary>開始年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TargetDivideCodeSt
        {
            get { return _targetDivideCodeSt; }
            set { _targetDivideCodeSt = value; }
        }

        /// public propaty name  :  TargetDivideCodeEd
        /// <summary>終了年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TargetDivideCodeEd
        {
            get { return _targetDivideCodeEd; }
            set { _targetDivideCodeEd = value; }
        }

        /// public propaty name  :  SectionCodeSt
        /// <summary>開始拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeSt
        {
            get { return _sectionCodeSt; }
            set { _sectionCodeSt = value; }
        }

        /// public propaty name  :  SectionCodeEd
        /// <summary>終了拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeEd
        {
            get { return _sectionCodeEd; }
            set { _sectionCodeEd = value; }
        }

        /// public propaty name  :  SubSectionCodeSt
        /// <summary>開始部門コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始部門コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubSectionCodeSt
        {
            get { return _subSectionCodeSt; }
            set { _subSectionCodeSt = value; }
        }

        /// public propaty name  :  SubSectionCodeEd
        /// <summary>終了部門コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了部門コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubSectionCodeEd
        {
            get { return _subSectionCodeEd; }
            set { _subSectionCodeEd = value; }
        }

        /// public propaty name  :  EmployeeCodeSt
        /// <summary>開始従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCodeSt
        {
            get { return _employeeCodeSt; }
            set { _employeeCodeSt = value; }
        }

        /// public propaty name  :  EmployeeCodeEd
        /// <summary>終了従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCodeEd
        {
            get { return _employeeCodeEd; }
            set { _employeeCodeEd = value; }
        }

        /// public propaty name  :  SalesCodeSt
        /// <summary>開始販売区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始販売区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCodeSt
        {
            get { return _salesCodeSt; }
            set { _salesCodeSt = value; }
        }

        /// public propaty name  :  SalesCodeEd
        /// <summary>終了販売区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了販売区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCodeEd
        {
            get { return _salesCodeEd; }
            set { _salesCodeEd = value; }
        }

        /// public propaty name  :  EnterpriseGanreCodeSt
        /// <summary>開始商品区分コードプロパティ</summary>
        /// <value>自社分類コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterpriseGanreCodeSt
        {
            get { return _enterpriseGanreCodeSt; }
            set { _enterpriseGanreCodeSt = value; }
        }

        /// public propaty name  :  EnterpriseGanreCodeEd
        /// <summary>終了商品区分コードプロパティ</summary>
        /// <value>自社分類コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterpriseGanreCodeEd
        {
            get { return _enterpriseGanreCodeEd; }
            set { _enterpriseGanreCodeEd = value; }
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

        /// public propaty name  :  BusinessTypeCodeSt
        /// <summary>開始業種コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始業種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BusinessTypeCodeSt
        {
            get { return _businessTypeCodeSt; }
            set { _businessTypeCodeSt = value; }
        }

        /// public propaty name  :  BusinessTypeCodeEd
        /// <summary>終了業種コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了業種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BusinessTypeCodeEd
        {
            get { return _businessTypeCodeEd; }
            set { _businessTypeCodeEd = value; }
        }

        /// public propaty name  :  SalesAreaCodeSt
        /// <summary>開始販売エリアコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始販売エリアコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCodeSt
        {
            get { return _salesAreaCodeSt; }
            set { _salesAreaCodeSt = value; }
        }

        /// public propaty name  :  SalesAreaCodeEd
        /// <summary>終了販売エリアコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了販売エリアコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCodeEd
        {
            get { return _salesAreaCodeEd; }
            set { _salesAreaCodeEd = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>削除指定区分プロパティ</summary>
        /// <value>0:有効,1:論理削除</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   削除指定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  DeleteDateTimeSt
        /// <summary>開始削除日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始削除日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeleteDateTimeSt
        {
            get { return _deleteDateTimeSt; }
            set { _deleteDateTimeSt = value; }
        }

        /// public propaty name  :  DeleteDateTimeEd
        /// <summary>終了削除日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了削除日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeleteDateTimeEd
        {
            get { return _deleteDateTimeEd; }
            set { _deleteDateTimeEd = value; }
        }
        # endregion ■ public propaty ■

        # region ■ Constructor ■
        /// <summary>
        /// 売上目標設定マスタ（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>SalesTargetPrintWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesTargetPrintWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesTargetPrintWork()
        {
        }
        # endregion ■ Constructor ■
    }
}
