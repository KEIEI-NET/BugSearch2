//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : Tablet用ログ出力クラス
// プログラム概要   : Tablet用ログ出力を行います
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 修正日  ：2013/07/29
// 修正者  ：吉岡
// 修正内容：ログ見直し
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 簡易ログクラス
    /// </summary>
    /// <remarks></remarks>
    public static class EasyLogger
    {
        /// <summary>デフォルト書込み者名称</summary>
        private const string DEFAULT_NAME = "PMTAB00152A_";

        /// <summary>デフォルトエンコード</summary>
        private const string DEFAULT_ENCODE = "shift_jis";

        /// <summary>ダンプフォルダ名</summary>
        private const string DUMP_DIR = "_DUMP_";

        #region <基本情報>

        /// <summary>ログ書込み者の名称</summary>
        private static string _name = DEFAULT_NAME;
        /// <summary>ログ書込み者の名称を取得します。</summary>
        public static string Name { get { return _name; } }

        /// <summary>
        /// ファイル名称を取得します。
        /// </summary>
        public static string FileName { get { return Name + DateTime.Now.ToString("yyyyMMdd") + ".log"; } }
        /// <summary>エンコード</summary>
        private static string _encode = DEFAULT_ENCODE;
        /// <summary>
        /// エンコードを取得します。
        /// </summary>
        public static string Encode { get { return _encode; } }

        private const string _path = @"\Log\PmTablet";

        #endregion // </基本情報>

        /// <summary>
        /// ログ出力用パス
        /// </summary>
        public static string OutPutPath
        {
            get { return System.IO.Directory.GetCurrentDirectory() + _path; }
        }


        /// <summary>
        /// ログを出力します。
        /// </summary>
        /// <param name="className">クラス名称</param>
        /// <param name="methodName">メソッド名称</param>
        /// <param name="msg">メッセージ</param>
        public static void Write(
            string className,
            string methodName,
            string msg
        )
        {
            FileStream fileStream = new FileStream(Path.Combine( OutPutPath ,FileName), FileMode.Append, FileAccess.Write, FileShare.Write);
            StreamWriter writer = new StreamWriter(fileStream, Encoding.GetEncoding(Encode));
            DateTime writingDateTime = DateTime.Now;
            writer.WriteLine(string.Format(
                // UPD 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // "{0,-19} {1,-5} ==> {2,-70} {3}",   // yyyy/MM/dd hh:mm:ss
                "{0,-19} {1,-5} {2,-70} {3}",   // yyyy/MM/dd hh:mm:ss
                // UPD 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                writingDateTime,
                writingDateTime.Millisecond,
                // UPD 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // className + "." + methodName,
                methodName,
                // UPD 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                msg
            ));
            if (writer != null) writer.Close();
            if (fileStream != null) fileStream.Close();
        }


        /// <summary>
        /// ダンプします。
        /// </summary>
        /// <param name="data">データ</param>
        /// <param name="keyword">XMLファイル名のキーワード</param>
        public static void Dump(
            DataSet data,
            string keyword
        )
        {
            if (data == null) return;

            string fileName = keyword + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml";
            string filePathName = Path.Combine(OutPutPath, fileName);
            data.WriteXml(filePathName);
        }

        /// <summary>
        /// ログユーティリティ
        /// int型配列からcsv形式に変換
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string LogUtlIntAryToCsv(int[] target)
        {
            // string型の配列に変換
            string[] stringArray = Array.ConvertAll<int, string>(target, delegate(int value)
            {
                return value.ToString();
            });

            // 配列をCSV文字列に変換
            return string.Join(",", stringArray);
        }
        /// <summary>
        /// ログユーティリティ
        /// byte型配列からcsv形式に変換
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string LogUtlByteAryToCsv(byte[] target)
        {
            // string型の配列に変換
            string[] stringArray = Array.ConvertAll<byte, string>(target, delegate(byte value)
            {
                return value.ToString();
            });

            // 配列をCSV文字列に変換
            return string.Join(",", stringArray);
        }
    }
}
