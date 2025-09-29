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
using Broadleaf.Library.Globarization;


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���|�c������DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���|�c�������̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2007.11.09</br>
    /// <br></br>
    /// <br>Update Note: �������W�v�����̒ǉ�</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2009.01.13</br>
    /// <br></br>
    /// <br>Update Note: �d�����������Ή� �d�������@�\�I�v�V�����̗L���^�������ʂƁA�L�����̎d���f�[�^���������ǉ�</br>
    /// <br>Programmer : FSI�����@�v</br>
    /// <br>Date       : 2012/10/02</br>
    /// <br></br>
    /// <br>Update Note: ��ʓ��͂̎d����w�肪���������f����Ȃ���Q�Ή�</br>
    /// <br>Programmer : FSI�֓� �a�G</br>
    /// <br>Date       : 2012/11/08</br>
    /// <br>Update Note: �����I�v�V�����L�����Ɏx����݂̂̃f�[�^���W�v�ł��Ă��Ȃ���Q�Ή�</br>
    /// <br>Programmer : FSI�֓� �a�G</br>
    /// <br>Date       : 2012/11/18</br>
    /// <br>Update Note: Redmine#47007 ���|�c�������̏���ł̑Ή�</br>
    /// <br>Programmer : �c�v�t</br>
    /// <br>Date       : 2015/08/17</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class AccPayBalanceLedgerDB : RemoteDB, IAccPayBalanceLedgerDB
    {
        /// <summary>
        /// ���|�c������DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.09</br>
        /// </remarks>
        public AccPayBalanceLedgerDB()
            :
            base("AccPayBalanceLedgerDB", "Broadleaf.Application.Remoting.ParamData.RsltInfo_AccRecBalanceWork", "SUPLACCPAYRF")
        {
        }

        /// <summary>���|/���|���z�}�X�^�X�V�����[�g�I�u�W�F�N�g</summary>
        private MonthlyAddUpDB _monthlyAddUpDB;


        #region [SearchAccPayBalanceLedger]
        /// <summary>
        /// �w�肳�ꂽ�����̔��|�c��������߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔��|�c��������߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.09</br>
        public int SearchAccPayBalanceLedger(out object retObj, object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //SqlEncryptInfo sqlEncryptInfo = null;
            retObj = null;

            ExtrInfo_AccPayBalanceWork extrInfo_AccPayBalanceWork = null;

            ArrayList extrInfo_AccPayBalanceWorkList = paraObj as ArrayList;
            ArrayList retList = new ArrayList();

            if (extrInfo_AccPayBalanceWorkList == null)
            {
                extrInfo_AccPayBalanceWork = paraObj as ExtrInfo_AccPayBalanceWork;
            }
            else
            {
                if (extrInfo_AccPayBalanceWorkList.Count > 0)
                    extrInfo_AccPayBalanceWork = extrInfo_AccPayBalanceWorkList[0] as ExtrInfo_AccPayBalanceWork;
            }

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //���Í����L�[OPEN
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF"});
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //���������z�}�X�^�擾
                status = SearchAccPayBalanceLedgerProc(ref retList, extrInfo_AccPayBalanceWork, ref sqlConnection);

                // ADD 2009.01.13 >>>
                //���������W�v����
                status = SearchPaymentSlipLedgerProc(ref retList, extrInfo_AccPayBalanceWork, ref sqlConnection);
                // ADD 2009.01.13 <<<

                //STATUS
                if (retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccRecBalanceLedgerDB.SearchAccPayBalanceLedger");
                retObj = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                //���Í����L�[CLOSE
                //if (sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            retObj = (object)retList;
            return status;
        }
        // ADD 2009.01.13 >>>
        /// <summary>
        /// �w�肳�ꂽ�����̖������̔��|�c��������߂��܂�
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="extrInfo_AccPayBalanceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̖������̔��|�c��������߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2009.01.09</br>
        /// <br>Note       : Redmine#47007 ���|�c�������̏���ł̑Ή�</br>
        /// <br>Programmer : �c�v�t</br>
        /// <br>Date       : 2015/08/17</br>
        private int SearchPaymentSlipLedgerProc(ref ArrayList retList, ExtrInfo_AccPayBalanceWork extrInfo_AccPayBalanceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ArrayList SupplierList = new ArrayList();
            RsltInfo_AccPayBalanceWork paraWork = new RsltInfo_AccPayBalanceWork();
            DateTime StAddUpYearMonth = DateTime.MinValue;

            try
            {
                //���d���惊�X�g�쐬
                status = SearchSupplierProc(ref SupplierList, extrInfo_AccPayBalanceWork, ref sqlConnection);

                //���ŏI�����Z�o(�d���攃�|���z�}�X�^)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = GetMonthlyAddUpHis(ref SupplierList, extrInfo_AccPayBalanceWork, ref sqlConnection);
                }

                //���W�v�Ώۊ��Ԃ̔��菈��
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    for (int i = 0; i < SupplierList.Count; i++)
                    {
                        paraWork = SupplierList[i] as RsltInfo_AccPayBalanceWork;
                        DateTime addUpYearMonth = paraWork.AddUpYearMonth;   // ADD 2015/08/17 �c�v�t For Redmine#47007 ���|�c�������̏���ł̑Ή� 
                        if (paraWork.AddUpYearMonth < extrInfo_AccPayBalanceWork.Ed_AddUpYearMonth)
                        {
                            StAddUpYearMonth = extrInfo_AccPayBalanceWork.St_AddUpYearMonth;
                            while (true)
                            {
                                //�I������
                                if (StAddUpYearMonth > extrInfo_AccPayBalanceWork.Ed_AddUpYearMonth)
                                {
                                    break;
                                }

                                // ���Ӑ�ŏI���� < ��ʊJ�n�N��
                                if (paraWork.AddUpYearMonth < StAddUpYearMonth)
                                {
                                    // ���������W�v����
                                    // ---------- ADD 2015/08/17 �c�v�t For Redmine#47007 ���|�c�������̏���ł̑Ή� ---------->>>>>
                                    DateTime tempAddUpYearMonth = DateTime.MinValue;
                                    //���x�͍ŏI�����̗����̏ꍇ�A�v��N����null��ݒ肵�āA�u�iMAKAU00133R�j�v�́i�O����擾GetMonthlyAddUpHisAndSuplAccPay�j���b�\�h�𗘗p���āA�O�����|�c�����擾����
                                    if (addUpYearMonth == StAddUpYearMonth.AddMonths(-1))
                                    {
                                        tempAddUpYearMonth = paraWork.AddUpYearMonth;
                                        paraWork.AddUpYearMonth = DateTime.MinValue;
                                    }
                                    // ---------- ADD 2015/08/17 �c�v�t For Redmine#47007 ���|�c�������̏���ł̑Ή� ----------<<<<<<
                                    MakeSuplAccPayProc(ref retList, ref paraWork, extrInfo_AccPayBalanceWork, StAddUpYearMonth, ref sqlConnection);
                                    // ---------- ADD 2015/08/17 �c�v�t For Redmine#47007 ���|�c�������̏���ł̑Ή� ---------->>>>>
                                    if (addUpYearMonth == StAddUpYearMonth.AddMonths(-1))
                                    {
                                        paraWork.AddUpYearMonth = tempAddUpYearMonth;
                                    }
                                    // ---------- ADD 2015/08/17 �c�v�t For Redmine#47007 ���|�c�������̏���ł̑Ή� ----------<<<<<<
                                }

                                //��ʊJ�n�N�� + �P����
                                StAddUpYearMonth = StAddUpYearMonth.AddMonths(1);
                            }
                        }
                    }
                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccRecBalanceLedgerDB.SearchPaymentSlipLedgerProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;

        }

        #region [SearchSupplierProc]
        /// <summary>
        /// �d����}�X�^��������ɊY�����链�Ӑ惊�X�g�𒊏o���܂��B
        /// </summary>
        /// <param name="al">��������</param>
        /// <param name="extrInfo_AccPayBalanceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓��Ӑ惊�X�g��߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.09.22</br>
        private int SearchSupplierProc(ref ArrayList al, ExtrInfo_AccPayBalanceWork extrInfo_AccPayBalanceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region [Select���쐬]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += " SUPL.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += " SUPL.PAYMENTSECTIONCODERF," + Environment.NewLine;
                selectTxt += " SEC.SECTIONGUIDESNMRF AS ADDUPSECNAMERF," + Environment.NewLine;
                selectTxt += " SUPL.PAYEECODERF," + Environment.NewLine;
                selectTxt += " SUPL.SUPPLIERNM1RF," + Environment.NewLine;
                selectTxt += " SUPL.SUPPLIERNM2RF," + Environment.NewLine;
                selectTxt += " SUPL.SUPPLIERSNMRF," + Environment.NewLine;
                selectTxt += " SUPL.PAYMENTCONDRF," + Environment.NewLine;
                selectTxt += " SUPL.PAYMENTTOTALDAYRF," + Environment.NewLine;
                selectTxt += " SUPL.PAYMENTMONTHNAMERF," + Environment.NewLine;
                selectTxt += " SUPL.PAYMENTDAYRF" + Environment.NewLine;
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += " SUPPLIERRF AS SUPL" + Environment.NewLine;

                #region [JOIN]
                //���_���ݒ�}�X�^
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += " ON SUPL.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SUPL.PAYMENTSECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                #endregion  //[JOIN]

                #region [WHERE��]
                selectTxt += " WHERE" + Environment.NewLine;

                //��ƃR�[�h
                selectTxt += " SUPL.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_AccPayBalanceWork.EnterpriseCode);

                //�_���폜�敪
                selectTxt += " AND SUPL.LOGICALDELETECODERF=0" + Environment.NewLine;

                // �e�d����R�[�h�̂ݑΏ�
                selectTxt += " AND SUPL.SUPPLIERCDRF = SUPL.PAYEECODERF" + Environment.NewLine;
                selectTxt += " AND SUPL.PAYEECODERF IS NOT NULL" + Environment.NewLine;
                selectTxt += " AND SUPL.PAYEECODERF != 0" + Environment.NewLine;
                selectTxt += " AND SUPL.PAYMENTSECTIONCODERF IS NOT NULL" + Environment.NewLine;
                selectTxt += " AND SUPL.PAYMENTSECTIONCODERF != 0 " + Environment.NewLine;

                //���_�R�[�h
                if (extrInfo_AccPayBalanceWork.SectionCodes != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in extrInfo_AccPayBalanceWork.SectionCodes)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }
                    if (sectionCodestr != "")
                    {
                        selectTxt += " AND SUPL.PAYMENTSECTIONCODERF IN (" + sectionCodestr + ") ";
                    }
                    selectTxt += Environment.NewLine;
                }

                //�x����R�[�h
                if (extrInfo_AccPayBalanceWork.St_PayeeCode != 0)
                {
                    selectTxt += " AND SUPL.PAYEECODERF>=@ST_SUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraSt_SupplierCd = sqlCommand.Parameters.Add("@ST_SUPPLIERCD", SqlDbType.Int);
                    paraSt_SupplierCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_AccPayBalanceWork.St_PayeeCode);
                }
                // --- ADD 2012/11/08 ---------->>>>>
                //if (extrInfo_AccPayBalanceWork.St_PayeeCode != 99999999 && extrInfo_AccPayBalanceWork.St_PayeeCode != 0)
                if (extrInfo_AccPayBalanceWork.Ed_PayeeCode != 99999999 && extrInfo_AccPayBalanceWork.Ed_PayeeCode != 0)
                // --- ADD 2012/11/06 ----------<<<<<
                {
                    selectTxt += " AND SUPL.PAYEECODERF<=@ED_SUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraEd_SupplierCd = sqlCommand.Parameters.Add("@ED_SUPPLIERCD", SqlDbType.Int);
                    // --- ADD 2012/11/08 ---------->>>>>
                    //paraEd_SupplierCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_AccPayBalanceWork.St_PayeeCode);
                    paraEd_SupplierCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_AccPayBalanceWork.Ed_PayeeCode);
                    // --- ADD 2012/11/06 ----------<<<<<
                }
                #endregion  //[WHERE��]

                #region [ORDER BY]
                selectTxt += "ORDER BY " + Environment.NewLine;
                selectTxt += " SUPL.PAYMENTSECTIONCODERF," + Environment.NewLine;
                selectTxt += " SUPL.PAYEECODERF" + Environment.NewLine;
                #endregion

                #endregion  //[Select���쐬]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    RsltInfo_AccPayBalanceWork ResultWork = new RsltInfo_AccPayBalanceWork();

                    #region [���o����-�l�Z�b�g]
                    ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTSECTIONCODERF"));
                    ResultWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
                    ResultWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                    ResultWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                    ResultWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                    ResultWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    ResultWork.PaymentCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTCONDRF"));
                    ResultWork.PaymentTotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTTOTALDAYRF"));
                    ResultWork.PaymentMonthName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONTHNAMERF"));
                    ResultWork.PaymentDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF"));
                    #endregion

                    al.Add(ResultWork);
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
                base.WriteErrorLog(ex, "BillBalanceTableDB.SearchSupplierProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }

            return status;
        }
        #endregion  //[SearchSupplierProc]

        #region [GetMonthlyAddUpHis]
        /// <summary>
        /// �d���攃�|���z�}�X�^��������ɊY������ŏI�����𒊏o���܂��B
        /// </summary>
        /// <param name="al">��������</param>
        /// <param name="extrInfo_AccPayBalanceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍ŏI������߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2009.01.13</br>
        private int GetMonthlyAddUpHis(ref ArrayList al, ExtrInfo_AccPayBalanceWork extrInfo_AccPayBalanceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            RsltInfo_AccPayBalanceWork paraWork = new RsltInfo_AccPayBalanceWork();
            string sqlText = string.Empty;

            try
            {
                for (int i = 0; i < al.Count; i++)
                {
                    paraWork = al[i] as RsltInfo_AccPayBalanceWork;
                    sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection);
                    sqlCommand.Parameters.Clear();
                    sqlCommand.CommandText = string.Empty;

                    #region [Select���쐬]
                    sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += " ADDUPDATERF," + Environment.NewLine;
                    sqlText += " ADDUPYEARMONTHRF" + Environment.NewLine;
                    sqlText += "FROM SUPLACCPAYRF WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += " AND PAYEECODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += " AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += " AND ADDUPDATERF=" + Environment.NewLine;
                    sqlText += "  (" + Environment.NewLine;
                    sqlText += "    SELECT MAX(ADDUPDATERF)" + Environment.NewLine;
                    sqlText += "    FROM SUPLACCPAYRF WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "    WHERE" + Environment.NewLine;
                    sqlText += "       ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "     AND PAYEECODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += "     AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "   )" + Environment.NewLine;
                    #endregion  //[Select���쐬]

                    sqlCommand.CommandText = sqlText;

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_AccPayBalanceWork.EnterpriseCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(paraWork.PayeeCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(paraWork.AddUpSecCode.Trim());

                    myReader = sqlCommand.ExecuteReader();

                    ((RsltInfo_AccPayBalanceWork)al[i]).AddUpYearMonth = DateTime.MinValue;

                    while (myReader.Read())
                    {
                        //[���o����-�l�Z�b�g]
                        ((RsltInfo_AccPayBalanceWork)al[i]).AddUpYearMonth = TDateTime.LongDateToDateTime("YYYYMM", SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")));

                        if (((RsltInfo_AccPayBalanceWork)al[i]).AddUpYearMonth == extrInfo_AccPayBalanceWork.St_AddUpYearMonth.AddMonths(-1))
                        {
                            //��ʊJ�n�N��= �O�񗚗�-�P�����̏ꍇ�A���|���z�W�v���W���[���ɂđO������擾������
                            // ��((RsltInfo_AccPayBalanceWork)al[i]).AddUpYearMonth��DateTime.MinValue�̏ꍇ�A���|���z�W�v���W���[���ɂđO������擾����
                            ((RsltInfo_AccPayBalanceWork)al[i]).AddUpYearMonth = DateTime.MinValue;
                        }

                    }
                    if (!myReader.IsClosed)
                        myReader.Close();

                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccRecBalanceLedgerDB.GetMonthlyAddUpHis Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }

            return status;
        }
        #endregion  //[GetMonthlyAddUpHis]

        #region [MakeSuplAccPayProc]
        /// <summary>
        /// �����ɊY�����関�����̔��|�c�������𒊏o���܂��B
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <param name="extrInfo_AccPayBalanceWork">�����p�����[�^</param>
        /// <param name="AddUpYearMonth">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����ɊY�����関�����̔��|�c�������𒊏o���܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2009.01.09</br>
        private int MakeSuplAccPayProc(ref ArrayList retList, ref RsltInfo_AccPayBalanceWork paraWork, ExtrInfo_AccPayBalanceWork extrInfo_AccPayBalanceWork, DateTime AddUpYearMonth, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            DateTime StMonthDate = DateTime.MinValue;
            DateTime EdMonthDate = DateTime.MinValue;

            //���W�v�Ώۊ��Ԏ擾
            //���Џ��擾
            CompanyInfWork paraCompanyInfWork = new CompanyInfWork();
            CompanyInfDB companyInfDB = new CompanyInfDB();
            ArrayList arrayList;

            paraCompanyInfWork.EnterpriseCode = extrInfo_AccPayBalanceWork.EnterpriseCode;
            companyInfDB.Search(out arrayList, paraCompanyInfWork, ref sqlConnection);
            paraCompanyInfWork = (CompanyInfWork)arrayList[0];
            FinYearTableGenerator parafinYearTableGenerator = new FinYearTableGenerator(paraCompanyInfWork);

            try
            {
                parafinYearTableGenerator.GetDaysFromMonth(AddUpYearMonth, out StMonthDate, out EdMonthDate);
                this._monthlyAddUpDB = new MonthlyAddUpDB();                
                SuplAccPayWork suplAccPayWork = new SuplAccPayWork();

                #region ���|���W�v���W���[�� �ďo�p�����[�^�ݒ�
                suplAccPayWork.EnterpriseCode = extrInfo_AccPayBalanceWork.EnterpriseCode;//��ƃR�[�h    �����Ӑ惊�X�g����
                suplAccPayWork.AddUpSecCode = paraWork.AddUpSecCode.Trim();    //�������_�R�[�h���d���惊�X�g����
                suplAccPayWork.PayeeCode = paraWork.PayeeCode;          //�x����R�[�h  ���d���惊�X�g����
                suplAccPayWork.SupplierCd = paraWork.PayeeCode;

                suplAccPayWork.AddUpDate = EdMonthDate;                 //�v��N����(�I��)
                suplAccPayWork.AddUpYearMonth = AddUpYearMonth;         //�v��N��
                if (paraWork.AddUpYearMonth == DateTime.MinValue)
                {
                    // �X�V���� 
                    suplAccPayWork.StMonCAddUpUpdDate = DateTime.MinValue; // �v��N����(�J�n)
                    suplAccPayWork.LaMonCAddUpUpdDate = DateTime.MinValue; // �v��N����(�O�����)
                }
                else
                {
                    // �X�V��������
                    suplAccPayWork.StMonCAddUpUpdDate = StMonthDate; // �v��N����(�J�n)
                    suplAccPayWork.LaMonCAddUpUpdDate = StMonthDate.AddDays(-1);// �v��N����(�O�����)
                }

                object paraObj2 = (object)suplAccPayWork;
                string retMsg = null;
                #endregion

                //���|���W�v���W���[���ďo
                status = _monthlyAddUpDB.ReadSuplAccPay(ref paraObj2, out retMsg, ref sqlConnection);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //�擾���ʃL���X�g
                    ArrayList suplAccPayResult = new ArrayList();
                    suplAccPayResult.Add((SuplAccPayWork)paraObj2);
                    DateTime paraLaMonCAddUpUpdDate = DateTime.MinValue;
                    //�擾���ʃZ�b�g
                    for (int j = 0; j < suplAccPayResult.Count; j++)
                    {
                        RsltInfo_AccPayBalanceWork wkRsltInfo_AccPayBalanceWork = new RsltInfo_AccPayBalanceWork();
                        paraLaMonCAddUpUpdDate = DateTime.MinValue;

                        #region ���ʃZ�b�g
                        wkRsltInfo_AccPayBalanceWork.AddUpSecCode = paraWork.AddUpSecCode;
                        wkRsltInfo_AccPayBalanceWork.AddUpSecName = paraWork.AddUpSecName;
                        wkRsltInfo_AccPayBalanceWork.PayeeCode = paraWork.PayeeCode;
                        wkRsltInfo_AccPayBalanceWork.PayeeName = paraWork.PayeeName;
                        wkRsltInfo_AccPayBalanceWork.PayeeName2 = paraWork.PayeeName2;
                        wkRsltInfo_AccPayBalanceWork.PayeeSnm = paraWork.PayeeSnm;
                        wkRsltInfo_AccPayBalanceWork.AddUpDate = ((SuplAccPayWork)suplAccPayResult[j]).AddUpDate;
                        wkRsltInfo_AccPayBalanceWork.AddUpYearMonth = ((SuplAccPayWork)suplAccPayResult[j]).AddUpYearMonth;
                        wkRsltInfo_AccPayBalanceWork.LastTimeAccPay = ((SuplAccPayWork)suplAccPayResult[j]).LastTimeAccPay;
                        wkRsltInfo_AccPayBalanceWork.StckTtl2TmBfBlAccPay = ((SuplAccPayWork)suplAccPayResult[j]).StckTtl2TmBfBlAccPay;
                        wkRsltInfo_AccPayBalanceWork.StckTtl3TmBfBlAccPay = ((SuplAccPayWork)suplAccPayResult[j]).StckTtl3TmBfBlAccPay;
                        wkRsltInfo_AccPayBalanceWork.ThisTimePayNrml = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimePayNrml;
                        wkRsltInfo_AccPayBalanceWork.ThisTimeFeePayNrml = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimeFeePayNrml;
                        wkRsltInfo_AccPayBalanceWork.ThisTimeDisPayNrml = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimeDisPayNrml;
                        wkRsltInfo_AccPayBalanceWork.ThisTimeTtlBlcAcPay = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimeTtlBlcAcPay;
                        wkRsltInfo_AccPayBalanceWork.OfsThisTimeStock = ((SuplAccPayWork)suplAccPayResult[j]).OfsThisTimeStock;
                        wkRsltInfo_AccPayBalanceWork.OfsThisStockTax = ((SuplAccPayWork)suplAccPayResult[j]).OfsThisStockTax;
                        wkRsltInfo_AccPayBalanceWork.ThisTimeStockPrice = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimeStockPrice;
                        wkRsltInfo_AccPayBalanceWork.ThisStcPrcTax = ((SuplAccPayWork)suplAccPayResult[j]).ThisStcPrcTax;
                        wkRsltInfo_AccPayBalanceWork.ThisStckPricRgds = ((SuplAccPayWork)suplAccPayResult[j]).ThisStckPricRgds;
                        wkRsltInfo_AccPayBalanceWork.ThisStcPrcTaxRgds = ((SuplAccPayWork)suplAccPayResult[j]).ThisStcPrcTaxRgds;
                        wkRsltInfo_AccPayBalanceWork.ThisStckPricDis = ((SuplAccPayWork)suplAccPayResult[j]).ThisStckPricDis;
                        wkRsltInfo_AccPayBalanceWork.ThisStcPrcTaxDis = ((SuplAccPayWork)suplAccPayResult[j]).ThisStcPrcTaxDis;
                        wkRsltInfo_AccPayBalanceWork.TaxAdjust = ((SuplAccPayWork)suplAccPayResult[j]).TaxAdjust;
                        wkRsltInfo_AccPayBalanceWork.BalanceAdjust = ((SuplAccPayWork)suplAccPayResult[j]).BalanceAdjust;
                        wkRsltInfo_AccPayBalanceWork.StckTtlAccPayBalance = ((SuplAccPayWork)suplAccPayResult[j]).StckTtlAccPayBalance;
                        wkRsltInfo_AccPayBalanceWork.StockSlipCount = ((SuplAccPayWork)suplAccPayResult[j]).StockSlipCount;
                        wkRsltInfo_AccPayBalanceWork.PaymentCond = paraWork.PaymentCond;
                        wkRsltInfo_AccPayBalanceWork.PaymentTotalDay = paraWork.PaymentTotalDay;
                        wkRsltInfo_AccPayBalanceWork.PaymentMonthName = paraWork.PaymentMonthName;
                        wkRsltInfo_AccPayBalanceWork.PaymentDay = paraWork.PaymentDay;
                        #endregion

                        paraLaMonCAddUpUpdDate = ((SuplAccPayWork)suplAccPayResult[j]).LaMonCAddUpUpdDate;

                        // �O�񗚗������݂���ꍇ�A�O���c���E�J�z�c���E�������c�����v�Z
                        if (paraLaMonCAddUpUpdDate != DateTime.MinValue)
                        {
                            for (int i = 0; i < retList.Count; i++)
                            {
                                if ((((RsltInfo_AccPayBalanceWork)retList[i]).AddUpSecCode == wkRsltInfo_AccPayBalanceWork.AddUpSecCode) &&
                                    (((RsltInfo_AccPayBalanceWork)retList[i]).PayeeCode == wkRsltInfo_AccPayBalanceWork.PayeeCode) &&
                                    (((RsltInfo_AccPayBalanceWork)retList[i]).AddUpDate == paraLaMonCAddUpUpdDate))
                                {
                                    wkRsltInfo_AccPayBalanceWork.LastTimeAccPay = ((RsltInfo_AccPayBalanceWork)retList[i]).StckTtlAccPayBalance; // �O���c��
                                    // ����J�z�c��(���|) = �O��c�� - ����x�����z 
                                    wkRsltInfo_AccPayBalanceWork.ThisTimeTtlBlcAcPay = (wkRsltInfo_AccPayBalanceWork.LastTimeAccPay) - wkRsltInfo_AccPayBalanceWork.ThisTimePayNrml;// ����J�z�c��(���|)
                                    // �v�Z����z = ����J�z�c�� + (���E�㍡��d�����z + ���E�㍡��d�������)
                                    wkRsltInfo_AccPayBalanceWork.StckTtlAccPayBalance = wkRsltInfo_AccPayBalanceWork.ThisTimeTtlBlcAcPay + (wkRsltInfo_AccPayBalanceWork.OfsThisTimeStock + wkRsltInfo_AccPayBalanceWork.OfsThisStockTax);// �v�Z�㐿�����z
                                }
                            }
                        }
                        retList.Add(wkRsltInfo_AccPayBalanceWork);
                    }
                }
                paraWork.AddUpYearMonth = AddUpYearMonth;

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccRecBalanceLedgerDB.MakeSuplAccPayProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion  //[MakeSuplAccPayProc]


        // ADD 2009.01.13 <<<

        /// <summary>
        /// �w�肳�ꂽ�����̔��|�c��������߂��܂�
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="extrInfo_AccPayBalanceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔��|�c��������߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.09</br>
        private int SearchAccPayBalanceLedgerProc(ref ArrayList retList, ExtrInfo_AccPayBalanceWork extrInfo_AccPayBalanceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                #region [SQL��]

                string selectTxt = "";

                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   SUPLACC.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  ,SEC.SECTIONGUIDESNMRF AS ADDUPSECNAMERF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.PAYEECODERF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.PAYEENAMERF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.PAYEENAME2RF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.PAYEESNMRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.ADDUPDATERF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.ADDUPYEARMONTHRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.LASTTIMEACCPAYRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.STCKTTL2TMBFBLACCPAYRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.STCKTTL3TMBFBLACCPAYRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.THISTIMEPAYNRMLRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.THISTIMEFEEPAYNRMLRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.THISTIMEDISPAYNRMLRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.THISTIMETTLBLCACPAYRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.OFSTHISTIMESTOCKRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.OFSTHISSTOCKTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.THISTIMESTOCKPRICERF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.THISSTCPRCTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.THISSTCKPRICRGDSRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.THISSTCPRCTAXRGDSRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.THISSTCKPRICDISRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.THISSTCPRCTAXDISRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.TAXADJUSTRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.BALANCEADJUSTRF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.STCKTTLACCPAYBALANCERF" + Environment.NewLine;
                selectTxt += "  ,SUPLACC.STOCKSLIPCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,SUPL.PAYMENTCONDRF" + Environment.NewLine;
                selectTxt += "  ,SUPL.PAYMENTTOTALDAYRF" + Environment.NewLine;
                selectTxt += "  ,SUPL.PAYMENTMONTHNAMERF" + Environment.NewLine;
                selectTxt += "  ,SUPL.PAYMENTDAYRF" + Environment.NewLine;
                selectTxt += "FROM SUPLACCPAYRF AS SUPLACC" + Environment.NewLine;

                selectTxt += "LEFT JOIN SUPPLIERRF AS SUPL" + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     SUPLACC.ENTERPRISECODERF=SUPL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SUPLACC.PAYEECODERF=SUPL.SUPPLIERCDRF" + Environment.NewLine;

                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "     SUPLACC.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SUPLACC.ADDUPSECCODERF=SEC.SECTIONCODERF" + Environment.NewLine;

                #endregion

                //Where��쐬
                selectTxt += MakeWhereString(ref sqlCommand, extrInfo_AccPayBalanceWork);

                //�v�㋒�_�R�[�h�{������R�[�h�{�v��N�����ɕ��ёւ���
                selectTxt += "ORDER BY" + Environment.NewLine;
                selectTxt += "  SUPLACC.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += ", SUPLACC.PAYEECODERF" + Environment.NewLine;
                selectTxt += ", SUPLACC.ADDUPYEARMONTHRF" + Environment.NewLine;

                sqlCommand.CommandText = selectTxt;    
                
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    retList.Add(CopyToRsltInfo_AccPayBalanceFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        #endregion

        // ---------- ADD 2012/10/02 ---------->>>>>
        #region [�d�������I�v�V�����L�������\�b�h�Q]

        #region [SearchAccPayBalanceLedgerForSumOptOn]
        /// <summary>
        /// �w�肳�ꂽ�����̔��|�c��������߂��܂��i�d�������I�v�V�����L�����j
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔��|�c��������߂��܂�</br>
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date       : 2012/10/02</br>
        public int SearchAccPayBalanceLedgerForSumOptOn(out object retObj, object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //SqlEncryptInfo sqlEncryptInfo = null;
            retObj = null;

            ExtrInfo_AccPayBalanceWork extrInfo_AccPayBalanceWork = null;

            ArrayList extrInfo_AccPayBalanceWorkList = paraObj as ArrayList;
            ArrayList retList = new ArrayList();

            if (extrInfo_AccPayBalanceWorkList == null)
            {
                extrInfo_AccPayBalanceWork = paraObj as ExtrInfo_AccPayBalanceWork;
            }
            else
            {
                if (extrInfo_AccPayBalanceWorkList.Count > 0)
                    extrInfo_AccPayBalanceWork = extrInfo_AccPayBalanceWorkList[0] as ExtrInfo_AccPayBalanceWork;
            }

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //���������z�}�X�^�擾
                //  ������̏����i���σf�[�^�̎擾�j�́A�d�������I�v�V�����L���^�����Ɋւ�炸�����������Ăяo��
                status = SearchAccPayBalanceLedgerProc(ref retList, extrInfo_AccPayBalanceWork, ref sqlConnection);

                //���������W�v�����i�d�������I�v�V�����L�����j
                status = SearchPaymentSlipLedgerProcForSumOptOn(ref retList, extrInfo_AccPayBalanceWork, ref sqlConnection);

                if (retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccRecBalanceLedgerDB.SearchAccPayBalanceLedgerForSumOptOn");
                retObj = new ArrayList();
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

            retObj = (object)retList;
            return status;
        }

        #endregion [SearchAccPayBalanceLedgerForSumOptOn]

        #region [SearchPaymentSlipLedgerProcForSumOptOn]
        /// <summary>
        /// �w�肳�ꂽ�����̖������̔��|�c��������߂��܂��i�d�������I�v�V�����L�����j
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="extrInfo_AccPayBalanceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̖������̔��|�c��������߂��܂�</br>
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date       : 2012/10/02</br>
        /// <br>Update Note: Redmine#47007 ���|�c�������̏���ł̑Ή�</br>
        /// <br>Programmer : �c�v�t</br>
        /// <br>Date       : 2015/08/17</br>
        private int SearchPaymentSlipLedgerProcForSumOptOn(ref ArrayList retList, ExtrInfo_AccPayBalanceWork extrInfo_AccPayBalanceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ArrayList SupplierList = new ArrayList();
            RsltInfo_AccPayBalanceWork paraWork = new RsltInfo_AccPayBalanceWork();
            DateTime StAddUpYearMonth = DateTime.MinValue;

            // �v��σ��X�g(�W�v���R�[�h�̃R�s�[)
            ArrayList addUppedList = new ArrayList();
            addUppedList = (ArrayList)retList.Clone();
            //----- ADD 2015/08/17 �c�v�t For Redmine#47007 ���|�c�������̏���ł̑Ή� ---------->>>>>
            DateTime lastAddUpYearMonth = DateTime.MinValue;
            RsltInfo_AccPayBalanceWork currWork = null;
            RsltInfo_AccPayBalanceWork nextWork = null;
            // �O�񌎎��������̎擾
            for (int index = 0; index < addUppedList.Count; index++)
            {   
                currWork = addUppedList[index] as RsltInfo_AccPayBalanceWork;
                nextWork = null;
                if (index < addUppedList.Count - 1)
                {
                    nextWork = addUppedList[index + 1] as RsltInfo_AccPayBalanceWork;
                }

                if (nextWork != null)
                {
                    if (currWork.AddUpYearMonth < nextWork.AddUpYearMonth)
                    {
                        lastAddUpYearMonth = nextWork.AddUpYearMonth;
                    }
                    else
                    {
                        lastAddUpYearMonth = currWork.AddUpYearMonth;
                    }
                }
                else
                {
                    lastAddUpYearMonth = currWork.AddUpYearMonth;
                }
            }
            //----- ADD 2015/08/17 �c�v�t For Redmine#47007 ���|�c�������̏���ł̑Ή� ----------<<<<<

            // �W�v���R�[�h�ɑ��݂����d����̋��_�̓��A���W�v���Ă��܂��B
            // ��ŏW�v�ς��Ȃ�
            for (int cnt = 0; cnt < addUppedList.Count; cnt++)
            {
                paraWork = addUppedList[cnt] as RsltInfo_AccPayBalanceWork;
                
                #region ���v�㋒�_�`�F�b�N
                // ���ꂩ�珈�����s�����Ƃ���d����̌v�㋒�_�R�[�h���A
                // ��ʂŎw�肳��Ă���R�[�h�ƈ�v���Ȃ��ꍇ�́A�������W�v�������X�L�b�v����
                // �u�S�Ёv���w�肳��Ă���ꍇ�́A���̃`�F�b�N�������̂��X�L�b�v�����
                if (extrInfo_AccPayBalanceWork.SectionCodes != null)
                {
                    bool flg = false;
                    foreach (string seccdstr in extrInfo_AccPayBalanceWork.SectionCodes)
                    {
                        if (seccdstr != "")
                        {
                            if (seccdstr == paraWork.AddUpSecCode.Trim())
                            {
                                flg = true;
                                break;
                            }
                        }
                    }
                    if (flg == false)
                        continue;
                }
                #endregion

                if ((paraWork.AddUpYearMonth.AddDays(1)).AddMonths(-1) < extrInfo_AccPayBalanceWork.Ed_AddUpYearMonth)
                {
                    StAddUpYearMonth = extrInfo_AccPayBalanceWork.St_AddUpYearMonth;
                    while (true)
                    {
                        //�I������
                        if (StAddUpYearMonth > extrInfo_AccPayBalanceWork.Ed_AddUpYearMonth)
                        {
                            break;
                        }

                        // ���Ӑ�ŏI���� < ��ʊJ�n�N��
                        if ((paraWork.AddUpDate.AddDays(1)).AddMonths(-1) < StAddUpYearMonth)
                        {
                            // ���W�v���R�[�h����擾�ς݂͏Ȃ��悤�ɏW�v���R�[�h�擾�ς݃��X�g��n��
                            // ���������W�v�����i�d�������I�v�V�����L�����j
                            //MakeSuplAccPayProcForSumOptOn(ref retList, ref paraWork, extrInfo_AccPayBalanceWork, StAddUpYearMonth, ref sqlConnection);
                            //----- ADD 2015/08/17 �c�v�t For Redmine#47007 ���|�c�������̏���ł̑Ή�---------->>>>>
                            DateTime tempAddUpYearMonth = DateTime.MinValue;
                            // ��ʂ̌v��N���͑O�񌎎��X�V���̗����̏ꍇ�A�p�����[�^�̌v��N����null��ݒ肵�āA
                            // �u�iMAKAU00133R�j�v�́i�O����擾GetMonthlyAddUpHisAndSuplAccPay�j���b�\�h�𗘗p���āA�O���d���c�����擾������A����ł��v�Z����
                            if ((lastAddUpYearMonth.AddDays(1)).AddMonths(-1) == StAddUpYearMonth.AddMonths(-1))
                            {
                                tempAddUpYearMonth = paraWork.AddUpYearMonth;
                                paraWork.AddUpYearMonth = DateTime.MinValue;
                            }
                            //----- ADD 2015/08/17 �c�v�t For Redmine#47007 ���|�c�������̏���ł̑Ή�----------<<<<<
                            MakeSuplAccPayProcForAddedData_SumOptOn(ref retList, ref paraWork, extrInfo_AccPayBalanceWork, StAddUpYearMonth, addUppedList, ref sqlConnection);
                            //----- ADD 2015/08/17 �c�v�t For Redmine#47007 ���|�c�������̏���ł̑Ή�---------->>>>>
                            if ((lastAddUpYearMonth.AddDays(1)).AddMonths(-1) == StAddUpYearMonth.AddMonths(-1))
                            {
                                // �p�����[�^�̌v��N�������ɖ߂�
                                paraWork.AddUpYearMonth = tempAddUpYearMonth;
                            }
                            //----- ADD 2015/08/17 �c�v�t For Redmine#47007 ���|�c�������̏���ł̑Ή�----------<<<<<
                        }

                        //��ʊJ�n�N�� + �P����
                        StAddUpYearMonth = StAddUpYearMonth.AddMonths(1);
                    }
                }
            }

            // retList���ēx����
            addUppedList = new ArrayList();
            addUppedList = (ArrayList)retList.Clone();
            
            try
            {
                //���d���惊�X�g�쐬�i�d�������I�v�V�����L�����j
                status = SearchSupplierProcForSumOptOn(ref SupplierList, extrInfo_AccPayBalanceWork, ref sqlConnection);

                //���ŏI�����Z�o(�d���攃�|���z�}�X�^)
                //  ���̏����͎d�������I�v�V�����L�����^�����Ɋ֌W�Ȃ������������Ăяo��
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = GetMonthlyAddUpHis(ref SupplierList, extrInfo_AccPayBalanceWork, ref sqlConnection);
                }

                //���d����f�[�^�ǉ��擾(�d���攃�|���z�}�X�^)
                //  �d�������f�[�^���������āA�d���惊�X�g���́u�e�v�Ɠ����d����Ŏd�����_�i���v�㋒�_�j���Ⴄ�f�[�^���A
                //  �d���惊�X�g�ɒǉ�
                status = GetSupplierForDifferentStockSection(ref SupplierList, extrInfo_AccPayBalanceWork, ref sqlConnection);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //���W�v�Ώۊ��Ԃ̔��菈��
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    for (int i = 0; i < SupplierList.Count; i++)
                    {
                        paraWork = SupplierList[i] as RsltInfo_AccPayBalanceWork;
                        #region ���v�㋒�_�`�F�b�N
                        // ���ꂩ�珈�����s�����Ƃ���d����̌v�㋒�_�R�[�h���A
                        // ��ʂŎw�肳��Ă���R�[�h�ƈ�v���Ȃ��ꍇ�́A�������W�v�������X�L�b�v����
                        // �u�S�Ёv���w�肳��Ă���ꍇ�́A���̃`�F�b�N�������̂��X�L�b�v�����
                        if (extrInfo_AccPayBalanceWork.SectionCodes != null)
                        {
                            bool flg = false;
                            foreach (string seccdstr in extrInfo_AccPayBalanceWork.SectionCodes)
                            {
                                if (seccdstr != "")
                                {
                                    if (seccdstr == paraWork.AddUpSecCode.Trim())
                                    {
                                        flg = true;
                                        break;
                                    }
                                }
                            }
                            if (flg == false)
                                continue;
                        }
                        #endregion

                        if (paraWork.AddUpYearMonth < extrInfo_AccPayBalanceWork.Ed_AddUpYearMonth)
                        {
                            StAddUpYearMonth = extrInfo_AccPayBalanceWork.St_AddUpYearMonth;
                            DateTime addUpYearMonth = paraWork.AddUpYearMonth; // ADD 2015/08/17 �c�v�t For Redmine#47007 ���|�c�������̏���ł̑Ή�
                            while (true)
                            {
                                //�I������
                                if (StAddUpYearMonth > extrInfo_AccPayBalanceWork.Ed_AddUpYearMonth)
                                {
                                    break;
                                }

                                // ���Ӑ�ŏI���� < ��ʊJ�n�N��
                                if (paraWork.AddUpYearMonth < StAddUpYearMonth)
                                {
                                    // ���������W�v�����i�d�������I�v�V�����L�����j
                                    // ��ʂ̌v��N���͑O�񌎎��X�V���̗����̏ꍇ�A�p�����[�^�̌v��N����null��ݒ肵�āA
                                    // �u�iMAKAU00133R�j�v�́i�O����擾GetMonthlyAddUpHisAndSuplAccPay�j���b�\�h�𗘗p���āA�O���d���c�����擾������A����ł��v�Z����
                                    // ---------- ADD 2015/08/17 �c�v�t For Redmine#47007 ���|�c�������̏���ł̑Ή�---------->>>>>
                                    DateTime tempAddUpYearMonth = DateTime.MinValue;
                                    if (addUpYearMonth == StAddUpYearMonth.AddMonths(-1))
                                    {
                                        tempAddUpYearMonth = paraWork.AddUpYearMonth;
                                        paraWork.AddUpYearMonth = DateTime.MinValue;
                                    }
                                    // ---------- ADD 2015/08/17 �c�v�t For Redmine#47007 ���|�c�������̏���ł̑Ή�----------<<<<<<
                                    MakeSuplAccPayProcForSumOptOn(ref retList, ref paraWork, extrInfo_AccPayBalanceWork, StAddUpYearMonth, addUppedList, ref sqlConnection);
                                    // ---------- ADD 2015/08/17 �c�v�t For Redmine#47007 ���|�c�������̏���ł̑Ή�---------->>>>>
                                    if (addUpYearMonth == StAddUpYearMonth.AddMonths(-1))
                                    {
                                        paraWork.AddUpYearMonth = tempAddUpYearMonth;
                                    }
                                    // ---------- ADD 2015/08/17 �c�v�t For Redmine#47007 ���|�c�������̏���ł̑Ή�----------<<<<<<
                                }

                                //��ʊJ�n�N�� + �P����
                                StAddUpYearMonth = StAddUpYearMonth.AddMonths(1);
                            }
                        }
                    }
                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccRecBalanceLedgerDB.SearchPaymentSlipLedgerProcForSumOptOn Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;

        }
        #endregion [SearchPaymentSlipLedgerProcForSumOptOn]

        #region [SearchSupplierProcForSumOptOn]
        /// <summary>
        /// �d����}�X�^��������ɊY������d���惊�X�g�𒊏o���܂��B�i�d�������I�v�V�����L�����j
        /// </summary>
        /// <param name="al">��������</param>
        /// <param name="extrInfo_AccPayBalanceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓��Ӑ惊�X�g��߂��܂�</br>
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date       : 2012/10/02</br>
        private int SearchSupplierProcForSumOptOn(ref ArrayList al, ExtrInfo_AccPayBalanceWork extrInfo_AccPayBalanceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region [Select���쐬]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += " SUPL.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += " SUPL.MNGSECTIONCODERF," + Environment.NewLine;
                selectTxt += " SEC.SECTIONGUIDESNMRF AS ADDUPSECNAMERF," + Environment.NewLine;
                selectTxt += " SUPL.SUPPLIERNM1RF," + Environment.NewLine;
                selectTxt += " SUPL.SUPPLIERNM2RF," + Environment.NewLine;
                selectTxt += " SUPL.SUPPLIERSNMRF," + Environment.NewLine;
                selectTxt += " SUPL.PAYMENTCONDRF," + Environment.NewLine;
                selectTxt += " SUPL.PAYMENTTOTALDAYRF," + Environment.NewLine;
                selectTxt += " SUPL.PAYMENTMONTHNAMERF," + Environment.NewLine;
                selectTxt += " SUPL.PAYMENTDAYRF," + Environment.NewLine;
                selectTxt += " SUPL.SUPPLIERCDRF" + Environment.NewLine; // �I�v�V�����������͎x����R�[�h���������A�����ł͎d����R�[�h���擾
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += " SUPPLIERRF AS SUPL" + Environment.NewLine;

                #region [JOIN]
                //���_���ݒ�}�X�^
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += " ON SUPL.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                // �d�������̏ꍇ�͊Ǘ����_�R�[�h����v�̏ꍇ�i�e�q�֌W�������Ȃ邽�߁B�d�������Ȃ��̏ꍇ�͓��͋��_�R�[�h�j
                selectTxt += " AND SUPL.MNGSECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                #endregion  //[JOIN]

                #region [WHERE��]
                selectTxt += " WHERE" + Environment.NewLine;

                //��ƃR�[�h
                selectTxt += " SUPL.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_AccPayBalanceWork.EnterpriseCode);

                //�_���폜�敪
                selectTxt += " AND SUPL.LOGICALDELETECODERF=0" + Environment.NewLine;

                // �I�v�V�����������͎x����R�[�h���������A�����ł͎d����R�[�h�Ō���
                // �܂��A������x����ł́u�e�v�u�q�v�Ɋ֌W�Ȃ��f�[�^���擾����
                if (extrInfo_AccPayBalanceWork.St_PayeeCode != 0)
                {
                    selectTxt += " AND SUPL.SUPPLIERCDRF>=@ST_SUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraSt_SupplierCd = sqlCommand.Parameters.Add("@ST_SUPPLIERCD", SqlDbType.Int);
                    paraSt_SupplierCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_AccPayBalanceWork.St_PayeeCode);
                }
                if (extrInfo_AccPayBalanceWork.Ed_PayeeCode != 99999999 && extrInfo_AccPayBalanceWork.Ed_PayeeCode != 0)
                {
                    selectTxt += " AND SUPL.SUPPLIERCDRF<=@ED_SUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraEd_SupplierCd = sqlCommand.Parameters.Add("@ED_SUPPLIERCD", SqlDbType.Int);
                    paraEd_SupplierCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_AccPayBalanceWork.Ed_PayeeCode);
                }
                #endregion  //[WHERE��]

                #region [ORDER BY]
                selectTxt += "ORDER BY " + Environment.NewLine;
                selectTxt += " SUPL.PAYMENTSECTIONCODERF," + Environment.NewLine;
                selectTxt += " SUPL.SUPPLIERCDRF" + Environment.NewLine;
                #endregion

                #endregion  //[Select���쐬]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    RsltInfo_AccPayBalanceWork ResultWork = new RsltInfo_AccPayBalanceWork();

                    #region [���o����-�l�Z�b�g]
                    ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
                    ResultWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
                    ResultWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    ResultWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                    ResultWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                    ResultWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    ResultWork.PaymentCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTCONDRF"));
                    ResultWork.PaymentTotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTTOTALDAYRF"));
                    ResultWork.PaymentMonthName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONTHNAMERF"));
                    ResultWork.PaymentDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF"));
                    #endregion

                    al.Add(ResultWork);
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
                base.WriteErrorLog(ex, "BillBalanceTableDB.SearchSupplierProcForSumOptOn Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }

            return status;
        }
        #endregion  //[SearchSupplierProcForSumOptOn]

        #region [GetSupplierForDifferentStockSection]
        /// <summary>
        /// �ʌv�㋒�_�d����f�[�^�擾�i�d�������I�v�V�����L�����̂ݓ���j
        /// </summary>
        /// <param name="al">��������</param>
        /// <param name="extrInfo_AccPayBalanceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d�������f�[�^���������A�d���惊�X�g���̎d����Ŏd�����_�i���v�㋒�_�j���Ⴄ�d������擾���Ďd���惊�X�g�ɒǉ�</br>
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date       : 2012/10/02</br>
        private int GetSupplierForDifferentStockSection(ref ArrayList al, ExtrInfo_AccPayBalanceWork extrInfo_AccPayBalanceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            RsltInfo_AccPayBalanceWork paraWork = new RsltInfo_AccPayBalanceWork();
            string sqlText = string.Empty;

			// --- ADD 2012/11/18 ---------->>>>>
            //���t�擾�p
            DateTime startYearMonth = DateTime.MinValue;
            DateTime startDate = DateTime.MinValue;
            DateTime endDate = DateTime.MinValue;
            DateTime dateBuf = DateTime.MinValue;
			// --- ADD 2012/11/18 ----------<<<<<

            try
            {
                #region ���d�������f�[�^�������Ԏ擾�̂��߁A���Џ��擾
                CompanyInfWork paraCompanyInfWork = new CompanyInfWork();
                CompanyInfDB companyInfDB = new CompanyInfDB();
                ArrayList arrayList;

                paraCompanyInfWork.EnterpriseCode = extrInfo_AccPayBalanceWork.EnterpriseCode;
                status = companyInfDB.Search(out arrayList, paraCompanyInfWork, ref sqlConnection);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                paraCompanyInfWork = (CompanyInfWork)arrayList[0];
                FinYearTableGenerator parafinYearTableGenerator = new FinYearTableGenerator(paraCompanyInfWork);
                #endregion ���d�������f�[�^�������Ԏ擾�̂��߁A���Џ��擾

                ArrayList orgList;
                orgList = (ArrayList)al.Clone();

                for (int i = 0; i < orgList.Count; i++)
                {
                    #region ���d�������f�[�^���������i�d���v����t�͈̔́j����
                    paraWork = al[i] as RsltInfo_AccPayBalanceWork;

                    // �ŏI�����̗������擾�i���ꂪ���̎d���恁�x����̖��������Ԃ̊J�n�N���ɂȂ�j
                    DateTime dt = paraWork.AddUpYearMonth.AddMonths(1);

                    // ���̎d����i���x����j�̖��������Ԃ̊J�n�N���ƁA��ʂŎw�肳�ꂽ�����N���i�J�n�j�̗������r���A
                    // �d���f�[�^����������ۂ̊J�n�N��������
                    if (dt < extrInfo_AccPayBalanceWork.St_AddUpYearMonth)
                    {
                        // ���������Ԃ̊J�n�N������ʂŎw�肳�ꂽ�����N���i�J�n�j���O�ł���A
                        // ��ʎw��͈̔͊O�ƂȂ邽�߁A�J�n�N���͉�ʎw��̏����N���i�J�n�j�Ƃ���
                        startYearMonth = extrInfo_AccPayBalanceWork.St_AddUpYearMonth;
                    }
                    else if (dt == extrInfo_AccPayBalanceWork.St_AddUpYearMonth)
                    {
                        // ���������Ԃ̊J�n�N���Ɖ�ʎw��̏����N���i�J�n�j����v����̂ŁA
                        // ���������Ԃ̊J�n�N�������̂܂܊J�n�N���Ƃ���
                        // �@�����ł́A�������̃f�[�^���擾���邽�߂̎d����i���x����j�����X�g�ɐݒ肵�����̂ŁA
                        //   �ŏI���ߓ��̗����A�܂薢�����̊��Ԃ̍ŏ��̔N�����J�n�N���Ƃ���
                        startYearMonth = dt;
                    }
                    else
                    {
                        // ���������Ԃ̊J�n�N������ʎw��̏����N���i�J�n�j����Ȃ̂ŁA
                        // ����ɉ�ʎw��̏����N���i�I���j����ɂȂ��Ă��Ȃ����`�F�b�N
                        if (dt > extrInfo_AccPayBalanceWork.Ed_AddUpYearMonth)
                        {
                            // ��ʎw��͈̔͊O�ƂȂ邽�߁A���̎d����i���x����j�ɂ��ẮA
                            // �d�������f�[�^�̌��������͍s��Ȃ�
                            continue;
                        }
                        else
                        {
                            // ��ʎw��̏����N���i�I���j�ȑO�ɂȂ��Ă���̂ŁA
                            // ���������Ԃ̊J�n�N�������̂܂܊J�n�N���Ƃ���
                            startYearMonth = dt;
                        }
                    }

                    // ���肵���J�n�N���ƁA��ʎw��̏����N���i�I���j����A�����͈͂̊J�n���ƏI�������擾
                    parafinYearTableGenerator.GetDaysFromMonth(startYearMonth, out startDate, out dateBuf);
                    parafinYearTableGenerator.GetDaysFromMonth(extrInfo_AccPayBalanceWork.Ed_AddUpYearMonth, out dateBuf, out endDate);
                    #endregion ���d�������f�[�^���������i�d���v����t�͈̔́j����

                    #region ���d�������f�[�^����

                    sqlCommand = new SqlCommand(sqlText, sqlConnection);
                    sqlCommand.Parameters.Clear();
                    sqlCommand.CommandText = string.Empty;

                    #region ��Select���쐬
                    
#if false //���R�[�h
                    sqlText = string.Empty;
                    sqlText += "SELECT DISTINCT" + Environment.NewLine;                                 // ���o����
                    sqlText += " STOCK.STOCKSECTIONCDRF AS SECTIONCDRF," + Environment.NewLine;    //  �d�����_�R�[�h
                    sqlText += " SEC.SECTIONGUIDESNMRF AS SECNAMERF," + Environment.NewLine;       //  �d�����_���i���̃J�����̂݋��_���ݒ�}�X�^����j
                    sqlText += " STOCK.SUPPLIERCDRF AS SUPPLIERCDRF" + Environment.NewLine;             //  �d����R�[�h

                    sqlText += "FROM STOCKSLIPHISTRF AS STOCK,  SECINFOSETRF AS SEC WITH(READUNCOMMITTED)" + Environment.NewLine;

                    sqlText += "WHERE" + Environment.NewLine;                                                       // �������猟������
                    sqlText += "     STOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;             //  ��ƃR�[�h
                    sqlText += " AND STOCK.LOGICALDELETECODERF = 0" + Environment.NewLine;                          //  �_���폜�敪�u0�v�i�L���j
                    sqlText += " AND STOCK.STOCKSECTIONCDRF<>@FINDSTOCKSECTIONCDRF" + Environment.NewLine;          //  �d�����_�R�[�h�͎d���惊�X�g���̃f�[�^�ƈ�v���Ȃ��f�[�^
                    sqlText += " AND STOCK.SUPPLIERCDRF=@FINDPAYEECODERF" + Environment.NewLine;                    //  �d����R�[�h�͈�v
                    sqlText += " AND STOCK.STOCKADDUPADATERF>=@FINDSTARTSTOCKADDUPADATERF" + Environment.NewLine;   //  �d���v����t�E�J�n
                    sqlText += " AND STOCK.STOCKADDUPADATERF<=@FINDENDSTOCKADDUPADATERF" + Environment.NewLine;     //  �d���v����t�E�I��
                    sqlText += " AND STOCK.SUPPLIERFORMALRF= 0" + Environment.NewLine;                              //  �d���`���u0�v�i�d���j
                    sqlText += " AND STOCK.DEBITNOTEDIVRF= 0" + Environment.NewLine;                                //  �ԓ`�敪�u0�v�i���`�j
                    sqlText += " AND STOCK.SUPPLIERSLIPCDRF IN (10,20) " + Environment.NewLine;                     //  �d���`�[�敪�u10�v�i�d���jor �u20�v�i�ԕi�j
                    sqlText += " AND STOCK.STOCKGOODSCDRF IN (0,6) " + Environment.NewLine;                         //  �d�����i�敪�u0�v�i���i�jor �u6�v�i���v���́j
                    sqlText += " AND STOCK.ENTERPRISECODERF = SEC.ENTERPRISECODERF " + Environment.NewLine;         //  ����ȍ~�́A���_���ݒ�}�X�^�̌�������
                    sqlText += " AND STOCK.STOCKSECTIONCDRF = SEC.SECTIONCODERF " + Environment.NewLine;

                    sqlText += "ORDER BY" + Environment.NewLine;
                    sqlText += "        STOCKSECTIONCDRF, SUPPLIERCDRF ASC" + Environment.NewLine;
#endif
					// --- ADD 2012/11/18 ---------->>>>>
                    sqlText = string.Empty;
                    sqlText += "SELECT DISTINCT" + Environment.NewLine;
                    sqlText += " STOCK.STOCKSECTIONCDRF AS SECTIONCDRF," + Environment.NewLine;    // �d�����_�R�[�h
                    sqlText += " SEC.SECTIONGUIDESNMRF AS SECNAMERF," + Environment.NewLine;     // �d�����_���i���̃J�����̂݋��_���ݒ�}�X�^����j
                    sqlText += " STOCK.SUPPLIERCDRF AS SUPPLIERCDRF" + Environment.NewLine;      // �d����R�[�h
                    sqlText += "FROM STOCKSLIPHISTRF AS STOCK" + Environment.NewLine;
                    sqlText += "  LEFT JOIN SECINFOSETRF AS SEC WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " ON (STOCK.ENTERPRISECODERF = SEC.ENTERPRISECODERF" + Environment.NewLine;       // ���_���ݒ�}�X�^��������
                    sqlText += " AND STOCK.STOCKSECTIONCDRF = SEC.SECTIONCODERF" + Environment.NewLine;
                    sqlText += " AND SEC.LOGICALDELETECODERF = 0)" + Environment.NewLine;
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "     STOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += " AND STOCK.LOGICALDELETECODERF = 0" + Environment.NewLine;
                    sqlText += " AND STOCK.STOCKSECTIONCDRF<>@FINDSTOCKSECTIONCDRF" + Environment.NewLine;   // �d�����_�R�[�h�͎d���惊�X�g���̃f�[�^�ƈ�v���Ȃ��f�[�^
                    sqlText += " AND STOCK.SUPPLIERCDRF=@FINDPAYEECODERF" + Environment.NewLine;             // �d����R�[�h�͈�v
                    sqlText += " AND STOCK.STOCKADDUPADATERF>=@FINDSTARTSTOCKADDUPADATERF" + Environment.NewLine;        // �d���v����t�E�J�n
                    sqlText += " AND STOCK.STOCKADDUPADATERF<=@FINDENDSTOCKADDUPADATERF" + Environment.NewLine;          // �d���v����t�E�I��
                    sqlText += " AND STOCK.SUPPLIERFORMALRF= 0" + Environment.NewLine;                                   // �d���`���u0�v�i�d���j
                    sqlText += " AND STOCK.SUPPLIERSLIPCDRF IN (10,20)" + Environment.NewLine;                           // �d���`�[�敪�u10�v�i�d���jor �u20�v�i�ԕi�j
                    sqlText += " AND STOCK.STOCKGOODSCDRF IN (0,6)" + Environment.NewLine;                               // �d�����i�敪�u0�v�i���i�jor �u6�v�i���v���́j
                    sqlText += "UNION" + Environment.NewLine;
                    sqlText += "SELECT DISTINCT" + Environment.NewLine;
                    sqlText += " PAY.ADDUPSECCODERF AS SECTIONCDRF," + Environment.NewLine;
                    sqlText += " SEC.SECTIONGUIDESNMRF AS SECNAMERF," + Environment.NewLine;
                    sqlText += " PAY.SUPPLIERCDRF AS SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += "FROM PAYMENTSLPRF AS PAY" + Environment.NewLine;
                    sqlText += "  LEFT JOIN SECINFOSETRF AS SEC WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " ON (PAY.ENTERPRISECODERF = SEC.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND PAY.ADDUPSECCODERF = SEC.SECTIONCODERF" + Environment.NewLine;
                    sqlText += " AND SEC.LOGICALDELETECODERF = 0)" + Environment.NewLine;
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "     PAY.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += " AND PAY.LOGICALDELETECODERF = 0" + Environment.NewLine;
                    sqlText += " AND PAY.ADDUPSECCODERF<>@FINDSTOCKSECTIONCDRF" + Environment.NewLine;
                    sqlText += " AND PAY.SUPPLIERCDRF=@FINDPAYEECODERF" + Environment.NewLine;
                    sqlText += " AND PAY.ADDUPADATERF>=@FINDSTARTSTOCKADDUPADATERF" + Environment.NewLine;
                    sqlText += " AND PAY.ADDUPADATERF<=@FINDENDSTOCKADDUPADATERF" + Environment.NewLine;
                    sqlText += " AND PAY.SUPPLIERFORMALRF= 0" + Environment.NewLine;
                    sqlText += "ORDER BY" + Environment.NewLine;
                    sqlText += "    SECTIONCDRF, SUPPLIERCDRF ASC" + Environment.NewLine;
					// --- ADD 2012/11/18 ----------<<<<<
                    #endregion  ��Select���쐬

                    #region ���N�G�����s�ƒ��o���ʎ擾
                    sqlCommand.CommandText = sqlText;

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaStockSectionCode = sqlCommand.Parameters.Add("@FINDSTOCKSECTIONCDRF", SqlDbType.NChar);
                    SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODERF", SqlDbType.Int);
                    SqlParameter findStartStockAddUpADate = sqlCommand.Parameters.Add("@FINDSTARTSTOCKADDUPADATERF", SqlDbType.Int);
                    SqlParameter findEndStockAddUpADate = sqlCommand.Parameters.Add("@FINDENDSTOCKADDUPADATERF", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_AccPayBalanceWork.EnterpriseCode);
                    findParaStockSectionCode.Value = SqlDataMediator.SqlSetString(paraWork.AddUpSecCode);
                    findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(paraWork.PayeeCode);
                    findStartStockAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(startDate);
                    findEndStockAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(endDate);

                    // �N�G�����s
                    myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            #region [���o����-�l�Z�b�g]
                            RsltInfo_AccPayBalanceWork ResultWork = new RsltInfo_AccPayBalanceWork();

                            ResultWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));         // �d����R�[�h �ݒ��͎x����R�[�h�v���p�e�B�����A�ݒ肷��l�͎d����R�[�h
                            ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCDRF")); // �d�����_�R�[�h
                            ResultWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECNAMERF"));   // �d�����_����

                            // ��L�ȊO�̍��ڂ́A�d����i���x����j�������Ȃ̂ŁA�d���惊�X�g�̃f�[�^���R�s�[
                            //   �d���於�̂ɂ��ẮA�x���於�̃v���p�e�B�ցA�������x���於�̃v���p�e�B�̒l��ݒ肵�Ă��邪�A
                            //   �d���惊�X�g�ɂ͂��Ƃ��Ǝd���於�̂��ݒ肳��Ă���̂Ŗ��͖���
                            ResultWork.AddUpYearMonth = paraWork.AddUpYearMonth;
                            ResultWork.PayeeName = paraWork.PayeeName;
                            ResultWork.PayeeName2 = paraWork.PayeeName2;
                            ResultWork.PayeeSnm = paraWork.PayeeSnm;
                            ResultWork.PaymentCond = paraWork.PaymentCond;
                            ResultWork.PaymentTotalDay = paraWork.PaymentTotalDay;
                            ResultWork.PaymentMonthName = paraWork.PaymentMonthName;
                            ResultWork.PaymentDay = paraWork.PaymentDay;
                            #endregion

                            // �d���惊�X�g�ɒǉ�
                            al.Add(ResultWork);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                        }
                    if (!myReader.IsClosed)
                        myReader.Close();
                    #endregion ���N�G�����s�ƒ��o���ʎ擾

                    #endregion ���d���f�[�^����
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccRecBalanceLedgerDB.GetSupplierForDifferentStockSection Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }

            return status;

        }
        #endregion

        #region [MakeSuplAccPayProcForSumOptOn]
        /// <summary>
        /// �����ɊY�����関�����̔��|�c�������𒊏o���܂��B�i�d�������I�v�V�����L�����j
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <param name="extrInfo_AccPayBalanceWork">�����p�����[�^</param>
        /// <param name="AddUpYearMonth">�����p�����[�^</param>
        /// <param name="uppedList">�W�v�ς݃f�[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����ɊY�����関�����̔��|�c�������𒊏o���܂�</br>
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date       : 2012/10/02</br>
        private int MakeSuplAccPayProcForSumOptOn(ref ArrayList retList, ref RsltInfo_AccPayBalanceWork paraWork, ExtrInfo_AccPayBalanceWork extrInfo_AccPayBalanceWork, DateTime AddUpYearMonth, ArrayList uppedList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            DateTime StMonthDate = DateTime.MinValue;
            DateTime EdMonthDate = DateTime.MinValue;

            //���W�v�Ώۊ��Ԏ擾
            //���Џ��擾
            CompanyInfWork paraCompanyInfWork = new CompanyInfWork();
            CompanyInfDB companyInfDB = new CompanyInfDB();
            ArrayList arrayList;

            paraCompanyInfWork.EnterpriseCode = extrInfo_AccPayBalanceWork.EnterpriseCode;
            companyInfDB.Search(out arrayList, paraCompanyInfWork, ref sqlConnection);
            paraCompanyInfWork = (CompanyInfWork)arrayList[0];
            FinYearTableGenerator parafinYearTableGenerator = new FinYearTableGenerator(paraCompanyInfWork);

            try
            {
                parafinYearTableGenerator.GetDaysFromMonth(AddUpYearMonth, out StMonthDate, out EdMonthDate);
                this._monthlyAddUpDB = new MonthlyAddUpDB();
                SuplAccPayWork suplAccPayWork = new SuplAccPayWork();

                // �����ŏW�v���R�[�h�Ɋi�[�ς݃��X�g�ł���΃��A���W�v���Ȃ�
                foreach (RsltInfo_AccPayBalanceWork uppedWork in uppedList)
                {
                    if (paraWork.AddUpSecCode.Trim() == uppedWork.AddUpSecCode.Trim() &&
                        paraWork.PayeeCode == uppedWork.PayeeCode &&
                        EdMonthDate == uppedWork.AddUpDate)
                    {
                        // �W�v���R�[�h�Ōv��ς݂Ȃ̂Ń��A���W�v���Ȃ�
                        return status;
                    }
                }

                #region ���|���W�v���W���[�� �ďo�p�����[�^�ݒ�
                suplAccPayWork.EnterpriseCode = extrInfo_AccPayBalanceWork.EnterpriseCode;  //��ƃR�[�h
                suplAccPayWork.AddUpSecCode = paraWork.AddUpSecCode.Trim();                 //�������_�R�[�h���d���惊�X�g����
                suplAccPayWork.PayeeCode = paraWork.PayeeCode;                              //�x����R�[�h  ���d���惊�X�g����
                suplAccPayWork.SupplierCd = paraWork.PayeeCode;

                suplAccPayWork.AddUpDate = EdMonthDate;                 //�v��N����(�I��)
                suplAccPayWork.AddUpYearMonth = AddUpYearMonth;         //�v��N��
                if (paraWork.AddUpYearMonth == DateTime.MinValue)
                {
                    // �X�V���� 
                    suplAccPayWork.StMonCAddUpUpdDate = DateTime.MinValue; // �v��N����(�J�n)
                    suplAccPayWork.LaMonCAddUpUpdDate = DateTime.MinValue; // �v��N����(�O�����)
                }
                else
                {
                    // �X�V��������
                    suplAccPayWork.StMonCAddUpUpdDate = StMonthDate;            // �v��N����(�J�n)
                    suplAccPayWork.LaMonCAddUpUpdDate = StMonthDate.AddDays(-1);// �v��N����(�O�����)
                }

                object paraObj2 = (object)suplAccPayWork;
                string retMsg = null;
                #endregion

                //���|���W�v���W���[���ďo�i�d���������A���W�v���\�b�h�j
                status = _monthlyAddUpDB.ReadSuplAccPayByAddUpSecCode(ref paraObj2, out retMsg, ref sqlConnection);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //�擾���ʃL���X�g
                    ArrayList suplAccPayResult = new ArrayList();
                    suplAccPayResult.Add((SuplAccPayWork)paraObj2);
                    DateTime paraLaMonCAddUpUpdDate = DateTime.MinValue;
                    //�擾���ʃZ�b�g
                    for (int j = 0; j < suplAccPayResult.Count; j++)
                    {
                        RsltInfo_AccPayBalanceWork wkRsltInfo_AccPayBalanceWork = new RsltInfo_AccPayBalanceWork();
                        paraLaMonCAddUpUpdDate = DateTime.MinValue;

                        #region ���ʃZ�b�g
                        wkRsltInfo_AccPayBalanceWork.AddUpSecCode = paraWork.AddUpSecCode;
                        wkRsltInfo_AccPayBalanceWork.AddUpSecName = paraWork.AddUpSecName;
                        wkRsltInfo_AccPayBalanceWork.PayeeCode = paraWork.PayeeCode;
                        wkRsltInfo_AccPayBalanceWork.PayeeName = paraWork.PayeeName;
                        wkRsltInfo_AccPayBalanceWork.PayeeName2 = paraWork.PayeeName2;
                        wkRsltInfo_AccPayBalanceWork.PayeeSnm = paraWork.PayeeSnm;
                        wkRsltInfo_AccPayBalanceWork.AddUpDate = ((SuplAccPayWork)suplAccPayResult[j]).AddUpDate;
                        wkRsltInfo_AccPayBalanceWork.AddUpYearMonth = ((SuplAccPayWork)suplAccPayResult[j]).AddUpYearMonth;
                        wkRsltInfo_AccPayBalanceWork.LastTimeAccPay = ((SuplAccPayWork)suplAccPayResult[j]).LastTimeAccPay;
                        wkRsltInfo_AccPayBalanceWork.StckTtl2TmBfBlAccPay = ((SuplAccPayWork)suplAccPayResult[j]).StckTtl2TmBfBlAccPay;
                        wkRsltInfo_AccPayBalanceWork.StckTtl3TmBfBlAccPay = ((SuplAccPayWork)suplAccPayResult[j]).StckTtl3TmBfBlAccPay;
                        wkRsltInfo_AccPayBalanceWork.ThisTimePayNrml = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimePayNrml;
                        wkRsltInfo_AccPayBalanceWork.ThisTimeFeePayNrml = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimeFeePayNrml;
                        wkRsltInfo_AccPayBalanceWork.ThisTimeDisPayNrml = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimeDisPayNrml;
                        wkRsltInfo_AccPayBalanceWork.ThisTimeTtlBlcAcPay = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimeTtlBlcAcPay;
                        wkRsltInfo_AccPayBalanceWork.OfsThisTimeStock = ((SuplAccPayWork)suplAccPayResult[j]).OfsThisTimeStock;
                        wkRsltInfo_AccPayBalanceWork.OfsThisStockTax = ((SuplAccPayWork)suplAccPayResult[j]).OfsThisStockTax;
                        wkRsltInfo_AccPayBalanceWork.ThisTimeStockPrice = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimeStockPrice;
                        wkRsltInfo_AccPayBalanceWork.ThisStcPrcTax = ((SuplAccPayWork)suplAccPayResult[j]).ThisStcPrcTax;
                        wkRsltInfo_AccPayBalanceWork.ThisStckPricRgds = ((SuplAccPayWork)suplAccPayResult[j]).ThisStckPricRgds;
                        wkRsltInfo_AccPayBalanceWork.ThisStcPrcTaxRgds = ((SuplAccPayWork)suplAccPayResult[j]).ThisStcPrcTaxRgds;
                        wkRsltInfo_AccPayBalanceWork.ThisStckPricDis = ((SuplAccPayWork)suplAccPayResult[j]).ThisStckPricDis;
                        wkRsltInfo_AccPayBalanceWork.ThisStcPrcTaxDis = ((SuplAccPayWork)suplAccPayResult[j]).ThisStcPrcTaxDis;
                        wkRsltInfo_AccPayBalanceWork.TaxAdjust = ((SuplAccPayWork)suplAccPayResult[j]).TaxAdjust;
                        wkRsltInfo_AccPayBalanceWork.BalanceAdjust = ((SuplAccPayWork)suplAccPayResult[j]).BalanceAdjust;
                        wkRsltInfo_AccPayBalanceWork.StckTtlAccPayBalance = ((SuplAccPayWork)suplAccPayResult[j]).StckTtlAccPayBalance;
                        wkRsltInfo_AccPayBalanceWork.StockSlipCount = ((SuplAccPayWork)suplAccPayResult[j]).StockSlipCount;
                        wkRsltInfo_AccPayBalanceWork.PaymentCond = paraWork.PaymentCond;
                        wkRsltInfo_AccPayBalanceWork.PaymentTotalDay = paraWork.PaymentTotalDay;
                        wkRsltInfo_AccPayBalanceWork.PaymentMonthName = paraWork.PaymentMonthName;
                        wkRsltInfo_AccPayBalanceWork.PaymentDay = paraWork.PaymentDay;
                        #endregion

                        paraLaMonCAddUpUpdDate = ((SuplAccPayWork)suplAccPayResult[j]).LaMonCAddUpUpdDate;

                        // �O�񗚗������݂���ꍇ�A�O���c���E�J�z�c���E�������c�����v�Z
                        if (paraLaMonCAddUpUpdDate != DateTime.MinValue)
                        {
                            for (int i = 0; i < retList.Count; i++)
                            {
                                if ((((RsltInfo_AccPayBalanceWork)retList[i]).AddUpSecCode == wkRsltInfo_AccPayBalanceWork.AddUpSecCode) &&
                                    (((RsltInfo_AccPayBalanceWork)retList[i]).PayeeCode == wkRsltInfo_AccPayBalanceWork.PayeeCode) &&
                                    (((RsltInfo_AccPayBalanceWork)retList[i]).AddUpDate == paraLaMonCAddUpUpdDate))
                                {
                                    wkRsltInfo_AccPayBalanceWork.LastTimeAccPay = ((RsltInfo_AccPayBalanceWork)retList[i]).StckTtlAccPayBalance; // �O���c��
                                    // ����J�z�c��(���|) = �O��c�� - ����x�����z 
                                    wkRsltInfo_AccPayBalanceWork.ThisTimeTtlBlcAcPay = (wkRsltInfo_AccPayBalanceWork.LastTimeAccPay) - wkRsltInfo_AccPayBalanceWork.ThisTimePayNrml;// ����J�z�c��(���|)
                                    // �v�Z����z = ����J�z�c�� + (���E�㍡��d�����z + ���E�㍡��d�������)
                                    wkRsltInfo_AccPayBalanceWork.StckTtlAccPayBalance = wkRsltInfo_AccPayBalanceWork.ThisTimeTtlBlcAcPay + (wkRsltInfo_AccPayBalanceWork.OfsThisTimeStock + wkRsltInfo_AccPayBalanceWork.OfsThisStockTax);// �v�Z�㐿�����z
                                }
                            }
                        }
                        retList.Add(wkRsltInfo_AccPayBalanceWork);
                    }
                }
                paraWork.AddUpYearMonth = AddUpYearMonth;

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccRecBalanceLedgerDB.MakeSuplAccPayProcForSumOptOn Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion  //[MakeSuplAccPayProcForSumOptOn]

        #region ���W�v���R�[�h�̖������t�p���A���W�v�擾���\�b�h
        /// <summary>
        /// �����ɊY�����関�����̔��|�c�������𒊏o���܂��B�i�d�������I�v�V�����L�����j
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <param name="extrInfo_AccPayBalanceWork">�����p�����[�^</param>
        /// <param name="AddUpYearMonth">�����p�����[�^</param>
        /// <param name="uppedList">�W�v�ς݃f�[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����ɊY�����関�����̔��|�c�������𒊏o���܂�</br>
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date       : 2012/10/02</br>
        private int MakeSuplAccPayProcForAddedData_SumOptOn(ref ArrayList retList, ref RsltInfo_AccPayBalanceWork paraWork, ExtrInfo_AccPayBalanceWork extrInfo_AccPayBalanceWork, DateTime AddUpYearMonth, ArrayList uppedList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            DateTime StMonthDate = DateTime.MinValue;
            DateTime EdMonthDate = DateTime.MinValue;

            //���W�v�Ώۊ��Ԏ擾
            //���Џ��擾
            CompanyInfWork paraCompanyInfWork = new CompanyInfWork();
            CompanyInfDB companyInfDB = new CompanyInfDB();
            ArrayList arrayList;

            paraCompanyInfWork.EnterpriseCode = extrInfo_AccPayBalanceWork.EnterpriseCode;
            companyInfDB.Search(out arrayList, paraCompanyInfWork, ref sqlConnection);
            paraCompanyInfWork = (CompanyInfWork)arrayList[0];
            FinYearTableGenerator parafinYearTableGenerator = new FinYearTableGenerator(paraCompanyInfWork);

            try
            {
                parafinYearTableGenerator.GetDaysFromMonth(AddUpYearMonth, out StMonthDate, out EdMonthDate);
                this._monthlyAddUpDB = new MonthlyAddUpDB();
                SuplAccPayWork suplAccPayWork = new SuplAccPayWork();

                 #region ���|���W�v���W���[�� �ďo�p�����[�^�ݒ�
                suplAccPayWork.EnterpriseCode = extrInfo_AccPayBalanceWork.EnterpriseCode;  //��ƃR�[�h
                suplAccPayWork.AddUpSecCode = paraWork.AddUpSecCode.Trim();                 //�������_�R�[�h���d���惊�X�g����
                suplAccPayWork.PayeeCode = paraWork.PayeeCode;                              //�x����R�[�h  ���d���惊�X�g����
                suplAccPayWork.SupplierCd = paraWork.PayeeCode;

                suplAccPayWork.AddUpDate = EdMonthDate;                 //�v��N����(�I��)
                suplAccPayWork.AddUpYearMonth = AddUpYearMonth;         //�v��N��
                if (paraWork.AddUpYearMonth == DateTime.MinValue)
                {
                    // �X�V���� 
                    suplAccPayWork.StMonCAddUpUpdDate = DateTime.MinValue; // �v��N����(�J�n)
                    suplAccPayWork.LaMonCAddUpUpdDate = DateTime.MinValue; // �v��N����(�O�����)
                }
                else
                {
                    // �X�V��������
                    suplAccPayWork.StMonCAddUpUpdDate = StMonthDate;            // �v��N����(�J�n)
                    suplAccPayWork.LaMonCAddUpUpdDate = StMonthDate.AddDays(-1);// �v��N����(�O�����)
                }

                object paraObj2 = (object)suplAccPayWork;
                string retMsg = null;
                #endregion

                //���|���W�v���W���[���ďo�i�d���������A���W�v���\�b�h�j
                status = _monthlyAddUpDB.ReadSuplAccPayByAddUpSecCode(ref paraObj2, out retMsg, ref sqlConnection);

                // �����ŏW�v���R�[�h����擾�ς݂̃f�[�^�ł���΁A�i�[���Ȃ�
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //�擾���ʃL���X�g
                    ArrayList suplAccPayResult = new ArrayList();
                    suplAccPayResult.Add((SuplAccPayWork)paraObj2);
                    DateTime paraLaMonCAddUpUpdDate = DateTime.MinValue;

                    //�擾���ʃZ�b�g
                    for (int j = 0; j < suplAccPayResult.Count; j++)
                    {
                        RsltInfo_AccPayBalanceWork wkRsltInfo_AccPayBalanceWork = new RsltInfo_AccPayBalanceWork();
                        paraLaMonCAddUpUpdDate = DateTime.MinValue;

                        //�W�v���R�[�h����擾�ς݂̃f�[�^�͏������Ȃ�
                        // ���W�v���R�[�h�Ɠ������̂̓��A���W�v���Ȃ�
                        foreach (RsltInfo_AccPayBalanceWork retWork in retList)
                        {
                            if ((retWork.AddUpDate == ((SuplAccPayWork)suplAccPayResult[0]).AddUpDate) &&
                                retWork.PayeeCode ==((SuplAccPayWork)suplAccPayResult[0]).PayeeCode &&
                                retWork.AddUpSecCode.Trim() == ((SuplAccPayWork)suplAccPayResult[0]).AddUpSecCode.Trim())                            
                            {
                                return status;
                            }
                        }

                        #region ���ʃZ�b�g
                        wkRsltInfo_AccPayBalanceWork.AddUpSecCode = paraWork.AddUpSecCode;
                        wkRsltInfo_AccPayBalanceWork.AddUpSecName = paraWork.AddUpSecName;
                        wkRsltInfo_AccPayBalanceWork.PayeeCode = paraWork.PayeeCode;
                        wkRsltInfo_AccPayBalanceWork.PayeeName = paraWork.PayeeName;
                        wkRsltInfo_AccPayBalanceWork.PayeeName2 = paraWork.PayeeName2;
                        wkRsltInfo_AccPayBalanceWork.PayeeSnm = paraWork.PayeeSnm;
                        wkRsltInfo_AccPayBalanceWork.AddUpDate = ((SuplAccPayWork)suplAccPayResult[j]).AddUpDate;
                        wkRsltInfo_AccPayBalanceWork.AddUpYearMonth = ((SuplAccPayWork)suplAccPayResult[j]).AddUpYearMonth;
                        wkRsltInfo_AccPayBalanceWork.LastTimeAccPay = ((SuplAccPayWork)suplAccPayResult[j]).LastTimeAccPay;
                        wkRsltInfo_AccPayBalanceWork.StckTtl2TmBfBlAccPay = ((SuplAccPayWork)suplAccPayResult[j]).StckTtl2TmBfBlAccPay;
                        wkRsltInfo_AccPayBalanceWork.StckTtl3TmBfBlAccPay = ((SuplAccPayWork)suplAccPayResult[j]).StckTtl3TmBfBlAccPay;
                        wkRsltInfo_AccPayBalanceWork.ThisTimePayNrml = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimePayNrml;
                        wkRsltInfo_AccPayBalanceWork.ThisTimeFeePayNrml = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimeFeePayNrml;
                        wkRsltInfo_AccPayBalanceWork.ThisTimeDisPayNrml = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimeDisPayNrml;
                        wkRsltInfo_AccPayBalanceWork.ThisTimeTtlBlcAcPay = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimeTtlBlcAcPay;
                        wkRsltInfo_AccPayBalanceWork.OfsThisTimeStock = ((SuplAccPayWork)suplAccPayResult[j]).OfsThisTimeStock;
                        wkRsltInfo_AccPayBalanceWork.OfsThisStockTax = ((SuplAccPayWork)suplAccPayResult[j]).OfsThisStockTax;
                        wkRsltInfo_AccPayBalanceWork.ThisTimeStockPrice = ((SuplAccPayWork)suplAccPayResult[j]).ThisTimeStockPrice;
                        wkRsltInfo_AccPayBalanceWork.ThisStcPrcTax = ((SuplAccPayWork)suplAccPayResult[j]).ThisStcPrcTax;
                        wkRsltInfo_AccPayBalanceWork.ThisStckPricRgds = ((SuplAccPayWork)suplAccPayResult[j]).ThisStckPricRgds;
                        wkRsltInfo_AccPayBalanceWork.ThisStcPrcTaxRgds = ((SuplAccPayWork)suplAccPayResult[j]).ThisStcPrcTaxRgds;
                        wkRsltInfo_AccPayBalanceWork.ThisStckPricDis = ((SuplAccPayWork)suplAccPayResult[j]).ThisStckPricDis;
                        wkRsltInfo_AccPayBalanceWork.ThisStcPrcTaxDis = ((SuplAccPayWork)suplAccPayResult[j]).ThisStcPrcTaxDis;
                        wkRsltInfo_AccPayBalanceWork.TaxAdjust = ((SuplAccPayWork)suplAccPayResult[j]).TaxAdjust;
                        wkRsltInfo_AccPayBalanceWork.BalanceAdjust = ((SuplAccPayWork)suplAccPayResult[j]).BalanceAdjust;
                        wkRsltInfo_AccPayBalanceWork.StckTtlAccPayBalance = ((SuplAccPayWork)suplAccPayResult[j]).StckTtlAccPayBalance;
                        wkRsltInfo_AccPayBalanceWork.StockSlipCount = ((SuplAccPayWork)suplAccPayResult[j]).StockSlipCount;
                        wkRsltInfo_AccPayBalanceWork.PaymentCond = paraWork.PaymentCond;
                        wkRsltInfo_AccPayBalanceWork.PaymentTotalDay = paraWork.PaymentTotalDay;
                        wkRsltInfo_AccPayBalanceWork.PaymentMonthName = paraWork.PaymentMonthName;
                        wkRsltInfo_AccPayBalanceWork.PaymentDay = paraWork.PaymentDay;
                        #endregion

                        paraLaMonCAddUpUpdDate = ((SuplAccPayWork)suplAccPayResult[j]).LaMonCAddUpUpdDate;

                        // �O�񗚗������݂���ꍇ�A�O���c���E�J�z�c���E�������c�����v�Z
                        if (paraLaMonCAddUpUpdDate != DateTime.MinValue)
                        {
                            for (int i = 0; i < retList.Count; i++)
                            {
                                if ((((RsltInfo_AccPayBalanceWork)retList[i]).AddUpSecCode == wkRsltInfo_AccPayBalanceWork.AddUpSecCode) &&
                                    (((RsltInfo_AccPayBalanceWork)retList[i]).PayeeCode == wkRsltInfo_AccPayBalanceWork.PayeeCode) &&
                                    (((RsltInfo_AccPayBalanceWork)retList[i]).AddUpDate == paraLaMonCAddUpUpdDate))
                                {
                                    wkRsltInfo_AccPayBalanceWork.LastTimeAccPay = ((RsltInfo_AccPayBalanceWork)retList[i]).StckTtlAccPayBalance; // �O���c��
                                    // ����J�z�c��(���|) = �O��c�� - ����x�����z 
                                    wkRsltInfo_AccPayBalanceWork.ThisTimeTtlBlcAcPay = (wkRsltInfo_AccPayBalanceWork.LastTimeAccPay) - wkRsltInfo_AccPayBalanceWork.ThisTimePayNrml;// ����J�z�c��(���|)
                                    // �v�Z����z = ����J�z�c�� + (���E�㍡��d�����z + ���E�㍡��d�������)
                                    wkRsltInfo_AccPayBalanceWork.StckTtlAccPayBalance = wkRsltInfo_AccPayBalanceWork.ThisTimeTtlBlcAcPay + (wkRsltInfo_AccPayBalanceWork.OfsThisTimeStock + wkRsltInfo_AccPayBalanceWork.OfsThisStockTax);// �v�Z�㐿�����z
                                }
                            }
                        }
                        retList.Add(wkRsltInfo_AccPayBalanceWork);
                    }
                }
               //paraWork.AddUpYearMonth = AddUpYearMonth;

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccRecBalanceLedgerDB.MakeSuplAccPayProcForSumOptOn Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;

        }

        #endregion



        #endregion [�d�������I�v�V�����L�������\�b�h�Q]
        // ---------- ADD 2012/10/02 ----------<<<<<

        #region [WHERE�吶������]
        /// <summary>
        /// WHERE�吶������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="extrInfo_AccPayBalanceWork">���������i�[�N���X</param>
        /// <returns>���|�c���������o��SQL������</returns>
        /// <br>Note       : WHERE�吶������</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.09</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, ExtrInfo_AccPayBalanceWork extrInfo_AccPayBalanceWork)
        {
            //��{WHERE��̍쐬
            StringBuilder retString = new StringBuilder();
            retString.Append("WHERE ");

            //���Œ����
            //��ƃR�[�h
            retString.Append("SUPLACC.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_AccPayBalanceWork.EnterpriseCode);

            //�_���폜�敪
            retString.Append("AND SUPLACC.LOGICALDELETECODERF=0 ");

            //�e���R�[�h�݂̂�ΏۂƂ���(���Ӑ�R�[�h=0�̂ݑΏ�)
            retString.Append("AND SUPLACC.SUPPLIERCDRF=0 ");

            //��������p�����[�^�̒l�ɂ�蓮�I�ω��̍���
            //�v�㋒�_�R�[�h
            if (extrInfo_AccPayBalanceWork.SectionCodes != null)
            {
                string sectionString = "";
                foreach (string sectionCode in extrInfo_AccPayBalanceWork.SectionCodes)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    retString.Append("AND SUPLACC.ADDUPSECCODERF IN (" + sectionString + ") ");
                }
            }

            //������R�[�h
            if (extrInfo_AccPayBalanceWork.St_PayeeCode > 0)
            {
                retString.Append("AND SUPLACC.PAYEECODERF>=@ST_PAYEECODE ");
                SqlParameter paraSt_PayeeCode = sqlCommand.Parameters.Add("@ST_PAYEECODE", SqlDbType.Int);
                paraSt_PayeeCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_AccPayBalanceWork.St_PayeeCode);
            }
            if (extrInfo_AccPayBalanceWork.Ed_PayeeCode > 0)
            {
                retString.Append("AND SUPLACC.PAYEECODERF<=@ED_PAYEECODE ");
                SqlParameter paraEd_PayeeCode = sqlCommand.Parameters.Add("@ED_PAYEECODE", SqlDbType.Int);
                paraEd_PayeeCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_AccPayBalanceWork.Ed_PayeeCode);
            }

            //�Ώ۔N��
            if (extrInfo_AccPayBalanceWork.St_AddUpYearMonth != DateTime.MinValue)
            {
                retString.Append("AND SUPLACC.ADDUPYEARMONTHRF>=@ST_ADDUPYEARMONTH ");
                SqlParameter paraSt_AddUpYearMonth = sqlCommand.Parameters.Add("@ST_ADDUPYEARMONTH", SqlDbType.Int);
                paraSt_AddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(extrInfo_AccPayBalanceWork.St_AddUpYearMonth);
            }
            if (extrInfo_AccPayBalanceWork.Ed_AddUpYearMonth != DateTime.MinValue)
            {
                retString.Append("AND SUPLACC.ADDUPYEARMONTHRF<=@ED_ADDUPYEARMONTH ");
                SqlParameter paraEd_AddUpYearMonth = sqlCommand.Parameters.Add("@ED_ADDUPYEARMONTH", SqlDbType.Int);
                paraEd_AddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(extrInfo_AccPayBalanceWork.Ed_AddUpYearMonth);
            }


            return retString.ToString();
        }
        #endregion

        #region [���|�c���������o���ʃN���X�i�[����]
        /// <summary>
        /// ���|�c���������o���ʃN���X�i�[���� Reader �� RsltInfo_AccPayBalanceWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RsltInfo_AccPayBalanceWork</returns>
        /// <remarks>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.09</br>
        /// </remarks>
        private RsltInfo_AccPayBalanceWork CopyToRsltInfo_AccPayBalanceFromReader(ref SqlDataReader myReader)
        {
            RsltInfo_AccPayBalanceWork wkRsltInfo_AccPayBalanceWork = new RsltInfo_AccPayBalanceWork();

            #region �N���X�֊i�[
            wkRsltInfo_AccPayBalanceWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkRsltInfo_AccPayBalanceWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
            wkRsltInfo_AccPayBalanceWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            wkRsltInfo_AccPayBalanceWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));
            wkRsltInfo_AccPayBalanceWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));
            wkRsltInfo_AccPayBalanceWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            wkRsltInfo_AccPayBalanceWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            wkRsltInfo_AccPayBalanceWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
            wkRsltInfo_AccPayBalanceWork.LastTimeAccPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEACCPAYRF"));
            wkRsltInfo_AccPayBalanceWork.StckTtl2TmBfBlAccPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKTTL2TMBFBLACCPAYRF"));
            wkRsltInfo_AccPayBalanceWork.StckTtl3TmBfBlAccPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKTTL3TMBFBLACCPAYRF"));
            wkRsltInfo_AccPayBalanceWork.ThisTimePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEPAYNRMLRF"));
            wkRsltInfo_AccPayBalanceWork.ThisTimeFeePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEFEEPAYNRMLRF"));
            wkRsltInfo_AccPayBalanceWork.ThisTimeDisPayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDISPAYNRMLRF"));
            wkRsltInfo_AccPayBalanceWork.ThisTimeTtlBlcAcPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLCACPAYRF"));
            wkRsltInfo_AccPayBalanceWork.OfsThisTimeStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESTOCKRF"));
            wkRsltInfo_AccPayBalanceWork.OfsThisStockTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSTOCKTAXRF"));
            wkRsltInfo_AccPayBalanceWork.ThisTimeStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESTOCKPRICERF"));
            wkRsltInfo_AccPayBalanceWork.ThisStcPrcTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCPRCTAXRF"));
            wkRsltInfo_AccPayBalanceWork.ThisStckPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICRGDSRF"));
            wkRsltInfo_AccPayBalanceWork.ThisStcPrcTaxRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCPRCTAXRGDSRF"));
            wkRsltInfo_AccPayBalanceWork.ThisStckPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICDISRF"));
            wkRsltInfo_AccPayBalanceWork.ThisStcPrcTaxDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCPRCTAXDISRF"));
            wkRsltInfo_AccPayBalanceWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));
            wkRsltInfo_AccPayBalanceWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));
            wkRsltInfo_AccPayBalanceWork.StckTtlAccPayBalance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKTTLACCPAYBALANCERF"));
            wkRsltInfo_AccPayBalanceWork.StockSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCOUNTRF"));
            wkRsltInfo_AccPayBalanceWork.PaymentCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTCONDRF"));
            wkRsltInfo_AccPayBalanceWork.PaymentTotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTTOTALDAYRF"));
            wkRsltInfo_AccPayBalanceWork.PaymentMonthName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONTHNAMERF"));
            wkRsltInfo_AccPayBalanceWork.PaymentDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF"));
            #endregion

            return wkRsltInfo_AccPayBalanceWork;
        }

        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.09</br>
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
