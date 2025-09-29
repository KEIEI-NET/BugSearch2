//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   SCMデータ受信処理起動リモートオブジェクト
//                  :   PMSCM01055R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21024　佐々木 健
// Date             :   2010/05/20
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Microsoft.Win32;
using System.Diagnostics;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// SCMデータ受信処理起動リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 簡単問合せ接続情報の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/03/25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class SCMDtRcveExecDB : RemoteDB,ISCMDtRcveExecDB
    {
        /// <summary>
        /// SCMデータ受信処理起動リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/05/19</br>
        /// </remarks>
        public SCMDtRcveExecDB() 
        {

        }

        /// <summary>
        /// データ受信処理を実行します
        /// </summary>
        /// <param name="wait"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : SCMデータ受信処理を実行します。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/05/19</br>
        /// </remarks>
        public int ExecuteDataReceive(bool wait)
        {
            return this.ExecuteDataReceiveProc(wait);
        }

        /// <summary>
        /// データ受信処理を実行します
        /// </summary>
        /// <param name="wait"></param>
        /// <returns></returns>
        private int ExecuteDataReceiveProc(bool wait)
        {
            try
            {
                string dir = this.GetTargetDir();
                if (string.IsNullOrEmpty(dir) || !System.IO.Directory.Exists(dir))
                {
                    return -1;
                }

                string path = System.IO.Path.Combine(dir, "PMSCM01000U.exe");

                if (!System.IO.File.Exists(path)) return -2;


                Process pr = Process.Start(path);

                if (wait) pr.WaitForExit();

                return 0;
            }
            catch (Exception ex)
            {
                return -999;
            }
        }

        /// <summary>
        /// 対象ディレクトリのを取得します
        /// </summary>
        /// <returns>USER_APのディレクトリ（取得できなかった場合はカレントディレクトリ）</returns>
        private string GetTargetDir()
        {
            string dir = string.Empty;
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (key != null) // あってはいけないケース
                {
                    dir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                }
            }
            catch
            {
            }
            if (string.IsNullOrEmpty(dir)) dir = System.IO.Directory.GetCurrentDirectory();

            return dir;
        }
    }
}
