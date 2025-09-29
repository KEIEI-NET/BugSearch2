using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ARCtrlPropertyDispInfo
	/// <summary>
	///                      ���R���[�v���p�e�B�\�����
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���R���[�v���p�e�B�\�����w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2007/06/04</br>
	/// <br>Genarated Date   :   2007/08/01  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class ARCtrlPropertyDispInfo
	{
		/// <summary>ActiveReport�R���g���[���^�C�v����</summary>
		private string _aRControlTypeName = "";

		/// <summary>�v���p�e�B����</summary>
		private string _propertyName = "";

		/// <summary>�\���t���O</summary>
		private Int32 _canDisplay;

		/// <summary>�ҏW�敪</summary>
		private Int32 _editDivCode;

		/// <summary>�\������</summary>
		/// <remarks>�K�C�h���ɕ\�����閼��</remarks>
		private string _displayName = "";

		/// <summary>���[�U�[�Ǘ��҃t���O</summary>
		/// <remarks>0:���,1:���[�U�[�Ǘ���</remarks>
		private Int32 _userAdminFlag;


		/// public propaty name  :  ARControlTypeName
		/// <summary>ActiveReport�R���g���[���^�C�v���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ActiveReport�R���g���[���^�C�v���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ARControlTypeName
		{
			get { return _aRControlTypeName; }
			set { _aRControlTypeName = value; }
		}

		/// public propaty name  :  PropertyName
		/// <summary>�v���p�e�B���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v���p�e�B���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PropertyName
		{
			get { return _propertyName; }
			set { _propertyName = value; }
		}

		/// public propaty name  :  CanDisplay
		/// <summary>�\���t���O�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �\���t���O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CanDisplay
		{
			get { return _canDisplay; }
			set { _canDisplay = value; }
		}

		/// public propaty name  :  EditDivCode
		/// <summary>�ҏW�敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ҏW�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EditDivCode
		{
			get { return _editDivCode; }
			set { _editDivCode = value; }
		}

		/// public propaty name  :  DisplayName
		/// <summary>�\�����̃v���p�e�B</summary>
		/// <value>�K�C�h���ɕ\�����閼��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �\�����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DisplayName
		{
			get { return _displayName; }
			set { _displayName = value; }
		}

		/// public propaty name  :  UserAdminFlag
		/// <summary>���[�U�[�Ǘ��҃t���O�v���p�e�B</summary>
		/// <value>0:���,1:���[�U�[�Ǘ���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�U�[�Ǘ��҃t���O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UserAdminFlag
		{
			get { return _userAdminFlag; }
			set { _userAdminFlag = value; }
		}


		/// <summary>
		/// ���R���[�v���p�e�B�\�����R���X�g���N�^
		/// </summary>
		/// <returns>ARCtrlPropertyDispInfo�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ARCtrlPropertyDispInfo�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ARCtrlPropertyDispInfo()
		{
		}

	}
}
