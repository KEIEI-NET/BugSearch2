//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : お買得商品設定マスタ
// プログラム概要   : お買得商品設定マスタを行う
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
    /// public class name:   RecBgnGds
    /// <summary>
    ///                      お買得商品設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   お買得商品設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2015/02/20</br>
    /// <br>Genarated Date   :   2015/02/20  (CSharp File Generated Date)</br>
    /// </remarks>
    public class RecBgnGds
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

        /// <summary>問合せ先企業コード</summary>
        private string _inqOtherEpCd = "";

        /// <summary>問合せ先拠点コード</summary>
        private string _inqOtherSecCd = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品メーカー名称</summary>
        private string _goodsMakerNm = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>BLグループコード</summary>
        private Int32 _bLGroupCode;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>商品コメント</summary>
        private string _goodsComment = "";

        /// <summary>ﾒｰｶｰ希望小売価格</summary>
        private Int64 _mkrSuggestRtPric;

        /// <summary>定価</summary>
        private Int64 _listPrice;

        /// <summary>単価算出掛率</summary>
        private Double _unitCalcRate;

        /// <summary>単価</summary>
        private Int64 _unitPrice;

        /// <summary>公開開始日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyStaDate;

        /// <summary>公開終了日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyEndDate;

        /// <summary>適合車種区分</summary>
        /// <remarks>0なし、1：あり</remarks>
        private Int16 _modelFitDiv;

        /// <summary>得意先掛率グループコード</summary>
        /// <remarks>(PMで利用)</remarks>
        private Int32 _custRateGrpCode;

        /// <summary>表示区分</summary>
        /// <remarks>0:表示、1:非表示</remarks>
        private Int32 _displayDivCode;

        /// <summary>お買得商品グループコード</summary>
        private Int16 _brgnGoodsGrpCode;

        /// <summary>商品画像</summary>
        private byte[] _goodsImage = new Byte[0];

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

        /// public propaty name  :  GoodsName
        /// <summary>商品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
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

        /// public propaty name  :  GoodsComment
        /// <summary>商品コメントプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品コメントプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsComment
        {
            get { return _goodsComment; }
            set { _goodsComment = value; }
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

        /// public propaty name  :  ModelFitDiv
        /// <summary>適合車種区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適合車種区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 ModelFitDiv
        {
            get { return _modelFitDiv; }
            set { _modelFitDiv = value; }
        }

        /// public propaty name  :  CustRateGrpCode
        /// <summary>得意先掛率グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先掛率グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustRateGrpCode
        {
            get { return _custRateGrpCode; }
            set { _custRateGrpCode = value; }
        }

        /// public propaty name  :  DisplayDivCode
        /// <summary>表示区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DisplayDivCode
        {
            get { return _displayDivCode; }
            set { _displayDivCode = value; }
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

        /// public propaty name  :  GoodsImage
        /// <summary>商品画像プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品画像プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public byte[] GoodsImage
        {
            get { return _goodsImage; }
            set { _goodsImage = value; }
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
        /// お買得商品設定マスタコンストラクタ
        /// </summary>
        /// <returns>RecBgnGdsクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGdsクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RecBgnGds()
        {
        }

        /// <summary>
        /// お買得商品設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時</param>
        /// <param name="updateDateTime">更新日時</param>
        /// <param name="logicalDeleteCode">論理削除区分</param>
        /// <param name="inqOtherEpCd">問合せ先企業コード</param>
        /// <param name="inqOtherSecCd">問合せ先拠点コード</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="goodsMakerNm">商品メーカー名称</param>
        /// <param name="goodsName">商品名称</param>
        /// <param name="bLGroupCode">BLグループコード</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="goodsComment">商品コメント</param>
        /// <param name="mkrSuggestRtPric">ﾒｰｶｰ希望小売価格</param>
        /// <param name="listPrice">定価</param>
        /// <param name="unitCalcRate">単価算出掛率</param>
        /// <param name="unitPrice">単価</param>
        /// <param name="applyStaDate">適用開始日</param>
        /// <param name="applyEndDate">適用終了日</param>
        /// <param name="modelFitDiv">適合車種区分</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <param name="displayDivCode">表示区分</param>
        /// <param name="brgnGoodsGrpCode">お買得商品グループコード</param>
        /// <param name="soodsImage">商品画像</param>
        /// <param name="rowIndex">行数</param>
        /// <param name="isUpdRow">新規行フラグ</param>
        /// <returns>RecBgnGdsクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGdsクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RecBgnGds(
            DateTime createDateTime,
            DateTime updateDateTime,
            Int32 logicalDeleteCode,
            string inqOtherEpCd,
            string inqOtherSecCd,
            string goodsNo,
            Int32 goodsMakerCd,
            string goodsMakerNm,
            string goodsName,
            Int32 bLGroupCode,
            Int32 bLGoodsCode,
            string goodsComment,
            Int64 mkrSuggestRtPric,
            Int64 listPrice,
            Double unitCalcRate,
            Int64 unitPrice,
            Int32 applyStaDate,
            Int32 applyEndDate,
            Int16 modelFitDiv,
            Int32 custRateGrpCode,
            Int32 displayDivCode,
            Int16 brgnGoodsGrpCode,
            byte[] goodsImage,
            Int32 rowIndex,
            Boolean isUpdRow
        )
        {
            this.CreateDateTime = createDateTime;           // 作成日時
            this.UpdateDateTime = updateDateTime;           // 更新日時
            this._logicalDeleteCode = logicalDeleteCode;    // 論理削除区分
            this._inqOtherEpCd = inqOtherEpCd;              // 問合せ先企業コード      
            this._inqOtherSecCd = inqOtherSecCd;            // 問合せ先拠点コード
            this._goodsNo = goodsNo;                        // 商品番号
            this._goodsMakerCd = goodsMakerCd;              // 商品メーカーコード
            this._goodsMakerNm = goodsMakerNm;              // 商品メーカー名称
            this._goodsName = goodsName;                    // 商品名称
            this._bLGroupCode = bLGroupCode;                // BLグループコード
            this._bLGoodsCode = bLGoodsCode;                // BL商品コード
            this._goodsComment = goodsComment;              // 商品コメント
            this._mkrSuggestRtPric = mkrSuggestRtPric;      // ﾒｰｶｰ希望小売価格
            this._listPrice = listPrice;                    // 定価
            this._unitCalcRate = unitCalcRate;              // 単価算出掛率
            this._unitPrice = unitPrice;                    // 単価
            this._applyStaDate = applyStaDate;              // 適用開始日
            this._applyEndDate = applyEndDate;              // 適用終了日
            this._modelFitDiv = modelFitDiv;                // 適合車種区分
            this._custRateGrpCode = custRateGrpCode;        // 得意先掛率グループコード
            this._displayDivCode = displayDivCode;          // 表示区分
            this._brgnGoodsGrpCode = brgnGoodsGrpCode;      // お買得商品グループコード
            this._goodsImage = goodsImage;                  // 商品画像
            this._rowIndex = rowIndex;
            this._isUpdRow = isUpdRow;
        }

        /// <summary>
        /// お買得商品設定マスタ複製処理
        /// </summary>
        /// <returns>RecBgnGdsクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいRecBgnGdsクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RecBgnGds Clone()
        {
            return new RecBgnGds(
                this._createDateTime, 
                this._updateDateTime, 
                this._logicalDeleteCode, 
                this._inqOtherEpCd, 
                this._inqOtherSecCd, 
                this._goodsNo,
                this._goodsMakerCd, 
                this._goodsMakerNm,
                this._goodsName, 
                this._bLGroupCode, 
                this._bLGoodsCode, 
                this._goodsComment, 
                this._mkrSuggestRtPric, 
                this._listPrice,
                this._unitCalcRate,
                this._unitPrice, 
                this._applyStaDate, 
                this._applyEndDate, 
                this._modelFitDiv,
                this._custRateGrpCode,
                this._displayDivCode,
                this._brgnGoodsGrpCode,
                this._goodsImage, 
                this._rowIndex, 
                this._isUpdRow
            );
        }
    }
}