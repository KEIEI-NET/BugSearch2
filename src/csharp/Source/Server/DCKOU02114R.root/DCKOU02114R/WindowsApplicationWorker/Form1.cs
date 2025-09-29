using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace WindowsApplicationWorker
{
    /// <summary>
    /// Form1 �̊T�v�̐����ł��B
    /// ����From�̓����[�g�e�X�g�ׂ̈�����From�ł�
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGrid dataGrid1;
        /// <summary>
        /// �K�v�ȃf�U�C�i�ϐ��ł��B
        /// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button button9;

        //private StockConfShWork _salesOrderWork = null;

        //private StockConfShWork _prevStockConfShWork = null;
        private System.Windows.Forms.Button button8;

        private IStockDayMonthReportDB IstockconfDB = null;

        private static string[] _parameter;
        private DataGrid dataGrid2;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label1;
        private Label label2;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private TextBox textBox8;
        private TextBox textBox9;
        private Label label5;
        private Label label6;
        private Label label18;
        private Label label19;
        private TextBox textBox22;
        private TextBox textBox23;
        private Label label23;
        private Label label24;
        private TextBox textBox26;
        private TextBox textBox27;
        private TextBox textBox5;
        private Label label3;
        private Label label4;
        private ComboBox comboBox1;
        private Label label7;
        private Label label8;
        private TextBox textBox6;
        private TextBox textBox7;
        private static System.Windows.Forms.Form _form = null;

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
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(115, 19);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "0101150842020000";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(16, 339);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(909, 197);
            this.dataGrid1.TabIndex = 13;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(730, 110);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "Clear";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(16, 310);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(88, 23);
            this.button8.TabIndex = 33;
            this.button8.Text = "�d���m�F";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(12, 224);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(908, 80);
            this.dataGrid2.TabIndex = 39;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(150, 44);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(146, 19);
            this.textBox2.TabIndex = 40;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(150, 69);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(146, 19);
            this.textBox3.TabIndex = 41;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(150, 94);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(146, 19);
            this.textBox4.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 43;
            this.label1.Text = "��ƃR�[�h";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 44;
            this.label2.Text = "���_�R�[�h";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(146, 181);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 16);
            this.checkBox1.TabIndex = 45;
            this.checkBox1.Text = "�S�I��";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(212, 181);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(84, 16);
            this.checkBox2.TabIndex = 46;
            this.checkBox2.Text = "�S���_�I��";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(534, 45);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(146, 19);
            this.textBox8.TabIndex = 52;
            this.textBox8.Text = "20080101";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(712, 44);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(146, 19);
            this.textBox9.TabIndex = 53;
            this.textBox9.Text = "20091231";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(532, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 55;
            this.label5.Text = "�d����";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(686, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 56;
            this.label6.Text = "�`";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(434, 178);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 12);
            this.label18.TabIndex = 85;
            this.label18.Text = "�`";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(314, 182);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(68, 12);
            this.label19.TabIndex = 84;
            this.label19.Text = "�S���҃R�[�h";
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(388, 178);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(41, 19);
            this.textBox22.TabIndex = 83;
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(457, 178);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(41, 19);
            this.textBox23.TabIndex = 82;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(398, 48);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 12);
            this.label23.TabIndex = 97;
            this.label23.Text = "�`";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(303, 19);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(112, 12);
            this.label24.TabIndex = 96;
            this.label24.Text = "�d����(���Ӑ�)�R�[�h";
            // 
            // textBox26
            // 
            this.textBox26.Location = new System.Drawing.Point(302, 44);
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(89, 19);
            this.textBox26.TabIndex = 95;
            this.textBox26.Text = "0";
            // 
            // textBox27
            // 
            this.textBox27.Location = new System.Drawing.Point(421, 44);
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new System.Drawing.Size(92, 19);
            this.textBox27.TabIndex = 94;
            this.textBox27.Text = "999999999";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(817, 177);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(41, 19);
            this.textBox5.TabIndex = 98;
            this.textBox5.Text = "31";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(770, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 99;
            this.label3.Text = "����";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(548, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 100;
            this.label4.Text = "���[���";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "�c�Ə���",
            "�c�Ə��ʁE�S���ҕ�",
            "�c�Ə��ʁE�d�����",
            "�c�Ə��ʁE�S���ҕʁE�d�����"});
            this.comboBox1.Location = new System.Drawing.Point(607, 177);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 101;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 12);
            this.label7.TabIndex = 102;
            this.label7.Text = "�g��Ȃ����ځ�";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(686, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 105;
            this.label8.Text = "�`";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(712, 69);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(146, 19);
            this.textBox6.TabIndex = 104;
            this.textBox6.Text = "20091231";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(534, 70);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(146, 19);
            this.textBox7.TabIndex = 103;
            this.textBox7.Text = "20080101";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 550);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.textBox26);
            this.Controls.Add(this.textBox27);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.textBox22);
            this.Controls.Add(this.textBox23);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGrid1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
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
                //�A�v���P�[�V�����J�n���������B���p�����[�^�̓A�v���P�[�V�����̃\�t�g�E�F�A�R�[�h���w��o����ꍇ�͎w��B�o���Ȃ��ꍇ�̓v���_�N�g�R�[�h
                int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
                if (status == 0)
                {
                    _form = new Form1();
                    System.Windows.Forms.Application.Run(_form);
                }
                if (status != 0) TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFCMN09000U", msg, 0, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFCMN09000U", ex.Message, 0, MessageBoxButtons.OK);
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
            if (_form != null) TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "SFCMN09000U", e.ToString(), 0, MessageBoxButtons.OK);
            else TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFCMN09000U", e.ToString(), 0, MessageBoxButtons.OK);
            //�A�v���P�[�V�����I��
            System.Windows.Forms.Application.Exit();
        }


        /// <summary>
        /// FromLoad���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, System.EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            IstockconfDB = MediationStockDayMonthReportDB.GetStockConfDB();
        }

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, System.EventArgs e)
        {
            dataGrid1.DataSource = null;
            dataGrid2.DataSource = null;


            ArrayList al = new ArrayList();
            StockDayMonthReportWork work = new StockDayMonthReportWork();

            #region [OLD]
            /* --- DEL 2008/07/11 ---------->>>>>
            // ��ƃR�[�h
            work.EnterpriseCode = textBox1.Text;

            // ���_�R�[�h
            System.Collections.Generic.List<string> wrkSecCdList = new System.Collections.Generic.List<string>();

            if (textBox2.Text != "") wrkSecCdList.Add(textBox2.Text);
            if (textBox3.Text != "") wrkSecCdList.Add(textBox3.Text);
            if (textBox4.Text != "") wrkSecCdList.Add(textBox4.Text);

            string[] sectionCode = wrkSecCdList.ToArray();
            
            work.SectionCode = sectionCode;

            // �d����(���Ӑ�)�R�[�h
            if (textBox26.Text != "") work.SupplierCdSt = Convert.ToInt32(textBox26.Text);
            if (textBox27.Text != "") work.SupplierCdEd = Convert.ToInt32(textBox27.Text);

            // �d���S����
            if (textBox22.Text != "") work.StockAgentCodeSt = textBox22.Text;
            if (textBox23.Text != "") work.StockAgentCodeEd = textBox23.Text;

            // �d����
            if (textBox8.Text != "") work.StockDateSt = Convert.ToInt32(textBox8.Text);
            if (textBox9.Text != "") work.StockDateEd = Convert.ToInt32(textBox9.Text);

            // ���[���
            work.PrintType = comboBox1.SelectedIndex;

            // ����
            work.TotalDay = Convert.ToInt32(textBox5.Text);
              --- DEL 2008/07/11 ----------<<<<< */
            #endregion

            // --- ADD 2008/07/11 ---------->>>>>
            // ��ƃR�[�h
            work.EnterpriseCode = textBox1.Text;
            // ���_�R�[�h
            System.Collections.Generic.List<string> wrkSecCdList = new System.Collections.Generic.List<string>();
            if (textBox2.Text != "") wrkSecCdList.Add(textBox2.Text);
            if (textBox3.Text != "") wrkSecCdList.Add(textBox3.Text);
            if (textBox4.Text != "") wrkSecCdList.Add(textBox4.Text);
            string[] sectionCode = wrkSecCdList.ToArray();
            work.DepositStockSecCodeList = sectionCode;
            // �d����(���Ӑ�)�R�[�h
            if (textBox26.Text != "") work.SupplierCdSt = Convert.ToInt32(textBox26.Text);
            if (textBox27.Text != "") work.SupplierCdEd = Convert.ToInt32(textBox27.Text);
            // �d����
            if (textBox8.Text != "") work.DayStockDateSt = DateTime.ParseExact(textBox8.Text, "yyyyMMdd", null);
            if (textBox9.Text != "") work.DayStockDateEd = DateTime.ParseExact(textBox9.Text, "yyyyMMdd", null);
            if (textBox7.Text != "") work.MonthStockDateSt = DateTime.ParseExact(textBox7.Text, "yyyyMMdd", null);
            if (textBox6.Text != "") work.MonthStockDateEd = DateTime.ParseExact(textBox6.Text, "yyyyMMdd", null);
            // --- ADD 2008/07/11 ----------<<<<<

            al.Add(work);
            dataGrid2.DataSource = al;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, System.EventArgs e)
        {
            button9_Click(sender, e);

            object parabyte = dataGrid2.DataSource;
            object objsalesOrder;

            int status = IstockconfDB.Search(out objsalesOrder, parabyte);

            if (status != 0)
            {
                Text = "�Y���f�[�^����:status = " + status.ToString();
            }
            else
            {

                Text = "�Y���f�[�^�L��  HIT " + ((ArrayList)objsalesOrder).Count.ToString() + "��";

                dataGrid1.DataSource = objsalesOrder;
            }
        }



    }
}
