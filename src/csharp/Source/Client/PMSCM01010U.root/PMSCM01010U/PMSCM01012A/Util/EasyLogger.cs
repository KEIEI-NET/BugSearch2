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
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2014/01/17  修正内容 : SCM仕掛一覧№10628対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
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
    public static class EasyLogger
    {
        /// <summary>デフォルト書込み者名称(自動回答処理)</summary>
        private const string DEFAULT_NAME = "PMSCM01010U";

        /// <summary>デフォルトエンコード</summary>
        private const string DEFAULT_ENCODE = "shift_jis";

        /// <summary>デバッグログのINIファイル</summary>
        private const string DEBUG_FILE_INI = "_DEBUG_.ini";
        /// <summary>ダンプフォルダ名</summary>
        private const string DUMP_DIR = "_DUMP_";

        // ADD 2014/01/17 SCM障害№10628 吉岡 配信日未定 自動回答速度改善 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary> デバッグログのINIファイル読込状態 　
        /// -1:未読込 
        ///  0:ファイル無し(デバッグログ出力無し)  
        ///  1:ファイル有り(デバッグログ出力有り)  </summary>
        public static sbyte debugIniFlg = -1;
        // ADD 2014/01/17 SCM障害№10628 吉岡 配信日未定 自動回答速度改善 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

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
            // UPD 2014/01/17 SCM障害№10628 吉岡 配信日未定 自動回答速度改善 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //if (!File.Exists(DEBUG_FILE_INI)) return;
            //Write(className, methodName, msg);

            if (debugIniFlg.Equals(-1))
            {
                // 未読込場合のみ読込む
                if (File.Exists(DEBUG_FILE_INI))
                {
                    debugIniFlg = 1;
                }
                else
                {
                    debugIniFlg = 0;
                }
            }

            if (debugIniFlg.Equals(1)) Write(className, methodName, msg);
            // UPD 2014/01/17 SCM障害№10628 吉岡 配信日未定 自動回答速度改善 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
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
            if (!Directory.Exists(DUMP_DIR)) return;
            if (data == null) return;

            string fileName = keyword + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml";
            string filePathName = Path.Combine(DUMP_DIR, fileName);
            data.WriteXml(filePathName);
        }

        /// <summary>
        /// ログ出力(DEBUG)処理
        /// </summary>
        /// <param name="pMsg"></param>
        public static void LogWrite(string pMsg)
        {
#if DEBUG
            System.IO.FileStream _fs;										// ファイルストリーム
            System.IO.StreamWriter _sw;										// ストリームwriter
            _fs = new FileStream("d:\\ddd.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
            _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
            DateTime edt = DateTime.Now;
            //yyyy/MM/dd hh:mm:ss
            _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg));
            if (_sw != null)
                _sw.Close();
            if (_fs != null)
                _fs.Close();
#endif
        }

    }
}
