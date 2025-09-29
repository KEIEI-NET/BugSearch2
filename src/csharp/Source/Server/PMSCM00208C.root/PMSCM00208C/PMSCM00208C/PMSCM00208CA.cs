//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   簡単問合せ接続情報制御クラス
//                  :   PMSCM00208C.dll
// Name Space       :   Broadleaf.Application.Common
// Programmer       :   21024　佐々木 健
// Date             :   2010/03/25
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using Broadleaf.Library.Resources;


namespace Broadleaf.Application.Common
{
    /// <summary>
    /// 簡単問合せ接続情報制御クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 簡単問合せ接続情報の制御（追加、削除、クリア、取得）を行うクラスです。</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/03/25</br>
    /// </remarks>
    public static class SimplInqCnectInfoController
    {
        #region ■ Constructor
        ///// <summary>
        ///// デフォルトコンストラクタ
        ///// </summary>
        //public CMTCnectInfoController()
        //{

        //}
        #endregion

        #region ■ Private Member
        // リトライ回数
        static readonly int retry = 5;
        #endregion

        #region ■ Property
        #endregion

        #region ■ Public Method

        #region 追加
        /// <summary>
        /// 対象企業の簡単問合せ接続情報を追加します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="cmtCnectInfo">簡単問合せ接続情報</param>
        /// <returns>ステータス(＝0:正常、≠0:エラー</returns>
        public static int AddConnectionInfo(string enterpriseCode, SimplInqCnectInfo cmtCnectInfo)
        {
            List<SimplInqCnectInfo> list = new List<SimplInqCnectInfo>();
            list.Add(cmtCnectInfo);
            return AddConnectionInfo(enterpriseCode, list);
        }

        /// <summary>
        /// 対象企業の簡単問合せ接続情報を追加します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="cmtCnectInfoList">簡単問合せ接続情報リスト</param>
        /// <returns>ステータス(＝0:正常、≠0:エラー</returns>
        public static int AddConnectionInfo(string enterpriseCode, List<SimplInqCnectInfo> cmtCnectInfoList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            for (int i = 0; i < retry; i++)
            {
                status = AddCMTCnectInfoProc(enterpriseCode, cmtCnectInfoList);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) break;

                // 0.1秒待ってリトライ
                System.Threading.Thread.Sleep(100);
            }
            return status;
        }

        #endregion

        #region 削除
        /// <summary>
        /// 対象企業の簡単問合せ接続情報を削除します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="cmtCnectInfo">簡単問合せ接続情報</param>
        /// <returns>ステータス(＝0:正常、≠0:エラー</returns>
        public static int DeleteConnectionInfo(string enterpriseCode, SimplInqCnectInfo cmtCnectInfo)
        {
            List<SimplInqCnectInfo> list = new List<SimplInqCnectInfo>();
            list.Add(cmtCnectInfo);

            return DeleteConnectionInfo(enterpriseCode, list);
        }

        /// <summary>
        /// 対象企業の簡単問合せ接続情報を削除します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="cmtCnectInfoList">簡単問合せ接続情報リスト</param>
        /// <returns>ステータス(＝0:正常、≠0:エラー</returns>
        public static int DeleteConnectionInfo(string enterpriseCode, List<SimplInqCnectInfo> cmtCnectInfoList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            for (int i = 0; i < retry; i++)
            {
                status = DeleteCMTCnectInfoProc(enterpriseCode, cmtCnectInfoList);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) break;

                // 0.1秒待ってリトライ
                System.Threading.Thread.Sleep(100);
            }

            return status;
        }
        #endregion

        #region クリア
        /// <summary>
        /// 対象企業の簡単問合せ接続情報をクリアします。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        public static int ClearConnectionInfo(string enterpriseCode)
        {
            SimplInqCnectInfo cmtCnectInfo = new SimplInqCnectInfo();

            return DeleteConnectionInfo(enterpriseCode, cmtCnectInfo);
        }
        #endregion

        #region 取得

        /// <summary>
        /// 接続情報の取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        public static List<SimplInqCnectInfo> GetConnectionInfolist(string enterpriseCode)
        {
            return GetConnectionListProc(enterpriseCode);
        }

        #endregion

        #endregion

        #region ■ Private Static Method

        /// <summary>
        /// ファイルパス取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>ファイルフルパス</returns>
        private static string GetFilePath(string enterpriseCode)
        {
            string path = GetSystemDir();
            path = System.IO.Path.Combine(path, "SimpleInquiryConnect");
            path = System.IO.Path.Combine(path, string.Format("SimpleInquiryConnect_{0}.bin", enterpriseCode));

            return path;
        }

        /// <summary>
        /// システムフォルダの取得
        /// </summary>
        /// <returns></returns>
        private static string GetSystemDir()
        {
            string ret = string.Empty;
            string rKeyName = @"SOFTWARE\Broadleaf\Service\Partsman\USER_AP\";
            string rGetValueName = "InstallDirectory";
            try
            {
                // レジストリ・キーのパスを指定してレジストリを開く
                RegistryKey rKey = Registry.LocalMachine.OpenSubKey(rKeyName);

                // レジストリの値を取得
                ret = (string)rKey.GetValue(rGetValueName);

                // 開いたレジストリ・キーを閉じる
                rKey.Close();
            }
            catch (NullReferenceException)
            {
            }

            // ファイル名を取得できなかった場合はカレントディレクトリをセット
            if (string.IsNullOrEmpty(ret)) ret = System.IO.Directory.GetCurrentDirectory();

            return ret;
        }

        /// <summary>
        /// 簡単問合せ接続中のリストを取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns></returns>
        private static List<SimplInqCnectInfo> GetConnectionListProc(string enterpriseCode)
        {
            List<SimplInqCnectInfo> ret = new List<SimplInqCnectInfo>();
            string path = GetFilePath(enterpriseCode);

            if (System.IO.File.Exists(path))
            {
                try
                {
                    System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate);
                    try
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        object obj = bf.Deserialize(fs);
                        if (obj is List<SimplInqCnectInfo>)
                        {
                            ret = (List<SimplInqCnectInfo>)obj;
                        }
                        else if (obj is SimplInqCnectInfo)
                        {
                            ret.Add((SimplInqCnectInfo)obj);
                        }
                    }
                    finally
                    {
                        fs.Close();
                    }
                }
                catch
                {
                }
            }

            return ret;
        }

        /// <summary>
        /// 簡単問合せ接続情報の追加
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="cmtCnectInfoList">簡単問合せ接続情報リスト</param>
        private static int AddCMTCnectInfoProc(string enterpriseCode, List<SimplInqCnectInfo> cmtCnectInfoList)
        {
            List<SimplInqCnectInfo> list = GetConnectionListProc(enterpriseCode);
            List<SimplInqCnectInfo> addlist = new List<SimplInqCnectInfo>();

            if (list != null && list.Count > 0)
            {
                foreach (SimplInqCnectInfo info in cmtCnectInfoList)
                {
                    SimplInqCnectInfo find = list.Find(
                        delegate(SimplInqCnectInfo target)
                        {
                            if (( target.CashRegisterNo == info.CashRegisterNo ) &&
                                ( target.CustomerCode == info.CustomerCode )) return true;

                            return false;
                        });

                    // 一致するデータが無ければ追加対象
                    if (find == null) addlist.Add(info);
                }
            }
            else
            {
                list = new List<SimplInqCnectInfo>();
                addlist = cmtCnectInfoList;
            }

            if (addlist.Count > 0)
            {
                list.AddRange(addlist);
            }
            return SaveCMTCnectInfoProc(enterpriseCode, list);
        }

        /// <summary>
        /// 簡単問合せ接続情報の削除
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="cmtCnectInfoList">簡単問合せ接続情報リスト</param>
        private static int DeleteCMTCnectInfoProc(string enterpriseCode, List<SimplInqCnectInfo> cmtCnectInfoList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            List<SimplInqCnectInfo> list = GetConnectionListProc(enterpriseCode);

            List<SimplInqCnectInfo> delTargetList = new List<SimplInqCnectInfo>();

            if (list != null && list.Count > 0)
            {
                foreach (SimplInqCnectInfo info in cmtCnectInfoList)
                {
                    List<SimplInqCnectInfo> findlist = list.FindAll(
                        delegate(SimplInqCnectInfo target)
                        {
                            // 端末番号未指定時は全て削除対象
                            if (info.CashRegisterNo == 0) return true;

                            // 端末番号が一致する場合、得意先が一致するかパラメータの得意先がゼロの場合は削除対象
                            if (( target.CashRegisterNo == info.CashRegisterNo ) &&
                                ( target.CustomerCode == info.CustomerCode || info.CustomerCode == 0 )) return true;

                            return false;
                        });
                    if (findlist != null && findlist.Count > 0) delTargetList.AddRange(findlist);
                }
            }

            if (delTargetList.Count > 0)
            {
                foreach (SimplInqCnectInfo wkinfo in delTargetList)
                {
                    list.Remove(wkinfo);
                }
                status = SaveCMTCnectInfoProc(enterpriseCode, list);
            }

            return status;
        }

        /// <summary>
        /// 簡単問合せ接続情報の保存
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="list">簡単問合せ接続情報リスト</param>
        private static int SaveCMTCnectInfoProc(string enterpriseCode, List<SimplInqCnectInfo> list)
        {
            int status = 0;
            string path = GetFilePath(enterpriseCode);
            string dirName = System.IO.Path.GetDirectoryName(path);

            if (!System.IO.Directory.Exists(dirName))
            {
                System.IO.Directory.CreateDirectory(dirName);
            }

            if (System.IO.Directory.Exists(dirName))
            {
                try
                {
                    System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create);
                    try
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, (object)list);
                    }
                    finally
                    {
                        fs.Close();
                    }
                }
                catch
                {
                    status = -1;

                }
            }
            return status;
        }
        #endregion
    }
}
