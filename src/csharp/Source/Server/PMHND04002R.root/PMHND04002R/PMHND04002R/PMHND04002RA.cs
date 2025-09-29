//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : ���i�Ώێ擾�����[�g�I�u�W�F�N�g
// �v���O�����T�v   : ���i�Ώێ擾���s���܂�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : ���R
// �� �� ��  2017/06/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

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
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i�Ώێ擾�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�Ώێ擾�����[�g�I�u�W�F�N�g�ł��B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2017/06/12</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// </remarks>
    [Serializable]
    public class HandyInspectDB : RemoteDB, IHandyInspectDB
    {
        #region [�R���X�g���N�^]
        /// <summary>
        /// ���i�Ώێ擾�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public HandyInspectDB()
        {
        }
        #endregion

        #region [Public Methods]
        /// <summary>
        /// ���i�Ώ�(�`�[�ԍ�)�擾����
        /// </summary>
        /// <param name="condByte">��������</param>
        /// <param name="retListObj">��������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���i�Ώ�(�`�[�ԍ�)�����������܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public int SearchSlipNum(byte[] condByte, out object retListObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            retListObj = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                // sqlConnection��null�̏ꍇ
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                HandyInspectCondWork condWork = (HandyInspectCondWork)XmlByteSerializer.Deserialize(condByte, typeof(HandyInspectCondWork));
                // condWork��null�̏ꍇ
                if (condWork == null)
                {
                    base.WriteErrorLog("HandyInspectDB.SearchSlipNum" + "�J�X�^���V���A���C�U���s");
                    return status;
                } 

                // ��񌟕i�敪���擾
                int orderInspectCode = 0;
                status = SearchOrderInspectCode(condWork, out orderInspectCode, ref sqlConnection);
                // �X�e�[�^�X������ł͂Ȃ��ꍇ
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    return status;
                }

                // �o�׃f�[�^�v��c�敪���擾
                int shipmAddUpRemDiv = -1;
                status = SearchShipmAddUpRemDiv(condWork, out shipmAddUpRemDiv, ref sqlConnection);
                // �X�e�[�^�X������ł͂Ȃ��ꍇ
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    return status;
                }

                ArrayList handyInspectWorkList = null;
                status = SearchProc(condWork, orderInspectCode, shipmAddUpRemDiv, out handyInspectWorkList, ref sqlConnection);
                // �X�e�[�^�X������̏ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retListObj = handyInspectWorkList as object;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyInspectDB.SearchSlipNum" + ex.Message, status);
            }
            finally
            {
                // sqlConnection��null�ł͂Ȃ��ꍇ
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// ���i�Ώ�(�ꊇ���i)�擾����
        /// </summary>
        /// <param name="condByte">��������</param>
        /// <param name="retListObj">��������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���i�Ώ�(�ꊇ���i)�����������܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public int SearchTotal(byte[] condByte, out object retListObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            retListObj = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                // sqlConnection��null�̏ꍇ
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                HandyInspectCondWork condWork = (HandyInspectCondWork)XmlByteSerializer.Deserialize(condByte, typeof(HandyInspectCondWork));
                // condWork��null�̏ꍇ
                if (condWork == null)
                {
                    base.WriteErrorLog("HandyInspectDB.SearchTotal" + "�J�X�^���V���A���C�U���s");
                    return status;
                } 

                ArrayList handyInspectWorkList = null;
                // ���i�Ώ�(�ꊇ���i)�̏ꍇ�A���i�S�̐ݒ�}�X�^.��񌟕i�敪���u0�F���Ȃ��v���Œ�ŃZ�b�g����B
                // ���i�Ώ�(�ꊇ���i)�̏ꍇ�A����S�̐ݒ�}�X�^.�o�׃f�[�^�v��c�敪���g�p���Ȃ��A�u0:�c���v���Œ�ŃZ�b�g����B
                status = SearchProc(condWork, 0, 0, out handyInspectWorkList, ref sqlConnection);
                // �X�e�[�^�X������̏ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retListObj = handyInspectWorkList as object;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyInspectDB.SearchTotal" + ex.Message, status);
            }
            finally
            {
                // sqlConnection��null�ł͂Ȃ��ꍇ
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [Private Methods]
        /// <summary>
        /// �w�肳�ꂽ�����̎�񌟕i�敪��߂��܂�
        /// </summary>
        /// <param name="condWork">��������</param>
        /// <param name="orderInspectCode">��񌟕i�敪</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̎�񌟕i�敪��߂��܂�</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private int SearchOrderInspectCode(HandyInspectCondWork condWork, out int orderInspectCode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            orderInspectCode = -1;

            try
            {
                // SQL���𐶐�
                StringBuilder sb = new StringBuilder();

                # region SELECT�吶��
                sb.AppendLine("SELECT TOP 1 A.ORDERINSPECTCODERF FROM (");
                sb.AppendLine("SELECT");
                sb.AppendLine(" I.ORDERINSPECTCODERF,");
                sb.AppendLine(" 0 ORDERRF ");
                sb.AppendLine("FROM");
                sb.AppendLine(" EMPLOYEERF E WITH (READUNCOMMITTED)");
                sb.AppendLine(" INNER JOIN INSPECTTTLSTRF I WITH (READUNCOMMITTED) ");
                sb.AppendLine("ON");
                sb.AppendLine(" E.ENTERPRISECODERF = I.ENTERPRISECODERF");
                sb.AppendLine(" AND E.LOGICALDELETECODERF = I.LOGICALDELETECODERF");
                sb.AppendLine(" AND E.BELONGSECTIONCODERF = I.SECTIONCODERF ");
                sb.AppendLine("WHERE");
                sb.AppendLine(" E.ENTERPRISECODERF = @FINDENTERPRISECODE");
                sb.AppendLine(" AND E.LOGICALDELETECODERF = @FINDLOGICALDELETECODE");
                sb.AppendLine(" AND E.EMPLOYEECODERF = @FINDEMPLOYEECODE ");
                sb.AppendLine("UNION SELECT");
                sb.AppendLine(" ORDERINSPECTCODERF,");
                sb.AppendLine(" 1 ORDERRF ");
                sb.AppendLine("FROM");
                sb.AppendLine(" INSPECTTTLSTRF WITH (READUNCOMMITTED) ");
                sb.AppendLine("WHERE");
                sb.AppendLine(" ENTERPRISECODERF = @FINDENTERPRISECODE");
                sb.AppendLine(" AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE");
                sb.AppendLine(" AND SECTIONCODERF = @FINDSECTIONCODE) A ");
                sb.AppendLine("ORDER BY A.ORDERRF");
                # endregion

                sqlCommand = new SqlCommand(sb.ToString(), sqlConnection);
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                #region �p�����[�^�ݒ�
                // ��ƃR�[�h
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(condWork.EnterpriseCode);
                // �_���폜�敪
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // �]�ƈ��R�[�h
                SqlParameter findEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                findEmployeeCode.Value = SqlDataMediator.SqlSetString(condWork.EmployeeCode);
                // ���_�R�[�h
                SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                findSectionCode.Value = SqlDataMediator.SqlSetString("00");
                #endregion

                myReader = sqlCommand.ExecuteReader();

                // �f�[�^�����݂���ꍇ
                while (myReader.Read())
                {
                    orderInspectCode = SqlDataMediator.SqlGetInt32(myReader, 0);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyInspectDB.SearchOrderInspectCode" + ex.Message, status);
            }
            finally
            {
                // myReader��null�ł͂Ȃ��ꍇ
                if (myReader != null)
                {
                    // myReader�����Ă��Ȃ��ꍇ�A
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

                // sqlCommand��null�ł͂Ȃ��ꍇ
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏o�׃f�[�^�v��c�敪��߂��܂�
        /// </summary>
        /// <param name="condWork">��������</param>
        /// <param name="shipmAddUpRemDiv">�o�׃f�[�^�v��c�敪</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̏o�׃f�[�^�v��c�敪��߂��܂�</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private int SearchShipmAddUpRemDiv(HandyInspectCondWork condWork, out int shipmAddUpRemDiv, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            shipmAddUpRemDiv = -1;
            // �����敪���u1,3�v�̏ꍇ
            if (condWork.ProcDiv == 1 || condWork.ProcDiv == 3)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                return status;
            }

            try
            {
                // SQL���𐶐�
                StringBuilder sb = new StringBuilder();

                # region SELECT�吶��
                sb.AppendLine("SELECT TOP 1 A.SHIPMADDUPREMDIVRF FROM (");
                sb.AppendLine("SELECT");
                sb.AppendLine(" S.SHIPMADDUPREMDIVRF,");
                sb.AppendLine(" 0 ORDERRF ");
                sb.AppendLine("FROM");
                sb.AppendLine(" EMPLOYEERF E WITH (READUNCOMMITTED)");
                sb.AppendLine(" INNER JOIN SALESTTLSTRF S WITH (READUNCOMMITTED) ");
                sb.AppendLine("ON");
                sb.AppendLine(" E.ENTERPRISECODERF = S.ENTERPRISECODERF");
                sb.AppendLine(" AND E.LOGICALDELETECODERF = S.LOGICALDELETECODERF");
                sb.AppendLine(" AND E.BELONGSECTIONCODERF = S.SECTIONCODERF ");
                sb.AppendLine("WHERE");
                sb.AppendLine(" E.ENTERPRISECODERF = @FINDENTERPRISECODE");
                sb.AppendLine(" AND E.LOGICALDELETECODERF = @FINDLOGICALDELETECODE");
                sb.AppendLine(" AND E.EMPLOYEECODERF = @FINDEMPLOYEECODE ");
                sb.AppendLine("UNION SELECT");
                sb.AppendLine(" SHIPMADDUPREMDIVRF,");
                sb.AppendLine(" 1 ORDERRF ");
                sb.AppendLine("FROM");
                sb.AppendLine(" SALESTTLSTRF WITH (READUNCOMMITTED) ");
                sb.AppendLine("WHERE");
                sb.AppendLine(" ENTERPRISECODERF = @FINDENTERPRISECODE");
                sb.AppendLine(" AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE");
                sb.AppendLine(" AND SECTIONCODERF = @FINDSECTIONCODE) A ");
                sb.AppendLine("ORDER BY A.ORDERRF");
                # endregion

                sqlCommand = new SqlCommand(sb.ToString(), sqlConnection);
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                #region �p�����[�^�ݒ�
                // ��ƃR�[�h
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(condWork.EnterpriseCode);
                // �_���폜�敪
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // �]�ƈ��R�[�h
                SqlParameter findEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                findEmployeeCode.Value = SqlDataMediator.SqlSetString(condWork.EmployeeCode);
                // ���_�R�[�h
                SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                findSectionCode.Value = SqlDataMediator.SqlSetString("00");
                #endregion

                myReader = sqlCommand.ExecuteReader();

                // �f�[�^�����݂���ꍇ
                while (myReader.Read())
                {
                    shipmAddUpRemDiv = SqlDataMediator.SqlGetInt32(myReader, 0);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyInspectDB.SearchShipmAddUpRemDiv" + ex.Message, status);
            }
            finally
            {
                // myReader��null�ł͂Ȃ��ꍇ
                if (myReader != null)
                {
                    // myReader�����Ă��Ȃ��ꍇ�A
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

                // sqlCommand��null�ł͂Ȃ��ꍇ
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̌��i�Ώۏ��LIST��߂��܂�
        /// </summary>
        /// <param name="condWork">��������</param>
        /// <param name="orderInspectCode">��񌟕i�敪</param>
        /// <param name="shipmAddUpRemDiv">�o�׃f�[�^�v��c�敪</param>
        /// <param name="handyInspectWorkList">��������</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̌��i�Ώۏ��LIST��߂��܂�</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private int SearchProc(HandyInspectCondWork condWork, int orderInspectCode, int shipmAddUpRemDiv, out ArrayList handyInspectWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            handyInspectWorkList = null;

            try
            {
                #region SQL���𐶐�
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("SELECT");
                sb.AppendLine(" A.CUSTOMERSNMRF,");
                sb.AppendLine(" A.SALESSLIPNUMRF,");
                sb.AppendLine(" A.SALESROWNORF,");
                sb.AppendLine(" A.GOODSMAKERCDRF,");
                sb.AppendLine(" A.GOODSNORF,");
                sb.AppendLine(" A.GOODSNAMEKANARF,");
                sb.AppendLine(" A.SHIPMENTCNTRF,");
                sb.AppendLine(" A.WAREHOUSESHELFNORF,");
                sb.AppendLine(" A.WAREHOUSECODERF,");
                sb.AppendLine(" A.SALESORDERDIVCDRF,");
                sb.AppendLine(" G.GOODSBARCODERF,");
                sb.AppendLine(" I.INSPECTSTATUSRF,");
                sb.AppendLine(" I.INSPECTCODERF,");
                sb.AppendLine(" I.INSPECTCNTRF ");
                sb.AppendLine("FROM (SELECT");
                sb.AppendLine(" S.ENTERPRISECODERF,");
                sb.AppendLine(" S.LOGICALDELETECODERF,");
                sb.AppendLine(" S.SALESSLIPNUMRF,");
                sb.AppendLine(" S.ACPTANODRSTATUSRF,");
                sb.AppendLine(" S.CUSTOMERSNMRF,");
                sb.AppendLine(" D.SALESROWNORF,");
                sb.AppendLine(" D.GOODSMAKERCDRF,");
                sb.AppendLine(" D.GOODSNORF,");
                sb.AppendLine(" D.GOODSNAMEKANARF,");
                // �����敪���u1,2�v�̏ꍇ
                if (condWork.ProcDiv == 1 || condWork.ProcDiv == 2)
                {
                    sb.AppendLine(" D.SHIPMENTCNTRF,");
                }
                // �����敪���u3�v�̏ꍇ
                else if (condWork.ProcDiv == 3)
                {
                    sb.AppendLine(" D.SHIPMENTCNTRF * -1 SHIPMENTCNTRF,");
                }
                // �����敪���u4�v�̏ꍇ
                else
                {
                    sb.AppendLine(" D.SHIPMENTCNTRF * -1 SHIPMENTCNTRF,");
                }
                sb.AppendLine(" D.WAREHOUSESHELFNORF,");
                sb.AppendLine(" D.SALESORDERDIVCDRF,");
                sb.AppendLine(" CASE WHEN (D.SALESORDERDIVCDRF = 0) THEN '0'");
                sb.AppendLine(" ELSE D.WAREHOUSECODERF END WAREHOUSECODERF ");
                sb.AppendLine("FROM");
                sb.AppendLine(" SALESSLIPRF S WITH (READUNCOMMITTED)");
                sb.AppendLine(" INNER JOIN SALESDETAILRF D WITH (READUNCOMMITTED)");
                sb.AppendLine(" ON S.ENTERPRISECODERF = D.ENTERPRISECODERF");
                sb.AppendLine(" AND S.LOGICALDELETECODERF = D.LOGICALDELETECODERF");
                sb.AppendLine(" AND S.ACPTANODRSTATUSRF = D.ACPTANODRSTATUSRF");
                sb.AppendLine(" AND S.SALESSLIPNUMRF = D.SALESSLIPNUMRF ");
                sb.AppendLine("WHERE");
                sb.AppendLine(" S.ENTERPRISECODERF = @FINDENTERPRISECODE");
                sb.AppendLine(" AND S.LOGICALDELETECODERF = @FINDLOGICALDELETECODE");
                sb.AppendLine(" AND S.SALESSLIPNUMRF = @FINDSALESSLIPNUM");
                sb.AppendLine(" AND S.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS");
                sb.AppendLine(" AND S.DEBITNOTEDIVRF = @FINDDEBITNOTEDIV");
                sb.AppendLine(" AND D.GOODSMAKERCDRF <> 0");
                sb.AppendLine(" AND D.GOODSNORF IS NOT NULL");
                // ��񌟕i�敪���u0�F���Ȃ��v�̏ꍇ
                if (orderInspectCode == 0)
                    sb.AppendLine(" AND D.SALESORDERDIVCDRF = @FINDSALESORDERDIVCD");
                sb.AppendLine(" AND D.SALESSLIPCDDTLRF = @FINDSALESSLIPCDDTL");

                // �����敪��1�̏ꍇ
                if (condWork.ProcDiv == 1)
                {
                    sb.AppendLine(" AND D.ACPTANODRSTATUSSRCRF <> @FINDACPTANODRSTATUSSRC");
                    sb.AppendLine(" AND D.SHIPMENTCNTRF > @FINDSHIPMENTCNT");
                }
                // �����敪��2�̏ꍇ
                else if (condWork.ProcDiv == 2)
                {
                    sb.AppendLine(" AND D.SHIPMENTCNTRF > @FINDSHIPMENTCNT");
                }
                // �����敪��3�̏ꍇ
                else if (condWork.ProcDiv == 3)
                {
                    sb.AppendLine(" AND D.SHIPMENTCNTRF * -1 > @FINDSHIPMENTCNT");
                }
                // �����敪��4�̏ꍇ
                else
                {
                    // �ݏo�c�敪���u0:�c���v�̏ꍇ
                    if (shipmAddUpRemDiv == 0)
                        sb.AppendLine(" AND D.SHIPMENTCNTRF * -1 > @FINDSHIPMENTCNT");
                    // �ݏo�c�敪���u1:�c���Ȃ��v�̏ꍇ
                    else
                    {
                        sb.AppendLine(" AND D.SHIPMENTCNTRF * -1 > @FINDSHIPMENTCNT ");
                        sb.AppendLine("UNION SELECT");
                        sb.AppendLine(" S.ENTERPRISECODERF,");
                        sb.AppendLine(" S.LOGICALDELETECODERF,");
                        sb.AppendLine(" S.SALESSLIPNUMRF,");
                        sb.AppendLine(" S.ACPTANODRSTATUSRF,");
                        sb.AppendLine(" S.CUSTOMERSNMRF,");
                        sb.AppendLine(" D.SALESROWNORF,");
                        sb.AppendLine(" D.GOODSMAKERCDRF,");
                        sb.AppendLine(" D.GOODSNORF,");
                        sb.AppendLine(" D.GOODSNAMEKANARF,");
                        sb.AppendLine(" CASE WHEN (E.SHIPMENTCNTRF IS NOT NULL) THEN (D.SHIPMENTCNTRF - E.SHIPMENTCNTRF)");
                        sb.AppendLine(" ELSE D.SHIPMENTCNTRF END SHIPMENTCNTRF,");
                        sb.AppendLine(" D.WAREHOUSESHELFNORF,");
                        sb.AppendLine(" D.SALESORDERDIVCDRF,");
                        sb.AppendLine(" CASE WHEN (D.SALESORDERDIVCDRF=0) THEN '0'");
                        sb.AppendLine(" ELSE D.WAREHOUSECODERF END WAREHOUSECODERF ");
                        sb.AppendLine("FROM");
                        sb.AppendLine(" SALESSLIPRF S WITH (READUNCOMMITTED)");
                        sb.AppendLine(" INNER JOIN SALESDETAILRF D WITH (READUNCOMMITTED)");
                        sb.AppendLine(" ON S.ENTERPRISECODERF = D.ENTERPRISECODERF");
                        sb.AppendLine(" AND S.LOGICALDELETECODERF = D.LOGICALDELETECODERF");
                        sb.AppendLine(" AND S.ACPTANODRSTATUSRF = D.ACPTANODRSTATUSRF");
                        sb.AppendLine(" AND S.SALESSLIPNUMRF = D.SALESSLIPNUMRF");
                        sb.AppendLine(" LEFT JOIN SALESDETAILRF E WITH (READUNCOMMITTED)");
                        sb.AppendLine(" ON D.ENTERPRISECODERF = E.ENTERPRISECODERF");
                        sb.AppendLine(" AND D.ACPTANODRSTATUSRF = E.ACPTANODRSTATUSSRCRF");
                        sb.AppendLine(" AND D.SALESSLIPDTLNUMRF = E.SALESSLIPDTLNUMSRCRF");
                        sb.AppendLine(" AND E.LOGICALDELETECODERF = @FINDLOGICALDELETECODE");
                        sb.AppendLine(" AND E.ACPTANODRSTATUSRF = @FINDRENTACPTANODRSTATUS ");
                        sb.AppendLine("WHERE");
                        sb.AppendLine(" S.ENTERPRISECODERF=@FINDENTERPRISECODE");
                        sb.AppendLine(" AND S.LOGICALDELETECODERF = @FINDRENTLOGICALDELETECODE");
                        sb.AppendLine(" AND S.SALESSLIPNUMRF = @FINDSALESSLIPNUM");
                        sb.AppendLine(" AND S.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS");
                        sb.AppendLine(" AND S.DEBITNOTEDIVRF = @FINDDEBITNOTEDIV");
                        sb.AppendLine(" AND D.GOODSMAKERCDRF <> 0");
                        sb.AppendLine(" AND D.GOODSNORF IS NOT NULL");
                        // ��񌟕i�敪���u0�F���Ȃ��v�̏ꍇ
                        if (orderInspectCode == 0)
                            sb.AppendLine(" AND D.SALESORDERDIVCDRF = @FINDSALESORDERDIVCD");
                        sb.AppendLine(" AND D.SALESSLIPCDDTLRF = @FINDRENTSALESSLIPCDDTL");
                        sb.AppendLine(" AND ((E.SHIPMENTCNTRF IS NOT NULL AND D.SHIPMENTCNTRF - E.SHIPMENTCNTRF > 0)");
                        sb.AppendLine(" OR (E.SHIPMENTCNTRF IS NULL AND D.SHIPMENTCNTRF > 0))");
                    }
                }
                sb.AppendLine(") A ");
                sb.AppendLine("LEFT JOIN GOODSBARCODEREVNRF G WITH (READUNCOMMITTED)");
                sb.AppendLine(" ON A.ENTERPRISECODERF = G.ENTERPRISECODERF");
                sb.AppendLine(" AND G.LOGICALDELETECODERF = @FINDLOGICALDELETECODE");
                sb.AppendLine(" AND A.GOODSMAKERCDRF = G.GOODSMAKERCDRF");
                sb.AppendLine(" AND A.GOODSNORF = G.GOODSNORF ");
                sb.AppendLine("LEFT JOIN INSPECTDATARF I WITH (READUNCOMMITTED)");
                sb.AppendLine(" ON A.ENTERPRISECODERF = I.ENTERPRISECODERF");
                sb.AppendLine(" AND I.LOGICALDELETECODERF = @FINDLOGICALDELETECODE");
                sb.AppendLine(" AND A.SALESSLIPNUMRF = I.ACPAYSLIPNUMRF");
                sb.AppendLine(" AND A.SALESROWNORF = I.ACPAYSLIPROWNORF");
                sb.AppendLine(" AND A.GOODSMAKERCDRF = I.GOODSMAKERCDRF");
                sb.AppendLine(" AND A.GOODSNORF = I.GOODSNORF");
                sb.AppendLine(" AND A.WAREHOUSECODERF = I.WAREHOUSECODERF");
                sb.AppendLine(" AND I.ACPAYSLIPCDRF = @FINDACPAYSLIPCD");
                sb.AppendLine(" AND I.ACPAYTRANSCDRF = @FINDACPAYTRANSCD");
                sb.AppendLine("ORDER BY");
                sb.AppendLine(" A.ACPTANODRSTATUSRF,");
                sb.AppendLine(" A.SALESSLIPNUMRF,");
                sb.AppendLine(" A.SALESROWNORF");
                #endregion

                #region �p�����[�^�ݒ�
                sqlCommand = new SqlCommand(sb.ToString(), sqlConnection);
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                this.SetSqlCommand(condWork, orderInspectCode, ref sqlCommand);

                // �_���폜�敪
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                // �󒍃X�e�[�^�X
                SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                // ����`�[�敪�i���ׁj
                SqlParameter findSalesSlipCdDtl = sqlCommand.Parameters.Add("@FINDSALESSLIPCDDTL", SqlDbType.Int);
                // �󕥌��`�[�敪
                SqlParameter findAcPaySlipCd = sqlCommand.Parameters.Add("@FINDACPAYSLIPCD", SqlDbType.Int);
                // �󕥌�����敪
                SqlParameter findAcPayTransCd = sqlCommand.Parameters.Add("@FINDACPAYTRANSCD", SqlDbType.Int);

                switch (condWork.ProcDiv)
                {
                    case 1:

                        findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);   // �_���폜�敪
                        findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(30);    // �󒍃X�e�[�^�X
                        findSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(0);      // ����`�[�敪�i���ׁj
                        findAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(20);        // �󕥌��`�[�敪
                        findAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(10);       // �󕥌�����敪
                        // �󒍃X�e�[�^�X�i���j
                        SqlParameter findAcptAnOdrStatusSrc = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUSSRC", SqlDbType.Int);
                        findAcptAnOdrStatusSrc.Value = SqlDataMediator.SqlSetInt32(40);

                        break;

                    case 2:

                        findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);   // �_���폜�敪
                        findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(40);    // �󒍃X�e�[�^�X
                        findSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(0);      // ����`�[�敪�i���ׁj
                        findAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(22);        // �󕥌��`�[�敪
                        findAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(10);       // �󕥌�����敪

                        break;

                    case 3:

                        findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);   // �_���폜�敪
                        findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(30);    // �󒍃X�e�[�^�X
                        findSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(1);      // ����`�[�敪�i���ׁj
                        findAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(20);        // �󕥌��`�[�敪
                        findAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(11);       // �󕥌�����敪

                        break;

                    case 4:

                        // �ݏo�c�敪���u0:�c���v�̏ꍇ
                        if (shipmAddUpRemDiv == 0)
                        {
                            findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);   // �_���폜�敪
                            findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(40);    // �󒍃X�e�[�^�X
                            findSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(1);      // ����`�[�敪�i���ׁj
                            findAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(22);        // �󕥌��`�[�敪
                            findAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(11);       // �󕥌�����敪
                        }
                        // �ݏo�c�敪���u1:�c���Ȃ��v�̏ꍇ
                        else
                        {
                            findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);   // �_���폜�敪
                            findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(40);    // �󒍃X�e�[�^�X
                            findSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(1);      // ����`�[�敪�i���ׁj
                            findAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(22);        // �󕥌��`�[�敪
                            findAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(11);       // �󕥌�����敪

                            // �_���폜�敪
                            SqlParameter findRentLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDRENTLOGICALDELETECODE", SqlDbType.Int);
                            findRentLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(1);
                            // �󒍃X�e�[�^�X
                            SqlParameter findRentAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDRENTACPTANODRSTATUS", SqlDbType.Int);
                            findRentAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(30);
                            // ����`�[�敪�i���ׁj
                            SqlParameter findRentSalesSlipCdDtl = sqlCommand.Parameters.Add("@FINDRENTSALESSLIPCDDTL", SqlDbType.Int);
                            findRentSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(0);
                        }
                        break;

                }
                #endregion

                myReader = sqlCommand.ExecuteReader();

                int[] indexs = new int[14];
                // �f�[�^�����݂���ꍇ
                if (myReader.HasRows)
                {
                    int i = -1;
                    indexs[++i] = myReader.GetOrdinal("CUSTOMERSNMRF");
                    indexs[++i] = myReader.GetOrdinal("SALESSLIPNUMRF");
                    indexs[++i] = myReader.GetOrdinal("SALESROWNORF");
                    indexs[++i] = myReader.GetOrdinal("GOODSMAKERCDRF");
                    indexs[++i] = myReader.GetOrdinal("GOODSNORF");
                    indexs[++i] = myReader.GetOrdinal("GOODSNAMEKANARF");
                    indexs[++i] = myReader.GetOrdinal("SHIPMENTCNTRF");
                    indexs[++i] = myReader.GetOrdinal("WAREHOUSESHELFNORF");
                    indexs[++i] = myReader.GetOrdinal("WAREHOUSECODERF");
                    indexs[++i] = myReader.GetOrdinal("SALESORDERDIVCDRF");
                    indexs[++i] = myReader.GetOrdinal("GOODSBARCODERF");
                    indexs[++i] = myReader.GetOrdinal("INSPECTSTATUSRF");
                    indexs[++i] = myReader.GetOrdinal("INSPECTCODERF");
                    indexs[++i] = myReader.GetOrdinal("INSPECTCNTRF");

                    handyInspectWorkList = new ArrayList();
                }

                while (myReader.Read())
                {
                    handyInspectWorkList.Add(CopyToHandyLoginInfoWorkFromReader(indexs, ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyInspectDB.SearchProc" + ex.Message, status);
            }
            finally
            {
                // myReader��null�ł͂Ȃ��ꍇ
                if (myReader != null)
                {
                    // myReader�����Ă��Ȃ��ꍇ�A
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

                // sqlCommand��null�ł͂Ȃ��ꍇ
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        private void SetSqlCommand(HandyInspectCondWork condWork, int orderInspectCode, ref SqlCommand sqlCommand)
        {
            // ��ƃR�[�h
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(condWork.EnterpriseCode);
            // �`�[�ԍ�
            SqlParameter findSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
            findSalesSlipNum.Value = SqlDataMediator.SqlSetString(condWork.SlipNum);
            // �ԓ`�敪
            SqlParameter findDebitNoteDiv = sqlCommand.Parameters.Add("@FINDDEBITNOTEDIV", SqlDbType.Int);
            findDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(0);
            // ��񌟕i�敪���u0�F���Ȃ��v�̏ꍇ
            if (orderInspectCode == 0)
            {
                // ����݌Ɏ�񂹋敪
                SqlParameter findSalesOrderDivDd = sqlCommand.Parameters.Add("@FINDSALESORDERDIVCD", SqlDbType.Int);
                findSalesOrderDivDd.Value = SqlDataMediator.SqlSetInt32(1);
            }
            // �o�א�
            SqlParameter findShipmentCnt = sqlCommand.Parameters.Add("@FINDSHIPMENTCNT", SqlDbType.Float);
            findShipmentCnt.Value = SqlDataMediator.SqlSetDouble(0);
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� HandyInspectWork
        /// </summary>
        /// <param name="indexs">��̏����z��</param>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>HandyInspectWork</returns>
        /// <remarks>
        /// <br>Note       : �N���X�i�[�������s���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private HandyInspectWork CopyToHandyLoginInfoWorkFromReader(int[] indexs, ref SqlDataReader myReader)
        {
            HandyInspectWork handyInspectWork = new HandyInspectWork();

            #region �N���X�֊i�[
            int i = -1;
            handyInspectWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, indexs[++i]);
            handyInspectWork.SlipNum = SqlDataMediator.SqlGetString(myReader, indexs[++i]);
            handyInspectWork.RowNo = SqlDataMediator.SqlGetInt32(myReader, indexs[++i]);
            handyInspectWork.MakerCd = SqlDataMediator.SqlGetInt32(myReader, indexs[++i]);
            handyInspectWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, indexs[++i]);
            handyInspectWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, indexs[++i]);
            handyInspectWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, indexs[++i]);
            handyInspectWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, indexs[++i]);
            handyInspectWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, indexs[++i]);
            handyInspectWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, indexs[++i]);
            handyInspectWork.GoodsBarCode = SqlDataMediator.SqlGetString(myReader, indexs[++i]);
            handyInspectWork.InspectStatus = SqlDataMediator.SqlGetInt32(myReader, indexs[++i]);
            handyInspectWork.InspectCode = SqlDataMediator.SqlGetInt32(myReader, indexs[++i]);
            handyInspectWork.InspectCnt = SqlDataMediator.SqlGetDouble(myReader, indexs[++i]);
            #endregion

            return handyInspectWork;
        }

        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Note       : SqlConnection�𐶐����܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            // connectionText�����݂��Ȃ��ꍇ
            if (String.IsNullOrEmpty(connectionText))
            {
                base.WriteErrorLog("HandyInspectDB.CreateSqlConnection" + "�R�l�N�V�����擾���s");
                return null;
            } 

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
