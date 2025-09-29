using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SupplierPrintWork
	/// <summary>
	///                      仕入先マスタ（印刷）条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入先マスタ（印刷）条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
    public class SupplierPrintWork 
    {
        # region ■ private field ■
        /// <summary>開始仕入先コード</summary>
        private Int32 _supplierCdSt;

        /// <summary>終了仕入先コード</summary>
        private Int32 _supplierCdEd;

        /// <summary>開始仕入先カナ</summary>
        private string _supplierKanaSt = "";

        /// <summary>終了仕入先カナ</summary>
        private string _supplierKanaEd = "";

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
        /// public propaty name  :  SupplierCdSt
        /// <summary>開始仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCdSt
        {
            get { return _supplierCdSt; }
            set { _supplierCdSt = value; }
        }

        /// public propaty name  :  SupplierCdEd
        /// <summary>終了仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCdEd
        {
            get { return _supplierCdEd; }
            set { _supplierCdEd = value; }
        }

        /// public propaty name  :  SupplierKanaSt
        /// <summary>開始仕入先カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始仕入先カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierKanaSt
        {
            get { return _supplierKanaSt; }
            set { _supplierKanaSt = value; }
        }

        /// public propaty name  :  SupplierKanaEd
        /// <summary>終了仕入先カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了仕入先カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierKanaEd
        {
            get { return _supplierKanaEd; }
            set { _supplierKanaEd = value; }
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
        /// 仕入先マスタ（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>EmployeePrintWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeePrintWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SupplierPrintWork()
        {
        }
        # endregion ■ Constructor ■
    }
}
