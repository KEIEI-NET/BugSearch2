using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// �I���K�C�h
    /// </summary>
    /// <remarks>
    /// <br>�{�N���X��internal�Ő錾����Ă���ׁA�O���A�Z���u������͒��ڎQ�Ƃł��Ȃ��B</br>
    /// <br>�O���A�Z���u������{�N���X�ɃA�N�Z�X����ꍇ�́A����N���X�ɃC���^�[�t�F�[�X</br>
    /// <br>�ƂȂ郁�\�b�h��v���p�e�B���쐬���鎖</br>
    /// <br>Update Note: 2013/02/06 donggy </br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M</br>
    /// <br>           : Redmine#33919�̑Ή�</br>
    /// <br>Update Note: 2016/01/13 �c����</br>
    /// <br>           : 11200090-00 Redmine#48587</br>
    /// <br>           : �@�����\���������A�����t�H�[�J�X�𖼏̍i���ɏ����敪��B���ɂ���ύX</br>
    /// <br>           : �A��ʕ\��������AF5�AF6�AF7�AF8��ؑւ��A�t�H�[�J�X�𖼏̍i���ɏ����敪��B���ɂ���ύX</br>
    /// <br>Update Note: 2016/02/03 �c����</br>
    /// <br>           : 11200090-00 Redmine#48587</br>
    /// <br>           : �@�����\���������A�u���������v���`�F�b�N�I���ɂ���ύX</br>
    /// <br>           : �A��ʕ\��������AF5�AF6�AF7�AF8��ؑւ��A�u���������v���`�F�b�N�I���ɂ���ύX</br>
    /// <br>Update Note: 2016/02/17  �c����</br>
    /// <br>           : 11200090-00 Redmine#48587</br>
    /// <br>           : �@���̍i���݂̏������̓��[�h���u���p�J�i�v�ɂ���ύX</br>
    /// <br>           : �A�A���[�L�[�Aenter�Atab�̃t�H�[�J�X�J�ڂ̑Ή�</br>
    /// <br>Update Note: 2016/12/26 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11270116-00 ����`�[���̓p�b�P�[�W�o�חp�\�[�X�̃}�[�W</br>
    /// <br>             Designer.cs�̏C��</br>
    /// </remarks>
    internal partial class SelectionForm2 : Form
    {
        # region �ϐ���`
        private BlInfo.BL1DataTable _blInfoTable = null;

        private BlInfo.BLDataTable _dt;
        /// <summary>�K�C�h�p���X�g</summary>
        private ArrayList lstGuide = null;
        /// <summary>���_�R�[�h�iBL�R�[�h�K�C�h�\���p�j</summary>
        private string _sectionCd;

        /// <summary>���ݕ\�����y�[�W�̐擪�ʒu</summary>
        private int curPos = 0;
        /// <summary>�S��BL�J�E���g</summary>
        private int cnt;
        private bool flipflopFlg = false;
        private bool isUserClose;
        private bool guideOn = false;

        private RetType retType;

        private const int ct_CntPerPage = 54;
        private const int ct_CntPerColumn = 18;
        private bool flgPgTxt = false;
        private int time_count;//ADD 2016/02/17 �c���� Redmine#48587
        # endregion

        #region [ �R���X�g���N�^ ]
        /// <summary>
        /// �I����ʃR���X�g���N�^
        /// </summary>
        /// <param name="myOwner"></param>
        /// <param name="dt">�O���b�h�ɕ\������f�[�^���w�肵�܂��B</param>
        /// <param name="sectionCd"></param>
        public SelectionForm2(Form myOwner, BlInfo.BLDataTable dt, string sectionCd)
        {
            InitializeComponent();
            // DataTable �̐ݒ�
            Owner = myOwner;
            _dt = new BlInfo.BLDataTable();
            _dt.Merge(dt);
            _dt.DefaultView.RowFilter = string.Empty;
            _sectionCd = sectionCd;

            InitializeForm();
            _blInfoTable = new BlInfo.BL1DataTable();
            ((StateButtonTool)ToolbarsManager.Tools["Btn_ByCode"]).Checked = true; // �R�[�h����BL�R�[�h�\��
            //InitializeData();
            flipflopFlg = true;
            ((StateButtonTool)ToolbarsManager.Tools["Button_All"]).Checked = true;
            flipflopFlg = false;
        }
        #endregion

        #region [ �������� ]
        private void InitializeForm()
        {
            // �X�e�[�^�X�o�[�̏�����
            StatusBar.Panels[0].Text = "";

            // �c�[���o�[�̃C���[�W(16x16)�⃁�b�Z�[�W��ݒ肷��
            ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
            ToolbarsManager.Tools["Button_Select"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            ToolbarsManager.Tools["Button_Back"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            ToolbarsManager.Tools["Button_All"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            ToolbarsManager.Tools["Button_Search"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PARTSSELECT;
            ToolbarsManager.Tools["Button_Pos"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.LABEL;
            ToolbarsManager.Tools["Button_Guide"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            ToolbarsManager.Tools["Btn_PrevPg"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE2;
            ToolbarsManager.Tools["Btn_NextPg"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEXT2;
            if (((SelectionForm)Owner)._orgBlInfoTable.Count == 0)
            {
                //ToolbarsManager.Tools["Button_All"].SharedProps.Visible = false;
                ToolbarsManager.Tools["Button_Search"].SharedProps.Visible = false;
            }

        }

        /// <summary>
        /// �\���p�f�[�^��DataTable�ɓo�^���邽�߂̃T�u�X���b�h
        /// </summary>
        private void InitializeData()
        {
            _blInfoTable.Clear();
            _blInfoTable.BeginLoadData();
            try
            {
                if (guideOn) // BL�R�[�h�K�C�h�\���̏ꍇ�̃f�[�^�ݒ�
                {
                    int pg = curPos / ct_CntPerPage + 1;
                    BlInfo.BL1Row wkRow;
                    for (int i = 0; i < ct_CntPerColumn; i++)
                    {
                        wkRow = _blInfoTable.NewBL1Row();
                        _blInfoTable.AddBL1Row(wkRow);
                    }
                    for (int i = 0; i < lstGuide.Count; i++)
                    {
                        BLCodeGuide blCodeGuide = lstGuide[i] as BLCodeGuide;
                        if (blCodeGuide.BLCodeDspPage == pg)
                        {
                            string blCd = blCodeGuide.BLGoodsCode.ToString("00000");
                            string blName = blCodeGuide.BLGoodsName;
                            wkRow = _blInfoTable[blCodeGuide.BLCodeDspRow - 1];
                            switch (blCodeGuide.BLCodeDspCol)
                            {
                                case 1:
                                    wkRow.BLCd = blCd;
                                    wkRow.BLName = blName;
                                    break;
                                case 2:
                                    wkRow.BLCd2 = blCd;
                                    wkRow.BLName2 = blName;
                                    break;
                                case 3:
                                    wkRow.BLCd3 = blCd;
                                    wkRow.BLName3 = blName;
                                    break;
                            }
                        }
                    }
                }
                else // BL�S�\���̏ꍇ�̃f�[�^�ݒ�
                {
                    DataRowView row;
                    for (int i = curPos; i < curPos + ct_CntPerColumn; i++)
                    {
                        BlInfo.BL1Row wkRow = wkRow = _blInfoTable.NewBL1Row();
                        if (i < cnt) // ��1�J����
                        {
                            row = _dt.DefaultView[i];
                            wkRow[_blInfoTable.BLCdColumn] = string.Format("{0:00000}", row[_dt.BLCdColumn.ColumnName]);
                            wkRow[_blInfoTable.BLNameColumn] = row[_dt.BLNameColumn.ColumnName];
                        }
                        if (i + ct_CntPerColumn < cnt) // ��2�J����
                        {
                            row = _dt.DefaultView[i + ct_CntPerColumn];
                            wkRow[_blInfoTable.BLCd2Column] = string.Format("{0:00000}", row[_dt.BLCdColumn.ColumnName]);
                            wkRow[_blInfoTable.BLName2Column] = row[_dt.BLNameColumn.ColumnName];
                        }
                        if (i + ct_CntPerColumn * 2 < cnt) // ��3�J����
                        {
                            row = _dt.DefaultView[i + ct_CntPerColumn * 2];
                            wkRow[_blInfoTable.BLCd3Column] = string.Format("{0:00000}", row[_dt.BLCdColumn.ColumnName]);
                            wkRow[_blInfoTable.BLName3Column] = row[_dt.BLNameColumn.ColumnName];
                        }
                        _blInfoTable.AddBL1Row(wkRow);
                    }
                }
            }
            finally
            {
                _blInfoTable.EndLoadData();
                gridBL.BeginUpdate();
                gridBL.DataSource = _blInfoTable;
                gridBL.EndUpdate();
                RefreshDataCount(); // [���y�[�W�^���y�[�W]�\���X�V
            }
        }
        #endregion

        #region [ �t�H�[���C�x���g���� ]

        /// <summary>
        /// ESC�L�[�����ɂ��I������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionForm2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstBlCd"></param>
        /// <param name="result">BL�S�\����ʂ���Ă��珈���t���O</param>
        /// <param name="isGuide">true : �K�C�h�\�� / false : BL�S�\��</param>
        /// <returns></returns>
        internal DialogResult ShowDialog(out List<int> lstBlCd, out RetType result, bool isGuide)
        {
            isUserClose = true;
            lstBlCd = new List<int>();
            if (isGuide) // �K�C�h�\���̏ꍇ
            {
                ((StateButtonTool)ToolbarsManager.Tools["Button_Guide"]).Checked = true;
            }
            else
            {
                if (((StateButtonTool)ToolbarsManager.Tools["Button_Guide"]).Checked)
                {
                    ((StateButtonTool)ToolbarsManager.Tools["Button_All"]).Checked = true;
                }
            }
            if (this.Left + this.Width > Screen.PrimaryScreen.Bounds.Width - 200)
            {
                this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 200;
            }
            DialogResult ret = base.ShowDialog();
            if (isUserClose)
            {
                result = RetType.Cancel;
            }
            else
            {
                result = retType;
            }
            if (ret == DialogResult.OK)
            {
                for (int i = 0; i < ultraListView1.Items.Count; i++)
                {
                    lstBlCd.Add((int)ultraListView1.Items[i].Value);
                }
            }
            return ret;
        }
        #endregion

        #region [ �c�[���o�[�C�x���g���� ]
        /// <summary>
        /// �c�[���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2013/02/06 donggy </br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M</br>
        /// <br>             Redmine#33919�Ή�</br>
        /// <br>Update Note: 2016/01/13 �c����</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : �@�����\���������A�����t�H�[�J�X�𖼏̍i���ɏ����敪��B���ɂ���ύX</br>
        /// <br>           : �A��ʕ\��������AF5�AF6�AF7�AF8��ؑւ��A�t�H�[�J�X�𖼏̍i���ɏ����敪��B���ɂ���ύX</br>
        /// <br>Update Note: 2016/02/03 �c����</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : �@�����\���������A�u���������v���`�F�b�N�I���ɂ���ύX</br>
        /// <br>           : �A��ʕ\��������AF5�AF6�AF7�AF8��ؑւ��A�u���������v���`�F�b�N�I���ɂ���ύX</br>
        /// </remarks>
        private void ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if (flipflopFlg)
                return;
            switch (e.Tool.Key)
            {
                case "Button_Select": // �I������Ă���s���m�肷��
                    retType = RetType.OK;
                    isUserClose = false;
                    DialogResult = DialogResult.OK;
                    break;

                case "Button_Back": // �O�̉�ʂɖ߂�
                    retType = RetType.Cancel;
                    isUserClose = false;
                    DialogResult = DialogResult.Cancel;
                    break;

                case "Button_All": // �S�\��
                    if (((StateButtonTool)ToolbarsManager.Tools["Button_All"]).Checked)
                    {
                        guideOn = false;
                        flipflopFlg = true;
                        ToolbarsManager.Tools["Btn_ByCode"].SharedProps.Enabled = true;
                        ToolbarsManager.Tools["Btn_ByName"].SharedProps.Enabled = true;
                        ((StateButtonTool)ToolbarsManager.Tools["Button_Guide"]).Checked = false;
                        flipflopFlg = false;
                        cnt = _dt.DefaultView.Count;
                        InitializeData();
                    }
                    else
                    {
                        flipflopFlg = true;
                        ((StateButtonTool)ToolbarsManager.Tools["Button_All"]).Checked = true;
                        flipflopFlg = false;
                    }
                    // --- ADD donggy 2013/02/06 for Redmine#33919 ------>>>>>>
                    //�敪�ʕύX���鎞�A�i���̖��̂̃N���A
                    txtName.Clear();
                    BLFiltering();
                    // --- ADD donggy 2013/02/06 for Redmine#33919 ------<<<<<<
                    //----- ADD 2016/01/13 �c���� Redmine#48587 ----->>>>>
                    // �����t�H�[�J�X�F���̍i���ɐݒ肵�A�u�B���v���`�F�b�N�I��
                    this.OptionSearch.CheckedIndex = 1;
                    this.txtName.Focus();
                    this.chkSearch.Checked = true;//ADD 2016/02/03 �c���� Redmine#48587
                    //----- ADD 2016/01/13 �c���� Redmine#48587 -----<<<<<
                    break;

                case "Button_Search": // �����\�Ώۂ̂ݕ\��                    
                    retType = RetType.ShowSearch;
                    flipflopFlg = true;
                    ((StateButtonTool)ToolbarsManager.Tools["Button_Search"]).Checked = false;
                    flipflopFlg = false;
                    isUserClose = false;
                    DialogResult = DialogResult.Cancel;
                    break;

                case "Button_Pos": // ���ʕʕ\������                    
                    retType = RetType.ShowPos;
                    flipflopFlg = true;
                    ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked = false;
                    flipflopFlg = false;
                    isUserClose = false;
                    DialogResult = DialogResult.Cancel;
                    break;

                case "Button_Guide": // BL�R�[�h�K�C�h�\��
                    ShowByGuide();
                    break;

                case "Btn_PrevPg":
                    if (curPos == 0)
                    {
                        StatusBar.Panels[0].Text = "�擪�y�[�W�ł��B";
                    }
                    else
                    {
                        StatusBar.Panels[0].Text = "";
                        curPos -= ct_CntPerPage;
                        InitializeData();
                    }
                    break;

                case "Btn_NextPg":
                    if (curPos + ct_CntPerPage >= cnt)
                    {
                        StatusBar.Panels[0].Text = "�Ō�y�[�W�ł��B";
                    }
                    else
                    {
                        StatusBar.Panels[0].Text = "";
                        curPos += ct_CntPerPage;
                        InitializeData();
                    }
                    break;

                case "Btn_ByCode":
                    if (((StateButtonTool)ToolbarsManager.Tools["Btn_ByCode"]).Checked)
                    {
                        _dt.DefaultView.Sort = _dt.BLCdColumn.ColumnName;
                        cnt = _dt.DefaultView.Count;
                        flipflopFlg = true;
                        ((StateButtonTool)ToolbarsManager.Tools["Btn_ByName"]).Checked = false;
                        flipflopFlg = false;
                        InitializeData();
                    }
                    else
                    {
                        flipflopFlg = true;
                        ((StateButtonTool)ToolbarsManager.Tools["Btn_ByCode"]).Checked = true;
                        flipflopFlg = false;
                    }
                    break;

                case "Btn_ByName":
                    if (((StateButtonTool)ToolbarsManager.Tools["Btn_ByName"]).Checked)
                    {
                        _dt.DefaultView.Sort = _dt.BLNameColumn.ColumnName;
                        cnt = _dt.DefaultView.Count;
                        flipflopFlg = true;
                        ((StateButtonTool)ToolbarsManager.Tools["Btn_ByCode"]).Checked = false;
                        flipflopFlg = false;
                        InitializeData();
                    }
                    else
                    {
                        flipflopFlg = true;
                        ((StateButtonTool)ToolbarsManager.Tools["Btn_ByName"]).Checked = true;
                        flipflopFlg = false;
                    }
                    break;
            }
            //txtBLCode.Select();
        }

        private void ToolbarsManager_AfterToolExitEditMode(object sender, AfterToolExitEditModeEventArgs e)
        {
            int pg;
            if (int.TryParse(((TextBoxTool)e.Tool).Text, out pg))
            {
                if (pg < (((cnt - 1) / ct_CntPerPage) + 2))
                {
                    curPos = (pg - 1) * ct_CntPerPage;
                    InitializeData();
                }
            }
            StatusBar.Panels[0].Text = "";
            flgPgTxt = true;
            ((TextBoxTool)e.Tool).Text = string.Empty;
            txtBLCode.Select();
        }

        private void ToolbarsManager_BeforeToolActivate(object sender, CancelableToolEventArgs e)
        {
            if (e.Tool.Key == "Button_Select" && flgPgTxt)
            {
                e.Cancel = true;
            }
            flgPgTxt = false;
        }

        /// <summary>
        /// BL�R�[�h�K�C�h�\��
        /// </summary>
        /// <remarks>
        /// <br>Update Note: 2013/02/06 donggy </br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M</br>
        /// <br>             Redmine#33919�Ή�</br>
        /// <br>Update Note: 2016/01/13 �c����</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : �@�����\���������A�����t�H�[�J�X�𖼏̍i���ɏ����敪��B���ɂ���ύX</br>
        /// <br>           : �A��ʕ\��������AF5�AF6�AF7�AF8��ؑւ��A�t�H�[�J�X�𖼏̍i���ɏ����敪��B���ɂ���ύX</br>
        /// <br>Update Note: 2016/02/03 �c����</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : �@�����\���������A�u���������v���`�F�b�N�I���ɂ���ύX</br>
        /// <br>           : �A��ʕ\��������AF5�AF6�AF7�AF8��ؑւ��A�u���������v���`�F�b�N�I���ɂ���ύX</br>
        /// </remarks>
        private void ShowByGuide()
        {
            if (((StateButtonTool)ToolbarsManager.Tools["Button_Guide"]).Checked)
            {
                guideOn = true;
                flipflopFlg = true;
                ToolbarsManager.Tools["Btn_ByCode"].SharedProps.Enabled = false;
                ToolbarsManager.Tools["Btn_ByName"].SharedProps.Enabled = false;
                ((StateButtonTool)ToolbarsManager.Tools["Button_All"]).Checked = false;
                flipflopFlg = false;
                if (lstGuide == null)
                {
                    BLCodeGuideAcs blCodeGuideAcs = new BLCodeGuideAcs();
                    int status = blCodeGuideAcs.Search(out lstGuide, LoginInfoAcquisition.EnterpriseCode,
                        _sectionCd, ConstantManagement.LogicalMode.GetData0);
                    if (status != 0)
                    {
                        if (status == 9)
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, Text, "BL�R�[�h�K�C�h���ݒ肳��Ă��܂���B", 0, MessageBoxButtons.OK);
                        else
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, Text, "BL�R�[�h�K�C�h�̎擾�Ɏ��s���܂����B", 0, MessageBoxButtons.OK);
                        lstGuide = null;
                        flipflopFlg = true;
                        ToolbarsManager.Tools["Btn_ByCode"].SharedProps.Enabled = false;
                        ToolbarsManager.Tools["Btn_ByName"].SharedProps.Enabled = false;
                        ((StateButtonTool)ToolbarsManager.Tools["Button_Guide"]).Checked = false;
                        flipflopFlg = false;
                        ((StateButtonTool)ToolbarsManager.Tools["Button_All"]).Checked = true;
                        return;
                    }
                }
                cnt = ct_CntPerPage * 5; // 1�y�[�W������54����5�y�[�W��
                curPos = 0;
                InitializeData();
            }
            else
            {
                flipflopFlg = true;
                ((StateButtonTool)ToolbarsManager.Tools["Button_Guide"]).Checked = true;
                flipflopFlg = false;
            }
            // --- ADD donggy 2013/02/06 for Redmine#33919 ------>>>>>>
            //�敪�ʕύX���鎞�A�i���̖��̂̃N���A
            txtName.Clear();
            BLFiltering();
            // --- ADD donggy 2013/02/06 for Redmine#33919 ------<<<<<<
            //----- ADD 2016/01/13 �c���� Redmine#48587 ----->>>>>
            // �����t�H�[�J�X�F���̍i���ɐݒ肵�A�u�B���v���`�F�b�N�I��
            this.OptionSearch.CheckedIndex = 1;
            this.txtName.Focus();
            this.chkSearch.Checked = true;//ADD 2016/02/03 �c���� Redmine#48587
            //----- ADD 2016/01/13 �c���� Redmine#48587 -----<<<<<
        }

        #endregion

        #region [ �O���b�h�C�x���g���� ]
        /// <summary>
        /// InitializeLayout �C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>�O���b�h�̃��C�A�E�g����������</br>
        /// </remarks>
        private void gridBLInfo_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            #region �O���b�h�̃��C�A�E�g������
            // �񕝂̎����������@
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.SelectTypeRow = SelectType.Single;

            // �o���h�̎擾
            UltraGridBand Band = e.Layout.Bands[0];
            Band.UseRowLayout = true;

            for (int Index = 0; Index < Band.Columns.Count; Index++)
            {
                // �����\���ʒu
                if (Band.Columns[Index].DataType == typeof(int))
                {
                    Band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else
                {
                    Band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                Band.Columns[Index].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;

                // �����\���ʒu
                Band.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }

            SelectionForm.ColInfo.SetColInfo(Band, _blInfoTable.BLCdColumn.ColumnName, 2, 0, 1, 2, 22);
            SelectionForm.ColInfo.SetColInfo(Band, _blInfoTable.BLNameColumn.ColumnName, 3, 0, 5, 2, 130);
            SelectionForm.ColInfo.SetColInfo(Band, _blInfoTable.BLCd2Column.ColumnName, 8, 0, 1, 2, 21);
            SelectionForm.ColInfo.SetColInfo(Band, _blInfoTable.BLName2Column.ColumnName, 9, 0, 5, 2, 130);
            SelectionForm.ColInfo.SetColInfo(Band, _blInfoTable.BLCd3Column.ColumnName, 14, 0, 1, 2, 21);
            SelectionForm.ColInfo.SetColInfo(Band, _blInfoTable.BLName3Column.ColumnName, 15, 0, 5, 2, 130);
            #endregion
        }

        #endregion

        #region [ �t�B���^�����O���� ]
        private void txtName_ValueChanged(object sender, EventArgs e)
        {
            if (chkSearch.Checked && txtName.Text.Equals(txtName.Tag) == false)
            {
                BLFiltering();
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (chkSearch.Checked == false && txtName.Text.Equals(txtName.Tag) == false)
            {
                BLFiltering();
            }
        }

        private void OptionSearch_ValueChanged(object sender, EventArgs e)
        {
            BLFiltering();
        }

        private void BLFiltering()
        {
            if (guideOn == false)
            {
                if (txtName.Text != string.Empty)
                {
                    if (OptionSearch.Value.Equals(true)) // �B������
                        _dt.DefaultView.RowFilter = string.Format("{0} like '%{1}%'", _dt.BLNameColumn.ColumnName, txtName.Text);
                    else // �O����v����
                        _dt.DefaultView.RowFilter = string.Format("{0} like '{1}%'", _dt.BLNameColumn.ColumnName, txtName.Text);
                }
                else
                {
                    _dt.DefaultView.RowFilter = string.Empty;
                }
                cnt = _dt.DefaultView.Count;
                curPos = 0;
                InitializeData();
                txtName.Tag = txtName.Text;
            }
            // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
            // �K�C�h�̖��̍i���̒ǉ�
            else
            {
                // �K�C�h�ʂ̃f�[�^�̎擾
                BLCodeGuideAcs blCodeGuideAcs = new BLCodeGuideAcs();
                int status = blCodeGuideAcs.Search(out lstGuide, LoginInfoAcquisition.EnterpriseCode,
                    _sectionCd, ConstantManagement.LogicalMode.GetData0);
                if (status != 0)
                {
                    if (status == 9)
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, Text, "BL�R�[�h�K�C�h���ݒ肳��Ă��܂���B", 0, MessageBoxButtons.OK);
                    else
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, Text, "BL�R�[�h�K�C�h�̎擾�Ɏ��s���܂����B", 0, MessageBoxButtons.OK);
                    lstGuide = null;
                    flipflopFlg = true;
                    ToolbarsManager.Tools["Btn_ByCode"].SharedProps.Enabled = false;
                    ToolbarsManager.Tools["Btn_ByName"].SharedProps.Enabled = false;
                    ((StateButtonTool)ToolbarsManager.Tools["Button_Guide"]).Checked = false;
                    flipflopFlg = false;
                    ((StateButtonTool)ToolbarsManager.Tools["Button_All"]).Checked = true;
                    return;
                }
                //�i���pDataTable��DataView
                DataTable tempGuideTable = new DataTable();
                DataView tempGuideView = new DataView(tempGuideTable);
                tempGuideTable.Columns.Add("BLCodeDspCol", typeof(int));
                tempGuideTable.Columns.Add("BLCodeDspPage", typeof(int));
                tempGuideTable.Columns.Add("BLCodeDspRow", typeof(int));
                tempGuideTable.Columns.Add("BLGoodsCode", typeof(int));
                tempGuideTable.Columns.Add(_dt.BLNameColumn.ColumnName, typeof(string));
                tempGuideTable.Columns.Add("EnterpriseCode", typeof(string));
                tempGuideTable.Columns.Add("SectionCode", typeof(string));
                DataRow row = null;
                // �K�C�h�ʂ̃f�[�^���i���pDataTable�ɗ��Ƃ�
                foreach (BLCodeGuide blCodeGuide in lstGuide)
                {
                    row = tempGuideTable.NewRow();
                    row["BLCodeDspCol"] = blCodeGuide.BLCodeDspCol;
                    row["BLCodeDspPage"] = blCodeGuide.BLCodeDspPage;
                    row["BLCodeDspRow"] = blCodeGuide.BLCodeDspRow;
                    row["BLGoodsCode"] = blCodeGuide.BLGoodsCode;
                    row[_dt.BLNameColumn.ColumnName] = blCodeGuide.BLGoodsName;
                    row["EnterpriseCode"] = blCodeGuide.EnterpriseCode;
                    row["SectionCode"] = blCodeGuide.SectionCode;
                    tempGuideTable.Rows.Add(row);
                }
                //�i�����s
                if (txtName.Text != string.Empty)
                {
                    ArrayList tempGuide = new ArrayList();
                    if (OptionSearch.Value.Equals(true)) // �B������
                        tempGuideView.RowFilter = string.Format("{0} like '%{1}%'", _dt.BLNameColumn.ColumnName, txtName.Text);
                    else // �O����v����
                        tempGuideView.RowFilter = string.Format("{0} like '{1}%'", _dt.BLNameColumn.ColumnName, txtName.Text);
                    int rowNo = 1;
                    int colNo = 0;
                    BLCodeGuide tempBLCodeGuide = null;
                    //�i����̃f�[�^�̕\���ʒu�̐ݒ�
                    foreach( DataRowView tempRow in tempGuideView)
                    {
                        tempBLCodeGuide = new BLCodeGuide();
                        if (colNo < 3)
                        {
                            tempRow["BLCodeDspRow"] = rowNo;
                        }
                        else
                        {
                            tempRow["BLCodeDspRow"] = rowNo + 1;
                            colNo = 0;
                        }
                        tempRow["BLCodeDspCol"] = colNo + 1;
                        colNo++;
                        //�\���p�f�[�^�̎擾
                        foreach (BLCodeGuide blCodeGuide in lstGuide)
                        {
                            if (blCodeGuide.BLCodeDspPage.ToString() == tempRow["BLCodeDspPage"].ToString() && blCodeGuide.BLGoodsCode.ToString() == tempRow["BLGoodsCode"].ToString()
                                && blCodeGuide.EnterpriseCode == tempRow["EnterpriseCode"].ToString() && blCodeGuide.SectionCode == tempRow["SectionCode"].ToString()
                                && blCodeGuide.BLGoodsName == tempRow[_dt.BLNameColumn.ColumnName].ToString())
                            {
                                blCodeGuide.BLCodeDspCol = (int)tempRow["BLCodeDspCol"];
                                blCodeGuide.BLCodeDspRow = (int)tempRow["BLCodeDspRow"];
                                tempGuide.Add(blCodeGuide);
                            }
                        }

                    }
                    lstGuide = tempGuide;
                    cnt = lstGuide.Count;
                }
                else
                {
                   tempGuideView.RowFilter = string.Empty;
                   cnt = ct_CntPerPage * 5;
                }
                curPos = 0;
                InitializeData();
                txtName.Tag = txtName.Text;
            }
            // --- ADD donggy 2013/02/06 for Redmine#33919 --- <<<<<<
        }
        #endregion

        #region [ BL�R�[�h�o�^���� ]
        private void txtBLCode_Validating(object sender, CancelEventArgs e)
        {
            DoBLRegister();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int cnt = ultraListView1.SelectedItems.Count;
            for (int i = 0; i < cnt; i++)
                ultraListView1.Items.RemoveAt(ultraListView1.SelectedItems[0].Index);
            txtBLCode.Select();
        }

        /// <summary>
        /// �A���[�L�[�Aenter�Atab�̃t�H�[�J�X�J��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2016/02/17  �c����</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : �A�A���[�L�[�Aenter�Atab�̃t�H�[�J�X�J�ڂ̑Ή�</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            //if (e.PrevCtrl == txtBLCode && e.NextCtrl == gridBL)
            //----- DEL 2016/02/17 �c���� Redmine#48587 ----->>>>>
            //if (e.PrevCtrl == txtBLCode)// && e.NextCtrl == btnDel)
            //{
            //    DoBLRegister();
            //    e.NextCtrl = txtBLCode;
            //}
            //else
            //{
            //    e.NextCtrl = txtBLCode;
            //}
            //----- DEL 2016/02/17 �c���� Redmine#48587 -----<<<<<
            //----- ADD 2016/02/17 �c���� Redmine#48587 ----->>>>>
            switch (e.Key)
            {
                case Keys.Enter:
                case Keys.Tab:
                    if (e.PrevCtrl == txtBLCode)
                    {
                        //SHIFT�������Ȃ�
                        if (!e.ShiftKey)
                        {
                            DoBLRegister();
                            e.NextCtrl = txtBLCode;
                        }
                        //SHIFT+ENTER�ASHIFT+TAB�@BL�R�[�h�ˑO���E�B��
                        else
                        {
                            DoBLRegister();
                            e.NextCtrl = OptionSearch;
                        }
                    }
                    //SHIFT+ENTER�ASHIFT+TAB�@���̍i���݁�BL�R�[�h
                    else if (e.PrevCtrl == txtName)
                    {
                        if (e.ShiftKey)
                        {
                            e.NextCtrl = txtBLCode;
                        }
                    }
                    break;
            }
            //----- ADD 2016/02/17 �c���� Redmine#48587 -----<<<<<
        }

        private void DoBLRegister()
        {
            int bl;
            if (int.TryParse(txtBLCode.Text, out bl) && _dt.FindByBLCd(bl) != null)
            {
                ultraListView1.Items.Add(ultraListView1.Items.ToString(), bl);
            }
            txtBLCode.Clear();
        }
        #endregion

        /// <summary>
        /// [���y�[�W�^���y�[�W]�\���X�V
        /// </summary>
        private void RefreshDataCount()
        {
            int pg = curPos / ct_CntPerPage + 1;
            string cntMsg;
            cntMsg = string.Format("{0} / {1}", pg, ((cnt - 1) / ct_CntPerPage) + 1);

            ToolbarsManager.Tools["lbl_Cnt"].SharedProps.Caption = cntMsg;
        }

        //----- ADD 2016/01/13 �c���� Redmine#48587 ----->>>>>
        /// <summary>
        /// ��ʂ̕\��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g</param>
        /// <remarks>
        /// <br>Update Note: 2016/01/13 �c����</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : �@�����\���������A�����t�H�[�J�X�𖼏̍i���ɏ����敪��B���ɂ���ύX</br>
        /// <br>           : �A��ʕ\��������AF5�AF6�AF7�AF8��ؑւ��A�t�H�[�J�X�𖼏̍i���ɏ����敪��B���ɂ���ύX</br>
        /// <br>Update Note: 2016/02/03 �c����</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : �@�����\���������A�u���������v���`�F�b�N�I���ɂ���ύX</br>
        /// <br>           : �A��ʕ\��������AF5�AF6�AF7�AF8��ؑւ��A�u���������v���`�F�b�N�I���ɂ���ύX</br>
        /// </remarks>
        private void SelectionForm2_Shown(object sender, EventArgs e)
        {
            // BL�R�[�h�K�C�h�����\���敪���uBL�R�[�h�K�C�h�v�̏ꍇ�A
            // �����t�H�[�J�X�F���̍i���ɐݒ肵�A�u�B���v���`�F�b�N�I��
            this.OptionSearch.CheckedIndex = 1;
            this.txtName.Focus();
            this.chkSearch.Checked = true;//ADD 2016/02/03 �c���� Redmine#48587
        }
        //----- ADD 2016/01/13 �c���� Redmine#48587 -----<<<<<

        //----- ADD 2016/02/17 �c���� Redmine#48587 ----->>>>>
        /// <summary>
        /// ������͂���N���̏ꍇ�A�J�[�\�����擾�ł��Ȃ�������Q����̂ŁA�����J�[�\����timer1_Tick�Łu���̍i���݁v�ɃZ�b�g����B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2016/02/17 �c����</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : ���̍i���݂̏������̓��[�h���u���p�J�i�v�ɂ���</br>
        /// </remarks>
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            this.label1.Focus();
            this.txtName.Focus();
            time_count++;
            if (time_count > 1)
            {
                this.timer1.Enabled = false;
            }
        }

        /// <summary>
        /// ������͂���N���̏ꍇ�A�J�[�\�����擾�ł��Ȃ�������Q����̂ŁA�����J�[�\����timer1_Tick�Łu���̍i���݁v�ɃZ�b�g����B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2016/02/17 �c����</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : ���̍i���݂̏������̓��[�h���u���p�J�i�v�ɂ���</br>
        /// </remarks>
        private void SelectionForm2_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
        }
        //----- ADD 2016/02/17 �c���� Redmine#48587 -----<<<<<
    }

    internal enum RetType
    {
        OK = 0,
        Cancel = 1,
        ShowSearch = 2,
        ShowPos = 3
    }
}