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
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �D�ǐݒ�}�X�^���������[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �D�ǐݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.13</br>
    /// <br></br>
    /// <br>Update Note: 2015/02/23  �L��</br>
    /// <br>           : SCM������ C������ʓ��L�Ή�</br>
    /// </remarks>
    [Serializable]
    public class PrimeSettingDB : RemoteDB, IPrimeSettingDB
    {

        /// <summary>
        /// �D�ǐݒ�}�X�^���������[�g�I�u�W�F�N�g�R���X�g���N�^
        /// </summary>
        public PrimeSettingDB()
            :
        base("PMTKD09023D", "Broadleaf.Application.Remoting.ParamData.PrmSettingWork", "PRMSETTINGRF")
        {
        }

        /// <summary>
        /// �D�ǐݒ��S�Ė߂��܂�:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="primeSettingWork"></param>
        /// <returns></returns>
        public int Search(out object primeSettingWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            primeSettingWork = null;
            try
            {
                ArrayList _primeSettingWork = null;
                status = SearchProc(out _primeSettingWork);

                primeSettingWork = _primeSettingWork;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimeSettingDB.Search Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// Search������
        /// </summary>
        /// <param name="primeSettingWork"></param>
        /// <returns>�X�e�[�^�X</returns>
        private int SearchProc(out ArrayList primeSettingWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;

            primeSettingWork = null;
            ArrayList retlist = new ArrayList();	//���ʃN���X�i�[�pArrayList
            try
            {
                //�R�l�N�V����������擾�Ή�����������
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_OfferDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                    return 99;
                //�R�l�N�V����������擾�Ή�����������

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                SqlCommand sqlCommand;
                string sqlText = "SELECT OFFERDATERF, GOODSMGROUPRF, PARTSMAKERCDRF, TBSPARTSCODERF, TBSPARTSCDDERIVEDNORF, "
                    // UPD 2015/02/23 �L�� SCM������ C������ʓ��L�Ή� ---------->>>>>
                    //+ "SECRETCODERF, DISPLAYORDERRF, PRMSETDTLNO1RF, PRMSETDTLNAME1RF, PRMSETDTLNO2RF, PRMSETDTLNAME2RF, PRMSETGROUPRF FROM PRMSETTINGRF";
                    + "SECRETCODERF, DISPLAYORDERRF, PRMSETDTLNO1RF, PRMSETDTLNAME1RF, PRMSETDTLNO2RF, PRMSETDTLNAME2RF, PRMSETGROUPRF,"
                    + "PRMSETDTLNAME2FORFACRF, PRMSETDTLNAME2FORCOWRF"
                    + " FROM PRMSETTINGRF";
                    // UPD 2015/02/23 �L�� SCM������ C������ʓ��L�Ή� ----------<<<<<
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {

                    //�D�ǐݒ茋�ʃN���X
                    PrmSettingWork wkPrimeSettingWork = new PrmSettingWork();

                    #region ���ʃN���X�֊i�[
                    wkPrimeSettingWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    wkPrimeSettingWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    wkPrimeSettingWork.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    wkPrimeSettingWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    wkPrimeSettingWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    wkPrimeSettingWork.SecretCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECRETCODERF"));
                    wkPrimeSettingWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                    wkPrimeSettingWork.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));
                    wkPrimeSettingWork.PrmSetDtlName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME1RF"));
                    wkPrimeSettingWork.PrmSetDtlNo2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO2RF"));
                    wkPrimeSettingWork.PrmSetDtlName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2RF"));
                    wkPrimeSettingWork.PrmSetGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETGROUPRF"));
                    // ADD 2015/02/23 �L�� SCM������ C������ʓ��L�Ή� ---------->>>>>
                    wkPrimeSettingWork.PrmSetDtlName2ForFac = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2FORFACRF"));
                    wkPrimeSettingWork.PrmSetDtlName2ForCOw = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2FORCOWRF"));
                    // ADD 2015/02/23 �L�� SCM������ C������ʓ��L�Ή� ----------<<<<<
                    #endregion

                    retlist.Add(wkPrimeSettingWork);

                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimeSettingDB.SearchProc�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader.IsClosed == false) myReader.Close();
                sqlConnection.Close();
            }
            primeSettingWork = retlist;

            return status;
        }


        /// <summary>
        /// �D�ǐݒ��S�Ė߂��܂�:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="primeSettingNoteWork"></param>
        /// <returns></returns>
        public int SearchNote(out object primeSettingNoteWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            primeSettingNoteWork = null;
            try
            {
                ArrayList _primeSettingNoteWork = null;
                status = SearchNoteProc(out _primeSettingNoteWork);

                primeSettingNoteWork = _primeSettingNoteWork;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimeSettingDB.Search Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }


        /// <summary>
        /// Search������
        /// </summary>
        /// <param name="primeSettingNoteWork"></param>
        /// <returns>�X�e�[�^�X</returns>
        private int SearchNoteProc(out ArrayList primeSettingNoteWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;

            primeSettingNoteWork = null;
            ArrayList retlist = new ArrayList();	//���ʃN���X�i�[�pArrayList
            try
            {
                //�R�l�N�V����������擾�Ή�����������
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_OfferDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (connectionText == null || connectionText == "") return status;
                //�R�l�N�V����������擾�Ή�����������

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                SqlCommand sqlCommand;
                string sqlText =
                    "SELECT OFFERDATERF, GOODSMGROUPRF, PARTSMAKERCDRF, TBSPARTSCODERF, TBSPARTSCDDERIVEDNORF, "
                    + "IMPORTANTNOTECDRF, PRMSETNOTERF "
                    + "FROM PRMSETNOTERF";
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {
                    //�D�ǐݒ茋�ʃN���X
                    PrmSetNoteWork wkPrimeSettingNoteWork = new PrmSetNoteWork();

                    #region ���ʃN���X�֊i�[
                    wkPrimeSettingNoteWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    wkPrimeSettingNoteWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    wkPrimeSettingNoteWork.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    wkPrimeSettingNoteWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    wkPrimeSettingNoteWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    wkPrimeSettingNoteWork.ImportantNoteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IMPORTANTNOTECDRF"));
                    wkPrimeSettingNoteWork.PrmSetNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETNOTERF"));
                    #endregion

                    retlist.Add(wkPrimeSettingNoteWork);
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimeSettingDB.SearchNoteProc�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader.IsClosed == false) myReader.Close();
                sqlConnection.Close();
            }
            primeSettingNoteWork = retlist;

            return status;
        }

        /// <summary>
        /// �D�ǐݒ�ύX�}�X�^
        /// </summary>
        /// <param name="PrimeSettingChgWork"></param>
        /// <returns>�X�e�[�^�X</returns>
        public int SearchChg(out object PrimeSettingChgWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            PrimeSettingChgWork = null;
            try
            {
                ArrayList _primeSettingChgWork = null;
                status = SerchChgProc(out _primeSettingChgWork);

                PrimeSettingChgWork = _primeSettingChgWork;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimeSettingDB.SearchChg Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// Search������
        /// </summary>
        /// <param name="primeSettingChgWork"></param>
        /// <returns>�X�e�[�^�X</returns>
        private int SerchChgProc(out ArrayList primeSettingChgWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;

            primeSettingChgWork = null;
            ArrayList retlist = new ArrayList();	//���ʃN���X�i�[�pArrayList
            try
            {
                //�R�l�N�V����������擾�Ή�����������
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_OfferDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                    return 99;
                //�R�l�N�V����������擾�Ή�����������

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                SqlCommand sqlCommand;
                string sqlText = "SELECT OFFERDATERF, GOODSMGROUPRF, PARTSMAKERCDRF, TBSPARTSCODERF, TBSPARTSCDDERIVEDNORF, "
                               + "PRMSETDTLNO1RF, PRMSETDTLNO2RF, AFPRMSETDTLNO1RF, AFPRMSETDTLNO2RF, AFPRIMEDISPLAYCODERF, PROCDIVCDRF FROM PRMSETTINGCHGRF";
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {

                    //�D�ǐݒ茋�ʃN���X
                    PrmSettingChgWork wkPrimeSettingchgWork = new PrmSettingChgWork();

                    #region ���ʃN���X�֊i�[
                    wkPrimeSettingchgWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    wkPrimeSettingchgWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    wkPrimeSettingchgWork.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    wkPrimeSettingchgWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    wkPrimeSettingchgWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    wkPrimeSettingchgWork.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));
                    wkPrimeSettingchgWork.PrmSetDtlNo2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO2RF"));
                    wkPrimeSettingchgWork.AfPrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AFPRMSETDTLNO1RF"));
                    wkPrimeSettingchgWork.AfPrmSetDtlNo2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AFPRMSETDTLNO2RF"));
                    wkPrimeSettingchgWork.AfPrimeDisplayCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AFPRIMEDISPLAYCODERF"));
                    wkPrimeSettingchgWork.ProcDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PROCDIVCDRF"));
                    #endregion

                    retlist.Add(wkPrimeSettingchgWork);

                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimeSettingDB.SearchChgProc�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader.IsClosed == false) myReader.Close();
                sqlConnection.Close();
            }
            primeSettingChgWork = retlist;

            return status;
        }
    }
}
