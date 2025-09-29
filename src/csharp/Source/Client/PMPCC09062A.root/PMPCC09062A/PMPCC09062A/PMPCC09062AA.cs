//****************************************************************************//
// �V�X�e��         : RC.NS
// �v���O��������   : PCC�L�����y�[���ݒ�}�X�^�����e
// �v���O�����T�v   : PCC�L�����y�[���ݒ�}�X�^�����e�A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2011.08.11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : lxl
// �C �� ��  2011/12/05  �C�����e : Redmine#8077 ����߰ݕ\���ݒ�Ͻ�/�ُ�G���[
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
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// PCC�L�����y�[���ݒ�}�X�^�����e�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC�L�����y�[���ݒ�}�X�^�����e�t�h�N���X</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date	   : 2011.08.11</br>
    /// </remarks>  
    public class PccCpMsgStAcs
    {
        #region -- Private Member --
        /// <summary> �L�����y�[���ݒ�A�N�Z�X�N���X </summary>
        private CampaignStAcs _campaignStAcs = null;

        /// <summary> �L�����y�[���ݒ�f�B�N�V���i���[ </summary>
        private Dictionary<int, CampaignSt> _campaignStDic = null;
        private string _enterpriseCode;         // ��ƃR�[�h
        private string _loginSectionCode;
        /// <summary>
        /// �����[�g�I�u�W�F�N�g�C���^�[�t�F�C�X
        /// </summary>
        private IPccCpMsgStDB _iPccCpMsgStDB = null;
        // ���Ӑ�e�[�v��
        private Dictionary<int, PccCmpnySt> _customerHTable;
        // ���Ӑ�e�[�v��
        private Dictionary<string, PccCmpnySt> _customerEndTable;
        private PccCmpnyStAcs _pccCmpnyStAcs = null;
        #endregion

        /// <summary> CustomerHTable </summary>
        public Dictionary<int, PccCmpnySt> CustomerHTable
        {
            get
            {
                return this._customerHTable;
            }
            set
            {
                this._customerHTable = value;
            }

        }

        //PCC�L�����y�[���Ώېݒ�f�[�^���X�g
        private List<PccCpTgtSt> _pccCpTgtStList;
        //PCC�L�����y�[���i�ڐݒ�f�[�^���X�g
        private List<PccCpItmSt> _pccCpItmStList;
        //�i��BL�R�[�h���Hashtable
        private Hashtable _bLCodeTable;
        /// <summary> BLCodeTable </summary>
        public Hashtable BLCodeTable
        {
            get
            {
                return this._bLCodeTable;
            }
            set
            {
                this._bLCodeTable = value;
            }

        }

        //�ڑ���񂪐ݒ�Hashtable
        private Hashtable _scmEpScCntTable = null;

        /// <summary> �ڑ���񂪐ݒ�Hashtable </summary>
        public Hashtable ScmEpScCntTable
        {
            get
            {
                return this._scmEpScCntTable;
            }
            set
            {
                this._scmEpScCntTable = value;
            }

        }

        #region �� Constructor

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[���ݒ�}�X�^�����e�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public PccCpMsgStAcs()
        {
            _iPccCpMsgStDB = MediationPccCpMsgStDB.GetPccCpMsgStDB();
            // ��ƃR�[�h���擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            //���O�C���S���҂̋��_ 
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        }

        #endregion �� Constructor

        #region Public Methods

        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="pccCpMsgStList">PCC�L�����y�[�����b�Z�[�W���X�g</param>
        /// <param name="pccCpTgtStDic">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <param name="pccCpItmStDic">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e�o�^�A�X�V�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int Write(ref  List<PccCpMsgSt> pccCpMsgStList, ref Dictionary<string, PccCpTgtSt> pccCpTgtStDic,
             ref Dictionary<string, PccCpItmSt> pccCpItmStDic)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            //PCC�L�����y�[���Ώېݒ�f�[�^���X�g
            List<PccCpTgtSt> pccCpTgtStList = null;
            if (pccCpTgtStDic != null && pccCpTgtStDic.Count > 0)
            {
                pccCpTgtStList = new List<PccCpTgtSt>(pccCpTgtStDic.Values);
            }
            //PCC�L�����y�[���i�ڐݒ�f�[�^���X�g
            List<PccCpItmSt> pccCpItmStList = null;
            if (pccCpItmStDic != null && pccCpItmStDic.Count > 0)
            {
                pccCpItmStList = new List<PccCpItmSt>(pccCpItmStDic.Values);
            }
            //PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e��������
            status = Write(ref pccCpMsgStList, ref pccCpTgtStList, ref pccCpItmStList);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            //PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[�쐬����
            CopyToPccCpTgtStWorkDic(out pccCpTgtStDic, pccCpTgtStList);
            CopyToPccCpItmStListDic(out pccCpItmStDic, pccCpItmStList);
            return status;
        }

        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="pccCpMsgStList">PCC�L�����y�[�����b�Z�[�W�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="pccCpTgtStList">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <param name="pccCpItmStList">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e�o�^�A�X�V�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int Write(ref List<PccCpMsgSt> pccCpMsgStList, ref List<PccCpTgtSt> pccCpTgtStList, ref List<PccCpItmSt> pccCpItmStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            Object objPccCpMsgStWorkList = null;
            Object objPccCpTgtStWorkList = null;
            Object objPccCpItmStWorkList = null;
            ArrayList pccCpMsgStWorkListResultList = null;
            ArrayList pccCpTgtStWorkListResultList = null;
            ArrayList pccCpItmStWorkListResultList = null;
                       
            ArrayList pccCpMsgStWorkList = null;
            ArrayList pccCpTgtStWorkList = null;
            ArrayList pccCpItmStWorkList = null;

            try
            {

                if (pccCpMsgStList == null)
                {
                    return status;
                }
                CopyToPccCpMsgStWorkFromPccCpMsgSt(out pccCpMsgStWorkList, pccCpMsgStList);
                if (pccCpMsgStWorkList != null  )
                {
                    objPccCpMsgStWorkList = pccCpMsgStWorkList as object;
                }

                if (pccCpTgtStList != null)
                {
                    CopyToPccCpTgtStWorkFromPccCpTgtSt(out pccCpTgtStWorkList, pccCpTgtStList);
                
                }
               if (pccCpTgtStWorkList != null)
                {
                    objPccCpTgtStWorkList = pccCpTgtStWorkList as object;
                }

                if (pccCpItmStList != null)
                {
                    CopyToPccCpItmStWorkFromPccCpItmSt(out pccCpItmStWorkList, pccCpItmStList);
                
                }
                if (pccCpItmStWorkList != null)
                {
                    objPccCpItmStWorkList = pccCpItmStWorkList as object;
                }
                //PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e�o�^�A�X�V����
                status = _iPccCpMsgStDB.Write(ref objPccCpMsgStWorkList, ref objPccCpTgtStWorkList, ref objPccCpItmStWorkList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //���ʂ�߂�
                pccCpMsgStWorkListResultList = objPccCpMsgStWorkList as ArrayList;

                if (pccCpMsgStWorkListResultList != null)
                {
                    CopyToPccCpMsgStFromPccCpMsgStWork(pccCpMsgStWorkListResultList, out pccCpMsgStList);
                }

                pccCpTgtStWorkListResultList = objPccCpTgtStWorkList as ArrayList;

                if (pccCpTgtStWorkListResultList != null)
                {
                    CopyToPccCpTgtStFromPccCpTgtStWork(pccCpTgtStWorkListResultList, out pccCpTgtStList);
                }

                pccCpItmStWorkListResultList = objPccCpItmStWorkList as ArrayList;

                if (pccCpItmStWorkListResultList != null)
                {
                    CopyToPccCpItmStFromPccCpItmStWork(pccCpItmStWorkListResultList, out pccCpItmStList);
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
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCpMsgStList">PCC�L�����y�[�����b�Z�[�W�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="pccCpTgtStDicDic">PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[</param>
        /// <param name="pccCpItmStDicDic">PCC�L�����y�[���i�ڐݒ�f�[�^�f�B�N�V���i���[</param>
        /// <param name="parsePccCpMsgSt">�����L�����y�[�����b�Z�[�W�p�����[�^</param>
        /// <param name="parsePccCpTgtSt">�����L�����y�[���Ώۃp�����[�^</param>
        /// <param name="parsePccCpItmSt">�����L�����y�[���i�ڃp�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e���������B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int Search(out List<PccCpMsgSt> pccCpMsgStList, out Dictionary<string, Dictionary<string, PccCpTgtSt>> pccCpTgtStDicDic,
            out Dictionary<string, Dictionary<string, PccCpItmSt>> pccCpItmStDicDic, PccCpMsgSt parsePccCpMsgSt,
            PccCpTgtSt parsePccCpTgtSt, PccCpItmSt parsePccCpItmSt, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            pccCpTgtStDicDic = null;
            pccCpItmStDicDic = null;
            //PCC�L�����y�[���Ώېݒ�f�[�^���X�g
            List<PccCpTgtSt> pccCpTgtStList = null;
            //PCC�L�����y�[���i�ڐݒ�f�[�^���X�g
            List<PccCpItmSt> pccCpItmStList = null;
            //PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e��������
            status = Search(out pccCpMsgStList, out pccCpTgtStList, out pccCpItmStList, parsePccCpMsgSt, parsePccCpTgtSt,
                parsePccCpItmSt, readMode, logicalMode);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            //PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[�쐬����
            CopyToPccCpTgtStWorkDicDic(out pccCpTgtStDicDic, pccCpTgtStList);
            CopyToPccCpItmStListDicDic(out pccCpItmStDicDic, pccCpItmStList);
            return status;
        }
      
        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCpMsgStList">PCC�L�����y�[�����b�Z�[�W�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="pccCpTgtStList">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <param name="pccCpItmStList">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <param name="parsePccCpMsgSt">�����L�����y�[�����b�Z�[�W�p�����[�^</param>
        /// <param name="parsePccCpTgtSt">�����L�����y�[���Ώۃp�����[�^</param>
        /// <param name="parsePccCpItmSt">�����L�����y�[���i�ڃp�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e���������B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int Search(out List<PccCpMsgSt> pccCpMsgStList, out List<PccCpTgtSt> pccCpTgtStList,
            out List<PccCpItmSt> pccCpItmStList, PccCpMsgSt parsePccCpMsgSt,
            PccCpTgtSt parsePccCpTgtSt, PccCpItmSt parsePccCpItmSt, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            pccCpMsgStList = null;
            pccCpTgtStList = null;
            pccCpItmStList = null;

            Object objPccCpMsgStWorkList = null;
            Object objPccCpTgtStWorkList = null;
            Object objPccCpItmStWorkList = null;
            ArrayList pccCpMsgStWorkListResultList = null;
            ArrayList pccCpTgtStWorkListResultList = null;
            ArrayList pccCpItmStWorkListResultList = null;
            PccCpMsgStWork parsePccCpMsgStWork = null;
            PccCpTgtStWork parsePccCpTgtStWork = null;
            PccCpItmStWork parsePccCpItmStWork = null;
           
            try
            {
                parsePccCpMsgStWork = new PccCpMsgStWork();
                parsePccCpTgtStWork = new PccCpTgtStWork();
                parsePccCpItmStWork = new PccCpItmStWork();



                parsePccCpMsgStWork.InqOtherEpCd = parsePccCpMsgSt.InqOtherEpCd;
                parsePccCpMsgStWork.InqOtherSecCd = parsePccCpMsgSt.InqOtherSecCd;

                parsePccCpTgtStWork.InqOtherEpCd = parsePccCpItmSt.InqOtherEpCd;
                parsePccCpTgtStWork.InqOtherSecCd = parsePccCpItmSt.InqOtherSecCd;

                parsePccCpItmStWork.InqOtherEpCd = parsePccCpItmSt.InqOtherEpCd;
                parsePccCpItmStWork.InqOtherSecCd = parsePccCpItmSt.InqOtherSecCd;
               
                //PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e��������
                status = _iPccCpMsgStDB.Search(out objPccCpMsgStWorkList, out objPccCpTgtStWorkList, out objPccCpItmStWorkList, parsePccCpMsgStWork, parsePccCpTgtStWork, parsePccCpItmStWork, readMode, logicalMode, 0);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
               
                //���ʂ�߂�
                pccCpMsgStWorkListResultList = objPccCpMsgStWorkList as ArrayList;
              
                CopyToPccCpMsgStFromPccCpMsgStWork(pccCpMsgStWorkListResultList, out pccCpMsgStList);


                pccCpTgtStWorkListResultList = objPccCpTgtStWorkList as ArrayList;
               

                CopyToPccCpTgtStFromPccCpTgtStWork(pccCpTgtStWorkListResultList, out pccCpTgtStList);


                pccCpItmStWorkListResultList = objPccCpItmStWorkList as ArrayList;

                CopyToPccCpItmStFromPccCpItmStWork(pccCpItmStWorkListResultList, out pccCpItmStList);
                        
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
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCpMsgStList">PCC�L�����y�[�����b�Z�[�W�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="pccCpTgtStList">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <param name="pccCpItmStList">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e���������B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int Read(ref List<PccCpMsgSt> pccCpMsgStList, ref List<PccCpTgtSt> pccCpTgtStList, ref List<PccCpItmSt> pccCpItmStList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            Object objPccCpMsgStWorkList = null;
            Object objPccCpTgtStWorkList = null;
            Object objPccCpItmStWorkList = null;
            ArrayList pccCpMsgStWorkListResultList = null;
            ArrayList pccCpTgtStWorkListResultList = null;
            ArrayList pccCpItmStWorkListResultList = null;

            ArrayList pccCpMsgStWorkList = null;
            ArrayList pccCpTgtStWorkList = null;
            ArrayList pccCpItmStWorkList = null;
            try
            {
                 if (pccCpMsgStList == null)
                {
                    return status;
                }
                CopyToPccCpMsgStWorkFromPccCpMsgSt(out pccCpMsgStWorkList, pccCpMsgStList);
                if (pccCpMsgStWorkList != null  )
                {
                    objPccCpMsgStWorkList = pccCpMsgStWorkList as object;
                }

                if (pccCpTgtStList != null)
                {
                    CopyToPccCpTgtStWorkFromPccCpTgtSt(out pccCpTgtStWorkList, pccCpTgtStList);
                
                }
               if (pccCpTgtStWorkList != null)
                {
                    objPccCpTgtStWorkList = pccCpTgtStWorkList as object;
                }

                if (pccCpItmStList != null)
                {
                    CopyToPccCpItmStWorkFromPccCpItmSt(out pccCpItmStWorkList, pccCpItmStList);
                
                }
                if (pccCpItmStWorkList != null)
                {
                    objPccCpItmStWorkList = pccCpItmStWorkList as object;
                }
                //PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e��������
                status = _iPccCpMsgStDB.Read(ref objPccCpMsgStWorkList, ref objPccCpTgtStWorkList, ref objPccCpItmStWorkList, readMode, logicalMode, 0);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //���ʂ�߂�
                pccCpMsgStWorkListResultList = objPccCpMsgStWorkList as ArrayList;

                if (pccCpMsgStWorkListResultList != null)
                {
                    CopyToPccCpMsgStFromPccCpMsgStWork(pccCpMsgStWorkListResultList, out pccCpMsgStList);
                }

                pccCpTgtStWorkListResultList = objPccCpTgtStWorkList as ArrayList;

                if (pccCpTgtStWorkListResultList != null)
                {
                    CopyToPccCpTgtStFromPccCpTgtStWork(pccCpTgtStWorkListResultList, out pccCpTgtStList);
                }

                pccCpItmStWorkListResultList = objPccCpItmStWorkList as ArrayList;

                if (pccCpItmStWorkListResultList != null)
                {
                    CopyToPccCpItmStFromPccCpItmStWork(pccCpItmStWorkListResultList, out pccCpItmStList);
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
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccCpMsgStList">PCC�L�����y�[�����b�Z�[�W�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="pccCpTgtStDic">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <param name="pccCpItmStDic">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e�_���폜�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int LogicalDelete(ref  List<PccCpMsgSt> pccCpMsgStList, ref Dictionary<string, PccCpTgtSt> pccCpTgtStDic,
             ref Dictionary<string, PccCpItmSt> pccCpItmStDic)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            //PCC�L�����y�[���Ώېݒ�f�[�^���X�g
            List<PccCpTgtSt> pccCpTgtStList = null;
            if (pccCpTgtStDic != null && pccCpTgtStDic.Count > 0)
            {
                pccCpTgtStList = new List<PccCpTgtSt>(pccCpTgtStDic.Values);
            }
            //PCC�L�����y�[���i�ڐݒ�f�[�^���X�g
            List<PccCpItmSt> pccCpItmStList = null;
            if (pccCpItmStDic != null && pccCpItmStDic.Count > 0)
            {
                pccCpItmStList = new List<PccCpItmSt>(pccCpItmStDic.Values);
            }
            //PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e��������
            status = LogicalDelete(ref pccCpMsgStList, ref pccCpTgtStList, ref pccCpItmStList);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            //PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[�쐬����
            CopyToPccCpTgtStWorkDic(out pccCpTgtStDic, pccCpTgtStList);
            CopyToPccCpItmStListDic(out pccCpItmStDic, pccCpItmStList);
            return status;
        }

        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccCpMsgStList">PCC�L�����y�[�����b�Z�[�W�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="pccCpTgtStList">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <param name="pccCpItmStList">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e�_���폜�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int LogicalDelete(ref List<PccCpMsgSt> pccCpMsgStList, ref List<PccCpTgtSt> pccCpTgtStList, ref List<PccCpItmSt> pccCpItmStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            Object objPccCpMsgStWorkList = null;
            Object objPccCpTgtStWorkList = null;
            Object objPccCpItmStWorkList = null;
            ArrayList pccCpMsgStWorkListResultList = null;
            ArrayList pccCpTgtStWorkListResultList = null;
            ArrayList pccCpItmStWorkListResultList = null;

            ArrayList pccCpMsgStWorkList = null;
            ArrayList pccCpTgtStWorkList = null;
            ArrayList pccCpItmStWorkList = null;
            try
            {
                if (pccCpMsgStList == null)
                {
                    return status;
                }
                CopyToPccCpMsgStWorkFromPccCpMsgSt(out pccCpMsgStWorkList, pccCpMsgStList);
                if (pccCpMsgStWorkList != null)
                {
                    objPccCpMsgStWorkList = pccCpMsgStWorkList as object;
                }

                if (pccCpTgtStList != null)
                {
                    CopyToPccCpTgtStWorkFromPccCpTgtSt(out pccCpTgtStWorkList, pccCpTgtStList);
                
                }
                if (pccCpTgtStWorkList != null)
                {
                    objPccCpTgtStWorkList = pccCpTgtStWorkList as object;
                }

                if (pccCpItmStList != null)
                {
                    CopyToPccCpItmStWorkFromPccCpItmSt(out pccCpItmStWorkList, pccCpItmStList);
                
                }
                if (pccCpItmStWorkList != null)
                {
                    objPccCpItmStWorkList = pccCpItmStWorkList as object;
                }

                //PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e�_���폜����
                status = _iPccCpMsgStDB.LogicalDelete(ref objPccCpMsgStWorkList, ref objPccCpTgtStWorkList, ref objPccCpItmStWorkList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //���ʂ�߂�
                pccCpMsgStWorkListResultList = objPccCpMsgStWorkList as ArrayList;

                if (pccCpMsgStWorkListResultList != null)
                {
                    CopyToPccCpMsgStFromPccCpMsgStWork(pccCpMsgStWorkListResultList, out pccCpMsgStList);
                }

                pccCpTgtStWorkListResultList = objPccCpTgtStWorkList as ArrayList;

                if (pccCpTgtStWorkListResultList != null)
                {
                    CopyToPccCpTgtStFromPccCpTgtStWork(pccCpTgtStWorkListResultList, out pccCpTgtStList);
                }

                pccCpItmStWorkListResultList = objPccCpItmStWorkList as ArrayList;

                if (pccCpItmStWorkListResultList != null)
                {
                    CopyToPccCpItmStFromPccCpItmStWork(pccCpItmStWorkListResultList, out pccCpItmStList);
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
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e�����폜����
        /// </summary>
        /// <param name="pccCpMsgStList"></param>
        /// <param name="pccCpTgtStDic"></param>
        /// <param name="pccCpItmStDic"></param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e�����폜�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int Delete(ref  List<PccCpMsgSt> pccCpMsgStList, ref Dictionary<string, PccCpTgtSt> pccCpTgtStDic,
             ref Dictionary<string,PccCpItmSt> pccCpItmStDic)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            //PCC�L�����y�[���Ώېݒ�f�[�^���X�g
            List<PccCpTgtSt> pccCpTgtStList = null;
            if (pccCpTgtStDic != null && pccCpTgtStDic.Count > 0)
            {
                pccCpTgtStList = new List<PccCpTgtSt>(pccCpTgtStDic.Values);
            }
            //PCC�L�����y�[���i�ڐݒ�f�[�^���X�g
            List<PccCpItmSt> pccCpItmStList = null;
            if (pccCpItmStDic != null && pccCpItmStDic.Count > 0)
            {
                pccCpItmStList = new List<PccCpItmSt>(pccCpItmStDic.Values);
            }
            //PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e��������
            status = Delete(ref pccCpMsgStList, ref pccCpTgtStList, ref pccCpItmStList);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            //PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[�쐬����
            CopyToPccCpTgtStWorkDic(out pccCpTgtStDic, pccCpTgtStList);
            CopyToPccCpItmStListDic(out pccCpItmStDic, pccCpItmStList);
            return status;
        }

        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e�����폜����
        /// </summary>
        /// <param name="pccCpMsgStList">PCC�L�����y�[�����b�Z�[�W�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="pccCpTgtStList">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <param name="pccCpItmStList">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e�����폜�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int Delete(ref List<PccCpMsgSt> pccCpMsgStList, ref List<PccCpTgtSt> pccCpTgtStList, ref List<PccCpItmSt> pccCpItmStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            Object objPccCpMsgStWorkList = null;
            Object objPccCpTgtStWorkList = null;
            Object objPccCpItmStWorkList = null;
            ArrayList pccCpMsgStWorkListResultList = null;
            ArrayList pccCpTgtStWorkListResultList = null;
            ArrayList pccCpItmStWorkListResultList = null;

            ArrayList pccCpMsgStWorkList = null;
            ArrayList pccCpTgtStWorkList = null;
            ArrayList pccCpItmStWorkList = null;
            try
            {
                if (pccCpMsgStList == null)
                {
                    return status;
                }
                CopyToPccCpMsgStWorkFromPccCpMsgSt(out pccCpMsgStWorkList, pccCpMsgStList);
                if (pccCpMsgStWorkList != null)
                {
                    objPccCpMsgStWorkList = pccCpMsgStWorkList as object;
                }

                CopyToPccCpTgtStWorkFromPccCpTgtSt(out pccCpTgtStWorkList, pccCpTgtStList);
                if (pccCpTgtStWorkList != null)
                {
                    objPccCpTgtStWorkList = pccCpTgtStWorkList as object;
                }

                CopyToPccCpItmStWorkFromPccCpItmSt(out pccCpItmStWorkList, pccCpItmStList);
                if (pccCpItmStWorkList != null)
                {
                    objPccCpItmStWorkList = pccCpItmStWorkList as object;
                }

                //PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e�����폜����
                status = _iPccCpMsgStDB.Delete(ref objPccCpMsgStWorkList, ref objPccCpTgtStWorkList, ref objPccCpItmStWorkList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //���ʂ�߂�
                pccCpMsgStWorkListResultList = objPccCpMsgStWorkList as ArrayList;

                if (pccCpMsgStWorkListResultList != null)
                {
                    CopyToPccCpMsgStFromPccCpMsgStWork(pccCpMsgStWorkListResultList, out pccCpMsgStList);
                }

                pccCpTgtStWorkListResultList = objPccCpTgtStWorkList as ArrayList;

                if (pccCpTgtStWorkListResultList != null)
                {
                    CopyToPccCpTgtStFromPccCpTgtStWork(pccCpTgtStWorkListResultList, out pccCpTgtStList);
                }

                pccCpItmStWorkListResultList = objPccCpItmStWorkList as ArrayList;

                if (pccCpItmStWorkListResultList != null)
                {
                    CopyToPccCpItmStFromPccCpItmStWork(pccCpItmStWorkListResultList, out pccCpItmStList);
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
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCpMsgStList">PCC�L�����y�[�����b�Z�[�W�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="pccCpTgtStDic">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <param name="pccCpItmStDic">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e���������B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref  List<PccCpMsgSt> pccCpMsgStList, ref Dictionary<string, PccCpTgtSt> pccCpTgtStDic,
             ref Dictionary<string, PccCpItmSt> pccCpItmStDic)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            //PCC�L�����y�[���Ώېݒ�f�[�^���X�g
            List<PccCpTgtSt> pccCpTgtStList = null;
            if (pccCpTgtStDic != null && pccCpTgtStDic.Count > 0)
            {
                pccCpTgtStList = new List<PccCpTgtSt>(pccCpTgtStDic.Values);
            }
            //PCC�L�����y�[���i�ڐݒ�f�[�^���X�g
            List<PccCpItmSt> pccCpItmStList = null;
            if (pccCpItmStDic != null && pccCpItmStDic.Count > 0)
            {
                pccCpItmStList = new List<PccCpItmSt>(pccCpItmStDic.Values);
            }
            //PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e��������
            status = RevivalLogicalDelete(ref pccCpMsgStList, ref pccCpTgtStList, ref pccCpItmStList);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            //PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[�쐬����
            CopyToPccCpTgtStWorkDic(out pccCpTgtStDic, pccCpTgtStList);
            CopyToPccCpItmStListDic(out pccCpItmStDic, pccCpItmStList);
            return status;
        }
   
        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCpMsgStList">PCC�L�����y�[�����b�Z�[�W�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="pccCpTgtStList">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <param name="pccCpItmStList">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e���������B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref List<PccCpMsgSt> pccCpMsgStList, ref List<PccCpTgtSt> pccCpTgtStList, ref List<PccCpItmSt> pccCpItmStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            Object objPccCpMsgStWorkList = null;
            Object objPccCpTgtStWorkList = null;
            Object objPccCpItmStWorkList = null;
            ArrayList pccCpMsgStWorkListResultList = null;
            ArrayList pccCpTgtStWorkListResultList = null;
            ArrayList pccCpItmStWorkListResultList = null;

            ArrayList pccCpMsgStWorkList = null;
            ArrayList pccCpTgtStWorkList = null;
            ArrayList pccCpItmStWorkList = null;
            try
            {
                if (pccCpMsgStList == null)
                {
                    return status;
                }
                CopyToPccCpMsgStWorkFromPccCpMsgSt(out pccCpMsgStWorkList, pccCpMsgStList);
                if (pccCpMsgStWorkList != null)
                {
                    objPccCpMsgStWorkList = pccCpMsgStWorkList as object;
                }

                if (pccCpTgtStList != null)
                {
                    CopyToPccCpTgtStWorkFromPccCpTgtSt(out pccCpTgtStWorkList, pccCpTgtStList);
                
                }
                if (pccCpTgtStWorkList != null)
                {
                    objPccCpTgtStWorkList = pccCpTgtStWorkList as object;
                }

                if (pccCpItmStList != null)
                {
                    CopyToPccCpItmStWorkFromPccCpItmSt(out pccCpItmStWorkList, pccCpItmStList);
               
                }
                 if (pccCpItmStWorkList != null)
                {
                    objPccCpItmStWorkList = pccCpItmStWorkList as object;
                }
                //PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e��������
                status = _iPccCpMsgStDB.RevivalLogicalDelete(ref objPccCpMsgStWorkList, ref objPccCpTgtStWorkList, ref objPccCpItmStWorkList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //���ʂ�߂�
                pccCpMsgStWorkListResultList = objPccCpMsgStWorkList as ArrayList;

                if (pccCpMsgStWorkListResultList != null)
                {
                    CopyToPccCpMsgStFromPccCpMsgStWork(pccCpMsgStWorkListResultList, out pccCpMsgStList);
                }

                pccCpTgtStWorkListResultList = objPccCpTgtStWorkList as ArrayList;

                if (pccCpTgtStWorkListResultList != null)
                {
                    CopyToPccCpTgtStFromPccCpTgtStWork(pccCpTgtStWorkListResultList, out pccCpTgtStList);
                }

                pccCpItmStWorkListResultList = objPccCpItmStWorkList as ArrayList;

                if (pccCpItmStWorkListResultList != null)
                {
                    CopyToPccCpItmStFromPccCpItmStWork(pccCpItmStWorkListResultList, out pccCpItmStList);
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
        /// �L�����y�[���R�[�h���PCC�L�����y�[���ݒ�捞����
        /// </summary>
        /// <param name="campaignCode">�L�����y�[���R�[�h</param>
        /// <param name="pccCpMsgSt">PCC�L�����y�[�����b�Z�[�W�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="pccCpTgtStList">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <param name="pccCpItmStList">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[���ݒ�捞�������s���B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public void GetCampaignInfo(int campaignCode, out PccCpMsgSt pccCpMsgSt, out List<PccCpTgtSt> pccCpTgtStList,
             out List<PccCpItmSt> pccCpItmStList)
        {
            pccCpMsgSt = null;
            pccCpTgtStList = null;
            pccCpItmStList = null;
            // �L�����y�[�����̏��̎擾
            if (_campaignStDic == null || _campaignStDic.Count == 0)
            {
                // �L�����y�[���ݒ胊�X�g�擾
                GetCampaignStList();
            }
            if (_campaignStDic != null && _campaignStDic.Count > 0 && _campaignStDic.ContainsKey(campaignCode))
            {
                CampaignSt campaignSt = _campaignStDic[campaignCode];
                pccCpMsgSt = new PccCpMsgSt();
                pccCpMsgSt.CampaignCode = campaignSt.CampaignCode;
                pccCpMsgSt.CampaignName = campaignSt.CampaignName;
                pccCpMsgSt.CampaignObjDiv = campaignSt.CampaignObjDiv;
                pccCpMsgSt.ApplyStaDate = TDateTime.DateTimeToLongDate(campaignSt.ApplyStaDate);
                pccCpMsgSt.ApplyEndDate = TDateTime.DateTimeToLongDate(campaignSt.ApplyEndDate);
                
            }
            // �L�����y�[���Ώۓ��Ӑ�ݒ���̎擾
            if (_pccCpTgtStList == null || _pccCpTgtStList.Count == 0)
            {
                GetCampaignLinkList();
            }
            if (_pccCpTgtStList != null && _pccCpTgtStList.Count > 0)
            {
                pccCpTgtStList = new List<PccCpTgtSt>();
                foreach (PccCpTgtSt pccCpTgtSt in _pccCpTgtStList)
                {
                    if (pccCpTgtSt.CampaignCode == campaignCode)
                    {
                        pccCpTgtStList.Add(pccCpTgtSt);
                    }
                }
            }
            //�L�����y�[���Ώۏ��i�ݒ�}�X�^���̎擾
            if (_pccCpItmStList == null || _pccCpItmStList.Count == 0)
            {
                GetCampaignObjGoodsStList();
            }
            if (_pccCpItmStList != null && _pccCpItmStList.Count > 0)
            {
                pccCpItmStList = new List<PccCpItmSt>();
                Hashtable pccCpSHt = new Hashtable();
                
                foreach (PccCpItmSt pccCpItmSt in _pccCpItmStList)
                {
                    if (pccCpItmSt.CampaignCode == campaignCode)
                    {
                        if (!pccCpSHt.ContainsKey(pccCpItmSt.BLGoodsCode))
                        {
                            pccCpItmStList.Add(pccCpItmSt);
                            pccCpSHt.Add(pccCpItmSt.BLGoodsCode, pccCpItmSt);
                        }
                    }
                }
            }
        }

      
        #region �ŐV���擾
        /// <summary>
        /// �ŐV���擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ŐV���̎擾���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public void Renewal()
        {
            // �L�����y�[���ݒ胊�X�g�擾
            GetCampaignStList();
            //���Аݒ蓾�Ӑ�ݒ�}�X�^�擾����
            GetCustomerHTable();
            //�L�����y�[���Ώۓ��Ӑ�ݒ胊�X�g�擾
            GetCampaignLinkList();
            //�L�����y�[���Ώۏ��i�ݒ�}�X�^���̎擾
            GetCampaignObjGoodsStList();
            //BLCode���擾
            GetAllBLGoodsCdUMnt();
            //�S�Đڑ���񂪐ݒ�Hashtable���擾
            GetAllScmEpScCnt();
        }
        #endregion

        #region �L�����y�[���擾
        /// <summary>
        /// �L�����y�[�����擾
        /// </summary>
        /// <param name="campaignCode">�L�����y�[���R�[�h</param>
        /// <returns>�L�����y�[��</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[�����̎擾���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public CampaignSt GetCampaignSt(int campaignCode)
        {
            CampaignSt campaignSt = null;

            if (_campaignStDic == null)
            {
                // �L�����y�[���ݒ胊�X�g�擾
                GetCampaignStList();
            }

            if (_campaignStDic.ContainsKey(campaignCode))
            {
                // �f�B�N�V���i���[�ɑ���
                campaignSt = _campaignStDic[campaignCode];
            }
            else
            {
                // �f�B�N�V���i���[�ɑ��݂��Ȃ��̂ŁA�}�X�^����Ǎ�
                campaignSt = ReadCampaignSt(campaignCode);
            }
            return campaignSt;
        }

        /// <summary>
        /// �L�����y�[���ݒ胊�X�g�擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ݒ�}�X�^�̎擾���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private void GetCampaignStList()
        {
            if (_campaignStAcs == null)
            {
                _campaignStAcs = new CampaignStAcs();
            }
            _campaignStDic = null;
            ArrayList retList;

            // �S����
            int status = _campaignStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)  //DEL 2011/12/5 lxl Redmine#8077
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))     //ADD 2011/12/5 lxl Redmine#8077
            {
                _campaignStDic = new Dictionary<int, CampaignSt>();
            
                foreach (CampaignSt campaignSt in retList)
                {
                    if (campaignSt.LogicalDeleteCode != 0)
                    {
                        continue;
                    }

                    if (!_campaignStDic.ContainsKey(campaignSt.CampaignCode))
                    {
                        _campaignStDic.Add(campaignSt.CampaignCode, campaignSt);
                    }
                }
            }
        }

        /// <summary>
        /// �L�����y�[���ݒ�}�X�^�Ǎ�����
        /// </summary>
        /// <param name="campaignCode">�L�����y�[���R�[�h</param>
        /// <returns>�L�����y�[���ݒ�f�[�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ݒ�}�X�^�̎擾���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private CampaignSt ReadCampaignSt(int campaignCode)
        {
            if (_campaignStAcs == null)
            {
                _campaignStAcs = new CampaignStAcs();
            }

            CampaignSt campaignSt;
            int status = _campaignStAcs.Read(out campaignSt, LoginInfoAcquisition.EnterpriseCode, campaignCode);
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                (campaignSt.LogicalDeleteCode == 0))
            {
                return campaignSt;
            }
            else
            {
                campaignSt = null;
            }

            return campaignSt;
        }

        /// <summary>
        /// �L�����y�[���Ώۓ��Ӑ�ݒ胊�X�g�擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ݒ�}�X�^�̎擾���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private void GetCampaignLinkList()
        {
            // �L�����y�[���Ώۓ��Ӑ�ݒ���̎擾
            CampaignLinkAcs campaignLinkAcs = new CampaignLinkAcs();
            ArrayList campaignLinkArrList = null;
            _pccCpTgtStList = null;
            int status = campaignLinkAcs.SearchAll(out campaignLinkArrList, LoginInfoAcquisition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                _pccCpTgtStList = new List<PccCpTgtSt>();
                PccCmpnySt pccCmpnySt = null;
                foreach (CampaignLink wkCampaignLink in campaignLinkArrList)
                {
                    if (wkCampaignLink.LogicalDeleteCode != 0)
                    {
                        continue;
                    }
                    //PCC���Џ��̐ݒ�
                    if (this._customerHTable != null && this._customerHTable.ContainsKey(wkCampaignLink.CustomerCode))
                    {
                        PccCpTgtSt pccCpTgtSt = new PccCpTgtSt();
                        pccCpTgtSt.CampaignCode = wkCampaignLink.CampaignCode;
                        pccCpTgtSt.CustomerCode = wkCampaignLink.CustomerCode;
                        pccCpTgtSt.InqOtherEpCd = LoginInfoAcquisition.EnterpriseCode;
                        pccCpTgtSt.InqOtherSecCd = LoginInfoAcquisition.Employee.BelongSectionCode;

                        pccCmpnySt = this._customerHTable[wkCampaignLink.CustomerCode];
                        pccCpTgtSt.CustomerName = pccCmpnySt.PccCompanyName;
                        pccCpTgtSt.InqOriginalEpCd = pccCmpnySt.InqOriginalEpCd.Trim();//@@@@20230303
                        pccCpTgtSt.InqOriginalSecCd = pccCmpnySt.InqOriginalSecCd;
                        _pccCpTgtStList.Add(pccCpTgtSt);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^���̎擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^���̎擾���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private void GetCampaignObjGoodsStList()
        {
            //�L�����y�[���Ώۏ��i�ݒ�}�X�^���̎擾
            CampaignObjGoodsStAcs campaignObjGoodsStAcs = new CampaignObjGoodsStAcs();
            _pccCpItmStList = null;
            List<CampaignObjGoodsSt> campaignObjGoodsStList = null;
            int status = campaignObjGoodsStAcs.Search(out campaignObjGoodsStList, LoginInfoAcquisition.EnterpriseCode, ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                _pccCpItmStList = new List<PccCpItmSt>();
                foreach (CampaignObjGoodsSt campaignObjGoodsSt in campaignObjGoodsStList)
                {
                    if (campaignObjGoodsSt.BLGoodsCode != 0)
                    {
                        PccCpItmSt pccCpItmSt = new PccCpItmSt();
                        pccCpItmSt.CampaignCode = campaignObjGoodsSt.CampaignCode;
                        pccCpItmSt.BLGoodsCode = campaignObjGoodsSt.BLGoodsCode;
                        pccCpItmSt.GoodsNameKana = GetBLGoodsName(campaignObjGoodsSt.BLGoodsCode);
                        _pccCpItmStList.Add(pccCpItmSt);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        #endregion

        #region BLCode���擾
        /// <summary>
        /// �S��BLCode���擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : �S��BLCode�����擾���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        public void GetAllBLGoodsCdUMnt()
        {
            //BLCode
            ArrayList bLCodeList = null;
            _bLCodeTable = null;
            BLGoodsCdAcs bLGoodsCdAcs = new BLGoodsCdAcs();
            int status = bLGoodsCdAcs.SearchAll(out bLCodeList, this._enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                _bLCodeTable = new Hashtable();
                foreach (BLGoodsCdUMnt bLGoodsCdUMnt in bLCodeList)
                {
                    if (bLGoodsCdUMnt.LogicalDeleteCode == 0 && !_bLCodeTable.ContainsKey(bLGoodsCdUMnt.BLGoodsCode))
                    {
                        _bLCodeTable.Add(bLGoodsCdUMnt.BLGoodsCode, bLGoodsCdUMnt);
                    }
                }
            }
        }

        /// <summary>
        /// BLCode���擾
        /// </summary>
        /// <param name="blCode">BL�R�[�h</param>
        /// <remarks>
        /// <returns>BLCode���</returns>
        /// <br>Note       : LCode�����擾���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private BLGoodsCdUMnt GetBLGoodsCdUMnt(int blCode)
        {
            BLGoodsCdUMnt bLGoodsCdUMnt = null;
            if (_bLCodeTable != null && _bLCodeTable.ContainsKey(blCode))
            {
                bLGoodsCdUMnt = _bLCodeTable[blCode] as BLGoodsCdUMnt;
            }
            return bLGoodsCdUMnt;
        }

        /// <summary>
        /// BLCode���i���̃J�i���擾
        /// </summary>
        /// <param name="blCode">BL�R�[�h</param>
        /// <remarks>
        /// <returns>���i���̃J�i</returns>
        /// <br>Note       : BLCode���i���̃J�i�����擾���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private string GetBLGoodsName(int blCode)
        {
            string goodsName = string.Empty;
            BLGoodsCdUMnt bLGoodsCdUMnt = GetBLGoodsCdUMnt(blCode);
            if (bLGoodsCdUMnt != null)
            {
                goodsName = bLGoodsCdUMnt.BLGoodsHalfName;
            }
            return goodsName;
        }
        #endregion

        #region �S�Đڑ����擾
        /// <summary>
        /// �S�Đڑ���񂪐ݒ�Hashtable���擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : �S�Đڑ���񂪐ݒ�Hashtable�����擾���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        public void GetAllScmEpScCnt()
        {
            List<ScmEpScCnt> scmEpScCntList = null;
            _scmEpScCntTable = null;
            List<ScmEpCnect> scmEpCnectList = null;
            bool msgDiv;
            string errMsg = string.Empty;
            ScmEpScCntAcs scmEpScCntAcs = new ScmEpScCntAcs();
            int status = scmEpScCntAcs.SearchAll(string.Empty, string.Empty, ConstantManagement.LogicalMode.GetData0, out scmEpCnectList, out scmEpScCntList, out msgDiv, out errMsg);
           
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                _scmEpScCntTable = new Hashtable();
                string scmKey = string.Empty;
                foreach (ScmEpScCnt scmEpScCnt in scmEpScCntList)
                {
                    if (scmEpScCnt.CnectOtherEpCd.Equals(this._enterpriseCode) && scmEpScCnt.CnectOtherSecCd.Equals(this._loginSectionCode))
                    {
                        scmKey = scmEpScCnt.CnectOriginalEpCd.TrimEnd() + scmEpScCnt.CnectOriginalSecCd.TrimEnd()
                            + scmEpScCnt.CnectOtherEpCd.TrimEnd() + scmEpScCnt.CnectOtherSecCd.TrimEnd();
                        if (!_scmEpScCntTable.ContainsKey(scmKey))
                        {
                            _scmEpScCntTable.Add(scmKey, scmEpScCnt);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        #endregion

        #region ���Аݒ蓾�Ӑ�ݒ�}�X�^�擾����
        /// <summary>
        /// ���Аݒ蓾�Ӑ�ݒ�}�X�^�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Аݒ蓾�Ӑ�ݒ�}�X�^���擾���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public void GetCustomerHTable()
        {
            if (this._pccCmpnyStAcs == null)
            {
                _pccCmpnyStAcs = new PccCmpnyStAcs();
            }
            PccCmpnySt parsePccCmpnySt = new PccCmpnySt();
            parsePccCmpnySt.InqOtherEpCd = this._enterpriseCode;
            parsePccCmpnySt.InqOtherSecCd = this._loginSectionCode;
            List<PccCmpnySt> pccCmpnyStList = null;
            if (this._customerHTable == null)
            {
                this._customerHTable = new Dictionary<int, PccCmpnySt>();
                this._customerEndTable = new Dictionary<string, PccCmpnySt>();
            }
            else
            {
                this._customerHTable.Clear();
                this._customerEndTable.Clear();
            }
            int status = this._pccCmpnyStAcs.Search(out pccCmpnyStList, parsePccCmpnySt, 0, ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (PccCmpnySt pccCmpnySt in pccCmpnyStList)
                {
                    string inqCondition = pccCmpnySt.InqOriginalEpCd.Trim() + pccCmpnySt.InqOriginalSecCd.TrimEnd() //@@@@20230303
                      + pccCmpnySt.InqOtherEpCd.TrimEnd() + pccCmpnySt.InqOtherSecCd.TrimEnd();
                       
                    if (!this._customerHTable.ContainsKey(pccCmpnySt.PccCompanyCode))
                    {
                        this._customerHTable.Add(pccCmpnySt.PccCompanyCode, pccCmpnySt);
                    }
                    if (!this._customerEndTable.ContainsKey(inqCondition))
                    {
                        this._customerEndTable.Add(inqCondition, pccCmpnySt);
                    }
                }
            }

        }
        #endregion

        #endregion

        #region Private Methods

        /// <summary>
        /// PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[�쐬����
        /// </summary>
        /// <param name="pccCpTgtStWorkDic">PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[</param>
        /// <param name="pccCpTgtStList">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[�쐬�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private void CopyToPccCpTgtStWorkDic(out Dictionary<string, PccCpTgtSt> pccCpTgtStWorkDic, List<PccCpTgtSt> pccCpTgtStList)
        {
            pccCpTgtStWorkDic = null;
            if (pccCpTgtStList != null && pccCpTgtStList.Count >0 )
            {
                pccCpTgtStWorkDic = new Dictionary<string, PccCpTgtSt>();
                foreach (PccCpTgtSt pccCpTgtSt in pccCpTgtStList)
                {
                    //PCC�L�����y�[�����b�Z�[�W�ݒ�KEY
                    string pccCpMsgStKey = pccCpTgtSt.InqOtherEpCd.TrimEnd() + pccCpTgtSt.InqOtherSecCd.TrimEnd() + pccCpTgtSt.CampaignCode.ToString().PadRight(6, ' ');
                    //PCC�L�����y�[���Ώېݒ�KEY
                    string pccCpTgtStKey = pccCpMsgStKey + pccCpTgtSt.InqOriginalEpCd.Trim() + pccCpTgtSt.InqOriginalSecCd.TrimEnd();//@@@@20230303
                    pccCpTgtStWorkDic.Add(pccCpTgtStKey, pccCpTgtSt);
                }
            }
         
        }

        /// <summary>
        /// PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[�쐬����
        /// </summary>
        /// <param name="pccCpItmStDic">PCC�L�����y�[���i�ڐݒ�f�[�^�f�B�N�V���i���[</param>
        /// <param name="pccCpItmStList">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[�쐬�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private void CopyToPccCpItmStListDic(out Dictionary<string, PccCpItmSt> pccCpItmStDic, List<PccCpItmSt> pccCpItmStList)
        {
            pccCpItmStDic = null;
            if (pccCpItmStList != null && pccCpItmStList.Count > 0)
            {
                //PCC�L�����y�[�����b�Z�[�W�ݒ�KEY
                string pccCpMsgStKey = string.Empty;
                //PCC�L�����y�[���i�ڐݒ�KEY
                string pccCpItmStKey = string.Empty;
                pccCpItmStDic = new Dictionary<string, PccCpItmSt>();
               foreach (PccCpItmSt pccCpItmSt in pccCpItmStList)
                {
                    //PCC�L�����y�[�����b�Z�[�W�ݒ�KEY
                    pccCpMsgStKey = pccCpItmSt.InqOtherEpCd.TrimEnd() + pccCpItmSt.InqOtherSecCd.TrimEnd() + pccCpItmSt.CampaignCode.ToString().PadRight(6, ' ');
                    //PCC�L�����y�[���i�ڐݒ�KEY
                    pccCpItmStKey = pccCpMsgStKey + pccCpItmSt.CampStDiv.ToString().PadRight(2, ' ') +
                        pccCpItmSt.BLGoodsCode.ToString().PadRight(8, ' ') + pccCpItmSt.GoodsNo.PadRight(40, ' ')
                        + pccCpItmSt.GoodsMakerCd.ToString().PadRight(4, ' ');
                    pccCpItmStDic.Add(pccCpItmStKey, pccCpItmSt);
                }
               
            }
        }

        /// <summary>
        /// PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[�쐬����
        /// </summary>
        /// <param name="pccCpTgtStWorkDicDic">PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[</param>
        /// <param name="pccCpTgtStList">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[�쐬�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private void CopyToPccCpTgtStWorkDicDic(out Dictionary<string, Dictionary<string, PccCpTgtSt>> pccCpTgtStWorkDicDic, List<PccCpTgtSt>  pccCpTgtStList)
        {
            pccCpTgtStWorkDicDic = null;
            if (pccCpTgtStList != null && pccCpTgtStList.Count > 0)
            {
                //�OPCC�L�����y�[�����b�Z�[�W�ݒ�KEY
                string pccCpMsgStKeyPre = string.Empty;
                //PCC�L�����y�[�����b�Z�[�W�ݒ�KEY
                string pccCpMsgStKey = string.Empty;
                //PCC�L�����y�[���Ώېݒ�KEY
                string pccCpTgtStKey = string.Empty;
                //PCC�L�����y�[���Ώېݒ�f�B�N�V���i���[
                Dictionary<string, PccCpTgtSt> pccCpTgtStWorkDic = new Dictionary<string,PccCpTgtSt>();
                pccCpTgtStWorkDicDic = new Dictionary<string, Dictionary<string, PccCpTgtSt>>();
                foreach (PccCpTgtSt pccCpTgtSt in pccCpTgtStList)
                {
                    //PCC�L�����y�[�����b�Z�[�W�ݒ�KEY
                    pccCpMsgStKey = pccCpTgtSt.InqOtherEpCd.TrimEnd() + pccCpTgtSt.InqOtherSecCd.TrimEnd() + pccCpTgtSt.CampaignCode.ToString().PadRight(6, ' ');
                    //PCC�L�����y�[���Ώېݒ�KEY
                    pccCpTgtStKey = pccCpMsgStKey + pccCpTgtSt.InqOriginalEpCd.Trim() + pccCpTgtSt.InqOriginalSecCd.TrimEnd();//@@@@20230303
                    if (string.IsNullOrEmpty(pccCpMsgStKeyPre))
                    {
                        pccCpMsgStKeyPre = pccCpMsgStKey;
                        pccCpTgtStWorkDic.Add(pccCpTgtStKey, pccCpTgtSt);
                    }
                    else
                    {
                        if (!pccCpMsgStKeyPre.Equals(pccCpMsgStKey))
                        {
                            pccCpTgtStWorkDicDic.Add(pccCpMsgStKeyPre, pccCpTgtStWorkDic);
                            pccCpTgtStWorkDic = new Dictionary<string, PccCpTgtSt>();
                            pccCpMsgStKeyPre = pccCpMsgStKey;
                        }
                        pccCpTgtStWorkDic.Add(pccCpTgtStKey, pccCpTgtSt);
                    }
                }
                pccCpTgtStWorkDicDic.Add(pccCpMsgStKey, pccCpTgtStWorkDic);
            }
        }

        /// <summary>
        /// PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[�쐬����
        /// </summary>
        /// <param name="pccCpItmStDicDic">PCC�L�����y�[���i�ڐݒ�f�[�^�f�B�N�V���i���[</param>
        /// <param name="pccCpItmStList">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[�쐬�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private void CopyToPccCpItmStListDicDic(out Dictionary<string, Dictionary<string, PccCpItmSt>> pccCpItmStDicDic, List<PccCpItmSt> pccCpItmStList)
        {
            pccCpItmStDicDic = null;
            if (pccCpItmStList != null && pccCpItmStList.Count > 0)
            {
                //�OPCC�L�����y�[�����b�Z�[�W�ݒ�KEY
                string pccCpMsgStKeyPre = string.Empty;
                //PCC�L�����y�[�����b�Z�[�W�ݒ�KEY
                string pccCpMsgStKey = string.Empty;
                //PCC�L�����y�[���i�ڐݒ�KEY
                string pccCpItmStKey = string.Empty;
                //PCC�L�����y�[���i�ڐݒ�f�B�N�V���i���[
                Dictionary<string, PccCpItmSt> pccCpItmStDic = new Dictionary<string, PccCpItmSt>();
                pccCpItmStDicDic = new Dictionary<string, Dictionary<string, PccCpItmSt>>();
                foreach (PccCpItmSt pccCpItmSt in pccCpItmStList)
                {
                    //PCC�L�����y�[�����b�Z�[�W�ݒ�KEY
                    pccCpMsgStKey = pccCpItmSt.InqOtherEpCd.TrimEnd() + pccCpItmSt.InqOtherSecCd.TrimEnd() + pccCpItmSt.CampaignCode.ToString().PadRight(6, ' ');
                    //PCC�L�����y�[���i�ڐݒ�KEY
                    pccCpItmStKey = pccCpMsgStKey + pccCpItmSt.CampStDiv.ToString().PadRight(2, ' ') + 
                        pccCpItmSt.BLGoodsCode.ToString().PadRight(8, ' ') + pccCpItmSt.GoodsNo.PadRight(40, ' ') 
                        + pccCpItmSt.GoodsMakerCd.ToString().PadRight(4, ' ');
                    if (string.IsNullOrEmpty(pccCpMsgStKeyPre))
                    {
                        pccCpItmStDic.Add(pccCpItmStKey, pccCpItmSt);
                        pccCpMsgStKeyPre = pccCpMsgStKey;
                    }
                    else
                    {
                        if (!pccCpMsgStKeyPre.Equals(pccCpMsgStKey))
                        {
                            pccCpItmStDicDic.Add(pccCpMsgStKeyPre, pccCpItmStDic);
                            pccCpItmStDic = new Dictionary<string, PccCpItmSt>();
                            pccCpMsgStKeyPre = pccCpMsgStKey;
                        }
                        pccCpItmStDic.Add(pccCpItmStKey, pccCpItmSt);
                    }
                }
                pccCpItmStDicDic.Add(pccCpMsgStKey, pccCpItmStDic);
            }
        }

        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W���b�Z�[�W�ݒ胊�X�g�[�i����
        /// </summary>
        /// <param name="pccCpMsgStWorkListResultList">�L�����y�[�����b�Z�[�W�ݒ胏�[�N���X�g</param>
        /// <param name="pccCpMsgStList">�L�����y�[�����b�Z�[�W�ݒ胊�X�g</param>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[�쐬�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private void CopyToPccCpMsgStFromPccCpMsgStWork(ArrayList pccCpMsgStWorkListResultList, out List<PccCpMsgSt> pccCpMsgStList)
        {
            pccCpMsgStList = null;
            if (pccCpMsgStWorkListResultList == null || pccCpMsgStWorkListResultList.Count == 0)
            {
                return;
            }
            else
            {
                pccCpMsgStList = new List<PccCpMsgSt>();
                foreach (PccCpMsgStWork pccCpMsgStWork in pccCpMsgStWorkListResultList)
                {
                    PccCpMsgSt pccCpMsgSt = new PccCpMsgSt();

                    pccCpMsgSt.CreateDateTime = pccCpMsgStWork.CreateDateTime;
                    pccCpMsgSt.UpdateDateTime = pccCpMsgStWork.UpdateDateTime;
                    pccCpMsgSt.LogicalDeleteCode = pccCpMsgStWork.LogicalDeleteCode;
                    pccCpMsgSt.InqOtherEpCd = pccCpMsgStWork.InqOtherEpCd;
                    pccCpMsgSt.InqOtherSecCd = pccCpMsgStWork.InqOtherSecCd;
                    pccCpMsgSt.CampaignCode = pccCpMsgStWork.CampaignCode;
                    pccCpMsgSt.ApplyStaDate = pccCpMsgStWork.ApplyStaDate;
                    pccCpMsgSt.ApplyEndDate = pccCpMsgStWork.ApplyEndDate;
                    pccCpMsgSt.PccMsgDocCnts = pccCpMsgStWork.PccMsgDocCnts;
                    pccCpMsgSt.CampaignName = pccCpMsgStWork.CampaignName;
                    pccCpMsgSt.CampaignObjDiv = pccCpMsgStWork.CampaignObjDiv;
                    pccCpMsgSt.UpdateFlag = 1;
                    pccCpMsgStList.Add(pccCpMsgSt);
                }
            }
        }

        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^���[�N���X�g�[�i����
        /// </summary>
        /// <param name="pccCpMsgStWorkListResultList">PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^���[�N���X�g</param>
        /// <param name="pccCpMsgStList">PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^���X�g</param>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[�쐬�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private void CopyToPccCpMsgStWorkFromPccCpMsgSt(out ArrayList pccCpMsgStWorkListResultList, List<PccCpMsgSt> pccCpMsgStList)
        {
            pccCpMsgStWorkListResultList = null;
            if (pccCpMsgStList == null || pccCpMsgStList.Count == 0)
            {
                return;

            }
            else
            {
                pccCpMsgStWorkListResultList = new ArrayList();
                foreach (PccCpMsgSt pccCpMsgSt in pccCpMsgStList)
                {
                    PccCpMsgStWork pccCpMsgStWork = new PccCpMsgStWork();
                    pccCpMsgStWork.CreateDateTime = pccCpMsgSt.CreateDateTime;
                    pccCpMsgStWork.UpdateDateTime = pccCpMsgSt.UpdateDateTime;
                    pccCpMsgStWork.LogicalDeleteCode = pccCpMsgSt.LogicalDeleteCode;
                    pccCpMsgStWork.InqOtherEpCd = pccCpMsgSt.InqOtherEpCd;
                    pccCpMsgStWork.InqOtherSecCd = pccCpMsgSt.InqOtherSecCd;
                    pccCpMsgStWork.CampaignCode = pccCpMsgSt.CampaignCode;
                    pccCpMsgStWork.ApplyStaDate = pccCpMsgSt.ApplyStaDate;
                    pccCpMsgStWork.ApplyEndDate = pccCpMsgSt.ApplyEndDate;
                    pccCpMsgStWork.PccMsgDocCnts = pccCpMsgSt.PccMsgDocCnts;
                    pccCpMsgStWork.CampaignName = pccCpMsgSt.CampaignName;
                    pccCpMsgStWork.CampaignObjDiv = pccCpMsgSt.CampaignObjDiv;
                    pccCpMsgStWork.UpdateFlag = pccCpMsgSt.UpdateFlag;
                    pccCpMsgStWorkListResultList.Add(pccCpMsgStWork);
                }
            }
        }  

        /// <summary>
        /// PCC�L�����y�[���Ώېݒ胊�X�g�[�i����
        /// </summary>
        /// <param name="pccCpTgtStWorkListResultList">PCC�L�����y�[���Ώېݒ胏�[�N���X�g</param>
        /// <param name="pccCpTgtStList">PCC�L�����y�[���Ώېݒ胊�X�g</param>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[�쐬�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private void CopyToPccCpTgtStFromPccCpTgtStWork(ArrayList pccCpTgtStWorkListResultList, out List<PccCpTgtSt> pccCpTgtStList)
        {
            pccCpTgtStList = null;
             if (pccCpTgtStWorkListResultList == null || pccCpTgtStWorkListResultList.Count == 0)
             {
                 return;
             }
             else
             {
                 pccCpTgtStList = new List<PccCpTgtSt>();
                 string inqCondition = string.Empty;
                 PccCmpnySt pccCmpnySt = null;
                 foreach (PccCpTgtStWork pccCpTgtStWork in pccCpTgtStWorkListResultList)
                 {

                     PccCpTgtSt pccCpTgtSt = new PccCpTgtSt();
                     inqCondition = pccCpTgtStWork.InqOriginalEpCd.Trim() + pccCpTgtStWork.InqOriginalSecCd.TrimEnd() //@@@@20230303
                       + pccCpTgtStWork.InqOtherEpCd.TrimEnd() + pccCpTgtStWork.InqOtherSecCd.TrimEnd();
                     pccCpTgtSt.CreateDateTime = pccCpTgtStWork.CreateDateTime;
                     pccCpTgtSt.UpdateDateTime = pccCpTgtStWork.UpdateDateTime;
                     pccCpTgtSt.LogicalDeleteCode = pccCpTgtStWork.LogicalDeleteCode;
                     pccCpTgtSt.InqOtherEpCd = pccCpTgtStWork.InqOtherEpCd;
                     pccCpTgtSt.InqOtherSecCd = pccCpTgtStWork.InqOtherSecCd;
                     pccCpTgtSt.InqOriginalEpCd = pccCpTgtStWork.InqOriginalEpCd.Trim();//@@@@20230303
                     pccCpTgtSt.InqOriginalSecCd = pccCpTgtStWork.InqOriginalSecCd;
                     pccCpTgtSt.CampaignCode = pccCpTgtStWork.CampaignCode;
                     pccCpTgtSt.UpdateFlag = 1;
                     if (this._customerEndTable != null && this._customerEndTable.ContainsKey(inqCondition))
                     {
                         pccCmpnySt = this._customerEndTable[inqCondition];
                         pccCpTgtSt.CustomerCode = pccCmpnySt.PccCompanyCode;
                         pccCpTgtSt.CustomerName = pccCmpnySt.PccCompanyName;

                     }

                     pccCpTgtStList.Add(pccCpTgtSt);
                 }
             }
        }
       
        /// <summary>
        /// PCC�L�����y�[���Ώېݒ胏�[�N���X�g�[�i����
        /// </summary>
        /// <param name="pccCpTgtStWorkListResultList">PCC�L�����y�[���Ώېݒ胏�[�N���X�g</param>
        /// <param name="pccCpTgtStList">PCC�L�����y�[���Ώېݒ胊�X�g</param>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[�쐬�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private void CopyToPccCpTgtStWorkFromPccCpTgtSt(out ArrayList pccCpTgtStWorkListResultList, List<PccCpTgtSt> pccCpTgtStList)
        {
            pccCpTgtStWorkListResultList = null;
            if (pccCpTgtStList == null || pccCpTgtStList.Count == 0)
            {
                return;

            }
            else
            {
                pccCpTgtStWorkListResultList = new ArrayList();
                foreach (PccCpTgtSt pccCpTgtSt in pccCpTgtStList)
                {
                    PccCpTgtStWork pccCpTgtStWork = new PccCpTgtStWork();

                    pccCpTgtStWork.CreateDateTime = pccCpTgtSt.CreateDateTime;
                    pccCpTgtStWork.UpdateDateTime = pccCpTgtSt.UpdateDateTime;
                    pccCpTgtStWork.LogicalDeleteCode = pccCpTgtSt.LogicalDeleteCode;
                    pccCpTgtStWork.InqOtherEpCd = pccCpTgtSt.InqOtherEpCd;
                    pccCpTgtStWork.InqOtherSecCd = pccCpTgtSt.InqOtherSecCd;
                    pccCpTgtStWork.InqOriginalEpCd = pccCpTgtSt.InqOriginalEpCd.Trim();//@@@@20230303
                    pccCpTgtStWork.InqOriginalSecCd = pccCpTgtSt.InqOriginalSecCd;
                    pccCpTgtStWork.CampaignCode = pccCpTgtSt.CampaignCode;
                    pccCpTgtStWork.UpdateFlag = pccCpTgtSt.UpdateFlag;
                    pccCpTgtStWorkListResultList.Add(pccCpTgtStWork);
                }
            }
        }

        /// <summary>
        ///  PCC�L�����y�[���i�ڐݒ胊�X�g�[�i����
        /// </summary>
        /// <param name="pccCpItmStWorkListResultList">PCC�L�����y�[���i�ڐݒ胏�[�N���X�g</param>
        /// <param name="pccCpItmStList">PCC�L�����y�[���i�ڐݒ胊�X�g</param>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[�쐬�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private void CopyToPccCpItmStFromPccCpItmStWork(ArrayList pccCpItmStWorkListResultList, out List<PccCpItmSt> pccCpItmStList)
        {
            pccCpItmStList = null;
            if (pccCpItmStWorkListResultList == null || pccCpItmStWorkListResultList.Count == 0)
            {
                return;
            }
            else
            {
                pccCpItmStList = new List<PccCpItmSt>();
                foreach (PccCpItmStWork pccCpItmStWork in pccCpItmStWorkListResultList)
                {


                    PccCpItmSt pccCpItmSt = new PccCpItmSt();

                    pccCpItmSt.CreateDateTime = pccCpItmStWork.CreateDateTime;
                    pccCpItmSt.UpdateDateTime = pccCpItmStWork.UpdateDateTime;
                    pccCpItmSt.LogicalDeleteCode = pccCpItmStWork.LogicalDeleteCode;
                    pccCpItmSt.InqOtherEpCd = pccCpItmStWork.InqOtherEpCd;
                    pccCpItmSt.InqOtherSecCd = pccCpItmStWork.InqOtherSecCd;
                    pccCpItmSt.CampaignCode = pccCpItmStWork.CampaignCode;
                    pccCpItmSt.CampStDiv = pccCpItmStWork.CampStDiv;
                    pccCpItmSt.BLGoodsCode = pccCpItmStWork.BLGoodsCode;
                    pccCpItmSt.GoodsNo = pccCpItmStWork.GoodsNo;
                    pccCpItmSt.GoodsMakerCd = pccCpItmStWork.GoodsMakerCd;
                    pccCpItmSt.GoodsName = pccCpItmStWork.GoodsName;
                    pccCpItmSt.GoodsNameKana = pccCpItmStWork.GoodsNameKana;
                    pccCpItmSt.ItemQty = pccCpItmStWork.ItemQty;
                    pccCpItmSt.UpdateFlag = 1;
                    pccCpItmStList.Add(pccCpItmSt);
                }
            }
        }

        /// <summary>
        /// PCC�L�����y�[���i�ڐݒ胏�[�N���X�g�[�i����
        /// </summary>
        /// <param name="pccCpItmStWorkListResultList">PCC�L�����y�[���i�ڐݒ胏�[�N���X�g</param>
        /// <param name="pccCpItmStList">PCC�L�����y�[���i�ڐݒ胊�X�g</param>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[��PCC�L�����y�[���i�ڐݒ胊�X�g�쐬�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private void CopyToPccCpItmStWorkFromPccCpItmSt(out ArrayList pccCpItmStWorkListResultList, List<PccCpItmSt> pccCpItmStList)
        {
            pccCpItmStWorkListResultList = null;
            if (pccCpItmStList == null || pccCpItmStList.Count == 0)
            {
                return;

            }
            else
            {
                pccCpItmStWorkListResultList = new ArrayList();
                foreach (PccCpItmSt pccCpItmSt in pccCpItmStList)
                {

                    PccCpItmStWork pccCpItmStWork = new PccCpItmStWork();

                    pccCpItmStWork.CreateDateTime = pccCpItmSt.CreateDateTime;
                    pccCpItmStWork.UpdateDateTime = pccCpItmSt.UpdateDateTime;
                    pccCpItmStWork.LogicalDeleteCode = pccCpItmSt.LogicalDeleteCode;
                    pccCpItmStWork.InqOtherEpCd = pccCpItmSt.InqOtherEpCd;
                    pccCpItmStWork.InqOtherSecCd = pccCpItmSt.InqOtherSecCd;
                    pccCpItmStWork.CampaignCode = pccCpItmSt.CampaignCode;
                    pccCpItmStWork.CampStDiv = pccCpItmSt.CampStDiv;
                    pccCpItmStWork.BLGoodsCode = pccCpItmSt.BLGoodsCode;
                    pccCpItmStWork.GoodsNo = pccCpItmSt.GoodsNo;
                    pccCpItmStWork.GoodsMakerCd = pccCpItmSt.GoodsMakerCd;
                    pccCpItmStWork.GoodsName = pccCpItmSt.GoodsName;
                    pccCpItmStWork.GoodsNameKana = pccCpItmSt.GoodsNameKana;
                    pccCpItmStWork.ItemQty = pccCpItmSt.ItemQty;
                    pccCpItmStWork.UpdateFlag = pccCpItmSt.UpdateFlag;
                    pccCpItmStWorkListResultList.Add(pccCpItmStWork);
                }
            }
        }

        #endregion

    }

}
