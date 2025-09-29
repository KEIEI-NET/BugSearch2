//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d��M�ҏW�i���Y�m�p�[�c�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d��M�ҏW�i���Y�m�p�[�c�j���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �t�n�d��M�ҏW�i���Y�m�p�[�c�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d��M�ҏW�i���Y�m�p�[�c�j�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
	/// </remarks>
	public partial class UoeRecEdit0202Acs
	{
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructors
		public UoeRecEdit0202Acs()
		{
			//��ƃR�[�h���擾����
			_enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			//�t�n�d����M�i�m�k�A�N�Z�X�N���X
			_uoeSndRcvJnlAcs = UoeSndRcvJnlAcs.GetInstance();
		}
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		//��ƃR�[�h
		private string _enterpriseCode = "";

		//�t�n�d����M�i�m�k�A�N�Z�X�N���X
		private UoeSndRcvJnlAcs _uoeSndRcvJnlAcs;

		//�t�n�d���M�ҏW�i�w�b�_�[�j
		private UoeSndHed _uoeSndHed = new UoeSndHed();

		//�t�n�d��M�ҏW�i�w�b�_�[�j
		private UoeRecHed _uoeRecHed = new UoeRecHed();
		# endregion

		// ===================================================================================== //
		// �萔
		// ===================================================================================== //
		# region Const Members
		//�w�b�h�G���[���b�Z�[�W
        private const string MSG_TIM = "���޽ �޶����װ" ;	// 0x13
        private const string MSG_STP = "���޽ ò����"    ;	// 0x17
        private const string MSG_DEF = "��� �װ"         ;	// 0x99
		# endregion

		// ===================================================================================== //
		// �f���Q�[�g
		// ===================================================================================== //
		# region Delegate
		# endregion

		// ===================================================================================== //
		// �C�x���g
		// ===================================================================================== //
		# region Event
		# endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region Properties
		# region �t�n�d��M���ʁi�w�b�_�[�j
		/// <summary>
		/// �t�n�d��M�i�w�b�_�[�j
		/// </summary>
		public UoeRecHed uoeRecHed
		{
			get
			{
				return this._uoeRecHed;
			}
			set
			{
				this._uoeRecHed = value;
			}
		}
		# endregion

		# region �t�n�d��M���ʁi���ׁj
		/// <summary>
		/// �t�n�d��M�i���ׁj
		/// </summary>
		public List<UoeRecDtl> uoeRecDtlList
		{
			get
			{
				return this._uoeRecHed.UoeRecDtlList;
			}
			set
			{
				this._uoeRecHed.UoeRecDtlList = value;
			}
		}
		# endregion

		# endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region Public Methods

		# region �t�n�d��M�ҏW���������i���Y�m�p�[�c�j
		/// <summary>
		/// �t�n�d��M�ҏW���������i���Y�m�p�[�c�j
		/// </summary>
        /// <param name="uoeSndHed">UOE���M�I�u�W�F�N�g</param>
        /// <param name="uoeRecHed">UOE��M�I�u�W�F�N�g</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int uoeRecEditOrder0202(UoeSndHed uoeSndHed, UoeRecHed uoeRecHed, out string message)
		{
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
                //-----------------------------------------------------------
                // �ҏW�N���X�̕ۑ�
                //-----------------------------------------------------------
                //�t�n�d���M�ҏW�N���X�̕ۑ�
				_uoeSndHed = uoeSndHed;

				//�t�n�d��M�ҏW�N���X�̕ۑ�
				_uoeRecHed = uoeRecHed;

                //-----------------------------------------------------------
                // ��M�ҏW����
                //-----------------------------------------------------------
    			status = GetJnlOrder0202(out message);
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion

		# region �t�n�d��M�ҏW�����ρ��i���Y�m�p�[�c�j
		/// <summary>
		/// �t�n�d��M�ҏW�����ρ��i���Y�m�p�[�c�j
		/// </summary>
        /// <param name="uoeSndHed">UOE���M�I�u�W�F�N�g</param>
        /// <param name="uoeRecHed">UOE��M�I�u�W�F�N�g</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int uoeRecEditEstmt0202(UoeSndHed uoeSndHed, UoeRecHed uoeRecHed, out string message)
		{
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
                //-----------------------------------------------------------
                // �ҏW�N���X�̕ۑ�
                //-----------------------------------------------------------
                //�t�n�d���M�ҏW�N���X�̕ۑ�
				_uoeSndHed = uoeSndHed;

				//�t�n�d��M�ҏW�N���X�̕ۑ�
				_uoeRecHed = uoeRecHed;

                //-----------------------------------------------------------
                // ��M�ҏW����
                //-----------------------------------------------------------
				status = GetJnlEstmt0202(out message);
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion

		# region �t�n�d��M�ҏW���݌Ɂ��i���Y�m�p�[�c�j
		/// <summary>
		/// �t�n�d��M�ҏW���݌Ɂ��i���Y�m�p�[�c�j
		/// </summary>
        /// <param name="uoeSndHed">UOE���M�I�u�W�F�N�g</param>
        /// <param name="uoeRecHed">UOE��M�I�u�W�F�N�g</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int uoeRecEditStock0202(UoeSndHed uoeSndHed, UoeRecHed uoeRecHed, out string message)
		{
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
                //-----------------------------------------------------------
                // �ҏW�N���X�̕ۑ�
                //-----------------------------------------------------------
                //�t�n�d���M�ҏW�N���X�̕ۑ�
				_uoeSndHed = uoeSndHed;

				//�t�n�d��M�ҏW�N���X�̕ۑ�
				_uoeRecHed = uoeRecHed;

                //-----------------------------------------------------------
                // ��M�ҏW����
                //-----------------------------------------------------------
				status = GetJnlStock0202(out message);
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion

		# endregion
		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods
        # region �w�b�h�G���[���b�Z�[�W�̎擾
        /// <summary>
        /// �w�b�h�G���[���b�Z�[�W�̎擾
        /// </summary>
        /// <param name="cd"></param>
        /// <returns></returns>
        private string GetHeadErrorMassage(byte cd)
        {
            string str = "";


            switch (cd)
            {
                case 0x13:			//���޽ �޶����װ 
                    str = MSG_TIM;
                    break;
                case 0x17:			//���޽ ò����
                    str = MSG_STP;
                    break;
                case 0x99:			//��� �װ
                    str = MSG_DEF;
                    break;
                default:
                    int swk = UoeCommonFnc.ToInt32FromByteNum(cd);
                    str = String.Format("�װ����= 0x{0:x}", swk);
                    break;
            }
            return (str);
        }
        # endregion

		# endregion

	}
}
