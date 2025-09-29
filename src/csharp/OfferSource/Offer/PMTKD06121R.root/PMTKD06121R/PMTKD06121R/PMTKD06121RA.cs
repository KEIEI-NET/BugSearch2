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
using System.Windows.Forms;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 提供車輌情報結合検索DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 提供車輌情報結合検索の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class ColTrmEquInfDB : RemoteDB, IColTrmEquInfDB
    {
        # region --- コンストラクタ ---
        /// <summary>
        /// 類別型式検索リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 96137　久保田　信一</br>
        /// <br>Date       : 2005.04.05</br>
        /// </remarks>
        public ColTrmEquInfDB()
            :
        base("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.ColorCdRetWork", "COLORCDRF")
        {
        }
        # endregion

        /// <summary>
        /// カラー・トリム・装備情報を戻します
        /// </summary>
        /// <param name="colorCdRetWork">検索結果</param>
        /// <param name="trimCdRetWork">型式指定番号</param>
        /// <param name="cEqpDefDspRetWork">類別区分番号</param>
        /// <param name="colTrmEquSearchCondWork"></param>
        /// <returns>STATUS</returns>
        public int SearchColTrmEquInf(out object colorCdRetWork, out object trimCdRetWork, out object cEqpDefDspRetWork, ref object colTrmEquSearchCondWork)
        {
            colorCdRetWork = null;
            trimCdRetWork = null;
            cEqpDefDspRetWork = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                //取得情報一時格納コレクション生成
                ArrayList retArraycolorCdRetWork = new ArrayList();
                ArrayList retArraytrimCdRetWork = new ArrayList();
                ArrayList retArraycEqpDefDspRetWork = new ArrayList();

                ColTrmEquSearchCondWork _colTrmEquSearchCondWork = (ColTrmEquSearchCondWork)colTrmEquSearchCondWork;

                //メソッド開始時にコネクション文字列を取得
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    base.WriteErrorLog("ColTrmEquInfDB.SearchCategoryEquipmentにてエラー発生 ConnectionTextが取得出来ませんでした。");
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }

                //SQL文生成
                SqlConnection sqlConnection = null;
                using (sqlConnection = new SqlConnection(connectionText))   // usingブロックが終わるとdisposeにより切断されるため
                {                                                           // Closeメソッドを別途呼び出ししない。
                    sqlConnection.Open();

                    //カラー情報取得
                    status = SearchColorCd(retArraycolorCdRetWork, _colTrmEquSearchCondWork, sqlConnection, null);
                    if ((retArraycolorCdRetWork.Count > 0) && (status == 0))
                    {
                        colorCdRetWork = (object)retArraycolorCdRetWork;
                    }

                    //トリム情報取得
                    status = SearchTrimCd(retArraytrimCdRetWork, _colTrmEquSearchCondWork, sqlConnection, null);
                    if ((retArraytrimCdRetWork.Count > 0) && (status == 0))
                    {
                        trimCdRetWork = (object)retArraytrimCdRetWork;
                    }

                    //装備情報取得
                    status = SearchCEqpDefDsp(retArraycEqpDefDspRetWork, _colTrmEquSearchCondWork, sqlConnection, null);
                    if ((retArraycEqpDefDspRetWork.Count > 0) && (status == 0))
                    {
                        cEqpDefDspRetWork = (object)retArraycEqpDefDspRetWork;
                    }
                }
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "CategoryModelDesiguationDB.SearchCategoryEquipmentにてSQLエラー発生 Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CategoryModelDesiguationDB.SearchCategoryEquipmentにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        # region --- カラー情報をクラスにセット ---
        /// <summary>
        /// カラー情報をクラスにセット
        /// </summary>
        /// <param name="retArray">検索結果</param>
        /// <param name="colTrmEquSearchCondWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">SQL Transaction</param>
        /// <returns>STATUS</returns>
        public int SearchColorCd(ArrayList retArray, ColTrmEquSearchCondWork colTrmEquSearchCondWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return SearchColorCdProc(retArray, colTrmEquSearchCondWork, sqlConnection, sqlTransaction);
        }

        private int SearchColorCdProc(ArrayList retArray, ColTrmEquSearchCondWork colTrmEquSearchCondWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retArray.Clear();

            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = sqlConnection;
                string select;
                StringBuilder sb = new StringBuilder(1024);
                select = "SELECT "
                    + "SUB.MAKERCODERF, "
                    + "SUB.MODELCODERF, "
                    + "SUB.MODELSUBCODERF, "
                    //+ "SUB.SYSTEMATICCODERF, "
                    //+ "SUB.PRODUCETYPEOFYEARCDRF, "
                    + "SUB.RPCOLORCODERF, "
                    //+ "SUB.COLORCDDUPDERIVEDNORF, "
                    + "SUB.COLORNAME1RF "
                    + "FROM  COLORCDRF SUB "
                    + "WHERE "
                    + "SUB.MAKERCODERF=@FINDMAKERCODE "
                    + "AND SUB.MODELCODERF=@FINDMODELCODE "
                    + "AND SUB.MODELSUBCODERF=@FINDMODELSUBCODE "
                    + "AND SUB.RPCOLORCODERF <> '**' ";
                //+ "AND SUB.SYSTEMATICCODERF=@FINDSYSTEMATICCODE "
                //+ "AND SUB.PRODUCETYPEOFYEARCDRF=@FINDPRODUCETYPEOFYEARCD ";
                if (colTrmEquSearchCondWork.SystematicCode.Length > 0)
                {
                    sb.Append("AND SUB.SYSTEMATICCODERF IN (");
                    for (int i = 0; i < colTrmEquSearchCondWork.SystematicCode.Length; i++)
                    {
                        sb.Append(string.Format("{0}, ", colTrmEquSearchCondWork.SystematicCode[i]));
                    }
                    sb.Remove(sb.Length - 2, 2);
                    sb.Append(") ");
                }
                if (colTrmEquSearchCondWork.ProduceTypeOfYearCd.Length > 0)
                {
                    sb.Append("AND SUB.PRODUCETYPEOFYEARCDRF IN (");
                    for (int i = 0; i < colTrmEquSearchCondWork.ProduceTypeOfYearCd.Length; i++)
                    {
                        sb.Append(string.Format("{0}, ", colTrmEquSearchCondWork.ProduceTypeOfYearCd[i]));
                    }
                    sb.Remove(sb.Length - 2, 2);
                    sb.Append(") ");
                }
                if (colTrmEquSearchCondWork.FullModelFixedNo.Length > 0)
                {
                    sb.Append("AND SUB.FULLMODELFIXEDNORF IN (");
                    for (int i = 0; i < colTrmEquSearchCondWork.FullModelFixedNo.Length; i++)
                    {
                        sb.Append(string.Format("{0}, ", colTrmEquSearchCondWork.FullModelFixedNo[i]));
                    }
                    sb.Remove(sb.Length - 2, 2);
                    sb.Append(") ");
                }
                select += sb.ToString();
                select += "GROUP BY MAKERCODERF, MODELCODERF, MODELSUBCODERF, RPCOLORCODERF, COLORNAME1RF ";
                //select += "GROUP BY MAKERCODERF, MODELCODERF, MODELSUBCODERF, SYSTEMATICCODERF, PRODUCETYPEOFYEARCDRF, ";
                //select += "COLORCODERF, COLORCDDUPDERIVEDNORF, COLORNAME1RF";
                sqlCommand.CommandText = select;

                //Prameterオブジェクトの作成
                SqlParameter findMakerCode = sqlCommand.Parameters.Add("@FINDMAKERCODE", SqlDbType.Int);
                SqlParameter findModelCode = sqlCommand.Parameters.Add("@FINDMODELCODE", SqlDbType.Int);
                SqlParameter findModelSubCode = sqlCommand.Parameters.Add("@FINDMODELSUBCODE", SqlDbType.Int);
                //SqlParameter findSystematicCode = sqlCommand.Parameters.Add("@FINDSYSTEMATICCODE", SqlDbType.Int);
                //SqlParameter findProduceTypeOfYearCd = sqlCommand.Parameters.Add("@FINDPRODUCETYPEOFYEARCD", SqlDbType.Int);

                //Parameterオブジェクトへ類別・型式値設定
                findMakerCode.Value = colTrmEquSearchCondWork.MakerCode;
                findModelCode.Value = colTrmEquSearchCondWork.ModelCode;
                findModelSubCode.Value = colTrmEquSearchCondWork.ModelSubCode;
                //findSystematicCode.Value = colTrmEquSearchCondWork.SystematicCode;
                //findProduceTypeOfYearCd.Value = colTrmEquSearchCondWork.ProduceTypeOfYearCd;

                SqlDataReader myReader = null;
                try
                {
                    myReader = sqlCommand.ExecuteReader();
                    SetColorCdRetWork(myReader, retArray);

                    if (retArray.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException ex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "ColTrmEquInfDB.SearchColorCd Exception=" + ex.Message);
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                finally
                {
                    if (myReader != null && !myReader.IsClosed) myReader.Close();
                }
            }
            return status;
        }
        # endregion

        # region --- カラー情報設定 ---
        /// <summary>
        /// カラー情報設定
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="retArray"></param>
        private void SetColorCdRetWork(SqlDataReader myReader, ArrayList retArray)
        {
            while (myReader.Read())
            {
                ColorCdRetWork wkColorCdRetWork = new ColorCdRetWork();
                wkColorCdRetWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                wkColorCdRetWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));
                wkColorCdRetWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));
                //wkColorCdRetWork.SystematicCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SYSTEMATICCODERF"));
                //wkColorCdRetWork.ProduceTypeOfYearCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRODUCETYPEOFYEARCDRF"));
                wkColorCdRetWork.ColorCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RPCOLORCODERF"));
                //wkColorCdRetWork.ColorCdDupDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLORCDDUPDERIVEDNORF"));
                wkColorCdRetWork.ColorName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORNAME1RF"));
                retArray.Add(wkColorCdRetWork);
            }
        }
        # endregion

        # region --- トリム情報取得 ---
        /// <summary>
        /// トリム情報取得
        /// </summary>
        /// <param name="retArray">検索結果</param>
        /// <param name="colTrmEquSearchCondWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">SQL Transaction</param>
        /// <returns>STATUS</returns>
        public int SearchTrimCd(ArrayList retArray, ColTrmEquSearchCondWork colTrmEquSearchCondWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return SearchTrimCdProc(retArray, colTrmEquSearchCondWork, sqlConnection, sqlTransaction);
        }

        private int SearchTrimCdProc(ArrayList retArray, ColTrmEquSearchCondWork colTrmEquSearchCondWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retArray.Clear();

            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = sqlConnection;
                string select;
                StringBuilder sb = new StringBuilder(1024);
                select =
                    //トリム項目
                    "SELECT "
                    + "TRIMCDRF.MAKERCODERF, "
                    + "TRIMCDRF.MODELCODERF, "
                    + "TRIMCDRF.MODELSUBCODERF, "
                    //+ "TRIMCDRF.SYSTEMATICCODERF, "
                    //+ "TRIMCDRF.PRODUCETYPEOFYEARCDRF, "
                    + "TRIMCDRF.TRIMCODERF, "
                    + "TRIMCDRF.TRIMNAMERF "

                    + "FROM TRIMCDRF "

                    //抽出条件
                    + "WHERE TRIMCDRF.MAKERCODERF=@FINDMAKERCODE "
                    + "AND TRIMCDRF.MODELCODERF=@FINDMODELCODE "
                    + "AND TRIMCDRF.MODELSUBCODERF=@FINDMODELSUBCODE ";
                    //+ "AND TRIMCDRF.SYSTEMATICCODERF=@FINDSYSTEMATICCODE "
                    //+ "AND TRIMCDRF.PRODUCETYPEOFYEARCDRF=@FINDPRODUCETYPEOFYEARCD ";
                if(colTrmEquSearchCondWork.SystematicCode.Length > 0)
                {
                    sb.Append("AND TRIMCDRF.SYSTEMATICCODERF IN (");
                    for (int i = 0; i < colTrmEquSearchCondWork.SystematicCode.Length; i++)
                    {
                        sb.Append(string.Format("{0}, ", colTrmEquSearchCondWork.SystematicCode[i]));
                    }
                    sb.Remove(sb.Length - 2, 2);
                    sb.Append(") ");
                }
                if(colTrmEquSearchCondWork.ProduceTypeOfYearCd.Length > 0)
                {
                    sb.Append("AND TRIMCDRF.PRODUCETYPEOFYEARCDRF IN (");
                    for (int i = 0; i < colTrmEquSearchCondWork.ProduceTypeOfYearCd.Length; i++)
                    {
                        sb.Append(string.Format("{0}, ", colTrmEquSearchCondWork.ProduceTypeOfYearCd[i]));
                    }
                    sb.Remove(sb.Length - 2,2);
                    sb.Append(") ");
                }
                sb.Append(" GROUP BY MAKERCODERF, MODELCODERF, MODELSUBCODERF, TRIMCODERF, TRIMNAMERF");
                sqlCommand.CommandText = select + sb.ToString();
                //Prameterオブジェクトの作成
                SqlParameter findMakerCode = sqlCommand.Parameters.Add("@FINDMAKERCODE", SqlDbType.Int);
                SqlParameter findModelCode = sqlCommand.Parameters.Add("@FINDMODELCODE", SqlDbType.Int);
                SqlParameter findModelSubCode = sqlCommand.Parameters.Add("@FINDMODELSUBCODE", SqlDbType.Int);
                //SqlParameter findSystematicCode = sqlCommand.Parameters.Add("@FINDSYSTEMATICCODE", SqlDbType.Int);
                //SqlParameter findProduceTypeOfYearCd = sqlCommand.Parameters.Add("@FINDPRODUCETYPEOFYEARCD", SqlDbType.Int);

                //Parameterオブジェクトへ類別・型式値設定
                findMakerCode.Value = colTrmEquSearchCondWork.MakerCode;
                findModelCode.Value = colTrmEquSearchCondWork.ModelCode;
                findModelSubCode.Value = colTrmEquSearchCondWork.ModelSubCode;
                //findSystematicCode.Value = colTrmEquSearchCondWork.SystematicCode;
                //findProduceTypeOfYearCd.Value = colTrmEquSearchCondWork.ProduceTypeOfYearCd;

                SqlDataReader myReader = null;
                try
                {
                    myReader = sqlCommand.ExecuteReader();
                    SetTrimCdRetWork(myReader, retArray);

                    if (retArray.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException ex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "ColTrmEquInfDB.SearchTrimCd Exception=" + ex.Message);
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                finally
                {
                    if (myReader != null && !myReader.IsClosed) myReader.Close();
                }
            }
            return status;
        }

        # endregion

        # region --- トリム情報をクラスにセット ---
        /// <summary>
        /// トリム情報をクラスにセット
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="retArray"></param>
        private void SetTrimCdRetWork(SqlDataReader myReader, ArrayList retArray)
        {
            while (myReader.Read())
            {
                TrimCdRetWork wkTrimCdRetWork = new TrimCdRetWork();
                wkTrimCdRetWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                wkTrimCdRetWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));
                wkTrimCdRetWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));
                //wkTrimCdRetWork.SystematicCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SYSTEMATICCODERF"));
                //wkTrimCdRetWork.ProduceTypeOfYearCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRODUCETYPEOFYEARCDRF"));
                wkTrimCdRetWork.TrimCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMCODERF"));
                wkTrimCdRetWork.TrimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMNAMERF"));
                retArray.Add(wkTrimCdRetWork);
            }
        }
        # endregion

        # region --- 装備情報取得 ---
        /// <summary>
        /// 装備情報取得
        /// </summary>
        /// <param name="retArray">検索結果</param>
        /// <param name="colTrmEquSearchCondWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">SQL Transaction</param>
        /// <returns>STATUS</returns>
        public int SearchCEqpDefDsp(ArrayList retArray, ColTrmEquSearchCondWork colTrmEquSearchCondWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return SearchCEqpDefDspProc(retArray, colTrmEquSearchCondWork, sqlConnection, sqlTransaction);
        }

        private int SearchCEqpDefDspProc(ArrayList retArray, ColTrmEquSearchCondWork colTrmEquSearchCondWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retArray.Clear();

            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = sqlConnection;
                string select;
                StringBuilder sb = new StringBuilder(1024);
                select = "SELECT "      //装備項目                    
                    + "CEQPDEFDSPRF.MAKERCODERF, "
                    + "CEQPDEFDSPRF.MODELCODERF, "
                    + "CEQPDEFDSPRF.MODELSUBCODERF, "
                    + "CEQPDEFDSPRF.SYSTEMATICCODERF, "

                    + "CEQPDEFDSPRF.EQUIPMENTDISPORDERRF, "
                    + "CEQPDEFDSPRF.EQUIPMENTGENRECDRF, "
                    + "CEQPDEFDSPRF.EQUIPMENTGENRENMRF, "
                    + "CEQPDEFDSPRF.EQUIPMENTCODERF, "
                    + "CEQPDEFDSPRF.EQUIPMENTNAMERF, "
                    + "CEQPDEFDSPRF.EQUIPMENTSHORTNAMERF, "
                    + "CEQPDEFDSPRF.EQUIPMENTICONCODERF "

                    + "FROM CEQPDEFDSPRF "

                    //抽出条件
                    + "WHERE CEQPDEFDSPRF.MAKERCODERF=@FINDMAKERCODE "
                    + "AND CEQPDEFDSPRF.MODELCODERF=@FINDMODELCODE "
                    + "AND CEQPDEFDSPRF.MODELSUBCODERF=@FINDMODELSUBCODE ";
                    //+ "AND CEQPDEFDSPRF.SYSTEMATICCODERF=@FINDSYSTEMATICCODE ";

                if (colTrmEquSearchCondWork.SystematicCode.Length > 0)
                {
                    sb.Append("AND CEQPDEFDSPRF.SYSTEMATICCODERF IN (");
                    for (int i = 0; i < colTrmEquSearchCondWork.SystematicCode.Length; i++)
                    {
                        sb.Append(string.Format("{0}, ", colTrmEquSearchCondWork.SystematicCode[i]));
                    }
                    sb.Remove(sb.Length - 2, 2);
                    sb.Append(") ");
                }
                sqlCommand.CommandText = select + sb.ToString();
                //Prameterオブジェクトの作成
                SqlParameter findMakerCode = sqlCommand.Parameters.Add("@FINDMAKERCODE", SqlDbType.Int);
                SqlParameter findModelCode = sqlCommand.Parameters.Add("@FINDMODELCODE", SqlDbType.Int);
                SqlParameter findModelSubCode = sqlCommand.Parameters.Add("@FINDMODELSUBCODE", SqlDbType.Int);
                //SqlParameter findSystematicCode = sqlCommand.Parameters.Add("@FINDSYSTEMATICCODE", SqlDbType.Int);

                //Parameterオブジェクトへ類別・型式値設定
                findMakerCode.Value = colTrmEquSearchCondWork.MakerCode;
                findModelCode.Value = colTrmEquSearchCondWork.ModelCode;
                findModelSubCode.Value = colTrmEquSearchCondWork.ModelSubCode;
                //findSystematicCode.Value = colTrmEquSearchCondWork.SystematicCode;

                SqlDataReader myReader = null;
                try
                {
                    myReader = sqlCommand.ExecuteReader();
                    SetCEqpDefDspRetWork(myReader, retArray);
                    //while (myReader.Read())
                    //{
                    //    CEqpDefDspRetWork wkCEqpDefDspRetWork = SetCEqpDefDspRetWork(myReader);
                    //    retArray.Add(wkCEqpDefDspRetWork);
                    //}
                    if (retArray.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException ex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "ColTrmEquInfDB.SearchCEqpDefDsp Exception=" + ex.Message);
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                finally
                {
                    if (myReader != null && !myReader.IsClosed)
                        myReader.Close();
                }
            }
            return status;
        }
        # endregion

        # region --- 装備情報をクラスにセット ---
        /// <summary>
        /// 装備情報をクラスにセット
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="retArray"></param>
        private void SetCEqpDefDspRetWork(SqlDataReader myReader, ArrayList retArray)
        {
            while (myReader.Read())
            {
                CEqpDefDspRetWork wkCEqpDefDspRetWork = new CEqpDefDspRetWork();
                wkCEqpDefDspRetWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                wkCEqpDefDspRetWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));
                wkCEqpDefDspRetWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));
                wkCEqpDefDspRetWork.SystematicCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SYSTEMATICCODERF"));
                wkCEqpDefDspRetWork.EquipmentDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPMENTDISPORDERRF"));
                wkCEqpDefDspRetWork.EquipmentGenreCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPMENTGENRECDRF"));
                wkCEqpDefDspRetWork.EquipmentGenreNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EQUIPMENTGENRENMRF"));
                wkCEqpDefDspRetWork.EquipmentCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPMENTCODERF"));
                wkCEqpDefDspRetWork.EquipmentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EQUIPMENTNAMERF"));
                wkCEqpDefDspRetWork.EquipmentShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EQUIPMENTSHORTNAMERF"));
                wkCEqpDefDspRetWork.EquipmentIconCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPMENTICONCODERF"));

                retArray.Add(wkCEqpDefDspRetWork);
            }
        }
        # endregion
    }
}
