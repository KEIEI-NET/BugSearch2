//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自動起動サービス処理
// プログラム概要   : 自動起動サービスファイルを保存
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 修 正 日  2011/09/01  修正内容 : #24278 データ自動受信処理が起動しません
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2014/10/02  修正内容 : ツールチェックの修正
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using Broadleaf.Library.Resources;
using Microsoft.Win32;
using System.IO;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 自動起動サービスリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自動起動サービスの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class ServiceFilesDB : RemoteDB, IServiceFilesDB
    {
        #region read
        /// <summary>
        /// ファイル読む
        /// </summary>
        /// <param name="file">ファイル内容</param>
        /// <param name="msg">メッセージ</param>
        /// <param name="fileFlg">ファイルフラグ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.4.29</br>
        public int Read(ref object file, ref string msg, ref int fileFlg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            string workDir = string.Empty;

            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (key == null) // あってはいけないケース
                {
                    msg = "レジストリの取得に失敗しました。";
                    ServiceFilesWork serviceFilesWork = new ServiceFilesWork();
                    serviceFilesWork.FileContent = new byte[128];
                    file = serviceFilesWork as object;
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
                    workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = ReadCfgFile(ref file, workDir, ref msg, ref fileFlg);
            }
            return status;
        }


        /// <summary>
        /// 設定ファイル読込み
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private int ReadCfgFile(ref object file, string workDir, ref string msg, ref int fileFlg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            ServiceFilesWork serviceFilesWork = (ServiceFilesWork)file;

            try
            {
                string fileNm = Path.Combine(workDir, "PMCMN06200S.USR.XML");

                bool isExist = File.Exists(fileNm);

                // ファイル存在チェック
                if (isExist)
                {
                    FileStream fs = new FileStream(fileNm, FileMode.Open, FileAccess.Read, FileShare.Read);
                    byte[] tmp = new byte[fs.Length];
                    int cnt = fs.Read(tmp, 0, (int)fs.Length);
                    for (int i = 0; i < cnt; i++)
                    {
                        tmp[i] += 8;
                    }

                    fs.Dispose();

                    // フラグ
                    fileFlg = 1;
                    serviceFilesWork.FileContent = tmp;
                }
                else
                {
                    fileNm = Path.Combine(workDir, "PMCMN06200S.XML");

                    isExist = File.Exists(fileNm);

                    // ファイル存在チェック
                    if (isExist)
                    {
                        FileStream fs = new FileStream(fileNm, FileMode.Open, FileAccess.Read, FileShare.Read);
                        byte[] tmp = new byte[fs.Length];
                        int cnt = fs.Read(tmp, 0, (int)fs.Length);
                        for (int i = 0; i < cnt; i++)
                        {
                            tmp[i] += 8;
                        }

                        fs.Dispose();

                        // フラグ
                        fileFlg = 2;
                        serviceFilesWork.FileContent = tmp;
                    }
                    else
                    {
                        serviceFilesWork.FileContent = new byte[128];
                        msg = "指定された設定ファイルがありません。";
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
            }
            catch
            {
                msg = "XMLファイルの内容が不正です。";
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            file = serviceFilesWork as object;

            return status;
        }
        #endregion

        #region

        /// <summary>
        /// ファイル書き
        /// </summary>
        /// <param name="file">ファイル内容</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ取得</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        public int Write(object file)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            ServiceFilesWork serviceFilesWork = (ServiceFilesWork)file;

            string workDir = string.Empty;

            try
            {
                if (serviceFilesWork != null)
                {

                    RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                    if (key == null) // あってはいけないケース
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                    else
                    {
                        workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                    }


                    string fileNm = Path.Combine(workDir, "PMCMN06200S.USR.XML");

                    FileStream fs = new FileStream(fileNm, FileMode.Create, FileAccess.Write, FileShare.Write);

                    for (int i = 0; i < serviceFilesWork.FileContent.Length; i++)
                    {
                        serviceFilesWork.FileContent[i] -= 8;
                    }

                    fs.Write(serviceFilesWork.FileContent, 0, serviceFilesWork.FileContent.Length);

                    fs.Close();
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #region 2011/09/01 #24278 データ自動受信処理が起動しません
        #region read
        /// <summary>
        /// ファイル読む
        /// </summary>
        /// <param name="file">ファイル内容</param>
        /// <param name="msg">メッセージ</param>
        /// <param name="fileFlg">ファイルフラグ</param>
        /// <param name="dataType">データタイプ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 孫東響</br>
        /// <br>Date       : 2011.09.01</br>
        public int Read(ref object file, ref string msg, ref int fileFlg, int dataType)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            string workDir = string.Empty;

            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (key == null) // あってはいけないケース
                {
                    msg = "レジストリの取得に失敗しました。";
                    ServiceFilesWork serviceFilesWork = new ServiceFilesWork();
                    serviceFilesWork.FileContent = new byte[128];
                    file = serviceFilesWork as object;
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
                    workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = ReadCfgFile(ref file, workDir, ref msg, ref fileFlg, dataType);
            }
            return status;
        }


        /// <summary>
        /// 設定ファイル読込み
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 孫東響</br>
        /// <br>Date       : 2011.09.01</br>
        /// </remarks>
        private int ReadCfgFile(ref object file, string workDir, ref string msg, ref int fileFlg, int dataType)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            ServiceFilesWork serviceFilesWork = (ServiceFilesWork)file;            
            string fileName = "PMCMN06200S.SCM.XML";

            try
            {
                if(dataType == 1)
                {
                    fileName = "PMCMN06200S.SCM.XML";
                }

                string fileNm = Path.Combine(workDir, fileName);

                bool isExist = File.Exists(fileNm);

                // ファイル存在チェック
                if (isExist)
                {
                    FileStream fs = new FileStream(fileNm, FileMode.Open, FileAccess.Read, FileShare.Read);
                    byte[] tmp = new byte[fs.Length];
                    int cnt = fs.Read(tmp, 0, (int)fs.Length);
                    for (int i = 0; i < cnt; i++)
                    {
                        tmp[i] += 8;
                    }

                    fs.Dispose();

                    // フラグ
                    fileFlg = 1;
                    serviceFilesWork.FileContent = tmp;
                }
                else
                { 
                    serviceFilesWork.FileContent = new byte[128];
                    msg = "指定された設定ファイルがありません。";
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    //}
                }
            }
            catch
            {
                msg = "XMLファイルの内容が不正です。";
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            file = serviceFilesWork as object;

            return status;
        }
        #endregion

        #region write

        /// <summary>
        /// ファイル書き
        /// </summary>
        /// <param name="file">ファイル内容</param>
        /// <param name="dataType">データタイプ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ取得</br>
        /// <br>Programmer : 孫東響</br>
        /// <br>Date       : 2011.09.01</br>
        public int Write(object file, int dataType)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            ServiceFilesWork serviceFilesWork = (ServiceFilesWork)file;

            string workDir = string.Empty;
            string fileName = "PMCMN06200S.SCM.XML";
            try
            {
                if (serviceFilesWork != null)
                {

                    RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                    if (key == null) // あってはいけないケース
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                    else
                    {
                        workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                    }

                    if (dataType == 1)
                    {
                        fileName = "PMCMN06200S.SCM.XML";
                    }
                    string fileNm = Path.Combine(workDir, fileName);

                    FileStream fs = new FileStream(fileNm, FileMode.Create, FileAccess.Write, FileShare.Write);

                    for (int i = 0; i < serviceFilesWork.FileContent.Length; i++)
                    {
                        serviceFilesWork.FileContent[i] -= 8;
                    }

                    fs.Write(serviceFilesWork.FileContent, 0, serviceFilesWork.FileContent.Length);

                    fs.Close();
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion
        #endregion


        // ---- ADD 譚洪 2014/10/02 ---------------------------->>>>>
        /// <summary>
        /// ファイル読む
        /// </summary>
        /// <param name="file">ファイル内容</param>
        /// <param name="msg">メッセージ</param>
        /// <param name="fileFlg">ファイルフラグ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2014/10/02</br>
        public int Read(ref object userFile, ref object commFile, ref string msg, ref int fileFlg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            string workDir = string.Empty;

            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (key == null) // あってはいけないケース
                {
                    msg = "レジストリの取得に失敗しました。";
                    ServiceFilesWork userServiceFilesWork = new ServiceFilesWork();
                    userServiceFilesWork.FileContent = new byte[128];
                    userFile = userServiceFilesWork as object;

                    ServiceFilesWork commServiceFilesWork = new ServiceFilesWork();
                    commServiceFilesWork.FileContent = new byte[128];
                    commFile = commServiceFilesWork as object;

                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
                    workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = ReadCfgFile(ref userFile, ref commFile, workDir, ref msg, ref fileFlg);
            }
            return status;
        }



        /// <summary>
        /// 設定ファイル読込み
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2014/10/02</br>
        /// </remarks>
        private int ReadCfgFile(ref object userFile, ref object commFile, string workDir, ref string msg, ref int fileFlg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            ServiceFilesWork userServiceFilesWork = (ServiceFilesWork)userFile;
            ServiceFilesWork commServiceFilesWork = (ServiceFilesWork)commFile;

            try
            {
                string userFileNm = Path.Combine(workDir, "PMCMN06200S.USR.XML");

                bool userIsExist = File.Exists(userFileNm);

                // ファイル存在チェック
                if (userIsExist)
                {
                    FileStream fs = new FileStream(userFileNm, FileMode.Open, FileAccess.Read, FileShare.Read);
                    byte[] tmp = new byte[fs.Length];
                    int cnt = fs.Read(tmp, 0, (int)fs.Length);
                    for (int i = 0; i < cnt; i++)
                    {
                        tmp[i] += 8;
                    }

                    fs.Dispose();

                    // フラグ
                    fileFlg = 1;
                    userServiceFilesWork.FileContent = tmp;
                }
                else
                {
                    userFileNm = Path.Combine(workDir, "PMCMN06200S.XML");

                    userIsExist = File.Exists(userFileNm);

                    // ファイル存在チェック
                    if (userIsExist)
                    {
                        FileStream fs = new FileStream(userFileNm, FileMode.Open, FileAccess.Read, FileShare.Read);
                        byte[] tmp = new byte[fs.Length];
                        int cnt = fs.Read(tmp, 0, (int)fs.Length);
                        for (int i = 0; i < cnt; i++)
                        {
                            tmp[i] += 8;
                        }

                        fs.Dispose();

                        // フラグ
                        fileFlg = 2;
                        userServiceFilesWork.FileContent = tmp;
                    }
                    else
                    {
                        userServiceFilesWork.FileContent = new byte[128];
                        msg = "指定された設定ファイルがありません。";
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }

                string commFileNm = Path.Combine(workDir, "PMCMN06200S.XML");

                bool commIsExist = File.Exists(commFileNm);

                // ファイル存在チェック
                if (commIsExist)
                {
                    FileStream fs = new FileStream(commFileNm, FileMode.Open, FileAccess.Read, FileShare.Read);
                    byte[] tmp = new byte[fs.Length];
                    int cnt = fs.Read(tmp, 0, (int)fs.Length);
                    for (int i = 0; i < cnt; i++)
                    {
                        tmp[i] += 8;
                    }

                    fs.Dispose();

                    // フラグ
                    commServiceFilesWork.FileContent = tmp;
                }


                if (!userIsExist)
                {
                    userServiceFilesWork.FileContent = new byte[128];
                }

                if (!commIsExist)
                {
                    commServiceFilesWork.FileContent = new byte[128];
                }

                if (!userIsExist && !commIsExist)
                {
                    msg = "指定された設定ファイルがありません。";
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch
            {
                msg = "XMLファイルの内容が不正です。";
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            userFile = userServiceFilesWork as object;
            commFile = commServiceFilesWork as object;

            return status;
        }
        // ---- ADD 譚洪 2014/10/02 ----------------------------<<<<<
    }
}
