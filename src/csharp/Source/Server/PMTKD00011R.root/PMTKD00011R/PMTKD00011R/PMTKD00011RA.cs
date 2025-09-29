using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;
using Microsoft.Win32;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ユーザーバージョンチェックDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : ユーザーバージョンチェック実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30350 櫻井 亮太</br>
    /// <br>Date       : 2009.01.23</br>
    /// <br></br>
    /// <br>Update Note: 提供DB統合対応</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2010/06/18</br>
    /// </remarks>
    [Serializable]
    public class VersionChkTkdWorkDB : RemoteWithAppLockDB, IVersionChkTKDWorkDB
    {
        /// <summary>
        /// ユーザーバージョンチェックDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2009.01.23</br>
        /// </remarks>
        public VersionChkTkdWorkDB()
        {
        }

        private string CurrentVersion = string.Empty;
        private string TargetVersion  = string.Empty;
        private string ErrorMessage   = string.Empty;
        private string MergedVersion  = string.Empty;
        private Int32 ErrorCode = 0;
        private int MergeCheckResult = 0;

        // -- ADD 2010/06/18 ----------------------------------->>>
        /// <summary>
        /// ユーザーDBのバージョン情報を返します
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2010/06/14</br>
        /// </remarks>
        public int VersionCheckDB(out string CurrentVersion, out string TargetVersion, out Int32 ErrorCode, out string ErrorMessage)
        {
            return VersionCheckDBProc(out CurrentVersion, out TargetVersion, out ErrorCode, out ErrorMessage);
        }
        // -- ADD 2010/06/18 -----------------------------------<<<

        /// <summary>
        /// ユーザーDBのバージョン情報を返します
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2009.01.23</br>
        /// </remarks>
        // -- UPD 2010/06/14 ------------------------------------------>>>
        //public int VersionCheckDB(out string CurrentVersion, out string TargetVersion, out Int32 ErrorCode, out string ErrorMessage)
        private int VersionCheckDBProc(out string CurrentVersion, out string TargetVersion, out Int32 ErrorCode, out string ErrorMessage)
        // -- UPD 2010/06/14 ------------------------------------------<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            CurrentVersion = string.Empty;
            TargetVersion = string.Empty;
            ErrorMessage = string.Empty;
            ErrorCode = 0;
            MergeCheckResult = 0;

            SqlConnection retSqlConnection = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            // -- DEL 2010/06/18 ------------------------------------->>>
            //string ServerCode = ConstantManagement_SF_PRO.ServerCode_OfferAP;
            //string IndexCode = ConstantManagement_SF_PRO.IndexCode_OfferDB;
            //string ProductCode = ConstantManagement_SF_PRO.ProductCode;
            // -- DEL 2010/06/18 -------------------------------------<<<
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);

            retSqlConnection = new SqlConnection(connectionText);
            string coon = retSqlConnection.DataSource;
            //retSqlConnection.Open();   // DEL 2010/06/18

            SqlDataReader myReader = null;  // ADD 2010/06/18
            SqlCommand sqlCommand = null;   // ADD 2010/06/18
            try
            {
                retSqlConnection.Open();   // ADD 2010/06/18

                // -- UPD 2010/06/18 ---------------------------------------------->>>
                //// APとDBが同居
                //status = GetDBServerRegistryValue(ProductCode, ServerCode, IndexCode, out CurrentVersion, out TargetVersion, out ErrorCode, out ErrorMessage);
                //if (status == -9)
                //{
                //    // APとDBが別居
                //    status = GetDBServerShareRegistryValue(ProductCode, ServerCode, IndexCode, coon, out CurrentVersion, out TargetVersion, out ErrorCode, out ErrorMessage);
                //}

                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, retSqlConnection);

                sqlText += " SELECT " + Environment.NewLine;
                sqlText += "  MAX(OFFERVERSIONRF) AS OFFERVERSION " + Environment.NewLine;
                sqlText += " FROM DATAVERMNGOFFRF " + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    CurrentVersion = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFERVERSION"));
                }
                // -- UPD 2010/06/18 ----------------------------------------------<<<

            }
            // -- UPD 2010/06/18 ------------------------>>>
            //catch
            //{
            //}
            catch(SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            // -- UPD 2010/06/18 ------------------------<<<
            finally
            {
                // -- ADD 2010/06/18 -------------------->>>
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                // -- ADD 2010/06/18 --------------------<<<

                if (retSqlConnection != null)
                {
                    retSqlConnection.Close();
                    retSqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// ユーザーAPのバージョン情報を返します
        /// </summary>
        /// <remarks>
        /// <br>Note       : APサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2009.01.23</br>
        /// </remarks>
        public int VersionCheckAP(out string CurrentVersion, out string TargetVersion, out Int32 ErrorCode, out string ErrorMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            CurrentVersion = string.Empty;
            TargetVersion  = string.Empty;
            ErrorMessage   = string.Empty;
            ErrorCode = 0;
            MergeCheckResult = 0;

            string ServerCode  = ConstantManagement_SF_PRO.ServerCode_OfferAP;
            string ProductCode = ConstantManagement_SF_PRO.ProductCode;

            // APのみ
            status = GetAPServerVersion(ProductCode, ServerCode, out CurrentVersion, out TargetVersion, out ErrorCode, out ErrorMessage, out MergedVersion);

            return status;
        }

        /// <summary>
        /// APバージョン取得
        /// </summary>
        /// <remarks>
        /// <param name="productCode">製品コード</param>
        /// <param name="serverCode">サーバーコード</param>
        /// </remarks>
        public int GetAPServerVersion(string productCode, string serverCode, out string CurrentVersion, out string TargetVersion, out Int32 ErrorCode, out string ErrorMessage, out string MergedVersion)
        {
            int ret = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int _requiredServerVersion = 0;
            // 操作するレジストリ・キーの名前
            string rKeyName = @String.Format("SOFTWARE\\Broadleaf\\Service\\{0}\\{1}", productCode, serverCode);
            // 取得処理を行う対象となるレジストリの値の名前
            string rGetValueName = "RequiredServerVersion";

            CurrentVersion = "";
            TargetVersion  = "";
            ErrorCode = 0;
            ErrorMessage   = "";
            MergedVersion  = "";

            // レジストリの取得
            try
            {
                // レジストリ・キーのパスを指定してレジストリを開く
                RegistryKey rKey = Registry.LocalMachine.OpenSubKey(rKeyName);

                // レジストリの値を取得
                CurrentVersion = (string)rKey.GetValue("CurrentVersion", "");
                if (CurrentVersion != "")
                {
                    TargetVersion = (string)rKey.GetValue("TargetVersion", "");
                    ErrorCode = (Int32)rKey.GetValue("ErrorCode", 0);
                    ErrorMessage = (string)rKey.GetValue("ErrorMessage", "");
                    MergedVersion = (string)rKey.GetValue("MergedVersion", "");
                    ret = 0;
                }

                // 開いたレジストリ・キーを閉じる
                rKey.Close();
                return ret;
            }
            catch (NullReferenceException)
            {
                if (CurrentVersion != "")
                    return 0;
                else
                    return -9;
            }
        }

        /// <summary>
        /// DBServerShareレジストリ情報取得(Share) 
        /// </summary>
        /// <param name="ProductCode">プロダクトコード</param>
        /// <param name="ServiceCode">サービス USER_AP等</param>
        /// <param name="IndexCode">インデックスコード USER_DB等</param>
        /// <param name="conn">接続文字列</param>
        /// <returns>レジストリ値</returns>
        private int GetDBServerShareRegistryValue(string ProductCode, string ServiceCode, string IndexCode, string conn, out string CurrentVersion, out string TargetVersion, out Int32 ErrorCode, out string ErrorMessage)
        {
            int ret = -9;

            // 操作するレジストリ・キーの名前
            string rKeyName = @String.Format(@"SOFTWARE\Broadleaf\Service\{0}\{1}\share\{2}\{3}", ProductCode, ServiceCode, IndexCode, conn);

            CurrentVersion = "";
            TargetVersion  = "";
            ErrorCode = 0;
            ErrorMessage   = "";

            // レジストリの取得
            try
            {
                // レジストリ・キーのパスを指定してレジストリを開く
                RegistryKey rKey = Registry.LocalMachine.OpenSubKey(rKeyName);
                // レジストリの値を取得
                CurrentVersion = (string)rKey.GetValue("CurrentVersion", "");
                if (CurrentVersion != "")
                {
                    TargetVersion  = (string)rKey.GetValue("TargetVersion", "");
                    ErrorCode      = (Int32)rKey.GetValue("ErrorCode", 0);
                    ErrorMessage   = (string)rKey.GetValue("ErrorMessage", "");
                    ret = 0;
                }
                rKey.Close();
                // 取得したレジストリの値を戻す(0～)
                return ret;
            }
            catch (NullReferenceException)
            {
                if (CurrentVersion != "")
                    return 0;
                else
                    return -9;
            }
        }



        /// <summary>
        /// DBServerレジストリ情報取得(localhost)
        /// </summary>
        /// <param name="ProductCode">プロダクトコード</param>
        /// <param name="ServiceCode">サービス USER_AP等</param>
        /// <param name="IndexCode">インデックスコード USER_DB等</param>
        /// <returns>レジストリ値</returns>
        private int GetDBServerRegistryValue(string ProductCode, string ServiceCode, string IndexCode, out string CurrentVersion, out string TargetVersion, out Int32 ErrorCode, out string ErrorMessage)
        {
            int ret = -9;
            // 操作するレジストリ・キーの名前
            string rKeyName = @String.Format(@"SOFTWARE\Broadleaf\Service\{0}\{1}\localhost\{2}", ProductCode, ServiceCode, IndexCode);

            CurrentVersion = "";
            TargetVersion  = "";
            ErrorCode = 0;
            ErrorMessage   = "";

            // レジストリの取得
            try
            {
                RegistryKey reg_key = Registry.LocalMachine.OpenSubKey(rKeyName);

                // レジストリ・キーのパスを指定してレジストリを開く
                RegistryKey rKey = Registry.LocalMachine.OpenSubKey(rKeyName);
                // レジストリの値を取得
                CurrentVersion = (string)rKey.GetValue("CurrentVersion", "");
                if (CurrentVersion != "")
                {
                    TargetVersion  = (string)rKey.GetValue("TargetVersion", "");
                    ErrorCode      = (Int32)rKey.GetValue("ErrorCode", 0);
                    ErrorMessage   = (string)rKey.GetValue("ErrorMessage", "");
                    ret = 0;
                }
                // 開いたレジストリ・キーを閉じる
                rKey.Close();
                // 取得したレジストリの値を戻す
                return ret;
            }
            catch (NullReferenceException)
            {
                if (CurrentVersion != "")
                    return 0;
                else
                    return -9;
            }
        }
    }
}