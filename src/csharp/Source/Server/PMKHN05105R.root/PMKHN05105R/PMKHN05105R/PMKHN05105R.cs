//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　倉庫マスタコード変換リモートオブジェクト
// プログラム概要   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//=====================================================================================//
// 履歴
//-------------------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/02/18  修正内容 : 新規作成
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
    /// 倉庫マスタコード変換リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 倉庫マスタコード変換の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/02/18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class WarehouseConvertDB : RemoteWithAppLockDB, IWarehouseConvertDB
    {

        #region -- Member --
        /// <summary>タイムアウトの値を表す定数：36000</summary>
        private readonly int DB_TIME_OUT = 36000;
        /// <summary>担当者コード変換対象ファイルに不正データが有ることを示す定数：997</summary>
        private readonly int ILLEGAL_DATA = 997;
        /// <summary>担当者コード変換対象ファイルにデータが無いことを示す定数：998</summary>
        private readonly int NO_DATA = 998;
        /// <summary>担当者コード変換対象ファイルが存在しないことを示す定数：999</summary>
        private readonly int NO_FILE = 999;
        
        #endregion

        #region -- Constructor --

        /// <summary>
        /// 倉庫マスタコード変換DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        public WarehouseConvertDB()
        {
        }

        #endregion

        #region -- Public Method -- 

        /// <summary>
        /// 倉庫マスタのリストを取得します。
        /// </summary>
        /// <param name="warehousePrmObj">検索条件</param>
        /// <param name="warehouseRetObjList">検索結果</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に倉庫マスタのリストを取得します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        public int Search(object warehousePrmObj, ref object warehouseRetObjList)
        {
            // 処理ステータスを初期化します。
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // 抽出条件格納用の変数
            WarehouseSearchParamWork prmWk = warehousePrmObj as WarehouseSearchParamWork;
            // 検索結果格納用の変数
            ArrayList warehouseArrayList = new ArrayList();            
            try
            {
                // DBからデータを取得します
                using (SqlConnection sqlCon = this.CreateConnection(true))
                {
                    status = this.SearchProc(warehouseArrayList, prmWk, sqlCon);
                }
            }
            catch (Exception ex)
            {
                string errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errMsg, status);
            }

            // 検索結果を格納
            warehouseRetObjList = warehouseArrayList;
            return status;
        }

        /// <summary>
        /// コード変換処理
        /// </summary>
        /// <param name="warehouseConvertPrmListObj">変換条件</param>
        /// <param name="numberOfTransactions">処理件数を格納した変数</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に倉庫コードを変換します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        public int Convert(object warehouseConvertPrmListObj, ref long numberOfTransactions)
        {
            // 処理ステータスを初期化します。
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // 変換条件格納用の変数
            WarehouseConvertPrmInfoList prmWorkList = (WarehouseConvertPrmInfoList)warehouseConvertPrmListObj;
            // SqlConnection変数
            SqlConnection sqlCon = null;
            // SqlTrancation変数
            SqlTransaction tran = null;

            // コンバート処理の開始
            try
            {
                // DBと接続を行います
                sqlCon = this.CreateConnection(true);
                // トランザクションを開始します
                tran = this.CreateTransaction(ref sqlCon);
                // コンバートを実行します
                status = this.ConvertProc(prmWorkList, sqlCon, tran, ref numberOfTransactions);
            }
            catch (Exception ex)
            {
                string errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errMsg, status);
            }
            finally
            {
                if (tran != null)
                {
                    tran.Dispose();
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
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        public int GetConvertTableList(ref object targetTableMap)
        {
            // 処理ステータスを初期化します。
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // XMLから更新対象のリストを取得します。
                status = this.GetTargetTableFromXml(ref targetTableMap);
            }
            catch (Exception ex)
            {
                string errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errMsg, status);
            }

            return status;
        }

        #endregion

        #region -- Private Method --

        #region -- 倉庫マスタ検索関連 --

        /// <summary>
        /// 倉庫マスタのリストを取得します。
        /// </summary>
        /// <param name="resultList">検索結果</param>
        /// <param name="prmWk">検索条件</param>
        /// <param name="sqlCon">DB接続情報</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に倉庫マスタのリストを取得します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private int SearchProc(ArrayList resultList, WarehouseSearchParamWork prmWk, SqlConnection sqlCon)
        {
            // 処理ステータスを初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // 検索用のSQLを生成し、検索を行います
                using (SqlCommand cmd = new SqlCommand())
                {
                    // 接続情報を設定
                    cmd.Connection = sqlCon;
                    // クエリを設定
                    cmd.CommandText = this.GenerateSearchSql(prmWk, cmd);
                    // クエリを実行
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            resultList.Add(this.SetSearchResultToWarehouseSearchWork(rd));
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
                base.WriteErrorLog(ex, "WarehouseConvertDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 倉庫マスタ情報取得SQL作成処理。
        /// </summary>
        /// <param name="prmWk">検索条件</param>
        /// <param name="cmd">SqlCommandオブジェクト</param>
        /// <returns>SQL文</returns>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に検索用のSQL文を生成します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private string GenerateSearchSql(WarehouseSearchParamWork prmWk, SqlCommand cmd)
        {
            // SQL文の生成
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Concat(
                "SELECT " + Environment.NewLine,
                "  LOGICALDELETECODERF " + Environment.NewLine,
                " ,WAREHOUSECODERF " + Environment.NewLine,
                " ,WAREHOUSENAMERF " + Environment.NewLine,
                "FROM " + Environment.NewLine,
                " WAREHOUSERF " + Environment.NewLine
                ));
            // WHERE句以下の生成
            sb.Append(this.GenerateSearchConditionSql(prmWk, cmd));
            // GROUP BY句の生成
            sb.Append(String.Concat(
                " ORDER BY " + Environment.NewLine,
                "  " + WarehouseRf.WarehouseCodeRf
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
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private string GenerateSearchConditionSql(WarehouseSearchParamWork prmWk, SqlCommand cmd)
        {
            StringBuilder sb = new StringBuilder();

            // 倉庫コード(開始)、又は倉庫コード(終了)のどちらかが条件として指定された場合
            // WHERE句を生成します。
            if (!String.IsNullOrEmpty(prmWk.WarehouseStCd) || !String.IsNullOrEmpty(prmWk.WarehouseEdCd))
            {
                // 企業コード
                sb.Append(" WHERE ");
                sb.Append("   ENTERPRISECODERF = " + WarehouseRf.CndtnEnterpriseCodeEd + Environment.NewLine);
                SqlParameter prmEnterPriseCd = cmd.Parameters.Add(WarehouseRf.CndtnEnterpriseCodeEd, SqlDbType.NChar);
                prmEnterPriseCd.Value = SqlDataMediator.SqlSetString(prmWk.EnterPriseCode);

                // 倉庫コード(開始)
                if (!String.IsNullOrEmpty(prmWk.WarehouseStCd))
                {
                    sb.Append("  AND WAREHOUSECODERF >= " + WarehouseRf.CndtnWarehouseCodeSt + Environment.NewLine);
                    SqlParameter prm = cmd.Parameters.Add(WarehouseRf.CndtnWarehouseCodeSt, SqlDbType.NChar);
                    prm.Value = SqlDataMediator.SqlSetString(prmWk.WarehouseStCd);
                }
                // 倉庫コード(終了)
                if (!String.IsNullOrEmpty(prmWk.WarehouseEdCd))
                {
                    sb.Append("  AND WAREHOUSECODERF <= " + WarehouseRf.CndtnWarehouseCodeEd + Environment.NewLine);
                    SqlParameter prm = cmd.Parameters.Add(WarehouseRf.CndtnWarehouseCodeEd, SqlDbType.NChar);
                    prm.Value = SqlDataMediator.SqlSetString(prmWk.WarehouseEdCd);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 検索結果格納処理
        /// </summary>
        /// <param name="rd">ストリームデータ</param>
        /// <returns>検索結果</returns>
        /// <remarks>
        /// <br>Note       :検索結果をWarehouseSearchWorkに格納します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private WarehouseSearchWork SetSearchResultToWarehouseSearchWork(SqlDataReader rd)
        {
            WarehouseSearchWork result = new WarehouseSearchWork();

            // 論理削除
            result.LogicalDelete = (int)SqlDataMediator.SqlSetInt32(rd.GetInt32(rd.GetOrdinal(WarehouseRf.LogicalDeleteCodeRf)));
            // 倉庫コード
            result.WarehouseCd = SqlDataMediator.SqlGetString(rd, rd.GetOrdinal(WarehouseRf.WarehouseCodeRf));
            // 倉庫名称
            result.WarehouseNm = SqlDataMediator.SqlGetString(rd, rd.GetOrdinal(WarehouseRf.WarehouseNameRf));

            return result;
        }

        #endregion

        #region -- 倉庫コード変換 --

        /// <summary>
        /// コード変換処理
        /// </summary>
        /// <param name="prmWorkList">変換条件</param>
        /// <param name="sqlCon">SqlConnectionオブジェクト</param>
        /// <param name="sqlTran">SqlTransactionオブジェクト</param>
        /// <param name="numberOfTransactions">処理件数を格納した変数</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に倉庫コードを変換します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private int ConvertProc(WarehouseConvertPrmInfoList prmWorkList, SqlConnection sqlCon,
            SqlTransaction sqlTran, ref long numberOfTransactions)
        {
            // ステータスを初期化します
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // 更新対象のテーブル分、データのコンバートを行います。
                using (SqlCommand cmd = new SqlCommand(String.Empty, sqlCon, sqlTran))
                {
                    // タイムアウトの設定
                    cmd.CommandTimeout = this.DB_TIME_OUT;
                    // SQLを生成して実行します
                    cmd.CommandText = this.GenerateUpdateSql(prmWorkList.WarehouseConvertPrmWorkList, 
                        prmWorkList.TargetTable, prmWorkList.ColumnList, cmd);                    
                    long count = cmd.ExecuteNonQuery();
                    numberOfTransactions = count;
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理をしてもらいます
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "WarehouseConvertDB ConvertProc Exception" + ex.Message);
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
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private string GenerateUpdateSql(IList<WarehouseConvertPrmWork> prmWorkList, string trgTblNm, IList<string> columnList,
            SqlCommand cmd)
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
                for (int j = 0; j < prmWorkList.Count; j++)
                {
                    // パラメータ変数の準備
                    // 変換前の倉庫コード用のパラメータ変数
                    prmStrBf = String.Concat(WarehouseRf.CndtnWarehouseCodeBf, columnList[i], index);
                    // 変換後の倉庫コード用のパラメータ変数
                    prmStrAf = String.Concat(WarehouseRf.CndtnWarehouseCodeAf, columnList[i], index++);
                    sb.Append("  WHEN " + columnList[i] + " = " + prmStrBf + " THEN " + prmStrAf + Environment.NewLine);

                    // 変更前コードのパラメータをセット
                    prm = cmd.Parameters.Add(prmStrBf, SqlDbType.NChar);
                    prm.Value = SqlDataMediator.SqlSetString(prmWorkList[j].BfWarehouseCode);    
                    // 変更後コードのパラメータをセット
                    prm = cmd.Parameters.Add(prmStrAf, SqlDbType.NChar);
                    prm.Value = SqlDataMediator.SqlSetString(prmWorkList[j].AfWarehouseCode);
                }
                sb.Append("  ELSE " + columnList[i] + Environment.NewLine);
                sb.Append(" END " + Environment.NewLine);
                sb.Append(" ) ");
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
                for (int j = 0; j < prmWorkList.Count; j++)
                {
                    if (j != 0)
                    {
                        sb.Append(",");
                    }
                    sb.Append(String.Concat(WarehouseRf.CndtnWarehouseCodeBf, columnList[i], index++));
                }
                sb.Append(")");
            }

            sb.Append(";");
            
            return sb.ToString();
        }

        #endregion

        #region -- 倉庫コード変換対象テーブルリスト取得関連 --

        /// <summary>
        /// 対象テーブル情報XML読み取り処理
        /// </summary
        /// <param name="targetTableList">更新対象テーブル情報を格納する変数</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : XMLから変換対象となるテーブル情報を読み取ります。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private int GetTargetTableFromXml(ref object targetTableList)
        {
            // 処理ステータスを初期化します
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // XMLからデータを読み取ります。
            IDictionary<string, WarehouseTargetTableList> trgTblMap = targetTableList as IDictionary<string, WarehouseTargetTableList>;
            using (MemoryStream fs = XMLWarehouseConvertList.ms())
            {
                // XMLをデシリアライズします。
                XmlSerializer serializer = new XmlSerializer(typeof(ArrayOfWarehouseConvertList));
                ArrayOfWarehouseConvertList arryWarehouseCnvList = (ArrayOfWarehouseConvertList)serializer.Deserialize(fs);
                // key:テーブル名、value:カラムのリストとなるマップを作成します。
                string tmpTblNm = String.Empty;                
                foreach (WarehouseConvertList warehouseCnvList in arryWarehouseCnvList.WarehouseConvertList)
                {
                    tmpTblNm = warehouseCnvList.TargetTable.Trim().ToUpper();
                    if (String.IsNullOrEmpty(tmpTblNm))
                    {
                        // テーブル名が空、もしくはnullの場合は異常データである為、処理を打ち切り
                        return this.ILLEGAL_DATA;
                    }
                    else if (!trgTblMap.ContainsKey(tmpTblNm))
                    {
                        trgTblMap[tmpTblNm] = new WarehouseTargetTableList();
                        // テーブル名(物理名)
                        trgTblMap[tmpTblNm].TargetTable = tmpTblNm;
                        // テーブル名(論理名)
                        trgTblMap[tmpTblNm].TargetTableName = warehouseCnvList.TargetTableName.Trim();
                        // カラム名(物理名)のリスト
                        trgTblMap[tmpTblNm].ColumnList = new List<string>();
                    }
                    // カラム名(物理名)
                    string tmpClmn = warehouseCnvList.TargetColumn.Trim().ToUpper();
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
        /// 倉庫マスタのカラム名を定義したクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 倉庫マスタのカラム名を定義したクラスです。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private class WarehouseRf
        {
            #region -- Member -- 

            /// <summary>企業コードのパラメータ変数を表す定数:@ENTERPRISECODERFED</summary>
            public const string CndtnEnterpriseCodeEd = "@FINDENTERPRISECODERFED";
            /// <summary>倉庫コード(開始)のパラメータ変数を表す定数:@WAREHOUSECODERF</summary>
            public const string CndtnWarehouseCodeSt = "@FINDWAREHOUSECODERFST";
            /// <summary>倉庫コード(終了)のパラメータ変数を表す定数:@WAREHOUSENAMERFED</summary>
            public const string CndtnWarehouseCodeEd = "@FINDWAREHOUSENAMERFED";

            /// <summary>パラメータで利用する変数名(変更前倉庫コード用)</summary>
            public const string CndtnWarehouseCodeBf = "@FINDBF";
            /// <summary>パラメータで利用する変数名(変更後倉庫コード用)</summary>
            public const string CndtnWarehouseCodeAf = "@FINDAF";

            public const string LogicalDeleteCodeRf = "LOGICALDELETECODERF";         
            /// <summary>倉庫コードのカラム名を表す定数</summary>
            public const string WarehouseCodeRf = "WAREHOUSECODERF";
            /// <summary>倉庫名称のカラム名を表す定数</summary>
            public const string WarehouseNameRf = "WAREHOUSENAMERF";

            #endregion
        }

        #endregion
    }
}
