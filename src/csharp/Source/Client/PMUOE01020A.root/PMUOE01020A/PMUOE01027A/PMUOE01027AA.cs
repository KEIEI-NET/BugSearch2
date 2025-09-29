//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d��M�ҏW�i�D�ǁj�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d��M�ҏW�i�D�ǁj���s��
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
	/// �t�n�d��M�ҏW�i�D�ǁj�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d��M�ҏW�i�D�ǁj�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
	/// </remarks>
	public partial class UoeRecEdit1001Acs
	{
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructors
		public UoeRecEdit1001Acs()
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

		//�t�n�d������}�X�^
		UOESupplier _uOESupplier = null;

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
																// ����  ����  ����  �݌�
		private const string MSG_TRA = "��ݻ޸��ݴװ"	   ;	// 0x11  0xf1  0xf1  0xf1
		private const string MSG_UCD = "�����Ϻ��޴װ"     ;	// 0x12  0xf7  0xf7
		private const string MSG_PAS = "�߽ܰ�޴װ"        ;	// 0x14
		private const string MSG_RUS = "ٽ��ݴװ"          ;	// 0x88
		private const string MSG_ELS = "����װ"            ;	// 0x99
		private const string MSG_HEN = "�ݼ��ް�ż"        ;	//       0xf2
		private const string MSG_NOU = "ɳ�ݺ���ż"        ;	//       0xf3
		private const string MSG_DAT = "�ް�ż"            ;	//       0xf4  0xf4  0xf4
		private const string MSG_STK = "�ò���ݴװ"        ;	//       0xf5
		private const string MSG_KUF = "�����ر��̶"       ;	//       0xc3
		private const string MSG_HTA = "ʯ�����ĳ���װ"    ;	//       0xc4
		private const string MSG_FNC = "̫۰ɰ�ݺ���ż"    ;	//       0xc5
		private const string MSG_KOC = "���������Ϻ��޴װ" ;	//       0xc6
		private const string MSG_RTE = "ڰĴװ"            ;	//             0xc1
		private const string MSG_SCD = "�������޴װ"       ;	//             0xc2
		private const string MSG_SKK = "���ݷ��ݴװ"       ;	//             0xc3

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

		# region �t�n�d��M�ҏW���������i�D�ǁj
		/// <summary>
		/// �t�n�d��M�ҏW���������i�D�ǁj
		/// </summary>
        /// <param name="uoeSndHed">UOE���M�I�u�W�F�N�g</param>
        /// <param name="uoeRecHed">UOE��M�I�u�W�F�N�g</param>
		/// <param name="message">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		public int uoeRecEditOrder1001(UoeSndHed uoeSndHed, UoeRecHed uoeRecHed, out string message)
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
                status = GetJnlOrder1001(out message);
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}

		# endregion

		# region �t�n�d��M�ҏW���݌Ɂ��i�D�ǁj
		/// <summary>
		/// �t�n�d��M�ҏW���݌Ɂ��i�D�ǁj
		/// </summary>
        /// <param name="uoeSndHed">UOE���M�I�u�W�F�N�g</param>
        /// <param name="uoeRecHed">UOE��M�I�u�W�F�N�g</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int uoeRecEditStock1001(UoeSndHed uoeSndHed, UoeRecHed uoeRecHed, out string message)
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
                status = GetJnlStock1001(out message);
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
		# endregion

	}
}
