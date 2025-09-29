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
    /// �^���ޕʏ�񌟍�DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �^���ޕʏ�񌟍�DB�����[�g�I�u�W�F�N�g</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.16</br>
    /// <br></br>
    /// <br>Update Note: �ޕʌ�������Ԏ�I����A����������Ȃ���Q�̏C��[MANTIS:0011086]</br>
    /// <br>Programmer : 21024 ���X�� ��</br>
    /// <br>Date       : 2009.02.05</br>
    /// <br></br>
    /// <br>Update Note: �G���W���^�������ŁA�G���[�ɂȂ�ꍇ�������Q�̏C��[MANTIS:0011147]</br>
    /// <br>Programmer : 21024 ���X�� ��</br>
    /// <br>Date       : 2009.02.19</br>
    /// <br></br>
    /// <br>Update Note: ����V���[�Y�^���̃f�[�^���������A�ԑ�ԍ��E�N����񂪌������ʂ̑S�Ă̕��擾�ł��Ă��Ȃ����̏C��[MANTIS:0014523]</br>
    /// <br>Programmer : 21024 ���X�� ��</br>
    /// <br>Date       : 2009/10/29</br>
    /// </remarks>
    [Serializable]
    public class CarModelCtlDB : RemoteDB, ICarModelCtlDB
    {
        # region --- �R���X�g���N�^�[ ---
        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        public CarModelCtlDB()
            : base("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarKindInfoWork", "CARMODELRF")
        {
        }
        # endregion

        # region --- ���\�b�h ---

        # region --- �^���������\�b�h ---
        /// <summary>
        /// �^���������\�b�h
        /// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
        /// <param name="kindList">�ԗ��^��</param>
        /// <param name="colorCdRetWork">�J���[�R�[�h</param>
        /// <param name="trimCdRetWork">�g�����R�[�h</param>
        /// <param name="cEqpDefDspRetWork">�����R�[�h</param>
        /// <param name="prdTypYearRetWork">�N��</param>
        /// <param name="ctgyMdlLnkRetWork">�s�a�n</param>
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

            //���o�̓p�����[�^�[�ݒ�
            carModelRetList = new ArrayList();
            kindList = new ArrayList();
            colorCdRetWork = new ArrayList();
            trimCdRetWork = new ArrayList();
            cEqpDefDspRetWork = new ArrayList();
            prdTypYearRetWork = new ArrayList();
            ctgyMdlLnkRetWork = new ArrayList();

            try
            {
                //�r�p�k��������
                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //�Ԏ팟������
                CarModelSearchDB carModelSearchDB = new CarModelSearchDB();
                if (carModelCondWork.SearchMode == 0)
                {
                    status = carModelSearchDB.GetCarKindModel(carModelCondWork, out kindList, sqlConnection, null);
                }

                #region [ �^�����f���Č������W�b�N - �ۗ����� ]
                //// �V���[�Y���f���݂̂̓��͂Ō�������0���̏ꍇ�A���E���h�g���b�v���ŏ������邽��
                //// ���͒l��r�K�X�L���Ƃ݂Ȃ��A������x�������s���B
                ////if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && kindList.Count == 0 &&
                ////    (carModelCondWork.ExhaustGasSign == string.Empty && carModelCondWork.CategorySignModel == string.Empty))
                ////{
                ////    CarModelCondWork otherCondWork = new CarModelCondWork();
                ////    carModelCondWork.ExhaustGasSign = carModelCondWork.SeriesModel;
                ////    carModelCondWork.SeriesModel = string.Empty;
                ////    status = carModelSearchDB.GetCarKindModel(carModelCondWork, out kindList, sqlConnection, null);
                ////}
                #endregion

                //�^����������
                if ((kindList.Count == 1 && status == 0) || carModelCondWork.SearchMode == 1)
                {
                    status = carModelSearchDB.GetCarModelSearch(carModelCondWork, out carModelRetList, sqlConnection, null);
                }

                //�^���ޕʏ��擾����
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

                //�J���[�E�g�����E�����E���Y�N�����擾����
                if ((kindList.Count == 1 && status == 0) || carModelCondWork.SearchMode == 1)
                {
                    status = GetColTrmEquInf(carModelRetList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, sqlConnection);
                }

            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "CarModelCtlDB.GetCarModel�ɂ�SQL�G���[���� Msg=" + ex.Message, 0);
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

        # region --- �ޕʌ^���������\�b�h ---
        /// <summary>
        /// �ޕʌ^���������\�b�h
        /// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
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

            //���o�̓p�����[�^�[�ݒ�
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
                //�r�p�k��������
                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //�Ԏ팟������
                CarModelSearchDB carModelSearchDB = new CarModelSearchDB();
                if (carModelCondWork.SearchMode == 0)
                {
                    status = carModelSearchDB.GetCarKindCtgyMdl(carModelCondWork, out KindList, sqlConnection, null);
                }

                //�ޕʌ^����������
                if (KindList.Count == 1 || carModelCondWork.SearchMode == 1)
                {
                    // 2009.02.05 >>>
                    //if (status == 0)
                    if (( KindList.Count == 1 && status == 0 ) || carModelCondWork.SearchMode == 1)
                    // 2009.02.05 <<<
                    {
                        status = carModelSearchDB.GetCarCtgyMdlSearch(carModelCondWork, out carModelRetList, sqlConnection, null);
                    }

                    //�ޕʑ������i���擾����
                    if (status == 0)
                    {
                        CategoryEquipmentDB categoryEquipmentDB = new CategoryEquipmentDB();
                        ArrayList retArraycategoryEquipmentRetWork = new ArrayList();
                        status = categoryEquipmentDB.SearchCategoryEquipmentParts(retArraycategoryEquipmentRetWork, carModelCondWork.ModelDesignationNo, carModelCondWork.CategoryNo, sqlConnection, null);
                        categoryEquipmentRetWork = retArraycategoryEquipmentRetWork;

                        status = categoryEquipmentDB.SearchEquipment(equipmentRetWork, carModelCondWork.ModelDesignationNo, carModelCondWork.CategoryNo, sqlConnection, null);

                    }

                    //�J���[�E�g�����E�����E���Y�N�����擾����
                    if (status == 0)
                    {
                        status = GetColTrmEquInf(carModelRetList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, sqlConnection);
                    }

                }
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "CarModelCtlDB.GetCarCtgyMdl�ɂ�SQL�G���[���� Msg=" + ex.Message, 0);
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

        # region --- �v���[�g�^���������\�b�h ---
        /// <summary>
        /// �v���[�g�^���������\�b�h
        /// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
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

            //���o�̓p�����[�^�[�ݒ�
            carModelRetList = new ArrayList();
            KindList = new ArrayList();
            colorCdRetWork = new ArrayList();
            trimCdRetWork = new ArrayList();
            cEqpDefDspRetWork = new ArrayList();
            prdTypYearRetWork = new ArrayList();

            try
            {
                //�r�p�k��������
                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //�Ԏ팟������
                CarModelSearchDB carModelSearchDB = new CarModelSearchDB();
                if (carModelCondWork.SearchMode == 0)
                {
                    status = carModelSearchDB.GetCarKindlPlate(carModelCondWork, out KindList, sqlConnection, null);
                }

                //�v���[�g��������
                if ((KindList.Count == 1 && status == 0) || carModelCondWork.SearchMode == 1)
                {
                    status = carModelSearchDB.GetCarPlateSearch(carModelCondWork, out carModelRetList, sqlConnection, null);

                    //�J���[�E�g�����E�����E���Y�N�����擾����
                    if (status == 0)
                    {
                        status = GetColTrmEquInf(carModelRetList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, sqlConnection);
                    }
                }

            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "CarModelCtlDB.GetCarPlate�ɂ�SQL�G���[���� Msg=" + ex.Message, 0);
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

        # region --- �G���W���^���������\�b�h ---
        /// <summary>
        /// �G���W���^���������\�b�h
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

            //���o�̓p�����[�^�[�ݒ�
            carModelRetList = new ArrayList();
            KindList = new ArrayList();
            colorCdRetWork = new ArrayList();
            trimCdRetWork = new ArrayList();
            cEqpDefDspRetWork = new ArrayList();
            prdTypYearRetWork = new ArrayList();

            try
            {
                //�r�p�k��������
                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //�Ԏ팟������
                CarModelSearchDB carModelSearchDB = new CarModelSearchDB();
                if (carModelCondWork.SearchMode == 0)
                {
                    status = carModelSearchDB.GetCarKindEngine(carModelCondWork, out KindList, sqlConnection, null);
                }

                //�G���W���^����������
                if ((KindList.Count == 1 && status == 0) || carModelCondWork.SearchMode == 1)
                {
                    // 2009.02.19 >>>
                    // �Ԏ팟����A�Ԏ킪��̏ꍇ�̓G���W���^�����Đݒ�
                    // ���R�F�Ԏ팟���́A�G���W���^�����O����v�����A�ԗ������͊��S��v�̈�
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
                    //�J���[�E�g�����E�����E���Y�N�����擾����
                    if (status == 0)
                    {
                        status = GetColTrmEquInf(carModelRetList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, sqlConnection);
                    }
                }

            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "CarModelCtlDB.GetCarEngine�ɂ�SQL�G���[���� Msg=" + ex.Message, 0);
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

        # region --- �t���^���Œ�ԍ��������\�b�h ---
        /// <summary>
        /// �t���^���Œ�ԍ��������\�b�h
        /// </summary>
        /// <param name="carModelCondWork">��������</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
        /// <param name="kindList">�ԗ��^��</param>
        /// <param name="colorCdRetWork">�J���[�R�[�h</param>
        /// <param name="trimCdRetWork">�g�����R�[�h</param>
        /// <param name="cEqpDefDspRetWork">�����R�[�h</param>
        /// <param name="prdTypYearRetWork">�N��</param>
        /// <param name="ctgyMdlLnkRetWork">�s�a�n</param>
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

            //���o�̓p�����[�^�[�ݒ�
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
                //�r�p�k��������
                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //�Ԏ팟������
                CarModelSearchDB carModelSearchDB = new CarModelSearchDB();
                status = carModelSearchDB.GetCarFullModelNoSearch(carModelCondWork, out kindList, out carModelRetList, sqlConnection, null);

                //�^���ޕʏ��擾����
                if ((carModelRetList.Count > 0) && (status == 0))
                {
                    CtgyMdlLnkCondWork ctgyMdlLnkCondWork = new CtgyMdlLnkCondWork();
                    CtgyMdlLnkDB ctgyMdlLnkDB = new CtgyMdlLnkDB();

                    ctgyMdlLnkCondWork.FullModelFixedNo = carModelCondWork.FullModelFixedNos;
                    status = ctgyMdlLnkDB.GetCtgyMdlLnkSerch(ctgyMdlLnkCondWork, out ctgyMdlLnkRetWork, sqlConnection, null);
                }

                //�ޕʑ������i���擾����
                if (status == 0 && carModelCondWork.ModelDesignationNo != 0)
                {
                    CategoryEquipmentDB categoryEquipmentDB = new CategoryEquipmentDB();
                    ArrayList retArraycategoryEquipmentRetWork = new ArrayList();
                    status = categoryEquipmentDB.SearchCategoryEquipmentParts(retArraycategoryEquipmentRetWork, carModelCondWork.ModelDesignationNo, carModelCondWork.CategoryNo, sqlConnection, null);
                    categoryEquipmentRetWork = retArraycategoryEquipmentRetWork;

                    status = categoryEquipmentDB.SearchEquipment(equipmentRetWork, carModelCondWork.ModelDesignationNo, carModelCondWork.CategoryNo, sqlConnection, null);
                }

                //�J���[�E�g�����E�����E���Y�N�����擾����
                if ((kindList.Count == 1) && (status == 0))
                {
                    status = GetColTrmEquInf(carModelRetList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, sqlConnection);
                }

            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "CarModelCtlDB.GetCarModel�ɂ�SQL�G���[���� Msg=" + ex.Message, 0);
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

        # region --- �J���[�E�g�����E�����E���Y�N�����̎擾 ---
        /// <summary>
        /// �J���[�E�g�����E�����E���Y�N�����̎擾
        /// </summary>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
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

            //���o�̓p�����[�^�[�ݒ�
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
                    //�P�J�^���O�i������
                    if (wkInf.IsCatalogEqual(svCarModelRetWork) == false)
                    {
                        kataFlg = 1;
                    }

                    //�P�ԑ�^���i������
                    if (wkInf.IsFrameModelEqual(svCarModelRetWork) == false)
                    {
                        FModelflg = 1;
                    }

                    //�I������
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

                //�J���[���擾
                statusLocal = colTrmEquInfDB.SearchColorCd(retArraycolorCdRetWork, colTrmEquSearchCondWork, sqlConnection, null);
                if (statusLocal == 0)
                {
                    colorCdRetWork = retArraycolorCdRetWork;
                }
                else
                {
                    status = statusLocal;
                }

                //�g�������擾
                statusLocal = colTrmEquInfDB.SearchTrimCd(retArraytrimCdRetWork, colTrmEquSearchCondWork, sqlConnection, null);
                if (statusLocal == 0)
                {
                    trimCdRetWork = retArraytrimCdRetWork;
                }
                else
                {
                    status = statusLocal;
                }

                //�������擾
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
            //���Y�N�����擾
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
