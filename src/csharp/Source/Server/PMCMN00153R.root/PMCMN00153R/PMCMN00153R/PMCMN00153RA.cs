//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 環境調査
// プログラム概要   : 環境調査を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11670219-00 作成担当 : 佐々木亘
// 作 成 日  2020/06/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data;
using Broadleaf.Library.Resources;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Xml;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 環境調査DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 環境調査の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 佐々木亘</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>管理番号   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class EnvSurvObjDB : RemoteWithAppLockDB, IEnvSurvObjDB
    {

        #region 列挙体

        /// <summary>
        /// 環境調査の結果ステータス列挙体
        /// </summary>
        private enum StatusCode
        {
            /// <summary>成功</summary>
            Normal = 0
          , /// <summary>価格マスタ取得</summary>
            MstGet = 2000
          , /// <summary>DataTable展開</summary>
            DataTableDeploy = 2010
          , /// <summary>DataTable変換</summary>
            DataTableConv = 2020
          , /// <summary>一時テーブル作成</summary>
            TempTableCreate = 2030
          , /// <summary>一時テーブル登録</summary>
            TempTableIns = 2040
          , /// <summary>マスタ更新</summary>
            MstUpd = 2050
          , /// <summary>バージョン管理マスタ更新</summary>
            VerObjMstUpd = 2100
          , /// <summary>例外エラー(3000)</summary>
            Error3000 = 3000
          , /// <summary>例外エラー(3001)</summary>
            Error3001 = 3001
          , /// <summary>例外エラー(3002)</summary>
            Error3002 = 3002
          , /// <summary>例外エラー(3003)</summary>
            Error3003 = 3003
          , /// <summary>例外エラー(3004)</summary>
            Error3004 = 3004
        };

        #endregion //列挙体

        #region 定数

        /// <summary>
        /// DB名
        /// </summary>
        private const string PMUSERDBName = "PM_USER_DB";

        /// <summary>
        /// 環境調査処理で例外が発生しました。
        /// </summary>
        private const string ErrorTextUpdateProcFaild = "環境調査処理処理で例外が発生しました。";

        /// <summary>
        /// 設定ファイル名
        /// </summary>
        private const string XML_FILE_NAME = "PMCMN00153R_Setting.xml";

        /// <summary>
        /// タイムアウト初期値（秒）
        /// </summary>
        private const int TIMEOUT_DEFAULT_TIME = 1800;

        #endregion //定数

        #region プライベートフィールド

        /// <summary>
        /// タイムアウト
        /// </summary>
        private int _timeOut;

        /// <summary>
        /// 共通
        /// </summary>
        private static EnvSurvCommn esc = null;

        #endregion //プライベートフィールド

        #region コンストラクタ

        /// <summary>
        /// 環境調査リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public EnvSurvObjDB()
            : base("PMCMN00155D", "Broadleaf.Application.Remoting.ParamData.EnvSurvObjWork", "ENVSURVOBJRF")
        {
            #region タイムアウト

            // タイムアウト初期値
            _timeOut = TIMEOUT_DEFAULT_TIME;

            string fileName = this.InitializeXmlSettings();

            if (fileName != string.Empty)
            {
                XmlReaderSettings settings = new XmlReaderSettings();

                try
                {
                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            if (reader.IsStartElement("Timeout"))
                            {
                                _timeOut = reader.ReadElementContentAsInt();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //ログ出力
                    base.WriteErrorLog(ex, "EnvSurvObjDB.EnvSurvObjDB XMLReader");
                }
            }
            #endregion // タイムアウト

        }
        #endregion //コンストラクタ

        #region IEnvSurvObjDB メンバ

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → EnvFullBackupInfWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>EnvSurvObjWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private EnvFullBackupInfWork CopyToEnvFullBackupInfWorkReader(ref SqlDataReader myReader)
        {
            EnvFullBackupInfWork envFullBackupInfWork = new EnvFullBackupInfWork();

            this.CopyToEnvFullBackupInfWorkFromReader(ref myReader, ref envFullBackupInfWork);

            return envFullBackupInfWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → EnvFullBackupInfWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="envFullBackupInfWork">EnvFullBackupInfWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private void CopyToEnvFullBackupInfWorkFromReader(ref SqlDataReader myReader, ref EnvFullBackupInfWork envFullBackupInfWork)
        {
            if (myReader != null && envFullBackupInfWork != null)
            {
                # region クラスへ格納
                envFullBackupInfWork.DatabaseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BS_DATABASE_NAME"));
                envFullBackupInfWork.PhysicalDeviceName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BMF_PHYSICAL_DEVICE_NAME"));
                envFullBackupInfWork.BackupStartDate = SqlDataMediator.SqlGetDateTime(myReader, myReader.GetOrdinal("BS_BACKUP_START_DATE"));
                envFullBackupInfWork.BackupFinishDate = SqlDataMediator.SqlGetDateTime(myReader, myReader.GetOrdinal("BS_BACKUP_FINISH_DATE"));
                if (myReader.IsDBNull(myReader.GetOrdinal("BS_BACKUP_SIZE")))
                {
                    envFullBackupInfWork.BackupSize = (double)0.0;
                }
                else
                {
                    envFullBackupInfWork.BackupSize = (double)myReader.GetDecimal(myReader.GetOrdinal("BS_BACKUP_SIZE"));
                }
                envFullBackupInfWork.BackupType = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BS_TYPE"));
                envFullBackupInfWork.ServerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BS_SERVER_NAME"));
                envFullBackupInfWork.MachineName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BS_MACHINE_NAME"));
                # endregion
            }
        }

        # endregion // [クラス格納処理]

        #region EnvFullBackupInfSearch
        /// <summary>
        /// 全体バックアップ情報取得
        /// </summary>
        /// <param name="envFullBackupInf">全体バックアップ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 環境調査</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public int EnvFullBackupInfSearch(out object envFullBackupInf)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList envFullBackupInfList = null;

            envFullBackupInf = new CustomSerializeArrayList();

            status = EnvFullBackupInfSearchProc(out envFullBackupInfList);

            if (envFullBackupInfList != null && envFullBackupInfList.Count != 0)
            {
                (envFullBackupInf as CustomSerializeArrayList).AddRange(envFullBackupInfList);
            }

            return status;
        }

        /// <summary>
        /// 全体バックアップ情報取得
        /// </summary>
        /// <param name="envFullBackupInfList">全体バックアップ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 環境調査</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private int EnvFullBackupInfSearchProc(out ArrayList envFullBackupInfList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                StringBuilder sqlText = new StringBuilder();
                sqlText.Append("SELECT bs.database_name AS BS_DATABASE_NAME " + Environment.NewLine);
                sqlText.Append("    ,bmf.physical_device_name AS BMF_PHYSICAL_DEVICE_NAME " + Environment.NewLine);
                sqlText.Append("    ,bs.backup_start_date AS BS_BACKUP_START_DATE " + Environment.NewLine);
                sqlText.Append("    ,bs.backup_finish_date AS BS_BACKUP_FINISH_DATE " + Environment.NewLine);
                sqlText.Append("    ,bs.backup_size AS BS_BACKUP_SIZE " + Environment.NewLine);
                sqlText.Append("    ,bs.type AS BS_TYPE " + Environment.NewLine);
                sqlText.Append("    ,bs.server_name AS BS_SERVER_NAME " + Environment.NewLine);
                sqlText.Append("    ,bs.machine_name AS BS_MACHINE_NAME " + Environment.NewLine);
                sqlText.Append(" FROM msdb.dbo.backupmediafamily bmf " + Environment.NewLine);
                sqlText.Append(" INNER JOIN msdb.dbo.backupset bs ON bs.media_set_id  = bmf.media_set_id " + Environment.NewLine);
                sqlText.Append(" WHERE bs.database_name = @FINDDATABESENAME " + Environment.NewLine);
                sqlText.Append(" ORDER BY bs.backup_finish_date DESC " + Environment.NewLine);
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findParaDatabaseName = sqlCommand.Parameters.Add("@FINDDATABESENAME", SqlDbType.NChar);

                findParaDatabaseName.Value = SqlDataMediator.SqlSetString(PMUSERDBName);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    // 1件のみ
                    al.Add(this.CopyToEnvFullBackupInfWorkReader(ref myReader));
                }

                // 検索結果がある場合
                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "EnvSurvObjDB.EnvFullBackupInfSearchProc SqlException", status);

                if (esc == null)
                {
                    // 共通クラス
                    esc = new EnvSurvCommn();
                }
                esc.ClcLogOutput(String.Format("{0}:{1}", "ERR PMCMN00153RA EnvFullBackupInfSearchProc SqlException", sqlex.Message));

            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "EnvSurvObjDB.EnvFullBackupInfSearchProc", status);

                if (esc == null)
                {
                    // 共通クラス
                    esc = new EnvSurvCommn();
                }
                esc.ClcLogOutput(String.Format("{0}:{1}", "ERR PMCMN00153RA EnvFullBackupInfSearchProc Exception", ex.Message));
            }
            finally
            {
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
            }

            envFullBackupInfList = al;

            return status;
        }
        #endregion // EnvFullBackupInfSearch

        #region PriceMstInfCntSearch
        /// <summary>
        /// マスタ件数取得
        /// </summary>
        /// <param name="mstCount">マスタ件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 環境調査</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public int PriceMstInfCntSearch(out Int32 mstCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            status = PriceMstInfCntSearchProc(out mstCount);

            return status;
        }

        /// <summary>
        /// マスタ件数取得
        /// </summary>
        /// <param name="mstCount">マスタ件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 環境調査</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private int PriceMstInfCntSearchProc(out Int32 mstCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            mstCount = 0;

            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                StringBuilder sqlText = new StringBuilder();
                sqlText.Append("SELECT COUNT(*) " + Environment.NewLine);
                sqlText.Append(" FROM GOODSPRICEURF WITH (READUNCOMMITTED) " + Environment.NewLine);
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);
                myReader = sqlCommand.ExecuteReader();

                // 必ず取得結果1行となる
                if (myReader.Read())
                {
                    // 取得結果1列のみのため0列目を取得
                    mstCount = myReader.GetInt32(0);
                    if (mstCount > 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "EnvSurvObjDB.PriceMstInfCntSearchProc SqlException", status);

                if (esc == null)
                {
                    // 共通クラス
                    esc = new EnvSurvCommn();
                }
                esc.ClcLogOutput(String.Format("{0}:{1}", "ERR PMCMN00153RA PriceMstInfCntSearchProc SqlException", sqlex.Message));

            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "EnvSurvObjDB.PriceMstInfCntSearchProc", status);
                
                if (esc == null)
                {
                    // 共通クラス
                    esc = new EnvSurvCommn();
                }
                esc.ClcLogOutput(String.Format("{0}:{1}", "ERR PMCMN00153RA PriceMstInfCntSearchProc Exception", ex.Message));

            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion // PriceMstInfCntSearch

        #region XMLファイル操作
        /// <summary>
        /// XMLファイル設定情報取得処理
        /// ファイルが存在しない場合は空文字を戻す
        /// </summary>
        /// <returns>フルパスファイル名</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// </remarks>
        private string InitializeXmlSettings()
        {
            string homeDir = string.Empty;
            string path = string.Empty;

            try
            {
                // カレントディレクトリ取得
                homeDir = this.GetCurrentDirectory();

                // ディレクトリ情報にXMLファイル名を連結
                path = Path.Combine(homeDir, XML_FILE_NAME);

                // ファイルが存在しない場合は空白にする
                if (!File.Exists(path))
                {
                    path = string.Empty;
                }
            }
            catch (Exception ex)
            {
                //ログ出力
                base.WriteErrorLog(ex, "EnvSurvObjDB.InitializeXmlSettings");
                if (esc == null)
                {
                    // 共通クラス
                    esc = new EnvSurvCommn();
                }
                esc.ClcLogOutput(String.Format("{0}:{1}", "ERR PMCMN00153RA InitializeXmlSettings Exception", ex.Message));
            }

            return path;
        }
        #endregion  //XMLファイル操作

        #region カレントフォルダ
        /// <summary>
        /// カレントフォルダのパス取得
        /// フォルダが存在しない場合は空文字を戻す
        /// </summary>
        /// <returns>フルパスファイル名</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defaultDir = string.Empty;
            string homeDir = string.Empty;

            // XML格納ディレクトリ取得
            try
            {
                // dll格納パスを初期ディレクトリとする
                defaultDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'); // 末尾の「\」は常になし

                // レジストリ情報よりUSER_APのキー情報を取得
                RegistryKey keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (keyForUSERAP == null)
                {
                    keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP");
                    if (keyForUSERAP == null)
                    {
                        // レジストリ情報を取得できない場合は初期ディレクトリ
                        // 運用上ありえないケース
                        homeDir = defaultDir;
                    }
                    else
                    {
                        homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                    }
                }
                else
                {
                    homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                }

                // 取得ディレクトリが存在しない場合は初期ディレクトリを設定
                // 運用上ありえないケース
                if (!Directory.Exists(homeDir))
                {
                    homeDir = defaultDir;
                }
            }
            catch (Exception ex)
            {
                //ログ出力
                base.WriteErrorLog(ex, "EnvSurvObjDB.GetCurrentDirectory");
                if (esc == null)
                {
                    // 共通クラス
                    esc = new EnvSurvCommn();
                }
                esc.ClcLogOutput(String.Format("{0}:{1}", "ERR PMCMN00153RA GetCurrentDirectory Exception", ex.Message));

                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }

            return homeDir;
        }
        #endregion // privateメソッド

        #endregion // IEnvSurvObjDB メンバ

    }


}
