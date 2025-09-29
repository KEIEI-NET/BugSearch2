using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   CustomerClaimConf
	/// <summary>
	///                      請求先確認
	/// </summary>
	/// <remarks>
	/// <br>note             :   請求先確認ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/02/13  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class CustomerClaimConf
	{
		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>管理拠点コード</summary>
		private string _mngSectionCode = "";

		/// <summary>計上拠点コード</summary>
		private string _addUpSectionCode = "";

		/// <summary>名称</summary>
		private string _name = "";

		/// <summary>名称2</summary>
		private string _name2 = "";

		/// <summary>得意先略称</summary>
		private string _customerSnm = "";

		/// <summary>集金月区分コード</summary>
		/// <remarks>計上日</remarks>
		private Int32 _collectMoneyCode;

		/// <summary>締次更新年月日</summary>
		/// <remarks>"YYYYMMDD"  前回締次更新対象となった年月日</remarks>
		private DateTime _addUpADate;

		/// <summary>前回締次更新年月日</summary>
		private DateTime _lastCAddUpUpdDate;

		/// <summary>前回請求金額</summary>
		/// <remarks>DD</remarks>
		private Int64 _lastTimeDemand;

		/// <summary>締日</summary>
		/// <remarks>0:伝票単位1:明細単位2:請求親3:請求子　9:非課税</remarks>
		private Int32 _totalDay;

		/// <summary>消費税転嫁方式</summary>
		/// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
		private Int32 _consTaxLayMethod;

		/// <summary>総額表示方法区分</summary>
		/// <remarks>1:切捨て,2:四捨五入,3:切上げ　（消費税）</remarks>
		private Int32 _totalAmountDispWayCd;

		/// <summary>消費税端数処理区分</summary>
		private Int32 _taxFractionProcCd;

		/// <summary>勤務先TEL表示名称</summary>
		private string _officeTelNoDspName = "";

		/// <summary>勤務先FAX表示名称</summary>
		private string _officeFaxNoDspName = "";

		/// <summary>電話番号（勤務先）</summary>
		private string _officeTelNo = "";

		/// <summary>FAX番号（勤務先）</summary>
		private string _officeFaxNo = "";

		/// <summary>与信管理区分</summary>
		private Int32 _creditMngCode;

		/// <summary>次回勘定開始日</summary>
		/// <remarks>01～31まで（省略可能）</remarks>
		private Int32 _nTimeCalcStDate;

		/// <summary>得意先担当者</summary>
		/// <remarks>得意先の社員名</remarks>
		private string _customerAgent = "";

		/// <summary>管理拠点名称</summary>
		private string _mngSectionName = "";


		/// public propaty name  :  CustomerCode
		/// <summary>得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get { return _customerCode; }
			set { _customerCode = value; }
		}

		/// public propaty name  :  MngSectionCode
		/// <summary>管理拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   管理拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MngSectionCode
		{
			get { return _mngSectionCode; }
			set { _mngSectionCode = value; }
		}

		/// public propaty name  :  AddUpSectionCode
		/// <summary>計上拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpSectionCode
		{
			get { return _addUpSectionCode; }
			set { _addUpSectionCode = value; }
		}

		/// public propaty name  :  Name
		/// <summary>名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		/// public propaty name  :  Name2
		/// <summary>名称2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   名称2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Name2
		{
			get { return _name2; }
			set { _name2 = value; }
		}

		/// public propaty name  :  CustomerSnm
		/// <summary>得意先略称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先略称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CustomerSnm
		{
			get { return _customerSnm; }
			set { _customerSnm = value; }
		}

		/// public propaty name  :  CollectMoneyCode
		/// <summary>集金月区分コードプロパティ</summary>
		/// <value>計上日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   集金月区分コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CollectMoneyCode
		{
			get { return _collectMoneyCode; }
			set { _collectMoneyCode = value; }
		}

		/// public propaty name  :  AddUpADate
		/// <summary>締次更新年月日プロパティ</summary>
		/// <value>"YYYYMMDD"  前回締次更新対象となった年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締次更新年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AddUpADate
		{
			get { return _addUpADate; }
			set { _addUpADate = value; }
		}

		/// public propaty name  :  AddUpADateJpFormal
		/// <summary>締次更新年月日 和暦プロパティ</summary>
		/// <value>"YYYYMMDD"  前回締次更新対象となった年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締次更新年月日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpADateJpFormal
		{
			get { return TDateTime.DateTimeToString("GGYYMMDD", _addUpADate); }
			set { }
		}

		/// public propaty name  :  AddUpADateJpInFormal
		/// <summary>締次更新年月日 和暦(略)プロパティ</summary>
		/// <value>"YYYYMMDD"  前回締次更新対象となった年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締次更新年月日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpADateJpInFormal
		{
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _addUpADate); }
			set { }
		}

		/// public propaty name  :  AddUpADateAdFormal
		/// <summary>締次更新年月日 西暦プロパティ</summary>
		/// <value>"YYYYMMDD"  前回締次更新対象となった年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締次更新年月日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpADateAdFormal
		{
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _addUpADate); }
			set { }
		}

		/// public propaty name  :  AddUpADateAdInFormal
		/// <summary>締次更新年月日 西暦(略)プロパティ</summary>
		/// <value>"YYYYMMDD"  前回締次更新対象となった年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締次更新年月日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpADateAdInFormal
		{
			get { return TDateTime.DateTimeToString("YY/MM/DD", _addUpADate); }
			set { }
		}

		/// public propaty name  :  LastCAddUpUpdDate
		/// <summary>前回締次更新年月日プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前回締次更新年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime LastCAddUpUpdDate
		{
			get { return _lastCAddUpUpdDate; }
			set { _lastCAddUpUpdDate = value; }
		}

		/// public propaty name  :  LastCAddUpUpdDateJpFormal
		/// <summary>前回締次更新年月日 和暦プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前回締次更新年月日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LastCAddUpUpdDateJpFormal
		{
			get { return TDateTime.DateTimeToString("GGYYMMDD", _lastCAddUpUpdDate); }
			set { }
		}

		/// public propaty name  :  LastCAddUpUpdDateJpInFormal
		/// <summary>前回締次更新年月日 和暦(略)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前回締次更新年月日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LastCAddUpUpdDateJpInFormal
		{
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _lastCAddUpUpdDate); }
			set { }
		}

		/// public propaty name  :  LastCAddUpUpdDateAdFormal
		/// <summary>前回締次更新年月日 西暦プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前回締次更新年月日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LastCAddUpUpdDateAdFormal
		{
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _lastCAddUpUpdDate); }
			set { }
		}

		/// public propaty name  :  LastCAddUpUpdDateAdInFormal
		/// <summary>前回締次更新年月日 西暦(略)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前回締次更新年月日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LastCAddUpUpdDateAdInFormal
		{
			get { return TDateTime.DateTimeToString("YY/MM/DD", _lastCAddUpUpdDate); }
			set { }
		}

		/// public propaty name  :  LastTimeDemand
		/// <summary>前回請求金額プロパティ</summary>
		/// <value>DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前回請求金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 LastTimeDemand
		{
			get { return _lastTimeDemand; }
			set { _lastTimeDemand = value; }
		}

		/// public propaty name  :  TotalDay
		/// <summary>締日プロパティ</summary>
		/// <value>0:伝票単位1:明細単位2:請求親3:請求子　9:非課税</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TotalDay
		{
			get { return _totalDay; }
			set { _totalDay = value; }
		}

		/// public propaty name  :  ConsTaxLayMethod
		/// <summary>消費税転嫁方式プロパティ</summary>
		/// <value>0:総額表示しない（税抜き）,1:総額表示する（税込み）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   消費税転嫁方式プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ConsTaxLayMethod
		{
			get { return _consTaxLayMethod; }
			set { _consTaxLayMethod = value; }
		}

		/// public propaty name  :  TotalAmountDispWayCd
		/// <summary>総額表示方法区分プロパティ</summary>
		/// <value>1:切捨て,2:四捨五入,3:切上げ　（消費税）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   総額表示方法区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TotalAmountDispWayCd
		{
			get { return _totalAmountDispWayCd; }
			set { _totalAmountDispWayCd = value; }
		}

		/// public propaty name  :  TaxFractionProcCd
		/// <summary>消費税端数処理区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   消費税端数処理区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TaxFractionProcCd
		{
			get { return _taxFractionProcCd; }
			set { _taxFractionProcCd = value; }
		}

		/// public propaty name  :  OfficeTelNoDspName
		/// <summary>勤務先TEL表示名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   勤務先TEL表示名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OfficeTelNoDspName
		{
			get { return _officeTelNoDspName; }
			set { _officeTelNoDspName = value; }
		}

		/// public propaty name  :  OfficeFaxNoDspName
		/// <summary>勤務先FAX表示名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   勤務先FAX表示名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OfficeFaxNoDspName
		{
			get { return _officeFaxNoDspName; }
			set { _officeFaxNoDspName = value; }
		}

		/// public propaty name  :  OfficeTelNo
		/// <summary>電話番号（勤務先）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   電話番号（勤務先）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OfficeTelNo
		{
			get { return _officeTelNo; }
			set { _officeTelNo = value; }
		}

		/// public propaty name  :  OfficeFaxNo
		/// <summary>FAX番号（勤務先）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   FAX番号（勤務先）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OfficeFaxNo
		{
			get { return _officeFaxNo; }
			set { _officeFaxNo = value; }
		}

		/// public propaty name  :  CreditMngCode
		/// <summary>与信管理区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   与信管理区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CreditMngCode
		{
			get { return _creditMngCode; }
			set { _creditMngCode = value; }
		}

		/// public propaty name  :  NTimeCalcStDate
		/// <summary>次回勘定開始日プロパティ</summary>
		/// <value>01～31まで（省略可能）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   次回勘定開始日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NTimeCalcStDate
		{
			get { return _nTimeCalcStDate; }
			set { _nTimeCalcStDate = value; }
		}

		/// public propaty name  :  CustomerAgent
		/// <summary>得意先担当者プロパティ</summary>
		/// <value>得意先の社員名</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先担当者プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CustomerAgent
		{
			get { return _customerAgent; }
			set { _customerAgent = value; }
		}

		/// public propaty name  :  MngSectionName
		/// <summary>管理拠点名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   管理拠点名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MngSectionName
		{
			get { return _mngSectionName; }
			set { _mngSectionName = value; }
		}


		/// <summary>
		/// 請求先確認コンストラクタ
		/// </summary>
		/// <returns>CustomerClaimConfクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustomerClaimConfクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CustomerClaimConf()
		{
		}

		/// <summary>
		/// 請求先確認コンストラクタ
		/// </summary>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="mngSectionCode">管理拠点コード</param>
		/// <param name="addUpSectionCode">計上拠点コード</param>
		/// <param name="name">名称</param>
		/// <param name="name2">名称2</param>
		/// <param name="customerSnm">得意先略称</param>
		/// <param name="collectMoneyCode">集金月区分コード(計上日)</param>
		/// <param name="addUpADate">締次更新年月日("YYYYMMDD"  前回締次更新対象となった年月日)</param>
		/// <param name="lastCAddUpUpdDate">前回締次更新年月日</param>
		/// <param name="lastTimeDemand">前回請求金額(DD)</param>
		/// <param name="totalDay">締日(0:伝票単位1:明細単位2:請求親3:請求子　9:非課税)</param>
		/// <param name="consTaxLayMethod">消費税転嫁方式(0:総額表示しない（税抜き）,1:総額表示する（税込み）)</param>
		/// <param name="totalAmountDispWayCd">総額表示方法区分(1:切捨て,2:四捨五入,3:切上げ　（消費税）)</param>
		/// <param name="taxFractionProcCd">消費税端数処理区分</param>
		/// <param name="officeTelNoDspName">勤務先TEL表示名称</param>
		/// <param name="officeFaxNoDspName">勤務先FAX表示名称</param>
		/// <param name="officeTelNo">電話番号（勤務先）</param>
		/// <param name="officeFaxNo">FAX番号（勤務先）</param>
		/// <param name="creditMngCode">与信管理区分</param>
		/// <param name="nTimeCalcStDate">次回勘定開始日(01～31まで（省略可能）)</param>
		/// <param name="customerAgent">得意先担当者(得意先の社員名)</param>
		/// <param name="mngSectionName">管理拠点名称</param>
		/// <returns>CustomerClaimConfクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustomerClaimConfクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CustomerClaimConf( Int32 customerCode, string mngSectionCode, string addUpSectionCode, string name, string name2, string customerSnm, Int32 collectMoneyCode, DateTime addUpADate, DateTime lastCAddUpUpdDate, Int64 lastTimeDemand, Int32 totalDay, Int32 consTaxLayMethod, Int32 totalAmountDispWayCd, Int32 taxFractionProcCd, string officeTelNoDspName, string officeFaxNoDspName, string officeTelNo, string officeFaxNo, Int32 creditMngCode, Int32 nTimeCalcStDate, string customerAgent, string mngSectionName )
		{
			this._customerCode = customerCode;
			this._mngSectionCode = mngSectionCode;
			this._addUpSectionCode = addUpSectionCode;
			this._name = name;
			this._name2 = name2;
			this._customerSnm = customerSnm;
			this._collectMoneyCode = collectMoneyCode;
			this.AddUpADate = addUpADate;
			this.LastCAddUpUpdDate = lastCAddUpUpdDate;
			this._lastTimeDemand = lastTimeDemand;
			this._totalDay = totalDay;
			this._consTaxLayMethod = consTaxLayMethod;
			this._totalAmountDispWayCd = totalAmountDispWayCd;
			this._taxFractionProcCd = taxFractionProcCd;
			this._officeTelNoDspName = officeTelNoDspName;
			this._officeFaxNoDspName = officeFaxNoDspName;
			this._officeTelNo = officeTelNo;
			this._officeFaxNo = officeFaxNo;
			this._creditMngCode = creditMngCode;
			this._nTimeCalcStDate = nTimeCalcStDate;
			this._customerAgent = customerAgent;
			this._mngSectionName = mngSectionName;

		}

		/// <summary>
		/// 請求先確認複製処理
		/// </summary>
		/// <returns>CustomerClaimConfクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいCustomerClaimConfクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CustomerClaimConf Clone()
		{
			return new CustomerClaimConf(this._customerCode, this._mngSectionCode, this._addUpSectionCode, this._name, this._name2, this._customerSnm, this._collectMoneyCode, this._addUpADate, this._lastCAddUpUpdDate, this._lastTimeDemand, this._totalDay, this._consTaxLayMethod, this._totalAmountDispWayCd, this._taxFractionProcCd, this._officeTelNoDspName, this._officeFaxNoDspName, this._officeTelNo, this._officeFaxNo, this._creditMngCode, this._nTimeCalcStDate, this._customerAgent, this._mngSectionName);
		}

		/// <summary>
		/// 請求先確認比較処理
		/// </summary>
		/// <param name="target">比較対象のCustomerClaimConfクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustomerClaimConfクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals( CustomerClaimConf target )
		{
			return ( ( this.CustomerCode == target.CustomerCode )
				 && ( this.MngSectionCode == target.MngSectionCode )
				 && ( this.AddUpSectionCode == target.AddUpSectionCode )
				 && ( this.Name == target.Name )
				 && ( this.Name2 == target.Name2 )
				 && ( this.CustomerSnm == target.CustomerSnm )
				 && ( this.CollectMoneyCode == target.CollectMoneyCode )
				 && ( this.AddUpADate == target.AddUpADate )
				 && ( this.LastCAddUpUpdDate == target.LastCAddUpUpdDate )
				 && ( this.LastTimeDemand == target.LastTimeDemand )
				 && ( this.TotalDay == target.TotalDay )
				 && ( this.ConsTaxLayMethod == target.ConsTaxLayMethod )
				 && ( this.TotalAmountDispWayCd == target.TotalAmountDispWayCd )
				 && ( this.TaxFractionProcCd == target.TaxFractionProcCd )
				 && ( this.OfficeTelNoDspName == target.OfficeTelNoDspName )
				 && ( this.OfficeFaxNoDspName == target.OfficeFaxNoDspName )
				 && ( this.OfficeTelNo == target.OfficeTelNo )
				 && ( this.OfficeFaxNo == target.OfficeFaxNo )
				 && ( this.CreditMngCode == target.CreditMngCode )
				 && ( this.NTimeCalcStDate == target.NTimeCalcStDate )
				 && ( this.CustomerAgent == target.CustomerAgent )
				 && ( this.MngSectionName == target.MngSectionName ) );
		}

		/// <summary>
		/// 請求先確認比較処理
		/// </summary>
		/// <param name="customerClaimConf1">
		///                    比較するCustomerClaimConfクラスのインスタンス
		/// </param>
		/// <param name="customerClaimConf2">比較するCustomerClaimConfクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustomerClaimConfクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals( CustomerClaimConf customerClaimConf1, CustomerClaimConf customerClaimConf2 )
		{
			return ( ( customerClaimConf1.CustomerCode == customerClaimConf2.CustomerCode )
				 && ( customerClaimConf1.MngSectionCode == customerClaimConf2.MngSectionCode )
				 && ( customerClaimConf1.AddUpSectionCode == customerClaimConf2.AddUpSectionCode )
				 && ( customerClaimConf1.Name == customerClaimConf2.Name )
				 && ( customerClaimConf1.Name2 == customerClaimConf2.Name2 )
				 && ( customerClaimConf1.CustomerSnm == customerClaimConf2.CustomerSnm )
				 && ( customerClaimConf1.CollectMoneyCode == customerClaimConf2.CollectMoneyCode )
				 && ( customerClaimConf1.AddUpADate == customerClaimConf2.AddUpADate )
				 && ( customerClaimConf1.LastCAddUpUpdDate == customerClaimConf2.LastCAddUpUpdDate )
				 && ( customerClaimConf1.LastTimeDemand == customerClaimConf2.LastTimeDemand )
				 && ( customerClaimConf1.TotalDay == customerClaimConf2.TotalDay )
				 && ( customerClaimConf1.ConsTaxLayMethod == customerClaimConf2.ConsTaxLayMethod )
				 && ( customerClaimConf1.TotalAmountDispWayCd == customerClaimConf2.TotalAmountDispWayCd )
				 && ( customerClaimConf1.TaxFractionProcCd == customerClaimConf2.TaxFractionProcCd )
				 && ( customerClaimConf1.OfficeTelNoDspName == customerClaimConf2.OfficeTelNoDspName )
				 && ( customerClaimConf1.OfficeFaxNoDspName == customerClaimConf2.OfficeFaxNoDspName )
				 && ( customerClaimConf1.OfficeTelNo == customerClaimConf2.OfficeTelNo )
				 && ( customerClaimConf1.OfficeFaxNo == customerClaimConf2.OfficeFaxNo )
				 && ( customerClaimConf1.CreditMngCode == customerClaimConf2.CreditMngCode )
				 && ( customerClaimConf1.NTimeCalcStDate == customerClaimConf2.NTimeCalcStDate )
				 && ( customerClaimConf1.CustomerAgent == customerClaimConf2.CustomerAgent )
				 && ( customerClaimConf1.MngSectionName == customerClaimConf2.MngSectionName ) );
		}
		/// <summary>
		/// 請求先確認比較処理
		/// </summary>
		/// <param name="target">比較対象のCustomerClaimConfクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustomerClaimConfクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare( CustomerClaimConf target )
		{
			ArrayList resList = new ArrayList();
			if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
			if (this.MngSectionCode != target.MngSectionCode) resList.Add("MngSectionCode");
			if (this.AddUpSectionCode != target.AddUpSectionCode) resList.Add("AddUpSectionCode");
			if (this.Name != target.Name) resList.Add("Name");
			if (this.Name2 != target.Name2) resList.Add("Name2");
			if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
			if (this.CollectMoneyCode != target.CollectMoneyCode) resList.Add("CollectMoneyCode");
			if (this.AddUpADate != target.AddUpADate) resList.Add("AddUpADate");
			if (this.LastCAddUpUpdDate != target.LastCAddUpUpdDate) resList.Add("LastCAddUpUpdDate");
			if (this.LastTimeDemand != target.LastTimeDemand) resList.Add("LastTimeDemand");
			if (this.TotalDay != target.TotalDay) resList.Add("TotalDay");
			if (this.ConsTaxLayMethod != target.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
			if (this.TotalAmountDispWayCd != target.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
			if (this.TaxFractionProcCd != target.TaxFractionProcCd) resList.Add("TaxFractionProcCd");
			if (this.OfficeTelNoDspName != target.OfficeTelNoDspName) resList.Add("OfficeTelNoDspName");
			if (this.OfficeFaxNoDspName != target.OfficeFaxNoDspName) resList.Add("OfficeFaxNoDspName");
			if (this.OfficeTelNo != target.OfficeTelNo) resList.Add("OfficeTelNo");
			if (this.OfficeFaxNo != target.OfficeFaxNo) resList.Add("OfficeFaxNo");
			if (this.CreditMngCode != target.CreditMngCode) resList.Add("CreditMngCode");
			if (this.NTimeCalcStDate != target.NTimeCalcStDate) resList.Add("NTimeCalcStDate");
			if (this.CustomerAgent != target.CustomerAgent) resList.Add("CustomerAgent");
			if (this.MngSectionName != target.MngSectionName) resList.Add("MngSectionName");

			return resList;
		}

		/// <summary>
		/// 請求先確認比較処理
		/// </summary>
		/// <param name="customerClaimConf1">比較するCustomerClaimConfクラスのインスタンス</param>
		/// <param name="customerClaimConf2">比較するCustomerClaimConfクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustomerClaimConfクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare( CustomerClaimConf customerClaimConf1, CustomerClaimConf customerClaimConf2 )
		{
			ArrayList resList = new ArrayList();
			if (customerClaimConf1.CustomerCode != customerClaimConf2.CustomerCode) resList.Add("CustomerCode");
			if (customerClaimConf1.MngSectionCode != customerClaimConf2.MngSectionCode) resList.Add("MngSectionCode");
			if (customerClaimConf1.AddUpSectionCode != customerClaimConf2.AddUpSectionCode) resList.Add("AddUpSectionCode");
			if (customerClaimConf1.Name != customerClaimConf2.Name) resList.Add("Name");
			if (customerClaimConf1.Name2 != customerClaimConf2.Name2) resList.Add("Name2");
			if (customerClaimConf1.CustomerSnm != customerClaimConf2.CustomerSnm) resList.Add("CustomerSnm");
			if (customerClaimConf1.CollectMoneyCode != customerClaimConf2.CollectMoneyCode) resList.Add("CollectMoneyCode");
			if (customerClaimConf1.AddUpADate != customerClaimConf2.AddUpADate) resList.Add("AddUpADate");
			if (customerClaimConf1.LastCAddUpUpdDate != customerClaimConf2.LastCAddUpUpdDate) resList.Add("LastCAddUpUpdDate");
			if (customerClaimConf1.LastTimeDemand != customerClaimConf2.LastTimeDemand) resList.Add("LastTimeDemand");
			if (customerClaimConf1.TotalDay != customerClaimConf2.TotalDay) resList.Add("TotalDay");
			if (customerClaimConf1.ConsTaxLayMethod != customerClaimConf2.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
			if (customerClaimConf1.TotalAmountDispWayCd != customerClaimConf2.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
			if (customerClaimConf1.TaxFractionProcCd != customerClaimConf2.TaxFractionProcCd) resList.Add("TaxFractionProcCd");
			if (customerClaimConf1.OfficeTelNoDspName != customerClaimConf2.OfficeTelNoDspName) resList.Add("OfficeTelNoDspName");
			if (customerClaimConf1.OfficeFaxNoDspName != customerClaimConf2.OfficeFaxNoDspName) resList.Add("OfficeFaxNoDspName");
			if (customerClaimConf1.OfficeTelNo != customerClaimConf2.OfficeTelNo) resList.Add("OfficeTelNo");
			if (customerClaimConf1.OfficeFaxNo != customerClaimConf2.OfficeFaxNo) resList.Add("OfficeFaxNo");
			if (customerClaimConf1.CreditMngCode != customerClaimConf2.CreditMngCode) resList.Add("CreditMngCode");
			if (customerClaimConf1.NTimeCalcStDate != customerClaimConf2.NTimeCalcStDate) resList.Add("NTimeCalcStDate");
			if (customerClaimConf1.CustomerAgent != customerClaimConf2.CustomerAgent) resList.Add("CustomerAgent");
			if (customerClaimConf1.MngSectionName != customerClaimConf2.MngSectionName) resList.Add("MngSectionName");

			return resList;
		}
	}
}
