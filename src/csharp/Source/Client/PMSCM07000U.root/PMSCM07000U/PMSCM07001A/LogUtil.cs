//****************************************************************************//
// システム         : NS待機処理
// プログラム名称   : NS待機処理ユーティリティ
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/06/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Broadleaf.Library.Text;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ログユーティリティ
    /// </summary>
    public static class LogUtil
    {
        /// <summary>日時のフォーマット</summary>
        private const string DATE_TIME_FORMAT = "yyyy/MM/dd HH:mm:ss";

        /// <summary>
        /// ログの1行を取得します。
        /// </summary>
        /// <param name="msg">メッセージ</param>
        /// <returns>日時 + メッセージ</returns>
        public static string GetLine(string msg)
        {
            const string FORMAT = "{0} {1}";
            return string.Format(FORMAT, DateTime.Now.ToString(DATE_TIME_FORMAT), msg);
        }

        /// <summary>
        /// ログの1行を取得します。
        /// </summary>
        /// <param name="target">対象名</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>日時 + 対象名 + メッセージ</returns>
        public static string GetLine(
            string target,
            string msg
        )
        {
            const string FORMAT = "{0} {1} {2}";
            return string.Format(FORMAT, DateTime.Now.ToString(DATE_TIME_FORMAT), target, msg);
        }

        /// <summary>
        /// ログの1行を取得します。
        /// </summary>
        /// <param name="target">対象名</param>
        /// <param name="seq">連番（例：送信コマンドの処理順の番号）</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>日時 + 対象名 + [連番] + メッセージ</returns>
        public static string GetLine(
            string target,
            int seq,
            string msg
        )
        {
            const string FORMAT = "{0} {1} [{2}] {3}";
            return string.Format(FORMAT, DateTime.Now.ToString(DATE_TIME_FORMAT), target, seq, msg);
        }

        #region 復号化／暗号化

        /// <summary>
        /// ファイルを復号化します。
        /// </summary>
        /// <param name="filePathName">ファイルパス</param>
        public static void DecodeFile(string filePathName)
        {
            byte[] decodes = null;

            using (FileStream inputFile = new FileStream(filePathName, FileMode.Open))
            {
                decodes = TSPSendXMLReader.DecryptXML(inputFile);
            }

            using (FileStream outputFile = new FileStream(filePathName, FileMode.Create))
            {
                outputFile.Write(decodes, 0, decodes.Length);
            }

            #region ボツ

            //string text = string.Empty;
            //if (decodes != null && decodes.Length > 0)
            //{
            //    text = TStrConv.SJisToUnicode(decodes).Trim();
            //}

            //if (string.IsNullOrEmpty(text)) return;

            //using (StreamWriter writer = new StreamWriter(filePathName))
            //{
            //    writer.Write(text);
            //}

            ////using (FileStream decodedFile = new FileStream(filePathName, FileMode.Create))
            ////{
            ////    StreamWriter writer = new StreamWriter(decodedFile, Encoding.GetEncoding("Shift-JIS"));
            ////    {
            ////        writer.Write(text);
            ////    }
            ////}

            #endregion // ボツ
        }

        /// <summary>
        /// ファイルを暗号化します。
        /// </summary>
        /// <param name="filePathName">ファイルパス</param>
        public static void EncodeFile(string filePathName)
        {
            MemoryStream context = null;

            using (FileStream inputFile = new FileStream(filePathName, FileMode.Open))
            {
                byte[] decodes = new byte[inputFile.Length];
                inputFile.Read(decodes, 0, (int)inputFile.Length);

                #region ボツ

                //StreamReader reader = new StreamReader(inputFile, Encoding.GetEncoding("Shift-JIS"));
                //string text = reader.ReadToEnd();

                //byte[] decodes = TStrConv.UnicodeToSJis(text);

                #endregion // ボツ

                context = new MemoryStream(decodes);
            }

            using (FileStream outputFile = new FileStream(filePathName, FileMode.Create))
            {
                byte[] encodes = TSPSendXMLWriter.EncryptXML(context);
                outputFile.Write(encodes, 0, encodes.Length);
            }
        }

        #endregion // 復号化／暗号化
    }
}
