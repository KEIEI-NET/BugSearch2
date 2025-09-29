//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���}�X�^���p�o�^
// �v���O�����T�v   : �|���}�X�^���p�o�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/08  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��ؑn
// �� �� ��  2021/09/06  �C�����e : �ۑ��������A�A�N�Z�X�N���X�Ɉ��p�����Ӑ�|���O���[�v�R�[�h��0000���ǂ����̏���n���悤�C���B
//                                  BLINCIDENT-2384 PM(NS) �|���}�X�^���p�o�^�̏������m�F�������B
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;

using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// �|���}�X�^���p�o�^�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���}�X�^���p�o�^���s���܂��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2008.03.27</br>
    /// </remarks>
    public partial class PMKHN09411UA : Form
    {
        // ===================================================================================== //
        // Private Members
        // ===================================================================================== //
        #region
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;					// �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _updateButton;					// �X�V�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;					// �I�������{�^��					
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;				// ���O�C���S���Җ���
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;

        private string _enterpriseCode;
        private RateQuoteInputAcs _rateQuoteInputAcs = null;
        private SecInfoAcs _secInfoAcs;                     // ���_���A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs = null;        // ���_�A�N�Z�X�N���X
        private UserGuideAcs _userGuideAcs = null;			// ���[�U�[�K�C�h�A�N�Z�X�N���X
        private CustomerSearchAcs _customerSearchAcs = null;  
        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, string> _custRateGrpDic;
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;
        private Control _prevControl = null;									// ���݂̃R���g���[��
        private bool _setDisplayFlg = false;
        private bool BfFocusFlg = false;
        private bool AfFocusFlg = false;
        #endregion

        // ===================================================================================== //
        // Constructor
        // ===================================================================================== //
        #region
        /// <summary>
        /// �|���}�X�^���p�o�^�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �|���}�X�^���p�o�^�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: ���m</br>
        /// <br>Date		: 2008.03.27</br>
        /// </remarks>
        public PMKHN09411UA()
        {
            InitializeComponent();

            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;

            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._updateButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Update"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Clear"];

            //�@��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._rateQuoteInputAcs = RateQuoteInputAcs.GetInstance();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._customerSearchAcs = new CustomerSearchAcs();

            // �}�X�^�Ǎ�
            ReadSecInfoSet();

            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
        }
        #endregion

        // ===================================================================================== //
        //  Private Methods
        // ===================================================================================== //
        #region
        /// <summary>
        /// �{�^���ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._updateButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            this.BfSectionGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.BfCustRateGrpGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.BfCustomerCodeGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.AfSectionGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.AfCustRateGrpGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.AfCustomerCodeGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
        }

        /// <summary>
        /// �R���{�N�X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void ComboBoxSetting()
        {
            // �Ώۋ敪
            this.SetItemObjectDistinction();
            // �X�V�敪
            this.SetItemUpdateDistinction();
        }

        /// <summary>
        /// �Ώۋ敪
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void SetItemObjectDistinction()
        {
            this.ObjectDistinction_tComEditor.Items.Clear();

            Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
            item0.Tag = 1;
            item0.DataValue = 0;
            item0.DisplayText = "����E���i";
            this.ObjectDistinction_tComEditor.Items.Add(item0);

            Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
            item1.Tag = 2;
            item1.DataValue = 1;
            item1.DisplayText = "����̂�";
            this.ObjectDistinction_tComEditor.Items.Add(item1);

            Infragistics.Win.ValueListItem item2 = new Infragistics.Win.ValueListItem();
            item2.Tag = 3;
            item2.DataValue = 2;
            item2.DisplayText = "���i�̂�";
            this.ObjectDistinction_tComEditor.Items.Add(item2);

            this.ObjectDistinction_tComEditor.Value = 0;
        }

        
        /// <summary>
        /// �Ώۋ敪
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void SetItemUpdateDistinction()
        {
            this.UpdateDistinction_tComEditor.Items.Clear();

            Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
            item0.Tag = 1;
            item0.DataValue = 0;
            item0.DisplayText = "�ǉ��E�X�V";
            this.UpdateDistinction_tComEditor.Items.Add(item0);

            Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
            item1.Tag = 2;
            item1.DataValue = 1;
            item1.DisplayText = "�ǉ��̂�";
            this.UpdateDistinction_tComEditor.Items.Add(item1);

            this.UpdateDistinction_tComEditor.Value = 0;
        }

        /// <summary>
        /// ��ʕ\��
        /// </summary>
        /// <param name="stockQuoteData">��ʃf�[�^</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void SetDisplay(StockQuoteData stockQuoteData)
        {
            if (stockQuoteData == null) return;

            this._setDisplayFlg = true;

            // start
            this.tEdit_BfSectionCode.BeginUpdate();
            this.tEdit_AfSectionName.BeginUpdate();
            this.tEdit_BfCustRateGrpCode.BeginUpdate();
            this.tNedit_BfCustomerCode.BeginUpdate();
            this.tEdit_BfCustomerName.BeginUpdate();
            this.tEdit_AfSectionCode.BeginUpdate();
            this.tEdit_AfSectionName.BeginUpdate();
            this.tEdit_BfCustRateGrpCode.BeginUpdate();
            this.tNedit_BfCustomerCode.BeginUpdate();
            this.tEdit_AfCustomerName.BeginUpdate();
            this.ObjectDistinction_tComEditor.BeginUpdate();
            this.UpdateDistinction_tComEditor.BeginUpdate();

            // ��ʏ���\������
            this.tEdit_BfSectionCode.Text = stockQuoteData.BfSectionCode;
            this.tEdit_BfSectionName.Text = stockQuoteData.BfSectionName;
            if (!string.IsNullOrEmpty(stockQuoteData.BfCustRateGrpName))
            {
                this.tEdit_BfCustRateGrpCode.DataText = stockQuoteData.BfCustRateGrpCode.ToString("0000");
            }
            else
            {
                this.tEdit_BfCustRateGrpCode.DataText = "";
            }
            this.tNedit_BfCustomerCode.SetInt(stockQuoteData.BfCustomerCode);
            this.tEdit_BfCustomerName.Text = stockQuoteData.BfCustomerName;
            this.tEdit_AfSectionCode.Text = stockQuoteData.AfSectionCode;
            this.tEdit_AfSectionName.Text = stockQuoteData.AfSectionName;
            if (!string.IsNullOrEmpty(stockQuoteData.AfCustRateGrpName))
            {
                this.tEdit_AfCustRateGrpCode.DataText = stockQuoteData.AfCustRateGrpCode.ToString("0000");
            }
            else
            {
                this.tEdit_AfCustRateGrpCode.DataText = "";
            }
            this.tNedit_AfCustomerCode.SetInt(stockQuoteData.AfCustomerCode);
            this.tEdit_AfCustomerName.Text = stockQuoteData.AfCustomerName;
            this.ObjectDistinction_tComEditor.Value = stockQuoteData.ObjectDistinctionCode;
            this.UpdateDistinction_tComEditor.Value = stockQuoteData.UpdateDistinctionCode;
            this.ReadCount_uLabel.Text = stockQuoteData.ReadCount.ToString("N0") + " " + "��";
            this.ProcessCount_uLabel.Text = stockQuoteData.ProcessCount.ToString("N0") + " " + "��";

            // ���ENABLE
            this.tEdit_BfSectionCode.Enabled = true;
            this.BfSectionGuide_Button.Enabled = true;
            this.tEdit_BfCustRateGrpCode.Enabled = true;
            this.BfCustRateGrpGuide_Button.Enabled = true;
            this.tNedit_BfCustomerCode.Enabled = true;
            this.BfCustomerCodeGuide_Button.Enabled = true;
            this.tEdit_AfSectionCode.Enabled = true;
            this.AfSectionGuide_Button.Enabled = true;
            this.tEdit_AfCustRateGrpCode.Enabled = true;
            this.AfCustRateGrpGuide_Button.Enabled = true;
            this.tNedit_AfCustomerCode.Enabled = true;
            this.AfCustomerCodeGuide_Button.Enabled = true;

            // ���p�����Ӑ�|���O���[�v�����͂̏ꍇ
            if (!string.IsNullOrEmpty(stockQuoteData.BfCustRateGrpName))
            {
                this.tNedit_BfCustomerCode.Enabled = false;
                this.BfCustomerCodeGuide_Button.Enabled = false;
            }
            // ���p�����Ӑ�R�[�h�����͂̏ꍇ
            if (stockQuoteData.BfCustomerCode != 0)
            {
                this.tEdit_BfCustRateGrpCode.Enabled = false;
                this.BfCustRateGrpGuide_Button.Enabled = false;
            }
            // ���p�擾�Ӑ�|���O���[�v�����͂̏ꍇ
            if (!string.IsNullOrEmpty(stockQuoteData.AfCustRateGrpName))
            {
                this.tNedit_AfCustomerCode.Enabled = false;
                this.AfCustomerCodeGuide_Button.Enabled = false;
            }
            // ���p�擾�Ӑ�R�[�h�����͂̏ꍇ
            if (stockQuoteData.AfCustomerCode != 0)
            {
                this.tEdit_AfCustRateGrpCode.Enabled = false;
                this.AfCustRateGrpGuide_Button.Enabled = false;
            }

            // end
            this.tEdit_BfSectionCode.EndUpdate();
            this.tEdit_AfSectionName.EndUpdate();
            this.tEdit_BfCustRateGrpCode.EndUpdate();
            this.tNedit_BfCustomerCode.EndUpdate();
            this.tEdit_BfCustomerName.EndUpdate();
            this.tEdit_AfSectionCode.EndUpdate();
            this.tEdit_AfSectionName.EndUpdate();
            this.tEdit_AfCustRateGrpCode.EndUpdate();
            this.tNedit_AfCustomerCode.EndUpdate();
            this.tEdit_AfCustomerName.EndUpdate();
            this.ObjectDistinction_tComEditor.EndUpdate();
            this.UpdateDistinction_tComEditor.EndUpdate();

            this._setDisplayFlg = false;
        }

        /// <summary>
        /// ��ʏ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void Clear()
        {
            // ��ʏ������f�[�^
            this._rateQuoteInputAcs.CreateStockQuoteInitialData();
            // ��ʏ������\��
            this.SetDisplay(this._rateQuoteInputAcs.StockQuoteData);
            // ���Ӑ�|���O���[�v�ݒ�
            this.tEdit_BfCustRateGrpCode.Clear();
            this.tEdit_AfCustRateGrpCode.Clear();

            this.timer_SetFocus.Enabled = true;
        }

        /// <summary>
        /// ��ʍX�V
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void Save()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            if (this._prevControl != null)
            {
                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tRetKeyControl1_ChangeFocus(this, e);
            }

            // �`�F�b�N
            bool isSave = BeforeSaveCheck();

            if (!isSave)
            {
                return;
            }

            string msg = string.Empty;

            // ADD BLINCIDENT-2384 2021/09/06 --------------------------------------------------->>>>>

            // ���p���̓��Ӑ�|���O���[�v�R�[�h���u0000�v�̂Ƃ�Flag��True
            //   �{��ʂł͓��Ӑ�|���O���[�v�R�[�h���u0000�v�Ɓu�w��Ȃ��v�ǂ���̏ꍇ�ł��A
            //   BfCustRateGrpCode=0 �ƂȂ��Ă����ʂ����Ȃ����߁A�ʓr����t�^����B
            bool bfCustRateGrpCodeIsZero = this.tEdit_BfCustRateGrpCode.Text.Trim() == "0000" ? true : false ;

            // ADD BLINCIDENT-2384 2021/09/06 ---------------------------------------------------<<<<<

            // UPD BLINCIDENT-2384 2021/09/06 --------------------------------------------------->>>>>
            
            // �ۑ�����
            //status = this._rateQuoteInputAcs.SaveData(ref msg);
            status = this._rateQuoteInputAcs.SaveData(ref msg, bfCustRateGrpCodeIsZero);

            // UPD BLINCIDENT-2384 2021/09/06 ---------------------------------------------------<<<<<

            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                // �Y���Ȃ�
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                msg,                       // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);
                // �����X�V
                StockQuoteData stockQuoteData = this._rateQuoteInputAcs.StockQuoteData;

                this.ReadCount_uLabel.Text = stockQuoteData.ReadCount.ToString("N0") + " " + "��";
                this.ProcessCount_uLabel.Text = stockQuoteData.ProcessCount.ToString("N0") + " " + "��";
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                SaveCompletionDialog dialog = new SaveCompletionDialog();
                dialog.ShowDialog(2);
                // �����X�V
                this.ReadCount_uLabel.Text = this._rateQuoteInputAcs.StockQuoteData.ReadCount.ToString("N0") + " " + "��";
                this.ProcessCount_uLabel.Text = this._rateQuoteInputAcs.StockQuoteData.ProcessCount.ToString("N0") + " " + "��";
                // �t�H�[�J�X�ݒ�
                this.tEdit_BfSectionCode.Focus();
            }
            else
            {
                // ���b�Z�[�W���Ăяo��
                TMsgDisp.Show(
                   this,
                   emErrorLevel.ERR_LEVEL_STOPDISP,
                   this.Name,
                   "�ۑ����������s���܂��B",
                   -1,
                   MessageBoxButtons.OK);
                // �����X�V
                this.ReadCount_uLabel.Text = this._rateQuoteInputAcs.StockQuoteData.ReadCount.ToString("N0") + " " + "��";
                this.ProcessCount_uLabel.Text = this._rateQuoteInputAcs.StockQuoteData.ProcessCount.ToString("N0") + " " + "��";
            }
        }

        /// <summary>
        /// ��ʍX�V�O�`�F�b�N
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private bool BeforeSaveCheck()
        {

            StockQuoteData stockQuoteData = this._rateQuoteInputAcs.StockQuoteData;

            // ���p�����_���̓`�F�b�N
            if (string.IsNullOrEmpty(stockQuoteData.BfSectionCode))
            {
                // �Y���Ȃ�
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "���p�����_���ݒ肳��Ă��܂���B",                 // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);

                // �t�H�[�J�X�ݒ�
                this.tEdit_BfSectionCode.Focus();
                return false;
            }

            // ���p�拒�_���̓`�F�b�N
            if (string.IsNullOrEmpty(stockQuoteData.AfSectionCode))
            {
                // �Y���Ȃ�
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "���p�拒�_���ݒ肳��Ă��܂���B",                 // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);

                // �t�H�[�J�X�ݒ�
                this.tEdit_AfSectionCode.Focus();
                return false;
            }

            // ���p���񂪐ݒ肳��Ă��܂���
            if (string.IsNullOrEmpty(stockQuoteData.BfCustRateGrpName) && stockQuoteData.BfCustomerCode == 0)
            {
                // �Y���Ȃ�
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "���p����񂪐ݒ肳��Ă��܂���B",                 // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);

                // �t�H�[�J�X�ݒ�
                this.tEdit_BfCustRateGrpCode.Focus();
                return false;
            }

            // ���p���񂪐ݒ肳��Ă��܂���
            if (string.IsNullOrEmpty(stockQuoteData.AfCustRateGrpName) && stockQuoteData.AfCustomerCode == 0)
            {
                // �Y���Ȃ�
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "���p���񂪐ݒ肳��Ă��܂���B",                 // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);

                // �t�H�[�J�X�ݒ�
                this.tEdit_AfCustRateGrpCode.Focus();
                return false;
            }

            // ���p���ƈ��p�拒�_�R�[�h��������
            if (stockQuoteData.AfSectionCode.Equals(stockQuoteData.BfSectionCode))
            {
                if (!string.IsNullOrEmpty(stockQuoteData.BfCustRateGrpName) && !string.IsNullOrEmpty(stockQuoteData.AfCustRateGrpName)
                    && stockQuoteData.BfCustRateGrpCode == stockQuoteData.AfCustRateGrpCode)
                {
                    // �Y���Ȃ�
                    TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                    this.Name,											// �A�Z���u��ID
                                    "���p���A���p��̓��Ӑ�|���O���[�v�ݒ肪�s���ł��B", // �\�����郁�b�Z�[�W
                                    -1,													// �X�e�[�^�X�l
                                    MessageBoxButtons.OK);

                    // �t�H�[�J�X�ݒ�
                    this.tEdit_BfCustRateGrpCode.Focus();
                    return false;
                }

                if (stockQuoteData.BfCustomerCode != 0 && stockQuoteData.BfCustomerCode == stockQuoteData.AfCustomerCode)
                {
                    // �Y���Ȃ�
                    TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                    this.Name,											// �A�Z���u��ID
                                    "���p���A���p��̓��Ӑ�ݒ肪�s���ł��B",           // �\�����郁�b�Z�[�W
                                    -1,													// �X�e�[�^�X�l
                                    MessageBoxButtons.OK);

                    // �t�H�[�J�X�ݒ�
                    this.tNedit_BfCustomerCode.Focus();
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_��</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            sectionCode = sectionCode.Trim().PadLeft(2, '0');

            if (sectionCode == "00")
            {
                return "�S��";
            }

            if (this._secInfoSetDic.ContainsKey(sectionCode))
            {
                return this._secInfoSetDic[sectionCode].SectionGuideSnm.Trim();
            }

            return "";
        }

        /// <summary>
        /// ���_���}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
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
        /// ���Ӑ�|���O���[�v���̎擾����
        /// </summary>
        /// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h</param>
        /// <returns>���Ӑ�|���O���[�v����</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private string GetCustRateGrpName(int custRateGrpCode)
        {
            string custRateGrpName = "";

            if (this._custRateGrpDic.ContainsKey(custRateGrpCode))
            {
                custRateGrpName = (string)this._custRateGrpDic[custRateGrpCode];
            }

            return custRateGrpName;
        }

        /// <summary>
        /// ���Ӑ�|���O���[�v���擾����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private int GetCustRateGrp()
        {
            this._custRateGrpDic = new Dictionary<int, string>();

            int status;
            ArrayList retList = new ArrayList();

            // ���[�U�[�K�C�h�f�[�^�擾(���Ӑ�|���O���[�v)
            status = GetUserGuideBd(out retList, 43);
            if (status == 0)
            {
                foreach (UserGdBd userGdBd in retList)
                {
                    this._custRateGrpDic.Add(userGdBd.GuideCode, userGdBd.GuideName.Trim());
                }
            }

            return status;
        }

        /// <summary>
        /// ���[�U�[�K�C�h�f�[�^�擾����
        /// </summary>
        /// <param name="retList">���[�U�[�K�C�h�{�f�B�f�[�^���X�g</param>
        /// <param name="userGuideDivCd">�K�C�h�敪</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private int GetUserGuideBd(out ArrayList retList, int userGuideDivCd)
        {
            int status;
            retList = new ArrayList();

            status = this._userGuideAcs.SearchAllDivCodeBody(out retList, this._enterpriseCode,
                                                             userGuideDivCd, UserGuideAcsData.UserBodyData);

            return status;
        }

        /// <summary>
        /// ���Ӑ於�̎擾����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>���Ӑ於��</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            string customerName = "";

            try
            {
                if (this._customerSearchRetDic.ContainsKey(customerCode))
                {
                    customerName = this._customerSearchRetDic[customerCode].Snm.Trim();
                }
            }
            catch
            {
                customerName = "";
            }

            return customerName;
        }
        
        /// <summary>
        /// ���Ӑ挟���}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void LoadCustomerSearchRet()
        {
            this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();

            try
            {
                CustomerSearchPara para = new CustomerSearchPara();
                para.EnterpriseCode = this._enterpriseCode;

                CustomerSearchRet[] retList;

                int status = this._customerSearchAcs.Serch(out retList, para);
                if (status == 0)
                {
                    foreach (CustomerSearchRet ret in retList)
                    {
                        if (ret.LogicalDeleteCode == 0)
                        {
                            this._customerSearchRetDic.Add(ret.CustomerCode, ret);
                        }
                    }
                }
            }
            catch
            {
                this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
            }
        }
        #endregion


        // ===================================================================================== //
        // �e�R���g���[���C�x���g����
        // ===================================================================================== //
        # region ��Control Event Methods
        /// <summary>
        ///	Form.Load �C�x���g(PMKHN09411U)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer	: ���m</br>
        /// <br>Date		: 2008.03.27</br>
        /// </remarks>
        private void PMKHN09411U_Load(object sender, EventArgs e)
        {
            // �{�^���ݒ�
            this.ButtonInitialSetting();

            // �R���{�N�X�ݒ�
            this.ComboBoxSetting();

            // ��ʏ�����
            this.Clear();
        }

        /// <summary>
        /// �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // �I������
                        Close();
                        break;
                    }
                case "ButtonTool_Update":
                    {
                        this.Save();
                        break;
                    }
                case "ButtonTool_Clear":
                    {
                        // �N���A����
                        this.Clear();
                        break;
                    }
            }
        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            this._prevControl = e.NextCtrl;

            bool reReadFlg = false;

            StockQuoteData stockQuoteDataCurrent = this._rateQuoteInputAcs.StockQuoteData.Clone();
            if (stockQuoteDataCurrent == null) return;

            StockQuoteData stockQuoteData = stockQuoteDataCurrent.Clone();

            switch (e.PrevCtrl.Name)
            {
                // ���p�����_�R�[�h
                case "tEdit_BfSectionCode":
                    {
                        string code = this.tEdit_BfSectionCode.Text.Trim().PadLeft(2, '0');

                        if (string.IsNullOrEmpty(code) || "00".Equals(code))
                        {
                            code = "00";
                            stockQuoteData.BfSectionCode = code;
                            stockQuoteData.BfSectionName = GetSectionName(code);
                        }

                        if (e.ShiftKey == false)
                        {
                            // ���͕ύX�Ȃ�
                            if (code.Equals(stockQuoteData.BfSectionCode))
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    if (string.IsNullOrEmpty(code))
                                    {
                                        e.NextCtrl = this.BfSectionGuide_Button;
                                    }
                                    else
                                    {
                                        if (this.tEdit_BfCustRateGrpCode.Enabled)
                                        {
                                            e.NextCtrl = this.tEdit_BfCustRateGrpCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_BfCustomerCode;
                                        }
                                    }
                                }

                                break;
                            }
                            else
                            {
                                // ���͖���
                                if (string.IsNullOrEmpty(this.tEdit_BfSectionCode.Text.Trim()))
                                {
                                    // �ݒ�l�ۑ��A���̂̃N���A
                                    stockQuoteData.BfSectionCode = string.Empty;
                                    stockQuoteData.BfSectionName = string.Empty;

                                    // �t�H�[�J�X�ݒ�
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.BfSectionGuide_Button;
                                    }

                                    break;
                                }

                                if (!string.IsNullOrEmpty(GetSectionName(code)))
                                {
                                    // ���ʂ���ʂɐݒ�
                                    stockQuoteData.BfSectionCode = code;
                                    stockQuoteData.BfSectionName = GetSectionName(code);
                                }
                                else
                                {
                                    // �Y���Ȃ�
                                    TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                                    emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                                    this.Name,											// �A�Z���u��ID
                                                    "�}�X�^�ɑ��݂��܂���B", // �\�����郁�b�Z�[�W
                                                    -1,													// �X�e�[�^�X�l
                                                    MessageBoxButtons.OK);           					// �\������{�^��
                                    // ��ʕ\��
                                    this.SetDisplay(stockQuoteData);
                                    // �� 2009.07.07 ���m modify PVCS NO.307
                                    // �t�H�[�J�X�ݒ�
                                    // e.NextCtrl = this.BfSectionGuide_Button;
                                    e.NextCtrl = e.PrevCtrl;
                                    // �� 2009.07.07 ���m
                                    return;
                                }

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    if (this.tEdit_BfCustRateGrpCode.Enabled)
                                    {
                                        e.NextCtrl = this.tEdit_BfCustRateGrpCode;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tNedit_BfCustomerCode;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // ���͕ύX�Ȃ�
                            if (code.Equals(stockQuoteData.BfSectionCode))
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.UpdateDistinction_tComEditor;
                                }

                                break;
                            }
                            else
                            {
                                // ���͖���
                                if (string.IsNullOrEmpty(this.tEdit_BfSectionCode.Text.Trim()))
                                {
                                    // �ݒ�l�ۑ��A���̂̃N���A
                                    stockQuoteData.BfSectionCode = string.Empty;
                                    stockQuoteData.BfSectionName = string.Empty;

                                    // �t�H�[�J�X�ݒ�
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.UpdateDistinction_tComEditor;
                                    }

                                    break;
                                }

                                if (!string.IsNullOrEmpty(GetSectionName(code)))
                                {
                                    // ���ʂ���ʂɐݒ�
                                    stockQuoteData.BfSectionCode = code;
                                    stockQuoteData.BfSectionName = GetSectionName(code);
                                }
                                else
                                {
                                    // �Y���Ȃ�
                                    TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                                    emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                                    this.Name,											// �A�Z���u��ID
                                                    "�}�X�^�ɑ��݂��܂���B", // �\�����郁�b�Z�[�W
                                                    -1,													// �X�e�[�^�X�l
                                                    MessageBoxButtons.OK);           					// �\������{�^��
                                    // ��ʕ\��
                                    this.SetDisplay(stockQuoteData);
                                    // �� 2009.07.07 ���m modify PVCS NO.307
                                    // �t�H�[�J�X�ݒ�
                                    // e.NextCtrl = this.BfSectionGuide_Button;
                                    e.NextCtrl = e.PrevCtrl;
                                    // �� 2009.07.07 ���m
                                    return;
                                }

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.UpdateDistinction_tComEditor;
                                }
                            }
                        }

                        break;
                    }
                // ���p�����_�{�^��
                case "BfSectionGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                if (this.tEdit_BfCustRateGrpCode.Enabled)
                                {
                                    e.NextCtrl = this.tEdit_BfCustRateGrpCode;
                                }
                                else
                                {
                                    e.NextCtrl = this.tNedit_BfCustomerCode;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.tEdit_BfSectionCode;
                            }
                        }
                        break;
                    }
                // ���p�����Ӑ�|���O���[�v
                case "tEdit_BfCustRateGrpCode":
                    {
                        if (_custRateGrpDic == null)
                        {
                            GetCustRateGrp();
                        }

                        string value = this.tEdit_BfCustRateGrpCode.Text.Trim();
                        // ���͐��m�����f
                        bool inputFlg = true;
                        for (int i = 0; i < value.Length; i++)
                        {
                            if (!char.IsNumber(value, i))
                            {
                                inputFlg = false;
                                break;
                            }
                        }

                        if (e.ShiftKey == false)
                        {
                            // ���p�����Ӑ�|���O���[�v
                            if (this.tEdit_BfCustRateGrpCode.DataText.Trim() == "" || !inputFlg)
                            {
                                // �N���A
                                stockQuoteData.BfCustRateGrpCode = 0;
                                stockQuoteData.BfCustRateGrpName = string.Empty;

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // �t�H�[�J�X
                                    e.NextCtrl = this.BfCustRateGrpGuide_Button;
                                }

                                this.SetDisplay(stockQuoteData);

                                this._rateQuoteInputAcs.CacheStockQuoteData(stockQuoteData);

                                this.tEdit_BfCustRateGrpCode.Clear();

                                this.tEdit_BfCustRateGrpCode.DataText = "";

                                return;
                            }

                            reReadFlg = true;

                            // ���̓R�[�h
                            int code = Convert.ToInt32(this.tEdit_BfCustRateGrpCode.Text.ToString());

                            // ���͕ύX�Ȃ�
                            if (code == stockQuoteData.BfCustRateGrpCode && !string.IsNullOrEmpty(stockQuoteData.BfCustRateGrpName))
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    if (code == 0 && string.IsNullOrEmpty(stockQuoteData.BfCustRateGrpName))
                                    {
                                        e.NextCtrl = this.BfCustRateGrpGuide_Button;
                                    }
                                    else
                                    {
                                        if (this.tNedit_BfCustomerCode.Enabled)
                                        {
                                            e.NextCtrl = this.tNedit_BfCustomerCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_AfSectionCode;
                                        }
                                    }
                                }

                                break;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(GetCustRateGrpName(code)))
                                {
                                    // ���ʂ���ʂɐݒ�
                                    stockQuoteData.BfCustRateGrpCode = code;
                                    stockQuoteData.BfCustRateGrpName = GetCustRateGrpName(code);
                                }
                                else
                                {
                                    // �Y���Ȃ�
                                    TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                                    emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                                    this.Name,											// �A�Z���u��ID
                                                    "�}�X�^�ɑ��݂��܂���B", // �\�����郁�b�Z�[�W
                                                    -1,													// �X�e�[�^�X�l
                                                    MessageBoxButtons.OK);           					// �\������{�^��
                                    // ��ʕ\��
                                    this.SetDisplay(stockQuoteData);
                                    // �� 2009.07.07 ���m modify PVCS NO.307
                                    // �t�H�[�J�X�ݒ�
                                    // e.NextCtrl = this.BfCustRateGrpGuide_Button;
                                    e.NextCtrl = e.PrevCtrl;
                                    // �� 2009.07.07 ���m
                                    return;
                                }

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tEdit_AfSectionCode;
                                }
                            }
                        }
                        else
                        {
                            // ���p�����Ӑ�|���O���[�v
                            if (this.tEdit_BfCustRateGrpCode.DataText.Trim() == "" || !inputFlg)
                            {
                                // �N���A
                                stockQuoteData.BfCustRateGrpCode = 0;
                                stockQuoteData.BfCustRateGrpName = string.Empty;

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // �t�H�[�J�X
                                    e.NextCtrl = this.tEdit_BfSectionCode;
                                }

                                this.SetDisplay(stockQuoteData);

                                this._rateQuoteInputAcs.CacheStockQuoteData(stockQuoteData);

                                this.tEdit_BfCustRateGrpCode.Clear();

                                this.tEdit_BfCustRateGrpCode.DataText = "";

                                return;
                            }

                            reReadFlg = true;

                            // ���̓R�[�h
                            int code = Convert.ToInt32(this.tEdit_BfCustRateGrpCode.Text.ToString());

                            // ���͕ύX�Ȃ�
                            if (code == stockQuoteData.BfCustRateGrpCode && !string.IsNullOrEmpty(stockQuoteData.BfCustRateGrpName))
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tEdit_BfSectionCode;
                                }

                                break;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(GetCustRateGrpName(code)))
                                {
                                    // ���ʂ���ʂɐݒ�
                                    stockQuoteData.BfCustRateGrpCode = code;
                                    stockQuoteData.BfCustRateGrpName = GetCustRateGrpName(code);
                                }
                                else
                                {
                                    // �Y���Ȃ�
                                    TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                                    emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                                    this.Name,											// �A�Z���u��ID
                                                    "�}�X�^�ɑ��݂��܂���B", // �\�����郁�b�Z�[�W
                                                    -1,													// �X�e�[�^�X�l
                                                    MessageBoxButtons.OK);           					// �\������{�^��
                                    // ��ʕ\��
                                    this.SetDisplay(stockQuoteData);
                                    // �� 2009.07.07 ���m modify PVCS NO.307
                                    // �t�H�[�J�X�ݒ�
                                    // e.NextCtrl = this.BfCustRateGrpGuide_Button;
                                    e.NextCtrl = e.PrevCtrl;
                                    // �� 2009.07.07 ���m
                                    return;
                                }

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tEdit_BfSectionCode;
                                }
                            }
                        }


                        break;
                    }
                // ���p�����Ӑ�|���O���[�v
                case "BfCustRateGrpGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                if (this.tNedit_BfCustomerCode.Enabled)
                                {
                                    e.NextCtrl = this.tNedit_BfCustomerCode;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_AfSectionCode;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.tEdit_BfCustRateGrpCode;
                            }
                        }
                        break;
                    }
                // ���p�����Ӑ�R�[�h
                case "tNedit_BfCustomerCode":
                    {
                        // ���Ӑ挟��
                        if (_customerSearchRetDic == null)
                        {
                            LoadCustomerSearchRet();
                        }

                        // ���̓R�[�h
                        int code = this.tNedit_BfCustomerCode.GetInt();

                        if (e.ShiftKey == false)
                        {
                        // ���͕ύX�Ȃ�
                            if (code == stockQuoteData.BfCustomerCode)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    if (code == 0)
                                    {
                                        e.NextCtrl = this.BfCustomerCodeGuide_Button;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_AfSectionCode;
                                    }
                                }

                                break;
                            }
                            else
                            {
                                // ���͖���
                                if (code == 0)
                                {
                                    // �ݒ�l�ۑ��A���̂̃N���A
                                    stockQuoteData.BfCustomerCode = 0;
                                    stockQuoteData.BfCustomerName = string.Empty;

                                    // �t�H�[�J�X�ݒ�
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.BfCustomerCodeGuide_Button;
                                    }

                                    break;
                                }

                                if (!string.IsNullOrEmpty(GetCustomerName(code)))
                                {
                                    // ���ʂ���ʂɐݒ�
                                    stockQuoteData.BfCustomerCode = code;
                                    stockQuoteData.BfCustomerName = GetCustomerName(code);
                                }
                                else
                                {
                                    // �Y���Ȃ�
                                    TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                                    emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                                    this.Name,											// �A�Z���u��ID
                                                    "�}�X�^�ɑ��݂��܂���B", // �\�����郁�b�Z�[�W
                                                    -1,													// �X�e�[�^�X�l
                                                    MessageBoxButtons.OK);           					// �\������{�^��
                                    // ��ʕ\��
                                    this.SetDisplay(stockQuoteData);
                                    // �� 2009.07.07 ���m modify PVCS NO.307
                                    // �t�H�[�J�X�ݒ�
                                    // e.NextCtrl = this.BfCustomerCodeGuide_Button;
                                    e.NextCtrl = e.PrevCtrl;
                                    // �� 2009.07.07 ���m modify
                                    return;
                                }

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tEdit_AfSectionCode;
                                }
                            }
                        }
                        else
                        {
                            if (code == stockQuoteData.BfCustomerCode)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    if (!this.tEdit_BfCustRateGrpCode.Enabled)
                                    {
                                        e.NextCtrl = this.tEdit_BfSectionCode;
                                    }
                                    else
                                    {
                                        if (!string.IsNullOrEmpty(this.tEdit_BfCustRateGrpCode.DataText))
                                        {
                                            e.NextCtrl = this.tEdit_BfCustRateGrpCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.BfCustRateGrpGuide_Button;
                                        }
                                    }
                                }

                                break;
                            }
                            else
                            {
                                // ���͖���
                                if (code == 0)
                                {
                                    // �ݒ�l�ۑ��A���̂̃N���A
                                    stockQuoteData.BfCustomerCode = 0;
                                    stockQuoteData.BfCustomerName = string.Empty;

                                    // �t�H�[�J�X�ݒ�
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        if (!this.tEdit_BfCustRateGrpCode.Enabled)
                                        {
                                            e.NextCtrl = this.tEdit_BfSectionCode;
                                        }
                                        else
                                        {
                                            if (!string.IsNullOrEmpty(this.tEdit_BfCustRateGrpCode.DataText))
                                            {
                                                e.NextCtrl = this.tEdit_BfCustRateGrpCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.BfCustRateGrpGuide_Button;
                                            }
                                        }
                                    }

                                    break;
                                }

                                if (!string.IsNullOrEmpty(GetCustomerName(code)))
                                {
                                    // ���ʂ���ʂɐݒ�
                                    stockQuoteData.BfCustomerCode = code;
                                    stockQuoteData.BfCustomerName = GetCustomerName(code);
                                }
                                else
                                {
                                    // �Y���Ȃ�
                                    TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                                    emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                                    this.Name,											// �A�Z���u��ID
                                                    "�}�X�^�ɑ��݂��܂���B", // �\�����郁�b�Z�[�W
                                                    -1,													// �X�e�[�^�X�l
                                                    MessageBoxButtons.OK);           					// �\������{�^��
                                    // ��ʕ\��
                                    this.SetDisplay(stockQuoteData);
                                    // �� 2009.07.07 ���m modify PVCS NO.307
                                    // �t�H�[�J�X�ݒ�
                                    // e.NextCtrl = this.BfCustomerCodeGuide_Button;
                                    e.NextCtrl = e.PrevCtrl;
                                    // �� 2009.07.07 ���m modify
                                    return;
                                }

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    if (!this.tEdit_BfCustRateGrpCode.Enabled)
                                    {
                                        e.NextCtrl = this.tEdit_BfSectionCode;
                                    }
                                    else
                                    {
                                        if (!string.IsNullOrEmpty(this.tEdit_BfCustRateGrpCode.DataText))
                                        {
                                            e.NextCtrl = this.tEdit_BfCustRateGrpCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.BfCustRateGrpGuide_Button;
                                        }
                                    }
                                }
                            }
                        }

                        break;
                    }
                // ���p�����Ӑ�{�^��
                case "BfCustomerCodeGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.tEdit_AfSectionCode;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.tNedit_BfCustomerCode;
                            }
                        }
                        break;
                    }
                // ���p�拒�_�R�[�h
                case "tEdit_AfSectionCode":
                    {
                        string code = this.tEdit_AfSectionCode.DataText.Trim().PadLeft(2, '0');

                        if (e.ShiftKey == false)
                        {
                            if (string.IsNullOrEmpty(code) || "00".Equals(code))
                            {
                                code = "00";
                                stockQuoteData.AfSectionCode = code;
                                stockQuoteData.AfSectionName = GetSectionName(code);
                            }

                            // ���͕ύX�Ȃ�
                            if (code.Equals(stockQuoteData.AfSectionCode))
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    if (string.IsNullOrEmpty(code))
                                    {
                                        e.NextCtrl = this.AfSectionGuide_Button;
                                    }
                                    else
                                    {
                                        if (this.tEdit_AfCustRateGrpCode.Enabled)
                                        {
                                            e.NextCtrl = this.tEdit_AfCustRateGrpCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_AfCustomerCode;
                                        }
                                    }
                                }

                                break;
                            }
                            else
                            {
                                // ���͖���
                                if (string.IsNullOrEmpty(this.tEdit_AfSectionCode.Text.Trim()))
                                {
                                    // �ݒ�l�ۑ��A���̂̃N���A
                                    stockQuoteData.AfSectionCode = string.Empty;
                                    stockQuoteData.AfSectionName = string.Empty;

                                    // �t�H�[�J�X�ݒ�
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.AfSectionGuide_Button;
                                    }

                                    break;
                                }

                                if (!string.IsNullOrEmpty(GetSectionName(code)))
                                {
                                    // ���ʂ���ʂɐݒ�
                                    stockQuoteData.AfSectionCode = code;
                                    stockQuoteData.AfSectionName = GetSectionName(code);
                                }
                                else
                                {
                                    // �Y���Ȃ�
                                    TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                                    emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                                    this.Name,											// �A�Z���u��ID
                                                    "�}�X�^�ɑ��݂��܂���B", // �\�����郁�b�Z�[�W
                                                    -1,													// �X�e�[�^�X�l
                                                    MessageBoxButtons.OK);           					// �\������{�^��
                                    // ��ʕ\��
                                    this.SetDisplay(stockQuoteData);
                                    // �� 2009.07.07 ���m modify PVCS NO.307
                                    // �t�H�[�J�X�ݒ�
                                    // e.NextCtrl = this.AfSectionGuide_Button;
                                    e.NextCtrl = e.PrevCtrl;
                                    // �� 2009.07.07 ���m modify
                                    return;
                                }

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    if (this.tEdit_AfCustRateGrpCode.Enabled)
                                    {
                                        e.NextCtrl = this.tEdit_AfCustRateGrpCode;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tNedit_AfCustomerCode;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(code))
                            {
                                code = "00";
                                stockQuoteData.AfSectionCode = code;
                                stockQuoteData.AfSectionName = GetSectionName(code);
                            }

                            // ���͕ύX�Ȃ�
                            if (code.Equals(stockQuoteData.AfSectionCode))
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    if (!this.tNedit_BfCustomerCode.Enabled)
                                    {
                                        if (!string.IsNullOrEmpty(this.tEdit_BfCustRateGrpCode.DataText))
                                        {
                                            e.NextCtrl = this.tEdit_BfCustRateGrpCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.BfCustRateGrpGuide_Button;
                                        }
                                    }
                                    else
                                    {
                                        if (this.tNedit_BfCustomerCode.GetInt() != 0)
                                        {
                                            e.NextCtrl = this.tNedit_BfCustomerCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.BfCustomerCodeGuide_Button;
                                        }
                                    }
                                }

                                break;
                            }
                            else
                            {
                                // ���͖���
                                if (string.IsNullOrEmpty(this.tEdit_AfSectionCode.Text.Trim()))
                                {
                                    // �ݒ�l�ۑ��A���̂̃N���A
                                    stockQuoteData.AfSectionCode = string.Empty;
                                    stockQuoteData.AfSectionName = string.Empty;

                                    // �t�H�[�J�X�ݒ�
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        if (!this.tNedit_BfCustomerCode.Enabled)
                                        {
                                            if (!string.IsNullOrEmpty(this.tEdit_BfCustRateGrpCode.DataText))
                                            {
                                                e.NextCtrl = this.tEdit_BfCustRateGrpCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.BfCustRateGrpGuide_Button;
                                            }
                                        }
                                        else
                                        {
                                            if (this.tNedit_BfCustomerCode.GetInt() != 0)
                                            {
                                                e.NextCtrl = this.tNedit_BfCustomerCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.BfCustomerCodeGuide_Button;
                                            }
                                        }
                                    }

                                    break;
                                }

                                if (!string.IsNullOrEmpty(GetSectionName(code)))
                                {
                                    // ���ʂ���ʂɐݒ�
                                    stockQuoteData.AfSectionCode = code;
                                    stockQuoteData.AfSectionName = GetSectionName(code);
                                }
                                else
                                {
                                    // �Y���Ȃ�
                                    TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                                    emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                                    this.Name,											// �A�Z���u��ID
                                                    "�}�X�^�ɑ��݂��܂���B", // �\�����郁�b�Z�[�W
                                                    -1,													// �X�e�[�^�X�l
                                                    MessageBoxButtons.OK);           					// �\������{�^��
                                    // ��ʕ\��
                                    this.SetDisplay(stockQuoteData);
                                    // �� 2009.07.07 ���m modify PVCS NO.307
                                    // �t�H�[�J�X�ݒ�
                                    // e.NextCtrl = this.AfSectionGuide_Button;
                                    e.NextCtrl = e.PrevCtrl;
                                    // �� 2009.07.07 ���m modify
                                    return;
                                }

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    if (!this.tNedit_BfCustomerCode.Enabled)
                                    {
                                        if (!string.IsNullOrEmpty(this.tEdit_BfCustRateGrpCode.DataText))
                                        {
                                            e.NextCtrl = this.tEdit_BfCustRateGrpCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.BfCustRateGrpGuide_Button;
                                        }
                                    }
                                    else
                                    {
                                        if (this.tNedit_BfCustomerCode.GetInt() != 0)
                                        {
                                            e.NextCtrl = this.tNedit_BfCustomerCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.BfCustomerCodeGuide_Button;
                                        }
                                    }
                                }
                            }
                        }

                        break;
                    }
                // ���p�拒�_�{�^��
                case "AfSectionGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                if (this.tEdit_AfCustRateGrpCode.Enabled)
                                {
                                    e.NextCtrl = this.tEdit_AfCustRateGrpCode;
                                }
                                else
                                {
                                    e.NextCtrl = this.tNedit_AfCustomerCode;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.tEdit_AfSectionCode;
                            }
                        }
                        break;
                    }
                // ���p�擾�Ӑ�|���O���[�v
                case "tEdit_AfCustRateGrpCode":
                    {
                        if (_custRateGrpDic == null)
                        {
                            GetCustRateGrp();
                        }

                        string value = this.tEdit_AfCustRateGrpCode.Text.Trim();
                        // ���͐��m�����f
                        bool inputFlg = true;
                        for (int i = 0; i < value.Length; i++)
                        {
                            if (!char.IsNumber(value, i))
                            {
                                inputFlg = false;
                                break;
                            }
                        }

                        if (e.ShiftKey == false)
                        {
                            // ���p�����Ӑ�|���O���[�v
                            if (this.tEdit_AfCustRateGrpCode.DataText.Trim() == "" || !inputFlg)
                            {
                                this.tEdit_AfCustRateGrpCode.Clear();
                                // �N���A
                                stockQuoteData.AfCustRateGrpCode = 0;
                                stockQuoteData.AfCustRateGrpName = string.Empty;

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // �t�H�[�J�X
                                    e.NextCtrl = this.AfCustRateGrpGuide_Button;
                                }

                                this.SetDisplay(stockQuoteData);

                                this._rateQuoteInputAcs.CacheStockQuoteData(stockQuoteData);

                                return;
                            }

                            reReadFlg = true;

                            // ���̓R�[�h
                            int code = Convert.ToInt32(this.tEdit_AfCustRateGrpCode.Text.ToString());

                            // ���͕ύX�Ȃ�
                            if (code == stockQuoteData.AfCustRateGrpCode && !string.IsNullOrEmpty(stockQuoteData.AfCustRateGrpName))
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                        if (code == 0 && string.IsNullOrEmpty(stockQuoteData.AfCustRateGrpName))
                                        {
                                            e.NextCtrl = this.AfCustRateGrpGuide_Button;
                                        }
                                        else
                                        {
                                            if (this.tNedit_AfCustomerCode.Enabled)
                                            {
                                                e.NextCtrl = this.tNedit_AfCustomerCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.ObjectDistinction_tComEditor;
                                            }
                                        }
                                    }
                                }

                                break;
                            }
                            else
                            {

                                if (!string.IsNullOrEmpty(GetCustRateGrpName(code)))
                                {
                                    // ���ʂ���ʂɐݒ�
                                    stockQuoteData.AfCustRateGrpCode = code;
                                    stockQuoteData.AfCustRateGrpName = GetCustRateGrpName(code);
                                }
                                else
                                {
                                    // �Y���Ȃ�
                                    TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                                    emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                                    this.Name,											// �A�Z���u��ID
                                                    "�}�X�^�ɑ��݂��܂���B", // �\�����郁�b�Z�[�W
                                                    -1,													// �X�e�[�^�X�l
                                                    MessageBoxButtons.OK);           					// �\������{�^��
                                    // ��ʕ\��
                                    this.SetDisplay(stockQuoteData);
                                    // �� 2009.07.07 ���m modify PVCS NO.307
                                    // �t�H�[�J�X�ݒ�
                                    // e.NextCtrl = this.AfCustRateGrpGuide_Button;
                                    e.NextCtrl = e.PrevCtrl;
                                    // �� 2009.07.07 ���m
                                    return;
                                }

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.ObjectDistinction_tComEditor;
                                }
                            }
                        }
                        else
                        {
                            // ���p�����Ӑ�|���O���[�v
                            if (this.tEdit_AfCustRateGrpCode.DataText.Trim() == "" || !inputFlg)
                            {
                                this.tEdit_AfCustRateGrpCode.Clear();
                                // �N���A
                                stockQuoteData.AfCustRateGrpCode = 0;
                                stockQuoteData.AfCustRateGrpName = string.Empty;

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // �t�H�[�J�X
                                    e.NextCtrl = this.tEdit_AfSectionCode;
                                }

                                this.SetDisplay(stockQuoteData);

                                this._rateQuoteInputAcs.CacheStockQuoteData(stockQuoteData);

                                return;
                            }

                            reReadFlg = true;

                            // ���̓R�[�h
                            int code = Convert.ToInt32(this.tEdit_AfCustRateGrpCode.Text.ToString());

                            // ���͕ύX�Ȃ�
                            if (code == stockQuoteData.AfCustRateGrpCode && !string.IsNullOrEmpty(stockQuoteData.AfCustRateGrpName))
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.tEdit_AfSectionCode;
                                    }
                                }

                                break;
                            }
                            else
                            {

                                if (!string.IsNullOrEmpty(GetCustRateGrpName(code)))
                                {
                                    // ���ʂ���ʂɐݒ�
                                    stockQuoteData.AfCustRateGrpCode = code;
                                    stockQuoteData.AfCustRateGrpName = GetCustRateGrpName(code);
                                }
                                else
                                {
                                    // �Y���Ȃ�
                                    TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                                    emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                                    this.Name,											// �A�Z���u��ID
                                                    "�}�X�^�ɑ��݂��܂���B", // �\�����郁�b�Z�[�W
                                                    -1,													// �X�e�[�^�X�l
                                                    MessageBoxButtons.OK);           					// �\������{�^��
                                    // ��ʕ\��
                                    this.SetDisplay(stockQuoteData);
                                    // �� 2009.07.07 ���m modify PVCS NO.307
                                    // �t�H�[�J�X�ݒ�
                                    // e.NextCtrl = this.AfCustRateGrpGuide_Button;
                                    e.NextCtrl = e.PrevCtrl;
                                    // �� 2009.07.07 ���m
                                    return;
                                }

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tEdit_AfSectionCode;
                                }
                            }
                        }

                        break;
                    }
                // ���p�����Ӑ�|���O���[�v
                case "AfCustRateGrpGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                if (this.tNedit_AfCustomerCode.Enabled)
                                {
                                    e.NextCtrl = this.tNedit_AfCustomerCode;
                                }
                                else
                                {
                                    e.NextCtrl = this.ObjectDistinction_tComEditor;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.tEdit_AfCustRateGrpCode;
                            }
                        }
                        break;
                    }
                // ���p�擾�Ӑ�R�[�h
                case "tNedit_AfCustomerCode":
                    {
                        // ���Ӑ挟��
                        if (_customerSearchRetDic == null)
                        {
                            LoadCustomerSearchRet();
                        }

                        // ���̓R�[�h
                        int code = this.tNedit_AfCustomerCode.GetInt();

                        if (e.ShiftKey == false)
                        {
                            // ���͕ύX�Ȃ�
                            if (code == stockQuoteData.AfCustomerCode)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    if (code == 0)
                                    {
                                        e.NextCtrl = this.AfCustomerCodeGuide_Button;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.ObjectDistinction_tComEditor;
                                    }
                                }

                                break;
                            }
                            else
                            {
                                // ���͖���
                                if (code == 0)
                                {
                                    // �ݒ�l�ۑ��A���̂̃N���A
                                    stockQuoteData.AfCustomerCode = 0;
                                    stockQuoteData.AfCustomerName = string.Empty;

                                    // �t�H�[�J�X�ݒ�
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.AfCustomerCodeGuide_Button;
                                    }

                                    break;
                                }

                                if (!string.IsNullOrEmpty(GetCustomerName(code)))
                                {
                                    // ���ʂ���ʂɐݒ�
                                    stockQuoteData.AfCustomerCode = code;
                                    stockQuoteData.AfCustomerName = GetCustomerName(code);
                                }
                                else
                                {
                                    // �Y���Ȃ�
                                    TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                                    emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                                    this.Name,											// �A�Z���u��ID
                                                    "�}�X�^�ɑ��݂��܂���B", // �\�����郁�b�Z�[�W
                                                    -1,													// �X�e�[�^�X�l
                                                    MessageBoxButtons.OK);           					// �\������{�^��
                                    // ��ʕ\��
                                    this.SetDisplay(stockQuoteData);
                                    // �� 2009.07.07 ���m modify PVCS NO.307
                                    // �t�H�[�J�X�ݒ�
                                    // e.NextCtrl = this.AfCustomerCodeGuide_Button;
                                    e.NextCtrl = e.PrevCtrl;
                                    // �� 2009.07.07 ���m modify
                                    return;
                                }

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.ObjectDistinction_tComEditor;
                                }
                            }
                        }
                        else
                        {
                            if (code == stockQuoteData.AfCustomerCode)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    if (!this.tEdit_AfCustRateGrpCode.Enabled)
                                    {
                                        e.NextCtrl = this.tEdit_AfSectionCode;
                                    }
                                    else
                                    {
                                        if (string.IsNullOrEmpty(this.tEdit_AfCustRateGrpCode.DataText))
                                        {
                                            e.NextCtrl = this.AfCustRateGrpGuide_Button;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_AfCustRateGrpCode;
                                        }
                                    }
                                }

                                break;
                            }
                            else
                            {
                                // ���͖���
                                if (code == 0)
                                {
                                    // �ݒ�l�ۑ��A���̂̃N���A
                                    stockQuoteData.AfCustomerCode = 0;
                                    stockQuoteData.AfCustomerName = string.Empty;

                                    // �t�H�[�J�X�ݒ�
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        if (this.tEdit_AfCustRateGrpCode.Enabled)
                                        {
                                            if (string.IsNullOrEmpty(this.tEdit_AfCustRateGrpCode.DataText))
                                            {
                                                e.NextCtrl = this.AfCustRateGrpGuide_Button;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_AfCustRateGrpCode;
                                            }
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_AfSectionCode;
                                        }
                                    }

                                    break;
                                }

                                if (!string.IsNullOrEmpty(GetCustomerName(code)))
                                {
                                    // ���ʂ���ʂɐݒ�
                                    stockQuoteData.AfCustomerCode = code;
                                    stockQuoteData.AfCustomerName = GetCustomerName(code);
                                }
                                else
                                {
                                    // �Y���Ȃ�
                                    TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                                    emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                                    this.Name,											// �A�Z���u��ID
                                                    "�}�X�^�ɑ��݂��܂���B", // �\�����郁�b�Z�[�W
                                                    -1,													// �X�e�[�^�X�l
                                                    MessageBoxButtons.OK);           					// �\������{�^��
                                    // ��ʕ\��
                                    // �� 2009.07.07 ���m modify PVCS NO.307
                                    this.SetDisplay(stockQuoteData);
                                    // �t�H�[�J�X�ݒ�
                                    // e.NextCtrl = this.AfCustomerCodeGuide_Button;
                                    e.NextCtrl = e.PrevCtrl;
                                    // �� 2009.07.07 ���m modify
                                    return;
                                }

                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    if (this.tEdit_AfCustRateGrpCode.Enabled)
                                    {
                                        if (string.IsNullOrEmpty(this.tEdit_AfCustRateGrpCode.DataText))
                                        {
                                            e.NextCtrl = this.AfCustRateGrpGuide_Button;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_AfCustRateGrpCode;
                                        }
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_AfSectionCode;
                                    }
                                }
                            }
                        }

                        break;
                    }
                // ���p�擾�Ӑ�{�^��
                case "AfCustomerCodeGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.ObjectDistinction_tComEditor;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.tNedit_AfCustomerCode;
                            }
                        }
                        break;
                    }
                // �Ώۋ敪
                case "ObjectDistinction_tComEditor":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.UpdateDistinction_tComEditor;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                if (this.tNedit_AfCustomerCode.Enabled)
                                {
                                    if (this.tNedit_AfCustomerCode.GetInt() != 0)
                                    {
                                        e.NextCtrl = this.tNedit_AfCustomerCode;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.AfCustomerCodeGuide_Button;
                                    }
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(this.tEdit_AfCustRateGrpCode.DataText))
                                    {
                                        e.NextCtrl = this.tEdit_AfCustRateGrpCode;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.AfCustRateGrpGuide_Button;
                                    }
                                }
                            }
                        }
                        break;
                    }
                // �X�V�敪
                case "UpdateDistinction_tComEditor":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.tEdit_BfSectionCode;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.ObjectDistinction_tComEditor;
                            }
                        }
                        break;
                    }
            }

            // ��������̓��e�Ɣ�r����
            ArrayList arRetList = stockQuoteData.Compare(stockQuoteDataCurrent);

            if (arRetList.Count > 0 || reReadFlg)
            {
                this._rateQuoteInputAcs.CacheStockQuoteData(stockQuoteData);

                // ��ʕ\��
                this.SetDisplay(stockQuoteData);
            }
        }

        /// <summary>
        /// Control.Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void BfCustRateGrpGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_custRateGrpDic == null)
                {
                    GetCustRateGrp();
                }

                // �L���b�V������
                StockQuoteData stockQuoteData = this._rateQuoteInputAcs.StockQuoteData;

                int status;

                UserGdHd userGdHd;
                UserGdBd userGdBd;

                status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 43);
                if (status == 0)
                {
                    stockQuoteData.BfCustRateGrpCode = userGdBd.GuideCode;
                    stockQuoteData.BfCustRateGrpName = this.GetCustRateGrpName(userGdBd.GuideCode);

                    // �t�H�[�J�X�ݒ�
                    this.tEdit_AfSectionCode.Focus();

                    // ��ʍĕ\��
                    this.SetDisplay(stockQuoteData);

                    // �L���b�V������
                    this._rateQuoteInputAcs.CacheStockQuoteData(stockQuoteData);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void BfSectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �L���b�V������
                StockQuoteData stockQuoteData = this._rateQuoteInputAcs.StockQuoteData;

                int status;
                SecInfoSet secInfoSet = new SecInfoSet();

                // ���_�K�C�h�\��
                status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == 0)
                {
                    if (secInfoSet.SectionCode.Trim() != stockQuoteData.BfSectionCode)
                    {
                        // ���_�R�[�h
                        stockQuoteData.BfSectionCode = secInfoSet.SectionCode.Trim();

                        // ���_����
                        stockQuoteData.BfSectionName = secInfoSet.SectionGuideNm.Trim();

                        // ��ʍĕ\��
                        this.SetDisplay(stockQuoteData);

                        // �L���b�V������
                        this._rateQuoteInputAcs.CacheStockQuoteData(stockQuoteData);
                    }

                    // �t�H�[�J�X�ݒ�
                    if (this.tEdit_BfCustRateGrpCode.Enabled)
                    {
                        this.tEdit_BfCustRateGrpCode.Focus();
                    }
                    else
                    {
                        this.tNedit_BfCustomerCode.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        /// <summary>
        /// Control.Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void BfCustomerNameGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // ���Ӑ挟��
                if (_customerSearchRetDic == null)
                {
                    LoadCustomerSearchRet();
                }

                BfFocusFlg = false;

                // ���Ӑ�K�C�h
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.BfCustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                if (BfFocusFlg)
                {
                    // �t�H�[�J�X�ݒ�
                    this.tEdit_AfSectionCode.Focus();
                }

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void BfCustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            BfFocusFlg = true;

            // �L���b�V������
            StockQuoteData stockQuoteData = this._rateQuoteInputAcs.StockQuoteData;

            if (customerSearchRet.CustomerCode != stockQuoteData.BfCustomerCode)
            {
                // ���Ӑ�R�[�h
                stockQuoteData.BfCustomerCode = customerSearchRet.CustomerCode;

                // ���Ӑ於��
                stockQuoteData.BfCustomerName = customerSearchRet.Snm.Trim();

                // ��ʍĕ\��
                this.SetDisplay(stockQuoteData);

                // �L���b�V������
                this._rateQuoteInputAcs.CacheStockQuoteData(stockQuoteData);
            }
        }


        /// <summary>
        /// Control.Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void AfSectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �L���b�V������
                StockQuoteData stockQuoteData = this._rateQuoteInputAcs.StockQuoteData;

                int status;
                SecInfoSet secInfoSet = new SecInfoSet();

                // ���_�K�C�h�\��
                status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == 0)
                {
                    if (secInfoSet.SectionCode.Trim() != stockQuoteData.AfSectionCode)
                    {
                        // ���_�R�[�h
                        stockQuoteData.AfSectionCode = secInfoSet.SectionCode.Trim();

                        // ���_����
                        stockQuoteData.AfSectionName = secInfoSet.SectionGuideNm.Trim();

                        // ��ʍĕ\��
                        this.SetDisplay(stockQuoteData);

                        // �L���b�V������
                        this._rateQuoteInputAcs.CacheStockQuoteData(stockQuoteData);
                    }

                    // �t�H�[�J�X�ݒ�
                    if (this.tEdit_AfCustRateGrpCode.Enabled)
                    {
                        this.tEdit_AfCustRateGrpCode.Focus();
                    }
                    else
                    {
                        this.tNedit_AfCustomerCode.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        /// <summary>
        /// Control.Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void AfCustRateGrpGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_custRateGrpDic == null)
                {
                    GetCustRateGrp();
                }

                // �L���b�V������
                StockQuoteData stockQuoteData = this._rateQuoteInputAcs.StockQuoteData;

                int status;

                UserGdHd userGdHd;
                UserGdBd userGdBd;

                status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 43);
                if (status == 0)
                {
                    stockQuoteData.AfCustRateGrpCode = userGdBd.GuideCode;
                    stockQuoteData.AfCustRateGrpName = this.GetCustRateGrpName(userGdBd.GuideCode);

                    // �t�H�[�J�X�ݒ�
                    this.ObjectDistinction_tComEditor.Focus();

                    // ��ʍĕ\��
                    this.SetDisplay(stockQuoteData);

                    // �L���b�V������
                    this._rateQuoteInputAcs.CacheStockQuoteData(stockQuoteData);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void AfCustomerNameGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // ���Ӑ挟��
                if (_customerSearchRetDic == null)
                {
                    LoadCustomerSearchRet();
                }

                AfFocusFlg = false;

                // ���Ӑ�K�C�h
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.AfCustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                if (AfFocusFlg)
                {
                    // �t�H�[�J�X�ݒ�
                    this.ObjectDistinction_tComEditor.Focus();
                }

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void AfCustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            AfFocusFlg = true;

            // �L���b�V������
            StockQuoteData stockQuoteData = this._rateQuoteInputAcs.StockQuoteData;

            if (customerSearchRet.CustomerCode != stockQuoteData.AfCustomerCode)
            {
                // ���Ӑ�R�[�h
                stockQuoteData.AfCustomerCode = customerSearchRet.CustomerCode;

                // ���Ӑ於��
                stockQuoteData.AfCustomerName = customerSearchRet.Snm.Trim();

                // ��ʍĕ\��
                this.SetDisplay(stockQuoteData);

                // �L���b�V������
                this._rateQuoteInputAcs.CacheStockQuoteData(stockQuoteData);
            }
        }

        /// <summary>
        /// �t�H�[�J�X�ݒ�
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void timer_SetFocus_Tick(object sender, EventArgs e)
        {
            // �t�H�[�J�X�ݒ�
            this.tEdit_BfSectionCode.Focus();

            this.timer_SetFocus.Enabled = false;
        }

        /// <summary>
        /// �Ώۋ敪�ݒ�
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void ObjectDistinction_tComEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this.ObjectDistinction_tComEditor.Value != null)
            {
                // �L���b�V������
                StockQuoteData stockQuoteData = this._rateQuoteInputAcs.StockQuoteData;

                // ��ʒl
                stockQuoteData.ObjectDistinctionCode = (int)this.ObjectDistinction_tComEditor.Value;

                this._rateQuoteInputAcs.CacheStockQuoteData(stockQuoteData);
            }
        }

        /// <summary>
        /// �X�V�敪�ݒ�
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void UpdateDistinction_tComEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this.UpdateDistinction_tComEditor.Value != null)
            {
                // �L���b�V������
                StockQuoteData stockQuoteData = this._rateQuoteInputAcs.StockQuoteData;

                // ��ʒl
                stockQuoteData.UpdateDistinctionCode = (int)this.UpdateDistinction_tComEditor.Value;

                this._rateQuoteInputAcs.CacheStockQuoteData(stockQuoteData);
            }
        }

        /// <summary>
        /// ���Ӑ�|���O���[�v�ݒ�
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void tEdit_AfCustRateGrpCode_Enter(object sender, EventArgs e)
        {
            if (!_setDisplayFlg)
            {
                if (this.tEdit_AfCustRateGrpCode.DataText == "")
                {
                    return;
                }

                int code = Convert.ToInt32(this.tEdit_AfCustRateGrpCode.DataText.ToString());

                this.tEdit_AfCustRateGrpCode.DataText = code.ToString();
            }
        }

        /// <summary>
        /// ���Ӑ�|���O���[�v�ݒ�
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void tEdit_BfCustRateGrpCode_Enter(object sender, EventArgs e)
        {
            if (!_setDisplayFlg)
            {
                if (this.tEdit_BfCustRateGrpCode.DataText == "")
                {
                    return;
                }

                int code = Convert.ToInt32(this.tEdit_BfCustRateGrpCode.DataText.ToString());

                this.tEdit_BfCustRateGrpCode.DataText = code.ToString();
            }
        }
        #endregion

        private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "BfSettingGroup") ||
                (e.Group.Key == "AfSettingGroup") ||
                (e.Group.Key == "DetailSettingGroup") ||
                (e.Group.Key == "ResultSettingGroup"))
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
        }

        private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "BfSettingGroup") ||
                (e.Group.Key == "AfSettingGroup") ||
                (e.Group.Key == "DetailSettingGroup") ||
                (e.Group.Key == "ResultSettingGroup"))
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
        }
    }
}