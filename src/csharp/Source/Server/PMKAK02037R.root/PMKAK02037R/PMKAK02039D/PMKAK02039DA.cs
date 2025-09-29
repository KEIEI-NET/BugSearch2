//***************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 仕入返品予定一覧表
// プログラム概要   : 仕入返品予定一覧表 抽出条件クラスワーク
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : FSI高橋 文彰
// 作 成 日   2013/01/28 修正内容 : 新規作成 仕入返品予定機能対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   StockRetPlnParamWork
	/// <summary>
	///                      仕入返品予定一覧表抽出条件クラスワークワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入返品予定一覧表抽出条件クラスワークワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2009/04/07  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockRetPlnParamWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";
		/// <summary>拠点コード</summary>
		/// <remarks>(配列)　全社指定は{""}</remarks>
		private string[] _sectionCodes;
		/// <summary>開始仕入先コード</summary>
		private Int32 _supplierCdSt;
		/// <summary>終了仕入先コード</summary>
		private Int32 _supplierCdEd;
		/// <summary>開始仕入日付</summary>
		private Int32 _stockDateSt;
		/// <summary>終了仕入日付</summary>
		private Int32 _stockDateEd;
		/// <summary>開始入力日付</summary>
		private Int32 _inputDaySt;
		/// <summary>終了入力日付</summary>
		private Int32 _inputDayEd;
		/// <summary>発行タイプ</summary>
		private Int32 _makeShowDiv;
		/// <summary>出力指定</summary>
		private Int32 _slipDiv;
        /// <summary>日付指定</summary>
        private Int32 _printDailyFooter;
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
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
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
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

		/// public propaty name  :  SupplierCdSt
		/// <summary>開始仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierCdSt
		{
			get{return _supplierCdSt;}
			set{_supplierCdSt = value;}
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
			get{return _supplierCdEd;}
			set{_supplierCdEd = value;}
		}

		/// public propaty name  :  StockDateSt
		/// <summary>開始仕入日付プロパティ</summary>
		/// <value>YYYYMMDD (未入力は0)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始仕入日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockDateSt
		{
			get{return _stockDateSt;}
			set{_stockDateSt = value;}
		}

		/// public propaty name  :  StockDateEd
		/// <summary>終了仕入日付プロパティ</summary>
		/// <value>YYYYMMDD (未入力は0)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了仕入日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockDateEd
		{
			get{return _stockDateEd;}
			set{_stockDateEd = value;}
		}

		/// public propaty name  :  InputDaySt
		/// <summary>開始入力日付プロパティ</summary>
		/// <value>YYYYMMDD (未入力は0)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始入力日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InputDaySt
		{
			get{return _inputDaySt;}
			set{_inputDaySt = value;}
		}

		/// public propaty name  :  InputDayEd
		/// <summary>終了入力日付プロパティ</summary>
		/// <value>YYYYMMDD (未入力は0)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了入力日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InputDayEd
		{
			get{return _inputDayEd;}
			set{_inputDayEd = value;}
		}

		/// public propaty name  :  MakeShowDiv
		/// <summary>発行タイププロパティ</summary>
		/// <value>0:全て印刷,1:残のみ   ※未使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発行タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MakeShowDiv
		{
			get{return _makeShowDiv;}
			set{_makeShowDiv = value;}
		}

		/// public propaty name  :  SlipDiv
		/// <summary>出力指定プロパティ</summary>
		/// <value>0:返品予定のみ,1:返品済のみ,2:すべて</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力指定プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipDiv
		{
			get{return _slipDiv;}
			set{_slipDiv = value;}
		}

        /// public propaty name  :  DebitNoteDiv
        /// <summary>日付指定プロパティ</summary>
        /// <value>0:通常,1:削除</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   日付指定プロパティィ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintDailyFooter
        {
            get { return _printDailyFooter; }
            set { _printDailyFooter = value; }
        }

		/// <summary>
		/// 仕入返品予定一覧表抽出条件クラスワークワークコンストラクタ
		/// </summary>
		/// <returns>StockRetPlnParamWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockRetPlnParamWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockRetPlnParamWork()
		{
		}

	}

}
