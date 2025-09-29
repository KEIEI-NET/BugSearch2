using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ������e���͕\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note         : ������e���͕\�Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer   : 30452 ��� �r��</br>
    /// <br>Date         : 2008.11.11</br>
    /// <br>             : </br>
    /// </remarks>
    public class SalesHistAnalyzeAcs
    {
        #region �� �R���X�g���N�^
		/// <summary>
        /// ������e���͕\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ������e���͕\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.11.11</br>
		/// </remarks>
		public SalesHistAnalyzeAcs()
		{
            this._iSalesHistAnalyzeResultWorkDB = (ISalesHistAnalyzeResultWorkDB)MediationSalesHistAnalyzeResultWorkDB.GetSalesHistAnalyzeResultWorkDB();
		}

		/// <summary>
        /// ������e���͕\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ������e���͕\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.11.11</br>
		/// </remarks>
        static SalesHistAnalyzeAcs()
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

        #region �� Private�ϐ�

        ISalesHistAnalyzeResultWorkDB _iSalesHistAnalyzeResultWorkDB;

        private DataTable _salesHistAnalyzeResultDt; // ���DataTable
        private DataView _salesHistAnalyzeResultDv; // ���DataView

        #endregion

        #region �� Public�v���p�e�B
        /// <summary>
        /// ����f�[�^�Z�b�g(�ǂݎ���p)
        /// </summary>
        public DataView SalesHistAnalyzeResultDataView
        {
            get { return this._salesHistAnalyzeResultDv; }
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
        /// <br>Date         : 2008.11.11</br>
        /// </remarks>
        public int SearchMain(SalesHistAnalyzeCndtn salesHistAnalyzeCndtn, out string errMsg)
        {
            return this.SearchProc(salesHistAnalyzeCndtn, out errMsg);
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
        /// <br>Date         : 2008.11.11</br>
        /// </remarks>
        private int SearchProc(SalesHistAnalyzeCndtn salesHistAnalyzeCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMHNB02165EA.CreateDataTable(ref this._salesHistAnalyzeResultDt);

                SalesHistAnalyzeCndtnWork salesHistAnalyzeCndtnWork = new SalesHistAnalyzeCndtnWork();
                // ���o�����W�J  --------------------------------------------------------------
                status = this.DevListCndtn(salesHistAnalyzeCndtn, out salesHistAnalyzeCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retWorkList = null;

                status = this._iSalesHistAnalyzeResultWorkDB.Search(out retWorkList, salesHistAnalyzeCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);

                // �e�X�g�p
                //status = this.testproc(out retWorkList);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        DevListData(salesHistAnalyzeCndtn, (ArrayList)retWorkList);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "������e���͕\�f�[�^�̎擾�Ɏ��s���܂����B";
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
        /// <br>Date         : 2008.11.11</br>
        /// </remarks>
        private int DevListCndtn(SalesHistAnalyzeCndtn salesHistAnalyzeCndtn, out SalesHistAnalyzeCndtnWork salesHistAnalyzeCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            salesHistAnalyzeCndtnWork = new SalesHistAnalyzeCndtnWork();
            try
            {
                salesHistAnalyzeCndtnWork.EnterpriseCode = salesHistAnalyzeCndtn.EnterpriseCode;  // ��ƃR�[�h

                // ���o�����p�����[�^�Z�b�g
                if (salesHistAnalyzeCndtn.SectionCode.Length != 0)
                {
                    if (salesHistAnalyzeCndtn.IsSelectAllSection)
                    {
                        // �S�Ђ̎�
                        salesHistAnalyzeCndtnWork.SectionCode = null;
                    }
                    else
                    {
                        salesHistAnalyzeCndtnWork.SectionCode = salesHistAnalyzeCndtn.SectionCode;
                    }
                }
                else
                {
                    salesHistAnalyzeCndtnWork.SectionCode = null;
                }

                salesHistAnalyzeCndtnWork.St_SalesDate = salesHistAnalyzeCndtn.St_SalesDate; // �J�n�Ώۓ��t
                salesHistAnalyzeCndtnWork.Ed_SalesDate = salesHistAnalyzeCndtn.Ed_SalesDate; // �I���Ώۓ��t
                salesHistAnalyzeCndtnWork.St_MonthReportDate = salesHistAnalyzeCndtn.St_MonthReportDate; // �J�n�Ώۓ��t(�݌v)
                salesHistAnalyzeCndtnWork.Ed_MonthReportDate = salesHistAnalyzeCndtn.Ed_MonthReportDate; // �I���Ώۓ��t(�݌v)

                salesHistAnalyzeCndtnWork.St_CustomerCode = salesHistAnalyzeCndtn.St_CustomerCode; // �J�n���Ӑ�R�[�h
                if (salesHistAnalyzeCndtn.Ed_CustomerCode == 0) salesHistAnalyzeCndtnWork.Ed_CustomerCode = 99999999;
                else salesHistAnalyzeCndtnWork.Ed_CustomerCode = salesHistAnalyzeCndtn.Ed_CustomerCode; // �I�����Ӑ�R�[�h

                salesHistAnalyzeCndtnWork.St_SalesEmployeeCd = salesHistAnalyzeCndtn.St_SalesEmployeeCd; // �J�n�S���҃R�[�h
                salesHistAnalyzeCndtnWork.Ed_SalesEmployeeCd = salesHistAnalyzeCndtn.Ed_SalesEmployeeCd; // �I���S���҃R�[�h

                salesHistAnalyzeCndtnWork.St_SalesAreaCode = salesHistAnalyzeCndtn.St_SalesAreaCode; // �J�n�n��R�[�h
                if (salesHistAnalyzeCndtn.Ed_SalesAreaCode == 0) salesHistAnalyzeCndtnWork.Ed_SalesAreaCode = 9999;
                else salesHistAnalyzeCndtnWork.Ed_SalesAreaCode = salesHistAnalyzeCndtn.Ed_SalesAreaCode; // �I���n��R�[�h

                salesHistAnalyzeCndtnWork.PrintDiv = (int)salesHistAnalyzeCndtn.PrintDiv; // ���s�^�C�v
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
        /// <br>Date         : 2008.11.11</br>
        /// </remarks>
        private void DevListData(SalesHistAnalyzeCndtn salesHistAnalyzeCndtn, ArrayList resultWork)
        {
            // �����[�g���o���ʂ�DataTable�ɓW�J
            DataRow dr;

            foreach (SalesHistAnalyzeResultWork salesHistAnalyzeResultWork in resultWork)
            {
                dr = this._salesHistAnalyzeResultDt.NewRow();

                dr[PMHNB02165EA.ct_Col_EnterpriseCode] = salesHistAnalyzeResultWork.EnterpriseCode; // ��ƃR�[�h
                dr[PMHNB02165EA.ct_Col_SecCode] = salesHistAnalyzeResultWork.SecCode; // ���_�R�[�h
                dr[PMHNB02165EA.ct_Col_SectionGuideSnm] = salesHistAnalyzeResultWork.SectionGuideSnm; // ���_�K�C�h����
                dr[PMHNB02165EA.ct_Col_CustomerCode] = salesHistAnalyzeResultWork.CustomerCode; // ���Ӑ�R�[�h
                dr[PMHNB02165EA.ct_Col_CustomerSnm] = salesHistAnalyzeResultWork.CustomerSnm; // ���Ӑ旪��
                dr[PMHNB02165EA.ct_Col_SalesEmployeeCd] = salesHistAnalyzeResultWork.SalesEmployeeCd; // �S���҃R�[�h
                dr[PMHNB02165EA.ct_Col_SalesEmployeeNm] = salesHistAnalyzeResultWork.SalesEmployeeNm; // �S���Җ���
                dr[PMHNB02165EA.ct_Col_SalesAreaCode] = salesHistAnalyzeResultWork.SalesAreaCode; // �̔��G���A�R�[�h
                dr[PMHNB02165EA.ct_Col_SalesAreaName] = salesHistAnalyzeResultWork.SalesAreaName; // �̔��G���A����

                dr[PMHNB02165EA.ct_Col_SalesMoneyOrder] = salesHistAnalyzeResultWork.SalesMoneyOrder; // ������z(���v���)
                dr[PMHNB02165EA.ct_Col_SalesMoneyStock] = salesHistAnalyzeResultWork.SalesMoneyStock; // ������z(���v�݌�)
                dr[PMHNB02165EA.ct_Col_SalesMoneyGenuine] = salesHistAnalyzeResultWork.SalesMoneyGenuine; // ������z(���v����)
                dr[PMHNB02165EA.ct_Col_SalesMoneyPrm] = salesHistAnalyzeResultWork.SalesMoneyPrm; // ������z(���v�D��)
                dr[PMHNB02165EA.ct_Col_SalesMoneyOutside] = salesHistAnalyzeResultWork.SalesMoneyOutside; // ������z(���v�O��)
                dr[PMHNB02165EA.ct_Col_SalesMoneyOther] = salesHistAnalyzeResultWork.SalesMoneyOther; // ������z(���v���̑�)
                dr[PMHNB02165EA.ct_Col_MonthSalesMoneyOrder] = salesHistAnalyzeResultWork.MonthSalesMoneyOrder; // ������z(�݌v���)
                dr[PMHNB02165EA.ct_Col_MonthSalesMoneyStock] = salesHistAnalyzeResultWork.MonthSalesMoneyStock; // ������z(�݌v�݌�)
                dr[PMHNB02165EA.ct_Col_MonthSalesMoneyGenuine] = salesHistAnalyzeResultWork.MonthSalesMoneyGenuine; // ������z(�݌v����)
                dr[PMHNB02165EA.ct_Col_MonthSalesMoneyPrm] = salesHistAnalyzeResultWork.MonthSalesMoneyPrm; // ������z(�݌v�D��)
                dr[PMHNB02165EA.ct_Col_MonthSalesMoneyOutside] = salesHistAnalyzeResultWork.MonthSalesMoneyOutside; // ������z(�݌v�O��)
                dr[PMHNB02165EA.ct_Col_MonthSalesMoneyOther] = salesHistAnalyzeResultWork.MonthSalesMoneyOther; // ������z(�݌v���̑�)

                dr[PMHNB02165EA.ct_Col_GrossProfitOrder] = salesHistAnalyzeResultWork.GrossProfitOrder; // �e�����z(���v���)
                dr[PMHNB02165EA.ct_Col_GrossProfitStock] = salesHistAnalyzeResultWork.GrossProfitStock; // �e�����z(���v�݌�)
                dr[PMHNB02165EA.ct_Col_GrossProfitGenuine] = salesHistAnalyzeResultWork.GrossProfitGenuine; // �e�����z(���v����)
                dr[PMHNB02165EA.ct_Col_GrossProfitPrm] = salesHistAnalyzeResultWork.GrossProfitPrm; // �e�����z(���v�D��)
                dr[PMHNB02165EA.ct_Col_GrossProfitOutside] = salesHistAnalyzeResultWork.GrossProfitOutside; // �e�����z(���v�O��)
                dr[PMHNB02165EA.ct_Col_GrossProfitOther] = salesHistAnalyzeResultWork.GrossProfitOther; // �e�����z(���v���̑�)
                dr[PMHNB02165EA.ct_Col_MonthGrossProfitOrder] = salesHistAnalyzeResultWork.MonthGrossProfitOrder; // �e�����z(�݌v���)
                dr[PMHNB02165EA.ct_Col_MonthGrossProfitStock] = salesHistAnalyzeResultWork.MonthGrossProfitStock; // �e�����z(�݌v�݌�)
                dr[PMHNB02165EA.ct_Col_MonthGrossProfitGenuine] = salesHistAnalyzeResultWork.MonthGrossProfitGenuine; // �e�����z(�݌v����)
                dr[PMHNB02165EA.ct_Col_MonthGrossProfitPrm] = salesHistAnalyzeResultWork.MonthGrossProfitPrm; // �e�����z(�݌v�D��)
                dr[PMHNB02165EA.ct_Col_MonthGrossProfitOutside] = salesHistAnalyzeResultWork.MonthGrossProfitOutside; // �e�����z(�݌v�O��)
                dr[PMHNB02165EA.ct_Col_MonthGrossProfitOther] = salesHistAnalyzeResultWork.MonthGrossProfitOther; // �e�����z(�݌v���̑�)

                this._salesHistAnalyzeResultDt.Rows.Add(dr);
            }

            // DataView�쐬
            // ���s�^�C�v�ɂ��\�[�g
            this._salesHistAnalyzeResultDv = new DataView(this._salesHistAnalyzeResultDt, "", this.GetSortStr(salesHistAnalyzeCndtn), DataViewRowState.CurrentRows);
        }

        /// <summary>
        /// DataView�p�\�[�g������擾
        /// </summary>
        /// <param name="custFinancialListCndtn">UI���o�����N���X</param>
        /// <returns>�\�[�g������</returns>
        /// <remarks>
        /// <br>Note       �@: �\�[�g��������擾����</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.11.11</br>
        /// </remarks>
        private string GetSortStr(SalesHistAnalyzeCndtn salesHistAnalyzeCndtn)
        {
            string sortStr = string.Empty;

            switch (salesHistAnalyzeCndtn.PrintDiv)
            {
                case SalesHistAnalyzeCndtn.PrintDivState.Customer:
                    {
                        // ���_-���Ӑ�Ń\�[�g
                        sortStr = PMHNB02165EA.ct_Col_SecCode + ", " + PMHNB02165EA.ct_Col_CustomerCode;
                        break;
                    }
                case SalesHistAnalyzeCndtn.PrintDivState.Employee:
                    {
                        // ���_-�S���҂Ń\�[�g
                        sortStr = PMHNB02165EA.ct_Col_SecCode + ", " + PMHNB02165EA.ct_Col_SalesEmployeeCd;
                        break;
                    }
                case SalesHistAnalyzeCndtn.PrintDivState.SalesArea:
                    {
                        // ���_-�n��Ń\�[�g
                        sortStr = PMHNB02165EA.ct_Col_SecCode + ", " + PMHNB02165EA.ct_Col_SalesAreaCode;
                        break;
                    }
            }

            return sortStr;

        }
        #endregion

        #region �e�X�g�f�[�^
        private int testproc(out object retList)
        {
            ArrayList paramlist = new ArrayList();

            SalesHistAnalyzeResultWork param1 = new SalesHistAnalyzeResultWork();

            param1.SecCode = "99";
            param1.SectionGuideSnm = "���_���ő�P�O���ł�";
            param1.CustomerCode = 88888888;
            param1.CustomerSnm = "���Ӗ��̍ő�P�T���ł��B�R�S�T";
            param1.SalesEmployeeCd = "9999";
            param1.SalesEmployeeNm = "�]�Ƃ͍ő�P�O���ł�";
            param1.SalesAreaCode = 8888;
            param1.SalesAreaName = "�n��͍ő�P�O���ł�";

            param1.SalesMoneyOrder = 2500000000; // ������z(���v���)
            param1.SalesMoneyStock = 7500000000; // ������z(���v�݌�)
            param1.SalesMoneyGenuine = 2500000000; // ������z(���v����)
            param1.SalesMoneyPrm = 7500000000; // ������z(���v�D��)
            param1.SalesMoneyOutside = 2500000000; // ������z(���v�O��)
            param1.SalesMoneyOther = 7500000000; // ������z(���v���̑�)

            param1.MonthSalesMoneyOrder = 2500000000; // ������z(�݌v���)
            param1.MonthSalesMoneyStock = 2500000000; // ������z(�݌v�݌�)
            param1.MonthSalesMoneyGenuine = 2500000000; // ������z(�݌v����)
            param1.MonthSalesMoneyPrm = 2500000000; // ������z(�݌v�D��)
            param1.MonthSalesMoneyOutside = 2500000000; // ������z(�݌v�O��)
            param1.MonthSalesMoneyOther = 2500000000; // ������z(�݌v���̑�)
            
            //paramlist.Add(param1);

            retList = (object)paramlist;

            return 0;
        }
        #endregion
    }
}
