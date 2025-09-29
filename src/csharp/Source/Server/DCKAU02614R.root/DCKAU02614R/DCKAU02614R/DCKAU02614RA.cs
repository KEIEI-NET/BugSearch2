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
    /// <br>Update Note: 2008.09.27 ���� PM.NS�p�ɏC��</br>
    /// <br>Update Note: 2013/10/24 gezh</br>
    /// <br>             Redmine#39753���|�c�������̏���ŕs���ɂȂ錏�̑Ή�</br>
    /// </remarks>
    [Serializable]
    public class AccRecBalanceLedgerDB : RemoteDB, IAccRecBalanceLedgerDB
    {
        /// <summary>
        /// ���|�c������DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.09</br>
        /// </remarks>
        public AccRecBalanceLedgerDB()
            :
            base("DCKAU02616D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_AccRecBalanceWork", "CUSTACCRECRF")
        {
        }

        #region [SearchAccRecBalanceLedger]


        /// <summary>���|/���|���z�}�X�^�X�V�����[�g�I�u�W�F�N�g</summary>
        private MonthlyAddUpDB _monthlyAddUpDB;

        /// <summary>
        /// �w�肳�ꂽ�����̔��|�c��������߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔��|�c��������߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.09</br>
        public int SearchAccRecBalanceLedger(out object retObj, object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //SqlEncryptInfo sqlEncryptInfo = null;
            retObj = null;

            ExtrInfo_AccRecBalanceWork extrInfo_AccRecBalanceWork = null;

            ArrayList extrInfo_AccRecBalanceWorkList = paraObj as ArrayList;
            ArrayList retList = new ArrayList();

            if (extrInfo_AccRecBalanceWorkList == null)
            {
                extrInfo_AccRecBalanceWork = paraObj as ExtrInfo_AccRecBalanceWork;
            }
            else
            {
                if (extrInfo_AccRecBalanceWorkList.Count > 0)
                    extrInfo_AccRecBalanceWork = extrInfo_AccRecBalanceWorkList[0] as ExtrInfo_AccRecBalanceWork;
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
                status = SearchAccRecBalanceLedgerProc(ref retList, extrInfo_AccRecBalanceWork, ref sqlConnection);
                 
                // ADD 2009.01.09 >>>
                //���������擾
                status = SearchDepsitSalesLedgerProc(ref retList, extrInfo_AccRecBalanceWork, ref sqlConnection);
                // ADD 2009.01.09 <<<
                if (retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccRecBalanceLedgerDB.SearchAccRecBalanceLedger");
                retObj = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                ////���Í����L�[CLOSE
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
        // ADD 2009.01.09 >>>
        /// <summary>
        /// �w�肳�ꂽ�����̖������̔��|�c��������߂��܂�
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="extrInfo_AccRecBalanceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̖������̔��|�c��������߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2009.01.09</br>
        /// <br>Update Note: 2013/10/24 gezh</br>
        /// <br>             Redmine#39753���|�c�������̏���ŕs���ɂȂ錏�̑Ή�</br>
        private int SearchDepsitSalesLedgerProc(ref ArrayList retList, ExtrInfo_AccRecBalanceWork extrInfo_AccRecBalanceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ArrayList customerList = new ArrayList();
            RsltInfo_AccRecBalanceWork paraWork = new RsltInfo_AccRecBalanceWork();
            DateTime StAddUpYearMonth = DateTime.MinValue;

            try
            {
                //�����Ӑ惊�X�g�쐬
                status = SearchCustProc(ref customerList, extrInfo_AccRecBalanceWork, ref sqlConnection);

                //���ŏI�����Z�o(���Ӑ攄�|���z�}�X�^)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = GetMonthlyAddUpHis(ref customerList, extrInfo_AccRecBalanceWork, ref sqlConnection);
                }
                
                //���W�v�Ώۊ��Ԃ̔��菈��
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    for (int i = 0; i < customerList.Count; i++)
                    {
                        paraWork = customerList[i] as RsltInfo_AccRecBalanceWork;
                        DateTime addUpYearMonthBak = paraWork.AddUpYearMonth;  // ���Ӑ�ŏI�����N���[��  // ADD 2013/10/24 gezh for Redmine#39753
                        if (paraWork.AddUpYearMonth < extrInfo_AccRecBalanceWork.Ed_AddUpYearMonth)
                        {
                            StAddUpYearMonth = extrInfo_AccRecBalanceWork.St_AddUpYearMonth;
                            while (true)
                            {
                                //�I������
                                if (StAddUpYearMonth > extrInfo_AccRecBalanceWork.Ed_AddUpYearMonth)
                                {
                                    break;
                                }
                                // ------ ADD 2013/10/24 gezh for Redmine#39753 ------------------------------>>>>>
                                if (addUpYearMonthBak == StAddUpYearMonth.AddMonths(-1))
                                {
                                    paraWork.AddUpYearMonth = DateTime.MinValue;
                                }
                                else
                                {
                                    paraWork.AddUpYearMonth = addUpYearMonthBak;
                                }
                                // ------ ADD 2013/10/24 gezh for Redmine#39753 ------------------------------<<<<<
                                // ���Ӑ�ŏI���� < ��ʊJ�n�N��
                                if (paraWork.AddUpYearMonth < StAddUpYearMonth)
                                {
                                    // ���������W�v����
                                    MakeCustAccRecProc(ref retList, ref paraWork, extrInfo_AccRecBalanceWork, StAddUpYearMonth, ref sqlConnection);
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
                base.WriteErrorLog(ex, "BillBalanceTableDB.SearchDepsitSalesLedgerProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;

        }


        #region [MakeCustAccRecProc]
        /// <summary>
        /// �����ɊY�����関�����̔��|�c�������𒊏o���܂��B
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <param name="extrInfo_AccRecBalanceWork">�����p�����[�^</param>
        /// <param name="AddUpYearMonth">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����ɊY�����関�����̔��|�c�������𒊏o���܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2009.01.09</br>
        private int MakeCustAccRecProc(ref ArrayList retList, ref RsltInfo_AccRecBalanceWork paraWork, ExtrInfo_AccRecBalanceWork extrInfo_AccRecBalanceWork, DateTime AddUpYearMonth,  ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            DateTime StMonthDate = DateTime.MinValue;
            DateTime EdMonthDate = DateTime.MinValue;

            //���W�v�Ώۊ��Ԏ擾
            //���Џ��擾
            CompanyInfWork paraCompanyInfWork = new CompanyInfWork();
            CompanyInfDB companyInfDB = new CompanyInfDB();
            ArrayList arrayList;

            paraCompanyInfWork.EnterpriseCode = extrInfo_AccRecBalanceWork.EnterpriseCode;
            companyInfDB.Search(out arrayList, paraCompanyInfWork, ref sqlConnection);
            paraCompanyInfWork = (CompanyInfWork)arrayList[0];
            FinYearTableGenerator parafinYearTableGenerator = new FinYearTableGenerator(paraCompanyInfWork);

            try
            {                
                parafinYearTableGenerator.GetDaysFromMonth(AddUpYearMonth, out StMonthDate, out EdMonthDate);
                this._monthlyAddUpDB = new MonthlyAddUpDB();
                CustAccRecWork custAccRecWork = new CustAccRecWork();

                #region ���|���W�v���W���[�� �ďo�p�����[�^�ݒ�
                custAccRecWork.EnterpriseCode = extrInfo_AccRecBalanceWork.EnterpriseCode;//��ƃR�[�h    �����Ӑ惊�X�g����
                custAccRecWork.AddUpSecCode = paraWork.AddUpSecCode;    //�������_�R�[�h�����Ӑ惊�X�g����
                custAccRecWork.CustomerCode = paraWork.ClaimCode;       //���Ӑ�R�[�h  �����Ӑ惊�X�g����

                custAccRecWork.AddUpDate = EdMonthDate;          //�v��N����(�I��)
                custAccRecWork.AddUpYearMonth = AddUpYearMonth;//�v��N��
                if (paraWork.AddUpYearMonth == DateTime.MinValue)
                {
                    // �X�V���� 
                    custAccRecWork.StMonCAddUpUpdDate = DateTime.MinValue; // �v��N����(�J�n)
                    custAccRecWork.LaMonCAddUpUpdDate = DateTime.MinValue; // �v��N����(�O�����)
                }
                else
                {
                    // �X�V��������
                    custAccRecWork.StMonCAddUpUpdDate = StMonthDate; // �v��N����(�J�n)
                    custAccRecWork.LaMonCAddUpUpdDate = StMonthDate.AddDays(-1);// �v��N����(�O�����)
                }

                object paraObj2 = (object)custAccRecWork;
                string retMsg = null;
                #endregion

                //���|���W�v���W���[���ďo
                status = _monthlyAddUpDB.ReadCustAccRec(ref paraObj2, out retMsg,ref sqlConnection);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //�擾���ʃL���X�g
                    ArrayList custAccRecResult = new ArrayList();
                    custAccRecResult.Add((CustAccRecWork)paraObj2);
                    DateTime paraLaMonCAddUpUpdDate = DateTime.MinValue;
                    //�擾���ʃZ�b�g
                    for (int j = 0; j < custAccRecResult.Count; j++)
                    {
                        RsltInfo_AccRecBalanceWork wkRsltInfo_AccRecBalanceWork = new RsltInfo_AccRecBalanceWork();
                        paraLaMonCAddUpUpdDate = DateTime.MinValue;

                        #region ���ʃZ�b�g
                        wkRsltInfo_AccRecBalanceWork.AddUpSecCode = paraWork.AddUpSecCode;
                        wkRsltInfo_AccRecBalanceWork.AddUpSecName = paraWork.AddUpSecName;
                        wkRsltInfo_AccRecBalanceWork.ClaimCode = paraWork.ClaimCode;
                        wkRsltInfo_AccRecBalanceWork.ClaimName = paraWork.ClaimName;
                        wkRsltInfo_AccRecBalanceWork.ClaimName2 = paraWork.ClaimName2;
                        wkRsltInfo_AccRecBalanceWork.ClaimSnm = paraWork.ClaimSnm;
                        wkRsltInfo_AccRecBalanceWork.AddUpDate = ((CustAccRecWork)custAccRecResult[j]).AddUpDate;
                        wkRsltInfo_AccRecBalanceWork.AddUpYearMonth = ((CustAccRecWork)custAccRecResult[j]).AddUpYearMonth;
                        wkRsltInfo_AccRecBalanceWork.LastTimeAccRec = ((CustAccRecWork)custAccRecResult[j]).LastTimeAccRec;
                        wkRsltInfo_AccRecBalanceWork.AcpOdrTtl2TmBfAccRec = ((CustAccRecWork)custAccRecResult[j]).AcpOdrTtl2TmBfAccRec;
                        wkRsltInfo_AccRecBalanceWork.AcpOdrTtl3TmBfAccRec = ((CustAccRecWork)custAccRecResult[j]).AcpOdrTtl3TmBfAccRec;
                        wkRsltInfo_AccRecBalanceWork.ThisTimeDmdNrml = ((CustAccRecWork)custAccRecResult[j]).ThisTimeDmdNrml;
                        wkRsltInfo_AccRecBalanceWork.ThisTimeFeeDmdNrml = ((CustAccRecWork)custAccRecResult[j]).ThisTimeFeeDmdNrml;
                        wkRsltInfo_AccRecBalanceWork.ThisTimeDisDmdNrml = ((CustAccRecWork)custAccRecResult[j]).ThisTimeDisDmdNrml;
                        wkRsltInfo_AccRecBalanceWork.ThisTimeTtlBlcAcc = ((CustAccRecWork)custAccRecResult[j]).ThisTimeTtlBlcAcc;
                        wkRsltInfo_AccRecBalanceWork.OfsThisTimeSales = ((CustAccRecWork)custAccRecResult[j]).OfsThisTimeSales;
                        wkRsltInfo_AccRecBalanceWork.OfsThisSalesTax = ((CustAccRecWork)custAccRecResult[j]).OfsThisSalesTax;
                        wkRsltInfo_AccRecBalanceWork.ThisTimeSales = ((CustAccRecWork)custAccRecResult[j]).ThisTimeSales;
                        wkRsltInfo_AccRecBalanceWork.ThisSalesTax = ((CustAccRecWork)custAccRecResult[j]).ThisSalesTax;
                        wkRsltInfo_AccRecBalanceWork.ThisSalesPricRgds = ((CustAccRecWork)custAccRecResult[j]).ThisSalesPricRgds;
                        wkRsltInfo_AccRecBalanceWork.ThisSalesPrcTaxRgds = ((CustAccRecWork)custAccRecResult[j]).ThisSalesPrcTaxRgds;
                        wkRsltInfo_AccRecBalanceWork.ThisSalesPricDis = ((CustAccRecWork)custAccRecResult[j]).ThisSalesPricDis;
                        wkRsltInfo_AccRecBalanceWork.ThisSalesPrcTaxDis = ((CustAccRecWork)custAccRecResult[j]).ThisSalesPrcTaxDis;
                        wkRsltInfo_AccRecBalanceWork.TaxAdjust = ((CustAccRecWork)custAccRecResult[j]).TaxAdjust;
                        wkRsltInfo_AccRecBalanceWork.BalanceAdjust = ((CustAccRecWork)custAccRecResult[j]).BalanceAdjust;
                        wkRsltInfo_AccRecBalanceWork.AfCalTMonthAccRec = ((CustAccRecWork)custAccRecResult[j]).AfCalTMonthAccRec;
                        wkRsltInfo_AccRecBalanceWork.SalesSlipCount = ((CustAccRecWork)custAccRecResult[j]).SalesSlipCount;
                        wkRsltInfo_AccRecBalanceWork.CollectCond = paraWork.CollectCond;
                        wkRsltInfo_AccRecBalanceWork.TotalDay = paraWork.TotalDay;
                        wkRsltInfo_AccRecBalanceWork.CollectMoneyName = paraWork.CollectMoneyName;
                        wkRsltInfo_AccRecBalanceWork.CollectMoneyDay = paraWork.CollectMoneyDay;
                        wkRsltInfo_AccRecBalanceWork.BillCollecterCd = paraWork.BillCollecterCd;
                        wkRsltInfo_AccRecBalanceWork.BillCollecterNm = paraWork.BillCollecterNm;
                        #endregion

                        paraLaMonCAddUpUpdDate = ((CustAccRecWork)custAccRecResult[j]).LaMonCAddUpUpdDate;

                        // �O�񗚗������݂���ꍇ�A�O���c���E�J�z�c���E�������c�����v�Z
                        if (paraLaMonCAddUpUpdDate != DateTime.MinValue)
                        {
                            for (int i = 0; i < retList.Count; i++)
                            {
                                if ((((RsltInfo_AccRecBalanceWork)retList[i]).AddUpSecCode == wkRsltInfo_AccRecBalanceWork.AddUpSecCode) &&
                                    (((RsltInfo_AccRecBalanceWork)retList[i]).ClaimCode == wkRsltInfo_AccRecBalanceWork.ClaimCode) &&
                                    (((RsltInfo_AccRecBalanceWork)retList[i]).AddUpDate == paraLaMonCAddUpUpdDate))
                                {
                                    wkRsltInfo_AccRecBalanceWork.LastTimeAccRec = ((RsltInfo_AccRecBalanceWork)retList[i]).AfCalTMonthAccRec; // �O���c��
                                    // ����J�z�c��(���|) = �O�񐿋��c�� - ����������z 
                                    wkRsltInfo_AccRecBalanceWork.ThisTimeTtlBlcAcc = (wkRsltInfo_AccRecBalanceWork.LastTimeAccRec) - wkRsltInfo_AccRecBalanceWork.ThisTimeDmdNrml;// ����J�z�c��(���|)
                                    // �v�Z�㐿�����z = ����J�z�c�� + (���E�㍡�񔄏���z + ���E�㍡�񔄏�����)
                                    wkRsltInfo_AccRecBalanceWork.AfCalTMonthAccRec = wkRsltInfo_AccRecBalanceWork.ThisTimeTtlBlcAcc + (wkRsltInfo_AccRecBalanceWork.OfsThisTimeSales + wkRsltInfo_AccRecBalanceWork.OfsThisSalesTax);// �v�Z�㐿�����z
                                }
                            }
                        }

                        retList.Add(wkRsltInfo_AccRecBalanceWork);

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
                base.WriteErrorLog(ex, "BillBalanceTableDB.MakeCustAccRecProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion  //[MakeCustAccRecProc]

        #region [GetMonthlyAddUpHis]
        /// <summary>
        /// ���Ӑ攄�|���z�}�X�^��������ɊY������ŏI�����𒊏o���܂��B
        /// </summary>
        /// <param name="al">��������</param>
        /// <param name="extrInfo_AccRecBalanceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍ŏI������߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.09.22</br>
        /// <br>Update Note: 2013/10/24 gezh</br>
        /// <br>             Redmine#39753���|�c�������̏���ŕs���ɂȂ錏�̑Ή�</br>
        private int GetMonthlyAddUpHis(ref ArrayList al, ExtrInfo_AccRecBalanceWork extrInfo_AccRecBalanceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            RsltInfo_AccRecBalanceWork paraWork = new RsltInfo_AccRecBalanceWork();
            string sqlText = string.Empty;

            try
            {
                for (int i = 0; i < al.Count; i++)
                {
                    paraWork = al[i] as RsltInfo_AccRecBalanceWork;
                    sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection);
                    sqlCommand.Parameters.Clear();
                    sqlCommand.CommandText = string.Empty;


                    // �Ώۃe�[�u��
                    // CUSTACCRECRF ���Ӑ攄�|���z�}�X�^
                    #region [Select���쐬]
                    sqlText = string.Empty; 
                    sqlText += "SELECT " + Environment.NewLine;
                    sqlText += "   ADDUPYEARMONTHRF " + Environment.NewLine;
                    sqlText += "  ,ADDUPDATERF " + Environment.NewLine;
                    sqlText += " FROM CUSTACCRECRF WITH(READUNCOMMITTED) " + Environment.NewLine;
                    sqlText += " WHERE " + Environment.NewLine;
                    sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                    sqlText += "  AND CLAIMCODERF=@FINDCUSTOMERCODE " + Environment.NewLine;
                    sqlText += "  AND CUSTOMERCODERF=0 " + Environment.NewLine;
                    sqlText += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE " + Environment.NewLine;
                    sqlText += "  AND ADDUPDATERF= " + Environment.NewLine;
                    sqlText += "  ( " + Environment.NewLine;
                    sqlText += "   SELECT MAX(ADDUPDATERF)" + Environment.NewLine;
                    sqlText += "   FROM  CUSTACCRECRF WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "   WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "     AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "     AND CLAIMCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += "     AND CUSTOMERCODERF=0" + Environment.NewLine;
                    sqlText += "  ) " + Environment.NewLine;
                    #endregion  //[Select���쐬]

                    sqlCommand.CommandText = sqlText;

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_AccRecBalanceWork.EnterpriseCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(paraWork.ClaimCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(paraWork.AddUpSecCode.Trim());

                    myReader = sqlCommand.ExecuteReader();

                    ((RsltInfo_AccRecBalanceWork)al[i]).AddUpYearMonth = DateTime.MinValue;

                    while (myReader.Read())
                    {
                        //[���o����-�l�Z�b�g]
                        ((RsltInfo_AccRecBalanceWork)al[i]).AddUpYearMonth = TDateTime.LongDateToDateTime("YYYYMM", SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")));
                        // ------ DEL 2013/10/24 gezh for Redmine#39753 ------------------------------>>>>>
                        //if (((RsltInfo_AccRecBalanceWork)al[i]).AddUpYearMonth == extrInfo_AccRecBalanceWork.St_AddUpYearMonth.AddMonths(-1))
                        //{
                        //    //��ʊJ�n�N��= �O�񗚗�-�P�����̏ꍇ�A���|���z�W�v���W���[���ɂđO������擾������
                        //    // ��((RsltInfo_AccRecBalanceWork)al[i]).AddUpYearMonth��DateTime.MinValue�̏ꍇ�A���|���z�W�v���W���[���ɂđO������擾����
                        //    ((RsltInfo_AccRecBalanceWork)al[i]).AddUpYearMonth = DateTime.MinValue;
                        //}
                        // ------ DEL 2013/10/24 gezh for Redmine#39753 ------------------------------<<<<<
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
                base.WriteErrorLog(ex, "BillBalanceTableDB.SearchCustProc Exception=" + ex.Message);
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

        #region [SearchCustProc]
        /// <summary>
        /// ���Ӑ�}�X�^��������ɊY�����链�Ӑ惊�X�g�𒊏o���܂��B
        /// </summary>
        /// <param name="al">��������</param>
        /// <param name="extrInfo_AccRecBalanceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓��Ӑ惊�X�g��߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.09.22</br>
        private int SearchCustProc(ref ArrayList al, ExtrInfo_AccRecBalanceWork extrInfo_AccRecBalanceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // �Ώۃe�[�u��
                // CUSTOMERRF        CSTMER ���Ӑ�}�X�^
                // SECINFOSETRF      SCINST ���_���ݒ�}�X�^

                #region [Select���쐬]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += " CSTMER.CLAIMSECTIONCODERF," + Environment.NewLine;
                selectTxt += " SCINST.SECTIONGUIDESNMRF," + Environment.NewLine;
                selectTxt += " CSTMER.CUSTOMERCODERF," + Environment.NewLine;
                selectTxt += " CSTMER.CLAIMCODERF," + Environment.NewLine;
                selectTxt += " CSTMER.NAMERF," + Environment.NewLine;
                selectTxt += " CSTMER.NAME2RF," + Environment.NewLine;
                selectTxt += " CSTMER.CUSTOMERSNMRF, " + Environment.NewLine;
                selectTxt += " CSTMER.TOTALDAYRF," + Environment.NewLine;
                selectTxt += " CSTMER.COLLECTCONDRF," + Environment.NewLine;
                selectTxt += " CSTMER.COLLECTMONEYNAMERF," + Environment.NewLine;
                selectTxt += " CSTMER.COLLECTMONEYDAYRF," + Environment.NewLine;
                selectTxt += " CSTMER.BILLCOLLECTERCDRF," + Environment.NewLine;
                selectTxt += " EMP.SHORTNAMERF AS BILLCOLLECTERNMRF" + Environment.NewLine;
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += " CUSTOMERRF AS CSTMER" + Environment.NewLine;

                #region [JOIN]
                //���_���ݒ�}�X�^
                selectTxt += "LEFT JOIN SECINFOSETRF SCINST" + Environment.NewLine;
                selectTxt += " ON  SCINST.ENTERPRISECODERF=CSTMER.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SCINST.SECTIONCODERF=CSTMER.CLAIMSECTIONCODERF" + Environment.NewLine;
                //�]�ƈ��}�X�^
                selectTxt += "LEFT JOIN EMPLOYEERF AS EMP" + Environment.NewLine;
                selectTxt += " ON  CSTMER.ENTERPRISECODERF=EMP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND CSTMER.BILLCOLLECTERCDRF=EMP.EMPLOYEECODERF" + Environment.NewLine;
                #endregion  //[JOIN]

                #region [WHERE��]
                selectTxt += " WHERE" + Environment.NewLine;

                //��ƃR�[�h
                selectTxt += " CSTMER.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_AccRecBalanceWork.EnterpriseCode);

                //�_���폜�敪
                selectTxt += " AND CSTMER.LOGICALDELETECODERF=0" + Environment.NewLine;

                // �e���Ӑ�R�[�h�̂ݑΏ�
                selectTxt += " AND CSTMER.CUSTOMERCODERF = CSTMER.CLAIMCODERF" + Environment.NewLine;
                selectTxt += "AND CSTMER.CLAIMSECTIONCODERF !=0 " + Environment.NewLine;
                selectTxt += "AND CSTMER.CLAIMSECTIONCODERF IS NOT NULL " + Environment.NewLine;
                selectTxt += "AND CSTMER.CLAIMCODERF !=0" + Environment.NewLine;
                selectTxt += "AND CSTMER.CLAIMCODERF IS NOT NULL " + Environment.NewLine;

                //���_�R�[�h
                if (extrInfo_AccRecBalanceWork.SectionCodes != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in extrInfo_AccRecBalanceWork.SectionCodes)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }
                    if (sectionCodestr != "")
                    {
                        selectTxt += " AND CSTMER.CLAIMSECTIONCODERF IN (" + sectionCodestr + ") ";
                    }
                    selectTxt += Environment.NewLine;
                }

                //���Ӑ�R�[�h
                if (extrInfo_AccRecBalanceWork.St_ClaimCode != 0)
                {
                    selectTxt += " AND CSTMER.CLAIMCODERF>=@ST_CUSTOMERCOD" + Environment.NewLine;
                    SqlParameter paraSt_CustomerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCOD", SqlDbType.Int);
                    paraSt_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_AccRecBalanceWork.St_ClaimCode);
                }
                if (extrInfo_AccRecBalanceWork.Ed_ClaimCode != 99999999 && extrInfo_AccRecBalanceWork.Ed_ClaimCode != 0)
                {
                    selectTxt += " AND CSTMER.CLAIMCODERF<=@ED_CUSTOMERCOD" + Environment.NewLine;
                    SqlParameter paraEd_CustomerCode = sqlCommand.Parameters.Add("@ED_CUSTOMERCOD", SqlDbType.Int);
                    paraEd_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_AccRecBalanceWork.Ed_ClaimCode);
                }
                #endregion  //[WHERE��]

                #region [ORDER BY]
                selectTxt += "ORDER BY " + Environment.NewLine;
                selectTxt += " CSTMER.CLAIMSECTIONCODERF," + Environment.NewLine;
                selectTxt += " CSTMER.CLAIMCODERF" + Environment.NewLine;
                #endregion

                #endregion  //[Select���쐬]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    RsltInfo_AccRecBalanceWork ResultWork = new RsltInfo_AccRecBalanceWork();

                    #region [���o����-�l�Z�b�g]
                    ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSECTIONCODERF"));
                    ResultWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    ResultWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                    ResultWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    ResultWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                    ResultWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));
                    ResultWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
                    ResultWork.CollectCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTCONDRF"));
                    ResultWork.CollectMoneyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLLECTMONEYNAMERF"));
                    ResultWork.CollectMoneyDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"));
                    ResultWork.BillCollecterCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERCDRF"));
                    ResultWork.BillCollecterNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERNMRF"));
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
                base.WriteErrorLog(ex, "BillBalanceTableDB.SearchCustProc Exception=" + ex.Message);
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
        #endregion  //[SearchCustProc]

        // ADD 2009.01.09 <<<

        /// <summary>
        /// �w�肳�ꂽ�����̔��|�c��������߂��܂�
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="extrInfo_AccRecBalanceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔��|�c��������߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.09</br>
        private int SearchAccRecBalanceLedgerProc(ref ArrayList retList, ExtrInfo_AccRecBalanceWork extrInfo_AccRecBalanceWork, ref SqlConnection sqlConnection)
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
                selectTxt += "   CUSACC.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  ,SEC.SECTIONGUIDESNMRF AS ADDUPSECNAMERF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.CLAIMCODERF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.CLAIMNAMERF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.CLAIMNAME2RF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.CLAIMSNMRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.ADDUPDATERF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.ADDUPYEARMONTHRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.LASTTIMEACCRECRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.ACPODRTTL2TMBFACCRECRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.ACPODRTTL3TMBFACCRECRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.THISTIMEDMDNRMLRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.THISTIMEFEEDMDNRMLRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.THISTIMEDISDMDNRMLRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.THISTIMETTLBLCACCRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.OFSTHISTIMESALESRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.OFSTHISSALESTAXRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.THISTIMESALESRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.THISSALESTAXRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.THISSALESPRICRGDSRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.THISSALESPRCTAXRGDSRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.THISSALESPRICDISRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.THISSALESPRCTAXDISRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.TAXADJUSTRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.BALANCEADJUSTRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.AFCALTMONTHACCRECRF" + Environment.NewLine;
                selectTxt += "  ,CUSACC.SALESSLIPCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,CUST.COLLECTCONDRF" + Environment.NewLine;
                selectTxt += "  ,CUST.TOTALDAYRF" + Environment.NewLine;
                selectTxt += "  ,CUST.COLLECTMONEYNAMERF" + Environment.NewLine;
                selectTxt += "  ,CUST.COLLECTMONEYDAYRF" + Environment.NewLine;
                selectTxt += "  ,CUST.BILLCOLLECTERCDRF" + Environment.NewLine;
                selectTxt += "  ,EMP.SHORTNAMERF AS BILLCOLLECTERNMRF" + Environment.NewLine;
                selectTxt += "FROM CUSTACCRECRF AS CUSACC" + Environment.NewLine;
                selectTxt += "LEFT JOIN CUSTOMERRF AS CUST" + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     CUSACC.ENTERPRISECODERF=CUST.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND CUSACC.CLAIMCODERF=CUST.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     CUSACC.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND CUSACC.ADDUPSECCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN EMPLOYEERF AS EMP" + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     CUSACC.ENTERPRISECODERF=EMP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND CUST.BILLCOLLECTERCDRF=EMP.EMPLOYEECODERF" + Environment.NewLine;

                #endregion

                //Where��쐬
                selectTxt += MakeWhereString(ref sqlCommand, extrInfo_AccRecBalanceWork);

                //�v�㋒�_�R�[�h�{������R�[�h�{�v��N�����ɕ��ёւ���
                selectTxt += "ORDER BY" + Environment.NewLine;
                selectTxt += "  CUSACC.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += ", CUSACC.CLAIMCODERF" + Environment.NewLine;
                selectTxt += ", CUSACC.ADDUPYEARMONTHRF" + Environment.NewLine;

                sqlCommand.CommandText = selectTxt;    
                
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    retList.Add(CopyToRsltInfo_AccRecBalanceFromReader(ref myReader));

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

        #region [WHERE�吶������]
        /// <summary>
        /// WHERE�吶������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="extrInfo_AccRecBalanceWork">���������i�[�N���X</param>
        /// <returns>���|�c���������o��SQL������</returns>
        /// <br>Note       : WHERE�吶������</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.09</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, ExtrInfo_AccRecBalanceWork extrInfo_AccRecBalanceWork)
        {
            //��{WHERE��̍쐬
            StringBuilder retString = new StringBuilder();
            retString.Append("WHERE ");

            //���Œ����
            //��ƃR�[�h
            retString.Append("CUSACC.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_AccRecBalanceWork.EnterpriseCode);

            //�_���폜�敪
            retString.Append("AND CUSACC.LOGICALDELETECODERF=0 ");

            //�e���R�[�h�݂̂�ΏۂƂ���(���Ӑ�R�[�h=0�̂ݑΏ�)
            retString.Append("AND CUSACC.CUSTOMERCODERF=0 ");

            //��������p�����[�^�̒l�ɂ�蓮�I�ω��̍���
            //�v�㋒�_�R�[�h
            if (extrInfo_AccRecBalanceWork.SectionCodes != null)
            {
                string sectionString = "";
                foreach (string sectionCode in extrInfo_AccRecBalanceWork.SectionCodes)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    retString.Append("AND CUSACC.ADDUPSECCODERF IN (" + sectionString + ") ");
                }
            }

            //������R�[�h
            if (extrInfo_AccRecBalanceWork.St_ClaimCode > 0)
            {
                retString.Append("AND CUSACC.CLAIMCODERF>=@ST_CLAIMCODE ");
                SqlParameter paraSt_ClaimCode = sqlCommand.Parameters.Add("@ST_CLAIMCODE", SqlDbType.Int);
                paraSt_ClaimCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_AccRecBalanceWork.St_ClaimCode);
            }
            if (extrInfo_AccRecBalanceWork.Ed_ClaimCode > 0)
            {
                retString.Append("AND CUSACC.CLAIMCODERF<=@ED_CLAIMCODE ");
                SqlParameter paraEd_ClaimCode = sqlCommand.Parameters.Add("@ED_CLAIMCODE", SqlDbType.Int);
                paraEd_ClaimCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_AccRecBalanceWork.Ed_ClaimCode);
            }

            //�Ώ۔N��
            if (extrInfo_AccRecBalanceWork.St_AddUpYearMonth != DateTime.MinValue)
            {
                retString.Append("AND CUSACC.ADDUPYEARMONTHRF>=@ST_ADDUPYEARMONTH ");
                SqlParameter paraSt_AddUpYearMonth = sqlCommand.Parameters.Add("@ST_ADDUPYEARMONTH", SqlDbType.Int);
                paraSt_AddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(extrInfo_AccRecBalanceWork.St_AddUpYearMonth);
            }
            if (extrInfo_AccRecBalanceWork.Ed_AddUpYearMonth != DateTime.MinValue)
            {
                retString.Append("AND CUSACC.ADDUPYEARMONTHRF<=@ED_ADDUPYEARMONTH ");
                SqlParameter paraEd_AddUpYearMonth = sqlCommand.Parameters.Add("@ED_ADDUPYEARMONTH", SqlDbType.Int);
                paraEd_AddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(extrInfo_AccRecBalanceWork.Ed_AddUpYearMonth);
            }


            return retString.ToString();
        }
        #endregion

        #region [���|�c���������o���ʃN���X�i�[����]
        /// <summary>
        /// ���|�c���������o���ʃN���X�i�[���� Reader �� RsltInfo_AccRecBalanceWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RsltInfo_AccRecBalanceWork</returns>
        /// <remarks>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.09</br>
        /// </remarks>
        private RsltInfo_AccRecBalanceWork CopyToRsltInfo_AccRecBalanceFromReader(ref SqlDataReader myReader)
        {
            RsltInfo_AccRecBalanceWork wkRsltInfo_AccRecBalanceWork = new RsltInfo_AccRecBalanceWork();

            #region �N���X�֊i�[
            wkRsltInfo_AccRecBalanceWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkRsltInfo_AccRecBalanceWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
            wkRsltInfo_AccRecBalanceWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            wkRsltInfo_AccRecBalanceWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
            wkRsltInfo_AccRecBalanceWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
            wkRsltInfo_AccRecBalanceWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            wkRsltInfo_AccRecBalanceWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            wkRsltInfo_AccRecBalanceWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
            wkRsltInfo_AccRecBalanceWork.LastTimeAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEACCRECRF"));
            wkRsltInfo_AccRecBalanceWork.AcpOdrTtl2TmBfAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL2TMBFACCRECRF"));
            wkRsltInfo_AccRecBalanceWork.AcpOdrTtl3TmBfAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL3TMBFACCRECRF"));
            wkRsltInfo_AccRecBalanceWork.ThisTimeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDMDNRMLRF"));
            wkRsltInfo_AccRecBalanceWork.ThisTimeFeeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEFEEDMDNRMLRF"));
            wkRsltInfo_AccRecBalanceWork.ThisTimeDisDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDISDMDNRMLRF"));
            wkRsltInfo_AccRecBalanceWork.ThisTimeTtlBlcAcc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLCACCRF"));
            wkRsltInfo_AccRecBalanceWork.OfsThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESALESRF"));
            wkRsltInfo_AccRecBalanceWork.OfsThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSALESTAXRF"));
            wkRsltInfo_AccRecBalanceWork.ThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESALESRF"));
            wkRsltInfo_AccRecBalanceWork.ThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESTAXRF"));
            wkRsltInfo_AccRecBalanceWork.ThisSalesPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICRGDSRF"));
            wkRsltInfo_AccRecBalanceWork.ThisSalesPrcTaxRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRCTAXRGDSRF"));
            wkRsltInfo_AccRecBalanceWork.ThisSalesPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICDISRF"));
            wkRsltInfo_AccRecBalanceWork.ThisSalesPrcTaxDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRCTAXDISRF"));
            wkRsltInfo_AccRecBalanceWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));
            wkRsltInfo_AccRecBalanceWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));
            wkRsltInfo_AccRecBalanceWork.AfCalTMonthAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("AFCALTMONTHACCRECRF"));
            wkRsltInfo_AccRecBalanceWork.SalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCOUNTRF"));
            wkRsltInfo_AccRecBalanceWork.CollectCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTCONDRF"));
            wkRsltInfo_AccRecBalanceWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
            wkRsltInfo_AccRecBalanceWork.CollectMoneyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLLECTMONEYNAMERF"));
            wkRsltInfo_AccRecBalanceWork.CollectMoneyDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"));
            wkRsltInfo_AccRecBalanceWork.BillCollecterCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERCDRF"));
            wkRsltInfo_AccRecBalanceWork.BillCollecterNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERNMRF"));
            #endregion

            return wkRsltInfo_AccRecBalanceWork;
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
