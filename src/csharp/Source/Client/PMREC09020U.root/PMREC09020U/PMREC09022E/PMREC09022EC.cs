//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : お買得商品個別設定マスタ
// プログラム概要   : お買得商品個別設定マスタを行う
//----------------------------------------------------------------------------//
//                (c)Copyright 2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 作 成 日  2015/02/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   RecBgnCust
    /// <summary>
    ///                      お買得商品個別設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   お買得商品個別設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2015/02/20</br>
    /// <br>Genarated Date   :   2015/02/20  (CSharp File Generated Date)</br>
    /// </remarks>
    public class RecBgnCust
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

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品適用開始日</summary>
        private Int32 _goodsApplyStaDate;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>管理拠点コード</summary>
        private string _mngSectionCode = "";

        /// <summary>ﾒｰｶｰ希望小売価格</summary>
        private Int64 _mkrSuggestRtPric;

        /// <summary>定価</summary>
        private Int64 _listPrice;

        /// <summary>単価算出掛率</summary>
        private Double _unitCalcRate;

        /// <summary>売上単価</summary>
        private Int64 _unitPrice;

        /// <summary>公開開始日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyStaDate;

        /// <summary>公開終了日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyEndDate;

        /// <summary>お買得商品グループコード</summary>
        private Int16 _brgnGoodsGrpCode;

        /// <summary>表示区分</summary>
        private Int32 _displayDivCode;

        /// <summary>行数</summary>
        private Int32 _rowIndex;

        /// <summary>新規行フラグ</summary>
        private Boolean _isUpdRow;

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

        /// public propaty name  :  GoodsApplyStaDate
        /// <summary>商品適用開始日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品適用開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsApplyStaDate
        {
            get { return _goodsApplyStaDate; }
            set { _goodsApplyStaDate = value; }
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

        /// public propaty name  :  InqOtherSecCd
        /// <summary>管理拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   管理拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MngSectionCode
        {
            get { return _mngSectionCode; }
            set { _mngSectionCode = value; }
        }

        /// public propaty name  :  MkrSuggestRtPric
        /// <summary>ﾒｰｶｰ希望小売価格プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ﾒｰｶｰ希望小売価格プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MkrSuggestRtPric
        {
            get { return _mkrSuggestRtPric; }
            set { _mkrSuggestRtPric = value; }
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

        /// public propaty name  :  UnitCalcRate
        /// <summary>単価算出掛率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価算出掛率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double UnitCalcRate
        {
            get { return _unitCalcRate; }
            set { _unitCalcRate = value; }
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

        /// public propaty name  :  ApplyStaDate
        /// <summary>適用開始日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ApplyStaDate
        {
            get { return _applyStaDate; }
            set { _applyStaDate = value; }
        }

        /// public propaty name  :  ApplyEndDate
        /// <summary>適用終了日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用終了日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ApplyEndDate
        {
            get { return _applyEndDate; }
            set { _applyEndDate = value; }
        }

        /// public propaty name  :  BrgnGoodsGrpCode
        /// <summary>お買得商品グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   お買得商品グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 BrgnGoodsGrpCode
        {
            get { return _brgnGoodsGrpCode; }
            set { _brgnGoodsGrpCode = value; }
        }

        /// public propaty name  :  DisplayDivCode
        /// <summary>表示区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品画像プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DisplayDivCode
        {
            get { return _displayDivCode; }
            set { _displayDivCode = value; }
        }       

        /// public propaty name  :  RowIndex
        /// <summary>行数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   行数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RowIndex
        {
            get { return _rowIndex; }
            set { _rowIndex = value; }
        }

        /// public propaty name  :  IsUpdRow
        /// <summary>新規行フラグプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   新規行フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean IsUpdRow
        {
            get { return _isUpdRow; }
            set { _isUpdRow = value; }
        }

        /// <summary>
        /// お買得商品個別設定マスタコンストラクタ
        /// </summary>
        /// <returns>RecBgnCustクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnCustクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RecBgnCust()
        {
        }

        /// <summary>
        /// お買得商品個別設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時</param>
        /// <param name="updateDateTime">更新日時</param>
        /// <param name="logicalDeleteCode">論理削除区分</param>
        /// <param name="inqOriginalEpCd">問合せ元企業コード</param>
        /// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
        /// <param name="inqOtherEpCd">問合せ先企業コード</param>
        /// <param name="inqOtherSecCd">問合せ先拠点コード</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="goodsApplyStaDate">商品適用開始日</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="mngSectionCode">管理拠点コード</param>
        /// <param name="mkrSuggestRtPric">ﾒｰｶｰ希望小売価格</param>
        /// <param name="listPrice">定価</param>
        /// <param name="unitCalcRate">単価算出掛率</param>
        /// <param name="unitPrice">売上単価</param>
        /// <param name="applyStaDate">公開開始日</param>
        /// <param name="applyEndDate">公開終了日</param>
        /// <param name="brgnGoodsGrpCode">お買得商品グループコード</param>
        /// <param name="displayDivCode">表示区分</param>
        /// <param name="rowIndex">行数</param>
        /// <param name="isUpdRow">新規行フラグ</param>
        /// <returns>RecBgnCustクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnCustクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RecBgnCust(
            DateTime createDateTime,
            DateTime updateDateTime,
            Int32 logicalDeleteCode,
            string inqOriginalEpCd,
            string inqOriginalSecCd,
            string inqOtherEpCd,
            string inqOtherSecCd,
            string goodsNo,
            Int32 goodsMakerCd,
            Int32 goodsApplyStaDate,
            Int32 customerCode,
            string mngSectionCode,
            Int64 mkrSuggestRtPric,
            Int64 listPrice,
            Double unitCalcRate,
            Int64 unitPrice,
            Int32 applyStaDate,
            Int32 applyEndDate,
            Int32 displayDivCode,
            Int16 brgnGoodsGrpCode,
            Int32 rowIndex,
            Boolean isUpdRow
        )
        {
            this.CreateDateTime = createDateTime;           // 作成日時
            this.UpdateDateTime = updateDateTime;           // 更新日時
            this._logicalDeleteCode = logicalDeleteCode;    // 論理削除区分
            this._inqOriginalEpCd = inqOriginalEpCd;        // 問合せ元企業コード
            this._inqOriginalSecCd = inqOriginalSecCd;      // 問合せ元拠点コード
            this._inqOtherEpCd = inqOtherEpCd;              // 問合せ先企業コード      
            this._inqOtherSecCd = inqOtherSecCd;            // 問合せ先拠点コード
            this._goodsNo = goodsNo;                        // 商品番号
            this._goodsMakerCd = goodsMakerCd;              // 商品メーカーコード
            this._goodsApplyStaDate = goodsApplyStaDate;    // 商品適用開始日
            this._customerCode = customerCode;              // 得意先コード
            this._mngSectionCode = mngSectionCode;          // 管理拠点コード
            this._mkrSuggestRtPric = mkrSuggestRtPric;      // ﾒｰｶｰ希望小売価格
            this._listPrice = listPrice;                    // 定価
            this._unitCalcRate = unitCalcRate;              // 単価算出掛率
            this._unitPrice = unitPrice;                    // 単価
            this._applyStaDate = applyStaDate;              // 適用開始日
            this._applyEndDate = applyEndDate;              // 適用終了日
            this._displayDivCode = displayDivCode;          // 表示区分
            this._brgnGoodsGrpCode = brgnGoodsGrpCode;      // お買得商品グループコード
            this._rowIndex = rowIndex;
            this._isUpdRow = isUpdRow;
        }

        /// <summary>
        /// お買得商品個別設定マスタ複製処理
        /// </summary>
        /// <returns>RecBgnCustクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいRecBgnCustクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RecBgnCust Clone()
        {
            return new RecBgnCust(
                this._createDateTime, 
                this._updateDateTime, 
                this._logicalDeleteCode, 
                this._inqOriginalEpCd, 
                this._inqOriginalSecCd, 
                this._inqOtherEpCd, 
                this._inqOtherSecCd,
                this._goodsNo,
                this._goodsMakerCd,
                this._goodsApplyStaDate,
                this._customerCode,
                this._mngSectionCode,
                this._mkrSuggestRtPric, 
                this._listPrice, 
                this._unitCalcRate,
                this._unitPrice, 
                this._applyStaDate, 
                this._applyEndDate,
                this._displayDivCode,
                this._brgnGoodsGrpCode, 
                this._rowIndex, 
                this._isUpdRow
            );
        }
    }
}