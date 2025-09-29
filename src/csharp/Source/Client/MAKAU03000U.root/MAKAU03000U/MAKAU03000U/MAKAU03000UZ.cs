//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �������[�p�t�H�[���R���g���[���N���X
// �v���O�����T�v   : �������[�p�t�H�[���R���g���[���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright 2022 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570183-00   �쐬�S�� : ���O
// �� �� ��  2022/03/07    �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �������[�p�t�H�[���R���g���[���N���X
	/// </summary>
	/// <remarks>
    /// <br>Note        : �������[�t���[���ɂċN������t�H�[�����R���g���[������N���X�ł��B</br>
    /// <br>Programmer  : ���O</br>
    /// <br>Date        : 2022/03/07</br>
	/// <br></br>
	/// </remarks>
	internal class FormControlInfo
	{
		# region Private Members
		private string _key;
		private string _assemblyID;
		private string _classID;
		private string _name;
		private System.Drawing.Image _icon;
		private Form _form;
		# endregion

		# region Constructor
		/// <summary>
		/// �������[�p�t�H�[���R���g���[���N���X�R���X�g���N�^
		/// </summary>
		/// <param name="key">�N���X�̃L�[���</param>
		/// <param name="assemblyId">�A�Z���u���h�c</param>
		/// <param name="classId">�N���X�h�c</param>
		/// <param name="name">����</param>
		/// <param name="icon">�A�C�R��</param>
		/// <remarks>
        /// <br>Note        : �������[�p�t�H�[���R���g���[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
		/// </remarks>
		public FormControlInfo(string key, string assemblyId, string classId, string name, object icon)
		{
			this._key = key;
			this._assemblyID = assemblyId;
			this._classID = classId;
			this._name = name;
			this._icon = icon as System.Drawing.Image;
			this._form = null;
		}
		# endregion

		# region Properties
		/// <summary>�L�[�v���p�e�B</summary>
		/// <value>���̃v���O�����A�C�e���̃L�[���擾�܂��͐ݒ肵�܂��B</value>
		public string Key
		{
			get{ return _key; }
			set{ _key = value; }
		}

		/// <summary>�A�Z���u��ID�v���p�e�B</summary>
		/// <value>���̃v���O�����A�C�e���̃A�Z���u�����̂��擾�܂��͐ݒ肵�܂��B</value>
		public string AssemblyID
		{
			get{ return _assemblyID; }
			set{ _assemblyID = value; }
		}

		/// <summary>�N���XID�v���p�e�B</summary>
		/// <value>���̃v���O�����A�C�e���̃N���X�������̂��擾�܂��͐ݒ肵�܂��B</value>
		public string ClassID
		{
			get{ return _classID; }
			set{ _classID = value; }
		}

		/// <summary>�v���O�������̃v���p�e�B</summary>
		/// <value>���̃v���O�����̖��̂��擾�܂��͐ݒ肵�܂��B</value>
		public string Name
		{
			get{ return _name; }
			set{ _name = value; }
		}

		/// <summary>�A�C�R���v���p�e�B</summary>
		/// <value>�A�C�R�����擾�܂��͐ݒ肵�܂��B</value>
		public System.Drawing.Image Icon
		{
			get{ return _icon; }
			set{ _icon = value; }
		}

		/// <summary>CS�G���g���q�t�H�[���I�u�W�F�N�g�v���p�e�B</summary>
		/// <value>Form�^�ɃL���X�g�����ʃA�Z���u���̃t�H�[���I�u�W�F�N�g���擾�܂��͐ݒ肵�܂��B</value>
		public System.Windows.Forms.Form Form
		{
			get{ return _form; }
			set{ _form = value; }
		}
		# endregion
	}
}