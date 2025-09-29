using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   APStockAcPayHistWork
    /// <summary>
    ///                      在庫受払履歴データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫受払履歴データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2009/04/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/30  長内</br>
    /// <br>                 :   ＤＤ名修正</br>
    /// <br>                 :   BL商品コード名称（全角）</br>
    /// <br>                 :   BLGoodsFullName → BLGoodsFullNameRF</br>
    /// <br>Update Note      :   2008/6/30  杉村</br>
    /// <br>                 :   受払元取引区分の補足に</br>
    /// <br>                 :   「42:マスタメンテ」追加</br>
    /// <br>Update Note      :   2008/8/22  長内</br>
    /// <br>                 :   受払元伝票区分の補足に</br>
    /// <br>                 :   「13:在庫仕入」追加</br>
    /// <br>Update Note      :   2008/10/09  杉村</br>
    /// <br>                 :   受払元伝票区分の補足に</br>
    /// <br>                 :   「60:組立,61:分解,70:補充」追加</br>
    /// <br>Update Note      :   2008/10/14  杉村</br>
    /// <br>                 :   受払元伝票区分の補足変更</br>
    /// <br>                 :   「70:補充」⇒「70:補充入庫,70:補充出庫」</br>
    /// <br>Update Note      :   2008/10/30  長内</br>
    /// <br>                 :   ○キー変更</br>
    /// <br>                 :   3,11,12,13,14 → 3,11,12,13,14,24,26,32</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class APStockAcPayHistWork : IFileHeader
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

        /// <summary>入出荷日</summary>
        private Int32 _ioGoodsDay;

        /// <summary>計上日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _addUpADate;

        /// <summary>受払元伝票区分</summary>
        /// <remarks>10:仕入,11:受託,12:受計上,13:在庫仕入20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,42:マスタメンテ,50:棚卸,60:組立,61:分解,70:補充入庫,71:補充出庫</remarks>
        private Int32 _acPaySlipCd;

        /// <summary>受払元伝票番号</summary>
        /// <remarks>「受払元伝票」の伝票番号を格納</remarks>
        private string _acPaySlipNum = "";

        /// <summary>受払元行番号</summary>
        /// <remarks>「受払元伝票」の伝票行番号を格納</remarks>
        private Int32 _acPaySlipRowNo;

        /// <summary>受払履歴作成日時</summary>
        private Int64 _acPayHistDateTime;

        /// <summary>受払元取引区分</summary>
        /// <remarks>10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除
        /// 30:在庫数調整,31:原価調整,32:製番調整,33:不良品,
        /// 34:抜出,35:消去,36:一括登録,40:過不足更新,90:取消</remarks>
        private Int32 _acPayTransCd;

        /// <summary>入力拠点コード</summary>
        /// <remarks>入力を行った拠点ｺｰﾄﾞ</remarks>
        private string _inputSectionCd = "";

        /// <summary>入力拠点ガイド名称</summary>
        private string _inputSectionGuidNm = "";

        /// <summary>入力担当者コード</summary>
        private string _inputAgenCd = "";

        /// <summary>入力担当者名称</summary>
        private string _inputAgenNm = "";

        /// <summary>移動状態</summary>
        /// <remarks>0:移動対象外、1:未出荷状態、2:移動中、9:入荷済</remarks>
        private Int32 _moveStatus;

        /// <summary>相手先伝票番号</summary>
        /// <remarks>得意先伝票番号、仕入先伝票番号</remarks>
        private string _custSlipNo = "";

        /// <summary>明細通番</summary>
        private Int64 _slipDtlNum;

        /// <summary>受払備考</summary>
        /// <remarks>受払した情報を格納</remarks>
        private string _acPayNote = "";

        /// <summary>商品メーカーコード</summary>
        /// <remarks>提供範囲はプロダクト毎で定義</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード名称（全角）</summary>
        private string _bLGoodsFullName = "";

        /// <summary>拠点コード</summary>
        /// <remarks>出荷、入荷が発生する拠点</remarks>
        private string _sectionCode = "";

        /// <summary>拠点ガイド名称</summary>
        private string _sectionGuideNm = "";

        /// <summary>倉庫コード</summary>
        /// <remarks>出荷、入荷が発生する倉庫</remarks>
        private string _warehouseCode = "";

        /// <summary>倉庫名称</summary>
        private string _warehouseName = "";

        /// <summary>棚番</summary>
        /// <remarks>出荷、入荷が発生する棚番</remarks>
        private string _shelfNo = "";

        /// <summary>移動元拠点コード</summary>
        /// <remarks>移動（出荷）の場合は 自情報　　移動（入荷）の場合は相手情報</remarks>
        private string _bfSectionCode = "";

        /// <summary>移動元拠点ガイド名称</summary>
        /// <remarks>同上</remarks>
        private string _bfSectionGuideNm = "";

        /// <summary>移動元倉庫コード</summary>
        /// <remarks>同上</remarks>
        private string _bfEnterWarehCode = "";

        /// <summary>移動元倉庫名称</summary>
        /// <remarks>同上</remarks>
        private string _bfEnterWarehName = "";

        /// <summary>移動元棚番</summary>
        /// <remarks>同上</remarks>
        private string _bfShelfNo = "";

        /// <summary>移動先拠点コード</summary>
        /// <remarks>移動（出荷）の場合は 相手情報　　移動（入荷）の場合は自情報</remarks>
        private string _afSectionCode = "";

        /// <summary>移動先拠点ガイド名称</summary>
        /// <remarks>同上</remarks>
        private string _afSectionGuideNm = "";

        /// <summary>移動先倉庫コード</summary>
        /// <remarks>同上</remarks>
        private string _afEnterWarehCode = "";

        /// <summary>移動先倉庫名称</summary>
        /// <remarks>同上</remarks>
        private string _afEnterWarehName = "";

        /// <summary>移動先棚番</summary>
        /// <remarks>同上</remarks>
        private string _afShelfNo = "";

        /// <summary>得意先コード</summary>
        /// <remarks>売上時の得意先コードをセット</remarks>
        private Int32 _customerCode;

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>仕入先コード</summary>
        /// <remarks>仕入時の仕入先コードをセット</remarks>
        private Int32 _supplierCd;

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>入荷数</summary>
        /// <remarks>仕入入力、在庫移動（入荷）、在庫調整、棚卸し時にセット</remarks>
        private Double _arrivalCnt;

        /// <summary>出荷数</summary>
        /// <remarks>売上入力、在庫移動（出荷）時にセット</remarks>
        private Double _shipmentCnt;

        /// <summary>オープン価格区分</summary>
        /// <remarks>0:通常／1:オープン価格</remarks>
        private Int32 _openPriceDiv;

        /// <summary>定価（税抜，浮動）</summary>
        /// <remarks>税抜き</remarks>
        private Double _listPriceTaxExcFl;

        /// <summary>仕入単価（税抜，浮動）</summary>
        /// <remarks>売上の場合原価単価</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>仕入金額</summary>
        /// <remarks>売上の場合原価金額</remarks>
        private Int64 _stockPrice;

        /// <summary>売上単価（税抜，浮動）</summary>
        private Double _salesUnPrcTaxExcFl;

        /// <summary>売上金額</summary>
        private Int64 _salesMoney;

        /// <summary>仕入在庫数</summary>
        /// <remarks>入荷数(未計上）、出荷数(未計上）を含まない在庫数（自社在庫）</remarks>
        private Double _supplierStock;

        /// <summary>受注数</summary>
        private Double _acpOdrCount;

        /// <summary>発注数</summary>
        private Double _salesOrderCount;

        /// <summary>移動中仕入在庫数</summary>
        /// <remarks>在庫移動後、かつ移動先が入荷する前までの間に有効値が入る。</remarks>
        private Double _movingSupliStock;

        /// <summary>出荷数（未計上）</summary>
        /// <remarks>貸出、出荷と同意</remarks>
        private Double _nonAddUpShipmCnt;

        /// <summary>入荷数（未計上）</summary>
        /// <remarks>入荷</remarks>
        private Double _nonAddUpArrGdsCnt;

        /// <summary>出荷可能数</summary>
        /// <remarks>出荷可能数＝仕入在庫数＋入荷数(未計上）－出荷数（未計上）－受注数 － 移動中仕入在庫数</remarks>
        private Double _shipmentPosCnt;

        /// <summary>現在庫数量</summary>
        /// <remarks>現在庫数量＝仕入在庫数＋入荷数（未計上）－出荷数（未計上）－移動中仕入在庫数</remarks>
        private Double _presentStockCnt;


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

        /// public propaty name  :  IoGoodsDay
        /// <summary>入出荷日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入出荷日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 IoGoodsDay
        {
            get { return _ioGoodsDay; }
            set { _ioGoodsDay = value; }
        }

        /// public propaty name  :  AddUpADate
        /// <summary>計上日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpADate
        {
            get { return _addUpADate; }
            set { _addUpADate = value; }
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

        /// public propaty name  :  AcPaySlipNum
        /// <summary>受払元伝票番号プロパティ</summary>
        /// <value>「受払元伝票」の伝票番号を格納</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受払元伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AcPaySlipNum
        {
            get { return _acPaySlipNum; }
            set { _acPaySlipNum = value; }
        }

        /// public propaty name  :  AcPaySlipRowNo
        /// <summary>受払元行番号プロパティ</summary>
        /// <value>「受払元伝票」の伝票行番号を格納</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受払元行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcPaySlipRowNo
        {
            get { return _acPaySlipRowNo; }
            set { _acPaySlipRowNo = value; }
        }

        /// public propaty name  :  AcPayHistDateTime
        /// <summary>受払履歴作成日時プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受払履歴作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AcPayHistDateTime
        {
            get { return _acPayHistDateTime; }
            set { _acPayHistDateTime = value; }
        }

        /// public propaty name  :  AcPayTransCd
        /// <summary>受払元取引区分プロパティ</summary>
        /// <value>10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除
        /// 30:在庫数調整,31:原価調整,32:製番調整,33:不良品,
        /// 34:抜出,35:消去,36:一括登録,40:過不足更新,90:取消</value>
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

        /// public propaty name  :  InputSectionCd
        /// <summary>入力拠点コードプロパティ</summary>
        /// <value>入力を行った拠点ｺｰﾄﾞ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InputSectionCd
        {
            get { return _inputSectionCd; }
            set { _inputSectionCd = value; }
        }

        /// public propaty name  :  InputSectionGuidNm
        /// <summary>入力拠点ガイド名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InputSectionGuidNm
        {
            get { return _inputSectionGuidNm; }
            set { _inputSectionGuidNm = value; }
        }

        /// public propaty name  :  InputAgenCd
        /// <summary>入力担当者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InputAgenCd
        {
            get { return _inputAgenCd; }
            set { _inputAgenCd = value; }
        }

        /// public propaty name  :  InputAgenNm
        /// <summary>入力担当者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力担当者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InputAgenNm
        {
            get { return _inputAgenNm; }
            set { _inputAgenNm = value; }
        }

        /// public propaty name  :  MoveStatus
        /// <summary>移動状態プロパティ</summary>
        /// <value>0:移動対象外、1:未出荷状態、2:移動中、9:入荷済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動状態プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoveStatus
        {
            get { return _moveStatus; }
            set { _moveStatus = value; }
        }

        /// public propaty name  :  CustSlipNo
        /// <summary>相手先伝票番号プロパティ</summary>
        /// <value>得意先伝票番号、仕入先伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustSlipNo
        {
            get { return _custSlipNo; }
            set { _custSlipNo = value; }
        }

        /// public propaty name  :  SlipDtlNum
        /// <summary>明細通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SlipDtlNum
        {
            get { return _slipDtlNum; }
            set { _slipDtlNum = value; }
        }

        /// public propaty name  :  AcPayNote
        /// <summary>受払備考プロパティ</summary>
        /// <value>受払した情報を格納</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受払備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AcPayNote
        {
            get { return _acPayNote; }
            set { _acPayNote = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// <value>提供範囲はプロダクト毎で定義</value>
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

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>出荷、入荷が発生する拠点</value>
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

        /// public propaty name  :  SectionGuideNm
        /// <summary>拠点ガイド名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// <value>出荷、入荷が発生する倉庫</value>
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

        /// public propaty name  :  ShelfNo
        /// <summary>棚番プロパティ</summary>
        /// <value>出荷、入荷が発生する棚番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShelfNo
        {
            get { return _shelfNo; }
            set { _shelfNo = value; }
        }

        /// public propaty name  :  BfSectionCode
        /// <summary>移動元拠点コードプロパティ</summary>
        /// <value>移動（出荷）の場合は 自情報　　移動（入荷）の場合は相手情報</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動元拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfSectionCode
        {
            get { return _bfSectionCode; }
            set { _bfSectionCode = value; }
        }

        /// public propaty name  :  BfSectionGuideNm
        /// <summary>移動元拠点ガイド名称プロパティ</summary>
        /// <value>同上</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動元拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfSectionGuideNm
        {
            get { return _bfSectionGuideNm; }
            set { _bfSectionGuideNm = value; }
        }

        /// public propaty name  :  BfEnterWarehCode
        /// <summary>移動元倉庫コードプロパティ</summary>
        /// <value>同上</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動元倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfEnterWarehCode
        {
            get { return _bfEnterWarehCode; }
            set { _bfEnterWarehCode = value; }
        }

        /// public propaty name  :  BfEnterWarehName
        /// <summary>移動元倉庫名称プロパティ</summary>
        /// <value>同上</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動元倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfEnterWarehName
        {
            get { return _bfEnterWarehName; }
            set { _bfEnterWarehName = value; }
        }

        /// public propaty name  :  BfShelfNo
        /// <summary>移動元棚番プロパティ</summary>
        /// <value>同上</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動元棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfShelfNo
        {
            get { return _bfShelfNo; }
            set { _bfShelfNo = value; }
        }

        /// public propaty name  :  AfSectionCode
        /// <summary>移動先拠点コードプロパティ</summary>
        /// <value>移動（出荷）の場合は 相手情報　　移動（入荷）の場合は自情報</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動先拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfSectionCode
        {
            get { return _afSectionCode; }
            set { _afSectionCode = value; }
        }

        /// public propaty name  :  AfSectionGuideNm
        /// <summary>移動先拠点ガイド名称プロパティ</summary>
        /// <value>同上</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動先拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfSectionGuideNm
        {
            get { return _afSectionGuideNm; }
            set { _afSectionGuideNm = value; }
        }

        /// public propaty name  :  AfEnterWarehCode
        /// <summary>移動先倉庫コードプロパティ</summary>
        /// <value>同上</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動先倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfEnterWarehCode
        {
            get { return _afEnterWarehCode; }
            set { _afEnterWarehCode = value; }
        }

        /// public propaty name  :  AfEnterWarehName
        /// <summary>移動先倉庫名称プロパティ</summary>
        /// <value>同上</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動先倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfEnterWarehName
        {
            get { return _afEnterWarehName; }
            set { _afEnterWarehName = value; }
        }

        /// public propaty name  :  AfShelfNo
        /// <summary>移動先棚番プロパティ</summary>
        /// <value>同上</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動先棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfShelfNo
        {
            get { return _afShelfNo; }
            set { _afShelfNo = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// <value>売上時の得意先コードをセット</value>
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

        /// public propaty name  :  CustomerSnm
        /// <summary>得意先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// <value>仕入時の仕入先コードをセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>仕入先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  ArrivalCnt
        /// <summary>入荷数プロパティ</summary>
        /// <value>仕入入力、在庫移動（入荷）、在庫調整、棚卸し時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ArrivalCnt
        {
            get { return _arrivalCnt; }
            set { _arrivalCnt = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>出荷数プロパティ</summary>
        /// <value>売上入力、在庫移動（出荷）時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
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

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>定価（税抜，浮動）プロパティ</summary>
        /// <value>税抜き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPriceTaxExcFl
        {
            get { return _listPriceTaxExcFl; }
            set { _listPriceTaxExcFl = value; }
        }

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>仕入単価（税抜，浮動）プロパティ</summary>
        /// <value>売上の場合原価単価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  StockPrice
        /// <summary>仕入金額プロパティ</summary>
        /// <value>売上の場合原価金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockPrice
        {
            get { return _stockPrice; }
            set { _stockPrice = value; }
        }

        /// public propaty name  :  SalesUnPrcTaxExcFl
        /// <summary>売上単価（税抜，浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnPrcTaxExcFl
        {
            get { return _salesUnPrcTaxExcFl; }
            set { _salesUnPrcTaxExcFl = value; }
        }

        /// public propaty name  :  SalesMoney
        /// <summary>売上金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoney
        {
            get { return _salesMoney; }
            set { _salesMoney = value; }
        }

        /// public propaty name  :  SupplierStock
        /// <summary>仕入在庫数プロパティ</summary>
        /// <value>入荷数(未計上）、出荷数(未計上）を含まない在庫数（自社在庫）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SupplierStock
        {
            get { return _supplierStock; }
            set { _supplierStock = value; }
        }

        /// public propaty name  :  AcpOdrCount
        /// <summary>受注数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AcpOdrCount
        {
            get { return _acpOdrCount; }
            set { _acpOdrCount = value; }
        }

        /// public propaty name  :  SalesOrderCount
        /// <summary>発注数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesOrderCount
        {
            get { return _salesOrderCount; }
            set { _salesOrderCount = value; }
        }

        /// public propaty name  :  MovingSupliStock
        /// <summary>移動中仕入在庫数プロパティ</summary>
        /// <value>在庫移動後、かつ移動先が入荷する前までの間に有効値が入る。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動中仕入在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MovingSupliStock
        {
            get { return _movingSupliStock; }
            set { _movingSupliStock = value; }
        }

        /// public propaty name  :  NonAddUpShipmCnt
        /// <summary>出荷数（未計上）プロパティ</summary>
        /// <value>貸出、出荷と同意</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数（未計上）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double NonAddUpShipmCnt
        {
            get { return _nonAddUpShipmCnt; }
            set { _nonAddUpShipmCnt = value; }
        }

        /// public propaty name  :  NonAddUpArrGdsCnt
        /// <summary>入荷数（未計上）プロパティ</summary>
        /// <value>入荷</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷数（未計上）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double NonAddUpArrGdsCnt
        {
            get { return _nonAddUpArrGdsCnt; }
            set { _nonAddUpArrGdsCnt = value; }
        }

        /// public propaty name  :  ShipmentPosCnt
        /// <summary>出荷可能数プロパティ</summary>
        /// <value>出荷可能数＝仕入在庫数＋入荷数(未計上）－出荷数（未計上）－受注数 － 移動中仕入在庫数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷可能数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentPosCnt
        {
            get { return _shipmentPosCnt; }
            set { _shipmentPosCnt = value; }
        }

        /// public propaty name  :  PresentStockCnt
        /// <summary>現在庫数量プロパティ</summary>
        /// <value>現在庫数量＝仕入在庫数＋入荷数（未計上）－出荷数（未計上）－移動中仕入在庫数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   現在庫数量プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PresentStockCnt
        {
            get { return _presentStockCnt; }
            set { _presentStockCnt = value; }
        }


        /// <summary>
        /// 在庫受払履歴データワークコンストラクタ
        /// </summary>
        /// <returns>APStockAcPayHistWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   APStockAcPayHistWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public APStockAcPayHistWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>APStockAcPayHistWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   APStockAcPayHistWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class APStockAcPayHistWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   APStockAcPayHistWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  APStockAcPayHistWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is APStockAcPayHistWork || graph is ArrayList || graph is APStockAcPayHistWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(APStockAcPayHistWork).FullName));

            if (graph != null && graph is APStockAcPayHistWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.APStockAcPayHistWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is APStockAcPayHistWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((APStockAcPayHistWork[])graph).Length;
            }
            else if (graph is APStockAcPayHistWork)
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
            //入出荷日
            serInfo.MemberInfo.Add(typeof(Int32)); //IoGoodsDay
            //計上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpADate
            //受払元伝票区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AcPaySlipCd
            //受払元伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //AcPaySlipNum
            //受払元行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //AcPaySlipRowNo
            //受払履歴作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //AcPayHistDateTime
            //受払元取引区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AcPayTransCd
            //入力拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InputSectionCd
            //入力拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //InputSectionGuidNm
            //入力担当者コード
            serInfo.MemberInfo.Add(typeof(string)); //InputAgenCd
            //入力担当者名称
            serInfo.MemberInfo.Add(typeof(string)); //InputAgenNm
            //移動状態
            serInfo.MemberInfo.Add(typeof(Int32)); //MoveStatus
            //相手先伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //CustSlipNo
            //明細通番
            serInfo.MemberInfo.Add(typeof(Int64)); //SlipDtlNum
            //受払備考
            serInfo.MemberInfo.Add(typeof(string)); //AcPayNote
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL商品コード名称（全角）
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //棚番
            serInfo.MemberInfo.Add(typeof(string)); //ShelfNo
            //移動元拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //BfSectionCode
            //移動元拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //BfSectionGuideNm
            //移動元倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //BfEnterWarehCode
            //移動元倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //BfEnterWarehName
            //移動元棚番
            serInfo.MemberInfo.Add(typeof(string)); //BfShelfNo
            //移動先拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AfSectionCode
            //移動先拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //AfSectionGuideNm
            //移動先倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //AfEnterWarehCode
            //移動先倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //AfEnterWarehName
            //移動先棚番
            serInfo.MemberInfo.Add(typeof(string)); //AfShelfNo
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //入荷数
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt
            //出荷数
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //オープン価格区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv
            //定価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //仕入単価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //仕入金額
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPrice
            //売上単価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxExcFl
            //売上金額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney
            //仕入在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //SupplierStock
            //受注数
            serInfo.MemberInfo.Add(typeof(Double)); //AcpOdrCount
            //発注数
            serInfo.MemberInfo.Add(typeof(Double)); //SalesOrderCount
            //移動中仕入在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //MovingSupliStock
            //出荷数（未計上）
            serInfo.MemberInfo.Add(typeof(Double)); //NonAddUpShipmCnt
            //入荷数（未計上）
            serInfo.MemberInfo.Add(typeof(Double)); //NonAddUpArrGdsCnt
            //出荷可能数
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentPosCnt
            //現在庫数量
            serInfo.MemberInfo.Add(typeof(Double)); //PresentStockCnt


            serInfo.Serialize(writer, serInfo);
            if (graph is APStockAcPayHistWork)
            {
                APStockAcPayHistWork temp = (APStockAcPayHistWork)graph;

                SetAPStockAcPayHistWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is APStockAcPayHistWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((APStockAcPayHistWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (APStockAcPayHistWork temp in lst)
                {
                    SetAPStockAcPayHistWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// APStockAcPayHistWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 64;

        /// <summary>
        ///  APStockAcPayHistWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   APStockAcPayHistWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetAPStockAcPayHistWork(System.IO.BinaryWriter writer, APStockAcPayHistWork temp)
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
            //入出荷日
            writer.Write(temp.IoGoodsDay);
            //計上日付
            writer.Write((Int64)temp.AddUpADate.Ticks);
            //受払元伝票区分
            writer.Write(temp.AcPaySlipCd);
            //受払元伝票番号
            writer.Write(temp.AcPaySlipNum);
            //受払元行番号
            writer.Write(temp.AcPaySlipRowNo);
            //受払履歴作成日時
            writer.Write(temp.AcPayHistDateTime);
            //受払元取引区分
            writer.Write(temp.AcPayTransCd);
            //入力拠点コード
            writer.Write(temp.InputSectionCd);
            //入力拠点ガイド名称
            writer.Write(temp.InputSectionGuidNm);
            //入力担当者コード
            writer.Write(temp.InputAgenCd);
            //入力担当者名称
            writer.Write(temp.InputAgenNm);
            //移動状態
            writer.Write(temp.MoveStatus);
            //相手先伝票番号
            writer.Write(temp.CustSlipNo);
            //明細通番
            writer.Write(temp.SlipDtlNum);
            //受払備考
            writer.Write(temp.AcPayNote);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー名称
            writer.Write(temp.MakerName);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //BL商品コード名称（全角）
            writer.Write(temp.BLGoodsFullName);
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点ガイド名称
            writer.Write(temp.SectionGuideNm);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //倉庫名称
            writer.Write(temp.WarehouseName);
            //棚番
            writer.Write(temp.ShelfNo);
            //移動元拠点コード
            writer.Write(temp.BfSectionCode);
            //移動元拠点ガイド名称
            writer.Write(temp.BfSectionGuideNm);
            //移動元倉庫コード
            writer.Write(temp.BfEnterWarehCode);
            //移動元倉庫名称
            writer.Write(temp.BfEnterWarehName);
            //移動元棚番
            writer.Write(temp.BfShelfNo);
            //移動先拠点コード
            writer.Write(temp.AfSectionCode);
            //移動先拠点ガイド名称
            writer.Write(temp.AfSectionGuideNm);
            //移動先倉庫コード
            writer.Write(temp.AfEnterWarehCode);
            //移動先倉庫名称
            writer.Write(temp.AfEnterWarehName);
            //移動先棚番
            writer.Write(temp.AfShelfNo);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先略称
            writer.Write(temp.CustomerSnm);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //入荷数
            writer.Write(temp.ArrivalCnt);
            //出荷数
            writer.Write(temp.ShipmentCnt);
            //オープン価格区分
            writer.Write(temp.OpenPriceDiv);
            //定価（税抜，浮動）
            writer.Write(temp.ListPriceTaxExcFl);
            //仕入単価（税抜，浮動）
            writer.Write(temp.StockUnitPriceFl);
            //仕入金額
            writer.Write(temp.StockPrice);
            //売上単価（税抜，浮動）
            writer.Write(temp.SalesUnPrcTaxExcFl);
            //売上金額
            writer.Write(temp.SalesMoney);
            //仕入在庫数
            writer.Write(temp.SupplierStock);
            //受注数
            writer.Write(temp.AcpOdrCount);
            //発注数
            writer.Write(temp.SalesOrderCount);
            //移動中仕入在庫数
            writer.Write(temp.MovingSupliStock);
            //出荷数（未計上）
            writer.Write(temp.NonAddUpShipmCnt);
            //入荷数（未計上）
            writer.Write(temp.NonAddUpArrGdsCnt);
            //出荷可能数
            writer.Write(temp.ShipmentPosCnt);
            //現在庫数量
            writer.Write(temp.PresentStockCnt);

        }

        /// <summary>
        ///  APStockAcPayHistWorkインスタンス取得
        /// </summary>
        /// <returns>APStockAcPayHistWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   APStockAcPayHistWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private APStockAcPayHistWork GetAPStockAcPayHistWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            APStockAcPayHistWork temp = new APStockAcPayHistWork();

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
            //入出荷日
            temp.IoGoodsDay = reader.ReadInt32();
            //計上日付
            temp.AddUpADate = new DateTime(reader.ReadInt64());
            //受払元伝票区分
            temp.AcPaySlipCd = reader.ReadInt32();
            //受払元伝票番号
            temp.AcPaySlipNum = reader.ReadString();
            //受払元行番号
            temp.AcPaySlipRowNo = reader.ReadInt32();
            //受払履歴作成日時
            temp.AcPayHistDateTime = reader.ReadInt64();
            //受払元取引区分
            temp.AcPayTransCd = reader.ReadInt32();
            //入力拠点コード
            temp.InputSectionCd = reader.ReadString();
            //入力拠点ガイド名称
            temp.InputSectionGuidNm = reader.ReadString();
            //入力担当者コード
            temp.InputAgenCd = reader.ReadString();
            //入力担当者名称
            temp.InputAgenNm = reader.ReadString();
            //移動状態
            temp.MoveStatus = reader.ReadInt32();
            //相手先伝票番号
            temp.CustSlipNo = reader.ReadString();
            //明細通番
            temp.SlipDtlNum = reader.ReadInt64();
            //受払備考
            temp.AcPayNote = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //BL商品コード名称（全角）
            temp.BLGoodsFullName = reader.ReadString();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点ガイド名称
            temp.SectionGuideNm = reader.ReadString();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //倉庫名称
            temp.WarehouseName = reader.ReadString();
            //棚番
            temp.ShelfNo = reader.ReadString();
            //移動元拠点コード
            temp.BfSectionCode = reader.ReadString();
            //移動元拠点ガイド名称
            temp.BfSectionGuideNm = reader.ReadString();
            //移動元倉庫コード
            temp.BfEnterWarehCode = reader.ReadString();
            //移動元倉庫名称
            temp.BfEnterWarehName = reader.ReadString();
            //移動元棚番
            temp.BfShelfNo = reader.ReadString();
            //移動先拠点コード
            temp.AfSectionCode = reader.ReadString();
            //移動先拠点ガイド名称
            temp.AfSectionGuideNm = reader.ReadString();
            //移動先倉庫コード
            temp.AfEnterWarehCode = reader.ReadString();
            //移動先倉庫名称
            temp.AfEnterWarehName = reader.ReadString();
            //移動先棚番
            temp.AfShelfNo = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先略称
            temp.CustomerSnm = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //入荷数
            temp.ArrivalCnt = reader.ReadDouble();
            //出荷数
            temp.ShipmentCnt = reader.ReadDouble();
            //オープン価格区分
            temp.OpenPriceDiv = reader.ReadInt32();
            //定価（税抜，浮動）
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //仕入単価（税抜，浮動）
            temp.StockUnitPriceFl = reader.ReadDouble();
            //仕入金額
            temp.StockPrice = reader.ReadInt64();
            //売上単価（税抜，浮動）
            temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
            //売上金額
            temp.SalesMoney = reader.ReadInt64();
            //仕入在庫数
            temp.SupplierStock = reader.ReadDouble();
            //受注数
            temp.AcpOdrCount = reader.ReadDouble();
            //発注数
            temp.SalesOrderCount = reader.ReadDouble();
            //移動中仕入在庫数
            temp.MovingSupliStock = reader.ReadDouble();
            //出荷数（未計上）
            temp.NonAddUpShipmCnt = reader.ReadDouble();
            //入荷数（未計上）
            temp.NonAddUpArrGdsCnt = reader.ReadDouble();
            //出荷可能数
            temp.ShipmentPosCnt = reader.ReadDouble();
            //現在庫数量
            temp.PresentStockCnt = reader.ReadDouble();


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
        /// <returns>APStockAcPayHistWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   APStockAcPayHistWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                APStockAcPayHistWork temp = GetAPStockAcPayHistWork(reader, serInfo);
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
                    retValue = (APStockAcPayHistWork[])lst.ToArray(typeof(APStockAcPayHistWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
