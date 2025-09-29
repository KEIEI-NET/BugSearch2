using System;
using System.Collections;
using System.Collections.Generic;
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
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ����N�Ԏ���DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����N�Ԏ��т̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���쏹��</br>
    /// <br>Date       : 2007.11.26</br>
    /// <br></br>
    /// <br>Update Note: 2009/04/30 22008 ����</br>
    /// <br>             �����f�[�^�_���폜�Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2009/05/26 23012 ���� �[���N</br>
    /// <br>             �s��C�� (MANTIS ID:13331 )</br>
    /// <br></br>
    /// <br>Update Note: 2009/09/07 22008 ���� ���n</br>
    /// <br>             �s��C�� (MANTIS ID:14011 )</br>
    /// <br>Update Note: 2010/08/02 ����p</br>
    /// <br>               �e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note: 2010/08/25 chenyd</br>
    /// <br>            �E��QID:13278 �e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note: ���N�n��</br>
    /// <br>Date       : 2011/03/22</br>
    /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
    /// <br>Update Note: FSI�����@�v</br>
    /// <br>Date       : 2012/09/24</br>
    /// <br>             �W�v�敪�����Ӑ�̏ꍇ�̑e���\���s���Ή�</br>
    /// <br>Update Note: 2012/10/11 YANGMJ</br>
    /// <br>             REDMINE#32818 �l�����̏W�v���@�Ή�</br>
    /// <br>Update Note: 2015/09/08 �����</br>
    /// <br>             Redmine#47027 �u�c���Ɖ�v�^�u�ɐ�����̓`�[�����s���̑Ή�</br>
    /// </remarks>
    [Serializable]
    public class SalesAnnualDataSelectResultDB : RemoteDB, ISalesAnnualDataSelectResultDB
    {
        /// <summary>
        /// ����N�Ԏ���DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public SalesAnnualDataSelectResultDB()
            :
            base("DCHNB04196D", "Broadleaf.Application.Remoting.ParamData.SalesAnnualDataSelectResultWork", "SALESANNUALDATASELECTRESULTRF")
        {
        }

        IMTtlSaSlip mTtlSaSlip;
        /// <summary>���|/���|���z�}�X�^�X�V�����[�g�I�u�W�F�N�g</summary>
        private MonthlyAddUpDB _monthlyAddUpDB;


        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̔���N�Ԏ��уf�[�^��߂��܂��i�o�͗p�j
        /// </summary>
        /// <param name="retListObj">��������</param>
        /// <param name="paraList">�����p�����[�^���X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔���N�Ԏ��уf�[�^��߂��܂��i�o�͗p�j</br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/08/02</br>
        /// <br>Update Note: 2010/08/25 chenyd</br>
        /// <br>            �E��QID:13278 �e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note: ���N�n��</br>
        /// <br>Date       : 2011/03/22</br>
        /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
        //public int SearchAll(out object retListObj, object paraList) // DEL 2010/08/30
        public int SearchAll(out object retListObj, object paramWork)  // ADD 2010/08/30
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            retListObj = null;
            object retObj = null;

            ArrayList resultWorkList = new ArrayList();
            //ArrayList paraCndtnWorkList = paraList as ArrayList;
            ArrayList salesAnnualDataSelectResultWorkList = new ArrayList();
            try
            {
                SalesAnnualDataSelectParamWork _paramWork = paramWork as SalesAnnualDataSelectParamWork;
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // --- ADD 2011/03/22----------------------------------->>>>>
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _paramWork.EnterpriseCode, "����N�Ԏ��яƉ�", "���o�J�n");
                // --- ADD 2011/03/22-----------------------------------<<<<<
                // --- DEL 2010/08/25 -------------------------------->>>>>
                //foreach (SalesAnnualDataSelectParamWork paramWork in paraCndtnWorkList)
                //{
                //    status = SearchSalesAnnualData(out retObj, paramWork, ref sqlConnection); 
                //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //    {
                //        salesAnnualDataSelectResultWorkList = (ArrayList)retObj;
                //        foreach (SalesAnnualDataSelectResultWork resultWork in salesAnnualDataSelectResultWorkList)
                //        {
                //            resultWork.SectionCode = paramWork.SectionCode;
                //            resultWork.SectionName = paramWork.SectionName;
                //            resultWork.SelectionCode = paramWork.SelectionCode;
                //            resultWork.SelectionName = paramWork.SelectionName;
                //        }
                //        resultWorkList.Add(salesAnnualDataSelectResultWorkList);
                //    }
                //}
                // --- DEL 2010/08/25 --------------------------------<<<<<

                // --- ADD 2010/08/25 -------------------------------->>>>>
                List<string[]> sectionCodeList = _paramWork.SectionCodeList;
                string st_selectionCode = _paramWork.St_SelectionCode;
                string ed_selectionCode = _paramWork.Ed_SelectionCode;
                int employeeDivCd = _paramWork.EmployeeDivCd;
                foreach (string[] sectionCode in sectionCodeList)
                {
                    _paramWork.SectionCode = sectionCode[0];
                    _paramWork.St_SelectionCode = st_selectionCode;
                    _paramWork.Ed_SelectionCode = ed_selectionCode;
                    _paramWork.EmployeeDivCd = employeeDivCd;
                    status = SearchSalesAnnualData(out retObj, paramWork, ref sqlConnection);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        salesAnnualDataSelectResultWorkList = (ArrayList)retObj;
                        foreach (SalesAnnualDataSelectResultWork resultWork in salesAnnualDataSelectResultWorkList)
                        {
                            resultWork.SectionCode = sectionCode[0];
                            resultWork.SectionName = sectionCode[1];
                        }
                        resultWorkList.Add(salesAnnualDataSelectResultWorkList);
                    }
                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                if (resultWorkList.Count >= 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                retListObj = (object)resultWorkList;
                // --- ADD 2011/03/22----------------------------------->>>>>
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _paramWork.EnterpriseCode, "����N�Ԏ��яƉ�", "���o�I��");
                // --- ADD 2011/03/22-----------------------------------<<<<<
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesAnnualDataSelectResultDB.Search");
                resultWorkList = new ArrayList();
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

        /// <summary>
        /// �w�肳�ꂽ�����̔���N�Ԏ��уf�[�^��߂��܂�
        /// </summary>
        /// <param name="salesAnnualDataSelectResultWorkk">��������</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔���N�Ԏ��уf�[�^��߂��܂�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br>Update Note: ���N�n��</br>
        /// <br>Date       : 2011/03/22</br>
        /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
        public int Search(out object salesAnnualDataSelectResultWork, object paramWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            salesAnnualDataSelectResultWork = null;
            OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB(); // ADD 2011/03/22
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, ((SalesAnnualDataSelectParamWork)paramWork).EnterpriseCode, "����N�Ԏ��яƉ�", "���o�J�n");// ADD 2011/03/22
                return SearchSalesAnnualData(out salesAnnualDataSelectResultWork, paramWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesAnnualDataSelectResultDB.Search");
                salesAnnualDataSelectResultWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, ((SalesAnnualDataSelectParamWork)paramWork).EnterpriseCode, "����N�Ԏ��яƉ�", "���o�I��"); // ADD 2011/03/22
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// �w�肳�ꂽ�����̔���N�Ԏ��уf�[�^��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objSalesAnnualDataSelectResultWork">��������</param>
        /// <param name="objSalesAnnualDataSelectParamWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔���N�Ԏ��уf�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        private int SearchSalesAnnualData(out object objSalesAnnualDataSelectResultWork, object objSalesAnnualDataSelectParamWork, ref SqlConnection sqlConnection)
        {
            SalesAnnualDataSelectParamWork paramWork = null;

            ArrayList paramWorkList = objSalesAnnualDataSelectParamWork as ArrayList;

            if (paramWorkList == null)
            {
                paramWork = objSalesAnnualDataSelectParamWork as SalesAnnualDataSelectParamWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as SalesAnnualDataSelectParamWork;
            }

            ArrayList salesReportWorkList = null;

            switch (paramWork.TotalDiv)
            {
                // �C�� 2008/09/22 >>>
                #region �C���O
                /*
                case (int)TotalDivs.Section:                //���_��
                case (int)TotalDivs.SalesEmp:               //�S���ҕ�
                    mTtlSaSlip = new MTtlSaSlipEmp();
                    break;
                case (int)TotalDivs.Customer:               //���Ӑ��
                case (int)TotalDivs.Area:                   //�n���
                case (int)TotalDivs.BizType:                //�Ǝ��
                    mTtlSaSlip = new MTtlSaSlipCust();
                    break;
                default:
                    break;
                */
                #endregion
                case (int)TotalDivs.Section:                //���_��
                case (int)TotalDivs.SalesEmp:               //�S���ҕ�
                    mTtlSaSlip = new MTtlSaSlipEmp();
                    break;   

                case (int)TotalDivs.Customer:               //���Ӑ��
                    mTtlSaSlip = new MTtlSaSlipCust();
                    break;

                case (int)TotalDivs.Area:                   //�n���
                case (int)TotalDivs.BizType :               //�Ǝ��
                    mTtlSaSlip = new MTtlSaSlipAreaBizType();
                    break;
                default:
                    break;
                // �C�� 2008/09/22 <<<
            }
            
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // ����N�Ԏ��уf�[�^���捞��
            status = SearchSalesHistoryDataProc(out salesReportWorkList, paramWork, ref sqlConnection);
            objSalesAnnualDataSelectResultWork = salesReportWorkList;
            return status;

        }
        #endregion  //Search

        #region [SearchSalesHistoryDataProc]
        /// <summary>
        /// �w�肳�ꂽ�����̔���N�Ԏ��уf�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="salesAnnualDataSelectResultWorkList">��������</param>
        /// <param name="salesAnnualDataSelectParamWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔���N�Ԏ��уf�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        private int SearchSalesHistoryDataProc(out ArrayList salesHistoryWorkList, SalesAnnualDataSelectParamWork paramWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                
                sqlCommand = new SqlCommand("", sqlConnection);

                //�ڕW���z�擾
                sqlCommand.CommandText = mTtlSaSlip.MakeSelectString(ref sqlCommand, paramWork,0);

                //�^�C���A�E�g���Ԃ�ݒ�i�b�j
                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(mTtlSaSlip.CopyToResultWorkFromReader(ref myReader, paramWork));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                // ADD 2008/09/22 >>>
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();

                switch (paramWork.TotalDiv)
                {

                    case (int)TotalDivs.Section: // ���_��
                        // ���㗚���f�[�^�Ǎ�
                        status = SearchSalesHistDtl(ref al, paramWork, ref sqlConnection);
                        break;

                    case (int)TotalDivs.Customer: //���Ӑ��
                        if (paramWork.SearchDiv == 0)
                        {
                            status = SearchSalesHistDtl(ref al, paramWork, ref sqlConnection);
                        }
                        break;
                    default:
                        break;
                }
                // ADD 2008/09/22 <<<

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

            salesHistoryWorkList = al;

            return status;
        }
        #endregion  //SearchSalesHistoryDataProc

        // ADD 2008/09/22 >>>>
        #region [CustSearch ���Ӑ�c���Ɖ�pSearch����]
        // ADD 2008/09/22 >>>
        /// <summary>
        /// �w�肳�ꂽ�����̎c���Ɖ�f�[�^��߂��܂�
        /// </summary>
        /// <param name="custsalesAnnualDataSelectResultWorkk">��������</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎c���Ɖ�f�[�^��߂��܂�</br>
        /// <br>Programmer : ���� �[���N</br>
        /// <br>Date       : 2008.09.22</br>
        public int CustSearch(out object custsalesAnnualDataSelectResultWork, object paramWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            custsalesAnnualDataSelectResultWork = null;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                status =SearchCustSalesData(out custsalesAnnualDataSelectResultWork, paramWork, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchCustSalesData.CustSearch");
                custsalesAnnualDataSelectResultWork = new ArrayList();
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

        #region [SearchCustSalesData ���Ӑ�c���Ɖ�pSearch����]
        // ADD 2008/09/22 >>>
        /// <summary>
        /// �w�肳�ꂽ�����̎c���Ɖ�f�[�^��߂��܂�
        /// </summary>
        /// <param name="custsalesAnnualDataSelectResultWorkk">��������</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎c���Ɖ�f�[�^��߂��܂�</br>
        /// <br>Programmer : ���� �[���N</br>
        /// <br>Date       : 2008.09.22</br>
        private int SearchCustSalesData(out object objCustsalesHistoryWorkList, object objSalesAnnualDataSelectParamWork, ref SqlConnection sqlConnection)
        {
            SalesAnnualDataSelectParamWork paramWork = null;

            ArrayList paramWorkList = objSalesAnnualDataSelectParamWork as ArrayList;

            if (paramWorkList == null)
            {
                paramWork = objSalesAnnualDataSelectParamWork as SalesAnnualDataSelectParamWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as SalesAnnualDataSelectParamWork;
            }

            ArrayList salesReportWorkList = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            // �c���Ɖ�f�[�^���捞��
            status = SearchCustSalesDataProc(out salesReportWorkList, paramWork, ref sqlConnection);
            objCustsalesHistoryWorkList = salesReportWorkList;

            return status;
        }
        #endregion

        #region [SearchCustSalesDataProc ���Ӑ�c���Ɖ�pSearch����]
        // ADD 2008/09/22 >>>
        /// <summary>
        /// �w�肳�ꂽ�����̎c���Ɖ�f�[�^��߂��܂�
        /// </summary>
        /// <param name="custsalesAnnualDataSelectResultWorkk">��������</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎c���Ɖ�f�[�^��߂��܂�</br>
        /// <br>Programmer : ���� �[���N</br>
        /// 
        /// <br>Date       : 2008.09.22</br>
        private int SearchCustSalesDataProc(out ArrayList CustsalesHistoryWorkList, SalesAnnualDataSelectParamWork paramWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {                
                if (paramWork.SearchDiv == 1)�@// 0:�N�x����,1:�c��(�����E����),2:�c��(������������)
                {
                    #region �c��(�����E����)�擾����
                    status = SearchCustSalesDataProc(ref al, paramWork, ref sqlConnection, 1);// �����E�����f�[�^�擾
                    status = SearchCustSalesDataProc(ref al, paramWork, ref sqlConnection, 2);// ���|�f�[�^�擾
                    status = SearchCustSalesDataProc(ref al, paramWork, ref sqlConnection, 3);// ���������f�[�^�擾
                                       
                    //���|���E���|���W�v���W���[���ďo
                    this._monthlyAddUpDB = new MonthlyAddUpDB();

                    CustAccRecWork custAccRecWork = new CustAccRecWork();
                    custAccRecWork.EnterpriseCode = paramWork.EnterpriseCode;                         //��ƃR�[�h
                    custAccRecWork.AddUpSecCode = paramWork.ClaimSectionCode;                         //���Ӑ搿�����_
                    custAccRecWork.AddUpDate = TDateTime.LongDateToDateTime(paramWork.SecTotalDay);   //�v��N����
                    custAccRecWork.CustomerCode = paramWork.CustomerCode;                             //���Ӑ�R�[�h   
                    object paraObj2 = (object)custAccRecWork;
                    string retMsg = null;
                    //���|���E���|���W�v���W���[���ďo
                    status = _monthlyAddUpDB.ReadCustAccRec(ref paraObj2, out retMsg);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {                                            
                        //�擾����
                        //�擾���ʃL���X�g
                        ArrayList custAccRecResult = new ArrayList();
                        custAccRecResult.Add((CustAccRecWork)paraObj2);
                        #region [���o����-�l�Z�b�g]
                        //�����
                        ((CustSalesAnnualDataSelectResultWork)al[0]).ThisMOfsThisSalesTax = ((CustAccRecWork)custAccRecResult[0]).OfsThisSalesTax;
                        //�萔��
                        ((CustSalesAnnualDataSelectResultWork)al[0]).ThisMThisTimeFeeDmdNrml = ((CustAccRecWork)custAccRecResult[0]).ThisTimeFeeDmdNrml;
                        //�l��
                        ((CustSalesAnnualDataSelectResultWork)al[0]).ThisMThisTimeDisDmdNrml = ((CustAccRecWork)custAccRecResult[0]).ThisTimeDisDmdNrml;
                        #endregion
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    }
                    else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                             (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                    {
                        //NOT_FOUND,EOF�̏ꍇ�͎���
                    }
                    else
                    {
                        //�擾���s
                        throw new Exception("���|���E���|���W�v���W���[������̎擾�Ɏ��s�B");
                    }
                    #endregion
                }
                if (paramWork.SearchDiv == 2)�@// 0:�N�x����,1:�c��(�����E����),2:�c��(������������)
                {
                    status = SearchSalesHistDtlProc(ref al, paramWork, ref sqlConnection);
                   

                    //Del 2008.12.18 sakurai>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //
                    //#region �c��(������������)�擾����
                    //
                    //CompanyInfWork paraCompanyInfWork = new CompanyInfWork();
                    //status = SearchSalesHistDtlProc(ref al, paraCompanyInfWork, TDateTime.DateTimeToLongDate(paramWork.AddUpYearMonth), 0, 0, paramWork, ref sqlConnection, 1);
                    //
                    //#endregion
                    //
                    //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    
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
            CustsalesHistoryWorkList = al;

            return status;
        }
        #endregion

        #region [SearchCustDepoTotalProc]
        /// <summary>
        /// �w�肳�ꂽ�����̐����f�[�^�����f�[�^��߂��܂�
        /// </summary>
        /// <param name="custsalesAnnualDataSelectResultWorkk">��������</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̐����f�[�^�����f�[�^��߂��܂�</br>
        /// <br>Programmer : ���� �[���N</br>
        /// <br>Date       : 2008.09.22</br>
        private int SearchCustSalesDataProc(ref ArrayList WorkList, SalesAnnualDataSelectParamWork paramWork, ref SqlConnection sqlConnection, int SubSlip)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                IMTtlSaSlip mTtlSaSlipCust = new MTtlSaSlipCust();
                String sText = "";
                sqlCommand = new SqlCommand(sText, sqlConnection);

                if (SubSlip == 1) // �����E�����f�[�^�擾
                {
                    #region [SELECT��]
                    sText += "SELECT" + Environment.NewLine;
                    sText += " CUSTDMD.LASTTIMEDEMANDRF AS LASTTIMEDEMANDRF," + Environment.NewLine;
                    sText += " CUSTDMD.THISTIMEFEEDMDNRMLRF AS THISTIMEFEEDMDNRMLRF," + Environment.NewLine;
                    sText += " CUSTDMD.THISTIMEDISDMDNRMLRF AS THISTIMEDISDMDNRMLRF," + Environment.NewLine;
                    sText += " CUSTDMD.OFSTHISSALESTAXRF AS OFSTHISSALESTAXRF," + Environment.NewLine;
                    sText += " CUSTDMD.ACPODRTTL2TMBFBLDMDRF AS ACPODRTTL2TMBFBLDMDRF," + Environment.NewLine;
                    sText += " CUSTDMD.ACPODRTTL3TMBFBLDMDRF AS ACPODRTTL3TMBFBLDMDRF," + Environment.NewLine;
                    sText += " CUSTDMD.SALESSLIPCOUNTRF AS SALESSLIPCOUNTRF," + Environment.NewLine;
                    sText += " CUSTDMD.ADDUPYEARMONTHRF  AS ADDUPYEARMONTHRF," + Environment.NewLine;
                    sText += " CUSTDMD.ADDUPDATERF AS ADDDAY," + Environment.NewLine;
                    sText += " DMDEPO.CASHDEPOSIT AS CASHDEPOSIT," + Environment.NewLine;
                    sText += " DMDEPO.TRFRDEPOSIT As TRFRDEPOSIT," + Environment.NewLine;
                    sText += " DMDEPO.CHECKDEPOSIT AS CHECKDEPOSIT," + Environment.NewLine;
                    sText += " DMDEPO.DRAFTDEPOSIT AS DRAFTDEPOSIT," + Environment.NewLine;
                    sText += " DMDEPO.OFFSETDEPOSIT AS OFFSETDEPOSIT," + Environment.NewLine;
                    sText += " DMDEPO.FUNDTRANSFERDEPOSIT AS FUNDTRANSFERDEPOSIT," + Environment.NewLine;
                    sText += " DMDEPO.EMONEYRDEPOSIT AS EMONEYRDEPOSIT," + Environment.NewLine;
                    sText += " DMDEPO.OTHERDEPOSIT AS OTHERDEPOSIT" + Environment.NewLine;
                    sText += " FROM" + Environment.NewLine;
                    sText += " (" + Environment.NewLine;
                    sText += "  SELECT" + Environment.NewLine;
                    sText += "   ENTERPRISECODERF AS ENTERPRISECODERF," + Environment.NewLine;
                    sText += "   ADDUPSECCODERF AS ADDUPSECCODERF," + Environment.NewLine;
                    sText += "   CLAIMCODERF AS CLAIMCODERF," + Environment.NewLine;
                    sText += "   ADDUPDATERF AS ADDUPDATERF," + Environment.NewLine;
                    sText += "   ADDUPYEARMONTHRF  AS ADDUPYEARMONTHRF," + Environment.NewLine;
                    sText += "   LASTTIMEDEMANDRF AS LASTTIMEDEMANDRF," + Environment.NewLine;
                    sText += "   SALESSLIPCOUNTRF AS SALESSLIPCOUNTRF," + Environment.NewLine;
                    sText += "   THISTIMEFEEDMDNRMLRF AS THISTIMEFEEDMDNRMLRF," + Environment.NewLine;
                    sText += "   THISTIMEDISDMDNRMLRF AS THISTIMEDISDMDNRMLRF, " + Environment.NewLine;
                    sText += "   OFSTHISSALESTAXRF AS OFSTHISSALESTAXRF," + Environment.NewLine;
                    sText += "   ACPODRTTL2TMBFBLDMDRF AS ACPODRTTL2TMBFBLDMDRF," + Environment.NewLine;
                    sText += "   ACPODRTTL3TMBFBLDMDRF AS ACPODRTTL3TMBFBLDMDRF" + Environment.NewLine;
                    sText += "  FROM " + Environment.NewLine;
                    sText += "   CUSTDMDPRCRF AS CUSTDMDPRC" + Environment.NewLine;
                    sText += mTtlSaSlipCust.MakeWhereString(ref sqlCommand, paramWork, "CUSTDMDPRC", SlipTargetDiv.TargetDay, SubSlip);
                    sText += "   AND CUSTDMDPRC.CUSTOMERCODERF=0" + Environment.NewLine;
                    sText += " ) AS CUSTDMD" + Environment.NewLine;
                    sText += " LEFT JOIN" + Environment.NewLine;
                    sText += " (" + Environment.NewLine;
                    sText += "   SELECT" + Environment.NewLine;
                    sText += "    DEPDTL.ENTERPRISECODERF AS ENTERPRISECODERF," + Environment.NewLine;
                    sText += "    DEPDTL.ADDUPSECCODERF AS ADDUPSECCODERF," + Environment.NewLine;
                    sText += "    DEPDTL.CUSTOMERCODERF AS CUSTOMERCODERF," + Environment.NewLine;
                    sText += "    DEPDTL.CLAIMCODERF AS CLAIMCODERF," + Environment.NewLine;
                    sText += "    DEPDTL.ADDUPDATERF AS ADDUPDATERF," + Environment.NewLine;
                    sText += "    SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=51 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS CASHDEPOSIT," + Environment.NewLine;
                    sText += "    SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=52 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS TRFRDEPOSIT," + Environment.NewLine;
                    sText += "    SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=53 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS CHECKDEPOSIT," + Environment.NewLine;
                    sText += "    SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=54 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS DRAFTDEPOSIT," + Environment.NewLine;
                    sText += "    SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=56 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS OFFSETDEPOSIT," + Environment.NewLine;
                    sText += "    SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=59 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS FUNDTRANSFERDEPOSIT," + Environment.NewLine;
                    sText += "    SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=60 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS EMONEYRDEPOSIT," + Environment.NewLine;
                    sText += "    SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=58 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS OTHERDEPOSIT" + Environment.NewLine;
                    sText += "   FROM DMDDEPOTOTALRF AS DEPDTL" + Environment.NewLine;
                    sText += mTtlSaSlipCust.MakeWhereString(ref sqlCommand, paramWork, "DEPDTL", SlipTargetDiv.TargetDay, SubSlip);
                    sText += "   GROUP BY" + Environment.NewLine;
                    sText += "    ENTERPRISECODERF," + Environment.NewLine;
                    sText += "    ADDUPSECCODERF," + Environment.NewLine;
                    sText += "    CLAIMCODERF," + Environment.NewLine;
                    sText += "    CUSTOMERCODERF," + Environment.NewLine;
                    sText += "    ADDUPDATERF" + Environment.NewLine;
                    sText += "   ) AS DMDEPO" + Environment.NewLine;
                    sText += " ON" + Environment.NewLine;
                    sText += " CUSTDMD.ENTERPRISECODERF = DMDEPO.ENTERPRISECODERF" + Environment.NewLine;
                    sText += " AND CUSTDMD.ADDUPSECCODERF = DMDEPO.ADDUPSECCODERF" + Environment.NewLine;
                    sText += " AND CUSTDMD.CLAIMCODERF = DMDEPO.CLAIMCODERF" + Environment.NewLine;
                    sText += " AND CUSTDMD.ADDUPDATERF = DMDEPO.ADDUPDATERF" + Environment.NewLine;
                    #endregion

                }
                if (SubSlip == 2) // ���|�f�[�^�擾
                {
                    #region [SELECT��]
                    sText = "SELECT" + Environment.NewLine;
                    sText +=  "ADDUPDATERF AS ADDUPDATERF," + Environment.NewLine;
                    sText +=  "AFCALTMONTHACCRECRF AS LASTTIMEACCRECRF" + Environment.NewLine;
                    sText +=  "FROM" + Environment.NewLine;
                    sText +=  "CUSTACCRECRF" + Environment.NewLine;
                    sText += mTtlSaSlipCust.MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.TargetDay, SubSlip);
                    sText +=  " AND CUSTOMERCODERF =0" + Environment.NewLine;
                    #endregion
                }
                if (SubSlip == 3) // ���������f�[�^�擾
                {
                    #region [SELECT��]
                    sText = "SELECT" + Environment.NewLine;
                    sText += "DEPMIN.ENTERPRISECODERF" + Environment.NewLine;
                    sText += "  ,DEPMIN.ADDUPSECCODERF" + Environment.NewLine;
                    sText += "  ,DEPMIN.CLAIMCODERF" + Environment.NewLine;
                    sText += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=51 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS CASHDEPOSIT" + Environment.NewLine;
                    sText += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=52 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS TRFRDEPOSIT" + Environment.NewLine;
                    sText += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=53 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS CHECKDEPOSIT" + Environment.NewLine;
                    sText += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=54 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS DRAFTDEPOSIT" + Environment.NewLine;
                    sText += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=56 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS OFFSETDEPOSIT" + Environment.NewLine;
                    sText += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=59 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS FUNDTRANSFERDEPOSIT" + Environment.NewLine;
                    sText += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=60 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS EMONEYRDEPOSIT" + Environment.NewLine;
                    sText += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=58 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS OTHERDEPOSIT" + Environment.NewLine;
                    sText += " FROM DEPSITMAINRF AS DEPMIN" + Environment.NewLine;
                    sText += " INNER JOIN DEPSITDTLRF DEPDTL" + Environment.NewLine;
                    sText += " ON  DEPDTL.ENTERPRISECODERF=DEPMIN.ENTERPRISECODERF" + Environment.NewLine;
                    sText += " AND DEPDTL.ACPTANODRSTATUSRF=DEPMIN.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sText += " AND DEPDTL.DEPOSITSLIPNORF=DEPMIN.DEPOSITSLIPNORF" + Environment.NewLine;
                    sText += " AND DEPDTL.LOGICALDELETECODERF=0" + Environment.NewLine;
                    sText += mTtlSaSlipCust.MakeWhereString(ref sqlCommand, paramWork, "DEPMIN", SlipTargetDiv.TargetDay, SubSlip);
                    sText += " GROUP BY" + Environment.NewLine;
                    sText += "   DEPMIN.ENTERPRISECODERF" + Environment.NewLine;
                    sText += "  ,DEPMIN.ADDUPSECCODERF" + Environment.NewLine;
                    sText += "  ,DEPMIN.CLAIMCODERF" + Environment.NewLine;
                    #endregion
                }
                sqlCommand.CommandText = sText;

                //�^�C���A�E�g���Ԃ�ݒ�i�b�j
                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    if (SubSlip == 1) // �����E�����f�[�^�擾
                    {
                        #region ���ʃZ�b�g
                        CustSalesAnnualDataSelectResultWork CustSalesDataResultWork = new CustSalesAnnualDataSelectResultWork();
                        CustSalesDataResultWork.AUPYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
                        CustSalesDataResultWork.LastTimeDemand = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEDEMANDRF"));            //�O�񐿋����z
                        CustSalesDataResultWork.AcpOdrTtl2TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL2TMBFBLDMDRF"));  //��2��O�c���i�����v�j
                        CustSalesDataResultWork.AcpOdrTtl3TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL3TMBFBLDMDRF"));  //��3��O�c���i�����v�j
                        CustSalesDataResultWork.SalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCOUNTRF"));            //����`�[����
                        CustSalesDataResultWork.CasheDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CASHDEPOSIT"));                   //�����������(����)
                        CustSalesDataResultWork.TrfrDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TRFRDEPOSIT"));                    //�����������(�U��)
                        CustSalesDataResultWork.CheckKDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CHECKDEPOSIT"));                 //�����������(���؎�)
                        CustSalesDataResultWork.DraftDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DRAFTDEPOSIT"));                  //�����������(��`)
                        CustSalesDataResultWork.OffsetDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETDEPOSIT"));                //�����������(���E)
                        CustSalesDataResultWork.FundtransferDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FUNDTRANSFERDEPOSIT"));    //�����������(�����U��)
                        CustSalesDataResultWork.EmoneyDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("EMONEYRDEPOSIT"));               //�����������(E-Money)
                        CustSalesDataResultWork.OtherDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OTHERDEPOSIT"));                  //�����������(���̑�)
                        CustSalesDataResultWork.ThisTimeFeeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEFEEDMDNRMLRF"));      //�����������(�萔��)
                        CustSalesDataResultWork.ThisTimeDisDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDISDMDNRMLRF"));      //�����������(�l��)
                        CustSalesDataResultWork.OfsThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSALESTAXRF"));            //���������
                        #endregion
                        WorkList.Add(CustSalesDataResultWork);
                    }
                    if (SubSlip == 2) // ���|�f�[�^�擾
                    {
                        #region ���ʃZ�b�g
                        if (WorkList.Count == 0)
                        {
                            CustSalesAnnualDataSelectResultWork CustSalesDataResultWork = new CustSalesAnnualDataSelectResultWork();
                            CustSalesDataResultWork.LastTimeAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEACCRECRF")); //�O�񔄊|���z
                            WorkList.Add(CustSalesDataResultWork);
                        }
                        else
                        {
                            ((CustSalesAnnualDataSelectResultWork)WorkList[0]).LastTimeAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEACCRECRF")); //�O�񔄊|���z

                        }
                        #endregion
                    }
                    if (SubSlip == 3) // ���������f�[�^�擾
                    {
                        #region ���ʃZ�b�g
                        if (WorkList.Count == 0)
                        {
                            CustSalesAnnualDataSelectResultWork CustSalesDataResultWork = new CustSalesAnnualDataSelectResultWork();
                            CustSalesDataResultWork.ThisMCasheDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CASHDEPOSIT"));
                            CustSalesDataResultWork.ThisMhTrfrDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TRFRDEPOSIT"));
                            CustSalesDataResultWork.ThisMCheckKDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CHECKDEPOSIT"));
                            CustSalesDataResultWork.ThisMDraftDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DRAFTDEPOSIT"));
                            CustSalesDataResultWork.ThisMOffsetDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETDEPOSIT"));
                            CustSalesDataResultWork.ThisMFundtransferDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FUNDTRANSFERDEPOSIT"));                                                                                                                                    
                            CustSalesDataResultWork.ThisMEmoneyDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("EMONEYRDEPOSIT"));
                            CustSalesDataResultWork.ThisMOtherDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OTHERDEPOSIT"));
                            WorkList.Add(CustSalesDataResultWork);
                        }
                        else
                        {
                            ((CustSalesAnnualDataSelectResultWork)WorkList[0]).ThisMCasheDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CASHDEPOSIT"));
                            ((CustSalesAnnualDataSelectResultWork)WorkList[0]).ThisMhTrfrDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TRFRDEPOSIT"));
                            ((CustSalesAnnualDataSelectResultWork)WorkList[0]).ThisMCheckKDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CHECKDEPOSIT"));
                            ((CustSalesAnnualDataSelectResultWork)WorkList[0]).ThisMDraftDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DRAFTDEPOSIT"));
                            ((CustSalesAnnualDataSelectResultWork)WorkList[0]).ThisMOffsetDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETDEPOSIT"));
                            ((CustSalesAnnualDataSelectResultWork)WorkList[0]).ThisMFundtransferDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FUNDTRANSFERDEPOSIT"));
                            ((CustSalesAnnualDataSelectResultWork)WorkList[0]).ThisMEmoneyDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("EMONEYRDEPOSIT"));
                            ((CustSalesAnnualDataSelectResultWork)WorkList[0]).ThisMOtherDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OTHERDEPOSIT"));
                        }
                        #endregion
                    }

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
        // ADD 2008/09/22 <<<

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
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
        #endregion  //�R�l�N�V������������

        // ADD 2008/09/22 >>>
        #region [���㗚���������� SearchSalesHistDtl]
        /// <summary>
        /// ���㗚���f�[�^ ��������
        /// </summary>
        /// <param name="salesHistoryWorkList">��������</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <returns>���㗚���f�[�^ ��������</returns>
        /// <br>Note       : ���㗚���f�[�^���������A�`�[������߂��܂�</br>
        /// <br>Programmer : ���� �[���N</br>
        /// <br>Date       : 2008.09.22</br>
        private int SearchSalesHistDtl(ref ArrayList al, SalesAnnualDataSelectParamWork paramWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SalesAnnualDataSelectResultWork SalesDataResultWork = null;
            int TermSalesSlipCount = 0;
            int AUPYearMonth;
            long SalesTargetM;
            long SalesTargetP;

            // ���Џ��擾
            CompanyInfWork paraCompanyInfWork = new CompanyInfWork();
            paraCompanyInfWork.EnterpriseCode = paramWork.EnterpriseCode;
            CompanyInfDB companyInfDB = new CompanyInfDB();
            ArrayList arrayList;
            companyInfDB.Search(out arrayList, paraCompanyInfWork, ref sqlConnection);
            CompanyInfWork companyInfWork = (CompanyInfWork)arrayList[0];

            ArrayList ResultAl = new ArrayList();
            //ResultAl = null;

            for (int i = 0; i < al.Count; i++)
            {
                SalesDataResultWork = (SalesAnnualDataSelectResultWork)al[i];
                AUPYearMonth = SalesDataResultWork.AUPYearMonth;
                SalesTargetM = SalesDataResultWork.SalesTargetMoney;
                SalesTargetP = SalesDataResultWork.SalesTargetProfit;
                // --- ADD 2010/08/25 -------------------------------->>>>>
                if (paramWork.TotalDiv == 1 && paramWork.SearDiv == 1)
                {
                    paramWork.St_SelectionCode = SalesDataResultWork.SelectionCode;
                    paramWork.Ed_SelectionCode = SalesDataResultWork.SelectionCode;

                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                if (paramWork.TotalDiv == 0) // 0:���_
                {
                    //���ԓ`�[�����擾: TermSalesSlipCount
                    status = SearchSalesHistDtlProc(companyInfWork, AUPYearMonth, ref TermSalesSlipCount, paramWork, ref sqlConnection);
                    ((SalesAnnualDataSelectResultWork)al[i]).TermSalesSlipCount = TermSalesSlipCount;
                }
                if (paramWork.TotalDiv == 1) // 1:���Ӑ�
                {
                    status = SearchSalesHistDtlProc(ref ResultAl, companyInfWork, AUPYearMonth, SalesTargetM, SalesTargetP, paramWork, ref sqlConnection,0,ref al);
                    if (ResultAl.Count != 0)
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;    
                }
            }
            if (paramWork.TotalDiv == 1) // 1:���Ӑ�
            {
                al = null;
                al = ResultAl;
            }
            return status;

        }

        #endregion

        #region [���㗚���������� SearchSalesHistDtlProc]
        /// <summary>
        /// ���㗚���f�[�^ ��������
        /// </summary>
        /// <param name="salesHistoryWorkList">��������</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <returns>���㗚���f�[�^ ��������</returns>
        /// <br>Note       : ���㗚���f�[�^���������A�`�[������߂��܂�</br>
        /// <br>Programmer : ���� �[���N</br>
        /// <br>Date       : 2008.09.22</br>
        private int SearchSalesHistDtlProc(CompanyInfWork companyInfWork, int AUPYearMonth, ref int TermSalesSlipCount, SalesAnnualDataSelectParamWork paramWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            DateTime StADDUPADATE = DateTime.MinValue;
            DateTime EdADDUPADATE = DateTime.MinValue;
            try
            {               
                FinYearTableGenerator finYearTableGenerator = new FinYearTableGenerator(companyInfWork);
                finYearTableGenerator.GetDaysFromMonth(TDateTime.LongDateToDateTime("YYYYMM",AUPYearMonth), out StADDUPADATE, out EdADDUPADATE);

                string sText = "";
                sText = " SELECT COUNT(*) SALESDT_COUNT" + Environment.NewLine;
                sText += " FROM SALESHISTORYRF SALESDT" + Environment.NewLine;
                sText += " WHERE " + Environment.NewLine;
                sText += " ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                sText += " AND LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                // -- UPD 2010/05/10 -------------------------->>>
                //sText += " AND ADDUPADATERF>@STADDUPADATE" + Environment.NewLine;
                //sText += " AND ADDUPADATERF<=@EDADDUPADATE" + Environment.NewLine;
                //if (paramWork.SectionCode != "00")
                //{
                //    sText += " AND SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                //}

                sText += " AND ACPTANODRSTATUSRF=30" + Environment.NewLine;
                sText += " AND SALESDATERF>=" + SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate(StADDUPADATE)).ToString() + Environment.NewLine;
                sText += " AND SALESDATERF<=" + SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate(EdADDUPADATE)).ToString() + Environment.NewLine;
                if (paramWork.SectionCode != "00")
                {
                    //sText += " AND SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                    sText += " AND RESULTSADDUPSECCDRF=@SECTIONCODE" + Environment.NewLine;
                }
                // -- UPD 2010/05/10 --------------------------<<<

                if (paramWork.CustomerCode != 0)
                {
                    sText += " AND CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                }

                sqlCommand = new SqlCommand(sText, sqlConnection);

                //Parameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                // -- DEL 2010/05/10 ------------------------------>>>
                //SqlParameter findParaSTADDUPADATE = sqlCommand.Parameters.Add("@STADDUPADATE", SqlDbType.Int);
                //SqlParameter findParaEDADDUPADATE = sqlCommand.Parameters.Add("@EDADDUPADATE", SqlDbType.Int);
                // -- DEL 2010/05/10 ------------------------------<<<
                SqlParameter findParaLogicalDaleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);                
                
                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);
                // -- DEL 2010/05/10 ------------------------------>>>
                //findParaSTADDUPADATE.Value = SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate(StADDUPADATE));
                //findParaEDADDUPADATE.Value = SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate(EdADDUPADATE));
                // -- DEL 2010/05/10 ------------------------------<<<
                findParaLogicalDaleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                if (paramWork.SectionCode != "00")
                {
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.SectionCode);
                }
                if (paramWork.CustomerCode != 0)
                {
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCode);
                }

                //�^�C���A�E�g���Ԃ�ݒ�i�b�j
                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    TermSalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESDT_COUNT"));
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

        #region [���㗚���������� SearchSalesHistDtlProc]
        /// <summary>
        /// ���㗚���f�[�^ ��������
        /// </summary>
        /// <param name="salesHistoryWorkList">��������</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <returns>���㗚���f�[�^ ��������</returns>
        /// <br>Note       : ���㗚���f�[�^���������A�`�[������߂��܂�</br>
        /// <br>Programmer : ���� �[���N</br>
        /// <br>Date       : 2008.09.22</br>
        private int SearchSalesHistDtlProc(ref ArrayList ResultAl,SalesAnnualDataSelectParamWork paramWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            DateTime StADDUPADATE = DateTime.MinValue;
            DateTime EdADDUPADATE = DateTime.MinValue;

            try
            {
                for (int i = 0; i < 2; i++)
                {
                    if (i == 0)
                    {
                        // �C�� 2009.01.23 >>>
                        //int stYear = paramWork.CustTotalDay / 10000;
                        //int dummyMonth = paramWork.CustTotalDay % 10000;
                        //int stMonth = dummyMonth / 100;
                        //int stDay = dummyMonth % 100;
                        //int stAddDay = stYear * 10000 + (stMonth - 1) * 100 + stDay + 1;
                        //StADDUPADATE = TDateTime.LongDateToDateTime(paramWork.CustTotalDay);
                        //StADDUPADATE = StADDUPADATE.AddMonths(-1);
                        // �C�� 2009.01.23 <<<

                        // -- UPD 2009/09/07 ---------------------->>>
                        //StADDUPADATE = TDateTime.LongDateToDateTime(paramWork.EdAddUpDate);
                        //EdADDUPADATE = TDateTime.LongDateToDateTime(paramWork.CustTotalDay);
                        StADDUPADATE = TDateTime.LongDateToDateTime(paramWork.StAddUpDate);
                        EdADDUPADATE = TDateTime.LongDateToDateTime(paramWork.EdAddUpDate);
                        // -- UPD 2009/09/07 ----------------------<<<
                    }
                    else if (i == 1)
                    {
                        // -- UPD 2009/09/07 ---------------------->>>
                        //StADDUPADATE = TDateTime.LongDateToDateTime(paramWork.StAddUpDate);
                        //EdADDUPADATE = TDateTime.LongDateToDateTime(paramWork.EdAddUpDate);

                        StADDUPADATE = TDateTime.LongDateToDateTime(paramWork.EdSecAddUpDate);
                        EdADDUPADATE = TDateTime.LongDateToDateTime(paramWork.SecTotalDay);
                        // -- UPD 2009/09/07 ----------------------<<<
                    }

                    String sText = "";

                    IMTtlSaSlip mTtlSaSlipCust = new MTtlSaSlipCust();
                    sqlCommand = new SqlCommand("", sqlConnection);

                    sText += "SELECT" + Environment.NewLine;
                    sText += "SUM(CASE WHEN DT.SALESSLIPCDDTLRF = 0 AND DT.GOODSKINDCODERF = 0 THEN DT.SALESMONEYTAXEXCRF ELSE 0 END) AS PSALES," + Environment.NewLine;
                    sText += "SUM(CASE WHEN DT.SALESSLIPCDDTLRF = 1 AND DT.GOODSKINDCODERF = 0 THEN DT.SALESMONEYTAXEXCRF ELSE 0 END) AS PRETURN," + Environment.NewLine;
                    sText += "SUM(CASE WHEN DT.SALESSLIPCDDTLRF = 2 AND DT.GOODSKINDCODERF = 0 THEN DT.SALESMONEYTAXEXCRF ELSE 0 END) AS PDOWN," + Environment.NewLine;
                    sText += "SUM(CASE WHEN DT.GOODSKINDCODERF = 0 THEN DT.SALESMONEYTAXEXCRF - DT.COSTRF ELSE 0 END) AS PGROSS," + Environment.NewLine;
                    sText += "SUM(CASE WHEN DT.SALESSLIPCDDTLRF = 0 AND DT.GOODSKINDCODERF = 1 THEN DT.SALESMONEYTAXEXCRF ELSE 0 END) AS ESALES," + Environment.NewLine;
                    sText += "SUM(CASE WHEN DT.SALESSLIPCDDTLRF = 1 AND DT.GOODSKINDCODERF = 1 THEN DT.SALESMONEYTAXEXCRF ELSE 0 END) AS ERETURN," + Environment.NewLine;
                    sText += "SUM(CASE WHEN DT.SALESSLIPCDDTLRF = 2 AND DT.GOODSKINDCODERF = 1 THEN DT.SALESMONEYTAXEXCRF ELSE 0 END) AS EDOWN," + Environment.NewLine;
                    //sText += "SUM(CASE WHEN DT.GOODSKINDCODERF = 1 THEN DT.SALESMONEYTAXEXCRF - DT.COSTRF ELSE 0 END) AS EGROSS" + Environment.NewLine; // DEL 2009/09/07

                    sText += "SUM(CASE WHEN DT.GOODSKINDCODERF = 1 THEN DT.SALESMONEYTAXEXCRF - DT.COSTRF ELSE 0 END) AS EGROSS," + Environment.NewLine; // DEL 2009/09/07 �Ō����,��ǉ�
                    sText += "SUM(CASE WHEN (HI.SALESSLIPCDRF IN (0,1) AND DT.SALESROWNORF=1) THEN 1 ELSE 0 END) AS SALESSLIPCNT" + Environment.NewLine; // ADD 2009/09/07
                    
                    sText += "FROM SALESHISTDTLRF DT" + Environment.NewLine;
                    sText += "LEFT JOIN SALESHISTORYRF HI" + Environment.NewLine;
                    sText += "ON  HI.ENTERPRISECODERF = DT.ENTERPRISECODERF" + Environment.NewLine;
                    // -- UPD 2009/09/07 ---------------------------------------->>>
                    //sText += "AND HI.SECTIONCODERF = DT.SECTIONCODERF" + Environment.NewLine; 
                    sText += "AND HI.ACPTANODRSTATUSRF = DT.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sText += "AND HI.SALESSLIPNUMRF = DT.SALESSLIPNUMRF" + Environment.NewLine;
                    sText += "AND HI.LOGICALDELETECODERF=@HILOGICALDELETECODE" + Environment.NewLine;// ADD BY ����� 2015/09/08  For Redmine #47027 
                    // -- UPD 2009/09/07 ----------------------------------------<<<
                    sText += "WHERE" + Environment.NewLine;
                    sText += "DT.ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                    sText += "AND DT.SECTIONCODERF =@SECTIONCODE" + Environment.NewLine;
                    sText += "AND HI.CUSTOMERCODERF =@CUSTOMERCODE" + Environment.NewLine;
                    sText += "AND (DT.SALESSLIPCDDTLRF != 3 AND DT.SALESSLIPCDDTLRF !=4 AND DT.SALESSLIPCDDTLRF != 5)" + Environment.NewLine;
                    sText += "AND DT.LOGICALDELETECODERF=@DTLOGICALDELETECODE" + Environment.NewLine;//ADD BY ����� 2015/09/08  For Redmine #47027
                    
                    if (i == 0)
                    {
                        // -- UPD 2009/09/07 ---------------------------------->>>
                        //sText += "AND HI.ADDUPADATERF > @STADDUPADATE" + Environment.NewLine;
                        sText += "AND HI.ADDUPADATERF >= @STADDUPADATE" + Environment.NewLine;
                        // -- UPD 2009/09/07 ----------------------------------<<<
                    }
                    else
                    {
                        // -- UPD 2009/09/07 ---------------------------------->>>
                        //sText += "AND HI.ADDUPADATERF >= @STADDUPADATE" + Environment.NewLine;
                        sText += "AND HI.ADDUPADATERF > @STADDUPADATE" + Environment.NewLine;
                        // -- UPD 2009/09/07 ----------------------------------<<<
                    }

                    sText += "AND HI.ADDUPADATERF <= @EDADDUPADATE" + Environment.NewLine;

                    sqlCommand.CommandText = sText;

                    //Parameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaSTADDUPADATE = sqlCommand.Parameters.Add("@STADDUPADATE", SqlDbType.Int);
                    SqlParameter findParaEDADDUPADATE = sqlCommand.Parameters.Add("@EDADDUPADATE", SqlDbType.Int);
                    SqlParameter findParaEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE",SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCUSTOMERCODERF = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    // --- ADD BY ����� 2015/09/08  For Redmine #47027 ---->>>>>
                    SqlParameter findParaDtLogicalDaleteCode = sqlCommand.Parameters.Add("@DTLOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter findParaHiLogicalDaleteCode = sqlCommand.Parameters.Add("@HILOGICALDELETECODE", SqlDbType.Int);
                    // --- ADD BY ����� 2015/09/08  For Redmine #47027 ----<<<<<

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaSTADDUPADATE.Value = SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate(StADDUPADATE));
                    findParaEDADDUPADATE.Value = SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate(EdADDUPADATE));
                    findParaEnterPriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.SectionCode);
                    findParaCUSTOMERCODERF.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCode);

                    // --- ADD BY ����� 2015/09/08  For Redmine #47027 ---->>>>>
                    findParaDtLogicalDaleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                    findParaHiLogicalDaleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                    // --- ADD BY ����� 2015/09/08  For Redmine #47027 ----<<<<<

                    //�^�C���A�E�g���Ԃ�ݒ�i�b�j
                    sqlCommand.CommandTimeout = 3600;

                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        CustSalesAnnualDataSelectResultWork SalesDataResultWork = new CustSalesAnnualDataSelectResultWork();
                        #region ���ʃZ�b�g
                        SalesDataResultWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PSALES"));
                        SalesDataResultWork.SalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PRETURN"));
                        SalesDataResultWork.DiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PDOWN"));
                        SalesDataResultWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PGROSS"));
                        SalesDataResultWork.ExSalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ESALES"));
                        SalesDataResultWork.ExSalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ERETURN"));
                        SalesDataResultWork.ExDiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("EDOWN"));
                        SalesDataResultWork.ExGrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("EGROSS"));
                        SalesDataResultWork.TermSalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCNT"));
                        SalesDataResultWork.claimDiv = i+1;
                        #endregion

                        ResultAl.Add(SalesDataResultWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
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




        #region [���㗚���������� SearchSalesHistDtlProc]
        /// <summary>
        /// ���㗚���f�[�^ ��������
        /// </summary>
        /// <param name="salesHistoryWorkList">��������</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <returns>���㗚���f�[�^ ��������</returns>
        /// <br>Note       : ���㗚���f�[�^���������A�`�[������߂��܂�</br>
        /// <br>Programmer : ���� �[���N</br>
        /// <br>Date       : 2008.09.22</br>
        /// <br>Update Note: 2010/08/25 chenyd</br>
        /// <br>            �E��QID:13278 �e�L�X�g�o�͑Ή�</br>
        /// <br>           : 2012/09/24 FSI�����@�v</br>
        /// <br>            �@�e���\���s���Ή�</br>
        /// <br>Update Note: 2012/10/11 YANGMJ</br>
        /// <br>             REDMINE#32818 �l�����̏W�v���@�Ή�</br>
        private int SearchSalesHistDtlProc(ref ArrayList ResultAl, CompanyInfWork companyInfWork, int AUPYearMonth, long SalesTargetM, long SalesTargetP, SalesAnnualDataSelectParamWork paramWork, ref SqlConnection sqlConnection, int subTotalDiv, ref ArrayList al)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            DateTime StADDUPADATE = DateTime.MinValue;
            DateTime EdADDUPADATE = DateTime.MinValue;
            string key = string.Empty;
            try
            {
                if (subTotalDiv == 0)
                {
                    FinYearTableGenerator finYearTableGenerator = new FinYearTableGenerator(companyInfWork);
                    finYearTableGenerator.GetDaysFromMonth(TDateTime.LongDateToDateTime("YYYYMM", AUPYearMonth), out StADDUPADATE, out EdADDUPADATE);
                }
                else
                {
                    StADDUPADATE = TDateTime.LongDateToDateTime(paramWork.StAddUpDate);
                    EdADDUPADATE = TDateTime.LongDateToDateTime(paramWork.EdAddUpDate);
                }

                String sText = "";

                IMTtlSaSlip mTtlSaSlipCust = new MTtlSaSlipCust();
                sqlCommand = new SqlCommand("", sqlConnection);

                #region Select Del 2008/12/19 sakurai
                //Del 2008/12/19 sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //sText = " SELECT" + Environment.NewLine;
                //sText += " TOTAL.ENTERPRISECODERF," + Environment.NewLine;
                //sText += " TOTAL.CUSTOMERCODERF," + Environment.NewLine;
                //sText += " TOTAL.SALESSLIPCDDTLRF AS SALESSLIPCDDTLRF , " + Environment.NewLine;
                //sText += " TOTAL.SALESORDERDIVCDRF AS SALESORDERDIVCDRF," + Environment.NewLine;
                //sText += " TOTAL.GOODSKINDCODERF AS GOODSKINDCODERF," + Environment.NewLine;
                //sText += " TOTAL.SUM_SALESMONEYTAXEXCRF AS SALESMONEYTAXEXCRF," + Environment.NewLine;
                //sText += " TOTAL.SUM_COSTRF AS COSTRF," + Environment.NewLine;
                //sText += " COUNTDT.SALESDT_COUNT AS TERMSALESSLIPCOUNTRF" + Environment.NewLine;
                //sText += " FROM" + Environment.NewLine;
                //sText += " (" + Environment.NewLine;
                //sText += " SELECT" + Environment.NewLine;
                //sText += "  SALES.ENTERPRISECODERF AS ENTERPRISECODERF," + Environment.NewLine;
                //sText += "  SALES.SECTIONCODERF AS SECTIONCODERF," + Environment.NewLine;
                //sText += "  SALES.CUSTOMERCODERF AS CUSTOMERCODERF," + Environment.NewLine;
                //sText += " SALES.GOODSKINDCODERF AS GOODSKINDCODERF," + Environment.NewLine;
                //sText += " SALES.SALESORDERDIVCDRF AS SALESORDERDIVCDRF," + Environment.NewLine;
                //sText += " SALES.SALESSLIPCDDTLRF AS SALESSLIPCDDTLRF, " + Environment.NewLine;
                //sText += " SUM(SALESMONEYTAXEXCRF) AS SUM_SALESMONEYTAXEXCRF," + Environment.NewLine;
                //sText += " SUM(COSTRF) AS SUM_COSTRF " + Environment.NewLine;
                //sText += "FROM" + Environment.NewLine;
                //sText += "(" + Environment.NewLine;
                //sText += "SELECT" + Environment.NewLine;
                //sText += "SALESHIS.SALESSLIPNUMRF AS SALESHIS_SALESSLIPNUMRF," + Environment.NewLine;
                //sText += "SALESDT.SALESSLIPNUMRF AS SALESDT_SALESSLIPNUMRF," + Environment.NewLine;
                //sText += "SALESDT.SALESROWNORF AS SALESROWNORF," + Environment.NewLine;
                //sText += "SALESHIS.ENTERPRISECODERF AS ENTERPRISECODERF," + Environment.NewLine;
                //sText += "SALESHIS.SECTIONCODERF AS  SECTIONCODERF," + Environment.NewLine;
                //sText += "SALESHIS.ADDUPADATERF AS ADDUPADATERF," + Environment.NewLine;
                //sText += "SALESHIS.CUSTOMERCODERF AS CUSTOMERCODERF," + Environment.NewLine;
                //sText += "SALESDT.SALESSLIPCDDTLRF AS SALESSLIPCDDTLRF," + Environment.NewLine;
                //sText += "SALESDT.GOODSKINDCODERF AS GOODSKINDCODERF," + Environment.NewLine;
                //sText += "SALESDT.SALESORDERDIVCDRF AS SALESORDERDIVCDRF," + Environment.NewLine;
                //sText += "SALESDT.SALESMONEYTAXEXCRF AS SALESMONEYTAXEXCRF," + Environment.NewLine;
                //sText += "SALESDT.COSTRF AS COSTRF " + Environment.NewLine;
                //sText += "FROM SALESHISTORYRF AS SALESHIS" + Environment.NewLine;
                //sText += "LEFT JOIN" + Environment.NewLine;
                //sText += "SALESHISTDTLRF AS SALESDT" + Environment.NewLine;
                //sText += "ON " + Environment.NewLine;
                //sText += "SALESHIS.SALESSLIPNUMRF = SALESDT.SALESSLIPNUMRF" + Environment.NewLine;
                //sText += mTtlSaSlipCust.MakeWhereString(ref sqlCommand, paramWork, "SALESHIS", SlipTargetDiv.SalesHist, 99);
                //sText += " AND SALESHIS.ADDUPADATERF>=@STADDUPADATE" + Environment.NewLine;
                //sText += " AND SALESHIS.ADDUPADATERF<=@EDADDUPADATE " + Environment.NewLine;
                //sText += ") AS SALES" + Environment.NewLine;
                //sText += "GROUP BY" + Environment.NewLine;
                //sText += " SALES.ENTERPRISECODERF," + Environment.NewLine;
                //sText += " SALES.SECTIONCODERF," + Environment.NewLine;
                //sText += " SALES.CUSTOMERCODERF," + Environment.NewLine;
                //sText += " SALES.GOODSKINDCODERF," + Environment.NewLine;
                //sText += " SALES.SALESSLIPCDDTLRF, " + Environment.NewLine;
                //sText += " SALES.SALESORDERDIVCDRF " + Environment.NewLine;
                //sText += " ) AS TOTAL" + Environment.NewLine;
                //sText += " Left Join" + Environment.NewLine;
                //sText += " (" + Environment.NewLine;
                //sText += " SELECT " + Environment.NewLine;
                //sText += " COUNT(*) AS SALESDT_COUNT," + Environment.NewLine;
                //sText += " ENTERPRISECODERF AS ENTERPRISECODERF," + Environment.NewLine;
                //sText += " SECTIONCODERF AS SECTIONCODERF" + Environment.NewLine;
                //sText += " FROM " + Environment.NewLine;
                //sText += " SALESHISTORYRF as SALESDTCOUNT" + Environment.NewLine;
                //sText += mTtlSaSlipCust.MakeWhereString(ref sqlCommand, paramWork, "SALESDTCOUNT", SlipTargetDiv.SalesHist, 99);
                //sText += " AND SALESDTCOUNT.ADDUPADATERF>=@STADDUPADATE" + Environment.NewLine;
                //sText += " AND SALESDTCOUNT.ADDUPADATERF<=@EDADDUPADATE " + Environment.NewLine;
                //sText += " GROUP BY" + Environment.NewLine;
                //sText += " ENTERPRISECODERF," + Environment.NewLine;
                //sText += " SECTIONCODERF" + Environment.NewLine;
                //sText += " ) COUNTDT" + Environment.NewLine;
                //sText += " ON " + Environment.NewLine;
                //sText += " TOTAL.ENTERPRISECODERF = COUNTDT.ENTERPRISECODERF AND" + Environment.NewLine;
                //sText += " TOTAL.SECTIONCODERF = COUNTDT.SECTIONCODERF" + Environment.NewLine;
                //Del 2008/12/19 sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                #endregion

                #region Select Add 2008/12/19 sakurai
                // --- ADD 2010/10/09 -------------------------------->>>>>
                if (paramWork.SearDiv == 1)
                {
                    sText += " SELECT A.*, CUST.CUSTOMERSNMRF AS CUSTOMERNAMERF FROM (" + Environment.NewLine;
                }
                // --- ADD 2010/10/09 --------------------------------<<<<<
                sText += " SELECT" + Environment.NewLine;
                // --- ADD 2010/08/25 -------------------------------->>>>>
                if (paramWork.SearDiv == 1)
                {
                    sText += " SA.ENTERPRISECODERF," + Environment.NewLine; // ADD 2010/10/09
                    sText += " SA.CUSTOMERCODERF," + Environment.NewLine;
                    //sText += " SA.CUSTOMERNAMERF," + Environment.NewLine; // DEL 2010/10/09
                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                //sText += "  SUM(CASE WHEN  SALESSLIPCDDTLRF = 0 THEN HI.SALESMONEYTAXEXCRF ELSE 0 END) AS P_SALES," + Environment.NewLine;//DEL YANGMJ 2012/10/11 REDMINE#32818
                sText += "  SUM(CASE WHEN  SALESSLIPCDDTLRF = 0 OR (SALESSLIPCDDTLRF = 2 AND GOODSNORF IS NULL) THEN HI.SALESMONEYTAXEXCRF ELSE 0 END) AS P_SALES," + Environment.NewLine;//ADD YANGMJ 2012/10/11 REDMINE#32818
                sText += "  SUM(CASE WHEN  SALESSLIPCDDTLRF = 1 THEN HI.SALESMONEYTAXEXCRF ELSE 0 END) AS P_RETSA," + Environment.NewLine;
                //sText += "  SUM(CASE WHEN  SALESSLIPCDDTLRF = 2 THEN HI.SALESMONEYTAXEXCRF ELSE 0 END) AS P_DISCO," + Environment.NewLine;//DEL YANGMJ 2012/10/11 REDMINE#32818
                sText += "  SUM(CASE WHEN  SALESSLIPCDDTLRF = 2 AND GOODSNORF IS NOT NULL THEN HI.SALESMONEYTAXEXCRF ELSE 0 END) AS P_DISCO," + Environment.NewLine;//ADD YANGMJ 2012/10/11 REDMINE#32818
                sText += "  SUM(HI.SALESMONEYTAXEXCRF) AS P_GROSS," + Environment.NewLine;
                sText += "  SUM(HI.COSTRF) AS COST," + Environment.NewLine;
                sText += "  SUM(CASE WHEN (SA.SALESSLIPCDRF IN (0,1) AND HI.SALESROWNORF=1) THEN 1 ELSE 0 END) AS SALESSLIPCNT," + Environment.NewLine; // ADD 2009/09/07
                sText += "  HI.GOODSKINDCODERF," + Environment.NewLine;
                sText += "  HI.SALESORDERDIVCDRF" + Environment.NewLine;
                sText += "  FROM SALESHISTDTLRF AS HI" + Environment.NewLine;
                sText += " LEFT JOIN SALESHISTORYRF AS SA" + Environment.NewLine;
                sText += "  ON  SA.ENTERPRISECODERF = HI.ENTERPRISECODERF" + Environment.NewLine;
                // -- UPD 2010/05/10 ------------------------------------->>>
                //sText += "  AND SA.SECTIONCODERF = HI.SECTIONCODERF" + Environment.NewLine;
                // -- UPD 2010/05/10 -------------------------------------<<<
                sText += "  AND SA.ACPTANODRSTATUSRF = HI.ACPTANODRSTATUSRF" + Environment.NewLine;
                sText += "  AND SA.SALESSLIPNUMRF = HI.SALESSLIPNUMRF" + Environment.NewLine;
                //sText += " LEFT JOIN MTTLSALESSLIPRF AS MT" + Environment.NewLine;
                //sText += "  ON MT.ENTERPRISECODERF = HI.ENTERPRISECODERF" + Environment.NewLine;
                //sText += "  AND MT.ADDUPSECCODERF = HI.SECTIONCODERF" + Environment.NewLine;
                //sText += "  AND MT.CUSTOMERCODERF = SA.CUSTOMERCODERF" + Environment.NewLine;
                sText += mTtlSaSlipCust.MakeWhereString(ref sqlCommand, paramWork, "SA", SlipTargetDiv.SalesHist, 99);
                sText += "  AND SA.ADDUPADATERF >= @STADDUPADATE" + Environment.NewLine;
                sText += "  AND SA.ADDUPADATERF <= @EDADDUPADATE" + Environment.NewLine;
                sText += "  AND SA.LOGICALDELETECODERF = 0" + Environment.NewLine; // ADD 2009/05/26
                sText += "  AND (HI.GOODSKINDCODERF =0 OR HI.GOODSKINDCODERF =1)" + Environment.NewLine;
                //sText += "  AND MT.EMPLOYEEDIVCDRF =10" + Environment.NewLine;
                sText += " GROUP BY " + Environment.NewLine;
                // --- ADD 2010/08/25 -------------------------------->>>>>
                if (paramWork.SearDiv == 1)
                {
                    sText += " SA.ENTERPRISECODERF," + Environment.NewLine; // ADD 2010/10/09
                    sText += "  SA.CUSTOMERCODERF," + Environment.NewLine;
                    //sText += "  SA.CUSTOMERNAMERF," + Environment.NewLine; // DEL 2010/10/09
                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                sText += "  HI.GOODSKINDCODERF," + Environment.NewLine;
                sText += "  HI.SALESORDERDIVCDRF" + Environment.NewLine;
                // --- ADD 2010/10/09 -------------------------------->>>>>
                if (paramWork.SearDiv == 1)
                {
                    sText += " ) AS A" + Environment.NewLine;
                    sText += " LEFT JOIN CUSTOMERRF AS CUST" + Environment.NewLine;
                    sText += "  ON  A.ENTERPRISECODERF = CUST.ENTERPRISECODERF" + Environment.NewLine;
                    sText += "  AND A.CUSTOMERCODERF = CUST.CUSTOMERCODERF" + Environment.NewLine;
                    sText += "  AND CUST.LOGICALDELETECODERF = 0" + Environment.NewLine;
                }
                // --- ADD 2010/10/09 --------------------------------<<<<<
                #endregion

                sqlCommand.CommandText = sText;

                //Parameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaSTADDUPADATE = sqlCommand.Parameters.Add("@STADDUPADATE", SqlDbType.Int);
                SqlParameter findParaEDADDUPADATE = sqlCommand.Parameters.Add("@EDADDUPADATE", SqlDbType.Int);
                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaSTADDUPADATE.Value = SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate(StADDUPADATE));
                findParaEDADDUPADATE.Value = SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate(EdADDUPADATE));

                //�^�C���A�E�g���Ԃ�ݒ�i�b�j
                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();

                #region
                while (myReader.Read())
                {
                    if (subTotalDiv == 0)
                    {
                        SalesAnnualDataSelectResultWork SalesDataResultWork = new SalesAnnualDataSelectResultWork();
                        #region ���ʃZ�b�g
                        SalesDataResultWork.AUPYearMonth = AUPYearMonth;                                                            // �v��N��                             
                        SalesDataResultWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("P_SALES"));        �@      // ������z
                        SalesDataResultWork.SalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("P_RETSA"));        // �ԕi���z
                        SalesDataResultWork.DiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("P_DISCO"));             // �l�����z
                        //SalesDataResultWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("P_GROSS"));               // �e�����z // DEL 2009/09/07
                        SalesDataResultWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF")); // �ݎ�敪
                        SalesDataResultWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));     // ���i����
                        SalesDataResultWork.Cost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COST"));                         // ����
                        SalesDataResultWork.SalesTargetMoney = SalesTargetM;                                                      �@        �@ // ����ڕW
                        SalesDataResultWork.SalesTargetProfit = SalesTargetP;                                                                  // �e���ڕW                                

                        // ---------- DEL 2012/09/24 ---------->>>>>
                        //SalesDataResultWork.GrossProfit = SalesDataResultWork.SalesMoney + SalesDataResultWork.SalesRetGoodsPrice - SalesDataResultWork.Cost;               // �e�����z  // ADD 2009/09/07
                        // ---------- DEL 2012/09/24 ----------<<<<<
                        // ---------- ADD 2012/09/24 ---------->>>>>
                        SalesDataResultWork.GrossProfit = SalesDataResultWork.SalesMoney + SalesDataResultWork.SalesRetGoodsPrice - SalesDataResultWork.Cost + SalesDataResultWork.DiscountPrice;   // �e�����z
                        // ---------- ADD 2012/09/24 ----------<<<<<
                        SalesDataResultWork.TermSalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCNT")); // �����`�[�����i�����̏W�v�Ŏg�p�j ADD 2009/09/07
                        // --- ADD 2010/08/25 -------------------------------->>>>>
                        if (paramWork.SearDiv == 1)
                        {
                            SalesDataResultWork.SelectionCode = Convert.ToString(SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF")));
                            SalesDataResultWork.SelectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                        }
                        // --- ADD 2010/08/25 --------------------------------<<<<<
                        #endregion

                        ResultAl.Add(SalesDataResultWork);
                    }
                    else
                    {
                        CustSalesAnnualDataSelectResultWork SalesDataResultWork = new CustSalesAnnualDataSelectResultWork();
                        #region ���ʃZ�b�g
                        SalesDataResultWork.AUPYearMonth = AUPYearMonth;                                                              // �v��N��                             
                        SalesDataResultWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("P_SALES"));        �@// ������z
                        SalesDataResultWork.SalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("P_RETSA"));        // �ԕi���z
                        SalesDataResultWork.DiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("P_DISCO"));             // �l�����z
                        //SalesDataResultWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("P_GROSS"));               // �e�����z // DEL 2009/09/07
                        SalesDataResultWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF")); // �ݎ�敪
                        SalesDataResultWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));     // ���i����
                        SalesDataResultWork.Cost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COST"));                         // ����
                        SalesDataResultWork.SalesTargetMoney = SalesTargetM;                                                      �@        �@ // ����ڕW
                        SalesDataResultWork.SalesTargetProfit = SalesTargetP;                                                                  // �e���ڕW                                                                 
                        
                        SalesDataResultWork.GrossProfit = SalesDataResultWork.SalesMoneyTaxExc + SalesDataResultWork.SalesRetGoodsPrice - SalesDataResultWork.Cost;               // �e�����z  // ADD 2009/09/07
                        SalesDataResultWork.TermSalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCNT")); // �����`�[�����i�����̏W�v�Ŏg�p�j ADD 2009/09/07
                        #endregion

                        ResultAl.Add(SalesDataResultWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                #endregion

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
        // ADD 2008/09/22 <<<

    }

}
