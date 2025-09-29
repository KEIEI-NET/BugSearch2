//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d��M���ʃN���X
// �v���O�����T�v   : �t�n�d��M���ʂ̒�`
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
	# region �t�n�d��M���ʁi�w�b�_�[�j�N���X
	/// <summary>
	/// �t�n�d��M���ʁi�w�b�_�[�j�N���X
	/// </summary>
	public class UoeRecHed
	{
		# region Private Members
		/// <summary>�Ɩ��敪</summary>
		private Int32 _businessCode;

		//�ʐM�A�Z���u��ID
		private string _commAssemblyId;

		//UOE������R�[�h
		private Int32 _uOESupplierCd;

		/// <summary>�t�n�d��M���ʁi���ׁj�N���X</summary>
		private List<UoeRecDtl> _uoeRecDtlList;
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
		/// �t�n�d��M�ҏW���ʁi���ׁj�N���X
		/// </summary>
		public List<UoeRecDtl> UoeRecDtlList
		{
			get { return _uoeRecDtlList; }
			set { _uoeRecDtlList = value; }
		}
		# endregion

		# region Constructors
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public UoeRecHed()
		{
			_commAssemblyId = "";
			_uOESupplierCd = 0;
			_uoeRecDtlList = new List<UoeRecDtl>();
		}
		# endregion
	}
	# endregion

	# region �t�n�d��M���ʁi���ׁj�N���X
	/// <summary>
	/// �t�n�d��M���ʁi���ׁj�N���X
	/// </summary>
	public class UoeRecDtl
	{
		# region Private Members
		/// <summary>�����񓚔ԍ�</summary>
		private Int32 _uOESalesOrderNo;

		/// <summary>�����񓚍s�ԍ�</summary>
		private List<Int32> _lINENO;

		/// <summary>��M�d��(JIS)</summary>
		private Byte[] _recTelegram;

        /// <summary>���M�d���T�C�Y</summary>
        private Int32 _recTelegramLen;

		/// <summary>�f�[�^���M�敪</summary>
		private Int32 _dataSendCode;

		/// <summary>�f�[�^�����敪</summary>
		private Int32 _dataRecoverDiv;

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
		/// ��M�d��
		/// </summary>
		public Byte[] RecTelegram
		{
			get { return _recTelegram; }
			set { _recTelegram = value; }
		}

        /// <summary>
        /// ��M�d���T�C�Y
        /// </summary>
        public Int32 RecTelegramLen
        {
            get { return _recTelegramLen; }
            set { _recTelegramLen = value; }
        }

		/// <summary>
		/// �f�[�^���M�敪
		/// </summary>
		public Int32 DataSendCode
		{
			get { return _dataSendCode; }
			set { _dataSendCode = value; }
		}

		/// <summary>
		/// �f�[�^�����敪
		/// </summary>
		public Int32 DataRecoverDiv
		{
			get { return _dataRecoverDiv; }
			set { _dataRecoverDiv = value; }
		}


		# endregion

		# region Constructors
		public UoeRecDtl()
		{
			_uOESalesOrderNo = 0;
			_lINENO = new List<int>();
			_recTelegram = new byte[2048];
			_dataSendCode = 0;
			_dataRecoverDiv = 0;
            _recTelegramLen = 0;
		}
		# endregion

	}
	# endregion
}
