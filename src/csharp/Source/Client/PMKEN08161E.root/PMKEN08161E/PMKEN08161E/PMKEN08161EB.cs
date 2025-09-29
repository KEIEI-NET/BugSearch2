using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   MarketPriceInfo
    /// <summary>
    ///                      相場価格情報
    /// </summary>
    /// <remarks>
    /// <br>note             :   相場価格情報ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2010/5/18</br>
    /// <br>Genarated Date   :   2010/06/17  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class MarketPriceInfo
    {
        /// <summary>相場価格地域コード</summary>
        private Int32 _marketPriceAreaCd;

        /// <summary>相場価格種別コード</summary>
        private Int32 _marketPriceKindCd;

        /// <summary>相場価格品質コード</summary>
        private Int32 _marketPriceQualityCd;

        /// <summary>流通相場価格</summary>
        /// <remarks>相場サービスで取得した流通相場価格</remarks>
        private Int64 _dstrMarketPrice;

        /// <summary>相場価格</summary>
        /// <remarks>算出後の相場価格</remarks>
        private Int64 _marketPrice;

        /// <summary>相場価格地域名称</summary>
        private string _marketPriceAreaNm = "";

        /// <summary>相場価格種別名称</summary>
        private string _marketPriceKindNm = "";

        /// <summary>相場価格品質名称</summary>
        private string _marketPriceQualityNm = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>商品名称カナ</summary>
        private string _goodsNameKana = "";

        /// <summary>BL商品コード名称</summary>
        private string _bLGoodsName = "";


        /// public propaty name  :  MarketPriceAreaCd
        /// <summary>相場価格地域コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相場価格地域コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MarketPriceAreaCd
        {
            get { return _marketPriceAreaCd; }
            set { _marketPriceAreaCd = value; }
        }

        /// public propaty name  :  MarketPriceKindCd
        /// <summary>相場価格種別コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相場価格種別コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MarketPriceKindCd
        {
            get { return _marketPriceKindCd; }
            set { _marketPriceKindCd = value; }
        }

        /// public propaty name  :  MarketPriceQualityCd
        /// <summary>相場価格品質コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相場価格品質コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MarketPriceQualityCd
        {
            get { return _marketPriceQualityCd; }
            set { _marketPriceQualityCd = value; }
        }

        /// public propaty name  :  DstrMarketPrice
        /// <summary>流通相場価格プロパティ</summary>
        /// <value>相場サービスで取得した流通相場価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   流通相場価格プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DstrMarketPrice
        {
            get { return _dstrMarketPrice; }
            set { _dstrMarketPrice = value; }
        }

        /// public propaty name  :  MarketPrice
        /// <summary>相場価格プロパティ</summary>
        /// <value>算出後の相場価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相場価格プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MarketPrice
        {
            get { return _marketPrice; }
            set { _marketPrice = value; }
        }

        /// public propaty name  :  MarketPriceAreaNm
        /// <summary>相場価格地域名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相場価格地域名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MarketPriceAreaNm
        {
            get { return _marketPriceAreaNm; }
            set { _marketPriceAreaNm = value; }
        }

        /// public propaty name  :  MarketPriceKindNm
        /// <summary>相場価格種別名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相場価格種別名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MarketPriceKindNm
        {
            get { return _marketPriceKindNm; }
            set { _marketPriceKindNm = value; }
        }

        /// public propaty name  :  MarketPriceQualityNm
        /// <summary>相場価格品質名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相場価格品質名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MarketPriceQualityNm
        {
            get { return _marketPriceQualityNm; }
            set { _marketPriceQualityNm = value; }
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

        /// public propaty name  :  GoodsNameKana
        /// <summary>商品名称カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
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
        /// 相場価格情報コンストラクタ
        /// </summary>
        /// <returns>MarketPriceInfoクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MarketPriceInfoクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MarketPriceInfo()
        {
        }

        /// <summary>
        /// 相場価格情報コンストラクタ
        /// </summary>
        /// <param name="marketPriceAreaCd">相場価格地域コード</param>
        /// <param name="marketPriceKindCd">相場価格種別コード</param>
        /// <param name="marketPriceQualityCd">相場価格品質コード</param>
        /// <param name="dstrMarketPrice">流通相場価格(相場サービスで取得した流通相場価格)</param>
        /// <param name="marketPrice">相場価格(算出後の相場価格)</param>
        /// <param name="marketPriceAreaNm">相場価格地域名称</param>
        /// <param name="marketPriceKindNm">相場価格種別名称</param>
        /// <param name="marketPriceQualityNm">相場価格品質名称</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="goodsNameKana">商品名称カナ</param>
        /// <param name="bLGoodsName">BL商品コード名称</param>
        /// <returns>MarketPriceInfoクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MarketPriceInfoクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MarketPriceInfo( Int32 marketPriceAreaCd, Int32 marketPriceKindCd, Int32 marketPriceQualityCd, Int64 dstrMarketPrice, Int64 marketPrice, string marketPriceAreaNm, string marketPriceKindNm, string marketPriceQualityNm, Int32 bLGoodsCode, string goodsNameKana, string bLGoodsName )
        {
            this._marketPriceAreaCd = marketPriceAreaCd;
            this._marketPriceKindCd = marketPriceKindCd;
            this._marketPriceQualityCd = marketPriceQualityCd;
            this._dstrMarketPrice = dstrMarketPrice;
            this._marketPrice = marketPrice;
            this._marketPriceAreaNm = marketPriceAreaNm;
            this._marketPriceKindNm = marketPriceKindNm;
            this._marketPriceQualityNm = marketPriceQualityNm;
            this._bLGoodsCode = bLGoodsCode;
            this._goodsNameKana = goodsNameKana;
            this._bLGoodsName = bLGoodsName;

        }

        /// <summary>
        /// 相場価格情報複製処理
        /// </summary>
        /// <returns>MarketPriceInfoクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいMarketPriceInfoクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MarketPriceInfo Clone()
        {
            return new MarketPriceInfo( this._marketPriceAreaCd, this._marketPriceKindCd, this._marketPriceQualityCd, this._dstrMarketPrice, this._marketPrice, this._marketPriceAreaNm, this._marketPriceKindNm, this._marketPriceQualityNm, this._bLGoodsCode, this._goodsNameKana, this._bLGoodsName );
        }

        /// <summary>
        /// 相場価格情報比較処理
        /// </summary>
        /// <param name="target">比較対象のMarketPriceInfoクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MarketPriceInfoクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals( MarketPriceInfo target )
        {
            return ((this.MarketPriceAreaCd == target.MarketPriceAreaCd)
                 && (this.MarketPriceKindCd == target.MarketPriceKindCd)
                 && (this.MarketPriceQualityCd == target.MarketPriceQualityCd)
                 && (this.DstrMarketPrice == target.DstrMarketPrice)
                 && (this.MarketPrice == target.MarketPrice)
                 && (this.MarketPriceAreaNm == target.MarketPriceAreaNm)
                 && (this.MarketPriceKindNm == target.MarketPriceKindNm)
                 && (this.MarketPriceQualityNm == target.MarketPriceQualityNm)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.GoodsNameKana == target.GoodsNameKana)
                 && (this.BLGoodsName == target.BLGoodsName));
        }

        /// <summary>
        /// 相場価格情報比較処理
        /// </summary>
        /// <param name="marketPriceInfo1">
        ///                    比較するMarketPriceInfoクラスのインスタンス
        /// </param>
        /// <param name="marketPriceInfo2">比較するMarketPriceInfoクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MarketPriceInfoクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals( MarketPriceInfo marketPriceInfo1, MarketPriceInfo marketPriceInfo2 )
        {
            return ((marketPriceInfo1.MarketPriceAreaCd == marketPriceInfo2.MarketPriceAreaCd)
                 && (marketPriceInfo1.MarketPriceKindCd == marketPriceInfo2.MarketPriceKindCd)
                 && (marketPriceInfo1.MarketPriceQualityCd == marketPriceInfo2.MarketPriceQualityCd)
                 && (marketPriceInfo1.DstrMarketPrice == marketPriceInfo2.DstrMarketPrice)
                 && (marketPriceInfo1.MarketPrice == marketPriceInfo2.MarketPrice)
                 && (marketPriceInfo1.MarketPriceAreaNm == marketPriceInfo2.MarketPriceAreaNm)
                 && (marketPriceInfo1.MarketPriceKindNm == marketPriceInfo2.MarketPriceKindNm)
                 && (marketPriceInfo1.MarketPriceQualityNm == marketPriceInfo2.MarketPriceQualityNm)
                 && (marketPriceInfo1.BLGoodsCode == marketPriceInfo2.BLGoodsCode)
                 && (marketPriceInfo1.GoodsNameKana == marketPriceInfo2.GoodsNameKana)
                 && (marketPriceInfo1.BLGoodsName == marketPriceInfo2.BLGoodsName));
        }
        /// <summary>
        /// 相場価格情報比較処理
        /// </summary>
        /// <param name="target">比較対象のMarketPriceInfoクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MarketPriceInfoクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare( MarketPriceInfo target )
        {
            ArrayList resList = new ArrayList();
            if ( this.MarketPriceAreaCd != target.MarketPriceAreaCd ) resList.Add( "MarketPriceAreaCd" );
            if ( this.MarketPriceKindCd != target.MarketPriceKindCd ) resList.Add( "MarketPriceKindCd" );
            if ( this.MarketPriceQualityCd != target.MarketPriceQualityCd ) resList.Add( "MarketPriceQualityCd" );
            if ( this.DstrMarketPrice != target.DstrMarketPrice ) resList.Add( "DstrMarketPrice" );
            if ( this.MarketPrice != target.MarketPrice ) resList.Add( "MarketPrice" );
            if ( this.MarketPriceAreaNm != target.MarketPriceAreaNm ) resList.Add( "MarketPriceAreaNm" );
            if ( this.MarketPriceKindNm != target.MarketPriceKindNm ) resList.Add( "MarketPriceKindNm" );
            if ( this.MarketPriceQualityNm != target.MarketPriceQualityNm ) resList.Add( "MarketPriceQualityNm" );
            if ( this.BLGoodsCode != target.BLGoodsCode ) resList.Add( "BLGoodsCode" );
            if ( this.GoodsNameKana != target.GoodsNameKana ) resList.Add( "GoodsNameKana" );
            if ( this.BLGoodsName != target.BLGoodsName ) resList.Add( "BLGoodsName" );

            return resList;
        }

        /// <summary>
        /// 相場価格情報比較処理
        /// </summary>
        /// <param name="marketPriceInfo1">比較するMarketPriceInfoクラスのインスタンス</param>
        /// <param name="marketPriceInfo2">比較するMarketPriceInfoクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MarketPriceInfoクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare( MarketPriceInfo marketPriceInfo1, MarketPriceInfo marketPriceInfo2 )
        {
            ArrayList resList = new ArrayList();
            if ( marketPriceInfo1.MarketPriceAreaCd != marketPriceInfo2.MarketPriceAreaCd ) resList.Add( "MarketPriceAreaCd" );
            if ( marketPriceInfo1.MarketPriceKindCd != marketPriceInfo2.MarketPriceKindCd ) resList.Add( "MarketPriceKindCd" );
            if ( marketPriceInfo1.MarketPriceQualityCd != marketPriceInfo2.MarketPriceQualityCd ) resList.Add( "MarketPriceQualityCd" );
            if ( marketPriceInfo1.DstrMarketPrice != marketPriceInfo2.DstrMarketPrice ) resList.Add( "DstrMarketPrice" );
            if ( marketPriceInfo1.MarketPrice != marketPriceInfo2.MarketPrice ) resList.Add( "MarketPrice" );
            if ( marketPriceInfo1.MarketPriceAreaNm != marketPriceInfo2.MarketPriceAreaNm ) resList.Add( "MarketPriceAreaNm" );
            if ( marketPriceInfo1.MarketPriceKindNm != marketPriceInfo2.MarketPriceKindNm ) resList.Add( "MarketPriceKindNm" );
            if ( marketPriceInfo1.MarketPriceQualityNm != marketPriceInfo2.MarketPriceQualityNm ) resList.Add( "MarketPriceQualityNm" );
            if ( marketPriceInfo1.BLGoodsCode != marketPriceInfo2.BLGoodsCode ) resList.Add( "BLGoodsCode" );
            if ( marketPriceInfo1.GoodsNameKana != marketPriceInfo2.GoodsNameKana ) resList.Add( "GoodsNameKana" );
            if ( marketPriceInfo1.BLGoodsName != marketPriceInfo2.BLGoodsName ) resList.Add( "BLGoodsName" );

            return resList;
        }
    }
}
