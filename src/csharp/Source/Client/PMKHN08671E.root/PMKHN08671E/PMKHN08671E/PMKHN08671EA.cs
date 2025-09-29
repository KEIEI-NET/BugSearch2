using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   NoteGuidPrintWork
	/// <summary>
	///                      車種マスタ（印刷）条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   車種マスタ（印刷）条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
    public class ModelNamePrintWork 
    {
        # region ■ private field ■
        /// <summary>開始メーカーコード</summary>
		private Int32 _makerCodeSt;

		/// <summary>開始車種コード</summary>
		private Int32 _modelCodeSt;

		/// <summary>開始車種サブコード</summary>
		private Int32 _modelSubCodeSt;

		/// <summary>終了メーカーコード</summary>
		private Int32 _makerCodeEd;

		/// <summary>終了車種コード</summary>
		private Int32 _modelCodeEd;

		/// <summary>終了車種サブコード</summary>
		private Int32 _modelSubCodeEd;

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
        /// public propaty name  :  MakerCodeSt
		/// <summary>開始メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MakerCodeSt
		{
			get{return _makerCodeSt;}
			set{_makerCodeSt = value;}
		}

		/// public propaty name  :  ModelCodeSt
		/// <summary>開始車種コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始車種コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ModelCodeSt
		{
			get{return _modelCodeSt;}
			set{_modelCodeSt = value;}
		}

		/// public propaty name  :  ModelSubCodeSt
		/// <summary>開始車種サブコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始車種サブコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ModelSubCodeSt
		{
			get{return _modelSubCodeSt;}
			set{_modelSubCodeSt = value;}
		}

		/// public propaty name  :  MakerCodeEd
		/// <summary>終了メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MakerCodeEd
		{
			get{return _makerCodeEd;}
			set{_makerCodeEd = value;}
		}

		/// public propaty name  :  ModelCodeEd
		/// <summary>終了車種コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了車種コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ModelCodeEd
		{
			get{return _modelCodeEd;}
			set{_modelCodeEd = value;}
		}

		/// public propaty name  :  ModelSubCodeEd
		/// <summary>終了車種サブコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了車種サブコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ModelSubCodeEd
		{
			get{return _modelSubCodeEd;}
			set{_modelSubCodeEd = value;}
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
        /// 車種名称（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>ModelNamePrintWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ModelNamePrintWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ModelNamePrintWork()
        {
        }
        # endregion ■ Constructor ■
    }
}
