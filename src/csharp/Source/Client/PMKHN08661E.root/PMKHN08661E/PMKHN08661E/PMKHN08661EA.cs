using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   GoodsSetPrintWork
	/// <summary>
	///                      セットマスタ（印刷）条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   セットマスタ（印刷）条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
    public class GoodsSetPrintWork 
    {
        # region ■ private field ■
        /// <summary>開始親メーカーコード</summary>
		private Int32 _parentGoodsMakerCdSt;

		/// <summary>終了親メーカーコード</summary>
		private Int32 _parentGoodsMakerCdEd;

		/// <summary>開始親商品番号</summary>
		private string _parentGoodsNoSt = "";

		/// <summary>終了親商品番号</summary>
		private string _parentGoodsNoEd = "";

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
        /// public propaty name  :  ParentGoodsMakerCdSt
		/// <summary>開始親メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始親メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ParentGoodsMakerCdSt
		{
			get{return _parentGoodsMakerCdSt;}
			set{_parentGoodsMakerCdSt = value;}
		}

		/// public propaty name  :  ParentGoodsMakerCdEd
		/// <summary>終了親メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了親メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ParentGoodsMakerCdEd
		{
			get{return _parentGoodsMakerCdEd;}
			set{_parentGoodsMakerCdEd = value;}
		}

		/// public propaty name  :  ParentGoodsNoSt
		/// <summary>開始親商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始親商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ParentGoodsNoSt
		{
			get{return _parentGoodsNoSt;}
			set{_parentGoodsNoSt = value;}
		}

		/// public propaty name  :  ParentGoodsNoEd
		/// <summary>終了親商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了親商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ParentGoodsNoEd
		{
			get{return _parentGoodsNoEd;}
			set{_parentGoodsNoEd = value;}
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
        /// セット（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>GoodsSetPrintWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsSetPrintWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsSetPrintWork()
        {
        }
        # endregion ■ Constructor ■
    }
}
