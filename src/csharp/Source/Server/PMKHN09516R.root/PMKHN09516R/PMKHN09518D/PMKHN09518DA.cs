//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ＴＢＯ情報出力
// プログラム概要   : ＴＢＯ情報出力
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11270029-00  作成担当 : 黄亜光
// 作 成 日 : 2016/05/20   修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TBODataExportCond
    /// <summary>
    ///                      ＴＢＯ情報出力条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   ＴＢＯ情報出力条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2016/05/20</br>
    /// <br>Genarated Date   :   2016/05/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TBODataExportCond
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>商品カテゴリ</summary>
        /// <remarks>1:タイヤ 2:バッテリー 3:オイル</remarks>
        private int _categoryID;

        /// <summary>品番</summary>
        private string _goodsNo = "";

        /// <summary>メーカーコード(Start)</summary>
        private Int32 _goodsMakerCd_ST;

        /// <summary>メーカーコード(End)</summary>
        private Int32 _goodsMakerCd_ED;

        /// <summary>価格適用日</summary>
        private Int32 _priceStartDate;

        /// <summary>拠点コード</summary>
        private string _sectionCodeRF = "";

        /// <summary>商品中分類コード</summary>
        private ArrayList _goodsMGroup;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

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

        /// public propaty name  :  CategoryID
        /// <summary>商品カテゴリプロパティ</summary>
        /// <value>1:タイヤ 2:バッテリー 3:オイル</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品カテゴリプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
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

        /// public propaty name  :  GoodsMakerCd_ST
        /// <summary>メーカーコード(Start)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコード(Start)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd_ST
        {
            get { return _goodsMakerCd_ST; }
            set { _goodsMakerCd_ST = value; }
        }

        /// public propaty name  :  GoodsMakerCd_ED
        /// <summary>メーカーコード(End)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコード(End)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd_ED
        {
            get { return _goodsMakerCd_ED; }
            set { _goodsMakerCd_ED = value; }
        }

        /// public propaty name  :  PriceStartDate
        /// <summary>価格開始日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }

        /// public propaty name  :  SectionCodeRF
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeRF
        {
            get { return _sectionCodeRF; }
            set { _sectionCodeRF = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
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
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// <summary>
        /// ＴＢＯ情報出力条件ワークコンストラクタ
        /// </summary>
        /// <returns>TBODataExportCondクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBODataExportCondクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TBODataExportCond()
        {
        }

        /// <summary>
        /// ＴＢＯ情報出力条件ワークコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="categoryID">商品カテゴリ</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="goodsMakerCd_ST">メーカーコード(Start)</param>
        /// <param name="goodsMakerCd_ED">メーカーコード(End)</param>
        /// <param name="priceStartDate">価格開始日</param>
        /// <param name="sectionCodeRF">拠点コード</param>
        /// <param name="goodsMGroup">商品中分類コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>TBODataExportCondクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBODataExportCondクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TBODataExportCond(string enterpriseCode, int categoryID, string goodsNo, Int32 goodsMakerCd_ST, Int32 goodsMakerCd_ED, Int32 priceStartDate, string sectionCodeRF, ArrayList goodsMGroup, Int32 customerCode)
        {
            this._enterpriseCode = enterpriseCode;
            this._categoryID = categoryID;
            this._goodsNo = goodsNo;
            this._goodsMakerCd_ST = goodsMakerCd_ST;
            this._goodsMakerCd_ED = goodsMakerCd_ED;
            this._priceStartDate = priceStartDate;
            this._sectionCodeRF = sectionCodeRF;
            this._goodsMGroup = goodsMGroup;
            this._customerCode = customerCode;
        }

        /// <summary>
        /// ＴＢＯ情報出力条件ワーク複製処理
        /// </summary>
        /// <returns>TBODataExportCondクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいTBODataExportCondクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TBODataExportCond Clone()
        {
            return new TBODataExportCond(this._enterpriseCode, this._categoryID, this._goodsNo, this._goodsMakerCd_ST, this._goodsMakerCd_ED, this._priceStartDate, this._sectionCodeRF, this._goodsMGroup, this._customerCode);
        }

        /// <summary>
        /// ＴＢＯ情報出力条件ワーク比較処理
        /// </summary>
        /// <param name="target">比較対象のTBODataExportCondクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBODataExportCondクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(TBODataExportCond target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                && (this.CategoryID == target.CategoryID)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsMakerCd_ST == target.GoodsMakerCd_ST)
                 && (this.GoodsMakerCd_ED == target.GoodsMakerCd_ED)
                 && (this.PriceStartDate == target.PriceStartDate)
                 && (this.SectionCodeRF == target.SectionCodeRF)
                 && (this.GoodsMGroup == target.GoodsMGroup)
                 && (this.CustomerCode == target.CustomerCode));
        }

        /// <summary>
        /// ＴＢＯ情報出力条件ワーク比較処理
        /// </summary>
        /// <param name="TBODataExportCond1">
        ///                    比較するTBODataExportCondクラスのインスタンス
        /// </param>
        /// <param name="TBODataExportCond2">比較するTBODataExportCondクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBODataExportCondクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(TBODataExportCond TBODataExportCond1, TBODataExportCond TBODataExportCond2)
        {
            return ((TBODataExportCond1.EnterpriseCode == TBODataExportCond2.EnterpriseCode)
                 && (TBODataExportCond1.CategoryID == TBODataExportCond2.CategoryID)
                 && (TBODataExportCond1.GoodsNo == TBODataExportCond2.GoodsNo)
                 && (TBODataExportCond1.GoodsMakerCd_ST == TBODataExportCond2.GoodsMakerCd_ST)
                 && (TBODataExportCond1.GoodsMakerCd_ED == TBODataExportCond2.GoodsMakerCd_ED)
                 && (TBODataExportCond1.PriceStartDate == TBODataExportCond2.PriceStartDate)
                 && (TBODataExportCond1.SectionCodeRF == TBODataExportCond2.SectionCodeRF)
                 && (TBODataExportCond1.GoodsMGroup == TBODataExportCond2.GoodsMGroup)
                 && (TBODataExportCond1.CustomerCode == TBODataExportCond2.CustomerCode));
        }
        /// <summary>
        /// ＴＢＯ情報出力条件ワーク比較処理
        /// </summary>
        /// <param name="target">比較対象のTBODataExportCondクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBODataExportCondクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(TBODataExportCond target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.CategoryID != target.CategoryID) resList.Add("CategoryID");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsMakerCd_ST != target.GoodsMakerCd_ST) resList.Add("GoodsMakerCd_ST");
            if (this.GoodsMakerCd_ED != target.GoodsMakerCd_ED) resList.Add("GoodsMakerCd_ED");
            if (this.PriceStartDate != target.PriceStartDate) resList.Add("PriceStartDate");
            if (this.SectionCodeRF != target.SectionCodeRF) resList.Add("SectionCodeRF");
            if (this.GoodsMGroup != target.GoodsMGroup) resList.Add("GoodsMGroup");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");

            return resList;
        }

        /// <summary>
        /// ＴＢＯ情報出力条件ワーク比較処理
        /// </summary>
        /// <param name="TBODataExportCond1">比較するTBODataExportCondクラスのインスタンス</param>
        /// <param name="TBODataExportCond2">比較するTBODataExportCondクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBODataExportCondクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(TBODataExportCond TBODataExportCond1, TBODataExportCond TBODataExportCond2)
        {
            ArrayList resList = new ArrayList();
            if (TBODataExportCond1.EnterpriseCode != TBODataExportCond2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (TBODataExportCond1.CategoryID != TBODataExportCond2.CategoryID) resList.Add("CategoryID");
            if (TBODataExportCond1.GoodsNo != TBODataExportCond2.GoodsNo) resList.Add("GoodsNo");
            if (TBODataExportCond1.GoodsMakerCd_ST != TBODataExportCond2.GoodsMakerCd_ST) resList.Add("GoodsMakerCd_ST");
            if (TBODataExportCond1.GoodsMakerCd_ED != TBODataExportCond2.GoodsMakerCd_ED) resList.Add("GoodsMakerCd_ED");
            if (TBODataExportCond1.PriceStartDate != TBODataExportCond2.PriceStartDate) resList.Add("PriceStartDate");
            if (TBODataExportCond1.SectionCodeRF != TBODataExportCond2.SectionCodeRF) resList.Add("SectionCodeRF");
            if (TBODataExportCond1.GoodsMGroup != TBODataExportCond2.GoodsMGroup) resList.Add("GoodsMGroup");
            if (TBODataExportCond1.CustomerCode != TBODataExportCond2.CustomerCode) resList.Add("CustomerCode");

            return resList;
        }
    }
}
