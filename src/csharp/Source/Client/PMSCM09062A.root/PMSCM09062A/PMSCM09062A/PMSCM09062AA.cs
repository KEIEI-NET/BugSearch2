//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : SCM�D��ݒ�}�X�^
// �v���O�����T�v   : SCM�D��ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
// Update Note      :	 �D��ݒ�}�X�^������                   		      //
//                  :    lingxiaoqing                                         //
//                  :    2011.08.08                                           //
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
    /// SCM�D��ݒ�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : SCM�D��ݒ�̃A�N�Z�X������s���܂��B</br>
    /// <br></br>
    /// </remarks>
	public class SCMPriorStAcs
	{
		#region -- �����[�g�I�u�W�F�N�g�i�[�o�b�t�@ --
		/// <summary>
		/// �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br></br>
		/// </remarks>
		private ISCMPriorStDB _iSCMPriorStDB = null;
		
		#endregion

		#region -- �R���X�g���N�^ --
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �V�����C���X�^���X�����������܂��B</br>
		/// <br></br>
		/// </remarks>
		static SCMPriorStAcs()
		{			
		}

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �V�����C���X�^���X�����������܂��B</br>
        /// <br></br>
        /// </remarks>
		public SCMPriorStAcs()
		{
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iSCMPriorStDB = (ISCMPriorStDB)MediationSCMPriorStDB.GetSCMPriorStDB();
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iSCMPriorStDB = null;
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
            if (this._iSCMPriorStDB == null)
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
        // ------------DELETE BY lingxiaoqing  2011.08.08------------->>>>>>>>>>>>>
        // /// <summary>
        ///// �ǂݍ��ݏ���
        ///// </summary>
        ///// <param name="scmPriorSt">UI�f�[�^�N���X</param>
        ///// <param name="enterpriseCode">��ƃR�[�h</param> 
        ///// <param name="sectionCode">���_�R�[�h</param> 
        ///// <remarks>
        ///// <br>Note       : </br>
        ///// <br></br>
        ///// </remarks>
        //public int Read(out SCMPriorSt scmPriorSt, string enterpriseCode, string sectionCode)
        //{
        //    return ReadProc(out scmPriorSt, enterpriseCode, sectionCode,customerCode,priorAppliDiv);
        //}
        // ------------DELETE BY lingxiaoqing  2011.08.08-------------<<<<<<<<<<<<<<

        // ------------ADD BY lingxiaoqing  2011.08.08------------->>>>>>>>>>>>>>>
        /// <summary>
        /// �ǂݍ��ݏ���
        /// </summary>
        /// <param name="scmPriorSt">UI�f�[�^�N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param> 
        /// <param name="sectionCode">���_�R�[�h</param>  
        /// <param name="customerCode">���Ӑ�R�[�h</param> 
        /// <param name="priorAppliDiv">�D��K�p�敪</param>  
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        public int Read(out SCMPriorSt scmPriorSt, string enterpriseCode, string sectionCode, int customerCode, int priorAppliDiv)
        {
            return ReadProc(out scmPriorSt, enterpriseCode, sectionCode, customerCode, priorAppliDiv);
        }
        // ------------ADD BY lingxiaoqing  2011.08.08--------------<<<<<<<<<<<<<<<<
        // ------------ADD 2011.08.10------------->>>>>>>>>>>>>>>
        /// <summary>
        /// �ǂݍ��ݏ���
        /// </summary>
        /// <param name="scmPriorSt">UI�f�[�^�N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param> 
        /// <param name="sectionCode">���_�R�[�h</param>  
        /// <param name="customerCode">���Ӑ�R�[�h</param> 
        /// <param name="priorAppliDiv">�D��K�p�敪</param>  
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        public int ReadPCCUOE(out SCMPriorSt scmPriorSt, string enterpriseCode, string sectionCode, int customerCode, int priorAppliDiv)
        {
            return ReadProcPCCUOE(out scmPriorSt, enterpriseCode, sectionCode, customerCode, priorAppliDiv);
        }
        // ------------ADD 2011.08.10-------------<<<<<<<<<<<<<<

        // ------------DELETE BY lingxiaoqing  2011.08.08------------->>>>>>>>>>>>>>>>>   
        ///// <summary>
        ///// �ǂݍ��ݏ���
        ///// </summary>
        ///// <param name="scmPriorSt">UI�f�[�^�N���X</param>
        ///// <param name="enterpriseCode">��ƃR�[�h</param> 
        ///// <param name="sectionCode">���_�R�[�h</param> 
        ///// <remarks>
        ///// <br>Note       : </br>
        ///// <br></br>
        ///// </remarks>
        //private int ReadProc(out SCMPriorSt scmPriorSt, string enterpriseCode, string sectionCode)
        //{
        //    int status = 0;

        //    scmPriorSt = null;

        //    try
        //    {
        //        SCMPriorStWork scmPriorStWork = new SCMPriorStWork();
        //        scmPriorStWork.EnterpriseCode = enterpriseCode;
        //        scmPriorStWork.SectionCode = sectionCode;

        //        // XML�֕ϊ����A������̃o�C�i����
        //        byte[] parabyte = XmlByteSerializer.Serialize(scmPriorStWork);

        //        status = this._iSCMPriorStDB.Read(ref parabyte, 0);
        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            // XML�̓ǂݍ���
        //            scmPriorStWork = (SCMPriorStWork)XmlByteSerializer.Deserialize(parabyte, typeof(SCMPriorStWork));
        //            // ���[�N��UI�f�[�^�N���X
        //            scmPriorSt = CopyToSCMPriorStFromSCMPriorStWork(scmPriorStWork);
        //        }

        //        return status;
        //    }
        //    catch (Exception)
        //    {				
        //        scmPriorSt = null;
        //        // �I�t���C������null���Z�b�g
        //        this._iSCMPriorStDB = null;
        //        // �ʐM�G���[��-1��߂�
        //        return -1;
        //    }
        //}
        // ------------DELETE BY lingxiaoqing  2011.08.08-------------<<<<<<<<<<<<<<

        // ------------ADD BY lingxiaoqing  2011.08.08------------->>>>>>>>>>>>>>>
        /// <summary>
        /// �ǂݍ��ݏ���
        /// </summary>
        /// <param name="scmPriorSt">UI�f�[�^�N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param> 
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param> 
        /// <param name="priorAppliDiv">�D��K�p�敪</param>  
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private int ReadProc(out SCMPriorSt scmPriorSt, string enterpriseCode, string sectionCode, int customerCode, int priorAppliDiv)
        {
            int status = 0;

            scmPriorSt = null;

            try
            {
                SCMPriorStWork scmPriorStWork = new SCMPriorStWork();
                scmPriorStWork.EnterpriseCode = enterpriseCode;
                scmPriorStWork.SectionCode = sectionCode;
                scmPriorStWork.CustomerCode = customerCode;
                scmPriorStWork.PriorAppliDiv = priorAppliDiv;

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(scmPriorStWork);

                status = this._iSCMPriorStDB.Read(ref parabyte, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XML�̓ǂݍ���
                    scmPriorStWork = (SCMPriorStWork)XmlByteSerializer.Deserialize(parabyte, typeof(SCMPriorStWork));
                    // ���[�N��UI�f�[�^�N���X
                    scmPriorSt = CopyToSCMPriorStFromSCMPriorStWork(scmPriorStWork);
                }

                return status;
            }
            catch (Exception)
            {
                scmPriorSt = null;
                // �I�t���C������null���Z�b�g
                this._iSCMPriorStDB = null;
                // �ʐM�G���[��-1��߂�
                return -1;
            }
        }
        // ------------ADD BY lingxiaoqing  2011.08.08-------------<<<<<<<<<<<<<<

        // ------------ADD 2011.08.10------------->>>>>>>>>>>>>>>
        /// <summary>
        /// �ǂݍ��ݏ���
        /// </summary>
        /// <param name="scmPriorSt">UI�f�[�^�N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param> 
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param> 
        /// <param name="priorAppliDiv">�D��K�p�敪</param>  
        /// <remarks>
        /// <br>Programmer : LIUSY</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private int ReadProcPCCUOE(out SCMPriorSt scmPriorSt, string enterpriseCode, string sectionCode, int customerCode, int priorAppliDiv)
        {
            int status = 0;

            scmPriorSt = null;

            try
            {
                SCMPriorStWork scmPriorStWork = new SCMPriorStWork();
                scmPriorStWork.EnterpriseCode = enterpriseCode;
                scmPriorStWork.SectionCode = sectionCode;
                scmPriorStWork.CustomerCode = customerCode;
                scmPriorStWork.PriorAppliDiv = priorAppliDiv;

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(scmPriorStWork);

                status = this._iSCMPriorStDB.ReadPCCUOE(ref parabyte, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XML�̓ǂݍ���
                    scmPriorStWork = (SCMPriorStWork)XmlByteSerializer.Deserialize(parabyte, typeof(SCMPriorStWork));
                    // ���[�N��UI�f�[�^�N���X
                    scmPriorSt = CopyToSCMPriorStFromSCMPriorStWork(scmPriorStWork);
                }

                return status;
            }
            catch (Exception)
            {
                scmPriorSt = null;
                // �I�t���C������null���Z�b�g
                this._iSCMPriorStDB = null;
                // �ʐM�G���[��-1��߂�
                return -1;
            }
        }
        // ------------ADD 2011.08.10------------->>>>>>>>>>>>>>>
		#endregion

		#region -- �o�^��X�V���� --
		/// <summary>
		/// �o�^�E�X�V����
		/// </summary>
        /// <param name="scmPriorSt">UI�f�[�^�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �o�^�E�X�V�������s���܂��B</br>
		/// <br></br>
		/// </remarks>
        public int Write(ref SCMPriorSt scmPriorSt)
		{
            int status = 0;

			// UI�f�[�^�N���X�����[�N
            SCMPriorStWork scmPriorStWork = CopyToSCMPriorStWorkFromSCMPriorSt(scmPriorSt);

            object obj = scmPriorStWork;
			
			try
			{
				// �������ݏ���
                status = this._iSCMPriorStDB.Write(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    if (obj is ArrayList)
                    {
                        scmPriorStWork = (SCMPriorStWork)((ArrayList)obj)[0];
                        // ���[�N��UI�f�[�^�N���X
                        scmPriorSt = CopyToSCMPriorStFromSCMPriorStWork(scmPriorStWork);
                    }
                }
			}
			catch (Exception)
			{
				// �I�t���C������null���Z�b�g
				this._iSCMPriorStDB = null;
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
        /// <param name="scmPriorSt">UI�f�[�^�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : SCM�D��ݒ�̘_���폜���s���܂��B</br>
		/// <br></br>
		/// </remarks>
        public int LogicalDelete(ref SCMPriorSt scmPriorSt)
		{
            int status = 0;

            // UI�f�[�^�N���X�����[�N
            SCMPriorStWork scmPriorStWork = CopyToSCMPriorStWorkFromSCMPriorSt(scmPriorSt);

            object obj = scmPriorStWork;

            try
            {
                // �_���폜
                status = this._iSCMPriorStDB.LogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    scmPriorStWork = (SCMPriorStWork)obj;
                    // ���[�N��UI�f�[�^�N���X
                    scmPriorSt = CopyToSCMPriorStFromSCMPriorStWork(scmPriorStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iSCMPriorStDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
		}

		/// <summary>
		/// �����폜����
		/// </summary>
        /// <param name="scmPriorSt">UI�f�[�^�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : SCM�D��ݒ�̕����폜���s���܂��B</br>
		/// <br></br>
		/// </remarks>
        public int Delete(SCMPriorSt scmPriorSt)
		{
            int status = 0;

            try
            {
                // UI�f�[�^�N���X�����[�N
                SCMPriorStWork scmPriorStWork = CopyToSCMPriorStWorkFromSCMPriorSt(scmPriorSt);

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(scmPriorStWork);

                // �����폜
                status = this._iSCMPriorStDB.Delete(parabyte);
                
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iSCMPriorStDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
		}
		#endregion

        #region -- �������� --
        /// <summary>
        /// SCM�D��ݒ蕜������
        /// </summary>
        /// <param name="scmPriorSt">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM�D��ݒ�̕������s���܂�</br>
        /// <br></br>
        /// </remarks>
        public int Revival(ref SCMPriorSt scmPriorSt)
        {
            int status = 0;

            try
            {
                // UI�f�[�^�N���X�����[�N
                SCMPriorStWork scmPriorStWork = CopyToSCMPriorStWorkFromSCMPriorSt(scmPriorSt);

                object obj = scmPriorStWork;

                // ��������
                status = this._iSCMPriorStDB.RevivalLogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    scmPriorStWork = (SCMPriorStWork)obj;
                    // ���[�N��UI�f�[�^�N���X
                    scmPriorSt = CopyToSCMPriorStFromSCMPriorStWork(scmPriorStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iSCMPriorStDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }
        #endregion

        #region -- �������� --
        /// <summary>
        /// SCM�D��ݒ茟�������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : SCM�D��ݒ�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br></br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode);
        }

        /// <summary>
        /// SCM�D��ݒ茟������
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : SCM�D��ݒ�̌����������s���܂��B</br>
		/// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode)
		{
            int status = 0;

            SCMPriorStWork scmPriorStWork = new SCMPriorStWork();
            scmPriorStWork.EnterpriseCode = enterpriseCode;

			retList = new ArrayList();
			
            object paraobj = scmPriorStWork;
			object retobj = null;

            // SCM�D��ݒ�̑S����
            status = this._iSCMPriorStDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData01);
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                ArrayList workList = retobj as ArrayList;

                foreach (SCMPriorStWork wkSCMPriorStWork in workList)
                {
                    retList.Add(CopyToSCMPriorStFromSCMPriorStWork(wkSCMPriorStWork));
                }
            }
                
 			return status;
		}
		#endregion

        #region -- �N���X�����o�[�R�s�[���� --
        /// <summary>
		/// �N���X�����o�[�R�s�[�����i���[�N�N���X��UI�f�[�^�N���X�j
		/// </summary>
        /// <param name="scmPriorStWork">���[�N�N���X</param>
        /// <returns>UI�f�[�^�N���X</returns>
		/// <remarks>
        /// <br>Note       : ���[�N�N���X����UI�f�[�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br></br>
        /// </remarks>
        private SCMPriorSt CopyToSCMPriorStFromSCMPriorStWork(SCMPriorStWork scmPriorStWork)
		{
            SCMPriorSt scmPriorSt = new SCMPriorSt();

            scmPriorSt.CreateDateTime = scmPriorStWork.CreateDateTime;
            scmPriorSt.UpdateDateTime = scmPriorStWork.UpdateDateTime;
            scmPriorSt.EnterpriseCode = scmPriorStWork.EnterpriseCode;
            scmPriorSt.FileHeaderGuid = scmPriorStWork.FileHeaderGuid;
            scmPriorSt.UpdEmployeeCode = scmPriorStWork.UpdEmployeeCode;
            scmPriorSt.UpdAssemblyId1 = scmPriorStWork.UpdAssemblyId1;
            scmPriorSt.UpdAssemblyId2 = scmPriorStWork.UpdAssemblyId2;
            scmPriorSt.LogicalDeleteCode = scmPriorStWork.LogicalDeleteCode;
            scmPriorSt.SectionCode = scmPriorStWork.SectionCode;

            scmPriorSt.PrioritySettingCd1 = scmPriorStWork.PrioritySettingCd1;      // �D��ݒ�R�[�h�P
            scmPriorSt.PrioritySettingNm1 = scmPriorStWork.PrioritySettingNm1;      // �D��ݒ薼�̂P
            scmPriorSt.PrioritySettingCd2 = scmPriorStWork.PrioritySettingCd2;      // �D��ݒ�R�[�h�Q
            scmPriorSt.PrioritySettingNm2 = scmPriorStWork.PrioritySettingNm2;      // �D��ݒ薼�̂Q
            scmPriorSt.PrioritySettingCd3 = scmPriorStWork.PrioritySettingCd3;      // �D��ݒ�R�[�h�R
            scmPriorSt.PrioritySettingNm3 = scmPriorStWork.PrioritySettingNm3;      // �D��ݒ薼�̂R
            scmPriorSt.PrioritySettingCd4 = scmPriorStWork.PrioritySettingCd4;      // �D��ݒ�R�[�h�S
            scmPriorSt.PrioritySettingNm4 = scmPriorStWork.PrioritySettingNm4;      // �D��ݒ薼�̂S
            scmPriorSt.PrioritySettingCd5 = scmPriorStWork.PrioritySettingCd5;      // �D��ݒ�R�[�h�T
            scmPriorSt.PrioritySettingNm5 = scmPriorStWork.PrioritySettingNm5;      // �D��ݒ薼�̂T

            scmPriorSt.PriorPriceSetCd1 = scmPriorStWork.PriorPriceSetCd1;          // �D�承�i�ݒ�R�[�h�P
            scmPriorSt.PriorPriceSetNm1 = scmPriorStWork.PriorPriceSetNm1;          // �D�承�i�ݒ薼�̂P
            scmPriorSt.PriorPriceSetCd2 = scmPriorStWork.PriorPriceSetCd2;          // �D�承�i�ݒ�R�[�h�Q
            scmPriorSt.PriorPriceSetNm2 = scmPriorStWork.PriorPriceSetNm2;          // �D�承�i�ݒ薼�̂Q
            scmPriorSt.PriorPriceSetCd3 = scmPriorStWork.PriorPriceSetCd3;          // �D�承�i�ݒ�R�[�h�R
            scmPriorSt.PriorPriceSetNm3 = scmPriorStWork.PriorPriceSetNm3;          // �D�承�i�ݒ薼�̂R
            scmPriorSt.PriorPriceSetCd4 = scmPriorStWork.PriorPriceSetCd4;          // �D�承�i�ݒ�R�[�h�S
            scmPriorSt.PriorPriceSetNm4 = scmPriorStWork.PriorPriceSetNm4;          // �D�承�i�ݒ薼�̂S
            scmPriorSt.PriorPriceSetCd5 = scmPriorStWork.PriorPriceSetCd5;          // �D�承�i�ݒ�R�[�h�T
            scmPriorSt.PriorPriceSetNm5 = scmPriorStWork.PriorPriceSetNm5;          // �D�承�i�ݒ薼�̂T

            //-----ADD BY lingxiaoqing  2011.08.08---------->>>>>>>>>>>>>>>
            //���Ӑ�R�[�h
            scmPriorSt.CustomerCode = scmPriorStWork.CustomerCode;
            //�D��K�p�敪
            scmPriorSt.PriorAppliDiv = scmPriorStWork.PriorAppliDiv;
            //�I�����Ώۏ��D�敪    
            scmPriorSt.SelTgtPureDiv = scmPriorStWork.SelTgtPureDiv;
            //�I�����Ώۍ݌ɋ敪
            scmPriorSt.SelTgtStckDiv = scmPriorStWork.SelTgtStckDiv;
            //�I�����ΏۃL�����y�[���敪
            scmPriorSt.SelTgtCampDiv = scmPriorStWork.SelTgtCampDiv;
            //��I�����Ώۏ��D�敪    
            scmPriorSt.UnSelTgtPureDiv = scmPriorStWork.UnSelTgtPureDiv;
            //��I�����Ώۍ݌ɋ敪
            scmPriorSt.UnSelTgtStckDiv = scmPriorStWork.UnSelTgtStckDiv;
            //��I�����ΏۃL�����y�[���敪
            scmPriorSt.UnSelTgtCampDiv = scmPriorStWork.UnSelTgtCampDiv;
            //�I�����Ώۉ��i�敪�P
            scmPriorSt.SelTgtPricDiv1 = scmPriorStWork.SelTgtPricDiv1;
            //�I�����Ώۉ��i�敪�Q
            scmPriorSt.SelTgtPricDiv2 = scmPriorStWork.SelTgtPricDiv2;
            //�I�����Ώۉ��i�敪 3
            scmPriorSt.SelTgtPricDiv3 = scmPriorStWork.SelTgtPricDiv3;
            //��I�����Ώۉ��i�敪�P
            scmPriorSt.UnSelTgtPricDiv1 = scmPriorStWork.UnSelTgtPricDiv1;
            //��I�����Ώۉ��i�敪�Q
            scmPriorSt.UnSelTgtPricDiv2 = scmPriorStWork.UnSelTgtPricDiv2;
            //��I�����Ώۉ��i�敪 3
            scmPriorSt.UnSelTgtPricDiv3 = scmPriorStWork.UnSelTgtPricDiv3;
            //-----ADD BY lingxiaoqing  2011.08.08 -----------------<<<<<<<<<<<<<<<<<<
			
            return scmPriorSt;
		}
		
		/// <summary>
        /// �N���X�����o�[�R�s�[�����iUI�f�[�^�N���X�˃��[�N�N���X�j
		/// </summary>
        /// <param name="scmPriorSt">UI�f�[�^�N���X</param>
        /// <returns>���[�N�N���X</returns>
		/// <remarks>
        /// <br>Note       : UI�f�[�^�N���X���烏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br></br>
		/// </remarks>
        private SCMPriorStWork CopyToSCMPriorStWorkFromSCMPriorSt(SCMPriorSt scmPriorSt)
		{
            SCMPriorStWork scmPriorStWork = new SCMPriorStWork();

            scmPriorStWork.CreateDateTime = scmPriorSt.CreateDateTime;
            scmPriorStWork.UpdateDateTime = scmPriorSt.UpdateDateTime;
            scmPriorStWork.EnterpriseCode = scmPriorSt.EnterpriseCode;
            scmPriorStWork.FileHeaderGuid = scmPriorSt.FileHeaderGuid;
            scmPriorStWork.UpdEmployeeCode = scmPriorSt.UpdEmployeeCode;
            scmPriorStWork.UpdAssemblyId1 = scmPriorSt.UpdAssemblyId1;
            scmPriorStWork.UpdAssemblyId2 = scmPriorSt.UpdAssemblyId2;
            scmPriorStWork.LogicalDeleteCode = scmPriorSt.LogicalDeleteCode;
            scmPriorStWork.SectionCode = scmPriorSt.SectionCode;            

            scmPriorStWork.PrioritySettingCd1 = scmPriorSt.PrioritySettingCd1;      // �D��ݒ�R�[�h�P
            scmPriorStWork.PrioritySettingNm1 = scmPriorSt.PrioritySettingNm1;      // �D��ݒ薼�̂P
            scmPriorStWork.PrioritySettingCd2 = scmPriorSt.PrioritySettingCd2;      // �D��ݒ�R�[�h�Q
            scmPriorStWork.PrioritySettingNm2 = scmPriorSt.PrioritySettingNm2;      // �D��ݒ薼�̂Q
            scmPriorStWork.PrioritySettingCd3 = scmPriorSt.PrioritySettingCd3;      // �D��ݒ�R�[�h�R
            scmPriorStWork.PrioritySettingNm3 = scmPriorSt.PrioritySettingNm3;      // �D��ݒ薼�̂R
            scmPriorStWork.PrioritySettingCd4 = scmPriorSt.PrioritySettingCd4;      // �D��ݒ�R�[�h�S
            scmPriorStWork.PrioritySettingNm4 = scmPriorSt.PrioritySettingNm4;      // �D��ݒ薼�̂S
            scmPriorStWork.PrioritySettingCd5 = scmPriorSt.PrioritySettingCd5;      // �D��ݒ�R�[�h�T
            scmPriorStWork.PrioritySettingNm5 = scmPriorSt.PrioritySettingNm5;      // �D��ݒ薼�̂T

            scmPriorStWork.PriorPriceSetCd1 = scmPriorSt.PriorPriceSetCd1;          // �D�承�i�ݒ�R�[�h�P
            scmPriorStWork.PriorPriceSetNm1 = scmPriorSt.PriorPriceSetNm1;          // �D�承�i�ݒ薼�̂P
            scmPriorStWork.PriorPriceSetCd2 = scmPriorSt.PriorPriceSetCd2;          // �D�承�i�ݒ�R�[�h�Q
            scmPriorStWork.PriorPriceSetNm2 = scmPriorSt.PriorPriceSetNm2;          // �D�承�i�ݒ薼�̂Q
            scmPriorStWork.PriorPriceSetCd3 = scmPriorSt.PriorPriceSetCd3;          // �D�承�i�ݒ�R�[�h�R
            scmPriorStWork.PriorPriceSetNm3 = scmPriorSt.PriorPriceSetNm3;          // �D�承�i�ݒ薼�̂R
            scmPriorStWork.PriorPriceSetCd4 = scmPriorSt.PriorPriceSetCd4;          // �D�承�i�ݒ�R�[�h�S
            scmPriorStWork.PriorPriceSetNm4 = scmPriorSt.PriorPriceSetNm4;          // �D�承�i�ݒ薼�̂S
            scmPriorStWork.PriorPriceSetCd5 = scmPriorSt.PriorPriceSetCd5;          // �D�承�i�ݒ�R�[�h�T
            scmPriorStWork.PriorPriceSetNm5 = scmPriorSt.PriorPriceSetNm5;          // �D�承�i�ݒ薼�̂T

            //---------ADD BY lingxiaoqing------------>>>>>>>>>
            //���Ӑ�R�[�h
            scmPriorStWork.CustomerCode = scmPriorSt.CustomerCode;
            //�D��K�p�敪
            scmPriorStWork.PriorAppliDiv = scmPriorSt.PriorAppliDiv;
            //�I�����Ώۏ��D�敪    
            scmPriorStWork.SelTgtPureDiv = scmPriorSt.SelTgtPureDiv;
            //�I�����Ώۍ݌ɋ敪
            scmPriorStWork.SelTgtStckDiv = scmPriorSt.SelTgtStckDiv;
            //�I�����ΏۃL�����y�[���敪
            scmPriorStWork.SelTgtCampDiv = scmPriorSt.SelTgtCampDiv;
            //��I�����Ώۏ��D�敪    
            scmPriorStWork.UnSelTgtPureDiv = scmPriorSt.UnSelTgtPureDiv;
            //��I�����Ώۍ݌ɋ敪
            scmPriorStWork.UnSelTgtStckDiv = scmPriorSt.UnSelTgtStckDiv;
            //��I�����ΏۃL�����y�[���敪
            scmPriorStWork.UnSelTgtCampDiv = scmPriorSt.UnSelTgtCampDiv;
            //�I�����Ώۉ��i�敪�P
            scmPriorStWork.SelTgtPricDiv1 = scmPriorSt.SelTgtPricDiv1;
            //�I�����Ώۉ��i�敪�Q
            scmPriorStWork.SelTgtPricDiv2 = scmPriorSt.SelTgtPricDiv2;
            //�I�����Ώۉ��i�敪 3
            scmPriorStWork.SelTgtPricDiv3 = scmPriorSt.SelTgtPricDiv3;
            //��I�����Ώۉ��i�敪�P
            scmPriorStWork.UnSelTgtPricDiv1 = scmPriorSt.UnSelTgtPricDiv1;
            //��I�����Ώۉ��i�敪�Q
            scmPriorStWork.UnSelTgtPricDiv2 = scmPriorSt.UnSelTgtPricDiv2;
            //��I�����Ώۉ��i�敪 3
            scmPriorStWork.UnSelTgtPricDiv3 = scmPriorSt.UnSelTgtPricDiv3;
            //�\����7
            //---------ADD BY lingxiaoqing------------<<<<<<<<<<
            return scmPriorStWork;
		}
		#endregion
		
	}
}
