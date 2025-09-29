using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ExtrInfo_ShipGoodsAnalyzeWork
	/// <summary>
	///                      出荷商品分析表抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   出荷商品分析表抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/09/29  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
    /// <br>Update Note      :   2014/12/22 尹晶晶</br>
    /// <br>管理番号         :   11070263-00</br>
    /// <br>                 :   明治産業様Seiken品番変更</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ExtrInfo_ShipGoodsAnalyzeWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>(配列)　全社指定はnull</remarks>
		private string[] _sectionCodes;

		/// <summary>集計方法</summary>
		/// <remarks>0:全社 1:拠点毎</remarks>
		private Int32 _ttlType;

		/// <summary>開始対象年月</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _st_AddUpYearMonth;

		/// <summary>終了対象年月</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _ed_AddUpYearMonth;

		/// <summary>在庫登録日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _ex_StockCreateDate;

		/// <summary>在庫登録日検索区分</summary>
		/// <remarks>0:以前 1:以後</remarks>
		private Int32 _beforeAfter;

		/// <summary>在庫取寄せ区分</summary>
		/// <remarks>0:合計 1:在庫, 2:取寄せ</remarks>
		private Int32 _rsltTtlDivCd;

        //------ ADD START 2014/12/23 尹晶晶 FOR Redmine#44209改良 ------>>>>>
        /// <summary>品番集計区分</summary>
        /// <remarks>0:別々 1:合算</remarks>
        private Int32 _goodsNoTtlDiv;

        /// <summary>品番表示区分</summary>
        /// <remarks>0:新品番 1:旧品番</remarks>
        private Int32 _goodsNoShowDiv;
        //------ ADD END 2014/12/23 尹晶晶 FOR Redmine#44209改良 ------<<<<<
        
		/// <summary>開始仕入先コード</summary>
		private Int32 _supplierCdSt;

		/// <summary>終了仕入先コード</summary>
		private Int32 _supplierCdEd;

		/// <summary>開始商品メーカーコード</summary>
		private Int32 _goodsMakerCdSt;

		/// <summary>終了商品メーカーコード</summary>
		private Int32 _goodsMakerCdEd;

		/// <summary>開始商品大分類コード</summary>
		private Int32 _goodsLGroupSt;

		/// <summary>終了商品大分類コード</summary>
		private Int32 _goodsLGroupEd;

		/// <summary>開始商品中分類コード</summary>
		private Int32 _goodsMGroupSt;

		/// <summary>終了商品中分類コード</summary>
		private Int32 _goodsMGroupEd;

		/// <summary>開始BLグループコード</summary>
		private Int32 _bLGroupCodeSt;

		/// <summary>終了BLグループコード</summary>
		private Int32 _bLGroupCodeEd;

		/// <summary>開始BL商品コード</summary>
		private Int32 _bLGoodsCodeSt;

		/// <summary>終了BL商品コード</summary>
		private Int32 _bLGoodsCodeEd;

		/// <summary>開始商品番号</summary>
		private string _goodsNoSt = "";

		/// <summary>終了商品番号</summary>
		private string _goodsNoEd = "";


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
		/// <value>(配列)　全社指定はnull</value>
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

		/// public propaty name  :  TtlType
		/// <summary>集計方法プロパティ</summary>
		/// <value>0:全社 1:拠点毎</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   集計方法プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TtlType
		{
			get{return _ttlType;}
			set{_ttlType = value;}
		}

		/// public propaty name  :  St_AddUpYearMonth
		/// <summary>開始対象年月プロパティ</summary>
		/// <value>YYYYMM</value>
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
		/// <value>YYYYMM</value>
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

		/// public propaty name  :  Ex_StockCreateDate
		/// <summary>在庫登録日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫登録日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Ex_StockCreateDate
		{
			get{return _ex_StockCreateDate;}
			set{_ex_StockCreateDate = value;}
		}

		/// public propaty name  :  BeforeAfter
		/// <summary>在庫登録日検索区分プロパティ</summary>
		/// <value>0:以前 1:以後</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫登録日検索区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BeforeAfter
		{
			get{return _beforeAfter;}
			set{_beforeAfter = value;}
		}

		/// public propaty name  :  RsltTtlDivCd
		/// <summary>在庫取寄せ区分プロパティ</summary>
		/// <value>0:合計 1:在庫, 2:取寄せ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫取寄せ区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 RsltTtlDivCd
		{
			get{return _rsltTtlDivCd;}
			set{_rsltTtlDivCd = value;}
		}

        //------ ADD START 2014/12/23 尹晶晶 FOR Redmine#44209改良 ------>>>>>
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
        //------ ADD END 2014/12/23 尹晶晶 FOR Redmine#44209改良 ------<<<<<

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

		/// public propaty name  :  GoodsMakerCdSt
		/// <summary>開始商品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMakerCdSt
		{
			get{return _goodsMakerCdSt;}
			set{_goodsMakerCdSt = value;}
		}

		/// public propaty name  :  GoodsMakerCdEd
		/// <summary>終了商品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMakerCdEd
		{
			get{return _goodsMakerCdEd;}
			set{_goodsMakerCdEd = value;}
		}

		/// public propaty name  :  GoodsLGroupSt
		/// <summary>開始商品大分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品大分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsLGroupSt
		{
			get{return _goodsLGroupSt;}
			set{_goodsLGroupSt = value;}
		}

		/// public propaty name  :  GoodsLGroupEd
		/// <summary>終了商品大分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品大分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsLGroupEd
		{
			get{return _goodsLGroupEd;}
			set{_goodsLGroupEd = value;}
		}

		/// public propaty name  :  GoodsMGroupSt
		/// <summary>開始商品中分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品中分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMGroupSt
		{
			get{return _goodsMGroupSt;}
			set{_goodsMGroupSt = value;}
		}

		/// public propaty name  :  GoodsMGroupEd
		/// <summary>終了商品中分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品中分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMGroupEd
		{
			get{return _goodsMGroupEd;}
			set{_goodsMGroupEd = value;}
		}

		/// public propaty name  :  BLGroupCodeSt
		/// <summary>開始BLグループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始BLグループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGroupCodeSt
		{
			get{return _bLGroupCodeSt;}
			set{_bLGroupCodeSt = value;}
		}

		/// public propaty name  :  BLGroupCodeEd
		/// <summary>終了BLグループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了BLグループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGroupCodeEd
		{
			get{return _bLGroupCodeEd;}
			set{_bLGroupCodeEd = value;}
		}

		/// public propaty name  :  BLGoodsCodeSt
		/// <summary>開始BL商品コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始BL商品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGoodsCodeSt
		{
			get{return _bLGoodsCodeSt;}
			set{_bLGoodsCodeSt = value;}
		}

		/// public propaty name  :  BLGoodsCodeEd
		/// <summary>終了BL商品コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了BL商品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGoodsCodeEd
		{
			get{return _bLGoodsCodeEd;}
			set{_bLGoodsCodeEd = value;}
		}

		/// public propaty name  :  GoodsNoSt
		/// <summary>開始商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNoSt
		{
			get{return _goodsNoSt;}
			set{_goodsNoSt = value;}
		}

		/// public propaty name  :  GoodsNoEd
		/// <summary>終了商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNoEd
		{
			get{return _goodsNoEd;}
			set{_goodsNoEd = value;}
		}


		/// <summary>
		/// 出荷商品分析表抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>ExtrInfo_ShipGoodsAnalyzeWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_ShipGoodsAnalyzeWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_ShipGoodsAnalyzeWork()
		{
		}

	}
}
