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
    /// �^�����擾�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �^�����擾�����[�g�N���X�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.09</br>
    /// <br></br>
    /// <br>Update Note: 2009/10/13  22018  ��� ���b</br>
    /// <br>             ���o�\�t�@�\�̏C���Ή��B�i�t���^���Œ�ԍ��z��Ƀ[�����܂܂�鎞�̑Ή��j</br>
    /// <br></br>
    /// <br>Update Note: 2012/03/05  22008  ���� ���n</br>
    /// <br>             �O�ԕ��i�����Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2012/05/28  20056  ���n ���</br>
    /// <br>             SCM���� No135</br>
    /// <br></br>
    /// <br>Update Note: 2013/02/12  22013  �v�ۏ���</br>
    /// <br>             VSS[Partsman.NS[012]] �d�|�ꗗ�Ή� No.854</br>
    /// <br>             �@�EPM7��NS�̐��Y�N���̈Ⴂ�ɂ����ɑΉ�</br>
    /// <br></br>
    /// <br>Update Note: 2013/03/21  FSI�֓� �a�G</br>
    /// <br>             10900269-00 SPK�ԑ�ԍ�������Ή�</br>
    /// <br>               �E���Y/�O�ԋ敪�ƃn���h���ʒu���̎擾�Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2013/04/24  ��� �T�M</br>
    /// <br>             10900269-00 SPK�ԑ�ԍ�������Ή�</br>
    /// <br>               �E���Y/�O�ԋ敪���O�ԂŎԑ�ԍ��J�n��0�ȊO�̎��ɂ͍��Y�Ƃ��ĕ␳����Ή�</br>
    /// </remarks>
    [Serializable]
    public class CarModelSearchDB : RemoteDB, ICarModelSearchDB
    {
        # region --- private��` ---
        # region --- �񋟎��q�^���}�X�^�擾���ڒ�` ---

        //�񋟎��q�^���}�X�^�擾���ڒ�`
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
             #region // DEL 2013/02/12 22013 �v��@�d�|�ꗗ�Ή� No.854
                //+ ", CAR.STPRODUCETYPEOFYEARRF"
                //+ ", CAR.EDPRODUCETYPEOFYEARRF"
            #endregion
            // ADD 2013/02/12 22013 �v��@�d�|�ꗗ�Ή� No.854 *-------------------->>>
                + ", CAR.PTSTPRDCTYPEYRF"
                + ", CAR.PTEDPRDCTYPEYRF"
            // ADD 2013/02/12 22013 �v��@�d�|�ꗗ�Ή� No.854 *-------------------->>>
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
        #region // DEL 2013/02/12 22013 �v��@�d�|�ꗗ�Ή� No.854
            //+ ", CAR.STPRODUCETYPEOFYEARRF"
            //+ ", CAR.EDPRODUCETYPEOFYEARRF"     
        #endregion
                + ", CAR.PTSTPRDCTYPEYRF"   // ADD 2013/02/12 22013 �v��@�d�|�ꗗ�Ή� No.854
                + ", CAR.PTEDPRDCTYPEYRF"   // ADD 2013/02/12 22013 �v��@�d�|�ꗗ�Ή� No.854
            ;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/24 ADD

        # endregion
        # endregion

        # region --- �R���X�g���N�^�[ ---
        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        public CarModelSearchDB()
            : base("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarKindInfoWork", "CARMODELRF")
        {
        }
        # endregion

        # region --- �Ԏ���擾���� ---
        # region --- �Ԏ팟���������ޕʌ^�������� ---
        /// <summary>
        /// �Ԏ팟���������ޕʌ^��������
        /// �ޕʏ��i�^���w��ԍ�5���A�ޕʋ敪�ԍ�4���j���Ԏ���̎擾���s���܂��B
        /// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="KindList">��������(�Ԏ탊�X�g)</param>
        /// <returns>DB Status</returns>
        public int GetCarKindCtgyMdl(CarModelCondWork carModelCondWork, out ArrayList KindList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            KindList = null;

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_OfferDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                    return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = GetCarKindCtgyMdl(carModelCondWork, out KindList, sqlConnection, null);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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
        /// �Ԏ팟���������ޕʌ^��������
        /// �ޕʏ��i�^���w��ԍ�5���A�ޕʋ敪�ԍ�4���j���Ԏ���̎擾���s���܂��B
        /// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="KindList">��������(�Ԏ탊�X�g)</param>
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
                //�擾����
                string sqlText = CarKindSelectFields;
                SqlCommand sqlCmd = new SqlCommand();

                //�A���w��
                sqlText += " FROM CTGYMDLLNKRF AS CTG INNER JOIN CARMODELRF AS CAR ON CTG.CARPROPERNORF = CAR.CARPROPERNORF";
                sqlText += " INNER JOIN MAKERNAMERF ON CAR.MAKERCODERF = MAKERNAMERF.MAKERCODERF ";
                sqlText += " INNER JOIN MODELNAMERF ON CAR.MAKERCODERF = MODELNAMERF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMERF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMERF.MODELSUBCODERF";

                //���o����
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

                //�uORDER BY�v�ݒ�
                sqlText += CARMODELRFOrderByFields;

                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = sqlText;
                sqlCmd.Transaction = sqlTransaction;

                // SQL�̎��s
                myReader = sqlCmd.ExecuteReader();

                // �Ԏ���i�[����
                SetCarKindInfoWork(myReader, KindList);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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

        # region --- �Ԏ팟���������^�������� ---
        /// <summary>
        /// �Ԏ팟���������^��������
        /// �r�K�X�L���A�V���[�Y�^���A�^���i�ޕʔԍ��j���Ԏ���̎擾���s���܂��B
        /// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="kindList">��������(�Ԏ탊�X�g)</param>
        /// <returns>DB Status</returns>
        public int GetCarKindModel(CarModelCondWork carModelCondWork, out ArrayList kindList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            kindList = null;

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_OfferDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                    return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = GetCarKindModel(carModelCondWork, out kindList, sqlConnection, null);

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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
        /// �Ԏ팟���������^��������
        /// �r�K�X�L���A�V���[�Y�^���A�^���i�ޕʔԍ��j���Ԏ���̎擾���s���܂��B
        /// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="kindList">��������(�Ԏ탊�X�g)</param>
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
                //�擾����
                string sqlText = CarKindSelectFields;
                string whereString = string.Empty;
                SqlCommand sqlCmd = new SqlCommand();

                //�A���w��
                sqlText += " FROM CARMODELRF AS CAR ";
                sqlText += " INNER JOIN MAKERNAMERF ON CAR.MAKERCODERF = MAKERNAMERF.MAKERCODERF ";
                sqlText += " INNER JOIN MODELNAMERF ON CAR.MAKERCODERF = MODELNAMERF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMERF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMERF.MODELSUBCODERF";

                //���o����
                // �r�K�X�K�����ʋL��
                if (carModelCondWork.ExhaustGasSign != string.Empty)
                {
                    whereString += " AND CAR.EXHAUSTGASSIGNRF = @EXHAUSTGASSIGNRF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@EXHAUSTGASSIGNRF", SqlDbType.NChar)).Value = SqlDataMediator.SqlSetString(carModelCondWork.ExhaustGasSign);
                }

                // �V���[�Y�^��
                if (carModelCondWork.SeriesModel != string.Empty)
                {
                    if (carModelCondWork.CategorySignModel == string.Empty)
                    {
                        // �ޕʋL�������͂���Ă��Ȃ���Ό����v                        
                        whereString += " AND CAR.SERIESMODELRF LIKE @SERIESMODELRF";
                        ((SqlParameter)sqlCmd.Parameters.Add("@SERIESMODELRF", SqlDbType.NChar)).Value = SqlDataMediator.SqlSetString(carModelCondWork.SeriesModel + '%');
                    }
                    else
                    {
                        // �ޕʋL�������͂���Ă���ꍇ�͊��S��v
                        whereString += " AND CAR.SERIESMODELRF = @SERIESMODELRF";
                        ((SqlParameter)sqlCmd.Parameters.Add("@SERIESMODELRF", SqlDbType.NChar)).Value = SqlDataMediator.SqlSetString(carModelCondWork.SeriesModel);
                    }
                }

                // �ޕʋL��
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

                //�uORDER BY�v�ݒ�
                sqlText += CARMODELRFOrderByFields;

                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = sqlText;
                sqlCmd.Transaction = sqlTransanction;

                // SQL�̎��s
                myReader = sqlCmd.ExecuteReader();

                // �Ԏ���i�[����
                SetCarKindInfoWork(myReader, kindList);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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

        # region --- �Ԏ팟���������v���[�g������ ---
        /// <summary>
        /// �Ԏ팟���������v���[�g������
        /// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="KindList">��������(�Ԏ탊�X�g)</param>
        /// <returns>DB Status</returns>
        public int GetCarKindlPlate(CarModelCondWork carModelCondWork, out ArrayList KindList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            KindList = null;

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_OfferDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                    return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = GetCarKindlPlate(carModelCondWork, out KindList, sqlConnection, null);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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
        /// �Ԏ팟���������v���[�g������
        /// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="KindList">��������(�Ԏ탊�X�g)</param>
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
                //�擾����
                string sqlText = CarKindSelectFields;
                SqlCommand sqlCmd = new SqlCommand();

                //�A���w��
                sqlText += " FROM PLATEMDLLNKRF AS PLA INNER JOIN CARMODELRF AS CAR ON PLA.CARPROPERNORF = CAR.CARPROPERNORF";
                sqlText += " INNER JOIN MAKERNAMERF ON CAR.MAKERCODERF = MAKERNAMERF.MAKERCODERF ";
                sqlText += " INNER JOIN MODELNAMERF ON CAR.MAKERCODERF = MODELNAMERF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMERF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMERF.MODELSUBCODERF";
                //sqlText += " LEFT JOIN ADDICARSPECTTLRF AS ADI ON ADI.MAKERCODERF = CAR.MAKERCODERF AND ADI.MODELCODERF = CAR.MODELCODERF AND ADI.MODELSUBCODERF = CAR.MODELSUBCODERF ";

                //���o����
                sqlText += " WHERE";

                //���f���v���[�g�ԍ�
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

                //���[�J�[�R�[�h
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

                //�uORDER BY�v�ݒ�
                sqlText += CARMODELRFOrderByFields;

                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = sqlText;
                sqlCmd.Transaction = sqlTransaction;

                // SQL�̎��s
                myReader = sqlCmd.ExecuteReader();

                // �Ԏ���i�[����
                SetCarKindInfoWork(myReader, KindList);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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

        # region --- �Ԏ팟���������G���W���^�������� ---
        /// <summary>
        /// �Ԏ팟���������G���W���^��������
        /// </summary>
        /// <param name="carModelCondWork"></param>
        /// <param name="KindList">��������(�Ԏ탊�X�g)</param>
        /// <returns>DB Status</returns>
        public int GetCarKindEngine(CarModelCondWork carModelCondWork, out ArrayList KindList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            KindList = null;

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_OfferDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                    return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = GetCarKindEngine(carModelCondWork, out KindList, sqlConnection, null);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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
        /// �Ԏ팟���������G���W���^��������
        /// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="KindList">��������(�Ԏ탊�X�g)</param>
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
                //�擾����
                string sqlText = CarKindEgnSelectFields;
                SqlCommand sqlCmd = new SqlCommand();

                //�A���w��
                //sqlText += " FROM CARMODELINDEXRF AS IDX INNER JOIN CARMODELRF AS CAR ON IDX.CARPROPERNORF = CAR.CARPROPERNORF";
                sqlText += " FROM CARMODELRF AS CAR ";
                sqlText += " INNER JOIN MAKERNAMERF ON CAR.MAKERCODERF = MAKERNAMERF.MAKERCODERF ";
                sqlText += " INNER JOIN MODELNAMERF ON CAR.MAKERCODERF = MODELNAMERF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMERF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMERF.MODELSUBCODERF";
                //���o����
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

                //�uORDER BY�v�ݒ�
                sqlText += CARMODELRFOrderByFields;

                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = sqlText;
                sqlCmd.Transaction = sqlTransaction;

                // SQL�̎��s
                myReader = sqlCmd.ExecuteReader();

                // �Ԏ���i�[����
                SetEgnCarKindInfoWork(myReader, KindList);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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

        # region --- �^�����擾���� ---
        # region --- �^�������������ޕʌ^�������� ---
        /// <summary>
        /// �ޕʌ^����������
        /// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
        /// <returns>DB Status</returns>
        public int GetCarCtgyMdlSearch(CarModelCondWork carModelCondWork, out ArrayList carModelRetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            carModelRetList = null;

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_OfferDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                    return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = GetCarCtgyMdlSearch(carModelCondWork, out carModelRetList, sqlConnection, null);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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
        /// �ޕʌ^����������
        /// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
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
                //�擾����
                string sqlText = CARMODELRFSelectFields;
                SqlCommand sqlCmd = new SqlCommand();

                //�A���w��
                sqlText += " FROM CTGYMDLLNKRF AS CTG INNER JOIN CARMODELRF AS CAR ON CTG.CARPROPERNORF = CAR.CARPROPERNORF";
                sqlText += " INNER JOIN MAKERNAMERF ON CAR.MAKERCODERF = MAKERNAMERF.MAKERCODERF ";
                sqlText += " INNER JOIN MODELNAMERF ON CAR.MAKERCODERF = MODELNAMERF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMERF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMERF.MODELSUBCODERF";
                sqlText += " LEFT JOIN ADDICARSPECTTLRF AS ADI ON ADI.MAKERCODERF = CAR.MAKERCODERF AND ADI.MODELCODERF = CAR.MODELCODERF AND ADI.MODELSUBCODERF = CAR.MODELSUBCODERF ";

                //���o����
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

                // SQL�̎��s
                myReader = sqlCmd.ExecuteReader();

                // ���q�^���i�[����
                SetCarModelRetWork(myReader, carModelRetList);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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

        # region --- �^�������������^�������� ---
        /// <summary>
        /// �^����������
        /// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
        /// <returns>DB Status</returns>
        public int GetCarModelSearch(CarModelCondWork carModelCondWork, out ArrayList carModelRetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            carModelRetList = null;

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_OfferDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                    return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = GetCarModelSearch(carModelCondWork, out carModelRetList, sqlConnection, null);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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
        /// �^����������
        /// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
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
                //�擾����
                string sqlText = CARMODELRFSelectFields;
                string whereString = string.Empty;
                SqlCommand sqlCmd = new SqlCommand();

                //�A���w��
                sqlText += " FROM CARMODELRF AS CAR ";
                sqlText += " INNER JOIN MAKERNAMERF ON CAR.MAKERCODERF = MAKERNAMERF.MAKERCODERF ";
                sqlText += " INNER JOIN MODELNAMERF ON CAR.MAKERCODERF = MODELNAMERF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMERF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMERF.MODELSUBCODERF";
                sqlText += " LEFT JOIN ADDICARSPECTTLRF AS ADI ON ADI.MAKERCODERF = CAR.MAKERCODERF AND ADI.MODELCODERF = CAR.MODELCODERF AND ADI.MODELSUBCODERF = CAR.MODELSUBCODERF ";

                //���o����
                // �r�K�X�K�����ʋL��
                if (carModelCondWork.ExhaustGasSign != string.Empty)
                {
                    whereString += " AND CAR.EXHAUSTGASSIGNRF = @EXHAUSTGASSIGNRF";
                    ((SqlParameter)sqlCmd.Parameters.Add("@EXHAUSTGASSIGNRF", SqlDbType.NChar)).Value = SqlDataMediator.SqlSetString(carModelCondWork.ExhaustGasSign);
                }

                // �V���[�Y�^��
                if (carModelCondWork.SeriesModel != string.Empty)
                {
                    if (carModelCondWork.CategorySignModel == string.Empty)
                    {
                        // �ޕʋL�������͂���Ă��Ȃ���Ό����v
                        whereString += " AND CAR.SERIESMODELRF LIKE @SERIESMODELRF";
                        ((SqlParameter)sqlCmd.Parameters.Add("@SERIESMODELRF", SqlDbType.NChar)).Value = SqlDataMediator.SqlSetString(carModelCondWork.SeriesModel + '%');
                    }
                    else
                    {
                        // �ޕʋL�������͂���Ă���ꍇ�͊��S��v
                        whereString += " AND CAR.SERIESMODELRF = @SERIESMODELRF";
                        ((SqlParameter)sqlCmd.Parameters.Add("@SERIESMODELRF", SqlDbType.NChar)).Value = SqlDataMediator.SqlSetString(carModelCondWork.SeriesModel);
                    }
                }

                // �ޕʋL��
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
                //�uORDER BY�v�ݒ�
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

                // SQL�̎��s
                myReader = sqlCmd.ExecuteReader();

                // ���q�^���i�[����
                SetCarModelRetWork(myReader, carModelRetList);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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

        # region --- �^�������������v���[�g������ ---
        /// <summary>
        /// �v���[�g��������
        /// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
        /// <returns>DB Status</returns>
        public int GetCarPlateSearch(CarModelCondWork carModelCondWork, out ArrayList carModelRetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            carModelRetList = null;

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_OfferDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                    return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = GetCarPlateSearch(carModelCondWork, out carModelRetList, sqlConnection, null);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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
        /// �v���[�g��������
        /// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
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
                //�擾����
                string sqlText = CARMODELRFSelectFields;
                string whereString = string.Empty;
                SqlCommand sqlCmd = new SqlCommand();

                //�A���w��
                sqlText += " FROM PLATEMDLLNKRF AS PLA INNER JOIN CARMODELRF AS CAR ON PLA.CARPROPERNORF = CAR.CARPROPERNORF";
                sqlText += " INNER JOIN MAKERNAMERF ON CAR.MAKERCODERF = MAKERNAMERF.MAKERCODERF ";
                sqlText += " INNER JOIN MODELNAMERF ON CAR.MAKERCODERF = MODELNAMERF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMERF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMERF.MODELSUBCODERF";
                sqlText += " LEFT JOIN ADDICARSPECTTLRF AS ADI ON ADI.MAKERCODERF = CAR.MAKERCODERF AND ADI.MODELCODERF = CAR.MODELCODERF AND ADI.MODELSUBCODERF = CAR.MODELSUBCODERF ";

                //���o����
                whereString += " WHERE";

                //���f���v���[�g�ԍ�
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
                //�uORDER BY�v�ݒ�
                sqlText += CARMODELRFOrderByFields;

                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = sqlText;
                sqlCmd.Transaction = sqlTransaction;

                // SQL�̎��s
                myReader = sqlCmd.ExecuteReader();

                // ���q�^���i�[����
                SetCarModelRetWork(myReader, carModelRetList);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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

        # region --- �^�������������G���W���^�������� ---
        /// <summary>
        /// �G���W���^����������
        /// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
        /// <returns>DB Status</returns>
        public int GetCarEngineSearch(CarModelCondWork carModelCondWork, out ArrayList carModelRetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            carModelRetList = null;

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_OfferDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                    return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = GetCarEngineSearch(carModelCondWork, out carModelRetList, sqlConnection, null);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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
        /// �G���W���^����������
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
                //�擾����
                string sqlText = CARMODELRFSelectFields;
                SqlCommand sqlCmd = new SqlCommand();

                //�A���w��
                //sqlText += " FROM CARMODELINDEXRF AS IDX INNER JOIN CARMODELRF AS CAR ON IDX.CARPROPERNORF = CAR.CARPROPERNORF";
                sqlText += " FROM CARMODELRF AS CAR";
                sqlText += " INNER JOIN MAKERNAMERF ON CAR.MAKERCODERF = MAKERNAMERF.MAKERCODERF ";
                sqlText += " INNER JOIN MODELNAMERF ON CAR.MAKERCODERF = MODELNAMERF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMERF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMERF.MODELSUBCODERF";
                sqlText += " LEFT JOIN ADDICARSPECTTLRF AS ADI ON ADI.MAKERCODERF = CAR.MAKERCODERF AND ADI.MODELCODERF = CAR.MODELCODERF AND ADI.MODELSUBCODERF = CAR.MODELSUBCODERF";

                //���o����
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

                // SQL�̎��s
                myReader = sqlCmd.ExecuteReader();

                // ���q�^���i�[����
                SetCarModelRetWork(myReader, carModelRetList);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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

        #region --- �^�������������t���^���Œ�ԍ������� ---
        /// <summary>
        /// �^����������
        /// </summary>
        /// <param name="carModelCondWork">��������</param>
        /// <param name="kindList">�Ԏ���</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
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
                //�擾����
                string sqlText = CarKindSelectFields;
                string whereString = string.Empty;
                SqlCommand sqlCmd = new SqlCommand();

                //�A���w��
                sqlText += " FROM CARMODELRF AS CAR ";
                sqlText += " INNER JOIN MAKERNAMERF ON CAR.MAKERCODERF = MAKERNAMERF.MAKERCODERF ";
                sqlText += " INNER JOIN MODELNAMERF ON CAR.MAKERCODERF = MODELNAMERF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMERF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMERF.MODELSUBCODERF ";

                //���o����
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
                // �t���^���Œ�ԍ����O�ɑΉ�����ׁA������ǉ��B

                //���o����
                // �r�K�X�K�����ʋL��
                if ( carModelCondWork.ExhaustGasSign != string.Empty )
                {
                    whereString += " AND CAR.EXHAUSTGASSIGNRF = @EXHAUSTGASSIGNRF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@EXHAUSTGASSIGNRF", SqlDbType.NChar )).Value = SqlDataMediator.SqlSetString( carModelCondWork.ExhaustGasSign );
                }

                // �V���[�Y�^��
                if ( carModelCondWork.SeriesModel != string.Empty )
                {
                    if ( carModelCondWork.CategorySignModel == string.Empty )
                    {
                        // �ޕʋL�������͂���Ă��Ȃ���Ό����v
                        whereString += " AND CAR.SERIESMODELRF LIKE @SERIESMODELRF";
                        ((SqlParameter)sqlCmd.Parameters.Add( "@SERIESMODELRF", SqlDbType.NChar )).Value = SqlDataMediator.SqlSetString( carModelCondWork.SeriesModel + '%' );
                    }
                    else
                    {
                        // �ޕʋL�������͂���Ă���ꍇ�͊��S��v
                        whereString += " AND CAR.SERIESMODELRF = @SERIESMODELRF";
                        ((SqlParameter)sqlCmd.Parameters.Add( "@SERIESMODELRF", SqlDbType.NChar )).Value = SqlDataMediator.SqlSetString( carModelCondWork.SeriesModel );
                    }
                }

                // �ޕʋL��
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

                //�uORDER BY�v�ݒ�
                sqlText += CARMODELRFOrderByFields;

                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = sqlText;
                sqlCmd.Transaction = sqlTransanction;

                // SQL�̎��s
                myReader = sqlCmd.ExecuteReader();

                // �Ԏ���i�[����
                SetCarKindInfoWork(myReader, kindList);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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
                //�擾����
                string sqlText = CARMODELRFSelectFields;
                string whereString = string.Empty;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/13 ADD
                SqlCommand sqlCmd = new SqlCommand();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/13 ADD

                //�A���w��
                sqlText += " FROM CARMODELRF AS CAR ";
                sqlText += " INNER JOIN MAKERNAMERF ON CAR.MAKERCODERF = MAKERNAMERF.MAKERCODERF ";
                sqlText += " INNER JOIN MODELNAMERF ON CAR.MAKERCODERF = MODELNAMERF.MAKERCODERF AND CAR.MODELCODERF = MODELNAMERF.MODELCODERF AND CAR.MODELSUBCODERF = MODELNAMERF.MODELSUBCODERF";
                sqlText += " LEFT JOIN ADDICARSPECTTLRF AS ADI ON ADI.MAKERCODERF = CAR.MAKERCODERF AND ADI.MODELCODERF = CAR.MODELCODERF AND ADI.MODELSUBCODERF = CAR.MODELSUBCODERF ";

                //���o����
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
                // �t���^���Œ�ԍ����O�ɑΉ�����ׁA������ǉ��B

                //���o����
                // �r�K�X�K�����ʋL��
                if ( carModelCondWork.ExhaustGasSign != string.Empty )
                {
                    whereString += " AND CAR.EXHAUSTGASSIGNRF = @EXHAUSTGASSIGNRF";
                    ((SqlParameter)sqlCmd.Parameters.Add( "@EXHAUSTGASSIGNRF", SqlDbType.NChar )).Value = SqlDataMediator.SqlSetString( carModelCondWork.ExhaustGasSign );
                }

                // �V���[�Y�^��
                if ( carModelCondWork.SeriesModel != string.Empty )
                {
                    if ( carModelCondWork.CategorySignModel == string.Empty )
                    {
                        // �ޕʋL�������͂���Ă��Ȃ���Ό����v
                        whereString += " AND CAR.SERIESMODELRF LIKE @SERIESMODELRF";
                        ((SqlParameter)sqlCmd.Parameters.Add( "@SERIESMODELRF", SqlDbType.NChar )).Value = SqlDataMediator.SqlSetString( carModelCondWork.SeriesModel + '%' );
                    }
                    else
                    {
                        // �ޕʋL�������͂���Ă���ꍇ�͊��S��v
                        whereString += " AND CAR.SERIESMODELRF = @SERIESMODELRF";
                        ((SqlParameter)sqlCmd.Parameters.Add( "@SERIESMODELRF", SqlDbType.NChar )).Value = SqlDataMediator.SqlSetString( carModelCondWork.SeriesModel );
                    }
                }

                // �ޕʋL��
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

                //�uORDER BY�v�ݒ�
                sqlText += CARMODELRFOrderByFields;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/13 UPD
                //SqlCommand sqlCmd = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandText = sqlText;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Transaction = sqlTransaction;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/13 UPD

                // SQL�̎��s
                myReader = sqlCmd.ExecuteReader();

                // ���q�^���i�[����
                SetCarModelRetWork(myReader, carModelRetList);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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
            // MLHARGAY34*�ɑ΂���MLHARGAY34TDA---A-*����͂��Ă������\�ɂ��邽�߂�
            // �ꕶ�������Ȃ��炻�������v���[�g�����邩�m�F����B
            for (ind = strLen; ind > 0; ind--)
            {
                sqlText = sqlStr + modelPlate.Substring(0, ind) + "%'";
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlText;

                if (sqlCommand.ExecuteScalar().Equals(0) == false)
                    break;
            }
            // MLHARGAY34*�ɑ΂���MLHARGAY34*����͂��Ė���āA�҂������v����ꍇ��
            // ���̃v���[�g�̂݌�������l�Ƀt���O�ɃZ�b�g����B
            sqlText = "SELECT COUNT(MODELPLATERF) FROM PLATEMDLLNKRF WHERE MODELPLATERF = '" + modelPlate.Substring(0, ind) + '\'';
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlText;
            if (sqlCommand.ExecuteScalar().Equals(0) == false)
                isFitPlate = true;
            return ind;
        }

        # region --- �i�[���� ---
        # region --- ���q�^���i�[���� ---
        /// <summary>
        /// ���q�^���i�[����
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
                #region // DEL 2013/02/12 22013 �v��@�d�|�ꗗ�Ή� No.854
                //wkCarModelRetWork.StProduceTypeOfYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STPRODUCETYPEOFYEARRF"));
                //wkCarModelRetWork.EdProduceTypeOfYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDPRODUCETYPEOFYEARRF"));
                #endregion
                // ADD 2013/02/12 22013 �v��@�d�|�ꗗ�Ή� No.854 *-------------------->>>
                // ���Y�N���iSTPRODUCETYPEOFYEARRF�j��NS����ԗ��̔̔��N�����ݒ肳��Ă��邪�A
                // PM7�Ŏg�p���Ă������Y�N���ƈقȂ邽�߁APM7-NS�œ��삪�قȂ�B
                // �ԗ��╔�i�̌����ɉe�����o�Ă��邽��PM7���̕ʍ��ڂ�p�ӂ��Ďg�p����B
                wkCarModelRetWork.StProduceTypeOfYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PTSTPRDCTYPEYRF"));
                wkCarModelRetWork.EdProduceTypeOfYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PTEDPRDCTYPEYRF"));
                // ADD 2013/02/12 22013 �v��@�d�|�ꗗ�Ή� No.854 <<<--------------------*

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

                partsDataOfferFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSDATAOFFERFLAGRF"));  // ���i�f�[�^�񋟃t���O
                partsDtOfrFlgPrmJoin = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("PARTSDTOFRFLGPRMJOINRF"));  // ���i�f�[�^�񋟃t���O�i�D�ǌ����A�g���i�j

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
                //���Y�O�ԋ敪���O�ԂŁA�ԑ�ԍ��J�n��0�ȊO�̏ꍇ�ɂ�
                //���Y�O�ԋ敪�����Y�Ƃ��ĕ␳����
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

        # region --- �Ԏ���i�[���� ---
        /// <summary>
        /// �Ԏ���i�[����
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
        /// �Ԏ���i�[�������G���W��������p��
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
