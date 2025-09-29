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
using Broadleaf.Library.Collections;

namespace WindowsApplicationWorker
{
    /// <summary>
    /// Form1 �̊T�v�̐����ł��B
    /// ����From�̓����[�g�e�X�g�ׂ̈�����From�ł�
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.TextBox txtEnterpriseCode;
        private System.Windows.Forms.DataGrid dataGrid1;
        /// <summary>
        /// �K�v�ȃf�U�C�i�ϐ��ł��B
        /// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button buttonClear;

        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonWriteGrid;
        private System.Windows.Forms.Button buttonAddRow;
        private System.Windows.Forms.Button buttonLogDelGrid;
        private System.Windows.Forms.Button buttonRevGrid;
        private System.Windows.Forms.Button buttonDelGrid;

        private IRoleGroupAuthDB IroleGroupAuthDB = null;

        private static string[] _parameter;
        private DataGrid dataGrid2;
        private Label lblEnterpriseCode;
        private Label lblRoleGroupCode;
        private TextBox txtRoleGroupCode;
        private Label lblRoleCategoryID;
        private TextBox txtRoleCategoryID;
        private Label lblROLECATEGORYSUBID;
        private TextBox txtRoleCategorySubID;
        private Label lblRoleItemID;
        private TextBox txtRoleItemID;
        private Label lblRoleLimitDiv;
        private TextBox txtRoleLimitDiv;
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
            this.txtEnterpriseCode = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonWriteGrid = new System.Windows.Forms.Button();
            this.buttonAddRow = new System.Windows.Forms.Button();
            this.buttonLogDelGrid = new System.Windows.Forms.Button();
            this.buttonRevGrid = new System.Windows.Forms.Button();
            this.buttonDelGrid = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.lblEnterpriseCode = new System.Windows.Forms.Label();
            this.lblRoleGroupCode = new System.Windows.Forms.Label();
            this.txtRoleGroupCode = new System.Windows.Forms.TextBox();
            this.lblRoleCategoryID = new System.Windows.Forms.Label();
            this.txtRoleCategoryID = new System.Windows.Forms.TextBox();
            this.lblROLECATEGORYSUBID = new System.Windows.Forms.Label();
            this.txtRoleCategorySubID = new System.Windows.Forms.TextBox();
            this.lblRoleItemID = new System.Windows.Forms.Label();
            this.txtRoleItemID = new System.Windows.Forms.TextBox();
            this.lblRoleLimitDiv = new System.Windows.Forms.Label();
            this.txtRoleLimitDiv = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRead
            // 
            this.buttonRead.Location = new System.Drawing.Point(320, 12);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(75, 23);
            this.buttonRead.TabIndex = 0;
            this.buttonRead.Text = "Read";
            this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // txtEnterpriseCode
            // 
            this.txtEnterpriseCode.Location = new System.Drawing.Point(107, 13);
            this.txtEnterpriseCode.Name = "txtEnterpriseCode";
            this.txtEnterpriseCode.Size = new System.Drawing.Size(189, 19);
            this.txtEnterpriseCode.TabIndex = 1;
            this.txtEnterpriseCode.Text = "TBS1";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(16, 314);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(909, 222);
            this.dataGrid1.TabIndex = 13;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(16, 169);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 20;
            this.buttonClear.Text = "Clear";
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(84, 285);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(88, 23);
            this.buttonSearch.TabIndex = 33;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonWriteGrid
            // 
            this.buttonWriteGrid.Location = new System.Drawing.Point(290, 285);
            this.buttonWriteGrid.Name = "buttonWriteGrid";
            this.buttonWriteGrid.Size = new System.Drawing.Size(72, 23);
            this.buttonWriteGrid.TabIndex = 34;
            this.buttonWriteGrid.Text = "WriteGrid";
            this.buttonWriteGrid.Click += new System.EventHandler(this.buttonWriteGrid_Click);
            // 
            // buttonAddRow
            // 
            this.buttonAddRow.Location = new System.Drawing.Point(18, 285);
            this.buttonAddRow.Name = "buttonAddRow";
            this.buttonAddRow.Size = new System.Drawing.Size(60, 23);
            this.buttonAddRow.TabIndex = 35;
            this.buttonAddRow.Text = "AddRow";
            this.buttonAddRow.Click += new System.EventHandler(this.buttonAddRow_Click);
            // 
            // buttonLogDelGrid
            // 
            this.buttonLogDelGrid.Location = new System.Drawing.Point(362, 285);
            this.buttonLogDelGrid.Name = "buttonLogDelGrid";
            this.buttonLogDelGrid.Size = new System.Drawing.Size(72, 23);
            this.buttonLogDelGrid.TabIndex = 36;
            this.buttonLogDelGrid.Text = "LogDelGrid";
            this.buttonLogDelGrid.Click += new System.EventHandler(this.buttonLogDelGrid_Click);
            // 
            // buttonRevGrid
            // 
            this.buttonRevGrid.Location = new System.Drawing.Point(434, 285);
            this.buttonRevGrid.Name = "buttonRevGrid";
            this.buttonRevGrid.Size = new System.Drawing.Size(72, 23);
            this.buttonRevGrid.TabIndex = 37;
            this.buttonRevGrid.Text = "RevGrid";
            this.buttonRevGrid.Click += new System.EventHandler(this.buttonRevGrid_Click);
            // 
            // buttonDelGrid
            // 
            this.buttonDelGrid.Location = new System.Drawing.Point(506, 285);
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
            this.dataGrid2.Location = new System.Drawing.Point(16, 198);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(909, 81);
            this.dataGrid2.TabIndex = 39;
            // 
            // lblEnterpriseCode
            // 
            this.lblEnterpriseCode.AutoSize = true;
            this.lblEnterpriseCode.Location = new System.Drawing.Point(24, 16);
            this.lblEnterpriseCode.Name = "lblEnterpriseCode";
            this.lblEnterpriseCode.Size = new System.Drawing.Size(56, 12);
            this.lblEnterpriseCode.TabIndex = 40;
            this.lblEnterpriseCode.Text = "��ƃR�[�h";
            // 
            // lblRoleGroupCode
            // 
            this.lblRoleGroupCode.AutoSize = true;
            this.lblRoleGroupCode.Location = new System.Drawing.Point(24, 41);
            this.lblRoleGroupCode.Name = "lblRoleGroupCode";
            this.lblRoleGroupCode.Size = new System.Drawing.Size(72, 12);
            this.lblRoleGroupCode.TabIndex = 42;
            this.lblRoleGroupCode.Text = "���[���O���[�v";
            // 
            // txtRoleGroupCode
            // 
            this.txtRoleGroupCode.Location = new System.Drawing.Point(107, 38);
            this.txtRoleGroupCode.Name = "txtRoleGroupCode";
            this.txtRoleGroupCode.Size = new System.Drawing.Size(189, 19);
            this.txtRoleGroupCode.TabIndex = 41;
            this.txtRoleGroupCode.Text = "1";
            // 
            // lblRoleCategoryID
            // 
            this.lblRoleCategoryID.AutoSize = true;
            this.lblRoleCategoryID.Location = new System.Drawing.Point(24, 66);
            this.lblRoleCategoryID.Name = "lblRoleCategoryID";
            this.lblRoleCategoryID.Size = new System.Drawing.Size(39, 12);
            this.lblRoleCategoryID.TabIndex = 44;
            this.lblRoleCategoryID.Text = "�J�e�S��";
            // 
            // txtRoleCategoryID
            // 
            this.txtRoleCategoryID.Location = new System.Drawing.Point(107, 63);
            this.txtRoleCategoryID.Name = "txtRoleCategoryID";
            this.txtRoleCategoryID.Size = new System.Drawing.Size(189, 19);
            this.txtRoleCategoryID.TabIndex = 43;
            this.txtRoleCategoryID.Text = "100";
            // 
            // lblROLECATEGORYSUBID
            // 
            this.lblROLECATEGORYSUBID.AutoSize = true;
            this.lblROLECATEGORYSUBID.Location = new System.Drawing.Point(24, 91);
            this.lblROLECATEGORYSUBID.Name = "lblROLECATEGORYSUBID";
            this.lblROLECATEGORYSUBID.Size = new System.Drawing.Size(58, 12);
            this.lblROLECATEGORYSUBID.TabIndex = 46;
            this.lblROLECATEGORYSUBID.Text = "�T�u�J�e�S��";
            // 
            // txtRoleCategorySubID
            // 
            this.txtRoleCategorySubID.Location = new System.Drawing.Point(107, 88);
            this.txtRoleCategorySubID.Name = "txtRoleCategorySubID";
            this.txtRoleCategorySubID.Size = new System.Drawing.Size(189, 19);
            this.txtRoleCategorySubID.TabIndex = 45;
            this.txtRoleCategorySubID.Text = "10001";
            // 
            // lblRoleItemID
            // 
            this.lblRoleItemID.AutoSize = true;
            this.lblRoleItemID.Location = new System.Drawing.Point(24, 116);
            this.lblRoleItemID.Name = "lblRoleItemID";
            this.lblRoleItemID.Size = new System.Drawing.Size(42, 12);
            this.lblRoleItemID.TabIndex = 48;
            this.lblRoleItemID.Text = "�A�C�e��";
            // 
            // txtRoleItemID
            // 
            this.txtRoleItemID.Location = new System.Drawing.Point(107, 113);
            this.txtRoleItemID.Name = "txtRoleItemID";
            this.txtRoleItemID.Size = new System.Drawing.Size(189, 19);
            this.txtRoleItemID.TabIndex = 47;
            this.txtRoleItemID.Text = "1";
            // 
            // lblRoleLimitDiv
            // 
            this.lblRoleLimitDiv.AutoSize = true;
            this.lblRoleLimitDiv.Location = new System.Drawing.Point(24, 141);
            this.lblRoleLimitDiv.Name = "lblRoleLimitDiv";
            this.lblRoleLimitDiv.Size = new System.Drawing.Size(53, 12);
            this.lblRoleLimitDiv.TabIndex = 50;
            this.lblRoleLimitDiv.Text = "�����敪";
            // 
            // txtRoleLimitDiv
            // 
            this.txtRoleLimitDiv.Location = new System.Drawing.Point(107, 138);
            this.txtRoleLimitDiv.Name = "txtRoleLimitDiv";
            this.txtRoleLimitDiv.Size = new System.Drawing.Size(189, 19);
            this.txtRoleLimitDiv.TabIndex = 49;
            this.txtRoleLimitDiv.Text = "1";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 550);
            this.Controls.Add(this.lblRoleLimitDiv);
            this.Controls.Add(this.txtRoleLimitDiv);
            this.Controls.Add(this.lblRoleItemID);
            this.Controls.Add(this.txtRoleItemID);
            this.Controls.Add(this.lblROLECATEGORYSUBID);
            this.Controls.Add(this.txtRoleCategorySubID);
            this.Controls.Add(this.lblRoleCategoryID);
            this.Controls.Add(this.txtRoleCategoryID);
            this.Controls.Add(this.lblRoleGroupCode);
            this.Controls.Add(this.txtRoleGroupCode);
            this.Controls.Add(this.lblEnterpriseCode);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.buttonDelGrid);
            this.Controls.Add(this.buttonRevGrid);
            this.Controls.Add(this.buttonLogDelGrid);
            this.Controls.Add(this.buttonAddRow);
            this.Controls.Add(this.buttonWriteGrid);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.txtEnterpriseCode);
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
        /// �v���C�}���L�[�l��ݒ�
        /// </summary>
        /// <param name="roleGroupAuthWork"></param>
        private void SetKey(ref RoleGroupAuthWork roleGroupAuthWork)
        {
            roleGroupAuthWork.EnterpriseCode = txtEnterpriseCode.Text;
            //���ȉ��Ɋ�ƃR�[�h�ȊO�̃L�[���ڂ��Z�b�g����R�[�h���L�q
            roleGroupAuthWork.RoleGroupCode = Convert.ToInt32(txtRoleGroupCode.Text);
            roleGroupAuthWork.RoleCategoryID = Convert.ToInt32(txtRoleCategoryID.Text);
            roleGroupAuthWork.RoleCategorySubID = Convert.ToInt32(txtRoleCategorySubID.Text);
            roleGroupAuthWork.RoleItemID = Convert.ToInt32(txtRoleItemID.Text);
            roleGroupAuthWork.RoleLimitDiv = Convert.ToInt32(txtRoleLimitDiv.Text);
        }

        /// <summary>
        /// 1���ǂݍ��ݏ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRead_Click(object sender, System.EventArgs e)
        {
            object parabyte = new RoleGroupAuthWork();
            RoleGroupAuthWork roleGroupAuthWork = parabyte as RoleGroupAuthWork;

            this.SetKey(ref roleGroupAuthWork);

            int status = IroleGroupAuthDB.Read(ref parabyte, 0);

            if (status != 0)
            {
                Text = "�Y���f�[�^����";
            }
            else
            {
                Text = "�Y���f�[�^�L��";

                CustomSerializeArrayList al = new CustomSerializeArrayList();
                al.Add(parabyte);
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
            IroleGroupAuthDB = MediationRoleGroupAuthDB.GetRoleGroupAuthDB();
            txtEnterpriseCode.Text = LoginInfoAcquisition.EnterpriseCode;
#if DEBUG
            this.Text = "���[���O���[�v�����ݒ�}�X�^ - Debug";
#else
            this.Text = "���[���O���[�v�����ݒ�}�X�^ - Release";
#endif
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
            CustomSerializeArrayList al = new CustomSerializeArrayList();
            RoleGroupAuthWork roleGroupAuthWork = new RoleGroupAuthWork();
            this.SetKey(ref roleGroupAuthWork);
            al.Add(roleGroupAuthWork);
            dataGrid2.DataSource = al;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSearch_Click(object sender, System.EventArgs e)
        {
            object parabyte = dataGrid2.DataSource;
            object objroleGroupAuth = null;

            int status = IroleGroupAuthDB.Search(ref objroleGroupAuth, parabyte, 0, 0);

            if (status != 0)
            {
                Text = "�Y���f�[�^����";
            }
            else
            {

                Text = "�Y���f�[�^�L��  HIT " + ((CustomSerializeArrayList)objroleGroupAuth).Count.ToString() + "��";

                dataGrid1.DataSource = objroleGroupAuth;
            }
        }

        /// <summary>
        /// �X�V����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonWriteGrid_Click(object sender, System.EventArgs e)
        {
            object objroleGroupAuthList = dataGrid1.DataSource;

            int status = IroleGroupAuthDB.Write(ref objroleGroupAuthList);
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
                dataGrid1.DataSource = objroleGroupAuthList;
            }
        }

        /// <summary>
        /// �s�ǉ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddRow_Click(object sender, System.EventArgs e)
        {
            RoleGroupAuthWork roleGroupAuthWork = new RoleGroupAuthWork();
            this.SetKey(ref roleGroupAuthWork);
            CustomSerializeArrayList al = dataGrid1.DataSource as CustomSerializeArrayList;
            if (al == null) al = new CustomSerializeArrayList();
            al.Add(roleGroupAuthWork);
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
            object objroleGroupAuthList = dataGrid1.DataSource;

            int status = IroleGroupAuthDB.LogicalDelete(ref objroleGroupAuthList);
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
                dataGrid1.DataSource = objroleGroupAuthList;
            }
        }

        /// <summary>
        /// �폜����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelGrid_Click(object sender, System.EventArgs e)
        {
            object objroleGroupAuthList = dataGrid1.DataSource;

            int status = IroleGroupAuthDB.Delete(objroleGroupAuthList);
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
            object objroleGroupAuthList = dataGrid1.DataSource;

            int status = IroleGroupAuthDB.RevivalLogicalDelete(ref objroleGroupAuthList);
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
                dataGrid1.DataSource = objroleGroupAuthList;
            }
        }
    }
}