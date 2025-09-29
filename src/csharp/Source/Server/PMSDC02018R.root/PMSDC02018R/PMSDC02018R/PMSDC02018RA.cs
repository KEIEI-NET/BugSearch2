//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����A�g�e�L�X�g�o��
// �v���O�����T�v   : ����A�g�e�L�X�g�o�͒��[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570219-00     �쐬�S�� : �c����
// �� �� �� 2019/12/02       �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570219-00     �쐬�S�� : ���c�`�[
// �X �V �� 2020/02/04       �C�����e : �i�C�����e�ꗗNo.�Q�j���l�o�͐ݒ荀�ڕύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 11670214-00    �쐬�S�� : 3H ����
// �X �V �� 2020/09/15     �C�����e : ����f�[�^�o�͕�����g���Ή� ���i���̍��ڒǉ�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting;
using Broadleaf.Library.Resources;
using System.Collections;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ����A�g�e�L�X�gDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����A�g�e�L�X�g�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2019/12/02</br>
    /// </remarks>
    [Serializable]
    public class SalesCprtDB : RemoteDB, ISalesCprtWorkDB
    {
        /// <summary>
        /// ����A�g�e�L�X�g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        public SalesCprtDB()
            :
        base("PMSDC02016D", "Broadleaf.Application.Remoting.ParamData.SalesCprtWork", "SALESHISTORYRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region Search
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔���A�g�e�L�X�g�̑S�Ė߂鏈���i�_���폜�����j
        /// </summary>
        /// <param name="salesCprtWork">��������</param>
        /// <param name="salesCprtCndtnWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔���f�[�^LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        public int Search(out object salesCprtWork, object salesCprtCndtnWork)
        {
            SqlConnection sqlConnection = null;
            salesCprtWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection(true);

                return SearchProc(out salesCprtWork, salesCprtCndtnWork, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesCprtDB.Search");
                salesCprtWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (null != sqlConnection)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔���A�g�e�L�X�g��S�Ė߂鏈��
        /// </summary>
        /// <param name="salesCprtWork">��������</param>
        /// <param name="salesCprtCndtnWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎d���f�[�^LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// <br>Update Note: 2020/02/04 ���c �`�[</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br>           :�i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
        /// <br>Update Note: 2020/09/15 3H ����</br>
        /// <br>�Ǘ��ԍ�   : 11670214-00</br>
        /// <br>           : ����f�[�^�o�͕�����g���Ή� ���i���̍��ڒǉ�</br>
        /// </remarks>
        private int SearchProc(out object salesCprtWork, object salesCprtCndtnWork, ref SqlConnection sqlConnection)
        {
            SalesCprtCndtnWork cndtnWork = salesCprtCndtnWork as SalesCprtCndtnWork;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            salesCprtWork = null;
            ArrayList al = new ArrayList();   //���o����

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                StringBuilder sb = new StringBuilder();
                sb.Append(" SELECT ");
                sb.Append(" A.CREATEDATETIMERF, ");
                sb.Append(" A.UPDATEDATETIMERF, ");
                sb.Append(" A.ENTERPRISECODERF, ");
                sb.Append(" A.ACPTANODRSTATUSRF, ");
                sb.Append(" A.SALESSLIPNUMRF, ");
                sb.Append(" C.SALESSLIPNUMRF AS DEBITNLNKSALESSLNUMRF, ");
                sb.Append(" A.SALESSLIPCDRF, ");
                sb.Append(" A.RESULTSADDUPSECCDRF, ");
                sb.Append(" A.SEARCHSLIPDATERF, ");
                sb.Append(" A.ADDUPADATERF, ");
                sb.Append(" A.CUSTOMERCODERF, ");
                sb.Append(" A.SLIPNOTERF, ");
                sb.Append(" A.SLIPNOTE2RF, ");
                sb.Append(" A.SLIPNOTE3RF, ");
                sb.Append(" B.SALESROWNORF, ");
                sb.Append(" B.GOODSMAKERCDRF, ");
                sb.Append(" B.GOODSNORF, ");
                sb.Append(" B.GOODSNAMERF, ");     // ���i����  // 2020/09/15 3H ���� ADD
                sb.Append(" B.GOODSNAMEKANARF, ");
                sb.Append(" B.PRTBLGOODSCODERF AS BLGOODSCODERF, ");
                sb.Append(" B.SALESUNPRCTAXEXCFLRF, ");
                sb.Append(" B.SHIPMENTCNTRF, ");
                sb.Append(" B.SALESMONEYTAXEXCRF, ");
                sb.Append(" B.LISTPRICETAXEXCFLRF, ");
                sb.Append(" B.SUPPLIERCDRF, ");
                sb.Append(" B.PRTBLGOODSCODERF, ");
                sb.Append(" D.CUSTOMERSNMRF, ");
                sb.Append(" E.SECTIONGUIDESNMRF, ");
                sb.Append(" G.ENTERPRISECODERF AS SEENTERPRISECODERF, ");
                sb.Append(" G.ACPTANODRSTATUSRF AS SEACPTANODRSTATUSRF, ");
                sb.Append(" G.SALESSLIPNUMRF AS SESALESSLIPNUMRF, ");
                sb.Append(" G.SALESCREATEDATETIMERF AS SESALESCREATEDATETIMERF ");
                //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
                sb.Append(" ,A.PARTYSALESLIPNUMRF ");
                //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2

                sb.Append(" FROM SALESHISTORYRF A WITH (READUNCOMMITTED)");

                sb.Append(" INNER JOIN SALESHISTDTLRF B ");
                sb.Append(" ON A.ENTERPRISECODERF =  B.ENTERPRISECODERF ");
                sb.Append(" AND A.ACPTANODRSTATUSRF = B.ACPTANODRSTATUSRF ");
                sb.Append(" AND A.SALESSLIPNUMRF =  B.SALESSLIPNUMRF ");

                sb.Append(" LEFT JOIN SALESHISTDTLRF C ");
                sb.Append(" ON C.ENTERPRISECODERF =  B.ENTERPRISECODERF ");
                sb.Append(" AND C.ACPTANODRSTATUSRF = B.ACPTANODRSTATUSRF ");
                sb.Append(" AND C.SALESSLIPDTLNUMRF =  B.SALESSLIPDTLNUMSRCRF ");

                sb.Append(" LEFT JOIN CUSTOMERRF D ");
                sb.Append(" ON A.ENTERPRISECODERF =  D.ENTERPRISECODERF ");
                sb.Append(" AND A.CUSTOMERCODERF =  D.CUSTOMERCODERF ");
                sb.Append(" AND D.LOGICALDELETECODERF = 0 ");

                sb.Append(" LEFT JOIN SECINFOSETRF E ");
                sb.Append(" ON A.ENTERPRISECODERF =  E.ENTERPRISECODERF ");
                sb.Append(" AND A.RESULTSADDUPSECCDRF = E.SECTIONCODERF ");
                sb.Append(" AND E.LOGICALDELETECODERF = 0 ");

                sb.Append(" LEFT JOIN SALCPRTEXTRDTRF G ");
                sb.Append(" ON A.ENTERPRISECODERF =  G.ENTERPRISECODERF ");
                sb.Append(" AND A.ACPTANODRSTATUSRF = G.ACPTANODRSTATUSRF ");
                sb.Append(" AND A.SALESSLIPNUMRF = G.SALESSLIPNUMRF ");
                //���M�敪(0:�蓮;1:����)
                if (cndtnWork.SendDataDiv == 1)
                {
                    sb.Append(" AND A.CREATEDATETIMERF = G.SALESCREATEDATETIMERF ");
                    sb.Append(" AND A.UPDATEDATETIMERF = G.SALESUPDATEDATETIMERF ");
                }

                // ��������
                sb.Append(MakeWhereString(ref sqlCommand, cndtnWork));

                sb.Append(" ORDER BY ");
                sb.Append(" A.ADDUPADATERF,A.RESULTSADDUPSECCDRF,A.SALESSLIPNUMRF,B.SALESROWNORF ");

                sqlCommand.CommandText = sb.ToString();

                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    SalesCprtWork wkSalesHistoryJoinWork = new SalesCprtWork();

                    //�f�[�^���ʎ擾���e�i�[
                    wkSalesHistoryJoinWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkSalesHistoryJoinWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkSalesHistoryJoinWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkSalesHistoryJoinWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                    wkSalesHistoryJoinWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                    wkSalesHistoryJoinWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
                    wkSalesHistoryJoinWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
                    wkSalesHistoryJoinWork.SearchSlipDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SEARCHSLIPDATERF"));
                    wkSalesHistoryJoinWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    wkSalesHistoryJoinWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    wkSalesHistoryJoinWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkSalesHistoryJoinWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkSalesHistoryJoinWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));�@// ���i���́@// 2020/09/15 3H ���� ADD 
                    wkSalesHistoryJoinWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                    wkSalesHistoryJoinWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    wkSalesHistoryJoinWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                    wkSalesHistoryJoinWork.PrtBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTBLGOODSCODERF"));
                    wkSalesHistoryJoinWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    wkSalesHistoryJoinWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                    wkSalesHistoryJoinWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                    wkSalesHistoryJoinWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    wkSalesHistoryJoinWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    wkSalesHistoryJoinWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    wkSalesHistoryJoinWork.SEEnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEENTERPRISECODERF"));
                    wkSalesHistoryJoinWork.SEAcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEACPTANODRSTATUSRF"));
                    wkSalesHistoryJoinWork.SESalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SESALESSLIPNUMRF"));
                    wkSalesHistoryJoinWork.SESalesCreateDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SESALESCREATEDATETIMERF"));
                    wkSalesHistoryJoinWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
                    wkSalesHistoryJoinWork.SlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE2RF"));
                    wkSalesHistoryJoinWork.SlipNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE3RF"));
                    wkSalesHistoryJoinWork.DebitNLnkSalesSlNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEBITNLNKSALESSLNUMRF"));
                    wkSalesHistoryJoinWork.SalesCreateDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkSalesHistoryJoinWork.SalesUpdateDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
                    wkSalesHistoryJoinWork.PartySalesLipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
                    //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
                    #endregion

                    al.Add(wkSalesHistoryJoinWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                if (al.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "SalesCprtDB.SearchProc", status);
            }
            finally
            {
                if (null != myReader && !myReader.IsClosed)
                {
                    myReader.Close();
                }

                if (null != sqlCommand)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            salesCprtWork = al;

            return status;
        }
        #endregion

        #region Update
        /// <summary>
        /// ���㒊�o�f�[�^����ǉ��X�V�����B
        /// </summary>
        /// <param name="salesCprtWorkList">�ǉ��E�X�V���锄�㒊�o�f�[�^���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : salesCprtWorkList �Ɋi�[����Ă��锄�㒊�o�f�[�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        public int Write(ref object salesCprtWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList salesHistoryWorkList = salesCprtWorkList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                foreach (SalesCprtWork detailWork in salesHistoryWorkList)
                {
                    // �폜�������s
                    status = this.DeleteProc(detailWork, ref sqlConnection, ref sqlTransaction);

                    //�ǉ��������s
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = this.InsertProc(detailWork, ref sqlConnection, ref sqlTransaction);
                    }

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesCprtDB.Write(ref object)", status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        ///���㒊�o�f�[�^���𕨗��폜����
        /// </summary>
        /// <param name="salesCprtWork">���㒊�o�f�[�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SalesCprtWork �Ɋi�[����Ă���SE���㒊�o�f�[�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br> 
        /// </remarks>
        private int DeleteProc(SalesCprtWork salesCprtWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;

            try
            {
                if (salesCprtWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [DELETE��]
                    sqlText += "DELETE " + Environment.NewLine;
                    sqlText += "FROM " + Environment.NewLine;
                    sqlText += "SALCPRTEXTRDTRF " + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += " AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += " AND SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion


                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                    SqlParameter findSalesCreateDateTime = sqlCommand.Parameters.Add("@FINDSALESCREATEDATETIME", SqlDbType.BigInt);

                    // KEY�R�}���h��ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesCprtWork.EnterpriseCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesCprtWork.AcptAnOdrStatus);
                    findSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesCprtWork.SalesSlipNum);
                    findSalesCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesCprtWork.CreateDateTime);

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SalesCprtDB.DeleteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SalesCprtDB.DeleteProc" , status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        ///���㒊�o�f�[�^����ǉ�����
        /// </summary>
        /// <param name="salesCprtWork">���㒊�o�f�[�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SalesCprtWork �Ɋi�[����Ă���SE���㒊�o�f�[�^����ǉ����܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private int InsertProc(SalesCprtWork salesCprtWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;

            try
            {
                if (salesCprtWork != null)
                {
                    string sqlText = string.Empty;

                    //���㒊�o�f�[�^. ����f�[�^�쐬����
                    long salesCreateDateTime = salesCprtWork.SalesCreateDateTime;
                    long salesUpdateDateTime = salesCprtWork.SalesUpdateDateTime; 

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [INSERT��]
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO SALCPRTEXTRDTRF" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += " ,SALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += " ,SALESCREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,SALESUPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += ")" + Environment.NewLine;
                    sqlText += "VALUES" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += " ,@ACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += " ,@SALESSLIPNUM" + Environment.NewLine;
                    sqlText += " ,@SALESCREATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@SALESUPDATEDATETIME" + Environment.NewLine;
                    sqlText += ")" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    // �o�^�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)salesCprtWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);

                    # region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                    SqlParameter paraSalesCreateDateTime = sqlCommand.Parameters.Add("@SALESCREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraSalesUpdateDateTime = sqlCommand.Parameters.Add("@SALESUPDATEDATETIME", SqlDbType.BigInt);
                    # endregion

                    # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesCprtWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesCprtWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesCprtWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(salesCprtWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(salesCprtWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(salesCprtWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(salesCprtWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(salesCprtWork.LogicalDeleteCode);
                    paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesCprtWork.AcptAnOdrStatus);
                    paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesCprtWork.SalesSlipNum);
                    paraSalesCreateDateTime.Value = SqlDataMediator.SqlSetInt64(salesCreateDateTime);
                    paraSalesUpdateDateTime.Value = SqlDataMediator.SqlSetInt64(salesUpdateDateTime);

                    # endregion

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SalesCprtDB.InsertProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SalesCprtDB.InsertProc" , status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        #endregion

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="salesCprtCndtnWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <remarks>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesCprtCndtnWork salesCprtCndtnWork)
        {
            #region WHERE���쐬
            string retstring = " WHERE ";

            //��ƃR�[�h
            retstring += " A.ENTERPRISECODERF=@ENTERPRISECODERF";
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODERF", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(salesCprtCndtnWork.EnterpriseCode);

            //���㗚���f�[�^.�_���폜�敪
            retstring += " AND A.LOGICALDELETECODERF=@ALOGICALDELETECODERF";
            SqlParameter paraALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODERF", SqlDbType.Int);
            paraALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //�󒍃X�e�[�^�X
            retstring += " AND A.ACPTANODRSTATUSRF=@ACPTANODRSTATUSRF";
            SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUSRF", SqlDbType.Int);
            paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(30);

            //���㗚�𖾍׃f�[�^.�_���폜�敪
            retstring += " AND B.LOGICALDELETECODERF=@BLOGICALDELETECODERF";
            SqlParameter paraBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODERF", SqlDbType.Int);
            paraBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //���_�R�[�h 
            if (!string.IsNullOrEmpty(salesCprtCndtnWork.SectionCode) && !salesCprtCndtnWork.SectionCode.Equals("00"))
            {
                retstring += " AND A.RESULTSADDUPSECCDRF = @RESULTSADDUPSECCD";
                SqlParameter ParaSectionCode = sqlCommand.Parameters.Add("@RESULTSADDUPSECCD", SqlDbType.NChar);
                ParaSectionCode.Value = SqlDataMediator.SqlSetString(salesCprtCndtnWork.SectionCode);
            }

            //���M�敪(0:�蓮;1:����)
            if (salesCprtCndtnWork.SendDataDiv == 0)
            {
                // AND �v���>���p�����[�^.�v����̊J�n��																																	
                if (!DateTime.MinValue.Equals(salesCprtCndtnWork.AddUpADateSt))
                {
                    retstring += " AND A.ADDUPADATERF>=@ST_SCVDAY ";
                    SqlParameter Para_St_csvDate = sqlCommand.Parameters.Add("@ST_SCVDAY", SqlDbType.Int);
                    Para_St_csvDate.Value = SqlDataMediator.SqlSetInt32(salesCprtCndtnWork.AddUpADateSt);
                }

                // AND �v���<���p�����[�^.�v����̏I����
                if (!DateTime.MinValue.Equals(salesCprtCndtnWork.AddUpADateEd))
                {
                    retstring += " AND A.ADDUPADATERF<=@ED_SCVDAY ";
                    SqlParameter Para_Ed_csvDate = sqlCommand.Parameters.Add("@ED_SCVDAY", SqlDbType.Int);
                    Para_Ed_csvDate.Value = SqlDataMediator.SqlSetInt32(salesCprtCndtnWork.AddUpADateEd);
                }
            }
            else
            {
                // AND �X�V����>���p�����[�^.�����J�n����																																
                if (!DateTime.MinValue.Equals(salesCprtCndtnWork.SearchTimeSt))
                {
                    retstring += " AND A.UPDATEDATETIMERF>=@ST_SECTIME ";
                    SqlParameter Para_St_secTime = sqlCommand.Parameters.Add("@ST_SECTIME", SqlDbType.BigInt);
                    Para_St_secTime.Value = SqlDataMediator.SqlSetInt64(salesCprtCndtnWork.SearchTimeSt.Ticks);
                }

                // �������M�ڑ��敪 0:�����M,2:�S��
                if (salesCprtCndtnWork.AutoDataSendDiv == 0)
                {
                    retstring += " AND G.ENTERPRISECODERF IS NULL ";
                }
            }

            // AND ���Ӑ�R�[�h>���p�����[�^.���Ӑ�R�[�h�̊J�n																																	
            if (0 != salesCprtCndtnWork.CustomerCode)
            {
                retstring += " AND A.CUSTOMERCODERF=@ST_CUSTOMERCODE ";
                SqlParameter Para_St_customerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCODE", SqlDbType.Int);
                Para_St_customerCode.Value = SqlDataMediator.SqlSetInt32(salesCprtCndtnWork.CustomerCode);
            }

            retstring += " AND (B.SALESSLIPCDDTLRF = 0 OR B.SALESSLIPCDDTLRF = 1 OR (B.SALESSLIPCDDTLRF = 2 AND B.SHIPMENTCNTRF = 0)) ";

            #endregion
            return retstring;
        }

        /// <summary>
        /// ����A�g�e�L�X�g���M���O���̓o�^�����B
        /// </summary>
        /// <param name="objectSalCprtSndLogWork">�o�^���锄��A�g�e�L�X�g���M���O���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : objectSalCprtSndLogWork �Ɋi�[����Ă��锄��A�g�e�L�X�g���M���O����o�^���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2013/06/26</br>
        public int WriteLog(ref object objectSalCprtSndLogWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                SalCprtSndLogListResultWork salCprtSndLogWork = objectSalCprtSndLogWork as SalCprtSndLogListResultWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = WriteLogProc(salCprtSndLogWork, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesCprtDB.WriteLog(ref object)", status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        ///����A�g�e�L�X�g���M���O���̓o�^����
        /// </summary>
        /// <param name="salCprtSndLogWork">�o�^���锄��A�g�e�L�X�g���M���O���</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : salCprtSndLogWork �Ɋi�[����Ă��锄��A�g�e�L�X�g���M���O����o�^���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        private int WriteLogProc(SalCprtSndLogListResultWork salCprtSndLogWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (salCprtSndLogWork != null)
                {
                    StringBuilder sqlText = new StringBuilder();

                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    # region [SELECT��]
                    sqlText.Append(" SELECT UPDATEDATETIMERF").Append( Environment.NewLine);
                    sqlText.Append(" FROM SALCPRTSNDLOGRF").Append(Environment.NewLine);
                    sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE").Append( Environment.NewLine);
                    sqlText.Append("   AND SECTIONCODERF=@FINDSECTIONCODE").Append( Environment.NewLine);
                    sqlText.Append("   AND AUTOSENDDIVRF=@FINDAUTOSENDDIV").Append(Environment.NewLine);
                    sqlText.Append("   AND SENDDATETIMESTARTRF=@FINDSENDDATETIMESTART").Append( Environment.NewLine);
                    sqlText.Append("   AND SENDOBJCUSTSTARTRF=@FINDSENDOBJCUSTSTART").Append(Environment.NewLine);
                    sqlCommand.CommandText = sqlText.ToString();
                    # endregion

                    //Prameter�I�u�W�F�N�g�̍쐬
                    sqlCommand.Parameters.Clear();
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.Int);
                    SqlParameter findParaAutoSendDiv = sqlCommand.Parameters.Add("@FINDAUTOSENDDIV", SqlDbType.NChar);
                    SqlParameter findParaSendDateTimeStart = sqlCommand.Parameters.Add("@FINDSENDDATETIMESTART", SqlDbType.BigInt);
                    SqlParameter findParaSendObjCustStart = sqlCommand.Parameters.Add("@FINDSENDOBJCUSTSTART", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salCprtSndLogWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(salCprtSndLogWork.SectionCode);
                    findParaAutoSendDiv.Value = SqlDataMediator.SqlSetInt32(salCprtSndLogWork.SAndEAutoSendDiv);
                    findParaSendDateTimeStart.Value = SqlDataMediator.SqlSetInt64(salCprtSndLogWork.SendDateTimeStart);
                    findParaSendObjCustStart.Value = SqlDataMediator.SqlSetInt32(salCprtSndLogWork.SendObjCustStart);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (_updateDateTime != salCprtSndLogWork.UpdateDateTime)
                        {
                            if (salCprtSndLogWork.UpdateDateTime == DateTime.MinValue)
                            {
                                // �V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            }
                            else
                            {
                                // �����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            }

                            return status;
                        }
                    }
                    else
                    {
                        // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (salCprtSndLogWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        # region [INSERT��]
                        sqlText = new StringBuilder();
                        sqlText.Append("INSERT INTO SALCPRTSNDLOGRF").Append(Environment.NewLine);
                        sqlText.Append("(").Append( Environment.NewLine);
                        sqlText.Append("  CREATEDATETIMERF").Append( Environment.NewLine);
                        sqlText.Append(" ,UPDATEDATETIMERF").Append( Environment.NewLine);
                        sqlText.Append(" ,ENTERPRISECODERF").Append( Environment.NewLine);
                        sqlText.Append(" ,FILEHEADERGUIDRF").Append( Environment.NewLine);
                        sqlText.Append(" ,UPDEMPLOYEECODERF").Append( Environment.NewLine);
                        sqlText.Append(" ,UPDASSEMBLYID1RF").Append( Environment.NewLine);
                        sqlText.Append(" ,UPDASSEMBLYID2RF").Append( Environment.NewLine);
                        sqlText.Append(" ,LOGICALDELETECODERF").Append( Environment.NewLine);
                        sqlText.Append(" ,SECTIONCODERF").Append( Environment.NewLine);
                        sqlText.Append(" ,AUTOSENDDIVRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDDATETIMESTARTRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDDATETIMEENDRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDOBJDATESTARTRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDOBJDATEENDRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDOBJCUSTSTARTRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDOBJCUSTENDRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDOBJDIVRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDRESULTSRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDERRORCONTENTSRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDSLIPCOUNTRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDSLIPDTLCNTRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDSLIPTOTALMNYRF").Append( Environment.NewLine);
                        sqlText.Append(")").Append( Environment.NewLine);
                        sqlText.Append("VALUES").Append( Environment.NewLine);
                        sqlText.Append("(").Append( Environment.NewLine);
                        sqlText.Append("  @CREATEDATETIME").Append( Environment.NewLine);
                        sqlText.Append(" ,@UPDATEDATETIME").Append( Environment.NewLine);
                        sqlText.Append(" ,@ENTERPRISECODE").Append( Environment.NewLine);
                        sqlText.Append(" ,@FILEHEADERGUID").Append( Environment.NewLine);
                        sqlText.Append(" ,@UPDEMPLOYEECODE").Append( Environment.NewLine);
                        sqlText.Append(" ,@UPDASSEMBLYID1").Append( Environment.NewLine);
                        sqlText.Append(" ,@UPDASSEMBLYID2").Append( Environment.NewLine);
                        sqlText.Append(" ,@LOGICALDELETECODE").Append(Environment.NewLine);
                        sqlText.Append(" ,@SECTIONCODE").Append(Environment.NewLine);
                        sqlText.Append(" ,@AUTOSENDDIV").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDDATETIMESTART").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDDATETIMEEND").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDOBJDATESTART").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDOBJDATEEND").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDOBJCUSTSTART").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDOBJCUSTEND").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDOBJDIV").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDRESULTS").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDERRORCONTENTS").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDSLIPCOUNT").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDSLIPDTLCNT").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDSLIPTOTALMNY").Append(Environment.NewLine);
                        sqlText.Append(")").Append( Environment.NewLine);
                        sqlCommand.CommandText = sqlText.ToString();
                        # endregion

                        // �o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)salCprtSndLogWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    # region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraAutoSendDiv = sqlCommand.Parameters.Add("@AUTOSENDDIV", SqlDbType.Int);
                    SqlParameter paraSendDateTimeStart = sqlCommand.Parameters.Add("@SENDDATETIMESTART", SqlDbType.BigInt);
                    SqlParameter paraSendDateTimeEnd = sqlCommand.Parameters.Add("@SENDDATETIMEEND", SqlDbType.BigInt);
                    SqlParameter paraSendObjDateStart = sqlCommand.Parameters.Add("@SENDOBJDATESTART", SqlDbType.BigInt);
                    SqlParameter paraSendObjDateEnd = sqlCommand.Parameters.Add("@SENDOBJDATEEND", SqlDbType.BigInt);
                    SqlParameter paraSendObjCustStart = sqlCommand.Parameters.Add("@SENDOBJCUSTSTART", SqlDbType.Int);
                    SqlParameter paraSendObjCustEnd = sqlCommand.Parameters.Add("@SENDOBJCUSTEND", SqlDbType.Int);
                    SqlParameter paraSendObjDiv = sqlCommand.Parameters.Add("@SENDOBJDIV", SqlDbType.Int);
                    SqlParameter paraSendResults = sqlCommand.Parameters.Add("@SENDRESULTS", SqlDbType.Int);
                    SqlParameter paraSendErrorContents = sqlCommand.Parameters.Add("@SENDERRORCONTENTS", SqlDbType.NVarChar);
                    SqlParameter paraSendSlipCount = sqlCommand.Parameters.Add("@SENDSLIPCOUNT", SqlDbType.Int);
                    SqlParameter paraSendSlipDtlCnt = sqlCommand.Parameters.Add("@SENDSLIPDTLCNT", SqlDbType.Int);
                    SqlParameter paraSendSlipTotalMny = sqlCommand.Parameters.Add("@SENDSLIPTOTALMNY", SqlDbType.BigInt);
                    # endregion

                    # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salCprtSndLogWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salCprtSndLogWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(salCprtSndLogWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(salCprtSndLogWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(salCprtSndLogWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(salCprtSndLogWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(salCprtSndLogWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(salCprtSndLogWork.LogicalDeleteCode);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(salCprtSndLogWork.SectionCode);
                    paraAutoSendDiv.Value = SqlDataMediator.SqlSetInt32(salCprtSndLogWork.SAndEAutoSendDiv);
                    paraSendDateTimeStart.Value = SqlDataMediator.SqlSetInt64(salCprtSndLogWork.SendDateTimeStart);
                    paraSendDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(salCprtSndLogWork.SendDateTimeEnd);
                    paraSendObjDateStart.Value = SqlDataMediator.SqlSetInt64(salCprtSndLogWork.SendObjDateStart);
                    paraSendObjDateEnd.Value = SqlDataMediator.SqlSetInt64(salCprtSndLogWork.SendObjDateEnd);
                    paraSendObjCustStart.Value = SqlDataMediator.SqlSetInt32(salCprtSndLogWork.SendObjCustStart);
                    paraSendObjCustEnd.Value = SqlDataMediator.SqlSetInt32(salCprtSndLogWork.SendObjCustEnd);
                    paraSendObjDiv.Value = SqlDataMediator.SqlSetInt32(salCprtSndLogWork.SendObjDiv);
                    paraSendResults.Value = SqlDataMediator.SqlSetInt32(salCprtSndLogWork.SendResults);
                    paraSendErrorContents.Value = SqlDataMediator.SqlSetString(salCprtSndLogWork.SendErrorContents);
                    paraSendSlipCount.Value = SqlDataMediator.SqlSetInt32(salCprtSndLogWork.SendSlipCount);
                    paraSendSlipDtlCnt.Value = SqlDataMediator.SqlSetInt32(salCprtSndLogWork.SendSlipDtlCnt);
                    paraSendSlipTotalMny.Value = SqlDataMediator.SqlSetInt64(salCprtSndLogWork.SendSlipTotalMny);

                    # endregion

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SalesCprtDB.WriteLogProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SalesCprtDB.WriteLogProc", status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            //SqlConnection����
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            //SqlConnection�ڑ�
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            //SqlConnection�Ԃ�
            return retSqlConnection;
        }

        /// <summary>
        /// SqlTransaction��������
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <returns>�������ꂽSqlTransaction�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlconnection)
        {
            SqlTransaction retSqlTransaction = null;

            if (sqlconnection != null)
            {
                // DB�ɐڑ�����Ă��Ȃ��ꍇ�͂����Őڑ�����
                if ((sqlconnection.State & ConnectionState.Open) == 0)
                {
                    sqlconnection.Open();
                }

                // �g�����U�N�V�����̐���(�J�n)
                retSqlTransaction = sqlconnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }

            return retSqlTransaction;
        }
        #endregion  //�R�l�N�V������������
    }
}
