using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// SFCMN00221UL �̊T�v�̐����ł��B
	/// </summary>
	internal class SFCMN00221UL : System.Windows.Forms.UserControl
	{
		# region Components
		private Infragistics.Win.Misc.UltraLabel uLabel_Title2;
		private Infragistics.Win.Misc.UltraLabel uLabel_Title1;
		private System.ComponentModel.IContainer components = null;
		# endregion

		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructor
		/// <summary>
		/// ���o���t�H�[���N���X�R���X�g���N�^
		/// </summary>
		public SFCMN00221UL()
		{
			InitializeComponent();
		}
		# endregion

		// ===================================================================================== //
		// �j������
		// ===================================================================================== //
		# region Dispose
		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		# endregion

		// ===================================================================================== //
		// �R���|�[�l���g �f�U�C�i �f�U�C�i�ō쐬���ꂽ�R�[�h
		// ===================================================================================== //
		#region �R���|�[�l���g �f�U�C�i �f�U�C�i�ō쐬���ꂽ�R�[�h
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			this.uLabel_Title2 = new Infragistics.Win.Misc.UltraLabel();
			this.uLabel_Title1 = new Infragistics.Win.Misc.UltraLabel();
			this.SuspendLayout();
			// 
			// uLabel_Title2
			// 
			appearance1.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance1.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.uLabel_Title2.Appearance = appearance1;
			this.uLabel_Title2.BackColor = System.Drawing.Color.Transparent;
			this.uLabel_Title2.Dock = System.Windows.Forms.DockStyle.Top;
			this.uLabel_Title2.Location = new System.Drawing.Point(0, 18);
			this.uLabel_Title2.Name = "uLabel_Title2";
			this.uLabel_Title2.Size = new System.Drawing.Size(250, 18);
			this.uLabel_Title2.TabIndex = 5;
			this.uLabel_Title2.Text = "���΂炭���҂��������B";
			// 
			// uLabel_Title1
			// 
			appearance2.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance2.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.uLabel_Title1.Appearance = appearance2;
			this.uLabel_Title1.BackColor = System.Drawing.Color.Transparent;
			this.uLabel_Title1.Dock = System.Windows.Forms.DockStyle.Top;
			this.uLabel_Title1.Location = new System.Drawing.Point(0, 0);
			this.uLabel_Title1.Name = "uLabel_Title1";
			this.uLabel_Title1.Size = new System.Drawing.Size(250, 18);
			this.uLabel_Title1.TabIndex = 4;
			this.uLabel_Title1.Text = "���݁A�������𒊏o���ł��B";
			// 
			// SFCMN00221UL
			// 
			this.BackColor = System.Drawing.Color.GhostWhite;
			this.Controls.Add(this.uLabel_Title2);
			this.Controls.Add(this.uLabel_Title1);
			this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.Name = "SFCMN00221UL";
			this.Size = new System.Drawing.Size(250, 40);
			this.ResumeLayout(false);

		}
		#endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		private string _dataType = "";
		private int _mode = 0;
		# endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region Properties
		/// <summary>
		/// �f�[�^�^�C�v������
		/// </summary>
		internal string DataType
		{
			set
			{
				this._dataType = value;
				this.uLabel_Title1.Text = "���݁A" + this._dataType + "���𒊏o���ł��B";
				this.uLabel_Title2.Text = "���΂炭���҂��������B";
			}
			get
			{
				return this._dataType;
			}
		}

		/// <summary>
		/// ���[�h�v���p�e�B
		/// </summary>
		internal int mode
		{
			set
			{
				this._mode = value;

				if (this._mode == 0)
				{
					this.uLabel_Title1.Text = "���݁A" + this._dataType + "���𒊏o���ł��B";
					this.uLabel_Title2.Text = "���΂炭���҂��������B";
				}
				else
				{
					this.uLabel_Title1.Text = "�Y������f�[�^��";
					this.uLabel_Title2.Text = "������܂���ł����B";
				}
			}
			get
			{
				return this._mode;
			}
		}
		# endregion
	}
}
