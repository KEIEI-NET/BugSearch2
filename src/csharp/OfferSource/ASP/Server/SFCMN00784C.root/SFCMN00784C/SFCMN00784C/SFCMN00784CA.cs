using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

using System.Runtime.Serialization.Formatters.Soap;


namespace Broadleaf.Application.Common
{
    /// <summary>
    /// 変更PG案内用ログ出力部品
    /// </summary>
    /// <remarks>
    /// <br>Note       : ログを出力します。</br>
    /// <br>Programmer : 23002 上野　耕平</br>
    /// <br>Date       : 2007.03.05</br>
    /// </remarks>
    public class ChangePgGuideLogOutPut
    {
        # region メッセージレベル型
        /// <summary>
        /// メッセージレベル
        /// </summary>
        public enum MessageLevel
        {
            Information,
            Warning,
            Error,
            Debug
        }
        #endregion

        #region プライベートメンバ
        /// <summary>ロックオブジェクト</summary>
        static private object _thisLock = new object();
        /// <summary>ログの出力先</summary>
        private string _logoutputPath = "";
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ChangePgGuideLogOutPut()
        {
            //_logoutputPath = "c:\\log";//= this.GetLogPath();
            _logoutputPath = this.GetLogPath();
        }
        #endregion

        #region パブリッククラス
        /// <summary>
        /// ログ書込み
        /// </summary>
        /// <param name="messageLevel"></param>
        /// <param name="message"></param>
        public void WriteLog(MessageLevel messageLevel, string message)
        {
            this.WriteLogProc(_logoutputPath, messageLevel, "", "", null, message);
        }

        /// <summary>
        /// ログ書込み
        /// </summary>
        /// <param name="messageLevel"></param>
        /// <param name="ex"></param>
        public void WriteLog(MessageLevel messageLevel, Exception ex)
        {
            this.WriteLogProc(_logoutputPath, messageLevel, "", "", ex, null);
        }

        /// <summary>
        /// ログ書込み
        /// </summary>
        /// <param name="messageLevel"></param>
        /// <param name="enterprisecode"></param>
        /// <param name="groupcode"></param>
        /// <param name="message"></param>
        public void WriteLog(MessageLevel messageLevel, string enterprisecode, string groupcode, string message)
        {
            this.WriteLogProc(_logoutputPath, messageLevel, enterprisecode, groupcode, null, message);
        }

        /// <summary>
        /// ログ書込み
        /// </summary>
        /// <param name="messageLevel"></param>
        /// <param name="enterprisecode"></param>
        /// <param name="groupcode"></param>
        /// <param name="ex"></param>
        public void WriteLog(MessageLevel messageLevel, string enterprisecode, string groupcode, Exception ex)
        {
            this.WriteLogProc(_logoutputPath, messageLevel, enterprisecode, groupcode, ex, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputFileName"></param>
        /// <returns></returns>
        public Exception ReadExceptionLog(string inputFileName)
        {
            return this.ReadExceptionLogProc(inputFileName);
        }
        #endregion

        #region プライベートメソッド
        /// <summary>
        /// ログ書込み（実行部）
        /// </summary>
        /// <param name="outputPath"></param>
        /// <param name="messageLevel"></param>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        private void WriteLogProc(string outputPath, MessageLevel messageLevel, string enterprisecode, string groupcode, Exception ex, string message)
        {
            try
            {
                lock( _thisLock )
                {
                    string writeLogText = "";
                    string yymmdd = DateTime.Now.ToString("yyyyMMdd");
                    string fileName = Path.Combine(outputPath, yymmdd + "_Log.txt");

                    if( ex == null )
                    {
                        writeLogText = this.GetLogMessage(messageLevel, enterprisecode, groupcode, message.Replace("\r\n", ""));
                    }
                    else
                    {
                        writeLogText = this.GetLogMessage(messageLevel, enterprisecode, groupcode, ex.Message.Replace("\r\n", ""));

                        string exceptionGuid = Guid.NewGuid().ToString();
                        writeLogText += string.Format("\tエラー詳細：[{0}]", exceptionGuid);

                        this.WiteExceptionLog(Path.Combine(Path.Combine(_logoutputPath, yymmdd), exceptionGuid), ex);
                    }

                    using( StreamWriter streamWriter = new StreamWriter(fileName, true) )
                    {
                        streamWriter.WriteLine(writeLogText);
                    }
                }
            }
            catch( Exception exs )
            {
                //ログ書込みに失敗した場合どうする！？
            }
        }


        /// <summary>
        /// ログ書込み用メッセージ加工処理
        /// </summary>
        /// <param name="messageLevel"></param>
        /// <param name="enterprisecode"></param>
        /// <param name="groupcode"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private string GetLogMessage(MessageLevel messageLevel, string enterprisecode, string groupcode, string message)
        {
            string result = "";

            if( messageLevel == MessageLevel.Warning )
            {
                result = string.Format("[{0}]\t[{1}]\t企業コード：[{2}]\tグループコード：[{3}]\tメッセージ：[{4}]", "Warning", DateTime.Now.ToString("yyyy/MM/dd  HH:mm:ss"), enterprisecode, groupcode, message);
            }
            else if( messageLevel == MessageLevel.Information )
            {
                result = string.Format("[{0}]\t[{1}]\t企業コード：[{2}]\tグループコード：[{3}]\tメッセージ：[{4}]", "Information", DateTime.Now.ToString("yyyy/MM/dd  HH:mm:ss"), enterprisecode, groupcode, message);
            }
            else if( messageLevel == MessageLevel.Error )
            {
                result = string.Format("[{0}]\t[{1}]\t企業コード：[{2}]\tグループコード：[{3}]\tメッセージ：[{4}]", "Error", DateTime.Now.ToString("yyyy/MM/dd  HH:mm:ss"), enterprisecode, groupcode, message);
            }
            else if( messageLevel == MessageLevel.Debug )
            {
                result = string.Format("[{0}]\t[{1}]\t企業コード：[{2}]\tグループコード：[{3}]\tメッセージ：[{4}]", "Debug", DateTime.Now.ToString("yyyy/MM/dd  HH:mm:ss"), enterprisecode, groupcode, message);
            }
            else
            {
                result = string.Format("[{0}]\t[{1}]\t企業コード：[{2}]\tグループコード：[{3}]\tメッセージ：[{4}]", "その他", DateTime.Now.ToString("yyyy/MM/dd  HH:mm:ss"), enterprisecode, groupcode, message);
            }


            return result;
        }


        /// <summary>
        /// 例外クラス出力処理
        /// </summary>
        /// <param name="outputFilePath"></param>
        /// <param name="ex"></param>
        private void WiteExceptionLog(string outputFilePath, Exception ex)
        {
            SoapFormatter sfr = null;
            MemoryStream ms = null;
            byte[] exbytes = null;
            TextWriter textWriter = null;

            try
            {
                if( !Directory.Exists(Path.GetDirectoryName(outputFilePath)) )
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));
                }
                sfr = new SoapFormatter();
                ms = new MemoryStream();
                sfr.Serialize(ms, ex);
                exbytes = ms.GetBuffer();

                textWriter = new StreamWriter(outputFilePath);
                XmlSerializer serializer = new XmlSerializer(typeof(Byte[]));
                serializer.Serialize(textWriter, exbytes);
            }
            catch( Exception )
            {
                exbytes = null;
            }
            finally
            {
                if( ms != null )
                {
                    ms.Close();
                }
                if( textWriter != null )
                {
                    textWriter.Close();
                }
            }
        }


        /// <summary>
        /// 例外クラス呼出処理
        /// </summary>
        /// <param name="inputFilePath"></param>
        /// <returns></returns>
        private Exception ReadExceptionLogProc(string inputFileName)
        {
            Exception result = null;
            StreamReader reader = null;
            MemoryStream ms = null;

            try
            {
                reader = new StreamReader(inputFileName);
                XmlSerializer deserialize = new XmlSerializer(typeof(Byte[]));
                Byte[] byt = deserialize.Deserialize(reader) as Byte[];

                SoapFormatter sfr = new SoapFormatter();
                ms = new MemoryStream(byt);

                result = sfr.Deserialize(ms) as Exception;
            }
            catch( Exception )
            {
                result = null;
            }
            finally
            {
                if( ms != null )
                {
                    ms.Close();
                }
                if( reader != null )
                {
                    reader.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// ログ出力先パス取得
        /// </summary>
        /// <returns></returns>
        private string GetLogPath()
        {
            //ログ出力パスの取得
            //優先順位はWebConfig⇒Appconfig⇒デフォルト（C:\Log）です。
            string path = "";
            try
            {
                path = System.Web.Configuration.WebConfigurationManager.AppSettings["LOGPATH"].ToString();
            }
            catch( Exception ex)
            {
                try
                {
                    System.Configuration.AppSettingsReader appSettingsReader = new System.Configuration.AppSettingsReader();
                    path = (string)appSettingsReader.GetValue("LOGPATH", typeof(string));

                    if( path == "" )
                    {
                        path = "C:\\LOG";
                    }
                }
                catch( Exception )
                {
                    path = "C:\\LOG";
                }
            }
            return path;
        }
        #endregion
    }
}