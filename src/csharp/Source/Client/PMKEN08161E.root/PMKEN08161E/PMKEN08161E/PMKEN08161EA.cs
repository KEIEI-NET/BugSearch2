using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   MarketPriceAcqCond
    /// <summary>
    ///                      相場取得条件
    /// </summary>
    /// <remarks>
    /// <br>note             :   相場取得条件ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2010/5/18</br>
    /// <br>Genarated Date   :   2010/06/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class MarketPriceAcqCond
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>アクセスチケット</summary>
        private string _aaccessTicket = "";

        /// <summary>ジェネレーションコード</summary>
        private string _generationCode = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>関連型式</summary>
        /// <remarks>リサイクル系で使用</remarks>
        private string _relevanceModel = "";

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>BL商品コード名称</summary>
        private string _bLGoodsName = "";


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

        /// public propaty name  :  AaccessTicket
        /// <summary>アクセスチケットプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   アクセスチケットプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AaccessTicket
        {
            get { return _aaccessTicket; }
            set { _aaccessTicket = value; }
        }

        /// public propaty name  :  GenerationCode
        /// <summary>ジェネレーションコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ジェネレーションコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GenerationCode
        {
            get { return _generationCode; }
            set { _generationCode = value; }
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

        /// public propaty name  :  RelevanceModel
        /// <summary>関連型式プロパティ</summary>
        /// <value>リサイクル系で使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   関連型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RelevanceModel
        {
            get { return _relevanceModel; }
            set { _relevanceModel = value; }
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

        /// public propaty name  :  BLGoodsName
        /// <summary>BL商品コード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsName
        {
            get { return _bLGoodsName; }
            set { _bLGoodsName = value; }
        }


        /// <summary>
        /// 相場取得条件コンストラクタ
        /// </summary>
        /// <returns>MarketPriceAcqCondクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MarketPriceAcqCondクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MarketPriceAcqCond()
        {
        }

        /// <summary>
        /// 相場取得条件コンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="aaccessTicket">アクセスチケット</param>
        /// <param name="generationCode">ジェネレーションコード</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="relevanceModel">関連型式(リサイクル系で使用)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="bLGoodsName">BL商品コード名称</param>
        /// <returns>MarketPriceAcqCondクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MarketPriceAcqCondクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MarketPriceAcqCond(string enterpriseCode, string sectionCode, string aaccessTicket, string generationCode, Int32 bLGoodsCode, string relevanceModel, string enterpriseName, string bLGoodsName)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._aaccessTicket = aaccessTicket;
            this._generationCode = generationCode;
            this._bLGoodsCode = bLGoodsCode;
            this._relevanceModel = relevanceModel;
            this._enterpriseName = enterpriseName;
            this._bLGoodsName = bLGoodsName;

        }

        /// <summary>
        /// 相場取得条件複製処理
        /// </summary>
        /// <returns>MarketPriceAcqCondクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいMarketPriceAcqCondクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MarketPriceAcqCond Clone()
        {
            return new MarketPriceAcqCond(this._enterpriseCode, this._sectionCode, this._aaccessTicket, this._generationCode, this._bLGoodsCode, this._relevanceModel, this._enterpriseName, this._bLGoodsName);
        }

        /// <summary>
        /// 相場取得条件比較処理
        /// </summary>
        /// <param name="target">比較対象のMarketPriceAcqCondクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MarketPriceAcqCondクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(MarketPriceAcqCond target)
        {
            return ( ( this.EnterpriseCode == target.EnterpriseCode )
                 && ( this.SectionCode == target.SectionCode )
                 && ( this.AaccessTicket == target.AaccessTicket )
                 && ( this.GenerationCode == target.GenerationCode )
                 && ( this.BLGoodsCode == target.BLGoodsCode )
                 && ( this.RelevanceModel == target.RelevanceModel )
                 && ( this.EnterpriseName == target.EnterpriseName )
                 && ( this.BLGoodsName == target.BLGoodsName ) );
        }

        /// <summary>
        /// 相場取得条件比較処理
        /// </summary>
        /// <param name="marketPriceAcqCond1">
        ///                    比較するMarketPriceAcqCondクラスのインスタンス
        /// </param>
        /// <param name="marketPriceAcqCond2">比較するMarketPriceAcqCondクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MarketPriceAcqCondクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(MarketPriceAcqCond marketPriceAcqCond1, MarketPriceAcqCond marketPriceAcqCond2)
        {
            return ( ( marketPriceAcqCond1.EnterpriseCode == marketPriceAcqCond2.EnterpriseCode )
                 && ( marketPriceAcqCond1.SectionCode == marketPriceAcqCond2.SectionCode )
                 && ( marketPriceAcqCond1.AaccessTicket == marketPriceAcqCond2.AaccessTicket )
                 && ( marketPriceAcqCond1.GenerationCode == marketPriceAcqCond2.GenerationCode )
                 && ( marketPriceAcqCond1.BLGoodsCode == marketPriceAcqCond2.BLGoodsCode )
                 && ( marketPriceAcqCond1.RelevanceModel == marketPriceAcqCond2.RelevanceModel )
                 && ( marketPriceAcqCond1.EnterpriseName == marketPriceAcqCond2.EnterpriseName )
                 && ( marketPriceAcqCond1.BLGoodsName == marketPriceAcqCond2.BLGoodsName ) );
        }
        /// <summary>
        /// 相場取得条件比較処理
        /// </summary>
        /// <param name="target">比較対象のMarketPriceAcqCondクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MarketPriceAcqCondクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(MarketPriceAcqCond target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.AaccessTicket != target.AaccessTicket) resList.Add("AaccessTicket");
            if (this.GenerationCode != target.GenerationCode) resList.Add("GenerationCode");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.RelevanceModel != target.RelevanceModel) resList.Add("RelevanceModel");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");

            return resList;
        }

        /// <summary>
        /// 相場取得条件比較処理
        /// </summary>
        /// <param name="marketPriceAcqCond1">比較するMarketPriceAcqCondクラスのインスタンス</param>
        /// <param name="marketPriceAcqCond2">比較するMarketPriceAcqCondクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MarketPriceAcqCondクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(MarketPriceAcqCond marketPriceAcqCond1, MarketPriceAcqCond marketPriceAcqCond2)
        {
            ArrayList resList = new ArrayList();
            if (marketPriceAcqCond1.EnterpriseCode != marketPriceAcqCond2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (marketPriceAcqCond1.SectionCode != marketPriceAcqCond2.SectionCode) resList.Add("SectionCode");
            if (marketPriceAcqCond1.AaccessTicket != marketPriceAcqCond2.AaccessTicket) resList.Add("AaccessTicket");
            if (marketPriceAcqCond1.GenerationCode != marketPriceAcqCond2.GenerationCode) resList.Add("GenerationCode");
            if (marketPriceAcqCond1.BLGoodsCode != marketPriceAcqCond2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (marketPriceAcqCond1.RelevanceModel != marketPriceAcqCond2.RelevanceModel) resList.Add("RelevanceModel");
            if (marketPriceAcqCond1.EnterpriseName != marketPriceAcqCond2.EnterpriseName) resList.Add("EnterpriseName");
            if (marketPriceAcqCond1.BLGoodsName != marketPriceAcqCond2.BLGoodsName) resList.Add("BLGoodsName");

            return resList;
        }
    }
}
