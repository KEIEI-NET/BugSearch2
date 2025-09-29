//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����M�������O�Q�ƃ����e��ʃA�N�Z�X�N���X
// �v���O�����T�v   : ����M�������O�Q�ƃ����e��ʃA�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2012/07/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ������
// �C �� ��  2012/10/08  �C�����e : ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ������
// �C �� ��  2012/10/16  �C�����e : ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ����M�������O�Q�ƃ����e��ʃA�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����M�������O�Q�ƃ����e��ʃA�N�Z�X�N���X</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2012/07/25</br>
    /// <br>Update Note: 2012/10/08 ������</br>
    ///	<br>			 Redmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
    /// <br>Update Note: 2012/10/16 ������</br>
    ///	<br>			 Redmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
    /// </remarks>
    public partial class SndRcvHisLogAcs
    {
        #region �� Const Memebers ��
        private const string MST_SECINFOSET = "���_�ݒ�}�X�^";
        private const string MST_SUBSECTION = "����ݒ�}�X�^";
        private const string MST_WAREHOUSE = "�q�ɐݒ�}�X�^";
        private const string MST_EMPLOYEE = "�]�ƈ��ݒ�}�X�^";
        private const string MST_USERGDAREADIVU = "���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j";
        private const string MST_USERGDBUSDIVU = "���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j";
        private const string MST_USERGDCATEU = "���[�U�[�K�C�h�}�X�^�i�Ǝ�j";
        private const string MST_USERGDBUSU = "���[�U�[�K�C�h�}�X�^�i�E��j";
        private const string MST_USERGDGOODSDIVU = "���[�U�[�K�C�h�}�X�^�i���i�敪�j";
        private const string MST_USERGDCUSGROUPU = "���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j";
        private const string MST_USERGDBANKU = "���[�U�[�K�C�h�}�X�^�i��s�j";
        private const string MST_USERGDPRIDIVU = "���[�U�[�K�C�h�}�X�^�i���i�敪�j";
        private const string MST_USERGDDELIDIVU = "���[�U�[�K�C�h�}�X�^�i�[�i�敪�j";
        private const string MST_USERGDGOODSBIGU = "���[�U�[�K�C�h�}�X�^�i���i�啪�ށj";
        private const string MST_USERGDBUYDIVU = "���[�U�[�K�C�h�}�X�^�i�̔��敪�j";
        private const string MST_USERGDSTOCKDIVOU = "���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j";
        private const string MST_USERGDSTOCKDIVTU = "���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j";
        private const string MST_USERGDRETURNREAU = "���[�U�[�K�C�h�}�X�^�i�ԕi���R�j";
        private const string MST_RATEPROTYMNG = "�|���D��Ǘ��}�X�^";
        private const string MST_RATE = "�|���}�X�^";
        private const string MST_SALESTARGET = "����ڕW�ݒ�}�X�^";
        private const string MST_CUSTOME = "���Ӑ�}�X�^";
        private const string MST_SUPPLIER = "�d����}�X�^";
        private const string MST_JOINPARTSU = "�����}�X�^";
        private const string MST_GOODSSET = "�Z�b�g�}�X�^";
        private const string MST_TBOSEARCHU = "�s�a�n�}�X�^";
        private const string MST_MODELNAMEU = "�Ԏ�}�X�^";
        private const string MST_BLGOODSCDU = "�a�k�R�[�h�}�X�^";
        private const string MST_MAKERU = "���[�J�[�}�X�^";
        private const string MST_GOODSMGROUPU = "���i�����ރ}�X�^";
        private const string MST_BLGROUPU = "�O���[�v�R�[�h�}�X�^";
        private const string MST_BLCODEGUIDE = "BL�R�[�h�K�C�h�}�X�^";
        private const string MST_GOODSU = "���i�}�X�^";
        private const string MST_STOCK = "�݌Ƀ}�X�^";
        private const string MST_PARTSSUBSTU = "��փ}�X�^";
        private const string MST_PARTSPOSCODEU = "���ʃ}�X�^";

        private const string MST_ID_SECINFOSET = "SecInfoSetRF";
        private const string MST_ID_SUBSECTION = "SubSectionRF";
        private const string MST_ID_WAREHOUSE = "WarehouseRF";
        //private const string MST_ID_EMPLOYEE = "EmployeeDtlRF";//DEL 2012/10/08 ������ for redmine#31026 
        private const string MST_ID_EMPLOYEE = "EmployeeRF";//ADD 2012/10/08 ������ for redmine#31026
        private const string MST_ID_EMPLOYEEDTL = "EmployeeDtlRF";
        private const string MST_ID_USERGDU = "UserGdBdURF";
        private const string MST_ID_RATEPROTYMNG = "RateProtyMngRF";
        private const string MST_ID_RATE = "RateRF";
        private const string MST_ID_CUSTSALESTARGET = "CustSalesTargetRF";
        private const string MST_ID_EMPSALESTARGET = "EmpSalesTargetRF";
        private const string MST_ID_GCDSALESTARGET = "GcdSalesTargetRF";
        private const string MST_ID_CUSTOMECHA = "CustomerChangeRF";
        private const string MST_ID_CUSTOME = "CustomerRF";
        private const string MST_ID_CUSTOMEGROUP = "CustRateGroupRF";
        private const string MST_ID_CUSTOMESLIPMNG = "CustSlipMngRF";
        private const string MST_ID_CUSTOMESLIPNO = "CustSlipNoSetRF";
        private const string MST_ID_SUPPLIER = "SupplierRF";
        private const string MST_ID_JOINPARTSU = "JoinPartsURF";
        private const string MST_ID_GOODSSET = "GoodsSetRF";
        private const string MST_ID_TBOSEARCHU = "TBOSearchURF";
        private const string MST_ID_MODELNAMEU = "ModelNameURF";
        private const string MST_ID_BLGOODSCDU = "BLGoodsCdURF";
        private const string MST_ID_MAKERU = "MakerURF";
        private const string MST_ID_GOODSMGROUPU = "GoodsMGroupURF";
        private const string MST_ID_BLGROUPU = "BLGroupURF";
        private const string MST_ID_BLCODEGUIDE = "BLCodeGuideRF";
        private const string MST_ID_GOODSUMNG = "GoodsMngRF";
        private const string MST_ID_GOODSUPRI = "GoodsPriceURF";
        private const string MST_ID_GOODSU = "GoodsURF";
        private const string MST_ID_GOODSUISO = "IsolIslandPrcRF";
        private const string MST_ID_STOCK = "StockRF";
        private const string MST_ID_PARTSSUBSTU = "PartsSubstURF";
        private const string MST_ID_PARTSPOSCODEU = "PartsPosCodeURF";

        private const string FILEID_CUSTOMER = "CustomerRF";
        private const string FILEID_GOODS = "GoodsURF";
        private const string FILEID_STOCK = "StockRF";
        private const string FILEID_SUPPLIER = "SupplierRF";
        private const string FILEID_RATE = "RateRF";
        #endregion �� Const Memebers ��

        # region �� Constructor ��

        /// <summary>
        ///  ����M�������O�Q�ƃ����e��ʃA�N�Z�X�N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�t�H���g�R���X�g���N�^</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        public SndRcvHisLogAcs()
        {

        }
        #endregion �� Constructor ��

        # region �� Private Members ��

        private static SndRcvHisLogAcs _sndRcvHisLogAcs;
        private IDCControlDB IDCControlDB = null;
        private IMstDCControlDB IMstDCControlDB = null;
        private ISndRcvHisTableDB ISndRcvHisTableDB = null;
        # endregion �� Private Members ��

        #region �� Public Method ��
        /// <summary>
        /// ����M�������O�߂�f�[�^���LIST��߂��܂�
        /// </summary>
        /// <param name="sndRcvHisConWork">����M�������O�f�[�^���[�N</param>
        /// <param name="searchResult">���LIST</param>
        /// <param name="searchEtrResult">���o�����ڍ׏��LIST</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����M�������O�߂�f�[�^���LIST��߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/25</br>
        public int Search(SndRcvHisConWork sndRcvHisConWork, out object searchResult, out object searchEtrResult)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            searchResult = new object();
            searchEtrResult = new object();

            try
            {
                if (ISndRcvHisTableDB == null)
                {
                    ISndRcvHisTableDB = (ISndRcvHisTableDB)MediationSndRcvHisTableDB.GetSndRcvHisTableDB();
                }

                status = ISndRcvHisTableDB.Search(sndRcvHisConWork, out searchResult, out searchEtrResult);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ����M�������O�f�[�^�𕨗��폜���܂�
        /// </summary>
        /// <param name="sndRcvHisTableWorkList">�폜���鑗��M�������O�f�[�^���܂�ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����M�������O�f�[�^�𕨗��폜���܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/25</br>
        public int Delete(ref object sndRcvHisTableWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                if (ISndRcvHisTableDB == null)
                {
                    ISndRcvHisTableDB = (ISndRcvHisTableDB)MediationSndRcvHisTableDB.GetSndRcvHisTableDB();
                }

                status = ISndRcvHisTableDB.Delete(ref sndRcvHisTableWorkList);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ����M�������O�߂�f�[�^���LIST�Ď�M
        /// </summary>
        /// <param name="records">����M�������O�f�[�^���LIST</param>
        /// <param name="searchEtrResultObj">����M�������O�ڍ׏��LIST</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����M�������O�߂�f�[�^���LIST��߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/25</br>
        /// <br>Update Note: 2012/10/16 ������</br>
        ///	<br>			 Redmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
        public int ReceiveAgain(object records, object searchEtrResultObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ArrayList list = records as ArrayList;
            ArrayList masterDivList = null;
            ArrayList condParamList = null;
            DCReceiveDataWork parareceiveWork = null;
            object receiveList = null;

            try
            {
                foreach (SndRcvHisTableWork sndRcvHisTableWork in list)
                {
                    // ���0:�f�[�^
                    if (sndRcvHisTableWork.Kind == 0)
                    {
                        receiveList = new object();

                        string[] fileIds = sndRcvHisTableWork.SndRcvFileID.Split(',');

                        parareceiveWork = new DCReceiveDataWork();
                        // ��ƃR�[�h
                        parareceiveWork.PmEnterpriseCode = sndRcvHisTableWork.EnterpriseCode;

                        // ����M���O���o�����敪1:�`�[���t
                        if (sndRcvHisTableWork.SndLogExtraCondDiv == 1)
                        {
                            parareceiveWork.StartDateTime =
                            Convert.ToInt32(new DateTime(sndRcvHisTableWork.SndObjStartDate).ToString("yyyyMMdd"));
                            parareceiveWork.EndDateTime = Convert.ToInt32(new DateTime(sndRcvHisTableWork.SndObjEndDate).ToString("yyyyMMdd"));

                            parareceiveWork.EndDateTimeTicks = sndRcvHisTableWork.SndObjEndDate;
                        }
                        else
                        {
                            parareceiveWork.StartDateTime = sndRcvHisTableWork.SndObjStartDate;
                            parareceiveWork.EndDateTime = sndRcvHisTableWork.SndObjEndDate;
                        }
                        // ���
                        parareceiveWork.Kind = sndRcvHisTableWork.Kind;
                        // �V���N���s���t
                        parareceiveWork.SyncExecDate = sndRcvHisTableWork.SyncExecDate;
                        // ���_�R�[�h
                        parareceiveWork.PmSectionCode = sndRcvHisTableWork.SectionCode;
                        // ����M�������O���M�ԍ�
                        parareceiveWork.SndRcvHisConsNo = sndRcvHisTableWork.SndRcvHisConsNo;
                        // ����M���O���o�����敪
                        parareceiveWork.SndLogExtraCondDiv = sndRcvHisTableWork.SndLogExtraCondDiv;
                        // ���M���ƃR�[�h
                        parareceiveWork.SendDestEpCode = sndRcvHisTableWork.SendDestEpCode;
                        // ���M�拒�_�R�[�h
                        parareceiveWork.SendDestSecCode = sndRcvHisTableWork.SendDestSecCode;
                        // ����M�敪:����M
                        parareceiveWork.TempReceiveDiv = 2;
                        //����M�t�@�C���h�c
                        parareceiveWork.SndRcvFileID = sndRcvHisTableWork.SndRcvFileID;

                        if (IDCControlDB == null)
                        {
                            IDCControlDB = (IDCControlDB)MediationDCControlDB.GetDCControlDB();
                        }

                        status = IDCControlDB.SearchSCM(out receiveList, parareceiveWork, sndRcvHisTableWork.SectionCode, fileIds);

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }
                    }
                    // ���1:�}�X�^
                    else if (sndRcvHisTableWork.Kind == 1)
                    {
                        masterDivList = new ArrayList();
                        condParamList = new ArrayList();

                        string[] fileIds = sndRcvHisTableWork.SndRcvFileID.Split(',');
                        string tempUserGuideDivCd = null;
                        DCSecMngSndRcvWork secMngSndRcvWork = null;

                        for (int i = 0; i < fileIds.Length; i++)
                        {
                            secMngSndRcvWork = new DCSecMngSndRcvWork();
                            // ��ƃR�[�h
                            //secMngSndRcvWork.EnterpriseCode = sndRcvHisTableWork.EnterpriseCode;//DEL 2012/10/16 ������ for redmine#31026
                            secMngSndRcvWork.EnterpriseCode = sndRcvHisTableWork.SendDestEpCode;//ADD 2012/10/16 ������ for redmine#31026
                            // ���_�R�[�h
                            secMngSndRcvWork.SectionCode = sndRcvHisTableWork.SectionCode;
                            // ����M�������O���M�ԍ�
                            secMngSndRcvWork.SndRcvHisConsNo = sndRcvHisTableWork.SndRcvHisConsNo;
                            // ����M���O���o�����敪
                            secMngSndRcvWork.SndLogExtraCondDiv = sndRcvHisTableWork.SndLogExtraCondDiv;
                            // ���M���ƃR�[�h
                            secMngSndRcvWork.SendDestEpCode = sndRcvHisTableWork.SendDestEpCode;
                            // ���M�拒�_�R�[�h
                            secMngSndRcvWork.SendDestSecCode = sndRcvHisTableWork.SendDestSecCode;
                            // ����M�敪:����M
                            secMngSndRcvWork.TempReceiveDiv = 2;
                            // ����M�t�@�C���h�c
                            secMngSndRcvWork.SndRcvFileID = fileIds[i];
                            // ����M�t�@�C���h�c
                            secMngSndRcvWork.FileId = fileIds[i];
                            // �}�X�^����
                            if (secMngSndRcvWork.SndRcvFileID.Length >= 11 && MST_ID_USERGDU.Equals(secMngSndRcvWork.SndRcvFileID.Substring(0, 11)))
                            {
                                tempUserGuideDivCd = secMngSndRcvWork.SndRcvFileID.Substring(11);

                                // ����M�t�@�C���h�c
                                secMngSndRcvWork.FileId = MST_ID_USERGDU;

                                // ���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j
                                if (tempUserGuideDivCd.Equals("21"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDAREADIVU;
                                }
                                // ���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j
                                else if (tempUserGuideDivCd.Equals("31"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDBUSDIVU;
                                }
                                // ���[�U�[�K�C�h�}�X�^�i�Ǝ�j
                                else if (tempUserGuideDivCd.Equals("33"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDCATEU;
                                }
                                // ���[�U�[�K�C�h�}�X�^�i�E��j
                                else if (tempUserGuideDivCd.Equals("34"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDBUSU;
                                }
                                // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                                else if (tempUserGuideDivCd.Equals("41"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDGOODSDIVU;
                                }
                                // ���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j
                                else if (tempUserGuideDivCd.Equals("43"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDCUSGROUPU;
                                }
                                // ���[�U�[�K�C�h�}�X�^�i��s�j
                                else if (tempUserGuideDivCd.Equals("46"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDBANKU;
                                }
                                // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                                else if (tempUserGuideDivCd.Equals("47"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDPRIDIVU;
                                }
                                // ���[�U�[�K�C�h�}�X�^�i�[�i�敪�j
                                else if (tempUserGuideDivCd.Equals("48"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDDELIDIVU;
                                }
                                // ���[�U�[�K�C�h�}�X�^�i���i�啪�ށj
                                else if (tempUserGuideDivCd.Equals("70"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDGOODSBIGU;
                                }
                                // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j
                                else if (tempUserGuideDivCd.Equals("71"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDBUYDIVU;
                                }
                                // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j
                                else if (tempUserGuideDivCd.Equals("72"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDSTOCKDIVOU;
                                }
                                // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j
                                else if (tempUserGuideDivCd.Equals("73"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDSTOCKDIVTU;
                                }
                                // ���[�U�[�K�C�h�}�X�^�i�ԕi���R�j
                                else if (tempUserGuideDivCd.Equals("91"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDRETURNREAU;
                                }
                            }
                            else
                            {
                                secMngSndRcvWork.MasterName = GetFileIdName(secMngSndRcvWork.SndRcvFileID);
                            }
                            // ���_�Ǘ���M�敪
                            secMngSndRcvWork.SecMngRecvDiv = 1;

                            masterDivList.Add(secMngSndRcvWork);
                        }

                        // ����M���O���o�����敪1:�蓮(����)
                        if (sndRcvHisTableWork.SndLogExtraCondDiv == 1)
                        {
                            ArrayList searchEtrResultList = searchEtrResultObj as ArrayList;
                            int sndRcvHisConsNo = sndRcvHisTableWork.SndRcvHisConsNo;  // ����M�������O���M�ԍ�
                            string sectionCode = sndRcvHisTableWork.SectionCode;       //���_�R�[�h
                            string enterpriseCode = sndRcvHisTableWork.EnterpriseCode; //��ƃR�[�h

                            foreach (SndRcvEtrWork work in searchEtrResultList)
                            {
                                if (work.SndRcvHisConsNo == sndRcvHisConsNo && work.EnterpriseCode.Trim().Equals(enterpriseCode.Trim()) && work.SectionCode.Trim().Equals(sectionCode.Trim()))
                                {
                                    //���Ӑ�}�X�^
                                    if (work.FileId.Equals(FILEID_CUSTOMER))
                                    {
                                        CustomerProcParamWork customerProcParamWork = SndRcvEtrWorkToCustomerProcParamWork(work);
                                        customerProcParamWork.UpdateDateTimeBegin = sndRcvHisTableWork.SndObjStartDate;
                                        customerProcParamWork.UpdateDateTimeEnd = sndRcvHisTableWork.SndObjEndDate;
                                        condParamList.Add(customerProcParamWork);
                                    }
                                    //���i�}�X�^
                                    else if (work.FileId.Equals(FILEID_GOODS))
                                    {
                                        GoodsProcParamWork goodsProcParamWork = SndRcvEtrWorkToGoodsProcParamWork(work);
                                        goodsProcParamWork.UpdateDateTimeBegin = sndRcvHisTableWork.SndObjStartDate;
                                        goodsProcParamWork.UpdateDateTimeEnd = sndRcvHisTableWork.SndObjEndDate;
                                        condParamList.Add(goodsProcParamWork);
                                    }
                                    //�݌Ƀ}�X�^
                                    else if (work.FileId.Equals(FILEID_STOCK))
                                    {
                                        StockProcParamWork stockProcParamWork = SndRcvEtrWorkToStockProcParamWork(work);
                                        stockProcParamWork.UpdateDateTimeBegin = sndRcvHisTableWork.SndObjStartDate;
                                        stockProcParamWork.UpdateDateTimeEnd = sndRcvHisTableWork.SndObjEndDate;
                                        condParamList.Add(stockProcParamWork);
                                    }
                                    //�d����}�X�^
                                    else if (work.FileId.Equals(FILEID_SUPPLIER))
                                    {
                                        SupplierProcParamWork supplierProcParamWork = SndRcvEtrWorkToSupplierProcParamWork(work);
                                        supplierProcParamWork.UpdateDateTimeBegin = sndRcvHisTableWork.SndObjStartDate;
                                        supplierProcParamWork.UpdateDateTimeEnd = sndRcvHisTableWork.SndObjEndDate;
                                        condParamList.Add(supplierProcParamWork);
                                    }
                                    //�|���}�X�^
                                    else if (work.FileId.Equals(FILEID_RATE))
                                    {
                                        RateProcParamWork rateProcParamWork = SndRcvEtrWorkToRateProcParamWork(work);
                                        rateProcParamWork.UpdateDateTimeBegin = sndRcvHisTableWork.SndObjStartDate;
                                        rateProcParamWork.UpdateDateTimeEnd = sndRcvHisTableWork.SndObjEndDate;
                                        condParamList.Add(rateProcParamWork);
                                    }

                                }
                            }
                        }

                        CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();
                        string retMessage = null;

                        if (IMstDCControlDB == null)
                        {
                            IMstDCControlDB = (IMstDCControlDB)MediationMstDCControlDB.GetMstDCControlDB();
                        }

                        // ����M���O���o�����敪0:����(����)
                        if (sndRcvHisTableWork.SndLogExtraCondDiv == 0)
                        {
                            //status = IMstDCControlDB.SearchCustomSerializeArrayList(masterDivList, sndRcvHisTableWork.SendDestEpCode, sndRcvHisTableWork.SndObjStartDate, sndRcvHisTableWork.SndObjEndDate, ref retCSAList, out retMessage);//DEL 2012/10/16 ������ for redmine#31026
                            status = IMstDCControlDB.SearchCustomSerializeArrayList(masterDivList, sndRcvHisTableWork.EnterpriseCode, sndRcvHisTableWork.SndObjStartDate, sndRcvHisTableWork.SndObjEndDate, ref retCSAList, out retMessage);//ADD 2012/10/16 ������ for redmine#31026
                        }
                        // ����M���O���o�����敪1:�蓮(����)
                        else
                        {
                            //status = IMstDCControlDB.SearchCustomSerializeArrayList(masterDivList, sndRcvHisTableWork.SendDestEpCode, condParamList, ref retCSAList, out retMessage);//DEL 2012/10/16 ������ for redmine#31026
                            status = IMstDCControlDB.SearchCustomSerializeArrayList(masterDivList, sndRcvHisTableWork.EnterpriseCode, condParamList, ref retCSAList, out retMessage);//ADD 2012/10/16 ������ for redmine#31026
                        }

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }

                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
        ///// <summary>
        ///// ���_�����擾
        ///// </summary>
        ///// <param name="sectionCode"></param>
        ///// <returns></returns>
        //public string GetSetctionName(string sectionCode)
        //{
        //    string sectionName = null;

        //    SecInfoAcs secInfoAcs = new SecInfoAcs();
        //    try
        //    {
        //        foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
        //        {
        //            if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
        //            {
        //                sectionName = secInfoSet.SectionGuideNm.Trim();
        //                break;
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        sectionName = string.Empty;
        //    }

        //    return sectionName;
        //}
        // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<

        /// <summary>
        /// ����M�������O�Q�� �C���X�^���X�擾����
        /// </summary>
        /// <returns>����M�������O�Q�� �C���X�^���X</returns>
        public static SndRcvHisLogAcs GetInstance()
        {
            if (_sndRcvHisLogAcs == null)
            {
                _sndRcvHisLogAcs = new SndRcvHisLogAcs();
            }

            return _sndRcvHisLogAcs;
        }
        /// <summary>
        /// DateTime�̓�����String�ɂ���
        /// </summary>
        /// <param name="dateTime">DateTime�̓���</param>
        /// <returns>String�̓���</returns>
        /// <remarks>
        /// <br>Note       : DateTime�̓�����String�ɂ���</br>
        /// <br>Programmer : ������ </br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        public string DateTimeFormatToString(DateTime dateTime)
        {
            string time = null;
            time += dateTime.Year + "�N";
            time += Convert.ToString(dateTime.Month).PadLeft(2, '0') + "��";
            time += Convert.ToString(dateTime.Day).PadLeft(2, '0') + "��";
            time += Convert.ToString(dateTime.Hour).PadLeft(2, '0') + "��";
            time += Convert.ToString(dateTime.Minute).PadLeft(2, '0') + "��";
            time += Convert.ToString(dateTime.Second).PadLeft(2, '0') + "�b";

            return time;
        }
        #endregion �� Public Method ��

        #region �� Private Method ��

        /// <summary>
        /// ���Ӑ�}�X�^���o����
        /// </summary>
        /// <param name="sndRcvEtrWork">����M���o�����������O�f�[�^</param>
        /// <returns>���Ӑ�}�X�^���[�N</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^���o�������擾����</br>
        /// <br>Programmer : ������ </br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private CustomerProcParamWork SndRcvEtrWorkToCustomerProcParamWork(SndRcvEtrWork sndRcvEtrWork)
        {
            CustomerProcParamWork customerProcParam = new CustomerProcParamWork();

            customerProcParam.CustomerCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond1);
            customerProcParam.CustomerCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond1);
            customerProcParam.KanaBeginRF = sndRcvEtrWork.StartCond2;
            customerProcParam.KanaEndRF = sndRcvEtrWork.EndCond2;
            customerProcParam.MngSectionCodeBeginRF = sndRcvEtrWork.StartCond3;
            customerProcParam.MngSectionCodeEndRF = sndRcvEtrWork.EndCond3;
            customerProcParam.CustomerAgentCdBeginRF = sndRcvEtrWork.StartCond4;
            customerProcParam.CustomerAgentCdEndRF = sndRcvEtrWork.EndCond4;
            customerProcParam.SalesAreaCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond5);
            customerProcParam.SalesAreaCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond5);
            customerProcParam.BusinessTypeCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond6);
            customerProcParam.BusinessTypeCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond6);

            return customerProcParam;
        }

        /// <summary>
        /// ���i�}�X�^���o����
        /// </summary>
        /// <param name="sndRcvEtrWork">����M���o�����������O�f�[�^</param>
        /// <returns>���i�}�X�^���[�N</returns>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^���o�������擾����</br>
        /// <br>Programmer : ������ </br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private GoodsProcParamWork SndRcvEtrWorkToGoodsProcParamWork(SndRcvEtrWork sndRcvEtrWork)
        {
            GoodsProcParamWork goodsProcParam = new GoodsProcParamWork();

            goodsProcParam.SupplierCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond1);
            goodsProcParam.SupplierCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond1);
            goodsProcParam.GoodsMakerCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond2);
            goodsProcParam.GoodsMakerCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond2);
            goodsProcParam.BLGoodsCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond3);
            goodsProcParam.BLGoodsCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond3);
            goodsProcParam.GoodsNoBeginRF = sndRcvEtrWork.StartCond4;
            goodsProcParam.GoodsNoEndRF = sndRcvEtrWork.EndCond4;

            return goodsProcParam;
        }

        /// <summary>
        /// �݌Ƀ}�X�^���o����
        /// </summary>
        /// <param name="sndRcvEtrWork">����M���o�����������O�f�[�^</param>
        /// <returns>�݌Ƀ}�X�^���[�N</returns>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^���o�������擾����</br>
        /// <br>Programmer : ������ </br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private StockProcParamWork SndRcvEtrWorkToStockProcParamWork(SndRcvEtrWork sndRcvEtrWork)
        {
            StockProcParamWork stockProcParam = new StockProcParamWork();

            stockProcParam.WarehouseCodeBeginRF = sndRcvEtrWork.StartCond1;
            stockProcParam.WarehouseCodeEndRF = sndRcvEtrWork.EndCond1;
            stockProcParam.WarehouseShelfNoBeginRF = sndRcvEtrWork.StartCond2;
            stockProcParam.WarehouseShelfNoEndRF = sndRcvEtrWork.EndCond2;
            stockProcParam.SupplierCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond3);
            stockProcParam.SupplierCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond3);
            stockProcParam.GoodsMakerCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond4);
            stockProcParam.GoodsMakerCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond4);
            stockProcParam.BLGloupCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond5);
            stockProcParam.BLGloupCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond5);
            stockProcParam.GoodsNoBeginRF = sndRcvEtrWork.StartCond6;
            stockProcParam.GoodsNoEndRF = sndRcvEtrWork.EndCond6;

            return stockProcParam;
        }

        /// <summary>
        /// �d����}�X�^���o����
        /// </summary>
        /// <param name="sndRcvEtrWork">����M���o�����������O�f�[�^</param>
        /// <returns>�d����}�X�^���[�N</returns>
        /// <remarks>
        /// <br>Note       : �d����}�X�^���o�������擾����</br>
        /// <br>Programmer : ������ </br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private SupplierProcParamWork SndRcvEtrWorkToSupplierProcParamWork(SndRcvEtrWork sndRcvEtrWork)
        {
            SupplierProcParamWork supplierProcParam = new SupplierProcParamWork();

            supplierProcParam.SupplierCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond1);
            supplierProcParam.SupplierCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond1);

            return supplierProcParam;
        }

        /// <summary>
        /// �|���}�X�^���o����
        /// </summary>
        /// <param name="sndRcvEtrWork">����M���o�����������O�f�[�^</param>
        /// <returns>�|���}�X�^���[�N</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^���o�������擾����</br>
        /// <br>Programmer : ������ </br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private RateProcParamWork SndRcvEtrWorkToRateProcParamWork(SndRcvEtrWork sndRcvEtrWork)
        {
            RateProcParamWork rateProcParam = new RateProcParamWork();

            rateProcParam.UnitPriceKindRF = sndRcvEtrWork.StartCond1;
            rateProcParam.SetFunRF = sndRcvEtrWork.EndCond1;
            rateProcParam.RateSettingDivideRF = sndRcvEtrWork.StartCond2;
            rateProcParam.CustRateGrpCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond3);
            rateProcParam.CustRateGrpCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond3);
            rateProcParam.CustomerCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond4);
            rateProcParam.CustomerCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond4);
            rateProcParam.SupplierCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond5);
            rateProcParam.SupplierCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond5);
            rateProcParam.GoodsMakerCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond6);
            rateProcParam.GoodsMakerCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond6);
            rateProcParam.GoodsRateRankBeginRF = sndRcvEtrWork.StartCond7;
            rateProcParam.GoodsRateRankEndRF = sndRcvEtrWork.EndCond7;
            rateProcParam.GoodsRateGrpCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond8);
            rateProcParam.GoodsRateGrpCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond8);
            rateProcParam.BLGoodsCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond9);
            rateProcParam.BLGoodsCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond9);
            rateProcParam.GoodsNoBeginRF = sndRcvEtrWork.StartCond10;
            rateProcParam.GoodsNoEndRF = sndRcvEtrWork.EndCond10;

            return rateProcParam;
        }

        /// <summary>
        /// �}�X�^�����擾����
        /// </summary>
        /// <param name="fileId">�}�X�^ID</param>
        /// <returns>�}�X�^��</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^�����擾����</br>
        /// <br>Programmer : ������ </br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private string GetFileIdName(string fileId)
        {
            string fileIdName = null;
            // ���Ӑ�}�X�^
            if (MST_ID_CUSTOME.Equals(fileId))
            {
                fileIdName = MST_CUSTOME;
            }
            // ���i�}�X�^�i���[�U�[�o�^���j
            else if (MST_ID_GOODSU.Equals(fileId))
            {
                fileIdName = MST_GOODSU;
            }
            // �݌Ƀ}�X�^
            else if (MST_ID_STOCK.Equals(fileId))
            {
                fileIdName = MST_STOCK;
            }
            // �d����}�X�^
            else if (MST_ID_SUPPLIER.Equals(fileId))
            {
                fileIdName = MST_SUPPLIER;
            }
            // �|���}�X�^
            else if (MST_ID_RATE.Equals(fileId))
            {
                fileIdName = MST_RATE;
            }
            // ���_�ݒ�}�X�^
            else if (MST_ID_SECINFOSET.Equals(fileId))
            {
                fileIdName = MST_SECINFOSET;
            }
            // ����ݒ�}�X�^
            else if (MST_ID_SUBSECTION.Equals(fileId))
            {
                fileIdName = MST_SUBSECTION;
            }
            // �q�ɐݒ�}�X�^
            else if (MST_ID_WAREHOUSE.Equals(fileId))
            {
                fileIdName = MST_WAREHOUSE;
            }
            // �]�ƈ��}�X�^�A�]�ƈ��ڍ׃}�X�^
            else if (MST_ID_EMPLOYEE.Equals(fileId) || MST_ID_EMPLOYEEDTL.Equals(fileId))
            {
                fileIdName = MST_EMPLOYEE;
            }
            // ���Ӑ�}�X�^(�ϓ����)�A���Ӑ�}�X�^�i�`�[�Ǘ��j�A���Ӑ�}�X�^�i�|���O���[�v�j�A���Ӑ�}�X�^(�`�[�ԍ�)
            else if (MST_ID_CUSTOMECHA.Equals(fileId) || MST_ID_CUSTOMESLIPMNG.Equals(fileId) || MST_ID_CUSTOMEGROUP.Equals(fileId) || MST_ID_CUSTOMESLIPNO.Equals(fileId))
            {
                fileIdName = MST_CUSTOME;
            }
            // ���[�J�[�}�X�^�i���[�U�[�o�^���j
            else if (MST_ID_MAKERU.Equals(fileId))
            {
                fileIdName = MST_MAKERU;
            }
            // BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j
            else if (MST_ID_BLGOODSCDU.Equals(fileId))
            {
                fileIdName = MST_BLGOODSCDU;
            }
            // ���i�}�X�^�i���[�U�[�o�^�j�A���i�Ǘ����}�X�^�A�������i�}�X�^
            else if (MST_ID_GOODSUPRI.Equals(fileId) || MST_ID_GOODSUMNG.Equals(fileId) || MST_ID_GOODSUISO.Equals(fileId))
            {
                fileIdName = MST_GOODSU;
            }
            // �|���D��Ǘ��}�X�^
            else if (MST_ID_RATEPROTYMNG.Equals(fileId))
            {
                fileIdName = MST_RATEPROTYMNG;
            }
            // ���i�Z�b�g�}�X�^
            else if (MST_ID_GOODSSET.Equals(fileId))
            {
                fileIdName = MST_GOODSSET;
            }
            // ���i��փ}�X�^�i���[�U�[�o�^���j
            else if (MST_ID_PARTSSUBSTU.Equals(fileId))
            {
                fileIdName = MST_PARTSSUBSTU;
            }
            // �]�ƈ��ʔ���ڕW�ݒ�}�X�^���Ӑ�ʔ���ڕW�ݒ�}�X�^�A���Ӑ�ʔ���ڕW�ݒ�}�X�^�A���i�ʔ���ڕW�ݒ�}�X�^
            else if (MST_ID_EMPSALESTARGET.Equals(fileId) || MST_ID_CUSTSALESTARGET.Equals(fileId) || MST_ID_GCDSALESTARGET.Equals(fileId))
            {
                fileIdName = MST_SALESTARGET;
            }
            // ���i�����ރ}�X�^�i���[�U�[�o�^���j
            else if (MST_ID_GOODSMGROUPU.Equals(fileId))
            {
                fileIdName = MST_GOODSMGROUPU;
            }
            // BL�O���[�v�}�X�^�i���[�U�[�o�^���j
            else if (MST_ID_BLGROUPU.Equals(fileId))
            {
                fileIdName = MST_BLGROUPU;
            }
            // �����}�X�^�i���[�U�[�o�^���j
            else if (MST_ID_JOINPARTSU.Equals(fileId))
            {
                fileIdName = MST_JOINPARTSU;
            }
            // TBO�����}�X�^�i���[�U�[�o�^�j
            else if (MST_ID_TBOSEARCHU.Equals(fileId))
            {
                fileIdName = MST_TBOSEARCHU;
            }
            // ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j
            else if (MST_ID_PARTSPOSCODEU.Equals(fileId))
            {
                fileIdName = MST_PARTSPOSCODEU;
            }
            // BL�R�[�h�K�C�h�}�X�^
            else if (MST_ID_BLCODEGUIDE.Equals(fileId))
            {
                fileIdName = MST_BLCODEGUIDE;
            }
            // �Ԏ햼�̃}�X�^
            else if (MST_ID_MODELNAMEU.Equals(fileId))
            {
                fileIdName = MST_MODELNAMEU;
            }
            return fileIdName;
        }
        #endregion �� Private Method ��
    }
}