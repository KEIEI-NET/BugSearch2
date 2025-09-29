using System;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ArrivalListParamWork
	/// <summary>
	///                      入荷確認表抽出条件クラスワークワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   入荷確認表抽出条件クラスワークワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2009/04/07  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ArrivalListParamWork
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

		/// <summary>開始仕入担当者コード</summary>
		private string _stockAgentCodeSt = "";

		/// <summary>終了仕入担当者コード</summary>
		private string _stockAgentCodeEd = "";

		/// <summary>開始仕入伝票番号</summary>
		private Int32 _supplierSlipNoSt;

		/// <summary>終了仕入伝票番号</summary>
		private Int32 _supplierSlipNoEd;

		/// <summary>開始仕入日付</summary>
		/// <remarks>YYYYMMDD (未入力は0)</remarks>
		private Int32 _stockDateSt;

		/// <summary>終了仕入日付</summary>
		/// <remarks>YYYYMMDD (未入力は0)</remarks>
		private Int32 _stockDateEd;

		/// <summary>開始入荷日付</summary>
		/// <remarks>YYYYMMDD (未入力は0)</remarks>
		private Int32 _arrivalGoodsDaySt;

		/// <summary>終了入荷日付</summary>
		/// <remarks>YYYYMMDD (未入力は0)</remarks>
		private Int32 _arrivalGoodsDayEd;

		/// <summary>開始入力日付</summary>
		/// <remarks>YYYYMMDD (未入力は0)</remarks>
		private Int32 _inputDaySt;

		/// <summary>終了入力日付</summary>
		/// <remarks>YYYYMMDD (未入力は0)</remarks>
		private Int32 _inputDayEd;

		/// <summary>作表区分</summary>
		/// <remarks>0:全て印刷,1:残のみ   ※未使用</remarks>
		private Int32 _makeShowDiv;

		/// <summary>伝票区分</summary>
		/// <remarks>0:入荷,1:返品,2:入荷＋返品</remarks>
		private Int32 _slipDiv;

		/// <summary>出力順</summary>
		/// <remarks>0:仕入先→入荷日→伝票番号、1:入荷日→仕入先→伝票番号、2:担当者→仕入先→入荷日→伝票番号、3:入荷日→伝票番号、4:伝票番号</remarks>
		private Int32 _sortOrder;

		/// <summary>赤伝区分</summary>
		/// <remarks>0:黒伝,1:赤伝,2:元黒,3:全て</remarks>
		private Int32 _debitNoteDiv;

		/// <summary>開始相手先伝票番号</summary>
		private string _st_PartySaleSlipNum = "";

		/// <summary>終了相手先伝票番号</summary>
		private string _ed_PartySaleSlipNum = "";


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

		/// public propaty name  :  StockAgentCodeSt
		/// <summary>開始仕入担当者コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始仕入担当者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockAgentCodeSt
		{
			get{return _stockAgentCodeSt;}
			set{_stockAgentCodeSt = value;}
		}

		/// public propaty name  :  StockAgentCodeEd
		/// <summary>終了仕入担当者コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了仕入担当者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockAgentCodeEd
		{
			get{return _stockAgentCodeEd;}
			set{_stockAgentCodeEd = value;}
		}

		/// public propaty name  :  SupplierSlipNoSt
		/// <summary>開始仕入伝票番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始仕入伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierSlipNoSt
		{
			get{return _supplierSlipNoSt;}
			set{_supplierSlipNoSt = value;}
		}

		/// public propaty name  :  SupplierSlipNoEd
		/// <summary>終了仕入伝票番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了仕入伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierSlipNoEd
		{
			get{return _supplierSlipNoEd;}
			set{_supplierSlipNoEd = value;}
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

		/// public propaty name  :  ArrivalGoodsDaySt
		/// <summary>開始入荷日付プロパティ</summary>
		/// <value>YYYYMMDD (未入力は0)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始入荷日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ArrivalGoodsDaySt
		{
			get{return _arrivalGoodsDaySt;}
			set{_arrivalGoodsDaySt = value;}
		}

		/// public propaty name  :  ArrivalGoodsDayEd
		/// <summary>終了入荷日付プロパティ</summary>
		/// <value>YYYYMMDD (未入力は0)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了入荷日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ArrivalGoodsDayEd
		{
			get{return _arrivalGoodsDayEd;}
			set{_arrivalGoodsDayEd = value;}
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
		/// <summary>作表区分プロパティ</summary>
		/// <value>0:全て印刷,1:残のみ   ※未使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作表区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MakeShowDiv
		{
			get{return _makeShowDiv;}
			set{_makeShowDiv = value;}
		}

		/// public propaty name  :  SlipDiv
		/// <summary>伝票区分プロパティ</summary>
		/// <value>0:入荷,1:返品,2:入荷＋返品</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipDiv
		{
			get{return _slipDiv;}
			set{_slipDiv = value;}
		}

		/// public propaty name  :  SortOrder
		/// <summary>出力順プロパティ</summary>
		/// <value>0:仕入先→入荷日→伝票番号、1:入荷日→仕入先→伝票番号、2:担当者→仕入先→入荷日→伝票番号、3:入荷日→伝票番号、4:伝票番号</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力順プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SortOrder
		{
			get{return _sortOrder;}
			set{_sortOrder = value;}
		}

		/// public propaty name  :  DebitNoteDiv
		/// <summary>赤伝区分プロパティ</summary>
		/// <value>0:黒伝,1:赤伝,2:元黒,3:全て</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   赤伝区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DebitNoteDiv
		{
			get{return _debitNoteDiv;}
			set{_debitNoteDiv = value;}
		}

		/// public propaty name  :  St_PartySaleSlipNum
		/// <summary>開始相手先伝票番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始相手先伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_PartySaleSlipNum
		{
			get{return _st_PartySaleSlipNum;}
			set{_st_PartySaleSlipNum = value;}
		}

		/// public propaty name  :  Ed_PartySaleSlipNum
		/// <summary>終了相手先伝票番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了相手先伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_PartySaleSlipNum
		{
			get{return _ed_PartySaleSlipNum;}
			set{_ed_PartySaleSlipNum = value;}
		}


		/// <summary>
		/// 入荷確認表抽出条件クラスワークワークコンストラクタ
		/// </summary>
		/// <returns>ArrivalListParamWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ArrivalListParamWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrivalListParamWork()
		{
		}

	}

}
