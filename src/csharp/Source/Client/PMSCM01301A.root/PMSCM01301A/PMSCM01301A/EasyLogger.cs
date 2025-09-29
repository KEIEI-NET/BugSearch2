//****************************************************************************//
// システム         : BLP自社設定マスタ倉庫移行
// プログラム名称   : BLP自社設定マスタ倉庫移行
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 三戸　伸悟
// 作 成 日  2012/12/14  修正内容 : 新規作成
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
        /// <summary>デフォルト書込み者名称(BLP自社設定マスタ倉庫移行)</summary>
        private const string DEFAULT_NAME = "PMSCM01300U";

        /// <summary>デフォルトエンコード</summary>
        private const string DEFAULT_ENCODE = "shift_jis";

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
        /// <param name="msg">メッセージ</param>
        public static void Write(
            string msg
        )
        {
            FileStream fileStream = new FileStream(FileName, FileMode.Append, FileAccess.Write, FileShare.Write);
            StreamWriter writer = new StreamWriter(fileStream, Encoding.GetEncoding(Encode));
            writer.WriteLine(msg);
            if (writer != null) writer.Close();
            if (fileStream != null) fileStream.Close();
        }
    }
}
