using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.UIData;


namespace Broadleaf.Windows.Forms
{

	/// <summary>
	/// ��\����ԃN���X�g��
	/// </summary>
	/// <remarks>
	/// <br>Note       : ��\����ԃN���X�̊g���N���X�ł��B</br>
	/// <br>Programmer : 21024 ���X�� ��</br>
	/// <br>Date       : 2008.05.21</br>
	/// </remarks>
	[Serializable]
	public class ColDisplayStatusExp : ColDisplayStatus
	{

		#region Private Members

		private bool _readOnly = true;
		private bool _visible = false;
		private bool _enterStop = false;

		#endregion

		#region Constructor
		/// <summary>
		/// �f�t�H���g�R���X�g���N�^
		/// </summary>
		public ColDisplayStatusExp()
			: base()
		{

		}

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <param name="key"></param>
		/// <param name="visiblePosition"></param>
		/// <param name="headerFixed"></param>
		/// <param name="width"></param>
		/// <param name="readOnly"></param>
		/// <param name="visible"></param>
		/// <param name="enterStop"></param>
		public ColDisplayStatusExp( string key, Int32 visiblePosition, bool headerFixed, Int32 width, bool readOnly, bool visible, bool enterStop )
			: base(key, visiblePosition, headerFixed, width)
		{
			_visible = visible;
			_enterStop = enterStop;
			_readOnly = readOnly;
		}
		#endregion

		#region Property
		/// <summary>
		/// ��\���v���p�e�B
		/// </summary>
		public bool Visible
		{
			get { return _visible; }
			set { _visible = value; }
		}
		/// <summary>
		/// Enter�L�[�ړ��v���p�e�B
		/// </summary>
		public bool EnterStop
		{
			get { return _enterStop; }
			set { _enterStop = value; }
		}
		/// <summary>
		/// ����Ώۃv���p�e�B
		/// </summary>
		public bool ReadOnly
		{
			get { return _readOnly; }
			set { _readOnly = value; }
		}
		#endregion

	}

}

