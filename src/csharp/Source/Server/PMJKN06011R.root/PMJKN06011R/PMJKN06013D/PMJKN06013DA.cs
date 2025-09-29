using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   FreeSearchPartsSParaWork
	/// <summary>
	///                      自由検索部品抽出条件ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   自由検索部品抽出条件ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2010/04/23  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class FreeSearchPartsSParaWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>自由検索部品固有番号</summary>
		private string[] _freSrchPrtPropNos = new string[0];

		/// <summary>ＢＬコード</summary>
		private Int32 _tbsPartsCode;

		/// <summary>ＢＬコード枝番</summary>
		/// <remarks>※未使用項目（レイアウトには入れておく）</remarks>
		private Int32 _tbsPartsCdDerivedNo;

		/// <summary>価格開始日</summary>
		/// <remarks>YYYYMMDD 指定値以前を抽出</remarks>
		private DateTime _priceStartDate;

		/// <summary>抽出条件(車輌)</summary>
		/// <remarks>抽出条件(車輌)の配列</remarks>
        private FreeSearchPartsSMdlParaWork[] _fSPartsSModels = new FreeSearchPartsSMdlParaWork[0];

        /// <summary>品番</summary>
        private string _goodsNo = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

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

		/// public propaty name  :  FreSrchPrtPropNos
		/// <summary>自由検索部品固有番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自由検索部品固有番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] FreSrchPrtPropNos
		{
			get{return _freSrchPrtPropNos;}
			set{_freSrchPrtPropNos = value;}
		}

		/// public propaty name  :  TbsPartsCode
		/// <summary>ＢＬコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ＢＬコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TbsPartsCode
		{
			get{return _tbsPartsCode;}
			set{_tbsPartsCode = value;}
		}

		/// public propaty name  :  TbsPartsCdDerivedNo
		/// <summary>ＢＬコード枝番プロパティ</summary>
		/// <value>※未使用項目（レイアウトには入れておく）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ＢＬコード枝番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TbsPartsCdDerivedNo
		{
			get{return _tbsPartsCdDerivedNo;}
			set{_tbsPartsCdDerivedNo = value;}
		}

		/// public propaty name  :  PriceStartDate
		/// <summary>価格開始日プロパティ</summary>
		/// <value>YYYYMMDD 指定値以前を抽出</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   価格開始日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime PriceStartDate
		{
			get{return _priceStartDate;}
			set{_priceStartDate = value;}
		}

		/// public propaty name  :  FSPartsSModels
		/// <summary>抽出条件(車輌)プロパティ</summary>
		/// <value>抽出条件(車輌)の配列</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出条件(車輌)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FreeSearchPartsSMdlParaWork[] FSPartsSModels
		{
			get{return _fSPartsSModels;}
			set{_fSPartsSModels = value;}
		}

        /// public propaty name  :  GoodsNo
        /// <summary>品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

		/// <summary>
		/// 自由検索部品抽出条件ワークコンストラクタ
		/// </summary>
		/// <returns>FreeSearchPartsSParaWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FreeSearchPartsSParaWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FreeSearchPartsSParaWork()
		{
		}
	}
}
