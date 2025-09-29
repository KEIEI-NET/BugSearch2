//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����񓚕i�ڐݒ�}�X�^�����e�i���X
// �v���O�����T�v   : �����񓚕i�ڐݒ�}�X�^�̑�����s���܂�
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g�� �F��
// �� �� ��  2012/10/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g���@�F��
// �� �� ��  2012/11/13  �C�����e : 12/12�z�M �V�X�e���e�X�g��Q��6�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g���@�F��
// �� �� ��  2012/11/16  �C�����e : 12/12�z�M �V�X�e���e�X�g��Q��32,38,37,39�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 �O�� �L��
// �� �� ��  2012/11/22  �C�����e : 2012/12/12�z�M�\��V�X�e���e�X�g��Q��58�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 �O�� �L��
// �� �� ��  2012/11/22  �C�����e : 2012/12/12�z�M�\��V�X�e���e�X�g��Q��77�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Infragistics.Win.Misc;
using System.Collections.Generic;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �����񓚕i�ڐݒ�}�X�^�����e�i���X�ҏW�t�H�[��
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����񓚕i�ڐݒ�}�X�^�̓��͂��s���܂��B</br>
    /// <br>Update Note: </br>
    /// <br></br>
    /// </remarks>
    public partial class PMKHN09701UB : System.Windows.Forms.Form
    {
        #region Private Menbers

        private string _enterpriseCode;         // ��ƃR�[�h

        // �t�h�z�u�p�i�J�n�ʒu�j
        // UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��38 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        // private const int ct_PositionStart = 119;
        private const int ct_PositionStart = 122;
        // UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��38 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        // �t�h�z�u�p�i�Ԋu�j
        // UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��38 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        // private const int ct_Interval = 4;
        private const int ct_Interval = 8;
        // UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��38 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // �����񓚕i�ڐݒ�A�N�Z�X�N���X
        private AutoAnsItemStAcs _autoAnsItemStAcs;
        // �����񓚕i�ڐݒ�}�X�����p�K�C�h����N���X
        private AutoAnsItemStGuideControl _guideControl;

        // ���_�R�[�h�i�O��l�j
        private string _prevSectionCode;
        // ���Ӑ�R�[�h�i�O��l�j
        private int _prevCustomerCode;
        // ���[�J�[�R�[�h�i�O��l�j
        private int _prevGoodsMakerCd;
        // ���i�����ރR�[�h�i�O��l�j
        private int _prevGoodsMGroup;
        // �a�k�R�[�h�i�O��l�j
        private int _prevBLGoodsCode;

        // �ҏW�����R�[�hGUID
        private Guid _recordGuid;
        // �O���b�h�@�f�[�^�\�[�X�p
        DataView _view = null;

        // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        private bool _GridEnterUP = true;
        // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        // �I�����̕ҏW�`�F�b�N�p
        private List<AutoAnsItemSt> _recordCloneList = new List<AutoAnsItemSt>();
        // �ҏW�����R�[�h
        private List<AutoAnsItemSt> _autoAnsItemStList = new List<AutoAnsItemSt>();

        // Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        private const string DELETE_DATE_TITLE = "�폜��";
        private const string SECTIONCODE_TITLE = "���_�R�[�h";
        private const string SECTIONGUIDENM_TITLE = "���_��";
        private const string SUBSECTIONCODE_TITLE = "�����񓚕i�ڐݒ�R�[�h";
        private const string SUBSECTIONNAME_TITLE = "�����񓚕i�ڐݒ薼";

        // ��ʃ��C�A�E�g�p�萔
        private const int BUTTON_LOCATION1_X = 196;     // ���S�폜�{�^���ʒuX
        private const int BUTTON_LOCATION2_X = 323;     // �����{�^���ʒuX
        private const int BUTTON_LOCATION3_X = 450;     // �ۑ��{�^���ʒuX
        private const int BUTTON_LOCATION4_X = 577;     // ����{�^���ʒuX
        private const int BUTTON_LOCATION_Y = 8;        // �{�^���ʒuY(����)

        // Message�֘A��`
        private const string ASSEMBLY_ID = "PMKHN09700U";
        private const string ERR_READ_MSG = "�ǂݍ��݂Ɏ��s���܂����B";
        private const string ERR_DPR_MSG = "���͂��ꂽ�i�ڐݒ�͊��ɓo�^����Ă��܂��B�ҏW���s���܂����H";
        private const string ERR_RDEL_MSG = "�폜�Ɏ��s���܂����B";
        private const string ERR_UPDT_MSG = "�o�^�Ɏ��s���܂����B";
        private const string ERR_RVV_MSG = "�����Ɏ��s���܂����B";
        private const string ERR_800_MSG = "���ɑ��[�����X�V����Ă��܂�";
        private const string ERR_801_MSG = "���ɑ��[�����폜����Ă��܂�";
        private const string SDC_RDEL_MSG = "�}�X�^����폜����Ă��܂�";

        // �O���b�h�֘A
        /// <summary> �O���b�h�p�e�[�u������ </summary>
        private const string ct_TABLE_FORGRID = "ForGrid";
        
        #endregion

        #region �v���p�e�B
        /// <summary>
        /// �ۑ����s�ς݃t���O
        /// </summary>
        private bool _isSave = false;
        /// <summary>
        /// �ۑ����s�ς݃t���O
        /// </summary>
        public bool IsSave
        {
            get
            {
                return _isSave;
            }
        }
        #endregion

        # region Constructor

        /// <summary>
        /// �����񓚕i�ڐݒ�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// </remarks>
        public PMKHN09701UB( AutoAnsItemStAcs scmPrtSettingAcs, AutoAnsItemStGuideControl scmPrtSettingGuideControl )
        {
            InitializeComponent();

            // �e��C���X�^���X���󂯎��
            _autoAnsItemStAcs = scmPrtSettingAcs;
            _guideControl = scmPrtSettingGuideControl;
            _guideControl.AfterRenewal += new EventHandler( GuideControl_AfterRenewal );

            // ��ƃR�[�h���擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �\���X�V
            tComboEditor_SetKind1.Value = 1; //1:���_
            DrawPanelsBySetKind1();

            // ���_�R�[�h�i�O��l�j
            _prevSectionCode = string.Empty;
            // ���Ӑ�R�[�h�i�O��l�j
            _prevCustomerCode = 0;
            // ���[�J�[�R�[�h�i�O��l�j
            _prevGoodsMakerCd = 0;
            // ���i�����ރR�[�h�i�O��l�j
            _prevGoodsMGroup = 0;
            // �a�k�R�[�h�i�O��l�j
            _prevBLGoodsCode = 0;

            // �ҏW�����R�[�h��GUID�ƃ��R�[�h
            _recordGuid = Guid.Empty;
            _autoAnsItemStList = new List<AutoAnsItemSt>();
        }

        /// <summary>
        /// �ŐV���擾�㏈��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuideControl_AfterRenewal( object sender, EventArgs e )
        {
            // �O��l�N���A
            _prevSectionCode = string.Empty;
            _prevCustomerCode = 0;
            _prevGoodsMGroup = 0;
            _prevBLGoodsCode = 0;
            _prevGoodsMakerCd = 0;

            // ���̍Ď擾
            // ���_
            MasterRead( ref tEdit_SectionCodeAllowZero, ref tEdit_SectionGuideNm, ref _prevSectionCode, ReadSection );
            // ���Ӑ�
            MasterRead( ref tNedit_CustomerCode, ref tEdit_CustomerName, ref _prevCustomerCode, ReadCustomer );
            // ���i������
            MasterReadForGoodsMGroup(ref tEdit_GoodsMGroup, ref tEdit_GoodsMGroupName, ref _prevGoodsMGroup, ReadGoodsMGroup);
            // �a�k�R�[�h
            MasterReadForBlGoodsCode( ref tNedit_BLGoodsCode, ref tEdit_BLCodeName, ref _prevBLGoodsCode, ReadBLCode );
            // ���[�J�[
            MasterRead(ref tNedit_GoodsMakerCd, ref tEdit_GoodsMakerName, ref _prevGoodsMakerCd, ReadMaker);
        }

        /// <summary>
        /// �p�l���R���g���[���`�揈��
        /// </summary>
        private void DrawPanelsBySetKind1()
        {
            int currPosition = ct_PositionStart;

            // �S��or���_or���Ӑ�
            switch ( (int)tComboEditor_SetKind1.Value )
            {
                // 0:�S��
                default:
                case 0:
                    panel_Section.Visible = false;
                    panel_Section.Enabled = false;
                    panel_Customer.Visible = false;
                    panel_Customer.Enabled = false;
                    panel_Line.Visible = false;
                    break;
                // 1:���_
                case 1:
                    panel_Section.Visible = true;
                    panel_Section.Enabled = true;
                    panel_Customer.Visible = false;
                    panel_Customer.Enabled = false;
                    panel_Line.Visible = true;

                    panel_Section.Top = currPosition;
                    currPosition += panel_Section.Height + ct_Interval;
                    panel_Line.Top = currPosition;
                    currPosition += panel_Line.Height + ct_Interval;
                    break;
                // 2:���Ӑ�
                case 2:
                    panel_Section.Visible = false;
                    panel_Section.Enabled = false;
                    panel_Customer.Visible = true;
                    panel_Customer.Enabled = true;
                    panel_Line.Visible = true;

                    panel_Customer.Top = currPosition;
                    currPosition += panel_Customer.Height + ct_Interval;
                    panel_Line.Top = currPosition;
                    currPosition += panel_Line.Height + ct_Interval;
                    break;
            }

            // �N���A
            PanelClear(panel_Section);
            PanelClear(panel_Customer);

            // ���_
            if (panel_Section.Enabled)
            {
                string sectionCode = tEdit_SectionCodeAllowZero.Text.Trim();
                if (sectionCode == string.Empty || sectionCode == "00")
                {
                    tEdit_SectionCodeAllowZero.Text = "00";
                    tEdit_SectionGuideNm.Text = "�S��";
                }
            }

            // ���i������
            if (panel_GoodsMGroup.Enabled)
            {
                string goodsMGroup = tEdit_GoodsMGroup.Text.Trim();
                if (goodsMGroup == string.Empty || goodsMGroup == "0000")
                {
                    tEdit_GoodsMGroup.Text = "0000";
                    tEdit_SectionGuideNm.Text = "����";
                }
            }

            // ���̏����������Ď��s
            DrawPanelsBySetKind2();
        }
        /// <summary>
        /// �p�l���R���g���[���`�揈��
        /// </summary>
        private void DrawPanelsBySetKind2()
        {
            # region [�J�n�ʒu]
            int currPosition;
            if ( (int)tComboEditor_SetKind1.Value != 0 )
            {
                currPosition = panel_Line.Top + panel_Line.Height + ct_Interval;
            }
            else
            {
                currPosition = ct_PositionStart;
            }
            # endregion

            # region [�\���E��\������]
            bool blCodeEnabled = false;

            // ���[�J�[,������,�a�k�R�[�h,�i��
            switch ( (int)tComboEditor_SetKind2.Value )
            {
                // 2:�����ށ{BL�R�[�h
                case 2:
                    blCodeEnabled = true;
                    break;
            }
            # endregion

            # region [�R���g���[���̔z�u]
            // ���i������
            panel_GoodsMGroup.Top = currPosition;
            currPosition += panel_GoodsMGroup.Height + ct_Interval;

            // �a�k�R�[�h
            if ( blCodeEnabled )
            {
                panel_BLCode.Top = currPosition;
                currPosition += panel_BLCode.Height + ct_Interval;
            }
            panel_BLCode.Enabled = blCodeEnabled;
            panel_BLCode.Visible = blCodeEnabled;

            // ���[�J�[
            panel_GoodsMaker.Top = currPosition;
            currPosition += panel_GoodsMaker.Height + ct_Interval;

            // �����񓚋敪
            panel_AutoAnswerDiv.Top = currPosition;
            currPosition += panel_AutoAnswerDiv.Height + ct_Interval;

            // �D�揇��
            panel_Priority.Top = currPosition;
            currPosition += panel_Priority.Height + ct_Interval;

            // �O���b�h
            // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��8 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // panel_Grid.Top = currPosition;
            int btm = panel_Grid.Bottom;
            panel_Grid.Top = currPosition;
            panel_Grid.Height += btm - panel_Grid.Bottom;
            currPosition += panel_Grid.Height + ct_Interval;
            // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��8 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            # endregion

            # region [�p�l�����̃N���A]
            // �p�l�����N���A
            PanelClear(panel_GoodsMGroup);
            PanelClear(panel_BLCode);
            PanelClear(panel_GoodsMaker);
            SetAutoAnswerDivEnabled(false);
            PanelClear(panel_AutoAnswerDiv);
            PanelClear(panel_Priority);
            PanelClear(panel_Grid);
            # endregion
        }

        /// <summary>
        /// �p�l���̃N���A����
        /// </summary>
        /// <param name="panel">�Ώۃp�l��</param>
        private void PanelClear(Panel panel)
        {
            // �p�l�����N���A
            ClearEditOnPanel(panel);

            // �O��l�̃N���A
            if (panel.Equals(panel_Section))
            {
                _prevSectionCode = string.Empty;
            }
            else if (panel.Equals(panel_Customer))
            {
                _prevCustomerCode = 0;
            }
            else if (panel.Equals(panel_GoodsMGroup))
            {
                tEdit_GoodsMGroup.Text = "0000";
                tEdit_GoodsMGroupName.Text = "����";
                _prevGoodsMGroup = 0;
            }
            else if (panel.Equals(panel_BLCode))
            {
                _prevBLGoodsCode = 0;
            }
            else if (panel.Equals(panel_GoodsMaker))
            {
                _prevGoodsMakerCd = 0;
            }
            else if (panel.Equals(panel_AutoAnswerDiv))
            {
                tComboEditor_AutoAnswerDivInitial();
            }
            else if(panel.Equals(panel_Grid))
            {
                GridNew();
            }
        }
        /// <summary>
        /// �p�l�����G�f�B�b�g�N���A����
        /// </summary>
        /// <param name="panel"></param>
        private void ClearEditOnPanel( Panel panel )
        {
            // ��ʓI�ɂ͍ċA�������K�v�����A���I�ɕs�v�Ȃ̂��������Ă���̂Ŋȗ���
            foreach ( Control ctrl in panel.Controls )
            {
                // TNEdit��TEdit���p������̂�,���̔���Ɋ܂܂��
                if ( ctrl is TEdit )
                {
                    // ���̓N���A
                    (ctrl as TEdit).Clear();
                }
                else if (ctrl is TComboEditor)
                {
                    (ctrl as TComboEditor).Items.Clear();
                }
                else if (ctrl is UltraGrid)
                {
                    GridNew();
                }
            }
        }
        # endregion

        # region Properties

        /// <summary>
        /// �ҏW�����R�[�h�f�t�h�c
        /// </summary>
        public Guid RecordGuid
        {
            get { return _recordGuid; }
            set { _recordGuid = value; }
        }

        # endregion

        # region [private delegate]
        /// <summary>
        /// �e��}�X�^�ǂݍ��݃f���Q�[�g�i���l�R�[�h�p�j
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private delegate bool MasterReadForNumber(ref int code, out string name);
        /// <summary>
        /// �e��}�X�^�ǂݍ��݁i�f���Q�[�gBL�R�[�h�p�j
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private delegate bool MasterReadForBlCode(ref int code, out string name,out int goodsMGroup);
        /// <summary>
        /// �e��}�X�^�ǂݍ��݃f���Q�[�g�i������R�[�h�p�j
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private delegate bool MasterReadForText( ref string code, out string name );
        # endregion

        # region Private Methods
        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��N���A���܂��B</br>
        /// </remarks>
        private void ScreenClear()
        {
            // ���[�h���x��
            this.Mode_Label.Text = INSERT_MODE;

            // �{�^��
            this.Delete_Button.Visible  = true;  // ���S�폜�{�^��
            this.Revive_Button.Visible  = true;  // �����{�^��
            this.Ok_Button.Visible      = true;  // �ۑ��{�^��
            this.Cancel_Button.Visible = true;  // ����{�^��
            this.Renewal_Button.Visible = true;  // �ŐV���{�^��
            this.Delete_Button.Location = new Point(BUTTON_LOCATION1_X, BUTTON_LOCATION_Y); // ���S�폜�{�^���ʒu
            this.Revive_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // �����{�^���ʒu
            this.Ok_Button.Location     = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // �ۑ��{�^���ʒu
            this.Cancel_Button.Location = new Point(BUTTON_LOCATION4_X, BUTTON_LOCATION_Y); // ����{�^���ʒu
            this.Renewal_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // �����{�^���ʒu

            // ���_��
            this.tEdit_SectionCodeAllowZero.Text = "00";
            this.tEdit_SectionGuideNm.Text = "�S��";

            // ���i������
            this.tEdit_GoodsMGroup.Text = "0000";
            this.tEdit_GoodsMGroupName.Text = "����";
        }

        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            if ( this.RecordGuid == null || this.RecordGuid == Guid.Empty )
            {
                // �V�K
                _autoAnsItemStList = new List<AutoAnsItemSt>();
                ScreenInputPermissionControl( 0 );
            }
            else
            {
                // ���R�[�h�擾
                AutoAnsItemSt autoAnsItemSt = _autoAnsItemStAcs.GetRecordForMaintenance(this.RecordGuid);
                _autoAnsItemStList = _autoAnsItemStAcs.GetRecordListForMaintenance(GetFilter(autoAnsItemSt),this.uGrid_Details2.Rows.Count);

                if ( _autoAnsItemStList[0].LogicalDeleteCode == 0 )
                {
                    // �X�V
                    ScreenInputPermissionControl( 1 );
                }
                else
                {
                    // �폜
                    ScreenInputPermissionControl( 2 );
                }
            }
        }

        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^���R�[�h����A���������̍쐬
        /// �����L�[
        /// </summary>
        /// <param name="r">�����񓚕i�ڐݒ�}�X�^���R�[�h</param>
        /// <returns>
        /// ��������������@�����L�[�F��ƃR�[�h�A���_�R�[�h�A���Ӑ�R�[�h
        /// ���i�����ރR�[�h�ABL���i�R�[�h�A���i���[�J�[�R�[�h
        /// </returns>
        private string GetFilter(AutoAnsItemSt r)
        {
            return string.Format(
                "{0}='{1}' AND " +
                "{2}='{3}' AND " +
                "{4}='{5}' AND " +
                "{6}='{7}' AND " +
                "{8}='{9}' AND " +
                "{10}='{11}' "
                , AutoAnsItemStAcs.ct_COL_ENTERPRISECODE, r.EnterpriseCode.ToString()
                , AutoAnsItemStAcs.ct_COL_SECTIONCODE, r.SectionCode
                , AutoAnsItemStAcs.ct_COL_CUSTOMERCODE, r.CustomerCode
                , AutoAnsItemStAcs.ct_COL_GOODSMGROUP, r.GoodsMGroup
                , AutoAnsItemStAcs.ct_COL_BLGOODSCODE, r.BLGoodsCode
                , AutoAnsItemStAcs.ct_COL_GOODSMAKERCD, r.GoodsMakerCd);
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="setType">�ݒ�^�C�v 0:�e-�V�K, 1:�e-�X�V, 2:�e-�폜, 3:�q-�V�K, 4:�q-�X�V, 5:�q-�폜</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// </remarks>
        private void ScreenInputPermissionControl(int setType)
        {
            int setKind1;
            int setKind2;

            switch ( setType )
            {
                // 0:�V�K
                default:
                case 0:
                    // �{�^��
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Renewal_Button.Visible = true;

                    // �p�l��
                    this.panel_SetKind.Enabled = true;
                    this.panel_Section.Enabled = true;
                    this.panel_Customer.Enabled = true;
                    this.panel_GoodsMaker.Enabled = true;
                    this.panel_GoodsMGroup.Enabled = true;
                    this.panel_BLCode.Enabled = true;
                    this.panel_AutoAnswerDiv.Enabled = true;

                    break;
                // 1:�X�V
                case 1:
                    // �ݒ��ʎ擾
                    GetSetKind( _autoAnsItemStList[0], out setKind1, out setKind2 );
                    tComboEditor_SetKind1.Value = setKind1;
                    tComboEditor_SetKind2.Value = setKind2;

                    // �{�^��
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = false;
                    this.Delete_Button.Visible = false;
                    this.Renewal_Button.Visible = true;

                    // �p�l��
                    this.panel_SetKind.Enabled = false;
                    this.panel_Section.Enabled = false;
                    this.panel_Customer.Enabled = false;
                    this.panel_GoodsMaker.Enabled = false;
                    this.panel_GoodsMGroup.Enabled = false;
                    this.panel_BLCode.Enabled = false;
                    this.panel_AutoAnswerDiv.Enabled = true;

                    break;
                // 2:�폜
                case 2:
                    // �ݒ��ʎ擾
                    GetSetKind(_autoAnsItemStList[0], out setKind1, out setKind2);
                    tComboEditor_SetKind1.Value = setKind1;
                    tComboEditor_SetKind2.Value = setKind2;

                    // �{�^��
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.Ok_Button.Visible = false;
                    this.Renewal_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Location = new Point( BUTTON_LOCATION2_X, BUTTON_LOCATION_Y ); // ���S�폜�{�^���ʒu
                    this.Revive_Button.Location = new Point( BUTTON_LOCATION3_X, BUTTON_LOCATION_Y ); // �����{�^���ʒu
                    this.Cancel_Button.Location = new Point( BUTTON_LOCATION4_X, BUTTON_LOCATION_Y ); // ����{�^���ʒu

                    // �p�l��
                    this.panel_SetKind.Enabled = false;
                    this.panel_Section.Enabled = false;
                    this.panel_Customer.Enabled = false;
                    this.panel_GoodsMaker.Enabled = false;
                    this.panel_GoodsMGroup.Enabled = false;
                    this.panel_BLCode.Enabled = false;
                    this.panel_AutoAnswerDiv.Enabled = false;
                    this.panel_Grid.Enabled = false;
                    this.panel_Priority.Enabled = false;

                    break;
            }
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (_autoAnsItemStList.Count.Equals(0) || _autoAnsItemStList[0].FileHeaderGuid == null || _autoAnsItemStList[0].FileHeaderGuid == Guid.Empty)
            {
                //---------------------------------------------
                // �V�K
                //---------------------------------------------
                this.Mode_Label.Text = INSERT_MODE;

                // ��ʓW�J����
                RecordToScreen(_autoAnsItemStList);

                // �N���[���쐬
                CreateRecordCloneLIst();
                this._recordCloneList = DispToRecord(this._recordCloneList);
            }
            else if ( _autoAnsItemStList[0].LogicalDeleteCode == 0 )
            {
                //---------------------------------------------
                // �X�V
                //---------------------------------------------
                this.Mode_Label.Text = UPDATE_MODE;

                // ��ʓW�J����
                RecordToScreen( _autoAnsItemStList );

                // �N���[���쐬
                CreateRecordCloneLIst();
                this._recordCloneList = DispToRecord(this._recordCloneList);
            }
            else
            {
                //---------------------------------------------
                // �폜
                //---------------------------------------------
                this.Mode_Label.Text = DELETE_MODE;

                // ��ʓW�J����
                RecordToScreen(_autoAnsItemStList);
            }
        }

        /// <summary>
        /// ���_�N���X��ʓW�J����
        /// </summary>
        /// <param name="secInfoSet">���_�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// </remarks>
        private void SecInfoSetToScreen(SecInfoSet secInfoSet)
        {
            this.tEdit_SectionCodeAllowZero.Text = secInfoSet.SectionCode;       // ���_�R�[�h
            this.tEdit_SectionGuideNm.Text  = secInfoSet.SectionGuideNm;    // ���_����
        }

        /// <summary>
        /// �����񓚕i�ڐݒ�N���X��ʓW�J����
        /// </summary>
        /// <param name="autoAnsItemStList">�����񓚕i�ڐݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// </remarks>
        private void RecordToScreen(List<AutoAnsItemSt> autoAnsItemStList)
        {
            if (autoAnsItemStList == null ||  autoAnsItemStList.Count.Equals(0))
            {
                return;
            }

            // ���_�R�[�h�A����
            if (autoAnsItemStList[0].SectionCode.Trim() == "00" || autoAnsItemStList[0].SectionCode.Trim() == string.Empty)
            {
                this.tEdit_SectionCodeAllowZero.Text = "00";
                this.tEdit_SectionGuideNm.Text = "�S��";
            }
            else
            {
                this.tEdit_SectionCodeAllowZero.Text = autoAnsItemStList[0].SectionCode.Trim();
                this.tEdit_SectionGuideNm.Text = autoAnsItemStList[0].SectionNm.Trim();
            }

            // ���Ӑ�R�[�h
            this.tNedit_CustomerCode.SetInt(autoAnsItemStList[0].CustomerCode);

            // ���Ӑ於
            this.tEdit_CustomerName.Text = autoAnsItemStList[0].CustomerName.Trim();

            // ���i�����ރR�[�h�A����
            if (autoAnsItemStList[0].GoodsMGroup.Equals(0))
            {
                this.tEdit_GoodsMGroup.Text = "0000";
                this.tEdit_GoodsMGroupName.Text = "����";
            }
            else
            {
                this.tEdit_GoodsMGroup.Text = autoAnsItemStList[0].GoodsMGroup.ToString("0000");
                this.tEdit_GoodsMGroupName.Text = autoAnsItemStList[0].GoodsMGroupName.Trim();
            }

            // �a�k�R�[�h
            this.tNedit_BLGoodsCode.SetInt(autoAnsItemStList[0].BLGoodsCode);

            // �a�k�R�[�h��
            this.tEdit_BLCodeName.Text = autoAnsItemStList[0].BLGoodsName.Trim();

            // ���[�J�[�R�[�h
            this.tNedit_GoodsMakerCd.SetInt(autoAnsItemStList[0].GoodsMakerCd);

            // ���[�J�[��
            this.tEdit_GoodsMakerName.Text = autoAnsItemStList[0].MakerName.Trim();

            // ��ʂ̗L���i�O���b�h�̎g�p�L���j�𔻒f���邽�߁A�X�V�㏈�������{
            AfterUpdate();

            // �폜���[�h�̏ꍇ
            if (this.Mode_Label.Text == DELETE_MODE)
            {
                // �����񓚋敪���g�p�s��
                SetAutoAnswerDivEnabled(false);
            }

            if (IsUseGrid())
            {
                // �D�ǃ��[�J�[ ���@��ʂ����݂���
                foreach (DataRow row in this._view.Table.Rows)
                {
                    foreach (AutoAnsItemSt autoAnsItemSt in autoAnsItemStList)
                    {
                        if (row[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].Equals(autoAnsItemSt.PrmSetDtlNo2))
                        {
                            // �����񓚋敪
                            row[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV] = autoAnsItemSt.AutoAnswerDiv;
                            // �D�揇�� 
                            row[AutoAnsItemStAcs.ct_COL_PRIORITYORDER] = autoAnsItemSt.PriorityOrder;
                            break;
                        }
                    }
                }

                // �D�揇�ʃZ���̎g�p�ېݒ�
                foreach (UltraGridRow row in this.uGrid_Details2.Rows)
                {
                    
                    if (PMKHN09701UA.GetIntNullZero(row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Value) == 2)
                    {
                        row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Activation = Activation.AllowEdit;
                    }
                    else
                    {
                        row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Activation = Activation.Disabled;
                    }
                }
            }
            else
            {
                // �������[�J�[�@�܂��́@�D�ǃ��[�J�[����ʂ����݂��Ȃ�
                // �����񓚋敪
                this.tComboEditor_AutoAnswerDiv.Value = autoAnsItemStList[0].AutoAnswerDiv;
                // �D�揇�� "0"�͕\�����Ȃ�
                this.tNedit_PriorityOrder.SetInt(autoAnsItemStList[0].PriorityOrder);
            }
        }

        /// <summary>
        /// �O���b�h���g�p���Ă��邩�ۂ�
        /// </summary>
        /// <returns>
        /// true�F�O���b�h�g�p
        /// false�F�O���b�h�s�g�p
        /// </returns>
        private bool IsUseGrid()
        {
            // �O���b�h�̃f�[�^�\�[�X�Ƀo�C���h���Ă���r���[�̍s���Ŕ��f
            return this._view.Table.Rows.Count >= 1;
        }

        /// <summary>
        /// ��ʏ�񋒓_�N���X�i�[����
        /// </summary>
        /// <param name="secInfoSet">���_�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// </remarks>
        private void DispToSecInfoSet(ref SecInfoSet secInfoSet)
        {
            secInfoSet.SectionCode      = this.tEdit_SectionCodeAllowZero.Text;      // ���_�R�[�h
            secInfoSet.SectionGuideNm   = this.tEdit_SectionGuideNm.Text;   // ���_����
            secInfoSet.EnterpriseCode   = this._enterpriseCode;             // ��ƃR�[�h
        }

        /// <summary>
        /// ��ʏ�񎩓��񓚕i�ڐݒ�N���X�i�[����
        /// </summary>
        /// <param name="Subsection">�����񓚕i�ڐݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂玩���񓚕i�ڐݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// </remarks>
        private List<AutoAnsItemSt> DispToRecord(List<AutoAnsItemSt> autoAnsItemSt)
        {
            foreach (AutoAnsItemSt r in autoAnsItemSt)
            {
                // ��ƃR�[�h
                r.EnterpriseCode = this._enterpriseCode;

                // ���_�R�[�h
                r.SectionCode = this.GetDispValue(this.tEdit_SectionCodeAllowZero);
                // ���_��
                r.SectionNm = this.GetDispValue(this.tEdit_SectionGuideNm);
                // ���Ӑ�R�[�h
                r.CustomerCode = this.GetDispValue(this.tNedit_CustomerCode);
                // ���Ӑ於
                r.CustomerName = this.GetDispValue(this.tEdit_CustomerName);
                // ���i�����ރR�[�h
                r.GoodsMGroup = this.GetDispValueForGoodsMGroup(this.tEdit_GoodsMGroup);
                // ���i�����ޖ�
                r.GoodsMGroupName = this.GetDispValue(this.tEdit_GoodsMGroupName);
                // �a�k�R�[�h
                r.BLGoodsCode = this.GetDispValue(this.tNedit_BLGoodsCode);
                // �a�k�R�[�h��
                r.BLGoodsName = this.GetDispValue(this.tEdit_BLCodeName);
                // ���[�J�[�R�[�h
                r.GoodsMakerCd = this.GetDispValue(this.tNedit_GoodsMakerCd);
                // ���[�J�[��
                r.MakerName = this.GetDispValue(this.tEdit_GoodsMakerName);
                
                // �����񓚋敪
                r.AutoAnswerDiv = (int)this.tComboEditor_AutoAnswerDiv.Value;
                // �D�揇��
                r.PriorityOrder = this.GetDispValue(this.tNedit_PriorityOrder);

                // �O���b�h
                if (this._view.Table.Rows.Count.Equals(0))
                {
                    r.PrmSetDtlNo2 = PMKHN09701UA.NO_SETTING;
                    r.PrmSetDtlName2 = string.Empty;
                }
                else
                {
                    foreach (DataRow dr in this._view.Table.Rows)
                    {
                        if (dr[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].Equals(r.PrmSetDtlNo2))
                        {
                            r.AutoAnswerDiv = PMKHN09701UA.GetIntNullZero(dr[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV]);
                            r.PriorityOrder = PMKHN09701UA.GetIntNullZero(dr[AutoAnsItemStAcs.ct_COL_PRIORITYORDER]);
                            break;
                        }
                    }
                }
            }

            return autoAnsItemSt;
        }
        /// <summary>
        /// ��ʏ�񎩓��񓚕i�ڐݒ�N���X�i�[���� ���������p
        /// </summary>
        /// <param name="autoAnsItemSt">�����񓚕i�ڐݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂玩���񓚕i�ڐݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// </remarks>
        private void DispToRecordForRead(ref AutoAnsItemSt autoAnsItemSt)
        {
            // ��ƃR�[�h
            autoAnsItemSt.EnterpriseCode = this._enterpriseCode;

            // ���_�R�[�h
            autoAnsItemSt.SectionCode = this.GetDispValue(this.tEdit_SectionCodeAllowZero);
            // ���Ӑ�R�[�h
            autoAnsItemSt.CustomerCode = this.GetDispValue(this.tNedit_CustomerCode);
            // ���i�����ރR�[�h
            autoAnsItemSt.GoodsMGroup = this.GetDispValueForGoodsMGroup(this.tEdit_GoodsMGroup);
            // �a�k�R�[�h
            autoAnsItemSt.BLGoodsCode = this.GetDispValue(this.tNedit_BLGoodsCode);
            // ���[�J�[�R�[�h
            autoAnsItemSt.GoodsMakerCd = this.GetDispValue(this.tNedit_GoodsMakerCd);
        }

        /// <summary>
        /// ��ʏ�񎩓��񓚕i�ڐݒ�N���X�i�[�����P
        /// </summary>
        /// <param name="Subsection">�����񓚕i�ڐݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂玩���񓚕i�ڐݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// </remarks>
        private void DispToRecord1( ref AutoAnsItemSt autoAnsItemSt )
        {
            // ��ƃR�[�h
            autoAnsItemSt.EnterpriseCode = this._enterpriseCode;

            // ���_�R�[�h
            autoAnsItemSt.SectionCode = this.GetDispValue( this.tEdit_SectionCodeAllowZero );
            // ���_��
            autoAnsItemSt.SectionNm = this.GetDispValue( this.tEdit_SectionGuideNm );
            // ���Ӑ�R�[�h
            autoAnsItemSt.CustomerCode = this.GetDispValue( this.tNedit_CustomerCode );
            // ���Ӑ於
            autoAnsItemSt.CustomerName = this.GetDispValue( this.tEdit_CustomerName );
            // ���i�����ރR�[�h
            autoAnsItemSt.GoodsMGroup = this.GetDispValueForGoodsMGroup(this.tEdit_GoodsMGroup);
            // ���i�����ޖ�
            autoAnsItemSt.GoodsMGroupName = this.GetDispValue(this.tEdit_GoodsMGroupName);
            // �a�k�R�[�h
            autoAnsItemSt.BLGoodsCode = this.GetDispValue(this.tNedit_BLGoodsCode);
            // �a�k�R�[�h��
            autoAnsItemSt.BLGoodsName = this.GetDispValue(this.tEdit_BLCodeName);
            // ���[�J�[�R�[�h
            autoAnsItemSt.GoodsMakerCd = this.GetDispValue( this.tNedit_GoodsMakerCd );
            // ���[�J�[��
            autoAnsItemSt.MakerName = this.GetDispValue( this.tEdit_GoodsMakerName );
            // ��ʁi�Ƃ肠�����O�i�ݒ薳���j��ݒ�j
            autoAnsItemSt.PrmSetDtlNo2 = PMKHN09701UA.NO_SETTING;
            // ��ʖ��́i�Ƃ肠�����󕶎��i�ݒ薳���j��ݒ�j
            autoAnsItemSt.PrmSetDtlName2 = string.Empty;
        }

        /// <summary>
        /// ��ʏ�񎩓��񓚕i�ڐݒ�N���X�i�[�����Q
        /// </summary>
        /// <param name="Subsection">�����񓚕i�ڐݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂玩���񓚕i�ڐݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// </remarks>
        private void DispToRecord2(ref AutoAnsItemSt autoAnsItemSt)
        {
            autoAnsItemSt.AutoAnswerDiv = (int)this.tComboEditor_AutoAnswerDiv.Value;

            // �D�揇��
            if (panel_Priority.Enabled)
            {
                autoAnsItemSt.PriorityOrder = this.GetDispValue(this.tNedit_PriorityOrder);
            }
            else
            {
                // �ݒ薳��
                autoAnsItemSt.PriorityOrder = PMKHN09701UA.NO_SETTING;
            }

            // �D�ǐݒ�ڍ׃R�[�h�Q�i��ʃR�[�h�j
            autoAnsItemSt.PrmSetDtlNo2 = PMKHN09701UA.NO_SETTING;
            // �D�ǐݒ�ڍז��̂Q
            autoAnsItemSt.PrmSetDtlName2 = string.Empty;
        }

        /// <summary>
        /// ��ʏ�񎩓��񓚕i�ڐݒ�N���X�i�[�����R
        /// </summary>
        /// <param name="Subsection">�����񓚕i�ڐݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂玩���񓚕i�ڐݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// </remarks>
        private void DispToRecord3(ref AutoAnsItemSt autoAnsItemSt,int i)
        {
            // ���
            autoAnsItemSt.PrmSetDtlNo2 = PMKHN09701UA.GetIntNullZero(this._view.Table.Rows[i][AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2]);
            // ��ʖ���
            autoAnsItemSt.PrmSetDtlName2 = PMKHN09701UA.GetString(this._view.Table.Rows[i][AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2]);
            // �����񓚋敪
            autoAnsItemSt.AutoAnswerDiv = PMKHN09701UA.GetIntNullZero(this._view.Table.Rows[i][AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV]);
            // �D�揇�� 
            autoAnsItemSt.PriorityOrder = PMKHN09701UA.GetIntNullZero(this._view.Table.Rows[i][AutoAnsItemStAcs.ct_COL_PRIORITYORDER]);
        }

        /// <summary>
        /// UI���͍��ڎ擾�����i��\�����ڂ͏����l��Ԃ��j
        /// </summary>
        /// <param name="tEdit"></param>
        /// <returns></returns>
        private string GetDispValue( TEdit tEdit )
        {
            if ( tEdit.Visible != false )
            {
                return tEdit.Text.Trim();
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// UI���͍��ڎ擾�����i��\�����ڂ͏����l��Ԃ��j
        /// </summary>
        /// <param name="tEdit"></param>
        /// <returns></returns>
        private int GetDispValue( TNedit tNedit )
        {
            if ( tNedit.Visible != false )
            {
                return tNedit.GetInt();
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// UI���͍��ڎ擾�����i��\�����ڂ͏����l��Ԃ��j
        /// </summary>
        /// <param name="tEdit"></param>
        /// <returns></returns>
        private int GetDispValueForGoodsMGroup(TEdit tEdit)
        {
            if ( tEdit.Visible != false )
            {
                return PMKHN09701UA.GetIntNullZero(tEdit.Text.Trim());
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// ��ʓ��͏��s���`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note		: ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
        /// </remarks>
        private bool ScreenDataCheck( ref Control control, ref string message )
        {
            bool result = true;

            // ���͍��ڈꗗ
            List<Control> ctrlList = new List<Control>();
            ctrlList.Add(tEdit_SectionCodeAllowZero);
            ctrlList.Add(tNedit_CustomerCode);
            ctrlList.Add(tEdit_GoodsMGroup);
            ctrlList.Add(tNedit_BLGoodsCode);
            ctrlList.Add(tNedit_GoodsMakerCd);
            ctrlList.Add(tNedit_PriorityOrder);
            ctrlList.Add(uGrid_Details2);

            // ���b�Z�[�W�ꗗ
            Dictionary<string, string> messageList = new Dictionary<string, string>();
            messageList.Add(tEdit_SectionCodeAllowZero.Name, "���_�R�[�h");
            messageList.Add(tNedit_CustomerCode.Name, "���Ӑ�R�[�h");
            messageList.Add(tEdit_GoodsMGroup.Name, "���i�����ރR�[�h");
            messageList.Add(tNedit_BLGoodsCode.Name, "�a�k�R�[�h");
            messageList.Add(tNedit_GoodsMakerCd.Name, "���[�J�[�R�[�h");
            messageList.Add(tNedit_PriorityOrder.Name, "�D�揇��");
            messageList.Add(uGrid_Details2.Name, "�D�揇��");

            // �\������Ă��ē��͉\�ȑS�Ă̍��ڂ͕K�{����
            foreach ( Control ctrl in ctrlList )
            {
                if ( ctrl.Visible && ctrl.Enabled )
                {
                    if ( ctrl is TNedit )
                    {
                        // �����̓`�F�b�N
                        if ( (ctrl as TNedit).GetInt() == 0 )
                        {
                            control = ctrl;
                            message = messageList[ctrl.Name] + "����͂��ĉ������B";
                            result = false;
                            break;
                        }
                    }
                    else if ( ctrl is TEdit )
                    {
                        // �����̓`�F�b�N
                        if ( (ctrl as TEdit).Text.Trim() == string.Empty )
                        {
                            control = ctrl;
                            message = messageList[ctrl.Name] + "����͂��ĉ������B";
                            result = false;
                            break;
                        }
                    }
                    else if (ctrl is UltraGrid)
                    {
                        foreach (UltraGridRow row in uGrid_Details2.Rows)
                        {
                            if (row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Activation.Equals(Activation.AllowEdit))
                            {
                                if (row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Value.Equals(DBNull.Value))
                                {
                                    control = ctrl;
                                    message = messageList[ctrl.Name] + "����͂��ĉ������B";
                                    result = false;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <param name="saveTarget">�ۑ��}�X�^ (PrdExchPNU/PrdExchPPU)</param>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note�@�@�@ : �ۑ��������s���܂��B</br>
        /// </remarks>
        private bool SaveProc()
        {
            Control control = null;
            string message = null;

            // �s���f�[�^���̓`�F�b�N
            if ( !ScreenDataCheck( ref control, ref message ) )
            {
                TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                    ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message, 							// �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.OK );				// �\������{�^��

                control.Focus();
                return false;
            }

            // �X�V
            if ( !SaveRecord() )
            {
                return false;
            }

            // �o�^�����_�C�A���O�\��
            SaveCompletionDialog dialog = new SaveCompletionDialog();
            dialog.ShowDialog(2);

            // �ۑ����s�t���O�X�V
            _isSave = true;

            return true;
        }

        /// <summary>
        /// �����񓚕i�ڐݒ�e�[�u���X�V
        /// </summary>
        /// <return>�X�V����status</return>
        /// <remarks>
        /// <br>Note       : Subsection�e�[�u���̍X�V���s���܂��B</br>
        /// </remarks>
        private bool SaveRecord()
        {
            // �o�^���R�[�h���擾(�ύX�O)
            if ( _autoAnsItemStList.Count.Equals(0) || _autoAnsItemStList[0].FileHeaderGuid == Guid.Empty )
            {
                AutoAnsItemSt r = _autoAnsItemStAcs.GetRecordForMaintenance(_recordGuid);
                if (IsUseGrid())
                {
                    _autoAnsItemStList = _autoAnsItemStAcs.GetRecordListForMaintenance(GetFilter(r), this.uGrid_Details2.Rows.Count);
                }
                else
                {
                    _autoAnsItemStList = _autoAnsItemStAcs.GetRecordListForMaintenance(GetFilter(r), 1);
                }
            }

            // �t�h����f�[�^�擾
            ArrayList writeList = GetUiData();

            // �X�V
            string msg;
            int status = _autoAnsItemStAcs.Write( ref writeList, out msg );

            // �G���[����
            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    // �d������
                    RepeatTransaction( status );
                    return false;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // �r������
                    ExclusiveTransaction( status, TMsgDisp.OPE_UPDATE, this._autoAnsItemStAcs );
                    // UI�q��ʋ����I������
                    EnforcedEndTransaction();
                    return false;
                default:
                    // �o�^���s
                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        this.Text,							// �v���O��������
                        "SaveSubsection",				    // ��������
                        TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                        ERR_UPDT_MSG,						// �\�����郁�b�Z�[�W 
                        status,								// �X�e�[�^�X�l
                        this._autoAnsItemStAcs,				    // �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,				// �\������{�^��
                        MessageBoxDefaultButton.Button1 );	// �����\���{�^��

                    // UI�q��ʋ����I������
                    EnforcedEndTransaction();

                    return false;
            }

            // ����V�K���͗p����
            NewEntryTransaction();

            return true;
        }

        /// <summary>
        /// �t�h����f�[�^�擾
        /// </summary>
        /// <param name="autoAnsItemSt"></param>
        /// <returns></returns>
        private ArrayList GetUiData()
        {
            ArrayList writeList = new ArrayList();

            if (IsUseGrid())
            {
                for (int i = 0; i < this._autoAnsItemStList.Count; i++)
                {
                    AutoAnsItemSt autoAnsItemSt = this._autoAnsItemStList[i];
                    DispToRecord1(ref autoAnsItemSt);
                    // �O���b�h����
                    DispToRecord3(ref autoAnsItemSt, i);
                    writeList.Add(autoAnsItemSt);
                }
            }
            else
            {
                AutoAnsItemSt autoAnsItemSt = this._autoAnsItemStList[0];
                DispToRecord1(ref autoAnsItemSt);
                DispToRecord2(ref autoAnsItemSt);
                writeList.Add(autoAnsItemSt);
            }
            return writeList;
        }

        /// <summary>
        /// �����񓚕i�ڐݒ� �_���폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����񓚕i�ڐݒ�̑Ώۃ��R�[�h���}�X�^����_���폜���܂��B</br>
        /// </remarks>
        private int LogicalDeleteSubsection()
        {
            int status = 0;

            return status;
        }

        /// <summary>
        /// �����񓚕i�ڐݒ� �����폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����񓚕i�ڐݒ�̑Ώۃ��R�[�h���}�X�^���畨���폜���܂��B</br>
        /// </remarks>
        private int PhysicalDeleteRecord()
        {
            int status = 0;

            // �o�^���R�[�h���擾(�ύX�O)
            if ( _autoAnsItemStList.Count.Equals(0) || _autoAnsItemStList[0].FileHeaderGuid == Guid.Empty )
            {
                AutoAnsItemSt r = _autoAnsItemStAcs.GetRecordForMaintenance(_recordGuid);
                _autoAnsItemStList = _autoAnsItemStAcs.GetRecordListForMaintenance(GetFilter(r), this.uGrid_Details2.Rows.Count);
            }

            ArrayList writeList = GetUiData();

            // �����폜
            string msg;
            status = _autoAnsItemStAcs.Delete( ref writeList, out msg );

            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // �r������
                    ExclusiveTransaction( status, TMsgDisp.OPE_DELETE, this._autoAnsItemStAcs );
                    // UI�q��ʋ����I������
                    EnforcedEndTransaction();

                    return status;
                default:
                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        this.Text,							// �v���O��������
                        "PhysicalDeleteSubsection",		    // ��������
                        TMsgDisp.OPE_HIDE,					// �I�y���[�V����
                        ERR_RDEL_MSG,						// �\�����郁�b�Z�[�W 
                        status,								// �X�e�[�^�X�l
                        this._autoAnsItemStAcs,					// �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,				// �\������{�^��
                        MessageBoxDefaultButton.Button1 );	// �����\���{�^��

                    // UI�q��ʋ����I������
                    EnforcedEndTransaction();

                    return status;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

            return status;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����񓚕i�ڐݒ�̑Ώۃ��R�[�h�𕜊����܂��B</br>
        /// </remarks>
        private int ReviveRecord()
        {
            int status = 0;

            // �o�^���R�[�h���擾(�ύX�O)
            if (_autoAnsItemStList.Count.Equals(0) || _autoAnsItemStList[0].FileHeaderGuid == Guid.Empty)
            {
                AutoAnsItemSt r = _autoAnsItemStAcs.GetRecordForMaintenance(_recordGuid);
                _autoAnsItemStList = _autoAnsItemStAcs.GetRecordListForMaintenance(GetFilter(r), this.uGrid_Details2.Rows.Count);
            }

            // �����A�����폜�͗D�ǐݒ�ڍ׃R�[�h�Q���������L�[���ځi����ʂ���1���̃��R�[�h�ōςށj��
            // ���������Ƃ��邽�߁A�p�����[�^��1���ɂ���
            ArrayList writeList = new ArrayList();
            writeList.Add(GetUiData()[0]);

            string msg;
            status = this._autoAnsItemStAcs.Revival(ref writeList, out msg);


            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // �r������
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._autoAnsItemStAcs);
                    return status;
                default:
                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOPDISP,    // �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        this.Text,							// �v���O��������
                        "ReviveSubsection",				    // ��������
                        TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                        ERR_RVV_MSG,						// �\�����郁�b�Z�[�W 
                        status,								// �X�e�[�^�X�l
                        this._autoAnsItemStAcs,					// �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,				// �\������{�^��
                        MessageBoxDefaultButton.Button1);	// �����\���{�^��
                    return status;
            }

            this.DialogResult = DialogResult.OK;
            this._isSave = true;
            this.Close();
            return status;
        }

        /// <summary>
        /// �V�K�o�^������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�K�o�^���̏������s���܂��B</br>
        /// </remarks>
        private void NewEntryTransaction()
        {
            // �V�K���[�h�̏ꍇ�͉�ʂ��I�������ɘA�����͂��\�Ƃ���
            if ( this.Mode_Label.Text == INSERT_MODE )
            {
                // �N���[���쐬
                CreateRecordCloneLIst();

                // �����t�H�[�J�X
                this.tComboEditor_SetKind1.Focus();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// �N���[���쐬
        /// </summary>
        private void CreateRecordCloneLIst()
        {
            // �N���[���쐬
            this._recordCloneList.Clear();

            if (this._autoAnsItemStList.Count.Equals(0))
            {
                this._recordCloneList.Add(new AutoAnsItemSt());
            }
            else
            {
                foreach (AutoAnsItemSt r in this._autoAnsItemStList)
                {
                    this._recordCloneList.Add(r.Clone());
                }
            }
        }

        /// <summary>
        /// UI�q��ʋ����I������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V�G���[����UI�q��ʋ����I���������s���܂��B</br>
        /// </remarks>
        private void EnforcedEndTransaction()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// �d������
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="control">�ΏۃR���g���[��</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̏d���������s���܂��B</br>
        /// </remarks>
        private void RepeatTransaction(int status)
        {
            DialogResult result =
            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                ERR_DPR_MSG, 	                    // �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.YesNo);			// �\������{�^��

            if ( result == DialogResult.Yes )
            {
                // �X�V���[�h�ɂ���

                // ���R�[�h�擾
                AutoAnsItemSt autoAnsItemSt = new AutoAnsItemSt();
                DispToRecordForRead(ref autoAnsItemSt);
                _autoAnsItemStList = new List<AutoAnsItemSt>();
                int retStatus = _autoAnsItemStAcs.Read2(autoAnsItemSt,ref _autoAnsItemStList);

                // ��ʃN���A����
                ScreenClear();
                
                if ( retStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    if (_autoAnsItemStList[0].LogicalDeleteCode == 0)
                    {
                        // �X�V
                        ScreenInputPermissionControl(1);
                    }
                    else
                    {
                        // �폜
                        ScreenInputPermissionControl(2);
                    }
                }
                // �\���X�V
                ScreenReconstruction();
            }
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="operation">�I�y���[�V����</param>
        /// <param name="erObject">�G���[�I�u�W�F�N�g</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, string operation, object erObject)
        {
            switch ( status ) {
                case ( int ) ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        this.Text,							// �v���O��������
                        "ExclusiveTransaction",				// ��������
                        operation,							// �I�y���[�V����
                        ERR_800_MSG,						// �\�����郁�b�Z�[�W 
                        status,								// �X�e�[�^�X�l
                        erObject,							// �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,				// �\������{�^��
                        MessageBoxDefaultButton.Button1);	// �����\���{�^��
                    break;
                case ( int ) ConstantManagement.DB_Status.ctDB_ALRDY_DELETE: 
                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        this.Text,							// �v���O��������
                        "ExclusiveTransaction",				// ��������
                        operation,							// �I�y���[�V����
                        ERR_801_MSG,						// �\�����郁�b�Z�[�W 
                        status,								// �X�e�[�^�X�l
                        erObject,							// �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,				// �\������{�^��
                        MessageBoxDefaultButton.Button1);	// �����\���{�^��
                    break;
            }
        }

        /// <summary>
        /// �X�V�㏈��
        /// </summary>
        private void AfterUpdate()
        {
            // �e���ڃN���A
            PanelClear(panel_AutoAnswerDiv);
            PanelClear(panel_Priority);
            PanelClear(panel_Grid);

            // �D�揇�� �͎����񓚋敪��"����(�D�揇��)"�̎��̂ݗL��
            panel_Priority.Enabled = false;

            // ���i�����ށABL�R�[�h�A���[�J�[ �����ꂩ�������͂̏ꍇ
            if ( tEdit_GoodsMGroup.Text.Equals(string.Empty)
                || tNedit_GoodsMakerCd.GetInt().Equals(0)
                ||(panel_BLCode.Visible && tNedit_BLGoodsCode.GetInt().Equals(0)))
            {
                // �����񓚋敪
                SetAutoAnswerDivEnabled(false);
                return;
            }

            // �������[�J�[���ۂ�
            bool isPure = PMKHN09701UA.IsPureMaker(tNedit_GoodsMakerCd.GetInt());

            // �����̏ꍇ
            if (isPure)
            {
                // �����񓚋敪
                SetAutoAnswerDivEnabled(true);
                tComboEditor_AutoAnswerDiv.Items.Clear();
                tComboEditor_AutoAnswerDiv.Items.AddRange(PMKHN09701UA.GetAutoAnswerDivValueArray(tNedit_GoodsMakerCd.GetInt()));
                tComboEditor_AutoAnswerDiv.SelectedIndex = 0;
                return;
            }

            // �����������@�ȉ��A�D�ǂ̏ꍇ

            if (tNedit_BLGoodsCode.GetInt().Equals(0)
                || tEdit_GoodsMGroup.Text.Equals(string.Empty))
            {
                // �����ށABL�R�[�h�A�ǂ��炩�������͂ł���ΗD�ǐݒ�}�X�^���擾�ł��Ȃ��̂ŁA�O���b�h���g�p�s��
                // �����񓚋敪
                SetAutoAnswerDivEnabled(true);
                tComboEditor_AutoAnswerDiv.Items.Clear();
                tComboEditor_AutoAnswerDiv.Items.AddRange(PMKHN09701UA.GetAutoAnswerDivValueArray(tNedit_GoodsMakerCd.GetInt()));
                tComboEditor_AutoAnswerDiv.SelectedIndex = 0;
                return;
            }
            else
            {
                // --- UPD 2012/11/22 �O�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��77 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //// �����ށABL�R�[�h�A�������͂�����΁A�D�ǐݒ�}�X�^���O���b�h�ɐݒ�
                //// ��ʋN�����Ɏ擾���Ă���D�ǐݒ�}�X�^���擾
                //DataView dv = PMKHN09701UA.OfferPrimeSettingDataView;
                //// ����������ݒ�
                //string filter = PrimeSettingInfo.COL_PARTSMAKERCD + " = " + tNedit_GoodsMakerCd.GetInt().ToString() + " AND " +
                //                PrimeSettingInfo.COL_TBSPARTSCODE + " = " + tNedit_BLGoodsCode.GetInt().ToString() + " AND " +
                //                PrimeSettingInfo.COL_MIDDLEGENRECODE + " = " + PMKHN09701UA.GetIntNullZero(tEdit_GoodsMGroup.Text).ToString();
                //dv.RowFilter = filter;
                //// �����ɂ������������̎�ʂ��擾
                //List<PMKHN09701UA.CodeAndName> type = new List<PMKHN09701UA.CodeAndName>();
                //foreach (DataRowView drv in dv)
                //{
                //    if (drv[PrimeSettingInfo.COL_PRIMEKINDCODE] != null &&
                //        (int)drv[PrimeSettingInfo.COL_PRIMEKINDCODE] >= 0)
                //    {
                //        type.Add(new PMKHN09701UA.CodeAndName(
                //            (Int32)drv[PrimeSettingInfo.COL_PRIMEKINDCODE], drv[PrimeSettingInfo.COL_PRIMEKINDNAME].ToString()));
                //    }
                //}

                //// ��ʌ�����0���ł���΁A�����񓚋敪�A�D�揇�ʂ��g�p
                //// ��ʌ�����1���ȏ�ł���΁A�O���b�h���g�p
                //// --- UPD 2012/11/22 �O�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��58 --------->>>>>>>>>>>>>>>>>>>>>>>>
                ////if (type.Count.Equals(0))
                ////�P���̏ꍇ���O���b�h���g�p���Ȃ��悤�ɏC��
                //if (type.Count < 2)
                //// --- UPD 2012/11/22 �O�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��58 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                //{
                //    // �����񓚋敪
                //    SetAutoAnswerDivEnabled(true);
                //    tComboEditor_AutoAnswerDiv.Items.Clear();
                //    tComboEditor_AutoAnswerDiv.Items.AddRange(PMKHN09701UA.GetAutoAnswerDivValueArray(tNedit_GoodsMakerCd.GetInt()));
                //    tComboEditor_AutoAnswerDiv.SelectedIndex = 0;
                //}
                //else
                //{
                //    // �����񓚋敪
                //    SetAutoAnswerDivEnabled(false);

                //    // ��ʂ��O���b�h�ɐݒ�
                //    GridCreate(type);
                //}
                // �����񓚋敪
                SetAutoAnswerDivEnabled(true);
                tComboEditor_AutoAnswerDiv.Items.Clear();
                tComboEditor_AutoAnswerDiv.Items.AddRange(PMKHN09701UA.GetAutoAnswerDivValueArray(tNedit_GoodsMakerCd.GetInt()));
                tComboEditor_AutoAnswerDiv.SelectedIndex = 0;
                // --- UPD 2012/11/22 �O�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��77 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            }
        }

        /// <summary>
        /// �����񓚋敪�R���{�̏�����
        /// </summary>
        private void tComboEditor_AutoAnswerDivInitial()
        {
            tComboEditor_AutoAnswerDiv.Items.Clear();
            // �����񓚋敪�Ƀ_�~�[�l��ݒ�
            tComboEditor_AutoAnswerDiv.Items.Add(0, "�@");
            tComboEditor_AutoAnswerDiv.SelectedIndex = 0;
        }
        # endregion

        # region Control Events

        /// <summary>
        /// Form.Load �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// </remarks>
        private void PMKHN09701UB_Load(object sender, System.EventArgs e)
        {
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList25 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList25;
            this.Cancel_Button.ImageList = imageList25;
            this.Revive_Button.ImageList = imageList25;
            this.Delete_Button.ImageList = imageList25;
            this.Renewal_Button.ImageList = imageList16;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;

            // �K�C�h�{�^���̃A�C�R���ݒ�
            this.uButton_Section.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerCode.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_GoodsMakerCd.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_GoodsMGroup.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_BLGoodsCode.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // �����񓚋敪�@������
            SetAutoAnswerDivEnabled(false);
            tComboEditor_AutoAnswerDivInitial();

            // �D�揇�ʁ@������
            panel_Priority.Enabled = false;

            // �O���b�h������
            GridNew();

            // �����t�H�[�J�X
            this.tComboEditor_SetKind1.Focus();
        }

        /// <summary>
        /// �O���b�h�̏�����
        /// </summary>
        private void GridNew()
        {
            this._view = new DataView();
            this._view = DataSetColumnConstruction();
            this.uGrid_Details2.DataSource = this._view;

            # region [�e��ݒ�]
            ColumnsCollection columns = uGrid_Details2.DisplayLayout.Bands[0].Columns;
            int visiblePosition = 0;

            // ��ʃR�[�h
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].Hidden = true;
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].Header.Caption = "��ʃR�[�h";
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].Header.Fixed = false;
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].CellAppearance.TextHAlign = HAlign.Right;
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].CellActivation = Activation.NoEdit;
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].Width = 80;
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].Header.VisiblePosition = visiblePosition++;

            // ��ʖ���
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Hidden = false;
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Header.Caption = "���";
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Header.Fixed = false;
            // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��6 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].CellAppearance.TextHAlign = HAlign.Right;
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].CellAppearance.TextHAlign = HAlign.Left;
            // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��6 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].CellActivation = Activation.NoEdit;
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Width = 200;
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Header.VisiblePosition = visiblePosition++;
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].SortIndicator = SortIndicator.Disabled;

            // �����񓚋敪
            columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Hidden = false;
            columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Header.Caption = "�����񓚋敪";
            columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Header.Fixed = false;
            // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��6 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].CellAppearance.TextHAlign = HAlign.Right;
            columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].CellAppearance.TextHAlign = HAlign.Left;
            // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��6 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].CellActivation = Activation.AllowEdit;
            columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Width = 200;
            columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].CellAppearance.ForeColorDisabled = Color.Black;
            columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].CellAppearance.BackColorDisabled = Color.LightGray;
            columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].ValueList = PMKHN09701UA.GetAutoAnswerDivValueList();
            columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Header.VisiblePosition = visiblePosition++;
            columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].SortIndicator = SortIndicator.Disabled;

            uGrid_Details2.CellListSelect += null;
            uGrid_Details2.CellListSelect += new CellEventHandler(this.uGrid_Details2_CellListSelect);

            // �D�揇�� 
            columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Hidden = false;
            columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Header.Caption = "�D�揇��";
            columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Header.Fixed = false;
            columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].CellAppearance.TextHAlign = HAlign.Right;
            columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].CellActivation = Activation.AllowEdit;
            columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Width = 50;
            columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Header.VisiblePosition = visiblePosition++;
            columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Format = "#";
            columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].SortIndicator = SortIndicator.Disabled;

            // �Z���X�^�C��
            for (int index = 0; index < columns.Count; index++)
            {
                columns[index].CellAppearance.BackColorDisabled = Color.White;
                columns[index].CellAppearance.BackColorDisabled2 = Color.White;
                columns[index].CellAppearance.BackColor = Color.Lavender;
                columns[index].CellAppearance.BackColor2 = Color.Lavender;
                columns[index].CellAppearance.TextVAlign = VAlign.Top;
            }

            #endregion
        }

        /// <summary>
        /// Control.VisibleChanged �C�x���g(PMKHN09701UB)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// </remarks>
        private void PMKHN09701UB_VisibleChanged(object sender, System.EventArgs e)
        {
            if ( this.Owner != null )
            {
                this.Owner.Activate();
            }

            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if ( this.Visible == false )
            {
                return;
            }

            // ��ʃN���A����
            ScreenClear();

            // ��ʏ����ݒ菈��
            ScreenInitialSetting();

            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Control.Click �C�x���g(Ok_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            // �o�^����
            SaveProc();
        }

        /// <summary>
        /// Control.Click �C�x���g(Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            bool cloneFlg = true;

            // �폜���[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text.Equals(DELETE_MODE))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                // ���݂̉�ʏ����擾
                List<AutoAnsItemSt> autoAnsItemStList = new List<AutoAnsItemSt>();
                foreach (AutoAnsItemSt r in this._recordCloneList)
                {
                    autoAnsItemStList.Add(r.Clone());
                }
                autoAnsItemStList = DispToRecord(autoAnsItemStList);
                // �ŏ��Ɏ擾������ʏ��Ɣ�r
                for (int i = 0; i < this._recordCloneList.Count; i++)
                {
                    cloneFlg = this._recordCloneList[i].Equals(autoAnsItemStList[i]);
                    if (!cloneFlg)
                    {
                        break;
                    }
                }

                if (cloneFlg)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                    DialogResult res = TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        "",									// �\�����郁�b�Z�[�W 
                        0,									// �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel );		// �\������{�^��

                    switch ( res )
                    {
                        case DialogResult.Yes:
                            if ( SaveProc() )
                            {
                                this.DialogResult = DialogResult.OK;
                                break;
                            }
                            else
                            {
                                return;
                            }
                        case DialogResult.No:
                            this.DialogResult = DialogResult.Cancel;
                            break;
                        default:
                            this.Cancel_Button.Focus();
                            return;
                    }
                }
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, System.EventArgs e)
        {
            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);		// �\������{�^��

            if ( result == DialogResult.Yes ) 
            {
                // �����폜
                PhysicalDeleteRecord();
                this._isSave = true;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, System.EventArgs e)
        {
            DialogResult result =
            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^�𕜊����܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.YesNo);			// �\������{�^��

            if ( result == DialogResult.Yes )
            {
                // ����
                ReviveRecord();
            }
        }

        /// <summary>
        /// Timer.Tick �C�x���g �C�x���g(Initial_Timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///					 ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///					 �X���b�h�Ŏ��s����܂��B</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
        }

        /// <summary>
        /// Control.Click �C�x���g(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// </remarks>
        private void SectionGuide_ultraButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSet secInfoSet = new SecInfoSet();

                status = _guideControl.SecInfoSetAcs.ExecuteGuid( this._enterpriseCode, true, out secInfoSet );
                if (status == 0)
                {
                    this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                    this.tEdit_SectionGuideNm.DataText = secInfoSet.SectionGuideNm.Trim();
                    _prevSectionCode = secInfoSet.SectionCode.Trim();

                    // ���t�H�[�J�X
                    this.SelectNextControl( (Control)sender, true, true, true, true );
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// tArrowKeyControlChangeFocus�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �R���g���[���̃t�H�[�J�X���ς��^�C�~���O�Ŕ������܂��B</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // �ݒ��ʂQ
                case "tComboEditor_SetKind2":
                    {
                        if (!e.ShiftKey)
                        {
                            if ( e.Key == Keys.Down )
                            {
                                e.NextCtrl = GetNextEdit( e.PrevCtrl );
                            }
                        }
                    }
                    break;
                // ���_
                case "tEdit_SectionCodeAllowZero":
                    {
                        MasterRead(ref tEdit_SectionCodeAllowZero, ref tEdit_SectionGuideNm, ref _prevSectionCode, ReadSection, ref e, "���_" );
                    }
                    break;
                // ���Ӑ�
                case "tNedit_CustomerCode":
                    {
                        // UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        // MasterRead(ref tNedit_CustomerCode, ref tEdit_CustomerName, ref _prevCustomerCode, ReadCustomer, ref e, "���Ӑ�");
                        bool status = MasterRead(ref tNedit_CustomerCode, ref tEdit_CustomerName, ref _prevCustomerCode, ReadCustomer, ref e, "���Ӑ�");
                        // UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        if (status)
                        {
                            FocusControler(e);
                        }
                        // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    }
                    break;
                // ���[�J�[
                case "tNedit_GoodsMakerCd":
                    {
                        int cdBackup = _prevGoodsMakerCd;
                        // UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        // MasterRead(ref tNedit_GoodsMakerCd, ref tEdit_GoodsMakerName, ref _prevGoodsMakerCd, ReadMaker, ref e, "���[�J�[");
                        bool status = MasterRead(ref tNedit_GoodsMakerCd, ref tEdit_GoodsMakerName, ref _prevGoodsMakerCd, ReadMaker, ref e, "���[�J�[");
                        // UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        // ���͓��e�ɕύX������΁A�e���ڍX�V
                        if (!cdBackup.Equals(tNedit_GoodsMakerCd.GetInt()))
                        {
                            // �X�V�㏈��
                            AfterUpdate();
                        }
                        // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        if (status)
                        {
                            FocusControler(e);
                        }
                        // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    }
                    break;
                // ���i������
                case "tEdit_GoodsMGroup":
                    {
                        int cdBackup = _prevGoodsMGroup;
                        MasterReadForGoodsMGroup(ref tEdit_GoodsMGroup, ref tEdit_GoodsMGroupName, ref _prevGoodsMGroup, ReadGoodsMGroup, ref e, "���i������");
                        // ���͓��e�ɕύX������΁A�e���ڍX�V
                        if (!cdBackup.Equals(_prevGoodsMGroup)) // ���̎��_�ŁAtEdit_GoodsMGroup��_prevGoodsMGroup�͓����l
                        {
                            // �X�V�㏈��
                            AfterUpdate();
                        }
                    }
                    break;
                // �a�k�R�[�h
                case "tNedit_BLGoodsCode":
                    {
                        int cdBackup = _prevBLGoodsCode;
                        MasterReadForBlGoodsCode(ref tNedit_BLGoodsCode, ref tEdit_BLCodeName, ref _prevBLGoodsCode, ReadBLCode, ref e, "�a�k�R�[�h");
                        // ���͓��e�ɕύX������΁A�e���ڍX�V
                        if (!cdBackup.Equals(tNedit_BLGoodsCode.GetInt()))
                        {
                            // �X�V�㏈��
                            AfterUpdate();
                        }
                    }
                    break;
                // �����񓚋敪
                case "tComboEditor_AutoAnswerDiv":
                // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                case "tNedit_PriorityOrder":
                case "Renewal_Button":
                case "Ok_Button":
                case "Cancel_Button":
                case "Delete_Button":
                case "uButton_GoodsMakerCd":
                // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    // UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    //if (e.ShiftKey)
                    //{
                    //    if ( e.Key == Keys.Return || e.Key == Keys.Tab )
                    //    {
                    //        // �O���ڎ擾
                    //        Control control = GetPrevEdit( e.PrevCtrl );
                    //        if ( control != null )
                    //        {
                    //            e.NextCtrl = control;
                    //        }
                    //    }
                    //}
                    FocusControler(e);
                    // UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<<
                    break;
                // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��39 --------->>>>>>>>>>>>>>>>>>>>>>>>>>
                case "uGrid_Details2":
                    if (!e.ShiftKey)
                    {
                        // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<<
                        // �ŉ��s�̏���
                        if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                        {
                            // �D�揇�ʂ��ҏW�\�̏ꍇ
                            if (uGrid_Details2.Rows[uGrid_Details2.Rows.Count - 1].Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Activated)
                            {
                                e.NextCtrl = GetNextEdit(uGrid_Details2);
                                break;
                            }
                            // �D�揇�ʂ��ҏW�s�̏ꍇ
                            else if (!uGrid_Details2.Rows[uGrid_Details2.Rows.Count - 1].Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].CanEnterEditMode
                                    && uGrid_Details2.Rows[uGrid_Details2.Rows.Count - 1].Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Activated)
                            {
                                e.NextCtrl = GetNextEdit(uGrid_Details2);
                                break;
                            }
                        }
                        // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 --------->>>>>>>>>>>>>>>>>>>>>>>>>>
                        if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                        {
                            this.uGrid_Details2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                            e.NextCtrl = null;
                        }
                    }
                    else
                    {
                        // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<<
                        // �ŏ�s�̏���
                        if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                        {
                            if (uGrid_Details2.Rows[0].Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Activated)
                            {
                                e.NextCtrl = GetPrevEdit(uGrid_Details2);
                                break;
                            }
                        }
                        // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 --------->>>>>>>>>>>>>>>>>>>>>>>>>>
                        e.NextCtrl = e.PrevCtrl;
                        if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                        {
                            this.uGrid_Details2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                            e.NextCtrl = null;
                        }
                    }
                    break;
                // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��39 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                default:
                    break;
            }
        }

        // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �t�H�[�J�X����
        /// </summary>
        /// <param name="e"></param>
        private void FocusControler(ChangeFocusEventArgs e)
        {
            if (e.ShiftKey)
            {
                // �V�t�g�L�[������
                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                {
                    e.NextCtrl = GetPrevEdit(e.PrevCtrl);
                }
            }
            else
            {
                if (e.Key == Keys.Down || e.Key == Keys.Return || e.Key == Keys.Tab)
                {
                    e.NextCtrl = GetNextEdit(e.PrevCtrl);
                }
                else if (e.Key == Keys.Up)
                {
                    e.NextCtrl = GetPrevEdit(e.PrevCtrl);
                }
            }

            // �t�H�[�J�X�J�ڐ悪�O���b�h�̏ꍇ�A�ŏ�s�ɑJ�ڂ��邩�A�ŉ��s�ɑJ�ڂ��邩
            if (e.NextCtrl.Equals(uGrid_Details2))
            {
                if (e.PrevCtrl.Equals(Renewal_Button)
                    || e.PrevCtrl.Equals(Ok_Button)
                    || e.PrevCtrl.Equals(Cancel_Button)
                    || e.PrevCtrl.Equals(Delete_Button))
                {
                    this._GridEnterUP = false;
                }
                else
                {
                    this._GridEnterUP = true;
                }

            }

        }
        // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// �e��}�X�^�ǂݍ��݋��ʏ����i���l�R�[�h�p�j
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="tEdit"></param>
        /// <param name="e"></param>
        /// <param name="proc"></param>
        /// <param name="masterName"></param>
        // UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //private void MasterRead(ref TNedit codeEdit, ref TEdit nameEdit, ref int prevCode, MasterReadForNumber proc, ref ChangeFocusEventArgs e, string masterName)
        private bool MasterRead(ref TNedit codeEdit, ref TEdit nameEdit, ref int prevCode, MasterReadForNumber proc, ref ChangeFocusEventArgs e, string masterName)
        // UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        {
            int code = codeEdit.GetInt();
            // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            bool checkOK = false;
            // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            if ( code != 0 )
            {
                // DEL 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // bool checkOK = false;
                // DEL 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                if ( code != prevCode )
                {
                    string name;
                    bool status = proc( ref code, out name );

                    if ( status )
                    {
                        checkOK = true;
                    }
                    else
                    {
                        // �G���[���b�Z�[�W
                        TMsgDisp.Show( this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          masterName + "�����݂��܂���B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK );				// �\������{�^��

                        e.NextCtrl = e.PrevCtrl;
                    }
                    codeEdit.SetInt( code );
                    nameEdit.Text = name;
                    prevCode = code;
                }
                else
                {
                    checkOK = true;
                }

                // DEL 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // ���͂n�j�Ȃ�Ύ����͍��ڂ�
                //if ( checkOK )
                //{
                //    if ( !e.ShiftKey )
                //    {
                //        if ( e.Key == Keys.Return || e.Key == Keys.Tab )
                //        {
                //            // �����ڎ擾
                //            e.NextCtrl = GetNextEdit( codeEdit );
                //        }
                //    }
                //}
                // DEL 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            else
            {
                // �N���A
                codeEdit.SetInt( 0 );
                nameEdit.Text = string.Empty;
                prevCode = 0;
                // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                checkOK = true;
                // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            }

            // DEL 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //if (e.ShiftKey)
            //{
            //    if ( e.Key == Keys.Return || e.Key == Keys.Tab )
            //    {
            //        // �O���ڎ擾
            //        Control control = GetPrevEdit( e.PrevCtrl );
            //        if ( control != null )
            //        {
            //            e.NextCtrl = control;
            //        }
            //    }
            //}
            // DEL 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            return checkOK;
            // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }
        /// <summary>
        /// �e��}�X�^�ǂݍ��݋��ʏ����i������R�[�h�p�j
        /// </summary>
        /// <param name="codeEdit"></param>
        /// <param name="nameEdit"></param>
        /// <param name="e"></param>
        /// <param name="proc"></param>
        /// <param name="masterName"></param>
        private void MasterRead(ref TEdit codeEdit, ref TEdit nameEdit, ref string prevCode, MasterReadForText proc, ref ChangeFocusEventArgs e, string masterName )
        {
            string code = codeEdit.Text.Trim();

            if ( code != string.Empty )
            {
                bool checkOK = false;

                if ( code != prevCode )
                {
                    string name;
                    bool status = proc( ref code, out name );

                    if ( status )
                    {
                        checkOK = true;
                    }
                    else
                    {
                        // �G���[���b�Z�[�W
                        TMsgDisp.Show( this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          masterName + "�����݂��܂���B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK );				// �\������{�^��

                        e.NextCtrl = e.PrevCtrl;
                    }
                    codeEdit.Text = code;
                    nameEdit.Text = name;
                    prevCode = code;
                }
                else
                {
                    checkOK = true;
                }

                // ���͂n�j�Ȃ�Ύ����͍��ڂ�
                if ( checkOK )
                {
                    if ( !e.ShiftKey )
                    {
                        if ( e.Key == Keys.Return || e.Key == Keys.Tab )
                        {
                            // �����ڎ擾
                            e.NextCtrl = GetNextEdit( codeEdit );
                        }
                    }
                }
            }
            else
            {
                // �N���A
                codeEdit.Text = string.Empty;
                nameEdit.Text = string.Empty;
                prevCode = string.Empty;
            }

            if ( e.ShiftKey )
            {
                if ( e.Key == Keys.Return || e.Key == Keys.Tab )
                {
                    // �O���ڎ擾
                    Control control = GetPrevEdit( e.PrevCtrl );
                    if ( control != null )
                    {
                        e.NextCtrl = control;
                    }
                }
            }
        }


        /// <summary>
        /// �e��}�X�^�ǂݍ��݋��ʏ����i���i�����ޗp�j
        /// </summary>
        /// <param name="codeEdit"></param>
        /// <param name="nameEdit"></param>
        /// <param name="e"></param>
        /// <param name="proc"></param>
        /// <param name="masterName"></param>
        private void MasterReadForGoodsMGroup(ref TEdit codeEdit, ref TEdit nameEdit, ref int prevCode, MasterReadForNumber proc, ref ChangeFocusEventArgs e, string masterName)
        {
            int code = PMKHN09701UA.GetIntNullZero(codeEdit.Text);

            bool checkOK = false;

            if (code != prevCode)
            {
                string name;
                bool status = proc(ref code, out name);

                if (status)
                {
                    checkOK = true;
                }
                else
                {
                    // �G���[���b�Z�[�W
                    TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                      emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                      ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                      masterName + "�����݂��܂���B", 			// �\�����郁�b�Z�[�W
                      0, 									// �X�e�[�^�X�l
                      MessageBoxButtons.OK);				// �\������{�^��

                    e.NextCtrl = e.PrevCtrl;
                }
                nameEdit.Text = name;
                prevCode = code;
            }
            else
            {
                checkOK = true;
            }

            codeEdit.Text = code.ToString("0000");

            // ���͂n�j�Ȃ�Ύ����͍��ڂ�
            if (checkOK)
            {
                if (!e.ShiftKey)
                {
                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                    {
                        // �����ڎ擾
                        e.NextCtrl = GetNextEdit(codeEdit);
                    }
                }
            }

            if (e.ShiftKey)
            {
                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                {
                    // �O���ڎ擾
                    Control control = GetPrevEdit(e.PrevCtrl);
                    if (control != null)
                    {
                        e.NextCtrl = control;
                    }
                }
            }
        }

        /// <summary>
        /// �e��}�X�^�ǂݍ��݋��ʏ����i���l�R�[�h�p�j
        /// BL�R�[�h�p
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="tEdit"></param>
        /// <param name="e"></param>
        /// <param name="proc"></param>
        /// <param name="masterName"></param>
        private void MasterReadForBlGoodsCode(ref TNedit codeEdit, ref TEdit nameEdit, ref int prevCode, MasterReadForBlCode proc, ref ChangeFocusEventArgs e, string masterName)
        {
            int code = codeEdit.GetInt();

            if (code != 0)
            {
                bool checkOK = false;

                if (code != prevCode)
                {
                    string name;
                    int goodsMGroup;
                    bool status = proc(ref code, out name, out goodsMGroup);

                    if (status)
                    {
                        checkOK = true;
                    }
                    else
                    {
                        // �G���[���b�Z�[�W
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          masterName + "�����݂��܂���B", 		// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��

                        e.NextCtrl = e.PrevCtrl;
                    }
                    codeEdit.SetInt(code);
                    nameEdit.Text = name;
                    prevCode = code;

                    // ���i������
                    tEdit_GoodsMGroup.Text = goodsMGroup.ToString();
                    MasterReadForGoodsMGroup(ref tEdit_GoodsMGroup, ref tEdit_GoodsMGroupName, ref _prevGoodsMGroup, ReadGoodsMGroup, ref e, "���i������");
                }
                else
                {
                    checkOK = true;
                }

                // ���͂n�j�Ȃ�Ύ����͍��ڂ�
                if (checkOK)
                {
                    if (!e.ShiftKey)
                    {
                        if (e.Key == Keys.Return || e.Key == Keys.Tab)
                        {
                            // �����ڎ擾
                            e.NextCtrl = GetNextEdit(codeEdit);
                        }
                    }
                }
            }
            else
            {
                // �N���A
                codeEdit.SetInt(0);
                nameEdit.Text = string.Empty;
                prevCode = 0;
            }

            if (e.ShiftKey)
            {
                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                {
                    // �O���ڎ擾
                    Control control = GetPrevEdit(e.PrevCtrl);
                    if (control != null)
                    {
                        e.NextCtrl = control;
                    }
                }
            }
        }

        /// <summary>
        /// �e��}�X�^�ǂݍ��݋��ʏ����i���l�R�[�h�p�j�擾�̂�
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="tEdit"></param>
        /// <param name="e"></param>
        /// <param name="proc"></param>
        /// <param name="masterName"></param>
        private void MasterRead( ref TNedit codeEdit, ref TEdit nameEdit, ref int prevCode, MasterReadForNumber proc )
        {
            int code = codeEdit.GetInt();

            if ( code != 0 )
            {
                string name;
                bool status = proc( ref code, out name );

                codeEdit.SetInt( code );
                nameEdit.Text = name;
                prevCode = code;
            }
            else
            {
                // �N���A
                codeEdit.SetInt( 0 );
                nameEdit.Text = string.Empty;
                prevCode = 0;
            }
        }

        /// <summary>
        /// �e��}�X�^�ǂݍ��݋��ʏ����i������R�[�h�p�j�擾�̂�
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="tEdit"></param>
        /// <param name="e"></param>
        /// <param name="proc"></param>
        /// <param name="masterName"></param>
        private void MasterRead(ref TEdit codeEdit, ref TEdit nameEdit, ref string prevCode, MasterReadForText proc)
        {
            string code = codeEdit.Text.Trim();

            if (code != string.Empty)
            {
                string name;
                bool status = proc(ref code, out name);

                codeEdit.Text = code;
                nameEdit.Text = name;
                prevCode = code;
            }
            else
            {
                // �N���A
                codeEdit.Text = string.Empty;
                nameEdit.Text = string.Empty;
                prevCode = string.Empty;
            }
        }

        /// <summary>
        /// �e��}�X�^�ǂݍ��݋��ʏ����i���i�����ޗp�j
        /// </summary>
        /// <param name="TEdit"></param>
        /// <param name="tEdit"></param>
        /// <param name="e"></param>
        /// <param name="proc"></param>
        /// <param name="masterName"></param>
        private void MasterReadForGoodsMGroup(ref TEdit codeEdit, ref TEdit nameEdit, ref int prevCode, MasterReadForNumber proc)
        {
            int code = PMKHN09701UA.GetIntNullZero(codeEdit.Text);

            string name;
            bool status = proc(ref code, out name);

            // �[���͕\���\����������
            // NullValue��"0000"��ݒ肵�Ă���
            codeEdit.Text = code.ToString("0000");
            nameEdit.Text = name;
            prevCode = code;
        }

        /// <summary>
        /// �e��}�X�^�ǂݍ��݋��ʏ����iBL�R�[�h�p�j
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="tEdit"></param>
        /// <param name="e"></param>
        /// <param name="proc"></param>
        /// <param name="masterName"></param>
        private void MasterReadForBlGoodsCode(ref TNedit codeEdit, ref TEdit nameEdit, ref int prevCode, MasterReadForBlCode proc)
        {
            int code = codeEdit.GetInt();

            if (code != 0)
            {
                string name;
                int goodsMGroup;
                bool status = proc(ref code, out name, out goodsMGroup);

                codeEdit.SetInt(code);
                nameEdit.Text = name;
                prevCode = code;
            }
            else
            {
                // �N���A
                codeEdit.SetInt(0);
                nameEdit.Text = string.Empty;
                prevCode = 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            // �ŐV���
            _guideControl.Renewal();

            TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
        }

        /// <summary>
        /// �ݒ��ʂP�@�ύX��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_SetKind1_ValueChanged( object sender, EventArgs e )
        {
            DrawPanelsBySetKind1();
        }

        /// <summary>
        /// �ݒ��ʂQ�@�ύX��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_SetKind2_ValueChanged(object sender, EventArgs e)
        {
            DrawPanelsBySetKind2();
        }

        /// <summary>
        /// ���[�J�[�K�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_GoodsMakerCd_Click( object sender, EventArgs e )
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                MakerUMnt makerUMnt;

                int status = this._guideControl.MakerAcs.ExecuteGuid( this._enterpriseCode, out makerUMnt );
                if ( status == 0 )
                {
                    // ���ʃZ�b�g
                    this.tNedit_GoodsMakerCd.SetInt( makerUMnt.GoodsMakerCd );
                    this.tEdit_GoodsMakerName.Text = makerUMnt.MakerName;

                    // ���͓��e�ɕύX������΁A�e���ڍX�V
                    if (!_prevGoodsMakerCd.Equals(tNedit_GoodsMakerCd.GetInt()))
                    {
                        // �X�V�㏈��
                        AfterUpdate();
                    }
                    _prevGoodsMakerCd = makerUMnt.GoodsMakerCd;

                    // ���t�H�[�J�X
                    this.SelectNextControl( (Control)sender, true, true, true, true );
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���i�����ރK�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_GoodsMGroup_Click( object sender, EventArgs e )
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                GoodsGroupU goodsMGroup;

                // �K�C�h�N��
                int status = this._guideControl.GoodsAcs.ExecuteGoodsMGroupGuid( this._enterpriseCode, out goodsMGroup );

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    // ���ʃZ�b�g
                    this.tEdit_GoodsMGroup.Text = goodsMGroup.GoodsMGroup.ToString("0000");
                    this.tEdit_GoodsMGroupName.Text = goodsMGroup.GoodsMGroupName;

                    // ���͓��e�ɕύX������΁A�e���ڍX�V
                    if (!_prevGoodsMGroup.Equals(PMKHN09701UA.GetIntNullZero(tEdit_GoodsMGroup.Text)))
                    {
                        // �X�V�㏈��
                        AfterUpdate();
                    }

                    _prevGoodsMGroup = goodsMGroup.GoodsMGroup;

                    // ���t�H�[�J�X
                    this.SelectNextControl( (Control)sender, true, true, true, true );
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �a�k�R�[�h�K�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_BLGoodsCode_Click( object sender, EventArgs e )
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                BLGoodsCdUMnt bLGoodsCdUMnt;

                // �K�C�h�N��
                int status = _guideControl.BLGoodsCdAcs.ExecuteGuid( this._enterpriseCode, out bLGoodsCdUMnt );
                if ( status == 0 )
                {
                    // ���ʃZ�b�g
                    this.tNedit_BLGoodsCode.SetInt( bLGoodsCdUMnt.BLGoodsCode );
                    this.tEdit_BLCodeName.Text = bLGoodsCdUMnt.BLGoodsFullName;
                    // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��32 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    // ���i�����ނ��擾���邽�߁A�ēx����
                    _guideControl.BLGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, bLGoodsCdUMnt.BLGoodsCode);
                    // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��32 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    this.tEdit_GoodsMGroup.Text = bLGoodsCdUMnt.GoodsRateGrpCode.ToString(); // ���i������
                    MasterReadForGoodsMGroup(ref tEdit_GoodsMGroup, ref tEdit_GoodsMGroupName, ref _prevGoodsMGroup, ReadGoodsMGroup);

                    // ���͓��e�ɕύX������΁A�e���ڍX�V
                    if (!_prevBLGoodsCode.Equals(tNedit_BLGoodsCode.GetInt()))
                    {
                        // �X�V�㏈��
                        AfterUpdate();
                    }

                    _prevBLGoodsCode = bLGoodsCdUMnt.BLGoodsCode;

                    // ���t�H�[�J�X
                    this.SelectNextControl( (Control)sender, true, true, true, true );
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���Ӑ�K�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_CustomerCode_Click( object sender, EventArgs e )
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �K�C�h�\��
                DialogResult result = _guideControl.CustomerSearchForm.ShowDialog();
                if ( result == DialogResult.OK && _guideControl.CustomerGuideRet != null )
                {
                    // ���ʃZ�b�g
                    this.tNedit_CustomerCode.SetInt( _guideControl.CustomerGuideRet.CustomerCode );
                    this.tEdit_CustomerName.Text = _guideControl.CustomerGuideRet.Name;
                    _prevCustomerCode = _guideControl.CustomerGuideRet.CustomerCode;

                    // ���t�H�[�J�X
                    this.SelectNextControl( (Control)sender, true, true, true, true );
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        /// <summary>
        /// ���_���̎擾
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadSection( ref string code, out string name )
        {
            if ( code == "00" )
            {
                name = "�S��";
                return true;
            }

            if ( _guideControl.SecInfoSetDic.ContainsKey( code ) )
            {
                name = _guideControl.SecInfoSetDic[code].SectionGuideNm;
                return true;
            }
            else
            {
                code = string.Empty;
                name = string.Empty;
                return false;
            }
        }

        /// <summary>
        /// ���Ӑ於�擾
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadCustomer( ref int code, out string name )
        {
            // ���������Z�b�g
            CustomerSearchPara para = new CustomerSearchPara();
            para.EnterpriseCode = _enterpriseCode;
            para.CustomerCode = code;

            // �������s
            CustomerSearchRet[] retList;
            int status = _guideControl.CustomerSearchAcs.Serch( out retList, para );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null && retList.Length > 0)
            {
                name = retList[0].Name;
                return true;
            }
            else
            {
                code = 0;
                name = string.Empty;
                return false;
            }
        }

        /// <summary>
        /// ���[�J�[���擾
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadMaker( ref int code, out string name )
        {
            bool rtn = false;
            MakerUMnt maker;
            int status = _guideControl.MakerAcs.Read( out maker, this._enterpriseCode, code );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && maker != null )
            {
                name = maker.MakerName;
                rtn = true;
            }
            else
            {
                code = 0;
                name = string.Empty;
                rtn = false;
            }

            return rtn;
        }

        /// <summary>
        /// ���i�����ޖ��擾
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadGoodsMGroup( ref int code, out string name )
        {
            if (code == 0)
            {
                name = "����";
                return true;
            }

            GoodsGroupU goodsGroupU;
            int status = _guideControl.GoodsAcs.GetGoodsMGroup( _enterpriseCode, code, out goodsGroupU );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsGroupU != null )
            {
                name = goodsGroupU.GoodsMGroupName;
                return true;
            }
            else
            {
                code = 0;
                name = string.Empty;
                return false;
            }
        }
        
        /// <summary>
        /// �a�k�R�[�h���擾
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadBLCode( ref int code, out string name ,out int goodsMGroup)
        {
            BLGoodsCdUMnt blGoodsCdUMnt;

            if (code.Equals(0))
            {
                name = "����";
                goodsMGroup = 0;
                return�@true;
            }

            int status = _guideControl.BLGoodsCdAcs.Read( out blGoodsCdUMnt, _enterpriseCode, code );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && blGoodsCdUMnt != null )
            {
                name = blGoodsCdUMnt.BLGoodsFullName;
                goodsMGroup = blGoodsCdUMnt.GoodsRateGrpCode;    // ���i������
                return true;
            }
            else
            {
                code = 0;
                name = string.Empty;
                goodsMGroup = 0;
                return false;
            }
        }

        /// <summary>
        /// ����"���͍���"���擾(�K�C�h�{�^������)
        /// </summary>
        /// <param name="currControl"></param>
        /// <returns></returns>
        private Control GetNextEdit( Control currControl )
        {
            Control nextControl;

            // �����ڎ擾
            switch ( currControl.Name )
            {
                case "tComboEditor_SetKind1":
                    nextControl = tComboEditor_SetKind2;
                    break;
                case "tComboEditor_SetKind2":
                    nextControl = tEdit_SectionCodeAllowZero;
                    break;
                case "tEdit_SectionCodeAllowZero":
                    nextControl = tNedit_CustomerCode;
                    break;
                case "tNedit_CustomerCode":
                    nextControl = tEdit_GoodsMGroup;
                    break;
                case "tEdit_GoodsMGroup":
                    nextControl = tNedit_BLGoodsCode;
                    break;
                case "tNedit_BLGoodsCode":
                    nextControl = tNedit_GoodsMakerCd;
                    break;
                case "tNedit_GoodsMakerCd":
                    nextControl = tComboEditor_AutoAnswerDiv;
                    break;
                case "tComboEditor_AutoAnswerDiv":
                    nextControl = tNedit_PriorityOrder;
                    break;
                case "tNedit_PriorityOrder":
                    nextControl = uGrid_Details2;
                    break;
                default:
                    // UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    // nextControl = Cancel_Button;
                    nextControl = Renewal_Button;
                    // UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    break;
            }

            // ���͕s�Ȃ�ċA�I�Ɏ擾
            // UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //if (!nextControl.Enabled || !nextControl.Visible)
            if (!nextControl.Enabled || !nextControl.Visible
                || (nextControl.Equals(uGrid_Details2) && uGrid_Details2.Rows.Count <= 0))
            // UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            {
                nextControl = GetNextEdit( nextControl );
            }

            // �ԋp
            return nextControl;
        }

        /// <summary>
        /// �O��"���͍���"���擾(�K�C�h�{�^������)
        /// </summary>
        /// <param name="currControl"></param>
        /// <returns></returns>
        private Control GetPrevEdit( Control currControl )
        {
            Control prevControl;

            // �O���ڎ擾
            switch ( currControl.Name )
            {
                case "tComboEditor_SetKind2":
                    prevControl = tComboEditor_SetKind1;
                    break;
                case "tEdit_SectionCodeAllowZero":
                    prevControl = tComboEditor_SetKind2;
                    break;
                case "tNedit_CustomerCode":
                    prevControl = tEdit_SectionCodeAllowZero;
                    break;
                case "tEdit_GoodsMGroup":
                    prevControl = tNedit_CustomerCode;
                    break;
                case "tNedit_BLGoodsCode":
                    prevControl = tEdit_GoodsMGroup;
                    break;
                case "tNedit_GoodsMakerCd":
                    prevControl = tNedit_BLGoodsCode;
                    break;
                case "tComboEditor_AutoAnswerDiv":
                    prevControl = tNedit_GoodsMakerCd;
                    break;
                case "tNedit_PriorityOrder":
                    prevControl = tComboEditor_AutoAnswerDiv;
                    break;
                case "uGrid_Details2":
                    prevControl = tNedit_PriorityOrder;
                    break;
                // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // ���[�J�[�̃K�C�h�{�^���́A�O���b�h�ւ̃t�H�[�J�X�ړ����e�����邽�߁A���䂷��B
                // ���̃K�C�h�{�^���͐��䂵�Ȃ�
                case "uButton_GoodsMakerCd":
                    if (uButton_BLGoodsCode.Visible)
                    {
                        prevControl = uButton_BLGoodsCode;
                    }
                    else
                    {
                        prevControl = uButton_GoodsMGroup;
                    }
                    break;
                case "Renewal_Button":
                case "Ok_Button":
                case "Cancel_Button":
                case "Delete_Button":
                    prevControl = uGrid_Details2;
                    break;
                // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                default:
                    prevControl = Cancel_Button;
                    break;
            }

            // ���͕s�Ȃ�ċA�I�Ɏ擾
            // UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // if ( !prevControl.Enabled || !prevControl.Visible )
            if (!prevControl.Enabled || !prevControl.Visible
                || (prevControl.Equals(uGrid_Details2) && uGrid_Details2.Rows.Count <= 0))
            // UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            {
                prevControl = GetPrevEdit( prevControl );
            }

            // DEL 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // �O���ڂ̓��̓`�F�b�N
            //if ( prevControl != null )
            //{
            //    if ( prevControl is TNedit )
            //    {
            //        if ( (prevControl as TNedit).GetInt() == 0 )
            //        {
            //            prevControl = null;
            //        }
            //    }
            //    else if ( prevControl is TEdit )
            //    {
            //        if ( (prevControl as TEdit).Text.Trim() == string.Empty )
            //        {
            //            prevControl = null;
            //        }
            //    }
            //}
            // DEL 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // �ԋp
            return prevControl;
        }

        /// <summary>
        /// �ݒ��ʂP�E�Q�擾����
        /// </summary>
        /// <param name="scmPrtSetting"></param>
        /// <param name="setKind1"></param>
        /// <param name="setKind2"></param>
        private void GetSetKind(AutoAnsItemSt autoAnsItemSt, out int setKind1, out int setKind2)
        {
            # region [�ݒ��ʂP]
            if (autoAnsItemSt.SectionCode == null || autoAnsItemSt.SectionCode.Trim() != string.Empty)
            {
                // 1:���_
                setKind1 = 1;
            }
            else if (autoAnsItemSt.CustomerCode != 0)
            {
                // 2:���Ӑ�
                setKind1 = 2;
            }
            else
            {
                // 0:�S��
                setKind1 = 0;
            }
            # endregion

            # region [�ݒ��ʂQ]
            if (autoAnsItemSt.BLGoodsCode != 0)
            {
                // 2:�����ށ{BL�R�[�h
                setKind2 = 2;
            }
            else 
            {
                // 1:������
                setKind2 = 1;
            }

            # endregion
        }

        # endregion

        #region �O���b�h�ݒ�
        /// <summary>
        /// �O���b�h�쐬����
        /// </summary>
        /// <param name="uGrid">�O���b�h</param>
        /// <param name="displayList">�\���f�[�^���X�g</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�̗���쐬���܂��B</br>
        /// </remarks>
        private void GridCreate(List<PMKHN09701UA.CodeAndName> typeList)
        {
            this.uGrid_Details2.DataSource = null;

            GridNew();
            this.uGrid_Details2.Enabled = true;

            DataTable tbl = this._view.Table;
            tbl.Clear();
            foreach(PMKHN09701UA.CodeAndName type in typeList)
            {
                DataRow nr = tbl.NewRow();
                nr[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2] = type.Code;
                nr[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2] = type.Name;
                // �����񓚋敪 �����l�͂O�i���Ȃ��j
                nr[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV] = 0;
                tbl.Rows.Add(nr);
            }

            this.uGrid_Details2.DataSource = this._view;
            
            // �D�揇�ʗ�̃Z���ݒ�
            foreach (UltraGridRow row in this.uGrid_Details2.Rows)
            {
                row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Activation = Activation.Disabled;
            }
        }
        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <param name="ds">�f�[�^�Z�b�g</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B</br>
        /// </remarks>
        private DataView DataSetColumnConstruction()
        {
            //----------------------------------------------------------------
            // �O���b�h�p�e�[�u�����`
            //----------------------------------------------------------------
            DataTable ForGrid = new DataTable(ct_TABLE_FORGRID);

            // ���
            ForGrid.Columns.Add(AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2, typeof(Int32));
            ForGrid.Columns.Add(AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2, typeof(string));
            // �����񓚋敪
            ForGrid.Columns.Add(AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV, typeof(string));
            // �D�揇��
            ForGrid.Columns.Add(AutoAnsItemStAcs.ct_COL_PRIORITYORDER, typeof(Int32));

            //----------------------------------------------------------------
            // �f�[�^�r���[����
            //----------------------------------------------------------------
            DataView dataView = new DataView(ForGrid);
            dataView.Sort = string.Format("{0}",AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2);

            return dataView;
        }

        #endregion

        /// <summary>
        /// �����񓚋敪�@�g�p�ېݒ�
        /// </summary>
        /// <param name="enabled">true:�g�p�@false:�g�p�s��</param>
        private void SetAutoAnswerDivEnabled(bool enabled)
        {
            panel_AutoAnswerDiv.Enabled = enabled;
            tComboEditor_AutoAnswerDiv.Enabled = enabled;
        }

        /// <summary>
        /// �����񓚋敪�@�ύX��
        /// �D�揇�ʂ̎g�p�ۂ�ݒ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_AutoAnswerDiv_ValueChanged(object sender, EventArgs e)
        {
            // �폜���[�h�̏ꍇ�͐��䂵�Ȃ�
            if (this.Mode_Label.Text.Equals(DELETE_MODE))
            {
                return;
            }
            panel_Priority.Enabled = PMKHN09701UA.IsPriority(tComboEditor_AutoAnswerDiv.Text);
            if (!panel_Priority.Enabled)
            {
                tNedit_PriorityOrder.SetInt(0);
            }
        }


        /// <summary>
        /// �O���b�h�@�h���b�v�_�E�����X�g�ύX��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details2_CellListSelect(object sender, CellEventArgs e)
        {
            if (PMKHN09701UA.IsPriority(e.Cell.Text))
            {
                // �g�p��
                e.Cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Value = DBNull.Value;
                e.Cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Activation = Activation.AllowEdit;
            }
            else
            {
                // �g�p�s��
                e.Cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Value = DBNull.Value;
                e.Cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Activation = Activation.Disabled;
            }

        }

        /// <summary>
        /// �L�[������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details2_KeyDown(object sender, KeyEventArgs e)
        {
            #region ���Z�����I������Ă���ꍇ
            if (this.uGrid_Details2.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details2.ActiveCell;

                #region ��Escape�L�[
                if (e.KeyCode == Keys.Escape)
                {
                    // �Ȃɂ����Ȃ�
                }
                #endregion
                // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<<
                switch (e.KeyData)
                {
                    case Keys.Down:
                        // �ŉ��s�̏���
                        // �D�揇�ʂ��ҏW�\�̏ꍇ
                        if (uGrid_Details2.Rows[uGrid_Details2.Rows.Count - 1].Activated)
                        {
                            GetNextEdit(uGrid_Details2).Focus();
                            e.Handled = true;
                            return;
                        }
                        break;
                    case Keys.Up:
                        // �ŉ��s�̏���
                        // �D�揇�ʂ��ҏW�\�̏ꍇ
                        if (uGrid_Details2.Rows[0].Activated)
                        {
                            GetPrevEdit(uGrid_Details2).Focus();
                            e.Handled = true;
                            return;
                        }
                        break;
                }
                // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��37 --------->>>>>>>>>>>>>>>>>>>>>>>>>>

                // �ҏW���ł������ꍇ
                if (cell.IsInEditMode)
                {
                    // �Z���̃X�^�C���ɂĔ���
                    switch (this.uGrid_Details2.ActiveCell.StyleResolved)
                    {
                        #region < �e�L�X�g�{�b�N�X�E�e�L�X�g�{�b�N�X(�{�^���t) >
                        case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            {
                                switch (e.KeyData)
                                {
                                    // ���L�[
                                    case Keys.Left:
                                        if (this.uGrid_Details2.ActiveCell.SelStart == 0)
                                        {
                                            this.uGrid_Details2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                            e.Handled = true;
                                        }
                                        break;
                                    // ���L�[
                                    case Keys.Right:
                                        if (this.uGrid_Details2.ActiveCell.SelStart >= this.uGrid_Details2.ActiveCell.Text.Length)
                                        {
                                            this.uGrid_Details2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                            e.Handled = true;
                                        }
                                        break;
                                    case Keys.Down:
                                        this.uGrid_Details2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
                                        e.Handled = true;
                                        break;
                                    case Keys.Up:
                                        this.uGrid_Details2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);
                                        e.Handled = true;
                                        break;
                                }
                                break;
                            }
                        #endregion

                        #region < ��L�ȊO�̃X�^�C�� >
                        default:
                            {
                                switch (e.KeyData)
                                {
                                    // ���L�[
                                    case Keys.Left:
                                        {
                                            this.uGrid_Details2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                            e.Handled = true;
                                        }
                                        break;
                                    // ���L�[
                                    case Keys.Right:
                                        {
                                            this.uGrid_Details2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                            e.Handled = true;
                                        }
                                        break;
                                    // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��39 --------->>>>>>>>>>>>>>>>>>>>>>>>>>
                                    case Keys.Up:
                                        {
                                            this.uGrid_Details2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);
                                            e.Handled = true;
                                        }
                                        break;
                                    case Keys.Down:
                                        {
                                            this.uGrid_Details2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
                                            e.Handled = true;
                                        }
                                        break;
                                    // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��39 ---------<<<<<<<<<<<<<<<<<<<<<<<<<<
                                }
                                break;
                            }
                        #endregion
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// �L�[���������ė�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details2.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details2.ActiveCell;

            #region ��ActiveCell���D�揇�ʂ̏ꍇ
            if (cell.Column.Key == AutoAnsItemStAcs.ct_COL_PRIORITYORDER)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��14 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    //if (!PMKHN09701UA.KeyPressNumCheck(int.MaxValue.ToString().Length, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    if (!PMKHN09701UA.KeyPressNumCheck(2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��14 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// �L�[�A�N�V����������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details2_AfterPerformAction(object sender, AfterUltraGridPerformActionEventArgs e)
        {
            switch (e.UltraGridAction)
            {
                case Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell:

                    // �A�N�e�B�u�ȃZ�������邩�H�܂��͕ҏW�\�Z�����H
                    if ((this.uGrid_Details2.ActiveCell != null) &&
                        (this.uGrid_Details2.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details2.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        // �A�N�e�B�u�Z���̃X�^�C�����擾
                        switch (this.uGrid_Details2.ActiveCell.StyleResolved)
                        {
                            // �G�f�B�b�g�n�X�^�C��
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    // �ҏW���[�h�ɂ���H
                                    if (this.uGrid_Details2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode))
                                    {
                                        if (!(this.uGrid_Details2.ActiveCell.Value is System.DBNull))
                                        {
                                            // �S�I����Ԃɂ���B
                                            this.uGrid_Details2.ActiveCell.SelStart = 0;
                                            this.uGrid_Details2.ActiveCell.SelLength = this.uGrid_Details2.ActiveCell.Text.Length;
                                        }
                                    }
                                    break;
                                }
                            default:
                                {
                                    // �G�f�B�b�g�n�ȊO�̃X�^�C���ł���΁A�ҏW��Ԃɂ���B
                                    this.uGrid_Details2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// �Z�����A�N�e�B�u�ɂȂ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details2_AfterCellActivate(object sender, EventArgs e)
        {
            this.uGrid_Details2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
        }

        /// <summary>
        /// �O���b�h�@�t�H�[�J�X�A�E�g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details2_Leave(object sender, EventArgs e)
        {
            // ActiveCell����
            if (uGrid_Details2.ActiveCell != null)
            {
                uGrid_Details2.ActiveCell.Selected = false;
                uGrid_Details2.ActiveCell = null;
            }

            // ActiveRow����
            if (uGrid_Details2.ActiveRow != null)
            {
                uGrid_Details2.ActiveRow.Selected = false;
                uGrid_Details2.ActiveRow = null;
            }
        }
        // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��39 --------->>>>>>>>>>>>>>>>>>>>>>>>>>
        private void uGrid_Details2_Enter(object sender, EventArgs e)
        {
            if (uGrid_Details2.Rows.Count <= 0)
            {
                return;
            }

            if (this._GridEnterUP)
            {
                uGrid_Details2.Rows[0].Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Activate();
            }
            else
            {
                uGrid_Details2.Rows[uGrid_Details2.Rows.Count - 1].Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Activate();
            }
        }
        // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��39 ---------<<<<<<<<<<<<<<<<<<<<<<<<<<
    }

}
