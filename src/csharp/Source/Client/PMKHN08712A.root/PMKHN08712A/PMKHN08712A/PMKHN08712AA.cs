//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���ڕW�ݒ�}�X�^�i����j
// �v���O�����T�v   : �L�����y�[���ڕW�ݒ�}�X�^�Őݒ肵�����e���ꗗ�o�͂�
//                    �m�F����
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �k���r
// �� �� ��  2011/04/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �L�����y�[���ڕW�ݒ�}�X�^�e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : �k���r</br>
    /// <br>Date       : 2011/04/25</br>
    /// <br>Update Note: </br>
    /// <br></br>
    /// </remarks>
    public class CampaignTargetSetAcs 
    {
        #region �� Constructor
        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: </br>
        /// </remarks>
        public CampaignTargetSetAcs()
        {
            this._iCampTrgtPrintResultDB = (ICampTrgtPrintResultDB)MediationCampTrgtPrintResultDB.GetCampTrgtPrintResultDB();
        }

        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^����A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^����A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: </br>
        /// </remarks>
        static CampaignTargetSetAcs()
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
        ICampTrgtPrintResultDB _iCampTrgtPrintResultDB;
        #endregion �� Private Member

        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^�S���������i�_���폜�����j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: </br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, CampaignTargetPrintWork campaignTargetPrintWork)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, campaignTargetPrintWork);
        }

        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^���������i�_���폜�j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: </br>
        /// </remarks>
        public int SearchDelete(out ArrayList retList, string enterpriseCode, CampaignTargetPrintWork campaignTargetPrintWork)
        {

            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData1, 0, campaignTargetPrintWork);
        }

        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^��������
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
        /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^�̌����������s���܂��B</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: </br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, CampaignTargetPrintWork campaignTargetPrintWork)
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
                CampTrgtPrintParamWork campTrgtPrintParamWork = new CampTrgtPrintParamWork();
                // ���o�����W�J  --------------------------------------------------------------
                status = this.DevReatCndtn(campaignTargetPrintWork, enterpriseCode, out campTrgtPrintParamWork);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retReatList = null;

                status = this._iCampTrgtPrintResultDB.Search(out retReatList, campTrgtPrintParamWork, logicalMode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        DevReatData(campaignTargetPrintWork, (ArrayList)retReatList, out retList);

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
        /// <param name="campaignTargetPrintWork">UI���o�����N���X</param>
        /// <param name="salTrgtPrintParamWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        private int DevReatCndtn(CampaignTargetPrintWork campaignTargetPrintWork, string enterpriseCode, out CampTrgtPrintParamWork campTrgtPrintParamWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            campTrgtPrintParamWork = new CampTrgtPrintParamWork();
            try
            {
                campTrgtPrintParamWork.StartMonth = campaignTargetPrintWork.StartMonth;

                campTrgtPrintParamWork.EnterpriseCode = enterpriseCode;  // ��ƃR�[�h
                // ���o�����p�����[�^�Z�b�g
                campTrgtPrintParamWork.SectionCodes = null;
                // ���_�̑��֏���
                campTrgtPrintParamWork.SectionCodeSt = campaignTargetPrintWork.SectionCodeSt;
                campTrgtPrintParamWork.SectionCodeEd = campaignTargetPrintWork.SectionCodeEd;

                campTrgtPrintParamWork.PrintType = campaignTargetPrintWork.PrintType;
                switch (campaignTargetPrintWork.PrintType)
                {
                    case 0: //���_
                        campTrgtPrintParamWork.PrintType = 10;
                        campTrgtPrintParamWork.EmployeeDivCd = 0;
                        break;
                    case 1: //���_-���Ӑ�  
                        campTrgtPrintParamWork.PrintType = 30;
                        campTrgtPrintParamWork.EmployeeDivCd = 0;
                        break;
                    case 2: //���_-�S���� 
                        campTrgtPrintParamWork.PrintType = 22;
                        campTrgtPrintParamWork.EmployeeDivCd = 10;
                        break;
                    case 3://���_-�󒍎� 
                        campTrgtPrintParamWork.PrintType = 22;
                        campTrgtPrintParamWork.EmployeeDivCd = 20;
                        break;
                    case 4://���_-���s�� 
                        campTrgtPrintParamWork.PrintType = 22;
                        campTrgtPrintParamWork.EmployeeDivCd = 30;
                        break;
                    case 5://���_-�n��
                        campTrgtPrintParamWork.PrintType = 32;
                        campTrgtPrintParamWork.EmployeeDivCd = 0;
                        break;
                    case 6://���_+��ٰ�ߺ���,
                        campTrgtPrintParamWork.PrintType = 50;
                        campTrgtPrintParamWork.EmployeeDivCd = 0;
                        break;
                    case 7://���_+BL���� 
                        campTrgtPrintParamWork.PrintType = 60;
                        campTrgtPrintParamWork.EmployeeDivCd = 0;
                        break;
                    case 8://���_-�̔��敪 
                        campTrgtPrintParamWork.PrintType = 44;
                        campTrgtPrintParamWork.EmployeeDivCd = 0;
                        break;
                }
                campTrgtPrintParamWork.CampaignCodeSt = campaignTargetPrintWork.CampaignCodeSt;
                if (campaignTargetPrintWork.CampaignCodeEd == 0)
                {
                    campTrgtPrintParamWork.CampaignCodeEd = 999999;
                }
                else
                {
                    campTrgtPrintParamWork.CampaignCodeEd = campaignTargetPrintWork.CampaignCodeEd;
                }

                campTrgtPrintParamWork.BlGoodsCdSt = campaignTargetPrintWork.BlGoodsCdSt;
                if (campaignTargetPrintWork.BlGoodsCdEd == 0)
                {
                    campTrgtPrintParamWork.BlGoodsCdEd = 99999999;
                }
                else
                {
                    campTrgtPrintParamWork.BlGoodsCdEd = campaignTargetPrintWork.BlGoodsCdEd;
                }
                campTrgtPrintParamWork.EmployeeCodeSt = campaignTargetPrintWork.EmployeeCodeSt;
                campTrgtPrintParamWork.EmployeeCodeEd = campaignTargetPrintWork.EmployeeCodeEd;

                campTrgtPrintParamWork.SalesCodeSt = campaignTargetPrintWork.SalesCodeSt;
                if (campaignTargetPrintWork.SalesCodeEd == 0)
                {
                    campTrgtPrintParamWork.SalesCodeEd = 9999;
                }
                else
                {
                    campTrgtPrintParamWork.SalesCodeEd = campaignTargetPrintWork.SalesCodeEd;
                }

                campTrgtPrintParamWork.BlGroupCodeSt = campaignTargetPrintWork.BlGroupCodeSt;
                if (campaignTargetPrintWork.BlGroupCodeEd == 0)
                {
                    campTrgtPrintParamWork.BlGroupCodeEd = 99999;
                }
                else
                {
                    campTrgtPrintParamWork.BlGroupCodeEd = campaignTargetPrintWork.BlGroupCodeEd;
                }

                campTrgtPrintParamWork.CustomerCodeSt = campaignTargetPrintWork.CustomerCodeSt;
                if (campaignTargetPrintWork.CustomerCodeEd == 0)
                {
                    campTrgtPrintParamWork.CustomerCodeEd = 99999999;
                }
                else
                {
                    campTrgtPrintParamWork.CustomerCodeEd = campaignTargetPrintWork.CustomerCodeEd;
                }

                campTrgtPrintParamWork.SalesAreaCodeSt = campaignTargetPrintWork.SalesAreaCodeSt;
                if (campaignTargetPrintWork.SalesAreaCodeEd == 0)
                {
                    campTrgtPrintParamWork.SalesAreaCodeEd = 9999;
                }
                else
                {
                    campTrgtPrintParamWork.SalesAreaCodeEd = campaignTargetPrintWork.SalesAreaCodeEd;
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
        /// <param name="campaignTargetPrintWork">UI���o�����N���X</param>
        /// <param name="retaWork">�擾�f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �擾�f�[�^��W�J����B</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void DevReatData(CampaignTargetPrintWork campaignTargetPrintWork, ArrayList retaWork, out ArrayList retList)
        {

            retList = new ArrayList();

            foreach (CampTrgtPrintResultWork campTrgtPrintResultWork in retaWork)
            {
                if (DataCheck(campTrgtPrintResultWork, campaignTargetPrintWork) == 0)
                {
                    CampaignTargetSet campaignTargetSet = new CampaignTargetSet();

                    campaignTargetSet.CampaignCode = campTrgtPrintResultWork.CampaignCode.ToString();
                    campaignTargetSet.CampaignCodeName = campTrgtPrintResultWork.CampaignName;
                    campaignTargetSet.SectionCode = campTrgtPrintResultWork.SectionCode;
                    campaignTargetSet.SectionGuideSnm = campTrgtPrintResultWork.SectionGuideSnm;
                    campaignTargetSet.BlGoodsCode = campTrgtPrintResultWork.BLGoodsCode;
                    campaignTargetSet.BlGoodsCodeName = campTrgtPrintResultWork.BLGoodsHalfName;
                    if (campTrgtPrintResultWork.EmployeeDivCd == 10)
                    {
                        campaignTargetSet.SalesEmployeeCd = campTrgtPrintResultWork.EmployeeCode;
                        campaignTargetSet.SalesEmployeeNm = campTrgtPrintResultWork.Name;
                    }
                    else if (campTrgtPrintResultWork.EmployeeDivCd == 20)
                    {
                        campaignTargetSet.FrontEmployeeCd = campTrgtPrintResultWork.EmployeeCode;
                        campaignTargetSet.FrontEmployeeNm = campTrgtPrintResultWork.Name;
                    }
                    else if (campTrgtPrintResultWork.EmployeeDivCd == 30)
                    {
                        campaignTargetSet.SalesInputCode = campTrgtPrintResultWork.EmployeeCode;
                        campaignTargetSet.SalesInputName = campTrgtPrintResultWork.Name;
                    }
                    campaignTargetSet.SalesCode = campTrgtPrintResultWork.SalesCode;
                    campaignTargetSet.SalesCodeName = campTrgtPrintResultWork.SalesCodeName;
                    campaignTargetSet.BlGroupCode = campTrgtPrintResultWork.BLGroupCode;
                    campaignTargetSet.BlGroupCodeName = campTrgtPrintResultWork.BLGroupKanaName;
                    campaignTargetSet.CustomerCode = campTrgtPrintResultWork.CustomerCode;
                    campaignTargetSet.CustomerSnm = campTrgtPrintResultWork.CustomerSnm;
                    campaignTargetSet.SalesAreaCode = campTrgtPrintResultWork.SalesAreaCode;
                    campaignTargetSet.SalesAreaCodeName = campTrgtPrintResultWork.SalesAreaName;

                    campaignTargetSet.SalesTargetMoney1 = campTrgtPrintResultWork.SalesTargetMoney1;
                    campaignTargetSet.SalesTargetMoney2 = campTrgtPrintResultWork.SalesTargetMoney2;
                    campaignTargetSet.SalesTargetMoney3 = campTrgtPrintResultWork.SalesTargetMoney3;
                    campaignTargetSet.SalesTargetMoney4 = campTrgtPrintResultWork.SalesTargetMoney4;
                    campaignTargetSet.SalesTargetMoney5 = campTrgtPrintResultWork.SalesTargetMoney5;
                    campaignTargetSet.SalesTargetMoney6 = campTrgtPrintResultWork.SalesTargetMoney6;
                    campaignTargetSet.SalesTargetMoney7 = campTrgtPrintResultWork.SalesTargetMoney7;
                    campaignTargetSet.SalesTargetMoney8 = campTrgtPrintResultWork.SalesTargetMoney8;
                    campaignTargetSet.SalesTargetMoney9 = campTrgtPrintResultWork.SalesTargetMoney9;
                    campaignTargetSet.SalesTargetMoney10 = campTrgtPrintResultWork.SalesTargetMoney10;
                    campaignTargetSet.SalesTargetMoney11 = campTrgtPrintResultWork.SalesTargetMoney11;
                    campaignTargetSet.SalesTargetMoney12 = campTrgtPrintResultWork.SalesTargetMoney12;
                    campaignTargetSet.MonthlySalesTarget = campTrgtPrintResultWork.MonthlySalesTarget;
                    campaignTargetSet.TermSalesTarget = campTrgtPrintResultWork.TermSalesTarget;

                    campaignTargetSet.SalesTargetProfit1 = campTrgtPrintResultWork.SalesTargetProfit1;
                    campaignTargetSet.SalesTargetProfit2 = campTrgtPrintResultWork.SalesTargetProfit2;
                    campaignTargetSet.SalesTargetProfit3 = campTrgtPrintResultWork.SalesTargetProfit3;
                    campaignTargetSet.SalesTargetProfit4 = campTrgtPrintResultWork.SalesTargetProfit4;
                    campaignTargetSet.SalesTargetProfit5 = campTrgtPrintResultWork.SalesTargetProfit5;
                    campaignTargetSet.SalesTargetProfit6 = campTrgtPrintResultWork.SalesTargetProfit6;
                    campaignTargetSet.SalesTargetProfit7 = campTrgtPrintResultWork.SalesTargetProfit7;
                    campaignTargetSet.SalesTargetProfit8 = campTrgtPrintResultWork.SalesTargetProfit8;
                    campaignTargetSet.SalesTargetProfit9 = campTrgtPrintResultWork.SalesTargetProfit9;
                    campaignTargetSet.SalesTargetProfit10 = campTrgtPrintResultWork.SalesTargetProfit10;
                    campaignTargetSet.SalesTargetProfit11 = campTrgtPrintResultWork.SalesTargetProfit11;
                    campaignTargetSet.SalesTargetProfit12 = campTrgtPrintResultWork.SalesTargetProfit12;
                    campaignTargetSet.MonthlySalesTargetProfit = campTrgtPrintResultWork.MonthlySalesTargetProfit;
                    campaignTargetSet.TermSalesTargetProfit = campTrgtPrintResultWork.TermSalesTargetProfit;

                    campaignTargetSet.SalesTargetCount1 = campTrgtPrintResultWork.SalesTargetCount1;
                    campaignTargetSet.SalesTargetCount2 = campTrgtPrintResultWork.SalesTargetCount2;
                    campaignTargetSet.SalesTargetCount3 = campTrgtPrintResultWork.SalesTargetCount3;
                    campaignTargetSet.SalesTargetCount4 = campTrgtPrintResultWork.SalesTargetCount4;
                    campaignTargetSet.SalesTargetCount5 = campTrgtPrintResultWork.SalesTargetCount5;
                    campaignTargetSet.SalesTargetCount6 = campTrgtPrintResultWork.SalesTargetCount6;
                    campaignTargetSet.SalesTargetCount7 = campTrgtPrintResultWork.SalesTargetCount7;
                    campaignTargetSet.SalesTargetCount8 = campTrgtPrintResultWork.SalesTargetCount8;
                    campaignTargetSet.SalesTargetCount9 = campTrgtPrintResultWork.SalesTargetCount9;
                    campaignTargetSet.SalesTargetCount10 = campTrgtPrintResultWork.SalesTargetCount10;
                    campaignTargetSet.SalesTargetCount11 = campTrgtPrintResultWork.SalesTargetCount11;
                    campaignTargetSet.SalesTargetCount12 = campTrgtPrintResultWork.SalesTargetCount12;
                    campaignTargetSet.MonthlySalesTargetCount = campTrgtPrintResultWork.MonthlySalesTargetCount;
                    campaignTargetSet.TermSalesTargetCount = campTrgtPrintResultWork.TermSalesTargetCount;

                    campaignTargetSet.ApplyStaDate = campTrgtPrintResultWork.ApplyStaDate;
                    campaignTargetSet.ApplyEndDate = campTrgtPrintResultWork.ApplyEndDate;
                    retList.Add(campaignTargetSet);
                }

            }

        }

        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(CampTrgtPrintResultWork campTrgtPrintResultWork, CampaignTargetPrintWork campaignTargetPrintWork)
        {
            int status = 0;

            string upDateTime = campTrgtPrintResultWork.UpdateDateTime.Year.ToString("0000") +
                                campTrgtPrintResultWork.UpdateDateTime.Month.ToString("00") +
                                campTrgtPrintResultWork.UpdateDateTime.Day.ToString("00");

            if (campaignTargetPrintWork.LogicalDeleteCode == 1 &&
                campaignTargetPrintWork.DeleteDateTimeSt != 0 &&
                campaignTargetPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < campaignTargetPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > campaignTargetPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (campaignTargetPrintWork.LogicalDeleteCode == 1 &&
                        campaignTargetPrintWork.DeleteDateTimeSt != 0 &&
                        campaignTargetPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < campaignTargetPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (campaignTargetPrintWork.LogicalDeleteCode == 1 &&
                   campaignTargetPrintWork.DeleteDateTimeSt == 0 &&
                   campaignTargetPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > campaignTargetPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            return status;
        }

    }
}
