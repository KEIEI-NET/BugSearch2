//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����f�[�^�e�L�X�g�o�́i�s�l�x�j
// �v���O�����T�v   : ����f�[�^�e�L�X�g�o�́i�s�l�x�j�@�����[�g�I�u�W�F�N�g 
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10805731-00 �쐬�S�� : ���N�n��
// �� �� ��  2011/10/31  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10805731-00 �쐬�S�� : ���N�n�� 							
// �C �� ��  2012/11/21  �C�����e : Redmine#33560�@ 							
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�d����ɂ��Ă̎d�l�ύX	
//                                  �A���Ӑ敪�̓R�[�h�U�̗L���ɂ��Ă̏C��
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
using Broadleaf.Library.Data.SqlTypes;
using System.Data;
using Broadleaf.Library.Data;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ����f�[�^�e�L�X�g�o�́i�s�l�x�jDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����f�[�^�e�L�X�g�o�́i�s�l�x�jDB�����[�g�I�u�W�F�N�g</br>										
    /// <br>Programmer : ���N�n��</br>										
    /// <br>Date       : 2012/10/31</br>										
    /// <br>�Ǘ��ԍ�   : 10805731-00</br>
    /// <br>Update Note: 2012/11/21 ���N�n��</br>
    /// <br>�Ǘ��ԍ�   : 10805731-00</br>
    /// <br>             Redmine#33560</br>
    /// <br>             �@�d����ɂ��Ă̎d�l�ύX</br>
    /// <br>�@�@�@�@�@�@ �A���Ӑ敪�̓R�[�h�U�̗L���ɂ��Ă̏C��</br> 
    /// </remarks>
    [Serializable]
    public class SalesSliptextResultDB : RemoteDB, ISalesSliptextResultDB
    {
        /// <summary>
        /// ����f�[�^�e�L�X�g�o�́i�s�l�x�j�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����f�[�^�e�L�X�g�o�́i�s�l�x�jDB�����[�g�I�u�W�F�N�g</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        public SalesSliptextResultDB()
            :
        base("PMKHN07707D", "Broadleaf.Application.Remoting.ParamData.SalesSliptextResultDB", "SALESHISTORYRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region Search
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔���f�[�^�e�L�X�g�o�́i�s�l�x�j�̑S�Ė߂鏈���i�_���폜�����j
        /// </summary>
        /// <param name="salesSliptextResultWork">��������</param>
        /// <param name="salesSliptextcndtnWork">�����p�����[�^</param>
        /// <param name="retMsg">retMsg</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔���f�[�^�e�L�X�g�o�́i�s�l�x�j�̑S�Ė߂鏈���i�_���폜�����j</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        public int Search(out object salesSliptextResultWork, object salesSliptextcndtnWork, out string retMsg)
        {
            SqlConnection sqlConnection = null;
            salesSliptextResultWork = null;
            retMsg = string.Empty;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection(true);

                return SearchProc(out salesSliptextResultWork, salesSliptextcndtnWork, ref sqlConnection);

            }
            catch (Exception ex)
            {
                retMsg = ex.Message;
                base.WriteErrorLog(ex, "SalesSliptextResultDB.Search");
                salesSliptextResultWork = new ArrayList();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (null != sqlConnection)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                else
                {
                    //�Ȃ��B
                } 
            }
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔���f�[�^�e�L�X�g�o�́i�s�l�x�j��S�Ė߂鏈��
        /// </summary>
        /// <param name="salesSliptextResultWork">��������</param>
        /// <param name="salesSliptextcndtnWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔���f�[�^�e�L�X�g�o�́i�s�l�x�j��S�Ė߂鏈��</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>Update Note: 2012/11/21 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>             Redmine#33560</br>
        /// <br>             �@�d����ɂ��Ă̎d�l�ύX</br>
        /// </remarks>
        private int SearchProc(out object salesSliptextResultWork, object salesSliptextcndtnWork, ref SqlConnection sqlConnection)
        {
            SalesSliptextCndtnWork cndtnWork = salesSliptextcndtnWork as SalesSliptextCndtnWork;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            salesSliptextResultWork = null;
            ArrayList al = new ArrayList();   //���o����

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);
                StringBuilder sb = new StringBuilder();

                sb.Append(" SELECT " + Environment.NewLine);
                sb.Append(" A.CUSTOMERCODERF, " + Environment.NewLine);
                sb.Append(" A.SALESDATERF," + Environment.NewLine);
                sb.Append(" A.SALESSLIPNUMRF," + Environment.NewLine);
                sb.Append(" B.GOODSNORF, " + Environment.NewLine);
                sb.Append(" B.GOODSMAKERCDRF, " + Environment.NewLine);
                sb.Append(" B.BLGOODSCODERF, " + Environment.NewLine);
                sb.Append(" B.SHIPMENTCNTRF, " + Environment.NewLine);
                sb.Append(" B.SUPPLIERCDRF, " + Environment.NewLine);
                sb.Append(" B.SALESROWNORF " + Environment.NewLine);
                sb.Append(" FROM ");
                sb.Append(" SALESHISTORYRF AS A WITH (READUNCOMMITTED) " + Environment.NewLine);  //���㗚���f�[�^�@A
                sb.Append(" INNER JOIN ");
                sb.Append(" SALESHISTDTLRF AS B WITH (READUNCOMMITTED) " + Environment.NewLine);  //���㗚�𖾍׃f�[�^ B
                sb.Append(" ON ");
                sb.Append(" A.ENTERPRISECODERF =  B.ENTERPRISECODERF " + Environment.NewLine);
                sb.Append(" AND ");
                sb.Append(" A.ACPTANODRSTATUSRF = B.ACPTANODRSTATUSRF " + Environment.NewLine);
                sb.Append(" AND ");
                sb.Append(" A.SALESSLIPNUMRF =  B.SALESSLIPNUMRF " + Environment.NewLine);
                sb.Append(" AND " + Environment.NewLine);
                //sb.Append(" B.LOGICALDELETECODERF = 0 " + Environment.NewLine);//DEL�@���N�n���@2012/11/21 Redmine33560
                //---ADD�@���N�n���@2012/11/21 Redmine33560--------------------->>>>>
                sb.Append(" A.LOGICALDELETECODERF = @LOGICALDELETECODEA " + Environment.NewLine);
                SqlParameter logicalDeleteCodeA = sqlCommand.Parameters.Add("@LOGICALDELETECODEA", SqlDbType.Int);
                logicalDeleteCodeA.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);
                sb.Append(" AND " + Environment.NewLine);
                sb.Append(" B.LOGICALDELETECODERF = @LOGICALDELETECODEB " + Environment.NewLine);
                SqlParameter logicalDeleteCodeB = sqlCommand.Parameters.Add("@LOGICALDELETECODEB", SqlDbType.Int);
                logicalDeleteCodeB.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);
                //---ADD�@���N�n���@2012/11/21 Redmine33560---------------------<<<<<
                sb.Append(" LEFT JOIN " + Environment.NewLine);
                sb.Append(" CUSTOMERRF AS C WITH (READUNCOMMITTED) " + Environment.NewLine);      //���Ӑ�}�X�^ C
                sb.Append(" ON ");
                sb.Append(" A.ENTERPRISECODERF =  C.ENTERPRISECODERF " + Environment.NewLine);
                sb.Append(" AND ");
                sb.Append(" A.CUSTOMERCODERF =  C.CUSTOMERCODERF " + Environment.NewLine);
                sb.Append(" LEFT JOIN ");
                sb.Append(" ACCEPTODRCARRF AS D WITH (READUNCOMMITTED)" + Environment.NewLine);   // �󒍃}�X�^�i�ԗ��j D
                sb.Append(" ON ");
                sb.Append(" B.ENTERPRISECODERF =  D.ENTERPRISECODERF " + Environment.NewLine);
                sb.Append(" AND ");
                sb.Append(" B.ACCEPTANORDERNORF =  D.ACCEPTANORDERNORF " + Environment.NewLine);
          
                sb.Append(" AND ");
                //�󒍃X�e�[�^�X���u7:����v
                sb.Append(" D.ACPTANODRSTATUSRF = @ACPTANODRSTATUSR " + Environment.NewLine);
                SqlParameter paraAcpt = sqlCommand.Parameters.Add("@ACPTANODRSTATUSR", SqlDbType.Int);
                paraAcpt.Value = SqlDataMediator.SqlSetInt(7);
                sb.Append(" AND ");
                //D.�f�[�^���̓V�X�e�����u10:PM�v�@�@�@
                sb.Append(" D.DATAINPUTSYSTEMRF = @DATAINPUTSYSTEM " + Environment.NewLine);
                SqlParameter paraDataInputSys = sqlCommand.Parameters.Add("@DATAINPUTSYSTEM", SqlDbType.Int);
                paraDataInputSys.Value = SqlDataMediator.SqlSetInt(10);
                //---DEL�@���N�n���@2012/11/21 Redmine33560--------------------->>>>>
                //sb.Append(" AND ");
                //sb.Append(" D.LOGICALDELETECODERF = 0 " + Environment.NewLine);
                //---DEL�@���N�n���@2012/11/21 Redmine33560---------------------<<<<<
              
                 // ��������
                sb.Append(MakeWhereString(ref sqlCommand, cndtnWork));

                sb.Append(" ORDER BY ");
                sb.Append(" A.SALESDATERF,A.CUSTOMERCODERF DESC,A.SALESSLIPNUMRF,B.SALESROWNORF  " + Environment.NewLine);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    SalesSliptextResultWork wkSalesSliptextResultWork = new SalesSliptextResultWork();
                    //�f�[�^���ʎ擾���e�i�[
                    wkSalesSliptextResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF")); //���Ӑ溰��
                    wkSalesSliptextResultWork.SalesDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESDATERF"));       //������t
                    wkSalesSliptextResultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));//����`�[�ԍ�
                    wkSalesSliptextResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));          //���i�ԍ�
                    wkSalesSliptextResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF")); //���i���[�J�[�R�[�h
                    wkSalesSliptextResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));   //BL���i�R�[�h
                    wkSalesSliptextResultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));  //�o�א�
                    wkSalesSliptextResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));     //�d����R�[�h
                    wkSalesSliptextResultWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));     //����s�ԍ�
                    #endregion

                    al.Add(wkSalesSliptextResultWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                if (al.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
                    //�Ȃ��B
                } 

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "SalesSliptextResultDB.SearchProc", status);
            }
            finally
            {
                if (null != myReader && !myReader.IsClosed)
                {
                    myReader.Close();
                }
                else
                {
                    //�Ȃ��B
                } 

                if (null != sqlCommand)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                else
                {
                    //�Ȃ��B
                } 
            }

            salesSliptextResultWork = al;

            return status;
        }
        #endregion

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="salesSliptextCndtnWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <remarks>
        /// <br>Note       : �������������񐶐��{�����l�ݒ�</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>Update Note: 2012/11/21 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>             Redmine#33560</br>
        /// <br>             �@�d����ɂ��Ă̎d�l�ύX</br>
        /// <br>�@�@�@�@�@�@ �A���Ӑ敪�̓R�[�h�U�̗L���ɂ��Ă̏C��</br> 
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesSliptextCndtnWork salesSliptextCndtnWork)
        {
            #region WHERE���쐬
            string retstring = " WHERE " + Environment.NewLine;
            string retstringor = "";

            //��ƃR�[�h
            retstring += " A.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(salesSliptextCndtnWork.EnterpriseCode);

            //---DEL�@���N�n���@2012/11/21 Redmine33560--------------------->>>>>
            //���㗚���f�[�^.�_���폜�敪
            //retstring += " AND A.LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
            //SqlParameter paraALogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            //paraALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
            //---DEL�@���N�n���@2012/11/21 Redmine33560---------------------<<<<<

            //�󒍃X�e�[�^�X
            retstring += " AND A.ACPTANODRSTATUSRF=@ACPTANODRSTATUS" + Environment.NewLine;
            SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
            paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(30);

            // AND �Ώۓ��t>���p�����[�^.�Ώۓ��̊J�n��																																	
            if (!DateTime.MinValue.Equals(salesSliptextCndtnWork.SalesDateSt))
            {
                retstring += " AND A.SALESDATERF>=@SALESDATEST " + Environment.NewLine;
                SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@SALESDATEST", SqlDbType.Int);
                paraSalesDateSt.Value = SqlDataMediator.SqlSetInt32(salesSliptextCndtnWork.SalesDateSt);
            }
            else
            {
                //�Ȃ��B
            } 

            // AND �Ώۓ��t<���p�����[�^.�Ώۓ��̏I����
            if (!DateTime.MinValue.Equals(salesSliptextCndtnWork.SalesDateEd))
            {
                retstring += " AND A.SALESDATERF<=@SALESDATEED " + Environment.NewLine;
                SqlParameter paraAddUpADateEd = sqlCommand.Parameters.Add("@SALESDATEED", SqlDbType.Int);
                paraAddUpADateEd.Value = SqlDataMediator.SqlSetInt32(salesSliptextCndtnWork.SalesDateEd);
            }
            else
            {
                //�Ȃ��B
            } 

            //B.���i���[�J�[�R�[�h>��1000
            retstring += " AND B.GOODSMAKERCDRF>=@GOODSMAKERCD" + Environment.NewLine;
            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(1000);


            //B.����`�[�敪�i���ׁj���u0:����v OR B.����`�[�敪�i���ׁj���u1:�ԕi�v
            retstring += " AND (B.SALESSLIPCDDTLRF = @SALESSLIPCDDTLRFA OR B.SALESSLIPCDDTLRF = @SALESSLIPCDDTLRFB)" + Environment.NewLine;
            SqlParameter paraSalesSlipCdDtl1= sqlCommand.Parameters.Add("@SALESSLIPCDDTLRFA", SqlDbType.Int);
            paraSalesSlipCdDtl1.Value = SqlDataMediator.SqlSetInt32(0);

            SqlParameter paraSalesSlipCdDtl2 = sqlCommand.Parameters.Add("@SALESSLIPCDDTLRFB", SqlDbType.Int);
            paraSalesSlipCdDtl2.Value = SqlDataMediator.SqlSetInt32(1);

            //---ADD�@���N�n���@2012/11/21 Redmine33560--------------------->>>>>
            //�d����R�[�h
            if (salesSliptextCndtnWork.SupplierCd != 0)
            {
                retstring += " AND B.SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt(salesSliptextCndtnWork.SupplierCd);
            }
            else
            {
                //�Ȃ��B
            }
            //---ADD�@���N�n���@2012/11/21 Redmine33560---------------------<<<<<

            //B.���i�ԍ� ���@NULL
            retstring += " AND B.GOODSNORF IS NOT NULL AND (" + Environment.NewLine;

            //�`�[���l�l������
            if (!string.IsNullOrEmpty(salesSliptextCndtnWork.SlipNote))
            {
                retstringor += " A.SLIPNOTERF LIKE @SLIPNOTE" + Environment.NewLine;
                SqlParameter paraSlipNote = sqlCommand.Parameters.Add("@SLIPNOTE", SqlDbType.NVarChar);
                paraSlipNote.Value = SqlDataMediator.SqlSetString(salesSliptextCndtnWork.SlipNote + "%");
            }
            else
            {
                //�Ȃ��B
            } 

            //�`�[���l�Q�l������
            if (!string.IsNullOrEmpty(salesSliptextCndtnWork.SlipNote2))
            {
                if (!string.IsNullOrEmpty(retstringor))
                {
                    retstringor += " OR ";
                }
                retstringor += "A.SLIPNOTE2RF LIKE @SLIPNOTE2" + Environment.NewLine;
                SqlParameter paraSlipNote2 = sqlCommand.Parameters.Add("@SLIPNOTE2", SqlDbType.NVarChar);
                paraSlipNote2.Value = SqlDataMediator.SqlSetString(salesSliptextCndtnWork.SlipNote2 + "%");
            }
            else
            {
                //�Ȃ��B
            } 

            //�`�[���l�R�l������
            if (!string.IsNullOrEmpty(salesSliptextCndtnWork.SlipNote3))
            {
                if (!string.IsNullOrEmpty(retstringor))
                {
                    retstringor += " OR ";
                }
                else
                {
                    //�Ȃ��B
                } 
                retstringor += "A.SLIPNOTE3RF LIKE @SLIPNOTE3" + Environment.NewLine;
                SqlParameter paraSlipNote3 = sqlCommand.Parameters.Add("@SLIPNOTE3", SqlDbType.NVarChar);
                paraSlipNote3.Value = SqlDataMediator.SqlSetString(salesSliptextCndtnWork.SlipNote3 + "%");
            }
            else
            {
                //�Ȃ��B
            } 

            //���Ӑ敪�̓R�[�h1�l������
            if (salesSliptextCndtnWork.CustAnalysCode1 != 0)
            {
                if (!string.IsNullOrEmpty(retstringor))
                {
                    retstringor += " OR ";
                }
                else
                {
                    //�Ȃ��B
                } 
                retstringor += "C.CUSTANALYSCODE1RF=@CUSTANALYSCODE1" + Environment.NewLine;
                SqlParameter paraCustAnalysCode1 = sqlCommand.Parameters.Add("@CUSTANALYSCODE1", SqlDbType.Int);
                paraCustAnalysCode1.Value = SqlDataMediator.SqlSetInt(salesSliptextCndtnWork.CustAnalysCode1);
            }
            else
            {
                //�Ȃ��B
            } 

            //���Ӑ敪�̓R�[�h2�l������
            if (salesSliptextCndtnWork.CustAnalysCode2 != 0)
            {
                if (!string.IsNullOrEmpty(retstringor))
                {
                    retstringor += " OR ";
                }
                else
                {
                    //�Ȃ��B
                } 
                retstringor += "C.CUSTANALYSCODE2RF=@CUSTANALYSCODE2" + Environment.NewLine;
                SqlParameter paraCustAnalysCode2 = sqlCommand.Parameters.Add("@CUSTANALYSCODE2", SqlDbType.Int);
                paraCustAnalysCode2.Value = SqlDataMediator.SqlSetInt(salesSliptextCndtnWork.CustAnalysCode2);
            }
            else
            {
                //�Ȃ��B
            } 

            //���Ӑ敪�̓R�[�h3�l������
            if (salesSliptextCndtnWork.CustAnalysCode3 != 0)
            {
                if (!string.IsNullOrEmpty(retstringor))
                {
                    retstringor += " OR ";
                }
                else
                {
                    //�Ȃ��B
                } 
                retstringor += "C.CUSTANALYSCODE3RF=@CUSTANALYSCODE3" + Environment.NewLine;
                SqlParameter paraCustAnalysCode3 = sqlCommand.Parameters.Add("@CUSTANALYSCODE3", SqlDbType.Int);
                paraCustAnalysCode3.Value = SqlDataMediator.SqlSetInt(salesSliptextCndtnWork.CustAnalysCode3);
            }
            else
            {
                //�Ȃ��B
            } 

            //���Ӑ敪�̓R�[�h4�l������
            if (salesSliptextCndtnWork.CustAnalysCode4 != 0)
            {
                if (!string.IsNullOrEmpty(retstringor))
                {
                    retstringor += " OR ";
                }
                else
                {
                    //�Ȃ��B
                } 
                retstringor += "C.CUSTANALYSCODE4RF=@CUSTANALYSCODE4" + Environment.NewLine;
                SqlParameter paraCustAnalysCode4 = sqlCommand.Parameters.Add("@CUSTANALYSCODE4", SqlDbType.Int);
                paraCustAnalysCode4.Value = SqlDataMediator.SqlSetInt(salesSliptextCndtnWork.CustAnalysCode4);
            }
            else
            {
                //�Ȃ��B
            } 

            //���Ӑ敪�̓R�[�h5�l������
            if (salesSliptextCndtnWork.CustAnalysCode5 != 0)
            {
                if (!string.IsNullOrEmpty(retstringor))
                {
                    retstringor += " OR ";
                }
                else
                {
                    //�Ȃ��B
                } 
                retstringor += "C.CUSTANALYSCODE5RF=@CUSTANALYSCODE5" + Environment.NewLine;
                SqlParameter paraCustAnalysCode5 = sqlCommand.Parameters.Add("@CUSTANALYSCODE5", SqlDbType.Int);
                paraCustAnalysCode5.Value = SqlDataMediator.SqlSetInt(salesSliptextCndtnWork.CustAnalysCode5);
            }
            else
            {
                //�Ȃ��B
            } 

            //���Ӑ敪�̓R�[�h6�l������
            if (salesSliptextCndtnWork.CustAnalysCode6 != 0)
            {
                if (!string.IsNullOrEmpty(retstringor))
                {
                    retstringor += " OR ";
                }
                else
                {
                    //�Ȃ��B
                } 
                //retstringor += "C.CUSTANALYSCODE5RF=@CUSTANALYSCODE6" + Environment.NewLine;//DEL�@���N�n���@2012/11/21 Redmine33560
                retstringor += "C.CUSTANALYSCODE6RF=@CUSTANALYSCODE6" + Environment.NewLine;//ADD�@���N�n���@2012/11/21 Redmine33560
                SqlParameter paraCustAnalysCode6 = sqlCommand.Parameters.Add("@CUSTANALYSCODE6", SqlDbType.Int);
                paraCustAnalysCode6.Value = SqlDataMediator.SqlSetInt(salesSliptextCndtnWork.CustAnalysCode6);
            }
            else
            {
                //�Ȃ��B
            } 

            //���q�Ǘ��R�[�h
            if (!string.IsNullOrEmpty(salesSliptextCndtnWork.CarMngNo1))
            {
                if (!string.IsNullOrEmpty(retstringor))
                {
                    retstringor += " OR ";
                }
                else
                {
                    //�Ȃ��B
                }
                retstringor += "D.CARMNGCODERF=@CARMNGCODE" + Environment.NewLine;
                SqlParameter paraCarMngNo1 = sqlCommand.Parameters.Add("@CARMNGCODE", SqlDbType.NVarChar);
                paraCarMngNo1.Value = SqlDataMediator.SqlSetString(salesSliptextCndtnWork.CarMngNo1);
            }
            else
            {
                //�Ȃ��B
            } 

            //---DEL�@���N�n���@2012/11/21 Redmine33560--------------------->>>>>
            //�d����R�[�h
            //if (salesSliptextCndtnWork.SupplierCd != 0)
            //{
            //    if (!string.IsNullOrEmpty(retstringor))
            //    {
            //        retstringor += " OR ";
            //    }
            //    else
            //    {
            //        //�Ȃ��B
            //    } 
            //    retstringor += "B.SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
            //    SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
            //    paraSupplierCd.Value = SqlDataMediator.SqlSetInt(salesSliptextCndtnWork.SupplierCd);
            //}
            //else
            //{
            //    //�Ȃ��B
            //}
            //---DEL�@���N�n���@2012/11/21 Redmine33560---------------------<<<<<

            //�����`�[�ԍ�
            if (!string.IsNullOrEmpty(salesSliptextCndtnWork.PartySaleSlipNum))
            {
                if (!string.IsNullOrEmpty(retstringor))
                {
                    retstringor += " OR ";
                }
                else
                {
                    //�Ȃ��B
                } 
                retstringor += "A.PARTYSALESLIPNUMRF=@PARTYSALESLIPNUMRF" + Environment.NewLine;
                SqlParameter paraPartySaleSlipNum = sqlCommand.Parameters.Add("@PARTYSALESLIPNUMRF", SqlDbType.NVarChar);
                paraPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(salesSliptextCndtnWork.PartySaleSlipNum);
            }
            else
            {
                //�Ȃ��B
            } 
            retstring += retstringor;
            retstring += " )";
            #endregion
            return retstring;
        }

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Note       : SqlConnection��������</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
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
                else
                {
                    //�Ȃ��B
                } 
            }
            else
            {
                //�Ȃ��B
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
        /// <br>Note       : SqlTransaction��������</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
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
                else
                {
                    //�Ȃ��B
                } 

                // �g�����U�N�V�����̐���(�J�n)
                retSqlTransaction = sqlconnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }
            else
            {
                //�Ȃ��B
            } 

            return retSqlTransaction;
        }
        #endregion  //�R�l�N�V������������
    }
}
