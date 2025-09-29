using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PccItemSt
    /// <summary>
    ///                      PCC品目設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   PCC品目設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2011/7/21</br>
    /// <br>Genarated Date   :   2011/08/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PccItemSt
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

        /// <summary>問合せ条件</summary>
        private string _inqCondition = "";

        /// <summary>PCC自社コード</summary>
        /// <remarks>PMの得意先コード</remarks>
        private Int32 _pccCompanyCode;

        /// <summary>品目グループコード</summary>
        /// <remarks>1～5の使用を想定</remarks>
        private Int32 _itemGroupCode;

        /// <summary>品目表示位置1</summary>
        /// <remarks>横(X)方向の位置 0～Z</remarks>
        private Int32 _itemDspPos1;

        /// <summary>品目表示位置2</summary>
        /// <remarks>縦(Y)方向の位置 0～</remarks>
        private Int32 _itemDspPos2;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品名</summary>
        private string _bLGoodsName = "";

        /// <summary>品目QTY</summary>
        private Int32 _itemQty;

        /// <summary>品目選択区分</summary>
        /// <remarks>0:OFF 1:選択ｳｨﾝﾄﾞｳ表示</remarks>
        private Int32 _itemSelectDiv;

        /// <summary>更新区分</summary>
        /// <remarks>0:新規 1:更新 2:削除</remarks>
        private Int32 _updateFlag;


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

        /// public propaty name  :  InqCondition
        /// <summary>問合せ条件プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ条件プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqCondition
        {
            get { return _inqCondition; }
            set { _inqCondition = value; }
        }

        /// public propaty name  :  PccCompanyCode
        /// <summary>PCC自社コードプロパティ</summary>
        /// <value>PMの得意先コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC自社コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PccCompanyCode
        {
            get { return _pccCompanyCode; }
            set { _pccCompanyCode = value; }
        }

        /// public propaty name  :  ItemGroupCode
        /// <summary>品目グループコードプロパティ</summary>
        /// <value>1～5の使用を想定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ItemGroupCode
        {
            get { return _itemGroupCode; }
            set { _itemGroupCode = value; }
        }

        /// public propaty name  :  ItemDspPos1
        /// <summary>品目表示位置1プロパティ</summary>
        /// <value>横(X)方向の位置 0～Z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目表示位置1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ItemDspPos1
        {
            get { return _itemDspPos1; }
            set { _itemDspPos1 = value; }
        }

        /// public propaty name  :  ItemDspPos2
        /// <summary>品目表示位置2プロパティ</summary>
        /// <value>縦(Y)方向の位置 0～</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目表示位置2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ItemDspPos2
        {
            get { return _itemDspPos2; }
            set { _itemDspPos2 = value; }
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

        /// public propaty name  :  BLGoodsName
        /// <summary>BL商品名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsName
        {
            get { return _bLGoodsName; }
            set { _bLGoodsName = value; }
        }

        /// public propaty name  :  ItemQty
        /// <summary>品目QTYプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目QTYプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ItemQty
        {
            get { return _itemQty; }
            set { _itemQty = value; }
        }

        /// public propaty name  :  ItemSelectDiv
        /// <summary>品目選択区分プロパティ</summary>
        /// <value>0:OFF 1:選択ｳｨﾝﾄﾞｳ表示</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目選択区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ItemSelectDiv
        {
            get { return _itemSelectDiv; }
            set { _itemSelectDiv = value; }
        }

        /// public propaty name  :  UpdateFlag
        /// <summary>更新区分プロパティ</summary>
        /// <value>0:新規 1:更新 2:削除</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateFlag
        {
            get { return _updateFlag; }
            set { _updateFlag = value; }
        }


        /// <summary>
        /// PCC品目設定マスタコンストラクタ
        /// </summary>
        /// <returns>PccItemStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccItemStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PccItemSt()
        {
        }

        /// <summary>
        /// PCC品目設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="inqOriginalEpCd">問合せ元企業コード</param>
        /// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
        /// <param name="inqOtherEpCd">問合せ先企業コード</param>
        /// <param name="inqOtherSecCd">問合せ先拠点コード</param>
        /// <param name="inqCondition">問合せ条件</param>
        /// <param name="pccCompanyCode">PCC自社コード(PMの得意先コード)</param>
        /// <param name="itemGroupCode">品目グループコード(1～5の使用を想定)</param>
        /// <param name="itemDspPos1">品目表示位置1(横(X)方向の位置 0～Z)</param>
        /// <param name="itemDspPos2">品目表示位置2(縦(Y)方向の位置 0～)</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="bLGoodsName">BL商品名</param>
        /// <param name="itemQty">品目QTY</param>
        /// <param name="itemSelectDiv">品目選択区分(0:OFF 1:選択ｳｨﾝﾄﾞｳ表示)</param>
        /// <param name="updateFlag">更新区分(0:新規 1:更新 2:削除)</param>
        /// <returns>PccItemStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccItemStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PccItemSt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, string inqCondition, Int32 pccCompanyCode, Int32 itemGroupCode, Int32 itemDspPos1, Int32 itemDspPos2, Int32 bLGoodsCode, string bLGoodsName, Int32 itemQty, Int32 itemSelectDiv, Int32 updateFlag)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._inqOtherEpCd = inqOtherEpCd;
            this._inqOtherSecCd = inqOtherSecCd;
            this._inqCondition = inqCondition;
            this._pccCompanyCode = pccCompanyCode;
            this._itemGroupCode = itemGroupCode;
            this._itemDspPos1 = itemDspPos1;
            this._itemDspPos2 = itemDspPos2;
            this._bLGoodsCode = bLGoodsCode;
            this._bLGoodsName = bLGoodsName;
            this._itemQty = itemQty;
            this._itemSelectDiv = itemSelectDiv;
            this._updateFlag = updateFlag;

        }

        /// <summary>
        /// PCC品目設定マスタ複製処理
        /// </summary>
        /// <returns>PccItemStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいPccItemStクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PccItemSt Clone()
        {
            return new PccItemSt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd.Trim(), this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inqCondition, this._pccCompanyCode, this._itemGroupCode, this._itemDspPos1, this._itemDspPos2, this._bLGoodsCode, this._bLGoodsName, this._itemQty, this._itemSelectDiv, this._updateFlag);//@@@@20230303
        }

        /// <summary>
        /// PCC品目設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のPccItemStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccItemStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(PccItemSt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim())//@@@@20230303
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.InqOtherEpCd == target.InqOtherEpCd)
                 && (this.InqOtherSecCd == target.InqOtherSecCd)
                 && (this.InqCondition == target.InqCondition)
                 && (this.PccCompanyCode == target.PccCompanyCode)
                 && (this.ItemGroupCode == target.ItemGroupCode)
                 && (this.ItemDspPos1 == target.ItemDspPos1)
                 && (this.ItemDspPos2 == target.ItemDspPos2)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.BLGoodsName == target.BLGoodsName)
                 && (this.ItemQty == target.ItemQty)
                 && (this.ItemSelectDiv == target.ItemSelectDiv)
                 && (this.UpdateFlag == target.UpdateFlag));
        }

        /// <summary>
        /// PCC品目設定マスタ比較処理
        /// </summary>
        /// <param name="pccItemSt1">
        ///                    比較するPccItemStクラスのインスタンス
        /// </param>
        /// <param name="pccItemSt2">比較するPccItemStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccItemStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(PccItemSt pccItemSt1, PccItemSt pccItemSt2)
        {
            return ((pccItemSt1.CreateDateTime == pccItemSt2.CreateDateTime)
                 && (pccItemSt1.UpdateDateTime == pccItemSt2.UpdateDateTime)
                 && (pccItemSt1.LogicalDeleteCode == pccItemSt2.LogicalDeleteCode)
                 && (pccItemSt1.InqOriginalEpCd.Trim() == pccItemSt2.InqOriginalEpCd.Trim())//@@@@20230303
                 && (pccItemSt1.InqOriginalSecCd == pccItemSt2.InqOriginalSecCd)
                 && (pccItemSt1.InqOtherEpCd == pccItemSt2.InqOtherEpCd)
                 && (pccItemSt1.InqOtherSecCd == pccItemSt2.InqOtherSecCd)
                 && (pccItemSt1.InqCondition == pccItemSt2.InqCondition)
                 && (pccItemSt1.PccCompanyCode == pccItemSt2.PccCompanyCode)
                 && (pccItemSt1.ItemGroupCode == pccItemSt2.ItemGroupCode)
                 && (pccItemSt1.ItemDspPos1 == pccItemSt2.ItemDspPos1)
                 && (pccItemSt1.ItemDspPos2 == pccItemSt2.ItemDspPos2)
                 && (pccItemSt1.BLGoodsCode == pccItemSt2.BLGoodsCode)
                 && (pccItemSt1.BLGoodsName == pccItemSt2.BLGoodsName)
                 && (pccItemSt1.ItemQty == pccItemSt2.ItemQty)
                 && (pccItemSt1.ItemSelectDiv == pccItemSt2.ItemSelectDiv)
                 && (pccItemSt1.UpdateFlag == pccItemSt2.UpdateFlag));
        }
        /// <summary>
        /// PCC品目設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のPccItemStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccItemStクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(PccItemSt target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (this.InqCondition != target.InqCondition) resList.Add("InqCondition");
            if (this.PccCompanyCode != target.PccCompanyCode) resList.Add("PccCompanyCode");
            if (this.ItemGroupCode != target.ItemGroupCode) resList.Add("ItemGroupCode");
            if (this.ItemDspPos1 != target.ItemDspPos1) resList.Add("ItemDspPos1");
            if (this.ItemDspPos2 != target.ItemDspPos2) resList.Add("ItemDspPos2");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");
            if (this.ItemQty != target.ItemQty) resList.Add("ItemQty");
            if (this.ItemSelectDiv != target.ItemSelectDiv) resList.Add("ItemSelectDiv");
            if (this.UpdateFlag != target.UpdateFlag) resList.Add("UpdateFlag");

            return resList;
        }

        /// <summary>
        /// PCC品目設定マスタ比較処理
        /// </summary>
        /// <param name="pccItemSt1">比較するPccItemStクラスのインスタンス</param>
        /// <param name="pccItemSt2">比較するPccItemStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccItemStクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(PccItemSt pccItemSt1, PccItemSt pccItemSt2)
        {
            ArrayList resList = new ArrayList();
            if (pccItemSt1.CreateDateTime != pccItemSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (pccItemSt1.UpdateDateTime != pccItemSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (pccItemSt1.LogicalDeleteCode != pccItemSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (pccItemSt1.InqOriginalEpCd.Trim() != pccItemSt2.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (pccItemSt1.InqOriginalSecCd != pccItemSt2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (pccItemSt1.InqOtherEpCd != pccItemSt2.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (pccItemSt1.InqOtherSecCd != pccItemSt2.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (pccItemSt1.InqCondition != pccItemSt2.InqCondition) resList.Add("InqCondition");
            if (pccItemSt1.PccCompanyCode != pccItemSt2.PccCompanyCode) resList.Add("PccCompanyCode");
            if (pccItemSt1.ItemGroupCode != pccItemSt2.ItemGroupCode) resList.Add("ItemGroupCode");
            if (pccItemSt1.ItemDspPos1 != pccItemSt2.ItemDspPos1) resList.Add("ItemDspPos1");
            if (pccItemSt1.ItemDspPos2 != pccItemSt2.ItemDspPos2) resList.Add("ItemDspPos2");
            if (pccItemSt1.BLGoodsCode != pccItemSt2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (pccItemSt1.BLGoodsName != pccItemSt2.BLGoodsName) resList.Add("BLGoodsName");
            if (pccItemSt1.ItemQty != pccItemSt2.ItemQty) resList.Add("ItemQty");
            if (pccItemSt1.ItemSelectDiv != pccItemSt2.ItemSelectDiv) resList.Add("ItemSelectDiv");
            if (pccItemSt1.UpdateFlag != pccItemSt2.UpdateFlag) resList.Add("UpdateFlag");

            return resList;
        }
    }
}
