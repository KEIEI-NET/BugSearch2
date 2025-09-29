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
    /// 全体設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫管理全体設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30350　櫻井　亮太</br>
    /// <br>Date       : 2009.04.27</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class SCMPrtSettingDB : RemoteDB, ISCMPrtSettingDB
    {
        /// <summary>
        /// 在庫管理全体設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        /// </remarks>
        public SCMPrtSettingDB()
            :
            base("PMSCM09007D", "Broadleaf.Application.Remoting.ParamData.SCMPrtSettingWork", "SCMPRTSETTINGRF")
        {
        }

        private const string _allSecCode = "00";

        #region [Search]
        /// <summary>
        /// 指定された条件の在庫管理全体設定マスタ情報LISTを戻します
        /// </summary>
        /// <param name="scmPrtSettingWork">検索結果</param>
        /// <param name="parascmPrtSettingWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM品目設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        public int Search(out object scmPrtSettingWork, object scmPrtSettingOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            scmPrtSettingWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSCMPrtSettingProc(out scmPrtSettingWork, scmPrtSettingOrderWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "scmPrtSettingDB.Search");
                scmPrtSettingWork = new ArrayList();
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
        /// 指定された条件のSCM品目設定マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objscmPrtSettingWork">検索結果</param>
        /// <param name="objscmPrtSettingOrderWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM品目設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        public int SearchSCMPrtSettingProc(out object objscmPrtSettingWork, object objscmPrtSettingOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            ArrayList scmPrtSettingWorkList = new ArrayList();

            SCMPrtSettingOrderWork scmPrtSettingOrderWork = null;

            if (objscmPrtSettingOrderWork != null)
            {
                scmPrtSettingOrderWork = objscmPrtSettingOrderWork as SCMPrtSettingOrderWork;
            }
            else
            {
                scmPrtSettingOrderWork = new SCMPrtSettingOrderWork();
            }

            int status = SearchSCMPrtSettingProc(out scmPrtSettingWorkList, scmPrtSettingOrderWork, readMode, logicalMode, ref sqlConnection);
            objscmPrtSettingWork = scmPrtSettingWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件のSCM品目設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="scmPrtSettingWorkList">検索結果</param>
        /// <param name="scmPrtSettingOrderWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫管理全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        public int SearchSCMPrtSettingProc(out ArrayList scmPrtSettingWorkList, SCMPrtSettingOrderWork scmPrtSettingOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchSCMPrtSettingProcProc(out scmPrtSettingWorkList, scmPrtSettingOrderWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件のSCM品目設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="scmPrtSettingWorkList">検索結果</param>
        /// <param name="scmPrtSettingOrderWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫管理全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        private int SearchSCMPrtSettingProcProc(out ArrayList scmPrtSettingWorkList, SCMPrtSettingOrderWork scmPrtSettingOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;
                #region SELECT
                selectTxt += " SELECT   SCM.CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,SCM.LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.CUSTOMERCODERF " + Environment.NewLine;
                //selectTxt += "         ,SCM.SUPPLIERCDRF " + Environment.NewLine;
                selectTxt += "         ,SCM.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "         ,BLG.BLGROUPCODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "         ,SCM.GOODSNORF " + Environment.NewLine;
                selectTxt += "         ,SCM.AUTOANSWERDIVRF " + Environment.NewLine;
                selectTxt += "         ,SEC.SECTIONGUIDENMRF " + Environment.NewLine;
                selectTxt += "         ,CUS.CUSTOMERSNMRF " + Environment.NewLine;
                //selectTxt += "         ,SUP.SUPPLIERNMRF " + Environment.NewLine;
                selectTxt += "         ,GOO.GOODSMGROUPNAMERF " + Environment.NewLine;
                selectTxt += "         ,GRO.BLGROUPNAMERF " + Environment.NewLine;
                selectTxt += "         ,BLG.BLGOODSFULLNAMERF " + Environment.NewLine;
                selectTxt += "         ,MAK.MAKERNAMERF " + Environment.NewLine;
                selectTxt += "         ,GOD.GOODSNAMERF " + Environment.NewLine;
                selectTxt += "  FROM SCMPRTSETTINGRF AS SCM " + Environment.NewLine;
                selectTxt += "  LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;
                selectTxt += "   ON  SEC.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND SEC.SECTIONCODERF = SCM.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN CUSTOMERRF AS CUS " + Environment.NewLine;
                selectTxt += "   ON  CUS.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND CUS.CUSTOMERCODERF = SCM.CUSTOMERCODERF " + Environment.NewLine;
                //selectTxt += "  LEFT JOIN SUPPLIERRF AS SUP " + Environment.NewLine;
                //selectTxt += "   ON  SUP.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                //selectTxt += "   AND SUP.SUPPLIERCDRF = SCM.SUPPLIERCDRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN BLGOODSCDURF AS BLG " + Environment.NewLine;
                selectTxt += "   ON  BLG.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND BLG.BLGOODSCODERF = SCM.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSGROUPURF AS GOO " + Environment.NewLine;
                selectTxt += "   ON  GOO.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GOO.GOODSMGROUPRF = SCM.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN BLGROUPURF AS GRO " + Environment.NewLine;
                selectTxt += "   ON  GRO.ENTERPRISECODERF = BLG.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GRO.BLGROUPCODERF = BLG.BLGROUPCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN MAKERURF AS MAK " + Environment.NewLine;
                selectTxt += "   ON  MAK.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND MAK.GOODSMAKERCDRF = SCM.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSURF AS GOD " + Environment.NewLine;
                selectTxt += "   ON  GOD.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GOD.GOODSMAKERCDRF = SCM.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "   AND GOD.GOODSNORF = SCM.GOODSNORF " + Environment.NewLine;

                #endregion

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, scmPrtSettingOrderWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToSCMPrtSettingWorkFromReader(ref myReader));

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

            scmPrtSettingWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件のSCM品目設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">StockMngTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM品目設定マスタを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            try
            {
                SCMPrtSettingWork scmPrtSettingWork = new SCMPrtSettingWork();

                // XMLの読み込み
                scmPrtSettingWork = (SCMPrtSettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(SCMPrtSettingWork));
                if (scmPrtSettingWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref scmPrtSettingWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(scmPrtSettingWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMPrtSettingDB.Read");
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
        /// 指定された条件のSCM品目設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="scmPrtSettingWork">scmPrtSettingWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM品目設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        public int ReadProc(ref SCMPrtSettingWork scmPrtSettingWork, int readMode, ref SqlConnection sqlConnection)
        {
            return this.ReadProcProc(ref scmPrtSettingWork, readMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件のSCM品目設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="scmPrtSettingWork">scmPrtSettingWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM品目設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        private int ReadProcProc(ref SCMPrtSettingWork scmPrtSettingWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = string.Empty;

                #region SELECT
                selectTxt += " SELECT   SCM.CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,SCM.LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.CUSTOMERCODERF " + Environment.NewLine;
                //selectTxt += "         ,SCM.SUPPLIERCDRF " + Environment.NewLine;
                selectTxt += "         ,SCM.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "         ,BLG.BLGROUPCODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "         ,SCM.GOODSNORF " + Environment.NewLine;
                selectTxt += "         ,SCM.AUTOANSWERDIVRF " + Environment.NewLine;
                selectTxt += "         ,SEC.SECTIONGUIDENMRF " + Environment.NewLine;
                selectTxt += "         ,CUS.CUSTOMERSNMRF " + Environment.NewLine;
                //selectTxt += "         ,SUP.SUPPLIERNMRF " + Environment.NewLine;
                selectTxt += "         ,GOO.GOODSMGROUPNAMERF " + Environment.NewLine;
                selectTxt += "         ,GRO.BLGROUPNAMERF " + Environment.NewLine;
                selectTxt += "         ,BLG.BLGOODSFULLNAMERF " + Environment.NewLine;
                selectTxt += "         ,MAK.MAKERNAMERF " + Environment.NewLine;
                selectTxt += "         ,GOD.GOODSNAMERF " + Environment.NewLine;
                selectTxt += "  FROM SCMPRTSETTINGRF AS SCM " + Environment.NewLine;
                selectTxt += "  LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;
                selectTxt += "   ON  SEC.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND SEC.SECTIONCODERF = SCM.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN CUSTOMERRF AS CUS " + Environment.NewLine;
                selectTxt += "   ON  CUS.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND CUS.CUSTOMERCODERF = SCM.CUSTOMERCODERF " + Environment.NewLine;
                //selectTxt += "  LEFT JOIN SUPPLIERRF AS SUP " + Environment.NewLine;
                //selectTxt += "   ON  SUP.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                //selectTxt += "   AND SUP.SUPPLIERCDRF = SCM.SUPPLIERCDRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN BLGOODSCDURF AS BLG " + Environment.NewLine;
                selectTxt += "   ON  BLG.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND BLG.BLGOODSCODERF = SCM.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSGROUPURF AS GOO " + Environment.NewLine;
                selectTxt += "   ON  GOO.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GOO.GOODSMGROUPRF = SCM.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN BLGROUPURF AS GRO " + Environment.NewLine;
                selectTxt += "   ON  GRO.ENTERPRISECODERF = BLG.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GRO.BLGROUPCODERF = BLG.BLGROUPCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN MAKERURF AS MAK " + Environment.NewLine;
                selectTxt += "   ON  MAK.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND MAK.GOODSMAKERCDRF = SCM.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSURF AS GOD " + Environment.NewLine;
                selectTxt += "   ON  GOD.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GOD.GOODSMAKERCDRF = SCM.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "   AND GOD.GOODSNORF = SCM.GOODSNORF " + Environment.NewLine;
                selectTxt += " WHERE SCM.ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                selectTxt += "         AND SCM.SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;
                selectTxt += "         AND SCM.CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
                //selectTxt += "         AND SCM.SUPPLIERCDRF = @FINDSUPPLIERCD " + Environment.NewLine;
                selectTxt += "         AND SCM.GOODSMGROUPRF = @FINDGOODSMGROUP " + Environment.NewLine;
                //selectTxt += "         AND SCM.BLGROUPCODERF = @FINDBLGROUPCODE " + Environment.NewLine;
                selectTxt += "         AND SCM.BLGOODSCODERF = @FINDBLGOODSCODE " + Environment.NewLine;
                selectTxt += "         AND SCM.GOODSMAKERCDRF = @FINDGOODSMAKERCD " + Environment.NewLine;
                selectTxt += "         AND SCM.GOODSNORF = @FINDGOODSNO " + Environment.NewLine;

                #endregion

                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.NChar);
                    //SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.NChar);
                    SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.NChar);
                    //SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.NChar);
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.NChar);
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.NChar);
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.EnterpriseCode);
                    findParaSectionCode.Value = scmPrtSettingWork.SectionCode.Trim();
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.CustomerCode);
                    //paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.SupplierCd);
                    paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMGroup);
                    //paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGroupCode);
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGoodsCode);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMakerCd);
                    paraGoodsNo.Value = scmPrtSettingWork.GoodsNo.Trim();

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        scmPrtSettingWork = CopyToSCMPrtSettingWorkFromReader(ref myReader);
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

        #region [Write]
        /// <summary>
        /// SCM品目設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="scmPrtSettingWork">scmPrtSettingWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM品目設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        public int Write(ref object scmPrtSettingWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(scmPrtSettingWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteSCMPrtSettingProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                SCMPrtSettingWork paraWork = paraList[0] as SCMPrtSettingWork;
                
                //全社設定を更新した場合は、他の項目にも反映させる
                if (paraWork.SectionCode == _allSecCode)
                {
                    UpdateAllSecSCMPrtSetting(ref paraList, ref sqlConnection, ref sqlTransaction);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                scmPrtSettingWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMPrtSettingDB.Write(ref object scmPrtSettingWork)");
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
        /// SCM品目設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="scmPrtSettingWorkList">scmPrtSettingWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM品目設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        public int WriteSCMPrtSettingProc(ref ArrayList scmPrtSettingWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteSCMPrtSettingProcProc(ref scmPrtSettingWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM品目設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="scmPrtSettingWorkList">scmPrtSettingWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM品目設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        private int WriteSCMPrtSettingProcProc(ref ArrayList scmPrtSettingWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (scmPrtSettingWorkList != null)
                {
                    for (int i = 0; i < scmPrtSettingWorkList.Count; i++)
                    {
                        SCMPrtSettingWork scmPrtSettingWork = scmPrtSettingWorkList[i] as SCMPrtSettingWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM SCMPRTSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP  AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND GOODSNORF = @FINDGOODSNO", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        //SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                        //SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.EnterpriseCode);
                        findParaSectionCode.Value = scmPrtSettingWork.SectionCode.Trim();
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.CustomerCode);
                        //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.SupplierCd);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMGroup);
                        //findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGoodsCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMakerCd);
                        findParaGoodsNo.Value = scmPrtSettingWork.GoodsNo.Trim();

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != scmPrtSettingWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (scmPrtSettingWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region 更新時のSQL文生成
                            string sqlText = string.Empty;
                            sqlText += " UPDATE SCMPRTSETTINGRF SET CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
                            sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
                            sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                            sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
                            sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
                            sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
                            sqlText += "  , SECTIONCODERF = @SECTIONCODE " + Environment.NewLine;
                            sqlText += "  , CUSTOMERCODERF = @CUSTOMERCODE " + Environment.NewLine;
                            //sqlText += "  , SUPPLIERCDRF = @SUPPLIERCD " + Environment.NewLine;
                            sqlText += "  , GOODSMGROUPRF = @GOODSMGROUP " + Environment.NewLine;
                            //sqlText += "  , BLGROUPCODERF = @BLGROUPCODE " + Environment.NewLine;
                            sqlText += "  , BLGOODSCODERF = @BLGOODSCODE " + Environment.NewLine;
                            sqlText += "  , GOODSMAKERCDRF = @GOODSMAKERCD " + Environment.NewLine;
                            sqlText += "  , GOODSNORF = @GOODSNO " + Environment.NewLine;
                            sqlText += "  , AUTOANSWERDIVRF = @AUTOAWNSERDIV " + Environment.NewLine;
                            sqlText += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                            sqlText += "         AND SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;
                            sqlText += "         AND CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
                            //sqlText += "         AND SUPPLIERCDRF = @FINDSUPPLIERCD " + Environment.NewLine;
                            sqlText += "         AND GOODSMGROUPRF = @FINDGOODSMGROUP " + Environment.NewLine;
                            //sqlText += "         AND BLGROUPCODERF = @FINDBLGROUPCODE " + Environment.NewLine;
                            sqlText += "         AND BLGOODSCODERF = @FINDBLGOODSCODE " + Environment.NewLine;
                            sqlText += "         AND GOODSMAKERCDRF = @FINDGOODSMAKERCD " + Environment.NewLine;
                            sqlText += "         AND GOODSNORF = @FINDGOODSNO " + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.EnterpriseCode);
                            findParaSectionCode.Value = scmPrtSettingWork.SectionCode.Trim();
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.CustomerCode);
                            //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.SupplierCd);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMGroup);
                            //findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGroupCode);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGoodsCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMakerCd);
                            findParaGoodsNo.Value = scmPrtSettingWork.GoodsNo.Trim();

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmPrtSettingWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (scmPrtSettingWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region 新規作成時のSQL文を生成
                            string sqlText = string.Empty;
                            sqlText += " INSERT INTO SCMPRTSETTINGRF " + Environment.NewLine;
                            sqlText += "  (CREATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,ENTERPRISECODERF " + Environment.NewLine;
                            sqlText += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                            sqlText += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                            sqlText += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                            sqlText += "         ,SECTIONCODERF " + Environment.NewLine;
                            sqlText += "         ,CUSTOMERCODERF " + Environment.NewLine;
                            //sqlText += "         ,SUPPLIERCDRF " + Environment.NewLine;
                            sqlText += "         ,GOODSMGROUPRF " + Environment.NewLine;
                            //sqlText += "         ,BLGROUPCODERF " + Environment.NewLine;
                            sqlText += "         ,BLGOODSCODERF " + Environment.NewLine;
                            sqlText += "         ,GOODSMAKERCDRF " + Environment.NewLine;
                            sqlText += "         ,GOODSNORF " + Environment.NewLine;
                            sqlText += "         ,AUTOANSWERDIVRF " + Environment.NewLine;
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
                            sqlText += "         ,@CUSTOMERCODE " + Environment.NewLine;
                            //sqlText += "         ,@SUPPLIERCD " + Environment.NewLine;
                            sqlText += "         ,@GOODSMGROUP " + Environment.NewLine;
                            //sqlText += "         ,@BLGROUPCODE " + Environment.NewLine;
                            sqlText += "         ,@BLGOODSCODE " + Environment.NewLine;
                            sqlText += "         ,@GOODSMAKERCD " + Environment.NewLine;
                            sqlText += "         ,@GOODSNO " + Environment.NewLine;
                            sqlText += "         ,@AUTOAWNSERDIV " + Environment.NewLine;
                            sqlText += "  ) " + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmPrtSettingWork;
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
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);  // 拠点コード
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);  // 得意先コード
                        //SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);  // 仕入先コード
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);  // 商品中分類コード
                        //SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);  // BLグループコード
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);  // BL商品コード
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);  // 商品メーカーコード
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);  // 商品番号
                        SqlParameter paraAutoAwnser = sqlCommand.Parameters.Add("@AUTOAWNSERDIV", SqlDbType.Int);  // 自動回答区分

                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmPrtSettingWork.CreateDateTime);  // 作成日時
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmPrtSettingWork.UpdateDateTime);  // 更新日時
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.EnterpriseCode);  // 企業コード
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(scmPrtSettingWork.FileHeaderGuid);  // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.UpdEmployeeCode);  // 更新従業員コード
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.UpdAssemblyId1);  // 更新アセンブリID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.UpdAssemblyId2);  // 更新アセンブリID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.LogicalDeleteCode);  // 論理削除区分
                        paraSectionCode.Value = scmPrtSettingWork.SectionCode.Trim();  // 拠点コード
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.CustomerCode);  // 得意先コード
                        //paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.SupplierCd);  // 仕入先コード
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMGroup);  // 商品中分類コード
                        //paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGroupCode);  // BLグループコード
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGoodsCode);  // BL商品コード
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMakerCd);  // 商品メーカーコード
                        paraGoodsNo.Value = scmPrtSettingWork.GoodsNo.Trim();  // 商品番号
                        paraAutoAwnser.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.AutoAnswerDiv);  // 自動回答区分
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(scmPrtSettingWork);
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

            scmPrtSettingWorkList = al;

            return status;
        }

        /// <summary>
        /// 全社共通項目を更新する
        /// </summary>
        /// <param name="scmPrtSettingWorkList">scmPrtSettingWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM品目設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        private int UpdateAllSecSCMPrtSetting(ref ArrayList scmPrtSettingWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (scmPrtSettingWorkList != null)
                {
                    SCMPrtSettingWork scmPrtSettingWork = scmPrtSettingWorkList[0] as SCMPrtSettingWork;

                    sqlCommand = new SqlCommand("",sqlConnection,sqlTransaction);
                    # region 更新時のSQL文生成
                    string sqlText = string.Empty;

                    sqlText += " UPDATE SCMPRTSETTINGRF SET CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
                    sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
                    sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                    sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
                    sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
                    sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
                    sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
                    sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
                    sqlText += "  , SECTIONCODERF = @SECTIONCODE " + Environment.NewLine;
                    sqlText += "  , CUSTOMERCODERF = @CUSTOMERCODE " + Environment.NewLine;
                    //sqlText += "  , SUPPLIERCDRF = @SUPPLIERCD " + Environment.NewLine;
                    sqlText += "  , GOODSMGROUPRF = @GOODSMGROUP " + Environment.NewLine;
                    //sqlText += "  , BLGROUPCODERF = @BLGROUPCODE " + Environment.NewLine;
                    sqlText += "  , BLGOODSCODERF = @BLGOODSCODE " + Environment.NewLine;
                    sqlText += "  , GOODSMAKERCDRF = @GOODSMAKERCD " + Environment.NewLine;
                    sqlText += "  , GOODSNORF = @GOODSNO " + Environment.NewLine;
                    sqlText += "  , AUTOANSWERDIVRF = @AUTOAWNSER " + Environment.NewLine;
                    sqlText += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                    sqlText += "         AND SECTIONCODERF<>'00'" + Environment.NewLine;
                    sqlText += "         AND CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
                    sqlText += "         AND SUPPLIERCDRF = @FINDSUPPLIERCD " + Environment.NewLine;
                    sqlText += "         AND GOODSMGROUPRF = @FINDGOODSMGROUP " + Environment.NewLine;
                    sqlText += "         AND BLGROUPCODERF = @FINDBLGROUPCODE " + Environment.NewLine;
                    sqlText += "         AND BLGOODSCODERF = @FINDBLGOODSCODE " + Environment.NewLine;
                    sqlText += "         AND GOODSMAKERCDRF = @FINDGOODSMAKERCD " + Environment.NewLine;
                    sqlText += "         AND GOODSNORF = @FINDGOODSNO " + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.NChar);
                    //SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.NChar);
                    SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.NChar);
                    //SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.NChar);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.NChar);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.EnterpriseCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.CustomerCode);
                    //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.SupplierCd);
                    findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMGroup);
                    //findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGroupCode);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGoodsCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.GoodsNo);

                    //更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)scmPrtSettingWork;
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
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);  // 得意先コード
                    //SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);  // 仕入先コード
                    SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);  // 商品中分類コード
                    //SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);  // BLグループコード
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);  // BL商品コード
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);  // 商品メーカーコード
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);  // 商品番号
                    SqlParameter paraAutoAwnser = sqlCommand.Parameters.Add("@AUTOAWNSER", SqlDbType.Int);  // 自動回答区分

                    #endregion

                    #region Parameterオブジェクトへ値設定(更新用)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmPrtSettingWork.CreateDateTime);  // 作成日時
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmPrtSettingWork.UpdateDateTime);  // 更新日時
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.EnterpriseCode);  // 企業コード
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(scmPrtSettingWork.FileHeaderGuid);  // GUID
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.UpdEmployeeCode);  // 更新従業員コード
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.UpdAssemblyId1);  // 更新アセンブリID1
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.UpdAssemblyId2);  // 更新アセンブリID2
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.LogicalDeleteCode);  // 論理削除区分
                    paraSectionCode.Value = scmPrtSettingWork.SectionCode.Trim();  // 拠点コード
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.CustomerCode);  // 得意先コード
                    //paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.SupplierCd);  // 仕入先コード
                    paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMGroup);  // 商品中分類コード
                    //paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGroupCode);  // BLグループコード
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGoodsCode);  // BL商品コード
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMakerCd);  // 商品メーカーコード
                    paraGoodsNo.Value = scmPrtSettingWork.GoodsNo.Trim();  // 商品番号
                    paraAutoAwnser.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.AutoAnswerDiv);  // 自動回答区分
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
        /// SCM品目設定マスタ情報を論理削除します
        /// </summary>
        /// <param name="scmPrtSettingWork">scmPrtSettingWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM品目設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        public int LogicalDelete(ref object scmPrtSettingWork)
        {
            return LogicalDeleteSCMPrtSetting(ref scmPrtSettingWork, 0);
        }

        /// <summary>
        /// 論理削除SCM品目設定マスタ情報を復活します
        /// </summary>
        /// <param name="scmPrtSettingWork">scmPrtSettingWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除SCM品目設定マスタ情報を復活します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        public int RevivalLogicalDelete(ref object scmPrtSettingWork)
        {
            return LogicalDeleteSCMPrtSetting(ref scmPrtSettingWork, 1);
        }

        /// <summary>
        /// SCM品目設定マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="scmPrtSettingWork">SCMPrtSettingWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM品目設定マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        private int LogicalDeleteSCMPrtSetting(ref object scmPrtSettingWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(scmPrtSettingWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteSCMPrtSettingProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "SCMPrtSettingDB.LogicalDeleteSCMPrtSetting :" + procModestr);

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
        /// SCM品目設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="scmPrtSettingWorkList">SCMPrtSettingWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM品目設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        public int LogicalDeleteSCMPrtSettingProc(ref ArrayList scmPrtSettingWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteSCMPrtSettingProcProc(ref scmPrtSettingWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM品目設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="scmPrtSettingWorkList">SCMPrtSettingWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM品目設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        private int LogicalDeleteSCMPrtSettingProcProc(ref ArrayList scmPrtSettingWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (scmPrtSettingWorkList != null)
                {
                    for (int i = 0; i < scmPrtSettingWorkList.Count; i++)
                    {
                        SCMPrtSettingWork scmPrtSettingWork = scmPrtSettingWorkList[i] as SCMPrtSettingWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF,LOGICALDELETECODERF,  ENTERPRISECODERF FROM SCMPRTSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND GOODSNORF = @FINDGOODSNO", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        //SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                        //SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.EnterpriseCode);
                        findParaSectionCode.Value = scmPrtSettingWork.SectionCode.Trim();
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.CustomerCode);
                        //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.SupplierCd);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMGroup);
                        //findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGoodsCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMakerCd);
                        findParaGoodsNo.Value = scmPrtSettingWork.GoodsNo.Trim();

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != scmPrtSettingWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE SCMPRTSETTINGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND GOODSNORF = @FINDGOODSNO";
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.EnterpriseCode);
                            findParaSectionCode.Value = scmPrtSettingWork.SectionCode.Trim();
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.CustomerCode);
                            //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.SupplierCd);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMGroup);
                            //findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGroupCode);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGoodsCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMakerCd);
                            findParaGoodsNo.Value = scmPrtSettingWork.GoodsNo.Trim();

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmPrtSettingWork;
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
                            else if (logicalDelCd == 0) scmPrtSettingWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else scmPrtSettingWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) scmPrtSettingWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmPrtSettingWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(scmPrtSettingWork);
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

            scmPrtSettingWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// SCM品目設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">SCM品目設定マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : SCM品目設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
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

                status = DeleteSCMPrtSettingProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "SCMPrtSettingDB.Delete");
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
        /// SCM品目設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="scmPrtSettingWorkList">SCM品目設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : SCM品目設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        public int DeleteSCMPrtSettingProc(ArrayList scmPrtSettingWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteSCMPrtSettingProcProc(scmPrtSettingWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM品目設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="scmPrtSettingWorkList">SCM品目設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : SCM品目設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        private int DeleteSCMPrtSettingProcProc(ArrayList scmPrtSettingWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < scmPrtSettingWorkList.Count; i++)
                {
                    SCMPrtSettingWork scmPrtSettingWork = scmPrtSettingWorkList[i] as SCMPrtSettingWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SCMPRTSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND GOODSNORF = @FINDGOODSNO", sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    //SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                    //SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.EnterpriseCode);
                    findParaSectionCode.Value = scmPrtSettingWork.SectionCode.Trim();
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.CustomerCode);
                    //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.SupplierCd);
                    findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMGroup);
                    //findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGroupCode);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGoodsCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMakerCd);
                    findParaGoodsNo.Value = scmPrtSettingWork.GoodsNo.Trim();

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != scmPrtSettingWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM SCMPRTSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND GOODSNORF = @FINDGOODSNO";
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.EnterpriseCode);
                        findParaSectionCode.Value = scmPrtSettingWork.SectionCode.Trim();
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.CustomerCode);
                        //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.SupplierCd);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMGroup);
                        //findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGoodsCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMakerCd);
                        findParaGoodsNo.Value = scmPrtSettingWork.GoodsNo.Trim();
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
        /// <param name="scmPrtSettingWork">検索条件格納クラス</param>
	    /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
	    /// <returns>Where条件文字列</returns>
	    /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SCMPrtSettingOrderWork scmPrtSettingOrderWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //企業コード
		    retstring += "SCM.ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingOrderWork.EnterpriseCode);

            //拠点コード
            if (string.IsNullOrEmpty(scmPrtSettingOrderWork.SectionCode) == false)
            {
                retstring += "AND SCM.SECTIONCODERF=@SECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingOrderWork.SectionCode);
            }
            
            //論理削除区分
		    wkstring = "";
		    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData1)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData2)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData3))
		    {
                wkstring = "AND SCM.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
		    }
		    else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData012))
		    {
                wkstring = "AND SCM.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
		    }
		    if(wkstring != "")
		    {
			    retstring += wkstring;
			    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
			    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
		    }

            // 得意先コード
            if (scmPrtSettingOrderWork.St_CustomerCode != 0)
            {
                retstring += "AND SCM.CUSTOMERCODERF >= @FINDSTCUSTOMERCODE ";
                SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@FINDSTCUSTOMERCODE", SqlDbType.Int);
                paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingOrderWork.St_CustomerCode);
            }
            if (scmPrtSettingOrderWork.Ed_CustomerCode != 0)
            {
                retstring += "AND SCM.CUSTOMERCODERF <= @FINDEDCUSTOMERCODE ";
                SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@FINDEDCUSTOMERCODE", SqlDbType.Int);
                paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingOrderWork.Ed_CustomerCode);
            }

            //// 仕入先コード
            //if (scmPrtSettingOrderWork.St_SupplierCd != 0)
            //{
            //    retstring += "AND SUPPLIERCDRF >= @FINDSTSUPPLIERCD ";
            //    SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@FINDSTSUPPLIERCD", SqlDbType.Int);
            //    paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingOrderWork.St_SupplierCd);
            //}
            //if (scmPrtSettingOrderWork.Ed_SupplierCd != 0)
            //{
            //    retstring += "AND SUPPLIERCDRF <= @FINDEDSUPPLIERCD ";
            //    SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@FINDEDSUPPLIERCD", SqlDbType.Int);
            //    paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingOrderWork.Ed_SupplierCd);
            //}

            // 商品中分類コード
            if (scmPrtSettingOrderWork.St_GoodsMGroup != 0) 
            {
                retstring += "AND SCM.GOODSMGROUPRF >= @FINDSTGOODSMGROUP ";
                SqlParameter paraStGoodsMGroup = sqlCommand.Parameters.Add("@FINDSTGOODSMGROUP", SqlDbType.Int);
                paraStGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingOrderWork.St_GoodsMGroup);
            } 
            if (scmPrtSettingOrderWork.Ed_GoodsMGroup != 0)
            {
                retstring += "AND SCM.GOODSMGROUPRF <= @FINDEDGOODSMGROUP ";
                SqlParameter paraEdGoodsMGroup = sqlCommand.Parameters.Add("@FINDEDGOODSMGROUP", SqlDbType.Int);
                paraEdGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingOrderWork.Ed_GoodsMGroup);
            }

            // BLグループコード
            if (scmPrtSettingOrderWork.St_BLGroupCode != 0)
            {
                retstring += "AND BLG.BLGROUPCODERF >= @FINDSTBLGROUPCODE ";
                SqlParameter paraStBLGroupCode = sqlCommand.Parameters.Add("@FINDSTBLGROUPCODE", SqlDbType.Int);
                paraStBLGroupCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingOrderWork.St_BLGroupCode);
            }
            if (scmPrtSettingOrderWork.Ed_BLGroupCode != 0)
            {
                retstring += "AND BLG.BLGROUPCODERF <= @FINDEDBLGROUPCODE ";
                SqlParameter paraEdBLGroupCode = sqlCommand.Parameters.Add("@FINDEDBLGROUPCODE", SqlDbType.Int);
                paraEdBLGroupCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingOrderWork.Ed_BLGroupCode);
            }

            // BL商品コード
            if (scmPrtSettingOrderWork.St_BLGoodsCode != 0)
            {
                retstring += "AND SCM.BLGOODSCODERF >= @FINDSTBLGOODSCODE ";
                SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@FINDSTBLGOODSCODE", SqlDbType.Int);
                paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingOrderWork.St_BLGoodsCode);
            }
            if (scmPrtSettingOrderWork.Ed_BLGoodsCode != 0)
            {
                retstring += "AND SCM.BLGOODSCODERF <= @FINDEDBLGOODSCODE ";
                SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@FINDEDBLGOODSCODE", SqlDbType.Int);
                paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingOrderWork.Ed_BLGoodsCode);
            }

            // メーカーコード
            if (scmPrtSettingOrderWork.St_GoodsMakerCd != 0)
            {
                retstring += "AND SCM.GOODSMAKERCDRF >= @FINDSTGOODSMAKERCD ";
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSTGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingOrderWork.St_GoodsMakerCd);
            }
            if (scmPrtSettingOrderWork.Ed_GoodsMakerCd != 0)
            {
                retstring += "AND SCM.GOODSMAKERCDRF <= @FINDEDGOODSMAKERCD ";
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@FINDEDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingOrderWork.Ed_GoodsMakerCd);
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
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        /// </remarks>
        private SCMPrtSettingWork CopyToSCMPrtSettingWorkFromReader(ref SqlDataReader myReader)
        {
            SCMPrtSettingWork wkSCMPrtSettingWork = new SCMPrtSettingWork();

            #region クラスへ格納
            wkSCMPrtSettingWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // 作成日時
            wkSCMPrtSettingWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // 更新日時
            wkSCMPrtSettingWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // 企業コード
            wkSCMPrtSettingWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));  // GUID
            wkSCMPrtSettingWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));  // 更新従業員コード
            wkSCMPrtSettingWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));  // 更新アセンブリID1
            wkSCMPrtSettingWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));  // 更新アセンブリID2
            wkSCMPrtSettingWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));  // 論理削除区分
            wkSCMPrtSettingWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));  // 拠点コード
            wkSCMPrtSettingWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));  // 得意先コード
            //wkSCMPrtSettingWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));  // 仕入先コード
            wkSCMPrtSettingWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));  // 商品中分類コード
            wkSCMPrtSettingWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));  // BLグループコード
            wkSCMPrtSettingWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));  // BL商品コード
            wkSCMPrtSettingWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));  // 商品メーカーコード
            wkSCMPrtSettingWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));  // 商品番号
            wkSCMPrtSettingWork.AutoAnswerDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOANSWERDIVRF"));  // 自動回答区分
            wkSCMPrtSettingWork.SectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));  // 拠点名称
            wkSCMPrtSettingWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));  // 得意先名称
            //wkSCMPrtSettingWork.SupplierNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNMRF"));  // 仕入先名称
            wkSCMPrtSettingWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));  // 商品中分類名称
            wkSCMPrtSettingWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));  // BLグループ名称
            wkSCMPrtSettingWork.BLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));  // BL商品コード名称
            wkSCMPrtSettingWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));  // メーカー名称
            wkSCMPrtSettingWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));  // 商品名称
            #endregion

            return wkSCMPrtSettingWork;
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
        /// <br>Date       : 2009.05.08</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            SCMPrtSettingWork[] SCMPrtSettingWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is SCMPrtSettingWork)
                    {
                        SCMPrtSettingWork wkSCMPrtSettingWork = paraobj as SCMPrtSettingWork;
                        if (wkSCMPrtSettingWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkSCMPrtSettingWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            SCMPrtSettingWorkArray = (SCMPrtSettingWork[])XmlByteSerializer.Deserialize(byteArray, typeof(SCMPrtSettingWork[]));
                        }
                        catch (Exception) { }
                        if (SCMPrtSettingWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(SCMPrtSettingWorkArray);
                        }
                        else
                        {
                            try
                            {
                                SCMPrtSettingWork wkSCMPrtSettingWork = (SCMPrtSettingWork)XmlByteSerializer.Deserialize(byteArray, typeof(SCMPrtSettingWork));
                                if (wkSCMPrtSettingWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkSCMPrtSettingWork);
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
        /// <br>Date       : 2009.05.08</br>
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
