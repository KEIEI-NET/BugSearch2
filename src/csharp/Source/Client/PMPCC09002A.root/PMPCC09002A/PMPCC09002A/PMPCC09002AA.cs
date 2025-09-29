using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using System.Runtime.Remoting;
using System.Data;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// PCC�S�̐ݒ�}�X�^ �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC�S�̐ݒ�}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : �t�I��</br>
    /// <br>Date       : 2011.08.01</br>
    /// <br></br>
    /// </remarks>
    public class PccTtlStAcs
    {
        #region Private Member

        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        //PCC�S�̐ݒ�}�X�^
        private IPccTtlStDB _iPccTtlStDB = null;
        private SecInfoSetAcs _secInfoSetAcs = null;
        private EmployeeAcs _employeeAcs = null;       
        private Hashtable _secInfoSetTable = null;

        private UserGuideAcs _userGuideAcs = null;
        private Hashtable _userGdBdTb = null;
        #endregion

        #region Constructor

        /// <summary>
        ///PCC�S�̐ݒ�}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       :PCC�S�̐ݒ�}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public PccTtlStAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iPccTtlStDB = (IPccTtlStDB)MediationPccTtlStDB.GetPccTtlStDB();
                _secInfoSetAcs = new SecInfoSetAcs();
                _employeeAcs = new EmployeeAcs();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iPccTtlStDB = null;
            }
        }

        #endregion

        #region Public Methods
       
        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iPccTtlStDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }
      
        /// <summary>
        ///PCC�S�̐ݒ�}�X�^�ǂݍ��ݏ���
        /// </summary>
        /// <param name="pccTtlSt">UOE���ЃI�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       :PCC�S�̐ݒ����ǂݍ��݂܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int Read(out  PccTtlSt pccTtlSt, string enterpriseCode)
        {
            try
            {
                // �L�[���̐ݒ�
                pccTtlSt = null;
                PccTtlStWork pccTtlStWork = new PccTtlStWork();
                pccTtlStWork.EnterpriseCode = enterpriseCode;
            
                //PCC�S�̐ݒ胏�[�J�[�N���X���I�u�W�F�N�g�ɐݒ�
                object paraObj = pccTtlStWork as object;

                //UOE���Ѓ}�X�^�ǂݍ���
                int status = this._iPccTtlStDB.Read(ref paraObj, 0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �ǂݍ��݌��ʂ�UOE���Ѓ��[�J�[�N���X�ɐݒ�
                    PccTtlStWork wkPccTtlStWork = (PccTtlStWork)paraObj;
                    //PCC�S�̐ݒ胏�[�J�[�N���X����UOE���ЃN���X�ɃR�s�[
                    pccTtlSt = CopyToPccTtlStFromPccTtlStWork(wkPccTtlStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iPccTtlStDB = null;
                //�ʐM�G���[��-1��߂�
                pccTtlSt = null;
                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
        }
             
        /// <summary>
        ///PCC�S�̐ݒ�o�^�E�X�V����
        /// </summary>
        /// <param name="pccTtlSt">UOE���ЃN���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :PCC�S�̐ݒ�̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int Write(ref PccTtlSt pccTtlSt)
        {
            PccTtlStWork pccTtlStWork = new PccTtlStWork();
            ArrayList paraList = new ArrayList();

            //PCC�S�̐ݒ�N���X����UOE���Ѓ��[�N�N���X�Ƀ����o�R�s�[
            pccTtlStWork = CopyToPccTtlStWorkFromPccTtlSt(pccTtlSt);

            //PCC�S�̐ݒ�̓o�^�E�X�V����ݒ�
            paraList.Add(pccTtlStWork);

            object paraObj = paraList;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {               
                //PCC�S�̐ݒ菑������
                status = this._iPccTtlStDB.Write(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraList = (ArrayList)paraObj;

                    pccTtlSt = new PccTtlSt();

                    //PCC�S�̐ݒ胏�[�N�N���X����UOE���ЃN���X�Ƀ����o�R�s�[
                    pccTtlSt = this.CopyToPccTtlStFromPccTtlStWork((PccTtlStWork)paraList[0]);
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iPccTtlStDB = null;
                // �ʐM�G���[��-1��߂�
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
    
        /// <summary>
        ///PCC�S�̐ݒ�o�^�E�X�V����
        /// </summary>
        /// <param name="pccTtlStList">UOE���ЃN���X</param>
        /// <param name="parsePccTtlSt">��ƃR�[�h</param>
        /// <param name="retTotalCnt">����</param>
        /// <param name="readMode"></param>
        /// <param name="readCnt">����</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :PCC�S�̐ݒ�̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int Search(ref List<PccTtlSt> pccTtlStList, PccTtlSt parsePccTtlSt, out int retTotalCnt, int readMode, int readCnt, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            pccTtlStList = null;            
            Object objpccTtlStWorkList = null;
            PccTtlStWork parsePccTtlStWork = null;
            ArrayList pccTtlStWorkResultList = null;
            List<PccTtlStWork> pccTtlStWorkList = null;

            retTotalCnt = 0;                   
            parsePccTtlStWork = new PccTtlStWork();
            parsePccTtlStWork.EnterpriseCode = parsePccTtlSt.EnterpriseCode;
            parsePccTtlStWork.SectionCode = parsePccTtlSt.SectionCode;
            //���_���̏���
            if (_secInfoSetAcs == null)
            {
                _secInfoSetAcs = new SecInfoSetAcs();
            }
            ArrayList secInfoSetList = null;
            status = _secInfoSetAcs.Search(out secInfoSetList, parsePccTtlSt.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && secInfoSetList != null)
            {
                this._secInfoSetTable = new Hashtable();
                foreach (SecInfoSet secInfoSet in secInfoSetList)
                {
                    this._secInfoSetTable.Add(secInfoSet.SectionCode, secInfoSet.SectionGuideSnm);

                }
            }
            // ���[�U�[�K�C�h�ݒ�̔[�i�敪�̎擾
            SetDelivereds(parsePccTtlSt.EnterpriseCode);
                //��������
           status = _iPccTtlStDB.Search(ref objpccTtlStWorkList, parsePccTtlStWork, readMode, logicalMode);

           if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
           {
               return status;
           }
           //���ʂ�߂�
           pccTtlStWorkResultList = objpccTtlStWorkList as ArrayList;

           if (pccTtlStWorkResultList != null)
           {
               pccTtlStWorkList = new List<PccTtlStWork>((PccTtlStWork[])pccTtlStWorkResultList.ToArray(typeof(PccTtlStWork)));
           }
           if (pccTtlStWorkList != null)
           {
               pccTtlStList = new List<PccTtlSt>();
               foreach (PccTtlStWork pccTtlStWork in pccTtlStWorkList)
               {
                   if (pccTtlStWork.EnterpriseCode == parsePccTtlSt.EnterpriseCode &&
                       ((parsePccTtlSt.SectionCode == "") || (pccTtlStWork.SectionCode.TrimEnd() == parsePccTtlSt.SectionCode.TrimEnd()) || (pccTtlStWork.SectionCode.TrimEnd() == "")))
                   {
                       PccTtlSt pccTtlSt = null;
                       pccTtlSt = CopyToPccTtlStFromPccTtlStWork(pccTtlStWork);
                       pccTtlStList.Add(pccTtlSt);
                   }
               }
           }
           
            return status;
        }
    
        /// <summary>
        ///PCC�S�̐ݒ�o�^�E�X�V����
        /// </summary>
        /// <param name="pccTtlSt">UOE���ЃN���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :PCC�S�̐ݒ�̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int LogicalDelete(ref PccTtlSt pccTtlSt) 
        {

            ArrayList paraList = new ArrayList();
            PccTtlStWork pccTtlStWork = new PccTtlStWork();

            //PCC�S�̐ݒ�N���X����UOE���Ѓ��[�N�N���X�Ƀ����o�R�s�[
            pccTtlStWork = CopyToPccTtlStWorkFromPccTtlSt(pccTtlSt);

            paraList.Add(pccTtlStWork);

            Object objpccTtlStWorkList = paraList;
           
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
  
              
            // �_���폜����
            status = _iPccTtlStDB.LogicalDelete(ref objpccTtlStWorkList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {

                paraList = (ArrayList)objpccTtlStWorkList;

                pccTtlSt = new PccTtlSt();

                //PCC�S�̐ݒ胏�[�N�N���X����UOE���ЃN���X�Ƀ����o�R�s�[
                pccTtlSt = this.CopyToPccTtlStFromPccTtlStWork((PccTtlStWork)paraList[0]);

                return status;
            }               
            return status;
        }
    
        /// <summary>
        ///PCC�S�̐ݒ�o�^�E�X�V����
        /// </summary>
        /// <param name="pccTtlSt">UOE���ЃN���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :PCC�S�̐ݒ�̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int Delete(ref PccTtlSt pccTtlSt)
        {

            PccTtlStWork pccTtlStWork = new PccTtlStWork();

            ArrayList paraList = new ArrayList();

            //PCC�S�̐ݒ�N���X����UOE���Ѓ��[�N�N���X�Ƀ����o�R�s�[
            pccTtlStWork = CopyToPccTtlStWorkFromPccTtlSt(pccTtlSt);

            paraList.Add(pccTtlStWork);

            Object objpccTtlStWorkList = paraList;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        
            //�����폜����
            status = _iPccTtlStDB.Delete(ref objpccTtlStWorkList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                paraList = (ArrayList)objpccTtlStWorkList;

                pccTtlSt = new PccTtlSt();

                //PCC�S�̐ݒ胏�[�N�N���X����UOE���ЃN���X�Ƀ����o�R�s�[
                pccTtlSt = this.CopyToPccTtlStFromPccTtlStWork((PccTtlStWork)paraList[0]);

                return status;
            }

            return status;
        }
    
        /// <summary>
        ///PCC�S�̐ݒ�o�^�E�X�V����
        /// </summary>
        /// <param name="pccTtlSt">UOE���ЃN���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :PCC�S�̐ݒ�̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref PccTtlSt pccTtlSt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            PccTtlStWork pccTtlStWork = new PccTtlStWork();

            ArrayList paraList = new ArrayList();

            //PCC�S�̐ݒ�N���X����UOE���Ѓ��[�N�N���X�Ƀ����o�R�s�[
            pccTtlStWork = CopyToPccTtlStWorkFromPccTtlSt(pccTtlSt);

            paraList.Add(pccTtlStWork);

            Object objpccTtlStWorkList = paraList;
          
            //��������
            status = _iPccTtlStDB.RevivalLogicalDelete(ref objpccTtlStWorkList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                paraList = (ArrayList)objpccTtlStWorkList;

                pccTtlSt = new PccTtlSt();

                //PCC�S�̐ݒ胏�[�N�N���X����UOE���ЃN���X�Ƀ����o�R�s�[
                pccTtlSt = this.CopyToPccTtlStFromPccTtlStWork((PccTtlStWork)paraList[0]);

                return status;
            }       

            return status;
        }
      
        #endregion

        #region Private Methods

        /// <summary>
        /// �N���X�����o�[�R�s�[�����iUOE���Ѓ��[�N�N���X��UOE���ЃN���X�j
        /// </summary>
        /// <param name="pccTtlStWork">UOE���Ѓ��[�N�N���X</param>
        /// <returns>UOE���ЃN���X</returns>
        /// <remarks>
        /// <br>Note       :PCC�S�̐ݒ胏�[�N�N���X����UOE���ЃN���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private PccTtlSt CopyToPccTtlStFromPccTtlStWork(PccTtlStWork pccTtlStWork)
        {
            PccTtlSt pccTtlSt = new PccTtlSt();
            pccTtlSt.CreateDateTime = pccTtlStWork.CreateDateTime;
            pccTtlSt.UpdateDateTime = pccTtlStWork.UpdateDateTime;
            pccTtlSt.EnterpriseCode = pccTtlStWork.EnterpriseCode;
            pccTtlSt.FileHeaderGuid = pccTtlStWork.FileHeaderGuid;
            pccTtlSt.UpdEmployeeCode = pccTtlStWork.UpdEmployeeCode;
            pccTtlSt.UpdAssemblyId1 = pccTtlStWork.UpdAssemblyId1;
            pccTtlSt.UpdAssemblyId2 = pccTtlStWork.UpdAssemblyId2;
            pccTtlSt.LogicalDeleteCode = pccTtlStWork.LogicalDeleteCode;
            //���_�R�[�h
            pccTtlSt.SectionCode = pccTtlStWork.SectionCode;

            string sectionName = string.Empty;
            if (this._secInfoSetTable != null && this._secInfoSetTable.ContainsKey(pccTtlStWork.SectionCode))
            {
                sectionName = (string)this._secInfoSetTable[pccTtlStWork.SectionCode];
            }
            pccTtlSt.SectionName = sectionName;
            pccTtlSt.FrontEmployeeCd = pccTtlStWork.FrontEmployeeCd.Trim();                                
            pccTtlSt.DeliveredGoodsDiv = pccTtlStWork.DeliveredGoodsDiv;
            pccTtlSt.DeliveredGoodsNm = GetDeliveredName(pccTtlStWork.DeliveredGoodsDiv);
            pccTtlSt.SalesSlipPrtDiv = pccTtlStWork.SalesSlipPrtDiv;                      
            pccTtlSt.SalesSlipPrtNm = GetNameFromDiv(pccTtlStWork.SalesSlipPrtDiv); 
            pccTtlSt.AcpOdrrSlipPrtDiv = pccTtlStWork.AcpOdrrSlipPrtDiv;                  
            pccTtlSt.AcpOdrrSlipPrtNm = GetNameFromDiv(pccTtlStWork.AcpOdrrSlipPrtDiv);                    

            return pccTtlSt;
        }
     
        /// <summary>
        /// �N���X�����o�[�R�s�[�����iUOE���ЃN���X��UOE���Ѓ��[�N�N���X�j
        /// </summary>
        /// <param name="pccTtlSt">UOE���Ѓ��[�N�N���X</param>
        /// <returns>UOE���ЃN���X</returns>
        /// <remarks>
        /// <br>Note       :PCC�S�̐ݒ�N���X����UOE���Ѓ��[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private PccTtlStWork CopyToPccTtlStWorkFromPccTtlSt(PccTtlSt pccTtlSt)
        {
            PccTtlStWork pccTtlStWork = new PccTtlStWork();

            pccTtlStWork.CreateDateTime = pccTtlSt.CreateDateTime;
            pccTtlStWork.UpdateDateTime = pccTtlSt.UpdateDateTime;
            pccTtlStWork.EnterpriseCode = pccTtlSt.EnterpriseCode;
            pccTtlStWork.FileHeaderGuid = pccTtlSt.FileHeaderGuid;
            pccTtlStWork.UpdEmployeeCode = pccTtlSt.UpdEmployeeCode;
            pccTtlStWork.UpdAssemblyId1 = pccTtlSt.UpdAssemblyId1;
            pccTtlStWork.UpdAssemblyId2 = pccTtlSt.UpdAssemblyId2;
            pccTtlStWork.LogicalDeleteCode = pccTtlSt.LogicalDeleteCode;
            pccTtlStWork.SectionCode = pccTtlSt.SectionCode;
            pccTtlStWork.SectionName = pccTtlSt.SectionName;            
            pccTtlStWork.FrontEmployeeCd = pccTtlSt.FrontEmployeeCd;                  
            pccTtlStWork.FrontEmployeeNm = pccTtlSt.FrontEmployeeNm;                 
            pccTtlStWork.DeliveredGoodsDiv = pccTtlSt.DeliveredGoodsDiv;             
            pccTtlStWork.SalesSlipPrtDiv = pccTtlSt.SalesSlipPrtDiv;                  
            pccTtlStWork.AcpOdrrSlipPrtDiv = pccTtlSt.AcpOdrrSlipPrtDiv;                          
            return pccTtlStWork;
        }      
      
        /// <summary>
        ///�敪�̖��̂̎擾
        /// </summary>
        /// <param name="div">�敪</param>
        /// <remarks>
        /// <br>Note		: �敪�̖��̂̎擾</br>
        /// <br>Programmer  : �t�I��</br>
        /// <br>Date        : 2011.08.01</br>
        /// </remarks>
        private string GetNameFromDiv(int div)
        {
            string name = string.Empty;
            switch (div)
            {
                case 0:
                    {
                        name = "���Ȃ�";
                        break;
                    }
                case 1:
                    {
                        name = "����";
                        break;
                    }
            }
            return name;
        }
         
        /// <summary>
        /// �N���X�����o�[�R�s�[�����iUOE���Ѓ��[�N�N���X��UOE���ЃN���X�j
        /// </summary>
        /// <param name="guideRow">UOE���Ѓ��[�N�N���X</param>
        /// <param name="pccTtlSt">UOE���Ѓ��[�N</param>
        /// <returns>UOE���ЃN���X</returns>
        /// <remarks>
        /// <br>Note       :PCC�S�̐ݒ胏�[�N�N���X����UOE���ЃN���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void CopyToGuideRowFromSearchData(ref DataRow guideRow, PccTtlSt pccTtlSt)
        {
            # region [�f�[�^����K�C�h�ɃZ�b�g�i���������j]
           
            # endregion
        }

        /// <summary>
        /// ���[�U�[�K�C�h�ݒ�̔[�i�敪�̎擾
        /// </summary>
        /// <remarks>
        /// <param name="enterpriseCode"> ��ƃR�[�h</param>
        /// <br>Note       : ���[�U�[�K�C�h�ݒ�̔[�i�敪���擾���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void SetDelivereds(string enterpriseCode)
        {
            //���[�U�[�K�C�h�ݒ�̔[�i�敪�̎擾
            ArrayList userGuidList = null;
            //�[�i�敪�̍���
            int userGuideDivCd = 48;
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }
            this._userGuideAcs.SearchAllDivCodeBody(out userGuidList, enterpriseCode, userGuideDivCd, UserGuideAcsData.UserBodyData);
            _userGdBdTb = new Hashtable();
            if (userGuidList != null || userGuidList.Count > 0)
            {
                foreach (UserGdBd userGdBd in userGuidList)
                {
                    if (userGdBd.LogicalDeleteCode == 0)
                    {
                        if (!_userGdBdTb.ContainsKey(userGdBd.GuideCode))
                        {
                             _userGdBdTb.Add(userGdBd.GuideCode, userGdBd.GuideName);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// �[�i�敪���̂̎擾
        /// </summary>
        /// <param name="deliveredGoodsDiv"> �[�i�敪</param>
        /// <remarks>
        /// <returns>�[�i�敪����</returns>
        /// <br>Note       : �[�i�敪���̂��擾���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private string GetDeliveredName(int deliveredGoodsDiv)
        {
            string deliveredName = string.Empty;
            if (this._userGdBdTb != null && this._userGdBdTb.ContainsKey(deliveredGoodsDiv))
            {
                deliveredName = (string)this._userGdBdTb[deliveredGoodsDiv];
            }
            return deliveredName;
        }
        #endregion
    }
}
