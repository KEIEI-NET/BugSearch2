using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
    public partial class DCHNB04180UD : Form
    {
        public DCHNB04180UD()
        {
            InitializeComponent();

            this._imageList16 = IconResourceManagement.ImageList16;
        }

        private ImageList _imageList16 = null;

        public List<string> _titleList;
        public List<int> _graphPara;
        public List<int> _graphShow;

        // �O���t��ʋ敪
        private const string GRAPH_LINE = "�܂���O���t";
        private const string GRAPH_BAR = "�_�O���t";
        private const string GRAPH_PIE = "�~�O���t";

        // �Ώۍ��ڑI���ő匏��
        private const int CHKMAXCOUNT = 10;

        /// <summary>
        /// �ďo���䏈��
        /// </summary>
        /// <param name="owner">�ďo���I�u�W�F�N�g</param>
        public DialogResult ShowWindows(IWin32Window owner)
        {
            // ��ʂ̐ݒ�
            this.ShowInTaskbar = false;

            return this.ShowDialog(owner);
        }

        # region ��Main
        /// <summary>�A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B</summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new DCHNB04180UD());
        }
        # endregion

        /// <summary>
        /// Control.Click �C�x���g(Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : 980035 ����  ��`</br>
        /// <br>Date        : 2007.10.26</br>
        /// </remarks>
        private void Ok_ultraButton_Click(object sender, EventArgs e)
        {
            int chkflg = 0;
            for (int ix = 0; ix < _graphShow.Count; ix++)
            {
                switch (ix)
                {
                    case 0: { if (this.uCheckEditor_Para01.Checked == true) chkflg++; break; }
                    case 1: { if (this.uCheckEditor_Para02.Checked == true) chkflg++; break; }
                    case 2: { if (this.uCheckEditor_Para03.Checked == true) chkflg++; break; }
                    case 3: { if (this.uCheckEditor_Para04.Checked == true) chkflg++; break; }
                    case 4: { if (this.uCheckEditor_Para05.Checked == true) chkflg++; break; }
                    case 5: { if (this.uCheckEditor_Para06.Checked == true) chkflg++; break; }
                    case 6: { if (this.uCheckEditor_Para07.Checked == true) chkflg++; break; }
                    case 7: { if (this.uCheckEditor_Para08.Checked == true) chkflg++; break; }
                    case 8: { if (this.uCheckEditor_Para09.Checked == true) chkflg++; break; }
                    case 9: { if (this.uCheckEditor_Para10.Checked == true) chkflg++; break; }
                }
            }
            if (chkflg == 0)
            {
                return;
            }

            this.DialogResult = DialogResult.Cancel;

            _graphPara[0] = this.tComboEditor_GraphStyle.SelectedIndex;

            if ((_graphShow != null) && (_graphShow.Count != 0))
            {
                for (int ix = 0; ix < _graphShow.Count; ix++) _graphShow[ix] = 0;
                for (int ix = 0; ix < _graphShow.Count; ix++)
                {
                    switch (ix)
                    {
                        case 0: { if (this.uCheckEditor_Para01.Checked == true) _graphShow[ix] = 1; break; }
                        case 1: { if (this.uCheckEditor_Para02.Checked == true) _graphShow[ix] = 1; break; }
                        case 2: { if (this.uCheckEditor_Para03.Checked == true) _graphShow[ix] = 1; break; }
                        case 3: { if (this.uCheckEditor_Para04.Checked == true) _graphShow[ix] = 1; break; }
                        case 4: { if (this.uCheckEditor_Para05.Checked == true) _graphShow[ix] = 1; break; }
                        case 5: { if (this.uCheckEditor_Para06.Checked == true) _graphShow[ix] = 1; break; }
                        case 6: { if (this.uCheckEditor_Para07.Checked == true) _graphShow[ix] = 1; break; }
                        case 7: { if (this.uCheckEditor_Para08.Checked == true) _graphShow[ix] = 1; break; }
                        case 8: { if (this.uCheckEditor_Para09.Checked == true) _graphShow[ix] = 1; break; }
                        case 9: { if (this.uCheckEditor_Para10.Checked == true) _graphShow[ix] = 1; break; }
                    }
                }
            }
            else
            {
                for (int ix = 0; ix < CHKMAXCOUNT; ix++) _graphShow.Add(0);
                if (this.uCheckEditor_Para01.Checked == true) _graphShow[0] = 1;
                if (this.uCheckEditor_Para02.Checked == true) _graphShow[1] = 1;
                if (this.uCheckEditor_Para03.Checked == true) _graphShow[2] = 1;
                if (this.uCheckEditor_Para04.Checked == true) _graphShow[3] = 1;
                if (this.uCheckEditor_Para05.Checked == true) _graphShow[4] = 1;
                if (this.uCheckEditor_Para06.Checked == true) _graphShow[5] = 1;
                if (this.uCheckEditor_Para07.Checked == true) _graphShow[6] = 1;
                if (this.uCheckEditor_Para08.Checked == true) _graphShow[7] = 1;
                if (this.uCheckEditor_Para09.Checked == true) _graphShow[8] = 1;
                if (this.uCheckEditor_Para10.Checked == true) _graphShow[9] = 1;
            }

            this.Close();
            //this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Ok_ultraButton.ImageList = this._imageList16;
            this.Ok_ultraButton.Appearance.Image = Size16_Index.DECISION;

            // �O���t��ʂ̺����ޯ���ɏ��Z�b�g
            this.tComboEditor_GraphStyle.Items.Clear();
            this.tComboEditor_GraphStyle.Items.Add(0, GRAPH_BAR);
            //this.tComboEditor_GraphStyle.Items.Add(1, GRAPH_LINE);
            //this.tComboEditor_GraphStyle.Items.Add(2, GRAPH_PIE);
            this.tComboEditor_GraphStyle.Items.Add(1, GRAPH_PIE);
            this.tComboEditor_GraphStyle.MaxDropDownItems = this.tComboEditor_GraphStyle.Items.Count;
            if ((_graphPara != null) && (_graphPara.Count != 0))
            {
                this.tComboEditor_GraphStyle.SelectedIndex = _graphPara[0];
                this._graphPara[0] = -1;
            }
            else
            {
                this.tComboEditor_GraphStyle.SelectedIndex = 0;
                this._graphPara.Add(-1);
            }

            // �Ώۍ��ڃ^�C�g�����Z�b�g
            for (int ix = 0; ix < _titleList.Count; ix++)
            {
                switch (ix)
                {
                    case 0: { this.uCheckEditor_Para01.Text = _titleList[ix].ToString(); break; }
                    case 1: { this.uCheckEditor_Para02.Text = _titleList[ix].ToString(); break; }
                    case 2: { this.uCheckEditor_Para03.Text = _titleList[ix].ToString(); break; }
                    case 3: { this.uCheckEditor_Para04.Text = _titleList[ix].ToString(); break; }
                    case 4: { this.uCheckEditor_Para05.Text = _titleList[ix].ToString(); break; }
                    case 5: { this.uCheckEditor_Para06.Text = _titleList[ix].ToString(); break; }
                    case 6: { this.uCheckEditor_Para07.Text = _titleList[ix].ToString(); break; }
                    case 7: { this.uCheckEditor_Para08.Text = _titleList[ix].ToString(); break; }
                    case 8: { this.uCheckEditor_Para09.Text = _titleList[ix].ToString(); break; }
                    case 9: { this.uCheckEditor_Para10.Text = _titleList[ix].ToString(); break; }
                }
            }
            for (int ix = _titleList.Count; ix < CHKMAXCOUNT; ix++)
            {
                switch (ix)
                {
                    case 0: { this.uCheckEditor_Para01.Visible = false; break; }
                    case 1: { this.uCheckEditor_Para02.Visible = false; break; }
                    case 2: { this.uCheckEditor_Para03.Visible = false; break; }
                    case 3: { this.uCheckEditor_Para04.Visible = false; break; }
                    case 4: { this.uCheckEditor_Para05.Visible = false; break; }
                    case 5: { this.uCheckEditor_Para06.Visible = false; break; }
                    case 6: { this.uCheckEditor_Para07.Visible = false; break; }
                    case 7: { this.uCheckEditor_Para08.Visible = false; break; }
                    case 8: { this.uCheckEditor_Para09.Visible = false; break; }
                    case 9: { this.uCheckEditor_Para10.Visible = false; break; }
                }
            }

            // �Ώۍ��ڑI�����Z�b�g
            if ((_graphShow != null) && (_graphShow.Count != 0))
            {
                for (int ix = 0; ix < CHKMAXCOUNT; ix++)
                {
                    if (ix < this._graphShow.Count)
                    {
                        switch (ix)
                        {
                            case 0: { if (_graphShow[ix] == 0) this.uCheckEditor_Para01.Checked = false; break; }
                            case 1: { if (_graphShow[ix] == 0) this.uCheckEditor_Para02.Checked = false; break; }
                            case 2: { if (_graphShow[ix] == 0) this.uCheckEditor_Para03.Checked = false; break; }
                            case 3: { if (_graphShow[ix] == 0) this.uCheckEditor_Para04.Checked = false; break; }
                            case 4: { if (_graphShow[ix] == 0) this.uCheckEditor_Para05.Checked = false; break; }
                            case 5: { if (_graphShow[ix] == 0) this.uCheckEditor_Para06.Checked = false; break; }
                            case 6: { if (_graphShow[ix] == 0) this.uCheckEditor_Para07.Checked = false; break; }
                            case 7: { if (_graphShow[ix] == 0) this.uCheckEditor_Para08.Checked = false; break; }
                            case 8: { if (_graphShow[ix] == 0) this.uCheckEditor_Para09.Checked = false; break; }
                            case 9: { if (_graphShow[ix] == 0) this.uCheckEditor_Para10.Checked = false; break; }
                        }
                    }
                }
            }
        }
    }
}