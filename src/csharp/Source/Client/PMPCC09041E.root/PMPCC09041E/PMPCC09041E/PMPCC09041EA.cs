using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PccItemGrp
    /// <summary>
    ///                      PCC品目グループマスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   PCC品目グループマスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2011/7/21</br>
    /// <br>Genarated Date   :   2011/08/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2013/05/30 30747 三戸 伸悟</br>
    /// <br>                 :   2013/99/99配信 SCM障害№10541対応</br>
    /// <br>                 :   品目グループ画像コード追加</br>
    /// </remarks>
    public class PccItemGrp
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

        /// <summary>品目グループ名称</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _itemGroupName = "";

        /// <summary>品目グループ表示順位</summary>
        /// <remarks>左から順に1～5</remarks>
        private Int32 _itemGrpDspOdr;

        /// <summary>更新区分</summary>
        /// <remarks>0:新規 1:更新 2:削除</remarks>
        private Int32 _updateFlag;

        // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>品目グループ画像コード</summary>
        /// <remarks>1:ItemGrpImg01.png, 2:ItemGrpImg02.png …</remarks>
        private Int16 _itemGrpImgCode;
        // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

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

        /// public propaty name  :  ItemGroupName
        /// <summary>品目グループ名称プロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目グループ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ItemGroupName
        {
            get { return _itemGroupName; }
            set { _itemGroupName = value; }
        }

        /// public propaty name  :  ItemGrpDspOdr
        /// <summary>品目グループ表示順位プロパティ</summary>
        /// <value>左から順に1～5</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目グループ表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ItemGrpDspOdr
        {
            get { return _itemGrpDspOdr; }
            set { _itemGrpDspOdr = value; }
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

        // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  ItemGrpImgCode
        /// <summary>品目グループ画像コード</summary>
        /// <value>1:ItemGrpImg01.png, 2:ItemGrpImg02.png …</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目グループ画像コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 ItemGrpImgCode
        {
            get { return _itemGrpImgCode; }
            set { _itemGrpImgCode = value; }
        }
        // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// PCC品目グループマスタコンストラクタ
        /// </summary>
        /// <returns>PccItemGrpクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccItemGrpクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PccItemGrp()
        {
        }

        /// <summary>
        /// PCC品目グループマスタコンストラクタ
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
        /// <param name="itemGroupName">品目グループ名称((半角全角混在))</param>
        /// <param name="itemGrpDspOdr">品目グループ表示順位(左から順に1～5)</param>
        /// <param name="itemGrpImgCode">品目グループ画像コード</param>
        /// <param name="updateFlag">更新区分(0:新規 1:更新 2:削除)</param>
        /// <returns>PccItemGrpクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccItemGrpクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        // --- UPD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
        //public PccItemGrp(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, string inqCondition, Int32 pccCompanyCode, Int32 itemGroupCode, string itemGroupName, Int32 itemGrpDspOdr, Int32 updateFlag)
        public PccItemGrp(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, string inqCondition, Int32 pccCompanyCode, Int32 itemGroupCode, string itemGroupName, Int32 itemGrpDspOdr, Int32 updateFlag, Int16 itemGrpImgCode)
        // --- UPD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
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
            this._itemGroupName = itemGroupName;
            this._itemGrpDspOdr = itemGrpDspOdr;
            this._updateFlag = updateFlag;
            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            this._itemGrpImgCode = itemGrpImgCode;
            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        }

        /// <summary>
        /// PCC品目グループマスタ複製処理
        /// </summary>
        /// <returns>PccItemGrpクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいPccItemGrpクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PccItemGrp Clone()
        {
            // --- UPD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //return new PccItemGrp(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inqCondition, this._pccCompanyCode, this._itemGroupCode, this._itemGroupName, this._itemGrpDspOdr, this._updateFlag);
            return new PccItemGrp(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd.Trim(), this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inqCondition, this._pccCompanyCode, this._itemGroupCode, this._itemGroupName, this._itemGrpDspOdr, this._updateFlag, this._itemGrpImgCode);//@@@@20230303
            // --- UPD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// PCC品目グループマスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のPccItemGrpクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccItemGrpクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(PccItemGrp target)
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
                 && (this.ItemGroupName == target.ItemGroupName)
                 && (this.ItemGrpDspOdr == target.ItemGrpDspOdr)
                // --- UPD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                 //&& (this.UpdateFlag == target.UpdateFlag));
                 && (this.UpdateFlag == target.UpdateFlag)
                 && (this.ItemGrpImgCode == target.ItemGrpImgCode)
                 );
                // --- UPD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// PCC品目グループマスタ比較処理
        /// </summary>
        /// <param name="pccItemGrp1">
        ///                    比較するPccItemGrpクラスのインスタンス
        /// </param>
        /// <param name="pccItemGrp2">比較するPccItemGrpクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccItemGrpクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(PccItemGrp pccItemGrp1, PccItemGrp pccItemGrp2)
        {
            return ((pccItemGrp1.CreateDateTime == pccItemGrp2.CreateDateTime)
                 && (pccItemGrp1.UpdateDateTime == pccItemGrp2.UpdateDateTime)
                 && (pccItemGrp1.LogicalDeleteCode == pccItemGrp2.LogicalDeleteCode)
                 && (pccItemGrp1.InqOriginalEpCd.Trim() == pccItemGrp2.InqOriginalEpCd.Trim())//@@@@20230303
                 && (pccItemGrp1.InqOriginalSecCd == pccItemGrp2.InqOriginalSecCd)
                 && (pccItemGrp1.InqOtherEpCd == pccItemGrp2.InqOtherEpCd)
                 && (pccItemGrp1.InqOtherSecCd == pccItemGrp2.InqOtherSecCd)
                 && (pccItemGrp1.InqCondition == pccItemGrp2.InqCondition)
                 && (pccItemGrp1.PccCompanyCode == pccItemGrp2.PccCompanyCode)
                 && (pccItemGrp1.ItemGroupCode == pccItemGrp2.ItemGroupCode)
                 && (pccItemGrp1.ItemGroupName == pccItemGrp2.ItemGroupName)
                 && (pccItemGrp1.ItemGrpDspOdr == pccItemGrp2.ItemGrpDspOdr)
                // --- UPD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                 //&& (pccItemGrp1.UpdateFlag == pccItemGrp2.UpdateFlag));
                 && (pccItemGrp1.UpdateFlag == pccItemGrp2.UpdateFlag)
                 && (pccItemGrp1.ItemGrpImgCode == pccItemGrp2.ItemGrpImgCode)
                 );
                // --- UPD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }
        /// <summary>
        /// PCC品目グループマスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のPccItemGrpクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccItemGrpクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(PccItemGrp target)
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
            if (this.ItemGroupName != target.ItemGroupName) resList.Add("ItemGroupName");
            if (this.ItemGrpDspOdr != target.ItemGrpDspOdr) resList.Add("ItemGrpDspOdr");
            if (this.UpdateFlag != target.UpdateFlag) resList.Add("UpdateFlag");
            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            if (this.ItemGrpImgCode != target.ItemGrpImgCode) resList.Add("ItemGrpImgCode");
            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            return resList;
        }

        /// <summary>
        /// PCC品目グループマスタ比較処理
        /// </summary>
        /// <param name="pccItemGrp1">比較するPccItemGrpクラスのインスタンス</param>
        /// <param name="pccItemGrp2">比較するPccItemGrpクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccItemGrpクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(PccItemGrp pccItemGrp1, PccItemGrp pccItemGrp2)
        {
            ArrayList resList = new ArrayList();
            if (pccItemGrp1.CreateDateTime != pccItemGrp2.CreateDateTime) resList.Add("CreateDateTime");
            if (pccItemGrp1.UpdateDateTime != pccItemGrp2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (pccItemGrp1.LogicalDeleteCode != pccItemGrp2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (pccItemGrp1.InqOriginalEpCd.Trim() != pccItemGrp2.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (pccItemGrp1.InqOriginalSecCd != pccItemGrp2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (pccItemGrp1.InqOtherEpCd != pccItemGrp2.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (pccItemGrp1.InqOtherSecCd != pccItemGrp2.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (pccItemGrp1.InqCondition != pccItemGrp2.InqCondition) resList.Add("InqCondition");
            if (pccItemGrp1.PccCompanyCode != pccItemGrp2.PccCompanyCode) resList.Add("PccCompanyCode");
            if (pccItemGrp1.ItemGroupCode != pccItemGrp2.ItemGroupCode) resList.Add("ItemGroupCode");
            if (pccItemGrp1.ItemGroupName != pccItemGrp2.ItemGroupName) resList.Add("ItemGroupName");
            if (pccItemGrp1.ItemGrpDspOdr != pccItemGrp2.ItemGrpDspOdr) resList.Add("ItemGrpDspOdr");
            if (pccItemGrp1.UpdateFlag != pccItemGrp2.UpdateFlag) resList.Add("UpdateFlag");
            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            if (pccItemGrp1.ItemGrpImgCode != pccItemGrp2.ItemGrpImgCode) resList.Add("ItemGrpImgCode");
            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            return resList;
        }
    }
}
