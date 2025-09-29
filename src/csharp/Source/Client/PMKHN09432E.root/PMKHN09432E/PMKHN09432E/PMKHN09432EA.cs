//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売価一括修正
// プログラム概要   : 売価一括修正を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/04/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SalesRateSearchParam
    /// <summary>
    ///                      売価一括修正抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   掛率マスタ一括登録修正抽出条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/01/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SalesRateSearchParam
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        /// <remarks>全社指定はnull</remarks>
        private String _sectionCode;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>得意先掛率グループコード</summary>
        /// <remarks>(配列) nullの場合は全て</remarks>
        private Int32[] _custRateGrpCode;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>ログイン拠点コード</summary>
        /// <remarks></remarks>
        private String[] _prmSectionCode;

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

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>全社指定はnull</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public String SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
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
            get { return _custRateGrpCode; }
            set { _custRateGrpCode = value; }
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
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
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

        /// <summary>
        /// 売価一括修正抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>SalesRateSearchParamクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesRateSearchParamクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesRateSearchParam()
        {
        }

        /// <summary>
        /// 売価一括修正修正抽出条件クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="sectionCode">拠点コード(全社指定はnull)</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード((配列) nullの場合は全て)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="prmSectionCode">ログイン拠点コード</param>
        /// <returns>SalesRateSearchParamクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesRateSearchParamクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesRateSearchParam(string enterpriseCode, String sectionCode, Int32 bLGoodsCode, Int32 goodsMakerCd, Int32[] custRateGrpCode, string enterpriseName, String[] prmSectionCode)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._bLGoodsCode = bLGoodsCode;
            this._goodsMakerCd = goodsMakerCd;
            this._custRateGrpCode = custRateGrpCode;
            this._enterpriseName = enterpriseName;
            this._prmSectionCode = prmSectionCode;
        }

        /// <summary>
        /// 売価一括修正抽出条件クラス複製処理
        /// </summary>
        /// <returns>SalesRateSearchParamクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSalesRateSearchParamクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesRateSearchParam Clone()
        {
            return new SalesRateSearchParam(this._enterpriseCode, this._sectionCode, this._bLGoodsCode, this._goodsMakerCd, this._custRateGrpCode, this._enterpriseName, this._prmSectionCode);
        }

        /// <summary>
        /// 売価一括修正抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のSalesRateSearchParamクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesRateSearchParamクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SalesRateSearchParam target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.CustRateGrpCode == target.CustRateGrpCode)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.PrmSectionCode == target.PrmSectionCode));
        }

        /// <summary>
        /// 売価一括修正抽出条件クラス比較処理
        /// </summary>
        /// <param name="rateSearchParam1">
        ///                    比較するSalesRateSearchParamクラスのインスタンス
        /// </param>
        /// <param name="rateSearchParam2">比較するSalesRateSearchParamクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesRateSearchParamクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SalesRateSearchParam rateSearchParam1, SalesRateSearchParam rateSearchParam2)
        {
            return ((rateSearchParam1.EnterpriseCode == rateSearchParam2.EnterpriseCode)
                 && (rateSearchParam1.SectionCode == rateSearchParam2.SectionCode)
                 && (rateSearchParam1.BLGoodsCode == rateSearchParam2.BLGoodsCode)
                 && (rateSearchParam1.GoodsMakerCd == rateSearchParam2.GoodsMakerCd)
                 && (rateSearchParam1.CustRateGrpCode == rateSearchParam2.CustRateGrpCode)
                 && (rateSearchParam1.EnterpriseName == rateSearchParam2.EnterpriseName)
                 && (rateSearchParam1.PrmSectionCode == rateSearchParam2.PrmSectionCode));
        }
        /// <summary>
        ///  売価一括修正抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のSalesRateSearchParamクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesRateSearchParamクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SalesRateSearchParam target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.CustRateGrpCode != target.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.PrmSectionCode != target.PrmSectionCode) resList.Add("PrmSectionCode");

            return resList;
        }

        /// <summary>
        /// 売価一括修正抽出条件クラス比較処理
        /// </summary>
        /// <param name="rateSearchParam1">比較するSalesRateSearchParamクラスのインスタンス</param>
        /// <param name="rateSearchParam2">比較するSalesRateSearchParamクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesRateSearchParamクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SalesRateSearchParam rateSearchParam1, SalesRateSearchParam rateSearchParam2)
        {
            ArrayList resList = new ArrayList();
            if (rateSearchParam1.EnterpriseCode != rateSearchParam2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (rateSearchParam1.SectionCode != rateSearchParam2.SectionCode) resList.Add("SectionCode");
            if (rateSearchParam1.BLGoodsCode != rateSearchParam2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (rateSearchParam1.GoodsMakerCd != rateSearchParam2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (rateSearchParam1.CustRateGrpCode != rateSearchParam2.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (rateSearchParam1.EnterpriseName != rateSearchParam2.EnterpriseName) resList.Add("EnterpriseName");
            if (rateSearchParam1.PrmSectionCode != rateSearchParam2.PrmSectionCode) resList.Add("PrmSectionCode");

            return resList;
        }
    }
}
