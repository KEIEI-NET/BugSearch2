//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����f�[�^�e�L�X�g�o�̓����[�g�I�u�W�F�N�g
// �v���O�����T�v   : ����f�[�^�e�L�X�g�o�͂��s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// �Ǘ��ԍ�  11370098-00  �쐬�S�� : ���O
// �� �� ��  2017/11/20   �C�����e : �V�K�쐬
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
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ����f�[�^�e�L�X�gDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����f�[�^�e�L�X�g�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2017/11/20</br>
    /// </remarks>
    [Serializable]
    public class EDISalesResultDB : RemoteDB, IEDISalesResultDB
    {
        #region
        /// <summary>
        /// ����f�[�^�e�L�X�g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/20</br>
        /// </remarks>
        public EDISalesResultDB()
            :
        base("PMEDI02016D", "Broadleaf.Application.Remoting.ParamData.EDISalesResultWork", "SALESHISTORYRF") //���N���X�̃R���X�g���N�^
        {
        }
        #endregion

        #region const
        /// <summary>�󒍃X�e�[�^�X�i30�F����j</summary>
        private const int SalesAcptAnOdrStatus = 30;
        /// <summary>�ԓ`�敪(0:���`)</summary>
        private const int DebitNoteDiv = 0;
        /// <summary>�󒍃}�X�^�i�ԗ��j.�󒍃X�e�[�^�X�i7�F����j</summary>
        private const int SalesAcceptStatusCar = 7;
        /// <summary>�󒍃}�X�^�i�ԗ��j.�f�[�^���̓V�X�e���i10�FPM�j</summary>
        private const int DataInputSystemPm = 10;
        // ����`�[�敪�i���ׁj(0:����)
        private const int SalesSlipCdDtl = 0;
        // ����`�[�敪�i���ׁj(1:�ԕi)
        private const int RetSlipCdDtl = 1;
        #endregion

        #region Search
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔���f�[�^�e�L�X�g�̑S�Ė߂鏈���i�_���폜�����j
        /// </summary>
        /// <param name="eDISalesResultObj">��������</param>
        /// <param name="eDISalesCndtnObj">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔���f�[�^LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/20</br>
        /// </remarks>
        public int Search(out object eDISalesResultObj, object eDISalesCndtnObj)
        {
            SqlConnection sqlConnection = null;
            eDISalesResultObj = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �R�l�N�V��������
            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    status = SearchProc(out eDISalesResultObj, eDISalesCndtnObj, ref sqlConnection);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "EDISalesResultDB.Search Exception=" + ex.Message, status);
                }
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔���f�[�^�e�L�X�g��S�Ė߂鏈��
        /// </summary>
        /// <param name="eDISalesResultObj">��������</param>
        /// <param name="eDISalesCndtnObj">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎d���f�[�^LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/20</br>
        /// </remarks>
        private int SearchProc(out object eDISalesResultObj, object eDISalesCndtnObj, ref SqlConnection sqlConnection)
        {
            EDISalesCndtnWork cndtnWork = eDISalesCndtnObj as EDISalesCndtnWork;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ArrayList al = new ArrayList();   //���o����
            eDISalesResultObj = null;
            SqlCommand sqlCommand = null;
            using (sqlCommand = new SqlCommand("", sqlConnection))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(" SELECT ");
                    sb.AppendLine(" A.CREATEDATETIMERF, ");
                    sb.AppendLine(" A.ENTERPRISECODERF, ");
                    sb.AppendLine(" A.ACPTANODRSTATUSRF, ");
                    sb.AppendLine(" A.SALESSLIPNUMRF, ");
                    sb.AppendLine(" A.SALESSLIPCDRF, ");
                    sb.AppendLine(" A.RESULTSADDUPSECCDRF, ");
                    sb.AppendLine(" A.SALESDATERF, ");
                    sb.AppendLine(" A.CUSTOMERCODERF, ");
                    sb.AppendLine(" A.SALESEMPLOYEENMRF, ");
                    sb.AppendLine(" A.SLIPNOTERF, ");
                    sb.AppendLine(" B.SALESROWNORF, ");
                    sb.AppendLine(" B.GOODSMAKERCDRF, ");
                    sb.AppendLine(" B.GOODSNORF, ");
                    sb.AppendLine(" B.GOODSNAMEKANARF, ");
                    sb.AppendLine(" B.BLGOODSCODERF, ");
                    sb.AppendLine(" B.SALESUNPRCTAXEXCFLRF, ");
                    sb.AppendLine(" B.SHIPMENTCNTRF, ");
                    sb.AppendLine(" B.SALESMONEYTAXEXCRF, ");
                    sb.AppendLine(" B.LISTPRICETAXEXCFLRF, ");
                    sb.AppendLine(" C.FULLMODELRF, ");
                    sb.AppendLine(" C.MODELHALFNAMERF, ");
                    sb.AppendLine(" D.ENTERPRISECODERF AS EDIENTERPRISECODERF, ");
                    sb.AppendLine(" D.ACPTANODRSTATUSRF AS EDIACPTANODRSTATUSRF, ");
                    sb.AppendLine(" D.SALESSLIPNUMRF AS EDISALESSLIPNUMRF, ");
                    sb.AppendLine(" D.SALESCREATEDATETIMERF AS EDISALESCREATEDATETIMERF, ");
                    sb.AppendLine(" E.SECTIONCODERF, ");         // ���_�R�[�h
                    sb.AppendLine(" E.CUSTOMERCODERF AS  EDICUSTOMERCODERF, ");        // ���Ӑ�R�[�h
                    sb.AppendLine(" E.COOPERATOFFICECODERF, ");  // �A�g���Ə��R�[�h
                    sb.AppendLine(" E.COOPERATCUSTCODERF,");     // �A�g���Ӑ�R�[�h
                    sb.AppendLine(" E.TRADCOMPCDRF, ");          // ���i���R�[�h
                    sb.AppendLine(" E.TRADCOMPNAMERF, ");        // ���i������
                    sb.AppendLine(" E.GOODSCODERF, ");           // ���i�R�[�h
                    sb.AppendLine(" E.INCREASEBLGOODSCODERF, ");    // �l��BL���i�R�[�h
                    sb.AppendLine(" E.DISCOUNTBLGOODSCODERF ");    // �l��BL���i�R�[�h

                    sb.AppendLine(" FROM SALESHISTORYRF A WITH (READUNCOMMITTED)");

                    sb.AppendLine(" INNER JOIN SALESHISTDTLRF B WITH (READUNCOMMITTED) ");
                    sb.AppendLine(" ON A.ENTERPRISECODERF =  B.ENTERPRISECODERF ");
                    sb.AppendLine(" AND A.ACPTANODRSTATUSRF = B.ACPTANODRSTATUSRF ");
                    sb.AppendLine(" AND A.SALESSLIPNUMRF =  B.SALESSLIPNUMRF ");
                    sb.AppendLine(" AND A.LOGICALDELETECODERF = B.LOGICALDELETECODERF ");

                    sb.AppendLine(" INNER JOIN ACCEPTODRCARRF C WITH (READUNCOMMITTED)");
                    sb.AppendLine(" ON A.ENTERPRISECODERF = C.ENTERPRISECODERF ");
                    sb.AppendLine(" AND B.ACCEPTANORDERNORF = C.ACCEPTANORDERNORF ");
                    sb.AppendLine(" AND A.ACPTANODRSTATUSRF = " + SalesAcptAnOdrStatus);
                    sb.AppendLine(" AND C.ACPTANODRSTATUSRF = " + SalesAcceptStatusCar);
                    sb.AppendLine(" AND C.DATAINPUTSYSTEMRF = " + DataInputSystemPm);
                    sb.AppendLine(" AND C.LOGICALDELETECODERF = " + (int)ConstantManagement.LogicalMode.GetData0);

                    sb.AppendLine(" INNER JOIN EDICOOPERATSTRF E WITH (READUNCOMMITTED)");
                    sb.AppendLine(" ON A.ENTERPRISECODERF =  E.ENTERPRISECODERF ");
                    sb.AppendLine(" AND A.RESULTSADDUPSECCDRF =  E.SECTIONCODERF ");
                    sb.AppendLine(" AND A.CUSTOMERCODERF =  E.CUSTOMERCODERF ");
                    sb.AppendLine(" AND E.LOGICALDELETECODERF = " + (int)ConstantManagement.LogicalMode.GetData0);

                    sb.AppendLine(" LEFT JOIN EDISALEXTRDTRF D WITH (READUNCOMMITTED)");
                    sb.AppendLine(" ON A.ENTERPRISECODERF =  D.ENTERPRISECODERF ");
                    sb.AppendLine(" AND A.ACPTANODRSTATUSRF = D.ACPTANODRSTATUSRF ");
                    sb.AppendLine(" AND A.SALESSLIPNUMRF = D.SALESSLIPNUMRF ");
                    sb.AppendLine(" AND D.LOGICALDELETECODERF = " + (int)ConstantManagement.LogicalMode.GetData0);

                    // ��������
                    sb.AppendLine(MakeWhereString(ref sqlCommand, cndtnWork));

                    sb.AppendLine(" ORDER BY ");
                    sb.AppendLine(" A.RESULTSADDUPSECCDRF,A.CUSTOMERCODERF,A.SALESSLIPNUMRF,B.SALESROWNORF ");

                    sqlCommand.CommandText = sb.ToString();

                    // �N�G�����s���̃^�C���A�E�g���Ԃ�3600�b�ɐݒ肷��
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            EDISalesResultWork eDISalesResultWork = new EDISalesResultWork();
                            eDISalesResultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                            eDISalesResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                            eDISalesResultWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                            eDISalesResultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                            eDISalesResultWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
                            eDISalesResultWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
                            eDISalesResultWork.SalesDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESDATERF"));
                            eDISalesResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                            eDISalesResultWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
                            eDISalesResultWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
                            eDISalesResultWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
                            eDISalesResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                            eDISalesResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                            eDISalesResultWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                            eDISalesResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                            eDISalesResultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                            eDISalesResultWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                            eDISalesResultWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                            eDISalesResultWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                            eDISalesResultWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));
                            eDISalesResultWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));
                            eDISalesResultWork.EDIEnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EDIENTERPRISECODERF"));
                            eDISalesResultWork.EDIAcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDIACPTANODRSTATUSRF"));
                            eDISalesResultWork.EDISalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EDISALESSLIPNUMRF"));
                            eDISalesResultWork.EDISalesCreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("EDISALESCREATEDATETIMERF"));
                            eDISalesResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                            eDISalesResultWork.EDICustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDICUSTOMERCODERF"));
                            eDISalesResultWork.CooperatOfficeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COOPERATOFFICECODERF"));
                            eDISalesResultWork.CooperatCustCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COOPERATCUSTCODERF"));
                            eDISalesResultWork.TradCompCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRADCOMPCDRF"));
                            eDISalesResultWork.TradCompName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRADCOMPNAMERF"));
                            eDISalesResultWork.GoodsCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSCODERF"));
                            eDISalesResultWork.IncreaseBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INCREASEBLGOODSCODERF"));
                            eDISalesResultWork.DiscountBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISCOUNTBLGOODSCODERF"));
                            al.Add(eDISalesResultWork);

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }

                        if (al.Count == 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                    }

                }
                catch (SqlException ex)
                {
                    // ���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "EDICooperatStDB.SearchProc Exception=" + ex.Message, status);
                }
            }
            eDISalesResultObj = al;
            return status;
        }
        #endregion

        #region Update
        /// <summary>
        /// ���㒊�o�f�[�^����ǉ��X�V�����B
        /// </summary>
        /// <param name="eDISalesResultWorkObj">�ǉ��E�X�V���锄�㒊�o�f�[�^���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDISalesResultWorkObj �Ɋi�[����Ă��锄�㒊�o�f�[�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/20</br>
        /// </remarks>
        public int Write(ref object eDISalesResultWorkObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            // �R�l�N�V��������
            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    ArrayList eDISalesResultList = eDISalesResultWorkObj as ArrayList;
                    // �g�����U�N�V�����J�n
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                    foreach (EDISalesResultWork detailWork in eDISalesResultList)
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
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "EDICooperatStDB.Write Exception=" + ex.Message, status);
                }
                finally
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �R�~�b�g
                        sqlTransaction.Commit();
                    }
                    else
                    {
                        // ���[���o�b�N
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }

                    if (sqlTransaction != null) sqlTransaction.Dispose();
                }
            }
            return status;

        }

        /// <summary>
        ///���㒊�o�f�[�^���𕨗��폜����
        /// </summary>
        /// <param name="eDISalesResultWork">���㒊�o�f�[�^�����i�[����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDISalesResultWork �Ɋi�[����Ă��锄�㒊�o�f�[�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/20</br>
        /// </remarks>
        private int DeleteProc(EDISalesResultWork eDISalesResultWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction))
            {
                try
                {
                    StringBuilder sqlTextDel = new StringBuilder();
                    #region
                    sqlTextDel.AppendLine(" DELETE ");
                    sqlTextDel.AppendLine(" FROM ");
                    sqlTextDel.AppendLine(" EDISALEXTRDTRF");
                    sqlTextDel.AppendLine(" WHERE ");
                    sqlTextDel.AppendLine(" ENTERPRISECODERF=@FINDENTERPRISECODE ");
                    sqlTextDel.AppendLine(" AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS ");
                    sqlTextDel.AppendLine(" AND SALESSLIPNUMRF=@FINDSALESSLIPNUM ");
                    #endregion
                    sqlCommand.CommandText = sqlTextDel.ToString();

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                    SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(eDISalesResultWork.EnterpriseCode);
                    findParaSalesSlipNum.Value = SqlDataMediator.SqlSetString(eDISalesResultWork.SalesSlipNum);
                    findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(eDISalesResultWork.AcptAnOdrStatus);

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException sqlex)
                {
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(sqlex, "EDISalesResultDB.DeleteProc", status);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "EDICooperatStDB.DeleteProc Exception=" + ex.Message, status);
                }
            }

            return status;
        }

        /// <summary>
        ///���㒊�o�f�[�^����ǉ�����
        /// </summary>
        /// <param name="eDISalesResultWork">���㒊�o�f�[�^�����i�[����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDISalesResultWork �Ɋi�[����Ă��锄�㒊�o�f�[�^����ǉ����܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/20</br>
        /// </remarks>
        private int InsertProc(EDISalesResultWork eDISalesResultWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction))
            {
                try
                {
                    //���㒊�o�f�[�^. ����f�[�^�쐬����
                    DateTime salesCreateDateTime = eDISalesResultWork.CreateDateTime; 
                    StringBuilder sqlText = new StringBuilder();
                    #region
                    sqlText.AppendLine(" INSERT INTO ");
                    sqlText.AppendLine(" EDISALEXTRDTRF");
                    sqlText.AppendLine(" (CREATEDATETIMERF, ");
                    sqlText.AppendLine(" UPDATEDATETIMERF, ");
                    sqlText.AppendLine(" ENTERPRISECODERF, ");
                    sqlText.AppendLine(" FILEHEADERGUIDRF, ");
                    sqlText.AppendLine(" UPDEMPLOYEECODERF, ");
                    sqlText.AppendLine(" UPDASSEMBLYID1RF, ");
                    sqlText.AppendLine(" UPDASSEMBLYID2RF, ");
                    sqlText.AppendLine(" LOGICALDELETECODERF, ");
                    sqlText.AppendLine(" ACPTANODRSTATUSRF, ");
                    sqlText.AppendLine(" SALESSLIPNUMRF, ");
                    sqlText.AppendLine(" SALESCREATEDATETIMERF) ");

                    sqlText.AppendLine(" VALUES ");
                    sqlText.AppendLine(" (@CREATEDATETIME, ");
                    sqlText.AppendLine(" @UPDATEDATETIME, ");
                    sqlText.AppendLine(" @ENTERPRISECODE, ");
                    sqlText.AppendLine(" @FILEHEADERGUID, ");
                    sqlText.AppendLine(" @UPDEMPLOYEECODE, ");
                    sqlText.AppendLine(" @UPDASSEMBLYID1, ");
                    sqlText.AppendLine(" @UPDASSEMBLYID2, ");
                    sqlText.AppendLine(" @LOGICALDELETECODE, ");
                    sqlText.AppendLine(" @ACPTANODRSTATUS, ");
                    sqlText.AppendLine(" @SALESSLIPNUM, ");
                    sqlText.AppendLine(" @SALESCREATEDATETIME) ");

                    #endregion
                    sqlCommand.CommandText = sqlText.ToString();

                    // �o�^�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)eDISalesResultWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);

                    //Prameter�I�u�W�F�N�g�̍쐬
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

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(eDISalesResultWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(eDISalesResultWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(eDISalesResultWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(eDISalesResultWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(eDISalesResultWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(eDISalesResultWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(eDISalesResultWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(eDISalesResultWork.LogicalDeleteCode);
                    paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(eDISalesResultWork.AcptAnOdrStatus);
                    paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(eDISalesResultWork.SalesSlipNum);
                    paraSalesCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesCreateDateTime);

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException sqlex)
                {
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(sqlex, "EDISalesResultDB.InsertProc", status);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "EDICooperatStDB.InsertProc Exception==" + ex.Message, status);
                }
            }

            return status;
        }

        #endregion

        #region
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="eDISalesCndtnWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <remarks>
        /// <br>Note       : �������������񐶐��{�����l�ݒ���s���B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/20</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, EDISalesCndtnWork eDISalesCndtnWork)
        {
            #region WHERE���쐬
            string retstring = " WHERE ";

            // ��ƃR�[�h
            retstring += " A.ENTERPRISECODERF=@ENTERPRISECODERF";
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODERF", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(eDISalesCndtnWork.EnterpriseCode);

            // ���㗚���f�[�^.�_���폜�敪
            retstring += " AND A.LOGICALDELETECODERF=@ALOGICALDELETECODERF";
            SqlParameter paraALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODERF", SqlDbType.Int);
            paraALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);

            // �󒍃X�e�[�^�X
            retstring += " AND A.ACPTANODRSTATUSRF=@ACPTANODRSTATUSRF";
            SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUSRF", SqlDbType.Int);
            paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(SalesAcptAnOdrStatus);

            // ���_�R�[�h    ���z��ŕ����w�肳���
            if (eDISalesCndtnWork.SectionCodeList != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in eDISalesCndtnWork.SectionCodeList)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }

                if (sectionCodestr != "")
                {
                    retstring += " AND A.RESULTSADDUPSECCDRF IN (" + sectionCodestr + ") ";
                }
            }

            // AND ������t>���p�����[�^.������t�̊J�n��
            if (!DateTime.MinValue.Equals(eDISalesCndtnWork.AddUpADateSt))
            {
                retstring += " AND A.SALESDATERF>=@ST_SCVDAY ";
                SqlParameter paraStCsvDate = sqlCommand.Parameters.Add("@ST_SCVDAY", SqlDbType.Int);
                paraStCsvDate.Value = SqlDataMediator.SqlSetInt32(eDISalesCndtnWork.AddUpADateSt);
            }

            // AND ������t<���p�����[�^.������t�̏I����
            if (!DateTime.MinValue.Equals(eDISalesCndtnWork.AddUpADateEd))
            {
                retstring += " AND A.SALESDATERF<=@ED_SCVDAY ";
                SqlParameter paraEdCsvDate = sqlCommand.Parameters.Add("@ED_SCVDAY", SqlDbType.Int);
                paraEdCsvDate.Value = SqlDataMediator.SqlSetInt32(eDISalesCndtnWork.AddUpADateEd);
            }

            // AND ���Ӑ�R�[�h>���p�����[�^.���Ӑ�R�[�h�̊J�n
            if (0 != eDISalesCndtnWork.CustomerCodeSt)
            {
                retstring += " AND A.CUSTOMERCODERF>=@ST_CUSTOMERCODE ";
                SqlParameter ParaStCustomerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCODE", SqlDbType.Int);
                ParaStCustomerCode.Value = SqlDataMediator.SqlSetInt32(eDISalesCndtnWork.CustomerCodeSt);
            }

            // AND ���Ӑ�R�[�h<���p�����[�^.���Ӑ�R�[�h�̏I��
            if (0 != eDISalesCndtnWork.CustomerCodeEd)
            {
                retstring += " AND A.CUSTOMERCODERF<=@ED_CUSTOMERCODE ";
                SqlParameter ParaEdCustomerCode = sqlCommand.Parameters.Add("@ED_CUSTOMERCODE", SqlDbType.Int);
                ParaEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(eDISalesCndtnWork.CustomerCodeEd);
            }
            // �ԓ`�敪
            retstring += " AND A.DEBITNOTEDIVRF=@DEBITNOTEDIVRF";
            SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@DEBITNOTEDIVRF", SqlDbType.Int);
            paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(DebitNoteDiv);

            // ����`�[�敪�i���ׁj(0:����,1:�ԕi)
            retstring += " AND B.SALESSLIPCDDTLRF IN (@SALESSLIPCDDTL, @RETSLIPCDDTL)";
            SqlParameter paraSalesSlipCdDtl = sqlCommand.Parameters.Add("@SALESSLIPCDDTL", SqlDbType.Int);
            paraSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(SalesSlipCdDtl);
            SqlParameter paraRetSlipCdDtl = sqlCommand.Parameters.Add("@RETSLIPCDDTL", SqlDbType.Int);
            paraRetSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(RetSlipCdDtl);

            #endregion
            return retstring;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Note       : SqlConnection�����������s���B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/20</br>
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
        #endregion  //�R�l�N�V������������
    }
}
