//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�K�C�h
// �v���O�����T�v   : ���i�K�C�h�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : 杍^
// �� �� ��  2017/07/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00 �쐬�S�� : 3H ������                               
// �C �� ��  2017/09/07  �C�����e : ���i�Ɖ�̕ύX�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���i�K�C�h�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�K�C�h�t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2017/07/20</br>
    /// <br>Update Note: 2017/09/07 3H ������</br>
    /// <br>�@�@�@�@�@ : ���i�Ɖ�̕ύX�Ή�</br>
    /// </remarks>
    public partial class PMHND04201UB : Form
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region ��Privaete Members
        /// <summary>�_�C�A���O���U���g</summary>
        private DialogResult DgResult = DialogResult.Cancel;
        /// <summary>�C���[�W���X�g</summary>
        private ImageList ImageList16 = null;
        /// <summary>�I���{�^��</summary>
        private Infragistics.Win.UltraWinToolbars.ButtonTool BackButton;
        /// <summary>�m��{�^��</summary>
        private Infragistics.Win.UltraWinToolbars.ButtonTool DecisionButton;
        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin ControlScreenSkin;
        /// <summary>���i�A�N�Z�X�N���X</summary>
        private InspectInfoAcs InspectInfoObj;
        /// <summary>���׃f�[�^�i�[�f�[�^�Z�b�g</summary>
        private InspectDataSet DataSet;
        /// <summary>���t�A�N�Z�X�N���X</summary>
        private DateGetAcs DateGetObj = null;
        /// <summary>�߂錟�i�f�[�^</summary>
        private HandyInspectDataWork RetWork = new HandyInspectDataWork();
        /// <summary>���׃f�[�^�i�[�f�[�^�r���[</summary>
        private DataView ViewInspect = null;

        /// <summary>���i�����̓G���[ </summary>
        private const string InspectDateError = "���i���̓��͂��s���ł��B";
        /// <summary>���i�f�[�^�G���[�̃��b�Z�[�W</summary>
        private const string UpdInspectDateEmptyError = "�����\�Ȍ��i�f�[�^�����݂��܂���B";
        /// <summary>���i�f�[�^�G���[�̃��b�Z�[�W</summary>
        private const string InspectDateEmptyError = "���i�f�[�^�����݂��܂���B";
        /// <summary>���i�f�[�^�擾�G���[�̃��b�Z�[�W</summary>
        private const string InspectDateSearchError = "���i�f�[�^�������Ɏ��s���܂����B";
        /// <summary>���i�f�[�^���I���G���[�̃��b�Z�[�W</summary>
        private const string InspectDateNoSelectError = "���i�f�[�^���I�����܂���B";

        /// <summary>���ʃt�H�[�}�b�g</summary>
        private const string CountFormat = "#,###,##0.00";
        /// <summary>/������</summary>
        private const string StringSlash = "/";
        /// <summary>�󕶎���</summary>
        private const string StringEmpty = "";
        /// <summary>���t�t�H�[�}�b�g</summary>
        private const string DateFormat = "yyyy/MM/dd";
        /// <summary>�̔��Ɩ�(����)</summary>
        private const string AcPaySlipName = "�̔��Ɩ�(����)";
        // --- ADD 3H ������ 2017/09/07---------->>>>>
        /// <summary>�݌Ɏd��(����)</summary>
        private const string AcPaySlipStockSupplierInName = "�݌Ɏd��(����)";
        /// <summary>�݌Ɏd��(�o��)</summary>
        private const string AcPaySlipStockSupplierOutName = "�݌Ɏd��(�o��)";
        // --- ADD 3H ������ 2017/09/07----------<<<<<
        /// <summary>�I���{�^��</summary>
        private const string ButtonToolBack = "ButtonTool_Back";
        /// <summary>�m��{�^��</summary>
        private const string ButtonToolDecision = "ButtonTool_Decision";
        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region ��Constructors

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMHND04201UB()
        {
            InitializeComponent();
            // �R���g���[�����i�X�L����ݒ肵�܂��B
            this.ControlScreenSkin = new ControlScreenSkin();
            // ���i�A�N�Z�X�N���X�����������܂��B
            this.InspectInfoObj = InspectInfoAcs.GetInstance();
            // ���t�A�N�Z�X�N���X�����������܂��B
            this.DateGetObj = DateGetAcs.GetInstance();
            // �R���g���[�����i�C���[�W��ݒ肵�܂��B
            this.ImageList16 = IconResourceManagement.ImageList16;
            // �I���{�^��
            this.BackButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools[ButtonToolBack];
            // �m��{�^��
            this.DecisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools[ButtonToolDecision];
            this.tToolbarsManager_Main.ImageListSmall = this.ImageList16;
            this.BackButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this.DecisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
        }

        #endregion

        #region ���v���p�e�B
        /// <summary>
        /// �K�C�h��ʂŊm��{�^�������������ۂɑI������Ă������i�f�[�^
        /// </summary>
        public HandyInspectDataWork RetInspectDataWork
        {
            get
            {
                return RetWork;
            }
            set
            {
                this.RetWork = value;
            }
        }

        #endregion

        // ===================================================================================== //
        // �p�u���b�N ���\�b�h
        // ===================================================================================== //
        #region ��Public Methods

        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="owner">�I�[�i�[�t�H�[��</param>
        /// <param name="handyInspectParamWork">�����p�����[�^</param>
        /// <param name="mode">0:���i�\�� 1:���i����</param>
        /// <returns>>DialogResult[OK: �m��, OK�ȊO: �L�����Z��]</returns>
        /// <remarks>
        /// <br>Note       : ��ʕ\���������s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2017/09/07 3H ������</br>
        /// <br>�@�@�@�@�@ : ���i�Ɖ�̕ύX�Ή�</br>
        /// </remarks>
        public DialogResult ShowDialog(IWin32Window owner, HandyInspectDataWork handyInspectParamWork, int mode)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            this.tEdit_GoodsNo.Value = handyInspectParamWork.GoodsNo;
            this.tDateEdit_InspectDate.SetDateTime(handyInspectParamWork.InspectDateTime);
            this.DataSet = new InspectDataSet();
            ArrayList HandyInspectDataList = new ArrayList();

            //if (handyInspectParamWork.AcPaySlipCd == 20 && handyInspectParamWork.AcPayTransCd == 11)  // --- DEL 3H ������ 2017/09/07
            // --- ADD 3H ������ 2017/09/07---------->>>>>
            // �����P�F�@�󕥌��`�[�敪���u20�F����v�@AND�@�󕥌�����敪���u11�F�ԕi�v
            // �����Q�F�@�󕥌��`�[�敪���u10�F�d���v�@AND�@�󕥌�����敪�@IN�u10�F�ʏ�`�[ , 11�F�ԕi�v
            if ((handyInspectParamWork.AcPaySlipCd == 20 && handyInspectParamWork.AcPayTransCd == 11) 
                || (handyInspectParamWork.AcPaySlipCd == 10 && (handyInspectParamWork.AcPayTransCd == 10 || handyInspectParamWork.AcPayTransCd == 11)))
            // --- ADD 3H ������ 2017/09/07----------<<<<<
            {
                // ���i�f�[�^����
                Status = this.InspectInfoObj.SearchGuid(handyInspectParamWork, out HandyInspectDataList);
            }
            else
            {
                Status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ��ʕ\�����[�h��1:���i�������w�肵�ĕ\�����������s���ꂽ�ꍇ�A���A�Ώۃf�[�^���ꌏ�����̏ꍇ�A���i�K�C�h�|�b�v�A�b�v��ʂ��N�����܂���B
                if (mode == 1 && HandyInspectDataList.Count == 1)
                {
                    RetWork = HandyInspectDataList[0] as HandyInspectDataWork;
                    return DialogResult.OK;
                }

                // ��ʕ\�����[�h��0:���i�\�����w�肵�ĕ\�����������s���ꂽ�A���邢�́A�Ώۃf�[�^����������ꍇ�A���i�K�C�h��\�����܂��B
                if (HandyInspectDataList.Count > 1 || mode == 0)
                {

                    this.DataSet.InspectData.BeginLoadData();
                    this.DataSet.InspectData.Rows.Clear();
                    DataRow newRow = null;
                    int index = 0;
                    // �f�[�^�W�J����
                    foreach (HandyInspectDataWork refDataWork in HandyInspectDataList)
                    {
                        newRow = this.DataSet.InspectData.NewRow();

                        newRow[this.DataSet.InspectData.NoColumn] = index;            // NO
                        newRow[this.DataSet.InspectData.InspectDateColumn] = refDataWork.InspectDateTime.ToString(DateFormat);          // ���i��
                        newRow[this.DataSet.InspectData.InspectTimeColumn] = refDataWork.InspectDateTime.ToShortTimeString().ToString();                // ���i������
                        newRow[this.DataSet.InspectData.InspectCntColumn] = refDataWork.InspectCnt.ToString(CountFormat); ;          // ����
                        if (refDataWork.AcPaySlipCd == 20 && refDataWork.AcPayTransCd == 11)
                        {
                            newRow[this.DataSet.InspectData.AcPaySlipNameColumn] = AcPaySlipName;                  // ����
                        }
                        // --- ADD 3H ������ 2017/09/07---------->>>>>
                        // �󕥌��`�[�敪���u10�F�d���v�@AND�@�󕥌�����敪���u10�F�ʏ�`�[�v
                        else if (refDataWork.AcPaySlipCd == 10 && refDataWork.AcPayTransCd == 10)
                        {
                            // ����: �݌Ɏd��(����)
                            newRow[this.DataSet.InspectData.AcPaySlipNameColumn] = AcPaySlipStockSupplierInName;
                        }
                        // �󕥌��`�[�敪���u10�F�d���v�@AND�@�󕥌�����敪���u11�F�ԕi�v
                        else if (refDataWork.AcPaySlipCd == 10 && refDataWork.AcPayTransCd == 11)
                        {
                            // ����: �݌Ɏd��(�o��)
                            newRow[this.DataSet.InspectData.AcPaySlipNameColumn] = AcPaySlipStockSupplierOutName;
                        }
                        // --- ADD 3H ������ 2017/09/07----------<<<<<
                        else
                        {
                            newRow[this.DataSet.InspectData.AcPaySlipNameColumn] = string.Empty;                  // ����
                        }
                        newRow[this.DataSet.InspectData.AcPaySlipCdColumn] = refDataWork.AcPaySlipCd;          // �󕥌��`�[�敪
                        newRow[this.DataSet.InspectData.AcPayTransCdColumn] = refDataWork.AcPayTransCd;          // �󕥌�����敪
                        newRow[this.DataSet.InspectData.AcPaySlipNumColumn] = refDataWork.AcPaySlipNum;          // �󕥌��`�[�ԍ�
                        newRow[this.DataSet.InspectData.AcPaySlipRowNoColumn] = refDataWork.AcPaySlipRowNo;          // �󕥌��s�ԍ�
                        newRow[this.DataSet.InspectData.EmployeeCodeColumn] = refDataWork.EmployeeCode;
                        newRow[this.DataSet.InspectData.EmployeeNameColumn] = this.InspectInfoObj.GetEmployeeName(refDataWork.EmployeeCode);                // �S����
                        newRow[this.DataSet.InspectData.GoodsMakerCdColumn] = refDataWork.GoodsMakerCd;          // ���[�J�[�R�[�h
                        newRow[this.DataSet.InspectData.GoodsNoColumn] = refDataWork.GoodsNo;                  // �i��
                        newRow[this.DataSet.InspectData.InspectStatusColumn] = refDataWork.InspectStatus;                  // ���i�X�e�[�^�X
                        newRow[this.DataSet.InspectData.InspectCodeColumn] = refDataWork.InspectCode;                  // ���i�敪
                        newRow[this.DataSet.InspectData.HandTerminalCodeColumn] = refDataWork.HandTerminalCode;                  // �n���f�B�^�[�~�i���敪
                        newRow[this.DataSet.InspectData.MachineNameColumn] = refDataWork.MachineName;                  // �[������
                        newRow[this.DataSet.InspectData.WarehouseCodeColumn] = refDataWork.WarehouseCode;                  // �q�ɃR�[�h
                        newRow[this.DataSet.InspectData.EnterpriseCodeColumn] = refDataWork.EnterpriseCode;                  // ��ƃR�[�h
                        newRow[this.DataSet.InspectData.InspectDateTimeColumn] = (long)refDataWork.InspectDateTime.Ticks;                  // ���i����
                        index++;
                        this.DataSet.InspectData.Rows.Add(newRow);
                    }
                    this.DataSet.InspectData.EndLoadData();
                }
                // ��ʕ\�����[�h�Ɂu0:���i�\���v���w�肵�ĕ\�����������s���ꂽ�ꍇ�A�m��(F10)��\��
                if (mode == 0)
                {
                    this.DecisionButton.SharedProps.Visible = false;
                }
                // ��ʕ\�����[�h�Ɂu1:���i�����v���w�肵�ĕ\�����������s���ꂽ�ꍇ�A�m��(F10)�{�^���L��
                else
                {
                    this.DecisionButton.SharedProps.Visible = true;
                }
                
            }
            else if (Status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                if (mode == 1)
                {
                    TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       UpdInspectDateEmptyError,
                       0,
                       MessageBoxButtons.OK);
                }
                else
                {
                    TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       InspectDateEmptyError,
                       0,
                       MessageBoxButtons.OK);
                }
                return DialogResult.None;
            }
            else
            {
                TMsgDisp.Show(
                      this,
                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                      this.Name,
                      InspectDateSearchError,
                      -1,
                      MessageBoxButtons.OK);
                return DialogResult.None;
            }

            return this.ShowDialog(owner);

        }

        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g ���\�b�h
        // ===================================================================================== //
        #region ��Private Methods
        /// <summary>
        /// ���׃O���b�h�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���׃O���b�h�ݒ菈�����s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        internal void SettingGrid()
        {
            try
            {
                // �`����ꎞ��~
                this.uGrid_Details.BeginUpdate();

                // �`�悪�K�v�Ȗ��׌������擾����B
                int Cnt = this.uGrid_Details.Rows.Count;

                // �e�s���Ƃ̐ݒ�
                for (int i = 0; i < Cnt; i++)
                {
                    this.SettingGridRow(i);
                }
            }
            finally
            {
                // �`����J�n
                this.uGrid_Details.EndUpdate();
            }
        }

        /// <summary>
        /// ���׃O���b�h�E�s�P�ʂł̃Z���ݒ�
        /// </summary>
        /// <param name="rowIndex">�Ώۍs�C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���׃O���b�h�E�s�P�ʂł̃Z���ݒ菈�����s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void SettingGridRow(int rowIndex)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand EditBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (EditBand == null) return;

            // �w��s�̑S�Ă̗�ɑ΂��Đݒ���s���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in EditBand.Columns)
            {
                // �Z�������擾
                Infragistics.Win.UltraWinGrid.UltraGridCell Cell = this.uGrid_Details.Rows[rowIndex].Cells[col];
                if (Cell == null) continue;

                Cell.Row.Hidden = false;

                // �A���_�[���C����S�ẴZ���ɑ΂��Ĕ�\���Ƃ���
                Cell.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.False;

                Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }
        }

        #endregion

        // ===================================================================================== //
        // �R���g���[���̃C�x���g
        // ===================================================================================== //
        #region ��Control Events

        /// <summary>
        /// �t�H�[�� Load�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�� Load�C�x���g���s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void PMHND04201UB_Load(object sender, EventArgs e)
        {
            this.ControlScreenSkin.LoadSkin();
            this.ControlScreenSkin.SettingScreenSkin(this);

           this.ViewInspect = new DataView(this.DataSet.InspectData);

           this.uGrid_Details.DataSource = this.ViewInspect;
           string Filter = string.Format(" {0} >= '{1}' ",
               this.DataSet.InspectData.InspectDateColumn.ColumnName, this.tDateEdit_InspectDate.GetDateTime().ToString(DateFormat));

           this.ViewInspect.RowFilter = Filter;

            this.SettingGrid();
        }

        /// <summary>
        /// �t�H�[�� Closed�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�� Closed�C�x���g���s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void PMHND04201UB_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = this.DgResult;
        }

        /// <summary>
        /// �t�H�[�J�XChange�C�x���g(tArrowKeyControl1, tRetKeyControl1)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�XChange�C�x���g���s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "tDateEdit_InspectDate":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                case Keys.Right:
                                case Keys.Down:
                                    {
                                        DateGetAcs.CheckDateResult Cdr;
                                        Cdr = this.DateGetObj.CheckDate(ref this.tDateEdit_InspectDate, true);
                                        if (Cdr != DateGetAcs.CheckDateResult.OK)
                                        {
                                            this.tDateEdit_InspectDate.Clear();
                                            e.NextCtrl = this.tDateEdit_InspectDate;

                                            TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                InspectDateError,
                                                0,
                                                MessageBoxButtons.OK);
                                        }
                                        else
                                        {
                                            string Filter = string.Format(" {0} >= '{1}' ",
                                            this.DataSet.InspectData.InspectDateColumn.ColumnName, this.tDateEdit_InspectDate.GetDateTime().ToString(DateFormat));

                                            this.ViewInspect.RowFilter = Filter;

                                            if (this.uGrid_Details.Rows.Count > 0)
                                            {
                                                e.NextCtrl = null;
                                                this.uGrid_Details.Focus();
                                                this.uGrid_Details.ActiveRow = this.uGrid_Details.Rows[0];
                                                this.uGrid_Details.ActiveRow.Selected = true;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tDateEdit_InspectDate;
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if (e.NextCtrl == this.uGrid_Details)
                                        {
                                            e.NextCtrl = this.tDateEdit_InspectDate;
                                        }
                                    }
                                    break;
                            }
                        }

                    }
                    break;
            }
        }

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�N���b�N�C�x���g���s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void tToolbarsManager_Main_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �߂�
                case "ButtonTool_Back":
                    {
                        this.Close();
                        break;
                    }
                // �m��
                case "ButtonTool_Decision":
                    {
                        if (this.uGrid_Details.ActiveRow == null
                           || this.uGrid_Details.ActiveRow.Selected == false)
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          InspectDateNoSelectError,
                                          0,
                                          MessageBoxButtons.OK);
                            break;
                        }
                        RetWork = new HandyInspectDataWork();
                        // �S����
                        RetWork.EmployeeCode = (string)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.EmployeeCodeColumn];
                        // �[������
                        RetWork.MachineName = (string)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.MachineNameColumn];
                        // �n���f�B�^�[�~�i���敪
                        RetWork.HandTerminalCode = (int)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.HandTerminalCodeColumn];
                        // ���i�敪
                        RetWork.InspectCode = (int)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.InspectCodeColumn];
                        // ���i�X�e�[�^�X
                        RetWork.InspectStatus = (int)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.InspectStatusColumn];
                        // �󕥌��`�[�敪
                        RetWork.AcPaySlipCd = (int)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.AcPaySlipCdColumn];
                        // �󕥌��`�[�ԍ�
                        RetWork.AcPaySlipNum = (string)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.AcPaySlipNumColumn];
                        // �󕥌��s�ԍ�
                        RetWork.AcPaySlipRowNo = (int)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.AcPaySlipRowNoColumn];
                        // �󕥌�����敪
                        RetWork.AcPayTransCd = (int)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.AcPayTransCdColumn];
                        // ���[�J�[�R�[�h
                        RetWork.GoodsMakerCd = (int)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.GoodsMakerCdColumn];
                        // �i��
                        RetWork.GoodsNo = (string)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.GoodsNoColumn];
                        // �q�ɃR�[�h
                        RetWork.WarehouseCode = (string)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.WarehouseCodeColumn];
                        // ��ƃR�[�h
                        RetWork.EnterpriseCode = (string)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.EnterpriseCodeColumn];
                        // ���i����
                        long InspectString = (Int64)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.InspectDateTimeColumn];
                        RetWork.InspectDateTime = new DateTime(InspectString);
                        this.DgResult = DialogResult.OK;
                        this.Close();
                        break;
                    }
            }
        }

        /// <summary>
        /// �t�H�[���L�[�_�E���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[���L�[�_�E���C�x���g���s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void PMHND04201UB_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        #region �O���b�h�֘A
        /// <summary>
        /// ���i�f�[�^�O���b�h���C�A�E�g�������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���i�f�[�^�O���b�h���C�A�E�g�������C�x���g���s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

            // ��U�A�S�Ă̗���\���ɂ���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //��\���ݒ�
                column.Hidden = true;
                column.Header.Fixed = false;
            }

            int visiblePosition = 1;
            //--------------------------------------------------------------------------------
            //  �\������J�������
            //--------------------------------------------------------------------------------
            #region �J�������̐ݒ�

            // ���i��
            Columns[this.DataSet.InspectData.InspectDateColumn.ColumnName].Hidden = false;
            Columns[this.DataSet.InspectData.InspectDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.DataSet.InspectData.InspectDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this.DataSet.InspectData.InspectDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this.DataSet.InspectData.InspectDateColumn.ColumnName].Header.Caption = "���i��";
            Columns[this.DataSet.InspectData.InspectDateColumn.ColumnName].Width = 40;

            // ���i����
            Columns[this.DataSet.InspectData.InspectTimeColumn.ColumnName].Hidden = false;
            Columns[this.DataSet.InspectData.InspectTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.DataSet.InspectData.InspectTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this.DataSet.InspectData.InspectTimeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this.DataSet.InspectData.InspectTimeColumn.ColumnName].Header.Caption = "���i����";
            Columns[this.DataSet.InspectData.InspectTimeColumn.ColumnName].Width = 40;

            // ����
            Columns[this.DataSet.InspectData.InspectCntColumn.ColumnName].Hidden = false;
            Columns[this.DataSet.InspectData.InspectCntColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.DataSet.InspectData.InspectCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this.DataSet.InspectData.InspectCntColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this.DataSet.InspectData.InspectCntColumn.ColumnName].Header.Caption = "����";
            Columns[this.DataSet.InspectData.InspectCntColumn.ColumnName].Width = 45;

            // ����
            Columns[this.DataSet.InspectData.AcPaySlipNameColumn.ColumnName].Hidden = false;
            Columns[this.DataSet.InspectData.AcPaySlipNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.DataSet.InspectData.AcPaySlipNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this.DataSet.InspectData.AcPaySlipNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this.DataSet.InspectData.AcPaySlipNameColumn.ColumnName].Header.Caption = "����";
            Columns[this.DataSet.InspectData.AcPaySlipNameColumn.ColumnName].Width = 50;

            // ���i�S����
            Columns[this.DataSet.InspectData.EmployeeNameColumn.ColumnName].Hidden = false;
            Columns[this.DataSet.InspectData.EmployeeNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.DataSet.InspectData.EmployeeNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this.DataSet.InspectData.EmployeeNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this.DataSet.InspectData.EmployeeNameColumn.ColumnName].Header.Caption = "���i�S����";
            Columns[this.DataSet.InspectData.EmployeeNameColumn.ColumnName].Width = 75;
            #endregion

            // �Œ���؂���ݒ�
            this.uGrid_Details.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;

            this.uGrid_Details.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
        }
        #endregion

        /// <summary>
        /// ���i�f�[�^�O���b�h��Leave�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���i�f�[�^�O���b�h��Leave�C�x���g���s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveRow != null)
            {
                this.uGrid_Details.ActiveRow.Selected = false;
                this.uGrid_Details.ActiveRow = null;
            }
        }

        /// <summary>
        /// ���i�f�[�^�O���b�h��KeyDown�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���i�f�[�^�O���b�h��KeyDown�C�x���g���s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if ((this.uGrid_Details.ActiveRow.Index == 0 && e.KeyCode == Keys.Up))
            {
                this.tDateEdit_InspectDate.Focus();
            }
        }

        /// <summary>
        /// ���i����ValueChanged�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���i����ValueChanged�C�x���g���s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void tDateEdit_InspectDate_ValueChanged(object sender, EventArgs e)
        {
            if (this.ViewInspect != null)
            {
                string Filter = string.Format(" {0} >= '{1}' ",
                this.DataSet.InspectData.InspectDateColumn.ColumnName, this.tDateEdit_InspectDate.GetDateTime().ToString(DateFormat));

                this.ViewInspect.RowFilter = Filter;
            }
        }
        #endregion
    }

}