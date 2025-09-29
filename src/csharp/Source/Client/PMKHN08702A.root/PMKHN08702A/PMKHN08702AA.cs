//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���}�X�^���
// �v���O�����T�v   : ���o���ʂ��o�͌��ʃC���[�W�\���E�o�c�e�o�́E������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �� �� ��  2011/04/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using System.Data;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
	/// �L�����y�[���Ǘ��}�X�^�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �L�����y�[���Ǘ��}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : liyp</br>
	/// <br>Date       : 2011/04/25</br>
	/// <br></br>
    /// </remarks>
    public class CampaignMasterAcs
    {
        #region �� Constructor
        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ǘ��}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : liyp</br>
	    /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public CampaignMasterAcs()
        {
            this._iCampaignMasterWorkDB = (ICampaignMasterWorkDB)MediationCampaignMasterWorkDB.GetCampaignMasterWorkDB();
        }

        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^����A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ǘ��}�X�^����A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : liyp</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        static CampaignMasterAcs()
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
        private static PrtOutSet stc_PrtOutSet;			                // ���[�o�͐ݒ�f�[�^�N���X
        private static PrtOutSetAcs stc_PrtOutSetAcs;	                // ���[�o�͐ݒ�A�N�Z�X�N���X
        private static SecInfoAcs stc_SecInfoAcs;                       // ���_�A�N�Z�X�N���X
        private static Dictionary<string, SecInfoSet> stc_SectionDic;   // ���_Dictionary
        #endregion �� Static Member

        #region �� Private Member
        ICampaignMasterWorkDB _iCampaignMasterWorkDB;
        #endregion �� Private Member

        #region Public Method

        #region �� ���[�ݒ�f�[�^�擾
        #region �� ���[�o�͐ݒ�擾����
        /// <summary>
        /// ���[�o�͐ݒ�Ǎ�
        /// </summary>
        /// <param name="retPrtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����_�̒��[�o�͐ݒ�̓Ǎ����s���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/25</br>
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
        #endregion �� ���[�o�͐ݒ�擾����
        #endregion �� ���[�ݒ�f�[�^�擾

        /// <summary>
		/// �L�����y�[���Ǘ��}�X�^�S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �L�����y�[���Ǘ��}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : liyp</br>
        /// <br>Date       : 2011/04/25</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, CampaignMasterPrintWork campaignMasterPrintWork)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, campaignMasterPrintWork);
        }

        /// <summary>
        /// ���i�}�X�^���������i�_���폜�j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ǘ��}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : liyp</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int SearchDelete(out ArrayList retList, string enterpriseCode, CampaignMasterPrintWork campaignMasterPrintWork)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData1, 0, campaignMasterPrintWork);
        }

        #endregion

        #region private method

        /// <summary>
		/// �L�����y�[���Ǘ��}�X�^��������
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
		/// <br>Note       : �L�����y�[���Ǘ��}�X�^�̌����������s���܂��B</br>
		/// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, CampaignMasterPrintWork campaignMasterPrintWork)
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
                CampaignMasterPrtWork campaignMasterPrtWork = new CampaignMasterPrtWork();
                // ���o�����W�J  --------------------------------------------------------------
                status = this.SearchParaSet(campaignMasterPrintWork, out campaignMasterPrtWork);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retReatList = new object();
                if (campaignMasterPrintWork.PrintType == 6)
                {
                    status = this._iCampaignMasterWorkDB.SearchForMasterType(ref retReatList, campaignMasterPrtWork, 0, logicalMode);
                }
                else
                {
                    status = this._iCampaignMasterWorkDB.Search(ref retReatList, campaignMasterPrtWork, 0, logicalMode);
                }
                
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        if (((ArrayList)retReatList).Count == 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            break;
                        }

                        // �f�[�^�W�J����
                        DevReatData(campaignMasterPrintWork, (ArrayList)retReatList, out retList);

                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
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

        #region �� ���o�����W�J����
        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="inventSearchCndtnUI">UI���o�����N���X</param>
        /// <param name="inventInputSearchCndtnWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <br>Update Note : liyp 2011/01/11</br>
        /// <br>              �o�͏����ɐ��ʂƒI�ԂɊւ�������w���ǉ�����i�v�]�j</br>
        private int SearchParaSet(CampaignMasterPrintWork campaignMasterPrintWork, out CampaignMasterPrtWork campaignMasterPrtWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            campaignMasterPrtWork = new CampaignMasterPrtWork();

            try
            {
                // ��ƃR�[�h
                campaignMasterPrtWork.EnterpriseCode = campaignMasterPrintWork.EnterpriseCode;
                // ���s�^�C�v
                campaignMasterPrtWork.PrintType = campaignMasterPrintWork.PrintType;
                // �J�n�L�����y�[���R�[�h
                campaignMasterPrtWork.CampaignCodeSt = campaignMasterPrintWork.CampaignCodeSt;
                // �I���L�����y�[���R�[�h
                campaignMasterPrtWork.CampaignCodeEd = campaignMasterPrintWork.CampaignCodeEd;
                // �J�n���_
                campaignMasterPrtWork.SectionCodeSt = campaignMasterPrintWork.SectionCodeSt;
                // �I�����_
                campaignMasterPrtWork.SectionCodeEd = campaignMasterPrintWork.SectionCodeEd;
                // �_���폜�敪
                campaignMasterPrtWork.LogicalDeleteCode = campaignMasterPrintWork.LogicalDeleteCode;
                // �폜���J�n
                campaignMasterPrtWork.DeleteDateTimeSt = campaignMasterPrintWork.DeleteDateTimeSt;
                // �폜���I��
                campaignMasterPrtWork.DeleteDateTimeEd = campaignMasterPrintWork.DeleteDateTimeEd;
                // ���[�J�[�R�[�h�J�n
                campaignMasterPrtWork.GoodsMakerCodeSt = campaignMasterPrintWork.GoodsMakerCodeSt;
                // ���[�J�[�R�[�h�I��
                campaignMasterPrtWork.GoodsMakerCodeEd = campaignMasterPrintWork.GoodsMakerCodeEd;
                // �O���[�v�R�[�h�J�n
                campaignMasterPrtWork.BLGroupCodeSt = campaignMasterPrintWork.BLGroupCodeSt;
                // �O���[�v�R�[�h�I��
                campaignMasterPrtWork.BLGroupCodeEd = campaignMasterPrintWork.BLGroupCodeEd;
                // �a�k�R�[�h�J�n
                campaignMasterPrtWork.BLGoodsCodeSt = campaignMasterPrintWork.BLGoodsCodeSt;
                // �a�k�R�[�h�I��
                campaignMasterPrtWork.BLGoodsCodeEd = campaignMasterPrintWork.BLGoodsCodeEd;
                // �̔��敪�R�[�h�J�n
                campaignMasterPrtWork.SalesCodeSt = campaignMasterPrintWork.SalesCodeSt;
                // �̔��敪�R�[�h�I��
                campaignMasterPrtWork.SalesCodeEd = campaignMasterPrintWork.SalesCodeEd;
                // �i�ԊJ�n
                campaignMasterPrtWork.GoodsNoSt = campaignMasterPrintWork.GoodsNoSt;
                // �i�ԏI��
                campaignMasterPrtWork.GoodsNoEd = campaignMasterPrintWork.GoodsNoEd;
                // �������w��敪
                campaignMasterPrtWork.DiscountRateDiv = campaignMasterPrintWork.DiscountRateDiv;
                // ������
                campaignMasterPrtWork.DiscountRate = campaignMasterPrintWork.DiscountRate;
                // �������w��敪
                campaignMasterPrtWork.RateValDiv = campaignMasterPrintWork.RateValDiv;
                // ������
                campaignMasterPrtWork.RateVal = campaignMasterPrintWork.RateVal;
                // �����z�w��敪
                campaignMasterPrtWork.PriceFlDiv = campaignMasterPrintWork.PriceFlDiv;
                // �����z
                campaignMasterPrtWork.PriceFl = campaignMasterPrintWork.PriceFl;
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region �� �擾�f�[�^�W�J����
        /// <summary>
        /// �擾�f�[�^�W�J����
        /// </summary>
        /// <param name="salesTargetPrintWork">UI���o�����N���X</param>
        /// <param name="retaWork">�擾�f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �擾�f�[�^��W�J����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void DevReatData(CampaignMasterPrintWork campaignMasterPrintWork, ArrayList retaWork, out ArrayList retList)
        {
            retList = new ArrayList();

            foreach (CampaignMasterWork cmpaignMasterWork in retaWork)
            {
                if (DataCheck(cmpaignMasterWork, campaignMasterPrintWork) == 0)
                {
                    CampaignMaster campaignMaster = new CampaignMaster();
                    campaignMaster.CreateDateTime = cmpaignMasterWork.CreateDateTime;
                    campaignMaster.UpdateDateTime = cmpaignMasterWork.UpdateDateTime;
                    campaignMaster.CampaignCode = cmpaignMasterWork.CampaignCode;       // �L�����y�[���R�[�h
                    campaignMaster.CampaignName = cmpaignMasterWork.CampaignName;       // �L�����y�[���R�[�h����
                    campaignMaster.CampaignObjDiv = cmpaignMasterWork.CampaignObjDiv;   // �L�����y�[���Ώۋ敪
                    campaignMaster.ApplyStaDate = cmpaignMasterWork.ApplyStaDate;       // �K�p�J�n��
                    campaignMaster.ApplyEndDate = cmpaignMasterWork.ApplyEndDate;       // �K�p�I����
                    campaignMaster.SectionCode = cmpaignMasterWork.SectionCode;         // �L�����y�[�����{���_
                    campaignMaster.SectionGuideSnm = cmpaignMasterWork.SectionGuideSnm; // ���_����
                    campaignMaster.CustomerCode = cmpaignMasterWork.CustomerCode;       // ���Ӑ�R�[�h
                    campaignMaster.CustomerSnm = cmpaignMasterWork.CustomerSnm;         // ���Ӑ旪��
                    campaignMaster.BLGoodsCode = cmpaignMasterWork.BLGoodsCode;         // BL���i�R�[�h
                    campaignMaster.GoodsMakerCd = cmpaignMasterWork.GoodsMakerCd;       // ���i���[�J�[�R�[�h
                    campaignMaster.GoodsNo = cmpaignMasterWork.GoodsNo;                 // ���i�ԍ�
                    campaignMaster.BLGroupCode = cmpaignMasterWork.BLGroupCode;         // BL�O���[�v�R�[�h
                    campaignMaster.SalesCode = cmpaignMasterWork.SalesCode;             // �̔��敪�R�[�h
                    campaignMaster.SalesPriceSetDiv = cmpaignMasterWork.SalesPriceSetDiv; // �����ݒ�敪
                    campaignMaster.PriceFl = cmpaignMasterWork.PriceFl;                 // ���i�i�����j
                    campaignMaster.RateVal = cmpaignMasterWork.RateVal;                 // �|��
                    campaignMaster.DiscountRate = cmpaignMasterWork.DiscountRate;       // ������
                    campaignMaster.PriceStartDate = cmpaignMasterWork.PriceStartDate;   // ���i�J�n��
                    campaignMaster.PriceEndDate = cmpaignMasterWork.PriceEndDate;       // ���i�I����
                    campaignMaster.BLGoodsHalfName = cmpaignMasterWork.BLGoodsHalfName; // �a�k�R�[�h���́i���p�j
                    campaignMaster.MakerName = cmpaignMasterWork.MakerName;             // ���[�J�[����
                    campaignMaster.GoodsName = cmpaignMasterWork.GoodsName;             // ���i����
                    campaignMaster.BLGroupName = cmpaignMasterWork.BLGroupName;         // �O���[�v�R�[�h����
                    campaignMaster.GuideName = cmpaignMasterWork.GuideName;             // �K�C�h����
                    
                    retList.Add(campaignMaster);
                }
            }

        }

        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="cmpaignMasterWork"></param>
        /// <param name="campaignMasterPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(CampaignMasterWork cmpaignMasterWork, CampaignMasterPrintWork campaignMasterPrintWork)
        {
            int status = 0;

            string upDateTime = cmpaignMasterWork.UpdateDateTime.Year.ToString("0000") +
                                cmpaignMasterWork.UpdateDateTime.Month.ToString("00") +
                                cmpaignMasterWork.UpdateDateTime.Day.ToString("00");

            if (campaignMasterPrintWork.LogicalDeleteCode == 1 &&
                campaignMasterPrintWork.DeleteDateTimeSt != 0 &&
                campaignMasterPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < campaignMasterPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > campaignMasterPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (campaignMasterPrintWork.LogicalDeleteCode == 1 &&
                        campaignMasterPrintWork.DeleteDateTimeSt != 0 &&
                        campaignMasterPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < campaignMasterPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (campaignMasterPrintWork.LogicalDeleteCode == 1 &&
                  campaignMasterPrintWork.DeleteDateTimeSt == 0 &&
                  campaignMasterPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > campaignMasterPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            return status;
        }

        #endregion

        #endregion
    }
}