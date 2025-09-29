using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SuplierPayInfGetParameter
	/// <summary>
	///                      仕入先元帳(支払履歴)抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入先元帳(支払履歴)抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/12/17  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class SuplierPayInfGetParameter
    {
        ///// <summary>拠点オプション</summary>
        //private bool _isOptSection = false;

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード（複数指定）</summary>
		/// <remarks>（配列）</remarks>
		private string[] _addUpSecCodeList;

		/// <summary>開始計上年月</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _startAddUpYearMonth;

		/// <summary>終了計上年月</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _endAddUpYearMonth;

		/// <summary>開始仕入先コード</summary>
		private Int32 _startCustomerCode;

		/// <summary>終了仕入先コード</summary>
		private Int32 _endCustomerCode;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

        /// <summary>出力帳票区分</summary>
        private Int32 _outputSlipDiv = 0;

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

		/// public propaty name  :  AddUpSecCodeList
		/// <summary>拠点コード（複数指定）プロパティ</summary>
		/// <value>（配列）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コード（複数指定）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] AddUpSecCodeList
		{
			get{return _addUpSecCodeList;}
			set{_addUpSecCodeList = value;}
		}

		/// public propaty name  :  StartAddUpYearMonth
		/// <summary>開始計上年月プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始計上年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StartAddUpYearMonth
		{
			get{return _startAddUpYearMonth;}
			set{_startAddUpYearMonth = value;}
		}

		/// public propaty name  :  EndAddUpYearMonth
		/// <summary>終了計上年月プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了計上年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EndAddUpYearMonth
		{
			get{return _endAddUpYearMonth;}
			set{_endAddUpYearMonth = value;}
		}

		/// public propaty name  :  StartCustomerCode
		/// <summary>開始仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StartCustomerCode
		{
			get{return _startCustomerCode;}
			set{_startCustomerCode = value;}
		}

		/// public propaty name  :  EndCustomerCode
		/// <summary>終了仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EndCustomerCode
		{
			get{return _endCustomerCode;}
			set{_endCustomerCode = value;}
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

        /// public propaty name  :  OutputSlipDiv
        /// <summary>出力帳票区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力帳票区分</br>
        /// <br>Programer        :   手書き</br>
        /// </remarks>
        public Int32 OutputSlipDiv
        {
            get { return _outputSlipDiv; }
            set { _outputSlipDiv = value; }
        }

		/// <summary>
		/// 仕入先元帳(支払履歴)抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>SuplierPayInfGetParameterクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SuplierPayInfGetParameterクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SuplierPayInfGetParameter()
		{
		}

		/// <summary>
		/// 仕入先元帳(支払履歴)抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="addUpSecCodeList">拠点コード（複数指定）(（配列）)</param>
		/// <param name="startAddUpYearMonth">開始計上年月(YYYYMM)</param>
		/// <param name="endAddUpYearMonth">終了計上年月(YYYYMM)</param>
		/// <param name="startCustomerCode">開始仕入先コード</param>
		/// <param name="endCustomerCode">終了仕入先コード</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <returns>SuplierPayInfGetParameterクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SuplierPayInfGetParameterクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public SuplierPayInfGetParameter(string enterpriseCode, string[] addUpSecCodeList, Int32 startAddUpYearMonth, Int32 endAddUpYearMonth, Int32 startCustomerCode, Int32 endCustomerCode, string enterpriseName)
		{
			this._enterpriseCode = enterpriseCode;
			this._addUpSecCodeList = addUpSecCodeList;
			this._startAddUpYearMonth = startAddUpYearMonth;
			this._endAddUpYearMonth = endAddUpYearMonth;
			this._startCustomerCode = startCustomerCode;
			this._endCustomerCode = endCustomerCode;
			this._enterpriseName = enterpriseName;

		}

		/// <summary>
		/// 仕入先元帳(支払履歴)抽出条件クラス複製処理
		/// </summary>
		/// <returns>SuplierPayInfGetParameterクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSuplierPayInfGetParameterクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SuplierPayInfGetParameter Clone()
		{
			return new SuplierPayInfGetParameter(this._enterpriseCode,this._addUpSecCodeList,this._startAddUpYearMonth,this._endAddUpYearMonth,this._startCustomerCode,this._endCustomerCode,this._enterpriseName);
		}

		/// <summary>
		/// 仕入先元帳(支払履歴)抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のSuplierPayInfGetParameterクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SuplierPayInfGetParameterクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(SuplierPayInfGetParameter target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.AddUpSecCodeList == target.AddUpSecCodeList)
				 && (this.StartAddUpYearMonth == target.StartAddUpYearMonth)
				 && (this.EndAddUpYearMonth == target.EndAddUpYearMonth)
				 && (this.StartCustomerCode == target.StartCustomerCode)
				 && (this.EndCustomerCode == target.EndCustomerCode)
				 && (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
		/// 仕入先元帳(支払履歴)抽出条件クラス比較処理
		/// </summary>
		/// <param name="suplierPayInfGetParameter1">
		///                    比較するSuplierPayInfGetParameterクラスのインスタンス
		/// </param>
		/// <param name="suplierPayInfGetParameter2">比較するSuplierPayInfGetParameterクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SuplierPayInfGetParameterクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(SuplierPayInfGetParameter suplierPayInfGetParameter1, SuplierPayInfGetParameter suplierPayInfGetParameter2)
		{
			return ((suplierPayInfGetParameter1.EnterpriseCode == suplierPayInfGetParameter2.EnterpriseCode)
				 && (suplierPayInfGetParameter1.AddUpSecCodeList == suplierPayInfGetParameter2.AddUpSecCodeList)
				 && (suplierPayInfGetParameter1.StartAddUpYearMonth == suplierPayInfGetParameter2.StartAddUpYearMonth)
				 && (suplierPayInfGetParameter1.EndAddUpYearMonth == suplierPayInfGetParameter2.EndAddUpYearMonth)
				 && (suplierPayInfGetParameter1.StartCustomerCode == suplierPayInfGetParameter2.StartCustomerCode)
				 && (suplierPayInfGetParameter1.EndCustomerCode == suplierPayInfGetParameter2.EndCustomerCode)
				 && (suplierPayInfGetParameter1.EnterpriseName == suplierPayInfGetParameter2.EnterpriseName));
		}
		/// <summary>
		/// 仕入先元帳(支払履歴)抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のSuplierPayInfGetParameterクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SuplierPayInfGetParameterクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(SuplierPayInfGetParameter target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.AddUpSecCodeList != target.AddUpSecCodeList)resList.Add("AddUpSecCodeList");
			if(this.StartAddUpYearMonth != target.StartAddUpYearMonth)resList.Add("StartAddUpYearMonth");
			if(this.EndAddUpYearMonth != target.EndAddUpYearMonth)resList.Add("EndAddUpYearMonth");
			if(this.StartCustomerCode != target.StartCustomerCode)resList.Add("StartCustomerCode");
			if(this.EndCustomerCode != target.EndCustomerCode)resList.Add("EndCustomerCode");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}

		/// <summary>
		/// 仕入先元帳(支払履歴)抽出条件クラス比較処理
		/// </summary>
		/// <param name="suplierPayInfGetParameter1">比較するSuplierPayInfGetParameterクラスのインスタンス</param>
		/// <param name="suplierPayInfGetParameter2">比較するSuplierPayInfGetParameterクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SuplierPayInfGetParameterクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(SuplierPayInfGetParameter suplierPayInfGetParameter1, SuplierPayInfGetParameter suplierPayInfGetParameter2)
		{
			ArrayList resList = new ArrayList();
			if(suplierPayInfGetParameter1.EnterpriseCode != suplierPayInfGetParameter2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(suplierPayInfGetParameter1.AddUpSecCodeList != suplierPayInfGetParameter2.AddUpSecCodeList)resList.Add("AddUpSecCodeList");
			if(suplierPayInfGetParameter1.StartAddUpYearMonth != suplierPayInfGetParameter2.StartAddUpYearMonth)resList.Add("StartAddUpYearMonth");
			if(suplierPayInfGetParameter1.EndAddUpYearMonth != suplierPayInfGetParameter2.EndAddUpYearMonth)resList.Add("EndAddUpYearMonth");
			if(suplierPayInfGetParameter1.StartCustomerCode != suplierPayInfGetParameter2.StartCustomerCode)resList.Add("StartCustomerCode");
			if(suplierPayInfGetParameter1.EndCustomerCode != suplierPayInfGetParameter2.EndCustomerCode)resList.Add("EndCustomerCode");
			if(suplierPayInfGetParameter1.EnterpriseName != suplierPayInfGetParameter2.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}
	}
}
