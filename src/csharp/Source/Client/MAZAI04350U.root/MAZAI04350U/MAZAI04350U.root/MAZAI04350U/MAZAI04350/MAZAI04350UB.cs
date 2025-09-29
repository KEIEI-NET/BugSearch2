using System;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �d���`�[���̓t�H�[���R���g���[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �d���`�[���̓t�H�[���ɂċN������t�H�[�����R���g���[������N���X�ł��B</br>
	/// <br>Programmer : 21027 �{��  ���u�Y</br>
	/// <br>Date       : 2006.05.30</br>
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
		private string _nextForm;
		private string _beforeForm;
		# endregion

		# region Constructor
		/// <summary>
		/// �d���`�[���̓t�H�[���R���g���[���N���X�R���X�g���N�^
		/// </summary>
		/// <param name="key">�N���X�̃L�[���</param>
		/// <param name="assemblyId">�A�Z���u���h�c</param>
		/// <param name="classId">�N���X�h�c</param>
		/// <param name="name">����</param>
		/// <param name="icon">�A�C�R��</param>
		/// <param name="nextForm">���̃t�H�[���h�c</param>
		/// <param name="beforeForm">�O�̃t�H�[���h�c</param>
		/// <remarks>
		/// <br>Note       : �d���`�[���̓t�H�[���R���g���[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		public FormControlInfo(string key, string assemblyId, string classId, string name, object icon, string nextForm, string beforeForm)
		{
			this._key = key;
			this._assemblyID = assemblyId;
			this._classID = classId;
			this._name = name;
			this._icon = icon as System.Drawing.Image;
			this._form = null;
			this._nextForm = nextForm;
			this._beforeForm = beforeForm;
		}
		# endregion

		# region Properties
		/// <summary>�L�[�v���p�e�B</summary>
		/// <value>���̃v���O�����A�C�e���̃L�[���擾�܂��͐ݒ肵�܂��B</value>
		public string Key
		{
			get { return _key; }
			set { _key = value; }
		}

		/// <summary>�A�Z���u��ID�v���p�e�B</summary>
		/// <value>���̃v���O�����A�C�e���̃A�Z���u�����̂��擾�܂��͐ݒ肵�܂��B</value>
		public string AssemblyID
		{
			get { return _assemblyID; }
			set { _assemblyID = value; }
		}

		/// <summary>�N���XID�v���p�e�B</summary>
		/// <value>���̃v���O�����A�C�e���̃N���X�������̂��擾�܂��͐ݒ肵�܂��B</value>
		public string ClassID
		{
			get { return _classID; }
			set { _classID = value; }
		}

		/// <summary>�v���O�������̃v���p�e�B</summary>
		/// <value>���̃v���O�����̖��̂��擾�܂��͐ݒ肵�܂��B</value>
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		/// <summary>�A�C�R���v���p�e�B</summary>
		/// <value>�A�C�R�����擾�܂��͐ݒ肵�܂��B</value>
		public System.Drawing.Image Icon
		{
			get { return _icon; }
			set { _icon = value; }
		}

		/// <summary>CS�G���g���q�t�H�[���I�u�W�F�N�g�v���p�e�B</summary>
		/// <value>Form�^�ɃL���X�g�����ʃA�Z���u���̃t�H�[���I�u�W�F�N�g���擾�܂��͐ݒ肵�܂��B</value>
		public System.Windows.Forms.Form Form
		{
			get { return _form; }
			set { _form = value; }
		}

		/// <summary>���̃t�H�[���h�c�i�N���X�h�c�j�v���p�e�B</summary>
		/// <value>���g�̎��ɕ\�������t�H�[���h�c���擾�܂��͐ݒ肵�܂��B</value>
		public string NextForm
		{
			get { return _nextForm; }
			set { _nextForm = value; }
		}

		/// <summary>�O�̃t�H�[���h�c�i�N���X�h�c�j�v���p�e�B</summary>
		/// <value>���g�̑O�ɕ\�������t�H�[���h�c���擾�܂��͐ݒ肵�܂��B</value>
		public string BeforeForm
		{
			get { return _beforeForm; }
			set { _beforeForm = value; }
		}
		# endregion

		# region Internal Methods
		# endregion
	}
}