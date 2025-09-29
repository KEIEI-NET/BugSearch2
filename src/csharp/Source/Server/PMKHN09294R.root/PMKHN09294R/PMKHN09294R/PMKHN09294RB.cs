using System;
using System.Collections.Generic;
using Broadleaf.Application.Remoting.ParamData;
using System.Xml.Serialization;
using System.IO;
using Broadleaf.Library.Resources;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// public class name:   UiSetByAssembly
    /// <summary>
    ///                      XMLシリアライズクラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   XMLシリアライズクラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011.06.22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [XmlRoot("UiSetByAssembly")]
    public class UiSetByAssembly
    {
        /// <summary>
        /// バックアップ処理履歴取得結果リスト
        /// </summary>
        public List<BackUpExecution> BackUpExecutions = new List<BackUpExecution>();

        /// <summary>
        /// XMLシリアライズコンストラクタ
        /// </summary>
        public UiSetByAssembly()
        { 
        }

        /// <summary>
        /// XMLシリア読み
        /// </summary>
        /// <param name="wklist"> XML記録のリスト</param>
        /// <summary>処理終了時間</summary>
        /// <remarks>
        /// <br>note             :   XMLシリアを読む</br>
        /// <br>Programer        :   黄海霞</br>
        /// </remarks>
        public UiSetByAssembly(ArrayList wklist)
        {
            for (int i = 0; i < wklist.Count; i++)
            {
                BackUpExecutionWork wk = wklist[i] as BackUpExecutionWork;
                BackUpExecution bk = new BackUpExecution();
                bk.StartDateTime = wk.StartDateTime;
                bk.EndDateTime = wk.EndDateTime;
                bk.FileName = wk.FileName;
                bk.DBVersion = wk.DBVersion;
                bk.ResultContent = wk.ResultContent;
                bk.Status = wk.Status;
                BackUpExecutions.Add(bk);
            }
        }
   
    }


    /// public class name:   BackUpExecution
    /// <summary>
    ///                      バックアップ処理履歴ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   バックアップ処理履歴ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011.06.22  (CSharp File Generated Date)</br>
    /// </remarks>
    [XmlType("BackUpExecution")]
    public class BackUpExecution
    {
        /// <summary>処理開始時間</summary>
        /// <remarks>処理開始時間（DateTime:精度は100ナノ秒）</remarks>
        private string _startDateTime;

        /// <summary>処理終了時間</summary>
        /// <remarks>処理終了時間（DateTime:精度は100ナノ秒）</remarks>
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
        /// <summary>処理開始時間</summary>
        /// <value>処理開始時間（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理開始時間</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StartDateTime
        {
            get { return _startDateTime; }
            set { _startDateTime = value; }
        }

        /// public propaty name  :  EndDateTime
        /// <summary>処理終了時間</summary>
        /// <value>処理終了時間（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理終了時間</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EndDateTime
        {
            get { return _endDateTime; }
            set { _endDateTime = value; }
        }

        /// public propaty name  :  FileName
        /// <summary>バックアップファイル名</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   バックアップファイル名</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// public propaty name  :  DBVersion
        /// <summary>DBVersion</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   DBVersion</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DBVersion
        {
            get { return _dBVersion; }
            set { _dBVersion = value; }
        }

        /// public propaty name  :  ResultContent
        /// <summary>処理結果</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理結果</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ResultContent
        {
            get { return _resultContent; }
            set { _resultContent = value; }
        }

        /// public propaty name  :  Status
        /// <summary>ステータス</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ステータス</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Status
        {
            get { return _status; }
            set { _status = value; }
        }

    }

    /// public class name:   myReverserClass
    /// <summary>
    ///                      リストの比較クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   リストの比較クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011.06.22  (CSharp File Generated Date)</br>
    /// </remarks>
    public class myReverserClass : IComparer
    {

        // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
        int IComparer.Compare(Object x, Object y)
        {
            return ((new CaseInsensitiveComparer()).Compare(((BackUpExecutionWork)y).StartDateTime, ((BackUpExecutionWork)x).StartDateTime));
        }

    }

    /// public class name:   myReverserClass
    /// <summary>
    ///                      XML書きクラス 
    /// </summary>
    /// <remarks>
    /// <br>note             :   XML書きクラス ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011.06.22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class XmlSerial
    {
        /// <summary>
        ///XML書き
        /// </summary>
        /// <param name="filePath">ファイルパース</param>
        /// <param name="work">バックアップ処理履歴ワーク</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 自動生成</br>
        /// <br>Date       : 2011.06.22</br>
        /// </remarks>
        public int Serialiaze(String filePath,BackUpExecutionWork work)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                IComparer myComparer = new myReverserClass();
                ArrayList wklist = Deserialize(filePath);
                wklist.Add(work);
                if (wklist.Count > 1)
                {
                    wklist.Sort(myComparer);
                }
                int count = wklist.Count - 10;
                if (wklist.Count > 10)
                {
                    for (int i = 0; i < count; i++)
                    {
                        wklist.RemoveAt(10 + i);
                    }
                }
                UiSetByAssembly u = new UiSetByAssembly(wklist);
                XmlSerializer xs = new XmlSerializer(typeof(UiSetByAssembly));

                Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                xs.Serialize(stream, u);
                stream.Close();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch(Exception ex)
            {
                work.ResultContent = ex.Message;
            }
            
            return status;

        }

        /// <summary>
        ///XML読む
        /// </summary>
        /// <param name="filePath">ファイルパース</param>
        /// <returns>ックアップ処理履歴ワークリスト</returns>
        /// <remarks>
        /// <br>Programmer : 自動生成</br>
        /// <br>Date       : 2011.06.22</br>
        /// </remarks>
        public ArrayList Deserialize(String filePath)
        {
            ArrayList list = new ArrayList();
            Stream stream = null;
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(UiSetByAssembly));
                stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
                UiSetByAssembly p = (UiSetByAssembly)xs.Deserialize(stream);
                stream.Close();

                foreach (BackUpExecution back in p.BackUpExecutions)
                {
                    BackUpExecutionWork wk = new BackUpExecutionWork();
                    wk.Status = back.Status;
                    wk.StartDateTime = back.StartDateTime;
                    wk.EndDateTime = back.EndDateTime;
                    wk.DBVersion = back.DBVersion;
                    wk.FileName = back.FileName;
                    wk.ResultContent = back.ResultContent;
                    list.Add(wk);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                stream.Close();
            }
            
            return list;

        }

    }
}
