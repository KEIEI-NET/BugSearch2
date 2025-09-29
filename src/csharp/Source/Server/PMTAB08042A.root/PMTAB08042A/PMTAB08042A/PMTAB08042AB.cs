//****************************************************************************//
// システム         : PM-Tablet
// プログラム名称   : 部品詳細情報JSONクラス
// プログラム概要   : 部品詳細情報JSONデータを戻る。
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370090-00  作成担当 : chenyk
// 作 成 日  2017.11.02   修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 部品詳細情報JSONクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 部品詳細情報JSONクラス制御を行います。</br>
    /// <br>Programmer : chenyk</br>
    /// <br>Date       : 2017.11.02</br>
    /// </remarks>
    public class JSPartsDetailInfo
    {
        #region Private Members
        /// <summary>メーカーコード</summary>
        private int PartsMakerCodeField;
        /// <summary>メーカー名</summary>
        private string PartsMakerFullNameField = "";
        /// <summary>品名</summary>
        private string PrimePartsNameField = "";
        /// <summary>品番</summary>
        private string PrimePartsNoField = "";
        /// <summary>商品説明</summary>
        private string GoodsDetailDescField = "";
        /// <summary>特記</summary>
        private string PrimePartsSpecialNoteField = "";
        /// <summary>メーカー名ホームページURL</summary>
        private string PrmPartsMakerUrlField = "";
        /// <summary>カタログ情報ページURL</summary>
        private string PrmPartsCatalogUriField = "";
        /// <summary>商品情報ページURL</summary>
        private string PrmPtDescMovieUriField = "";
        /// <summary>寸法（長さ）（商品寸法単位付き）</summary>
        private string GoodsSizeLengthWithUnitField = "";
        /// <summary>寸法（幅）（商品寸法単位付き）</summary>
        private string GoodsSizeWidthWithUnitField = "";
        /// <summary>寸法（高さ）（商品寸法単位付き）</summary>
        private string GoodsSizeHeightWithUnitField = "";
        /// <summary>箱寸法（長さ）（商品箱寸法単位付き）</summary>
        private string GoodsPkgBoxLengthWithUnitField = "";
        /// <summary>箱寸法（幅）（商品箱寸法単位付き）</summary>
        private string GoodsPkgBoxWidthWithUnitField = "";
        /// <summary>箱寸法（高さ）（商品箱寸法単位付き）</summary>
        private string GoodsPkgBoxHeightWithUnitField = "";
        /// <summary>商品容量（商品内容量単位付き）</summary>
        private string GoodsVolumeWithUnitField = "";
        /// <summary>商品重量（商品重量単位付き）</summary>
        private string GoodsWeightWithUnitField = "";
        /// <summary>商品サムネイル画像有無区分</summary>
        private short GoodsTmbImgExtDivField;
        /// <summary>画像1</summary>
        private string GoodsTmbImgFlName1Field = "";
        /// <summary>画像2</summary>
        private string GoodsTmbImgFlName2Field = "";
        /// <summary>画像3</summary>
        private string GoodsTmbImgFlName3Field = "";
        /// <summary>画像4</summary>
        private string GoodsTmbImgFlName4Field = "";
        /// <summary>画像5</summary>
        private string GoodsTmbImgFlName5Field = "";
        /// <summary>画像6</summary>
        private string GoodsTmbImgFlName6Field = "";
        /// <summary>画像7</summary>
        private string GoodsTmbImgFlName7Field = "";
        /// <summary>画像8</summary>
        private string GoodsTmbImgFlName8Field = "";
        /// <summary>画像9</summary>
        private string GoodsTmbImgFlName9Field = "";
        /// <summary>販売終了日（廃番日付）</summary>
        private string CarPrtsDiscontDateField = "";
        #endregion

        #region Property
        /// <summary>
        /// メーカーコード
        /// </summary>
        public int PartsMakerCode
        {
            get { return PartsMakerCodeField; }
            set { PartsMakerCodeField = value; }
        }
        /// <summary>
        /// メーカー名
        /// </summary>
        public string PartsMakerFullName
        {
            get { return PartsMakerFullNameField; }
            set { PartsMakerFullNameField = value; }
        }
        /// <summary>
        /// 品名
        /// </summary>
        public string PrimePartsName
        {
            get { return PrimePartsNameField; }
            set { PrimePartsNameField = value; }
        }
        /// <summary>
        /// 品番
        /// </summary>
        public string PrimePartsNo
        {
            get { return PrimePartsNoField; }
            set { PrimePartsNoField = value; }
        }
        /// <summary>
        /// 商品説明
        /// </summary>
        public string GoodsDetailDesc
        {
            get { return GoodsDetailDescField; }
            set { GoodsDetailDescField = value; }
        }
        /// <summary>
        /// 特記
        /// </summary>
        public string PrimePartsSpecialNote
        {
            get { return PrimePartsSpecialNoteField; }
            set { PrimePartsSpecialNoteField = value; }
        }
        /// <summary>
        /// メーカー名ホームページURL
        /// </summary>
        public string PrmPartsMakerUrl
        {
            get { return PrmPartsMakerUrlField; }
            set { PrmPartsMakerUrlField = value; }
        }
        /// <summary>
        /// カタログ情報ページURL
        /// </summary>
        public string PrmPartsCatalogUri
        {
            get { return PrmPartsCatalogUriField; }
            set { PrmPartsCatalogUriField = value; }
        }
        /// <summary>
        /// 商品情報ページURL
        /// </summary>
        public string PrmPtDescMovieUri
        {
            get { return PrmPtDescMovieUriField; }
            set { PrmPtDescMovieUriField = value; }
        }
        /// <summary>
        /// 寸法（長さ）（商品寸法単位付き）
        /// </summary>
        public string GoodsSizeLengthWithUnit
        {
            get { return GoodsSizeLengthWithUnitField; }
            set { GoodsSizeLengthWithUnitField = value; }
        }
        /// <summary>
        /// 寸法（幅）（商品寸法単位付き）
        /// </summary>
        public string GoodsSizeWidthWithUnit
        {
            get { return GoodsSizeWidthWithUnitField; }
            set { GoodsSizeWidthWithUnitField = value; }
        }
        /// <summary>
        /// 寸法（高さ）（商品寸法単位付き）
        /// </summary>
        public string GoodsSizeHeightWithUnit
        {
            get { return GoodsSizeHeightWithUnitField; }
            set { GoodsSizeHeightWithUnitField = value; }
        }
        /// <summary>
        /// 箱寸法（長さ）（商品箱寸法単位付き）
        /// </summary>
        public string GoodsPkgBoxLengthWithUnit
        {
            get { return GoodsPkgBoxLengthWithUnitField; }
            set { GoodsPkgBoxLengthWithUnitField = value; }
        }
        /// <summary>
        /// 箱寸法（幅）（商品箱寸法単位付き）
        /// </summary>
        public string GoodsPkgBoxWidthWithUnit
        {
            get { return GoodsPkgBoxWidthWithUnitField; }
            set { GoodsPkgBoxWidthWithUnitField = value; }
        }
        /// <summary>
        /// 箱寸法（高さ）（商品箱寸法単位付き）
        /// </summary>
        public string GoodsPkgBoxHeightWithUnit
        {
            get { return GoodsPkgBoxHeightWithUnitField; }
            set { GoodsPkgBoxHeightWithUnitField = value; }
        }
        /// <summary>
        /// 商品容量（商品内容量単位付き）
        /// </summary>
        public string GoodsVolumeWithUnit
        {
            get { return GoodsVolumeWithUnitField; }
            set { GoodsVolumeWithUnitField = value; }
        }
        /// <summary>
        /// 商品重量（商品重量単位付き）
        /// </summary>
        public string GoodsWeightWithUnit
        {
            get { return GoodsWeightWithUnitField; }
            set { GoodsWeightWithUnitField = value; }
        }
        /// <summary>
        /// 商品サムネイル画像有無区分
        /// </summary>
        public short GoodsTmbImgExtDiv
        {
            get { return GoodsTmbImgExtDivField; }
            set { GoodsTmbImgExtDivField = value; }
        }
        /// <summary>
        /// 画像1
        /// </summary>
        public string GoodsTmbImgFlName1
        {
            get { return GoodsTmbImgFlName1Field; }
            set { GoodsTmbImgFlName1Field = value; }
        }
        /// <summary>
        /// 画像2
        /// </summary>
        public string GoodsTmbImgFlName2
        {
            get { return GoodsTmbImgFlName2Field; }
            set { GoodsTmbImgFlName2Field = value; }
        }
        /// <summary>
        /// 画像3
        /// </summary>
        public string GoodsTmbImgFlName3
        {
            get { return GoodsTmbImgFlName3Field; }
            set { GoodsTmbImgFlName3Field = value; }
        }
        /// <summary>
        /// 画像4
        /// </summary>
        public string GoodsTmbImgFlName4
        {
            get { return GoodsTmbImgFlName4Field; }
            set { GoodsTmbImgFlName4Field = value; }
        }
        /// <summary>
        /// 画像5
        /// </summary>
        public string GoodsTmbImgFlName5
        {
            get { return GoodsTmbImgFlName5Field; }
            set { GoodsTmbImgFlName5Field = value; }
        }
        /// <summary>
        /// 画像6
        /// </summary>
        public string GoodsTmbImgFlName6
        {
            get { return GoodsTmbImgFlName6Field; }
            set { GoodsTmbImgFlName6Field = value; }
        }
        /// <summary>
        /// 画像7
        /// </summary>
        public string GoodsTmbImgFlName7
        {
            get { return GoodsTmbImgFlName7Field; }
            set { GoodsTmbImgFlName7Field = value; }
        }
        /// <summary>
        /// 画像8
        /// </summary>
        public string GoodsTmbImgFlName8
        {
            get { return GoodsTmbImgFlName8Field; }
            set { GoodsTmbImgFlName8Field = value; }
        }
        /// <summary>
        /// 画像9
        /// </summary>
        public string GoodsTmbImgFlName9
        {
            get { return GoodsTmbImgFlName9Field; }
            set { GoodsTmbImgFlName9Field = value; }
        }
        /// <summary>
        /// 販売終了日（廃番日付）
        /// </summary>
        public string CarPrtsDiscontDate
        {
            get { return CarPrtsDiscontDateField; }
            set { CarPrtsDiscontDateField = value; }
        }
        #endregion
    }
}
