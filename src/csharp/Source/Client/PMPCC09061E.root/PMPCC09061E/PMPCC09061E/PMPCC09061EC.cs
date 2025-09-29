using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PccCpItmSt
    /// <summary>
    ///                      PCCキャンペーン品目設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   PCCキャンペーン品目設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2011/7/21</br>
    /// <br>Genarated Date   :   2011/08/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PccCpItmSt
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

        /// <summary>キャンペーンコード</summary>
        private Int32 _campaignCode;

        /// <summary>キャンペーン設定区分</summary>
        /// <remarks>0:BLコード,1:品番</remarks>
        private Int32 _campStDiv;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品名称</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _goodsName = "";

        /// <summary>商品名称カナ</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _goodsNameKana = "";

        /// <summary>品目QTY</summary>
        private Int32 _itemQty;

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

        /// public propaty name  :  CampaignCode
        /// <summary>キャンペーンコードプロパティ</summary>
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

        /// public propaty name  :  CampStDiv
        /// <summary>キャンペーン設定区分プロパティ</summary>
        /// <value>0:BLコード,1:品番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーン設定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CampStDiv
        {
            get { return _campStDiv; }
            set { _campStDiv = value; }
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

        /// public propaty name  :  GoodsName
        /// <summary>商品名称プロパティ</summary>
        /// <value>(半角全角混在)</value>
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

        /// public propaty name  :  GoodsNameKana
        /// <summary>商品名称カナプロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
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
        /// PCCキャンペーン品目設定マスタコンストラクタ
        /// </summary>
        /// <returns>PccCpItmStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCpItmStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PccCpItmSt()
        {
        }

        /// <summary>
        /// PCCキャンペーン品目設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="inqOtherEpCd">問合せ先企業コード</param>
        /// <param name="inqOtherSecCd">問合せ先拠点コード</param>
        /// <param name="campaignCode">キャンペーンコード</param>
        /// <param name="campStDiv">キャンペーン設定区分(0:BLコード,1:品番)</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="goodsName">商品名称((半角全角混在))</param>
        /// <param name="goodsNameKana">商品名称カナ((半角全角混在))</param>
        /// <param name="itemQty">品目QTY</param>
        /// <param name="updateFlag">更新区分(0:新規 1:更新 2:削除)</param>
        /// <returns>PccCpItmStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCpItmStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PccCpItmSt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOtherEpCd, string inqOtherSecCd, Int32 campaignCode, Int32 campStDiv, Int32 bLGoodsCode, string goodsNo, Int32 goodsMakerCd, string goodsName, string goodsNameKana, Int32 itemQty, Int32 updateFlag)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._inqOtherEpCd = inqOtherEpCd;
            this._inqOtherSecCd = inqOtherSecCd;
            this._campaignCode = campaignCode;
            this._campStDiv = campStDiv;
            this._bLGoodsCode = bLGoodsCode;
            this._goodsNo = goodsNo;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsName = goodsName;
            this._goodsNameKana = goodsNameKana;
            this._itemQty = itemQty;
            this._updateFlag = updateFlag;

        }

        /// <summary>
        /// PCCキャンペーン品目設定マスタ複製処理
        /// </summary>
        /// <returns>PccCpItmStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいPccCpItmStクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PccCpItmSt Clone()
        {
            return new PccCpItmSt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOtherEpCd, this._inqOtherSecCd, this._campaignCode, this._campStDiv, this._bLGoodsCode, this._goodsNo, this._goodsMakerCd, this._goodsName, this._goodsNameKana, this._itemQty, this._updateFlag);
        }

        /// <summary>
        /// PCCキャンペーン品目設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のPccCpItmStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCpItmStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(PccCpItmSt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOtherEpCd == target.InqOtherEpCd)
                 && (this.InqOtherSecCd == target.InqOtherSecCd)
                 && (this.CampaignCode == target.CampaignCode)
                 && (this.CampStDiv == target.CampStDiv)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsName == target.GoodsName)
                 && (this.GoodsNameKana == target.GoodsNameKana)
                 && (this.ItemQty == target.ItemQty)
                 && (this.UpdateFlag == target.UpdateFlag));
        }

        /// <summary>
        /// PCCキャンペーン品目設定マスタ比較処理
        /// </summary>
        /// <param name="pccCpItmSt1">
        ///                    比較するPccCpItmStクラスのインスタンス
        /// </param>
        /// <param name="pccCpItmSt2">比較するPccCpItmStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCpItmStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(PccCpItmSt pccCpItmSt1, PccCpItmSt pccCpItmSt2)
        {
            return ((pccCpItmSt1.CreateDateTime == pccCpItmSt2.CreateDateTime)
                 && (pccCpItmSt1.UpdateDateTime == pccCpItmSt2.UpdateDateTime)
                 && (pccCpItmSt1.LogicalDeleteCode == pccCpItmSt2.LogicalDeleteCode)
                 && (pccCpItmSt1.InqOtherEpCd == pccCpItmSt2.InqOtherEpCd)
                 && (pccCpItmSt1.InqOtherSecCd == pccCpItmSt2.InqOtherSecCd)
                 && (pccCpItmSt1.CampaignCode == pccCpItmSt2.CampaignCode)
                 && (pccCpItmSt1.CampStDiv == pccCpItmSt2.CampStDiv)
                 && (pccCpItmSt1.BLGoodsCode == pccCpItmSt2.BLGoodsCode)
                 && (pccCpItmSt1.GoodsNo == pccCpItmSt2.GoodsNo)
                 && (pccCpItmSt1.GoodsMakerCd == pccCpItmSt2.GoodsMakerCd)
                 && (pccCpItmSt1.GoodsName == pccCpItmSt2.GoodsName)
                 && (pccCpItmSt1.GoodsNameKana == pccCpItmSt2.GoodsNameKana)
                 && (pccCpItmSt1.ItemQty == pccCpItmSt2.ItemQty)
                 && (pccCpItmSt1.UpdateFlag == pccCpItmSt2.UpdateFlag));
        }
        /// <summary>
        /// PCCキャンペーン品目設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のPccCpItmStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCpItmStクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(PccCpItmSt target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (this.CampaignCode != target.CampaignCode) resList.Add("CampaignCode");
            if (this.CampStDiv != target.CampStDiv) resList.Add("CampStDiv");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.GoodsNameKana != target.GoodsNameKana) resList.Add("GoodsNameKana");
            if (this.ItemQty != target.ItemQty) resList.Add("ItemQty");
            if (this.UpdateFlag != target.UpdateFlag) resList.Add("UpdateFlag");

            return resList;
        }

        /// <summary>
        /// PCCキャンペーン品目設定マスタ比較処理
        /// </summary>
        /// <param name="pccCpItmSt1">比較するPccCpItmStクラスのインスタンス</param>
        /// <param name="pccCpItmSt2">比較するPccCpItmStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCpItmStクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(PccCpItmSt pccCpItmSt1, PccCpItmSt pccCpItmSt2)
        {
            ArrayList resList = new ArrayList();
            if (pccCpItmSt1.CreateDateTime != pccCpItmSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (pccCpItmSt1.UpdateDateTime != pccCpItmSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (pccCpItmSt1.LogicalDeleteCode != pccCpItmSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (pccCpItmSt1.InqOtherEpCd != pccCpItmSt2.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (pccCpItmSt1.InqOtherSecCd != pccCpItmSt2.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (pccCpItmSt1.CampaignCode != pccCpItmSt2.CampaignCode) resList.Add("CampaignCode");
            if (pccCpItmSt1.CampStDiv != pccCpItmSt2.CampStDiv) resList.Add("CampStDiv");
            if (pccCpItmSt1.BLGoodsCode != pccCpItmSt2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (pccCpItmSt1.GoodsNo != pccCpItmSt2.GoodsNo) resList.Add("GoodsNo");
            if (pccCpItmSt1.GoodsMakerCd != pccCpItmSt2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (pccCpItmSt1.GoodsName != pccCpItmSt2.GoodsName) resList.Add("GoodsName");
            if (pccCpItmSt1.GoodsNameKana != pccCpItmSt2.GoodsNameKana) resList.Add("GoodsNameKana");
            if (pccCpItmSt1.ItemQty != pccCpItmSt2.ItemQty) resList.Add("ItemQty");
            if (pccCpItmSt1.UpdateFlag != pccCpItmSt2.UpdateFlag) resList.Add("UpdateFlag");

            return resList;
        }
    }
}
