using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;

using Broadleaf.Library.Windows.Forms;  // 2010/03/31 Add

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �C���|�[�g�Ώېݒ�UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �C���|�[�g�Ώۂ̐ݒ���s���N���X�ł��B</br>
    /// <br>Programer  : 30517 �Ė� �x��</br>
    /// <br>Date       : 2010/03/31</br>
    /// </remarks>
    public partial class PMKHN08500UC : Form
    {
        public PMKHN08500UC(string fileName, string xmlName)
        {
            InitializeComponent();

            this.BackColor = Color.FromArgb(222, 239, 255);
            FileName_tEdit.Text = fileName;
            _xmlFileName = Path.GetFileNameWithoutExtension(xmlName);
        }

        private const string COLUMN_FILENM = "FileNm";
        private const string COLUMN_ITEMID = "ItemId";
        private const string COLUMN_ITEMNAME = "ItemName";
        private const string COLUMN_UPDATECD = "UpdateCd";
        private string _xmlFileName = string.Empty;
        private List<SetUpControlInfo> _setUpControlInfoList = new List<SetUpControlInfo>();

        private void PMKHN08500UC_Load(object sender, EventArgs e)
        {
            CreateGrid();
            SetGridLayout();
            if (LoadToFiles(_xmlFileName, out _setUpControlInfoList) != 0)
            {
                _setUpControlInfoList = getSetUpControlInfoList(_xmlFileName);
            }
            CreateNewRow(ref this.uGrid_Details, _setUpControlInfoList);

            this.uGrid_Details.Rows[0].Cells[3].Activate();
        }

        /// <summary>
        /// �O���b�h���쐬���܂��B
        /// </summary>
        private void CreateGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(COLUMN_FILENM, typeof(string));
            dt.Columns.Add(COLUMN_ITEMID, typeof(int));
            dt.Columns.Add(COLUMN_ITEMNAME, typeof(string));
            dt.Columns.Add(COLUMN_UPDATECD, typeof(string));
            this.uGrid_Details.DataSource = dt;
            this.uGrid_Details.DisplayLayout.ColScrollRegions.Clear();
        }

        /// <summary>
        /// SetUpControlInfoList�̓��e��Grid�ɒǉ����܂��B
        /// </summary>
        /// <param name="uGrid">�ǉ��Ώۂ�Grid</param>
        /// <param name="setUpControlInfoList">SetUpControlInfoList</param>
        private void CreateNewRow(ref UltraGrid uGrid,List<SetUpControlInfo> setUpControlInfoList)
        {
            foreach (SetUpControlInfo setUpControlInfo in setUpControlInfoList)
            {
                uGrid.DisplayLayout.Bands[0].AddNew();

                uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_ITEMID].Value = setUpControlInfo.ItemId;
                uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_ITEMNAME].Value = setUpControlInfo.ItemName;
                uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_FILENM].Value = setUpControlInfo.FileName;
                uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_UPDATECD].Value = setUpControlInfo.UpdateDiv;
            }
        }

        /// <summary>
        /// �O���b�h�̃��C�A�E�g��ݒ肵�܂��B
        /// </summary>
        private void SetGridLayout()
        {
            ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

            // ���͕s��
            columns[COLUMN_FILENM].CellActivation = Activation.NoEdit;
            columns[COLUMN_ITEMID].CellActivation = Activation.NoEdit;
            columns[COLUMN_ITEMNAME].CellActivation = Activation.NoEdit;

            // �L���v�V����
            columns[COLUMN_FILENM].Header.Caption = "�t�@�C������";
            columns[COLUMN_ITEMID].Header.Caption = "���ڂh�c";
            columns[COLUMN_ITEMNAME].Header.Caption = "���ږ���";
            columns[COLUMN_UPDATECD].Header.Caption = "�X�V�敪";

            // ��
            columns[COLUMN_FILENM].Width = 174;
            columns[COLUMN_ITEMID].Width = 50;
            columns[COLUMN_ITEMNAME].Width = 160;
            columns[COLUMN_UPDATECD].Width = 92;

            // ��\��
            columns[COLUMN_ITEMID].Hidden = true;

            // �e�L�X�g�ʒu
            for (int i = 0; i < columns.Count; i++)
            {
                columns[i].CellAppearance.TextVAlign = VAlign.Middle;
            }

            // �R���{�{�b�N�X�ݒ�
            ValueList valueList = new ValueList();
            valueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);
            valueList.ValueListItems.Clear();
            valueList.ValueListItems.Add(0, "����");
            valueList.ValueListItems.Add(1, "���Ȃ�");
            columns[COLUMN_UPDATECD].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            columns[COLUMN_UPDATECD].ValueList = valueList.Clone();
        }

        /// <summary>
        /// SetUpControlInfoList�̏����l��ݒ肵�܂��B
        /// </summary>
        /// <param name="xmlName">DLL��</param>
        /// <returns>SetUpControlInfoList</returns>
        private List<SetUpControlInfo> getSetUpControlInfoList(string xmlName)
        {
            List<SetUpControlInfo> list = new List<SetUpControlInfo>();
            switch (xmlName)
            {
                case "PMKHN07630U":
                    list = GetSetUpControlinfoList07630();
                    break;
            }
            return list;
        }

        /// <summary>
        /// ���i�}�X�^�C���|�[�g����SetUpControlInfoList�����l���Z�b�g���܂��B
        /// </summary>
        /// <returns>SetUpControlInfoList</returns>
        private List<SetUpControlInfo> GetSetUpControlinfoList07630()
        {
            List<SetUpControlInfo> list = new List<SetUpControlInfo>();
            SetUpControlInfo addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 3;
            addList.ItemName = "�i��";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 4;
            addList.ItemName = "�i����";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 5;
            addList.ItemName = "�i�`�m�R�[�h";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 6;
            addList.ItemName = "�a�k�R�[�h";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 7;
            addList.ItemName = "���i�敪";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 8;
            addList.ItemName = "�w��";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 9;
            addList.ItemName = "���D�敪";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 10;
            addList.ItemName = "�ېŋ敪";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 11;
            addList.ItemName = "���i���l�P";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 12;
            addList.ItemName = "���i���l�Q";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 13;
            addList.ItemName = "�K�i�E���L����";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 15;
            addList.ItemName = "���i�P";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 16;
            addList.ItemName = "�I�[�v�����i�敪�P";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 17;
            addList.ItemName = "�d�����P";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 18;
            addList.ItemName = "���P���P";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 20;
            addList.ItemName = "���i�Q";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 21;
            addList.ItemName = "�I�[�v�����i�敪�Q";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 22;
            addList.ItemName = "�d�����Q";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 23;
            addList.ItemName = "���P���Q";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 25;
            addList.ItemName = "���i�R";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 26;
            addList.ItemName = "�I�[�v�����i�敪�R";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 27;
            addList.ItemName = "�d�����R";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 28;
            addList.ItemName = "���P���R";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 30;
            addList.ItemName = "���i�S";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 31;
            addList.ItemName = "�I�[�v�����i�敪�S";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 32;
            addList.ItemName = "�d�����S";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 33;
            addList.ItemName = "���P���S";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 35;
            addList.ItemName = "���i�T";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 36;
            addList.ItemName = "�I�[�v�����i�敪�T";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 37;
            addList.ItemName = "�d�����T";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "���i�}�X�^";
            addList.ItemId = 38;
            addList.ItemName = "���P���T";
            list.Add(addList);

            return list;
        }

        /// <summary>
        /// �C���|�[�g�Ώېݒ��ǂݍ��݂܂��B
        /// </summary>
        /// <param name="fileName">�C���|�[�gDLL��</param>
        /// <param name="list">SetUpControlInfoList</param>
        /// <returns>status</returns>
        public int LoadToFiles(string fileName, out List<SetUpControlInfo> list)
        {
            // �Ǎ�����
            int status = 0;
            list = new List<SetUpControlInfo>();
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName + "_Construction.XML")))
            {
                list = UserSettingController.DeserializeUserSetting<List<SetUpControlInfo>>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName + "_Construction.XML"));
            }
            else
            {
                status = 1;
            }
            return status;
        }

        /// <summary>
        /// �C���|�[�g�Ώېݒ��ۑ����܂��B
        /// </summary>
        /// <param name="fileName">�ۑ����XML�t�@�C����</param>
        /// <param name="list">SetUpControlInfoList</param>
        /// <returns>status</returns>
        private int SaveToFiles(string fileName, List<SetUpControlInfo> list)
        {
            int status = 0;
            UserSettingController.SerializeUserSetting(list, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName + "_Construction.XML"));
            return status;
        }

        /// <summary>
        /// �ۑ��{�^�����ݒ���e�̕ۑ����s���܂��B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            int updCnt = 0;
            this.Ok_Button.Focus();
            for (int index = 0; index < uGrid_Details.Rows.Count; index++)
            {
                object updateDiv = uGrid_Details.Rows[index].Cells[COLUMN_UPDATECD].Value;
                _setUpControlInfoList[index].UpdateDiv = Convert.ToInt32(updateDiv);
                if (Convert.ToInt32(updateDiv) == 0)
                    updCnt++;
            }
            if (updCnt == 0)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKHN08500U",
                    "�X�V�Ώۂ�ݒ肵�Ă��������B", 0, MessageBoxButtons.OK);
                return;
            }
            SaveToFiles(_xmlFileName, _setUpControlInfoList);
            this.Close();
        }

        /// <summary>
        /// ����{�^�����A��ʂ���܂��B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // �O���b�h
                case "uGrid_Details":
                    {
                        #region �O���b�h

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                int rowIndex;
                                int colIndex;

                                if (this.uGrid_Details.ActiveCell != null)
                                {
                                    rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
                                    colIndex = this.uGrid_Details.ActiveCell.Column.Index;
                                }
                                else if (this.uGrid_Details.ActiveRow != null)
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[3].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                                else
                                {
                                    if (this.uGrid_Details.Rows.Count == 0)
                                    {
                                        e.NextCtrl = this.Ok_Button;
                                        return;
                                    }
                                    else
                                    {
                                        e.NextCtrl = null;
                                        this.uGrid_Details.Rows[0].Cells[3].Activate();
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        return;
                                    }
                                }

                                e.NextCtrl = null;

                                if (colIndex < 3)
                                {
                                    // �Ƀt�H�[�J�X
                                    this.uGrid_Details.Rows[rowIndex].Cells[3].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                                else if (colIndex == 3)
                                {
                                    if (rowIndex == this.uGrid_Details.Rows.VisibleRowCount - 1)
                                    {
                                        // �t�H�[�J�X�ړ��Ȃ�
                                        //this.uGrid_Details.Rows[rowIndex].Cells[colIndex].Activate();
                                        e.NextCtrl = this.Ok_Button;
                                        this.uGrid_Details.ActiveCell = null;
                                        return;
                                    }
                                    else if (rowIndex >= this.uGrid_Details.Rows.VisibleRowCount - 1)
                                    {
                                        e.NextCtrl = null;
                                        this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        return;
                                    }
                                    else
                                    {
                                        this.uGrid_Details.Rows[rowIndex + 1].Cells[3].Activate();
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        return;
                                    }
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                int rowIndex;
                                int colIndex;

                                if (this.uGrid_Details.ActiveCell != null)
                                {
                                    rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
                                    colIndex = this.uGrid_Details.ActiveCell.Column.Index;
                                }
                                else if (this.uGrid_Details.ActiveRow != null)
                                {
                                    rowIndex = this.uGrid_Details.ActiveRow.Index;
                                    colIndex = 5;
                                }
                                else
                                {
                                    if (this.uGrid_Details.Rows.Count == 0)
                                    {
                                        e.NextCtrl = this.Ok_Button;
                                        return;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.Ok_Button;
                                        return;
                                    }
                                }

                                e.NextCtrl = null;

                                if (colIndex <= 3)
                                {
                                    if (rowIndex == 0)
                                    {
                                        e.NextCtrl = this.Cancel_Button;
                                    }
                                    else
                                    {
                                        this.uGrid_Details.Rows[rowIndex - 1].Cells[3].Activate();
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(UltraGridAction.PrevCellByTab);
                                }
                            }
                        }
                        break;

                        #endregion
                    }
            }

            if (e.NextCtrl == null)
            {
                return;
            }

            switch (e.NextCtrl.Name)
            {
                // �O���b�h
                case "uGrid_Details":
                    {
                        #region �O���b�h

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                            {
                                if (this.uGrid_Details.Rows.Count == 0)
                                {
                                    e.NextCtrl = this.Ok_Button;
                                }
                                else
                                {
                                    e.NextCtrl = null;

                                    this.uGrid_Details.Rows[0].Cells[3].Activate();

                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            else if (e.Key == Keys.Up)
                            {
                                if (this.uGrid_Details.Rows.Count == 0)
                                {
                                    e.NextCtrl = this.Ok_Button;
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[3].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.uGrid_Details.Rows.Count == 0)
                                {
                                    e.NextCtrl = this.Cancel_Button;
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[3].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        break;

                        #endregion
                    }
            }
        }
    }
}