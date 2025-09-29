using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using UBAU.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;

using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;


namespace Broadleaf.Windows.Forms
{
    public partial class PMUOE00004U : Form
    {
        #region �v���C�x�[�g�����o
        private const string SETCOM1 = "COM1";
        private const string SETCOM2 = "COM2";
        private const string SETCOM3 = "COM3";
        private const int SETCOM1_VALUE = 0;
        private const int SETCOM2_VALUE = 1;
        private const int SETCOM3_VALUE = 2;

        private PMUOE00004U _customerSearchForm;
        #endregion

        public PMUOE00004U()
        {
            InitializeComponent();

            this.ultraComboEditor1.Items.Clear();
            this.ultraComboEditor1.Items.Add(SETCOM1_VALUE, SETCOM1);
            this.ultraComboEditor1.Items.Add(SETCOM2_VALUE, SETCOM2);
            this.ultraComboEditor1.Items.Add(SETCOM3_VALUE, SETCOM3);
            this.ultraComboEditor1.MaxDropDownItems = this.ultraComboEditor1.Items.Count;
            this.ultraComboEditor1.SelectedIndex = 0;

            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.Ok_Button.ImageList = imageList24;                     // �ۑ��{�^��
            this.Cancel_Button.ImageList = imageList24;                 // ����{�^��
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;        // �ۑ��{�^��
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;   // ����{�^��
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            int status = -1;

            string comPort = "";
            string paraKey = "";

            //�C���X�g�[���p�X�ǂݍ���
            status = GetRegistryValue(out paraKey);

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();

            //ComSpec�̃p�X���擾����
            psi.FileName = System.Environment.GetEnvironmentVariable("ComSpec");

            if (status == -1)
            {
                TMsgDisp.Show(
                              this,
                              emErrorLevel.ERR_LEVEL_EXCLAMATION,
                              this.Name,
                              "�C���X�g�[�����̎擾�Ɏ��s���܂����B\n�������C���X�g�[�����s���Ă��邩�ǂ����m�F���Ă�������",
                              -1,
                              MessageBoxButtons.OK);
                return;
            }

            //�o�͂�ǂݎ���悤�ɂ���
            psi.RedirectStandardInput = false;
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            //�E�B���h�E��\�����Ȃ��悤�ɂ���
            psi.CreateNoWindow = true;
            psi.WorkingDirectory = paraKey;
            //�R�}���h���C�����w��i"/c"�͎��s����邽�߂ɕK�v�j
            psi.Arguments = @"/c chktcom.exe " + this.ultraComboEditor1.SelectedItem;

            //�N��
            System.Diagnostics.Process p = System.Diagnostics.Process.Start(psi);

            //�o�͂�ǂݎ��
            string results = p.StandardOutput.ReadToEnd();
            //WaitForExit��ReadToEnd�̌�ł���K�v������
            //(�e�v���Z�X�A�q�v���Z�X�Ńu���b�N�h�~�̂���)
            p.WaitForExit();

            if (results.Contains("TCOM56KFHA")/*TCOM56K*/)
            {
                comPort = "TRANS_BC.PRG";
            }
            else if (results.Contains("TCOM336FHA(C)")/*TCOM336C*/)
            {
                comPort = "TRANS_BC.PRG";
            }
            else if (results.Contains("TCOM336FHA")/*TCOM336*/)
            {
                comPort = "TRANS_B.PRG";
            }
            else if(results.Contains("No way to identify this device"))
            {
                TMsgDisp.Show(
                              this,
                              emErrorLevel.ERR_LEVEL_EXCLAMATION,
                              this.Name,
                              "�I������COM�|�[�g�����݂��܂���B",
                              -1,
                              MessageBoxButtons.OK);
                this.Enabled = true;
                return;
            }
            else if(results.Contains("Fail to open"))
            {
                TMsgDisp.Show(
                              this,
                              emErrorLevel.ERR_LEVEL_EXCLAMATION,
                              this.Name,
                              "COM�|�[�g�̐ڑ��Ɏ��s���܂����B",
                              -1,
                              MessageBoxButtons.OK);
                this.Enabled = true;
                return;
            }
            else
            {
                TMsgDisp.Show(
                              this,
                              emErrorLevel.ERR_LEVEL_EXCLAMATION,
                              this.Name,
                              "���̃��f���͎g�p�ł��܂���B",
                              -1,
                              MessageBoxButtons.OK);
                this.Enabled = true;
                return;
            }

            psi.Arguments = @"/c LOADTCOM.EXE "+ this.ultraComboEditor1.SelectedItem + " " + comPort;

            //�N��
            System.Diagnostics.Process q = System.Diagnostics.Process.Start(psi);
            //�o�͂�ǂݎ��
            string qresults = q.StandardOutput.ReadToEnd();
            //WaitForExit��ReadToEnd�̌�ł���K�v������
            //(�e�v���Z�X�A�q�v���Z�X�Ńu���b�N�h�~�̂���)
            q.WaitForExit();
            this.Enabled = true;
        }

        /// <summary>
        /// ���W�X�g�����擾
        /// </summary>
        /// <param name="paraKey">���W�X�g��KEY</param>
        /// <returns>���W�X�g���l</returns>
        private int GetRegistryValue(out string paraKey)
        {
            int status = -1;
            paraKey = string.Empty;
            /*  �ΏۂƂȂ鐻�i�̏��������܂��B
             *  Menu�A�v���Ȃǂ�ApplicationType��Client��I��
             */
            RegistryTargetProductInfo registryTargetProductInfo = new RegistryTargetProductInfo();
            registryTargetProductInfo.ProductCode = LoginInfoAcquisition.ProductCode;

            registryTargetProductInfo.ApplicationType = ApplicationType.Client;
            registryTargetProductInfo.TargetServiceName = String.Empty;
            Dictionary<string, object> regTable =ServiceFactory.GetInstance().GetRemoteService().GetRegistryInfo(registryTargetProductInfo);
            
            if (regTable.Count != 0)
            {
                string ret = regTable["InstallDirectory"].ToString();
                if (ret != null)
                {
                    paraKey = ret;
                    status = 0;
                }
            }
            return status;
        }

        /// <summary>
        /// �{�^���N���b�N�C�x���g(����)
        /// </summary>
        private void ultraButton_Close_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// ���[�h�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMUOE00004U_Load(object sender, EventArgs e)
        {
            this._customerSearchForm = new PMUOE00004U();
            this._customerSearchForm.TopLevel = false;
            this._customerSearchForm.FormBorderStyle = FormBorderStyle.None;
            this._customerSearchForm.Dock = DockStyle.Fill;
        }
    }
}