using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	///	��\�����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�H�[�J�X����ݒ�O���b�h�p�̃��X�g�A�e�[�u���N���X�ł��B</br>
	/// <br>Programmer : 21024 ���X�� ��</br>
	/// <br>Date       : 2008.05.21</br>
	/// </remarks>
	public class ColDisplayInfo
	{
		#region ��Private Members
		private string _key;
		private int _visiblePosition;
		private bool _fixedCol;
		private string _caption;
		private bool _visible;
		private bool _visibleControl;
		private bool _enterStop;
		private bool _enterStopControl;
		#endregion

		#region ��Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public ColDisplayInfo()
		{
		}

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <param name="key"></param>
		/// <param name="caption"></param>
		/// <param name="visiblePosition"></param>
		/// <param name="fixedcol"></param>
		/// <param name="visible"></param>
		/// <param name="visibleControl"></param>
		/// <param name="enterStop"></param>
		public ColDisplayInfo( string key, string caption, int visiblePosition, bool fixedcol, bool visible, bool visibleControl, bool enterStop, bool enterStopControl )
		{
			this._key = key;
			this._caption = caption;
			this._visiblePosition = visiblePosition;
			this._fixedCol = fixedcol;
			this._visible = visible;
			this._visibleControl = visibleControl;
			this._enterStop = enterStop;
			this._enterStopControl = enterStopControl;
		}
		#endregion

		#region ��Properties
		/// <summary>�L�[</summary>
		public string Key
		{
			get { return this._key; }
			set { this._key = value; }
		}
		/// <summary>�L���v�V����</summary>
		public string Caption
		{
			get { return this._caption; }
			set { this._caption = value; }
		}
		/// <summary>�\���ʒu</summary>
		public int VisiblePosition
		{
			get { return this._visiblePosition; }
			set { this._visiblePosition = value; }
		}
		/// <summary>�Œ��i��������ւ��A�ړ��A�\���̕s��)</summary>
		public bool FixedCol
		{
			get { return this._fixedCol; }
			set { this._fixedCol = value; }
		}
		/// <summary>�\���L��</summary>
		public bool Visible
		{
			get { return this._visible; }
			set { this._visible = value; }
		}
		/// <summary>�ړ��L��</summary>
		public bool EnterStop
		{
			get { return this._enterStop; }
			set { this._enterStop = value; }
		}
		/// <summary>�ړ��ύX��</summary>
		public bool EnterStopControl
		{
			get { return this._enterStopControl; }
			set { this._enterStopControl = value; }
		}

		/// <summary>�\���ύX��</summary>
		public bool VisibleControl
		{
			get { return this._visibleControl; }
			set { this._visibleControl = value; }
		}
		#endregion
		
	}
}
