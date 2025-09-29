using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   WarehousePrintWork
	/// <summary>
	///                      倉庫マスタ（印刷）条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   倉庫マスタ（印刷）条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
    public class WarehousePrintWork 
    {
        # region ■ private field ■
        /// <summary>開始倉庫コード</summary>
        private string _warehousecodeSt = "";

        /// <summary>終了倉庫コード</summary>
        private string _warehousecodeEd = "";

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
        /// public propaty name  :  SectionCodeSt
		/// <summary>開始倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public string WarehouseCodeSt
		{
            get { return _warehousecodeSt; }
            set { _warehousecodeSt = value; }
		}

		/// public propaty name  :  SectionCodeEd
		/// <summary>終了倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public string WarehouseCodeEd
		{
            get { return _warehousecodeEd; }
            set { _warehousecodeEd = value; }
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
            get { return _deleteDateTimeEd; }
            set { _deleteDateTimeEd = value; }
        }
        # endregion ■ public propaty ■

        # region ■ Constructor ■
        /// <summary>
		/// 拠点情報（印刷）データクラスワークコンストラクタ
		/// </summary>
        /// <returns>WarehousePrintWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SectionPrintWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public WarehousePrintWork()
		{
		}
        # endregion ■ Constructor ■
    }
}
