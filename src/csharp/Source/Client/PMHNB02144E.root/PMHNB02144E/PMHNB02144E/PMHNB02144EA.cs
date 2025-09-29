using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ShipGdsPrimeListCndtn
	/// <summary>
	///                      出荷商品優良対応表抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   出荷商品優良対応表抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/14  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2014/12/16 劉超</br>
    /// <br>管理番号         :   11070263-00</br>
    /// <br>                 :  ・明治産業様Seiken品番変更</br>
    /// <br>Update Note      : 2015/03/27 時シン</br>
    /// <br>管理番号         : 11070263-00</br>
    /// <br>                 : Redmine#44209の#423品番集計区分の名称変更</br>
	/// </remarks>
	public class ShipGdsPrimeListCndtn
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

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

        // 自動生成以外
        /// <summary>拠点オプション区分</summary>
        private bool _isOptSection = false;

        /// <summary>全拠点選択区分</summary>
        private bool _isSelectAllSection = false;

        /// <summary>結合区分</summary>
        /// <remarks>0:全て 1:結合 2:非結合</remarks>
        private ComvDivState _comvDiv;

        /// <summary>順位付設定　単位</summary>
        /// <remarks>0:純正メーカー 1:グループコード 2:商品中分類</remarks>
        private RankSectionState _rankSection;

        /// <summary>順位付設定　上位・下位</summary>
        /// <remarks>0:上位 1:下位</remarks>
        private RankHighLowState _rankHighLow;

        /// <summary>順位付設定　最大値</summary>
        private Int32 _rankOrderMax;

        //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
        /// <summary>品番集計区分</summary>
        /// <remarks>0:別々 1:合算</remarks>
        private GoodsNoTtlDivState _goodsNoTtlDiv;
        /// <summary>品番表示区分</summary>
        /// <remarks>0:新品番 1:旧品番</remarks>
        private GoodsNoShowDivState _goodsNoShowDiv;
        //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

        /// <summary>印刷タイプ</summary>
        /// <remarks>0:当月 1:当期</remarks>
        private PrintTypeState _printType;

        /// <summary>改頁</summary>
        /// <remarks>0:拠点 1:順位毎 2:しない</remarks>
        private NewPageDivState _newPageDiv;

        /// <summary>開始対象年月(当期)</summary>
        private DateTime _st_AnnualAddUpYearMonth;

        /// <summary>終了対象年月(当期)</summary>
        private DateTime _ed_AnnualAddUpYearMonth;

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

        /// <summary>
        /// 結合区分プロパティ
        /// </summary>
        public ComvDivState ComvDiv
        {
            get { return this._comvDiv; }
            set { this._comvDiv = value; }
        }

        /// <summary>
        /// 順位付設定　単位プロパティ
        /// </summary>
        public RankSectionState RankSection
        {
            get { return this._rankSection; }
            set { this._rankSection = value; }
        }

        /// <summary>
        /// 順位付設定　上位・下位プロパティ
        /// </summary>
        public RankHighLowState RankHighLow
        {
            get { return this._rankHighLow; }
            set { this._rankHighLow = value; }
        }

        /// <summary>
        /// 順位付設定　最大値プロパティ
        /// </summary>
        public Int32 RankOrderMax
        {
            get { return this._rankOrderMax; }
            set { this._rankOrderMax = value; }
        }

        //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
        /// <summary>
        /// 品番集計区分プロパティ
        /// </summary>
        public GoodsNoTtlDivState GoodsNoTtlDiv
        {
            get { return _goodsNoTtlDiv; }
            set { _goodsNoTtlDiv = value; }
        }

        /// <summary>
        /// 品番表示区分プロパティ
        /// </summary>
        public GoodsNoShowDivState GoodsNoShowDiv
        {
            get { return _goodsNoShowDiv; }
            set { _goodsNoShowDiv = value; }
        }
        //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

        /// <summary>
        /// 改頁プロパティ
        /// </summary>
        public NewPageDivState NewPageDiv
        {
            get { return this._newPageDiv; }
            set { this._newPageDiv = value; }
        }

        /// <summary>
        /// 印刷タイププロパティ
        /// </summary>
        public PrintTypeState PrintType
        {
            get { return this._printType; }
            set { this._printType = value; }
        }

        /// <summary>
        /// 開始対象年月(当期)
        /// </summary>
        public DateTime St_AnnualAddUpYearMonth
        {
            get { return _st_AnnualAddUpYearMonth; }
            set { _st_AnnualAddUpYearMonth = value; }
        }

        /// <summary>
        /// 終了対象年月(当期)
        /// </summary>
        public DateTime Ed_AnnualAddUpYearMonth
        {
            get { return _ed_AnnualAddUpYearMonth; }
            set { _ed_AnnualAddUpYearMonth = value; }
        }


		/// <summary>
		/// 出荷商品優良対応表抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>ShipGdsPrimeListCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ShipGdsPrimeListCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ShipGdsPrimeListCndtn()
		{
		}

		/// <summary>
		/// 出荷商品優良対応表抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="sectionCodes">拠点コード((配列) nullで全社指定)</param>
		/// <param name="st_AddUpYearMonth">開始対象年月</param>
		/// <param name="ed_AddUpYearMonth">終了対象年月</param>
		/// <param name="st_GoodsMakerCd">開始メーカーコード</param>
		/// <param name="ed_GoodsMakerCd">終了メーカーコード</param>
		/// <param name="st_GoodsLGroup">開始大分類コード(グループコードマスタ)</param>
		/// <param name="ed_GoodsLGroup">終了大分類コード(グループコードマスタ)</param>
		/// <param name="st_GoodsMGroup">開始中分類コード(グループコードマスタ)</param>
		/// <param name="ed_GoodsMGroup">終了中分類コード(グループコードマスタ)</param>
		/// <param name="st_BLGroupCode">開始グループコード(BLコードマスタ)</param>
		/// <param name="ed_BLGroupCode">終了グループコード(BLコードマスタ)</param>
		/// <param name="st_BLGoodsCode">開始ＢＬコード</param>
		/// <param name="ed_BLGoodsCode">終了ＢＬコード</param>
		/// <param name="shipCount">出荷回数(※Ⅱで使用)</param>
		/// <param name="enterpriseName">企業名称</param>
        /// <param name="goodsNoTtlDiv">品番集計区分</param> // ADD 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更
        /// <param name="goodsNoShowDiv">品番表示区分</param> // ADD 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更
		/// <returns>ShipGdsPrimeListCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ShipGdsPrimeListCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ShipGdsPrimeListCndtn(string enterpriseCode,string[] sectionCodes,DateTime st_AddUpYearMonth,DateTime ed_AddUpYearMonth,Int32 st_GoodsMakerCd,Int32 ed_GoodsMakerCd,Int32 st_GoodsLGroup,Int32 ed_GoodsLGroup,Int32 st_GoodsMGroup,Int32 ed_GoodsMGroup,Int32 st_BLGroupCode,Int32 ed_BLGroupCode,Int32 st_BLGoodsCode,Int32 ed_BLGoodsCode,Int32 shipCount,string enterpriseName,
            //bool isOptSection, bool isSelectAllSection, ComvDivState comvDiv, RankSectionState rankSection, RankHighLowState rankHighLow, Int32 rankOrderMax, PrintTypeState printType, NewPageDivState newPageDiv, DateTime st_AnnualAddUpYearMonth, DateTime ed_AnnualAddUpYearMonth) // DEL 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更
            bool isOptSection, bool isSelectAllSection, ComvDivState comvDiv, RankSectionState rankSection, RankHighLowState rankHighLow, Int32 rankOrderMax, PrintTypeState printType, NewPageDivState newPageDiv, GoodsNoTtlDivState goodsNoTtlDiv, GoodsNoShowDivState goodsNoShowDiv, DateTime st_AnnualAddUpYearMonth, DateTime ed_AnnualAddUpYearMonth) // ADD 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCodes = sectionCodes;
			this._st_AddUpYearMonth = st_AddUpYearMonth;
			this._ed_AddUpYearMonth = ed_AddUpYearMonth;
			this._st_GoodsMakerCd = st_GoodsMakerCd;
			this._ed_GoodsMakerCd = ed_GoodsMakerCd;
			this._st_GoodsLGroup = st_GoodsLGroup;
			this._ed_GoodsLGroup = ed_GoodsLGroup;
			this._st_GoodsMGroup = st_GoodsMGroup;
			this._ed_GoodsMGroup = ed_GoodsMGroup;
			this._st_BLGroupCode = st_BLGroupCode;
			this._ed_BLGroupCode = ed_BLGroupCode;
			this._st_BLGoodsCode = st_BLGoodsCode;
			this._ed_BLGoodsCode = ed_BLGoodsCode;
			this._shipCount = shipCount;
			this._enterpriseName = enterpriseName;

            this._isOptSection = isOptSection;
            this._isSelectAllSection = isSelectAllSection;
            this._comvDiv = comvDiv;
            this._rankSection = rankSection;
            this._rankHighLow = rankHighLow;
            this._rankOrderMax = rankOrderMax;
            this._printType = printType;
            this._newPageDiv = newPageDiv;
            //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
            this._goodsNoTtlDiv = goodsNoTtlDiv;
            this._goodsNoShowDiv = goodsNoShowDiv;
            //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<
            this._st_AnnualAddUpYearMonth = st_AnnualAddUpYearMonth;
            this._ed_AnnualAddUpYearMonth = ed_AnnualAddUpYearMonth;

		}

		/// <summary>
		/// 出荷商品優良対応表抽出条件クラス複製処理
		/// </summary>
		/// <returns>ShipGdsPrimeListCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいShipGdsPrimeListCndtnクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ShipGdsPrimeListCndtn Clone()
		{
            //return new ShipGdsPrimeListCndtn(this._enterpriseCode,this._sectionCodes,this._st_AddUpYearMonth,this._ed_AddUpYearMonth,this._st_GoodsMakerCd,this._ed_GoodsMakerCd,this._st_GoodsLGroup,this._ed_GoodsLGroup,this._st_GoodsMGroup,this._ed_GoodsMGroup,this._st_BLGroupCode,this._ed_BLGroupCode,this._st_BLGoodsCode,this._ed_BLGoodsCode,this._shipCount,this._enterpriseName, this._isOptSection, this._isSelectAllSection, this._comvDiv, this._rankSection, this._rankHighLow, this._rankOrderMax, this._printType, this._newPageDiv, this._st_AnnualAddUpYearMonth, this._ed_AnnualAddUpYearMonth); // DEL 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更
            return new ShipGdsPrimeListCndtn(this._enterpriseCode, this._sectionCodes, this._st_AddUpYearMonth, this._ed_AddUpYearMonth, this._st_GoodsMakerCd, this._ed_GoodsMakerCd, this._st_GoodsLGroup, this._ed_GoodsLGroup, this._st_GoodsMGroup, this._ed_GoodsMGroup, this._st_BLGroupCode, this._ed_BLGroupCode, this._st_BLGoodsCode, this._ed_BLGoodsCode, this._shipCount, this._enterpriseName, this._isOptSection, this._isSelectAllSection, this._comvDiv, this._rankSection, this._rankHighLow, this._rankOrderMax, this._printType, this._newPageDiv, this._goodsNoTtlDiv, this._goodsNoShowDiv, this._st_AnnualAddUpYearMonth, this._ed_AnnualAddUpYearMonth); // ADD 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更
		}

		/// <summary>
		/// 出荷商品優良対応表抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のShipGdsPrimeListCndtnクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ShipGdsPrimeListCndtnクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(ShipGdsPrimeListCndtn target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCodes == target.SectionCodes)
				 && (this.St_AddUpYearMonth == target.St_AddUpYearMonth)
				 && (this.Ed_AddUpYearMonth == target.Ed_AddUpYearMonth)
				 && (this.St_GoodsMakerCd == target.St_GoodsMakerCd)
				 && (this.Ed_GoodsMakerCd == target.Ed_GoodsMakerCd)
				 && (this.St_GoodsLGroup == target.St_GoodsLGroup)
				 && (this.Ed_GoodsLGroup == target.Ed_GoodsLGroup)
				 && (this.St_GoodsMGroup == target.St_GoodsMGroup)
				 && (this.Ed_GoodsMGroup == target.Ed_GoodsMGroup)
				 && (this.St_BLGroupCode == target.St_BLGroupCode)
				 && (this.Ed_BLGroupCode == target.Ed_BLGroupCode)
				 && (this.St_BLGoodsCode == target.St_BLGoodsCode)
				 && (this.Ed_BLGoodsCode == target.Ed_BLGoodsCode)
				 && (this.ShipCount == target.ShipCount)
				 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.IsOptSection == target.IsOptSection)
                 && (this.IsSelectAllSection == target.IsSelectAllSection)
                 && (this.ComvDiv == target.ComvDiv)
                 && (this.RankSection == target.RankSection)
                 && (this.RankHighLow == target.RankHighLow)
                 && (this.RankOrderMax == target.RankOrderMax)
                 && (this.NewPageDiv == target.NewPageDiv)
                 //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
                 && (this.GoodsNoTtlDiv == target.GoodsNoTtlDiv)
                 && (this.GoodsNoShowDiv == target.GoodsNoShowDiv)
                 //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<
                 && (this.PrintType == target.PrintType)
                 && (this.St_AnnualAddUpYearMonth == target.St_AnnualAddUpYearMonth)
                 && (this.Ed_AnnualAddUpYearMonth == target.Ed_AnnualAddUpYearMonth)
                 );
		}

		/// <summary>
		/// 出荷商品優良対応表抽出条件クラス比較処理
		/// </summary>
		/// <param name="shipGdsPrimeListCndtn1">
		///                    比較するShipGdsPrimeListCndtnクラスのインスタンス
		/// </param>
		/// <param name="shipGdsPrimeListCndtn2">比較するShipGdsPrimeListCndtnクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ShipGdsPrimeListCndtnクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn1, ShipGdsPrimeListCndtn shipGdsPrimeListCndtn2)
		{
			return ((shipGdsPrimeListCndtn1.EnterpriseCode == shipGdsPrimeListCndtn2.EnterpriseCode)
				 && (shipGdsPrimeListCndtn1.SectionCodes == shipGdsPrimeListCndtn2.SectionCodes)
				 && (shipGdsPrimeListCndtn1.St_AddUpYearMonth == shipGdsPrimeListCndtn2.St_AddUpYearMonth)
				 && (shipGdsPrimeListCndtn1.Ed_AddUpYearMonth == shipGdsPrimeListCndtn2.Ed_AddUpYearMonth)
				 && (shipGdsPrimeListCndtn1.St_GoodsMakerCd == shipGdsPrimeListCndtn2.St_GoodsMakerCd)
				 && (shipGdsPrimeListCndtn1.Ed_GoodsMakerCd == shipGdsPrimeListCndtn2.Ed_GoodsMakerCd)
				 && (shipGdsPrimeListCndtn1.St_GoodsLGroup == shipGdsPrimeListCndtn2.St_GoodsLGroup)
				 && (shipGdsPrimeListCndtn1.Ed_GoodsLGroup == shipGdsPrimeListCndtn2.Ed_GoodsLGroup)
				 && (shipGdsPrimeListCndtn1.St_GoodsMGroup == shipGdsPrimeListCndtn2.St_GoodsMGroup)
				 && (shipGdsPrimeListCndtn1.Ed_GoodsMGroup == shipGdsPrimeListCndtn2.Ed_GoodsMGroup)
				 && (shipGdsPrimeListCndtn1.St_BLGroupCode == shipGdsPrimeListCndtn2.St_BLGroupCode)
				 && (shipGdsPrimeListCndtn1.Ed_BLGroupCode == shipGdsPrimeListCndtn2.Ed_BLGroupCode)
				 && (shipGdsPrimeListCndtn1.St_BLGoodsCode == shipGdsPrimeListCndtn2.St_BLGoodsCode)
				 && (shipGdsPrimeListCndtn1.Ed_BLGoodsCode == shipGdsPrimeListCndtn2.Ed_BLGoodsCode)
				 && (shipGdsPrimeListCndtn1.ShipCount == shipGdsPrimeListCndtn2.ShipCount)
				 && (shipGdsPrimeListCndtn1.EnterpriseName == shipGdsPrimeListCndtn2.EnterpriseName)
                 && (shipGdsPrimeListCndtn1.IsOptSection == shipGdsPrimeListCndtn2.IsOptSection)
                 && (shipGdsPrimeListCndtn1.IsSelectAllSection == shipGdsPrimeListCndtn2.IsSelectAllSection)
                 && (shipGdsPrimeListCndtn1.ComvDiv == shipGdsPrimeListCndtn2.ComvDiv)
                 && (shipGdsPrimeListCndtn1.RankSection == shipGdsPrimeListCndtn2.RankSection)
                 && (shipGdsPrimeListCndtn1.RankHighLow == shipGdsPrimeListCndtn2.RankHighLow)
                 && (shipGdsPrimeListCndtn1.RankOrderMax == shipGdsPrimeListCndtn2.RankOrderMax)
                 && (shipGdsPrimeListCndtn1.NewPageDiv == shipGdsPrimeListCndtn2.NewPageDiv)
                 //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
                 && (shipGdsPrimeListCndtn1.GoodsNoTtlDiv == shipGdsPrimeListCndtn2.GoodsNoTtlDiv)
                 && (shipGdsPrimeListCndtn1.GoodsNoShowDiv == shipGdsPrimeListCndtn2.GoodsNoShowDiv)
                 //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<
                 && (shipGdsPrimeListCndtn1.PrintType == shipGdsPrimeListCndtn2.PrintType)
                 && (shipGdsPrimeListCndtn1.St_AnnualAddUpYearMonth == shipGdsPrimeListCndtn2.St_AnnualAddUpYearMonth)
                 && (shipGdsPrimeListCndtn1.Ed_AnnualAddUpYearMonth == shipGdsPrimeListCndtn2.Ed_AnnualAddUpYearMonth)
                 );
		}
		/// <summary>
		/// 出荷商品優良対応表抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のShipGdsPrimeListCndtnクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ShipGdsPrimeListCndtnクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(ShipGdsPrimeListCndtn target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCodes != target.SectionCodes)resList.Add("SectionCodes");
			if(this.St_AddUpYearMonth != target.St_AddUpYearMonth)resList.Add("St_AddUpYearMonth");
			if(this.Ed_AddUpYearMonth != target.Ed_AddUpYearMonth)resList.Add("Ed_AddUpYearMonth");
			if(this.St_GoodsMakerCd != target.St_GoodsMakerCd)resList.Add("St_GoodsMakerCd");
			if(this.Ed_GoodsMakerCd != target.Ed_GoodsMakerCd)resList.Add("Ed_GoodsMakerCd");
			if(this.St_GoodsLGroup != target.St_GoodsLGroup)resList.Add("St_GoodsLGroup");
			if(this.Ed_GoodsLGroup != target.Ed_GoodsLGroup)resList.Add("Ed_GoodsLGroup");
			if(this.St_GoodsMGroup != target.St_GoodsMGroup)resList.Add("St_GoodsMGroup");
			if(this.Ed_GoodsMGroup != target.Ed_GoodsMGroup)resList.Add("Ed_GoodsMGroup");
			if(this.St_BLGroupCode != target.St_BLGroupCode)resList.Add("St_BLGroupCode");
			if(this.Ed_BLGroupCode != target.Ed_BLGroupCode)resList.Add("Ed_BLGroupCode");
			if(this.St_BLGoodsCode != target.St_BLGoodsCode)resList.Add("St_BLGoodsCode");
			if(this.Ed_BLGoodsCode != target.Ed_BLGoodsCode)resList.Add("Ed_BLGoodsCode");
			if(this.ShipCount != target.ShipCount)resList.Add("ShipCount");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
            if (this.IsOptSection != target.IsOptSection) resList.Add("IsOptSection");
            if (this.IsSelectAllSection != target.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (this.ComvDiv != target.ComvDiv) resList.Add("ComvDiv");
            if (this.RankSection != target.RankSection) resList.Add("RankSection");
            if (this.RankHighLow != target.RankHighLow) resList.Add("RankHighLow");
            if (this.RankOrderMax != target.RankOrderMax) resList.Add("RankOrderMax");
            if (this.NewPageDiv != target.NewPageDiv) resList.Add("NewPageDiv");
            //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
            if (this.GoodsNoTtlDiv != target.GoodsNoTtlDiv) resList.Add("GoodsNoTtlDiv");
            if (this.GoodsNoShowDiv != target.GoodsNoShowDiv) resList.Add("GoodsNoShowDiv");
            //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<
            if (this.PrintType != target.PrintType) resList.Add("PrintType");
            if (this.St_AnnualAddUpYearMonth != target.St_AnnualAddUpYearMonth) resList.Add("St_AnnualAddUpYearMonth");
            if (this.Ed_AnnualAddUpYearMonth != target.Ed_AnnualAddUpYearMonth) resList.Add("Ed_AnnualAddUpYearMonth");

			return resList;
		}

		/// <summary>
		/// 出荷商品優良対応表抽出条件クラス比較処理
		/// </summary>
		/// <param name="shipGdsPrimeListCndtn1">比較するShipGdsPrimeListCndtnクラスのインスタンス</param>
		/// <param name="shipGdsPrimeListCndtn2">比較するShipGdsPrimeListCndtnクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ShipGdsPrimeListCndtnクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn1, ShipGdsPrimeListCndtn shipGdsPrimeListCndtn2)
		{
			ArrayList resList = new ArrayList();
			if(shipGdsPrimeListCndtn1.EnterpriseCode != shipGdsPrimeListCndtn2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(shipGdsPrimeListCndtn1.SectionCodes != shipGdsPrimeListCndtn2.SectionCodes)resList.Add("SectionCodes");
			if(shipGdsPrimeListCndtn1.St_AddUpYearMonth != shipGdsPrimeListCndtn2.St_AddUpYearMonth)resList.Add("St_AddUpYearMonth");
			if(shipGdsPrimeListCndtn1.Ed_AddUpYearMonth != shipGdsPrimeListCndtn2.Ed_AddUpYearMonth)resList.Add("Ed_AddUpYearMonth");
			if(shipGdsPrimeListCndtn1.St_GoodsMakerCd != shipGdsPrimeListCndtn2.St_GoodsMakerCd)resList.Add("St_GoodsMakerCd");
			if(shipGdsPrimeListCndtn1.Ed_GoodsMakerCd != shipGdsPrimeListCndtn2.Ed_GoodsMakerCd)resList.Add("Ed_GoodsMakerCd");
			if(shipGdsPrimeListCndtn1.St_GoodsLGroup != shipGdsPrimeListCndtn2.St_GoodsLGroup)resList.Add("St_GoodsLGroup");
			if(shipGdsPrimeListCndtn1.Ed_GoodsLGroup != shipGdsPrimeListCndtn2.Ed_GoodsLGroup)resList.Add("Ed_GoodsLGroup");
			if(shipGdsPrimeListCndtn1.St_GoodsMGroup != shipGdsPrimeListCndtn2.St_GoodsMGroup)resList.Add("St_GoodsMGroup");
			if(shipGdsPrimeListCndtn1.Ed_GoodsMGroup != shipGdsPrimeListCndtn2.Ed_GoodsMGroup)resList.Add("Ed_GoodsMGroup");
			if(shipGdsPrimeListCndtn1.St_BLGroupCode != shipGdsPrimeListCndtn2.St_BLGroupCode)resList.Add("St_BLGroupCode");
			if(shipGdsPrimeListCndtn1.Ed_BLGroupCode != shipGdsPrimeListCndtn2.Ed_BLGroupCode)resList.Add("Ed_BLGroupCode");
			if(shipGdsPrimeListCndtn1.St_BLGoodsCode != shipGdsPrimeListCndtn2.St_BLGoodsCode)resList.Add("St_BLGoodsCode");
			if(shipGdsPrimeListCndtn1.Ed_BLGoodsCode != shipGdsPrimeListCndtn2.Ed_BLGoodsCode)resList.Add("Ed_BLGoodsCode");
			if(shipGdsPrimeListCndtn1.ShipCount != shipGdsPrimeListCndtn2.ShipCount)resList.Add("ShipCount");
			if(shipGdsPrimeListCndtn1.EnterpriseName != shipGdsPrimeListCndtn2.EnterpriseName)resList.Add("EnterpriseName");
            if (shipGdsPrimeListCndtn1.IsOptSection != shipGdsPrimeListCndtn2.IsOptSection) resList.Add("IsOptSection");
            if (shipGdsPrimeListCndtn1.IsSelectAllSection != shipGdsPrimeListCndtn2.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (shipGdsPrimeListCndtn1.ComvDiv != shipGdsPrimeListCndtn2.ComvDiv) resList.Add("ComvDiv");
            if (shipGdsPrimeListCndtn1.RankSection != shipGdsPrimeListCndtn2.RankSection) resList.Add("RankSection");
            if (shipGdsPrimeListCndtn1.RankHighLow != shipGdsPrimeListCndtn2.RankHighLow) resList.Add("RankHighLow");
            if (shipGdsPrimeListCndtn1.RankOrderMax != shipGdsPrimeListCndtn2.RankOrderMax) resList.Add("RankOrderMax");
            if (shipGdsPrimeListCndtn1.NewPageDiv != shipGdsPrimeListCndtn2.NewPageDiv) resList.Add("NewPageDiv");
            //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
            if (shipGdsPrimeListCndtn1.GoodsNoTtlDiv != shipGdsPrimeListCndtn2.GoodsNoTtlDiv) resList.Add("GoodsNoTtlDiv");
            if (shipGdsPrimeListCndtn1.GoodsNoShowDiv != shipGdsPrimeListCndtn2.GoodsNoShowDiv) resList.Add("GoodsNoShowDiv");
            //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<
            if (shipGdsPrimeListCndtn1.PrintType != shipGdsPrimeListCndtn2.PrintType) resList.Add("PrintType");
            if (shipGdsPrimeListCndtn1.St_AnnualAddUpYearMonth != shipGdsPrimeListCndtn2.St_AnnualAddUpYearMonth) resList.Add("St_AnnualAddUpYearMonth");
            if (shipGdsPrimeListCndtn1.Ed_AnnualAddUpYearMonth != shipGdsPrimeListCndtn2.Ed_AnnualAddUpYearMonth) resList.Add("Ed_AnnualAddUpYearMonth"); 

			return resList;
        }

        #region ■項目名称プロパティ
        /// <summary>
        /// 結合区分タイトル　プロパティ
        /// </summary>
        public string ComvDivStateTitle
        {
            get
            {
                switch (this._comvDiv)
                {
                    case ComvDivState.All: return ct_ComvDivState_All;
                    case ComvDivState.Combine: return ct_ComvDivState_Combine;
                    case ComvDivState.NotCombine: return ct_ComvDivState_NotCombine;
                    
                    default: return "";
                }
            }
        }

        /// <summary>
        /// 印刷タイプタイトル　プロパティ
        /// </summary>
        public string PrintTypeStateTitle
        {
            get
            {
                switch (this._printType)
                {
                    case PrintTypeState.Month: return ct_PrintTypeState_Month;
                    case PrintTypeState.Term: return ct_PrintTypeState_Term;

                    default: return "";
                }
            }
        }

        /// <summary>
        /// 改ページ区分タイトル　プロパティ
        /// </summary>
        public string NewPageDivStateTitle
        {
            get
            {
                switch (this._newPageDiv)
                {
                    case NewPageDivState.Section: return ct_NewPageDivState_Section;
                    case NewPageDivState.Order: return ct_NewPageDivState_Order;
                    case NewPageDivState.None: return ct_NewPageDivState_None;
                    default: return "";
                }
            }
        }

        /// <summary>
        /// 順位付設定単位　プロパティ
        /// </summary>
        public string RankSectionStateTitle
        {
            get
            {
                switch (this._rankSection)
                {
                    case RankSectionState.Maker: return ct_RankSectionState_Maker;
                    case RankSectionState.BLGroupCode: return ct_RankSectionState_BLGroupCode;
                    case RankSectionState.GoodsMGroup: return ct_RankSectionState_GoodsMGroup;
                    default: return "";
                }
            }
        }

        /// <summary>
        /// 順位付設定 上位・下位　プロパティ
        /// </summary>
        public string RankHighLowStateTitle
        {
            get
            {
                switch (this._rankHighLow)
                {
                    case RankHighLowState.High: return ct_RankHighLowState_High;
                    case RankHighLowState.Low: return ct_RankHighLowState_Low;
                    default: return "";
                }
            }
        }

        //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
        /// <summary>
        /// 品番集計区分　プロパティ
        /// </summary>
        public string GoodsNoTtlDivStateTitle
        {
            get
            {
                switch (this._goodsNoTtlDiv)
                {
                    case GoodsNoTtlDivState.Together:
                        return ct_GoodsNoTtlDivState_Together;
                    case GoodsNoTtlDivState.Either:
                        return ct_GoodsNoTtlDivState_Either;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// 品番表示区分　プロパティ
        /// </summary>
        public string GoodsNoShowDivStateTitle
        {
            get
            {
                switch (this._goodsNoShowDiv)
                {
                    case GoodsNoShowDivState.NewGoodsNo:
                        return ct_GoodsNoShowDivState_NewGoodsNo;
                    case GoodsNoShowDivState.OldGoodsNo:
                        return ct_GoodsNoShowDivState_OldGoodsNo;
                    default:
                        return string.Empty;
                }
            }
        }
        //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<
        #endregion

        #region ■列挙体

        /// <summary>
        /// 結合区分　列挙体
        /// </summary>
        public enum ComvDivState
        {
            /// <summary>全て</summary>
            All = 0,
            /// <summary>結合</summary>
            Combine = 1,
            /// <summary>非結合</summary>
            NotCombine = 2,
        }

        /// <summary>
        /// 印刷タイプ 列挙体
        /// </summary>
        public enum PrintTypeState
        {
            /// <summary>当月</summary>
            Month = 0,
            /// <summary>当期</summary>
            Term = 1,

        }

        /// <summary>
        /// 改ページ区分　列挙体
        /// </summary>
        public enum NewPageDivState
        {
            /// <summary>拠点毎</summary>
            Section = 0,
            /// <summary>順位毎</summary>
            Order = 1,
            /// <summary>しない</summary>
            None = 2,
        }

        /// <summary>
        /// 順位付設定単位　列挙体
        /// </summary>
        public enum RankSectionState
        {
            /// <summary>純正メーカー毎</summary>
            Maker = 0,
            /// <summary>グループコード毎</summary>
            BLGroupCode = 1,
            /// <summary>商品中分類毎</summary>
            GoodsMGroup = 2,
        }

        /// <summary>
        /// 順位付設定上位下位　列挙体
        /// </summary>
        public enum RankHighLowState
        {
            /// <summary>上位</summary>
            High = 0,
            /// <summary>下位</summary>
            Low = 1,

        }

        //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
        /// <summary>
        /// 品番集計区分　列挙型
        /// </summary>
        public enum GoodsNoTtlDivState
        {
            /// <summary>別々</summary>
            Either = 0,
            /// <summary>合算</summary>
            Together = 1,
        }

        /// <summary>
        /// 品番表示区分　列挙型
        /// </summary>
        public enum GoodsNoShowDivState
        {
            /// <summary>新品番</summary>
            NewGoodsNo = 0,
            /// <summary>旧品番</summary>
            OldGoodsNo = 1,
        }
        //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<
        #endregion

        #region ■項目名称

        /// <summary>結合区分 全て</summary>
        private const string ct_ComvDivState_All = "全て";
        /// <summary>結合区分 結合</summary>
        private const string ct_ComvDivState_Combine = "結合";
        /// <summary>結合区分 非結合</summary>
        private const string ct_ComvDivState_NotCombine = "非結合";

        /// <summary>印刷タイプ　当月</summary>
        private const string ct_PrintTypeState_Month = "当月";
        /// <summary>印刷タイプ　当期</summary>
        private const string ct_PrintTypeState_Term = "当期";


        /// <summary>改ページ区分 拠点毎</summary>
        private const string ct_NewPageDivState_Section = "拠点単位";
        /// <summary>改ページ区分 順位毎</summary>
        private const string ct_NewPageDivState_Order = "順位単位";
        /// <summary>改ページ区分 しない</summary>
        private const string ct_NewPageDivState_None = "しない";

        /// <summary>順位付設定単位 純正メーカー毎</summary>
        private const string ct_RankSectionState_Maker = "純正メーカー毎で";
        /// <summary>順位付設定単位 グループコード毎</summary>
        private const string ct_RankSectionState_BLGroupCode = "グループコード毎で";
        /// <summary>順位付設定単位 商品中分類毎</summary>
        private const string ct_RankSectionState_GoodsMGroup = "商品中分類毎で";

        /// <summary>順位付設定上位下位 上位</summary>
        private const string ct_RankHighLowState_High = "上位";
        /// <summary>順位付設定上位下位 下位</summary>
        private const string ct_RankHighLowState_Low = "下位";

        //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
        /// <summary>品番集計区分　別々</summary>
        //public const string ct_GoodsNoTtlDivState_Either = "別々";// DEL 2015/03/27 Redmine#44209の#423品番集計区分の名称変更
        public const string ct_GoodsNoTtlDivState_Either = "通常";// ADD 2015/03/27 Redmine#44209の#423品番集計区分の名称変更
        /// <summary>品番集計区分　合算</summary>
        public const string ct_GoodsNoTtlDivState_Together = "合算";

        /// <summary>品番表示区分　新品番</summary>
        public const string ct_GoodsNoShowDivState_NewGoodsNo = "新品番";
        /// <summary>品番表示区分　旧品番</summary>
        public const string ct_GoodsNoShowDivState_OldGoodsNo = "旧品番";
        //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<
        #endregion
    }
}
