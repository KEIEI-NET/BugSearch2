namespace Broadleaf.Windows.Forms
{
    partial class PMTAB00100UC
    {
        /// <summary>
        /// �K�v�ȃf�U�C�i�ϐ��ł��B
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// �g�p���̃��\�[�X�����ׂăN���[���A�b�v���܂��B
        /// </summary>
        /// <param name="disposing">�}�l�[�W ���\�[�X���j�������ꍇ true�A�j������Ȃ��ꍇ�� false �ł��B</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h

        /// <summary>
        /// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
        /// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
        /// </summary>
        private void InitializeComponent()
        {
            this.checkEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.setButton = new Infragistics.Win.Misc.UltraButton();
            this.closeButton = new Infragistics.Win.Misc.UltraButton();
            this.SuspendLayout();
            // 
            // checkEditor
            // 
            this.checkEditor.Location = new System.Drawing.Point(31, 33);
            this.checkEditor.Name = "checkEditor";
            this.checkEditor.Size = new System.Drawing.Size(198, 20);
            this.checkEditor.TabIndex = 0;
            this.checkEditor.Text = "����o�^�ʒm��\������";
            // 
            // setButton
            // 
            this.setButton.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.setButton.Location = new System.Drawing.Point(134, 77);
            this.setButton.Margin = new System.Windows.Forms.Padding(1);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(75, 24);
            this.setButton.TabIndex = 1;
            this.setButton.Text = "�ݒ�(&S)";
            this.setButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.closeButton.Location = new System.Drawing.Point(213, 77);
            this.closeButton.Margin = new System.Windows.Forms.Padding(1);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 24);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "����(&X)";
            this.closeButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // PMTAB00100UF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(292, 110);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.checkEditor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PMTAB00100UF";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "����ݒ�";
            this.Shown += new System.EventHandler(this.PMTAB00100UF_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraCheckEditor checkEditor;
        private Infragistics.Win.Misc.UltraButton setButton;
        private Infragistics.Win.Misc.UltraButton closeButton;
    }
}