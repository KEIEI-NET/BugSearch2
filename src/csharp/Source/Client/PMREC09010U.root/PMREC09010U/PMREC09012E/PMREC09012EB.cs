using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   RecGoodsLkSt
    /// <summary>
    ///                      リコメンド商品関連設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   リコメンド商品関連設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2015/01/20</br>
    /// </remarks>
    public class RecGoodsLkSt
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

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>推奨元BL商品コード</summary>
        private Int32 _recSourceBLGoodsCd;

        /// <summary>推奨先BL商品コード</summary>
        private Int32 _recDestBLGoodsCd;

        /// <summary>推奨先BL商品コード名称</summary>
        private string _recDestBLGoodsNm = "";

        // --- ADD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------>>>>>
        /// <summary>商品コメント</summary>
        private string _goodsComment = "";
        // --- ADD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------<<<<<
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

        /// public propaty name  :  RecSourceBLGoodsCd
        /// <summary>推奨元BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   推奨元BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RecSourceBLGoodsCd
        {
            get { return _recSourceBLGoodsCd; }
            set { _recSourceBLGoodsCd = value; }
        }

        /// public propaty name  :  RecDestBLGoodsCd
        /// <summary>推奨先BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   推奨先BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RecDestBLGoodsCd
        {
            get { return _recDestBLGoodsCd; }
            set { _recDestBLGoodsCd = value; }
        }

        /// public propaty name  :  RecDestBLGoodsNm
        /// <summary>推奨先BL商品コード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   推奨先BL商品コード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RecDestBLGoodsNm
        {
            get { return _recDestBLGoodsNm; }
            set { _recDestBLGoodsNm = value; }
        }

        // --- ADD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------>>>>>
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
        // --- ADD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------<<<<<

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
        /// リコメンド商品関連設定マスタコンストラクタ
        /// </summary>
        /// <returns>RecGoodsLkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecGoodsLkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RecGoodsLkSt()
        {
        }

        /// <summary>
        /// リコメンド商品関連設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="InqOriginalEpCdRF">問合せ元企業コード</param>
        /// <param name="InqOriginalSecCdRF">問合せ元拠点コード</param>
        /// <param name="InqOtherEpCdRF">問合せ先企業コード</param>
        /// <param name="InqOtherSecCdRF">問合せ先拠点コード</param>
        /// <param name="CustomerCodeRF">得意先コード</param>
        /// <param name="RecSourceBLGoodsCdRF">推奨元BL商品コード</param>
        /// <param name="RecDestBLGoodsCdRF">推奨先BL商品コード</param>
        /// <param name="RecDestBLGoodsNmRF">推奨先BL商品コード名称</param>
        /// <param name="rowIndex">行数</param>
        /// <param name="isUpdRow">新規行フラグ</param>
        /// <returns>RecGoodsLkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecGoodsLkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        // --- UPD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------>>>>>
        //public RecGoodsLkSt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 customerCode, Int32 recSourceBLGoodsCd, Int32 recDestBLGoodsCd, string recDestBLGoodsNm, Int32 rowIndex, Boolean isUpdRow)
        public RecGoodsLkSt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 customerCode, Int32 recSourceBLGoodsCd, Int32 recDestBLGoodsCd, string recDestBLGoodsNm, string goodsComment, Int32 rowIndex, Boolean isUpdRow)
        // --- UPD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------<<<<<
        {
            this._createDateTime = createDateTime;
            this._updateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._inqOriginalEpCd = inqOriginalEpCd;
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._inqOtherEpCd = inqOtherEpCd;
            this._inqOtherSecCd = inqOtherSecCd;
            this._customerCode = customerCode;
            this._recSourceBLGoodsCd = recSourceBLGoodsCd;
            this._recDestBLGoodsCd = recDestBLGoodsCd;
            this._recDestBLGoodsNm = recDestBLGoodsNm;
            this._goodsComment = goodsComment; // ADD 2015/02/06 T.Miyamoto コメント項目追加
            this._rowIndex = rowIndex;
            this._isUpdRow = isUpdRow;
        }

        /// <summary>
        /// リコメンド商品関連設定マスタ複製処理
        /// </summary>
        /// <returns>RecGoodsLkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいRecGoodsLkクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RecGoodsLkSt Clone()
        {
            // --- UPD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------>>>>>
            //return new RecGoodsLkSt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._customerCode, this._recSourceBLGoodsCd, this._recDestBLGoodsCd, this._recDestBLGoodsNm, this._rowIndex, this._isUpdRow);
            return new RecGoodsLkSt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._customerCode, this._recSourceBLGoodsCd, this._recDestBLGoodsCd, this._recDestBLGoodsNm, this._goodsComment, this._rowIndex, this._isUpdRow);
            // --- UPD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------<<<<<
        }

        /// <summary>
        /// リコメンド商品関連設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のRecGoodsLkクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecGoodsLkクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(RecGoodsLkSt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOriginalEpCd == target.InqOriginalEpCd)
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.InqOtherEpCd == target.InqOtherEpCd)
                 && (this.InqOtherSecCd == target.InqOtherSecCd)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.RecSourceBLGoodsCd == target.RecSourceBLGoodsCd)
                 && (this.RecDestBLGoodsCd == target.RecDestBLGoodsCd)
                 && (this.RecDestBLGoodsNm == target.RecDestBLGoodsNm)
                 && (this.GoodsComment == target.GoodsComment) // ADD 2015/02/06 T.Miyamoto コメント項目追加
                 && (this.RowIndex == target.RowIndex)
                 && (this.IsUpdRow == target.IsUpdRow));
        }

        /// <summary>
        /// リコメンド商品関連設定マスタ比較処理
        /// </summary>
        /// <param name="RecGoodsLk1">比較するRecGoodsLkクラスのインスタンス</param>
        /// <param name="RecGoodsLk2">比較するRecGoodsLkクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecGoodsLkクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(RecGoodsLkSt RecGoodsLk1, RecGoodsLkSt RecGoodsLk2)
        {
            return ((RecGoodsLk1.CreateDateTime == RecGoodsLk2.CreateDateTime)
                 && (RecGoodsLk1.UpdateDateTime == RecGoodsLk2.UpdateDateTime)
                 && (RecGoodsLk1.LogicalDeleteCode == RecGoodsLk2.LogicalDeleteCode)
                 && (RecGoodsLk1.InqOriginalEpCd == RecGoodsLk2.InqOriginalEpCd)
                 && (RecGoodsLk1.InqOriginalSecCd == RecGoodsLk2.InqOriginalSecCd)
                 && (RecGoodsLk1.InqOtherEpCd == RecGoodsLk2.InqOtherEpCd)
                 && (RecGoodsLk1.InqOtherSecCd == RecGoodsLk2.InqOtherSecCd)
                 && (RecGoodsLk1.CustomerCode == RecGoodsLk2.CustomerCode)
                 && (RecGoodsLk1.RecSourceBLGoodsCd == RecGoodsLk2.RecSourceBLGoodsCd)
                 && (RecGoodsLk1.RecDestBLGoodsCd == RecGoodsLk2.RecDestBLGoodsCd)
                 && (RecGoodsLk1.RecDestBLGoodsNm == RecGoodsLk2.RecDestBLGoodsNm)
                 && (RecGoodsLk1.GoodsComment == RecGoodsLk2.GoodsComment) // ADD 2015/02/06 T.Miyamoto コメント項目追加
                 && (RecGoodsLk1.RowIndex == RecGoodsLk2.RowIndex)
                 && (RecGoodsLk1.IsUpdRow == RecGoodsLk2.IsUpdRow));
        }
        /// <summary>
        /// リコメンド商品関連設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のRecGoodsLkクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecGoodsLkクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(RecGoodsLkSt target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.InqOriginalEpCd != target.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
            if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.RecSourceBLGoodsCd != target.RecSourceBLGoodsCd) resList.Add("RecSourceBLGoodsCd");
            if (this.RecDestBLGoodsCd != target.RecDestBLGoodsCd) resList.Add("RecDestBLGoodsCd");
            if (this.RecDestBLGoodsNm != target.RecDestBLGoodsNm) resList.Add("RecDestBLGoodsNm");
            if (this.GoodsComment != target.GoodsComment) resList.Add("GoodsComment"); // ADD 2015/02/06 T.Miyamoto コメント項目追加
            if (this.RowIndex != target.RowIndex) resList.Add("RowIndex");
            if (this.IsUpdRow != target.IsUpdRow) resList.Add("IsUpdRow");

            return resList;
        }

        /// <summary>
        /// リコメンド商品関連設定マスタ比較処理
        /// </summary>
        /// <param name="RecGoodsLk1">比較するRecGoodsLkクラスのインスタンス</param>
        /// <param name="RecGoodsLk2">比較するRecGoodsLkクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecGoodsLkクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(RecGoodsLkSt RecGoodsLk1, RecGoodsLkSt RecGoodsLk2)
        {
            ArrayList resList = new ArrayList();
            if (RecGoodsLk1.CreateDateTime != RecGoodsLk2.CreateDateTime) resList.Add("CreateDateTime");
            if (RecGoodsLk1.UpdateDateTime != RecGoodsLk2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (RecGoodsLk1.LogicalDeleteCode != RecGoodsLk2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (RecGoodsLk1.InqOriginalEpCd != RecGoodsLk2.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
            if (RecGoodsLk1.InqOriginalSecCd != RecGoodsLk2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (RecGoodsLk1.InqOtherEpCd != RecGoodsLk2.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (RecGoodsLk1.InqOtherSecCd != RecGoodsLk2.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (RecGoodsLk1.CustomerCode != RecGoodsLk2.CustomerCode) resList.Add("CustomerCode");
            if (RecGoodsLk1.RecSourceBLGoodsCd != RecGoodsLk2.RecSourceBLGoodsCd) resList.Add("RecSourceBLGoodsCd");
            if (RecGoodsLk1.RecDestBLGoodsCd != RecGoodsLk2.RecDestBLGoodsCd) resList.Add("RecDestBLGoodsCd");
            if (RecGoodsLk1.RecDestBLGoodsNm != RecGoodsLk2.RecDestBLGoodsNm) resList.Add("RecDestBLGoodsNm");
            if (RecGoodsLk1.GoodsComment != RecGoodsLk2.GoodsComment) resList.Add("GoodsComment"); // ADD 2015/02/06 T.Miyamoto コメント項目追加
            if (RecGoodsLk1.RowIndex != RecGoodsLk2.RowIndex) resList.Add("RowIndex");
            if (RecGoodsLk1.IsUpdRow != RecGoodsLk2.IsUpdRow) resList.Add("IsUpdRow");

            return resList;
        }
    }
}