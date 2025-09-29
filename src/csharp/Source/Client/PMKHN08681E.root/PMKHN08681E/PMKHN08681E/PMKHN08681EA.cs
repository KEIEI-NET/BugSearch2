using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   PartsPosCodePrintWork
	/// <summary>
	///                      部位マスタ（印刷）条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   部位マスタ（印刷）条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
    public class PartsPosCodePrintWork 
    {
        # region ■ private field ■
        /// <summary>開始検索部位コード</summary>
		private Int32 _searchPartsPosCodeSt;

		/// <summary>終了検索部位コード</summary>
		private Int32 _searchPartsPosCodeEd;

        /// <summary>開始得意先コード</summary>
        private Int32 _customerCodeSt;

        /// <summary>開始得意先コード</summary>
        private Int32 _customerCodeEd;

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
        /// public propaty name  :  SearchPartsPosCodeSt
		/// <summary>開始検索部位コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始検索部位コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SearchPartsPosCodeSt
		{
			get{return _searchPartsPosCodeSt;}
			set{_searchPartsPosCodeSt = value;}
		}

		/// public propaty name  :  SearchPartsPosCodeEd
		/// <summary>終了検索部位コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了検索部位コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SearchPartsPosCodeEd
		{
			get{return _searchPartsPosCodeEd;}
			set{_searchPartsPosCodeEd = value;}
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
        /// 部位コード（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>PartsPosCodePrintWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsPosCodePrintWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PartsPosCodePrintWork()
        {
        }
        # endregion ■ Constructor ■
    }
}
