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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// SCM優先設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : SCM優先設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30350　櫻井　亮太</br>
    /// <br>Date       : 2009.05.12</br>
    /// <br>Update Note: 2011.08.08 lingxiaoqing</br>
    /// <br>             SCM優先設定マスタの実データ操作を変更</br>
    /// </remarks>
    [Serializable]
    public class SCMPriorStDB : RemoteDB, ISCMPriorStDB
    {
        /// <summary>
        /// SCM優先設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public SCMPriorStDB()
            :
            base("PMSCM09066D", "Broadleaf.Application.Remoting.ParamData.scmPriorStWork", "SCMPRIORSTRF")
        {
        }

        private const string _allSecCode = "00";

        #region [Search]
        /// <summary>
        /// 指定された条件のSCM優先設定マスタ情報LISTを戻します
        /// </summary>
        /// <param name="scmPriorStWork">検索結果</param>
        /// <param name="parascmPriorStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM優先設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int Search(out object scmPriorStWork, object parascmPriorStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            scmPriorStWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSCMPriorStProc(out scmPriorStWork, parascmPriorStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMPriorStDB.Search");
                scmPriorStWork = new ArrayList();
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
        /// 指定された条件のSCM優先設定マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objscmPriorStWork">検索結果</param>
        /// <param name="parascmPriorStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM優先設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int SearchSCMPriorStProc(out object objscmPriorStWork, object parascmPriorStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            SCMPriorStWork scmPriorStWork = null; 

            ArrayList scmPriorStWorkList = parascmPriorStWork as ArrayList;
            if (scmPriorStWorkList == null)
            {
                scmPriorStWork = parascmPriorStWork as SCMPriorStWork;
            }
            else
            {
                if (scmPriorStWorkList.Count > 0)
                    scmPriorStWork = scmPriorStWorkList[0] as SCMPriorStWork;
            }

            int status = SearchSCMPriorStProc(out scmPriorStWorkList, scmPriorStWork, readMode, logicalMode, ref sqlConnection);
            objscmPriorStWork = scmPriorStWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件のSCM優先設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="scmPriorStWorkList">検索結果</param>
        /// <param name="scmPriorStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM優先設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int SearchSCMPriorStProc(out ArrayList scmPriorStWorkList, SCMPriorStWork scmPriorStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchSCMPriorStProcProc(out scmPriorStWorkList, scmPriorStWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件のSCM優先設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="scmPriorStWorkList">検索結果</param>
        /// <param name="scmPriorStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM優先設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        private int SearchSCMPriorStProcProc(out ArrayList scmPriorStWorkList, SCMPriorStWork scmPriorStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;

                #region SELECT文
                selectTxt += " SELECT CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,SECTIONCODERF " + Environment.NewLine;
                //-------ADD BY  lingxiaoqing 2011.08.08----------->>>>>>>>>>
                selectTxt += "         , CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "         , PRIORAPPLIDIVRF" + Environment.NewLine;
                selectTxt += "         , SELTGTPUREDIVRF" + Environment.NewLine;
                selectTxt += "         , SELTGTSTCKDIVRF" + Environment.NewLine;
                selectTxt += "         , SELTGTCAMPDIVRF" + Environment.NewLine;
                selectTxt += "         , SELTGTPRICDIV1RF" + Environment.NewLine;
                selectTxt += "         , SELTGTPRICDIV2RF" + Environment.NewLine;
                selectTxt += "         , SELTGTPRICDIV3RF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTPUREDIVRF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTSTCKDIVRF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTCAMPDIVRF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTPRICDIV1RF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTPRICDIV2RF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTPRICDIV3RF" + Environment.NewLine;
                //-------ADD BY  lingxiaoqing 2011.08.08-----------<<<<<<<<<<
                selectTxt += "         ,PRIORITYSETTINGCD1RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM1RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGCD2RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM2RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGCD3RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM3RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGCD4RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM4RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGCD5RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM5RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD1RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM1RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD2RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM2RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD3RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM3RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD4RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM4RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD5RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM5RF " + Environment.NewLine;
                selectTxt += "  FROM SCMPRIORSTRF " + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, scmPriorStWork, logicalMode);
                sqlCommand.CommandText += "  ORDER BY SECTIONCODERF ASC,CUSTOMERCODERF ASC";  //ADD BY lingxiaoqing 対応ID=PCCUOE-0071的票
                
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToscmPriorStWorkFromReader(ref myReader));

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
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            scmPriorStWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件のSCM優先設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">scmPriorStWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM優先設定マスタを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                SCMPriorStWork scmPriorStWork = new SCMPriorStWork();

                // XMLの読み込み
                scmPriorStWork = (SCMPriorStWork)XmlByteSerializer.Deserialize(parabyte, typeof(SCMPriorStWork));
                if (scmPriorStWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref scmPriorStWork, readMode, ref sqlConnection,ref sqlTransaction);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(scmPriorStWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMPriorStDB.Read");
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
        // ADD 2011/08/10 ------------<<<<<<<<
        /// <summary>
        /// 指定された条件のSCM優先設定マスタを戻します(PCCUO専用)
        /// </summary>
        /// <param name="parabyte">scmPriorStWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM優先設定マスタを戻します</br>
        /// <br>Programmer : LIUSY</br>
        /// <br>Date       : 2011.08.10</br>
        public int ReadPCCUOE(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                SCMPriorStWork scmPriorStWork = new SCMPriorStWork();

                // XMLの読み込み
                scmPriorStWork = (SCMPriorStWork)XmlByteSerializer.Deserialize(parabyte, typeof(SCMPriorStWork));
                if (scmPriorStWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProcPCCUOE(ref scmPriorStWork, readMode, ref sqlConnection, ref sqlTransaction);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(scmPriorStWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMPriorStDB.ReadPCCUOE");
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
        // ADD 2011/08/10 ------------>>>>>>>>

        /// <summary>
        /// 指定された条件のSCM優先設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="scmPriorStWork">scmPriorStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM優先設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int ReadProc(ref SCMPriorStWork scmPriorStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProcProc(ref scmPriorStWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された条件のSCM優先設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="scmPriorStWork">scmPriorStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM優先設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        private int ReadProcProc(ref SCMPriorStWork scmPriorStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = string.Empty;

                #region SELECT文
                selectTxt += " SELECT CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,SECTIONCODERF " + Environment.NewLine;
                //-------ADD BY  lingxiaoqing 2011.08.08----------->>>>>>>>>>
                selectTxt += "         , CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "         , PRIORAPPLIDIVRF" + Environment.NewLine;
                selectTxt += "         , SELTGTPUREDIVRF" + Environment.NewLine;
                selectTxt += "         , SELTGTSTCKDIVRF" + Environment.NewLine;
                selectTxt += "         , SELTGTCAMPDIVRF" + Environment.NewLine;
                selectTxt += "         , SELTGTPRICDIV1RF" + Environment.NewLine;
                selectTxt += "         , SELTGTPRICDIV2RF" + Environment.NewLine;
                selectTxt += "         , SELTGTPRICDIV3RF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTPUREDIVRF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTSTCKDIVRF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTCAMPDIVRF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTPRICDIV1RF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTPRICDIV2RF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTPRICDIV3RF" + Environment.NewLine;
                //-------ADD BY  lingxiaoqing 2011.08.08-----------<<<<<<<<<<
                selectTxt += "         ,PRIORITYSETTINGCD1RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM1RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGCD2RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM2RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGCD3RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM3RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGCD4RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM4RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGCD5RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM5RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD1RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM1RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD2RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM2RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD3RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM3RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD4RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM4RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD5RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM5RF " + Environment.NewLine;
                selectTxt += "  FROM SCMPRIORSTRF " + Environment.NewLine;
                //------------DELETE BY lingxiaoqing 2011.08.08 -------------->>>>>>>>>>>>>>>>
                //selectTxt += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                //selectTxt += "         AND SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;
                //------------DELETE BY lingxiaoqing 2011.08.08 --------------<<<<<<<<<<<<<<<<


                //------------ADD BY lingxiaoqing 2011.08.08 --------->>>>>>>>>>>>
                if (scmPriorStWork.CustomerCode == 0)
                {
                    //拠点コード
                    selectTxt += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                    selectTxt += "         AND SECTIONCODERF IN (" + scmPriorStWork.SectionCode+",00)"+ Environment.NewLine;
                    selectTxt += "         AND PRIORAPPLIDIVRF IN (" + scmPriorStWork.PriorAppliDiv +",0)"+ Environment.NewLine;
                }
                else if (scmPriorStWork.SectionCode.Trim().Equals("00"))
                {
                    //得意先コード
                    selectTxt += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                    selectTxt += "         AND CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
                    selectTxt += "         AND PRIORAPPLIDIVRF =@FINDPRIORAPPLIDIV " + Environment.NewLine;
                }
                selectTxt += "         ORDER BY PRIORAPPLIDIVRF DESC, SECTIONCODERF DESC" + Environment.NewLine;
                //------------ADD BY lingxiaoqing ---------------------<<<<<<<<<<<<<<<<<
                #endregion　

                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomernCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int); //ADD BY lingxiaoqing on 2011.08.08 for 得意先コード
                    SqlParameter findParaPriorapplidiv = sqlCommand.Parameters.Add("@FINDPRIORAPPLIDIV", SqlDbType.Int);//ADD BY lingxiaoqing on 2011.08.08 for 優先適用区分


                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);
                    findParaCustomernCode.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.CustomerCode); //ADD BY lingxiaoqing on  2011.08.08 for 得意先コード
                    findParaPriorapplidiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorAppliDiv);//ADD BY lingxiaoqing on 2011.08.08 for 優先適用区分
                    
                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        scmPriorStWork = CopyToscmPriorStWorkFromReader(ref myReader);
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

        // ADD 2011.08.10 ------------------<<<<<<<<<
        /// <summary>
        /// 指定された条件のSCM優先設定マスタを戻します(PCCUOE専用)
        /// </summary>
        /// <param name="scmPriorStWork">scmPriorStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM優先設定マスタを戻します(PCCUOE専用)</br>
        /// <br>Programmer : LIUSY</br>
        /// <br>Date       : 2011.08.10</br>
        public int ReadProcPCCUOE(ref SCMPriorStWork scmPriorStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProcProcPCCUOE(ref scmPriorStWork, readMode, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// 指定された条件のSCM優先設定マスタを戻します(PCCUOE専用)
        /// </summary>
        /// <param name="scmPriorStWork">scmPriorStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM優先設定マスタを戻します(PCCUOE専用)</br>
        /// <br>Programmer : LIUSY</br>
        /// <br>Date       : 2011.08.10</br>
        private int ReadProcProcPCCUOE(ref SCMPriorStWork scmPriorStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = string.Empty;

                #region SELECT文
                selectTxt += " SELECT CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         , CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "         , PRIORAPPLIDIVRF" + Environment.NewLine;
                selectTxt += "         , SELTGTPUREDIVRF" + Environment.NewLine;
                selectTxt += "         , SELTGTSTCKDIVRF" + Environment.NewLine;
                selectTxt += "         , SELTGTCAMPDIVRF" + Environment.NewLine;
                selectTxt += "         , SELTGTPRICDIV1RF" + Environment.NewLine;
                selectTxt += "         , SELTGTPRICDIV2RF" + Environment.NewLine;
                selectTxt += "         , SELTGTPRICDIV3RF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTPUREDIVRF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTSTCKDIVRF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTCAMPDIVRF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTPRICDIV1RF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTPRICDIV2RF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTPRICDIV3RF" + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGCD1RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM1RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGCD2RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM2RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGCD3RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM3RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGCD4RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM4RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGCD5RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM5RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD1RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM1RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD2RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM2RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD3RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM3RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD4RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM4RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD5RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM5RF " + Environment.NewLine;
                selectTxt += "  FROM SCMPRIORSTRF " + Environment.NewLine;

                selectTxt += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                //拠点コード
                selectTxt += "         AND  SECTIONCODERF IN (" + scmPriorStWork.SectionCode + ",00)" + Environment.NewLine;
                //得意先コード
                selectTxt += "         AND  CUSTOMERCODERF IN (" + scmPriorStWork.CustomerCode + ",0)" + Environment.NewLine;
                selectTxt += "         AND  PRIORAPPLIDIVRF IN (" + scmPriorStWork.PriorAppliDiv + ",0)" + Environment.NewLine;
                selectTxt += "         AND LOGICALDELETECODERF = 0 ";
                selectTxt += "         ORDER BY CUSTOMERCODERF DESC, SECTIONCODERF DESC, PRIORAPPLIDIVRF DESC" + Environment.NewLine;
                #endregion

                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomernCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaPriorapplidiv = sqlCommand.Parameters.Add("@FINDPRIORAPPLIDIV", SqlDbType.Int);


                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);
                    findParaCustomernCode.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.CustomerCode); 
                    findParaPriorapplidiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorAppliDiv);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        scmPriorStWork = CopyToscmPriorStWorkFromReader(ref myReader);
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
        // ADD 2011.08.10 ------------------>>>>>>>>>>
        #endregion

        #region [Write]
        /// <summary>
        /// SCM優先設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="scmPriorStWork">StockMngTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM優先設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int Write(ref object scmPriorStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(scmPriorStWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteSCMPriorStProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                SCMPriorStWork paraWork = paraList[0] as SCMPriorStWork;
                
                //全社設定を更新した場合は、他の項目にも反映させる
                //-----------DELETE BY lingxiaoqing on 2011.08.08 for #Redmine25643------------>>>>>>>>>>>>
                //if (paraWork.SectionCode == _allSecCode)
                //{
                //    UpdateAllSecSCMPriorSt(ref paraList, ref sqlConnection, ref sqlTransaction);
                //}
                //-----------DELETE BY lingxiaoqing on 2011.08.08 for #Redmine25643------------<<<<<<<<<<<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                scmPriorStWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMPriorStDB.Write(ref object scmPriorStWork)");
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
        /// SCM優先設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="scmPriorStWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM優先設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int WriteSCMPriorStProc(ref ArrayList scmPriorStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteSCMPriorStProcProc(ref scmPriorStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM優先設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="scmPriorStWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM優先設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        private int WriteSCMPriorStProcProc(ref ArrayList scmPriorStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (scmPriorStWorkList != null)
                {
                    foreach (SCMPriorStWork scmPriorStWork in scmPriorStWorkList)
                    {
                        //Selectコマンドの生成
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM SCMPRIORSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction); // DELETE BY lingxiaoqing for 区分拠点コードと得意先コード
                        
                        //------------ADD BY lingxiaoqing 2011.08.08 --------->>>>>>>>>>
                        if (scmPriorStWork.CustomerCode == 0)
                        {
                            //拠点コード
                            sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM SCMPRIORSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND  CUSTOMERCODERF = 0 AND SECTIONCODERF=@FINDSECTIONCODE AND PRIORAPPLIDIVRF =@FINDPRIORAPPLIDIV", sqlConnection, sqlTransaction);
                        }
                        else if (scmPriorStWork.SectionCode.Trim().Equals("00"))
                        {
                            //得意先コード
                            sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM SCMPRIORSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND PRIORAPPLIDIVRF =@FINDPRIORAPPLIDIV", sqlConnection, sqlTransaction);
                        }
                        //------------ADD BY lingxiaoqing 2011.08.08---------<<<<<<<<<<

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCustomernCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int); //ADD BY lingxiaoqing for 得意先コード
                        SqlParameter findParaPriorapplidiv = sqlCommand.Parameters.Add("@FINDPRIORAPPLIDIV", SqlDbType.Int);//ADD BY lingxiaoqing for 優先適用区分

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);
                        findParaCustomernCode.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.CustomerCode);//ADD BY lingxiaoqing  for 得意先コード
                        findParaPriorapplidiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorAppliDiv);//ADD BY lingxiaoqing for 優先適用区分                       
                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != scmPriorStWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (scmPriorStWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region UPDATE文
                            string sqlText = string.Empty;

                            sqlText += " UPDATE SCMPRIORSTRF SET  " + Environment.NewLine;
                            sqlText += "    CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
                            sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
                            sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                            sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
                            sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
                            sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
                           // sqlText += "  , SECTIONCODERF = @SECTIONCODE " + Environment.NewLine;   //DELETE BY lingxiaoqing 2011.08.08
                            //-------ADD BY  lingxiaoqing 2011.08.08----------->>>>>>>>>>
                            if (scmPriorStWork.CustomerCode == 0)
                            {
                                //拠点コード
                                sqlText += "         ,SECTIONCODERF= @SECTIONCODE" + Environment.NewLine;
                            }
                            else if (scmPriorStWork.SectionCode.Trim().Equals("00"))
                            {
                                //得意先コード
                                sqlText += "         , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                            }
                            sqlText += "  , PRIORAPPLIDIVRF = @PRIORAPPLIDIV " + Environment.NewLine;
                            sqlText += "  , SELTGTPUREDIVRF = @SELTGTPUREDIV " + Environment.NewLine;
                            sqlText += "  , SELTGTSTCKDIVRF = @SELTGTSTCKDIV " + Environment.NewLine;
                            sqlText += "  , SELTGTCAMPDIVRF = @SELTGTCAMPDIV " + Environment.NewLine;
                            sqlText += "  , SELTGTPRICDIV1RF = @SELTGTPRICDIV1 " + Environment.NewLine;
                            sqlText += "  , SELTGTPRICDIV2RF = @SELTGTPRICDIV2 " + Environment.NewLine;
                            sqlText += "  , SELTGTPRICDIV3RF = @SELTGTPRICDIV3 " + Environment.NewLine;
                            sqlText += "  , UNSELTGTPUREDIVRF = @UNSELTGTPUREDIV " + Environment.NewLine;
                            sqlText += "  , UNSELTGTSTCKDIVRF = @UNSELTGTSTCKDIV " + Environment.NewLine;
                            sqlText += "  , UNSELTGTCAMPDIVRF = @UNSELTGTCAMPDIV " + Environment.NewLine;
                            sqlText += "  , UNSELTGTPRICDIV1RF = @UNSELTGTPRICDIV1 " + Environment.NewLine;
                            sqlText += "  , UNSELTGTPRICDIV2RF = @UNSELTGTPRICDIV2 " + Environment.NewLine;
                            sqlText += "  , UNSELTGTPRICDIV3RF = @UNSELTGTPRICDIV3 " + Environment.NewLine;
                            //-------ADD BY  lingxiaoqing 2011.08.08-----------<<<<<<<<<<
                            sqlText += "  , PRIORITYSETTINGCD1RF = @PRIORITYSETTINGCD1 " + Environment.NewLine;
                            sqlText += "  , PRIORITYSETTINGNM1RF = @PRIORITYSETTINGNM1 " + Environment.NewLine;
                            sqlText += "  , PRIORITYSETTINGCD2RF = @PRIORITYSETTINGCD2 " + Environment.NewLine;
                            sqlText += "  , PRIORITYSETTINGNM2RF = @PRIORITYSETTINGNM2 " + Environment.NewLine;
                            sqlText += "  , PRIORITYSETTINGCD3RF = @PRIORITYSETTINGCD3 " + Environment.NewLine;
                            sqlText += "  , PRIORITYSETTINGNM3RF = @PRIORITYSETTINGNM3 " + Environment.NewLine;
                            sqlText += "  , PRIORITYSETTINGCD4RF = @PRIORITYSETTINGCD4 " + Environment.NewLine;
                            sqlText += "  , PRIORITYSETTINGNM4RF = @PRIORITYSETTINGNM4 " + Environment.NewLine;
                            sqlText += "  , PRIORITYSETTINGCD5RF = @PRIORITYSETTINGCD5 " + Environment.NewLine;
                            sqlText += "  , PRIORITYSETTINGNM5RF = @PRIORITYSETTINGNM5 " + Environment.NewLine;
                            sqlText += "  , PRIORPRICESETCD1RF = @PRIORPRICESETCD1 " + Environment.NewLine;
                            sqlText += "  , PRIORPRICESETNM1RF = @PRIORPRICESETNM1 " + Environment.NewLine;
                            sqlText += "  , PRIORPRICESETCD2RF = @PRIORPRICESETCD2 " + Environment.NewLine;
                            sqlText += "  , PRIORPRICESETNM2RF = @PRIORPRICESETNM2 " + Environment.NewLine;
                            sqlText += "  , PRIORPRICESETCD3RF = @PRIORPRICESETCD3 " + Environment.NewLine;
                            sqlText += "  , PRIORPRICESETNM3RF = @PRIORPRICESETNM3 " + Environment.NewLine;
                            sqlText += "  , PRIORPRICESETCD4RF = @PRIORPRICESETCD4 " + Environment.NewLine;
                            sqlText += "  , PRIORPRICESETNM4RF = @PRIORPRICESETNM4 " + Environment.NewLine;
                            sqlText += "  , PRIORPRICESETCD5RF = @PRIORPRICESETCD5 " + Environment.NewLine;
                            sqlText += "  , PRIORPRICESETNM5RF = @PRIORPRICESETNM5 " + Environment.NewLine;
                            sqlText += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                            //sqlText += "         AND SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;  // DELETE BY lingxiaoqing for 区分拠点コードと得意先コード
                            // ---------ADD BY lingxiaoqing 2011.08.08--------->>>>>>>>>>
                            if (scmPriorStWork.CustomerCode == 0)
                            {
                                //拠点コード
                                sqlText += "         AND SECTIONCODERF = @FINDSECTIONCODE  AND CUSTOMERCODERF = 0 " + Environment.NewLine;
                            }
                            else if (scmPriorStWork.SectionCode.Trim().Equals("00"))
                            {
                                //得意先コード
                                sqlText += "         AND CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
                            }
                            sqlText += "             AND PRIORAPPLIDIVRF =@FINDPRIORAPPLIDIV" + Environment.NewLine;
                            // ---------ADD BY lingxiaoqing ----------<<<<<<<<<<<
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);
                            findParaCustomernCode.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.CustomerCode); //ADD BY lingxiaoqing for 得意先コード
                            findParaPriorapplidiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorAppliDiv);//ADD BY lingxiaoqing for 優先適用区分

                            //---------ADD BY lingxiaoqing 2011.08.08------------>>>>>>>>>>>>
                            SqlParameter paraSectionCode = null;
                            SqlParameter paraCustomerCode = null;
                            if (scmPriorStWork.CustomerCode == 0)
                            {
                                //拠点コード
                                paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                            }
                            else if (scmPriorStWork.SectionCode.Trim().Equals("00"))
                            {
                                //得意先コード
                                paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.NChar);  //得意先コード
                            }
                            if (scmPriorStWork.CustomerCode == 0)
                            {
                                //拠点コード
                                paraSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);
                            }
                            else if (scmPriorStWork.SectionCode.Trim().Equals("00"))
                            {
                                //得意先コード
                                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.CustomerCode);//得意先コード
                            }
                            //---------ADD BY lingxiaoqing 2011.08.08------------<<<<<<<<<<<<
                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmPriorStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);

                           
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (scmPriorStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region INSERT文
                            string sqlText = string.Empty;
                            sqlText += " INSERT INTO SCMPRIORSTRF " + Environment.NewLine;
                            sqlText += "  (CREATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,ENTERPRISECODERF " + Environment.NewLine;
                            sqlText += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                            sqlText += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                            sqlText += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                            sqlText += "         ,SECTIONCODERF " + Environment.NewLine;
                            //-------ADD BY  lingxiaoqing 2011.08.08----------->>>>>>>>>>
                            sqlText += "         , CUSTOMERCODERF " + Environment.NewLine;
                            sqlText += "         , PRIORAPPLIDIVRF" + Environment.NewLine;
                            sqlText += "         , SELTGTPUREDIVRF" + Environment.NewLine;
                            sqlText += "         , SELTGTSTCKDIVRF" + Environment.NewLine;
                            sqlText += "         , SELTGTCAMPDIVRF" + Environment.NewLine;
                            sqlText += "         , SELTGTPRICDIV1RF" + Environment.NewLine;
                            sqlText += "         , SELTGTPRICDIV2RF" + Environment.NewLine;
                            sqlText += "         , SELTGTPRICDIV3RF" + Environment.NewLine;
                            sqlText += "         , UNSELTGTPUREDIVRF" + Environment.NewLine;
                            sqlText += "         , UNSELTGTSTCKDIVRF" + Environment.NewLine;
                            sqlText += "         , UNSELTGTCAMPDIVRF" + Environment.NewLine;
                            sqlText += "         , UNSELTGTPRICDIV1RF" + Environment.NewLine;
                            sqlText += "         , UNSELTGTPRICDIV2RF" + Environment.NewLine;
                            sqlText += "         , UNSELTGTPRICDIV3RF" + Environment.NewLine;
                            //-------ADD BY  lingxiaoqing 2011.08.08-----------<<<<<<<<<<
                            sqlText += "         ,PRIORITYSETTINGCD1RF " + Environment.NewLine;
                            sqlText += "         ,PRIORITYSETTINGNM1RF " + Environment.NewLine;
                            sqlText += "         ,PRIORITYSETTINGCD2RF " + Environment.NewLine;
                            sqlText += "         ,PRIORITYSETTINGNM2RF " + Environment.NewLine;
                            sqlText += "         ,PRIORITYSETTINGCD3RF " + Environment.NewLine;
                            sqlText += "         ,PRIORITYSETTINGNM3RF " + Environment.NewLine;
                            sqlText += "         ,PRIORITYSETTINGCD4RF " + Environment.NewLine;
                            sqlText += "         ,PRIORITYSETTINGNM4RF " + Environment.NewLine;
                            sqlText += "         ,PRIORITYSETTINGCD5RF " + Environment.NewLine;
                            sqlText += "         ,PRIORITYSETTINGNM5RF " + Environment.NewLine;
                            sqlText += "         ,PRIORPRICESETCD1RF " + Environment.NewLine;
                            sqlText += "         ,PRIORPRICESETNM1RF " + Environment.NewLine;
                            sqlText += "         ,PRIORPRICESETCD2RF " + Environment.NewLine;
                            sqlText += "         ,PRIORPRICESETNM2RF " + Environment.NewLine;
                            sqlText += "         ,PRIORPRICESETCD3RF " + Environment.NewLine;
                            sqlText += "         ,PRIORPRICESETNM3RF " + Environment.NewLine;
                            sqlText += "         ,PRIORPRICESETCD4RF " + Environment.NewLine;
                            sqlText += "         ,PRIORPRICESETNM4RF " + Environment.NewLine;
                            sqlText += "         ,PRIORPRICESETCD5RF " + Environment.NewLine;
                            sqlText += "         ,PRIORPRICESETNM5RF " + Environment.NewLine;
                            sqlText += "  ) " + Environment.NewLine;
                            sqlText += "  VALUES " + Environment.NewLine;
                            sqlText += "  (@CREATEDATETIME " + Environment.NewLine;
                            sqlText += "         ,@UPDATEDATETIME " + Environment.NewLine;
                            sqlText += "         ,@ENTERPRISECODE " + Environment.NewLine;
                            sqlText += "         ,@FILEHEADERGUID " + Environment.NewLine;
                            sqlText += "         ,@UPDEMPLOYEECODE " + Environment.NewLine;
                            sqlText += "         ,@UPDASSEMBLYID1 " + Environment.NewLine;
                            sqlText += "         ,@UPDASSEMBLYID2 " + Environment.NewLine;
                            sqlText += "         ,@LOGICALDELETECODE " + Environment.NewLine;
                            sqlText += "         ,@SECTIONCODE " + Environment.NewLine;
                            //-------ADD BY  lingxiaoqing 2011.08.08----------->>>>>>>>>>
                            sqlText += "         , @CUSTOMERCODE " + Environment.NewLine;
                            sqlText += "         , @PRIORAPPLIDIV " + Environment.NewLine;
                            sqlText += "         , @SELTGTPUREDIV " + Environment.NewLine;
                            sqlText += "         , @SELTGTSTCKDIV " + Environment.NewLine;
                            sqlText += "         , @SELTGTCAMPDIV " + Environment.NewLine;
                            sqlText += "         , @SELTGTPRICDIV1 " + Environment.NewLine;
                            sqlText += "         , @SELTGTPRICDIV2 " + Environment.NewLine;
                            sqlText += "         , @SELTGTPRICDIV3 " + Environment.NewLine;
                            sqlText += "         , @UNSELTGTPUREDIV " + Environment.NewLine;
                            sqlText += "         , @UNSELTGTSTCKDIV " + Environment.NewLine;
                            sqlText += "         , @UNSELTGTCAMPDIV " + Environment.NewLine;
                            sqlText += "         , @UNSELTGTPRICDIV1 " + Environment.NewLine;
                            sqlText += "         , @UNSELTGTPRICDIV2 " + Environment.NewLine;
                            sqlText += "         , @UNSELTGTPRICDIV3 " + Environment.NewLine;
                            //-------ADD BY  lingxiaoqing 2011.08.08-----------<<<<<<<<<<
                            sqlText += "         ,@PRIORITYSETTINGCD1 " + Environment.NewLine;
                            sqlText += "         ,@PRIORITYSETTINGNM1 " + Environment.NewLine;
                            sqlText += "         ,@PRIORITYSETTINGCD2 " + Environment.NewLine;
                            sqlText += "         ,@PRIORITYSETTINGNM2 " + Environment.NewLine;
                            sqlText += "         ,@PRIORITYSETTINGCD3 " + Environment.NewLine;
                            sqlText += "         ,@PRIORITYSETTINGNM3 " + Environment.NewLine;
                            sqlText += "         ,@PRIORITYSETTINGCD4 " + Environment.NewLine;
                            sqlText += "         ,@PRIORITYSETTINGNM4 " + Environment.NewLine;
                            sqlText += "         ,@PRIORITYSETTINGCD5 " + Environment.NewLine;
                            sqlText += "         ,@PRIORITYSETTINGNM5 " + Environment.NewLine;
                            sqlText += "         ,@PRIORPRICESETCD1 " + Environment.NewLine;
                            sqlText += "         ,@PRIORPRICESETNM1 " + Environment.NewLine;
                            sqlText += "         ,@PRIORPRICESETCD2 " + Environment.NewLine;
                            sqlText += "         ,@PRIORPRICESETNM2 " + Environment.NewLine;
                            sqlText += "         ,@PRIORPRICESETCD3 " + Environment.NewLine;
                            sqlText += "         ,@PRIORPRICESETNM3 " + Environment.NewLine;
                            sqlText += "         ,@PRIORPRICESETCD4 " + Environment.NewLine;
                            sqlText += "         ,@PRIORPRICESETNM4 " + Environment.NewLine;
                            sqlText += "         ,@PRIORPRICESETCD5 " + Environment.NewLine;
                            sqlText += "         ,@PRIORPRICESETNM5 " + Environment.NewLine;
                            sqlText += "  ) " + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            //------------ADD BY lingxiaoqing 2011.08.08 --------->>>>>>>>>>>>
                            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);  // 拠点コード
                            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.NChar);  //得意先コード
                            paraSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);  // 拠点コード
                            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.CustomerCode);//得意先コード
                            //---------ADD BY lingxiaoqing 2011.08.08------------<<<<<<<<<<<<
                            # endregion

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmPriorStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);  // 作成日時
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);  // 更新日時
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);  // GUID
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);  // 更新従業員コード
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);  // 更新アセンブリID1
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);  // 更新アセンブリID2
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);  // 論理削除区分
                        //SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);  // 拠点コード DELETE BY lingxiaoqing 2011.08.08
                        //--------ADD BY lingxiaoqing 2011.08.08---------->>>>>>>>>>>>                                            
                        SqlParameter paraPriorAppliDiv = sqlCommand.Parameters.Add("@PRIORAPPLIDIV", SqlDbType.NChar); //優先適用区分
                        SqlParameter paraSelTgtPureDiv = sqlCommand.Parameters.Add("@SELTGTPUREDIV", SqlDbType.NChar);//選択時対象純優区分    
                        SqlParameter paraSelTgtStckDiv = sqlCommand.Parameters.Add("@SELTGTSTCKDIV", SqlDbType.NChar);//選択時対象在庫区分
                        SqlParameter paraSelTgtCampDiv = sqlCommand.Parameters.Add("@SELTGTCAMPDIV", SqlDbType.NChar);//選択時対象キャンペーン区分
                        SqlParameter paraSelTgtPricDiv1 = sqlCommand.Parameters.Add("@SELTGTPRICDIV1", SqlDbType.NChar);//選択時対象価格区分１    
                        SqlParameter paraSelTgtPricDiv2 = sqlCommand.Parameters.Add("@SELTGTPRICDIV2", SqlDbType.NChar);//選択時対象価格区分２
                        SqlParameter paraSelTgtPricDiv3 = sqlCommand.Parameters.Add("@SELTGTPRICDIV3", SqlDbType.NChar);//選択時対象価格区分 3
                        SqlParameter paraUnSelTgtPureDiv = sqlCommand.Parameters.Add("@UNSELTGTPUREDIV", SqlDbType.NChar);//非選択時対象純優区分
                        SqlParameter paraUnSelTgtStckDiv = sqlCommand.Parameters.Add("@UNSELTGTSTCKDIV", SqlDbType.NChar);//非選択時対象在庫区分
                        SqlParameter paraUnSelTgtCampDiv = sqlCommand.Parameters.Add("@UNSELTGTCAMPDIV", SqlDbType.NChar);//非選択時対象キャンペーン区分
                        SqlParameter paraUnSelTgtPricDiv1 = sqlCommand.Parameters.Add("@UNSELTGTPRICDIV1", SqlDbType.NChar);//非選択時対象価格区分１
                        SqlParameter paraUnSelTgtPricDiv2 = sqlCommand.Parameters.Add("@UNSELTGTPRICDIV2", SqlDbType.NChar);//非選択時対象価格区分２
                        SqlParameter paraUnSelTgtPricDiv3 = sqlCommand.Parameters.Add("@UNSELTGTPRICDIV3", SqlDbType.NChar);//非選択時対象価格区分 3
                        //--------ADD BY lingxiaoqing 2011.08.08---------->>>>>>>>>>>>
                        SqlParameter paraPrioritySettingCd1 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD1", SqlDbType.Int);  // 優先設定コード１
                        SqlParameter paraPrioritySettingNm1 = sqlCommand.Parameters.Add("@PRIORITYSETTINGNM1", SqlDbType.NVarChar);  // 優先設定名称１
                        SqlParameter paraPrioritySettingCd2 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD2", SqlDbType.Int);  // 優先設定コード２
                        SqlParameter paraPrioritySettingNm2 = sqlCommand.Parameters.Add("@PRIORITYSETTINGNM2", SqlDbType.NVarChar);  // 優先設定名称２
                        SqlParameter paraPrioritySettingCd3 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD3", SqlDbType.Int);  // 優先設定コード３
                        SqlParameter paraPrioritySettingNm3 = sqlCommand.Parameters.Add("@PRIORITYSETTINGNM3", SqlDbType.NVarChar);  // 優先設定名称３
                        SqlParameter paraPrioritySettingCd4 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD4", SqlDbType.Int);  // 優先設定コード４
                        SqlParameter paraPrioritySettingNm4 = sqlCommand.Parameters.Add("@PRIORITYSETTINGNM4", SqlDbType.NVarChar);  // 優先設定名称４
                        SqlParameter paraPrioritySettingCd5 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD5", SqlDbType.Int);  // 優先設定コード５
                        SqlParameter paraPrioritySettingNm5 = sqlCommand.Parameters.Add("@PRIORITYSETTINGNM5", SqlDbType.NVarChar);  // 優先設定名称５
                        SqlParameter paraPriorPriceSetCd1 = sqlCommand.Parameters.Add("@PRIORPRICESETCD1", SqlDbType.Int);  // 優先価格設定コード１
                        SqlParameter paraPriorPriceSetNm1 = sqlCommand.Parameters.Add("@PRIORPRICESETNM1", SqlDbType.NVarChar);  // 優先価格設定名称１
                        SqlParameter paraPriorPriceSetCd2 = sqlCommand.Parameters.Add("@PRIORPRICESETCD2", SqlDbType.Int);  // 優先価格設定コード２
                        SqlParameter paraPriorPriceSetNm2 = sqlCommand.Parameters.Add("@PRIORPRICESETNM2", SqlDbType.NVarChar);  // 優先価格設定名称２
                        SqlParameter paraPriorPriceSetCd3 = sqlCommand.Parameters.Add("@PRIORPRICESETCD3", SqlDbType.Int);  // 優先価格設定コード３
                        SqlParameter paraPriorPriceSetNm3 = sqlCommand.Parameters.Add("@PRIORPRICESETNM3", SqlDbType.NVarChar);  // 優先価格設定名称３
                        SqlParameter paraPriorPriceSetCd4 = sqlCommand.Parameters.Add("@PRIORPRICESETCD4", SqlDbType.Int);  // 優先価格設定コード４
                        SqlParameter paraPriorPriceSetNm4 = sqlCommand.Parameters.Add("@PRIORPRICESETNM4", SqlDbType.NVarChar);  // 優先価格設定名称４
                        SqlParameter paraPriorPriceSetCd5 = sqlCommand.Parameters.Add("@PRIORPRICESETCD5", SqlDbType.Int);  // 優先価格設定コード５
                        SqlParameter paraPriorPriceSetNm5 = sqlCommand.Parameters.Add("@PRIORPRICESETNM5", SqlDbType.NVarChar);  // 優先価格設定名称５
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmPriorStWork.CreateDateTime);  // 作成日時
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmPriorStWork.UpdateDateTime);  // 更新日時
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);  // 企業コード
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(scmPriorStWork.FileHeaderGuid);  // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.UpdEmployeeCode);  // 更新従業員コード
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmPriorStWork.UpdAssemblyId1);  // 更新アセンブリID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmPriorStWork.UpdAssemblyId2);  // 更新アセンブリID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.LogicalDeleteCode);  // 論理削除区分
                        //paraSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);  // 拠点コード DELETE BY lingxiaiqing 2011.08.08
                        //--------ADD BY lingxiaoqing 2011.08.08---------->>>>>>>>>>>>                   
                        paraPriorAppliDiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorAppliDiv);//優先適用区分
                        paraSelTgtPureDiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.SelTgtPureDiv);//選択時対象純優区分    
                        paraSelTgtStckDiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.SelTgtStckDiv);//選択時対象在庫区分
                        paraSelTgtCampDiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.SelTgtCampDiv);//選択時対象キャンペーン区分
                        paraSelTgtPricDiv1.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.SelTgtPricDiv1); //選択時対象価格区分１    
                        paraSelTgtPricDiv2.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.SelTgtPricDiv2);//選択時対象価格区分２
                        paraSelTgtPricDiv3.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.SelTgtPricDiv3);//選択時対象価格区分 3
                        paraUnSelTgtPureDiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.UnSelTgtPureDiv);//非選択時対象純優区分
                        paraUnSelTgtStckDiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.UnSelTgtStckDiv);//非選択時対象在庫区分
                        paraUnSelTgtCampDiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.UnSelTgtCampDiv);//非選択時対象キャンペーン区分
                        paraUnSelTgtPricDiv1.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.UnSelTgtPricDiv1);//非選択時対象価格区分１
                        paraUnSelTgtPricDiv2.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.UnSelTgtPricDiv2);//非選択時対象価格区分２
                        paraUnSelTgtPricDiv3.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.UnSelTgtPricDiv3);//非選択時対象価格区分 3
                        //--------ADD BY lingxiaoqing 2011.08.08---------->>>>>>>>>>>>
                        paraPrioritySettingCd1.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PrioritySettingCd1);  // 優先設定コード１
                        paraPrioritySettingNm1.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PrioritySettingNm1);  // 優先設定名称１
                        paraPrioritySettingCd2.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PrioritySettingCd2);  // 優先設定コード２
                        paraPrioritySettingNm2.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PrioritySettingNm2);  // 優先設定名称２
                        paraPrioritySettingCd3.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PrioritySettingCd3);  // 優先設定コード３
                        paraPrioritySettingNm3.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PrioritySettingNm3);  // 優先設定名称３
                        paraPrioritySettingCd4.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PrioritySettingCd4);  // 優先設定コード４
                        paraPrioritySettingNm4.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PrioritySettingNm4);  // 優先設定名称４
                        paraPrioritySettingCd5.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PrioritySettingCd5);  // 優先設定コード５
                        paraPrioritySettingNm5.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PrioritySettingNm5);  // 優先設定名称５
                        paraPriorPriceSetCd1.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorPriceSetCd1);  // 優先価格設定コード１
                        paraPriorPriceSetNm1.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PriorPriceSetNm1);  // 優先価格設定名称１
                        paraPriorPriceSetCd2.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorPriceSetCd2);  // 優先価格設定コード２
                        paraPriorPriceSetNm2.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PriorPriceSetNm2);  // 優先価格設定名称２
                        paraPriorPriceSetCd3.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorPriceSetCd3);  // 優先価格設定コード３
                        paraPriorPriceSetNm3.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PriorPriceSetNm3);  // 優先価格設定名称３
                        paraPriorPriceSetCd4.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorPriceSetCd4);  // 優先価格設定コード４
                        paraPriorPriceSetNm4.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PriorPriceSetNm4);  // 優先価格設定名称４
                        paraPriorPriceSetCd5.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorPriceSetCd5);  // 優先価格設定コード５
                        paraPriorPriceSetNm5.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PriorPriceSetNm5);  // 優先価格設定名称５
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(scmPriorStWork);
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
                    if (myReader.IsClosed == false) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            scmPriorStWorkList = al;

            return status;
        }

        /// <summary>
        /// 全社共通項目を更新する
        /// </summary>
        /// <param name="scmPriorStWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM優先設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        private int UpdateAllSecSCMPriorSt(ref ArrayList scmPriorStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (scmPriorStWorkList != null)
                {
                    SCMPriorStWork scmPriorStWork = scmPriorStWorkList[0] as SCMPriorStWork;

                    sqlCommand = new SqlCommand("",sqlConnection,sqlTransaction);
                    # region 更新時のSQL文生成
                    string sqlText = string.Empty;
                    sqlText += " UPDATE SCMPRIORSTRF SET  " + Environment.NewLine;
                    sqlText += "    CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
                    sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
                    sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                    sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
                    sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
                    sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
                    sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
                    sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
                    sqlText += "  , SECTIONCODERF = @SECTIONCODE " + Environment.NewLine;
                    sqlText += "  , PRIORITYSETTINGCD1RF = @PRIORITYSETTINGCD1 " + Environment.NewLine;
                    sqlText += "  , PRIORITYSETTINGNM1RF = @PRIORITYSETTINGNM1 " + Environment.NewLine;
                    sqlText += "  , PRIORITYSETTINGCD2RF = @PRIORITYSETTINGCD2 " + Environment.NewLine;
                    sqlText += "  , PRIORITYSETTINGNM2RF = @PRIORITYSETTINGNM2 " + Environment.NewLine;
                    sqlText += "  , PRIORITYSETTINGCD3RF = @PRIORITYSETTINGCD3 " + Environment.NewLine;
                    sqlText += "  , PRIORITYSETTINGNM3RF = @PRIORITYSETTINGNM3 " + Environment.NewLine;
                    sqlText += "  , PRIORITYSETTINGCD4RF = @PRIORITYSETTINGCD4 " + Environment.NewLine;
                    sqlText += "  , PRIORITYSETTINGNM4RF = @PRIORITYSETTINGNM4 " + Environment.NewLine;
                    sqlText += "  , PRIORITYSETTINGCD5RF = @PRIORITYSETTINGCD5 " + Environment.NewLine;
                    sqlText += "  , PRIORITYSETTINGNM5RF = @PRIORITYSETTINGNM5 " + Environment.NewLine;
                    sqlText += "  , PRIORPRICESETCD1RF = @PRIORPRICESETCD1 " + Environment.NewLine;
                    sqlText += "  , PRIORPRICESETNM1RF = @PRIORPRICESETNM1 " + Environment.NewLine;
                    sqlText += "  , PRIORPRICESETCD2RF = @PRIORPRICESETCD2 " + Environment.NewLine;
                    sqlText += "  , PRIORPRICESETNM2RF = @PRIORPRICESETNM2 " + Environment.NewLine;
                    sqlText += "  , PRIORPRICESETCD3RF = @PRIORPRICESETCD3 " + Environment.NewLine;
                    sqlText += "  , PRIORPRICESETNM3RF = @PRIORPRICESETNM3 " + Environment.NewLine;
                    sqlText += "  , PRIORPRICESETCD4RF = @PRIORPRICESETCD4 " + Environment.NewLine;
                    sqlText += "  , PRIORPRICESETNM4RF = @PRIORPRICESETNM4 " + Environment.NewLine;
                    sqlText += "  , PRIORPRICESETCD5RF = @PRIORPRICESETCD5 " + Environment.NewLine;
                    sqlText += "  , PRIORPRICESETNM5RF = @PRIORPRICESETNM5 " + Environment.NewLine;
                    sqlText += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                    sqlText += "  AND SECTIONCODERF<>'00'" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;

                    //更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)scmPriorStWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                    #endregion

                    #region Parameterオブジェクトの作成(更新用)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);  // 作成日時
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);  // 更新日時
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);  // GUID
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);  // 更新従業員コード
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);  // 更新アセンブリID1
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);  // 更新アセンブリID2
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);  // 論理削除区分
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);  // 拠点コード
                    SqlParameter paraPrioritySettingCd1 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD1", SqlDbType.Int);  // 優先設定コード１
                    SqlParameter paraPrioritySettingNm1 = sqlCommand.Parameters.Add("@PRIORITYSETTINGNM1", SqlDbType.NVarChar);  // 優先設定名称１
                    SqlParameter paraPrioritySettingCd2 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD2", SqlDbType.Int);  // 優先設定コード２
                    SqlParameter paraPrioritySettingNm2 = sqlCommand.Parameters.Add("@PRIORITYSETTINGNM2", SqlDbType.NVarChar);  // 優先設定名称２
                    SqlParameter paraPrioritySettingCd3 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD3", SqlDbType.Int);  // 優先設定コード３
                    SqlParameter paraPrioritySettingNm3 = sqlCommand.Parameters.Add("@PRIORITYSETTINGNM3", SqlDbType.NVarChar);  // 優先設定名称３
                    SqlParameter paraPrioritySettingCd4 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD4", SqlDbType.Int);  // 優先設定コード４
                    SqlParameter paraPrioritySettingNm4 = sqlCommand.Parameters.Add("@PRIORITYSETTINGNM4", SqlDbType.NVarChar);  // 優先設定名称４
                    SqlParameter paraPrioritySettingCd5 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD5", SqlDbType.Int);  // 優先設定コード５
                    SqlParameter paraPrioritySettingNm5 = sqlCommand.Parameters.Add("@PRIORITYSETTINGNM5", SqlDbType.NVarChar);  // 優先設定名称５
                    SqlParameter paraPriorPriceSetCd1 = sqlCommand.Parameters.Add("@PRIORPRICESETCD1", SqlDbType.Int);  // 優先価格設定コード１
                    SqlParameter paraPriorPriceSetNm1 = sqlCommand.Parameters.Add("@PRIORPRICESETNM1", SqlDbType.NVarChar);  // 優先価格設定名称１
                    SqlParameter paraPriorPriceSetCd2 = sqlCommand.Parameters.Add("@PRIORPRICESETCD2", SqlDbType.Int);  // 優先価格設定コード２
                    SqlParameter paraPriorPriceSetNm2 = sqlCommand.Parameters.Add("@PRIORPRICESETNM2", SqlDbType.NVarChar);  // 優先価格設定名称２
                    SqlParameter paraPriorPriceSetCd3 = sqlCommand.Parameters.Add("@PRIORPRICESETCD3", SqlDbType.Int);  // 優先価格設定コード３
                    SqlParameter paraPriorPriceSetNm3 = sqlCommand.Parameters.Add("@PRIORPRICESETNM3", SqlDbType.NVarChar);  // 優先価格設定名称３
                    SqlParameter paraPriorPriceSetCd4 = sqlCommand.Parameters.Add("@PRIORPRICESETCD4", SqlDbType.Int);  // 優先価格設定コード４
                    SqlParameter paraPriorPriceSetNm4 = sqlCommand.Parameters.Add("@PRIORPRICESETNM4", SqlDbType.NVarChar);  // 優先価格設定名称４
                    SqlParameter paraPriorPriceSetCd5 = sqlCommand.Parameters.Add("@PRIORPRICESETCD5", SqlDbType.Int);  // 優先価格設定コード５
                    SqlParameter paraPriorPriceSetNm5 = sqlCommand.Parameters.Add("@PRIORPRICESETNM5", SqlDbType.NVarChar);  // 優先価格設定名称５
                    #endregion

                    #region Parameterオブジェクトへ値設定(更新用)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmPriorStWork.CreateDateTime);  // 作成日時
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmPriorStWork.UpdateDateTime);  // 更新日時
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);  // 企業コード
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(scmPriorStWork.FileHeaderGuid);  // GUID
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.UpdEmployeeCode);  // 更新従業員コード
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmPriorStWork.UpdAssemblyId1);  // 更新アセンブリID1
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmPriorStWork.UpdAssemblyId2);  // 更新アセンブリID2
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.LogicalDeleteCode);  // 論理削除区分
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);  // 拠点コード
                    paraPrioritySettingCd1.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PrioritySettingCd1);  // 優先設定コード１
                    paraPrioritySettingNm1.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PrioritySettingNm1);  // 優先設定名称１
                    paraPrioritySettingCd2.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PrioritySettingCd2);  // 優先設定コード２
                    paraPrioritySettingNm2.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PrioritySettingNm2);  // 優先設定名称２
                    paraPrioritySettingCd3.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PrioritySettingCd3);  // 優先設定コード３
                    paraPrioritySettingNm3.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PrioritySettingNm3);  // 優先設定名称３
                    paraPrioritySettingCd4.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PrioritySettingCd4);  // 優先設定コード４
                    paraPrioritySettingNm4.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PrioritySettingNm4);  // 優先設定名称４
                    paraPrioritySettingCd5.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PrioritySettingCd5);  // 優先設定コード５
                    paraPrioritySettingNm5.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PrioritySettingNm5);  // 優先設定名称５
                    paraPriorPriceSetCd1.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorPriceSetCd1);  // 優先価格設定コード１
                    paraPriorPriceSetNm1.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PriorPriceSetNm1);  // 優先価格設定名称１
                    paraPriorPriceSetCd2.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorPriceSetCd2);  // 優先価格設定コード２
                    paraPriorPriceSetNm2.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PriorPriceSetNm2);  // 優先価格設定名称２
                    paraPriorPriceSetCd3.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorPriceSetCd3);  // 優先価格設定コード３
                    paraPriorPriceSetNm3.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PriorPriceSetNm3);  // 優先価格設定名称３
                    paraPriorPriceSetCd4.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorPriceSetCd4);  // 優先価格設定コード４
                    paraPriorPriceSetNm4.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PriorPriceSetNm4);  // 優先価格設定名称４
                    paraPriorPriceSetCd5.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorPriceSetCd5);  // 優先価格設定コード５
                    paraPriorPriceSetNm5.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PriorPriceSetNm5);  // 優先価格設定名称５
                    #endregion

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
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// SCM優先設定マスタ情報を論理削除します
        /// </summary>
        /// <param name="scmPriorStWork">StockMngTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM優先設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int LogicalDelete(ref object scmPriorStWork)
        {
            return LogicalDeleteSCMPriorSt(ref scmPriorStWork, 0);
        }

        /// <summary>
        /// 論理削除SCM優先設定マスタ情報を復活します
        /// </summary>
        /// <param name="scmPriorStWork">StockMngTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除SCM優先設定マスタ情報を復活します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int RevivalLogicalDelete(ref object scmPriorStWork)
        {
            return LogicalDeleteSCMPriorSt(ref scmPriorStWork, 1);
        }

        /// <summary>
        /// SCM優先設定マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="scmPriorStWork">StockMngTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM優先設定マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        private int LogicalDeleteSCMPriorSt(ref object scmPriorStWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(scmPriorStWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteSCMPriorStProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "SCMPriorStDB.LogicalDeleteSCMPriorSt :" + procModestr);

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
        /// SCM優先設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="scmPriorStWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM優先設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int LogicalDeleteSCMPriorStProc(ref ArrayList scmPriorStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteSCMPriorStProcProc(ref scmPriorStWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM優先設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="scmPriorStWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM優先設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        private int LogicalDeleteSCMPriorStProcProc(ref ArrayList scmPriorStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (scmPriorStWorkList != null)
                {
                    foreach (SCMPriorStWork scmPriorStWork in scmPriorStWorkList)
                    {
                        //Selectコマンドの生成
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SCMPRIORSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction); //DELETE BY lingxiaoqing on 2011.08.08 for 区分拠点コードと得意先コード
                        //------------ADD BY lingxiaoqing 2011.08.08 --------->>>>>>>>>>
                        if (scmPriorStWork.CustomerCode == 0)
                        {
                            //拠点コード
                            sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SCMPRIORSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND PRIORAPPLIDIVRF =@FINDPRIORAPPLIDIV", sqlConnection, sqlTransaction);
                        }
                        else if (scmPriorStWork.SectionCode.Trim().Equals("00"))
                        {
                            //得意先コード
                            sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SCMPRIORSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND PRIORAPPLIDIVRF =@FINDPRIORAPPLIDIV", sqlConnection, sqlTransaction);
                        }
                        //------------ADD BY lingxiaoqing -----------------<<<<<<<<<<<<<

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCustomernCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int); //ADD BY lingxiaoqing for 得意先コード
                        SqlParameter findParaPriorapplidiv = sqlCommand.Parameters.Add("@FINDPRIORAPPLIDIV", SqlDbType.Int);//ADD BY lingxiaoqing for 優先適用区分


                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);
                        findParaCustomernCode.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.CustomerCode);//ADD BY lingxiaoqing   for  得意先コード
                        findParaPriorapplidiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorAppliDiv);//ADD BY lingxiaoqing  for 優先適用区分

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != scmPriorStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                            //----------DELETE BY lingxiaoqing 2011.08.08 ------------------>>>>>>>>>>>>
                            //sqlCommand.CommandText = "UPDATE SCMPRIORSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                            //KEYコマンドを再設定
                            //findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);
                            //findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);
                            //----------DELETE BY lingxiaoqing 2011.08.08 ------------------<<<<<<<<<<<<<
                            //------------ADD BY lingxiaoqing 2011.08.08 --------->>>>>>>>>>
                            if (scmPriorStWork.CustomerCode == 0)
                            {
                                //拠点コード
                                sqlCommand.CommandText = "UPDATE SCMPRIORSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND PRIORAPPLIDIVRF =@FINDPRIORAPPLIDIV";
                                //KEYコマンドを再設定
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);
                                findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);
                                findParaPriorapplidiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorAppliDiv);//ADD BY lingxiaoqing
                            }
                            else if (scmPriorStWork.SectionCode.Trim().Equals("00"))
                            {
                                //得意先コード
                                sqlCommand.CommandText = "UPDATE SCMPRIORSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND PRIORAPPLIDIVRF =@FINDPRIORAPPLIDIV";
                                //KEYコマンドを再設定
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);
                                findParaCustomernCode.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.CustomerCode);//ADD BY lingxiaoqing
                                findParaPriorapplidiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorAppliDiv);//ADD BY lingxiaoqing
                            }
                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmPriorStWork;
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
                            else if (logicalDelCd == 0) scmPriorStWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else scmPriorStWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) scmPriorStWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmPriorStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmPriorStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmPriorStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(scmPriorStWork);
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
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            scmPriorStWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// SCM優先設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">SCM優先設定マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : SCM優先設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
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

                status = DeleteSCMPriorStProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "SCMPriorStDB.Delete");
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
        /// SCM優先設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="scmPriorStWorkList">SCM優先設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : SCM優先設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int DeleteSCMPriorStProc(ArrayList scmPriorStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteSCMPriorStProcProc(scmPriorStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM優先設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="scmPriorStWorkList">SCM優先設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : SCM優先設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        private int DeleteSCMPriorStProcProc(ArrayList scmPriorStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                foreach(SCMPriorStWork scmPriorStWork in scmPriorStWorkList)
                {
                    //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SCMPRIORSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction); //DELETE BY lingxiaoqing on 2011.08.08 for 区分拠点コードと得意先コード
                    //------------ADD BY lingxiaoqing 2011.08.08 --------->>>>>>>>>>
                    if (scmPriorStWork.CustomerCode == 0)
                    {
                        //拠点コード
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SCMPRIORSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND PRIORAPPLIDIVRF =@FINDPRIORAPPLIDIV ", sqlConnection, sqlTransaction);
                    }
                    else if (scmPriorStWork.SectionCode.Trim().Equals("00"))
                    {
                        //得意先コード
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SCMPRIORSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND PRIORAPPLIDIVRF =@FINDPRIORAPPLIDIV ", sqlConnection, sqlTransaction);

                    }
                    //------------ADD BY lingxiaoqing --------------->>>>>>>>>>
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomernCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int); //ADD BY lingxiaoqing on 2011.08.08 for 得意先コード
                    SqlParameter findParaPriorapplidiv = sqlCommand.Parameters.Add("@FINDPRIORAPPLIDIV", SqlDbType.Int);//ADD BY lingxiaoqing on 2011.08.08 for 優先適用区分

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);
                    findParaCustomernCode.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.CustomerCode);//ADD BY lingxiaoqing on 2011.08.08 for 得意先コード
                    findParaPriorapplidiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorAppliDiv);//ADD BY lingxiaoqing on 2011.08.08 for 優先適用区分
                    
                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != scmPriorStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }
                        //-----------DELETE BY lingxiaoqing  2011.08.08----------->>>>>>>>
                        //sqlCommand.CommandText = "DELETE FROM SCMPRIORSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                        //KEYコマンドを再設定
                        //findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);
                        //findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);
                        //-----------DELETE BY lingxiaoqing  2011.08.08-----------<<<<<<<< 
                        //------------ADD BY lingxiaoqing 2011.08.08 --------->>>>>>>>>>
                        if (scmPriorStWork.CustomerCode == 0)
                        {
                            //拠点コード
                            sqlCommand.CommandText = "DELETE FROM SCMPRIORSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND PRIORAPPLIDIVRF =@FINDPRIORAPPLIDIV";
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);
                            findParaPriorapplidiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorAppliDiv);
                        }
                        else if (scmPriorStWork.SectionCode.Trim().Equals("00"))
                        {
                            //得意先コード
                            sqlCommand.CommandText = "DELETE FROM SCMPRIORSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND PRIORAPPLIDIVRF =@FINDPRIORAPPLIDIV";
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);
                            findParaCustomernCode.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.CustomerCode);
                            findParaPriorapplidiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorAppliDiv);
                        }
                        //------------ADD BY lingxiaoqing 2011.08.08 -----------<<<<<<<<<<<<
                       
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
                {
                    if (myReader.IsClosed == false) myReader.Close();
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

	    #region [Where文作成処理]
	    /// <summary>
	    /// 検索条件文字列生成＋条件値設定
	    /// </summary>
	    /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="scmPriorStWork">検索条件格納クラス</param>
	    /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
	    /// <returns>Where条件文字列</returns>
	    /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SCMPriorStWork scmPriorStWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //企業コード
		    retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);

            //拠点コード
            if (string.IsNullOrEmpty(scmPriorStWork.SectionCode) == false)
            {
                retstring += "AND SECTIONCODERF=@SECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);
            }
            
            //論理削除区分
		    wkstring = "";
		    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData1)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData2)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData3))
		    {
			    wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
		    }
		    else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData012))
		    {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
		    }
		    if(wkstring != "")
		    {
			    retstring += wkstring;
			    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
			    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
		    }

		    return retstring;
		}
	    #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → StockMngTtlStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockMngTtlStWork</returns>
        /// <remarks>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private SCMPriorStWork CopyToscmPriorStWorkFromReader(ref SqlDataReader myReader)
        {
            SCMPriorStWork wkscmPriorStWork = new SCMPriorStWork();

            #region クラスへ格納
            wkscmPriorStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // 作成日時
            wkscmPriorStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // 更新日時
            wkscmPriorStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // 企業コード
            wkscmPriorStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));  // GUID
            wkscmPriorStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));  // 更新従業員コード
            wkscmPriorStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));  // 更新アセンブリID1
            wkscmPriorStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));  // 更新アセンブリID2
            wkscmPriorStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));  // 論理削除区分
            wkscmPriorStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));  // 拠点コード
            wkscmPriorStWork.PrioritySettingCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORITYSETTINGCD1RF"));  // 優先設定コード１
            wkscmPriorStWork.PrioritySettingNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIORITYSETTINGNM1RF"));  // 優先設定名称１
            wkscmPriorStWork.PrioritySettingCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORITYSETTINGCD2RF"));  // 優先設定コード２
            wkscmPriorStWork.PrioritySettingNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIORITYSETTINGNM2RF"));  // 優先設定名称２
            wkscmPriorStWork.PrioritySettingCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORITYSETTINGCD3RF"));  // 優先設定コード３
            wkscmPriorStWork.PrioritySettingNm3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIORITYSETTINGNM3RF"));  // 優先設定名称３
            wkscmPriorStWork.PrioritySettingCd4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORITYSETTINGCD4RF"));  // 優先設定コード４
            wkscmPriorStWork.PrioritySettingNm4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIORITYSETTINGNM4RF"));  // 優先設定名称４
            wkscmPriorStWork.PrioritySettingCd5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORITYSETTINGCD5RF"));  // 優先設定コード５
            wkscmPriorStWork.PrioritySettingNm5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIORITYSETTINGNM5RF"));  // 優先設定名称５
            wkscmPriorStWork.PriorPriceSetCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORPRICESETCD1RF"));  // 優先価格設定コード１
            wkscmPriorStWork.PriorPriceSetNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIORPRICESETNM1RF"));  // 優先価格設定名称１
            wkscmPriorStWork.PriorPriceSetCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORPRICESETCD2RF"));  // 優先価格設定コード２
            wkscmPriorStWork.PriorPriceSetNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIORPRICESETNM2RF"));  // 優先価格設定名称２
            wkscmPriorStWork.PriorPriceSetCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORPRICESETCD3RF"));  // 優先価格設定コード３
            wkscmPriorStWork.PriorPriceSetNm3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIORPRICESETNM3RF"));  // 優先価格設定名称３
            wkscmPriorStWork.PriorPriceSetCd4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORPRICESETCD4RF"));  // 優先価格設定コード４
            wkscmPriorStWork.PriorPriceSetNm4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIORPRICESETNM4RF"));  // 優先価格設定名称４
            wkscmPriorStWork.PriorPriceSetCd5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORPRICESETCD5RF"));  // 優先価格設定コード５
            wkscmPriorStWork.PriorPriceSetNm5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIORPRICESETNM5RF"));  // 優先価格設定名称５
            //-------------ADD BY lingxiaoqing  2011.08.08-------------->>>>>>>>>>>>>>>>>>>
            wkscmPriorStWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));//得意先コード
            wkscmPriorStWork.PriorAppliDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORAPPLIDIVRF"));//優先適用区分
            wkscmPriorStWork.SelTgtPureDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SELTGTPUREDIVRF"));//選択時対象純優区分 
            wkscmPriorStWork.SelTgtStckDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SELTGTSTCKDIVRF"));//選択時対象在庫区分
            wkscmPriorStWork.SelTgtCampDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SELTGTCAMPDIVRF"));//選択時対象キャンペーン区分
            wkscmPriorStWork.UnSelTgtPureDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNSELTGTPUREDIVRF"));//非選択時対象純優区分   
            wkscmPriorStWork.UnSelTgtStckDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNSELTGTSTCKDIVRF"));//非選択時対象在庫区分
            wkscmPriorStWork.UnSelTgtCampDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNSELTGTCAMPDIVRF"));//非選択時対象キャンペーン区分
            wkscmPriorStWork.SelTgtPricDiv1= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SELTGTPRICDIV1RF"));//選択時対象価格区分１
            wkscmPriorStWork.SelTgtPricDiv2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SELTGTPRICDIV2RF"));//選択時対象価格区分２
            wkscmPriorStWork.SelTgtPricDiv3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SELTGTPRICDIV3RF"));//選択時対象価格区分 3
            wkscmPriorStWork.UnSelTgtPricDiv1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNSELTGTPRICDIV1RF"));//非選択時対象価格区分１
            wkscmPriorStWork.UnSelTgtPricDiv2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNSELTGTPRICDIV2RF"));//非選択時対象価格区分２
            wkscmPriorStWork.UnSelTgtPricDiv3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNSELTGTPRICDIV3RF"));//非選択時対象価格区分 3
            //-------------ADD BY lingxiaoqing  -------------------------<<<<<<<<<<<<<<<<<<<<<
            #endregion

            return wkscmPriorStWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            SCMPriorStWork[] scmPriorStWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is SCMPriorStWork)
                    {
                        SCMPriorStWork wkscmPriorStWork = paraobj as SCMPriorStWork;
                        if (wkscmPriorStWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkscmPriorStWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            scmPriorStWorkArray = (SCMPriorStWork[])XmlByteSerializer.Deserialize(byteArray, typeof(SCMPriorStWork[]));
                        }
                        catch (Exception) { }
                        if (scmPriorStWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(scmPriorStWorkArray);
                        }
                        else
                        {
                            try
                            {
                                SCMPriorStWork wkscmPriorStWork = (SCMPriorStWork)XmlByteSerializer.Deserialize(byteArray, typeof(SCMPriorStWork));
                                if (wkscmPriorStWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkscmPriorStWork);
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
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
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
