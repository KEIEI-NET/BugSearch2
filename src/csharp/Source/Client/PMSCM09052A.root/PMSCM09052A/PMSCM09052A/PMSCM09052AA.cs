//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : SCM���ꉿ�i�ݒ�}�X�^
// �v���O�����T�v   : SCM���ꉿ�i�ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10601193-00  �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2010/04/12  �C�����e : ���ꉿ�i�i���R�[�h�Q�A���ꉿ�i�i���R�[�h�R�̒ǉ�
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
using System.Collections.Generic;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// SCM���ꉿ�i�ݒ�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : SCM���ꉿ�i�ݒ�̃A�N�Z�X������s���܂��B</br>
    /// <br></br>
    /// </remarks>
	public class SCMMrktPriStAcs
	{
		#region -- �����[�g�I�u�W�F�N�g�i�[�o�b�t�@ --
		/// <summary>
		/// �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br></br>
		/// </remarks>
		private ISCMMrktPriStDB _iSCMMrktPriStDB = null;
		
		#endregion

		#region -- �R���X�g���N�^ --
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �V�����C���X�^���X�����������܂��B</br>
		/// <br></br>
		/// </remarks>
		static SCMMrktPriStAcs()
		{			
		}

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �V�����C���X�^���X�����������܂��B</br>
        /// <br></br>
        /// </remarks>
		public SCMMrktPriStAcs()
		{
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iSCMMrktPriStDB = (ISCMMrktPriStDB)MediationSCMMrktPriStDB.GetSCMMrktPriStDB();
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iSCMMrktPriStDB = null;
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
            if (this._iSCMMrktPriStDB == null)
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
        /// <param name="scmMrktPriSt">UI�f�[�^�N���X</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param> 
		/// <param name="sectionCode">���_�R�[�h</param>  
		/// <remarks>
		/// <br>Note       : </br>
		/// <br></br>
		/// </remarks>
        public int Read(out SCMMrktPriSt scmMrktPriSt, string enterpriseCode, string sectionCode)
        {
            return ReadProc(out scmMrktPriSt, enterpriseCode, sectionCode);
        }

        /// <summary>
        /// �ǂݍ��ݏ���
        /// </summary>
        /// <param name="scmMrktPriSt">UI�f�[�^�N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param> 
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private int ReadProc(out SCMMrktPriSt scmMrktPriSt, string enterpriseCode, string sectionCode)
		{
            int status = 0;

            scmMrktPriSt = null;

			try
			{
                SCMMrktPriStWork scmMrktPriStWork = new SCMMrktPriStWork();
                scmMrktPriStWork.EnterpriseCode = enterpriseCode;
                scmMrktPriStWork.SectionCode = sectionCode;

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(scmMrktPriStWork);

                status = this._iSCMMrktPriStDB.Read(ref parabyte, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XML�̓ǂݍ���
                    scmMrktPriStWork = (SCMMrktPriStWork)XmlByteSerializer.Deserialize(parabyte, typeof(SCMMrktPriStWork));
                    // ���[�N��UI�f�[�^�N���X
                    scmMrktPriSt = CopyToSCMMrktPriStFromSCMMrktPriStWork(scmMrktPriStWork);
                }

				return status;
			}
			catch (Exception)
			{				
				scmMrktPriSt = null;
				// �I�t���C������null���Z�b�g
				this._iSCMMrktPriStDB = null;
				// �ʐM�G���[��-1��߂�
				return -1;
			}
		}
		#endregion

		#region -- �o�^��X�V���� --
		/// <summary>
		/// �o�^�E�X�V����
		/// </summary>
        /// <param name="scmMrktPriSt">UI�f�[�^�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �o�^�E�X�V�������s���܂��B</br>
		/// <br></br>
		/// </remarks>
        public int Write(ref SCMMrktPriSt scmMrktPriSt)
		{
            int status = 0;

			// UI�f�[�^�N���X�����[�N
            SCMMrktPriStWork scmMrktPriStWork = CopyToSCMMrktPriStWorkFromSCMMrktPriSt(scmMrktPriSt);

            object obj = scmMrktPriStWork;
			
			try
			{
				// �������ݏ���
                status = this._iSCMMrktPriStDB.Write(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    if (obj is ArrayList)
                    {
                        scmMrktPriStWork = (SCMMrktPriStWork)((ArrayList)obj)[0];
                        // ���[�N��UI�f�[�^�N���X
                        scmMrktPriSt = CopyToSCMMrktPriStFromSCMMrktPriStWork(scmMrktPriStWork);
                    }
                }
			}
			catch (Exception)
			{
				// �I�t���C������null���Z�b�g
				this._iSCMMrktPriStDB = null;
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
        /// <param name="scmMrktPriSt">UI�f�[�^�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : SCM���ꉿ�i�ݒ�̘_���폜���s���܂��B</br>
		/// <br></br>
		/// </remarks>
        public int LogicalDelete(ref SCMMrktPriSt scmMrktPriSt)
		{
            int status = 0;

            // UI�f�[�^�N���X�����[�N
            SCMMrktPriStWork scmMrktPriStWork = CopyToSCMMrktPriStWorkFromSCMMrktPriSt(scmMrktPriSt);

            object obj = scmMrktPriStWork;

            try
            {
                // �_���폜
                status = this._iSCMMrktPriStDB.LogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    scmMrktPriStWork = (SCMMrktPriStWork)obj;
                    // ���[�N��UI�f�[�^�N���X
                    scmMrktPriSt = CopyToSCMMrktPriStFromSCMMrktPriStWork(scmMrktPriStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iSCMMrktPriStDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
		}

		/// <summary>
		/// �����폜����
		/// </summary>
        /// <param name="scmMrktPriSt">UI�f�[�^�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : SCM���ꉿ�i�ݒ�̕����폜���s���܂��B</br>
		/// <br></br>
		/// </remarks>
        public int Delete(SCMMrktPriSt scmMrktPriSt)
		{
            int status = 0;

            try
            {
                // UI�f�[�^�N���X�����[�N
                SCMMrktPriStWork scmMrktPriStWork = CopyToSCMMrktPriStWorkFromSCMMrktPriSt(scmMrktPriSt);

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(scmMrktPriStWork);

                // �����폜
                status = this._iSCMMrktPriStDB.Delete(parabyte);
                
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iSCMMrktPriStDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
		}
		#endregion

        #region -- �������� --
        /// <summary>
        /// SCM���ꉿ�i�ݒ蕜������
        /// </summary>
        /// <param name="scmMrktPriSt">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM���ꉿ�i�ݒ�̕������s���܂�</br>
        /// <br></br>
        /// </remarks>
        public int Revival(ref SCMMrktPriSt scmMrktPriSt)
        {
            int status = 0;

            try
            {
                // UI�f�[�^�N���X�����[�N
                SCMMrktPriStWork scmMrktPriStWork = CopyToSCMMrktPriStWorkFromSCMMrktPriSt(scmMrktPriSt);

                object obj = scmMrktPriStWork;

                // ��������
                status = this._iSCMMrktPriStDB.RevivalLogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    scmMrktPriStWork = (SCMMrktPriStWork)obj;
                    // ���[�N��UI�f�[�^�N���X
                    scmMrktPriSt = CopyToSCMMrktPriStFromSCMMrktPriStWork(scmMrktPriStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iSCMMrktPriStDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }
        #endregion

        #region -- �������� --
        /// <summary>
        /// SCM���ꉿ�i�ݒ茟�������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : SCM���ꉿ�i�ݒ�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br></br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode);
        }

        /// <summary>
        /// SCM���ꉿ�i�ݒ茟������
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : SCM���ꉿ�i�ݒ�̌����������s���܂��B</br>
		/// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode)
		{
            int status = 0;

            SCMMrktPriStWork scmMrktPriStWork = new SCMMrktPriStWork();
            scmMrktPriStWork.EnterpriseCode = enterpriseCode;

			retList = new ArrayList();
			
            object paraobj = scmMrktPriStWork;
			object retobj = null;

            // SCM���ꉿ�i�ݒ�̑S����
            status = this._iSCMMrktPriStDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData01);
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                ArrayList workList = retobj as ArrayList;

                foreach (SCMMrktPriStWork wkSCMMrktPriStWork in workList)
                {
                    retList.Add(CopyToSCMMrktPriStFromSCMMrktPriStWork(wkSCMMrktPriStWork));
                }
            }
                
 			return status;
		}
		#endregion

        #region -- �N���X�����o�[�R�s�[���� --
        /// <summary>
		/// �N���X�����o�[�R�s�[�����i���[�N�N���X��UI�f�[�^�N���X�j
		/// </summary>
        /// <param name="scmMrktPriStWork">���[�N�N���X</param>
        /// <returns>UI�f�[�^�N���X</returns>
		/// <remarks>
        /// <br>Note       : ���[�N�N���X����UI�f�[�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br></br>
		/// </remarks>
        private SCMMrktPriSt CopyToSCMMrktPriStFromSCMMrktPriStWork(SCMMrktPriStWork scmMrktPriStWork)
		{
            SCMMrktPriSt scmMrktPriSt = new SCMMrktPriSt();

            scmMrktPriSt.CreateDateTime = scmMrktPriStWork.CreateDateTime;
            scmMrktPriSt.UpdateDateTime = scmMrktPriStWork.UpdateDateTime;
            scmMrktPriSt.EnterpriseCode = scmMrktPriStWork.EnterpriseCode;
            scmMrktPriSt.FileHeaderGuid = scmMrktPriStWork.FileHeaderGuid;
            scmMrktPriSt.UpdEmployeeCode = scmMrktPriStWork.UpdEmployeeCode;
            scmMrktPriSt.UpdAssemblyId1 = scmMrktPriStWork.UpdAssemblyId1;
            scmMrktPriSt.UpdAssemblyId2 = scmMrktPriStWork.UpdAssemblyId2;
            scmMrktPriSt.LogicalDeleteCode = scmMrktPriStWork.LogicalDeleteCode;
            scmMrktPriSt.SectionCode = scmMrktPriStWork.SectionCode;

            scmMrktPriSt.MarketPriceAreaCd = scmMrktPriStWork.MarketPriceAreaCd;            // ���ꉿ�i�n��R�[�h
            scmMrktPriSt.MarketPriceQualityCd = scmMrktPriStWork.MarketPriceQualityCd;      // ���ꉿ�i�i���R�[�h
            scmMrktPriSt.MarketPriceKindCd1 = scmMrktPriStWork.MarketPriceKindCd1;          // ���ꉿ�i��ʃR�[�h�P
            scmMrktPriSt.MarketPriceKindCd2 = scmMrktPriStWork.MarketPriceKindCd2;          // ���ꉿ�i��ʃR�[�h�Q
            scmMrktPriSt.MarketPriceKindCd3 = scmMrktPriStWork.MarketPriceKindCd3;          // ���ꉿ�i��ʃR�[�h�R
            scmMrktPriSt.MarketPriceAnswerDiv = scmMrktPriStWork.MarketPriceAnswerDiv;      // ���ꉿ�i�񓚋敪
            scmMrktPriSt.MarketPriceSalesRate = scmMrktPriStWork.MarketPriceSalesRate;      // ���ꉿ�i������

            scmMrktPriSt.AddPaymntAmbit1 = scmMrktPriStWork.AddPaymntAmbit1;                // ���Z�z�͈͂P
            scmMrktPriSt.AddPaymntAmbit2 = scmMrktPriStWork.AddPaymntAmbit2;                // ���Z�z�͈͂Q
            scmMrktPriSt.AddPaymntAmbit3 = scmMrktPriStWork.AddPaymntAmbit3;                // ���Z�z�͈͂R
            scmMrktPriSt.AddPaymntAmbit4 = scmMrktPriStWork.AddPaymntAmbit4;                // ���Z�z�͈͂S
            scmMrktPriSt.AddPaymntAmbit5 = scmMrktPriStWork.AddPaymntAmbit5;                // ���Z�z�͈͂T
            scmMrktPriSt.AddPaymntAmbit6 = scmMrktPriStWork.AddPaymntAmbit6;                // ���Z�z�͈͂U
            scmMrktPriSt.AddPaymntAmbit7 = scmMrktPriStWork.AddPaymntAmbit7;                // ���Z�z�͈͂V
            scmMrktPriSt.AddPaymntAmbit8 = scmMrktPriStWork.AddPaymntAmbit8;                // ���Z�z�͈͂W
            scmMrktPriSt.AddPaymntAmbit9 = scmMrktPriStWork.AddPaymntAmbit9;                // ���Z�z�͈͂X
            scmMrktPriSt.AddPaymntAmbit10 = scmMrktPriStWork.AddPaymntAmbit10;              // ���Z�z�͈͂P�O

            scmMrktPriSt.AddPaymnt1 = scmMrktPriStWork.AddPaymnt1;                          // ���Z�z�P
            scmMrktPriSt.AddPaymnt2 = scmMrktPriStWork.AddPaymnt2;                          // ���Z�z�Q
            scmMrktPriSt.AddPaymnt3 = scmMrktPriStWork.AddPaymnt3;                          // ���Z�z�R
            scmMrktPriSt.AddPaymnt4 = scmMrktPriStWork.AddPaymnt4;                          // ���Z�z�S
            scmMrktPriSt.AddPaymnt5 = scmMrktPriStWork.AddPaymnt5;                          // ���Z�z�T
            scmMrktPriSt.AddPaymnt6 = scmMrktPriStWork.AddPaymnt6;                          // ���Z�z�U
            scmMrktPriSt.AddPaymnt7 = scmMrktPriStWork.AddPaymnt7;                          // ���Z�z�V
            scmMrktPriSt.AddPaymnt8 = scmMrktPriStWork.AddPaymnt8;                          // ���Z�z�W
            scmMrktPriSt.AddPaymnt9 = scmMrktPriStWork.AddPaymnt9;                          // ���Z�z�X
            scmMrktPriSt.AddPaymnt10 = scmMrktPriStWork.AddPaymnt10;                        // ���Z�z�P�O

            scmMrktPriSt.FractionProcCd = scmMrktPriStWork.FractionProcCd;                  // �[�������敪

            // 2010/04/12 Add >>>
            scmMrktPriSt.MarketPriceQualityCd2 = scmMrktPriStWork.MarketPriceQualityCd2;    // ���ꉿ�i�i���R�[�h�Q
            scmMrktPriSt.MarketPriceQualityCd3 = scmMrktPriStWork.MarketPriceQualityCd3;    // ���ꉿ�i�i���R�[�h�R
            // 2010/04/12 Add <<<

            return scmMrktPriSt;
		}
		
		/// <summary>
        /// �N���X�����o�[�R�s�[�����iUI�f�[�^�N���X�˃��[�N�N���X�j
		/// </summary>
        /// <param name="scmMrktPriSt">UI�f�[�^�N���X</param>
        /// <returns>���[�N�N���X</returns>
		/// <remarks>
        /// <br>Note       : UI�f�[�^�N���X���烏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br></br>
		/// </remarks>
        private SCMMrktPriStWork CopyToSCMMrktPriStWorkFromSCMMrktPriSt(SCMMrktPriSt scmMrktPriSt)
		{
            SCMMrktPriStWork scmMrktPriStWork = new SCMMrktPriStWork();

            scmMrktPriStWork.CreateDateTime = scmMrktPriSt.CreateDateTime;
            scmMrktPriStWork.UpdateDateTime = scmMrktPriSt.UpdateDateTime;
            scmMrktPriStWork.EnterpriseCode = scmMrktPriSt.EnterpriseCode;
            scmMrktPriStWork.FileHeaderGuid = scmMrktPriSt.FileHeaderGuid;
            scmMrktPriStWork.UpdEmployeeCode = scmMrktPriSt.UpdEmployeeCode;
            scmMrktPriStWork.UpdAssemblyId1 = scmMrktPriSt.UpdAssemblyId1;
            scmMrktPriStWork.UpdAssemblyId2 = scmMrktPriSt.UpdAssemblyId2;
            scmMrktPriStWork.LogicalDeleteCode = scmMrktPriSt.LogicalDeleteCode;
            scmMrktPriStWork.SectionCode = scmMrktPriSt.SectionCode;

            scmMrktPriStWork.MarketPriceAreaCd = scmMrktPriSt.MarketPriceAreaCd;            // ���ꉿ�i�n��R�[�h
            scmMrktPriStWork.MarketPriceQualityCd = scmMrktPriSt.MarketPriceQualityCd;      // ���ꉿ�i�i���R�[�h
            scmMrktPriStWork.MarketPriceKindCd1 = scmMrktPriSt.MarketPriceKindCd1;          // ���ꉿ�i��ʃR�[�h�P
            scmMrktPriStWork.MarketPriceKindCd2 = scmMrktPriSt.MarketPriceKindCd2;          // ���ꉿ�i��ʃR�[�h�Q
            scmMrktPriStWork.MarketPriceKindCd3 = scmMrktPriSt.MarketPriceKindCd3;          // ���ꉿ�i��ʃR�[�h�R
            scmMrktPriStWork.MarketPriceAnswerDiv = scmMrktPriSt.MarketPriceAnswerDiv;      // ���ꉿ�i�񓚋敪
            scmMrktPriStWork.MarketPriceSalesRate = scmMrktPriSt.MarketPriceSalesRate;      // ���ꉿ�i������

            scmMrktPriStWork.AddPaymntAmbit1 = scmMrktPriSt.AddPaymntAmbit1;                // ���Z�z�͈͂P
            scmMrktPriStWork.AddPaymntAmbit2 = scmMrktPriSt.AddPaymntAmbit2;                // ���Z�z�͈͂Q
            scmMrktPriStWork.AddPaymntAmbit3 = scmMrktPriSt.AddPaymntAmbit3;                // ���Z�z�͈͂R
            scmMrktPriStWork.AddPaymntAmbit4 = scmMrktPriSt.AddPaymntAmbit4;                // ���Z�z�͈͂S
            scmMrktPriStWork.AddPaymntAmbit5 = scmMrktPriSt.AddPaymntAmbit5;                // ���Z�z�͈͂T
            scmMrktPriStWork.AddPaymntAmbit6 = scmMrktPriSt.AddPaymntAmbit6;                // ���Z�z�͈͂U
            scmMrktPriStWork.AddPaymntAmbit7 = scmMrktPriSt.AddPaymntAmbit7;                // ���Z�z�͈͂V
            scmMrktPriStWork.AddPaymntAmbit8 = scmMrktPriSt.AddPaymntAmbit8;                // ���Z�z�͈͂W
            scmMrktPriStWork.AddPaymntAmbit9 = scmMrktPriSt.AddPaymntAmbit9;                // ���Z�z�͈͂X
            scmMrktPriStWork.AddPaymntAmbit10 = scmMrktPriSt.AddPaymntAmbit10;              // ���Z�z�͈͂P�O

            scmMrktPriStWork.AddPaymnt1 = scmMrktPriSt.AddPaymnt1;                          // ���Z�z�P
            scmMrktPriStWork.AddPaymnt2 = scmMrktPriSt.AddPaymnt2;                          // ���Z�z�Q
            scmMrktPriStWork.AddPaymnt3 = scmMrktPriSt.AddPaymnt3;                          // ���Z�z�R
            scmMrktPriStWork.AddPaymnt4 = scmMrktPriSt.AddPaymnt4;                          // ���Z�z�S
            scmMrktPriStWork.AddPaymnt5 = scmMrktPriSt.AddPaymnt5;                          // ���Z�z�T
            scmMrktPriStWork.AddPaymnt6 = scmMrktPriSt.AddPaymnt6;                          // ���Z�z�U
            scmMrktPriStWork.AddPaymnt7 = scmMrktPriSt.AddPaymnt7;                          // ���Z�z�V
            scmMrktPriStWork.AddPaymnt8 = scmMrktPriSt.AddPaymnt8;                          // ���Z�z�W
            scmMrktPriStWork.AddPaymnt9 = scmMrktPriSt.AddPaymnt9;                          // ���Z�z�X
            scmMrktPriStWork.AddPaymnt10 = scmMrktPriSt.AddPaymnt10;                        // ���Z�z�P�O

            scmMrktPriStWork.FractionProcCd = scmMrktPriSt.FractionProcCd;                  // �[�������敪

            // 2010/04/12 Add >>>
            scmMrktPriStWork.MarketPriceQualityCd2 = scmMrktPriSt.MarketPriceQualityCd2;    // ���ꉿ�i�i���R�[�h�Q
            scmMrktPriStWork.MarketPriceQualityCd3 = scmMrktPriSt.MarketPriceQualityCd3;    // ���ꉿ�i�i���R�[�h�R
            // 2010/04/12 Add <<<

            return scmMrktPriStWork;
		}
		#endregion
		
	}
}
