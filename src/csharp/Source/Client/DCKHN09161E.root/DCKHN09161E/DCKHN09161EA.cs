using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   Rate
    /// <summary>
    ///                      掛率マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   掛率マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成 / 上野　弘貴</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/10/17  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class Rate
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>更新従業員コード</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _updEmployeeCode = "";

        /// <summary>更新アセンブリID1</summary>
        /// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>更新アセンブリID2</summary>
        /// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

		/// <summary>単価掛率設定区分</summary>
		/// <remarks>単価種類＋掛率設定区分＋新旧区分（1A10,2A21等）</remarks>
		private string _unitRateSetDivCd = "";

        /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
		/// <summary>新旧区分</summary>
		/// <remarks>0:新 1:旧</remarks>
		private string _oldNewDivCd = "";
           --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
        
        /// <summary>単価種類</summary>
		/// <remarks>1:売上単価　2:売上原価　3:仕入単価 4:定価</remarks>
		private string _unitPriceKind = "1";

		/// <summary>掛率設定区分</summary>
		/// <remarks>A1,A2等</remarks>
		private string _rateSettingDivide = "";

		/// <summary>掛率設定区分（商品）</summary>
		/// <remarks>A～O　</remarks>
		private string _rateMngGoodsCd = "";

		/// <summary>掛率設定名称（商品）</summary>
		/// <remarks>A： "メーカー＋商品"</remarks>
		private string _rateMngGoodsNm = "";

		/// <summary>掛率設定区分（得意先）</summary>
		/// <remarks>1～9　</remarks>
		private string _rateMngCustCd = "";

		/// <summary>掛率設定名称（得意先）</summary>
		/// <remarks>1： "得意先＋仕入先"</remarks>
		private string _rateMngCustNm = "";

		/// <summary>商品メーカーコード</summary>
		private Int32 _goodsMakerCd;

		/// <summary>商品番号</summary>
		private string _goodsNo = "";

		/// <summary>商品掛率ランク</summary>
		private string _goodsRateRank = "";

        /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
		/// <summary>商品区分グループコード</summary>
		/// <remarks>旧：商品大分類コード</remarks>
		private string _largeGoodsGanreCode = "";

		/// <summary>商品区分コード</summary>
		/// <remarks>旧：商品中分類コード</remarks>
		private string _mediumGoodsGanreCode = "";

		/// <summary>商品区分詳細コード</summary>
		private string _detailGoodsGanreCode = "";

		/// <summary>自社分類コード</summary>
		private Int32 _enterpriseGanreCode;
           --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
        
        /// <summary>BL商品コード</summary>
		private Int32 _bLGoodsCode;

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>得意先掛率グループコード</summary>
		private Int32 _custRateGrpCode;

		/// <summary>仕入先コード</summary>
		private Int32 _supplierCd;

        /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
		/// <summary>仕入先掛率グループコード</summary>
		private Int32 _suppRateGrpCode;
           --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
        
        /// <summary>ロット数</summary>
		/// <remarks>表示順位はロット数の昇順とする</remarks>
		private Double _lotCount;

        /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
		/// <summary>単価算出区分</summary>
		/// <remarks>1:基準価格×掛率　2:原価×原価UP率　3:原価÷(1-粗利率) 4:入力定価×掛率</remarks>
		private Int32 _unitPrcCalcDiv;

		/// <summary>価格区分</summary>
		/// <remarks>0:定価  10:卸等(提供）</remarks>
		private Int32 _priceDiv;
           --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
        
        /// <summary>価格（浮動）</summary>
		/// <remarks>ずばり値</remarks>
		private Double _priceFl;

		/// <summary>掛率</summary>
		/// <remarks>掛率</remarks>
		private Double _rateVal;

		/// <summary>単価端数処理単位</summary>
		private Double _unPrcFracProcUnit;

		/// <summary>単価端数処理区分</summary>
		private Int32 _unPrcFracProcDiv;

        /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
		/// <summary>掛率開始日</summary>
		private DateTime _rateStartDate;

		/// <summary>特売区分コード</summary>
		private Int32 _bargainCd;
           --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/

        // --- ADD 2008/06/18 --------------------------------------------------------------------->>>>>
        /// <summary>商品掛率グループコード</summary>
        private Int32 _goodsRateGrpCode;

        /// <summary>BLグループコード</summary>
        private Int32 _bLGroupCode;

        /// <summary>UP率</summary>
        private Double _upRate;

        /// <summary>粗利確保率</summary>
        private Double _grsProfitSecureRate;
        // --- ADD 2008/06/18 ---------------------------------------------------------------------<<<<<

        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>作成日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>作成日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>作成日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>作成日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>更新日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>更新日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>更新日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>更新日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
        }

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
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUIDプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>更新従業員コードプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>更新アセンブリID1プロパティ</summary>
        /// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>更新アセンブリID2プロパティ</summary>
        /// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

		/// public propaty name  :  UnitRateSetDivCd
		/// <summary>単価掛率設定区分プロパティ</summary>
		/// <value>単価種類＋掛率設定区分＋新旧区分（1A10,2A21等）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   単価掛率設定区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UnitRateSetDivCd
		{
			get{return _unitRateSetDivCd;}
			set{_unitRateSetDivCd = value;}
		}

        /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
		/// public propaty name  :  OldNewDivCd
		/// <summary>新旧区分プロパティ</summary>
		/// <value>0:新 1:旧</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   新旧区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OldNewDivCd
		{
			get{return _oldNewDivCd;}
			set{_oldNewDivCd = value;}
		}
           --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
        
        /// public propaty name  :  UnitPriceKind
		/// <summary>単価種類プロパティ</summary>
		/// <value>1:売上単価　2:売上原価　3:仕入単価 4:定価</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   単価種類プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UnitPriceKind
		{
			get{return _unitPriceKind;}
			set{_unitPriceKind = value;}
		}

		/// public propaty name  :  RateSettingDivide
		/// <summary>掛率設定区分プロパティ</summary>
		/// <value>A1,A2等</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   掛率設定区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RateSettingDivide
		{
			get{return _rateSettingDivide;}
			set{_rateSettingDivide = value;}
		}

		/// public propaty name  :  RateMngGoodsCd
		/// <summary>掛率設定区分（商品）プロパティ</summary>
		/// <value>A～O　</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   掛率設定区分（商品）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RateMngGoodsCd
		{
			get{return _rateMngGoodsCd;}
			set{_rateMngGoodsCd = value;}
		}

		/// public propaty name  :  RateMngGoodsNm
		/// <summary>掛率設定名称（商品）プロパティ</summary>
		/// <value>A： "メーカー＋商品"</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   掛率設定名称（商品）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RateMngGoodsNm
		{
			get{return _rateMngGoodsNm;}
			set{_rateMngGoodsNm = value;}
		}

		/// public propaty name  :  RateMngCustCd
		/// <summary>掛率設定区分（得意先）プロパティ</summary>
		/// <value>1～9　</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   掛率設定区分（得意先）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RateMngCustCd
		{
			get{return _rateMngCustCd;}
			set{_rateMngCustCd = value;}
		}

		/// public propaty name  :  RateMngCustNm
		/// <summary>掛率設定名称（得意先）プロパティ</summary>
		/// <value>1： "得意先＋仕入先"</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   掛率設定名称（得意先）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RateMngCustNm
		{
			get{return _rateMngCustNm;}
			set{_rateMngCustNm = value;}
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
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
		}

		/// public propaty name  :  GoodsNo
		/// <summary>商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNo
		{
			get{return _goodsNo;}
			set{_goodsNo = value;}
		}

		/// public propaty name  :  GoodsRateRank
		/// <summary>商品掛率ランクプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品掛率ランクプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsRateRank
		{
			get{return _goodsRateRank;}
			set{_goodsRateRank = value;}
		}

        /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
		/// public propaty name  :  LargeGoodsGanreCode
		/// <summary>商品区分グループコードプロパティ</summary>
		/// <value>旧：商品大分類コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品区分グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LargeGoodsGanreCode
		{
			get{return _largeGoodsGanreCode;}
			set{_largeGoodsGanreCode = value;}
		}

		/// public propaty name  :  MediumGoodsGanreCode
		/// <summary>商品区分コードプロパティ</summary>
		/// <value>旧：商品中分類コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品区分コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MediumGoodsGanreCode
		{
			get{return _mediumGoodsGanreCode;}
			set{_mediumGoodsGanreCode = value;}
		}

		/// public propaty name  :  DetailGoodsGanreCode
		/// <summary>商品区分詳細コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品区分詳細コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DetailGoodsGanreCode
		{
			get{return _detailGoodsGanreCode;}
			set{_detailGoodsGanreCode = value;}
		}

		/// public propaty name  :  EnterpriseGanreCode
		/// <summary>自社分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EnterpriseGanreCode
		{
			get{return _enterpriseGanreCode;}
			set{_enterpriseGanreCode = value;}
		}
           --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
        
        /// public propaty name  :  BLGoodsCode
		/// <summary>BL商品コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGoodsCode
		{
			get{return _bLGoodsCode;}
			set{_bLGoodsCode = value;}
		}

		/// public propaty name  :  CustomerCode
		/// <summary>得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get{return _customerCode;}
			set{_customerCode = value;}
		}

		/// public propaty name  :  CustRateGrpCode
		/// <summary>得意先掛率グループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先掛率グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustRateGrpCode
		{
			get{return _custRateGrpCode;}
			set{_custRateGrpCode = value;}
		}

		/// public propaty name  :  SupplierCd
		/// <summary>仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierCd
		{
			get{return _supplierCd;}
			set{_supplierCd = value;}
		}

        /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
		/// public propaty name  :  SuppRateGrpCode
		/// <summary>仕入先掛率グループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先掛率グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SuppRateGrpCode
		{
			get{return _suppRateGrpCode;}
			set{_suppRateGrpCode = value;}
		}
           --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
        
        /// public propaty name  :  LotCount
		/// <summary>ロット数プロパティ</summary>
		/// <value>表示順位はロット数の昇順とする</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ロット数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double LotCount
		{
			get{return _lotCount;}
			set{_lotCount = value;}
		}

        /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
		/// public propaty name  :  UnitPrcCalcDiv
		/// <summary>単価算出区分プロパティ</summary>
		/// <value>1:基準価格×掛率　2:原価×原価UP率　3:原価÷(1-粗利率) 4:入力定価×掛率</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   単価算出区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UnitPrcCalcDiv
		{
			get{return _unitPrcCalcDiv;}
			set{_unitPrcCalcDiv = value;}
		}

		/// public propaty name  :  PriceDiv
		/// <summary>価格区分プロパティ</summary>
		/// <value>0:定価  10:卸等(提供）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   価格区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PriceDiv
		{
			get{return _priceDiv;}
			set{_priceDiv = value;}
		}
           --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
        
        /// public propaty name  :  PriceFl
		/// <summary>価格（浮動）プロパティ</summary>
		/// <value>ずばり値</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   価格（浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double PriceFl
		{
			get{return _priceFl;}
			set{_priceFl = value;}
		}

		/// public propaty name  :  RateVal
		/// <summary>掛率プロパティ</summary>
		/// <value>掛率</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   掛率プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double RateVal
		{
			get{return _rateVal;}
			set{_rateVal = value;}
		}

		/// public propaty name  :  UnPrcFracProcUnit
		/// <summary>単価端数処理単位プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   単価端数処理単位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double UnPrcFracProcUnit
		{
			get{return _unPrcFracProcUnit;}
			set{_unPrcFracProcUnit = value;}
		}

		/// public propaty name  :  UnPrcFracProcDiv
		/// <summary>単価端数処理区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   単価端数処理区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UnPrcFracProcDiv
		{
			get{return _unPrcFracProcDiv;}
			set{_unPrcFracProcDiv = value;}
		}

        /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
		/// public propaty name  :  RateStartDate
		/// <summary>掛率開始日プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   掛率開始日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime RateStartDate
		{
			get{return _rateStartDate;}
			set{_rateStartDate = value;}
		}

		/// public propaty name  :  BargainCd
		/// <summary>特売区分コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   特売区分コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BargainCd
		{
			get{return _bargainCd;}
			set{_bargainCd = value;}
		}
           --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/

        // --- ADD 2008/06/18 --------------------------------------------------------------------->>>>>
        /// public property name  :  GoodsRateGrpCode
        /// <summary>商品掛率グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsRateGrpCode
        {
            get { return _goodsRateGrpCode; }
            set { _goodsRateGrpCode = value; }
        }

        /// public property name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public property name  :  UpRate
        /// <summary>UP率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UP率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double UpRate
        {
            get { return _upRate; }
            set { _upRate = value; }
        }

        /// public property name  :  GrsProfitSecureRate
        /// <summary>粗利確保率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利確保率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double GrsProfitSecureRate
        {
            get { return _grsProfitSecureRate; }
            set { _grsProfitSecureRate = value; }
        }
        // --- ADD 2008/06/18 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// 掛率マスタコンストラクタ
        /// </summary>
        /// <returns>Rateクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Rateクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Rate ()
        {
        }

        /// <summary>
        /// 掛率マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="sectionCode">拠点コード</param>
		/// <param name="unitRateSetDivCd">単価掛率設定区分(単価種類＋掛率設定区分＋新旧区分（1A10,2A21等）)</param>
		/// <param name="unitPriceKind">単価種類(1:売上単価　2:売上原価　3:仕入単価 4:定価)</param>
		/// <param name="rateSettingDivide">掛率設定区分(A1,A2等)</param>
		/// <param name="rateMngGoodsCd">掛率設定区分（商品）(A～O)</param>
		/// <param name="rateMngGoodsNm">掛率設定名称（商品）(A： "メーカー＋商品")</param>
		/// <param name="rateMngCustCd">掛率設定区分（得意先）(1～9)</param>
		/// <param name="rateMngCustNm">掛率設定名称（得意先）(1： "得意先＋仕入先")</param>
		/// <param name="goodsMakerCd">商品メーカーコード</param>
		/// <param name="goodsNo">商品番号</param>
		/// <param name="goodsRateRank">商品掛率ランク</param>
		/// <param name="bLGoodsCode">BL商品コード</param>
		/// <param name="customerCode">>得意先コード</param>
		/// <param name="custRateGrpCode">得意先掛率グループコード</param>
		/// <param name="supplierCd">仕入先コード</param>
		/// <param name="lotCount">ロット数(表示順位はロット数の昇順とする)</param>
		/// <param name="priceFl">価格（浮動）(ずばり値)</param>
		/// <param name="rateVal">掛率</param>
		/// <param name="unPrcFracProcUnit">単価端数処理単位</param>
		/// <param name="unPrcFracProcDiv">単価端数処理区分</param>
        /// <param name="goodsRateGrpCode">商品掛率グループコード</param>
        /// <param name="bLGroupCode">BLグループコード</param>
        /// <param name="upRate">UP率</param>
        /// <param name="grsProfitSecureRate">粗利確保率</param>
        /// <returns>Rateクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Rateクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Rate (
							DateTime createDateTime,
							DateTime updateDateTime,
							string enterpriseCode,
							Guid fileHeaderGuid,
							string updEmployeeCode,
							string updAssemblyId1,
							string updAssemblyId2,
							Int32 logicalDeleteCode,
							string sectionCode,
							string unitRateSetDivCd,
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
							string oldNewDivCd,
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
                            string unitPriceKind,
							string rateSettingDivide,
							string rateMngGoodsCd,
							string rateMngGoodsNm,
							string rateMngCustCd,
							string rateMngCustNm,
							Int32 goodsMakerCd,
							string goodsNo,
							string goodsRateRank,
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
							string largeGoodsGanreCode,
							string mediumGoodsGanreCode,
							string detailGoodsGanreCode,
							Int32 enterpriseGanreCode,
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
                            Int32 bLGoodsCode,
							Int32 customerCode,
							Int32 custRateGrpCode,
							Int32 supplierCd,
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
							Int32 suppRateGrpCode,
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
                            Double lotCount,
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
							Int32 unitPrcCalcDiv,
							Int32 priceDiv,
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
                            Double priceFl,
							Double rateVal,
							Double unPrcFracProcUnit,
            // --- ADD 2008/06/18 --------------------------------------------------------------------->>>>>
                            Int32 goodsRateGrpCode,
                            Int32 bLGroupCode,
                            Double upRate,
                            Double grsProfitSecureRate,
            // --- ADD 2008/06/18 ---------------------------------------------------------------------<<<<<
							Int32 unPrcFracProcDiv)
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
							DateTime rateStartDate,
							Int32 bargainCd)
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
        {
            this.CreateDateTime 		= createDateTime;
            this.UpdateDateTime 		= updateDateTime;
            this._enterpriseCode 		= enterpriseCode;
            this._fileHeaderGuid 		= fileHeaderGuid;
            this._updEmployeeCode 		= updEmployeeCode;
            this._updAssemblyId1 		= updAssemblyId1;
            this._updAssemblyId2 		= updAssemblyId2;
            this._logicalDeleteCode 	= logicalDeleteCode;
            this._sectionCode 			= sectionCode;
			this._unitRateSetDivCd 		= unitRateSetDivCd;
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			this._oldNewDivCd 			= oldNewDivCd;
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            this._unitPriceKind 		= unitPriceKind;
			this._rateSettingDivide 	= rateSettingDivide;
			this._rateMngGoodsCd 		= rateMngGoodsCd;
			this._rateMngGoodsNm		= rateMngGoodsNm;
			this._rateMngCustCd			= rateMngCustCd;
			this._rateMngCustNm			= rateMngCustNm;
			this._goodsMakerCd			= goodsMakerCd;
			this._goodsNo				= goodsNo;
			this._goodsRateRank			= goodsRateRank;
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			this._largeGoodsGanreCode	= largeGoodsGanreCode;
			this._mediumGoodsGanreCode	= mediumGoodsGanreCode;
			this._detailGoodsGanreCode	= detailGoodsGanreCode;
			this._enterpriseGanreCode	= enterpriseGanreCode;
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            this._bLGoodsCode			= bLGoodsCode;
			this._customerCode			= customerCode;
			this._custRateGrpCode		= custRateGrpCode;
			this._supplierCd			= supplierCd;
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			this._suppRateGrpCode		= suppRateGrpCode;
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            this._lotCount				= lotCount;
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			this._unitPrcCalcDiv		= unitPrcCalcDiv;
			this._priceDiv				= priceDiv;
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            this._priceFl				= priceFl;
			this._rateVal				= rateVal;
			this._unPrcFracProcUnit		= unPrcFracProcUnit;
			this._unPrcFracProcDiv		= unPrcFracProcDiv;
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			this._rateStartDate			= rateStartDate;
			this._bargainCd				= bargainCd;
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            // --- ADD 2008/06/18 --------------------------------------------------------------------->>>>>
            this._goodsRateGrpCode      = goodsRateGrpCode;
            this._bLGroupCode           = bLGroupCode;
            this._upRate                = upRate;
            this._grsProfitSecureRate   = grsProfitSecureRate;
            // --- ADD 2008/06/18 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// 掛率マスタ複製処理
        /// </summary>
        /// <returns>Rateクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいRateクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Rate Clone ()
        {
            return new Rate(
                                    this._createDateTime,
                                    this._updateDateTime,
                                    this._enterpriseCode,
                                    this._fileHeaderGuid,
                                    this._updEmployeeCode,
                                    this._updAssemblyId1,
                                    this._updAssemblyId2,
                                    this._logicalDeleteCode,
                                    this._sectionCode,
                                    this._unitRateSetDivCd,
                /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
                this._oldNewDivCd,
                   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
                                    this._unitPriceKind,
                                    this._rateSettingDivide,
                                    this._rateMngGoodsCd,
                                    this._rateMngGoodsNm,
                                    this._rateMngCustCd,
                                    this._rateMngCustNm,
                                    this._goodsMakerCd,
                                    this._goodsNo,
                                    this._goodsRateRank,
                /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
                this._largeGoodsGanreCode,
                this._mediumGoodsGanreCode,
                this._detailGoodsGanreCode,
                this._enterpriseGanreCode,
                   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
                                    this._bLGoodsCode,
                                    this._customerCode,
                                    this._custRateGrpCode,
                                    this._supplierCd,
                /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
                this._suppRateGrpCode,
                   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
                                    this._lotCount,
                /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
                this._unitPrcCalcDiv,
                this._priceDiv,
                   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
                                    this._priceFl,
                                    this._rateVal,
                                    this._unPrcFracProcUnit,
                // --- ADD 2008/06/18 --------------------------------------------------------------------->>>>>
                                    this._goodsRateGrpCode,
                                    this._bLGroupCode,
                                    this._upRate,
                                    this._grsProfitSecureRate,
                // --- ADD 2008/06/18 ---------------------------------------------------------------------<<<<<
                                    this._unPrcFracProcDiv);
                /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
				this._rateStartDate,
				this._bargainCd);
                   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
        }

        /// <summary>
        /// 掛率マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のRateクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Rateクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals ( Rate target )
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                && (this.UpdateDateTime == target.UpdateDateTime)
                && (this.EnterpriseCode == target.EnterpriseCode)
                && (this.FileHeaderGuid == target.FileHeaderGuid)
                && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                && (this.SectionCode == target.SectionCode)
                && (this.UnitRateSetDivCd == target.UnitRateSetDivCd)
                /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
				&& ( this.OldNewDivCd 			== target.OldNewDivCd )
                   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
                && (this.UnitPriceKind == target.UnitPriceKind)
                && (this.RateSettingDivide == target.RateSettingDivide)
                && (this.RateMngGoodsCd == target.RateMngGoodsCd)
                && (this.RateMngGoodsNm == target.RateMngGoodsNm)
                && (this.RateMngCustCd == target.RateMngCustCd)
                && (this.RateMngCustNm == target.RateMngCustNm)
                && (this.GoodsMakerCd == target.GoodsMakerCd)
                && (this.GoodsNo == target.GoodsNo)
                && (this.GoodsRateRank == target.GoodsRateRank)
                /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
				&& ( this.LargeGoodsGanreCode	== target.LargeGoodsGanreCode )
				&& ( this.MediumGoodsGanreCode	== target.MediumGoodsGanreCode )
				&& ( this.DetailGoodsGanreCode	== target.DetailGoodsGanreCode )
				&& ( this.EnterpriseGanreCode	== target.EnterpriseGanreCode )
                   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
                && (this.BLGoodsCode == target.BLGoodsCode)
                && (this.CustomerCode == target.CustomerCode)
                && (this.CustRateGrpCode == target.CustRateGrpCode)
                && (this.SupplierCd == target.SupplierCd)
                /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
				&& ( this.SuppRateGrpCode		== target.SuppRateGrpCode )
                   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
                && (this.LotCount == target.LotCount)
                /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
				&& ( this.UnitPrcCalcDiv		== target.UnitPrcCalcDiv )
				&& ( this.PriceDiv				== target.PriceDiv )
                   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
                && (this.PriceFl == target.PriceFl)
                && (this.RateVal == target.RateVal)
                && (this.UnPrcFracProcUnit == target.UnPrcFracProcUnit)
                // --- ADD 2008/06/18 --------------------------------------------------------------------->>>>>
                && (this.GoodsRateGrpCode == target.GoodsRateGrpCode)
                && (this.BLGroupCode == target.BLGroupCode)
                && (this.UpRate == target.UpRate)
                && (this.GrsProfitSecureRate == target.GrsProfitSecureRate)
                // --- ADD 2008/06/18 ---------------------------------------------------------------------<<<<<
                && (this.UnPrcFracProcDiv == target.UnPrcFracProcDiv));
                /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
				&& ( this.RateStartDate			== target.RateStartDate )
				&& ( this.BargainCd				== target.BargainCd ));
                   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
        }

        /// <summary>
        /// 掛率マスタ比較処理
        /// </summary>
        /// <param name="rate1">
        ///                    比較するRateクラスのインスタンス
        /// </param>
        /// <param name="rate2">比較するRateクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Rateクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals ( Rate rate1, Rate rate2 )
        {
            return ((rate1.CreateDateTime == rate2.CreateDateTime)
                && (rate1.UpdateDateTime == rate2.UpdateDateTime)
                && (rate1.EnterpriseCode == rate2.EnterpriseCode)
                && (rate1.FileHeaderGuid == rate2.FileHeaderGuid)
                && (rate1.UpdEmployeeCode == rate2.UpdEmployeeCode)
                && (rate1.UpdAssemblyId1 == rate2.UpdAssemblyId1)
                && (rate1.UpdAssemblyId2 == rate2.UpdAssemblyId2)
                && (rate1.LogicalDeleteCode == rate2.LogicalDeleteCode)
                && (rate1.SectionCode == rate2.SectionCode)
                && (rate1.UnitRateSetDivCd == rate2.UnitRateSetDivCd)
                /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
				&& ( rate1.OldNewDivCd 			== rate2.OldNewDivCd )
                   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
                && (rate1.UnitPriceKind == rate2.UnitPriceKind)
                && (rate1.RateSettingDivide == rate2.RateSettingDivide)
                && (rate1.RateMngGoodsCd == rate2.RateMngGoodsCd)
                && (rate1.RateMngGoodsNm == rate2.RateMngGoodsNm)
                && (rate1.RateMngCustCd == rate2.RateMngCustCd)
                && (rate1.RateMngCustNm == rate2.RateMngCustNm)
                && (rate1.GoodsMakerCd == rate2.GoodsMakerCd)
                && (rate1.GoodsNo == rate2.GoodsNo)
                && (rate1.GoodsRateRank == rate2.GoodsRateRank)
                /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
				&& ( rate1.LargeGoodsGanreCode	== rate2.LargeGoodsGanreCode )
				&& ( rate1.MediumGoodsGanreCode	== rate2.MediumGoodsGanreCode )
				&& ( rate1.DetailGoodsGanreCode	== rate2.DetailGoodsGanreCode )
				&& ( rate1.EnterpriseGanreCode	== rate2.EnterpriseGanreCode )
                   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
                && (rate1.BLGoodsCode == rate2.BLGoodsCode)
                && (rate1.CustomerCode == rate2.CustomerCode)
                && (rate1.CustRateGrpCode == rate2.CustRateGrpCode)
                && (rate1.SupplierCd == rate2.SupplierCd)
                /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
				&& ( rate1.SuppRateGrpCode		== rate2.SuppRateGrpCode )
                   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
                && (rate1.LotCount == rate2.LotCount)
                /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
				&& ( rate1.UnitPrcCalcDiv		== rate2.UnitPrcCalcDiv )
				&& ( rate1.PriceDiv				== rate2.PriceDiv )
                   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
                && (rate1.PriceFl == rate2.PriceFl)
                && (rate1.RateVal == rate2.RateVal)
                && (rate1.UnPrcFracProcUnit == rate2.UnPrcFracProcUnit)
                // --- ADD 2008/06/18 --------------------------------------------------------------------->>>>>
                && (rate1.GoodsRateGrpCode == rate2.GoodsRateGrpCode)
                && (rate1.BLGroupCode == rate2.BLGroupCode)
                && (rate1.UpRate == rate2.UpRate)
                && (rate1.GrsProfitSecureRate == rate2.GrsProfitSecureRate)
                // --- ADD 2008/06/18 ---------------------------------------------------------------------<<<<<
                && (rate1.UnPrcFracProcDiv == rate2.UnPrcFracProcDiv));
                /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
				&& ( rate1.RateStartDate		== rate2.RateStartDate )
				&& ( rate1.BargainCd			== rate2.BargainCd ));
                   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
        }
        /// <summary>
        /// 掛率マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のRateクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Rateクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare ( Rate target )
        {
            ArrayList resList = new ArrayList();
            if ( this.CreateDateTime		!= target.CreateDateTime )			resList.Add("CreateDateTime");
            if ( this.UpdateDateTime		!= target.UpdateDateTime )			resList.Add("UpdateDateTime");
            if ( this.EnterpriseCode		!= target.EnterpriseCode )			resList.Add("EnterpriseCode");
            if ( this.FileHeaderGuid		!= target.FileHeaderGuid )			resList.Add("FileHeaderGuid");
            if ( this.UpdEmployeeCode		!= target.UpdEmployeeCode )			resList.Add("UpdEmployeeCode");
            if ( this.UpdAssemblyId1		!= target.UpdAssemblyId1 )			resList.Add("UpdAssemblyId1");
            if ( this.UpdAssemblyId2		!= target.UpdAssemblyId2 )			resList.Add("UpdAssemblyId2");
            if ( this.LogicalDeleteCode		!= target.LogicalDeleteCode )		resList.Add("LogicalDeleteCode");
            if ( this.SectionCode			!= target.SectionCode )				resList.Add("SectionCode");
			if ( this.UnitRateSetDivCd 		!= target.UnitRateSetDivCd ) 		resList.Add("UnitRateSetDivCd");
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			if ( this.OldNewDivCd 			!= target.OldNewDivCd )				resList.Add("OldNewDivCd");
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            if ( this.UnitPriceKind 		!= target.UnitPriceKind ) 			resList.Add("UnitPriceKind");
			if ( this.RateSettingDivide 	!= target.RateSettingDivide ) 		resList.Add("RateSettingDivide");
			if ( this.RateMngGoodsCd 		!= target.RateMngGoodsCd ) 			resList.Add("RateMngGoodsCd");
			if ( this.RateMngGoodsNm		!= target.RateMngGoodsNm )			resList.Add("RateMngGoodsNm");
			if ( this.RateMngCustCd			!= target.RateMngCustCd )			resList.Add("RateMngCustCd");
			if ( this.RateMngCustNm			!= target.RateMngCustNm )			resList.Add("RateMngCustNm");
			if ( this.GoodsMakerCd			!= target.GoodsMakerCd )			resList.Add("GoodsMakerCd");
			if ( this.GoodsNo				!= target.GoodsNo )					resList.Add("GoodsNo");
			if ( this.GoodsRateRank			!= target.GoodsRateRank )			resList.Add("GoodsRateRank");
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			if ( this.LargeGoodsGanreCode	!= target.LargeGoodsGanreCode )		resList.Add("LargeGoodsGanreCode");
			if ( this.MediumGoodsGanreCode	!= target.MediumGoodsGanreCode )	resList.Add("MediumGoodsGanreCode");
			if ( this.DetailGoodsGanreCode	!= target.DetailGoodsGanreCode )	resList.Add("DetailGoodsGanreCode");
			if ( this.EnterpriseGanreCode	!= target.EnterpriseGanreCode )		resList.Add("EnterpriseGanreCode");
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            if ( this.BLGoodsCode			!= target.BLGoodsCode )				resList.Add("BLGoodsCode");
			if ( this.CustomerCode			!= target.CustomerCode )			resList.Add("CustomerCode");
			if ( this.CustRateGrpCode		!= target.CustRateGrpCode )			resList.Add("CustRateGrpCode");
			if ( this.SupplierCd			!= target.SupplierCd )				resList.Add("SupplierCd");
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			if ( this.SuppRateGrpCode		!= target.SuppRateGrpCode )			resList.Add("SuppRateGrpCode");
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            if ( this.LotCount				!= target.LotCount )				resList.Add("LotCount");
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			if ( this.UnitPrcCalcDiv		!= target.UnitPrcCalcDiv )			resList.Add("UnitPrcCalcDiv");
			if ( this.PriceDiv				!= target.PriceDiv )				resList.Add("PriceDiv");
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            if ( this.PriceFl				!= target.PriceFl )					resList.Add("PriceFl");
			if ( this.RateVal				!= target.RateVal )					resList.Add("RateVal");
			if ( this.UnPrcFracProcUnit		!= target.UnPrcFracProcUnit )		resList.Add("UnPrcFracProcUnit");
			if ( this.UnPrcFracProcDiv		!= target.UnPrcFracProcDiv )		resList.Add("UnPrcFracProcDiv");
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			if ( this.RateStartDate			!= target.RateStartDate )			resList.Add("RateStartDate");
			if ( this.BargainCd				!= target.BargainCd )				resList.Add("BargainCd");
			   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/18 --------------------------------------------------------------------->>>>>
            if (this.GoodsRateGrpCode != target.GoodsRateGrpCode) resList.Add("GoodsRateGrpCode");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.UpRate != target.UpRate) resList.Add("UpRate");
            if (this.GrsProfitSecureRate != target.GrsProfitSecureRate) resList.Add("GrsProfitSecureRate");
            // --- ADD 2008/06/18 ---------------------------------------------------------------------<<<<<

            return resList;
        }

        /// <summary>
        /// 掛率マスタ比較処理
        /// </summary>
        /// <param name="rate1">比較するRateクラスのインスタンス</param>
        /// <param name="rate2">比較するRateクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Rateクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare ( Rate rate1, Rate rate2 )
        {
            ArrayList resList = new ArrayList();
            if ( rate1.CreateDateTime		!= rate2.CreateDateTime )		resList.Add("CreateDateTime");
            if ( rate1.UpdateDateTime		!= rate2.UpdateDateTime )		resList.Add("UpdateDateTime");
            if ( rate1.EnterpriseCode		!= rate2.EnterpriseCode )		resList.Add("EnterpriseCode");
            if ( rate1.FileHeaderGuid		!= rate2.FileHeaderGuid )		resList.Add("FileHeaderGuid");
            if ( rate1.UpdEmployeeCode		!= rate2.UpdEmployeeCode )		resList.Add("UpdEmployeeCode");
            if ( rate1.UpdAssemblyId1		!= rate2.UpdAssemblyId1 )		resList.Add("UpdAssemblyId1");
            if ( rate1.UpdAssemblyId2		!= rate2.UpdAssemblyId2 )		resList.Add("UpdAssemblyId2");
            if ( rate1.LogicalDeleteCode	!= rate2.LogicalDeleteCode )	resList.Add("LogicalDeleteCode");
            if ( rate1.SectionCode			!= rate2.SectionCode )			resList.Add("SectionCode");
			if ( rate1.UnitRateSetDivCd 	!= rate2.UnitRateSetDivCd ) 	resList.Add("UnitRateSetDivCd");
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			if ( rate1.OldNewDivCd 			!= rate2.OldNewDivCd )			resList.Add("OldNewDivCd");
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            if ( rate1.UnitPriceKind 		!= rate2.UnitPriceKind ) 		resList.Add("UnitPriceKind");
			if ( rate1.RateSettingDivide 	!= rate2.RateSettingDivide ) 	resList.Add("RateSettingDivide");
			if ( rate1.RateMngGoodsCd 		!= rate2.RateMngGoodsCd ) 		resList.Add("RateMngGoodsCd");
			if ( rate1.RateMngGoodsNm		!= rate2.RateMngGoodsNm )		resList.Add("RateMngGoodsNm");
			if ( rate1.RateMngCustCd		!= rate2.RateMngCustCd )		resList.Add("RateMngCustCd");
			if ( rate1.RateMngCustNm		!= rate2.RateMngCustNm )		resList.Add("RateMngCustNm");
			if ( rate1.GoodsMakerCd			!= rate2.GoodsMakerCd )			resList.Add("GoodsMakerCd");
			if ( rate1.GoodsNo				!= rate2.GoodsNo )				resList.Add("GoodsNo");
			if ( rate1.GoodsRateRank		!= rate2.GoodsRateRank )		resList.Add("GoodsRateRank");
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			if ( rate1.LargeGoodsGanreCode	!= rate2.LargeGoodsGanreCode )	resList.Add("LargeGoodsGanreCode");
			if ( rate1.MediumGoodsGanreCode	!= rate2.MediumGoodsGanreCode )	resList.Add("MediumGoodsGanreCode");
			if ( rate1.DetailGoodsGanreCode	!= rate2.DetailGoodsGanreCode )	resList.Add("DetailGoodsGanreCode");
			if ( rate1.EnterpriseGanreCode	!= rate2.EnterpriseGanreCode )	resList.Add("EnterpriseGanreCode");
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            if ( rate1.BLGoodsCode			!= rate2.BLGoodsCode )			resList.Add("BLGoodsCode");
			if ( rate1.CustomerCode			!= rate2.CustomerCode )			resList.Add("CustomerCode");
			if ( rate1.CustRateGrpCode		!= rate2.CustRateGrpCode )		resList.Add("CustRateGrpCode");
			if ( rate1.SupplierCd			!= rate2.SupplierCd )			resList.Add("SupplierCd");
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			if ( rate1.SuppRateGrpCode		!= rate2.SuppRateGrpCode )		resList.Add("SuppRateGrpCode");
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            if ( rate1.LotCount				!= rate2.LotCount )				resList.Add("LotCount");
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			if ( rate1.UnitPrcCalcDiv		!= rate2.UnitPrcCalcDiv )		resList.Add("UnitPrcCalcDiv");
			if ( rate1.PriceDiv				!= rate2.PriceDiv )				resList.Add("PriceDiv");
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            if ( rate1.PriceFl				!= rate2.PriceFl )				resList.Add("PriceFl");
			if ( rate1.RateVal				!= rate2.RateVal )				resList.Add("RateVal");
			if ( rate1.UnPrcFracProcUnit	!= rate2.UnPrcFracProcUnit )	resList.Add("UnPrcFracProcUnit");
			if ( rate1.UnPrcFracProcDiv		!= rate2.UnPrcFracProcDiv )		resList.Add("UnPrcFracProcDiv");
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			if ( rate1.RateStartDate		!= rate2.RateStartDate )		resList.Add("RateStartDate");
			if ( rate1.BargainCd			!= rate2.BargainCd )			resList.Add("BargainCd");
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/18 --------------------------------------------------------------------->>>>>
            if (rate1.GoodsRateGrpCode != rate2.GoodsRateGrpCode) resList.Add("GoodsRateGrpCode");
            if (rate1.BLGroupCode != rate2.BLGroupCode) resList.Add("BLGroupCode");
            if (rate1.UpRate != rate2.UpRate) resList.Add("UpRate");
            if (rate1.GrsProfitSecureRate != rate2.GrsProfitSecureRate) resList.Add("GrsProfitSecureRate");
            // --- ADD 2008/06/18 ---------------------------------------------------------------------<<<<<

            return resList;
        }

        /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
		/// <summary>新旧区分リスト</summary>
		public static SortedList _OldNewDivCdTable;

		/// <summary>単価種類リスト</summary>
		public static SortedList _unitPriceKindTable;

		/// <summary>単価種類設定方法リスト</summary>
		public static SortedList _unitPriceKindWayTable;

		/// <summary>単価算出区分リスト</summary>
		public static SortedList _unPrcCalcDivTable;

		/// <summary>単価端数処理区分リスト</summary>
		public static SortedList _unPrcFracProcDivTable;

		/// <summary>全体入力コントロールリスト</summary>
		public static ArrayList _setDataAllInpCtrl;

		/// <summary>入力条件リスト</summary>
		public static ArrayList _setDataInpCond;

		/// <summary>商品掛率条件リスト</summary>
		public static ArrayList _setDataGoodsRateCond;

		/// <summary>得意先掛率条件リスト</summary>
		public static ArrayList _setDataCustRateCond;

		/// <summary>新旧掛率入力条件リスト</summary>
		public static ArrayList _setDataRateInpCond;
		
		/// <summary>
		/// 静的コンストラクタ
		/// </summary>
		static Rate()
		{
			// 新旧区分設定
			_OldNewDivCdTable		= MakeOldNewDivCdTable();
			
			// コンボボックス設定
			_unitPriceKindTable		= MakeUnitPriceKindTable();
			_unitPriceKindWayTable	= MakeUnitPriceKindWayTable();
			_unPrcCalcDivTable		= MakeUnPrcCalcDiv();
			_unPrcFracProcDivTable	= MakeUnPrcFracProcDiv();
			
			// 各種条件設定
			_setDataAllInpCtrl		= SetDataAllInpCtrl();
			_setDataInpCond			= SetDataInpCond();
			_setDataGoodsRateCond	= SetDataGoodsRateCond();
			_setDataCustRateCond	= SetDataCustRateCond();
			_setDataRateInpCond		= SetDataRateInpCond();
		}

		/// <summary>
		/// ソートリスト名称取得処理
		/// </summary>
		/// <param name="code">ソートリストコード</param>
		/// <returns>名称</returns>
		/// <remarks>
		/// <br>Note       : ソートリストコードからソートリスト名称を取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.07</br>
		/// </remarks>
		public static string GetSortedListNm(object code, SortedList sList)
		{
			string retStr = "";

			if (sList.ContainsKey((object)code))
			{
				retStr = sList[code].ToString();
			}
			return retStr;
		}

		/// <summary>
		/// 単価種類設定方法判定
		/// </summary>
		/// <param name="rateMngGoodsCd">掛率設定区分（商品）</param>
		/// <returns>単価種類設定方法判別値(0:単品, 1:グループ)</returns>
		/// <remarks>
		/// <br>Note	   : 掛率設定区分（商品）によって単価種類設定方法を判定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.03</br>
		/// </remarks>
		public static int JudgeUnitPriceKindWayCd(string rateMngGoodsCd)
		{
			int retCd;

			// 単価種類設定方法コード取得
			if (string.Equals(rateMngGoodsCd, "A") == true)
			{
				// 単品設定
				retCd = 0;
			}
			else
			{
				// グループ設定
				retCd = 1;
			}
			return retCd;
		}

		/// <summary>
		/// 新旧区分リスト生成
		/// </summary>
		/// <returns>新旧区分のリスト</returns>
		/// <remarks>
		/// <br>Note	   : 新旧区分のリストを生成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.24</br>
		/// </remarks>
		private static SortedList MakeOldNewDivCdTable()
		{
			SortedList retSortedList = new SortedList();
			retSortedList.Add(0, "0");
			retSortedList.Add(1, "1");
			return retSortedList;
		}

		/// <summary>
		/// 単価種類リスト生成
		/// </summary>
		/// <returns>単価種類のリスト</returns>
		/// <remarks>
		/// <br>Note	   : 単価種類のリストを生成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.03</br>
		/// </remarks>
		private static SortedList MakeUnitPriceKindTable()
		{
			SortedList retSortedList = new SortedList();
			retSortedList.Add(1, "売上単価");
			retSortedList.Add(2, "売上原価");
			retSortedList.Add(3, "仕入単価");
			retSortedList.Add(4, "定価");
			return retSortedList;
		}

		/// <summary>
		/// 単価種類設定方法リスト生成
		/// </summary>
		/// <returns>単価種類設定方法のリスト</returns>
		/// <remarks>
		/// <br>Note	   : 単価種類設定方法のリストを生成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.03</br>
		/// </remarks>
		private static SortedList MakeUnitPriceKindWayTable()
		{
			SortedList retSortedList = new SortedList();
			retSortedList.Add(0, "単品設定");
			retSortedList.Add(1, "商品ｸﾞﾙｰﾌﾟ設定");
			return retSortedList;
		}

		/// <summary>
		/// 単価算出区分リスト生成
		/// </summary>
		/// <returns>単価算出区分のリスト</returns>
		/// <remarks>
		/// <br>Note	   : 単価算出区分のリストを生成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.03</br>
		/// </remarks>
		private static SortedList MakeUnPrcCalcDiv()
		{
			SortedList retSortedList = new SortedList();
			retSortedList.Add(1, "基準価格×掛率");
			retSortedList.Add(2, "原価×原価UP率");
			retSortedList.Add(3, "原価÷(1-粗利率)");
			retSortedList.Add(4, "入力定価×掛率");
			return retSortedList;
		}

		/// <summary>
		/// 単価端数処理区分リスト生成
		/// </summary>
		/// <returns>単価端数処理区分のリスト</returns>
		/// <remarks>
		/// <br>Note	   : 単価端数処理区分のリストを生成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.03</br>
		/// </remarks>
		private static SortedList MakeUnPrcFracProcDiv()
		{
			SortedList retSortedList = new SortedList();
			retSortedList.Add(1, "切捨て");
			retSortedList.Add(2, "四捨五入");
			retSortedList.Add(3, "切上げ");
			return retSortedList;
		}

		/// <summary>
		/// 全体入力コントロールデータ設定
		/// </summary>
		/// <returns>全体入力コントロールデータリスト</returns>
		/// <remarks>
		/// <br>Note       : 全体入力コントロールデータを設定します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.10.19</br>
		/// </remarks>
		private static ArrayList SetDataAllInpCtrl()
		{
			ArrayList condList = new ArrayList();

			//------------------------------------------------------------------------------------------------------------------
			// 設定順序
			//（条件）画面ﾀﾌﾞ,        画面入力状況
			//（結果）掛率設定ﾊﾟﾈﾙ,   単品設定ﾊﾟﾈﾙ,   商品G設定ﾊﾟﾈﾙ,      取引先設定ﾊﾟﾈﾙ, 検索ﾎﾞﾀﾝ,
			//        新掛率設定ﾊﾟﾈﾙ, 旧掛率設定ﾊﾟﾈﾙ, 新掛率→旧掛率ﾎﾞﾀﾝ, 保存ﾎﾞﾀﾝ,       論理削除ﾎﾞﾀﾝ, 物理削除ﾎﾞﾀﾝ, 復活ﾎﾞﾀﾝ,
			//        掛率ﾀﾌﾞ,        ﾛｯﾄﾀﾌﾞ
			//
			// ※詳細 画面ﾀﾌﾞ      0:掛率ﾀﾌﾞ, 1:ﾛｯﾄﾀﾌﾞ
			//        画面入力状況 0:初期(掛率設定), 1:条件設定,       2:検索後新規ﾓｰﾄﾞ,     3:検索後更新ﾓｰﾄﾞ, 4:検索後削除ﾓｰﾄﾞ
			//------------------------------------------------------------------------------------------------------------------
			
			// 掛率タブ―初期(掛率設定)
			string[] inpCond = new string[]{
				"0", "0",
				"1", "0", "0", "0", "0",
				"0", "0", "0", "0", "0", "0", "0",
				"1", "0" };
			condList.Add(inpCond);
			
			// 掛率タブ―条件設定
			inpCond = new string[]{
				"0", "1",
				"1", "1", "1", "1", "1",
				"0", "0", "0", "0", "0", "0", "0",
				"1", "0" };
			condList.Add(inpCond);
			
			// 掛率タブ―検索後新規ﾓｰﾄﾞ,
			// 掛率タブ―削除ﾓｰﾄﾞ物理削除後,
			inpCond = new string[]{
				"0", "2",
				"1", "1", "1", "1", "1",
				"1", "1", "1", "1", "0", "0", "0",
				"1", "0" };
			condList.Add(inpCond);
			
			// 掛率タブ―検索後更新ﾓｰﾄﾞ,
			// 掛率タブ―新規ﾓｰﾄﾞ保存後,
			// 掛率タブ―更新ﾓｰﾄﾞ保存後,
			// 掛率タブ―削除ﾓｰﾄﾞ復活後
			inpCond = new string[]{
				"0", "3",
				"1", "1", "1", "1", "1",
				"1", "1", "1", "1", "1", "0", "0",
				"1", "1" };
			condList.Add(inpCond);
			
			// 掛率タブ―検索後削除ﾓｰﾄﾞ
			inpCond = new string[]{
				"0", "4",
				"1", "1", "1", "1", "1",
				"0", "0", "0", "0", "0", "1", "1",
				"1", "0" };
			condList.Add(inpCond);
			
			// ロットタブ―初期
			inpCond = new string[]{
				"1", "0",
				"0", "0", "0", "0", "0",
				"0", "0", "0", "0", "0", "0", "0",
				"1", "1" };
			condList.Add(inpCond);
			
			return condList;
		}
		
		/// <summary>
		/// 入力条件データ設定
		/// </summary>
		/// <returns>入力条件データリスト</returns>
		/// <remarks>
		/// <br>Note       : 入力条件データを設定します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.10.09</br>
		/// </remarks>
		private static ArrayList SetDataInpCond()
		{
			ArrayList condList = new ArrayList();

			//------------------------------------------------------------------------------------------------------------------
			// 設定順序
			//（条件）単価種類, 設定方法
			//（結果）商品ｺｰﾄﾞ, ﾒｰｶｰｺｰﾄﾞ, 商品掛率ﾗﾝｸ, 商品区分Gｺｰﾄﾞ, 商品区分ｺｰﾄﾞ, 商品区分詳細ｺｰﾄﾞ, 自社分類ｺｰﾄﾞ, BL商品ｺｰﾄﾞ,
			//        得意先ｺｰﾄﾞ, 得意先掛率G, 仕入先ｺｰﾄﾞ, 仕入先掛率G
			//------------------------------------------------------------------------------------------------------------------

			// 売上単価―単品設定
			string[] inpCond = new string[]{
				"1", "0",
				"1", "1", "0", "0", "0", "0", "0", "0",
				"1", "1", "1", "1" };
			condList.Add(inpCond);

			// 売上単価―商品G設定
			inpCond = new string[]{
				"1", "1",
				"0", "1", "1", "1", "1", "1", "1", "1",
				"1", "1", "1", "1" };
			condList.Add(inpCond);

			// 売上原価―単品設定
			inpCond = new string[]{
				"2", "0",
				"1", "1", "0", "0", "0", "0", "0", "0",
				"1", "1", "1", "1" };
			condList.Add(inpCond);
			
			// 売上原価―商品G設定
			inpCond = new string[]{
				"2", "1",
				"0", "1", "1", "1",	"1", "1", "1", "1",
				"1", "1", "1", "1" };
			condList.Add(inpCond);

			// 仕入単価―単品設定
			inpCond = new string[]{
				"3", "0",
				"1", "1", "0", "0", "0", "0", "0", "0",
				"1", "1", "1", "1" };
			condList.Add(inpCond);

			// 仕入単価―商品G設定
			inpCond = new string[]{
				"3", "1",
				"0", "1", "1", "1", "1", "1", "1", "1",
				"1", "1", "1", "1" };
			condList.Add(inpCond);

			// 定価―単品設定
			inpCond = new string[]{
				"4", "0",
				"1", "1", "0", "0", "0", "0", "0", "0",
				"1", "1", "1", "1" };
			condList.Add(inpCond);

			// 定価―商品G設定
			inpCond = new string[]{
				"4", "1",
				"0", "1", "1", "1", "1", "1", "1", "1",
				"1", "1", "1", "1" };
			condList.Add(inpCond);

			return condList;
		}
		
		/// <summary>
		/// 商品掛率条件データ設定
		/// </summary>
		/// <returns>商品掛率条件データリスト</returns>
		/// <remarks>
		/// <br>Note       : 商品掛率条件データを設定します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.10.09</br>
		/// </remarks>
		private static ArrayList SetDataGoodsRateCond()
		{
			ArrayList condList = new ArrayList();

			//------------------------------------------------------------------------------------------------------------------
			// 設定順序
			//（条件）区分,
			//（結果）商品ｺｰﾄﾞ, ﾒｰｶｰｺｰﾄﾞ, 商品掛率ﾗﾝｸ, 商品区分Gｺｰﾄﾞ, 商品区分ｺｰﾄﾞ, 商品区分詳細ｺｰﾄﾞ, 自社分類ｺｰﾄﾞ, BL商品ｺｰﾄﾞ
			//------------------------------------------------------------------------------------------------------------------
			
			string[] inpCond = new string[]{
			    "A",
			    "1", "1", "0", "0", "0", "0", "0", "0" };
			condList.Add(inpCond);

			inpCond = new string[]{
			    "B",
			    "0", "1", "1", "0", "0", "0", "0", "0" };
			condList.Add(inpCond);

			inpCond = new string[]{
			    "C",
			    "0", "1", "0", "0", "0", "0", "0", "1" };
			condList.Add(inpCond);

			inpCond = new string[]{
			    "D",
			    "0", "1", "0", "0", "0", "0", "1", "0" };
			condList.Add(inpCond);

			inpCond = new string[]{
			    "E",
			    "0", "1", "0", "1", "1", "1", "0", "0" };
			condList.Add(inpCond);

			inpCond = new string[]{
			    "F",
			    "0", "1", "0", "1", "1", "0", "0", "0" };
			condList.Add(inpCond);

			inpCond = new string[]{
			    "G",
			    "0", "1", "0", "1", "0", "0", "0", "0" };
			condList.Add(inpCond);

			inpCond = new string[]{
			    "H",
			    "0", "1", "0", "0", "0", "0", "0", "0" };
			condList.Add(inpCond);

			inpCond = new string[]{
			    "I",
			    "0", "0", "1", "0", "0", "0", "0", "0" };
			condList.Add(inpCond);

			inpCond = new string[]{
			    "J",
			    "0", "0", "0", "0", "0", "0", "0", "1" };
			condList.Add(inpCond);

			inpCond = new string[]{
			    "K",
			    "0", "0", "0", "0", "0", "0", "1", "0" };
			condList.Add(inpCond);

			inpCond = new string[]{
			    "L",
			    "0", "0", "0", "1", "1", "1", "0", "0" };
			condList.Add(inpCond);

			inpCond = new string[]{
			    "M",
			    "0", "0", "0", "1", "1", "0", "0", "0" };
			condList.Add(inpCond);

			inpCond = new string[]{
			    "N",
			    "0", "0", "0", "1", "0", "0", "0", "0" };
			condList.Add(inpCond);

			inpCond = new string[]{
			    "O",
			    "0", "0", "0", "0", "0", "0", "0", "0" };
			condList.Add(inpCond);
			
			return condList;
		}
		
		/// <summary>
		/// 得意先掛率条件データ設定
		/// </summary>
		/// <returns>得意先掛率条件データリスト</returns>
		/// <remarks>
		/// <br>Note       : 得意先掛率条件データを設定します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.10.09</br>
		/// </remarks>
		private static ArrayList SetDataCustRateCond()
		{
			ArrayList condList = new ArrayList();

			//------------------------------------------------------------------------------------------------------------------
			// 設定順序
			//（条件）区分,
			//（結果）得意先ｺｰﾄﾞ, 得意先掛率G, 仕入先ｺｰﾄﾞ, 仕入先掛率G
			//------------------------------------------------------------------------------------------------------------------
			
			string[] inpCond = new string[]{
			    "1",
			    "1", "0", "1", "0" };
			condList.Add(inpCond);

			inpCond = new string[]{
			    "2",
			    "1", "0", "0", "1" };
			condList.Add(inpCond);

			inpCond = new string[]{
			    "3",
			    "1", "0", "0", "0" };
			condList.Add(inpCond);

			inpCond = new string[]{
			    "4",
			    "0", "1", "1", "0" };
			condList.Add(inpCond);

			inpCond = new string[]{
			    "5",
			    "0", "1", "0", "1" };
			condList.Add(inpCond);

			inpCond = new string[]{
			    "6",
			    "0", "1", "0", "0" };
			condList.Add(inpCond);

			inpCond = new string[]{
			    "7",
			    "0", "0", "1", "0" };
			condList.Add(inpCond);

			inpCond = new string[]{
			    "8",
			    "0", "0", "0", "1" };
			condList.Add(inpCond);

			inpCond = new string[]{
			    "9",
			    "0", "0", "0", "0" };
			condList.Add(inpCond);

			return condList;
		}
		
		/// <summary>
		/// 新旧掛率入力条件データ設定
		/// </summary>
		/// <returns>新旧掛率入力条件データリスト</returns>
		/// <remarks>
		/// <br>Note       : 新旧掛率入力条件データを設定します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.10.11</br>
		/// </remarks>
		private static ArrayList SetDataRateInpCond()
		{
			ArrayList condList = new ArrayList();

			//--------------------------------------------------------------------------------------
			// 設定順序
			//（条件）単価種類, 設定方法
			//（結果）掛率開始日, 価格, 価格区分, 単価算出区分
			//--------------------------------------------------------------------------------------

			// 売上単価―単品設定
			string[] inpCond = new string[]{
				"1", "0",
				"1", "1", "1", "1" };
			condList.Add(inpCond);

			// 売上単価―商品G設定
			inpCond = new string[]{
				"1", "1",
				"1", "0", "1", "1" };
			condList.Add(inpCond);

			// 売上原価―単品設定
			inpCond = new string[]{
				"2", "0",
				"1", "1", "1", "11" };	// 1:基準価格×掛率のみ
			condList.Add(inpCond);

			// 売上原価―商品G設定
			inpCond = new string[]{
				"2", "1",
				"1", "0" ,"1", "11" };	// 1:基準価格×掛率のみ
			condList.Add(inpCond);

			// 仕入単価―単品設定
			inpCond = new string[]{
				"3", "0",
				"1", "0", "1", "11" };	// 1:基準価格×掛率のみ
			condList.Add(inpCond);

			// 仕入単価―商品G設定
			inpCond = new string[]{
				"3", "1",
				"1", "0", "1", "11" };	// 1:基準価格×掛率のみ
			condList.Add(inpCond);

			// 定価―単品設定
			inpCond = new string[]{
				"4", "0",
				"1", "1", "1", "11" };	// 1:基準価格×掛率のみ
			condList.Add(inpCond);

			// 定価―商品G設定
			inpCond = new string[]{
				"4", "1",
				"1", "0", "1", "11" };	// 1:基準価格×掛率のみ
			condList.Add(inpCond);

			return condList;
		}
           --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
    }
}
