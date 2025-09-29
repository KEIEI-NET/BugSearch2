//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　得意先マスタコード変換リモートオブジェクト
// プログラム概要   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//=====================================================================================//
// 履歴
//-------------------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/03/23  修正内容 : 新規作成
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
    /// 得意先マスタコード変換リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先マスタコード変換の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/03/23</br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class CustomerConvertDB : RemoteWithAppLockDB, ICustomerConvertDB
    {
        #region -- Member --

        #region -- Constant --

        /// <summary>テーブル・カラム情報を保存した設定ファイルのパス</summary>
        private const string TARGET_TABLE_INFO_XML = "CustomerConvertList.xml";
        /// <summary>タイムアウトの値を表す定数：36000</summary>
        private readonly int DB_TIME_OUT = 36000;
        /// <summary>得意先コード変換対象ファイルに不正データが有ることを示す定数：997</summary>
        private readonly int ILLEGAL_DATA = 997;
        /// <summary>得意先コード変換対象ファイルにデータが無いことを示す定数：998</summary>
        private readonly int NO_DATA = 998;
        /// <summary>得意先コード変換対象ファイルが存在しないことを示す定数：999</summary>
        private readonly int NO_FILE = 999;

        #endregion

        #endregion

        #region -- Constructor --

        /// <summary>
        /// 得意先マスタコード変換DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        public CustomerConvertDB()
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
        /// <br>Note       : 画面で指定した条件を元に得意先コードを変換します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        public int Convert(object customerConvertPrmObj, ref int numberOfTransactions)
        {
            // 処理ステータスを初期化します。
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // コード変換条件格納用の変数
            CustomerConvertParamInfoList prmWrkList = customerConvertPrmObj as CustomerConvertParamInfoList;
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
                status = this.ConverProc(prmWrkList, sqlCon, sqlTrn, ref numberOfTransactions);
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
        /// <br>Date       : 2016/03/23</br>
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
        /// 得意先マスタのリストを取得します。
        /// </summary>
        /// <param name="customerPrmObj">検索条件</param>
        /// <param name="customerRetObjList">検索結果</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に得意先マスタのリストを取得します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        public int Search(object customerPrmObj, ref object customerRetObjList)
        {
            // 処理ステータスを初期化します。
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // 抽出条件格納用の変数
            CustomerSearchParamWork prmWk = customerPrmObj as CustomerSearchParamWork;
            // 検索結果格納用の変数
            ArrayList customerArrayList = new ArrayList();
            try
            {
                // DBからデータを取得します。
                using (SqlConnection sqlCon = this.CreateConnection(true))
                {
                    status = this.SearchProc(customerArrayList, prmWk, sqlCon);
                }
            }
            catch (Exception ex)
            {
                string errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errMsg, status);
            }

            // 検索結果を格納
            customerRetObjList = customerArrayList;
            return status;
        }

        #endregion

        #region -- Private Method --

        #region -- 検索関連 --

        /// <summary>
        /// 得意先マスタのリストを取得します。
        /// </summary>
        /// <param name="resultList">検索結果</param>
        /// <param name="prmWk">検索条件</param>
        /// <param name="sqlCon">DB接続情報</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に得意先マスタのリストを取得します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private int SearchProc(ArrayList resultList, CustomerSearchParamWork prmWk, SqlConnection sqlCon)
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
                            resultList.Add(this.SetSearchResultToCustomerSearchWork(rd));
                        }
                    }
                    status = resultList.Count == 0 ? (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND :
                        (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException sqle)
            {
                string errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(sqle, errMsg, sqle.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustomerConvertDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 得意先マスタ情報取得SQL作成処理。
        /// </summary>
        /// <param name="prmWk">検索条件</param>
        /// <param name="cmd">SqlCommandオブジェクト</param>
        /// <returns>SQL文</returns>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に検索用のSQL文を生成します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private string GenerateSearchSql(CustomerSearchParamWork prmWk, SqlCommand cmd)
        {
            // SQL文の生成
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Concat(
                "SELECT " + Environment.NewLine,
                " "       + CustomerRf.LogicDeleteCofrRf + " " + Environment.NewLine,
                " ,"      + CustomerRf.CustomerCodeRf    + " " + Environment.NewLine,
                " ,"      + CustomerRf.CustomerNameRf    + " " + Environment.NewLine,
                "FROM "   + Environment.NewLine,
                " "       + CustomerRf.TblCustomerRf + " " + Environment.NewLine
                ));
            // WHERE句の生成
            sb.Append(this.GenerateSearchConditionSql(prmWk, cmd));
            // ORDER BY句の生成
            sb.Append(String.Concat(
                " ORDER BY " + Environment.NewLine,
                "  " + CustomerRf.CustomerCodeRf + Environment.NewLine
                ));

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
        private string GenerateSearchConditionSql(CustomerSearchParamWork prmWk, SqlCommand cmd)
        {
            StringBuilder sb = new StringBuilder();

            // 企業コード
            sb.Append(" WHERE ");
            sb.Append("" + CustomerRf.EnterpriseCodeRf + " = " + CustomerRf.CndtnEnterpriseCode + Environment.NewLine);
            SqlParameter prmEnterPriseCd = cmd.Parameters.Add(CustomerRf.CndtnEnterpriseCode, SqlDbType.NChar);
            prmEnterPriseCd.Value = SqlDataMediator.SqlSetString(prmWk.EnterpriseCode);

            // 得意先コード(開始)、又は得意先コード(終了)のどちらかが条件として指定された場合、
            // 指定した得意先コードを抽出条件とします。
            if (prmWk.CustomerCodeStart != 0 || prmWk.CustomerCodeEnd != 0)
            {
                // 得意先コード(開始)
                if (prmWk.CustomerCodeStart != 0)
                {
                    sb.Append(" AND " + CustomerRf.CustomerCodeRf + " >= " + CustomerRf.CndtnCustomerCodeSt + Environment.NewLine);
                    SqlParameter prm = cmd.Parameters.Add(CustomerRf.CndtnCustomerCodeSt, SqlDbType.NChar);
                    prm.Value = SqlDataMediator.SqlSetInt32(prmWk.CustomerCodeStart);
                }

                // 得意先コード(終了)
                if (prmWk.CustomerCodeEnd != 0)
                {
                    sb.Append(" AND " + CustomerRf.CustomerCodeRf + " <= " + CustomerRf.CndtnCustomerCodeEd + Environment.NewLine);
                    SqlParameter prm = cmd.Parameters.Add(CustomerRf.CndtnCustomerCodeEd, SqlDbType.NChar);
                    prm.Value = SqlDataMediator.SqlSetInt32(prmWk.CustomerCodeEnd);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 検索結果格納処理
        /// </summary>
        /// <param name="rd"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       :検索結果をWarehouseSearchWorkに格納します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private CustomerSearchWork SetSearchResultToCustomerSearchWork(SqlDataReader rd)
        {
            CustomerSearchWork result = new CustomerSearchWork();
            // 論理削除
            result.LogicalDelete = SqlDataMediator.SqlGetInt32(rd, rd.GetOrdinal(CustomerRf.LogicDeleteCofrRf));
            // 得意先コード
            result.CustomerCode = SqlDataMediator.SqlGetInt32(rd, rd.GetOrdinal(CustomerRf.CustomerCodeRf));
            // 得意先名称
            result.CustomerName = SqlDataMediator.SqlGetString(rd, rd.GetOrdinal(CustomerRf.CustomerNameRf));

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
        /// <br>Note       : 画面で指定した条件を元に得意先コードを変換します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private int ConverProc(CustomerConvertParamInfoList prmWrkList, SqlConnection sqlCon,
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
                    cmd.CommandText = this.GenerateUpdateSql(prmWrkList.CustomerConvertParamWorkList,
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
                base.WriteErrorLog(ex, "CustomerConvertDB ConvertProc Excepton" + ex.Message);
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
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private string GenerateUpdateSql(IList<CustomerConvertParamWork> prmWrkList, string trgTblNm,
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
                    sb.Append("," );
                }
                sb.Append(columnList[i] + " = (" + Environment.NewLine);
                sb.Append(" CASE " + Environment.NewLine);
                int index = 1;
                for (int j = 0; j < prmWrkList.Count; j++)
                {
                    // パラメータ変数の準備
                    // 変更前得意先コード用のパラメータ変数
                    prmStrBf = String.Concat(CustomerRf.CndtnCustomerCodeBf, columnList[i], index);
                    // 変更後得意先コード用のパラメータ変数
                    prmStrAf = String.Concat(CustomerRf.CndtnCustomerCodeAf, columnList[i], index++);
                    sb.Append(" WHEN " + columnList[i] + " = " + prmStrBf + " THEN " + prmStrAf + Environment.NewLine);

                    // 変更前得意先コードのパラメータをセット
                    prm = cmd.Parameters.Add(prmStrBf, SqlDbType.NChar);
                    prm.Value = SqlDataMediator.SqlSetInt32(prmWrkList[j].BfCustomerCode);
                    // 変更後得意先コードのパラメータをセット
                    prm = cmd.Parameters.Add(prmStrAf, SqlDbType.NChar);
                    prm.Value = SqlDataMediator.SqlSetInt32(prmWrkList[j].AfCustomerCode);
                }
                sb.Append("  ELSE " + columnList[i] + Environment.NewLine);
                sb.Append(" END " + Environment.NewLine);
                sb.Append(" )" + Environment.NewLine);
            }

            // WHERE句の生成
            sb.Append(" WHERE " + Environment.NewLine);
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
                    sb.Append(String.Concat(CustomerRf.CndtnCustomerCodeBf, columnList[i], index++));
                }
                sb.Append(")");
            }
            sb.Append(";");

            return sb.ToString();
        }

        #endregion

        #region -- 得意先コード変換対象テーブルリスト取得処理関連 --

        /// <summary>
        /// 対象テーブル情報XML読み取り処理
        /// </summary>
        /// <param name="targetTableList">更新対象テーブル情報を格納する変数</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : XMLから変換対象となるテーブル情報を読み取ります。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private int GetTargetTableFromXml(ref object targetTableList)
        {
            // 処理ステータスを初期化します。
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // XMLからデータを読み取ります。
            IDictionary<string, CustomerTargetTableList> trgTblMap = targetTableList as IDictionary<string, CustomerTargetTableList>;
            using (MemoryStream fs = XMLCustomerConvertList.ms())
            {
                // XMLをデシリアライズします。
                XmlSerializer serializer = new XmlSerializer(typeof(ArrayOfCustomerConvertList));
                ArrayOfCustomerConvertList arryCstmrCnvList = (ArrayOfCustomerConvertList)serializer.Deserialize(fs);
                // key:テーブル名、value:カラムのリストとなるマップを作成します。
                string tmpTblNm = String.Empty;
                foreach (CustomerConvertList customerCnvList in arryCstmrCnvList.CustomerConvertList)
                {
                    tmpTblNm = customerCnvList.TargetTable.Trim().ToUpper();
                    if (String.IsNullOrEmpty(tmpTblNm))
                    {
                        // テーブル名が空、もしくはnullの場合は異常データである為、処理を打ち切り
                        return this.ILLEGAL_DATA;
                    }
                    else if (!trgTblMap.ContainsKey(tmpTblNm))
                    {
                        // keyが無い場合は要素を作成
                        trgTblMap[tmpTblNm] = new CustomerTargetTableList();
                        // 対象テーブル名(物理名)
                        trgTblMap[tmpTblNm].TargetTable = tmpTblNm;
                        // 対象テーブル名(論理名)
                        trgTblMap[tmpTblNm].TargetTableName = customerCnvList.TargetTableName.Trim();
                        // 対象カラム名(物理名)を保存するリスト
                        trgTblMap[tmpTblNm].ColumnList = new List<string>();
                    }
                    // 対象カラム名(物理名)
                    string tmpClmn = customerCnvList.TargetColumn.Trim().ToUpper();
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
        /// 得意先マスタのカラム名を定義したクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先マスタのカラム名を定義したクラスです。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private class CustomerRf
        {
            #region -- Member --

            /// <summary>企業コードのパラメータ変数を表す定数:@FINDENTERPRISECODERFED</summary>
            public const string CndtnEnterpriseCode = "@FINDENTERPRISECODERFED";
            /// <summary>得意先コード(開始)のパラメータ変数を表す定数:@FINDCUSTOMERCODERFST</summary>
            public const string CndtnCustomerCodeSt = "@FINDCUSTOMERCODERFST";
            /// <summary>得意先コード(終了)のパラメータ変数を表す定数:@FINDCUSTOMERCODERFED</summary>
            public const string CndtnCustomerCodeEd = "@FINDCUSTOMERCODERFED";
            /// <summary>得意先コード(Admin)のパラメータ変数を表す定数:@FINDCODEADMIN</summary>
            public const string CndtnCustomerCodeAdmin = "@FINDCODEADMIN";
            /// <summary>得意先コード(Support)のパラメータ変数を表す定数:@FINDSUPPORT</summary>
            public const string CndtnCustomerCodeSupport = "@FINDSUPPORT";

            /// <summary>パラメータで利用する変数名(変更前得意先コード用)</summary>
            public const string CndtnCustomerCodeBf = "@FINDBF";
            /// <summary>パラメータで利用する変数名(変更後得意先コード用)</summary>
            public const string CndtnCustomerCodeAf = "@FINDAF";

            /// <summary>論理削除フラグを表す定数：LOGICALDELETECODERF</summary>
            public const string LogicDeleteCofrRf = "LOGICALDELETECODERF";
            /// <summary>得意先コードを表す定数：CUSTOMERCODERF</summary>
            public const string CustomerCodeRf = "CUSTOMERCODERF";
            /// <summary>得意先名称のカラム名を表す定数：NAMERF</summary>
            public const string CustomerNameRf = "NAMERF";
            /// <summary>企業コードのカラム名を表す定数：ENTERPRISECODERF</summary>
            public const string EnterpriseCodeRf = "ENTERPRISECODERF";

            /// <summary>テーブル名を表す定数：CUSTOMERRF</summary>
            public const string TblCustomerRf = "CUSTOMERRF";

            #endregion
        }

        #endregion

        #region ICustomerConvertDB メンバ

        #endregion
    }
}
