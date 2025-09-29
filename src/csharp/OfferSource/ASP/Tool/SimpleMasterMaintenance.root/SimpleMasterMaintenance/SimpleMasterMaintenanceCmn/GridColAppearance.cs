using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �O���b�h��O�ϐݒ�N���X
	/// </summary>
	public class GridColAppearance
	{
		#region << Constructor >>

		/// <summary>
		/// �O���b�h��O�ϐݒ�N���X�R���X�g���N�^
		/// </summary>
		public GridColAppearance()
		{
		}

		/// <summary>
		/// �O���b�h��O�ϐݒ�N���X�R���X�g���N�^
		/// </summary>
		/// <param name="displayIndex">�\���C���f�b�N�X</param>
		/// <param name="caption">�L���v�V����</param>
		/// <param name="alignment">�Z���̓��e�̕\���ʒu</param>
		/// <param name="format">�Z���ɓK�p���鏑���w�蕶����</param>
		/// <param name="foreColor">�Z���̑O�i�F</param>
		/// <param name="selectionForeColor">�I�����̃Z���̑O�i�F</param>
		public GridColAppearance( int displayIndex, string caption, DataGridViewContentAlignment alignment, string format, Color foreColor, Color selectionForeColor )
		{
			this._displayIndex       = displayIndex;
			this._caption            = caption;
			this._alignment          = alignment;
			this._format             = format;
			this._foreColor          = foreColor;
			this._selectionForeColor = selectionForeColor;
		}

		#endregion

		#region << Private Members >>

		/// <summary>�\���C���f�b�N�X</summary>
		private int                          _displayIndex       = 0;

		/// <summary>�L���v�V����</summary>
		private string                       _caption            = String.Empty;

		/// <summary>�Z���̓��e�̕\���ʒu</summary>
		private DataGridViewContentAlignment _alignment          = DataGridViewContentAlignment.NotSet;

		/// <summary>�Z���ɓK�p���鏑���w�蕶����</summary>
		private string                       _format             = String.Empty;

		/// <summary>�Z���̑O�i�F</summary>
		private Color                        _foreColor          = Color.Empty;

		/// <summary>�I�����̃Z���̑O�i�F</summary>
		private Color                        _selectionForeColor = Color.Empty;

		#endregion

		#region << Public Properties >>

		/// <summary>
		/// �\���C���f�b�N�X
		/// </summary>
		public int DisplayIndex
		{
			get {
				return this._displayIndex;
			}
			set {
				this._displayIndex = value;
			}
		}

		/// <summary>
		/// �L���v�V����
		/// </summary>
		public string Caption
		{
			get {
				return this._caption;
			}
			set {
				this._caption = value;
			}
		}

		/// <summary>
		/// �Z���̓��e�̕\���ʒu�v���p�e�B
		/// </summary>
		public DataGridViewContentAlignment Alignment
		{
			get {
				return this._alignment;
			}
			set {
				this._alignment = value;
			}
		}

		/// <summary>
		/// �Z���ɓK�p���鏑���w�蕶����v���p�e�B
		/// </summary>
		public string Format
		{
			get {
				return this._format;
			}
			set {
				this._format = value;
			}
		}

		/// <summary>
		/// �Z���̑O�i�F�v���p�e�B
		/// </summary>
		public Color ForeColor
		{
			get {
				return this._foreColor;
			}
			set {
				this._foreColor = value;
			}
		}

		/// <summary>
		/// �I�����̃Z���̑O�i�F�v���p�e�B
		/// </summary>
		public Color SelectionForeColor
		{
			get {
				return this._selectionForeColor;
			}
			set {
				this._selectionForeColor = value;
			}
		}

		#endregion
	}
}
