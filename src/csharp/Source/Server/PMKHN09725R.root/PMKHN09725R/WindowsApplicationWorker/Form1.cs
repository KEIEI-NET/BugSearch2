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
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.TextBox textEnterpriseCode;
        private System.Windows.Forms.DataGrid dataGrid1;
        /// <summary>
        /// �K�v�ȃf�U�C�i�ϐ��ł��B
        /// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button buttonClear;

        private RoleGroupNameStWork _roleGroupNameStWork = null;

        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonWriteGrid;
        private System.Windows.Forms.Button buttonAddRow;
        private System.Windows.Forms.Button buttonLogDelGrid;
        private System.Windows.Forms.Button buttonRevGrid;
        private System.Windows.Forms.Button buttonDelGrid;

        private IRoleGroupNameStDB IroleGroupNameStDB = null;

        private static string[] _parameter;
        private DataGrid dataGrid2;
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
            this.buttonRead = new System.Windows.Forms.Button();
            this.textEnterpriseCode = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonWriteGrid = new System.Windows.Forms.Button();
            this.buttonAddRow = new System.Windows.Forms.Button();
            this.buttonLogDelGrid = new System.Windows.Forms.Button();
            this.buttonRevGrid = new System.Windows.Forms.Button();
            this.buttonDelGrid = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRead
            // 
            this.buttonRead.Location = new System.Drawing.Point(312, 16);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(75, 23);
            this.buttonRead.TabIndex = 0;
            this.buttonRead.Text = "Read";
            this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // textEnterpriseCode
            // 
            this.textEnterpriseCode.Location = new System.Drawing.Point(16, 16);
            this.textEnterpriseCode.Name = "textEnterpriseCode";
            this.textEnterpriseCode.Size = new System.Drawing.Size(288, 19);
            this.textEnterpriseCode.TabIndex = 1;
            this.textEnterpriseCode.Text = "0101150842020000";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(16, 284);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(909, 252);
            this.dataGrid1.TabIndex = 13;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(17, 139);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 20;
            this.buttonClear.Text = "Clear";
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(83, 255);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(88, 23);
            this.buttonSearch.TabIndex = 33;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonWriteGrid
            // 
            this.buttonWriteGrid.Location = new System.Drawing.Point(289, 255);
            this.buttonWriteGrid.Name = "buttonWriteGrid";
            this.buttonWriteGrid.Size = new System.Drawing.Size(72, 23);
            this.buttonWriteGrid.TabIndex = 34;
            this.buttonWriteGrid.Text = "WriteGrid";
            this.buttonWriteGrid.Click += new System.EventHandler(this.buttonWriteGrid_Click);
            // 
            // buttonAddRow
            // 
            this.buttonAddRow.Location = new System.Drawing.Point(17, 255);
            this.buttonAddRow.Name = "buttonAddRow";
            this.buttonAddRow.Size = new System.Drawing.Size(60, 23);
            this.buttonAddRow.TabIndex = 35;
            this.buttonAddRow.Text = "AddRow";
            this.buttonAddRow.Click += new System.EventHandler(this.buttonAddRow_Click);
            // 
            // buttonLogDelGrid
            // 
            this.buttonLogDelGrid.Location = new System.Drawing.Point(361, 255);
            this.buttonLogDelGrid.Name = "buttonLogDelGrid";
            this.buttonLogDelGrid.Size = new System.Drawing.Size(72, 23);
            this.buttonLogDelGrid.TabIndex = 36;
            this.buttonLogDelGrid.Text = "LogDelGrid";
            this.buttonLogDelGrid.Click += new System.EventHandler(this.buttonLogDelGrid_Click);
            // 
            // buttonRevGrid
            // 
            this.buttonRevGrid.Location = new System.Drawing.Point(433, 255);
            this.buttonRevGrid.Name = "buttonRevGrid";
            this.buttonRevGrid.Size = new System.Drawing.Size(72, 23);
            this.buttonRevGrid.TabIndex = 37;
            this.buttonRevGrid.Text = "RevGrid";
            this.buttonRevGrid.Click += new System.EventHandler(this.buttonRevGrid_Click);
            // 
            // buttonDelGrid
            // 
            this.buttonDelGrid.Location = new System.Drawing.Point(505, 255);
            this.buttonDelGrid.Name = "buttonDelGrid";
            this.buttonDelGrid.Size = new System.Drawing.Size(72, 23);
            this.buttonDelGrid.TabIndex = 38;
            this.buttonDelGrid.Text = "DelGrid";
            this.buttonDelGrid.Click += new System.EventHandler(this.buttonDelGrid_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(16, 168);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(909, 81);
            this.dataGrid2.TabIndex = 39;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 550);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.buttonDelGrid);
            this.Controls.Add(this.buttonRevGrid);
            this.Controls.Add(this.buttonLogDelGrid);
            this.Controls.Add(this.buttonAddRow);
            this.Controls.Add(this.buttonWriteGrid);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textEnterpriseCode);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.buttonRead);
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
        /// 1���ǂݍ��ݏ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRead_Click(object sender, EventArgs e)
        {
            _roleGroupNameStWork = new RoleGroupNameStWork();
            _roleGroupNameStWork.EnterpriseCode = "0101150842020000";
            _roleGroupNameStWork.RoleGroupCode = 1;

            // XML�֕ϊ����A������̃o�C�i����
            byte[] parabyte = XmlByteSerializer.Serialize(_roleGroupNameStWork);

            int status = IroleGroupNameStDB.Read(ref parabyte, 0);
            if (status != 0)
            {
                Text = "�Y���f�[�^����";
            }
            else
            {
                // XML�̓ǂݍ���
                _roleGroupNameStWork = (RoleGroupNameStWork)XmlByteSerializer.Deserialize(parabyte, typeof(RoleGroupNameStWork));

                Text = "�Y���f�[�^�L��";
                ArrayList al = new ArrayList();
                al.Add(_roleGroupNameStWork);
                dataGrid1.DataSource = al;
            }
        }

        /// <summary>
        /// FromLoad���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, System.EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            IroleGroupNameStDB = MediationRoleGroupNameStDB.GetRoleGroupNameStDB();
        }

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, System.EventArgs e)
        {
            dataGrid1.DataSource = null;
            dataGrid2.DataSource = null;
            ArrayList al = new ArrayList();
            RoleGroupNameStWork work = new RoleGroupNameStWork();
            work.EnterpriseCode = textEnterpriseCode.Text;
            al.Add(work);
            dataGrid2.DataSource = al;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSearch_Click(object sender, System.EventArgs e)
        {
            string ent = "0101150842020000";

            RoleGroupNameStWork work = new RoleGroupNameStWork();
            work.EnterpriseCode = ent;

            ArrayList al = new ArrayList();
            al.Add(work);

            object parabyte = al;
            object objRoleGroupNameLst;

            int status = IroleGroupNameStDB.Search(out objRoleGroupNameLst, parabyte, 0, 0);

            if (status != 0)
            {
                Text = "�Y���f�[�^����";
            }
            else
            {

                Text = "�Y���f�[�^�L��  HIT " + ((ArrayList)objRoleGroupNameLst).Count.ToString() + "��";

                dataGrid1.DataSource = objRoleGroupNameLst;
            }
        }

        /// <summary>
        /// �X�V����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonWriteGrid_Click(object sender, System.EventArgs e)
        {
            object objRoleGroupNameStWork = null;

            RoleGroupNameStWork cam = new RoleGroupNameStWork();

            cam.EnterpriseCode = "0101150842020000";
            cam.RoleGroupCode = 1;
            cam.RoleGroupName = "�O���[�v���̂P";

            objRoleGroupNameStWork = cam;


            int status = IroleGroupNameStDB.Write(ref objRoleGroupNameStWork);
            if (status != 0)
            {
                Text = "�X�V���s";
                if (status == 800)
                {
                    MessageBox.Show("���[���ōX�V����Ă��܂��B�ēx�f�[�^��ǂݍ���ł���ēo�^���Ă��������B");
                }
                else if (status == 801)
                {
                    MessageBox.Show("���[���Ńf�[�^���폜����Ă��܂��B�o�^�o���܂���ł����B");
                }
            }
            else
            {
                Text = "�X�V����";
                dataGrid1.DataSource = null;
                dataGrid1.DataSource = objRoleGroupNameStWork;
            }
        }

        /// <summary>
        /// �s�ǉ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddRow_Click(object sender, System.EventArgs e)
        {
            RoleGroupNameStWork roleGroupNameStWork = new RoleGroupNameStWork();
            roleGroupNameStWork.EnterpriseCode = textEnterpriseCode.Text;
            ArrayList al = dataGrid1.DataSource as ArrayList;
            if (al == null) al = new ArrayList();
            al.Add(roleGroupNameStWork);
            dataGrid1.DataSource = null;
            dataGrid1.DataSource = al;
        }

        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLogDelGrid_Click(object sender, System.EventArgs e)
        {
            object objRoleGroupNameLstWork = dataGrid1.DataSource;

            int status = IroleGroupNameStDB.LogicalDelete(ref objRoleGroupNameLstWork);
            if (status != 0)
            {
                Text = "�_���폜���s";
                if (status == 800)
                {
                    MessageBox.Show("���[���ōX�V����Ă��܂��B�ēx�f�[�^��ǂݍ���ł���ēo�^���Ă��������B");
                }
                else if (status == 801)
                {
                    MessageBox.Show("���[���Ńf�[�^���폜����Ă��܂��B�o�^�o���܂���ł����B");
                }
            }
            else
            {
                Text = "�_���폜����";
                dataGrid1.DataSource = null;
                dataGrid1.DataSource = objRoleGroupNameLstWork;
            }
        }

        /// <summary>
        /// �폜����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelGrid_Click(object sender, System.EventArgs e)
        {
            object objRoleGroupNameLstWork = dataGrid1.DataSource;

            RoleGroupNameStWork[] trarray = (RoleGroupNameStWork[])((ArrayList)dataGrid1.DataSource).ToArray(typeof(RoleGroupNameStWork));
            byte[] parabyte = XmlByteSerializer.Serialize(trarray);

            int status = IroleGroupNameStDB.Delete(parabyte);
            if (status != 0)
            {
                Text = "�폜���s";
                if (status == 800)
                {
                    MessageBox.Show("���[���ōX�V����Ă��܂��B�ēx�f�[�^��ǂݍ���ł���č폜���Ă��������B");
                }
                else if (status == 801)
                {
                    MessageBox.Show("���[���Ńf�[�^���폜����Ă��܂��B�폜�o���܂���ł����B");
                }
            }
            else
            {
                Text = "�폜����";
                dataGrid1.DataSource = null;
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRevGrid_Click(object sender, EventArgs e)
        {
            object objRoleGroupNameLstWork = dataGrid1.DataSource;

            int status = IroleGroupNameStDB.RevivalLogicalDelete(ref objRoleGroupNameLstWork);
            if (status != 0)
            {
                Text = "�������s";
                if (status == 800)
                {
                    MessageBox.Show("���[���ōX�V����Ă��܂��B�ēx�f�[�^��ǂݍ���ł���ēo�^���Ă��������B");
                }
                else if (status == 801)
                {
                    MessageBox.Show("���[���Ńf�[�^���폜����Ă��܂��B�o�^�o���܂���ł����B");
                }
            }
            else
            {
                Text = "��������";
                dataGrid1.DataSource = null;
                dataGrid1.DataSource = objRoleGroupNameLstWork;
            }
        }
    }
}