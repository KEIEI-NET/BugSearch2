//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/05/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/04/09  修正内容 : SCM仕掛一覧№10641対応
//----------------------------------------------------------------------------//
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// 簡易ログクラス
    /// </summary>
    /// <remarks>MAHNB01012AD.cs::SalesSlipInputInitDataAcs.LogWrite()を参考</remarks>
    public static class SimpleLogger
    {
        /// <summary>デフォルト書込み者名称(自動回答処理)</summary>
        private const string DEFAULT_NAME = "PMSCM01100U";  // 回答送信用に変更

        /// <summary>デフォルトエンコード</summary>
        private const string DEFAULT_ENCODE = "shift_jis";

        /// <summary>デバッグログのINIファイル</summary>
        private const string DEBUG_FILE_INI = "_DEBUG_.ini";
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
        public static string FileName { get { return Name + ".log"; } }

        /// <summary>エンコード</summary>
        private static string _encode = DEFAULT_ENCODE;
        /// <summary>
        /// エンコードを取得します。
        /// </summary>
        public static string Encode { get { return _encode; } }

        #endregion // </基本情報>

        /// <summary>
        /// ログを出力します。
        /// </summary>
        /// <remarks>MAHNB01012AD.cs::SalesSlipInputInitDataAcs.LogWrite()を参考</remarks>
        /// <param name="className">クラス名称</param>
        /// <param name="methodName">メソッド名称</param>
        /// <param name="msg">メッセージ</param>
        public static void Write(
            string className,
            string methodName,
            string msg
        )
        {
            FileStream fileStream = new FileStream(FileName, FileMode.Append, FileAccess.Write, FileShare.Write);
            StreamWriter writer = new StreamWriter(fileStream, Encoding.GetEncoding(Encode));
            DateTime writingDateTime = DateTime.Now;
            writer.WriteLine(string.Format(
                "{0,-19} {1,-5} ==> {2,-70} {3}",   // yyyy/MM/dd hh:mm:ss
                writingDateTime,
                writingDateTime.Millisecond,
                className + "." + methodName,
                msg
            ));
            if (writer != null) writer.Close();
            if (fileStream != null) fileStream.Close();
        }

        /// <summary>
        /// デバッグログを出力します。
        /// </summary>
        /// <remarks>MAHNB01012AD.cs::SalesSlipInputInitDataAcs.LogWrite()を参考</remarks>
        /// <param name="className">クラス名称</param>
        /// <param name="methodName">メソッド名称</param>
        /// <param name="msg">メッセージ</param>
        public static void WriteDebugLog(
            string className,
            string methodName,
            string msg
        )
        {
            if (!File.Exists(DEBUG_FILE_INI)) return;
            Write(className, methodName, msg);
        }

        // ADD 2014/04/09 SCM仕掛一覧№10641対応 ------------------------------------------>>>>>
        /// <summary>
        /// 送信エラー時のデータ情報をログに出力します
        /// </summary>
        /// <remarks></remarks>
        /// <param name="scmDataPath">ログファイルパス</param>
        /// <param name="msg">メッセージ</param>
        public static void WriteSlipNumLog(
            string scmDataPath,
            string msg
        )
        {
            // ファイル名
            // PMSCM01100U_システム日付(yyyyMMddHHMMSSsss).txt
            DateTime writingDateTime = DateTime.Now;
            Int32 updateTime = writingDateTime.Hour * 10000000 + writingDateTime.Minute * 100000 + writingDateTime.Second * 1000 + writingDateTime.Millisecond;

            string fileName = Path.Combine(scmDataPath, Name + "_" +  string.Format("{0:yyyyMMdd}", writingDateTime) + updateTime.ToString() + ".txt");
            FileStream fileStream = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.Write);
            StreamWriter writer = new StreamWriter(fileStream, Encoding.GetEncoding(Encode));
            writer.WriteLine(string.Format("{0}", msg));
            if (writer != null) writer.Close();
            if (fileStream != null) fileStream.Close();
        }
        // ADD 2014/04/09 SCM仕掛一覧№10641対応 ------------------------------------------<<<<<

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
            if (!Directory.Exists(DUMP_DIR)) return;
            if (data == null) return;

            string fileName = keyword + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml";
            string filePathName = Path.Combine(DUMP_DIR, fileName);
            data.WriteXml(filePathName);
        }

        /// <summary>ファイルサイズの限界値[Byte]</summary>
        private const long FILE_SIZE_LIMIT = 4000000;

        /// <summary>
        /// 条件付きでログをバックアップします。
        /// </summary>
        /// <remarks>
        /// ログファイルが4[MB]以上であれば別名で保存します。
        /// </remarks>
        /// <param name="logPathName">ログファイルのパス</param>
        /// <returns>
        /// バックアップしたファイル名 ※バックアップを行わなかった場合、<c>string.Empty</c>を返します。
        /// </returns>
        public static string BackupLogIf(string logPathName)
        {
            #region <Guard Phrase>

            if (!File.Exists(logPathName)) return string.Empty;

            #endregion // </Guard Phrase>

            FileInfo logInfo = new FileInfo(logPathName);
            {
                if (logInfo.Length < FILE_SIZE_LIMIT) return string.Empty;
            }
            string backupedName = Path.GetFileNameWithoutExtension(logPathName)
                + DateTime.Now.ToString("yyyyMMddHHmmss")
                + Path.GetExtension(logPathName);
            {
                File.Copy(logPathName, Path.Combine(Path.GetDirectoryName(logPathName), backupedName), true);
            }
            return backupedName;
        }
    }
}
