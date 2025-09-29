using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ScmOdSetDt
    /// <summary>
    ///                      SCM受発注セット部品データ
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM受発注セット部品データヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2011/8/1</br>
    /// <br>Genarated Date   :   2011/08/08  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class ScmOdSetDt
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

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

        /// <summary>セット部品メーカーコード</summary>
        private Int32 _setPartsMkrCd;

        /// <summary>セット部品番号</summary>
        private string _setPartsNumber = "";

        /// <summary>セット部品親子番号</summary>
        /// <remarks>0:親,1-*:子</remarks>
        private Int32 _setPartsMainSubNo;

        /// <summary>商品種別</summary>
        /// <remarks>0:純正部品 1:優良部品 2:リサイクル部品 3:平均相場 99:値引き</remarks>
        private Int32 _goodsDivCd;

        /// <summary>リサイクル部品種別</summary>
        /// <remarks>1:リビルド 2:中古</remarks>
        private Int32 _recyclePrtKindCode;

        /// <summary>リサイクル部品種別名称</summary>
        private string _recyclePrtKindName = "";

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

        /// <summary>回答納期</summary>
        private string _answerDeliveryDate = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード枝番</summary>
        private Int32 _bLGoodsDrCode;

        /// <summary>問発商品名</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _inqGoodsName = "";

        /// <summary>回答商品名</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _ansGoodsName = "";

        /// <summary>発注数</summary>
        private Double _salesOrderCount;

        /// <summary>納品数</summary>
        private Double _deliveredGoodsCount;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品メーカー名称</summary>
        private string _goodsMakerNm = "";

        /// <summary>純正商品メーカーコード</summary>
        private Int32 _pureGoodsMakerCd;

        /// <summary>問発純正商品番号</summary>
        /// <remarks>(半角のみ)</remarks>
        private string _inqPureGoodsNo = "";

        /// <summary>回答純正商品番号</summary>
        /// <remarks>(半角のみ)</remarks>
        private string _ansPureGoodsNo = "";

        /// <summary>定価</summary>
        private Int64 _listPrice;

        /// <summary>単価</summary>
        private Int64 _unitPrice;

        /// <summary>商品補足情報</summary>
        private string _goodsAddInfo = "";

        /// <summary>粗利額</summary>
        private Int64 _roughRrofit;

        /// <summary>粗利率</summary>
        private Double _roughRate;

        /// <summary>回答期限</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _answerLimitDate;

        /// <summary>備考(明細)</summary>
        private string _commentDtl = "";

        /// <summary>棚番</summary>
        private string _shelfNo = "";

        /// <summary>PM受注ステータス</summary>
        /// <remarks>10：見積 20:受注 30:売上 40:出荷</remarks>
        private Int32 _pMAcptAnOdrStatus;

        /// <summary>PM売上伝票番号</summary>
        /// <remarks>PMの売上伝票番号</remarks>
        private Int32 _pMSalesSlipNum;

        /// <summary>PM売上行番号</summary>
        private Int32 _pMSalesRowNo;

        /// <summary>PM倉庫コード</summary>
        private string _pmWarehouseCd = "";

        /// <summary>PM倉庫名称</summary>
        private string _pmWarehouseName = "";

        /// <summary>PM棚番</summary>
        private string _pmShelfNo = "";

        /// <summary>PM現在個数</summary>
        private Double _pmPrsntCount;


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

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>作成日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>作成日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>作成日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>作成日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
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

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>更新日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>更新日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>更新日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>更新日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
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

        /// public propaty name  :  SetPartsMkrCd
        /// <summary>セット部品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット部品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SetPartsMkrCd
        {
            get { return _setPartsMkrCd; }
            set { _setPartsMkrCd = value; }
        }

        /// public propaty name  :  SetPartsNumber
        /// <summary>セット部品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット部品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SetPartsNumber
        {
            get { return _setPartsNumber; }
            set { _setPartsNumber = value; }
        }

        /// public propaty name  :  SetPartsMainSubNo
        /// <summary>セット部品親子番号プロパティ</summary>
        /// <value>0:親,1-*:子</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット部品親子番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SetPartsMainSubNo
        {
            get { return _setPartsMainSubNo; }
            set { _setPartsMainSubNo = value; }
        }

        /// public propaty name  :  GoodsDivCd
        /// <summary>商品種別プロパティ</summary>
        /// <value>0:純正部品 1:優良部品 2:リサイクル部品 3:平均相場 99:値引き</value>
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

        /// public propaty name  :  DeliGdsCmpltDueDateJpFormal
        /// <summary>納品完了予定日 和暦プロパティ</summary>
        /// <value>納品予定日付 YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DeliGdsCmpltDueDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _deliGdsCmpltDueDate); }
            set { }
        }

        /// public propaty name  :  DeliGdsCmpltDueDateJpInFormal
        /// <summary>納品完了予定日 和暦(略)プロパティ</summary>
        /// <value>納品予定日付 YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DeliGdsCmpltDueDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _deliGdsCmpltDueDate); }
            set { }
        }

        /// public propaty name  :  DeliGdsCmpltDueDateAdFormal
        /// <summary>納品完了予定日 西暦プロパティ</summary>
        /// <value>納品予定日付 YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DeliGdsCmpltDueDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _deliGdsCmpltDueDate); }
            set { }
        }

        /// public propaty name  :  DeliGdsCmpltDueDateAdInFormal
        /// <summary>納品完了予定日 西暦(略)プロパティ</summary>
        /// <value>納品予定日付 YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DeliGdsCmpltDueDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _deliGdsCmpltDueDate); }
            set { }
        }

        /// public propaty name  :  AnswerDeliveryDate
        /// <summary>回答納期プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnswerDeliveryDate
        {
            get { return _answerDeliveryDate; }
            set { _answerDeliveryDate = value; }
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

        /// public propaty name  :  GoodsMakerNm
        /// <summary>商品メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMakerNm
        {
            get { return _goodsMakerNm; }
            set { _goodsMakerNm = value; }
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

        /// public propaty name  :  ListPrice
        /// <summary>定価プロパティ</summary>
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
        public DateTime AnswerLimitDate
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

        /// public propaty name  :  PMAcptAnOdrStatus
        /// <summary>PM受注ステータスプロパティ</summary>
        /// <value>10：見積 20:受注 30:売上 40:出荷</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PMAcptAnOdrStatus
        {
            get { return _pMAcptAnOdrStatus; }
            set { _pMAcptAnOdrStatus = value; }
        }

        /// public propaty name  :  PMSalesSlipNum
        /// <summary>PM売上伝票番号プロパティ</summary>
        /// <value>PMの売上伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PMSalesSlipNum
        {
            get { return _pMSalesSlipNum; }
            set { _pMSalesSlipNum = value; }
        }

        /// public propaty name  :  PMSalesRowNo
        /// <summary>PM売上行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM売上行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PMSalesRowNo
        {
            get { return _pMSalesRowNo; }
            set { _pMSalesRowNo = value; }
        }

        /// public propaty name  :  PmWarehouseCd
        /// <summary>PM倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PmWarehouseCd
        {
            get { return _pmWarehouseCd; }
            set { _pmWarehouseCd = value; }
        }

        /// public propaty name  :  PmWarehouseName
        /// <summary>PM倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PmWarehouseName
        {
            get { return _pmWarehouseName; }
            set { _pmWarehouseName = value; }
        }

        /// public propaty name  :  PmShelfNo
        /// <summary>PM棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PmShelfNo
        {
            get { return _pmShelfNo; }
            set { _pmShelfNo = value; }
        }

        /// public propaty name  :  PmPrsntCount
        /// <summary>PM現在個数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM現在個数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PmPrsntCount
        {
            get { return _pmPrsntCount; }
            set { _pmPrsntCount = value; }
        }


        /// <summary>
        /// SCM受発注セット部品データコンストラクタ
        /// </summary>
        /// <returns>ScmOdSetDtクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmOdSetDtクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ScmOdSetDt()
        {
        }

        /// <summary>
        /// SCM受発注セット部品データコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="inqOriginalEpCd">問合せ元企業コード</param>
        /// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
        /// <param name="inqOtherEpCd">問合せ先企業コード</param>
        /// <param name="inqOtherSecCd">問合せ先拠点コード</param>
        /// <param name="inquiryNumber">問合せ番号</param>
        /// <param name="setPartsMkrCd">セット部品メーカーコード</param>
        /// <param name="setPartsNumber">セット部品番号</param>
        /// <param name="setPartsMainSubNo">セット部品親子番号(0:親,1-*:子)</param>
        /// <param name="goodsDivCd">商品種別(0:純正部品 1:優良部品 2:リサイクル部品 3:平均相場 99:値引き)</param>
        /// <param name="recyclePrtKindCode">リサイクル部品種別(1:リビルド 2:中古)</param>
        /// <param name="recyclePrtKindName">リサイクル部品種別名称</param>
        /// <param name="deliveredGoodsDiv">納品区分(0:配送,1:引取)</param>
        /// <param name="handleDivCode">取扱区分(0:取り扱い品,1:納期確認中,2:未取り扱い品)</param>
        /// <param name="goodsShape">商品形態(1:部品,2:用品)</param>
        /// <param name="delivrdGdsConfCd">納品確認区分(0:未確認,1:確認)</param>
        /// <param name="deliGdsCmpltDueDate">納品完了予定日(納品予定日付 YYYYMMDD)</param>
        /// <param name="answerDeliveryDate">回答納期</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="bLGoodsDrCode">BL商品コード枝番</param>
        /// <param name="inqGoodsName">問発商品名((半角全角混在))</param>
        /// <param name="ansGoodsName">回答商品名((半角全角混在))</param>
        /// <param name="salesOrderCount">発注数</param>
        /// <param name="deliveredGoodsCount">納品数</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="goodsMakerNm">商品メーカー名称</param>
        /// <param name="pureGoodsMakerCd">純正商品メーカーコード</param>
        /// <param name="inqPureGoodsNo">問発純正商品番号((半角のみ))</param>
        /// <param name="ansPureGoodsNo">回答純正商品番号((半角のみ))</param>
        /// <param name="listPrice">定価</param>
        /// <param name="unitPrice">単価</param>
        /// <param name="goodsAddInfo">商品補足情報</param>
        /// <param name="roughRrofit">粗利額</param>
        /// <param name="roughRate">粗利率</param>
        /// <param name="answerLimitDate">回答期限(YYYYMMDD)</param>
        /// <param name="commentDtl">備考(明細)</param>
        /// <param name="shelfNo">棚番</param>
        /// <param name="pMAcptAnOdrStatus">PM受注ステータス(10：見積 20:受注 30:売上 40:出荷)</param>
        /// <param name="pMSalesSlipNum">PM売上伝票番号(PMの売上伝票番号)</param>
        /// <param name="pMSalesRowNo">PM売上行番号</param>
        /// <param name="pmWarehouseCd">PM倉庫コード</param>
        /// <param name="pmWarehouseName">PM倉庫名称</param>
        /// <param name="pmShelfNo">PM棚番</param>
        /// <param name="pmPrsntCount">PM現在個数</param>
        /// <returns>ScmOdSetDtクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmOdSetDtクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ScmOdSetDt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, Int32 setPartsMkrCd, string setPartsNumber, Int32 setPartsMainSubNo, Int32 goodsDivCd, Int32 recyclePrtKindCode, string recyclePrtKindName, Int32 deliveredGoodsDiv, Int32 handleDivCode, Int32 goodsShape, Int32 delivrdGdsConfCd, DateTime deliGdsCmpltDueDate, string answerDeliveryDate, Int32 bLGoodsCode, Int32 bLGoodsDrCode, string inqGoodsName, string ansGoodsName, Double salesOrderCount, Double deliveredGoodsCount, string goodsNo, Int32 goodsMakerCd, string goodsMakerNm, Int32 pureGoodsMakerCd, string inqPureGoodsNo, string ansPureGoodsNo, Int64 listPrice, Int64 unitPrice, string goodsAddInfo, Int64 roughRrofit, Double roughRate, DateTime answerLimitDate, string commentDtl, string shelfNo, Int32 pMAcptAnOdrStatus, Int32 pMSalesSlipNum, Int32 pMSalesRowNo, string pmWarehouseCd, string pmWarehouseName, string pmShelfNo, Double pmPrsntCount)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._inqOriginalEpCd = inqOriginalEpCd;
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._inqOtherEpCd = inqOtherEpCd;
            this._inqOtherSecCd = inqOtherSecCd;
            this._inquiryNumber = inquiryNumber;
            this._setPartsMkrCd = setPartsMkrCd;
            this._setPartsNumber = setPartsNumber;
            this._setPartsMainSubNo = setPartsMainSubNo;
            this._goodsDivCd = goodsDivCd;
            this._recyclePrtKindCode = recyclePrtKindCode;
            this._recyclePrtKindName = recyclePrtKindName;
            this._deliveredGoodsDiv = deliveredGoodsDiv;
            this._handleDivCode = handleDivCode;
            this._goodsShape = goodsShape;
            this._delivrdGdsConfCd = delivrdGdsConfCd;
            this.DeliGdsCmpltDueDate = deliGdsCmpltDueDate;
            this._answerDeliveryDate = answerDeliveryDate;
            this._bLGoodsCode = bLGoodsCode;
            this._bLGoodsDrCode = bLGoodsDrCode;
            this._inqGoodsName = inqGoodsName;
            this._ansGoodsName = ansGoodsName;
            this._salesOrderCount = salesOrderCount;
            this._deliveredGoodsCount = deliveredGoodsCount;
            this._goodsNo = goodsNo;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsMakerNm = goodsMakerNm;
            this._pureGoodsMakerCd = pureGoodsMakerCd;
            this._inqPureGoodsNo = inqPureGoodsNo;
            this._ansPureGoodsNo = ansPureGoodsNo;
            this._listPrice = listPrice;
            this._unitPrice = unitPrice;
            this._goodsAddInfo = goodsAddInfo;
            this._roughRrofit = roughRrofit;
            this._roughRate = roughRate;
            this._answerLimitDate = answerLimitDate;
            this._commentDtl = commentDtl;
            this._shelfNo = shelfNo;
            this._pMAcptAnOdrStatus = pMAcptAnOdrStatus;
            this._pMSalesSlipNum = pMSalesSlipNum;
            this._pMSalesRowNo = pMSalesRowNo;
            this._pmWarehouseCd = pmWarehouseCd;
            this._pmWarehouseName = pmWarehouseName;
            this._pmShelfNo = pmShelfNo;
            this._pmPrsntCount = pmPrsntCount;

        }

        /// <summary>
        /// SCM受発注セット部品データ複製処理
        /// </summary>
        /// <returns>ScmOdSetDtクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいScmOdSetDtクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ScmOdSetDt Clone()
        {
            return new ScmOdSetDt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inquiryNumber, this._setPartsMkrCd, this._setPartsNumber, this._setPartsMainSubNo, this._goodsDivCd, this._recyclePrtKindCode, this._recyclePrtKindName, this._deliveredGoodsDiv, this._handleDivCode, this._goodsShape, this._delivrdGdsConfCd, this._deliGdsCmpltDueDate, this._answerDeliveryDate, this._bLGoodsCode, this._bLGoodsDrCode, this._inqGoodsName, this._ansGoodsName, this._salesOrderCount, this._deliveredGoodsCount, this._goodsNo, this._goodsMakerCd, this._goodsMakerNm, this._pureGoodsMakerCd, this._inqPureGoodsNo, this._ansPureGoodsNo, this._listPrice, this._unitPrice, this._goodsAddInfo, this._roughRrofit, this._roughRate, this._answerLimitDate, this._commentDtl, this._shelfNo, this._pMAcptAnOdrStatus, this._pMSalesSlipNum, this._pMSalesRowNo, this._pmWarehouseCd, this._pmWarehouseName, this._pmShelfNo, this._pmPrsntCount);
        }

        /// <summary>
        /// SCM受発注セット部品データ比較処理
        /// </summary>
        /// <param name="target">比較対象のScmOdSetDtクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmOdSetDtクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(ScmOdSetDt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOriginalEpCd == target.InqOriginalEpCd)
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.InqOtherEpCd == target.InqOtherEpCd)
                 && (this.InqOtherSecCd == target.InqOtherSecCd)
                 && (this.InquiryNumber == target.InquiryNumber)
                 && (this.SetPartsMkrCd == target.SetPartsMkrCd)
                 && (this.SetPartsNumber == target.SetPartsNumber)
                 && (this.SetPartsMainSubNo == target.SetPartsMainSubNo)
                 && (this.GoodsDivCd == target.GoodsDivCd)
                 && (this.RecyclePrtKindCode == target.RecyclePrtKindCode)
                 && (this.RecyclePrtKindName == target.RecyclePrtKindName)
                 && (this.DeliveredGoodsDiv == target.DeliveredGoodsDiv)
                 && (this.HandleDivCode == target.HandleDivCode)
                 && (this.GoodsShape == target.GoodsShape)
                 && (this.DelivrdGdsConfCd == target.DelivrdGdsConfCd)
                 && (this.DeliGdsCmpltDueDate == target.DeliGdsCmpltDueDate)
                 && (this.AnswerDeliveryDate == target.AnswerDeliveryDate)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.BLGoodsDrCode == target.BLGoodsDrCode)
                 && (this.InqGoodsName == target.InqGoodsName)
                 && (this.AnsGoodsName == target.AnsGoodsName)
                 && (this.SalesOrderCount == target.SalesOrderCount)
                 && (this.DeliveredGoodsCount == target.DeliveredGoodsCount)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsMakerNm == target.GoodsMakerNm)
                 && (this.PureGoodsMakerCd == target.PureGoodsMakerCd)
                 && (this.InqPureGoodsNo == target.InqPureGoodsNo)
                 && (this.AnsPureGoodsNo == target.AnsPureGoodsNo)
                 && (this.ListPrice == target.ListPrice)
                 && (this.UnitPrice == target.UnitPrice)
                 && (this.GoodsAddInfo == target.GoodsAddInfo)
                 && (this.RoughRrofit == target.RoughRrofit)
                 && (this.RoughRate == target.RoughRate)
                 && (this.AnswerLimitDate == target.AnswerLimitDate)
                 && (this.CommentDtl == target.CommentDtl)
                 && (this.ShelfNo == target.ShelfNo)
                 && (this.PMAcptAnOdrStatus == target.PMAcptAnOdrStatus)
                 && (this.PMSalesSlipNum == target.PMSalesSlipNum)
                 && (this.PMSalesRowNo == target.PMSalesRowNo)
                 && (this.PmWarehouseCd == target.PmWarehouseCd)
                 && (this.PmWarehouseName == target.PmWarehouseName)
                 && (this.PmShelfNo == target.PmShelfNo)
                 && (this.PmPrsntCount == target.PmPrsntCount));
        }

        /// <summary>
        /// SCM受発注セット部品データ比較処理
        /// </summary>
        /// <param name="scmOdSetDt1">
        ///                    比較するScmOdSetDtクラスのインスタンス
        /// </param>
        /// <param name="scmOdSetDt2">比較するScmOdSetDtクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmOdSetDtクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(ScmOdSetDt scmOdSetDt1, ScmOdSetDt scmOdSetDt2)
        {
            return ((scmOdSetDt1.CreateDateTime == scmOdSetDt2.CreateDateTime)
                 && (scmOdSetDt1.UpdateDateTime == scmOdSetDt2.UpdateDateTime)
                 && (scmOdSetDt1.LogicalDeleteCode == scmOdSetDt2.LogicalDeleteCode)
                 && (scmOdSetDt1.InqOriginalEpCd == scmOdSetDt2.InqOriginalEpCd)
                 && (scmOdSetDt1.InqOriginalSecCd == scmOdSetDt2.InqOriginalSecCd)
                 && (scmOdSetDt1.InqOtherEpCd == scmOdSetDt2.InqOtherEpCd)
                 && (scmOdSetDt1.InqOtherSecCd == scmOdSetDt2.InqOtherSecCd)
                 && (scmOdSetDt1.InquiryNumber == scmOdSetDt2.InquiryNumber)
                 && (scmOdSetDt1.SetPartsMkrCd == scmOdSetDt2.SetPartsMkrCd)
                 && (scmOdSetDt1.SetPartsNumber == scmOdSetDt2.SetPartsNumber)
                 && (scmOdSetDt1.SetPartsMainSubNo == scmOdSetDt2.SetPartsMainSubNo)
                 && (scmOdSetDt1.GoodsDivCd == scmOdSetDt2.GoodsDivCd)
                 && (scmOdSetDt1.RecyclePrtKindCode == scmOdSetDt2.RecyclePrtKindCode)
                 && (scmOdSetDt1.RecyclePrtKindName == scmOdSetDt2.RecyclePrtKindName)
                 && (scmOdSetDt1.DeliveredGoodsDiv == scmOdSetDt2.DeliveredGoodsDiv)
                 && (scmOdSetDt1.HandleDivCode == scmOdSetDt2.HandleDivCode)
                 && (scmOdSetDt1.GoodsShape == scmOdSetDt2.GoodsShape)
                 && (scmOdSetDt1.DelivrdGdsConfCd == scmOdSetDt2.DelivrdGdsConfCd)
                 && (scmOdSetDt1.DeliGdsCmpltDueDate == scmOdSetDt2.DeliGdsCmpltDueDate)
                 && (scmOdSetDt1.AnswerDeliveryDate == scmOdSetDt2.AnswerDeliveryDate)
                 && (scmOdSetDt1.BLGoodsCode == scmOdSetDt2.BLGoodsCode)
                 && (scmOdSetDt1.BLGoodsDrCode == scmOdSetDt2.BLGoodsDrCode)
                 && (scmOdSetDt1.InqGoodsName == scmOdSetDt2.InqGoodsName)
                 && (scmOdSetDt1.AnsGoodsName == scmOdSetDt2.AnsGoodsName)
                 && (scmOdSetDt1.SalesOrderCount == scmOdSetDt2.SalesOrderCount)
                 && (scmOdSetDt1.DeliveredGoodsCount == scmOdSetDt2.DeliveredGoodsCount)
                 && (scmOdSetDt1.GoodsNo == scmOdSetDt2.GoodsNo)
                 && (scmOdSetDt1.GoodsMakerCd == scmOdSetDt2.GoodsMakerCd)
                 && (scmOdSetDt1.GoodsMakerNm == scmOdSetDt2.GoodsMakerNm)
                 && (scmOdSetDt1.PureGoodsMakerCd == scmOdSetDt2.PureGoodsMakerCd)
                 && (scmOdSetDt1.InqPureGoodsNo == scmOdSetDt2.InqPureGoodsNo)
                 && (scmOdSetDt1.AnsPureGoodsNo == scmOdSetDt2.AnsPureGoodsNo)
                 && (scmOdSetDt1.ListPrice == scmOdSetDt2.ListPrice)
                 && (scmOdSetDt1.UnitPrice == scmOdSetDt2.UnitPrice)
                 && (scmOdSetDt1.GoodsAddInfo == scmOdSetDt2.GoodsAddInfo)
                 && (scmOdSetDt1.RoughRrofit == scmOdSetDt2.RoughRrofit)
                 && (scmOdSetDt1.RoughRate == scmOdSetDt2.RoughRate)
                 && (scmOdSetDt1.AnswerLimitDate == scmOdSetDt2.AnswerLimitDate)
                 && (scmOdSetDt1.CommentDtl == scmOdSetDt2.CommentDtl)
                 && (scmOdSetDt1.ShelfNo == scmOdSetDt2.ShelfNo)
                 && (scmOdSetDt1.PMAcptAnOdrStatus == scmOdSetDt2.PMAcptAnOdrStatus)
                 && (scmOdSetDt1.PMSalesSlipNum == scmOdSetDt2.PMSalesSlipNum)
                 && (scmOdSetDt1.PMSalesRowNo == scmOdSetDt2.PMSalesRowNo)
                 && (scmOdSetDt1.PmWarehouseCd == scmOdSetDt2.PmWarehouseCd)
                 && (scmOdSetDt1.PmWarehouseName == scmOdSetDt2.PmWarehouseName)
                 && (scmOdSetDt1.PmShelfNo == scmOdSetDt2.PmShelfNo)
                 && (scmOdSetDt1.PmPrsntCount == scmOdSetDt2.PmPrsntCount));
        }
        /// <summary>
        /// SCM受発注セット部品データ比較処理
        /// </summary>
        /// <param name="target">比較対象のScmOdSetDtクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmOdSetDtクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(ScmOdSetDt target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.InqOriginalEpCd != target.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
            if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (this.InquiryNumber != target.InquiryNumber) resList.Add("InquiryNumber");
            if (this.SetPartsMkrCd != target.SetPartsMkrCd) resList.Add("SetPartsMkrCd");
            if (this.SetPartsNumber != target.SetPartsNumber) resList.Add("SetPartsNumber");
            if (this.SetPartsMainSubNo != target.SetPartsMainSubNo) resList.Add("SetPartsMainSubNo");
            if (this.GoodsDivCd != target.GoodsDivCd) resList.Add("GoodsDivCd");
            if (this.RecyclePrtKindCode != target.RecyclePrtKindCode) resList.Add("RecyclePrtKindCode");
            if (this.RecyclePrtKindName != target.RecyclePrtKindName) resList.Add("RecyclePrtKindName");
            if (this.DeliveredGoodsDiv != target.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (this.HandleDivCode != target.HandleDivCode) resList.Add("HandleDivCode");
            if (this.GoodsShape != target.GoodsShape) resList.Add("GoodsShape");
            if (this.DelivrdGdsConfCd != target.DelivrdGdsConfCd) resList.Add("DelivrdGdsConfCd");
            if (this.DeliGdsCmpltDueDate != target.DeliGdsCmpltDueDate) resList.Add("DeliGdsCmpltDueDate");
            if (this.AnswerDeliveryDate != target.AnswerDeliveryDate) resList.Add("AnswerDeliveryDate");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.BLGoodsDrCode != target.BLGoodsDrCode) resList.Add("BLGoodsDrCode");
            if (this.InqGoodsName != target.InqGoodsName) resList.Add("InqGoodsName");
            if (this.AnsGoodsName != target.AnsGoodsName) resList.Add("AnsGoodsName");
            if (this.SalesOrderCount != target.SalesOrderCount) resList.Add("SalesOrderCount");
            if (this.DeliveredGoodsCount != target.DeliveredGoodsCount) resList.Add("DeliveredGoodsCount");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsMakerNm != target.GoodsMakerNm) resList.Add("GoodsMakerNm");
            if (this.PureGoodsMakerCd != target.PureGoodsMakerCd) resList.Add("PureGoodsMakerCd");
            if (this.InqPureGoodsNo != target.InqPureGoodsNo) resList.Add("InqPureGoodsNo");
            if (this.AnsPureGoodsNo != target.AnsPureGoodsNo) resList.Add("AnsPureGoodsNo");
            if (this.ListPrice != target.ListPrice) resList.Add("ListPrice");
            if (this.UnitPrice != target.UnitPrice) resList.Add("UnitPrice");
            if (this.GoodsAddInfo != target.GoodsAddInfo) resList.Add("GoodsAddInfo");
            if (this.RoughRrofit != target.RoughRrofit) resList.Add("RoughRrofit");
            if (this.RoughRate != target.RoughRate) resList.Add("RoughRate");
            if (this.AnswerLimitDate != target.AnswerLimitDate) resList.Add("AnswerLimitDate");
            if (this.CommentDtl != target.CommentDtl) resList.Add("CommentDtl");
            if (this.ShelfNo != target.ShelfNo) resList.Add("ShelfNo");
            if (this.PMAcptAnOdrStatus != target.PMAcptAnOdrStatus) resList.Add("PMAcptAnOdrStatus");
            if (this.PMSalesSlipNum != target.PMSalesSlipNum) resList.Add("PMSalesSlipNum");
            if (this.PMSalesRowNo != target.PMSalesRowNo) resList.Add("PMSalesRowNo");
            if (this.PmWarehouseCd != target.PmWarehouseCd) resList.Add("PmWarehouseCd");
            if (this.PmWarehouseName != target.PmWarehouseName) resList.Add("PmWarehouseName");
            if (this.PmShelfNo != target.PmShelfNo) resList.Add("PmShelfNo");
            if (this.PmPrsntCount != target.PmPrsntCount) resList.Add("PmPrsntCount");

            return resList;
        }

        /// <summary>
        /// SCM受発注セット部品データ比較処理
        /// </summary>
        /// <param name="scmOdSetDt1">比較するScmOdSetDtクラスのインスタンス</param>
        /// <param name="scmOdSetDt2">比較するScmOdSetDtクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmOdSetDtクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(ScmOdSetDt scmOdSetDt1, ScmOdSetDt scmOdSetDt2)
        {
            ArrayList resList = new ArrayList();
            if (scmOdSetDt1.CreateDateTime != scmOdSetDt2.CreateDateTime) resList.Add("CreateDateTime");
            if (scmOdSetDt1.UpdateDateTime != scmOdSetDt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (scmOdSetDt1.LogicalDeleteCode != scmOdSetDt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (scmOdSetDt1.InqOriginalEpCd != scmOdSetDt2.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
            if (scmOdSetDt1.InqOriginalSecCd != scmOdSetDt2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (scmOdSetDt1.InqOtherEpCd != scmOdSetDt2.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (scmOdSetDt1.InqOtherSecCd != scmOdSetDt2.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (scmOdSetDt1.InquiryNumber != scmOdSetDt2.InquiryNumber) resList.Add("InquiryNumber");
            if (scmOdSetDt1.SetPartsMkrCd != scmOdSetDt2.SetPartsMkrCd) resList.Add("SetPartsMkrCd");
            if (scmOdSetDt1.SetPartsNumber != scmOdSetDt2.SetPartsNumber) resList.Add("SetPartsNumber");
            if (scmOdSetDt1.SetPartsMainSubNo != scmOdSetDt2.SetPartsMainSubNo) resList.Add("SetPartsMainSubNo");
            if (scmOdSetDt1.GoodsDivCd != scmOdSetDt2.GoodsDivCd) resList.Add("GoodsDivCd");
            if (scmOdSetDt1.RecyclePrtKindCode != scmOdSetDt2.RecyclePrtKindCode) resList.Add("RecyclePrtKindCode");
            if (scmOdSetDt1.RecyclePrtKindName != scmOdSetDt2.RecyclePrtKindName) resList.Add("RecyclePrtKindName");
            if (scmOdSetDt1.DeliveredGoodsDiv != scmOdSetDt2.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (scmOdSetDt1.HandleDivCode != scmOdSetDt2.HandleDivCode) resList.Add("HandleDivCode");
            if (scmOdSetDt1.GoodsShape != scmOdSetDt2.GoodsShape) resList.Add("GoodsShape");
            if (scmOdSetDt1.DelivrdGdsConfCd != scmOdSetDt2.DelivrdGdsConfCd) resList.Add("DelivrdGdsConfCd");
            if (scmOdSetDt1.DeliGdsCmpltDueDate != scmOdSetDt2.DeliGdsCmpltDueDate) resList.Add("DeliGdsCmpltDueDate");
            if (scmOdSetDt1.AnswerDeliveryDate != scmOdSetDt2.AnswerDeliveryDate) resList.Add("AnswerDeliveryDate");
            if (scmOdSetDt1.BLGoodsCode != scmOdSetDt2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (scmOdSetDt1.BLGoodsDrCode != scmOdSetDt2.BLGoodsDrCode) resList.Add("BLGoodsDrCode");
            if (scmOdSetDt1.InqGoodsName != scmOdSetDt2.InqGoodsName) resList.Add("InqGoodsName");
            if (scmOdSetDt1.AnsGoodsName != scmOdSetDt2.AnsGoodsName) resList.Add("AnsGoodsName");
            if (scmOdSetDt1.SalesOrderCount != scmOdSetDt2.SalesOrderCount) resList.Add("SalesOrderCount");
            if (scmOdSetDt1.DeliveredGoodsCount != scmOdSetDt2.DeliveredGoodsCount) resList.Add("DeliveredGoodsCount");
            if (scmOdSetDt1.GoodsNo != scmOdSetDt2.GoodsNo) resList.Add("GoodsNo");
            if (scmOdSetDt1.GoodsMakerCd != scmOdSetDt2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (scmOdSetDt1.GoodsMakerNm != scmOdSetDt2.GoodsMakerNm) resList.Add("GoodsMakerNm");
            if (scmOdSetDt1.PureGoodsMakerCd != scmOdSetDt2.PureGoodsMakerCd) resList.Add("PureGoodsMakerCd");
            if (scmOdSetDt1.InqPureGoodsNo != scmOdSetDt2.InqPureGoodsNo) resList.Add("InqPureGoodsNo");
            if (scmOdSetDt1.AnsPureGoodsNo != scmOdSetDt2.AnsPureGoodsNo) resList.Add("AnsPureGoodsNo");
            if (scmOdSetDt1.ListPrice != scmOdSetDt2.ListPrice) resList.Add("ListPrice");
            if (scmOdSetDt1.UnitPrice != scmOdSetDt2.UnitPrice) resList.Add("UnitPrice");
            if (scmOdSetDt1.GoodsAddInfo != scmOdSetDt2.GoodsAddInfo) resList.Add("GoodsAddInfo");
            if (scmOdSetDt1.RoughRrofit != scmOdSetDt2.RoughRrofit) resList.Add("RoughRrofit");
            if (scmOdSetDt1.RoughRate != scmOdSetDt2.RoughRate) resList.Add("RoughRate");
            if (scmOdSetDt1.AnswerLimitDate != scmOdSetDt2.AnswerLimitDate) resList.Add("AnswerLimitDate");
            if (scmOdSetDt1.CommentDtl != scmOdSetDt2.CommentDtl) resList.Add("CommentDtl");
            if (scmOdSetDt1.ShelfNo != scmOdSetDt2.ShelfNo) resList.Add("ShelfNo");
            if (scmOdSetDt1.PMAcptAnOdrStatus != scmOdSetDt2.PMAcptAnOdrStatus) resList.Add("PMAcptAnOdrStatus");
            if (scmOdSetDt1.PMSalesSlipNum != scmOdSetDt2.PMSalesSlipNum) resList.Add("PMSalesSlipNum");
            if (scmOdSetDt1.PMSalesRowNo != scmOdSetDt2.PMSalesRowNo) resList.Add("PMSalesRowNo");
            if (scmOdSetDt1.PmWarehouseCd != scmOdSetDt2.PmWarehouseCd) resList.Add("PmWarehouseCd");
            if (scmOdSetDt1.PmWarehouseName != scmOdSetDt2.PmWarehouseName) resList.Add("PmWarehouseName");
            if (scmOdSetDt1.PmShelfNo != scmOdSetDt2.PmShelfNo) resList.Add("PmShelfNo");
            if (scmOdSetDt1.PmPrsntCount != scmOdSetDt2.PmPrsntCount) resList.Add("PmPrsntCount");

            return resList;
        }
    }
}
