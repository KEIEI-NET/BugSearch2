//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PCC���Аݒ�}�X�^�����e
// �v���O�����T�v   : PCC���Аݒ�}�X�^�����e�A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2011.08.04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2013/03/06  �C�����e : 2013/03/06�z�M�@SCM��Q��10342,10343�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2013/09/13  �C�����e : SCM�d�|�ꗗ��10571�Ή� �Q�Ƒq�ɃR�[�h�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070147-00 �쐬�S�� : ���N�n��
// �� �� ��  2014/07/23  �C�����e : SCM�d�|�ꗗ��10659��1���݌ɐ��\���敪�̒ǉ�     
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30746 ���� ��
// �C �� ��  2014/09/04  �C�����e : SCM�d�|�ꗗ��10678�Ή��@�񓚔[���\���敪�ǉ�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using System.Runtime.Remoting;
using System.Collections;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// PCC���Аݒ�}�X�^�����e�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC���Аݒ�}�X�^�����e�t�h�N���X</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date	   : 2011.08.04</br>
    /// </remarks>  
    public class PccCmpnyStAcs
    {
        /// <summary>
        /// �����[�g�I�u�W�F�N�g�C���^�[�t�F�C�X
        /// </summary>
        private IPccCmpnyStDB _IPccCmpnyStDB = null;
        private CustomerInfoAcs _customerInfoAcs;
        //���Ӑ�
        private Hashtable _customerInfoTable;
        private const string CUSTOMEMPTY_BASE = "�x�[�X�ݒ�";
        #region �� Constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : PCC���Аݒ�}�X�^�����e�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public PccCmpnyStAcs()
        {
            _IPccCmpnyStDB = MediationPccCmpnyStDB.GetPccCmpnyStDB();
            _customerInfoAcs = new CustomerInfoAcs();
        }
        #endregion �� Constructor

        /// <summary>
        /// PCC���Аݒ�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="pccCmpnyStList">PCC���Аݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC���Аݒ�}�X�^�����e�o�^�A�X�V�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int Write(ref List<PccCmpnySt> pccCmpnyStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            Object objPccCmpnyStWorkList = null;
            ArrayList pccCmpnyStWorkResultList = null;

            try
            {
                if (pccCmpnyStList != null)
                {
                    this.CopyCmpnyStToWork(out pccCmpnyStWorkResultList, pccCmpnyStList);
                    objPccCmpnyStWorkList = pccCmpnyStWorkResultList as object;
                }

                //PCC���Аݒ�}�X�^�����e�o�^�A�X�V����
                status = _IPccCmpnyStDB.Write(ref objPccCmpnyStWorkList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //���ʂ�߂�
                pccCmpnyStWorkResultList = objPccCmpnyStWorkList as ArrayList;

                if (pccCmpnyStWorkResultList != null)
                {
                    this.CopyWorkToCmpnySt(pccCmpnyStWorkResultList, out pccCmpnyStList);
                }

            }
            catch (RemotingException)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /// <summary>
        /// PCC���Аݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCmpnyStList">PCC���Аݒ�f�[�^���X�g</param>
        /// <param name="parsePccCmpnySt">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC���Аݒ�}�X�^�����e���������B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int Search(out List<PccCmpnySt> pccCmpnyStList, PccCmpnySt parsePccCmpnySt, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            Object objPccCmpnyStWorkList = null;
            ArrayList pccCmpnyStWorkResultList = null;
            PccCmpnyStWork parsePccCmpnyStWork = null;
            pccCmpnyStList = null;
            try
            {
                if (parsePccCmpnySt != null)
                {
                    List<PccCmpnySt> pareCmpnyStWorkList = new List<PccCmpnySt>();
                    pareCmpnyStWorkList.Add(parsePccCmpnySt);
                    ArrayList parsePccCmpnyStWorkList = null;
                    this.CopyCmpnyStToWork(out parsePccCmpnyStWorkList, pareCmpnyStWorkList);
                    parsePccCmpnyStWork = parsePccCmpnyStWorkList[0] as PccCmpnyStWork;
                }
                else
                {
                    return status;
                }
                if (_customerInfoAcs == null)
                {
                    _customerInfoAcs = new CustomerInfoAcs();
                }
                List<CustomerInfo> customerInfoList = null;
                this._customerInfoTable = new Hashtable();
                CustomerInfo customerInfo0 = new CustomerInfo();
                customerInfo0.CustomerCode = 0;
                customerInfo0.CustomerSnm = CUSTOMEMPTY_BASE;
                this._customerInfoTable.Add(customerInfo0.CustomerCode, customerInfo0.CustomerSnm);
                
                status = _customerInfoAcs.Search(parsePccCmpnySt.InqOtherEpCd, true, true, out customerInfoList);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (CustomerInfo customerInfo in customerInfoList)
                    {
                        this._customerInfoTable.Add(customerInfo.CustomerCode, customerInfo.CustomerSnm);
                    }
                }
                //PCC���Аݒ�}�X�^�����e��������
                status = _IPccCmpnyStDB.Search(out objPccCmpnyStWorkList, parsePccCmpnyStWork, readMode, logicalMode);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //���ʂ�߂�
                pccCmpnyStWorkResultList = objPccCmpnyStWorkList as ArrayList;

                if (pccCmpnyStWorkResultList != null)
                {
                    this.CopyWorkToCmpnySt(pccCmpnyStWorkResultList, out pccCmpnyStList);
                }

            }
            catch (RemotingException)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /// <summary>
        /// PCC���Аݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCmpnySt">PCC���Аݒ�f�[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC���Аݒ�}�X�^�����e���������B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int Read(ref PccCmpnySt pccCmpnySt, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            Object objPccCmpnyStWork = null;
            PccCmpnyStWork wkPccCmpnyStWork = null;
            try
            {
                if (pccCmpnySt != null)
                {
                    wkPccCmpnyStWork = new PccCmpnyStWork();
                    //�⍇������ƃR�[�h
                    wkPccCmpnyStWork.InqOriginalEpCd = pccCmpnySt.InqOriginalEpCd.Trim();//@@@@20230303
                    //�⍇�������_�R�[�h
                    wkPccCmpnyStWork.InqOriginalSecCd = pccCmpnySt.InqOriginalSecCd;
                    //�⍇�����ƃR�[�h
                    wkPccCmpnyStWork.InqOtherEpCd = pccCmpnySt.InqOtherEpCd;
                    //�⍇���拒�_�R�[�h
                    wkPccCmpnyStWork.InqOtherSecCd = pccCmpnySt.InqOtherSecCd;
                    //PCC���ЃR�[�h
                    wkPccCmpnyStWork.PccCompanyCode = pccCmpnySt.PccCompanyCode;
                }
                objPccCmpnyStWork = wkPccCmpnyStWork;
                //PCC���Аݒ�}�X�^�����e��������
                status = _IPccCmpnyStDB.Read(ref objPccCmpnyStWork, readMode, logicalMode);


                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //���ʂ�߂�
                wkPccCmpnyStWork = objPccCmpnyStWork as PccCmpnyStWork;
                ArrayList pccCmpnyStWorkList = new ArrayList();
                pccCmpnyStWorkList.Add(wkPccCmpnyStWork);
                List<PccCmpnySt> pccCmpnyStList = null;
                this.CopyWorkToCmpnySt(pccCmpnyStWorkList, out pccCmpnyStList);
                pccCmpnySt = pccCmpnyStList[0];
            }
            catch (RemotingException)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /// <summary>
        /// PCC���Аݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccCmpnyStList">PCC���Аݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC���Аݒ�}�X�^�����e�_���폜�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int LogicalDelete(ref List<PccCmpnySt> pccCmpnyStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            Object objPccCmpnyStWorkList = null;
            ArrayList pccCmpnyStWorkResultList = null;

            try
            {
                if (pccCmpnyStList != null)
                {
                    this.CopyCmpnyStToWork(out pccCmpnyStWorkResultList, pccCmpnyStList);
                    objPccCmpnyStWorkList = pccCmpnyStWorkResultList as object;
                }

                //PCC���Аݒ�}�X�^�����e�o�^�A�X�V����
                status = _IPccCmpnyStDB.LogicalDelete(ref objPccCmpnyStWorkList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //���ʂ�߂�
                pccCmpnyStWorkResultList = objPccCmpnyStWorkList as ArrayList;

                if (pccCmpnyStWorkResultList != null)
                {
                    this.CopyWorkToCmpnySt(pccCmpnyStWorkResultList, out pccCmpnyStList);
                }

            }
            catch (RemotingException)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /// <summary>
        /// PCC���Аݒ�}�X�^�����e�����폜����
        /// </summary>
        /// <param name="pccCmpnyStList">PCC���Аݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC���Аݒ�}�X�^�����e�����폜�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int Delete(ref List<PccCmpnySt> pccCmpnyStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            Object objPccCmpnyStWorkList = null;
            ArrayList pccCmpnyStWorkResultList = null;

            try
            {
                if (pccCmpnyStList != null)
                {
                    this.CopyCmpnyStToWork(out pccCmpnyStWorkResultList, pccCmpnyStList);
                    objPccCmpnyStWorkList = pccCmpnyStWorkResultList as object;
                }

                //PCC���Аݒ�}�X�^�����e�o�^�A�X�V����
                status = _IPccCmpnyStDB.Delete(ref objPccCmpnyStWorkList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //���ʂ�߂�
                pccCmpnyStWorkResultList = objPccCmpnyStWorkList as ArrayList;

                if (pccCmpnyStWorkResultList != null)
                {
                    this.CopyWorkToCmpnySt(pccCmpnyStWorkResultList, out pccCmpnyStList);
                }

            }
            catch (RemotingException)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /// <summary>
        /// PCC���Аݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCmpnyStList">PCC���Аݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC���Аݒ�}�X�^�����e���������B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref List<PccCmpnySt> pccCmpnyStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            Object objPccCmpnyStWorkList = null;
            ArrayList pccCmpnyStWorkResultList = null;

            try
            {
                if (pccCmpnyStList != null)
                {
                    this.CopyCmpnyStToWork(out pccCmpnyStWorkResultList, pccCmpnyStList);
                    objPccCmpnyStWorkList = pccCmpnyStWorkResultList as object;
                }

                //PCC���Аݒ�}�X�^�����e�o�^�A�X�V����
                status = _IPccCmpnyStDB.RevivalLogicalDelete(ref objPccCmpnyStWorkList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //���ʂ�߂�
                pccCmpnyStWorkResultList = objPccCmpnyStWorkList as ArrayList;

                if (pccCmpnyStWorkResultList != null)
                {
                    this.CopyWorkToCmpnySt(pccCmpnyStWorkResultList, out pccCmpnyStList);
                }

            }
            catch (RemotingException)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        #region Private Method
        /// <summary>
        /// PCC���Аݒ�}�X�^�����e�]������
        /// </summary>
        /// <param name="pccCmpnyStWorkList">���Аݒ�O���[�v���[�N���X�g</param>
        /// <param name="pccCmpnyStList">PCC���Аݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�i�ڃO���[�v�}�X�^�����e�]�������B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private void CopyWorkToCmpnySt(ArrayList pccCmpnyStWorkList, out List<PccCmpnySt> pccCmpnyStList)
        {
            pccCmpnyStList = null;
            if (pccCmpnyStWorkList == null || pccCmpnyStWorkList.Count == 0)
            {
                return;
            }
            else
            {
                pccCmpnyStList = new List<PccCmpnySt>();
                foreach (PccCmpnyStWork wkPccCmpnyStWork in pccCmpnyStWorkList)
                {
                    PccCmpnySt pccCmpnySt = new PccCmpnySt();
                    //�쐬����
                    pccCmpnySt.CreateDateTime = wkPccCmpnyStWork.CreateDateTime;
                    //�X�V����
                    pccCmpnySt.UpdateDateTime = wkPccCmpnyStWork.UpdateDateTime;
                    //�_���폜�敪
                    pccCmpnySt.LogicalDeleteCode = wkPccCmpnyStWork.LogicalDeleteCode;
                    //�⍇������ƃR�[�h
                    pccCmpnySt.InqOriginalEpCd = wkPccCmpnyStWork.InqOriginalEpCd.Trim();//@@@@20230303
                    //�⍇�������_�R�[�h
                    pccCmpnySt.InqOriginalSecCd = wkPccCmpnyStWork.InqOriginalSecCd;
                    //�⍇�����ƃR�[�h
                    pccCmpnySt.InqOtherEpCd = wkPccCmpnyStWork.InqOtherEpCd;
                    //�⍇���拒�_�R�[�h
                    pccCmpnySt.InqOtherSecCd = wkPccCmpnyStWork.InqOtherSecCd;
                    //PCC���ЃR�[�h
                    pccCmpnySt.PccCompanyCode = wkPccCmpnyStWork.PccCompanyCode;
                    //PCC���Ж���
                    string pccCompanyName = string.Empty;
                    if (this._customerInfoTable != null && this._customerInfoTable.ContainsKey(wkPccCmpnyStWork.PccCompanyCode))
                    {
                        pccCompanyName = this._customerInfoTable[wkPccCmpnyStWork.PccCompanyCode] as string;

                    }
                    pccCmpnySt.PccCompanyName = pccCompanyName;
                    //PCC�q�ɃR�[�h
                    pccCmpnySt.PccWarehouseCd = wkPccCmpnyStWork.PccWarehouseCd;
                    //PCC�D��q�ɃR�[�h1
                    pccCmpnySt.PccPriWarehouseCd1 = wkPccCmpnyStWork.PccPriWarehouseCd1;
                    //PCC�D��q�ɃR�[�h2
                    pccCmpnySt.PccPriWarehouseCd2 = wkPccCmpnyStWork.PccPriWarehouseCd2;
                    //PCC�D��q�ɃR�[�h3
                    pccCmpnySt.PccPriWarehouseCd3 = wkPccCmpnyStWork.PccPriWarehouseCd3;
                    //�i�ԕ\���敪
                    pccCmpnySt.GoodsNoDspDiv = wkPccCmpnyStWork.GoodsNoDspDiv;
                    //�i�ԕ\������
                    pccCmpnySt.GoodsNoDspDivName = getNameFromDiv(wkPccCmpnyStWork.GoodsNoDspDiv, 0);
                    //�W�����i�\���敪
                    pccCmpnySt.ListPrcDspDiv = wkPccCmpnyStWork.ListPrcDspDiv;
                    //�W�����i�\������
                    pccCmpnySt.ListPrcDspDivName = getNameFromDiv(wkPccCmpnyStWork.ListPrcDspDiv, 0);
                    //�d�؉��i�\���敪
                    pccCmpnySt.CostDspDiv = wkPccCmpnyStWork.CostDspDiv;
                    //�d�؉��i�\������
                    pccCmpnySt.CostDspDivName =  getNameFromDiv(wkPccCmpnyStWork.CostDspDiv, 0);
                    //�I�ԕ\���敪
                    pccCmpnySt.ShelfDspDiv = wkPccCmpnyStWork.ShelfDspDiv;
                    //�I�ԕ\������
                    pccCmpnySt.ShelfDspDivName =  getNameFromDiv(wkPccCmpnyStWork.ShelfDspDiv, 0);
                    //�݌ɕ\���敪
                    pccCmpnySt.StockDspDiv = wkPccCmpnyStWork.StockDspDiv;
                    //�݌ɕ\������
                    pccCmpnySt.StockDspDivName =  getNameFromDiv(wkPccCmpnyStWork.StockDspDiv, 0);
                    //�R�����g�\���敪
                    pccCmpnySt.CommentDspDiv = wkPccCmpnyStWork.CommentDspDiv;
                    //�R�����g�\������
                    pccCmpnySt.CommentDspDivName =  getNameFromDiv(wkPccCmpnyStWork.CommentDspDiv, 0);
                    //�o�א��\���敪
                    pccCmpnySt.SpmtCntDspDiv = wkPccCmpnyStWork.SpmtCntDspDiv;
                    //�o�א��\������
                    pccCmpnySt.SpmtCntDspDivName =  getNameFromDiv(wkPccCmpnyStWork.SpmtCntDspDiv, 0);
                    //�󒍐��\���敪
                    pccCmpnySt.AcptCntDspDiv = wkPccCmpnyStWork.AcptCntDspDiv;
                    //�󒍐��\������
                    pccCmpnySt.AcptCntDspDivName =  getNameFromDiv(wkPccCmpnyStWork.AcptCntDspDiv, 0);
                    //���i�I��i�ԕ\���敪
                    pccCmpnySt.PrtSelGdNoDspDiv = wkPccCmpnyStWork.PrtSelGdNoDspDiv;
                    //���i�I��i�ԕ\������
                    pccCmpnySt.PrtSelGdNoDspDivName =  getNameFromDiv(wkPccCmpnyStWork.PrtSelGdNoDspDiv, 0);
                    //���i�I��W�����i�\���敪
                    pccCmpnySt.PrtSelLsPrDspDiv = wkPccCmpnyStWork.PrtSelLsPrDspDiv;
                    //���i�I��W�����i�\������
                    pccCmpnySt.PrtSelLsPrDspDivName =  getNameFromDiv(wkPccCmpnyStWork.PrtSelLsPrDspDiv, 0);
                    //���i�I��I�ԕ\���敪
                    pccCmpnySt.PrtSelSelfDspDiv = wkPccCmpnyStWork.PrtSelSelfDspDiv;
                    //���i�I��I�ԕ\������
                    pccCmpnySt.PrtSelSelfDspDivName =  getNameFromDiv(wkPccCmpnyStWork.PrtSelSelfDspDiv, 0);
                    //���i�I���݌ɕ\���敪
                    pccCmpnySt.PrtSelStckDspDiv = wkPccCmpnyStWork.PrtSelStckDspDiv;
                    //���i�I���݌ɕ\������
                    pccCmpnySt.PrtSelStckDspDivName = getNameFromDiv(wkPccCmpnyStWork.PrtSelStckDspDiv, 0);
                    //�݌ɏ󋵃}�[�N1
                    pccCmpnySt.StckStMark1 = wkPccCmpnyStWork.StckStMark1;
                    //�݌ɏ󋵃}�[�N2
                    pccCmpnySt.StckStMark2 = wkPccCmpnyStWork.StckStMark2;
                    //�݌ɏ󋵃}�[�N3
                    pccCmpnySt.StckStMark3 = wkPccCmpnyStWork.StckStMark3;
                    //PCC�����於��1
                    pccCmpnySt.PccSuplName1 = wkPccCmpnyStWork.PccSuplName1;
                    //PCC�����於��2
                    pccCmpnySt.PccSuplName2 = wkPccCmpnyStWork.PccSuplName2;
                    //PCC������J�i����
                    pccCmpnySt.PccSuplKana = wkPccCmpnyStWork.PccSuplKana;
                    //PCC�����旪��
                    pccCmpnySt.PccSuplSnm = wkPccCmpnyStWork.PccSuplSnm;
                    //PCC������X�֔ԍ�
                    pccCmpnySt.PccSuplPostNo = wkPccCmpnyStWork.PccSuplPostNo;
                    //PCC������Z��1
                    pccCmpnySt.PccSuplAddr1 = wkPccCmpnyStWork.PccSuplAddr1;
                    //PCC������Z��2
                    pccCmpnySt.PccSuplAddr2 = wkPccCmpnyStWork.PccSuplAddr2;
                    //PCC������Z��3
                    pccCmpnySt.PccSuplAddr3 = wkPccCmpnyStWork.PccSuplAddr3;
                    //PCC������d�b�ԍ�1
                    pccCmpnySt.PccSuplTelNo1 = wkPccCmpnyStWork.PccSuplTelNo1;
                    //PCC������d�b�ԍ�2
                    pccCmpnySt.PccSuplTelNo2 = wkPccCmpnyStWork.PccSuplTelNo2;
                    //PCC������FAX�ԍ�
                    pccCmpnySt.PccSuplFaxNo = wkPccCmpnyStWork.PccSuplFaxNo;
                    //�`�[���s�敪�iPCC�j
                    pccCmpnySt.PccSlipPrtDiv = wkPccCmpnyStWork.PccSlipPrtDiv;
                    //�`�[���s���́iPCC�j
                    pccCmpnySt.PccSlipPrtDivName = getNameFromDiv(wkPccCmpnyStWork.PccSlipPrtDiv, 1);
                    //�`�[�Ĕ��s�敪
                    pccCmpnySt.PccSlipRePrtDiv = wkPccCmpnyStWork.PccSlipRePrtDiv;
                    //�`�[�Ĕ��s����
                    pccCmpnySt.PccSlipRePrtDivName = getNameFromDiv(wkPccCmpnyStWork.PccSlipRePrtDiv, 4);
                    //���i�I��D�Ǖ\���敪
                    pccCmpnySt.PrtSelPrmDspDiv = wkPccCmpnyStWork.PrtSelPrmDspDiv;
                    //���i�I��D�Ǖ\������
                    pccCmpnySt.PrtSelPrmDspDivName = getNameFromDiv(wkPccCmpnyStWork.PrtSelPrmDspDiv, 2);
                    //�݌ɏ󋵕\���敪
                    pccCmpnySt.StckStDspDiv = wkPccCmpnyStWork.StckStDspDiv;
                    //�݌ɏ󋵕\������
                    pccCmpnySt.StckStDspDivName = getNameFromDiv(wkPccCmpnyStWork.StckStDspDiv, 3);
                    //�݌ɃR�����g1
                    pccCmpnySt.StckStComment1 = wkPccCmpnyStWork.StckStComment1;
                    //�݌ɃR�����g2
                    pccCmpnySt.StckStComment2 = wkPccCmpnyStWork.StckStComment2;
                    //�݌ɃR�����g3
                    pccCmpnySt.StckStComment3 = wkPccCmpnyStWork.StckStComment3;

                    // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
                    //�q�ɕ\���敪(�⍇��)
                    pccCmpnySt.WarehouseDspDiv = wkPccCmpnyStWork.WarehouseDspDiv;
                    //����\���敪(�⍇��)
                    pccCmpnySt.CancelDspDiv = wkPccCmpnyStWork.CancelDspDiv;
                    //�i�ԕ\���敪(����)
                    pccCmpnySt.GoodsNoDspDivOd = wkPccCmpnyStWork.GoodsNoDspDivOd;
                    //�W�����i�\���敪(����)
                    pccCmpnySt.ListPrcDspDivOd = wkPccCmpnyStWork.ListPrcDspDivOd;
                    //�d�؉��i�\���敪(����)
                    pccCmpnySt.CostDspDivOd = wkPccCmpnyStWork.CostDspDivOd;
                    //�I�ԕ\���敪(����)
                    pccCmpnySt.ShelfDspDivOd = wkPccCmpnyStWork.ShelfDspDivOd;
                    //�݌ɕ\���敪(����)
                    pccCmpnySt.StockDspDivOd = wkPccCmpnyStWork.StockDspDivOd;
                    //�R�����g�\���敪(����)
                    pccCmpnySt.CommentDspDivOd = wkPccCmpnyStWork.CommentDspDivOd;
                    //�o�א��\���敪(����)
                    pccCmpnySt.SpmtCntDspDivOd = wkPccCmpnyStWork.SpmtCntDspDivOd;
                    //�󒍐��\���敪(����)
                    pccCmpnySt.AcptCntDspDivOd = wkPccCmpnyStWork.AcptCntDspDivOd;
                    //���i�I��i�ԕ\���敪(����)
                    pccCmpnySt.PrtSelGdNoDspDivOd = wkPccCmpnyStWork.PrtSelGdNoDspDivOd;
                    //���i�I��W�����i�\���敪(����)
                    pccCmpnySt.PrtSelLsPrDspDivOd = wkPccCmpnyStWork.PrtSelLsPrDspDivOd;
                    //���i�I��I�ԕ\���敪(����)
                    pccCmpnySt.PrtSelSelfDspDivOd = wkPccCmpnyStWork.PrtSelSelfDspDivOd;
                    //���i�I���݌ɕ\���敪(����)
                    pccCmpnySt.PrtSelStckDspDivOd = wkPccCmpnyStWork.PrtSelStckDspDivOd;
                    //�q�ɕ\���敪(����)
                    pccCmpnySt.WarehouseDspDivOd = wkPccCmpnyStWork.WarehouseDspDivOd;
                    //����\���敪(����)
                    pccCmpnySt.CancelDspDivOd = wkPccCmpnyStWork.CancelDspDivOd;
                    //�⍇�������\���敪�ݒ�
                    pccCmpnySt.InqOdrDspDivSet = wkPccCmpnyStWork.InqOdrDspDivSet;

                    //�q�ɕ\���敪����(�⍇��)
                    pccCmpnySt.WarehouseDspDivName = getNameFromDiv(wkPccCmpnyStWork.WarehouseDspDiv, 0);
                    //����\���敪����(�⍇��)
                    pccCmpnySt.CancelDspDivName = getNameFromDiv(wkPccCmpnyStWork.CancelDspDiv, 0);
                    //�i�ԕ\���敪����(����)
                    pccCmpnySt.GoodsNoDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.GoodsNoDspDivOd, 0);
                    //�W�����i�\���敪����(����)
                    pccCmpnySt.ListPrcDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.ListPrcDspDivOd, 0);
                    //�d�؉��i�\���敪����(����)
                    pccCmpnySt.CostDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.CostDspDivOd, 0);
                    //�I�ԕ\���敪����(����)
                    pccCmpnySt.ShelfDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.ShelfDspDivOd, 0);
                    //�݌ɕ\���敪����(����)
                    pccCmpnySt.StockDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.StockDspDivOd, 0);
                    //�R�����g�\���敪����(����)
                    pccCmpnySt.CommentDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.CommentDspDivOd, 0);
                    //�o�א��\���敪����(����)
                    pccCmpnySt.SpmtCntDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.SpmtCntDspDivOd, 0);
                    //�󒍐��\���敪����(����)
                    pccCmpnySt.AcptCntDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.AcptCntDspDivOd, 0);
                    //���i�I��i�ԕ\���敪����(����)
                    pccCmpnySt.PrtSelGdNoDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.PrtSelGdNoDspDivOd, 0);
                    //���i�I��W�����i�\���敪����(����)
                    pccCmpnySt.PrtSelLsPrDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.PrtSelLsPrDspDivOd, 0);
                    //���i�I��I�ԕ\���敪����(����)
                    pccCmpnySt.PrtSelSelfDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.PrtSelSelfDspDivOd, 0);
                    //���i�I���݌ɕ\���敪����(����)
                    pccCmpnySt.PrtSelStckDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.PrtSelStckDspDivOd, 0);
                    //�q�ɕ\���敪����(����)
                    pccCmpnySt.WarehouseDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.WarehouseDspDivOd, 0);
                    //����\���敪����(����)
                    pccCmpnySt.CancelDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.CancelDspDivOd, 0);
                    //�⍇�������\���敪�ݒ薼��
                    pccCmpnySt.InqOdrDspDivSetName = getNameFromDiv(wkPccCmpnyStWork.InqOdrDspDivSet, 5);
                    // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<

                    // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
                    // PCC�D��q�ɃR�[�h4
                    pccCmpnySt.PccPriWarehouseCd4 = wkPccCmpnyStWork.PccPriWarehouseCd4;
                    // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
                    // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                    //���݌ɐ��\���敪(����)
                    pccCmpnySt.PrsntStkCtDspDivOd = wkPccCmpnyStWork.PrsntStkCtDspDivOd;
                    //���݌ɐ��\���敪(����)����
                    pccCmpnySt.PrsntStkCtDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.PrsntStkCtDspDivOd, 6);
                    //���݌ɐ��\���敪(�⍇��)
                    pccCmpnySt.PrsntStkCtDspDiv = wkPccCmpnyStWork.PrsntStkCtDspDiv;
                    //���݌ɐ��\���敪(�⍇��)����
                    pccCmpnySt.PrsntStkCtDspDivName = getNameFromDiv(wkPccCmpnyStWork.PrsntStkCtDspDiv, 6);
                    // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
                    // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
                    // �񓚔[���\���敪(�⍇��)
                    pccCmpnySt.AnsDeliDtDspDiv = wkPccCmpnyStWork.AnsDeliDtDspDiv;
                    // �񓚔[���\���敪����(�⍇��)
                    pccCmpnySt.AnsDeliDtDspDivName = getNameFromDiv(wkPccCmpnyStWork.AnsDeliDtDspDiv, 0);
                    // �񓚔[���\���敪(����)
                    pccCmpnySt.AnsDeliDtDspDivOd = wkPccCmpnyStWork.AnsDeliDtDspDivOd;
                    // �񓚔[���\���敪����(����)
                    pccCmpnySt.AnsDeliDtDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.AnsDeliDtDspDivOd, 0);
                    // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<

                    pccCmpnyStList.Add(pccCmpnySt);
                }
            }
        }

        /// <summary>
        /// PCC���Аݒ�}�X�^�����e�]������
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC���Аݒ胏�[�N���X�g</param>
        /// <param name="pccCmpnyStList">PCC���Аݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�i�ڃO���[�v�}�X�^�����e�]�������B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private void CopyCmpnyStToWork(out ArrayList pccCmpnyStWorkList, List<PccCmpnySt> pccCmpnyStList)
        {
            pccCmpnyStWorkList = null;
            if (pccCmpnyStList == null || pccCmpnyStList.Count == 0)
            {
                return;
            }
            else
            {
                pccCmpnyStWorkList = new ArrayList();
                foreach (PccCmpnySt pccCmpnySt in pccCmpnyStList)
                {
                    PccCmpnyStWork wkPccCmpnyStWork = new PccCmpnyStWork();
                    //�쐬����
                    wkPccCmpnyStWork.CreateDateTime = pccCmpnySt.CreateDateTime;
                    //�X�V����
                    wkPccCmpnyStWork.UpdateDateTime = pccCmpnySt.UpdateDateTime;
                    //�_���폜�敪
                    wkPccCmpnyStWork.LogicalDeleteCode = pccCmpnySt.LogicalDeleteCode;
                    //�⍇������ƃR�[�h
                    wkPccCmpnyStWork.InqOriginalEpCd = pccCmpnySt.InqOriginalEpCd.Trim();//@@@@20230303
                    //�⍇�������_�R�[�h
                    wkPccCmpnyStWork.InqOriginalSecCd = pccCmpnySt.InqOriginalSecCd;
                    //�⍇�����ƃR�[�h
                    wkPccCmpnyStWork.InqOtherEpCd = pccCmpnySt.InqOtherEpCd;
                    //�⍇���拒�_�R�[�h
                    wkPccCmpnyStWork.InqOtherSecCd = pccCmpnySt.InqOtherSecCd;
                    //PCC���ЃR�[�h
                    wkPccCmpnyStWork.PccCompanyCode = pccCmpnySt.PccCompanyCode;
                    //PCC�q�ɃR�[�h
                    wkPccCmpnyStWork.PccWarehouseCd = pccCmpnySt.PccWarehouseCd;
                    //PCC�D��q�ɃR�[�h1
                    wkPccCmpnyStWork.PccPriWarehouseCd1 = pccCmpnySt.PccPriWarehouseCd1;
                    //PCC�D��q�ɃR�[�h2
                    wkPccCmpnyStWork.PccPriWarehouseCd2 = pccCmpnySt.PccPriWarehouseCd2;
                    //PCC�D��q�ɃR�[�h3
                    wkPccCmpnyStWork.PccPriWarehouseCd3 = pccCmpnySt.PccPriWarehouseCd3;
                    //�i�ԕ\���敪
                    wkPccCmpnyStWork.GoodsNoDspDiv = pccCmpnySt.GoodsNoDspDiv;
                    //�W�����i�\���敪
                    wkPccCmpnyStWork.ListPrcDspDiv = pccCmpnySt.ListPrcDspDiv;
                    //�d�؉��i�\���敪
                    wkPccCmpnyStWork.CostDspDiv = pccCmpnySt.CostDspDiv;
                    //�I�ԕ\���敪
                    wkPccCmpnyStWork.ShelfDspDiv = pccCmpnySt.ShelfDspDiv;
                    //�݌ɕ\���敪
                    wkPccCmpnyStWork.StockDspDiv = pccCmpnySt.StockDspDiv;
                    //�R�����g�\���敪
                    wkPccCmpnyStWork.CommentDspDiv = pccCmpnySt.CommentDspDiv;
                    //�o�א��\���敪
                    wkPccCmpnyStWork.SpmtCntDspDiv = pccCmpnySt.SpmtCntDspDiv;
                    //�󒍐��\���敪
                    wkPccCmpnyStWork.AcptCntDspDiv = pccCmpnySt.AcptCntDspDiv;
                    //���i�I��i�ԕ\���敪
                    wkPccCmpnyStWork.PrtSelGdNoDspDiv = pccCmpnySt.PrtSelGdNoDspDiv;
                    //���i�I��W�����i�\���敪
                    wkPccCmpnyStWork.PrtSelLsPrDspDiv = pccCmpnySt.PrtSelLsPrDspDiv;
                    //���i�I��I�ԕ\���敪
                    wkPccCmpnyStWork.PrtSelSelfDspDiv = pccCmpnySt.PrtSelSelfDspDiv;
                    //���i�I���݌ɕ\���敪
                    wkPccCmpnyStWork.PrtSelStckDspDiv = pccCmpnySt.PrtSelStckDspDiv;
                    //�݌ɏ󋵃}�[�N1
                    wkPccCmpnyStWork.StckStMark1 = pccCmpnySt.StckStMark1;
                    //�݌ɏ󋵃}�[�N2
                    wkPccCmpnyStWork.StckStMark2 = pccCmpnySt.StckStMark2;
                    //�݌ɏ󋵃}�[�N3
                    wkPccCmpnyStWork.StckStMark3 = pccCmpnySt.StckStMark3;
                    //PCC�����於��1
                    wkPccCmpnyStWork.PccSuplName1 = pccCmpnySt.PccSuplName1;
                    //PCC�����於��2
                    wkPccCmpnyStWork.PccSuplName2 = pccCmpnySt.PccSuplName2;
                    //PCC������J�i����
                    wkPccCmpnyStWork.PccSuplKana = pccCmpnySt.PccSuplKana;
                    //PCC�����旪��
                    wkPccCmpnyStWork.PccSuplSnm = pccCmpnySt.PccSuplSnm;
                    //PCC������X�֔ԍ�
                    wkPccCmpnyStWork.PccSuplPostNo = pccCmpnySt.PccSuplPostNo;
                    //PCC������Z��1
                    wkPccCmpnyStWork.PccSuplAddr1 = pccCmpnySt.PccSuplAddr1;
                    //PCC������Z��2
                    wkPccCmpnyStWork.PccSuplAddr2 = pccCmpnySt.PccSuplAddr2;
                    //PCC������Z��3
                    wkPccCmpnyStWork.PccSuplAddr3 = pccCmpnySt.PccSuplAddr3;
                    //PCC������d�b�ԍ�1
                    wkPccCmpnyStWork.PccSuplTelNo1 = pccCmpnySt.PccSuplTelNo1;
                    //PCC������d�b�ԍ�2
                    wkPccCmpnyStWork.PccSuplTelNo2 = pccCmpnySt.PccSuplTelNo2;
                    //PCC������FAX�ԍ�
                    wkPccCmpnyStWork.PccSuplFaxNo = pccCmpnySt.PccSuplFaxNo;
                    //�`�[���s�敪�iPCC�j
                    wkPccCmpnyStWork.PccSlipPrtDiv = pccCmpnySt.PccSlipPrtDiv;
                    //�`�[�Ĕ��s�敪
                    wkPccCmpnyStWork.PccSlipRePrtDiv = pccCmpnySt.PccSlipRePrtDiv;
                    //���i�I��D�Ǖ\���敪
                    wkPccCmpnyStWork.PrtSelPrmDspDiv = pccCmpnySt.PrtSelPrmDspDiv;
                    //�݌ɏ󋵕\���敪
                    wkPccCmpnyStWork.StckStDspDiv = pccCmpnySt.StckStDspDiv;
                    //�݌ɃR�����g1
                    wkPccCmpnyStWork.StckStComment1 = pccCmpnySt.StckStComment1;
                    //�݌ɃR�����g2
                    wkPccCmpnyStWork.StckStComment2 = pccCmpnySt.StckStComment2;
                    //�݌ɃR�����g3
                    wkPccCmpnyStWork.StckStComment3 = pccCmpnySt.StckStComment3;

                    // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
                    //�q�ɕ\���敪(�⍇��)
                    wkPccCmpnyStWork.WarehouseDspDiv = pccCmpnySt.WarehouseDspDiv;
                    //����\���敪(�⍇��)
                    wkPccCmpnyStWork.CancelDspDiv = pccCmpnySt.CancelDspDiv;
                    //�i�ԕ\���敪(����)
                    wkPccCmpnyStWork.GoodsNoDspDivOd = pccCmpnySt.GoodsNoDspDivOd;
                    //�W�����i�\���敪(����)
                    wkPccCmpnyStWork.ListPrcDspDivOd = pccCmpnySt.ListPrcDspDivOd;
                    //�d�؉��i�\���敪(����)
                    wkPccCmpnyStWork.CostDspDivOd = pccCmpnySt.CostDspDivOd;
                    //�I�ԕ\���敪(����)
                    wkPccCmpnyStWork.ShelfDspDivOd = pccCmpnySt.ShelfDspDivOd;
                    //�݌ɕ\���敪(����)
                    wkPccCmpnyStWork.StockDspDivOd = pccCmpnySt.StockDspDivOd;
                    //�R�����g�\���敪(����)
                    wkPccCmpnyStWork.CommentDspDivOd = pccCmpnySt.CommentDspDivOd;
                    //�o�א��\���敪(����)
                    wkPccCmpnyStWork.SpmtCntDspDivOd = pccCmpnySt.SpmtCntDspDivOd;
                    //�󒍐��\���敪(����)
                    wkPccCmpnyStWork.AcptCntDspDivOd = pccCmpnySt.AcptCntDspDivOd;
                    //���i�I��i�ԕ\���敪(����)
                    wkPccCmpnyStWork.PrtSelGdNoDspDivOd = pccCmpnySt.PrtSelGdNoDspDivOd;
                    //���i�I��W�����i�\���敪(����)
                    wkPccCmpnyStWork.PrtSelLsPrDspDivOd = pccCmpnySt.PrtSelLsPrDspDivOd;
                    //���i�I��I�ԕ\���敪(����)
                    wkPccCmpnyStWork.PrtSelSelfDspDivOd = pccCmpnySt.PrtSelSelfDspDivOd;
                    //���i�I���݌ɕ\���敪(����)
                    wkPccCmpnyStWork.PrtSelStckDspDivOd = pccCmpnySt.PrtSelStckDspDivOd;
                    //�q�ɕ\���敪(����)
                    wkPccCmpnyStWork.WarehouseDspDivOd = pccCmpnySt.WarehouseDspDivOd;
                    //����\���敪(����)
                    wkPccCmpnyStWork.CancelDspDivOd = pccCmpnySt.CancelDspDivOd;
                    //�⍇�������\���敪�ݒ�
                    wkPccCmpnyStWork.InqOdrDspDivSet = pccCmpnySt.InqOdrDspDivSet;
                    // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<

                    // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
                    //PCC�D��q�ɃR�[�h4
                    wkPccCmpnyStWork.PccPriWarehouseCd4 = pccCmpnySt.PccPriWarehouseCd4;
                    // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<

                    // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                    //���݌ɐ��\���敪(����)
                    wkPccCmpnyStWork.PrsntStkCtDspDivOd = pccCmpnySt.PrsntStkCtDspDivOd;
                    //���݌ɐ��\���敪(�⍇��)
                    wkPccCmpnyStWork.PrsntStkCtDspDiv = pccCmpnySt.PrsntStkCtDspDiv;
                    // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
                    // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
                    // �񓚔[���\���敪(�⍇��)
                    wkPccCmpnyStWork.AnsDeliDtDspDiv = pccCmpnySt.AnsDeliDtDspDiv;
                    // �񓚔[���\���敪(����)
                    wkPccCmpnyStWork.AnsDeliDtDspDivOd = pccCmpnySt.AnsDeliDtDspDivOd;
                    // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<

                    pccCmpnyStWorkList.Add(wkPccCmpnyStWork);
                }
            }

        }

        /// <summary>
        /// �敪���疼�̂̎擾����
        /// </summary>
        /// <param name="div">�敪</param>
        /// <param name="kind">���(1:�`�[���s�敪�iPCC�j;2:���i�I��D�Ǖ\���敪;3:�݌ɏ󋵕\���敪;4:�`�[�Ĕ��s�敪0:���̑�;)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �敪���疼�̂̎擾�������s���B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private string getNameFromDiv(int div, int kind)
        {
            string name = string.Empty;
            switch (kind)
            {
                case 0:
                    {
                        switch (div)
                        {
                            case 0:
                                {
                                    name = "����";
                                    break;
                                }
                            case 1:
                                {
                                    name = "���Ȃ�";
                                    break;
                                }
                        }
                      
                        break;
                    }
                //�`�[���s�敪�iPCC�j
                case 1:
                    {
                        switch (kind)
                        {
                            case 0:
                                {
                                    name = "���Ȃ�";
                                    break;
                                }
                            case 1:
                                {
                                    name = "��";
                                    break;
                                }
                            case 2:
                                {
                                    name = "�Ӱ�";
                                    break;
                                }
                            case 3:
                                {
                                    name = "����";
                                    break;
                                }
                        }
                        break;
                    }
                //���i�I��D�Ǖ\���敪
                case 2:
                    {
                        switch (kind)
                        {
                            case 0:
                                {
                                    name = "�S��";
                                    break;
                                }
                            case 1:
                                {
                                    name = "���ЗD��݌�";
                                    break;
                                }
                            case 2:
                                {
                                    name = "���Ѝ݌�";
                                    break;
                                }
                        }
                        break;
                    }
                case 3:
                    {
                        //�݌ɏ󋵕\���敪
                        switch (div)
                        {
                            case 0:
                                {
                                    name = "�}�[�N";
                                    break;
                                }
                            case 1:
                                {
                                    name = "���݌ɐ�";
                                    break;
                                }
                        }

                        break;
                    }
                case 4:
                    {
                        switch (div)
                        {
                            case 0:
                                {
                                    name = "����";
                                    break;
                                }
                            case 1:
                                {
                                    name = "���Ȃ�";
                                    break;
                                }
                        }

                        break;
                    }
                // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
                case 5:
                    {
                        switch (div)
                        {
                            case 0:
                                {
                                    name = "�⍇����������";
                                    break;
                                }
                            case 1:
                                {
                                    name = "�⍇��������";
                                    break;
                                }
                        }

                        break;
                    }
                // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                case 6:
                    {
                        switch (div)
                        {
                            case 2:
                                {
                                    name = "���ʁE�󋵕\��";
                                    break;
                                }
                            case 1:
                                {
                                    name = "�󋵕\��";
                                    break;
                                }
                            case 0:
                                {
                                    name = "���Ȃ�";
                                    break;
                                }
                        }

                        break;
                    }
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<

            }
            return name;
        }
        #endregion

    }

}
