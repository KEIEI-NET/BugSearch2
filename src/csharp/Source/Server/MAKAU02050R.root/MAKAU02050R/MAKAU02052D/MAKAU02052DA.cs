using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ExtrInfo_DemandDetailWork
	/// <summary>
	///                      請求書(明細書情報)抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   請求書(明細書情報)抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/05/17  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ExtrInfo_DemandDetailWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>計上拠点コード</summary>
		/// <remarks>集計の対象となっている拠点コード</remarks>
		private string _addUpSecCode = "";

		/// <summary>抽出対象計上日(開始)</summary>
		/// <remarks>"YYYYMMDD"  今回締開始計上日となる年月日</remarks>
		private DateTime _addUpADateSt;

		/// <summary>抽出対象計上日(終了)</summary>
		/// <remarks>"YYYYMMDD"  今回締終了計上日となる年月日</remarks>
        private DateTime _addUpADateEd;

		/// <summary>請求先コード</summary>
		private Int32 _claimCode;

		/// <summary>入金明細抽出有無</summary>
		private bool _isExtractDepo;

		/// <summary>明細単位</summary>
        /// <remarks>0:詳細単位 1:明細単位 2:伝票単位</remarks>
		private Int32 _detailsUnit;


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
        public DateTime AddUpADateSt
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
        public DateTime AddUpADateEd
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


		/// <summary>
		/// 請求書(明細書情報)抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>ExtrInfo_DemandDetailWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DemandDetailWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_DemandDetailWork()
		{
		}

	}
}