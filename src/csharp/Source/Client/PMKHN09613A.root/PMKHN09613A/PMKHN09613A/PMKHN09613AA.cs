//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[�������D��ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : �L�����y�[�������D��ݒ�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���N�n��
// �� �� ��  2011/04/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;
using System.Data;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �L�����y�[�������D��ݒ�}�X�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[�������D��ݒ�}�X�^�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : ���N�n��</br>
    /// <br>Date       : 2011/04/25</br>
    /// <br></br>
    /// </remarks>
    public class CampaignPrcPrStAcs
    {
        #region -- �����[�g�I�u�W�F�N�g�i�[�o�b�t�@ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private ICampaignPrcPrStDB _iCampaignPrcPrStDB = null;

        // ���[�J���c�a���[�h
        private static bool _isLocalDBRead = false;	// �f�t�H���g�̓����[�g

        #endregion

        #region -- �R���X�g���N�^ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br></br>
        /// </remarks>
        public CampaignPrcPrStAcs()
        {
            // �����[�g�I�u�W�F�N�g�擾
            this._iCampaignPrcPrStDB = (ICampaignPrcPrStDB)MediationCampaignPrcPrStDB.GetCampaignPrcPrStDB();
        }

        #endregion

        #region [���[�J���A�N�Z�X�p]
        /// <summary> �������[�h </summary>
        public enum SearchMode
        {
            /// <summary> ���[�J���A�N�Z�X </summary>
            Local = 0,
            /// <summary> �����[�g�A�N�Z�X </summary>
            Remote = 1
        }
        #endregion

        #region -- �o�^��X�V���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �o�^�E�X�V����
        /// </summary>
        /// <param name="campaignPrcPrSt">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �o�^�E�X�V�������s���܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int Write(ref CampaignPrcPrSt campaignPrcPrSt)
        {
            int status = 0;
           
            try
            {
                // UI�f�[�^�N���X�����[�N
                CampaignPrcPrStWork campaignPrcPrStWork = CopyToCampaignPrcPrStWorkFromCampaignPrcPrSt(campaignPrcPrSt);

                object objCampaignPrcPrStWork = campaignPrcPrStWork;

                int writeMode = 0;

                // �������ݏ���
                status = this._iCampaignPrcPrStDB.Write(ref objCampaignPrcPrStWork, writeMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {

                    campaignPrcPrStWork = objCampaignPrcPrStWork as CampaignPrcPrStWork;

                    // �N���X�������o�R�s�[
                    campaignPrcPrSt = CopyToCampaignPrcPrStFromCampaignPrcPrStWork(campaignPrcPrStWork);
                }
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iCampaignPrcPrStDB = null;

                //�ʐM�G���[��-1��߂�
                return -1;
            }
          
            return status;
        }

        #endregion -- �o�^��X�V���� --

        #region -- �폜���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <param name="campaignPrcPrSt">�L�����y�[�������D��ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[�������D��ݒ�}�X�^�̘_���폜���s���܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int LogicalDelete(ref CampaignPrcPrSt campaignPrcPrSt)
        {
            try
            {
                CampaignPrcPrStWork campaignPrcPrStWork = CopyToCampaignPrcPrStWorkFromCampaignPrcPrSt(campaignPrcPrSt);
                object objCampaignPrcPrStWork = campaignPrcPrStWork;

                // ���_���_���폜
                int status = this._iCampaignPrcPrStDB.LogicalDelete(ref objCampaignPrcPrStWork);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �t�@�C������n���ċ��_��񃏁[�N�N���X���f�V���A���C�Y����
                    campaignPrcPrStWork = objCampaignPrcPrStWork as CampaignPrcPrStWork;

                    // �N���X�������o�R�s�[
                    campaignPrcPrSt = CopyToCampaignPrcPrStFromCampaignPrcPrStWork(campaignPrcPrStWork);

                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iCampaignPrcPrStDB = null;

                //�ʐM�G���[��-1��߂�
                return -1;
            }
           
        }

        /// <summary>
        /// �����폜����
        /// </summary>
        /// <param name="campaignPrcPrSt">�L�����y�[�������D��ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[�������D��ݒ�}�X�^�̕����폜���s���܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int Delete(CampaignPrcPrSt campaignPrcPrSt)
        {
            try
            {
                CampaignPrcPrStWork campaignPrcPrStWorks = new CampaignPrcPrStWork();
                campaignPrcPrStWorks = CopyToCampaignPrcPrStWorkFromCampaignPrcPrSt(campaignPrcPrSt);

                byte[] parabyte = XmlByteSerializer.Serialize(campaignPrcPrStWorks);

                // �����폜
                int status = this._iCampaignPrcPrStDB.Delete(parabyte);
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iCampaignPrcPrStDB = null;

                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        #endregion

        #region -- ������������� --

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �L�����y�[�������D��ݒ�}�X�^�S�����������i�_���폜�܂ށj
        /// </summary>
        /// <param name="campaignPrcPrStList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[�������D��ݒ�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int SearchAll(out ArrayList campaignPrcPrStList, string enterpriseCode)
        {
            return SearchProc(out campaignPrcPrStList, enterpriseCode, SearchMode.Remote);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �L�����y�[�������D��ݒ�}�X�^�S����������
        /// </summary>
        /// <param name="campaignPrcPrStList">�Ǎ����ʃR���N�V����</param>  
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="searchMode">�������[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[�������D��ݒ�}�X�^�̌����������s���܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList campaignPrcPrStList, string enterpriseCode, SearchMode searchMode)
        {

            _isLocalDBRead = searchMode == SearchMode.Local ? true : false;

            CampaignPrcPrStWork campaignPrcPrStWork = new CampaignPrcPrStWork();

            campaignPrcPrStWork.EnterpriseCode = enterpriseCode;

            int status = 0;

            campaignPrcPrStList = new ArrayList();
            campaignPrcPrStList.Clear();

            ArrayList campaignPrcPrStWorkList = new ArrayList();
            campaignPrcPrStWorkList.Clear();

            object paraobj = campaignPrcPrStWork;
            object retobj = null;

            status = this._iCampaignPrcPrStDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData01);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                campaignPrcPrStWorkList = retobj as ArrayList;

                foreach (CampaignPrcPrStWork wkCampaignPrcPrStWork in campaignPrcPrStWorkList)
                {
                    campaignPrcPrStList.Add(CopyToCampaignPrcPrStFromCampaignPrcPrStWork(wkCampaignPrcPrStWork));
                }
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            }

            // STATUS ��ݒ�
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                (campaignPrcPrStList.Count == 0))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }

        /// <summary>
        /// �L�����y�[�������D��ݒ�}�X�^��������
        /// </summary>
        /// <param name="campaignPrcPrSt">�L�����y�[�������D��ݒ�N���X�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[�������D��ݒ�}�X�^�̌����������s���܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int Read(out CampaignPrcPrSt campaignPrcPrSt, string enterpriseCode, string sectionCode)
        {
            try
            {
                campaignPrcPrSt = null;

                CampaignPrcPrStWork campaignPrcPrStWork = new CampaignPrcPrStWork();

                campaignPrcPrStWork.EnterpriseCode = enterpriseCode;
                campaignPrcPrStWork.SectionCode = sectionCode;

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(campaignPrcPrStWork);

                // ���[�����M�Ǘ��t�B�[���h���̓ǂݍ���
                int status = this._iCampaignPrcPrStDB.Read(ref parabyte, 0);

                if (status == 0)
                {
                    // XML�̓ǂݍ���
                    campaignPrcPrStWork = (CampaignPrcPrStWork)XmlByteSerializer.Deserialize(parabyte, typeof(CampaignPrcPrStWork));
                    // �N���X�������o�R�s�[
                    campaignPrcPrSt = CopyToCampaignPrcPrStFromCampaignPrcPrStWork(campaignPrcPrStWork);
                }
                return status;
            }
            catch (Exception)
            {
                //�ʐM�G���[��-1��߂�
                campaignPrcPrSt = null;
                //�I�t���C������null���Z�b�g
                this._iCampaignPrcPrStDB = null;
                return -1;
            }
        }

        /// <summary>
        /// �_���폜��������
        /// </summary>
        /// <param name="campaignPrcPrSt">�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �̕������s���܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int Revival(ref CampaignPrcPrSt campaignPrcPrSt)
        {
            try
            {
                CampaignPrcPrStWork campaignPrcPrStWork = CopyToCampaignPrcPrStWorkFromCampaignPrcPrSt(campaignPrcPrSt);

                // XML�֕ϊ����A������̃o�C�i����
                object objCampaignPrcPrStWork = campaignPrcPrStWork;

                // ��������
                int status = this._iCampaignPrcPrStDB.RevivalLogicalDelete(ref objCampaignPrcPrStWork);


                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �t�@�C������n���ċ��_��񃏁[�N�N���X���f�V���A���C�Y����
                    campaignPrcPrStWork = objCampaignPrcPrStWork as CampaignPrcPrStWork;

                    // �N���X�������o�R�s�[
                    campaignPrcPrSt = CopyToCampaignPrcPrStFromCampaignPrcPrStWork(campaignPrcPrStWork);

                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iCampaignPrcPrStDB = null;

                //�ʐM�G���[��-1��߂�
                return -1;
            }
           
           
        }

        #endregion -- ������������� --

        #region -- �N���X�����o�[�R�s�[���� --

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�L�����y�[�������D��ݒ�}�X�^���[�N�N���X�˃L�����y�[�������D��ݒ�}�X�^�N���X�j
        /// </summary>
        /// <param name="campaignPrcPrStWork">�L�����y�[�������D��ݒ�}�X�^���[�N�N���X</param>
        /// <returns>�L�����y�[�������D��ݒ�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[�������D��ݒ�}�X�^���[�N�N���X����L�����y�[�������D��ݒ�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private CampaignPrcPrSt CopyToCampaignPrcPrStFromCampaignPrcPrStWork(CampaignPrcPrStWork campaignPrcPrStWork)
        {
            CampaignPrcPrSt campaignPrcPrSt = new CampaignPrcPrSt();
            campaignPrcPrSt.CreateDateTime = campaignPrcPrStWork.CreateDateTime;
            campaignPrcPrSt.UpdateDateTime = campaignPrcPrStWork.UpdateDateTime;
            campaignPrcPrSt.EnterpriseCode = campaignPrcPrStWork.EnterpriseCode;
            campaignPrcPrSt.FileHeaderGuid = campaignPrcPrStWork.FileHeaderGuid;
            campaignPrcPrSt.UpdEmployeeCode = campaignPrcPrStWork.UpdEmployeeCode;
            campaignPrcPrSt.UpdAssemblyId1 = campaignPrcPrStWork.UpdAssemblyId1;
            campaignPrcPrSt.UpdAssemblyId2 = campaignPrcPrStWork.UpdAssemblyId2;
            campaignPrcPrSt.LogicalDeleteCode = campaignPrcPrStWork.LogicalDeleteCode;
            campaignPrcPrSt.SectionCode = campaignPrcPrStWork.SectionCode;
            campaignPrcPrSt.PrioritySettingCd1 = campaignPrcPrStWork.PrioritySettingCd1;
            campaignPrcPrSt.PrioritySettingCd2 = campaignPrcPrStWork.PrioritySettingCd2;
            campaignPrcPrSt.PrioritySettingCd3 = campaignPrcPrStWork.PrioritySettingCd3;
            campaignPrcPrSt.PrioritySettingCd4 = campaignPrcPrStWork.PrioritySettingCd4;
            campaignPrcPrSt.PrioritySettingCd5 = campaignPrcPrStWork.PrioritySettingCd5;
            campaignPrcPrSt.PrioritySettingCd6 = campaignPrcPrStWork.PrioritySettingCd6;

            return campaignPrcPrSt;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�L�����y�[�������D��ݒ�}�X�^�N���X�˃L�����y�[�������D��ݒ�}�X�^���[�N�N���X�j
        /// </summary>
        /// <param name="allDefSet">�L�����y�[�������D��ݒ�}�X�^�N���X</param>
        /// <returns>�L�����y�[�������D��ݒ�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[�������D��ݒ�}�X�^�N���X����L�����y�[�������D��ݒ�}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private CampaignPrcPrStWork CopyToCampaignPrcPrStWorkFromCampaignPrcPrSt(CampaignPrcPrSt campaignPrcPrSt)
        {
            CampaignPrcPrStWork campaignPrcPrStWork = new CampaignPrcPrStWork();
            campaignPrcPrStWork.CreateDateTime = campaignPrcPrSt.CreateDateTime;
            campaignPrcPrStWork.UpdateDateTime = campaignPrcPrSt.UpdateDateTime;
            campaignPrcPrStWork.EnterpriseCode = campaignPrcPrSt.EnterpriseCode;
            campaignPrcPrStWork.FileHeaderGuid = campaignPrcPrSt.FileHeaderGuid;
            campaignPrcPrStWork.UpdEmployeeCode = campaignPrcPrSt.UpdEmployeeCode;
            campaignPrcPrStWork.UpdAssemblyId1 = campaignPrcPrSt.UpdAssemblyId1;
            campaignPrcPrStWork.UpdAssemblyId2 = campaignPrcPrSt.UpdAssemblyId2;
            campaignPrcPrStWork.LogicalDeleteCode = campaignPrcPrSt.LogicalDeleteCode;
            campaignPrcPrStWork.SectionCode = campaignPrcPrSt.SectionCode;
            campaignPrcPrStWork.PrioritySettingCd1 = campaignPrcPrSt.PrioritySettingCd1;
            campaignPrcPrStWork.PrioritySettingCd2 = campaignPrcPrSt.PrioritySettingCd2;
            campaignPrcPrStWork.PrioritySettingCd3 = campaignPrcPrSt.PrioritySettingCd3;
            campaignPrcPrStWork.PrioritySettingCd4 = campaignPrcPrSt.PrioritySettingCd4;
            campaignPrcPrStWork.PrioritySettingCd5 = campaignPrcPrSt.PrioritySettingCd5;
            campaignPrcPrStWork.PrioritySettingCd6 = campaignPrcPrSt.PrioritySettingCd6;

            return campaignPrcPrStWork;

        }

        #endregion -- �N���X�����o�[�R�s�[���� --
       

    }
}
