using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���o���@�ݒ�t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���o���@�ݒ���s���܂��B</br>
	/// <br>Programmer : 980076 �Ȓ��@����Y</br>
	/// <br>Date       : 2004.03.19</br>
	/// <br></br>
	/// </remarks>
	internal class SFCMN09000UD : System.Windows.Forms.Form
	{
		# region Private Members (Component)
		private Infragistics.Win.Misc.UltraButton Decision_Button;
		private Infragistics.Win.Misc.UltraButton Close_Button;
		private Infragistics.Win.UltraWinEditors.UltraOptionSet ExtractionSetUp_OptionSet;

		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;
		# endregion

		# region Constructors
		/// <summary>
		/// ���o���@�ݒ�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���o���@�ݒ�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		internal SFCMN09000UD()
		{
			InitializeComponent();
		}

		/// <summary>
		/// ���o���@�ݒ�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <param name="type">���o���@�ݒ�</param>
		/// <remarks>
		/// <br>Note       : ���o���@�ݒ�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		internal SFCMN09000UD(ExtractionSetUpType type)
		{
			InitializeComponent();

			switch (type)
			{
				case ExtractionSetUpType.SearchAuto:
				{
					this.ExtractionSetUp_OptionSet.CheckedIndex = 0;
					break;
				}
				case ExtractionSetUpType.SearchSpecification:
				{
					this.ExtractionSetUp_OptionSet.CheckedIndex = 1;
					break;
				}
			}
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
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFCMN09000UD));
			this.ExtractionSetUp_OptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
			this.Decision_Button = new Infragistics.Win.Misc.UltraButton();
			this.Close_Button = new Infragistics.Win.Misc.UltraButton();
			((System.ComponentModel.ISupportInitialize)(this.ExtractionSetUp_OptionSet)).BeginInit();
			this.SuspendLayout();
			// 
			// ExtractionSetUp_OptionSet
			// 
			this.ExtractionSetUp_OptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.Etched;
			this.ExtractionSetUp_OptionSet.ItemAppearance = appearance1;
			this.ExtractionSetUp_OptionSet.ItemOrigin = new System.Drawing.Point(5, 5);
			valueListItem1.DataValue = "Default Item";
			valueListItem1.DisplayText = "�S���������o";
			valueListItem2.DataValue = "ValueListItem1";
			valueListItem2.DisplayText = "�����w�蒊�o";
			this.ExtractionSetUp_OptionSet.Items.Add(valueListItem1);
			this.ExtractionSetUp_OptionSet.Items.Add(valueListItem2);
			this.ExtractionSetUp_OptionSet.ItemSpacingVertical = 5;
			this.ExtractionSetUp_OptionSet.Location = new System.Drawing.Point(10, 10);
			this.ExtractionSetUp_OptionSet.Name = "ExtractionSetUp_OptionSet";
			this.ExtractionSetUp_OptionSet.Size = new System.Drawing.Size(210, 60);
			this.ExtractionSetUp_OptionSet.TabIndex = 0;
			// 
			// Decision_Button
			// 
            this.Decision_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.Decision_Button.Location = new System.Drawing.Point(40, 80);
			this.Decision_Button.Name = "Decision_Button";
			this.Decision_Button.Size = new System.Drawing.Size(90, 30);
			this.Decision_Button.TabIndex = 1;
			this.Decision_Button.Text = "�m��(&S)";
			this.Decision_Button.Click += new System.EventHandler(this.Decision_Button_Click);
			// 
			// Close_Button
			// 
            this.Close_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.Close_Button.Location = new System.Drawing.Point(130, 80);
			this.Close_Button.Name = "Close_Button";
			this.Close_Button.Size = new System.Drawing.Size(90, 30);
			this.Close_Button.TabIndex = 2;
			this.Close_Button.Text = "�߂�(&X)";
			this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
			// 
			// SFCMN09000UD
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
			this.BackColor = System.Drawing.Color.GhostWhite;
			this.ClientSize = new System.Drawing.Size(232, 123);
			this.Controls.Add(this.Close_Button);
			this.Controls.Add(this.Decision_Button);
			this.Controls.Add(this.ExtractionSetUp_OptionSet);
			this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "SFCMN09000UD";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "���o���@�ݒ�";
			this.Load += new System.EventHandler(this.SFCMN09000UD_Load);
			((System.ComponentModel.ISupportInitialize)(this.ExtractionSetUp_OptionSet)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		# region Internal Methods
		/// <summary>
		/// ���o���@�ݒ�擾����
		/// </summary>
		/// <returns>���o���@�ݒ�l</returns>
		/// <remarks>
		/// <br>Note       : ��ʂőI�𒆂̒��o���@�ݒ���擾���܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		internal ExtractionSetUpType GetExtractionSetUpType()
		{
			if (this.ExtractionSetUp_OptionSet.CheckedIndex == 0)
			{
				return ExtractionSetUpType.SearchAuto;
			}
			else
			{
				return ExtractionSetUpType.SearchSpecification;
			}
		}
		# endregion

		# region Control Events
		/// <summary>
		/// Form.Load �C�x���g(SFCMN09000UD)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void SFCMN09000UD_Load(object sender, System.EventArgs e)
		{
			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Decision_Button.ImageList = imageList16;
			this.Close_Button.ImageList = imageList16;
			this.Decision_Button.Appearance.Image = Size16_Index.DECISION;
			this.Close_Button.Appearance.Image = Size16_Index.CLOSE;
		}

		/// <summary>
		/// Control.Click �C�x���g(Decision_Button_Click)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �m��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void Decision_Button_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		/// <summary>
		/// Control.Click �C�x���g(Close_Button_Click)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void Close_Button_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		# endregion
	}
}
