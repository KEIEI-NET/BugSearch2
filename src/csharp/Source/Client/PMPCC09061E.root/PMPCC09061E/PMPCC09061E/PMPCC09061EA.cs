using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PccCpMsgSt
    /// <summary>
    ///                      PCCキャンペーンメッセージ設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   PCCキャンペーンメッセージ設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2011/7/21</br>
    /// <br>Genarated Date   :   2011/08/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PccCpMsgSt
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

        /// <summary>適用開始日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyStaDate;

        /// <summary>適用終了日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyEndDate;

        /// <summary>PCCメッセージ本文</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _pccMsgDocCnts = "";

        /// <summary>キャンペーン名称</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _campaignName = "";

        /// <summary>キャンペーン対象区分</summary>
        /// <remarks>0:全得意先 1:対象得意先</remarks>
        private Int32 _campaignObjDiv;

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

        /// public propaty name  :  PccMsgDocCnts
        /// <summary>PCCメッセージ本文プロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCCメッセージ本文プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PccMsgDocCnts
        {
            get { return _pccMsgDocCnts; }
            set { _pccMsgDocCnts = value; }
        }

        /// public propaty name  :  CampaignName
        /// <summary>キャンペーン名称プロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーン名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CampaignName
        {
            get { return _campaignName; }
            set { _campaignName = value; }
        }

        /// public propaty name  :  CampaignObjDiv
        /// <summary>キャンペーン対象区分プロパティ</summary>
        /// <value>0:全得意先 1:対象得意先</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーン対象区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CampaignObjDiv
        {
            get { return _campaignObjDiv; }
            set { _campaignObjDiv = value; }
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
        /// PCCキャンペーンメッセージ設定マスタコンストラクタ
        /// </summary>
        /// <returns>PccCpMsgStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCpMsgStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PccCpMsgSt()
        {
        }

        /// <summary>
        /// PCCキャンペーンメッセージ設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="inqOtherEpCd">問合せ先企業コード</param>
        /// <param name="inqOtherSecCd">問合せ先拠点コード</param>
        /// <param name="campaignCode">キャンペーンコード</param>
        /// <param name="applyStaDate">適用開始日(YYYYMMDD)</param>
        /// <param name="applyEndDate">適用終了日(YYYYMMDD)</param>
        /// <param name="pccMsgDocCnts">PCCメッセージ本文((半角全角混在))</param>
        /// <param name="campaignName">キャンペーン名称((半角全角混在))</param>
        /// <param name="campaignObjDiv">キャンペーン対象区分(0:全得意先 1:対象得意先)</param>
        /// <param name="updateFlag">更新区分(0:新規 1:更新 2:削除)</param>
        /// <returns>PccCpMsgStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCpMsgStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PccCpMsgSt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOtherEpCd, string inqOtherSecCd, Int32 campaignCode, Int32 applyStaDate, Int32 applyEndDate, string pccMsgDocCnts, string campaignName, Int32 campaignObjDiv, Int32 updateFlag)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._inqOtherEpCd = inqOtherEpCd;
            this._inqOtherSecCd = inqOtherSecCd;
            this._campaignCode = campaignCode;
            this._applyStaDate = applyStaDate;
            this._applyEndDate = applyEndDate;
            this._pccMsgDocCnts = pccMsgDocCnts;
            this._campaignName = campaignName;
            this._campaignObjDiv = campaignObjDiv;
            this._updateFlag = updateFlag;

        }

        /// <summary>
        /// PCCキャンペーンメッセージ設定マスタ複製処理
        /// </summary>
        /// <returns>PccCpMsgStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいPccCpMsgStクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PccCpMsgSt Clone()
        {
            return new PccCpMsgSt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOtherEpCd, this._inqOtherSecCd, this._campaignCode, this._applyStaDate, this._applyEndDate, this._pccMsgDocCnts, this._campaignName, this._campaignObjDiv, this._updateFlag);
        }

        /// <summary>
        /// PCCキャンペーンメッセージ設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のPccCpMsgStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCpMsgStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(PccCpMsgSt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOtherEpCd == target.InqOtherEpCd)
                 && (this.InqOtherSecCd == target.InqOtherSecCd)
                 && (this.CampaignCode == target.CampaignCode)
                 && (this.ApplyStaDate == target.ApplyStaDate)
                 && (this.ApplyEndDate == target.ApplyEndDate)
                 && (this.PccMsgDocCnts == target.PccMsgDocCnts)
                 && (this.CampaignName == target.CampaignName)
                 && (this.CampaignObjDiv == target.CampaignObjDiv)
                 && (this.UpdateFlag == target.UpdateFlag));
        }

        /// <summary>
        /// PCCキャンペーンメッセージ設定マスタ比較処理
        /// </summary>
        /// <param name="pccCpMsgSt1">
        ///                    比較するPccCpMsgStクラスのインスタンス
        /// </param>
        /// <param name="pccCpMsgSt2">比較するPccCpMsgStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCpMsgStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(PccCpMsgSt pccCpMsgSt1, PccCpMsgSt pccCpMsgSt2)
        {
            return ((pccCpMsgSt1.CreateDateTime == pccCpMsgSt2.CreateDateTime)
                 && (pccCpMsgSt1.UpdateDateTime == pccCpMsgSt2.UpdateDateTime)
                 && (pccCpMsgSt1.LogicalDeleteCode == pccCpMsgSt2.LogicalDeleteCode)
                 && (pccCpMsgSt1.InqOtherEpCd == pccCpMsgSt2.InqOtherEpCd)
                 && (pccCpMsgSt1.InqOtherSecCd == pccCpMsgSt2.InqOtherSecCd)
                 && (pccCpMsgSt1.CampaignCode == pccCpMsgSt2.CampaignCode)
                 && (pccCpMsgSt1.ApplyStaDate == pccCpMsgSt2.ApplyStaDate)
                 && (pccCpMsgSt1.ApplyEndDate == pccCpMsgSt2.ApplyEndDate)
                 && (pccCpMsgSt1.PccMsgDocCnts == pccCpMsgSt2.PccMsgDocCnts)
                 && (pccCpMsgSt1.CampaignName == pccCpMsgSt2.CampaignName)
                 && (pccCpMsgSt1.CampaignObjDiv == pccCpMsgSt2.CampaignObjDiv)
                 && (pccCpMsgSt1.UpdateFlag == pccCpMsgSt2.UpdateFlag));
        }
        /// <summary>
        /// PCCキャンペーンメッセージ設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のPccCpMsgStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCpMsgStクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(PccCpMsgSt target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (this.CampaignCode != target.CampaignCode) resList.Add("CampaignCode");
            if (this.ApplyStaDate != target.ApplyStaDate) resList.Add("ApplyStaDate");
            if (this.ApplyEndDate != target.ApplyEndDate) resList.Add("ApplyEndDate");
            if (this.PccMsgDocCnts != target.PccMsgDocCnts) resList.Add("PccMsgDocCnts");
            if (this.CampaignName != target.CampaignName) resList.Add("CampaignName");
            if (this.CampaignObjDiv != target.CampaignObjDiv) resList.Add("CampaignObjDiv");
            if (this.UpdateFlag != target.UpdateFlag) resList.Add("UpdateFlag");

            return resList;
        }

        /// <summary>
        /// PCCキャンペーンメッセージ設定マスタ比較処理
        /// </summary>
        /// <param name="pccCpMsgSt1">比較するPccCpMsgStクラスのインスタンス</param>
        /// <param name="pccCpMsgSt2">比較するPccCpMsgStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCpMsgStクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(PccCpMsgSt pccCpMsgSt1, PccCpMsgSt pccCpMsgSt2)
        {
            ArrayList resList = new ArrayList();
            if (pccCpMsgSt1.CreateDateTime != pccCpMsgSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (pccCpMsgSt1.UpdateDateTime != pccCpMsgSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (pccCpMsgSt1.LogicalDeleteCode != pccCpMsgSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (pccCpMsgSt1.InqOtherEpCd != pccCpMsgSt2.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (pccCpMsgSt1.InqOtherSecCd != pccCpMsgSt2.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (pccCpMsgSt1.CampaignCode != pccCpMsgSt2.CampaignCode) resList.Add("CampaignCode");
            if (pccCpMsgSt1.ApplyStaDate != pccCpMsgSt2.ApplyStaDate) resList.Add("ApplyStaDate");
            if (pccCpMsgSt1.ApplyEndDate != pccCpMsgSt2.ApplyEndDate) resList.Add("ApplyEndDate");
            if (pccCpMsgSt1.PccMsgDocCnts != pccCpMsgSt2.PccMsgDocCnts) resList.Add("PccMsgDocCnts");
            if (pccCpMsgSt1.CampaignName != pccCpMsgSt2.CampaignName) resList.Add("CampaignName");
            if (pccCpMsgSt1.CampaignObjDiv != pccCpMsgSt2.CampaignObjDiv) resList.Add("CampaignObjDiv");
            if (pccCpMsgSt1.UpdateFlag != pccCpMsgSt2.UpdateFlag) resList.Add("UpdateFlag");

            return resList;
        }
    }
}
