//****************************************************************************//
// �V�X�e��         : LSM���O�`�F�b�N�c�[��
// �v���O��������   : LSM���O�`�F�b�N�c�[��
// �v���O�����T�v   : LSM���O�`�F�b�N�c�[��
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �{�{ ����
// �� �� ��  2015/09/24  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� �B
// �� �� ��  2015/10/08  �C�����e : ���s�����ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �{�{ ����
// �� �� ��  2015/11/18  �C�����e : �@�擾����C���X�g�[���p�X���N���C�A���g�ɕύX
//                                  �A��O�������̃��O�̏o�͐��ύX
//                                  �B�G���[�������̃��O�o�͂��폜
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �{�{ ����
// �� �� ��  2015/11/24  �C�����e : ���O�o�͐�p�X�����s�p�X���ɕύX
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Collections;
using Microsoft.Win32;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    public partial class PMCMN00084UA : Form
    {
        /// <summary>�������[�h</summary>
        private bool autoMode = false;

        /// <summary>�W���z�M�t�H���_�o�X</summary>
        private string installDirectory = "";


        #region Private Event
        /// <summary>
        /// �N��
        /// </summary>
        public PMCMN00084UA(bool autoMode)
        {
            InitializeComponent();

            this.autoMode = autoMode;

            //PMNS�̃C���X�g�[���p�X�̎擾(USER_AP)
            this.installDirectory = GetInstallDirectory();
        }

        /// <summary>
        /// FormLoad
        /// </summary>
        private void PMCMN00084UA_Load(object sender, EventArgs e)
        {
            if (this.autoMode)
            {
                //�������[�h
                CallLsmCheck(); // LSM�`�F�b�N�ďo
                Close();
            }
        }

        /// <summary>
        /// �I���{�^������
        /// </summary>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// �`�F�b�N�J�n�{�^������
        /// </summary>
        private void btn_Start_Click(object sender, EventArgs e)
        {
            LsmLogLst.Items.Clear();
            CallLsmCheck(); // LSM�`�F�b�N�ďo
        }
        #endregion


        #region Private Method
        /// <summary>
        /// �C���X�g�[���p�X�̎擾
        /// </summary>
        private string GetInstallDirectory()
        {
            // --- UPD 2015/11/18 T.Miyamoto �@ ------------------------------>>>>>
            ////�T�[�o�[
            //string keyPath = @String.Format(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

            //RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath);
            //string directoryPath = "";
            //if (key.GetValue("InstallDirectory") != null)
            //{
            //    directoryPath = (string)key.GetValue("InstallDirectory");
            //}
            //key.Close();

            //return directoryPath;
            try
            {
                // --- UPD 2015/11/24 T.Miyamoto ------------------------------>>>>>
                ////�N���C�A���g
                //string keyPath = @String.Format(@"SOFTWARE\Broadleaf\Product\Partsman");
                //RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath);
                //string directoryPath = "";
                //if (key.GetValue("InstallDirectory") != null)
                //{
                //    directoryPath = (string)key.GetValue("InstallDirectory");
                //}
                //key.Close();
                //return directoryPath;
                return System.Windows.Forms.Application.StartupPath;
                // --- UPD 2015/11/24 T.Miyamoto ------------------------------<<<<<
            }
            catch (Exception ex)
            {
                return "";
            }
            // --- UPD 2015/11/18 T.Miyamoto �@ ------------------------------<<<<<
        }

        /// <summary>
        /// LSM�`�F�b�N�ďo
        /// </summary>
        private void CallLsmCheck()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR; //ctDB_ERROR(1000)
            ArrayList list = new ArrayList();
            try
            {
                object objLsmCheckList = null;

                // LSM�`�F�b�N�ďo
                LsmHistoryLog lsmHistoryLog = new LsmHistoryLog();
                //--- ADD 2015/10/08 20073 T.Nishi ----->>>>>
                Boolean LsmWriteFlg = true;  //true:���O����������  false:���O���������܂Ȃ�
                if (autoMode)
                {
                    LsmWriteFlg = false;
                }
                //--- ADD 2015/10/08 20073 T.Nishi -----<<<<<
                status = lsmHistoryLog.WriteLsmLog(out objLsmCheckList, LsmWriteFlg);

                // ���ʕ\��
                string sMsg = string.Empty;
                //LogTextOut logTextOut = new LogTextOut(); // DEL 2015/11/18 T.Miyamoto �A
                foreach (LsmHisLogWork lsmHisLogWork in (ArrayList)objLsmCheckList)
                {
                    sMsg = lsmHisLogWork.LogDataMassage;
                    if (status.Equals((int)ConstantManagement.MethodResult.ctFNC_NORMAL))
                    {
                        sMsg = "��肠��܂���B";
                    }
                    else if (status.Equals((int)ConstantManagement.MethodResult.ctFNC_WARNING))
                    {
                        //���\�b�h�̖߂�l���x���̏ꍇ�́A����l�Ƃ��Ĉ���
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                    else
                    {
                        sMsg = "�y�A�v���P�[�V�����T�[�o�[�z" + "\r\n"
                                    + "LSM�T�[�r�X�ŃG���[���������Ă��܂��B"
                                    + "\r\n"
                                    + "\r\n"
                                    + sMsg;
                    }
                    if (autoMode)
                    {
                        list.Add(lsmHisLogWork);
                        if (lsmHisLogWork.LogDataOperationCd >= 1)
                        {
                            // --- DEL 2015/11/18 T.Miyamoto �B ------------------------------>>>>>
                            //���O�o��
                            //logTextOut.Output("PMCMN00084U", sMsg, status);
                            // --- DEL 2015/11/18 T.Miyamoto �B ------------------------------<<<<<
                            // LSM���O�f�[�^�o�^
                            lsmHistoryLog.Write(ref list);
                            if (lsmHisLogWork.LogDataOperationCd >= 2)
                            {
                                //���b�Z�[�W�\��
                                DialogResult dResult = TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                sMsg,
                                0,
                                MessageBoxButtons.OK,
                                MessageBoxDefaultButton.Button1);
                            }
                        }
                    }
                    else
                    {
                        //���s�R�[�h���܂܂��ꍇ�A���s
                        //�n�߂̈ʒu��T��
                        int foundIndex = sMsg.IndexOf("\r\n");
                        while (0 <= foundIndex)
                        {
                            string sMsg1 = sMsg.Substring(0, foundIndex);
                            LsmLogLst.Items.Add(sMsg1);
                            sMsg = sMsg.Substring(foundIndex + 2);
                            foundIndex = sMsg.IndexOf("\r\n");
                        }
                        LsmLogLst.Items.Add(sMsg);
                    }
                }
            }
            catch (Exception ex)
            {
                // --- UPD 2015/11/18 T.Miyamoto �A ------------------------------>>>>>
                //LogTextOut logTextOut = new LogTextOut();
                //logTextOut.Output("PMCMN00084U", ex.Message, 0);
                this.LogOutPut(ex.Message);
                // --- UPD 2015/11/18 T.Miyamoto �A ------------------------------<<<<<
            }
            finally
            {
                if (!autoMode)
                {
                    lblStatue.Text = (status == 0) ? "����" : "�ُ�";
                    lblStatue.ForeColor = (status == 0) ? Color.Black : Color.Red;
                }
            }
        }

        // --- ADD 2015/11/18 T.Miyamoto �A ------------------------------>>>>>
        /// <summary>
        /// ���O�o�͏���
        /// </summary>
        private void LogOutPut(string sMsg)
        {
            if (this.installDirectory != "")
            {
                StreamWriter writer = null; // �e�L�X�g���O�p

                //�o�͐�  �F[�N���C�A���g�̃C���X�g�[���p�X]\Log\PMCMN00084U\PMCMN00084U_YYYYMMDD.Log
                //�o�͌`���F"YYYY/MM/DD hh:mm:ss    �G���[���b�Z�[�W"
                Directory.CreateDirectory(@"" + this.installDirectory + @"\Log\PMCMN00084U");
                writer = new StreamWriter(@"" + this.installDirectory + @"\Log\PMCMN00084U\" + string.Format("PMCMN00084U_{0}.Log", DateTime.Now.ToString("yyyyMMdd")), true, System.Text.Encoding.GetEncoding("shift-jis"));

                writer.Write(DateTime.Now + "    " + sMsg + "\r\n");
                writer.Flush();
                if (writer != null) writer.Close();
            }
        }
        // --- ADD 2015/11/18 T.Miyamoto �A ------------------------------<<<<<
        #endregion


    }
}