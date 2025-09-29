//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���׍��ٕ\DB�����[�g�I�u�W�F�N�g
// �v���O�����T�v   : ���׍��ٕ\���f�[�^������s���N���X�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570136-00  �쐬�S�� : 杍^
// �� �� ��  K2019/08/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
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
    /// ���׍��ٕ\ �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���׍��ٕ\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : K2019/08/14</br>
    /// </remarks>
    [Serializable]
    public class ArrGoodsDiffResultDB : RemoteDB, IArrGoodsDiffResultDB
    {
       #region [�N���X�R���X�g���N�^]
       /// <summary>
       /// ���׍��ٕ\�R���X�g���N�^
       /// </summary>
       /// <remarks>
       /// <br>Note       : �Ȃ�</br>
       /// <br>Programmer : 杍^</br>
       /// <br>Date       : K2019/08/14</br>
       /// </remarks>
       public ArrGoodsDiffResultDB()
           : base("PMKOU02358D", "Broadleaf.Application.Remoting.ParamData.ArrGoodsDiffResultWork", "ArrGoodsDiffResult")
       {

       }
       #endregion

       #region [Search]

       /// <summary>
       /// �w�肳�ꂽ�����̓��׍��ٕ\���LIST��߂��܂�
       /// </summary>
       /// <param name="arrGoodsDiffResultWork">��������</param>
       /// <param name="arrGoodsDiffCndtnWork">�����p�����[�^</param>
       /// <returns>STATUS</returns>
       /// <remarks>
       /// <br>Note       : �w�肳�ꂽ�����̓��׍��ٕ\���LIST��߂��܂�</br>
       /// <br>Programmer : 杍^</br>
       /// <br>Date       : K2019/08/14</br>
       /// </remarks>
        public int Search(out object arrGoodsDiffResultWork, object arrGoodsDiffCndtnWork)
       {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            arrGoodsDiffResultWork = new ArrayList();
            try
            {
                //�R���N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // �������s��
                status = SearchProc(out arrGoodsDiffResultWork, arrGoodsDiffCndtnWork, ref sqlConnection);
                
            }
            catch (SqlException exSql)
            {
                base.WriteErrorLog(exSql, "ArrGoodsDiffResultDB.Search");
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ArrGoodsDiffResultDB.Search");
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

       #region [SearchProc -- Search���C������]
       /// <summary>
       /// �w�肳�ꂽ�����̓��׍��ٕ\���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
       /// </summary>
       /// <param name="retList">�������ʌ����p�����[�^</param>
       /// <param name="paraObj">�����p�����[�^</param>
       /// <param name="sqlConnection">sqlConnection</param>
       /// <returns>STATUS</returns>
       /// <remarks>
       /// <br>Note       : �w�肳�ꂽ�����̓��׍��ٕ\���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)</br>
       /// <br>Programmer : 杍^</br>
       /// <br>Date       : K2019/08/14</br>
       /// </remarks>
       private int SearchProc(out object retList, object paraObj, ref SqlConnection sqlConnection)
       {

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrGoodsDiffCndtnWork paraWork = null;
            paraWork = paraObj as ArrGoodsDiffCndtnWork;

            retList = new ArrayList();
            ArrayList al = new ArrayList();
            ArrGoodsDiffResultWork resultWork = new ArrGoodsDiffResultWork();

            // SQL
            StringBuilder sqlString = new StringBuilder(string.Empty);
            
            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                sqlCommand.CommandTimeout = 600;

                # region SQL��
                sqlString.AppendLine("SELECT");
                sqlString.AppendLine("	 UOE.UOESUPPLIERCDRF");
                sqlString.AppendLine("	,UOS.UOESUPPLIERNAMERF");
                sqlString.AppendLine("	,STD.SUPPLIERSLIPNORF");
                sqlString.AppendLine("	,STD.GOODSNORF");
                sqlString.AppendLine("	,STD.GOODSNAMERF");
                sqlString.AppendLine("	,STD.GOODSMAKERCDRF");
                sqlString.AppendLine("	,MAK.MAKERNAMERF");
                sqlString.AppendLine("	,UOE.ACCEPTANORDERCNTRF");
                sqlString.AppendLine("	,UOE.ACCEPTANORDERCNTRF-STDUOE.ORDERCNTRF AS ORDERREMAINCNTRF");
                sqlString.AppendLine("	,INP.INSPECTCNTRF");
                sqlString.AppendLine("	,STD.WAREHOUSECODERF");
                sqlString.AppendLine("	,WAR.WAREHOUSENAMERF");
                sqlString.AppendLine("	,STS.STOCKAGENTCODERF"); 
                sqlString.AppendLine("	,EMP.NAMERF");
                sqlString.AppendLine("FROM");
                sqlString.AppendLine("	STOCKDETAILRF AS STD WITH (READUNCOMMITTED) ");
                sqlString.AppendLine("	INNER JOIN STOCKSLIPRF AS STS WITH (READUNCOMMITTED) ");
                sqlString.AppendLine("	ON STS.ENTERPRISECODERF=STD.ENTERPRISECODERF ");
                sqlString.AppendLine("	AND STS.SUPPLIERFORMALRF=STD.SUPPLIERFORMALRF ");
                sqlString.AppendLine("	AND STS.SUPPLIERSLIPNORF=STD.SUPPLIERSLIPNORF ");
                sqlString.AppendLine("	AND STS.LOGICALDELETECODERF=STD.LOGICALDELETECODERF ");

                //�d�����׃f�[�^(����)
                sqlString.AppendLine("	INNER JOIN STOCKDETAILRF AS STDUOE WITH (READUNCOMMITTED) ");
                sqlString.AppendLine("	ON STD.ENTERPRISECODERF = STDUOE.ENTERPRISECODERF ");
                sqlString.AppendLine("	AND STD.SUPPLIERFORMALSRCRF = STDUOE.SUPPLIERFORMALRF ");
                sqlString.AppendLine("	AND STD.STOCKSLIPDTLNUMSRCRF = STDUOE.STOCKSLIPDTLNUMRF ");
                sqlString.AppendLine("	AND STD.LOGICALDELETECODERF = STDUOE.LOGICALDELETECODERF ");
                 
                //UOE�����f�[�^
                sqlString.AppendLine("	INNER JOIN UOEORDERDTLRF AS UOE WITH (READUNCOMMITTED) ");
                sqlString.AppendLine("	ON STDUOE.ENTERPRISECODERF=UOE.ENTERPRISECODERF ");
                sqlString.AppendLine("	AND STDUOE.COMMONSEQNORF=UOE.COMMONSEQNORF ");
                sqlString.AppendLine("	AND STDUOE.LOGICALDELETECODERF = UOE.LOGICALDELETECODERF ");
                sqlString.AppendLine("	AND UOE.UOEKINDRF =0 ");

                //���i�f�[�^
                sqlString.AppendLine("	INNER JOIN INSPECTDATARF AS INP WITH (READUNCOMMITTED) ");
                sqlString.AppendLine("	ON STD.ENTERPRISECODERF = INP.ENTERPRISECODERF ");
                sqlString.AppendLine("	AND STD.SUPPLIERSLIPNORF = INP.ACPAYSLIPNUMRF ");
                sqlString.AppendLine("	AND STD.STOCKROWNORF = INP.ACPAYSLIPROWNORF ");
                sqlString.AppendLine("	AND STD.LOGICALDELETECODERF = INP.LOGICALDELETECODERF ");
                sqlString.AppendLine("	AND INP.ACPAYSLIPCDRF =10 ");

                //���[�J�[�}�X�^
                sqlString.AppendLine("	LEFT JOIN MAKERURF AS MAK WITH (READUNCOMMITTED) ");
                sqlString.AppendLine("	ON MAK.ENTERPRISECODERF = STD.ENTERPRISECODERF ");
                sqlString.AppendLine("	AND MAK.GOODSMAKERCDRF = STD.GOODSMAKERCDRF ");
                sqlString.AppendLine("	AND MAK.LOGICALDELETECODERF = STD.LOGICALDELETECODERF ");

                //�q�Ƀ}�X�^
                sqlString.AppendLine("	LEFT JOIN WAREHOUSERF AS WAR WITH (READUNCOMMITTED) ");
                sqlString.AppendLine("	ON WAR.ENTERPRISECODERF = STD.ENTERPRISECODERF ");
                sqlString.AppendLine("	AND WAR.WAREHOUSECODERF = STD.WAREHOUSECODERF ");
                sqlString.AppendLine("	AND WAR.LOGICALDELETECODERF = STD.LOGICALDELETECODERF ");

                //�]�ƈ��}�X�^
                sqlString.AppendLine("	LEFT JOIN EMPLOYEERF AS EMP WITH (READUNCOMMITTED) ");
                sqlString.AppendLine("	ON EMP.ENTERPRISECODERF = STS.ENTERPRISECODERF ");
                sqlString.AppendLine("	AND EMP.EMPLOYEECODERF = STS.STOCKAGENTCODERF ");
                sqlString.AppendLine("	AND EMP.LOGICALDELETECODERF = STS.LOGICALDELETECODERF ");


                //UOE������}�X�^
                sqlString.AppendLine("	LEFT JOIN UOESUPPLIERRF AS UOS WITH (READUNCOMMITTED) ");
                sqlString.AppendLine("	ON UOS.ENTERPRISECODERF = UOE.ENTERPRISECODERF ");
                sqlString.AppendLine("	AND UOS.UOESUPPLIERCDRF = UOE.UOESUPPLIERCDRF ");
                sqlString.AppendLine("	AND UOS.LOGICALDELETECODERF = UOE.LOGICALDELETECODERF ");
                sqlString.AppendLine("	AND UOS.SECTIONCODERF = @FINDSECTIONCODE ");

                sqlString.AppendLine("WHERE");
                sqlString.AppendLine("	STS.ENTERPRISECODERF = @FINDENTERPRISECODE");
                sqlString.AppendLine("	AND STS.LOGICALDELETECODERF = 0");
                sqlString.AppendLine("	AND STS.SUPPLIERFORMALRF = 0");

                //���i��
                sqlString.AppendLine("	AND INP.INSPECTDATETIMERF >= @FINDINSPECTDATETIMEST");
                sqlString.AppendLine("	AND INP.INSPECTDATETIMERF < @FINDINSPECTDATETIMEED");

                // ������R�[�h�w�肵���ꍇ
                if(paraWork.UOESupplierCd != 0)
                {
                    sqlString.AppendLine("	AND UOE.UOESUPPLIERCDRF = @FINDUOESUPPLIERCD");
                }
                
                sqlString.AppendLine("ORDER BY");
                sqlString.AppendLine("	UOE.UOESUPPLIERCDRF,STD.SUPPLIERSLIPNORF,STD.GOODSNORF ASC");
                sqlCommand.CommandText = sqlString.ToString();
                # endregion SQL��

                # region Parameter�I�u�W�F�N�g�쐬�E�l�i�[

                //���_�R�[�h
                SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                findSectionCode.Value = SqlDataMediator.SqlSetString(paraWork.LoginSectionCode);

                //��ƃR�[�h
                SqlParameter findEnterpriseCode  = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWork.EnterpriseCode);

                //���i��
                SqlParameter findInspectDateTimeSt = sqlCommand.Parameters.Add("@FINDINSPECTDATETIMEST", SqlDbType.BigInt);
                findInspectDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paraWork.InspectDate);

                SqlParameter findInspectDateTimeEd = sqlCommand.Parameters.Add("@FINDINSPECTDATETIMEED", SqlDbType.BigInt);
                findInspectDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paraWork.InspectDate.AddDays(1));

                //������
                if (paraWork.UOESupplierCd != 0)
                {
                    SqlParameter findSupplierCd = sqlCommand.Parameters.Add("@FINDUOESUPPLIERCD", SqlDbType.Int);
                    findSupplierCd.Value = SqlDataMediator.SqlSetInt(paraWork.UOESupplierCd);
                }
                # endregion Parameter�I�u�W�F�N�g�쐬�E�l�i�[

                // �N�G�����s
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    // �������ʊi�[
                    resultWork = CopyToArrGoodsDiffResultWorkFromReader(ref myReader);
                    if (resultWork.DiffCnt == 0) continue;
                    al.Add(resultWork);
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
                status = base.WriteSQLErrorLog(sqlex, "ArrGoodsDiffResultDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "ArrGoodsDiffResultDB.SearchProc" + status);
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

       #region [�N���X�i�[����]
       /// <summary>
       /// �N���X�i�[���� Reader �� ArrGoodsDiffResultWork
       /// </summary>
       /// <param name="myReader">SqlDataReader</param>
       /// <returns>Result</returns>
       /// <remarks>
       /// <br>Note       : Reader����ArrGoodsDiffResultWork�֕ϊ����܂��B</br>
       /// <br>Programmer : 杍^</br>
       /// <br>Date       : K2019/08/14</br>
       /// </remarks>
        private ArrGoodsDiffResultWork CopyToArrGoodsDiffResultWorkFromReader(ref SqlDataReader myReader)
       {
           ArrGoodsDiffResultWork listWork = new ArrGoodsDiffResultWork();

           // ������R�[�h
           listWork.UOESupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESUPPLIERCDRF"));

           // �����於
           listWork.UOESupplierName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESUPPLIERNAMERF"));

           // �`�[�ԍ�
           listWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));

           // �i��
           listWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));

           // �i��
           listWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));

           // ���[�J�[�R�[�h
           listWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));

           // ���[�J�[��
           listWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));

           // ������
           listWork.OrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACCEPTANORDERCNTRF"));

           // �����c
           listWork.OrderRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERREMAINCNTRF"));

           // ���i��
           listWork.InspectCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INSPECTCNTRF"));

           // ���ِ�
           listWork.DiffCnt = listWork.OrderCnt - listWork.OrderRemainCnt - listWork.InspectCnt;

           // �q�ɃR�[�h
           listWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));

           // �q�ɖ�
           listWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));

           // �����҃R�[�h
           listWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));

           // �����Җ�
           listWork.EmployeeName= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));

           return listWork;

       }
       #endregion  �N���X�i�[����

       #region [�R�l�N�V������������]
       /// <summary>
       /// SqlConnection��������
       /// </summary>
       /// <returns>SqlConnection</returns>
       /// <remarks>
       /// <br>Programmer : 杍^</br>
       /// <br>Date       : K2019/08/14</br>
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
