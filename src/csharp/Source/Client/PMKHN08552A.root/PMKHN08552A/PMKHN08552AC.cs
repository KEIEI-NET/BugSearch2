using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Collections;
namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���Ӑ�}�X�^�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���Ӑ�}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 30462 �s�V �m��</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class CustomerSetAcs
    {
        #region �� Constructor
        /// <summary>
        /// ���Ӑ�}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public CustomerSetAcs()
        {
            this._iCustomerCustomerChangeDB = (ICustomerCustomerChangeDB)MediationCustomerCustomerChangeDB.GetCustomerCustomerChangeDB();
        }

        /// <summary>
        /// ���Ӑ�}�X�^����A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^����A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.15</br>
        /// </remarks>
        static CustomerSetAcs()
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
        private ICustomerCustomerChangeDB _iCustomerCustomerChangeDB;
        #endregion �� Private Member

		/// <summary>
		/// ���Ӑ�}�X�^�S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, CustomerPrintWork customerPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, customerPrintWork);
		}

		/// <summary>
		/// ���Ӑ�}�X�^���������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchDelete(out ArrayList retList, string enterpriseCode, CustomerPrintWork customerPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData1, 0, customerPrintWork);
		}

		

		/// <summary>
		/// ���Ӑ�}�X�^��������
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
		/// <br>Note       : ���Ӑ�}�X�^�̌����������s���܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, CustomerPrintWork customerPrintWork)
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
                CustomerCustomerChangeParamWork customerCustomerChangeParamWork = new CustomerCustomerChangeParamWork();
                // ���o�����W�J  --------------------------------------------------------------
                status = this.DevReatCndtn(customerPrintWork, enterpriseCode, out customerCustomerChangeParamWork);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retReatList = null;

                status = this._iCustomerCustomerChangeDB.Search(ref retReatList, customerCustomerChangeParamWork,0 ,logicalMode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        DevReatData(customerPrintWork, (ArrayList)retReatList, out retList);

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
        /// <param name="goodsPrintWork">UI���o�����N���X</param>
        /// <param name="goodsPrintParamWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        private int DevReatCndtn(CustomerPrintWork customerPrintWork, string enterpriseCode, out CustomerCustomerChangeParamWork customerCustomerChangeParamWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            customerCustomerChangeParamWork = new CustomerCustomerChangeParamWork();
            try
            {
                customerCustomerChangeParamWork.EnterpriseCode = enterpriseCode;  // ��ƃR�[�h
                // ���o�����p�����[�^�Z�b�g
                // DEL 2008/11/28 �s��Ή�[8306] ---------->>>>>
                //if (customerPrintWork.MngSectionCodeSt.Trim().Equals(string.Empty))
                //{
                //    customerCustomerChangeParamWork.StMngSectionCode = 0;
                //}
                //else
                //{
                //    customerCustomerChangeParamWork.StMngSectionCode = customerPrintWork.MngSectionCodeSt.Trim().PadLeft(2,'0');
                //}
                //if (customerPrintWork.MngSectionCodeEd.Trim().Equals(string.Empty))
                //{
                //    customerCustomerChangeParamWork.EdMngSectionCode = 99;
                //}
                //else
                //{
                //    customerCustomerChangeParamWork.EdMngSectionCode = Int32.Parse(customerPrintWork.MngSectionCodeEd);
                //}
                // DEL 2008/11/28 �s��Ή�[8306] ----------<<<<<
                // ADD 2008/11/28 �s��Ή�[8306] ---------->>>>>
                customerCustomerChangeParamWork.StMngSectionCode = customerPrintWork.MngSectionCodeSt.Trim().PadLeft(2, '0');
                if (customerPrintWork.MngSectionCodeEd.Trim().Equals(string.Empty))
                {
                    customerCustomerChangeParamWork.EdMngSectionCode = "99";
                }
                else
                {
                    customerCustomerChangeParamWork.EdMngSectionCode = customerPrintWork.MngSectionCodeEd.Trim().PadLeft(2,'0');
                }
                // ADD 2008/11/28 �s��Ή�[8306] ----------<<<<<
                customerCustomerChangeParamWork.StCustomerCode = customerPrintWork.CustomerCodeSt;
                if (customerPrintWork.CustomerCodeEd == 0)
                {
                    customerCustomerChangeParamWork.EdCustomerCode = 99999999;
                }
                else
                {
                    customerCustomerChangeParamWork.EdCustomerCode = customerPrintWork.CustomerCodeEd;
                }
                customerCustomerChangeParamWork.StKana = customerPrintWork.KanaSt;
                customerCustomerChangeParamWork.EdKana = customerPrintWork.KanaEd;
                customerCustomerChangeParamWork.StCustomerAgentCd = customerPrintWork.CustomerAgentCdSt;
                customerCustomerChangeParamWork.EdCustomerAgentCd = customerPrintWork.CustomerAgentCdEd;
                customerCustomerChangeParamWork.StSalesAreaCode = customerPrintWork.SalesAreaCodeSt;
                if (customerPrintWork.SalesAreaCodeEd == 0)
                {
                    customerCustomerChangeParamWork.EdSalesAreaCode = 9999;
                }
                else
                {
                    customerCustomerChangeParamWork.EdSalesAreaCode = customerPrintWork.SalesAreaCodeEd;
                }
                customerCustomerChangeParamWork.StBusinessTypeCode = customerPrintWork.BusinessTypeCodeSt;
                if (customerPrintWork.BusinessTypeCodeEd == 0)
                {
                    customerCustomerChangeParamWork.EdBusinessTypeCode = 9999;
                }
                else
                {
                    customerCustomerChangeParamWork.EdBusinessTypeCode = customerPrintWork.BusinessTypeCodeEd;
                }

                if (customerPrintWork.PrintType == 2)
                {
                    customerCustomerChangeParamWork.SearchDiv = 1;
                }
                else
                {
                    customerCustomerChangeParamWork.SearchDiv = 0;
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
        /// <param name="goodsPrintWork">UI���o�����N���X</param>
        /// <param name="retaWork">�擾�f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �擾�f�[�^��W�J����B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.07.17</br>
        /// </remarks>
        private void DevReatData(CustomerPrintWork customerPrintWork, ArrayList retaWork, out ArrayList retList)
        {

            retList = new ArrayList();

            foreach (CustomerCustomerChangeResultWork customerCustomerChangeResultWork in retaWork)
            {
                if (DataCheck(customerCustomerChangeResultWork, customerPrintWork) == 0)
                {
                    CustomerSet customerSet = new CustomerSet();

                    customerSet.CustomerCode = customerCustomerChangeResultWork.CustomerCode;
                    customerSet.Kana = customerCustomerChangeResultWork.Kana;
                    customerSet.OfficeTelNo = customerCustomerChangeResultWork.OfficeTelNo;
                    customerSet.PortableTelNo = customerCustomerChangeResultWork.PortableTelNo;
                    customerSet.OfficeFaxNo = customerCustomerChangeResultWork.OfficeFaxNo;
                    customerSet.TotalDay = customerCustomerChangeResultWork.TotalDay;
                    customerSet.CollectMoneyName = customerCustomerChangeResultWork.CollectMoneyName;
                    customerSet.CollectMoneyDay = customerCustomerChangeResultWork.CollectMoneyDay;
                    customerSet.CustomerAgentCd = customerCustomerChangeResultWork.CustomerAgentCd;
                    customerSet.CustomerAgentName = customerCustomerChangeResultWork.CustomerAgentNm;
                    customerSet.SalesAreaCode = customerCustomerChangeResultWork.SalesAreaCode;
                    customerSet.SalesAreaName = customerCustomerChangeResultWork.SalesAreaName;
                    customerSet.BusinessTypeCode = customerCustomerChangeResultWork.BusinessTypeCode;
                    customerSet.BusinessTypeName = customerCustomerChangeResultWork.BusinessTypeName;
                    customerSet.ClaimSectionCode = customerCustomerChangeResultWork.ClaimSectionCode;
                    customerSet.ClaimCode = customerCustomerChangeResultWork.ClaimCode;
                    customerSet.BillCollecterCd = customerCustomerChangeResultWork.BillCollecterCd;
                    customerSet.PostNo = customerCustomerChangeResultWork.PostNo;
                    customerSet.Address1 = customerCustomerChangeResultWork.Address1;
                    customerSet.Address3 = customerCustomerChangeResultWork.Address3;
                    customerSet.Address4 = customerCustomerChangeResultWork.Address4;
                    customerSet.MngSectionCode = customerCustomerChangeResultWork.MngSectionCode;
                    customerSet.SectionGuideSnm = customerCustomerChangeResultWork.MngSectionName;
                    customerSet.CustWarehouseCd = customerCustomerChangeResultWork.CustWarehouseCd;
                    customerSet.Name = customerCustomerChangeResultWork.Name;
                    customerSet.Name2 = customerCustomerChangeResultWork.Name2;
                    customerSet.CustomerSnm = customerCustomerChangeResultWork.CustomerSnm;
                    customerSet.PureCode = customerCustomerChangeResultWork.RateGPureCode;
                    customerSet.GoodsMakerCd = customerCustomerChangeResultWork.GoodsMakerCd;
                    customerSet.CustRateGrpCode = customerCustomerChangeResultWork.CustRateGrpCode;
                    retList.Add(customerSet);
                }

            }

        }

        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(CustomerCustomerChangeResultWork customerCustomerChangeResultWork, CustomerPrintWork customerPrintWork)
        {
            int status = 0;

            string upDateTime = customerCustomerChangeResultWork.UpdateDateTime.Year.ToString("0000") +
                                customerCustomerChangeResultWork.UpdateDateTime.Month.ToString("00") +
                                customerCustomerChangeResultWork.UpdateDateTime.Day.ToString("00");

            if (customerPrintWork.LogicalDeleteCode == 1 &&
                customerPrintWork.DeleteDateTimeSt != 0 &&
                customerPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < customerPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > customerPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (customerPrintWork.LogicalDeleteCode == 1 &&
                        customerPrintWork.DeleteDateTimeSt != 0 &&
                        customerPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < customerPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (customerPrintWork.LogicalDeleteCode == 1 &&
                 customerPrintWork.DeleteDateTimeSt == 0 &&
                 customerPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > customerPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            // �|���O���[�v�ݒ�̏ꍇ�A�s�v�f�[�^�͕s�Ƃ���
            if (customerPrintWork.PrintType == 2)
            {
                // DEL 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                // TODO:if (customerCustomerChangeResultWork.CustRateGrpCode == 0)
                // DEL 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                // ADD 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                if (customerCustomerChangeResultWork.CustRateGrpCode < 0)
                // ADD 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                {
                    status = -1;
                    return status;
                }
            }
            return status;
        }
               
        #region �|���O���[�v�Ǎ�
        ///// <summary>
        ///// �����敪�擾����
        ///// </summary>
        ///// <param name="makerCode">���Ӑ�R�[�h</param>
        ///// <returns>�����敪</returns>
        ///// <remarks>
        ///// <br>Note       : �����敪���擾���܂��B</br>
        ///// </remarks>
        //private int GetPureCodeCd(int customerCode, string enterpriseCode)
        //{
        //    int PureCodeCd = 0;
        //    ReadCustRateGroup(enterpriseCode);
        //    if (this._CustRateGroupDic.ContainsKey(customerCode))
        //    {
        //        PureCodeCd = this._CustRateGroupDic[customerCode].PureCode;
        //    }

        //    return PureCodeCd;
        //}

        ///// <summary>
        ///// ���[�J�[�R�[�h�擾����
        ///// </summary>
        ///// <param name="makerCode">���Ӑ�R�[�h</param>
        ///// <returns>���[�J�[�R�[�h�R�[�h</returns>
        ///// <remarks>
        ///// <br>Note       : ���[�J�[�R�[�h���擾���܂��B</br>
        ///// </remarks>
        //private int GetGoodsMakerCd(int customerCode, string enterpriseCode)
        //{
        //    int goodsMakerCd = 0;
        //    ReadCustRateGroup(enterpriseCode);
        //    if (this._CustRateGroupDic.ContainsKey(customerCode))
        //    {
        //        goodsMakerCd = this._CustRateGroupDic[customerCode].GoodsMakerCd;
        //    }

        //    return goodsMakerCd;
        //}

        ///// <summary>
        ///// �|���O���[�v�R�[�h�擾����
        ///// </summary>
        ///// <param name="makerCode">���Ӑ�R�[�h</param>
        ///// <returns>�|���O���[�v�R�[�h</returns>
        ///// <remarks>
        ///// <br>Note       : �|���O���[�v�R�[�h���擾���܂��B</br>
        ///// </remarks>
        //private int GetCustRateGrpCode(int customerCode, string enterpriseCode)
        //{
        //    int custRateGrpCode = 0;
        //    ReadCustRateGroup(enterpriseCode);
        //    if (this._CustRateGroupDic.ContainsKey(customerCode))
        //    {
        //        custRateGrpCode = this._CustRateGroupDic[customerCode].CustRateGrpCode;
        //    }

        //    return custRateGrpCode;
        //}

        ///// <summary>
        ///// ���[�J�[�Ǎ�����
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : ���[�J�[�ꗗ��ǂݍ��݂܂��B</br>
        ///// </remarks>
        //private void ReadCustRateGroup(string enterpriseCode)
        //{
        //    try
        //    {
        //        if (this._CustRateGroupDic.Count == 0)
        //        {
        //            this._CustRateGroupDic = new Dictionary<int, CustRateGroup>();

        //            ArrayList retList;

        //            int status = this._CustRateGroupAcs.Search(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
        //            if (status == 0)
        //            {
        //                foreach (CustRateGroup custRateGroup in retList)
        //                {
        //                    if (custRateGroup.LogicalDeleteCode == 0)
        //                    {
        //                        this._CustRateGroupDic.Add(custRateGroup.CustomerCode, custRateGroup);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        this._CustRateGroupDic = new Dictionary<int, CustRateGroup>();

        //        ArrayList retList;

        //        int status = this._CustRateGroupAcs.Search(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
        //        if (status == 0)
        //        {
        //            foreach (CustRateGroup custRateGroup in retList)
        //            {
        //                if (custRateGroup.LogicalDeleteCode == 0)
        //                {
        //                    this._CustRateGroupDic.Add(custRateGroup.CustomerCode, custRateGroup);
        //                }
        //            }
        //        }
        //    }
        //    return;
        //}
        #endregion �|���O���[�v�Ǎ�

    }
}
