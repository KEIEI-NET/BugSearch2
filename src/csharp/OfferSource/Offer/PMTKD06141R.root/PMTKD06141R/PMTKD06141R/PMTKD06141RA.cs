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
    /// �ޕʑ������i���擾�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ޕʑ������i���̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 96186�@���ԁ@�T��</br>
    /// <br>Date       : 2007.03.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class CategoryEquipmentDB : RemoteDB, ICategoryEquipmentDB
    {
        # region --- �R���X�g���N�^ ---
        /// <summary>
        /// �ޕʌ^�����������[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 96137�@�v�ۓc�@�M��</br>
        /// <br>Date       : 2005.04.05</br>
        /// </remarks>
        public CategoryEquipmentDB()
            :
        base("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CategoryEquipmentRetWork", "CTGEQUIPPTRF")
        {
        }
        # endregion

        /// <summary>
        /// �ޕʑ�������߂��܂�
        /// </summary>
        /// <param name="retbyte">��������</param>
        /// <param name="modelDesignationNo">�^���w��ԍ�</param>
        /// <param name="categoryNo">�ޕʋ敪�ԍ�</param>
        /// <returns>STATUS</returns>
        public int SearchCategoryEquipment(out object retbyte, Int32 modelDesignationNo, Int32 categoryNo)
        {
            retbyte = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            try
            {
                //�������ꎞ�i�[�R���N�V��������
                ArrayList retArrayCTGRYEQUIP = new ArrayList();

                //���\�b�h�J�n���ɃR�l�N�V������������擾
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    base.WriteErrorLog("CategoryEquipmentDB.SearchCategoryEquipment�ɂăG���[���� ConnectionText���擾�o���܂���ł����B");
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }

                //SQL������
                SqlConnection sqlConnection = null;
                using (sqlConnection = new SqlConnection(connectionText))
                {
                    sqlConnection.Open();

                    //�ޕʑ������擾
                    status = SearchCategoryEquipmentParts(retArrayCTGRYEQUIP, modelDesignationNo, categoryNo, sqlConnection, null);

                    //�߂�l��ݒ�
                    if (retArrayCTGRYEQUIP.Count > 0)
                    {
                        retbyte = (object)retArrayCTGRYEQUIP;
                    }

                }
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "CategoryEquipmentDB.SearchCategoryEquipment�ɂ�SQL�G���[���� Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CategoryEquipmentDB.SearchCategoryEquipment�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        # region --- �ޕʑ������i���擾 ---
        /// <summary>
        /// �ޕʑ������i���擾
        /// </summary>
        /// <param name="retArray">��������</param>
        /// <param name="modelDesignationNo">�����p�����[�^</param>
        /// <param name="categoryNo"></param>
        /// <param name="sqlConnection">sql�ȸ��ݏ��</param>
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

                //�B�F�ޕʑ������i���擾
                //�ޕʁE�^���݂̂Ń��[�h�ł��A�ޕʃ}�X�^�̃��[�J�[�E�Ԏ���܂񂾃��R�[�h
                //�Ƃ̊֘A���������וʃ��[�h�Ƃ��܂�
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

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaModelDesignationNo = sqlCommand.Parameters.Add("@FINDMODELDESIGNATIONNO", SqlDbType.Int);
                SqlParameter findParaCategoryNo = sqlCommand.Parameters.Add("@FINDCATEGORYNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֗ޕʁE�^���l�ݒ�
                findParaModelDesignationNo.Value = modelDesignationNo;
                findParaCategoryNo.Value = categoryNo;

                SqlDataReader myReader = null;
                try
                {
                    //�ޕʑ������i�}�X�^�Ǎ�
                    myReader = sqlCommand.ExecuteReader();
                    CategoryEquipmentPartsInfoSet(myReader, retArray);

                    if (retArray.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException ex)
                {
                    return base.WriteSQLErrorLog(ex, "CategoryEquipmentDB.SearchCategoryEquipmentParts�ɂ�SQL�G���[���� Msg=" + ex.Message, 0);
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "CategoryEquipmentDB.SearchCategoryEquipmentParts�ɂăG���[���� Msg=" + ex.Message, 0);
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

        # region --- �ޕʑ������i�}�X�^�̋敪�����N���X�ɃZ�b�g ---
        /// <summary>
        /// �ޕʑ������i�}�X�^�̏����N���X�ɃZ�b�g
        /// </summary>
        /// <param name="myReader">SqlDataReader�Ǎ�����</param>
        /// <param name="retArray"></param>
        /// <returns>�ޕʑ����敪���[�N�N���X</returns>
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

                //�ޕʑ������i�ꎞ�ۑ��p�R���N�V�����ɒǉ�
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
                //�ޕʑ������擾
                status = SearchEquipmentProc(retArray, modelDesignationNo, categoryNo, sqlConnection, sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CategoryEquipmentDB.SearchEquipment�ɂăG���[���� Msg=" + ex.Message, 0);
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

                //�������擾
                //�ޕʁE�^���݂̂Ń��[�h�ł��A�ޕʃ}�X�^�̃��[�J�[�E�Ԏ���܂񂾃��R�[�h
                //�Ƃ̊֘A���������וʃ��[�h�Ƃ��܂�
                sqlCommand.CommandText = "SELECT " +
                    "OFFERDATERF, MODELDESIGNATIONNORF, CATEGORYNORF, EQUIPMENTGENRECDRF, EQUIPMENTGENRENMRF, EQUIPMENTCODERF, EQUIPMENTNAMERF, EQUIPMENTSHORTNAMERF,EQUIPMENTICONCODERF " +
                    "FROM CTGRYEQUIPRF " +
                    "WHERE MODELDESIGNATIONNORF=@FINDMODELDESIGNATIONNO AND CATEGORYNORF=@FINDCATEGORYNO " +
                    "ORDER BY EQUIPMENTGENRECDRF, EQUIPMENTCODERF";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaModelDesignationNo = sqlCommand.Parameters.Add("@FINDMODELDESIGNATIONNO", SqlDbType.Int);
                SqlParameter findParaCategoryNo = sqlCommand.Parameters.Add("@FINDCATEGORYNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֗ޕʁE�^���l�ݒ�
                findParaModelDesignationNo.Value = modelDesignationNo;
                findParaCategoryNo.Value = categoryNo;

                SqlDataReader myReader = null;
                try
                {
                    //�ޕʑ����}�X�^�Ǎ�
                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        //�ޕʑ������擾
                        //�ޕʑ����N���X����
                        CtgryEquipWork wkCategoryEquipmentWork = CategoryEquipmentInfoSet(myReader);
                        //�ޕʑ����ꎞ�ۑ��p�R���N�V�����ɒǉ�
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
        /// �ޕʑ����}�X�^�����N���X�ɃZ�b�g���܂�
        /// </summary>
        /// <param name="myReader">SqlDataReader�Ǎ�����</param>
        /// <returns>�ޕʑ������[�N�N���X</returns>
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
