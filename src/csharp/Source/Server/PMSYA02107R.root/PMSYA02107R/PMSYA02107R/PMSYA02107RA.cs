//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����Ԍ��ԗ��ꗗ�\DB�����[�g�I�u�W�F�N�g
// �v���O�����T�v   : �����Ԍ��ԗ��ꗗ�\���f�[�^������s���N���X�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �L�Q
// �� �� ��  2010/04/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Data.SqlTypes;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Data;
using Broadleaf.Library.Resources;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����Ԍ��ԗ��ꗗ�\ �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����Ԍ��ԗ��ꗗ�\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : �L�Q</br>
    /// <br>Date       : 2010.04.21</br>
    /// </remarks>
    [Serializable]
    public class MonthCarInspectListResultDB : RemoteDB, IMonthCarInspectListResultDB
    {
       #region �N���X�R���X�g���N�^
        /// <summary>
        /// �����Ԍ��ԗ��ꗗ�\�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : �L�Q</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public MonthCarInspectListResultDB()
            : base("PMSYA02109D", "Broadleaf.Application.Remoting.ParamData.MonthCarInspectListResultWork", "MONTHCARINSPECTLISTRESULT")
        {

        }
        #endregion

       #region [Search]
        #region �w�肳�ꂽ�����̓����Ԍ��ԗ��ꗗ�\�ꗗ�\���LIST�̎擾����
        /// <summary>
        /// �w�肳�ꂽ�����̓����Ԍ��ԗ��ꗗ�\�ꗗ�\���LIST��߂��܂�
        /// </summary>
        /// <param name="monthCarInspectListResultWork">��������</param>
        /// <param name="monthCarInspectListParaWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̓����Ԍ��ԗ��ꗗ�\���LIST��߂��܂�</br>
        /// <br>Programmer : �L�Q</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public int Search(out object monthCarInspectListResultWork, object monthCarInspectListParaWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            monthCarInspectListResultWork = new ArrayList();
            try
            {
                //�R���N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // �������s��
                status = SearchProc(out monthCarInspectListResultWork, monthCarInspectListParaWork, ref sqlConnection);
                
            }
            catch (SqlException exSql)
            {
                base.WriteErrorLog(exSql, "MonthCarInspectListResultDB.Search");
                monthCarInspectListResultWork = new ArrayList();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MonthCarInspectListResultDB.Search");
                monthCarInspectListResultWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
        #endregion

        #region �w�肳�ꂽ�����̓����Ԍ��ԗ��ꗗ�\�ꗗ�\���LIST(�O�������SqlConnection���g�p)
        /// <summary>
        /// �w�肳�ꂽ�����̓����Ԍ��ԗ��ꗗ�\�ꗗ�\���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="retList">�������ʌ����p�����[�^</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̓����Ԍ��ԗ��ꗗ�\�ꗗ�\���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : �L�Q</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private int SearchProc(out object retList, object paraObj, ref SqlConnection sqlConnection)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            MonthCarInspectListParaWork paraWork = null;
            paraWork = paraObj as MonthCarInspectListParaWork;

            retList = new ArrayList();
            ArrayList al = new ArrayList();

            StringBuilder selectTxt = new StringBuilder(string.Empty);

            try
            {
                sqlCommand = new SqlCommand(String.Empty, sqlConnection);

                selectTxt.Append("SELECT ");
                selectTxt.Append("  A.CUSTOMERSNMRF, ");        // ���Ӑ旪��
                selectTxt.Append("  A.MNGSECTIONCODERF, ");     // �Ǘ����_�R�[�h
                selectTxt.Append("  B.ENTERPRISECODERF, ");     // ��ƃR�[�h
                selectTxt.Append("  B.LOGICALDELETECODERF, ");  // �_���폜�敪
                selectTxt.Append("  B.CUSTOMERCODERF, ");       // ���Ӑ�R�[�h
                selectTxt.Append("  B.CARMNGNORF, ");           // �ԗ��Ǘ��ԍ�
                selectTxt.Append("  B.CARMNGCODERF, ");         // ���q�Ǘ��R�[�h
                selectTxt.Append("  B.NUMBERPLATE1NAMERF, ");   // ���^�����ǖ���
                selectTxt.Append("  B.NUMBERPLATE2RF, ");       // �ԗ��o�^�ԍ��i��ʁj
                selectTxt.Append("  B.NUMBERPLATE3RF, ");       // �ԗ��o�^�ԍ��i�J�i�j
                selectTxt.Append("  B.NUMBERPLATE4RF, ");       // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                selectTxt.Append("  B.FIRSTENTRYDATERF, ");     // ���N�x
                selectTxt.Append("  B.MAKERCODERF, ");          // ���[�J�[�R�[�h
                selectTxt.Append("  B.MODELCODERF, ");          // �Ԏ�R�[�h
                selectTxt.Append("  B.MODELSUBCODERF, ");       // �Ԏ�T�u�R�[�h
                selectTxt.Append("  B.MODELHALFNAMERF, ");      // �Ԏ피�p����
                selectTxt.Append("  B.FULLMODELRF, ");          // �^���i�t���^�j
                selectTxt.Append("  B.FRAMENORF, ");            // �ԑ�ԍ�
                selectTxt.Append("  B.INSPECTMATURITYDATERF, ");// �Ԍ�������
                selectTxt.Append("  B.CARINSPECTYEARRF ");      // �Ԍ�����
                selectTxt.Append("FROM ");
                selectTxt.Append("  CUSTOMERRF A, ");           // ���Ӑ�}�X�^
                selectTxt.Append("  CARMANAGEMENTRF B ");       // ���q�Ǘ��}�X�^
                selectTxt.Append("WHERE ");
                selectTxt.Append("  A.CUSTOMERCODERF = B.CUSTOMERCODERF ");
                selectTxt.Append("  AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                // �_���폜�敪
                selectTxt.Append("  AND B.LOGICALDELETECODERF = 0 ");
                // ��ƃR�[�h
                selectTxt.Append("  AND B.ENTERPRISECODERF = @FINDENTERPRISECODE ");
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWork.EnterpriseCode);
                
                // �Ԍ�������
                if (paraWork.InspectMaturityDate != DateTime.MinValue)
                {
                    selectTxt.Append("  AND LEFT(B.INSPECTMATURITYDATERF, 6) = @FINDINSPECTMATURITYDATE ");
                    SqlParameter paraInspectMaturityDate = sqlCommand.Parameters.Add("@FINDINSPECTMATURITYDATE", SqlDbType.Int);
                    paraInspectMaturityDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paraWork.InspectMaturityDate);
                }

                // ���Ӑ�(�J�n)�����͂��ꂽ�ꍇ
                if (!String.IsNullOrEmpty(paraWork.StCustomerCode))
                {
                    selectTxt.Append("  AND B.CUSTOMERCODERF >= @FINDSTCUSTOMERCODE ");
                    SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@FINDSTCUSTOMERCODE", SqlDbType.Int);
                    paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.StCustomerCode));
                }
                // ���Ӑ�(�I��)�����͂��ꂽ�ꍇ
                if (!String.IsNullOrEmpty(paraWork.EdCustomerCode))
                {
                    selectTxt.Append("  AND B.CUSTOMERCODERF <= @FINDEDCUSTOMERCODE ");
                    SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@FINDEDCUSTOMERCODE", SqlDbType.Int);
                    paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.EdCustomerCode));
                }

                // ���_�R�[�h
                if (paraWork.MngSectionCode != null)
                {
                    string sectionString = "";
                    foreach (string sectionCode in paraWork.MngSectionCode)
                    {
                        if (!string.Empty.Equals(sectionCode))
                        {
                            if (!string.Empty.Equals(sectionString))
                            {
                                sectionString += ",";
                            }
                            sectionString += "'" + sectionCode + "'";
                        }
                    }
                    if (!string.Empty.Equals(sectionString))
                    {
                        // ���_�R�[�h
                        selectTxt.Append(" AND A.MNGSECTIONCODERF IN (" + sectionString + ")  ");

                    }
                }

                // ���q�Ǘ��R�[�h
                if (!string.IsNullOrEmpty(paraWork.StCarMngCode))
                {
                    selectTxt.Append(" AND B.CARMNGCODERF>=@FINDSTCARMNGCODE ");
                    SqlParameter paraStCarMngCode = sqlCommand.Parameters.Add("@FINDSTCARMNGCODE", SqlDbType.NChar);
                    paraStCarMngCode.Value = SqlDataMediator.SqlSetString(paraWork.StCarMngCode);
                }
                if (!string.IsNullOrEmpty(paraWork.EdCarMngCode))
                {
                    selectTxt.Append(" AND B.CARMNGCODERF<=@FINDEDCARMNGCODE ");
                    SqlParameter paraEdCarMngCode = sqlCommand.Parameters.Add("@FINDEDCARMNGCODE", SqlDbType.NChar);
                    paraEdCarMngCode.Value = SqlDataMediator.SqlSetString(paraWork.EdCarMngCode);
                }

                // ���Ӑ�
                selectTxt.Append("ORDER BY B.CUSTOMERCODERF, ");
                // �Ǘ��ԍ�
                selectTxt.Append("B.CARMNGNORF, B.CARMNGCODERF ");// Chg 2010.05.18 zhangsf FOR Redmine #7784

                sqlCommand.CommandText= selectTxt.ToString();
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    al.Add(CopyResultWorkFromReader(ref myReader, paraWork));
                }

                // �������ʂ�����ꍇ
                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "MonthCarInspectListResultDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "MonthCarInspectListResultDB.SearchProc" + status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                }
            }
            retList = al;
            return status;

        }

        
        #endregion


        #endregion

        #region �N���X�i�[���� Reader �� MonthCarInspectListResultWork
        /// <summary>
        /// �N���X�i�[���� Reader �� MonthCarInspectListResultWork
        /// </summary>
        /// <param name="paraWork">���������i�[�N���X</param>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// <br>Note       : Reader����MonthCarInspectListResultWork�֕ϊ����܂��B</br>
        /// <br>Programmer : �L�Q</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private MonthCarInspectListResultWork CopyResultWorkFromReader(ref SqlDataReader myReader, MonthCarInspectListParaWork paraWork)
        {
            MonthCarInspectListResultWork listWork = new MonthCarInspectListResultWork();
            #region �N���X�֊i�[
            // ���Ӑ旪��
            listWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            // �Ǘ����_�R�[�h
            listWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
            // ��ƃR�[�h
            listWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            // �_���폜�敪
            listWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            // ���Ӑ�R�[�h
            listWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            // �ԗ��Ǘ��ԍ�
            listWork.CarMngNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGNORF"));
            // ���q�Ǘ��R�[�h   
            listWork.CarMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMNGCODERF"));
            // ���^�����ǖ���
            listWork.NumberPlate1Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE1NAMERF"));
            // �ԗ��o�^�ԍ��i��ʁj
            listWork.NumberPlate2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE2RF"));
            // �ԗ��o�^�ԍ��i�J�i�j
            listWork.NumberPlate3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE3RF"));
            // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            listWork.NumberPlate4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE4RF"));
            // ���N�x
            listWork.FirstEntryDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF")).ToString();
            // ���[�J�[�R�[�h
            listWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
            // �Ԏ�R�[�h
            listWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));
            // �Ԏ�T�u�R�[�h
            listWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));
            // �Ԏ피�p����
            listWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));
            // �^���i�t���^�j
            listWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));
            // �ԑ�ԍ�
            listWork.FrameNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));
            // �Ԍ�������
            listWork.InspectMaturityDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INSPECTMATURITYDATERF"));
            // �Ԍ�����
            listWork.CarInspectYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARINSPECTYEARRF"));
            return listWork;
            #endregion
        }
        #endregion  �N���X�i�[���� Reader �� MonthCarInspectListResultWork

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : �L�Q</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
