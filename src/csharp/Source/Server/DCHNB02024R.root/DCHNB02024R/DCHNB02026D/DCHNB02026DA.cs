using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   OrderConfShWork
	/// <summary>
	///                      受注貸出確認表抽出条件クラスワークワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   受注貸出確認表抽出条件クラスワークワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/07/04  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class OrderConfShWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>実績計上拠点コードリスト</summary>
		/// <remarks>(配列)　全社指定は{""}</remarks>
		private string[] _resultsAddUpSecList;

		/// <summary>論理削除区分</summary>
		/// <remarks>0:有効,1:論理削除,2:保留,3:完全削除</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>受注ステータス</summary>
		private Int32 _acptAnOdrStatus;

		/// <summary>売上日付(開始)</summary>
		private Int32 _salesDateSt;

		/// <summary>売上日付(終了)</summary>
		private Int32 _salesDateEd;

		/// <summary>出荷日付(開始)</summary>
		private Int32 _shipmentDaySt;

		/// <summary>出荷日付(終了)</summary>
		private Int32 _shipmentDayEd;

		/// <summary>入力日付(開始)</summary>
		private Int32 _searchSlipDateSt;

		/// <summary>入力日付(終了)</summary>
		private Int32 _searchSlipDateEd;

		/// <summary>得意先コード(開始)</summary>
		private Int32 _customerCodeSt;

		/// <summary>得意先コード(終了)</summary>
		private Int32 _customerCodeEd;

		/// <summary>赤伝区分</summary>
		/// <remarks>0:黒伝,1:赤伝,2:元黒　　※全ては-1</remarks>
		private Int32 _debitNoteDiv;

		/// <summary>売上伝票区分</summary>
		/// <remarks>0:売上,1:返品　※全ては-1</remarks>
		private Int32 _salesSlipCd;

		/// <summary>売上伝票番号(開始)</summary>
		private string _salesSlipNumSt = "";

		/// <summary>売上伝票番号(終了)</summary>
		private string _salesSlipNumEd = "";

		/// <summary>販売従業員コード(開始)</summary>
		private string _salesEmployeeCdSt = "";

		/// <summary>販売従業員コード(終了)</summary>
		private string _salesEmployeeCdEd = "";

		/// <summary>受付従業員コード(開始)</summary>
		private string _frontEmployeeCdSt = "";

		/// <summary>受付従業員コード(終了)</summary>
		private string _frontEmployeeCdEd = "";

		/// <summary>入力担当者コード(開始)</summary>
		private string _salesInputCodeSt = "";

		/// <summary>入力担当者コード(終了)</summary>
		private string _salesInputCodeEd = "";

		/// <summary>粗利チェック下限</summary>
		/// <remarks>粗利チェックの下限値（％で入力）　XX.X％　以上</remarks>
		private Double _grsProfitCheckLower;

		/// <summary>粗利チェック適正</summary>
		/// <remarks>粗利チェックの適正値（％で入力）　XX.X％　以上</remarks>
		private Double _grsProfitCheckBest;

		/// <summary>粗利チェック上限</summary>
		/// <remarks>粗利チェックの上限値（％で入力）　XX.X％　以上</remarks>
		private Double _grsProfitCheckUpper;

		/// <summary>粗利チェック1(マーク)</summary>
		private string _grossMargin1Mark = "";

		/// <summary>粗利チェック2(マーク)</summary>
		private string _grossMargin2Mark = "";

		/// <summary>粗利チェック3(マーク)</summary>
		private string _grossMargin3Mark = "";

		/// <summary>粗利チェック4(マーク)</summary>
		private string _grossMargin4Mark = "";

		/// <summary>発行タイプ</summary>
		/// <remarks>0:受注,1:受注計上済み,2:貸出,3:貸出計上済み,4:受注(UOE受信),5:受注計上済み(UOE受信)</remarks>
		private Int32 _printDiv;


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

		/// public propaty name  :  ResultsAddUpSecList
		/// <summary>実績計上拠点コードリストプロパティ</summary>
		/// <value>(配列)　全社指定は{""}</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   実績計上拠点コードリストプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public string[] ResultsAddUpSecList
		{
			get{return _resultsAddUpSecList;}
			set{_resultsAddUpSecList = value;}
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>論理削除区分プロパティ</summary>
		/// <value>0:有効,1:論理削除,2:保留,3:完全削除</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   論理削除区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 LogicalDeleteCode
		{
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
		}

		/// public propaty name  :  AcptAnOdrStatus
		/// <summary>受注ステータスプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注ステータスプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcptAnOdrStatus
		{
			get{return _acptAnOdrStatus;}
			set{_acptAnOdrStatus = value;}
		}

		/// public propaty name  :  SalesDateSt
		/// <summary>売上日付(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上日付(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesDateSt
		{
			get{return _salesDateSt;}
			set{_salesDateSt = value;}
		}

		/// public propaty name  :  SalesDateEd
		/// <summary>売上日付(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上日付(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesDateEd
		{
			get{return _salesDateEd;}
			set{_salesDateEd = value;}
		}

		/// public propaty name  :  ShipmentDaySt
		/// <summary>出荷日付(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷日付(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ShipmentDaySt
		{
			get{return _shipmentDaySt;}
			set{_shipmentDaySt = value;}
		}

		/// public propaty name  :  ShipmentDayEd
		/// <summary>出荷日付(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷日付(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ShipmentDayEd
		{
			get{return _shipmentDayEd;}
			set{_shipmentDayEd = value;}
		}

		/// public propaty name  :  SearchSlipDateSt
		/// <summary>入力日付(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力日付(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SearchSlipDateSt
		{
			get{return _searchSlipDateSt;}
			set{_searchSlipDateSt = value;}
		}

		/// public propaty name  :  SearchSlipDateEd
		/// <summary>入力日付(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力日付(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SearchSlipDateEd
		{
			get{return _searchSlipDateEd;}
			set{_searchSlipDateEd = value;}
		}

		/// public propaty name  :  CustomerCodeSt
		/// <summary>得意先コード(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コード(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCodeSt
		{
			get{return _customerCodeSt;}
			set{_customerCodeSt = value;}
		}

		/// public propaty name  :  CustomerCodeEd
		/// <summary>得意先コード(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コード(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCodeEd
		{
			get{return _customerCodeEd;}
			set{_customerCodeEd = value;}
		}

		/// public propaty name  :  DebitNoteDiv
		/// <summary>赤伝区分プロパティ</summary>
		/// <value>0:黒伝,1:赤伝,2:元黒　　※全ては-1</value>
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

		/// public propaty name  :  SalesSlipCd
		/// <summary>売上伝票区分プロパティ</summary>
		/// <value>0:売上,1:返品　※全ては-1</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesSlipCd
		{
			get{return _salesSlipCd;}
			set{_salesSlipCd = value;}
		}

		/// public propaty name  :  SalesSlipNumSt
		/// <summary>売上伝票番号(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票番号(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesSlipNumSt
		{
			get{return _salesSlipNumSt;}
			set{_salesSlipNumSt = value;}
		}

		/// public propaty name  :  SalesSlipNumEd
		/// <summary>売上伝票番号(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票番号(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesSlipNumEd
		{
			get{return _salesSlipNumEd;}
			set{_salesSlipNumEd = value;}
		}

		/// public propaty name  :  SalesEmployeeCdSt
		/// <summary>販売従業員コード(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売従業員コード(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesEmployeeCdSt
		{
			get{return _salesEmployeeCdSt;}
			set{_salesEmployeeCdSt = value;}
		}

		/// public propaty name  :  SalesEmployeeCdEd
		/// <summary>販売従業員コード(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売従業員コード(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesEmployeeCdEd
		{
			get{return _salesEmployeeCdEd;}
			set{_salesEmployeeCdEd = value;}
		}

		/// public propaty name  :  FrontEmployeeCdSt
		/// <summary>受付従業員コード(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受付従業員コード(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FrontEmployeeCdSt
		{
			get{return _frontEmployeeCdSt;}
			set{_frontEmployeeCdSt = value;}
		}

		/// public propaty name  :  FrontEmployeeCdEd
		/// <summary>受付従業員コード(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受付従業員コード(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FrontEmployeeCdEd
		{
			get{return _frontEmployeeCdEd;}
			set{_frontEmployeeCdEd = value;}
		}

		/// public propaty name  :  SalesInputCodeSt
		/// <summary>入力担当者コード(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力担当者コード(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesInputCodeSt
		{
			get{return _salesInputCodeSt;}
			set{_salesInputCodeSt = value;}
		}

		/// public propaty name  :  SalesInputCodeEd
		/// <summary>入力担当者コード(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力担当者コード(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesInputCodeEd
		{
			get{return _salesInputCodeEd;}
			set{_salesInputCodeEd = value;}
		}

		/// public propaty name  :  GrsProfitCheckLower
		/// <summary>粗利チェック下限プロパティ</summary>
		/// <value>粗利チェックの下限値（％で入力）　XX.X％　以上</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック下限プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double GrsProfitCheckLower
		{
			get{return _grsProfitCheckLower;}
			set{_grsProfitCheckLower = value;}
		}

		/// public propaty name  :  GrsProfitCheckBest
		/// <summary>粗利チェック適正プロパティ</summary>
		/// <value>粗利チェックの適正値（％で入力）　XX.X％　以上</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック適正プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double GrsProfitCheckBest
		{
			get{return _grsProfitCheckBest;}
			set{_grsProfitCheckBest = value;}
		}

		/// public propaty name  :  GrsProfitCheckUpper
		/// <summary>粗利チェック上限プロパティ</summary>
		/// <value>粗利チェックの上限値（％で入力）　XX.X％　以上</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック上限プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double GrsProfitCheckUpper
		{
			get{return _grsProfitCheckUpper;}
			set{_grsProfitCheckUpper = value;}
		}

		/// public propaty name  :  GrossMargin1Mark
		/// <summary>粗利チェック1(マーク)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック1(マーク)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GrossMargin1Mark
		{
			get{return _grossMargin1Mark;}
			set{_grossMargin1Mark = value;}
		}

		/// public propaty name  :  GrossMargin2Mark
		/// <summary>粗利チェック2(マーク)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック2(マーク)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GrossMargin2Mark
		{
			get{return _grossMargin2Mark;}
			set{_grossMargin2Mark = value;}
		}

		/// public propaty name  :  GrossMargin3Mark
		/// <summary>粗利チェック3(マーク)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック3(マーク)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GrossMargin3Mark
		{
			get{return _grossMargin3Mark;}
			set{_grossMargin3Mark = value;}
		}

		/// public propaty name  :  GrossMargin4Mark
		/// <summary>粗利チェック4(マーク)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック4(マーク)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GrossMargin4Mark
		{
			get{return _grossMargin4Mark;}
			set{_grossMargin4Mark = value;}
		}

		/// public propaty name  :  PrintDiv
		/// <summary>発行タイププロパティ</summary>
		/// <value>0:受注,1:受注計上済み,2:貸出,3:貸出計上済み,4:受注(UOE受信),5:受注計上済み(UOE受信)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発行タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrintDiv
		{
			get{return _printDiv;}
			set{_printDiv = value;}
		}


		/// <summary>
		/// 受注貸出確認表抽出条件クラスワークワークコンストラクタ
		/// </summary>
		/// <returns>OrderConfShWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   OrderConfShWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public OrderConfShWork()
		{
		}

	}

}
