using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   RatePrtReqCndtn
	/// <summary>
	///                      従業員ガイドマスタ（印刷）条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   従業員ガイドマスタ（印刷）条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
    public class EmployeePrintWork 
    {
        # region ■ private field ■
        /// <summary>開始拠点コード</summary>
        private string _sectionCodeSt = "";

		/// <summary>終了拠点コード</summary>
        private string _sectionCodeEd = "";

		/// <summary>開始従業員ガイドコード</summary>
		private string _employeeCodeSt = "";

		/// <summary>開始従業員ガイドコード</summary>
		private string _employeeCodeEd = "";

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
        /// public propaty name  :  WarehousecodeSt
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

		/// public propaty name  :  WarehousecodeEd
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

		/// public propaty name  :  EmployeeCodeSt
		/// <summary>開始従業員ガイドコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始従業員ガイドコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EmployeeCodeSt
		{
			get{return _employeeCodeSt;}
			set{_employeeCodeSt = value;}
		}

		/// public propaty name  :  EmployeeCodeEd
		/// <summary>開始従業員ガイドコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始従業員ガイドコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EmployeeCodeEd
		{
			get{return _employeeCodeEd;}
			set{_employeeCodeEd = value;}
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
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
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
			get{return _deleteDateTimeSt;}
			set{_deleteDateTimeSt = value;}
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
			get{return _deleteDateTimeEd;}
			set{_deleteDateTimeEd = value;}
		}
        # endregion ■ public propaty ■

        # region ■ Constructor ■
        /// <summary>
        /// 従業員ガイド（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>EmployeePrintWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeePrintWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EmployeePrintWork()
        {
        }
        # endregion ■ Constructor ■
    }
}
