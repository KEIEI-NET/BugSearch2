//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 優良部品詳細マスタDBリモートオブジェクト
// プログラム概要   : 優良部品詳細マスタの取得を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370090-00 作成担当 : 櫻井　亮太
// 作 成 日  2017/10/17  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PrmPrtDtInfWork
    /// <summary>
    ///                      優良部品詳細情報取得結果ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   優良部品詳細情報取得結果ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2017/10/23</br>
    /// <br>Genarated Date   :   2017/10/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PrmPrtDtInfWork
    {
        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _offerDate;

        /// <summary>部品メーカーコード</summary>
        /// <remarks>自動車ﾒｰｶｰ(1～899:提供分, 900～998:ﾕｰｻﾞｰ登録),優良ﾒｰｶｰ(1000～8999:提供,9000～9999:ﾕｰｻﾞｰ登録)</remarks>
        private Int32 _partsMakerCode;

        /// <summary>優良品番(－付き品番)</summary>
        /// <remarks>ハイフン付き</remarks>
        private string _primePartsNoWithH = "";

        /// <summary>商品詳細説明(B向け)</summary>
        /// <remarks>全角文字のみ</remarks>
        private string _goodsDetailDescToB = "";

        /// <summary>商品詳細説明(C向け)</summary>
        /// <remarks>全角文字のみ</remarks>
        private string _goodsDetailDescToC = "";

        /// <summary>優良部品メーカーURL</summary>
        /// <remarks>部品メーカーのホームページ等のURLが入る</remarks>
        private string _prmPartsMakerUrl = "";

        /// <summary>優良部品カタログURI</summary>
        /// <remarks>優良部品のカタログページ等のURIが入る</remarks>
        private string _prmPartsCatalogUri = "";

        /// <summary>優良部品説明動画URI</summary>
        /// <remarks>優良部品の説明動画等のURIが入る</remarks>
        private string _prmPtDescMovieUri = "";

        /// <summary>商品寸法・長さ</summary>
        /// <remarks>999999.99</remarks>
        private Double _goodsSizeLength;

        /// <summary>商品寸法・幅</summary>
        /// <remarks>999999.99</remarks>
        private Double _goodsSizeWidth;

        /// <summary>商品寸法・高さ</summary>
        /// <remarks>999999.99</remarks>
        private Double _goodsSizeHeight;

        /// <summary>商品寸法・単位</summary>
        /// <remarks>mm, cm, m</remarks>
        private string _goodsSizeUnit = "";

        /// <summary>商品箱寸法・長さ</summary>
        /// <remarks>999999.99</remarks>
        private Double _goodsPkgBoxLength;

        /// <summary>商品箱寸法・幅</summary>
        /// <remarks>999999.99</remarks>
        private Double _goodsPkgBoxWidth;

        /// <summary>商品箱寸法・高さ</summary>
        /// <remarks>999999.99</remarks>
        private Double _goodsPkgBoxHeight;

        /// <summary>商品箱寸法・単位</summary>
        /// <remarks>mm, cm, m</remarks>
        private string _goodsPkgBoxUnit = "";

        /// <summary>商品内容量</summary>
        /// <remarks>999999.99</remarks>
        private Double _goodsVolume;

        /// <summary>商品内容量単位</summary>
        /// <remarks>ml, L, cc</remarks>
        private string _goodsVolumeUnit = "";

        /// <summary>商品重量</summary>
        /// <remarks>999999.99</remarks>
        private Double _goodsWeight;

        /// <summary>商品重量単位</summary>
        /// <remarks>g, kg, t</remarks>
        private string _goodsWeightUnit = "";

        /// <summary>商品詳細画像有無区分</summary>
        /// <remarks>0:無し,1:有り</remarks>
        private Int16 _goodsDtlImgExtDiv;

        /// <summary>商品サムネイル画像有無区分</summary>
        /// <remarks>0:無し,1:有り</remarks>
        private Int16 _goodsTmbImgExtDiv;

        /// <summary>商品画像1詳細ファイル名</summary>
        private string _goodsDtlImgFlName1 = "";

        /// <summary>商品画像1サムネイルファイル名</summary>
        private string _goodsTmbImgFlName1 = "";

        /// <summary>商品画像2詳細ファイル名</summary>
        private string _goodsDtlImgFlName2 = "";

        /// <summary>商品画像2サムネイルファイル名</summary>
        private string _goodsTmbImgFlName2 = "";

        /// <summary>商品画像3詳細ファイル名</summary>
        private string _goodsDtlImgFlName3 = "";

        /// <summary>商品画像3サムネイルファイル名</summary>
        private string _goodsTmbImgFlName3 = "";

        /// <summary>商品画像4詳細ファイル名</summary>
        private string _goodsDtlImgFlName4 = "";

        /// <summary>商品画像4サムネイルファイル名</summary>
        private string _goodsTmbImgFlName4 = "";

        /// <summary>商品画像5詳細ファイル名</summary>
        private string _goodsDtlImgFlName5 = "";

        /// <summary>商品画像5サムネイルファイル名</summary>
        private string _goodsTmbImgFlName5 = "";

        /// <summary>商品画像6詳細ファイル名</summary>
        private string _goodsDtlImgFlName6 = "";

        /// <summary>商品画像6サムネイルファイル名</summary>
        private string _goodsTmbImgFlName6 = "";

        /// <summary>商品画像7詳細ファイル名</summary>
        private string _goodsDtlImgFlName7 = "";

        /// <summary>商品画像7サムネイルファイル名</summary>
        private string _goodsTmbImgFlName7 = "";

        /// <summary>商品画像8詳細ファイル名</summary>
        private string _goodsDtlImgFlName8 = "";

        /// <summary>商品画像8サムネイルファイル名</summary>
        private string _goodsTmbImgFlName8 = "";

        /// <summary>商品画像9詳細ファイル名</summary>
        private string _goodsDtlImgFlName9 = "";

        /// <summary>商品画像9サムネイルファイル名</summary>
        private string _goodsTmbImgFlName9 = "";

        /// <summary>自動車部品廃番区分</summary>
        /// <remarks>0:生産中,1:廃番予定,2:廃番</remarks>
        private Int16 _carPrtsDiscontDiv;

        /// <summary>自動車部品廃番日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _carPrtsDiscontDate;

        /// <summary>代替優良品番(－付き品番)</summary>
        private string _substPrmPrtsWithHyph = "";

        /// <summary>部品メーカー名称（全角）</summary>
        private string _partsMakerFullName = "";

        /// <summary>優良品名</summary>
        private string _primePartsName = "";

        /// <summary>優良部品規格・特記事項</summary>
        private string _primePartsSpecialNote = "";


        /// public propaty name  :  OfferDate
        /// <summary>提供日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  PartsMakerCode
        /// <summary>部品メーカーコードプロパティ</summary>
        /// <value>自動車ﾒｰｶｰ(1～899:提供分, 900～998:ﾕｰｻﾞｰ登録),優良ﾒｰｶｰ(1000～8999:提供,9000～9999:ﾕｰｻﾞｰ登録)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsMakerCode
        {
            get { return _partsMakerCode; }
            set { _partsMakerCode = value; }
        }

        /// public propaty name  :  PrimePartsNoWithH
        /// <summary>優良品番(－付き品番)プロパティ</summary>
        /// <value>ハイフン付き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良品番(－付き品番)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrimePartsNoWithH
        {
            get { return _primePartsNoWithH; }
            set { _primePartsNoWithH = value; }
        }

        /// public propaty name  :  GoodsDetailDescToB
        /// <summary>商品詳細説明(B向け)プロパティ</summary>
        /// <value>全角文字のみ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品詳細説明(B向け)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsDetailDescToB
        {
            get { return _goodsDetailDescToB; }
            set { _goodsDetailDescToB = value; }
        }

        /// public propaty name  :  GoodsDetailDescToC
        /// <summary>商品詳細説明(C向け)プロパティ</summary>
        /// <value>全角文字のみ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品詳細説明(C向け)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsDetailDescToC
        {
            get { return _goodsDetailDescToC; }
            set { _goodsDetailDescToC = value; }
        }

        /// public propaty name  :  PrmPartsMakerUrl
        /// <summary>優良部品メーカーURLプロパティ</summary>
        /// <value>部品メーカーのホームページ等のURLが入る</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良部品メーカーURLプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrmPartsMakerUrl
        {
            get { return _prmPartsMakerUrl; }
            set { _prmPartsMakerUrl = value; }
        }

        /// public propaty name  :  PrmPartsCatalogUri
        /// <summary>優良部品カタログURIプロパティ</summary>
        /// <value>優良部品のカタログページ等のURIが入る</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良部品カタログURIプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrmPartsCatalogUri
        {
            get { return _prmPartsCatalogUri; }
            set { _prmPartsCatalogUri = value; }
        }

        /// public propaty name  :  PrmPtDescMovieUri
        /// <summary>優良部品説明動画URIプロパティ</summary>
        /// <value>優良部品の説明動画等のURIが入る</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良部品説明動画URIプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrmPtDescMovieUri
        {
            get { return _prmPtDescMovieUri; }
            set { _prmPtDescMovieUri = value; }
        }

        /// public propaty name  :  GoodsSizeLength
        /// <summary>商品寸法・長さプロパティ</summary>
        /// <value>999999.99</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品寸法・長さプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double GoodsSizeLength
        {
            get { return _goodsSizeLength; }
            set { _goodsSizeLength = value; }
        }

        /// public propaty name  :  GoodsSizeWidth
        /// <summary>商品寸法・幅プロパティ</summary>
        /// <value>999999.99</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品寸法・幅プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double GoodsSizeWidth
        {
            get { return _goodsSizeWidth; }
            set { _goodsSizeWidth = value; }
        }

        /// public propaty name  :  GoodsSizeHeight
        /// <summary>商品寸法・高さプロパティ</summary>
        /// <value>999999.99</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品寸法・高さプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double GoodsSizeHeight
        {
            get { return _goodsSizeHeight; }
            set { _goodsSizeHeight = value; }
        }

        /// public propaty name  :  GoodsSizeUnit
        /// <summary>商品寸法・単位プロパティ</summary>
        /// <value>mm, cm, m</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品寸法・単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsSizeUnit
        {
            get { return _goodsSizeUnit; }
            set { _goodsSizeUnit = value; }
        }

        /// public propaty name  :  GoodsPkgBoxLength
        /// <summary>商品箱寸法・長さプロパティ</summary>
        /// <value>999999.99</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品箱寸法・長さプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double GoodsPkgBoxLength
        {
            get { return _goodsPkgBoxLength; }
            set { _goodsPkgBoxLength = value; }
        }

        /// public propaty name  :  GoodsPkgBoxWidth
        /// <summary>商品箱寸法・幅プロパティ</summary>
        /// <value>999999.99</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品箱寸法・幅プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double GoodsPkgBoxWidth
        {
            get { return _goodsPkgBoxWidth; }
            set { _goodsPkgBoxWidth = value; }
        }

        /// public propaty name  :  GoodsPkgBoxHeight
        /// <summary>商品箱寸法・高さプロパティ</summary>
        /// <value>999999.99</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品箱寸法・高さプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double GoodsPkgBoxHeight
        {
            get { return _goodsPkgBoxHeight; }
            set { _goodsPkgBoxHeight = value; }
        }

        /// public propaty name  :  GoodsPkgBoxUnit
        /// <summary>商品箱寸法・単位プロパティ</summary>
        /// <value>mm, cm, m</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品箱寸法・単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsPkgBoxUnit
        {
            get { return _goodsPkgBoxUnit; }
            set { _goodsPkgBoxUnit = value; }
        }

        /// public propaty name  :  GoodsVolume
        /// <summary>商品内容量プロパティ</summary>
        /// <value>999999.99</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品内容量プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double GoodsVolume
        {
            get { return _goodsVolume; }
            set { _goodsVolume = value; }
        }

        /// public propaty name  :  GoodsVolumeUnit
        /// <summary>商品内容量単位プロパティ</summary>
        /// <value>ml, L, cc</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品内容量単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsVolumeUnit
        {
            get { return _goodsVolumeUnit; }
            set { _goodsVolumeUnit = value; }
        }

        /// public propaty name  :  GoodsWeight
        /// <summary>商品重量プロパティ</summary>
        /// <value>999999.99</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品重量プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double GoodsWeight
        {
            get { return _goodsWeight; }
            set { _goodsWeight = value; }
        }

        /// public propaty name  :  GoodsWeightUnit
        /// <summary>商品重量単位プロパティ</summary>
        /// <value>g, kg, t</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品重量単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsWeightUnit
        {
            get { return _goodsWeightUnit; }
            set { _goodsWeightUnit = value; }
        }

        /// public propaty name  :  GoodsDtlImgExtDiv
        /// <summary>商品詳細画像有無区分プロパティ</summary>
        /// <value>0:無し,1:有り</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品詳細画像有無区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 GoodsDtlImgExtDiv
        {
            get { return _goodsDtlImgExtDiv; }
            set { _goodsDtlImgExtDiv = value; }
        }

        /// public propaty name  :  GoodsTmbImgExtDiv
        /// <summary>商品サムネイル画像有無区分プロパティ</summary>
        /// <value>0:無し,1:有り</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品サムネイル画像有無区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 GoodsTmbImgExtDiv
        {
            get { return _goodsTmbImgExtDiv; }
            set { _goodsTmbImgExtDiv = value; }
        }

        /// public propaty name  :  GoodsDtlImgFlName1
        /// <summary>商品画像1詳細ファイル名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品画像1詳細ファイル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsDtlImgFlName1
        {
            get { return _goodsDtlImgFlName1; }
            set { _goodsDtlImgFlName1 = value; }
        }

        /// public propaty name  :  GoodsTmbImgFlName1
        /// <summary>商品画像1サムネイルファイル名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品画像1サムネイルファイル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsTmbImgFlName1
        {
            get { return _goodsTmbImgFlName1; }
            set { _goodsTmbImgFlName1 = value; }
        }

        /// public propaty name  :  GoodsDtlImgFlName2
        /// <summary>商品画像2詳細ファイル名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品画像2詳細ファイル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsDtlImgFlName2
        {
            get { return _goodsDtlImgFlName2; }
            set { _goodsDtlImgFlName2 = value; }
        }

        /// public propaty name  :  GoodsTmbImgFlName2
        /// <summary>商品画像2サムネイルファイル名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品画像2サムネイルファイル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsTmbImgFlName2
        {
            get { return _goodsTmbImgFlName2; }
            set { _goodsTmbImgFlName2 = value; }
        }

        /// public propaty name  :  GoodsDtlImgFlName3
        /// <summary>商品画像3詳細ファイル名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品画像3詳細ファイル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsDtlImgFlName3
        {
            get { return _goodsDtlImgFlName3; }
            set { _goodsDtlImgFlName3 = value; }
        }

        /// public propaty name  :  GoodsTmbImgFlName3
        /// <summary>商品画像3サムネイルファイル名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品画像3サムネイルファイル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsTmbImgFlName3
        {
            get { return _goodsTmbImgFlName3; }
            set { _goodsTmbImgFlName3 = value; }
        }

        /// public propaty name  :  GoodsDtlImgFlName4
        /// <summary>商品画像4詳細ファイル名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品画像4詳細ファイル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsDtlImgFlName4
        {
            get { return _goodsDtlImgFlName4; }
            set { _goodsDtlImgFlName4 = value; }
        }

        /// public propaty name  :  GoodsTmbImgFlName4
        /// <summary>商品画像4サムネイルファイル名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品画像4サムネイルファイル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsTmbImgFlName4
        {
            get { return _goodsTmbImgFlName4; }
            set { _goodsTmbImgFlName4 = value; }
        }

        /// public propaty name  :  GoodsDtlImgFlName5
        /// <summary>商品画像5詳細ファイル名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品画像5詳細ファイル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsDtlImgFlName5
        {
            get { return _goodsDtlImgFlName5; }
            set { _goodsDtlImgFlName5 = value; }
        }

        /// public propaty name  :  GoodsTmbImgFlName5
        /// <summary>商品画像5サムネイルファイル名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品画像5サムネイルファイル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsTmbImgFlName5
        {
            get { return _goodsTmbImgFlName5; }
            set { _goodsTmbImgFlName5 = value; }
        }

        /// public propaty name  :  GoodsDtlImgFlName6
        /// <summary>商品画像6詳細ファイル名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品画像6詳細ファイル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsDtlImgFlName6
        {
            get { return _goodsDtlImgFlName6; }
            set { _goodsDtlImgFlName6 = value; }
        }

        /// public propaty name  :  GoodsTmbImgFlName6
        /// <summary>商品画像6サムネイルファイル名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品画像6サムネイルファイル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsTmbImgFlName6
        {
            get { return _goodsTmbImgFlName6; }
            set { _goodsTmbImgFlName6 = value; }
        }

        /// public propaty name  :  GoodsDtlImgFlName7
        /// <summary>商品画像7詳細ファイル名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品画像7詳細ファイル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsDtlImgFlName7
        {
            get { return _goodsDtlImgFlName7; }
            set { _goodsDtlImgFlName7 = value; }
        }

        /// public propaty name  :  GoodsTmbImgFlName7
        /// <summary>商品画像7サムネイルファイル名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品画像7サムネイルファイル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsTmbImgFlName7
        {
            get { return _goodsTmbImgFlName7; }
            set { _goodsTmbImgFlName7 = value; }
        }

        /// public propaty name  :  GoodsDtlImgFlName8
        /// <summary>商品画像8詳細ファイル名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品画像8詳細ファイル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsDtlImgFlName8
        {
            get { return _goodsDtlImgFlName8; }
            set { _goodsDtlImgFlName8 = value; }
        }

        /// public propaty name  :  GoodsTmbImgFlName8
        /// <summary>商品画像8サムネイルファイル名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品画像8サムネイルファイル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsTmbImgFlName8
        {
            get { return _goodsTmbImgFlName8; }
            set { _goodsTmbImgFlName8 = value; }
        }

        /// public propaty name  :  GoodsDtlImgFlName9
        /// <summary>商品画像9詳細ファイル名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品画像9詳細ファイル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsDtlImgFlName9
        {
            get { return _goodsDtlImgFlName9; }
            set { _goodsDtlImgFlName9 = value; }
        }

        /// public propaty name  :  GoodsTmbImgFlName9
        /// <summary>商品画像9サムネイルファイル名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品画像9サムネイルファイル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsTmbImgFlName9
        {
            get { return _goodsTmbImgFlName9; }
            set { _goodsTmbImgFlName9 = value; }
        }

        /// public propaty name  :  CarPrtsDiscontDiv
        /// <summary>自動車部品廃番区分プロパティ</summary>
        /// <value>0:生産中,1:廃番予定,2:廃番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動車部品廃番区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 CarPrtsDiscontDiv
        {
            get { return _carPrtsDiscontDiv; }
            set { _carPrtsDiscontDiv = value; }
        }

        /// public propaty name  :  CarPrtsDiscontDate
        /// <summary>自動車部品廃番日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動車部品廃番日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarPrtsDiscontDate
        {
            get { return _carPrtsDiscontDate; }
            set { _carPrtsDiscontDate = value; }
        }

        /// public propaty name  :  SubstPrmPrtsWithHyph
        /// <summary>代替優良品番(－付き品番)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   代替優良品番(－付き品番)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SubstPrmPrtsWithHyph
        {
            get { return _substPrmPrtsWithHyph; }
            set { _substPrmPrtsWithHyph = value; }
        }

        /// public propaty name  :  PartsMakerFullName
        /// <summary>部品メーカー名称（全角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品メーカー名称（全角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartsMakerFullName
        {
            get { return _partsMakerFullName; }
            set { _partsMakerFullName = value; }
        }

        /// public propaty name  :  PrimePartsName
        /// <summary>優良品名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良品名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrimePartsName
        {
            get { return _primePartsName; }
            set { _primePartsName = value; }
        }

        /// public propaty name  :  PrimePartsSpecialNote
        /// <summary>優良部品規格・特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良部品規格・特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrimePartsSpecialNote
        {
            get { return _primePartsSpecialNote; }
            set { _primePartsSpecialNote = value; }
        }


        /// <summary>
        /// 優良部品詳細情報取得結果ワークコンストラクタ
        /// </summary>
        /// <returns>PrmPrtDtInfWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmPrtDtInfWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PrmPrtDtInfWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PrmPrtDtInfWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PrmPrtDtInfWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PrmPrtDtInfWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmPrtDtInfWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PrmPrtDtInfWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PrmPrtDtInfWork || graph is ArrayList || graph is PrmPrtDtInfWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PrmPrtDtInfWork).FullName));

            if (graph != null && graph is PrmPrtDtInfWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PrmPrtDtInfWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PrmPrtDtInfWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PrmPrtDtInfWork[])graph).Length;
            }
            else if (graph is PrmPrtDtInfWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //提供日付
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //部品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsMakerCode
            //優良品番(－付き品番)
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsNoWithH
            //商品詳細説明(B向け)
            serInfo.MemberInfo.Add(typeof(string)); //GoodsDetailDescToB
            //商品詳細説明(C向け)
            serInfo.MemberInfo.Add(typeof(string)); //GoodsDetailDescToC
            //優良部品メーカーURL
            serInfo.MemberInfo.Add(typeof(string)); //PrmPartsMakerUrl
            //優良部品カタログURI
            serInfo.MemberInfo.Add(typeof(string)); //PrmPartsCatalogUri
            //優良部品説明動画URI
            serInfo.MemberInfo.Add(typeof(string)); //PrmPtDescMovieUri
            //商品寸法・長さ
            serInfo.MemberInfo.Add(typeof(Double)); //GoodsSizeLength
            //商品寸法・幅
            serInfo.MemberInfo.Add(typeof(Double)); //GoodsSizeWidth
            //商品寸法・高さ
            serInfo.MemberInfo.Add(typeof(Double)); //GoodsSizeHeight
            //商品寸法・単位
            serInfo.MemberInfo.Add(typeof(string)); //GoodsSizeUnit
            //商品箱寸法・長さ
            serInfo.MemberInfo.Add(typeof(Double)); //GoodsPkgBoxLength
            //商品箱寸法・幅
            serInfo.MemberInfo.Add(typeof(Double)); //GoodsPkgBoxWidth
            //商品箱寸法・高さ
            serInfo.MemberInfo.Add(typeof(Double)); //GoodsPkgBoxHeight
            //商品箱寸法・単位
            serInfo.MemberInfo.Add(typeof(string)); //GoodsPkgBoxUnit
            //商品内容量
            serInfo.MemberInfo.Add(typeof(Double)); //GoodsVolume
            //商品内容量単位
            serInfo.MemberInfo.Add(typeof(string)); //GoodsVolumeUnit
            //商品重量
            serInfo.MemberInfo.Add(typeof(Double)); //GoodsWeight
            //商品重量単位
            serInfo.MemberInfo.Add(typeof(string)); //GoodsWeightUnit
            //商品詳細画像有無区分
            serInfo.MemberInfo.Add(typeof(Int16)); //GoodsDtlImgExtDiv
            //商品サムネイル画像有無区分
            serInfo.MemberInfo.Add(typeof(Int16)); //GoodsTmbImgExtDiv
            //商品画像1詳細ファイル名
            serInfo.MemberInfo.Add(typeof(string)); //GoodsDtlImgFlName1
            //商品画像1サムネイルファイル名
            serInfo.MemberInfo.Add(typeof(string)); //GoodsTmbImgFlName1
            //商品画像2詳細ファイル名
            serInfo.MemberInfo.Add(typeof(string)); //GoodsDtlImgFlName2
            //商品画像2サムネイルファイル名
            serInfo.MemberInfo.Add(typeof(string)); //GoodsTmbImgFlName2
            //商品画像3詳細ファイル名
            serInfo.MemberInfo.Add(typeof(string)); //GoodsDtlImgFlName3
            //商品画像3サムネイルファイル名
            serInfo.MemberInfo.Add(typeof(string)); //GoodsTmbImgFlName3
            //商品画像4詳細ファイル名
            serInfo.MemberInfo.Add(typeof(string)); //GoodsDtlImgFlName4
            //商品画像4サムネイルファイル名
            serInfo.MemberInfo.Add(typeof(string)); //GoodsTmbImgFlName4
            //商品画像5詳細ファイル名
            serInfo.MemberInfo.Add(typeof(string)); //GoodsDtlImgFlName5
            //商品画像5サムネイルファイル名
            serInfo.MemberInfo.Add(typeof(string)); //GoodsTmbImgFlName5
            //商品画像6詳細ファイル名
            serInfo.MemberInfo.Add(typeof(string)); //GoodsDtlImgFlName6
            //商品画像6サムネイルファイル名
            serInfo.MemberInfo.Add(typeof(string)); //GoodsTmbImgFlName6
            //商品画像7詳細ファイル名
            serInfo.MemberInfo.Add(typeof(string)); //GoodsDtlImgFlName7
            //商品画像7サムネイルファイル名
            serInfo.MemberInfo.Add(typeof(string)); //GoodsTmbImgFlName7
            //商品画像8詳細ファイル名
            serInfo.MemberInfo.Add(typeof(string)); //GoodsDtlImgFlName8
            //商品画像8サムネイルファイル名
            serInfo.MemberInfo.Add(typeof(string)); //GoodsTmbImgFlName8
            //商品画像9詳細ファイル名
            serInfo.MemberInfo.Add(typeof(string)); //GoodsDtlImgFlName9
            //商品画像9サムネイルファイル名
            serInfo.MemberInfo.Add(typeof(string)); //GoodsTmbImgFlName9
            //自動車部品廃番区分
            serInfo.MemberInfo.Add(typeof(Int16)); //CarPrtsDiscontDiv
            //自動車部品廃番日
            serInfo.MemberInfo.Add(typeof(Int32)); //CarPrtsDiscontDate
            //代替優良品番(－付き品番)
            serInfo.MemberInfo.Add(typeof(string)); //SubstPrmPrtsWithHyph
            //部品メーカー名称（全角）
            serInfo.MemberInfo.Add(typeof(string)); //PartsMakerFullName
            //優良品名
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsName
            //優良部品規格・特記事項
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsSpecialNote


            serInfo.Serialize(writer, serInfo);
            if (graph is PrmPrtDtInfWork)
            {
                PrmPrtDtInfWork temp = (PrmPrtDtInfWork)graph;

                SetPrmPrtDtInfWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PrmPrtDtInfWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PrmPrtDtInfWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PrmPrtDtInfWork temp in lst)
                {
                    SetPrmPrtDtInfWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PrmPrtDtInfWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 46;

        /// <summary>
        ///  PrmPrtDtInfWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmPrtDtInfWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPrmPrtDtInfWork(System.IO.BinaryWriter writer, PrmPrtDtInfWork temp)
        {
            //提供日付
            writer.Write((Int64)temp.OfferDate.Ticks);
            //部品メーカーコード
            writer.Write(temp.PartsMakerCode);
            //優良品番(－付き品番)
            writer.Write(temp.PrimePartsNoWithH);
            //商品詳細説明(B向け)
            writer.Write(temp.GoodsDetailDescToB);
            //商品詳細説明(C向け)
            writer.Write(temp.GoodsDetailDescToC);
            //優良部品メーカーURL
            writer.Write(temp.PrmPartsMakerUrl);
            //優良部品カタログURI
            writer.Write(temp.PrmPartsCatalogUri);
            //優良部品説明動画URI
            writer.Write(temp.PrmPtDescMovieUri);
            //商品寸法・長さ
            writer.Write(temp.GoodsSizeLength);
            //商品寸法・幅
            writer.Write(temp.GoodsSizeWidth);
            //商品寸法・高さ
            writer.Write(temp.GoodsSizeHeight);
            //商品寸法・単位
            writer.Write(temp.GoodsSizeUnit);
            //商品箱寸法・長さ
            writer.Write(temp.GoodsPkgBoxLength);
            //商品箱寸法・幅
            writer.Write(temp.GoodsPkgBoxWidth);
            //商品箱寸法・高さ
            writer.Write(temp.GoodsPkgBoxHeight);
            //商品箱寸法・単位
            writer.Write(temp.GoodsPkgBoxUnit);
            //商品内容量
            writer.Write(temp.GoodsVolume);
            //商品内容量単位
            writer.Write(temp.GoodsVolumeUnit);
            //商品重量
            writer.Write(temp.GoodsWeight);
            //商品重量単位
            writer.Write(temp.GoodsWeightUnit);
            //商品詳細画像有無区分
            writer.Write(temp.GoodsDtlImgExtDiv);
            //商品サムネイル画像有無区分
            writer.Write(temp.GoodsTmbImgExtDiv);
            //商品画像1詳細ファイル名
            writer.Write(temp.GoodsDtlImgFlName1);
            //商品画像1サムネイルファイル名
            writer.Write(temp.GoodsTmbImgFlName1);
            //商品画像2詳細ファイル名
            writer.Write(temp.GoodsDtlImgFlName2);
            //商品画像2サムネイルファイル名
            writer.Write(temp.GoodsTmbImgFlName2);
            //商品画像3詳細ファイル名
            writer.Write(temp.GoodsDtlImgFlName3);
            //商品画像3サムネイルファイル名
            writer.Write(temp.GoodsTmbImgFlName3);
            //商品画像4詳細ファイル名
            writer.Write(temp.GoodsDtlImgFlName4);
            //商品画像4サムネイルファイル名
            writer.Write(temp.GoodsTmbImgFlName4);
            //商品画像5詳細ファイル名
            writer.Write(temp.GoodsDtlImgFlName5);
            //商品画像5サムネイルファイル名
            writer.Write(temp.GoodsTmbImgFlName5);
            //商品画像6詳細ファイル名
            writer.Write(temp.GoodsDtlImgFlName6);
            //商品画像6サムネイルファイル名
            writer.Write(temp.GoodsTmbImgFlName6);
            //商品画像7詳細ファイル名
            writer.Write(temp.GoodsDtlImgFlName7);
            //商品画像7サムネイルファイル名
            writer.Write(temp.GoodsTmbImgFlName7);
            //商品画像8詳細ファイル名
            writer.Write(temp.GoodsDtlImgFlName8);
            //商品画像8サムネイルファイル名
            writer.Write(temp.GoodsTmbImgFlName8);
            //商品画像9詳細ファイル名
            writer.Write(temp.GoodsDtlImgFlName9);
            //商品画像9サムネイルファイル名
            writer.Write(temp.GoodsTmbImgFlName9);
            //自動車部品廃番区分
            writer.Write(temp.CarPrtsDiscontDiv);
            //自動車部品廃番日
            writer.Write(temp.CarPrtsDiscontDate);
            //代替優良品番(－付き品番)
            writer.Write(temp.SubstPrmPrtsWithHyph);
            //部品メーカー名称（全角）
            writer.Write(temp.PartsMakerFullName);
            //優良品名
            writer.Write(temp.PrimePartsName);
            //優良部品規格・特記事項
            writer.Write(temp.PrimePartsSpecialNote);

        }

        /// <summary>
        ///  PrmPrtDtInfWorkインスタンス取得
        /// </summary>
        /// <returns>PrmPrtDtInfWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmPrtDtInfWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PrmPrtDtInfWork GetPrmPrtDtInfWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PrmPrtDtInfWork temp = new PrmPrtDtInfWork();

            //提供日付
            temp.OfferDate = new DateTime(reader.ReadInt64());
            //部品メーカーコード
            temp.PartsMakerCode = reader.ReadInt32();
            //優良品番(－付き品番)
            temp.PrimePartsNoWithH = reader.ReadString();
            //商品詳細説明(B向け)
            temp.GoodsDetailDescToB = reader.ReadString();
            //商品詳細説明(C向け)
            temp.GoodsDetailDescToC = reader.ReadString();
            //優良部品メーカーURL
            temp.PrmPartsMakerUrl = reader.ReadString();
            //優良部品カタログURI
            temp.PrmPartsCatalogUri = reader.ReadString();
            //優良部品説明動画URI
            temp.PrmPtDescMovieUri = reader.ReadString();
            //商品寸法・長さ
            temp.GoodsSizeLength = reader.ReadDouble();
            //商品寸法・幅
            temp.GoodsSizeWidth = reader.ReadDouble();
            //商品寸法・高さ
            temp.GoodsSizeHeight = reader.ReadDouble();
            //商品寸法・単位
            temp.GoodsSizeUnit = reader.ReadString();
            //商品箱寸法・長さ
            temp.GoodsPkgBoxLength = reader.ReadDouble();
            //商品箱寸法・幅
            temp.GoodsPkgBoxWidth = reader.ReadDouble();
            //商品箱寸法・高さ
            temp.GoodsPkgBoxHeight = reader.ReadDouble();
            //商品箱寸法・単位
            temp.GoodsPkgBoxUnit = reader.ReadString();
            //商品内容量
            temp.GoodsVolume = reader.ReadDouble();
            //商品内容量単位
            temp.GoodsVolumeUnit = reader.ReadString();
            //商品重量
            temp.GoodsWeight = reader.ReadDouble();
            //商品重量単位
            temp.GoodsWeightUnit = reader.ReadString();
            //商品詳細画像有無区分
            temp.GoodsDtlImgExtDiv = reader.ReadInt16();
            //商品サムネイル画像有無区分
            temp.GoodsTmbImgExtDiv = reader.ReadInt16();
            //商品画像1詳細ファイル名
            temp.GoodsDtlImgFlName1 = reader.ReadString();
            //商品画像1サムネイルファイル名
            temp.GoodsTmbImgFlName1 = reader.ReadString();
            //商品画像2詳細ファイル名
            temp.GoodsDtlImgFlName2 = reader.ReadString();
            //商品画像2サムネイルファイル名
            temp.GoodsTmbImgFlName2 = reader.ReadString();
            //商品画像3詳細ファイル名
            temp.GoodsDtlImgFlName3 = reader.ReadString();
            //商品画像3サムネイルファイル名
            temp.GoodsTmbImgFlName3 = reader.ReadString();
            //商品画像4詳細ファイル名
            temp.GoodsDtlImgFlName4 = reader.ReadString();
            //商品画像4サムネイルファイル名
            temp.GoodsTmbImgFlName4 = reader.ReadString();
            //商品画像5詳細ファイル名
            temp.GoodsDtlImgFlName5 = reader.ReadString();
            //商品画像5サムネイルファイル名
            temp.GoodsTmbImgFlName5 = reader.ReadString();
            //商品画像6詳細ファイル名
            temp.GoodsDtlImgFlName6 = reader.ReadString();
            //商品画像6サムネイルファイル名
            temp.GoodsTmbImgFlName6 = reader.ReadString();
            //商品画像7詳細ファイル名
            temp.GoodsDtlImgFlName7 = reader.ReadString();
            //商品画像7サムネイルファイル名
            temp.GoodsTmbImgFlName7 = reader.ReadString();
            //商品画像8詳細ファイル名
            temp.GoodsDtlImgFlName8 = reader.ReadString();
            //商品画像8サムネイルファイル名
            temp.GoodsTmbImgFlName8 = reader.ReadString();
            //商品画像9詳細ファイル名
            temp.GoodsDtlImgFlName9 = reader.ReadString();
            //商品画像9サムネイルファイル名
            temp.GoodsTmbImgFlName9 = reader.ReadString();
            //自動車部品廃番区分
            temp.CarPrtsDiscontDiv = reader.ReadInt16();
            //自動車部品廃番日
            temp.CarPrtsDiscontDate = reader.ReadInt32();
            //代替優良品番(－付き品番)
            temp.SubstPrmPrtsWithHyph = reader.ReadString();
            //部品メーカー名称（全角）
            temp.PartsMakerFullName = reader.ReadString();
            //優良品名
            temp.PrimePartsName = reader.ReadString();
            //優良部品規格・特記事項
            temp.PrimePartsSpecialNote = reader.ReadString();


            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>PrmPrtDtInfWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmPrtDtInfWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PrmPrtDtInfWork temp = GetPrmPrtDtInfWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (PrmPrtDtInfWork[])lst.ToArray(typeof(PrmPrtDtInfWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
