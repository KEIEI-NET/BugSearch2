//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 受注マスタ(車両)DBリモートオブジェクト
// プログラム概要   : 受注マスタ(車両)DBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10902622-01 作成担当 : huangt
// 作 成 日  2013/05/30  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 修正内容　ソースチェック確認事項一覧にNo.12の対応 
// 管理番号  10902622-01 作成担当 : huangt
// 作 成 日  2013/06/11  作成内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 受注マスタ(車両)DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 受注マスタ(車両)の実データ操作を行うクラスです。</br>
    /// <br>Programmer : huangt</br>
    /// <br>Date       : 2013/05/30</br>
    /// </remarks>
    [Serializable]
    public class PmTabAcpOdrCarDB : RemoteWithAppLockDB, IPmTabAcpOdrCarDB
    {

        /// <summary>
        /// 受注マスタ(車両)DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        /// </remarks>
        public PmTabAcpOdrCarDB()
            //: base("PMJUT01813D", "Broadleaf.Application.Remoting.ParamData.PmTabAcpOdrCarWork", "PmTabAcpOdrCarRF")      // DEL huangt 2013/06/11 ソースチェック確認事項一覧にNo.12の対応
            : base("PMTAB00176D", "Broadleaf.Application.Remoting.ParamData.PmTabAcpOdrCarWork", "PmTabAcpOdrCarRF")        // ADD huangt 2013/06/11 ソースチェック確認事項一覧にNo.12の対応
        {
        }

        # region [Read]
        /// <summary>
        /// 単一の受注マスタ(車両)情報を取得します。
        /// </summary>
        /// <param name="pmTabAcpOdrCarObj">PmTabAcpOdrCarWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ(車両)のキー値が一致する受注マスタ(車両)情報を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        public int Read(ref object pmTabAcpOdrCarObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                PmTabAcpOdrCarWork pmTabAcpOdrCarWork = pmTabAcpOdrCarObj as PmTabAcpOdrCarWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref pmTabAcpOdrCarWork, readMode, sqlConnection, sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 単一の受注マスタ(車両)情報を取得します。
        /// </summary>
        /// <param name="pmTabAcpOdrCarWork">PmTabAcpOdrCarWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ(車両)のキー値が一致する受注マスタ(車両)情報を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        public int Read(ref PmTabAcpOdrCarWork pmTabAcpOdrCarWork, int readMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref pmTabAcpOdrCarWork, readMode, sqlConnection, sqlTransaction);
        }

        // 2009/05/28 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 受注マスタ(車両)情報リストを取得します。
        /// </summary>
        /// <param name="pmTabAcpOdrCarObj">抽出条件リスト(PmTabAcpOdrCarWork)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ(車両)のキー値が一致する受注マスタ(車両)情報を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        public int ReadAll(ref object pmTabAcpOdrCarObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList paraList = pmTabAcpOdrCarObj as ArrayList;
                ArrayList pmTabAcpOdrCarList = new ArrayList();

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.ReadAll(ref pmTabAcpOdrCarList, paraList, sqlConnection, sqlTransaction);

                pmTabAcpOdrCarObj = pmTabAcpOdrCarList;

            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 単一の受注マスタ(車両)情報を取得します。
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">抽出結果リスト(PmTabAcpOdrCarWork)</param>
        /// <param name="paraList">抽出条件リスト(PmTabAcpOdrCarWork)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ(車両)のキー値が一致する受注マスタ(車両)情報を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        public int ReadAll(ref ArrayList pmTabAcpOdrCarList, ArrayList paraList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            foreach (PmTabAcpOdrCarWork pmTabAcpOdrCarWork in paraList)
            {
                PmTabAcpOdrCarWork pararetWork = pmTabAcpOdrCarWork;

                status = this.ReadProc(ref pararetWork, 0, sqlConnection, sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    pmTabAcpOdrCarList.Add(pararetWork);
                }
                else
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND && status != (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        return status;
                    }
            }

            //件数の有無は関係無しで異常系以外はノーマルとする
            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            return status;
        }
        // 2009/05/28 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 単一の受注マスタ(車両)情報を取得します。
        /// </summary>
        /// <param name="pmTabAcpOdrCarWork">PmTabAcpOdrCarWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ(車両)のキー値が一致する受注マスタ(車両)情報を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        private int ReadProc(ref PmTabAcpOdrCarWork pmTabAcpOdrCarWork, int readMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CREATEDATETIMERF " + Environment.NewLine;      // 作成日時
                sqlText += " ,UPDATEDATETIMERF " + Environment.NewLine;      // 更新日時
                sqlText += " ,ENTERPRISECODERF " + Environment.NewLine;      // 企業コード
                sqlText += " ,FILEHEADERGUIDRF " + Environment.NewLine;      // GUID
                sqlText += " ,UPDEMPLOYEECODERF " + Environment.NewLine;     // 更新従業員コード
                sqlText += " ,UPDASSEMBLYID1RF " + Environment.NewLine;      // 更新アセンブリID1
                sqlText += " ,UPDASSEMBLYID2RF " + Environment.NewLine;      // 更新アセンブリID2
                sqlText += " ,LOGICALDELETECODERF " + Environment.NewLine;   // 論理削除区分
                sqlText += " ,BUSINESSSESSIONIDRF " + Environment.NewLine;	 // 業務セッションID
                sqlText += " ,SEARCHSECTIONCODERF " + Environment.NewLine;   // 検索拠点コード
                sqlText += " ,PMTABDTLDISCGUIDRF " + Environment.NewLine;    // PMTAB明細識別GUID
                sqlText += " ,DATADELETEDATERF " + Environment.NewLine;      // データ削除予定日
                sqlText += " ,ACCEPTANORDERNORF " + Environment.NewLine;     // 受注番号
                sqlText += " ,ACPTANODRSTATUSRF " + Environment.NewLine;     // 受注ステータス
                sqlText += " ,DATAINPUTSYSTEMRF " + Environment.NewLine;     // データ入力システム
                sqlText += " ,CARMNGNORF " + Environment.NewLine;            // 車両管理番号
                sqlText += " ,CARMNGCODERF " + Environment.NewLine;          // 車輌管理コード
                sqlText += " ,NUMBERPLATE1CODERF " + Environment.NewLine;    // 陸運事務所番号
                sqlText += " ,NUMBERPLATE1NAMERF " + Environment.NewLine;    // 陸運事務局名称
                sqlText += " ,NUMBERPLATE2RF " + Environment.NewLine;        // 車両登録番号（種別）
                sqlText += " ,NUMBERPLATE3RF " + Environment.NewLine;        // 車両登録番号（カナ）
                sqlText += " ,NUMBERPLATE4RF " + Environment.NewLine;        // 車両登録番号（プレート番号）
                sqlText += " ,FIRSTENTRYDATERF " + Environment.NewLine;      // 初年度
                sqlText += " ,MAKERCODERF " + Environment.NewLine;	         // メーカーコード
                sqlText += " ,MAKERFULLNAMERF " + Environment.NewLine;       // メーカー全角名称
                sqlText += " ,MAKERHALFNAMERF " + Environment.NewLine;       // メーカー半角名称
                sqlText += " ,MODELCODERF " + Environment.NewLine;           // 車種コード
                sqlText += " ,MODELSUBCODERF " + Environment.NewLine;        // 車種サブコード
                sqlText += " ,MODELFULLNAMERF " + Environment.NewLine;       // 車種全角名称
                sqlText += " ,MODELHALFNAMERF " + Environment.NewLine;       // 車種半角名称
                sqlText += " ,EXHAUSTGASSIGNRF " + Environment.NewLine;      // 排ガス記号
                sqlText += " ,SERIESMODELRF " + Environment.NewLine;         // シリーズ型式
                sqlText += " ,CATEGORYSIGNMODELRF " + Environment.NewLine;   // 型式（類別記号）
                sqlText += " ,FULLMODELRF " + Environment.NewLine;           // 型式（フル型）
                sqlText += " ,MODELDESIGNATIONNORF " + Environment.NewLine;  // 型式指定番号
                sqlText += " ,CATEGORYNORF " + Environment.NewLine;          // 類別番号
                sqlText += " ,FRAMEMODELRF " + Environment.NewLine;          // 車台型式
                sqlText += " ,FRAMENORF " + Environment.NewLine;             // 車台番号
                sqlText += " ,SEARCHFRAMENORF " + Environment.NewLine;       // 車台番号（検索用）
                sqlText += " ,ENGINEMODELNMRF " + Environment.NewLine;       // エンジン型式名称
                sqlText += " ,RELEVANCEMODELRF " + Environment.NewLine;      // 関連型式
                sqlText += " ,SUBCARNMCDRF " + Environment.NewLine;          // サブ車名コード
                sqlText += " ,MODELGRADESNAMERF " + Environment.NewLine;     // 型式グレード略称
                sqlText += " ,COLORCODERF " + Environment.NewLine;           // カラーコード
                sqlText += " ,COLORNAME1RF " + Environment.NewLine;          // カラー名称1
                sqlText += " ,TRIMCODERF " + Environment.NewLine;            // トリムコード
                sqlText += " ,TRIMNAMERF " + Environment.NewLine;            // トリム名称
                sqlText += " ,MILEAGERF " + Environment.NewLine;             // 車両走行距離
                sqlText += " ,FULLMODELFIXEDNOARYRF " + Environment.NewLine; // フル型式固定番号配列
                sqlText += " ,CATEGORYOBJARYRF " + Environment.NewLine;      // 装備オブジェクト配列
                sqlText += " ,CARNOTERF " + Environment.NewLine;             // 車輌備考
                sqlText += " ,FREESRCHMDLFXDNOARYRF " + Environment.NewLine; // 自由検索型式固定番号配列
                sqlText += " ,DOMESTICFOREIGNCODERF " + Environment.NewLine;// 国産／外車区分
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  PMTABACPODRCARRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND SEARCHSECTIONCODERF = @FINDSEARCHSECTIONCODE" + Environment.NewLine;
                sqlText += "  AND BUSINESSSESSIONIDRF = @FINDBUSINESSSESSIONID" + Environment.NewLine;

                // PMTAB明細識別GUID
                if (pmTabAcpOdrCarWork.PmTabDtlDiscGuid != "")
                {
                    sqlText += "  AND PMTABDTLDISCGUIDRF = @FINDPMTABDTLDISCGUID" + Environment.NewLine;
                    SqlParameter findPmTabDtlDiscGuid = sqlCommand.Parameters.Add("@FINDPMTABDTLDISCGUID", SqlDbType.NChar);
                    findPmTabDtlDiscGuid.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.PmTabDtlDiscGuid);
                }
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameterオブジェクトの作成
                sqlCommand.Parameters.Clear();
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findSearchSectionCode = sqlCommand.Parameters.Add("@FINDSEARCHSECTIONCODE", SqlDbType.NChar);
                SqlParameter findBusinessSessionId = sqlCommand.Parameters.Add("@FINDBUSINESSSESSIONID", SqlDbType.NChar);

                // Parameterオブジェクトへ値設定
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.EnterpriseCode);
                findSearchSectionCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.SearchSectionCode);
                findBusinessSessionId.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.BusinessSessionId);

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToPmTabAcpOdrCarWorkFromReader(ref myReader, ref pmTabAcpOdrCarWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

            return status;
        }
        # endregion

        # region [Delete]
        /// <summary>
        /// 受注マスタ(車両)情報を物理削除します
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">物理削除する受注マスタ(車両)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ(車両)のキー値が一致する受注マスタ(車両)情報を物理削除します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        public int Delete(object pmTabAcpOdrCarList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = pmTabAcpOdrCarList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.Delete(paraList, sqlConnection, sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// 受注マスタ(車両)情報を物理削除します
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">受注マスタ(車両)情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmTabAcpOdrCarList に格納されている受注マスタ(車両)情報を物理削除します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        public int Delete(ArrayList pmTabAcpOdrCarList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(pmTabAcpOdrCarList, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// 受注マスタ(車両)情報を物理削除します
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">受注マスタ(車両)情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmTabAcpOdrCarList に格納されている受注マスタ(車両)情報を物理削除します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        private int DeleteProc(ArrayList pmTabAcpOdrCarList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (pmTabAcpOdrCarList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < pmTabAcpOdrCarList.Count; i++)
                    {
                        PmTabAcpOdrCarWork pmTabAcpOdrCarWork = pmTabAcpOdrCarList[i] as PmTabAcpOdrCarWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  PMTABACPODRCARRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SEARCHSECTIONCODERF = @FINDSEARCHSECTIONCODE" + Environment.NewLine;
                        sqlText += "  AND BUSINESSSESSIONIDRF = @FINDBUSINESSSESSIONID" + Environment.NewLine;
                        sqlText += "  AND PMTABDTLDISCGUIDRF = @FINDPMTABDTLDISCGUID" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findSearchSectionCode = sqlCommand.Parameters.Add("@FINDSEARCHSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findBusinessSessionId = sqlCommand.Parameters.Add("@FINDBUSINESSSESSIONID", SqlDbType.NChar);
                        SqlParameter findPmTabDtlDiscGuid = sqlCommand.Parameters.Add("@FINDPMTABDTLDISCGUID", SqlDbType.NChar);

                        // Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.EnterpriseCode);
                        findSearchSectionCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.SearchSectionCode);
                        findBusinessSessionId.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.BusinessSessionId);
                        findPmTabDtlDiscGuid.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.PmTabDtlDiscGuid);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != pmTabAcpOdrCarWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  PMTABACPODRCARRF" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND SEARCHSECTIONCODERF = @FINDSEARCHSECTIONCODE" + Environment.NewLine;
                            sqlText += "  AND BUSINESSSESSIONIDRF = @FINDBUSINESSSESSIONID" + Environment.NewLine;
                            sqlText += "  AND PMTABDTLDISCGUIDRF = @FINDPMTABDTLDISCGUID" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.EnterpriseCode);
                            findSearchSectionCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.SearchSectionCode);
                            findBusinessSessionId.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.BusinessSessionId);
                            findPmTabDtlDiscGuid.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.PmTabDtlDiscGuid);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        sqlCommand.ExecuteNonQuery();
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

            return status;
        }
        # endregion

        # region [Search]
        /// <summary>
        /// 受注マスタ(車両)情報のリストを取得します。
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">検索結果</param>
        /// <param name="pmTabAcpOdrCarObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ(車両)のキー値が一致する、全ての受注マスタ(車両)情報を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        public int Search(ref object pmTabAcpOdrCarList, object pmTabAcpOdrCarObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList pmTabAcpOdrCarArray = pmTabAcpOdrCarList as ArrayList;
                PmTabAcpOdrCarWork pmTabAcpOdrCarWork = pmTabAcpOdrCarObj as PmTabAcpOdrCarWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref pmTabAcpOdrCarArray, pmTabAcpOdrCarWork, readMode, logicalMode, sqlConnection, sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 受注マスタ(車両)情報のリストを取得します。
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">受注マスタ(車両)情報を格納する ArrayList</param>
        /// <param name="pmTabAcpOdrCarWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ(車両)のキー値が一致する、全ての受注マスタ(車両)情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        public int Search(ref ArrayList pmTabAcpOdrCarList, PmTabAcpOdrCarWork pmTabAcpOdrCarWork, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref pmTabAcpOdrCarList, pmTabAcpOdrCarWork, readMode, logicalMode, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// 受注マスタ(車両)情報のリストを取得します。
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">受注マスタ(車両)情報を格納する ArrayList</param>
        /// <param name="pmTabAcpOdrCarWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ(車両)のキー値が一致する、全ての受注マスタ(車両)情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        private int SearchProc(ref ArrayList pmTabAcpOdrCarList, PmTabAcpOdrCarWork pmTabAcpOdrCarWork, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CREATEDATETIMERF " + Environment.NewLine;      // 作成日時
                sqlText += " ,UPDATEDATETIMERF " + Environment.NewLine;      // 更新日時
                sqlText += " ,ENTERPRISECODERF " + Environment.NewLine;      // 企業コード
                sqlText += " ,FILEHEADERGUIDRF " + Environment.NewLine;      // GUID
                sqlText += " ,UPDEMPLOYEECODERF " + Environment.NewLine;     // 更新従業員コード
                sqlText += " ,UPDASSEMBLYID1RF " + Environment.NewLine;      // 更新アセンブリID1
                sqlText += " ,UPDASSEMBLYID2RF " + Environment.NewLine;      // 更新アセンブリID2
                sqlText += " ,LOGICALDELETECODERF " + Environment.NewLine;   // 論理削除区分
                sqlText += " ,BUSINESSSESSIONIDRF " + Environment.NewLine;	 // 業務セッションID
                sqlText += " ,SEARCHSECTIONCODERF " + Environment.NewLine;   // 検索拠点コード
                sqlText += " ,PMTABDTLDISCGUIDRF " + Environment.NewLine;    // PMTAB明細識別GUID
                sqlText += " ,DATADELETEDATERF " + Environment.NewLine;      // データ削除予定日
                sqlText += " ,ACCEPTANORDERNORF " + Environment.NewLine;     // 受注番号
                sqlText += " ,ACPTANODRSTATUSRF " + Environment.NewLine;     // 受注ステータス
                sqlText += " ,DATAINPUTSYSTEMRF " + Environment.NewLine;     // データ入力システム
                sqlText += " ,CARMNGNORF " + Environment.NewLine;            // 車両管理番号
                sqlText += " ,CARMNGCODERF " + Environment.NewLine;          // 車輌管理コード
                sqlText += " ,NUMBERPLATE1CODERF " + Environment.NewLine;    // 陸運事務所番号
                sqlText += " ,NUMBERPLATE1NAMERF " + Environment.NewLine;    // 陸運事務局名称
                sqlText += " ,NUMBERPLATE2RF " + Environment.NewLine;        // 車両登録番号（種別）
                sqlText += " ,NUMBERPLATE3RF " + Environment.NewLine;        // 車両登録番号（カナ）
                sqlText += " ,NUMBERPLATE4RF " + Environment.NewLine;        // 車両登録番号（プレート番号）
                sqlText += " ,FIRSTENTRYDATERF " + Environment.NewLine;      // 初年度
                sqlText += " ,MAKERCODERF " + Environment.NewLine;	         // メーカーコード
                sqlText += " ,MAKERFULLNAMERF " + Environment.NewLine;       // メーカー全角名称
                sqlText += " ,MAKERHALFNAMERF " + Environment.NewLine;       // メーカー半角名称
                sqlText += " ,MODELCODERF " + Environment.NewLine;           // 車種コード
                sqlText += " ,MODELSUBCODERF " + Environment.NewLine;        // 車種サブコード
                sqlText += " ,MODELFULLNAMERF " + Environment.NewLine;       // 車種全角名称
                sqlText += " ,MODELHALFNAMERF " + Environment.NewLine;       // 車種半角名称
                sqlText += " ,EXHAUSTGASSIGNRF " + Environment.NewLine;      // 排ガス記号
                sqlText += " ,SERIESMODELRF " + Environment.NewLine;         // シリーズ型式
                sqlText += " ,CATEGORYSIGNMODELRF " + Environment.NewLine;   // 型式（類別記号）
                sqlText += " ,FULLMODELRF " + Environment.NewLine;           // 型式（フル型）
                sqlText += " ,MODELDESIGNATIONNORF " + Environment.NewLine;  // 型式指定番号
                sqlText += " ,CATEGORYNORF " + Environment.NewLine;          // 類別番号
                sqlText += " ,FRAMEMODELRF " + Environment.NewLine;          // 車台型式
                sqlText += " ,FRAMENORF " + Environment.NewLine;             // 車台番号
                sqlText += " ,SEARCHFRAMENORF " + Environment.NewLine;       // 車台番号（検索用）
                sqlText += " ,ENGINEMODELNMRF " + Environment.NewLine;       // エンジン型式名称
                sqlText += " ,RELEVANCEMODELRF " + Environment.NewLine;      // 関連型式
                sqlText += " ,SUBCARNMCDRF " + Environment.NewLine;          // サブ車名コード
                sqlText += " ,MODELGRADESNAMERF " + Environment.NewLine;     // 型式グレード略称
                sqlText += " ,COLORCODERF " + Environment.NewLine;           // カラーコード
                sqlText += " ,COLORNAME1RF " + Environment.NewLine;          // カラー名称1
                sqlText += " ,TRIMCODERF " + Environment.NewLine;            // トリムコード
                sqlText += " ,TRIMNAMERF " + Environment.NewLine;            // トリム名称
                sqlText += " ,MILEAGERF " + Environment.NewLine;             // 車両走行距離
                sqlText += " ,FULLMODELFIXEDNOARYRF " + Environment.NewLine; // フル型式固定番号配列
                sqlText += " ,CATEGORYOBJARYRF " + Environment.NewLine;      // 装備オブジェクト配列
                sqlText += " ,CARNOTERF " + Environment.NewLine;             // 車輌備考
                sqlText += " ,FREESRCHMDLFXDNOARYRF " + Environment.NewLine; // 自由検索型式固定番号配列
                sqlText += " ,DOMESTICFOREIGNCODERF " + Environment.NewLine;// 国産／外車区分
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  PMTABACPODRCARRF" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, pmTabAcpOdrCarWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    pmTabAcpOdrCarList.Add(this.CopyToPmTabAcpOdrCarWorkFromReader(ref myReader));
                }

                if (pmTabAcpOdrCarList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

            return status;
        }
        # endregion

        # region [Write]
        /// <summary>
        /// 受注マスタ(車両)情報を追加・更新します。
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">追加・更新する受注マスタ(車両)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmTabAcpOdrCarList に格納されている受注マスタ(車両)情報を追加・更新します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        public int Write(ref object pmTabAcpOdrCarList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = pmTabAcpOdrCarList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write実行
                status = this.Write(ref paraList, sqlConnection, sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 受注マスタ(車両)情報を追加・更新します。
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">追加・更新する受注マスタ(車両)情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmTabAcpOdrCarList に格納されている受注マスタ(車両)情報を追加・更新します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        public int Write(ref ArrayList pmTabAcpOdrCarList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref pmTabAcpOdrCarList, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// 受注マスタ(車両)情報を追加・更新します。
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">追加・更新する受注マスタ(車両)情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmTabAcpOdrCarList に格納されている受注マスタ(車両)情報を追加・更新します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        private int WriteProc(ref ArrayList pmTabAcpOdrCarList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (pmTabAcpOdrCarList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < pmTabAcpOdrCarList.Count; i++)
                    {
                        PmTabAcpOdrCarWork pmTabAcpOdrCarWork = pmTabAcpOdrCarList[i] as PmTabAcpOdrCarWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += " FROM" + Environment.NewLine;
                        sqlText += "  PMTABACPODRCARRF" + Environment.NewLine;
                        sqlText += " WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SEARCHSECTIONCODERF = @FINDSEARCHSECTIONCODE" + Environment.NewLine;
                        sqlText += "  AND BUSINESSSESSIONIDRF = @FINDBUSINESSSESSIONID" + Environment.NewLine;
                        sqlText += "  AND PMTABDTLDISCGUIDRF = @FINDPMTABDTLDISCGUID" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findSearchSectionCode = sqlCommand.Parameters.Add("@FINDSEARCHSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findBusinessSessionId = sqlCommand.Parameters.Add("@FINDBUSINESSSESSIONID", SqlDbType.NChar);
                        SqlParameter findPmTabDtlDiscGuid = sqlCommand.Parameters.Add("@FINDPMTABDTLDISCGUID", SqlDbType.NChar);

                        // Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.EnterpriseCode);
                        findSearchSectionCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.SearchSectionCode);
                        findBusinessSessionId.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.BusinessSessionId);
                        findPmTabDtlDiscGuid.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.PmTabDtlDiscGuid);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            pmTabAcpOdrCarWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // 作成日時
                            pmTabAcpOdrCarWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));               // GUID
                            # region [UPDATE文]

                            sqlText = string.Empty;
                            sqlText += " UPDATE PMTABACPODRCARRF" + Environment.NewLine;
                            sqlText += " SET " + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;      // 作成日時
                            sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;      // 更新日時
                            sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;      // 企業コード
                            sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;      // GUID
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;    // 更新従業員コード
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;      // 更新アセンブリID1
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;      // 更新アセンブリID2
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;     // 論理削除区分
                            sqlText += " ,BUSINESSSESSIONIDRF = @BUSINESSSESSIONID " + Environment.NewLine;	    // 業務セッションID
                            sqlText += " ,SEARCHSECTIONCODERF = @SEARCHSECTIONCODE " + Environment.NewLine;     // 検索拠点コード
                            sqlText += " ,PMTABDTLDISCGUIDRF = @PMTABDTLDISCGUID " + Environment.NewLine;       // PMTAB明細識別GUID
                            sqlText += " ,DATADELETEDATERF = @DATADELETEDATE " + Environment.NewLine;           // データ削除予定日
                            sqlText += " ,ACCEPTANORDERNORF = @ACCEPTANORDERNO " + Environment.NewLine;         // 受注番号
                            sqlText += " ,ACPTANODRSTATUSRF = @ACPTANODRSTATUS " + Environment.NewLine;         // 受注ステータス
                            sqlText += " ,DATAINPUTSYSTEMRF = @DATAINPUTSYSTEM " + Environment.NewLine;         // データ入力システム
                            sqlText += " ,CARMNGNORF = @CARMNGNO " + Environment.NewLine;                       // 車両管理番号
                            sqlText += " ,CARMNGCODERF = @CARMNGCODE " + Environment.NewLine;                   // 車輌管理コード
                            sqlText += " ,NUMBERPLATE1CODERF = @NUMBERPLATE1CODE " + Environment.NewLine;       // 陸運事務所番号
                            sqlText += " ,NUMBERPLATE1NAMERF = @NUMBERPLATE1NAME " + Environment.NewLine;       // 陸運事務局名称
                            sqlText += " ,NUMBERPLATE2RF = @NUMBERPLATE2 " + Environment.NewLine;               // 車両登録番号（種別）
                            sqlText += " ,NUMBERPLATE3RF = @NUMBERPLATE3 " + Environment.NewLine;               // 車両登録番号（カナ）
                            sqlText += " ,NUMBERPLATE4RF = @NUMBERPLATE4 " + Environment.NewLine;               // 車両登録番号（プレート番号）
                            sqlText += " ,FIRSTENTRYDATERF = @FIRSTENTRYDATE " + Environment.NewLine;           // 初年度
                            sqlText += " ,MAKERCODERF = @MAKERCODE " + Environment.NewLine;	                    // メーカーコード
                            sqlText += " ,MAKERFULLNAMERF = @MAKERFULLNAME " + Environment.NewLine;             // メーカー全角名称
                            sqlText += " ,MAKERHALFNAMERF = @MAKERHALFNAME " + Environment.NewLine;             // メーカー半角名称
                            sqlText += " ,MODELCODERF = @MODELCODE " + Environment.NewLine;                     // 車種コード
                            sqlText += " ,MODELSUBCODERF =@MODELSUBCODE " + Environment.NewLine;                // 車種サブコード
                            sqlText += " ,MODELFULLNAMERF = @MODELFULLNAME " + Environment.NewLine;             // 車種全角名称
                            sqlText += " ,MODELHALFNAMERF = @MODELHALFNAME " + Environment.NewLine;             // 車種半角名称
                            sqlText += " ,EXHAUSTGASSIGNRF = @EXHAUSTGASSIGN " + Environment.NewLine;           // 排ガス記号
                            sqlText += " ,SERIESMODELRF = @SERIESMODEL " + Environment.NewLine;                 // シリーズ型式
                            sqlText += " ,CATEGORYSIGNMODELRF = @CATEGORYSIGNMODEL " + Environment.NewLine;     // 型式（類別記号）
                            sqlText += " ,FULLMODELRF = @FULLMODEL " + Environment.NewLine;                     // 型式（フル型）
                            sqlText += " ,MODELDESIGNATIONNORF = @MODELDESIGNATIONNO " + Environment.NewLine;   // 型式指定番号
                            sqlText += " ,CATEGORYNORF = @CATEGORYNO " + Environment.NewLine;                   // 類別番号
                            sqlText += " ,FRAMEMODELRF = @FRAMEMODEL " + Environment.NewLine;                   // 車台型式
                            sqlText += " ,FRAMENORF = @FRAMENO " + Environment.NewLine;                         // 車台番号
                            sqlText += " ,SEARCHFRAMENORF = @SEARCHFRAMENO " + Environment.NewLine;             // 車台番号（検索用）
                            sqlText += " ,ENGINEMODELNMRF = @ENGINEMODELNM " + Environment.NewLine;             // エンジン型式名称
                            sqlText += " ,RELEVANCEMODELRF = @RELEVANCEMODEL " + Environment.NewLine;           // 関連型式
                            sqlText += " ,SUBCARNMCDRF = @SUBCARNMCD " + Environment.NewLine;                   // サブ車名コード
                            sqlText += " ,MODELGRADESNAMERF = @MODELGRADESNAME " + Environment.NewLine;         // 型式グレード略称
                            sqlText += " ,COLORCODERF = @COLORCODE " + Environment.NewLine;                     // カラーコード
                            sqlText += " ,COLORNAME1RF = @COLORNAME1 " + Environment.NewLine;                   // カラー名称1
                            sqlText += " ,TRIMCODERF = @TRIMCODE " + Environment.NewLine;                       // トリムコード
                            sqlText += " ,TRIMNAMERF = @TRIMNAME " + Environment.NewLine;                       // トリム名称
                            sqlText += " ,MILEAGERF = @MILEAGE " + Environment.NewLine;                         // 車両走行距離
                            sqlText += " ,FULLMODELFIXEDNOARYRF = @FULLMODELFIXEDNOARY " + Environment.NewLine; // フル型式固定番号配列
                            sqlText += " ,CATEGORYOBJARYRF = @CATEGORYOBJARY " + Environment.NewLine;           // 装備オブジェクト配列
                            sqlText += " ,CARNOTERF = @CARNOTE " + Environment.NewLine;                         // 車輌備考
                            sqlText += " ,FREESRCHMDLFXDNOARYRF = @FREESRCHMDLFXDNOARY " + Environment.NewLine; // 自由検索型式固定番号配列
                            sqlText += " ,DOMESTICFOREIGNCODERF = @DOMESTICFOREIGNCODE " + Environment.NewLine; // 国産／外車区分
                            sqlText += " WHERE " + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                            sqlText += "  AND SEARCHSECTIONCODERF = @FINDSEARCHSECTIONCODE " + Environment.NewLine;
                            sqlText += "  AND BUSINESSSESSIONIDRF = @FINDBUSINESSSESSIONID " + Environment.NewLine;
                            sqlText += "  AND PMTABDTLDISCGUIDRF = @FINDPMTABDTLDISCGUID " + Environment.NewLine;

                            #endregion

                            // KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.EnterpriseCode);
                            findSearchSectionCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.SearchSectionCode);
                            findBusinessSessionId.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.BusinessSessionId);
                            findPmTabDtlDiscGuid.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.PmTabDtlDiscGuid);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pmTabAcpOdrCarWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (pmTabAcpOdrCarWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            #region INSERT文

                            sqlText = string.Empty;
                            sqlText += "INSERT INTO PMTABACPODRCARRF" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF " + Environment.NewLine;      // 作成日時
                            sqlText += " ,UPDATEDATETIMERF " + Environment.NewLine;      // 更新日時
                            sqlText += " ,ENTERPRISECODERF " + Environment.NewLine;      // 企業コード
                            sqlText += " ,FILEHEADERGUIDRF " + Environment.NewLine;      // GUID
                            sqlText += " ,UPDEMPLOYEECODERF " + Environment.NewLine;     // 更新従業員コード
                            sqlText += " ,UPDASSEMBLYID1RF " + Environment.NewLine;      // 更新アセンブリID1
                            sqlText += " ,UPDASSEMBLYID2RF " + Environment.NewLine;      // 更新アセンブリID2
                            sqlText += " ,LOGICALDELETECODERF " + Environment.NewLine;   // 論理削除区分
                            sqlText += " ,BUSINESSSESSIONIDRF " + Environment.NewLine;	 // 業務セッションID
                            sqlText += " ,SEARCHSECTIONCODERF " + Environment.NewLine;   // 検索拠点コード
                            sqlText += " ,PMTABDTLDISCGUIDRF " + Environment.NewLine;    // PMTAB明細識別GUID
                            sqlText += " ,DATADELETEDATERF " + Environment.NewLine;      // データ削除予定日
                            sqlText += " ,ACCEPTANORDERNORF " + Environment.NewLine;     // 受注番号
                            sqlText += " ,ACPTANODRSTATUSRF " + Environment.NewLine;     // 受注ステータス
                            sqlText += " ,DATAINPUTSYSTEMRF " + Environment.NewLine;     // データ入力システム
                            sqlText += " ,CARMNGNORF " + Environment.NewLine;            // 車両管理番号
                            sqlText += " ,CARMNGCODERF " + Environment.NewLine;          // 車輌管理コード
                            sqlText += " ,NUMBERPLATE1CODERF " + Environment.NewLine;    // 陸運事務所番号
                            sqlText += " ,NUMBERPLATE1NAMERF " + Environment.NewLine;    // 陸運事務局名称
                            sqlText += " ,NUMBERPLATE2RF " + Environment.NewLine;        // 車両登録番号（種別）
                            sqlText += " ,NUMBERPLATE3RF " + Environment.NewLine;        // 車両登録番号（カナ）
                            sqlText += " ,NUMBERPLATE4RF " + Environment.NewLine;        // 車両登録番号（プレート番号）
                            sqlText += " ,FIRSTENTRYDATERF " + Environment.NewLine;      // 初年度
                            sqlText += " ,MAKERCODERF " + Environment.NewLine;	         // メーカーコード
                            sqlText += " ,MAKERFULLNAMERF " + Environment.NewLine;       // メーカー全角名称
                            sqlText += " ,MAKERHALFNAMERF " + Environment.NewLine;       // メーカー半角名称
                            sqlText += " ,MODELCODERF " + Environment.NewLine;           // 車種コード
                            sqlText += " ,MODELSUBCODERF " + Environment.NewLine;        // 車種サブコード
                            sqlText += " ,MODELFULLNAMERF " + Environment.NewLine;       // 車種全角名称
                            sqlText += " ,MODELHALFNAMERF " + Environment.NewLine;       // 車種半角名称
                            sqlText += " ,EXHAUSTGASSIGNRF " + Environment.NewLine;      // 排ガス記号
                            sqlText += " ,SERIESMODELRF " + Environment.NewLine;         // シリーズ型式
                            sqlText += " ,CATEGORYSIGNMODELRF " + Environment.NewLine;   // 型式（類別記号）
                            sqlText += " ,FULLMODELRF " + Environment.NewLine;           // 型式（フル型）
                            sqlText += " ,MODELDESIGNATIONNORF " + Environment.NewLine;  // 型式指定番号
                            sqlText += " ,CATEGORYNORF " + Environment.NewLine;          // 類別番号
                            sqlText += " ,FRAMEMODELRF " + Environment.NewLine;          // 車台型式
                            sqlText += " ,FRAMENORF " + Environment.NewLine;             // 車台番号
                            sqlText += " ,SEARCHFRAMENORF " + Environment.NewLine;       // 車台番号（検索用）
                            sqlText += " ,ENGINEMODELNMRF " + Environment.NewLine;       // エンジン型式名称
                            sqlText += " ,RELEVANCEMODELRF " + Environment.NewLine;      // 関連型式
                            sqlText += " ,SUBCARNMCDRF " + Environment.NewLine;          // サブ車名コード
                            sqlText += " ,MODELGRADESNAMERF " + Environment.NewLine;     // 型式グレード略称
                            sqlText += " ,COLORCODERF " + Environment.NewLine;           // カラーコード
                            sqlText += " ,COLORNAME1RF " + Environment.NewLine;          // カラー名称1
                            sqlText += " ,TRIMCODERF " + Environment.NewLine;            // トリムコード
                            sqlText += " ,TRIMNAMERF " + Environment.NewLine;            // トリム名称
                            sqlText += " ,MILEAGERF " + Environment.NewLine;             // 車両走行距離
                            sqlText += " ,FULLMODELFIXEDNOARYRF " + Environment.NewLine; // フル型式固定番号配列
                            sqlText += " ,CATEGORYOBJARYRF " + Environment.NewLine;      // 装備オブジェクト配列
                            sqlText += " ,CARNOTERF " + Environment.NewLine;             // 車輌備考
                            sqlText += " ,FREESRCHMDLFXDNOARYRF " + Environment.NewLine; // 自由検索型式固定番号配列
                            sqlText += " ,DOMESTICFOREIGNCODERF) " + Environment.NewLine;// 国産／外車区分
                            sqlText += "VALUES" + Environment.NewLine;
                            sqlText += "  (@CREATEDATETIME " + Environment.NewLine;      // 作成日時
                            sqlText += " ,@UPDATEDATETIME " + Environment.NewLine;       // 更新日時
                            sqlText += " ,@ENTERPRISECODE " + Environment.NewLine;       // 企業コード
                            sqlText += " ,@FILEHEADERGUID " + Environment.NewLine;       // GUID
                            sqlText += " ,@UPDEMPLOYEECODE " + Environment.NewLine;      // 更新従業員コード
                            sqlText += " ,@UPDASSEMBLYID1 " + Environment.NewLine;       // 更新アセンブリID1
                            sqlText += " ,@UPDASSEMBLYID2 " + Environment.NewLine;       // 更新アセンブリID2
                            sqlText += " ,@LOGICALDELETECODE " + Environment.NewLine;    // 論理削除区分
                            sqlText += " ,@BUSINESSSESSIONID " + Environment.NewLine;	 // 業務セッションID
                            sqlText += " ,@SEARCHSECTIONCODE " + Environment.NewLine;    // 検索拠点コード
                            sqlText += " ,@PMTABDTLDISCGUID " + Environment.NewLine;     // PMTAB明細識別GUID
                            sqlText += " ,@DATADELETEDATE " + Environment.NewLine;       // データ削除予定日
                            sqlText += " ,@ACCEPTANORDERNO " + Environment.NewLine;      // 受注番号
                            sqlText += " ,@ACPTANODRSTATUS " + Environment.NewLine;      // 受注ステータス
                            sqlText += " ,@DATAINPUTSYSTEM " + Environment.NewLine;      // データ入力システム
                            sqlText += " ,@CARMNGNO " + Environment.NewLine;             // 車両管理番号
                            sqlText += " ,@CARMNGCODE " + Environment.NewLine;           // 車輌管理コード
                            sqlText += " ,@NUMBERPLATE1CODE " + Environment.NewLine;     // 陸運事務所番号
                            sqlText += " ,@NUMBERPLATE1NAME " + Environment.NewLine;     // 陸運事務局名称
                            sqlText += " ,@NUMBERPLATE2 " + Environment.NewLine;         // 車両登録番号（種別）
                            sqlText += " ,@NUMBERPLATE3 " + Environment.NewLine;         // 車両登録番号（カナ）
                            sqlText += " ,@NUMBERPLATE4 " + Environment.NewLine;         // 車両登録番号（プレート番号）
                            sqlText += " ,@FIRSTENTRYDATE " + Environment.NewLine;       // 初年度
                            sqlText += " ,@MAKERCODE " + Environment.NewLine;	         // メーカーコード
                            sqlText += " ,@MAKERFULLNAME " + Environment.NewLine;        // メーカー全角名称
                            sqlText += " ,@MAKERHALFNAME " + Environment.NewLine;        // メーカー半角名称
                            sqlText += " ,@MODELCODE " + Environment.NewLine;            // 車種コード
                            sqlText += " ,@MODELSUBCODE " + Environment.NewLine;         // 車種サブコード
                            sqlText += " ,@MODELFULLNAME " + Environment.NewLine;        // 車種全角名称
                            sqlText += " ,@MODELHALFNAME " + Environment.NewLine;        // 車種半角名称
                            sqlText += " ,@EXHAUSTGASSIGN " + Environment.NewLine;       // 排ガス記号
                            sqlText += " ,@SERIESMODEL " + Environment.NewLine;          // シリーズ型式
                            sqlText += " ,@CATEGORYSIGNMODEL " + Environment.NewLine;    // 型式（類別記号）
                            sqlText += " ,@FULLMODEL " + Environment.NewLine;            // 型式（フル型）
                            sqlText += " ,@MODELDESIGNATIONNO " + Environment.NewLine;   // 型式指定番号
                            sqlText += " ,@CATEGORYNO " + Environment.NewLine;           // 類別番号
                            sqlText += " ,@FRAMEMODEL " + Environment.NewLine;           // 車台型式
                            sqlText += " ,@FRAMENO " + Environment.NewLine;              // 車台番号
                            sqlText += " ,@SEARCHFRAMENO " + Environment.NewLine;        // 車台番号（検索用）
                            sqlText += " ,@ENGINEMODELNM " + Environment.NewLine;        // エンジン型式名称
                            sqlText += " ,@RELEVANCEMODEL " + Environment.NewLine;       // 関連型式
                            sqlText += " ,@SUBCARNMCD " + Environment.NewLine;           // サブ車名コード
                            sqlText += " ,@MODELGRADESNAME " + Environment.NewLine;      // 型式グレード略称
                            sqlText += " ,@COLORCODE " + Environment.NewLine;            // カラーコード
                            sqlText += " ,@COLORNAME1 " + Environment.NewLine;           // カラー名称1
                            sqlText += " ,@TRIMCODE " + Environment.NewLine;             // トリムコード
                            sqlText += " ,@TRIMNAME " + Environment.NewLine;             // トリム名称
                            sqlText += " ,@MILEAGE " + Environment.NewLine;              // 車両走行距離
                            sqlText += " ,@FULLMODELFIXEDNOARY " + Environment.NewLine;  // フル型式固定番号配列
                            sqlText += " ,@CATEGORYOBJARY " + Environment.NewLine;       // 装備オブジェクト配列
                            sqlText += " ,@CARNOTE " + Environment.NewLine;              // 車輌備考
                            sqlText += " ,@FREESRCHMDLFXDNOARY " + Environment.NewLine;  // 自由検索型式固定番号配列
                            sqlText += " ,@DOMESTICFOREIGNCODE " + Environment.NewLine;  // 国産／外車区分
                            sqlText += ")" + Environment.NewLine;

                            #endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pmTabAcpOdrCarWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        sqlCommand.CommandText = sqlText;

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);                    // 作成日時
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);                    // 更新日時
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);                     // 企業コード
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);          // GUID
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);                   // 更新従業員コード
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);                  // 更新アセンブリID1
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);                  // 更新アセンブリID2
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);                 // 論理削除区分
                        SqlParameter paraBusinessSessionId = sqlCommand.Parameters.Add("@BUSINESSSESSIONID", SqlDbType.NChar);               // 業務セッションID
                        SqlParameter paraSearchSectionCode = sqlCommand.Parameters.Add("@SEARCHSECTIONCODE", SqlDbType.NChar);               // 検索拠点コード
                        SqlParameter paraPmTabDtlDiscGuid = sqlCommand.Parameters.Add("@PMTABDTLDISCGUID", SqlDbType.NChar);	     // PMTAB明細識別GUID
                        SqlParameter paraDataDeleteDate = sqlCommand.Parameters.Add("@DATADELETEDATE", SqlDbType.Int);                       // データ削除予定日
                        SqlParameter paraAcceptAnOrderNo = sqlCommand.Parameters.Add("@ACCEPTANORDERNO", SqlDbType.Int);                     // 受注番号
                        SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);                     // 受注ステータス
                        SqlParameter paraDataInputSystem = sqlCommand.Parameters.Add("@DATAINPUTSYSTEM", SqlDbType.Int);                     // データ入力システム
                        SqlParameter paraCarMngNo = sqlCommand.Parameters.Add("@CARMNGNO", SqlDbType.Int);                                   // 車両管理番号
                        SqlParameter paraCarMngCode = sqlCommand.Parameters.Add("@CARMNGCODE", SqlDbType.NVarChar);                          //車輌管理コード
                        SqlParameter paraNumberPlate1Code = sqlCommand.Parameters.Add("@NUMBERPLATE1CODE", SqlDbType.Int);                   // 陸運事務所番号
                        SqlParameter paraNumberPlate1Name = sqlCommand.Parameters.Add("@NUMBERPLATE1NAME", SqlDbType.NVarChar);              // 陸運事務局名称
                        SqlParameter paraNumberPlate2 = sqlCommand.Parameters.Add("@NUMBERPLATE2", SqlDbType.NVarChar);                      // 車両登録番号（種別）
                        SqlParameter paraNumberPlate3 = sqlCommand.Parameters.Add("@NUMBERPLATE3", SqlDbType.NVarChar);                      // 車両登録番号（カナ）
                        SqlParameter paraNumberPlate4 = sqlCommand.Parameters.Add("@NUMBERPLATE4", SqlDbType.Int);                           // 車両登録番号（プレート番号）
                        SqlParameter paraFirstEntryDate = sqlCommand.Parameters.Add("@FIRSTENTRYDATE", SqlDbType.Int);                       // 初年度
                        SqlParameter paraMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);                                 // メーカーコード
                        SqlParameter paraMakerFullName = sqlCommand.Parameters.Add("@MAKERFULLNAME", SqlDbType.NVarChar);                    // メーカー全角名称
                        SqlParameter paraMakerHalfName = sqlCommand.Parameters.Add("@MAKERHALFNAME", SqlDbType.NVarChar);                    // メーカー半角名称
                        SqlParameter paraModelCode = sqlCommand.Parameters.Add("@MODELCODE", SqlDbType.Int);                                 // 車種コード
                        SqlParameter paraModelSubCode = sqlCommand.Parameters.Add("@MODELSUBCODE", SqlDbType.Int);                           // 車種サブコード
                        SqlParameter paraModelFullName = sqlCommand.Parameters.Add("@MODELFULLNAME", SqlDbType.NVarChar);                    // 車種全角名称
                        SqlParameter paraModelHalfName = sqlCommand.Parameters.Add("@MODELHALFNAME", SqlDbType.NVarChar);                    // 車種半角名称
                        SqlParameter paraExhaustGasSign = sqlCommand.Parameters.Add("@EXHAUSTGASSIGN", SqlDbType.NVarChar);                  // 排ガス記号
                        SqlParameter paraSeriesModel = sqlCommand.Parameters.Add("@SERIESMODEL", SqlDbType.NVarChar);                        // シリーズ型式
                        SqlParameter paraCategorySignModel = sqlCommand.Parameters.Add("@CATEGORYSIGNMODEL", SqlDbType.NVarChar);            // 型式（類別記号）
                        SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FULLMODEL", SqlDbType.NVarChar);                            // 型式（フル型）
                        SqlParameter paraModelDesignationNo = sqlCommand.Parameters.Add("@MODELDESIGNATIONNO", SqlDbType.Int);               // 型式指定番号
                        SqlParameter paraCategoryNo = sqlCommand.Parameters.Add("@CATEGORYNO", SqlDbType.Int);                               // 類別番号
                        SqlParameter paraFrameModel = sqlCommand.Parameters.Add("@FRAMEMODEL", SqlDbType.NVarChar);                          // 車台型式
                        SqlParameter paraFrameNo = sqlCommand.Parameters.Add("@FRAMENO", SqlDbType.NVarChar);                                // 車台番号
                        SqlParameter paraSearchFrameNo = sqlCommand.Parameters.Add("@SEARCHFRAMENO", SqlDbType.Int);                         // 車台番号（検索用）
                        SqlParameter paraEngineModelNm = sqlCommand.Parameters.Add("@ENGINEMODELNM", SqlDbType.NVarChar);                    // エンジン型式名称
                        SqlParameter paraRelevanceModel = sqlCommand.Parameters.Add("@RELEVANCEMODEL", SqlDbType.NVarChar);                  // 関連型式
                        SqlParameter paraSubCarNmCd = sqlCommand.Parameters.Add("@SUBCARNMCD", SqlDbType.Int);                               // サブ車名コード
                        SqlParameter paraModelGradeSname = sqlCommand.Parameters.Add("@MODELGRADESNAME", SqlDbType.NVarChar);                // 型式グレード略称
                        SqlParameter paraColorCode = sqlCommand.Parameters.Add("@COLORCODE", SqlDbType.NVarChar);                            // カラーコード
                        SqlParameter paraColorName1 = sqlCommand.Parameters.Add("@COLORNAME1", SqlDbType.NVarChar);                          // カラー名称1
                        SqlParameter paraTrimCode = sqlCommand.Parameters.Add("@TRIMCODE", SqlDbType.NVarChar);                              // トリムコード
                        SqlParameter paraTrimName = sqlCommand.Parameters.Add("@TRIMNAME", SqlDbType.NVarChar);                              // トリム名称
                        SqlParameter paraMileage = sqlCommand.Parameters.Add("@MILEAGE", SqlDbType.Int);                                     // 車両走行距離
                        SqlParameter paraFullModelFixedNoAry = sqlCommand.Parameters.Add("@FULLMODELFIXEDNOARY", SqlDbType.VarBinary);       // フル型式固定番号配列
                        SqlParameter paraCategoryObjAry = sqlCommand.Parameters.Add("@CATEGORYOBJARY", SqlDbType.VarBinary);                 // 装備オブジェクト配列
                        SqlParameter paraCarNote = sqlCommand.Parameters.Add("@CARNOTE", SqlDbType.NVarChar);                                // 車輌備考
                        SqlParameter paraFreeSrchMdlFxdNoAry = sqlCommand.Parameters.Add("@FREESRCHMDLFXDNOARY", SqlDbType.VarBinary);       // 自由検索型式固定番号配列
                        SqlParameter paraDomesticForeignCode = sqlCommand.Parameters.Add("@DOMESTICFOREIGNCODE", SqlDbType.Int);             // 国産／外車区分
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmTabAcpOdrCarWork.CreateDateTime);        // 作成日時
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmTabAcpOdrCarWork.UpdateDateTime);        // 更新日時
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.EnterpriseCode);                   // 企業コード
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(pmTabAcpOdrCarWork.FileHeaderGuid);                     // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.UpdEmployeeCode);                 // 更新従業員コード
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.UpdAssemblyId1);                   // 更新アセンブリID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.UpdAssemblyId2);                   // 更新アセンブリID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.LogicalDeleteCode);              // 論理削除区分
                        paraBusinessSessionId.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.BusinessSessionId);             // 業務セッションID
                        paraSearchSectionCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.SearchSectionCode);             // 検索拠点コード
                        paraPmTabDtlDiscGuid.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.PmTabDtlDiscGuid);               // PMTAB明細識別GUID
                        paraDataDeleteDate.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.DataDeleteDate);                    // データ削除予定日
                        paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.AcceptAnOrderNo);                  // 受注番号
                        paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.AcptAnOdrStatus);                  // 受注ステータス
                        paraDataInputSystem.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.DataInputSystem);                  // データ入力システム
                        paraCarMngNo.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.CarMngNo);                                // 車両管理番号
                        paraCarMngCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.CarMngCode);                           // 車輌管理コード
                        paraNumberPlate1Code.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.NumberPlate1Code);                // 陸運事務所番号
                        paraNumberPlate1Name.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.NumberPlate1Name);               // 陸運事務局名称
                        paraNumberPlate2.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.NumberPlate2);                       // 車両登録番号（種別）
                        paraNumberPlate3.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.NumberPlate3);                       // 車両登録番号（カナ）
                        paraNumberPlate4.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.NumberPlate4);                        // 車両登録番号（プレート番号）
                        paraFirstEntryDate.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.FirstEntryDate);                    // 初年度
                        paraMakerCode.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.MakerCode);                              // メーカーコード
                        paraMakerFullName.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.MakerFullName);                     // メーカー全角名称
                        paraMakerHalfName.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.MakerHalfName);                     // メーカー半角名称
                        paraModelCode.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.ModelCode);                              // 車種コード
                        paraModelSubCode.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.ModelSubCode);                        // 車種サブコード
                        paraModelFullName.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.ModelFullName);                     // 車種全角名称
                        paraModelHalfName.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.ModelHalfName);                     // 車種半角名称
                        paraExhaustGasSign.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.ExhaustGasSign);                   // 排ガス記号
                        paraSeriesModel.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.SeriesModel);                         // シリーズ型式
                        paraCategorySignModel.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.CategorySignModel);             // 型式（類別記号）
                        paraFullModel.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.FullModel);                             // 型式（フル型）
                        paraModelDesignationNo.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.ModelDesignationNo);            // 型式指定番号
                        paraCategoryNo.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.CategoryNo);                            // 類別番号
                        paraFrameModel.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.FrameModel);                           // 車台型式
                        paraFrameNo.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.FrameNo);                                 // 車台番号
                        paraSearchFrameNo.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.SearchFrameNo);                      // 車台番号（検索用）
                        paraEngineModelNm.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.EngineModelNm);                     // エンジン型式名称
                        paraRelevanceModel.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.RelevanceModel);                   // 関連型式
                        paraSubCarNmCd.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.SubCarNmCd);                            // サブ車名コード
                        paraModelGradeSname.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.ModelGradeSname);                 // 型式グレード略称
                        paraColorCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.ColorCode);                             // カラーコード
                        paraColorName1.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.ColorName1);                           // カラー名称1
                        paraTrimCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.TrimCode);                               // トリムコード
                        paraTrimName.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.TrimName);                               // トリム名称
                        paraMileage.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.Mileage);                                  // 車両走行距離
                        // フル型式固定番号配列
                        // int[] → byte[] に変換
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        foreach (int item in pmTabAcpOdrCarWork.FullModelFixedNoAry)
                            ms.Write(BitConverter.GetBytes(item), 0, sizeof(int));
                        byte[] verbinary = ms.ToArray();
                        ms.Close();

                        paraFullModelFixedNoAry.Value = SqlDataMediator.SqlSetBinary(verbinary);                                      // フル型式固定番号配列

                        paraCategoryObjAry.Value = SqlDataMediator.SqlSetBinary(pmTabAcpOdrCarWork.CategoryObjAry);                   // 装備オブジェクト配列
                        paraCarNote.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.CarNote);                                 // 車輌備考
                        paraFreeSrchMdlFxdNoAry.Value = SqlDataMediator.SqlSetBinary(pmTabAcpOdrCarWork.FreeSrchMdlFxdNoAry);         // 自由検索型式固定番号配列
                        paraDomesticForeignCode.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.DomesticForeignCode);          // 国産／外車区分

                        #endregion

                        int cnt = sqlCommand.ExecuteNonQuery();
                        al.Add(pmTabAcpOdrCarWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
                    //sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            pmTabAcpOdrCarList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// 受注マスタ(車両)情報を論理削除します。
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">論理削除する受注マスタ(車両)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmTabAcpOdrCarWork に格納されている受注マスタ(車両)情報を論理削除します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        public int LogicalDelete(ref object pmTabAcpOdrCarList)
        {
            return this.LogicalDelete(ref pmTabAcpOdrCarList, 0);
        }

        /// <summary>
        /// 受注マスタ(車両)情報の論理削除を解除します。
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">論理削除を解除する受注マスタ(車両)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmTabAcpOdrCarWork に格納されている受注マスタ(車両)情報の論理削除を解除します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        public int RevivalLogicalDelete(ref object pmTabAcpOdrCarList)
        {
            return this.LogicalDelete(ref pmTabAcpOdrCarList, 1);
        }

        /// <summary>
        /// 受注マスタ(車両)情報の論理削除を操作します。
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">論理削除を操作する受注マスタ(車両)情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmTabAcpOdrCarWork に格納されている受注マスタ(車両)情報の論理削除を操作します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        private int LogicalDelete(ref object pmTabAcpOdrCarList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = pmTabAcpOdrCarList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDelete(ref paraList, procMode, sqlConnection, sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 受注マスタ(車両)情報の論理削除を操作します。
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">論理削除を操作する受注マスタ(車両)情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmTabAcpOdrCarWork に格納されている受注マスタ(車両)情報の論理削除を操作します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        public int LogicalDelete(ref ArrayList pmTabAcpOdrCarList, int procMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref pmTabAcpOdrCarList, procMode, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// 受注マスタ(車両)情報の論理削除を操作します。
        /// </summary>
        /// <param name="pmTabAcpOdrCarList">論理削除を操作する受注マスタ(車両)情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmTabAcpOdrCarWork に格納されている受注マスタ(車両)情報の論理削除を操作します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        private int LogicalDeleteProc(ref ArrayList pmTabAcpOdrCarList, int procMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (pmTabAcpOdrCarList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < pmTabAcpOdrCarList.Count; i++)
                    {
                        PmTabAcpOdrCarWork pmTabAcpOdrCarWork = pmTabAcpOdrCarList[i] as PmTabAcpOdrCarWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  PMTABACPODRCARRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SEARCHSECTIONCODERF = @FINDSEARCHSECTIONCODE" + Environment.NewLine;
                        sqlText += "  AND BUSINESSSESSIONIDRF = @FINDBUSINESSSESSIONID" + Environment.NewLine;
                        sqlText += "  AND PMTABDTLDISCGUIDRF = @FINDPMTABDTLDISCGUID" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findSearchSectionCode = sqlCommand.Parameters.Add("@FINDSEARCHSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findBusinessSessionId = sqlCommand.Parameters.Add("@FINDBUSINESSSESSIONID", SqlDbType.NChar);
                        SqlParameter findPmTabDtlDiscGuid = sqlCommand.Parameters.Add("@FINDPMTABDTLDISCGUID", SqlDbType.NChar);

                        // Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.EnterpriseCode);
                        findSearchSectionCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.SearchSectionCode);
                        findBusinessSessionId.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.BusinessSessionId);
                        findPmTabDtlDiscGuid.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.PmTabDtlDiscGuid);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != pmTabAcpOdrCarWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // 現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  PMTABACPODRCARRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND SEARCHSECTIONCODERF = @FINDSEARCHSECTIONCODE" + Environment.NewLine;
                            sqlText += "  AND BUSINESSSESSIONIDRF = @FINDBUSINESSSESSIONID" + Environment.NewLine;
                            sqlText += "  AND PMTABDTLDISCGUIDRF = @FINDPMTABDTLDISCGUID" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.EnterpriseCode);
                            findSearchSectionCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.SearchSectionCode);
                            findBusinessSessionId.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.BusinessSessionId);
                            findPmTabDtlDiscGuid.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.PmTabDtlDiscGuid);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pmTabAcpOdrCarWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        // 論理削除モードの場合
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;       // 既に削除済みの場合正常
                                return status;
                            }
                            else if (logicalDelCd == 0) pmTabAcpOdrCarWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                            else pmTabAcpOdrCarWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                pmTabAcpOdrCarWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
                            }
                            else
                            {
                                if (logicalDelCd == 0)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;   // 既に復活している場合はそのまま正常を戻す
                                }
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  // 完全削除はデータなしを戻す
                                }

                                return status;
                            }
                        }

                        // Parameterオブジェクトの作成(更新用)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定(更新用)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmTabAcpOdrCarWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pmTabAcpOdrCarWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(pmTabAcpOdrCarWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

            pmTabAcpOdrCarList = al;

            return status;
        }
        # endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="pmTabAcpOdrCarWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, PmTabAcpOdrCarWork pmTabAcpOdrCarWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine; ;

            // 企業コード
            retstring += "  ACAR.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.EnterpriseCode);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // 検索拠点コード
            if (pmTabAcpOdrCarWork.SearchSectionCode != "")
            {
                retstring += "  AND SEARCHSECTIONCODERF = @FINDSEARCHSECTIONCODE" + Environment.NewLine;
                SqlParameter findSearchSectionCode = sqlCommand.Parameters.Add("@FINDSEARCHSECTIONCODE", SqlDbType.NChar);
                findSearchSectionCode.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.SearchSectionCode);
            }

            // 業務セッションID
            if (pmTabAcpOdrCarWork.BusinessSessionId != "")
            {
                retstring += "  AND BUSINESSSESSIONIDRF = @FINDBUSINESSSESSIONID" + Environment.NewLine;
                SqlParameter findBusinessSessionId = sqlCommand.Parameters.Add("@FINDBUSINESSSESSIONID", SqlDbType.NChar);
                findBusinessSessionId.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.BusinessSessionId);
            }

            // PMTAB明細識別GUID
            if (pmTabAcpOdrCarWork.PmTabDtlDiscGuid != "")
            {
                retstring += "  AND PMTABDTLDISCGUIDRF = @FINDPMTABDTLDISCGUID" + Environment.NewLine;
                SqlParameter findPmTabDtlDiscGuid = sqlCommand.Parameters.Add("@FINDPMTABDTLDISCGUID", SqlDbType.NChar);
                findPmTabDtlDiscGuid.Value = SqlDataMediator.SqlSetString(pmTabAcpOdrCarWork.PmTabDtlDiscGuid);
            }

            return retstring;
        }
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → PmTabAcpOdrCarWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PmTabAcpOdrCarWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        /// </remarks>
        private PmTabAcpOdrCarWork CopyToPmTabAcpOdrCarWorkFromReader(ref SqlDataReader myReader)
        {
            PmTabAcpOdrCarWork pmTabAcpOdrCarWork = new PmTabAcpOdrCarWork();

            this.CopyToPmTabAcpOdrCarWorkFromReader(ref myReader, ref pmTabAcpOdrCarWork);

            return pmTabAcpOdrCarWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → PmTabAcpOdrCarWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="pmTabAcpOdrCarWork">PmTabAcpOdrCarWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        /// </remarks>
        private void CopyToPmTabAcpOdrCarWorkFromReader(ref SqlDataReader myReader, ref PmTabAcpOdrCarWork pmTabAcpOdrCarWork)
        {
            if (myReader != null && pmTabAcpOdrCarWork != null)
            {
                # region クラスへ格納
                pmTabAcpOdrCarWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // 作成日時
                pmTabAcpOdrCarWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // 更新日時
                pmTabAcpOdrCarWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));             // 企業コード
                pmTabAcpOdrCarWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));               // GUID
                pmTabAcpOdrCarWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));           // 更新従業員コード
                pmTabAcpOdrCarWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));             // 更新アセンブリID1
                pmTabAcpOdrCarWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));             // 更新アセンブリID2
                pmTabAcpOdrCarWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));        // 論理削除区分
                pmTabAcpOdrCarWork.BusinessSessionId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSSESSIONIDRF"));       // 業務セッションID
                pmTabAcpOdrCarWork.SearchSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHSECTIONCODERF"));       // 検索拠点コード
                pmTabAcpOdrCarWork.PmTabDtlDiscGuid = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PMTABDTLDISCGUIDRF"));           // PMTAB明細識別GUID
                pmTabAcpOdrCarWork.DataDeleteDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATADELETEDATERF"));              // データ削除予定日
                pmTabAcpOdrCarWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));            // 受注番号
                pmTabAcpOdrCarWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));            // 受注ステータス
                pmTabAcpOdrCarWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));            // データ入力システム
                pmTabAcpOdrCarWork.CarMngNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGNORF"));                          // 車両管理番号
                pmTabAcpOdrCarWork.CarMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMNGCODERF"));                     // 車輌管理コード
                pmTabAcpOdrCarWork.NumberPlate1Code = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE1CODERF"));          // 陸運事務所番号
                pmTabAcpOdrCarWork.NumberPlate1Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE1NAMERF"));         // 陸運事務局名称
                pmTabAcpOdrCarWork.NumberPlate2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE2RF"));                 // 車両登録番号（種別）
                pmTabAcpOdrCarWork.NumberPlate3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE3RF"));                 // 車両登録番号（カナ）
                pmTabAcpOdrCarWork.NumberPlate4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE4RF"));                  // 車両登録番号（プレート番号）
                pmTabAcpOdrCarWork.FirstEntryDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF"));              // 初年度
                pmTabAcpOdrCarWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));                        // メーカーコード
                pmTabAcpOdrCarWork.MakerFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERFULLNAMERF"));               // メーカー全角名称
                pmTabAcpOdrCarWork.MakerHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERHALFNAMERF"));               // メーカー半角名称
                pmTabAcpOdrCarWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));                        // 車種コード
                pmTabAcpOdrCarWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));                  // 車種サブコード
                pmTabAcpOdrCarWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));               // 車種全角名称
                pmTabAcpOdrCarWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));               // 車種半角名称
                pmTabAcpOdrCarWork.ExhaustGasSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXHAUSTGASSIGNRF"));             // 排ガス記号
                pmTabAcpOdrCarWork.SeriesModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));                   // シリーズ型式
                pmTabAcpOdrCarWork.CategorySignModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYSIGNMODELRF"));       // 型式（類別記号）
                pmTabAcpOdrCarWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));                       // 型式（フル型）
                pmTabAcpOdrCarWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));      // 型式指定番号
                pmTabAcpOdrCarWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));                      // 類別番号
                pmTabAcpOdrCarWork.FrameModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMEMODELRF"));                     // 車台型式
                pmTabAcpOdrCarWork.FrameNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));                           // 車台番号
                pmTabAcpOdrCarWork.SearchFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEARCHFRAMENORF"));                // 車台番号（検索用）
                pmTabAcpOdrCarWork.EngineModelNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));               // エンジン型式名称
                pmTabAcpOdrCarWork.RelevanceModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RELEVANCEMODELRF"));             // 関連型式
                pmTabAcpOdrCarWork.SubCarNmCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBCARNMCDRF"));                      // サブ車名コード
                pmTabAcpOdrCarWork.ModelGradeSname = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELGRADESNAMERF"));           // 型式グレード略称
                pmTabAcpOdrCarWork.ColorCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORCODERF"));                       // カラーコード
                pmTabAcpOdrCarWork.ColorName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORNAME1RF"));                     // カラー名称1
                pmTabAcpOdrCarWork.TrimCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMCODERF"));                         // トリムコード
                pmTabAcpOdrCarWork.TrimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMNAMERF"));                         // トリム名称
                pmTabAcpOdrCarWork.Mileage = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MILEAGERF"));                            // 車両走行距離
                byte[] varbinary = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("FULLMODELFIXEDNOARYRF"));                         // フル型式固定番号配列

                if (null != varbinary)
                {
                    pmTabAcpOdrCarWork.FullModelFixedNoAry = new int[(int)varbinary.Length / sizeof(int)];

                    for (int idx = 0; idx < pmTabAcpOdrCarWork.FullModelFixedNoAry.Length; idx++)
                    {
                        pmTabAcpOdrCarWork.FullModelFixedNoAry[idx] = BitConverter.ToInt32(varbinary, idx * sizeof(int));
                    }
                }
                else
                {
                    pmTabAcpOdrCarWork.FullModelFixedNoAry = new int[0];
                }
                pmTabAcpOdrCarWork.CategoryObjAry = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("CATEGORYOBJARYRF"));             // 装備オブジェクト配列
                pmTabAcpOdrCarWork.CarNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARNOTERF"));                           // 車輌備考
                pmTabAcpOdrCarWork.FreeSrchMdlFxdNoAry = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("FREESRCHMDLFXDNOARYRF"));   // 自由検索型式固定番号配列
                pmTabAcpOdrCarWork.DomesticForeignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOMESTICFOREIGNCODERF"));    // 国産／外車区分
                # endregion
            }
        }
        # endregion
    }
}
