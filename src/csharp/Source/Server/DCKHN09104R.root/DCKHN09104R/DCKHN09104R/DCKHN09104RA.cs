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
using Broadleaf.Library.Collections;
using Broadleaf.Application.Common;


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 掛率優先管理マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率優先管理マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20081　疋田　勇人</br>
    /// <br>Date       : 2007.09.14</br>
    /// <br></br>
    /// <br>Update Note: 980081 山田 明友</br>
    /// <br>Date       : 2008.02.07</br>
    /// <br>             ローカルシンク対応</br>
    /// </remarks>
    [Serializable]
    public class RateProtyMngDB : RemoteDB, IRateProtyMngDB, IGetSyncdataList
    {
        /// <summary>
        /// 掛率優先管理マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
        /// </remarks>
        public RateProtyMngDB()
            :
            base("DCKHN09106D", "Broadleaf.Application.Remoting.ParamData.RateProtyMngWork", "RATEPROTYMNGRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の掛率優先管理マスタ情報LISTを戻します
        /// </summary>
        /// <param name="objRateProtyMngWork">検索結果</param>
        /// <param name="paraRateProtyMngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率優先管理マスタ情報LISTを戻します</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
        public int Search(out object objRateProtyMngWork, object paraRateProtyMngWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            objRateProtyMngWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchProc(out objRateProtyMngWork, paraRateProtyMngWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RateProtyMngDB.Search");
                objRateProtyMngWork = new ArrayList();
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
        /// 指定された条件の掛率優先管理マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objRateProtyMngWork">検索結果</param>
        /// <param name="paraRateProtyMngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率優先管理マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
        public int SearchProc(out object objRateProtyMngWork, object paraRateProtyMngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            RateProtyMngWork wrkRateProtyMngWork = null;

            ArrayList RateProtyMngWorkList = paraRateProtyMngWork as ArrayList;
            if (RateProtyMngWorkList == null)
            {
                wrkRateProtyMngWork = paraRateProtyMngWork as RateProtyMngWork;
            }
            else
            {
                if (RateProtyMngWorkList.Count > 0)
                    wrkRateProtyMngWork = RateProtyMngWorkList[0] as RateProtyMngWork;
            }

            int status = SearchProc(out RateProtyMngWorkList, wrkRateProtyMngWork, readMode, logicalMode, ref sqlConnection);
            objRateProtyMngWork = RateProtyMngWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の掛率優先管理マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="RateProtyMngWorkList">検索結果</param>
        /// <param name="paraRateProtyMngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率優先管理マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
		public int SearchProc(out ArrayList RateProtyMngWorkList, RateProtyMngWork paraRateProtyMngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
		{
			return this.SearchProcProc(out RateProtyMngWorkList, paraRateProtyMngWork, readMode, logicalMode, ref sqlConnection);
		}

        /// <summary>
        /// 指定された条件の掛率優先管理マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="RateProtyMngWorkList">検索結果</param>
        /// <param name="paraRateProtyMngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率優先管理マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
		private int SearchProcProc(out ArrayList RateProtyMngWorkList, RateProtyMngWork paraRateProtyMngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                // SQL文を生成
                string sqlText = string.Empty;

                # region SELECT句生成

                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  RATE.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,RATE.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,RATE.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,RATE.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,RATE.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,RATE.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,RATE.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,RATE.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,RATE.SECTIONCODERF" + Environment.NewLine;
                sqlText += " ,RATE.UNITPRICEKINDRF" + Environment.NewLine;
                sqlText += " ,RATE.RATESETTINGDIVIDERF" + Environment.NewLine;
                sqlText += " ,RATE.RATEPRIORITYORDERRF" + Environment.NewLine;
                sqlText += " ,RATE.RATEMNGGOODSCDRF" + Environment.NewLine;
                sqlText += " ,RATE.RATEMNGGOODSNMRF" + Environment.NewLine;
                sqlText += " ,RATE.RATEMNGCUSTCDRF" + Environment.NewLine;
                sqlText += " ,RATE.RATEMNGCUSTNMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  RATEPROTYMNGRF AS RATE" + Environment.NewLine;
                # endregion

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                #region WHERE句生成

                sqlText += "WHERE" + Environment.NewLine;

                // 企業コード
                sqlText += "  RATE.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraRateProtyMngWork.EnterpriseCode);

                // 拠点コード
                if (string.IsNullOrEmpty(paraRateProtyMngWork.SectionCode))
                {
                    sqlText += "  AND RATE.SECTIONCODERF = RATE.SECTIONCODERF" + Environment.NewLine;
                }
                else
                {
                    sqlText += "  AND RATE.SECTIONCODERF = @FINDSECTIONCODERF" + Environment.NewLine;
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    findSectionCode.Value = SqlDataMediator.SqlSetString(paraRateProtyMngWork.SectionCode);
                }

                // 単価種類
                if (paraRateProtyMngWork.UnitPriceKind == 0)
                {
                    sqlText += "  AND RATE.UNITPRICEKINDRF = RATE.UNITPRICEKINDRF" + Environment.NewLine;
                }
                else
                {
                    sqlText += "  AND RATE.UNITPRICEKINDRF = @FINDUNITPRICEKIND" + Environment.NewLine;
                    SqlParameter findUnitPriceKind = sqlCommand.Parameters.Add("@FINDUNITPRICEKIND", SqlDbType.Int);
                    findUnitPriceKind.Value = SqlDataMediator.SqlSetInt32(paraRateProtyMngWork.UnitPriceKind);
                }

                // 掛率設定区分
                if (string.IsNullOrEmpty(paraRateProtyMngWork.RateSettingDivide))
                {
                    sqlText += "  AND RATE.RATESETTINGDIVIDERF = RATE.RATESETTINGDIVIDERF" + Environment.NewLine;
                }
                else
                {
                    sqlText += "  AND RATE.RATESETTINGDIVIDERF = @FINDRATESETTINGDIVIDE" + Environment.NewLine;
                    SqlParameter findRateSettingDivide = sqlCommand.Parameters.Add("@FINDRATESETTINGDIVIDE", SqlDbType.NChar);
                    findRateSettingDivide.Value = SqlDataMediator.SqlSetString(paraRateProtyMngWork.RateSettingDivide);
                }

                // 論理削除区分
                string wkstring = "";
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "  AND RATE.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                         (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "  AND RATE.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
                }

                if (wkstring != "")
                {
                    sqlText += wkstring;
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                #endregion

                sqlCommand.CommandText = sqlText;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToRateProtyMngWorkFromReader(ref myReader));

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
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            RateProtyMngWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の掛率優先管理マスタを戻します
        /// </summary>
        /// <param name="parabyte">RateProtyMngWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率優先管理マスタを戻します</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                RateProtyMngWork wrkRateProtyMngWork = new RateProtyMngWork();

                // XMLの読み込み
                wrkRateProtyMngWork = (RateProtyMngWork)XmlByteSerializer.Deserialize(parabyte, typeof(RateProtyMngWork));
                if (wrkRateProtyMngWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref wrkRateProtyMngWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(wrkRateProtyMngWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RateProtyMngDB.Read");
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
        /// 指定された条件の掛率優先管理マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="paraRateProtyMngWork">RateProtyMngWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>        
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率優先管理マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081 疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
		public int ReadProc(ref RateProtyMngWork paraRateProtyMngWork, int readMode, ref SqlConnection sqlConnection)
		{
			return this.ReadProcProc(ref paraRateProtyMngWork, readMode, ref sqlConnection);
		}

        /// <summary>
        /// 指定された条件の掛率優先管理マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="paraRateProtyMngWork">RateProtyMngWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>        
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率優先管理マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081 疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
		private int ReadProcProc(ref RateProtyMngWork paraRateProtyMngWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string sqlText = string.Empty;

                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   RATE.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,RATE.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,RATE.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,RATE.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,RATE.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,RATE.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,RATE.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,RATE.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,RATE.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  ,RATE.UNITPRICEKINDRF" + Environment.NewLine;
                sqlText += "  ,RATE.RATESETTINGDIVIDERF" + Environment.NewLine;
                sqlText += "  ,RATE.RATEPRIORITYORDERRF" + Environment.NewLine;
                sqlText += "  ,RATE.RATEMNGGOODSCDRF" + Environment.NewLine;
                sqlText += "  ,RATE.RATEMNGGOODSNMRF" + Environment.NewLine;
                sqlText += "  ,RATE.RATEMNGCUSTCDRF" + Environment.NewLine;
                sqlText += "  ,RATE.RATEMNGCUSTNMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  RATEPROTYMNGRF AS RATE" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  RATE.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND RATE.SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                sqlText += "  AND RATE.UNITPRICEKINDRF = @FINDUNITPRICEKIND" + Environment.NewLine;
                sqlText += "  AND RATE.RATESETTINGDIVIDERF = @FINDRATESETTINGDIVIDE" + Environment.NewLine;
                
                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaUnitPriceKind = sqlCommand.Parameters.Add("@FINDUNITPRICEKIND", SqlDbType.Int);
                    SqlParameter findParaRateSettingDivide = sqlCommand.Parameters.Add("@FINDRATESETTINGDIVIDE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraRateProtyMngWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(paraRateProtyMngWork.SectionCode);
                    findParaUnitPriceKind.Value = SqlDataMediator.SqlSetInt32(paraRateProtyMngWork.UnitPriceKind);
                    findParaRateSettingDivide.Value = SqlDataMediator.SqlSetString(paraRateProtyMngWork.RateSettingDivide);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        paraRateProtyMngWork = CopyToRateProtyMngWorkFromReader(ref myReader);
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
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [GetSyncdataList]
		/// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率優先管理マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
		public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
		{
			return this.GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
		}
		
		/// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率優先管理マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                // ↓ 2008.02.07 980081 a
                sqlCommand = new SqlCommand("", sqlConnection);
                // ↑ 2008.02.07 980081 a
                string sqlText = string.Empty;

                # region SELECT句生成
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  RATE.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,RATE.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,RATE.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,RATE.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,RATE.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,RATE.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,RATE.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,RATE.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,RATE.SECTIONCODERF" + Environment.NewLine;
                sqlText += " ,RATE.UNITPRICEKINDRF" + Environment.NewLine;
                sqlText += " ,RATE.RATESETTINGDIVIDERF" + Environment.NewLine;
                sqlText += " ,RATE.RATEPRIORITYORDERRF" + Environment.NewLine;
                sqlText += " ,RATE.RATEMNGGOODSCDRF" + Environment.NewLine;
                sqlText += " ,RATE.RATEMNGGOODSNMRF" + Environment.NewLine;
                sqlText += " ,RATE.RATEMNGCUSTCDRF" + Environment.NewLine;
                sqlText += " ,RATE.RATEMNGCUSTNMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  RATEPROTYMNGRF AS RATE" + Environment.NewLine;
                # endregion

                # region WHERE句生成
                sqlText += "WHERE" + Environment.NewLine;

                // 企業コード
                sqlText += "  RATE.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

                // 差分シンクの場合は更新日付の範囲指定
                if (syncServiceWork.Syncmode == 0)
                {
                    sqlText += "  AND RATE.UPDATEDATETIMERF >= @FINDUPDATEDATETIMEST ";
                    SqlParameter findUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                    findUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                    sqlText += "  AND RATE.UPDATEDATETIMERF <= @FINDUPDATEDATETIMEED ";
                    SqlParameter findUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                    findUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
                }
                else
                {
                    sqlText += "  AND RATE.UPDATEDATETIMERF <= @FINDUPDATEDATETIMEED ";
                    SqlParameter findUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                    findUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
                }
                # endregion
                // ↓ 2008.02.07 980081 a
                sqlCommand.CommandText = sqlText;
                // ↑ 2008.02.07 980081 a
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToRateProtyMngWorkFromReader(ref myReader));

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
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            arraylistdata = al;

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// 掛率優先管理マスタを登録、更新します
        /// </summary>
        /// <param name="objRateProtyMngWork">RateProtyMngWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率優先管理マスタを登録、更新します</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.08.10</br>
        public int Write(ref object objRateProtyMngWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(objRateProtyMngWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                objRateProtyMngWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RateProtyMngDB.Write(ref object objRateProtyMngWork)");
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
        /// 掛率優先管理マスタ情報を登録、更新します(外部からのSqlConnection と SqlTranactionを使用)
        /// </summary>
        /// <param name="RateProtyMngWorkList">RateProtyMngWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率優先管理マスタ情報を登録、更新します(外部からのSqlConnection と SqlTranactionを使用)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
		public int WriteProc(ref ArrayList RateProtyMngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.WriteProcProc(ref RateProtyMngWorkList, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// 掛率優先管理マスタ情報を登録、更新します(外部からのSqlConnection と SqlTranactionを使用)
        /// </summary>
        /// <param name="RateProtyMngWorkList">RateProtyMngWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率優先管理マスタ情報を登録、更新します(外部からのSqlConnection と SqlTranactionを使用)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
		private int WriteProcProc(ref ArrayList RateProtyMngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (RateProtyMngWorkList != null)
                {
                    for (int i = 0; i < RateProtyMngWorkList.Count; i++)
                    {
                        RateProtyMngWork wrkRateProtyMngWork = RateProtyMngWorkList[i] as RateProtyMngWork;

                        //Selectコマンドの生成
                        string sqlText = string.Empty;

                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  RATE.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  RATEPROTYMNGRF AS RATE" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  RATE.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND RATE.SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                        sqlText += "  AND RATE.UNITPRICEKINDRF = @FINDUNITPRICEKIND" + Environment.NewLine;
                        sqlText += "  AND RATE.RATESETTINGDIVIDERF = @FINDRATESETTINGDIVIDE" + Environment.NewLine;

                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaUnitPriceKind = sqlCommand.Parameters.Add("@FINDUNITPRICEKIND", SqlDbType.Int);
                        SqlParameter findParaRateSettingDivide = sqlCommand.Parameters.Add("@FINDRATESETTINGDIVIDE", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.SectionCode);
                        findParaUnitPriceKind.Value = SqlDataMediator.SqlSetInt32(wrkRateProtyMngWork.UnitPriceKind);
                        findParaRateSettingDivide.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.RateSettingDivide);

                        myReader = sqlCommand.ExecuteReader();

                        sqlText = string.Empty;

                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != wrkRateProtyMngWork.UpdateDateTime)
                            {
                                if (wrkRateProtyMngWork.UpdateDateTime == DateTime.MinValue)
                                {
                                    //新規登録で該当データ有りの場合には重複
                                    status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                }
                                else
                                {
                                    //既存データで更新日時違いの場合には排他
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                }

                                return status;
                            }

                            // 更新時のSQL文を生成
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  RATEPROTYMNGRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,SECTIONCODERF = @SECTIONCODE" + Environment.NewLine;
                            sqlText += " ,UNITPRICEKINDRF = @UNITPRICEKIND" + Environment.NewLine;
                            sqlText += " ,RATESETTINGDIVIDERF = @RATESETTINGDIVIDE" + Environment.NewLine;
                            sqlText += " ,RATEPRIORITYORDERRF = @RATEPRIORITYORDER" + Environment.NewLine;
                            sqlText += " ,RATEMNGGOODSCDRF = @RATEMNGGOODSCD" + Environment.NewLine;
                            sqlText += " ,RATEMNGGOODSNMRF = @RATEMNGGOODSNM" + Environment.NewLine;
                            sqlText += " ,RATEMNGCUSTCDRF = @RATEMNGCUSTCD" + Environment.NewLine;
                            sqlText += " ,RATEMNGCUSTNMRF = @RATEMNGCUSTNM" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                            sqlText += "  AND UNITPRICEKINDRF = @FINDUNITPRICEKIND" + Environment.NewLine;
                            sqlText += "  AND RATESETTINGDIVIDERF = @FINDRATESETTINGDIVIDE" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.SectionCode);
                            findParaUnitPriceKind.Value = SqlDataMediator.SqlSetInt32(wrkRateProtyMngWork.UnitPriceKind);
                            findParaRateSettingDivide.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.RateSettingDivide);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)wrkRateProtyMngWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (wrkRateProtyMngWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            //新規作成時のSQL文を生成
                            sqlText += "INSERT INTO RATEPROTYMNGRF" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,SECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,UNITPRICEKINDRF" + Environment.NewLine;
                            sqlText += " ,RATESETTINGDIVIDERF" + Environment.NewLine;
                            sqlText += " ,RATEPRIORITYORDERRF" + Environment.NewLine;
                            sqlText += " ,RATEMNGGOODSCDRF" + Environment.NewLine;
                            sqlText += " ,RATEMNGGOODSNMRF" + Environment.NewLine;
                            sqlText += " ,RATEMNGCUSTCDRF" + Environment.NewLine;
                            sqlText += " ,RATEMNGCUSTNMRF" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;
                            sqlText += "VALUES" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@SECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@UNITPRICEKIND" + Environment.NewLine;
                            sqlText += " ,@RATESETTINGDIVIDE" + Environment.NewLine;
                            sqlText += " ,@RATEPRIORITYORDER" + Environment.NewLine;
                            sqlText += " ,@RATEMNGGOODSCD" + Environment.NewLine;
                            sqlText += " ,@RATEMNGGOODSNM" + Environment.NewLine;
                            sqlText += " ,@RATEMNGCUSTCD" + Environment.NewLine;
                            sqlText += " ,@RATEMNGCUSTNM" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)wrkRateProtyMngWork;
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
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraUnitPriceKind = sqlCommand.Parameters.Add("@UNITPRICEKIND", SqlDbType.Int);
                        SqlParameter paraRateSettingDivide = sqlCommand.Parameters.Add("@RATESETTINGDIVIDE", SqlDbType.NChar);
                        SqlParameter paraRatePriorityOrder = sqlCommand.Parameters.Add("@RATEPRIORITYORDER", SqlDbType.NVarChar);
                        SqlParameter paraRateMngGoodsCd = sqlCommand.Parameters.Add("@RATEMNGGOODSCD", SqlDbType.NChar);
                        SqlParameter paraRateMngGoodsNm = sqlCommand.Parameters.Add("@RATEMNGGOODSNM", SqlDbType.NVarChar);
                        SqlParameter paraRateMngCustCd = sqlCommand.Parameters.Add("@RATEMNGCUSTCD", SqlDbType.NVarChar);
                        SqlParameter paraRateMngCustNm = sqlCommand.Parameters.Add("@RATEMNGCUSTNM", SqlDbType.NVarChar);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(wrkRateProtyMngWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(wrkRateProtyMngWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(wrkRateProtyMngWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(wrkRateProtyMngWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.SectionCode);
                        paraUnitPriceKind.Value = SqlDataMediator.SqlSetInt32(wrkRateProtyMngWork.UnitPriceKind);
                        paraRateSettingDivide.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.RateSettingDivide);
                        paraRatePriorityOrder.Value = SqlDataMediator.SqlSetInt32(wrkRateProtyMngWork.RatePriorityOrder);
                        paraRateMngGoodsCd.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.RateMngGoodsCd);
                        paraRateMngGoodsNm.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.RateMngGoodsNm);
                        paraRateMngCustCd.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.RateMngCustCd);
                        paraRateMngCustNm.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.RateMngCustNm);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(wrkRateProtyMngWork);
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
                {
                    if (myReader.IsClosed == false)
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

            RateProtyMngWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 掛率優先管理マスタ情報を論理削除します
        /// </summary>
        /// <param name="objRateProtyMngWork">RateProtyMngWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率優先管理マスタ情報を論理削除します</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
        public int LogicalDelete(ref object objRateProtyMngWork)
        {
            return LogicalDeleteProc(ref objRateProtyMngWork, 0);
        }

        /// <summary>
        /// 論理削除掛率優先管理マスタ情報を復活します
        /// </summary>
        /// <param name="objRateProtyMngWork">RateProtyMngWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除掛率優先管理マスタ情報を復活します</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
        public int RevivalLogicalDelete(ref object objRateProtyMngWork)
        {
            return LogicalDeleteProc(ref objRateProtyMngWork, 1);
        }

        /// <summary>
        /// 掛率優先管理マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="objRateProtyMngWork">RateProtyMngWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率優先管理マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.08.10</br>
        private int LogicalDeleteProc(ref object objRateProtyMngWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(objRateProtyMngWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "RateProtyMngDB.LogicalDeleteEjibaiRtDt :" + procModestr);

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
        /// 掛率優先管理マスタ情報の論理削除を操作します(外部からのSqlConnection と SqlTranactionを使用)
        /// </summary>
        /// <param name="RateProtyMngWorkList">RateProtyMngWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率優先管理マスタ情報の論理削除を操作します(外部からのSqlConnection と SqlTranactionを使用)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.08.10</br>
		public int LogicalDeleteProc(ref ArrayList RateProtyMngWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.LogicalDeleteProcProc(ref RateProtyMngWorkList, procMode, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// 掛率優先管理マスタ情報の論理削除を操作します(外部からのSqlConnection と SqlTranactionを使用)
        /// </summary>
        /// <param name="RateProtyMngWorkList">RateProtyMngWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率優先管理マスタ情報の論理削除を操作します(外部からのSqlConnection と SqlTranactionを使用)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.08.10</br>
		private int LogicalDeleteProcProc(ref ArrayList RateProtyMngWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (RateProtyMngWorkList != null)
                {
                    for (int i = 0; i < RateProtyMngWorkList.Count; i++)
                    {
                        RateProtyMngWork wrkRateProtyMngWork = RateProtyMngWorkList[i] as RateProtyMngWork;

                        //Selectコマンドの生成
                        string sqlText = string.Empty;

                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  RATE.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,RATE.LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  RATEPROTYMNGRF AS RATE" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  RATE.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND RATE.SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                        sqlText += "  AND RATE.UNITPRICEKINDRF = @FINDUNITPRICEKIND" + Environment.NewLine;
                        sqlText += "  AND RATE.RATESETTINGDIVIDERF = @FINDRATESETTINGDIVIDE" + Environment.NewLine;

                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaUnitPriceKind = sqlCommand.Parameters.Add("@FINDUNITPRICEKIND", SqlDbType.Int);
                        SqlParameter findParaRateSettingDivide = sqlCommand.Parameters.Add("@FINDRATESETTINGDIVIDE", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.SectionCode);
                        findParaUnitPriceKind.Value = SqlDataMediator.SqlSetInt32(wrkRateProtyMngWork.UnitPriceKind);
                        findParaRateSettingDivide.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.RateSettingDivide);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時

                            if (_updateDateTime != wrkRateProtyMngWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  RATEPROTYMNGRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                            sqlText += "  AND UNITPRICEKINDRF = @FINDUNITPRICEKIND" + Environment.NewLine;
                            sqlText += "  AND RATESETTINGDIVIDERF = @FINDRATESETTINGDIVIDE" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.SectionCode);
                            findParaUnitPriceKind.Value = SqlDataMediator.SqlSetInt32(wrkRateProtyMngWork.UnitPriceKind);
                            findParaRateSettingDivide.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.RateSettingDivide);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)wrkRateProtyMngWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
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
                                return status;
                            }
                            else if (logicalDelCd == 0) wrkRateProtyMngWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else wrkRateProtyMngWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) wrkRateProtyMngWork.LogicalDeleteCode = 0;//論理削除フラグを解除
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
                                else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(wrkRateProtyMngWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(wrkRateProtyMngWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(wrkRateProtyMngWork);
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

            RateProtyMngWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 掛率優先管理マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">掛率優先管理マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 掛率優先管理マスタ情報を物理削除します</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
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

                status = DeleteProc(paraList, ref sqlConnection, ref sqlTransaction);

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
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RateProtyMngDB.Delete");
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
        /// 掛率優先管理マスタ情報を物理削除します(外部からのSqlConnection と SqlTranactionを使用)
        /// </summary>
        /// <param name="RateProtyMngWorkList">掛率優先管理マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 掛率優先管理マスタ情報を物理削除します(外部からのSqlConnection と SqlTranactionを使用)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
		public int DeleteProc(ArrayList RateProtyMngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.DeleteProcProc(RateProtyMngWorkList, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// 掛率優先管理マスタ情報を物理削除します(外部からのSqlConnection と SqlTranactionを使用)
        /// </summary>
        /// <param name="RateProtyMngWorkList">掛率優先管理マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 掛率優先管理マスタ情報を物理削除します(外部からのSqlConnection と SqlTranactionを使用)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
		private int DeleteProcProc(ArrayList RateProtyMngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < RateProtyMngWorkList.Count; i++)
                {
                    RateProtyMngWork wrkRateProtyMngWork = RateProtyMngWorkList[i] as RateProtyMngWork;

                    //Selectコマンドの生成
                    string sqlText = string.Empty;

                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  RATE.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  RATEPROTYMNGRF AS RATE" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  RATE.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND RATE.SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                    sqlText += "  AND RATE.UNITPRICEKINDRF = @FINDUNITPRICEKIND" + Environment.NewLine;
                    sqlText += "  AND RATE.RATESETTINGDIVIDERF = @FINDRATESETTINGDIVIDE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaUnitPriceKind = sqlCommand.Parameters.Add("@FINDUNITPRICEKIND", SqlDbType.Int);
                    SqlParameter findParaRateSettingDivide = sqlCommand.Parameters.Add("@FINDRATESETTINGDIVIDE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.SectionCode);
                    findParaUnitPriceKind.Value = SqlDataMediator.SqlSetInt32(wrkRateProtyMngWork.UnitPriceKind);
                    findParaRateSettingDivide.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.RateSettingDivide);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != wrkRateProtyMngWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        sqlText = string.Empty;

                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  RATEPROTYMNGRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                        sqlText += "  AND UNITPRICEKINDRF = @FINDUNITPRICEKIND" + Environment.NewLine;
                        sqlText += "  AND RATESETTINGDIVIDERF = @FINDRATESETTINGDIVIDE" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;

                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.SectionCode);
                        findParaUnitPriceKind.Value = SqlDataMediator.SqlSetInt32(wrkRateProtyMngWork.UnitPriceKind);
                        findParaRateSettingDivide.Value = SqlDataMediator.SqlSetString(wrkRateProtyMngWork.RateSettingDivide);
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
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
                {
                    if (!myReader.IsClosed == false)
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
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → RateProtyMngWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RateProtyMngWork</returns>
        /// <remarks>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
        /// </remarks>
        private RateProtyMngWork CopyToRateProtyMngWorkFromReader(ref SqlDataReader myReader)
        {
            RateProtyMngWork wkRateProtyMngWork = new RateProtyMngWork();

            #region クラスへ格納
            wkRateProtyMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkRateProtyMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkRateProtyMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkRateProtyMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkRateProtyMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkRateProtyMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkRateProtyMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkRateProtyMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkRateProtyMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkRateProtyMngWork.UnitPriceKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNITPRICEKINDRF"));
            wkRateProtyMngWork.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESETTINGDIVIDERF"));
            wkRateProtyMngWork.RatePriorityOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEPRIORITYORDERRF"));
            wkRateProtyMngWork.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSCDRF"));
            wkRateProtyMngWork.RateMngGoodsNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSNMRF"));
            wkRateProtyMngWork.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTCDRF"));
            wkRateProtyMngWork.RateMngCustNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTNMRF"));
            #endregion

            return wkRateProtyMngWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            RateProtyMngWork[] RateProtyMngWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is RateProtyMngWork)
                    {
                        RateProtyMngWork wkRateProtyMngWork = paraobj as RateProtyMngWork;
                        if (wkRateProtyMngWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkRateProtyMngWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            RateProtyMngWorkArray = (RateProtyMngWork[])XmlByteSerializer.Deserialize(byteArray, typeof(RateProtyMngWork[]));
                        }
                        catch (Exception) { }
                        if (RateProtyMngWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(RateProtyMngWorkArray);
                        }
                        else
                        {
                            try
                            {
                                RateProtyMngWork wkRateProtyMngWork = (RateProtyMngWork)XmlByteSerializer.Deserialize(byteArray, typeof(RateProtyMngWork));
                                if (wkRateProtyMngWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkRateProtyMngWork);
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
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
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
