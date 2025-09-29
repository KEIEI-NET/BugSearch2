//****************************************************************************//
// �V�X�e��         : �񓚑��M����
// �v���O��������   : ���O�\�����
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21112 �v�ۓc ��
// �� �� ��  2011/06/01  �C�����e : ���O�̈Í����ɔ����A�\����ʂ�V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���O�\����ʃt�H�[��
    /// </summary>
    public partial class PMSCM01101UD : Form
    {
        private string _LogFilePath = string.Empty;
        private string _FileNameFormat = string.Empty;
        private DateTime _prevDate;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private const int WM_SETREDRAW = 0x000B;
        private const int Win32False = 0;
        private const int Win32True = 1;

        /// <summary>
        /// DateTimePicker �� ToolStrip �ɔz�u����ׂ̃R���g���[�� �z�X�g
        /// </summary>
        private ToolStripControlHost toolStripDateTimePicker;

        /// <summary>
        /// PMSCM01101UD�R���X�g���N�^
        /// </summary>
        /// <param name="path">���O�ۑ���p�X��ݒ�</param>
        /// <param name="format">���O�t�@�C�����̏�����ݒ�</param>
        public PMSCM01101UD(string path, string format)
        {
            InitializeComponent();
            _LogFilePath = path;
            _FileNameFormat = format;

            toolStripDateTimePicker = new ToolStripControlHost(dateTimePicker1);
            toolStrip1.Items.Insert(1, toolStripDateTimePicker);

            toolStrip1.ImageList = IconResourceManagement.ImageList32;
            toolStrip1.Items["tsbRefresh"].ImageIndex = (int)Size32_Index.RENEWAL;

            _prevDate = DateTime.Now;
        }

        /// <summary>
        /// ���O��ʂ�\�����܂�
        /// </summary>
        public new void Show()
        {
            base.Show();

            System.Windows.Forms.Application.DoEvents();

            // ���O�̕\��
            // ��ʍĕ\���̏ꍇ�͑O��\�����Ă������O���ēǍ����܂��B
            this.LoadLogFile(_prevDate, true);
        }

        /// <summary>
        /// ���O�t�@�C����ǂݍ��݁A���������ĕ\�����܂��B
        /// </summary>
        /// <param name="targetDate">�\�����郍�O�t�@�C���̓��t��ݒ�</param>
        /// <param name="update">�X�V�\���t���O</param>
        private void LoadLogFile(DateTime targetDate, bool update)
        {
            // �O��\���������O�t�@�C��(�N��)�Ɣ�r���A�قȂ��Ă���ꍇ�ɂ̂݃t�@�C����ǂݍ��ݒ����܂��B
            // �A�� update �� true �̏ꍇ�͖������œǍ��ݒ����܂��B
            // ���J�����_�[�œ�(����N��)��ς���x�Ƀt�@�C����ǂݍ��ނ͔̂�����Ȉ�
            bool reload = !_prevDate.ToString("yyyyMM").Equals(targetDate.ToString("yyyyMM")) || update;

            _prevDate = targetDate;

            if (reload)
            {
                string strLog = string.Empty;

                try
                {
                    string file = String.Format(_FileNameFormat, targetDate);
                    string path = Path.Combine(_LogFilePath, file);

                    // ���O�t�@�C���̓Ǎ�
                    // ���O�t�@�C���� PMSCM01103A.DLL �����J���Ă���̂ŁAFileShare.ReadWrite ���w�肵�ĊJ���K�v������
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 1024, FileOptions.SequentialScan))
                    {
                        using (TextReader txtReader = new StreamReader(fs, Encoding.GetEncoding("shift-jis")))
                        {
                            StringBuilder sbLog = new StringBuilder(1024);

                            while (txtReader.Peek() > -1)
                            {
                                // Base64�ɂ�镜����
                                byte[] bin = Convert.FromBase64String(txtReader.ReadLine());
                                sbLog.Append(Encoding.GetEncoding("shift-jis").GetString(bin));
                                sbLog.Append(Environment.NewLine);
                            }

                            strLog = sbLog.ToString();
                        }
                    }
                }
                catch (Exception e)
                {
                    // ��O�͂��̂܂ܕ\������(�J���҂��g�p����v�f�������̂�)
                    strLog = e.Message;
                }

                this.tbxLogDisplay.Text = strLog;
            }

            // ���O��ǂ��Ղ�����ׁA�Y�����t�ɃL�����b�g���ړ�����
            int index = this.tbxLogDisplay.Text.IndexOf(string.Format("{0:yyyy/MM/dd}", targetDate));

            if (index > -1)
            {
                this.tbxLogDisplay.SelectionStart = index;
                this.tbxLogDisplay.SelectionLength = 10;
                this.tbxLogDisplay.ScrollToCaret();
            }
        }

        /// <summary>
        /// ���O�\����ʃt�H�[����FormClosing�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void PMSCM01101UD_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sender == this)
            {
                e.Cancel = true;
                
                // �ʏ�͕�����(���������)��\���Ƃ���B
                this.Hide();
            }
        }

        /// <summary>
        /// ���O�\����ʃt�H�[����KeyDown�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void PMSCM01101UD_KeyDown(object sender, KeyEventArgs e)
        {
            // ESC�L�[�����ɂ��A���O�\����ʂ��\���ɂ���B
            if (e.KeyData == Keys.Escape)
            {
                this.Hide();
            }
        }

        /// <summary>
        /// DateTimePicker��ValueChanged�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // ���O�t�@�C����ǂݍ��ݒ����A�A�����݊J���Ă���t�@�C����
            // �Ώ۔N���������ꍇ�͓Ǎ��ݒ������A�L�����b�g�̈ړ��݂̂Ƃ���B
            this.LoadLogFile(dateTimePicker1.Value, false);
        }

        /// <summary>
        /// �X�V�{�^����Click�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            // �ŐV���ɍX�V����
            this.LoadLogFile(dateTimePicker1.Value, true);
        }
    }
}