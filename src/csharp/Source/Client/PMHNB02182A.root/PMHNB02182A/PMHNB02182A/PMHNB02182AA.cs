using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���Ӑ�ʎ�����z�\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note         : ���Ӑ�ʎ�����z�\�Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer   : 30452 ��� �r��</br>
    /// <br>Date         : 2008.11.21</br>
    /// <br>Update Note  : 2011/11/09 ������</br>
    /// <br>             : Redmine#26432�̑Ή�</br> 
    /// <br>             : </br>
    /// </remarks>
    public class CustSalesDistributionReportAcs
    {
        #region �� �R���X�g���N�^
		/// <summary>
        /// ���Ӑ�ʎ�����z�\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���Ӑ�ʎ�����z�\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.11.21</br>
		/// </remarks>
		public CustSalesDistributionReportAcs()
		{
            this._iCustSalesDistributionReportResultDB = (ICustSalesDistributionReportResultDB)MediationCustSalesDistributionReportResultDB.GetCustSalesDistributionReportResultDB();
		}

		/// <summary>
        /// ���Ӑ�ʎ�����z�\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���Ӑ�ʎ�����z�\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.11.21</br>
		/// </remarks>
        static CustSalesDistributionReportAcs()
		{
            stc_Employee		= null;
			stc_PrtOutSet		= null;					// ���[�o�͐ݒ�f�[�^�N���X
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// ���[�o�͐ݒ�A�N�Z�X�N���X

            stc_SecInfoAcs      = new SecInfoAcs(1);    // ���_�A�N�Z�X�N���X
            stc_SectionDic      = new Dictionary<string,SecInfoSet>();  // ���_Dictionary

            // ���O�C�����_�擾
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }

            // ���_Dictionary����
            SecInfoSet[] secInfoSetList = stc_SecInfoAcs.SecInfoSetList;

            foreach ( SecInfoSet secInfoSet in secInfoSetList )
            {
                // �����łȂ����
                if ( !stc_SectionDic.ContainsKey( secInfoSet.SectionCode ) )
                {
                    // �ǉ�
                    stc_SectionDic.Add( secInfoSet.SectionCode, secInfoSet );
                }
            }
        }
		#endregion

        #region �� Static�ϐ�
        private static Employee stc_Employee;
        private static PrtOutSet stc_PrtOutSet;			// ���[�o�͐ݒ�f�[�^�N���X
        private static PrtOutSetAcs stc_PrtOutSetAcs;	// ���[�o�͐ݒ�A�N�Z�X�N���X

        private static SecInfoAcs stc_SecInfoAcs;               // ���_�A�N�Z�X�N���X
        private static Dictionary<string, SecInfoSet> stc_SectionDic;   // ���_Dictionary
        #endregion

        #region private�萔
        // ���[�󎚂��锄����t�L��
        private const string CT_SalesDateStr = "*";
        #endregion

        #region �� Private�ϐ�
        ICustSalesDistributionReportResultDB _iCustSalesDistributionReportResultDB;

        private DataTable _custSalesDistributionReportDt; // �����[�g���o���ʕێ�DataTable
        private DataTable _printDt;                       // ���[�󎚃f�[�^�ێ�DataTable
        private DataView  _custSalesDistributionReportDv; // ���DataView

        private HolidaySettingAcs _holidaySettingAcs; // �x�Ɠ��ݒ�A�N�Z�X�N���X(�c�Ɠ����擾�p)
        #endregion

        #region �� Public�v���p�e�B
        /// <summary>
        /// ����f�[�^�Z�b�g(�ǂݎ���p)
        /// </summary>
        public DataView CustSalesDistributionDataView
        {
            get { return this._custSalesDistributionReportDv; }
        }
        #endregion

        #region �� Public���\�b�h
        /// <summary>
        /// �f�[�^�擾
        /// </summary>
        /// <param name="salesRsltListCndtn">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������f�[�^���擾����B</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.11.21</br>
        /// </remarks>
        public int SearchMain(CustSalesDistributionReportParam custSalesDistributionReportParam, out string errMsg)
        {
            return this.SearchProc(custSalesDistributionReportParam, out errMsg);
        }

        /// <summary>
        /// ���[�o�͐ݒ�Ǎ�
        /// </summary>
        /// <param name="retPrtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����_�̒��[�o�͐ݒ�̓Ǎ����s���܂��B</br>
        /// </remarks>
        static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = "";

            try
            {
                // �f�[�^�͓Ǎ��ς݂��H
                if (stc_PrtOutSet != null)
                {
                    retPrtOutSet = stc_PrtOutSet.Clone();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = stc_PrtOutSet.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        default:
                            errMsg = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂���";
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                retPrtOutSet = new PrtOutSet();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region �� Private���\�b�h

        /// <summary>
        /// �f�[�^�擾
        /// </summary>
        /// <param name="salesRsltListCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������f�[�^���擾����B</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.11.21</br>
        /// </remarks>
        private int SearchProc(CustSalesDistributionReportParam custSalesDistributionReportParam, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMHNB02185EA.CreateDataTable(ref this._custSalesDistributionReportDt);

                CustSalesDistributionReportParamWork custSalesDistributionReportParamWork = new CustSalesDistributionReportParamWork();
                // ���o�����W�J  --------------------------------------------------------------
                status = this.DevListCndtn(custSalesDistributionReportParam, out custSalesDistributionReportParamWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retWorkList = null;

                status = this._iCustSalesDistributionReportResultDB.Search(out retWorkList, custSalesDistributionReportParamWork);

                // �e�X�g�p
                //status = this.testproc(out retWorkList);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        DevListData(custSalesDistributionReportParam, (ArrayList)retWorkList);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "���Ӑ�ʎ�����z�\�f�[�^�̎擾�Ɏ��s���܂����B";
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="salesRsltListCndtn">UI���o�����N���X</param>
        /// <param name="salesRsltListCndtnWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       �@: ��ʒ��o�����������[�g���o�����֓W�J����</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.11.21</br>
        /// </remarks>
        private int DevListCndtn(CustSalesDistributionReportParam custSalesDistributionReportParam, out CustSalesDistributionReportParamWork custSalesDistributionReportParamWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            custSalesDistributionReportParamWork = new CustSalesDistributionReportParamWork();

            try
            {
                custSalesDistributionReportParamWork.EnterpriseCode = custSalesDistributionReportParam.EnterpriseCode;  // ��ƃR�[�h

                // ���o�����p�����[�^�Z�b�g
                if (custSalesDistributionReportParam.SectionCode.Length != 0)
                {
                    if (custSalesDistributionReportParam.IsSelectAllSection)
                    {
                        // �S�Ђ̎�
                        custSalesDistributionReportParamWork.SectionCode = null;
                    }
                    else
                    {
                        custSalesDistributionReportParamWork.SectionCode = custSalesDistributionReportParam.SectionCode;
                    }
                }
                else
                {
                    custSalesDistributionReportParamWork.SectionCode = null;
                }

                custSalesDistributionReportParamWork.StSalesDate = custSalesDistributionReportParam.StSalesDate; // �J�n�Ώۓ��t
                custSalesDistributionReportParamWork.EdSalesDate = custSalesDistributionReportParam.EdSalesDate; // �I���Ώۓ��t

                custSalesDistributionReportParamWork.StSalesEmployeeCd = custSalesDistributionReportParam.StSalesEmployeeCd; // �J�n�S���҃R�[�h
                custSalesDistributionReportParamWork.EdSalesEmployeeCd = custSalesDistributionReportParam.EdSalesEmployeeCd; // �I���S���҃R�[�h

                custSalesDistributionReportParamWork.StSalesAreaCode = custSalesDistributionReportParam.StSalesAreaCode; // �J�n�n��R�[�h
                if (custSalesDistributionReportParam.EdSalesAreaCode == 0) custSalesDistributionReportParamWork.EdSalesAreaCode = 9999;
                else custSalesDistributionReportParamWork.EdSalesAreaCode = custSalesDistributionReportParam.EdSalesAreaCode; // �I���n��R�[�h

                custSalesDistributionReportParamWork.StCustomerCode = custSalesDistributionReportParam.StCustomerCode; // �J�n���Ӑ�R�[�h
                if (custSalesDistributionReportParam.EdCustomerCode == 0) custSalesDistributionReportParamWork.EdCustomerCode = 99999999;
                else custSalesDistributionReportParamWork.EdCustomerCode = custSalesDistributionReportParam.EdCustomerCode; // �I�����Ӑ�R�[�h

                custSalesDistributionReportParamWork.SearchDiv = custSalesDistributionReportParam.SearchDiv; // ���ш���敪
                custSalesDistributionReportParamWork.PrintDiv = (int)custSalesDistributionReportParam.PrintType; // ���s�^�C�v
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// �擾�f�[�^�W�J����
        /// </summary>
        /// <param name="salesRsltListCndtn">UI���o�����N���X</param>
        /// <param name="resultWork">�擾�f�[�^</param>
        /// <remarks>
        /// <br>Note       �@: �����[�g���o���ʂ𒠕[�󎚗pDataTable�֓W�J����</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.11.21</br>
        /// </remarks>
        private void DevListData(CustSalesDistributionReportParam custSalesDistributionReportParam, ArrayList resultWork)
        {
            // �����[�g���o���ʂ�DataTable�ɓW�J
            DataRow dr;

            foreach (CustSalesDistributionReportResultWork custSalesDistributionReportResultWork in resultWork)
            {
                dr = this._custSalesDistributionReportDt.NewRow();

                dr[PMHNB02185EA.ct_Col_EnterpriseCode] = custSalesDistributionReportResultWork.EnterpriseCode; // ��ƃR�[�h
                dr[PMHNB02185EA.ct_Col_SecCode] = custSalesDistributionReportResultWork.SecCode; // ���_�R�[�h
                dr[PMHNB02185EA.ct_Col_SectionGuideSnm] = custSalesDistributionReportResultWork.SectionGuideSnm; // ���_�K�C�h����

                dr[PMHNB02185EA.ct_Col_CustomerCode] = custSalesDistributionReportResultWork.CustomerCode; // ���Ӑ�R�[�h
                dr[PMHNB02185EA.ct_Col_CustomerSnm] = custSalesDistributionReportResultWork.CustomerSnm; // ���Ӑ旪��
                dr[PMHNB02185EA.ct_Col_SalesEmployeeCd] = custSalesDistributionReportResultWork.SalesEmployeeCd; // �S���҃R�[�h
                dr[PMHNB02185EA.ct_Col_SalesEmployeeNm] = custSalesDistributionReportResultWork.SalesEmployeeNm; // �S���Җ���
                dr[PMHNB02185EA.ct_Col_SalesAreaCode] = custSalesDistributionReportResultWork.SalesAreaCode; // �̔��G���A�R�[�h
                dr[PMHNB02185EA.ct_Col_SalesAreaName] = custSalesDistributionReportResultWork.SalesAreaName; // �̔��G���A����

                dr[PMHNB02185EA.ct_Col_SalesCount] = custSalesDistributionReportResultWork.SalesCount; // �`�[����
                dr[PMHNB02185EA.ct_Col_SalesTotalTaxExc] = custSalesDistributionReportResultWork.SalesTotalTaxExc; //������
                dr[PMHNB02185EA.ct_Col_TotalCost] = custSalesDistributionReportResultWork.TotalCost; // �������z�v
                dr[PMHNB02185EA.ct_Col_SalesDate] = custSalesDistributionReportResultWork.SalesDate; // ������t
                

                this._custSalesDistributionReportDt.Rows.Add(dr);
            }

            // ���[�󎚗p�e�[�u���ɋl�ւ�
            this.MakePrintTable(custSalesDistributionReportParam);

            // ���ʐݒ�
            this.SetOrder(custSalesDistributionReportParam);

            // DataView�쐬
            // ���ʂɂ��t�B���^�A���s�^�C�v�ɂ��\�[�g
            this._custSalesDistributionReportDv = new DataView(this._printDt, this.GetFilterStrForPrintDv(custSalesDistributionReportParam), this.GetSortStrForPrintDv(custSalesDistributionReportParam), DataViewRowState.CurrentRows);
        }

        /// <summary>
        /// ���[�󎚃e�[�u���쐬�p�\�[�g������擾
        /// </summary>
        /// <param name="custFinancialListCndtn">UI���o�����N���X</param>
        /// <returns>�\�[�g������</returns>
        /// <remarks>
        /// <br>Note       �@: �\�[�g��������擾����</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.11.21</br>
        /// </remarks>
        private void GetSortStrForPrintDt(CustSalesDistributionReportParam custSalesDistributionReportParam)
        {
            string sortString = string.Empty;
            // ���_�Ɣ��s�^�C�v�̃R�[�h���Ƀ\�[�g
            if (custSalesDistributionReportParam.PrintType == CustSalesDistributionReportParam.PrintTypeState.Customer)
            {
                sortString = PMHNB02185EA.ct_Col_SecCode + ", " + PMHNB02185EA.ct_Col_CustomerCode;
            }
            else if (custSalesDistributionReportParam.PrintType == CustSalesDistributionReportParam.PrintTypeState.Employee)
            {
                sortString = PMHNB02185EA.ct_Col_SecCode + ", " + PMHNB02185EA.ct_Col_SalesEmployeeCd;
            }
            else if (custSalesDistributionReportParam.PrintType == CustSalesDistributionReportParam.PrintTypeState.Area)
            {
                sortString = PMHNB02185EA.ct_Col_SecCode + ", " + PMHNB02185EA.ct_Col_SalesAreaCode;
            }

            DataTable workTable = this._custSalesDistributionReportDt.Copy();
            this._custSalesDistributionReportDt.Clear();

            DataRow[] workRowList = workTable.Select("", sortString);

            foreach (DataRow workDr in workRowList)
            {
                this._custSalesDistributionReportDt.ImportRow(workDr);
            }
        }

        /// <summary>
        /// ���[�󎚃e�[�u�����쐬����
        /// </summary>
        /// <param name="custFinancialListCndtn">UI���o�����N���X</param>
        /// <remarks>
        /// <br>Note       �@: ���[�󎚃e�[�u�����쐬����</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.11.21</br>
        /// </remarks>
        private void MakePrintTable(CustSalesDistributionReportParam custSalesDistributionReportParam)
        {
            // �e�[�u���쐬
            PMHNB02185EB.CreateDataTable(ref this._printDt);

            // �L�[���Ƀ\�[�g
            this.GetSortStrForPrintDt(custSalesDistributionReportParam);

            // ���L�[�l��ێ�
            string sectionKey = string.Empty;
            string codeKey = string.Empty;

            // �L�[�l�ƂȂ�J������
            string codeColumnName;

            if (custSalesDistributionReportParam.PrintType == CustSalesDistributionReportParam.PrintTypeState.Customer)
            {
                codeColumnName = PMHNB02185EB.ct_Col_CustomerCode;
            }
            else if (custSalesDistributionReportParam.PrintType == CustSalesDistributionReportParam.PrintTypeState.Employee)
            {
                codeColumnName = PMHNB02185EB.ct_Col_SalesEmployeeCd;
            }
            else
            {
                codeColumnName = PMHNB02185EB.ct_Col_SalesAreaCode;
            }


            // �����[�g��������1�s������
            foreach (DataRow dr in this._custSalesDistributionReportDt.Rows)
            {
                if (sectionKey == dr[PMHNB02185EA.ct_Col_SecCode].ToString()
                    && codeKey == dr[codeColumnName].ToString())
                {
                    // ���L�[�l(���[���s�f�[�^)
                    DataRow existRow = this._printDt.Rows[this._printDt.Rows.Count - 1];

                    existRow[PMHNB02185EB.ct_Col_SalesCount] = (Int32)existRow[PMHNB02185EB.ct_Col_SalesCount]
                                                             + (Int32)dr[PMHNB02185EA.ct_Col_SalesCount]; // �`�[����
                    existRow[PMHNB02185EB.ct_Col_SalesTotalTaxExc] = (Int64)existRow[PMHNB02185EB.ct_Col_SalesTotalTaxExc]
                                                                   + (Int64)dr[PMHNB02185EA.ct_Col_SalesTotalTaxExc]; // ������
                    existRow[PMHNB02185EB.ct_Col_GrossProfit] = (Int64)existRow[PMHNB02185EB.ct_Col_GrossProfit]
                                                                   + (Int64)dr[PMHNB02185EA.ct_Col_SalesTotalTaxExc]
                                                                   - (Int64)dr[PMHNB02185EA.ct_Col_TotalCost]; // �e��(������ - �������z�v)

                    int salesDate = ((DateTime)dr[PMHNB02185EA.ct_Col_SalesDate]).Year * 10000 
                                  + ((DateTime)dr[PMHNB02185EA.ct_Col_SalesDate]).Month * 100
                                  + ((DateTime)dr[PMHNB02185EA.ct_Col_SalesDate]).Day;

                    if (salesDate >= custSalesDistributionReportParam.StSalesDate
                        && salesDate <= custSalesDistributionReportParam.EdSalesDate)
                    {
                        // ������t����ʓ��͈͓͂̔��ł����"*"��ݒ�
                        this.SetSalesDate(ref existRow, (DateTime)dr[PMHNB02185EA.ct_Col_SalesDate], custSalesDistributionReportParam.StartDate); // ������t
                    }
                }
                else
                {
                    // �ʃL�[�l(���[�ʍs�f�[�^)
                    DataRow newRow = this._printDt.NewRow();

                    newRow[PMHNB02185EB.ct_Col_SecCode] = dr[PMHNB02185EA.ct_Col_SecCode]; // ���_�R�[�h
                    newRow[PMHNB02185EB.ct_Col_SectionGuideSnm] = dr[PMHNB02185EA.ct_Col_SectionGuideSnm];// ���_�K�C�h����
                    newRow[PMHNB02185EB.ct_Col_CustomerCode] = dr[PMHNB02185EA.ct_Col_CustomerCode];// ���Ӑ�R�[�h
                    newRow[PMHNB02185EB.ct_Col_CustomerSnm] = dr[PMHNB02185EA.ct_Col_CustomerSnm];// ���Ӑ旪��
                    newRow[PMHNB02185EB.ct_Col_SalesEmployeeCd] = dr[PMHNB02185EA.ct_Col_SalesEmployeeCd];// �̔��]�ƈ��R�[�h
                    newRow[PMHNB02185EB.ct_Col_SalesEmployeeNm] = dr[PMHNB02185EA.ct_Col_SalesEmployeeNm];// �̔��]�ƈ�����
                    newRow[PMHNB02185EB.ct_Col_SalesAreaCode] = dr[PMHNB02185EA.ct_Col_SalesAreaCode];// �̔��G���A�R�[�h
                    newRow[PMHNB02185EB.ct_Col_SalesAreaName] = dr[PMHNB02185EA.ct_Col_SalesAreaName];// �̔��G���A����

                    newRow[PMHNB02185EB.ct_Col_SalesCount] = dr[PMHNB02185EA.ct_Col_SalesCount]; // �`�[����
                    newRow[PMHNB02185EB.ct_Col_SalesTotalTaxExc] = dr[PMHNB02185EA.ct_Col_SalesTotalTaxExc]; // ������
                    newRow[PMHNB02185EB.ct_Col_GrossProfit] = (Int64)dr[PMHNB02185EA.ct_Col_SalesTotalTaxExc]
                                                             - (Int64)dr[PMHNB02185EA.ct_Col_TotalCost]; // �e��(������ - �������z�v)                   
                    //newRow[PMHNB02185EB.ct_Col_BusinessDays] 
                    //    = this.GetBussinessDays(dr[PMHNB02185EA.ct_Col_SecCode].ToString(), custSalesDistributionReportParam.StartDate); // �c�Ɠ��� // DEL BY ������ on 2011/11/09

                    // --------ADD BY  ������ on 2011/11/09 for Redmine#26432 ---------->>>>>>>>>>>>>
                    DateTime startDate = Convert.ToDateTime(custSalesDistributionReportParam.StSalesDate.ToString().Substring(0, 4)
                                      + "/" + custSalesDistributionReportParam.StSalesDate.ToString().Substring(4, 2)
                                      + "/" + custSalesDistributionReportParam.StSalesDate.ToString().Substring(6, 2));
                    DateTime endDate = Convert.ToDateTime(custSalesDistributionReportParam.EdSalesDate.ToString().Substring(0, 4) 
                                       + "/" + custSalesDistributionReportParam.EdSalesDate.ToString().Substring(4, 2) 
                                       + "/" + custSalesDistributionReportParam.EdSalesDate.ToString().Substring(6, 2));
                    newRow[PMHNB02185EB.ct_Col_BusinessDays]
                       = this.GetBussinessDays(dr[PMHNB02185EA.ct_Col_SecCode].ToString(), startDate, endDate); // �c�Ɠ���
                    // --------ADD BY  ������ on 2011/11/09 for Redmine#26432 ----------<<<<<<<<<<<<<<

                    int salesDate = ((DateTime)dr[PMHNB02185EA.ct_Col_SalesDate]).Year * 10000
                                  + ((DateTime)dr[PMHNB02185EA.ct_Col_SalesDate]).Month * 100
                                  + ((DateTime)dr[PMHNB02185EA.ct_Col_SalesDate]).Day;

                    if (salesDate >= custSalesDistributionReportParam.StSalesDate
                        && salesDate <= custSalesDistributionReportParam.EdSalesDate)
                    {
                        // ������t����ʓ��͈͓͂̔��ł����"*"��ݒ�
                        this.SetSalesDate(ref newRow, (DateTime)dr[PMHNB02185EA.ct_Col_SalesDate], custSalesDistributionReportParam.StartDate); // ������t
                    }

                    this._printDt.Rows.Add(newRow);

                    // �L�[�l�̕ۑ�
                    sectionKey = dr[PMHNB02185EA.ct_Col_SecCode].ToString();
                    codeKey = dr[codeColumnName].ToString();

                }
            }
        }

        /// <summary>
        /// �c�Ɠ����擾����
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <param name="targetDay"></param>
        /// <param name="endDay"></param> //ADD BY ������ on 2011/11/09
        /// <returns>�c�Ɠ���</returns>
        //private int GetBussinessDays(string sectionCode, DateTime targetDay) //DEL BY ������ on 2011/11/09
        private int GetBussinessDays(string sectionCode, DateTime targetDay, DateTime endDay)//ADD BY ������ on 2011/11/09
        {
            if (_holidaySettingAcs == null)
            {
                _holidaySettingAcs = new HolidaySettingAcs();
            }

            // �c�Ɠ���
            int bussinessDays;

            // ���_�R�[�h�̎w�肪�����ꍇ�A�����_�̉c�Ɠ������擾����
            if (string.IsNullOrEmpty(sectionCode) ||
                sectionCode.Trim().PadLeft(2, '0') == "00")
            {
                sectionCode = stc_Employee.BelongSectionCode;
            }

            //_holidaySettingAcs.GetWorkDaysInRange(sectionCode, targetDay, targetDay.AddMonths(1).AddDays(-1), out bussinessDays);//DEL BY ������ on 2011/11/09
            _holidaySettingAcs.GetWorkDaysInRange(sectionCode, targetDay, endDay, out bussinessDays);//ADD BY ������ on 2011/11/09 for Redmine#26432

            return bussinessDays;
        }

        /// <summary>
        /// ������t�̈󎚐ݒ�
        /// </summary>
        /// <param name="setRow">����p�e�[�u��(PMHNB02185EB)��DataRow</param>
        /// <param name="setDate"></param>
        /// <param name="startDate"></param>
        /// <remarks>
        /// <br>Note       �@: ������t�̈󎚐ݒ���s��</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.11.21</br>
        /// </remarks>
        private void SetSalesDate(ref DataRow setRow, DateTime setDate, DateTime startDate)
        {
            int dayInterval = ((TimeSpan)(setDate - startDate)).Days;

            switch (dayInterval)
            {
                case 0:
                    setRow[PMHNB02185EB.ct_Col_SalesDate1] = CT_SalesDateStr;
                    break;
                case 1:
                    setRow[PMHNB02185EB.ct_Col_SalesDate2] = CT_SalesDateStr;
                    break;
                case 2:
                    setRow[PMHNB02185EB.ct_Col_SalesDate3] = CT_SalesDateStr;
                    break;
                case 3:
                    setRow[PMHNB02185EB.ct_Col_SalesDate4] = CT_SalesDateStr;
                    break;
                case 4:
                    setRow[PMHNB02185EB.ct_Col_SalesDate5] = CT_SalesDateStr;
                    break;
                case 5:
                    setRow[PMHNB02185EB.ct_Col_SalesDate6] = CT_SalesDateStr;
                    break;
                case 6:
                    setRow[PMHNB02185EB.ct_Col_SalesDate7] = CT_SalesDateStr;
                    break;
                case 7:
                    setRow[PMHNB02185EB.ct_Col_SalesDate8] = CT_SalesDateStr;
                    break;
                case 8:
                    setRow[PMHNB02185EB.ct_Col_SalesDate9] = CT_SalesDateStr;
                    break;
                case 9:
                    setRow[PMHNB02185EB.ct_Col_SalesDate10] = CT_SalesDateStr;
                    break;
                case 10:
                    setRow[PMHNB02185EB.ct_Col_SalesDate11] = CT_SalesDateStr;
                    break;
                case 11:
                    setRow[PMHNB02185EB.ct_Col_SalesDate12] = CT_SalesDateStr;
                    break;
                case 12:
                    setRow[PMHNB02185EB.ct_Col_SalesDate13] = CT_SalesDateStr;
                    break;
                case 13:
                    setRow[PMHNB02185EB.ct_Col_SalesDate14] = CT_SalesDateStr;
                    break;
                case 14:
                    setRow[PMHNB02185EB.ct_Col_SalesDate15] = CT_SalesDateStr;
                    break;
                case 15:
                    setRow[PMHNB02185EB.ct_Col_SalesDate16] = CT_SalesDateStr;
                    break;
                case 16:
                    setRow[PMHNB02185EB.ct_Col_SalesDate17] = CT_SalesDateStr;
                    break;
                case 17:
                    setRow[PMHNB02185EB.ct_Col_SalesDate18] = CT_SalesDateStr;
                    break;
                case 18:
                    setRow[PMHNB02185EB.ct_Col_SalesDate19] = CT_SalesDateStr;
                    break;
                case 19:
                    setRow[PMHNB02185EB.ct_Col_SalesDate20] = CT_SalesDateStr;
                    break;
                case 20:
                    setRow[PMHNB02185EB.ct_Col_SalesDate21] = CT_SalesDateStr;
                    break;
                case 21:
                    setRow[PMHNB02185EB.ct_Col_SalesDate22] = CT_SalesDateStr;
                    break;
                case 22:
                    setRow[PMHNB02185EB.ct_Col_SalesDate23] = CT_SalesDateStr;
                    break;
                case 23:
                    setRow[PMHNB02185EB.ct_Col_SalesDate24] = CT_SalesDateStr;
                    break;
                case 24:
                    setRow[PMHNB02185EB.ct_Col_SalesDate25] = CT_SalesDateStr;
                    break;
                case 25:
                    setRow[PMHNB02185EB.ct_Col_SalesDate26] = CT_SalesDateStr;
                    break;
                case 26:
                    setRow[PMHNB02185EB.ct_Col_SalesDate27] = CT_SalesDateStr;
                    break;
                case 27:
                    setRow[PMHNB02185EB.ct_Col_SalesDate28] = CT_SalesDateStr;
                    break;
                case 28:
                    setRow[PMHNB02185EB.ct_Col_SalesDate29] = CT_SalesDateStr;
                    break;
                case 29:
                    setRow[PMHNB02185EB.ct_Col_SalesDate30] = CT_SalesDateStr;
                    break;
                case 30:
                    setRow[PMHNB02185EB.ct_Col_SalesDate31] = CT_SalesDateStr;
                    break;

            }
        }

        /// <summary>
        /// ���ʐݒ�
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       �@: ���ʂ̐ݒ���s��</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.11.21</br>
        /// </remarks>
        private void SetOrder(CustSalesDistributionReportParam custSalesDistributionReportParam)
        {
            string savAddUpSecCode = ""; // ���_�R�[�h
            int orderNo = 0; // ����
            int orderNoPls = 0; // ���ʉ��Z�l
            Int64 savTotls = -1;
            Int64 nowTotls = 0;

            DataTable tmpTable = this._printDt.Copy();
            this._printDt.Clear();

            // ���ʕt�ݒ菇�ɕ��ёւ�
            DataRow[] sortedDrList = tmpTable.Select("", this.GetSortStrForOrder(custSalesDistributionReportParam));

            for (int i = 0; i < sortedDrList.Length; i++)
            {
                DataRow dr = sortedDrList[i];

                // ���_
                string tmpAddUpSecCode = (string)dr[PMHNB02185EB.ct_Col_SecCode];

                if (custSalesDistributionReportParam.RankSection == CustSalesDistributionReportParam.RankSectionState.Section)
                {
                    // ���ʕt�����_�������_���قȂ�ꍇ�A���ʕt����������
                    if (custSalesDistributionReportParam.RankSection == CustSalesDistributionReportParam.RankSectionState.Section
                        && savAddUpSecCode.Trim() != tmpAddUpSecCode.Trim())
                    {
                        savAddUpSecCode = tmpAddUpSecCode;
                        orderNo = 0;
                        orderNoPls = 0;
                        savTotls = -1;
                    }
                }

                if (custSalesDistributionReportParam.RankStandard == CustSalesDistributionReportParam.RankStandardState.Sales)
                {
                    // ������
                    nowTotls = (Int64)dr[PMHNB02185EB.ct_Col_SalesTotalTaxExc];
                }
                else
                {
                    // �e��
                    nowTotls = (Int64)dr[PMHNB02185EB.ct_Col_GrossProfit];
                }

                if (savTotls == nowTotls)
                {
                    orderNoPls++;
                }
                else
                {
                    // ���ʂ͍ő�l�ȏ���U��
                    savTotls = nowTotls;
                    orderNo += orderNoPls;
                    orderNoPls = 0;
                }

                if (orderNoPls == 0)
                {
                    orderNo++;
                }

                dr[PMHNB02185EB.ct_Col_Order] = orderNo;

                this._printDt.ImportRow(dr);
            }
        }

        /// <summary>
        /// ���ʕt�p�\�[�g������쐬
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       �@: ���ʕt�p�\�[�g��������쐬����</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.11.21</br>
        /// </remarks>
        private string GetSortStrForOrder(CustSalesDistributionReportParam custSalesDistributionReportParam)
        {
            StringBuilder sb = new StringBuilder();

            if (custSalesDistributionReportParam.RankSection == CustSalesDistributionReportParam.RankSectionState.Section)
            {
                // ���_���̏ꍇ�A���_�Ń\�[�g
                sb.Append(PMHNB02185EB.ct_Col_SecCode);
                sb.Append(", ");
            }

            // ���ʎw��
            if (custSalesDistributionReportParam.RankStandard == CustSalesDistributionReportParam.RankStandardState.Sales)
            {
                // ������
                sb.Append(PMHNB02185EB.ct_Col_SalesTotalTaxExc);
            }
            else
            {
                // �e��
                sb.Append(PMHNB02185EB.ct_Col_GrossProfit);
            }

            if (custSalesDistributionReportParam.RankHighLow == CustSalesDistributionReportParam.RankHighLowState.High)
            {
                sb.Append(" DESC");
            }
            else
            {
                sb.Append(" ASC");
            }

            return sb.ToString();
        }

        /// <summary>
        /// DataView�p�t�B���^������擾
        /// </summary>
        /// <param name="custFinancialListCndtn">UI���o�����N���X</param>
        /// <returns>�t�B���^������</returns>
        /// <remarks>
        /// <br>Note       �@: �t�B���^��������쐬����</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.11.21</br>
        /// </remarks>
        private string GetFilterStrForPrintDv(CustSalesDistributionReportParam custSalesDistributionReportParam)
        {
            return PMHNB02185EB.ct_Col_Order + " <= " + custSalesDistributionReportParam.RankOrderMax.ToString();
        }

        /// <summary>
        /// DataView�p�\�[�g������擾
        /// </summary>
        /// <param name="custFinancialListCndtn">UI���o�����N���X</param>
        /// <returns>�\�[�g������</returns>
        /// <remarks>
        /// <br>Note       �@: �\�[�g��������쐬����</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.11.21</br>
        /// </remarks>
        private string GetSortStrForPrintDv(CustSalesDistributionReportParam custSalesDistributionReportParam)
        {
            StringBuilder sb = new StringBuilder();

            // ���_
            sb.Append(PMHNB02185EB.ct_Col_SecCode);
            sb.Append(", ");

            // �������"����"�ł���΁A����
            if (custSalesDistributionReportParam.PrintOrder == CustSalesDistributionReportParam.PrintOrderState.Order)
            {
                sb.Append(PMHNB02185EB.ct_Col_Order);
                sb.Append(", ");
            }

            // ���s�^�C�v�ݒ�l
            if (custSalesDistributionReportParam.PrintType == CustSalesDistributionReportParam.PrintTypeState.Customer)
            {
                // ���Ӑ��
                sb.Append(PMHNB02185EB.ct_Col_CustomerCode);
            }
            else if (custSalesDistributionReportParam.PrintType == CustSalesDistributionReportParam.PrintTypeState.Employee)
            {
                // �S���ҕ�
                sb.Append(PMHNB02185EB.ct_Col_SalesEmployeeCd);
            }
            else
            {
                // �n���
                sb.Append(PMHNB02185EB.ct_Col_SalesAreaCode);
            }

            return sb.ToString();

        }
        #endregion

        #region �e�X�g�f�[�^
        private int testproc(out object retList)
        {
            ArrayList paramlist = new ArrayList();

            CustSalesDistributionReportResultWork param1 = new CustSalesDistributionReportResultWork();

            param1.EnterpriseCode = "0101150842020000";
            param1.SecCode = "1";
            param1.SectionGuideSnm = "���_���ő�P�O���ł�";
            param1.CustomerCode = 88888888;
            param1.CustomerSnm = "���Ӗ��̍ő�P�T���ł��B�R�S�T";
            param1.SalesEmployeeCd = "9999";
            param1.SalesEmployeeNm = "�]�Ƃ͍ő�P�O���ł�";
            param1.SalesAreaCode = 8888;
            param1.SalesAreaName = "�n��͍ő�P�O���ł�";

            param1.SalesCount = 123456; // �`�[����
            param1.SalesTotalTaxExc = 987654321; //������
            param1.TotalCost = 123456789; // �������z�v
            param1.SalesDate = new DateTime(2008, 11, 22); // ������t


            paramlist.Add(param1);

            CustSalesDistributionReportResultWork param2 = new CustSalesDistributionReportResultWork();

            param2.EnterpriseCode = "0101150842020000";
            param2.SecCode = "";
            param2.SectionGuideSnm = "";
            param2.CustomerCode = 0;
            param2.CustomerSnm = "";
            param2.SalesEmployeeCd = "";
            param2.SalesEmployeeNm = "";
            param2.SalesAreaCode = 0;
            param2.SalesAreaName = "";

            param2.SalesCount = 0; // �`�[����
            param2.SalesTotalTaxExc = 0; //������
            param2.TotalCost = 0; // �������z�v
            param2.SalesDate = new DateTime(2008, 11, 25); // ������t

            paramlist.Add(param2);

            retList = (object)paramlist;

            return 0;
        }
        #endregion
    }
}
