using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   PartsSubstPrintWork
	/// <summary>
	///                      代替マスタ（印刷）条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   代替マスタ（印刷）条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
    public class PartsSubstPrintWork 
    {
        # region ■ private field ■
        /// <summary>開始変換元メーカーコード</summary>
		private Int32 _chgSrcMakerCdSt;

		/// <summary>終了変換元メーカーコード</summary>
		private Int32 _chgSrcMakerCdEd;

		/// <summary>開始変換元商品番号</summary>
		private string _chgSrcGoodsNoSt = "";

		/// <summary>終了変換元商品番号</summary>
		private string _chgSrcGoodsNoEd = "";

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
        /// public propaty name  :  ChgSrcMakerCdSt
		/// <summary>開始変換元メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始変換元メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ChgSrcMakerCdSt
		{
			get{return _chgSrcMakerCdSt;}
			set{_chgSrcMakerCdSt = value;}
		}

		/// public propaty name  :  ChgSrcMakerCdEd
		/// <summary>終了変換元メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了変換元メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ChgSrcMakerCdEd
		{
			get{return _chgSrcMakerCdEd;}
			set{_chgSrcMakerCdEd = value;}
		}

		/// public propaty name  :  ChgSrcGoodsNoSt
		/// <summary>開始変換元商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始変換元商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ChgSrcGoodsNoSt
		{
			get{return _chgSrcGoodsNoSt;}
			set{_chgSrcGoodsNoSt = value;}
		}

		/// public propaty name  :  ChgSrcGoodsNoEd
		/// <summary>終了変換元商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了変換元商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ChgSrcGoodsNoEd
		{
			get{return _chgSrcGoodsNoEd;}
			set{_chgSrcGoodsNoEd = value;}
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
        /// 代替（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>PartsSubstPrintWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsSubstPrintWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PartsSubstPrintWork()
        {
        }
        # endregion ■ Constructor ■
    }
}
