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
    /// 重点品目設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 重点品目設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30350　櫻井　亮太</br>
    /// <br>Date       : 2009.04.28</br>
    /// </remarks>
    [Serializable]
    public class ImportantPrtStDB : RemoteDB, IImportantPrtStDB
    {
        /// <summary>
        /// 重点品目設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        public ImportantPrtStDB()
            :
            base("PMKHN09557D", "Broadleaf.Application.Remoting.ParamData.ImportantPrtStWork", "IMPORTANTPRTSTRF")
        {
        }

        private const string _allSecCode = "00";

        #region [Search]
        /// <summary>
        /// 指定された条件の重点品目設定マスタ情報LISTを戻します
        /// </summary>
        /// <param name="importantPrtStWork">検索結果</param>
        /// <param name="paraimportantPrtStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の重点品目設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        public int Search(out object importantPrtStWork, object paraimportantPrtStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            importantPrtStWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchImportantPrtStProc(out importantPrtStWork, paraimportantPrtStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMngTtlStDB.Search");
                importantPrtStWork = new ArrayList();
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
        /// 指定された条件の重点品目設定マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="paraimportantPrtStWork">検索結果</param>
        /// <param name="objimportantPrtStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の重点品目設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchImportantPrtStProc(out object objimportantPrtStWork, object paraimportantPrtStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            ArrayList importantPrtStWorkList = new ArrayList();

            ImportantPrtStOrderWork importantPrtStWork = null;

            if (paraimportantPrtStWork != null)
            {
                importantPrtStWork = paraimportantPrtStWork as ImportantPrtStOrderWork;
            }
            else
            {
                importantPrtStWork = new ImportantPrtStOrderWork();
            }

            int status = SearchImportantPrtStProc(out importantPrtStWorkList, importantPrtStWork, readMode, logicalMode, ref sqlConnection);
            objimportantPrtStWork = importantPrtStWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の重点品目設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="importantPrtStWorkList">検索結果</param>
        /// <param name="importantPrtStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の重点品目設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchImportantPrtStProc(out ArrayList importantPrtStWorkList, ImportantPrtStOrderWork importantPrtStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchImportantPrtStProcProc(out importantPrtStWorkList, importantPrtStWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の重点品目設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="importantPrtStWorkList">検索結果</param>
        /// <param name="importantPrtStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の重点品目設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        private int SearchImportantPrtStProcProc(out ArrayList importantPrtStWorkList, ImportantPrtStOrderWork importantPrtStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;

                #region SELECT
                selectTxt += " SELECT SCM.CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,SCM.LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.CUSTOMERCODERF " + Environment.NewLine;
                //selectTxt += "         ,SUPPLIERCDRF " + Environment.NewLine;
                selectTxt += "         ,SCM.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "         ,BLG.BLGROUPCODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "         ,SCM.GOODSNORF " + Environment.NewLine;
                selectTxt += "         ,SCM.VALIDDIVCDRF " + Environment.NewLine;
                selectTxt += "         ,SEC.SECTIONGUIDENMRF " + Environment.NewLine;
                selectTxt += "         ,CUS.CUSTOMERSNMRF " + Environment.NewLine;
                //selectTxt += "         ,SUPPLIERNMRF " + Environment.NewLine;
                selectTxt += "         ,GOO.GOODSMGROUPNAMERF " + Environment.NewLine;
                selectTxt += "         ,GRO.BLGROUPNAMERF " + Environment.NewLine;
                selectTxt += "         ,BLG.BLGOODSFULLNAMERF " + Environment.NewLine;
                selectTxt += "         ,MAK.MAKERNAMERF " + Environment.NewLine;
                selectTxt += "         ,GOD.GOODSNAMERF " + Environment.NewLine;
                selectTxt += "  FROM IMPORTANTPRTSTRF AS SCM" + Environment.NewLine;
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

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, importantPrtStWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToImportantPrtStWorkFromReader(ref myReader));

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

            importantPrtStWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の重点品目設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">ImportantPrtStWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫管理全体設定マスタを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            try
            {
                ImportantPrtStWork importantPrtStWork = new ImportantPrtStWork();

                // XMLの読み込み
                importantPrtStWork = (ImportantPrtStWork)XmlByteSerializer.Deserialize(parabyte, typeof(ImportantPrtStWork));
                if (importantPrtStWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref importantPrtStWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(importantPrtStWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMngTtlStDB.Read");
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
        /// 指定された条件の在庫管理全体設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="importantPrtStWork">StockMngTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫管理全体設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        public int ReadProc(ref ImportantPrtStWork importantPrtStWork, int readMode, ref SqlConnection sqlConnection)
        {
            return this.ReadProcProc(ref importantPrtStWork, readMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の在庫管理全体設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="importantPrtStWork">StockMngTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫管理全体設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        private int ReadProcProc(ref ImportantPrtStWork importantPrtStWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = string.Empty;
                selectTxt += " SELECT SCM.CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,SCM.LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.CUSTOMERCODERF " + Environment.NewLine;
                //selectTxt += "         ,SUPPLIERCDRF " + Environment.NewLine;
                selectTxt += "         ,SCM.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "         ,BLG.BLGROUPCODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "         ,SCM.GOODSNORF " + Environment.NewLine;
                selectTxt += "         ,SCM.VALIDDIVCDRF " + Environment.NewLine;
                selectTxt += "         ,SEC.SECTIONGUIDENMRF " + Environment.NewLine;
                selectTxt += "         ,CUS.CUSTOMERSNMRF " + Environment.NewLine;
                //selectTxt += "         ,SUPPLIERNMRF " + Environment.NewLine;
                selectTxt += "         ,GOO.GOODSMGROUPNAMERF " + Environment.NewLine;
                selectTxt += "         ,GRO.BLGROUPNAMERF " + Environment.NewLine;
                selectTxt += "         ,BLG.BLGOODSFULLNAMERF " + Environment.NewLine;
                selectTxt += "         ,MAK.MAKERNAMERF " + Environment.NewLine;
                selectTxt += "         ,GOD.GOODSNAMERF " + Environment.NewLine;
                selectTxt += "  FROM IMPORTANTPRTSTRF AS SCM" + Environment.NewLine;
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
                //selectTxt += "         AND SUPPLIERCDRF = @FINDSUPPLIERCD " + Environment.NewLine;
                selectTxt += "         AND SCM.GOODSMGROUPRF = @FINDGOODSMGROUP " + Environment.NewLine;
                //selectTxt += "         AND BLGROUPCODERF = @FINDBLGROUPCODE " + Environment.NewLine;
                selectTxt += "         AND SCM.BLGOODSCODERF = @FINDBLGOODSCODE " + Environment.NewLine;
                selectTxt += "         AND SCM.GOODSMAKERCDRF = @FINDGOODSMAKERCD " + Environment.NewLine;
                selectTxt += "         AND SCM.GOODSNORF = @FINDGOODSNO " + Environment.NewLine;

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
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(importantPrtStWork.EnterpriseCode);
                    findParaSectionCode.Value = importantPrtStWork.SectionCode.Trim();
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.CustomerCode);
                    //paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.SupplierCd);
                    paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.GoodsMGroup);
                    //paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.BLGroupCode);
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.BLGoodsCode);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.GoodsMakerCd);
                    paraGoodsNo.Value = importantPrtStWork.GoodsNo.Trim();

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        importantPrtStWork = CopyToImportantPrtStWorkFromReader(ref myReader);
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
        /// 重点品目設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="importantPrtStWork">ImportantPrtStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 重点品目設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        public int Write(ref object importantPrtStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(importantPrtStWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteImportantPrtStProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                ImportantPrtStWork paraWork = paraList[0] as ImportantPrtStWork;
                
                //全社設定を更新した場合は、他の項目にも反映させる
                if (paraWork.SectionCode == _allSecCode)
                {
                    UpdateAllSecStockMngTtlSt(ref paraList, ref sqlConnection, ref sqlTransaction);
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
                importantPrtStWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ImportantPrtStDB.Write(ref object importantPrtStWork)");
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
        /// 重点品目設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="importantPrtStWorkList">ImportantPrtStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 重点品目設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        public int WriteImportantPrtStProc(ref ArrayList importantPrtStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteImportantPrtStProcProc(ref importantPrtStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 重点品目設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="importantPrtStWorkList">ImportantPrtStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 重点品目設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        private int WriteImportantPrtStProcProc(ref ArrayList importantPrtStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (importantPrtStWorkList != null)
                {
                    for (int i = 0; i < importantPrtStWorkList.Count; i++)
                    {
                        ImportantPrtStWork importantPrtStWork = importantPrtStWorkList[i] as ImportantPrtStWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM IMPORTANTPRTSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND GOODSNORF = @FINDGOODSNO", sqlConnection, sqlTransaction);

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
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(importantPrtStWork.EnterpriseCode);
                        findParaSectionCode.Value = importantPrtStWork.SectionCode.Trim();
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.CustomerCode);
                        //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.SupplierCd);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.GoodsMGroup);
                        //findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.BLGoodsCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.GoodsMakerCd);
                        findParaGoodsNo.Value = importantPrtStWork.GoodsNo.Trim();

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != importantPrtStWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (importantPrtStWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region 更新時のSQL文生成
                            string sqlText = string.Empty;
                            sqlText += " UPDATE IMPORTANTPRTSTRF SET " + Environment.NewLine;
                            sqlText += "    CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
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
                            sqlText += "  , VALIDDIVCDRF = @VALIDDIVCD " + Environment.NewLine;
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
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(importantPrtStWork.EnterpriseCode);
                            findParaSectionCode.Value = importantPrtStWork.SectionCode.Trim();
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.CustomerCode);
                            //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.SupplierCd);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.GoodsMGroup);
                            //findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.BLGroupCode);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.BLGoodsCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.GoodsMakerCd);
                            findParaGoodsNo.Value = importantPrtStWork.GoodsNo.Trim();

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)importantPrtStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (importantPrtStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region 新規作成時のSQL文を生成
                            string sqlText = string.Empty;
                            sqlText += " INSERT INTO IMPORTANTPRTSTRF " + Environment.NewLine;
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
                            sqlText += "         ,VALIDDIVCDRF " + Environment.NewLine;
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
                            sqlText += "         ,@VALIDDIVCD " + Environment.NewLine;
                            sqlText += "  ) " + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)importantPrtStWork;
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
                        SqlParameter paraValidDivCd = sqlCommand.Parameters.Add("@VALIDDIVCD", SqlDbType.Int);  // 有効区分
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(importantPrtStWork.CreateDateTime);  // 作成日時
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(importantPrtStWork.UpdateDateTime);  // 更新日時
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(importantPrtStWork.EnterpriseCode);  // 企業コード
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(importantPrtStWork.FileHeaderGuid);  // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(importantPrtStWork.UpdEmployeeCode);  // 更新従業員コード
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(importantPrtStWork.UpdAssemblyId1);  // 更新アセンブリID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(importantPrtStWork.UpdAssemblyId2);  // 更新アセンブリID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.LogicalDeleteCode);  // 論理削除区分
                        paraSectionCode.Value = importantPrtStWork.SectionCode.Trim();  // 拠点コード
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.CustomerCode);  // 得意先コード
                        //paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.SupplierCd);  // 仕入先コード
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.GoodsMGroup);  // 商品中分類コード
                        //paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.BLGroupCode);  // BLグループコード
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.BLGoodsCode);  // BL商品コード
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.GoodsMakerCd);  // 商品メーカーコード
                        paraGoodsNo.Value = importantPrtStWork.GoodsNo.Trim();  // 商品番号
                        paraValidDivCd.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.ValidDivCd);  // 有効区分
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(importantPrtStWork);
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

            importantPrtStWorkList = al;

            return status;
        }

        /// <summary>
        /// 全社共通項目を更新する
        /// </summary>
        /// <param name="importantPrtStWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 重点品目設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        private int UpdateAllSecStockMngTtlSt(ref ArrayList importantPrtStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (importantPrtStWorkList != null)
                {
                    ImportantPrtStWork importantPrtStWork = importantPrtStWorkList[0] as ImportantPrtStWork;

                    sqlCommand = new SqlCommand("",sqlConnection,sqlTransaction);
                    # region 更新時のSQL文生成
                    string sqlText = string.Empty;
                    sqlText += " UPDATE IMPORTANTPRTSTRF SET " + Environment.NewLine;
                    sqlText += "    CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
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
                    sqlText += "  , VALIDDIVCDRF = @VALIDDIVCD " + Environment.NewLine;
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

                    //更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)importantPrtStWork;
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
                    SqlParameter paraValidDivCd = sqlCommand.Parameters.Add("@VALIDDIVCD", SqlDbType.Int);  // 有効区分
                    #endregion

                    #region Parameterオブジェクトへ値設定(更新用)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(importantPrtStWork.CreateDateTime);  // 作成日時
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(importantPrtStWork.UpdateDateTime);  // 更新日時
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(importantPrtStWork.EnterpriseCode);  // 企業コード
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(importantPrtStWork.FileHeaderGuid);  // GUID
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(importantPrtStWork.UpdEmployeeCode);  // 更新従業員コード
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(importantPrtStWork.UpdAssemblyId1);  // 更新アセンブリID1
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(importantPrtStWork.UpdAssemblyId2);  // 更新アセンブリID2
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.LogicalDeleteCode);  // 論理削除区分
                    paraSectionCode.Value = importantPrtStWork.SectionCode.Trim();  // 拠点コード
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.CustomerCode);  // 得意先コード
                    //paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.SupplierCd);  // 仕入先コード
                    paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.GoodsMGroup);  // 商品中分類コード
                    //paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.BLGroupCode);  // BLグループコード
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.BLGoodsCode);  // BL商品コード
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.GoodsMakerCd);  // 商品メーカーコード
                    paraGoodsNo.Value = importantPrtStWork.GoodsNo.Trim();  // 商品番号
                    paraValidDivCd.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.ValidDivCd);  // 有効区分
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
        /// 重点品目設定マスタ情報を論理削除します
        /// </summary>
        /// <param name="importantPrtStWork">オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 重点品目設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        public int LogicalDelete(ref object importantPrtStWork)
        {
            return LogicalDeleteImportantPrtSt(ref importantPrtStWork, 0);
        }

        /// <summary>
        /// 論理削除重点品目設定マスタ情報を復活します
        /// </summary>
        /// <param name="importantPrtStWork">ImportantPrtStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除重点品目設定マスタ情報を復活します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        public int RevivalLogicalDelete(ref object importantPrtStWork)
        {
            return LogicalDeleteImportantPrtSt(ref importantPrtStWork, 1);
        }

        /// <summary>
        /// 重点品目設定マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="stockmngttlstWork">ImportantPrtStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 重点品目設定マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        private int LogicalDeleteImportantPrtSt(ref object importantPrtStWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(importantPrtStWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteImportantPrtStProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "ImportantPrtStDB.LogicalDeleteimportantPrtSt :" + procModestr);

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
        /// 重点品目設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 重点品目設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        public int LogicalDeleteImportantPrtStProc(ref ArrayList importantPrtStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteImportantPrtStProcProc(ref importantPrtStWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 重点品目設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 重点品目設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        private int LogicalDeleteImportantPrtStProcProc(ref ArrayList importantPrtStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (importantPrtStWorkList != null)
                {
                    for (int i = 0; i < importantPrtStWorkList.Count; i++)
                    {
                        ImportantPrtStWork importantPrtStWork = importantPrtStWorkList[i] as ImportantPrtStWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM IMPORTANTPRTSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND GOODSNORF = @FINDGOODSNO", sqlConnection, sqlTransaction);

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
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(importantPrtStWork.EnterpriseCode);
                        findParaSectionCode.Value = importantPrtStWork.SectionCode.Trim();
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.CustomerCode);
                        //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.SupplierCd);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.GoodsMGroup);
                        //findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.BLGoodsCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.GoodsMakerCd);
                        findParaGoodsNo.Value = importantPrtStWork.GoodsNo.Trim();

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != importantPrtStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE IMPORTANTPRTSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND GOODSNORF = @FINDGOODSNO";
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(importantPrtStWork.EnterpriseCode);
                            findParaSectionCode.Value = importantPrtStWork.SectionCode.Trim();
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.CustomerCode);
                            //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.SupplierCd);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.GoodsMGroup);
                            //findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.BLGroupCode);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.BLGoodsCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.GoodsMakerCd);
                            findParaGoodsNo.Value = importantPrtStWork.GoodsNo.Trim();

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)importantPrtStWork;
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
                            else if (logicalDelCd == 0) importantPrtStWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else importantPrtStWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) importantPrtStWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(importantPrtStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(importantPrtStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(importantPrtStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(importantPrtStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(importantPrtStWork);
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

            importantPrtStWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 重点品目設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">重点品目設定マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 重点品目設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
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

                status = DeletImportantPrtStProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "StockMngTtlStDB.Delete");
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
        /// 重点品目設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="importantPrtStWorkList">重点品目設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 重点品目設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        public int DeletImportantPrtStProc(ArrayList importantPrtStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeletImportantPrtStProcProc(importantPrtStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 重点品目設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="importantPrtStWorkList">重点品目設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 在庫管理全体設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        private int DeletImportantPrtStProcProc(ArrayList importantPrtStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < importantPrtStWorkList.Count; i++)
                {
                    ImportantPrtStWork importantPrtStWork = importantPrtStWorkList[i] as ImportantPrtStWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM IMPORTANTPRTSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND GOODSNORF = @FINDGOODSNO", sqlConnection, sqlTransaction);

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
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(importantPrtStWork.EnterpriseCode);
                    findParaSectionCode.Value = importantPrtStWork.SectionCode.Trim();
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.CustomerCode);
                    //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.SupplierCd);
                    findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.GoodsMGroup);
                    //findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.BLGroupCode);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.BLGoodsCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.GoodsMakerCd);
                    findParaGoodsNo.Value = importantPrtStWork.GoodsNo.Trim();

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != importantPrtStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM IMPORTANTPRTSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND GOODSNORF = @FINDGOODSNO";
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(importantPrtStWork.EnterpriseCode);
                        findParaSectionCode.Value = importantPrtStWork.SectionCode.Trim();
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.CustomerCode);
                        //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.SupplierCd);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.GoodsMGroup);
                        //findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.BLGoodsCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.GoodsMakerCd);
                        findParaGoodsNo.Value = importantPrtStWork.GoodsNo.Trim();
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
        /// <param name="importantPrtStWork">検索条件格納クラス</param>
	    /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
	    /// <returns>Where条件文字列</returns>
	    /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, ImportantPrtStOrderWork importantPrtStWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

            //企業コード
            retstring += "SCM.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(importantPrtStWork.EnterpriseCode);

            //拠点コード
            if (string.IsNullOrEmpty(importantPrtStWork.SectionCode) == false)
            {
                retstring += "AND SCM.SECTIONCODERF=@SECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(importantPrtStWork.SectionCode);
            }

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND SCM.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND SCM.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // 得意先コード
            if (importantPrtStWork.St_CustomerCode != 0)
            {
                retstring += "AND SCM.CUSTOMERCODERF >= @FINDSTCUSTOMERCODE ";
                SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@FINDSTCUSTOMERCODE", SqlDbType.Int);
                paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.St_CustomerCode);
            }
            if (importantPrtStWork.Ed_CustomerCode != 0)
            {
                retstring += "AND SCM.CUSTOMERCODERF <= @FINDEDCUSTOMERCODE ";
                SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@FINDEDCUSTOMERCODE", SqlDbType.Int);
                paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.Ed_CustomerCode);
            }

            // 商品中分類コード
            if (importantPrtStWork.St_GoodsMGroup != 0)
            {
                retstring += "AND SCM.GOODSMGROUPRF >= @FINDSTGOODSMGROUP ";
                SqlParameter paraStGoodsMGroup = sqlCommand.Parameters.Add("@FINDSTGOODSMGROUP", SqlDbType.Int);
                paraStGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.St_GoodsMGroup);
            }
            if (importantPrtStWork.Ed_GoodsMGroup != 0)
            {
                retstring += "AND SCM.GOODSMGROUPRF <= @FINDEDGOODSMGROUP ";
                SqlParameter paraEdGoodsMGroup = sqlCommand.Parameters.Add("@FINDEDGOODSMGROUP", SqlDbType.Int);
                paraEdGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.Ed_GoodsMGroup);
            }

            // BLグループコード
            if (importantPrtStWork.St_BLGroupCode != 0)
            {
                retstring += "AND BLG.BLGROUPCODERF >= @FINDSTBLGROUPCODE ";
                SqlParameter paraStBLGroupCode = sqlCommand.Parameters.Add("@FINDSTBLGROUPCODE", SqlDbType.Int);
                paraStBLGroupCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.St_BLGroupCode);
            }
            if (importantPrtStWork.Ed_BLGroupCode != 0)
            {
                retstring += "AND BLG.BLGROUPCODERF <= @FINDEDBLGROUPCODE ";
                SqlParameter paraEdBLGroupCode = sqlCommand.Parameters.Add("@FINDEDBLGROUPCODE", SqlDbType.Int);
                paraEdBLGroupCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.Ed_BLGroupCode);
            }

            // BL商品コード
            if (importantPrtStWork.St_BLGoodsCode != 0)
            {
                retstring += "AND SCM.BLGOODSCODERF >= @FINDSTBLGOODSCODE ";
                SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@FINDSTBLGOODSCODE", SqlDbType.Int);
                paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.St_BLGoodsCode);
            }
            if (importantPrtStWork.Ed_BLGoodsCode != 0)
            {
                retstring += "AND SCM.BLGOODSCODERF <= @FINDEDBLGOODSCODE ";
                SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@FINDEDBLGOODSCODE", SqlDbType.Int);
                paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.Ed_BLGoodsCode);
            }

            // メーカーコード
            if (importantPrtStWork.St_GoodsMakerCd != 0)
            {
                retstring += "AND SCM.GOODSMAKERCDRF >= @FINDSTGOODSMAKERCD ";
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSTGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.St_GoodsMakerCd);
            }
            if (importantPrtStWork.Ed_GoodsMakerCd != 0)
            {
                retstring += "AND SCM.GOODSMAKERCDRF <= @FINDEDGOODSMAKERCD ";
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@FINDEDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(importantPrtStWork.Ed_GoodsMakerCd);
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
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        private ImportantPrtStWork CopyToImportantPrtStWorkFromReader(ref SqlDataReader myReader)
        {
            ImportantPrtStWork wkImportantPrtStWork = new ImportantPrtStWork();

            #region クラスへ格納
            wkImportantPrtStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // 作成日時
            wkImportantPrtStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // 更新日時
            wkImportantPrtStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // 企業コード
            wkImportantPrtStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));  // GUID
            wkImportantPrtStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));  // 更新従業員コード
            wkImportantPrtStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));  // 更新アセンブリID1
            wkImportantPrtStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));  // 更新アセンブリID2
            wkImportantPrtStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));  // 論理削除区分
            wkImportantPrtStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));  // 拠点コード
            wkImportantPrtStWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));  // 得意先コード
            //wkImportantPrtStWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));  // 仕入先コード
            wkImportantPrtStWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));  // 商品中分類コード
            wkImportantPrtStWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));  // BLグループコード
            wkImportantPrtStWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));  // BL商品コード
            wkImportantPrtStWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));  // 商品メーカーコード
            wkImportantPrtStWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));  // 商品番号
            wkImportantPrtStWork.SectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));  // 拠点名称
            wkImportantPrtStWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));  // 得意先名称
            //wkImportantPrtStWork.SupplierNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNMRF"));  // 仕入先名称
            wkImportantPrtStWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));  // 商品中分類名称
            wkImportantPrtStWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));  // BLグループ名称
            wkImportantPrtStWork.BLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));  // BL商品コード名称
            wkImportantPrtStWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));  // メーカー名称
            wkImportantPrtStWork.ValidDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("VALIDDIVCDRF"));　//有効区分


            #endregion

            return wkImportantPrtStWork;
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
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            ImportantPrtStWork[] ImportantPrtStWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is ImportantPrtStWork)
                    {
                        ImportantPrtStWork wkImportantPrtStWork = paraobj as ImportantPrtStWork;
                        if (wkImportantPrtStWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkImportantPrtStWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            ImportantPrtStWorkArray = (ImportantPrtStWork[])XmlByteSerializer.Deserialize(byteArray, typeof(ImportantPrtStWork[]));
                        }
                        catch (Exception) { }
                        if (ImportantPrtStWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(ImportantPrtStWorkArray);
                        }
                        else
                        {
                            try
                            {
                                ImportantPrtStWork wkImportantPrtStWork = (ImportantPrtStWork)XmlByteSerializer.Deserialize(byteArray, typeof(ImportantPrtStWork));
                                if (wkImportantPrtStWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkImportantPrtStWork);
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
        /// <br>Date       : 2009.04.28</br>
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
