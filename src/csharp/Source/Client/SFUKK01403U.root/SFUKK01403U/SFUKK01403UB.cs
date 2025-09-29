using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �����`�[���́i�����^�j�ԓ`�쐬�t�h�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �����`�[���́i�����^�j�ԓ`�쐬�t�h�̋@�\���������܂��B</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2005.08.20</br>
	/// </remarks>
	public class SFUKK01403UB : System.Windows.Forms.Form
	{
		# region Private Members (Component)
		private Infragistics.Win.Misc.UltraLabel ultraLabel57;
		private Broadleaf.Library.Windows.Forms.TLine tLine10;
		private Infragistics.Win.Misc.UltraLabel ultraLabel40;
		private Broadleaf.Library.Windows.Forms.TDateEdit detDepositDate;
		private Infragistics.Win.Misc.UltraButton btnSave;
		private Infragistics.Win.Misc.UltraButton btnCancel;
		private Broadleaf.Library.Windows.Forms.TNedit edtDepositSlipNo;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// �����`�[���́i�����^�j�ԓ`�쐬�t�h�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �g�p���郁���o�̏��������s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.20</br>
		/// </remarks>
		public SFUKK01403UB()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFUKK01403UB));
            this.detDepositDate = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel57 = new Infragistics.Win.Misc.UltraLabel();
            this.btnSave = new Infragistics.Win.Misc.UltraButton();
            this.btnCancel = new Infragistics.Win.Misc.UltraButton();
            this.tLine10 = new Broadleaf.Library.Windows.Forms.TLine();
            this.ultraLabel40 = new Infragistics.Win.Misc.UltraLabel();
            this.edtDepositSlipNo = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tLine10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDepositSlipNo)).BeginInit();
            this.SuspendLayout();
            // 
            // detDepositDate
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.detDepositDate.ActiveEditAppearance = appearance1;
            this.detDepositDate.BackColor = System.Drawing.Color.Transparent;
            this.detDepositDate.CalendarDisp = true;
            this.detDepositDate.EditAppearance = appearance2;
            this.detDepositDate.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.detDepositDate.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.detDepositDate.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.detDepositDate.LabelAppearance = appearance3;
            this.detDepositDate.Location = new System.Drawing.Point(104, 48);
            this.detDepositDate.Name = "detDepositDate";
            this.detDepositDate.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.detDepositDate.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.detDepositDate.Size = new System.Drawing.Size(172, 24);
            this.detDepositDate.TabIndex = 1;
            this.detDepositDate.TabStop = true;
            // 
            // ultraLabel57
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.ultraLabel57.Appearance = appearance4;
            this.ultraLabel57.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel57.Location = new System.Drawing.Point(16, 48);
            this.ultraLabel57.Name = "ultraLabel57";
            this.ultraLabel57.Size = new System.Drawing.Size(96, 24);
            this.ultraLabel57.TabIndex = 57;
            this.ultraLabel57.Text = "�ԓ`������";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(28, 104);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(132, 25);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "�m��(&S)";
            this.btnSave.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(160, 104);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(132, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "�߂�(&C)";
            this.btnCancel.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            // 
            // tLine10
            // 
            this.tLine10.BackColor = System.Drawing.Color.Transparent;
            this.tLine10.LineStyle = Broadleaf.Library.Windows.Forms.emLineStyle.lsDot;
            this.tLine10.Location = new System.Drawing.Point(16, 88);
            this.tLine10.Name = "tLine10";
            this.tLine10.Size = new System.Drawing.Size(288, 8);
            this.tLine10.TabIndex = 187;
            this.tLine10.Text = "tLine10";
            // 
            // ultraLabel40
            // 
            appearance5.TextVAlignAsString = "Middle";
            this.ultraLabel40.Appearance = appearance5;
            this.ultraLabel40.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel40.Location = new System.Drawing.Point(16, 16);
            this.ultraLabel40.Name = "ultraLabel40";
            this.ultraLabel40.Size = new System.Drawing.Size(88, 24);
            this.ultraLabel40.TabIndex = 188;
            this.ultraLabel40.Text = "�����ԍ�";
            // 
            // edtDepositSlipNo
            // 
            this.edtDepositSlipNo.ActiveAppearance = appearance6;
            appearance7.TextHAlignAsString = "Right";
            this.edtDepositSlipNo.Appearance = appearance7;
            this.edtDepositSlipNo.AutoSelect = true;
            this.edtDepositSlipNo.CalcSize = new System.Drawing.Size(172, 200);
            this.edtDepositSlipNo.DataText = "";
            this.edtDepositSlipNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.edtDepositSlipNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.edtDepositSlipNo.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.edtDepositSlipNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.edtDepositSlipNo.Location = new System.Drawing.Point(104, 16);
            this.edtDepositSlipNo.MaxLength = 9;
            this.edtDepositSlipNo.Name = "edtDepositSlipNo";
            this.edtDepositSlipNo.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.edtDepositSlipNo.ReadOnly = true;
            this.edtDepositSlipNo.Size = new System.Drawing.Size(82, 24);
            this.edtDepositSlipNo.TabIndex = 0;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // SFUKK01403UB
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(320, 142);
            this.Controls.Add(this.edtDepositSlipNo);
            this.Controls.Add(this.ultraLabel40);
            this.Controls.Add(this.tLine10);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.detDepositDate);
            this.Controls.Add(this.ultraLabel57);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SFUKK01403UB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "�����@�ԓ`�쐬";
            this.Load += new System.EventHandler(this.SFUKK01403UB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tLine10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDepositSlipNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region Private Menbers
		/// <summary>�����`�[���͉��(�����^)�A�N�Z�X�N���X</summary>
		private InputDepositNormalTypeAcs _inputDepositNormalTypeAcs;
		# endregion

		# region public Methods
		/// <summary>
		/// �����`�[�ԓ`����
		/// </summary>
		/// <param name="inputDepositNormalTypeAcs">�����`�[���͉��(�����^)�A�N�Z�X�N���X</param>
		/// <param name="depositSlipNo">�����ԍ�</param>
		/// <param name="depositDate">�ԓ`�������t</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �����`�[�̐ԓ`����UI��ʂ�\�����܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public System.Windows.Forms.DialogResult ShowDialogAkaCreate(InputDepositNormalTypeAcs inputDepositNormalTypeAcs, int depositSlipNo, out int depositDate)
		{
			// �����`�[���͉��(�����^)�A�N�Z�X�N���X
			this._inputDepositNormalTypeAcs = inputDepositNormalTypeAcs;

			// �����ԍ�
			edtDepositSlipNo.SetInt(depositSlipNo);

			// �ԓ`������
			detDepositDate.SetDateTime(TDateTime.GetSFDateNow());

			// ��ʋN��
			System.Windows.Forms.DialogResult result = this.ShowDialog();

			// �ԓ`������
			depositDate = TDateTime.DateTimeToLongDate(detDepositDate.GetDateTime());

			return result;
		}
		# endregion

		# region Private Methods
		/// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
			ImageList imageList16 = IconResourceManagement.ImageList16;

			// �m��{�^��
			btnSave.ImageList = imageList16;
			btnSave.Appearance.Image = Size16_Index.SAVE;

			// �L�����Z���{�^��
			btnCancel.ImageList = imageList16;
			btnCancel.Appearance.Image = Size16_Index.BEFORE;
		}
		# endregion

		# region Control Events
		/// <summary>
		/// ��ʃ��[�h�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�f�[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ގ��ɔ������܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void SFUKK01403UB_Load(object sender, System.EventArgs e)
		{
			// ��ʏ����ݒ菈��
			this.ScreenInitialSetting();

			// �����J�[�\���Z�b�g
			detDepositDate.Focus();
		}

		/// <summary>
		/// �ۑ��{�^�������C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�f�[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���[�U�[���ۑ��{�^�����N���b�N�������ɔ������܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.None;

			// �������`�F�b�N
			if (detDepositDate.GetLongDate() == 0)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "����������͂��ĉ������B", 0, MessageBoxButtons.OK);
				detDepositDate.Focus();
				return;
			}
			if (TDateTime.IsAvailableDate(detDepositDate.GetDateTime()) == false)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "�������̓��t���s���ł��B", 0, MessageBoxButtons.OK);
				detDepositDate.Focus();
				return;
			}

			// �������`�F�b�N �ŏI�����X�V�N�����`�F�b�N
			if (_inputDepositNormalTypeAcs.CheckPastCAddUpUpdDate(detDepositDate.GetLongDate()) <= 0)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "���������O�񐿋������ȑO�ɂȂ��Ă��܂��B", 0, MessageBoxButtons.OK);
				detDepositDate.Focus();
				return;
			}

            // �� 20070801 18322 a
            if (detDepositDate.GetLongDate() <= this._inputDepositNormalTypeAcs.GetLastMonthlyDate())
            {
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "���������O�񌎎������ȑO�ɂȂ��Ă��܂��B", 0, MessageBoxButtons.OK);
				detDepositDate.Focus();
				return;
            }
            // �� 20070801 18322 a

			this.DialogResult = System.Windows.Forms.DialogResult.OK;
		}
		# endregion
	}
}
