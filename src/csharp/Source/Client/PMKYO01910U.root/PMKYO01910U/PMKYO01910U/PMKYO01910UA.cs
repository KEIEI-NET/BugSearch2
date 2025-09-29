//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��M�G���[�`�F�b�N����
// �v���O�����T�v   : ���[�U�f�[�^�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2011/07/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// �G���[�\���t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �G���[�\���̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2011.07.28</br>
    /// </remarks>
    public partial class PMKYO01910UA : Form
    {
        #region private
        private const int DEFAULT_X = 100000;//�f�t�H���gx���W
        private const int DEFAULT_Y = 100000;//�f�t�H���gy���W

        private const string MSG_NO_NEW_ORDER = "������M�G���[���͂���܂���";
        private const string MSG_NEW_ORDER = "������M�G���[��� {0} ������܂�";
        private const string CTFILE_UISETTING = "UISetting_PMKYO01100U.xml";

        private OprtnHisLogAcs _logAcs = new OprtnHisLogAcs();
        private ArrayList _errInfoList = new ArrayList();
        private const double CT_FORM_OPACITY = 0.92;
        private const int INTERVAL_DEFAULT = 3600000;
        private bool _hasErrorInfo = false;
        #endregion

        #region <�R�}���h���C������>

        /// <summary>�R�}���h���C������</summary>
        private readonly string[] _commandLineArgs;
        /// <summary>�R�}���h���C���������擾���܂��B</summary>
        private string[] CommandLineArgs { get { return _commandLineArgs; } }

        #endregion // </�R�}���h���C������>

        #region <�t�H�[������锻��>

        /// <summary>�t�H�[������锻��t���O</summary>
        private bool _canClose;
        /// <summary>�t�H�[������锻��t���O�̃A�N�Z�T</summary>
        private bool CanClose
        {
            get { return _canClose; }
            set { _canClose = value; }
        }

        #endregion // </�t�H�[������锻��>

        #region �C�x���g
        /// <summary>
        /// �G���[����
        /// </summary>
        /// <param name="commandLineArgs"></param>
        public PMKYO01910UA(string[] commandLineArgs)
        {
            InitializeComponent();
            _commandLineArgs = commandLineArgs;
        }

        /// <summary>
        /// �G���[���ו\��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UltraButton_Detail_Click(object sender, EventArgs e)
        {
            try
            {
                if (_errInfoList.Count > 0)
                {
                    //�G���[�ڂ�����ʂ�\��
                    PMKYO01900UA form = new PMKYO01900UA(_errInfoList);
                    form.Show();

                    //���O�����W�b�N�폜
                    _logAcs.LogicalDelete();

                    //�ϐ��������ɂȂ�
                    _hasErrorInfo = false;
                    _errInfoList = new ArrayList();
                }                
            }
            catch { }
        }

        /// <summary>
        /// �I��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UltraButton_Close_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch { }
        }

        /// <summary>
        /// ���Load
        /// </summary>
        private void PMKYO01910UA_Load(object sender, EventArgs e)
        {
            // �����\���͉B��
            SetVisibleState(false);

            // �����ʒu��ݒ�i������h�~�ׁ̈A10000�ɂ��Ă��܂��j
            SetDesktopBounds(DEFAULT_X, DEFAULT_Y, Width, Height);

            //�����`�F�b�N
            SerachLog();

            //�����`�F�b�N��ݒ�
            check_timer.Enabled = true;
            check_timer.Interval = GetInterval();
            
        }

        /// <summary>
        /// ��ʂ���܂��B
        /// </summary>
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            DialogResult dResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_QUESTION,
                this.Name,
                "������M�G���[��񏈗����I�����܂��B\r\n" +
                "�I�����Ă���낵���ł����H",
                0,
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button1);

            if (dResult == DialogResult.No) return;
            
            CanClose = true;
            Close();
        }

        /// <summary>
        /// �p�g�����v�A�C�R����MouseClick�C�x���g�n���h��
        /// </summary>
        /// <remarks>��ʂ�\�����܂��B</remarks>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void PatoLampNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (!e.Button.Equals(MouseButtons.Left)) return;
            if (_hasErrorInfo)
            {
                SetVisibleState(true);
            }
        }

        /// <summary>
        /// �p�g�����v�A�C�R����MouseMove�C�x���g�n���h��
        /// </summary>
        /// <remarks>����\�����܂��B</remarks>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void PatoLampNotifyIcon_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (_errInfoList.Count > 0)
                {
                    this.patoLampNotifyIcon.Text = string.Format(MSG_NEW_ORDER, _errInfoList.Count);
                }
                else
                {
                    this.patoLampNotifyIcon.Text = MSG_NO_NEW_ORDER;
                }
            }
            catch { }
        }

        /// <summary>
        /// ��ʓ��ߗ��ݒ菈��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void Close_Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                this.Opacity = this.Opacity - 0.02;
            }
            catch (Exception)
            {
                this.Opacity = 0.0;
            }
            finally
            {
                if (this.Opacity <= 0.0)
                {
                    this.Visible = false;

                    // ���ߗ������ɖ߂��Ă���
                    this.Opacity = CT_FORM_OPACITY;

                    this.close_Timer.Enabled = false;
                }
            }
        }

        /// <summary>
        /// ����`�F�b�N���s�^�C�}�[����
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void Check_timer_Tick(object sender, EventArgs e)
        {
            try
            {
                SerachLog();
            }
            catch { }
        }

        /// <summary>
        /// �t�H�[����FormClosing�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void PMKYO01910U_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CanClose)
            {
                if (e.CloseReason.Equals(CloseReason.UserClosing))
                {
                    // �Ӑ}�I�ȏI���ȊO�̓L�����Z�����ăA�C�R�����i�t�H�[�����\���ɂ���j
                    e.Cancel = true; // �I�������̃L�����Z��
                    this.close_Timer.Enabled = true;
                    return;
                }
            }
        }
        #endregion

        #region private�@���\�b�h
        /// <summary>
        /// �Ԋu���Ԃ��擾���܂��B
        /// </summary>
        private int GetInterval()
        {
            int interval = 0;
            try
            {                
                string path = ConstantManagement_ClientDirectory.UISettings + "\\" + CTFILE_UISETTING;
                if (File.Exists(path))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(path);

                    //�Ԋu���ԁi���j���~���b�ɕς���
                    interval = Convert.ToInt32(ds.Tables["add"].Rows[0]["value"].ToString()) * 60 * 1000;
                }
                return interval;
            }
            catch
            {
                interval = INTERVAL_DEFAULT;
                return interval;
            }
        }

        /// <summary>
        /// �\����Ԃ�ݒ肵�܂��B
        /// </summary>
        /// <param name="visible">�\���t���O</param>
        private void SetVisibleState(bool visible)
        {
            if (visible)
            {
                SetInitialPosition();
                Visible = true;
                TopMost = true;
                Activate();
                TopMost = false;
            }
            else
            {
                Visible = false;
            }
        }

        /// <summary>
        /// �����N���ʒu��ݒ肵�܂��B
        /// </summary>
        private void SetInitialPosition()
        {
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenheigth = Screen.PrimaryScreen.WorkingArea.Height;
            int appWidth = Width;
            int appHeight = Height;
            int appLeftXPos = screenWidth - appWidth;
            int appLeftYPos = screenheigth - appHeight;

            SetDesktopBounds(appLeftXPos, appLeftYPos, appWidth, appHeight);
        }

        /// <summary>
        /// �G���[���O����
        /// </summary>
        private void SerachLog()
        {
            try
            {
                //DO CHECK
                _logAcs.SearchLog(out _errInfoList);
                if (_errInfoList.Count > 0)
                {
                    _hasErrorInfo = true;
                    this.SetVisibleState(true);
                }
                else
                {
                    _hasErrorInfo = false;
                }
            }
            catch { }
        }
        #endregion
    }
}