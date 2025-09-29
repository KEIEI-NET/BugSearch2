using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PccMailDt
    /// <summary>
    ///                      PCCメールデータ
    /// </summary>
    /// <remarks>
    /// <br>note             :   PCCメールデータヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2011/7/21</br>
    /// <br>Genarated Date   :   2011/08/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PccMailDt
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

        /// <summary>更新年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _updateDate;

        /// <summary>更新時分秒ミリ秒</summary>
        /// <remarks>HHMMSSXXX</remarks>
        private Int32 _updateTime;

        /// <summary>PCCメール件名</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _pccMailTitle = "";

        /// <summary>PCCメール本文</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _pccMailDocCnts = "";

        /// <summary>対象日開始</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _updateDateSt;

        /// <summary>対象日終了</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _updateDateEd;


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

        /// public propaty name  :  UpdateDate
        /// <summary>更新年月日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

        /// public propaty name  :  UpdateTime
        /// <summary>更新時分秒ミリ秒プロパティ</summary>
        /// <value>HHMMSSXXX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新時分秒ミリ秒プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateTime
        {
            get { return _updateTime; }
            set { _updateTime = value; }
        }

        /// public propaty name  :  PccMailTitle
        /// <summary>PCCメール件名プロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCCメール件名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PccMailTitle
        {
            get { return _pccMailTitle; }
            set { _pccMailTitle = value; }
        }

        /// public propaty name  :  PccMailDocCnts
        /// <summary>PCCメール本文プロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCCメール本文プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PccMailDocCnts
        {
            get { return _pccMailDocCnts; }
            set { _pccMailDocCnts = value; }
        }

        /// public propaty name  :  UpdateDateSt
        /// <summary>対象日開始プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   対象日開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateDateSt
        {
            get { return _updateDateSt; }
            set { _updateDateSt = value; }
        }

        /// public propaty name  :  UpdateDateEd
        /// <summary>対象日終了プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   対象日終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateDateEd
        {
            get { return _updateDateEd; }
            set { _updateDateEd = value; }
        }


        /// <summary>
        /// PCCメールデータコンストラクタ
        /// </summary>
        /// <returns>PccMailDtクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccMailDtクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PccMailDt()
        {
        }

        /// <summary>
        /// PCCメールデータコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="inqOriginalEpCd">問合せ元企業コード</param>
        /// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
        /// <param name="inqOtherEpCd">問合せ先企業コード</param>
        /// <param name="inqOtherSecCd">問合せ先拠点コード</param>
        /// <param name="updateDate">更新年月日(YYYYMMDD)</param>
        /// <param name="updateTime">更新時分秒ミリ秒(HHMMSSXXX)</param>
        /// <param name="pccMailTitle">PCCメール件名((半角全角混在))</param>
        /// <param name="pccMailDocCnts">PCCメール本文((半角全角混在))</param>
        /// <param name="updateDateSt">対象日開始(YYYYMMDD)</param>
        /// <param name="updateDateEd">対象日終了(YYYYMMDD)</param>
        /// <returns>PccMailDtクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccMailDtクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PccMailDt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 updateDate, Int32 updateTime, string pccMailTitle, string pccMailDocCnts, Int32 updateDateSt, Int32 updateDateEd)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._inqOtherEpCd = inqOtherEpCd;
            this._inqOtherSecCd = inqOtherSecCd;
            this._updateDate = updateDate;
            this._updateTime = updateTime;
            this._pccMailTitle = pccMailTitle;
            this._pccMailDocCnts = pccMailDocCnts;
            this._updateDateSt = updateDateSt;
            this._updateDateEd = updateDateEd;

        }

        /// <summary>
        /// PCCメールデータ複製処理
        /// </summary>
        /// <returns>PccMailDtクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいPccMailDtクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PccMailDt Clone()
        {
            return new PccMailDt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd.Trim(), this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._updateDate, this._updateTime, this._pccMailTitle, this._pccMailDocCnts, this._updateDateSt, this._updateDateEd);//@@@@20230303
        }

        /// <summary>
        /// PCCメールデータ比較処理
        /// </summary>
        /// <param name="target">比較対象のPccMailDtクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccMailDtクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(PccMailDt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim())//@@@@20230303
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.InqOtherEpCd == target.InqOtherEpCd)
                 && (this.InqOtherSecCd == target.InqOtherSecCd)
                 && (this.UpdateDate == target.UpdateDate)
                 && (this.UpdateTime == target.UpdateTime)
                 && (this.PccMailTitle == target.PccMailTitle)
                 && (this.PccMailDocCnts == target.PccMailDocCnts)
                 && (this.UpdateDateSt == target.UpdateDateSt)
                 && (this.UpdateDateEd == target.UpdateDateEd));
        }

        /// <summary>
        /// PCCメールデータ比較処理
        /// </summary>
        /// <param name="pccMailDt1">
        ///                    比較するPccMailDtクラスのインスタンス
        /// </param>
        /// <param name="pccMailDt2">比較するPccMailDtクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccMailDtクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(PccMailDt pccMailDt1, PccMailDt pccMailDt2)
        {
            return ((pccMailDt1.CreateDateTime == pccMailDt2.CreateDateTime)
                 && (pccMailDt1.UpdateDateTime == pccMailDt2.UpdateDateTime)
                 && (pccMailDt1.LogicalDeleteCode == pccMailDt2.LogicalDeleteCode)
                 && (pccMailDt1.InqOriginalEpCd.Trim() == pccMailDt2.InqOriginalEpCd.Trim())//@@@@20230303
                 && (pccMailDt1.InqOriginalSecCd == pccMailDt2.InqOriginalSecCd)
                 && (pccMailDt1.InqOtherEpCd == pccMailDt2.InqOtherEpCd)
                 && (pccMailDt1.InqOtherSecCd == pccMailDt2.InqOtherSecCd)
                 && (pccMailDt1.UpdateDate == pccMailDt2.UpdateDate)
                 && (pccMailDt1.UpdateTime == pccMailDt2.UpdateTime)
                 && (pccMailDt1.PccMailTitle == pccMailDt2.PccMailTitle)
                 && (pccMailDt1.PccMailDocCnts == pccMailDt2.PccMailDocCnts)
                 && (pccMailDt1.UpdateDateSt == pccMailDt2.UpdateDateSt)
                 && (pccMailDt1.UpdateDateEd == pccMailDt2.UpdateDateEd));
        }
        /// <summary>
        /// PCCメールデータ比較処理
        /// </summary>
        /// <param name="target">比較対象のPccMailDtクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccMailDtクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(PccMailDt target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (this.UpdateDate != target.UpdateDate) resList.Add("UpdateDate");
            if (this.UpdateTime != target.UpdateTime) resList.Add("UpdateTime");
            if (this.PccMailTitle != target.PccMailTitle) resList.Add("PccMailTitle");
            if (this.PccMailDocCnts != target.PccMailDocCnts) resList.Add("PccMailDocCnts");
            if (this.UpdateDateSt != target.UpdateDateSt) resList.Add("UpdateDateSt");
            if (this.UpdateDateEd != target.UpdateDateEd) resList.Add("UpdateDateEd");

            return resList;
        }

        /// <summary>
        /// PCCメールデータ比較処理
        /// </summary>
        /// <param name="pccMailDt1">比較するPccMailDtクラスのインスタンス</param>
        /// <param name="pccMailDt2">比較するPccMailDtクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccMailDtクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(PccMailDt pccMailDt1, PccMailDt pccMailDt2)
        {
            ArrayList resList = new ArrayList();
            if (pccMailDt1.CreateDateTime != pccMailDt2.CreateDateTime) resList.Add("CreateDateTime");
            if (pccMailDt1.UpdateDateTime != pccMailDt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (pccMailDt1.LogicalDeleteCode != pccMailDt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (pccMailDt1.InqOriginalEpCd.Trim() != pccMailDt2.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (pccMailDt1.InqOriginalSecCd != pccMailDt2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (pccMailDt1.InqOtherEpCd != pccMailDt2.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (pccMailDt1.InqOtherSecCd != pccMailDt2.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (pccMailDt1.UpdateDate != pccMailDt2.UpdateDate) resList.Add("UpdateDate");
            if (pccMailDt1.UpdateTime != pccMailDt2.UpdateTime) resList.Add("UpdateTime");
            if (pccMailDt1.PccMailTitle != pccMailDt2.PccMailTitle) resList.Add("PccMailTitle");
            if (pccMailDt1.PccMailDocCnts != pccMailDt2.PccMailDocCnts) resList.Add("PccMailDocCnts");
            if (pccMailDt1.UpdateDateSt != pccMailDt2.UpdateDateSt) resList.Add("UpdateDateSt");
            if (pccMailDt1.UpdateDateEd != pccMailDt2.UpdateDateEd) resList.Add("UpdateDateEd");

            return resList;
        }
    }
}
