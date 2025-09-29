//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d���`�F�b�N���X�g
// �v���O�����T�v   : �d���`�F�b�N���X�g���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2009/05/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� �� 2009/08/07   �C�����e : �J�[�\����PM���_�̖��̂ֈړ��������ɓ��͉\��ԁi�Z�����I�����W�F�j�ƂȂ�悤�ɏC�� 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Infragistics.Win.UltraWinGrid;
using System.Collections;
using Infragistics.Win;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���_�ϊ��ݒ�UI�N���X                                                         
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���_�ϊ��ݒ�UI�ŁA���o��������͂��܂��B</br>       
    /// <br>Programmer : ����</br>                                   
    /// <br>Date       : 2009.05.10</br>                                   
    /// </remarks>
    public partial class PMKOU02050UB : Form
    {
        #region �� Constants

        // �v���O����ID
        private const string ASSEMBLY_ID = "PMKOU02050UB";

        // �O���b�h��^�C�g��
        private const string COLUMN_CSV_NO = "CSV_No";
        private const string COLUMN_CSV_SECCD = "CSV_SecCd";
        private const string COLUMN_PM_NO = "PM_No";
        private const string COLUMN_PM_SECCD = "PM_SecCd";
        private const string COLUMN_PM_SECNM = "PM_SecNm";
        private const string COLUMN_PM_SECGUIDE = "PM_SecGuide";
        #region �� Private Members

        private SecInfoAcs _secInfoAcs;
        private SecInfoSetAcs _secInfoSetAcs;

        private Dictionary<string, SecInfoSet> _secInfoSetDic;

        private SectionCdInputConstructionAcs _sectionCdInputConstructionAcs = null;

        private Hashtable _inputData = new Hashtable();
        private ArrayList keyData = new ArrayList();
        private ArrayList keyData1 = new ArrayList();
        private ArrayList keyData2 = new ArrayList();
        private ArrayList valueData = new ArrayList();

        private string firstGridActiveStr = null;
        private string beforeChangeStr = null;
        private int firstGridActiveRow;

        private DataTable dataTableCsv = new DataTable();
        private DataTable dataTablePm = new DataTable();
        private string _enterpriseCode;
        private ControlScreenSkin _controlScreenSkin;           // ��ʃf�U�C���ύX�N���X
   

        #endregion �� Private Members
        #endregion �� Constants

        /// <summary>
        /// ���_�ϊ��ݒ�UI�N���X�R���X�g���N�^�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@ �@
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_�ϊ��ݒ�UI����������уC���X�^���X�̐������s��</br>                 
        /// <br>Programmer : ����</br>                                  
        /// <br>Date       : 2009.05.10</br>                                     
        /// </remarks>
        public PMKOU02050UB()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();

            this._controlScreenSkin = new ControlScreenSkin();

            // �}�X�^�Ǎ�
            ReadSecInfoSet();

            // DataSet����\�z
            this.Bind_DataSet = new DataSet();

            this._sectionCdInputConstructionAcs = new SectionCdInputConstructionAcs();
            keyData = this._sectionCdInputConstructionAcs.InputSecCdCSV;
            valueData = this._sectionCdInputConstructionAcs.InputSecCdPM;
            if (keyData != null)
            {
                for (int i = 0; i < keyData.Count; i++)
                {
                    _inputData.Add(keyData[i], valueData[i]);
                }
            }
                      
        }


        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �t�H�[����Load���ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void PMKOU02050UB_Load(object sender, EventArgs e)
        {
            // ��ʏ����ݒ�
            SetScreenInitialSetting();

            this.timer_SetFocus.Enabled = true;
        }

        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void SetScreenInitialSetting()
        {
            // �}�X�^�Ǎ�
            ReadSecInfoSet();

            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList16 = IconResourceManagement.ImageList16;
            ImageList imageList24 = IconResourceManagement.ImageList24;

            this.Ok_Button.ImageList = imageList24;
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.ImageList = imageList24;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

            // �O���b�h�\�z
            dataTableCsv.Columns.Add(COLUMN_CSV_NO, typeof(string));
            dataTableCsv.Columns.Add(COLUMN_CSV_SECCD, typeof(string));

            dataTablePm.Columns.Add(COLUMN_PM_NO, typeof(string));
            dataTablePm.Columns.Add(COLUMN_PM_SECCD, typeof(string));
            dataTablePm.Columns.Add(COLUMN_PM_SECNM, typeof(string));
            dataTablePm.Columns.Add(COLUMN_PM_SECGUIDE, typeof(string));

            if (_inputData.Count > 0)
            {
                keyData1 = new ArrayList (_inputData.Keys);
                keyData1.Sort();
                keyData2 = new ArrayList(_inputData.Values);
                for (int i = 0; i < keyData1.Count; i++)
                {
                    DataRow dataRowCsv = dataTableCsv.NewRow();
                    dataRowCsv[COLUMN_CSV_NO] = "";
                    dataRowCsv[COLUMN_CSV_SECCD] = keyData1[i];
                    dataTableCsv.Rows.Add(dataRowCsv);
                }

                ArrayList firstPmData = new ArrayList();
                firstPmData = (ArrayList)_inputData[keyData1[0]];
                firstPmData.Sort();
                for (int j = 0; j < firstPmData.Count; j++)
                {
                    DataRow dataRowPm = dataTablePm.NewRow();
                    dataRowPm[COLUMN_PM_NO] = "";
                    dataRowPm[COLUMN_PM_SECCD] = firstPmData[j].ToString();
                    dataRowPm[COLUMN_PM_SECNM] = GetSectionName(firstPmData[j].ToString().Trim());
                    dataTablePm.Rows.Add(dataRowPm);

                }
                
            }
            DataRow dataRowCsvbk = dataTableCsv.NewRow();
            dataRowCsvbk[COLUMN_CSV_NO] = "";
            dataRowCsvbk[COLUMN_CSV_SECCD] = "";
            dataTableCsv.Rows.Add(dataRowCsvbk);

            DataRow dataRowPmbk = dataTablePm.NewRow();
            dataRowPmbk[COLUMN_PM_NO] = "";
            dataRowPmbk[COLUMN_PM_SECCD] = "";
            dataRowPmbk[COLUMN_PM_SECNM] = "";
            dataRowPmbk[COLUMN_PM_SECGUIDE] = "";
            dataTablePm.Rows.Add(dataRowPmbk);
            
            this.First_Grid.DataSource = dataTableCsv;
            this.Second_Grid.DataSource = dataTablePm;

            ColumnsCollection columnsCsv = this.First_Grid.DisplayLayout.Bands[0].Columns;
            ColumnsCollection columnsPm = this.Second_Grid.DisplayLayout.Bands[0].Columns;

            // �w�b�_�[�L���v�V����
            columnsCsv[COLUMN_CSV_NO].Header.Caption = "";
            columnsCsv[COLUMN_CSV_SECCD].Header.Caption = "���_�R�[�h";

            columnsPm[COLUMN_PM_NO].Header.Caption = "";
            columnsPm[COLUMN_PM_SECCD].Header.Caption = "���_�R�[�h";
            columnsPm[COLUMN_PM_SECNM].Header.Caption = "���_����";
            columnsPm[COLUMN_PM_SECGUIDE].Header.Caption = "";

            // TextHAlign
            columnsCsv[COLUMN_CSV_NO].CellAppearance.TextHAlign = HAlign.Right;
            columnsCsv[COLUMN_CSV_SECCD].CellAppearance.TextHAlign = HAlign.Right;

            columnsPm[COLUMN_PM_NO].CellAppearance.TextHAlign = HAlign.Right;
            columnsPm[COLUMN_PM_SECCD].CellAppearance.TextHAlign = HAlign.Right;
            columnsPm[COLUMN_PM_SECNM].CellAppearance.TextHAlign = HAlign.Left;
            columnsPm[COLUMN_PM_SECGUIDE].CellAppearance.TextHAlign = HAlign.Center;

            // TextVAlign
            columnsCsv[COLUMN_CSV_NO].CellAppearance.TextVAlign = VAlign.Middle;
            columnsCsv[COLUMN_CSV_SECCD].CellAppearance.TextVAlign = VAlign.Middle;

            columnsPm[COLUMN_PM_NO].CellAppearance.TextVAlign = VAlign.Middle;
            columnsPm[COLUMN_PM_SECCD].CellAppearance.TextVAlign = VAlign.Middle;
            columnsPm[COLUMN_PM_SECNM].CellAppearance.TextVAlign = VAlign.Middle;
            columnsPm[COLUMN_PM_SECGUIDE].CellAppearance.TextVAlign = VAlign.Middle;

            // ���͐���
            columnsCsv[COLUMN_CSV_NO].CellActivation = Activation.Disabled;
            columnsCsv[COLUMN_CSV_SECCD].CellActivation = Activation.AllowEdit;

            columnsPm[COLUMN_PM_NO].CellActivation = Activation.Disabled;
            columnsPm[COLUMN_PM_SECCD].CellActivation = Activation.AllowEdit;
            columnsPm[COLUMN_PM_SECNM].CellActivation = Activation.Disabled;
            columnsPm[COLUMN_PM_SECGUIDE].CellActivation = Activation.AllowEdit;

            // ��
            columnsCsv[COLUMN_CSV_NO].Width = 20;
            columnsCsv[COLUMN_CSV_SECCD].Width = 110;

            columnsPm[COLUMN_PM_NO].Width = 20;
            columnsPm[COLUMN_PM_SECCD].Width = 110;
            columnsPm[COLUMN_PM_SECNM].Width = 200;
            columnsPm[COLUMN_PM_SECGUIDE].Width = 24;

            // �Z��Color
            columnsCsv[COLUMN_CSV_NO].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            columnsCsv[COLUMN_CSV_NO].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            columnsCsv[COLUMN_CSV_NO].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            columnsCsv[COLUMN_CSV_NO].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            columnsCsv[COLUMN_CSV_NO].CellAppearance.ForeColor = Color.White;
            columnsCsv[COLUMN_CSV_NO].CellAppearance.ForeColorDisabled = Color.White;
            columnsCsv[COLUMN_CSV_NO].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            columnsCsv[COLUMN_CSV_SECCD].CellAppearance.BackColorDisabled = Color.FromKnownColor(KnownColor.Control);

            columnsPm[COLUMN_PM_NO].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            columnsPm[COLUMN_PM_NO].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            columnsPm[COLUMN_PM_NO].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            columnsPm[COLUMN_PM_NO].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            columnsPm[COLUMN_PM_NO].CellAppearance.ForeColor = Color.White;
            columnsPm[COLUMN_PM_NO].CellAppearance.ForeColorDisabled = Color.White;
            columnsPm[COLUMN_PM_NO].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            columnsPm[COLUMN_PM_SECCD].CellAppearance.BackColorDisabled = Color.FromKnownColor(KnownColor.Control);
            columnsPm[COLUMN_PM_SECNM].CellAppearance.BackColor = Color.Gainsboro;
            columnsPm[COLUMN_PM_SECNM].CellAppearance.BackColorDisabled = Color.Gainsboro;

            // MaxLength
            columnsCsv[COLUMN_CSV_SECCD].MaxLength = 10;
            columnsPm[COLUMN_PM_SECCD].MaxLength = 2;
            columnsPm[COLUMN_PM_SECNM].MaxLength = 10;

            // �Z���{�^��
            columnsPm[COLUMN_PM_SECGUIDE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columnsPm[COLUMN_PM_SECGUIDE].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columnsPm[COLUMN_PM_SECGUIDE].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columnsPm[COLUMN_PM_SECGUIDE].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columnsPm[COLUMN_PM_SECGUIDE].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            columnsPm[COLUMN_PM_SECGUIDE].CellAppearance.Cursor = Cursors.Hand;

        }


        /// <summary>
        /// ���_�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_�}�X�^��Ǎ��A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
        }

        /// <summary>
        /// ���_���擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_��</returns>
        /// <remarks>
        /// <br>Note       : ���_�����擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if (this._secInfoSetDic.ContainsKey(sectionCode.Trim()))
            {
                sectionName = this._secInfoSetDic[sectionCode.Trim()].SectionGuideNm.Trim();
            }

            return sectionName;
        }

        /// <summary>
        /// �V�K�s�쐬����
        /// </summary>
        /// <param name="uGrid">�O���b�h</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�ɍs��ǉ����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private void CreateNewRow(ref UltraGrid uGrid)
        {
            // �s�ǉ�
            uGrid.DisplayLayout.Bands[0].AddNew();
        }

        /// <summary>
        /// UltraWinGrid.AfterSelectChange �C�x���g(First_Grid)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">Band�I�u�W�F�N�g�������Ƃ���C�x���g�Ŏg�p�����C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �P�ȏ�̍s�A�Z���A�܂��͗�I�u�W�F�N�g���I���܂��͑I���������ꂽ��ɔ������܂��B </br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void First_Grid_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            if (this.First_Grid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.First_Grid.ActiveCell;
            int rowIndex = cell.Row.Index;

            // ��l�̏ꍇ
            if (cell.Value is DBNull)
            {
                return;
            }

            int code = Convert.ToInt32(cell.Value.ToString());

            string secCd = code.ToString("0000000000");
            if (!string.IsNullOrEmpty(secCd))
            {
                ArrayList pmData = new ArrayList();
                pmData = (ArrayList)_inputData[secCd];
                pmData.Sort();
                for (int j = 0; j < pmData.Count; j++)
                {
                    DataRow dataRowPm = dataTablePm.NewRow();
                    dataRowPm[COLUMN_PM_NO] = "";
                    dataRowPm[COLUMN_PM_SECCD] = pmData[j].ToString();
                    dataRowPm[COLUMN_PM_SECNM] = GetSectionName(secCd[j].ToString().Trim());
                    dataTablePm.Rows.Add(dataRowPm);

                }
            }
        }

        /// <summary>
        /// Button_Click �C�x���g(����{�^��)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ����{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Button_Click �C�x���g(�ۑ��{�^��)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �ۑ��{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            if (_inputData.Contains(""))
            {
                _inputData.Remove("");
            }
            keyData = new ArrayList(_inputData.Keys);
            valueData = new ArrayList(_inputData.Values);
            this._sectionCdInputConstructionAcs.InputSecCdCSV = this.keyData;
            this._sectionCdInputConstructionAcs.InputSecCdPM = this.valueData;
            this._sectionCdInputConstructionAcs.Serialize();

            this.Close();
        }

        /// <summary>
        /// ClickCellButton �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Z���{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void Second_Grid_ClickCellButton(object sender, CellEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;
            int status;
            switch (e.Cell.Column.Key)
            {
                // ���_�K�C�h�{�^��
                case COLUMN_PM_SECGUIDE:                    
                    {
                        SecInfoSet secInfoSet;
                        status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                        if (status == 0)
                        {
                            // ���_�R�[�h
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_PM_SECCD].Value = secInfoSet.SectionCode.Trim();
                            // ���_��
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_PM_SECNM].Value = GetSectionName(secInfoSet.SectionCode.Trim());

                            if (e.Cell.Row.Index == uGrid.Rows.Count - 1)
                            {
                                // �ŏI�s�������ꍇ�A�s��ǉ�
                                CreateNewRow(ref uGrid);
                            }

                            // �t�H�[�J�X�ݒ�
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_PM_SECCD].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
            }
        }

        // --------DEL 20090819 ���仁@�t�H�[�J�X�ړ��̏C��------>>>>>>>>>
        ///// <summary>
        ///// AfterExitEditMode �C�x���g
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�n���h��</param>
        ///// <remarks>
        ///// <br>Note       : �ҏW���[�h���I���������ɔ������܂��B</br>
        ///// <br>Programmer : ����</br>
        ///// <br>Date	   : 2009.05.10</br>
        ///// </remarks>
        //private void Second_Grid_AfterExitEditMode(object sender, EventArgs e)
        //{
        //    UltraGrid uGrid = (UltraGrid)sender;
        //    int rowNm = Second_Grid.ActiveCell.Row.Index;
        //    if (uGrid.ActiveCell == null)
        //    {
        //        return;
        //    }
        //    //switch (uGrid.ActiveCell.Column.Key)
        //    //{
        //    //    case COLUMN_PM_SECCD:
        //    //        {
        //    //            // �[���l��
        //    //            uGrid.ActiveCell.Value = this.uiSetControl1.GetZeroPaddedText(uGrid.ActiveCell.Column.Key, uGrid.ActiveCell.Value.ToString());

        //    //            // ���_�R�[�h�擾
        //    //            string sectionCode = CellTextToString(uGrid.ActiveCell.Text);
            
        //    //            if (sectionCode == "")
        //    //            {
        //    //                // �s�N���A
        //    //                ClearRow(rowNm);
        //    //                if (rowNm != uGrid.Rows.Count - 1)
        //    //                {
        //    //                    this.dataTablePm.AcceptChanges();
        //    //                    this.dataTablePm.Rows[rowNm].Delete();
                                
        //    //                    this.Second_Grid.Rows[rowNm].Cells[1].Activate();
        //    //                }
        //    //            }
        //    //            else
        //    //            {
        //    //                bool bStatus = CheckSectionCode(sectionCode);
        //    //                if (!bStatus)
        //    //                {
        //    //                    // �s�N���A
        //    //                    ClearRow(Second_Grid.ActiveCell.Row.Index);
        //    //                    return;
        //    //                }

        //    //                // ���_���擾
        //    //                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_PM_SECNM].Value = GetSectionName(sectionCode);

        //    //                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_PM_SECCD].Value = sectionCode;

        //    //                if (uGrid.ActiveCell.Row.Index == uGrid.Rows.Count - 1)
        //    //                {
        //    //                    // �ŏI�s�������ꍇ�A�s�ǉ�
        //    //                    CreateNewRow(ref uGrid);
        //    //                }
        //    //                this.Second_Grid.Rows[rowNm].Cells[1].Activate();
                            
        //    //            }

        //    //            break;
        //    //        }
        //    //}

        //    ArrayList nowPmData = new ArrayList();
        //    for (int i = 0; i < uGrid.Rows.Count; i++)
        //    {
        //        // ��ʂ�PM�f�[�^���擾
        //        if (!string.IsNullOrEmpty(uGrid.Rows[i].Cells[COLUMN_PM_SECCD].Text.ToString()))
        //        {
        //            nowPmData.Add(uGrid.Rows[i].Cells[COLUMN_PM_SECCD].Text);
        //        }
        //    }
        //    if (!string.IsNullOrEmpty(firstGridActiveStr))
        //    {
        //        //�@���f�[�^���폜����
        //        if (_inputData.Contains(firstGridActiveStr))
        //        {
        //            _inputData.Remove(firstGridActiveStr);
        //        }
        //        //�@���̃f�[�^���Z�[�t
        //        if (nowPmData.Count > 0)
        //        {
        //            _inputData.Add(firstGridActiveStr, nowPmData);
        //        }
        //    }
        //}
        // --------DEL 20090819 ���仁@�t�H�[�J�X�ړ��̏C��------<<<<<<<<<<

        /// <summary>
        /// �s�N���A����
        /// </summary>
        /// <param name="rowIndex">�s�C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �Ώۍs�̃f�[�^���N���A���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private void ClearRow(int rowIndex)
        {
            this.Second_Grid.Rows[rowIndex].Cells[COLUMN_PM_SECCD].Value = "";
            this.Second_Grid.Rows[rowIndex].Cells[COLUMN_PM_SECNM].Value = "";
        }

        /// <summary>
        /// �ϊ�����(object��string)
        /// </summary>
        /// <param name="targetValue">�ϊ��Ώ�object</param>
        /// <returns>������</returns>
        /// <remarks>
        /// <br>Note       : object�^��string�ɕϊ����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private string StrObjectToString(object targetValue)
        {
            if ((targetValue == DBNull.Value) || (targetValue == null) || ((string)targetValue == ""))
            {
                return "";
            }

            return (string)targetValue;
        }

        /// <summary>
        /// �ϊ�����(string��string)
        /// </summary>
        /// <param name="cellText">�ϊ��Ώ�</param>
        /// <returns>������</returns>
        /// <remarks>
        /// <br>Note       : �ϊ����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private string CellTextToString(string cellText)
        {
            if ((cellText == null) || (cellText.Trim() == ""))
            {
                return "";
            }

            return cellText.Trim().PadLeft(2, '0');
        }

        /// <summary>
        /// ���_�R�[�h�`�F�b�N����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���_�R�[�h���}�X�^�ɑ��݂��邩�`�F�b�N���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private bool CheckSectionCode(string sectionCode)
        {
            string errMsg = "";

            try
            {
                if (this._secInfoSetDic.ContainsKey(sectionCode.Trim()) == false)
                {
                    errMsg = "���_���ݒ�}�X�^�ɓo�^����Ă��܂���B";
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   -1,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// ���b�Z�[�W�{�b�N�X�\������
        /// </summary>
        /// <param name="errLevel">�G���[���x��</param>
        /// <param name="message">�\�����郁�b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X�l</param>
        /// <param name="msgButton">�\������{�^��</param>
        /// <param name="defaultButton">�����\���{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W�{�b�N�X��\�����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // �e�E�B���h�E�t�H�[��
                                         errLevel,                          // �G���[���x��
                                         ASSEMBLY_ID,                       // �A�Z���u��ID
                                         message,                           // �\�����郁�b�Z�[�W
                                         status,                            // �X�e�[�^�X�l
                                         msgButton,                         // �\������{�^��
                                         defaultButton);                    // �����\���{�^��
            return dialogResult;
        }

        /// <summary>
        /// AfterEnterEditMode �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �ҏW���[�h���J�n�������ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void First_Grid_AfterEnterEditMode(object sender, EventArgs e)
        {
            if (this.First_Grid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.First_Grid.ActiveCell;
            int rowIndex = cell.Row.Index;

            // ��l�𔻒f����
            if (!string.IsNullOrEmpty(cell.Value.ToString()))
            {
                int code = Convert.ToInt32(cell.Value.ToString());

                string secCd = code.ToString("0000000000");

                firstGridActiveStr = code.ToString("0000000000");
                //�@PM�f�[�^��\������
                if (!string.IsNullOrEmpty(secCd))
                {
                    ArrayList pmData = new ArrayList();
                    pmData = (ArrayList)_inputData[secCd];
                    
                    dataTablePm.Clear();
                    if (pmData != null && pmData.Count > 0)
                    {
                        pmData.Sort();
                        for (int j = 0; j < pmData.Count; j++)
                        {
                            DataRow dataRowPm = dataTablePm.NewRow();
                            dataRowPm[COLUMN_PM_NO] = "";
                            dataRowPm[COLUMN_PM_SECCD] = pmData[j].ToString();
                            dataRowPm[COLUMN_PM_SECNM] = GetSectionName(pmData[j].ToString().Trim());
                            dataTablePm.Rows.Add(dataRowPm);
                        }
                    }

                    DataRow dataRowPmbk = dataTablePm.NewRow();
                    dataRowPmbk[COLUMN_PM_NO] = "";
                    dataRowPmbk[COLUMN_PM_SECCD] = "";
                    dataRowPmbk[COLUMN_PM_SECNM] = "";
                    dataTablePm.Rows.Add(dataRowPmbk);

                    this.First_Grid.DataSource = dataTableCsv;
                    this.Second_Grid.DataSource = dataTablePm;
                }
                else
                {
                    //�@�s��ǉ�
                    dataTablePm.Clear();
                    DataRow dataRowPmbk = dataTablePm.NewRow();
                    dataRowPmbk[COLUMN_PM_NO] = "";
                    dataRowPmbk[COLUMN_PM_SECCD] = "";
                    dataRowPmbk[COLUMN_PM_SECNM] = "";
                    dataTablePm.Rows.Add(dataRowPmbk);
                }
            }
            else
            {
                firstGridActiveStr = string.Empty;
                //�@�s��ǉ�
                dataTablePm.Clear();
                DataRow dataRowPmbk = dataTablePm.NewRow();
                dataRowPmbk[COLUMN_PM_NO] = "";
                dataRowPmbk[COLUMN_PM_SECCD] = "";
                dataRowPmbk[COLUMN_PM_SECNM] = "";
                dataTablePm.Rows.Add(dataRowPmbk);
            }
        }

        /// <summary>
        /// BeforeCellActivate �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �X�V���J�n�������ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void First_Grid_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            // IME���Ђ炪�ȃ��[�h�ɂ���
            this.First_Grid.ImeMode = System.Windows.Forms.ImeMode.Close;

            UltraGrid uGrid = (UltraGrid)sender;
            int rowNo = uGrid.ActiveRow.Index;
            beforeChangeStr = uGrid.ActiveRow.Cells[COLUMN_CSV_SECCD].Text;
        }

        /// <summary>
        /// SetFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �t�H�J�X���w�肵�����ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void timer_SetFocus_Tick(object sender, EventArgs e)
        {
            if (dataTableCsv.Rows.Count != 0)
            {
                this.First_Grid.Focus();
                this.First_Grid.Rows[0].Cells[1].Activate();
                this.First_Grid.PerformAction(UltraGridAction.EnterEditMode);
            }

            this.timer_SetFocus.Enabled = false;
        }

        /// <summary>
        /// KeyDown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�A�N�e�B�u���ɃL�[�������ꂽ�^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            int rowIndex;
            int columnIndex;

            if (uGrid.ActiveCell == null)
            {
                if (uGrid.ActiveRow == null)
                {
                    return;
                }
                else
                {
                    rowIndex = uGrid.ActiveRow.Index;
                    columnIndex = 1;
                }
            }
            else
            {
                rowIndex = uGrid.ActiveCell.Row.Index;
                columnIndex = uGrid.ActiveCell.Column.Index;
            }

            switch (e.KeyCode)
            {
                case Keys.Space:
                    {
                        e.Handled = true;
                        if (uGrid == Second_Grid)
                        {
                            if (columnIndex == 3)
                            {
                                Second_Grid_ClickCellButton(this.Second_Grid, new CellEventArgs(uGrid.ActiveCell));
                            }
                        }
                        break;
                    }
                case Keys.Up:
                    {
                        e.Handled = true;

                        // �ҏW���[�h�I��
                        uGrid.PerformAction(UltraGridAction.ExitEditMode);

                        if (rowIndex != 0)
                        {
                            uGrid.Rows[rowIndex - 1].Cells[columnIndex].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        e.Handled = true;

                        // �ҏW���[�h�I��
                        uGrid.PerformAction(UltraGridAction.ExitEditMode);

                        if (rowIndex != uGrid.Rows.Count - 1)
                        {
                            uGrid.Rows[rowIndex + 1].Cells[columnIndex].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        if (uGrid == Second_Grid)
                        {
                            e.Handled = true;

                            // �ҏW���[�h�I��
                            uGrid.PerformAction(UltraGridAction.ExitEditMode);
                            int colNo = (columnIndex + 2) % 4;
                            if (columnIndex == 1)
                            {
                                this.First_Grid.Rows[firstGridActiveRow].Cells[1].Activate();
                                this.First_Grid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                uGrid.Rows[rowIndex].Cells[(columnIndex + 2) % 4].Activate();
                                if (colNo == 1)
                                {
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            
                        }
                        
                        break;
                    }
                case Keys.Right:
                    {
                        if (uGrid == Second_Grid)
                        {
                            e.Handled = true;

                            // �ҏW���[�h�I��
                            uGrid.PerformAction(UltraGridAction.ExitEditMode);
                            int colNo = (columnIndex + 2) % 4;
                            uGrid.Rows[rowIndex].Cells[(columnIndex + 2) % 4].Activate();
                            if (colNo == 1)
                            {
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        break;
                    }

            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �ҏW���[�h���I���������ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void First_Grid_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.First_Grid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.First_Grid.ActiveCell;
            int rowIndex = cell.Row.Index;
            firstGridActiveRow = rowIndex;
            string data = cell.Value.ToString();

            bool hasAdd = false;
            // �����d���拒�_���݂̏ꍇ�A�G���[���o���B
            if (!string.IsNullOrEmpty(cell.Value.ToString()))
            {
                int code = Convert.ToInt32(cell.Value.ToString());

                firstGridActiveStr = code.ToString("0000000000");
                for (int i = 0; i < this.First_Grid.Rows.Count; i++)
                {
                    string secStr = this.First_Grid.Rows[i].Cells[COLUMN_CSV_SECCD].Text.ToString();
                    if (firstGridActiveStr.Equals(secStr) && rowIndex != i && firstGridActiveStr != string.Empty)
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "�w�肳�ꂽ�d���拒�_�͑��݂��܂����B",
                                       -1,
                                       MessageBoxButtons.OK,
                                       MessageBoxDefaultButton.Button1);
                        // �s�N���A
                        this.First_Grid.Rows[rowIndex].Cells[COLUMN_CSV_SECCD].Value = "";
                        data = null;
                        hasAdd = true;
                        break;

                    }

                }

                if ((rowIndex == this.First_Grid.Rows.Count - 1) && !hasAdd)
                {
                    // �ŏI�s�������ꍇ�A�s��ǉ�
                    CreateNewRow(ref this.First_Grid);
                }
            }
            else
            {
                firstGridActiveStr = string.Empty;
            }
            // DeleteKEY�ōs���A���̃f�[�^���폜
            if (_inputData.Contains(beforeChangeStr) && !beforeChangeStr.Equals(firstGridActiveStr))
            {
                _inputData.Remove(beforeChangeStr);
            }
            // DeleteKEY�ōs���A�s���폜
            if (rowIndex != this.First_Grid.Rows.Count - 1 && string.IsNullOrEmpty(data))
            {
                DataRow row = this.dataTableCsv.Rows[rowIndex];
                this.dataTableCsv.Rows.Remove(row);
                //�@���s�̃f�[�^��\������
                this.First_Grid.Rows[rowIndex].Cells[1].Activate();
                this.First_Grid.Rows[rowIndex].Cells[1].Selected = true;
                if (!string.IsNullOrEmpty(this.First_Grid.ActiveCell.Value.ToString()))
                {
                    int nowCd = Convert.ToInt32(this.First_Grid.ActiveCell.Value.ToString());
                    //�@PM�f�[�^��ݒ肷��
                    string secCd = nowCd.ToString("0000000000");
                    if (!string.IsNullOrEmpty(secCd))
                    {
                        ArrayList pmData = new ArrayList();
                        dataTablePm.Clear();
                        pmData = (ArrayList)_inputData[secCd];
                        if (pmData != null && pmData.Count > 0)
                        {
                            for (int j = 0; j < pmData.Count; j++)
                            {
                                DataRow dataRowPm = dataTablePm.NewRow();
                                dataRowPm[COLUMN_PM_NO] = "";
                                dataRowPm[COLUMN_PM_SECCD] = pmData[j].ToString();
                                dataRowPm[COLUMN_PM_SECNM] = GetSectionName(pmData[j].ToString().Trim());
                                dataTablePm.Rows.Add(dataRowPm);

                            }
                        }

                        //�@�s��ǉ�
                        DataRow dataRowPmbk = dataTablePm.NewRow();
                        dataRowPmbk[COLUMN_PM_NO] = "";
                        dataRowPmbk[COLUMN_PM_SECCD] = "";
                        dataRowPmbk[COLUMN_PM_SECNM] = "";
                        dataTablePm.Rows.Add(dataRowPmbk);
                    }
                }
                else
                {
                    dataTablePm.Clear();
                    //�@�s��ǉ�
                    DataRow dataRowPmbk = dataTablePm.NewRow();
                    dataRowPmbk[COLUMN_PM_NO] = "";
                    dataRowPmbk[COLUMN_PM_SECCD] = "";
                    dataRowPmbk[COLUMN_PM_SECNM] = "";
                    dataTablePm.Rows.Add(dataRowPmbk);

                }
            }
            //�@�t�H�[�}�b�g�ݒ�
            else
            {
                if (cell.Column.Key == COLUMN_CSV_SECCD)
                {
                    if (!(cell.Value is DBNull))
                    {
                        if (!string.IsNullOrEmpty(cell.Value.ToString()))
                        {
                            int value = Convert.ToInt32(cell.Value.ToString());
                            cell.Value = value.ToString("0000000000");
                        }
                    }
                }
            }

            // ADD 20090807 ���仁@
            // �J�[�\����PM���_�̖��̂ֈړ��������ɓ��͉\��ԁi�Z�����I�����W�F�j�ƂȂ�悤�ɏC�� 
            this.Second_Grid.Rows[0].Cells[1].Activate();
            this.Second_Grid.PerformAction(UltraGridAction.EnterEditMode);
        }

        /// <summary>
        /// KeyPress �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �L�[�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void First_Grid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.First_Grid.ActiveCell == null) return;

            //this.First_Grid.Rows[rowIndex].Cells[1].Activate();
            this.First_Grid.PerformAction(UltraGridAction.EnterEditMode);

            UltraGrid uGrid = (UltraGrid)sender;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = (UltraGridCell)uGrid.ActiveCell;

            if (cell.Column.Key == COLUMN_CSV_SECCD)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(10, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// ���l���̓`�F�b�N����
        /// </summary>
        /// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
        /// <param name="priod">�����_�ȉ�����</param>
        /// <param name="prevVal">���݂̕�����</param>
        /// <param name="key">���͂��ꂽ�L�[�l</param>
        /// <param name="selstart">�J�[�\���ʒu</param>
        /// <param name="sellength">�I�𕶎���</param>
        /// <param name="minusFlg">�}�C�i�X���͉H</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }
            // ���l�ȊO�́A�m�f
            if (!Char.IsDigit(key))
            {
                // �����_�܂��́A�}�C�i�X�ȊO
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string _strResult = string.Empty;
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // �}�C�i�X�̃`�F�b�N
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // �����_�̃`�F�b�N
            if (key == '.')
            {
                if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // �����`�F�b�N�I
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // �����_�ȉ��̃`�F�b�N
            if (priod > 0)
            {
                // �����_�̈ʒu����
                int _pointPos = _strResult.IndexOf('.');

                // �������ɓ��͉\�Ȍ���������I
                //int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
                int _Rketa = this.diverge<int>(_strResult[0] == '-', keta - priod, keta - priod - 1);
                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (_strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    // �������̌������v�Z
                    int _priketa = _strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// ��r�֐�
        /// </summary>
        /// <typeparam name="T">�^�w��</typeparam>
        /// <param name="condition">����</param>
        /// <param name="valueOnTrue">True�̎��̒l</param>
        /// <param name="valueOnFalse">False�̎��̒l</param>
        /// <returns>�����ɂ��I�����ꂽ�l</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        public T diverge<T>(bool condition, T valueOnTrue, T valueOnFalse)
        {
            if (condition)
            {
                return valueOnTrue;
            }
            else
            {
                return valueOnFalse;
            }
        }

        /// <summary>
        /// BeforeCellActivate �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �ҏW���[�h���J�n�������ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void Second_Grid_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            // IME���Ђ炪�ȃ��[�h�ɂ���
            this.First_Grid.ImeMode = System.Windows.Forms.ImeMode.Close;
        }

        /// <summary>
        /// KeyPress �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �L�[�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void Second_Grid_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (this.Second_Grid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.Second_Grid.ActiveCell;

            if (cell.Column.Key == COLUMN_PM_SECCD)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// BeforeEnterEditMode �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �ҏW���[�h���J�n�������ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void First_Grid_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            if (this.First_Grid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.First_Grid.ActiveCell;
            int rowIndex = cell.Row.Index;

            // ActiveCell���J�n���Ԃ̏ꍇ
            if (cell.Column.Key == COLUMN_CSV_SECCD)
            {
                if (!(cell.Value is DBNull) && !string.IsNullOrEmpty(cell.Value.ToString()))
                {
                    int value = Convert.ToInt32(cell.Value.ToString());
                    cell.Value = value.ToString();
                }
            }
        }

        // --------ADD 20090819 ���仁@�t�H�[�J�X�ړ��̏C��------>>>>>>>>>
        /// <summary>
        /// ChangeFocus �C�x���g(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �e�R���g���[������t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            if (e.PrevCtrl == this.Second_Grid)
            {
                if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                {
                    if (this.Second_Grid.ActiveCell == null)
                    {
                        this.Second_Grid.PerformAction(UltraGridAction.NextCell);
                        this.Second_Grid.PerformAction(UltraGridAction.EnterEditMode);
                        e.NextCtrl = null;
                        return;
                    }

                    int activeRowIndex = this.Second_Grid.ActiveCell.Row.Index;
                    int activeColumnIndex = this.Second_Grid.ActiveCell.Column.Index;
                    // ���_�R�[�h�擾
                    string sectionCd = CellTextToString(this.Second_Grid.ActiveCell.Text);
                    if (string.Empty.Equals(sectionCd))
                    {
                        // �s�N���A
                        ClearRow(activeRowIndex);
                        if (activeRowIndex != this.Second_Grid.Rows.Count - 1)
                        {
                            this.dataTablePm.AcceptChanges();
                            this.dataTablePm.Rows[activeRowIndex].Delete();
                        }
                        this.Second_Grid.Rows[activeRowIndex].Cells[activeColumnIndex].Activate();
                        this.Second_Grid.PerformAction(UltraGridAction.EnterEditMode);
                        e.NextCtrl = null;
                        ArrayList nowPmData = new ArrayList();
                for (int i = 0; i < this.Second_Grid.Rows.Count; i++)
                {
                    // ��ʂ�PM�f�[�^���擾
                    if (!string.IsNullOrEmpty(this.Second_Grid.Rows[i].Cells[COLUMN_PM_SECCD].Text.ToString()))
                    {
                        nowPmData.Add(this.Second_Grid.Rows[i].Cells[COLUMN_PM_SECCD].Text);
                    }
                }
                if (!string.IsNullOrEmpty(firstGridActiveStr))
                {
                    //�@���f�[�^���폜����
                    if (_inputData.Contains(firstGridActiveStr))
                    {
                        _inputData.Remove(firstGridActiveStr);
                    }
                    //�@���̃f�[�^���Z�[�t
                    if (nowPmData.Count > 0)
                    {
                        _inputData.Add(firstGridActiveStr, nowPmData);
                    }
                }
                        return;
                    }
                    
                    bool Scdstatus = CheckSectionCode(sectionCd);
                    if (!Scdstatus)
                    {
                        // �s�N���A
                        ClearRow(activeRowIndex);
                        this.Second_Grid.Rows[activeRowIndex].Cells[activeColumnIndex].Activate();
                        this.Second_Grid.PerformAction(UltraGridAction.EnterEditMode);
                        e.NextCtrl = null;
                        ArrayList nowPmData = new ArrayList();
                        for (int i = 0; i < this.Second_Grid.Rows.Count; i++)
                        {
                            // ��ʂ�PM�f�[�^���擾
                            if (!string.IsNullOrEmpty(this.Second_Grid.Rows[i].Cells[COLUMN_PM_SECCD].Text.ToString()))
                            {
                                nowPmData.Add(this.Second_Grid.Rows[i].Cells[COLUMN_PM_SECCD].Text);
                            }
                        }
                        if (!string.IsNullOrEmpty(firstGridActiveStr))
                        {
                            //�@���f�[�^���폜����
                            if (_inputData.Contains(firstGridActiveStr))
                            {
                                _inputData.Remove(firstGridActiveStr);
                            }
                            //�@���̃f�[�^���Z�[�t
                            if (nowPmData.Count > 0)
                            {
                                _inputData.Add(firstGridActiveStr, nowPmData);
                            }
                        }
                        return;
                    }
                    else
                    {
                        if (activeRowIndex != this.Second_Grid.Rows.Count - 1)
                        {
                            this.Second_Grid.Rows[activeRowIndex + 1].Cells[activeColumnIndex].Activate();
                            this.Second_Grid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        else
                        {
                            // ���_���擾
                            this.Second_Grid.Rows[activeRowIndex].Cells[COLUMN_PM_SECNM].Value = GetSectionName(sectionCd);
                            this.Second_Grid.Rows[activeRowIndex].Cells[COLUMN_PM_SECCD].Value = sectionCd;
                            // �ŏI�s�������ꍇ�A�s�ǉ�
                            CreateNewRow(ref this.Second_Grid);    

                            this.Second_Grid.Rows[activeRowIndex + 1].Cells[activeColumnIndex].Activate();
                            this.Second_Grid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        e.NextCtrl = null;

                        ArrayList nowPmData = new ArrayList();
                        for (int i = 0; i < this.Second_Grid.Rows.Count; i++)
                        {
                            // ��ʂ�PM�f�[�^���擾
                            if (!string.IsNullOrEmpty(this.Second_Grid.Rows[i].Cells[COLUMN_PM_SECCD].Text.ToString()))
                            {
                                nowPmData.Add(this.Second_Grid.Rows[i].Cells[COLUMN_PM_SECCD].Text);
                            }
                        }
                        if (!string.IsNullOrEmpty(firstGridActiveStr))
                        {
                            //�@���f�[�^���폜����
                            if (_inputData.Contains(firstGridActiveStr))
                            {
                                _inputData.Remove(firstGridActiveStr);
                            }
                            //�@���̃f�[�^���Z�[�t
                            if (nowPmData.Count > 0)
                            {
                                _inputData.Add(firstGridActiveStr, nowPmData);
                            }
                        }
                        return;
                    }
                }
            }
        }
        // --------ADD 20090819 ���仁@�t�H�[�J�X�ړ��̏C��------<<<<<<<<<<
    }
}