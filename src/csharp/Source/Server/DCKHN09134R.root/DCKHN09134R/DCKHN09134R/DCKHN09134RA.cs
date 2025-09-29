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
// ↓ 2008.02.08 980081 a
using Broadleaf.Application.Common;
// ↑ 2008.02.08 980081 a

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 得意先マスタ(伝票管理)マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先マスタ(伝票管理)マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20081　疋田  勇人</br>
    /// <br>Date       : 2007.09.18</br>
    /// <br></br>
    /// <br>Update Note: 980081 山田 明友</br>
    /// <br>Date       : 2008.02.08</br>
    /// <br>             ローカルシンク対応</br>
    /// <br>Update Note: 20081 疋田 勇人</br>
    /// <br>Date       : 2008.05.26</br>
    /// <br>             ＰＭ.ＮＳ用に変更</br>
    /// <br>Update Note: caowj</br>
    /// <br>Date       : 2010.08.06</br>
    /// <br>             ＰＭ.ＮＳ１０１２用に変更</br>
    /// </remarks>
    [Serializable]
    // ↓ 2008.02.08 980081 a
    //public class CustSlipMngDB : RemoteDB, ICustSlipMngDB
    public class CustSlipMngDB : RemoteDB, ICustSlipMngDB, IGetSyncdataList
    // ↑ 2008.02.08 980081 a
    {
        /// <summary>
        /// 得意先マスタ(伝票管理)マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 20081　疋田  勇人</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        public CustSlipMngDB()
            :
            base("DCKHN09136D", "Broadleaf.Application.Remoting.ParamData.CustSlipMngWork", "CUSTSLIPMNGRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の得意先マスタ(伝票管理)マスタ情報LISTを戻します
        /// </summary>
        /// <param name="custslipmngWork">検索結果</param>
        /// <param name="paracustslipmngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先マスタ(伝票管理)マスタ情報LISTを戻します</br>
        /// <br>Programmer : 20081　疋田  勇人</br>
        /// <br>Date       : 2007.09.18</br>
        public int Search(out object custslipmngWork, object paracustslipmngWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            custslipmngWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchCustSlipMngProc(out custslipmngWork, paracustslipmngWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustSlipMngDB.Search");
                custslipmngWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 指定された条件の得意先マスタ(伝票管理)マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objcustslipmngWork">検索結果</param>
        /// <param name="paracustslipmngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先マスタ(伝票管理)マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081　疋田  勇人</br>
        /// <br>Date       : 2007.09.18</br>
        public int SearchCustSlipMngProc(out object objcustslipmngWork, object paracustslipmngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            CustSlipMngWork custslipmngWork = null; 

            ArrayList custslipmngWorkList = paracustslipmngWork as ArrayList;
            if (custslipmngWorkList == null)
            {
                custslipmngWork = paracustslipmngWork as CustSlipMngWork;
            }
            else
            {
                if (custslipmngWorkList.Count > 0)
                    custslipmngWork = custslipmngWorkList[0] as CustSlipMngWork;
            }

            int status = SearchCustSlipMngProc(out custslipmngWorkList, custslipmngWork, readMode, logicalMode, ref sqlConnection);
            objcustslipmngWork = custslipmngWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の得意先マスタ(伝票管理)マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="custslipmngWorkList">検索結果</param>
        /// <param name="custslipmngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先マスタ(伝票管理)マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081　疋田  勇人</br>
        /// <br>Date       : 2007.09.18</br>
		public int SearchCustSlipMngProc(out ArrayList custslipmngWorkList, CustSlipMngWork custslipmngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
		{
			return this.SearchCustSlipMngProcProc(out custslipmngWorkList, custslipmngWork, readMode, logicalMode, ref sqlConnection);
		}

        /// <summary>
        /// 指定された条件の得意先マスタ(伝票管理)マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="custslipmngWorkList">検索結果</param>
        /// <param name="custslipmngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先マスタ(伝票管理)マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081　疋田  勇人</br>
        /// <br>Date       : 2007.09.18</br>
		private int SearchCustSlipMngProcProc(out ArrayList custslipmngWorkList, CustSlipMngWork custslipmngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                // 2008.05.26 upd start ------------------------------>>
                //sqlCommand = new SqlCommand("SELECT * FROM CUSTSLIPMNGRF  ", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CUSTSLIP.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.DATAINPUTSYSTEMRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.SLIPPRTKINDRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlTxt += "    ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                sqlTxt += " FROM CUSTSLIPMNGRF CUSTSLIP" + Environment.NewLine;
                sqlTxt += " LEFT JOIN CUSTOMERRF CUST ON CUST.ENTERPRISECODERF=CUSTSLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    AND CUST.CUSTOMERCODERF=CUSTSLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.26 upd end --------------------------------<<

		        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, custslipmngWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToCustSlipMngWorkFromReader(ref myReader));

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
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            custslipmngWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の得意先マスタ(伝票管理)マスタを戻します
        /// </summary>
        /// <param name="parabyte">CustSlipMngWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先マスタ(伝票管理)マスタを戻します</br>
        /// <br>Programmer : 20081　疋田  勇人</br>
        /// <br>Date       : 2007.09.18</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                CustSlipMngWork custslipmngWork = new CustSlipMngWork();

                // XMLの読み込み
                custslipmngWork = (CustSlipMngWork)XmlByteSerializer.Deserialize(parabyte, typeof(CustSlipMngWork));
                if (custslipmngWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref custslipmngWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(custslipmngWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustSlipMngDB.Read");
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

        /// <summary>
        /// 指定された条件の得意先マスタ(伝票管理)マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="custslipmngWork">CustSlipMngWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先マスタ(伝票管理)マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081　疋田  勇人</br>
        /// <br>Date       : 2007.09.18</br>
		public int ReadProc(ref CustSlipMngWork custslipmngWork, int readMode, ref SqlConnection sqlConnection)
		{
			return this.ReadProcProc(ref custslipmngWork, readMode, ref sqlConnection);
		}

        /// <summary>
        /// 指定された条件の得意先マスタ(伝票管理)マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="custslipmngWork">CustSlipMngWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先マスタ(伝票管理)マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081　疋田  勇人</br>
        /// <br>Date       : 2007.09.18</br>
		private int ReadProcProc(ref CustSlipMngWork custslipmngWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            
            try        
            {
                //Selectコマンドの生成
                // 2008.05.26 upd start ------------------------------------------>>
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM CUSTSLIPMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection))
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CUSTSLIP.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.DATAINPUTSYSTEMRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.SLIPPRTKINDRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlTxt += "    ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                sqlTxt += " FROM CUSTSLIPMNGRF CUSTSLIP" + Environment.NewLine;
                sqlTxt += " LEFT JOIN CUSTOMERRF CUST ON CUST.ENTERPRISECODERF=CUSTSLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    AND CUST.CUSTOMERCODERF=CUSTSLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlTxt += " WHERE CUSTSLIP.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND CUSTSLIP.DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                sqlTxt += "    AND CUSTSLIP.SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                sqlTxt += "    AND CUSTSLIP.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                sqlTxt += "    AND CUSTSLIP.CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))    
                // 2008.05.26 upd end --------------------------------------------<<
                {
                    
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                    SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);  // 2008.05.26 add
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.EnterpriseCode);
                    findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.DataInputSystem);
                    findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.SlipPrtKind);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.SectionCode);              // 2008.05.26 add
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.CustomerCode);
                    
                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        custslipmngWork = CopyToCustSlipMngWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
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
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// 得意先マスタ(伝票管理)マスタ情報を登録、更新します
        /// </summary>
        /// <param name="custslipmngWork">CustSlipMngWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ(伝票管理)マスタ情報を登録、更新します</br>
        /// <br>Programmer : 20081　疋田  勇人</br>
        /// <br>Date       : 2007.09.18</br>
        public int Write(ref object custslipmngWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(custslipmngWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteCustSlipMngProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                custslipmngWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustSlipMngDB.Write(ref object custslipmngWork)");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 得意先マスタ(伝票管理)マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="custslipmngWorkList">CustSlipMngWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ(伝票管理)マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 20081　疋田  勇人</br>
        /// <br>Date       : 2007.09.18</br>
		public int WriteCustSlipMngProc(ref ArrayList custslipmngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.WriteCustSlipMngProcProc(ref custslipmngWorkList, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// 得意先マスタ(伝票管理)マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="custslipmngWorkList">CustSlipMngWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ(伝票管理)マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 20081　疋田  勇人</br>
        /// <br>Date       : 2007.09.18</br>
		private int WriteCustSlipMngProcProc(ref ArrayList custslipmngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string sqlTxt = string.Empty;  // 2008.05.26 add
            try
            {
                if (custslipmngWorkList != null)
                {
                    for (int i = 0; i < custslipmngWorkList.Count; i++)
                    {
                        CustSlipMngWork custslipmngWork = custslipmngWorkList[i] as CustSlipMngWork;

                        //Selectコマンドの生成
                        // 2008.05.26 upd start ----------------------------------------------------->>
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM CUSTSLIPMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection, sqlTransaction);
                        sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += " FROM CUSTSLIPMNGRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                        sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                        sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlTxt += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        sqlTxt = string.Empty;
                        // 2008.05.26 upd end -------------------------------------------------------<<

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                        SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);  // 2008.05.26 add
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.EnterpriseCode);
                        findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.DataInputSystem);
                        findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.SlipPrtKind);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.SectionCode);              // 2008.05.26 add 
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.CustomerCode);
                        
                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != custslipmngWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (custslipmngWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            // 2008.05.26 upd start -------------------------------------->>
                            //sqlCommand.CommandText = "UPDATE CUSTSLIPMNGRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , DATAINPUTSYSTEMRF=@DATAINPUTSYSTEM , SLIPPRTKINDRF=@SLIPPRTKIND , CUSTOMERCODERF=@CUSTOMERCODE , CUSTOMERSNMRF=@CUSTOMERSNM , SLIPPRTSETPAPERIDRF=@SLIPPRTSETPAPERID WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                            sqlTxt += "UPDATE CUSTSLIPMNGRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " , DATAINPUTSYSTEMRF=@DATAINPUTSYSTEM" + Environment.NewLine;
                            sqlTxt += " , SLIPPRTKINDRF=@SLIPPRTKIND" + Environment.NewLine;
                            sqlTxt += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlTxt += " , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                            sqlTxt += " , SLIPPRTSETPAPERIDRF=@SLIPPRTSETPAPERID" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                            sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                            sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlTxt += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            sqlTxt = string.Empty;
                            // 2008.05.26 upd end ----------------------------------------<<
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.EnterpriseCode);
                            findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.DataInputSystem);
                            findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.SlipPrtKind);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.SectionCode);        // 2008.05.26 add 
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.CustomerCode);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)custslipmngWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (custslipmngWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }
                            
                            //新規作成時のSQL文を生成
                            // 2008.05.26 upd start --------------------------------->>
                            //sqlCommand.CommandText = "INSERT INTO CUSTSLIPMNGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DATAINPUTSYSTEMRF, SLIPPRTKINDRF, CUSTOMERCODERF, CUSTOMERSNMRF, SLIPPRTSETPAPERIDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @DATAINPUTSYSTEM, @SLIPPRTKIND, @CUSTOMERCODE, @CUSTOMERSNM, @SLIPPRTSETPAPERID)";
                            sqlTxt += "INSERT INTO CUSTSLIPMNGRF" + Environment.NewLine;
                            sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                            sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                            sqlTxt += " )" + Environment.NewLine;
                            sqlTxt += " VALUES" + Environment.NewLine;
                            sqlTxt += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlTxt += "    ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += "    ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlTxt += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += "    ,@DATAINPUTSYSTEM" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPPRTKIND" + Environment.NewLine;
                            sqlTxt += "    ,@SECTIONCODE" + Environment.NewLine;
                            sqlTxt += "    ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPPRTSETPAPERID" + Environment.NewLine;
                            sqlTxt += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            sqlTxt = string.Empty;
                            // 2008.05.26 upd end -----------------------------------<<
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)custslipmngWork;
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
                        SqlParameter paraDataInputSystem = sqlCommand.Parameters.Add("@DATAINPUTSYSTEM", SqlDbType.Int);
                        SqlParameter paraSlipPrtKind = sqlCommand.Parameters.Add("@SLIPPRTKIND", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);  // 2008.05.26 add
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraSlipPrtSetPaperId = sqlCommand.Parameters.Add("@SLIPPRTSETPAPERID", SqlDbType.NChar);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custslipmngWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custslipmngWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(custslipmngWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(custslipmngWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(custslipmngWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.LogicalDeleteCode);
                        paraDataInputSystem.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.DataInputSystem);
                        paraSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.SlipPrtKind);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.SectionCode);         // 2008.05.26 add
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.CustomerCode);
                        paraSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(custslipmngWork.SlipPrtSetPaperId);
                        #endregion
                        
                        sqlCommand.ExecuteNonQuery();
                        al.Add(custslipmngWork);
                    }
                }
                
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            custslipmngWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 得意先マスタ(伝票管理)マスタ情報を論理削除します
        /// </summary>
        /// <param name="custslipmngWork">CustSlipMngWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ(伝票管理)マスタ情報を論理削除します</br>
        /// <br>Programmer : 20081　疋田  勇人</br>
        /// <br>Date       : 2007.09.18</br>
        public int LogicalDelete(ref object custslipmngWork)
        {
            return LogicalDeleteCustSlipMng(ref custslipmngWork, 0);
        }

        /// <summary>
        /// 論理削除得意先マスタ(伝票管理)マスタ情報を復活します
        /// </summary>
        /// <param name="custslipmngWork">CustSlipMngWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除得意先マスタ(伝票管理)マスタ情報を復活します</br>
        /// <br>Programmer : 20081　疋田  勇人</br>
        /// <br>Date       : 2007.09.18</br>
        public int RevivalLogicalDelete(ref object custslipmngWork)
        {
            return LogicalDeleteCustSlipMng(ref custslipmngWork, 1);
        }

        /// <summary>
        /// 得意先マスタ(伝票管理)マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="custslipmngWork">CustSlipMngWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ(伝票管理)マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 20081　疋田  勇人</br>
        /// <br>Date       : 2007.09.18</br>
        private int LogicalDeleteCustSlipMng(ref object custslipmngWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(custslipmngWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteCustSlipMngProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                string procModestr = "";
                if (procMode == 0)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";
                base.WriteErrorLog(ex, "CustSlipMngDB.LogicalDeleteCustSlipMng :" + procModestr);

                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 得意先マスタ(伝票管理)マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="custslipmngWorkList">CustSlipMngWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ(伝票管理)マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 20081　疋田  勇人</br>
        /// <br>Date       : 2007.09.18</br>
		public int LogicalDeleteCustSlipMngProc(ref ArrayList custslipmngWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.LogicalDeleteCustSlipMngProcProc(ref custslipmngWorkList, procMode, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// 得意先マスタ(伝票管理)マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="custslipmngWorkList">CustSlipMngWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ(伝票管理)マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 20081　疋田  勇人</br>
        /// <br>Date       : 2007.09.18</br>
		private int LogicalDeleteCustSlipMngProcProc(ref ArrayList custslipmngWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string sqlTxt = string.Empty;  // 2008.05.26 add 
            try
            {
                if (custslipmngWorkList != null)
                {
                    for (int i = 0; i < custslipmngWorkList.Count; i++)
                    {
                        CustSlipMngWork custslipmngWork = custslipmngWorkList[i] as CustSlipMngWork;

                        //Selectコマンドの生成
                        // 2008.05.26 upd start -------------------------------->>
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM CUSTSLIPMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection, sqlTransaction);
                        sqlTxt = string.Empty;
                        sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += " FROM CUSTSLIPMNGRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                        sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                        sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlTxt += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        // 2008.05.26 upd end ----------------------------------<<

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                        SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("FINDSECTIONCODE", SqlDbType.NChar);   // 2008.05.26 add
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.EnterpriseCode);
                        findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.DataInputSystem);
                        findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.SlipPrtKind);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.SectionCode);              // 2008.05.26 add
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.CustomerCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != custslipmngWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            // 2008.05.26 upd start ----------------------------------------->>
                            //sqlCommand.CommandText = "UPDATE CUSTSLIPMNGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                            sqlTxt = string.Empty;
                            sqlTxt += "UPDATE CUSTSLIPMNGRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                            sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                            sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlTxt += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.05.26 upd end -------------------------------------------<<
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.EnterpriseCode);
                            findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.DataInputSystem);
                            findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.SlipPrtKind);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.SectionCode);    // 2008.05.26 add
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.CustomerCode);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)custslipmngWork;
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
                        if (myReader.IsClosed == false) myReader.Close();

                        //論理削除モードの場合
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
                                sqlCommand.Cancel();
                                return status;
                            }
                            else if (logicalDelCd == 0) custslipmngWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else custslipmngWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) custslipmngWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custslipmngWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(custslipmngWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(custslipmngWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(custslipmngWork);
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
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            custslipmngWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 得意先マスタ(伝票管理)マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">得意先マスタ(伝票管理)マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 得意先マスタ(伝票管理)マスタ情報を物理削除します</br>
        /// <br>Programmer : 20081　疋田  勇人</br>
        /// <br>Date       : 2007.09.18</br>
        public int Delete(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(parabyte);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteCustSlipMngProc(paraList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustSlipMngDB.Delete");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// 得意先マスタ(伝票管理)マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="custslipmngWorkList">得意先マスタ(伝票管理)マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 得意先マスタ(伝票管理)マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 20081　疋田  勇人</br>
        /// <br>Date       : 2007.09.18</br>
		public int DeleteCustSlipMngProc(ArrayList custslipmngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.DeleteCustSlipMngProcProc(custslipmngWorkList, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// 得意先マスタ(伝票管理)マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="custslipmngWorkList">得意先マスタ(伝票管理)マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 得意先マスタ(伝票管理)マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 20081　疋田  勇人</br>
        /// <br>Date       : 2007.09.18</br>
		private int DeleteCustSlipMngProcProc(ArrayList custslipmngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlTxt = string.Empty; // 2008.05.26 add
            try
            {
                for (int i = 0; i < custslipmngWorkList.Count; i++)
                {
                    CustSlipMngWork custslipmngWork = custslipmngWorkList[i] as CustSlipMngWork;
                    // 2008.05.26 upd start ------------------------->>
                    //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM CUSTSLIPMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection, sqlTransaction);
                    sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += " FROM CUSTSLIPMNGRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                    sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                    sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                    sqlTxt += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                    sqlTxt = string.Empty;
                    // 2008.05.26 upd end ---------------------------<<

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                    SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);   // 2008.05.26 add
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.EnterpriseCode);
                    findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.DataInputSystem);
                    findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.SlipPrtKind);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.SectionCode);               // 2008.05.26 add
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.CustomerCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != custslipmngWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        // 2008.05.26 upd start ---------------------------------------->>
                        //sqlCommand.CommandText = "DELETE FROM CUSTSLIPMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += " FROM CUSTSLIPMNGRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                        sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                        sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlTxt += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        sqlTxt = string.Empty;
                        // 2008.05.26 upd end ------------------------------------------<<
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.EnterpriseCode);
                        findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.DataInputSystem);
                        findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.SlipPrtKind);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.SectionCode);  // 2008.05.26 add
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.CustomerCode);
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    sqlCommand.ExecuteNonQuery();                    
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion
        // ↓ 2008.02.08 980081 a
        #region [GetSyncdataList]
		/// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">Sync用データ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先マスタ(伝票管理)マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.08</br>
		public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
		{
			return this.GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
		}
		
		/// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">Sync用データ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先マスタ(伝票管理)マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.08</br>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                // 2008.05.26 upd start ------------------------------->>
                //sqlCommand = new SqlCommand("SELECT * FROM CUSTSLIPMNGRF ", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CUSTSLIP.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.DATAINPUTSYSTEMRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.SLIPPRTKINDRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlTxt += "    ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                sqlTxt += " FROM CUSTSLIPMNGRF CUSTSLIP" + Environment.NewLine;
                sqlTxt += " LEFT JOIN CUSTOMERRF CUST ON CUST.ENTERPRISECODERF=CUSTSLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    AND CUST.CUSTOMERCODERF=CUSTSLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.26 upd end ---------------------------------<<

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToCustSlipMngWorkFromReader(ref myReader));
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
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            arraylistdata = al;

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="syncServiceWork">Sync用データ</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.08</br>
        private string MakeSyncWhereString(ref SqlCommand sqlCommand, SyncServiceWork syncServiceWork)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;

            //企業コード
            retstring += "CUSTSLIP.ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

            //差分シンクの場合は更新日付の範囲指定
            if (syncServiceWork.Syncmode == 0)
            {
                wkstring = "AND CUSTSLIP.UPDATEDATETIMERF >= @FINDUPDATEDATETIMEST " + Environment.NewLine;
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                paraUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                wkstring = "AND CUSTSLIP.UPDATEDATETIMERF <= @FINDUPDATEDATETIMEED " + Environment.NewLine;
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }
            else
            {
                wkstring = "AND CUSTSLIP.UPDATEDATETIMERF <= @FINDUPDATEDATETIMEED " + Environment.NewLine;
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }

            return retstring;
        }
        #endregion
        // ↑ 2008.02.08 980081 a

	    #region [Where文作成処理]
	    /// <summary>
	    /// 検索条件文字列生成＋条件値設定
	    /// </summary>
	    /// <param name="sqlCommand">SqlCommandオブジェクト</param>
	    /// <param name="custslipmngWork">検索条件格納クラス</param>
	    /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
	    /// <returns>Where条件文字列</returns>
	    /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 20081　疋田  勇人</br>
        /// <br>Date       : 2007.09.18</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, CustSlipMngWork custslipmngWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //企業コード
            retstring += "CUSTSLIP.ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.EnterpriseCode);

		    // 論理削除区分
		    wkstring = "";
		    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData1)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData2)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData3))
		    {
                wkstring = "AND CUSTSLIP.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
		    }
		    else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData012))
		    {
                wkstring = "AND CUSTSLIP.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
		    }
		    if(wkstring != "")
		    {
			    retstring += wkstring;
			    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
			    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
		    }

            // データ入力システム
            if (custslipmngWork.DataInputSystem != 0)
            {
                retstring += "AND CUSTSLIP.DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM ";
                SqlParameter paraDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                paraDataInputSystem.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.DataInputSystem);
            }

            // 伝票印刷種別
            if (custslipmngWork.SlipPrtKind != 0)
            {
                retstring += "AND CUSTSLIP.SLIPPRTKINDRF=@FINDSLIPPRTKIND ";
                SqlParameter paraSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
                paraSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.SlipPrtKind);
            }

            // 2008.05.26 add start ------------------------------>>
            // 拠点コード
            if (custslipmngWork.SectionCode != string.Empty)
            {
                retstring += "AND CUSTSLIP.SECTIONCODERF=@FINDSECTIONCODE ";
                // ---DEL 2010/08/06 ------------------------------------------------------------>>>>>
                //SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);
                // ---DEL 2010/08/06 ------------------------------------------------------------<<<<<
                // ---UPD 2010/08/06 ------------------------------------------------------------>>>>>
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                // ---UPD 2010/08/06 ------------------------------------------------------------<<<<<
                paraSectionCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.SectionCode);
            }
            // 2008.05.26 add end --------------------------------<<

            // 得意先コード
            if (custslipmngWork.CustomerCode != 0)
            {
                retstring += "AND CUSTSLIP.CUSTOMERCODERF=@FINDCUSTOMERCODE ";
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.CustomerCode);
            }

		    return retstring;
		}
	    #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → CustSlipMngWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CustSlipMngWork</returns>
        /// <remarks>
        /// <br>Programmer : 20081　疋田  勇人</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        private CustSlipMngWork CopyToCustSlipMngWorkFromReader(ref SqlDataReader myReader)
        {
            CustSlipMngWork wkCustSlipMngWork = new CustSlipMngWork();

            #region クラスへ格納
            wkCustSlipMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
            wkCustSlipMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkCustSlipMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
            wkCustSlipMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkCustSlipMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkCustSlipMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkCustSlipMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkCustSlipMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkCustSlipMngWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
            wkCustSlipMngWork.SlipPrtKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRTKINDRF"));
            wkCustSlipMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkCustSlipMngWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkCustSlipMngWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkCustSlipMngWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
            #endregion

            return wkCustSlipMngWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 20081　疋田  勇人</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            CustSlipMngWork[] CustSlipMngWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is CustSlipMngWork)
                    {
                        CustSlipMngWork wkCustSlipMngWork = paraobj as CustSlipMngWork;
                        if (wkCustSlipMngWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkCustSlipMngWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            CustSlipMngWorkArray = (CustSlipMngWork[])XmlByteSerializer.Deserialize(byteArray, typeof(CustSlipMngWork[]));
                        }
                        catch (Exception) { }
                        if (CustSlipMngWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(CustSlipMngWorkArray);
                        }
                        else
                        {
                            try
                            {
                                CustSlipMngWork wkCustSlipMngWork = (CustSlipMngWork)XmlByteSerializer.Deserialize(byteArray, typeof(CustSlipMngWork));
                                if (wkCustSlipMngWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkCustSlipMngWork);
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
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 20081　疋田  勇人</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
