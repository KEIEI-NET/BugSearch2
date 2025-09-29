using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���̑��p�t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̑��p�^�[���̃}�X�^�����e�i���X��\�����܂��B</br>
	/// <br>Programmer : 980076 �Ȓ��@����Y</br>
	/// <br>Date       : 2004.03.19</br>
	/// <br></br>
	/// </remarks>
	public class SFCMN09000UF : System.Windows.Forms.Form
	{
		# region Private Members (Component)
		private System.ComponentModel.IContainer components = null;
		# endregion

		# region Constructor
		/// <summary>
		/// ���̑��p�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �P�[�\���t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public SFCMN09000UF()
		{
			InitializeComponent();
		}
		# endregion

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

		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// SFCMN09000UF
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
			this.BackColor = System.Drawing.Color.GhostWhite;
			this.ClientSize = new System.Drawing.Size(759, 670);
			this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "SFCMN09000UF";
			this.Text = "SFCMN09000UF";

		}
		#endregion

		# region Private Members
		private SFCMN09000UA _owningForm;
		private Form _otherTypeObj;
		private ProgramItem _programItemObj;
		# endregion

		# region Internal Methods
		/// <summary>
		/// ��ʕ\������
		/// </summary>
		/// <param name="owningForm">�e�t�H�[���̃C���X�^���X</param>
		/// <param name="programItemObj">�v���O�������Ǘ��N���X�̃C���X�^���X</param>
		/// <remarks>
		/// <br>Note       : �e�t�H�[���̃C���X�^���X���󂯎��A���g�̃t�H�[�������[�h���X�ŕ\�����܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		internal void ShowMe(SFCMN09000UA owningForm, ProgramItem programItemObj)
		{
			this._owningForm = owningForm;
			this._programItemObj = programItemObj;
			this._otherTypeObj = (Form)programItemObj.CustomForm;
			this.Show();

			this.Font = this._otherTypeObj.Font;

			this._otherTypeObj.TopLevel = false;
			this._otherTypeObj.FormBorderStyle = FormBorderStyle.None;
			this._otherTypeObj.Show();
			this.Controls.Add(this._otherTypeObj);
			this._otherTypeObj.Dock = System.Windows.Forms.DockStyle.Fill;

			this._otherTypeObj.Closed +=new EventHandler(OtherTypeObj_Closed);
		}
		# endregion

		# region Control Events
		/// <summary>
		/// Closed�C�x���g�p���\�b�h
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		/// <remarks>
		/// <br>Note       : �e�t�H�[���̃C���X�^���X���󂯎��A���g�̃t�H�[�������[�h���X�ŕ\�����܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public void OtherTypeObj_Closed(object sender, EventArgs e)
		{
			this.Close();
		}
		# endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/10 ADD
        /// <summary>
        /// �e�^�u���A�N�e�B�u�ɂȂ����ꍇ�̃t�H�[�J�X����
        /// </summary>
        public void SetFocusOnParentTabActive()
        {
            this.Focus();
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/10 ADD
	}
}
