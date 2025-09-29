using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ExtrInfo_DemandDtlGrpSum
	/// <summary>
	///                      請求書(鑑部明細情報)抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   請求書(鑑部明細情報)抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/06/29  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class ExtrInfo_DemandDtlGrpSum
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>計上拠点コード</summary>
		/// <remarks>集計の対象となっている拠点コード</remarks>
		private string _addUpSecCode = "";

		/// <summary>抽出対象計上日(開始)</summary>
		/// <remarks>"YYYYMMDD"  今回締開始計上日となる年月日</remarks>
		private Int32 _addUpADateSt;

		/// <summary>抽出対象計上日(終了)</summary>
		/// <remarks>"YYYYMMDD"  今回締終了計上日となる年月日</remarks>
		private Int32 _addUpADateEd;

		/// <summary>請求先コード</summary>
		private Int32 _claimCode;

		/// <summary>入金明細抽出有無</summary>
		private bool _isExtractDepo;

		/// <summary>件数出力設定</summary>
		private Int32 _countSheets;

		/// <summary>請求集計方法(出力順)1</summary>
		/// <remarks>クライアントから対象項目IDを投げる</remarks>
		private string _demandSumOdr1 = "";

		/// <summary>請求集計方法(出力順)付随1</summary>
		/// <remarks>クライアントから対象項目IDを投げる</remarks>
		private string _demandSumOdrAttend1 = "";

		/// <summary>請求集計方法(出力順)2</summary>
		/// <remarks>クライアントから対象項目IDを投げる</remarks>
		private string _demandSumOdr2 = "";

		/// <summary>請求集計方法(出力順)付随2</summary>
		/// <remarks>クライアントから対象項目IDを投げる</remarks>
		private string _demandSumOdrAttend2 = "";

		/// <summary>請求集計方法(出力順)3</summary>
		/// <remarks>クライアントから対象項目IDを投げる</remarks>
		private string _demandSumOdr3 = "";

		/// <summary>請求集計方法(出力順)付随3</summary>
		/// <remarks>クライアントから対象項目IDを投げる</remarks>
		private string _demandSumOdrAttend3 = "";

		/// <summary>支払集計方法(出力順)1</summary>
		/// <remarks>クライアントから対象項目IDを投げる</remarks>
		private string _paymentSumOdr1 = "";

		/// <summary>支払集計方法(出力順)付随1</summary>
		/// <remarks>クライアントから対象項目IDを投げる</remarks>
		private string _paymentSumOdrAttend1 = "";

		/// <summary>支払集計方法(出力順)2</summary>
		/// <remarks>クライアントから対象項目IDを投げる</remarks>
		private string _paymentSumOdr2 = "";

		/// <summary>支払集計方法(出力順)付随2</summary>
		/// <remarks>クライアントから対象項目IDを投げる</remarks>
		private string _paymentSumOdrAttend2 = "";

		/// <summary>支払集計方法(出力順)3</summary>
		/// <remarks>クライアントから対象項目IDを投げる</remarks>
		private string _paymentSumOdr3 = "";

		/// <summary>支払集計方法(出力順)付随3</summary>
		/// <remarks>クライアントから対象項目IDを投げる</remarks>
		private string _paymentSumOdrAttend3 = "";

		/// <summary>強制請求商品区分</summary>
		private String[] _forceDmdMggCd;

		/// <summary>強制支払商品区分</summary>
		private String[] _forcePayMggCd;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>計上拠点名称</summary>
		private string _addUpSecName = "";


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

		/// public propaty name  :  AddUpSecCode
		/// <summary>計上拠点コードプロパティ</summary>
		/// <value>集計の対象となっている拠点コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpSecCode
		{
			get{return _addUpSecCode;}
			set{_addUpSecCode = value;}
		}

		/// public propaty name  :  AddUpADateSt
		/// <summary>抽出対象計上日(開始)プロパティ</summary>
		/// <value>"YYYYMMDD"  今回締開始計上日となる年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出対象計上日(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AddUpADateSt
		{
			get{return _addUpADateSt;}
			set{_addUpADateSt = value;}
		}

		/// public propaty name  :  AddUpADateEd
		/// <summary>抽出対象計上日(終了)プロパティ</summary>
		/// <value>"YYYYMMDD"  今回締終了計上日となる年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出対象計上日(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AddUpADateEd
		{
			get{return _addUpADateEd;}
			set{_addUpADateEd = value;}
		}

		/// public propaty name  :  ClaimCode
		/// <summary>請求先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ClaimCode
		{
			get{return _claimCode;}
			set{_claimCode = value;}
		}

		/// public propaty name  :  IsExtractDepo
		/// <summary>入金明細抽出有無プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金明細抽出有無プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool IsExtractDepo
		{
			get{return _isExtractDepo;}
			set{_isExtractDepo = value;}
		}

		/// public propaty name  :  CountSheets
		/// <summary>件数出力設定プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   件数出力設定プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CountSheets
		{
			get{return _countSheets;}
			set{_countSheets = value;}
		}

		/// public propaty name  :  DemandSumOdr1
		/// <summary>請求集計方法(出力順)1プロパティ</summary>
		/// <value>クライアントから対象項目IDを投げる</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求集計方法(出力順)1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DemandSumOdr1
		{
			get{return _demandSumOdr1;}
			set{_demandSumOdr1 = value;}
		}

		/// public propaty name  :  DemandSumOdrAttend1
		/// <summary>請求集計方法(出力順)付随1プロパティ</summary>
		/// <value>クライアントから対象項目IDを投げる</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求集計方法(出力順)付随1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DemandSumOdrAttend1
		{
			get{return _demandSumOdrAttend1;}
			set{_demandSumOdrAttend1 = value;}
		}

		/// public propaty name  :  DemandSumOdr2
		/// <summary>請求集計方法(出力順)2プロパティ</summary>
		/// <value>クライアントから対象項目IDを投げる</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求集計方法(出力順)2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DemandSumOdr2
		{
			get{return _demandSumOdr2;}
			set{_demandSumOdr2 = value;}
		}

		/// public propaty name  :  DemandSumOdrAttend2
		/// <summary>請求集計方法(出力順)付随2プロパティ</summary>
		/// <value>クライアントから対象項目IDを投げる</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求集計方法(出力順)付随2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DemandSumOdrAttend2
		{
			get{return _demandSumOdrAttend2;}
			set{_demandSumOdrAttend2 = value;}
		}

		/// public propaty name  :  DemandSumOdr3
		/// <summary>請求集計方法(出力順)3プロパティ</summary>
		/// <value>クライアントから対象項目IDを投げる</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求集計方法(出力順)3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DemandSumOdr3
		{
			get{return _demandSumOdr3;}
			set{_demandSumOdr3 = value;}
		}

		/// public propaty name  :  DemandSumOdrAttend3
		/// <summary>請求集計方法(出力順)付随3プロパティ</summary>
		/// <value>クライアントから対象項目IDを投げる</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求集計方法(出力順)付随3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DemandSumOdrAttend3
		{
			get{return _demandSumOdrAttend3;}
			set{_demandSumOdrAttend3 = value;}
		}

		/// public propaty name  :  PaymentSumOdr1
		/// <summary>支払集計方法(出力順)1プロパティ</summary>
		/// <value>クライアントから対象項目IDを投げる</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払集計方法(出力順)1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PaymentSumOdr1
		{
			get{return _paymentSumOdr1;}
			set{_paymentSumOdr1 = value;}
		}

		/// public propaty name  :  PaymentSumOdrAttend1
		/// <summary>支払集計方法(出力順)付随1プロパティ</summary>
		/// <value>クライアントから対象項目IDを投げる</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払集計方法(出力順)付随1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PaymentSumOdrAttend1
		{
			get{return _paymentSumOdrAttend1;}
			set{_paymentSumOdrAttend1 = value;}
		}

		/// public propaty name  :  PaymentSumOdr2
		/// <summary>支払集計方法(出力順)2プロパティ</summary>
		/// <value>クライアントから対象項目IDを投げる</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払集計方法(出力順)2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PaymentSumOdr2
		{
			get{return _paymentSumOdr2;}
			set{_paymentSumOdr2 = value;}
		}

		/// public propaty name  :  PaymentSumOdrAttend2
		/// <summary>支払集計方法(出力順)付随2プロパティ</summary>
		/// <value>クライアントから対象項目IDを投げる</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払集計方法(出力順)付随2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PaymentSumOdrAttend2
		{
			get{return _paymentSumOdrAttend2;}
			set{_paymentSumOdrAttend2 = value;}
		}

		/// public propaty name  :  PaymentSumOdr3
		/// <summary>支払集計方法(出力順)3プロパティ</summary>
		/// <value>クライアントから対象項目IDを投げる</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払集計方法(出力順)3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PaymentSumOdr3
		{
			get{return _paymentSumOdr3;}
			set{_paymentSumOdr3 = value;}
		}

		/// public propaty name  :  PaymentSumOdrAttend3
		/// <summary>支払集計方法(出力順)付随3プロパティ</summary>
		/// <value>クライアントから対象項目IDを投げる</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払集計方法(出力順)付随3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PaymentSumOdrAttend3
		{
			get{return _paymentSumOdrAttend3;}
			set{_paymentSumOdrAttend3 = value;}
		}

		/// public propaty name  :  ForceDmdMggCd
		/// <summary>強制請求商品区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   強制請求商品区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public String[] ForceDmdMggCd
		{
			get{return _forceDmdMggCd;}
			set{_forceDmdMggCd = value;}
		}

		/// public propaty name  :  ForcePayMggCd
		/// <summary>強制支払商品区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   強制支払商品区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public String[] ForcePayMggCd
		{
			get{return _forcePayMggCd;}
			set{_forcePayMggCd = value;}
		}

		/// public propaty name  :  EnterpriseName
		/// <summary>企業名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseName
		{
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}

		/// public propaty name  :  AddUpSecName
		/// <summary>計上拠点名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上拠点名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpSecName
		{
			get{return _addUpSecName;}
			set{_addUpSecName = value;}
		}


		/// <summary>
		/// 請求書(鑑部明細情報)抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>ExtrInfo_DemandDtlGrpSumクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandDtlGrpSumクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_DemandDtlGrpSum()
		{
		}

		/// <summary>
		/// 請求書(鑑部明細情報)抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="addUpSecCode">計上拠点コード(集計の対象となっている拠点コード)</param>
		/// <param name="addUpADateSt">抽出対象計上日(開始)("YYYYMMDD"  今回締開始計上日となる年月日)</param>
		/// <param name="addUpADateEd">抽出対象計上日(終了)("YYYYMMDD"  今回締終了計上日となる年月日)</param>
		/// <param name="claimCode">請求先コード</param>
		/// <param name="isExtractDepo">入金明細抽出有無</param>
		/// <param name="countSheets">件数出力設定</param>
		/// <param name="demandSumOdr1">請求集計方法(出力順)1(クライアントから対象項目IDを投げる)</param>
		/// <param name="demandSumOdrAttend1">請求集計方法(出力順)付随1(クライアントから対象項目IDを投げる)</param>
		/// <param name="demandSumOdr2">請求集計方法(出力順)2(クライアントから対象項目IDを投げる)</param>
		/// <param name="demandSumOdrAttend2">請求集計方法(出力順)付随2(クライアントから対象項目IDを投げる)</param>
		/// <param name="demandSumOdr3">請求集計方法(出力順)3(クライアントから対象項目IDを投げる)</param>
		/// <param name="demandSumOdrAttend3">請求集計方法(出力順)付随3(クライアントから対象項目IDを投げる)</param>
		/// <param name="paymentSumOdr1">支払集計方法(出力順)1(クライアントから対象項目IDを投げる)</param>
		/// <param name="paymentSumOdrAttend1">支払集計方法(出力順)付随1(クライアントから対象項目IDを投げる)</param>
		/// <param name="paymentSumOdr2">支払集計方法(出力順)2(クライアントから対象項目IDを投げる)</param>
		/// <param name="paymentSumOdrAttend2">支払集計方法(出力順)付随2(クライアントから対象項目IDを投げる)</param>
		/// <param name="paymentSumOdr3">支払集計方法(出力順)3(クライアントから対象項目IDを投げる)</param>
		/// <param name="paymentSumOdrAttend3">支払集計方法(出力順)付随3(クライアントから対象項目IDを投げる)</param>
		/// <param name="forceDmdMggCd">強制請求商品区分</param>
		/// <param name="forcePayMggCd">強制支払商品区分</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="addUpSecName">計上拠点名称</param>
		/// <returns>ExtrInfo_DemandDtlGrpSumクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandDtlGrpSumクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public ExtrInfo_DemandDtlGrpSum(string enterpriseCode, string addUpSecCode, Int32 addUpADateSt, Int32 addUpADateEd, Int32 claimCode, bool isExtractDepo, Int32 countSheets, string demandSumOdr1, string demandSumOdrAttend1, string demandSumOdr2, string demandSumOdrAttend2, string demandSumOdr3, string demandSumOdrAttend3, string paymentSumOdr1, string paymentSumOdrAttend1, string paymentSumOdr2, string paymentSumOdrAttend2, string paymentSumOdr3, string paymentSumOdrAttend3, String[] forceDmdMggCd, String[] forcePayMggCd, string enterpriseName, string addUpSecName)
		{
			this._enterpriseCode = enterpriseCode;
			this._addUpSecCode = addUpSecCode;
			this._addUpADateSt = addUpADateSt;
			this._addUpADateEd = addUpADateEd;
			this._claimCode = claimCode;
			this._isExtractDepo = isExtractDepo;
			this._countSheets = countSheets;
			this._demandSumOdr1 = demandSumOdr1;
			this._demandSumOdrAttend1 = demandSumOdrAttend1;
			this._demandSumOdr2 = demandSumOdr2;
			this._demandSumOdrAttend2 = demandSumOdrAttend2;
			this._demandSumOdr3 = demandSumOdr3;
			this._demandSumOdrAttend3 = demandSumOdrAttend3;
			this._paymentSumOdr1 = paymentSumOdr1;
			this._paymentSumOdrAttend1 = paymentSumOdrAttend1;
			this._paymentSumOdr2 = paymentSumOdr2;
			this._paymentSumOdrAttend2 = paymentSumOdrAttend2;
			this._paymentSumOdr3 = paymentSumOdr3;
			this._paymentSumOdrAttend3 = paymentSumOdrAttend3;
			this._forceDmdMggCd = forceDmdMggCd;
			this._forcePayMggCd = forcePayMggCd;
			this._enterpriseName = enterpriseName;
			this._addUpSecName = addUpSecName;

		}

		/// <summary>
		/// 請求書(鑑部明細情報)抽出条件クラス複製処理
		/// </summary>
		/// <returns>ExtrInfo_DemandDtlGrpSumクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいExtrInfo_DemandDtlGrpSumクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_DemandDtlGrpSum Clone()
		{
			return new ExtrInfo_DemandDtlGrpSum(this._enterpriseCode,this._addUpSecCode,this._addUpADateSt,this._addUpADateEd,this._claimCode,this._isExtractDepo,this._countSheets,this._demandSumOdr1,this._demandSumOdrAttend1,this._demandSumOdr2,this._demandSumOdrAttend2,this._demandSumOdr3,this._demandSumOdrAttend3,this._paymentSumOdr1,this._paymentSumOdrAttend1,this._paymentSumOdr2,this._paymentSumOdrAttend2,this._paymentSumOdr3,this._paymentSumOdrAttend3,this._forceDmdMggCd,this._forcePayMggCd,this._enterpriseName,this._addUpSecName);
		}

		/// <summary>
		/// 請求書(鑑部明細情報)抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のExtrInfo_DemandDtlGrpSumクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandDtlGrpSumクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(ExtrInfo_DemandDtlGrpSum target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.AddUpSecCode == target.AddUpSecCode)
				 && (this.AddUpADateSt == target.AddUpADateSt)
				 && (this.AddUpADateEd == target.AddUpADateEd)
				 && (this.ClaimCode == target.ClaimCode)
				 && (this.IsExtractDepo == target.IsExtractDepo)
				 && (this.CountSheets == target.CountSheets)
				 && (this.DemandSumOdr1 == target.DemandSumOdr1)
				 && (this.DemandSumOdrAttend1 == target.DemandSumOdrAttend1)
				 && (this.DemandSumOdr2 == target.DemandSumOdr2)
				 && (this.DemandSumOdrAttend2 == target.DemandSumOdrAttend2)
				 && (this.DemandSumOdr3 == target.DemandSumOdr3)
				 && (this.DemandSumOdrAttend3 == target.DemandSumOdrAttend3)
				 && (this.PaymentSumOdr1 == target.PaymentSumOdr1)
				 && (this.PaymentSumOdrAttend1 == target.PaymentSumOdrAttend1)
				 && (this.PaymentSumOdr2 == target.PaymentSumOdr2)
				 && (this.PaymentSumOdrAttend2 == target.PaymentSumOdrAttend2)
				 && (this.PaymentSumOdr3 == target.PaymentSumOdr3)
				 && (this.PaymentSumOdrAttend3 == target.PaymentSumOdrAttend3)
				 && (this.ForceDmdMggCd == target.ForceDmdMggCd)
				 && (this.ForcePayMggCd == target.ForcePayMggCd)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.AddUpSecName == target.AddUpSecName));
		}

		/// <summary>
		/// 請求書(鑑部明細情報)抽出条件クラス比較処理
		/// </summary>
		/// <param name="extrInfo_DemandDtlGrpSum1">
		///                    比較するExtrInfo_DemandDtlGrpSumクラスのインスタンス
		/// </param>
		/// <param name="extrInfo_DemandDtlGrpSum2">比較するExtrInfo_DemandDtlGrpSumクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandDtlGrpSumクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(ExtrInfo_DemandDtlGrpSum extrInfo_DemandDtlGrpSum1, ExtrInfo_DemandDtlGrpSum extrInfo_DemandDtlGrpSum2)
		{
			return ((extrInfo_DemandDtlGrpSum1.EnterpriseCode == extrInfo_DemandDtlGrpSum2.EnterpriseCode)
				 && (extrInfo_DemandDtlGrpSum1.AddUpSecCode == extrInfo_DemandDtlGrpSum2.AddUpSecCode)
				 && (extrInfo_DemandDtlGrpSum1.AddUpADateSt == extrInfo_DemandDtlGrpSum2.AddUpADateSt)
				 && (extrInfo_DemandDtlGrpSum1.AddUpADateEd == extrInfo_DemandDtlGrpSum2.AddUpADateEd)
				 && (extrInfo_DemandDtlGrpSum1.ClaimCode == extrInfo_DemandDtlGrpSum2.ClaimCode)
				 && (extrInfo_DemandDtlGrpSum1.IsExtractDepo == extrInfo_DemandDtlGrpSum2.IsExtractDepo)
				 && (extrInfo_DemandDtlGrpSum1.CountSheets == extrInfo_DemandDtlGrpSum2.CountSheets)
				 && (extrInfo_DemandDtlGrpSum1.DemandSumOdr1 == extrInfo_DemandDtlGrpSum2.DemandSumOdr1)
				 && (extrInfo_DemandDtlGrpSum1.DemandSumOdrAttend1 == extrInfo_DemandDtlGrpSum2.DemandSumOdrAttend1)
				 && (extrInfo_DemandDtlGrpSum1.DemandSumOdr2 == extrInfo_DemandDtlGrpSum2.DemandSumOdr2)
				 && (extrInfo_DemandDtlGrpSum1.DemandSumOdrAttend2 == extrInfo_DemandDtlGrpSum2.DemandSumOdrAttend2)
				 && (extrInfo_DemandDtlGrpSum1.DemandSumOdr3 == extrInfo_DemandDtlGrpSum2.DemandSumOdr3)
				 && (extrInfo_DemandDtlGrpSum1.DemandSumOdrAttend3 == extrInfo_DemandDtlGrpSum2.DemandSumOdrAttend3)
				 && (extrInfo_DemandDtlGrpSum1.PaymentSumOdr1 == extrInfo_DemandDtlGrpSum2.PaymentSumOdr1)
				 && (extrInfo_DemandDtlGrpSum1.PaymentSumOdrAttend1 == extrInfo_DemandDtlGrpSum2.PaymentSumOdrAttend1)
				 && (extrInfo_DemandDtlGrpSum1.PaymentSumOdr2 == extrInfo_DemandDtlGrpSum2.PaymentSumOdr2)
				 && (extrInfo_DemandDtlGrpSum1.PaymentSumOdrAttend2 == extrInfo_DemandDtlGrpSum2.PaymentSumOdrAttend2)
				 && (extrInfo_DemandDtlGrpSum1.PaymentSumOdr3 == extrInfo_DemandDtlGrpSum2.PaymentSumOdr3)
				 && (extrInfo_DemandDtlGrpSum1.PaymentSumOdrAttend3 == extrInfo_DemandDtlGrpSum2.PaymentSumOdrAttend3)
				 && (extrInfo_DemandDtlGrpSum1.ForceDmdMggCd == extrInfo_DemandDtlGrpSum2.ForceDmdMggCd)
				 && (extrInfo_DemandDtlGrpSum1.ForcePayMggCd == extrInfo_DemandDtlGrpSum2.ForcePayMggCd)
				 && (extrInfo_DemandDtlGrpSum1.EnterpriseName == extrInfo_DemandDtlGrpSum2.EnterpriseName)
				 && (extrInfo_DemandDtlGrpSum1.AddUpSecName == extrInfo_DemandDtlGrpSum2.AddUpSecName));
		}
		/// <summary>
		/// 請求書(鑑部明細情報)抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のExtrInfo_DemandDtlGrpSumクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandDtlGrpSumクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(ExtrInfo_DemandDtlGrpSum target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.AddUpSecCode != target.AddUpSecCode)resList.Add("AddUpSecCode");
			if(this.AddUpADateSt != target.AddUpADateSt)resList.Add("AddUpADateSt");
			if(this.AddUpADateEd != target.AddUpADateEd)resList.Add("AddUpADateEd");
			if(this.ClaimCode != target.ClaimCode)resList.Add("ClaimCode");
			if(this.IsExtractDepo != target.IsExtractDepo)resList.Add("IsExtractDepo");
			if(this.CountSheets != target.CountSheets)resList.Add("CountSheets");
			if(this.DemandSumOdr1 != target.DemandSumOdr1)resList.Add("DemandSumOdr1");
			if(this.DemandSumOdrAttend1 != target.DemandSumOdrAttend1)resList.Add("DemandSumOdrAttend1");
			if(this.DemandSumOdr2 != target.DemandSumOdr2)resList.Add("DemandSumOdr2");
			if(this.DemandSumOdrAttend2 != target.DemandSumOdrAttend2)resList.Add("DemandSumOdrAttend2");
			if(this.DemandSumOdr3 != target.DemandSumOdr3)resList.Add("DemandSumOdr3");
			if(this.DemandSumOdrAttend3 != target.DemandSumOdrAttend3)resList.Add("DemandSumOdrAttend3");
			if(this.PaymentSumOdr1 != target.PaymentSumOdr1)resList.Add("PaymentSumOdr1");
			if(this.PaymentSumOdrAttend1 != target.PaymentSumOdrAttend1)resList.Add("PaymentSumOdrAttend1");
			if(this.PaymentSumOdr2 != target.PaymentSumOdr2)resList.Add("PaymentSumOdr2");
			if(this.PaymentSumOdrAttend2 != target.PaymentSumOdrAttend2)resList.Add("PaymentSumOdrAttend2");
			if(this.PaymentSumOdr3 != target.PaymentSumOdr3)resList.Add("PaymentSumOdr3");
			if(this.PaymentSumOdrAttend3 != target.PaymentSumOdrAttend3)resList.Add("PaymentSumOdrAttend3");
			if(this.ForceDmdMggCd != target.ForceDmdMggCd)resList.Add("ForceDmdMggCd");
			if(this.ForcePayMggCd != target.ForcePayMggCd)resList.Add("ForcePayMggCd");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.AddUpSecName != target.AddUpSecName)resList.Add("AddUpSecName");

			return resList;
		}

		/// <summary>
		/// 請求書(鑑部明細情報)抽出条件クラス比較処理
		/// </summary>
		/// <param name="extrInfo_DemandDtlGrpSum1">比較するExtrInfo_DemandDtlGrpSumクラスのインスタンス</param>
		/// <param name="extrInfo_DemandDtlGrpSum2">比較するExtrInfo_DemandDtlGrpSumクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandDtlGrpSumクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(ExtrInfo_DemandDtlGrpSum extrInfo_DemandDtlGrpSum1, ExtrInfo_DemandDtlGrpSum extrInfo_DemandDtlGrpSum2)
		{
			ArrayList resList = new ArrayList();
			if(extrInfo_DemandDtlGrpSum1.EnterpriseCode != extrInfo_DemandDtlGrpSum2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(extrInfo_DemandDtlGrpSum1.AddUpSecCode != extrInfo_DemandDtlGrpSum2.AddUpSecCode)resList.Add("AddUpSecCode");
			if(extrInfo_DemandDtlGrpSum1.AddUpADateSt != extrInfo_DemandDtlGrpSum2.AddUpADateSt)resList.Add("AddUpADateSt");
			if(extrInfo_DemandDtlGrpSum1.AddUpADateEd != extrInfo_DemandDtlGrpSum2.AddUpADateEd)resList.Add("AddUpADateEd");
			if(extrInfo_DemandDtlGrpSum1.ClaimCode != extrInfo_DemandDtlGrpSum2.ClaimCode)resList.Add("ClaimCode");
			if(extrInfo_DemandDtlGrpSum1.IsExtractDepo != extrInfo_DemandDtlGrpSum2.IsExtractDepo)resList.Add("IsExtractDepo");
			if(extrInfo_DemandDtlGrpSum1.CountSheets != extrInfo_DemandDtlGrpSum2.CountSheets)resList.Add("CountSheets");
			if(extrInfo_DemandDtlGrpSum1.DemandSumOdr1 != extrInfo_DemandDtlGrpSum2.DemandSumOdr1)resList.Add("DemandSumOdr1");
			if(extrInfo_DemandDtlGrpSum1.DemandSumOdrAttend1 != extrInfo_DemandDtlGrpSum2.DemandSumOdrAttend1)resList.Add("DemandSumOdrAttend1");
			if(extrInfo_DemandDtlGrpSum1.DemandSumOdr2 != extrInfo_DemandDtlGrpSum2.DemandSumOdr2)resList.Add("DemandSumOdr2");
			if(extrInfo_DemandDtlGrpSum1.DemandSumOdrAttend2 != extrInfo_DemandDtlGrpSum2.DemandSumOdrAttend2)resList.Add("DemandSumOdrAttend2");
			if(extrInfo_DemandDtlGrpSum1.DemandSumOdr3 != extrInfo_DemandDtlGrpSum2.DemandSumOdr3)resList.Add("DemandSumOdr3");
			if(extrInfo_DemandDtlGrpSum1.DemandSumOdrAttend3 != extrInfo_DemandDtlGrpSum2.DemandSumOdrAttend3)resList.Add("DemandSumOdrAttend3");
			if(extrInfo_DemandDtlGrpSum1.PaymentSumOdr1 != extrInfo_DemandDtlGrpSum2.PaymentSumOdr1)resList.Add("PaymentSumOdr1");
			if(extrInfo_DemandDtlGrpSum1.PaymentSumOdrAttend1 != extrInfo_DemandDtlGrpSum2.PaymentSumOdrAttend1)resList.Add("PaymentSumOdrAttend1");
			if(extrInfo_DemandDtlGrpSum1.PaymentSumOdr2 != extrInfo_DemandDtlGrpSum2.PaymentSumOdr2)resList.Add("PaymentSumOdr2");
			if(extrInfo_DemandDtlGrpSum1.PaymentSumOdrAttend2 != extrInfo_DemandDtlGrpSum2.PaymentSumOdrAttend2)resList.Add("PaymentSumOdrAttend2");
			if(extrInfo_DemandDtlGrpSum1.PaymentSumOdr3 != extrInfo_DemandDtlGrpSum2.PaymentSumOdr3)resList.Add("PaymentSumOdr3");
			if(extrInfo_DemandDtlGrpSum1.PaymentSumOdrAttend3 != extrInfo_DemandDtlGrpSum2.PaymentSumOdrAttend3)resList.Add("PaymentSumOdrAttend3");
			if(extrInfo_DemandDtlGrpSum1.ForceDmdMggCd != extrInfo_DemandDtlGrpSum2.ForceDmdMggCd)resList.Add("ForceDmdMggCd");
			if(extrInfo_DemandDtlGrpSum1.ForcePayMggCd != extrInfo_DemandDtlGrpSum2.ForcePayMggCd)resList.Add("ForcePayMggCd");
			if(extrInfo_DemandDtlGrpSum1.EnterpriseName != extrInfo_DemandDtlGrpSum2.EnterpriseName)resList.Add("EnterpriseName");
			if(extrInfo_DemandDtlGrpSum1.AddUpSecName != extrInfo_DemandDtlGrpSum2.AddUpSecName)resList.Add("AddUpSecName");

			return resList;
		}
	}
}
