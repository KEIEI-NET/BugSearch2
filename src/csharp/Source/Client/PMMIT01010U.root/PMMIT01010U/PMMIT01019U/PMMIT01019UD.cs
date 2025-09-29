using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	[Serializable]
	/// <summary>
	/// �w�b�_�[���t�H�[�J�X�ړ��ݒ胊�X�g�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �w�b�_�[���̃t�H�[�J�X�ړ����Ǘ����郊�X�g�N���X�ł��B</br>
	/// <br>Programmer : 20056 ���n ���</br>
	/// <br>Date       : 2007.11.06</br>
	/// <br></br>
	/// </remarks>
	public class HeaderFocusConstructionList
	{
		public List<HeaderFocusConstruction> headerFocusConstruction = new List<HeaderFocusConstruction>();
	}

	/// <summary>
	/// �w�b�_�[���t�H�[�J�X�ړ��ݒ�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �w�b�_�[���̃t�H�[�J�X�ړ����Ǘ�����N���X�ł��B</br>
	/// <br>Programmer : 20056 ���n ���</br>
	/// <br>Date       : 2007.11.06</br>
	/// <br></br>
	/// </remarks>
	[Serializable]
	public class HeaderFocusConstruction
	{
		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		private string _key;
		private string _caption;
		private bool _enterStop;
		# endregion

		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructors
		/// <summary>
		/// �w�b�_�[���t�H�[�J�X�ړ��ݒ�N���X
		/// </summary>
		/// <remarks>
		/// <br>Note       : �w�b�_�[���t�H�[�J�X�ړ��ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 20056 ���n ���</br>
		/// <br>Date       : 2007.11.06</br>
		/// </remarks>
		public HeaderFocusConstruction()
		{
			this._key = string.Empty;
			this._caption = string.Empty;
			this._enterStop = true;
		}
		# endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region Properties
		/// <summary>�L�[</summary>
		public string Key
		{
			get { return this._key; }
			set { this._key = value; }
		}
		/// <summary>���ڕ\������</summary>
		public string Caption
		{
			get { return this._caption; }
			set { this._caption = value; }
		}
		/// <summary>�ړ��L��</summary>
		public bool EnterStop
		{
			get { return this._enterStop; }
			set { this._enterStop = value; }
		}
		# endregion
	}
}
