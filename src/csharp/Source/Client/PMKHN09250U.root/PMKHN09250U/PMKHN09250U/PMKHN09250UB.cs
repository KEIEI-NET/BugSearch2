using System;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ����ڕW�ݒ�p�t�H�[���R���g���[���N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ����ڕW�ݒ�p�̃t�H�[���R���g���[������N���X</br>
	/// <br>Programmer : 30414 �E �K�j</br>
	/// <br>Date       : 2008/10/08</br>
	/// <br></br>
	/// <br>UpdateNote : </br>
	/// </remarks>
	internal class FormControlInfo_InventInput
	{
		# region Constructor
		/// <summary>
		/// ����ڕW�ݒ�p�t�H�[���R���g���[���N���X�R���X�g���N�^
		/// </summary>
		/// <param name="key">���̃v���O�����A�C�e����Unique��ID</param>
		/// <param name="assemblyId">���̃v���O�����A�C�e���̃A�Z���u��ID</param>
		/// <param name="classId">���̃v���O�����A�C�e���̃N���XID</param>
		/// <param name="name">���̃v���O�����̖���</param>
		/// <param name="icon">���̃v���O�����̃A�C�R��</param>
		/// <remarks>
		/// <br>Note       : ����ڕW�ݒ�p�t�H�[���R���g���[���N���X�̐V�����C���X�^���X������������</br>
		/// <br>Programmer : 30414 �E �K�j</br>
		/// <br>Date       : 2008/10/08</br>
		/// <br></br>
		/// <br>UpdateNote : </br>
		/// </remarks>
		public FormControlInfo_InventInput(string key, string assemblyId, string classId, string name, object icon)
		{
			this._key = key;
			this._assemblyID = assemblyId;
			this._classID = classId;
			this._name = name;
			this._icon = icon as System.Drawing.Image;
			this._form = null;
		}
		# endregion

		# region Private Members
		private string _key;
		private string _assemblyID;
		private string _classID;
		private string _name;
		private System.Drawing.Image _icon;
		private Form _form;
		# endregion

		# region Properties
		/// <summary>�L�[�v���p�e�B</summary>
		/// <value>���̃v���O�����A�C�e���̃L�[���擾�܂��͐ݒ肷��</value>
		public string Key
		{
			get{ return _key; }
			set{ _key = value; }
		}

		/// <summary>�A�Z���u��ID�v���p�e�B</summary>
		/// <value>���̃v���O�����A�C�e���̃A�Z���u�����̂��擾�܂��͐ݒ肷��</value>
		public string AssemblyID
		{
			get{ return _assemblyID; }
			set{ _assemblyID = value; }
		}

		/// <summary>�N���XID�v���p�e�B</summary>
		/// <value>���̃v���O�����A�C�e���̃N���X�������̂��擾�܂��͐ݒ肷��</value>
		public string ClassID
		{
			get{ return _classID; }
			set{ _classID = value; }
		}

		/// <summary>�v���O�������̃v���p�e�B</summary>
		/// <value>���̃v���O�����̖��̂��擾�܂��͐ݒ肷��</value>
		public string Name
		{
			get{ return _name; }
			set{ _name = value; }
		}

		/// <summary>�A�C�R���v���p�e�B</summary>
		/// <value>�A�C�R�����擾�܂��͐ݒ肷��</value>
		public System.Drawing.Image Icon
		{
			get{ return _icon; }
			set{ _icon = value; }
		}

		/// <summary>�I���q��ʃI�u�W�F�N�g�v���p�e�B</summary>
		/// <value>Form�^�ɃL���X�g�����ʃA�Z���u���̃t�H�[���I�u�W�F�N�g���擾�܂��͐ݒ肷��</value>
		public System.Windows.Forms.Form Form
		{
			get{ return _form; }
			set{ _form = value; }
		}
		# endregion
	}
}
