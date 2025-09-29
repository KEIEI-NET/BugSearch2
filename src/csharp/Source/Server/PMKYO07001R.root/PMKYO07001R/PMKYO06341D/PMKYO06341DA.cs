using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   APStockAdjustDtlWork
    /// <summary>
    ///                      在庫調整明細データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫調整明細データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2009/04/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/20  長内</br>
    /// <br>                 :   受払元取引区分、受払元伝票区分の補足に</br>
    /// <br>                 :   「42:マスタメンテ」を追加</br>
    /// <br>Update Note      :   2008/6/30  杉村</br>
    /// <br>                 :   受払元取引区分の補足の</br>
    /// <br>                 :   「42:マスタメンテ」削除</br>
    /// <br>Update Note      :   2008/7/29  長内</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   仕入形式（元）</br>
    /// <br>                 :   仕入明細通番（元）</br>
    /// <br>Update Note      :   2008/8/22  長内</br>
    /// <br>                 :   ○項目削除</br>
    /// <br>                 :   　仕入在庫数</br>
    /// <br>                 :   　受託数</br>
    /// <br>                 :   　変更前在庫状態</br>
    /// <br>                 :   　在庫区分</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   　BL商品コード名称</br>
    /// <br>                 :   　オープン価格区分</br>
    /// <br>                 :   　仕入金額（税抜き）</br>
    /// <br>Update Note      :   2008/10/09  杉村</br>
    /// <br>                 :   受払元伝票区分の補足に</br>
    /// <br>                 :   「60:組立,61:分解,70:補充」追加</br>
    /// <br>Update Note      :   2008/10/14  杉村</br>
    /// <br>                 :   受払元伝票区分の補足変更</br>
    /// <br>                 :   「70:補充」⇒「70:補充入庫,70:補充出庫」</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class APStockAdjustDtlWork : IFileHeader
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

        /// <summary>在庫調整伝票番号</summary>
        private Int32 _stockAdjustSlipNo;

        /// <summary>在庫調整行番号</summary>
        private Int32 _stockAdjustRowNo;

        /// <summary>仕入形式（元）</summary>
        /// <remarks>0:仕入,1:入荷,2:発注</remarks>
        private Int32 _supplierFormalSrc;

        /// <summary>仕入明細通番（元）</summary>
        /// <remarks>計上時の元データ明細通番をセット</remarks>
        private Int64 _stockSlipDtlNumSrc;

        /// <summary>受払元伝票区分</summary>
        /// <remarks>10:仕入,11:受託,12:受計上,13:在庫仕入20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,42:マスタメンテ,50:棚卸,60:組立,61:分解,70:補充入庫,71:補充出庫</remarks>
        private Int32 _acPaySlipCd;

        /// <summary>受払元取引区分</summary>
        /// <remarks>10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除
        /// 30:在庫数調整,31:原価調整,32:製番調整,33:不良品,
        /// 34:抜出,35:消去,40:過不足更新,90:取消</remarks>
        private Int32 _acPayTransCd;

        /// <summary>調整日付</summary>
        private Int32 _adjustDate;

        /// <summary>入力日付</summary>
        private Int32 _inputDay;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>仕入単価（税抜,浮動）</summary>
        /// <remarks>在庫調整入力、棚卸過不足更新の単価変更時にセット</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>変更前仕入単価（浮動）</summary>
        private Double _bfStockUnitPriceFl;

        /// <summary>調整数</summary>
        /// <remarks>変更前と変更後の仕入在庫数の差を登録する。</remarks>
        private Double _adjustCount;

        /// <summary>明細備考</summary>
        private string _dtlNote = "";

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>倉庫名称</summary>
        private string _warehouseName = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード名称（全角）</summary>
        private string _bLGoodsFullName = "";

        /// <summary>倉庫棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>定価（浮動）</summary>
        private Double _listPriceFl;

        /// <summary>オープン価格区分</summary>
        /// <remarks>0:通常／1:オープン価格</remarks>
        private Int32 _openPriceDiv;

        /// <summary>仕入金額（税抜き）</summary>
        private Int64 _stockPriceTaxExc;


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

        /// public propaty name  :  StockAdjustSlipNo
        /// <summary>在庫調整伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫調整伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockAdjustSlipNo
        {
            get { return _stockAdjustSlipNo; }
            set { _stockAdjustSlipNo = value; }
        }

        /// public propaty name  :  StockAdjustRowNo
        /// <summary>在庫調整行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫調整行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockAdjustRowNo
        {
            get { return _stockAdjustRowNo; }
            set { _stockAdjustRowNo = value; }
        }

        /// public propaty name  :  SupplierFormalSrc
        /// <summary>仕入形式（元）プロパティ</summary>
        /// <value>0:仕入,1:入荷,2:発注</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入形式（元）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierFormalSrc
        {
            get { return _supplierFormalSrc; }
            set { _supplierFormalSrc = value; }
        }

        /// public propaty name  :  StockSlipDtlNumSrc
        /// <summary>仕入明細通番（元）プロパティ</summary>
        /// <value>計上時の元データ明細通番をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入明細通番（元）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockSlipDtlNumSrc
        {
            get { return _stockSlipDtlNumSrc; }
            set { _stockSlipDtlNumSrc = value; }
        }

        /// public propaty name  :  AcPaySlipCd
        /// <summary>受払元伝票区分プロパティ</summary>
        /// <value>10:仕入,11:受託,12:受計上,13:在庫仕入20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,42:マスタメンテ,50:棚卸,60:組立,61:分解,70:補充入庫,71:補充出庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受払元伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcPaySlipCd
        {
            get { return _acPaySlipCd; }
            set { _acPaySlipCd = value; }
        }

        /// public propaty name  :  AcPayTransCd
        /// <summary>受払元取引区分プロパティ</summary>
        /// <value>10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除
        /// 30:在庫数調整,31:原価調整,32:製番調整,33:不良品,
        /// 34:抜出,35:消去,40:過不足更新,90:取消</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受払元取引区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcPayTransCd
        {
            get { return _acPayTransCd; }
            set { _acPayTransCd = value; }
        }

        /// public propaty name  :  AdjustDate
        /// <summary>調整日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   調整日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AdjustDate
        {
            get { return _adjustDate; }
            set { _adjustDate = value; }
        }

        /// public propaty name  :  InputDay
        /// <summary>入力日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
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

        /// public propaty name  :  MakerName
        /// <summary>メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
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
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>商品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>仕入単価（税抜,浮動）プロパティ</summary>
        /// <value>在庫調整入力、棚卸過不足更新の単価変更時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価（税抜,浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  BfStockUnitPriceFl
        /// <summary>変更前仕入単価（浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更前仕入単価（浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double BfStockUnitPriceFl
        {
            get { return _bfStockUnitPriceFl; }
            set { _bfStockUnitPriceFl = value; }
        }

        /// public propaty name  :  AdjustCount
        /// <summary>調整数プロパティ</summary>
        /// <value>変更前と変更後の仕入在庫数の差を登録する。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   調整数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AdjustCount
        {
            get { return _adjustCount; }
            set { _adjustCount = value; }
        }

        /// public propaty name  :  DtlNote
        /// <summary>明細備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DtlNote
        {
            get { return _dtlNote; }
            set { _dtlNote = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
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

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL商品コード名称（全角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（全角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>倉庫棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  ListPriceFl
        /// <summary>定価（浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPriceFl
        {
            get { return _listPriceFl; }
            set { _listPriceFl = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>オープン価格区分プロパティ</summary>
        /// <value>0:通常／1:オープン価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オープン価格区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }

        /// public propaty name  :  StockPriceTaxExc
        /// <summary>仕入金額（税抜き）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockPriceTaxExc
        {
            get { return _stockPriceTaxExc; }
            set { _stockPriceTaxExc = value; }
        }


        /// <summary>
        /// 在庫調整明細データワークコンストラクタ
        /// </summary>
        /// <returns>APStockAdjustDtlWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   APStockAdjustDtlWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public APStockAdjustDtlWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>APStockAdjustDtlWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   APStockAdjustDtlWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class APStockAdjustDtlWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   APStockAdjustDtlWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  APStockAdjustDtlWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is APStockAdjustDtlWork || graph is ArrayList || graph is APStockAdjustDtlWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(APStockAdjustDtlWork).FullName));

            if (graph != null && graph is APStockAdjustDtlWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.APStockAdjustDtlWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is APStockAdjustDtlWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((APStockAdjustDtlWork[])graph).Length;
            }
            else if (graph is APStockAdjustDtlWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //更新従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //更新アセンブリID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //更新アセンブリID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //在庫調整伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //StockAdjustSlipNo
            //在庫調整行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //StockAdjustRowNo
            //仕入形式（元）
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormalSrc
            //仕入明細通番（元）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNumSrc
            //受払元伝票区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AcPaySlipCd
            //受払元取引区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AcPayTransCd
            //調整日付
            serInfo.MemberInfo.Add(typeof(Int32)); //AdjustDate
            //入力日付
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //仕入単価（税抜,浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //変更前仕入単価（浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //BfStockUnitPriceFl
            //調整数
            serInfo.MemberInfo.Add(typeof(Double)); //AdjustCount
            //明細備考
            serInfo.MemberInfo.Add(typeof(string)); //DtlNote
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL商品コード名称（全角）
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //倉庫棚番
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //定価（浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceFl
            //オープン価格区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv
            //仕入金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxExc


            serInfo.Serialize(writer, serInfo);
            if (graph is APStockAdjustDtlWork)
            {
                APStockAdjustDtlWork temp = (APStockAdjustDtlWork)graph;

                SetAPStockAdjustDtlWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is APStockAdjustDtlWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((APStockAdjustDtlWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (APStockAdjustDtlWork temp in lst)
                {
                    SetAPStockAdjustDtlWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// APStockAdjustDtlWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 33;

        /// <summary>
        ///  APStockAdjustDtlWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   APStockAdjustDtlWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetAPStockAdjustDtlWork(System.IO.BinaryWriter writer, APStockAdjustDtlWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //拠点コード
            writer.Write(temp.SectionCode);
            //在庫調整伝票番号
            writer.Write(temp.StockAdjustSlipNo);
            //在庫調整行番号
            writer.Write(temp.StockAdjustRowNo);
            //仕入形式（元）
            writer.Write(temp.SupplierFormalSrc);
            //仕入明細通番（元）
            writer.Write(temp.StockSlipDtlNumSrc);
            //受払元伝票区分
            writer.Write(temp.AcPaySlipCd);
            //受払元取引区分
            writer.Write(temp.AcPayTransCd);
            //調整日付
            writer.Write(temp.AdjustDate);
            //入力日付
            writer.Write(temp.InputDay);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー名称
            writer.Write(temp.MakerName);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //仕入単価（税抜,浮動）
            writer.Write(temp.StockUnitPriceFl);
            //変更前仕入単価（浮動）
            writer.Write(temp.BfStockUnitPriceFl);
            //調整数
            writer.Write(temp.AdjustCount);
            //明細備考
            writer.Write(temp.DtlNote);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //倉庫名称
            writer.Write(temp.WarehouseName);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //BL商品コード名称（全角）
            writer.Write(temp.BLGoodsFullName);
            //倉庫棚番
            writer.Write(temp.WarehouseShelfNo);
            //定価（浮動）
            writer.Write(temp.ListPriceFl);
            //オープン価格区分
            writer.Write(temp.OpenPriceDiv);
            //仕入金額（税抜き）
            writer.Write(temp.StockPriceTaxExc);

        }

        /// <summary>
        ///  APStockAdjustDtlWorkインスタンス取得
        /// </summary>
        /// <returns>APStockAdjustDtlWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   APStockAdjustDtlWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private APStockAdjustDtlWork GetAPStockAdjustDtlWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            APStockAdjustDtlWork temp = new APStockAdjustDtlWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //在庫調整伝票番号
            temp.StockAdjustSlipNo = reader.ReadInt32();
            //在庫調整行番号
            temp.StockAdjustRowNo = reader.ReadInt32();
            //仕入形式（元）
            temp.SupplierFormalSrc = reader.ReadInt32();
            //仕入明細通番（元）
            temp.StockSlipDtlNumSrc = reader.ReadInt64();
            //受払元伝票区分
            temp.AcPaySlipCd = reader.ReadInt32();
            //受払元取引区分
            temp.AcPayTransCd = reader.ReadInt32();
            //調整日付
            temp.AdjustDate = reader.ReadInt32();
            //入力日付
            temp.InputDay = reader.ReadInt32();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //仕入単価（税抜,浮動）
            temp.StockUnitPriceFl = reader.ReadDouble();
            //変更前仕入単価（浮動）
            temp.BfStockUnitPriceFl = reader.ReadDouble();
            //調整数
            temp.AdjustCount = reader.ReadDouble();
            //明細備考
            temp.DtlNote = reader.ReadString();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //倉庫名称
            temp.WarehouseName = reader.ReadString();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //BL商品コード名称（全角）
            temp.BLGoodsFullName = reader.ReadString();
            //倉庫棚番
            temp.WarehouseShelfNo = reader.ReadString();
            //定価（浮動）
            temp.ListPriceFl = reader.ReadDouble();
            //オープン価格区分
            temp.OpenPriceDiv = reader.ReadInt32();
            //仕入金額（税抜き）
            temp.StockPriceTaxExc = reader.ReadInt64();


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
        /// <returns>APStockAdjustDtlWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   APStockAdjustDtlWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                APStockAdjustDtlWork temp = GetAPStockAdjustDtlWork(reader, serInfo);
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
                    retValue = (APStockAdjustDtlWork[])lst.ToArray(typeof(APStockAdjustDtlWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
