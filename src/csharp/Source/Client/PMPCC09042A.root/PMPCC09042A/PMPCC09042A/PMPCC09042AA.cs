//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PCC�i�ڃO���[�v�}�X�^�����e
// �v���O�����T�v   : PCC�i�ڃO���[�v�}�X�^�����e�A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2011.07.20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30747 �O�� �L��
// �� �� ��  2013/05/30  �C�����e : 2013/99/99�z�M SCM��Q��10541�Ή� 
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
    /// PCC�i�ڃO���[�v�}�X�^�����e�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC�i�ڃO���[�v�}�X�^�����e�t�h�N���X</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date	   : 2011.07.20</br>
    /// </remarks>  
    public class PccItemGrpAcs
    {
        /// <summary>
        /// �����[�g�I�u�W�F�N�g�C���^�[�t�F�C�X
        /// </summary>
        private IPccItemGrpDB _iPccItemGrpDB = null;
        private Hashtable _bLCodeTable;
        private BLGoodsCdAcs _bLGoodsCdAcs = null;
        private CustomerInfoAcs _customerInfoAcs;
        private List<BLGoodsCdUMnt> _bLGoodsCdUMntList = null;
        //���Ӑ�
        private Hashtable _customerInfoTable;
        private const string CUSTOMEMPTY_BASE = "�x�[�X�ݒ�";

        #region �� Constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : PCC�i�ڃO���[�v�}�X�^�����e�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public PccItemGrpAcs()
        {
            _iPccItemGrpDB = MediationPccItemGrpDB.GetPccItemGrpDB();
            _bLGoodsCdAcs = new BLGoodsCdAcs();
            _customerInfoAcs = new CustomerInfoAcs();
        }
        #endregion �� Constructor

        /// <summary>
        /// PCC�i�ڃO���[�v�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="pccItemGrid">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <param name="pccItemGrpList">PCC�i�ڃO���[�v���X�g</param>
        /// <param name="pccItemStDict">PCC�i�ڐݒ�f�B�N�V���i���[</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�i�ڃO���[�v�}�X�^�����e�o�^�A�X�V�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int Write(ref PccItemGrid pccItemGrid, ref List<PccItemGrp> pccItemGrpList,
            ref Dictionary<int, List<PccItemSt>> pccItemStDict)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            //PCC�i�ڐݒ�}�X�^�����e�o�^
            status = WritePcc(ref pccItemGrid, ref pccItemGrpList, ref pccItemStDict);
            //PCCBL�R�[�h�}�X�^�����e�o�^
            if (pccItemGrid.PccCompanyCode != 0)
            {
                WritePMBLGdsCd(pccItemGrid);
            }
            return status;
        }

        /// <summary>
        /// PCC�i�ڃO���[�v�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="pccItemGrid">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <param name="pccItemGrpList">PCC�i�ڃO���[�v���X�g</param>
        /// <param name="pccItemStDict">PCC�i�ڐݒ�f�B�N�V���i���[</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�i�ڃO���[�v�}�X�^�����e�o�^�A�X�V�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int WritePcc(ref PccItemGrid pccItemGrid, ref List<PccItemGrp> pccItemGrpList,
            ref Dictionary<int, List<PccItemSt>> pccItemStDict)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            Object objPccItemGrpWorkList = null;
            ArrayList pccItemGrpWorkListResultList = null;
            ArrayList pccItemStWorkListResultList = null;
            Object objPccItemStWorkList = null;
            
            ArrayList pccItemGrpWorkList = null;
            ArrayList pccItemStWorkList = null;
            List<PccItemSt> pccItemStList = null;
            try
            {
                if (pccItemGrpList == null)
                {
                    return status;
                }
                
                CopyGrpToWork(out pccItemGrpWorkList, pccItemGrpList);
                if (pccItemGrpWorkList == null || pccItemGrpWorkList.Count == 0)
                {
                    return status;
                }
                objPccItemGrpWorkList = pccItemGrpWorkList as Object;
                    
                if (pccItemStDict != null && pccItemStDict.Count > 0)
                {
                    pccItemStList = new List<PccItemSt>();
                    foreach (KeyValuePair<int, List<PccItemSt>> pccItemPair in pccItemStDict)
                    {
                        pccItemStList.AddRange(pccItemPair.Value);
                    }
                    CopyStToWork(out pccItemStWorkList, pccItemStList);


                    objPccItemStWorkList = pccItemStWorkList as Object;
                }
                //PCC�i�ڐݒ�}�X�^�����e�o�^�A�X�V����
                status = _iPccItemGrpDB.Write(ref objPccItemGrpWorkList, ref objPccItemStWorkList); 
              
                //���ʂ�߂�
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
                pccItemGrpWorkListResultList = objPccItemGrpWorkList as ArrayList;
                if (pccItemGrpWorkListResultList != null)
                {
                    CopyWorkToGrp(pccItemGrpWorkListResultList, out pccItemGrpList);
                  
                }

               
                if (objPccItemStWorkList != null)
                {
                    pccItemStWorkListResultList = objPccItemStWorkList as ArrayList;
                }
                if (pccItemStWorkListResultList != null)
                {
                    CopyWorkToSt(pccItemStWorkListResultList, out pccItemStList);
                    Dictionary<string, Dictionary<int, List<PccItemSt>>> pccItemStDictDict = null;
                    //PCC�i�ڐݒ�f�B�N�V���i���[�̍쐬
                    CopyStListToDict(pccItemStList, out pccItemStDictDict);
                    if (pccItemStDictDict != null && pccItemStDictDict.ContainsKey(pccItemGrid.InqCondition))
                    {
                        pccItemStDict = pccItemStDictDict[pccItemGrid.InqCondition];
                    }
                   

                }
                //PCC�i�ڃO���[�v�}�X�^���X�g�̍쐬
                CopyGridListToGrid(pccItemGrpList, ref pccItemGrid);


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

        ///<summary>
        ///�o�l�a�k�R�[�h�̓o�^�A�X�V��������
        ///</summary>
        ///<remarks>
        ///<br>Note       : �o�l�a�k�R�[�h�̓o�^�A�X�V�������s���B</br>
        ///<br>Programmer : ���C��</br>
        ///<br>Date       : 2011.07.20</br>
        ///</remarks>
        public int WritePMBLGdsCd(PccItemGrid pccItemGrid)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
             ArrayList bLCodeList = null;
             ArrayList pMBLGdsCdWorkList = null;
             object pMBLGdsCdWorkObj = null;
             status = this._bLGoodsCdAcs.SearchAll(out bLCodeList, pccItemGrid.InqOtherEpCd);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    CopyBlPmToBlSCM(out pMBLGdsCdWorkList, bLCodeList, pccItemGrid);
                    pMBLGdsCdWorkObj = pMBLGdsCdWorkList;
                    status = _iPccItemGrpDB.WritePMBLGdsCd(ref pMBLGdsCdWorkObj);
                }

                return status;
            
        }

        /// <summary>
        /// PCC�i�ڃO���[�v�}�X�^�����e��������
        /// </summary>
        /// <param name="pccItemGridList">PCC�i�ڃO���b�h���X�g</param>
        /// <param name="pccItemGrpDict">PCC�i�ڃO���[�v�f�B�N�V���i���[</param>
        /// <param name="pccItemStDictDict">PCC�i�ڐݒ�f�B�N�V���i���[</param>
        /// <param name="parsePccItemGrid">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�i�ڃO���[�v�}�X�^�����e���������B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int Search(out List<PccItemGrid> pccItemGridList, out Dictionary<string, List<PccItemGrp>> pccItemGrpDict, 
            out Dictionary<string, Dictionary<int, List<PccItemSt>>> pccItemStDictDict, PccItemGrid parsePccItemGrid, 
            int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            pccItemGridList = null;

            Object objPccItemGrpWorkList = null;
            ArrayList pccItemGrpWorkListResultList = null;
            Object objPccItemStWorkList = null;
            ArrayList pccItemStWorkListResultList = null;
            //PCC�i�ڃO���[�v
            pccItemGrpDict = null;
            //PCC�i�ڐݒ�
            pccItemStDictDict = null;
            //BLCode
            ArrayList bLCodeList = null;
            
            status = this._bLGoodsCdAcs.SearchAll(out bLCodeList, parsePccItemGrid.InqOtherEpCd);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                _bLGoodsCdUMntList = new List<BLGoodsCdUMnt>();
                _bLCodeTable = new Hashtable();

                foreach (BLGoodsCdUMnt bLGoodsCdUMnt in bLCodeList)
                {
                    if (!_bLCodeTable.ContainsKey(bLGoodsCdUMnt.BLGoodsCode))
                    {
                        _bLCodeTable.Add(bLGoodsCdUMnt.BLGoodsCode, bLGoodsCdUMnt.BLGoodsHalfName);
                        _bLGoodsCdUMntList.Add(bLGoodsCdUMnt);
                    }
                }
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
            
            status = _customerInfoAcs.Search(parsePccItemGrid.InqOtherEpCd, true, true, out customerInfoList);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (CustomerInfo customerInfo in customerInfoList)
                {
                    this._customerInfoTable.Add(customerInfo.CustomerCode, customerInfo.CustomerSnm);
                }
            }
            try
            {

                //PCC�i�ڃO���[�v�}�X�^�����e��������
                PccItemGrpWork parsePccItemGrpWork = new PccItemGrpWork();
                parsePccItemGrpWork.EnterpriseCode = parsePccItemGrid.EnterpriseCode;
                parsePccItemGrpWork.InqOtherEpCd = parsePccItemGrid.InqOtherEpCd;
                parsePccItemGrpWork.InqOtherSecCd = parsePccItemGrid.InqOtherSecCd;
          
                //PCC�i�ڐݒ�}�X�^�����e��������
                PccItemStWork parsePccItemStWork = new PccItemStWork();
                parsePccItemStWork.EnterpriseCode = parsePccItemGrid.EnterpriseCode;
                parsePccItemStWork.InqOtherEpCd = parsePccItemGrid.InqOtherEpCd;
                parsePccItemStWork.InqOtherSecCd = parsePccItemGrid.InqOtherSecCd;

                //PCC�i�ڃO���[�v�}�X�^�����e��������
                 status = _iPccItemGrpDB.Search(out objPccItemGrpWorkList, out objPccItemStWorkList,parsePccItemGrpWork, parsePccItemStWork, readMode, logicalMode);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
                //���ʂ�߂�
                pccItemGrpWorkListResultList = objPccItemGrpWorkList as ArrayList;
                if (objPccItemStWorkList != null)
                {
                    pccItemStWorkListResultList = objPccItemStWorkList as ArrayList;
                }
                CopyWorkToTwoResult(pccItemGrpWorkListResultList, pccItemStWorkListResultList,
                    out pccItemGridList, out pccItemGrpDict, out pccItemStDictDict);
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
        /// PCC�i�ڃO���[�v�}�X�^�����e��������
        /// </summary>
        /// <param name="pccItemGrpList">PCC�i�ڃO���[�v���X�g</param>
        /// <param name="pccItemStList">PCC�i�ڐݒ�f�B�N�V���i���[</param>
        /// <param name="parsePccItemGrid">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�i�ڃO���[�v�}�X�^�����e���������B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int Search(out List<PccItemGrp> pccItemGrpList,
            out List<PccItemSt> pccItemStList, PccItemGrid parsePccItemGrid,
            int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            pccItemGrpList = null;
            pccItemStList = null;
            Object objPccItemGrpWorkList = null;
            ArrayList pccItemGrpWorkListResultList = null;
            Object objPccItemStWorkList = null;
            ArrayList pccItemStWorkListResultList = null;
            //BLCode
            ArrayList bLCodeList = null;
            if (parsePccItemGrid != null)
            {
                status = this._bLGoodsCdAcs.SearchAll(out bLCodeList, parsePccItemGrid.InqOtherEpCd);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    _bLGoodsCdUMntList = new List<BLGoodsCdUMnt>();
                    _bLCodeTable = new Hashtable();

                    foreach (BLGoodsCdUMnt bLGoodsCdUMnt in bLCodeList)
                    {
                        if (!_bLCodeTable.ContainsKey(bLGoodsCdUMnt.BLGoodsCode))
                        {
                            _bLCodeTable.Add(bLGoodsCdUMnt.BLGoodsCode, bLGoodsCdUMnt.BLGoodsHalfName);
                            _bLGoodsCdUMntList.Add(bLGoodsCdUMnt);
                        }
                    }
                }

            }
            try
            {

                //PCC�i�ڃO���[�v�}�X�^�����e��������
                PccItemGrpWork parsePccItemGrpWork = new PccItemGrpWork();
                //PCC�i�ڐݒ�}�X�^�����e��������
                PccItemStWork parsePccItemStWork = new PccItemStWork();
                if (parsePccItemGrid != null)
                {
                    parsePccItemGrpWork.EnterpriseCode = parsePccItemGrid.EnterpriseCode;
                    parsePccItemGrpWork.InqOtherEpCd = parsePccItemGrid.InqOtherEpCd;
                    parsePccItemGrpWork.InqOtherSecCd = parsePccItemGrid.InqOtherSecCd;

                    parsePccItemStWork.EnterpriseCode = parsePccItemGrid.EnterpriseCode;
                    parsePccItemStWork.InqOtherEpCd = parsePccItemGrid.InqOtherEpCd;
                    parsePccItemStWork.InqOtherSecCd = parsePccItemGrid.InqOtherSecCd;
                }

                //PCC�i�ڃO���[�v�}�X�^�����e��������
                status = _iPccItemGrpDB.Search(out objPccItemGrpWorkList, out objPccItemStWorkList, parsePccItemGrpWork, parsePccItemStWork, readMode, logicalMode);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
                //���ʂ�߂�
                pccItemGrpWorkListResultList = objPccItemGrpWorkList as ArrayList;
                CopyWorkToGrp(pccItemGrpWorkListResultList, out pccItemGrpList);
                if (objPccItemStWorkList != null)
                {
                    pccItemStWorkListResultList = objPccItemStWorkList as ArrayList;
                }
                //PCC�i�ڐݒ�}�X�^���X�g
                if (pccItemStWorkListResultList != null && pccItemStWorkListResultList.Count > 0)
                {
                    CopyWorkToSt(pccItemStWorkListResultList, out pccItemStList);
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
        /// PCC�i�ڃO���[�v�}�X�^�����e��������
        /// </summary>
        /// <param name="pccItemGrpList">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <param name="pccItemStList">PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�i�ڃO���[�v�}�X�^�����e���������B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int Read(ref List<PccItemGrp> pccItemGrpList, ref List<PccItemSt> pccItemStList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF; 

            Object objPccItemGrpWorkList = null;
            ArrayList pccItemGrpWorkListResultList = null;
            ArrayList pccItemStWorkListResultList = null;
            Object objPccItemStWorkList = null;

            ArrayList pccItemGrpWorkList = null;
            ArrayList pccItemStWorkList = null;
            pccItemGrpList = null;
            pccItemStList = null;
            try
            {
                CopyGrpToWork(out pccItemGrpWorkList, pccItemGrpList);
                if (pccItemGrpWorkList != null)
                {
                    objPccItemGrpWorkList = pccItemGrpWorkList as Object;
                }
               CopyStToWork(out pccItemStWorkList, pccItemStList);
                if (pccItemStWorkList != null)
                {
                    objPccItemStWorkList = pccItemStWorkList as Object;
                }

                status = _iPccItemGrpDB.Read(ref objPccItemGrpWorkList, ref objPccItemStWorkList, readMode, logicalMode);

                
                //���ʂ�߂�
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
                pccItemGrpWorkListResultList = objPccItemGrpWorkList as ArrayList;

                if (pccItemGrpWorkListResultList != null)
                {
                    CopyWorkToGrp(pccItemGrpWorkListResultList, out pccItemGrpList);

                }


                if (objPccItemStWorkList != null)
                {
                    pccItemStWorkListResultList = objPccItemStWorkList as ArrayList;
                }
                if (pccItemStWorkListResultList != null)
                {
                    CopyWorkToSt(pccItemStWorkListResultList, out pccItemStList);


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
        /// PCC�i�ڃO���[�v�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccItemGrid">PCC�i�ڃO���[�v���X�g</param>
        /// <param name="pccItemGrpList">PCC�i�ڃO���[�v���X�g</param>
        /// <param name="pccItemStDict">PCC�i�ڐݒ�f�B�N�V���i���[</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�i�ڃO���[�v�}�X�^�����e�_���폜�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int LogicalDelete(ref PccItemGrid pccItemGrid, ref List<PccItemGrp> pccItemGrpList, ref Dictionary<int, List<PccItemSt>> pccItemStDict)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            
            Object objPccItemGrpWorkList = null;
            ArrayList pccItemGrpWorkListResultList = null;
            ArrayList pccItemStWorkListResultList = null;
            Object objPccItemStWorkList = null;

            ArrayList pccItemGrpWorkList = null;
            ArrayList pccItemStWorkList = null;
            List<PccItemSt> pccItemStList = null;
            try
            {
                if (pccItemGrpList == null)
                {
                    return status;
                }
                CopyGrpToWork(out pccItemGrpWorkList, pccItemGrpList);
                if (pccItemGrpWorkList == null || pccItemGrpWorkList.Count == 0)
                {
                    return status;
                }
                objPccItemGrpWorkList = pccItemGrpWorkList as Object;
                //PCC�i�ڃO���[�v�}�X�^�����e�_���폜����
                if (pccItemStDict != null && pccItemStDict.Count > 0)
                {
                    pccItemStList = new List<PccItemSt>();
                    foreach (KeyValuePair<int, List<PccItemSt>> pccItemPair in pccItemStDict)
                    {
                        pccItemStList.AddRange(pccItemPair.Value);
                    }
                    CopyStToWork(out pccItemStWorkList, pccItemStList);
                    objPccItemStWorkList = pccItemStWorkList as Object;
                }
                //�_���폜����
                status = _iPccItemGrpDB.LogicalDelete(ref objPccItemGrpWorkList, ref objPccItemStWorkList);
                //���ʂ�߂�
                pccItemGrpWorkListResultList = objPccItemGrpWorkList as ArrayList;

                if (pccItemGrpWorkListResultList != null)
                {
                    CopyWorkToGrp(pccItemGrpWorkListResultList, out pccItemGrpList);

                }
                if (objPccItemStWorkList != null)
                {
                    pccItemStWorkListResultList = objPccItemStWorkList as ArrayList;
                }
                if (pccItemStWorkListResultList != null)
                {
                    CopyWorkToSt(pccItemStWorkListResultList, out pccItemStList);
                    Dictionary<string, Dictionary<int, List<PccItemSt>>> pccItemStDictDict = null;
                    //PCC�i�ڐݒ�f�B�N�V���i���[�̍쐬
                    CopyStListToDict(pccItemStList, out pccItemStDictDict);
                    if (pccItemStDictDict != null && pccItemStDictDict.ContainsKey(pccItemGrid.InqCondition))
                    {
                        pccItemStDict = pccItemStDictDict[pccItemGrid.InqCondition];
                    }


                }
                //PCC�i�ڃO���[�v�}�X�^���X�g�̍쐬
                CopyGridListToGrid(pccItemGrpList, ref pccItemGrid);

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
        /// PCC�i�ڃO���[�v�}�X�^�����e�����폜����
        /// </summary>
        /// <param name="pccItemGrid">PCC�i�ڃO���[�v���X�g</param>
        /// <param name="pccItemGrpList">PCC�i�ڃO���[�v���X�g</param>
        /// <param name="pccItemStDict">PCC�i�ڐݒ�f�B�N�V���i���[</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�i�ڃO���[�v�}�X�^�����e�����폜�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>

        public int Delete(ref PccItemGrid pccItemGrid, ref List<PccItemGrp> pccItemGrpList, ref Dictionary<int, List<PccItemSt>> pccItemStDict)
      {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            Object objPccItemGrpWorkList = null;
            ArrayList pccItemGrpWorkListResultList = null;
            ArrayList pccItemStWorkListResultList = null;
            Object objPccItemStWorkList = null;
           
            ArrayList pccItemGrpWorkList = null;
            ArrayList pccItemStWorkList = null;
            List<PccItemSt> pccItemStList = null;
            try
            {
                if (pccItemGrpList == null)
                {
                    return status;
                }
                CopyGrpToWork(out pccItemGrpWorkList, pccItemGrpList);
                if (pccItemGrpWorkList == null || pccItemGrpWorkList.Count == 0)
                {
                    return status;
                }
                objPccItemGrpWorkList = pccItemGrpWorkList as Object;
                if (pccItemStDict != null && pccItemStDict.Count > 0)
                {
                    pccItemStList = new List<PccItemSt>();
                    foreach (KeyValuePair<int, List<PccItemSt>> pccItemPair in pccItemStDict)
                    {
                        pccItemStList.AddRange(pccItemPair.Value);
                    }
                    CopyStToWork(out pccItemStWorkList, pccItemStList);
                    objPccItemStWorkList = pccItemStWorkList as Object;
                
                }
                
                status = _iPccItemGrpDB.Delete(ref objPccItemGrpWorkList, ref objPccItemStWorkList);
                //���ʂ�߂�
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                pccItemGrpWorkListResultList = objPccItemGrpWorkList as ArrayList;

                if (pccItemGrpWorkListResultList != null)
                {
                    CopyWorkToGrp(pccItemGrpWorkListResultList, out pccItemGrpList);

                }


                if (objPccItemStWorkList != null)
                {
                    pccItemStWorkListResultList = objPccItemStWorkList as ArrayList;
                }
                if (pccItemStWorkListResultList != null)
                {
                    CopyWorkToSt(pccItemStWorkListResultList, out pccItemStList);
                    Dictionary<string, Dictionary<int, List<PccItemSt>>> pccItemStDictDict = null;
                    //PCC�i�ڐݒ�f�B�N�V���i���[�̍쐬
                    CopyStListToDict(pccItemStList, out pccItemStDictDict);
                    if (pccItemStDictDict != null && pccItemStDictDict.ContainsKey(pccItemGrid.InqCondition))
                    {
                        pccItemStDict = pccItemStDictDict[pccItemGrid.InqCondition];
                    }


                }
                //PCC�i�ڃO���[�v�}�X�^���X�g�̍쐬
                CopyGridListToGrid(pccItemGrpList, ref pccItemGrid);
               

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
        /// PCC�i�ڃO���[�v�}�X�^�����e��������
        /// </summary>
        /// <param name="pccItemGrid">PCC�i�ڃO���[�v���X�g</param>
        /// <param name="pccItemGrpList">PCC�i�ڃO���[�v���X�g</param>
        /// <param name="pccItemStDict">PCC�i�ڐݒ�f�B�N�V���i���[</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�i�ڃO���[�v�}�X�^�����e���������B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref PccItemGrid pccItemGrid, ref List<PccItemGrp> pccItemGrpList, ref Dictionary<int, List<PccItemSt>> pccItemStDict)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            Object objPccItemGrpWorkList = null;
            ArrayList pccItemGrpWorkListResultList = null;
            ArrayList pccItemGrpWorkList = null;
            ArrayList pccItemStWorkListResultList = null;
            Object objPccItemStWorkList = null;

            
            ArrayList pccItemStWorkList = null;
            List<PccItemSt> pccItemStList = null;
            try
            {
                if (pccItemGrpList == null)
                {
                    return status;
                }
                CopyGrpToWork(out pccItemGrpWorkList, pccItemGrpList);
                if (pccItemGrpWorkList == null || pccItemGrpWorkList.Count == 0)
                {
                    return status;
                }
                objPccItemGrpWorkList = pccItemGrpWorkList as Object;
                if (pccItemStDict != null && pccItemStDict.Count > 0)
                {
                    pccItemStList = new List<PccItemSt>();
                    foreach (KeyValuePair<int, List<PccItemSt>> pccItemPair in pccItemStDict)
                    {
                        pccItemStList.AddRange(pccItemPair.Value);
                    }
                    CopyStToWork(out pccItemStWorkList, pccItemStList);

                    objPccItemStWorkList = pccItemStWorkList as Object;
                }
               //PCC�i�ڃO���[�v�}�X�^�����e��������
               status = _iPccItemGrpDB.RevivalLogicalDelete(ref objPccItemGrpWorkList, ref  objPccItemStWorkList);


                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
                //���ʂ�߂�
                pccItemGrpWorkListResultList = objPccItemGrpWorkList as ArrayList;

                if (pccItemGrpWorkListResultList != null)
                {
                    CopyWorkToGrp(pccItemGrpWorkListResultList, out pccItemGrpList);

                }
                if (objPccItemStWorkList != null)
                {
                    pccItemStWorkListResultList = objPccItemStWorkList as ArrayList;
                }
                if (pccItemStWorkListResultList != null)
                {
                    CopyWorkToSt(pccItemStWorkListResultList, out pccItemStList);
                    Dictionary<string, Dictionary<int, List<PccItemSt>>> pccItemStDictDict = null;
                    //PCC�i�ڐݒ�f�B�N�V���i���[�̍쐬
                    CopyStListToDict(pccItemStList, out pccItemStDictDict);
                    if (pccItemStDictDict != null && pccItemStDictDict.ContainsKey(pccItemGrid.InqCondition))
                    {
                        pccItemStDict = pccItemStDictDict[pccItemGrid.InqCondition];
                    }


                }
                //PCC�i�ڃO���[�v�}�X�^���X�g�̍쐬
                CopyGridListToGrid(pccItemGrpList, ref pccItemGrid);
                

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
        /// PCC�i�ڃf�[�^�����]������
        /// </summary>
        /// <param name="pccItemGrpWorkListResultList">PCC�i�ڃO���[�v���[�N���X�g</param>
        /// <param name="pccItemStWorkListResultList">PCC�i�ڐݒ胏�[�N���X�g</param>
        /// <param name="pccItemGridList">PCC�i�ڃO���b�h���X�g</param>
        /// <param name="pccItemGrpDict">PCC�i�ڃO���[�v�f�B�N�V���i���[</param>
        /// <param name="pccItemStDictDict">PCC�i�ڐݒ�f�B�N�V���i���[</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�i�ڏ����]���������s���B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void CopyWorkToTwoResult(ArrayList pccItemGrpWorkListResultList, ArrayList pccItemStWorkListResultList,
            out List<PccItemGrid> pccItemGridList, out Dictionary<string, List<PccItemGrp>> pccItemGrpDict,
            out Dictionary<string, Dictionary<int, List<PccItemSt>>> pccItemStDictDict)
        {
            pccItemGrpDict = null;
            //�i�ڃO���b�h���X�g
            pccItemGridList = null;
            //PCC�i�ڃO���[�v�}�X�^���X�g
            List<PccItemGrp> pccItemGrpList = null;
            //PCC�i�ڃO���[�v�f�B�N�V���i���[�̍쐬
            pccItemStDictDict = null;
            CopyWorkToGrp(pccItemGrpWorkListResultList, out pccItemGrpList);
            //PCC�i�ڃO���[�v�}�X�^���X�g�̍쐬
            CopyGrpListToDict(pccItemGrpList, out pccItemGrpDict);
            //PCC�i�ڐݒ�}�X�^���X�g
            List<PccItemSt> pccItemStList = null;
            if (pccItemStWorkListResultList != null && pccItemStWorkListResultList.Count > 0)
            {
                CopyWorkToSt(pccItemStWorkListResultList, out pccItemStList);
                //PCC�i�ڐݒ�f�B�N�V���i���[�̍쐬
                CopyStListToDict(pccItemStList, out pccItemStDictDict);
            }
            
            //PCC�i�ڃO���b�h���X�g�̍쐬
            CopyGrpDictToGridList(pccItemGrpDict, out pccItemGridList);

        }


        /// <summary>
        /// PCC�i�ڃO���[�v�}�X�^�����e�]������
        /// </summary>
        /// <param name="pccItemGrpWorkListResultList">PCC�i�ڃO���[�v���[�N���X�g</param>
        /// <param name="pccItemGrpList">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�i�ڃO���[�v�}�X�^�����e�]�������B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void CopyWorkToGrp(ArrayList pccItemGrpWorkListResultList, out List<PccItemGrp> pccItemGrpList)
        {
            pccItemGrpList = null;
            if (pccItemGrpWorkListResultList == null || pccItemGrpWorkListResultList.Count == 0)
            {
                return;
            }
            else
            {
                pccItemGrpList = new List<PccItemGrp>();
                foreach (PccItemGrpWork wkPccItemGrpWork in pccItemGrpWorkListResultList)
                {
                    PccItemGrp pccItemGrp = new PccItemGrp();
                    pccItemGrp.CreateDateTime = wkPccItemGrpWork.CreateDateTime;
                    pccItemGrp.UpdateDateTime = wkPccItemGrpWork.UpdateDateTime;
                    pccItemGrp.InqOriginalEpCd = wkPccItemGrpWork.InqOriginalEpCd.Trim();//@@@@20230303
                    pccItemGrp.InqOriginalSecCd = wkPccItemGrpWork.InqOriginalSecCd.TrimEnd();
                    pccItemGrp.InqOtherEpCd = wkPccItemGrpWork.InqOtherEpCd.TrimEnd();
                    pccItemGrp.InqOtherSecCd = wkPccItemGrpWork.InqOtherSecCd.TrimEnd();
                    pccItemGrp.LogicalDeleteCode = wkPccItemGrpWork.LogicalDeleteCode;
                    pccItemGrp.PccCompanyCode = wkPccItemGrpWork.PccCompanyCode;
                    pccItemGrp.ItemGroupCode = wkPccItemGrpWork.ItemGroupCode;
                    pccItemGrp.ItemGroupName = wkPccItemGrpWork.ItemGroupName;
                    pccItemGrp.ItemGrpDspOdr = wkPccItemGrpWork.ItemGrpDspOdr;
                    pccItemGrp.UpdateFlag = wkPccItemGrpWork.UpdateFlag;
                    //�⍇������ƃR�[�h + �⍇�������_�R�[�h+�⍇�����ƃR�[�h+ �⍇���拒�_�R�[�h
                    pccItemGrp.InqCondition = wkPccItemGrpWork.InqOriginalEpCd.Trim() + wkPccItemGrpWork.InqOriginalSecCd.TrimEnd() //@@@@20230303
                        + wkPccItemGrpWork.InqOtherEpCd.TrimEnd() + wkPccItemGrpWork.InqOtherSecCd.TrimEnd();
                    // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    pccItemGrp.ItemGrpImgCode = wkPccItemGrpWork.ItemGrpImgCode;
                    // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    pccItemGrpList.Add(pccItemGrp);
                }
            }
        }

        /// <summary>
        /// PCC�i�ڃO���[�v�}�X�^�����e�]������
        /// </summary>
        /// <param name="pccItemGrpWorkListResultList">PCC�i�ڃO���[�v���[�N���X�g</param>
        /// <param name="pccItemGrpList">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�i�ڃO���[�v�}�X�^�����e�]�������B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void CopyGrpToWork(out ArrayList pccItemGrpWorkListResultList, List<PccItemGrp> pccItemGrpList)
        {
            pccItemGrpWorkListResultList = null;
            if (pccItemGrpList == null || pccItemGrpList.Count == 0)
            {
                return;
            }
            else
            {
                pccItemGrpWorkListResultList = new ArrayList();
                foreach (PccItemGrp wkPccItemGrp in pccItemGrpList)
                {
                    PccItemGrpWork pccItemGrpWork = new PccItemGrpWork();
                    pccItemGrpWork.CreateDateTime = wkPccItemGrp.CreateDateTime;
                    pccItemGrpWork.UpdateDateTime = wkPccItemGrp.UpdateDateTime;
                    pccItemGrpWork.InqOriginalEpCd = wkPccItemGrp.InqOriginalEpCd.Trim();//@@@@20230303
                    pccItemGrpWork.InqOriginalSecCd = wkPccItemGrp.InqOriginalSecCd;
                    pccItemGrpWork.InqOtherEpCd = wkPccItemGrp.InqOtherEpCd;
                    pccItemGrpWork.InqOtherSecCd = wkPccItemGrp.InqOtherSecCd;
                    pccItemGrpWork.LogicalDeleteCode = wkPccItemGrp.LogicalDeleteCode;
                    pccItemGrpWork.PccCompanyCode = wkPccItemGrp.PccCompanyCode;
                    pccItemGrpWork.ItemGroupCode = wkPccItemGrp.ItemGroupCode;
                    pccItemGrpWork.ItemGroupName = wkPccItemGrp.ItemGroupName;
                    pccItemGrpWork.ItemGrpDspOdr = wkPccItemGrp.ItemGrpDspOdr;
                    pccItemGrpWork.UpdateFlag = wkPccItemGrp.UpdateFlag;
                    // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    pccItemGrpWork.ItemGrpImgCode = wkPccItemGrp.ItemGrpImgCode;
                    // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    pccItemGrpWorkListResultList.Add(pccItemGrpWork);
                }
            }
        }
      
        /// <summary>
        /// PCC�i�ڃO���[�v�}�X�^�����e�]������
        /// </summary>
        /// <param name="pccItemStWorkListResultList">PCC�i�ڐݒ胏�[�N���X�g</param>
        /// <param name="pccItemStList">PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�i�ڃO���[�v�}�X�^�����e�]�������B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void CopyStToWork(out ArrayList pccItemStWorkListResultList, List<PccItemSt> pccItemStList)
        {
            pccItemStWorkListResultList = null;
            if (pccItemStList == null || pccItemStList.Count == 0)
            {
                return;
            }
            else
            {
                pccItemStWorkListResultList = new ArrayList();
                foreach (PccItemSt wkPccItemSt in pccItemStList)
                {
                    PccItemStWork pccItemStWork = new PccItemStWork();
                    pccItemStWork.CreateDateTime = wkPccItemSt.CreateDateTime;
                    pccItemStWork.UpdateDateTime = wkPccItemSt.UpdateDateTime;
                    pccItemStWork.InqOriginalEpCd = wkPccItemSt.InqOriginalEpCd.Trim();//@@@@20230303
                    pccItemStWork.InqOriginalSecCd = wkPccItemSt.InqOriginalSecCd;
                    pccItemStWork.InqOtherEpCd = wkPccItemSt.InqOtherEpCd;
                    pccItemStWork.InqOtherSecCd = wkPccItemSt.InqOtherSecCd;
                    pccItemStWork.LogicalDeleteCode = wkPccItemSt.LogicalDeleteCode;
                    pccItemStWork.PccCompanyCode = wkPccItemSt.PccCompanyCode;
                    pccItemStWork.ItemGroupCode = wkPccItemSt.ItemGroupCode;
                    pccItemStWork.ItemDspPos1 = wkPccItemSt.ItemDspPos1;
                    pccItemStWork.ItemDspPos2 = wkPccItemSt.ItemDspPos2;
                    pccItemStWork.BLGoodsCode = wkPccItemSt.BLGoodsCode;
                    pccItemStWork.ItemQty = wkPccItemSt.ItemQty;
                    pccItemStWork.ItemSelectDiv = wkPccItemSt.ItemSelectDiv;
                    pccItemStWork.UpdateFlag = wkPccItemSt.UpdateFlag;
                    pccItemStWorkListResultList.Add(pccItemStWork);
                }
            }
        }


        /// <summary>
        /// PCC�i�ڐݒ�}�X�^�]������
        /// </summary>
        /// <param name="pccItemStWorkListResultList">PCC�i�ڐݒ胏�[�N���X�g</param>
        /// <param name="pccItemStList">PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <remarks>
        /// <br>Note       : PCC�i�ڃO���[�v�̓]���B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void CopyWorkToSt(ArrayList pccItemStWorkListResultList, out List<PccItemSt> pccItemStList)
        {
            pccItemStList = null;
            if (pccItemStWorkListResultList == null || pccItemStWorkListResultList.Count == 0)
            {
                return;
            }
            else
            {
                pccItemStList = new List<PccItemSt>();
                string blGoodsName = string.Empty;
                foreach (PccItemStWork wkpccItemStWork in pccItemStWorkListResultList)
                {
                    PccItemSt pccItemSt = new PccItemSt();
                    pccItemSt.CreateDateTime = wkpccItemStWork.CreateDateTime;
                    pccItemSt.UpdateDateTime = wkpccItemStWork.UpdateDateTime;
                    pccItemSt.InqOriginalEpCd = wkpccItemStWork.InqOriginalEpCd.Trim();//@@@@20230303
                    pccItemSt.InqOriginalSecCd = wkpccItemStWork.InqOriginalSecCd.TrimEnd();
                    pccItemSt.InqOtherEpCd = wkpccItemStWork.InqOtherEpCd.TrimEnd();
                    pccItemSt.InqOtherSecCd = wkpccItemStWork.InqOtherSecCd.TrimEnd();
                    pccItemSt.LogicalDeleteCode = wkpccItemStWork.LogicalDeleteCode;
                    pccItemSt.PccCompanyCode = wkpccItemStWork.PccCompanyCode;
                    pccItemSt.ItemGroupCode = wkpccItemStWork.ItemGroupCode;
                    pccItemSt.ItemDspPos1 = wkpccItemStWork.ItemDspPos1;
                    pccItemSt.ItemDspPos2 = wkpccItemStWork.ItemDspPos2;
                    pccItemSt.BLGoodsCode = wkpccItemStWork.BLGoodsCode;
                    if (_bLCodeTable != null && _bLCodeTable.Count > 0 &&
                            _bLCodeTable.ContainsKey(wkpccItemStWork.BLGoodsCode))
                    {
                        blGoodsName = _bLCodeTable[wkpccItemStWork.BLGoodsCode] as string;
                    }
                    pccItemSt.BLGoodsName = blGoodsName;
                    pccItemSt.ItemQty = wkpccItemStWork.ItemQty;
                    pccItemSt.ItemSelectDiv = wkpccItemStWork.ItemSelectDiv;
                    pccItemSt.UpdateFlag = wkpccItemStWork.UpdateFlag;
                    pccItemSt.InqCondition = wkpccItemStWork.InqOriginalEpCd.Trim() + wkpccItemStWork.InqOriginalSecCd.TrimEnd() //@@@@20230303
                        + wkpccItemStWork.InqOtherEpCd.TrimEnd() + wkpccItemStWork.InqOtherSecCd.TrimEnd();
                    pccItemStList.Add(pccItemSt);
                }
            }
        }

       
        /// <summary>
        /// PCC�i�ڐݒ�}�X�^���X�g�̍쐬����
        /// </summary>
        /// <param name="pccItemStList">PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <param name="pccItemStDictDict">PCC�i�ڐݒ�f�B�N�V���i���[</param>
        /// <remarks>
        /// <br>Note       : PCC�i�ڃO���[�v���X�g�̍쐬�������s���B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void CopyStListToDict(List<PccItemSt> pccItemStList, out Dictionary<string, Dictionary<int, List<PccItemSt>>> pccItemStDictDict)
        {
            //PCC�i�ڐݒ�f�B�N�V���i���[�̍쐬
            pccItemStDictDict = null;
            //�i�ڃO���[�v�R�[�h�œ���PCC�i�ڐݒ�̃��X�g
            List<PccItemSt> pccItemStListM = null;
            //PCC���ЃR�[�h�œ���PCC�i�ڐݒ�̃f�B�N�V���i���[
            Dictionary<int, List<PccItemSt>> pccItemStDictM = null;
            //�O���PCC�⍇������
            string preStInqCondition = string.Empty;
            //�O��̕i�ڃO���[�v�R�[�h
            int preStItemGroupCode = 0;

            //���������̕i�ڐݒ胊�X�g���ݏꍇ
            if (pccItemStList != null && pccItemStList.Count > 0)
            {
                //�i�ڃO���[�v�R�[�h�œ���PCC�i�ڐݒ�̃��X�g���쐬
                foreach (PccItemSt pccStListM in pccItemStList)
                {
                    if (pccItemStDictDict == null)
                    {
                        pccItemStDictDict = new Dictionary<string, Dictionary<int, List<PccItemSt>>>();
                        pccItemStDictM = new Dictionary<int, List<PccItemSt>>();
                        pccItemStListM = new List<PccItemSt>();
                        preStItemGroupCode = pccStListM.ItemGroupCode;
                        preStInqCondition = pccStListM.InqCondition;
                    }
                    if (preStInqCondition == pccStListM.InqCondition)
                    {
                        if (preStItemGroupCode != pccStListM.ItemGroupCode)
                        {
                            pccItemStDictM.Add(preStItemGroupCode, pccItemStListM);
                            pccItemStListM = new List<PccItemSt>();
                            preStItemGroupCode = pccStListM.ItemGroupCode;
                        }
                        pccItemStListM.Add(pccStListM);
                    }
                    else
                    {
                        pccItemStDictM.Add(preStItemGroupCode, pccItemStListM);
                        pccItemStDictDict.Add(preStInqCondition, pccItemStDictM);
                        preStInqCondition = pccStListM.InqCondition;
                        preStItemGroupCode = pccStListM.ItemGroupCode;
                        pccItemStDictM = new Dictionary<int, List<PccItemSt>>();
                        pccItemStListM = new List<PccItemSt>();
                        pccItemStListM.Add(pccStListM);
                    }

                }
                pccItemStDictM.Add(preStItemGroupCode, pccItemStListM);
                pccItemStDictDict.Add(preStInqCondition, pccItemStDictM);
            }


        }

        /// <summary>
        /// PCC�i�ڃO���[�v�}�X�^���X�g�̍쐬����
        /// </summary>
        /// <param name="pccItemGrpList">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <param name="pccItemGrpDict">PCC�i�ڃO���[�v�f�B�N�V���i���[</param>
        /// <remarks>
        /// <br>Note       : PCC�i�ڃO���[�v�}�X�^���X�g�̍쐬���s���B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void CopyGrpListToDict(List<PccItemGrp> pccItemGrpList, out Dictionary<string, List<PccItemGrp>> pccItemGrpDict)
        {
            //PCC�i�ڃO���[�v�}�X�^���X�g�̍쐬
            string prePccInqCondition = string.Empty;
            pccItemGrpDict = null;
            List<PccItemGrp> pccItemGrpListSmall = null;
            if (pccItemGrpList != null && pccItemGrpList.Count > 0)
            {
                foreach (PccItemGrp pccItemGrpRe in pccItemGrpList)
                {
                    if (pccItemGrpDict == null)
                    {
                        prePccInqCondition = pccItemGrpRe.InqCondition;
                        pccItemGrpDict = new Dictionary<string, List<PccItemGrp>>();
                        pccItemGrpListSmall = new List<PccItemGrp>();
                    }
                    if (prePccInqCondition != pccItemGrpRe.InqCondition)
                    {
                        pccItemGrpDict.Add(prePccInqCondition, pccItemGrpListSmall);
                        prePccInqCondition = pccItemGrpRe.InqCondition;
                        pccItemGrpListSmall = new List<PccItemGrp>();

                    }
                    pccItemGrpListSmall.Add(pccItemGrpRe);

                }
                pccItemGrpDict.Add(prePccInqCondition, pccItemGrpListSmall);
            }

        }

        /// <summary>
        /// PCC�i�ڃO���b�h���X�g�̍쐬�̍쐬����
        /// </summary>
        /// <param name="pccItemGrpDict">PCC�i�ڃO���[�v�f�B�N�V���i���[</param>
        /// <param name="pccItemGridList">PCC�i�ڃO���b�h���X�g</param>
        /// <remarks>
        /// <br>Note       : PCC�i�ڃO���b�h���X�g�̍쐬�̍쐬���s���B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void CopyGrpDictToGridList(Dictionary<string, List<PccItemGrp>> pccItemGrpDict, out List<PccItemGrid> pccItemGridList)
        {
            pccItemGridList = null;
            //PCC�i�ڃO���b�h���X�g�̍쐬
            if (pccItemGrpDict != null && pccItemGrpDict.Count > 0)
            {
                pccItemGridList = new List<PccItemGrid>();
                foreach (KeyValuePair<string, List<PccItemGrp>> pccItemGrpPair in pccItemGrpDict)
                {
                    PccItemGrid pccItemGrid = new PccItemGrid();
                    pccItemGrid.InqCondition = pccItemGrpPair.Key;
                    List<PccItemGrp> pccItemGrpList = pccItemGrpPair.Value as List<PccItemGrp>;
                    CopyGridListToGrid(pccItemGrpList, ref pccItemGrid);

                    
                    pccItemGridList.Add(pccItemGrid);
                }
            }
        }

        /// <summary>
        /// PCC�i�ڃO���b�h���X�g�̍쐬�̍쐬����
        /// </summary>
        /// <param name="pccItemGrpList">PCC�i�ڃO���[�v���X�g</param>
        /// <param name="pccItemGrid">PCC�i�ڃO���b�h</param>
        /// <remarks>
        /// <br>Note       : PCC�i�ڃO���b�h���X�g�̍쐬�̍쐬���s���B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void CopyGridListToGrid(List<PccItemGrp> pccItemGrpList, ref PccItemGrid pccItemGrid)
        {
            if (pccItemGrpList == null)
            {
                return;
            }
            pccItemGrid = new PccItemGrid();
            for(int i = 0; i < pccItemGrpList.Count; i ++)
            {
                PccItemGrp pccItemGrpEach = pccItemGrpList[i];
                if (i == 0)
                {
                    pccItemGrid.CreateDateTime = pccItemGrpEach.CreateDateTime;
                    pccItemGrid.UpdateDateTime = pccItemGrpEach.UpdateDateTime;
                    pccItemGrid.InqOriginalEpCd = pccItemGrpEach.InqOriginalEpCd.Trim();//@@@@20230303
                    pccItemGrid.InqOriginalSecCd = pccItemGrpEach.InqOriginalSecCd;
                    pccItemGrid.InqOtherEpCd = pccItemGrpEach.InqOtherEpCd;
                    pccItemGrid.InqOtherSecCd = pccItemGrpEach.InqOtherSecCd;
                    pccItemGrid.PccCompanyCode = pccItemGrpEach.PccCompanyCode;
                    //PCC���Ж���
                    string pccCompanyName = string.Empty;
                    if (this._customerInfoTable != null && this._customerInfoTable.ContainsKey(pccItemGrpEach.PccCompanyCode))
                    {
                        pccCompanyName = this._customerInfoTable[pccItemGrpEach.PccCompanyCode] as string;

                    }
                    pccItemGrid.PccCompanyName = pccCompanyName;
                    pccItemGrid.LogicalDeleteCode = pccItemGrpEach.LogicalDeleteCode;
                    pccItemGrid.InqCondition = pccItemGrpEach.InqCondition;
                }
                switch (i+1)
                {
                    case 1:
                        {

                            pccItemGrid.ItemGroupCode1 = pccItemGrpEach.ItemGroupCode;
                            pccItemGrid.ItemGroupName1 = pccItemGrpEach.ItemGroupName;
                            pccItemGrid.ItemGrpDspOdr1 = pccItemGrpEach.ItemGrpDspOdr;
                            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            pccItemGrid.ItemGroupCode1 = pccItemGrpEach.ItemGrpImgCode;
                            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            break;
                        }
                    case 2:
                        {

                            pccItemGrid.ItemGroupCode2 = pccItemGrpEach.ItemGroupCode;
                            pccItemGrid.ItemGroupName2 = pccItemGrpEach.ItemGroupName;
                            pccItemGrid.ItemGrpDspOdr2 = pccItemGrpEach.ItemGrpDspOdr;
                            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            pccItemGrid.ItemGroupCode2 = pccItemGrpEach.ItemGrpImgCode;
                            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            break;
                        }
                    case 3:
                        {

                            pccItemGrid.ItemGroupCode3 = pccItemGrpEach.ItemGroupCode;
                            pccItemGrid.ItemGroupName3 = pccItemGrpEach.ItemGroupName;
                            pccItemGrid.ItemGrpDspOdr3 = pccItemGrpEach.ItemGrpDspOdr;
                            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            pccItemGrid.ItemGroupCode3 = pccItemGrpEach.ItemGrpImgCode;
                            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            break;
                        }
                    case 4:
                        {

                            pccItemGrid.ItemGroupCode4 = pccItemGrpEach.ItemGroupCode;
                            pccItemGrid.ItemGroupName4 = pccItemGrpEach.ItemGroupName;
                            pccItemGrid.ItemGrpDspOdr4 = pccItemGrpEach.ItemGrpDspOdr;
                            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            pccItemGrid.ItemGroupCode4 = pccItemGrpEach.ItemGrpImgCode;
                            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            break;
                        }
                    case 5:
                        {

                            pccItemGrid.ItemGroupCode5 = pccItemGrpEach.ItemGroupCode;
                            pccItemGrid.ItemGroupName5 = pccItemGrpEach.ItemGroupName;
                            pccItemGrid.ItemGrpDspOdr5 = pccItemGrpEach.ItemGrpDspOdr;
                            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            pccItemGrid.ItemGroupCode5 = pccItemGrpEach.ItemGrpImgCode;
                            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            break;
                        }
                }

            }
        }

        /// <summary>
        /// �o�l�a�k�R�[�h�f�[�^���[�N�̍쐬����
        /// </summary>
        /// <param name="pMBLGdsCdWorkList">�a�k�R�[�h�f�[�^���[�N���X�g</param>
        /// <param name="bLGoodsCdUMntList">�a�k�R�[�h�f�[�^���X�g</param>
        /// <param name="pccItemGrid">PCC�i�ڃO���b�h</param>
        /// <remarks>
        /// <br>Note       : �o�l�a�k�R�[�h�f�[�^���[�N�̍쐬���s���B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void CopyBlPmToBlSCM(out ArrayList pMBLGdsCdWorkList, ArrayList bLGoodsCdUMntList, PccItemGrid pccItemGrid)
        {
            pMBLGdsCdWorkList = null;
            if (bLGoodsCdUMntList != null && bLGoodsCdUMntList.Count > 0)
            {
                pMBLGdsCdWorkList = new ArrayList();
                foreach (BLGoodsCdUMnt bLGoodsCdUMnt in bLGoodsCdUMntList)
                {
                    if (bLGoodsCdUMnt.LogicalDeleteCode == 0)
                    {
                        PMBLGdsCdWork pMBLGdsCdWork = new PMBLGdsCdWork();
                        pMBLGdsCdWork.InqOriginalEpCd = pccItemGrid.InqOriginalEpCd.Trim();//@@@@20230303
                        pMBLGdsCdWork.InqOriginalSecCd = pccItemGrid.InqOriginalSecCd;
                        pMBLGdsCdWork.InqOtherEpCd = pccItemGrid.InqOtherEpCd;
                        pMBLGdsCdWork.InqOtherSecCd = pccItemGrid.InqOtherSecCd;
                        pMBLGdsCdWork.PccCompanyCode = pccItemGrid.PccCompanyCode;
                        pMBLGdsCdWork.BLGoodsCode = bLGoodsCdUMnt.BLGoodsCode;
                        pMBLGdsCdWork.BLGoodsFullName = bLGoodsCdUMnt.BLGoodsFullName;
                        pMBLGdsCdWork.BLGoodsHalfName = bLGoodsCdUMnt.BLGoodsHalfName;
                        pMBLGdsCdWorkList.Add(pMBLGdsCdWork);
                    }
                }

            }
        }
    }

}
