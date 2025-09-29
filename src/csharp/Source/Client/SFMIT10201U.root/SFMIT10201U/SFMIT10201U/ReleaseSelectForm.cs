using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;

using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �ʒm���e�ݒ�t�H�[��
    /// </summary>
    public partial class ReleaseSelectForm : Form
    {
        #region �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public ReleaseSelectForm()
        {
            InitializeComponent();
            this._TBOServiceACS = new TBOServiceACS();
            this._destSettingTable = new DataTable();
            this._list = new List<DestSetting>();
            this.Title_textBox.Clear();
            this.Content_textBox.Clear();
            this._dicPropose_Para_SCM = new Dictionary<string, Propose_Para_SCM>();

            this._startProposeList = new List<Propose_Para_SCM>();
            this._stopProposeList = new List<DestSetting>();

#if DEBUG
            //// TODO ���J���_�~�[
            //DestSetting store = new DestSetting();
            //store.enterpriseCode = "0140150842030050";
            //store.sectionCode = "000001";
            //this._list.Add(store);
#endif
        }
        #endregion

        #region const

        private const string CT_ASSEMBLYID = "SFMIT10201U";
        private const string CT_PROPOSESTOP = "���J��~";
        private const string CT_PROPOSE_YES = "���J��";
        private const string CT_PROPOSE_NO = "�����J";

        private const string ctSeparator = @"	";
        private const string ctSpace = @"�@";

        private const string COL_PROPOSEDIV = "���J��";
        private const string COL_PROPOSENAME = "���J��";
        private const string COL_STOPBUTTON  = "     ";
        private const string COL_CLASS = "CLASS";

        #endregion

        #region �����o
        /// <summary>TBO�A�N�Z�X�N���X</summary>
        private TBOServiceACS _TBOServiceACS;
        /// <summary>���J��e�[�u��</summary>
        private DataTable _destSettingTable;
        /// <summary>SCM��Ƌ��_�A���f�B�N�V���i��</summary>
        private Dictionary<string, Propose_Para_SCM> _dicPropose_Para_SCM;

        #region �N���p�����[�^
        /// <summary>
        /// �N�����[�h(0:�I����ʁA1:���J�󋵉��)
        /// </summary>
        public int _mode;
        /// <summary>
        /// �J�e�S��ID
        /// </summary>
        public long _categoryID;
        /// <summary>
        /// �J�e�S������
        /// </summary>
        public string _categoryName;
        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string _enterpriseCode;
        /// <summary>
        /// ��Ɩ���
        /// </summary>
        public string _enterpriseName;
        /// <summary>
        /// ���_�R�[�h
        /// </summary>
        public string _sectionCode;
        /// <summary>
        /// ���_�R�[�h
        /// </summary>
        public string _sectionName;
        /// <summary>
        /// SCM��Ƌ��_�A���ݒ�
        /// </summary>
        public List<Propose_Para_SCM> _scmList;
        /// <summary>
        /// ���i���J����
        /// </summary>
        public List<DestSetting> _list;
        #endregion

        #region �߂�l
        /// <summary>
        /// ����
        /// </summary>
        public string NewsTitle;
        /// <summary>
        /// �{��
        /// </summary>
        public string NewsContent;
        /// <summary>
        /// ���J���Ӑ惊�X�g
        /// </summary>
        public List<Propose_Para_SCM> _startProposeList;
        /// <summary>
        /// ���J�˔���J���Ӑ惊�X�g
        /// </summary>
        public List<DestSetting> _stopProposeList;
        #endregion

        #endregion

        #region Public



        #endregion




        /// <summary>
        /// �N������
        /// </summary>
        /// <param name="bootPara">�N���p�����[�^</param>
        /// <param name="target">SCM��Ƌ��_�A�����(���J��̂�)</param>
        /// <returns></returns>
        public DialogResult ShowReleaseSelectFrom()
        {
            int st = 0;
            string errMsg= "";

            #region memo
            // �@���݂̌��J�󋵂��擾
            // �ASCM��Ƌ��_�A�����擾

            // SCM �g�t�`
            // SCM �g�t�a

            // ���J�@�g�t�`
            // ���J�@�u���[�h�P

            // ��1�F���߂͍g�t�`�A�a�A�u���[�h�P��SCM��Ƌ��_�A������
            // ��2�F�g�t�`�A�u���[�h�P�ɏ��i�����J
            // ��3: �u���[�h�P�Ƃ�SCM���I���B��Ƌ��_�A�����폜
            // ����L��

            // ���J��
            // ���J���@�g�t�`
            // �����J�@�g�t�a
            // ���J���@�u���[�h�P

            // ���J��
            // SCM �g�t�`�@�f�t�H�`�F�b�N�n�m
            // SCM �g�t�a

            // �ۑ���A�̂ݐV���f�[�^�����

            // ���J��~���[�h
            // ���J��
            // ���J���@�g�t�`       ���J��~
            // �����J�@�g�t�a�@�@�@ Enable
            // ���J���@�u���[�h�P   ���J��~
#endregion


            if (this._mode == 0)
            {
                // ���J��I�����[�h
                this.panel1.Visible = false;
                this.panel2.Visible = false;
                this.panel3.Visible = true;
                this.panel4.Visible = true;
                this.panel5.Visible = true;
                this.panel6.Visible = true;
                this.panel7.Visible = true;

                this.Size = new Size(620, 520);

            }
            else
            {
                // ���J�󋵊m�F���[�h
                this.panel1.Visible = true;
                this.panel2.Visible = true;
                this.panel2.BringToFront();
                this.panel2.Dock = DockStyle.Fill;
                this.panel3.Visible = false;
                this.panel4.Visible = false;
                this.panel5.Visible = false;
                this.panel6.Visible = false;
                this.panel7.Visible = false;

                this.Size = new Size(620, 250);
                this.FormBorderStyle = FormBorderStyle.Sizable;

                this.Text = "���J��̊m�F";
            }

            // �J�e�S�����̃Z�b�g
            this.Category_textBox.Text = this._categoryName;

            // ���J���擾
            st = this._TBOServiceACS.GetDestSetting(this._enterpriseCode, this._sectionCode, this._categoryID, out this._list, out errMsg);
            if (st != 0)
            {
                // ���J���̎擾�Ɏ��s
                TMsgDisp.Show(
                this,								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                CT_ASSEMBLYID,						// �A�Z���u��ID�܂��̓N���XID
                errMsg,			                    // �\�����郁�b�Z�[�W 
                st,								    // �X�e�[�^�X�l
                MessageBoxButtons.OK);
                this.DialogResult = DialogResult.Abort;
                return this.DialogResult;
            }

            if (this._mode == 0)
            {
                // ���J��c���[�쐬
                this.MakeCustomerTree();
            }
            else
            {
                // �e�[�u���X�L�[�}�쐬
                this.MakeTable();
                // �e�[�u���Ƀf�[�^���Z�b�g
                this.SetData();
            }
         
            return this.ShowDialog();
        }

        /// <summary>
        /// ���J��c���[�쐬
        /// </summary>
        private void MakeCustomerTree()
        {
            this.Customer_ultraTree.AfterCheck -= new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.Customer_ultraTree_AfterCheck);

            this.Customer_ultraTree.Nodes.Clear();

            foreach (Propose_Para_SCM scm in this._scmList)
            {
                // ���J�󋵂ƌ��J�惊�X�g���쐬

                // ���J�惊�X�g
                string key = MakeSCMKey(scm);
                string text = MakeSCMText(scm);

                if (!this.Customer_ultraTree.Nodes.Exists(key))
                {
                    this.Customer_ultraTree.Nodes.Add(key, text);
                    this.Customer_ultraTree.Nodes[key].Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;

                    if (!this._dicPropose_Para_SCM.ContainsKey(key))
                    {
                        this._dicPropose_Para_SCM.Add(key, scm);
                    }

                    DestSetting wkDestSetting = this._list.Find
                        (delegate(DestSetting destSetting)
                        {
                            if (destSetting.proposeDestEnterpriseCode == scm.CnectOriginalEpCd && destSetting.proposeDestSectionCode.TrimEnd() == scm.CnectOriginalSecCd.TrimEnd())
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    );
                    if (wkDestSetting != null)
                    {
                        this.Customer_ultraTree.Nodes[key].CheckedState = CheckState.Checked;
                        this.Customer_ultraTree.Nodes[key].Tag = wkDestSetting;
                    }
                    else
                    {
                        this.Customer_ultraTree.Nodes[key].CheckedState = CheckState.Unchecked;
                    }
                }
            }

            this.Customer_ultraTree.AfterCheck += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.Customer_ultraTree_AfterCheck);

        }

        /// <summary>
        /// ���J���쐬
        /// </summary>
        /// <returns></returns>
        private void SetData()
        {
            foreach (Propose_Para_SCM scm in this._scmList)
            {
                // ���J�󋵂ƌ��J�惊�X�g���쐬

                // ���J�惊�X�g
                string key = MakeSCMKey(scm);
                string text = MakeSCMText(scm);

                // ���J�󋵃e�[�u��
                DataRow row = this._destSettingTable.NewRow();

                DestSetting wkDestSetting = this._list.Find
                    (delegate(DestSetting destSetting)
                    {
                        if (destSetting.proposeDestEnterpriseCode == scm.CnectOriginalEpCd && destSetting.proposeDestSectionCode.TrimEnd() == scm.CnectOriginalSecCd.TrimEnd())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                // ���J�於��
                row[COL_PROPOSENAME] = text;
                // ���ɏ��i�����J����Ă��链�Ӑ�͌��J���\��
                if (wkDestSetting != null)
                {
                    row[COL_PROPOSEDIV] = CT_PROPOSE_YES;
                    row[COL_CLASS] = wkDestSetting;
                }
                else
                {
                    row[COL_PROPOSEDIV] = CT_PROPOSE_NO;
                }

                this._destSettingTable.Rows.Add(row);
            }

            // �C���M�����[�P�[�X
            // ���i���J��ASCM�̊�Ƌ��_�A�������������ꍇ(�������߂�ꍇ��z��)
            // ���̏ꍇ�A�f�[�^���c���Ă��܂��̂ŁASCM��Ƌ��_�A�����F�Ȃ��A���J���F����̃f�[�^���\������
            foreach (DestSetting dst in this._list)
            {
                Propose_Para_SCM scm = this._scmList.Find
                  (delegate(Propose_Para_SCM wkScm)
                    {
                        if (dst.proposeDestEnterpriseCode == wkScm.CnectOriginalEpCd && dst.proposeDestSectionCode.TrimEnd() == wkScm.CnectOriginalSecCd.TrimEnd())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                if (scm == null)
                {
                    // ���J�󋵃e�[�u��
                    DataRow row = this._destSettingTable.NewRow();
                   
                    // ���J���̂ݎc���Ă�

                    // ���J�於 
                    row[COL_PROPOSENAME] = dst.proposeDestEnterpriseName + ctSpace + dst.proposeDestSectionName;
                    row[COL_PROPOSEDIV] = CT_PROPOSE_YES;
                    row[COL_CLASS] = dst;
                    this._destSettingTable.Rows.Add(row);
                }
            }

            // �O���b�h�ɃZ�b�g
            this.Propose_Grid.DataSource = this._destSettingTable;

        }

        /// <summary>
        /// ���J��̃L�[���쐬
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        private string MakeSCMKey(Propose_Para_SCM customer)
        {
            return customer.CnectOriginalEpCd + ctSeparator + customer.CnectOriginalSecCd;
        }

        /// <summary>
        /// ���J��̃L�[���쐬
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        private string MakeSCMKey(string key1, string key2)
        {
            return key1 + ctSeparator + key2;
        }

        /// <summary>
        /// ���J��̖��̂��쐬
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        private string MakeSCMText(Propose_Para_SCM customer)
        {
            return customer.CnectOriginalEpNm + ctSpace + customer.CnectOriginalSecNm;
        }

        /// <summary>
        /// �f�[�^�Z�b�g�쐬
        /// </summary>
        private void MakeTable()
        {
            this._destSettingTable.Columns.Add(COL_PROPOSEDIV, typeof(string));
            this._destSettingTable.Columns.Add(COL_PROPOSENAME, typeof(string));
            this._destSettingTable.Columns.Add(COL_STOPBUTTON, typeof(string));
            this._destSettingTable.Columns.Add(COL_CLASS, typeof(object));
            this._destSettingTable.Columns[COL_STOPBUTTON].DefaultValue = CT_PROPOSESTOP;
        }

        /// <summary>
        /// ����{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// �ۑ��{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Button_Click(object sender, EventArgs e)
        {
            this._startProposeList.Clear();
            this._stopProposeList.Clear();

            // ���J�惊�X�g�쐬
            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode node in this.Customer_ultraTree.Nodes)
            {
                string[] keys = node.Key.Split(new string[] { ctSeparator }, StringSplitOptions.RemoveEmptyEntries);
                string scmkey = MakeSCMKey(keys[0], keys[1]);

                // ���J���X�g�A����J���X�g���쐬
                if (node.CheckedState == CheckState.Checked)
                {
                    // ���J���X�g�ɒǉ�
                    if (this._dicPropose_Para_SCM.ContainsKey(scmkey))
                    {
                        this._startProposeList.Add(this._dicPropose_Para_SCM[scmkey]);
                    }
                }

                if (node.Tag != null && node.CheckedState == CheckState.Unchecked)
                {
                    // ���J�˔���J�ɂ��ꂽ
                    // ����J���X�g�ɒǉ�
                    DestSetting delSet = (DestSetting)node.Tag;
                    delSet.logicalDelDiv = 1;
                    this._stopProposeList.Add(delSet);
                }
            }

            // ���̓`�F�b�N
            // ���J��͕K�{
            // �������A���J�˔���J�̏ꍇ������̂ł�����l��

            if (this._startProposeList.Count == 0 && this._stopProposeList.Count == 0)
            {
                // ���b�Z�[�W��\��
                DialogResult rlt = TMsgDisp.Show(
                   this,							        // �e�E�B���h�E�t�H�[��
                   emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // �G���[���x��
                   CT_ASSEMBLYID,					        // �A�Z���u��ID�܂��̓N���XID
                   "���J���I�����ĉ�����", 	            // �\�����郁�b�Z�[�W 
                   0,								        // �X�e�[�^�X�l
                   MessageBoxButtons.OK);
                this.Customer_ultraTree.Focus();
                return;
            }

            #region �����͖����͉Ƃ���
            //// ���� �͕K�{�Ƃ���
            //if (string.IsNullOrEmpty(this.Title_textBox.Text))
            //{
            //    // ���b�Z�[�W��\��
            //    DialogResult rlt = TMsgDisp.Show(
            //       this,							        // �e�E�B���h�E�t�H�[��
            //       emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // �G���[���x��
            //       CT_ASSEMBLYID,					        // �A�Z���u��ID�܂��̓N���XID
            //       "��������͂��ĉ�����", 	                // �\�����郁�b�Z�[�W 
            //       0,								        // �X�e�[�^�X�l
            //       MessageBoxButtons.OK);
            //    this.Title_textBox.Focus();
            //    return;
            //}

            //// �{��
            //if (string.IsNullOrEmpty(this.Content_textBox.Text))
            //{
            //    // ���b�Z�[�W��\��
            //    DialogResult rlt = TMsgDisp.Show(
            //       this,							        // �e�E�B���h�E�t�H�[��
            //       emErrorLevel.ERR_LEVEL_INFO,	    // �G���[���x��
            //       CT_ASSEMBLYID,					        // �A�Z���u��ID�܂��̓N���XID
            //       "�{�������͂���Ă��܂���B" 
            //       + Environment.NewLine + "���̂܂ܓo�^���Ă���낵���ł����H",    // �\�����郁�b�Z�[�W 
            //       0,								        // �X�e�[�^�X�l
            //       MessageBoxButtons.OKCancel);

            //    if (rlt == DialogResult.Cancel)
            //    {
            //        this.Content_textBox.Focus();
            //    }
            //    return;
            //}
            #endregion

            // �߂�l���Z�b�g
            this.NewsTitle = this.Title_textBox.Text;
            this.NewsContent = this.Content_textBox.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
       

        /// <summary>
        /// ���J�󋵃O���b�h InitializeLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Propose_Grid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = e.Layout;
            // �O���b�h�̃J��������ݒ肵�܂��B
            this.SettingGridColumn(layout.Bands[0].Columns);

            layout.ScrollBounds = ScrollBounds.ScrollToFill;
            layout.ScrollStyle = ScrollStyle.Immediate;
            layout.Override.AllowAddNew = AllowAddNew.No;
            layout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            layout.Override.AllowColMoving = AllowColMoving.NotAllowed;
            layout.UseFixedHeaders = false;

            // �w�b�_�[�̊O�ϐݒ�
            layout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            layout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            layout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            layout.Override.HeaderAppearance.ForeColor = System.Drawing.Color.White;
            layout.Override.HeaderAppearance.FontData.Name = "�l�r �S�V�b�N";
            layout.Override.HeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
            layout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

            // 1�s�����̊O�ϐݒ�
            layout.Override.RowAlternateAppearance.BackColor = Color.Lavender;

            // �s�Z���N�^�[�̐ݒ�
            layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            layout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
            layout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            layout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // �s�I��ݒ� �s�I�𖳂����[�h(�A�N�e�B�u�̂�)
            layout.Override.SelectTypeCell = SelectType.None;
            layout.Override.SelectTypeCol = SelectType.None;
            layout.Override.SelectTypeRow = SelectType.Single;

            // �I���s�̊O�ϐݒ�
            layout.Override.SelectedRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            layout.Override.SelectedRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            layout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            layout.Override.SelectedRowAppearance.ForeColor = System.Drawing.Color.Black;
            layout.Override.SelectedRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            layout.Override.SelectedRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);

            // �A�N�e�B�u�s�̊O�ϐݒ�
            layout.Override.ActiveRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            layout.Override.ActiveRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            layout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            layout.Override.ActiveRowAppearance.ForeColor = System.Drawing.Color.Black;
            layout.Override.ActiveRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            layout.Override.ActiveRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);

            // �s�t�B���^�[�̐ݒ�
            layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            // ��̎�������
            layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            // ��̓��֕s��
            layout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            // ��̃T�C�Y�ύX�s��
            layout.Override.AllowColSizing = AllowColSizing.None;
            // ��̃\�[�g�s��
            layout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None;
            layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
            layout.Override.CellClickAction = CellClickAction.RowSelect;

            //�s�T�C�Y�ύX�s��
            layout.Override.RowSizing = RowSizing.Fixed;
        }

        /// <summary>
        /// �O���b�h�A�b�v�f�[�g����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�b�v�f�[�g�������s���܂��B</br>
        /// </remarks>
        private void UpDateGrid()
        {
            this.Propose_Grid.UpdateData();
            this.Propose_Grid.Refresh();
        }

        /// <summary>
        /// �O���b�h�J�����ݒ�
        /// </summary>
        /// <param name="columnsCollection"></param>
        private void SettingGridColumn(ColumnsCollection cols)
        {
            // ���J��
            cols[COL_PROPOSEDIV].Width = 40;
            cols[COL_PROPOSEDIV].Hidden = false;
            cols[COL_PROPOSEDIV].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            cols[COL_PROPOSEDIV].CellActivation = Activation.NoEdit;
            cols[COL_PROPOSEDIV].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Top;
            cols[COL_PROPOSEDIV].CellDisplayStyle = CellDisplayStyle.PlainText;

            // ���J��
            cols[COL_PROPOSENAME].Hidden = false;
            cols[COL_PROPOSENAME].Width = 120;
            cols[COL_PROPOSENAME].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            cols[COL_PROPOSENAME].CellActivation = Activation.NoEdit;
            cols[COL_PROPOSENAME].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Top;
            cols[COL_PROPOSENAME].CellDisplayStyle = CellDisplayStyle.PlainText;

            // ���J��~�{�^��
            cols[COL_STOPBUTTON].Hidden = false;
            cols[COL_STOPBUTTON].Width = 30;
            //cols[COL_STOPBUTTON].CellButtonAppearance.Image = this._imageList.Images[0];
            cols[COL_STOPBUTTON].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            cols[COL_STOPBUTTON].ButtonDisplayStyle = ButtonDisplayStyle.Always;
            cols[COL_STOPBUTTON].CellActivation = Activation.AllowEdit;
            cols[COL_STOPBUTTON].CellButtonAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            //cols[COL_STOPBUTTON].CellButtonAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            cols[COL_STOPBUTTON].CellButtonAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            cols[COL_STOPBUTTON].CellButtonAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            // ��ƃJ����
            cols[COL_CLASS].Hidden = true;

        }

        /// <summary>
        /// Propose_Grid_InitializeRow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Propose_Grid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.Row.Cells[COL_PROPOSEDIV].Value.ToString() == CT_PROPOSE_YES)
            {
                e.Row.Cells[COL_STOPBUTTON].Activation = Activation.AllowEdit;
            }
            else
            {
                e.Row.Cells[COL_STOPBUTTON].Activation = Activation.Disabled;
            }
        }

        /// <summary>
        /// �S�I��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SELECTALL_Button_Click(object sender, EventArgs e)
        {
            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode node in this.Customer_ultraTree.Nodes)
            {
                node.CheckedState = CheckState.Checked;
            }
        }

        /// <summary>
        /// �S����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CLEARALL_Button_Click(object sender, EventArgs e)
        {
            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode node in this.Customer_ultraTree.Nodes)
            {
                node.CheckedState = CheckState.Checked;
            }
        }


        /// <summary>
        /// Customer_ultraTree_AfterCheck
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Customer_ultraTree_AfterCheck(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
        {
            // �`�F�b�N���O���ꂽ
            if (e.TreeNode.CheckedState == CheckState.Unchecked && e.TreeNode.Tag != null)
            {
                // ���Ɍ��J�ς݂̌��J��̃`�F�b�N���O���ꂽ

                // ���b�Z�[�W��\��
                DialogResult ret = TMsgDisp.Show(
                   this,							        // �e�E�B���h�E�t�H�[��
                   emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // �G���[���x��
                   CT_ASSEMBLYID,					        // �A�Z���u��ID�܂��̓N���XID
                   "�I�������������J��ɂ͌��ݏ��i�����J���ł��B"
                   + Environment.NewLine
                   + "���̂܂ܕۑ����s���ƁA���J�ς݂̏��i�����J����폜����܂��B"
                   + Environment.NewLine
                   + "�I�����������Ă���낵���ł����H", 	// �\�����郁�b�Z�[�W                                                          
                   0,								        // �X�e�[�^�X�l
                   MessageBoxButtons.OKCancel);

                if (ret == DialogResult.Cancel)
                {
                    this.Customer_ultraTree.AfterCheck -= new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.Customer_ultraTree_AfterCheck);
                    e.TreeNode.CheckedState = CheckState.Checked;
                    this.Customer_ultraTree.AfterCheck += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.Customer_ultraTree_AfterCheck);

                }
            }
        }

        /// <summary>
        /// tRetKeyControl1_ChangeFocus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if ((e.PrevCtrl == null) || (e.NextCtrl == null))
                return;

            //�L�[����         
            switch (e.PrevCtrl.Name)
            {
                case "Propose_Grid":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = null;

                                    //�V�t�g�L�[��������Ă��邩�H
                                    if (e.ShiftKey)
                                    {
                                        // �ŏ��̃Z��
                                        if (this.Propose_Grid.ActiveCell != null && this.Propose_Grid.ActiveCell.Column.Key == COL_PROPOSEDIV)
                                        {
                                            if (this.Propose_Grid.ActiveCell.Row.HasPrevSibling())
                                            {
                                                UltraGridRow prevRow = this.Propose_Grid.ActiveCell.Row.GetSibling(SiblingRow.Previous);
                                                UltraGridCell prevCel = null;
                                                prevCel = prevRow.Cells[COL_STOPBUTTON];
                                                if (prevCel != null)
                                                {
                                                    prevCel.Activate();
                                                    prevCel.Selected = true;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            this.Propose_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                                        }
                                    }
                                    else
                                    {
                                        // �ŏI�Z��
                                        if (this.Propose_Grid.ActiveCell != null && this.Propose_Grid.ActiveCell.Column.Key == COL_STOPBUTTON)
                                        {
                                            if (this.Propose_Grid.ActiveCell.Row.HasNextSibling())
                                            {
                                                UltraGridRow nextRow = this.Propose_Grid.ActiveCell.Row.GetSibling(SiblingRow.Next);
                                                UltraGridCell nextCel = nextRow.Cells[COL_PROPOSEDIV];
                                                if (nextCel != null)
                                                {
                                                    nextCel.Activate();
                                                    nextCel.Selected = true;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            this.Propose_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                        }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// Propose_Grid_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Propose_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            // �ҏW���ł������ꍇ
            if (this.Propose_Grid.ActiveCell != null)
            {
                // �A�N�e�B�u�Z��
                UltraGridCell activeCell = this.Propose_Grid.ActiveCell;

                switch (e.KeyData)
                {
                    // ���L�[
                    case Keys.Left:
                        // �ŏ��̃Z��
                        if (activeCell.Column.Key == COL_PROPOSEDIV)
                        {
                            if (activeCell.Row.HasPrevSibling())
                            {
                                UltraGridRow prevRow = activeCell.Row.GetSibling(SiblingRow.Previous);
                                UltraGridCell prevCel = null;
                                prevCel = prevRow.Cells[COL_STOPBUTTON];
                                if (prevCel != null)
                                {
                                    prevCel.Activate();
                                    prevCel.Selected = true;
                                }
                            }
                        }
                        else
                        {
                            this.Propose_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                        }
                        e.Handled = true;
                        break;
                    // ���L�[
                    case Keys.Right:
                        // �ŏI�Z��
                        if (activeCell.Column.Key == COL_STOPBUTTON)
                        {
                            if (activeCell.Row.HasNextSibling())
                            {
                                UltraGridRow nextRow = activeCell.Row.GetSibling(SiblingRow.Next);
                                UltraGridCell nextCel = nextRow.Cells[COL_PROPOSEDIV];
                                if (nextCel != null)
                                {
                                    nextCel.Activate();
                                    nextCel.Selected = true;
                                }
                            }
                        }
                        else
                        {
                            this.Propose_Grid.PerformAction(UltraGridAction.NextCellByTab);
                        }
                        e.Handled = true;
                        break;
                    case Keys.Up:
                        if (activeCell.Row.HasPrevSibling())
                        {
                            UltraGridRow prevRow = activeCell.Row.GetSibling(SiblingRow.Previous);
                            UltraGridCell prevCel = prevRow.Cells[activeCell.Column.Key];
                            if (prevCel != null)
                            {
                                prevCel.Activate();
                                prevCel.Selected = true;
                            }
                        }
                        e.Handled = true;
                        break;
                    // ���L�[
                    case Keys.Down:
                        if (activeCell.Row.HasNextSibling())
                        {
                            UltraGridRow belowRow = activeCell.Row.GetSibling(SiblingRow.Next);
                            UltraGridCell belowCel = belowRow.Cells[activeCell.Column.Key];
                            belowCel.Activate();
                            belowCel.Selected = true;
                        }
                        e.Handled = true;
                        break;
                    case Keys.Space:
                        if (activeCell.Activation != Activation.Disabled)
                        {
                            if (activeCell.Column.Key == COL_STOPBUTTON)
                            {
                                // ���J��~
                                this.StopProposeGoods(activeCell.Row.Index);
                            }
                        }
                        e.Handled = true;
                        break;
                }
            }
        }

        /// <summary>
        /// �I�����ꂽ���J��ւ̏��i���J���~���܂�
        /// </summary>
        /// <param name="p"></param>
        private void StopProposeGoods(int index)
        {
            // ���b�Z�[�W��\��
            DialogResult ret = TMsgDisp.Show(
               this,							            // �e�E�B���h�E�t�H�[��
               emErrorLevel.ERR_LEVEL_EXCLAMATION,	        // �G���[���x��
               CT_ASSEMBLYID,					            // �A�Z���u��ID�܂��̓N���XID
               "���J��~���I������܂����B"
               + Environment.NewLine
               + "���J��~���s���ƁA���J�ς݂̏��i�����J����폜����܂��B"
               + Environment.NewLine
               + "���J��~�����s���Ă���낵���ł����H",    // �\�����郁�b�Z�[�W                                                          
               0,								            // �X�e�[�^�X�l
               MessageBoxButtons.OKCancel);

            if (ret == DialogResult.OK)
            {

                // ���J��~����
                int st = 0;
                string errMsg = "";

                //�s���s���\��
                Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
                // �\��������ݒ�
                form.Title = "������";
                form.Message = "���J��~���������s���ł�";

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    form.Show();

                    DestSetting destSetting = (DestSetting)this.Propose_Grid.Rows[index].Cells[COL_CLASS].Value;

                    st = this._TBOServiceACS.DeleteDestSetting(destSetting, out errMsg);
                    if (st == 0)
                    {
                        // ���J�󋵂��擾
                        st = this._TBOServiceACS.GetDestSetting(this._enterpriseCode, this._sectionCode, this._categoryID, out this._list, out errMsg);
                        if (st == 0)
                        {
                            // �e�[�u��������
                            this.Propose_Grid.DataSource = null;
                            this._destSettingTable.Clear();
                            // �e�[�u���ŐV��
                            this.SetData();
                        }
                        else
                        {
                            // ���J���擾���s
                            TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                            CT_ASSEMBLYID,						// �A�Z���u��ID�܂��̓N���XID
                            errMsg,			                    // �\�����郁�b�Z�[�W 
                            st,								    // �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                        }
                    }
                    else
                    {
                        form.Close();
                        this.Cursor = Cursors.Default;

                        // ���J��~���s
                        TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                        CT_ASSEMBLYID,						// �A�Z���u��ID�܂��̓N���XID
                        errMsg,			                    // �\�����郁�b�Z�[�W 
                        st,								    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);				// �\������{�^��
                    }
                }
                finally
                {
                    // �_�C�A���O�����
                    form.Close();
                    this.Cursor = Cursors.Default;
                    this.UpDateGrid();
                    System.Windows.Forms.Application.DoEvents();
                }
            }
        }

        /// <summary>
        /// Propose_Grid_ClickCellButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Propose_Grid_ClickCellButton(object sender, CellEventArgs e)
        {
            // ���J��~
            if (e.Cell.Column.Key == COL_STOPBUTTON)
            {
                this.StopProposeGoods(e.Cell.Row.Index);
            }
        }

        /// <summary>
        /// KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Content_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            // ���s
            if (e.KeyCode == Keys.Enter && e.Alt)
            {
                // ���s
                try
                {
                    int index = this.Content_textBox.SelectionStart;
                    string insertVal = this.Content_textBox.Text;
                    int length = insertVal.Length;
                    if (length + 2 <= 256)
                    {
                        string wk = insertVal.Insert(index, Environment.NewLine);
                        this.Content_textBox.Text = wk;
                        this.Content_textBox.SelectionStart = index + 2;  // rn��
                    }
                }
                catch
                {

                }
            }
        }
    }
}