//using System;
//using System.Drawing;
//using System.Collections;
//using System.ComponentModel;
//using System.Windows.Forms;

//namespace Broadleaf.Windows.Forms
//{
//    /// <summary>
//    /// SFTKD00426UG �̊T�v�̐����ł��B
//    /// </summary>
//    public class WaitWindow : System.Windows.Forms.Form
//    {
//        private Infragistics.Win.UltraWinProgressBar.UltraProgressBar ultraProgressBar1;
//        private System.Windows.Forms.Timer timer1;
//        private System.ComponentModel.IContainer components;

//        public WaitWindow()
//        {
//            //
//            // Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
//            //
//            InitializeComponent();
//        }

//        /// <summary>
//        /// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
//        /// </summary>
//        protected override void Dispose( bool disposing )
//        {
//            if( disposing )
//            {
//                if(components != null)
//                {
//                    components.Dispose();
//                }
//            }
//            base.Dispose( disposing );
//        }

//        #region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
//        /// <summary>
//        /// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
//        /// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();
//            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(WaitWindow));
//            this.ultraProgressBar1 = new Infragistics.Win.UltraWinProgressBar.UltraProgressBar();
//            this.timer1 = new System.Windows.Forms.Timer(this.components);
//            this.SuspendLayout();
//            // 
//            // ultraProgressBar1
//            // 
//            this.ultraProgressBar1.Location = new System.Drawing.Point(16, 16);
//            this.ultraProgressBar1.Maximum = 10;
//            this.ultraProgressBar1.Name = "ultraProgressBar1";
//            this.ultraProgressBar1.Size = new System.Drawing.Size(376, 24);
//            this.ultraProgressBar1.Step = 1;
//            this.ultraProgressBar1.TabIndex = 0;
//            this.ultraProgressBar1.Text = "�_�E�����[�h��";
//            // 
//            // timer1
//            // 
//            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
//            // 
//            // WaitWindow
//            // 
//            this.AutoScaleBaseSize = new System.Drawing.Size(7, 15);
//            this.BackColor = System.Drawing.Color.WhiteSmoke;
//            this.ClientSize = new System.Drawing.Size(408, 59);
//            this.Controls.Add(this.ultraProgressBar1);
//            this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
//            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
//            this.MaximizeBox = false;
//            this.MinimizeBox = false;
//            this.Name = "WaitWindow";
//            this.ShowInTaskbar = false;
//            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
//            this.Text = "�Z�����_�E�����[�h";
//            this.TopMost = true;
//            this.VisibleChanged += new System.EventHandler(this.WaitWindow_VisibleChanged);
//            this.ResumeLayout(false);

//        }
//        #endregion

//        private void timer1_Tick(object sender, System.EventArgs e)
//        {
//            if( this.ultraProgressBar1.Value == this.ultraProgressBar1.Maximum )
//            {
//                this.ultraProgressBar1.Value = this.ultraProgressBar1.Minimum;
//            }
//            this.ultraProgressBar1.Value++;
//            this.Refresh();
//        }
		
//        private void WaitWindow_VisibleChanged(object sender, System.EventArgs e)
//        {
//            if( this.Visible )
//            {
//                this.timer1.Start();
//            }
//            else
//            {
//                this.timer1.Stop();
//            }
//        }
		
//    }
//}
