namespace Broadleaf.Windows.Forms
{
    partial class PMSDC04000UA
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMSDC04000UA));
            this.tMemPos1 = new Broadleaf.Library.Windows.Forms.TMemPos(this.components);
            this.SuspendLayout();
            // 
            // tMemPos1
            // 
            this.tMemPos1.OwnerForm = this;
            // 
            // PMSDC04000UA
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMSDC04000UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "����A�g���M���O�\��";
            this.Load += new System.EventHandler(this.PMSDC04000UA_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMSDC04000UA_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private Broadleaf.Library.Windows.Forms.TMemPos tMemPos1;
    }
}

