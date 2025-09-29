using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ExtrInfo_DemandDetail
	/// <summary>
	///                      請求書(明細書情報)抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   請求書(明細書情報)抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/06/19  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class ExtrInfo_DemandDetail
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

		/// <summary>明細単位</summary>
		/// <remarks>0:詳細単位 1:明細単位 2:伝票単位</remarks>
		private Int32 _detailsUnit;

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

		/// public propaty name  :  DetailsUnit
		/// <summary>明細単位プロパティ</summary>
		/// <value>0:詳細単位 1:明細単位 2:伝票単位</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   明細単位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DetailsUnit
		{
			get{return _detailsUnit;}
			set{_detailsUnit = value;}
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
		/// 請求書(明細書情報)抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>ExtrInfo_DemandDetailクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandDetailクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_DemandDetail()
		{
		}

		/// <summary>
		/// 請求書(明細書情報)抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="addUpSecCode">計上拠点コード(集計の対象となっている拠点コード)</param>
		/// <param name="addUpADateSt">抽出対象計上日(開始)("YYYYMMDD"  今回締開始計上日となる年月日)</param>
		/// <param name="addUpADateEd">抽出対象計上日(終了)("YYYYMMDD"  今回締終了計上日となる年月日)</param>
		/// <param name="claimCode">請求先コード</param>
		/// <param name="isExtractDepo">入金明細抽出有無</param>
		/// <param name="detailsUnit">明細単位(0:詳細単位 1:伝票単位)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="addUpSecName">計上拠点名称</param>
		/// <returns>ExtrInfo_DemandDetailクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandDetailクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public ExtrInfo_DemandDetail(string enterpriseCode, string addUpSecCode, Int32 addUpADateSt, Int32 addUpADateEd, Int32 claimCode, bool isExtractDepo, Int32 detailsUnit, string enterpriseName, string addUpSecName)
		{
			this._enterpriseCode = enterpriseCode;
			this._addUpSecCode = addUpSecCode;
			this._addUpADateSt = addUpADateSt;
			this._addUpADateEd = addUpADateEd;
			this._claimCode = claimCode;
			this._isExtractDepo = isExtractDepo;
			this._detailsUnit = detailsUnit;
			this._enterpriseName = enterpriseName;
			this._addUpSecName = addUpSecName;

		}

		/// <summary>
		/// 請求書(明細書情報)抽出条件クラス複製処理
		/// </summary>
		/// <returns>ExtrInfo_DemandDetailクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいExtrInfo_DemandDetailクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_DemandDetail Clone()
		{
			return new ExtrInfo_DemandDetail(this._enterpriseCode,this._addUpSecCode,this._addUpADateSt,this._addUpADateEd,this._claimCode,this._isExtractDepo,this._detailsUnit,this._enterpriseName,this._addUpSecName);
		}

		/// <summary>
		/// 請求書(明細書情報)抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のExtrInfo_DemandDetailクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandDetailクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(ExtrInfo_DemandDetail target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.AddUpSecCode == target.AddUpSecCode)
				 && (this.AddUpADateSt == target.AddUpADateSt)
				 && (this.AddUpADateEd == target.AddUpADateEd)
				 && (this.ClaimCode == target.ClaimCode)
				 && (this.IsExtractDepo == target.IsExtractDepo)
				 && (this.DetailsUnit == target.DetailsUnit)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.AddUpSecName == target.AddUpSecName));
		}

		/// <summary>
		/// 請求書(明細書情報)抽出条件クラス比較処理
		/// </summary>
		/// <param name="extrInfo_DemandDetail1">
		///                    比較するExtrInfo_DemandDetailクラスのインスタンス
		/// </param>
		/// <param name="extrInfo_DemandDetail2">比較するExtrInfo_DemandDetailクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandDetailクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(ExtrInfo_DemandDetail extrInfo_DemandDetail1, ExtrInfo_DemandDetail extrInfo_DemandDetail2)
		{
			return ((extrInfo_DemandDetail1.EnterpriseCode == extrInfo_DemandDetail2.EnterpriseCode)
				 && (extrInfo_DemandDetail1.AddUpSecCode == extrInfo_DemandDetail2.AddUpSecCode)
				 && (extrInfo_DemandDetail1.AddUpADateSt == extrInfo_DemandDetail2.AddUpADateSt)
				 && (extrInfo_DemandDetail1.AddUpADateEd == extrInfo_DemandDetail2.AddUpADateEd)
				 && (extrInfo_DemandDetail1.ClaimCode == extrInfo_DemandDetail2.ClaimCode)
				 && (extrInfo_DemandDetail1.IsExtractDepo == extrInfo_DemandDetail2.IsExtractDepo)
				 && (extrInfo_DemandDetail1.DetailsUnit == extrInfo_DemandDetail2.DetailsUnit)
				 && (extrInfo_DemandDetail1.EnterpriseName == extrInfo_DemandDetail2.EnterpriseName)
				 && (extrInfo_DemandDetail1.AddUpSecName == extrInfo_DemandDetail2.AddUpSecName));
		}
		/// <summary>
		/// 請求書(明細書情報)抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のExtrInfo_DemandDetailクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandDetailクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(ExtrInfo_DemandDetail target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.AddUpSecCode != target.AddUpSecCode)resList.Add("AddUpSecCode");
			if(this.AddUpADateSt != target.AddUpADateSt)resList.Add("AddUpADateSt");
			if(this.AddUpADateEd != target.AddUpADateEd)resList.Add("AddUpADateEd");
			if(this.ClaimCode != target.ClaimCode)resList.Add("ClaimCode");
			if(this.IsExtractDepo != target.IsExtractDepo)resList.Add("IsExtractDepo");
			if(this.DetailsUnit != target.DetailsUnit)resList.Add("DetailsUnit");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.AddUpSecName != target.AddUpSecName)resList.Add("AddUpSecName");

			return resList;
		}

		/// <summary>
		/// 請求書(明細書情報)抽出条件クラス比較処理
		/// </summary>
		/// <param name="extrInfo_DemandDetail1">比較するExtrInfo_DemandDetailクラスのインスタンス</param>
		/// <param name="extrInfo_DemandDetail2">比較するExtrInfo_DemandDetailクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandDetailクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(ExtrInfo_DemandDetail extrInfo_DemandDetail1, ExtrInfo_DemandDetail extrInfo_DemandDetail2)
		{
			ArrayList resList = new ArrayList();
			if(extrInfo_DemandDetail1.EnterpriseCode != extrInfo_DemandDetail2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(extrInfo_DemandDetail1.AddUpSecCode != extrInfo_DemandDetail2.AddUpSecCode)resList.Add("AddUpSecCode");
			if(extrInfo_DemandDetail1.AddUpADateSt != extrInfo_DemandDetail2.AddUpADateSt)resList.Add("AddUpADateSt");
			if(extrInfo_DemandDetail1.AddUpADateEd != extrInfo_DemandDetail2.AddUpADateEd)resList.Add("AddUpADateEd");
			if(extrInfo_DemandDetail1.ClaimCode != extrInfo_DemandDetail2.ClaimCode)resList.Add("ClaimCode");
			if(extrInfo_DemandDetail1.IsExtractDepo != extrInfo_DemandDetail2.IsExtractDepo)resList.Add("IsExtractDepo");
			if(extrInfo_DemandDetail1.DetailsUnit != extrInfo_DemandDetail2.DetailsUnit)resList.Add("DetailsUnit");
			if(extrInfo_DemandDetail1.EnterpriseName != extrInfo_DemandDetail2.EnterpriseName)resList.Add("EnterpriseName");
			if(extrInfo_DemandDetail1.AddUpSecName != extrInfo_DemandDetail2.AddUpSecName)resList.Add("AddUpSecName");

			return resList;
		}
	}
}
