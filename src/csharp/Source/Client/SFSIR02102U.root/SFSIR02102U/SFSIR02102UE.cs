using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �x���`�[���͐ԓ`�쐬�t�h�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �x���`�[���͐ԓ`�쐬�t�h�̋@�\���������܂��B</br>
	/// <br>Programmer : 18322 �ؑ� ����</br>
	/// <br>Date       : 2006.12.22 �g��.NS�p�ɒǉ�</br>
	/// </remarks>
	internal class SFSIR02102UE : System.Windows.Forms.Form
	{
		# region Private Members (Component)
		private Infragistics.Win.Misc.UltraLabel ultraLabel57;
		private Broadleaf.Library.Windows.Forms.TLine tLine10;
		private Infragistics.Win.Misc.UltraLabel ultraLabel40;
		private Broadleaf.Library.Windows.Forms.TDateEdit detPaymentDate;
		private Infragistics.Win.Misc.UltraButton btnSave;
		private Infragistics.Win.Misc.UltraButton btnCancel;
		private Broadleaf.Library.Windows.Forms.TNedit edtPaymentSlipNo;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// �x���`�[���͐ԓ`�쐬�t�h�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �g�p���郁���o�̏��������s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.20</br>
		/// </remarks>
		public SFSIR02102UE()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFSIR02102UE));
            this.detPaymentDate = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel57 = new Infragistics.Win.Misc.UltraLabel();
            this.btnSave = new Infragistics.Win.Misc.UltraButton();
            this.btnCancel = new Infragistics.Win.Misc.UltraButton();
            this.tLine10 = new Broadleaf.Library.Windows.Forms.TLine();
            this.ultraLabel40 = new Infragistics.Win.Misc.UltraLabel();
            this.edtPaymentSlipNo = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tLine10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPaymentSlipNo)).BeginInit();
            this.SuspendLayout();
            // 
            // detPaymentDate
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.detPaymentDate.ActiveEditAppearance = appearance1;
            this.detPaymentDate.BackColor = System.Drawing.Color.Transparent;
            this.detPaymentDate.CalendarDisp = true;
            this.detPaymentDate.EditAppearance = appearance2;
            this.detPaymentDate.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.detPaymentDate.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.detPaymentDate.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.detPaymentDate.LabelAppearance = appearance3;
            this.detPaymentDate.Location = new System.Drawing.Point(104, 48);
            this.detPaymentDate.Name = "detPaymentDate";
            this.detPaymentDate.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.detPaymentDate.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.detPaymentDate.Size = new System.Drawing.Size(172, 24);
            this.detPaymentDate.TabIndex = 1;
            this.detPaymentDate.TabStop = true;
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
            this.ultraLabel57.Text = "�ԓ`�x����";
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
            this.ultraLabel40.Text = "�x���ԍ�";
            // 
            // edtPaymentSlipNo
            // 
            this.edtPaymentSlipNo.ActiveAppearance = appearance6;
            appearance7.TextHAlignAsString = "Right";
            this.edtPaymentSlipNo.Appearance = appearance7;
            this.edtPaymentSlipNo.AutoSelect = true;
            this.edtPaymentSlipNo.CalcSize = new System.Drawing.Size(172, 200);
            this.edtPaymentSlipNo.DataText = "";
            this.edtPaymentSlipNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.edtPaymentSlipNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.edtPaymentSlipNo.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.edtPaymentSlipNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.edtPaymentSlipNo.Location = new System.Drawing.Point(104, 16);
            this.edtPaymentSlipNo.MaxLength = 9;
            this.edtPaymentSlipNo.Name = "edtPaymentSlipNo";
            this.edtPaymentSlipNo.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.edtPaymentSlipNo.ReadOnly = true;
            this.edtPaymentSlipNo.Size = new System.Drawing.Size(82, 24);
            this.edtPaymentSlipNo.TabIndex = 0;
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
            // SFSIR02102UE
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(320, 142);
            this.Controls.Add(this.edtPaymentSlipNo);
            this.Controls.Add(this.ultraLabel40);
            this.Controls.Add(this.tLine10);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.detPaymentDate);
            this.Controls.Add(this.ultraLabel57);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SFSIR02102UE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "�x���@�ԓ`�쐬";
            this.Load += new System.EventHandler(this.SFSIR02102UE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tLine10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPaymentSlipNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region Private Menbers
		/// <summary>�x���`�[�N���X</summary>
        private PaymentSlp _paymentSlp;

        private int        _lastMonthlyDate = 0;
		# endregion

		# region public Methods
		/// <summary>
		/// �x���`�[�ԓ`����
		/// </summary>
        /// <param name="paymentSlp">�x���`�[�N���X</param>
		/// <param name="paymentSlipNo">�x���`�[�ԍ�</param>
        /// <param name="lastMonthlyDate">�O�񌎎����ߓ�</param>
		/// <param name="paymentDate">�ԓ`�x�����t</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �x���`�[�̐ԓ`����UI��ʂ�\�����܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		internal DialogResult ShowDialogAkaCreate(PaymentSlp paymentSlp, int paymentSlipNo, int lastMonthlyDate, out int paymentDate)
		{
			// �x���`�[���͉�ʃA�N�Z�X�N���X
            this._paymentSlp = paymentSlp;

            // �O����ߓ�
            this._lastMonthlyDate = lastMonthlyDate;

			// �x���ԍ�
			edtPaymentSlipNo.SetInt(paymentSlipNo);

			// �ԓ`�x����
			detPaymentDate.SetDateTime(TDateTime.GetSFDateNow());

			// ��ʋN��
			System.Windows.Forms.DialogResult result = this.ShowDialog();

			// �ԓ`�x����
			paymentDate = TDateTime.DateTimeToLongDate(detPaymentDate.GetDateTime());

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
		private void SFSIR02102UE_Load(object sender, System.EventArgs e)
		{
			// ��ʏ����ݒ菈��
			this.ScreenInitialSetting();

			// �����J�[�\���Z�b�g
			detPaymentDate.Focus();
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

			// �x�����`�F�b�N
			if (detPaymentDate.GetLongDate() == 0)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "�x��������͂��ĉ������B", 0, MessageBoxButtons.OK);
				detPaymentDate.Focus();
				return;
			}
			if (TDateTime.IsAvailableDate(detPaymentDate.GetDateTime()) == false)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "�x�����̓��t���s���ł��B", 0, MessageBoxButtons.OK);
				detPaymentDate.Focus();
				return;
			}

			// �x�����`�F�b�N �ŏI�����X�V�N�����`�F�b�N
			if (TDateTime.DateTimeToLongDate(detPaymentDate.GetDateTime()) <= _paymentSlp.CAddUpUpdDate)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "�x�������O������ȑO�ɂȂ��Ă��܂��B", 0, MessageBoxButtons.OK);
				detPaymentDate.Focus();
				return;
			}

            // �� 20070801 18322 a
			if (TDateTime.DateTimeToLongDate(detPaymentDate.GetDateTime()) <= this._lastMonthlyDate)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "�x�������O�񌎎������ȑO�ɂȂ��Ă��܂��B", 0, MessageBoxButtons.OK);
				detPaymentDate.Focus();
				return;
			}
            // �� 20070801 18322 a

			this.DialogResult = System.Windows.Forms.DialogResult.OK;
		}
		# endregion
	}
}
