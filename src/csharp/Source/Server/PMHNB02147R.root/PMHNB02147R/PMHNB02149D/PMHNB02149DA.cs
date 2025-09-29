using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ShipGdsPrimeListCndtnWork
	/// <summary>
	///                      出荷商品優良対応表抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   出荷商品優良対応表抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/30  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
    /// <br>Update Note      :   2014/12/30 尹晶晶</br>
    /// <br>管理番号         :   11070263-00</br>
    /// <br>                 :   明治産業様Seiken品番変更</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ShipGdsPrimeListCndtnWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>(配列) nullで全社指定</remarks>
		private string[] _sectionCodes;

		/// <summary>開始対象年月</summary>
		private DateTime _st_AddUpYearMonth;

		/// <summary>終了対象年月</summary>
		private DateTime _ed_AddUpYearMonth;

        //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
        /// <summary>品番集計区分</summary>
        /// <remarks>0:別々 1:合算</remarks>
        private Int32 _goodsNoTtlDiv;

        /// <summary>品番表示区分</summary>
        /// <remarks>0:新品番 1:旧品番</remarks>
        private Int32 _goodsNoShowDiv;
        //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<
        
		/// <summary>開始メーカーコード</summary>
		private Int32 _st_GoodsMakerCd;

		/// <summary>終了メーカーコード</summary>
		private Int32 _ed_GoodsMakerCd;

		/// <summary>開始大分類コード</summary>
		/// <remarks>グループコードマスタ</remarks>
		private Int32 _st_GoodsLGroup;

		/// <summary>終了大分類コード</summary>
		/// <remarks>グループコードマスタ</remarks>
		private Int32 _ed_GoodsLGroup;

		/// <summary>開始中分類コード</summary>
		/// <remarks>グループコードマスタ</remarks>
		private Int32 _st_GoodsMGroup;

		/// <summary>終了中分類コード</summary>
		/// <remarks>グループコードマスタ</remarks>
		private Int32 _ed_GoodsMGroup;

		/// <summary>開始グループコード</summary>
		/// <remarks>BLコードマスタ</remarks>
		private Int32 _st_BLGroupCode;

		/// <summary>終了グループコード</summary>
		/// <remarks>BLコードマスタ</remarks>
		private Int32 _ed_BLGroupCode;

		/// <summary>開始ＢＬコード</summary>
		private Int32 _st_BLGoodsCode;

		/// <summary>終了ＢＬコード</summary>
		private Int32 _ed_BLGoodsCode;

		/// <summary>出荷回数</summary>
		/// <remarks>※Ⅱで使用</remarks>
		private Int32 _shipCount;


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
		/// <value>(配列) nullで全社指定</value>
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

		/// public propaty name  :  St_AddUpYearMonth
		/// <summary>開始対象年月プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始対象年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime St_AddUpYearMonth
		{
			get{return _st_AddUpYearMonth;}
			set{_st_AddUpYearMonth = value;}
		}

		/// public propaty name  :  Ed_AddUpYearMonth
		/// <summary>終了対象年月プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了対象年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Ed_AddUpYearMonth
		{
			get{return _ed_AddUpYearMonth;}
			set{_ed_AddUpYearMonth = value;}
		}

        //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
        /// public propaty name  :  GoodsNoTtlDiv
        /// <summary>品番集計区分プロパティ</summary>
        /// <value>0:別々 1:合算</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番集計区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNoTtlDiv
        {
            get { return _goodsNoTtlDiv; }
            set { _goodsNoTtlDiv = value; }
        }

        /// public propaty name  :  GoodsNoShowDiv
        /// <summary>品番表示区分プロパティ</summary>
        /// <value>0:新品番 1:旧品番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNoShowDiv
        {
            get { return _goodsNoShowDiv; }
            set { _goodsNoShowDiv = value; }
        }
        //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<

		/// public propaty name  :  St_GoodsMakerCd
		/// <summary>開始メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_GoodsMakerCd
		{
			get{return _st_GoodsMakerCd;}
			set{_st_GoodsMakerCd = value;}
		}

		/// public propaty name  :  Ed_GoodsMakerCd
		/// <summary>終了メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_GoodsMakerCd
		{
			get{return _ed_GoodsMakerCd;}
			set{_ed_GoodsMakerCd = value;}
		}

		/// public propaty name  :  St_GoodsLGroup
		/// <summary>開始大分類コードプロパティ</summary>
		/// <value>グループコードマスタ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始大分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_GoodsLGroup
		{
			get{return _st_GoodsLGroup;}
			set{_st_GoodsLGroup = value;}
		}

		/// public propaty name  :  Ed_GoodsLGroup
		/// <summary>終了大分類コードプロパティ</summary>
		/// <value>グループコードマスタ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了大分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_GoodsLGroup
		{
			get{return _ed_GoodsLGroup;}
			set{_ed_GoodsLGroup = value;}
		}

		/// public propaty name  :  St_GoodsMGroup
		/// <summary>開始中分類コードプロパティ</summary>
		/// <value>グループコードマスタ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始中分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_GoodsMGroup
		{
			get{return _st_GoodsMGroup;}
			set{_st_GoodsMGroup = value;}
		}

		/// public propaty name  :  Ed_GoodsMGroup
		/// <summary>終了中分類コードプロパティ</summary>
		/// <value>グループコードマスタ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了中分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_GoodsMGroup
		{
			get{return _ed_GoodsMGroup;}
			set{_ed_GoodsMGroup = value;}
		}

		/// public propaty name  :  St_BLGroupCode
		/// <summary>開始グループコードプロパティ</summary>
		/// <value>BLコードマスタ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_BLGroupCode
		{
			get{return _st_BLGroupCode;}
			set{_st_BLGroupCode = value;}
		}

		/// public propaty name  :  Ed_BLGroupCode
		/// <summary>終了グループコードプロパティ</summary>
		/// <value>BLコードマスタ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_BLGroupCode
		{
			get{return _ed_BLGroupCode;}
			set{_ed_BLGroupCode = value;}
		}

		/// public propaty name  :  St_BLGoodsCode
		/// <summary>開始ＢＬコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始ＢＬコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_BLGoodsCode
		{
			get{return _st_BLGoodsCode;}
			set{_st_BLGoodsCode = value;}
		}

		/// public propaty name  :  Ed_BLGoodsCode
		/// <summary>終了ＢＬコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了ＢＬコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_BLGoodsCode
		{
			get{return _ed_BLGoodsCode;}
			set{_ed_BLGoodsCode = value;}
		}

		/// public propaty name  :  ShipCount
		/// <summary>出荷回数プロパティ</summary>
		/// <value>※Ⅱで使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷回数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ShipCount
		{
			get{return _shipCount;}
			set{_shipCount = value;}
		}


		/// <summary>
		/// 出荷商品優良対応表抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>ShipGdsPrimeListCndtnWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ShipGdsPrimeListCndtnWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ShipGdsPrimeListCndtnWork()
		{
		}

	}
}




