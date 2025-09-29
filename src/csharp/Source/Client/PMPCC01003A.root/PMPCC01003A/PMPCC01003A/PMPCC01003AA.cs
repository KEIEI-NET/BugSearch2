//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�����b�Z�[�W�ݒ菈��
// �v���O�����T�v   : ���[�����b�Z�[�W�ݒ菈���A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2011.08.09  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
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
    /// ���[�����b�Z�[�W�ݒ菈���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�����b�Z�[�W�ݒ菈���t�h�N���X</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date	   : 2011.08.09</br>
    /// </remarks>  
    public class PccMailDtAcs
    {
        /// <summary>
        /// �����[�g�I�u�W�F�N�g�C���^�[�t�F�C�X
        /// </summary>
        private IPccMailDtDB _iPccMailDtDB = null;

        #region �� Constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�����b�Z�[�W�ݒ菈���A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public PccMailDtAcs()
        {
            try
            {
                _iPccMailDtDB = MediationPccMailDtDB.GetPccMailDtDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iPccMailDtDB = null;
            }
        }
        #endregion �� Constructor

        #region �� Public Method
        /// <summary>
        /// ���[�����b�Z�[�W�ݒ菈���o�^�A�X�V����
        /// </summary>
        /// <param name="pccMailDtList">PCC���[���f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�����b�Z�[�W�ݒ菈���o�^�A�X�V�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int Write(ref  List<PccMailDt> pccMailDtList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            PccMailDtWork pccMailDtWork = null;
            ArrayList paraList = new ArrayList();
            foreach (PccMailDt pccMailDt in pccMailDtList)
            {
                pccMailDtWork = CopyToPccMailDtWorkFromPccMailDt(pccMailDt);

                // UOE���Ђ̓o�^�E�X�V����ݒ�
                paraList.Add(pccMailDtWork);
            }
            object paraObj = paraList;
            try
            {
                
                //���[�����b�Z�[�W�ݒ菈���o�^�A�X�V����
                status = _iPccMailDtDB.Write(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraList = (ArrayList)paraObj;
                    pccMailDtList = new List<PccMailDt>();
                    foreach (PccMailDtWork pccMailDtWorkResult in paraList)
                    {
                        PccMailDt pccMailDt = this.CopyToPccMailDtFromPccMailDtWork(pccMailDtWorkResult);
                        pccMailDtList.Add(pccMailDt);
                    }
                    return status;

                }
               

            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iPccMailDtDB = null;
                // �ʐM�G���[��-1��߂�
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
          
            return status;
        }

        /// <summary>
        /// ���[�����b�Z�[�W�ݒ茟������
        /// </summary>
        /// <param name="pccMailDtDicDic">PCC���[���f�[�^���X�g</param>
        /// <param name="parsePccMailDt">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�����b�Z�[�W�ݒ茟�������B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int Search(ref Dictionary<string, Dictionary<string ,PccMailDt>> pccMailDtDicDic, PccMailDt parsePccMailDt, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            pccMailDtDicDic = null;
            List<PccMailDt> pccMailList = null;
            status = Search(ref pccMailList, parsePccMailDt, readMode, logicalMode);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            pccMailDtDicDic = new Dictionary<string, Dictionary<string, PccMailDt>>();
            string inqConditionFaPre = string.Empty;
            string inqConditionFa = string.Empty;
            string inqCondition = string.Empty;
            Dictionary<string, PccMailDt> pccMailDtDic = new Dictionary<string, PccMailDt>();
            foreach (PccMailDt pccMailDt in pccMailList)
            {
                inqConditionFa = pccMailDt.InqOriginalEpCd.Trim() + pccMailDt.InqOriginalSecCd.TrimEnd() //@@@@20230303
               + pccMailDt.InqOtherEpCd.TrimEnd() + pccMailDt.InqOtherSecCd.TrimEnd();
                inqCondition = pccMailDt.InqOriginalEpCd.Trim() + pccMailDt.InqOriginalSecCd.TrimEnd() //@@@@20230303
              + pccMailDt.InqOtherEpCd.TrimEnd() + pccMailDt.InqOtherSecCd.TrimEnd() + pccMailDt.UpdateDate + pccMailDt.UpdateTime;
                if (!inqConditionFaPre.Equals(inqConditionFa))
                {
                    if (!string.IsNullOrEmpty(inqConditionFaPre))
                    {
                        pccMailDtDicDic.Add(inqConditionFaPre, pccMailDtDic);
                    }
                    pccMailDtDic = new Dictionary<string, PccMailDt>();
                    pccMailDtDic.Add(inqCondition, pccMailDt);

                    inqConditionFaPre = inqConditionFa;
                }
                else
                {
                    pccMailDtDic.Add(inqCondition, pccMailDt);
                }
            }
            pccMailDtDicDic.Add(inqConditionFaPre, pccMailDtDic);



            return status;
        }

        /// <summary>
        /// ���[�����b�Z�[�W�ݒ茟������
        /// </summary>
        /// <param name="pccMailDtList">PCC���[���f�[�^���X�g</param>
        /// <param name="parsePccMailDt">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�����b�Z�[�W�ݒ茟�������B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int Search(ref List<PccMailDt> pccMailDtList, PccMailDt parsePccMailDt, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            pccMailDtList = null;
            PccMailDtWork parsePccMailDtWork = null;
            Object objPccMailDtWorkList = null;
            ArrayList pccMailDtWorkListResultList = null;
            List<PccMailDtWork> pccMailDtWorkList = null;
            try
            {

                parsePccMailDtWork = CopyToPccMailDtWorkFromPccMailDt(parsePccMailDt);
                //���[�����b�Z�[�W�ݒ茟������
                status = _iPccMailDtDB.Search(ref objPccMailDtWorkList, parsePccMailDtWork, readMode, logicalMode);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //���ʂ�߂�
                pccMailDtWorkListResultList = objPccMailDtWorkList as ArrayList;

                if (pccMailDtWorkListResultList != null)
                {
                    pccMailDtWorkList = new List<PccMailDtWork>((PccMailDtWork[])pccMailDtWorkListResultList.ToArray(typeof(PccMailDtWork)));
                }
                if (pccMailDtWorkList != null)
                {
                    pccMailDtList = new List<PccMailDt>();
                    foreach (PccMailDtWork pccMailDtWork in pccMailDtWorkList)
                    {
                        PccMailDt pccMailDt = CopyToPccMailDtFromPccMailDtWork(pccMailDtWork);
                        pccMailDtList.Add(pccMailDt);
                    }
                    
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
        /// ���[�����b�Z�[�W�ݒ茟������
        /// </summary>
        /// <param name="pccMailDt">PCC���[���f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�����b�Z�[�W�ݒ茟�������B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int Read(ref PccMailDt pccMailDt, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            try
            {
            pccMailDt = null;
            PccMailDtWork pccMailDtWork = new PccMailDtWork();
          
            // UOE���Ѓ��[�J�[�N���X���I�u�W�F�N�g�ɐݒ�
            object paraObj = pccMailDtWork as object;

          
                //���[�����b�Z�[�W�ݒ茟������
              status = _iPccMailDtDB.Read(ref paraObj, readMode, logicalMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {


                    PccMailDtWork wkPccMailDtWork = (PccMailDtWork)paraObj;
                    // UOE���Ѓ��[�N�N���X����UOE���ЃN���X�Ƀ����o�R�s�[
                    pccMailDt = this.CopyToPccMailDtFromPccMailDtWork(wkPccMailDtWork);

                    return status;
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
        /// ���[�����b�Z�[�W�ݒ�_���폜����
        /// </summary>
        /// <param name="pccMailDt">PCC���[���f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�����b�Z�[�W�ݒ�_���폜�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int LogicalDelete(ref PccMailDt pccMailDt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            PccMailDtWork pccMailDtWork = new PccMailDtWork();

            ArrayList paraList = new ArrayList();
            // UOE���Ђ̓o�^�E�X�V����ݒ�
            pccMailDtWork = CopyToPccMailDtWorkFromPccMailDt(pccMailDt);  
          
            paraList.Add(pccMailDtWork);
           
            Object objpccMailDtWorkList = paraList;
            
            try
            {
              

                //���[�����b�Z�[�W�ݒ�_���폜����
                status = _iPccMailDtDB.LogicalDelete(ref objpccMailDtWorkList);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraList = (ArrayList)objpccMailDtWorkList;

                    pccMailDt = new PccMailDt();

                    // UOE���Ѓ��[�N�N���X����UOE���ЃN���X�Ƀ����o�R�s�[
                    pccMailDt = this.CopyToPccMailDtFromPccMailDtWork((PccMailDtWork)paraList[0]);

                    return status;
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
        /// ���[�����b�Z�[�W�ݒ蕨���폜����
        /// </summary>
        /// <param name="pccMailDt">PCC���[���f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�����b�Z�[�W�ݒ蕨���폜�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int Delete(ref PccMailDt pccMailDt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            PccMailDtWork pccMailDtWork = new PccMailDtWork();

            
            ArrayList paraList = new ArrayList();

            // UOE���Ђ̓o�^�E�X�V����ݒ�
            pccMailDtWork = CopyToPccMailDtWorkFromPccMailDt(pccMailDt);

            paraList.Add(pccMailDtWork);

            Object objpccMailDtWorkList = paraList;

            try
            {
                

                //���[�����b�Z�[�W�ݒ蕨���폜����
                status = _iPccMailDtDB.Delete(ref objpccMailDtWorkList);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraList = (ArrayList)objpccMailDtWorkList;

                    pccMailDt = new PccMailDt();

                    // UOE���Ѓ��[�N�N���X����UOE���ЃN���X�Ƀ����o�R�s�[
                    pccMailDt = this.CopyToPccMailDtFromPccMailDtWork((PccMailDtWork)paraList[0]);

                    return status;
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
        /// ���[�����b�Z�[�W�ݒ蕜������
        /// </summary>
        /// <param name="pccMailDtWorkList">PCC���[���f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�����b�Z�[�W�ݒ蕜�������B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref List<PccMailDtWork> pccMailDtWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            Object objPccMailDtWorkList = null;
            ArrayList pccMailDtWorkListResultList = null;

            try
            {
                if (pccMailDtWorkList != null)
                {
                    objPccMailDtWorkList = new ArrayList(pccMailDtWorkList.ToArray());
                }

                //���[�����b�Z�[�W�ݒ蕜������
                status = _iPccMailDtDB.RevivalLogicalDelete(ref objPccMailDtWorkList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //���ʂ�߂�
                pccMailDtWorkListResultList = objPccMailDtWorkList as ArrayList;

                if (pccMailDtWorkListResultList != null)
                {
                    pccMailDtWorkList = new List<PccMailDtWork>((PccMailDtWork[])pccMailDtWorkListResultList.ToArray(typeof(PccMailDtWork)));
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

        #endregion

        #region �� Private Method
        /// <summary>
        ///  �N���X�����o�[�R�s�[�����iUOE���Ѓ��[�N�N���X��UOE���ЃN���X�j
        /// </summary>
        /// <param name="pccMailDt"></param>
        /// <returns>UOE���ЃN���X</returns>
        /// <remarks>
        /// <br>Note       : ���[�����b�Z�[�W�ݒ蕜�������B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        private PccMailDtWork CopyToPccMailDtWorkFromPccMailDt(PccMailDt pccMailDt)
        {
            PccMailDtWork pccMailDtWork = new PccMailDtWork();
            pccMailDtWork.CreateDateTime = pccMailDt.CreateDateTime;
            pccMailDtWork.UpdateDateTime = pccMailDt.UpdateDateTime;
            pccMailDtWork.LogicalDeleteCode = pccMailDt.LogicalDeleteCode;
            pccMailDtWork.InqOriginalEpCd = pccMailDt.InqOriginalEpCd.Trim();//@@@@20230303
            pccMailDtWork.InqOriginalSecCd = pccMailDt.InqOriginalSecCd;
            pccMailDtWork.InqOtherEpCd = pccMailDt.InqOtherEpCd;
            pccMailDtWork.InqOtherSecCd = pccMailDt.InqOtherSecCd;
            pccMailDtWork.UpdateDate = pccMailDt.UpdateDate;
            pccMailDtWork.UpdateTime = pccMailDt.UpdateTime;
            pccMailDtWork.PccMailTitle = pccMailDt.PccMailTitle;
            pccMailDtWork.PccMailDocCnts = pccMailDt.PccMailDocCnts;
            pccMailDtWork.UpdateDateSt = pccMailDt.UpdateDateSt;
            pccMailDtWork.UpdateDateEd = pccMailDt.UpdateDateEd;
            return pccMailDtWork;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����iUOE���Ѓ��[�N�N���X��UOE���ЃN���X�j
        /// </summary>
        /// <param name="pccMailDtWork"></param>
        /// <returns>UOE���ЃN���X</returns>
        /// <remarks>
        /// <br>Note       : ���[�����b�Z�[�W�ݒ蕜�������B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        private PccMailDt CopyToPccMailDtFromPccMailDtWork(PccMailDtWork pccMailDtWork)
        {
            PccMailDt pccMailDt = new PccMailDt();
            pccMailDt.CreateDateTime = pccMailDtWork.CreateDateTime;
            pccMailDt.UpdateDateTime = pccMailDtWork.UpdateDateTime;
            pccMailDt.LogicalDeleteCode = pccMailDtWork.LogicalDeleteCode;
            pccMailDt.InqOriginalEpCd = pccMailDtWork.InqOriginalEpCd.Trim();//@@@@20230303
            pccMailDt.InqOriginalSecCd = pccMailDtWork.InqOriginalSecCd;
            pccMailDt.InqOtherEpCd = pccMailDtWork.InqOtherEpCd;
            pccMailDt.InqOtherSecCd = pccMailDtWork.InqOtherSecCd;
            pccMailDt.UpdateDate = pccMailDtWork.UpdateDate;
            pccMailDt.UpdateTime = pccMailDtWork.UpdateTime;
            pccMailDt.PccMailTitle = pccMailDtWork.PccMailTitle;
            pccMailDt.PccMailDocCnts = pccMailDtWork.PccMailDocCnts;
            return pccMailDt;
        }
        #endregion
    }

}
