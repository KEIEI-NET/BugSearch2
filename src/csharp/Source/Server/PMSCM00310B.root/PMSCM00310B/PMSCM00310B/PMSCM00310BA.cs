//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 同期認証部品
// プログラム概要   : 同期認証部品
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 11070136-00  作成担当 : 松本 宏紀
// 作 成 日  2014/08/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Security.Cryptography;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// 認証情報管理クラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: </br>
    /// <br>Programmer	: 松本 宏紀</br>
    /// <br>Date		: 2014/08/27</br>
    /// </remarks>
    public class PmSyncAuthenticator
    {
        public static string Version
        {
            get { return "1.0.0"; }
        }

        public static string GetAuthenticationKey(string value)
        {
            return GetAuthenticationKeyProc(value);
        }

        private static string GetAuthenticationKeyProc(string value)
        {
            string secretKey = value;
            secretKey += Encoding.UTF8.GetString(new byte[] { 0x21, 0x72, 0x9, 0x21, 0x65, 0xD, 0x21, 0x70, 0x73, 0xA, 0x70, 0x73, 0x63, 0x6D, 0x6C, 0x69, 0x63, 0x6D, 0x61, 0x6E, 0xE2, 0x98, 0x80 });

            SHA1Managed sha1 = new SHA1Managed();
            return ToHexString(sha1.ComputeHash(Encoding.UTF8.GetBytes(secretKey)));
        }

        private static string ToHexString(byte[] value)
        {
            StringBuilder sb = new StringBuilder(value.Length * 2);
            foreach (byte b in value)
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
