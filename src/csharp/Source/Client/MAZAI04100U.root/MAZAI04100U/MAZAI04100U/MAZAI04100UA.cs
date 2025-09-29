//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �݌Ɉړ�����
// �v���O�����T�v   : �݌Ɉړ��̊e�q��ʂ𐧌䂷�郁�C���t���[���ł��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 20008 �ɓ� �L
// �� �� ��  2007/01/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018 ��� ���b
// �C �� ��  2007/09/05  �C�����e : ����.NS�p�ɕύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30414 �E �K�j
// �C �� ��  2008/07/14  �C�����e : Partsman�p�ɕύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/06/04  �C�����e : �ړ��f�[�^���_�Ǘ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/06/23  �C�����e : �s��Ή�[13614]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���X�� ��
// �C �� ��  2009.07.07  �C�����e : MANTIS[0013679]�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30434 �H��
// �� �� ��  2010/06/10  �C�����e : �ړ��`�[��[���s����]�I�v�V�����̏����l��ݒ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H���@�b�D
// �C �� ��  2010/06/11  �C�����e : ���׎���̊m�F��1�񂾂�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H���@�b�D
// �C �� ��  2010/06/15  �C�����e : MANTIS�Ή�[15317]�F�ۑ����[�ŐV���]�{�^���𑀍�\��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2010/11/15  �C�����e : ��Q���ǑΉ��u�T�C�U�C�V�v�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : tianjw
// �C �� ��  2010/11/15  �C�����e : ��Q���ǑΉ��u3�v�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : liyp
// �C �� ��  2010/11/15  �C�����e : MANTIS�Ή�[15617]�F���׏�����̊m�F���b�Z�[�W�̕ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2010/12/09  �C�����e : �V�K���͎��ŁA�ۑ����s��Ɂu�V�K�{�^���v�������̃��b�Z�[�W�̗L�����f�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : tianjw
// �C �� ��  2011/05/10  �C�����e : redmine #20901
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �C �� �� K2013/09/11  �C�����e : �t�^�o�ʑΉ�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinTabControl;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Application.Controller.Facade;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �݌Ɉړ����̓��C���t���[��
	/// </summary>
	/// <remarks>
	/// <br>Note       : �݌Ɉړ��̊e�q��ʂ𐧌䂷�郁�C���t���[���ł��B</br>br>
	/// <br>Programer  : 20008 �ɓ� �L</br>
	/// <br>Date       : 2007.01.23<br/>
    /// <br>Note       : ����.NS�p�ɕύX</br>
    /// <br>Programer  : 22018 ��� ���b</br>
    /// <br>Date       : 2007.09.05</br>
    /// <br>Update Date: 2008/07/14 30414 �E �K�j</br>
    /// <br>           : Partsman�p�ɕύX</br>
    /// <br>           : 2009/06/04 �Ɠc �M�u�@�ړ��f�[�^���_�Ǘ��Ή�</br>
    /// <br>           : 2009/06/23 �Ɠc �M�u�@�s��Ή�[13614]</br>
    /// <br>           : 2009.07.07 ���X�� ���@MANTIS�Ή�[0013679]</br>
    /// <br>           : 2010/11/15 ������ ��Q���ǑΉ��u�T�C�U�C�V�v�̑Ή�</br>
    /// <br>           : 2010/11/15 tianjw ��Q���ǑΉ��u3�v�̑Ή�</br>
    /// <br>           : 2010/12/09 ������ �V�K���͎��ŁA�ۑ����s��Ɂu�V�K�{�^���v�������̃��b�Z�[�W�̗L�����f�ǉ�</br>
    /// <br>Update Date: K2013/09/11 �c����</br>
    /// <br>           : �t�^�o�ʑΉ�</br>
    /// <br>           : �e�L�X�g�ϊ���̃f�[�^���C���E�폜�s�Ƃ���B</br>
    /// </remarks>
    public partial class MAZAI04100UA : Form
    {
        //----------------------------------------------------------------------------------------------------
        //  �R���X�g���N�^
        //----------------------------------------------------------------------------------------------------
        # region �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public MAZAI04100UA()
        {
            InitializeComponent();

            // �X�L���C���X�^���X�̐���
            _controlScreenSkin = new ControlScreenSkin();

            // �C���[�W�C���X�^���X�̐���
            this._imageList16 = IconResourceManagement.ImageList16;

            // �{�^���C���X�^���X�̐���
            this._closeButton = (ButtonTool)this.ToolbarsManager_Main.Tools["ButtonTool_Close"];
            this._saveButton = (ButtonTool)this.ToolbarsManager_Main.Tools["ButtonTool_Save"];
            this._newButton = (ButtonTool)this.ToolbarsManager_Main.Tools["ButtonTool_New"];
            this._deleteButton = (ButtonTool)this.ToolbarsManager_Main.Tools["ButtonTool_Delete"];
            this._loadButton = (ButtonTool)this.ToolbarsManager_Main.Tools["ButtonTool_Load"];
            this._renewalButton = (ButtonTool)this.ToolbarsManager_Main.Tools["ButtonTool_Renewal"];

            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
            this._outPutButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.ToolbarsManager_Main.Tools["ButtonTool_OutPut"];
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

            this._retryButton = (ButtonTool)this.ToolbarsManager_Main.Tools["ButtonTool_undo"];
            this._StockMoveInputButton = (ButtonTool)this.ToolbarsManager_Main.Tools["ButtonTool_StockMove"];
            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
            this._StockMoveFixInputButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.ToolbarsManager_Main.Tools["ButtonTool_StockDecision"];
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
            this._StockMoveArrivalGoodsInputButton = (ButtonTool)this.ToolbarsManager_Main.Tools["ButtonTool_StockArrivalGoods"];
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._setupButton = (ButtonTool)this.ToolbarsManager_Main.Tools["ButtonTool_Setup"];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            this._sectionTitleLabel = (LabelTool)this.ToolbarsManager_Main.Tools["LabelTool_SectionTitle"];
            this._sectionLabel = (LabelTool)this.ToolbarsManager_Main.Tools["LabelTool_Section"];
            this._loginEmployeeLabel = (LabelTool)this.ToolbarsManager_Main.Tools["LabelTool_LoginNameTitle"];
            this._loginEmployeeName = (LabelTool)this.ToolbarsManager_Main.Tools["LabelTool_LoginName"];

            // �t���[������Ăяo�����e�q��ʂ̃C���X�^���X�̐���
            this._StockMoveInput = new MAZAI04120UA();

            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
            // ���_�R�[�h�ύX�C�x���g�o�^
            _StockMoveInput.SectionChange += new EventHandler( StockMoveInput_SectionChange );
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

            this._StockMoveInputAcs = StockMoveInputAcs.GetInstance();
            this._StockMoveDataTable = _StockMoveInputAcs.StockMoveDataTable;
            
            // �����l���
            _StockMoveInputInitAcs = StockMoveInputInitDataAcs.GetInstance();
            
            // �w�b�_���
            _StockMoveHeader = _StockMoveInputInitAcs.StockMoveHeader;

            // �e�[�u�����
            _StockMoveDataTable = _StockMoveInputAcs.StockMoveDataTable;

            // �����f�[�^�擾����
            this._StockMoveInputInitAcs.ReadInitData(LoginInfoAcquisition.EnterpriseCode);

            //this._StockMoveFixInput = new MAZAI04128UA();
            //this._StockMoveArrivalGoodsInput = new MAZAI04129UA();
            _sectionLabel.SharedProps.Caption = _StockMoveInputInitAcs.GetSectionName( LoginInfoAcquisition.Employee.BelongSectionCode );

            // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
            this._StockMoveInput.enterGoodsNoColumn += new MAZAI04120UA.EnterGoodsNoColumnEventHandler(this.EnterGoodsNoColumn);
            this._StockMoveInput.changeFocusFooter += new MAZAI04120UA.ChangeFocusFooterEventHandler(this.ChangeFocusFooter);
            this._StockMoveInput.loadSlipGuide += new MAZAI04120UA.LoadSlipGuideEventHandler(this.SlipLoad);
            this._StockMoveInput.setSlipInfo += new MAZAI04120UA.SetSlipInfoEventHandler(this.SetDisplay);
            // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<
            // 2009.04.02 30413 ���� �ۑ��p�C�x���g�ǉ� >>>>>>START
            this._StockMoveInput.save += new MAZAI04120UA.SaveEventHandler(Save);
            // 2009.04.02 30413 ���� �ۑ��p�C�x���g�ǉ� <<<<<<END
        }
        # endregion

        //----------------------------------------------------------------------------------------------------
        //  �v���C�x�C�g�����o
        //----------------------------------------------------------------------------------------------------
        # region �v���C�x�C�g�����o

        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin;

        // �݌Ɉړ����͉��
        private MAZAI04120UA _StockMoveInput;
        private StockMoveInputDataSet.StockMoveDataTable _StockMoveDataTable;
        private StockMoveInputAcs _StockMoveInputAcs;

        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        // �݌Ɋm�菈�����͉��
        private MAZAI04128UA _StockMoveFixInput;
        //private MAZAI04128UB _StockMoveFixInputGrid;
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

        // �݌Ɉړ����׏������͉��
        private MAZAI04129UA _StockMoveArrivalGoodsInput;
        //private MAZAI04129UB _StockMoveArrivalGoodsInputGrid;

        // �����l���
        private StockMoveInputInitDataAcs _StockMoveInputInitAcs;

        //----- ADD K2013/09/11 �c���� ---------->>>>>
        /// <summary>�t�^�o�o�͍ϓ`�[����i�ʁj</summary>
        private int _opt_FutabaCtrl;
        //----- ADD K2013/09/11 �c���� ----------<<<<<

        // �w�b�_���
        private StockMoveHeader _StockMoveHeader;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        // �c�[���o�[�L���v�V�����ݒ�
        private ToolBarCaptionAcs _toolBarCaptionAcs;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        private ImageList _imageList16 = null;				    // �C���[�W���X�g
        private ButtonTool _closeButton;			            // �I���{�^��
        private ButtonTool _saveButton;			                // �ۑ��{�^��
        private ButtonTool _retryButton;			            // ���ɖ߂��{�^��
        private ButtonTool _newButton;			                // �V�K�{�^��
        private ButtonTool _deleteButton;			            // �`�[�폜�{�^��
        private ButtonTool _loadButton;			                // �`�[�ďo�{�^��
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        private Infragistics.Win.UltraWinToolbars.ButtonTool _outPutButton;                     // �`�[�o�̓{�^��
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        //private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;			        // �K�C�h�{�^��
        private ButtonTool _StockMoveInputButton;	            // �o�׏����{�^��
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        private Infragistics.Win.UltraWinToolbars.ButtonTool _StockMoveFixInputButton;	        // �݌Ɉړ��m��{�^��
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        private ButtonTool _StockMoveArrivalGoodsInputButton;	// ���׏����{�^��
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        private ButtonTool _setupButton;                        // �ݒ�{�^��
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        private ButtonTool _renewalButton;

        private LabelTool _sectionTitleLabel;                   // ���_�R�[�h���x��
        private LabelTool _sectionLabel;                        // ���_�����x��
        private LabelTool _loginEmployeeLabel;                  // ���O�C���S���҃��x��
        private LabelTool _loginEmployeeName;                   // ���O�C���S���Җ����x��

        private IOperationAuthority _operationAuthority;    // ���쌠���̐���I�u�W�F�N�g
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        // ����s�t���O(true:���p�� false:���p�s��)
        private bool printCheck = true;

        ///// <summary>OLE�R���g���[�����䕔�i</summary>
        //private OLEPrintController _olePrtController;

        /// <summary>IPrint�C���^�t�F�[�X</summary>
        public SFCMN06002C _sfcmn06002C = new SFCMN06002C();
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        private bool _isNewFlag = false; // �V�K�A�C���t���O�i�ۑ��p�j// ADD 2010/11/15
        # endregion

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �I�y���[�V�����R�[�h
        /// </summary>
        internal enum OperationCode : int
        {
            /// <summary>�C��</summary>
            Revision = 10,
            /// <summary>�폜</summary>
            Delete = 11,
        }

        // ���쌠���̐���I�u�W�F�N�g�ۗ̕L
        /// <summary>
        /// ���쌠���̐���I�u�W�F�N�g���擾���܂��B
        /// </summary>
        /// <value>���쌠���̐���I�u�W�F�N�g</value>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateEntryOperationAuthority("MAZAI04100U", this);
                }
                return _operationAuthority;
            }
        }

        private bool GetOperationAuthority()
        {
            if (MyOpeCtrl.Disabled((int)OperationCode.Revision))
            {
                return (true);
            }

            return (false);
        }

        /// <summary>
        /// ���쌠���̐�����J�n���܂��B
        /// </summary>
        private void BeginControllingByOperationAuthority()
        {
            // �`�[�폜�{�^��
            if (MyOpeCtrl.Disabled((int)OperationCode.Delete))
            {
                ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Visible = false;
                ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Shortcut = Shortcut.None;
            }
        }

        private void SetButtonDispAfterSearchArrival()
        {
            this.ToolbarsManager_Main.Tools["ButtonTool_Undo"].SharedProps.Enabled = true;
        }
        /// <summary>
        /// �O���b�h�i�ԗ�Enter������
        /// </summary>
        /// <param name="goodsNoFlg">�i�ԗ�t���O(True:�i�� False:�i�ԈȊO)</param>
        private void EnterGoodsNoColumn(Boolean goodsNoFlg)
        {
            if (goodsNoFlg == true)
            {
                this.ultraStatusBar1.Panels[0].Text = "�O����v�����F�Ō��*�����[��:A*]";
            }
            else
            {
                this.ultraStatusBar1.Panels[0].Text = "";
            }
        }

        private void ChangeFocusFooter(Boolean changeFlg)
        {
            if (changeFlg == true)
            {
                this._saveButton.SharedProps.Caption = "�ۑ�(F10)";
            }
            else
            {
                this._saveButton.SharedProps.Caption = "�m��(F10)";
            }
        }
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        //----------------------------------------------------------------------------------------------------
        //  �R���g���[���C�x���g�n���h��
        //----------------------------------------------------------------------------------------------------
        # region �R���g���[���C�x���g�n���h��
        /// <summary>
        /// �t�H�[�����[�h�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void MAZAI04100UA_Load(object sender, EventArgs e)
        {
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            this.Panel_Detail.Controls.Add(this._StockMoveInput);
            this._StockMoveInput.Dock = DockStyle.Fill;
            this._StockMoveInput.Visible = true;

            // �{�^�������ݒ菈��
            ButtonInitialSetting();

            BeginControllingByOperationAuthority();

            // ���O�C�����\��
            this._sectionLabel.SharedProps.Caption = _StockMoveInputInitAcs.GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
            this._loginEmployeeName.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;

            // �t�@���N�V�����L�[�Ή�
            this._toolBarCaptionAcs = new ToolBarCaptionAcs();
            this._toolBarCaptionAcs.GetToolbarCaptionsFileInfoList();
        }

        #region DEL 2008/07/14 Partsman�p�ɕύX
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �t�H�[�����[�h�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// Note       : �t�H�[�������[�h���ꂽ���ɔ������܂�<br />
        /// Programer  : 20008 �ɓ� �L<br />
        /// Date       : 2007.01.24<br />
        /// </remarks>
        private void MAZAI04100UA_Load(object sender, EventArgs e)
        {
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();
            
            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            this.Panel_Detail.Controls.Add(this._StockMoveInput);
            this._StockMoveInput.Dock = DockStyle.Fill;
            this._StockMoveInput.Visible = true;

            // ���ɑ��̉�ʂ��\���ɂ���B(��X�̓p�����[�^�ɂ���Đ��䂷��B)
            //this._StockMoveFixInput.Visible = false;
            //this._StockMoveArrivalGoodsInput.Visible = false;

            // �{�^�������ݒ菈��
            this.ButtonInitialSetting();

            // ���O�C�����\��
            _sectionLabel.SharedProps.Caption = _StockMoveInputInitAcs.GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
            _loginEmployeeName.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;

            // OPOS�g�p����
            // �[����POS�ɐݒ肳��Ă���ꍇ�̂Ƃ��̂ݎ��s
            //if (_StockMoveInputInitAcs.POSPCTermCd == 1)
            //{
            //int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// OLEController�̃C���X�^���X����
            //this._olePrtController = new OLEPrintController();
            //try
            //{
            //    #region -- OLEController�̃��[�h���� --
            //    string message = "";
            //    status = this._olePrtController.LoadOleControl(_StockMoveInputInitAcs.POSPCTermCd, ref message);
            //    if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            //    {
            //        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
            //                    "MAZAI04100U",
            //                    "�v�����^�������ɂăG���[���������܂����B\n" + message + "\n",
            //                    status,
            //                    MessageBoxButtons.OK);

            //        TMsgDisp.Show(
            //                this,
            //                emErrorLevel.ERR_LEVEL_INFO,
            //                this.Name,
            //                "�v�����^�̏������Ɏ��s�������߁A�ړ��`�[�͈���ł��܂���B",
            //                -1,
            //                MessageBoxButtons.OK);

            //        this.printCheck = false;
            //        _StockMoveInput.CheckBoxEnableChange();

            //        return;
            //    }
            //    #endregion

            //    #region -- �f�o�C�X�̃I�[�v������ --
            //    status = this._olePrtController.Open(ref message);
            //    if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            //    {
            //        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
            //                    "MAZAI04100U",
            //                    "�v�����^�������ɂăG���[���������܂����B\n" + message,
            //                    status,
            //                    MessageBoxButtons.OK);

            //        TMsgDisp.Show(
            //                this,
            //                emErrorLevel.ERR_LEVEL_INFO,
            //                this.Name,
            //                "�v�����^�̏������Ɏ��s�������߁A�ړ��`�[�͈���ł��܂���B",
            //                -1,
            //                MessageBoxButtons.OK);

            //        this.printCheck = false;
            //        _StockMoveInput.CheckBoxEnableChange();

            //        return;
            //    }
            //    #endregion
            //}
            //catch (Exception ex)
            //{
            //    string msg = ex.Message;
            //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
            //                    "MAZAI04100U",
            //                    "�v�����^�������ɂăG���[���������܂����B\n" + msg + "\n",
            //                    status,
            //                    MessageBoxButtons.OK);

            //    TMsgDisp.Show(
            //            this,
            //            emErrorLevel.ERR_LEVEL_INFO,
            //            this.Name,
            //            "�v�����^�̏������Ɏ��s�������߁A�ړ��`�[�͈���ł��܂���B",
            //            -1,
            //            MessageBoxButtons.OK);

            //    this.printCheck = false;
            //    _StockMoveInput.CheckBoxEnableChange();

            //}

            //..�ۗ��@�`�[�����false�Œ�

            //this.printCheck = false;
            //_StockMoveInput.CheckBoxEnableChange();


            // �t�@���N�V�����L�[�Ή�
            _toolBarCaptionAcs = new ToolBarCaptionAcs();
            _toolBarCaptionAcs.GetToolbarCaptionsFileInfoList();

            this.ReflectSetup();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }

        /// <summary>
        /// �ݒ�t�H�[���ݒ�K�p
        /// </summary>
        private void ReflectSetup ()
        {
            StockMoveInputConstructionAcs stockMoveInputConstructionAcs = new StockMoveInputConstructionAcs();
            int index = stockMoveInputConstructionAcs.FunctionMode;

            // �c�[���o�[�ݒ�
            try
            {
                if ( _toolBarCaptionAcs.DisplayNameList.Count > index )
                {
                    _toolBarCaptionAcs.SettingToolBarCaptions( index, "MAZAI04100UA", ref this.ToolbarsManager_Main );
                }
            }
            catch
            {
                // �ݒ莞�G���[
            }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman�p�ɕύX
        # endregion

        //----------------------------------------------------------------------------------------------------
        //  �v���C�x�[�g���\�b�h
        //----------------------------------------------------------------------------------------------------
        # region �v���C�x�[�g���\�b�h
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        private void ButtonInitialSetting()
        {
            this.ToolbarsManager_Main.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._retryButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;
            this._newButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
            this._deleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            this._loadButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIPSEARCH;
            this._StockMoveInputButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            this._StockMoveArrivalGoodsInputButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            this._renewalButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;

            this._sectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            this._loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            this._setupButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;

            // �{�^������
            if (_StockMoveInput != null)
            {
                StockMoveButtonSettings("ButtonTool_StockMove");
            }
            if (_StockMoveArrivalGoodsInput != null)
            {
                StockMoveButtonSettings("ButtonTool_StockArrivalGoods");
            }
        }

        // ADD 2010/06/10 MANTIS�Ή�[15573]�F�ړ��`�[��[���s����]�I�v�V�����̏����l��ݒ�  ---------->>>>>
        private int _printOutOptionValueBackup = -1;

        private int PrintOutOptionValueBackup
        {
            get { return _printOutOptionValueBackup; }
            set { _printOutOptionValueBackup = value; }
        }
        // ADD 2010/06/10 MANTIS�Ή�[15573]�F�ړ��`�[��[���s����]�I�v�V�����̏����l��ݒ�  ----------<<<<<

        /// <summary>
        /// �݌Ɉړ���ʕ\��
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        private int StockMoveDisplay()
        {
            Boolean successFlg = false;

            //-------------------------------------------------
            // �݌Ɉړ���ʈȊO�̉�ʂ͔�\���ɂ���B
            //-------------------------------------------------

            // ���׏������
            if (_StockMoveArrivalGoodsInput != null)
            {
                successFlg = StockMoveArrivalGoodsInputClose();
                if (successFlg == true)
                {
                    this._StockMoveArrivalGoodsInput = null;
                }
            }

            if (successFlg == true)
            {
                this._StockMoveInput = new MAZAI04120UA();

                this._StockMoveInput.enterGoodsNoColumn += new MAZAI04120UA.EnterGoodsNoColumnEventHandler(EnterGoodsNoColumn);
                this._StockMoveInput.changeFocusFooter += new MAZAI04120UA.ChangeFocusFooterEventHandler(ChangeFocusFooter);
                this._StockMoveInput.loadSlipGuide += new MAZAI04120UA.LoadSlipGuideEventHandler(this.SlipLoad);
                this._StockMoveInput.setSlipInfo += new MAZAI04120UA.SetSlipInfoEventHandler(this.SetDisplay);
                // 2009.04.02 30413 ���� �ۑ��p�C�x���g�ǉ� >>>>>>START
                this._StockMoveInput.save += new MAZAI04120UA.SaveEventHandler(Save);
                // 2009.04.02 30413 ���� �ۑ��p�C�x���g�ǉ� <<<<<<END

                this.Panel_Detail.Controls.Add(this._StockMoveInput);
                this._StockMoveInput.Dock = DockStyle.Fill;
                this._StockMoveInput.DataTableSettings();
                this._StockMoveInput.Visible = true;
                // ADD 2010/06/10 MANTIS�Ή�[15573]�F�ړ��`�[��[���s����]�I�v�V�����̏����l��ݒ�  ---------->>>>>
                this._StockMoveInput.SetPrintOutOptionValue(PrintOutOptionValueBackup);
                // ADD 2010/06/10 MANTIS�Ή�[15573]�F�ړ��`�[��[���s����]�I�v�V�����̏����l��ݒ�  ----------<<<<<

                // �{�^������
                StockMoveButtonSettings("ButtonTool_StockMove");
                this._sectionLabel.SharedProps.Caption = this._StockMoveInputInitAcs.GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
                ChangeFocusFooter(false);
            }

            return 0;
        }

        /// <summary>
        /// �݌Ɉړ����׉�ʕ\��
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        private int StockArrivalGoodsDisplay()
        {
            Boolean successFlg = false;

            ChangeFocusFooter(true);

            //-------------------------------------------------
            // �݌Ɉړ����׉�ʈȊO�̉�ʂ͔�\���ɂ���B
            //-------------------------------------------------

            // �o�׏������
            if (_StockMoveInput != null)
            {
                // ADD 2010/06/10 MANTIS�Ή�[15573]�F�ړ��`�[��[���s����]�I�v�V�����̏����l��ݒ�  ---------->>>>>
                PrintOutOptionValueBackup = this._StockMoveInput.GetPrintOutOptionValue();
                // ADD 2010/06/10 MANTIS�Ή�[15573]�F�ړ��`�[��[���s����]�I�v�V�����̏����l��ݒ�  ----------<<<<<

                successFlg = StockMoveInputClose();
                if (successFlg == true)
                {
                    this._StockMoveInput = null;
                }
            }

            if (successFlg == true)
            {
                this._StockMoveArrivalGoodsInput = new MAZAI04129UA();
                this._StockMoveArrivalGoodsInput.searchAfter += new MAZAI04129UA.SearchAfterEventHandler(SetButtonDispAfterSearchArrival);

                this.Panel_Detail.Controls.Add(this._StockMoveArrivalGoodsInput);
                this._StockMoveArrivalGoodsInput.Dock = DockStyle.Fill;
                this._StockMoveArrivalGoodsInput.DataTableSettings();
                this._StockMoveArrivalGoodsInput.Visible = true;

                // �{�^������
                StockMoveButtonSettings("ButtonTool_StockArrivalGoods");

                this._sectionLabel.SharedProps.Caption = this._StockMoveInputInitAcs.GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
            }
            return 0;
        }

        /// <summary>
        /// �ݒ�t�H�[���\��
        /// </summary>
        private void SetupFormDisplay()
        {
            ArrayList userSettingList;
            this._StockMoveInput.GetUserSetting(out userSettingList);

            // DEL 2010/06/10 MANTIS�Ή�[15573]�F�ړ��`�[��[���s����]�I�v�V�����̏����l��ݒ�  ---------->>>>>
            //StockMoveInputSetUp setupForm = new StockMoveInputSetUp(userSettingList);
            // DEL 2010/06/10 MANTIS�Ή�[15573]�F�ړ��`�[��[���s����]�I�v�V�����̏����l��ݒ�  ----------<<<<<
            // ADD 2010/06/10 MANTIS�Ή�[15573]�F�ړ��`�[��[���s����]�I�v�V�����̏����l��ݒ�  ---------->>>>>
            StockMoveInputSetUp setupForm = new StockMoveInputSetUp(userSettingList, this._StockMoveInput);
            // ADD 2010/06/10 MANTIS�Ή�[15573]�F�ړ��`�[��[���s����]�I�v�V�����̏����l��ݒ�  ----------<<<<<

            DialogResult res = setupForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                userSettingList = setupForm.UserSettingList;
                this._StockMoveInput.SetUserSetting(userSettingList);
                // ----- ADD 2010/11/15 ---------------->>>>>
                // �O���b�h���XML�ۑ�
                this._StockMoveInput.SaveXmlData();
                // ----- ADD 2010/11/15 ----------------<<<<<
            }
        }

        /// <summary>
        /// �݌Ɉړ���ʕ\���{�^������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        private void StockMoveButtonSettings(string displayName)
        {
            switch (displayName)
            {
                case "ButtonTool_StockMove":
                    {
                        this._StockMoveInputInitAcs.ReadStockMngTtlSt();        //ADD 2009/06/04�@�݌ɊǗ��S�̐ݒ�ǂݍ���

                        // ���ݕ\������Ă����ʂ̃{�^�����\���ɂ��A����ȊO��\������B
                        this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                        this.ToolbarsManager_Main.Tools["ButtonTool_StockMove"].SharedProps.Visible = false;
                        //this.ToolbarsManager_Main.Tools["ButtonTool_StockArrivalGoods"].SharedProps.Visible = true;       //DEL 2009/06/04
                        // ---ADD 2009/06/04 --------------------------------------------------------------------->>>>>
                        // ���׏���(F8)�{�^���ݒ�@�݌ɊǗ��S�̐ݒ�̍݌Ɉړ��m��敪�ɏ]��
                        if (this._StockMoveInputInitAcs.StockMoveFixCode == 1)
                        {
                            this.ToolbarsManager_Main.Tools["ButtonTool_StockArrivalGoods"].SharedProps.Visible = true;
                            this.ToolbarsManager_Main.Tools["ButtonTool_StockArrivalGoods"].SharedProps.Enabled = true;     //ADD 2009/06/23 �s��Ή�[13614]  ��\���ł�F8�����őJ�ڂ��Ă��܂���
                        }
                        else
                        {
                            this.ToolbarsManager_Main.Tools["ButtonTool_StockArrivalGoods"].SharedProps.Visible = false;
                            this.ToolbarsManager_Main.Tools["ButtonTool_StockArrivalGoods"].SharedProps.Enabled = false;    //ADD 2009/06/23 �s��Ή�[13614]  ��\���ł�F8�����őJ�ڂ��Ă��܂���
                        }
                        // ---ADD 2009/06/04 ---------------------------------------------------------------------<<<<<

                        // �`�[�ďo�A�폜�A�ݒ�{�^��
                        this.ToolbarsManager_Main.Tools["ButtonTool_Load"].SharedProps.Enabled = true;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Setup"].SharedProps.Enabled = true;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Undo"].SharedProps.Enabled = false;

                        break;
                    }
                case "ButtonTool_StockArrivalGoods":
                    {
                        // ���ݕ\������Ă����ʂ̃{�^�����\���ɂ��A����ȊO��\������B
                        this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                        this.ToolbarsManager_Main.Tools["ButtonTool_StockMove"].SharedProps.Visible = true;
                        this.ToolbarsManager_Main.Tools["ButtonTool_StockArrivalGoods"].SharedProps.Visible = false;

                        // �`�[�ďo�A�폜�A�ݒ�{�^��
                        this.ToolbarsManager_Main.Tools["ButtonTool_Load"].SharedProps.Enabled = false;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Setup"].SharedProps.Enabled = false;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Undo"].SharedProps.Enabled = false;

                        break;
                    }
            }
        }

        #region DEL 2008/07/14 Partsman�p�ɕύX
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        private void ButtonInitialSetting()
        {
            this.ToolbarsManager_Main.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._retryButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;
            this._newButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
            this._deleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            this._loadButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIPSEARCH;
            this._outPutButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINTOUT;
            //this._guideButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            this._StockMoveInputButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            this._StockMoveFixInputButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            this._StockMoveArrivalGoodsInputButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;

            this._sectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            this._loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._setupButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // �ړ��`�[�o�̓{�^��
            this.ToolbarsManager_Main.Tools["ButtonTool_OutPut"].SharedProps.Enabled = false;

            // �{�^������
            //if (_StockMoveInput.Visible == true)
            if (_StockMoveInput != null)
            {
                this.StockMoveButtonSettings("ButtonTool_StockMove");
            }

            //if (_StockMoveFixInput.Visible == true)
            if (_StockMoveFixInput != null)
            {
                this.StockMoveButtonSettings("ButtonTool_StockDecision");
            }

            //if (_StockMoveArrivalGoodsInput.Visible == true)
            if (_StockMoveArrivalGoodsInput != null)
            {
                this.StockMoveButtonSettings("ButtonTool_StockArrivalGoods");
            }
        }

        /// <summary>
        /// �݌Ɉړ���ʕ\��
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// Note       : �݌Ɉړ���ʂ�\�����܂��B<br />
        /// Programer  : 20008 �ɓ� �L<br />
        /// Date       : 2007.01.23<br />
        /// </remarks>
        private int StockMoveDisplay()
        {
            Boolean successFlg = false;

            // �݌Ɉړ���ʈȊO�̉�ʂ͔�\���ɂ���B

            if (_StockMoveFixInput != null)
            {
                successFlg = this.StockMoveInputFixClose();
                if (successFlg == true)
                {
                    this._StockMoveFixInput = null;
                }
            }

            if (_StockMoveArrivalGoodsInput != null)
            {
                successFlg = this.StockMoveArrivalGoodsInputClose();
                if (successFlg == true)
                {
                    this._StockMoveArrivalGoodsInput = null;
                }
            }

            if (successFlg == true)
            {
                _StockMoveInput = new MAZAI04120UA();

                // ���_�R�[�h�ύX�C�x���g�o�^
                _StockMoveInput.SectionChange += new EventHandler( StockMoveInput_SectionChange );

                this.Panel_Detail.Controls.Add(this._StockMoveInput);
                this._StockMoveInput.Dock = DockStyle.Fill;
                _StockMoveInput.DataTableSettings();
                this._StockMoveInput.Visible = true;

                // �{�^������
                this.StockMoveButtonSettings("ButtonTool_StockMove");
                _sectionLabel.SharedProps.Caption = _StockMoveInputInitAcs.GetSectionName( LoginInfoAcquisition.Employee.BelongSectionCode );
            }

            return 0;
        }

        /// <summary>
        /// �݌Ɉړ��m���ʕ\��
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// Note       : �݌Ɉړ��m���ʂ�\�����܂��B<br />
        /// Programer  : 20008 �ɓ� �L<br />
        /// Date       : 2007.01.23<br />
        /// </remarks>
        private int StockDecisionDisplay()
        {
            Boolean successFlg = false;

            // �݌Ɉړ��m���ʈȊO�̉�ʂ͔�\���ɂ���B
            if (_StockMoveInput != null)
            {
                successFlg = this.StockMoveInputClose();
                if (successFlg == true)
                {
                    this._StockMoveInput = null;
                }
            }

            if (_StockMoveArrivalGoodsInput != null)
            {
                successFlg = this.StockMoveArrivalGoodsInputClose();
                if (successFlg == true)
                {
                    this._StockMoveArrivalGoodsInput = null;
                }
            }

            if (successFlg == true)
            {
                // ��ʃC���X�^���X�̐���
                _StockMoveFixInput = new MAZAI04128UA();

                // ���_�ύX�C�x���g
                _StockMoveFixInput.SectionChange += new EventHandler( StockMoveInput_SectionChange );

                this.Panel_Detail.Controls.Add(this._StockMoveFixInput);
                this._StockMoveFixInput.Dock = DockStyle.Fill;
                _StockMoveFixInput.DataTableSettings();
                this._StockMoveFixInput.Visible = true;

                // �{�^������
                this.StockMoveButtonSettings("ButtonTool_StockDecision");

                _sectionLabel.SharedProps.Caption = _StockMoveInputInitAcs.GetSectionName( LoginInfoAcquisition.Employee.BelongSectionCode );
            } 
            return 0;
        }
        
        /// <summary>
        /// �݌Ɉړ����׉�ʕ\��
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// Note       : �݌Ɉړ����׉�ʂ�\�����܂��B<br />
        /// Programer  : 20008 �ɓ� �L<br />
        /// Date       : 2007.01.23<br />
        /// </remarks>
        private int StockArrivalGoodsDisplay()
        {
            Boolean successFlg = false;

            // �݌Ɉړ����׉�ʈȊO�̉�ʂ͔�\���ɂ���B
            if (_StockMoveInput != null)
            {
                successFlg = this.StockMoveInputClose();
                if (successFlg == true)
                {
                    this._StockMoveInput = null;
                }
            }

            if (this._StockMoveFixInput != null)
            {
                successFlg = this.StockMoveInputFixClose();
                if (successFlg == true)
                {
                    this._StockMoveFixInput = null;
                }
            }

            if (successFlg == true)
            {
                _StockMoveArrivalGoodsInput = new MAZAI04129UA();

                _StockMoveArrivalGoodsInput.SectionChange += new EventHandler( StockMoveInput_SectionChange );

                this.Panel_Detail.Controls.Add(this._StockMoveArrivalGoodsInput);
                this._StockMoveArrivalGoodsInput.Dock = DockStyle.Fill;
                _StockMoveArrivalGoodsInput.DataTableSettings();
                this._StockMoveArrivalGoodsInput.Visible = true;

                // �{�^������
                this.StockMoveButtonSettings("ButtonTool_StockArrivalGoods");

                _sectionLabel.SharedProps.Caption = _StockMoveInputInitAcs.GetSectionName( LoginInfoAcquisition.Employee.BelongSectionCode );
            }
            return 0;
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// �ݒ�t�H�[���\��
        /// </summary>
        private void SetupFormDisplay ()
        {
            // �ݒ�t�H�[����\��
            StockMoveInputSetUp setupForm = new StockMoveInputSetUp( _toolBarCaptionAcs.DisplayNameList );
            setupForm.ShowDialog();
            
            // �ݒ���e�����C���t���[���ɓK�p
            this.ReflectSetup();
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        /// <summary>
        /// �݌Ɉړ���ʕ\���{�^������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// Note       : �\������Ă����ʂɂ���ă{�^���̐�����s���܂��B<br />
        /// Programer  : 20008 �ɓ� �L<br />
        /// Date       : 2007.01.23<br />
        /// </remarks>
        private void StockMoveButtonSettings(string displayName)
        {
            switch (displayName)
            {
                case "ButtonTool_StockMove":
                    {
                        // �{�^���̃O���[�v�w�b�_��ύX����B
                        //_StockMoveInputButton.InstanceProps.IsFirstInGroup = false;
                        //_StockMoveFixInputButton.InstanceProps.IsFirstInGroup = true;
                        //_StockMoveArrivalGoodsInputButton.InstanceProps.IsFirstInGroup = false;

                        // ���ݕ\������Ă����ʂ̃{�^�����\���ɂ��A����ȊO��\������B
                        this.ToolbarsManager_Main.Tools["ButtonTool_StockMove"].SharedProps.Enabled = false;
                        this.ToolbarsManager_Main.Tools["ButtonTool_StockDecision"].SharedProps.Enabled = true;
                        this.ToolbarsManager_Main.Tools["ButtonTool_StockArrivalGoods"].SharedProps.Enabled = true;

                        // �`�[�ďo�A�폜�{�^����\��
                        this.ToolbarsManager_Main.Tools["ButtonTool_Load"].SharedProps.Enabled = true;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = true;

                        // �ړ��`�[�o�̓{�^�����\��
                        this.ToolbarsManager_Main.Tools["ButtonTool_OutPut"].SharedProps.Enabled = false;

                        // �ړ��`�[�o�̓��W�I�{�^���\����\��
                        if (this.printCheck == false)
                        {
                            _StockMoveInput.CheckBoxEnableChange();
                        }

                        break;
                    }
                case "ButtonTool_StockDecision":
                    {
                        // �{�^���̃O���[�v�w�b�_��ύX����B
                        //_StockMoveInputButton.InstanceProps.IsFirstInGroup = true;
                        //_StockMoveFixInputButton.InstanceProps.IsFirstInGroup = false;
                        //_StockMoveArrivalGoodsInputButton.InstanceProps.IsFirstInGroup = false;

                        // ���ݕ\������Ă����ʂ̃{�^�����\���ɂ��A����ȊO��\������B
                        this.ToolbarsManager_Main.Tools["ButtonTool_StockMove"].SharedProps.Enabled = true;
                        this.ToolbarsManager_Main.Tools["ButtonTool_StockDecision"].SharedProps.Enabled = false;
                        this.ToolbarsManager_Main.Tools["ButtonTool_StockArrivalGoods"].SharedProps.Enabled = true;

                        // �`�[�ďo�A�폜�{�^�����\��
                        this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Load"].SharedProps.Enabled = false;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;

                        // �ړ��`�[�o�̓{�^�����\��
                        this.ToolbarsManager_Main.Tools["ButtonTool_OutPut"].SharedProps.Enabled = false;

                        break;

                    }
                case "ButtonTool_StockArrivalGoods":
                    {
                        // �{�^���̃O���[�v�w�b�_��ύX����B
                        //_StockMoveInputButton.InstanceProps.IsFirstInGroup = true;
                        //_StockMoveFixInputButton.InstanceProps.IsFirstInGroup = false;
                        //_StockMoveArrivalGoodsInputButton.InstanceProps.IsFirstInGroup = false;

                        // ���ݕ\������Ă����ʂ̃{�^�����\���ɂ��A����ȊO��\������B
                        this.ToolbarsManager_Main.Tools["ButtonTool_StockMove"].SharedProps.Enabled = true;
                        this.ToolbarsManager_Main.Tools["ButtonTool_StockDecision"].SharedProps.Enabled = true;
                        this.ToolbarsManager_Main.Tools["ButtonTool_StockArrivalGoods"].SharedProps.Enabled = false;

                        // �`�[�ďo�A�폜�{�^�����\��
                        this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Load"].SharedProps.Enabled = false;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;

                        // �ړ��`�[�o�̓{�^�����\��
                        this.ToolbarsManager_Main.Tools["ButtonTool_OutPut"].SharedProps.Enabled = false;

                        break;
                    }
            }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman�p�ɕύX

        /// <summary>
        /// �c�[���o�[�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Update Note : 2011/05/10 tianjw redmine #20901</br>
        private void ToolbarsManager_Main_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // �I������
                        this.Close(true);
                        break;
                    }
                case "ButtonTool_New":
                    {
                        // �V�K����
                        New();
                        break;
                    }
                case "ButtonTool_Save":
                    {
                        // ----- ADD 2011/05/10 tianjw ------------------->>>>>
                        if (this._StockMoveArrivalGoodsInput != null)
                        {
                            EventArgs ex = new EventArgs();
                            this._StockMoveArrivalGoodsInput.ArrivalGoodsDay_tDateEdit_Leave(this, ex);
                        }
                        // ----- ADD 2011/05/10 tianjw -------------------<<<<<
                        // �ۑ�����
                        this.Save();

                        break;
                    }
                case "ButtonTool_Undo":
                    {
                        // ���ɖ߂�����
                        this.Retry();

                        break;
                    }
                case "ButtonTool_Load":
                    {
                        // �`�[�敪�u-1:���ڔ�\���A0:�o�ɓ`�[�A1:���ɓ`�[�v(�ۑ������O��A�N���X�ɃZ�b�g����K�v�L��)
                        this._StockMoveInputAcs.SlipDiv = this._StockMoveInput.GetSlipDiv();        //ADD 2009/06/04

                        // �`�[�ďo����
                        this.SlipLoad();

                        break;
                    }
                case "ButtonTool_Delete":
                    {
                        // �`�[�폜����
                        this.Delete();

                        break;
                    }
                /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
                case "ButtonTool_OutPut":
                    {
                        // �ړ��`�[�o��
                        this.SlipOutput();

                        break;
                    }
                   --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
                case "ButtonTool_StockMove":
                    {
                        // �݌Ɉړ���ʕ\������
                        this.StockMoveDisplay();
                        break;
                    }
                /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
                case "ButtonTool_StockDecision":
                    {
                        // �݌Ɉړ��m���ʕ\������
                        this.StockDecisionDisplay();
                        break;
                    }
                   --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
                case "ButtonTool_StockArrivalGoods":
                    {
                        // �݌Ɉړ����׉�ʕ\������
                        this.StockArrivalGoodsDisplay();
                        break;
                    }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                case "ButtonTool_Setup":
                    {
                        // �ݒ�t�h
                        this.SetupFormDisplay();
                        break;
                    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                case "ButtonTool_Renewal":
                    {
                        // �݌Ɉړ����͉�ʂɂčŐV���{�^�����������ꂽ�ꍇ
                        if (this._StockMoveInput != null)
                        {
                            _StockMoveInput.Renewal();
                        }

                        // �݌Ɉړ����ד��͂ɂčŐV���{�^�����������ꂽ�ꍇ
                        if (this._StockMoveArrivalGoodsInput != null)
                        {
                            _StockMoveArrivalGoodsInput.Renewal();
                        }

                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                             "�ŐV�����擾���܂����B",
                                             0,
                                             MessageBoxButtons.OK,
                                             MessageBoxDefaultButton.Button1);
                        break;
                    }
            }
        }

        /// <summary>
        /// ��ʃN���[�Y����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        private void Close(bool boolean)
        {
            Boolean status = false;

            // �݌Ɉړ����͉�ʂɂăN���[�Y�{�^�����������ꂽ�ꍇ
            if (_StockMoveInput != null)
            {
                status = StockMoveInputClose();
            }

            // �݌Ɉړ����ד��͂ɂăN���[�Y�{�^�����������ꂽ�ꍇ
            if (_StockMoveArrivalGoodsInput != null)
            {
                status = StockMoveArrivalGoodsInputClose();
            }

            if (status == true)
            {
                Close();
            }
        }

        /// <summary>
        /// �V�K����
        /// </summary>
        /// <br>Update Note: 2010/12/09 ������ �V�K���͎��ŁA�ۑ����s��Ɂu�V�K�{�^���v�������̃��b�Z�[�W�̗L�����f�ǉ�</br>
        private void New()
        {
            // �݌Ɉړ����͉�ʂɂĐV�K�{�^�����������ꂽ�ꍇ
            if (this._StockMoveInput != null)
            {
                if (!_StockMoveInput.CompareBeforeNewProc())
                {
                    DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                          "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                                                          "������Ԃɖ߂��܂����H",
                                                          0,
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxDefaultButton.Button1);

                    if (res != DialogResult.Yes)
                    {
                        return;
                    }

                    // �c�[���o�[�{�^���̏�����
                    this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                    this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
                    this.ToolbarsManager_Main.Tools["ButtonTool_Undo"].SharedProps.Enabled = false;
                    this.ToolbarsManager_Main.Tools["ButtonTool_Renewal"].SharedProps.Enabled = true;   // TODO:[�ŐV���]�{�^��

                    // �w�b�_�̏����폜
                    this._StockMoveInputInitAcs.StockMoveHeaderClear();
                    this._StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                    // ��ʂ̏�����
                    this._StockMoveInput.HeaderClear();

                    // �f�[�^�e�[�u���̓��e���폜
                    this._StockMoveInput.Clear();
                }
                // ---ADD 2010/12/09------->>>>>
                else
                {
                    if (_isNewFlag)
                    {
                        // �c�[���o�[�{�^���̏�����
                        this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Undo"].SharedProps.Enabled = false;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Renewal"].SharedProps.Enabled = true;

                        // �w�b�_�̏����폜
                        this._StockMoveInputInitAcs.StockMoveHeaderClear();
                        this._StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                        // ��ʂ̏�����
                        this._StockMoveInput.HeaderClear();

                        // �f�[�^�e�[�u���̓��e���폜
                        this._StockMoveInput.Clear();
                        _isNewFlag = false;
                    }
                }
                // ---ADD 2010/12/09-------<<<<<
            }

            // �݌Ɉړ����ד��͂ɂĐV�K�{�^�����������ꂽ�ꍇ
            if (this._StockMoveArrivalGoodsInput != null)
            {
                if (!this._StockMoveArrivalGoodsInput.CompareBeforeNewProc())
                {
                    DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                          "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                                                          "������Ԃɖ߂��܂����H",
                                                          0,
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxDefaultButton.Button1);


                    if (res != DialogResult.Yes)
                    {
                        return;
                    }

                    // �c�[���o�[�{�^���̏�����
                    this.ToolbarsManager_Main.Tools["ButtonTool_Undo"].SharedProps.Enabled = false;

                    // �w�b�_�̏����폜
                    this._StockMoveInputInitAcs.StockMoveHeaderClear();
                    this._StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                    // ��ʂ̏�����
                    this._StockMoveArrivalGoodsInput.HeaderClear();

                    // �f�[�^�e�[�u���̓��e���폜
                    this._StockMoveArrivalGoodsInput.Clear();
                }
            }
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <br>Update Note : 2010/11/15 ������ ��Q���ǑΉ��u�T�C�U�C�V�v�̑Ή�</br>
        private void Save()
        {
            if (this._saveButton.SharedProps.Caption == "�m��(F10)")
            {
                if (this._StockMoveInput.ActiveControl.Parent == this._StockMoveInput.Detail_panel)
                {
                    ChangeFocusFooter(true);
                    this._StockMoveInput.Outline_tEdit.Focus();
                }
                else
                {
                    this._StockMoveInput._stockMoveInput.ReturnKeyDownEnterFocus();
                }
                return;
            }

            DialogResult dr = ShowMessageBox(emErrorLevel.ERR_LEVEL_QUESTION,
                                             "�o�^���Ă���낵���ł����H",
                                             0,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.No)
            {
                return;
            }

            // �݌Ɉړ����͉�ʂɂĕۑ��{�^�����������ꂽ�ꍇ
            if (this._StockMoveInput != null)
            {
                // �O���b�h�ҏW�m��
                this._StockMoveInput.DetailReturnKeyDown();

                // �ۑ�����
                if (StockMoveInputSave() == true)
                {
                    this._StockMoveInput.SetTableUpdateFlg();

                    // �`�[�������
                    if (_StockMoveInput.GetPrintCheck() == true)
                    {
                        this.SlipOutput();
                    }

                    // ---UPD 2010/11/15---------------->>>>>
                    // ��ʂ��N���A
                    //this._StockMoveInput.Clear();

                    // ��ʂ��N���A
                    if (this._isNewFlag == false)
                    {
                        this._StockMoveInput.Clear();
                    }
                    else
                    {
                        this._StockMoveInput.ClearAfterSave();
                    }
                    // ---UPD 2010/11/15----------------<<<<<

                    // �O��`�[�ԍ��ݒ�
                    this._StockMoveInput.SetLastSlipNo(this._StockMoveInputAcs.StockMoveSlipNo);

                    // �폜�{�^���𖳌�
                    this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
                    this.ToolbarsManager_Main.Tools["ButtonTool_Undo"].SharedProps.Enabled = false;

                    // ---UPD 2010/11/15---------------->>>>>
                    // �t�H�[�J�X�̈ړ�
                    //this._StockMoveInput.ChangeFocus("SAVE");

                    // �t�H�[�J�X�̈ړ�
                    if (this._isNewFlag == false)
                    {
                        this._StockMoveInput.ChangeFocus("SAVE");
                    }
                    else
                    {
                        // �V�K���͎��̕ۑ����s��̃t�H�[�J�X�́A���ׂP�s�ڂ̕i�Ԃֈړ�����
                        this._StockMoveInput.ChangeFocusAfterSave();
                    }
                    // ---UPD 2010/11/15----------------<<<<<
                }
            }

            // �݌Ɉړ����ד��͂ɂĕۑ��{�^�����������ꂽ�ꍇ
            if (this._StockMoveArrivalGoodsInput != null)
            {
                // �w�b�_�A�t�b�^���̊i�[���`�F�b�N
                if (this._StockMoveArrivalGoodsInput.HeaderFooterCheck() == true)
                {
                    // �w�b�_�A�t�b�^�����i�[
                    this._StockMoveArrivalGoodsInput.SetHeaderFooterInfoFromDisplay();

                    StockArrivalGoodsInputSave();

                    this.ToolbarsManager_Main.Tools["ButtonTool_Undo"].SharedProps.Enabled = false;
                }
                _StockMoveArrivalGoodsInput.Clear();//ADD 2010/11/15
            }

            
        }

        /// <summary>
        /// ���ɖ߂�����
        /// </summary>
        private void Retry()
        {
            // �݌Ɉړ����͉�ʂɂČ��ɖ߂��{�^�����������ꂽ�ꍇ
            if (this._StockMoveInput != null)
            {
                this.StockMoveInputRetry();
            }

            // �݌Ɉړ����ד��͂ɂČ��ɖ߂��{�^�����������ꂽ�ꍇ
            if (this._StockMoveArrivalGoodsInput != null)
            {
                this.StockArrivalGoodsInputRetry();
            }
        }

        /// <summary>
        /// �`�[�ďo����
        /// </summary>
        private void SlipLoad()
        {
            MAZAI04120UD StockMoveSlipSearch = new MAZAI04120UD();

            // �݌Ɉړ��`�[������ʕ\��
            this._StockMoveInput.GuideShow();

            SetDisplay();
        }

        private void SetDisplay()
        {
            // �K�C�h����I�����ꂽ�ꍇ�̂ݓo�^
            if (this._StockMoveInputInitAcs.GuideSelected == true)
            {
                if (this._StockMoveDataTable.Count > 0)
                {
                    this._StockMoveInputInitAcs.RegistMode = 1;
                }
                else
                {
                    this._StockMoveInputInitAcs.RegistMode = 0;
                }

                this._StockMoveInput.FixAndArrivalCheck();

                // �ۑ��{�^���A�폜�{�^���������\�ɂ���B
                this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = true;

                //// �m��ς݂����׍ς݂̃`�F�b�N(�m��f�[�^�A���׃f�[�^�͍폜��ύX�͂ł��Ȃ�)
                //if (this._StockMoveInput.FixAndArrivalCheck() == false)
                //{
                //    // �ۑ��{�^���A�폜�{�^���������s�\�ɂ���B
                //    this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
                //    this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
                //}
                //else
                //{
                //    // �ۑ��{�^���A�폜�{�^���������\�ɂ���B
                //    this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                //    this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = true;
                //}

                // ���ɖ߂��{�^��
                this.ToolbarsManager_Main.Tools["ButtonTool_Undo"].SharedProps.Enabled = true;
                // DEL 2010/06/15 MANTIS�Ή�[15317]�F�ۑ����[�ŐV���]�{�^���𑀍�\�� ---------->>>>>
                // TODO:[�ŐV���]�{�^��
                //this.ToolbarsManager_Main.Tools["ButtonTool_Renewal"].SharedProps.Enabled = false;
                // DEL 2010/06/15 MANTIS�Ή�[15317]�F�ۑ����[�ŐV���]�{�^���𑀍�\�� ----------<<<<<

                // �f�[�^�e�[�u������擾�����f�[�^���w�b�_���Ɋi�[
                // 2009.07.07 >>>
                //this._StockMoveInput.setHeader(_StockMoveHeader.StockMvEmpCode,
                //                          _StockMoveHeader.StockMvEmpName,
                //                          _StockMoveHeader.ShipmentScdlDay,
                //                          _StockMoveHeader.AfSectionCode,
                //                          _StockMoveHeader.AfSectionGuideName,
                //                          _StockMoveHeader.AfEnterWarehCode,
                //                          _StockMoveHeader.AfEnterWarehName,
                //                          _StockMoveHeader.BfSectionCode,
                //                          _StockMoveHeader.BfSectionGuideName,
                //                          _StockMoveHeader.BfEnterWarehCode,
                //                          _StockMoveHeader.BfEnterWarehName,
                //                          _StockMoveHeader.OutLine,
                //                          _StockMoveHeader.StockMoveSlipNo);

                // ���ד`�[�̏ꍇ�ɂ́A���ד���\������ׁA�ړ��`�����擾���Ĕ��f����
                int stockMoveFormal = this._StockMoveInput.GetReadDataStockMoveFormal();
                DateTime date = ( stockMoveFormal > 2 ) ? _StockMoveHeader.ArrivalGoodsDay : _StockMoveHeader.ShipmentScdlDay;

                this._StockMoveInput.setHeader(_StockMoveHeader.StockMvEmpCode,
                                          _StockMoveHeader.StockMvEmpName,
                                          date,
                                          _StockMoveHeader.AfSectionCode,
                                          _StockMoveHeader.AfSectionGuideName,
                                          _StockMoveHeader.AfEnterWarehCode,
                                          _StockMoveHeader.AfEnterWarehName,
                                          _StockMoveHeader.BfSectionCode,
                                          _StockMoveHeader.BfSectionGuideName,
                                          _StockMoveHeader.BfEnterWarehCode,
                                          _StockMoveHeader.BfEnterWarehName,
                                          _StockMoveHeader.OutLine,
                                          _StockMoveHeader.StockMoveSlipNo);
                // 2009.07.07 <<<

                // �K�C�h�I���t���O��������
                this._StockMoveInputInitAcs.GuideSelected = false;

                // ���v���z�X�V
                this._StockMoveInput.SetDisplayTotalMoveingPrice();

                this._StockMoveInput.SetRowDeleteEnable(false);
            }
        }

        #region DEL 2008/07/14 Partsman�p�ɕύX
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ��ʃN���[�Y����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// Note       : ��ʂ��N���[�Y�����ۂɍs���鏈���ł��B<br />
        /// Programer  : 20008 �ɓ� �L<br />
        /// Date       : 2007.01.23<br />
        /// </remarks>
        private void Close(bool boolean)
        {
            Boolean status = false;

            // �݌Ɉړ����͉�ʂɂăN���[�Y�{�^�����������ꂽ�ꍇ
            if (_StockMoveInput != null)
            {
                status = this.StockMoveInputClose();
            }

            // �݌Ɉړ��m���ʂɂăN���[�Y�{�^�����������ꂽ�ꍇ
            if (_StockMoveFixInput != null)
            {
                status = this.StockMoveInputFixClose();
            }

            // �݌Ɉړ����ד��͂ɂăN���[�Y�{�^�����������ꂽ�ꍇ
            if (_StockMoveArrivalGoodsInput != null)
            {
                status = this.StockMoveArrivalGoodsInputClose();
            }

            if (status == true)
            {
                this.Close();
            }
        }
        
        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// Note       : �ۑ��{�^�������������ۂɍs���鏈���ł��B<br />
        /// Programer  : 20008 �ɓ� �L<br />
        /// Date       : 2007.01.23<br />
        /// </remarks>
        private void Save()
        {
            // �݌Ɉړ����͉�ʂɂĕۑ��{�^�����������ꂽ�ꍇ
            if (_StockMoveInput != null)
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // �O���b�h�ҏW�m��
                _StockMoveInput.DetailReturnKeyDown();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // �w�b�_�A�t�b�^���̊i�[���`�F�b�N
                if (_StockMoveInput.HeaderFooterCheck() == true)
                {
                    // �w�b�_�A�t�b�^�����i�[
                    _StockMoveInput.SetHeaderFooterInfoFromDisplay();

                    // �{�Ћ@�\�����`�F�b�N
                    if (_StockMoveInput.MainOfficeFuncCheck() == false)
                    {
                        TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�����_�̑q�Ɉړ��͂ł��܂���B",
                                -1,
                                MessageBoxButtons.OK);
                        return;
                    }

                    // �ړ��拒�_�A�ړ���q�ɐ������`�F�b�N
                    if (_StockMoveInput.AfIntegrationCheck() == false)
                    {
                        TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�ړ���q�ɂ����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);
                        return;
                    }

                    // ����݌ɂ̗��p�\�`�F�b�N
                    switch (_StockMoveInput.TrustStockCheck())
                    {
                        case 1:
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "����݌ɂ̋��_�Ԉړ���������Ă��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);
                                return;
                            }
                        case 2:
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "����݌ɂ̑q�ɊԈړ���������Ă��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);
                                return;
                            }
                    }

                    if (this.StockMoveInputSave() == true)
                    {
                        _StockMoveInput.SetTableUpdateFlg();

                        // �`�[�������
                        if (_StockMoveInput.PrintCheck == true)
                        {
                            this.SlipOutput();
                        }

                        // ��ʂ��N���A
                        _StockMoveInput.Clear();

                        // �t�H�[�J�X�̈ړ�
                        _StockMoveInput.ChangeFocus("SAVE");
                    }
                }

                // �ړ��`�[�o�̓{�^�����\��
                this.ToolbarsManager_Main.Tools["ButtonTool_OutPut"].SharedProps.Enabled = false;
            }

            // �݌Ɉړ��m���ʂɂĕۑ��{�^�����������ꂽ�ꍇ
            if (_StockMoveFixInput != null)
            {
                // �w�b�_�A�t�b�^���̊i�[���`�F�b�N
                if (_StockMoveFixInput.HeaderFooterCheck() == true)
                {
                    // �w�b�_�A�t�b�^�����i�[
                    _StockMoveFixInput.SetHeaderFooterInfoFromDisplay();

                    this.StockMoveFixInputSave();
                }
            }

            // �݌Ɉړ����ד��͂ɂĕۑ��{�^�����������ꂽ�ꍇ
            if (_StockMoveArrivalGoodsInput != null)
            {
                // �w�b�_�A�t�b�^���̊i�[���`�F�b�N
                if (_StockMoveArrivalGoodsInput.HeaderFooterCheck() == true)
                {
                    // �w�b�_�A�t�b�^�����i�[
                    _StockMoveArrivalGoodsInput.SetHeaderFooterInfoFromDisplay();

                    this.StockArrivalGoodsInputSave();
                }
            }
        }
        
        /// <summary>
        /// ���ɖ߂�����
        /// </summary>
        /// <remarks>
        /// Note       : ���ɖ߂��{�^�������������ۂɍs���鏈���ł��B<br />
        /// Programer  : 20008 �ɓ� �L<br />
        /// Date       : 2007.01.23<br />
        /// </remarks>
        private void Retry()
        {
            // �݌Ɉړ����͉�ʂɂČ��ɖ߂��{�^�����������ꂽ�ꍇ
            if (_StockMoveInput != null)
            {
                this.StockMoveInputRetry();
            }

            // �݌Ɉړ��m���ʂɂČ��ɖ߂��{�^�����������ꂽ�ꍇ
            if (_StockMoveFixInput != null)
            {
                this.StockMoveFixInputRetry();
            }

            // �݌Ɉړ����ד��͂ɂČ��ɖ߂��{�^�����������ꂽ�ꍇ
            if (_StockMoveArrivalGoodsInput != null)
            {
                this.StockArrivalGoodsInputRetry();
            }
        }

        /// <summary>
        /// �`�[�ďo����
        /// </summary>
        /// <remarks>
        /// Note       : �`�[�ďo�{�^�������������ۂɍs���鏈���ł��B<br />
        /// Programer  : 20008 �ɓ� �L<br />
        /// Date       : 2007.03.03<br />
        /// </remarks>
        private void SlipLoad()
        {
            MAZAI04120UD StockMoveSlipSearch = new MAZAI04120UD();

            // �݌Ɉړ��`�[������ʕ\��
            _StockMoveInput.GuideShow();

            // �K�C�h����I�����ꂽ�ꍇ�̂ݓo�^
            if (_StockMoveInputInitAcs.GuideSelected == true)
            {
                if (_StockMoveDataTable.Count > 0)
                {
                    _StockMoveInputInitAcs.RegistMode = 1;
                }
                else
                {
                    _StockMoveInputInitAcs.RegistMode = 0;
                }

                // �m��ς݂����׍ς݂̃`�F�b�N(�m��f�[�^�A���׃f�[�^�͍폜��ύX�͂ł��Ȃ�)
                if (this._StockMoveInput.FixAndArrivalCheck() == false)
                {
                    // �ۑ��{�^���A�폜�{�^���������s�\�ɂ���B
                    this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
                    this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
                }
                else
                {
                    // �ۑ��{�^���A�폜�{�^���������\�ɂ���B
                    this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                    this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = true;
                }

                // �ړ��`�[�o�̓{�^����\��
                if (this.printCheck == true)
                {
                    this.ToolbarsManager_Main.Tools["ButtonTool_OutPut"].SharedProps.Enabled = true;
                }
                else
                {
                    this.ToolbarsManager_Main.Tools["ButtonTool_OutPut"].SharedProps.Enabled = false;
                }

                // �ŏI���R�[�h�ɋ󂫃��R�[�h��1���쐬
                // �ŏI�s�̏ꍇ�́A�P�s�ǉ�����
                this._StockMoveInputAcs.AddStockDetailRow();

                string[] splitString = _StockMoveDataTable[0].ShipmentScdlDay.Split('/');
                DateTime convShipmentScdlDay = new DateTime(Int32.Parse(splitString[0]), Int32.Parse(splitString[1]), Int32.Parse(splitString[2]));

                // �f�[�^�e�[�u������擾�����f�[�^���w�b�_���Ɋi�[
                _StockMoveInput.setHeader(_StockMoveHeader.StockMvEmpCode,
                                          _StockMoveHeader.StockMvEmpName,
                                          _StockMoveHeader.ShipmentScdlDay,
                                          _StockMoveHeader.AfSectionCode,
                                          _StockMoveHeader.AfSectionGuideName,
                                          _StockMoveHeader.AfEnterWarehCode,
                                          _StockMoveHeader.AfEnterWarehName,
                                          _StockMoveHeader.BfSectionCode,
                                          _StockMoveHeader.BfSectionGuideName,
                                          _StockMoveHeader.BfEnterWarehCode,
                                          _StockMoveHeader.BfEnterWarehName,
                                          _StockMoveHeader.OutLine,
                                          _StockMoveHeader.StockMoveSlipNo);

                // �K�C�h�I���t���O��������
                _StockMoveInputInitAcs.GuideSelected = false;

                // ���v���z�X�V
                _StockMoveInput.SetDisplayTotalPriceInfo();

                _StockMoveInput.SetRowDeleteEnable(false);
            }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman�p�ɕύX

        #region DEL �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���_�R�[�h�ύX�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void StockMoveInput_SectionChange( object sender, EventArgs e )
        {
            // ���_����
            string sectionName = string.Empty;

            // ���_���̂��擾����
            if ( sender == _StockMoveInput )
            {
                // �ړ�����
                sectionName = _StockMoveInput.GetSectionName();
            }
            else if ( sender == _StockMoveFixInput )
            {
                // �ړ��m��
                sectionName = _StockMoveFixInput.GetSectionName();
            }
            else if ( sender == _StockMoveArrivalGoodsInput )
            {
                // �ړ�����
                sectionName = _StockMoveArrivalGoodsInput.GetSectionName();
            }


            // ����Ɏ擾�ł���΁A���_���̂�����������
            if ( !string.IsNullOrEmpty( sectionName ) )
            {
                _sectionLabel.SharedProps.Caption = sectionName;
            }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        /// <summary>
        /// �`�[�폜����
        /// </summary>
        private void Delete()
        {
            Boolean saveCheck = false;
            int stockMoveSlipNo = 0;

            foreach (StockMoveInputDataSet.StockMoveRow row in this._StockMoveDataTable)
            {
                if (row.GoodsNo != null || row.GoodsNo != "")
                {
                    saveCheck = true;
                    stockMoveSlipNo = row.StockMoveSlipNo;
                }
            }

            if (saveCheck == true && stockMoveSlipNo != 0)
            {
                // �ǂݍ��܂ꂽ�`�[���폜����
                DialogResult dialogResult = ShowMessageBox(emErrorLevel.ERR_LEVEL_QUESTION,
                                                           "�\�����̈ړ��`�[" + "���폜���܂��B" + "\r\n" + "\r\n" +
                                                           "��낵���ł����H",
                                                           0,
                                                           MessageBoxButtons.YesNo,
                                                           MessageBoxDefaultButton.Button1);

                // �ҏW�f�[�^��o�^���ĕ���ꍇ
                if (dialogResult == DialogResult.Yes)
                {
                    DateTime targetDate;

                    if (!this._StockMoveInputInitAcs.CheckHisTotalDayMonthly(this._StockMoveInputInitAcs.StockMoveHeader.BfSectionCode.Trim(), this._StockMoveInput.GetSlipmentDay(), out targetDate))
                    {
                        string errMsg = "�o�ד����O�񌎎��X�V���ȑO�ɂȂ��Ă���ׁA�폜�ł��܂���B" + "\r\n\r\n" + "  �O�񌎎��X�V���F" + targetDate.ToString("yyyy�NMM��dd��");
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                               errMsg,
                                               0,
                                               MessageBoxButtons.OK,
                                               MessageBoxDefaultButton.Button1);
                        return;
                    }
                    //----- ADD K2013/09/11 �c���� ---------->>>>>
                    if (CheckStockMoveData(this._StockMoveInputAcs.StockMoveDataTable[0].StockMoveSlipNo) == false)
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        "�e�L�X�g�ϊ��ς݂̃f�[�^�ׁ̈A�X�V�ł��܂���B",
                                        0,
                                        MessageBoxButtons.OK,
                                        MessageBoxDefaultButton.Button1);

                        return;
                    }
                    //----- ADD K2013/09/11 �c���� ----------<<<<<

                    int slipNo;
                    int status = this._StockMoveInputAcs.DeleteStockMove(out slipNo);
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            {
                                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                               "�ړ��`�[���폜���܂����B",
                                               0,
                                               MessageBoxButtons.OK,
                                               MessageBoxDefaultButton.Button1);

                                // ���O�o��
                                if (MyOpeCtrl.EnabledWithLog((int)OperationCode.Delete))
                                {
                                    MyOpeCtrl.Logger.WriteOperationLog(
                                        "Delete",
                                        (int)OperationCode.Delete,
                                        0,
                                        string.Format("{0}�`�[�A�`�[�ԍ�:{1}���폜", "�݌Ɉړ�", slipNo.ToString("000000000")));
                                }

                                // ��ʏ�����
                                this._StockMoveInput.Clear();

                                // �t�H�[�J�X�ړ�
                                this._StockMoveInput.ChangeFocus("DELETE");

                                // �폜�{�^���𖳌�
                                this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
                                this.ToolbarsManager_Main.Tools["ButtonTool_Undo"].SharedProps.Enabled = false;
                                return;
                            }
                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                            {
                                ExclusiveTransaction(status);
                                return;
                            }
                        // ��ƃ��b�N�^�C���A�E�g
                        case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                            {
                                TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "�폜�Ɏ��s���܂����B" + "\r\n"
                                    + "\r\n" +
                                    "�V�F�A�`�F�b�N�G���[�i��ƃ��b�N�j�ł��B" + "\r\n" +
                                    "�����������A���̑��̋Ɩ����s���Ă��邽�ߖ{�����͍s���܂���B" + "\r\n" +
                                    "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                    status,
                                    MessageBoxButtons.OK);
                                return;
                            }
                        // ���_���b�N�^�C���A�E�g
                        case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                            {
                                TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "�폜�Ɏ��s���܂����B" + "\r\n"
                                    + "\r\n" +
                                    "�V�F�A�`�F�b�N�G���[�i���_���b�N�j�ł��B" + "\r\n" +
                                    "���������A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n" +
                                    "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                    status,
                                    MessageBoxButtons.OK);
                                return;
                            }
                        // �q�Ƀ��b�N�^�C���A�E�g
                        case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                            {
                                TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "�폜�Ɏ��s���܂����B" + "\r\n"
                                    + "\r\n" +
                                    "�V�F�A�`�F�b�N�G���[�i�q�Ƀ��b�N�j�ł��B" + "\r\n" +
                                    "�I���������A���̑��̍݌ɋƖ����s���Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n" +
                                    "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                    status,
                                    MessageBoxButtons.OK);
                                return;
                            }
                        default:
                            {
                                ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                               "Delete",
                                               "�ړ��`�[�̍폜�Ɏ��s���܂����B",
                                               status,
                                               MessageBoxButtons.OK);
                                return;
                            }
                    }
                }
                // �ҏW�f�[�^��o�^�����ɕ���ꍇ
                else if (dialogResult == DialogResult.No)
                {
                    // �������Ȃ�
                }
            }
            else
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "�폜����ړ��`�[������܂���B",
                               -1,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);
            }
        }

        #region DEL 2008/07/14 Partsman�p�ɕύX
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �`�[�폜����
        /// </summary>
        /// <remarks>
        /// Note       : �`�[�폜�{�^�������������ۂɍs���鏈���ł��B<br />
        /// Programer  : 20008 �ɓ� �L<br />
        /// Date       : 2007.03.03<br />
        /// </remarks>
        private void Delete()
        {
            Boolean saveCheck = false;
            int stockMoveSlipNo= 0;

            foreach (StockMoveInputDataSet.StockMoveRow row in _StockMoveDataTable) 
            {
                if ( row.GoodsNo != null || row.GoodsNo != "" ) 
                {
                    saveCheck = true;
                    stockMoveSlipNo = row.StockMoveSlipNo;
                }
            }

            if (saveCheck == true && stockMoveSlipNo != 0) 
            {
                // �ǂݍ��܂ꂽ�`�[���폜����
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    this.Name,
                    "�\�����̈ړ��`�[" + "���폜���܂��B" + "\r\n" + "\r\n" +
                    "��낵���ł����H",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                // �ҏW�f�[�^��o�^���ĕ���ꍇ
                if (dialogResult == DialogResult.Yes)
                {
                    int status = _StockMoveInputAcs.DeleteStockMove();
                    // �o�^�ɐ��������ꍇ�ɂ̂݁A��ʂ����B
                    if (status == 0)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "�ړ��`�[���폜���܂����B",
                            -1,
                            MessageBoxButtons.OK);

                        // ��ʏ�����
                        _StockMoveInput.Clear();

                        // �t�H�[�J�X�ړ�
                        _StockMoveInput.ChangeFocus("DELETE");
                    }
                    else
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "�ړ��`�[�̍폜�Ɏ��s���܂����B",
                            -1,
                            MessageBoxButtons.OK);
                    }
                }
                // �ҏW�f�[�^��o�^�����ɕ���ꍇ
                else if (dialogResult == DialogResult.No) 
                {
                    // �������Ȃ�
                }
            }
            else {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�폜����ړ��`�[������܂���B",
                    -1,
                    MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// �݌Ɉړ��`�[�o�͏���
        /// </summary>
        /// <remarks>
        /// Note       : �݌Ɉړ��`�[���o�͂��܂��B<br />
        /// Programer  : 20008 �ɓ� �L<br />
        /// Date       : 2007.07.11<br />
        /// </remarks>
        private void SlipOutput()
        {
            try
            {
                MAZAI02172PA _MAZAI02172PA = new MAZAI02172PA();

                //_MAZAI04123PA._outputMode = outputMode;

                _MAZAI02172PA.Printinfo = _sfcmn06002C;

                _MAZAI02172PA.Printinfo.rdData = _StockMoveInputAcs.StockMoveDataTable;

                _MAZAI02172PA.Printinfo.prevkbn = 1;//PreView����

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// �r���A�N�Z�X���擾
                //this.GetOLEControlClaim();

                //// �f�o�C�X�R���g���[����n��
                //_MAZAI02172PA.DeviceHandle = this._olePrtController;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                _MAZAI02172PA.StartPrint();
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// OPOS�f�o�C�X�R���g���[���A�N�Z�X���j��
                //this.ReleaseOLEControlClaim();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // �f�[�^�e�[�u���\�[�g�̃N���A
                _StockMoveInputAcs.StockMoveDataTable.DefaultView.Sort = "";
            }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman�p�ɕύX

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �݌Ɉړ��`�[�o�͏���
        /// </summary>
        /// <remarks>
        /// Note       : �݌Ɉړ��`�[���o�͂��܂��B<br />
        /// Programer  : 30414 �E �K�j<br />
        /// Date       : 2008/10/03<br />
        /// </remarks>
        private void SlipOutput()
        {
            try
            {
                // �݌Ɉړ��`�[ ��������ݒ�
                StockMoveSlipPrintCndtn cndtn = new StockMoveSlipPrintCndtn();
                cndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                cndtn.StockMoveSlipKeyList = new List<StockMoveSlipPrintCndtn.StockMoveSlipKey>();

                int stockMoveFormal;
                int stockMoveSlipNo;

                if (this._StockMoveInput.GetSlipNo() == "")
                {
                    // �V�K�ۑ���ɓ`�[�o�͂���ꍇ
                    stockMoveFormal = this._StockMoveInputAcs.StockMoveFormal; 
                    stockMoveSlipNo = this._StockMoveInputAcs.StockMoveSlipNo;
                    cndtn.ReissueDiv = false;
                }
                else
                {
                    // �`�[�ďo��ɓ`�[�o�͂���ꍇ
                    stockMoveFormal = this._StockMoveInput.GetStockMoveFormal();
                    stockMoveSlipNo = int.Parse(this._StockMoveInput.GetSlipNo());
                    cndtn.ReissueDiv = true;
                }

                cndtn.StockMoveSlipKeyList.Add(new StockMoveSlipPrintCndtn.StockMoveSlipKey(stockMoveFormal, stockMoveSlipNo));

                // �݌Ɉړ��`�[ ���
                DCCMN02000UA slipPrtDialog = new DCCMN02000UA();
                slipPrtDialog.Print(cndtn);
            }
            finally
            {
                // �f�[�^�e�[�u���\�[�g�̃N���A
                _StockMoveInputAcs.StockMoveDataTable.DefaultView.Sort = "";
            }
        }
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// �݌Ɉړ����͉�ʎ��N���[�Y����
        /// </summary>
        /// <remarks>
        /// Note       : �݌Ɉړ����͉�ʎ��ɕ���{�^�����������ꂽ�ۂɍs���鏈���ł��B<br />
        /// Programer  : 20008 �ɓ� �L<br />
        /// Date       : 2007.02.20<br />
        /// </remarks>
        private Boolean StockMoveInputClose()
        {
            // �ҏW�����m�F
            if (!_StockMoveInput.CompareBeforeNewProc())
            {
                DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                "�o�^���Ă���낵���ł����H",
                0,
                MessageBoxButtons.YesNoCancel,
                MessageBoxDefaultButton.Button1);

                // �ҏW�f�[�^��o�^���ĕ���ꍇ
                if (dialogResult == DialogResult.Yes)
                {
                    Boolean status = this.StockMoveInputSave();

                    // �o�^�ɐ��������ꍇ�ɂ̂݁A��ʂ����B
                    if (status == true)
                    {
                        // �w�b�_�y�ь���������������
                        _StockMoveInputInitAcs.StockMoveHeaderClear();
                        _StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                        _StockMoveInput.Close();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                // �ҏW�f�[�^��o�^�����ɕ���ꍇ
                else if (dialogResult == DialogResult.No)
                {
                    // �w�b�_�y�ь���������������
                    _StockMoveInputInitAcs.StockMoveHeaderClear();
                    _StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                    _StockMoveInput.Close();
                    return true;
                }
                // �L�����Z�����ꂽ�ꍇ
                else
                {
                    return false;
                }
            }
            // �ҏW���łȂ��ꍇ�͂��̂܂ܕ���B
            else
            {
                // �w�b�_�y�ь���������������
                _StockMoveInputInitAcs.StockMoveHeaderClear();
                _StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                _StockMoveInput.Close();
                return true;
            }
        }

        #region DEL 2008/07/14 Partsman�p�ɕύX
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �݌Ɉړ��m���ʎ��N���[�Y����
        /// </summary>
        /// <remarks>
        /// Note       : �݌Ɉړ��m���ʎ��ɕ���{�^�����������ꂽ�ۂɍs���鏈���ł��B<br />
        /// Programer  : 20008 �ɓ� �L<br />
        /// Date       : 2007.02.20<br />
        /// </remarks>
        private Boolean StockMoveInputFixClose()
        {
            // �ҏW�����m�F
            if (_StockMoveFixInput.CloseDataCheck())
            {
                DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                "�o�^���Ă���낵���ł����H",
                0,
                MessageBoxButtons.YesNoCancel,MessageBoxDefaultButton.Button1);

                // �ҏW�f�[�^��o�^���ĕ���ꍇ
                if (dialogResult == DialogResult.Yes)
                {
                    Boolean status = this.StockMoveFixInputSave();

                    // �o�^�ɐ��������ꍇ�ɂ̂݁A��ʂ����B
                    if (status == true)
                    {
                        // �w�b�_�y�ь���������������
                        _StockMoveInputInitAcs.StockMoveHeaderClear();
                        _StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                        _StockMoveFixInput.Close();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                // �ҏW�f�[�^��o�^�����ɕ���ꍇ
                else if (dialogResult == DialogResult.No)
                {
                    // �w�b�_�y�ь���������������
                    _StockMoveInputInitAcs.StockMoveHeaderClear();
                    _StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                    _StockMoveFixInput.Close();
                    return true;
                }
                // �L�����Z�����ꂽ�ꍇ
                else
                {
                    return false;
                }
            }
            // �ҏW���łȂ��ꍇ�͂��̂܂ܕ���B
            else
            {
                // �w�b�_�y�ь���������������
                _StockMoveInputInitAcs.StockMoveHeaderClear();
                _StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                _StockMoveFixInput.Close();
                return true;
            }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman�p�ɕύX

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">��\���t���O(true: ��\���ɂ���, false: ��\���ɂ��Ȃ�)</param>
        private void ExclusiveTransaction(int status)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // ���[���X�V
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            "MAZAI04100U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,				            // �v���O��������
                            "ExclusiveTransaction", 			// ��������
                            TMsgDisp.OPE_HIDE, 					// �I�y���[�V����
                            "���ɑ��[�����X�V����Ă��܂��B", // �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._StockMoveInputAcs, 			// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // ���[���폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            "MAZAI04100U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,				            // �v���O��������
                            "ExclusiveTransaction", 			// ��������
                            TMsgDisp.OPE_HIDE, 					// �I�y���[�V����
                            "���ɑ��[�����폜����Ă��܂��B", // �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._StockMoveInputAcs, 			// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        break;
                    }
            }
        }

        /// <summary>
        /// �݌Ɉړ����ד��͉�ʎ��N���[�Y����
        /// </summary>
        /// <remarks>
        /// Note       : �݌Ɉړ����ד��͉�ʎ��ɃN���[�Y�{�^�����������ꂽ�ۂɍs���鏈���ł��B<br />
        /// Programer  : 20008 �ɓ� �L<br />
        /// Date       : 2007.02.20<br />
        /// </remarks>
        private Boolean StockMoveArrivalGoodsInputClose()
        {
            // �ҏW�����m�F
            if (!_StockMoveArrivalGoodsInput.CompareBeforeNewProc())
            {
                DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                "�o�^���Ă���낵���ł����H",
                0,
                MessageBoxButtons.YesNoCancel,
                MessageBoxDefaultButton.Button1);

                // �ҏW�f�[�^��o�^���ĕ���ꍇ
                if (dialogResult == DialogResult.Yes)
                {
                    Boolean status = this.StockArrivalGoodsInputSave();

                    // �o�^�ɐ��������ꍇ�ɂ̂݁A��ʂ����B
                    if (status == true)
                    {
                        // �w�b�_�y�ь���������������
                        _StockMoveInputInitAcs.StockMoveHeaderClear();
                        _StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                        _StockMoveArrivalGoodsInput.Close();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                // �ҏW�f�[�^��o�^�����ɕ���ꍇ
                else if (dialogResult == DialogResult.No)
                {
                    // �w�b�_�y�ь���������������
                    _StockMoveInputInitAcs.StockMoveHeaderClear();
                    _StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                    _StockMoveArrivalGoodsInput.Close();
                    return true;
                }
                // �L�����Z�����ꂽ�ꍇ
                else
                {
                    return false;
                }
            }
            // �ҏW���łȂ��ꍇ�͂��̂܂ܕ���B
            else
            {
                // �w�b�_�y�ь���������������
                _StockMoveInputInitAcs.StockMoveHeaderClear();
                _StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                _StockMoveArrivalGoodsInput.Close();
                return true;
            }
        }

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �o�׏����ۑ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Update Date: K2013/09/11 �c����</br>
        /// <br>           : �t�^�o�ʑΉ�</br>
        /// <br>           : �e�L�X�g�ϊ���̃f�[�^���C���E�폜�s�Ƃ���B</br>
        /// </remarks>
        private Boolean StockMoveInputSave()
        {
            // �`�[�C����
            if (_StockMoveInput.GetEnabledSupplierSlipNo() == false)
            {
                if (MyOpeCtrl.Disabled((int)OperationCode.Revision))
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                               "�Z�L�����e�B�ɂ��`�[�C������������Ă��܂��B",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);
                    return (false);
                }
            }

            // ���̓`�F�b�N
            if (this._StockMoveInput.CheckInputScreen() == false)
            {
                return (false);
            }

            // �w�b�_�A�t�b�^�����i�[
            this._StockMoveInput.SetHeaderFooterInfoFromDisplay();

            Boolean saveCheck = false;
            foreach (StockMoveInputDataSet.StockMoveRow row in this._StockMoveDataTable)
            {
                if (row.GoodsNo != null && row.GoodsNo != "")
                {
                    saveCheck = true;
                    break;
                }
            }

            if (saveCheck == false)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "�ۑ�����f�[�^�����݂��܂���B",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);

                return (false);
            }

            //----- ADD K2013/09/11 �c���� ---------->>>>>
            if (CheckStockMoveData(this._StockMoveInputAcs.StockMoveDataTable[0].StockMoveSlipNo) == false)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                "�e�L�X�g�ϊ��ς݂̃f�[�^�ׁ̈A�X�V�ł��܂���B",
                                0,
                                MessageBoxButtons.OK,
                                MessageBoxDefaultButton.Button1);

                return (false);
            }
            //----- ADD K2013/09/11 �c���� ----------<<<<<

            // �`�[����敪(�ۑ������O��A�N���X�ɃZ�b�g����K�v�L��)
            _StockMoveInputAcs.SlipPrint = _StockMoveInput.GetPrintCheck();

            // �`�[�敪�u-1:���ڔ�\���A0:�o�ɓ`�[�A1:���ɓ`�[�v(�ۑ������O��A�N���X�ɃZ�b�g����K�v�L��)
            this._StockMoveInputAcs.SlipDiv = this._StockMoveInput.GetSlipDiv();        //ADD 2009/06/04

            // �ۑ����� 
            bool isNew;
            int status = this._StockMoveInputAcs.WriteStockMove(out isNew);
            this._isNewFlag = isNew; // ADD 2010/11/15
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (!isNew)
                        {
                            // ���O�o��
                            if (MyOpeCtrl.EnabledWithLog((int)OperationCode.Revision))
                            {
                                MyOpeCtrl.Logger.WriteOperationLog(
                                    "Revision",
                                    (int)OperationCode.Revision,
                                    0,
                                    string.Format("{0}�`�[�A�`�[�ԍ�:{1}���C��", "�݌Ɉړ�", this._StockMoveInputAcs.StockMoveSlipNo.ToString("000000000")));
                            }
                        }

                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);

                        // �ۑ��ɐ���������X�V���[�h��V�K�ɕύX
                        this._StockMoveInputInitAcs.RegistMode = 0;
                        
                        // ��ʂ�������
                        this._StockMoveInputInitAcs.StockMoveHeaderClear();

                        return (true);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        ExclusiveTransaction(status);
                        return (false);
                    }
                // ��ƃ��b�N�^�C���A�E�g
                case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "�ۑ��Ɏ��s���܂����B" + "\r\n"
                                    + "\r\n" +
                                    "�V�F�A�`�F�b�N�G���[�i��ƃ��b�N�j�ł��B" + "\r\n" +
                                    "�����������A���̑��̋Ɩ����s���Ă��邽�ߖ{�����͍s���܂���B" + "\r\n" +
                                    "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                    status,
                                    MessageBoxButtons.OK);
                        return (false);
                    }
                // ���_���b�N�^�C���A�E�g
                case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "�ۑ��Ɏ��s���܂����B" + "\r\n"
                                    + "\r\n" +
                                    "�V�F�A�`�F�b�N�G���[�i���_���b�N�j�ł��B" + "\r\n" +
                                    "���������A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n" +
                                    "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                    status,
                                    MessageBoxButtons.OK);
                        return (false);
                    }
                // �q�Ƀ��b�N�^�C���A�E�g
                case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "�ۑ��Ɏ��s���܂����B" + "\r\n"
                                    + "\r\n" +
                                    "�V�F�A�`�F�b�N�G���[�i�q�Ƀ��b�N�j�ł��B" + "\r\n" +
                                    "�I���������A���̑��̍݌ɋƖ����s���Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n" +
                                    "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                    status,
                                    MessageBoxButtons.OK);
                        return (false);
                    }
                case -2:
                case -9:
                    {
                        string errMsg;
                        if (status == -2)
                        {
                            errMsg = "�X�V�f�[�^���Ɋ��Ɋm��ς̃f�[�^�����݂��܂��B";
                        }
                        else
                        {
                            errMsg = "�X�V�f�[�^���Ɋ��ɓ��׍ς̃f�[�^�����݂��܂��B";
                        }

                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               errMsg,
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);

                        return (false);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                       "StockMoveInputSave",
                                       "�ۑ��Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);
                        return (false);
                    }
            }
        }

        /// <summary>
        /// ���׏����ۑ�����
        /// </summary>
        /// <return>
        /// true: �o�^����, false: �o�^���s
        /// </return>
        /// <remarks>
        /// <br>Update Date: K2013/09/11 �c����</br>
        /// <br>           : �t�^�o�ʑΉ�</br>
        /// <br>           : �e�L�X�g�ϊ���̃f�[�^���C���E�폜�s�Ƃ���B</br>
        /// </remarks>
        private Boolean StockArrivalGoodsInputSave()
        {
            // �o�^�f�[�^�`�F�b�N
            if (this._StockMoveDataTable.Count == 0)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "�ۑ�����f�[�^�����݂��܂���B",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);

                return (false);
            }

            // ���ד�
            DateTime targetDate = this._StockMoveArrivalGoodsInput.GetArrivalGoodsDay();

            for (int index = 0; index < this._StockMoveInputAcs.StockMoveDataTable.Rows.Count; index++)
            {
                // �ύX�f�[�^
                if (this._StockMoveInputAcs.StockMoveDataTable[index].ArrivalFlag !=
                    this._StockMoveInputAcs.StockMoveDataTableBackup[index].ArrivalFlag)
                {
                    // ���ɋ��_
                    string sectionCode = this._StockMoveInputAcs.StockMoveDataTable[index].AfSectionCode;

                    DateTime prevTotalDay;

                    if (!this._StockMoveInputInitAcs.CheckHisTotalDayMonthly(sectionCode, targetDate, out prevTotalDay))
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                               "���ד����O�񌎎��X�V���ȑO�ɂȂ��Ă���ׁA�o�^�ł��܂���B" + "\r\n\r\n" + "  �O�񌎎��X�V���F" + prevTotalDay.ToString("yyyy�NMM��dd��"),
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);

                        return (false);
                    }
                }

            }

            bool existsCancelData = false;  // ADD 2010/06/11 ���׎���̊m�F��1�񂾂�
            //----- ADD K2013/09/11 �c���� ---------->>>>>
            bool canSaveFlg = true;
            ArrayList errorSlipNoList = new ArrayList();
            ArrayList stockMoveSlipNoList = new ArrayList();
            //----- ADD K2013/09/11 �c���� ----------<<<<<
            for (int index = 0; index < this._StockMoveInputAcs.StockMoveDataTable.Rows.Count; index++)
            {
                if (this._StockMoveInputAcs.StockMoveDataTable[index].ArrivalFlag !=
                    this._StockMoveInputAcs.StockMoveDataTableBackup[index].ArrivalFlag)
                {
                    if (this._StockMoveInputAcs.StockMoveDataTable[index].MoveStatus != 9)
                    {
                        
                        // DEL 2010/06/11 ���׎���̊m�F��1�񂾂� ---------->>>>>
                        //DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                        //                                  "���׎�����s���f�[�^���܂܂�Ă��܂����A��낵���ł����H",
                        //                                  0,
                        //                                  MessageBoxButtons.OKCancel,
                        //                                  MessageBoxDefaultButton.Button1);
                        //if (res == DialogResult.Cancel)
                        //{
                        //    return (false);
                        //}
                        // DEL 2010/06/11 ���׎���̊m�F��1�񂾂� ----------<<<<<
                        // ADD 2010/06/11 ���׎���̊m�F��1�񂾂� ---------->>>>>
                        existsCancelData = true;
                        // ADD 2010/06/11 ���׎���̊m�F��1�񂾂� ----------<<<<<
                        //----- ADD K2013/09/11 �c���� ---------->>>>>
                        if (!stockMoveSlipNoList.Contains(this._StockMoveInputAcs.StockMoveDataTable[index].StockMoveSlipNo))
                        {
                            if (CheckStockMoveData(this._StockMoveInputAcs.StockMoveDataTable[index].StockMoveSlipNo) == false)
                            {
                                canSaveFlg = false;
                                errorSlipNoList.Add(this._StockMoveInputAcs.StockMoveDataTable[index].StockMoveSlipNo);
                            }
                            stockMoveSlipNoList.Add(this._StockMoveInputAcs.StockMoveDataTable[index].StockMoveSlipNo);
                        }
                        //----- ADD K2013/09/11 �c���� ----------<<<<<
                    }
                }
            }
            // ADD 2010/06/11 ���׎���̊m�F��1�񂾂� ---------->>>>>
            if (existsCancelData)
            {
                DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                      "���׎�����s���f�[�^���܂܂�Ă��܂����A��낵���ł����H",
                                      0,
                                      MessageBoxButtons.OKCancel,
                                      MessageBoxDefaultButton.Button1);
                if (res == DialogResult.Cancel)
                {
                    return (false);
                }
            }
            // ADD 2010/06/11 ���׎���̊m�F��1�񂾂� ----------<<<<<
            //----- ADD K2013/09/11 �c���� ---------->>>>>
            if (!canSaveFlg)
            {
                string stockMoveSlipNo = string.Empty;
                errorSlipNoList.Sort();
                if (errorSlipNoList.Count > 0)
                {
                    for (int i = 0; i < errorSlipNoList.Count; i++)
                    {
                        stockMoveSlipNo += "�y�`�[�ԍ��F" + errorSlipNoList[i].ToString().PadLeft(9, '0') + "�z";
                        if (i != errorSlipNoList.Count - 1)
                        {
                            stockMoveSlipNo += Environment.NewLine;
                        }
                    }
                }
                ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                "���׎���ΏۂɃe�L�X�g�ϊ��ς݂̃f�[�^�����݂���ׁA���׎���ł��܂���B" + Environment.NewLine + stockMoveSlipNo,
                                0,
                                MessageBoxButtons.OK,
                                MessageBoxDefaultButton.Button1);

                return (false);
            }
            //----- ADD K2013/09/11 �c���� ----------<<<<<
            // �ۑ�����
            ArrayList stockMoveWorkList;
            int status = this._StockMoveInputAcs.WriteStockMoveArrival(out stockMoveWorkList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        //foreach (StockMoveWork stockMoveWork in stockMoveWorkList)
                        //{
                        //    // ���O�o��
                        //    if (MyOpeCtrl.EnabledWithLog((int)OperationCode.Revision))
                        //    {
                        //        MyOpeCtrl.Logger.WriteOperationLog(
                        //            "Revision",
                        //            (int)OperationCode.Revision,
                        //            0,
                        //            string.Format("{0}�`�[�A�`�[�ԍ�:{1}���C��", "�݌Ɉړ�", stockMoveWork.StockMoveSlipNo.ToString("000000000")));
                        //    }
                        //}

                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        ExclusiveTransaction(status);
                        return (false);
                    }
                // ��ƃ��b�N�^�C���A�E�g
                case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "�ۑ��Ɏ��s���܂����B" + "\r\n"
                                    + "\r\n" +
                                    "�V�F�A�`�F�b�N�G���[�i��ƃ��b�N�j�ł��B" + "\r\n" +
                                    "�����������A���̑��̋Ɩ����s���Ă��邽�ߖ{�����͍s���܂���B" + "\r\n" +
                                    "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                    status,
                                    MessageBoxButtons.OK);
                        return (false);
                    }
                // ���_���b�N�^�C���A�E�g
                case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "�ۑ��Ɏ��s���܂����B" + "\r\n"
                                    + "\r\n" +
                                    "�V�F�A�`�F�b�N�G���[�i���_���b�N�j�ł��B" + "\r\n" +
                                    "���������A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n" +
                                    "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                    status,
                                    MessageBoxButtons.OK);
                        return (false);
                    }
                // �q�Ƀ��b�N�^�C���A�E�g
                case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "�ۑ��Ɏ��s���܂����B" + "\r\n"
                                    + "\r\n" +
                                    "�V�F�A�`�F�b�N�G���[�i�q�Ƀ��b�N�j�ł��B" + "\r\n" +
                                    "�I���������A���̑��̍݌ɋƖ����s���Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n" +
                                    "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                    status,
                                    MessageBoxButtons.OK);
                        return (false);
                    }
                case -1:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "�Y���f�[�^�����݂��܂���B",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);
                        return (false);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                       "StockArrivalGoodsInputSave",
                                       "�ۑ��Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);
                        return (false);
                    }
            }

            return (true);
        }

        /// <summary>
        /// �݌Ɉړ����͉�ʎ����ɖ߂�����
        /// </summary>
        private void StockMoveInputRetry()
        {
            if (!_StockMoveInput.CompareBeforeRetry())
            {
                DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                      "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                                                      "������Ԃɖ߂��܂����H",
                                                      0,
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxDefaultButton.Button1);

                if (res != DialogResult.Yes)
                {
                    return;
                }

                _StockMoveInput.RetryProc();

                //// �c�[���o�[�{�^���̏�����
                //this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                //this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;

                //// �w�b�_�̏����폜
                //this._StockMoveInputInitAcs.StockMoveHeaderClear();
                //this._StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                //// ��ʂ̏�����
                //this._StockMoveInput.HeaderClear();

                //// �f�[�^�e�[�u���̓��e���폜
                //this._StockMoveInput.Clear();

            }
        }

        /// <summary>
        /// �݌Ɉړ����ד��͉�ʎ����ɖ߂�����
        /// </summary>
        private void StockArrivalGoodsInputRetry()
        {
            if (!this._StockMoveArrivalGoodsInput.CompareBeforeRetry())
            {
                DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                      "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                                                      "������Ԃɖ߂��܂����H",
                                                      0,
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxDefaultButton.Button1);


                if (res != DialogResult.Yes)
                {
                    return;
                }

                _StockMoveArrivalGoodsInput.RetryProc();
                //// �w�b�_�̏����폜
                //this._StockMoveInputInitAcs.StockMoveHeaderClear();
                //this._StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                //// ��ʂ̏�����
                //this._StockMoveArrivalGoodsInput.HeaderClear();

                //// �f�[�^�e�[�u���̓��e���폜
                //this._StockMoveArrivalGoodsInput.Clear();
            }
        }

        /// <summary>
        /// FormClosing �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void MAZAI04100UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._StockMoveInput != null)
            {
                this._StockMoveInput.Close();
            }
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
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // �e�E�B���h�E�t�H�[��
                                         errLevel,                          // �G���[���x��
                                         "MAZAI04100U",                     // �A�Z���u��ID
                                         message,                           // �\�����郁�b�Z�[�W
                                         status,                            // �X�e�[�^�X�l
                                         msgButton,                         // �\������{�^��
                                         defaultButton);                    // �����\���{�^��
            return dialogResult;
        }

        /// <summary>
        /// ���b�Z�[�W�{�b�N�X�\������
        /// </summary>
        /// <param name="errLevel">�G���[���x��</param>
        /// <param name="methodName">��������</param>
        /// <param name="message">�\�����郁�b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X�l</param>
        /// <param name="msgButton">�\������{�^��</param>
        /// <returns>DialogResult</returns>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // �e�E�B���h�E�t�H�[��
                                         errLevel,			                // �G���[���x��
                                         this.Name,						    // �v���O��������
                                         "MAZAI04100U", 		  �@�@		// �A�Z���u��ID
                                         methodName,						// ��������
                                         "",					            // �I�y���[�V����
                                         message,	                        // �\�����郁�b�Z�[�W
                                         status,							// �X�e�[�^�X�l
                                         this._StockMoveInputAcs,			// �G���[�����������I�u�W�F�N�g
                                         msgButton,         			  	// �\������{�^��
                                         MessageBoxDefaultButton.Button1);	// �����\���{�^��

            return dialogResult;
        }

        /// <summary>
        /// �I���{�^���N���b�N�C�x���g(Esc�L�[���N���b�N���ꂽ���ɔ������܂�)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            // �{�^�����uVisible = False�v�ɂ���ƁA�C�x���g���������Ȃ����߁A
            // �T�C�Y���u1, 1�v�ɂ��A�����I�Ɍ����Ȃ��悤�ɂ���

            DialogResult dResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "�I�����Ă���낵���ł����H",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

            if (dResult == DialogResult.Yes)
            {
                this.Close(true);
            }
        }

        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        #region DEL Partsman�p�ɕύX
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �݌Ɉړ����͉�ʎ��ۑ�����
        /// </summary>
        /// <return>
        /// true: �o�^����, false: �o�^���s
        /// </return>
        /// <remarks>
        /// Note       : �݌Ɉړ����͉�ʎ��ɕۑ��{�^�����������ꂽ�ۂɍs���鏈���ł��B<br />
        /// Programer  : 20008 �ɓ� �L<br />
        /// Date       : 2007.01.26<br />
        /// </remarks>
        private Boolean StockMoveInputSave()
        {
            // �ړ����q�ɃR�[�h���̓`�F�b�N
            if (_StockMoveInput.bfEnterwarehCodeCheck() == false)
            {
                return false;
            }

            Boolean saveCheck = false;

            foreach (StockMoveInputDataSet.StockMoveRow row in _StockMoveDataTable)
            {
                if ( row.GoodsNo != null && row.GoodsNo != "" )
                {
                    saveCheck = true;
                }
            }

            // �P���R�[�h�ł����i�R�[�h������̂�����Γo�^
            if (saveCheck == true)
            {
                // �݌Ɉړ��f�[�^�o�^ 
                int status = _StockMoveInputAcs.WriteStockMove();

                if (status == 0)
                {
                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                    dialog.ShowDialog(2);

                    // �ۑ��ɐ���������X�V���[�h��V�K�ɕύX
                    _StockMoveInputInitAcs.RegistMode = 0;

                    // ��ʂ�������
                    _StockMoveInputInitAcs.StockMoveHeaderClear();

                    return true;

                }
                else if (status == 5)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�݌ɐ��ʂ��s�����Ă��܂��B",
                        status,
                        MessageBoxButtons.OK);

                    return false;
                }
                else if (status == -2)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�X�V�f�[�^���Ɋ��Ɋm��ς̃f�[�^�����݂��܂��B",
                        status,
                        MessageBoxButtons.OK);

                    return false;
                }
                else if (status == -3)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "����q�ɂւ̍݌Ɉړ������͂ł��܂���B",
                        status,
                        MessageBoxButtons.OK);

                    return false;
                }
                else if (status == -4)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�o�^���郌�R�[�h���ɏo�א�0�����݂��܂��B",
                        status,
                        MessageBoxButtons.OK);

                    return false;
                }
                else if (status == -5)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�}�X�^�ɓo�^����Ă��Ȃ����[�J�[�R�[�h�����݂��܂��B",
                        status,
                        MessageBoxButtons.OK);

                    return false;
                }
                else if (status == -6)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�}�X�^�ɓo�^����Ă��Ȃ�BL���i�R�[�h�����݂��܂��B",
                        status,
                        MessageBoxButtons.OK);

                    return false;
                }
                else if (status == -9)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�X�V�f�[�^���Ɋ��ɓ��׍ς̃f�[�^�����݂��܂��B",
                        status,
                        MessageBoxButtons.OK);

                    return false;
                }
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�ۑ��Ɏ��s���܂����B(" + status + ")",
                        status,
                        MessageBoxButtons.OK);

                    return false;

                }
            }
            // ������Γo�^�f�[�^�͂Ȃ�
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�ۑ�����f�[�^�����݂��܂���B",
                    -1,
                    MessageBoxButtons.OK);

                return false;
            }
        }
        
        /// <summary>
        /// �݌Ɉړ��m���ʎ��ۑ�����
        /// </summary>
        /// <return>
        /// true: �o�^����, false: �o�^���s
        /// </return>
        /// <remarks>
        /// Note       : �݌Ɉړ��m���ʎ��ɕۑ��{�^�����������ꂽ�ۂɍs���鏈���ł��B<br />
        /// Programer  : 20008 �ɓ� �L<br />
        /// Date       : 2007.01.26<br />
        /// </remarks>
        private Boolean StockMoveFixInputSave()
        {
            // �o�^�f�[�^�`�F�b�N
            if (_StockMoveDataTable.Count == 0)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�ۑ�����f�[�^�����݂��܂���B",
                    -1,
                    MessageBoxButtons.OK);

                return false;
            }

            int status = _StockMoveInputAcs.WriteStockMoveFix();

            if (status == 0)
            {
                SaveCompletionDialog dialog = new SaveCompletionDialog();
                dialog.ShowDialog(2);

                return true;

            }
            else if (status == -1)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�Y���f�[�^������܂���B",
                    -1,
                    MessageBoxButtons.OK);

                return false;
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�ۑ��Ɏ��s���܂����B(" + status + ")",
                    status,
                    MessageBoxButtons.OK);

                return false;

            }
        }

        /// <summary>
        /// �݌Ɉړ����ד��͉�ʎ��ۑ�����
        /// </summary>
        /// <return>
        /// true: �o�^����, false: �o�^���s
        /// </return>
        /// <remarks>
        /// Note       : �݌Ɉړ����ד��͉�ʎ��ɕۑ��{�^�����������ꂽ�ۂɍs���鏈���ł��B<br />
        /// Programer  : 20008 �ɓ� �L<br />
        /// Date       : 2007.01.26<br />
        /// </remarks>
        private Boolean StockArrivalGoodsInputSave()
        {
            // �o�^�f�[�^�`�F�b�N
            if (_StockMoveDataTable.Count == 0)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�ۑ�����f�[�^�����݂��܂���B",
                    -1,
                    MessageBoxButtons.OK);

                return false;
            }

            int status = _StockMoveInputAcs.WriteStockMoveArrival();

            if (status == 0)
            {
                SaveCompletionDialog dialog = new SaveCompletionDialog();
                dialog.ShowDialog(2);

                return true;

            }
            else if (status == -1)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�Y���f�[�^������܂���B",
                    -1,
                    MessageBoxButtons.OK);

                return false;
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�ۑ��Ɏ��s���܂����B(" + status + ")",
                    status,
                    MessageBoxButtons.OK);

                return false;

            }
        }

        /// <summary>
        /// �݌Ɉړ����͉�ʎ����ɖ߂�����
        /// </summary>
        /// <remarks>
        /// Note       : �݌Ɉړ����͉�ʎ��Ɍ��ɖ߂��{�^�����������ꂽ�ۂɍs���鏈���ł��B<br />
        /// Programer  : 20008 �ɓ� �L<br />
        /// Date       : 2007.02.20<br />
        /// </remarks>
        private void StockMoveInputRetry()
        {
            if (_StockMoveInput.CloseDataCheck())
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                    "������Ԃɖ߂��܂����H",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }

                // �c�[���o�[�{�^���̏�����
                this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = true;

                // �ړ��`�[�o�̓{�^�����\��
                this.ToolbarsManager_Main.Tools["ButtonTool_OutPut"].SharedProps.Enabled = false;

                // �w�b�_�̏����폜
                _StockMoveInputInitAcs.StockMoveHeaderClear();
                _StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                // ��ʂ̏�����
                _StockMoveInput.HeaderClear();

                // �f�[�^�e�[�u���̓��e���폜
                _StockMoveInput.Clear();

            }
            else
            {
                // �c�[���o�[�{�^���̏�����
                this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = true;

                // �ړ��`�[�o�̓{�^�����\��
                this.ToolbarsManager_Main.Tools["ButtonTool_OutPut"].SharedProps.Enabled = false;

                // �w�b�_�̏����폜
                _StockMoveInputInitAcs.StockMoveHeaderClear();
                _StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                // ��ʂ̏�����
                _StockMoveInput.HeaderClear();

                // �f�[�^�e�[�u���̓��e���폜
                _StockMoveInput.Clear();
            }
        }

        /// <summary>
        /// �݌Ɉړ��m���ʎ����ɖ߂�����
        /// </summary>
        /// <remarks>
        /// Note       : �݌Ɉړ��m���ʎ��Ɍ��ɖ߂��{�^�����������ꂽ�ۂɍs���鏈���ł��B<br />
        /// Programer  : 20008 �ɓ� �L<br />
        /// Date       : 2007.02.20<br />
        /// </remarks>
        private void StockMoveFixInputRetry()
        {
            if (_StockMoveFixInput.CloseDataCheck())
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                    "������Ԃɖ߂��܂����H",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }

                // �w�b�_�̏����폜
                _StockMoveInputInitAcs.StockMoveHeaderClear();
                _StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                // ��ʂ̏�����
                _StockMoveFixInput.HeaderClear();

                // �f�[�^�e�[�u���̓��e���폜
                _StockMoveFixInput.Clear();

            }
        }

        /// <summary>
        /// �݌Ɉړ����ד��͉�ʎ����ɖ߂�����
        /// </summary>
        /// <remarks>
        /// Note       : �݌Ɉړ����ד��͉�ʎ��Ɍ��ɖ߂��{�^�����������ꂽ�ۂɍs���鏈���ł��B<br />
        /// Programer  : 20008 �ɓ� �L<br />
        /// Date       : 2007.02.20<br />
        /// </remarks>
        private void StockArrivalGoodsInputRetry()
        {
            if (_StockMoveArrivalGoodsInput.CloseDataCheck())
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                    "������Ԃɖ߂��܂����H",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }

                // �w�b�_�̏����폜
                _StockMoveInputInitAcs.StockMoveHeaderClear();
                _StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                // ��ʂ̏�����
                _StockMoveArrivalGoodsInput.HeaderClear();

                // �f�[�^�e�[�u���̓��e���폜
                _StockMoveArrivalGoodsInput.Clear();
            }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman�p�ɕύX

        #region DEL 2008/07/14 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// OPOS�r���A�N�Z�X���擾
        /// </summary>
        private void GetOLEControlClaim()
        {
            //#region < OPOS�r���A�N�Z�X���擾 >
            //int OPOSstatus = (int)OPOSConstantManagement.emOPOS.OPOS_E_NOSERVICE;
            //string message = "";

            //// OPOS�̔r���A�N�Z�X�����擾
            //OPOSstatus = this._olePrtController.ClaimDevice(0, ref message);
            //if (OPOSstatus != (int)OPOSConstantManagement.emOPOS.OPOS_SUCCESS)
            //{
            //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
            //                "MAZAI04100U",
            //                "�r���A�N�Z�X���̎擾�Ɏ��s���܂����B\n" + message,
            //                OPOSstatus,
            //                MessageBoxButtons.OK);
            //    return;
            //}
            //#endregion

            //#region < �f�o�C�X�g�p�敪(True) >
            //// �f�o�C�X���g�p���邽�߂̃v���p�e�B��True�ɂ���
            //this._olePrtController.DeviceEnabled = true;
            //#endregion
        }

        /// <summary>
        /// OPOS�r���A�N�Z�X���j��
        /// </summary>
        private void ReleaseOLEControlClaim()
        {
            //#region < OPOS�r���A�N�Z�X���J�� >
            //string errMessage = "";
            //this._olePrtController.DeviceEnabled = false;
            //this._olePrtController.ReleaseDevice(ref errMessage);
            //#endregion
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        # endregion

        //----- ADD K2013/09/11 �c���� ---------->>>>>
        #region ���t�^�o�ʑΉ���
        #region ���񋓑́�
        /// <summary>
        /// �I�v�V�����L���L��
        /// </summary>
        public enum Option : int
        {
            /// <summary>����</summary>
            OFF = 0,
            /// <summary>�L��</summary>
            ON = 1,
        }
        #endregion

        #region ���I�v�V�������L���b�V����
        /// <summary>
        /// �I�v�V�������L���b�V��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�v�V������񐧌䏈���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : K2013/09/11</br>
        /// </remarks>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

            #region ���t�^�o�o�͍ϓ`�[����i�ʁj
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaOutSlipCtl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FutabaCtrl = (int)Option.ON;
            }
            else
            {
                this._opt_FutabaCtrl = (int)Option.OFF;
            }
            #endregion
        }
        #endregion

        #region ���t�^�o����ړ��o�̓f�[�^�̎擾��
        /// <summary>
        /// �t�^�o����ړ��o�̓f�[�^�̎擾
        /// </summary>
        /// <param name="stockMoveSlipNo">�݌Ɉړ��`�[�ԍ�</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �t�^�o����ړ��o�̓f�[�^���擾����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : K2013/09/11</br>
        /// </remarks>
        private bool CheckStockMoveData(int stockMoveSlipNo)
        {
            bool canSaveFlg = true;
            // �I�v�V�������L���b�V��
            CacheOptionInfo();

            if (_opt_FutabaCtrl == (int)Option.ON)
            {
                int status = this._StockMoveInputAcs.CheckFTStockMoveData(stockMoveSlipNo);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    canSaveFlg = false;
                }
            }

            return canSaveFlg;
        }
        #endregion
        #endregion
        //----- ADD K2013/09/11 �c���� ----------<<<<<
    }
}
