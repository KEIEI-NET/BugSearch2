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
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// 年式情報取得リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 年式情報取得の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 96186　立花　裕輔</br>
    /// <br>Date       : 2007.03.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class PrdTypYearDB : RemoteDB, IPrdTypYearDB
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
        public PrdTypYearDB()
            :
        base("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.PrdTypYearRetWork", "PRDTYPYEARRF")
        {
        }
        # endregion

        /// <summary>
        /// 生産年式情報を戻します
        /// </summary>
        /// <param name="prdTypYearRetWork">検索結果</param>
        /// <param name="prdTypYearCondWork">年式指定</param>
        /// <returns>STATUS</returns>
        public int SearchPrdTypYearInf(out object prdTypYearRetWork, object prdTypYearCondWork)
        {
            prdTypYearRetWork = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            try
            {
                //装備情報一時格納コレクション生成
                ArrayList retArrayprdTypYearRetWork = new ArrayList();
                PrdTypYearCondWork _prdTypYearCondWork = (PrdTypYearCondWork)prdTypYearCondWork;

                //メソッド開始時にコネクション文字列を取得
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    base.WriteErrorLog("PrdTypYearDB.SearchPrdTypYearInfにてエラー発生 ConnectionTextが取得出来ませんでした。");
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }

                //SQL文生成
                SqlConnection sqlConnection = null;
                using (sqlConnection = new SqlConnection(connectionText))
                {
                    sqlConnection.Open();

                    //類別装備情報取得
                    status = SearchPrdTypYear(retArrayprdTypYearRetWork, _prdTypYearCondWork, sqlConnection, null);

                    //戻り値を設定
                    if ((retArrayprdTypYearRetWork.Count > 0) && (status == 0))
                    {
                        prdTypYearRetWork = (object)retArrayprdTypYearRetWork;
                    }
                }
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "PrdTypYearDB.SearchPrdTypYearInfにてSQLエラー発生 Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrdTypYearDB.SearchPrdTypYearInfにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        # region --- 生産年式情報取得 ---
        /// <summary>
        /// 生産年式情報取得
        /// </summary>
        /// <param name="retArray">検索結果</param>
        /// <param name="prdTypYearCondWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">SQL Transaction</param>
        /// <returns>STATUS</returns>
        public int SearchPrdTypYear(ArrayList retArray, PrdTypYearCondWork prdTypYearCondWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return SearchPrdTypYearProc(retArray, prdTypYearCondWork, sqlConnection, sqlTransaction);
        }

        private int SearchPrdTypYearProc(ArrayList retArray, PrdTypYearCondWork prdTypYearCondWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retArray.Clear();

            using (SqlCommand sqlCommand = new SqlCommand())
            {
                string cmdText;
                sqlCommand.Connection = sqlConnection;

                cmdText =
                    //生産年式項目
                    "SELECT "
                    + "PRDTYPYEARRF.MAKERCODERF, "
                    + "PRDTYPYEARRF.FRAMEMODELRF, "
                    + "PRDTYPYEARRF.STPRODUCEFRAMENORF, "
                    + "PRDTYPYEARRF.EDPRODUCEFRAMENORF, "
                    + "PRDTYPYEARRF.PRODUCETYPEOFYEARRF "

                    + "FROM PRDTYPYEARRF "

                    //抽出条件
                    + "WHERE PRDTYPYEARRF.MAKERCODERF=@FINDMAKERCODE "
                    + "AND PRDTYPYEARRF.FRAMEMODELRF=@FINDFRAMEMODEL ";

                //Prameterオブジェクトの作成
                SqlParameter findMakerCode = sqlCommand.Parameters.Add("@FINDMAKERCODE", SqlDbType.Int);
                SqlParameter findFrameModel = sqlCommand.Parameters.Add("@FINDFRAMEMODEL", SqlDbType.NVarChar);

                //Parameterオブジェクトへ類別・型式値設定
                findMakerCode.Value = prdTypYearCondWork.MakerCode;
                findFrameModel.Value = prdTypYearCondWork.FrameModel;

                if (prdTypYearCondWork.StProduceTypeOfYear != 0)
                {
                    cmdText += " AND PRDTYPYEARRF.PRODUCETYPEOFYEARRF >= @FINDSTPRODUCETYPEOFYEAR ";
                    ((SqlParameter)sqlCommand.Parameters.Add("@FINDSTPRODUCETYPEOFYEAR", SqlDbType.NVarChar)).Value =
                        prdTypYearCondWork.StProduceTypeOfYear;
                }
                if (prdTypYearCondWork.EdProduceTypeOfYear != 0)
                {
                    cmdText += " AND PRDTYPYEARRF.PRODUCETYPEOFYEARRF <= @FINDEDPRODUCETYPEOFYEAR ";
                    ((SqlParameter)sqlCommand.Parameters.Add("@FINDEDPRODUCETYPEOFYEAR", SqlDbType.NVarChar)).Value =
                        prdTypYearCondWork.EdProduceTypeOfYear;
                }

                sqlCommand.CommandText = cmdText;
                SqlDataReader myReader = null;
                try
                {
                    myReader = sqlCommand.ExecuteReader();
                    SetPrdTypYearRetWork(myReader, retArray);

                    if (retArray.Count > 0)
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException ex)
                {
                    return base.WriteSQLErrorLog(ex, "PrdTypYearDB.SearchPrdTypYearにてSQLエラー発生 Msg=" + ex.Message, 0);
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "PrdTypYearDB.SearchPrdTypYearにてエラー発生 Msg=" + ex.Message, 0);
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

        # region --- 生産年式情報をクラスにセット ---
        /// <summary>
        /// 生産年式情報をクラスにセット
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="retArray"></param>
        private void SetPrdTypYearRetWork(SqlDataReader myReader, ArrayList retArray)
        {
            while (myReader.Read())
            {
                PrdTypYearRetWork wkPrdTypYearRetWork = new PrdTypYearRetWork();
                wkPrdTypYearRetWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                wkPrdTypYearRetWork.FrameModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMEMODELRF"));
                wkPrdTypYearRetWork.StProduceFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STPRODUCEFRAMENORF"));
                wkPrdTypYearRetWork.EdProduceFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDPRODUCEFRAMENORF"));
                wkPrdTypYearRetWork.ProduceTypeOfYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRODUCETYPEOFYEARRF"));

                retArray.Add(wkPrdTypYearRetWork);
            }
        }
        # endregion

    }
}
