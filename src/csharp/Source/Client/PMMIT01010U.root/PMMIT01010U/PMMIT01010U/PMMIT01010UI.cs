using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �������� ����ݒ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������ς̈���ݒ���s���t�H�[���N���X�ł��B�B</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2008.08.12</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.08.12 men �V�K�쐬</br>
    /// </remarks>
	public partial class PMMIT01010UI : Form
    {

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region ��Constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="estimateInputAcs">�������σA�N�Z�X�N���X</param>
        public PMMIT01010UI( EstimateInputAcs estimateInputAcs )
		{
			InitializeComponent();

            this._controlScreenSkin = new ControlScreenSkin();
            this._estimateInputAcs = estimateInputAcs;
            this._estimateInputInitDataAcs = EstimateInputInitDataAcs.GetInstance();

            this._estimateInputConstructionAcs = EstimateInputConstructionAcs.GetInstance();
            this._estimateInputInitData = new EstimateInputInitData();

            this._imageList16 = IconResourceManagement.ImageList16;
            this._backButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_Back"];
            this._entryAndPrintButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_EntryAndPrint"];

            this.tToolbarsManager_Main.ImageListSmall = this._imageList16;
            this._backButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            this._entryAndPrintButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINTOUT;
        }
        #endregion

        // ==================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ==================================================================================== //
        #region ��Private Member

        private EstimateInputAcs _estimateInputAcs;
        private EstimateInputInitDataAcs _estimateInputInitDataAcs;
        private EstimateInputConstructionAcs _estimateInputConstructionAcs;
        private EstimateInputInitData _estimateInputInitData;
        private ControlScreenSkin _controlScreenSkin;

        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        private ImageList _imageList16 = null;                                                  // �C���[�W���X�g
        private Infragistics.Win.UltraWinToolbars.ButtonTool _backButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _entryAndPrintButton;

        DialogResult _result = DialogResult.Cancel;

        private ConstantManagement.MethodResult _saveResult = ConstantManagement.MethodResult.ctFNC_NO_RETURN;
        private ConstantManagement.MethodResult _printResult = ConstantManagement.MethodResult.ctFNC_NO_RETURN;

        #endregion

        // ===================================================================================== //
        // �f���Q�[�g
        // ===================================================================================== //
        #region ��Delegate

        internal delegate void RefreshScreenEventHandler();

        #endregion

        // ===================================================================================== //
        // �C�x���g
        // ===================================================================================== //
        #region ��Events

        internal event RefreshScreenEventHandler RefreshScreen;

        internal event EventHandler InitialScreen;

        internal event EventHandler Reload;

        internal event EventHandler InitialScreenAfterSave;

        #endregion

        // ===================================================================================== //
        // �񋓌^
        // ===================================================================================== //
        #region ��Enums

        #endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        #region ��Properties

        /// <summary>�f�[�^�ۑ�����</summary>
        internal ConstantManagement.MethodResult SaveResult
        {
            get { return _saveResult; }
        }

        /// <summary>�f�[�^�������</summary>
        internal ConstantManagement.MethodResult PrintResult
        {
            get { return _printResult; }
        }

        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��Private Methods

        /// <summary>
        /// ��ʐݒ菈��
        /// </summary>
        /// <param name="salesSlip">����f�[�^�I�u�W�F�N�g</param>
        private void SetDisplay(SalesSlip salesSlip)
        {
            try
            {
                this.tEdit_EstimateTitle1.BeginUpdate();
                this.tEdit_EstimateNote1.BeginUpdate();
                this.tEdit_EstimateNote2.BeginUpdate();
                this.tEdit_EstimateNote3.BeginUpdate();
                this.tComboEditor_ListPricePrintDiv.BeginUpdate();
                this.tComboEditor_EstimateDtCreateDiv.BeginUpdate();
                this.tComboEditor_PartsNoPrtCd.BeginUpdate();
                this.tComboEditor_RateUseCode.BeginUpdate();

                // ���σ^�C�g��
                this.tEdit_EstimateTitle1.Text = salesSlip.EstimateTitle1;      
                // ���ϔ��l1
                this.tEdit_EstimateNote1.Text = salesSlip.EstimateNote1;        
                // ���ϔ��l2
                this.tEdit_EstimateNote2.Text = salesSlip.EstimateNote2;        
                // ���ϔ��l3
                this.tEdit_EstimateNote3.Text = salesSlip.EstimateNote3;        
                // �艿���
                ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_ListPricePrintDiv, salesSlip.ListPricePrintDiv, true);
                // �i�Ԉ��
                ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_PartsNoPrtCd, salesSlip.PartsNoPrtCd, true);
                // ���σf�[�^�쐬
                ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_EstimateDtCreateDiv, salesSlip.EstimateDtCreateDiv, true);
                // �|���g�p�敪
                ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_RateUseCode, salesSlip.RateUseCode, true);
                // ������
                this.tNedit_Rate.SetValue(salesSlip.SalesRate);

                if (salesSlip.RateUseCode == 1)
                {
                    this.tNedit_Rate.Visible = true;
                    this.uLabel_RateMark.Visible = true;
                }
                else
                {
                    this.tNedit_Rate.Visible = false;
                    this.uLabel_RateMark.Visible = false;
                }

                if (( this.tNedit_PrintCnt_All.GetInt() == 0 ) &&
                    ( this.tNedit_PrintCnt_Prime.GetInt() == 0 ) &&
                    ( this.tNedit_PrintCnt_Pure.GetInt() == 0 ) &&
                    ( this.tNedit_PrintCnt_Selected.GetInt() == 0 ) &&
                    ( salesSlip.EstimateDtCreateDiv == 1 ))
                {
                    this._entryAndPrintButton.SharedProps.Enabled = false;
                }
                else
                {
                    this._entryAndPrintButton.SharedProps.Enabled = true;
                }
            }
            finally
            {
                this.tEdit_EstimateTitle1.EndUpdate();
                this.tEdit_EstimateNote1.EndUpdate();
                this.tEdit_EstimateNote2.EndUpdate();
                this.tEdit_EstimateNote3.EndUpdate();
                this.tComboEditor_ListPricePrintDiv.EndUpdate();
                this.tComboEditor_EstimateDtCreateDiv.EndUpdate();
                this.tComboEditor_PartsNoPrtCd.EndUpdate();
                this.tComboEditor_RateUseCode.EndUpdate();
            }
        }

        #region �e�敪�l�ύX������

        /// <summary>
        /// �i�Ԉ���敪�ύX����
        /// </summary>
        /// <param name="salesSlip">����f�[�^�I�u�W�F�N�g</param>
        /// <param name="isCache">�L���b�V���L��</param>
        /// <returns>True:�i�Ԉ���敪�ύX�L</returns>
        private bool ChangePartsNoPrtCd( ref SalesSlip salesSlip, bool isCache )
        {
            bool changePartsNoPrtCd = false;

            int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_PartsNoPrtCd, ComboEditorGetDataType.TAG);

            if (salesSlip.PartsNoPrtCd != code)
            {
                changePartsNoPrtCd = true;
            }

            if (changePartsNoPrtCd)
            {
                salesSlip.PartsNoPrtCd = code;

                if (isCache)
                {
                    this._estimateInputAcs.Cache(salesSlip);
                }
            }
            return changePartsNoPrtCd;
        }

        /// <summary>
        /// �艿����敪�ύX����
        /// </summary>
        /// <param name="salesSlip">����f�[�^�I�u�W�F�N�g</param>
        /// <param name="isCache">�L���b�V���L��</param>
        /// <returns>True:�艿����敪�ύX�L</returns>
        private bool ChangeListPricePrintDiv( ref SalesSlip salesSlip, bool isCache )
        {
            bool changeListPricePrintDiv = false;

            int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_ListPricePrintDiv, ComboEditorGetDataType.TAG);

            if (salesSlip.ListPricePrintDiv != code)
            {
                changeListPricePrintDiv = true;
            }

            if (changeListPricePrintDiv)
            {
                salesSlip.ListPricePrintDiv = code;

                if (isCache)
                {
                    this._estimateInputAcs.Cache(salesSlip);
                }
            }
            return changeListPricePrintDiv;
        }

        /// <summary>
        /// �����v�Z�敪�ύX����
        /// </summary>
        /// <param name="salesSlip">����f�[�^�I�u�W�F�N�g</param>
        /// <param name="isCache">�L���b�V���L��</param>
        /// <returns>True:�����v�Z�敪�ύX�L</returns>
        private bool ChangeRateUseCode( ref SalesSlip salesSlip, bool isCache )
        {
            bool changeRateUseCode = false;

            int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_RateUseCode, ComboEditorGetDataType.TAG);

            if (salesSlip.RateUseCode != code)
            {
                changeRateUseCode = true;
            }

            if (changeRateUseCode)
            {
                salesSlip.RateUseCode = code;

                if (isCache)
                {
                    this._estimateInputAcs.Cache(salesSlip);
                }
            }
            return changeRateUseCode;
        }

        /// <summary>
        /// ���σf�[�^�쐬�敪�ύX����
        /// </summary>
        /// <param name="salesSlip">����f�[�^�I�u�W�F�N�g</param>
        /// <param name="isCache">�L���b�V���L��</param>
        /// <returns>True:���σf�[�^�쐬�敪�ύX�L</returns>
        private bool ChangeEstimateDtCreateDiv( ref SalesSlip salesSlip, bool isCache )
        {
            bool changeEstimateDtCreateDiv = false;

            int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_EstimateDtCreateDiv, ComboEditorGetDataType.TAG);

            if (salesSlip.EstimateDtCreateDiv != code)
            {
                changeEstimateDtCreateDiv = true;
            }

            if (changeEstimateDtCreateDiv)
            {
                salesSlip.EstimateDtCreateDiv = code;

                if (isCache)
                {
                    this._estimateInputAcs.Cache(salesSlip);
                }
            }
            return changeEstimateDtCreateDiv;
        }

        #endregion

        /// <summary>
        /// �ۑ�������O�`�F�b�N
        /// </summary>
        /// <returns></returns>
        private bool CheckPrintAndSave()
        {
            bool checkResult = true;

            int makeData = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_EstimateDtCreateDiv, ComboEditorGetDataType.TAG);

            if (( this.tNedit_PrintCnt_All.GetInt() == 0 ) &&
                ( this.tNedit_PrintCnt_Pure.GetInt() == 0 ) &&
                ( this.tNedit_PrintCnt_Prime.GetInt() == 0 ) &&
                ( this.tNedit_PrintCnt_Selected.GetInt() == 0 ) &&
                ( makeData == 1 ))
            {
                TMsgDisp.Show(
                   this,
                   emErrorLevel.ERR_LEVEL_EXCLAMATION,
                   this.Name,
                   "���σf�[�^�쐬�A��������̂ǂ��炩���w�肵�ĉ������B",
                   0,
                   MessageBoxButtons.OK);

                checkResult = false;
            }
            else if (( this.tNedit_PrintCnt_Pure.GetInt() != 0 ) ||
                     ( this.tNedit_PrintCnt_Prime.GetInt() != 0 ) ||
                     ( this.tNedit_PrintCnt_Selected.GetInt() != 0 ))
            {
                List<string> targetdataList;
                if (!this._estimateInputAcs.ExistPrintTargetData(this.tNedit_PrintCnt_Pure.GetInt(), this.tNedit_PrintCnt_Prime.GetInt(), this.tNedit_PrintCnt_Selected.GetInt(), out targetdataList))
                {
                    StringBuilder message = new StringBuilder();
                    message.Append("����ΏۂƂȂ閾�ׂ��������Ϗ�������܂��B" + Environment.NewLine + Environment.NewLine);

                    foreach (string s in targetdataList)
                    {
                        message.Append(s + "\r\n");
                    }

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        message.ToString(),
                        0,
                        MessageBoxButtons.OK);

                    checkResult = false;
                }
            }

            return checkResult;
        }

        /// <summary>
        /// ����o�^����
        /// </summary>
        /// <returns>True:��ʂ����</returns>
        private bool PrintAndSave()
        {
            this._saveResult = ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            this._printResult = ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            bool initialScreenAfterSave = false;
            bool initialScreen = false;
            bool reLoad = false;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                #region �O����

                // �S���ׂ̔�����z�v�Z
                this._estimateInputAcs.CalsclateDetialSalesPrice();

                #endregion

                #region �ۑ�����

                // ���σf�[�^�쐬�u����v
                if (this._estimateInputAcs.SalesSlip.EstimateDtCreateDiv == 0)
                {
                    // �s�v�ȍs�̍폜
                    this._estimateInputAcs.AdjustSaveData();

                    string retMessage;
                    int status = this._estimateInputAcs.SaveDBData(this._enterpriseCode, this._estimateInputAcs.SalesSlip.SalesSlipNum, out retMessage);

                    this.RefreshScreenCall();

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {

                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);
                        this._saveResult = ConstantManagement.MethodResult.ctFNC_NORMAL;

                        if (this._estimateInputConstructionAcs.SaveInfoStoreValue == EstimateInputConstructionAcs.SaveInfoStore_ON)
                        {
                            // ���ϓ��͗p�����l�N���X���V���A���C�Y
                            this._estimateInputInitData.EnterpriseCode = this._estimateInputAcs.SalesSlip.EnterpriseCode;
                            this._estimateInputInitData.CustomerCode = this._estimateInputAcs.SalesSlip.CustomerCode;
                            this._estimateInputInitData.Serialize();
                        }
                        initialScreenAfterSave = true;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)             // �r���i�ʒ[���X�V�ρj
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "���݁A�ҏW���̌��σf�[�^�͊��ɍX�V����Ă��܂��B" + "\r\n" + "\r\n" +
                            "�ŐV�̏����擾���܂��B",
                            -1,
                            MessageBoxButtons.OK);

                        reLoad = true;

                        this._saveResult = ConstantManagement.MethodResult.ctFNC_ERROR;

                        return true;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)             // �r���i�ʒ[�������폜�ρj
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "���݁A�ҏW���̌��σf�[�^�͊��ɍ폜����Ă��܂��B",
                            -1,
                            MessageBoxButtons.OK);

                        initialScreen = true;
                        this._saveResult = ConstantManagement.MethodResult.ctFNC_ERROR;
                        return true;
                    }
                    else if (status == 999)                                                             // �r���i�ʒ[���X�V�ρj
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "�ۑ��Ɏ��s���܂����B" + retMessage + "\r\n" + "\r\n" +
                            "�\���󂠂�܂��񂪁A�ēx�������s���Ă��������B",
                            -1,
                            MessageBoxButtons.OK);

                        initialScreen = true;

                        this._saveResult = ConstantManagement.MethodResult.ctFNC_ERROR;
                        return true;
                    }
                    else if (status == 811)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_STOPDISP,
                            this.Name,
                            "�ۑ��Ɏ��s���܂����B�i�^�C���A�E�g�G���[�j" + "\r\n" + "\r\n" + retMessage,
                            status,
                            MessageBoxButtons.OK);
                        this._saveResult = ConstantManagement.MethodResult.ctFNC_ERROR;

                        return false;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_STOPDISP,
                            this.Name,
                            "�ۑ��Ɏ��s���܂����B" + "\r\n"
                            + "\r\n" +
                            "�V�F�A�`�F�b�N�G���[�i��ƃ��b�N�j�ł��B" + "\r\n" +
                            "�����������A���̑��̋Ɩ����s���Ă��邽�ߖ{�����͍s���܂���B" + "\r\n" +
                            "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                            status,
                            MessageBoxButtons.OK);
                        this._saveResult = ConstantManagement.MethodResult.ctFNC_ERROR;

                        return false;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_STOPDISP,
                            this.Name,
                            "�ۑ��Ɏ��s���܂����B" + "\r\n"
                            + "\r\n" +
                            "�V�F�A�`�F�b�N�G���[�i���_���b�N�j�ł��B" + "\r\n" +
                            "���������A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n" +
                            "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                            status,
                            MessageBoxButtons.OK);
                        this._saveResult = ConstantManagement.MethodResult.ctFNC_ERROR;

                        return false;
                    }
                    else
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_STOPDISP,
                            this.Name,
                            "�ۑ��Ɏ��s���܂����B" + "\r\n" + "\r\n" + retMessage,
                            status,
                            MessageBoxButtons.OK);
                        this._saveResult = ConstantManagement.MethodResult.ctFNC_ERROR;

                        return false;
                    }
                }
                #endregion

                #region ���

                if (( this.tNedit_PrintCnt_All.GetInt() != 0 ) ||
                    ( this.tNedit_PrintCnt_Prime.GetInt() != 0 ) ||
                    ( this.tNedit_PrintCnt_Pure.GetInt() != 0 ) ||
                    ( this.tNedit_PrintCnt_Selected.GetInt() != 0 ))
                {
                    // ����f�[�^�̎擾
                    EstFmPrintCndtn estFmPrintCndtn = this._estimateInputAcs.GetPrintData(this.tNedit_PrintCnt_All.GetInt(), this.tNedit_PrintCnt_Pure.GetInt(), this.tNedit_PrintCnt_Prime.GetInt(), this.tNedit_PrintCnt_Selected.GetInt());
                        
                    if (estFmPrintCndtn == null)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_STOPDISP,
                            this.Name,
                            "����f�[�^������܂���B",
                            -1,
                            MessageBoxButtons.OK);
                        initialScreenAfterSave = false;
                        initialScreen = false;
                        reLoad = false;

                        return false;
                    }

                    DCCMN02000UA slipPrintDialog = new DCCMN02000UA();
                    slipPrintDialog.ShowDialog(estFmPrintCndtn, false);

                    this._printResult = ConstantManagement.MethodResult.ctFNC_NORMAL;
                }

                #endregion
            }
            finally
            {
                this.Cursor = Cursors.Default;

                if (initialScreenAfterSave)
                {
                    if (this.InitialScreenAfterSave != null) this.InitialScreenAfterSave(this, new EventArgs());
                }
                if (initialScreen)
                {
                    if (this.InitialScreen != null) this.InitialScreen(this, new EventArgs());
                }
                else if (reLoad)
                {
                    if (this.Reload != null) this.Reload(this, new EventArgs());
                }
            }

            return true;
        }

        /// <summary>
        /// ��ʍĕ`��C�x���g�R�[��
        /// </summary>
        private void RefreshScreenCall()
        {
            if (this.RefreshScreen != null)
            {
                this.RefreshScreen();
            }
        }
        #endregion

        // ===================================================================================== //
        // �R���g���[���C�x���g
        // ===================================================================================== //
        #region ��Control Events
        /// <summary>
        /// ���Load�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMMIT01010UK_Load( object sender, EventArgs e )
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            this.tNedit_PrintCnt_All.SetInt(0);
            this.tNedit_PrintCnt_Prime.SetInt(0);
            this.tNedit_PrintCnt_Pure.SetInt(0);
            this.tNedit_PrintCnt_Selected.SetInt(0);

            this.SetDisplay(this._estimateInputAcs.SalesSlip);

            this._printResult = ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            this._saveResult = ConstantManagement.MethodResult.ctFNC_NO_RETURN;
        }

        /// <summary>
        /// ChangeFocus�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl1_ChangeFocus( object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e )
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            SalesSlip salesSlipCurrent = this._estimateInputAcs.SalesSlip.Clone();
            if (salesSlipCurrent == null) return;

            SalesSlip salesSlip = salesSlipCurrent.Clone();

            switch (e.PrevCtrl.Name)
            {
                #region �����σ^�C�g���P
                case "tEdit_EstimateTitle1":
                    {
                        string estimateTitle1 = this.tEdit_EstimateTitle1.Text;
                        if (estimateTitle1 != salesSlipCurrent.EstimateTitle1)
                        {
                            salesSlip.EstimateTitle1 = estimateTitle1;
                        }
                        break;
                    }
                #endregion

                #region �����ϔ��l�P
                case "tEdit_EstimateNote1":
                    {
                        string estimateNote1 = this.tEdit_EstimateNote1.Text;
                        if (estimateNote1 != salesSlipCurrent.EstimateNote1)
                        {
                            salesSlip.EstimateNote1 = estimateNote1;
                        }
                        break;
                    }
                #endregion

                #region �����ϔ��l�Q
                case "tEdit_EstimateNote2":
                    {
                        string estimateNote2 = this.tEdit_EstimateNote2.Text;
                        if (estimateNote2 != salesSlipCurrent.EstimateNote2)
                        {
                            salesSlip.EstimateNote2 = estimateNote2;
                        }
                        break;
                    }
                #endregion

                #region �����ϔ��l�R
                case "tEdit_EstimateNote3":
                    {
                        string estimateNote3 = this.tEdit_EstimateNote3.Text;
                        if (estimateNote3 != salesSlipCurrent.EstimateNote3)
                        {
                            salesSlip.EstimateNote3 = estimateNote3;
                        }
                        break;
                    }
                #endregion

                #region ���i�Ԉ���敪
                case "tComboEditor_PartsNoPrtCd":
                    {
                        this.tComboEditor_PartsNoPrtCd.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_PartsNoPrtCd_SelectionChangeCommitted);

                        this.ChangePartsNoPrtCd(ref salesSlip, false);

                        this.tComboEditor_PartsNoPrtCd.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_PartsNoPrtCd_SelectionChangeCommitted);
                        break;
                    }
                #endregion

                #region ���艿����敪
                case "tComboEditor_ListPricePrintDiv":
                    {
                        this.tComboEditor_ListPricePrintDiv.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_ListPricePrintDiv_SelectionChangeCommitted);

                        this.ChangeListPricePrintDiv(ref salesSlip, false);

                        this.tComboEditor_ListPricePrintDiv.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_ListPricePrintDiv_SelectionChangeCommitted);

                        break;
                    }
                #endregion

                #region �������v�Z�敪
                case "tComboEditor_RateUseCode":
                    {
                        this.tComboEditor_RateUseCode.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_RateUseCode_SelectionChangeCommitted);

                        bool changeRateUseCode = this.ChangeRateUseCode(ref salesSlip, false);

                        this.tComboEditor_RateUseCode.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_RateUseCode_SelectionChangeCommitted);

                        if (changeRateUseCode)
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        if (salesSlip.RateUseCode == 1)
                                        {
                                            e.NextCtrl = this.tNedit_Rate;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tComboEditor_EstimateDtCreateDiv;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region �����σf�[�^�쐬�敪
                case "tComboEditor_EstimateDtCreateDiv":
                    {
                        this.tComboEditor_EstimateDtCreateDiv.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_EstimateDtCreateDiv_SelectionChangeCommitted);

                        this.ChangeEstimateDtCreateDiv(ref salesSlip, false);

                        this.tComboEditor_EstimateDtCreateDiv.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_EstimateDtCreateDiv_SelectionChangeCommitted);
                        break;
                    }
                #endregion

                #region ��������
                case "tNedit_Rate":
                    {
                        double code = this.tNedit_Rate.GetValue();

                        if (code != salesSlipCurrent.SalesRate)
                        {
                            salesSlip.SalesRate = code;
                        }
                        break;
                    }
                #endregion

                #region ���������
                case "tNedit_PrintCnt_All":
                case "tNedit_PrintCnt_Pure":
                case "tNedit_PrintCnt_Prime":
                case "tNedit_PrintCnt_Selected":
                    {
                        this.SetDisplay(salesSlip);
                        break;
                    }
                #endregion
            }

            //---------------------------------------------------------------
            // ��������̓��e�Ɣ�r
            //---------------------------------------------------------------
            ArrayList arRetList = salesSlip.Compare(salesSlipCurrent);

            //---------------------------------------------------------------
            // ����f�[�^�ύX��
            //---------------------------------------------------------------
            if (arRetList.Count > 0)
            {
                // ����f�[�^�L���b�V������
                this._estimateInputAcs.Cache(salesSlip);

                // ����f�[�^�N���X����ʊi�[����
                this.SetDisplay(salesSlip);

                // �f�[�^�ύX�t���O�v���p�e�B��True�ɂ���
                this._estimateInputAcs.IsDataChanged = true;
            }
        }

        /// <summary>
        /// �i�Ԉ���敪�R���{�{�b�N�X SelectionChangeCommitted�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_PartsNoPrtCd_SelectionChangeCommitted( object sender, EventArgs e )
        {
            SalesSlip salesSlip = this._estimateInputAcs.SalesSlip;

            this.ChangePartsNoPrtCd(ref salesSlip, true);

            this.SetDisplay(salesSlip);
        }

        /// <summary>
        /// �艿����敪�R���{�{�b�N�X SelectionChangeCommitted�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_ListPricePrintDiv_SelectionChangeCommitted( object sender, EventArgs e )
        {
            SalesSlip salesSlip = this._estimateInputAcs.SalesSlip;

            this.ChangeListPricePrintDiv(ref salesSlip, true);

            this.SetDisplay(salesSlip);
        }

        /// <summary>
        /// �����v�Z�敪�R���{�{�b�N�X SelectionChangeCommitted�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_RateUseCode_SelectionChangeCommitted( object sender, EventArgs e )
        {
            SalesSlip salesSlip = this._estimateInputAcs.SalesSlip;

            this.ChangeRateUseCode(ref salesSlip, true);

            this.SetDisplay(salesSlip);
        }

        /// <summary>
        /// �f�[�^�쐬�敪�R���{�{�b�N�X SelectionChangeCommitted�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_EstimateDtCreateDiv_SelectionChangeCommitted( object sender, EventArgs e )
        {
            SalesSlip salesSlip = this._estimateInputAcs.SalesSlip;

            this.ChangeEstimateDtCreateDiv(ref salesSlip, true);

            this.SetDisplay(salesSlip);
        }

        /// <summary>
        /// �c�[���{�^�� �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tToolbarsManager_Main_ToolClick( object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e )
        {
            switch (e.Tool.Key)
            {
                // �߂�
                case "ButtonTool_Back":
                    {
                        this.Close();
                        break;
                    }
                // ����o�^
                case "ButtonTool_EntryAndPrint":
                    {
                        if (this.CheckPrintAndSave())
                        {
                            if (this.PrintAndSave())
                            {
                                this._result = DialogResult.OK;
                                this.Close();
                            }
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// ��������ύX�������C�x���g(�S�Ă̕����ł��̃C�x���g�������j
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tNedit_PrintCnt_All_ValueChanged( object sender, EventArgs e )
        {
            this.SetDisplay(this._estimateInputAcs.SalesSlip);
        }

        /// <summary>
        /// �t�H�[���N���[�Y�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void PMMIT01010UK_FormClosed( object sender, FormClosedEventArgs e )
        {
            DialogResult = this._result;
        }

        /// <summary>
        /// �t�H�[���@�L�[�_�E���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMMIT01010UI_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        #endregion

    }
}