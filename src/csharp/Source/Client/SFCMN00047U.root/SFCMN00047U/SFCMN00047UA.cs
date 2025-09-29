using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Runtime.Common;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �V�X�e���E���O�C��UI����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �V�X�e���E���O�C��UI����N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2008.08.28</br>
    /// <br></br>
    /// <br>Update Note: 2009.01.16 ����@�K��</br>
    /// </remarks>
    public partial class SFCMN00047UAF : Form
    {
        public bool _Finish = false;
        public bool _Visible = false;
        public bool _SpecialKilled = false;                                     //  2009.01.16  �ǉ�
        public string _KilledReason = "";                                       //  2009.01.16  �ǉ�
       
        private NsLoginControler _nsc = new NsLoginControler();

        /// <summary>
        /// �V�X�e���E���O�C������UI�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�X�e���E���O�C������UI�N���X�R���X�g���N�^</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2008.08.28</br>
        /// </remarks>
        public SFCMN00047UAF()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �t�H�[�����[�h1���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFCMN00047UAF_Load(object sender, EventArgs e)
        {
            this.Visible = false; // �t�H�[���̕\��

            // 2015/08/07 UPD ���� SCM�|�b�v�A�b�v�̃v���Z�X�����s���̏ꍇ�͋����I������ -------->>>>>>>>>>
            // TTraynotifyIcon.Text = "NS���O�C������";
            TTraynotifyIcon.Text = "NS���O�C������iPartsman�j";
            // 2015/08/07 UPD ���� SCM�|�b�v�A�b�v�̃v���Z�X�����s���̏ꍇ�͋����I������ --------<<<<<<<<<<
            TTraynotifyIcon.BalloonTipText = TTraynotifyIcon.Text;
            TTraynotifyIcon.BalloonTipTitle = TTraynotifyIcon.Text;
            TTraynotifyIcon.ContextMenuStrip = mnuMain;
            TTraynotifyIcon.Visible = true;

            //  �I���C�x���g���Ď�
            _nsc.ProcessKilling += new EventHandler<ProcessKillEventArgs>(_nsc_ProcessKilling);

            _nsc.StartControl(this);

        }

        void _nsc_ProcessKilling(object sender, ProcessKillEventArgs e)
        {

            // 2015/08/07 ADD ���� SCM�|�b�v�A�b�v�̃v���Z�X�����s���̏ꍇ�͋����I������ -------->>>>>>>>>>
            // SCM�|�b�v�A�b�v�̃v���Z�X�����s���̏ꍇ�͋����I������B
            System.Diagnostics.Process[] processList = System.Diagnostics.Process.GetProcessesByName("PMSCM00005U");
            foreach (System.Diagnostics.Process process in processList)
            {
                try
                {
                    process.Kill();
                }
                catch
                {
                    // process�I�����A�I���ς̏ꍇ�Aexception�����������ۂ̎����[�v�p
                }
            }
            // 2015/08/07 ADD ���� SCM�|�b�v�A�b�v�̃v���Z�X�����s���̏ꍇ�͋����I������ --------<<<<<<<<<<
            if ((e.Reason.IndexOf("RESUME") >= 0) || (e.Reason.IndexOf("LIMITDATE") >= 0))
            {
                _SpecialKilled = true;
                _KilledReason = e.ReasonMessage;
            }
            
        }

        /// <summary>
        /// �t�H�[���N���[�Y�O�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFCMN00047UAF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Finish == true)
            {
                // �A�C�R�����g���C�����菜��
                TTraynotifyIcon.Visible = false;
            }
            else
            {
                //  �^�X�N�g���C�Ɏd����
                e.Cancel = true;
                Visible = false;
                _Visible = false;

            }

        }

        /// <summary>
        /// �\�����j���[�N���b�N���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuShow_Click(object sender, EventArgs e)
        {

            _Visible = true;
            Visible = true;

            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal; // �ŏ�������߂�
            }

            //  �r���o�ߕ�
            string actionType = "";
            string startDate = "";
            string onTheWayTime = "";
            string endDate = "";

            _nsc.GetStatus(ref actionType, ref startDate, ref onTheWayTime, ref endDate);

            if (actionType.IndexOf("Date") > -1)
            {

                lblMsg.Text = "�V�X�e�������e�i���X��\n\n   �y" + endDate + "�z\n\n�ɗ\�肳��Ă��܂��B\n\n�����A��L�̎��_�Ń��O�C�����Ă���ꍇ�A\n�����I�Ƀ��O�I�t����܂��̂ł����ӂ��������B";
            }
            else
            {
                lblMsg.Text = "NS��ƃ��O�C������@" + onTheWayTime + " �o�߂��Ă��܂��B\n\n���̂܂܃��O�I�t���Ȃ��ꍇ�A\n\n   �y" + endDate + "�z\n\n�Ɏ������O�I�t����܂��B";
            }

            //  ���b�Z�[�W�ɍ��킹�ăt�H�[���T�C�Y����
            SetClientSizeCore(lblMsg.Size.Width + (lblMsg.Left * 2), lblMsg.Size.Height + (lblMsg.Top * 2));

            //  �\��
            Show();

            // �t�H�[�����A�N�e�B�u�ɂ���
            Activate();
        }

        /// <summary>
        /// �t�H�[���A�N�e�B�u���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFCMN00047UAF_Activated(object sender, EventArgs e)
        {
            //  ��\���ݒ�Ȃ�A�B�ꂽ�܂�
            if (_Visible == false)
            {
                this.Visible = false; // �t�H�[���̕\��
            }

        }

        /// <summary>
        /// �t�H�[�����T�C�Y���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFCMN00047UAF_Resize(object sender, EventArgs e)
        {
            //  �ŏ����w��Ȃ�A�^�X�N�g���C�ɉB���
            if (WindowState == FormWindowState.Minimized)
            {
                _Visible = false;
                Visible = false;
            }
        }

        /// <summary>
        /// �t�H�[���I�����\�b�h(Program.cs����R�[��)
        /// </summary>
        /// <remarks>
        /// <br>Note       :���[�U�[�A�C�e���擾</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2008.08.29</br>
        /// </remarks>
        public void CloseWindow()
        {
            _Finish = true;
            Close();
        }

    }
}