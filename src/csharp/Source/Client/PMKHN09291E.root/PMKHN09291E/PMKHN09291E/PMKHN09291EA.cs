using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   BackUpExecutionCndtn
    /// <summary>
    ///                      バックアップ履歴取得結果
    /// </summary>
    /// <remarks>
    /// <br>note             :   バックアップ履歴取得結果ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/9/29</br>
    /// <br>Genarated Date   :   2011/06/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class BackUpExecutionCndtn
    {
        /// <summary>処理開始時間</summary>
        /// <remarks>処理開始時間（string:精度は100ナノ秒）</remarks>
        private string _startDateTime;

        /// <summary>処理終了時間</summary>
        /// <remarks>処理終了時間（string:精度は100ナノ秒）</remarks>
        private string _endDateTime;

        /// <summary>バックアップファイル名</summary>
        private string _fileName = "";

        /// <summary>DBVersion</summary>
        private string _dBVersion = "";

        /// <summary>処理結果</summary>
        private string _resultContent = "";

        /// <summary>ステータス</summary>
        private Int32 _status;


        /// public propaty name  :  StartDateTime
        /// <summary>処理開始時間プロパティ</summary>
        /// <value>処理開始時間（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理開始時間プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StartDateTime
        {
            get { return _startDateTime; }
            set { _startDateTime = value; }
        }

        /// public propaty name  :  EndDateTime
        /// <summary>処理終了時間プロパティ</summary>
        /// <value>処理終了時間（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理終了時間プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EndDateTime
        {
            get { return _endDateTime; }
            set { _endDateTime = value; }
        }

        /// public propaty name  :  FileName
        /// <summary>バックアップファイル名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   バックアップファイル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// public propaty name  :  DBVersion
        /// <summary>DBVersionプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   DBVersionプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DBVersion
        {
            get { return _dBVersion; }
            set { _dBVersion = value; }
        }

        /// public propaty name  :  ResultContent
        /// <summary>処理結果プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理結果プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ResultContent
        {
            get { return _resultContent; }
            set { _resultContent = value; }
        }

        /// public propaty name  :  Status
        /// <summary>ステータスプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Status
        {
            get { return _status; }
            set { _status = value; }
        }


        /// <summary>
        /// バックアップ履歴取得結果コンストラクタ
        /// </summary>
        /// <returns>BackUpExecutionCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BackUpExecutionCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public BackUpExecutionCndtn()
        {
        }

        /// <summary>
        /// バックアップ履歴取得結果コンストラクタ
        /// </summary>
        /// <param name="startDateTime">処理開始時間(処理開始時間（DateTime:精度は100ナノ秒）)</param>
        /// <param name="endDateTime">処理終了時間(処理終了時間（DateTime:精度は100ナノ秒）)</param>
        /// <param name="fileName">バックアップファイル名</param>
        /// <param name="dBVersion">DBVersion</param>
        /// <param name="resultContent">処理結果</param>
        /// <param name="status">ステータス</param>
        /// <returns>BackUpExecutionCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BackUpExecutionCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public BackUpExecutionCndtn(string startDateTime, string endDateTime, string fileName, string dBVersion, string resultContent, Int32 status)
        {
            this._startDateTime = startDateTime;
            this._endDateTime = endDateTime;
            this._fileName = fileName;
            this._dBVersion = dBVersion;
            this._resultContent = resultContent;
            this._status = status;

        }

        /// <summary>
        /// バックアップ履歴取得結果複製処理
        /// </summary>
        /// <returns>BackUpExecutionCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいBackUpExecutionCndtnクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public BackUpExecutionCndtn Clone()
        {
            return new BackUpExecutionCndtn(this._startDateTime, this._endDateTime, this._fileName, this._dBVersion, this._resultContent, this._status);
        }

        /// <summary>
        /// バックアップ履歴取得結果比較処理
        /// </summary>
        /// <param name="target">比較対象のBackUpExecutionCndtnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BackUpExecutionCndtnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(BackUpExecutionCndtn target)
        {
            return ((this.StartDateTime == target.StartDateTime)
                 && (this.EndDateTime == target.EndDateTime)
                 && (this.FileName == target.FileName)
                 && (this.DBVersion == target.DBVersion)
                 && (this.ResultContent == target.ResultContent)
                 && (this.Status == target.Status));
        }

        /// <summary>
        /// バックアップ履歴取得結果比較処理
        /// </summary>
        /// <param name="backUpExecutionCndtn1">
        ///                    比較するBackUpExecutionCndtnクラスのインスタンス
        /// </param>
        /// <param name="backUpExecutionCndtn2">比較するBackUpExecutionCndtnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BackUpExecutionCndtnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(BackUpExecutionCndtn backUpExecutionCndtn1, BackUpExecutionCndtn backUpExecutionCndtn2)
        {
            return ((backUpExecutionCndtn1.StartDateTime == backUpExecutionCndtn2.StartDateTime)
                 && (backUpExecutionCndtn1.EndDateTime == backUpExecutionCndtn2.EndDateTime)
                 && (backUpExecutionCndtn1.FileName == backUpExecutionCndtn2.FileName)
                 && (backUpExecutionCndtn1.DBVersion == backUpExecutionCndtn2.DBVersion)
                 && (backUpExecutionCndtn1.ResultContent == backUpExecutionCndtn2.ResultContent)
                 && (backUpExecutionCndtn1.Status == backUpExecutionCndtn2.Status));
        }
        /// <summary>
        /// バックアップ履歴取得結果比較処理
        /// </summary>
        /// <param name="target">比較対象のBackUpExecutionCndtnクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BackUpExecutionCndtnクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(BackUpExecutionCndtn target)
        {
            ArrayList resList = new ArrayList();
            if (this.StartDateTime != target.StartDateTime) resList.Add("StartDateTime");
            if (this.EndDateTime != target.EndDateTime) resList.Add("EndDateTime");
            if (this.FileName != target.FileName) resList.Add("FileName");
            if (this.DBVersion != target.DBVersion) resList.Add("DBVersion");
            if (this.ResultContent != target.ResultContent) resList.Add("ResultContent");
            if (this.Status != target.Status) resList.Add("Status");

            return resList;
        }

        /// <summary>
        /// バックアップ履歴取得結果比較処理
        /// </summary>
        /// <param name="backUpExecutionCndtn1">比較するBackUpExecutionCndtnクラスのインスタンス</param>
        /// <param name="backUpExecutionCndtn2">比較するBackUpExecutionCndtnクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BackUpExecutionCndtnクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(BackUpExecutionCndtn backUpExecutionCndtn1, BackUpExecutionCndtn backUpExecutionCndtn2)
        {
            ArrayList resList = new ArrayList();
            if (backUpExecutionCndtn1.StartDateTime != backUpExecutionCndtn2.StartDateTime) resList.Add("StartDateTime");
            if (backUpExecutionCndtn1.EndDateTime != backUpExecutionCndtn2.EndDateTime) resList.Add("EndDateTime");
            if (backUpExecutionCndtn1.FileName != backUpExecutionCndtn2.FileName) resList.Add("FileName");
            if (backUpExecutionCndtn1.DBVersion != backUpExecutionCndtn2.DBVersion) resList.Add("DBVersion");
            if (backUpExecutionCndtn1.ResultContent != backUpExecutionCndtn2.ResultContent) resList.Add("ResultContent");
            if (backUpExecutionCndtn1.Status != backUpExecutionCndtn2.Status) resList.Add("Status");

            return resList;
        }
    }
}
