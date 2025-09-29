using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RateProcParamWork
    /// <summary>
    ///                      掛率マスタ抽出条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   掛率マスタ抽出条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011/08/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class APRateProcParamWork
    {
        /// <summary>開始日時</summary>
        private Int64 _beginningDate;

        /// <summary>終了日時</summary>
        private Int64 _endingDate;

        /// <summary>単価種類</summary>
        private string _unitPriceKind = "";

        /// <summary>設定方法</summary>
        private string _setFun = "";

        /// <summary>単独</summary>
        private string _rateSettingDivide = "";

        /// <summary>拠点(開始)</summary>
        private string _belongSectionCdBegin = "";

        /// <summary>拠点(終了)</summary>
        private string _belongSectionCdEnd = "";

        /// <summary>得意先掛率GR(開始)</summary>
        private Int32 _custRateGrpCodeBegin;

        /// <summary>得意先掛率GR(終了)</summary>
        private Int32 _custRateGrpCodeEnd;

        /// <summary>得意先コード(開始)</summary>
        private Int32 _customerCodeBegin;

        /// <summary>得意先コード(終了)</summary>
        private Int32 _customerCodeEnd;

        /// <summary>仕入先コード(開始)</summary>
        private Int32 _supplierCdBegin;

        /// <summary>仕入先コード(終了)</summary>
        private Int32 _supplierCdEnd;

        /// <summary>部品メーカーコード(開始)</summary>
        private Int32 _goodsMakerCdBegin;

        /// <summary>部品メーカーコード(終了)</summary>
        private Int32 _goodsMakerCdEnd;

        /// <summary>層別(開始)</summary>
        private string _goodsRateRankBegin = "";

        /// <summary>層別(終了)</summary>
        private string _goodsRateRankEnd = "";

        /// <summary>商品掛率GR(開始)</summary>
        private Int32 _goodsRateGrpCodeBegin;

        /// <summary>商品掛率GR(終了)</summary>
        private Int32 _goodsRateGrpCodeEnd;

        /// <summary>BLコード(開始)</summary>
        private Int32 _bLGoodsCodeBegin;

        /// <summary>BLコード(終了)</summary>
        private Int32 _bLGoodsCodeEnd;

        /// <summary>品番(開始)</summary>
        private string _goodsNoBegin = "";

        /// <summary>品番(終了)</summary>
        private string _goodsNoEnd = "";


        /// public propaty name  :  BeginningDate
        /// <summary>開始日時プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 UpdateDateTimeBegin
        {
            get { return _beginningDate; }
            set { _beginningDate = value; }
        }

        /// public propaty name  :  EndingDate
        /// <summary>終了日時プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 UpdateDateTimeEnd
        {
            get { return _endingDate; }
            set { _endingDate = value; }
        }

        /// public propaty name  :  UnitPriceKind
        /// <summary>単価種類プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価種類プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UnitPriceKindRF
        {
            get { return _unitPriceKind; }
            set { _unitPriceKind = value; }
        }

        /// public propaty name  :  SetFun
        /// <summary>設定方法プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   設定方法プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SetFunRF
        {
            get { return _setFun; }
            set { _setFun = value; }
        }

        /// public propaty name  :  RateSettingDivide
        /// <summary>単独プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単独プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateSettingDivideRF
        {
            get { return _rateSettingDivide; }
            set { _rateSettingDivide = value; }
        }

        /// public propaty name  :  SectionCodeBegin
        /// <summary>拠点(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeBeginRF
        {
            get { return _belongSectionCdBegin; }
            set { _belongSectionCdBegin = value; }
        }

        /// public propaty name  :  SectionCodeEnd
        /// <summary>拠点(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeEndRF
        {
            get { return _belongSectionCdEnd; }
            set { _belongSectionCdEnd = value; }
        }

        /// public propaty name  :  CustRateGrpCodeBegin
        /// <summary>得意先掛率GR(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先掛率GR(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustRateGrpCodeBeginRF
        {
            get { return _custRateGrpCodeBegin; }
            set { _custRateGrpCodeBegin = value; }
        }

        /// public propaty name  :  CustRateGrpCodeEnd
        /// <summary>得意先掛率GR(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先掛率GR(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustRateGrpCodeEndRF
        {
            get { return _custRateGrpCodeEnd; }
            set { _custRateGrpCodeEnd = value; }
        }

        /// public propaty name  :  CustomerCodeBegin
        /// <summary>得意先コード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeBeginRF
        {
            get { return _customerCodeBegin; }
            set { _customerCodeBegin = value; }
        }

        /// public propaty name  :  CustomerCodeEnd
        /// <summary>得意先コード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeEndRF
        {
            get { return _customerCodeEnd; }
            set { _customerCodeEnd = value; }
        }

        /// public propaty name  :  SupplierCdBegin
        /// <summary>仕入先コード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCdBeginRF
        {
            get { return _supplierCdBegin; }
            set { _supplierCdBegin = value; }
        }

        /// public propaty name  :  SupplierCdEnd
        /// <summary>仕入先コード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCdEndRF
        {
            get { return _supplierCdEnd; }
            set { _supplierCdEnd = value; }
        }

        /// public propaty name  :  GoodsMakerCdBegin
        /// <summary>部品メーカーコード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品メーカーコード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdBeginRF
        {
            get { return _goodsMakerCdBegin; }
            set { _goodsMakerCdBegin = value; }
        }

        /// public propaty name  :  GoodsMakerCdEnd
        /// <summary>部品メーカーコード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品メーカーコード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdEndRF
        {
            get { return _goodsMakerCdEnd; }
            set { _goodsMakerCdEnd = value; }
        }

        /// public propaty name  :  GoodsRateRankBegin
        /// <summary>層別(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   層別(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsRateRankBeginRF
        {
            get { return _goodsRateRankBegin; }
            set { _goodsRateRankBegin = value; }
        }

        /// public propaty name  :  GoodsRateRankEnd
        /// <summary>層別(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   層別(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsRateRankEndRF
        {
            get { return _goodsRateRankEnd; }
            set { _goodsRateRankEnd = value; }
        }

        /// public propaty name  :  GoodsRateGrpCodeBegin
        /// <summary>商品掛率GR(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率GR(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsRateGrpCodeBeginRF
        {
            get { return _goodsRateGrpCodeBegin; }
            set { _goodsRateGrpCodeBegin = value; }
        }

        /// public propaty name  :  GoodsRateGrpCodeEnd
        /// <summary>商品掛率GR(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率GR(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsRateGrpCodeEndRF
        {
            get { return _goodsRateGrpCodeEnd; }
            set { _goodsRateGrpCodeEnd = value; }
        }

        /// public propaty name  :  BLGoodsCodeBegin
        /// <summary>BLコード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeBeginRF
        {
            get { return _bLGoodsCodeBegin; }
            set { _bLGoodsCodeBegin = value; }
        }

        /// public propaty name  :  BLGoodsCodeEnd
        /// <summary>BLコード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeEndRF
        {
            get { return _bLGoodsCodeEnd; }
            set { _bLGoodsCodeEnd = value; }
        }

        /// public propaty name  :  GoodsNoBegin
        /// <summary>品番(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoBeginRF
        {
            get { return _goodsNoBegin; }
            set { _goodsNoBegin = value; }
        }

        /// public propaty name  :  GoodsNoEnd
        /// <summary>品番(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoEndRF
        {
            get { return _goodsNoEnd; }
            set { _goodsNoEnd = value; }
        }


        /// <summary>
        /// 掛率マスタ抽出条件ワークコンストラクタ
        /// </summary>
        /// <returns>RateProcParamWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RateProcParamWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public APRateProcParamWork()
        {
        }

    }
}

