//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d���M�ҏW���ʃN���X
// �v���O�����T�v   : �t�n�d���M�ҏW���ʂ̒�`���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;

namespace Broadleaf.Application.UIData
{
	# region �t�n�d���M�ҏW���ʁi�w�b�_�[�j�N���X
	/// <summary>
	/// �t�n�d���M�ҏW���ʁi�w�b�_�[�j�N���X
	/// </summary>
	public class UoeSndHed
	{
		# region Private Members
		/// <summary>�Ɩ��敪</summary>
		private Int32 _businessCode;

		/// <summary>�ʐM�A�Z���u��ID</summary>
		private string _commAssemblyId;

		/// <summary>UOE������R�[�h</summary>
		private Int32 _uOESupplierCd;

		/// <summary>�t�n�d���M�ҏW�i���ׁj�N���X</summary>
		private List<UoeSndDtl> _uoeSndDtlList;
		# endregion

		# region Properties
		/// <summary>
		/// �Ɩ��敪
		/// </summary>
		public Int32 BusinessCode
		{
			get { return _businessCode; }
			set { _businessCode = value; }
		}

		/// <summary>
		/// �ʐM�A�Z���u��ID
		/// </summary>
		public string CommAssemblyId
		{
			get { return _commAssemblyId; }
			set { _commAssemblyId = value; }
		}

		/// <summary>
		/// UOE������R�[�h
		/// </summary>
		public Int32 UOESupplierCd
		{
			get { return _uOESupplierCd; }
			set { _uOESupplierCd = value; }
		}

		/// <summary>
		/// �t�n�d���M�ҏW���ʁi���ׁj�N���X
		/// </summary>
		public List<UoeSndDtl> UoeSndDtlList
		{
			get { return _uoeSndDtlList; }
			set { _uoeSndDtlList = value; }
		}
		# endregion

		# region Constructors
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public UoeSndHed()
		{
			_commAssemblyId = "";
			_businessCode = 0;
			_uOESupplierCd = 0;
			_uoeSndDtlList = new List<UoeSndDtl>();
		}
		# endregion
	}
	# endregion

	# region �t�n�d���M�ҏW���ʁi���ׁj�N���X
	/// <summary>
	/// �t�n�d���M�ҏW���ʁi���ׁj�N���X
	/// </summary>
	public class UoeSndDtl
	{
		# region Private Members
		/// <summary>�����񓚔ԍ�</summary>
		private Int32 _uOESalesOrderNo;

		/// <summary>�����񓚍s�ԍ�</summary>
		private List<Int32> _lINENO;

		/// <summary>���M�d��(JIS)</summary>
		private Byte[] _sndTelegram;

        /// <summary>���M�d���T�C�Y</summary>
        private Int32 _sndTelegramLen;

		# endregion

		# region Properties
		/// <summary>
		/// �����񓚔ԍ�
		/// </summary>
		public Int32 UOESalesOrderNo
		{
			get { return _uOESalesOrderNo; }
			set { _uOESalesOrderNo = value; }
		}

		/// <summary>
		/// �����񓚍s�ԍ�
		/// </summary>
		public List<Int32> UOESalesOrderRowNo
		{
			get { return _lINENO; }
			set { _lINENO = value; }
		}

		/// <summary>
		/// ���M�d��
		/// </summary>
		public Byte[] SndTelegram
		{
			get { return _sndTelegram; }
			set { _sndTelegram = value; }
		}
		# endregion

        /// <summary>
        /// ���M�d���T�C�Y
        /// </summary>
        public Int32 SndTelegramLen
        {
            get { return _sndTelegramLen; }
            set { _sndTelegramLen = value; }
        }

		# region Constructors
		public UoeSndDtl()
		{
			_uOESalesOrderNo = 0;
			_lINENO = new List<int>();
			_sndTelegram = new byte[2048];
            _sndTelegramLen = 0;
		}
		# endregion

	}
	# endregion
}
