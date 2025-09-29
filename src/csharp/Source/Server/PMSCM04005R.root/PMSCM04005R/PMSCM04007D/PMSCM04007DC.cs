using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    # region --- DEL 2011/05/26 ---
    /*
    /// public class name:   SCMInquiryDtlAnsResultWork
    /// <summary>
    ///                      SCM問い合わせ一覧抽出結果(明細回答)クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM問い合わせ一覧抽出結果(明細回答)クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    2009/4/13</br>
    /// <br>Genarated Date   :   2010/06/17  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SCMInquiryDtlAnsResultWork
    {
        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先名称</summary>
        private string _customerName = "";

        /// <summary>売上日付</summary>
        /// <remarks>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</remarks>
        private DateTime _salesDate;

        /// <summary>受注ステータス</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>売上伝票番号</summary>
        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
        private string _salesSlipNum = "";

        /// <summary>売上金額（税抜き）</summary>
        private Int64 _salesMoneyTaxExc;

        /// <summary>問合せ元企業コード</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>問合せ元拠点コード</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>問合せ先企業コード</summary>
        private string _inqOtherEpCd = "";

        /// <summary>問合せ先拠点コード</summary>
        private string _inqOtherSecCd = "";

        /// <summary>問合せ番号</summary>
        private Int64 _inquiryNumber;

        /// <summary>更新年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _updateDate;

        /// <summary>更新時間</summary>
        /// <remarks>HHMMSSXXX</remarks>
        private Int32 _updateTime;

        /// <summary>問合せ行番号</summary>
        private Int32 _inqRowNumber;

        /// <summary>問合せ行番号枝番</summary>
        private Int32 _inqRowNumDerivedNo;

        /// <summary>問合せ元明細識別GUID</summary>
        private Guid _inqOrgDtlDiscGuid;

        /// <summary>問合せ先明細識別GUID</summary>
        /// <remarks>回答データの場合有効、問合せ／発注元の明細GUIDを設定</remarks>
        private Guid _inqOthDtlDiscGuid;

        /// <summary>商品種別</summary>
        /// <remarks>0:純正部品 1:優良部品 2:リビルド 3:中古 4:平均相場</remarks>
        private Int32 _goodsDivCd;

        /// <summary>納品区分</summary>
        /// <remarks>0:配送,1:引取</remarks>
        private Int32 _deliveredGoodsDiv;

        /// <summary>取扱区分</summary>
        /// <remarks>0:取り扱い品,1:納期確認中,2:未取り扱い品</remarks>
        private Int32 _handleDivCode;

        /// <summary>商品形態</summary>
        /// <remarks>1:部品,2:用品</remarks>
        private Int32 _goodsShape;

        /// <summary>納品確認区分</summary>
        /// <remarks>0:未確認,1:確認</remarks>
        private Int32 _delivrdGdsConfCd;

        /// <summary>納品完了予定日</summary>
        /// <remarks>納品予定日付 YYYYMMDD</remarks>
        private DateTime _deliGdsCmpltDueDate;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード枝番</summary>
        private Int32 _bLGoodsDrCode;

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>発注数</summary>
        private Double _salesOrderCount;

        /// <summary>納品数</summary>
        private Double _deliveredGoodsCount;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>純正商品メーカーコード</summary>
        private Int32 _pureGoodsMakerCd;

        /// <summary>純正商品番号</summary>
        private string _pureGoodsNo = "";

        /// <summary>定価</summary>
        /// <remarks>0:オープン価格</remarks>
        private Int64 _listPrice;

        /// <summary>単価</summary>
        private Int64 _unitPrice;

        /// <summary>明細取込区分</summary>
        /// <remarks>0:未取込 1:取込済</remarks>
        private Int32 _dtlTakeinDivCd;

        /// <summary>商品補足情報</summary>
        private string _goodsAddInfo = "";

        /// <summary>粗利額</summary>
        private Int64 _roughRrofit;

        /// <summary>粗利率</summary>
        private Double _roughRate;

        /// <summary>回答期限</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _answerLimitDate;

        /// <summary>備考(明細)</summary>
        private string _commentDtl = "";

        /// <summary>棚番</summary>
        private string _shelfNo = "";

        /// <summary>追加区分</summary>
        private Int32 _additionalDivCd;

        /// <summary>訂正区分</summary>
        private Int32 _correctDivCD;

        /// <summary>問合せ・発注種別</summary>
        /// <remarks>1:問合せ 2:発注</remarks>
        private Int32 _inqOrdDivCd;

        /// <summary>売上金額消費税額</summary>
        /// <remarks>売上金額（税込み）- 売上金額（税抜き）※消費税調整額も兼ねる</remarks>
        private Int64 _salesPriceConsTax;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>売上行番号</summary>
        private Int32 _salesRowNo;

        /// <summary>キャンペーンコード</summary>
        /// <remarks>任意の無重複コードとする（自動付番はしない）</remarks>
        private Int32 _campaignCode;

        /// <summary>在庫区分</summary>
        /// <remarks>委託在庫、得意先在庫、優先倉庫、自社在庫、非在庫</remarks>
        private Int32 _stockDiv;

        /// <summary>回答納期</summary>
        private string _answerDelivDate = "";

        /// <summary>リサイクル部品種別</summary>
        /// <remarks>1:リビルド 2:中古</remarks>
        private Int32 _recyclePrtKindCode;

        /// <summary>リサイクル部品種別名称</summary>
        private string _recyclePrtKindName = "";

        /// <summary>問発商品名</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _inqGoodsName = "";

        /// <summary>回答商品名</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _ansGoodsName = "";

        /// <summary>問発純正商品番号</summary>
        /// <remarks>(半角のみ)</remarks>
        private string _inqPureGoodsNo = "";

        /// <summary>回答純正商品番号</summary>
        /// <remarks>(半角のみ)</remarks>
        private string _ansPureGoodsNo = "";

        /// <summary>キャンセル状態区分</summary>
        /// <remarks>0:キャンセルなし 10:キャンセル要求 20:キャンセル却下 30:キャンセル確定</remarks>
        private Int16 _cancelCndtinDiv;


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

        /// public propaty name  :  CustomerName
        /// <summary>得意先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>売上日付プロパティ</summary>
        /// <value>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>10:見積,20:受注,30:売上,40:出荷</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>売上伝票番号プロパティ</summary>
        /// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc
        /// <summary>売上金額（税抜き）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>問合せ元企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
        }

        /// public propaty name  :  InqOriginalSecCd
        /// <summary>問合せ元拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOriginalSecCd
        {
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
        }

        /// public propaty name  :  InqOtherEpCd
        /// <summary>問合せ先企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ先企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOtherEpCd
        {
            get { return _inqOtherEpCd; }
            set { _inqOtherEpCd = value; }
        }

        /// public propaty name  :  InqOtherSecCd
        /// <summary>問合せ先拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ先拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOtherSecCd
        {
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
        }

        /// public propaty name  :  InquiryNumber
        /// <summary>問合せ番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 InquiryNumber
        {
            get { return _inquiryNumber; }
            set { _inquiryNumber = value; }
        }

        /// public propaty name  :  UpdateDate
        /// <summary>更新年月日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

        /// public propaty name  :  UpdateTime
        /// <summary>更新時間プロパティ</summary>
        /// <value>HHMMSSXXX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新時間プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateTime
        {
            get { return _updateTime; }
            set { _updateTime = value; }
        }

        /// public propaty name  :  InqRowNumber
        /// <summary>問合せ行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InqRowNumber
        {
            get { return _inqRowNumber; }
            set { _inqRowNumber = value; }
        }

        /// public propaty name  :  InqRowNumDerivedNo
        /// <summary>問合せ行番号枝番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ行番号枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InqRowNumDerivedNo
        {
            get { return _inqRowNumDerivedNo; }
            set { _inqRowNumDerivedNo = value; }
        }

        /// public propaty name  :  InqOrgDtlDiscGuid
        /// <summary>問合せ元明細識別GUIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元明細識別GUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid InqOrgDtlDiscGuid
        {
            get { return _inqOrgDtlDiscGuid; }
            set { _inqOrgDtlDiscGuid = value; }
        }

        /// public propaty name  :  InqOthDtlDiscGuid
        /// <summary>問合せ先明細識別GUIDプロパティ</summary>
        /// <value>回答データの場合有効、問合せ／発注元の明細GUIDを設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ先明細識別GUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid InqOthDtlDiscGuid
        {
            get { return _inqOthDtlDiscGuid; }
            set { _inqOthDtlDiscGuid = value; }
        }

        /// public propaty name  :  GoodsDivCd
        /// <summary>商品種別プロパティ</summary>
        /// <value>0:純正部品 1:優良部品 2:リビルド 3:中古 4:平均相場</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsDivCd
        {
            get { return _goodsDivCd; }
            set { _goodsDivCd = value; }
        }

        /// public propaty name  :  DeliveredGoodsDiv
        /// <summary>納品区分プロパティ</summary>
        /// <value>0:配送,1:引取</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeliveredGoodsDiv
        {
            get { return _deliveredGoodsDiv; }
            set { _deliveredGoodsDiv = value; }
        }

        /// public propaty name  :  HandleDivCode
        /// <summary>取扱区分プロパティ</summary>
        /// <value>0:取り扱い品,1:納期確認中,2:未取り扱い品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取扱区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HandleDivCode
        {
            get { return _handleDivCode; }
            set { _handleDivCode = value; }
        }

        /// public propaty name  :  GoodsShape
        /// <summary>商品形態プロパティ</summary>
        /// <value>1:部品,2:用品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品形態プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsShape
        {
            get { return _goodsShape; }
            set { _goodsShape = value; }
        }

        /// public propaty name  :  DelivrdGdsConfCd
        /// <summary>納品確認区分プロパティ</summary>
        /// <value>0:未確認,1:確認</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品確認区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DelivrdGdsConfCd
        {
            get { return _delivrdGdsConfCd; }
            set { _delivrdGdsConfCd = value; }
        }

        /// public propaty name  :  DeliGdsCmpltDueDate
        /// <summary>納品完了予定日プロパティ</summary>
        /// <value>納品予定日付 YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime DeliGdsCmpltDueDate
        {
            get { return _deliGdsCmpltDueDate; }
            set { _deliGdsCmpltDueDate = value; }
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

        /// public propaty name  :  BLGoodsDrCode
        /// <summary>BL商品コード枝番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsDrCode
        {
            get { return _bLGoodsDrCode; }
            set { _bLGoodsDrCode = value; }
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

        /// public propaty name  :  DeliveredGoodsCount
        /// <summary>納品数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double DeliveredGoodsCount
        {
            get { return _deliveredGoodsCount; }
            set { _deliveredGoodsCount = value; }
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

        /// public propaty name  :  PureGoodsMakerCd
        /// <summary>純正商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PureGoodsMakerCd
        {
            get { return _pureGoodsMakerCd; }
            set { _pureGoodsMakerCd = value; }
        }

        /// public propaty name  :  PureGoodsNo
        /// <summary>純正商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PureGoodsNo
        {
            get { return _pureGoodsNo; }
            set { _pureGoodsNo = value; }
        }

        /// public propaty name  :  ListPrice
        /// <summary>定価プロパティ</summary>
        /// <value>0:オープン価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        /// public propaty name  :  UnitPrice
        /// <summary>単価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        /// public propaty name  :  DtlTakeinDivCd
        /// <summary>明細取込区分プロパティ</summary>
        /// <value>0:未取込 1:取込済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細取込区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DtlTakeinDivCd
        {
            get { return _dtlTakeinDivCd; }
            set { _dtlTakeinDivCd = value; }
        }

        /// public propaty name  :  GoodsAddInfo
        /// <summary>商品補足情報プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品補足情報プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsAddInfo
        {
            get { return _goodsAddInfo; }
            set { _goodsAddInfo = value; }
        }

        /// public propaty name  :  RoughRrofit
        /// <summary>粗利額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 RoughRrofit
        {
            get { return _roughRrofit; }
            set { _roughRrofit = value; }
        }

        /// public propaty name  :  RoughRate
        /// <summary>粗利率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double RoughRate
        {
            get { return _roughRate; }
            set { _roughRate = value; }
        }

        /// public propaty name  :  AnswerLimitDate
        /// <summary>回答期限プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答期限プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AnswerLimitDate
        {
            get { return _answerLimitDate; }
            set { _answerLimitDate = value; }
        }

        /// public propaty name  :  CommentDtl
        /// <summary>備考(明細)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考(明細)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CommentDtl
        {
            get { return _commentDtl; }
            set { _commentDtl = value; }
        }

        /// public propaty name  :  ShelfNo
        /// <summary>棚番プロパティ</summary>
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

        /// public propaty name  :  AdditionalDivCd
        /// <summary>追加区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AdditionalDivCd
        {
            get { return _additionalDivCd; }
            set { _additionalDivCd = value; }
        }

        /// public propaty name  :  CorrectDivCD
        /// <summary>訂正区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   訂正区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CorrectDivCD
        {
            get { return _correctDivCD; }
            set { _correctDivCD = value; }
        }

        /// public propaty name  :  InqOrdDivCd
        /// <summary>問合せ・発注種別プロパティ</summary>
        /// <value>1:問合せ 2:発注</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ・発注種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InqOrdDivCd
        {
            get { return _inqOrdDivCd; }
            set { _inqOrdDivCd = value; }
        }

        /// public propaty name  :  SalesPriceConsTax
        /// <summary>売上金額消費税額プロパティ</summary>
        /// <value>売上金額（税込み）- 売上金額（税抜き）※消費税調整額も兼ねる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額消費税額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesPriceConsTax
        {
            get { return _salesPriceConsTax; }
            set { _salesPriceConsTax = value; }
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

        /// public propaty name  :  SalesRowNo
        /// <summary>売上行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesRowNo
        {
            get { return _salesRowNo; }
            set { _salesRowNo = value; }
        }

        /// public propaty name  :  CampaignCode
        /// <summary>キャンペーンコードプロパティ</summary>
        /// <value>任意の無重複コードとする（自動付番はしない）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーンコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CampaignCode
        {
            get { return _campaignCode; }
            set { _campaignCode = value; }
        }

        /// public propaty name  :  StockDiv
        /// <summary>在庫区分プロパティ</summary>
        /// <value>委託在庫、得意先在庫、優先倉庫、自社在庫、非在庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockDiv
        {
            get { return _stockDiv; }
            set { _stockDiv = value; }
        }

        /// public propaty name  :  AnswerDelivDate
        /// <summary>回答納期プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnswerDelivDate
        {
            get { return _answerDelivDate; }
            set { _answerDelivDate = value; }
        }

        /// public propaty name  :  RecyclePrtKindCode
        /// <summary>リサイクル部品種別プロパティ</summary>
        /// <value>1:リビルド 2:中古</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   リサイクル部品種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RecyclePrtKindCode
        {
            get { return _recyclePrtKindCode; }
            set { _recyclePrtKindCode = value; }
        }

        /// public propaty name  :  RecyclePrtKindName
        /// <summary>リサイクル部品種別名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   リサイクル部品種別名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RecyclePrtKindName
        {
            get { return _recyclePrtKindName; }
            set { _recyclePrtKindName = value; }
        }

        /// public propaty name  :  InqGoodsName
        /// <summary>問発商品名プロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問発商品名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqGoodsName
        {
            get { return _inqGoodsName; }
            set { _inqGoodsName = value; }
        }

        /// public propaty name  :  AnsGoodsName
        /// <summary>回答商品名プロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答商品名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnsGoodsName
        {
            get { return _ansGoodsName; }
            set { _ansGoodsName = value; }
        }

        /// public propaty name  :  InqPureGoodsNo
        /// <summary>問発純正商品番号プロパティ</summary>
        /// <value>(半角のみ)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問発純正商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqPureGoodsNo
        {
            get { return _inqPureGoodsNo; }
            set { _inqPureGoodsNo = value; }
        }

        /// public propaty name  :  AnsPureGoodsNo
        /// <summary>回答純正商品番号プロパティ</summary>
        /// <value>(半角のみ)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答純正商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnsPureGoodsNo
        {
            get { return _ansPureGoodsNo; }
            set { _ansPureGoodsNo = value; }
        }

        /// public propaty name  :  CancelCndtinDiv
        /// <summary>キャンセル状態区分プロパティ</summary>
        /// <value>0:キャンセルなし 10:キャンセル要求 20:キャンセル却下 30:キャンセル確定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンセル状態区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 CancelCndtinDiv
        {
            get { return _cancelCndtinDiv; }
            set { _cancelCndtinDiv = value; }
        }


        /// <summary>
        /// SCM問い合わせ一覧抽出結果(明細回答)クラスワークコンストラクタ
        /// </summary>
        /// <returns>SCMInquiryDtlAnsResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMInquiryDtlAnsResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SCMInquiryDtlAnsResultWork()
        {
        }

    }
    */
    # endregion

    /// public class name:   SCMInquiryDtlAnsResultWork
    /// <summary>
    ///                      SCM問い合わせ一覧抽出結果(明細回答)クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM問い合わせ一覧抽出結果(明細回答)クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    2009/4/13</br>
    /// <br>Genarated Date   :   2011/05/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2011/5/26  久保田</br>
    /// <br>                 :   倉庫コード を追加</br>
    /// <br>                 :   倉庫名称 を追加</br>
    /// <br>                 :   倉庫棚番 を追加</br>
    /// <br>Update Note      :   管理番号  10900690-00 作成担当 : qijh</br>
    /// <br>                 :   2013/06/18配信 Redmine#34752 「PMSCMのNo.10385」BLPの対応 </br>
    /// <br>Update Note      :   2015/02/20 吉岡  管理番号 11070266-00  </br>
    /// <br>                 :   SCM高速化 C向け種別特記対応 </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SCMInquiryDtlAnsResultWork
    {
        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先名称</summary>
        private string _customerName = "";

        /// <summary>売上日付</summary>
        /// <remarks>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</remarks>
        private DateTime _salesDate;

        /// <summary>受注ステータス</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>売上伝票番号</summary>
        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
        private string _salesSlipNum = "";

        /// <summary>売上金額（税抜き）</summary>
        private Int64 _salesMoneyTaxExc;

        /// <summary>問合せ元企業コード</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>問合せ元拠点コード</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>問合せ先企業コード</summary>
        private string _inqOtherEpCd = "";

        /// <summary>問合せ先拠点コード</summary>
        private string _inqOtherSecCd = "";

        /// <summary>問合せ番号</summary>
        private Int64 _inquiryNumber;

        /// <summary>更新年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _updateDate;

        /// <summary>更新時間</summary>
        /// <remarks>HHMMSSXXX</remarks>
        private Int32 _updateTime;

        /// <summary>問合せ行番号</summary>
        private Int32 _inqRowNumber;

        /// <summary>問合せ行番号枝番</summary>
        private Int32 _inqRowNumDerivedNo;

        /// <summary>問合せ元明細識別GUID</summary>
        private Guid _inqOrgDtlDiscGuid;

        /// <summary>問合せ先明細識別GUID</summary>
        /// <remarks>回答データの場合有効、問合せ／発注元の明細GUIDを設定</remarks>
        private Guid _inqOthDtlDiscGuid;

        /// <summary>商品種別</summary>
        /// <remarks>0:純正部品 1:優良部品 2:リビルド 3:中古 4:平均相場</remarks>
        private Int32 _goodsDivCd;

        /// <summary>納品区分</summary>
        /// <remarks>0:配送,1:引取</remarks>
        private Int32 _deliveredGoodsDiv;

        /// <summary>取扱区分</summary>
        /// <remarks>0:取り扱い品,1:納期確認中,2:未取り扱い品</remarks>
        private Int32 _handleDivCode;

        /// <summary>商品形態</summary>
        /// <remarks>1:部品,2:用品</remarks>
        private Int32 _goodsShape;

        /// <summary>納品確認区分</summary>
        /// <remarks>0:未確認,1:確認</remarks>
        private Int32 _delivrdGdsConfCd;

        /// <summary>納品完了予定日</summary>
        /// <remarks>納品予定日付 YYYYMMDD</remarks>
        private DateTime _deliGdsCmpltDueDate;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード枝番</summary>
        private Int32 _bLGoodsDrCode;

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>発注数</summary>
        private Double _salesOrderCount;

        /// <summary>納品数</summary>
        private Double _deliveredGoodsCount;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>純正商品メーカーコード</summary>
        private Int32 _pureGoodsMakerCd;

        /// <summary>純正商品番号</summary>
        private string _pureGoodsNo = "";

        /// <summary>定価</summary>
        /// <remarks>0:オープン価格</remarks>
        private Int64 _listPrice;

        /// <summary>単価</summary>
        private Int64 _unitPrice;

        /// <summary>明細取込区分</summary>
        /// <remarks>0:未取込 1:取込済</remarks>
        private Int32 _dtlTakeinDivCd;

        /// <summary>商品補足情報</summary>
        private string _goodsAddInfo = "";

        /// <summary>粗利額</summary>
        private Int64 _roughRrofit;

        /// <summary>粗利率</summary>
        private Double _roughRate;

        /// <summary>回答期限</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _answerLimitDate;

        /// <summary>備考(明細)</summary>
        private string _commentDtl = "";

        /// <summary>棚番</summary>
        private string _shelfNo = "";

        /// <summary>追加区分</summary>
        private Int32 _additionalDivCd;

        /// <summary>訂正区分</summary>
        private Int32 _correctDivCD;

        /// <summary>問合せ・発注種別</summary>
        /// <remarks>1:問合せ 2:発注</remarks>
        private Int32 _inqOrdDivCd;

        /// <summary>売上金額消費税額</summary>
        /// <remarks>売上金額（税込み）- 売上金額（税抜き）※消費税調整額も兼ねる</remarks>
        private Int64 _salesPriceConsTax;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>売上行番号</summary>
        private Int32 _salesRowNo;

        /// <summary>キャンペーンコード</summary>
        /// <remarks>任意の無重複コードとする（自動付番はしない）</remarks>
        private Int32 _campaignCode;

        /// <summary>在庫区分</summary>
        /// <remarks>委託在庫、得意先在庫、優先倉庫、自社在庫、非在庫</remarks>
        private Int32 _stockDiv;

        /// <summary>回答納期</summary>
        private string _answerDelivDate = "";

        /// <summary>リサイクル部品種別</summary>
        /// <remarks>1:リビルド 2:中古</remarks>
        private Int32 _recyclePrtKindCode;

        /// <summary>リサイクル部品種別名称</summary>
        private string _recyclePrtKindName = "";

        /// <summary>問発商品名</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _inqGoodsName = "";

        /// <summary>回答商品名</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _ansGoodsName = "";

        /// <summary>問発純正商品番号</summary>
        /// <remarks>(半角のみ)</remarks>
        private string _inqPureGoodsNo = "";

        /// <summary>回答純正商品番号</summary>
        /// <remarks>(半角のみ)</remarks>
        private string _ansPureGoodsNo = "";

        /// <summary>キャンセル状態区分</summary>
        /// <remarks>0:キャンセルなし 10:キャンセル要求 20:キャンセル却下 30:キャンセル確定</remarks>
        private Int16 _cancelCndtinDiv;

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>倉庫名称</summary>
        private string _warehouseName = "";

        /// <summary>倉庫棚番</summary>
        private string _warehouseShelfNo = "";

        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        /// <summary>PM主管倉庫コード</summary>
        private string _pmMainMngWarehouseCd = "";

        /// <summary>PM主管倉庫名称</summary>
        private string _pmMainMngWarehouseName = "";

        /// <summary>PM主管棚番</summary>
        private string _pmMainMngShelfNo = "";

        /// <summary>PM主管現在個数</summary>
        private Double _pmMainMngPrsntCount;
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

        // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   -------------->>>>>>>>>>>>>>>>>>>>
        /// <summary> 商品規格・特記事項(工場向け) </summary>
        private string _goodsSpecialNtForFac;

        /// <summary> 商品規格・特記事項(カーオーナー向け) </summary>
        private string _goodsSpecialNtForCOw;

        /// <summary> 優良設定詳細名称２(工場向け) </summary>
        private string _prmSetDtlName2ForFac;

        /// <summary> 優良設定詳細名称２(カーオーナー向け) </summary>
        private string _prmSetDtlName2ForCOw;
        // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   --------------<<<<<<<<<<<<<<<<<<<<

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

        /// public propaty name  :  CustomerName
        /// <summary>得意先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>売上日付プロパティ</summary>
        /// <value>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>10:見積,20:受注,30:売上,40:出荷</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>売上伝票番号プロパティ</summary>
        /// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc
        /// <summary>売上金額（税抜き）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>問合せ元企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
        }

        /// public propaty name  :  InqOriginalSecCd
        /// <summary>問合せ元拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOriginalSecCd
        {
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
        }

        /// public propaty name  :  InqOtherEpCd
        /// <summary>問合せ先企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ先企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOtherEpCd
        {
            get { return _inqOtherEpCd; }
            set { _inqOtherEpCd = value; }
        }

        /// public propaty name  :  InqOtherSecCd
        /// <summary>問合せ先拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ先拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOtherSecCd
        {
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
        }

        /// public propaty name  :  InquiryNumber
        /// <summary>問合せ番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 InquiryNumber
        {
            get { return _inquiryNumber; }
            set { _inquiryNumber = value; }
        }

        /// public propaty name  :  UpdateDate
        /// <summary>更新年月日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

        /// public propaty name  :  UpdateTime
        /// <summary>更新時間プロパティ</summary>
        /// <value>HHMMSSXXX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新時間プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateTime
        {
            get { return _updateTime; }
            set { _updateTime = value; }
        }

        /// public propaty name  :  InqRowNumber
        /// <summary>問合せ行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InqRowNumber
        {
            get { return _inqRowNumber; }
            set { _inqRowNumber = value; }
        }

        /// public propaty name  :  InqRowNumDerivedNo
        /// <summary>問合せ行番号枝番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ行番号枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InqRowNumDerivedNo
        {
            get { return _inqRowNumDerivedNo; }
            set { _inqRowNumDerivedNo = value; }
        }

        /// public propaty name  :  InqOrgDtlDiscGuid
        /// <summary>問合せ元明細識別GUIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元明細識別GUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid InqOrgDtlDiscGuid
        {
            get { return _inqOrgDtlDiscGuid; }
            set { _inqOrgDtlDiscGuid = value; }
        }

        /// public propaty name  :  InqOthDtlDiscGuid
        /// <summary>問合せ先明細識別GUIDプロパティ</summary>
        /// <value>回答データの場合有効、問合せ／発注元の明細GUIDを設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ先明細識別GUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid InqOthDtlDiscGuid
        {
            get { return _inqOthDtlDiscGuid; }
            set { _inqOthDtlDiscGuid = value; }
        }

        /// public propaty name  :  GoodsDivCd
        /// <summary>商品種別プロパティ</summary>
        /// <value>0:純正部品 1:優良部品 2:リビルド 3:中古 4:平均相場</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsDivCd
        {
            get { return _goodsDivCd; }
            set { _goodsDivCd = value; }
        }

        /// public propaty name  :  DeliveredGoodsDiv
        /// <summary>納品区分プロパティ</summary>
        /// <value>0:配送,1:引取</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeliveredGoodsDiv
        {
            get { return _deliveredGoodsDiv; }
            set { _deliveredGoodsDiv = value; }
        }

        /// public propaty name  :  HandleDivCode
        /// <summary>取扱区分プロパティ</summary>
        /// <value>0:取り扱い品,1:納期確認中,2:未取り扱い品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取扱区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HandleDivCode
        {
            get { return _handleDivCode; }
            set { _handleDivCode = value; }
        }

        /// public propaty name  :  GoodsShape
        /// <summary>商品形態プロパティ</summary>
        /// <value>1:部品,2:用品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品形態プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsShape
        {
            get { return _goodsShape; }
            set { _goodsShape = value; }
        }

        /// public propaty name  :  DelivrdGdsConfCd
        /// <summary>納品確認区分プロパティ</summary>
        /// <value>0:未確認,1:確認</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品確認区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DelivrdGdsConfCd
        {
            get { return _delivrdGdsConfCd; }
            set { _delivrdGdsConfCd = value; }
        }

        /// public propaty name  :  DeliGdsCmpltDueDate
        /// <summary>納品完了予定日プロパティ</summary>
        /// <value>納品予定日付 YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime DeliGdsCmpltDueDate
        {
            get { return _deliGdsCmpltDueDate; }
            set { _deliGdsCmpltDueDate = value; }
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

        /// public propaty name  :  BLGoodsDrCode
        /// <summary>BL商品コード枝番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsDrCode
        {
            get { return _bLGoodsDrCode; }
            set { _bLGoodsDrCode = value; }
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

        /// public propaty name  :  DeliveredGoodsCount
        /// <summary>納品数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double DeliveredGoodsCount
        {
            get { return _deliveredGoodsCount; }
            set { _deliveredGoodsCount = value; }
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

        /// public propaty name  :  PureGoodsMakerCd
        /// <summary>純正商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PureGoodsMakerCd
        {
            get { return _pureGoodsMakerCd; }
            set { _pureGoodsMakerCd = value; }
        }

        /// public propaty name  :  PureGoodsNo
        /// <summary>純正商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PureGoodsNo
        {
            get { return _pureGoodsNo; }
            set { _pureGoodsNo = value; }
        }

        /// public propaty name  :  ListPrice
        /// <summary>定価プロパティ</summary>
        /// <value>0:オープン価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        /// public propaty name  :  UnitPrice
        /// <summary>単価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        /// public propaty name  :  DtlTakeinDivCd
        /// <summary>明細取込区分プロパティ</summary>
        /// <value>0:未取込 1:取込済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細取込区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DtlTakeinDivCd
        {
            get { return _dtlTakeinDivCd; }
            set { _dtlTakeinDivCd = value; }
        }

        /// public propaty name  :  GoodsAddInfo
        /// <summary>商品補足情報プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品補足情報プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsAddInfo
        {
            get { return _goodsAddInfo; }
            set { _goodsAddInfo = value; }
        }

        /// public propaty name  :  RoughRrofit
        /// <summary>粗利額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 RoughRrofit
        {
            get { return _roughRrofit; }
            set { _roughRrofit = value; }
        }

        /// public propaty name  :  RoughRate
        /// <summary>粗利率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double RoughRate
        {
            get { return _roughRate; }
            set { _roughRate = value; }
        }

        /// public propaty name  :  AnswerLimitDate
        /// <summary>回答期限プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答期限プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AnswerLimitDate
        {
            get { return _answerLimitDate; }
            set { _answerLimitDate = value; }
        }

        /// public propaty name  :  CommentDtl
        /// <summary>備考(明細)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考(明細)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CommentDtl
        {
            get { return _commentDtl; }
            set { _commentDtl = value; }
        }

        /// public propaty name  :  ShelfNo
        /// <summary>棚番プロパティ</summary>
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

        /// public propaty name  :  AdditionalDivCd
        /// <summary>追加区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AdditionalDivCd
        {
            get { return _additionalDivCd; }
            set { _additionalDivCd = value; }
        }

        /// public propaty name  :  CorrectDivCD
        /// <summary>訂正区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   訂正区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CorrectDivCD
        {
            get { return _correctDivCD; }
            set { _correctDivCD = value; }
        }

        /// public propaty name  :  InqOrdDivCd
        /// <summary>問合せ・発注種別プロパティ</summary>
        /// <value>1:問合せ 2:発注</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ・発注種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InqOrdDivCd
        {
            get { return _inqOrdDivCd; }
            set { _inqOrdDivCd = value; }
        }

        /// public propaty name  :  SalesPriceConsTax
        /// <summary>売上金額消費税額プロパティ</summary>
        /// <value>売上金額（税込み）- 売上金額（税抜き）※消費税調整額も兼ねる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額消費税額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesPriceConsTax
        {
            get { return _salesPriceConsTax; }
            set { _salesPriceConsTax = value; }
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

        /// public propaty name  :  SalesRowNo
        /// <summary>売上行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesRowNo
        {
            get { return _salesRowNo; }
            set { _salesRowNo = value; }
        }

        /// public propaty name  :  CampaignCode
        /// <summary>キャンペーンコードプロパティ</summary>
        /// <value>任意の無重複コードとする（自動付番はしない）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーンコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CampaignCode
        {
            get { return _campaignCode; }
            set { _campaignCode = value; }
        }

        /// public propaty name  :  StockDiv
        /// <summary>在庫区分プロパティ</summary>
        /// <value>委託在庫、得意先在庫、優先倉庫、自社在庫、非在庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockDiv
        {
            get { return _stockDiv; }
            set { _stockDiv = value; }
        }

        /// public propaty name  :  AnswerDelivDate
        /// <summary>回答納期プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnswerDelivDate
        {
            get { return _answerDelivDate; }
            set { _answerDelivDate = value; }
        }

        /// public propaty name  :  RecyclePrtKindCode
        /// <summary>リサイクル部品種別プロパティ</summary>
        /// <value>1:リビルド 2:中古</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   リサイクル部品種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RecyclePrtKindCode
        {
            get { return _recyclePrtKindCode; }
            set { _recyclePrtKindCode = value; }
        }

        /// public propaty name  :  RecyclePrtKindName
        /// <summary>リサイクル部品種別名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   リサイクル部品種別名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RecyclePrtKindName
        {
            get { return _recyclePrtKindName; }
            set { _recyclePrtKindName = value; }
        }

        /// public propaty name  :  InqGoodsName
        /// <summary>問発商品名プロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問発商品名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqGoodsName
        {
            get { return _inqGoodsName; }
            set { _inqGoodsName = value; }
        }

        /// public propaty name  :  AnsGoodsName
        /// <summary>回答商品名プロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答商品名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnsGoodsName
        {
            get { return _ansGoodsName; }
            set { _ansGoodsName = value; }
        }

        /// public propaty name  :  InqPureGoodsNo
        /// <summary>問発純正商品番号プロパティ</summary>
        /// <value>(半角のみ)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問発純正商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqPureGoodsNo
        {
            get { return _inqPureGoodsNo; }
            set { _inqPureGoodsNo = value; }
        }

        /// public propaty name  :  AnsPureGoodsNo
        /// <summary>回答純正商品番号プロパティ</summary>
        /// <value>(半角のみ)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答純正商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnsPureGoodsNo
        {
            get { return _ansPureGoodsNo; }
            set { _ansPureGoodsNo = value; }
        }

        /// public propaty name  :  CancelCndtinDiv
        /// <summary>キャンセル状態区分プロパティ</summary>
        /// <value>0:キャンセルなし 10:キャンセル要求 20:キャンセル却下 30:キャンセル確定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンセル状態区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 CancelCndtinDiv
        {
            get { return _cancelCndtinDiv; }
            set { _cancelCndtinDiv = value; }
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

        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        /// public propaty name  :  PmMainMngWarehouseCd
        /// <summary>PM主管倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM主管倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PmMainMngWarehouseCd
        {
            get { return _pmMainMngWarehouseCd; }
            set { _pmMainMngWarehouseCd = value; }
        }

        /// public propaty name  :  PmMainMngWarehouseName
        /// <summary>PM主管倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM主管倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PmMainMngWarehouseName
        {
            get { return _pmMainMngWarehouseName; }
            set { _pmMainMngWarehouseName = value; }
        }

        /// public propaty name  :  PmMainMngShelfNo
        /// <summary>PM主管棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM主管棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PmMainMngShelfNo
        {
            get { return _pmMainMngShelfNo; }
            set { _pmMainMngShelfNo = value; }
        }

        /// public propaty name  :  PmMainMngPrsntCount
        /// <summary>PM主管現在個数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM主管現在個数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PmMainMngPrsntCount
        {
            get { return _pmMainMngPrsntCount; }
            set { _pmMainMngPrsntCount = value; }
        }
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

        // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   -------------->>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  GoodsSpecialNtForFac
        /// <summary>商品規格・特記事項(工場向け)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品規格・特記事項(工場向け)プロパティ</br>
        /// </remarks>
        public string GoodsSpecialNtForFac
        {
            get { return _goodsSpecialNtForFac; }
            set { _goodsSpecialNtForFac = value; }
        }

        /// public propaty name  :  GoodsSpecialNtForCOw
        /// <summary>商品規格・特記事項(カーオーナー向け)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品規格・特記事項(カーオーナー向け)プロパティ</br>
        /// </remarks>
        public string GoodsSpecialNtForCOw
        {
            get { return _goodsSpecialNtForCOw; }
            set { _goodsSpecialNtForCOw = value; }
        }

        /// public propaty name  :  PrmSetDtlName2ForFac
        /// <summary>優良設定詳細名称２(工場向け)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細名称２(工場向け)プロパティ</br>
        /// </remarks>
        public string PrmSetDtlName2ForFac
        {
            get { return _prmSetDtlName2ForFac; }
            set { _prmSetDtlName2ForFac = value; }
        }

        /// public propaty name  :  PrmSetDtlName2ForCOw
        /// <summary>優良設定詳細名称２(カーオーナー向け)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細名称２(カーオーナー向け)プロパティ</br>
        /// </remarks>
        public string PrmSetDtlName2ForCOw
        {
            get { return _prmSetDtlName2ForCOw; }
            set { _prmSetDtlName2ForCOw = value; }
        }
        // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   --------------<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// SCM問い合わせ一覧抽出結果(明細回答)クラスワークコンストラクタ
        /// </summary>
        /// <returns>SCMInquiryDtlAnsResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMInquiryDtlAnsResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SCMInquiryDtlAnsResultWork()
        {
        }

    }

    # region --- DEL 2011/05/26 ---
    /*
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SCMInquiryDtlAnsResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SCMInquiryDtlAnsResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SCMInquiryDtlAnsResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMInquiryDtlAnsResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SCMInquiryDtlAnsResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SCMInquiryDtlAnsResultWork || graph is ArrayList || graph is SCMInquiryDtlAnsResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SCMInquiryDtlAnsResultWork).FullName));

            if (graph != null && graph is SCMInquiryDtlAnsResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMInquiryDtlAnsResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SCMInquiryDtlAnsResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SCMInquiryDtlAnsResultWork[])graph).Length;
            }
            else if (graph is SCMInquiryDtlAnsResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先名称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //売上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //受注ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //売上伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //売上金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //問合せ元企業コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalEpCd
            //問合せ元拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalSecCd
            //問合せ先企業コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
            //問合せ先拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
            //問合せ番号
            serInfo.MemberInfo.Add(typeof(Int64)); //InquiryNumber
            //更新年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDate
            //更新時間
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateTime
            //問合せ行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //InqRowNumber
            //問合せ行番号枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //InqRowNumDerivedNo
            //問合せ元明細識別GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //InqOrgDtlDiscGuid
            //問合せ先明細識別GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //InqOthDtlDiscGuid
            //商品種別
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsDivCd
            //納品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliveredGoodsDiv
            //取扱区分
            serInfo.MemberInfo.Add(typeof(Int32)); //HandleDivCode
            //商品形態
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsShape
            //納品確認区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DelivrdGdsConfCd
            //納品完了予定日
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliGdsCmpltDueDate
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL商品コード枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsDrCode
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //発注数
            serInfo.MemberInfo.Add(typeof(Double)); //SalesOrderCount
            //納品数
            serInfo.MemberInfo.Add(typeof(Double)); //DeliveredGoodsCount
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //純正商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //PureGoodsMakerCd
            //純正商品番号
            serInfo.MemberInfo.Add(typeof(string)); //PureGoodsNo
            //定価
            serInfo.MemberInfo.Add(typeof(Int64)); //ListPrice
            //単価
            serInfo.MemberInfo.Add(typeof(Int64)); //UnitPrice
            //明細取込区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DtlTakeinDivCd
            //商品補足情報
            serInfo.MemberInfo.Add(typeof(string)); //GoodsAddInfo
            //粗利額
            serInfo.MemberInfo.Add(typeof(Int64)); //RoughRrofit
            //粗利率
            serInfo.MemberInfo.Add(typeof(Double)); //RoughRate
            //回答期限
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerLimitDate
            //備考(明細)
            serInfo.MemberInfo.Add(typeof(string)); //CommentDtl
            //棚番
            serInfo.MemberInfo.Add(typeof(string)); //ShelfNo
            //追加区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AdditionalDivCd
            //訂正区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CorrectDivCD
            //問合せ・発注種別
            serInfo.MemberInfo.Add(typeof(Int32)); //InqOrdDivCd
            //売上金額消費税額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesPriceConsTax
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //売上行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo
            //キャンペーンコード
            serInfo.MemberInfo.Add(typeof(Int32)); //CampaignCode
            //在庫区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDiv
            //回答納期
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate
            //リサイクル部品種別
            serInfo.MemberInfo.Add(typeof(Int32)); //RecyclePrtKindCode
            //リサイクル部品種別名称
            serInfo.MemberInfo.Add(typeof(string)); //RecyclePrtKindName
            //問発商品名
            serInfo.MemberInfo.Add(typeof(string)); //InqGoodsName
            //回答商品名
            serInfo.MemberInfo.Add(typeof(string)); //AnsGoodsName
            //問発純正商品番号
            serInfo.MemberInfo.Add(typeof(string)); //InqPureGoodsNo
            //回答純正商品番号
            serInfo.MemberInfo.Add(typeof(string)); //AnsPureGoodsNo
            //キャンセル状態区分
            serInfo.MemberInfo.Add(typeof(Int16)); //CancelCndtinDiv


            serInfo.Serialize(writer, serInfo);
            if (graph is SCMInquiryDtlAnsResultWork)
            {
                SCMInquiryDtlAnsResultWork temp = (SCMInquiryDtlAnsResultWork)graph;

                SetSCMInquiryDtlAnsResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SCMInquiryDtlAnsResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SCMInquiryDtlAnsResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SCMInquiryDtlAnsResultWork temp in lst)
                {
                    SetSCMInquiryDtlAnsResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SCMInquiryDtlAnsResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 57;

        /// <summary>
        ///  SCMInquiryDtlAnsResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMInquiryDtlAnsResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSCMInquiryDtlAnsResultWork(System.IO.BinaryWriter writer, SCMInquiryDtlAnsResultWork temp)
        {
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先名称
            writer.Write(temp.CustomerName);
            //売上日付
            writer.Write((Int64)temp.SalesDate.Ticks);
            //受注ステータス
            writer.Write(temp.AcptAnOdrStatus);
            //売上伝票番号
            writer.Write(temp.SalesSlipNum);
            //売上金額（税抜き）
            writer.Write(temp.SalesMoneyTaxExc);
            //問合せ元企業コード
            writer.Write(temp.InqOriginalEpCd);
            //問合せ元拠点コード
            writer.Write(temp.InqOriginalSecCd);
            //問合せ先企業コード
            writer.Write(temp.InqOtherEpCd);
            //問合せ先拠点コード
            writer.Write(temp.InqOtherSecCd);
            //問合せ番号
            writer.Write(temp.InquiryNumber);
            //更新年月日
            writer.Write((Int64)temp.UpdateDate.Ticks);
            //更新時間
            writer.Write(temp.UpdateTime);
            //問合せ行番号
            writer.Write(temp.InqRowNumber);
            //問合せ行番号枝番
            writer.Write(temp.InqRowNumDerivedNo);
            //問合せ元明細識別GUID
            byte[] inqOrgDtlDiscGuidArray = temp.InqOrgDtlDiscGuid.ToByteArray();
            writer.Write(inqOrgDtlDiscGuidArray.Length);
            writer.Write(temp.InqOrgDtlDiscGuid.ToByteArray());
            //問合せ先明細識別GUID
            byte[] inqOthDtlDiscGuidArray = temp.InqOthDtlDiscGuid.ToByteArray();
            writer.Write(inqOthDtlDiscGuidArray.Length);
            writer.Write(temp.InqOthDtlDiscGuid.ToByteArray());
            //商品種別
            writer.Write(temp.GoodsDivCd);
            //納品区分
            writer.Write(temp.DeliveredGoodsDiv);
            //取扱区分
            writer.Write(temp.HandleDivCode);
            //商品形態
            writer.Write(temp.GoodsShape);
            //納品確認区分
            writer.Write(temp.DelivrdGdsConfCd);
            //納品完了予定日
            writer.Write((Int64)temp.DeliGdsCmpltDueDate.Ticks);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //BL商品コード枝番
            writer.Write(temp.BLGoodsDrCode);
            //商品名称
            writer.Write(temp.GoodsName);
            //発注数
            writer.Write(temp.SalesOrderCount);
            //納品数
            writer.Write(temp.DeliveredGoodsCount);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //純正商品メーカーコード
            writer.Write(temp.PureGoodsMakerCd);
            //純正商品番号
            writer.Write(temp.PureGoodsNo);
            //定価
            writer.Write(temp.ListPrice);
            //単価
            writer.Write(temp.UnitPrice);
            //明細取込区分
            writer.Write(temp.DtlTakeinDivCd);
            //商品補足情報
            writer.Write(temp.GoodsAddInfo);
            //粗利額
            writer.Write(temp.RoughRrofit);
            //粗利率
            writer.Write(temp.RoughRate);
            //回答期限
            writer.Write(temp.AnswerLimitDate);
            //備考(明細)
            writer.Write(temp.CommentDtl);
            //棚番
            writer.Write(temp.ShelfNo);
            //追加区分
            writer.Write(temp.AdditionalDivCd);
            //訂正区分
            writer.Write(temp.CorrectDivCD);
            //問合せ・発注種別
            writer.Write(temp.InqOrdDivCd);
            //売上金額消費税額
            writer.Write(temp.SalesPriceConsTax);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //売上行番号
            writer.Write(temp.SalesRowNo);
            //キャンペーンコード
            writer.Write(temp.CampaignCode);
            //在庫区分
            writer.Write(temp.StockDiv);
            //回答納期
            writer.Write(temp.AnswerDelivDate);
            //リサイクル部品種別
            writer.Write(temp.RecyclePrtKindCode);
            //リサイクル部品種別名称
            writer.Write(temp.RecyclePrtKindName);
            //問発商品名
            writer.Write(temp.InqGoodsName);
            //回答商品名
            writer.Write(temp.AnsGoodsName);
            //問発純正商品番号
            writer.Write(temp.InqPureGoodsNo);
            //回答純正商品番号
            writer.Write(temp.AnsPureGoodsNo);
            //キャンセル状態区分
            writer.Write(temp.CancelCndtinDiv);

        }

        /// <summary>
        ///  SCMInquiryDtlAnsResultWorkインスタンス取得
        /// </summary>
        /// <returns>SCMInquiryDtlAnsResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMInquiryDtlAnsResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SCMInquiryDtlAnsResultWork GetSCMInquiryDtlAnsResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SCMInquiryDtlAnsResultWork temp = new SCMInquiryDtlAnsResultWork();

            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先名称
            temp.CustomerName = reader.ReadString();
            //売上日付
            temp.SalesDate = new DateTime(reader.ReadInt64());
            //受注ステータス
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //売上伝票番号
            temp.SalesSlipNum = reader.ReadString();
            //売上金額（税抜き）
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //問合せ元企業コード
            temp.InqOriginalEpCd = reader.ReadString();
            //問合せ元拠点コード
            temp.InqOriginalSecCd = reader.ReadString();
            //問合せ先企業コード
            temp.InqOtherEpCd = reader.ReadString();
            //問合せ先拠点コード
            temp.InqOtherSecCd = reader.ReadString();
            //問合せ番号
            temp.InquiryNumber = reader.ReadInt64();
            //更新年月日
            temp.UpdateDate = new DateTime(reader.ReadInt64());
            //更新時間
            temp.UpdateTime = reader.ReadInt32();
            //問合せ行番号
            temp.InqRowNumber = reader.ReadInt32();
            //問合せ行番号枝番
            temp.InqRowNumDerivedNo = reader.ReadInt32();
            //問合せ元明細識別GUID
            int lenOfInqOrgDtlDiscGuidArray = reader.ReadInt32();
            byte[] inqOrgDtlDiscGuidArray = reader.ReadBytes(lenOfInqOrgDtlDiscGuidArray);
            temp.InqOrgDtlDiscGuid = new Guid(inqOrgDtlDiscGuidArray);
            //問合せ先明細識別GUID
            int lenOfInqOthDtlDiscGuidArray = reader.ReadInt32();
            byte[] inqOthDtlDiscGuidArray = reader.ReadBytes(lenOfInqOthDtlDiscGuidArray);
            temp.InqOthDtlDiscGuid = new Guid(inqOthDtlDiscGuidArray);
            //商品種別
            temp.GoodsDivCd = reader.ReadInt32();
            //納品区分
            temp.DeliveredGoodsDiv = reader.ReadInt32();
            //取扱区分
            temp.HandleDivCode = reader.ReadInt32();
            //商品形態
            temp.GoodsShape = reader.ReadInt32();
            //納品確認区分
            temp.DelivrdGdsConfCd = reader.ReadInt32();
            //納品完了予定日
            temp.DeliGdsCmpltDueDate = new DateTime(reader.ReadInt64());
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //BL商品コード枝番
            temp.BLGoodsDrCode = reader.ReadInt32();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //発注数
            temp.SalesOrderCount = reader.ReadDouble();
            //納品数
            temp.DeliveredGoodsCount = reader.ReadDouble();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //純正商品メーカーコード
            temp.PureGoodsMakerCd = reader.ReadInt32();
            //純正商品番号
            temp.PureGoodsNo = reader.ReadString();
            //定価
            temp.ListPrice = reader.ReadInt64();
            //単価
            temp.UnitPrice = reader.ReadInt64();
            //明細取込区分
            temp.DtlTakeinDivCd = reader.ReadInt32();
            //商品補足情報
            temp.GoodsAddInfo = reader.ReadString();
            //粗利額
            temp.RoughRrofit = reader.ReadInt64();
            //粗利率
            temp.RoughRate = reader.ReadDouble();
            //回答期限
            temp.AnswerLimitDate = reader.ReadInt32();
            //備考(明細)
            temp.CommentDtl = reader.ReadString();
            //棚番
            temp.ShelfNo = reader.ReadString();
            //追加区分
            temp.AdditionalDivCd = reader.ReadInt32();
            //訂正区分
            temp.CorrectDivCD = reader.ReadInt32();
            //問合せ・発注種別
            temp.InqOrdDivCd = reader.ReadInt32();
            //売上金額消費税額
            temp.SalesPriceConsTax = reader.ReadInt64();
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //売上行番号
            temp.SalesRowNo = reader.ReadInt32();
            //キャンペーンコード
            temp.CampaignCode = reader.ReadInt32();
            //在庫区分
            temp.StockDiv = reader.ReadInt32();
            //回答納期
            temp.AnswerDelivDate = reader.ReadString();
            //リサイクル部品種別
            temp.RecyclePrtKindCode = reader.ReadInt32();
            //リサイクル部品種別名称
            temp.RecyclePrtKindName = reader.ReadString();
            //問発商品名
            temp.InqGoodsName = reader.ReadString();
            //回答商品名
            temp.AnsGoodsName = reader.ReadString();
            //問発純正商品番号
            temp.InqPureGoodsNo = reader.ReadString();
            //回答純正商品番号
            temp.AnsPureGoodsNo = reader.ReadString();
            //キャンセル状態区分
            temp.CancelCndtinDiv = reader.ReadInt16();


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
        /// <returns>SCMInquiryDtlAnsResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMInquiryDtlAnsResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SCMInquiryDtlAnsResultWork temp = GetSCMInquiryDtlAnsResultWork(reader, serInfo);
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
                    retValue = (SCMInquiryDtlAnsResultWork[])lst.ToArray(typeof(SCMInquiryDtlAnsResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
    */
    # endregion

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SCMInquiryDtlAnsResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SCMInquiryDtlAnsResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SCMInquiryDtlAnsResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMInquiryDtlAnsResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SCMInquiryDtlAnsResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SCMInquiryDtlAnsResultWork || graph is ArrayList || graph is SCMInquiryDtlAnsResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SCMInquiryDtlAnsResultWork).FullName));

            if (graph != null && graph is SCMInquiryDtlAnsResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMInquiryDtlAnsResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SCMInquiryDtlAnsResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SCMInquiryDtlAnsResultWork[])graph).Length;
            }
            else if (graph is SCMInquiryDtlAnsResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先名称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //売上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //受注ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //売上伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //売上金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //問合せ元企業コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalEpCd
            //問合せ元拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalSecCd
            //問合せ先企業コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
            //問合せ先拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
            //問合せ番号
            serInfo.MemberInfo.Add(typeof(Int64)); //InquiryNumber
            //更新年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDate
            //更新時間
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateTime
            //問合せ行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //InqRowNumber
            //問合せ行番号枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //InqRowNumDerivedNo
            //問合せ元明細識別GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //InqOrgDtlDiscGuid
            //問合せ先明細識別GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //InqOthDtlDiscGuid
            //商品種別
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsDivCd
            //納品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliveredGoodsDiv
            //取扱区分
            serInfo.MemberInfo.Add(typeof(Int32)); //HandleDivCode
            //商品形態
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsShape
            //納品確認区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DelivrdGdsConfCd
            //納品完了予定日
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliGdsCmpltDueDate
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL商品コード枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsDrCode
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //発注数
            serInfo.MemberInfo.Add(typeof(Double)); //SalesOrderCount
            //納品数
            serInfo.MemberInfo.Add(typeof(Double)); //DeliveredGoodsCount
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //純正商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //PureGoodsMakerCd
            //純正商品番号
            serInfo.MemberInfo.Add(typeof(string)); //PureGoodsNo
            //定価
            serInfo.MemberInfo.Add(typeof(Int64)); //ListPrice
            //単価
            serInfo.MemberInfo.Add(typeof(Int64)); //UnitPrice
            //明細取込区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DtlTakeinDivCd
            //商品補足情報
            serInfo.MemberInfo.Add(typeof(string)); //GoodsAddInfo
            //粗利額
            serInfo.MemberInfo.Add(typeof(Int64)); //RoughRrofit
            //粗利率
            serInfo.MemberInfo.Add(typeof(Double)); //RoughRate
            //回答期限
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerLimitDate
            //備考(明細)
            serInfo.MemberInfo.Add(typeof(string)); //CommentDtl
            //棚番
            serInfo.MemberInfo.Add(typeof(string)); //ShelfNo
            //追加区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AdditionalDivCd
            //訂正区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CorrectDivCD
            //問合せ・発注種別
            serInfo.MemberInfo.Add(typeof(Int32)); //InqOrdDivCd
            //売上金額消費税額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesPriceConsTax
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //売上行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo
            //キャンペーンコード
            serInfo.MemberInfo.Add(typeof(Int32)); //CampaignCode
            //在庫区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDiv
            //回答納期
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate
            //リサイクル部品種別
            serInfo.MemberInfo.Add(typeof(Int32)); //RecyclePrtKindCode
            //リサイクル部品種別名称
            serInfo.MemberInfo.Add(typeof(string)); //RecyclePrtKindName
            //問発商品名
            serInfo.MemberInfo.Add(typeof(string)); //InqGoodsName
            //回答商品名
            serInfo.MemberInfo.Add(typeof(string)); //AnsGoodsName
            //問発純正商品番号
            serInfo.MemberInfo.Add(typeof(string)); //InqPureGoodsNo
            //回答純正商品番号
            serInfo.MemberInfo.Add(typeof(string)); //AnsPureGoodsNo
            //キャンセル状態区分
            serInfo.MemberInfo.Add(typeof(Int16)); //CancelCndtinDiv
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //倉庫棚番
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            //PM主管倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //PmMainMngWarehouseCd 
            //PM主管倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //PmMainMngWarehouseName
            //PM主管棚番
            serInfo.MemberInfo.Add(typeof(string)); //PmMainMngShelfNo
            //PM主管現在個数
            serInfo.MemberInfo.Add(typeof(Double)); //PmMainMngPrsntCount
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
            // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   -------------->>>>>>>>>>>>>>>>>>>>
            // 商品規格・特記事項(工場向け)
            serInfo.MemberInfo.Add(typeof(string)); // GoodsSpecialNtForFac 
            // 商品規格・特記事項(カーオーナー向け)
            serInfo.MemberInfo.Add(typeof(string)); // GoodsSpecialNtForCOw 
            // 優良設定詳細名称２(工場向け)
            serInfo.MemberInfo.Add(typeof(string)); // PrmSetDtlName2ForFac
            // 優良設定詳細名称２(カーオーナー向け)
            serInfo.MemberInfo.Add(typeof(string)); // PrmSetDtlName2ForCOw 
            // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   --------------<<<<<<<<<<<<<<<<<<<<
            serInfo.Serialize(writer, serInfo);
            if (graph is SCMInquiryDtlAnsResultWork)
            {
                SCMInquiryDtlAnsResultWork temp = (SCMInquiryDtlAnsResultWork)graph;

                SetSCMInquiryDtlAnsResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SCMInquiryDtlAnsResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SCMInquiryDtlAnsResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SCMInquiryDtlAnsResultWork temp in lst)
                {
                    SetSCMInquiryDtlAnsResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SCMInquiryDtlAnsResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        ////private const int currentMemberCount = 60;// DEL 2013/02/27 qijh #34752
        // private const int currentMemberCount = 64;// ADD 2013/02/27 qijh #34752 // DEL 2015/02/20 吉岡 SCM高速化 C向け種別特記対応
        private const int currentMemberCount = 68;// ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応

        /// <summary>
        ///  SCMInquiryDtlAnsResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMInquiryDtlAnsResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSCMInquiryDtlAnsResultWork(System.IO.BinaryWriter writer, SCMInquiryDtlAnsResultWork temp)
        {
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先名称
            writer.Write(temp.CustomerName);
            //売上日付
            writer.Write((Int64)temp.SalesDate.Ticks);
            //受注ステータス
            writer.Write(temp.AcptAnOdrStatus);
            //売上伝票番号
            writer.Write(temp.SalesSlipNum);
            //売上金額（税抜き）
            writer.Write(temp.SalesMoneyTaxExc);
            //問合せ元企業コード
            writer.Write(temp.InqOriginalEpCd.Trim());	//@@@@20230303
            //問合せ元拠点コード
            writer.Write(temp.InqOriginalSecCd);
            //問合せ先企業コード
            writer.Write(temp.InqOtherEpCd);
            //問合せ先拠点コード
            writer.Write(temp.InqOtherSecCd);
            //問合せ番号
            writer.Write(temp.InquiryNumber);
            //更新年月日
            writer.Write((Int64)temp.UpdateDate.Ticks);
            //更新時間
            writer.Write(temp.UpdateTime);
            //問合せ行番号
            writer.Write(temp.InqRowNumber);
            //問合せ行番号枝番
            writer.Write(temp.InqRowNumDerivedNo);
            //問合せ元明細識別GUID
            byte[] inqOrgDtlDiscGuidArray = temp.InqOrgDtlDiscGuid.ToByteArray();
            writer.Write(inqOrgDtlDiscGuidArray.Length);
            writer.Write(temp.InqOrgDtlDiscGuid.ToByteArray());
            //問合せ先明細識別GUID
            byte[] inqOthDtlDiscGuidArray = temp.InqOthDtlDiscGuid.ToByteArray();
            writer.Write(inqOthDtlDiscGuidArray.Length);
            writer.Write(temp.InqOthDtlDiscGuid.ToByteArray());
            //商品種別
            writer.Write(temp.GoodsDivCd);
            //納品区分
            writer.Write(temp.DeliveredGoodsDiv);
            //取扱区分
            writer.Write(temp.HandleDivCode);
            //商品形態
            writer.Write(temp.GoodsShape);
            //納品確認区分
            writer.Write(temp.DelivrdGdsConfCd);
            //納品完了予定日
            writer.Write((Int64)temp.DeliGdsCmpltDueDate.Ticks);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //BL商品コード枝番
            writer.Write(temp.BLGoodsDrCode);
            //商品名称
            writer.Write(temp.GoodsName);
            //発注数
            writer.Write(temp.SalesOrderCount);
            //納品数
            writer.Write(temp.DeliveredGoodsCount);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //純正商品メーカーコード
            writer.Write(temp.PureGoodsMakerCd);
            //純正商品番号
            writer.Write(temp.PureGoodsNo);
            //定価
            writer.Write(temp.ListPrice);
            //単価
            writer.Write(temp.UnitPrice);
            //明細取込区分
            writer.Write(temp.DtlTakeinDivCd);
            //商品補足情報
            writer.Write(temp.GoodsAddInfo);
            //粗利額
            writer.Write(temp.RoughRrofit);
            //粗利率
            writer.Write(temp.RoughRate);
            //回答期限
            writer.Write(temp.AnswerLimitDate);
            //備考(明細)
            writer.Write(temp.CommentDtl);
            //棚番
            writer.Write(temp.ShelfNo);
            //追加区分
            writer.Write(temp.AdditionalDivCd);
            //訂正区分
            writer.Write(temp.CorrectDivCD);
            //問合せ・発注種別
            writer.Write(temp.InqOrdDivCd);
            //売上金額消費税額
            writer.Write(temp.SalesPriceConsTax);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //売上行番号
            writer.Write(temp.SalesRowNo);
            //キャンペーンコード
            writer.Write(temp.CampaignCode);
            //在庫区分
            writer.Write(temp.StockDiv);
            //回答納期
            writer.Write(temp.AnswerDelivDate);
            //リサイクル部品種別
            writer.Write(temp.RecyclePrtKindCode);
            //リサイクル部品種別名称
            writer.Write(temp.RecyclePrtKindName);
            //問発商品名
            writer.Write(temp.InqGoodsName);
            //回答商品名
            writer.Write(temp.AnsGoodsName);
            //問発純正商品番号
            writer.Write(temp.InqPureGoodsNo);
            //回答純正商品番号
            writer.Write(temp.AnsPureGoodsNo);
            //キャンセル状態区分
            writer.Write(temp.CancelCndtinDiv);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //倉庫名称
            writer.Write(temp.WarehouseName);
            //倉庫棚番
            writer.Write(temp.WarehouseShelfNo);
            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            //PM主管倉庫コード
            writer.Write(temp.PmMainMngWarehouseCd);
            //PM主管倉庫名称
            writer.Write(temp.PmMainMngWarehouseName);
            //PM主管棚番
            writer.Write(temp.PmMainMngShelfNo);
            //PM主管現在個数
            writer.Write(temp.PmMainMngPrsntCount);
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
            // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   -------------->>>>>>>>>>>>>>>>>>>>
            // 商品規格・特記事項(工場向け)
            writer.Write(temp.GoodsSpecialNtForFac);
            // 商品規格・特記事項(カーオーナー向け)
            writer.Write(temp.GoodsSpecialNtForCOw);
            // 優良設定詳細名称２(工場向け)
            writer.Write(temp.PrmSetDtlName2ForFac);
            // 優良設定詳細名称２(カーオーナー向け)
            writer.Write(temp.PrmSetDtlName2ForCOw);
            // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   --------------<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        ///  SCMInquiryDtlAnsResultWorkインスタンス取得
        /// </summary>
        /// <returns>SCMInquiryDtlAnsResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMInquiryDtlAnsResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SCMInquiryDtlAnsResultWork GetSCMInquiryDtlAnsResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SCMInquiryDtlAnsResultWork temp = new SCMInquiryDtlAnsResultWork();

            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先名称
            temp.CustomerName = reader.ReadString();
            //売上日付
            temp.SalesDate = new DateTime(reader.ReadInt64());
            //受注ステータス
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //売上伝票番号
            temp.SalesSlipNum = reader.ReadString();
            //売上金額（税抜き）
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //問合せ元企業コード
            temp.InqOriginalEpCd = reader.ReadString().Trim();//@@@@20230303
            //問合せ元拠点コード
            temp.InqOriginalSecCd = reader.ReadString();
            //問合せ先企業コード
            temp.InqOtherEpCd = reader.ReadString();
            //問合せ先拠点コード
            temp.InqOtherSecCd = reader.ReadString();
            //問合せ番号
            temp.InquiryNumber = reader.ReadInt64();
            //更新年月日
            temp.UpdateDate = new DateTime(reader.ReadInt64());
            //更新時間
            temp.UpdateTime = reader.ReadInt32();
            //問合せ行番号
            temp.InqRowNumber = reader.ReadInt32();
            //問合せ行番号枝番
            temp.InqRowNumDerivedNo = reader.ReadInt32();
            //問合せ元明細識別GUID
            int lenOfInqOrgDtlDiscGuidArray = reader.ReadInt32();
            byte[] inqOrgDtlDiscGuidArray = reader.ReadBytes(lenOfInqOrgDtlDiscGuidArray);
            temp.InqOrgDtlDiscGuid = new Guid(inqOrgDtlDiscGuidArray);
            //問合せ先明細識別GUID
            int lenOfInqOthDtlDiscGuidArray = reader.ReadInt32();
            byte[] inqOthDtlDiscGuidArray = reader.ReadBytes(lenOfInqOthDtlDiscGuidArray);
            temp.InqOthDtlDiscGuid = new Guid(inqOthDtlDiscGuidArray);
            //商品種別
            temp.GoodsDivCd = reader.ReadInt32();
            //納品区分
            temp.DeliveredGoodsDiv = reader.ReadInt32();
            //取扱区分
            temp.HandleDivCode = reader.ReadInt32();
            //商品形態
            temp.GoodsShape = reader.ReadInt32();
            //納品確認区分
            temp.DelivrdGdsConfCd = reader.ReadInt32();
            //納品完了予定日
            temp.DeliGdsCmpltDueDate = new DateTime(reader.ReadInt64());
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //BL商品コード枝番
            temp.BLGoodsDrCode = reader.ReadInt32();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //発注数
            temp.SalesOrderCount = reader.ReadDouble();
            //納品数
            temp.DeliveredGoodsCount = reader.ReadDouble();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //純正商品メーカーコード
            temp.PureGoodsMakerCd = reader.ReadInt32();
            //純正商品番号
            temp.PureGoodsNo = reader.ReadString();
            //定価
            temp.ListPrice = reader.ReadInt64();
            //単価
            temp.UnitPrice = reader.ReadInt64();
            //明細取込区分
            temp.DtlTakeinDivCd = reader.ReadInt32();
            //商品補足情報
            temp.GoodsAddInfo = reader.ReadString();
            //粗利額
            temp.RoughRrofit = reader.ReadInt64();
            //粗利率
            temp.RoughRate = reader.ReadDouble();
            //回答期限
            temp.AnswerLimitDate = reader.ReadInt32();
            //備考(明細)
            temp.CommentDtl = reader.ReadString();
            //棚番
            temp.ShelfNo = reader.ReadString();
            //追加区分
            temp.AdditionalDivCd = reader.ReadInt32();
            //訂正区分
            temp.CorrectDivCD = reader.ReadInt32();
            //問合せ・発注種別
            temp.InqOrdDivCd = reader.ReadInt32();
            //売上金額消費税額
            temp.SalesPriceConsTax = reader.ReadInt64();
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //売上行番号
            temp.SalesRowNo = reader.ReadInt32();
            //キャンペーンコード
            temp.CampaignCode = reader.ReadInt32();
            //在庫区分
            temp.StockDiv = reader.ReadInt32();
            //回答納期
            temp.AnswerDelivDate = reader.ReadString();
            //リサイクル部品種別
            temp.RecyclePrtKindCode = reader.ReadInt32();
            //リサイクル部品種別名称
            temp.RecyclePrtKindName = reader.ReadString();
            //問発商品名
            temp.InqGoodsName = reader.ReadString();
            //回答商品名
            temp.AnsGoodsName = reader.ReadString();
            //問発純正商品番号
            temp.InqPureGoodsNo = reader.ReadString();
            //回答純正商品番号
            temp.AnsPureGoodsNo = reader.ReadString();
            //キャンセル状態区分
            temp.CancelCndtinDiv = reader.ReadInt16();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //倉庫名称
            temp.WarehouseName = reader.ReadString();
            //倉庫棚番
            temp.WarehouseShelfNo = reader.ReadString();
            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            //PM主管倉庫コード
            temp.PmMainMngWarehouseCd = reader.ReadString();
            //PM主管倉庫名称
            temp.PmMainMngWarehouseName = reader.ReadString();
            //PM主管棚番
            temp.PmMainMngShelfNo = reader.ReadString();
            //PM主管現在個数
            temp.PmMainMngPrsntCount = reader.ReadDouble();
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
            // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   -------------->>>>>>>>>>>>>>>>>>>>
            // 商品規格・特記事項(工場向け)
            temp.GoodsSpecialNtForFac = reader.ReadString();
            // 商品規格・特記事項(カーオーナー向け)
            temp.GoodsSpecialNtForCOw = reader.ReadString();
            // 優良設定詳細名称２(工場向け)
            temp.PrmSetDtlName2ForFac = reader.ReadString();
            // 優良設定詳細名称２(カーオーナー向け)
            temp.PrmSetDtlName2ForCOw = reader.ReadString();
            // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   --------------<<<<<<<<<<<<<<<<<<<<

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
        /// <returns>SCMInquiryDtlAnsResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMInquiryDtlAnsResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SCMInquiryDtlAnsResultWork temp = GetSCMInquiryDtlAnsResultWork(reader, serInfo);
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
                    retValue = (SCMInquiryDtlAnsResultWork[])lst.ToArray(typeof(SCMInquiryDtlAnsResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

// 2009.08.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
#region 削除
//using System;
//using System.Collections;
//using Broadleaf.Library.Data;
//using Broadleaf.Library.Runtime.Serialization;
//using Broadleaf.Application.Resources;

//namespace Broadleaf.Application.Remoting.ParamData
//{
//    /// public class name:   SCMInquiryDtlAnsResultWork
//    /// <summary>
//    ///                      SCM問い合わせ一覧抽出結果(明細回答)クラスワーク
//    /// </summary>
//    /// <remarks>
//    /// <br>note             :   SCM問い合わせ一覧抽出結果(明細回答)クラスワークヘッダファイル</br>
//    /// <br>Programmer       :   自動生成</br>
//    /// <br>Date             :    2009/4/13</br>
//    /// <br>Genarated Date   :   2009/06/19  (CSharp File Generated Date)</br>
//    /// <br>Update Note      :   </br>
//    /// </remarks>
//    [Serializable]
//    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
//    public class SCMInquiryDtlAnsResultWork 
//    {
//        /// <summary>得意先コード</summary>
//        private Int32 _customerCode;

//        /// <summary>得意先名称</summary>
//        private string _customerName = "";

//        /// <summary>売上日付</summary>
//        /// <remarks>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</remarks>
//        private DateTime _salesDate;

//        /// <summary>受注ステータス</summary>
//        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
//        private Int32 _acptAnOdrStatus;

//        /// <summary>売上伝票番号</summary>
//        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
//        private string _salesSlipNum = "";

//        /// <summary>売上金額（税抜き）</summary>
//        private Int64 _salesMoneyTaxExc;

//        /// <summary>問合せ元企業コード</summary>
//        private string _inqOriginalEpCd = "";

//        /// <summary>問合せ元拠点コード</summary>
//        private string _inqOriginalSecCd = "";

//        /// <summary>問合せ先企業コード</summary>
//        private string _inqOtherEpCd = "";

//        /// <summary>問合せ先拠点コード</summary>
//        private string _inqOtherSecCd = "";

//        /// <summary>問合せ番号</summary>
//        private Int64 _inquiryNumber;

//        /// <summary>更新年月日</summary>
//        /// <remarks>YYYYMMDD</remarks>
//        private DateTime _updateDate;

//        /// <summary>更新時間</summary>
//        /// <remarks>HHMMSSXXX</remarks>
//        private Int32 _updateTime;

//        /// <summary>問合せ行番号</summary>
//        private Int32 _inqRowNumber;

//        /// <summary>問合せ行番号枝番</summary>
//        private Int32 _inqRowNumDerivedNo;

//        /// <summary>問合せ元明細識別GUID</summary>
//        private Guid _inqOrgDtlDiscGuid;

//        /// <summary>問合せ先明細識別GUID</summary>
//        /// <remarks>回答データの場合有効、問合せ／発注元の明細GUIDを設定</remarks>
//        private Guid _inqOthDtlDiscGuid;

//        /// <summary>商品種別</summary>
//        /// <remarks>0:純正部品 1:優良部品 2:リビルド 3:中古 4:平均相場</remarks>
//        private Int32 _goodsDivCd;

//        /// <summary>納品区分</summary>
//        /// <remarks>0:配送,1:引取</remarks>
//        private Int32 _deliveredGoodsDiv;

//        /// <summary>取扱区分</summary>
//        /// <remarks>0:取り扱い品,1:納期確認中,2:未取り扱い品</remarks>
//        private Int32 _handleDivCode;

//        /// <summary>商品形態</summary>
//        /// <remarks>1:部品,2:用品</remarks>
//        private Int32 _goodsShape;

//        /// <summary>納品確認区分</summary>
//        /// <remarks>0:未確認,1:確認</remarks>
//        private Int32 _delivrdGdsConfCd;

//        /// <summary>納品完了予定日</summary>
//        /// <remarks>納品予定日付 YYYYMMDD</remarks>
//        private DateTime _deliGdsCmpltDueDate;

//        /// <summary>BL商品コード</summary>
//        private Int32 _bLGoodsCode;

//        /// <summary>BL商品コード枝番</summary>
//        private Int32 _bLGoodsDrCode;

//        /// <summary>問発商品名</summary>
//        /// <remarks>(半角全角混在)</remarks>
//        private string _inqGoodsName = "";

//        /// <summary>回答商品名</summary>
//        /// <remarks>(半角全角混在)</remarks>
//        private string _ansGoodsName = "";

//        /// <summary>発注数</summary>
//        private Double _salesOrderCount;

//        /// <summary>納品数</summary>
//        private Double _deliveredGoodsCount;

//        /// <summary>商品番号</summary>
//        private string _goodsNo = "";

//        /// <summary>商品メーカーコード</summary>
//        private Int32 _goodsMakerCd;

//        /// <summary>純正商品メーカーコード</summary>
//        private Int32 _pureGoodsMakerCd;

//        /// <summary>問発純正商品番号</summary>
//        /// <remarks>(半角のみ)</remarks>
//        private string _inqPureGoodsNo = "";

//        /// <summary>回答純正商品番号</summary>
//        /// <remarks>(半角のみ)</remarks>
//        private string _ansPureGoodsNo = "";

//        /// <summary>定価</summary>
//        /// <remarks>0:オープン価格</remarks>
//        private Int64 _listPrice;

//        /// <summary>単価</summary>
//        private Int64 _unitPrice;

//        /// <summary>明細取込区分</summary>
//        /// <remarks>0:未取込 1:取込済</remarks>
//        private Int32 _dtlTakeinDivCd;

//        /// <summary>商品補足情報</summary>
//        private string _goodsAddInfo = "";

//        /// <summary>粗利額</summary>
//        private Int64 _roughRrofit;

//        /// <summary>粗利率</summary>
//        private Double _roughRate;

//        /// <summary>回答期限</summary>
//        /// <remarks>YYYYMMDD</remarks>
//        private Int32 _answerLimitDate;

//        /// <summary>備考(明細)</summary>
//        private string _commentDtl = "";

//        /// <summary>棚番</summary>
//        private string _shelfNo = "";

//        /// <summary>追加区分</summary>
//        private Int32 _additionalDivCd;

//        /// <summary>訂正区分</summary>
//        private Int32 _correctDivCD;

//        /// <summary>問合せ・発注種別</summary>
//        /// <remarks>1:問合せ 2:発注</remarks>
//        private Int32 _inqOrdDivCd;

//        /// <summary>売上金額消費税額</summary>
//        /// <remarks>売上金額（税込み）- 売上金額（税抜き）※消費税調整額も兼ねる</remarks>
//        private Int64 _salesPriceConsTax;

//        /// <summary>企業コード</summary>
//        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
//        private string _enterpriseCode = "";

//        /// <summary>売上行番号</summary>
//        private Int32 _salesRowNo;

//        /// <summary>キャンペーンコード</summary>
//        /// <remarks>任意の無重複コードとする（自動付番はしない）</remarks>
//        private Int32 _campaignCode;

//        /// <summary>在庫区分</summary>
//        /// <remarks>委託在庫、得意先在庫、優先倉庫、自社在庫、非在庫</remarks>
//        private Int32 _stockDiv;

//        /// <summary>回答納期</summary>
//        private string _answerDelivDate = "";


//        /// public propaty name  :  CustomerCode
//        /// <summary>得意先コードプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   得意先コードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 CustomerCode
//        {
//            get { return _customerCode; }
//            set { _customerCode = value; }
//        }

//        /// public propaty name  :  CustomerName
//        /// <summary>得意先名称プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   得意先名称プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string CustomerName
//        {
//            get { return _customerName; }
//            set { _customerName = value; }
//        }

//        /// public propaty name  :  SalesDate
//        /// <summary>売上日付プロパティ</summary>
//        /// <value>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   売上日付プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public DateTime SalesDate
//        {
//            get { return _salesDate; }
//            set { _salesDate = value; }
//        }

//        /// public propaty name  :  AcptAnOdrStatus
//        /// <summary>受注ステータスプロパティ</summary>
//        /// <value>10:見積,20:受注,30:売上,40:出荷</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   受注ステータスプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 AcptAnOdrStatus
//        {
//            get { return _acptAnOdrStatus; }
//            set { _acptAnOdrStatus = value; }
//        }

//        /// public propaty name  :  SalesSlipNum
//        /// <summary>売上伝票番号プロパティ</summary>
//        /// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   売上伝票番号プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string SalesSlipNum
//        {
//            get { return _salesSlipNum; }
//            set { _salesSlipNum = value; }
//        }

//        /// public propaty name  :  SalesMoneyTaxExc
//        /// <summary>売上金額（税抜き）プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   売上金額（税抜き）プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int64 SalesMoneyTaxExc
//        {
//            get { return _salesMoneyTaxExc; }
//            set { _salesMoneyTaxExc = value; }
//        }

//        /// public propaty name  :  InqOriginalEpCd
//        /// <summary>問合せ元企業コードプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   問合せ元企業コードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string InqOriginalEpCd
//        {
//            get { return _inqOriginalEpCd; }
//            set { _inqOriginalEpCd = value; }
//        }

//        /// public propaty name  :  InqOriginalSecCd
//        /// <summary>問合せ元拠点コードプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   問合せ元拠点コードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string InqOriginalSecCd
//        {
//            get { return _inqOriginalSecCd; }
//            set { _inqOriginalSecCd = value; }
//        }

//        /// public propaty name  :  InqOtherEpCd
//        /// <summary>問合せ先企業コードプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   問合せ先企業コードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string InqOtherEpCd
//        {
//            get { return _inqOtherEpCd; }
//            set { _inqOtherEpCd = value; }
//        }

//        /// public propaty name  :  InqOtherSecCd
//        /// <summary>問合せ先拠点コードプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   問合せ先拠点コードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string InqOtherSecCd
//        {
//            get { return _inqOtherSecCd; }
//            set { _inqOtherSecCd = value; }
//        }

//        /// public propaty name  :  InquiryNumber
//        /// <summary>問合せ番号プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   問合せ番号プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int64 InquiryNumber
//        {
//            get { return _inquiryNumber; }
//            set { _inquiryNumber = value; }
//        }

//        /// public propaty name  :  UpdateDate
//        /// <summary>更新年月日プロパティ</summary>
//        /// <value>YYYYMMDD</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   更新年月日プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public DateTime UpdateDate
//        {
//            get { return _updateDate; }
//            set { _updateDate = value; }
//        }

//        /// public propaty name  :  UpdateTime
//        /// <summary>更新時間プロパティ</summary>
//        /// <value>HHMMSSXXX</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   更新時間プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 UpdateTime
//        {
//            get { return _updateTime; }
//            set { _updateTime = value; }
//        }

//        /// public propaty name  :  InqRowNumber
//        /// <summary>問合せ行番号プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   問合せ行番号プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 InqRowNumber
//        {
//            get { return _inqRowNumber; }
//            set { _inqRowNumber = value; }
//        }

//        /// public propaty name  :  InqRowNumDerivedNo
//        /// <summary>問合せ行番号枝番プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   問合せ行番号枝番プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 InqRowNumDerivedNo
//        {
//            get { return _inqRowNumDerivedNo; }
//            set { _inqRowNumDerivedNo = value; }
//        }

//        /// public propaty name  :  InqOrgDtlDiscGuid
//        /// <summary>問合せ元明細識別GUIDプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   問合せ元明細識別GUIDプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Guid InqOrgDtlDiscGuid
//        {
//            get { return _inqOrgDtlDiscGuid; }
//            set { _inqOrgDtlDiscGuid = value; }
//        }

//        /// public propaty name  :  InqOthDtlDiscGuid
//        /// <summary>問合せ先明細識別GUIDプロパティ</summary>
//        /// <value>回答データの場合有効、問合せ／発注元の明細GUIDを設定</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   問合せ先明細識別GUIDプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Guid InqOthDtlDiscGuid
//        {
//            get { return _inqOthDtlDiscGuid; }
//            set { _inqOthDtlDiscGuid = value; }
//        }

//        /// public propaty name  :  GoodsDivCd
//        /// <summary>商品種別プロパティ</summary>
//        /// <value>0:純正部品 1:優良部品 2:リビルド 3:中古 4:平均相場</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   商品種別プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 GoodsDivCd
//        {
//            get { return _goodsDivCd; }
//            set { _goodsDivCd = value; }
//        }

//        /// public propaty name  :  DeliveredGoodsDiv
//        /// <summary>納品区分プロパティ</summary>
//        /// <value>0:配送,1:引取</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   納品区分プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 DeliveredGoodsDiv
//        {
//            get { return _deliveredGoodsDiv; }
//            set { _deliveredGoodsDiv = value; }
//        }

//        /// public propaty name  :  HandleDivCode
//        /// <summary>取扱区分プロパティ</summary>
//        /// <value>0:取り扱い品,1:納期確認中,2:未取り扱い品</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   取扱区分プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 HandleDivCode
//        {
//            get { return _handleDivCode; }
//            set { _handleDivCode = value; }
//        }

//        /// public propaty name  :  GoodsShape
//        /// <summary>商品形態プロパティ</summary>
//        /// <value>1:部品,2:用品</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   商品形態プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 GoodsShape
//        {
//            get { return _goodsShape; }
//            set { _goodsShape = value; }
//        }

//        /// public propaty name  :  DelivrdGdsConfCd
//        /// <summary>納品確認区分プロパティ</summary>
//        /// <value>0:未確認,1:確認</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   納品確認区分プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 DelivrdGdsConfCd
//        {
//            get { return _delivrdGdsConfCd; }
//            set { _delivrdGdsConfCd = value; }
//        }

//        /// public propaty name  :  DeliGdsCmpltDueDate
//        /// <summary>納品完了予定日プロパティ</summary>
//        /// <value>納品予定日付 YYYYMMDD</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   納品完了予定日プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public DateTime DeliGdsCmpltDueDate
//        {
//            get { return _deliGdsCmpltDueDate; }
//            set { _deliGdsCmpltDueDate = value; }
//        }

//        /// public propaty name  :  BLGoodsCode
//        /// <summary>BL商品コードプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   BL商品コードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 BLGoodsCode
//        {
//            get { return _bLGoodsCode; }
//            set { _bLGoodsCode = value; }
//        }

//        /// public propaty name  :  BLGoodsDrCode
//        /// <summary>BL商品コード枝番プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   BL商品コード枝番プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 BLGoodsDrCode
//        {
//            get { return _bLGoodsDrCode; }
//            set { _bLGoodsDrCode = value; }
//        }

//        /// public propaty name  :  InqGoodsName
//        /// <summary>問発商品名プロパティ</summary>
//        /// <value>(半角全角混在)</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   問発商品名プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string InqGoodsName
//        {
//            get { return _inqGoodsName; }
//            set { _inqGoodsName = value; }
//        }

//        /// public propaty name  :  AnsGoodsName
//        /// <summary>回答商品名プロパティ</summary>
//        /// <value>(半角全角混在)</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   回答商品名プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string AnsGoodsName
//        {
//            get { return _ansGoodsName; }
//            set { _ansGoodsName = value; }
//        }

//        /// public propaty name  :  SalesOrderCount
//        /// <summary>発注数プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   発注数プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Double SalesOrderCount
//        {
//            get { return _salesOrderCount; }
//            set { _salesOrderCount = value; }
//        }

//        /// public propaty name  :  DeliveredGoodsCount
//        /// <summary>納品数プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   納品数プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Double DeliveredGoodsCount
//        {
//            get { return _deliveredGoodsCount; }
//            set { _deliveredGoodsCount = value; }
//        }

//        /// public propaty name  :  GoodsNo
//        /// <summary>商品番号プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   商品番号プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string GoodsNo
//        {
//            get { return _goodsNo; }
//            set { _goodsNo = value; }
//        }

//        /// public propaty name  :  GoodsMakerCd
//        /// <summary>商品メーカーコードプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   商品メーカーコードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 GoodsMakerCd
//        {
//            get { return _goodsMakerCd; }
//            set { _goodsMakerCd = value; }
//        }

//        /// public propaty name  :  PureGoodsMakerCd
//        /// <summary>純正商品メーカーコードプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   純正商品メーカーコードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 PureGoodsMakerCd
//        {
//            get { return _pureGoodsMakerCd; }
//            set { _pureGoodsMakerCd = value; }
//        }

//        /// public propaty name  :  InqPureGoodsNo
//        /// <summary>問発純正商品番号プロパティ</summary>
//        /// <value>(半角のみ)</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   問発純正商品番号プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string InqPureGoodsNo
//        {
//            get { return _inqPureGoodsNo; }
//            set { _inqPureGoodsNo = value; }
//        }

//        /// public propaty name  :  AnsPureGoodsNo
//        /// <summary>回答純正商品番号プロパティ</summary>
//        /// <value>(半角のみ)</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   回答純正商品番号プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string AnsPureGoodsNo
//        {
//            get { return _ansPureGoodsNo; }
//            set { _ansPureGoodsNo = value; }
//        }

//        /// public propaty name  :  ListPrice
//        /// <summary>定価プロパティ</summary>
//        /// <value>0:オープン価格</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   定価プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int64 ListPrice
//        {
//            get { return _listPrice; }
//            set { _listPrice = value; }
//        }

//        /// public propaty name  :  UnitPrice
//        /// <summary>単価プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   単価プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int64 UnitPrice
//        {
//            get { return _unitPrice; }
//            set { _unitPrice = value; }
//        }

//        /// public propaty name  :  DtlTakeinDivCd
//        /// <summary>明細取込区分プロパティ</summary>
//        /// <value>0:未取込 1:取込済</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   明細取込区分プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 DtlTakeinDivCd
//        {
//            get { return _dtlTakeinDivCd; }
//            set { _dtlTakeinDivCd = value; }
//        }

//        /// public propaty name  :  GoodsAddInfo
//        /// <summary>商品補足情報プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   商品補足情報プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string GoodsAddInfo
//        {
//            get { return _goodsAddInfo; }
//            set { _goodsAddInfo = value; }
//        }

//        /// public propaty name  :  RoughRrofit
//        /// <summary>粗利額プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   粗利額プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int64 RoughRrofit
//        {
//            get { return _roughRrofit; }
//            set { _roughRrofit = value; }
//        }

//        /// public propaty name  :  RoughRate
//        /// <summary>粗利率プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   粗利率プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Double RoughRate
//        {
//            get { return _roughRate; }
//            set { _roughRate = value; }
//        }

//        /// public propaty name  :  AnswerLimitDate
//        /// <summary>回答期限プロパティ</summary>
//        /// <value>YYYYMMDD</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   回答期限プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 AnswerLimitDate
//        {
//            get { return _answerLimitDate; }
//            set { _answerLimitDate = value; }
//        }

//        /// public propaty name  :  CommentDtl
//        /// <summary>備考(明細)プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   備考(明細)プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string CommentDtl
//        {
//            get { return _commentDtl; }
//            set { _commentDtl = value; }
//        }

//        /// public propaty name  :  ShelfNo
//        /// <summary>棚番プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   棚番プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string ShelfNo
//        {
//            get { return _shelfNo; }
//            set { _shelfNo = value; }
//        }

//        /// public propaty name  :  AdditionalDivCd
//        /// <summary>追加区分プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   追加区分プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 AdditionalDivCd
//        {
//            get { return _additionalDivCd; }
//            set { _additionalDivCd = value; }
//        }

//        /// public propaty name  :  CorrectDivCD
//        /// <summary>訂正区分プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   訂正区分プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 CorrectDivCD
//        {
//            get { return _correctDivCD; }
//            set { _correctDivCD = value; }
//        }

//        /// public propaty name  :  InqOrdDivCd
//        /// <summary>問合せ・発注種別プロパティ</summary>
//        /// <value>1:問合せ 2:発注</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   問合せ・発注種別プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 InqOrdDivCd
//        {
//            get { return _inqOrdDivCd; }
//            set { _inqOrdDivCd = value; }
//        }

//        /// public propaty name  :  SalesPriceConsTax
//        /// <summary>売上金額消費税額プロパティ</summary>
//        /// <value>売上金額（税込み）- 売上金額（税抜き）※消費税調整額も兼ねる</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   売上金額消費税額プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int64 SalesPriceConsTax
//        {
//            get { return _salesPriceConsTax; }
//            set { _salesPriceConsTax = value; }
//        }

//        /// public propaty name  :  EnterpriseCode
//        /// <summary>企業コードプロパティ</summary>
//        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   企業コードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string EnterpriseCode
//        {
//            get { return _enterpriseCode; }
//            set { _enterpriseCode = value; }
//        }

//        /// public propaty name  :  SalesRowNo
//        /// <summary>売上行番号プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   売上行番号プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 SalesRowNo
//        {
//            get { return _salesRowNo; }
//            set { _salesRowNo = value; }
//        }

//        /// public propaty name  :  CampaignCode
//        /// <summary>キャンペーンコードプロパティ</summary>
//        /// <value>任意の無重複コードとする（自動付番はしない）</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   キャンペーンコードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 CampaignCode
//        {
//            get { return _campaignCode; }
//            set { _campaignCode = value; }
//        }

//        /// public propaty name  :  StockDiv
//        /// <summary>在庫区分プロパティ</summary>
//        /// <value>委託在庫、得意先在庫、優先倉庫、自社在庫、非在庫</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   在庫区分プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 StockDiv
//        {
//            get { return _stockDiv; }
//            set { _stockDiv = value; }
//        }

//        /// public propaty name  :  AnswerDelivDate
//        /// <summary>回答納期プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   回答納期プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string AnswerDelivDate
//        {
//            get { return _answerDelivDate; }
//            set { _answerDelivDate = value; }
//        }


//        /// <summary>
//        /// SCM問い合わせ一覧抽出結果(明細回答)クラスワークコンストラクタ
//        /// </summary>
//        /// <returns>SCMInquiryDtlAnsResultWorkクラスのインスタンス</returns>
//        /// <remarks>
//        /// <br>Note　　　　　　 :   SCMInquiryDtlAnsResultWorkクラスの新しいインスタンスを生成します</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public SCMInquiryDtlAnsResultWork()
//        {
//        }

//    }

//    /// <summary>
//    ///  Ver5.10.1.0用のカスタムシライアライザです。
//    /// </summary>
//    /// <returns>SCMInquiryDtlAnsResultWorkクラスのインスタンス(object)</returns>
//    /// <remarks>
//    /// <br>Note　　　　　　 :   SCMInquiryDtlAnsResultWorkクラスのカスタムシリアライザを定義します</br>
//    /// <br>Programer        :   自動生成</br>
//    /// </remarks>
//    public class SCMInquiryDtlAnsResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
//    {
//        #region ICustomSerializationSurrogate メンバ

//        /// <summary>
//        ///  Ver5.10.1.0用のカスタムシリアライザです
//        /// </summary>
//        /// <remarks>
//        /// <br>Note　　　　　　 :   SCMInquiryDtlAnsResultWorkクラスのカスタムシリアライザを定義します</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public void Serialize(System.IO.BinaryWriter writer, object graph)
//        {
//            // TODO:  SCMInquiryDtlAnsResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
//            if (writer == null)
//                throw new ArgumentNullException();

//            if (graph != null && !(graph is SCMInquiryDtlAnsResultWork || graph is ArrayList || graph is SCMInquiryDtlAnsResultWork[]))
//                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SCMInquiryDtlAnsResultWork).FullName));

//            if (graph != null && graph is SCMInquiryDtlAnsResultWork)
//            {
//                Type t = graph.GetType();
//                if (!CustomFormatterServices.NeedCustomSerialization(t))
//                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
//            }

//            //SerializationTypeInfo
//            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMInquiryDtlAnsResultWork");

//            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
//            int occurrence = 0;     //一般にゼロの場合もありえます
//            if (graph is ArrayList)
//            {
//                serInfo.RetTypeInfo = 0;
//                occurrence = ((ArrayList)graph).Count;
//            }
//            else if (graph is SCMInquiryDtlAnsResultWork[])
//            {
//                serInfo.RetTypeInfo = 2;
//                occurrence = ((SCMInquiryDtlAnsResultWork[])graph).Length;
//            }
//            else if (graph is SCMInquiryDtlAnsResultWork)
//            {
//                serInfo.RetTypeInfo = 1;
//                occurrence = 1;
//            }

//            serInfo.Occurrence = occurrence;		 //繰り返し数	

//            //得意先コード
//            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
//            //得意先名称
//            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
//            //売上日付
//            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
//            //受注ステータス
//            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
//            //売上伝票番号
//            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
//            //売上金額（税抜き）
//            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
//            //問合せ元企業コード
//            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalEpCd
//            //問合せ元拠点コード
//            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalSecCd
//            //問合せ先企業コード
//            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
//            //問合せ先拠点コード
//            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
//            //問合せ番号
//            serInfo.MemberInfo.Add(typeof(Int64)); //InquiryNumber
//            //更新年月日
//            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDate
//            //更新時間
//            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateTime
//            //問合せ行番号
//            serInfo.MemberInfo.Add(typeof(Int32)); //InqRowNumber
//            //問合せ行番号枝番
//            serInfo.MemberInfo.Add(typeof(Int32)); //InqRowNumDerivedNo
//            //問合せ元明細識別GUID
//            serInfo.MemberInfo.Add(typeof(byte[]));  //InqOrgDtlDiscGuid
//            //問合せ先明細識別GUID
//            serInfo.MemberInfo.Add(typeof(byte[]));  //InqOthDtlDiscGuid
//            //商品種別
//            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsDivCd
//            //納品区分
//            serInfo.MemberInfo.Add(typeof(Int32)); //DeliveredGoodsDiv
//            //取扱区分
//            serInfo.MemberInfo.Add(typeof(Int32)); //HandleDivCode
//            //商品形態
//            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsShape
//            //納品確認区分
//            serInfo.MemberInfo.Add(typeof(Int32)); //DelivrdGdsConfCd
//            //納品完了予定日
//            serInfo.MemberInfo.Add(typeof(Int32)); //DeliGdsCmpltDueDate
//            //BL商品コード
//            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
//            //BL商品コード枝番
//            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsDrCode
//            //問発商品名
//            serInfo.MemberInfo.Add(typeof(string)); //InqGoodsName
//            //回答商品名
//            serInfo.MemberInfo.Add(typeof(string)); //AnsGoodsName
//            //発注数
//            serInfo.MemberInfo.Add(typeof(Double)); //SalesOrderCount
//            //納品数
//            serInfo.MemberInfo.Add(typeof(Double)); //DeliveredGoodsCount
//            //商品番号
//            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
//            //商品メーカーコード
//            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
//            //純正商品メーカーコード
//            serInfo.MemberInfo.Add(typeof(Int32)); //PureGoodsMakerCd
//            //問発純正商品番号
//            serInfo.MemberInfo.Add(typeof(string)); //InqPureGoodsNo
//            //回答純正商品番号
//            serInfo.MemberInfo.Add(typeof(string)); //AnsPureGoodsNo
//            //定価
//            serInfo.MemberInfo.Add(typeof(Int64)); //ListPrice
//            //単価
//            serInfo.MemberInfo.Add(typeof(Int64)); //UnitPrice
//            //明細取込区分
//            serInfo.MemberInfo.Add(typeof(Int32)); //DtlTakeinDivCd
//            //商品補足情報
//            serInfo.MemberInfo.Add(typeof(string)); //GoodsAddInfo
//            //粗利額
//            serInfo.MemberInfo.Add(typeof(Int64)); //RoughRrofit
//            //粗利率
//            serInfo.MemberInfo.Add(typeof(Double)); //RoughRate
//            //回答期限
//            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerLimitDate
//            //備考(明細)
//            serInfo.MemberInfo.Add(typeof(string)); //CommentDtl
//            //棚番
//            serInfo.MemberInfo.Add(typeof(string)); //ShelfNo
//            //追加区分
//            serInfo.MemberInfo.Add(typeof(Int32)); //AdditionalDivCd
//            //訂正区分
//            serInfo.MemberInfo.Add(typeof(Int32)); //CorrectDivCD
//            //問合せ・発注種別
//            serInfo.MemberInfo.Add(typeof(Int32)); //InqOrdDivCd
//            //売上金額消費税額
//            serInfo.MemberInfo.Add(typeof(Int64)); //SalesPriceConsTax
//            //企業コード
//            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
//            //売上行番号
//            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo
//            //キャンペーンコード
//            serInfo.MemberInfo.Add(typeof(Int32)); //CampaignCode
//            //在庫区分
//            serInfo.MemberInfo.Add(typeof(Int32)); //StockDiv
//            //回答納期
//            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate


//            serInfo.Serialize(writer, serInfo);
//            if (graph is SCMInquiryDtlAnsResultWork)
//            {
//                SCMInquiryDtlAnsResultWork temp = (SCMInquiryDtlAnsResultWork)graph;

//                SetSCMInquiryDtlAnsResultWork(writer, temp);
//            }
//            else
//            {
//                ArrayList lst = null;
//                if (graph is SCMInquiryDtlAnsResultWork[])
//                {
//                    lst = new ArrayList();
//                    lst.AddRange((SCMInquiryDtlAnsResultWork[])graph);
//                }
//                else
//                {
//                    lst = (ArrayList)graph;
//                }

//                foreach (SCMInquiryDtlAnsResultWork temp in lst)
//                {
//                    SetSCMInquiryDtlAnsResultWork(writer, temp);
//                }

//            }


//        }


//        /// <summary>
//        /// SCMInquiryDtlAnsResultWorkメンバ数(publicプロパティ数)
//        /// </summary>
//        private const int currentMemberCount = 52;

//        /// <summary>
//        ///  SCMInquiryDtlAnsResultWorkインスタンス書き込み
//        /// </summary>
//        /// <remarks>
//        /// <br>Note　　　　　　 :   SCMInquiryDtlAnsResultWorkのインスタンスを書き込み</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        private void SetSCMInquiryDtlAnsResultWork(System.IO.BinaryWriter writer, SCMInquiryDtlAnsResultWork temp)
//        {
//            //得意先コード
//            writer.Write(temp.CustomerCode);
//            //得意先名称
//            writer.Write(temp.CustomerName);
//            //売上日付
//            writer.Write((Int64)temp.SalesDate.Ticks);
//            //受注ステータス
//            writer.Write(temp.AcptAnOdrStatus);
//            //売上伝票番号
//            writer.Write(temp.SalesSlipNum);
//            //売上金額（税抜き）
//            writer.Write(temp.SalesMoneyTaxExc);
//            //問合せ元企業コード
//            writer.Write(temp.InqOriginalEpCd);
//            //問合せ元拠点コード
//            writer.Write(temp.InqOriginalSecCd);
//            //問合せ先企業コード
//            writer.Write(temp.InqOtherEpCd);
//            //問合せ先拠点コード
//            writer.Write(temp.InqOtherSecCd);
//            //問合せ番号
//            writer.Write(temp.InquiryNumber);
//            //更新年月日
//            writer.Write((Int64)temp.UpdateDate.Ticks);
//            //更新時間
//            writer.Write(temp.UpdateTime);
//            //問合せ行番号
//            writer.Write(temp.InqRowNumber);
//            //問合せ行番号枝番
//            writer.Write(temp.InqRowNumDerivedNo);
//            //問合せ元明細識別GUID
//            byte[] inqOrgDtlDiscGuidArray = temp.InqOrgDtlDiscGuid.ToByteArray();
//            writer.Write(inqOrgDtlDiscGuidArray.Length);
//            writer.Write(temp.InqOrgDtlDiscGuid.ToByteArray());
//            //問合せ先明細識別GUID
//            byte[] inqOthDtlDiscGuidArray = temp.InqOthDtlDiscGuid.ToByteArray();
//            writer.Write(inqOthDtlDiscGuidArray.Length);
//            writer.Write(temp.InqOthDtlDiscGuid.ToByteArray());
//            //商品種別
//            writer.Write(temp.GoodsDivCd);
//            //納品区分
//            writer.Write(temp.DeliveredGoodsDiv);
//            //取扱区分
//            writer.Write(temp.HandleDivCode);
//            //商品形態
//            writer.Write(temp.GoodsShape);
//            //納品確認区分
//            writer.Write(temp.DelivrdGdsConfCd);
//            //納品完了予定日
//            writer.Write((Int64)temp.DeliGdsCmpltDueDate.Ticks);
//            //BL商品コード
//            writer.Write(temp.BLGoodsCode);
//            //BL商品コード枝番
//            writer.Write(temp.BLGoodsDrCode);
//            //問発商品名
//            writer.Write(temp.InqGoodsName);
//            //回答商品名
//            writer.Write(temp.AnsGoodsName);
//            //発注数
//            writer.Write(temp.SalesOrderCount);
//            //納品数
//            writer.Write(temp.DeliveredGoodsCount);
//            //商品番号
//            writer.Write(temp.GoodsNo);
//            //商品メーカーコード
//            writer.Write(temp.GoodsMakerCd);
//            //純正商品メーカーコード
//            writer.Write(temp.PureGoodsMakerCd);
//            //問発純正商品番号
//            writer.Write(temp.InqPureGoodsNo);
//            //回答純正商品番号
//            writer.Write(temp.AnsPureGoodsNo);
//            //定価
//            writer.Write(temp.ListPrice);
//            //単価
//            writer.Write(temp.UnitPrice);
//            //明細取込区分
//            writer.Write(temp.DtlTakeinDivCd);
//            //商品補足情報
//            writer.Write(temp.GoodsAddInfo);
//            //粗利額
//            writer.Write(temp.RoughRrofit);
//            //粗利率
//            writer.Write(temp.RoughRate);
//            //回答期限
//            writer.Write(temp.AnswerLimitDate);
//            //備考(明細)
//            writer.Write(temp.CommentDtl);
//            //棚番
//            writer.Write(temp.ShelfNo);
//            //追加区分
//            writer.Write(temp.AdditionalDivCd);
//            //訂正区分
//            writer.Write(temp.CorrectDivCD);
//            //問合せ・発注種別
//            writer.Write(temp.InqOrdDivCd);
//            //売上金額消費税額
//            writer.Write(temp.SalesPriceConsTax);
//            //企業コード
//            writer.Write(temp.EnterpriseCode);
//            //売上行番号
//            writer.Write(temp.SalesRowNo);
//            //キャンペーンコード
//            writer.Write(temp.CampaignCode);
//            //在庫区分
//            writer.Write(temp.StockDiv);
//            //回答納期
//            writer.Write(temp.AnswerDelivDate);

//        }

//        /// <summary>
//        ///  SCMInquiryDtlAnsResultWorkインスタンス取得
//        /// </summary>
//        /// <returns>SCMInquiryDtlAnsResultWorkクラスのインスタンス</returns>
//        /// <remarks>
//        /// <br>Note　　　　　　 :   SCMInquiryDtlAnsResultWorkのインスタンスを取得します</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        private SCMInquiryDtlAnsResultWork GetSCMInquiryDtlAnsResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
//        {
//            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
//            // serInfo.MemberInfo.Count < currentMemberCount
//            // のケースについての配慮が必要になります。

//            SCMInquiryDtlAnsResultWork temp = new SCMInquiryDtlAnsResultWork();

//            //得意先コード
//            temp.CustomerCode = reader.ReadInt32();
//            //得意先名称
//            temp.CustomerName = reader.ReadString();
//            //売上日付
//            temp.SalesDate = new DateTime(reader.ReadInt64());
//            //受注ステータス
//            temp.AcptAnOdrStatus = reader.ReadInt32();
//            //売上伝票番号
//            temp.SalesSlipNum = reader.ReadString();
//            //売上金額（税抜き）
//            temp.SalesMoneyTaxExc = reader.ReadInt64();
//            //問合せ元企業コード
//            temp.InqOriginalEpCd = reader.ReadString();
//            //問合せ元拠点コード
//            temp.InqOriginalSecCd = reader.ReadString();
//            //問合せ先企業コード
//            temp.InqOtherEpCd = reader.ReadString();
//            //問合せ先拠点コード
//            temp.InqOtherSecCd = reader.ReadString();
//            //問合せ番号
//            temp.InquiryNumber = reader.ReadInt64();
//            //更新年月日
//            temp.UpdateDate = new DateTime(reader.ReadInt64());
//            //更新時間
//            temp.UpdateTime = reader.ReadInt32();
//            //問合せ行番号
//            temp.InqRowNumber = reader.ReadInt32();
//            //問合せ行番号枝番
//            temp.InqRowNumDerivedNo = reader.ReadInt32();
//            //問合せ元明細識別GUID
//            int lenOfInqOrgDtlDiscGuidArray = reader.ReadInt32();
//            byte[] inqOrgDtlDiscGuidArray = reader.ReadBytes(lenOfInqOrgDtlDiscGuidArray);
//            temp.InqOrgDtlDiscGuid = new Guid(inqOrgDtlDiscGuidArray);
//            //問合せ先明細識別GUID
//            int lenOfInqOthDtlDiscGuidArray = reader.ReadInt32();
//            byte[] inqOthDtlDiscGuidArray = reader.ReadBytes(lenOfInqOthDtlDiscGuidArray);
//            temp.InqOthDtlDiscGuid = new Guid(inqOthDtlDiscGuidArray);
//            //商品種別
//            temp.GoodsDivCd = reader.ReadInt32();
//            //納品区分
//            temp.DeliveredGoodsDiv = reader.ReadInt32();
//            //取扱区分
//            temp.HandleDivCode = reader.ReadInt32();
//            //商品形態
//            temp.GoodsShape = reader.ReadInt32();
//            //納品確認区分
//            temp.DelivrdGdsConfCd = reader.ReadInt32();
//            //納品完了予定日
//            temp.DeliGdsCmpltDueDate = new DateTime(reader.ReadInt64());
//            //BL商品コード
//            temp.BLGoodsCode = reader.ReadInt32();
//            //BL商品コード枝番
//            temp.BLGoodsDrCode = reader.ReadInt32();
//            //問発商品名
//            temp.InqGoodsName = reader.ReadString();
//            //回答商品名
//            temp.AnsGoodsName = reader.ReadString();
//            //発注数
//            temp.SalesOrderCount = reader.ReadDouble();
//            //納品数
//            temp.DeliveredGoodsCount = reader.ReadDouble();
//            //商品番号
//            temp.GoodsNo = reader.ReadString();
//            //商品メーカーコード
//            temp.GoodsMakerCd = reader.ReadInt32();
//            //純正商品メーカーコード
//            temp.PureGoodsMakerCd = reader.ReadInt32();
//            //問発純正商品番号
//            temp.InqPureGoodsNo = reader.ReadString();
//            //回答純正商品番号
//            temp.AnsPureGoodsNo = reader.ReadString();
//            //定価
//            temp.ListPrice = reader.ReadInt64();
//            //単価
//            temp.UnitPrice = reader.ReadInt64();
//            //明細取込区分
//            temp.DtlTakeinDivCd = reader.ReadInt32();
//            //商品補足情報
//            temp.GoodsAddInfo = reader.ReadString();
//            //粗利額
//            temp.RoughRrofit = reader.ReadInt64();
//            //粗利率
//            temp.RoughRate = reader.ReadDouble();
//            //回答期限
//            temp.AnswerLimitDate = reader.ReadInt32();
//            //備考(明細)
//            temp.CommentDtl = reader.ReadString();
//            //棚番
//            temp.ShelfNo = reader.ReadString();
//            //追加区分
//            temp.AdditionalDivCd = reader.ReadInt32();
//            //訂正区分
//            temp.CorrectDivCD = reader.ReadInt32();
//            //問合せ・発注種別
//            temp.InqOrdDivCd = reader.ReadInt32();
//            //売上金額消費税額
//            temp.SalesPriceConsTax = reader.ReadInt64();
//            //企業コード
//            temp.EnterpriseCode = reader.ReadString();
//            //売上行番号
//            temp.SalesRowNo = reader.ReadInt32();
//            //キャンペーンコード
//            temp.CampaignCode = reader.ReadInt32();
//            //在庫区分
//            temp.StockDiv = reader.ReadInt32();
//            //回答納期
//            temp.AnswerDelivDate = reader.ReadString();


//            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
//            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
//            //型情報にしたがって、ストリームから情報を読み出します...といっても
//            //読み出して捨てることになります。
//            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
//            {
//                //byte[],char[]をデシリアライズする直前に、そのlengthが
//                //デシリアライズされているケースがある、byte[],char[]の
//                //デシリアライズにはlengthが必要なのでint型のデータをデ
//                //シリアライズした場合は、この値をこの変数に退避します。
//                int optCount = 0;
//                object oMemberType = serInfo.MemberInfo[k];
//                if (oMemberType is Type)
//                {
//                    Type t = (Type)oMemberType;
//                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
//                    if (t.Equals(typeof(int)))
//                    {
//                        optCount = Convert.ToInt32(oData);
//                    }
//                    else
//                    {
//                        optCount = 0;
//                    }
//                }
//                else if (oMemberType is string)
//                {
//                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
//                    object userData = formatter.Deserialize(reader);  //読み飛ばし
//                }
//            }
//            return temp;
//        }

//        /// <summary>
//        ///  Ver5.10.1.0用のカスタムデシリアライザです
//        /// </summary>
//        /// <returns>SCMInquiryDtlAnsResultWorkクラスのインスタンス(object)</returns>
//        /// <remarks>
//        /// <br>Note　　　　　　 :   SCMInquiryDtlAnsResultWorkクラスのカスタムデシリアライザを定義します</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public object Deserialize(System.IO.BinaryReader reader)
//        {
//            object retValue = null;
//            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
//            ArrayList lst = new ArrayList();
//            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
//            {
//                SCMInquiryDtlAnsResultWork temp = GetSCMInquiryDtlAnsResultWork(reader, serInfo);
//                lst.Add(temp);
//            }
//            switch (serInfo.RetTypeInfo)
//            {
//                case 0:
//                    retValue = lst;
//                    break;
//                case 1:
//                    retValue = lst[0];
//                    break;
//                case 2:
//                    retValue = (SCMInquiryDtlAnsResultWork[])lst.ToArray(typeof(SCMInquiryDtlAnsResultWork));
//                    break;
//            }
//            return retValue;
//        }

//        #endregion
//    }

//}
#endregion
// 2009.08.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
