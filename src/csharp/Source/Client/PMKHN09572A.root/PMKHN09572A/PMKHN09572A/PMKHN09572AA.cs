//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[���֘A�}�X�^
// �v���O�����T�v   : �L�����y�[���֘A�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/05/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �L�����y�[���֘A�}�X�^�e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���֘A�}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br></br>
    /// </remarks>
    public class CampaignLinkAcs
    {
        #region -- �����[�g�I�u�W�F�N�g�i�[�o�b�t�@ --
        /// <summary>
        /// �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
		private ICampaignLinkDB _iCampaignLinkDB = null;
        
        #endregion

        #region -- Private Member --
        /// <summary> �L�����y�[���ݒ�A�N�Z�X�N���X </summary>
        private CampaignStAcs _campaignStAcs = null;

        /// <summary> �L�����y�[���ݒ�f�B�N�V���i���[ </summary>
        private Dictionary<int, CampaignSt> _campaignStDic = null;
        #endregion

        #region -- �R���X�g���N�^ --
        /// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �V�����C���X�^���X�����������܂��B</br>
		/// <br></br>
		/// </remarks>
        static CampaignLinkAcs()
		{			
		}

        /// <summary>
        /// �L�����y�[���֘A�}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �L�����y�[���֘A�}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br></br>
        /// </remarks>
        public CampaignLinkAcs()
		{
			try
			{
				// �����[�g�I�u�W�F�N�g�擾
                this._iCampaignLinkDB = (ICampaignLinkDB)MediationCampaignLinkDB.GetCampaignLinkDB();
			}
			catch (Exception)
			{				
				//�I�t���C������null���Z�b�g
                this._iCampaignLinkDB = null;
			}
		}

        #endregion

        #region -- �v���p�e�B --
        public CampaignStAcs CampaignStAcs
        {
            get
            {
                if (_campaignStAcs == null)
                {
                    _campaignStAcs = new CampaignStAcs();
                }
                return _campaignStAcs;
            }
        }
        #endregion

        #region -- �I�����C�����[�h�擾���� --
        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iCampaignLinkDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }
        #endregion

        #region -- �ǂݍ��ݏ��� --
        /// <summary>
        /// �ǂݍ��ݏ���
        /// </summary>
        /// <param name="campaignLink">UI�f�[�^�N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param> 
        /// <param name="campaignCode">�L�����y�[���R�[�h</param>  
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        public int Read(out CampaignLink campaignLink, string enterpriseCode, int campaignCode)
        {
            return ReadProc(out campaignLink, enterpriseCode, campaignCode);
        }

        /// <summary>
        /// �ǂݍ��ݏ���
        /// </summary>
        /// <param name="campaignLink">UI�f�[�^�N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param> 
        /// <param name="campaignCode">�L�����y�[���R�[�h</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private int ReadProc(out CampaignLink campaignLink, string enterpriseCode, int campaignCode)
        {
            int status = 0;

            campaignLink = null;

            try
            {
                CampaignLinkWork campaignLinkWork = new CampaignLinkWork();
                campaignLinkWork.EnterpriseCode = enterpriseCode;
                campaignLinkWork.CampaignCode = campaignCode;

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(campaignLinkWork);

                status = this._iCampaignLinkDB.Read(ref parabyte, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XML�̓ǂݍ���
                    campaignLinkWork = (CampaignLinkWork)XmlByteSerializer.Deserialize(parabyte, typeof(CampaignLinkWork));
                    // ���[�N��UI�f�[�^�N���X
                    campaignLink = CopyToCampaignLinkFromCampaignLinkWork(campaignLinkWork);
                }

                return status;
            }
            catch (Exception)
            {
                campaignLink = null;
                // �I�t���C������null���Z�b�g
                this._iCampaignLinkDB = null;
                // �ʐM�G���[��-1��߂�
                return -1;
            }
        }
        #endregion

        #region -- �o�^��X�V���� --
        /// <summary>
        /// �o�^�E�X�V����
        /// </summary>
        /// <param name="campaignLinkList">UI�f�[�^�N���X���X�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �o�^�E�X�V�������s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int Write(ref ArrayList campaignLinkList)
        {
            int status = 0;
            ArrayList paraList = new ArrayList();            
            CampaignLinkWork campaignLinkWork = new CampaignLinkWork();

            foreach (CampaignLink campaignLink in campaignLinkList)
            {
                // UI�f�[�^�N���X�����[�N
                campaignLinkWork = CopyToCampaignLinkWorkFromCampaignLink(campaignLink);

                // �o�^�E�X�V����ݒ�
                paraList.Add(campaignLinkWork);
            }

            object obj = paraList;

            try
            {
                // �������ݏ���
                status = this._iCampaignLinkDB.Write(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraList = (ArrayList)obj;
                    campaignLinkList.Clear();

                    foreach (CampaignLinkWork wkCampaignLinkWork in paraList)
                    {
                        CampaignLink campaignLink = new CampaignLink();
                        // ���[�N��UI�f�[�^�N���X
                        campaignLink = this.CopyToCampaignLinkFromCampaignLinkWork((CampaignLinkWork)wkCampaignLinkWork);
                        campaignLinkList.Add(campaignLink);
                    }
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iCampaignLinkDB = null;
                // �ʐM�G���[��-1��߂�
                status = -1;
            }
            return status;
        }
        #endregion

        #region -- �폜���� --
        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <param name="campaignLinkList">UI�f�[�^�N���X���X�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���֘A�̘_���폜���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int LogicalDelete(ref ArrayList campaignLinkList)
        {
            int status = 0;
            ArrayList paraList = new ArrayList();
            CampaignLinkWork campaignLinkWork = new CampaignLinkWork();

            foreach (CampaignLink campaignLink in campaignLinkList)
            {
                // UI�f�[�^�N���X�����[�N
                campaignLinkWork = CopyToCampaignLinkWorkFromCampaignLink(campaignLink);

                // �_���폜����ݒ�
                paraList.Add(campaignLinkWork);
            }

            object obj = paraList;

            try
            {
                // �_���폜
                status = this._iCampaignLinkDB.LogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraList = (ArrayList)obj;
                    campaignLinkList.Clear();

                    foreach (CampaignLinkWork wkCampaignLinkWork in paraList)
                    {
                        CampaignLink campaignLink = new CampaignLink();
                        // ���[�N��UI�f�[�^�N���X
                        campaignLink = this.CopyToCampaignLinkFromCampaignLinkWork((CampaignLinkWork)wkCampaignLinkWork);
                        campaignLinkList.Add(campaignLink);
                    }
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iCampaignLinkDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// �����폜����
        /// </summary>
        /// <param name="campaignLinkList">UI�f�[�^�N���X���X�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���֘A�̕����폜���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int Delete(ArrayList campaignLinkList)
        {
            int status = 0;
            ArrayList paraList = new ArrayList();
            CampaignLinkWork campaignLinkWork = new CampaignLinkWork();

            foreach (CampaignLink campaignLink in campaignLinkList)
            {
                // UI�f�[�^�N���X�����[�N
                campaignLinkWork = CopyToCampaignLinkWorkFromCampaignLink(campaignLink);

                // �����폜����ݒ�
                paraList.Add(campaignLinkWork);
            }

            object obj = paraList;

            try
            {
                // ArrayList����z��𐶐�
                CampaignLinkWork[] campaignMngWorks = (CampaignLinkWork[])paraList.ToArray(typeof(CampaignLinkWork));

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(campaignMngWorks);

                // �����폜
                status = this._iCampaignLinkDB.Delete(parabyte);

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iCampaignLinkDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }
        #endregion

        #region -- �������� --
        /// <summary>
        /// �L�����y�[���֘A��������
        /// </summary>
        /// <param name="campaignLinkList">UI�f�[�^�N���X���X�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���֘A�̕������s���܂�</br>
        /// <br></br>
        /// </remarks>
        public int Revival(ref ArrayList campaignLinkList)
        {
            int status = 0;
            ArrayList paraList = new ArrayList();
            CampaignLinkWork campaignLinkWork = new CampaignLinkWork();

            foreach (CampaignLink campaignLink in campaignLinkList)
            {
                // UI�f�[�^�N���X�����[�N
                campaignLinkWork = CopyToCampaignLinkWorkFromCampaignLink(campaignLink);

                // �_���폜����ݒ�
                paraList.Add(campaignLinkWork);
            }

            object obj = paraList;

            try
            {
                // ��������
                status = this._iCampaignLinkDB.RevivalLogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraList = (ArrayList)obj;
                    campaignLinkList.Clear();

                    foreach (CampaignLinkWork wkCampaignLinkWork in paraList)
                    {
                        CampaignLink campaignLink = new CampaignLink();
                        // ���[�N��UI�f�[�^�N���X
                        campaignLink = this.CopyToCampaignLinkFromCampaignLinkWork((CampaignLinkWork)wkCampaignLinkWork);
                        campaignLinkList.Add(campaignLink);
                    }
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iCampaignLinkDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }
        #endregion

        #region -- �������� --
        /// <summary>
        /// �L�����y�[���֘A���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���֘A�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br></br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, 0);
        }

        /// <summary>
        /// �L�����y�[���֘A���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <param name="campaignCode">�L�����y�[���R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���֘A�̌����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br></br>
        /// </remarks>
        public int SearchDetail(out ArrayList retList, string enterpriseCode, int campaignCode)
        {
            return SearchProc(out retList, enterpriseCode, campaignCode);
        }

        /// <summary>
        /// �L�����y�[���֘A��������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="campaignCode">�L�����y�[���R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���֘A�̌����������s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode, int campaignCode)
        {
            int status = 0;

            CampaignLinkWork campaignLinkWork = new CampaignLinkWork();
            campaignLinkWork.EnterpriseCode = enterpriseCode;
            campaignLinkWork.CampaignCode = campaignCode;

            retList = new ArrayList();

            object paraobj = campaignLinkWork;
            object retobj = null;

            // �L�����y�[���֘A�̑S����
            status = this._iCampaignLinkDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData01);
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                ArrayList workList = retobj as ArrayList;

                foreach (CampaignLinkWork wkCampaignLinkWork in workList)
                {
                    retList.Add(CopyToCampaignLinkFromCampaignLinkWork(wkCampaignLinkWork));
                }
            }

            return status;
        }

        /// <summary>
        /// �}�X�^���������iDataSet�p�j
        /// </summary>
        /// <param name="ds">�擾���ʊi�[�pDataSet</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �擾���ʂ�DataSet�ŕԂ��܂��B</br>
        /// <br></br>
        /// </remarks>
        public int Search(ref DataSet ds, string enterpriseCode)
        {
            ArrayList retList = new ArrayList();

            int status = 0;

            // �}�X�^�T�[�`
            status = SearchAll(out retList, enterpriseCode);
            if (status != 0)
            {
                return status;
            }

            ArrayList workList = retList.Clone() as ArrayList;
            SortedList workSort = new SortedList();

            // --- [�S��] --- //
            // ���̂܂ܑS���Ԃ�
            foreach (CampaignLink wkCampaignLink in workList)
            {
                if (wkCampaignLink.LogicalDeleteCode == 0)
                {
                    workSort.Add(wkCampaignLink.CampaignCode, wkCampaignLink);
                }
            }

            CampaignLink[] campaignLink = new CampaignLink[workSort.Count];

            // �f�[�^�����ɖ߂�
            for (int i = 0; i < workSort.Count; i++)
            {
                campaignLink[i] = (CampaignLink)workSort.GetByIndex(i);
            }

            byte[] retbyte = XmlByteSerializer.Serialize(campaignLink);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }
        #endregion

        #region -- �N���X�����o�[�R�s�[���� --
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���[�N�N���X��UI�f�[�^�N���X�j
        /// </summary>
        /// <param name="campaignLinkWork">���[�N�N���X</param>
        /// <returns>UI�f�[�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���[�N�N���X����UI�f�[�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private CampaignLink CopyToCampaignLinkFromCampaignLinkWork(CampaignLinkWork campaignLinkWork)
        {
            CampaignLink campaignLink = new CampaignLink();

            campaignLink.CreateDateTime = campaignLinkWork.CreateDateTime;
            campaignLink.UpdateDateTime = campaignLinkWork.UpdateDateTime;
            campaignLink.EnterpriseCode = campaignLinkWork.EnterpriseCode;
            campaignLink.FileHeaderGuid = campaignLinkWork.FileHeaderGuid;
            campaignLink.UpdEmployeeCode = campaignLinkWork.UpdEmployeeCode;
            campaignLink.UpdAssemblyId1 = campaignLinkWork.UpdAssemblyId1;
            campaignLink.UpdAssemblyId2 = campaignLinkWork.UpdAssemblyId2;
            campaignLink.LogicalDeleteCode = campaignLinkWork.LogicalDeleteCode;

            campaignLink.CampaignCode = campaignLinkWork.CampaignCode;                  // �L�����y�[���R�[�h
            campaignLink.CustomerCode = campaignLinkWork.CustomerCode;                  // ���Ӑ�R�[�h
            campaignLink.SalesAreaCode = campaignLinkWork.SalesAreaCode;                // �̔��G���A�R�[�h
            campaignLink.CustomerAgentCd = campaignLinkWork.CustomerAgentCd;            // �ڋq�S���]�ƈ�
            campaignLink.InfoSendCode = campaignLinkWork.InfoSendCode;                  // ��񑗐M�敪
            
            return campaignLink;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����iUI�f�[�^�N���X�˃��[�N�N���X�j
        /// </summary>
        /// <param name="campaignLink">UI�f�[�^�N���X</param>
        /// <returns>���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : UI�f�[�^�N���X���烏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private CampaignLinkWork CopyToCampaignLinkWorkFromCampaignLink(CampaignLink campaignLink)
        {
            CampaignLinkWork campaignLinkWork = new CampaignLinkWork();

            campaignLinkWork.CreateDateTime = campaignLink.CreateDateTime;
            campaignLinkWork.UpdateDateTime = campaignLink.UpdateDateTime;
            campaignLinkWork.EnterpriseCode = campaignLink.EnterpriseCode;
            campaignLinkWork.FileHeaderGuid = campaignLink.FileHeaderGuid;
            campaignLinkWork.UpdEmployeeCode = campaignLink.UpdEmployeeCode;
            campaignLinkWork.UpdAssemblyId1 = campaignLink.UpdAssemblyId1;
            campaignLinkWork.UpdAssemblyId2 = campaignLink.UpdAssemblyId2;
            campaignLinkWork.LogicalDeleteCode = campaignLink.LogicalDeleteCode;

            campaignLinkWork.CampaignCode = campaignLink.CampaignCode;                  // �L�����y�[���R�[�h
            campaignLinkWork.CustomerCode = campaignLink.CustomerCode;                  // ���Ӑ�R�[�h
            campaignLinkWork.SalesAreaCode = campaignLink.SalesAreaCode;                // �̔��G���A�R�[�h
            campaignLinkWork.CustomerAgentCd = campaignLink.CustomerAgentCd;            // �ڋq�S���]�ƈ�
            campaignLinkWork.InfoSendCode = campaignLink.InfoSendCode;                  // ��񑗐M�敪

            return campaignLinkWork;
        }
        #endregion

        #region -- �L�����y�[�����̎擾 --
        /// <summary>
        /// �L�����y�[�����̎擾
        /// </summary>
        /// <param name="campaignCode">�L�����y�[���R�[�h</param>
        /// <returns>�L�����y�[������</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[�����̂̎擾���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public string GetCampaignName(int campaignCode)
        {
            string name = string.Empty;

            if (_campaignStDic == null)
            {
                // �L�����y�[���ݒ胊�X�g�擾
                GetCampaignStList();
            }

            CampaignSt campaignSt;
            if (_campaignStDic.ContainsKey(campaignCode))
            {
                // �f�B�N�V���i���[�ɑ���
                campaignSt = _campaignStDic[campaignCode];
                name = campaignSt.CampaignName;
            }
            else
            {
                // �f�B�N�V���i���[�ɑ��݂��Ȃ��̂ŁA�}�X�^����Ǎ�
                campaignSt = ReadCampaignSt(campaignCode);
                name = campaignSt.CampaignName;
            }

            return name;
        }

        /// <summary>
        /// �ŐV���擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ŐV���̎擾���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public void Renewal()
        {
            // �L�����y�[���ݒ胊�X�g�擾
            GetCampaignStList();
        }

        /// <summary>
        /// �L�����y�[���ݒ胊�X�g�擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ݒ�}�X�^�̎擾���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void GetCampaignStList()
        {
            if (_campaignStAcs == null)
            {
                _campaignStAcs = new CampaignStAcs();
            }

            _campaignStDic = new Dictionary<int, CampaignSt>();
            ArrayList retList;

            // �S����
            int status = _campaignStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
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
        /// <br></br>
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
                ;
            }
            else
            {
                campaignSt = new CampaignSt();
            }

            return campaignSt;
        }
        #endregion
    }
}
