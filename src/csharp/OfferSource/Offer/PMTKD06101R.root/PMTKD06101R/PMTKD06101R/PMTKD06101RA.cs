using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 型式類別情報検索DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 型式類別情報検索DBリモートオブジェクト</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.16</br>
    /// <br></br>
    /// <br>Update Note: 類別検索から車種選択後、検索が走らない障害の修正[MANTIS:0011086]</br>
    /// <br>Programmer : 21024 佐々木 健</br>
    /// <br>Date       : 2009.02.05</br>
    /// <br></br>
    /// <br>Update Note: エンジン型式検索で、エラーになる場合がある障害の修正[MANTIS:0011147]</br>
    /// <br>Programmer : 21024 佐々木 健</br>
    /// <br>Date       : 2009.02.19</br>
    /// <br></br>
    /// <br>Update Note: 同一シリーズ型式のデータを検索時、車台番号・年式情報が検索結果の全ての分取得できていない件の修正[MANTIS:0014523]</br>
    /// <br>Programmer : 21024 佐々木 健</br>
    /// <br>Date       : 2009/10/29</br>
    /// </remarks>
    [Serializable]
    public class CarModelCtlDB : RemoteDB, ICarModelCtlDB
    {
        # region --- コンストラクター ---
        /// <summary>
        /// コンストラクター
        /// </summary>
        public CarModelCtlDB()
            : base("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarKindInfoWork", "CARMODELRF")
        {
        }
        # endregion

        # region --- メソッド ---

        # region --- 型式検索メソッド ---
        /// <summary>
        /// 型式検索メソッド
        /// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="carModelRetList">検索結果(型式リスト)</param>
        /// <param name="kindList">車両型式</param>
        /// <param name="colorCdRetWork">カラーコード</param>
        /// <param name="trimCdRetWork">トリムコード</param>
        /// <param name="cEqpDefDspRetWork">装備コード</param>
        /// <param name="prdTypYearRetWork">年式</param>
        /// <param name="ctgyMdlLnkRetWork">ＴＢＯ</param>
        /// <returns></returns>
        public int GetCarModel(CarModelCondWork carModelCondWork, out ArrayList carModelRetList, out ArrayList kindList,
            out ArrayList colorCdRetWork, out ArrayList trimCdRetWork, out ArrayList cEqpDefDspRetWork,
            out ArrayList prdTypYearRetWork, out ArrayList ctgyMdlLnkRetWork)
        {
            return GetCarModelProc(carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork,
                                    out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork);
        }

        private int GetCarModelProc(CarModelCondWork carModelCondWork, out ArrayList carModelRetList, out ArrayList kindList,
            out ArrayList colorCdRetWork, out ArrayList trimCdRetWork, out ArrayList cEqpDefDspRetWork,
            out ArrayList prdTypYearRetWork, out ArrayList ctgyMdlLnkRetWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            //入出力パラメーター設定
            carModelRetList = new ArrayList();
            kindList = new ArrayList();
            colorCdRetWork = new ArrayList();
            trimCdRetWork = new ArrayList();
            cEqpDefDspRetWork = new ArrayList();
            prdTypYearRetWork = new ArrayList();
            ctgyMdlLnkRetWork = new ArrayList();

            try
            {
                //ＳＱＬ初期処理
                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //車種検索処理
                CarModelSearchDB carModelSearchDB = new CarModelSearchDB();
                if (carModelCondWork.SearchMode == 0)
                {
                    status = carModelSearchDB.GetCarKindModel(carModelCondWork, out kindList, sqlConnection, null);
                }

                #region [ 型式モデル再検索ロジック - 保留する ]
                //// シリーズモデルのみの入力で検索結果0件の場合、ラウンドトリップを最小化するため
                //// 入力値を排ガス記号とみなす、もう一度検索を行う。
                ////if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && kindList.Count == 0 &&
                ////    (carModelCondWork.ExhaustGasSign == string.Empty && carModelCondWork.CategorySignModel == string.Empty))
                ////{
                ////    CarModelCondWork otherCondWork = new CarModelCondWork();
                ////    carModelCondWork.ExhaustGasSign = carModelCondWork.SeriesModel;
                ////    carModelCondWork.SeriesModel = string.Empty;
                ////    status = carModelSearchDB.GetCarKindModel(carModelCondWork, out kindList, sqlConnection, null);
                ////}
                #endregion

                //型式検索処理
                if ((kindList.Count == 1 && status == 0) || carModelCondWork.SearchMode == 1)
                {
                    status = carModelSearchDB.GetCarModelSearch(carModelCondWork, out carModelRetList, sqlConnection, null);
                }

                //型式類別情報取得処理
                if ((carModelRetList.Count > 0) && (status == 0))
                {
                    CtgyMdlLnkCondWork ctgyMdlLnkCondWork = new CtgyMdlLnkCondWork();
                    CtgyMdlLnkDB ctgyMdlLnkDB = new CtgyMdlLnkDB();

                    //int ix = 0;
                    List<int> lstFullModelFixedNo = new List<int>();
                    //Int32[] FullModelFixedNos;
                    //FullModelFixedNos = new Int32[carModelRetList.Count];

                    foreach (CarModelRetWork wkInf in carModelRetList)
                    {
                        if (lstFullModelFixedNo.Contains(wkInf.FullModelFixedNo) == false)
                        {
                            lstFullModelFixedNo.Add(wkInf.FullModelFixedNo);
                        }
                    }

                    ctgyMdlLnkCondWork.FullModelFixedNo = lstFullModelFixedNo.ToArray();//FullModelFixedNos;
                    status = ctgyMdlLnkDB.GetCtgyMdlLnkSerch(ctgyMdlLnkCondWork, out ctgyMdlLnkRetWork, sqlConnection, null);
                }

                //カラー・トリム・装備・生産年式情報取得処理
                if ((kindList.Count == 1 && status == 0) || carModelCondWork.SearchMode == 1)
                {
                    status = GetColTrmEquInf(carModelRetList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, sqlConnection);
                }

            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "CarModelCtlDB.GetCarModelにてSQLエラー発生 Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CarModelCtlDB.GetCarModel Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        # endregion

        # region --- 類別型式検索メソッド ---
        /// <summary>
        /// 類別型式検索メソッド
        /// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="carModelRetList">検索結果(型式リスト)</param>
        /// <param name="KindList"></param>
        /// <param name="colorCdRetWork"></param>
        /// <param name="trimCdRetWork"></param>
        /// <param name="cEqpDefDspRetWork"></param>
        /// <param name="prdTypYearRetWork"></param>
        /// <param name="categoryEquipmentRetWork"></param>
        /// <param name="equipmentRetWork"></param>
        /// <returns></returns>
        public int GetCarCtgyMdl(CarModelCondWork carModelCondWork, out ArrayList carModelRetList,
            out ArrayList KindList, out ArrayList colorCdRetWork, out ArrayList trimCdRetWork,
            out ArrayList cEqpDefDspRetWork, out ArrayList prdTypYearRetWork, out ArrayList categoryEquipmentRetWork,
            out ArrayList equipmentRetWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            //入出力パラメーター設定
            carModelRetList = new ArrayList();
            KindList = new ArrayList();
            colorCdRetWork = new ArrayList();
            trimCdRetWork = new ArrayList();
            cEqpDefDspRetWork = new ArrayList();
            prdTypYearRetWork = new ArrayList();
            categoryEquipmentRetWork = new ArrayList();
            equipmentRetWork = new ArrayList();

            try
            {
                //ＳＱＬ初期処理
                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //車種検索処理
                CarModelSearchDB carModelSearchDB = new CarModelSearchDB();
                if (carModelCondWork.SearchMode == 0)
                {
                    status = carModelSearchDB.GetCarKindCtgyMdl(carModelCondWork, out KindList, sqlConnection, null);
                }

                //類別型式検索処理
                if (KindList.Count == 1 || carModelCondWork.SearchMode == 1)
                {
                    // 2009.02.05 >>>
                    //if (status == 0)
                    if (( KindList.Count == 1 && status == 0 ) || carModelCondWork.SearchMode == 1)
                    // 2009.02.05 <<<
                    {
                        status = carModelSearchDB.GetCarCtgyMdlSearch(carModelCondWork, out carModelRetList, sqlConnection, null);
                    }

                    //類別装備部品情報取得処理
                    if (status == 0)
                    {
                        CategoryEquipmentDB categoryEquipmentDB = new CategoryEquipmentDB();
                        ArrayList retArraycategoryEquipmentRetWork = new ArrayList();
                        status = categoryEquipmentDB.SearchCategoryEquipmentParts(retArraycategoryEquipmentRetWork, carModelCondWork.ModelDesignationNo, carModelCondWork.CategoryNo, sqlConnection, null);
                        categoryEquipmentRetWork = retArraycategoryEquipmentRetWork;

                        status = categoryEquipmentDB.SearchEquipment(equipmentRetWork, carModelCondWork.ModelDesignationNo, carModelCondWork.CategoryNo, sqlConnection, null);

                    }

                    //カラー・トリム・装備・生産年式情報取得処理
                    if (status == 0)
                    {
                        status = GetColTrmEquInf(carModelRetList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, sqlConnection);
                    }

                }
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "CarModelCtlDB.GetCarCtgyMdlにてSQLエラー発生 Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CarModelCtlDB.GetCarCtgyMdl Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        # endregion

        # region --- プレート型式検索メソッド ---
        /// <summary>
        /// プレート型式検索メソッド
        /// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="carModelRetList">検索結果(型式リスト)</param>
        /// <param name="KindList"></param>
        /// <param name="colorCdRetWork"></param>
        /// <param name="trimCdRetWork"></param>
        /// <param name="cEqpDefDspRetWork"></param>
        /// <param name="prdTypYearRetWork"></param>
        /// <returns></returns>
        public int GetCarPlate(CarModelCondWork carModelCondWork, out ArrayList carModelRetList, out ArrayList KindList, out ArrayList colorCdRetWork, out ArrayList trimCdRetWork, out ArrayList cEqpDefDspRetWork, out ArrayList prdTypYearRetWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            //入出力パラメーター設定
            carModelRetList = new ArrayList();
            KindList = new ArrayList();
            colorCdRetWork = new ArrayList();
            trimCdRetWork = new ArrayList();
            cEqpDefDspRetWork = new ArrayList();
            prdTypYearRetWork = new ArrayList();

            try
            {
                //ＳＱＬ初期処理
                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //車種検索処理
                CarModelSearchDB carModelSearchDB = new CarModelSearchDB();
                if (carModelCondWork.SearchMode == 0)
                {
                    status = carModelSearchDB.GetCarKindlPlate(carModelCondWork, out KindList, sqlConnection, null);
                }

                //プレート検索処理
                if ((KindList.Count == 1 && status == 0) || carModelCondWork.SearchMode == 1)
                {
                    status = carModelSearchDB.GetCarPlateSearch(carModelCondWork, out carModelRetList, sqlConnection, null);

                    //カラー・トリム・装備・生産年式情報取得処理
                    if (status == 0)
                    {
                        status = GetColTrmEquInf(carModelRetList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, sqlConnection);
                    }
                }

            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "CarModelCtlDB.GetCarPlateにてSQLエラー発生 Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CarModelCtlDB.GetCarPlate Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        # endregion

        # region --- エンジン型式検索メソッド ---
        /// <summary>
        /// エンジン型式検索メソッド
        /// </summary>
        /// <param name="carModelCondWork"></param>
        /// <param name="carModelRetList"></param>
        /// <param name="KindList"></param>
        /// <param name="colorCdRetWork"></param>
        /// <param name="trimCdRetWork"></param>
        /// <param name="cEqpDefDspRetWork"></param>
        /// <param name="prdTypYearRetWork"></param>
        /// <returns></returns>
        public int GetCarEngine(CarModelCondWork carModelCondWork, out ArrayList carModelRetList, out ArrayList KindList, out ArrayList colorCdRetWork, out ArrayList trimCdRetWork, out ArrayList cEqpDefDspRetWork, out ArrayList prdTypYearRetWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            //入出力パラメーター設定
            carModelRetList = new ArrayList();
            KindList = new ArrayList();
            colorCdRetWork = new ArrayList();
            trimCdRetWork = new ArrayList();
            cEqpDefDspRetWork = new ArrayList();
            prdTypYearRetWork = new ArrayList();

            try
            {
                //ＳＱＬ初期処理
                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //車種検索処理
                CarModelSearchDB carModelSearchDB = new CarModelSearchDB();
                if (carModelCondWork.SearchMode == 0)
                {
                    status = carModelSearchDB.GetCarKindEngine(carModelCondWork, out KindList, sqlConnection, null);
                }

                //エンジン型式検索処理
                if ((KindList.Count == 1 && status == 0) || carModelCondWork.SearchMode == 1)
                {
                    // 2009.02.19 >>>
                    // 車種検索後、車種が一つの場合はエンジン型式を再設定
                    // 理由：車種検索は、エンジン型式が前方一致だが、車両検索は完全一致の為
                    if ( carModelCondWork.SearchMode == 0 )
                    {
                        if (KindList[0] is CarKindInfoWork)
                        {
                            carModelCondWork.EngineModelNm = ( (CarKindInfoWork)KindList[0] ).EngineModelNm;
                            carModelCondWork.MakerCode = ( (CarKindInfoWork)KindList[0] ).MakerCode;
                            carModelCondWork.ModelCode = ( (CarKindInfoWork)KindList[0] ).ModelCode;
                            carModelCondWork.ModelSubCode = ( (CarKindInfoWork)KindList[0] ).ModelSubCode;
                        }
                    }
                    // 2009.02.19 <<<
                    status = carModelSearchDB.GetCarEngineSearch(carModelCondWork, out carModelRetList, sqlConnection, null);
                    //カラー・トリム・装備・生産年式情報取得処理
                    if (status == 0)
                    {
                        status = GetColTrmEquInf(carModelRetList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, sqlConnection);
                    }
                }

            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "CarModelCtlDB.GetCarEngineにてSQLエラー発生 Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CarModelCtlDB.GetCarEngine Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        # endregion

        # region --- フル型式固定番号検索メソッド ---
        /// <summary>
        /// フル型式固定番号検索メソッド
        /// </summary>
        /// <param name="carModelCondWork">検索条件</param>
        /// <param name="carModelRetList">検索結果(型式リスト)</param>
        /// <param name="kindList">車両型式</param>
        /// <param name="colorCdRetWork">カラーコード</param>
        /// <param name="trimCdRetWork">トリムコード</param>
        /// <param name="cEqpDefDspRetWork">装備コード</param>
        /// <param name="prdTypYearRetWork">年式</param>
        /// <param name="ctgyMdlLnkRetWork">ＴＢＯ</param>
        /// <param name="categoryEquipmentRetWork"></param>
        /// <param name="equipmentRetWork"></param>
        /// <returns></returns>
        public int GetCarFullModelNo(CarModelCondWork carModelCondWork, out ArrayList carModelRetList, out ArrayList kindList,
            out ArrayList colorCdRetWork, out ArrayList trimCdRetWork, out ArrayList cEqpDefDspRetWork,
            out ArrayList prdTypYearRetWork, out ArrayList ctgyMdlLnkRetWork, out ArrayList categoryEquipmentRetWork, out ArrayList equipmentRetWork)
        {
            return GetCarFullModelNoProc(carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork,
                                    out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork,
                                    out categoryEquipmentRetWork, out equipmentRetWork);
        }

        private int GetCarFullModelNoProc(CarModelCondWork carModelCondWork, out ArrayList carModelRetList, out ArrayList kindList,
            out ArrayList colorCdRetWork, out ArrayList trimCdRetWork, out ArrayList cEqpDefDspRetWork,
            out ArrayList prdTypYearRetWork, out ArrayList ctgyMdlLnkRetWork, out ArrayList categoryEquipmentRetWork, 
            out ArrayList equipmentRetWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            //入出力パラメーター設定
            carModelRetList = new ArrayList();
            kindList = new ArrayList();
            colorCdRetWork = new ArrayList();
            trimCdRetWork = new ArrayList();
            cEqpDefDspRetWork = new ArrayList();
            prdTypYearRetWork = new ArrayList();
            ctgyMdlLnkRetWork = new ArrayList();
            categoryEquipmentRetWork = new ArrayList();
            equipmentRetWork = new ArrayList();

            try
            {
                //ＳＱＬ初期処理
                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //車種検索処理
                CarModelSearchDB carModelSearchDB = new CarModelSearchDB();
                status = carModelSearchDB.GetCarFullModelNoSearch(carModelCondWork, out kindList, out carModelRetList, sqlConnection, null);

                //型式類別情報取得処理
                if ((carModelRetList.Count > 0) && (status == 0))
                {
                    CtgyMdlLnkCondWork ctgyMdlLnkCondWork = new CtgyMdlLnkCondWork();
                    CtgyMdlLnkDB ctgyMdlLnkDB = new CtgyMdlLnkDB();

                    ctgyMdlLnkCondWork.FullModelFixedNo = carModelCondWork.FullModelFixedNos;
                    status = ctgyMdlLnkDB.GetCtgyMdlLnkSerch(ctgyMdlLnkCondWork, out ctgyMdlLnkRetWork, sqlConnection, null);
                }

                //類別装備部品情報取得処理
                if (status == 0 && carModelCondWork.ModelDesignationNo != 0)
                {
                    CategoryEquipmentDB categoryEquipmentDB = new CategoryEquipmentDB();
                    ArrayList retArraycategoryEquipmentRetWork = new ArrayList();
                    status = categoryEquipmentDB.SearchCategoryEquipmentParts(retArraycategoryEquipmentRetWork, carModelCondWork.ModelDesignationNo, carModelCondWork.CategoryNo, sqlConnection, null);
                    categoryEquipmentRetWork = retArraycategoryEquipmentRetWork;

                    status = categoryEquipmentDB.SearchEquipment(equipmentRetWork, carModelCondWork.ModelDesignationNo, carModelCondWork.CategoryNo, sqlConnection, null);
                }

                //カラー・トリム・装備・生産年式情報取得処理
                if ((kindList.Count == 1) && (status == 0))
                {
                    status = GetColTrmEquInf(carModelRetList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, sqlConnection);
                }

            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "CarModelCtlDB.GetCarModelにてSQLエラー発生 Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CarModelCtlDB.GetCarModel Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        # endregion
        # endregion

        # region --- カラー・トリム・装備・生産年式情報の取得 ---
        /// <summary>
        /// カラー・トリム・装備・生産年式情報の取得
        /// </summary>
        /// <param name="carModelRetList">検索結果(型式リスト)</param>
        /// <param name="colorCdRetWork"></param>
        /// <param name="trimCdRetWork"></param>
        /// <param name="cEqpDefDspRetWork"></param>
        /// <param name="prdTypYearRetWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int GetColTrmEquInf(ArrayList carModelRetList, out ArrayList colorCdRetWork,
            out ArrayList trimCdRetWork, out ArrayList cEqpDefDspRetWork, out ArrayList prdTypYearRetWork, SqlConnection sqlConnection)
        {
            int status = 0;
            int statusLocal;
            int kataFlg = 0;
            int FModelflg = 0;
            CarModelRetWork svCarModelRetWork = new CarModelRetWork();

            //入出力パラメーター設定
            colorCdRetWork = null;
            trimCdRetWork = null;
            cEqpDefDspRetWork = null;
            prdTypYearRetWork = null;

            ArrayList retArraycolorCdRetWork = new ArrayList();
            ArrayList retArraytrimCdRetWork = new ArrayList();
            ArrayList retArraycEqpDefDspRetWork = new ArrayList();
            ArrayList retArrayprdTypYearRetWork = new ArrayList();

            if (carModelRetList.Count <= 0)
            {
                return (status);
            }
            List<int> lstSystematicCode = new List<int>();
            List<int> lstProduceTypeOfYearCd = new List<int>();
            List<int> lstFullModelFixedNo = new List<int>();
            if (carModelRetList.Count > 1)
            {
                svCarModelRetWork = carModelRetList[0] as CarModelRetWork;
                lstSystematicCode.Add(svCarModelRetWork.SystematicCode);
                lstProduceTypeOfYearCd.Add(svCarModelRetWork.ProduceTypeOfYearCd);
                lstFullModelFixedNo.Add(svCarModelRetWork.FullModelFixedNo);
                for (int i = 1; i < carModelRetList.Count; i++)
                {
                    CarModelRetWork wkInf = carModelRetList[i] as CarModelRetWork;
                    if (lstSystematicCode.Contains(wkInf.SystematicCode) == false)
                    {
                        lstSystematicCode.Add(wkInf.SystematicCode);
                    }
                    if (lstProduceTypeOfYearCd.Contains(wkInf.ProduceTypeOfYearCd) == false)
                    {
                        lstProduceTypeOfYearCd.Add(wkInf.ProduceTypeOfYearCd);
                    }
                    if (lstFullModelFixedNo.Contains(wkInf.FullModelFixedNo) == false)
                    {
                        lstFullModelFixedNo.Add(wkInf.FullModelFixedNo);
                    }
                    //１カタログ絞込判定
                    if (wkInf.IsCatalogEqual(svCarModelRetWork) == false)
                    {
                        kataFlg = 1;
                    }

                    //１車台型式絞込判定
                    if (wkInf.IsFrameModelEqual(svCarModelRetWork) == false)
                    {
                        FModelflg = 1;
                    }

                    //終了条件
                    if ((kataFlg == 1) && (FModelflg == 1))
                    {
                        break;
                    }
                }
            }

            PrdTypYearDB prdTypYearDB = new PrdTypYearDB();
            ColTrmEquInfDB colTrmEquInfDB = new ColTrmEquInfDB();
            CarModelRetWork carModelRetWork = carModelRetList[0] as CarModelRetWork;

            if (kataFlg == 0)
            {
                ColTrmEquSearchCondWork colTrmEquSearchCondWork = new ColTrmEquSearchCondWork();
                colTrmEquSearchCondWork.MakerCode = carModelRetWork.MakerCode;
                colTrmEquSearchCondWork.ModelCode = carModelRetWork.ModelCode;
                colTrmEquSearchCondWork.ModelSubCode = carModelRetWork.ModelSubCode;
                colTrmEquSearchCondWork.ProduceTypeOfYearCd = lstProduceTypeOfYearCd.ToArray();//carModelRetWork.ProduceTypeOfYearCd;
                colTrmEquSearchCondWork.SystematicCode = lstSystematicCode.ToArray();//carModelRetWork.SystematicCode;

                colTrmEquSearchCondWork.FullModelFixedNo = lstFullModelFixedNo.ToArray();

                //カラー情報取得
                statusLocal = colTrmEquInfDB.SearchColorCd(retArraycolorCdRetWork, colTrmEquSearchCondWork, sqlConnection, null);
                if (statusLocal == 0)
                {
                    colorCdRetWork = retArraycolorCdRetWork;
                }
                else
                {
                    status = statusLocal;
                }

                //トリム情報取得
                statusLocal = colTrmEquInfDB.SearchTrimCd(retArraytrimCdRetWork, colTrmEquSearchCondWork, sqlConnection, null);
                if (statusLocal == 0)
                {
                    trimCdRetWork = retArraytrimCdRetWork;
                }
                else
                {
                    status = statusLocal;
                }

                //装備情報取得
                statusLocal = colTrmEquInfDB.SearchCEqpDefDsp(retArraycEqpDefDspRetWork, colTrmEquSearchCondWork, sqlConnection, null);
                if (statusLocal == 0)
                {
                    cEqpDefDspRetWork = retArraycEqpDefDspRetWork;
                }
                else
                {
                    status = statusLocal;
                }
            }
            //生産年式情報取得
            if (FModelflg == 0)
            {
                PrdTypYearCondWork prdTypYearCondWork = new PrdTypYearCondWork();
                prdTypYearCondWork.MakerCode = carModelRetWork.MakerCode;
                prdTypYearCondWork.FrameModel = carModelRetWork.FrameModel;
                // 2009/10/29 Del >>>
                //prdTypYearCondWork.StProduceTypeOfYear = carModelRetWork.StProduceTypeOfYear;
                //prdTypYearCondWork.EdProduceTypeOfYear = carModelRetWork.EdProduceTypeOfYear;
                // 2009/10/29 Del <<<

                status = prdTypYearDB.SearchPrdTypYear(retArrayprdTypYearRetWork, prdTypYearCondWork, sqlConnection, null);
                // 2009/10/29 >>>
                //// if (status == 0)
                //// {
                //prdTypYearRetWork = retArrayprdTypYearRetWork;
                //// }

                if (retArrayprdTypYearRetWork != null && retArrayprdTypYearRetWork.Count > 0)
                {
                    foreach (PrdTypYearRetWork wkPrdTypYearRetWork in retArrayprdTypYearRetWork)
                    {
                        foreach (CarModelRetWork wkCarModelRetWork in carModelRetList)
                        {
                            if (wkPrdTypYearRetWork.ProduceTypeOfYear >= wkCarModelRetWork.StProduceTypeOfYear &&
                                wkPrdTypYearRetWork.ProduceTypeOfYear <= wkCarModelRetWork.EdProduceTypeOfYear)
                            {
                                if (prdTypYearRetWork == null) prdTypYearRetWork = new ArrayList();
                                prdTypYearRetWork.Add(wkPrdTypYearRetWork);
                                break;
                            }
                        }
                    }
                }
                // 2009/10/29 <<<
            }

            return (status);
        }
        # endregion

    }
}
