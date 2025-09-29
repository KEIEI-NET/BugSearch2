//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 従業員別販売区分別売上目標設定マスタ
// プログラム概要   : 従業員別販売区分別売上目標設定マスタ DBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 管理番号  11500865-00  作成担当 : 譚洪
// 作 成 日  2019/09/02   修正内容 : 新規作成
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
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 従業員別販売区分別売上目標設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 従業員別販売区分別売上目標設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2019/09/02</br>
    /// </remarks>
    [Serializable]
    public class EmpScSalesTargetDB : RemoteDB, IEmpScSalesTargetDB
    {
        /// <summary>
        /// 従業員別販売区分別売上目標設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        public EmpScSalesTargetDB()
            :
            base("PMKHN09196D", "Broadleaf.Application.Remoting.ParamData.EmpScSalesTargetWork", "EMPSCSALESTARGETRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の従業員別販売区分別売上目標設定マスタ情報LISTを戻します
        /// </summary>
        /// <param name="empScSalesTargetWork">検索結果</param>
        /// <param name="paraWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の従業員別販売区分別売上目標設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        public int Search(out object empScSalesTargetWork, object paraWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            // コネクション
            SqlConnection sqlConnection = null;
            // 検索結果ワーク
            empScSalesTargetWork = null;
            // コネクション生成
            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    // 検索処理を行う
                    return SearchProc(out empScSalesTargetWork, paraWork, readMode, logicalMode, ref sqlConnection);
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "EmpScSalesTargetDB.Search");
                    empScSalesTargetWork = new ArrayList();
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
            }
        }

        /// <summary>
        /// 指定された条件の従業員別販売区分別売上目標設定マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objetEmpScSalesTargetWork">検索結果</param>
        /// <param name="searchParaWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の従業員別販売区分別売上目標設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        public int SearchProc(out object objetEmpScSalesTargetWork, object searchParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            // 検索結果ワーク
            SearchEmpScSalesTargetParaWork empScSalesTargetParaWork = null;
            // 検索パラメータリスト
            ArrayList empScSalesTargetList = searchParaWork as ArrayList;

            // 単一検索場合
            if (empScSalesTargetList == null)
            {
                empScSalesTargetParaWork = searchParaWork as SearchEmpScSalesTargetParaWork;
            }
            else
            {
                if (empScSalesTargetList.Count > 0)
                {
                    empScSalesTargetParaWork = empScSalesTargetList[0] as SearchEmpScSalesTargetParaWork;
                }
            }

            // 検索処理を行う
            int status = SearchEmpScSalesTargetProc(out empScSalesTargetList, empScSalesTargetParaWork, readMode, logicalMode, ref sqlConnection);
            // 検索結果ワーク
            objetEmpScSalesTargetWork = empScSalesTargetList;

            return status;
        }

        /// <summary>
        /// 指定された条件の従業員別販売区分別売上目標設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="empScSalesTargetList">検索結果</param>
        /// <param name="searchParaWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の従業員別販売区分別売上目標設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        public int SearchEmpScSalesTargetProc(out ArrayList empScSalesTargetList, SearchEmpScSalesTargetParaWork searchParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchEmpSalesTargetProcProc(out empScSalesTargetList, searchParaWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の従業員別販売区分別売上目標設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="empScSalesTargetList">検索結果</param>
        /// <param name="searchParaWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の従業員別販売区分別売上目標設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        private int SearchEmpSalesTargetProcProc(out ArrayList empScSalesTargetList, SearchEmpScSalesTargetParaWork searchParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // コマンド
            SqlCommand sqlCommand = null;
            // 検索結果リスト
            ArrayList al = new ArrayList();
            empScSalesTargetList = new ArrayList();

            try
            {
                using (sqlCommand = new SqlCommand("", sqlConnection))
                {
                    string selectTxt = string.Empty;
                    selectTxt += "SELECT" + Environment.NewLine;
                    selectTxt += " A.CREATEDATETIMERF" + Environment.NewLine;
                    selectTxt += " , A.UPDATEDATETIMERF" + Environment.NewLine;
                    selectTxt += " , A.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += " , A.FILEHEADERGUIDRF" + Environment.NewLine;
                    selectTxt += " , A.UPDEMPLOYEECODERF" + Environment.NewLine;
                    selectTxt += " , A.UPDASSEMBLYID1RF" + Environment.NewLine;
                    selectTxt += " , A.UPDASSEMBLYID2RF" + Environment.NewLine;
                    selectTxt += " , A.LOGICALDELETECODERF" + Environment.NewLine;
                    selectTxt += " , A.TARGETSETCDRF" + Environment.NewLine;
                    selectTxt += " , A.TARGETCONTRASTCDRF" + Environment.NewLine;
                    selectTxt += " , A.TARGETDIVIDECODERF" + Environment.NewLine;
                    selectTxt += " , A.TARGETDIVIDENAMERF" + Environment.NewLine;
                    selectTxt += " , A.SALESCODERF" + Environment.NewLine;
                    selectTxt += " , A.EMPLOYEECODERF" + Environment.NewLine;
                    selectTxt += " , A.APPLYSTADATERF" + Environment.NewLine;
                    selectTxt += " , A.APPLYENDDATERF" + Environment.NewLine;
                    selectTxt += " , A.SALESTARGETMONEYRF" + Environment.NewLine;
                    selectTxt += " , A.SALESTARGETPROFITRF" + Environment.NewLine;
                    selectTxt += " , A.SALESTARGETCOUNTRF" + Environment.NewLine;
                    selectTxt += "  FROM EMPSCSALESTARGETRF AS A WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlCommand.CommandText = selectTxt.ToString();
                    // 検索条件
                    sqlCommand.CommandText += MakeWhereString(ref sqlCommand, searchParaWork, logicalMode);

                    // クエリ実行時のタイムアウト時間を3600秒に設定する
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            // 検索結果格納
                            al.Add(CopyToEmpSalesTargetWorkFromReader(myReader));
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }

                    // 検索結果格納
                    empScSalesTargetList = al;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// 従業員別販売区分別売上目標設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="empScSalesTarget">従業員別販売区分別売上目標設定マスタ情報オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 従業員別販売区分別売上目標設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        public int Write(ref object empScSalesTarget)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            // コネクション
            SqlConnection sqlConnection = null;
            // トランザクション
            SqlTransaction sqlTransaction = null;

            try
            {
                // コネクション開始
                using (sqlConnection = CreateSqlConnection(true))
                {
                    // パラメータのキャスト
                    ArrayList paraList = CastToArrayListFromPara(empScSalesTarget);
                    if (paraList == null) return status;

                    // トランザクション開始
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                    // 登録処理を行う
                    status = WriteProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // コミット
                        sqlTransaction.Commit();
                    }
                    else
                    {
                        // ロールバック
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }
                    //戻り値セット
                    empScSalesTarget = paraList;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmpScSalesTargetDB.Write");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
            }

            return status;
        }


        /// <summary>
        /// 従業員別販売区分別売上目標設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="empScSalesTargetList">従業員別販売区分別売上目標設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 従業員別販売区分別売上目標設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        public int WriteProc(ref ArrayList empScSalesTargetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteEmpScSalesTargetProc(ref empScSalesTargetList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 従業員別販売区分別売上目標設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="empScSalesTargetList">従業員別販売区分別売上目標設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 従業員別販売区分別売上目標設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        private int WriteEmpScSalesTargetProc(ref ArrayList empScSalesTargetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            // コマンド
            SqlCommand sqlCommand = null;
            // 検索結果リスト
            ArrayList al = new ArrayList();

            try
            {
                using (sqlCommand = new SqlCommand("", sqlConnection))
                {
                    string selectTxt = string.Empty;
                    if (empScSalesTargetList != null)
                    {
                        for (int i = 0; i < empScSalesTargetList.Count; i++)
                        {
                            EmpScSalesTargetWork empScSalesTargetWork = empScSalesTargetList[i] as EmpScSalesTargetWork;

                            selectTxt = string.Empty;
                            selectTxt += "SELECT UPDATEDATETIMERF FROM EMPSCSALESTARGETRF" + Environment.NewLine;
                            selectTxt += "WHERE" + Environment.NewLine;
                            selectTxt += " ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " AND TARGETSETCDRF=@FINDTARGETSETCD" + Environment.NewLine;
                            selectTxt += " AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD" + Environment.NewLine;
                            selectTxt += " AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE" + Environment.NewLine;
                            selectTxt += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += " AND SALESCODERF=@FINDSALESCODE" + Environment.NewLine;

                            //Selectコマンドの生成
                            sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                            //Prameterオブジェクトの作成
                            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                            SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                            SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                            SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                            SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDSALESCODE", SqlDbType.Int);

                            //Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EnterpriseCode);
                            findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetSetCd);
                            findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetContrastCd);
                            findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.TargetDivideCode);
                            findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EmployeeCode);
                            findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.SalesCode);

                            myReader = sqlCommand.ExecuteReader();
                            if (myReader.Read())
                            {
                                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                                if (_updateDateTime != empScSalesTargetWork.UpdateDateTime)
                                {
                                    //新規登録で該当データ有りの場合には重複
                                    if (empScSalesTargetWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                    //既存データで更新日時違いの場合には排他
                                    else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                    sqlCommand.Cancel();
                                    if (myReader.IsClosed == false) myReader.Close();
                                    return status;
                                }

                                selectTxt = string.Empty;
                                selectTxt += "UPDATE EMPSCSALESTARGETRF SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                                selectTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                selectTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                                selectTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                                selectTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                                selectTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                                selectTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                                selectTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                                selectTxt += " , TARGETSETCDRF=@TARGETSETCD" + Environment.NewLine;
                                selectTxt += " , TARGETCONTRASTCDRF=@TARGETCONTRASTCD" + Environment.NewLine;
                                selectTxt += " , TARGETDIVIDECODERF=@TARGETDIVIDECODE" + Environment.NewLine;
                                selectTxt += " , TARGETDIVIDENAMERF=@TARGETDIVIDENAME" + Environment.NewLine;
                                selectTxt += " , SALESCODERF=@SALESCODE" + Environment.NewLine;
                                selectTxt += " , EMPLOYEECODERF=@EMPLOYEECODE" + Environment.NewLine;
                                selectTxt += " , APPLYSTADATERF=@APPLYSTADATE" + Environment.NewLine;
                                selectTxt += " , APPLYENDDATERF=@APPLYENDDATE" + Environment.NewLine;
                                selectTxt += " , SALESTARGETMONEYRF=@SALESTARGETMONEY" + Environment.NewLine;
                                selectTxt += " , SALESTARGETPROFITRF=@SALESTARGETPROFIT" + Environment.NewLine;
                                selectTxt += " , SALESTARGETCOUNTRF=@SALESTARGETCOUNT" + Environment.NewLine;
                                selectTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                selectTxt += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                                selectTxt += "  AND TARGETSETCDRF=@FINDTARGETSETCD" + Environment.NewLine;
                                selectTxt += "  AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD" + Environment.NewLine;
                                selectTxt += "  AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE" + Environment.NewLine;
                                selectTxt += "  AND SALESCODERF=@FINDSALESCODE " + Environment.NewLine;
                                selectTxt += "  AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                                sqlCommand.CommandText = selectTxt;

                                //KEYコマンドを再設定
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EnterpriseCode);
                                findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetSetCd);
                                findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetContrastCd);
                                findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.TargetDivideCode);
                                findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.SalesCode);
                                findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EmployeeCode);

                                //更新ヘッダ情報を設定
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)empScSalesTargetWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetUpdateHeader(ref flhd, obj);
                            }
                            else
                            {
                                //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                                if (empScSalesTargetWork.UpdateDateTime > DateTime.MinValue)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                    sqlCommand.Cancel();
                                    if (myReader.IsClosed == false) myReader.Close();
                                    return status;
                                }

                                selectTxt = string.Empty;
                                selectTxt += "INSERT INTO EMPSCSALESTARGETRF" + Environment.NewLine;
                                selectTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                                selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                                selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                                selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                                selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                                selectTxt += "  ,TARGETSETCDRF" + Environment.NewLine;
                                selectTxt += "  ,TARGETCONTRASTCDRF" + Environment.NewLine;
                                selectTxt += "  ,TARGETDIVIDECODERF" + Environment.NewLine;
                                selectTxt += "  ,TARGETDIVIDENAMERF" + Environment.NewLine;
                                selectTxt += "  ,SALESCODERF" + Environment.NewLine;
                                selectTxt += "  ,EMPLOYEECODERF" + Environment.NewLine;
                                selectTxt += "  ,APPLYSTADATERF" + Environment.NewLine;
                                selectTxt += "  ,APPLYENDDATERF" + Environment.NewLine;
                                selectTxt += "  ,SALESTARGETMONEYRF" + Environment.NewLine;
                                selectTxt += "  ,SALESTARGETPROFITRF" + Environment.NewLine;
                                selectTxt += "  ,SALESTARGETCOUNTRF" + Environment.NewLine;
                                selectTxt += " )" + Environment.NewLine;
                                selectTxt += " VALUES" + Environment.NewLine;
                                selectTxt += " (@CREATEDATETIME" + Environment.NewLine;
                                selectTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
                                selectTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
                                selectTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
                                selectTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                                selectTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                                selectTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                                selectTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                                selectTxt += "  ,@TARGETSETCD" + Environment.NewLine;
                                selectTxt += "  ,@TARGETCONTRASTCD" + Environment.NewLine;
                                selectTxt += "  ,@TARGETDIVIDECODE" + Environment.NewLine;
                                selectTxt += "  ,@TARGETDIVIDENAME" + Environment.NewLine;
                                selectTxt += "  ,@SALESCODE" + Environment.NewLine;
                                selectTxt += "  ,@EMPLOYEECODE" + Environment.NewLine;
                                selectTxt += "  ,@APPLYSTADATE" + Environment.NewLine;
                                selectTxt += "  ,@APPLYENDDATE" + Environment.NewLine;
                                selectTxt += "  ,@SALESTARGETMONEY" + Environment.NewLine;
                                selectTxt += "  ,@SALESTARGETPROFIT" + Environment.NewLine;
                                selectTxt += "  ,@SALESTARGETCOUNT" + Environment.NewLine;
                                selectTxt += " )" + Environment.NewLine;

                                //新規作成時のSQL文を生成
                                sqlCommand.CommandText = selectTxt;
                                //登録ヘッダ情報を設定
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)empScSalesTargetWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetInsertHeader(ref flhd, obj);
                            }
                            if (myReader.IsClosed == false) myReader.Close();

                            #region Parameterオブジェクトの作成(更新用)
                            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                            SqlParameter paraTargetSetCd = sqlCommand.Parameters.Add("@TARGETSETCD", SqlDbType.Int);
                            SqlParameter paraTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                            SqlParameter paraTargetDivideCode = sqlCommand.Parameters.Add("@TARGETDIVIDECODE", SqlDbType.NChar);
                            SqlParameter paraTargetDivideName = sqlCommand.Parameters.Add("@TARGETDIVIDENAME", SqlDbType.NVarChar);
                            SqlParameter paraSalesCode = sqlCommand.Parameters.Add("@SALESCODE", SqlDbType.Int);
                            SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                            SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                            SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                            SqlParameter paraSalesTargetMoney = sqlCommand.Parameters.Add("@SALESTARGETMONEY", SqlDbType.BigInt);
                            SqlParameter paraSalesTargetProfit = sqlCommand.Parameters.Add("@SALESTARGETPROFIT", SqlDbType.BigInt);
                            SqlParameter paraSalesTargetCount = sqlCommand.Parameters.Add("@SALESTARGETCOUNT", SqlDbType.Float);

                            #endregion

                            #region Parameterオブジェクトへ値設定(更新用)
                            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(empScSalesTargetWork.CreateDateTime);
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(empScSalesTargetWork.UpdateDateTime);
                            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EnterpriseCode);
                            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(empScSalesTargetWork.FileHeaderGuid);
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.UpdEmployeeCode);
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.UpdAssemblyId1);
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.UpdAssemblyId2);
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.LogicalDeleteCode);
                            paraTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetSetCd);
                            paraTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetContrastCd);
                            paraTargetDivideCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.TargetDivideCode);
                            paraTargetDivideName.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.TargetDivideName);
                            paraSalesCode.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.SalesCode);
                            paraEmployeeCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EmployeeCode);
                            paraApplyStaDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(empScSalesTargetWork.ApplyStaDate);
                            paraApplyEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(empScSalesTargetWork.ApplyEndDate);
                            paraSalesTargetMoney.Value = SqlDataMediator.SqlSetInt64(empScSalesTargetWork.SalesTargetMoney);
                            paraSalesTargetProfit.Value = SqlDataMediator.SqlSetInt64(empScSalesTargetWork.SalesTargetProfit);
                            paraSalesTargetCount.Value = SqlDataMediator.SqlSetDouble(empScSalesTargetWork.SalesTargetCount);
                            #endregion

                            sqlCommand.ExecuteNonQuery();
                            al.Add(empScSalesTargetWork);
                        }
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
            }

            empScSalesTargetList = al;

            return status;
        }
        #endregion

        #region [WriteProc]
        /// <summary>
        /// 従業員別販売区分別売上目標設定マスタ情報を更新します
        /// </summary>
        /// <param name="empScSalesTargetWork">従業員別販売区分別売上目標設定マスタ情報オブジェクト(write用)</param>
        /// <param name="parabyte">EmpSalesTargetWorkオブジェクト(delete用)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 従業員別販売区分別売上目標設定マスタ情報を更新します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        public int WriteProc(ref object empScSalesTargetWork, byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // コネクション
            SqlConnection sqlConnection = null;
            // トランザクション
            SqlTransaction sqlTransaction = null;
            try
            {
                // コネクション生成
                using (sqlConnection = CreateSqlConnection(true))
                {
                    // パラメータのキャスト
                    ArrayList paraWriteList = CastToArrayListFromPara(empScSalesTargetWork);
                    if (paraWriteList == null) return status;

                    ArrayList paraDeleteList = CastToArrayListFromPara(parabyte);
                    if (paraDeleteList == null) return status;

                    // トランザクション開始
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                    // 削除処理を行う
                    status = DeleteEmpScSalesTargetProcProc(paraDeleteList, ref sqlConnection, ref sqlTransaction);

                    // 登録処理を行う
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = WriteEmpScSalesTargetProc(ref paraWriteList, ref sqlConnection, ref sqlTransaction);
                    }
                    else
                    {
                        // なし
                    }

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // コミット
                        sqlTransaction.Commit();
                    }
                    else
                    {
                        // ロールバック
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }
                    //戻り値セット
                    empScSalesTargetWork = paraWriteList;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmpScSalesTargetDB.WriteProc");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
            }

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 従業員別販売区分別売上目標設定マスタ情報を論理削除します
        /// </summary>
        /// <param name="empScSalesTargetWork">従業員別販売区分別売上目標設定マスタ情報オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 従業員別販売区分別売上目標設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        public int LogicalDelete(ref object empScSalesTargetWork)
        {
            return LogicalDeleteEmpScSalesTarget(ref empScSalesTargetWork, 0);
        }

        /// <summary>
        /// 論理削除従業員別販売区分別売上目標設定マスタ情報を復活します
        /// </summary>
        /// <param name="empScSalesTargetWork">従業員別販売区分別売上目標設定マスタ情報オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 論理削除従業員別販売区分別売上目標設定マスタ情報を復活します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object empScSalesTargetWork)
        {
            return LogicalDeleteEmpScSalesTarget(ref empScSalesTargetWork, 1);
        }

        /// <summary>
        /// 従業員別販売区分別売上目標設定マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="empScSalesTargetWork">従業員別販売区分別売上目標設定オブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 従業員別販売区分別売上目標設定マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        private int LogicalDeleteEmpScSalesTarget(ref object empScSalesTargetWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // コネクション
            SqlConnection sqlConnection = null;
            // トランザクション
            SqlTransaction sqlTransaction = null;
            try
            {
                // コネクション生成
                using (sqlConnection = CreateSqlConnection(true))
                {
                    //パラメータのキャスト
                    ArrayList paraList = CastToArrayListFromPara(empScSalesTargetWork);
                    if (paraList == null) return status;

                    // トランザクション開始
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                    status = LogicalDeleteEmpScSalesTargetProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // コミット
                        sqlTransaction.Commit();
                    }
                    else
                    {
                        // ロールバック
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmpScSalesTargetDB.LogicalDeleteEmpScSalesTarget");

                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
            }
            return status;
        }

        /// <summary>
        /// 従業員別販売区分別売上目標設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="empScSalesTargetWorkList">従業員別販売区分別売上目標設定マスタ情報オブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 従業員別販売区分別売上目標設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        public int LogicalDeleteEmpScSalesTargetProc(ref ArrayList empScSalesTargetWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteEmpScSalesTargetProcProc(ref empScSalesTargetWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 従業員別販売区分別売上目標設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="empScSalesTargetWorkList">従業員別販売区分別売上目標設定マスタ情報オブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 従業員別販売区分別売上目標設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        private int LogicalDeleteEmpScSalesTargetProcProc(ref ArrayList empScSalesTargetWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // ロジック削除区分
            int logicalDelCd = 0;
            // コマンド
            SqlCommand sqlCommand = null;
            // 検索結果リスト
            ArrayList al = new ArrayList();

            try
            {
                using (sqlCommand = new SqlCommand("", sqlConnection))
                {
                    string selectTxt = string.Empty;
                    if (empScSalesTargetWorkList != null)
                    {
                        for (int i = 0; i < empScSalesTargetWorkList.Count; i++)
                        {
                            EmpScSalesTargetWork empScSalesTargetWork = empScSalesTargetWorkList[i] as EmpScSalesTargetWork;

                            //Selectコマンドの生成
                            selectTxt = string.Empty;
                            selectTxt += "SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM EMPSCSALESTARGETRF" + Environment.NewLine;
                            selectTxt += "WHERE" + Environment.NewLine;
                            selectTxt += " ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " AND TARGETSETCDRF=@FINDTARGETSETCD" + Environment.NewLine;
                            selectTxt += " AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD" + Environment.NewLine;
                            selectTxt += " AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE" + Environment.NewLine;
                            selectTxt += " AND SALESCODERF=@FINDSALESCODE" + Environment.NewLine;
                            selectTxt += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                            sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                            //Prameterオブジェクトの作成
                            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                            SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                            SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                            SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDSALESCODE", SqlDbType.Int);
                            SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                            //Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EnterpriseCode);
                            findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetSetCd);
                            findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetContrastCd);
                            findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.TargetDivideCode);
                            findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.SalesCode);
                            findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EmployeeCode);

                            using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                            {
                                if (myReader.Read())
                                {
                                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                                    if (_updateDateTime != empScSalesTargetWork.UpdateDateTime)
                                    {
                                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                        sqlCommand.Cancel();
                                        return status;
                                    }
                                    //現在の論理削除区分を取得
                                    logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                                    selectTxt = string.Empty;
                                    selectTxt += "UPDATE EMPSCSALESTARGETRF" + Environment.NewLine;
                                    selectTxt += "SET" + Environment.NewLine;
                                    selectTxt += " UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                    selectTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                                    selectTxt += ", UPDASSEMBLYID1RF=@UPDASSEMBLYID1 " + Environment.NewLine;
                                    selectTxt += ", UPDASSEMBLYID2RF=@UPDASSEMBLYID2 " + Environment.NewLine;
                                    selectTxt += ", LOGICALDELETECODERF=@LOGICALDELETECODE " + Environment.NewLine;
                                    selectTxt += "WHERE" + Environment.NewLine;
                                    selectTxt += " ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                    selectTxt += " AND TARGETSETCDRF=@FINDTARGETSETCD" + Environment.NewLine;
                                    selectTxt += " AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD" + Environment.NewLine;
                                    selectTxt += " AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE" + Environment.NewLine;
                                    selectTxt += " AND SALESCODERF=@FINDSALESCODE" + Environment.NewLine;
                                    selectTxt += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                                    //KEYコマンドを再設定
                                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EnterpriseCode);
                                    findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetSetCd);
                                    findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetContrastCd);
                                    findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.TargetDivideCode);
                                    findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.SalesCode);
                                    findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EmployeeCode);
                                    sqlCommand.CommandText = selectTxt;
                                    //更新ヘッダ情報を設定
                                    object obj = (object)this;
                                    IFileHeader flhd = (IFileHeader)empScSalesTargetWork;
                                    FileHeader fileHeader = new FileHeader(obj);
                                    fileHeader.SetUpdateHeader(ref flhd, obj);
                                }
                                else
                                {
                                    //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                    sqlCommand.Cancel();
                                    return status;
                                }
                                sqlCommand.Cancel();
                            }

                            //論理削除モードの場合
                            if (procMode == 0)
                            {
                                if (logicalDelCd == 3)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
                                    sqlCommand.Cancel();
                                    return status;
                                }
                                else if (logicalDelCd == 0) empScSalesTargetWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                                else empScSalesTargetWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                            }
                            else
                            {
                                if (logicalDelCd == 1) empScSalesTargetWork.LogicalDeleteCode = 0;//論理削除フラグを解除
                                else
                                {
                                    if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
                                    else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
                                    sqlCommand.Cancel();
                                    return status;
                                }
                            }

                            //Parameterオブジェクトの作成(更新用)
                            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                            //Parameterオブジェクトへ値設定(更新用)
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(empScSalesTargetWork.UpdateDateTime);
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.UpdEmployeeCode);
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.UpdAssemblyId1);
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.UpdAssemblyId2);
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.LogicalDeleteCode);

                            sqlCommand.ExecuteNonQuery();
                            al.Add(empScSalesTargetWork);
                        }

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }

            // 検索結果リスト格納
            empScSalesTargetWorkList = al;

            return status;
        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 従業員別販売区分別売上目標設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">従業員別販売区分別売上目標設定マスタ情報オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 従業員別販売区分別売上目標設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        public int Delete(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // コネクション
            SqlConnection sqlConnection = null;
            // トランザクション
            SqlTransaction sqlTransaction = null;
            try
            {
                // コネクション生成
                using (sqlConnection = CreateSqlConnection(true))
                {
                    // パラメータのキャスト
                    ArrayList paraList = CastToArrayListFromPara(parabyte);
                    if (paraList == null) return status;

                    // トランザクション開始
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                    status = DeleteEmpScSalesTargetProc(paraList, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // コミット
                        sqlTransaction.Commit();
                    }
                    else
                    {
                        // ロールバック
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmpScSalesTargetDB.Delete");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
            }
            return status;
        }


        /// <summary>
        /// 従業員別販売区分別売上目標設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="empScSalesTargetWorkList">従業員別販売区分別売上目標設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 従業員別販売区分別売上目標設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        public int DeleteEmpScSalesTargetProc(ArrayList empScSalesTargetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteEmpScSalesTargetProcProc(empScSalesTargetWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 従業員別販売区分別売上目標設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="empScSalesTargetWorkList">従業員別販売区分別売上目標設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 従業員別販売区分別売上目標設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        private int DeleteEmpScSalesTargetProcProc(ArrayList empScSalesTargetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // コマンド
            SqlCommand sqlCommand = null;

            try
            {
                using (sqlCommand = new SqlCommand("", sqlConnection))
                {
                    string selectTxt = string.Empty;

                    for (int i = 0; i < empScSalesTargetWorkList.Count; i++)
                    {
                        EmpScSalesTargetWork empScSalesTargetWork = empScSalesTargetWorkList[i] as EmpScSalesTargetWork;

                        selectTxt = string.Empty;
                        selectTxt += "SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM EMPSCSALESTARGETRF" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += " ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND TARGETSETCDRF=@FINDTARGETSETCD" + Environment.NewLine;
                        selectTxt += " AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD" + Environment.NewLine;
                        selectTxt += " AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE" + Environment.NewLine;
                        selectTxt += " AND SALESCODERF=@FINDSALESCODE" + Environment.NewLine;
                        selectTxt += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                        SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                        SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                        SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDSALESCODE", SqlDbType.Int);
                        SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EnterpriseCode);
                        findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetSetCd);
                        findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetContrastCd);
                        findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.TargetDivideCode);
                        findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.SalesCode);
                        findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EmployeeCode);
                        using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                        {
                            if (myReader.Read())
                            {
                                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                                if (_updateDateTime != empScSalesTargetWork.UpdateDateTime)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                    sqlCommand.Cancel();
                                    return status;
                                }

                                selectTxt = string.Empty;
                                selectTxt = "DELETE FROM EMPSCSALESTARGETRF ";
                                selectTxt += " WHERE" + Environment.NewLine;
                                selectTxt += " ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                selectTxt += " AND TARGETSETCDRF=@FINDTARGETSETCD" + Environment.NewLine;
                                selectTxt += " AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD" + Environment.NewLine;
                                selectTxt += " AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE" + Environment.NewLine;
                                selectTxt += " AND SALESCODERF=@FINDSALESCODE" + Environment.NewLine;
                                selectTxt += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                                //KEYコマンドを再設定
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EnterpriseCode);
                                findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetSetCd);
                                findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.TargetContrastCd);
                                findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.TargetDivideCode);
                                findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(empScSalesTargetWork.SalesCode);
                                findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(empScSalesTargetWork.EmployeeCode);
                                sqlCommand.CommandText = selectTxt;
                            }
                            else
                            {
                                //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                return status;
                            }
                        }

                        sqlCommand.ExecuteNonQuery();
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }

            return status;
        }
        #endregion

	    #region [Where文作成処理]
	    /// <summary>
	    /// 検索条件文字列生成＋条件値設定
	    /// </summary>
	    /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="searchParaWork">検索条件格納クラス</param>
	    /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
	    /// <returns>Where条件文字列</returns>
        /// <remarks>
	    /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, SearchEmpScSalesTargetParaWork searchParaWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //企業コード
		    retstring += "A.ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(searchParaWork.EnterpriseCode);

		    //論理削除区分
		    wkstring = "";
		    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData1)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData2)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData3))
		    {
                wkstring = "AND A.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
		    }
		    else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData012))
		    {
                wkstring = "AND A.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
		    }
		    if(wkstring != "")
		    {
			    retstring += wkstring;
			    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
			    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
		    }

            //目標設定区分
            if (searchParaWork.TargetSetCd > 0)
            {
                retstring += "AND A.TARGETSETCDRF=@TARGETSETCD ";
                SqlParameter paraTargetSetCd = sqlCommand.Parameters.Add("@TARGETSETCD", SqlDbType.Int);
                paraTargetSetCd.Value = SqlDataMediator.SqlSetInt32(searchParaWork.TargetSetCd);
            }

            //目標対比区分
            if (searchParaWork.TargetContrastCd > 0)
            {
                retstring += "AND A.TARGETCONTRASTCDRF=@TARGETCONTRASTCD ";
                SqlParameter paraTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                paraTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(searchParaWork.TargetContrastCd);
            }

            //目標区分コード
            if (searchParaWork.TargetDivideCode != "")
            {
                retstring += "AND A.TARGETDIVIDECODERF>=@TARGETDIVIDECODE1 ";
                retstring += "AND A.TARGETDIVIDECODERF<=@TARGETDIVIDECODE2 ";
                SqlParameter paraTargetDivideCode1 = sqlCommand.Parameters.Add("@TARGETDIVIDECODE1", SqlDbType.NChar);
                SqlParameter paraTargetDivideCode2 = sqlCommand.Parameters.Add("@TARGETDIVIDECODE2", SqlDbType.NChar);
                paraTargetDivideCode1.Value = SqlDataMediator.SqlSetString(searchParaWork.TargetDivideCode);
                int endYearMonth = Convert.ToInt32(searchParaWork.TargetDivideCode) + 99;
                if (endYearMonth % 100 == 0)
                {
                    endYearMonth = Convert.ToInt32(searchParaWork.TargetDivideCode) + 11;
                }
                paraTargetDivideCode2.Value = SqlDataMediator.SqlSetString(endYearMonth.ToString());
            }

            //従業員コード
            if (searchParaWork.EmployeeCode != "")
            {
                retstring += "AND A.EMPLOYEECODERF=@EMPLOYEECODE ";
                SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                paraEmployeeCode.Value = SqlDataMediator.SqlSetString(searchParaWork.EmployeeCode);
            }

            //販売区分コード
            if (searchParaWork.SalesCode > 0)
            {
                retstring += "AND A.SALESCODERF=@SALESCODE ";
                SqlParameter paraSalesCode = sqlCommand.Parameters.Add("@SALESCODE", SqlDbType.Int);
                paraSalesCode.Value = SqlDataMediator.SqlSetInt32(searchParaWork.SalesCode);
            }

            //ソート順位
            retstring += "ORDER BY A.APPLYSTADATERF,A.APPLYENDDATERF,A.EMPLOYEECODERF,A.SALESCODERF ";

		    return retstring;
		}
	    #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → EmpSalesTargetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>EmpSalesTargetWork</returns>
        /// <remarks>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        private EmpScSalesTargetWork CopyToEmpSalesTargetWorkFromReader(SqlDataReader myReader)
        {
            EmpScSalesTargetWork wkEmpScSalesTarget = new EmpScSalesTargetWork();

            #region クラスへ格納
            wkEmpScSalesTarget.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkEmpScSalesTarget.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkEmpScSalesTarget.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkEmpScSalesTarget.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkEmpScSalesTarget.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkEmpScSalesTarget.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkEmpScSalesTarget.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkEmpScSalesTarget.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkEmpScSalesTarget.TargetSetCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TARGETSETCDRF"));
            wkEmpScSalesTarget.TargetContrastCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TARGETCONTRASTCDRF"));
            wkEmpScSalesTarget.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
            wkEmpScSalesTarget.TargetDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDENAMERF"));
            wkEmpScSalesTarget.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
            wkEmpScSalesTarget.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
            wkEmpScSalesTarget.ApplyStaDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYSTADATERF"));
            wkEmpScSalesTarget.ApplyEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYENDDATERF"));
            wkEmpScSalesTarget.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEYRF"));
            wkEmpScSalesTarget.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFITRF"));
            wkEmpScSalesTarget.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNTRF"));
            #endregion

            return wkEmpScSalesTarget;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            EmpScSalesTargetWork[] empScSalesTargetArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is EmpScSalesTargetWork)
                    {
                        EmpScSalesTargetWork wkEmpSalesTargetWork = paraobj as EmpScSalesTargetWork;
                        if (wkEmpSalesTargetWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkEmpSalesTargetWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            empScSalesTargetArray = (EmpScSalesTargetWork[])XmlByteSerializer.Deserialize(byteArray, typeof(EmpScSalesTargetWork[]));
                        }
                        catch (Exception) { }
                        if (empScSalesTargetArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(empScSalesTargetArray);
                        }
                        else
                        {
                            try
                            {
                                EmpScSalesTargetWork wkEmpSalesTargetWork = (EmpScSalesTargetWork)XmlByteSerializer.Deserialize(byteArray, typeof(EmpScSalesTargetWork));
                                if (wkEmpSalesTargetWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkEmpSalesTargetWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    //特に何もしない
                }

            return retal;
        }
        #endregion

       #region [コネクション生成処理]
        /// <summary>
        /// コネクション生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Note        : コネクション生成処理を行う。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2017/08/02</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            // コネクション生成
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            // コネクション接続
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }
            else
            {
                base.WriteErrorLog("EmpScSalesTargetDB.CreateSqlConnection" + "コネクション取得失敗");
            }

            // SqlConnection返す
            return retSqlConnection;
        }
        #endregion  // コネクション生成処理
    }
}
