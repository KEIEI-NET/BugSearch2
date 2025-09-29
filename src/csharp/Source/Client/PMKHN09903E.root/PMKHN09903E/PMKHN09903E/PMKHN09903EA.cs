//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率一括登録・修正Ⅱ抽出条件クラス
// プログラム概要   : 定義・初期化及びインスタンス生成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宋剛
// 作 成 日  2013/02/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   Rate2SearchParam
	/// <summary>
    ///                      掛率一括登録・修正Ⅱ抽出条件クラス
	/// </summary>
	/// <remarks>
    /// <br>note             :   掛率一括登録・修正Ⅱ抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2013/02/19  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class Rate2SearchParam
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>(配列)　全社指定はnull</remarks>
		private String[] _sectionCode;

		/// <summary>仕入先コード</summary>
		private Int32 _supplierCd;

        /// <summary>仕入先名称</summary>
        private string _supplierNm;

        /// <summary>出力区分</summary>
        private string _outputDiv;

        /// <summary>拠点名称</summary>
        /// <remarks>(配列)/remarks>
        private String[] _sectionName;

		/// <summary>商品掛率グループコード</summary>
		private Int32 _goodsRateGrpCode;

        /// <summary>商品掛率ランク</summary>
        /// <remarks>層別</remarks>
        private string _goodsRateRank;

        /// <summary>商品切替モード</summary>
        /// <remarks>0:商品掛率G 1:層別</remarks>
        private Int32 _goodsChangeMode;

        /// <summary>グループコード</summary>
        private Int32 _groupCd;

        /// <summary>BLコード</summary>
        private Int32 _blCd;

		/// <summary>商品メーカーコード</summary>
		private Int32 _goodsMakerCd;

        /// <summary>商品メーカー名称</summary>
        private string _goodsMakerNm;

		/// <summary>得意先コード</summary>
		/// <remarks>(配列) nullの場合は全て</remarks>
		private Int32[] _customerCode;

		/// <summary>得意先掛率グループコード</summary>
		/// <remarks>(配列) nullの場合は全て</remarks>
		private Int32[] _custRateGrpCode;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

        /// <summary>ログイン拠点コード</summary>
        /// <remarks></remarks>
        private String[] _prmSectionCode;

        /// <summary>得意先検索モード</summary>
        /// <remarks>（0: 得意先掛率Ｇ; 1 : 得意先ＣＤ</remarks>
        private Int32 _customerSearchMode;

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

		/// public propaty name  :  SectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// <value>(配列)　全社指定はnull</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public String[] SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
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

        /// public propaty name  :  SupplierCd
		/// <summary>仕入先名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
        /// <br>note             :   仕入先名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SupplierNm
		{
            get { return _supplierNm; }
            set { _supplierNm = value; }
		}

        /// public propaty name  :  出力区分
        /// <summary>出力区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
        /// <br>note             :   出力区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public string OutputDiv
		{
            get { return _outputDiv; }
            set { _outputDiv = value; }
		}


        /// public propaty name  :  SectionName
        /// <summary>拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public String[] SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        

		/// public propaty name  :  GoodsRateGrpCode
		/// <summary>商品掛率グループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品掛率グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsRateGrpCode
		{
			get{return _goodsRateGrpCode;}
			set{_goodsRateGrpCode = value;}
		}

        /// public propaty name  :  GoodsRateRank
        /// <summary>商品掛率ランクプロパティ</summary>
        /// <value>層別</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率ランクプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsRateRank
        {
            get { return _goodsRateRank; }
            set { _goodsRateRank = value; }
        }

        /// public propaty name  :  CustomerSearchMode
        /// <summary>商品切替モードプロパティ</summary>
        /// <value>0:商品掛率G 1:層別</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品切替モードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsChangeMode
        {
            get { return _goodsChangeMode; }
            set { _goodsChangeMode = value; }
        }

        /// public propaty name  :  GroupCd
        /// <summary>グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GroupCd
        {
            get { return _groupCd; }
            set { _groupCd = value; }
        }

        /// public propaty name  :  BlCd
        /// <summary>BLコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコードコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BlCd
        {
            get { return _blCd; }
            set { _blCd = value; }
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

        /// public propaty name  :  GoodsMakerNm
		/// <summary>商品メーカー名称</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品メーカー名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public string GoodsMakerNm
		{
            get { return _goodsMakerNm; }
            set { _goodsMakerNm = value; }
		}

        

		/// public propaty name  :  CustomerCode
		/// <summary>得意先コードプロパティ</summary>
		/// <value>(配列) nullの場合は全て</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32[] CustomerCode
		{
			get{return _customerCode;}
			set{_customerCode = value;}
		}

		/// public propaty name  :  CustRateGrpCode
		/// <summary>得意先掛率グループコードプロパティ</summary>
		/// <value>(配列) nullの場合は全て</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先掛率グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32[] CustRateGrpCode
		{
			get{return _custRateGrpCode;}
			set{_custRateGrpCode = value;}
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

        /// public propaty name  :  SectionCode
        /// <summary>ログイン拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public String[] PrmSectionCode
        {
            get { return _prmSectionCode; }
            set { _prmSectionCode = value; }
        }

        /// public propaty name  :  CustomerSearchMode
        /// <summary>得意先検索モード（0: 得意先掛率Ｇ; 1 : 得意先ＣＤ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先検索モード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerSearchMode
        {
            get { return _customerSearchMode; }
            set { _customerSearchMode = value; }
        }

		/// <summary>
        /// 掛率一括登録・修正Ⅱ抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>Rate2SearchParamクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Rate2SearchParamクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Rate2SearchParam()
		{
		}

		/// <summary>
        /// 掛率一括登録・修正Ⅱ抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="sectionCode">拠点コード((配列)　全社指定はnull)</param>
		/// <param name="supplierCd">仕入先コード</param>
		/// <param name="goodsRateGrpCode">商品掛率グループコード</param>
        /// <param name="goodsRateRank">層別</param>
        /// <param name="goodChangeMode">商品切替モード</param>
		/// <param name="goodsMakerCd">商品メーカーコード</param>
		/// <param name="customerCode">得意先コード((配列) nullの場合は全て)</param>
		/// <param name="custRateGrpCode">得意先掛率グループコード((配列) nullの場合は全て)</param>
		/// <param name="enterpriseName">企業名称</param>
        /// <param name="prmSectionCode">ログイン拠点コード</param>
		/// <returns>Rate2SearchParamクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Rate2SearchParamクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Rate2SearchParam(string enterpriseCode, String[] sectionCode, Int32 supplierCd, Int32 goodsRateGrpCode, string goodsRateRank, Int32 goodsChangeMode, Int32 groupCd, Int32 blCd, Int32 goodsMakerCd, Int32[] customerCode, Int32[] custRateGrpCode, string enterpriseName, String[] prmSectionCode)
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCode = sectionCode;
			this._supplierCd = supplierCd;
			this._goodsRateGrpCode = goodsRateGrpCode;
            this._goodsRateRank = goodsRateRank;
            this._goodsChangeMode = goodsChangeMode;
            this._groupCd = groupCd;
            this._blCd = blCd;
			this._goodsMakerCd = goodsMakerCd;
			this._customerCode = customerCode;
			this._custRateGrpCode = custRateGrpCode;
			this._enterpriseName = enterpriseName;
            this._prmSectionCode = prmSectionCode;
		}

		/// <summary>
        /// 掛率一括登録・修正Ⅱ抽出条件クラス複製処理
		/// </summary>
		/// <returns>Rate2SearchParamクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいRate2SearchParamクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Rate2SearchParam Clone()
		{
			return new Rate2SearchParam(this._enterpriseCode,this._sectionCode,this._supplierCd,this._goodsRateGrpCode, this._goodsRateRank,this._goodsChangeMode,this._groupCd,this._blCd, this._goodsMakerCd, this._customerCode,this._custRateGrpCode,this._enterpriseName, this._prmSectionCode);
		}

		/// <summary>
        /// 掛率一括登録・修正Ⅱ抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のRate2SearchParamクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Rate2SearchParamクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(Rate2SearchParam target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.SupplierCd == target.SupplierCd)
				 && (this.GoodsRateGrpCode == target.GoodsRateGrpCode)
                 && (this.GoodsRateRank == target.GoodsRateRank)
                 && (this.GoodsChangeMode == target.GoodsChangeMode)
				 && (this.GoodsMakerCd == target.GoodsMakerCd)
				 && (this.CustomerCode == target.CustomerCode)
				 && (this.CustRateGrpCode == target.CustRateGrpCode)
				 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.PrmSectionCode == target.PrmSectionCode));
		}

		/// <summary>
        /// 掛率一括登録・修正Ⅱ抽出条件クラス比較処理
		/// </summary>
		/// <param name="rateSearchParam1">
		///                    比較するRate2SearchParamクラスのインスタンス
		/// </param>
		/// <param name="rateSearchParam2">比較するRate2SearchParamクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Rate2SearchParamクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(Rate2SearchParam rateSearchParam1, Rate2SearchParam rateSearchParam2)
		{
			return ((rateSearchParam1.EnterpriseCode == rateSearchParam2.EnterpriseCode)
				 && (rateSearchParam1.SectionCode == rateSearchParam2.SectionCode)
				 && (rateSearchParam1.SupplierCd == rateSearchParam2.SupplierCd)
				 && (rateSearchParam1.GoodsRateGrpCode == rateSearchParam2.GoodsRateGrpCode)
                 && (rateSearchParam1.GoodsRateRank == rateSearchParam2.GoodsRateRank)
                 && (rateSearchParam1.GoodsChangeMode == rateSearchParam2.GoodsChangeMode)
				 && (rateSearchParam1.GoodsMakerCd == rateSearchParam2.GoodsMakerCd)
				 && (rateSearchParam1.CustomerCode == rateSearchParam2.CustomerCode)
				 && (rateSearchParam1.CustRateGrpCode == rateSearchParam2.CustRateGrpCode)
				 && (rateSearchParam1.EnterpriseName == rateSearchParam2.EnterpriseName)
                 && (rateSearchParam1.PrmSectionCode == rateSearchParam2.PrmSectionCode));
		}
		/// <summary>
        /// 掛率一括登録・修正Ⅱ抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のRate2SearchParamクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Rate2SearchParamクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(Rate2SearchParam target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.SupplierCd != target.SupplierCd)resList.Add("SupplierCd");
			if(this.GoodsRateGrpCode != target.GoodsRateGrpCode)resList.Add("GoodsRateGrpCode");
            if (this.GoodsRateRank != target.GoodsRateRank) resList.Add("GoodsRateRank");
            if (this.GoodsChangeMode != target.GoodsChangeMode) resList.Add("GoodsChangeMode");
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.CustRateGrpCode != target.CustRateGrpCode)resList.Add("CustRateGrpCode");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.PrmSectionCode != target.PrmSectionCode) resList.Add("PrmSectionCode");

			return resList;
		}

		/// <summary>
        /// 掛率一括登録・修正Ⅱ抽出条件クラス比較処理
		/// </summary>
		/// <param name="rateSearchParam1">比較するRate2SearchParamクラスのインスタンス</param>
		/// <param name="rateSearchParam2">比較するRate2SearchParamクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Rate2SearchParamクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(Rate2SearchParam rateSearchParam1, Rate2SearchParam rateSearchParam2)
		{
			ArrayList resList = new ArrayList();
			if(rateSearchParam1.EnterpriseCode != rateSearchParam2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(rateSearchParam1.SectionCode != rateSearchParam2.SectionCode)resList.Add("SectionCode");
			if(rateSearchParam1.SupplierCd != rateSearchParam2.SupplierCd)resList.Add("SupplierCd");
			if(rateSearchParam1.GoodsRateGrpCode != rateSearchParam2.GoodsRateGrpCode)resList.Add("GoodsRateGrpCode");
            if (rateSearchParam1.GoodsRateRank != rateSearchParam2.GoodsRateRank) resList.Add("GoodsRateRank");
            if (rateSearchParam1.GoodsChangeMode != rateSearchParam2.GoodsChangeMode) resList.Add("GoodsChangeMode");
			if(rateSearchParam1.GoodsMakerCd != rateSearchParam2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(rateSearchParam1.CustomerCode != rateSearchParam2.CustomerCode)resList.Add("CustomerCode");
			if(rateSearchParam1.CustRateGrpCode != rateSearchParam2.CustRateGrpCode)resList.Add("CustRateGrpCode");
            if (rateSearchParam1.EnterpriseName != rateSearchParam2.EnterpriseName) resList.Add("EnterpriseName");
            if (rateSearchParam1.PrmSectionCode != rateSearchParam2.PrmSectionCode) resList.Add("PrmSectionCode");

			return resList;
		}
	}
}
