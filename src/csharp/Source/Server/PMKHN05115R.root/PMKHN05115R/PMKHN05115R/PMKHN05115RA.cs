//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　担当者マスタコード変換リモートオブジェクト
// プログラム概要   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//=====================================================================================//
// 履歴
//-------------------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/03/10  修正内容 : 新規作成
//-------------------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 担当者マスタコード変換リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 担当者マスタコード変換の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/03/10</br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class EmployeeConvertDB : RemoteWithAppLockDB, IEmployeeConvertDB
    {
        #region -- Member --

        #region -- Constant --
        /// <summary>タイムアウトの値を表す定数：36000</summary>
        private readonly int DB_TIME_OUT = 36000;        
        /// <summary>担当者コード変換対象ファイルに不正データが有ることを示す定数：997</summary>
        private readonly int ILLEGAL_DATA = 997;
        /// <summary>担当者コード変換対象ファイルにデータが無いことを示す定数：998</summary>
        private readonly int NO_DATA = 998;
        /// <summary>担当者コード変換対象ファイルが存在しないことを示す定数：999</summary>
        private readonly int NO_FILE = 999;

        #endregion

        #endregion
        
        #region -- Constructor --

        /// <summary>
        /// 担当者マスタコード変換DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        public EmployeeConvertDB()
        {
            // 処理なし
        }

        #endregion

        #region -- Public Method --

        /// <summary>
        /// コード変換処理
        /// </summary>
        /// <param name="warehouseConvertPrmListObj">変換条件</param>
        /// <param name="numberOfTransactions">処理件数を格納した変数</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に担当者コードを変換します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        public int Convert(object employeeConvertPrmObj, ref int numberOfTransactions)
        {
            // 処理ステータスを初期化します。
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // コード変換条件格納用の変数
            EmployeeConvertParamInfoList prmWrkList = employeeConvertPrmObj as EmployeeConvertParamInfoList;
            // SqlConnection変数
            SqlConnection sqlCon = null;
            // SqlTransaction変数
            SqlTransaction sqlTrn = null;

            // コンバート処理開始
            try
            {
                // DBと接続を行います。
                sqlCon = this.CreateConnection(true);
                // トランザクションを開始します。
                sqlTrn = this.CreateTransaction(ref sqlCon);
                // コンバートを実行します。
                status = this.ConvertProc(prmWrkList, sqlCon, sqlTrn, ref numberOfTransactions);
            }
            catch (Exception ex)
            {
                string errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errMsg, status);
            }
            finally
            {
                if (sqlTrn != null)
                {
                    sqlTrn.Dispose();
                }

                if (sqlCon != null)
                {
                    sqlCon.Close();
                    sqlCon.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// コード変換対象テーブルリスト取得処理
        /// </summary>
        /// <param name="targetTableList">コード変換対象テーブルリスト</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : コード変換対象のテーブルのリストを取得します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        public int GetConvertTableList(ref object targetTableList)
        {
            // 処理ステータスを初期化します。
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // XMLから更新対象のリストを取得します。
                status = this.GetTargetTableFromXml(ref targetTableList);
            }
            catch (Exception ex)
            {
                string errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errMsg, status);
            }

            return status;
        }

        /// <summary>
        /// 担当者マスタのリストを取得します。
        /// </summary>
        /// <param name="employeePrmObj">検索条件</param>
        /// <param name="employeeRetObjList">検索結果</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に担当者マスタのリストを取得します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        public int Search(object employeePrmObj, ref object employeeRetObjList)
        {
            // 処理ステータスを初期化します。
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // 抽出条件格納用の変数
            EmployeeSearchParamWork prmWk = employeePrmObj as EmployeeSearchParamWork;
            // 検索結果格納用の変数
            ArrayList employeeArrayList = new ArrayList();
            try
            {
                // DBからデータを取得します。
                using (SqlConnection sqlCon = this.CreateConnection(true))
                {
                    status = this.SearchProc(employeeArrayList, prmWk, sqlCon);
                }
            }
            catch (Exception ex)
            {
                string errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errMsg, status);
            }

            // 検索結果を格納
            employeeRetObjList = employeeArrayList;
            return status;
        }

        #endregion

        #region -- Private Method --

        #region -- 検索関連 --

        /// <summary>
        /// 担当者マスタのリストを取得します。
        /// </summary>
        /// <param name="resultList">検索結果</param>
        /// <param name="prmWk">検索条件</param>
        /// <param name="sqlCon">DB接続情報</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に担当者マスタのリストを取得します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        private int SearchProc(ArrayList resultList, EmployeeSearchParamWork prmWk, SqlConnection sqlCon)
        {
            // 処理ステータスを初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // 検索用のSQLを生成し、DBからデータを取得します。
                using (SqlCommand cmd = new SqlCommand(String.Empty, sqlCon))
                {
                    // クエリを設定
                    cmd.CommandText = this.GenerateSearchSql(prmWk, cmd);
                    // クエリを実行
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            resultList.Add(this.SetSearchResultToEmployeeSearchWork(rd));                            
                        }
                    }
                }
                status = resultList.Count == 0 ? (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND :
                    (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqle)
            {
                string errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(sqle, errMsg, sqle.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeConvertDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 担当者マスタ情報取得SQL作成処理。
        /// </summary>
        /// <param name="prmWk">検索条件</param>
        /// <param name="cmd">SqlCommandオブジェクト</param>
        /// <returns>SQL文</returns>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に検索用のSQL文を生成します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        private string GenerateSearchSql(EmployeeSearchParamWork prmWk, SqlCommand cmd)
        {
            // SQL文の生成
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Concat(
                "SELECT " + Environment.NewLine,
                " " + EmployeeRf.LogicDeleteCofrRf + " " + Environment.NewLine,
                " ," + EmployeeRf.EmployeeCodeRf + " " + Environment.NewLine,
                " ," + EmployeeRf.EmployeeNameRf + " " + Environment.NewLine,
                "FROM " + Environment.NewLine,
                " EMPLOYEERF " + Environment.NewLine 
                ));
            // WHERE句の生成
            sb.Append(this.GenerateSearchConditionSql(prmWk, cmd));
            // ORDER BY句の生成
            sb.Append(" ORDER BY " + Environment.NewLine);
            sb.Append("  " + EmployeeRf.EmployeeCodeRf + Environment.NewLine);

            return sb.ToString();
        }

        /// <summary>
        /// 画面で指定した条件を元に検索用のSQL文(WHERE句部分の作成)を生成します。
        /// </summary>
        /// <param name="prmWk">検索条件</param>
        /// <param name="cmd">SqlCommandオブジェクト</param>
        /// <returns>SQL文(抽出条件部分)</returns>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に検索用のSQL文(WHERE句部分の作成)を生成します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        private string GenerateSearchConditionSql(EmployeeSearchParamWork prmWk, SqlCommand cmd)
        {
            StringBuilder sb = new StringBuilder();

            // 企業コード
            sb.Append(" WHERE ");
            sb.Append("" + EmployeeRf.EnterpriseCodeRf + " = " + EmployeeRf.CndtnEnterpriseCode + Environment.NewLine);
            SqlParameter prmEnterPriseCd = cmd.Parameters.Add(EmployeeRf.CndtnEnterpriseCode, SqlDbType.NChar);
            prmEnterPriseCd.Value = SqlDataMediator.SqlSetString(prmWk.EnterpriseCode);

            // 担当者コード(開始)、又は担当者コード(終了)のどちらかが条件として指定された場合、
            // 指定した担当者コードを抽出条件とします。
            if (!String.IsNullOrEmpty(prmWk.EmployeeCodeStart) || !String.IsNullOrEmpty(prmWk.EmployeeCodeEnd))
            {                
                // 担当者コード(開始)
                if (!String.IsNullOrEmpty(prmWk.EmployeeCodeStart))
                {
                    sb.Append(" AND " + EmployeeRf.EmployeeCodeRf + " >= " + EmployeeRf.CndtnEmployeeCodeSt + Environment.NewLine);
                    SqlParameter prm = cmd.Parameters.Add(EmployeeRf.CndtnEmployeeCodeSt, SqlDbType.NChar);
                    prm.Value = SqlDataMediator.SqlSetString(prmWk.EmployeeCodeStart);
                }

                // 担当者コード(終了)
                if (!String.IsNullOrEmpty(prmWk.EmployeeCodeEnd))
                {
                    sb.Append(" AND " + EmployeeRf.EmployeeCodeRf + " <= " + EmployeeRf.CndtnEmployeeCodeEd + Environment.NewLine);
                    SqlParameter prm = cmd.Parameters.Add(EmployeeRf.CndtnEmployeeCodeEd, SqlDbType.NChar);
                    prm.Value = SqlDataMediator.SqlSetString(prmWk.EmployeeCodeEnd);
                }
            }

            // 担当者コードAdminとSupportは除外します。
            sb.Append(" AND " + EmployeeRf.EmployeeCodeRf + " != " + EmployeeRf.CndtnEmployeeCodeAdmin);
            SqlParameter codeAdmin = cmd.Parameters.Add(EmployeeRf.CndtnEmployeeCodeAdmin, SqlDbType.NChar);
            codeAdmin.Value = EmployeeRf.EmployeeCodeAdmin;
            sb.Append(" AND " + EmployeeRf.EmployeeCodeRf + " != " + EmployeeRf.CndtnEmployeeCodeSupport);
            SqlParameter codeSuppor = cmd.Parameters.Add(EmployeeRf.CndtnEmployeeCodeSupport, SqlDbType.NChar);
            codeSuppor.Value = EmployeeRf.EmployeeCodeSupport;

            return sb.ToString();
        }

        /// <summary>
        /// 検索結果格納処理
        /// </summary>
        /// <param name="rd">ストリームデータ</param>
        /// <returns>検索結果</returns>
        /// <remarks>
        /// <br>Note       :検索結果をEmployeeSearchWorkに格納します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        private EmployeeSearchWork SetSearchResultToEmployeeSearchWork(SqlDataReader rd)
        {
            EmployeeSearchWork result = new EmployeeSearchWork();
            // 論理削除
            result.LogicalDelete = SqlDataMediator.SqlGetInt32(rd, rd.GetOrdinal(EmployeeRf.LogicDeleteCofrRf));
            // 担当者コード
            result.EmployeeCode = SqlDataMediator.SqlGetString(rd, rd.GetOrdinal(EmployeeRf.EmployeeCodeRf));
            // 担当者名称
            result.EmployeeName = SqlDataMediator.SqlGetString(rd, rd.GetOrdinal(EmployeeRf.EmployeeNameRf));

            return result;
        }

        #endregion

        #region -- コード変換関連 --

        /// <summary>
        /// コード変換処理
        /// </summary>
        /// <param name="prmWorkList">変換条件</param>
        /// <param name="sqlCon">SqlConnectionオブジェクト</param>
        /// <param name="sqlTran">SqlTransactionオブジェクト</param>
        /// <param name="numberOfTransactions">処理件数を格納した変数</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に担当者コードを変換します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        private int ConvertProc(EmployeeConvertParamInfoList prmWrkList, SqlConnection sqlCon, 
            SqlTransaction sqlTran, ref int numberOfTransactions)
        {
            // ステータスを初期化します。
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // 指定したテーブルのデータをコンバートします。
                using (SqlCommand cmd = new SqlCommand(String.Empty, sqlCon, sqlTran))
                {
                    // タイムアウトの設定
                    cmd.CommandTimeout = this.DB_TIME_OUT;
                    // SQLを生成して実行します。
                    cmd.CommandText = this.GenerateUpdateSql(prmWrkList.EmployeeConvertParamWorkList, 
                        prmWrkList.TargetTable, prmWrkList.ColumnList, cmd);
                    numberOfTransactions = cmd.ExecuteNonQuery();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException sqle)
            {
                // 基底クラスに例外を渡して処理してもらいます。
                status = base.WriteSQLErrorLog(sqle);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeConvertDB ConvertProc Excepton" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // 処理が成功した場合はコミット、失敗した場合はロールバックを実施します。
                if (status == 0)
                {
                    sqlTran.Commit();
                }
                else
                {
                    sqlTran.Rollback();
                }
            }

            return status;
        }

        /// <summary>
        /// コード変換用SQL作成処理
        /// </summary>
        /// <param name="prmWorkList">変換条件のリスト</param>
        /// <param name="columnList">更新対象カラムリスト</param>
        /// <param name="trgTblNm">更新対象テーブル</param>
        /// <param name="cmd">SqlCommandオブジェクト</param>
        /// <returns>コード変換用SQL</returns>
        /// <remarks>
        /// <br>Note       : コード変換するためのSQLを生成します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        private string GenerateUpdateSql(IList<EmployeeConvertParamWork> prmWrkList, string trgTblNm,
            IList<string> columnList, SqlCommand cmd)
        {
            SqlParameter prm;
            string prmStrBf;
            string prmStrAf;
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE " + Environment.NewLine);
            sb.Append("  " + trgTblNm + Environment.NewLine);
            sb.Append(" SET " + Environment.NewLine);
            for (int i = 0; i < columnList.Count; i++)
            {
                if (i != 0)
                {
                    sb.Append(", ");
                }
                sb.Append(columnList[i] + " = (" + Environment.NewLine);
                sb.Append(" CASE " + Environment.NewLine);
                int index = 1;
                for (int j = 0; j < prmWrkList.Count; j++)
                {
                    // パラメータ変数の準備
                    // 変更前の担当者コード用のパラメータ変数
                    prmStrBf = String.Concat(EmployeeRf.CndtnEmployeeCodeBf, columnList[i], index);
                    // 変更後の担当者コード用のパラメータ変数
                    prmStrAf = String.Concat(EmployeeRf.CndtnEmployeeCodeAf, columnList[i], index++);
                    sb.Append(" WHEN " + columnList[i] + " = " + prmStrBf + " THEN " + prmStrAf + Environment.NewLine);

                    // 変更前コードのパラメータのセット
                    prm = cmd.Parameters.Add(prmStrBf, SqlDbType.NChar);
                    prm.Value = SqlDataMediator.SqlSetString(prmWrkList[j].BfEmployeeCode);
                    // 変更後コードのパラメータのセット
                    prm = cmd.Parameters.Add(prmStrAf, SqlDbType.NChar);
                    prm.Value = SqlDataMediator.SqlSetString(prmWrkList[j].AfEmployeeCode);
                }
                sb.Append("  ELSE " + columnList[i] + Environment.NewLine);
                sb.Append(" END " + Environment.NewLine);
                sb.Append(" )");
            }

            // WHERE句の生成
            sb.Append(" WHERE ");
            for (int i = 0; i < columnList.Count; i++)
            {
                if (i != 0)
                {
                    sb.Append(" OR ");
                }
                int index = 1;
                sb.Append(columnList[i] + " IN (");
                for (int j = 0; j < prmWrkList.Count; j++)
                {
                    if (j != 0)
                    {
                        sb.Append(",");
                    }
                    sb.Append(String.Concat(EmployeeRf.CndtnEmployeeCodeBf, columnList[i], index++));
                }
                sb.Append(")");
            }
            sb.Append(";");

            return sb.ToString();
        }

        #endregion

        #region -- 担当者コード変換対象テーブルリスト取得処理関連 --

        /// <summary>
        /// 対象テーブル情報XML読み取り処理
        /// </summary
        /// <param name="targetTableList">更新対象テーブル情報を格納する変数</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : XMLから変換対象となるテーブル情報を読み取ります。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        private int GetTargetTableFromXml(ref object targetTableList)
        {
            // 処理ステータスを初期化します
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // XMLからデータを読み取ります
            IDictionary<string, EmployeeTargetTableList> trgTblMap = targetTableList as IDictionary<string, EmployeeTargetTableList>;
            using (MemoryStream fs = XMLEmployeeConvertList.ms())
            {
                // XMLをデシリアライズします。
                XmlSerializer serializer = new XmlSerializer(typeof(ArrayOfEmployeeConvertList));
                ArrayOfEmployeeConvertList arryEmplyCnvList = (ArrayOfEmployeeConvertList)serializer.Deserialize(fs);
                // key:テーブル名、value:カラムのリストとなるマップを作成します。
                string tmpTblNm = String.Empty;
                foreach (EmployeeConvertList employeeCnvList in arryEmplyCnvList.EmployeeConvertList)
                {
                    tmpTblNm = employeeCnvList.TargetTable.Trim().ToUpper();
                    if (String.IsNullOrEmpty(tmpTblNm))
                    {
                        // テーブル名が空、もしくはnullの場合は異常データである為、処理を打ち切り
                        return this.ILLEGAL_DATA;
                    }
                    else if (!trgTblMap.ContainsKey(tmpTblNm))
                    {
                        trgTblMap[tmpTblNm] = new EmployeeTargetTableList();
                        // 対象テーブル名(物理名)
                        trgTblMap[tmpTblNm].TargetTable = tmpTblNm;
                        // 対象テーブル名(論理名)
                        trgTblMap[tmpTblNm].TargetTableName = employeeCnvList.TargetTableName.Trim();
                        // 対象カラム名(物理名)を保存するリスト
                        trgTblMap[tmpTblNm].ColumnList = new List<string>();
                    }
                    // 対象カラム名(物理名)
                    string tmpClmn = employeeCnvList.TargetColumn.Trim().ToUpper();
                    if (String.IsNullOrEmpty(tmpClmn))
                    {
                        // カラム名が空、もしくはnullの場合は異常データである為、処理を打ち切り
                        return this.ILLEGAL_DATA;
                    }
                    trgTblMap[tmpTblNm].ColumnList.Add(tmpClmn);
                }
                
                if (trgTblMap.Count == 0)
                {
                    // trgTblMapが0件の場合は、変換対象のテーブルが無い為、ステータスをNO_DATAにします。
                    status = this.NO_DATA;
                }
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
            }

            return status;
        }

        #endregion

        #endregion

        #region -- Inner Class --

        /// <summary>
        /// 担当者マスタのカラム名を定義したクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 担当者マスタのカラム名を定義したクラスです。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        private class EmployeeRf
        {
            #region -- Member --

            /// <summary>企業コードのパラメータ変数を表す定数:@FINDENTERPRISECODERFED</summary>
            public const string CndtnEnterpriseCode = "@FINDENTERPRISECODERFED";
            /// <summary>担当者コード(開始)のパラメータ変数を表す定数:@FINDEMPLOYEECODERFST</summary>
            public const string CndtnEmployeeCodeSt = "@FINDEMPLOYEECODERFST";
            /// <summary>担当者コード(終了)のパラメータ変数を表す定数:@FINDEMPLOYEECODERFED</summary>
            public const string CndtnEmployeeCodeEd = "@FINDEMPLOYEECODERFED";
            /// <summary>担当者コード(Admin)のパラメータ変数を表す定数:@FINDCODEADMIN</summary>
            public const string CndtnEmployeeCodeAdmin = "@FINDCODEADMIN";
            /// <summary>担当者コード(Support)のパラメータ変数を表す定数:@FINDSUPPORT</summary>
            public const string CndtnEmployeeCodeSupport = "@FINDSUPPORT";

            /// <summary>パラメータで利用する変数名(変更前担当者コード用)</summary>
            public const string CndtnEmployeeCodeBf = "@FINDBF";
            /// <summary>パラメータで利用する変数名(変更後担当者コード用)</summary>
            public const string CndtnEmployeeCodeAf = "@FINDAF";

            /// <summary>論理削除フラグを表す定数：LOGICALDELETECODERF</summary>
            public const string LogicDeleteCofrRf = "LOGICALDELETECODERF";
            /// <summary>担当者コードを表す定数：EMPLOYEECODERF</summary>
            public const string EmployeeCodeRf = "EMPLOYEECODERF";
            /// <summary>担当者名称のカラム名を表す定数：NAMERF</summary>
            public const string EmployeeNameRf = "NAMERF";
            /// <summary>企業コードのカラム名を表す定数：ENTERPRISECODERF</summary>
            public const string EnterpriseCodeRf = "ENTERPRISECODERF";

            /// <summary>担当者コード、Adminを表す定数：Admin</summary>
            public const string EmployeeCodeAdmin = "Admin";
            /// <summary>担当者コード、Supportを表す定数：Support</summary>
            public const string EmployeeCodeSupport = "Support";

            #endregion
        }

        #endregion
    }
}
