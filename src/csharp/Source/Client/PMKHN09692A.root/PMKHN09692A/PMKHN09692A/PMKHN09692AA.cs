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
    /// BL�R�[�h�ϊ��}�X�^ �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : BL�R�[�h�ϊ��}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : �g�� �F�� 30745</br>
    /// <br>Date       : 2012.08.01</br>
    /// <br></br>
    /// </remarks>
    public class BLGoodsCdChgUAcs
    {
        #region Private Member

        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        //BL�R�[�h�ϊ��}�X�^
        private IBLGoodsCdChgUDB _iBLGoodsCdChgUDB = null;
        private SecInfoSetAcs _secInfoSetAcs = null;
        private Hashtable _secInfoSetTable = null;

        #endregion

        #region Constructor

        /// <summary>
        ///BL�R�[�h�ϊ��}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       :BL�R�[�h�ϊ��}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012.08.01</br>
        /// </remarks>
        public BLGoodsCdChgUAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iBLGoodsCdChgUDB = (IBLGoodsCdChgUDB)MediationBLGoodsCdChgUDB.GetBLGoodsCdChgUDB();
                _secInfoSetAcs = new SecInfoSetAcs();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iBLGoodsCdChgUDB = null;
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
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012.08.01</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iBLGoodsCdChgUDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }
      
        /// <summary>
        ///BL�R�[�h�ϊ��}�X�^�ǂݍ��ݏ���
        /// </summary>
        /// <param name="blCodeChange">UOE���ЃI�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       :BL�R�[�h�ϊ��}�X�^����ǂݍ��݂܂��B</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012.08.01</br>
        /// </remarks>
        public int Read(out  BLGoodsCdChgU blCodeChange, string enterpriseCode)
        {
            try
            {
                // �L�[���̐ݒ�
                blCodeChange = null;
                BLGoodsCdChgUWork blCodeChangeWork = new BLGoodsCdChgUWork();
                blCodeChangeWork.EnterpriseCode = enterpriseCode;
            
                //BL�R�[�h�ϊ��}�X�^���[�J�[�N���X���I�u�W�F�N�g�ɐݒ�
                object paraObj = blCodeChangeWork as object;

                //UOE���Ѓ}�X�^�ǂݍ���
                int status = this._iBLGoodsCdChgUDB.Read(ref paraObj, 0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �ǂݍ��݌��ʂ�UOE���Ѓ��[�J�[�N���X�ɐݒ�
                    BLGoodsCdChgUWork wkBLGoodsCdChgUWork = (BLGoodsCdChgUWork)paraObj;
                    //BL�R�[�h�ϊ��}�X�^���[�J�[�N���X����BL�R�[�h�ϊ��}�X�^�N���X�ɃR�s�[
                    blCodeChange = CopyToBLGoodsCdChgUFromBLGoodsCdChgUWork(wkBLGoodsCdChgUWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iBLGoodsCdChgUDB = null;
                //�ʐM�G���[��-1��߂�
                blCodeChange = null;
                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
        }
             
        /// <summary>
        ///BL�R�[�h�ϊ��}�X�^�o�^�E�X�V����
        /// </summary>
        /// <param name="blCodeChange">BL�R�[�h�ϊ��}�X�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :BL�R�[�h�ϊ��}�X�^�̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012.08.01</br>
        /// </remarks>
        public int Write(ref BLGoodsCdChgU blCodeChange)
        {
            BLGoodsCdChgUWork blCodeChangeWork = new BLGoodsCdChgUWork();
            ArrayList paraList = new ArrayList();

            //BL�R�[�h�ϊ��}�X�^�N���X����BL�R�[�h�ϊ��}�X�^���[�N�N���X�Ƀ����o�R�s�[
            blCodeChangeWork = CopyToBLGoodsCdChgUWorkFromBLGoodsCdChgU(blCodeChange);

            //BL�R�[�h�ϊ��}�X�^�̓o�^�E�X�V����ݒ�
            paraList.Add(blCodeChangeWork);

            object paraObj = paraList;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {               
                //BL�R�[�h�ϊ��}�X�^��������
                status = this._iBLGoodsCdChgUDB.Write(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraList = (ArrayList)paraObj;

                    blCodeChange = new BLGoodsCdChgU();

                    //BL�R�[�h�ϊ��}�X�^���[�N�N���X����BL�R�[�h�ϊ��}�X�^�N���X�Ƀ����o�R�s�[
                    blCodeChange = this.CopyToBLGoodsCdChgUFromBLGoodsCdChgUWork((BLGoodsCdChgUWork)paraList[0]);
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iBLGoodsCdChgUDB = null;
                // �ʐM�G���[��-1��߂�
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
    
        /// <summary>
        ///BL�R�[�h�ϊ��}�X�^�o�^�E�X�V����
        /// </summary>
        /// <param name="blCodeChangeList">BL�R�[�h�ϊ��}�X�^�N���X</param>
        /// <param name="parseBLGoodsCdChgU">��ƃR�[�h</param>
        /// <param name="retTotalCnt">����</param>
        /// <param name="readMode"></param>
        /// <param name="readCnt">����</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :BL�R�[�h�ϊ��}�X�^�̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012.08.01</br>
        /// </remarks>
        public int Search(ref List<BLGoodsCdChgU> blCodeChangeList, BLGoodsCdChgU parseBLGoodsCdChgU, out int retTotalCnt, int readMode, int readCnt, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            blCodeChangeList = null;
            Object objblCodeChangeWorkList = null;
            BLGoodsCdChgUWork parseBLGoodsCdChgUWork = null;
            ArrayList blCodeChangeWorkResultList = null;
            List<BLGoodsCdChgUWork> blCodeChangeWorkList = null;

            retTotalCnt = 0;
            parseBLGoodsCdChgUWork = new BLGoodsCdChgUWork();
            parseBLGoodsCdChgUWork.EnterpriseCode = parseBLGoodsCdChgU.EnterpriseCode;
            parseBLGoodsCdChgUWork.SectionCode = parseBLGoodsCdChgU.SectionCode;

            // ���_�A�N�Z�X�N���X
            if (_secInfoSetAcs == null)
            {
                _secInfoSetAcs = new SecInfoSetAcs();
            }
            // ���_���
            ArrayList secInfoSetList = null;
            status = _secInfoSetAcs.Search(out secInfoSetList, parseBLGoodsCdChgU.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && secInfoSetList != null)
            {
                this._secInfoSetTable = new Hashtable();
                foreach (SecInfoSet secInfoSet in secInfoSetList)
                {
                    this._secInfoSetTable.Add(secInfoSet.SectionCode, secInfoSet.SectionGuideSnm);

                }
            }

            //��������
            status = _iBLGoodsCdChgUDB.Search(ref objblCodeChangeWorkList, parseBLGoodsCdChgUWork, readMode, logicalMode);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            //���ʂ�߂�
            blCodeChangeWorkResultList = objblCodeChangeWorkList as ArrayList;

            if (blCodeChangeWorkResultList != null)
            {
                blCodeChangeWorkList = new List<BLGoodsCdChgUWork>((BLGoodsCdChgUWork[])blCodeChangeWorkResultList.ToArray(typeof(BLGoodsCdChgUWork)));
            }
            if (blCodeChangeWorkList != null)
            {
                blCodeChangeList = new List<BLGoodsCdChgU>();
                foreach (BLGoodsCdChgUWork blCodeChangeWork in blCodeChangeWorkList)
                {
                    if (blCodeChangeWork.EnterpriseCode == parseBLGoodsCdChgU.EnterpriseCode &&
                        ((parseBLGoodsCdChgU.SectionCode == "") || (blCodeChangeWork.SectionCode.TrimEnd() == parseBLGoodsCdChgU.SectionCode.TrimEnd()) || (blCodeChangeWork.SectionCode.TrimEnd() == "")))
                    {
                        BLGoodsCdChgU blCodeChange = null;
                        blCodeChange = CopyToBLGoodsCdChgUFromBLGoodsCdChgUWork(blCodeChangeWork);
                        blCodeChangeList.Add(blCodeChange);
                    }
                }
            }

            return status;
        }
    
        /// <summary>
        ///BL�R�[�h�ϊ��}�X�^�o�^�E�X�V����
        /// </summary>
        /// <param name="blCodeChange">BL�R�[�h�ϊ��}�X�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :BL�R�[�h�ϊ��}�X�^�̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012.08.01</br>
        /// </remarks>
        public int LogicalDelete(ref BLGoodsCdChgU blCodeChange) 
        {

            ArrayList paraList = new ArrayList();
            BLGoodsCdChgUWork blCodeChangeWork = new BLGoodsCdChgUWork();

            //BL�R�[�h�ϊ��}�X�^�N���X����BL�R�[�h�ϊ��}�X�^���[�N�N���X�Ƀ����o�R�s�[
            blCodeChangeWork = CopyToBLGoodsCdChgUWorkFromBLGoodsCdChgU(blCodeChange);

            paraList.Add(blCodeChangeWork);

            Object objblCodeChangeWorkList = paraList;
           
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
  
              
            // �_���폜����
            status = _iBLGoodsCdChgUDB.LogicalDelete(ref objblCodeChangeWorkList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {

                paraList = (ArrayList)objblCodeChangeWorkList;

                blCodeChange = new BLGoodsCdChgU();

                //BL�R�[�h�ϊ��}�X�^���[�N�N���X����BL�R�[�h�ϊ��}�X�^�N���X�Ƀ����o�R�s�[
                blCodeChange = this.CopyToBLGoodsCdChgUFromBLGoodsCdChgUWork((BLGoodsCdChgUWork)paraList[0]);

                return status;
            }               
            return status;
        }
    
        /// <summary>
        ///BL�R�[�h�ϊ��}�X�^�o�^�E�X�V����
        /// </summary>
        /// <param name="blCodeChange">BL�R�[�h�ϊ��}�X�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :BL�R�[�h�ϊ��}�X�^�̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012.08.01</br>
        /// </remarks>
        public int Delete(ref BLGoodsCdChgU blCodeChange)
        {

            BLGoodsCdChgUWork blCodeChangeWork = new BLGoodsCdChgUWork();

            ArrayList paraList = new ArrayList();

            //BL�R�[�h�ϊ��}�X�^�N���X����BL�R�[�h�ϊ��}�X�^���[�N�N���X�Ƀ����o�R�s�[
            blCodeChangeWork = CopyToBLGoodsCdChgUWorkFromBLGoodsCdChgU(blCodeChange);

            paraList.Add(blCodeChangeWork);

            Object objblCodeChangeWorkList = paraList;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        
            //�����폜����
            status = _iBLGoodsCdChgUDB.Delete(ref objblCodeChangeWorkList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                paraList = (ArrayList)objblCodeChangeWorkList;

                blCodeChange = new BLGoodsCdChgU();

                //BL�R�[�h�ϊ��}�X�^���[�N�N���X����BL�R�[�h�ϊ��}�X�^�N���X�Ƀ����o�R�s�[
                blCodeChange = this.CopyToBLGoodsCdChgUFromBLGoodsCdChgUWork((BLGoodsCdChgUWork)paraList[0]);

                return status;
            }

            return status;
        }
    
        /// <summary>
        ///BL�R�[�h�ϊ��}�X�^�o�^�E�X�V����
        /// </summary>
        /// <param name="blCodeChange">BL�R�[�h�ϊ��}�X�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :BL�R�[�h�ϊ��}�X�^�̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012.08.01</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref BLGoodsCdChgU blCodeChange)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            BLGoodsCdChgUWork blCodeChangeWork = new BLGoodsCdChgUWork();

            ArrayList paraList = new ArrayList();

            //BL�R�[�h�ϊ��}�X�^�N���X����BL�R�[�h�ϊ��}�X�^���[�N�N���X�Ƀ����o�R�s�[
            blCodeChangeWork = CopyToBLGoodsCdChgUWorkFromBLGoodsCdChgU(blCodeChange);

            paraList.Add(blCodeChangeWork);

            Object objblCodeChangeWorkList = paraList;
          
            //��������
            status = _iBLGoodsCdChgUDB.RevivalLogicalDelete(ref objblCodeChangeWorkList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                paraList = (ArrayList)objblCodeChangeWorkList;

                blCodeChange = new BLGoodsCdChgU();

                //BL�R�[�h�ϊ��}�X�^���[�N�N���X����BL�R�[�h�ϊ��}�X�^�N���X�Ƀ����o�R�s�[
                blCodeChange = this.CopyToBLGoodsCdChgUFromBLGoodsCdChgUWork((BLGoodsCdChgUWork)paraList[0]);

                return status;
            }       

            return status;
        }
      
        #endregion

        #region Private Methods

        /// <summary>
        /// �N���X�����o�[�R�s�[�����iBL�R�[�h�ϊ��}�X�^���[�N�N���X��BL�R�[�h�ϊ��}�X�^�N���X�j
        /// </summary>
        /// <param name="blCodeChangeWork">BL�R�[�h�ϊ��}�X�^���[�N�N���X</param>
        /// <returns>BL�R�[�h�ϊ��}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       :BL�R�[�h�ϊ��}�X�^���[�N�N���X����BL�R�[�h�ϊ��}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012.08.01</br>
        /// </remarks>
        private BLGoodsCdChgU CopyToBLGoodsCdChgUFromBLGoodsCdChgUWork(BLGoodsCdChgUWork blCodeChangeWork)
        {
            BLGoodsCdChgU blCodeChange = new BLGoodsCdChgU();
            blCodeChange.CreateDateTime = blCodeChangeWork.CreateDateTime;
            blCodeChange.UpdateDateTime = blCodeChangeWork.UpdateDateTime;
            blCodeChange.EnterpriseCode = blCodeChangeWork.EnterpriseCode;
            blCodeChange.FileHeaderGuid = blCodeChangeWork.FileHeaderGuid;
            blCodeChange.UpdEmployeeCode = blCodeChangeWork.UpdEmployeeCode;
            blCodeChange.UpdAssemblyId1 = blCodeChangeWork.UpdAssemblyId1;
            blCodeChange.UpdAssemblyId2 = blCodeChangeWork.UpdAssemblyId2;
            blCodeChange.LogicalDeleteCode = blCodeChangeWork.LogicalDeleteCode;
            blCodeChange.SectionCode = blCodeChangeWork.SectionCode;
            blCodeChange.CustomerCode = blCodeChangeWork.CustomerCode;

            blCodeChange.PMBLGoodsCode = blCodeChangeWork.PMBLGoodsCode;
            blCodeChange.PMBLGoodsCodeDerivNo = blCodeChangeWork.PMBLGoodsCodeDerivNo;
            blCodeChange.SFBLGoodsCode = blCodeChangeWork.SFBLGoodsCode;
            blCodeChange.SFBLGoodsCodeDerivNo = blCodeChangeWork.SFBLGoodsCodeDerivNo;
            blCodeChange.BLGoodsFullName = blCodeChangeWork.BLGoodsFullName;
            blCodeChange.BLGoodsHalfName = blCodeChangeWork.BLGoodsHalfName;                  

            return blCodeChange;
        }
     
        /// <summary>
        /// �N���X�����o�[�R�s�[�����iBL�R�[�h�ϊ��}�X�^�N���X��BL�R�[�h�ϊ��}�X�^���[�N�N���X�j
        /// </summary>
        /// <param name="blCodeChange">BL�R�[�h�ϊ��}�X�^���[�N�N���X</param>
        /// <returns>BL�R�[�h�ϊ��}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       :BL�R�[�h�ϊ��}�X�^�N���X����BL�R�[�h�ϊ��}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012.08.01</br>
        /// </remarks>
        private BLGoodsCdChgUWork CopyToBLGoodsCdChgUWorkFromBLGoodsCdChgU(BLGoodsCdChgU blCodeChange)
        {
            BLGoodsCdChgUWork blCodeChangeWork = new BLGoodsCdChgUWork();

            blCodeChangeWork.CreateDateTime = blCodeChange.CreateDateTime;
            blCodeChangeWork.UpdateDateTime = blCodeChange.UpdateDateTime;
            blCodeChangeWork.EnterpriseCode = blCodeChange.EnterpriseCode;
            blCodeChangeWork.FileHeaderGuid = blCodeChange.FileHeaderGuid;
            blCodeChangeWork.UpdEmployeeCode = blCodeChange.UpdEmployeeCode;
            blCodeChangeWork.UpdAssemblyId1 = blCodeChange.UpdAssemblyId1;
            blCodeChangeWork.UpdAssemblyId2 = blCodeChange.UpdAssemblyId2;
            blCodeChangeWork.LogicalDeleteCode = blCodeChange.LogicalDeleteCode;
            blCodeChangeWork.SectionCode = blCodeChange.SectionCode;
            blCodeChangeWork.CustomerCode = blCodeChange.CustomerCode;
            blCodeChangeWork.PMBLGoodsCode = blCodeChange.PMBLGoodsCode;
            blCodeChangeWork.PMBLGoodsCodeDerivNo = blCodeChange.PMBLGoodsCodeDerivNo;
            blCodeChangeWork.SFBLGoodsCode = blCodeChange.SFBLGoodsCode;
            blCodeChangeWork.SFBLGoodsCodeDerivNo = blCodeChange.SFBLGoodsCodeDerivNo;
            blCodeChangeWork.BLGoodsFullName = blCodeChange.BLGoodsFullName;
            blCodeChangeWork.BLGoodsHalfName = blCodeChange.BLGoodsHalfName;
            return blCodeChangeWork;
        }      
      
        #endregion
    }
}
