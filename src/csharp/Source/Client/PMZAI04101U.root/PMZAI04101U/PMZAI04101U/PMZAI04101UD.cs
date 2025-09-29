using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Broadleaf.Library.Resources;

// 2010/04/30 Add >>>
using System.IO;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
// 2010/04/30 Add <<<

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
        // 2010/04/30 Add >>>
        public int _graphId;
        public bool _changeflg = true;
        public List<int> _graphPara2;
        // 2010/04/30 Add <<<

        // �O���t��ʋ敪
        private const string GRAPH_LINE = "�܂���O���t";
        private const string GRAPH_BAR = "�_�O���t";
        private const string GRAPH_PIE = "�~�O���t";

        // 2010/04/30 Add >>>
        private const string GRAPH_RADAR = "���[�_�[";
        private const string GRAPH_LINEBAR = "�܂���{�_�O���t";

        private const string GRAPH_LINE_L = "�܂���O���t(��)";
        private const string GRAPH_LINE_S = "�܂���O���t(��)";
        private const string GRAPH_BAR_L = "�_�O���t(��)";
        private const string GRAPH_BAR_S = "�_�O���t(��)";

        private const string GRAPH_MONEY = "�i���z�j";
        private const string GRAPH_COUNT = "�i�񐔁j";
        private const string GRAPH_QUANTITY = "�i���ʁj";

        private const string COL_SALESTIMES = "�����";
        private const string COL_SALESCOUNT = "���㐔";
        private const string COL_SALESMONEY = "������z";
        private const string COL_STOCKTIMES = "�d����";
        private const string COL_STOCKCOUNT = "�d����";
        private const string COL_STOCKMONEY = "�d�����z";
        private const string COL_GRPROFIT = "�e�����z";
        private const string COL_MOVEACOUNT = "�ړ����א�";
        private const string COL_MOVEAPRICE = "�ړ����׊z";
        private const string COL_MOVESCOUNT = "�ړ��o�א�";
        private const string COL_MOVESPRICE = "�ړ��o�׊z";
        // 2010/04/30 Add <<<

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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2010/02/18</br>
        /// </remarks>
        private void Ok_ultraButton_Click(object sender, EventArgs e)
        {
            int chkflg = 0;
            for (int ix = 0; ix < 9; ix++)
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
                }
            }
            if (chkflg == 0)
            {
                return;
            }

            this.DialogResult = DialogResult.Cancel;

            int flg;
            if ((_graphPara != null) && (_graphPara.Count != 0))
            {
                _graphPara[0] = this.tComboEditor_GraphStyle.SelectedIndex; // 2010/04/30 Add

                int iCnt = 1;
                for (int ix = 1; ix < _graphPara.Count; ix++)
                {
                    if (_graphPara[ix] == -1)
                    {
                        _graphPara[ix] = 1;
                        continue;
                    }
                    if (_graphPara[ix] != -1)
                    {
                        if (iCnt == 1)
                        {
                            if (this.uCheckEditor_Para01.Checked == true) _graphPara[ix] = 0;
                            else _graphPara[ix] = 1;
                            // 2010/04/30 Add >>>
                            if (this.tComboEditor1.SelectedIndex == -1) _graphPara2[ix] = 2;
                            else _graphPara2[ix] = this.tComboEditor1.SelectedIndex;
                            // 2010/04/30 Add <<<
                        }
                        if (iCnt == 2)
                        {
                            if (this.uCheckEditor_Para02.Checked == true) _graphPara[ix] = 0;
                            else _graphPara[ix] = 1;
                            // 2010/04/30 Add >>>
                            if (this.tComboEditor2.SelectedIndex == -1) _graphPara2[ix] = 2;
                            else _graphPara2[ix] = this.tComboEditor2.SelectedIndex;
                            // 2010/04/30 Add <<<
                        }
                        if (iCnt == 3)
                        {
                            if (this.uCheckEditor_Para03.Checked == true) _graphPara[ix] = 0;
                            else _graphPara[ix] = 1;
                            // 2010/04/30 Add >>>
                            if (this.tComboEditor3.SelectedIndex == -1) _graphPara2[ix] = 2;
                            else _graphPara2[ix] = this.tComboEditor3.SelectedIndex;
                            // 2010/04/30 Add <<<
                        }
                        if (iCnt == 4)
                        {
                            if (this.uCheckEditor_Para04.Checked == true) _graphPara[ix] = 0;
                            else _graphPara[ix] = 1;
                            // 2010/04/30 Add >>>
                            if (this.tComboEditor4.SelectedIndex == -1) _graphPara2[ix] = 2;
                            else _graphPara2[ix] = this.tComboEditor4.SelectedIndex;
                            // 2010/04/30 Add <<<
                        }
                        if (iCnt == 5)
                        {
                            if (this.uCheckEditor_Para05.Checked == true) _graphPara[ix] = 0;
                            else _graphPara[ix] = 1;
                            // 2010/04/30 Add >>>
                            if (this.tComboEditor5.SelectedIndex == -1) _graphPara2[ix] = 2;
                            else _graphPara2[ix] = this.tComboEditor5.SelectedIndex;
                            // 2010/04/30 Add <<<
                        }
                        if (iCnt == 6)
                        {
                            if (this.uCheckEditor_Para06.Checked == true) _graphPara[ix] = 0;
                            else _graphPara[ix] = 1;
                            // 2010/04/30 Add >>>
                            if (this.tComboEditor6.SelectedIndex == -1) _graphPara2[ix] = 2;
                            else _graphPara2[ix] = this.tComboEditor6.SelectedIndex;
                            // 2010/04/30 Add <<<
                        }
                        if (iCnt == 7)
                        {
                            if (this.uCheckEditor_Para07.Checked == true) _graphPara[ix] = 0;
                            else _graphPara[ix] = 1;
                            // 2010/04/30 Add >>>
                            if (this.tComboEditor7.SelectedIndex == -1) _graphPara2[ix] = 2;
                            else _graphPara2[ix] = this.tComboEditor7.SelectedIndex;
                            // 2010/04/30 Add <<<
                        }
                        if (iCnt == 8)
                        {
                            if (this.uCheckEditor_Para08.Checked == true) _graphPara[ix] = 0;
                            else _graphPara[ix] = 1;
                            // 2010/04/30 Add >>>
                            if (this.tComboEditor8.SelectedIndex == -1) _graphPara2[ix] = 2;
                            else _graphPara2[ix] = this.tComboEditor8.SelectedIndex;
                            // 2010/04/30 Add <<<
                        }
                        if (iCnt == 9)
                        {
                            if (this.uCheckEditor_Para09.Checked == true) _graphPara[ix] = 0;
                            else _graphPara[ix] = 1;
                            // 2010/04/30 Add >>>
                            if (this.tComboEditor9.SelectedIndex == -1) _graphPara2[ix] = 2;
                            else _graphPara2[ix] = this.tComboEditor9.SelectedIndex;
                            // 2010/04/30 Add <<<
                        }
                        iCnt++;
                    }
                }
            }
            else
            {
                _graphPara.Add(this.tComboEditor_GraphStyle.SelectedIndex);
                if (this.uCheckEditor_Para01.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para02.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para03.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para04.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para05.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para06.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para07.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para08.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);
                if (this.uCheckEditor_Para09.Checked == true) flg = 0;
                else flg = 1;
                _graphPara.Add(flg);

                // 2010/04/30 Add >>>
                _graphPara2.Add(_graphId);
                if (this.tComboEditor1.SelectedIndex != -1) flg = this.tComboEditor1.SelectedIndex;
                else flg = 2;
                _graphPara2.Add(flg);
                if (this.tComboEditor2.SelectedIndex != -1) flg = this.tComboEditor2.SelectedIndex;
                else flg = 2;
                _graphPara2.Add(flg);
                if (this.tComboEditor3.SelectedIndex != -1) flg = this.tComboEditor3.SelectedIndex;
                else flg = 2;
                _graphPara2.Add(flg);
                if (this.tComboEditor4.SelectedIndex != -1) flg = this.tComboEditor4.SelectedIndex;
                else flg = 2;
                _graphPara2.Add(flg);
                if (this.tComboEditor5.SelectedIndex != -1) flg = this.tComboEditor5.SelectedIndex;
                else flg = 2;
                _graphPara2.Add(flg);
                if (this.tComboEditor6.SelectedIndex != -1) flg = this.tComboEditor6.SelectedIndex;
                else flg = 2;
                _graphPara2.Add(flg);
                if (this.tComboEditor7.SelectedIndex != -1) flg = this.tComboEditor7.SelectedIndex;
                else flg = 2;
                _graphPara2.Add(flg);
                if (this.tComboEditor8.SelectedIndex != -1) flg = this.tComboEditor8.SelectedIndex;
                else flg = 2;
                _graphPara2.Add(flg);
                if (this.tComboEditor9.SelectedIndex != -1) flg = this.tComboEditor9.SelectedIndex;
                else flg = 2;
                _graphPara2.Add(flg);
                // 2010/04/30 Add <<<
            }

            // 2010/04/30 Add >>>
            List<List<int>> saveList = new List<List<int>>();
            saveList.Add(_graphPara);
            saveList.Add(_graphPara2);
            SaveToFiles(saveList);
            // 2010/04/30 Add <<<

            this.Close();
            //this.Hide();
        }

        internal static void ShowWindows(AnalysisChartViewForm dCHNB04180UB)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Ok_ultraButton.ImageList = this._imageList16;
            this.Ok_ultraButton.Appearance.Image = Size16_Index.DECISION;

            this.uCheckEditor_Para01.Text = string.Empty;
            this.uCheckEditor_Para02.Text = string.Empty;
            this.uCheckEditor_Para03.Text = string.Empty;
            this.uCheckEditor_Para04.Text = string.Empty;
            this.uCheckEditor_Para05.Text = string.Empty;
            this.uCheckEditor_Para06.Text = string.Empty;
            this.uCheckEditor_Para07.Text = string.Empty;
            this.uCheckEditor_Para08.Text = string.Empty;
            this.uCheckEditor_Para09.Text = string.Empty;

            // 2010/04/30 Add >>>
            this.uCheckEditor_Para01.Visible = true;
            this.uCheckEditor_Para02.Visible = true;
            this.uCheckEditor_Para03.Visible = true;
            this.uCheckEditor_Para04.Visible = true;
            this.uCheckEditor_Para05.Visible = true;
            this.uCheckEditor_Para06.Visible = true;
            this.uCheckEditor_Para07.Visible = true;
            this.uCheckEditor_Para08.Visible = true;
            this.uCheckEditor_Para09.Visible = true;

            if (this.tComboEditor_GraphStyle.SelectedIndex == 4 || this.tComboEditor_GraphStyle.SelectedIndex == 5)
            {
                this.tComboEditor1.Visible = true;
                this.tComboEditor2.Visible = true;
                this.tComboEditor3.Visible = true;
                this.tComboEditor4.Visible = true;
                this.tComboEditor5.Visible = true;
                this.tComboEditor6.Visible = true;
                this.tComboEditor7.Visible = true;
                this.tComboEditor8.Visible = true;
                this.tComboEditor9.Visible = true;
            }
            else
            {
                this.tComboEditor1.Visible = false;
                this.tComboEditor2.Visible = false;
                this.tComboEditor3.Visible = false;
                this.tComboEditor4.Visible = false;
                this.tComboEditor5.Visible = false;
                this.tComboEditor6.Visible = false;
                this.tComboEditor7.Visible = false;
                this.tComboEditor8.Visible = false;
                this.tComboEditor9.Visible = false;
            }
            // 2010/04/30 Add <<<

            if (_titleList.Count > 0) this.uCheckEditor_Para01.Text = _titleList[0].ToString();
            else
            {
                this.uCheckEditor_Para01.Visible = false;
                this.uCheckEditor_Para01.Checked = false;
                this.tComboEditor1.Visible = false; // 2010/04/30 Add
            }
            if (_titleList.Count > 1) this.uCheckEditor_Para02.Text = _titleList[1].ToString();
            else
            {
                this.uCheckEditor_Para02.Visible = false;
                this.uCheckEditor_Para02.Checked = false;
                this.tComboEditor2.Visible = false; // 2010/04/30 Add
            }
            if (_titleList.Count > 2) this.uCheckEditor_Para03.Text = _titleList[2].ToString();
            else
            {
                this.uCheckEditor_Para03.Visible = false;
                this.uCheckEditor_Para03.Checked = false;
                this.tComboEditor3.Visible = false; // 2010/04/30 Add
            }
            if (_titleList.Count > 3) this.uCheckEditor_Para04.Text = _titleList[3].ToString();
            else
            {
                this.uCheckEditor_Para04.Visible = false;
                this.uCheckEditor_Para04.Checked = false;
                this.tComboEditor4.Visible = false; // 2010/04/30 Add
            }
            if (_titleList.Count > 4) this.uCheckEditor_Para05.Text = _titleList[4].ToString();
            else
            {
                this.uCheckEditor_Para05.Visible = false;
                this.uCheckEditor_Para05.Checked = false;
                this.tComboEditor5.Visible = false; // 2010/04/30 Add
            }
            if (_titleList.Count > 5) this.uCheckEditor_Para06.Text = _titleList[5].ToString();
            else
            {
                this.uCheckEditor_Para06.Visible = false;
                this.uCheckEditor_Para06.Checked = false;
                this.tComboEditor6.Visible = false; // 2010/04/30 Add
            }
            if (_titleList.Count > 6) this.uCheckEditor_Para07.Text = _titleList[6].ToString();
            else
            {
                this.uCheckEditor_Para07.Visible = false;
                this.uCheckEditor_Para07.Checked = false;
                this.tComboEditor7.Visible = false; // 2010/04/30 Add
            }
            if (_titleList.Count > 7) this.uCheckEditor_Para08.Text = _titleList[7].ToString();
            else
            {
                this.uCheckEditor_Para08.Visible = false;
                this.uCheckEditor_Para08.Checked = false;
                this.tComboEditor8.Visible = false; // 2010/04/30 Add
            }
            if (_titleList.Count > 8) this.uCheckEditor_Para09.Text = _titleList[8].ToString();
            else
            {
                this.uCheckEditor_Para09.Visible = false;
                this.uCheckEditor_Para09.Checked = false;
                this.tComboEditor9.Visible = false; // 2010/04/30 Add
            }
            // 2010/04/30 Add >>>
            if (_changeflg == true)
            {
                // 2010/04/30 Add <<<
                // �O���t��ʂ̺����ޯ���ɏ��Z�b�g
                this.tComboEditor_GraphStyle.Items.Clear();
                this.tComboEditor_GraphStyle.Items.Add(0, GRAPH_BAR);
                this.tComboEditor_GraphStyle.Items.Add(1, GRAPH_LINE);
                this.tComboEditor_GraphStyle.Items.Add(2, GRAPH_PIE);
                // 2010/04/30 Add >>>
                this.tComboEditor_GraphStyle.Items.Add(3, GRAPH_RADAR);
                switch (_graphId)
                {
                    case 1: // ���z�O���t�̐܂���{�_�O���t�ݒ�
                        this.tComboEditor_GraphStyle.Items.Add(4, GRAPH_LINEBAR + GRAPH_COUNT);
                        this.tComboEditor_GraphStyle.Items.Add(5, GRAPH_LINEBAR + GRAPH_QUANTITY);
                        break;
                    case 2: // ���ʃO���t�̐܂���{�_�O���t�ݒ�
                        this.tComboEditor_GraphStyle.Items.Add(4, GRAPH_LINEBAR + GRAPH_MONEY);
                        this.tComboEditor_GraphStyle.Items.Add(5, GRAPH_LINEBAR + GRAPH_COUNT);
                        break;
                    case 3: // �񐔃O���t�̐܂���{�_�O���t�ݒ�
                        this.tComboEditor_GraphStyle.Items.Add(4, GRAPH_LINEBAR + GRAPH_QUANTITY);
                        this.tComboEditor_GraphStyle.Items.Add(5, GRAPH_LINEBAR + GRAPH_MONEY);
                        break;
                    default:    // �O�̂��ߐݒ�
                        this.tComboEditor_GraphStyle.Items.Add(4, GRAPH_LINEBAR + GRAPH_QUANTITY);
                        this.tComboEditor_GraphStyle.Items.Add(5, GRAPH_LINEBAR + GRAPH_MONEY);
                        break;
                }

                // �O���t��ʂ̃R���{�{�b�N�X�ɏ��Z�b�g
                this.tComboEditor1.Items.Clear();
                this.tComboEditor1.Items.Add(0, GRAPH_BAR_L);
                this.tComboEditor1.Items.Add(1, GRAPH_BAR_S);
                this.tComboEditor1.Items.Add(2, GRAPH_LINE_L);
                this.tComboEditor1.Items.Add(3, GRAPH_LINE_S);

                this.tComboEditor2.Items.Clear();
                this.tComboEditor2.Items.Add(0, GRAPH_BAR_L);
                this.tComboEditor2.Items.Add(1, GRAPH_BAR_S);
                this.tComboEditor2.Items.Add(2, GRAPH_LINE_L);
                this.tComboEditor2.Items.Add(3, GRAPH_LINE_S);

                this.tComboEditor3.Items.Clear();
                this.tComboEditor3.Items.Add(0, GRAPH_BAR_L);
                this.tComboEditor3.Items.Add(1, GRAPH_BAR_S);
                this.tComboEditor3.Items.Add(2, GRAPH_LINE_L);
                this.tComboEditor3.Items.Add(3, GRAPH_LINE_S);

                this.tComboEditor4.Items.Clear();
                this.tComboEditor4.Items.Add(0, GRAPH_BAR_L);
                this.tComboEditor4.Items.Add(1, GRAPH_BAR_S);
                this.tComboEditor4.Items.Add(2, GRAPH_LINE_L);
                this.tComboEditor4.Items.Add(3, GRAPH_LINE_S);

                this.tComboEditor5.Items.Clear();
                this.tComboEditor5.Items.Add(0, GRAPH_BAR_L);
                this.tComboEditor5.Items.Add(1, GRAPH_BAR_S);
                this.tComboEditor5.Items.Add(2, GRAPH_LINE_L);
                this.tComboEditor5.Items.Add(3, GRAPH_LINE_S);

                this.tComboEditor6.Items.Clear();
                this.tComboEditor6.Items.Add(0, GRAPH_BAR_L);
                this.tComboEditor6.Items.Add(1, GRAPH_BAR_S);
                this.tComboEditor6.Items.Add(2, GRAPH_LINE_L);
                this.tComboEditor6.Items.Add(3, GRAPH_LINE_S);

                this.tComboEditor7.Items.Clear();
                this.tComboEditor7.Items.Add(0, GRAPH_BAR_L);
                this.tComboEditor7.Items.Add(1, GRAPH_BAR_S);
                this.tComboEditor7.Items.Add(2, GRAPH_LINE_L);
                this.tComboEditor7.Items.Add(3, GRAPH_LINE_S);

                this.tComboEditor8.Items.Clear();
                this.tComboEditor8.Items.Add(0, GRAPH_BAR_L);
                this.tComboEditor8.Items.Add(1, GRAPH_BAR_S);
                this.tComboEditor8.Items.Add(2, GRAPH_LINE_L);
                this.tComboEditor8.Items.Add(3, GRAPH_LINE_S);

                this.tComboEditor9.Items.Clear();
                this.tComboEditor9.Items.Add(0, GRAPH_BAR_L);
                this.tComboEditor9.Items.Add(1, GRAPH_BAR_S);
                this.tComboEditor9.Items.Add(2, GRAPH_LINE_L);
                this.tComboEditor9.Items.Add(3, GRAPH_LINE_S);

            }
            // 2010/04/30 Add <<<
            this.tComboEditor_GraphStyle.MaxDropDownItems = this.tComboEditor_GraphStyle.Items.Count;
            if ((_graphPara != null) && (_graphPara.Count != 0))
            {
                //this.tComboEditor_GraphStyle.SelectedIndex = _graphPara[0]; // 2010/04/30 Del

                int iCnt = 1;
                for (int ix = 1; ix < _graphPara.Count; ix++)
                {
                    if (_graphPara[ix] == -1) continue;

                    if (iCnt == 1)
                    {
                        if (_graphPara[ix] == 0) this.uCheckEditor_Para01.Checked = false;
                        else this.uCheckEditor_Para01.Checked = true;
                        // 2010/04/30 Add >>>
                        if (_graphPara2[ix] == -1) this.tComboEditor1.SelectedIndex = 2;
                        else this.tComboEditor1.SelectedIndex = _graphPara2[ix];
                        // 2010/04/30 Add <<<
                    }
                    if (iCnt == 2)
                    {
                        if (_graphPara[ix] == 0) this.uCheckEditor_Para02.Checked = false;
                        else this.uCheckEditor_Para02.Checked = true;
                        // 2010/04/30 Add >>>
                        if (_graphPara2[ix] == -1) this.tComboEditor2.SelectedIndex = 2;
                        else this.tComboEditor2.SelectedIndex = _graphPara2[ix];
                        // 2010/04/30 Add <<<
                    }
                    if (iCnt == 3)
                    {
                        if (_graphPara[ix] == 0) this.uCheckEditor_Para03.Checked = false;
                        else this.uCheckEditor_Para03.Checked = true;
                        // 2010/04/30 Add >>>
                        if (_graphPara2[ix] == -1) this.tComboEditor3.SelectedIndex = 2;
                        else this.tComboEditor3.SelectedIndex = _graphPara2[ix];
                        // 2010/04/30 Add <<<
                    }
                    if (iCnt == 4)
                    {
                        if (_graphPara[ix] == 0) this.uCheckEditor_Para04.Checked = false;
                        else this.uCheckEditor_Para04.Checked = true;
                        // 2010/04/30 Add >>>
                        if (_graphPara2[ix] == -1) this.tComboEditor4.SelectedIndex = 2;
                        else this.tComboEditor4.SelectedIndex = _graphPara2[ix];
                        // 2010/04/30 Add <<<
                    }
                    if (iCnt == 5)
                    {
                        if (_graphPara[ix] == 0) this.uCheckEditor_Para05.Checked = false;
                        else this.uCheckEditor_Para05.Checked = true;
                        // 2010/04/30 Add >>>
                        if (_graphPara2[ix] == -1) this.tComboEditor5.SelectedIndex = 2;
                        else this.tComboEditor5.SelectedIndex = _graphPara2[ix];
                        // 2010/04/30 Add <<<
                    }
                    if (iCnt == 6)
                    {
                        if (_graphPara[ix] == 0) this.uCheckEditor_Para06.Checked = false;
                        else this.uCheckEditor_Para06.Checked = true;
                        // 2010/04/30 Add >>>
                        if (_graphPara2[ix] == -1) this.tComboEditor6.SelectedIndex = 2;
                        else this.tComboEditor6.SelectedIndex = _graphPara2[ix];
                        // 2010/04/30 Add <<<
                    }
                    if (iCnt == 7)
                    {
                        if (_graphPara[ix] == 0) this.uCheckEditor_Para07.Checked = false;
                        else this.uCheckEditor_Para07.Checked = true;
                        // 2010/04/30 Add >>>
                        if (_graphPara2[ix] == -1) this.tComboEditor7.SelectedIndex = 2;
                        else this.tComboEditor7.SelectedIndex = _graphPara2[ix];
                        // 2010/04/30 Add <<<
                    }
                    if (iCnt == 8)
                    {
                        if (_graphPara[ix] == 0) this.uCheckEditor_Para08.Checked = false;
                        else this.uCheckEditor_Para08.Checked = true;
                        // 2010/04/30 Add >>>
                        if (_graphPara2[ix] == -1) this.tComboEditor8.SelectedIndex = 2;
                        else this.tComboEditor8.SelectedIndex = _graphPara2[ix];
                        // 2010/04/30 Add <<<
                    }
                    if (iCnt == 9)
                    {
                        if (_graphPara[ix] == 0) this.uCheckEditor_Para09.Checked = false;
                        else this.uCheckEditor_Para09.Checked = true;
                        // 2010/04/30 Add >>>
                        if (_graphPara2[ix] == -1) this.tComboEditor9.SelectedIndex = 2;
                        else this.tComboEditor9.SelectedIndex = _graphPara2[ix];
                        // 2010/04/30 Add <<<
                    }
                    iCnt++;
                }

                // 2010/04/30 Add >>>
                if (_changeflg == true)
                    this.tComboEditor_GraphStyle.SelectedIndex = _graphPara[0];
                // 2010/04/30 Add <<<
            }
            else
            {
                this.tComboEditor_GraphStyle.SelectedIndex = 0;
            }

            _graphPara[0] = -1;
            _changeflg = true;  // 2010/04/30 Add
        }

        // 2010/04/30 Add >>>
        /// <summary>
        /// �O���t�I���R���{�{�b�N�X�̐ݒ肪�ύX�����x�ɌĂяo����܂��B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_GraphStyle_ValueChanged(object sender, EventArgs e)
        {
            // ���݂̃`�F�b�N�{�b�N�X�̓��e���擾
            if ((_graphPara != null) && (_graphPara.Count != 0))
            {
                int iCnt = 1;
                for (int ix = 1; ix < _graphPara.Count; ix++)
                {
                    if (_graphPara[ix] != -1)
                    {
                        if (iCnt == 1)
                        {
                            if (this.uCheckEditor_Para01.Checked == true) _graphPara[ix] = 1;
                            else _graphPara[ix] = 0;
                            if (this.tComboEditor1.SelectedIndex == -1) _graphPara2[ix] = 2;
                            else _graphPara2[ix] = this.tComboEditor1.SelectedIndex;
                        }
                        if (iCnt == 2)
                        {
                            if (this.uCheckEditor_Para02.Checked == true) _graphPara[ix] = 1;
                            else _graphPara[ix] = 0;
                            if (this.tComboEditor2.SelectedIndex == -1) _graphPara2[ix] = 2;
                            else _graphPara2[ix] = this.tComboEditor2.SelectedIndex;
                        }
                        if (iCnt == 3)
                        {
                            if (this.uCheckEditor_Para03.Checked == true) _graphPara[ix] = 1;
                            else _graphPara[ix] = 0;
                            if (this.tComboEditor3.SelectedIndex == -1) _graphPara2[ix] = 2;
                            else _graphPara2[ix] = this.tComboEditor3.SelectedIndex;
                        }
                        if (iCnt == 4)
                        {
                            if (this.uCheckEditor_Para04.Checked == true) _graphPara[ix] = 1;
                            else _graphPara[ix] = 0;
                            if (this.tComboEditor4.SelectedIndex == -1) _graphPara2[ix] = 2;
                            else _graphPara2[ix] = this.tComboEditor4.SelectedIndex;
                        }
                        if (iCnt == 5)
                        {
                            if (this.uCheckEditor_Para05.Checked == true) _graphPara[ix] = 1;
                            else _graphPara[ix] = 0;
                            if (this.tComboEditor5.SelectedIndex == -1) _graphPara2[ix] = 2;
                            else _graphPara2[ix] = this.tComboEditor5.SelectedIndex;
                        }
                        if (iCnt == 6)
                        {
                            if (this.uCheckEditor_Para06.Checked == true) _graphPara[ix] = 1;
                            else _graphPara[ix] = 0;
                            if (this.tComboEditor6.SelectedIndex == -1) _graphPara2[ix] = 2;
                            else _graphPara2[ix] = this.tComboEditor6.SelectedIndex;
                        }
                        if (iCnt == 7)
                        {
                            if (this.uCheckEditor_Para07.Checked == true) _graphPara[ix] = 1;
                            else _graphPara[ix] = 0;
                            if (this.tComboEditor7.SelectedIndex == -1) _graphPara2[ix] = 2;
                            else _graphPara2[ix] = this.tComboEditor7.SelectedIndex;
                        }
                        if (iCnt == 8)
                        {
                            if (this.uCheckEditor_Para08.Checked == true) _graphPara[ix] = 1;
                            else _graphPara[ix] = 0;
                            if (this.tComboEditor8.SelectedIndex == -1) _graphPara2[ix] = 2;
                            else _graphPara2[ix] = this.tComboEditor8.SelectedIndex;
                        }
                        if (iCnt == 9)
                        {
                            if (this.uCheckEditor_Para09.Checked == true) _graphPara[ix] = 1;
                            else _graphPara[ix] = 0;
                            if (this.tComboEditor9.SelectedIndex == -1) _graphPara2[ix] = 2;
                            else _graphPara2[ix] = this.tComboEditor9.SelectedIndex;
                        }
                        iCnt++;
                    }
                }
            }

            _titleList = new List<string>();
            if (tComboEditor_GraphStyle.SelectedIndex == 4 || tComboEditor_GraphStyle.SelectedIndex == 5)
            {
                if (tComboEditor_GraphStyle.SelectedIndex == 4)
                {
                    _graphPara[0] = 4;
                    switch (_graphId)
                    {
                        case 1: // ���z�{��
                            _titleList.Add(COL_SALESTIMES);
                            _titleList.Add(COL_STOCKTIMES);
                            _titleList.Add(COL_SALESMONEY);
                            _titleList.Add(COL_STOCKMONEY);
                            _titleList.Add(COL_GRPROFIT);
                            _titleList.Add(COL_MOVEAPRICE);
                            _titleList.Add(COL_MOVESPRICE);
                            if (_graphPara[1] == -1)
                                _graphPara[1] = 0;
                            if (_graphPara[2] == -1)
                                _graphPara[2] = 0;
                            _graphPara[3] = -1;
                            _graphPara[4] = -1;
                            _graphPara[5] = -1;
                            _graphPara[6] = -1;
                            break;
                        case 2: // ���ʁ{���z
                            _titleList.Add(COL_SALESCOUNT);
                            _titleList.Add(COL_STOCKCOUNT);
                            _titleList.Add(COL_MOVEACOUNT);
                            _titleList.Add(COL_MOVESCOUNT);
                            _titleList.Add(COL_SALESMONEY);
                            _titleList.Add(COL_STOCKMONEY);
                            _titleList.Add(COL_GRPROFIT);
                            _titleList.Add(COL_MOVEAPRICE);
                            _titleList.Add(COL_MOVESPRICE);
                            _graphPara[1] = -1;
                            _graphPara[2] = -1;
                            if (_graphPara[7] == -1)
                                _graphPara[7] = 0;
                            if (_graphPara[8] == -1)
                                _graphPara[8] = 0;
                            if (_graphPara[9] == -1)
                                _graphPara[9] = 0;
                            if (_graphPara[10] == -1)
                                _graphPara[10] = 0;
                            if (_graphPara[11] == -1)
                                _graphPara[11] = 0;
                            break;
                        case 3: // �񐔁{����
                            _titleList.Add(COL_SALESTIMES);
                            _titleList.Add(COL_STOCKTIMES);
                            _titleList.Add(COL_SALESCOUNT);
                            _titleList.Add(COL_STOCKCOUNT);
                            _titleList.Add(COL_MOVEACOUNT);
                            _titleList.Add(COL_MOVESCOUNT);
                            if (_graphPara[3] == -1)
                                _graphPara[3] = 0;
                            if (_graphPara[4] == -1)
                                _graphPara[4] = 0;
                            if (_graphPara[5] == -1)
                                _graphPara[5] = 0;
                            if (_graphPara[6] == -1)
                                _graphPara[6] = 0;
                            _graphPara[7] = -1;
                            _graphPara[8] = -1;
                            _graphPara[9] = -1;
                            _graphPara[10] = -1;
                            _graphPara[11] = -1;
                            break;
                    }
                }
                else if (tComboEditor_GraphStyle.SelectedIndex == 5)
                {
                    _graphPara[0] = 5;
                    switch (_graphId)
                    {
                        case 1: // ���z�{����
                            _titleList.Add(COL_SALESCOUNT);
                            _titleList.Add(COL_STOCKCOUNT);
                            _titleList.Add(COL_MOVEACOUNT);
                            _titleList.Add(COL_MOVESCOUNT);
                            _titleList.Add(COL_SALESMONEY);
                            _titleList.Add(COL_STOCKMONEY);
                            _titleList.Add(COL_GRPROFIT);
                            _titleList.Add(COL_MOVEAPRICE);
                            _titleList.Add(COL_MOVESPRICE);
                            _graphPara[1] = -1;
                            _graphPara[2] = -1;
                            if (_graphPara[3] == -1)
                                _graphPara[3] = 0;
                            if (_graphPara[4] == -1)
                                _graphPara[4] = 0;
                            if (_graphPara[5] == -1)
                                _graphPara[5] = 0;
                            if (_graphPara[6] == -1)
                                _graphPara[6] = 0;
                            break;
                        case 2: // ���ʁ{��
                            _titleList.Add(COL_SALESTIMES);
                            _titleList.Add(COL_STOCKTIMES);
                            _titleList.Add(COL_SALESCOUNT);
                            _titleList.Add(COL_STOCKCOUNT);
                            _titleList.Add(COL_MOVEACOUNT);
                            _titleList.Add(COL_MOVESCOUNT);
                            if (_graphPara[1] == -1)
                                _graphPara[1] = 0;
                            if (_graphPara[2] == -1)
                                _graphPara[2] = 0;
                            _graphPara[7] = -1;
                            _graphPara[8] = -1;
                            _graphPara[9] = -1;
                            _graphPara[10] = -1;
                            _graphPara[11] = -1;
                            break;
                        case 3: // �񐔁{���z
                            _titleList.Add(COL_SALESTIMES);
                            _titleList.Add(COL_STOCKTIMES);
                            _titleList.Add(COL_SALESMONEY);
                            _titleList.Add(COL_STOCKMONEY);
                            _titleList.Add(COL_GRPROFIT);
                            _titleList.Add(COL_MOVEAPRICE);
                            _titleList.Add(COL_MOVESPRICE);
                            _graphPara[3] = -1;
                            _graphPara[4] = -1;
                            _graphPara[5] = -1;
                            _graphPara[6] = -1;
                            if (_graphPara[7] == -1)
                                _graphPara[7] = 0;
                            if (_graphPara[8] == -1)
                                _graphPara[8] = 0;
                            if (_graphPara[9] == -1)
                                _graphPara[9] = 0;
                            if (_graphPara[10] == -1)
                                _graphPara[10] = 0;
                            if (_graphPara[11] == -1)
                                _graphPara[11] = 0;
                            break;
                    }
                }
                _changeflg = false;
                this.Form2_Load(sender, e);
            }
            else
            {
                switch (_graphId)
                {
                    case 1: // ���z
                        _titleList.Add(COL_SALESMONEY);
                        _titleList.Add(COL_STOCKMONEY);
                        _titleList.Add(COL_GRPROFIT);
                        _titleList.Add(COL_MOVEAPRICE);
                        _titleList.Add(COL_MOVESPRICE);
                        _graphPara[1] = -1;
                        _graphPara[2] = -1;
                        _graphPara[3] = -1;
                        _graphPara[4] = -1;
                        _graphPara[5] = -1;
                        _graphPara[6] = -1;
                        break;
                    case 2: // ����
                        _titleList.Add(COL_SALESCOUNT);
                        _titleList.Add(COL_STOCKCOUNT);
                        _titleList.Add(COL_MOVEACOUNT);
                        _titleList.Add(COL_MOVESCOUNT);
                        _graphPara[1] = -1;
                        _graphPara[2] = -1;
                        _graphPara[7] = -1;
                        _graphPara[8] = -1;
                        _graphPara[9] = -1;
                        _graphPara[10] = -1;
                        _graphPara[11] = -1;
                        break;
                    case 3: // ��
                        _titleList.Add(COL_SALESTIMES);
                        _titleList.Add(COL_STOCKTIMES);
                        _graphPara[3] = -1;
                        _graphPara[4] = -1;
                        _graphPara[5] = -1;
                        _graphPara[6] = -1;
                        _graphPara[7] = -1;
                        _graphPara[8] = -1;
                        _graphPara[9] = -1;
                        _graphPara[10] = -1;
                        _graphPara[11] = -1;
                        break;
                }
            }
            _changeflg = false;
            this.Form2_Load(sender, e);
        }

        /// <summary>
        /// �O���t�ݒ��ۑ����܂��B
        /// </summary>
        /// <param name="list">graphpara</param>
        /// <returns>status</returns>
        private int SaveToFiles(List<List<int>> list)
        {
            int status = 0;
            UserSettingController.SerializeUserSetting(list, Path.Combine(ConstantManagement_ClientDirectory.UISettings, "PMZAI04101U" + _graphId + "_Construction.XML"));
            return status;
        }

        /// <summary>
        /// �O���t�ݒ��ǂݍ��݂܂��B
        /// </summary>
        /// <param name="list">graphpara</param>
        /// <returns>status</returns>
        public int LoadToFiles(out List<List<int>> list)
        {
            // �Ǎ�����
            int status = 0;
            list = new List<List<int>>();
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, "PMZAI04101U" + _graphId + "_Construction.XML")))
            {
                try
                {
                    list = UserSettingController.DeserializeUserSetting<List<List<int>>>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, "PMZAI04101U" + _graphId + "_Construction.XML"));
                }
                catch
                {
                    status = 1;
                }
            }
            else
            {
                status = 1;
            }
            return status;
        }

        // 2010/04/30 Add <<<
    }
}