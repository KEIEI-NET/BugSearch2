//**********************************************************************//
// System			:	Partsman     									//
// Sub System		:													//
// Program name		:	�����X�V�A�N�Z�X�N���X							//
//					:	DepsitMainAcs.DLL								//
// Name Space		:	Broadleaf.Application.Controller				//
// Programmer		:	���i�@��										//
// Date				:	2005.08.09										//
// Note				:													//
//----------------------------------------------------------------------//
// Update Note		:	2008/06/26 30414 �E �K�j                		//
//                  :   Partsman�p�ɕύX                                //
//----------------------------------------------------------------------//
//					(c)Copyright  2008 Broadleaf Co,. Ltd				//
//**********************************************************************//
using System;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �����X�V�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����f�[�^�̍X�V������s���A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : 95089 ���i�@��</br>
    /// <br>Date       : 2005.08.11</br>
    /// <br>Update Note : 2010.05.06 gejun</br>
    /// <br>              M1007A-�x����`�f�[�^�X�V�ǉ�</br>
    /// <br>Update Note : 2011.08.01 qijh</br>
    /// <br>              SCM�Ή� - ���_�Ǘ�(10704767-00)
    /// <br>              ���M�ς݂̃`�F�b�N���b�Z�[�W���o�͂ł���悤�ɉ��C</br>
    /// </remarks>
    public class DepsitMainAcs
    {
        // ADD 2011/08/01 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
        /// <summary>
        /// ���M�σ`�F�b�N���s�̃X�e�[�^�X
        /// </summary>
        private const int STATUS_CHK_SEND_ERR = -1001;

        /// <summary>
        /// ���M�σ`�F�b�N���s�̃G���[���b�Z�[�W
        /// </summary>
        private const string CHK_SEND_ERR_MSG = "���M�ς݂̃f�[�^�ׁ̈A�X�V�ł��܂���B";
        // ADD 2011/08/01 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<

        IDepsitMainDB _depsitMainDB;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���X�g���N�^</br>
        /// <br>Programmer : 18322 T.Kimura</br>
        /// <br>Date       : 2007.05.18</br>
        /// </remarks>
        public DepsitMainAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._depsitMainDB = (IDepsitMainDB)MediationDepsitMainDB.GetDepsitMainDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._depsitMainDB = null;
            }
        }

        /// <summary>
        /// �����X�V����
        /// </summary>
        /// <param name="depsitDataWork">������񃏁[�N</param>
        /// <param name="depositAlwWorkList">����������񃏁[�N</param>
        /// <param name="errmsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �������E���������������Ƀf�[�^�X�V���s���܂�</br>
        /// <br>           : �����ԍ������̎��A�V�K�����쐬�Ƃ��܂�</br>
        /// <br>           : �_���폜�𗧂Ă��ꍇ�A�폜�������s���܂�</br>
        /// <br>           : ���������̍폜���s���ꍇ�͍폜�������������R�[�h�̂ݘ_���폜�𗧂Ă܂�</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        public int WriteDB(ref DepsitDataWork depsitDataWork, ref DepositAlwWork[] depositAlwWorkList, out string errmsg)
        {

            // XML�֕ϊ����A�N���X�̃o�C�i����
            byte[] depsitDataWorkByte = XmlByteSerializer.Serialize(depsitDataWork);
            byte[] depositAlwWorkListByte = XmlByteSerializer.Serialize(depositAlwWorkList);

            errmsg = "";
            int status = 0;
            try
            {
                // �����f�[�^��������
                status = this._depsitMainDB.Write(ref depsitDataWorkByte, ref depositAlwWorkListByte);
                if (status == 0)
                {
                    depsitDataWork = (DepsitDataWork)XmlByteSerializer.Deserialize(depsitDataWorkByte, typeof(DepsitDataWork));
                    depositAlwWorkList = (DepositAlwWork[])XmlByteSerializer.Deserialize(depositAlwWorkListByte, typeof(DepositAlwWork[]));
                }
                // ADD 2011/08/01 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
                if (STATUS_CHK_SEND_ERR == status)
                    errmsg = CHK_SEND_ERR_MSG;
                // ADD 2011/08/01 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<
            }
            catch (Exception ex)
            {
                //�I�t���C������null���Z�b�g
                this._depsitMainDB = null;
                //�ʐM�G���[��-1��߂�
                status = -1;

                errmsg = ex.Message;
            }
            return status;
        }

        // --------------- ADD START 2010.05.06 gejun FOR M1007A-M1007A-�x����`�f�[�^�X�V�ǉ�------->>>>
        /// <summary>
        /// �����X�V����(��`�f�[�^���A���)
        /// </summary>
        /// <param name="depsitDataWork">������񃏁[�N</param>
        /// <param name="depositAlwWorkList">����������񃏁[�N</param>
        /// <param name="errmsg">�G���[���b�Z�[�W</param>
        /// <param name="rcvDraftDataWorkUpd">��`�f�[�^�i�X�V�p�j���[�N</param>
        /// <param name="rcvDraftDataWorkDel">��`�f�[�^�i�폜�p�j���[�N</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �������E�����������E��`�������Ƀf�[�^�X�V���s���܂�</br>
        /// <br>           : �����ԍ������̎��A�V�K�����쐬�Ƃ��܂�</br>
        /// <br>           : �_���폜�𗧂Ă��ꍇ�A�폜�������s���܂�</br>
        /// <br>           : ���������̍폜���s���ꍇ�͍폜�������������R�[�h�̂ݘ_���폜�𗧂Ă܂�</br>
        /// <br>Note�@�@�@  : ��`���̍X�V�������s���܂��B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010/05/06</br>
        /// </remarks>
        public int WriteDBWithDraftData(ref DepsitDataWork depsitDataWork, ref DepositAlwWork[] depositAlwWorkList, out string errmsg, RcvDraftDataWork rcvDraftDataWorkUpd, RcvDraftDataWork rcvDraftDataWorkDel)
        {

            // XML�֕ϊ����A�N���X�̃o�C�i����
            byte[] depsitDataWorkByte = XmlByteSerializer.Serialize(depsitDataWork);
            byte[] depositAlwWorkListByte = XmlByteSerializer.Serialize(depositAlwWorkList);

            byte[] rcvDraftDataWorkUpdByte;
            if (rcvDraftDataWorkUpd != null)
               rcvDraftDataWorkUpdByte = XmlByteSerializer.Serialize(rcvDraftDataWorkUpd);
            else
               rcvDraftDataWorkUpdByte = null;

           byte[] rcvDraftDataWorkDelByte;
           if (rcvDraftDataWorkDel != null)
               rcvDraftDataWorkDelByte = XmlByteSerializer.Serialize(rcvDraftDataWorkDel);
           else
               rcvDraftDataWorkDelByte = null;

            errmsg = "";
            int status = 0;
            try
            {
                // �����f�[�^��������
                status = this._depsitMainDB.WriteWithDraftData(ref depsitDataWorkByte, ref depositAlwWorkListByte, rcvDraftDataWorkUpdByte, rcvDraftDataWorkDelByte);
                if (status == 0)
                {
                    depsitDataWork = (DepsitDataWork)XmlByteSerializer.Deserialize(depsitDataWorkByte, typeof(DepsitDataWork));
                    depositAlwWorkList = (DepositAlwWork[])XmlByteSerializer.Deserialize(depositAlwWorkListByte, typeof(DepositAlwWork[]));
                }
                // ADD 2011/08/01 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
                if (STATUS_CHK_SEND_ERR == status)
                    errmsg = CHK_SEND_ERR_MSG;
                // ADD 2011/08/01 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<
            }
            catch (Exception ex)
            {
                //�I�t���C������null���Z�b�g
                this._depsitMainDB = null;
                //�ʐM�G���[��-1��߂�
                status = -1;

                errmsg = ex.Message;
            }

            return status;
        }
        // --------------- ADD END 2010.05.06 gejun FOR M1007A-M1007A-�x����`�f�[�^�X�V�ǉ�------->>>>

        /// <summary>
        /// �����Ǎ�����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="depositSlipNo">�����ԍ�</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X(10:���ρ@20:�󒍁@30:����@40:�o��)</param>
        /// <param name="depsitDataWork">�������</param>
        /// <param name="depositAlwWorkList">�����������</param>
        /// <param name="errmsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �������E����������������ԍ������Ƀf�[�^�擾���s���܂�</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        public int ReadDB(string enterpriseCode, 
                          int depositSlipNo, 
                          int acptAnOdrStatus, 
                          out DepsitDataWork depsitDataWork, 
                          out DepositAlwWork[] depositAlwWorkList, 
                          out string errmsg)
        {

            byte[] depsitDataWorkByte = null;
            byte[] depositAlwWorkListByte = null;

            depsitDataWork = null;
            depositAlwWorkList = null;
            errmsg = "";

            int status = 0;
            try
            {
                // �����f�[�^�Ǎ���
                status = this._depsitMainDB.Read(enterpriseCode, depositSlipNo, acptAnOdrStatus, out depsitDataWorkByte, out depositAlwWorkListByte);
                if (status == 0)
                {
                    depsitDataWork = (DepsitDataWork)XmlByteSerializer.Deserialize(depsitDataWorkByte, typeof(DepsitDataWork));
                    depositAlwWorkList = (DepositAlwWork[])XmlByteSerializer.Deserialize(depositAlwWorkListByte, typeof(DepositAlwWork[]));
                }
            }
            catch (Exception ex)
            {
                //�I�t���C������null���Z�b�g
                this._depsitMainDB = null;
                //�ʐM�G���[��-1��߂�
                status = -1;

                errmsg = ex.Message;
            }

            return status;
        }

        #region 2008/06/26 DEL Partsman�p�ɕύX
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �����X�V����
		/// </summary>
		/// <param name="depsitMainWork">������񃏁[�N</param>
		/// <param name="depositAlwWorkList">����������񃏁[�N</param>
		/// <param name="errmsg">�G���[���b�Z�[�W</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������E���������������Ƀf�[�^�X�V���s���܂�</br>
		/// <br>           : �����ԍ������̎��A�V�K�����쐬�Ƃ��܂�</br>
		/// <br>           : �_���폜�𗧂Ă��ꍇ�A�폜�������s���܂�</br>
		/// <br>           : ���������̍폜���s���ꍇ�͍폜�������������R�[�h�̂ݘ_���폜�𗧂Ă܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
		public int WriteDB(ref DepsitMainWork depsitMainWork,  ref DepositAlwWork[] depositAlwWorkList, out string errmsg)
		{

			// XML�֕ϊ����A�N���X�̃o�C�i����
			byte[] depsitMainWorkByte = XmlByteSerializer.Serialize(depsitMainWork);
			byte[] depositAlwWorkListByte = XmlByteSerializer.Serialize(depositAlwWorkList);

			errmsg = "";
			int status = 0;
			try
			{
				// �����f�[�^��������
				status = this._depsitMainDB.Write(ref depsitMainWorkByte, ref depositAlwWorkListByte);
				if (status == 0)
				{
					depsitMainWork = (DepsitMainWork)XmlByteSerializer.Deserialize(depsitMainWorkByte,typeof(DepsitMainWork));
					depositAlwWorkList = (DepositAlwWork[])XmlByteSerializer.Deserialize(depositAlwWorkListByte,typeof(DepositAlwWork[]));
				}
			}
			catch (Exception ex)
			{
				//�I�t���C������null���Z�b�g
				this._depsitMainDB = null;
				//�ʐM�G���[��-1��߂�
				status = -1;

				errmsg = ex.Message;
			}

			return status;
		}
        
        /// <summary>
		/// �����Ǎ�����
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="DepositSlipNo">�����ԍ�</param>
		/// <param name="depsitMainWork">�������</param>
		/// <param name="depositAlwWorkList">�����������</param>
		/// <param name="errmsg">�G���[���b�Z�[�W</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������E����������������ԍ������Ƀf�[�^�擾���s���܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>

		public int ReadDB(string EnterpriseCode, int DepositSlipNo, out DepsitMainWork depsitMainWork,  out DepositAlwWork[] depositAlwWorkList, out string errmsg)
		{

			byte[] depsitMainWorkByte = null;
			byte[] depositAlwWorkListByte = null;

			depsitMainWork = null;
			depositAlwWorkList = null;
			errmsg = "";

			int status = 0;
			try
			{
				// �����f�[�^�Ǎ���
				status = this._depsitMainDB.Read(EnterpriseCode, DepositSlipNo, out depsitMainWorkByte, out depositAlwWorkListByte);
				if (status == 0)
				{
					depsitMainWork = (DepsitMainWork)XmlByteSerializer.Deserialize(depsitMainWorkByte,typeof(DepsitMainWork));
					depositAlwWorkList = (DepositAlwWork[])XmlByteSerializer.Deserialize(depositAlwWorkListByte,typeof(DepositAlwWork[]));
				}
			}
			catch (Exception ex)
			{
				//�I�t���C������null���Z�b�g
				this._depsitMainDB = null;
				//�ʐM�G���[��-1��߂�
				status = -1;

				errmsg = ex.Message;
			}

			return status;
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman�p�ɕύX

        /// <summary>
        /// �����ꊇ�쐬�����i�󒍎w��^�j
        /// </summary>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="createDepsitMainWorkList">�����X�V�f�[�^�p�����[�^(�󒍎w��^)</param>
        /// <param name="depositSlipNoList">�X�V���������f�[�^�̓����ԍ��z��</param>
        /// <param name="errmsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �ꊇ�쐬�p�p�����[�^����w��󒍂ւ̈����X�V�E�����V�K�쐬�������s���܂�</br>
        /// <br>           : �󒍎w��^��p�ł���A�V�K�����E�����̂ݍs���܂�</br>
        /// <br>Programmer : 95089 ���i�@��</br>
        /// <br>Date       : 2005.08.11</br>
        /// </remarks>
        public int WriteDB(string EnterpriseCode, CreateDepsitMainWork[] createDepsitMainWorkList, out int[] depositSlipNoList, out string errmsg)
        {
            depositSlipNoList = null;

            // XML�֕ϊ����A�N���X�̃o�C�i����
            byte[] createDepsitMainWorkListByte = XmlByteSerializer.Serialize(createDepsitMainWorkList);

            errmsg = "";
            int status = 0;
            try
            {
                // �����f�[�^��������
                status = this._depsitMainDB.Write(EnterpriseCode, createDepsitMainWorkListByte, out depositSlipNoList);
                if (status == 0)
                {

                }
                // ADD 2011/08/01 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
                if (STATUS_CHK_SEND_ERR == status)
                    errmsg = CHK_SEND_ERR_MSG;
                // ADD 2011/08/01 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<
            }
            catch (Exception ex)
            {
                //�I�t���C������null���Z�b�g
                this._depsitMainDB = null;
                //�ʐM�G���[��-1��߂�
                status = -1;

                errmsg = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// �����폜����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="depositSlipNo">�����ԍ�</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X(10:���ρ@20:�󒍁@30:����@40:�o��)</param>
        /// <param name="errmsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肵�������ԍ��̓������E�����������폜���s���܂�</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        public int DeleteDB(string enterpriseCode, int depositSlipNo, int acptAnOdrStatus, out string errmsg)
        {
            errmsg = "";

            int status = 0;
            try
            {
                // ADD 2009/05/01 �R�����g�ǋL
                // �����폜���\�b�h���g�p���Ă��邪�A�����[�g���Ř_���폜�����ɕύX���Ă���
                // �����폜����
                status = this._depsitMainDB.Delete(enterpriseCode, depositSlipNo, acptAnOdrStatus);
                // ADD 2011/08/01 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
                if (STATUS_CHK_SEND_ERR == status)
                    errmsg = CHK_SEND_ERR_MSG;
                // ADD 2011/08/01 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<
            }
            catch (Exception ex)
            {
                //�I�t���C������null���Z�b�g
                this._depsitMainDB = null;

                //�ʐM�G���[��-1��߂�
                status = -1;

                errmsg = ex.Message;
            }

            return (status);
        }

        /// <summary>
        /// �����폜����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="depositSlipNo">�����ԍ�</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X(10:���ρ@20:�󒍁@30:����@40:�o��)</param>
        /// <param name="errmsg">�G���[���b�Z�[�W</param>
        /// <param name="retDepsitDataWork">�X�V�����f�[�^(�ԍ폜���̌������R�[�h)</param>
        /// <param name="retDepositAlwWorkList">�X�V���������f�[�^(�ԍ폜���̌����������R�[�h)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肵�������ԍ��̓������E�����������폜���s���܂�</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        public int DeleteDB(string enterpriseCode, 
                            int depositSlipNo, 
                            int acptAnOdrStatus,
                            out DepsitDataWork retDepsitDataWork, 
                            out DepositAlwWork[] retDepositAlwWorkList, 
                            out string errmsg)
        {
            retDepsitDataWork = null;
            retDepositAlwWorkList = null;
            byte[] depsitDataWorkByte = null;
            byte[] depositAlwWorkListByte = null;

            errmsg = "";

            int status = 0;
            try
            {
                // ADD 2009/05/01 �R�����g�ǋL
                // �����폜���\�b�h���g�p���Ă��邪�A�����[�g���Ř_���폜�����ɕύX���Ă���
                // �����폜����
                status = this._depsitMainDB.Delete(enterpriseCode, 
                                                   depositSlipNo, 
                                                   acptAnOdrStatus, 
                                                   out depsitDataWorkByte, 
                                                   out depositAlwWorkListByte);
                if (status == 0)
                {
                    if (depsitDataWorkByte != null)
                    {
                        retDepsitDataWork = (DepsitDataWork)XmlByteSerializer.Deserialize(depsitDataWorkByte, typeof(DepsitDataWork));
                    }
                    if (depositAlwWorkListByte != null)
                    {
                        retDepositAlwWorkList = (DepositAlwWork[])XmlByteSerializer.Deserialize(depositAlwWorkListByte, typeof(DepositAlwWork[]));
                    }
                }
                // ADD 2011/08/01 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
                if (STATUS_CHK_SEND_ERR == status)
                    errmsg = CHK_SEND_ERR_MSG;
                // ADD 2011/08/01 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<
            }
            catch (Exception ex)
            {
                //�I�t���C������null���Z�b�g
                this._depsitMainDB = null;
                //�ʐM�G���[��-1��߂�
                status = -1;

                errmsg = ex.Message;
            }

            return status;
        }

        #region 2008/06/26 DEL Partsman�p�ɕύX
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        
        /// <summary>
        /// �����폜����
        /// </summary>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="DepositSlipNo">�����ԍ�</param>
        /// <param name="errmsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肵�������ԍ��̓������E�����������폜���s���܂�</br>
        /// <br>Programmer : 95089 ���i�@��</br>
        /// <br>Date       : 2005.08.11</br>
        /// </remarks>
        public int DeleteDB(string EnterpriseCode, int DepositSlipNo, out string errmsg)
        {

            errmsg = "";

            int status = 0;
            try
            {
                // �����폜����
                status = this._depsitMainDB.Delete(EnterpriseCode, DepositSlipNo);
                if (status == 0)
                {

                }
            }
            catch (Exception ex)
            {
                //�I�t���C������null���Z�b�g
                this._depsitMainDB = null;
                //�ʐM�G���[��-1��߂�
                status = -1;

                errmsg = ex.Message;
            }

            return status;
        }
        
		/// <summary>
		/// �����폜����
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="DepositSlipNo">�����ԍ�</param>
		/// <param name="errmsg">�G���[���b�Z�[�W</param>
		/// <param name="RetDepsitMainWork">�X�V�����f�[�^(�ԍ폜���̌������R�[�h)</param>
		/// <param name="RetDepositAlwWorkList">�X�V���������f�[�^(�ԍ폜���̌����������R�[�h)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�肵�������ԍ��̓������E�����������폜���s���܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.09.20</br>
		/// </remarks>
		public int DeleteDB(string EnterpriseCode, int DepositSlipNo, out DepsitMainWork RetDepsitMainWork,  out DepositAlwWork[] RetDepositAlwWorkList, out string errmsg)
		{
			RetDepsitMainWork = null;
			RetDepositAlwWorkList = null;
			byte[] depsitMainWorkByte = null;
			byte[] depositAlwWorkListByte = null;

			errmsg = "";

			int status = 0;
			try
			{
				// �����폜����
				status = this._depsitMainDB.Delete(EnterpriseCode, DepositSlipNo, out depsitMainWorkByte, out depositAlwWorkListByte);
				if (status == 0)
				{
					if (depsitMainWorkByte != null)
						RetDepsitMainWork = (DepsitMainWork)XmlByteSerializer.Deserialize(depsitMainWorkByte,typeof(DepsitMainWork));
					if (depositAlwWorkListByte != null)
						RetDepositAlwWorkList = (DepositAlwWork[])XmlByteSerializer.Deserialize(depositAlwWorkListByte,typeof(DepositAlwWork[]));
				}
			}
			catch (Exception ex)
			{
				//�I�t���C������null���Z�b�g
				this._depsitMainDB = null;
				//�ʐM�G���[��-1��߂�
				status = -1;

				errmsg = ex.Message;
			}

			return status;
		}
        
        /// <summary>
        /// �ԓ����쐬����
        /// </summary>
        /// <param name="mode">0:�ԓ����쐬 1:�ԓ����E�V�������쐬</param>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="DepositCd">�a����敪</param>
        /// <param name="UpdateSecCd">�X�V���_�R�[�h</param>
        /// <param name="DepositAgentCode">�����S���҃R�[�h</param>
        /// <param name="DepositAgentNm">�����S���Җ�</param>
        /// <param name="AddUpADate">�v���</param>
        /// <param name="DepositSlipNo">�����ԍ�</param>
        /// <param name="errmsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肵�������ԍ��̐ԓ����쐬�������s���܂�</br>
        /// <br>Programmer : 95089 ���i�@��</br>
        /// <br>Date       : 2005.08.29</br>
        /// <br>Update Note: 2007.01.25 18322 T.Kimura ������ύX</br>
        /// </remarks>
        // �� 20070125 18322 c MA.NS�p�ɕύX
        //public int RedCreate(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, DateTime AddUpADate, int DepositSlipNo, out string errmsg )
        public int RedCreate(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo, out string errmsg)
        // �� 20070125 18322 c
        {
            errmsg = "";

            int status = 0;
            try
            {
                // �� 20070125 18322 c MA.NS�p�ɕύX
                //// �ԓ����쐬����
                //status = this._depsitMainDB.RedCreate(mode, EnterpriseCode, DepositCd, UpdateSecCd, DepositAgentCode, AddUpADate, DepositSlipNo);

                // �ԓ����쐬����
                status = this._depsitMainDB.RedCreate(mode
                                                     , EnterpriseCode
                                                     , DepositCd
                                                     , UpdateSecCd
                                                     , DepositAgentCode
                                                     , DepositAgentNm
                                                     , AddUpADate
                                                     , DepositSlipNo
                                                     );
                // �� 20070125 18322 c 
                if (status == 0)
                {

                }
            }
            catch (Exception ex)
            {
                //�I�t���C������null���Z�b�g
                this._depsitMainDB = null;
                //�ʐM�G���[��-1��߂�
                status = -1;

                errmsg = ex.Message;
            }

            return status;

        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman�p�ɕύX

        /// <summary>
        /// �ԓ����쐬����
        /// </summary>
        /// <param name="mode">0:�ԓ����쐬 1:�ԓ����E�V�������쐬</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="depositCd">�a����敪</param>
        /// <param name="updateSecCd">�X�V���_�R�[�h</param>
        /// <param name="depositAgentCode">�����S���҃R�[�h</param>
        /// <param name="depositAgentNm">�����S���Җ�</param>
        /// <param name="addUpADate">�v���</param>
        /// <param name="depositSlipNo">�����ԍ�</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X(10:���ρ@20:�󒍁@30:����@40:�o��)</param>
        /// <param name="errmsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肵�������ԍ��̐ԓ����쐬�������s���܂�</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        public int RedCreate(int mode, 
                             string enterpriseCode, 
                             int depositCd, 
                             string updateSecCd, 
                             string depositAgentCode, 
                             string depositAgentNm, 
                             DateTime addUpADate, 
                             int depositSlipNo, 
                             int acptAnOdrStatus,
                             out string errmsg)
        {
            errmsg = "";

            int status = 0;
            try
            {
                // �ԓ����쐬����
                status = this._depsitMainDB.RedCreate(mode,
                                                      enterpriseCode,
                                                      updateSecCd,
                                                      depositAgentCode,
                                                      depositAgentNm,
                                                      addUpADate,
                                                      depositCd,
                                                      acptAnOdrStatus);
                // ADD 2011/08/01 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
                if (STATUS_CHK_SEND_ERR == status)
                    errmsg = CHK_SEND_ERR_MSG;
                // ADD 2011/08/01 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<
            }
            catch (Exception ex)
            {
                //�I�t���C������null���Z�b�g
                this._depsitMainDB = null;

                //�ʐM�G���[��-1��߂�
                status = -1;

                errmsg = ex.Message;
            }

            return (status);

        }

        /// <summary>
        /// �ԓ����쐬����
        /// </summary>
        /// <param name="mode">0:�ԓ����쐬 1:�ԓ����E�V�������쐬</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="depositCd">�a����敪</param>
        /// <param name="updateSecCd">�X�V���_�R�[�h</param>
        /// <param name="depositAgentCode">�����S���҃R�[�h</param>
        /// <param name="depositAgentNm">�����S���Җ�</param>
        /// <param name="addUpADate">�v���</param>
        /// <param name="depositSlipNo">�����ԍ�</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X(10:���ρ@20:�󒍁@30:����@40:�o��)</param>
        /// <param name="retDepsitDataWorkList">�����}�X�^</param>
        /// <param name="retDepositAlwWorkList">���������}�X�^</param>
        /// <param name="errmsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肵�������ԍ��̐ԓ����쐬�������s���܂�</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        public int RedCreate(int mode,
                             string enterpriseCode,
                             int depositCd,
                             string updateSecCd,
                             string depositAgentCode,
                             string depositAgentNm,
                             DateTime addUpADate,
                             int depositSlipNo,
                             int acptAnOdrStatus,
                             out DepsitDataWork[] retDepsitDataWorkList,
                             out DepositAlwWork[] retDepositAlwWorkList,
                             out string errmsg)
        {
            errmsg = "";

            int status = 0;

            byte[] RetDepsitDataWorkListByte;
            byte[] RetDepositAlwWorkListByte;

            retDepsitDataWorkList = null;
            retDepositAlwWorkList = null;

            try
            {
                // DEL 2011/08/01 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
                // �ԓ����쐬����
                //this._depsitMainDB.RedCreate(mode, 
                //                             enterpriseCode,
                //                             updateSecCd,
                //                             depositAgentCode,
                //                             depositAgentNm,
                //                             addUpADate,
                //                             depositSlipNo,
                //                             acptAnOdrStatus,
                //                             out RetDepsitDataWorkListByte,
                //                             out RetDepositAlwWorkListByte);
                // DEL 2011/08/01 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<
                // ADD 2011/08/01 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
                // �ύX���e�F[status = ]��ǉ�
                status = this._depsitMainDB.RedCreate(mode,
                                               enterpriseCode,
                                               updateSecCd,
                                               depositAgentCode,
                                               depositAgentNm,
                                               addUpADate,
                                               depositSlipNo,
                                               acptAnOdrStatus,
                                               out RetDepsitDataWorkListByte,
                                               out RetDepositAlwWorkListByte);
                // ADD 2011/08/01 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<

                if (status == 0)
                {
                    retDepsitDataWorkList = (DepsitDataWork[])XmlByteSerializer.Deserialize(RetDepsitDataWorkListByte, typeof(DepsitDataWork[]));
                    retDepositAlwWorkList = (DepositAlwWork[])XmlByteSerializer.Deserialize(RetDepositAlwWorkListByte, typeof(DepositAlwWork[]));
                }
                // ADD 2011/08/01 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
                if (STATUS_CHK_SEND_ERR == status)
                    errmsg = CHK_SEND_ERR_MSG;
                // ADD 2011/08/01 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<
            }
            catch (Exception ex)
            {
                //�I�t���C������null���Z�b�g
                this._depsitMainDB = null;

                //�ʐM�G���[��-1��߂�
                status = -1;

                errmsg = ex.Message;
            }

            return status;

        }

        #region 2008/06/26 DEL Partsman�p�ɕύX
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �ԓ����쐬����
		/// </summary>
		/// <param name="mode">0:�ԓ����쐬 1:�ԓ����E�V�������쐬</param>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="DepositCd">�a����敪</param>
		/// <param name="UpdateSecCd">�X�V���_�R�[�h</param>
		/// <param name="DepositAgentCode">�����S���҃R�[�h</param>
		/// <param name="DepositAgentNm">�����S���Җ�</param>
		/// <param name="AddUpADate">�v���</param>
		/// <param name="DepositSlipNo">�����ԍ�</param>
		/// <param name="RetDepsitMainWorkList">�����}�X�^</param>
		/// <param name="RetDepositAlwWorkList">���������}�X�^</param>
		/// <param name="errmsg">�G���[���b�Z�[�W</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�肵�������ԍ��̐ԓ����쐬�������s���܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.29</br>
		/// <br>Update Note: 2007.01.25 T.Kimura ������ύX</br>
		/// </remarks>
        // �� 20070125 18322 c MA.NS�p�ɕύX
        //public int RedCreate(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, DateTime AddUpADate, int DepositSlipNo, out DepsitMainWork[] RetDepsitMainWorkList, out DepositAlwWork[] RetDepositAlwWorkList, out string errmsg )
        public int RedCreate(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo, out DepsitMainWork[] RetDepsitMainWorkList, out DepositAlwWork[] RetDepositAlwWorkList, out string errmsg )
        // �� 20070125 18322 c
		{
			errmsg = "";

			int status = 0;

			byte[] RetDepsitMainWorkListByte;
			byte[] RetDepositAlwWorkListByte;

			RetDepsitMainWorkList = null;
			RetDepositAlwWorkList = null;

			try
			{
                // �� 20070125 18322 c MA.NS�p�ɕύX
				//// �ԓ����쐬����
				//status = this._depsitMainDB.RedCreate(mode, EnterpriseCode, DepositCd, UpdateSecCd, DepositAgentCode, AddUpADate, DepositSlipNo, out RetDepsitMainWorkListByte, out RetDepositAlwWorkListByte);

				// �ԓ����쐬����
				status = this._depsitMainDB.RedCreate( mode
                                                     , EnterpriseCode
                                                     , DepositCd
                                                     , UpdateSecCd
                                                     , DepositAgentCode
                                                     , DepositAgentNm
                                                     , AddUpADate
                                                     , DepositSlipNo
                                                     , out RetDepsitMainWorkListByte
                                                     , out RetDepositAlwWorkListByte);
                // �� 20070125 18322 c
				if (status == 0)
				{
					
					RetDepsitMainWorkList = (DepsitMainWork[])XmlByteSerializer.Deserialize(RetDepsitMainWorkListByte,typeof(DepsitMainWork[]));
					RetDepositAlwWorkList = (DepositAlwWork[])XmlByteSerializer.Deserialize(RetDepositAlwWorkListByte,typeof(DepositAlwWork[]));

				}
			}
			catch (Exception ex)
			{
				//�I�t���C������null���Z�b�g
				this._depsitMainDB = null;
				//�ʐM�G���[��-1��߂�
				status = -1;

				errmsg = ex.Message;
			}

			return status;

		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman�p�ɕύX

        // �� 20070518 18322 d �e�X�g�p�̃��W���[���Ȃ̂ō폜
        #region ��������Ǎ�����(��)
        // �� 20070124 18322 c MA.NS�p�ɕύX
        /////// <summary>
        /////// ��������Ǎ�����(��)
        /////// </summary>
        ////public int ReadDmdSalesDB(string EnterpriseCode, int ClaimCode, out DmdSalesWork[] dmdSalesWorkList, out string errmsg)
        //
        ///// <summary>
        ///// ��������Ǎ�����(��)
        ///// </summary>
        //public int ReadDmdSalesDB(string EnterpriseCode, int ClaimCode, out SalesSlipWork[] dmdSalesWorkList, out string errmsg)
        //// �� 20070124 18322 c
        //{
        //
        //	byte[] dmdSalesWorkListByte = null;
        //
        //	dmdSalesWorkList = null;
        //	errmsg = "";
        //
        //	int status = 0;
        //	try
        //	{
        //		// ��������}�X�^�f�[�^�Ǎ���
        //		status = this._depsitMainDB.ReadDmdSalesRec(EnterpriseCode, ClaimCode, out dmdSalesWorkListByte);
        //		if (status == 0)
        //		{
        //            // �� 20070125 18322 c MA.NS�p�ɕύX�iMA.NS�ł͐�������̕ς��ɔ���f�[�^���g�p�j
        //			//dmdSalesWorkList = (DmdSalesWork[])XmlByteSerializer.Deserialize(dmdSalesWorkListByte,typeof(DmdSalesWork[]));
        //	
        //			dmdSalesWorkList = (SalesSlipWork[])XmlByteSerializer.Deserialize(dmdSalesWorkListByte,typeof(SalesSlipWork[]));
        //            // �� 20070125 18322 c
        //		}
        //	}
        //	catch (Exception ex)
        //	{
        //		//�I�t���C������null���Z�b�g
        //		this._depsitMainDB = null;
        //		//�ʐM�G���[��-1��߂�
        //		status = -1;
        //	
        //		errmsg = ex.Message;
        //	}
        //	
        //	return status;
        //}
        #endregion
        // �� 20070518 18322 d

    }
}
