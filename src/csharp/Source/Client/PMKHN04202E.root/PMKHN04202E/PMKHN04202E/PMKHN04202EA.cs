using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ScmInqLogInquiry
    /// <summary>
    ///                      SCM問合せログテーブル
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM問合せログテーブルヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2010/10/14</br>
    /// <br>Genarated Date   :   2010/11/11  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class ScmInqLogInquiry
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

        /// <summary>連結元企業コード</summary>
        private string _cnectOriginalEpCd = "";

        /// <summary>連結元企業名称</summary>
        private string _cnectOriginalEpNm = "";

        /// <summary>連結先企業コード</summary>
        private string _cnectOtherEpCd = "";

        /// <summary>連結先企業名称</summary>
        private string _cnectOtherEpNm = "";

        /// <summary>問合せ元データ入力システム</summary>
        /// <remarks>1:SF.NS 2:BK/BF.NS 3:RC.NS 4:SF7 5:BK-P 6:RC7</remarks>
        private Int32 _inqDataInputSystem;

        /// <summary>ログデータGUID</summary>
        private Guid _logDataGuid;

        /// <summary>SCM問合せ内容</summary>
        /// <remarks>nvarchar(max)</remarks>
        private string _scmInqContents = "";

        /// <summary>回答部品件数</summary>
        /// <remarks>回答した部品件数</remarks>
        private Int32 _answerPartsCnt;


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

        /// public propaty name  :  CnectOriginalEpCd
        /// <summary>連結元企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連結元企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CnectOriginalEpCd
        {
            get { return _cnectOriginalEpCd; }
            set { _cnectOriginalEpCd = value; }
        }

        /// public propaty name  :  CnectOriginalEpNm
        /// <summary>連結元企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連結元企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CnectOriginalEpNm
        {
            get { return _cnectOriginalEpNm; }
            set { _cnectOriginalEpNm = value; }
        }

        /// public propaty name  :  CnectOtherEpCd
        /// <summary>連結先企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連結先企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CnectOtherEpCd
        {
            get { return _cnectOtherEpCd; }
            set { _cnectOtherEpCd = value; }
        }

        /// public propaty name  :  CnectOtherEpNm
        /// <summary>連結先企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連結先企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CnectOtherEpNm
        {
            get { return _cnectOtherEpNm; }
            set { _cnectOtherEpNm = value; }
        }

        /// public propaty name  :  InqDataInputSystem
        /// <summary>問合せ元データ入力システムプロパティ</summary>
        /// <value>1:SF.NS 2:BK/BF.NS 3:RC.NS 4:SF7 5:BK-P 6:RC7</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元データ入力システムプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InqDataInputSystem
        {
            get { return _inqDataInputSystem; }
            set { _inqDataInputSystem = value; }
        }

        /// public propaty name  :  LogDataGuid
        /// <summary>ログデータGUIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログデータGUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid LogDataGuid
        {
            get { return _logDataGuid; }
            set { _logDataGuid = value; }
        }

        /// public propaty name  :  ScmInqContents
        /// <summary>SCM問合せ内容プロパティ</summary>
        /// <value>nvarchar(max)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SCM問合せ内容プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ScmInqContents
        {
            get { return _scmInqContents; }
            set { _scmInqContents = value; }
        }

        /// public propaty name  :  AnswerPartsCnt
        /// <summary>回答部品件数プロパティ</summary>
        /// <value>回答した部品件数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答部品件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AnswerPartsCnt
        {
            get { return _answerPartsCnt; }
            set { _answerPartsCnt = value; }
        }


        /// <summary>
        /// SCM問合せログテーブルコンストラクタ
        /// </summary>
        /// <returns>ScmInqLogクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmInqLogクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ScmInqLogInquiry()
        {
        }

        /// <summary>
        /// SCM問合せログテーブルコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="cnectOriginalEpCd">連結元企業コード</param>
        /// <param name="cnectOriginalEpNm">連結元企業名称</param>
        /// <param name="cnectOtherEpCd">連結先企業コード</param>
        /// <param name="cnectOtherEpNm">連結先企業名称</param>
        /// <param name="inqDataInputSystem">問合せ元データ入力システム(1:SF.NS 2:BK/BF.NS 3:RC.NS 4:SF7 5:BK-P 6:RC7)</param>
        /// <param name="logDataGuid">ログデータGUID</param>
        /// <param name="scmInqContents">SCM問合せ内容(nvarchar(max))</param>
        /// <param name="answerPartsCnt">回答部品件数(回答した部品件数)</param>
        /// <returns>ScmInqLogクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmInqLogクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ScmInqLogInquiry(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string cnectOriginalEpCd, string cnectOriginalEpNm, string cnectOtherEpCd, string cnectOtherEpNm, Int32 inqDataInputSystem, Guid logDataGuid, string scmInqContents, Int32 answerPartsCnt)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._cnectOriginalEpCd = cnectOriginalEpCd;
            this._cnectOriginalEpNm = cnectOriginalEpNm;
            this._cnectOtherEpCd = cnectOtherEpCd;
            this._cnectOtherEpNm = cnectOtherEpNm;
            this._inqDataInputSystem = inqDataInputSystem;
            this._logDataGuid = logDataGuid;
            this._scmInqContents = scmInqContents;
            this._answerPartsCnt = answerPartsCnt;

        }

        /// <summary>
        /// SCM問合せログテーブル複製処理
        /// </summary>
        /// <returns>ScmInqLogクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいScmInqLogクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ScmInqLogInquiry Clone()
        {
            return new ScmInqLogInquiry(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._cnectOriginalEpCd, this._cnectOriginalEpNm, this._cnectOtherEpCd, this._cnectOtherEpNm, this._inqDataInputSystem, this._logDataGuid, this._scmInqContents, this._answerPartsCnt);
        }

        /// <summary>
        /// SCM問合せログテーブル比較処理
        /// </summary>
        /// <param name="target">比較対象のScmInqLogクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmInqLogクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(ScmInqLogInquiry target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.CnectOriginalEpCd == target.CnectOriginalEpCd)
                 && (this.CnectOriginalEpNm == target.CnectOriginalEpNm)
                 && (this.CnectOtherEpCd == target.CnectOtherEpCd)
                 && (this.CnectOtherEpNm == target.CnectOtherEpNm)
                 && (this.InqDataInputSystem == target.InqDataInputSystem)
                 && (this.LogDataGuid == target.LogDataGuid)
                 && (this.ScmInqContents == target.ScmInqContents)
                 && (this.AnswerPartsCnt == target.AnswerPartsCnt));
        }

        /// <summary>
        /// SCM問合せログテーブル比較処理
        /// </summary>
        /// <param name="scmInqLog1">
        ///                    比較するScmInqLogクラスのインスタンス
        /// </param>
        /// <param name="scmInqLog2">比較するScmInqLogクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmInqLogクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(ScmInqLogInquiry scmInqLog1, ScmInqLogInquiry scmInqLog2)
        {
            return ((scmInqLog1.CreateDateTime == scmInqLog2.CreateDateTime)
                 && (scmInqLog1.UpdateDateTime == scmInqLog2.UpdateDateTime)
                 && (scmInqLog1.LogicalDeleteCode == scmInqLog2.LogicalDeleteCode)
                 && (scmInqLog1.CnectOriginalEpCd == scmInqLog2.CnectOriginalEpCd)
                 && (scmInqLog1.CnectOriginalEpNm == scmInqLog2.CnectOriginalEpNm)
                 && (scmInqLog1.CnectOtherEpCd == scmInqLog2.CnectOtherEpCd)
                 && (scmInqLog1.CnectOtherEpNm == scmInqLog2.CnectOtherEpNm)
                 && (scmInqLog1.InqDataInputSystem == scmInqLog2.InqDataInputSystem)
                 && (scmInqLog1.LogDataGuid == scmInqLog2.LogDataGuid)
                 && (scmInqLog1.ScmInqContents == scmInqLog2.ScmInqContents)
                 && (scmInqLog1.AnswerPartsCnt == scmInqLog2.AnswerPartsCnt));
        }
        /// <summary>
        /// SCM問合せログテーブル比較処理
        /// </summary>
        /// <param name="target">比較対象のScmInqLogクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmInqLogクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(ScmInqLogInquiry target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.CnectOriginalEpCd != target.CnectOriginalEpCd) resList.Add("CnectOriginalEpCd");
            if (this.CnectOriginalEpNm != target.CnectOriginalEpNm) resList.Add("CnectOriginalEpNm");
            if (this.CnectOtherEpCd != target.CnectOtherEpCd) resList.Add("CnectOtherEpCd");
            if (this.CnectOtherEpNm != target.CnectOtherEpNm) resList.Add("CnectOtherEpNm");
            if (this.InqDataInputSystem != target.InqDataInputSystem) resList.Add("InqDataInputSystem");
            if (this.LogDataGuid != target.LogDataGuid) resList.Add("LogDataGuid");
            if (this.ScmInqContents != target.ScmInqContents) resList.Add("ScmInqContents");
            if (this.AnswerPartsCnt != target.AnswerPartsCnt) resList.Add("AnswerPartsCnt");

            return resList;
        }

        /// <summary>
        /// SCM問合せログテーブル比較処理
        /// </summary>
        /// <param name="scmInqLog1">比較するScmInqLogクラスのインスタンス</param>
        /// <param name="scmInqLog2">比較するScmInqLogクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmInqLogクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(ScmInqLogInquiry scmInqLog1, ScmInqLogInquiry scmInqLog2)
        {
            ArrayList resList = new ArrayList();
            if (scmInqLog1.CreateDateTime != scmInqLog2.CreateDateTime) resList.Add("CreateDateTime");
            if (scmInqLog1.UpdateDateTime != scmInqLog2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (scmInqLog1.LogicalDeleteCode != scmInqLog2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (scmInqLog1.CnectOriginalEpCd != scmInqLog2.CnectOriginalEpCd) resList.Add("CnectOriginalEpCd");
            if (scmInqLog1.CnectOriginalEpNm != scmInqLog2.CnectOriginalEpNm) resList.Add("CnectOriginalEpNm");
            if (scmInqLog1.CnectOtherEpCd != scmInqLog2.CnectOtherEpCd) resList.Add("CnectOtherEpCd");
            if (scmInqLog1.CnectOtherEpNm != scmInqLog2.CnectOtherEpNm) resList.Add("CnectOtherEpNm");
            if (scmInqLog1.InqDataInputSystem != scmInqLog2.InqDataInputSystem) resList.Add("InqDataInputSystem");
            if (scmInqLog1.LogDataGuid != scmInqLog2.LogDataGuid) resList.Add("LogDataGuid");
            if (scmInqLog1.ScmInqContents != scmInqLog2.ScmInqContents) resList.Add("ScmInqContents");
            if (scmInqLog1.AnswerPartsCnt != scmInqLog2.AnswerPartsCnt) resList.Add("AnswerPartsCnt");

            return resList;
        }
    }
}
