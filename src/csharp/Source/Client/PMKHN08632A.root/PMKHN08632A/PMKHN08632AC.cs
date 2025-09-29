using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ����ڕW�ݒ�}�X�^�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ����ڕW�ݒ�}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 30462 �s�V �m��</br>
	/// <br>Date       : 2008.10.24</br>
    /// <br>Update Note: 2009/03/06 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12219</br>
	/// <br></br>
    /// </remarks>
	public class SalesTargetSetAcs 
	{
        #region �� Constructor
        /// <summary>
        /// ����ڕW�ݒ�}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����ڕW�ݒ�}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public SalesTargetSetAcs()
        {
            this._iSalTrgtPrintResultDB = (ISalTrgtPrintResultDB)MediationSalTrgtPrintResultDB.GetSalTrgtPrintResultDB();

        }

        /// <summary>
        /// ����ڕW�ݒ�}�X�^����A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����ڕW�ݒ�}�X�^����A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.15</br>
        /// </remarks>
        static SalesTargetSetAcs()
        {
            stc_Employee = null;
            stc_PrtOutSetAcs = new PrtOutSetAcs();	// ���[�o�͐ݒ�A�N�Z�X�N���X

            stc_SecInfoAcs = new SecInfoAcs(1);         // ���_�A�N�Z�X�N���X
            stc_SectionDic = new Dictionary<string, SecInfoSet>();  // ���_Dictionary

            Employee loginWorker = null;
            string ownSectionCode = "";

            if (LoginInfoAcquisition.Employee != null)
            {
                loginWorker = LoginInfoAcquisition.Employee.Clone();
                ownSectionCode = loginWorker.BelongSectionCode;
            }


            // ���O�C�����_�擾
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }

            // ���_Dictionary����
            SecInfoSet[] secInfoSetList = stc_SecInfoAcs.SecInfoSetList;

            foreach (SecInfoSet secInfoSet in secInfoSetList)
            {
                // �����łȂ����
                if (!stc_SectionDic.ContainsKey(secInfoSet.SectionCode))
                {
                    // �ǉ�
                    stc_SectionDic.Add(secInfoSet.SectionCode, secInfoSet);
                }
            }
        }
        #endregion �� Constructor

        #region �� Static Member
        private static Employee stc_Employee;
        private static PrtOutSetAcs stc_PrtOutSetAcs;	                // ���[�o�͐ݒ�A�N�Z�X�N���X
        private static SecInfoAcs stc_SecInfoAcs;                       // ���_�A�N�Z�X�N���X
        private static Dictionary<string, SecInfoSet> stc_SectionDic;   // ���_Dictionary
        #endregion �� Static Member

        #region �� Private Member
        ISalTrgtPrintResultDB _iSalTrgtPrintResultDB;
        #endregion �� Private Member

		/// <summary>
		/// ����ڕW�ݒ�}�X�^�S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ����ڕW�ݒ�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, SalesTargetPrintWork salesTargetPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, salesTargetPrintWork);
		}

		/// <summary>
		/// ����ڕW�ݒ�}�X�^���������i�_���폜�j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ����ڕW�ݒ�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchDelete(out ArrayList retList, string enterpriseCode, SalesTargetPrintWork salesTargetPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData1, 0, salesTargetPrintWork);
		}


		/// <summary>
		/// ����ڕW�ݒ�}�X�^��������
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
		/// <param name="readCnt">�Ǎ�����</param>
        /// <param name="sectionPrintWork">���o����</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ����ڕW�ݒ�}�X�^�̌����������s���܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, SalesTargetPrintWork salesTargetPrintWork)
		{

            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            //���f�[�^�L��������
            nextData = false;
            //0�ŏ�����
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            try
            {
                SalTrgtPrintParamWork salTrgtPrintParamWork = new SalTrgtPrintParamWork();
                // ���o�����W�J  --------------------------------------------------------------
                status = this.DevReatCndtn(salesTargetPrintWork, enterpriseCode, out salTrgtPrintParamWork);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retReatList = null;

                status = this._iSalTrgtPrintResultDB.Search(out retReatList, salTrgtPrintParamWork, logicalMode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        DevReatData(salesTargetPrintWork, (ArrayList)retReatList, out retList);

                        if (retList.Count == 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
		}

        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="salesTargetPrintWork">UI���o�����N���X</param>
        /// <param name="salTrgtPrintParamWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        private int DevReatCndtn(SalesTargetPrintWork salesTargetPrintWork, string enterpriseCode, out SalTrgtPrintParamWork salTrgtPrintParamWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            salTrgtPrintParamWork = new SalTrgtPrintParamWork();
            try
            {
                salTrgtPrintParamWork.EnterpriseCode = enterpriseCode;  // ��ƃR�[�h
                // ���o�����p�����[�^�Z�b�g
                salTrgtPrintParamWork.SectionCodes = null;
                salTrgtPrintParamWork.PrintType = salesTargetPrintWork.PrintType;
                switch (salesTargetPrintWork.PrintType)
                {
                    case 0: //���_
                        salTrgtPrintParamWork.PrintType = 10;
                        salTrgtPrintParamWork.EmployeeDivCd = 0;
                        break;
                    case 1: //���_-���� 
                        salTrgtPrintParamWork.PrintType = 20;
                        salTrgtPrintParamWork.EmployeeDivCd = 0;
                        break;
                    case 2: //���_-�S���� 
                        salTrgtPrintParamWork.PrintType = 22;
                        salTrgtPrintParamWork.EmployeeDivCd = 10;
                        break;
                    case 3://���_-�󒍎� 
                        salTrgtPrintParamWork.PrintType = 22;
                        salTrgtPrintParamWork.EmployeeDivCd = 20;
                        break;
                    case 4://���_-���s�� 
                        salTrgtPrintParamWork.PrintType = 22;
                        salTrgtPrintParamWork.EmployeeDivCd = 30;
                        break;
                    case 5://���_-�̔��敪 
                        salTrgtPrintParamWork.PrintType = 44;
                        salTrgtPrintParamWork.EmployeeDivCd = 0;
                        break;
                    case 6://���_-���i�敪 
                        salTrgtPrintParamWork.PrintType = 45;
                        salTrgtPrintParamWork.EmployeeDivCd = 0;
                        break;
                    case 7://���_-���Ӑ� 
                        salTrgtPrintParamWork.PrintType = 30;
                        salTrgtPrintParamWork.EmployeeDivCd = 0;
                        break;
                    case 8://���_-�Ǝ� 
                        salTrgtPrintParamWork.PrintType = 31;
                        salTrgtPrintParamWork.EmployeeDivCd = 0;
                        break;
                    case 9://���_-�n��
                        salTrgtPrintParamWork.PrintType = 32;
                        salTrgtPrintParamWork.EmployeeDivCd = 0;
                        break;
                }
                salTrgtPrintParamWork.SearchDiv = 0;
                salTrgtPrintParamWork.TargetDivideCodeSt = salesTargetPrintWork.TargetDivideCodeSt;
                salTrgtPrintParamWork.TargetDivideCodeEd = salesTargetPrintWork.TargetDivideCodeEd;
                salTrgtPrintParamWork.SubSectionCodeSt = salesTargetPrintWork.SubSectionCodeSt;
                if (salesTargetPrintWork.SubSectionCodeEd == 0)
                {
                    salTrgtPrintParamWork.SubSectionCodeEd = 99;
                }
                else
                {
                    salTrgtPrintParamWork.SubSectionCodeEd = salesTargetPrintWork.SubSectionCodeEd;
                }
                salTrgtPrintParamWork.EmployeeCodeSt = salesTargetPrintWork.EmployeeCodeSt;
                salTrgtPrintParamWork.EmployeeCodeEd = salesTargetPrintWork.EmployeeCodeEd;
                salTrgtPrintParamWork.SalesCodeSt = salesTargetPrintWork.SalesCodeSt;
                if (salesTargetPrintWork.SalesCodeEd == 0)
                {
                    salTrgtPrintParamWork.SalesCodeEd = 9999;
                }
                else
                {
                    salTrgtPrintParamWork.SalesCodeEd = salesTargetPrintWork.SalesCodeEd;
                }
                salTrgtPrintParamWork.EnterpriseGanreCodeSt = salesTargetPrintWork.EnterpriseGanreCodeSt;
                if (salesTargetPrintWork.EnterpriseGanreCodeEd == 0)
                {
                    salTrgtPrintParamWork.EnterpriseGanreCodeEd = 9999;
                }
                else
                {
                    salTrgtPrintParamWork.EnterpriseGanreCodeEd = salesTargetPrintWork.EnterpriseGanreCodeEd;
                }
                salTrgtPrintParamWork.CustomerCodeSt = salesTargetPrintWork.CustomerCodeSt;
                if (salesTargetPrintWork.CustomerCodeEd == 0)
                {
                    salTrgtPrintParamWork.CustomerCodeEd = 99999999;
                }
                else
                {
                    salTrgtPrintParamWork.CustomerCodeEd = salesTargetPrintWork.CustomerCodeEd;
                }
                salTrgtPrintParamWork.BusinessTypeCodeSt = salesTargetPrintWork.BusinessTypeCodeSt;
                if (salesTargetPrintWork.BusinessTypeCodeEd == 0)
                {
                    salTrgtPrintParamWork.BusinessTypeCodeEd = 9999;
                }
                else
                {
                    salTrgtPrintParamWork.BusinessTypeCodeEd = salesTargetPrintWork.BusinessTypeCodeEd;
                }
                salTrgtPrintParamWork.SalesAreaCodeSt = salesTargetPrintWork.SalesAreaCodeSt;
                if (salesTargetPrintWork.SalesAreaCodeEd == 0)
                {
                    salTrgtPrintParamWork.SalesAreaCodeEd = 9999;
                }
                else
                {
                    salTrgtPrintParamWork.SalesAreaCodeEd = salesTargetPrintWork.SalesAreaCodeEd;
                }
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// �擾�f�[�^�W�J����
        /// </summary>
        /// <param name="salesTargetPrintWork">UI���o�����N���X</param>
        /// <param name="retaWork">�擾�f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �擾�f�[�^��W�J����B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.07.17</br>
        /// </remarks>
        private void DevReatData(SalesTargetPrintWork salesTargetPrintWork, ArrayList retaWork, out ArrayList retList)
        {

            retList = new ArrayList();

            foreach (SalTrgtPrintResultWork salTrgtPrintResultWork in retaWork)
            {
                if (DataCheck(salTrgtPrintResultWork, salesTargetPrintWork) == 0)
                {
                    SalesTargetSet salesTargetSet = new SalesTargetSet();

                    salesTargetSet.SectionCode = salTrgtPrintResultWork.SectionCode;
                    salesTargetSet.SectionGuideSnm = salTrgtPrintResultWork.SectionGuideSnm;
                    salesTargetSet.SubSectionCode = salTrgtPrintResultWork.SubSectionCode;
                    salesTargetSet.SubSectionName = salTrgtPrintResultWork.SubSectionName;
                    salesTargetSet.SalesEmployeeCd = salTrgtPrintResultWork.SalesEmployeeCd;
                    salesTargetSet.SalesEmployeeNm = salTrgtPrintResultWork.SalesEmployeeNm;
                    salesTargetSet.FrontEmployeeCd = salTrgtPrintResultWork.FrontEmployeeCd;
                    salesTargetSet.FrontEmployeeNm = salTrgtPrintResultWork.FrontEmployeeNm;
                    salesTargetSet.SalesInputCode = salTrgtPrintResultWork.SalesInputCode;
                    salesTargetSet.SalesInputName = salTrgtPrintResultWork.SalesInputName;
                    salesTargetSet.SalesCode = salTrgtPrintResultWork.SalesCode;
                    salesTargetSet.SalesCodeName = salTrgtPrintResultWork.SalesCodeName;
                    salesTargetSet.EnterpriseGanreCode = salTrgtPrintResultWork.EnterpriseGanreCode;
                    salesTargetSet.EnterpriseGanreCodeName = salTrgtPrintResultWork.EnterpriseGanreCodeName;
                    salesTargetSet.CustomerCode = salTrgtPrintResultWork.CustomerCode;
                    salesTargetSet.CustomerSnm = salTrgtPrintResultWork.CustomerSnm;
                    salesTargetSet.BusinessTypeCode = salTrgtPrintResultWork.BusinessTypeCode;
                    salesTargetSet.BusinessTypeCodeName = salTrgtPrintResultWork.BusinessTypeCodeName;
                    salesTargetSet.SalesAreaCode = salTrgtPrintResultWork.SalesAreaCode;
                    salesTargetSet.SalesAreaCodeName = salTrgtPrintResultWork.SalesAreaCodeName;
                    salesTargetSet.SalesTargetMoney1 = salTrgtPrintResultWork.SalesTargetMoney1;
                    salesTargetSet.SalesTargetMoney2 = salTrgtPrintResultWork.SalesTargetMoney2;
                    salesTargetSet.SalesTargetMoney3 = salTrgtPrintResultWork.SalesTargetMoney3;
                    salesTargetSet.SalesTargetMoney4 = salTrgtPrintResultWork.SalesTargetMoney4;
                    salesTargetSet.SalesTargetMoney5 = salTrgtPrintResultWork.SalesTargetMoney5;
                    salesTargetSet.SalesTargetMoney6 = salTrgtPrintResultWork.SalesTargetMoney6;
                    salesTargetSet.SalesTargetMoney7 = salTrgtPrintResultWork.SalesTargetMoney7;
                    salesTargetSet.SalesTargetMoney8 = salTrgtPrintResultWork.SalesTargetMoney8;
                    salesTargetSet.SalesTargetMoney9 = salTrgtPrintResultWork.SalesTargetMoney9;
                    salesTargetSet.SalesTargetMoney10 = salTrgtPrintResultWork.SalesTargetMoney10;
                    salesTargetSet.SalesTargetMoney11 = salTrgtPrintResultWork.SalesTargetMoney11;
                    salesTargetSet.SalesTargetMoney12 = salTrgtPrintResultWork.SalesTargetMoney12;
                    salesTargetSet.SalesTargetProfit1 = salTrgtPrintResultWork.SalesTargetProfit1;
                    salesTargetSet.SalesTargetProfit2 = salTrgtPrintResultWork.SalesTargetProfit2;
                    salesTargetSet.SalesTargetProfit3 = salTrgtPrintResultWork.SalesTargetProfit3;
                    salesTargetSet.SalesTargetProfit4 = salTrgtPrintResultWork.SalesTargetProfit4;
                    salesTargetSet.SalesTargetProfit5 = salTrgtPrintResultWork.SalesTargetProfit5;
                    salesTargetSet.SalesTargetProfit6 = salTrgtPrintResultWork.SalesTargetProfit6;
                    salesTargetSet.SalesTargetProfit7 = salTrgtPrintResultWork.SalesTargetProfit7;
                    salesTargetSet.SalesTargetProfit8 = salTrgtPrintResultWork.SalesTargetProfit8;
                    salesTargetSet.SalesTargetProfit9 = salTrgtPrintResultWork.SalesTargetProfit9;
                    salesTargetSet.SalesTargetProfit10 = salTrgtPrintResultWork.SalesTargetProfit10;
                    salesTargetSet.SalesTargetProfit11 = salTrgtPrintResultWork.SalesTargetProfit11;
                    salesTargetSet.SalesTargetProfit12 = salTrgtPrintResultWork.SalesTargetProfit12;

                    retList.Add(salesTargetSet);
                }

            }

        }

        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(SalTrgtPrintResultWork salTrgtPrintResultWork, SalesTargetPrintWork salesTargetPrintWork)
        {
            int status = 0;

            string upDateTime = salTrgtPrintResultWork.UpdateDateTime.Year.ToString("0000") +
                                salTrgtPrintResultWork.UpdateDateTime.Month.ToString("00") +
                                salTrgtPrintResultWork.UpdateDateTime.Day.ToString("00");

            if (salesTargetPrintWork.LogicalDeleteCode == 1 &&
                salesTargetPrintWork.DeleteDateTimeSt != 0 &&
                salesTargetPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < salesTargetPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > salesTargetPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (salesTargetPrintWork.LogicalDeleteCode == 1 &&
                        salesTargetPrintWork.DeleteDateTimeSt != 0 &&
                        salesTargetPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < salesTargetPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (salesTargetPrintWork.LogicalDeleteCode == 1 &&
                   salesTargetPrintWork.DeleteDateTimeSt == 0 &&
                   salesTargetPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > salesTargetPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }

            // --- DEL 2009/03/06 -------------------------------->>>>>
            //if (Int32.Parse(salTrgtPrintResultWork.SectionCode) < Int32.Parse(salesTargetPrintWork.SectionCodeSt) ||
            //        Int32.Parse(salTrgtPrintResultWork.SectionCode) > Int32.Parse(salesTargetPrintWork.SectionCodeEd))
            //{
            //    status = -1;
            //    return status;
            //}
            // --- DEL 2009/03/06 --------------------------------<<<<<
            // --- ADD 2009/03/06 -------------------------------->>>>>
            // ���_�̒��o����
            int st_SectionCode = 0;
            int ed_SectionCode = 0;
            Int32.TryParse(salesTargetPrintWork.SectionCodeSt, out st_SectionCode);
            Int32.TryParse(salesTargetPrintWork.SectionCodeEd, out ed_SectionCode);

            int result_SectionCode = 0;
            Int32.TryParse(salTrgtPrintResultWork.SectionCode, out result_SectionCode);

            if (st_SectionCode != 0)
            {
                if (result_SectionCode < st_SectionCode)
                {
                    status = -1;
                    return status;
                }
            }

            if (ed_SectionCode != 0)
            {
                if (result_SectionCode > ed_SectionCode)
                {
                    status = -1;
                    return status;
                }
            }
            // --- ADD 2009/03/06 --------------------------------<<<<<

            return status;
        }
    }
}
