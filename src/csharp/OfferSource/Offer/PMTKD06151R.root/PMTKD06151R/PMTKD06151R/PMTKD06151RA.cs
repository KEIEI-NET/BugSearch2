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
    /// 型式類別情報検索DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 型式類別情報検索DBリモートオブジェクト</br>
    /// <br>Programmer : 96186　立花　裕輔</br>
    /// <br>Date       : 2007.03.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class CtgyMdlLnkDB : RemoteDB, ICtgyMdlLnkDB
    {
        /// <summary>
        ///　提供車輌情報結合検索DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 96186　立花　裕輔</br>
        /// <br>Date       : 2007.03.16</br>
        /// </remarks>
        public CtgyMdlLnkDB()
            :
            base("PMTKD06103D", "Broadleaf.Application.Remoting.CtgyMdlLnkDB", "CTGYMDLLNKRF")
        {
        }

        /// <summary>
        /// 型式類別情報検索DBリモートオブジェクト
        /// </summary>
        /// <param name="ctgyMdlLnkCondWork"></param>
        /// <param name="ctgyMdlLnkRetWork"></param>
        /// <returns></returns>
        public int GetCtgyMdlLnk(CtgyMdlLnkCondWork ctgyMdlLnkCondWork, out ArrayList ctgyMdlLnkRetWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //入出力パラメーター設定
            ctgyMdlLnkRetWork = null;
            SqlConnection sqlConnection = null;
            try
            {
                ArrayList _ctgyMdlLnkRetWork = null;

                //ＳＱＬ初期処理
                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = GetCtgyMdlLnkSerch(ctgyMdlLnkCondWork, out _ctgyMdlLnkRetWork, sqlConnection, null);
                if (status == 0)
                {
                    ctgyMdlLnkRetWork = _ctgyMdlLnkRetWork;
                }
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "CtgyMdlLnkDB.GetCtgyMdlLnkにてSQLエラー発生 Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CtgyMdlLnkDB.GetCtgyMdlLnkにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                    sqlConnection.Dispose();
            }
            return status;
        }

        /// <summary>
        /// 型式類別情報取得処理
        /// </summary>
        /// <param name="ctgyMdlLnkCondWork"></param>
        /// <param name="ctgyMdlLnkRetWork"></param>
        /// <param name="sqlConnection">SQL Connection</param>
        /// <param name="sqlTransaction">SQL Transaction</param>
        /// <returns></returns>
        public int GetCtgyMdlLnkSerch(CtgyMdlLnkCondWork ctgyMdlLnkCondWork, out ArrayList ctgyMdlLnkRetWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return GetCtgyMdlLnkSerchProc(ctgyMdlLnkCondWork, out  ctgyMdlLnkRetWork, sqlConnection, sqlTransaction);
        }

        private int GetCtgyMdlLnkSerchProc(CtgyMdlLnkCondWork ctgyMdlLnkCondWork, out ArrayList ctgyMdlLnkRetWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = 0;
            ctgyMdlLnkRetWork = new ArrayList();
            SqlDataReader myReader = null;

            //結果の初期化
            ArrayList RetInf = new ArrayList();

            //結果のAllayListにいれる作業情報クラス
            CtgyMdlLnkRetWork mf = null;

            string selectstr = "";
            string wherestr = "";

            try
            {
                selectstr = "SELECT ";
                selectstr += "CTGYMDLLNKRF.MODELDESIGNATIONNORF, ";
                selectstr += "CTGYMDLLNKRF.CATEGORYNORF, ";
                selectstr += "CTGYMDLLNKRF.CARPROPERNORF, ";
                selectstr += "CTGYMDLLNKRF.FULLMODELFIXEDNORF ";

                //ＪＯＩＮ項目
                selectstr += " FROM CTGYMDLLNKRF ";

                //ＷＨＥＲＥ項目
                selectstr += "WHERE ";

                //フル型式固定番号
                string wkstring = "";
                foreach (int fullModelFixedNo in ctgyMdlLnkCondWork.FullModelFixedNo)
                {
                    wkstring += fullModelFixedNo + ",";
                }
                if (wkstring != "")
                {
                    wkstring = wkstring.Remove(wkstring.LastIndexOf(','));
                    wherestr += " CTGYMDLLNKRF.FULLMODELFIXEDNORF IN (" + wkstring + ") ";
                }

                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    mf = new CtgyMdlLnkRetWork();
                    mf.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));
                    mf.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));
                    mf.CarProperNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARPROPERNORF"));
                    mf.FullModelFixedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FULLMODELFIXEDNORF"));
                    RetInf.Add(mf);
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "CtgyMdlLnkDB.GetCtgyMdlLnkSerchにてSQLエラー発生 Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CtgyMdlLnkDB.GetCtgyMdlLnkSerchにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            ctgyMdlLnkRetWork = RetInf;
            return status;
        }
    }
}
