//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d���M���� �t���t�H�[���N���X
// �v���O�����T�v   : �t�n�d���M�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/11/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Infragistics.Win;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �����M���ꗗ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �����M���ꗗ�t�H�[���N���X�ł��B</br>
    /// <br>Programmer  : �����</br>
    /// <br>Date        : 2009/11/23</br>
    /// </remarks>
    public partial class PMUOE01001UC : Form
    {
        #region �� �R���X�g���N�^ ��
        /// <summary>
        /// �����M���ꗗUI�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : �����M���ꗗUI�t�H�[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks>
        public PMUOE01001UC()
        {
            InitializeComponent();

            this._imageList16 = IconResourceManagement.ImageList16;
            this._okButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_OKBUTTON_KEY];
            this._backButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_BACKBUTTON_KEY];

            this._stockInputAcs = StockInputAcs.GetInstance();
            this._uOESendNotDataTable = this._stockInputAcs.uOESendNotDataTable;

            // �{�^�������ݒ菈��
            this.ButtonInitialSetting();

            // �\�[�g���̓V�X�e���敪�A�[���ԍ��A������R�[�h�Ƃ���B
            DataView dv = this._uOESendNotDataTable.DefaultView;
            dv.Sort = "SystemDivCd, CashRegisterNo, UOESupplierCd";
            this.uGrid_Details.DataSource = dv;

            // ��������
            this.SearchSendNot();
        }
        #endregion

        #region �� private�萔 ��
        // �c�[���o�[�c�[���L�[�ݒ�
        private const string TOOLBAR_OKBUTTON_KEY = "ButtonTool_OK";
        private const string TOOLBAR_BACKBUTTON_KEY = "ButtonTool_Back";

        // �O���b�h��
        private const string column_SelectionState = "SelectionState";
        private const string column_SystemDivCd = "SystemDivCd";
        private const string column_CashRegisterNo = "CashRegisterNo";
        private const string column_UOESupplierCd = "UOESupplierCd";
        #endregion

        #region �� private�ϐ� ��
        private ImageList _imageList16 = null;										// �C���[�W���X�g
        private Infragistics.Win.UltraWinToolbars.ButtonTool _okButton;				// �m��{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _backButton;			// �߂�{�^��

        private StockInputAcs _stockInputAcs;
        private StockInputDataSet.UOESendNotDataTable _uOESendNotDataTable;

        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        private string _loginSectionName = LoginInfoAcquisition.Employee.BelongSectionName;
        private string _employeeCode = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
        private string _employeeName = LoginInfoAcquisition.Employee.Name;

        /// <summary> �I�����X�g </summary>
        private Dictionary<int, UltraGridRow> _lstSelInf = new Dictionary<int, UltraGridRow>();
        #endregion

        #region �� �R���g���[���C�x���g ��
        /// <summary>
        /// �O���b�h�������C�A�E�g�ݒ�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: ��ʏ��������A�O���b�h�������C�A�E�g�ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks>
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // �O���b�h�񏉊��ݒ菈��
            this.InitialSettingGridCol();

            // �O���b�h��\����\���ݒ菈��
            this.SetGridColVisible();
        }

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �c�[���o�[�N���b�N���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �m��
                case TOOLBAR_OKBUTTON_KEY:
                    {
                        // �m�莞�̃G���[�`�F�b�N����
                        if (this.OKSelectCheck())
                        {
                            // �m�菈��
                            int status = this.Confim();
                            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                            {
                                DialogResult = DialogResult.OK;
                            }
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���ׂ��I������Ă��܂���B",
                                -1,
                                MessageBoxButtons.OK);
                        }
                        break;
                    }
                // �߂�
                case TOOLBAR_BACKBUTTON_KEY:
                    {
                        // �O�̉�ʂɖ߂�                    
                        DialogResult = DialogResult.Cancel;
                        break;
                    }
            }
        }

        /// <summary>
        /// �s���_�u���N���b�N���ꂽ�ꍇ�́A���̍s��I������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note        : �f�[�^���\������Ă��Ȃ��s���_�u���N���b�N���Ă��{�C�x���g�͔������Ȃ��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks>
        private void uGrid_Details_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            this.SetSelect(false);
        }

        /// <summary>
        /// �O���b�h���Enter�L�[�������ꂽ�ꍇ�́A���̍s��I������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note        : �O���b�h�A�N�e�B�u����Key�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    // Enter�L�[(�_�u���N���b�N)�ɂ��I������
                    this.SetSelect(true);
                    break;
            }
        }
        #endregion

        #region �� private���\�b�h ��
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ������̎��A�{�^�������ݒ菈�����s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;

            this._okButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            this._backButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
        }

        /// <summary>
        /// �O���b�h�񏉊��ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ������̎��A�O���b�h�񏉊��ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks>
        private void InitialSettingGridCol()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            // �����s�I����
            editBand.Layout.Override.SelectTypeRow = SelectType.Single;

            StockInputDataSet.UOESendNotDataTable table = this._uOESendNotDataTable;
            ColumnsCollection columns = editBand.Columns;

            //--------------------------------------
            // ���͕s��
            //--------------------------------------
            for (int index = 0; index < columns.Count; index++)
            {
                columns[index].CellActivation = Activation.NoEdit;
            }

            //--------------------------------------
            // �L���v�V����
            //--------------------------------------
            columns[table.SelImageColumn.ColumnName].Header.Caption = "";
            columns[table.SystemDivNmColumn.ColumnName].Header.Caption = "�V�X�e���敪";
            columns[table.CashRegisterNoColumn.ColumnName].Header.Caption = "�[���ԍ�";
            columns[table.UOESupplierNameColumn.ColumnName].Header.Caption = "������";

            //--------------------------------------
            // �w�b�_�̃e�L�X�g�ʒu(HAlign)
            //--------------------------------------
            columns[table.SystemDivNmColumn.ColumnName].Header.Appearance.TextHAlign = HAlign.Left;
            columns[table.CashRegisterNoColumn.ColumnName].Header.Appearance.TextHAlign = HAlign.Left;
            columns[table.UOESupplierNameColumn.ColumnName].Header.Appearance.TextHAlign = HAlign.Left;

            //--------------------------------------
            // ��
            //--------------------------------------
            columns[table.SelImageColumn.ColumnName].Width = 18;
            columns[table.SystemDivNmColumn.ColumnName].Width = 70;
            columns[table.CashRegisterNoColumn.ColumnName].Width = 60;
            columns[table.UOESupplierNameColumn.ColumnName].Width = 160;

            //--------------------------------------
            // �e�L�X�g�ʒu(HAlign)
            //--------------------------------------
            columns[table.SelImageColumn.ColumnName].CellAppearance.ImageHAlign = HAlign.Center;
            columns[table.SystemDivNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.CashRegisterNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.UOESupplierNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;

            //--------------------------------------
            // �e�L�X�g�ʒu(VAlign)
            //--------------------------------------
            for (int index = 0; index < columns.Count; index++)
            {
                columns[index].CellAppearance.TextVAlign = VAlign.Middle;
            }
            columns[table.SelImageColumn.ColumnName].CellAppearance.ImageVAlign = VAlign.Middle;


            //--------------------------------------
            // �t�H�[�}�b�g�ݒ�
            //--------------------------------------
            columns[table.CashRegisterNoColumn.ColumnName].Format = "000";

            //--------------------------------------
            // �N���b�N�����쐧��
            //--------------------------------------
            for (int index = 0; index < columns.Count; index++)
            {
                columns[index].CellClickAction = CellClickAction.RowSelect;
            }
        }

        /// <summary>
        /// �O���b�h��\����\���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ������̎��A�O���b�h�񏉊��ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks>
        private void SetGridColVisible()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            StockInputDataSet.UOESendNotDataTable table = this._uOESendNotDataTable;
            ColumnsCollection columns = editBand.Columns;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in columns)
            {
                // �S�Ă̗�����������\���ɂ���B
                col.Hidden = true;
            }

            columns[table.SelImageColumn.ColumnName].Hidden = false;
            columns[table.SelectionStateColumn.ColumnName].Hidden = true;
            columns[table.SystemDivCdColumn.ColumnName].Hidden = true;
            columns[table.SystemDivNmColumn.ColumnName].Hidden = false;
            columns[table.CashRegisterNoColumn.ColumnName].Hidden = false;
            columns[table.UOESupplierCdColumn.ColumnName].Hidden = true;
            columns[table.UOESupplierNameColumn.ColumnName].Hidden = false;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <remarks>
        /// <br>Note		: �����N���b�N�̎��A�������s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks>
        private bool SearchSendNot()
        {
            string message = "";

            InpDisplay inpDisplay = new InpDisplay();
            //������
            inpDisplay.EnterpriseCode = this._enterpriseCode;	//��ƃR�[�h
            inpDisplay.SectionCode = this._loginSectionCode;	//���_�R�[�h
            inpDisplay.SectionName = this._loginSectionName;	//���_��
            inpDisplay.EmployeeCode = this._employeeCode;		//���͒S���҃R�[�h
            inpDisplay.EmployeeName = this._employeeName;		//���͒S���Җ�

            inpDisplay.BusinessCode = 0;
            inpDisplay.SystemDivCd = -1;
            inpDisplay.CashRegisterNoDiv = 2;

            // �t�n�d�����f�[�^ ��������
            int status = _stockInputAcs.SearchDB2(inpDisplay, out message);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    message,
                    -1,
                    MessageBoxButtons.OK);
                return (false);
            }

            return (true);
        }

        /// <summary>
        /// �m�菈��
        /// </summary>
        /// <remarks>
        /// <br>Note		: �m��N���b�N�̎��A�m����s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks>
        private int Confim()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            Dictionary<int, InpDisplay> sefInfo = new Dictionary<int, InpDisplay>();
            foreach (UltraGridRow row in _lstSelInf.Values)
            {
                InpDisplay inpDisplay = new InpDisplay();
                inpDisplay.SystemDivCd = (int)row.Cells[column_SystemDivCd].Value;
                inpDisplay.CashRegisterNo = (int)row.Cells[column_CashRegisterNo].Value;
                inpDisplay.UOESupplierCd = (int)row.Cells[column_UOESupplierCd].Value;

                sefInfo.Add(row.ListIndex, inpDisplay);
            }

            // ���M������ʃf�[�^�̐ݒ菈��
            status = this._stockInputAcs.GetMenuData(sefInfo);

            return status;
        }

        /// <summary>
        /// Enter�L�[(�_�u���N���b�N)�ɂ��I������
        /// </summary>
        /// <param name="moveFlg">true:���̍s��I����ԂɁ^false:�Ȃɂ����Ȃ��i�}�E�X�_�u���N���b�N���j</param>
        /// <remarks>
        /// <br>Note		: Enter�L�[(�_�u���N���b�N)�ɂ��I���������s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks>
        private void SetSelect(bool moveFlg)
        {
            UltraGridRow activeRow = uGrid_Details.ActiveRow;

            if (activeRow != null)
            {
                CellsCollection activeCells = activeRow.Cells;

                if (activeCells[_uOESendNotDataTable.SelImageColumn.ColumnName].Value != DBNull.Value)
                {
                    activeCells[_uOESendNotDataTable.SelImageColumn.ColumnName].Value = DBNull.Value;
                    activeCells[_uOESendNotDataTable.SelectionStateColumn.ColumnName].Value = false;

                    if (_lstSelInf.ContainsKey(activeRow.ListIndex)) // �I����������
                    {
                        _lstSelInf.Remove(activeRow.ListIndex);
                    }
                }
                else
                {
                    int sysDiv = (int)activeCells[_uOESendNotDataTable.SystemDivCdColumn.ColumnName].Value;

                    if (!_lstSelInf.ContainsKey(activeRow.ListIndex))
                    {
                        _lstSelInf.Add(activeRow.ListIndex, activeRow);
                    }

                    // �I�����̃G���[�`�F�b�N����
                    if (this.SelectCheck())
                    {
                        // �I��ON
                        activeCells[_uOESendNotDataTable.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                        activeCells[_uOESendNotDataTable.SelectionStateColumn.ColumnName].Value = true;
                    }
                    else
                    {
                        if (_lstSelInf.ContainsKey(activeRow.ListIndex)) // �I����������
                        {
                            _lstSelInf.Remove(activeRow.ListIndex);
                        }

                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "�����̃V�X�e���敪�͑I���o���܂���B",
                            -1,
                            MessageBoxButtons.OK);
                    }
                }

                // �}�E�X�_�u���N���b�N�ɂ��ꍇ�͈ȉ��̏������Ȃ��B
                if (moveFlg)
                {
                    UltraGridRow ugr = activeRow.GetSibling(SiblingRow.Next);
                    if (ugr != null)
                    {
                        ugr.Activate();
                        ugr.Selected = true;
                    }
                }
            }
        }

        /// <summary>
        /// �I�����̃G���[�`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note		: �I�����̃G���[�`�F�b�N�������s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks>
        private bool SelectCheck()
        {
            List<int> selectSysDiv = new List<int>();
            // �����̃V�X�e���敪�̖��ׂ��I�����ꂽ�ꍇ
            foreach (UltraGridRow row in _lstSelInf.Values)
            {
                int sysDiv = (int)row.Cells[column_SystemDivCd].Value;
                if (!selectSysDiv.Contains(sysDiv))
                {
                    selectSysDiv.Add(sysDiv);
                }
            }

            // �����̃V�X�e���敪
            if (selectSysDiv.Count > 1)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// �m�莞�̃G���[�`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note		: �m�莞�̃G���[�`�F�b�N�������s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks>
        private bool OKSelectCheck()
        {
            // ���ׂ�����I������Ă��Ȃ����
            foreach (UltraGridRow row in this.uGrid_Details.Rows)
            {
                if ((bool)row.Cells[column_SelectionState].Value)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion �� private���\�b�h ��

        #region �� public���\�b�h ��
        /// <summary>
        /// ��ʕ\��
        /// </summary>
        /// <param name="owner">owner</param>
        /// <remarks>
        /// <br>Note        : ��ʕ\�����ɔ������܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/11/23</br>
        /// </remarks> 
        public new DialogResult ShowDialog(IWin32Window owner)
        {
            if (this.uGrid_Details.Rows.Count > 0)
            {
                // �擪�s��I����Ԃɂ���
                uGrid_Details.Rows[0].Activate();
                uGrid_Details.Rows[0].Selected = true;
            }
            else
            {
                // �Y���f�[�^���Ȃ��ꍇ�ɂ́A���̎|��\�����ĉ�ʂ̕\���͍s��Ȃ��B
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�Y���f�[�^������܂���B",
                    -1,
                    MessageBoxButtons.OK);

                return DialogResult.Cancel;
            }

            return base.ShowDialog(owner);
        }
        #endregion ��public���\�b�h ��
    }
}