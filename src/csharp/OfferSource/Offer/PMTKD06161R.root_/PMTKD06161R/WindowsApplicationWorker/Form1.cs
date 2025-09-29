using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
//using Broadleaf.Application.Controller;
//using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace WindowsApplicationWorker
{
    /// <summary>
    /// Form1 �̊T�v�̐����ł��B
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox textBox1;
        /// <summary>
        /// �K�v�ȃf�U�C�i�ϐ��ł��B
        /// </summary>
        private System.ComponentModel.Container components = null;

        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.DataGrid dataGrid2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;

        private static System.Windows.Forms.Form _form = null;
        private static string[] _parameter;

        public Form1()
        {
            //
            // Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
            //
            InitializeComponent();

            //
            // TODO: InitializeComponent �Ăяo���̌�ɁA�R���X�g���N�^ �R�[�h��ǉ����Ă��������B
            //
        }

        /// <summary>
        /// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(288, 19);
            this.textBox1.TabIndex = 1;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(432, 16);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(96, 24);
            this.button8.TabIndex = 33;
            this.button8.Text = "CustomSearch";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(17, 106);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(861, 342);
            this.dataGrid2.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(576, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 38;
            this.label3.Text = "Time:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(624, 16);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(112, 19);
            this.textBox2.TabIndex = 39;
            this.textBox2.Text = "0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(432, 48);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 24);
            this.button3.TabIndex = 58;
            this.button3.Text = "SearchACS";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(891, 460);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.button8);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            try
            {
                string msg = "";
                _parameter = args;
                //�A�v���P�[�V�����J�n���������B���p�����[�^�̓A�v���P�[�V�����̃\�t�g�E�F�A�R�[�h���w��o����ꍇ�͎w��B
                //�o���Ȃ��ꍇ�̓v���_�N�g�R�[�h
                int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode,
                                    new EventHandler(ApplicationReleased));
                if (status == 0)
                {
                    _form = new Form1();
                    System.Windows.Forms.Application.Run(_form);
                }
                if (status != 0) TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "Form1", msg, 0, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "Form1", ex.Message, 0, MessageBoxButtons.OK);
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
        }

        /// <summary>
        /// �A�v���P�[�V�����I���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">���b�Z�[�W</param>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            //���b�Z�[�W���o���O�ɑS�ĊJ��
            ApplicationStartControl.EndApplication();
            //�]�ƈ����O�I�t�̃��b�Z�[�W��\��
            if (_form != null) TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "Form1", e.ToString(), 0, MessageBoxButtons.OK);
            else TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "Form1", e.ToString(), 0, MessageBoxButtons.OK);
            //�A�v���P�[�V�����I��
            System.Windows.Forms.Application.Exit();
        }


        private void Form1_Load(object sender, System.EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);


        }

        private void button8_Click(object sender, System.EventArgs e)
        {

        }

        private void button3_Click(object sender, System.EventArgs e)
        {

        }

    }
}
