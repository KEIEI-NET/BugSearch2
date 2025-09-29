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
    /// 類別装備部品情報取得リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 類別装備部品情報の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 96186　立花　裕輔</br>
    /// <br>Date       : 2007.03.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class CategoryEquipmentDB : RemoteDB, ICategoryEquipmentDB
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
        public CategoryEquipmentDB()
            :
        base("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CategoryEquipmentRetWork", "CTGEQUIPPTRF")
        {
        }
        # endregion

        /// <summary>
        /// 類別装備情報を戻します
        /// </summary>
        /// <param name="retbyte">検索結果</param>
        /// <param name="modelDesignationNo">型式指定番号</param>
        /// <param name="categoryNo">類別区分番号</param>
        /// <returns>STATUS</returns>
        public int SearchCategoryEquipment(out object retbyte, Int32 modelDesignationNo, Int32 categoryNo)
        {
            retbyte = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            try
            {
                //装備情報一時格納コレクション生成
                ArrayList retArrayCTGRYEQUIP = new ArrayList();

                //メソッド開始時にコネクション文字列を取得
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    base.WriteErrorLog("CategoryEquipmentDB.SearchCategoryEquipmentにてエラー発生 ConnectionTextが取得出来ませんでした。");
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }

                //SQL文生成
                SqlConnection sqlConnection = null;
                using (sqlConnection = new SqlConnection(connectionText))
                {
                    sqlConnection.Open();

                    //類別装備情報取得
                    status = SearchCategoryEquipmentParts(retArrayCTGRYEQUIP, modelDesignationNo, categoryNo, sqlConnection, null);

                    //戻り値を設定
                    if (retArrayCTGRYEQUIP.Count > 0)
                    {
                        retbyte = (object)retArrayCTGRYEQUIP;
                    }

                }
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "CategoryEquipmentDB.SearchCategoryEquipmentにてSQLエラー発生 Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CategoryEquipmentDB.SearchCategoryEquipmentにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        # region --- 類別装備部品情報取得 ---
        /// <summary>
        /// 類別装備部品情報取得
        /// </summary>
        /// <param name="retArray">検索結果</param>
        /// <param name="modelDesignationNo">検索パラメータ</param>
        /// <param name="categoryNo"></param>
        /// <param name="sqlConnection">sqlｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">SQL Transaction</param>
        /// <returns>STATUS</returns>
        public int SearchCategoryEquipmentParts(ArrayList retArray, Int32 modelDesignationNo, Int32 categoryNo, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return SearchCategoryEquipmentPartsProc(retArray, modelDesignationNo, categoryNo, sqlConnection, sqlTransaction);
        }

        private int SearchCategoryEquipmentPartsProc(ArrayList retArray, Int32 modelDesignationNo, Int32 categoryNo, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retArray.Clear();

            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = sqlConnection;

                //③：類別装備部品情報取得
                //類別・型式のみでリードでき、類別マスタのメーカー・車種を含んだレコード
                //との関連性が無い為別リードとします
                sqlCommand.CommandText = "SELECT " +
                    "CTGEQUIPPTRF.MODELDESIGNATIONNORF, CTGEQUIPPTRF.CATEGORYNORF, " +
                    "CTGEQUIPPTRF.EQUIPMENTGENRECDRF, CTGEQUIPPTRF.EQUIPMENTGENRENMRF, CTGEQUIPPTRF.EQUIPMENTMNGCODERF, " +
                    "CTGEQUIPPTRF.EQUIPMENTMNGNAMERF, CTGEQUIPPTRF.EQUIPMENTCODERF, CTGEQUIPPTRF.EQUIPMENTDISPORDERRF, " +
                    "CTGEQUIPPTRF.TBSPARTSCODERF, CTGEQUIPPTRF.EQUIPMENTNAMERF, CTGEQUIPPTRF.EQUIPMENTSHORTNAMERF," +
                    "CTGEQUIPPTRF.EQUIPMENTICONCODERF, CTGEQUIPPTRF.EQUIPMENTUNITCODERF, CTGEQUIPPTRF.EQUIPMENTUNITNAMERF, " +
                    "CTGEQUIPPTRF.EQUIPMENTCNTRF, CTGEQUIPPTRF.EQUIPMENTCOMMENT1RF, CTGEQUIPPTRF.EQUIPMENTCOMMENT2RF " +
                    "FROM CTGEQUIPPTRF " +
                    "WHERE CTGEQUIPPTRF.MODELDESIGNATIONNORF=@FINDMODELDESIGNATIONNO AND CTGEQUIPPTRF.CATEGORYNORF=@FINDCATEGORYNO " +
                    "ORDER BY CTGEQUIPPTRF.EQUIPMENTGENRECDRF, CTGEQUIPPTRF.EQUIPMENTMNGCODERF, CTGEQUIPPTRF.EQUIPMENTDISPORDERRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaModelDesignationNo = sqlCommand.Parameters.Add("@FINDMODELDESIGNATIONNO", SqlDbType.Int);
                SqlParameter findParaCategoryNo = sqlCommand.Parameters.Add("@FINDCATEGORYNO", SqlDbType.Int);

                //Parameterオブジェクトへ類別・型式値設定
                findParaModelDesignationNo.Value = modelDesignationNo;
                findParaCategoryNo.Value = categoryNo;

                SqlDataReader myReader = null;
                try
                {
                    //類別装備部品マスタ読込
                    myReader = sqlCommand.ExecuteReader();
                    CategoryEquipmentPartsInfoSet(myReader, retArray);

                    if (retArray.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException ex)
                {
                    return base.WriteSQLErrorLog(ex, "CategoryEquipmentDB.SearchCategoryEquipmentPartsにてSQLエラー発生 Msg=" + ex.Message, 0);
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "CategoryEquipmentDB.SearchCategoryEquipmentPartsにてエラー発生 Msg=" + ex.Message, 0);
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                finally
                {
                    if (myReader != null && !myReader.IsClosed) myReader.Close();
                }
            }
            return status;
        }
        # endregion

        # region --- 類別装備部品マスタの区分情報をクラスにセット ---
        /// <summary>
        /// 類別装備部品マスタの情報をクラスにセット
        /// </summary>
        /// <param name="myReader">SqlDataReader読込結果</param>
        /// <param name="retArray"></param>
        /// <returns>類別装備区分ワーククラス</returns>
        private void CategoryEquipmentPartsInfoSet(SqlDataReader myReader, ArrayList retArray)
        {
            while (myReader.Read())
            {
                CategoryEquipmentRetWork wkCategoryEquipmentPartsWork = new CategoryEquipmentRetWork();
                wkCategoryEquipmentPartsWork.EquipmentGenreCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPMENTGENRECDRF"));
                wkCategoryEquipmentPartsWork.EquipmentGenreNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EQUIPMENTGENRENMRF"));
                wkCategoryEquipmentPartsWork.EquipmentMngCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPMENTMNGCODERF"));
                wkCategoryEquipmentPartsWork.EquipmentMngName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EQUIPMENTMNGNAMERF"));
                wkCategoryEquipmentPartsWork.EquipmentCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPMENTCODERF"));
                wkCategoryEquipmentPartsWork.EquipmentDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPMENTDISPORDERRF"));
                wkCategoryEquipmentPartsWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                wkCategoryEquipmentPartsWork.EquipmentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EQUIPMENTNAMERF"));
                wkCategoryEquipmentPartsWork.EquipmentShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EQUIPMENTSHORTNAMERF"));
                wkCategoryEquipmentPartsWork.EquipmentIconCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPMENTICONCODERF"));
                wkCategoryEquipmentPartsWork.EquipmentUnitCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPMENTUNITCODERF"));
                wkCategoryEquipmentPartsWork.EquipmentUnitName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EQUIPMENTUNITNAMERF"));
                wkCategoryEquipmentPartsWork.EquipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("EQUIPMENTCNTRF"));
                wkCategoryEquipmentPartsWork.EquipmentComment1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EQUIPMENTCOMMENT1RF"));
                wkCategoryEquipmentPartsWork.EquipmentComment2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EQUIPMENTCOMMENT2RF"));

                //類別装備部品一時保存用コレクションに追加
                retArray.Add(wkCategoryEquipmentPartsWork);
            }
        }
        # endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="retArray"></param>
        /// <param name="modelDesignationNo"></param>
        /// <param name="categoryNo"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int SearchEquipment(ArrayList retArray, Int32 modelDesignationNo, Int32 categoryNo, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            if (retArray == null)
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            retArray.Clear();
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            try
            {
                //類別装備情報取得
                status = SearchEquipmentProc(retArray, modelDesignationNo, categoryNo, sqlConnection, sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CategoryEquipmentDB.SearchEquipmentにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        private int SearchEquipmentProc(ArrayList retArray, Int32 modelDesignationNo, Int32 categoryNo, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = sqlConnection;

                //装備情報取得
                //類別・型式のみでリードでき、類別マスタのメーカー・車種を含んだレコード
                //との関連性が無い為別リードとします
                sqlCommand.CommandText = "SELECT " +
                    "OFFERDATERF, MODELDESIGNATIONNORF, CATEGORYNORF, EQUIPMENTGENRECDRF, EQUIPMENTGENRENMRF, EQUIPMENTCODERF, EQUIPMENTNAMERF, EQUIPMENTSHORTNAMERF,EQUIPMENTICONCODERF " +
                    "FROM CTGRYEQUIPRF " +
                    "WHERE MODELDESIGNATIONNORF=@FINDMODELDESIGNATIONNO AND CATEGORYNORF=@FINDCATEGORYNO " +
                    "ORDER BY EQUIPMENTGENRECDRF, EQUIPMENTCODERF";

                //Prameterオブジェクトの作成
                SqlParameter findParaModelDesignationNo = sqlCommand.Parameters.Add("@FINDMODELDESIGNATIONNO", SqlDbType.Int);
                SqlParameter findParaCategoryNo = sqlCommand.Parameters.Add("@FINDCATEGORYNO", SqlDbType.Int);

                //Parameterオブジェクトへ類別・型式値設定
                findParaModelDesignationNo.Value = modelDesignationNo;
                findParaCategoryNo.Value = categoryNo;

                SqlDataReader myReader = null;
                try
                {
                    //類別装備マスタ読込
                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        //類別装備情報取得
                        //類別装備クラス生成
                        CtgryEquipWork wkCategoryEquipmentWork = CategoryEquipmentInfoSet(myReader);
                        //類別装備一時保存用コレクションに追加
                        retArray.Add(wkCategoryEquipmentWork);
                    }
                }
                finally
                {
                    //sqlCommand.Cancel();
                    if (myReader != null && !myReader.IsClosed)
                        myReader.Close();
                }
            }
            if (retArray.Count > 0)
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            else
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            return status;
        }

        /// <summary>
        /// 類別装備マスタ情報をクラスにセットします
        /// </summary>
        /// <param name="myReader">SqlDataReader読込結果</param>
        /// <returns>類別装備ワーククラス</returns>
        private CtgryEquipWork CategoryEquipmentInfoSet(SqlDataReader myReader)
        {
            CtgryEquipWork wkCategoryEquipmentWork = new CtgryEquipWork();
            wkCategoryEquipmentWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkCategoryEquipmentWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));
            wkCategoryEquipmentWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));
            wkCategoryEquipmentWork.EquipmentGenreCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPMENTGENRECDRF"));
            wkCategoryEquipmentWork.EquipmentGenreNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EQUIPMENTGENRENMRF"));
            wkCategoryEquipmentWork.EquipmentCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPMENTCODERF"));
            wkCategoryEquipmentWork.EquipmentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EQUIPMENTNAMERF"));
            wkCategoryEquipmentWork.EquipmentShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EQUIPMENTSHORTNAMERF"));
            wkCategoryEquipmentWork.EquipmentIconCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPMENTICONCODERF"));

            return wkCategoryEquipmentWork;
        }
    }
}
