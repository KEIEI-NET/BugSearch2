using System;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 型式情報取得リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 型式情報取得リモートクラスです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.09</br>
    /// <br></br>
    /// <br>Update Note: 2009/10/13  22018  鈴木 正臣</br>
    /// <br>             見出貼付機能の修正対応。（フル型式固定番号配列にゼロが含まれる時の対応）</br>
    /// <br></br>
    /// <br>Update Note: 2012/03/05  22008  長内 数馬</br>
    /// <br>             外車部品検索対応</br>
    /// <br></br>
    /// <br>Update Note: 2012/05/28  20056  對馬 大輔</br>
    /// <br>             SCM改良 No135</br>
    /// <br></br>
    /// <br>Update Note: 2013/02/12  22013  久保将太</br>
    /// <br>             VSS[Partsman.NS[012]] 仕掛一覧対応 No.854</br>
    /// <br>             　・PM7とNSの生産年式の違いによる問題に対応</br>
    /// <br></br>
    /// <br>Update Note: 2013/03/21  FSI斎藤 和宏</br>
    /// <br>             10900269-00 SPK車台番号文字列対応</br>
    /// <br>               ・国産/外車区分とハンドル位置情報の取得対応</br>
    /// <br></br>
    /// <br>Update Note: 2013/04/24  井上 裕貴</br>
    /// <br>             10900269-00 SPK車台番号文字列対応</br>
    /// <br>               ・国産/外車区分が外車で車台番号開始が0以外の時には国産として補正する対応</br>
    /// </remarks>
    [Serializable]
    public class CarModelSearchDB : RemoteDB, ICarModelSearchDB
    {
        # region --- private定義 ---
        # region --- 提供車輌型式マスタ取得項目定義 ---

        //提供車輌型式マスタ取得項目定義
        private string CARMODELRFSelectFields = "SELECT"
                + "  CAR.MAKERCODERF"
                + ", CAR.MAKERFULLNAMERF"
                + ", MAKERHALFNAMERF"
                + ", CAR.MODELCODERF"
                + ", CAR.MODELSUBCODERF"
                + ", CAR.MODELFULLNAMERF"
                + ", MODELHALFNAMERF"
                + ", CAR.SYSTEMATICCODERF"
                + ", CAR.SYSTEMATICNAMERF"
                + ", CAR.PRODUCETYPEOFYEARCDRF"
                + ", CAR.PRODUCETYPEOFYEARNMRF"
             #region // DEL 2013/02/12 22013 久保@仕掛一覧対応 No.854
                //+ ", CAR.STPRODUCETYPEOFYEARRF"
                //+ ", CAR.EDPRODUCETYPEOFYEARRF"
            #endregion
            // ADD 2013/02/12 22013 久保@仕掛一覧対応 No.854 *-------------------->>>
                + ", CAR.PTSTPRDCTYPEYRF"
                + ", CAR.PTEDPRDCTYPEYRF"
            // ADD 2013/02/12 22013 久保@仕掛一覧対応 No.854 *-------------------->>>
                + ", CAR.DOORCOUNTRF"
                + ", CAR.BODYNAMECODERF"
                + ", CAR.BODYNAMERF"
                + ", CAR.CARPROPERNORF"
                + ", CAR.FULLMODELFIXEDNORF"
                + ", CAR.EXHAUSTGASSIGNRF"
                + ", CAR.SERIESMODELRF"
                + ", CAR.CATEGORYSIGNMODELRF"
                + ", CAR.FULLMODELRF"
                + ", CAR.FRAMEMODELRF"
                + ", CAR.STPRODUCEFRAMENORF"
                + ", CAR.EDPRODUCEFRAMENORF"
                + ", CAR.MODELGRADENMRF"
                + ", CAR.ENGINEMODELNMRF"
                + ", CAR.ENGINEDISPLACENMRF"
                + ", CAR.EDIVNMRF"
                + ", CAR.TRANSMISSIONNMRF"
                + ", CAR.WHEELDRIVEMETHODNMRF"
                + ", CAR.SHIFTNMRF"
                + ", CAR.ADDICARSPEC1RF"
                + ", CAR.ADDICARSPEC2RF"
                + ", CAR.ADDICARSPEC3RF"
                + ", CAR.ADDICARSPEC4RF"
                + ", CAR.ADDICARSPEC5RF"
                + ", CAR.ADDICARSPEC6RF"
                + ", ADI.ADDICARSPECTITLE1RF"
                + ", ADI.ADDICARSPECTITLE2RF"
                + ", ADI.ADDICARSPECTITLE3RF"
                + ", ADI.ADDICARSPECTITLE4RF"
                + ", ADI.ADDICARSPECTITLE5RF"
                + ", ADI.ADDICARSPECTITLE6RF"
                + ", CAR.RELEVANCEMODELRF"
                + ", CAR.SUBCARNMCDRF"
                + ", CAR.MODELGRADESNAMERF"
                + ", CAR.BLOCKILLUSTRATIONCDRF"
                + ", CAR.THREEDILLUSTNORF"
                + ", CAR.GRADEFULLNAMERF" // 2012/05/28
                //+ ", CAR.PARTSDATAOFFERFLAGRF";  // DEL 2012/03/05
                + ", CAR.PARTSDATAOFFERFLAGRF"     // ADD 2012/03/05
                + ", CAR.PARTSDTOFRFLGPRMJOINRF"  // ADD 2012/03/05
                // --- ADD 2013/03/21 ---------->>>>>
                + ", CAR.DOMESTICFOREIGNCODERF"
                + ", CAR.DOMESTICFOREIGNNAMERF"
                + ", CAR.HANDLEINFOCDRF"
                + ", CAR.HANDLEINFONMRF";
                // --- ADD 2013/03/21 ----------<<<<<

        private string CarKindSelectFields = "SELECT DISTINCT "
                + "  CAR.MAKERCODERF"
                + ", CAR.MODELCODERF"
                + ", CAR.MODELSUBCODERF"
            //+ ", CAR.ENGINEMODELNMRF"                
                + ", CAR.MAKERFULLNAMERF"
                + ", MAKERHALFNAMERF"
                + ", CAR.MODELFULLNAMERF"
                + ", MODELHALFNAMERF";

        private string CarKindEgnSelectFields = "SELECT DISTINCT "
                + "  CAR.MAKERCODERF"
                + ", CAR.MODELCODERF"
                + ", CAR.MODELSUBCODERF"
                + ", CAR.ENGINEMODELNMRF"
                + ", CAR.MAKERFULLNAMERF"
                + ", MAKERHALFNAMERF"
                + ", CAR.MODELFULLNAMERF"
                + ", MODELHALFNAMERF";

        private string CARMODELRFOrderByFields = " ORDER BY"
                + "  CAR.MAKERCODERF"
                + ", CAR.MODELCODERF"
                + ", CAR.MODELSUBCODERF";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/24 ADD
        private string CARMODELRFOrderByFieldsForCarModelSearch = " ORDER BY"
                + "  CAR.MAKERCODERF"
                + ", CAR.MODELCODERF"
                + ", CAR.MODELSUBCODERF"
                + ", CAR.FULLMODELRF"
        #region // DEL 2013/02/12 22013 久保@仕掛一覧対応 No.854
            //+ ", CAR.STPRODUCETYPEOFYEARRF"
            //+ ", CAR.EDPRODUCETYPEOFYEARRF"     
        #endregion
                + ", CAR.PTSTPRDCTYPEYRF"   // ADD 2013/02/12 22013 久保@仕掛一覧対応 No.854
                + ", CAR.PTEDPRDCTYPEYRF"   // ADD 2013/02/12 22013 久保@仕掛一覧対応 No.854
            ;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/24 ADD

        # endregion
        # endregion

        # region --- コンストラクター ---
        /// <summary>
        /// コンストラクター
        /// </summary>
        public CarModelSearchDB()
            : base("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarKindInfoWork", "CARMODELRF")
        {
        }
        # endregion

        # region --- 車種情報取得処理 ---
        # region --- 車種検索処理＜類別型式検索＞ ---
        /// <summary>
        /// 車種検索処理＜類別型式検索＞
        /// 類別情報（型式指定番号5桁、類別区分番号4桁）より車種情報の取得を行います。
        /// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="KindList">検索結果(車種リスト)</param>
        /// <returns>DB Status</returns>
        public int GetCarKindCtgyMdl(CarModelCondWork carModelCondWork, out ArrayList KindList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            KindList = null;

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_OfferDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                    return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = GetCarKindCtgyMdl(carModelCondWork, out KindList, sqlConnection, null);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CarModelSearchDB.GetCarKindCtgyMdl Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 車種検索処理＜類別型式検索＞
        /// 類別情報（型式指定番号5桁、類別区分番号4桁）より車種情報の取得を行います。
        /// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="KindList">検索結果(車種リスト)</param>
        /// <param name="sqlConnection">SQL Status</param>
        /// <param name="sqlTransaction">SQL Transaction</param>
        /// <returns>DB Status</returns>
        public int GetCarKindCtgyMdl(CarModelCondWork carModelCondWork, out ArrayList KindList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return GetCarKindCtgyMdlProc(carModelCondWork, out  KindList, sqlConnection, sqlTransaction);
        }

        private int GetCarKindCtgyMdlProc(CarModelCondWork carModelCondWork, out ArrayList KindList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            KindList = new ArrayList();
            SqlDataReader myReader = null;

            try
            {
                //取得項目
                string sqlText = CarKindSelectFields;
                SqlCommand sqlCmd = new SqlCommand();

                //連結指定
                sqlText += " FROM CTGYMDLLNKRF AS CTG INNER JOIN CARMODELRF AS CAR ON CTG.CARPROPERNORF = CAR.CARPROPERNORF";
                sqlText += " INNER JOIN MAKERNAMERF ON CAR.MAKERCODERF = MAKERNAMERF.MAKERCODERF ";
                sqlText += " INNER JOIN MODELNAMERF ON CAR.MAKERCODERF = MODELNAMERF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMERF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMERF.MODELSUBCODERF";

                //抽出条件
                sqlText += " WHERE";
                sqlText += " CTG.MODELDESIGNATIONNORF = @MODELDESIGNATIONNORF";
                sqlText += " AND CTG.CATEGORYNORF = @CATEGORYNORF";
                ((SqlParameter)sqlCmd.Parameters.Add("@MODELDESIGNATIONNORF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.ModelDesignationNo);
                ((SqlParameter)sqlCmd.Parameters.Add("@CATEGORYNORF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.CategoryNo);

                if (carModelCondWork.MakerCode != 0)
                {
                    sqlText += " AND CAR.MAKERCODERF = @MAKERCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MAKERCODERF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.MakerCode);
                }
                if (carModelCondWork.ModelCode != 0)
                {
                    sqlText += " AND CAR.MODELCODERF = @MODELCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MODELCODERF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.ModelCode);
                }
                if (carModelCondWork.ModelSubCode != -1)
                {
                    sqlText += " AND CAR.MODELSUBCODERF = @MODELSUBCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MODELSUBCODERF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.ModelSubCode);
                }

                //「ORDER BY」設定
                sqlText += CARMODELRFOrderByFields;

                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = sqlText;
                sqlCmd.Transaction = sqlTransaction;

                // SQLの実行
                myReader = sqlCmd.ExecuteReader();

                // 車種情報格納処理
                SetCarKindInfoWork(myReader, KindList);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CarModelSearchDB.GetCarKindCtgyMdl Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
            }
            return status;
        }
        # endregion

        # region --- 車種検索処理＜型式検索＞ ---
        /// <summary>
        /// 車種検索処理＜型式検索＞
        /// 排ガス記号、シリーズ型式、型式（類別番号）より車種情報の取得を行います。
        /// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="kindList">検索結果(車種リスト)</param>
        /// <returns>DB Status</returns>
        public int GetCarKindModel(CarModelCondWork carModelCondWork, out ArrayList kindList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            kindList = null;

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_OfferDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                    return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = GetCarKindModel(carModelCondWork, out kindList, sqlConnection, null);

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CarModelSearchDB.GetCarKindModel Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 車種検索処理＜型式検索＞
        /// 排ガス記号、シリーズ型式、型式（類別番号）より車種情報の取得を行います。
        /// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="kindList">検索結果(車種リスト)</param>
        /// <param name="sqlConnection">SQL Connection</param>
        /// <param name="sqlTransanction">SQL Transaction</param>
        /// <returns>DB Status</returns>
        public int GetCarKindModel(CarModelCondWork carModelCondWork, out ArrayList kindList, SqlConnection sqlConnection, SqlTransaction sqlTransanction)
        {
            return GetCarKindModelProc(carModelCondWork, out  kindList, sqlConnection, sqlTransanction);
        }

        private int GetCarKindModelProc(CarModelCondWork carModelCondWork, out ArrayList kindList, SqlConnection sqlConnection, SqlTransaction sqlTransanction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            kindList = new ArrayList();
            SqlDataReader myReader = null;

            try
            {
                //取得項目
                string sqlText = CarKindSelectFields;
                string whereString = string.Empty;
                SqlCommand sqlCmd = new SqlCommand();

                //連結指定
                sqlText += " FROM CARMODELRF AS CAR ";
                sqlText += " INNER JOIN MAKERNAMERF ON CAR.MAKERCODERF = MAKERNAMERF.MAKERCODERF ";
                sqlText += " INNER JOIN MODELNAMERF ON CAR.MAKERCODERF = MODELNAMERF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMERF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMERF.MODELSUBCODERF";

                //抽出条件
                // 排ガス規制識別記号
                if (carModelCondWork.ExhaustGasSign != string.Empty)
                {
                    whereString += " AND CAR.EXHAUSTGASSIGNRF = @EXHAUSTGASSIGNRF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@EXHAUSTGASSIGNRF", SqlDbType.NChar)).Value = SqlDataMediator.SqlSetString(carModelCondWork.ExhaustGasSign);
                }

                // シリーズ型式
                if (carModelCondWork.SeriesModel != string.Empty)
                {
                    if (carModelCondWork.CategorySignModel == string.Empty)
                    {
                        // 類別記号が入力されていなければ後方一致                        
                        whereString += " AND CAR.SERIESMODELRF LIKE @SERIESMODELRF";
                        ((SqlParameter)sqlCmd.Parameters.Add("@SERIESMODELRF", SqlDbType.NChar)).Value = SqlDataMediator.SqlSetString(carModelCondWork.SeriesModel + '%');
                    }
                    else
                    {
                        // 類別記号が入力されている場合は完全一致
                        whereString += " AND CAR.SERIESMODELRF = @SERIESMODELRF";
                        ((SqlParameter)sqlCmd.Parameters.Add("@SERIESMODELRF", SqlDbType.NChar)).Value = SqlDataMediator.SqlSetString(carModelCondWork.SeriesModel);
                    }
                }

                // 類別記号
                if (carModelCondWork.CategorySignModel != string.Empty)
                {
                    whereString += " AND CAR.CATEGORYSIGNMODELRF LIKE @CATEGORYSIGNMODELRF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@CATEGORYSIGNMODELRF", SqlDbType.NChar)).Value = SqlDataMediator.SqlSetString(carModelCondWork.CategorySignModel + '%');
                }

                if (carModelCondWork.MakerCode != 0)
                {
                    whereString += " AND CAR.MAKERCODERF = @MAKERCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MAKERCODERF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.MakerCode);
                }
                if (carModelCondWork.ModelCode != 0)
                {
                    whereString += " AND CAR.MODELCODERF = @MODELCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MODELCODERF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.ModelCode);
                }
                if (carModelCondWork.ModelSubCode != -1)
                {
                    whereString += " AND CAR.MODELSUBCODERF = @MODELSUBCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MODELSUBCODERF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.ModelSubCode);
                }

                if (whereString.Length > 0)
                {
                    sqlText += " WHERE " + whereString.Substring(4);
                }

                //「ORDER BY」設定
                sqlText += CARMODELRFOrderByFields;

                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = sqlText;
                sqlCmd.Transaction = sqlTransanction;

                // SQLの実行
                myReader = sqlCmd.ExecuteReader();

                // 車種情報格納処理
                SetCarKindInfoWork(myReader, kindList);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CarModelSearchDB.GetCarKindModel Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
            }
            return status;
        }
        # endregion

        # region --- 車種検索処理＜プレート検索＞ ---
        /// <summary>
        /// 車種検索処理＜プレート検索＞
        /// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="KindList">検索結果(車種リスト)</param>
        /// <returns>DB Status</returns>
        public int GetCarKindlPlate(CarModelCondWork carModelCondWork, out ArrayList KindList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            KindList = null;

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_OfferDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                    return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = GetCarKindlPlate(carModelCondWork, out KindList, sqlConnection, null);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CarModelSearchDB.GetCarKindlPlate Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 車種検索処理＜プレート検索＞
        /// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="KindList">検索結果(車種リスト)</param>
        /// <param name="sqlConnection">SQL Connection</param>
        /// <param name="sqlTransaction">SQL Transaction</param>
        /// <returns>DB Status</returns>
        public int GetCarKindlPlate(CarModelCondWork carModelCondWork, out ArrayList KindList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return GetCarKindlPlateProc(carModelCondWork, out  KindList, sqlConnection, sqlTransaction);
        }

        private int GetCarKindlPlateProc(CarModelCondWork carModelCondWork, out ArrayList KindList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            KindList = new ArrayList();
            SqlDataReader myReader = null;

            try
            {
                //取得項目
                string sqlText = CarKindSelectFields;
                SqlCommand sqlCmd = new SqlCommand();

                //連結指定
                sqlText += " FROM PLATEMDLLNKRF AS PLA INNER JOIN CARMODELRF AS CAR ON PLA.CARPROPERNORF = CAR.CARPROPERNORF";
                sqlText += " INNER JOIN MAKERNAMERF ON CAR.MAKERCODERF = MAKERNAMERF.MAKERCODERF ";
                sqlText += " INNER JOIN MODELNAMERF ON CAR.MAKERCODERF = MODELNAMERF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMERF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMERF.MODELSUBCODERF";
                //sqlText += " LEFT JOIN ADDICARSPECTTLRF AS ADI ON ADI.MAKERCODERF = CAR.MAKERCODERF AND ADI.MODELCODERF = CAR.MODELCODERF AND ADI.MODELSUBCODERF = CAR.MODELSUBCODERF ";

                //抽出条件
                sqlText += " WHERE";

                //モデルプレート番号
                bool isFitPlate;
                int ind = GetPlateSearchStringIndex(carModelCondWork.ModelPlate, sqlConnection, out isFitPlate);
                if (isFitPlate)
                {
                    sqlText += " PLA.MODELPLATERF = @MODELPLATERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MODELPLATERF", SqlDbType.NChar)).Value = SqlDataMediator.SqlSetString(carModelCondWork.ModelPlate.Substring(0, ind));
                }
                else
                {
                    sqlText += " PLA.MODELPLATERF LIKE @MODELPLATERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MODELPLATERF", SqlDbType.NChar)).Value = SqlDataMediator.SqlSetString(carModelCondWork.ModelPlate.Substring(0, ind) + '%');
                }

                //メーカーコード
                if (carModelCondWork.MakerCode != 0)
                {
                    sqlText += " AND CAR.MAKERCODERF = @MAKERCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MAKERCODERF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.MakerCode);
                }
                if (carModelCondWork.ModelCode != 0)
                {
                    sqlText += " AND CAR.MODELCODERF = @MODELCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MODELCODERF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.ModelCode);
                }
                if (carModelCondWork.ModelSubCode != -1)
                {
                    sqlText += " AND CAR.MODELSUBCODERF = @MODELSUBCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MODELSUBCODERF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.ModelSubCode);
                }

                //「ORDER BY」設定
                sqlText += CARMODELRFOrderByFields;

                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = sqlText;
                sqlCmd.Transaction = sqlTransaction;

                // SQLの実行
                myReader = sqlCmd.ExecuteReader();

                // 車種情報格納処理
                SetCarKindInfoWork(myReader, KindList);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CarModelSearchDB.GetCarKindPlate Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
            }
            return status;
        }
        # endregion

        # region --- 車種検索処理＜エンジン型式検索＞ ---
        /// <summary>
        /// 車種検索処理＜エンジン型式検索＞
        /// </summary>
        /// <param name="carModelCondWork"></param>
        /// <param name="KindList">検索結果(車種リスト)</param>
        /// <returns>DB Status</returns>
        public int GetCarKindEngine(CarModelCondWork carModelCondWork, out ArrayList KindList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            KindList = null;

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_OfferDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                    return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = GetCarKindEngine(carModelCondWork, out KindList, sqlConnection, null);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CarModelSearchDB.GetCarKindEngine Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 車種検索処理＜エンジン型式検索＞
        /// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="KindList">検索結果(車種リスト)</param>
        /// <param name="sqlConnection">SQL Connection</param>
        /// <param name="sqlTransaction">SQL Transaction</param>
        /// <returns>DB Status</returns>
        public int GetCarKindEngine(CarModelCondWork carModelCondWork, out ArrayList KindList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return GetCarKindEngineProc(carModelCondWork, out  KindList, sqlConnection, sqlTransaction);
        }

        private int GetCarKindEngineProc(CarModelCondWork carModelCondWork, out ArrayList KindList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            KindList = new ArrayList();
            SqlDataReader myReader = null;

            try
            {
                //取得項目
                string sqlText = CarKindEgnSelectFields;
                SqlCommand sqlCmd = new SqlCommand();

                //連結指定
                //sqlText += " FROM CARMODELINDEXRF AS IDX INNER JOIN CARMODELRF AS CAR ON IDX.CARPROPERNORF = CAR.CARPROPERNORF";
                sqlText += " FROM CARMODELRF AS CAR ";
                sqlText += " INNER JOIN MAKERNAMERF ON CAR.MAKERCODERF = MAKERNAMERF.MAKERCODERF ";
                sqlText += " INNER JOIN MODELNAMERF ON CAR.MAKERCODERF = MODELNAMERF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMERF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMERF.MODELSUBCODERF";
                //抽出条件
                //sqlText += " WHERE IDX.ENGINEMODELNMRF LIKE @ENGINEMODELNMRF";
                sqlText += " WHERE CAR.ENGINEMODELNMRF LIKE @ENGINEMODELNMRF";
                ((SqlParameter)sqlCmd.Parameters.Add("@ENGINEMODELNMRF", SqlDbType.NChar)).Value = SqlDataMediator.SqlSetString(carModelCondWork.EngineModelNm + "%");

                if (carModelCondWork.MakerCode != 0)
                {
                    sqlText += " AND CAR.MAKERCODERF = @MAKERCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MAKERCODERF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.MakerCode);
                }
                if (carModelCondWork.ModelCode != 0)
                {
                    sqlText += " AND CAR.MODELCODERF = @MODELCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MODELCODERF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.ModelCode);
                }
                if (carModelCondWork.ModelSubCode != -1)
                {
                    sqlText += " AND CAR.MODELSUBCODERF = @MODELSUBCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MODELSUBCODERF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.ModelSubCode);
                }

                //「ORDER BY」設定
                sqlText += CARMODELRFOrderByFields;

                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = sqlText;
                sqlCmd.Transaction = sqlTransaction;

                // SQLの実行
                myReader = sqlCmd.ExecuteReader();

                // 車種情報格納処理
                SetEgnCarKindInfoWork(myReader, KindList);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CarModelSearchDB.GetCarKindEngine Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
            }
            return status;
        }
        # endregion
        # endregion

        # region --- 型式情報取得処理 ---
        # region --- 型式検索処理＜類別型式検索＞ ---
        /// <summary>
        /// 類別型式検索処理
        /// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="carModelRetList">検索結果(型式リスト)</param>
        /// <returns>DB Status</returns>
        public int GetCarCtgyMdlSearch(CarModelCondWork carModelCondWork, out ArrayList carModelRetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            carModelRetList = null;

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_OfferDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                    return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = GetCarCtgyMdlSearch(carModelCondWork, out carModelRetList, sqlConnection, null);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CarModelSearchDB.GetCarCtgyMdlSearch Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 類別型式検索処理
        /// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="carModelRetList">検索結果(型式リスト)</param>
        /// <param name="sqlConnection">SQL Connection</param>
        /// <param name="sqlTransaction">SQL Transaction</param>
        /// <returns>DB Status</returns>
        public int GetCarCtgyMdlSearch(CarModelCondWork carModelCondWork, out ArrayList carModelRetList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return GetCarCtgyMdlSearchProc(carModelCondWork, out carModelRetList, sqlConnection, sqlTransaction);
        }

        private int GetCarCtgyMdlSearchProc(CarModelCondWork carModelCondWork, out ArrayList carModelRetList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            carModelRetList = new ArrayList();
            SqlDataReader myReader = null;

            try
            {
                //取得項目
                string sqlText = CARMODELRFSelectFields;
                SqlCommand sqlCmd = new SqlCommand();

                //連結指定
                sqlText += " FROM CTGYMDLLNKRF AS CTG INNER JOIN CARMODELRF AS CAR ON CTG.CARPROPERNORF = CAR.CARPROPERNORF";
                sqlText += " INNER JOIN MAKERNAMERF ON CAR.MAKERCODERF = MAKERNAMERF.MAKERCODERF ";
                sqlText += " INNER JOIN MODELNAMERF ON CAR.MAKERCODERF = MODELNAMERF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMERF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMERF.MODELSUBCODERF";
                sqlText += " LEFT JOIN ADDICARSPECTTLRF AS ADI ON ADI.MAKERCODERF = CAR.MAKERCODERF AND ADI.MODELCODERF = CAR.MODELCODERF AND ADI.MODELSUBCODERF = CAR.MODELSUBCODERF ";

                //抽出条件
                sqlText += " WHERE";
                sqlText += " CTG.MODELDESIGNATIONNORF = @MODELDESIGNATIONNORF";
                sqlText += " AND CTG.CATEGORYNORF = @CATEGORYNORF";
                ((SqlParameter)sqlCmd.Parameters.Add("@MODELDESIGNATIONNORF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.ModelDesignationNo);
                ((SqlParameter)sqlCmd.Parameters.Add("@CATEGORYNORF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.CategoryNo);

                if (carModelCondWork.MakerCode != 0)
                {
                    sqlText += " AND CAR.MAKERCODERF = @MAKERCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MAKERCODERF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.MakerCode);
                }
                if (carModelCondWork.ModelCode != 0)
                {
                    sqlText += " AND CAR.MODELCODERF = @MODELCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MODELCODERF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.ModelCode);
                }
                if (carModelCondWork.ModelSubCode != -1)
                {
                    sqlText += " AND CAR.MODELSUBCODERF = @MODELSUBCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MODELSUBCODERF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.ModelSubCode);
                }

                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = sqlText;
                sqlCmd.Transaction = sqlTransaction;

                // SQLの実行
                myReader = sqlCmd.ExecuteReader();

                // 車輌型式格納処理
                SetCarModelRetWork(myReader, carModelRetList);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CarModelSearchDB.GetCarCtgyMdlSearch Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
            }
            return status;
        }

        # endregion

        # region --- 型式検索処理＜型式検索＞ ---
        /// <summary>
        /// 型式検索処理
        /// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="carModelRetList">検索結果(型式リスト)</param>
        /// <returns>DB Status</returns>
        public int GetCarModelSearch(CarModelCondWork carModelCondWork, out ArrayList carModelRetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            carModelRetList = null;

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_OfferDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                    return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = GetCarModelSearch(carModelCondWork, out carModelRetList, sqlConnection, null);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CarModelSearchDB.GetCarModelSearch Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 型式検索処理
        /// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="carModelRetList">検索結果(型式リスト)</param>
        /// <param name="sqlConnection">SQL Connection</param>
        /// <param name="sqlTransaction">SQL Transaction</param>
        /// <returns>DB Status</returns>
        public int GetCarModelSearch(CarModelCondWork carModelCondWork, out ArrayList carModelRetList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return GetCarModelSearchProc(carModelCondWork, out  carModelRetList, sqlConnection, sqlTransaction);
        }

        private int GetCarModelSearchProc(CarModelCondWork carModelCondWork, out ArrayList carModelRetList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            carModelRetList = new ArrayList();
            SqlDataReader myReader = null;

            try
            {
                //取得項目
                string sqlText = CARMODELRFSelectFields;
                string whereString = string.Empty;
                SqlCommand sqlCmd = new SqlCommand();

                //連結指定
                sqlText += " FROM CARMODELRF AS CAR ";
                sqlText += " INNER JOIN MAKERNAMERF ON CAR.MAKERCODERF = MAKERNAMERF.MAKERCODERF ";
                sqlText += " INNER JOIN MODELNAMERF ON CAR.MAKERCODERF = MODELNAMERF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMERF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMERF.MODELSUBCODERF";
                sqlText += " LEFT JOIN ADDICARSPECTTLRF AS ADI ON ADI.MAKERCODERF = CAR.MAKERCODERF AND ADI.MODELCODERF = CAR.MODELCODERF AND ADI.MODELSUBCODERF = CAR.MODELSUBCODERF ";

                //抽出条件
                // 排ガス規制識別記号
                if (carModelCondWork.ExhaustGasSign != string.Empty)
                {
                    whereString += " AND CAR.EXHAUSTGASSIGNRF = @EXHAUSTGASSIGNRF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@EXHAUSTGASSIGNRF", SqlDbType.NChar)).Value = SqlDataMediator.SqlSetString(carModelCondWork.ExhaustGasSign);
                }

                // シリーズ型式
                if (carModelCondWork.SeriesModel != string.Empty)
                {
                    if (carModelCondWork.CategorySignModel == string.Empty)
                    {
                        // 類別記号が入力されていなければ後方一致
                        whereString += " AND CAR.SERIESMODELRF LIKE @SERIESMODELRF";
                        ((SqlParameter)sqlCmd.Parameters.Add("@SERIESMODELRF", SqlDbType.NChar)).Value = SqlDataMediator.SqlSetString(carModelCondWork.SeriesModel + '%');
                    }
                    else
                    {
                        // 類別記号が入力されている場合は完全一致
                        whereString += " AND CAR.SERIESMODELRF = @SERIESMODELRF";
                        ((SqlParameter)sqlCmd.Parameters.Add("@SERIESMODELRF", SqlDbType.NChar)).Value = SqlDataMediator.SqlSetString(carModelCondWork.SeriesModel);
                    }
                }

                // 類別記号
                if (carModelCondWork.CategorySignModel != string.Empty)
                {
                    whereString += " AND CAR.CATEGORYSIGNMODELRF LIKE @CATEGORYSIGNMODELRF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@CATEGORYSIGNMODELRF", SqlDbType.NChar)).Value = SqlDataMediator.SqlSetString(carModelCondWork.CategorySignModel + '%');
                }

                if (carModelCondWork.MakerCode != 0)
                {
                    whereString += " AND CAR.MAKERCODERF = @MAKERCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MAKERCODERF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.MakerCode);
                }
                if (carModelCondWork.ModelCode != 0)
                {
                    whereString += " AND CAR.MODELCODERF = @MODELCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MODELCODERF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.ModelCode);
                }
                if (carModelCondWork.ModelSubCode != -1)
                {
                    whereString += " AND CAR.MODELSUBCODERF = @MODELSUBCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MODELSUBCODERF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.ModelSubCode);
                }

                if (whereString.Length > 0)
                {
                    sqlText += " WHERE " + whereString.Substring(4);
                }
                //「ORDER BY」設定
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/24 DEL
                //sqlText += CARMODELRFOrderByFields;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/24 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/24 ADD
                sqlText += CARMODELRFOrderByFieldsForCarModelSearch;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/24 ADD

                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandText = sqlText;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Transaction = sqlTransaction;

                // SQLの実行
                myReader = sqlCmd.ExecuteReader();

                // 車輌型式格納処理
                SetCarModelRetWork(myReader, carModelRetList);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CarModelSearchDB.GetCarModelSearch Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
            }
            return status;
        }
        # endregion

        # region --- 型式検索処理＜プレート検索＞ ---
        /// <summary>
        /// プレート検索処理
        /// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="carModelRetList">検索結果(型式リスト)</param>
        /// <returns>DB Status</returns>
        public int GetCarPlateSearch(CarModelCondWork carModelCondWork, out ArrayList carModelRetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            carModelRetList = null;

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_OfferDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                    return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = GetCarPlateSearch(carModelCondWork, out carModelRetList, sqlConnection, null);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CarModelSearchDB.GetCarPlateSearch Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// プレート検索処理
        /// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="carModelRetList">検索結果(型式リスト)</param>
        /// <param name="sqlConnection">SQL Connection</param>
        /// <param name="sqlTransaction">SQL Transaction</param>
        /// <returns>DB Status</returns>
        public int GetCarPlateSearch(CarModelCondWork carModelCondWork, out ArrayList carModelRetList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return GetCarPlateSearchProc(carModelCondWork, out  carModelRetList, sqlConnection, sqlTransaction);
        }

        private int GetCarPlateSearchProc(CarModelCondWork carModelCondWork, out ArrayList carModelRetList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            carModelRetList = new ArrayList();
            SqlDataReader myReader = null;

            try
            {
                //取得項目
                string sqlText = CARMODELRFSelectFields;
                string whereString = string.Empty;
                SqlCommand sqlCmd = new SqlCommand();

                //連結指定
                sqlText += " FROM PLATEMDLLNKRF AS PLA INNER JOIN CARMODELRF AS CAR ON PLA.CARPROPERNORF = CAR.CARPROPERNORF";
                sqlText += " INNER JOIN MAKERNAMERF ON CAR.MAKERCODERF = MAKERNAMERF.MAKERCODERF ";
                sqlText += " INNER JOIN MODELNAMERF ON CAR.MAKERCODERF = MODELNAMERF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMERF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMERF.MODELSUBCODERF";
                sqlText += " LEFT JOIN ADDICARSPECTTLRF AS ADI ON ADI.MAKERCODERF = CAR.MAKERCODERF AND ADI.MODELCODERF = CAR.MODELCODERF AND ADI.MODELSUBCODERF = CAR.MODELSUBCODERF ";

                //抽出条件
                whereString += " WHERE";

                //モデルプレート番号
                bool isFitPlate;
                int ind = GetPlateSearchStringIndex(carModelCondWork.ModelPlate, sqlConnection, out isFitPlate);
                if (isFitPlate)
                {
                    whereString += " PLA.MODELPLATERF = @MODELPLATERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MODELPLATERF", SqlDbType.NChar)).Value = SqlDataMediator.SqlSetString(carModelCondWork.ModelPlate.Substring(0, ind));
                }
                else
                {
                    whereString += " PLA.MODELPLATERF LIKE @MODELPLATERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MODELPLATERF", SqlDbType.NChar)).Value = SqlDataMediator.SqlSetString(carModelCondWork.ModelPlate.Substring(0, ind) + '%');
                }

                if (carModelCondWork.MakerCode != 0)
                {
                    whereString += " AND CAR.MAKERCODERF = @MAKERCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MAKERCODERF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.MakerCode);
                }
                if (carModelCondWork.ModelCode != 0)
                {
                    whereString += " AND CAR.MODELCODERF = @MODELCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MODELCODERF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.ModelCode);
                }
                if (carModelCondWork.ModelSubCode != -1)
                {
                    whereString += " AND CAR.MODELSUBCODERF = @MODELSUBCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MODELSUBCODERF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.ModelSubCode);
                }

                sqlText += whereString;
                //「ORDER BY」設定
                sqlText += CARMODELRFOrderByFields;

                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = sqlText;
                sqlCmd.Transaction = sqlTransaction;

                // SQLの実行
                myReader = sqlCmd.ExecuteReader();

                // 車輌型式格納処理
                SetCarModelRetWork(myReader, carModelRetList);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CarModelSearchDB.GetCarPlateSearch Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
            }
            return status;
        }
        # endregion

        # region --- 型式検索処理＜エンジン型式検索＞ ---
        /// <summary>
        /// エンジン型式検索処理
        /// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="carModelRetList">検索結果(型式リスト)</param>
        /// <returns>DB Status</returns>
        public int GetCarEngineSearch(CarModelCondWork carModelCondWork, out ArrayList carModelRetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            carModelRetList = null;

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_OfferDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                    return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = GetCarEngineSearch(carModelCondWork, out carModelRetList, sqlConnection, null);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CarModelSearchDB.GetCarEngineSearch Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// エンジン型式検索処理
        /// </summary>
        /// <param name="carModelCondWork"></param>
        /// <param name="carModelRetList"></param>
        /// <param name="sqlConnection">SQL Connection</param>
        /// <param name="sqlTransaction">SQL Transaction</param>
        /// <returns>DB Status</returns>
        public int GetCarEngineSearch(CarModelCondWork carModelCondWork, out ArrayList carModelRetList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return GetCarEngineSearchProc(carModelCondWork, out  carModelRetList, sqlConnection, sqlTransaction);
        }

        private int GetCarEngineSearchProc(CarModelCondWork carModelCondWork, out ArrayList carModelRetList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            carModelRetList = new ArrayList();
            SqlDataReader myReader = null;

            try
            {
                //取得項目
                string sqlText = CARMODELRFSelectFields;
                SqlCommand sqlCmd = new SqlCommand();

                //連結指定
                //sqlText += " FROM CARMODELINDEXRF AS IDX INNER JOIN CARMODELRF AS CAR ON IDX.CARPROPERNORF = CAR.CARPROPERNORF";
                sqlText += " FROM CARMODELRF AS CAR";
                sqlText += " INNER JOIN MAKERNAMERF ON CAR.MAKERCODERF = MAKERNAMERF.MAKERCODERF ";
                sqlText += " INNER JOIN MODELNAMERF ON CAR.MAKERCODERF = MODELNAMERF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMERF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMERF.MODELSUBCODERF";
                sqlText += " LEFT JOIN ADDICARSPECTTLRF AS ADI ON ADI.MAKERCODERF = CAR.MAKERCODERF AND ADI.MODELCODERF = CAR.MODELCODERF AND ADI.MODELSUBCODERF = CAR.MODELSUBCODERF";

                //抽出条件
                sqlText += " WHERE";

                //sqlText += " IDX.ENGINEMODELNMRF LIKE @ENGINEMODELNMRF";
                sqlText += " CAR.ENGINEMODELNMRF = @ENGINEMODELNMRF";
                ((SqlParameter)sqlCmd.Parameters.Add("@ENGINEMODELNMRF", SqlDbType.NChar)).Value = SqlDataMediator.SqlSetString(carModelCondWork.EngineModelNm);

                if (carModelCondWork.MakerCode != 0)
                {
                    sqlText += " AND CAR.MAKERCODERF = @MAKERCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MAKERCODERF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.MakerCode);
                }
                if (carModelCondWork.ModelCode != 0)
                {
                    sqlText += " AND CAR.MODELCODERF = @MODELCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MODELCODERF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.ModelCode);
                }
                if (carModelCondWork.ModelSubCode != -1)
                {
                    sqlText += " AND CAR.MODELSUBCODERF = @MODELSUBCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@MODELSUBCODERF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(carModelCondWork.ModelSubCode);
                }

                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = sqlText;
                sqlCmd.Transaction = sqlTransaction;

                // SQLの実行
                myReader = sqlCmd.ExecuteReader();

                // 車輌型式格納処理
                SetCarModelRetWork(myReader, carModelRetList);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CarModelSearchDB.GetCarEngineSearch Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
            }

            return status;
        }
        # endregion

        #region --- 型式検索処理＜フル型式固定番号検索＞ ---
        /// <summary>
        /// 型式検索処理
        /// </summary>
        /// <param name="carModelCondWork">検索条件</param>
        /// <param name="kindList">車種情報</param>
        /// <param name="carModelRetList">検索結果(型式リスト)</param>
        /// <param name="sqlConnection">SQL Connection</param>
        /// <param name="sqlTransaction">SQL Transaction</param>
        /// <returns>DB Status</returns>
        public int GetCarFullModelNoSearch(CarModelCondWork carModelCondWork, out ArrayList kindList, out ArrayList carModelRetList,
            SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            carModelRetList = null;
            int status = GetCarKindFullModelNoProc(carModelCondWork, out kindList, sqlConnection, sqlTransaction);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                return status;
            return GetCarFullModelNoSearchProc(carModelCondWork, out carModelRetList, sqlConnection, sqlTransaction);
        }

        private int GetCarKindFullModelNoProc(CarModelCondWork carModelCondWork, out ArrayList kindList, SqlConnection sqlConnection, SqlTransaction sqlTransanction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            kindList = new ArrayList();
            SqlDataReader myReader = null;

            try
            {
                //取得項目
                string sqlText = CarKindSelectFields;
                string whereString = string.Empty;
                SqlCommand sqlCmd = new SqlCommand();

                //連結指定
                sqlText += " FROM CARMODELRF AS CAR ";
                sqlText += " INNER JOIN MAKERNAMERF ON CAR.MAKERCODERF = MAKERNAMERF.MAKERCODERF ";
                sqlText += " INNER JOIN MODELNAMERF ON CAR.MAKERCODERF = MODELNAMERF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMERF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMERF.MODELSUBCODERF ";

                //抽出条件
                whereString = "WHERE FULLMODELFIXEDNORF IN (";
                for (int i = 0; i < carModelCondWork.FullModelFixedNos.Length; i++)
                {
                    whereString += carModelCondWork.FullModelFixedNos[i].ToString() + ", ";
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/13 UPD
                //sqlText += whereString.Remove(whereString.Length - 2) + ") ";
                whereString = whereString.Remove( whereString.Length - 2 ) + ") ";
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/13 UPD

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/13 ADD
                // フル型式固定番号＝０に対応する為、条件を追加。

                //抽出条件
                // 排ガス規制識別記号
                if ( carModelCondWork.ExhaustGasSign != string.Empty )
                {
                    whereString += " AND CAR.EXHAUSTGASSIGNRF = @EXHAUSTGASSIGNRF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@EXHAUSTGASSIGNRF", SqlDbType.NChar )).Value = SqlDataMediator.SqlSetString( carModelCondWork.ExhaustGasSign );
                }

                // シリーズ型式
                if ( carModelCondWork.SeriesModel != string.Empty )
                {
                    if ( carModelCondWork.CategorySignModel == string.Empty )
                    {
                        // 類別記号が入力されていなければ後方一致
                        whereString += " AND CAR.SERIESMODELRF LIKE @SERIESMODELRF";
                        ((SqlParameter)sqlCmd.Parameters.Add( "@SERIESMODELRF", SqlDbType.NChar )).Value = SqlDataMediator.SqlSetString( carModelCondWork.SeriesModel + '%' );
                    }
                    else
                    {
                        // 類別記号が入力されている場合は完全一致
                        whereString += " AND CAR.SERIESMODELRF = @SERIESMODELRF";
                        ((SqlParameter)sqlCmd.Parameters.Add( "@SERIESMODELRF", SqlDbType.NChar )).Value = SqlDataMediator.SqlSetString( carModelCondWork.SeriesModel );
                    }
                }

                // 類別記号
                if ( carModelCondWork.CategorySignModel != string.Empty )
                {
                    whereString += " AND CAR.CATEGORYSIGNMODELRF LIKE @CATEGORYSIGNMODELRF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@CATEGORYSIGNMODELRF", SqlDbType.NChar )).Value = SqlDataMediator.SqlSetString( carModelCondWork.CategorySignModel + '%' );
                }

                if ( carModelCondWork.MakerCode != 0 )
                {
                    whereString += " AND CAR.MAKERCODERF = @MAKERCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@MAKERCODERF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( carModelCondWork.MakerCode );
                }
                if ( carModelCondWork.ModelCode != 0 )
                {
                    whereString += " AND CAR.MODELCODERF = @MODELCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@MODELCODERF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( carModelCondWork.ModelCode );
                }
                if ( carModelCondWork.ModelSubCode != -1 )
                {
                    whereString += " AND CAR.MODELSUBCODERF = @MODELSUBCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@MODELSUBCODERF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( carModelCondWork.ModelSubCode );
                }

                sqlText += whereString + Environment.NewLine;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/13 ADD

                //「ORDER BY」設定
                sqlText += CARMODELRFOrderByFields;

                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = sqlText;
                sqlCmd.Transaction = sqlTransanction;

                // SQLの実行
                myReader = sqlCmd.ExecuteReader();

                // 車種情報格納処理
                SetCarKindInfoWork(myReader, kindList);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CarModelSearchDB.GetCarKindModel Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
            }
            return status;
        }

        private int GetCarFullModelNoSearchProc(CarModelCondWork carModelCondWork, out ArrayList carModelRetList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            carModelRetList = new ArrayList();
            SqlDataReader myReader = null;

            try
            {
                //取得項目
                string sqlText = CARMODELRFSelectFields;
                string whereString = string.Empty;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/13 ADD
                SqlCommand sqlCmd = new SqlCommand();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/13 ADD

                //連結指定
                sqlText += " FROM CARMODELRF AS CAR ";
                sqlText += " INNER JOIN MAKERNAMERF ON CAR.MAKERCODERF = MAKERNAMERF.MAKERCODERF ";
                sqlText += " INNER JOIN MODELNAMERF ON CAR.MAKERCODERF = MODELNAMERF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMERF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMERF.MODELSUBCODERF";
                sqlText += " LEFT JOIN ADDICARSPECTTLRF AS ADI ON ADI.MAKERCODERF = CAR.MAKERCODERF AND ADI.MODELCODERF = CAR.MODELCODERF AND ADI.MODELSUBCODERF = CAR.MODELSUBCODERF ";

                //抽出条件
                whereString = "WHERE FULLMODELFIXEDNORF IN (";
                for (int i = 0; i < carModelCondWork.FullModelFixedNos.Length; i++)
                {
                    whereString += carModelCondWork.FullModelFixedNos[i].ToString() + ", ";
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/13 UPD
                //sqlText += whereString.Remove(whereString.Length - 2) + ") ";
                whereString = whereString.Remove( whereString.Length - 2 ) + ") ";
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/13 UPD

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/13 ADD
                // フル型式固定番号＝０に対応する為、条件を追加。

                //抽出条件
                // 排ガス規制識別記号
                if ( carModelCondWork.ExhaustGasSign != string.Empty )
                {
                    whereString += " AND CAR.EXHAUSTGASSIGNRF = @EXHAUSTGASSIGNRF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@EXHAUSTGASSIGNRF", SqlDbType.NChar )).Value = SqlDataMediator.SqlSetString( carModelCondWork.ExhaustGasSign );
                }

                // シリーズ型式
                if ( carModelCondWork.SeriesModel != string.Empty )
                {
                    if ( carModelCondWork.CategorySignModel == string.Empty )
                    {
                        // 類別記号が入力されていなければ後方一致
                        whereString += " AND CAR.SERIESMODELRF LIKE @SERIESMODELRF";
                        ((SqlParameter)sqlCmd.Parameters.Add( "@SERIESMODELRF", SqlDbType.NChar )).Value = SqlDataMediator.SqlSetString( carModelCondWork.SeriesModel + '%' );
                    }
                    else
                    {
                        // 類別記号が入力されている場合は完全一致
                        whereString += " AND CAR.SERIESMODELRF = @SERIESMODELRF";
                        ((SqlParameter)sqlCmd.Parameters.Add( "@SERIESMODELRF", SqlDbType.NChar )).Value = SqlDataMediator.SqlSetString( carModelCondWork.SeriesModel );
                    }
                }

                // 類別記号
                if ( carModelCondWork.CategorySignModel != string.Empty )
                {
                    whereString += " AND CAR.CATEGORYSIGNMODELRF LIKE @CATEGORYSIGNMODELRF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@CATEGORYSIGNMODELRF", SqlDbType.NChar )).Value = SqlDataMediator.SqlSetString( carModelCondWork.CategorySignModel + '%' );
                }

                if ( carModelCondWork.MakerCode != 0 )
                {
                    whereString += " AND CAR.MAKERCODERF = @MAKERCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@MAKERCODERF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( carModelCondWork.MakerCode );
                }
                if ( carModelCondWork.ModelCode != 0 )
                {
                    whereString += " AND CAR.MODELCODERF = @MODELCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@MODELCODERF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( carModelCondWork.ModelCode );
                }
                if ( carModelCondWork.ModelSubCode != -1 )
                {
                    whereString += " AND CAR.MODELSUBCODERF = @MODELSUBCODERF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@MODELSUBCODERF", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt32( carModelCondWork.ModelSubCode );
                }

                sqlText += whereString + Environment.NewLine;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/13 ADD

                //「ORDER BY」設定
                sqlText += CARMODELRFOrderByFields;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/13 UPD
                //SqlCommand sqlCmd = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandText = sqlText;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Transaction = sqlTransaction;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/13 UPD

                // SQLの実行
                myReader = sqlCmd.ExecuteReader();

                // 車輌型式格納処理
                SetCarModelRetWork(myReader, carModelRetList);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CarModelSearchDB.GetCarFullModelNoSearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && myReader.IsClosed == false)
                {
                    myReader.Close();
                }
            }
            return status;
        }
        #endregion

        # endregion

        private int GetPlateSearchStringIndex(string modelPlate, SqlConnection sqlConnection, out bool isFitPlate)
        {
            int ind;
            int strLen = modelPlate.Length;
            string strInEdit = modelPlate;
            string sqlStr = "SELECT COUNT(MODELPLATERF) FROM PLATEMDLLNKRF WHERE MODELPLATERF LIKE '";
            string sqlText;
            SqlCommand sqlCommand = new SqlCommand();
            isFitPlate = false;
            // MLHARGAY34*に対してMLHARGAY34TDA---A-*を入力しても検索可能にするために
            // 一文字ずつ削りながらそういうプレートがあるか確認する。
            for (ind = strLen; ind > 0; ind--)
            {
                sqlText = sqlStr + modelPlate.Substring(0, ind) + "%'";
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlText;

                if (sqlCommand.ExecuteScalar().Equals(0) == false)
                    break;
            }
            // MLHARGAY34*に対してMLHARGAY34*を入力して貰って、ぴったり一致する場合は
            // そのプレートのみ検索する様にフラグにセットする。
            sqlText = "SELECT COUNT(MODELPLATERF) FROM PLATEMDLLNKRF WHERE MODELPLATERF = '" + modelPlate.Substring(0, ind) + '\'';
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlText;
            if (sqlCommand.ExecuteScalar().Equals(0) == false)
                isFitPlate = true;
            return ind;
        }

        # region --- 格納処理 ---
        # region --- 車輌型式格納処理 ---
        /// <summary>
        /// 車輌型式格納処理
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="carModelRetList"></param>
        /// <returns></returns>
        private void SetCarModelRetWork(SqlDataReader myReader, ArrayList carModelRetList)
        {
            while (myReader.Read())
            {
                CarModelRetWork wkCarModelRetWork = new CarModelRetWork();

                wkCarModelRetWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                wkCarModelRetWork.MakerFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERFULLNAMERF"));
                wkCarModelRetWork.MakerHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERHALFNAMERF"));
                wkCarModelRetWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));
                wkCarModelRetWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));
                wkCarModelRetWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));
                wkCarModelRetWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));
                wkCarModelRetWork.SystematicCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SYSTEMATICCODERF"));
                wkCarModelRetWork.SystematicName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SYSTEMATICNAMERF"));
                wkCarModelRetWork.ProduceTypeOfYearCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRODUCETYPEOFYEARCDRF"));
                wkCarModelRetWork.ProduceTypeOfYearNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRODUCETYPEOFYEARNMRF"));
                #region // DEL 2013/02/12 22013 久保@仕掛一覧対応 No.854
                //wkCarModelRetWork.StProduceTypeOfYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STPRODUCETYPEOFYEARRF"));
                //wkCarModelRetWork.EdProduceTypeOfYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDPRODUCETYPEOFYEARRF"));
                #endregion
                // ADD 2013/02/12 22013 久保@仕掛一覧対応 No.854 *-------------------->>>
                // 生産年式（STPRODUCETYPEOFYEARRF）はNSから車両の販売年式が設定されているが、
                // PM7で使用していた生産年式と異なるため、PM7-NSで動作が異なる。
                // 車両や部品の検索に影響が出ているためPM7時の別項目を用意して使用する。
                wkCarModelRetWork.StProduceTypeOfYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PTSTPRDCTYPEYRF"));
                wkCarModelRetWork.EdProduceTypeOfYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PTEDPRDCTYPEYRF"));
                // ADD 2013/02/12 22013 久保@仕掛一覧対応 No.854 <<<--------------------*

                wkCarModelRetWork.DoorCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOORCOUNTRF"));
                wkCarModelRetWork.BodyNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BODYNAMECODERF"));
                wkCarModelRetWork.BodyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BODYNAMERF"));
                wkCarModelRetWork.CarProperNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARPROPERNORF"));
                wkCarModelRetWork.FullModelFixedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FULLMODELFIXEDNORF"));
                wkCarModelRetWork.ExhaustGasSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXHAUSTGASSIGNRF"));
                wkCarModelRetWork.SeriesModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));
                wkCarModelRetWork.CategorySignModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYSIGNMODELRF"));
                wkCarModelRetWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));
                wkCarModelRetWork.FrameModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMEMODELRF"));
                wkCarModelRetWork.StProduceFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STPRODUCEFRAMENORF"));
                wkCarModelRetWork.EdProduceFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDPRODUCEFRAMENORF"));
                wkCarModelRetWork.ModelGradeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELGRADENMRF"));
                wkCarModelRetWork.EngineModelNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));
                wkCarModelRetWork.EngineDisplaceNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEDISPLACENMRF"));
                wkCarModelRetWork.EDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EDIVNMRF"));
                wkCarModelRetWork.TransmissionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRANSMISSIONNMRF"));
                wkCarModelRetWork.WheelDriveMethodNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WHEELDRIVEMETHODNMRF"));
                wkCarModelRetWork.ShiftNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIFTNMRF"));
                wkCarModelRetWork.AddiCarSpec1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC1RF"));
                wkCarModelRetWork.AddiCarSpec2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC2RF"));
                wkCarModelRetWork.AddiCarSpec3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC3RF"));
                wkCarModelRetWork.AddiCarSpec4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC4RF"));
                wkCarModelRetWork.AddiCarSpec5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC5RF"));
                wkCarModelRetWork.AddiCarSpec6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC6RF"));

                wkCarModelRetWork.AddiCarSpecTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE1RF"));
                wkCarModelRetWork.AddiCarSpecTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE2RF"));
                wkCarModelRetWork.AddiCarSpecTitle3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE3RF"));
                wkCarModelRetWork.AddiCarSpecTitle4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE4RF"));
                wkCarModelRetWork.AddiCarSpecTitle5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE5RF"));
                wkCarModelRetWork.AddiCarSpecTitle6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE6RF"));

                wkCarModelRetWork.RelevanceModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RELEVANCEMODELRF"));
                wkCarModelRetWork.SubCarNmCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBCARNMCDRF"));
                wkCarModelRetWork.ModelGradeSname = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELGRADESNAMERF"));
                wkCarModelRetWork.BlockIllustrationCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLOCKILLUSTRATIONCDRF"));
                wkCarModelRetWork.ThreeDIllustNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("THREEDILLUSTNORF"));

                // -- UPD 2012/03/05 ---------------------->>>
                //wkCarModelRetWork.PartsDataOfferFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSDATAOFFERFLAGRF"));
                int partsDataOfferFlag = 0;
                short partsDtOfrFlgPrmJoin = 0;

                partsDataOfferFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSDATAOFFERFLAGRF"));  // 部品データ提供フラグ
                partsDtOfrFlgPrmJoin = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("PARTSDTOFRFLGPRMJOINRF"));  // 部品データ提供フラグ（優良結合連携部品）

                if ((partsDataOfferFlag == 1) || (partsDtOfrFlgPrmJoin == 1))
                {
                    wkCarModelRetWork.PartsDataOfferFlag = 1;
                }
                else
                {
                    wkCarModelRetWork.PartsDataOfferFlag = 0;
                }
                // -- UPD 2012/03/05 ----------------------<<<

                wkCarModelRetWork.GradeFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GRADEFULLNAMERF")); // 2012/05/28

                // --- ADD 2013/03/21 ---------->>>>>
                wkCarModelRetWork.DomesticForeignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOMESTICFOREIGNCODERF"));
                wkCarModelRetWork.DomesticForeignName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DOMESTICFOREIGNNAMERF"));
                wkCarModelRetWork.HandleInfoCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HANDLEINFOCDRF"));
                wkCarModelRetWork.HandleInfoNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HANDLEINFONMRF"));
                // --- ADD 2013/03/21 ----------<<<<<

                // --- ADD 2013/04/24 ---------->>>>>
                //国産外車区分が外車で、車台番号開始が0以外の場合には
                //国産外車区分を国産として補正する
                if (wkCarModelRetWork.DomesticForeignCode == 2) 
                {
                    if (wkCarModelRetWork.StProduceFrameNo != 0)
                        wkCarModelRetWork.DomesticForeignCode = 1;
                }
                // --- ADD 2013/04/24 ----------<<<<<
             
                carModelRetList.Add(wkCarModelRetWork);
            }
        }
        # endregion

        # region --- 車種情報格納処理 ---
        /// <summary>
        /// 車種情報格納処理
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="KindList"></param>
        /// <returns></returns>
        private void SetCarKindInfoWork(SqlDataReader myReader, ArrayList KindList)
        {
            while (myReader.Read())
            {
                CarKindInfoWork wkCarKind = new CarKindInfoWork();

                wkCarKind.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                wkCarKind.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));
                wkCarKind.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));
                //wkCarKind.EngineModelNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));
                wkCarKind.MakerFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERFULLNAMERF"));
                wkCarKind.MakerHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERHALFNAMERF"));
                wkCarKind.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));
                wkCarKind.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));

                KindList.Add(wkCarKind);
            }
        }

        /// <summary>
        /// 車種情報格納処理＜エンジン検索専用＞
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="KindList"></param>
        /// <returns></returns>
        private void SetEgnCarKindInfoWork(SqlDataReader myReader, ArrayList KindList)
        {
            while (myReader.Read())
            {
                CarKindInfoWork wkCarKind = new CarKindInfoWork();

                wkCarKind.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                wkCarKind.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));
                wkCarKind.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));
                wkCarKind.EngineModelNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));
                wkCarKind.MakerFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERFULLNAMERF"));
                wkCarKind.MakerHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERHALFNAMERF"));
                wkCarKind.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));
                wkCarKind.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));

                KindList.Add(wkCarKind);
            }
        }

        # endregion
        # endregion

    }
}
