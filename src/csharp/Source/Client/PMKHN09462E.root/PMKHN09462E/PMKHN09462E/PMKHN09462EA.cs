//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 単品売価設定一括登録・修正
// プログラム概要   : 掛率マスタの単品設定分を対象に、複数件一括で登録・修正、一括削除、引用登録を行う。
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2010/08/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   GoodsRateSetSearchParam
	/// <summary>
	///                      単品売価設定一括登録・修正抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   単品売価設定一括登録・修正抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
    /// <br>Genarated Date   :   2010/08/04  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class GoodsRateSetSearchParam
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>(配列)　全社指定はnull</remarks>
		private String[] _sectionCode;

		/// <summary>仕入先コード</summary>
		private Int32 _supplierCd;

		/// <summary>商品掛率グループコード</summary>
		private Int32 _goodsRateGrpCode;

		/// <summary>商品メーカーコード</summary>
		private Int32 _goodsMakerCd;

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

        /// <summary>品番</summary>
        /// <remarks></remarks>
        private String _goodsNo;

        /// <summary>BLコード</summary>
        /// <remarks></remarks>
        private Int32 _blGoodsCode;

        /// <summary>BLグループコード</summary>
        /// <remarks></remarks>
        private Int32 _blGroupCode;

        /// <summary>対象区分</summary>
        /// <remarks></remarks>
        private String _objectDiv;

        /// <summary>未設定</summary>
        /// <remarks></remarks>
        private bool _unSettingFlg;

        /// <summary>掛率設定区分（商品）</summary>
        /// <remarks>A～O　</remarks>
        private string _rateMngGoodsCd = "";

        /// <summary>掛率設定区分（得意先）</summary>
        /// <remarks>1～9　</remarks>
        private string _rateMngCustCd = "";

        //-----ADD 2010/08/31----->>>>>
        /// <summary>ファイル名</summary>
        private string _fileName = "";
        //-----ADD 2010/08/31-----<<<<<

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

        /// public propaty name  :  BlGoodsCode
        /// <summary>BLコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BlGoodsCode
        {
            get { return _blGoodsCode; }
            set { _blGoodsCode = value; }
        }

        /// public propaty name  :  BlGroupCodes
        /// <summary>BLグループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BlGroupCode
        {
            get { return _blGroupCode; }
            set { _blGroupCode = value; }
        }

        /// public propaty name  :  ObjectDiv
        /// <summary>対象区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   対象区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ObjectDiv
        {
            get { return _objectDiv; }
            set { _objectDiv = value; }
        }

        /// public propaty name  :  UnSettingFlg
        /// <summary>未設定プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   未設定プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool UnSettingFlg
        {
            get { return _unSettingFlg; }
            set { _unSettingFlg = value; }
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
            get { return _rateMngGoodsCd; }
            set { _rateMngGoodsCd = value; }
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
            get { return _rateMngCustCd; }
            set { _rateMngCustCd = value; }
        }


        //-----ADD 2010/08/31----->>>>>
        /// public propaty name  :  FileName
        /// <summary>ファイル名プロパティ</summary>
        /// <value>1～9　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ファイル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        //-----ADD 2010/08/31-----<<<<<

		/// <summary>
		/// 単品売価設定一括登録・修正抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>GoodsRateSetSearchParamクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   GoodsRateSetSearchParamクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public GoodsRateSetSearchParam()
		{
		}

		/// <summary>
		/// 単品売価設定一括登録・修正抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="sectionCode">拠点コード((配列)　全社指定はnull)</param>
		/// <param name="supplierCd">仕入先コード</param>
		/// <param name="goodsRateGrpCode">商品掛率グループコード</param>
		/// <param name="goodsMakerCd">商品メーカーコード</param>
		/// <param name="customerCode">得意先コード((配列) nullの場合は全て)</param>
		/// <param name="custRateGrpCode">得意先掛率グループコード((配列) nullの場合は全て)</param>
		/// <param name="enterpriseName">企業名称</param>
        /// <param name="prmSectionCode">ログイン拠点コード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="BlGoodsCode">BLコード</param>
        /// <param name="BlGroupCode">BLグループコード</param>
        /// <param name="objectDiv">対象区分</param>
        /// <param name="unSettingFlg">未設定</param>
		/// <returns>GoodsRateSetSearchParamクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   GoodsRateSetSearchParamクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public GoodsRateSetSearchParam(string enterpriseCode, String[] sectionCode, Int32 supplierCd, Int32 goodsRateGrpCode, Int32 goodsMakerCd, Int32[] customerCode, Int32[] custRateGrpCode, string enterpriseName, String[] prmSectionCode, string goodsNo, Int32 blGoodsCode, Int32 blGroupCode, string objectDiv, bool unSettingFlg)
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCode = sectionCode;
			this._supplierCd = supplierCd;
			this._goodsRateGrpCode = goodsRateGrpCode;
			this._goodsMakerCd = goodsMakerCd;
			this._customerCode = customerCode;
			this._custRateGrpCode = custRateGrpCode;
			this._enterpriseName = enterpriseName;
            this._prmSectionCode = prmSectionCode;
            this._goodsNo = goodsNo;
            this._blGoodsCode = blGoodsCode;
            this._blGroupCode = blGroupCode;
            this._objectDiv = objectDiv;
            this._unSettingFlg = unSettingFlg;
		}

		/// <summary>
		/// 単品売価設定一括登録・修正抽出条件クラス複製処理
		/// </summary>
		/// <returns>GoodsRateSetSearchParamクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいGoodsRateSetSearchParamクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public GoodsRateSetSearchParam Clone()
		{
            return new GoodsRateSetSearchParam(this._enterpriseCode, this._sectionCode, this._supplierCd, this._goodsRateGrpCode, this._goodsMakerCd, this._customerCode, this._custRateGrpCode, this._enterpriseName, this._prmSectionCode, this._goodsNo, this._blGoodsCode, this._blGroupCode, this._objectDiv, this._unSettingFlg);
		}

		/// <summary>
		/// 単品売価設定一括登録・修正抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のGoodsRateSetSearchParamクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   GoodsRateSetSearchParamクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(GoodsRateSetSearchParam target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.SupplierCd == target.SupplierCd)
				 && (this.GoodsRateGrpCode == target.GoodsRateGrpCode)
				 && (this.GoodsMakerCd == target.GoodsMakerCd)
				 && (this.CustomerCode == target.CustomerCode)
				 && (this.CustRateGrpCode == target.CustRateGrpCode)
				 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.PrmSectionCode == target.PrmSectionCode)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.BlGoodsCode == target.BlGoodsCode)
                 && (this.BlGroupCode == target.BlGroupCode)
                 && (this.ObjectDiv == target.ObjectDiv)
                 && (this.UnSettingFlg == target.UnSettingFlg));
		}

		/// <summary>
		/// 単品売価設定一括登録・修正抽出条件クラス比較処理
		/// </summary>
		/// <param name="rateSearchParam1">
		///                    比較するGoodsRateSetSearchParamクラスのインスタンス
		/// </param>
		/// <param name="rateSearchParam2">比較するGoodsRateSetSearchParamクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   GoodsRateSetSearchParamクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(GoodsRateSetSearchParam rateSearchParam1, GoodsRateSetSearchParam rateSearchParam2)
		{
			return ((rateSearchParam1.EnterpriseCode == rateSearchParam2.EnterpriseCode)
				 && (rateSearchParam1.SectionCode == rateSearchParam2.SectionCode)
				 && (rateSearchParam1.SupplierCd == rateSearchParam2.SupplierCd)
				 && (rateSearchParam1.GoodsRateGrpCode == rateSearchParam2.GoodsRateGrpCode)
				 && (rateSearchParam1.GoodsMakerCd == rateSearchParam2.GoodsMakerCd)
				 && (rateSearchParam1.CustomerCode == rateSearchParam2.CustomerCode)
				 && (rateSearchParam1.CustRateGrpCode == rateSearchParam2.CustRateGrpCode)
				 && (rateSearchParam1.EnterpriseName == rateSearchParam2.EnterpriseName)
                 && (rateSearchParam1.PrmSectionCode == rateSearchParam2.PrmSectionCode)
                 && (rateSearchParam1.GoodsNo == rateSearchParam2.GoodsNo)
                 && (rateSearchParam1.BlGoodsCode == rateSearchParam2.BlGoodsCode)
                 && (rateSearchParam1.BlGroupCode == rateSearchParam2.BlGroupCode)
                 && (rateSearchParam1.ObjectDiv == rateSearchParam2.ObjectDiv)
                 && (rateSearchParam1.UnSettingFlg == rateSearchParam2.UnSettingFlg));
		}
		/// <summary>
		/// 単品売価設定一括登録・修正抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のGoodsRateSetSearchParamクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   GoodsRateSetSearchParamクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(GoodsRateSetSearchParam target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.SupplierCd != target.SupplierCd)resList.Add("SupplierCd");
			if(this.GoodsRateGrpCode != target.GoodsRateGrpCode)resList.Add("GoodsRateGrpCode");
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.CustRateGrpCode != target.CustRateGrpCode)resList.Add("CustRateGrpCode");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.PrmSectionCode != target.PrmSectionCode) resList.Add("PrmSectionCode");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.BlGoodsCode != target.BlGoodsCode) resList.Add("BlGoodsCode");
            if (this.BlGroupCode != target.BlGroupCode) resList.Add("BlGroupCode");
            if (this.ObjectDiv != target.ObjectDiv) resList.Add("ObjectDiv");
            if (this.UnSettingFlg != target.UnSettingFlg) resList.Add("UnSettingFlg");

			return resList;
		}

		/// <summary>
		/// 単品売価設定一括登録・修正抽出条件クラス比較処理
		/// </summary>
		/// <param name="rateSearchParam1">比較するGoodsRateSetSearchParamクラスのインスタンス</param>
		/// <param name="rateSearchParam2">比較するGoodsRateSetSearchParamクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   GoodsRateSetSearchParamクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(GoodsRateSetSearchParam rateSearchParam1, GoodsRateSetSearchParam rateSearchParam2)
		{
			ArrayList resList = new ArrayList();
			if(rateSearchParam1.EnterpriseCode != rateSearchParam2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(rateSearchParam1.SectionCode != rateSearchParam2.SectionCode)resList.Add("SectionCode");
			if(rateSearchParam1.SupplierCd != rateSearchParam2.SupplierCd)resList.Add("SupplierCd");
			if(rateSearchParam1.GoodsRateGrpCode != rateSearchParam2.GoodsRateGrpCode)resList.Add("GoodsRateGrpCode");
			if(rateSearchParam1.GoodsMakerCd != rateSearchParam2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(rateSearchParam1.CustomerCode != rateSearchParam2.CustomerCode)resList.Add("CustomerCode");
			if(rateSearchParam1.CustRateGrpCode != rateSearchParam2.CustRateGrpCode)resList.Add("CustRateGrpCode");
            if (rateSearchParam1.EnterpriseName != rateSearchParam2.EnterpriseName) resList.Add("EnterpriseName");
            if (rateSearchParam1.PrmSectionCode != rateSearchParam2.PrmSectionCode) resList.Add("PrmSectionCode");
            if (rateSearchParam1.GoodsNo != rateSearchParam2.GoodsNo) resList.Add("GoodsNo");
            if (rateSearchParam1.BlGoodsCode != rateSearchParam2.BlGoodsCode) resList.Add("BlGoodsCode");
            if (rateSearchParam1.BlGroupCode != rateSearchParam2.BlGroupCode) resList.Add("BlGroupCode");
            if (rateSearchParam1.ObjectDiv != rateSearchParam2.ObjectDiv) resList.Add("ObjectDiv");
            if (rateSearchParam1.UnSettingFlg != rateSearchParam2.UnSettingFlg) resList.Add("UnSettingFlg");

			return resList;
		}
	}
}
