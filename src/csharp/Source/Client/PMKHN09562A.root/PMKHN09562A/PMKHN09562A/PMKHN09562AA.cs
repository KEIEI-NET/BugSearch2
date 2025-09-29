//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[���ݒ�ݒ�}�X�^
// �v���O�����T�v   : �L�����y�[���ݒ�ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/05/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Windows.Forms;
using System.Collections.Generic;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// �L�����y�[���ݒ�ݒ�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �L�����y�[���ݒ�ݒ�̃A�N�Z�X������s���܂��B</br>
    /// <br></br>
    /// </remarks>
    public class CampaignStAcs : IGeneralGuideData
	{
		#region -- �����[�g�I�u�W�F�N�g�i�[�o�b�t�@ --
		/// <summary>
		/// �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br></br>
		/// </remarks>
		private ICampaignStDB _iCampaignStDB = null;
		
		#endregion

		#region -- �R���X�g���N�^ --
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �V�����C���X�^���X�����������܂��B</br>
		/// <br></br>
		/// </remarks>
		static CampaignStAcs()
		{			
		}

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �V�����C���X�^���X�����������܂��B</br>
        /// <br></br>
        /// </remarks>
		public CampaignStAcs()
		{
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iCampaignStDB = (ICampaignStDB)MediationCampaignStDB.GetCampaignStDB();
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iCampaignStDB = null;
            }
		}
		#endregion

        #region -- �I�����C�����[�h�擾���� --
        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h�̎擾���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iCampaignStDB == null)
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
        /// <param name="campaignSt">UI�f�[�^�N���X</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param> 
        /// <param name="campaignCode">�L�����y�[���R�[�h</param>  
		/// <remarks>
		/// <br>Note       : </br>
		/// <br></br>
		/// </remarks>
        public int Read(out CampaignSt campaignSt, string enterpriseCode, int campaignCode)
        {
            return ReadProc(out campaignSt, enterpriseCode, campaignCode);
        }

        /// <summary>
        /// �ǂݍ��ݏ���
        /// </summary>
        /// <param name="campaignSt">UI�f�[�^�N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param> 
        /// <param name="campaignCode">�L�����y�[���R�[�h</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private int ReadProc(out CampaignSt campaignSt, string enterpriseCode, int campaignCode)
		{
            int status = 0;

            campaignSt = null;

			try
			{
                CampaignStWork campaignStWork = new CampaignStWork();
                campaignStWork.EnterpriseCode = enterpriseCode;
                campaignStWork.CampaignCode = campaignCode;

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(campaignStWork);

                status = this._iCampaignStDB.Read(ref parabyte, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XML�̓ǂݍ���
                    campaignStWork = (CampaignStWork)XmlByteSerializer.Deserialize(parabyte, typeof(CampaignStWork));
                    // ���[�N��UI�f�[�^�N���X
                    campaignSt = CopyToCampaignStFromCampaignStWork(campaignStWork);
                }

				return status;
			}
			catch (Exception)
			{				
				campaignSt = null;
				// �I�t���C������null���Z�b�g
				this._iCampaignStDB = null;
				// �ʐM�G���[��-1��߂�
				return -1;
			}
		}
		#endregion

		#region -- �o�^��X�V���� --
		/// <summary>
		/// �o�^�E�X�V����
		/// </summary>
        /// <param name="campaignSt">UI�f�[�^�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �o�^�E�X�V�������s���܂��B</br>
		/// <br></br>
		/// </remarks>
        public int Write(ref CampaignSt campaignSt)
		{
            int status = 0;

			// UI�f�[�^�N���X�����[�N
            CampaignStWork campaignStWork = CopyToCampaignStWorkFromCampaignSt(campaignSt);

            object obj = campaignStWork;
			
			try
			{
				// �������ݏ���
                status = this._iCampaignStDB.Write(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    if (obj is ArrayList)
                    {
                        campaignStWork = (CampaignStWork)((ArrayList)obj)[0];
                        // ���[�N��UI�f�[�^�N���X
                        campaignSt = CopyToCampaignStFromCampaignStWork(campaignStWork);
                    }
                }
			}
			catch (Exception)
			{
				// �I�t���C������null���Z�b�g
				this._iCampaignStDB = null;
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
        /// <param name="campaignSt">UI�f�[�^�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �L�����y�[���ݒ�ݒ�̘_���폜���s���܂��B</br>
		/// <br></br>
		/// </remarks>
        public int LogicalDelete(ref CampaignSt campaignSt)
		{
            int status = 0;

            // UI�f�[�^�N���X�����[�N
            CampaignStWork campaignStWork = CopyToCampaignStWorkFromCampaignSt(campaignSt);

            object obj = campaignStWork;

            try
            {
                // �_���폜
                status = this._iCampaignStDB.LogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    campaignStWork = (CampaignStWork)obj;
                    // ���[�N��UI�f�[�^�N���X
                    campaignSt = CopyToCampaignStFromCampaignStWork(campaignStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iCampaignStDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
		}

		/// <summary>
		/// �����폜����
		/// </summary>
        /// <param name="campaignSt">UI�f�[�^�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �L�����y�[���ݒ�ݒ�̕����폜���s���܂��B</br>
		/// <br></br>
		/// </remarks>
        public int Delete(CampaignSt campaignSt)
		{
            int status = 0;

            try
            {
                // UI�f�[�^�N���X�����[�N
                CampaignStWork campaignStWork = CopyToCampaignStWorkFromCampaignSt(campaignSt);

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(campaignStWork);

                // �����폜
                status = this._iCampaignStDB.Delete(parabyte);
                
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iCampaignStDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
		}
		#endregion

        #region -- �������� --
        /// <summary>
        /// �L�����y�[���ݒ�ݒ蕜������
        /// </summary>
        /// <param name="campaignSt">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ݒ�ݒ�̕������s���܂�</br>
        /// <br></br>
        /// </remarks>
        public int Revival(ref CampaignSt campaignSt)
        {
            int status = 0;

            try
            {
                // UI�f�[�^�N���X�����[�N
                CampaignStWork campaignStWork = CopyToCampaignStWorkFromCampaignSt(campaignSt);

                object obj = campaignStWork;

                // ��������
                status = this._iCampaignStDB.RevivalLogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    campaignStWork = (CampaignStWork)obj;
                    // ���[�N��UI�f�[�^�N���X
                    campaignSt = CopyToCampaignStFromCampaignStWork(campaignStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iCampaignStDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }
        #endregion

        #region -- �������� --
        /// <summary>
        /// �L�����y�[���ݒ�ݒ茟�������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ݒ�ݒ�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br></br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, string.Empty, false);
        }

        /// <summary>
        /// �L�����y�[���ݒ�ݒ茟������
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="searchingAllSectionIfEmpty">�������ʂ�0���̏ꍇ�A���_��S�ЂōČ�������t���O</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �L�����y�[���ݒ�ݒ�̌����������s���܂��B</br>
		/// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode, string sectionCode, bool searchingAllSectionIfEmpty)
		{
            int status = 0;

            CampaignStWork campaignStWork = new CampaignStWork();
            campaignStWork.EnterpriseCode = enterpriseCode;
            campaignStWork.SectionCode = sectionCode;

			retList = new ArrayList();
			
            object paraobj = campaignStWork;
			object retobj = null;

            // �L�����y�[���ݒ�ݒ�̑S����
            status = this._iCampaignStDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData01);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                ArrayList workList = retobj as ArrayList;

                foreach (CampaignStWork wkCampaignStWork in workList)
                {
                    if (string.IsNullOrEmpty(sectionCode.Trim()))
                    {
                        // ���_�R�[�h�̎w�肪�����ꍇ�A�S���ǉ�
                        retList.Add(CopyToCampaignStFromCampaignStWork(wkCampaignStWork));
                    }
                    else if (wkCampaignStWork.SectionCode.Trim().Equals(sectionCode.Trim()))
                    {
                        // ���_�R�[�h�̎w�肪����ꍇ�A���_�R�[�h����v������̂�ǉ�
                        retList.Add(CopyToCampaignStFromCampaignStWork(wkCampaignStWork));
                    }
                }
            }

            #region �������ʂ�0���̏ꍇ�A���_��S�ЂōČ���

            if (retList == null || retList.Count.Equals(0))
            {
                if (searchingAllSectionIfEmpty)
                {
                    return SearchProc(out retList, enterpriseCode, "00", false);
                }
            }

            #endregion

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
            return Search(ref ds, enterpriseCode, string.Empty, false);
        }

        /// <summary>
        /// �}�X�^���������iDataSet�p�j
        /// </summary>
        /// <param name="ds">�擾���ʊi�[�pDataSet</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="searchingAllSectionIfEmpty">�������ʂ�0���̏ꍇ�A���_��S�ЂōČ�������t���O</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �擾���ʂ�DataSet�ŕԂ��܂��B</br>
        /// <br></br>
        /// </remarks>
        public int Search(ref DataSet ds, string enterpriseCode, string sectionCode, bool searchingAllSectionIfEmpty)
        {
            ArrayList retList = new ArrayList();

            int status = 0;
            
            // �}�X�^�T�[�`
            //status = SearchAll(out retList, enterpriseCode);
            status = SearchProc(out retList, enterpriseCode, sectionCode, searchingAllSectionIfEmpty);
            if (status != 0)
            {
                return status;
            }

            ArrayList workList = retList.Clone() as ArrayList;
            SortedList workSort = new SortedList();

            // --- [�S��] --- //
            // ���̂܂ܑS���Ԃ�
            foreach (CampaignSt wkCampaignSt in workList)
            {
                if (wkCampaignSt.LogicalDeleteCode == 0)
                {
                    workSort.Add(wkCampaignSt.CampaignCode, wkCampaignSt);
                }
            }

            CampaignSt[] campaignSt = new CampaignSt[workSort.Count];

            // �f�[�^�����ɖ߂�
            for (int i = 0; i < workSort.Count; i++)
            {
                campaignSt[i] = (CampaignSt)workSort.GetByIndex(i);
            }

            byte[] retbyte = XmlByteSerializer.Serialize(campaignSt);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }
		#endregion

        #region -- �N���X�����o�[�R�s�[���� --
        /// <summary>
		/// �N���X�����o�[�R�s�[�����i���[�N�N���X��UI�f�[�^�N���X�j
		/// </summary>
        /// <param name="campaignStWork">���[�N�N���X</param>
        /// <returns>UI�f�[�^�N���X</returns>
		/// <remarks>
        /// <br>Note       : ���[�N�N���X����UI�f�[�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br></br>
		/// </remarks>
        private CampaignSt CopyToCampaignStFromCampaignStWork(CampaignStWork campaignStWork)
		{
            CampaignSt campaignSt = new CampaignSt();

            campaignSt.CreateDateTime = campaignStWork.CreateDateTime;
            campaignSt.UpdateDateTime = campaignStWork.UpdateDateTime;
            campaignSt.EnterpriseCode = campaignStWork.EnterpriseCode;
            campaignSt.FileHeaderGuid = campaignStWork.FileHeaderGuid;
            campaignSt.UpdEmployeeCode = campaignStWork.UpdEmployeeCode;
            campaignSt.UpdAssemblyId1 = campaignStWork.UpdAssemblyId1;
            campaignSt.UpdAssemblyId2 = campaignStWork.UpdAssemblyId2;
            campaignSt.LogicalDeleteCode = campaignStWork.LogicalDeleteCode;
            
            campaignSt.CampaignCode = campaignStWork.CampaignCode;                  // �L�����y�[���R�[�h
            campaignSt.CampaignName = campaignStWork.CampaignName;                  // �L�����y�[������
            campaignSt.SectionCode = campaignStWork.SectionCode;                    // ���_�R�[�h
            campaignSt.CampaignObjDiv = campaignStWork.CampaignObjDiv;              // �L�����y�[���Ώۋ敪
            campaignSt.ApplyStaDate = campaignStWork.ApplyStaDate;                  // �K�p�J�n��
            campaignSt.ApplyEndDate = campaignStWork.ApplyEndDate;                  // �K�p�I����
            campaignSt.SalesTargetMoney = campaignStWork.SalesTargetMoney;          // ����ڕW���z
            campaignSt.SalesTargetProfit = campaignStWork.SalesTargetProfit;        // ����ڕW�e���z
            campaignSt.SalesTargetCount = campaignStWork.SalesTargetCount;          // ����ڕW����
			
            return campaignSt;
		}
		
		/// <summary>
        /// �N���X�����o�[�R�s�[�����iUI�f�[�^�N���X�˃��[�N�N���X�j
		/// </summary>
        /// <param name="campaignSt">UI�f�[�^�N���X</param>
        /// <returns>���[�N�N���X</returns>
		/// <remarks>
        /// <br>Note       : UI�f�[�^�N���X���烏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br></br>
		/// </remarks>
        private CampaignStWork CopyToCampaignStWorkFromCampaignSt(CampaignSt campaignSt)
		{
            CampaignStWork campaignStWork = new CampaignStWork();

            campaignStWork.CreateDateTime = campaignSt.CreateDateTime;
            campaignStWork.UpdateDateTime = campaignSt.UpdateDateTime;
            campaignStWork.EnterpriseCode = campaignSt.EnterpriseCode;
            campaignStWork.FileHeaderGuid = campaignSt.FileHeaderGuid;
            campaignStWork.UpdEmployeeCode = campaignSt.UpdEmployeeCode;
            campaignStWork.UpdAssemblyId1 = campaignSt.UpdAssemblyId1;
            campaignStWork.UpdAssemblyId2 = campaignSt.UpdAssemblyId2;
            campaignStWork.LogicalDeleteCode = campaignSt.LogicalDeleteCode;
            
            campaignStWork.CampaignCode = campaignSt.CampaignCode;                  // �L�����y�[���R�[�h
            campaignStWork.CampaignName = campaignSt.CampaignName;                  // �L�����y�[������
            campaignStWork.SectionCode = campaignSt.SectionCode;                    // ���_�R�[�h
            campaignStWork.CampaignObjDiv = campaignSt.CampaignObjDiv;              // �L�����y�[���Ώۋ敪
            campaignStWork.ApplyStaDate = campaignSt.ApplyStaDate;                  // �K�p�J�n��
            campaignStWork.ApplyEndDate = campaignSt.ApplyEndDate;                  // �K�p�I����
            campaignStWork.SalesTargetMoney = campaignSt.SalesTargetMoney;          // ����ڕW���z
            campaignStWork.SalesTargetProfit = campaignSt.SalesTargetProfit;        // ����ڕW�e���z
            campaignStWork.SalesTargetCount = campaignSt.SalesTargetCount;          // ����ڕW����
            
            return campaignStWork;
		}
		#endregion

        #region -- �N���X�����o�[�R�s�[���� --
        /// <summary>
        /// �ėp�K�C�h�f�[�^�擾(IGeneralGuidData�C���^�[�t�F�[�X����)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��,4:���R�[�h����]</returns>
        /// <remarks>
        /// <br>Note		: �ėp�K�C�h�ݒ�p�f�[�^���擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = -1;
            string enterpriseCode   = "";
            string sectionCode      = "";

            // ��ƃR�[�h�ݒ�L��
            if (inParm.ContainsKey("EnterpriseCode"))
            {
                enterpriseCode = inParm["EnterpriseCode"].ToString();
            }
            // ��ƃR�[�h�ݒ薳��
            else
            {
                // �L�蓾�Ȃ��̂ŃG���[
                return status;
            }

            // ���_�R�[�h�ݒ�L��
            if (inParm.ContainsKey("SectionCode"))
            {
                sectionCode = inParm["SectionCode"].ToString();
            }

            // �L�����y�[���ݒ�}�X�^�̓Ǎ�
            status = Search(ref guideList, enterpriseCode, sectionCode, true);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = 4;
                        break;
                    }
                default:
                    status = -1;
                    break;
            }

            return status;
        }

        /// <summary>
        /// �L�����y�[���ݒ�}�X�^�K�C�h�N������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="campaignSt">�擾�f�[�^</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note		: �L�����y�[���ݒ�}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br></br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, out CampaignSt campaignSt)
        {
            return ExecuteGuid(enterpriseCode, string.Empty, out campaignSt);
        }

        /// <summary>
        /// �L�����y�[���ݒ�}�X�^�K�C�h�N������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="campaignSt">�擾�f�[�^</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note		: �L�����y�[���ݒ�}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br></br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, string sectionCode, out CampaignSt campaignSt)
        {
            int status = -1;
            campaignSt = new CampaignSt();
            
            TableGuideParent tableGuideParent = new TableGuideParent("CAMPAIGNSTGUIDEPARENT.XML");
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // ��ƃR�[�h
            inObj.Add("EnterpriseCode", enterpriseCode);
            // ���_�R�[�h
            inObj.Add("SectionCode", sectionCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                string strCode = retObj["CampaignCode"].ToString();
                campaignSt.CampaignCode = int.Parse(strCode);
                campaignSt.CampaignName = retObj["CampaignName"].ToString();
                strCode = retObj["CampaignObjDiv"].ToString();
                campaignSt.CampaignObjDiv = int.Parse(strCode);
                strCode = retObj["ApplyStaDate"].ToString();
                campaignSt.ApplyStaDate = DateTime.Parse(strCode);
                strCode = retObj["ApplyEndDate"].ToString();
                campaignSt.ApplyEndDate = DateTime.Parse(strCode);
                strCode = retObj["SalesTargetMoney"].ToString();
                campaignSt.SalesTargetMoney = long.Parse(strCode);
                strCode = retObj["SalesTargetProfit"].ToString();
                campaignSt.SalesTargetProfit = long.Parse(strCode);
                strCode = retObj["SalesTargetCount"].ToString();
                campaignSt.SalesTargetCount = long.Parse(strCode);
                status = 0;
            }
            // �L�����Z��
            else
            {
                status = 1;
            }

            return status;
        }
        #endregion
    }
}
