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
// �Ǘ��ԍ�              �쐬�S�� : �� �B
// �� �� ��  2016/10/20  �C�����e : ���[�J���ɏo�͂���Ă��郍�O���폜
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

namespace Broadleaf.Windows.Forms
{
    public partial class PMCMN00089UA : Form
    {
        /// <summary>�������[�h</summary>
        private bool autoMode = false;

        /// <summary>�W���z�M�t�H���_�o�X</summary>
        private string installDirectory = "";


        #region Private Event
        /// <summary>
        /// �N��
        /// </summary>
        public PMCMN00089UA(bool autoMode)
        {
            InitializeComponent();

            this.autoMode = autoMode;

            //PMNS�̃C���X�g�[���p�X�̎擾(USER_AP)
            this.installDirectory = GetInstallDirectory();
        }

        /// <summary>
        /// FormLoad
        /// </summary>
        private void PMCMN00089UA_Load(object sender, EventArgs e)
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
            //�T�[�o�[
            string keyPath = @String.Format(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

            RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath);
            string directoryPath = "";
            if (key.GetValue("InstallDirectory") != null)
            {
                directoryPath = (string)key.GetValue("InstallDirectory");
            }
            key.Close();

            return directoryPath;
        }

        /// <summary>
        /// LSM�`�F�b�N�ďo
        /// </summary>
        private void CallLsmCheck()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR; //ctDB_ERROR(1000)
            try
            {
                object objLsmCheckList = null;

                // LSM�`�F�b�N�ďo
                LsmHistoryLog lsmHistoryLog = new LsmHistoryLog();
                //--- ADD 2015/10/08 20073 T.Nishi ----->>>>>
                Boolean LsmWriteFlg = true;  //true:���O����������  false:���O���������܂Ȃ�
                status = lsmHistoryLog.WriteLsmLog(out objLsmCheckList, LsmWriteFlg);
                //--- ADD 2015/10/08 20073 T.Nishi -----<<<<<

                // ���ʕ\��
                string sMsg = string.Empty;
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
                                    + "�T�[�o�[���́uLSMService_Log.txt�v�̓��e���m�F���ĉ������B"
                                    + "\r\n"
                                    + "\r\n"
                                    + sMsg;
                    }
                    if (autoMode)
                    {
                        //--- DEL 2016/10/20 T.Nishi ----->>>>>
                        //LogTextOut logTextOut = new LogTextOut();
                        //logTextOut.Output("PMCMN00089U", sMsg, status);
                        //--- DEL 2016/10/20 T.Nishi -----<<<<<
                    }
                    else
                    {
                        //--- ADD 2015/10/08 20073 T.Nishi ----->>>>>
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
                        //--- ADD 2015/10/08 20073 T.Nishi -----<<<<<
                        LsmLogLst.Items.Add(sMsg);
                    }

                }
            }
            catch (Exception ex)
            {
                //--- DEL 2016/10/20 T.Nishi ----->>>>>
                //LogTextOut logTextOut = new LogTextOut();
                //logTextOut.Output("PMCMN00089U", ex.Message, 0);
                //--- DEL 2016/10/20 T.Nishi -----<<<<<
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
        #endregion
    }
}