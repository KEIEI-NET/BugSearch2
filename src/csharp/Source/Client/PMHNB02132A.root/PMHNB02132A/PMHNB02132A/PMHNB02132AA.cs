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
    /// ���Ӑ�ʉߔN�x���v�\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note         : ���Ӑ�ʉߔN�x���v�\�Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer   : 30452 ��� �r��</br>
    /// <br>Date         : 2008.10.31</br>
    /// <br>             : </br>
    /// </remarks>
    public class CustFinancialListAcs
    {
        #region �� �R���X�g���N�^
		/// <summary>
        /// ���Ӑ�ʉߔN�x���v�\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���Ӑ�ʉߔN�x���v�\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.10.31</br>
		/// </remarks>
		public CustFinancialListAcs()
		{
            this._iCustFinancialListResultWorkDB = (ICustFinancialListResultWorkDB)MediationCustFinancialListResultWorkDB.GetCustFinancialListResultWorkDB();
		}

		/// <summary>
        /// ���Ӑ�ʉߔN�x���v�\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���Ӑ�ʉߔN�x���v�\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.10.31</br>
		/// </remarks>
        static CustFinancialListAcs()
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
        ICustFinancialListResultWorkDB _iCustFinancialListResultWorkDB;

        private DataTable _custFinancialRsltPrintListDt;                    // �����[�g���o���ʕێ�DataTable 
        private DataTable _custFinancialRsltPrintListForPrintDt;			// ���DataTable
        private DataView _custFinancialRsltPrintListForPrintDv;	            // ���DataView

        #endregion

        #region �� Public�v���p�e�B
        /// <summary>
        /// ����f�[�^�Z�b�g(�ǂݎ���p)
        /// </summary>
        public DataView CustFinancialRsltPrintListForPrintDataView
        {
            get { return this._custFinancialRsltPrintListForPrintDv; }
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
        /// <br>Date         : 2008.10.31</br>
        /// </remarks>
        public int SearchMain(CustFinancialListCndtn custFinancialListCndtn, out string errMsg)
        {
            return this.SearchProc(custFinancialListCndtn, out errMsg);
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
        /// <br>Date         : 2008.10.31</br>
        /// </remarks>
        private int SearchProc(CustFinancialListCndtn custFinancialListCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMHNB02135EA.CreateDataTable(ref this._custFinancialRsltPrintListDt);
                PMHNB02135EB.CreateDataTable(ref this._custFinancialRsltPrintListForPrintDt);

                CustFinancialListCndtnWork custFinancialListCndtnWork = new CustFinancialListCndtnWork();
                // ���o�����W�J  --------------------------------------------------------------
                status = this.DevListCndtn(custFinancialListCndtn, out custFinancialListCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retWorkList = null;

                status = this._iCustFinancialListResultWorkDB.Search(out retWorkList, custFinancialListCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);

                // �e�X�g�p
                //status = this.testproc(out retWorkList);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        DevListData(custFinancialListCndtn, (ArrayList)retWorkList);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "���Ӑ�ʉߔN�x���v�\�f�[�^�̎擾�Ɏ��s���܂����B";
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
        /// <br>Date         : 2008.10.31</br>
        /// </remarks>
        private int DevListCndtn(CustFinancialListCndtn custFinancialListCndtn, out CustFinancialListCndtnWork custFinancialListCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            custFinancialListCndtnWork = new CustFinancialListCndtnWork();
            try
            {
                custFinancialListCndtnWork.EnterpriseCode = custFinancialListCndtn.EnterpriseCode;  // ��ƃR�[�h

                // ���o�����p�����[�^�Z�b�g
                if (custFinancialListCndtn.AddUpSecCodes.Length != 0)
                {
                    if (custFinancialListCndtn.IsSelectAllSection)
                    {
                        // �S�Ђ̎�
                        custFinancialListCndtnWork.AddUpSecCodes = null;
                    }
                    else
                    {
                        custFinancialListCndtnWork.AddUpSecCodes = custFinancialListCndtn.AddUpSecCodes;
                    }
                }
                else
                {
                    custFinancialListCndtnWork.AddUpSecCodes = null;
                }
                
                custFinancialListCndtnWork.St_CustomerCode = custFinancialListCndtn.St_CustomerCode; // �J�n���Ӑ�R�[�h
                if (custFinancialListCndtn.Ed_CustomerCode == 0) custFinancialListCndtnWork.Ed_CustomerCode = 99999999;
                else custFinancialListCndtnWork.Ed_CustomerCode = custFinancialListCndtn.Ed_CustomerCode; // �I�����Ӑ�R�[�h
                custFinancialListCndtnWork.St_Year = custFinancialListCndtn.St_Year; // �J�n�N�x
                custFinancialListCndtnWork.Ed_Year = custFinancialListCndtn.Ed_Year; // �I���N�x
                custFinancialListCndtnWork.St_AddUpYearMonth = custFinancialListCndtn.St_AddUpYearMonth; // �J�n�v��N��
                custFinancialListCndtnWork.Ed_AddUpYearMonth = custFinancialListCndtn.Ed_AddUpYearMonth; // �I���v��N��
                custFinancialListCndtnWork.PrintDiv = (int)custFinancialListCndtn.PrintDiv; // ���s�^�C�v
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
        /// <br>Date         : 2008.10.31</br>
        /// </remarks>
        private void DevListData(CustFinancialListCndtn custFinancialListCndtn, ArrayList resultWork)
        {
            // �����[�g���o���ʂ������[�g���o���ʗpDataTable(PMHNB02135EA)�ɓW�J
            DataRow dr;

            foreach (CustFinancialListResultWork custFinancialListResultWork in resultWork)
            {
                dr = this._custFinancialRsltPrintListDt.NewRow();

                dr[PMHNB02135EA.ct_Col_EnterpriseCode] = custFinancialListResultWork.EnterpriseCode; // ��ƃR�[�h
                dr[PMHNB02135EA.ct_Col_AddUpSecCode] = custFinancialListResultWork.AddUpSecCode; // �v�㋒�_�R�[�h
                dr[PMHNB02135EA.ct_Col_SectionGuideSnm] = custFinancialListResultWork.SectionGuideSnm; // ���_�K�C�h����
                dr[PMHNB02135EA.ct_Col_CustomerCode] = custFinancialListResultWork.CustomerCode; // ���Ӑ�R�[�h
                dr[PMHNB02135EA.ct_Col_CustomerSnm] = custFinancialListResultWork.CustomerSnm; // ���Ӑ旪��
                dr[PMHNB02135EA.ct_Col_SalesMoney] = custFinancialListResultWork.SalesMoney; // ������z
                dr[PMHNB02135EA.ct_Col_SalesRetGoodsPrice] = custFinancialListResultWork.SalesRetGoodsPrice; // �ԕi�z
                dr[PMHNB02135EA.ct_Col_DiscountPrice] = custFinancialListResultWork.DiscountPrice; // �l�����z
                dr[PMHNB02135EA.ct_Col_GrossProfit] = custFinancialListResultWork.GrossProfit; // �e�����z
                dr[PMHNB02135EA.ct_Col_FinancialYear] = custFinancialListResultWork.FinancialYear; // ��v�N�x

                this._custFinancialRsltPrintListDt.Rows.Add(dr);
            }

            // ���[�󎚗pDataTable(PMHNB02135EB)�ɋl�ւ�
            // ���o����DataRow�z��
            DataRow[] workDrList;

            if (custFinancialListCndtn.PrintDiv == CustFinancialListCndtn.PrintDivState.Section
                || custFinancialListCndtn.PrintDiv == CustFinancialListCndtn.PrintDivState.ManageSection)
            {
                // ���_�R�[�h�Ń\�[�g
                // �����[�g�œ��Ӑ��ݒ肵�Ȃ��̂ŁA���̕���͂Ȃ��Ă��悢
                workDrList = this._custFinancialRsltPrintListDt.Select("", PMHNB02135EA.ct_Col_AddUpSecCode);
            }
            else
            {
                // ���_�R�[�h�A���Ӑ�Ń\�[�g
                workDrList = this._custFinancialRsltPrintListDt.Select("", PMHNB02135EA.ct_Col_AddUpSecCode + ", " + PMHNB02135EA.ct_Col_CustomerCode);
            }

            string workSectionCode = string.Empty;
            int workCustomerCode = 0;
            DataRow printDr; // ���[�󎚗p�e�[�u����DataRow

            for (int i = 0; i < workDrList.Length; i++)
            {
                // ���o����DataRow
                DataRow workDr = workDrList[i];

                if (i == 0
                    || workSectionCode != workDr[PMHNB02135EA.ct_Col_AddUpSecCode].ToString()
                    || ((custFinancialListCndtn.PrintDiv == CustFinancialListCndtn.PrintDivState.Customer
                        || custFinancialListCndtn.PrintDiv == CustFinancialListCndtn.PrintDivState.CustomerSection
                        || custFinancialListCndtn.PrintDiv == CustFinancialListCndtn.PrintDivState.Clame)
                        && workCustomerCode != (int)workDr[PMHNB02135EA.ct_Col_CustomerCode]))
                {
                    // 1�s�ڂ̏ꍇ�A���_�R�[�h���قȂ�ꍇ�A�i���Ӑ�ʂ����Ӑ�ʋ��_�ʂ�������ʁj�����Ӑ悪�قȂ�ꍇ�͐V�K�s�쐬
                    printDr = this._custFinancialRsltPrintListForPrintDt.NewRow();

                    printDr[PMHNB02135EB.ct_Col_SectionCode] = workDr[PMHNB02135EA.ct_Col_AddUpSecCode]; // ���_�R�[�h
                    printDr[PMHNB02135EB.ct_Col_SectionName] = workDr[PMHNB02135EA.ct_Col_SectionGuideSnm];// ���_����
                    printDr[PMHNB02135EB.ct_Col_CustomerCode] = workDr[PMHNB02135EA.ct_Col_CustomerCode];// ���Ӑ�R�[�h
                    printDr[PMHNB02135EB.ct_Col_CustomerName] = workDr[PMHNB02135EA.ct_Col_CustomerSnm];// ���Ӑ於��

                    // ������z�A�e�����z�ݒ�
                    this.SetFinancialMoneyData(custFinancialListCndtn, ref printDr, workDr);

                    this._custFinancialRsltPrintListForPrintDt.Rows.Add(printDr);

                    // �ǉ������s�̋��_�R�[�h�Ɠ��Ӑ�R�[�h��ێ�
                    workSectionCode = workDr[PMHNB02135EA.ct_Col_AddUpSecCode].ToString();
                    workCustomerCode = (int)workDr[PMHNB02135EA.ct_Col_CustomerCode];
                }
                else
                {
                    // ���[�pDataTable�̊����s�Ƀf�[�^�ǉ�
                    printDr = this._custFinancialRsltPrintListForPrintDt.Rows[this._custFinancialRsltPrintListForPrintDt.Rows.Count - 1];

                    // ������z�A�e�����z�ݒ�
                    this.SetFinancialMoneyData(custFinancialListCndtn, ref printDr, workDr);
                }
            }

            // 2009.02.05 30413 ���� ���[���ŋ��z�P�ʂ��v�Z >>>>>>START
            // ���z�P�ʓK�p
            //ReflectMoneyUnit(custFinancialListCndtn);
            // 2009.02.05 30413 ���� ���[���ŋ��z�P�ʂ��v�Z <<<<<<END
            
            // DataView�쐬
            // ���s�^�C�v�ɂ��\�[�g
            this._custFinancialRsltPrintListForPrintDv = new DataView(this._custFinancialRsltPrintListForPrintDt, "", this.GetSortStr(custFinancialListCndtn), DataViewRowState.CurrentRows);
        }

        /// <summary>
        /// ������z�A�e�����z�ݒ菈��
        /// </summary>
        /// <param name="custFinancialListCndtn">UI���o�����N���X</param>
        /// <param name="printDr">���[�󎚗pDataRow</param>
        /// <param name="workDr">�����[�g���o����DataRow</param>
        /// <remarks>
        /// <br>Note       �@: ������z�A�e�����z����v�N�x���ɉ��������[���ڂɐݒ肷��</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.10.31</br>
        /// </remarks>
        private void SetFinancialMoneyData(CustFinancialListCndtn custFinancialListCndtn, ref DataRow printDr, DataRow workDr)
        {
            // ��v�N�x - �J�n�Ώ۔N + 1 = ���[�̈󎚑Ώۗ�index 
            int index = (Int32)workDr[PMHNB02135EA.ct_Col_FinancialYear] - custFinancialListCndtn.St_Year.Year + 1;

            switch (index)
            {
                case 1:
                    {
                        printDr[PMHNB02135EB.ct_Col_SalesMoney1] = (Int64)workDr[PMHNB02135EA.ct_Col_SalesMoney] + (Int64)workDr[PMHNB02135EA.ct_Col_SalesRetGoodsPrice] + (Int64)workDr[PMHNB02135EA.ct_Col_DiscountPrice];
                        printDr[PMHNB02135EB.ct_Col_GrossProfit1] = (Int64)workDr[PMHNB02135EA.ct_Col_GrossProfit];
                        break;
                    }
                case 2:
                    {
                        printDr[PMHNB02135EB.ct_Col_SalesMoney2] = (Int64)workDr[PMHNB02135EA.ct_Col_SalesMoney] + (Int64)workDr[PMHNB02135EA.ct_Col_SalesRetGoodsPrice] + (Int64)workDr[PMHNB02135EA.ct_Col_DiscountPrice];
                        printDr[PMHNB02135EB.ct_Col_GrossProfit2] = (Int64)workDr[PMHNB02135EA.ct_Col_GrossProfit];
                        break;
                    }
                case 3:
                    {
                        printDr[PMHNB02135EB.ct_Col_SalesMoney3] = (Int64)workDr[PMHNB02135EA.ct_Col_SalesMoney] + (Int64)workDr[PMHNB02135EA.ct_Col_SalesRetGoodsPrice] + (Int64)workDr[PMHNB02135EA.ct_Col_DiscountPrice];
                        printDr[PMHNB02135EB.ct_Col_GrossProfit3] = (Int64)workDr[PMHNB02135EA.ct_Col_GrossProfit];
                        break;
                    }
                case 4:
                    {
                        printDr[PMHNB02135EB.ct_Col_SalesMoney4] = (Int64)workDr[PMHNB02135EA.ct_Col_SalesMoney] + (Int64)workDr[PMHNB02135EA.ct_Col_SalesRetGoodsPrice] + (Int64)workDr[PMHNB02135EA.ct_Col_DiscountPrice];
                        printDr[PMHNB02135EB.ct_Col_GrossProfit4] = (Int64)workDr[PMHNB02135EA.ct_Col_GrossProfit];
                        break;
                    }
                case 5:
                    {
                        printDr[PMHNB02135EB.ct_Col_SalesMoney5] = (Int64)workDr[PMHNB02135EA.ct_Col_SalesMoney] + (Int64)workDr[PMHNB02135EA.ct_Col_SalesRetGoodsPrice] + (Int64)workDr[PMHNB02135EA.ct_Col_DiscountPrice];
                        printDr[PMHNB02135EB.ct_Col_GrossProfit5] = (Int64)workDr[PMHNB02135EA.ct_Col_GrossProfit];
                        break;
                    }
                case 6:
                    {
                        printDr[PMHNB02135EB.ct_Col_SalesMoney6] = (Int64)workDr[PMHNB02135EA.ct_Col_SalesMoney] + (Int64)workDr[PMHNB02135EA.ct_Col_SalesRetGoodsPrice] + (Int64)workDr[PMHNB02135EA.ct_Col_DiscountPrice];
                        printDr[PMHNB02135EB.ct_Col_GrossProfit6] = (Int64)workDr[PMHNB02135EA.ct_Col_GrossProfit];
                        break;
                    }
                case 7:
                    {
                        printDr[PMHNB02135EB.ct_Col_SalesMoney7] = (Int64)workDr[PMHNB02135EA.ct_Col_SalesMoney] + (Int64)workDr[PMHNB02135EA.ct_Col_SalesRetGoodsPrice] + (Int64)workDr[PMHNB02135EA.ct_Col_DiscountPrice];
                        printDr[PMHNB02135EB.ct_Col_GrossProfit7] = (Int64)workDr[PMHNB02135EA.ct_Col_GrossProfit];
                        break;
                    }
                case 8:
                    {
                        printDr[PMHNB02135EB.ct_Col_SalesMoney8] = (Int64)workDr[PMHNB02135EA.ct_Col_SalesMoney] + (Int64)workDr[PMHNB02135EA.ct_Col_SalesRetGoodsPrice] + (Int64)workDr[PMHNB02135EA.ct_Col_DiscountPrice];
                        printDr[PMHNB02135EB.ct_Col_GrossProfit8] = (Int64)workDr[PMHNB02135EA.ct_Col_GrossProfit];
                        break;
                    }
            }
        }

        /// <summary>
        /// DataView�p�\�[�g������擾
        /// </summary>
        /// <param name="custFinancialListCndtn">UI���o�����N���X</param>
        /// <returns>�\�[�g������</returns>
        /// <remarks>
        /// <br>Note       �@: ������z�A�e�����z����v�N�x���ɉ��������[���ڂɐݒ肷��</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.10.31</br>
        /// </remarks>
        private string GetSortStr(CustFinancialListCndtn custFinancialListCndtn)
        {
            string sortStr = string.Empty;

            switch (custFinancialListCndtn.PrintDiv)
            {
                case CustFinancialListCndtn.PrintDivState.Customer:
                case CustFinancialListCndtn.PrintDivState.Clame:
                    {
                        // ���_-���Ӑ�Ń\�[�g
                        sortStr = PMHNB02135EB.ct_Col_SectionCode + ", " + PMHNB02135EB.ct_Col_CustomerCode;
                        break;
                    }
                case CustFinancialListCndtn.PrintDivState.Section:
                case CustFinancialListCndtn.PrintDivState.ManageSection:
                    {
                        // ���_�Ń\�[�g
                        sortStr = PMHNB02135EB.ct_Col_SectionCode;
                        break;
                    }
                case CustFinancialListCndtn.PrintDivState.CustomerSection:
                    {
                        // ���Ӑ�-���_�Ń\�[�g
                        sortStr = PMHNB02135EB.ct_Col_CustomerCode + ", " + PMHNB02135EB.ct_Col_SectionCode;
                        break;
                    }
            }

            return sortStr;

        }

        /// <summary>
        /// ���z�P�ʐݒ�
        /// </summary>
        /// <param name="custFinancialListCndtn">UI���o�����N���X</param>
        /// <remarks>
        /// <br>Note       �@: ������z�A�e�����z�ɋ��z�P�ʂ̔��f���s��</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.10.31</br>
        /// </remarks>
        private void ReflectMoneyUnit(CustFinancialListCndtn custFinancialListCndtn)
        {
            int priceUnit = 1;

            if (custFinancialListCndtn.MoneyUnit == CustFinancialListCndtn.MoneyUnitState.One)
            {
                // �����͕s�v
                return;
            }
            else if (custFinancialListCndtn.MoneyUnit == CustFinancialListCndtn.MoneyUnitState.Thousand)
            {
                // ��~�P��
                priceUnit = 1000;
            }

            foreach(DataRow dr in this._custFinancialRsltPrintListForPrintDt.Rows)
            {
                dr[PMHNB02135EB.ct_Col_SalesMoney1] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_SalesMoney1]) / (decimal)priceUnit); // ������z�P
                dr[PMHNB02135EB.ct_Col_SalesMoney2] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_SalesMoney2]) / (decimal)priceUnit); // ������z�Q
                dr[PMHNB02135EB.ct_Col_SalesMoney3] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_SalesMoney3]) / (decimal)priceUnit); // ������z�R
                dr[PMHNB02135EB.ct_Col_SalesMoney4] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_SalesMoney4]) / (decimal)priceUnit); // ������z�S
                dr[PMHNB02135EB.ct_Col_SalesMoney5] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_SalesMoney5]) / (decimal)priceUnit); // ������z�T
                dr[PMHNB02135EB.ct_Col_SalesMoney6] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_SalesMoney6]) / (decimal)priceUnit); // ������z�U
                dr[PMHNB02135EB.ct_Col_SalesMoney7] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_SalesMoney7]) / (decimal)priceUnit); // ������z�V
                dr[PMHNB02135EB.ct_Col_SalesMoney8] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_SalesMoney8]) / (decimal)priceUnit); // ������z�W

                dr[PMHNB02135EB.ct_Col_GrossProfit1] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_GrossProfit1]) / (decimal)priceUnit); // �e�����z�P
                dr[PMHNB02135EB.ct_Col_GrossProfit2] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_GrossProfit2]) / (decimal)priceUnit); // �e�����z�Q
                dr[PMHNB02135EB.ct_Col_GrossProfit3] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_GrossProfit3]) / (decimal)priceUnit); // �e�����z�R
                dr[PMHNB02135EB.ct_Col_GrossProfit4] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_GrossProfit4]) / (decimal)priceUnit); // �e�����z�S
                dr[PMHNB02135EB.ct_Col_GrossProfit5] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_GrossProfit5]) / (decimal)priceUnit); // �e�����z�T
                dr[PMHNB02135EB.ct_Col_GrossProfit6] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_GrossProfit6]) / (decimal)priceUnit); // �e�����z�U
                dr[PMHNB02135EB.ct_Col_GrossProfit7] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_GrossProfit7]) / (decimal)priceUnit); // �e�����z�V
                dr[PMHNB02135EB.ct_Col_GrossProfit8] = (Int64)((decimal)((Int64)dr[PMHNB02135EB.ct_Col_GrossProfit8]) / (decimal)priceUnit); // �e�����z�W
            }
        }
        #endregion

        #region �e�X�g�f�[�^
        private int testproc(out object retList)
        {
            ArrayList paramlist = new ArrayList();

            //CustFinancialListResultWork param1 = new CustFinancialListResultWork();

            //param1.AddUpSecCode = "1";
            //param1.SectionGuideSnm = "���_���ő�P�O���ł�";
            //param1.CustomerCode = 22;
            //param1.CustomerSnm = "���Ӗ��ő�P�O���ł�";
            //param1.SalesMoney = 13;
            //param1.SalesRetGoodsPrice = -1;
            //param1.DiscountPrice = -2;
            //param1.GrossProfit = 111;
            //param1.FinancialYear = 2008;

            //paramlist.Add(param1);

            //CustFinancialListResultWork param2 = new CustFinancialListResultWork();

            //param2.AddUpSecCode = "1";
            //param2.SectionGuideSnm = "���_���ő�P�O���ł�";
            //param2.CustomerCode = 22;
            //param2.CustomerSnm = "���Ӗ��ő�P�O���ł�";
            //param2.SalesMoney = 23;
            //param2.SalesRetGoodsPrice = -1;
            //param2.DiscountPrice = -2;
            //param2.GrossProfit = 222;
            //param2.FinancialYear = 2007;

            //paramlist.Add(param2);

            //CustFinancialListResultWork param3 = new CustFinancialListResultWork();

            //param3.AddUpSecCode = "1";
            //param3.SectionGuideSnm = "���_���ő�P�O���ł�";
            //param3.CustomerCode = 22;
            //param3.CustomerSnm = "���Ӗ��ő�P�O���ł�";
            //param3.SalesMoney = 33;
            //param3.SalesRetGoodsPrice = -1;
            //param3.DiscountPrice = -2;
            //param3.GrossProfit = 333;
            //param3.FinancialYear = 2006;

            //paramlist.Add(param3);

            retList = (object)paramlist;

            return 0;
        }
        #endregion
    }
}
