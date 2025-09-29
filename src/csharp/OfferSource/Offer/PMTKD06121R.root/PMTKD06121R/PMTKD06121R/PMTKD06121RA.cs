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
    /// �񋟎��q��񌋍�����DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �񋟎��q��񌋍������̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class ColTrmEquInfDB : RemoteDB, IColTrmEquInfDB
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
        public ColTrmEquInfDB()
            :
        base("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.ColorCdRetWork", "COLORCDRF")
        {
        }
        # endregion

        /// <summary>
        /// �J���[�E�g�����E��������߂��܂�
        /// </summary>
        /// <param name="colorCdRetWork">��������</param>
        /// <param name="trimCdRetWork">�^���w��ԍ�</param>
        /// <param name="cEqpDefDspRetWork">�ޕʋ敪�ԍ�</param>
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
                //�擾���ꎞ�i�[�R���N�V��������
                ArrayList retArraycolorCdRetWork = new ArrayList();
                ArrayList retArraytrimCdRetWork = new ArrayList();
                ArrayList retArraycEqpDefDspRetWork = new ArrayList();

                ColTrmEquSearchCondWork _colTrmEquSearchCondWork = (ColTrmEquSearchCondWork)colTrmEquSearchCondWork;

                //���\�b�h�J�n���ɃR�l�N�V������������擾
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    base.WriteErrorLog("ColTrmEquInfDB.SearchCategoryEquipment�ɂăG���[���� ConnectionText���擾�o���܂���ł����B");
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }

                //SQL������
                SqlConnection sqlConnection = null;
                using (sqlConnection = new SqlConnection(connectionText))   // using�u���b�N���I����dispose�ɂ��ؒf����邽��
                {                                                           // Close���\�b�h��ʓr�Ăяo�����Ȃ��B
                    sqlConnection.Open();

                    //�J���[���擾
                    status = SearchColorCd(retArraycolorCdRetWork, _colTrmEquSearchCondWork, sqlConnection, null);
                    if ((retArraycolorCdRetWork.Count > 0) && (status == 0))
                    {
                        colorCdRetWork = (object)retArraycolorCdRetWork;
                    }

                    //�g�������擾
                    status = SearchTrimCd(retArraytrimCdRetWork, _colTrmEquSearchCondWork, sqlConnection, null);
                    if ((retArraytrimCdRetWork.Count > 0) && (status == 0))
                    {
                        trimCdRetWork = (object)retArraytrimCdRetWork;
                    }

                    //�������擾
                    status = SearchCEqpDefDsp(retArraycEqpDefDspRetWork, _colTrmEquSearchCondWork, sqlConnection, null);
                    if ((retArraycEqpDefDspRetWork.Count > 0) && (status == 0))
                    {
                        cEqpDefDspRetWork = (object)retArraycEqpDefDspRetWork;
                    }
                }
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "CategoryModelDesiguationDB.SearchCategoryEquipment�ɂ�SQL�G���[���� Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CategoryModelDesiguationDB.SearchCategoryEquipment�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        # region --- �J���[�����N���X�ɃZ�b�g ---
        /// <summary>
        /// �J���[�����N���X�ɃZ�b�g
        /// </summary>
        /// <param name="retArray">��������</param>
        /// <param name="colTrmEquSearchCondWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sql�ȸ��ݏ��</param>
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

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findMakerCode = sqlCommand.Parameters.Add("@FINDMAKERCODE", SqlDbType.Int);
                SqlParameter findModelCode = sqlCommand.Parameters.Add("@FINDMODELCODE", SqlDbType.Int);
                SqlParameter findModelSubCode = sqlCommand.Parameters.Add("@FINDMODELSUBCODE", SqlDbType.Int);
                //SqlParameter findSystematicCode = sqlCommand.Parameters.Add("@FINDSYSTEMATICCODE", SqlDbType.Int);
                //SqlParameter findProduceTypeOfYearCd = sqlCommand.Parameters.Add("@FINDPRODUCETYPEOFYEARCD", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֗ޕʁE�^���l�ݒ�
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
                    //���N���X�ɗ�O��n���ď������Ă��炤
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

        # region --- �J���[���ݒ� ---
        /// <summary>
        /// �J���[���ݒ�
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

        # region --- �g�������擾 ---
        /// <summary>
        /// �g�������擾
        /// </summary>
        /// <param name="retArray">��������</param>
        /// <param name="colTrmEquSearchCondWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sql�ȸ��ݏ��</param>
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
                    //�g��������
                    "SELECT "
                    + "TRIMCDRF.MAKERCODERF, "
                    + "TRIMCDRF.MODELCODERF, "
                    + "TRIMCDRF.MODELSUBCODERF, "
                    //+ "TRIMCDRF.SYSTEMATICCODERF, "
                    //+ "TRIMCDRF.PRODUCETYPEOFYEARCDRF, "
                    + "TRIMCDRF.TRIMCODERF, "
                    + "TRIMCDRF.TRIMNAMERF "

                    + "FROM TRIMCDRF "

                    //���o����
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
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findMakerCode = sqlCommand.Parameters.Add("@FINDMAKERCODE", SqlDbType.Int);
                SqlParameter findModelCode = sqlCommand.Parameters.Add("@FINDMODELCODE", SqlDbType.Int);
                SqlParameter findModelSubCode = sqlCommand.Parameters.Add("@FINDMODELSUBCODE", SqlDbType.Int);
                //SqlParameter findSystematicCode = sqlCommand.Parameters.Add("@FINDSYSTEMATICCODE", SqlDbType.Int);
                //SqlParameter findProduceTypeOfYearCd = sqlCommand.Parameters.Add("@FINDPRODUCETYPEOFYEARCD", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֗ޕʁE�^���l�ݒ�
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
                    //���N���X�ɗ�O��n���ď������Ă��炤
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

        # region --- �g���������N���X�ɃZ�b�g ---
        /// <summary>
        /// �g���������N���X�ɃZ�b�g
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

        # region --- �������擾 ---
        /// <summary>
        /// �������擾
        /// </summary>
        /// <param name="retArray">��������</param>
        /// <param name="colTrmEquSearchCondWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sql�ȸ��ݏ��</param>
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
                select = "SELECT "      //��������                    
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

                    //���o����
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
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findMakerCode = sqlCommand.Parameters.Add("@FINDMAKERCODE", SqlDbType.Int);
                SqlParameter findModelCode = sqlCommand.Parameters.Add("@FINDMODELCODE", SqlDbType.Int);
                SqlParameter findModelSubCode = sqlCommand.Parameters.Add("@FINDMODELSUBCODE", SqlDbType.Int);
                //SqlParameter findSystematicCode = sqlCommand.Parameters.Add("@FINDSYSTEMATICCODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֗ޕʁE�^���l�ݒ�
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
                    //���N���X�ɗ�O��n���ď������Ă��炤
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

        # region --- ���������N���X�ɃZ�b�g ---
        /// <summary>
        /// ���������N���X�ɃZ�b�g
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
