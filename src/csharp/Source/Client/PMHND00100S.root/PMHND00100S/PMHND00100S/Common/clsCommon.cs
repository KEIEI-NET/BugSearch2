//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : PMNS-HTT通信サービス
// プログラム概要   : PMNS-HTT間の通信を行うサービスプログラムです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 佐藤　智之
// 作 成 日  2017/07/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11575094-00 作成担当 : 岸　傑
// 作 成 日  2019/06/13  修正内容 : 大黒商会検品障害対応
//----------------------------------------------------------------------------//
// 管理番号  11570136-00 作成担当 : 白厩  翔也
// 修 正 日  2019/10/16  修正内容 : ６次対応
//----------------------------------------------------------------------------//
// 管理番号  11570249-00 作成担当 : 白厩  翔也
// 修 正 日  2020/04/01  修正内容 : ハンディ仕入れ時在庫登録対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using log4net;

namespace PMHND00100S.Common
{
    /// public class name:   clsCommon
    /// <summary>
    ///                      共通使用する変数定義クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   プロジェクト内で共通使用するグローバル変数を定義する</br>
    /// <br>Programmer       :   佐藤　智之</br>
    /// <br>Date             :   2017/07/01</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    class clsCommon
    {

#region "定数"

#endregion

#region "変数"

        /// <summary>引数</summary>
        public static string gArgs = string.Empty;

        /// <summary>設定ファイル　ハンディとのソケット通信　ＩＰアドレス</summary>
        public static string gIpAddress = "192.168.0.0";

        /// <summary>設定ファイル　ハンディとのソケット通信　ポート</summary>
        public static Int32 gSocketPort = 20024;

        /// <summary>設定ファイル　ログの出力判定</summary>
        public static String gDebugDetailLog = "on";

        /// <summary>ＩＰＣアドレス</summary>
        public static string gIpcAddress = "ipc://PmHandyChannel/PmHandyService";

        // --- ADD 2019/06/13 ---------->>>>>
        /// <summary>リトライ回数</summary>
        public static string gRetryTimes = "3";
        /// <summary>リトライ間隔</summary>
        public static string gRetryInterval = "100";
        // --- ADD 2019/06/13 ----------<<<<<

        // -- ADD 2019/10/16 ------------------------------>>>
        /// <summary>ソケット通信のバッファサイズ</summary>
        public static Int32 gSocketBufferSiz = 500000;
        // -- ADD 2019/10/16 ------------------------------<<<
#endregion

#region "関数"
        /// <summary>
        /// 文字列からバイト数を指定して部分文字列を取得する。
        /// </summary>
        /// <param name="value">対象文字列。</param>
        /// <param name="startIndex">開始位置。0～（バイト数）</param>
        /// <param name="length">長さ。（バイト数）</param>
        /// <returns>部分文字列。</returns>
        /// <remarks>文字列は <c>Shift_JIS</c> でエンコーディングして処理を行います。</remarks>
        public static string MidB(string value, Int32 startIndex, Int32 length)
        {

            System.Text.Encoding sjisEnc = System.Text.Encoding.GetEncoding("Shift_JIS");
            byte[] byteArray = sjisEnc.GetBytes(value);

            if (byteArray.Length < startIndex + 1)
            {
                return "";
            }

            if (byteArray.Length < startIndex + length)
            {
                length = byteArray.Length - startIndex;
            }

            string cut = sjisEnc.GetString(byteArray, startIndex, length);

            // 最初の文字が全角の途中で切れていた場合は１文字切り上げる
            string left = sjisEnc.GetString(byteArray, 0, startIndex + 1);
            char first = value[left.Length - 1];
            if (0 < cut.Length && !(first == cut[0]))
            {
                //cut = cut.Substring(1)   '最初の文字が全角の途中で切れていた場合はカット
                cut = sjisEnc.GetString(byteArray, startIndex - 1, length);
            }

            // 最後の文字が全角の途中で切れていた場合はカット
            left = sjisEnc.GetString(byteArray, 0, startIndex + length);

            char last = value[left.Length - 1];
            if (0 < cut.Length && !(last == cut[cut.Length - 1]))
            {
                cut = cut.Substring(0, cut.Length - 1);
            }

            return cut;

        }

        /// <summary>
        /// 文字列からバイト数を指定して固定長文字列を返す。
        /// </summary>
        /// <param name="value">対象文字列。</param>
        /// <param name="length">長さ。（バイト数）</param>
        /// <returns>固定長文字列。</returns>
        /// <remarks>文字列は <c>Shift_JIS</c> でエンコーディングして処理を行います。</remarks>
        public static string FixB(string value, Int32 length)
        {
            System.Text.Encoding sjisEnc = System.Text.Encoding.GetEncoding("Shift_JIS");
            byte[] byteArray = sjisEnc.GetBytes(value);

            Int32 sublength = length;

            if (byteArray.Length < length)
            {
                sublength = byteArray.Length;
            }

            string fixSt = sjisEnc.GetString(byteArray, 0, sublength);

            if (sublength != 0)
            {
                // 最初の文字が全角の途中で切れていた場合は１文字切り上げる
                string left = sjisEnc.GetString(byteArray, 0, 1);
                char first = value[left.Length - 1];
                if (0 < fixSt.Length && !(first == fixSt[0]))
                {
                    //fixSt = fixSt.Substring(1)   '最初の文字が全角の途中で切れていた場合はカット
                    fixSt = sjisEnc.GetString(byteArray, -1, sublength);
                }

                // 最後の文字が全角の途中で切れていた場合はカット
                left = sjisEnc.GetString(byteArray, 0, 0 + sublength);

                char last = value[left.Length - 1];
                if (0 < fixSt.Length && !(last == fixSt[fixSt.Length - 1]))
                {
                    fixSt = fixSt.Substring(0, fixSt.Length - 1);
                }
            }

            byteArray = sjisEnc.GetBytes(fixSt);

            if (byteArray.Length < length)
            {
                string stLen = (-1 * length).ToString();
                fixSt = String.Format("{0, " + stLen + "}", fixSt);
            }

            return fixSt;

        }

        /// <summary>
        /// log4netでのログ出力処理
        /// </summary>
        /// <param name="LOGGER"></param>
        /// <param name="logKbn">ログ出力レベル</param>
        /// <param name="message">ログ出力内容</param>
        public static void writeLog4(ILog LOGGER, clsBtConst.enumLOG4_KBN logKbn, string message)
        {
            //log4ロジックの実行判断
            if (clsCommon.gDebugDetailLog == clsBtConst.DEBUG_DETAIL_LOG_ON)
            {
                //ログ出力レベルで出力内容の切り替え
                switch (logKbn) 
                { 
                    case clsBtConst.enumLOG4_KBN.FATAL:
                        LOGGER.Fatal(message);
                        break;

                    case clsBtConst.enumLOG4_KBN.ERROR:
                        LOGGER.Error(message);
                        break;

                    case clsBtConst.enumLOG4_KBN.WARN:
                        LOGGER.Warn(message);
                        break;

                    case clsBtConst.enumLOG4_KBN.INFO:
                        LOGGER.Info(message);
                        break;

                    case clsBtConst.enumLOG4_KBN.DEBUG:
                        LOGGER.Debug(message);
                        break;
                }
            }
        }

        /// <summary>
        /// 日付フォーマット（DateTime型 ⇒ yyyyMMdd）
        /// </summary>
        /// <param name="strTarget">処理対象文字列</param>
        /// <returns>yyyy/MM/ddの文字列を返却する</returns>
        /// <remarks></remarks>
        public static string datFormat(DateTime dtmTarget)
        {
            try
            {
                string strBuf = "";

                //初期値
                if ((dtmTarget == new DateTime()) || (dtmTarget == new DateTime(0)))
                {
                    strBuf = setMaeSpace(" ", 8);
                    return strBuf;
                }

                strBuf = dtmTarget.ToString("yyyyMMdd");

                return strBuf;

            }
            catch (Exception ex)
            {
                string err = ex.Message;
                //システムエラー
                //frmMsgBoxMulti.showMsgBox(clsMsgConst.MSG_ALL_SYS_ERR + ex.Message);
                return dtmTarget.ToString();
            }
        }

        /// <summary>
        /// 前スペース埋め
        /// </summary>
        /// <param name="target"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string setMaeSpace(string target, Int32 len)
        {
            string strTarget = target;
            //桁数より少ない場合
            if (target.Length < len)
            {
                Int32 iCnt = 0;
                //0埋め処理
                for (iCnt = 0; iCnt <= len - target.Length - 1; iCnt++)
                {
                    strTarget = " " + strTarget;
                }
            }
            return strTarget;
        }

        /// <summary>
        /// ゼロ埋め
        /// </summary>
        /// <param name="target"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string setMaeZero(Int32 target, Int32 len)
        {
            string RetVal = target.ToString("00;-#");

            return RetVal;
        }

        // -- ADD 2020/04/01 ------------------------------>>>
        /// <summary>
        /// NULL or 空文字列の判定
        /// </summary>
        /// <param name="varBuf">処理対象の値</param>
        /// <returns>True:Null or 空文字列、False:Not Null or Not 空文字列</returns>
        /// <remarks></remarks>
        public static bool gIsNull(object varBuf)
        {
            bool functionReturnValue = false;
            functionReturnValue = false;
            if (varBuf == null)
            {
                functionReturnValue = true;
            }
            else if (varBuf.ToString().Trim().Length == 0)
            {
                functionReturnValue = true;
            }
            return functionReturnValue;
        }

        /// <summary>
        /// NULL Value を空文字列("")に変換
        /// </summary>
        /// <param name="varBuf">処理対象の値</param>
        /// <returns>String</returns>
        /// <remarks>引数の文字列が Null Value の場合空文字列を返す(上記以外は引数の値をﾄﾘﾐﾝｸﾞして返す)</remarks>
        public static string gNullToStr(object varBuf)
        {
            string functionReturnValue = null;
            if (gIsNull(varBuf) == true)
            {
                functionReturnValue = "";
            }
            else
            {
                functionReturnValue = varBuf.ToString().Trim();
            }
            return functionReturnValue;
        }
        // -- ADD 2020/04/01 ------------------------------<<<

#endregion

    }
}
