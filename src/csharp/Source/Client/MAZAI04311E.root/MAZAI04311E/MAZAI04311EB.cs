using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockAcPayHisSearchPara
	/// <summary>
	///                      在庫受払履歴検索条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫受払履歴検索条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/12/03  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class StockAcPayHisSearchPara
	{
        # region ■ private field ■

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>有効区分</summary>
		/// <remarks>0:有効 1:無効（修正前又は削除）</remarks>
		private Int32 _validDivCd;

		/// <summary>開始入出荷日</summary>
		private DateTime _st_IoGoodsDay;

		/// <summary>終了入出荷日</summary>
        private DateTime _ed_IoGoodsDay;

		/// <summary>開始計上日付</summary>
		/// <remarks>（予備項目）</remarks>
        private DateTime _st_AddUpADate;

		/// <summary>終了計上日付</summary>
		/// <remarks>（予備項目）</remarks>
        private DateTime _ed_AddUpADate;

		/// <summary>受払元伝票区分</summary>
		/// <remarks>-1:全て,10:仕入,11:入荷,12:受計上,20:売上,21:売計上,22:出荷,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸</remarks>
		private Int32 _acPaySlipCd;

		/// <summary>拠点コード（複数指定）</summary>
		/// <remarks>（※配列）出荷、入荷が発生する拠点</remarks>
		private string[] _sectionCodes = new string[0];

		/// <summary>開始倉庫コード</summary>
		/// <remarks>出荷、入荷が発生する倉庫</remarks>
		private string _st_WarehouseCode = "";

		/// <summary>終了倉庫コード</summary>
		/// <remarks>出荷、入荷が発生する倉庫</remarks>
		private string _ed_WarehouseCode = "";

		/// <summary>開始商品メーカーコード</summary>
		/// <remarks>提供範囲はプロダクト毎で定義</remarks>
		private Int32 _st_GoodsMakerCd;

		/// <summary>終了商品メーカーコード</summary>
		/// <remarks>提供範囲はプロダクト毎で定義</remarks>
		private Int32 _ed_GoodsMakerCd;

		/// <summary>開始受払元伝票番号</summary>
		/// <remarks>「受払元伝票」の伝票番号を格納</remarks>
		private string _st_AcPaySlipNum = "";

		/// <summary>終了受払元伝票番号</summary>
		/// <remarks>「受払元伝票」の伝票番号を格納</remarks>
		private string _ed_AcPaySlipNum = "";

		/// <summary>開始商品番号</summary>
		private string _st_GoodsNo = "";

		/// <summary>終了商品番号</summary>
		private string _ed_GoodsNo = "";

        /// <summary>履歴開始年月</summary>
        /// <remarks>前月開始年月 YYYYMM</remarks>
        private Int32 _st_HisYearMonth;

        /// <summary>受払開始年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _st_AcPayDate;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

        # endregion  ■ private field ■

        # region ■ public propaty ■

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

		/// public propaty name  :  ValidDivCd
		/// <summary>有効区分プロパティ</summary>
		/// <value>0:有効 1:無効（修正前又は削除）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   有効区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ValidDivCd
		{
			get{return _validDivCd;}
			set{_validDivCd = value;}
		}

		/// public propaty name  :  St_IoGoodsDay
		/// <summary>開始入出荷日プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始入出荷日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime St_IoGoodsDay
		{
			get{return _st_IoGoodsDay;}
			set{_st_IoGoodsDay = value;}
		}

		/// public propaty name  :  Ed_IoGoodsDay
		/// <summary>終了入出荷日プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了入出荷日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime Ed_IoGoodsDay
		{
			get{return _ed_IoGoodsDay;}
			set{_ed_IoGoodsDay = value;}
		}

		/// public propaty name  :  St_AddUpADate
		/// <summary>開始計上日付プロパティ</summary>
		/// <value>（予備項目）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始計上日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime St_AddUpADate
		{
			get{return _st_AddUpADate;}
			set{_st_AddUpADate = value;}
		}

		/// public propaty name  :  Ed_AddUpADate
		/// <summary>終了計上日付プロパティ</summary>
		/// <value>（予備項目）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了計上日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime Ed_AddUpADate
		{
			get{return _ed_AddUpADate;}
			set{_ed_AddUpADate = value;}
		}

		/// public propaty name  :  AcPaySlipCd
		/// <summary>受払元伝票区分プロパティ</summary>
		/// <value>-1:全て,10:仕入,11:入荷,12:受計上,20:売上,21:売計上,22:出荷,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受払元伝票区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcPaySlipCd
		{
			get{return _acPaySlipCd;}
			set{_acPaySlipCd = value;}
		}

		/// public propaty name  :  SectionCodes
		/// <summary>拠点コード（複数指定）プロパティ</summary>
		/// <value>（※配列）出荷、入荷が発生する拠点</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コード（複数指定）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

		/// public propaty name  :  St_WarehouseCode
		/// <summary>開始倉庫コードプロパティ</summary>
		/// <value>出荷、入荷が発生する倉庫</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_WarehouseCode
		{
			get{return _st_WarehouseCode;}
			set{_st_WarehouseCode = value;}
		}

		/// public propaty name  :  Ed_WarehouseCode
		/// <summary>終了倉庫コードプロパティ</summary>
		/// <value>出荷、入荷が発生する倉庫</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_WarehouseCode
		{
			get{return _ed_WarehouseCode;}
			set{_ed_WarehouseCode = value;}
		}

		/// public propaty name  :  St_GoodsMakerCd
		/// <summary>開始商品メーカーコードプロパティ</summary>
		/// <value>提供範囲はプロダクト毎で定義</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_GoodsMakerCd
		{
			get{return _st_GoodsMakerCd;}
			set{_st_GoodsMakerCd = value;}
		}

		/// public propaty name  :  Ed_GoodsMakerCd
		/// <summary>終了商品メーカーコードプロパティ</summary>
		/// <value>提供範囲はプロダクト毎で定義</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_GoodsMakerCd
		{
			get{return _ed_GoodsMakerCd;}
			set{_ed_GoodsMakerCd = value;}
		}

		/// public propaty name  :  St_AcPaySlipNum
		/// <summary>開始受払元伝票番号プロパティ</summary>
		/// <value>「受払元伝票」の伝票番号を格納</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始受払元伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_AcPaySlipNum
		{
			get{return _st_AcPaySlipNum;}
			set{_st_AcPaySlipNum = value;}
		}

		/// public propaty name  :  Ed_AcPaySlipNum
		/// <summary>終了受払元伝票番号プロパティ</summary>
		/// <value>「受払元伝票」の伝票番号を格納</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了受払元伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_AcPaySlipNum
		{
			get{return _ed_AcPaySlipNum;}
			set{_ed_AcPaySlipNum = value;}
		}

		/// public propaty name  :  St_GoodsNo
		/// <summary>開始商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_GoodsNo
		{
			get{return _st_GoodsNo;}
			set{_st_GoodsNo = value;}
		}

		/// public propaty name  :  Ed_GoodsNo
		/// <summary>終了商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_GoodsNo
		{
			get{return _ed_GoodsNo;}
			set{_ed_GoodsNo = value;}
		}

        /// public propaty name  :  St_HisYearMonth
        /// <summary>履歴開始年月プロパティ</summary>
        /// <value>前月開始年月 YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   履歴開始年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_HisYearMonth
        {
            get { return _st_HisYearMonth; }
            set { _st_HisYearMonth = value; }
        }

        /// public propaty name  :  St_AcPayDate
        /// <summary>受払開始年月日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受払開始年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_AcPayDate
        {
            get { return _st_AcPayDate; }
            set { _st_AcPayDate = value; }
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
        # endregion ■ public propaty ■

        # region ■ private field (自動生成以外) ■
        /// <summary>
        /// 拠点オプション区分
        /// </summary>
        private bool _isOptSection = false;
        /// <summary>
        /// 全拠点選択区分
        /// </summary>
        private bool _isSelectAllSection = false;
        # endregion ■ private field (自動生成以外) ■

        # region ■ public propaty (自動生成以外) ■
        /// <summary>
        /// 拠点オプション区分プロパティ
        /// </summary>
        public bool IsOptSection
        {
            get { return this._isOptSection; }
            set { this._isOptSection = value; }
        }
        /// <summary>
        /// 全拠点選択区分プロパティ
        /// </summary>
        public bool IsSelectAllSection
        {
            get { return this._isSelectAllSection; }
            set { this._isSelectAllSection = value; }
        }
        # endregion ■ public propaty (自動生成以外) ■

        # region ■ public Enum (自動生成以外) ■
        # endregion ■ public Enum (自動生成以外) ■

        #region ■ public const (自動生成以外) ■
        /// <summary>共通 日付フォーマット</summary>
        public const string ct_DateFomat = "YYYY/MM/DD";

        /// <summary>共通 全て コード</summary>
        public const int ct_All_Code = -1;
        /// <summary>共通 全て 名称</summary>
        public const string ct_All_Name = "全て";
        #endregion

        # region ■ Constructor ■
        /// <summary>
        /// 在庫受払履歴検索条件クラスコンストラクタ
        /// </summary>
        /// <returns>StockAcPayHisSearchParaクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockAcPayHisSearchParaクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockAcPayHisSearchPara ()
        {
        }
        # endregion ■ Constructor ■
    }
}
