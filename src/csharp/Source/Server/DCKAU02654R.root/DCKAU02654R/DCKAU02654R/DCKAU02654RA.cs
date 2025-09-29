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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �^�M�Ǘ��\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �^�M�Ǘ��\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2007.11.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class CreditMngListWorkDB : RemoteDB, ICreditMngListWorkDB
    {
        /// <summary>
        /// �^�M�Ǘ��\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.15</br>
        /// </remarks>
        public CreditMngListWorkDB()
            :
            base("DCKAU02656D", "Broadleaf.Application.Remoting.ParamData.CreditMngListResultWork", "CUSTOMERCHANGERF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̗^�M�Ǘ��\��߂��܂�
        /// </summary>
        /// <param name="creditMngListResultWork">��������</param>
        /// <param name="creditMngListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̗^�M�Ǘ��\��߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.15</br>
        public int Search(out object creditMngListResultWork, object creditMngListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            creditMngListResultWork = null;

            CreditMngListCndtnWork _creditMngListCndtnWork = creditMngListCndtnWork as CreditMngListCndtnWork;

            try
            {
                status = SearchProc(out creditMngListResultWork, _creditMngListCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CreditMngListWorkDB.Search Exception=" + ex.Message);
                creditMngListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̗^�M�Ǘ��\LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="creditMngListResultWork">��������</param>
        /// <param name="_creditMngListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̗^�M�Ǘ��\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.15</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.15 ���� DC.NS�p�ɏC��</br>
        private int SearchProc(out object creditMngListResultWork, CreditMngListCndtnWork _creditMngListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            creditMngListResultWork = null;

            ArrayList al = new ArrayList();   //���o����

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();


                status = SearchCreditMngProc(ref al, ref sqlConnection, _creditMngListCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CreditMngListWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            creditMngListResultWork = al;

            return status;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_creditMngListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int SearchCreditMngProc(ref ArrayList al, ref SqlConnection sqlConnection, CreditMngListCndtnWork _creditMngListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Select���쐬
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  CUSCH.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += " ,CUSCH.CUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += " ,CUSCH.CREDITMONEYRF" + Environment.NewLine;
                selectTxt += " ,CUSCH.WARNINGCREDITMONEYRF" + Environment.NewLine;
                //selectTxt += " ,ROUND(CAST(CUSCH.PRSNTACCRECBALANCERF AS FLOAT)/CAST(CUSCH.CREDITMONEYRF AS FLOAT)*100,2) AS CREDITRATERF" + Environment.NewLine;
                selectTxt += " ,CUSCH.PRSNTACCRECBALANCERF" + Environment.NewLine;
                selectTxt += " ,CUST.CUSTOMERAGENTCDRF" + Environment.NewLine;
                selectTxt += " ,CUST.CUSTOMERAGENTNMRF" + Environment.NewLine;
                selectTxt += " ,CUST.MNGSECTIONCODERF" + Environment.NewLine;
                selectTxt += " ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "FROM CUSTOMERCHANGERF AS CUSCH" + Environment.NewLine;
                selectTxt += "LEFT JOIN CUSTOMERRF AS CUST" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      CUST.ENTERPRISECODERF=CUSCH.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND CUST.CUSTOMERCODERF=CUSCH.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      SEC.ENTERPRISECODERF=CUST.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND SEC.SECTIONCODERF=CUST.MNGSECTIONCODERF" + Environment.NewLine;

                //WHERE���̍쐬
                selectTxt += MakeWhereString(ref sqlCommand, _creditMngListCndtnWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                #endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    //�^�M������
                    /*           
                    if (_creditMngListCndtnWork.CreditRate > 0)
                    {
                        if (SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CREDITRATERF")) < _creditMngListCndtnWork.CreditRate)
                        {
                          continue;
                        }
                    }
                    */
                    
                    #region ���o����-�l�Z�b�g
                    CreditMngListResultWork wkCreditMngListResultWork = new CreditMngListResultWork();

                    //�i�[����
                    wkCreditMngListResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    wkCreditMngListResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    wkCreditMngListResultWork.CreditMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CREDITMONEYRF"));
                    wkCreditMngListResultWork.WarningCreditMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("WARNINGCREDITMONEYRF"));
                    wkCreditMngListResultWork.PrsntAccRecBalance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PRSNTACCRECBALANCERF"));
                    //wkCreditMngListResultWork.CreditRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CREDITRATERF"));
                    wkCreditMngListResultWork.CustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"));
                    wkCreditMngListResultWork.CustomerAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTNMRF"));
                    wkCreditMngListResultWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
                    wkCreditMngListResultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));

                    #endregion

                    al.Add(wkCreditMngListResultWork);

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
                base.WriteErrorLog(ex, "CreditMngListWorkDB.SearchCreditMngProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_creditMngListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, CreditMngListCndtnWork _creditMngListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = "WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " CUSCH.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_creditMngListCndtnWork.EnterpriseCode);

            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND CUSCH.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND CUSCH.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //���_�R�[�h
            if (_creditMngListCndtnWork.SectionCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _creditMngListCndtnWork.SectionCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }
                if (sectionCodestr != "")
                {
                    retstring += " AND CUST.MNGSECTIONCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //�S���҃R�[�h�ݒ�
            if (_creditMngListCndtnWork.St_AgentCd != "")
            {
                retstring += " AND CUST.CUSTOMERAGENTCDRF>=@STCUSTOMERAGENTCD" + Environment.NewLine;
                SqlParameter paraStSalesEmployeeCd = sqlCommand.Parameters.Add("@STCUSTOMERAGENTCD", SqlDbType.NChar);
                paraStSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(_creditMngListCndtnWork.St_AgentCd);
            }
            if (_creditMngListCndtnWork.Ed_AgentCd != "")
            {
                retstring += " AND (CUST.CUSTOMERAGENTCDRF<=@EDCUSTOMERAGENTCD OR CUST.CUSTOMERAGENTCDRF LIKE @EDCUSTOMERAGENTCD)" + Environment.NewLine;
                SqlParameter paraEdSalesEmployeeCd = sqlCommand.Parameters.Add("@EDCUSTOMERAGENTCD", SqlDbType.NChar);
                paraEdSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(_creditMngListCndtnWork.Ed_AgentCd + "%");
            }

            /*  �t�h���Ŕ��f����׍폜
            //�^�M���x�z�ݒ�
            if (_creditMngListCndtnWork.CreditMoney > 0)
            {
                retstring += " AND CUSCH.CREDITMONEYRF>=@CREDITMONEY" + Environment.NewLine;
                SqlParameter paraStCreditMoney = sqlCommand.Parameters.Add("@CREDITMONEY", SqlDbType.Int);
                paraStCreditMoney.Value = SqlDataMediator.SqlSetInt64(_creditMngListCndtnWork.CreditMoney);
            }
            */
            #endregion
            return retstring;
        }
    }
}
